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
            status = SocHandlerStatus.UNINIT;
            msgStatus = MSGStatus.NONE;
            ftpStatus = FTPStatus.NONE;
        }

        public StateObject(Socket soc)
        {
            status = SocHandlerStatus.UNINIT;
            this.soc = soc;
            msgStatus = MSGStatus.NONE;
            ftpStatus = FTPStatus.NONE;
        }

        public StateObject(Exception e)
        {
            status = SocHandlerStatus.ERROR;
            this.exception = e;
            msgStatus = MSGStatus.NONE;
            ftpStatus = FTPStatus.NONE;
        }


        public StateObject(Socket soc, string msg)
        {
            status = SocHandlerStatus.UNINIT;
            this.soc = soc;
            this.data = msg;
            msgStatus = MSGStatus.NONE;
            ftpStatus = FTPStatus.NONE;
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
        public SocHandlerStatus status { get; set; }
        public Exception exception = null;

        public MSGStatus msgStatus { get; set; }
        public FTPStatus ftpStatus { get; set; }

        public int ftpPort { get; set; }

        string fileName;
        long fileSize;
        public long rcvFileSize;

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
            string[] list = this.data.Split(SocConst.TOKEN);
            if (list.Length != 3) return;

            fileName = list[1];
            fileSize = Convert.ToInt64(list[2]);
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
