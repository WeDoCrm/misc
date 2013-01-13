using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class FtpClientManager : TcpClientManager
    {
        string mFilePath;
        string mFileName;
        string mFullPath;
        bool IsCanceled = false;
        FileStream mFs;

        public FtpClientManager(string ipAddress, int port)
            : base(ipAddress, port, "ftp_cli", SocConst.FTP_WAIT_TIMEOUT)
        {
        }

        public FtpClientManager(string ipAddress, int port, string key)
            : base(ipAddress, port, key, SocConst.FTP_WAIT_TIMEOUT)
        {
        }

        public void setFileName(string fileName)
        {
            mFileName = fileName;
        }

        public void setFilePath(string filePath)
        {
            mFilePath = filePath;
        }

        public void setKey(string key)
        {
            stateObj.key = key;
        }

        public string getFullPath()
        {
            return mFilePath + "\\" + mFileName;
        }

        /**
         * 1. Send READY:FILENAME:FileSize
         * 2. Receive ACK
         *    - NACK return failure
         * 3. Send stream
         * 4. Receive Done
         * 5. Send Ack 
         * 5. Receive ACK
         * 6. Send BYE
         * 7. Receive BYE
         */
        public bool SendFile()
        {
            if (InternalPrepareFile())
                InternalSendFile();
            if (stateObj.status == SocHandlerStatus.FTP_CANCELED)
            {
                InternalSendCancelMsg();
                return InternalFinishSending();
            }
            else
            {
                InternalSendCompleteMsg();
                return InternalFinishSending();
            }
        }

        //파일전송준비
        public bool InternalPrepareFile() {
            //Stream dest = ...
            mFullPath = mFilePath + "\\" + mFileName;
            FileInfo fInfo = new FileInfo(mFullPath);

            stateObj.status = SocHandlerStatus.FTP_START;
            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

            if (!fInfo.Exists)
            {
                _internalHandleOnError(string.Format("File Not Found[{0}]", mFileName));
                return false;
            }
            //파일정보 전송
            long numBytes = fInfo.Length;
            stateObj.FileSize = fInfo.Length;
            string msgRequest = String.Format(MsgDef.MSG_SEND_FILE_FMT, MsgDef.MSG_SEND_FILE, mFileName, numBytes);

            stateObj.socMessage = string.Format("파일정보전송:Msg[{0}]", msgRequest);
            Logger.debug(stateObj);

            if (mSocClient.Send(msgRequest) != Encoding.UTF8.GetBytes(msgRequest).Length)
            {
                _internalHandleOnError(string.Format("파일정보전송에러:Msg[{0}]", msgRequest));
                return false;
            }

            //수신준비상태확인 
            stateObj.bufferSize = 0;
            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

            stateObj.data = mSocClient.ReadLine();
            if (stateObj.data != MsgDef.MSG_ACK)
            {
                _internalHandleOnError(string.Format("수신준비 비정상상태:Unknown Msg[{0}]/file[{1}]", stateObj.data, mFullPath));
                return false;
            }
            return true;
        }

        private void _internalHandleOnError(string msg)
        {
            stateObj.socMessage = msg;
            Logger.error(stateObj);
            stateObj.status = SocHandlerStatus.FTP_ERROR;
            mSocClient.SetText();
            if (mFs != null) mFs.Close();
            OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
        }

        //파일전송
        public bool InternalSendFile() {
            bool result = true;
            //using(Stream source = File.OpenRead(mFilePath+"\\"+mFileName)) {
            using (mFs = new FileStream(mFullPath,FileMode.Open,FileAccess.Read))
            {
                try
                {
                    Array.Clear(bufferBin, 0, bufferBin.Length);
                    byte[] buffer = bufferBin;
                    byte[] bPrefix;
                    int bytesRead;
                    long curRead = 0;
                    mSocClient.SetBinary();
                    while ((bytesRead = mFs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        //취소시 취소처리
                        if (IsCanceled) { 
                            result = _InternalCancelSending();
                            break;
                        }
                        //전송할 byte정보
                        bPrefix = Utils.ConvertFileSizeToByteArray(bytesRead);
                        curRead += bytesRead;
                        stateObj.socMessage = string.Format("전송바이트Size[{0}]/[{1}]", curRead, stateObj.FileSize);
                        Logger.info(stateObj);
                        //전송할 byte정보 전송
                        int bytePrefixSize = mSocClient.Send(bPrefix, bPrefix.Length);
                        //전송할 스트림 전송
                        int byteSize = mSocClient.Send(buffer, bytesRead);
                        if (bytePrefixSize != bPrefix.Length || byteSize != bytesRead)
                        {
                            _internalHandleOnError(string.Format("전송 Error : 확인Size[{0}]/전송Size[{1}] file[{0}]", bytesRead, byteSize, mFullPath));
                            result = false;
                            break;
                        }
                        stateObj.bufferSize = bytesRead;
                        stateObj.fileSizeDone = curRead;
                        stateObj.status = SocHandlerStatus.FTP_SENDING;
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));

                        //수신정보 확인
                        string line = mSocClient.ReadLine();
                        if (line == MsgDef.MSG_CANCEL)
                        {
                            result = _InternalCancelByServer();
                            break;
                        }
                        else if (line == string.Format(MsgDef.MSG_RCVCHECK_FMT, MsgDef.MSG_RCVCHECK, bytesRead))
                        {
                            continue;
                        }
                        else
                        {
                            _internalHandleOnError(string.Format("수신 SizeCheck Error Msg[{0}]/실제전송byte수[{1}]", line, bytesRead));
                            result = false;
                            break;
                        }
                    }
                }
                finally
                {
                    if (mFs != null) mFs.Close();
                    mSocClient.SetText();
                }
            }
            return result;
        }

        //파일전송완료 메시지보냄
        public bool InternalSendCompleteMsg()
        {
            return _InternalSendMsg(MsgDef.MSG_COMPLETE);
        }
        //파일전송취소 메시지보냄
        public bool InternalSendCancelMsg()
        {
            return _InternalSendMsg(MsgDef.MSG_CANCEL);
        }

        private bool _InternalSendMsg(string msgRequest)
        {
            stateObj.socMessage = string.Format("메시지전송:Msg[{0}]/파일전송관련", msgRequest);
            Logger.info(stateObj);
            if (mSocClient.Send(msgRequest) != msgRequest.Length)
            {
                stateObj.socMessage = string.Format("메시지전송 Error:file[{0}]/파일전송관련", mFullPath);
                Logger.error(stateObj);
                if (!StatusEnded())
                    stateObj.status = SocHandlerStatus.FTP_ERROR;
                OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
                return false;
            }
            return true;
        }

        //파일전송종료: 종료메시지수신/정리
        public bool InternalFinishSending()
        {
            stateObj.data = mSocClient.ReadLine();
            if (stateObj.data != MsgDef.MSG_BYE)
            {
                stateObj.socMessage = string.Format("전송종료 메시지수신 Error:Unknown Msg[{0}] file[{1}]", stateObj.data, mFullPath);
                Logger.error(stateObj);
                if (!StatusEnded())
                    stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
                return false;
            }

            mSocClient.Close();

            stateObj.socMessage = string.Format("전송종료 메시지수신 Msg:{0}", MsgDef.MSG_BYE);
            Logger.info(stateObj);
            if (!StatusEnded())
                stateObj.status = SocHandlerStatus.FTP_END;

            OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
            if (stateObj.status == SocHandlerStatus.FTP_ERROR)
                return false;
            else
                return true;
        }

        public bool _InternalCancelByServer()
        {
            stateObj.socMessage = string.Format("수신취소 메시지수신");
            Logger.info(stateObj);
            stateObj.status = SocHandlerStatus.FTP_SERVER_CANCELED;
            //OnSocStatusChanged(new SocStatusEventArgs(stateObj));
            if (mFs != null) mFs.Close();
            mSocClient.SetText();
            return true;
        }

        public bool _InternalCancelSending()
        {
            stateObj.socMessage = string.Format("전송취소");
            Logger.info(stateObj);
            stateObj.status = SocHandlerStatus.FTP_CANCELED;
            //OnSocStatusChanged(new SocStatusEventArgs(stateObj));
            if (mFs != null) mFs.Close();
            mSocClient.SetText();
            return true;
        }

        private bool StatusEnded()
        {
            return (stateObj.status == SocHandlerStatus.FTP_CANCELED
                || stateObj.status == SocHandlerStatus.FTP_END
                || stateObj.status == SocHandlerStatus.FTP_ERROR
                || stateObj.status == SocHandlerStatus.FTP_SERVER_CANCELED);
        }

        public void CancelSending()
        {
            IsCanceled = true;
        }

        protected override void TcpClientStatusChanged(object sender, SocStatusEventArgs e)
        {
            base.OnSocStatusChanged(e);
        }
    }
}
