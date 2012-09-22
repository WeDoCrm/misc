using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections;
using System.Diagnostics;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data;
using MySql.Data.Types;
using System.IO;

namespace License_Manager
{
    public partial class Form1 : Form
    {
        public static System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        Socket ReceiveServerCheckSocket;
        Hashtable socketTable = new Hashtable();
        Hashtable MACLIST = new Hashtable();
        CheckPass checkpass;
        AddCompany addcompany;
        DirectoryInfo di;
        bool CanFileWrite = false;
        StreamWriter sw;
        Socket sock;
        delegate void LogDele(string log);
        delegate void stringDele(string str);
        delegate void NoParamDele();
        delegate void listDele(string com_code, string comName, string expire);
        private string WDdbHost;
        private string WDdbName;
        private string WDdbUser;
        private string WDdbPass;
        private string LIC_SERVER_HOST = "211.52.153.160";


        public Form1()
        {
            InitializeComponent();
        }

        private MySqlConnection GetmysqlConnection()
        {
            MySqlConnection mconn = null;
            //try
            //{
            //    string ConnectionString = "server=" + WDdbHost + ";uid=" + WDdbUser + ";pwd=" + WDdbPass + ";database=" + WDdbName;

            //    mconn = new MySqlConnection(ConnectionString);
            //    //mconn.Open();

            //}
            //catch (Exception ex)
            //{
            //    logWriter("GetMySqlConnection Exception");
            //    logWriter(ex.ToString());
            //}
            return mconn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //timer.Interval = 3600000;
            //timer.Tick += new EventHandler(timer_Tick);
            //loadComcode();
            initSocket();
            di = new DirectoryInfo(Application.StartupPath + "\\log");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            if (hour == 1)
            {
                loadComcode();
            }
        }

        private void initSocket()
        {
            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(LIC_SERVER_HOST, 5999);

                if (sock.Connected == true)
                {
                    Thread t1 = new Thread(new ThreadStart(listenfromLicenseServer));
                    t1.Start();
                    byte[] message = Encoding.UTF8.GetBytes("list&");
                    sock.Send(message);
                }

            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }


