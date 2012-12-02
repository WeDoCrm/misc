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
    public class SynchronousSocketClient
    {

        // Data buffer for incoming data.
        Socket mSender = null;
        IPEndPoint remoteEP = null;
        int mPort = 1100;

        string mRemoteInfo;

        StateObject stateObj;
        public event EventHandler<SocStatusEventArgs> SocStatusChanged;

        protected bool IsText = true;

        public SynchronousSocketClient(string _ipAddress, int port) : this(_ipAddress, port, SocConst.SOC_TIME_OUT_MIL_SEC)
        {
        }

        public SynchronousSocketClient(string _ipAddress, int port, int timeout)
        {

            // Connect to a remote device.
            try
            {
                // Establish the remote endpoint for the socket.
                // This example uses port 11000 on the local computer.
                //IPHostEntry ipHostInfo = Dns.Resolve(_ipAddress);
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(_ipAddress);
                //IPAddress ipAddress = ipHostInfo.AddressList[2];  //[2]는 ip4 나머지 [0],[1],[3]은 ip6
                IPAddress ipAddress = System.Net.IPAddress.Parse(_ipAddress);
                mPort = port;
                remoteEP = new IPEndPoint(ipAddress, mPort);

                // Create a TCP/IP  socket.
                mSender = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream, ProtocolType.Tcp);
                // Send operations will time-out if confirmation  
                // is not received within 1000 milliseconds.
                mSender.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.SendTimeout, timeout);

                // The socket will linger for 10 seconds after Socket.Close is called.
                LingerOption lingerOption = new LingerOption(true, 10);

                mSender.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Linger, lingerOption);

                stateObj = new StateObject(mSender);
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("[SocClient:SocClient] ip[{0} port[{1}] timeout[{2}]]",_ipAddress,port,timeout));
                Logger.error(e.ToString());
            }

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
                    stateObj.socMessage = string.Format("[SocClient:Connect] Socket connected to {0}",
                        mRemoteInfo);
                    Logger.info(stateObj.socMessage);
                    stateObj.status = SocHandlerStatus.CONNECTED;
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                }
                else
                {
                    stateObj.status = SocHandlerStatus.ERROR;
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                    throw new SocketException();
                }
            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane, string.Format("[SocClient:Connect] ArgumentNullException : {0}", ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se, string.Format("[SocClient:Connect] SocketException[{0}] :{1}",
                    se.ErrorCode, mRemoteInfo));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e,string.Format("[SocClient:Connect] Unexpected exception : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            return SocCode.SOC_SUC_CODE;
        }

        public int Close()
        {
            try
            {
                // Release the socket.
                mSender.Shutdown(SocketShutdown.Both);
            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane,string.Format("[SocClient:Close] ArgumentNullException : {0}", ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se,string.Format("[SocClient:Close] SocketException[{0}] :{1}",
                    se.ErrorCode,mRemoteInfo));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e,string.Format("[SocClient:Close] Unexpected exception : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            finally
            {
                mSender.Close();
                stateObj.status = SocHandlerStatus.DISCONNECTED;
                Logger.info("[SocClient:Close] Socket Closed");
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
            }
            return SocCode.SOC_SUC_CODE;
        }

        public int Send(string msg)
        {                // Encode the data string into a byte array.
            byte[] byteMsg = Encoding.UTF8.GetBytes(msg);
            return Send(byteMsg);
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
                    stateObj.socMessage = string.Format("[SocClient:Send] Send to {0} data[{1}]",
                        mSender.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(msg));
                else
                    stateObj.socMessage = string.Format("[SocClient:Send] Send to {0} datalength[{1}]",
                        mSender.RemoteEndPoint.ToString(), bytesSent);
                Logger.debug(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane,string.Format("[SocClient:Send] Error Sending to {0} ArgumentNullException : {1}", 
                    mRemoteInfo, ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se, string.Format("[SocClient:Send] Error Sending to {0} SocketException[{1}] : {2}", 
                    mRemoteInfo, se.ErrorCode, se.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("[SocClient:Send] Unexpected exception in Sending : {0}", e.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            return bytesSent;
        }

        public int Receive(byte[] byteStr)
        {
            // Connect the socket to the remote endpoint. Catch any errors.
            int bytesRec = 0;
            try
            {
                // Receive the response from the remote device.
                stateObj.status = SocHandlerStatus.RECEIVING;
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));

                Logger.debug("[SocClient:Receive] Wait for receiving");
                bytesRec = mSender.Receive(byteStr);
                Logger.debug("[SocClient:Receive] Received message[{0}]",
                    Encoding.ASCII.GetString(byteStr, 0, bytesRec));
            }
            catch (ArgumentNullException ane)
            {
                setErrorMessage(ane, string.Format("[SocClient:Receive] ArgumentNullException : {0}", ane.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (SocketException se)
            {
                setErrorMessage(se, string.Format("[SocClient:Receive] Error Receiving from {0} SocketException[{1}] : {2}", 
                    mRemoteInfo, se.ErrorCode, se.ToString()));
                return SocCode.SOC_ERR_CODE;
            }
            catch (Exception e)
            {
                setErrorMessage(e, string.Format("[SocClient:Receive] Unexpected exception : {0}", e.ToString()));
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
            stateObj.socErrorMessage = e.ToString();
            stateObj.socMessage = errMsg;
            stateObj.status = SocHandlerStatus.ERROR;
            Logger.error(errMsg);
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));
        }

    }
}
