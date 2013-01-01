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

        public MsgrClientManager(string ipAddress, int port, string key)
            : base(ipAddress, port, key)
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

            stateObj.socMessage = string.Format("파일정보 전송[{0}].", fileName);
            Logger.debug(stateObj);
            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

            //파일리스너정보 수신 
            stateObj.data = Receive();
            if (MsgDef.MSG_LISTEN_INFO != stateObj.Cmd)
            {
                stateObj.socMessage = string.Format("파일수신리스너 정보 error.[{0}]", stateObj.Cmd);
                Logger.error(stateObj);
                OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
                return false;
            }

            try
            {
                string[] list = stateObj.data.Split(SocConst.TOKEN);
                if (list.Length != 3)
                {
                    stateObj.socMessage = string.Format("파일수신리스너 정보 error: Unknown IpAddress or port.[{0}]", stateObj.data);
                    Logger.error(stateObj);
                    OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
                    return false;
                }
                mFtpHostName = list[1];
                mFtpPort = Convert.ToInt32(list[2]);
            }
            catch (Exception e)
            {
                stateObj.socMessage = string.Format("파일수신리스너 정보 error: Parsing error.[{0}]", stateObj.data);
                Logger.error(stateObj);
                OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
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
         * 파일전송작업 종료
                     * 1. Cli A Send File Noti , Wait for Ack
                     * 2. Svr B Run FTPListener
                     * 3. Svr B Send Info | Nack
         * 6. Cli A Run FTPClient
         * 7. Cli A Done
         * 8. Cli A BYE
         */
        public bool FinishFile(string fileName, long fileSize)
        {
            //완료메시지 전송
            string msgRequest = MsgDef.MSG_COMPLETE;
            this.Send(msgRequest);

            stateObj.socMessage = string.Format("파일전송 완료메시지 전송[{0}].", msgRequest);
            Logger.debug(stateObj);
            OnSocStatusChangedOnDebug(new SocStatusEventArgs(stateObj));

            //종료메시지 수신
            stateObj.data = Receive();
            if (MsgDef.MSG_BYE != stateObj.Cmd)
            {
                stateObj.socMessage = string.Format("종료메시지수신 error: Unknown msg.[{0}]", stateObj.Cmd);
                Logger.error(stateObj);
                OnSocStatusChangedOnError(new SocStatusEventArgs(stateObj));
                return false;
            }
            //FTP_SendFile();
            return true;
        }
    }
}
