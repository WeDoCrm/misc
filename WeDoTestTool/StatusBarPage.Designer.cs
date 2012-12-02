namespace Elegant.Ui.Samples.ControlsSample
{
    partial class StatusBarPage
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
			this.StatusBarPagePanel = new Elegant.Ui.Panel();
			this.SampleStatusBar = new Elegant.Ui.StatusBar();
			this.SampleStatusBarNotificationsArea = new Elegant.Ui.StatusBarNotificationsArea();
			this.SampleStatusBarControlsArea = new Elegant.Ui.StatusBarControlsArea();
			this.RemoveCurrentPaneButton = new Elegant.Ui.Button();
			this.HighlightCurrentPaneButton = new Elegant.Ui.Button();
			this.AddLabelButton = new Elegant.Ui.Button();
			this.AddSliderButton = new Elegant.Ui.Button();
			this.AddProgressBarButton = new Elegant.Ui.Button();
			this.AddButtonGroupButton = new Elegant.Ui.Button();
			this.AddToggleButtonSplitButton = new Elegant.Ui.SplitButton();
			this.popupMenu2 = new Elegant.Ui.PopupMenu();
			this.AddToggleButtonButton = new Elegant.Ui.Button();
			this.AddToggleButtonWithTextButton = new Elegant.Ui.Button();
			this.AddButtonSplitButton = new Elegant.Ui.SplitButton();
			this.popupMenu1 = new Elegant.Ui.PopupMenu();
			this.AddButtonButton = new Elegant.Ui.Button();
			this.AddButtonWithTextButton = new Elegant.Ui.Button();
			this.CurrentPaneComboBox = new Elegant.Ui.ComboBox();
			this.DisableCurrentPaneToggleButton = new Elegant.Ui.ToggleButton();
			this.AddPaneToNotificationsAreaButton = new Elegant.Ui.Button();
			this.AddPaneToControlsAreaButton = new Elegant.Ui.Button();
			this.StatusBarPagePanel.SuspendLayout();
			this.SampleStatusBar.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).BeginInit();
			this.SuspendLayout();
			// 
			// StatusBarPagePanel
			// 
			this.StatusBarPagePanel.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.StatusBarPagePanel.Controls.Add(this.SampleStatusBar);
			this.StatusBarPagePanel.Controls.Add(this.RemoveCurrentPaneButton);
			this.StatusBarPagePanel.Controls.Add(this.HighlightCurrentPaneButton);
			this.StatusBarPagePanel.Controls.Add(this.AddLabelButton);
			this.StatusBarPagePanel.Controls.Add(this.AddSliderButton);
			this.StatusBarPagePanel.Controls.Add(this.AddProgressBarButton);
			this.StatusBarPagePanel.Controls.Add(this.AddButtonGroupButton);
			this.StatusBarPagePanel.Controls.Add(this.AddToggleButtonSplitButton);
			this.StatusBarPagePanel.Controls.Add(this.AddButtonSplitButton);
			this.StatusBarPagePanel.Controls.Add(this.CurrentPaneComboBox);
			this.StatusBarPagePanel.Controls.Add(this.DisableCurrentPaneToggleButton);
			this.StatusBarPagePanel.Controls.Add(this.AddPaneToNotificationsAreaButton);
			this.StatusBarPagePanel.Controls.Add(this.AddPaneToControlsAreaButton);
			this.StatusBarPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.StatusBarPagePanel.Location = new System.Drawing.Point(0, 0);
			this.StatusBarPagePanel.Name = "StatusBarPagePanel";
			this.StatusBarPagePanel.Size = new System.Drawing.Size(523, 421);
			this.StatusBarPagePanel.TabIndex = 0;
			// 
			// SampleStatusBar
			// 
			this.SampleStatusBar.Controls.Add(this.SampleStatusBarNotificationsArea);
			this.SampleStatusBar.Controls.Add(this.SampleStatusBarControlsArea);
			this.SampleStatusBar.ControlsArea = this.SampleStatusBarControlsArea;
			this.SampleStatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.SampleStatusBar.IntegrateWithForm = false;
			this.SampleStatusBar.Location = new System.Drawing.Point(0, 399);
			this.SampleStatusBar.Name = "SampleStatusBar";
			this.SampleStatusBar.NotificationsArea = this.SampleStatusBarNotificationsArea;
			this.SampleStatusBar.Size = new System.Drawing.Size(523, 22);
			this.SampleStatusBar.TabIndex = 6;
			// 
			// SampleStatusBarNotificationsArea
			// 
			this.SampleStatusBarNotificationsArea.AutoSize = true;
			this.SampleStatusBarNotificationsArea.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SampleStatusBarNotificationsArea.Location = new System.Drawing.Point(0, 0);
			this.SampleStatusBarNotificationsArea.MaximumSize = new System.Drawing.Size(0, 22);
			this.SampleStatusBarNotificationsArea.MinimumSize = new System.Drawing.Size(0, 22);
			this.SampleStatusBarNotificationsArea.Name = "SampleStatusBarNotificationsArea";
			this.SampleStatusBarNotificationsArea.Size = new System.Drawing.Size(503, 22);
			this.SampleStatusBarNotificationsArea.TabIndex = 1;
			// 
			// SampleStatusBarControlsArea
			// 
			this.SampleStatusBarControlsArea.AutoSize = true;
			this.SampleStatusBarControlsArea.Dock = System.Windows.Forms.DockStyle.Right;
			this.SampleStatusBarControlsArea.Location = new System.Drawing.Point(503, 0);
			this.SampleStatusBarControlsArea.MaximumSize = new System.Drawing.Size(0, 22);
			this.SampleStatusBarControlsArea.MinimumSize = new System.Drawing.Size(0, 22);
			this.SampleStatusBarControlsArea.Name = "SampleStatusBarControlsArea";
			this.SampleStatusBarControlsArea.Size = new System.Drawing.Size(20, 22);
			this.SampleStatusBarControlsArea.TabIndex = 0;
			// 
			// RemoveCurrentPaneButton
			// 
			this.RemoveCurrentPaneButton.CommandName = "";
			this.RemoveCurrentPaneButton.Id = "515ae9fc-a0f6-455c-8680-176cc697b306";
			this.RemoveCurrentPaneButton.KeyTip = "RP";
			this.RemoveCurrentPaneButton.Location = new System.Drawing.Point(47, 218);
			this.RemoveCurrentPaneButton.Name = "RemoveCurrentPaneButton";
			this.RemoveCurrentPaneButton.ScreenTip.Text = "Remove Current Pane";
			this.RemoveCurrentPaneButton.Size = new System.Drawing.Size(167, 23);
			this.RemoveCurrentPaneButton.TabIndex = 4;
			this.RemoveCurrentPaneButton.Text = "Remove Current Pane";
			this.RemoveCurrentPaneButton.Click += new System.EventHandler(this.RemoveCurrentPaneButton_Click);
			// 
			// HighlightCurrentPaneButton
			// 
			this.HighlightCurrentPaneButton.CommandName = "";
			this.HighlightCurrentPaneButton.Id = "ec4e1007-f032-4e90-b562-8a502bbb5810";
			this.HighlightCurrentPaneButton.KeyTip = "HP";
			this.HighlightCurrentPaneButton.Location = new System.Drawing.Point(47, 181);
			this.HighlightCurrentPaneButton.Name = "HighlightCurrentPaneButton";
			this.HighlightCurrentPaneButton.ScreenTip.Text = "Highlight Current Pane";
			this.HighlightCurrentPaneButton.Size = new System.Drawing.Size(167, 23);
			this.HighlightCurrentPaneButton.TabIndex = 3;
			this.HighlightCurrentPaneButton.Text = "Highlight Current Pane";
			this.HighlightCurrentPaneButton.Click += new System.EventHandler(this.HighlightCurrentPane_Click);
			// 
			// AddLabelButton
			// 
			this.AddLabelButton.Id = "c10546f5-1cbb-4d30-9636-20d100c602eb";
			this.AddLabelButton.KeyTip = "AL";
			this.AddLabelButton.Location = new System.Drawing.Point(324, 142);
			this.AddLabelButton.Name = "AddLabelButton";
			this.AddLabelButton.ScreenTip.Text = "Add Label";
			this.AddLabelButton.Size = new System.Drawing.Size(126, 23);
			this.AddLabelButton.TabIndex = 9;
			this.AddLabelButton.Text = "Add Label";
			this.AddLabelButton.Click += new System.EventHandler(this.AddLabelButton_Click);
			// 
			// AddSliderButton
			// 
			this.AddSliderButton.Id = "c6bb775c-9f9f-4ebc-98b2-9491c00c0d29";
			this.AddSliderButton.KeyTip = "AP";
			this.AddSliderButton.Location = new System.Drawing.Point(324, 210);
			this.AddSliderButton.Name = "AddSliderButton";
			this.AddSliderButton.ScreenTip.Text = "Add Progress Bar";
			this.AddSliderButton.Size = new System.Drawing.Size(126, 23);
			this.AddSliderButton.TabIndex = 11;
			this.AddSliderButton.Text = "Add Slider";
			// 
			// AddProgressBarButton
			// 
			this.AddProgressBarButton.Id = "4c75c190-6f88-4293-b50c-5681fb8de298";
			this.AddProgressBarButton.KeyTip = "AP";
			this.AddProgressBarButton.Location = new System.Drawing.Point(324, 176);
			this.AddProgressBarButton.Name = "AddProgressBarButton";
			this.AddProgressBarButton.ScreenTip.Text = "Add Progress Bar";
			this.AddProgressBarButton.Size = new System.Drawing.Size(126, 23);
			this.AddProgressBarButton.TabIndex = 10;
			this.AddProgressBarButton.Text = "Add Progress Bar";
			this.AddProgressBarButton.Click += new System.EventHandler(this.AddProgressBarButton_Click);
			// 
			// AddButtonGroupButton
			// 
			this.AddButtonGroupButton.Id = "5478ac7a-b627-4836-90e7-50d2e2f57d62";
			this.AddButtonGroupButton.KeyTip = "AG";
			this.AddButtonGroupButton.Location = new System.Drawing.Point(324, 108);
			this.AddButtonGroupButton.Name = "AddButtonGroupButton";
			this.AddButtonGroupButton.ScreenTip.Text = "Add Button Group";
			this.AddButtonGroupButton.Size = new System.Drawing.Size(126, 23);
			this.AddButtonGroupButton.TabIndex = 8;
			this.AddButtonGroupButton.Text = "Add Button Group";
			this.AddButtonGroupButton.Click += new System.EventHandler(this.AddButtonGroupButton_Click);
			// 
			// AddToggleButtonSplitButton
			// 
			this.AddToggleButtonSplitButton.ButtonKeyTip = "AT";
			this.AddToggleButtonSplitButton.ButtonScreenTip.Text = "Add Toggle Button";
			this.AddToggleButtonSplitButton.CommandName = "";
			this.AddToggleButtonSplitButton.DropDownKeyTip = "ADT";
			this.AddToggleButtonSplitButton.Id = "9ec393c1-6f90-41fd-ab9a-e310ff29efa2";
			this.AddToggleButtonSplitButton.Location = new System.Drawing.Point(324, 74);
			this.AddToggleButtonSplitButton.Name = "AddToggleButtonSplitButton";
			this.AddToggleButtonSplitButton.Popup = this.popupMenu2;
			this.AddToggleButtonSplitButton.Size = new System.Drawing.Size(126, 23);
			this.AddToggleButtonSplitButton.TabIndex = 7;
			this.AddToggleButtonSplitButton.Text = "Add Toggle Button";
			// 
			// popupMenu2
			// 
			this.popupMenu2.Items.AddRange(new System.Windows.Forms.Control[] {
            this.AddToggleButtonButton,
            this.AddToggleButtonWithTextButton});
			this.popupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
			this.popupMenu2.Size = new System.Drawing.Size(100, 100);
			// 
			// AddToggleButtonButton
			// 
			this.AddToggleButtonButton.CommandName = "B";
			this.AddToggleButtonButton.Id = "b34e19fc-4988-4ac4-8640-11bf7fbbadb9";
			this.AddToggleButtonButton.Location = new System.Drawing.Point(2, 2);
			this.AddToggleButtonButton.Name = "AddToggleButtonButton";
			this.AddToggleButtonButton.Size = new System.Drawing.Size(213, 23);
			this.AddToggleButtonButton.TabIndex = 3;
			this.AddToggleButtonButton.Text = "Add Toggle Button";
			// 
			// AddToggleButtonWithTextButton
			// 
			this.AddToggleButtonWithTextButton.CommandName = "T";
			this.AddToggleButtonWithTextButton.Id = "672a8c5e-ea63-48e7-8afe-72beae207124";
			this.AddToggleButtonWithTextButton.Location = new System.Drawing.Point(2, 25);
			this.AddToggleButtonWithTextButton.Name = "AddToggleButtonWithTextButton";
			this.AddToggleButtonWithTextButton.Size = new System.Drawing.Size(213, 23);
			this.AddToggleButtonWithTextButton.TabIndex = 4;
			this.AddToggleButtonWithTextButton.Text = "Add Toggle Button With Text";
			// 
			// AddButtonSplitButton
			// 
			this.AddButtonSplitButton.ButtonKeyTip = "AB";
			this.AddButtonSplitButton.ButtonScreenTip.Text = "Add Button";
			this.AddButtonSplitButton.DropDownKeyTip = "ADB";
			this.AddButtonSplitButton.Id = "e391be4a-a6cf-4072-9b08-e05aac14a4c6";
			this.AddButtonSplitButton.Location = new System.Drawing.Point(324, 40);
			this.AddButtonSplitButton.Name = "AddButtonSplitButton";
			this.AddButtonSplitButton.Popup = this.popupMenu1;
			this.AddButtonSplitButton.Size = new System.Drawing.Size(126, 23);
			this.AddButtonSplitButton.TabIndex = 6;
			this.AddButtonSplitButton.Text = "Add Button";
			// 
			// popupMenu1
			// 
			this.popupMenu1.Items.AddRange(new System.Windows.Forms.Control[] {
            this.AddButtonButton,
            this.AddButtonWithTextButton});
			this.popupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
			this.popupMenu1.Size = new System.Drawing.Size(100, 100);
			// 
			// AddButtonButton
			// 
			this.AddButtonButton.Id = "e715c561-77a9-4d42-b25e-2ab03caf9147";
			this.AddButtonButton.KeyTip = "B";
			this.AddButtonButton.Location = new System.Drawing.Point(2, 2);
			this.AddButtonButton.Name = "AddButtonButton";
			this.AddButtonButton.Size = new System.Drawing.Size(173, 23);
			this.AddButtonButton.TabIndex = 3;
			this.AddButtonButton.Text = "Add Button";
			// 
			// AddButtonWithTextButton
			// 
			this.AddButtonWithTextButton.Id = "4baf2a6e-0802-4fb5-bf21-aa1b97236100";
			this.AddButtonWithTextButton.KeyTip = "T";
			this.AddButtonWithTextButton.Location = new System.Drawing.Point(2, 25);
			this.AddButtonWithTextButton.Name = "AddButtonWithTextButton";
			this.AddButtonWithTextButton.Size = new System.Drawing.Size(173, 23);
			this.AddButtonWithTextButton.TabIndex = 4;
			this.AddButtonWithTextButton.Text = "Add Button With Text";
			// 
			// CurrentPaneComboBox
			// 
			this.CurrentPaneComboBox.BackColor = System.Drawing.SystemColors.Window;
			this.CurrentPaneComboBox.CommandName = "";
			this.CurrentPaneComboBox.Editable = false;
			this.CurrentPaneComboBox.FormattingEnabled = false;
			this.CurrentPaneComboBox.Id = "3a7d3ec1-c4ba-4334-8e0c-bc398066448c";
			this.CurrentPaneComboBox.InformativenessFixedLevel = "Elegant.Ui.ComboBoxInformativenessLevel:ComboBoxWithLabel";
			this.CurrentPaneComboBox.KeyTip = "P";
			this.CurrentPaneComboBox.LabelText = "Current Pane:";
			this.CurrentPaneComboBox.Location = new System.Drawing.Point(47, 147);
			this.CurrentPaneComboBox.Name = "CurrentPaneComboBox";
			this.CurrentPaneComboBox.ScreenTip.Text = "Current Pane";
			this.CurrentPaneComboBox.Size = new System.Drawing.Size(167, 21);
			this.CurrentPaneComboBox.TabIndex = 2;
			this.CurrentPaneComboBox.TextEditorWidth = 77;
			// 
			// DisableCurrentPaneToggleButton
			// 
			this.DisableCurrentPaneToggleButton.CommandName = "";
			this.DisableCurrentPaneToggleButton.Id = "a0b2a496-c8ac-4ee0-ae40-220f59c7a3cf";
			this.DisableCurrentPaneToggleButton.KeyTip = "DP";
			this.DisableCurrentPaneToggleButton.Location = new System.Drawing.Point(47, 256);
			this.DisableCurrentPaneToggleButton.Name = "DisableCurrentPaneToggleButton";
			this.DisableCurrentPaneToggleButton.ScreenTip.Text = "Disable Current Pane";
			this.DisableCurrentPaneToggleButton.Size = new System.Drawing.Size(167, 23);
			this.DisableCurrentPaneToggleButton.TabIndex = 5;
			this.DisableCurrentPaneToggleButton.Text = "Disable Current Pane";
			this.DisableCurrentPaneToggleButton.Click += new System.EventHandler(this.DisableCurrentPaneButton_Click);
			// 
			// AddPaneToNotificationsAreaButton
			// 
			this.AddPaneToNotificationsAreaButton.CommandName = "";
			this.AddPaneToNotificationsAreaButton.Id = "7495b77a-b8ce-4599-a759-d3d5aa5cb0cd";
			this.AddPaneToNotificationsAreaButton.KeyTip = "N";
			this.AddPaneToNotificationsAreaButton.Location = new System.Drawing.Point(47, 74);
			this.AddPaneToNotificationsAreaButton.Name = "AddPaneToNotificationsAreaButton";
			this.AddPaneToNotificationsAreaButton.ScreenTip.Text = "Add Pane To Notifications Area";
			this.AddPaneToNotificationsAreaButton.Size = new System.Drawing.Size(167, 23);
			this.AddPaneToNotificationsAreaButton.TabIndex = 1;
			this.AddPaneToNotificationsAreaButton.Text = "Add Pane To Notifications Area";
			this.AddPaneToNotificationsAreaButton.Click += new System.EventHandler(this.AddPaneToNotificationsAreaButton_Click);
			// 
			// AddPaneToControlsAreaButton
			// 
			this.AddPaneToControlsAreaButton.CommandName = "";
			this.AddPaneToControlsAreaButton.Id = "75a56a46-8939-4135-875d-15f07206d607";
			this.AddPaneToControlsAreaButton.KeyTip = "C";
			this.AddPaneToControlsAreaButton.Location = new System.Drawing.Point(47, 40);
			this.AddPaneToControlsAreaButton.Name = "AddPaneToControlsAreaButton";
			this.AddPaneToControlsAreaButton.ScreenTip.Text = "Add Pane To Controls Area";
			this.AddPaneToControlsAreaButton.Size = new System.Drawing.Size(167, 23);
			this.AddPaneToControlsAreaButton.TabIndex = 0;
			this.AddPaneToControlsAreaButton.Text = "Add Pane To Controls Area";
			this.AddPaneToControlsAreaButton.Click += new System.EventHandler(this.AddPaneToControlsAreaButton_Click);
			// 
			// StatusBarPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.StatusBarPagePanel);
			this.Name = "StatusBarPage";
			this.Size = new System.Drawing.Size(523, 421);
			this.StatusBarPagePanel.ResumeLayout(false);
			this.StatusBarPagePanel.PerformLayout();
			this.SampleStatusBar.ResumeLayout(false);
			this.SampleStatusBar.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popupMenu1)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Panel StatusBarPagePanel;
        private ToggleButton DisableCurrentPaneToggleButton;
        private Button AddPaneToControlsAreaButton;
        private Button AddLabelButton;
        private Button AddProgressBarButton;
        private Button AddButtonGroupButton;
        private SplitButton AddToggleButtonSplitButton;
        private SplitButton AddButtonSplitButton;
        private ComboBox CurrentPaneComboBox;
        private Button HighlightCurrentPaneButton;
        private Button RemoveCurrentPaneButton;
        private Button AddPaneToNotificationsAreaButton;
        private PopupMenu popupMenu1;
        private Button AddButtonButton;
        private Button AddButtonWithTextButton;
        private PopupMenu popupMenu2;
        private Button AddToggleButtonButton;
        private Button AddToggleButtonWithTextButton;
        private StatusBar SampleStatusBar;
        private StatusBarNotificationsArea SampleStatusBarNotificationsArea;
        private StatusBarControlsArea SampleStatusBarControlsArea;
		private Button AddSliderButton;
    }
}