        private void listenfromLicenseServer()
        {
            try
            {
                int buffersize = 0;
                byte[] msgbuffer;
                byte[] buffer = new byte[55600];
                int buffercount = sock.Receive(buffer);
                logWriter("수신! : " + buffercount.ToString() + " bytes");
                EndPoint ep = sock.RemoteEndPoint;
                IPEndPoint statiep = (IPEndPoint)ep;
                logWriter("sender IP : " + statiep.Address.ToString());
                logWriter("sender port : " + statiep.Port.ToString());
                if (buffer != null && buffer.Length != 0)
                {
                    msgbuffer = new byte[buffercount];
                    for (int i = 0; i < buffercount; i++)
                    {
                        msgbuffer[i] = buffer[i];
                    }
                    string msg = Encoding.UTF8.GetString(msgbuffer);
                    msg = msg.Trim();
                    logWriter("수신메시지 : " + msg);
                    stringDele dele = new stringDele(disposeLicenseResult);
                    Invoke(dele, msg);
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void disposeLicenseResult(string result)//result = 
        {
            try
            {
                //result = -1 : 비밀번호 틀림
                //result = 1 : 라이선스 생성 성공
                //result = 0 : 요청정보 부족
                //result = 2 : 라이선스 리스트 정보
                //result = 3 : 코드중복 또는 기한입력오류

                string license_message = "";
                string[] license_info = result.Split('†');
                result = license_info[0];
               

                switch (result)
                {
                    case "-1":
                        MessageBox.Show("비밀번호가 올바르지 않습니다.");
                        checkpass.tbx_pass.Focus();
                        break;

                    case "1":
                        MessageBox.Show("요청하신 라이선스가 정상발급 되었습니다.");
                        checkpass.Close();
                        addcompany.Close();
                        NoParamDele reload = new NoParamDele(reloadList);
                        Invoke(reload);

                        break;

                    case "2":

                        if (license_info.Length > 1)
                        {
                            NoParamDele nodele = new NoParamDele(clearDGV);
                            Invoke(nodele);
                            listDele dele = new listDele(listupLicenseInfo);
                            foreach (string item in license_info)
                            {
                                if (item.Length > 1)
                                {
                                    string[] temparr = item.Split('&'); //com_code&comName&2099/12/31
                                    Invoke(dele, new object[] { temparr[0], temparr[1], temparr[2] });
                                }
                            }
                        }

                        break;

                    case "3":
                        MessageBox.Show("코드가 중복되었거나 만료일자 오류입니다.");
                        checkpass.Close();

                        break;
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void reloadList()
        {
            try
            {
                dgv1.Rows.Clear();
                initSocket();
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void clearDGV()
        {
            try
            {
                dgv1.Rows.Clear();
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void listupLicenseInfo(string com_code, string comName, string expire)
        {
            try
            {
                dgv1.Rows.Add(new object[] { com_code, comName, "", expire, "", "", "" });
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void loadComcode()
        {
            MySqlConnection conn = GetmysqlConnection();
            string com_code;
            MACLIST.Clear();
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select COM_CODE from customer_list";
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            com_code = reader.GetString(0);
                            MACLIST[com_code] = "";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
            if (conn.State == ConnectionState.Connecting)
            {
                conn.Close();
            }
        }


        private string licenseMaker(string password, string comcd, string comName, string expire)
        {
            string result = "";
            try
            {
                if (password.Equals("ckftmwjd"))
                {
                    insertCompanyInfo(comcd, comName, expire);
                    MACLIST[addcompany.tbx_code.Text] = "";
                    result = "1";
                }
                else
                {
                    result = "-1";
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }

            return result;
        }

       

        private Hashtable readLicenseInfo(string com_code)
        {
            Hashtable com_info = new Hashtable();
            string com_name="";
            string expire_date="";
            MySqlConnection conn = GetmysqlConnection();
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("code", MySqlDbType.VarChar).Value = com_code;
                    command.CommandText = "select * from customer_list where COM_CODE = @code";
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            com_name = reader.GetString("COM_NAME");
                            expire_date = reader.GetString("EXPIRE_DATE");
                            com_info[com_code] = expire_date + "|" + com_name;
                            
                        }
                    }

                    logWriter("고객 라이선스 정보 획득 : " + com_name + " = " + expire_date);
                    foreach (DictionaryEntry de in com_info)
                    {
                        logWriter("com_info[ = "+de.Key.ToString() + " = " + de.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return com_info;
        }

        private Hashtable readLicenseInfoAll()
        {
            Hashtable com_info = new Hashtable();
            string com_name = "";
            string expire_date = "";
            string com_code = "";
            MySqlConnection conn = GetmysqlConnection();
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "select * from customer_list";
                    MySqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                            com_code = reader.GetString("COM_CODE");
                            com_name = reader.GetString("COM_NAME");
                            expire_date = reader.GetString("EXPIRE_DATE");
                            com_info[com_code] = expire_date + "|" + com_name;
                        }
                    }

                    logWriter("고객 라이선스 정보 획득 : " + com_name + " = " + expire_date);
                    foreach (DictionaryEntry de in com_info)
                    {
                        logWriter("com_info[ = " + de.Key.ToString() + " = " + de.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return com_info;
        }

        private void sendCheckResult(string com_code, string message)
        {
            try
            {
                Socket client = (Socket)socketTable[com_code];
                byte[] buffer = Encoding.UTF8.GetBytes(message);
                client.Send(buffer);
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private Hashtable getCustomerInfo(string com_code)
        {
            Hashtable info = new Hashtable();
            string expire_date = "";
            string mac = "";


            DataGridViewRowCollection collection = dgv1.Rows;

            foreach (DataGridViewRow row in collection)
            {
                if (row.Tag.ToString().Equals(com_code))
                {
                    expire_date = row.Cells[3].Value.ToString();
                    mac = row.Cells[6].Value.ToString();
                    break;
                }
            }

            return info;
        }


        private void con_menu_stip_show_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void btn_close_MouseClick(object sender, MouseEventArgs e)
        {

            notifyIcon1.Visible = false;
            Process.GetCurrentProcess().Kill();

        }

        private void btn_confirm_MouseClick(object sender, MouseEventArgs e)
        {
            string pass = checkpass.tbx_pass.Text.Trim();
            if (pass.Equals("ckftmwjd"))
            {
                Process.GetCurrentProcess().Kill();
            }
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                addcompany = new AddCompany();
                addcompany.btn_add.MouseClick += new MouseEventHandler(btn_add_MouseClick);
                addcompany.Show();
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void btn_add_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                checkpass = new CheckPass();
                checkpass.btn_confirm.MouseClick += new MouseEventHandler(btn_confirm_MouseClickForAdd);
                checkpass.Show();
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void btn_confirm_MouseClickForAdd(object sender, MouseEventArgs e)
        {
            try
            {
                string pass = checkpass.tbx_pass.Text.Trim(); //grant&password&comcd&comName&expiredate
                string reqMessage = "grant&" + pass + "&" + addcompany.tbx_code.Text + "&" + addcompany.tbx_name.Text + "&" + addcompany.tbx_expire.Text;
                stringDele dele = new stringDele(sendRequest);
                Invoke(dele, reqMessage);
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private void sendRequest(string reqMessage)
        {
            try
            {
                sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                sock.Connect(LIC_SERVER_HOST, 5999);

                if (sock.Connected == true)
                {
                    Thread t1 = new Thread(new ThreadStart(listenfromLicenseServer));
                    t1.Start();
                    byte[] message = Encoding.UTF8.GetBytes(reqMessage);
                    sock.Send(message);
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
        }

        private int insertCompanyInfo(string code, string name, string expire_date)
        {
            int result = 0;
            //result = 0 : 신규발급
            //result = 1 : 업데이트
            //result = 2 : 발급실패
            MySqlConnection conn = GetmysqlConnection();
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    MySqlCommand command = new MySqlCommand();
                    command.Connection = conn;
                    command.CommandType = CommandType.Text;
                    command.Parameters.Add("code", MySqlDbType.VarChar).Value = code;
                    command.Parameters.Add("comName", MySqlDbType.VarChar).Value = name;
                    command.Parameters.Add("expire", MySqlDbType.VarChar).Value = expire_date;
                    command.CommandText = "insert into customer_list values(@code, @comName, @expire)";
                    int count = command.ExecuteNonQuery();

                    logWriter(count + " 행 INSERT 성공!");
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            return result;
        }

        private void btn_mac_refresh_MouseClick(object sender, MouseEventArgs e)
        {
            MACLIST.Clear();
            loadComcode();
        }


        /// <summary>
        /// 서버 로그창에 로그 쓰기 및 로그파일에 쓰기
        /// </summary>
        /// <param name="svrLog"></param>
        public void logWriter(string Log)
        {
            try
            {
                Log += "( " + DateTime.Now.ToString() + ")" + "\r\n";
                if (this.InvokeRequired)
                {
                    LogDele dele = new LogDele(logFileWrite);
                    Invoke(dele, Log);
                    if (CanFileWrite == true)
                        logFileWrite(Log);
                }
                else
                {
                    if (CanFileWrite == true) logFileWrite(Log);
                }
            }
            catch (Exception exception)
            {
                logWriter(exception.ToString());
            }
        }

        /// <summary>
        /// 서버 관련 파일 폴더 생성
        /// </summary>
        public void FolderCheck()
        {
            try
            {
                if (!di.Exists)
                {
                    di.Create();
                    logWriter(" 폴더 생성!");
                }
            }
            catch (Exception e)
            {
                logWriter(e.ToString() + " : 폴더를 생성하지 못했습니다.");
            }
            CanFileWrite = true;
        }


        /// <summary>
        /// 로그파일 생성 및 쓰기
        /// </summary>
        /// <param name="_log"></param>
        public void logFileWrite(string _log)
        {
            try
            {
                if (!di.Exists)
                {
                    FolderCheck();
                }
                try
                {
                    sw = new StreamWriter(Application.StartupPath + "\\LicenseManager_" + DateTime.Now.ToShortDateString() + ".log", true);
                    sw.WriteLine(_log);
                    sw.Close();
                }
                catch (Exception e)
                {
                    if (this.InvokeRequired)
                    {
                        LogDele dele = new LogDele(logFileWrite);
                        Invoke(dele, "logFileWriter() 에러 : " + e.ToString());
                    }
                    else logWriter("logFileWriter() 에러 : " + e.ToString());
                }
            }
            catch (Exception exception)
            {
                logWriter(exception.ToString());
            }
        }
        
    }
}
