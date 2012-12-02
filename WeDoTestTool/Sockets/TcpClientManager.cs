using System;
using System.Collections.Generic;
using System.Text;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class TcpClientManager
    {

        protected SynchronousSocketClient mSocClient;
        //SocStreamClient         mstreamClient;
        protected StateObject stateObj;

        protected byte[] bufferTxt = new byte[SocConst.MAX_STR_BUFFER_SIZE];
        protected byte[] bufferBin = new byte[SocConst.MAX_BUFFER_SIZE];

        protected bool IsText = true;


        public event EventHandler<SocStatusEventArgs> SocStatusChanged;

        public TcpClientManager(string ipAddress, int port)
        {
            mSocClient = new SynchronousSocketClient(ipAddress, port);
            mSocClient.SocStatusChanged += TcpClientStatusChanged;

            stateObj = new StateObject(mSocClient.getSocket());
        }


        public void SetText()
        {
            this.IsText = true;
        }

        public void SetBinary()
        {
            this.IsText = false;
        }


        public bool IsConnected()
        {
            return mSocClient.IsConnected();
        }

        public bool Connect()
        {
            bool result = (SocCode.SOC_ERR_CODE != mSocClient.Connect());
            if (result) stateObj.status = SocHandlerStatus.CONNECTED;
            //OnSocStatusChanged(new SocStatusEventArgs(stateObj));
            return result;
        }

        public bool Send(string msg)
        {
            return (SocCode.SOC_ERR_CODE != mSocClient.Send(msg));
        }

        public string Receive()
        {
            return mSocClient.ReadLine();
        }

        public void Close()
        {
            mSocClient.Send(MsgDef.MSG_BYE);

            if (mSocClient.ReadLine() != MsgDef.MSG_BYE)
            {
                Logger.error("[TcpClient:Close] Send Bye Error");
            }

            mSocClient.Close();
            stateObj.status = SocHandlerStatus.DISCONNECTED;
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));
        }

        public virtual void OnSocStatusChanged(SocStatusEventArgs e)
        {
            EventHandler<SocStatusEventArgs> handler = SocStatusChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void TcpClientStatusChanged(object sender, SocStatusEventArgs e)
        {
            OnSocStatusChanged(e);
        }

    }
}
