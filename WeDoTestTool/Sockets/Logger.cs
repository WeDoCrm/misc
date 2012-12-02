using System;
using System.Collections.Generic;
using System.Text;
using System.Resources;
using System.IO;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    class Logger
    {
        public static LOGLEVEL level = LOGLEVEL.DEBUG;
        public static void debug(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.DEBUG)
                WriteLine("[DEBUG]" + format, arg);
        }
        public static void info(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.INFO)
                WriteLine("[INFO ]" + format, arg);
        }
        public static void error(string format, params object[] arg)
        {
            if (level >= LOGLEVEL.ERROR)
                WriteLine("[ERROR]" + format, arg);
        }
        private static void WriteLine(string format, params object[] arg)
        {
            //Console.WriteLine(format, arg);
            LogWrite(string.Format(format,arg));
        }


        static StreamWriter sw;// = new StreamWriter(SocConst.LOG_FILE + DateTime.Now.ToString("yyyyMMdd") + ".txt", true, Encoding.Default);
        static Object logFileLock = new Object();

        private static void LogWrite(object log)
        {
            lock (logFileLock)
            {
                try
                {
                    if (!Directory.Exists(SocConst.LOG_DIR))
                        Directory.CreateDirectory(SocConst.LOG_DIR);

                    sw = new StreamWriter(SocConst.LOG_FILE + DateTime.Now.ToString(SocConst.LOG_FILE_FMT) + ".txt", true, Encoding.Default);
                    string line = "[" + DateTime.Now.ToString(SocConst.LOG_DATE_TIME_FMT) + "] " + log;
                    sw.WriteLine(line);
                    Console.WriteLine(line);
                    sw.Flush();
                }
                catch (Exception) { }
                finally { if (sw != null) { sw.Close(); } }
            }
        }
    }
}
