using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.IO;
using System.Diagnostics;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    class Logger
    {
        public static LOGLEVEL level = LOGLEVEL.DEBUG;
        public static string logDir = SocConst.LOG_DIR;
        public static string logFile = SocConst.LOG_FILE;

        public static void setLogLevel(LOGLEVEL level)
        {
            Logger.level = level;
        }

        public static void setLogDir(string dir)
        {
            logDir = dir;
        }

        public static void setLogFile(string file)
        {
            logFile = file;
        }

        public static void debug(StateObject arg)
        {
            if (level >= LOGLEVEL.DEBUG)
                WriteLine("[DEBUG]", arg);
        }
        public static void info(StateObject arg)
        {
            if (level >= LOGLEVEL.INFO)
                WriteLine("[INFO ]", arg);
        }
        public static void error(StateObject arg)
        {
            if (level >= LOGLEVEL.ERROR)
                WriteLine("[ERROR]", arg);
        }
        private static void WriteLine(string mode, StateObject arg)
        {
            LogWrite(mode, string.Format("[{0}]{1}", arg.key, arg.socMessage));
        }


        public static void debug(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.DEBUG)
                WriteLine("[DEBUG]", format, arg);
        }
        public static void info(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.INFO)
                WriteLine("[INFO ]", format, arg);
        }
        public static void error(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.ERROR)
                WriteLine("[ERROR]",format, arg);
        }
        private static void WriteLine(string mode, string format, params object[] arg)
        {
            LogWrite(mode, string.Format(format, arg));
        }

        static StreamWriter sw;// = new StreamWriter(SocConst.LOG_FILE + DateTime.Now.ToString("yyyyMMdd") + ".txt", true, Encoding.Default);
        static Object logFileLock = new Object();

        private static void LogWrite(string mode, string log)
        {
            lock (logFileLock)
            {
                try
                {
                    if (!Directory.Exists(logDir))
                        Directory.CreateDirectory(logDir);

                    sw = new StreamWriter(logDir+"\\"+logFile + DateTime.Now.ToString(SocConst.LOG_FILE_FMT) + ".txt", true);

                    StackFrame frame = new StackFrame(3, true);
                    string methodName = frame.GetMethod().DeclaringType.Name + "." + frame.GetMethod().Name;
                    string fileName = frame.GetFileName().Substring(frame.GetFileName().LastIndexOf('\\') + 1);
                    int lineNo = frame.GetFileLineNumber();

                    string line;
                    
                    if (level >= LOGLEVEL.DEBUG)
                        line = string.Format("[{0}][{1}][{2}:{3}][{4}]{5}", DateTime.Now.ToString(SocConst.LOG_DATE_TIME_FMT),mode,fileName, lineNo, methodName, log);
                    else
                        line = string.Format("[{0}][{1}][{2}:{3}]{4}", DateTime.Now.ToString(SocConst.LOG_DATE_TIME_FMT), mode, methodName, lineNo, log);

                    sw.WriteLine(line);
                    Console.WriteLine(line);
                    sw.Flush();
                } catch (Exception) {
                    if (sw != null) sw.Close();
                    sw = new StreamWriter(logDir + "\\" + logFile + DateTime.Now.ToString(SocConst.LOG_FILE_FMT) + ".txt", true);
                    string line = string.Format("[{0}][{1}]{2}", DateTime.Now.ToString(SocConst.LOG_DATE_TIME_FMT), mode, log);
                    sw.WriteLine(line);
                    Console.WriteLine(line);
                    sw.Flush();
                } finally { if (sw != null) { sw.Close(); } }
            }
        }

    }
}
