namespace Elegant.Ui.Samples.ControlsSample
{
    partial class NotifyIconPage
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
                _animatedIconTimer.Stop();
                _animatedIconTimer.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NotifyIconPage));
            this.NotifyIconPagePanel = new Elegant.Ui.Panel();
            this.AnimatedIconCheckBox = new Elegant.Ui.CheckBox();
            this.IconPathTextBox = new Elegant.Ui.TextBox();
            this.EventsGroupBox = new Elegant.Ui.GroupBox();
            this.MouseDownEventControl = new Elegant.Ui.Samples.ControlsSample.EventControl();
            this.ListOfEventsLabel = new Elegant.Ui.Label();
            this.MouseIconEventsTextBox = new Elegant.Ui.TextBox();
            this.MouseEnterEventControl = new Elegant.Ui.Samples.ControlsSample.EventControl();
            this.MouseDownEventLabel = new Elegant.Ui.Label();
            this.MouseMoveEventControl = new Elegant.Ui.Samples.ControlsSample.EventControl();
            this.MouseMoveEventLabel = new Elegant.Ui.Label();
            this.MouseLeaveEventLabel = new Elegant.Ui.Label();
            this.MouseLeaveEventControl = new Elegant.Ui.Samples.ControlsSample.EventControl();
            this.MouseUpEventLabel = new Elegant.Ui.Label();
            this.MouseUpEventControl = new Elegant.Ui.Samples.ControlsSample.EventControl();
            this.MouseEnterEventLabel = new Elegant.Ui.Label();
            this.BalloonTipGroupBox = new Elegant.Ui.GroupBox();
            this.BalloonTipTitleTextBox = new Elegant.Ui.TextBox();
            this.BalloonTipTimoutUpDown = new Elegant.Ui.NumericUpDown();
            this.BalloonTipIconComboBox = new Elegant.Ui.ComboBox();
            this.ShowBalloonTipButton = new Elegant.Ui.Button();
            this.BalloonTipTextTextBox = new Elegant.Ui.TextBox();
            this.ChooseIconButton = new Elegant.Ui.Button();
            this.ToolTipTextTextBox = new Elegant.Ui.TextBox();
            this.ControlsSampleNotifyIcon = new Elegant.Ui.NotifyIcon(this.components);
            this.NotifyIconContextMenu = new Elegant.Ui.ContextMenu();
            this.NotifyIconContextMenuButton1 = new Elegant.Ui.Button();
            this.NotifyIconContextMenuButton2 = new Elegant.Ui.Button();
            this.NotifyIconContextMenuSeparator = new Elegant.Ui.Separator();
            this.NotifyIconContextMenuGallery = new Elegant.Ui.Gallery();
            this.NotifyIconContextMenuDropDown1 = new Elegant.Ui.DropDown();
            this.popupMenu1 = new Elegant.Ui.PopupMenu();
            this.NotifyIconContextMenuButton4 = new Elegant.Ui.Button();
            this.NotifyIconContextMenuButton5 = new Elegant.Ui.Button();
            this.NotifyIconContextMenuButton3 = new Elegant.Ui.Button();
            this.contextMenuExtenderProvider1 = new Elegant.Ui.ContextMenuExtenderProvider();
            this.NotifyIconPagePanel.SuspendLayout();
            this.EventsGroupBox.SuspendLayout();
            this.BalloonTipGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalloonTipTimoutUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotifyIconContextMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotifyIconContextMenuGallery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotifyIconContextMenuGallery.Popup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // NotifyIconPagePanel
            // 
            this.NotifyIconPagePanel.Controls.Add(this.AnimatedIconCheckBox);
            this.NotifyIconPagePanel.Controls.Add(this.IconPathTextBox);
            this.NotifyIconPagePanel.Controls.Add(this.EventsGroupBox);
            this.NotifyIconPagePanel.Controls.Add(this.BalloonTipGroupBox);
            this.NotifyIconPagePanel.Controls.Add(this.ChooseIconButton);
            this.NotifyIconPagePanel.Controls.Add(this.ToolTipTextTextBox);
            this.NotifyIconPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NotifyIconPagePanel.Location = new System.Drawing.Point(0, 0);
            this.NotifyIconPagePanel.Name = "NotifyIconPagePanel";
            this.NotifyIconPagePanel.Size = new System.Drawing.Size(655, 507);
            this.NotifyIconPagePanel.TabIndex = 0;
            this.NotifyIconPagePanel.Text = "panel1";
            // 
            // AnimatedIconCheckBox
            // 
            this.AnimatedIconCheckBox.Id = "a084a2e3-b1c4-43d8-9dd3-027332c0cff7";
            this.AnimatedIconCheckBox.Location = new System.Drawing.Point(15, 315);
            this.AnimatedIconCheckBox.Name = "AnimatedIconCheckBox";
            this.AnimatedIconCheckBox.ScreenTip.Text = "Turn on/off Icon animation";
            this.AnimatedIconCheckBox.Size = new System.Drawing.Size(156, 23);
            this.AnimatedIconCheckBox.TabIndex = 5;
            this.AnimatedIconCheckBox.Text = "Turn on/off Icon animation";
            this.AnimatedIconCheckBox.Visible = false;
            this.AnimatedIconCheckBox.CheckedChanged += new System.EventHandler(this.AnimatedIconCheckBox_CheckedChanged);
            // 
            // IconPathTextBox
            // 
            this.IconPathTextBox.BannerText = "Icon File Path";
            this.IconPathTextBox.Id = "4b7a6368-dcbd-4e57-abd2-0bd299094e3f";
            this.IconPathTextBox.KeyTip = "I";
            this.IconPathTextBox.LabelText = "Icon: ";
            this.IconPathTextBox.Location = new System.Drawing.Point(15, 19);
            this.IconPathTextBox.Name = "IconPathTextBox";
            this.IconPathTextBox.ScreenTip.Text = "Icon path";
            this.IconPathTextBox.Size = new System.Drawing.Size(285, 21);
            this.IconPathTextBox.TabIndex = 0;
            this.IconPathTextBox.TextEditorWidth = 249;
            this.IconPathTextBox.TextChanged += new System.EventHandler(this.IconPathTextBox_TextChanged);
            // 
            // EventsGroupBox
            // 
            this.EventsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EventsGroupBox.Controls.Add(this.MouseDownEventControl);
            this.EventsGroupBox.Controls.Add(this.ListOfEventsLabel);
            this.EventsGroupBox.Controls.Add(this.MouseIconEventsTextBox);
            this.EventsGroupBox.Controls.Add(this.MouseEnterEventControl);
            this.EventsGroupBox.Controls.Add(this.MouseDownEventLabel);
            this.EventsGroupBox.Controls.Add(this.MouseMoveEventControl);
            this.EventsGroupBox.Controls.Add(this.MouseMoveEventLabel);
            this.EventsGroupBox.Controls.Add(this.MouseLeaveEventLabel);
            this.EventsGroupBox.Controls.Add(this.MouseLeaveEventControl);
            this.EventsGroupBox.Controls.Add(this.MouseUpEventLabel);
            this.EventsGroupBox.Controls.Add(this.MouseUpEventControl);
            this.EventsGroupBox.Controls.Add(this.MouseEnterEventLabel);
            this.EventsGroupBox.Id = "0b1f715d-ef8d-4521-a0f9-c99d683a691f";
            this.EventsGroupBox.Location = new System.Drawing.Point(350, 12);
            this.EventsGroupBox.Name = "EventsGroupBox";
            this.EventsGroupBox.Size = new System.Drawing.Size(292, 293);
            this.EventsGroupBox.TabIndex = 4;
            this.EventsGroupBox.Text = "Events";
            // 
            // MouseDownEventControl
            // 
            this.MouseDownEventControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseDownEventControl.Id = "9c6e4952-8d89-41ea-8189-019585de3f30";
            this.MouseDownEventControl.Location = new System.Drawing.Point(12, 104);
            this.MouseDownEventControl.MaximumSize = new System.Drawing.Size(27, 27);
            this.MouseDownEventControl.MinimumSize = new System.Drawing.Size(27, 27);
            this.MouseDownEventControl.Name = "MouseDownEventControl";
            this.MouseDownEventControl.ScreenTip.Text = "Indicates when MouseDown event occurs";
            this.MouseDownEventControl.Size = new System.Drawing.Size(27, 27);
            this.MouseDownEventControl.TabIndex = 6;
            this.MouseDownEventControl.TabStop = false;
            // 
            // ListOfEventsLabel
            // 
            this.ListOfEventsLabel.Location = new System.Drawing.Point(12, 161);
            this.ListOfEventsLabel.Name = "ListOfEventsLabel";
            this.ListOfEventsLabel.Size = new System.Drawing.Size(53, 15);
            this.ListOfEventsLabel.TabIndex = 10;
            this.ListOfEventsLabel.Text = "Log:";
            // 
            // MouseIconEventsTextBox
            // 
            this.MouseIconEventsTextBox.Id = "6297e2da-4249-4e1b-bd2a-8d95983673c0";
            this.MouseIconEventsTextBox.Location = new System.Drawing.Point(12, 176);
            this.MouseIconEventsTextBox.Multiline = true;
            this.MouseIconEventsTextBox.Name = "MouseIconEventsTextBox";
            this.MouseIconEventsTextBox.ReadOnly = true;
            this.MouseIconEventsTextBox.ScreenTip.Text = "Events log";
            this.MouseIconEventsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MouseIconEventsTextBox.Size = new System.Drawing.Size(267, 95);
            this.MouseIconEventsTextBox.TabIndex = 11;
            this.MouseIconEventsTextBox.TabStop = false;
            this.MouseIconEventsTextBox.TextEditorWidth = 263;
            // 
            // MouseEnterEventControl
            // 
            this.MouseEnterEventControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseEnterEventControl.Id = "ff0f0afd-2983-4ff7-ad3e-bb473235b89f";
            this.MouseEnterEventControl.Location = new System.Drawing.Point(12, 22);
            this.MouseEnterEventControl.MaximumSize = new System.Drawing.Size(27, 27);
            this.MouseEnterEventControl.MinimumSize = new System.Drawing.Size(27, 27);
            this.MouseEnterEventControl.Name = "MouseEnterEventControl";
            this.MouseEnterEventControl.ScreenTip.Text = "Indicates when MouseEnter event occurs";
            this.MouseEnterEventControl.Size = new System.Drawing.Size(27, 27);
            this.MouseEnterEventControl.TabIndex = 0;
            this.MouseEnterEventControl.TabStop = false;
            // 
            // MouseDownEventLabel
            // 
            this.MouseDownEventLabel.Location = new System.Drawing.Point(48, 112);
            this.MouseDownEventLabel.Name = "MouseDownEventLabel";
            this.MouseDownEventLabel.ScreenTip.Text = "Indicates when MouseDown event occurs";
            this.MouseDownEventLabel.Size = new System.Drawing.Size(91, 13);
            this.MouseDownEventLabel.TabIndex = 7;
            this.MouseDownEventLabel.Text = "Mouse down";
            // 
            // MouseMoveEventControl
            // 
            this.MouseMoveEventControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseMoveEventControl.Id = "6827ac73-4ce0-401e-b02e-5f82a1414d56";
            this.MouseMoveEventControl.Location = new System.Drawing.Point(12, 49);
            this.MouseMoveEventControl.MaximumSize = new System.Drawing.Size(27, 27);
            this.MouseMoveEventControl.MinimumSize = new System.Drawing.Size(27, 27);
            this.MouseMoveEventControl.Name = "MouseMoveEventControl";
            this.MouseMoveEventControl.ScreenTip.Text = "Indicates when MouseMove event occurs";
            this.MouseMoveEventControl.Size = new System.Drawing.Size(27, 27);
            this.MouseMoveEventControl.TabIndex = 2;
            this.MouseMoveEventControl.TabStop = false;
            // 
            // MouseMoveEventLabel
            // 
            this.MouseMoveEventLabel.Location = new System.Drawing.Point(48, 57);
            this.MouseMoveEventLabel.Name = "MouseMoveEventLabel";
            this.MouseMoveEventLabel.ScreenTip.Text = "Indicates when MouseMove event occurs";
            this.MouseMoveEventLabel.Size = new System.Drawing.Size(91, 13);
            this.MouseMoveEventLabel.TabIndex = 3;
            this.MouseMoveEventLabel.Text = "Mouse move";
            // 
            // MouseLeaveEventLabel
            // 
            this.MouseLeaveEventLabel.Location = new System.Drawing.Point(48, 84);
            this.MouseLeaveEventLabel.Name = "MouseLeaveEventLabel";
            this.MouseLeaveEventLabel.ScreenTip.Text = "Indicates when MouseLeave event occurs";
            this.MouseLeaveEventLabel.Size = new System.Drawing.Size(91, 13);
            this.MouseLeaveEventLabel.TabIndex = 5;
            this.MouseLeaveEventLabel.Text = "Mouse leave";
            // 
            // MouseLeaveEventControl
            // 
            this.MouseLeaveEventControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseLeaveEventControl.Id = "903fb91f-2a2a-46ba-ab10-9a91f80b940a";
            this.MouseLeaveEventControl.Location = new System.Drawing.Point(12, 76);
            this.MouseLeaveEventControl.MaximumSize = new System.Drawing.Size(27, 27);
            this.MouseLeaveEventControl.MinimumSize = new System.Drawing.Size(27, 27);
            this.MouseLeaveEventControl.Name = "MouseLeaveEventControl";
            this.MouseLeaveEventControl.ScreenTip.Text = "Indicates when MouseLeave event occurs";
            this.MouseLeaveEventControl.Size = new System.Drawing.Size(27, 27);
            this.MouseLeaveEventControl.TabIndex = 4;
            this.MouseLeaveEventControl.TabStop = false;
            // 
            // MouseUpEventLabel
            // 
            this.MouseUpEventLabel.Location = new System.Drawing.Point(48, 139);
            this.MouseUpEventLabel.Name = "MouseUpEventLabel";
            this.MouseUpEventLabel.ScreenTip.Text = "Indicates when MouseUp event occurs";
            this.MouseUpEventLabel.Size = new System.Drawing.Size(91, 13);
            this.MouseUpEventLabel.TabIndex = 9;
            this.MouseUpEventLabel.Text = "Mouse up";
            // 
            // MouseUpEventControl
            // 
            this.MouseUpEventControl.BackColor = System.Drawing.Color.Transparent;
            this.MouseUpEventControl.Id = "f279a53c-7322-45b4-86c9-ad96a318ad95";
            this.MouseUpEventControl.Location = new System.Drawing.Point(12, 131);
            this.MouseUpEventControl.MaximumSize = new System.Drawing.Size(27, 27);
            this.MouseUpEventControl.MinimumSize = new System.Drawing.Size(27, 27);
            this.MouseUpEventControl.Name = "MouseUpEventControl";
            this.MouseUpEventControl.ScreenTip.Text = "Indicates when MouseUp event occurs";
            this.MouseUpEventControl.Size = new System.Drawing.Size(27, 27);
            this.MouseUpEventControl.TabIndex = 8;
            this.MouseUpEventControl.TabStop = false;
            // 
            // MouseEnterEventLabel
            // 
            this.MouseEnterEventLabel.Location = new System.Drawing.Point(48, 30);
            this.MouseEnterEventLabel.Name = "MouseEnterEventLabel";
            this.MouseEnterEventLabel.ScreenTip.Text = "Indicates when MouseEnter event occurs";
            this.MouseEnterEventLabel.Size = new System.Drawing.Size(89, 13);
            this.MouseEnterEventLabel.TabIndex = 1;
            this.MouseEnterEventLabel.Text = "Mouse enter";
            // 
            // BalloonTipGroupBox
            // 
            this.BalloonTipGroupBox.Controls.Add(this.BalloonTipTitleTextBox);
            this.BalloonTipGroupBox.Controls.Add(this.BalloonTipTimoutUpDown);
            this.BalloonTipGroupBox.Controls.Add(this.BalloonTipIconComboBox);
            this.BalloonTipGroupBox.Controls.Add(this.ShowBalloonTipButton);
            this.BalloonTipGroupBox.Controls.Add(this.BalloonTipTextTextBox);
            this.BalloonTipGroupBox.Id = "1f5f20b6-1dfc-4ac6-bd4c-e97480295827";
            this.BalloonTipGroupBox.Location = new System.Drawing.Point(15, 101);
            this.BalloonTipGroupBox.Name = "BalloonTipGroupBox";
            this.BalloonTipGroupBox.Size = new System.Drawing.Size(327, 204);
            this.BalloonTipGroupBox.TabIndex = 3;
            this.BalloonTipGroupBox.Text = "Balloon tip";
            // 
            // BalloonTipTitleTextBox
            // 
            this.BalloonTipTitleTextBox.Id = "0cd4d5e0-9764-43eb-b785-81e65fc7424a";
            this.BalloonTipTitleTextBox.KeyTip = "T";
            this.BalloonTipTitleTextBox.LabelAreaWidthTemplate = "Icon";
            this.BalloonTipTitleTextBox.LabelText = "Title";
            this.BalloonTipTitleTextBox.Location = new System.Drawing.Point(12, 29);
            this.BalloonTipTitleTextBox.Name = "BalloonTipTitleTextBox";
            this.BalloonTipTitleTextBox.ScreenTip.Text = "Balloon tip title";
            this.BalloonTipTitleTextBox.Size = new System.Drawing.Size(303, 21);
            this.BalloonTipTitleTextBox.TabIndex = 0;
            this.BalloonTipTitleTextBox.Text = "Elegant UI";
            this.BalloonTipTitleTextBox.TextEditorWidth = 273;
            // 
            // BalloonTipTimoutUpDown
            // 
            this.BalloonTipTimoutUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.BalloonTipTimoutUpDown.Id = "9d9c9ce4-1fe7-43ca-9f67-36c72f01634f";
            this.BalloonTipTimoutUpDown.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.BalloonTipTimoutUpDown.KeyTip = "M";
            this.BalloonTipTimoutUpDown.LabelAreaWidthTemplate = "";
            this.BalloonTipTimoutUpDown.LabelText = "Timeout, ms";
            this.BalloonTipTimoutUpDown.Location = new System.Drawing.Point(12, 158);
            this.BalloonTipTimoutUpDown.Maximum = new decimal(new int[] {
            20000,
            0,
            0,
            0});
            this.BalloonTipTimoutUpDown.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.BalloonTipTimoutUpDown.Name = "BalloonTipTimoutUpDown";
            this.BalloonTipTimoutUpDown.ScreenTip.Text = "The time period, in milliseconds, the balloon tip should display";
            this.BalloonTipTimoutUpDown.Size = new System.Drawing.Size(144, 21);
            this.BalloonTipTimoutUpDown.TabIndex = 3;
            this.BalloonTipTimoutUpDown.TextEditorWidth = 64;
            this.BalloonTipTimoutUpDown.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // BalloonTipIconComboBox
            // 
            this.BalloonTipIconComboBox.Editable = false;
            this.BalloonTipIconComboBox.FormattingEnabled = false;
            this.BalloonTipIconComboBox.Id = "45127b90-5952-4f96-8f58-dbc8d81bf9b2";
            this.BalloonTipIconComboBox.Items.AddRange(new object[] {
            "None",
            "Info",
            "Warning",
            "Error"});
            this.BalloonTipIconComboBox.KeyTip = "N";
            this.BalloonTipIconComboBox.LabelAreaWidthTemplate = "Icon";
            this.BalloonTipIconComboBox.LabelText = "Icon";
            this.BalloonTipIconComboBox.Location = new System.Drawing.Point(12, 123);
            this.BalloonTipIconComboBox.Name = "BalloonTipIconComboBox";
            this.BalloonTipIconComboBox.ScreenTip.Text = "Balloon tip icon";
            this.BalloonTipIconComboBox.Size = new System.Drawing.Size(303, 21);
            this.BalloonTipIconComboBox.TabIndex = 2;
            this.BalloonTipIconComboBox.Text = "None";
            this.BalloonTipIconComboBox.TextEditorWidth = 260;
            // 
            // ShowBalloonTipButton
            // 
            this.ShowBalloonTipButton.Id = "6ada7e6b-9e7b-4970-bc28-c4b6541bf056";
            this.ShowBalloonTipButton.KeyTip = "S";
            this.ShowBalloonTipButton.Location = new System.Drawing.Point(165, 153);
            this.ShowBalloonTipButton.Name = "ShowBalloonTipButton";
            this.ShowBalloonTipButton.ScreenTip.Text = "Show balloon tip";
            this.ShowBalloonTipButton.Size = new System.Drawing.Size(150, 29);
            this.ShowBalloonTipButton.TabIndex = 4;
            this.ShowBalloonTipButton.Text = "Show";
            this.ShowBalloonTipButton.Click += new System.EventHandler(this.ShowBalloonTipButton_Click);
            // 
            // BalloonTipTextTextBox
            // 
            this.BalloonTipTextTextBox.Id = "0bdbca05-e3b5-4717-aa46-34d0f0d1d46c";
            this.BalloonTipTextTextBox.KeyTip = "E";
            this.BalloonTipTextTextBox.LabelAreaWidthTemplate = "Icon";
            this.BalloonTipTextTextBox.LabelText = "Text";
            this.BalloonTipTextTextBox.Location = new System.Drawing.Point(12, 59);
            this.BalloonTipTextTextBox.Multiline = true;
            this.BalloonTipTextTextBox.Name = "BalloonTipTextTextBox";
            this.BalloonTipTextTextBox.ScreenTip.Text = "Balloon tip text";
            this.BalloonTipTextTextBox.Size = new System.Drawing.Size(303, 54);
            this.BalloonTipTextTextBox.TabIndex = 1;
            this.BalloonTipTextTextBox.Text = "Icons in the notification area are shortcuts to processes that are running in the" +
                " background of a computer, such as a virus protection program or a volume contro" +
                "l.";
            this.BalloonTipTextTextBox.TextEditorWidth = 273;
            // 
            // ChooseIconButton
            // 
            this.ChooseIconButton.Id = "3b14956e-5a98-4935-9cd3-7c69525ce5b1";
            this.ChooseIconButton.KeyTip = "C";
            this.ChooseIconButton.Location = new System.Drawing.Point(305, 19);
            this.ChooseIconButton.Name = "ChooseIconButton";
            this.ChooseIconButton.ScreenTip.Text = "Change the Icon";
            this.ChooseIconButton.Size = new System.Drawing.Size(25, 21);
            this.ChooseIconButton.TabIndex = 1;
            this.ChooseIconButton.Text = "...";
            this.ChooseIconButton.Click += new System.EventHandler(this.ChooseIconButton_Click);
            // 
            // ToolTipTextTextBox
            // 
            this.ToolTipTextTextBox.Id = "986a55af-bba3-4884-a240-bd3a8372cd30";
            this.ToolTipTextTextBox.KeyTip = "O";
            this.ToolTipTextTextBox.LabelAreaWidthTemplate = "";
            this.ToolTipTextTextBox.LabelText = "Tool tip text";
            this.ToolTipTextTextBox.Location = new System.Drawing.Point(15, 53);
            this.ToolTipTextTextBox.Multiline = true;
            this.ToolTipTextTextBox.Name = "ToolTipTextTextBox";
            this.ToolTipTextTextBox.ScreenTip.Text = "Tool tip text";
            this.ToolTipTextTextBox.Size = new System.Drawing.Size(315, 40);
            this.ToolTipTextTextBox.TabIndex = 2;
            this.ToolTipTextTextBox.Text = "Right-click the icon to show context menu";
            this.ToolTipTextTextBox.TextEditorWidth = 251;
            this.ToolTipTextTextBox.TextChanged += new System.EventHandler(this.ToolTipTextTextBox_TextChanged);
            // 
            // ControlsSampleNotifyIcon
            // 
            this.ControlsSampleNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Error;
            this.ControlsSampleNotifyIcon.ContextPopup = this.NotifyIconContextMenu;
            this.ControlsSampleNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("ControlsSampleNotifyIcon.Icon")));
            this.ControlsSampleNotifyIcon.IsBalloonTipShown = false;
            this.ControlsSampleNotifyIcon.Text = "Tool tip text";
            this.ControlsSampleNotifyIcon.Visible = true;
            this.ControlsSampleNotifyIcon.MouseLeave += new System.EventHandler(this.NotifyIcon_MouseLeave);
            this.ControlsSampleNotifyIcon.MouseEnter += new System.EventHandler(this.NotifyIcon_MouseEnter);
            this.ControlsSampleNotifyIcon.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ControlsSampleNotifyIcon_MouseUp);
            this.ControlsSampleNotifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ControlsSampleNotifyIcon_MouseDoubleClick);
            this.ControlsSampleNotifyIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ControlsSampleNotifyIcon_MouseDown);
            this.ControlsSampleNotifyIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ControlsSampleNotifyIcon_MouseMove);
            // 
            // NotifyIconContextMenu
            // 
            this.NotifyIconContextMenu.Items.AddRange(new System.Windows.Forms.Control[] {
            this.NotifyIconContextMenuButton1,
            this.NotifyIconContextMenuButton2,
            this.NotifyIconContextMenuSeparator,
            this.NotifyIconContextMenuGallery,
            this.NotifyIconContextMenuDropDown1,
            this.NotifyIconContextMenuButton3});
            this.NotifyIconContextMenu.KeepPopupsWithOffsetPlacementWithinPlacementArea = false;
            this.NotifyIconContextMenu.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
            this.NotifyIconContextMenu.PlacementOffset = new System.Drawing.Size(402, 67);
            this.NotifyIconContextMenu.Size = new System.Drawing.Size(100, 100);
            // 
            // NotifyIconContextMenuButton1
            // 
            this.NotifyIconContextMenuButton1.Id = "17bcf817-6626-414d-8182-d453dd1d4710";
            this.NotifyIconContextMenuButton1.Location = new System.Drawing.Point(2, 2);
            this.NotifyIconContextMenuButton1.Name = "NotifyIconContextMenuButton1";
            this.NotifyIconContextMenuButton1.Size = new System.Drawing.Size(138, 23);
            this.NotifyIconContextMenuButton1.TabIndex = 2;
            this.NotifyIconContextMenuButton1.Text = "Open";
            // 
            // NotifyIconContextMenuButton2
            // 
            this.NotifyIconContextMenuButton2.Id = "b2882905-ca48-496c-9c61-c3cad5cac46a";
            this.NotifyIconContextMenuButton2.Location = new System.Drawing.Point(2, 25);
            this.NotifyIconContextMenuButton2.Name = "NotifyIconContextMenuButton2";
            this.NotifyIconContextMenuButton2.Size = new System.Drawing.Size(138, 23);
            this.NotifyIconContextMenuButton2.TabIndex = 3;
            this.NotifyIconContextMenuButton2.Text = "Save";
            // 
            // NotifyIconContextMenuSeparator
            // 
            this.NotifyIconContextMenuSeparator.Id = "74bd2ae8-6788-4730-ab2a-082fb9816881";
            this.NotifyIconContextMenuSeparator.Location = new System.Drawing.Point(2, 48);
            this.NotifyIconContextMenuSeparator.Name = "NotifyIconContextMenuSeparator";
            this.NotifyIconContextMenuSeparator.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal;
            this.NotifyIconContextMenuSeparator.Size = new System.Drawing.Size(138, 5);
            this.NotifyIconContextMenuSeparator.TabIndex = 4;
            this.NotifyIconContextMenuSeparator.Text = "separator1";
            // 
            // NotifyIconContextMenuGallery
            // 
            this.NotifyIconContextMenuGallery.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.NotifyIconContextMenuGallery.Id = "31f3b49f-2720-497b-adfd-495d2244e17d";
            this.NotifyIconContextMenuGallery.ItemHeight = 105;
            this.NotifyIconContextMenuGallery.Items.AddRange(new object[] {
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall1, null, "Nature 1", null),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall2, null, "Nature 2", null),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall3, null, "Nature 3", null),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall4, null, "Nature 4", null),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall5, null, "Nature 5", null),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall6, null, "Nature 5", null)});
            this.NotifyIconContextMenuGallery.ItemWidth = 140;
            this.NotifyIconContextMenuGallery.Location = new System.Drawing.Point(2, 53);
            this.NotifyIconContextMenuGallery.Name = "NotifyIconContextMenuGallery";
            // 
            // 
            // 
            this.NotifyIconContextMenuGallery.Popup.KeepPopupsWithOffsetPlacementWithinPlacementArea = false;
            this.NotifyIconContextMenuGallery.Popup.PlacementMode = Elegant.Ui.PopupPlacementMode.Right;
            this.NotifyIconContextMenuGallery.Popup.Size = new System.Drawing.Size(100, 100);
            this.NotifyIconContextMenuGallery.Size = new System.Drawing.Size(138, 23);
            this.NotifyIconContextMenuGallery.TabIndex = 5;
            this.NotifyIconContextMenuGallery.Text = "Nature";
            // 
            // NotifyIconContextMenuDropDown1
            // 
            this.NotifyIconContextMenuDropDown1.Id = "94cd3ebe-6736-410c-8ef1-1bcdb4c2fa01";
            this.NotifyIconContextMenuDropDown1.Location = new System.Drawing.Point(2, 76);
            this.NotifyIconContextMenuDropDown1.Name = "NotifyIconContextMenuDropDown1";
            this.NotifyIconContextMenuDropDown1.Popup = this.popupMenu1;
            this.NotifyIconContextMenuDropDown1.Size = new System.Drawing.Size(138, 23);
            this.NotifyIconContextMenuDropDown1.TabIndex = 7;
            this.NotifyIconContextMenuDropDown1.Text = "Add";
            this.NotifyIconContextMenuDropDown1.TogglePopupByClickWhenOpen = false;
            // 
            // popupMenu1
            // 
            this.popupMenu1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.NotifyIconContextMenuButton4,
            this.NotifyIconContextMenuButton5});
            this.popupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = false;
            this.popupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Right;
            this.popupMenu1.Size = new System.Drawing.Size(100, 100);
            // 
            // NotifyIconContextMenuButton4
            // 
            this.NotifyIconContextMenuButton4.Id = "fc407adc-32cb-485e-9ff2-28a53b37fd90";
            this.NotifyIconContextMenuButton4.Location = new System.Drawing.Point(2, 2);
            this.NotifyIconContextMenuButton4.Name = "NotifyIconContextMenuButton4";
            this.NotifyIconContextMenuButton4.Size = new System.Drawing.Size(126, 21);
            this.NotifyIconContextMenuButton4.TabIndex = 3;
            this.NotifyIconContextMenuButton4.Text = "File";
            // 
            // NotifyIconContextMenuButton5
            // 
            this.NotifyIconContextMenuButton5.Id = "02308f2d-6e29-4de8-81a0-8383dd599135";
            this.NotifyIconContextMenuButton5.Location = new System.Drawing.Point(2, 23);
            this.NotifyIconContextMenuButton5.Name = "NotifyIconContextMenuButton5";
            this.NotifyIconContextMenuButton5.Size = new System.Drawing.Size(126, 21);
            this.NotifyIconContextMenuButton5.TabIndex = 4;
            this.NotifyIconContextMenuButton5.Text = "Picture";
            // 
            // NotifyIconContextMenuButton3
            // 
            this.NotifyIconContextMenuButton3.Id = "e71cc4bb-f51a-4981-926b-5d94b1b69ec3";
            this.NotifyIconContextMenuButton3.Location = new System.Drawing.Point(2, 99);
            this.NotifyIconContextMenuButton3.Name = "NotifyIconContextMenuButton3";
            this.NotifyIconContextMenuButton3.Size = new System.Drawing.Size(138, 23);
            this.NotifyIconContextMenuButton3.TabIndex = 9;
            this.NotifyIconContextMenuButton3.Text = "Exit";
            // 
            // NotifyIconPage
            // 
            this.contextMenuExtenderProvider1.SetContextPopupMenu(this, null);
            this.Controls.Add(this.NotifyIconPagePanel);
            this.Name = "NotifyIconPage";
            this.Size = new System.Drawing.Size(655, 507);
            this.NotifyIconPagePanel.ResumeLayout(false);
            this.NotifyIconPagePanel.PerformLayout();
            this.EventsGroupBox.ResumeLayout(false);
            this.EventsGroupBox.PerformLayout();
            this.BalloonTipGroupBox.ResumeLayout(false);
            this.BalloonTipGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BalloonTipTimoutUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotifyIconContextMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotifyIconContextMenuGallery.Popup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NotifyIconContextMenuGallery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel NotifyIconPagePanel;
        private NotifyIcon ControlsSampleNotifyIcon;
        private EventControl MouseEnterEventControl;
        private ContextMenu NotifyIconContextMenu;
        private ContextMenuExtenderProvider contextMenuExtenderProvider1;
        private TextBox ToolTipTextTextBox;
        private TextBox BalloonTipTitleTextBox;
        private TextBox BalloonTipTextTextBox;
        private EventControl MouseLeaveEventControl;
        private Label MouseEnterEventLabel;
        private Label MouseLeaveEventLabel;
        private Button ChooseIconButton;
        private Button ShowBalloonTipButton;
        private ComboBox BalloonTipIconComboBox;
        private NumericUpDown BalloonTipTimoutUpDown;
        private Button NotifyIconContextMenuButton1;
        private Button NotifyIconContextMenuButton2;
        private Separator NotifyIconContextMenuSeparator;
        private Gallery NotifyIconContextMenuGallery;
        private EventControl MouseDownEventControl;
        private Label MouseDownEventLabel;
        private EventControl MouseUpEventControl;
        private Label MouseUpEventLabel;
        private EventControl MouseMoveEventControl;
        private Label MouseMoveEventLabel;
        private GroupBox BalloonTipGroupBox;
        private TextBox MouseIconEventsTextBox;
        private Label ListOfEventsLabel;
        private GroupBox EventsGroupBox;
        private DropDown NotifyIconContextMenuDropDown1;
        private PopupMenu popupMenu1;
        private Button NotifyIconContextMenuButton4;
        private Button NotifyIconContextMenuButton5;
        private TextBox IconPathTextBox;
        private Button NotifyIconContextMenuButton3;
        private CheckBox AnimatedIconCheckBox;
    }
}
