using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Elegant.Ui.Samples.ControlsSample.Properties;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            Elegant.Ui.RibbonLicenser.LicenseKey = "E644-DB48-BFFB-CA0C-53D2-4F3F-C938-C3EF";

            SetStyle(
                ControlStyles.UserPaint,
                true);

            InitializeComponent();

            if(SystemFonts.MenuFont.FontFamily.Name == "Segoe UI")
                Font = SystemFonts.MenuFont;


            InitializeVisualThemeComboBox();

            //ButtonsPageToggleButton.Tag = typeof (ButtonsPage);
            //DataEntryControlsPageToggleButton.Tag = typeof(DataEntryControlsPage);
            //ListBoxPageToggleButton.Tag = typeof(ListBoxPage);
            //PopupsPageToggleButton.Tag = typeof(PopupsPage);
            //GalleryPageToggleButton.Tag = typeof (GalleryPage);
            //StatusBarPageToggleButton.Tag = typeof(StatusBarPage);
            //CalendarPageToggleButton.Tag = typeof(CalendarPage);
            //TabControlPageToggleButton.Tag = typeof(TabControlPage);
            //ProgressBarPageToggleButton.Tag = typeof(ProgressBarPage);
            //SliderPageToggleButton.Tag = typeof (SliderPage);
            //ScreenTipPageToggleButton.Tag = typeof(ScreenTipPage);
            //MessageBoxPageToggleButton.Tag = typeof (MessageBoxPage);
            //ColorPickerPageToggleButton.Tag = typeof(ColorPickerPage);
            //NotifyIconPageToggleButton.Tag = typeof(NotifyIconPage);
            IPPhonePageToggleButton.Tag = typeof(KeyPhonePage);
            IPPhonePageToggleButton.Tag = typeof(IPPhonePage);
            MsgrServerPageToggleButton.Tag = typeof(MsgrServerPage);
            MsgrClientPageToggleButton.Tag = typeof(MsgrClientPage);

            ControlsNavigationBar.PressedToggleButtonChanged += ControlsNavigationBar_PressedToggleButtonChanged;
            //VisualThemeComboBox.SelectedIndexChanged += VisualThemeComboBox_SelectedIndexChanged;

            ControlsNavigationBar.PerformLayout();

            DisplayCurrentSamplePage();
        }

        public static void SetMonospaceFont(System.Windows.Forms.Control control)
        {
            const string modernFontName = "Consolas";
            const string classicFontName = "Courier New";

            if (SystemInfo.IsWindowsXPOrHigher && SystemInformation.FontSmoothingType == 2) //AA is on
            {
                Font modernFont = TryToGetFont(modernFontName, control.Font.Size);
                if (modernFont != null)
                {
                    control.Font = modernFont;
                    return;
                }
            }

            Font font = TryToGetFont(classicFontName, control.Font.Size);
            if (font != null)
                control.Font = font;
        }

        private static Font TryToGetFont(string fontName, float size)
        {
            FontFamily[] families = FontFamily.Families;
            Font font = null;

            foreach (FontFamily family in families)
            {
                if (family.Name == fontName)
                {
                    font = new Font(new FontFamily(fontName), size);
                    break;
                }
            }

            return font;
        }


        private readonly Dictionary<Type, UserControl> _controlsSamplePages = new Dictionary<Type, UserControl>();

        private UserControl GetControlsSamplePage(Type type)
        {
            if(type == null)
                throw new ArgumentNullException("type");

            if(!type.IsSubclassOf(typeof(UserControl)))
                return null;

            UserControl samplePage;
            if (_controlsSamplePages.TryGetValue(type, out samplePage))
                return samplePage;

            samplePage = (UserControl)Activator.CreateInstance(type);

            _controlsSamplePages.Add(type, samplePage);

            return samplePage;
        }

        private void ControlsNavigationBar_PressedToggleButtonChanged(object sender, NavigationBarPressedToggleButtonChangedEventArgs e)
        {
            DisplayCurrentSamplePage();
        }

        private void DisplayCurrentSamplePage()
        {
            UserControl currentSamplePage = null;

            if(ControlsNavigationBar.PressedToggleButton != null)
            {
                Type type = ControlsNavigationBar.PressedToggleButton.Tag as Type;
                if (type != null)
                    currentSamplePage = GetControlsSamplePage(type);
            }

            ControlsSamplePageContainer.ControlsSamplePage = currentSamplePage;
        }

        private void RtlCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if(RTLCheckBox.Checked)
            //{
            //    RightToLeftLayout = true;
            //    RightToLeft = RightToLeft.Yes;
            //}
            //else
            //{
            //    RightToLeft = RightToLeft.No;
            //    RightToLeftLayout = false;
            //}
        }

        private void InitializeVisualThemeComboBox()
        {
            //VisualThemeComboBox.Items.Add(_office2010Blue);
            //VisualThemeComboBox.Items.Add(_office2010Silver);
            //VisualThemeComboBox.Items.Add(_office2010Black);
            //VisualThemeComboBox.Items.Add(_office2010Tp);
            //VisualThemeComboBox.Items.Add(_windows7);
            //VisualThemeComboBox.Items.Add(_office2007Blue);
            //VisualThemeComboBox.Items.Add(_office2007Silver);
            //VisualThemeComboBox.Items.Add(_office2007Black);
            //VisualThemeComboBox.Items.Add(_system);
            //VisualThemeComboBox.SelectedItem = _office2010Blue;
        }

		private readonly Theme _office2007Blue = new Theme("Office 2007 Blue", Resources.Office2007Blue);
		private readonly Theme _office2007Black = new Theme("Office 2007 Black",Resources.Office2007Black);
		private readonly Theme _office2007Silver = new Theme("Office 2007 Silver", Resources.Office2007Silver);
		private readonly Theme _office2010Tp = new Theme("Office 2010 TP", Resources.Office2010Blue);
		private readonly Theme _office2010Blue = new Theme("Office 2010 Blue", Resources.Blue32x32);
		private readonly Theme _office2010Black = new Theme("Office 2010 Black", Resources.Black32x32);
		private readonly Theme _office2010Silver = new Theme("Office 2010 Silver", Resources.Silver32x32);
		private readonly Theme _windows7 = new Theme("Windows7", Resources.Windows7);
		private readonly Theme _system = new Theme("System", Resources.System);

        private void VisualThemeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (VisualThemeComboBox.SelectedItem == _office2007Blue)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2007Blue, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _office2007Black)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2007Black, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _office2007Silver)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2007Silver, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _office2010Tp)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2010TP, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _windows7)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Windows7, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _office2010Blue)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2010Blue, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _office2010Silver)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2010Silver, Product.Common);
            //}
            //else if (VisualThemeComboBox.SelectedItem == _office2010Black)
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.Office2010Black, Product.Common);
            //}
            //else
            //{
            //    SkinManager.LoadEmbeddedTheme(EmbeddedTheme.System, Product.Common);
            //}

            Refresh();
        }

        private void DataEntryControlsPageToggleButton_PressedChanged(object sender, EventArgs e)
        {

        }

        private void MsgrClientPageToggleButton_PressedChanged(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (KeyValuePair<Type, UserControl> pair in _controlsSamplePages)
            {
                ((UserControl)pair.Value).Dispose();
            }

        }
    }
}