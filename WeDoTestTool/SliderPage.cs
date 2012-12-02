using System;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class SliderPage : SamplePageBase
	{
		public SliderPage()
		{
			InitializeComponent();
			InitializeTickStyleComboBox();
            SampleSlider.ValueChanged += SampleSlider_ValueChanged;
		}

        private void SampleSlider_ValueChanged(object sender, SliderValueChangedEventArgs e)
        {
            ValueNumericUpDown.Value = SampleSlider.Value;
        }

		private void InitializeTickStyleComboBox()
		{
			TickStyleComboBox.DataSource = Enum.GetValues(typeof(TickStyle));
			TickStyleComboBox.SelectedIndexChanged += TickStyleComboBox_SelectedIndexChanged;
			TickStyleComboBox.SelectedItem = SampleSlider.TickStyle;
		}

		void TickStyleComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SampleSlider.TickStyle = (TickStyle)TickStyleComboBox.SelectedItem;
		}

		private void OrientationHorizontalRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (OrientationHorizontalRadioButton.Checked)
				SampleSlider.Orientation = Orientation.Horizontal;
		}

		private void OrientationVerticalRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (OrientationVerticalRadioButton.Checked)
				SampleSlider.Orientation = Orientation.Vertical;
		}

		private void StyleSliderRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (StyleSliderRadioButton.Checked)
				SampleSlider.Style = SliderStyle.ZoomBar;
		}

		private void TrackBarRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (TrackBarRadioButton.Checked)
				SampleSlider.Style = SliderStyle.TrackBar;
		}

		private void ValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			SampleSlider.Value = (int) ValueNumericUpDown.Value;
		}

		private void MaximumNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			decimal maximumValue = MaximumNumericUpDown.Value;
			SampleSlider.Maximum = (int) maximumValue;
			ValueNumericUpDown.Maximum = maximumValue;
			MinimumNumericUpDown.Maximum = maximumValue;
		}

		private void SmallChangeNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			SampleSlider.SmallChange = (int)SmallChangeNumericUpDown.Value;
		}

		private void LargeChangeNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			SampleSlider.LargeChange = (int) LargeChangeNumericUpDown.Value;
		}

		private void TickFrequencyNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			SampleSlider.TickFrequency = (int) TickFrequencyNumericUpDown.Value;
		}

		private void IsMoveToPointEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleSlider.IsMoveToPointEnabled = IsMoveToPointEnabledCheckBox.Checked;
		}

		private void IsSnapToTickEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleSlider.IsSnapToTickEnabled = IsSnapToTickEnabledCheckBox.Checked;
		}

		private void ShowMinMaxTicksCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleSlider.ShowMinMaxTicks = ShowMinMaxTicksCheckBox.Checked;
		}

		private void MinimumNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			int minimumValue = (int)MinimumNumericUpDown.Value;

			if (SampleSlider.Value < minimumValue)
				SampleSlider.Value = minimumValue;

			SampleSlider.Minimum = minimumValue;
		}
	}
}
