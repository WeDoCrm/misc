using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample.Sockets
{
    public class Utils
    {
        public static byte[] GetBytesFromFile(string fullFilePath)
        {
            // this method is limited to 2^32 byte files (4.2 GB)

            FileStream fs = File.OpenRead(fullFilePath);
            try
            {
                byte[] bytes = new byte[fs.Length];
                fs.Read(bytes, 0, Convert.ToInt32(fs.Length));
                fs.Close();
                return bytes;
            }
            finally
            {
                fs.Close();
            }
        }

        public static string GetFileName(string path)
        {
            string[] token = path.Split('\\');
            if (token.Length == 1) return path;
            return token[token.Length - 1];
        }

        public static string GetPath(string path)
        {
            if (path.LastIndexOf('\\') < 0) return path;
            return path.Substring(0, path.LastIndexOf('\\'));
        }


        public static string getIndexedFileName(string fileName, int index)
        {
            string shortFileName = fileName.Substring(0, fileName.LastIndexOf('.'));
            string extension = fileName.Substring(fileName.LastIndexOf('.') + 1);
            if (index == 0)
                return fileName;
            else
                return string.Format("{0}_{1}.{2}", shortFileName, index, extension);
        }

        public static string getValidFileName(string path, string fileName, int index)
        {
            string fileRename = getIndexedFileName(fileName, index);
            string fullFileRename = string.Format("{0}\\{1}", path, fileRename);

            string[] files = Directory.GetFiles(path, fileRename, SearchOption.TopDirectoryOnly);

            bool fileExists = false;
            foreach (string file in files)
            {
                fileExists = (file == fullFileRename);
            }

            if (fileExists)
            {
                return getValidFileName(path, fileName, ++index);
            }
            else
            {
                return fullFileRename;
            }
        }

        public static int getMode(string msg)
        {
            int mode = 0;
            string[] udata = null;
            try
            {
                msg = msg.Trim();
                if (msg == null || msg.IndexOf(SocConst.TOKEN) < 0)
                    return 0;
                udata = msg.Split('|');
                mode = Convert.ToInt32(udata[0]);
            }
            catch (Exception ex)
            {
                Logger.error("getMode() Exception : " + ex.ToString());
                mode = 10000;
            }
            return mode;
        }

        public static string getCmd(string msg)
        {
            string[] udata = null;
            string cmd;
            try
            {
                msg = msg.Trim();
                if (msg == null)
                    return "";
                if (msg.IndexOf(SocConst.TOKEN) < 0)
                    return msg;
                udata = msg.Split('|');
                cmd = udata[0];
            }
            catch (Exception ex)
            {
                Logger.error("getMode() Exception : " + ex.ToString());
                cmd = "";
            }
            return cmd;
        }

        public static string getIpAddress(string ipStr1, string ipStr2, string ipStr3, string ipStr4)
        {
            string ipAddress;
            try
            {
                ipAddress = string.Format("{0}.{1}.{2}.{3}",
                    Int64.Parse(ipStr1),
                    Int64.Parse(ipStr2),
                    Int64.Parse(ipStr3),
                    Int64.Parse(ipStr4));

            }
            catch (Exception e)
            {
                return "";
            }
            return ipAddress;
        }

        public static void showMsgBox(IWin32Window win, string msg, string title) {
            MessageBox.Show(win, msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1,
                            MessageBoxOptions.RtlReading);
        }

        public static byte[] ConvertFileSizeToByteArray(Int32 fileSize)
        {
            byte[] buffer = new byte[6];
            byte[] bDelim = Encoding.UTF8.GetBytes("|");
            byte[] bSrc = BitConverter.GetBytes(fileSize);
            Buffer.BlockCopy(bDelim, 0, buffer, 0, bDelim.Length);
            Buffer.BlockCopy(bSrc, 0, buffer, bDelim.Length, bSrc.Length);
            Buffer.BlockCopy(bDelim, 0, buffer, bSrc.Length + bDelim.Length, bDelim.Length);
            return buffer;
        }

        const string DELIM = "|";

        public static Int32 ConvertByteArrayToFileSize(byte[] b)
        {
            string sDelim = Encoding.UTF8.GetString(b, 0, 1);
            if (sDelim != DELIM) return 0;
            sDelim = Encoding.UTF8.GetString(b, 5, 1);
            if (sDelim != DELIM) return 0;
            return BitConverter.ToInt32(b, 1);
        }
    }
}
