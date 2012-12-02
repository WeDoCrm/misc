using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
    public partial class GalleryPage : SamplePageBase
    {
        public GalleryPage()
        {
            InitializeComponent();

            SampleGallery.SelectedItemCategoryFilter = SampleGallery.ItemCategoryFilters[4];
            SampleGallery.DrawItem += SampleGallery_DrawItem;

            InteractionModeComboBox.DataSource = Enum.GetValues(typeof (GalleryInteractionMode));
            InteractionModeComboBox.SelectedItem = SampleGallery.InteractionMode;

            MinimumItemsInRowCountNumericUpDown.Value = SampleGallery.MinimumItemsInRowCount;
            MinimumItemsInRowCountNumericUpDown.Maximum = SampleGallery.MaximumItemsInRowCount;
            MaximumItemsInRowCountNumericUpDown.Value = SampleGallery.MaximumItemsInRowCount;
            PopupMinimumItemsInRowCountNumericUpDown.Value = SampleGallery.PopupMinimumItemsInRowCount;

            PopupResizeModeComboBox.DataSource = Enum.GetValues(typeof (GalleryPopupResizeMode));
            PopupResizeModeComboBox.SelectedItem = SampleGallery.PopupResizeMode;

            DropDownCheckBox.CheckedChanged += DropDownCheckBox_CheckedChanged;
            InteractionModeComboBox.SelectedIndexChanged += InteractionModeComboBox_SelectedIndexChanged;
            MinimumItemsInRowCountNumericUpDown.ValueChanged += MinimumItemsInRowCountNumericUpDown_ValueChanged;
            MaximumItemsInRowCountNumericUpDown.ValueChanged += MaximumItemsInRowCountNumericUpDown_ValueChanged;
            PopupMinimumItemsInRowCountNumericUpDown.ValueChanged += PopupMinimumItemsInRowCountNumericUpDown_ValueChanged;
            PopupResizeModeComboBox.SelectedIndexChanged += PopupResizeModeComboBox_SelectedIndexChanged;
            FilterEnabledCheckBox.CheckedChanged += FilterEnabledCheckBox_CheckedChanged;
            FilterDropDownVisibleCheckBox.CheckedChanged += FilterDropDownVisibleCheckBox_CheckedChanged;
            ExpandButtonVisibleCheckBox.CheckedChanged += ExpandButtonVisibleCheckBox_CheckedChanged;

            _saturationAdjustmentTimer = new Timer();
            _saturationAdjustmentTimer.Interval = SaturationAdjustmentTimerInterval;
            _saturationAdjustmentTimer.Tick += SaturationAdjustmentTimer_Tick;
        }

        private void ExpandButtonVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleGallery.ExpandButtonVisible = ExpandButtonVisibleCheckBox.Checked;
        }

        private void FilterDropDownVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleGallery.ItemCategoryFilterDropDownVisible = FilterDropDownVisibleCheckBox.Checked;
        }

        private void FilterEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleGallery.ItemCategoryFilterEnabled = FilterEnabledCheckBox.Checked;
            FilterDropDownVisibleCheckBox.Enabled = FilterEnabledCheckBox.Checked;
        }

        private void PopupResizeModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleGallery.PopupResizeMode = (GalleryPopupResizeMode) PopupResizeModeComboBox.SelectedItem;
        }

        private void PopupMinimumItemsInRowCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SampleGallery.PopupMinimumItemsInRowCount = Convert.ToInt32(PopupMinimumItemsInRowCountNumericUpDown.Value);
        }

        private void MaximumItemsInRowCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SampleGallery.MaximumItemsInRowCount = Convert.ToInt32(MaximumItemsInRowCountNumericUpDown.Value);
            MinimumItemsInRowCountNumericUpDown.Maximum = MaximumItemsInRowCountNumericUpDown.Value;
            MinimumItemsInRowCountNumericUpDown.Value = SampleGallery.MinimumItemsInRowCount;
        }

        private void MinimumItemsInRowCountNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            SampleGallery.MinimumItemsInRowCount = Convert.ToInt32(MinimumItemsInRowCountNumericUpDown.Value);
        }

        private void InteractionModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SampleGallery.InteractionMode = (GalleryInteractionMode) InteractionModeComboBox.SelectedItem;
        }

        private void DropDownCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            SampleGallery.Informativeness.FixedLevel = DropDownCheckBox.Checked
                                                           ? GalleryInformativenessLevel.DropDownSmallImage
                                                           : GalleryInformativenessLevel.Expanded;

            MinimumItemsInRowCountNumericUpDown.Enabled =
                MaximumItemsInRowCountNumericUpDown.Enabled = !DropDownCheckBox.Checked;

            GalleryContainerPanel.PerformLayout();
        }

        private void CustomPaintingDemoToggleButton_PressedChanged(object sender, EventArgs e)
        {
            _saturationAdjustmentTimer.Stop();

            if (CustomPaintingDemoToggleButton.Pressed)
                SampleGallery.ItemDrawMode = GalleryItemDrawMode.OwnerDrawWithStandardBackground;

            _SaturationAdjustmentVector = CustomPaintingDemoToggleButton.Pressed ? -1 : 1;

            _saturationAdjustmentTimer.Start();

            SampleGallery.InvalidateItems();
        }

        private const float OriginalSaturationValue = 1;
        private const float CustomSaturationValue = -1;
        private const float SaturationAdjustment = 0.4f;
        private const int SaturationAdjustmentTimerInterval = 100;
        
        private readonly Timer _saturationAdjustmentTimer;

        private void SaturationAdjustmentTimer_Tick(object sender, EventArgs e)
        {
            _saturationAdjustmentTimer.Stop();

            _CurrentSaturation += SaturationAdjustment * _SaturationAdjustmentVector;
            
            if (_CurrentSaturation < CustomSaturationValue)
                _CurrentSaturation = CustomSaturationValue;

            if (_CurrentSaturation > OriginalSaturationValue)
                _CurrentSaturation = OriginalSaturationValue;

            SampleGallery.InvalidateItems();

            if (_CurrentSaturation == CustomSaturationValue)
                return;

            if (_CurrentSaturation == OriginalSaturationValue)
            {
                SampleGallery.ItemDrawMode = GalleryItemDrawMode.CenterImage;
                return;
            }

            _saturationAdjustmentTimer.Start();
        }

        private int _SaturationAdjustmentVector;
        private float _CurrentSaturation = OriginalSaturationValue;

        private readonly Dictionary<float, ColorMatrix> _ColorMatrices = new Dictionary<float, ColorMatrix>();

        private ColorMatrix CreateSaturationMatrix(float saturation)
        {
            ColorMatrix cm;
            if (_ColorMatrices.TryGetValue(saturation, out cm))
                return cm;

            float SaturationComplement = 1.0f - saturation;

            float SaturationComplementR = 0.3086f * SaturationComplement;

            float SaturationComplementG = 0.6094f * SaturationComplement;

            float SaturationComplementB = 0.0820f * SaturationComplement;

            cm = new ColorMatrix(new float[][]{

                                 new float[]{SaturationComplementR + saturation,  SaturationComplementR,  SaturationComplementR,  0.0f, 0.0f},

                                 new float[]{SaturationComplementG,  SaturationComplementG + saturation,  SaturationComplementG,  0.0f, 0.0f},

                                 new float[]{SaturationComplementB,  SaturationComplementB,  SaturationComplementB + saturation,  0.0f, 0.0f},

                                 new float[]{0.0f,  0.0f,  0.0f,  1.0f,  0.0f},

                                 new float[]{0.0f,  0.0f,  0.0f,  0.0f,  1.0f}});

            _ColorMatrices[saturation] = cm;

            return cm;
        }

        private readonly Dictionary<Image, Dictionary<float, Image>> _CustomImages = new Dictionary<Image, Dictionary<float, Image>>();

        private Image ApplySaturationToImage(Image sourceImage, float saturation)
        {
            Dictionary<float, Image> imageCache;
            if(!_CustomImages.TryGetValue(sourceImage, out imageCache))
                _CustomImages[sourceImage] = imageCache = new Dictionary<float, Image>();

            Image image;
            if (imageCache.TryGetValue(saturation, out image))
                return image;

            image = ApplyColorMatrixToImage(sourceImage, CreateSaturationMatrix(saturation));

            imageCache[saturation] = image;

            return image;
        }

        private static Image ApplyColorMatrixToImage(Image sourceImage, ColorMatrix cm)
        {
            Bitmap bitmap = new Bitmap(sourceImage.Width, sourceImage.Height);

            using(Graphics g = Graphics.FromImage(bitmap))
            {
                ImageAttributes ia = new ImageAttributes();

                ia.SetColorMatrix(cm);

                g.DrawImage(
                    sourceImage, 
                    new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                    0, 0, sourceImage.Width, sourceImage.Height, 
                    GraphicsUnit.Pixel, 
                    ia);

                g.Save();
            }

            return bitmap;
        }

        private void SampleGallery_DrawItem(object sender, GalleryDrawItemEventArgs e)
        {
            GalleryItem galleryItem = (GalleryItem) e.Item;
            Image image = ApplySaturationToImage(galleryItem.Image, _CurrentSaturation);
            e.PaintScaledAndCenteredImage(image, e.ContentBounds, ImageEffect.None, e.Graphics);

            if(_CurrentSaturation == CustomSaturationValue)
            {
                int informationRectangleHeight = TextRenderer.MeasureText(galleryItem.TooltipText, Font).Height + 4;

                Rectangle backgroundRectangle = e.ContentBounds;
                backgroundRectangle.Y = backgroundRectangle.Bottom - informationRectangleHeight;
                backgroundRectangle.Height = informationRectangleHeight;

                using(Brush b = new SolidBrush(Color.FromArgb(128, Color.White)))
                {
                    e.Graphics.FillRectangle(b, backgroundRectangle);
                }

                Rectangle textRectangle = e.RelativeContentBounds;
                textRectangle.Y = textRectangle.Bottom - informationRectangleHeight;
                textRectangle.Height = informationRectangleHeight;
                
                TextRenderer.DrawText(
                        e.Graphics,
                        galleryItem.TooltipText,
                        Font,
                        textRectangle,
                        SystemColors.ControlText,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
        }
    }
}