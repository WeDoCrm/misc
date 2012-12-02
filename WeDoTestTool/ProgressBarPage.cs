using System;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class ProgressBarPage : SamplePageBase
	{
		public ProgressBarPage()
		{
			InitializeComponent();
			_progressTimer = new Timer();
			_progressTimer.Interval = 15;
			_progressTimer.Tick += ProgressTimer_Tick;
		}

        private readonly Timer _progressTimer;

		private void ProgressTimer_Tick(object sender, EventArgs e)
		{
			if (SampleProgressBar.Value == SampleProgressBar.Maximum)
				SampleProgressBar.Value = 0;

			SampleProgressBar.Value += 1;
		}

		private void BlocksRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SampleProgressBar.Style = ProgressBarStyle.Blocks;
		}

		private void ContinuousRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			SampleProgressBar.Style = ProgressBarStyle.Continuous;
		}

		private void MarqueeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (MarqueeRadioButton.Checked)
			{
				_progressTimer.Stop();
				SampleProgressBar.Style = ProgressBarStyle.Marquee;
			}
			else
			{
                ToggleProgressBar();
			}

			MarqueeAnimationSpeedNumericUpDown.Enabled = MarqueeRadioButton.Checked;
			ValueNumericUpDown.Enabled = !(MarqueeRadioButton.Checked || _progressRunning);
			RunProgressButton.Enabled = StopProgressBarButton.Enabled = !MarqueeRadioButton.Checked;
		}

		private void ValueNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			SampleProgressBar.Value = (int)ValueNumericUpDown.Value;
		}

		private void MarqueeAnomationSpeedNumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			SampleProgressBar.MarqueeAnimationSpeed = (int)MarqueeAnimationSpeedNumericUpDown.Value;
		}

		private bool _progressRunning;

		private void RunStopProgressButton_Click(object sender, EventArgs e)
		{
			_progressRunning = !_progressRunning;
		    RunProgressButton.Visible = !(StopProgressBarButton.Visible = _progressRunning);
            ToggleProgressBar();
		}

		private void ToggleProgressBar()
		{
			ValueNumericUpDown.Enabled = !_progressRunning;

			if (_progressRunning)
			{
				_progressTimer.Stop();
				_progressTimer.Start();
			}
			else
			{
				_progressTimer.Stop();
				ValueNumericUpDown.Value = SampleProgressBar.Value;
			}
		}
	}
}
