using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class PopupsPage : SamplePageBase
    {
        public PopupsPage()
        {
            InitializeComponent();
            InitializeHidingAnimationControls();
            InitializePlacementAreaComboBox();
            InitializePopupMenuLongSubMenu();

            _customPopup = new Popup(CustomPopupPanel);
            _customPopup.Child = new CustomPopupChildControl();
            _customPopup.PlacementMode = PopupPlacementMode.AbsoluteOffset;
            _customPopup.HideByClickingOnParentControl = true;

			InitalizePopupMenuSettingsControls();

			_hidingAnimationTime = Popup.HidingAnimationTime;
            _hidingAnimationFramesCount = Popup.HidingAnimationFramesCount;

            HidingAnimationFramesNumericUpDown.ValueChanged += HidingAnimationFramesNumericUpDown_ValueChanged;
            HidingAnimationTimeNumericUpDown.ValueChanged += HidingAnimationTimeNumericUpDown_ValueChanged;

            PlacementAreaComboBox.SelectedIndexChanged += PlacementAreaComboBox_SelectedIndexChanged;
            PlacementModeComboBox.SelectedIndexChanged += PlacementModeComboBox_SelectedIndexChanged;
            MinimumItemHeightNumericUpDown.ValueChanged += MinimumItemHeightNumericUpDown_ValueChanged;
            EnableFixedImageBoxWidthCheckBox.CheckedChanged += EnableFixedImageBoxWidthCheckBox_CheckedChanged;
            FixedImageBoxWidthNumericUpDown.ValueChanged += FixedImageBoxWidthNumericUpDown_ValueChanged;           
            
            AllowAnimationCheckBox.CheckedChanged += AllowAnimationCheckBox_CheckedChanged;
            AllowShadowCheckBox.CheckedChanged += AllowShadowCheckBox_CheckedChanged;
			SamplePopupMenuLongSubMenu.Showing += SamplePopupMenuLongSubMenu_Showing;
        }

        private readonly Popup _customPopup;

        private int _hidingAnimationTime;
        private int _hidingAnimationFramesCount;

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (Visible)
            {
                _hidingAnimationTime = Popup.HidingAnimationTime;
                _hidingAnimationFramesCount = Popup.HidingAnimationFramesCount;

                Popup.HidingAnimationTime = Convert.ToInt32(HidingAnimationTimeNumericUpDown.Value);
                Popup.HidingAnimationFramesCount = Convert.ToInt32(HidingAnimationFramesNumericUpDown.Value);
            }
            else
            {
                Popup.HidingAnimationTime = _hidingAnimationTime;
                Popup.HidingAnimationFramesCount = _hidingAnimationFramesCount;
            }

            base.OnVisibleChanged(e);
        }

        private void CustomPopupPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            _customPopup.PlacementOffset = new Size(CustomPopupPanel.PointToScreen(e.Location));
            _customPopup.Show();
        }

        private void CustomPopupPanelLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            _customPopup.PlacementOffset = new Size(CustomPopupPanelLabel.PointToScreen(e.Location));
            _customPopup.Show();
        }

        private void AllowAnimationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            HidingAnimationFramesNumericUpDown.Enabled =
                HidingAnimationTimeNumericUpDown.Enabled = AllowAnimationCheckBox.Checked;

            _customPopup.AllowAnimation =
                SamplePopupMenu.AllowAnimation = 
                SamplePopupMenu2.AllowAnimation =
                SamplePopupMenu3.AllowAnimation =
                SamplePopupMenu4.AllowAnimation =
                SamplePopupMenu5.AllowAnimation =
                SamplePopupMenuLongSubMenu.AllowAnimation =
                SamplePopupMenuGallery.Popup.AllowAnimation =
                SamplePopupMenuGallery2.Popup.AllowAnimation =
                SamplePopupMenuGallery3.Popup.AllowAnimation =
                SamplePopupMenuGallery4.Popup.AllowAnimation = AllowAnimationCheckBox.Checked;
        }

        private void AllowShadowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _customPopup.AllowShadow =
                SamplePopupMenu.AllowShadow = AllowShadowCheckBox.Checked;
        }

        private void InitializeHidingAnimationControls()
        {
            HidingAnimationTimeNumericUpDown.Value = Popup.HidingAnimationTime;
            HidingAnimationFramesNumericUpDown.Value = Popup.HidingAnimationFramesCount;
        }

        private void HidingAnimationTimeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Popup.HidingAnimationTime = Convert.ToInt32(HidingAnimationTimeNumericUpDown.Value);
        }

        private void HidingAnimationFramesNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Popup.HidingAnimationFramesCount = Convert.ToInt32(HidingAnimationFramesNumericUpDown.Value);
        }

        private void PopupMenuPanel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            SamplePopupMenu.Owner = PopupMenuPanel;
            SamplePopupMenu.HideByClickingOnParentControl = true;
            SamplePopupMenu.PlacementMode = PopupPlacementMode.AbsoluteOffset;
            SamplePopupMenu.PlacementOffset = new Size(PopupMenuPanel.PointToScreen(e.Location));
            SamplePopupMenu.Show();
        }

        private void PopupMenuPanelLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                return;

            SamplePopupMenu.Owner = PopupMenuPanel;
            SamplePopupMenu.HideByClickingOnParentControl = true;
            SamplePopupMenu.PlacementMode = PopupPlacementMode.AbsoluteOffset;
            SamplePopupMenu.PlacementOffset = new Size(PopupMenuPanelLabel.PointToScreen(e.Location));
            SamplePopupMenu.Show();
        }

        private void InitializePopupMenuLongSubMenu()
        {
            SamplePopupMenuLongSubMenu.BeginInit();

            try
            {
                for (int i = 1; i <= 60; ++i)
                {
                    Button button = new Button();
                    button.Text = "Item " + i;
                    button.KeyTip = i.ToString();
                    SamplePopupMenuLongSubMenu.Items.Add(button);
                }
            }
            finally
            {
                SamplePopupMenuLongSubMenu.EndInit();
            }
        }

        private void InitalizePopupMenuSettingsControls()
        {
            PlacementModeComboBox.DataSource = new PopupPlacementMode[]
                {
                    PopupPlacementMode.Left,
                    PopupPlacementMode.Top,
                    PopupPlacementMode.Right,
                    PopupPlacementMode.Bottom,
                };

            PlacementModeComboBox.SelectedItem = SamplePopupMenu.PlacementMode;

            LongSubMenuItemsCountNumericUpDown.Value = SamplePopupMenuLongSubMenu.Items.Count;

            EnableFixedImageBoxWidthCheckBox.Checked = SamplePopupMenu.FixedImageBoxWidth != -1;

            FixedImageBoxWidthNumericUpDown.Enabled = EnableFixedImageBoxWidthCheckBox.Checked;

			AllowShadowCheckBox.Checked =
				AllowShadowCheckBox.Enabled =
				(bool) (_customPopup.AllowShadow =
				        SamplePopupMenu.AllowShadow =
				        SystemInformation.IsDropShadowEnabled);
        }

        private void InitializePlacementAreaComboBox()
        {
            PlacementAreaComboBox.DataSource = Enum.GetValues(typeof (PopupPlacementArea));
            PlacementAreaComboBox.SelectedItem = SamplePopupMenu.PlacementArea;
        }

        private void FixedImageBoxWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SamplePopupMenu.FixedImageBoxWidth = Convert.ToInt32(FixedImageBoxWidthNumericUpDown.Value);
        }

        private void EnableFixedImageBoxWidthCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            FixedImageBoxWidthNumericUpDown.Enabled = EnableFixedImageBoxWidthCheckBox.Checked;

            if(EnableFixedImageBoxWidthCheckBox.Checked)
                SamplePopupMenu.FixedImageBoxWidth = Convert.ToInt32(FixedImageBoxWidthNumericUpDown.Value);
            else
                SamplePopupMenu.FixedImageBoxWidth = -1;
        }

        private void MinimumItemHeightNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SamplePopupMenu.MinimumItemHeight = Convert.ToInt32(MinimumItemHeightNumericUpDown.Value);
        }

        private void PlacementModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SamplePopupMenu.PlacementMode =
                ShowSamplePopupMenuDropDown.PopupPlacementMode = (PopupPlacementMode)PlacementModeComboBox.SelectedItem;
        }

        private void PlacementAreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _customPopup.PlacementArea =
                SamplePopupMenu.PlacementArea =
                SamplePopupMenu2.PlacementArea =
                SamplePopupMenu3.PlacementArea =
                SamplePopupMenu4.PlacementArea =
                SamplePopupMenu5.PlacementArea =
                SamplePopupMenuLongSubMenu.PlacementArea =
                SamplePopupMenuGallery.Popup.PlacementArea =
                SamplePopupMenuGallery2.Popup.PlacementArea =
                SamplePopupMenuGallery3.Popup.PlacementArea =
                SamplePopupMenuGallery4.Popup.PlacementArea = (PopupPlacementArea)PlacementAreaComboBox.SelectedItem;
        }

        private void SamplePopupMenuLongSubMenu_Showing(object sender, EventArgs e)
        {
            if(SamplePopupMenuLongSubMenu.Items.Count == LongSubMenuItemsCountNumericUpDown.Value)
                return;

            SamplePopupMenuLongSubMenu.BeginInit();

            try
            {
                if (SamplePopupMenuLongSubMenu.Items.Count > LongSubMenuItemsCountNumericUpDown.Value)
                {
                    while(SamplePopupMenuLongSubMenu.Items.Count > LongSubMenuItemsCountNumericUpDown.Value)
                    {
                        SamplePopupMenuLongSubMenu.Items.RemoveAt(SamplePopupMenuLongSubMenu.Items.Count - 1);
                    }
                }
                else
                {
                    while (SamplePopupMenuLongSubMenu.Items.Count < LongSubMenuItemsCountNumericUpDown.Value)
                    {
                        Button button = new Button();
                        button.Text = "Item " + (SamplePopupMenuLongSubMenu.Items.Count + 1);
                        button.KeyTip = (SamplePopupMenuLongSubMenu.Items.Count + 1).ToString();
                        SamplePopupMenuLongSubMenu.Items.Add(button);
                    }
                }
            }
            finally
            {
                SamplePopupMenuLongSubMenu.EndInit();    
            }
        }
    }
}