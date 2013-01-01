using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class TcpSocketListener : SyncSocListener
    {
        Hashtable mHtFtpListenerTable = new Hashtable();
        Object mFtpListenerTableLock = new Object();
        int mFtpPort = 0;
        string mFtpFilePath = "";

        string mFtpKey = "FTP_SVR";

        public TcpSocketListener(int port)
            : base(port)
        {
        }
        /**
         * 1. Cli A Send File Noti, Wait for Ack
         * 2. Svr B Send File Noti, Wait for Ack to Cli C
         * 3. Cli C Run FTPListener
         * 4. Cli C Svr Info | Nack
         * 5. Svr B /Nack Run FTPListener
         * 6. Svr B Send Info | Nack
         * 7. Cli A Run FTPClient
         * 8. Cli A Done
         * 9. Svr B BYE
         * 
         * 10. Normal Message
         */
        public override void ProcessMsg(object socObj)
        {
            base.ProcessMsg(socObj);

            Logger.debug("TCP ProcessMsg Start");
            StateObject stateObj = (StateObject)socObj;

            switch (stateObj.msgStatus)
            {
                case MSGStatus.NONE:
                    //파일 정보 수신 -> FTP기동/
                    if (stateObj.Cmd == MsgDef.MSG_SEND_FILE)
                    {
                        /**
                         * 1. receive file info
                         * ----2. send file info to Cli C
                         * ----3. receive svr info 
                         * 2. run Ftp listener
                         * 3. send ack / nack
                         * 4. Cli A Ask Svr Info
                         * 5. Svr B Send Info
                         */
                        int port = FTP_startListening(0);

                        if (port > 0)
                        {
                            stateObj.data = string.Format(MsgDef.MSG_LISTEN_INFO_FMT,
                                MsgDef.MSG_LISTEN_INFO,
                                ((IPEndPoint)stateObj.soc.LocalEndPoint).Address.ToString(),
                               port);
                            stateObj.msgStatus = MSGStatus.SENT_SVR_INFO;
                            stateObj.ftpPort = port;
                        }
                        else
                        {
                            stateObj.data = MsgDef.MSG_NACK;
                            stateObj.msgStatus = MSGStatus.SENT_READY_NACK;
                        }

                        stateObj.socMessage = string.Format("FTP 수신준비상태 file[{0}:{1}]:MSG_SEND_FILE/Msg[{2}]",
                            stateObj.FileName, stateObj.FileSize, stateObj.data);
                        stateObj.status = SocHandlerStatus.RECEIVING;

                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                        Logger.info(stateObj);

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.ERROR;
                            throw new Exception(string.Format("FTP 수신준비상태 전송에러:MSG_SEND_FILE/Msg[{0}]", stateObj.data));
                        }
                    }
                    else if (stateObj.Cmd == MsgDef.MSG_TEXT)
                    {
                        stateObj.socMessage = string.Format("일반메시지 수신[{0}]", stateObj.data);
                        stateObj.status = SocHandlerStatus.RECEIVING;
                        Logger.info(stateObj);
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                        
                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.ERROR;
                            throw new Exception(string.Format("일반메시지 전송에러:MSG_TEXT/Msg[{0}]", stateObj.data));
                        }
                    }
                        //전송완료 메시지 수신 -> 
                    else if (stateObj.Cmd == MsgDef.MSG_BYE)
                    {
                        stateObj.socMessage = string.Format("종료 메시지 수신:MSG_BYE/Msg[{0}]", stateObj.data);
                        stateObj.status = SocHandlerStatus.DISCONNECTED;

                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                        Logger.info(stateObj);
                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.ERROR;
                            throw new Exception(string.Format("종료 메시지 전송에러:MSG_BYE/Msg[{0}]", stateObj.data));
                        }

                        CloseClient(stateObj.soc);
                    }
                    else
                    {
                        stateObj.msgStatus = MSGStatus.NONE;
                        throw new Exception(string.Format("Unknown Msg[{0}]:MSGStatus.NONE", stateObj.data));
                    }
                    break;
                case MSGStatus.SENT_SVR_INFO:
                    /**
                     * 7. Cli A Done
                     * 8. Svr B BYE
                     */
                    if (stateObj.Cmd == MsgDef.MSG_COMPLETE)
                    {
                        stateObj.socMessage = string.Format("파일수신완료:SENT_SVR_INFO/Msg[{0}]",
                            stateObj.data);
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));

                        stateObj.data = MsgDef.MSG_BYE;
                        Logger.info(stateObj);

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.NONE;
                            throw new Exception(string.Format("파일수신종료 전송에러:MSG_COMPLETE/Msg[{0}]", stateObj.data));
                        }
                        stateObj.socMessage = string.Format("파일수신종료 전송:MSG_COMPLETE/Msg[{0}]", stateObj.data);
                        stateObj.msgStatus = MSGStatus.NONE;
                        OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));
                        FTP_stop(stateObj.ftpPort);
                    }
                    else
                    {
                        stateObj.msgStatus = MSGStatus.NONE;
                        throw new Exception(string.Format("Unknown Msg[{0}]:MSGStatus.SENT_SVR_INFO", stateObj.data));
                    }
                    break;
            }
            stateObj.socMessage = "TCP ProcessMsg End";
            Logger.debug(stateObj);
        }

        public void SetSaveFilePath(string path)
        {
            mFtpFilePath = path;
            mServerStateObj.socMessage = string.Format("Save Path to [{0}].",mFtpFilePath);
            Logger.debug(mServerStateObj);
            OnSocStatusChangedOnDebug(new SocStatusEventArgs(mServerStateObj));
        }

        protected void FTP_StatusChanged(object sender, SocStatusEventArgs e)
        {
            //if (e.Status.Cmd == MsgDef.MSG_BYE)
            //{
            //   server.
            //}
            base.OnSocStatusChanged(e);
        }

        public int FTP_startListening(int port)
        {
            mFtpPort = port;
            FtpSocketListener server;

            if (mFtpFilePath.Trim() == "" )
                server = new FtpSocketListener(mFtpPort);
            else
                server = new FtpSocketListener(mFtpPort, mFtpFilePath);
            server.SetKey(mFtpKey);
            server.SocStatusChanged += FTP_StatusChanged;

            Thread thFTPListener = new Thread(new ParameterizedThreadStart(FTP_Start));
            thFTPListener.Start(server);

            //포트 할당 기다려 포트값 가져옴
            int i = 0;
            while (true)
            {
                mFtpPort = server.getListeningPort();
                if (mFtpPort == 0 && i < 5)
                {
                    System.Threading.Thread.Sleep(100);
                    i++;
                    continue;
                }
                else
                {
                    break;
                }
            }
            Logger.info("할당된 포트(mFtpPort:{0})", mFtpPort);
            if (mFtpPort <= 0) return mFtpPort;

            lock (mFtpListenerTableLock)
            {
                mHtFtpListenerTable.Add(mFtpPort, server);
            }
            return mFtpPort;
        }

        public void FTP_Start(Object server)
        {
            Logger.info("FTP Server starting port[{0}]", ((FtpSocketListener)server).getListeningPort());
            ((FtpSocketListener)server).StartListening();
        }

        public bool FTP_stop(int port)
        {
            Logger.info("FTP_stop port[{0}]", port);
            try
            {
                lock (mClientTableLock)
                {
                    if (mHtFtpListenerTable.ContainsKey(port))
                    {
                        ((FtpSocketListener)mHtFtpListenerTable[port]).StopListening();
                    }
                    mHtClientTable.Remove(port);
                }
            }
            catch (Exception ex)
            {
                setErrorMessage(ex,"FTP Server 중지실패");
                return false;
            }
            return true;
        }

    }

    /**
     * 1. Receive READY:File Name:File Size
     * 2. Check File Path
     * 3. Send Ack
     *        - Fail Send Nack
     * 4. Receive Stream
     *      - Save to File
     *      - Check EndOfFile by File Size
     * 5. Send Done
     * 6. Receive Ack
     * 7. Send Ack
     * 8. Receive BYE
     * 9. Send Bye
     */
    public class FtpSocketListener : SyncSocListener
    {
        string filePath = "c:\\temp";
        string fileName;
        string tempFullPath;
        string validFullPath;
        long fileSize = 0;
        long rcvSize = 0;
        FileStream fs;
        bool closedOnError = false;

        FTPStatus transferStatus = FTPStatus.NONE;

        public FtpSocketListener(int port, string path)
            : this(port)
        {
            filePath = path;
        }

        public FtpSocketListener(int port)
            : base(port)
        {
            mClientSize = 1;
            mWaitCount = SocConst.FTP_WAIT_COUNT;
            mWaitTimeOut = SocConst.FTP_WAIT_TIMEOUT;
        }

        void Initialize()
        {
            transferStatus = FTPStatus.NONE;
            rcvSize = 0;
            fileName = "";
            fileSize = 0;
        }

        public override void OnSocStatusChanged(SocStatusEventArgs e)
        {
            if (e.Status.status == SocHandlerStatus.CONNECTED
                || e.Status.status == SocHandlerStatus.DISCONNECTED)
            {
                Initialize();
            }
            if (e.Status.status == SocHandlerStatus.ERROR)
            {
                if (!closedOnError)
                {
                    closedOnError = true;
                    closeFTPConnection(e.Status);
                }
            }
            base.OnSocStatusChanged(e);
        }


        public string toString()
        {
            return mServerSoc.LocalEndPoint.ToString();
        }

        public int getListeningPort()
        {
            return mPort;
        }

        private void closeOnError(object socObj, string errMsg)
        {
            transferStatus = FTPStatus.NONE;
            closedOnError = true;
            closeFTPConnection(socObj);
            throw new Exception(errMsg);
        }
        public void closeFTPConnection(object socObj)
        {
            if (fs != null) fs.Close();
            if (tempFullPath != null && File.Exists(tempFullPath))
                File.Delete(tempFullPath);
            this.CloseClient(((StateObject)socObj).soc);
            this.StopListening();
        }

        public override void ReceiveMsg(object client)
        {
            base.ReceiveMsg(client);
        }

        public override void ProcessMsg(object socObj)
        {
            base.ProcessMsg(socObj);
            StateObject stateObj = (StateObject)socObj;

            switch (transferStatus)
            {
                case FTPStatus.NONE:
                    //파일수신정보
                    if (stateObj.Cmd == MsgDef.MSG_SEND_FILE)
                    {
                        this.fileName = stateObj.FileName;
                        this.fileSize = stateObj.FileSize;
                        validFullPath = Utils.getValidFileName(filePath, fileName, 0);
                        tempFullPath = validFullPath + SocConst.TEMP_FILE_SUFFIX;
                        
                        //수신대기상태
                        stateObj.data = MsgDef.MSG_ACK;

                        //파일수신상태로 변경
                        transferStatus = FTPStatus.RECEIVE_STREAM;
                        this.SetBinary();

                        stateObj.status = SocHandlerStatus.RECEIVING;
                        stateObj.ftpStatus = FTPStatus.RECEIVED_FILE_INFO;
                        stateObj.socMessage = string.Format("파일수신정보[{0}/{1}]==>[{2}]",
                            stateObj.FileName, stateObj.FileSize, validFullPath);

                        Logger.info(stateObj);
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                        
                        fs = File.Open(tempFullPath, FileMode.Create, FileAccess.Write);
                        //수신대기 알림
                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            closeOnError(stateObj, string.Format("파일수신 대기메시지 전송에러:FTPStatus.NONE/Msg[{0}]", stateObj.data));
                        }
                    }
                    else
                    {
                        closeOnError(stateObj, string.Format("Unknown Msg[{0}]:FTPStatus.NONE", stateObj.data));
                    }
                    break;

                //파일 수신
                case FTPStatus.RECEIVE_STREAM:
                    //파일 전송 취소인경우
                    if (stateObj.Cmd == MsgDef.MSG_CANCEL)
                    {
                        //수신종료
                        stateObj.data = MsgDef.MSG_BYE;
                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            closeOnError(stateObj, string.Format("파일수신종료메시지 전송에러:FTPStatus.SENT_DONE/Msg[{0}]", stateObj.data));
                        }
                        //종료로 상태변경
                        transferStatus = FTPStatus.SENT_BYE;
                        stateObj.ftpStatus = FTPStatus.SENT_DONE;
                        stateObj.status = SocHandlerStatus.DISCONNECTED;
                        stateObj.socMessage = string.Format("파일수신종료/Msg[{0}]", MsgDef.MSG_BYE);
                        Logger.info(stateObj);
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                        closeFTPConnection(stateObj);
                        break;
                    }
                    //수신파일스트림 Write
                    fs.Write(stateObj.buffer, 0, stateObj.bufferSize);
                    rcvSize += stateObj.bufferSize;

                    stateObj.socMessage = string.Format("수신중인 바이트:rcvSize[{0}]/fileSize[{1}]", rcvSize, fileSize);
                    Logger.debug(stateObj);
                    //수신완료
                    if (rcvSize >= fileSize)
                    {
                        fs.Close();
                        File.Move(tempFullPath, validFullPath);
                        stateObj.socMessage = string.Format("수신완료한 바이트 rcvSize[{0}]/fileSize[{1}]", rcvSize, fileSize);
                        transferStatus = FTPStatus.SENT_DONE;
                        this.SetText();
                    }

                    stateObj.data = string.Format(MsgDef.MSG_RCVCHECK_FMT, MsgDef.MSG_RCVCHECK, stateObj.bufferSize);
                    stateObj.ftpStatus = FTPStatus.RECEIVE_STREAM;
                    stateObj.fileSizeDone = rcvSize;
                    OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

                    stateObj.socMessage = string.Format("수신바이트 확인전송:Msg[{0}]", stateObj.data);
                    Logger.debug(stateObj);

                    if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                    {
                        closeOnError(stateObj, string.Format("수신바이트 확인전송에러:FTPStatus.RECEIVE_STREAM/Msg[{0}]", stateObj.data));
                    }

                    break;
                    //수신완료
                case FTPStatus.SENT_DONE:
                    if (stateObj.Cmd == MsgDef.MSG_COMPLETE)
                    {
                        //수신종료
                        stateObj.data = MsgDef.MSG_BYE;

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            closeOnError(stateObj, string.Format("파일수신종료메시지 전송에러:FTPStatus.SENT_DONE/Msg[{0}]", stateObj.data));

                        }
                        transferStatus = FTPStatus.SENT_BYE;
                        stateObj.ftpStatus = FTPStatus.SENT_DONE;
                        stateObj.status = SocHandlerStatus.DISCONNECTED;
                        stateObj.socMessage = string.Format("파일수신종료:{0}", MsgDef.MSG_BYE);
                        Logger.info(stateObj);
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                        closeFTPConnection(stateObj);
                    }
                    else
                    {
                        closeOnError(stateObj, string.Format("Unknown Msg[{0}]:FTPStatus.SENT_DONE", stateObj.data));
                    }
                    break;
            }
            stateObj.socMessage = string.Format("Ftp ProcessMsg End");
            Logger.debug(stateObj);
        }
    }
}
