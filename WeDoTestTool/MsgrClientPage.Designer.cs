namespace Elegant.Ui.Samples.ControlsSample
{
    partial class MsgrClientPage
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
            this.components = new System.ComponentModel.Container();
            this.ListBoxPagePanel = new Elegant.Ui.Panel();
            this.ComboBoxLogLevel = new Elegant.Ui.ComboBox();
            this.BottonLogErase = new Elegant.Ui.Button();
            this.groupBox1 = new Elegant.Ui.GroupBox();
            this.label1 = new Elegant.Ui.Label();
            this.TextBoxClientId = new Elegant.Ui.TextBox();
            this.RadoiButtonDefinedHost = new Elegant.Ui.RadioButton();
            this.RadoiButtonLocalhost = new Elegant.Ui.RadioButton();
            this.TextBoxIP4 = new Elegant.Ui.TextBox();
            this.TextBoxIP3 = new Elegant.Ui.TextBox();
            this.TextBoxIP2 = new Elegant.Ui.TextBox();
            this.NumericUpDnRetryCnt = new Elegant.Ui.NumericUpDown();
            this.TextBoxIP1 = new Elegant.Ui.TextBox();
            this.NumericUpDnTimeout = new Elegant.Ui.NumericUpDown();
            this.TextBoxPortNum = new Elegant.Ui.TextBox();
            this.ButtonMsgrConnect = new Elegant.Ui.Button();
            this.ButtonMsgrClose = new Elegant.Ui.Button();
            this.GroupBoxMsgrContent = new Elegant.Ui.GroupBox();
            this.textBox1 = new Elegant.Ui.TextBox();
            this.TextBoxTargetClientId = new Elegant.Ui.TextBox();
            this.ProgressBarFileReceiving = new Elegant.Ui.ProgressBar();
            this.ButtonTextSend = new Elegant.Ui.Button();
            this.ButtonFileSendCancel = new Elegant.Ui.Button();
            this.TextBoxTextMessage = new Elegant.Ui.TextBox();
            this.ButtonFileSend = new Elegant.Ui.Button();
            this.TextBoxFilePath = new Elegant.Ui.TextBox();
            this.ButtonChooseFile = new Elegant.Ui.Button();
            this.RichTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.EventsLogLabel = new Elegant.Ui.Label();
            this.TextBoxSocketStatus = new Elegant.Ui.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ListBoxPagePanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDnRetryCnt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDnTimeout)).BeginInit();
            this.GroupBoxMsgrContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBoxPagePanel
            // 
            this.ListBoxPagePanel.Controls.Add(this.ComboBoxLogLevel);
            this.ListBoxPagePanel.Controls.Add(this.BottonLogErase);
            this.ListBoxPagePanel.Controls.Add(this.groupBox1);
            this.ListBoxPagePanel.Controls.Add(this.GroupBoxMsgrContent);
            this.ListBoxPagePanel.Controls.Add(this.RichTextBoxLog);
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
            this.ComboBoxLogLevel.Id = "d2586068-aff0-4047-b375-e047fd432b2f";
            this.ComboBoxLogLevel.Items.AddRange(new object[] {
            "error",
            "info",
            "debug"});
            this.ComboBoxLogLevel.KeyTip = "B";
            this.ComboBoxLogLevel.LabelAreaWidthTemplate = "log level setting:";
            this.ComboBoxLogLevel.LabelText = "log level setting:";
            this.ComboBoxLogLevel.Location = new System.Drawing.Point(579, 10);
            this.ComboBoxLogLevel.Name = "ComboBoxLogLevel";
            this.ComboBoxLogLevel.ScreenTip.Text = "Buttons";
            this.ComboBoxLogLevel.Size = new System.Drawing.Size(159, 20);
            this.ComboBoxLogLevel.TabIndex = 26;
            this.ComboBoxLogLevel.TextEditorWidth = 10;
            this.ComboBoxLogLevel.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLogLevel_SelectedIndexChanged);
            // 
            // BottonLogErase
            // 
            this.BottonLogErase.Id = "ea1a554e-7a8c-4824-884c-75c0d0adbccd";
            this.BottonLogErase.KeyTip = "C";
            this.BottonLogErase.Location = new System.Drawing.Point(348, 394);
            this.BottonLogErase.Name = "BottonLogErase";
            this.BottonLogErase.ScreenTip.Text = "Change the Icon";
            this.BottonLogErase.Size = new System.Drawing.Size(25, 18);
            this.BottonLogErase.TabIndex = 27;
            this.BottonLogErase.Text = "지움";
            this.BottonLogErase.Click += new System.EventHandler(this.BottonLogErase_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TextBoxClientId);
            this.groupBox1.Controls.Add(this.RadoiButtonDefinedHost);
            this.groupBox1.Controls.Add(this.RadoiButtonLocalhost);
            this.groupBox1.Controls.Add(this.TextBoxIP4);
            this.groupBox1.Controls.Add(this.TextBoxIP3);
            this.groupBox1.Controls.Add(this.TextBoxIP2);
            this.groupBox1.Controls.Add(this.NumericUpDnRetryCnt);
            this.groupBox1.Controls.Add(this.TextBoxIP1);
            this.groupBox1.Controls.Add(this.NumericUpDnTimeout);
            this.groupBox1.Controls.Add(this.TextBoxPortNum);
            this.groupBox1.Controls.Add(this.ButtonMsgrConnect);
            this.groupBox1.Controls.Add(this.ButtonMsgrClose);
            this.groupBox1.Id = "512a61d9-5c92-4a40-80d7-49033d0df6e5";
            this.groupBox1.Location = new System.Drawing.Point(386, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 146);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.Text = "접속정보";
            // 
            // label1
            // 
            this.label1.AutoSize = false;
            this.label1.Location = new System.Drawing.Point(15, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "Events Log";
            // 
            // TextBoxClientId
            // 
            this.TextBoxClientId.Id = "1732e67c-e7d2-49bd-9908-43cbc0311500";
            this.TextBoxClientId.LabelText = "Client Id";
            this.TextBoxClientId.Location = new System.Drawing.Point(14, 97);
            this.TextBoxClientId.Name = "TextBoxClientId";
            this.TextBoxClientId.ReadOnly = true;
            this.TextBoxClientId.Size = new System.Drawing.Size(91, 20);
            this.TextBoxClientId.TabIndex = 25;
            this.TextBoxClientId.Text = "001";
            this.TextBoxClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxClientId.TextEditorWidth = 36;
            // 
            // RadoiButtonDefinedHost
            // 
            this.RadoiButtonDefinedHost.Id = "10191106-6628-47f6-a24e-6f781a931ba6";
            this.RadoiButtonDefinedHost.Location = new System.Drawing.Point(95, 15);
            this.RadoiButtonDefinedHost.Name = "RadoiButtonDefinedHost";
            this.RadoiButtonDefinedHost.RadioGroupName = "RadioGroupServerInfo";
            this.RadoiButtonDefinedHost.Size = new System.Drawing.Size(104, 24);
            this.RadoiButtonDefinedHost.TabIndex = 24;
            this.RadoiButtonDefinedHost.Text = "서버지정";
            // 
            // RadoiButtonLocalhost
            // 
            this.RadoiButtonLocalhost.Checked = true;
            this.RadoiButtonLocalhost.Id = "fdb9bd48-b383-401f-b016-afd65b452dfa";
            this.RadoiButtonLocalhost.Location = new System.Drawing.Point(13, 15);
            this.RadoiButtonLocalhost.Name = "RadoiButtonLocalhost";
            this.RadoiButtonLocalhost.RadioGroupName = "RadioGroupServerInfo";
            this.RadoiButtonLocalhost.Size = new System.Drawing.Size(104, 24);
            this.RadoiButtonLocalhost.TabIndex = 23;
            this.RadoiButtonLocalhost.Text = "Localhost";
            // 
            // TextBoxIP4
            // 
            this.TextBoxIP4.Id = "5b9f6060-3291-4738-8cd4-ed9c907c774c";
            this.TextBoxIP4.KeyTip = "T";
            this.TextBoxIP4.LabelAreaWidthTemplate = "";
            this.TextBoxIP4.Location = new System.Drawing.Point(201, 44);
            this.TextBoxIP4.Name = "TextBoxIP4";
            this.TextBoxIP4.ScreenTip.Text = "Balloon tip title";
            this.TextBoxIP4.Size = new System.Drawing.Size(39, 20);
            this.TextBoxIP4.TabIndex = 22;
            this.TextBoxIP4.Text = "37";
            this.TextBoxIP4.TextEditorWidth = 33;
            // 
            // TextBoxIP3
            // 
            this.TextBoxIP3.Id = "1807b34e-f94b-4779-afa8-74797ded722e";
            this.TextBoxIP3.KeyTip = "T";
            this.TextBoxIP3.LabelAreaWidthTemplate = "";
            this.TextBoxIP3.Location = new System.Drawing.Point(160, 44);
            this.TextBoxIP3.Name = "TextBoxIP3";
            this.TextBoxIP3.ScreenTip.Text = "Balloon tip title";
            this.TextBoxIP3.Size = new System.Drawing.Size(39, 20);
            this.TextBoxIP3.TabIndex = 21;
            this.TextBoxIP3.Text = "0";
            this.TextBoxIP3.TextEditorWidth = 33;
            // 
            // TextBoxIP2
            // 
            this.TextBoxIP2.Id = "c53fcfa6-9f43-447a-87ec-dd136c02f6fc";
            this.TextBoxIP2.KeyTip = "T";
            this.TextBoxIP2.LabelAreaWidthTemplate = "";
            this.TextBoxIP2.Location = new System.Drawing.Point(119, 44);
            this.TextBoxIP2.Name = "TextBoxIP2";
            this.TextBoxIP2.ScreenTip.Text = "Balloon tip title";
            this.TextBoxIP2.Size = new System.Drawing.Size(39, 20);
            this.TextBoxIP2.TabIndex = 20;
            this.TextBoxIP2.Text = "168";
            this.TextBoxIP2.TextEditorWidth = 33;
            // 
            // NumericUpDnRetryCnt
            // 
            this.NumericUpDnRetryCnt.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.NumericUpDnRetryCnt.Id = "83a5f204-dfc0-4cbd-b92d-d4499c272b2e";
            this.NumericUpDnRetryCnt.KeyTip = "M";
            this.NumericUpDnRetryCnt.LabelAreaWidthTemplate = "";
            this.NumericUpDnRetryCnt.LabelText = "Retry Cnt";
            this.NumericUpDnRetryCnt.Location = new System.Drawing.Point(190, 69);
            this.NumericUpDnRetryCnt.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NumericUpDnRetryCnt.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumericUpDnRetryCnt.Name = "NumericUpDnRetryCnt";
            this.NumericUpDnRetryCnt.ScreenTip.Text = "The time period, in milliseconds, the balloon tip should display";
            this.NumericUpDnRetryCnt.Size = new System.Drawing.Size(144, 20);
            this.NumericUpDnRetryCnt.TabIndex = 19;
            this.NumericUpDnRetryCnt.TextEditorWidth = 64;
            this.NumericUpDnRetryCnt.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // TextBoxIP1
            // 
            this.TextBoxIP1.Id = "ea91d6ee-bf53-4bcb-9bf5-0470fe372990";
            this.TextBoxIP1.KeyTip = "T";
            this.TextBoxIP1.LabelAreaWidthTemplate = "Icon";
            this.TextBoxIP1.LabelText = "IP Address";
            this.TextBoxIP1.Location = new System.Drawing.Point(14, 44);
            this.TextBoxIP1.Name = "TextBoxIP1";
            this.TextBoxIP1.ScreenTip.Text = "Balloon tip title";
            this.TextBoxIP1.Size = new System.Drawing.Size(103, 20);
            this.TextBoxIP1.TabIndex = 0;
            this.TextBoxIP1.Text = "192";
            this.TextBoxIP1.TextEditorWidth = 32;
            // 
            // NumericUpDnTimeout
            // 
            this.NumericUpDnTimeout.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.NumericUpDnTimeout.Id = "031ef2bd-8c6a-4cc4-9bd4-fe9c62ed0a7b";
            this.NumericUpDnTimeout.Increment = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.NumericUpDnTimeout.KeyTip = "M";
            this.NumericUpDnTimeout.LabelAreaWidthTemplate = "";
            this.NumericUpDnTimeout.LabelText = "Timeout, ms";
            this.NumericUpDnTimeout.Location = new System.Drawing.Point(14, 69);
            this.NumericUpDnTimeout.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.NumericUpDnTimeout.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumericUpDnTimeout.Name = "NumericUpDnTimeout";
            this.NumericUpDnTimeout.ScreenTip.Text = "The time period, in milliseconds, the balloon tip should display";
            this.NumericUpDnTimeout.Size = new System.Drawing.Size(144, 20);
            this.NumericUpDnTimeout.TabIndex = 3;
            this.NumericUpDnTimeout.TextEditorWidth = 64;
            this.NumericUpDnTimeout.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // TextBoxPortNum
            // 
            this.TextBoxPortNum.Id = "82132683-2920-484c-ad4f-72a108048a4a";
            this.TextBoxPortNum.LabelText = "Port";
            this.TextBoxPortNum.Location = new System.Drawing.Point(278, 44);
            this.TextBoxPortNum.Name = "TextBoxPortNum";
            this.TextBoxPortNum.ReadOnly = true;
            this.TextBoxPortNum.Size = new System.Drawing.Size(55, 20);
            this.TextBoxPortNum.TabIndex = 15;
            this.TextBoxPortNum.Text = "1100";
            this.TextBoxPortNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxPortNum.TextEditorWidth = 49;
            // 
            // ButtonMsgrConnect
            // 
            this.ButtonMsgrConnect.Id = "e6ede735-44ee-49cc-b954-4c8d52837987";
            this.ButtonMsgrConnect.Location = new System.Drawing.Point(213, 117);
            this.ButtonMsgrConnect.Name = "ButtonMsgrConnect";
            this.ButtonMsgrConnect.Size = new System.Drawing.Size(58, 18);
            this.ButtonMsgrConnect.TabIndex = 17;
            this.ButtonMsgrConnect.Text = "접속";
            this.ButtonMsgrConnect.Click += new System.EventHandler(this.ButtonMsgrConnect_Click);
            // 
            // ButtonMsgrClose
            // 
            this.ButtonMsgrClose.Id = "3ed6cc83-66d4-4123-8944-1988398ba33d";
            this.ButtonMsgrClose.Location = new System.Drawing.Point(276, 117);
            this.ButtonMsgrClose.Name = "ButtonMsgrClose";
            this.ButtonMsgrClose.Size = new System.Drawing.Size(58, 18);
            this.ButtonMsgrClose.TabIndex = 18;
            this.ButtonMsgrClose.Text = "종료";
            this.ButtonMsgrClose.Click += new System.EventHandler(this.ButtonMsgrClose_Click);
            // 
            // GroupBoxMsgrContent
            // 
            this.GroupBoxMsgrContent.Controls.Add(this.textBox1);
            this.GroupBoxMsgrContent.Controls.Add(this.TextBoxTargetClientId);
            this.GroupBoxMsgrContent.Controls.Add(this.ProgressBarFileReceiving);
            this.GroupBoxMsgrContent.Controls.Add(this.ButtonTextSend);
            this.GroupBoxMsgrContent.Controls.Add(this.ButtonFileSendCancel);
            this.GroupBoxMsgrContent.Controls.Add(this.TextBoxTextMessage);
            this.GroupBoxMsgrContent.Controls.Add(this.ButtonFileSend);
            this.GroupBoxMsgrContent.Controls.Add(this.TextBoxFilePath);
            this.GroupBoxMsgrContent.Controls.Add(this.ButtonChooseFile);
            this.GroupBoxMsgrContent.Id = "93318ddf-692d-4d6a-b4db-5c515fb2dae4";
            this.GroupBoxMsgrContent.Location = new System.Drawing.Point(386, 265);
            this.GroupBoxMsgrContent.Name = "GroupBoxMsgrContent";
            this.GroupBoxMsgrContent.Size = new System.Drawing.Size(352, 136);
            this.GroupBoxMsgrContent.TabIndex = 24;
            this.GroupBoxMsgrContent.Text = "전송내용";
            // 
            // textBox1
            // 
            this.textBox1.Id = "807d4090-8202-4716-a378-86704c7d3ee0";
            this.textBox1.KeyTip = "T";
            this.textBox1.LabelAreaWidthTemplate = "";
            this.textBox1.Location = new System.Drawing.Point(14, 90);
            this.textBox1.Name = "textBox1";
            this.textBox1.ScreenTip.Text = "Balloon tip title";
            this.textBox1.Size = new System.Drawing.Size(185, 20);
            this.textBox1.TabIndex = 27;
            this.textBox1.TextEditorWidth = 179;
            this.textBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox1_KeyDown);
            // 
            // TextBoxTargetClientId
            // 
            this.TextBoxTargetClientId.Id = "f52c7f3d-ccad-4939-ada0-48f641c89263";
            this.TextBoxTargetClientId.LabelText = "Target Client Id";
            this.TextBoxTargetClientId.Location = new System.Drawing.Point(15, 40);
            this.TextBoxTargetClientId.Name = "TextBoxTargetClientId";
            this.TextBoxTargetClientId.ReadOnly = true;
            this.TextBoxTargetClientId.Size = new System.Drawing.Size(119, 20);
            this.TextBoxTargetClientId.TabIndex = 26;
            this.TextBoxTargetClientId.Text = "001";
            this.TextBoxTargetClientId.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TextBoxTargetClientId.TextEditorWidth = 24;
            // 
            // ProgressBarFileReceiving
            // 
            this.ProgressBarFileReceiving.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBarFileReceiving.DesiredWidth = 320;
            this.ProgressBarFileReceiving.Id = "35ce4655-3782-41df-b56f-e108f7aa00a0";
            this.ProgressBarFileReceiving.Location = new System.Drawing.Point(15, 115);
            this.ProgressBarFileReceiving.Name = "ProgressBarFileReceiving";
            this.ProgressBarFileReceiving.ScreenTip.Text = "Progress bar";
            this.ProgressBarFileReceiving.Size = new System.Drawing.Size(320, 15);
            this.ProgressBarFileReceiving.TabIndex = 12;
            this.ProgressBarFileReceiving.TabStop = false;
            this.ProgressBarFileReceiving.Text = "ProgressBarFileReceiving";
            this.ProgressBarFileReceiving.Value = 35;
            // 
            // ButtonTextSend
            // 
            this.ButtonTextSend.Id = "72057653-619d-4705-90c0-1920ee55f638";
            this.ButtonTextSend.KeyTip = "S";
            this.ButtonTextSend.Location = new System.Drawing.Point(284, 40);
            this.ButtonTextSend.Name = "ButtonTextSend";
            this.ButtonTextSend.ScreenTip.Text = "Show balloon tip";
            this.ButtonTextSend.Size = new System.Drawing.Size(51, 20);
            this.ButtonTextSend.TabIndex = 25;
            this.ButtonTextSend.Text = "보내기";
            this.ButtonTextSend.Click += new System.EventHandler(this.ButtonTextSend_Click);
            // 
            // ButtonFileSendCancel
            // 
            this.ButtonFileSendCancel.Id = "6442b6ca-d4d8-4120-9920-7b4ddbb0f5d7";
            this.ButtonFileSendCancel.KeyTip = "S";
            this.ButtonFileSendCancel.Location = new System.Drawing.Point(285, 90);
            this.ButtonFileSendCancel.Name = "ButtonFileSendCancel";
            this.ButtonFileSendCancel.ScreenTip.Text = "Show balloon tip";
            this.ButtonFileSendCancel.Size = new System.Drawing.Size(50, 18);
            this.ButtonFileSendCancel.TabIndex = 24;
            this.ButtonFileSendCancel.Text = "전송취소";
            // 
            // TextBoxTextMessage
            // 
            this.TextBoxTextMessage.Id = "6aa65709-879c-44b8-941a-c522d836b567";
            this.TextBoxTextMessage.KeyTip = "T";
            this.TextBoxTextMessage.LabelAreaWidthTemplate = "";
            this.TextBoxTextMessage.Location = new System.Drawing.Point(15, 17);
            this.TextBoxTextMessage.Name = "TextBoxTextMessage";
            this.TextBoxTextMessage.ScreenTip.Text = "Balloon tip title";
            this.TextBoxTextMessage.Size = new System.Drawing.Size(320, 20);
            this.TextBoxTextMessage.TabIndex = 0;
            this.TextBoxTextMessage.TextEditorWidth = 314;
            // 
            // ButtonFileSend
            // 
            this.ButtonFileSend.Id = "986da935-901b-4926-9419-1cb07d0364a8";
            this.ButtonFileSend.KeyTip = "S";
            this.ButtonFileSend.Location = new System.Drawing.Point(231, 90);
            this.ButtonFileSend.Name = "ButtonFileSend";
            this.ButtonFileSend.ScreenTip.Text = "Show balloon tip";
            this.ButtonFileSend.Size = new System.Drawing.Size(50, 18);
            this.ButtonFileSend.TabIndex = 4;
            this.ButtonFileSend.Text = "파일전송";
            this.ButtonFileSend.Click += new System.EventHandler(this.ButtonFileSend_Click);
            // 
            // TextBoxFilePath
            // 
            this.TextBoxFilePath.BannerText = "전송 파일 경로";
            this.TextBoxFilePath.Id = "96c8cd63-08fe-49d5-8815-747df28406d2";
            this.TextBoxFilePath.KeyTip = "I";
            this.TextBoxFilePath.LabelText = "File: ";
            this.TextBoxFilePath.Location = new System.Drawing.Point(13, 65);
            this.TextBoxFilePath.Name = "TextBoxFilePath";
            this.TextBoxFilePath.ScreenTip.Text = "Icon path";
            this.TextBoxFilePath.Size = new System.Drawing.Size(296, 20);
            this.TextBoxFilePath.TabIndex = 22;
            this.TextBoxFilePath.TextEditorWidth = 259;
            // 
            // ButtonChooseFile
            // 
            this.ButtonChooseFile.Id = "5e7e6795-24ae-4eee-9686-4a4cc19715ab";
            this.ButtonChooseFile.KeyTip = "C";
            this.ButtonChooseFile.Location = new System.Drawing.Point(310, 64);
            this.ButtonChooseFile.Name = "ButtonChooseFile";
            this.ButtonChooseFile.ScreenTip.Text = "Change the Icon";
            this.ButtonChooseFile.Size = new System.Drawing.Size(25, 21);
            this.ButtonChooseFile.TabIndex = 23;
            this.ButtonChooseFile.Text = "...";
            this.ButtonChooseFile.Click += new System.EventHandler(this.ChooseIconButton_Click);
            // 
            // RichTextBoxLog
            // 
            this.RichTextBoxLog.BackColor = System.Drawing.SystemColors.InfoText;
            this.RichTextBoxLog.ForeColor = System.Drawing.Color.Yellow;
            this.RichTextBoxLog.Location = new System.Drawing.Point(15, 13);
            this.RichTextBoxLog.Name = "RichTextBoxLog";
            this.RichTextBoxLog.Size = new System.Drawing.Size(360, 382);
            this.RichTextBoxLog.TabIndex = 19;
            this.RichTextBoxLog.Text = "";
            // 
            // EventsLogLabel
            // 
            this.EventsLogLabel.Location = new System.Drawing.Point(386, 16);
            this.EventsLogLabel.Name = "EventsLogLabel";
            this.EventsLogLabel.Size = new System.Drawing.Size(73, 12);
            this.EventsLogLabel.TabIndex = 4;
            this.EventsLogLabel.Text = "Events Log";
            // 
            // TextBoxSocketStatus
            // 
            this.TextBoxSocketStatus.Id = "24860320-fb06-4dd3-9a77-6cc24c507ff5";
            this.TextBoxSocketStatus.Location = new System.Drawing.Point(386, 30);
            this.TextBoxSocketStatus.Multiline = true;
            this.TextBoxSocketStatus.Name = "TextBoxSocketStatus";
            this.TextBoxSocketStatus.ReadOnly = true;
            this.TextBoxSocketStatus.Size = new System.Drawing.Size(352, 75);
            this.TextBoxSocketStatus.TabIndex = 2;
            this.TextBoxSocketStatus.TextEditorWidth = 346;
            // 
            // MsgrClientPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListBoxPagePanel);
            this.Name = "MsgrClientPage";
            this.Size = new System.Drawing.Size(761, 415);
            this.ListBoxPagePanel.ResumeLayout(false);
            this.ListBoxPagePanel.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDnRetryCnt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumericUpDnTimeout)).EndInit();
            this.GroupBoxMsgrContent.ResumeLayout(false);
            this.GroupBoxMsgrContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ListBoxPagePanel;
        private TextBox TextBoxSocketStatus;
        private Label EventsLogLabel;
        private System.Windows.Forms.RichTextBox RichTextBoxLog;
        private Button ButtonMsgrClose;
        private Button ButtonMsgrConnect;
        private TextBox TextBoxPortNum;
        private TextBox TextBoxFilePath;
        private Button ButtonChooseFile;
        private GroupBox groupBox1;
        private TextBox TextBoxIP1;
        private NumericUpDown NumericUpDnTimeout;
        private GroupBox GroupBoxMsgrContent;
        private TextBox TextBoxTextMessage;
        private Button ButtonFileSend;
        private Button ButtonFileSendCancel;
        private Button ButtonTextSend;
        private NumericUpDown NumericUpDnRetryCnt;
        private TextBox TextBoxIP4;
        private TextBox TextBoxIP3;
        private TextBox TextBoxIP2;
        private RadioButton RadoiButtonDefinedHost;
        private RadioButton RadoiButtonLocalhost;
        private ProgressBar ProgressBarFileReceiving;
        private TextBox TextBoxClientId;
        private TextBox TextBoxTargetClientId;
        private Button BottonLogErase;
        private ComboBox ComboBoxLogLevel;
        private TextBox textBox1;
        private Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
