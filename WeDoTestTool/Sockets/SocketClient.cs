using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class SyncSocClient
    {

        // Data buffer for incoming data.
        Socket mSender = null;
        IPEndPoint remoteEP = null;
        int mPort = 1100;

        string mRemoteInfo;

        StateObject stateObj;

        string mKey;
        public event EventHandler<SocStatusEventArgs> SocStatusChanged;

        protected bool IsText = true;

        public SyncSocClient(string _ipAddress, int port) : this(_ipAddress, port, SocConst.SOC_TIME_OUT_MIL_SEC)
        {
        }

        public SyncSocClient(string _ipAddress, int port, int timeout)
        {

            try
            {
                IPAddress ipAddress = System.Net.IPAddress.Parse(_ipAddress);
                mPort = port;
                remoteEP = new IPEndPoint(ipAddress, mPort);

                mSender = new Socket(AddressFamily.InterNetwork,
                                        SocketType.Stream, ProtocolType.Tcp);

                if (timeout > 0)
                {
                    mSender.ReceiveTimeout = timeout;
                    mSender.SendTimeout = timeout;
                }
                //mSender.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, timeout);

                // The socket will linger for 10 seconds after Socket.Close is called.
                LingerOption lingerOption = new LingerOption(true, 10);

                mSender.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption);

                stateObj = new StateObject(mSender);
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("소켓생성Error ip[{0}]/port[{1}]/timeout[{2}]]",_ipAddress,port,timeout));
                Logger.error(e.ToString());
            }
        }

        public void SetKey(string key)
        {
            mKey = key;
            this.stateObj.key = key;
        }

        public void SetText()
        {
            this.IsText = true;
        }

        public void SetBinary()
        {
            this.IsText = false;
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


        public Socket getSocket()
        {
            return this.mSender;
        }

        public bool IsConnected()
        {
            return ((mSender != null) && mSender.Connected);
        }

        public int Connect()
        {
            // Connect the socket to the remote endpoint. Catch any errors.
            try
            {
                mSender.Connect(remoteEP);

                if (mSender.Connected && mSender.RemoteEndPoint != null)
                {
                    mRemoteInfo = mSender.RemoteEndPoint.ToString();
                    stateObj.socMessage = string.Format("Socket Connected to [{0}]",
                        mRemoteInfo);
                    stateObj.status = SocHandlerStatus.CONNECTED;
                    Logger.info(stateObj);
                    OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                }
                else
                {
                    stateObj.status = SocHandlerStatus.ERROR;
                    OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
                    throw new SocketException((int)SocketError.NotConnected);
                }
            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane, string.Format("ArgumentNullException : {0}", ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se, string.Format("SocketException[{0}] :{1}",
                    se.ErrorCode, mRemoteInfo));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e,string.Format("Unexpected exception : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            return SocCode.SOC_SUC_CODE;
        }

        public int Close()
        {
            try
            {
                mSender.Shutdown(SocketShutdown.Both);
            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane,string.Format("ArgumentNullException : {0}", ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se,string.Format("SocketException[{0}] :{1}",
                    se.ErrorCode,mRemoteInfo));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e,string.Format("Unexpected exception : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            finally
            {
                mSender.Close();
                stateObj.status = SocHandlerStatus.DISCONNECTED;
                stateObj.socMessage = "Socket Closed";
                Logger.info(stateObj);
                OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
            }
            return SocCode.SOC_SUC_CODE;
        }

        public int Send(string msg)
        {                
            // Encode the data string into a byte array.
            return Send(Encoding.UTF8.GetBytes(msg));
        }

        public int Send(byte[] msg)
        {
            return Send(msg, msg.Length);
        }

        public int Send(byte[] msg, int bytesSize)
        {
            int bytesSent;
            try
            {
                stateObj.status = SocHandlerStatus.SENDING;
                // Send the data through the socket.
                bytesSent = mSender.Send(msg, bytesSize, SocketFlags.None);
                if (IsText)
                    stateObj.socMessage = string.Format("Send to [{0}] text data[{1}]",
                        mSender.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(msg));
                else
                    stateObj.socMessage = string.Format("Send to [{0}] bin data[{1}]",
                        mSender.RemoteEndPoint.ToString(), bytesSent);
                Logger.debug(stateObj);
                OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane,string.Format("Error Sending to {0} ArgumentNullException : {1}", 
                    mRemoteInfo, ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se, string.Format("Error Sending to {0} SocketException[{1}] : {2}", 
                    mRemoteInfo, se.ErrorCode, se.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("Unexpected Error in Sending : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            return bytesSent;
        }
        public int Receive(byte[] byteStr)
        {
            return Receive(byteStr, 0);
        }

        public int Receive(byte[] byteStr, int timeoutMilSec)
        {
            // Connect the socket to the remote endpoint. Catch any errors.
            int bytesRec = 0;
            try
            {
                // Receive the response from the remote device.
                stateObj.status = SocHandlerStatus.RECEIVING;
                stateObj.socMessage = "Wait for receiving";
                Logger.debug(stateObj);
                OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

                if (timeoutMilSec > 0)
                {
                    // Poll the socket for reception with a 10 ms timeout.
                    if (mSender.Poll(timeoutMilSec, SelectMode.SelectRead))
                    {
                        bytesRec = mSender.Receive(byteStr);
                    }
                    else
                    {
                        // Timed out
                        new SocketException((int)SocketError.TimedOut);
                    }
                }
                else
                {
                    bytesRec = mSender.Receive(byteStr);
                }
                stateObj.socMessage = string.Format("수신메시지[{0}]",
                    Encoding.ASCII.GetString(byteStr, 0, bytesRec));
                Logger.debug(stateObj);
            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane, string.Format("ArgumentNullException : {0}", ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se, string.Format("Error Receiving from [{0}] SocketException[{1}] : {2}", 
                    mRemoteInfo, se.ErrorCode, se.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("Unexpected exception : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            return bytesRec;
        }

        public string ReadLine()
        {
            string line = null;
            while (true)
            {
                byte[] bytes = new byte[SocConst.MAX_STR_BUFFER_SIZE];
                int bytesRec = Receive(bytes);
                if (bytesRec <= 0) break;
                line += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                if (line.IndexOf("") > -1) break;
            }
            return line;
        }

        public void setErrorMessage(Exception e, string errMsg)
        {
            stateObj = new StateObject(e);
            stateObj.key = mKey;
            stateObj.socErrorMessage = e.ToString();
            stateObj.socMessage = errMsg;
            stateObj.status = SocHandlerStatus.ERROR;
            Logger.error(stateObj);
            OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
        }
    }
}
