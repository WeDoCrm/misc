using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
	partial class SliderPage
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
			this.SliderSettingsGroupBox = new GroupBox();
			this.ShowMinMaxTicksCheckBox = new Elegant.Ui.CheckBox();
			this.OrientationVerticalRadioButton = new Elegant.Ui.RadioButton();
			this.MinimumNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.IsSnapToTickEnabledCheckBox = new Elegant.Ui.CheckBox();
			this.ValueNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.IsMoveToPointEnabledCheckBox = new Elegant.Ui.CheckBox();
			this.MaximumNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.TrackBarRadioButton = new Elegant.Ui.RadioButton();
			this.SmallChangeNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.StyleSliderRadioButton = new Elegant.Ui.RadioButton();
			this.LargeChangeNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.OrientationHorizontalRadioButton = new Elegant.Ui.RadioButton();
			this.TickFrequencyNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.StyleLabel = new Elegant.Ui.Label();
			this.TickStyleComboBox = new Elegant.Ui.ComboBox();
			this.OrientationLable = new Elegant.Ui.Label();
			this.SampleSlider = new Elegant.Ui.Slider();
			this.panel1.SuspendLayout();
			this.SliderSettingsGroupBox.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.MinimumNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SmallChangeNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LargeChangeNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.TickFrequencyNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.panel1.Controls.Add(this.SliderSettingsGroupBox);
			this.panel1.Controls.Add(this.SampleSlider);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(607, 473);
			this.panel1.TabIndex = 0;
			this.panel1.Text = "panel1";
			// 
			// SliderSettingsGroupBox
			// 
			this.SliderSettingsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.SliderSettingsGroupBox.Controls.Add(this.ShowMinMaxTicksCheckBox);
			this.SliderSettingsGroupBox.Controls.Add(this.OrientationVerticalRadioButton);
			this.SliderSettingsGroupBox.Controls.Add(this.MinimumNumericUpDown);
			this.SliderSettingsGroupBox.Controls.Add(this.IsSnapToTickEnabledCheckBox);
			this.SliderSettingsGroupBox.Controls.Add(this.ValueNumericUpDown);
			this.SliderSettingsGroupBox.Controls.Add(this.IsMoveToPointEnabledCheckBox);
			this.SliderSettingsGroupBox.Controls.Add(this.MaximumNumericUpDown);
			this.SliderSettingsGroupBox.Controls.Add(this.TrackBarRadioButton);
			this.SliderSettingsGroupBox.Controls.Add(this.SmallChangeNumericUpDown);
			this.SliderSettingsGroupBox.Controls.Add(this.StyleSliderRadioButton);
			this.SliderSettingsGroupBox.Controls.Add(this.LargeChangeNumericUpDown);
			this.SliderSettingsGroupBox.Controls.Add(this.OrientationHorizontalRadioButton);
			this.SliderSettingsGroupBox.Controls.Add(this.TickFrequencyNumericUpDown);
			this.SliderSettingsGroupBox.Controls.Add(this.StyleLabel);
			this.SliderSettingsGroupBox.Controls.Add(this.TickStyleComboBox);
			this.SliderSettingsGroupBox.Controls.Add(this.OrientationLable);
			this.SliderSettingsGroupBox.Location = new System.Drawing.Point(355, 9);
			this.SliderSettingsGroupBox.Name = "SliderSettingsGroupBox";
			this.SliderSettingsGroupBox.Size = new System.Drawing.Size(237, 454);
			this.SliderSettingsGroupBox.TabIndex = 1;
			this.SliderSettingsGroupBox.TabStop = false;
			this.SliderSettingsGroupBox.Text = "Settings";
			// 
			// ShowMinMaxTicksCheckBox
			// 
			this.ShowMinMaxTicksCheckBox.Checked = true;
			this.ShowMinMaxTicksCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ShowMinMaxTicksCheckBox.Id = "5adf1bc2-6d9b-4cce-a887-c7e1fcedc553";
			this.ShowMinMaxTicksCheckBox.KeyTip = "MM";
			this.ShowMinMaxTicksCheckBox.Location = new System.Drawing.Point(24, 418);
			this.ShowMinMaxTicksCheckBox.Name = "ShowMinMaxTicksCheckBox";
			this.ShowMinMaxTicksCheckBox.ScreenTip.Text = "Determines if ticks should be painted for minimum and maximum values.";
			this.ShowMinMaxTicksCheckBox.Size = new System.Drawing.Size(163, 23);
			this.ShowMinMaxTicksCheckBox.TabIndex = 13;
			this.ShowMinMaxTicksCheckBox.Text = "Show min max ticks";
			this.ShowMinMaxTicksCheckBox.CheckedChanged += new System.EventHandler(this.ShowMinMaxTicksCheckBox_CheckedChanged);
			// 
			// OrientationVerticalRadioButton
			// 
			this.OrientationVerticalRadioButton.Id = "2edfd881-4fbe-4197-8a41-796ae93b4a90";
			this.OrientationVerticalRadioButton.KeyTip = "OV";
			this.OrientationVerticalRadioButton.Location = new System.Drawing.Point(50, 54);
			this.OrientationVerticalRadioButton.Name = "OrientationVerticalRadioButton";
			this.OrientationVerticalRadioButton.RadioGroupName = "Orientation";
			this.OrientationVerticalRadioButton.ScreenTip.Text = "Orientation vertical.";
			this.OrientationVerticalRadioButton.Size = new System.Drawing.Size(117, 23);
			this.OrientationVerticalRadioButton.TabIndex = 1;
			this.OrientationVerticalRadioButton.Text = "Vertical";
			this.OrientationVerticalRadioButton.CheckedChanged += new System.EventHandler(this.OrientationVerticalRadioButton_CheckedChanged);
			// 
			// MinimumNumericUpDown
			// 
			this.MinimumNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.MinimumNumericUpDown.Id = "5fcba3d5-818e-432c-aef3-a3dd80d3ac28";
			this.MinimumNumericUpDown.KeyTip = "MN";
			this.MinimumNumericUpDown.LabelAreaWidthTemplate = "Tick frequency:";
			this.MinimumNumericUpDown.LabelText = "Minimum:";
			this.MinimumNumericUpDown.Location = new System.Drawing.Point(24, 199);
			this.MinimumNumericUpDown.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.MinimumNumericUpDown.Name = "MinimumNumericUpDown";
			this.MinimumNumericUpDown.ScreenTip.Text = "Minimum value of the Slider.";
			this.MinimumNumericUpDown.Size = new System.Drawing.Size(163, 21);
			this.MinimumNumericUpDown.TabIndex = 6;
			this.MinimumNumericUpDown.TextEditorWidth = 63;
			this.MinimumNumericUpDown.ValueChanged += new System.EventHandler(this.MinimumNumericUpDown_ValueChanged);
			// 
			// IsSnapToTickEnabledCheckBox
			// 
			this.IsSnapToTickEnabledCheckBox.Id = "a1416af7-813f-4b2c-a38f-49c61ce6c7c6";
			this.IsSnapToTickEnabledCheckBox.KeyTip = "IS";
			this.IsSnapToTickEnabledCheckBox.Location = new System.Drawing.Point(24, 385);
			this.IsSnapToTickEnabledCheckBox.Name = "IsSnapToTickEnabledCheckBox";
			this.IsSnapToTickEnabledCheckBox.ScreenTip.Text = "Indicates whether the Slider automatically moves the Thumb to the closest tick ma" +
				"rk.";
			this.IsSnapToTickEnabledCheckBox.Size = new System.Drawing.Size(163, 23);
			this.IsSnapToTickEnabledCheckBox.TabIndex = 12;
			this.IsSnapToTickEnabledCheckBox.Text = "Is snap to tick enabled";
			this.IsSnapToTickEnabledCheckBox.CheckedChanged += new System.EventHandler(this.IsSnapToTickEnabledCheckBox_CheckedChanged);
			// 
			// ValueNumericUpDown
			// 
			this.ValueNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.ValueNumericUpDown.Id = "be9c5c8d-d78e-437e-a10d-c9efded67642";
			this.ValueNumericUpDown.KeyTip = "V";
			this.ValueNumericUpDown.LabelAreaWidthTemplate = "Tick frequency:";
			this.ValueNumericUpDown.LabelText = "Value:";
			this.ValueNumericUpDown.Location = new System.Drawing.Point(24, 170);
			this.ValueNumericUpDown.Name = "ValueNumericUpDown";
			this.ValueNumericUpDown.ScreenTip.Text = "Value of the Slider.";
			this.ValueNumericUpDown.Size = new System.Drawing.Size(163, 21);
			this.ValueNumericUpDown.TabIndex = 5;
			this.ValueNumericUpDown.TextEditorWidth = 63;
			this.ValueNumericUpDown.ValueChanged += new System.EventHandler(this.ValueNumericUpDown_ValueChanged);
			// 
			// IsMoveToPointEnabledCheckBox
			// 
			this.IsMoveToPointEnabledCheckBox.Id = "d231e1b3-2109-4ea3-a57a-bab78a1a2bae";
			this.IsMoveToPointEnabledCheckBox.KeyTip = "P";
			this.IsMoveToPointEnabledCheckBox.Location = new System.Drawing.Point(24, 352);
			this.IsMoveToPointEnabledCheckBox.Name = "IsMoveToPointEnabledCheckBox";
			this.IsMoveToPointEnabledCheckBox.ScreenTip.Text = "Indicates whether the Thumb of a Slider moves immediately to the location of the " +
				"mouse click.";
			this.IsMoveToPointEnabledCheckBox.Size = new System.Drawing.Size(163, 23);
			this.IsMoveToPointEnabledCheckBox.TabIndex = 11;
			this.IsMoveToPointEnabledCheckBox.Text = "Is move to point enabled";
			this.IsMoveToPointEnabledCheckBox.CheckedChanged += new System.EventHandler(this.IsMoveToPointEnabledCheckBox_CheckedChanged);
			// 
			// MaximumNumericUpDown
			// 
			this.MaximumNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.MaximumNumericUpDown.Id = "5674af16-4a2d-4f0f-b003-81b867053a0c";
			this.MaximumNumericUpDown.KeyTip = "MX";
			this.MaximumNumericUpDown.LabelAreaWidthTemplate = "Tick frequency:";
			this.MaximumNumericUpDown.LabelText = "Maximum:";
			this.MaximumNumericUpDown.Location = new System.Drawing.Point(24, 230);
			this.MaximumNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.MaximumNumericUpDown.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
			this.MaximumNumericUpDown.Name = "MaximumNumericUpDown";
			this.MaximumNumericUpDown.ScreenTip.Text = "Maximum value of the Slider.";
			this.MaximumNumericUpDown.Size = new System.Drawing.Size(163, 21);
			this.MaximumNumericUpDown.TabIndex = 7;
			this.MaximumNumericUpDown.TextEditorWidth = 63;
			this.MaximumNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.MaximumNumericUpDown.ValueChanged += new System.EventHandler(this.MaximumNumericUpDown_ValueChanged);
			// 
			// TrackBarRadioButton
			// 
			this.TrackBarRadioButton.Id = "784ae017-1323-4857-937e-aef7d71ace52";
			this.TrackBarRadioButton.KeyTip = "ST";
			this.TrackBarRadioButton.Location = new System.Drawing.Point(50, 141);
			this.TrackBarRadioButton.Name = "TrackBarRadioButton";
			this.TrackBarRadioButton.RadioGroupName = "Style";
			this.TrackBarRadioButton.ScreenTip.Text = "Style track bar.";
			this.TrackBarRadioButton.Size = new System.Drawing.Size(117, 23);
			this.TrackBarRadioButton.TabIndex = 4;
			this.TrackBarRadioButton.Text = "Track bar";
			this.TrackBarRadioButton.CheckedChanged += new System.EventHandler(this.TrackBarRadioButton_CheckedChanged);
			// 
			// SmallChangeNumericUpDown
			// 
			this.SmallChangeNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.SmallChangeNumericUpDown.Id = "f9e56dba-98c9-464f-a28b-7928d7a9f4e4";
			this.SmallChangeNumericUpDown.KeyTip = "SC";
			this.SmallChangeNumericUpDown.LabelAreaWidthTemplate = "Tick frequency:";
			this.SmallChangeNumericUpDown.LabelText = "Small change:";
			this.SmallChangeNumericUpDown.Location = new System.Drawing.Point(24, 261);
			this.SmallChangeNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.SmallChangeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SmallChangeNumericUpDown.Name = "SmallChangeNumericUpDown";
			this.SmallChangeNumericUpDown.ScreenTip.Text = "Value added to or subtracted from the Value property when the scroll box is moved" +
				" a small distance.";
			this.SmallChangeNumericUpDown.Size = new System.Drawing.Size(163, 21);
			this.SmallChangeNumericUpDown.TabIndex = 8;
			this.SmallChangeNumericUpDown.TextEditorWidth = 63;
			this.SmallChangeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.SmallChangeNumericUpDown.ValueChanged += new System.EventHandler(this.SmallChangeNumericUpDown_ValueChanged);
			// 
			// StyleSliderRadioButton
			// 
			this.StyleSliderRadioButton.Checked = true;
			this.StyleSliderRadioButton.Id = "b1adb311-7d9e-4875-a8a0-3021d5fc65fd";
			this.StyleSliderRadioButton.KeyTip = "SS";
			this.StyleSliderRadioButton.Location = new System.Drawing.Point(50, 119);
			this.StyleSliderRadioButton.Name = "StyleSliderRadioButton";
			this.StyleSliderRadioButton.RadioGroupName = "Style";
			this.StyleSliderRadioButton.ScreenTip.Text = "Style slider.";
			this.StyleSliderRadioButton.Size = new System.Drawing.Size(117, 23);
			this.StyleSliderRadioButton.TabIndex = 3;
			this.StyleSliderRadioButton.Text = "Slider";
			this.StyleSliderRadioButton.CheckedChanged += new System.EventHandler(this.StyleSliderRadioButton_CheckedChanged);
			// 
			// LargeChangeNumericUpDown
			// 
			this.LargeChangeNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.LargeChangeNumericUpDown.Id = "0bae85ba-2b74-44ab-9fd3-e0d9bcd3d80e";
			this.LargeChangeNumericUpDown.KeyTip = "LC";
			this.LargeChangeNumericUpDown.LabelAreaWidthTemplate = "Tick frequency:";
			this.LargeChangeNumericUpDown.LabelText = "Large change:";
			this.LargeChangeNumericUpDown.Location = new System.Drawing.Point(24, 290);
			this.LargeChangeNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.LargeChangeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.LargeChangeNumericUpDown.Name = "LargeChangeNumericUpDown";
			this.LargeChangeNumericUpDown.ScreenTip.Text = "Value to be added to or subtracted from the Value property when the scroll box is" +
				" moved a large distance.";
			this.LargeChangeNumericUpDown.Size = new System.Drawing.Size(163, 21);
			this.LargeChangeNumericUpDown.TabIndex = 9;
			this.LargeChangeNumericUpDown.TextEditorWidth = 63;
			this.LargeChangeNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
			this.LargeChangeNumericUpDown.ValueChanged += new System.EventHandler(this.LargeChangeNumericUpDown_ValueChanged);
			// 
			// OrientationHorizontalRadioButton
			// 
			this.OrientationHorizontalRadioButton.Checked = true;
			this.OrientationHorizontalRadioButton.Id = "fcd0bd39-d68e-44a7-b9f2-f21bcf8c59ae";
			this.OrientationHorizontalRadioButton.KeyTip = "OH";
			this.OrientationHorizontalRadioButton.Location = new System.Drawing.Point(50, 33);
			this.OrientationHorizontalRadioButton.Name = "OrientationHorizontalRadioButton";
			this.OrientationHorizontalRadioButton.RadioGroupName = "Orientation";
			this.OrientationHorizontalRadioButton.ScreenTip.Text = "Orientation horizontal.";
			this.OrientationHorizontalRadioButton.Size = new System.Drawing.Size(117, 23);
			this.OrientationHorizontalRadioButton.TabIndex = 0;
			this.OrientationHorizontalRadioButton.Text = "Horizontal";
			this.OrientationHorizontalRadioButton.CheckedChanged += new System.EventHandler(this.OrientationHorizontalRadioButton_CheckedChanged);
			// 
			// TickFrequencyNumericUpDown
			// 
			this.TickFrequencyNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.TickFrequencyNumericUpDown.Id = "4b7a4d0b-ca8e-476d-a20f-af72e05b6eba";
			this.TickFrequencyNumericUpDown.KeyTip = "F";
			this.TickFrequencyNumericUpDown.LabelAreaWidthTemplate = "Tick frequency:";
			this.TickFrequencyNumericUpDown.LabelText = "Tick frequency:";
			this.TickFrequencyNumericUpDown.Location = new System.Drawing.Point(24, 320);
			this.TickFrequencyNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.TickFrequencyNumericUpDown.Name = "TickFrequencyNumericUpDown";
			this.TickFrequencyNumericUpDown.ScreenTip.Text = "Value that specifies the delta between ticks drawn on the track.";
			this.TickFrequencyNumericUpDown.Size = new System.Drawing.Size(163, 21);
			this.TickFrequencyNumericUpDown.TabIndex = 10;
			this.TickFrequencyNumericUpDown.TextEditorWidth = 63;
			this.TickFrequencyNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.TickFrequencyNumericUpDown.ValueChanged += new System.EventHandler(this.TickFrequencyNumericUpDown_ValueChanged);
			// 
			// StyleLabel
			// 
			this.StyleLabel.Location = new System.Drawing.Point(24, 105);
			this.StyleLabel.Name = "StyleLabel";
			this.StyleLabel.Size = new System.Drawing.Size(163, 20);
			this.StyleLabel.TabIndex = 4;
			this.StyleLabel.Text = "Style:";
			// 
			// TickStyleComboBox
			// 
			this.TickStyleComboBox.Editable = false;
			this.TickStyleComboBox.FormattingEnabled = false;
			this.TickStyleComboBox.Id = "10eb4f09-4889-4dda-b918-6199e75f29de";
			this.TickStyleComboBox.KeyTip = "T";
			this.TickStyleComboBox.LabelText = "Tick style:";
			this.TickStyleComboBox.Location = new System.Drawing.Point(24, 81);
			this.TickStyleComboBox.Name = "TickStyleComboBox";
			this.TickStyleComboBox.ScreenTip.Text = "Indicating how to display the tick marks on the slider.";
			this.TickStyleComboBox.Size = new System.Drawing.Size(163, 21);
			this.TickStyleComboBox.TabIndex = 2;
			this.TickStyleComboBox.TextEditorWidth = 93;
			// 
			// OrientationLable
			// 
			this.OrientationLable.Location = new System.Drawing.Point(24, 18);
			this.OrientationLable.Name = "OrientationLable";
			this.OrientationLable.Size = new System.Drawing.Size(163, 20);
			this.OrientationLable.TabIndex = 0;
			this.OrientationLable.Text = "Orientation:";
			// 
			// SampleSlider
			// 
			this.SampleSlider.Id = "ae8d1bec-df5d-4e63-9bad-e159c3eafef7";
			this.SampleSlider.KeyTip = "ZS";
			this.SampleSlider.Location = new System.Drawing.Point(16, 20);
			this.SampleSlider.Maximum = 100;
			this.SampleSlider.Name = "SampleSlider";
			this.SampleSlider.NextButtonScreenTipData.Text = "Zoom in";
			this.SampleSlider.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.SampleSlider.PreviousButtonScreenTipData.Text = "Zoom out";
			this.SampleSlider.ScreenTip.Text = "Slider";
			this.SampleSlider.Size = new System.Drawing.Size(325, 24);
			this.SampleSlider.TabIndex = 0;
			this.SampleSlider.Text = "slider1";
			this.SampleSlider.ThumbScreenTipData.Text = "Thumb";
			this.SampleSlider.TickFrequency = 50;
			// 
			// SliderPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "SliderPage";
			this.Size = new System.Drawing.Size(607, 473);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.SliderSettingsGroupBox.ResumeLayout(false);
			this.SliderSettingsGroupBox.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.MinimumNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ValueNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SmallChangeNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LargeChangeNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.TickFrequencyNumericUpDown)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private Slider SampleSlider;
		private NumericUpDown ValueNumericUpDown;
		private ComboBox TickStyleComboBox;
		private RadioButton OrientationVerticalRadioButton;
		private RadioButton OrientationHorizontalRadioButton;
		private Label OrientationLable;
		private CheckBox IsSnapToTickEnabledCheckBox;
		private CheckBox IsMoveToPointEnabledCheckBox;
		private CheckBox ShowMinMaxTicksCheckBox;
		private NumericUpDown TickFrequencyNumericUpDown;
		private NumericUpDown LargeChangeNumericUpDown;
		private NumericUpDown SmallChangeNumericUpDown;
		private NumericUpDown MinimumNumericUpDown;
		private NumericUpDown MaximumNumericUpDown;
		private RadioButton TrackBarRadioButton;
		private RadioButton StyleSliderRadioButton;
		private Label StyleLabel;
		private Panel panel1;
		private GroupBox SliderSettingsGroupBox;
	}
}
