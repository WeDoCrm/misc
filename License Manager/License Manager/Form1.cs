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
        delegate void LogDele(string log);
        private string WDdbHost = "localhost";
        private string WDdbName = "WD_LICENSE";
        private string WDdbUser = "root";
        private string WDdbPass = "Genesys!@#";

        public Form1()
        {
            InitializeComponent();
        }

         private MySqlConnection GetmysqlConnection()
        {
            MySqlConnection mconn = null;
            try
            {
                string ConnectionString = "server="+WDdbHost+";uid="+WDdbUser+";pwd="+WDdbPass+";database="+WDdbName;

                mconn = new MySqlConnection(ConnectionString);
                //mconn.Open();

            }
            catch (Exception ex)
            {
                logWriter("GetMySqlConnection Exception");
                logWriter(ex.ToString());
            }
            return mconn;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer.Interval = 3600000;
            timer.Tick += new EventHandler(timer_Tick);
            loadComcode();
            ReceiveServerCheckSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
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
                IPEndPoint iep = new IPEndPoint(IPAddress.Any, 5999);
                ReceiveServerCheckSocket.Bind(iep);

                Thread receiveThread = new Thread(new ThreadStart(ReceiveRequest));
                receiveThread.Start();

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

        

        private void ReceiveRequest()
        {
            try
            {
                logWriter("ReceiveRequest Thread 시작");

                ReceiveServerCheckSocket.Listen(10);
                while (true)
                {
                    try
                    {
                        logWriter("연결 대기중");
                        Socket listenSocket = ReceiveServerCheckSocket.Accept();
                        logWriter("연결 요청 수신");
                        Thread clientSockThread = new Thread(new ParameterizedThreadStart(receiveClientMsg));
                        clientSockThread.Start(listenSocket);
                    }
                    catch (SocketException e)
                    {
                        logWriter("ReceiveMsg() 에러 : " + e.ToString());
                    }

                }
            }
            catch (Exception exception)
            {
                logWriter(exception.ToString());
            }
        }

        private void receiveClientMsg(object obj)
        {
            try
            {
                Socket clientSocket = (Socket)obj;
                logWriter("receiveClientMsg Thread 시작");
                string com_code="";
                string MACID="";
                try
                {
                    int buffersize = 0;
                    byte[] msgbuffer;
                    byte[] buffer = new byte[55600];
                    int buffercount = clientSocket.Receive(buffer);
                    logWriter("수신!");
                    EndPoint ep = clientSocket.RemoteEndPoint;
                    IPEndPoint statiep = (IPEndPoint)ep;
                    logWriter("sender IP : " + statiep.Address.ToString());
                    logWriter("sender port : " + statiep.Port.ToString());
                    string company = "기타";
                    if (buffer != null && buffer.Length != 0)
                    {
                        msgbuffer = new byte[buffercount];
                        for (int i = 0; i < buffercount; i++)
                        {
                            msgbuffer[i] = buffer[i];
                        }
                        string msg = Encoding.UTF8.GetString(msgbuffer);
                        msg = msg.Trim();
                        logWriter(msg);
                        string[] reqArr = msg.Split('&');
                        if (reqArr.Length > 1)
                        {
                            if (reqArr[0].Equals("grant")) //grant&password&comcd&comName&expiredate
                            {
                                if (reqArr.Length == 5)
                                {
                                    string result = licenseMaker(reqArr[1], reqArr[2], reqArr[3], reqArr[4]);
                                    byte[] sendbuffer = Encoding.UTF8.GetBytes(result.ToString());
                                    int sendcount = clientSocket.Send(sendbuffer);
                                    if (sendcount != 0)
                                    {
                                        logWriter("라이선스 생성결과 전송 성공 : " + result);
                                    }
                                }
                                else
                                {
                                    string result = "0";
                                    byte[] sendbuffer = Encoding.UTF8.GetBytes(result.ToString());
                                    int sendcount = clientSocket.Send(sendbuffer);
                                    if (sendcount != 0)
                                    {
                                        logWriter("라이선스 생성결과 전송 성공 : " + result);
                                    }
                                }
                            }
                            else if (reqArr[0].Equals("list"))
                            {
                                Hashtable licenseInfo = readLicenseInfoAll(); //com_info[com_code] = expire_date + "|" + com_name;
                                string infolist = "2†";
                                foreach (DictionaryEntry de in licenseInfo)
                                {
                                    string temp = de.Value.ToString();
                                    string[] arr = temp.Split('|');
                                    infolist += de.Key.ToString() + "&" + arr[1] + "&" + arr[0] + "†";
                                }

                                byte[] sendbuffer = Encoding.UTF8.GetBytes(infolist);
                                int sendcount = clientSocket.Send(sendbuffer);
                                if (sendcount != 0)
                                {
                                    logWriter("라이선스 정보 전송 성공 : " + infolist);
                                }
                            }
                            else
                            {
                                com_code = reqArr[0];
                                MACID = reqArr[1];
                            }
                        }

                        if (!reqArr[0].Equals("grant") && !reqArr[0].Equals("list"))
                        {
                            //socketTable[com_code] = clientSocket;
                            string result = checkCustomer(com_code, MACID);
                            byte[] sendbuffer = Encoding.UTF8.GetBytes(result.ToString());
                            int sendcount = clientSocket.Send(sendbuffer);
                            if (sendcount != 0)
                            {
                                logWriter(com_code + " 에게 라이선스 인증결과 전송 성공 : " + result);
                            }
                        }
                    }

                }
                catch (SocketException e)
                {
                    logWriter("ReceiveMsg() 에러 : " + e.ToString());
                }
            }
            catch (Exception exception)
            {
                logWriter(exception.ToString());
            }
        }

        private string licenseMaker(string password, string comcd, string comName, string expire)
        {
            string result = "";
            try
            {
                if (password.Equals("ckftmwjd"))
                {
                    int r = insertCompanyInfo(comcd, comName, expire);
                    if (r == 0)
                    {
                        MACLIST[comcd] = "";
                        result = "1";
                    }
                    else if (r == 2)
                    {
                        result = "3";
                    }
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

        private string checkCustomer(string com_code, string MACID)
        {
            int result = 0;
            string license_info;
            string com_name = "";
            DateTime expire_date;
            Hashtable customer_info = new Hashtable();
            //result = -1 : 등록되어있지 않음
            //result = 1 : 라이선스 만료
            //result = 2 : 인증
            //result = 3: 30일 남음
            //result = 4: 7일 이하 남음
            //result = 5: 중복등록
            try
            {
                bool certify_mac = false;
                bool certify_license = false;

                customer_info = readLicenseInfo(com_code);

                if (customer_info.Count > 0)
                {
                    string[] tempArr = customer_info[com_code].ToString().Split('|');
                    logWriter("tempArr[0] = " + tempArr[0].ToString());
                    logWriter("tempArr[1] = " + tempArr[1].ToString());

                    com_name = tempArr[1];

                    string mac = "";
                    foreach (DictionaryEntry de in MACLIST)
                    {
                        logWriter("key : " + de.Key.ToString() + "   value : " + de.Value.ToString());
                    }
                    if (MACLIST.ContainsKey(com_code))
                    {
                        if (MACLIST[com_code].ToString().Length > 0)
                        {
                            mac = MACLIST[com_code].ToString();
                            if (MACID.Equals(mac))
                            {
                                certify_mac = true;
                            }
                            else
                            {
                                result = 5;
                            }
                        }
                        else
                        {
                            MACLIST[com_code] = MACID;
                            logWriter("MAC 등록 : " + com_code + " = " + MACID);

                            
                            certify_mac = true;
                        }
                    }
                    else
                    {
                        result = -1;
                        logWriter("MACLIST 에해당코드 없음");
                    }

                    if (result != 5 && result != -1)
                    {
                        DateTime now = DateTime.Now;

                        if (customer_info.Count != 0)
                        {
                            string tempTime = tempArr[0];
                            string[] arr = tempTime.Split('/');
                            expire_date = new DateTime(Convert.ToInt32(arr[0]), Convert.ToInt32(arr[1]), Convert.ToInt32(arr[2]));
                            logWriter(expire_date.ToShortDateString());
                            //now 값이 앞의 날짜이면 1 / 같은날이거나 지난날짜이면 -1
                            int isExpire = expire_date.CompareTo(now);
                            logWriter("isExpire = " + isExpire.ToString());

                            if (isExpire == -1)
                            {
                                result = 1;
                            }
                            else
                            {
                                int remnant = (expire_date - now).Days;
                                logWriter("남은 일수 : " + remnant.ToString());
                                if (remnant == 30)
                                {
                                    result = 3;
                                }
                                else if (remnant < 7)
                                {
                                    result = 4;
                                }
                                else
                                {
                                    result = 2;
                                }
                            }
                        }
                        else
                        {
                            logWriter("고객정보 읽어오기 실패");
                        }
                    }
                }
                else
                {
                    result = -1;
                }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }

            license_info = result.ToString() + "&" + com_name;
            return license_info;
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
                        while(reader.Read())
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
            if (e.CloseReason == CloseReason.TaskManagerClosing || e.CloseReason == CloseReason.WindowsShutDown)
            {
                Process.GetCurrentProcess().Kill();
            }
            else
            {
                e.Cancel = true;
                this.ShowInTaskbar = false;
                this.Hide();
            }
        }

        private void btn_close_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
               DialogResult result = MessageBox.Show("정말 라이선스 서버를 종료하시겠습니까?", "알림", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               if (result == DialogResult.Yes)
               {
                   notifyIcon1.Visible = false;
                   Process.GetCurrentProcess().Kill();
               }
            }
            catch (Exception ex)
            {
                logWriter(ex.ToString());
            }
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
                string pass = checkpass.tbx_pass.Text.Trim();
                if (pass.Equals("ckftmwjd"))
                {
                    checkpass.Close();
                    if (addcompany != null)
                    {
                        insertCompanyInfo(addcompany.tbx_code.Text, addcompany.tbx_name.Text, addcompany.tbx_expire.Text);
                        MessageBox.Show("정상 발급 되었습니다");
                        MACLIST[addcompany.tbx_code.Text] = "";
                        checkpass.Close();
                        addcompany.Close();
                    }
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
                result = 2;
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
