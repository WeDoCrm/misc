using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elegant.Ui.Samples.ControlsSample.Properties;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class StatusBarPage : SamplePageBase
    {
        private class StatusBarPane : Ui.StatusBarPane
        {
            public override string ToString()
            {
                return Text;
            }
        }

        public StatusBarPage()
        {
            InitializeComponent();

            UpdateControlsForCurrentPane();

            _imagesCollection.AddRange(
                new Image[]
                    {
                        Resources.RecordMacro,
                        Resources.reject_small,
                        Resources.research_small,
                        Resources.resetpicture_small,
                        Resources.reviewingpane_small,
                        Resources.reviewingpanevertical_small,
                        Resources.rotateleft_small,
                        Resources.setlanguage_small,
                        Resources.themes_small,
                        Resources.tight_small,
                        Resources.translationscreentip_small,
                        Resources.wordoptions_small
                    }
                );

            _imagesEnumerator = _imagesCollection.GetEnumerator();
            _imagesEnumerator.MoveNext();

            _highlightTimer = new Timer();
            _highlightTimer.Interval = 300;
            _highlightTimer.Tick += HighlightTimer_Tick;

            _progressBarTimer = new Timer();
            _progressBarTimer.Interval = 40;
            _progressBarTimer.Tick += ProgressBarTimer_Tick;
            _progressBarTimer.Start();

            CurrentPaneComboBox.SelectedIndexChanged += CurrentPaneComboBox_SelectedIndexChanged;

            AddButtonSplitButton.Command = AddButtonCommand;
            AddButtonButton.Command = AddButtonCommand;
            AddButtonWithTextButton.Command = AddButtonWithTextCommand;
            AddToggleButtonSplitButton.Command = AddToggleButtonCommand;
            AddToggleButtonButton.Command = AddToggleButtonCommand;
            AddToggleButtonWithTextButton.Command = AddToggleButtonWithTextCommand;
        	AddSliderButton.Command = AddSliderCommand;

            AddButtonCommand.Executed += AddButtonCommand_Executed;
            AddButtonWithTextCommand.Executed += AddButtonWithTextCommand_Executed;
            AddToggleButtonCommand.Executed += AddToggleButtonCommand_Executed;
            AddToggleButtonWithTextCommand.Executed += AddToggleButtonWithTextCommand_Executed;
			AddSliderCommand.Executed += AddSliderCommand_Executed;
        }

        private static readonly Command AddButtonCommand = new Command("AddButtonCommand");
        private static readonly Command AddButtonWithTextCommand = new Command("AddButtonWithTextCommand");
        private static readonly Command AddToggleButtonCommand = new Command("AddToggleButtonCommand");
        private static readonly Command AddToggleButtonWithTextCommand = new Command("AddToggleButtonWithTextCommand");
		private static readonly Command AddSliderCommand = new Command("AddSliderCommand");

        private void CurrentPaneComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControlsForCurrentPane();
        }

        private List<Image>.Enumerator _imagesEnumerator;
        private readonly List<Image> _imagesCollection = new List<Image>();

        private Image GetNextImage()
        {
            Image image = _imagesEnumerator.Current;

            if (!_imagesEnumerator.MoveNext())
            {
                _imagesEnumerator.Dispose();
                _imagesEnumerator = _imagesCollection.GetEnumerator();
                _imagesEnumerator.MoveNext();
            }

            return image;
        }

        protected override void OnParentChanged(EventArgs e)
        {
            if(Visible)
                SampleStatusBar.Parent = TopLevelControl;

            base.OnParentChanged(e);
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if(Visible)
            {
                SampleStatusBar.Parent = TopLevelControl;
                SampleStatusBar.Visible = true;

                _progressBarTimer.Start();    
            }
            else
            {
                SampleStatusBar.Parent = null;
                SampleStatusBar.Visible = false;

                _progressBarTimer.Stop();
            }

            base.OnVisibleChanged(e);
        }

        private readonly Timer _progressBarTimer;
        private readonly List<ProgressBar> _progressBarsList = new List<ProgressBar>();

        private void ProgressBarTimer_Tick(object sender, EventArgs e)
        {
            foreach (ProgressBar bar in _progressBarsList)
            {
                if(!bar.Enabled)
                    continue;

                int newValue = bar.Value + 2;
                if (newValue > bar.Maximum)
                    newValue = bar.Minimum;

                bar.Value = newValue;
            }
        }

        private void AddPaneToControlsAreaButton_Click(object sender, EventArgs e)
        {
            SampleStatusBarControlsArea.Controls.Add(CreateNewStatusBarPane());
            HighlightCurrentPane();
        }

        private void AddPaneToNotificationsAreaButton_Click(object sender, EventArgs e)
        {
            SampleStatusBarNotificationsArea.Controls.Add(CreateNewStatusBarPane());
            HighlightCurrentPane();
        }

        private int _nextStatusBarPaneNumber = 1;

        private StatusBarPane CreateNewStatusBarPane()
        {
            StatusBarPane pane = new StatusBarPane();
            pane.Text = "Pane " + _nextStatusBarPaneNumber++;
            
            Label paneLabel = new Label();
            paneLabel.Text = pane.Text;
            paneLabel.ScreenTip.Caption = pane.Text;
            paneLabel.Tag = pane;
            paneLabel.Parent = pane;
            paneLabel.AutoSize = true;
            
            CurrentPaneComboBox.Items.Add(pane);
            CurrentPaneComboBox.SelectedItem = pane;

            return pane;
        }

        private readonly Timer _highlightTimer;
        private Ui.StatusBarPane _highlightPane;
        private int _highlightFramesShown;
        private bool _showHighlightBorder;
        private const int HiglightFramesCount = 8;

        private void HighlightTimer_Tick(object sender, EventArgs e)
        {
            if(++_highlightFramesShown == HiglightFramesCount)
            {
                _highlightTimer.Stop();

                if(_highlightPane != null)
                    _highlightPane.Paint -= HighlightPane_Paint;
            }

            if(_highlightPane != null && !_highlightPane.IsDisposed)
                _highlightPane.Invalidate();

            _showHighlightBorder = !_showHighlightBorder;
        }

        private void HighlightPane_Paint(object sender, PaintEventArgs e)
        {
            if(!_showHighlightBorder)
                return;

            System.Windows.Forms.Control control = (System.Windows.Forms.Control) sender;
            using (Brush b = new SolidBrush(Color.FromArgb(128, Color.OrangeRed)))
            {
                e.Graphics.FillRectangle(b, control.ClientRectangle);
            }
        }

        private void HighlightCurrentPane_Click(object sender, EventArgs e)
        {
            HighlightCurrentPane();
        }

        private void HighlightCurrentPane()
        {
            _highlightTimer.Stop();

            if (_highlightPane != null)
                _highlightPane.Paint -= HighlightPane_Paint;

            Ui.StatusBarPane pane = CurrentPaneComboBox.SelectedItem as Ui.StatusBarPane;
            if (pane == null)
                return;

            _highlightPane = pane;
            _highlightFramesShown = 0;
            _highlightPane.Paint += HighlightPane_Paint;
            _showHighlightBorder = false;
            _highlightTimer.Start();
        }

        private void RemoveCurrentPaneButton_Click(object sender, EventArgs e)
        {
            Ui.StatusBarPane pane = CurrentPaneComboBox.SelectedItem as Ui.StatusBarPane;
            if (pane == null)
                return;

            if (CurrentPaneComboBox.SelectedIndex < CurrentPaneComboBox.Items.Count - 1)
                CurrentPaneComboBox.SelectedIndex += 1;
            else if (CurrentPaneComboBox.SelectedIndex > 0)
                CurrentPaneComboBox.SelectedIndex -= 1;
            else
                CurrentPaneComboBox.SelectedItem = null;

            CurrentPaneComboBox.Items.Remove(pane);

            foreach (System.Windows.Forms.Control control in pane.Controls)
            {
                ProgressBar progressBar = control as ProgressBar;
                if (progressBar != null)
                    _progressBarsList.Remove(progressBar);
            }

            pane.Parent = null;
            pane.Dispose();
        }

        private void DisableCurrentPaneButton_Click(object sender, EventArgs e)
        {
            Ui.StatusBarPane pane = CurrentPaneComboBox.SelectedItem as Ui.StatusBarPane;
            if (pane == null)
                return;

            pane.Enabled = !DisableCurrentPaneToggleButton.Pressed;
        }

        private void AddButtonCommand_Executed(object sender, CommandExecutedEventArgs e)
        {
            AddControlToTheCurrentPane(typeof(Button), true, false);
        }

        private void AddButtonWithTextCommand_Executed(object sender, CommandExecutedEventArgs e)
        {
            Button button = (Button)AddControlToTheCurrentPane(typeof(Button), true, true);
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private void AddToggleButtonCommand_Executed(object sender, CommandExecutedEventArgs e)
        {
            AddControlToTheCurrentPane(typeof(ToggleButton), true, false);
        }

        private void AddToggleButtonWithTextCommand_Executed(object sender, CommandExecutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)AddControlToTheCurrentPane(typeof(ToggleButton), true, true);
            toggleButton.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

		void AddSliderCommand_Executed(object sender, CommandExecutedEventArgs e)
		{
			Slider slider = (Slider)AddControlToTheCurrentPane(typeof(Slider), false, false);
			slider.Width = ContentScale.ScaleWidth(132);
			slider.ShowMinMaxTicks = false;
			slider.IsSnapToTickEnabled = true;
		}

        private void AddButtonGroupButton_Click(object sender, EventArgs e)
        {
            ButtonGroup buttonGroup = (ButtonGroup)AddControlToTheCurrentPane(typeof (ButtonGroup), false, false);
            buttonGroup.Controls.AddRange(
                new System.Windows.Forms.Control[]
                    {
                        CreateControl(typeof(Button), true, false),
                        CreateControl(typeof(ToggleButton), true, false),
                        CreateControl(typeof(ToggleButton), true, false),
                        CreateControl(typeof(Button), true, false)
                    });
            buttonGroup.PerformLayout();
        }

        private void AddProgressBarButton_Click(object sender, EventArgs e)
        {
			ProgressBar pb = (ProgressBar)AddControlToTheCurrentPane(typeof(ProgressBar), false, false);
			_progressBarsList.Add(pb);
        }

        private void AddLabelButton_Click(object sender, EventArgs e)
        {
            AddControlToTheCurrentPane(typeof (Label), false, true);
        }

        private System.Windows.Forms.Control AddControlToTheCurrentPane(Type controlType, bool setImage, bool setText)
        {
            Ui.StatusBarPane pane = CurrentPaneComboBox.SelectedItem as Ui.StatusBarPane;
            if (pane == null)
                return null;

            System.Windows.Forms.Control control = CreateControl(controlType, setImage, setText);
            if (control == null)
                return null;

            if(pane.Controls.Count == 1 && pane.Controls[0].Tag == pane)
                pane.Controls.Remove(pane.Controls[0]);

            control.Parent = pane;

            return control;
        }

        private readonly Dictionary<Type, int> _createdControlsStatistics = new Dictionary<Type, int>();

        private System.Windows.Forms.Control CreateControl(Type controlType, bool setImage, bool setText)
        {
            System.Windows.Forms.Control control = (System.Windows.Forms.Control) Activator.CreateInstance(controlType);
            if (control == null)
                return null;

            control.AutoSize = true;

            int count;
            if (!_createdControlsStatistics.TryGetValue(controlType, out count))
                count = 1;
            else
                count += 1;

            _createdControlsStatistics[controlType] = count;

            string controlText = controlType.Name + " " + count;

            if (setText)
                control.Text = controlText;

            Control elegantControl = control as Control;
            if (elegantControl != null)
            {
                if (setImage)
                    elegantControl.DefaultSmallImage = GetNextImage();

                elegantControl.ScreenTip.Text = controlText;
            }

            return control;
        }

        private void UpdateControlsForCurrentPane()
        {
            Ui.StatusBarPane pane = CurrentPaneComboBox.SelectedItem as Ui.StatusBarPane;

            CurrentPaneComboBox.Enabled =
                HighlightCurrentPaneButton.Enabled =
                RemoveCurrentPaneButton.Enabled =
                DisableCurrentPaneToggleButton.Enabled =
                AddButtonCommand.Enabled =
                AddButtonWithTextCommand.Enabled =
                AddToggleButtonCommand.Enabled =
                AddToggleButtonWithTextCommand.Enabled =
                AddButtonGroupButton.Enabled =
                AddProgressBarButton.Enabled =
				AddSliderCommand.Enabled =
				AddSliderButton.Enabled =
                AddLabelButton.Enabled = pane != null;

            DisableCurrentPaneToggleButton.Pressed = pane != null && !pane.Enabled;
        }
    }
}