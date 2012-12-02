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
    public class SynchronousSocketListener
    {
        protected Socket mServerSoc;

        public event EventHandler<SocStatusEventArgs> SocStatusChanged;
        protected int mPort = 0;
        public Hashtable mHtClientTable;
        protected Object mClientTableLock = new Object();
        protected Object mServerLock = new Object();
        protected StateObject mServerStateObj;

        protected byte[] bufferTxt = new byte[SocConst.MAX_STR_BUFFER_SIZE];
        protected byte[] bufferBin = new byte[SocConst.MAX_BUFFER_SIZE];

        protected bool IsText = true;
        protected int mClientSize = 20;

        public SynchronousSocketListener(int port)
        {
            mPort = port;
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

            // Bind the socket to the local endpoint and 
            // listen for incoming connections.
            try
            {
                mServerSoc.Bind(localEndPoint);
                mServerSoc.Listen(10);
                mServerStateObj = new StateObject(mServerSoc, "");
                mServerStateObj.status = SocHandlerStatus.LISTENING;

                if (mPort == 0)
                    mPort = ((IPEndPoint)mServerSoc.LocalEndPoint).Port;

                Logger.info("[SyncSoc:StartListening] Start Listening.");

                mHtClientTable = new Hashtable();

                // Start listening for connections.
                while (true)
                {
                    lock (mClientTableLock)
                    {
                        if (mHtClientTable.Count >= mClientSize)
                        {
                            Logger.info(string.Format("[SyncSoc:StartListening] Wait...over max count {0} >= {1}", mHtClientTable.Count, mClientSize));
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
                    mServerStateObj.socMessage = string.Format("[SyncSoc:StartListening] Port[{0}] Waiting for a connection...", mPort);
                    Logger.info(mServerStateObj.socMessage);
                    OnSocStatusChanged(new SocStatusEventArgs(mServerStateObj));
                    Socket soc = mServerSoc.Accept();
                    //soc.SetSocketOption(SocketOptionLevel.Socket,
                    //            SocketOptionName.ReceiveTimeout, 2000);

                    StateObject stateObj = new StateObject(soc, "");
                    stateObj.status = SocHandlerStatus.CONNECTED;
                    stateObj.socMessage = string.Format("[SyncSoc:StartListening] Accepted:{0}", soc.RemoteEndPoint.ToString());
                    Logger.info(stateObj.socMessage);
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                    lock (mClientTableLock)
                    {
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
                    setErrorMessage(e, "[SyncSoc:StartListening] Server Listening Error:" + e.ToString());
                }
            }
            catch (Exception e)
            {
                setErrorMessage(e, "[SyncSoc:StartListening] Server Listening Error:" + e.ToString());
            }


        }

        public void StopListening()
        {
            lock (mServerLock)
            {
                mServerStateObj.status = SocHandlerStatus.STOP;
                mServerStateObj.socMessage = "[SyncSoc:StopListening] Server Socket Stopped.";
                Logger.info(mServerStateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(mServerStateObj));
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
                    stateObj.socMessage = string.Format("[SyncSoc:listClient] {0}, {1}", entry.Key, entry.Value);
                    Logger.info(stateObj.socMessage);
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
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

        public void ReceiveMsg(object client)
        {
            Socket clientSoc = (Socket)client;
            StateObject stateObj = new StateObject(clientSoc);

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
                    if (IsText)
                    {
                        Array.Clear(this.bufferTxt, 0, this.bufferTxt.Length);
                        buffer = bufferTxt;
                    }
                    else
                    {
                        Array.Clear(this.bufferBin, 0, this.bufferBin.Length);
                        buffer = bufferBin;
                    }
                    stateObj.buffer = buffer;

                    if (!IsSocketReadyToReceive(stateObj))
                    {
                        Logger.info("[SyncSoc:ReceiveMsg] Soc Disconnected or Error.");
                        return;
                    }
                    //단일 메시지 수신
                    while (true)
                    {
                        stateObj.status = SocHandlerStatus.RECEIVING;
                        stateObj.socMessage = "[SyncSoc:ReceiveMsg] Client Soc Wait to Receive.";
                        Logger.debug(stateObj.socMessage);
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                        recv = clientSoc.Receive(buffer);

                        if (IsText)
                        {
                            stateObj.data += Encoding.UTF8.GetString(buffer, 0, recv);
                            stateObj.socMessage = string.Format("[SyncSoc:ReceiveMsg] Receive Msg[{0}].", Encoding.UTF8.GetString(buffer, 0, recv));
                        }
                        else
                        {
                            Buffer.BlockCopy(buffer, 0, stateObj.buffer, stateObj.bufferSize, recv);
                            stateObj.socMessage = string.Format("[SyncSoc:ReceiveMsg] Receive Msg[{0}].", recv);
                        }
                        stateObj.bufferSize += recv;
                        Logger.debug(stateObj.socMessage);
                        OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                        if (clientSoc.Available == 0)
                        {
                            Logger.debug("[SyncSoc:ReceiveMsg] 수신 메시지 Avaliable {0} break", clientSoc.Available);
                            break;
                        }
                    }

                    stateObj.socMessage = string.Format("[SyncSoc:ReceiveMsg] Received Size[{0}]", stateObj.bufferSize);
                    Logger.debug(stateObj.socMessage);
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                    this.ProcessMsg(stateObj);
                }
            }
            catch (Exception e)
            {
                CloseClient(clientSoc);
                setErrorMessage(e, "[SyncSoc:ReceiveMsg] " + e.ToString());
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

            while (true)
            {
                try
                {
                    stateObj.data = Encoding.UTF8.GetString(buffer, 0, buffer.Length);
                    stateObj.status = SocHandlerStatus.SENDING;
                    stateObj.socMessage = string.Format("[SyncSoc:Send] Send {0} Msg[{1}]", soc.RemoteEndPoint.ToString(), stateObj.data);

                    recv = soc.Send(buffer, SocketFlags.None);
                    Logger.debug(stateObj.socMessage);
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                    if (recv == buffer.Length) break;
                }
                catch (ArgumentNullException ane)
                {
                    stateObj.socMessage = string.Format("[SyncSoc:Send] ArgumentNullException : {0}", ane.ToString());
                    setErrorMessage(ane, stateObj);
                    return SocCode.SOC_ERR_CODE;
                }
                catch (SocketException se)
                {
                    stateObj.socMessage = string.Format("[SyncSoc:Send] SocketException : {0}", se.ToString());
                    setErrorMessage(se, stateObj);
                    return SocCode.SOC_ERR_CODE;
                }
                catch (Exception e)
                {
                    stateObj.socMessage = string.Format("[SyncSoc:Send] Unexpected exception : {0}", e.ToString());
                    setErrorMessage(e, stateObj);
                    return SocCode.SOC_ERR_CODE;
                }

                if (retry >= 3)
                {
                    stateObj.socErrorMessage = String.Format("[SyncSoc:Send] SendMsg Error :retry >= 3 " + Encoding.UTF8.GetString(buffer, 0, recv));
                    setErrorMessage(new Exception("[SyncSoc:Send] SendMsg Error :retry >= 3"), stateObj);
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
            stateObj.status = SocHandlerStatus.DISCONNECTED;
            stateObj.socMessage = String.Format("[SyncSoc:CloseClient] {0} socket is removed from Socket list: ", socId);
            Logger.info(stateObj.socMessage);
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            try
            {
                clientSoc.Shutdown(SocketShutdown.Both);
                clientSoc.Close();
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("[SyncSoc:CloseClient] Unexpected exception : {0}", e.ToString()));
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
            Logger.error(obj.socMessage);
            OnSocStatusChanged(new SocStatusEventArgs(obj));
        }

        public void setErrorMessage(Exception e, string errMsg)
        {
            StateObject stateObj = new StateObject(e);
            stateObj.socMessage = errMsg;
            setErrorMessage(e, stateObj);
        }

    }

}
