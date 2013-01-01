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
    public class TcpSocketListener : SynchronousSocketListener
    {
        Hashtable mHtFtpListenerTable = new Hashtable();
        Object mFtpListenerTableLock = new Object();
        int mFtpPort = 0;
        string mFtpFilePath = "";

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

            Logger.debug("[TcpSocket:ProcessMsg]");
            StateObject stateObj = (StateObject)socObj;

            switch (stateObj.msgStatus)
            {
                case MSGStatus.NONE:
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

                        stateObj.socMessage = string.Format("[TcpSocket:ProcessMsg] FTP Ready for file[{0}:{1}] Msg[{2}]",
                            stateObj.FileName, stateObj.FileSize, stateObj.data);
                        stateObj.status = SocHandlerStatus.RECEIVING;

                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        Logger.info(stateObj.socMessage);

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.ERROR;
                            throw new Exception(string.Format("[TcpSocket:ProcessMsg] SendMsg Error in MSG_SEND_FILE : Msg[{0}]", stateObj.data));
                        }
                    }
                    else if (stateObj.Cmd == MsgDef.MSG_TEXT)
                    {
                        stateObj.socMessage = string.Format("[TcpSocket:ProcessMsg] Received Msg: {0}",
                            stateObj.data);
                        stateObj.status = SocHandlerStatus.RECEIVING;

                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        Logger.info(stateObj.socMessage);

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.ERROR;
                            throw new Exception(string.Format("[TcpSocket:ProcessMsg] SendMsg Error in MSG_TEXT : Msg[{0}]", stateObj.data));
                        }
                    }
                    else if (stateObj.Cmd == MsgDef.MSG_BYE)
                    {
                        stateObj.socMessage = string.Format("[TcpSocket:ProcessMsg] Received Msg: {0}",
                            stateObj.data);
                        stateObj.status = SocHandlerStatus.DISCONNECTED;

                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        Logger.info(stateObj.socMessage);
                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.ERROR;
                            throw new Exception(string.Format("[TcpSocket:ProcessMsg] SendMsg Error in MSG_BYE : Msg[{0}]", stateObj.data));
                        }

                        CloseClient(stateObj.soc);
                    }
                    else
                    {
                        stateObj.msgStatus = MSGStatus.NONE;
                        throw new Exception(string.Format("[TcpSocket:ProcessMsg] Unknown Msg[{0}] in MSGStatus.NONE", stateObj.data));
                    }
                    break;
                case MSGStatus.SENT_SVR_INFO:
                    /**
                     * 7. Cli A Done
                     * 8. Svr B BYE
                     */
                    if (stateObj.Cmd == MsgDef.MSG_COMPLETE)
                    {
                        break;
                        stateObj.socMessage = string.Format("[TcpSocket:ProcessMsg] Received Msg: {0}",
                            stateObj.data);
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                        stateObj.data = MsgDef.MSG_BYE;
                        Logger.info(stateObj.socMessage);

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            stateObj.msgStatus = MSGStatus.NONE;
                            throw new Exception(string.Format("[TcpSocket:ProcessMsg] SendMsg Error in MSG_COMPLETE : Msg[{0}]", stateObj.data));
                        }
                        stateObj.socMessage = string.Format("[TcpSocket:ProcessMsg] Sent Msg: {0}",
                            stateObj.data);
                        stateObj.msgStatus = MSGStatus.NONE;
                        OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));
                        FTP_stop(stateObj.ftpPort);
                    }
                    else
                    {
                        stateObj.msgStatus = MSGStatus.NONE;
                        throw new Exception(string.Format("[TcpSocket:ProcessMsg] Unknown Msg[{0}] in MSGStatus.SENT_SVR_INFO", stateObj.data));
                    }
                    break;
            }
            Logger.debug("[TcpSocket:ProcessMsg]");
            //Thread msgThread = new Thread(new ParameterizedThreadStart(this.SendMsg));
            //msgThread.Start(socObj);
        }

        public void SetSaveFilePath(string path)
        {
            mFtpFilePath = path;
            mServerStateObj.socMessage = string.Format("[TcpSocket:SetSaveFilePath] Save Path to:[{0}].",mFtpFilePath);
            Logger.info(mServerStateObj.socMessage);
            OnSocStatusChanged(new SocStatusEventArgs(mServerStateObj));
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

            server.SocStatusChanged += FTP_StatusChanged;

            Thread thFTPListener = new Thread(new ParameterizedThreadStart(FTP_Start));
            thFTPListener.Start(server);
            //FTP_Start(server);
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
            Logger.info("[TcpSocket:FTP_startListening] mFtpPort=" + mFtpPort);
            if (mFtpPort <= 0) return mFtpPort;

            lock (mFtpListenerTableLock)
            {
                mHtFtpListenerTable.Add(mFtpPort, server);
            }
            //this.BufferChanged(this, new EventArgs());
            return mFtpPort;
        }

        public void FTP_Start(Object server)
        {
            Logger.info("[TcpSocket:FTP_Start]server starting");
            ((FtpSocketListener)server).StartListening();
        }

        public bool FTP_stop(int port)
        {
            Logger.info("[TcpSocket:FTP_stop] port=" + port);
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
            catch (Exception e)
            {
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
    public class FtpSocketListener : SynchronousSocketListener
    {
        string filePath = "c:\\temp";
        string fileName = "";
        long fileSize = 0;
        long rcvSize = 0;
        FileStream fs;

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

        public void closeFTPConnection(object socObj)
        {
            this.CloseClient(((StateObject)socObj).soc);
            this.StopListening();
        }

        public override void ProcessMsg(object socObj)
        {
            base.ProcessMsg(socObj);
            StateObject stateObj = (StateObject)socObj;

            switch (transferStatus)
            {
                case FTPStatus.NONE:
                    if (stateObj.Cmd == MsgDef.MSG_SEND_FILE)
                    {
                        //transferStatus = FTPStatus.RECEIVED_FILE_INFO;
                        this.fileName = stateObj.FileName;
                        this.fileSize = stateObj.FileSize;

                        stateObj.data = MsgDef.MSG_ACK;
                        transferStatus = FTPStatus.RECEIVE_STREAM;
                        string validFullPath = Utils.getValidFileName(filePath, fileName, 0);

                        stateObj.socMessage = string.Format("[FtpSocket:ProcessMsg] Receiving file {0}[{1}]==>[{2}]",
                            stateObj.FileName, stateObj.FileSize, validFullPath);
                        stateObj.status = SocHandlerStatus.RECEIVING;
                        stateObj.ftpStatus = FTPStatus.RECEIVED_FILE_INFO;
                        this.SetBinary();
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        fs = File.Open(validFullPath, FileMode.CreateNew, FileAccess.Write);
                        Logger.info(stateObj.socMessage);

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            transferStatus = FTPStatus.NONE;
                            closeFTPConnection(stateObj);
                            throw new Exception(string.Format("[FtpSocket:ProcessMsg] SendMsg Error in FTPStatus.NONE: {0}", stateObj.data));
                        }
                    }
                    else
                    {
                        transferStatus = FTPStatus.NONE;
                        closeFTPConnection(stateObj);
                        throw new Exception("[FtpSocket:ProcessMsg] Unknown Msg in FTPStatus.NONE");
                    }
                    break;
                case FTPStatus.RECEIVE_STREAM:
                    //get stream to file
                    fs.Write(stateObj.buffer, 0, stateObj.bufferSize);
                    rcvSize += stateObj.bufferSize;

                    stateObj.socMessage = string.Format("[FtpSocket:ProcessMsg] rcvSize[{0}]/fileSize[{1}]", rcvSize, fileSize);
                    Logger.debug(stateObj.socMessage);
                    if (rcvSize >= fileSize)
                    {
                        fs.Close();
                        stateObj.socMessage = string.Format("[FtpSocket:ProcessMsg] rcvSize[{0}]/fileSize[{1}] Completed.", rcvSize, fileSize);
                        transferStatus = FTPStatus.SENT_DONE;
                        this.SetText();
                    }

                    stateObj.data = string.Format(MsgDef.MSG_RCVCHECK_FMT, MsgDef.MSG_RCVCHECK, stateObj.bufferSize);
                    stateObj.ftpStatus = FTPStatus.RECEIVE_STREAM;
                    stateObj.rcvFileSize = rcvSize;
                    OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));
                    Logger.debug("[FtpSocket:ProcessMsg] Sending Msg:{0}", stateObj.data);

                    if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                    {
                        transferStatus = FTPStatus.NONE;
                        closeFTPConnection(stateObj);
                        throw new Exception(string.Format("[FtpSocket:ProcessMsg] SendMsg Error in FTPStatus.RECEIVE_STREAM: {0}", stateObj.data));
                    }

                    break;
                case FTPStatus.SENT_DONE:
                    if (stateObj.Cmd == MsgDef.MSG_COMPLETE)
                    {
                        stateObj.data = MsgDef.MSG_BYE;

                        if (SendMsg(stateObj) == SocCode.SOC_ERR_CODE)
                        {
                            transferStatus = FTPStatus.NONE;
                            closeFTPConnection(stateObj);
                            throw new Exception(string.Format("[FtpSocket:ProcessMsg] SendMsg Error in FTPStatus.SENT_DONE: {0}", stateObj.data));

                        }
                        transferStatus = FTPStatus.SENT_BYE;
                        stateObj.ftpStatus = FTPStatus.SENT_DONE;
                        stateObj.status = SocHandlerStatus.DISCONNECTED;
                        stateObj.socMessage = string.Format("[FtpSocket:ProcessMsg] Msg:{0}", MsgDef.MSG_BYE);
                        Logger.info(stateObj.socMessage);
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                        closeFTPConnection(stateObj);
                    }
                    else
                    {
                        transferStatus = FTPStatus.NONE;
                        closeFTPConnection(stateObj);
                        throw new Exception(string.Format("[FtpSocket:ProcessMsg] Unknown Msg[{0}] in FTPStatus.SENT_DONE", stateObj.data));
                    }
                    break;
            }
            Logger.debug("[FtpSocket:ProcessMsg]======================================");
        }
    }
}
