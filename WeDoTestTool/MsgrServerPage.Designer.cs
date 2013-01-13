namespace Elegant.Ui.Samples.ControlsSample
{
    partial class MsgrServerPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ListBoxPagePanel = new Elegant.Ui.Panel();
            this.ComboBoxLogLevel = new Elegant.Ui.ComboBox();
            this.TextBoxFilePath = new Elegant.Ui.TextBox();
            this.ButtonChoosePath = new Elegant.Ui.Button();
            this.BottonLogErase = new Elegant.Ui.Button();
            this.ButtonListClient = new Elegant.Ui.Button();
            this.GroupBoxFileTransferStatus = new Elegant.Ui.GroupBox();
            this.ButtonStopReceiving = new Elegant.Ui.Button();
            this.ProgressBarFileReceiving = new Elegant.Ui.ProgressBar();
            this.RichTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.ButtonServerStop = new Elegant.Ui.Button();
            this.ButtonServerRun = new Elegant.Ui.Button();
            this.TextBoxPortNum = new Elegant.Ui.TextBox();
            this.ListBoxSelectedItemIndicesLabel = new Elegant.Ui.Label();
            this.EventsLogLabel = new Elegant.Ui.Label();
            this.TextBoxSocketStatus = new Elegant.Ui.TextBox();
            this.ListBoxPagePanel.SuspendLayout();
            this.GroupBoxFileTransferStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxPagePanel
            // 
            this.ListBoxPagePanel.Controls.Add(this.ComboBoxLogLevel);
            this.ListBoxPagePanel.Controls.Add(this.TextBoxFilePath);
            this.ListBoxPagePanel.Controls.Add(this.ButtonChoosePath);
            this.ListBoxPagePanel.Controls.Add(this.BottonLogErase);
            this.ListBoxPagePanel.Controls.Add(this.ButtonListClient);
            this.ListBoxPagePanel.Controls.Add(this.GroupBoxFileTransferStatus);
            this.ListBoxPagePanel.Controls.Add(this.RichTextBoxLog);
            this.ListBoxPagePanel.Controls.Add(this.ButtonServerStop);
            this.ListBoxPagePanel.Controls.Add(this.ButtonServerRun);
            this.ListBoxPagePanel.Controls.Add(this.TextBoxPortNum);
            this.ListBoxPagePanel.Controls.Add(this.ListBoxSelectedItemIndicesLabel);
            this.ListBoxPagePanel.Controls.Add(this.EventsLogLabel);
            this.ListBoxPagePanel.Controls.Add(this.TextBoxSocketStatus);
            this.ListBoxPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxPagePanel.Location = new System.Drawing.Point(0, 0);
            this.ListBoxPagePanel.Name = "ListBoxPagePanel";
            this.ListBoxPagePanel.Size = new System.Drawing.Size(761, 415);
            this.ListBoxPagePanel.TabIndex = 0;
            this.ListBoxPagePanel.Text = "ListBoxPagePanel";
            // 
            // ComboBoxLogLevel
            // 
            this.ComboBoxLogLevel.Editable = false;
            this.ComboBoxLogLevel.FormattingEnabled = false;
            this.ComboBoxLogLevel.Id = "396a9314-cbe6-4667-9b2c-367782a7e75a";
            this.ComboBoxLogLevel.Items.AddRange(new object[] {
            "error",
            "info",
            "debug"});
            this.ComboBoxLogLevel.KeyTip = "B";
            this.ComboBoxLogLevel.LabelAreaWidthTemplate = "log level setting:";
            this.ComboBoxLogLevel.LabelText = "log level setting:";
            this.ComboBoxLogLevel.Location = new System.Drawing.Point(579, 8);
            this.ComboBoxLogLevel.Name = "ComboBoxLogLevel";
            this.ComboBoxLogLevel.ScreenTip.Text = "Buttons";
            this.ComboBoxLogLevel.Size = new System.Drawing.Size(159, 20);
            this.ComboBoxLogLevel.TabIndex = 31;
            this.ComboBoxLogLevel.TextEditorWidth = 10;
            this.ComboBoxLogLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLogLevel_SelectedIndexChanged);
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.BannerText = "파일 수신 경로";
            this.TextBoxFilePath.Id = "82e062d8-e9d8-4eb0-a80c-e1798dce0cb3";
            this.TextBoxFilePath.KeyTip = "I";
            this.TextBoxFilePath.LabelText = "File: ";
            this.TextBoxFilePath.Location = new System.Drawing.Point(385, 334);
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.ScreenTip.Text = "Icon path";
            this.TextBoxFilePath.Size = new System.Drawing.Size(296, 20);
            this.TextBoxFilePath.TabIndex = 29;
            this.TextBoxFilePath.TextEditorWidth = 259;
            // 
            // ButtonChoosePath
            // 
            this.ButtonChoosePath.Id = "63b7ec23-2194-4fc5-be81-ffad58f5107c";
            this.ButtonChoosePath.KeyTip = "C";
            this.ButtonChoosePath.Location = new System.Drawing.Point(682, 333);
            this.ButtonChoosePath.Name = "ButtonChoosePath";
            this.ButtonChoosePath.ScreenTip.Text = "Change the Icon";
            this.ButtonChoosePath.Size = new System.Drawing.Size(25, 21);
            this.ButtonChoosePath.TabIndex = 30;
            this.ButtonChoosePath.Text = "...";
            this.ButtonChoosePath.Click += new System.EventHandler(this.ButtonChoosePath_Click);
            // 
            // BottonLogErase
            // 
            this.BottonLogErase.Id = "e85b7972-d679-49b1-9cbf-131df3afa530";
            this.BottonLogErase.KeyTip = "C";
            this.BottonLogErase.Location = new System.Drawing.Point(342, 397);
            this.BottonLogErase.Name = "BottonLogErase";
            this.BottonLogErase.ScreenTip.Text = "Change the Icon";
            this.BottonLogErase.Size = new System.Drawing.Size(25, 18);
            this.BottonLogErase.TabIndex = 28;
            this.BottonLogErase.Text = "지움";
            this.BottonLogErase.Click += new System.EventHandler(this.BottonLogErase_Click);
            // 
            // ButtonListClient
            // 
            this.ButtonListClient.Id = "895f6ed7-b1c7-4961-8777-4f6200d7ef35";
            this.ButtonListClient.Location = new System.Drawing.Point(386, 226);
            this.ButtonListClient.Name = "ButtonListClient";
            this.ButtonListClient.Size = new System.Drawing.Size(138, 21);
            this.ButtonListClient.TabIndex = 14;
            this.ButtonListClient.Text = "접속리스트보기";
            this.ButtonListClient.Click += new System.EventHandler(this.ButtonListClient_Click);
            // 
            // GroupBoxFileTransferStatus
            // 
            this.GroupBoxFileTransferStatus.Controls.Add(this.ButtonStopReceiving);
            this.GroupBoxFileTransferStatus.Controls.Add(this.ProgressBarFileReceiving);
            this.GroupBoxFileTransferStatus.Id = "b1816ca8-fcbd-4141-8e77-e74a8131c8cb";
            this.GroupBoxFileTransferStatus.Location = new System.Drawing.Point(385, 259);
            this.GroupBoxFileTransferStatus.Name = "GroupBoxFileTransferStatus";
            this.GroupBoxFileTransferStatus.Size = new System.Drawing.Size(353, 60);
            this.GroupBoxFileTransferStatus.TabIndex = 13;
            this.GroupBoxFileTransferStatus.Text = "파일전송상태";
            // 
            // ButtonStopReceiving
            // 
            this.ButtonStopReceiving.Id = "1169f583-d090-4d24-899f-97d7e5173655";
            this.ButtonStopReceiving.Location = new System.Drawing.Point(288, 27);
            this.ButtonStopReceiving.Name = "ButtonStopReceiving";
            this.ButtonStopReceiving.Size = new System.Drawing.Size(38, 21);
            this.ButtonStopReceiving.TabIndex = 32;
            this.ButtonStopReceiving.Text = "취소";
            this.ButtonStopReceiving.Click += new System.EventHandler(this.ButtonStopReceiving_Click);
            // 
            // ProgressBarFileReceiving
            // 
            this.ProgressBarFileReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarFileReceiving.DesiredWidth = 275;
            this.ProgressBarFileReceiving.Id = "67c153a6-5a5b-406f-83ed-3b4c260bd9bf";
            this.ProgressBarFileReceiving.Location = new System.Drawing.Point(12, 27);
            this.ProgressBarFileReceiving.Name = "ProgressBarFileReceiving";
            this.ProgressBarFileReceiving.ScreenTip.Text = "Progress bar";
            this.ProgressBarFileReceiving.Size = new System.Drawing.Size(275, 21);
            this.ProgressBarFileReceiving.TabIndex = 12;
            this.ProgressBarFileReceiving.TabStop = false;
            this.ProgressBarFileReceiving.Text = "ProgressBarFileReceiving";
            this.ProgressBarFileReceiving.Value = 35;
            this.ProgressBarFileReceiving.Visible = false;
            // 
            // RichTextBoxLog
            // 
            this.RichTextBoxLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.RichTextBoxLog.ForeColor = System.Drawing.Color.Yellow;
            this.RichTextBoxLog.Location = new System.Drawing.Point(7, 9);
            this.RichTextBoxLog.Name = "RichTextBoxLog";
            this.RichTextBoxLog.Size = new System.Drawing.Size(360, 389);
            this.RichTextBoxLog.TabIndex = 11;
            this.RichTextBoxLog.Text = "";
            // 
            // ButtonServerStop
            // 
            this.ButtonServerStop.Id = "181c6ffa-fd1b-4bbd-a53c-1e48638e93b2";
            this.ButtonServerStop.Location = new System.Drawing.Point(537, 184);
            this.ButtonServerStop.Name = "ButtonServerStop";
            this.ButtonServerStop.Size = new System.Drawing.Size(138, 21);
            this.ButtonServerStop.TabIndex = 10;
            this.ButtonServerStop.Text = "서버중단";
            this.ButtonServerStop.Click += new System.EventHandler(this.ButtonServerStop_Click);
            // 
            // ButtonServerRun
            // 
            this.ButtonServerRun.Id = "e8ab7502-14e1-415e-a42b-2defce4d6002";
            this.ButtonServerRun.Location = new System.Drawing.Point(386, 184);
            this.ButtonServerRun.Name = "ButtonServerRun";
            this.ButtonServerRun.Size = new System.Drawing.Size(138, 21);
            this.ButtonServerRun.TabIndex = 10;
            this.ButtonServerRun.Text = "서버기동";
            this.ButtonServerRun.Click += new System.EventHandler(this.ButtonServerRun_Click);
            // 
            // TextBoxPortNum
            // 
            this.TextBoxPortNum.Id = "c0d179d1-4077-42d5-9102-4a09ae26d743";
            this.TextBoxPortNum.Location = new System.Drawing.Point(469, 150);
            this.TextBoxPortNum.Name = "TextBoxPortNum";
            this.TextBoxPortNum.Size = new System.Drawing.Size(55, 20);
            this.TextBoxPortNum.TabIndex = 3;
            this.TextBoxPortNum.Text = "1100";
            this.TextBoxPortNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxPortNum.TextEditorWidth = 49;
            // 
            // ListBoxSelectedItemIndicesLabel
            // 
            this.ListBoxSelectedItemIndicesLabel.Location = new System.Drawing.Point(386, 154);
            this.ListBoxSelectedItemIndicesLabel.Name = "ListBoxSelectedItemIndicesLabel";
            this.ListBoxSelectedItemIndicesLabel.Size = new System.Drawing.Size(73, 16);
            this.ListBoxSelectedItemIndicesLabel.TabIndex = 4;
            this.ListBoxSelectedItemIndicesLabel.Text = "메신저 포트";
            // 
            // EventsLogLabel
            // 
            this.EventsLogLabel.Location = new System.Drawing.Point(386, 16);
            this.EventsLogLabel.Name = "EventsLogLabel";
            this.EventsLogLabel.Size = new System.Drawing.Size(73, 12);
            this.EventsLogLabel.TabIndex = 4;
            this.EventsLogLabel.Text = "소켓 상태";
            // 
            // TextBoxSocketStatus
            // 
            this.TextBoxSocketStatus.Id = "732c7828-b1d2-49f0-b658-7489b550d006";
            this.TextBoxSocketStatus.Location = new System.Drawing.Point(386, 30);
            this.TextBoxSocketStatus.Multiline = true;
            this.TextBoxSocketStatus.Name = "TextBoxSocketStatus";
            this.TextBoxSocketStatus.ReadOnly = true;
            this.TextBoxSocketStatus.Size = new System.Drawing.Size(352, 111);
            this.TextBoxSocketStatus.TabIndex = 2;
            this.TextBoxSocketStatus.TextEditorWidth = 296;
            // 
            // MsgrServerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListBoxPagePanel);
            this.Name = "MsgrServerPage";
            this.Size = new System.Drawing.Size(761, 415);
            this.ListBoxPagePanel.ResumeLayout(false);
            this.ListBoxPagePanel.PerformLayout();
            this.GroupBoxFileTransferStatus.ResumeLayout(false);
            this.GroupBoxFileTransferStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ListBoxPagePanel;
        private TextBox TextBoxSocketStatus;
        private Label EventsLogLabel;
        private Label ListBoxSelectedItemIndicesLabel;
        private TextBox TextBoxPortNum;
        private Button ButtonServerStop;
        private Button ButtonServerRun;
        private System.Windows.Forms.RichTextBox RichTextBoxLog;
        private GroupBox GroupBoxFileTransferStatus;
        private ProgressBar ProgressBarFileReceiving;
        private Button ButtonListClient;
        private Button BottonLogErase;
        private TextBox TextBoxFilePath;
        private Button ButtonChoosePath;
        private ComboBox ComboBoxLogLevel;
        private Button ButtonStopReceiving;
    }
}
