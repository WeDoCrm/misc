using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Diagnostics;
using System.Threading;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class TcpServerMgr
    {
        protected SyncSocListener server;
        protected Thread thServer;
        protected int mPort = 0;
        string mTcpKey = "tcp_svr";


        public event EventHandler<SocStatusEventArgs> SocStatusChanged;

        public TcpServerMgr(int port)
        {
            mPort = port;
            server = new TcpSocketListener(mPort);
            server.SetKey(mTcpKey);
        }

        public virtual void OnSocStatusChanged(SocStatusEventArgs e)
        {
            EventHandler<SocStatusEventArgs> handler = SocStatusChanged;

            if (handler != null)
            {
                //Logger.WriteLine("ServerManager.OnSocStatusChanged");

                handler(this, e);

            }
        }

        protected virtual void ServerMgrStatusChanged(object sender, SocStatusEventArgs e)
        {
            OnSocStatusChanged(e);
        }

        public virtual void DoRun()
        {
            server.SocStatusChanged += ServerMgrStatusChanged;
            thServer = new Thread(new ThreadStart(Start));
            thServer.Start();
            //this.BufferChanged(this, new EventArgs());
        }

        public void SetSaveFilePath(string path)
        {
            ((TcpSocketListener)server).SetSaveFilePath(path);
        }

        public void Start()
        {
            Logger.info("TCP server starting");
            server.StartListening();
        }

        public bool isListening()
        {
            return (server != null && server.IsListenerBound());
        }
        public void Stop()
        {
            Logger.info("TCP server stopping");
            server.StopListening();
        }

        public bool IsListenerReady()
        {
            return server.IsListenerBound();
        }
        public void listClient()
        {
            Logger.info("TCP connection listup.");
            server.listClient();
        }

        public void BroadCast(string msg)
        {
            server.BroadCast(msg);
        }

        public void CancelReceiving()
        {
            int port = (server as TcpSocketListener).FTP_getActivePort();
            (server as TcpSocketListener).FTP_cancel(port);
        }

    }

    public class FtpServerMgr : TcpServerMgr
    {
        //FtpSocketListener server;

        public FtpServerMgr(int port)
            : base(port)
        {
            mPort = port;
            server = new FtpSocketListener(mPort);

        }

        protected override void ServerMgrStatusChanged(object sender, SocStatusEventArgs e)
        {
            if (e.Status.Cmd == MsgDef.MSG_BYE)
            {
                Stop();
            }
            base.OnSocStatusChanged(e);
        }

        public override void DoRun()
        {
            server.SocStatusChanged += ServerMgrStatusChanged;
            thServer = new Thread(new ThreadStart(Start));
            thServer.Start();
            //this.BufferChanged(this, new EventArgs());
        }

    }
}
