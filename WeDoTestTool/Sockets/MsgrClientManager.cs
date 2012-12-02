using System;
using System.Collections.Generic;
using System.Text;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    class MsgrClientManager : TcpClientManager
    {
        public MsgrClientManager(string ipAddress, int port)
            : base(ipAddress, port)
        {
        }

        public bool SendMsg(string msg)
        {
            return Send(string.Format(MsgDef.MSG_TEXT_FMT, MsgDef.MSG_TEXT, msg));
        }
        /**
         * 1. Cli A Send File Noti , Wait for Ack
         * 2. Svr B Run FTPListener
         * 3. Svr B Send Info | Nack
                     * 6. Cli A Run FTPClient
                     * 7. Cli A Done
                     * 8. Cli A BYE
         */
        public bool SendFile(string fileName, long fileSize)
        {
            string msgRequest = String.Format(MsgDef.MSG_SEND_FILE_FMT, MsgDef.MSG_SEND_FILE, Utils.GetFileName(fileName), fileSize);
            this.Send(msgRequest);

            stateObj.socMessage = string.Format("[MsgrClient:SendFile] Sent file info[{0}].", fileName);
            Logger.debug(stateObj.socMessage);
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            stateObj.data = Receive();
            if (MsgDef.MSG_LISTEN_INFO != stateObj.Cmd)
            {
                stateObj.socMessage = string.Format("[MsgrClient:SendFile] Receive listen info error.[{0}]", stateObj.Cmd);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }

            try
            {
                string[] list = stateObj.data.Split(SocConst.TOKEN);
                if (list.Length != 3)
                {
                    stateObj.socMessage = string.Format("[MsgrClient:SendFile] Receive listen info error: Unknown IpAddress or port.[{0}]", stateObj.data);
                    Logger.error(stateObj.socMessage);
                    OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                    return false;
                }
                mFtpHostName = list[1];
                mFtpPort = Convert.ToInt32(list[2]);
            }
            catch (Exception e)
            {
                stateObj.socMessage = string.Format("[MsgrClient:SendFile] Receive listen info error: Parsing error.[{0}]", stateObj.data);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }

            //FTP_SendFile();
            return true;
        }

        string mFtpHostName;
        int mFtpPort;


        public string getFtpHostName()
        {
            return mFtpHostName;
        }

        public int getFtpPort()
        {
            return mFtpPort;
        }
        /**
                     * 1. Cli A Send File Noti , Wait for Ack
                     * 2. Svr B Run FTPListener
                     * 3. Svr B Send Info | Nack
         * 6. Cli A Run FTPClient
         * 7. Cli A Done
         * 8. Cli A BYE
         */
        public bool FinishFile(string fileName, long fileSize)
        {
            string msgRequest = MsgDef.MSG_COMPLETE;
            this.Send(msgRequest);

            stateObj.socMessage = string.Format("[MsgrClient:FinishFile] Send Msg[{0}].", msgRequest);
            Logger.debug(stateObj.socMessage);
            OnSocStatusChanged(new SocStatusEventArgs(stateObj));

            stateObj.data = Receive();
            if (MsgDef.MSG_BYE != stateObj.Cmd)
            {
                stateObj.socMessage = string.Format("[MsgrClient:FinishFile] Receive Bye error: Unknown msg.[{0}]", stateObj.Cmd);
                Logger.error(stateObj.socMessage);
                OnSocStatusChanged(new SocStatusEventArgs(stateObj));
                return false;
            }
            //FTP_SendFile();
            return true;
        }
    }
}
