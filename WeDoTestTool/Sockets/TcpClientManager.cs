using System;
using System.Collections.Generic;
using System.Text;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class TcpClientManager
    {

        protected SyncSocClient mSocClient;
        //SocStreamClient         mstreamClient;
        protected StateObject stateObj;

        protected byte[] bufferTxt = new byte[SocConst.MAX_STR_BUFFER_SIZE];
        protected byte[] bufferBin = new byte[SocConst.MAX_BUFFER_SIZE];

        protected bool IsText = true;


        public event EventHandler<SocStatusEventArgs> SocStatusChanged;

        public TcpClientManager(string ipAddress, int port) : this(ipAddress, port, "")
        {
        }

        public TcpClientManager(string ipAddress, int port, string key, int timeout)
        {
            mSocClient = new SyncSocClient(ipAddress, port, timeout);
            mSocClient.SocStatusChanged += TcpClientStatusChanged;
            mSocClient.SetKey(key);
            stateObj = new StateObject(mSocClient.getSocket());
            stateObj.key = key;
        }


        public TcpClientManager(string ipAddress, int port, string key) : this(ipAddress, port, key, SocConst.SOC_TIME_OUT_MIL_SEC)
        {
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
                Logger.error("[TcpClient:Close] 종료메시지 전송에러");
            }

            mSocClient.Close();
            stateObj.status = SocHandlerStatus.DISCONNECTED;
            OnSocStatusChangedOnInfo(new SocStatusEventArgs(stateObj));
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

        protected virtual void TcpClientStatusChanged(object sender, SocStatusEventArgs e)
        {
            OnSocStatusChanged(e);
        }

    }
}
