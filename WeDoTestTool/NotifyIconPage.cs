using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class NotifyIconPage : SamplePageBase
    {
        private readonly OpenFileDialog _openFileDialog;
        private readonly Timer _animatedIconTimer;
        private int _animatedIconIndex;
        private int _eventsCounter;
        private Icon _currentIcon;

        public NotifyIconPage()
        {
            InitializeComponent();

            MainForm.SetMonospaceFont(MouseIconEventsTextBox);

            _openFileDialog = new OpenFileDialog();
//            _openFileDialog.InitialDirectory = "c:\\";
            _openFileDialog.Filter = @"ico files (*.ico)|*.ico";
            _openFileDialog.FilterIndex = 1;
            _openFileDialog.RestoreDirectory = true;

            ControlsSampleNotifyIcon.Text = ToolTipTextTextBox.Text;
            ControlsSampleNotifyIcon.BalloonTipTitle = BalloonTipTitleTextBox.Text;
            ControlsSampleNotifyIcon.BalloonTipText = BalloonTipTextTextBox.Text;
            ControlsSampleNotifyIcon.BalloonTipIcon = (ToolTipIcon)BalloonTipIconComboBox.SelectedIndex;
            ShowBalloonTip();

            _animatedIconTimer = new Timer();
            _animatedIconTimer.Interval = 100;
            _animatedIconTimer.Tick += AnimatedIconTimer_Tick;

            _currentIcon = null;

            _eventsCounter = 0;
            _animatedIconIndex = 0;
        }

        private void AnimatedIconTimer_Tick(object sender, EventArgs e)
        {
            _animatedIconIndex++;
            switch (_animatedIconIndex)
            {
                case 1:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_01;
                break;
                case 2:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_02;
                break;
                case 3:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_03;
                break;
                case 4:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_04;
                break;
                case 5:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_05;
                break;
                case 6:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_06;
                break;
                case 7:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_07;
                break;
                case 8:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_08;
                break;
                case 9:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_09;
                break;
                case 10:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_10;
                break;
                case 11:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_11;
                break;
                case 12:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_12;
                break;
                case 13:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_13;
                break;
                case 14:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_14;
                break;
                case 15:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_15;
                break;
                case 16:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_16;
                break;
                case 17:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_17;
                break;
                case 18:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_18;
                break;
                case 19:
                    ControlsSampleNotifyIcon.Icon = Properties.Resources.ElegantUI_19;
                    _animatedIconIndex = 0;
                break;
            }
        }

        private void AnimatedIconCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (AnimatedIconCheckBox.Checked)
            {
                IconPathTextBox.Enabled = false;
                ChooseIconButton.Enabled = false;
                _currentIcon = ControlsSampleNotifyIcon.Icon;
                _animatedIconIndex = 0;
                _animatedIconTimer.Start();
            }
            else
            {
                _animatedIconTimer.Stop();
                IconPathTextBox.Enabled = true;
                ChooseIconButton.Enabled = true;
                if (_currentIcon != null)
                    ControlsSampleNotifyIcon.Icon = _currentIcon;
            }
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                ShowBalloonTip();
            }
            else
            {
                MouseIconEventsTextBox.Text = "";
                _eventsCounter = 0;
            }

            base.OnVisibleChanged(e);
        }

        private void ShowBalloonTip()
        {
            ControlsSampleNotifyIcon.BalloonTipIcon = (ToolTipIcon)BalloonTipIconComboBox.SelectedIndex;
            ControlsSampleNotifyIcon.BalloonTipTitle = BalloonTipTitleTextBox.Text;
            ControlsSampleNotifyIcon.BalloonTipText = BalloonTipTextTextBox.Text;
            ControlsSampleNotifyIcon.ShowBalloonTip((int)BalloonTipTimoutUpDown.Value);
        }

        private void ChooseIconButton_Click(object sender, EventArgs e)
        {
            if (_openFileDialog.ShowDialog() == DialogResult.OK)
            {
                IconPathTextBox.Text = _openFileDialog.FileName;
                //try
                //{
                //    ControlsSampleNotifyIcon.Icon = new Icon(_openFileDialog.FileName);
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show("Error: The file isn't an Icon. Original error: " + ex.Message);
                //}
            }
        }

        private void IconPathTextBox_TextChanged(object sender, EventArgs e)
        {
            string imagePath = IconPathTextBox.Text.Trim();
            if (string.IsNullOrEmpty(imagePath))
                return;

            if(     !File.Exists(imagePath)
                ||  (   File.Exists(imagePath) 
                    &&  Path.GetExtension(imagePath) != ".ico")
                )
                return;

            ControlsSampleNotifyIcon.Icon = new Icon(imagePath);
        }

        private void ToolTipTextTextBox_TextChanged(object sender, EventArgs e)
        {
            ControlsSampleNotifyIcon.Text = ToolTipTextTextBox.Text;
        }

        private void ShowBalloonTipButton_Click(object sender, EventArgs e)
        {
            ShowBalloonTip();
        }

        private void NotifyIcon_MouseEnter(object sender, EventArgs e)
        {
            MouseEnterEventControl.StartAnimation();
            TraceIconEvent("MouseEnter");
        }

        private void NotifyIcon_MouseLeave(object sender, EventArgs e)
        {
            MouseLeaveEventControl.StartAnimation();
            TraceIconEvent("MouseLeave");
        }

        private void ControlsSampleNotifyIcon_MouseDown(object sender, MouseEventArgs e)
        {
            MouseDownEventControl.StartAnimation();
            TraceIconEvent("MouseDown");
        }

        private void ControlsSampleNotifyIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (!MouseMoveEventControl.IsAnimationEnabled)
                MouseMoveEventControl.StartAnimation();
            TraceIconEvent("MouseMove");
        }

        private void ControlsSampleNotifyIcon_MouseUp(object sender, MouseEventArgs e)
        {
            MouseUpEventControl.StartAnimation();
            TraceIconEvent("MouseUp");
        }

        private void TraceIconEvent(string eventName)
        {
            _eventsCounter++;
            string text = MouseIconEventsTextBox.Text + _eventsCounter + @"   " + eventName + Environment.NewLine; // DateTime.Now.ToString("HH:mm:ss:fff")

            int firstLineEnd = text.IndexOf(Environment.NewLine);
            if (firstLineEnd > 0)
            {
                int newLineCount = 0, currentLineIndex = firstLineEnd + Environment.NewLine.Length;
                while (currentLineIndex > 0)
                {
                    newLineCount += 1;
                    int startIndex = currentLineIndex + Environment.NewLine.Length;
                    if (startIndex >= text.Length - 1)
                        break;

                    currentLineIndex = text.IndexOf(Environment.NewLine, startIndex);
                }

                if (newLineCount == 50)
                {
                    text = text.Remove(0, firstLineEnd + Environment.NewLine.Length);
                }
            }


            MouseIconEventsTextBox.Text = text;
            MouseIconEventsTextBox.Select(MouseIconEventsTextBox.TextLength, 0);
            MouseIconEventsTextBox.ScrollToCaret();
        }

        private void ControlsSampleNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Form form = TopLevelControl as Form;
            if(form != null)
            {
                // to return form to the previous state (maximized or normal)
                WinApi.SendMessage(form.Handle, WinApi.WM_SYSCOMMAND, WinApi.SC_RESTORE, 0);
                form.Activate();
            }
        }
    }
}
