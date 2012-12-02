namespace Elegant.Ui.Samples.ControlsSample
{
    partial class CalendarPage
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
            this.CalendarPropertiesPanel = new Elegant.Ui.Panel();
            this.ButtonsGroupBox = new Elegant.Ui.GroupBox();
            this.DayOfWeekDisplayModeComboBox = new Elegant.Ui.ComboBox();
            this.NoneButtonVisibleCheckBox = new Elegant.Ui.CheckBox();
            this.CustomPaintingDemoToggleButton = new Elegant.Ui.ToggleButton();
            this.CalendarDimensionsLabel = new Elegant.Ui.Label();
            this.WeekNumbersVisibleCheckBox = new Elegant.Ui.CheckBox();
            this.CalendarDimensionsWidthNumericUpDown = new Elegant.Ui.NumericUpDown();
            this.MaximumWidthNumericUpDown = new Elegant.Ui.NumericUpDown();
            this.TodayButtonVisibleCheckBox = new Elegant.Ui.CheckBox();
            this.CalendarDimensionsHeightNumericUpDown = new Elegant.Ui.NumericUpDown();
            this.NonMonthDaysVisibleCheckBox = new Elegant.Ui.CheckBox();
            this.MaximumHeightNumericUpDown = new Elegant.Ui.NumericUpDown();
            this.MonthSelectionPopupEnabledCheckBox = new Elegant.Ui.CheckBox();
            this.AutoDimensionsModeCheckBox = new Elegant.Ui.CheckBox();
            this.AllowMultipleSelectionCheckBox = new Elegant.Ui.CheckBox();
            this.SampleCalendar = new Elegant.Ui.Calendar();
            this.RightClickInfoLabel = new Elegant.Ui.Label();
            this.CalendarHitTestContextMenu = new Elegant.Ui.ContextMenu(this.components);
            this.HitTestInfoButton = new Elegant.Ui.Button();
            this.contextMenuExtenderProvider1 = new Elegant.Ui.ContextMenuExtenderProvider(this.components);
            this.CalendarPageControls = new Elegant.Ui.Panel();
            this.TopControlsPanel = new Elegant.Ui.Panel();
            this.CalendarPropertiesPanel.SuspendLayout();
            this.ButtonsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarDimensionsWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumWidthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarDimensionsHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumHeightNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleCalendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarHitTestContextMenu)).BeginInit();
            this.CalendarPageControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // CalendarPropertiesPanel
            // 
            this.CalendarPropertiesPanel.Controls.Add(this.ButtonsGroupBox);
            this.CalendarPropertiesPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.CalendarPropertiesPanel.Location = new System.Drawing.Point(431, 0);
            this.CalendarPropertiesPanel.Name = "CalendarPropertiesPanel";
            this.CalendarPropertiesPanel.Size = new System.Drawing.Size(279, 459);
            this.CalendarPropertiesPanel.TabIndex = 0;
            // 
            // ButtonsGroupBox
            // 
            this.ButtonsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonsGroupBox.Controls.Add(this.DayOfWeekDisplayModeComboBox);
            this.ButtonsGroupBox.Controls.Add(this.NoneButtonVisibleCheckBox);
            this.ButtonsGroupBox.Controls.Add(this.CustomPaintingDemoToggleButton);
            this.ButtonsGroupBox.Controls.Add(this.CalendarDimensionsLabel);
            this.ButtonsGroupBox.Controls.Add(this.WeekNumbersVisibleCheckBox);
            this.ButtonsGroupBox.Controls.Add(this.CalendarDimensionsWidthNumericUpDown);
            this.ButtonsGroupBox.Controls.Add(this.MaximumWidthNumericUpDown);
            this.ButtonsGroupBox.Controls.Add(this.TodayButtonVisibleCheckBox);
            this.ButtonsGroupBox.Controls.Add(this.CalendarDimensionsHeightNumericUpDown);
            this.ButtonsGroupBox.Controls.Add(this.NonMonthDaysVisibleCheckBox);
            this.ButtonsGroupBox.Controls.Add(this.MaximumHeightNumericUpDown);
            this.ButtonsGroupBox.Controls.Add(this.MonthSelectionPopupEnabledCheckBox);
            this.ButtonsGroupBox.Controls.Add(this.AutoDimensionsModeCheckBox);
            this.ButtonsGroupBox.Controls.Add(this.AllowMultipleSelectionCheckBox);
            this.ButtonsGroupBox.Id = "4a348a1e-7300-4592-bd7d-e12785551162";
            this.ButtonsGroupBox.Location = new System.Drawing.Point(16, 11);
            this.ButtonsGroupBox.Name = "ButtonsGroupBox";
            this.ButtonsGroupBox.Size = new System.Drawing.Size(249, 448);
            this.ButtonsGroupBox.TabIndex = 13;
            this.ButtonsGroupBox.Text = "Settings";
            // 
            // DayOfWeekDisplayModeComboBox
            // 
            this.DayOfWeekDisplayModeComboBox.BackColor = System.Drawing.SystemColors.Window;
            this.DayOfWeekDisplayModeComboBox.Editable = false;
            this.DayOfWeekDisplayModeComboBox.FormattingEnabled = false;
            this.DayOfWeekDisplayModeComboBox.Id = "00a9d6e9-07ef-4f20-b3d1-7b97c5a007c9";
            this.DayOfWeekDisplayModeComboBox.InformativenessFixedLevel = "Elegant.Ui.ComboBoxInformativenessLevel:ComboBoxWithLabel";
            this.DayOfWeekDisplayModeComboBox.KeyTip = "DE";
            this.DayOfWeekDisplayModeComboBox.LabelText = "Day of Week Display Mode";
            this.DayOfWeekDisplayModeComboBox.Location = new System.Drawing.Point(8, 19);
            this.DayOfWeekDisplayModeComboBox.Name = "DayOfWeekDisplayModeComboBox";
            this.DayOfWeekDisplayModeComboBox.ScreenTip.Text = "Day of Week Display Mode";
            this.DayOfWeekDisplayModeComboBox.Size = new System.Drawing.Size(231, 21);
            this.DayOfWeekDisplayModeComboBox.TabIndex = 0;
            this.DayOfWeekDisplayModeComboBox.TextEditorWidth = 79;
            this.DayOfWeekDisplayModeComboBox.SelectedIndexChanged += new System.EventHandler(this.DayOfWeekDisplayModeComboBox_SelectedIndexChanged);
            // 
            // NoneButtonVisibleCheckBox
            // 
            this.NoneButtonVisibleCheckBox.Checked = true;
            this.NoneButtonVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NoneButtonVisibleCheckBox.Id = "0733040b-6989-4755-8010-47d1c9a54872";
            this.NoneButtonVisibleCheckBox.KeyTip = "N";
            this.NoneButtonVisibleCheckBox.Location = new System.Drawing.Point(8, 315);
            this.NoneButtonVisibleCheckBox.Name = "NoneButtonVisibleCheckBox";
            this.NoneButtonVisibleCheckBox.ScreenTip.Text = "\"None\" Button Visible";
            this.NoneButtonVisibleCheckBox.Size = new System.Drawing.Size(173, 19);
            this.NoneButtonVisibleCheckBox.TabIndex = 9;
            this.NoneButtonVisibleCheckBox.Text = "\"None\" Button Visible";
            this.NoneButtonVisibleCheckBox.CheckedChanged += new System.EventHandler(this.NoneButtonVisibleCheckBox_CheckedChanged);
            // 
            // CustomPaintingDemoToggleButton
            // 
            this.CustomPaintingDemoToggleButton.Id = "41f426d3-0bbf-4b32-b7aa-75363d980ea0";
            this.CustomPaintingDemoToggleButton.KeyTip = "C";
            this.CustomPaintingDemoToggleButton.Location = new System.Drawing.Point(26, 383);
            this.CustomPaintingDemoToggleButton.Name = "CustomPaintingDemoToggleButton";
            this.CustomPaintingDemoToggleButton.ScreenTip.Text = "Run custom painting demo";
            this.CustomPaintingDemoToggleButton.Size = new System.Drawing.Size(154, 28);
            this.CustomPaintingDemoToggleButton.TabIndex = 11;
            this.CustomPaintingDemoToggleButton.Text = "Custom Painting Demo";
            this.CustomPaintingDemoToggleButton.PressedChanged += new System.EventHandler(this.CustomPaintingDemoToggleButton_PressedChanged);
            // 
            // CalendarDimensionsLabel
            // 
            this.CalendarDimensionsLabel.Location = new System.Drawing.Point(8, 53);
            this.CalendarDimensionsLabel.Name = "CalendarDimensionsLabel";
            this.CalendarDimensionsLabel.Size = new System.Drawing.Size(99, 15);
            this.CalendarDimensionsLabel.TabIndex = 0;
            this.CalendarDimensionsLabel.Text = "Calendar Dimensions";
            // 
            // WeekNumbersVisibleCheckBox
            // 
            this.WeekNumbersVisibleCheckBox.Checked = true;
            this.WeekNumbersVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.WeekNumbersVisibleCheckBox.Id = "2e19e7a6-8d39-40e6-be86-7d2ecb8ff872";
            this.WeekNumbersVisibleCheckBox.KeyTip = "E";
            this.WeekNumbersVisibleCheckBox.Location = new System.Drawing.Point(8, 342);
            this.WeekNumbersVisibleCheckBox.Name = "WeekNumbersVisibleCheckBox";
            this.WeekNumbersVisibleCheckBox.ScreenTip.Text = "Week Numbers Visible";
            this.WeekNumbersVisibleCheckBox.Size = new System.Drawing.Size(173, 19);
            this.WeekNumbersVisibleCheckBox.TabIndex = 10;
            this.WeekNumbersVisibleCheckBox.Text = "Week Numbers Visible";
            this.WeekNumbersVisibleCheckBox.CheckedChanged += new System.EventHandler(this.WeekNumbersVisibleCheckBox_CheckedChanged);
            // 
            // CalendarDimensionsWidthNumericUpDown
            // 
            this.CalendarDimensionsWidthNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
            this.CalendarDimensionsWidthNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.CalendarDimensionsWidthNumericUpDown.Id = "c8a339ec-584b-4be1-a1a9-b8c9741d908d";
            this.CalendarDimensionsWidthNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithLabel";
            this.CalendarDimensionsWidthNumericUpDown.KeyTip = "W";
            this.CalendarDimensionsWidthNumericUpDown.LabelAreaWidthTemplate = "";
            this.CalendarDimensionsWidthNumericUpDown.LabelText = "Horizontal:";
            this.CalendarDimensionsWidthNumericUpDown.Location = new System.Drawing.Point(26, 72);
            this.CalendarDimensionsWidthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CalendarDimensionsWidthNumericUpDown.Name = "CalendarDimensionsWidthNumericUpDown";
            this.CalendarDimensionsWidthNumericUpDown.ScreenTip.Text = "Number of months to display horizontally";
            this.CalendarDimensionsWidthNumericUpDown.Size = new System.Drawing.Size(122, 21);
            this.CalendarDimensionsWidthNumericUpDown.TabIndex = 0;
            this.CalendarDimensionsWidthNumericUpDown.TextEditorWidth = 49;
            this.CalendarDimensionsWidthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CalendarDimensionsWidthNumericUpDown.ValueChanged += new System.EventHandler(this.CalendarDimensionsWidthNumericUpDown_ValueChanged);
            // 
            // MaximumWidthNumericUpDown
            // 
            this.MaximumWidthNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
            this.MaximumWidthNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.MaximumWidthNumericUpDown.Enabled = false;
            this.MaximumWidthNumericUpDown.Id = "ea80eaff-cddb-4692-82a9-ab780a799e87";
            this.MaximumWidthNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithLabel";
            this.MaximumWidthNumericUpDown.KeyTip = "MW";
            this.MaximumWidthNumericUpDown.LabelAreaWidthTemplate = "";
            this.MaximumWidthNumericUpDown.LabelText = "Max Horizontal:";
            this.MaximumWidthNumericUpDown.Location = new System.Drawing.Point(26, 156);
            this.MaximumWidthNumericUpDown.Name = "MaximumWidthNumericUpDown";
            this.MaximumWidthNumericUpDown.ScreenTip.Text = "Maximum number of months to display horizontally";
            this.MaximumWidthNumericUpDown.Size = new System.Drawing.Size(122, 21);
            this.MaximumWidthNumericUpDown.TabIndex = 3;
            this.MaximumWidthNumericUpDown.TextEditorWidth = 21;
            this.MaximumWidthNumericUpDown.ValueChanged += new System.EventHandler(this.MaximumWidthNumericUpDown_ValueChanged);
            // 
            // TodayButtonVisibleCheckBox
            // 
            this.TodayButtonVisibleCheckBox.Checked = true;
            this.TodayButtonVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TodayButtonVisibleCheckBox.Id = "664eb7b4-86c8-4b08-af95-4697aa63f6f8";
            this.TodayButtonVisibleCheckBox.KeyTip = "T";
            this.TodayButtonVisibleCheckBox.Location = new System.Drawing.Point(8, 289);
            this.TodayButtonVisibleCheckBox.Name = "TodayButtonVisibleCheckBox";
            this.TodayButtonVisibleCheckBox.ScreenTip.Text = "\"Today\" Button Visible";
            this.TodayButtonVisibleCheckBox.Size = new System.Drawing.Size(173, 19);
            this.TodayButtonVisibleCheckBox.TabIndex = 8;
            this.TodayButtonVisibleCheckBox.Text = "\"Today\" Button Visible";
            this.TodayButtonVisibleCheckBox.CheckedChanged += new System.EventHandler(this.TodayButtonVisibleCheckBox_CheckedChanged);
            // 
            // CalendarDimensionsHeightNumericUpDown
            // 
            this.CalendarDimensionsHeightNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
            this.CalendarDimensionsHeightNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.CalendarDimensionsHeightNumericUpDown.Id = "77b5af40-a289-41a7-867d-9a8c6b33768b";
            this.CalendarDimensionsHeightNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithLabel";
            this.CalendarDimensionsHeightNumericUpDown.KeyTip = "H";
            this.CalendarDimensionsHeightNumericUpDown.LabelAreaWidthTemplate = "Horizontal:";
            this.CalendarDimensionsHeightNumericUpDown.LabelText = "Vertical:";
            this.CalendarDimensionsHeightNumericUpDown.Location = new System.Drawing.Point(26, 99);
            this.CalendarDimensionsHeightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CalendarDimensionsHeightNumericUpDown.Name = "CalendarDimensionsHeightNumericUpDown";
            this.CalendarDimensionsHeightNumericUpDown.ScreenTip.Text = "Number of months to display vertically";
            this.CalendarDimensionsHeightNumericUpDown.Size = new System.Drawing.Size(122, 21);
            this.CalendarDimensionsHeightNumericUpDown.TabIndex = 1;
            this.CalendarDimensionsHeightNumericUpDown.TextEditorWidth = 49;
            this.CalendarDimensionsHeightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.CalendarDimensionsHeightNumericUpDown.ValueChanged += new System.EventHandler(this.CalendarDimensionsHeightNumericUpDown_ValueChanged);
            // 
            // NonMonthDaysVisibleCheckBox
            // 
            this.NonMonthDaysVisibleCheckBox.Checked = true;
            this.NonMonthDaysVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NonMonthDaysVisibleCheckBox.Id = "772b4a27-8b78-4d4a-84c5-206b275de1d3";
            this.NonMonthDaysVisibleCheckBox.KeyTip = "NMT";
            this.NonMonthDaysVisibleCheckBox.Location = new System.Drawing.Point(8, 264);
            this.NonMonthDaysVisibleCheckBox.Name = "NonMonthDaysVisibleCheckBox";
            this.NonMonthDaysVisibleCheckBox.ScreenTip.Text = "Non-Month Days Visible";
            this.NonMonthDaysVisibleCheckBox.Size = new System.Drawing.Size(173, 19);
            this.NonMonthDaysVisibleCheckBox.TabIndex = 7;
            this.NonMonthDaysVisibleCheckBox.Text = "Non-Month Days Visible";
            this.NonMonthDaysVisibleCheckBox.CheckedChanged += new System.EventHandler(this.NonMonthDaysVisibleCheckBox_CheckedChanged);
            // 
            // MaximumHeightNumericUpDown
            // 
            this.MaximumHeightNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
            this.MaximumHeightNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
            this.MaximumHeightNumericUpDown.Enabled = false;
            this.MaximumHeightNumericUpDown.Id = "fbc39efd-f3a2-473e-92e2-74225d0b7b49";
            this.MaximumHeightNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithLabel";
            this.MaximumHeightNumericUpDown.KeyTip = "MH";
            this.MaximumHeightNumericUpDown.LabelAreaWidthTemplate = "Max Horizontal:";
            this.MaximumHeightNumericUpDown.LabelText = "Max Vertical:";
            this.MaximumHeightNumericUpDown.Location = new System.Drawing.Point(26, 183);
            this.MaximumHeightNumericUpDown.Name = "MaximumHeightNumericUpDown";
            this.MaximumHeightNumericUpDown.ScreenTip.Text = "Maximum number of months to display vertically";
            this.MaximumHeightNumericUpDown.Size = new System.Drawing.Size(122, 21);
            this.MaximumHeightNumericUpDown.TabIndex = 4;
            this.MaximumHeightNumericUpDown.TextEditorWidth = 23;
            this.MaximumHeightNumericUpDown.ValueChanged += new System.EventHandler(this.MaximumHeightNumericUpDown_ValueChanged);
            // 
            // MonthSelectionPopupEnabledCheckBox
            // 
            this.MonthSelectionPopupEnabledCheckBox.Checked = true;
            this.MonthSelectionPopupEnabledCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MonthSelectionPopupEnabledCheckBox.Id = "736888b5-bd0e-41d9-91bc-c6818630942f";
            this.MonthSelectionPopupEnabledCheckBox.KeyTip = "MT";
            this.MonthSelectionPopupEnabledCheckBox.Location = new System.Drawing.Point(8, 239);
            this.MonthSelectionPopupEnabledCheckBox.Name = "MonthSelectionPopupEnabledCheckBox";
            this.MonthSelectionPopupEnabledCheckBox.ScreenTip.Text = "Month Selection Popup Enabled";
            this.MonthSelectionPopupEnabledCheckBox.Size = new System.Drawing.Size(173, 19);
            this.MonthSelectionPopupEnabledCheckBox.TabIndex = 6;
            this.MonthSelectionPopupEnabledCheckBox.Text = "Month Selection Popup Enabled";
            this.MonthSelectionPopupEnabledCheckBox.CheckedChanged += new System.EventHandler(this.MonthSelectionPopupEnabledCheckBox_CheckedChanged);
            // 
            // AutoDimensionsModeCheckBox
            // 
            this.AutoDimensionsModeCheckBox.Checked = true;
            this.AutoDimensionsModeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AutoDimensionsModeCheckBox.Id = "74285ff8-d3a0-4341-b3d1-73c0af96190e";
            this.AutoDimensionsModeCheckBox.KeyTip = "A";
            this.AutoDimensionsModeCheckBox.Location = new System.Drawing.Point(8, 134);
            this.AutoDimensionsModeCheckBox.Name = "AutoDimensionsModeCheckBox";
            this.AutoDimensionsModeCheckBox.ScreenTip.Text = "Auto-Dimensions Mode";
            this.AutoDimensionsModeCheckBox.Size = new System.Drawing.Size(133, 17);
            this.AutoDimensionsModeCheckBox.TabIndex = 2;
            this.AutoDimensionsModeCheckBox.Text = "Auto-Dimensions Mode";
            this.AutoDimensionsModeCheckBox.CheckedChanged += new System.EventHandler(this.AutoDimensionsModeCheckBox_CheckedChanged);
            // 
            // AllowMultipleSelectionCheckBox
            // 
            this.AllowMultipleSelectionCheckBox.Checked = true;
            this.AllowMultipleSelectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllowMultipleSelectionCheckBox.Id = "cd9f9e14-3b6e-4ffc-a899-24c082573055";
            this.AllowMultipleSelectionCheckBox.KeyTip = "MS";
            this.AllowMultipleSelectionCheckBox.Location = new System.Drawing.Point(8, 213);
            this.AllowMultipleSelectionCheckBox.Name = "AllowMultipleSelectionCheckBox";
            this.AllowMultipleSelectionCheckBox.ScreenTip.Text = "Allow Multiple Selection";
            this.AllowMultipleSelectionCheckBox.Size = new System.Drawing.Size(173, 19);
            this.AllowMultipleSelectionCheckBox.TabIndex = 5;
            this.AllowMultipleSelectionCheckBox.Text = "Allow Multiple Selection";
            this.AllowMultipleSelectionCheckBox.CheckedChanged += new System.EventHandler(this.AllowMultipleSelectionCheckBox_CheckedChanged);
            // 
            // SampleCalendar
            // 
            this.SampleCalendar.AllowMultipleSelection = true;
            this.SampleCalendar.AutoDimensionsMode = true;
            this.SampleCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SampleCalendar.FirstVisibleMonth = new System.DateTime(2008, 2, 6, 18, 52, 1, 891);
            this.SampleCalendar.Location = new System.Drawing.Point(15, 31);
            this.SampleCalendar.Name = "SampleCalendar";
            this.SampleCalendar.SelectedDate = null;
            this.SampleCalendar.Size = new System.Drawing.Size(416, 428);
            this.SampleCalendar.TabIndex = 0;
            this.SampleCalendar.WeekNumbersVisible = true;
            this.SampleCalendar.FirstVisibleMonthChanged += new System.EventHandler(this.SampleCalendar_FirstVisibleMonthChanged);
            this.SampleCalendar.DrawDay += new System.EventHandler<Elegant.Ui.CalendarDrawDayEventArgs>(this.SampleCalendar_DrawDay);
            this.SampleCalendar.PreviewMouseUp += new Elegant.Ui.PreviewMouseEventHandler(this.SampleCalendar_PreviewMouseUp);
            // 
            // RightClickInfoLabel
            // 
            this.RightClickInfoLabel.BackColor = System.Drawing.Color.White;
            this.RightClickInfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.RightClickInfoLabel.Location = new System.Drawing.Point(15, 18);
            this.RightClickInfoLabel.Name = "RightClickInfoLabel";
            this.RightClickInfoLabel.Size = new System.Drawing.Size(416, 13);
            this.RightClickInfoLabel.TabIndex = 1;
            this.RightClickInfoLabel.Text = "Right-click on calendar to get hit-test info";
            this.RightClickInfoLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.RightClickInfoLabel.UseVisualThemeForBackground = false;
            // 
            // CalendarHitTestContextMenu
            // 
            this.CalendarHitTestContextMenu.Items.AddRange(new System.Windows.Forms.Control[] {
            this.HitTestInfoButton});
            this.CalendarHitTestContextMenu.KeepPopupsWithOffsetPlacementWithinPlacementArea = false;
            this.CalendarHitTestContextMenu.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
            this.CalendarHitTestContextMenu.PlacementOffset = new System.Drawing.Size(25, 65);
            this.CalendarHitTestContextMenu.Size = new System.Drawing.Size(100, 100);
            // 
            // HitTestInfoButton
            // 
            this.HitTestInfoButton.Id = "ec277ed3-e9c2-45ad-be6d-cd78e24f746e";
            this.HitTestInfoButton.Location = new System.Drawing.Point(2, 2);
            this.HitTestInfoButton.Name = "HitTestInfoButton";
            this.HitTestInfoButton.Size = new System.Drawing.Size(138, 23);
            this.HitTestInfoButton.TabIndex = 3;
            this.HitTestInfoButton.Text = "button1";
            // 
            // CalendarPageControls
            // 
            this.CalendarPageControls.Controls.Add(this.SampleCalendar);
            this.CalendarPageControls.Controls.Add(this.RightClickInfoLabel);
            this.CalendarPageControls.Controls.Add(this.TopControlsPanel);
            this.CalendarPageControls.Controls.Add(this.CalendarPropertiesPanel);
            this.CalendarPageControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CalendarPageControls.Location = new System.Drawing.Point(0, 0);
            this.CalendarPageControls.Name = "CalendarPageControls";
            this.CalendarPageControls.Padding = new System.Windows.Forms.Padding(15, 0, 0, 15);
            this.CalendarPageControls.Size = new System.Drawing.Size(710, 474);
            this.CalendarPageControls.TabIndex = 2;
            // 
            // TopControlsPanel
            // 
            this.TopControlsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopControlsPanel.Location = new System.Drawing.Point(15, 0);
            this.TopControlsPanel.Name = "TopControlsPanel";
            this.TopControlsPanel.Size = new System.Drawing.Size(416, 18);
            this.TopControlsPanel.TabIndex = 1;
            // 
            // CalendarPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.CalendarPageControls);
            this.Name = "CalendarPage";
            this.Size = new System.Drawing.Size(710, 474);
            this.CalendarPropertiesPanel.ResumeLayout(false);
            this.ButtonsGroupBox.ResumeLayout(false);
            this.ButtonsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarDimensionsWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumWidthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarDimensionsHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximumHeightNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SampleCalendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CalendarHitTestContextMenu)).EndInit();
            this.CalendarPageControls.ResumeLayout(false);
            this.CalendarPageControls.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel CalendarPropertiesPanel;
        private NumericUpDown CalendarDimensionsWidthNumericUpDown;
        private Label CalendarDimensionsLabel;
        private NumericUpDown CalendarDimensionsHeightNumericUpDown;
        private CheckBox AutoDimensionsModeCheckBox;
        private CheckBox AllowMultipleSelectionCheckBox;
        private CheckBox MonthSelectionPopupEnabledCheckBox;
        private CheckBox TodayButtonVisibleCheckBox;
        private CheckBox NonMonthDaysVisibleCheckBox;
        private CheckBox NoneButtonVisibleCheckBox;
        private ToggleButton CustomPaintingDemoToggleButton;
		private Calendar SampleCalendar;
        private ComboBox DayOfWeekDisplayModeComboBox;
        private NumericUpDown MaximumHeightNumericUpDown;
        private NumericUpDown MaximumWidthNumericUpDown;
        private Label RightClickInfoLabel;
        private CheckBox WeekNumbersVisibleCheckBox;
        private ContextMenu CalendarHitTestContextMenu;
        private ContextMenuExtenderProvider contextMenuExtenderProvider1;
        private Button HitTestInfoButton;
        private Panel CalendarPageControls;
		private GroupBox ButtonsGroupBox;
		private Panel TopControlsPanel;
    }
}
