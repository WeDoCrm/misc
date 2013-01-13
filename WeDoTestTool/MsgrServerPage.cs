using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using Elegant.Ui.Samples.ControlsSample.Sockets;
using System.Net.Sockets;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class MsgrServerPage : SamplePageBase
    {

        TcpServerMgr mServer;
        int mPort = 1100;
        delegate void CallbackProgressBarFileStream(object sender, SocStatusEventArgs e);
        delegate void CallbackProgressBarFileBegin(object sender, SocStatusEventArgs e);
        delegate void CallbackProgressBarFileEnd(object sender, SocStatusEventArgs e);
        delegate void CallbackRichTextBoxLog(object sender, SocStatusEventArgs e, string str);
        delegate void CallbackTextBoxSocketStatus(object sender, SocStatusEventArgs e, string str);
        delegate void CallbackCancelButtonStatus(object sender, SocStatusEventArgs e);

        private readonly FolderBrowserDialog _openDirectoryDialog;

        public MsgrServerPage()
        {
            InitializeComponent();
            //GroupBoxFileTransferStatus.Visible = false;
            _openDirectoryDialog = new FolderBrowserDialog();
            MainForm.SetMonospaceFont(TextBoxSocketStatus);
        }

        private void ButtonServerRun_Click(object sender, EventArgs e)
        {
            try
            {
                mPort = Convert.ToInt32(TextBoxPortNum.Text);
            }
            catch (Exception ex)
            {
                mPort = 0;
                MessageBox.Show(this, "포트값이 잘못되었습니다.", "경고",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
            }
            if (mServer != null && mServer.isListening())
            {
                Utils.showMsgBox(this,"동일한 포트가 이미 사용중입니다.","소켓오류");
                return;
            }
            mServer = new TcpServerMgr(mPort);
            //mServer.BufferChanged += mServer_BufferChanged;//new EventHandler(mServer_BufferChanged);
            mServer.SocStatusChanged += SocStatusChanged;
            mServer.DoRun();
        }

        private void ButtonServerStop_Click(object sender, EventArgs e)
        {
            mServer.Stop();
        }

        private void ButtonListClient_Click(object sender, EventArgs e)
        {
            mServer.listClient();
        }

        private void ProgressBarStatusChanged(object sender, SocStatusEventArgs e)
        {
            if (this.ProgressBarFileReceiving.InvokeRequired)
            {
                CallbackProgressBarFileStream d = new CallbackProgressBarFileStream(ProgressBarStatusChanged);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ProgressBarFileReceiving.Value = (int)(100 * e.Status.fileSizeDone / e.Status.FileSize);
                Logger.info("ProgressBarFileReceiving.Value=" + ProgressBarFileReceiving.Value);
            }
        }

        private void ProgressBarFileBegin(object sender, SocStatusEventArgs e)
        {
            if (this.ProgressBarFileReceiving.InvokeRequired)
            {
                CallbackProgressBarFileBegin d = new CallbackProgressBarFileBegin(ProgressBarFileBegin);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ProgressBarFileReceiving.Visible = true;
                Logger.info("ProgressBarFileReceiving.Visible=" + ProgressBarFileReceiving.Visible);
            }
        }
        private void ProgressBarFileEnd(object sender, SocStatusEventArgs e)
        {
            if (this.ProgressBarFileReceiving.InvokeRequired)
            {
                CallbackProgressBarFileEnd d = new CallbackProgressBarFileEnd(ProgressBarFileEnd);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ProgressBarFileReceiving.Visible = false;
                Logger.info("ProgressBarFileReceiving.Visible=" + ProgressBarFileReceiving.Visible);
            }

        }
        private void RichTextBoxLogChanged(object sender, SocStatusEventArgs e, string strStatus)
        {
            if (this.RichTextBoxLog.InvokeRequired)
            {
                CallbackRichTextBoxLog d = new CallbackRichTextBoxLog(RichTextBoxLogChanged);
                this.Invoke(d, new object[] { sender, e, strStatus });
            }
            else
            {
                this.RichTextBoxLog.AppendText(">" + strStatus + ":" + e.Status.socMessage + "\n");
                if (e.Status.exception != null)
                {
                    if (e.Status.exception is SocketException)
                        RichTextBoxLog.AppendText(string.Format(">Error: {0} : {1}",
                            ((SocketException)e.Status.exception).ErrorCode,
                            ((SocketException)e.Status.exception).Message) + "\n");
                    else
                    {
                        this.RichTextBoxLog.AppendText(string.Format(">Error: {0}", e.Status.exception.Message) + "\n");
                    }
                }
                this.RichTextBoxLog.ScrollToCaret();
            }

        }
        private void TextBoxSocketStatusChanged(object sender, SocStatusEventArgs e, string strStatus)
        {
            if (this.TextBoxSocketStatus.InvokeRequired)
            {
                CallbackTextBoxSocketStatus d = new CallbackTextBoxSocketStatus(TextBoxSocketStatusChanged);
                this.Invoke(d, new object[] { sender, e, strStatus });
            }
            else
            {
                AddEventsLogMessage(strStatus);
                //UpdateListBoxSelectedItemIndicesTextBox();
            }
        }

        private void ButtonCancelStatusChanged(object sender, SocStatusEventArgs e)
        {
            if (this.ButtonStopReceiving.InvokeRequired)
            {
                CallbackCancelButtonStatus d = new CallbackCancelButtonStatus(ButtonCancelStatusChanged);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                //ButtonStopReceiving.Enabled = !ButtonStopReceiving.Enabled;
            }
        }

        private void SocStatusChanged(object sender, SocStatusEventArgs e)
        {
            //Logger.info("Form1.OnSocStatusChanged:"+e.Status.socMessage);

            string strStatus = "";
            switch (e.Status.status)
            {
                case SocHandlerStatus.UNINIT:
                    strStatus = "UNINIT";
                    break;
                case SocHandlerStatus.CONNECTED:
                    strStatus = "CONNECTED";
                    break;
                case SocHandlerStatus.DISCONNECTED:
                    strStatus = "DISCONNECTED";
                    break;
                case SocHandlerStatus.ERROR:
                    strStatus = "ERROR";
                    break;
                case SocHandlerStatus.RECEIVING:
                    strStatus = "RECEIVING";
                    break;
                case SocHandlerStatus.SENDING:
                    strStatus = "SENDING";
                    break;
                case SocHandlerStatus.LISTENING:
                    strStatus = "LISTENING";
                    break;
                case SocHandlerStatus.STOP:
                    strStatus = "STOP";
                    break;
            }

            if (e.Status.ftpStatus == FTPStatus.RECEIVE_STREAM)
            {
                ProgressBarStatusChanged(sender, e);
            }

            if (e.Status.ftpStatus == FTPStatus.RECEIVED_FILE_INFO)
            {
                ProgressBarFileBegin(sender, e);
                ButtonCancelStatusChanged(sender, e);
            }
            if (e.Status.ftpStatus == FTPStatus.SENT_DONE)
            {
                ProgressBarFileEnd(sender, e);
                ButtonCancelStatusChanged(sender, e);
            }

            RichTextBoxLogChanged(sender, e, strStatus);

            TextBoxSocketStatusChanged(sender, e, strStatus);
        }

        private int _eventLogCounter;

        private void AddEventsLogMessage(string m)
        {
            _eventLogCounter++;
            string text = TextBoxSocketStatus.Text + _eventLogCounter + " " + m + Environment.NewLine;

            int firstLineEnd = text.IndexOf(Environment.NewLine);
            if (firstLineEnd > 0)
            {
                int newLineCount = 0, currentLineIndex = firstLineEnd + Environment.NewLine.Length;
                while (currentLineIndex > 0)
                {
                    newLineCount += 1;
                    int startIndex = currentLineIndex + Environment.NewLine.Length;
                    if (startIndex >= text.Length - 1)
                        break;

                    currentLineIndex = text.IndexOf(Environment.NewLine, startIndex);
                }

                if (newLineCount == 100)
                {
                    text = text.Remove(0, firstLineEnd + Environment.NewLine.Length);
                }
            }

            TextBoxSocketStatus.Text = text;
            TextBoxSocketStatus.Select(TextBoxSocketStatus.TextLength, 0);
            TextBoxSocketStatus.ScrollToCaret();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                //if (mServer != null)
                //mServer.Stop();
            }
            else
            {
                Logger.info("mServer stops.");
                if (mServer != null)
                    mServer.Stop();
                //MessageBox.Show(this, "안보임.", "경고",
                //            MessageBoxButtons.OK,
                //            MessageBoxIcon.Warning,
                //            MessageBoxDefaultButton.Button1,
                //            MessageBoxOptions.RtlReading);
            }

            base.OnVisibleChanged(e);
        }

        private void BottonLogErase_Click(object sender, EventArgs e)
        {
            RichTextBoxLog.Clear();
        }

        public void Dispose()
        {
            base.Dispose();

            if (mServer != null)
                mServer.Stop();
        }

        string mSavePath = "C:\\temp";

        private void ButtonChoosePath_Click(object sender, EventArgs e)
        {
            DialogResult result = _openDirectoryDialog.ShowDialog();
            if (result == DialogResult.OK )
            {
                mSavePath = _openDirectoryDialog.SelectedPath;
                if (mServer != null && mServer.isListening())
                {
                    mServer.SetSaveFilePath(mSavePath);
                    TextBoxFilePath.Text = mSavePath;
                }
            }

        }

        private void ComboBoxLogLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Logger.setLogLevel((LOGLEVEL)ComboBoxLogLevel.SelectedIndex);
        }

        private void ButtonStopReceiving_Click(object sender, EventArgs e)
        {
            mServer.CancelReceiving();
        }

    }
}