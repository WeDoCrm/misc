using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Threading;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class SyncSocListener
    {
        protected Socket mServerSoc;

        public event EventHandler<SocStatusEventArgs> SocStatusChanged;
        protected int mPort = 0;
        public Hashtable mHtClientTable;
        protected Object mClientTableLock = new Object();
        protected Object mServerLock = new Object();
        protected StateObject mServerStateObj;
        protected string mKey;
        protected byte[] bufferTxtRcv = new byte[SocConst.MAX_STR_BUFFER_SIZE];
        protected byte[] bufferBinRcv = new byte[SocConst.TEMP_BUFFER_SIZE];
        protected byte[] bufferTxtStateObj = new byte[SocConst.MAX_STR_BUFFER_SIZE];
        protected byte[] bufferBinStateObj = new byte[SocConst.MAX_BUFFER_SIZE];

        protected bool IsText = true;
        protected int mClientSize = 20;
        protected int mWaitCount = 0;
        protected int mWaitTimeOut = 0;//milsec

        public SyncSocListener(int port)
        {
            mPort = port;
        }

        public void SetKey(string key)
        {
            mKey = key;
        }

        public void SetText()
        {
            this.IsText = true;
        }

        public void SetBinary()
        {
            this.IsText = false;
        }

        public void StartListening()
        {

            IPHostEntry ipHostInfo = new IPHostEntry();
            ipHostInfo.AddressList = new IPAddress[] { new IPAddress(new Byte[] { 127, 0, 0, 1 }) };
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Any, mPort);

            // Create a TCP/IP socket.
            mServerSoc = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            mServerSoc.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, (int)1);

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                mServerSoc.Bind(localEndPoint);
                mServerSoc.Listen(10);
                mServerStateObj = new StateObject(mServerSoc, "");
                mServerStateObj.key = mKey;
                mServerStateObj.status = SocHandlerStatus.LISTENING;

                if (mPort == 0)
                    mPort = ((IPEndPoint)mServerSoc.LocalEndPoint).Port;

                Logger.info(string.Format("Start Listening. port[{0}]", mPort));

                mHtClientTable = new Hashtable();
                int waitCount = 0;

                // Start listening for connections.
                while (true)
                {
                    lock (mClientTableLock)
                    {
                        if (mHtClientTable.Count >= mClientSize)
                        {
                            if (mWaitCount > 0) //0인경우 무한반복허용
                                waitCount++;
                            if (mWaitCount > 0 && waitCount >= mWaitCount)
                            {
                                Logger.info(string.Format("Wait 횟수 {0}회 초과.", waitCount));
                                StopListening();
                                break;
                            }
                            mServerStateObj.socMessage = string.Format("Wait 허용접속자수 초과 {0} >= {1}", mHtClientTable.Count, mClientSize);
                            Logger.debug(mServerStateObj);
                            System.Threading.Thread.Sleep(SocConst.WAIT_MIL_SEC);
                            continue;
                        }
                    }

                    lock (mServerLock)
                    {
                        if (mServerStateObj.status == SocHandlerStatus.STOP)
                        {
                            Logger.info("ServerSocket Stopped.");
                            return;
                        }
                    }

                    // Program is suspended while waiting for an incoming connection.
                    mServerStateObj.socMessage = string.Format("Port[{0}] 접속대기...", mPort);
                    Logger.info(mServerStateObj);
                    OnSocStatusChangedOnInfo(new SocStatusEventArgs(mServerStateObj));
                    Socket soc = mServerSoc.Accept();
                    //WaitTimeOut 0 이상 설정한 경우 적용
                    if (mWaitTimeOut > 0)
                    {
                        //soc.SetSocketOption(SocketOptionLevel.Socket,
                        //            SocketOptionName.ReceiveTimeout, mWaitTimeOut);
                        soc.ReceiveTimeout = mWaitTimeOut;
                        soc.SendTimeout = mWaitTimeOut;
                    }

                    lock (mClientTableLock)
                    {
                        StateObject stateObj = new StateObject(soc, "");
                        stateObj.key = mKey + "_CLI" + mHtClientTable.Count;
                        stateObj.status = SocHandlerStatus.CONNECTED;
                        stateObj.socMessage = string.Format("Soc Accepted:{0}", soc.RemoteEndPoint.ToString());
                        Logger.info(stateObj);
                        OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));

                        mHtClientTable.Add(soc.RemoteEndPoint.ToString(), soc);
                    }
                    Thread thClient = new Thread(new ParameterizedThreadStart(this.ReceiveMsg));
                    thClient.Start(soc);
                }
                   
            }
            catch (SocketException e)
            {
                if (e.ErrorCode == 10004) //정상 종료
                {
                    Logger.info("Socket errorCode[{0}]", e.ErrorCode);
                }
                else {
                    setErrorMessage(e, "Server Listening Error:" + e.ToString());
                }
            }
            catch (Exception e)
            {
                setErrorMessage(e, "Server Listening Error:" + e.ToString());
            }


        }

        public void StopListening()
        {
            lock (mServerLock)
            {
                mServerStateObj.status = SocHandlerStatus.STOP;
                mServerStateObj.socMessage = "Server Listening Stopped.";
                Logger.info(mServerStateObj);
                OnSocStatusChangedOnInfo(new SocStatusEventArgs(mServerStateObj));
                mServerSoc.Close();
            }
        }

        public void listClient()
        {
            lock (mClientTableLock)
            {
                if (mHtClientTable == null) return;

                foreach (DictionaryEntry entry in mHtClientTable)
                {
                    StateObject stateObj = new StateObject(null, String.Format("{0}, {1}", entry.Key, entry.Value));
                    stateObj.socMessage = string.Format("{0}, {1}", entry.Key, entry.Value);
                    Logger.info(stateObj);
                    OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                }
            }
        }

        public virtual void OnSocStatusChanged(SocStatusEventArgs e)
        {
            EventHandler<SocStatusEventArgs> handler = SocStatusChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        public virtual void OnSocStatusChangedOnDebug(SocStatusEventArgs e)
        {
            if (Logger.level >= LOGLEVEL.DEBUG)
                OnSocStatusChanged(e);
        }

        public virtual void OnSocStatusChangedOnInfo(SocStatusEventArgs e)
        {
            if (Logger.level >= LOGLEVEL.INFO)
                OnSocStatusChanged(e);
        }

        public virtual void OnSocStatusChangedOnError(SocStatusEventArgs e)
        {
            if (Logger.level >= LOGLEVEL.ERROR)
                OnSocStatusChanged(e);
        }

        public virtual void ReceiveMsg(object client)
        {
            Socket clientSoc = (Socket)client;
            StateObject stateObj = new StateObject(clientSoc);
            lock (mClientTableLock)
            {
                stateObj.key = mKey + "_CLI" + mHtClientTable.Count;
            }
            try
            {
                // An incoming connection needs to be processed.
                while (true)
                {
                    int recv = 0;
                    stateObj.bufferSize = 0;
                    stateObj.data = "";
                    stateObj.socMessage = "";
                    byte[] buffer;
                    if (IsText) //일반메시지
                    {
                        Array.Clear(this.bufferTxtRcv, 0, this.bufferTxtRcv.Length);
                        buffer = bufferTxtRcv;
                        Array.Clear(this.bufferTxtStateObj, 0, this.bufferTxtStateObj.Length);
                        stateObj.buffer = bufferTxtStateObj;
                    }
                    else //파일수신
                    {
                        Array.Clear(this.bufferBinRcv, 0, this.bufferBinRcv.Length);
                        buffer = bufferBinRcv;
                        Array.Clear(this.bufferBinStateObj, 0, this.bufferBinStateObj.Length);
                        stateObj.buffer = bufferBinStateObj;
                    }

                    //
                    if (!IsSocketReadyToReceive(stateObj))
                    {
                        stateObj.socMessage = "소켓수신상태 Disconnected or Error.";
                        Logger.info(stateObj);
                        return;
                    }

                    int receivingByteInfo = 0;
                    //단일 메시지 수신
                    while (true)
                    {
                        stateObj.status = SocHandlerStatus.RECEIVING;
                        if (IsText)
                        {
                            stateObj.socMessage = "메시지 수신대기";
                            Logger.debug(stateObj);
                            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));
                        }
                        recv = clientSoc.Receive(buffer);

                        if (IsText)
                        {
                            stateObj.data += Encoding.UTF8.GetString(buffer, 0, recv);
                            stateObj.socMessage = string.Format("일반메시지수신 Msg[{0}].", Encoding.UTF8.GetString(buffer, 0, recv));
                            stateObj.bufferSize += recv;
                            Logger.debug(stateObj);
                            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));
                        }
                        else
                        {
                            if (receivingByteInfo == 0)
                            {
                                receivingByteInfo = Utils.ConvertByteArrayToFileSize(buffer);
                                if (receivingByteInfo != 0)
                                {
                                    recv = recv - SocConst.PREFIX_BYTE_INFO_LENGTH;
                                    Buffer.BlockCopy(buffer, SocConst.PREFIX_BYTE_INFO_LENGTH, stateObj.buffer, stateObj.bufferSize, recv);
                                }
                                else
                                {// error or abnormal stop , cancel
                                    Buffer.BlockCopy(buffer, 0, stateObj.buffer, stateObj.bufferSize, recv);
                                    stateObj.data += Encoding.UTF8.GetString(buffer, 0, recv);
                                }
                                stateObj.socMessage = string.Format("파일수신바이트[{0}].", recv);
                            }
                            else
                            {
                                Buffer.BlockCopy(buffer, 0, stateObj.buffer, stateObj.bufferSize, recv);
                                stateObj.socMessage = string.Format("파일수신바이트[{0}].", recv);
                            }
                            stateObj.bufferSize += recv;
                            //Logger.debug(stateObj.socMessage);
                            //OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                        }

                        if ((receivingByteInfo == 0 && clientSoc.Available == 0 ) 
                            || (receivingByteInfo > 0 && receivingByteInfo == stateObj.bufferSize))
                        {
                            receivingByteInfo = 0;
                            stateObj.socMessage = "메시지수신완료";
                            Logger.debug(stateObj);
                            break;
                        }
                    }

                    stateObj.socMessage = string.Format("메시지수신 완료바이트Size[{0}]", stateObj.bufferSize);
                    Logger.debug(stateObj);
                    OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

                    this.ProcessMsg(stateObj);
                }
            } catch (WeDoFTPCancelException wde) {
                CloseClient(clientSoc);
                StopListening();
                setErrorMessage(wde, stateObj);
            }
            catch (Exception e)
            {
                CloseClient(clientSoc);
                setErrorMessage(e, "수신에러:" + e.ToString());
            }
        }

        public bool IsListenerConnected()
        {
            return mServerSoc.Connected;
        }

        public bool IsListenerBound()
        {
            try {
                return (mServerSoc.LocalEndPoint!=null);
            }
            catch (System.ObjectDisposedException e) {
                return false;
            }
        }

        public virtual void ProcessMsg(object socObj)
        {
            //need implementing
        }

        public void BroadCast(string msg)
        {
            lock (mClientTableLock)
            {

                foreach (DictionaryEntry entry in mHtClientTable)
                {
                    Logger.info("[SyncSoc:BroadCast] {0}, {1}", entry.Key, entry.Value);
                    Send((Socket)entry.Value, msg);
                }
            }
        }

        public int SendMsg(StateObject socObj)
        {
            return Send(socObj.soc, socObj.data);
        }

        public int Send(Socket soc, string msg)
        {
            return Send(soc, Encoding.UTF8.GetBytes(msg));
        }

        public int Send(Socket soc, byte[] buffer)
        {
            int retry = 0;
            int recv = 0;
            StateObject stateObj = new StateObject(soc);
            lock (mClientTableLock)
            {
                stateObj.key = mKey + "_CLI" + mHtClientTable.Count;
            }
            while (true)
            {
                try
                {
                    stateObj.data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    stateObj.status = SocHandlerStatus.SENDING;
                    stateObj.socMessage = string.Format("메시지전송 {0} Msg[{1}]", soc.RemoteEndPoint.ToString(), stateObj.data);

                    recv = soc.Send(buffer, SocketFlags.None);
                    Logger.debug(stateObj);
                    OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));
                    if (recv == buffer.Length) break;
                }
                catch (ArgumentNullException ane)
                {
                    stateObj.socMessage = string.Format("메시지전송에러:{0}", ane.ToString());
                    setErrorMessage(ane, stateObj);
                    return SocCode.SOC_ERR_CODE;
                }
                catch (SocketException se)
                {
                    stateObj.socMessage = string.Format("메시지전송에러:{0}", se.ToString());
                    setErrorMessage(se, stateObj);
                    return SocCode.SOC_ERR_CODE;
                }
                catch (Exception e)
                {
                    stateObj.socMessage = string.Format("메시지전송에러:{0}", e.ToString());
                    setErrorMessage(e, stateObj);
                    return SocCode.SOC_ERR_CODE;
                }

                if (retry >= 3)
                {
                    stateObj.socMessage = String.Format("메시지전송에러:retry >= 3 " + Encoding.UTF8.GetString(buffer, 0, recv));
                    setErrorMessage(new Exception("메시지전송에러:retry >= 3"), stateObj);
                    return SocCode.SOC_ERR_CODE;
                }
                retry++;
            }
            return recv;
        }

        public void CloseClient(object client)
        {
            Socket clientSoc = (Socket)client;
            string socId = "";

            try
            {
                socId = clientSoc.RemoteEndPoint.ToString();
                lock (mClientTableLock)
                {
                    mHtClientTable.Remove(clientSoc.RemoteEndPoint.ToString());
                }
            }
            catch (Exception e) { }

            StateObject stateObj = new StateObject(clientSoc);
            lock (mClientTableLock)
            {
                stateObj.key = mKey + "_Cli" + mHtClientTable.Count;
            }
            stateObj.status = SocHandlerStatus.DISCONNECTED;
            stateObj.socMessage = String.Format("{0} socket is removed from Socket list: ", socId);
            Logger.debug(stateObj);
            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

            try
            {
                clientSoc.Shutdown(SocketShutdown.Both);
                clientSoc.Close();
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("소켓접속해제:{0}", e.ToString()));
            }
        }

        public bool IsSocketReadyToReceive(StateObject obj)
        {
            return (obj.status != SocHandlerStatus.DISCONNECTED && obj.status != SocHandlerStatus.ERROR);
        }

        public void setErrorMessage(Exception e, StateObject obj)
        {
            obj.socErrorMessage = e.Message;
            obj.status = SocHandlerStatus.ERROR;
            Logger.error(obj);
            OnSocStatusChangedOnError(new SocStatusEventArgs(obj));
        }

        public void setErrorMessage(Exception e, string errMsg)
        {
            StateObject stateObj = new StateObject(e);
            stateObj.socMessage = errMsg;
            setErrorMessage(e, stateObj);
        }

    }

}
