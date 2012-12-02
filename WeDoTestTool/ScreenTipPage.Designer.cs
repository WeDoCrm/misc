namespace Elegant.Ui.Samples.ControlsSample
{
	partial class ScreenTipPage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenTipPage));
			this.panel1 = new Elegant.Ui.Panel();
			this.controlsSampleGroupBox1 = new GroupBox();
			this.ImageScaleModeComboBox = new Elegant.Ui.ComboBox();
			this.ImageCheckBox = new Elegant.Ui.CheckBox();
			this.CaptionTextBox = new Elegant.Ui.TextBox();
			this.ImagePathButton = new Elegant.Ui.Button();
			this.TextTextBox = new Elegant.Ui.TextBox();
			this.ImageTextBox = new Elegant.Ui.TextBox();
			this.ScreenTipPanel = new Elegant.Ui.Panel();
			this.ScreenTipPanelLabel = new Elegant.Ui.Label();
			this.ImagePathErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
			this.ImageFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.panel1.SuspendLayout();
			this.controlsSampleGroupBox1.SuspendLayout();
			this.ScreenTipPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ImagePathErrorProvider)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.controlsSampleGroupBox1);
			this.panel1.Controls.Add(this.ScreenTipPanel);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Id = "b0d9ce13-8bfa-4a99-b357-3b3e205a82c2";
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(642, 450);
			this.panel1.TabIndex = 0;
			this.panel1.Text = "panel1";
			// 
			// controlsSampleGroupBox1
			// 
			this.controlsSampleGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.controlsSampleGroupBox1.Controls.Add(this.ImageScaleModeComboBox);
			this.controlsSampleGroupBox1.Controls.Add(this.ImageCheckBox);
			this.controlsSampleGroupBox1.Controls.Add(this.CaptionTextBox);
			this.controlsSampleGroupBox1.Controls.Add(this.ImagePathButton);
			this.controlsSampleGroupBox1.Controls.Add(this.TextTextBox);
			this.controlsSampleGroupBox1.Controls.Add(this.ImageTextBox);
			this.controlsSampleGroupBox1.Location = new System.Drawing.Point(221, 15);
			this.controlsSampleGroupBox1.Name = "controlsSampleGroupBox1";
			this.controlsSampleGroupBox1.Size = new System.Drawing.Size(403, 167);
			this.controlsSampleGroupBox1.TabIndex = 16;
			this.controlsSampleGroupBox1.TabStop = false;
			this.controlsSampleGroupBox1.Text = "Settings";
			// 
			// ImageScaleModeComboBox
			// 
			this.ImageScaleModeComboBox.DrawMode = System.Windows.Forms.DrawMode.Normal;
			this.ImageScaleModeComboBox.DroppedDown = false;
			this.ImageScaleModeComboBox.Editable = false;
			this.ImageScaleModeComboBox.FormatInfo = null;
			this.ImageScaleModeComboBox.FormatString = "";
			this.ImageScaleModeComboBox.FormattingEnabled = false;
			this.ImageScaleModeComboBox.Id = "815deced-c034-41d9-baf0-3faf76efd8d3";
			this.ImageScaleModeComboBox.LabelText = "Image scale mode:";
			this.ImageScaleModeComboBox.Location = new System.Drawing.Point(16, 94);
			this.ImageScaleModeComboBox.Name = "ImageScaleModeComboBox";
			this.ImageScaleModeComboBox.Size = new System.Drawing.Size(371, 21);
			this.ImageScaleModeComboBox.Sorted = false;
			this.ImageScaleModeComboBox.TabIndex = 2;
			this.ImageScaleModeComboBox.TextEditorWidth = 352;
			// 
			// ImageCheckBox
			// 
			this.ImageCheckBox.Checked = true;
			this.ImageCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ImageCheckBox.Id = "32850029-8c92-4215-92e0-94124d0c9e6a";
			this.ImageCheckBox.KeyTip = "UI";
			this.ImageCheckBox.Location = new System.Drawing.Point(16, 130);
			this.ImageCheckBox.Name = "ImageCheckBox";
			this.ImageCheckBox.ScreenTip.Text = "Enable image in screen tip";
			this.ImageCheckBox.Size = new System.Drawing.Size(16, 23);
			this.ImageCheckBox.TabIndex = 3;
			this.ImageCheckBox.CheckedChanged += new System.EventHandler(this.ImageCheckBox_CheckedChanged);
			// 
			// CaptionTextBox
			// 
			this.CaptionTextBox.Id = "9ad8427e-1bb1-4604-a06f-ff62a1e8a6c9";
			this.CaptionTextBox.InformativenessFixedLevel = "Elegant.Ui.TextBoxInformativenessLevel:TextBoxWithLabel";
			this.CaptionTextBox.KeyTip = "C";
			this.CaptionTextBox.LabelAreaWidthTemplate = "Image scale mode:";
			this.CaptionTextBox.LabelText = "Caption:";
			this.CaptionTextBox.Location = new System.Drawing.Point(16, 26);
			this.CaptionTextBox.Name = "CaptionTextBox";
			this.CaptionTextBox.ScreenTip.Text = "Screen tip caption";
			this.CaptionTextBox.Size = new System.Drawing.Size(371, 21);
			this.CaptionTextBox.TabIndex = 0;
			this.CaptionTextBox.Text = "Sample Screen Tip";
			this.CaptionTextBox.TextEditorWidth = 273;
			this.CaptionTextBox.TextChanged += new System.EventHandler(this.CaptionTextBox_TextChanged);
			// 
			// ImagePathButton
			// 
			this.ImagePathButton.Id = "281b6748-0a6c-4688-bea5-2843ce8d310c";
			this.ImagePathButton.KeyTip = "BI";
			this.ImagePathButton.Location = new System.Drawing.Point(363, 131);
			this.ImagePathButton.Name = "ImagePathButton";
			this.ImagePathButton.ScreenTip.Text = "Browse for images";
			this.ImagePathButton.Size = new System.Drawing.Size(24, 21);
			this.ImagePathButton.TabIndex = 5;
			this.ImagePathButton.Text = "...";
			this.ImagePathButton.Click += new System.EventHandler(this.ImagePathButton_Click);
			// 
			// TextTextBox
			// 
			this.TextTextBox.Id = "f7857a8a-2d7a-49af-b62d-042a153f863f";
			this.TextTextBox.InformativenessFixedLevel = "Elegant.Ui.TextBoxInformativenessLevel:TextBoxWithLabel";
			this.TextTextBox.KeyTip = "T";
			this.TextTextBox.LabelAreaWidthTemplate = "Image scale mode:";
			this.TextTextBox.LabelText = "Text:";
			this.TextTextBox.Location = new System.Drawing.Point(16, 60);
			this.TextTextBox.Name = "TextTextBox";
			this.TextTextBox.ScreenTip.Text = "Screen tip text";
			this.TextTextBox.Size = new System.Drawing.Size(371, 21);
			this.TextTextBox.TabIndex = 1;
			this.TextTextBox.Text = resources.GetString("TextTextBox.Text");
			this.TextTextBox.TextEditorWidth = 273;
			this.TextTextBox.TextChanged += new System.EventHandler(this.TextTextBox_TextChanged);
			// 
			// ImageTextBox
			// 
			this.ImageTextBox.BannerText = "Image path";
			this.ImageTextBox.Id = "4b4b26fa-9201-46df-bfa0-ece81807e298";
			this.ImageTextBox.InformativenessFixedLevel = "Elegant.Ui.TextBoxInformativenessLevel:TextBoxWithLabel";
			this.ImageTextBox.KeyTip = "I";
			this.ImageTextBox.LabelAreaWidthTemplate = "Caption:";
			this.ImageTextBox.LabelText = "Image:";
			this.ImageTextBox.Location = new System.Drawing.Point(33, 131);
			this.ImageTextBox.Name = "ImageTextBox";
			this.ImageTextBox.ScreenTip.Text = "Path to an image for screen tip";
			this.ImageTextBox.Size = new System.Drawing.Size(325, 21);
			this.ImageTextBox.TabIndex = 4;
			this.ImageTextBox.TextEditorWidth = 277;
			this.ImageTextBox.TextChanged += new System.EventHandler(this.ImageTextBox_TextChanged);
			// 
			// ScreenTipPanel
			// 
			this.ScreenTipPanel.BackColor = System.Drawing.SystemColors.Window;
			this.ScreenTipPanel.Controls.Add(this.ScreenTipPanelLabel);
			this.ScreenTipPanel.Id = "f784c688-4562-446d-b316-5f52f34930dc";
			this.ScreenTipPanel.Location = new System.Drawing.Point(15, 23);
			this.ScreenTipPanel.Name = "ScreenTipPanel";
			this.ScreenTipPanel.Size = new System.Drawing.Size(168, 121);
			this.ScreenTipPanel.TabIndex = 9;
			this.ScreenTipPanel.UseVisualThemeForBackground = false;
			// 
			// ScreenTipPanelLabel
			// 
			this.ScreenTipPanelLabel.AutoSize = false;
			this.ScreenTipPanelLabel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ScreenTipPanelLabel.Id = "25fcdb50-61c3-400b-89be-44a6967affb1";
			this.ScreenTipPanelLabel.Location = new System.Drawing.Point(0, 0);
			this.ScreenTipPanelLabel.Name = "ScreenTipPanelLabel";
			this.ScreenTipPanelLabel.Padding = new System.Windows.Forms.Padding(15, 0, 15, 0);
			this.ScreenTipPanelLabel.ScreenTip.Caption = "Sample Screen Tip";
			this.ScreenTipPanelLabel.ScreenTip.Image = global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Sun;
			this.ScreenTipPanelLabel.ScreenTip.Text = resources.GetString("ScreenTipPanelLabel.ScreenTip.Text");
			this.ScreenTipPanelLabel.Size = new System.Drawing.Size(168, 121);
			this.ScreenTipPanelLabel.TabIndex = 0;
			this.ScreenTipPanelLabel.Text = "Hover mouse here to show screen tip";
			this.ScreenTipPanelLabel.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ImagePathErrorProvider
			// 
			this.ImagePathErrorProvider.ContainerControl = this;
			// 
			// ScreenTipPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "ScreenTipPage";
			this.Size = new System.Drawing.Size(642, 450);
			this.panel1.ResumeLayout(false);
			this.controlsSampleGroupBox1.ResumeLayout(false);
			this.controlsSampleGroupBox1.PerformLayout();
			this.ScreenTipPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.ImagePathErrorProvider)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private Panel ScreenTipPanel;
		private Label ScreenTipPanelLabel;
		private TextBox ImageTextBox;
		private TextBox TextTextBox;
		private TextBox CaptionTextBox;
		private Button ImagePathButton;
		private System.Windows.Forms.ErrorProvider ImagePathErrorProvider;
		private System.Windows.Forms.OpenFileDialog ImageFileDialog;
		private CheckBox ImageCheckBox;
		private GroupBox controlsSampleGroupBox1;
		private ComboBox ImageScaleModeComboBox;
	}
}
