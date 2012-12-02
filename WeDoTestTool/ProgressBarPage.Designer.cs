namespace Elegant.Ui.Samples.ControlsSample
{
	partial class ProgressBarPage
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
			this.panel1 = new Elegant.Ui.Panel();
			this.controlsSampleGroupBox1 = new GroupBox();
			this.ValueNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.label1 = new Elegant.Ui.Label();
			this.ContinuousRadioButton = new Elegant.Ui.RadioButton();
			this.MarqueeAnimationSpeedNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.MarqueeRadioButton = new Elegant.Ui.RadioButton();
			this.BlocksRadioButton = new Elegant.Ui.RadioButton();
			this.RunProgressButton = new Elegant.Ui.Button();
			this.SampleProgressBar = new Elegant.Ui.ProgressBar();
			this.StopProgressBarButton = new Elegant.Ui.Button();
			this.panel1.SuspendLayout();
			this.controlsSampleGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.ValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MarqueeAnimationSpeedNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.controlsSampleGroupBox1);
			this.panel1.Controls.Add(this.RunProgressButton);
			this.panel1.Controls.Add(this.SampleProgressBar);
			this.panel1.Controls.Add(this.StopProgressBarButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Id = "c0d7a90a-0f7d-4f23-9a75-3430891a8d94";
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(499, 234);
			this.panel1.TabIndex = 0;
			this.panel1.Text = "panel1";
			// 
			// controlsSampleGroupBox1
			// 
			this.controlsSampleGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.controlsSampleGroupBox1.Controls.Add(this.ValueNumericUpDown);
			this.controlsSampleGroupBox1.Controls.Add(this.label1);
			this.controlsSampleGroupBox1.Controls.Add(this.ContinuousRadioButton);
			this.controlsSampleGroupBox1.Controls.Add(this.MarqueeAnimationSpeedNumericUpDown);
			this.controlsSampleGroupBox1.Controls.Add(this.MarqueeRadioButton);
			this.controlsSampleGroupBox1.Controls.Add(this.BlocksRadioButton);
			this.controlsSampleGroupBox1.Location = new System.Drawing.Point(230, 19);
			this.controlsSampleGroupBox1.Name = "controlsSampleGroupBox1";
			this.controlsSampleGroupBox1.Size = new System.Drawing.Size(252, 187);
			this.controlsSampleGroupBox1.TabIndex = 15;
			this.controlsSampleGroupBox1.TabStop = false;
			this.controlsSampleGroupBox1.Text = "Settings";
			// 
			// ValueNumericUpDown
			// 
			this.ValueNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.ValueNumericUpDown.EditorImage = null;
			this.ValueNumericUpDown.Id = "55663b41-77b6-4998-9528-ba9ed652cd90";
			this.ValueNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithLabel";
			this.ValueNumericUpDown.KeyTip = "V";
			this.ValueNumericUpDown.LabelAreaWidthTemplate = "Marquee animation speed";
			this.ValueNumericUpDown.LabelText = "Progress value";
			this.ValueNumericUpDown.Location = new System.Drawing.Point(23, 124);
			this.ValueNumericUpDown.Name = "ValueNumericUpDown";
			this.ValueNumericUpDown.ScreenTip.Text = "Progress bar value";
			this.ValueNumericUpDown.Size = new System.Drawing.Size(178, 21);
			this.ValueNumericUpDown.TabIndex = 4;
			this.ValueNumericUpDown.TextEditorWidth = 30;
			this.ValueNumericUpDown.Value = new decimal(new int[] {
            35,
            0,
            0,
            0});
			this.ValueNumericUpDown.ValueChanged += new System.EventHandler(this.ValueNumericUpDown_ValueChanged);
			// 
			// label1
			// 
			this.label1.Id = "b75969d9-0c9d-4867-a981-0e0e3466502a";
			this.label1.Location = new System.Drawing.Point(23, 27);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(33, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Style:";
			// 
			// ContinuousRadioButton
			// 
			this.ContinuousRadioButton.Checked = true;
			this.ContinuousRadioButton.Id = "6813283b-2d9c-4043-8c98-7649ae8f97f7";
			this.ContinuousRadioButton.KeyTip = "C";
			this.ContinuousRadioButton.Location = new System.Drawing.Point(36, 44);
			this.ContinuousRadioButton.Name = "ContinuousRadioButton";
			this.ContinuousRadioButton.RadioGroupName = "ProgressBarStyleGroup";
			this.ContinuousRadioButton.ScreenTip.Text = "Continuous";
			this.ContinuousRadioButton.Size = new System.Drawing.Size(75, 23);
			this.ContinuousRadioButton.TabIndex = 1;
			this.ContinuousRadioButton.Text = "Continuous";
			this.ContinuousRadioButton.CheckedChanged += new System.EventHandler(this.ContinuousRadioButton_CheckedChanged);
			// 
			// MarqueeAnimationSpeedNumericUpDown
			// 
			this.MarqueeAnimationSpeedNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.MarqueeAnimationSpeedNumericUpDown.EditorImage = null;
			this.MarqueeAnimationSpeedNumericUpDown.Enabled = false;
			this.MarqueeAnimationSpeedNumericUpDown.Id = "5fd92d48-dac0-41c4-8128-ea7f46fd1fce";
			this.MarqueeAnimationSpeedNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.MarqueeAnimationSpeedNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithLabel";
			this.MarqueeAnimationSpeedNumericUpDown.KeyTip = "S";
			this.MarqueeAnimationSpeedNumericUpDown.LabelText = "Marquee animation speed";
			this.MarqueeAnimationSpeedNumericUpDown.Location = new System.Drawing.Point(23, 155);
			this.MarqueeAnimationSpeedNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
			this.MarqueeAnimationSpeedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MarqueeAnimationSpeedNumericUpDown.Name = "MarqueeAnimationSpeedNumericUpDown";
			this.MarqueeAnimationSpeedNumericUpDown.ScreenTip.Text = "Marquee animtion speed";
			this.MarqueeAnimationSpeedNumericUpDown.Size = new System.Drawing.Size(178, 21);
			this.MarqueeAnimationSpeedNumericUpDown.TabIndex = 5;
			this.MarqueeAnimationSpeedNumericUpDown.TextEditorWidth = 30;
			this.MarqueeAnimationSpeedNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.MarqueeAnimationSpeedNumericUpDown.ValueChanged += new System.EventHandler(this.MarqueeAnomationSpeedNumericUpDown_ValueChanged);
			// 
			// MarqueeRadioButton
			// 
			this.MarqueeRadioButton.Id = "ca4c356c-f2ba-48cd-afed-d210184625d8";
			this.MarqueeRadioButton.KeyTip = "M";
			this.MarqueeRadioButton.Location = new System.Drawing.Point(36, 96);
			this.MarqueeRadioButton.Name = "MarqueeRadioButton";
			this.MarqueeRadioButton.RadioGroupName = "ProgressBarStyleGroup";
			this.MarqueeRadioButton.ScreenTip.Text = "Marquee";
			this.MarqueeRadioButton.Size = new System.Drawing.Size(75, 23);
			this.MarqueeRadioButton.TabIndex = 3;
			this.MarqueeRadioButton.Text = "Marquee";
			this.MarqueeRadioButton.CheckedChanged += new System.EventHandler(this.MarqueeRadioButton_CheckedChanged);
			// 
			// BlocksRadioButton
			// 
			this.BlocksRadioButton.Id = "5209a29e-47f8-47ba-8c2a-5ec8c671d464";
			this.BlocksRadioButton.KeyTip = "B";
			this.BlocksRadioButton.Location = new System.Drawing.Point(36, 70);
			this.BlocksRadioButton.Name = "BlocksRadioButton";
			this.BlocksRadioButton.RadioGroupName = "ProgressBarStyleGroup";
			this.BlocksRadioButton.ScreenTip.Text = "Blocks";
			this.BlocksRadioButton.Size = new System.Drawing.Size(75, 23);
			this.BlocksRadioButton.TabIndex = 2;
			this.BlocksRadioButton.Text = "Blocks";
			this.BlocksRadioButton.CheckedChanged += new System.EventHandler(this.BlocksRadioButton_CheckedChanged);
			// 
			// RunProgressButton
			// 
			this.RunProgressButton.Id = "21ac39da-3ed4-4e5d-830b-d9f3b1ee1060";
			this.RunProgressButton.KeyTip = "R";
			this.RunProgressButton.Location = new System.Drawing.Point(15, 83);
			this.RunProgressButton.Name = "RunProgressButton";
			this.RunProgressButton.ScreenTip.Text = "Run the progress bar";
			this.RunProgressButton.Size = new System.Drawing.Size(75, 23);
			this.RunProgressButton.TabIndex = 1;
			this.RunProgressButton.Text = "Run";
			this.RunProgressButton.Click += new System.EventHandler(this.RunStopProgressButton_Click);
			// 
			// SampleProgressBar
			// 
			this.SampleProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.SampleProgressBar.DesiredWidth = 197;
			this.SampleProgressBar.Id = "df189e4e-f760-4410-8339-657f6563ec55";
			this.SampleProgressBar.Location = new System.Drawing.Point(15, 37);
			this.SampleProgressBar.Name = "SampleProgressBar";
			this.SampleProgressBar.ScreenTip.Text = "Progress bar";
			this.SampleProgressBar.Size = new System.Drawing.Size(197, 23);
			this.SampleProgressBar.TabIndex = 0;
			this.SampleProgressBar.TabStop = false;
			this.SampleProgressBar.Text = "progressBar1";
			this.SampleProgressBar.Value = 35;
			// 
			// StopProgressBarButton
			// 
			this.StopProgressBarButton.Id = "4cceae62-ed77-4ae8-8d40-109e42c3a24c";
			this.StopProgressBarButton.KeyTip = "S";
			this.StopProgressBarButton.Location = new System.Drawing.Point(15, 83);
			this.StopProgressBarButton.Name = "StopProgressBarButton";
			this.StopProgressBarButton.Size = new System.Drawing.Size(75, 23);
			this.StopProgressBarButton.TabIndex = 1;
			this.StopProgressBarButton.Text = "Stop";
			this.StopProgressBarButton.Click += new System.EventHandler(this.RunStopProgressButton_Click);
			// 
			// ProgressBarPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "ProgressBarPage";
			this.Size = new System.Drawing.Size(499, 234);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.controlsSampleGroupBox1.ResumeLayout(false);
			this.controlsSampleGroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.ValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MarqueeAnimationSpeedNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private ProgressBar SampleProgressBar;
		private NumericUpDown MarqueeAnimationSpeedNumericUpDown;
		private RadioButton ContinuousRadioButton;
		private RadioButton BlocksRadioButton;
		private Label label1;
		private NumericUpDown ValueNumericUpDown;
		private Button RunProgressButton;
		private RadioButton MarqueeRadioButton;
        private Button StopProgressBarButton;
		private GroupBox controlsSampleGroupBox1;
	}
}
