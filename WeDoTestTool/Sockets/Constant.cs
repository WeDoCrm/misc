using System;
using System.Collections.Generic;
using System.Text;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    class Constant
    {
    }
    class SocConst
    {
        public const char TOKEN = '|';
        public const int MAX_BUFFER_SIZE = 1024 * 16 * 1024;
        public const int TEMP_BUFFER_SIZE = 1024 * 512;
        public const int MAX_STR_BUFFER_SIZE = 1024 * 4;
        public const string LOCAL_HOST = "127.0.0.1";
        public const int FTP_PORT = 1101;
        public const int WAIT_MIL_SEC = 1000;
        public const string LOG_FILE = "log\\WeDoTestTool_";
        public const string LOG_DIR = "log";
        public const string LOG_FILE_FMT = "yyyyMMdd";
        public const string LOG_DATE_TIME_FMT = "yyyy-MM-dd HH:mm:sss";
        public const int SOC_TIME_OUT_MIL_SEC = 1000;
        public const int PREFIX_BYTE_INFO_LENGTH = 6;
        public const string TEMP_FILE_SUFFIX = ".temporary";
        public const int FTP_WAIT_COUNT = 5;
        public const int FTP_WAIT_TIMEOUT = 2000;
        public const string FTP_DEFAULT_KEY = "FTP_CLI";
    }

    public class MsgDef
    {
        public const string MSG_SEND_FILE = "FILE_SEND";
        public const string MSG_NACK = "NACK";
        public const string MSG_READY = "READY";
        public const string MSG_COMPLETE = "DONE";
        public const string MSG_ACK = "ACK";
        public const string MSG_CANCEL = "CANCEL";
        public const string MSG_BYE = "BYE";
        public const string MSG_EOF = "EOF";
        public const string MSG_END = "END";
        public const string MSG_RCVCHECK = "RCV_LENGTH";
        public const string MSG_LISTEN_INFO = "LISTEN_INFO";
        public const string MSG_TEXT = "MSG";
        public const string MSG_SEND_FILE_FMT = "{0}|{1}|{2}";
        public const string MSG_READY_FMT = "{0}|{1}";
        public const string MSG_RCVCHECK_FMT = "{0}|{1}";
        public const string MSG_LISTEN_INFO_FMT = "{0}|{1}|{2}";
        public const string MSG_TEXT_FMT = "{0}|{1}";
        public const string MSG_BINARY_FMT = "{0}|{1}";
    }

    public class SocCode
    {
        public const int SOC_SUC_CODE = 1;
        public const int SOC_ERR_CODE = -1;
    }

    public enum LOGLEVEL
    {
        ERROR = 0,
        INFO = 1,
        DEBUG = 2
    }

    public enum SocHandlerStatus
    {
        ERROR = -1,
        UNINIT = 0,
        CONNECTED = 1,
        ACTIVE = 2,
        RECEIVING = 3,
        SENDING = 4,
        FTP_START = 5,
        FTP_SENDING = 6,
        FTP_END = 7,
        FTP_CANCELED = 8,
        DISCONNECTED = 9,
        LISTENING = 10,
        STOP = 11
    }

    public enum FTPStatus
    {
        /**
         * 1. Receive READY:File Name:File Size
         * 2. Check File Path
         * 3. Send Ack
         *        - Fail Send Nack
         * 4. Receive Stream
         *      - Save to File
         *      - Check EndOfFile by File Size
         * 5. Send Done
         * 6. Receive BYE
         * 9. Send Bye
         */
        ERROR = -1,
        NONE = 0,
        RECEIVED_FILE_INFO = 1,
        SENT_READY_ACK = 2,
        SENT_READY_NACK = 3,
        RECEIVE_STREAM = 4,
        SENT_DONE = 5,
        RECEIVED_ACK = 6,
        SENT_ACK = 7,
        RECEIVED_BYE = 8,
        SENT_BYE = 9
    }

    public enum MSGStatus
    {
        /**
         * 1. Cli A Send File Noti, Wait for Ack
         * 2. Svr B Send File Noti, Wait for Ack to Cli C
         * 3. Cli C Run FTPListener
         * 4. Cli C Svr Info | Nack
         * 5. Svr B /Nack Run FTPListener
         * 6. Svr B Send Info | Nack
         * 7. Cli A Run FTPClient
         * 8. Cli A Done
         * 9. Svr B BYE
         * 
         * 10. Normal Message
         */

        ERROR = -1,
        NONE = 0,
        SENT_FILE_INFO = 1,
        SENT_READY_ACK = 2,
        SENT_READY_NACK = 3,
        SENT_SVR_INFO = 4,
        RUN_FTP = 5,
        FTP_DONE = 6,
        SENT_BYE = 7
    }
}
