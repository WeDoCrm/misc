using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class StateObject
    {

        public StateObject()
        {
        }

        public StateObject(Socket soc)
        {
            this.soc = soc;
        }

        public StateObject(Exception e)
        {
            status = SocHandlerStatus.ERROR;
            this.exception = e;
        }

        public StateObject(Socket soc, string msg)
        {
            this.soc = soc;
            this.data = msg;
        }


        // Client socket.
        public Socket soc = null;
        // Size of receive buffer.
        public int bufferSize = 0;
        // Receive buffer.
        public byte[] buffer;// = new byte[SocConst.MAX_BUFFER_SIZE];
        // Received data string.
        //public StringBuilder data = new StringBuilder();
        public string data;

        public string key;

        string cmd;
        int mode;
        public string Cmd
        {
            get
            {
                return Utils.getCmd(data);
            }
            set { cmd = value; }
        }

        public int Mode
        {
            get
            {
                return Utils.getMode(data);
            }
            set { mode = value; }
        }
        public string socMessage { get; set; }
        public string socErrorMessage { get; set; }
        public SocHandlerStatus status = SocHandlerStatus.UNINIT;
        public Exception exception = null;

        public MSGStatus msgStatus = MSGStatus.NONE;
        public FTPStatus ftpStatus = FTPStatus.NONE;

        public int ftpPort { get; set; }

        string fileName;
        long fileSize;
        public long fileSizeDone;

        public string FileName
        {
            get
            {
                setFileInfo();
                return fileName;
            }
            set { fileName = value; }
        }

        public long FileSize
        {
            get
            {
                setFileInfo();
                return fileSize;
            }
            set { fileSize = value; }
        }


        private void setFileInfo()
        {
            if (data == null) return;
            string[] list = this.data.Split(SocConst.TOKEN);
            if (list.Length != 3) return;

            fileName = list[1];
            fileSize = Convert.ToInt64(list[2]);
        }

    }

    public class WeDoFTPCancelException : Exception
    {
        public WeDoFTPCancelException()
            : base()
        {
        }
        public WeDoFTPCancelException(string message)
            : base(message)
        {
        }

    }

    //이벤트 전달할 소켓상태 정보
    public class SocStatusEventArgs : EventArgs
    {
        private StateObject status;

        public SocStatusEventArgs(StateObject s)
        {
            status = s;
        }

        public StateObject Status
        {
            get { return status; }
        }
    }
}
