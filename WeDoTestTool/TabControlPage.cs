using System;
using System.Drawing;
using System.Windows.Forms;
using Elegant.Ui.Samples.ControlsSample.Properties;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class TabControlPage : SamplePageBase
    {
        public TabControlPage()
        {
            InitializeComponent();

            TabsPlacementComboBox.DataSource = Enum.GetValues(typeof(TabsPlacement));
            TabsPlacementComboBox.SelectedItem = SampleTabControl.TabsPlacement;

            TabImageDisplayModeComboBox.DataSource = Enum.GetValues(typeof(TabImageDisplayMode));
            TabImageDisplayModeComboBox.SelectedItem = SampleTabControl.TabImageDisplayMode;

            HomeScrollButtonVisibleCheckBox.Checked = SampleTabControl.HomeScrollButtonVisible;
            EndScrollButtonVisibleCheckBox.Checked = SampleTabControl.EndScrollButtonVisible;

            EqualTabWidthCheckBox.Checked = SampleTabControl.EqualTabWidth;
            EqualTabHeightCheckBox.Checked = SampleTabControl.EqualTabHeight;

            HomeScrollButtonVisibleCheckBox.CheckedChanged += HomeScrollButtonVisibleCheckBox_CheckedChanged;
            EndScrollButtonVisibleCheckBox.CheckedChanged += EndScrollButtonVisibleCheckBox_CheckedChanged;
            EqualTabWidthCheckBox.CheckedChanged += EqualTabWidthCheckBox_CheckedChanged;
            EqualTabHeightCheckBox.CheckedChanged += EqualTabHeightCheckBox_CheckedChanged;
            TabsPlacementComboBox.SelectedIndexChanged += TabsPlacementComboBox_SelectedIndexChanged;
            TabImageDisplayModeComboBox.SelectedIndexChanged += TabImageDisplayModeComboBox_SelectedIndexChanged;

            AddCustomTabLineToolbarElements();

            SampleTabControl.TabsPlacementChanged += SampleTabControl_TabsPlacementChanged;
        }

        private void SampleTabControl_TabsPlacementChanged(object sender, PropertyChangedEventArgs<TabsPlacement> e)
        {
            bool horizontal = SampleTabControl.TabsPlacement == TabsPlacement.Bottom ||
                              SampleTabControl.TabsPlacement == TabsPlacement.Top;

            _tabControlSlider.Orientation = horizontal ? Orientation.Horizontal : Orientation.Vertical;
            SampleTabControl.PerformLayout();
        }

        private void AddCustomTabLineToolbarElements()
        {
            SampleTabControl.SuspendLayout();

            try
            {
                TabControlToolbarCustomButton plusButton = new TabControlToolbarCustomButton();
                plusButton.DefaultSmallImage = Resources.TabControlCustomToolbarPlus;
                plusButton.Click += TabControlPlusButton_Click;
                SampleTabControl.AdditionalTabLineControls.Add(plusButton);

                TabControlToolbarCustomButton folderButton = new TabControlToolbarCustomButton();
                folderButton.DefaultSmallImage = Resources.TabControlCustomToolbarFolder;
                folderButton.Click += TabControlFolderButton_Click;
                SampleTabControl.AdditionalTabLineControls.Add(folderButton);

                _tabControlSlider = new Slider();
                _tabControlSlider.Size = new Size(50, _tabControlSlider.PreferredSize.Height);
                _tabControlSlider.AutoSize = false;
                _tabControlSlider.ShowMinMaxTicks = false;
                _tabControlSlider.TickStyle = TickStyle.None;
                _tabControlSlider.Style = SliderStyle.TrackBar;

                _tabControlSlider.Minimum = 0;
                _tabControlSlider.Maximum = 100;
                _tabControlSlider.Value = 20;

                SampleTabControl.AdditionalTabLineControls.Add(_tabControlSlider);
            }
            finally
            {
                SampleTabControl.ResumeLayout(false);
            }
        }

        private Slider _tabControlSlider;

        private static void TabControlPlusButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked the \"Plus\" button");
        }

        private static void TabControlFolderButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have clicked the \"Folder\" button");
        }

        private void TabImageDisplayModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleTabControl.TabImageDisplayMode = (TabImageDisplayMode)TabImageDisplayModeComboBox.SelectedItem;
        }

        private void TabsPlacementComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleTabControl.TabsPlacement = (TabsPlacement)TabsPlacementComboBox.SelectedItem;
        }

        private void EqualTabWidthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleTabControl.EqualTabWidth = EqualTabWidthCheckBox.Checked;
        }
        
        private void EqualTabHeightCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleTabControl.EqualTabHeight = EqualTabHeightCheckBox.Checked;
        }

        private void EndScrollButtonVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleTabControl.EndScrollButtonVisible = EndScrollButtonVisibleCheckBox.Checked;
        }

        private void HomeScrollButtonVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleTabControl.HomeScrollButtonVisible = HomeScrollButtonVisibleCheckBox.Checked;
        }
    }
}
