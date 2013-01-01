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

        public FtpClientManager(string ipAddress, int port)
            : base(ipAddress, port)
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
        public bool SendFile()
        {
            //Stream dest = ...
            string fullPath = mFilePath + "\\" + mFileName;
            FileInfo fInfo = new FileInfo(fullPath);

            stateObj.status = SocHandlerStatus.FTP_START;
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            if (!fInfo.Exists)
            {
                stateObj.status = SocHandlerStatus.FTP_END;
                stateObj.socMessage = string.Format("[FtpClient:SendFile] File Not Found[{0}]", mFileName);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }
            long numBytes = fInfo.Length;
            string msgRequest = String.Format(MsgDef.MSG_SEND_FILE_FMT, MsgDef.MSG_SEND_FILE, mFileName, numBytes);

            Logger.debug("[FtpClient:SendFile] SendFile Msg[{0}]", msgRequest);
            if (mSocClient.Send(msgRequest) != Encoding.UTF8.GetBytes(msgRequest).Length)
            {
                stateObj.status = SocHandlerStatus.FTP_END;
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Send FileInfo Error {0}", fullPath);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }
            Logger.debug("[FtpClient:SendFile] SendFile 1");

            stateObj.socMessage = msgRequest;
            stateObj.bufferSize = 0;
            stateObj.status = SocHandlerStatus.FTP_SENDING;

            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            Logger.debug("[FtpClient:SendFile] SendFile 2");
            stateObj.data = mSocClient.ReadLine();
            Logger.debug("[FtpClient:SendFile] SendFile 3 {0}", stateObj.data);

            if (stateObj.data != MsgDef.MSG_ACK)
            {
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Receive Ack Error : Unknown Msg{0} : file[{1}]", stateObj.data, fullPath);
                Logger.error(stateObj.socMessage);
                stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }
            Logger.debug("[FtpClient:SendFile] SendFile 4 {0}", stateObj.data);

            //using(Stream source = File.OpenRead(mFilePath+"\\"+mFileName)) {
            using (FileStream fs = new FileStream(fullPath,
                                           FileMode.Open,
                                           FileAccess.Read))
            {
                Array.Clear(bufferBin, 0, bufferBin.Length);
                byte[] buffer = bufferBin;
                int bytesRead;
                long curRead = 0;
                mSocClient.SetBinary();
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    curRead += bytesRead;
                    Logger.info("[FtpClient:SendFile] Check FIle ByteSize [{0}]", curRead);
                    int byteSize = mSocClient.Send(buffer, bytesRead);
                    if (byteSize != bytesRead)
                    {
                        stateObj.status = SocHandlerStatus.FTP_END;
                        stateObj.socMessage = string.Format("[FtpClient:SendFile] Send Stream Error : readSize[{0}] sentSize[{1}] file[{0}]", bytesRead, byteSize, fullPath);
                        Logger.error(stateObj.socMessage);
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        mSocClient.SetText();
                        return false;
                    }
                    stateObj.socMessage = msgRequest;
                    stateObj.bufferSize = bytesRead;
                    stateObj.status = SocHandlerStatus.FTP_SENDING;
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                    string line = mSocClient.ReadLine();
                    if (line != string.Format(MsgDef.MSG_RCVCHECK_FMT, MsgDef.MSG_RCVCHECK, bytesRead))
                    {
                        stateObj.socMessage = string.Format("[FtpClient:SendFile] Receive Size Check Error Msg[{0}]:bytesRead[{1}]", line, bytesRead);
                        Logger.error(stateObj.socMessage);
                        stateObj.status = SocHandlerStatus.FTP_END;
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        mSocClient.SetText();
                        return false;
                    }
                }
            }

            mSocClient.SetText();
            msgRequest = MsgDef.MSG_COMPLETE;

            Logger.info("[FtpClient:SendFile] SendFile Msg:{0}", msgRequest);
            if (mSocClient.Send(msgRequest) != msgRequest.Length)
            {
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Send Complete Error : file[{0}]", fullPath);
                Logger.error(stateObj.socMessage);
                stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }

            stateObj.data = mSocClient.ReadLine();
            if (stateObj.data != MsgDef.MSG_BYE)
            {
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Receive Bye Error : Unknown Msg[{0}] file[{1}]", stateObj.data, fullPath);
                Logger.error(stateObj.socMessage);
                stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return true;
            }

            mSocClient.Close();
            stateObj.status = SocHandlerStatus.FTP_END;
            stateObj.socMessage = string.Format("[FtpClient:SendFile] SendFile Msg:{0}", MsgDef.MSG_BYE);
            Logger.info(stateObj.socMessage);
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            return true;
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
        //public bool SendFile()
        //{
        //    if (InternalPrepareFile())
        //        InternalSendFile();
        //    return InternalFinishSending();
        //}

        public bool InternalPrepareFile() {
            //Stream dest = ...
            mFullPath = mFilePath + "\\" + mFileName;
            FileInfo fInfo = new FileInfo(mFullPath);

            stateObj.status = SocHandlerStatus.FTP_START;
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            if (!fInfo.Exists)
            {
                stateObj.status = SocHandlerStatus.FTP_END;
                stateObj.socMessage = string.Format("[FtpClient:SendFile] File Not Found[{0}]", mFileName);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }
            long numBytes = fInfo.Length;
            string msgRequest = String.Format(MsgDef.MSG_SEND_FILE_FMT, MsgDef.MSG_SEND_FILE, mFileName, numBytes);

            Logger.debug("[FtpClient:SendFile] SendFile Msg[{0}]", msgRequest);
            if (mSocClient.Send(msgRequest) != Encoding.UTF8.GetBytes(msgRequest).Length)
            {
                stateObj.status = SocHandlerStatus.FTP_END;
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Send FileInfo Error {0}", mFullPath);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }

            stateObj.socMessage = msgRequest;
            stateObj.bufferSize = 0;
            stateObj.status = SocHandlerStatus.FTP_SENDING;
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));
            stateObj.data = mSocClient.ReadLine();
            if (stateObj.data != MsgDef.MSG_ACK)
            {
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Receive Ack Error : Unknown Msg{0} : file[{1}]", stateObj.data, mFullPath);
                Logger.error(stateObj.socMessage);
                stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }
            return true;
        }

        public bool InternalSendFile() {
            //using(Stream source = File.OpenRead(mFilePath+"\\"+mFileName)) {
            using (FileStream fs = new FileStream(mFullPath,
                                           FileMode.Open,
                                           FileAccess.Read))
            {
                Array.Clear(bufferBin, 0, bufferBin.Length);
                byte[] buffer = bufferBin;
                int bytesRead;
                long curRead = 0;
                string msgRequest;
                mSocClient.SetBinary();
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (IsCanceled) { return InternalCancelSending(); }
                    curRead += bytesRead;
                    msgRequest = string.Format("[FtpClient:SendFile] Check FIle ByteSize [{0}]", curRead);
                    Logger.info(msgRequest);
                    int byteSize = mSocClient.Send(buffer, bytesRead);
                    if (byteSize != bytesRead)
                    {
                        stateObj.socMessage = string.Format("[FtpClient:SendFile] Send Stream Error : readSize[{0}] sentSize[{1}] file[{0}]", bytesRead, byteSize, mFullPath);
                        Logger.error(stateObj.socMessage);
                        stateObj.status = SocHandlerStatus.FTP_END;
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        mSocClient.SetText();
                        return false;
                    }
                    stateObj.socMessage = msgRequest;
                    stateObj.bufferSize = bytesRead;
                    stateObj.status = SocHandlerStatus.FTP_SENDING;
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                    string line = mSocClient.ReadLine();
                    if (line != string.Format(MsgDef.MSG_RCVCHECK_FMT, MsgDef.MSG_RCVCHECK, bytesRead))
                    {
                        stateObj.socMessage = string.Format("[FtpClient:SendFile] Receive Size Check Error Msg[{0}]:bytesRead[{1}]", line, bytesRead);
                        Logger.error(stateObj.socMessage);
                        stateObj.status = SocHandlerStatus.FTP_END;
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        mSocClient.SetText();
                        return false;
                    }
                }
            }
            mSocClient.SetText();
            return true;
        }

        public bool InternalFinishSending()
        {
            string msgRequest = MsgDef.MSG_COMPLETE;

            Logger.info("[FtpClient:SendFile] SendFile Msg:{0}", msgRequest);
            if (mSocClient.Send(msgRequest) != msgRequest.Length)
            {
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Send Complete Error : file[{0}]", mFullPath);
                Logger.error(stateObj.socMessage);
                if (stateObj.status != SocHandlerStatus.FTP_CANCELED)
                    stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }

            stateObj.data = mSocClient.ReadLine();
            if (stateObj.data != MsgDef.MSG_BYE)
            {
                stateObj.socMessage = string.Format("[FtpClient:SendFile] Receive Bye Error : Unknown Msg[{0}] file[{1}]", stateObj.data, mFullPath);
                Logger.error(stateObj.socMessage);
                if (stateObj.status != SocHandlerStatus.FTP_CANCELED)
                    stateObj.status = SocHandlerStatus.FTP_END;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return true;
            }

            stateObj.socMessage = string.Format("[FtpClient:SendFile] SendFile Msg:{0}", MsgDef.MSG_BYE);
            Logger.info(stateObj.socMessage);
            mSocClient.Close();
            if (stateObj.status != SocHandlerStatus.FTP_CANCELED)
                stateObj.status = SocHandlerStatus.FTP_END;
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            return true;
        }

        public bool InternalCancelSending()
        {
            stateObj.socMessage = string.Format("[FtpClient:SendFile] File Sending Canceled.");
            Logger.error(stateObj.socMessage);
            stateObj.status = SocHandlerStatus.FTP_CANCELED;
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));
            mSocClient.SetText();
            if (!InternalFinishSending()) return false;
            return true;
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
