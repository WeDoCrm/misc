using System;
using System.Drawing;
using System.Windows.Forms;
using Elegant.Ui.Samples.ControlsSample.Properties;
using System.Drawing.Imaging;
using System.Collections.Generic;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class DataEntryControlsPage : SamplePageBase
	{
		internal class ComboBoxItem
		{
			public ComboBoxItem(string text, Image image, string tooltipText)
			{
				_text = text;
				_image = image;
				_screentipText = tooltipText;
			}

			private string _text;

			public string Text
			{
				get { return _text; }
				set { _text = value; }
			}

			private string _screentipText;

			public string ScreentipText
			{
				get { return _screentipText; }
				set { _screentipText = value; }
			}

			private Image _image;

			public Image Image
			{
				get { return _image; }
				set { _image = value; }
			}
		}

		public DataEntryControlsPage()
		{
			InitializeComponent();
			InitalizeTextAlignComboBox();
			InitalizeUpDownAlignComboBox();
			InitializeComboBoxWithImages();
			InitializeSampleDateTimePicker();

			TextAlignComboBox.SelectedIndexChanged += TextAlignComboBox_SelectedIndexChanged;
			UpDownAlignComboBox.SelectedIndexChanged += UpDownAlignComboBox_SelectedIndexChanged;

			FormatComboBox.DataSource = Enum.GetValues(typeof(DateTimePickerFormat));
			FormatComboBox.SelectedItem = DateTimePickerFormat.LongDate;

			ProcessCustomFormatPatternTextBoxTextChanging();

			InitalizeNumericUpDownImage();

			UpdateTextBoxInformativnes(SampleTextBox, TextBoxImageCheckBox.Checked, TextBoxLableCheckBox.Checked);

			UpdateTextBoxInformativnes(SampleComboBox, ConboBoxImageCheckBox.Checked, ComboBoxLabelCheckBox.Checked);

			UpdateTextBoxInformativnes(SampleNumericUpDown, NumericUpDownImageCheckBox.Checked, NumericUpDownLabelCheckBox.Checked);

			UpdateTextBoxInformativnes(
				SampleMaskedTextBox,
				MaskedTextBoxImageCheckBox.Checked,
				MaskedTextBoxLabelCheckBox.Checked);

			UpdateTextBoxInformativnes(
				SampleDateTimePicker,
				DateTimePickerImageCheckBox.Checked,
				DateTimePickerLabelCheckBox.Checked);

			InitialzeControlEditorImages();
		}

		private void InitializeSampleDateTimePicker()
		{
			SampleDateTimePicker.Value = DateTime.Now;
		}

		private void InitialzeControlEditorImages()
		{
			SampleNumericUpDown.EditorImage = Resources.sigma;
		}

		private const int MaximumColorTemperature = 1000;
		protected readonly Color LowTemperatureColor = Color.FromArgb(119, 157, 255);
		protected readonly Color HighTemperatureColor = Color.FromArgb(255, 60, 0);

		protected float RStep;
		protected float GStep;
		protected float BStep;
		protected int StandartComboBoxItemHeight = 13;

		private void InitalizeNumericUpDownImage()
		{
			RStep = (HighTemperatureColor.R - (float)LowTemperatureColor.R) / MaximumColorTemperature;
			GStep = (HighTemperatureColor.G - (float)LowTemperatureColor.G) / MaximumColorTemperature;
			BStep = (HighTemperatureColor.B - (float)LowTemperatureColor.B) / MaximumColorTemperature;

			UpdateNumericUpDownImageColor();
		}

		private ColorMap[] _colorReMapTable;

		private ColorMap[] ColorReMapTable
		{
			get
			{
				if (_colorReMapTable != null)
					return _colorReMapTable;

				List<ColorMap> table = new List<ColorMap>();

				Bitmap maskImage = Resources.CircleTemperatureIndicator;
				for (int i = 0; i < maskImage.Width; i++)
				{
					for (int j = 0; j < maskImage.Height; j++)
					{
						Color color = maskImage.GetPixel(i, j);
						if (color.B == 0 && color.G == 0 && color.R == 0)
						{
							ColorMap colorMap = new ColorMap();
							colorMap.OldColor = colorMap.NewColor = color;
							table.Add(colorMap);
						}
					}
				}

				_colorReMapTable = table.ToArray();

				return _colorReMapTable;
			}
		}

		private void UpdateNumericUpDownImageColor()
		{
			Bitmap imageMask = Resources.CircleTemperatureIndicator;
			Bitmap bmp = new Bitmap(imageMask.Width, imageMask.Height);

			if (ColorReMapTable.Length > 0)
			{
				Color currentColor = GetCurrentColor((int)CustomNumericUpDown.Value);
				foreach (ColorMap colorMap in ColorReMapTable)
				{
					colorMap.NewColor = Color.FromArgb(colorMap.OldColor.A, currentColor);
				}

				ImageAttributes attributes = new ImageAttributes();
				attributes.SetRemapTable(ColorReMapTable, ColorAdjustType.Bitmap);

				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.DrawImage(imageMask, new Rectangle(0, 0, bmp.Width, bmp.Height), 0, 0, bmp.Width, bmp.Height, GraphicsUnit.Pixel, attributes);
					g.Save();
				}
			}

			Image oldImage = CustomNumericUpDown.EditorImage;

			CustomNumericUpDown.EditorImage = bmp;

			if (oldImage != null)
				oldImage.Dispose();
		}

		protected Color GetCurrentColor(int temperature)
		{
			int r = (int)(temperature * RStep);
			int g = (int)(temperature * GStep);
			int b = (int)(temperature * BStep);
			return Color.FromArgb(LowTemperatureColor.R + r, LowTemperatureColor.G + g, LowTemperatureColor.B + b);
		}

		private void NumericUpDown_ValueChanged(object sender, EventArgs e)
		{
			UpdateNumericUpDownImageColor();
		}

		private void UpDownAlignComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SampleNumericUpDown.UpDownAlign = (LeftRightAlignment)UpDownAlignComboBox.SelectedItem;
		}

		private void TextAlignComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			SampleNumericUpDown.TextAlign = (HorizontalAlignment)TextAlignComboBox.SelectedItem;
		}

		private void PasswordCharactersCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleTextBox.PasswordChar = TextBoxPasswordCheckBox.Checked ? '*' : '\0';
		}

		private void HexadecimalCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleNumericUpDown.Hexadecimal = HexadecimalCheckBox.Checked;
		}

		private void ThousandsSeparatorCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleNumericUpDown.ThousandsSeparator = ThousandsSeparatorCheckBox.Checked;
		}

		private void InitalizeTextAlignComboBox()
		{
			TextAlignComboBox.DataSource = Enum.GetValues(typeof(HorizontalAlignment));
			TextAlignComboBox.SelectedItem = SampleNumericUpDown.TextAlign;
		}

		private void InitalizeUpDownAlignComboBox()
		{
			UpDownAlignComboBox.DataSource = Enum.GetValues(typeof(LeftRightAlignment));
			UpDownAlignComboBox.SelectedItem = SampleNumericUpDown.UpDownAlign;
		}

		private void InitializeComboBoxWithImages()
		{
			if (SampleComboBox.DataSource != null)
				SampleComboBox.DataSource = null;

			ComboBoxItem[] ds = new ComboBoxItem[]
                {
                    new ComboBoxItem("Item 1", Resources.ID_INSERT_BOOKMARK_LARGE, "Item 1 Description"),
                    new ComboBoxItem("Item 2", Resources.ID_INSERT_CHART_LARGE, "Item 2 Description"),
                    new ComboBoxItem("Item 3", Resources.ID_INSERT_CHART_LARGE, "Item 3 Description"),
                    new ComboBoxItem("Item 4", Resources.ID_INSERT_CROSS_REFERENCE_LARGE, "Item 4 Description"),
                    new ComboBoxItem("Item 5", Resources.ID_INSERT_EQUATION_LARGE, "Item 5 Description"),
                    new ComboBoxItem("Item 6", Resources.ID_INSERT_PICTURE_FROM_FILE_LARGE, "Item 6 Description"),
                    new ComboBoxItem("Item 7", Resources.ID_INSERT_QUICK_PARTS_LARGE, "Item 7 Description"),
                };

			SampleComboBox.ItemHeight = StandartComboBoxItemHeight;
			SampleComboBox.ItemImagePropertyName = string.Empty;
			if (ComboBoxItemWithImagesCheckBox.Checked)
			{
				SampleComboBox.ItemImagePropertyName = "Image";
				SampleComboBox.ItemHeight = 40;
			}
			SampleComboBox.ItemScreentipTextPropertyName = "ScreentipText";
			SampleComboBox.DisplayMember = "Text";

			SampleComboBox.DataSource = ds;
		}

		private void DisableAllControlsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleTextBox.Enabled = TexBoxEnabledCheckBox.Checked;
		}

		private void FormatComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			DateTimePickerFormat format = (DateTimePickerFormat)FormatComboBox.SelectedItem;

			SampleDateTimePicker.Format = format;

			DateTimePickerLayoutPanel.PerformLayout();

			UpdateCustomFormatTextBox();
		}

		private void UpdateCustomFormatTextBox()
		{
			DateTimePickerFormat format = (DateTimePickerFormat)FormatComboBox.SelectedItem;
			CustomFormatTextBox.Enabled = format == DateTimePickerFormat.Custom;
		}

		private void CustomFormatPatternTextBox_TextChanged(object sender, EventArgs e)
		{
			ProcessCustomFormatPatternTextBoxTextChanging();
		}

		private void ProcessCustomFormatPatternTextBoxTextChanging()
		{
			string text = CustomFormatTextBox.Text;

			int currentQuoteCharIndex = 0, lastQuoteCharIndex = -1, quoteCharCount = 0;
			while ((currentQuoteCharIndex = text.IndexOf('\'', currentQuoteCharIndex)) != -1)
			{
				quoteCharCount += 1;
				lastQuoteCharIndex = currentQuoteCharIndex;
				currentQuoteCharIndex += 1;
			}

			if (quoteCharCount % 2 != 0)
				text = text.Remove(lastQuoteCharIndex, 1);

			SampleDateTimePicker.CustomFormat = text;

			DateTimePickerLayoutPanel.PerformLayout();
		}

		private void IncrementOrDecrementWholeDateCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleDateTimePicker.IncrementOrDecrementWholeDate = IncrementOrDecrementWholeDateCheckBox.Checked;
		}

		private void UpDownButtonsVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleDateTimePicker.UpDownButtonsVisible = UpDownButtonsVisibleCheckBox.Checked;
		}

		private void CalendarDropDownVisibleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleDateTimePicker.CalendarDropDownVisible = CalendarDropDownVisibleCheckBox.Checked;
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			ProcessBannerTextChanged(textBox1.Text);
		}

		private void ProcessBannerTextChanged(string bannerText)
		{
			if (string.IsNullOrEmpty(bannerText.Trim()))
			{
				SampleTextBox.BannerText = string.Empty;
				return;
			}

			SampleTextBox.BannerText = bannerText.Trim();
		}

		private void TextBoxImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(SampleTextBox, TextBoxImageCheckBox.Checked, TextBoxLableCheckBox.Checked);
		}

		private static void UpdateTextBoxInformativnes(Control control, bool image, bool label)
		{
			string controlName = control.GetType().Name;
			if (!image && !label)
			{
				control.InformativenessFixedLevel = string.Format("Elegant.Ui.{0}InformativenessLevel:{0}", controlName);
			}
			else if (image && !label)
			{
				control.InformativenessFixedLevel = string.Format("Elegant.Ui.{0}InformativenessLevel:{0}WithImage", controlName);
			}
			else if (!image)
			{
				control.InformativenessFixedLevel = string.Format("Elegant.Ui.{0}InformativenessLevel:{0}WithLabel", controlName);
			}
			else
			{
			    control.InformativenessFixedLevel = string.Format("Elegant.Ui.{0}InformativenessLevel:{0}WithImageAndLabel", controlName);
			}
		}

		private void LableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(SampleTextBox, TextBoxImageCheckBox.Checked, TextBoxLableCheckBox.Checked);
		}

		private void ItalicToggleButton_PressedChanged(object sender, EventArgs e)
		{
			if (ItalicToggleButton.Pressed)
				SampleTextBox.BannerTextStyle = FontStyle.Italic;
			else
				SampleTextBox.BannerTextStyle = FontStyle.Regular;
		}

		private void ConboBoxImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(SampleComboBox, ConboBoxImageCheckBox.Checked, ComboBoxLabelCheckBox.Checked);
		}

		private void ComboBoxLabelCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(SampleComboBox, ConboBoxImageCheckBox.Checked, ComboBoxLabelCheckBox.Checked);
		}

		private void ComboBoxEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleComboBox.Enabled = ComboBoxEnabledCheckBox.Checked;
		}

		private void ComboBoxEditableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (ComboBoxEditableCheckBox.Checked)
			{
				SampleComboBox.Editable = true;
			}
			else
			{
				SampleComboBox.Editable = false;
			}
			InitializeComboBoxWithImages();
		}

		private void ComboBoxItemWithImagesCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleComboBox.Editable = ComboBoxEditableCheckBox.Checked;
			InitializeComboBoxWithImages();
		}

		private void NumericUpDownLableCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(SampleNumericUpDown, NumericUpDownImageCheckBox.Checked, NumericUpDownLabelCheckBox.Checked);
		}

		private void NumericUpDownImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(SampleNumericUpDown, NumericUpDownImageCheckBox.Checked, NumericUpDownLabelCheckBox.Checked);
		}

		private void NumericUpDownEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleNumericUpDown.Enabled = NumericUpDownEnabledCheckBox.Checked;
		}

		private void DateTimePickerLabelCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(
				SampleDateTimePicker,
				DateTimePickerImageCheckBox.Checked,
				DateTimePickerLabelCheckBox.Checked);
		}

		private void DateTimePickerImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(
				SampleDateTimePicker,
				DateTimePickerImageCheckBox.Checked,
				DateTimePickerLabelCheckBox.Checked);
		}

		private void DateTimePickerEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleDateTimePicker.Enabled = DateTimePickerEnabledCheckBox.Checked;
		}

		private void MaskButton_Click(object sender, EventArgs e)
		{
			using (MaskDesignerForm form = new MaskDesignerForm(
													SampleMaskedTextBox.PromptChar,
													SampleMaskedTextBox.Mask,
													SampleMaskedTextBox.ValidatingType)
													)
			{
				form.StartPosition = FormStartPosition.CenterParent;
				if (form.ShowDialog() == DialogResult.OK)
				{
					if (SampleMaskedTextBox.Mask != form.Mask)
					{
						SampleMaskedTextBox.Text = string.Empty;
						MaskTextBox.Text = form.Mask;
						SampleMaskedTextBox.Mask = form.Mask;
					}

					if (SampleMaskedTextBox.ValidatingType != form.ValidatingType)
						SampleMaskedTextBox.ValidatingType = form.ValidatingType;
				}
			}
		}

		private void MaskedPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleMaskedTextBox.PasswordChar = MaskedPasswordCheckBox.Checked ? '*' : '\0';
		}

		private void MaskedTextBoxLabelCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(
				SampleMaskedTextBox,
				MaskedTextBoxImageCheckBox.Checked,
				MaskedTextBoxLabelCheckBox.Checked);
		}

		private void MaskedTextBoxImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			UpdateTextBoxInformativnes(
				SampleMaskedTextBox,
				MaskedTextBoxImageCheckBox.Checked,
				MaskedTextBoxLabelCheckBox.Checked);
		}

		private void MaskedTextBoxEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleMaskedTextBox.Enabled = MaskedTextBoxEnabledCheckBox.Checked;
		}

		private void MaskTextBox_TextChanged(object sender, EventArgs e)
		{
			SampleMaskedTextBox.ValidatingType = null;
			SampleMaskedTextBox.Mask = MaskTextBox.Text;
		}

		private void NumericUpDownReadOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CustomNumericUpDown.ReadOnly = SampleNumericUpDown.ReadOnly = NumericUpDownReadOnlyCheckBox.Checked;
		}

		private void TextBoxReadOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleTextBox.ReadOnly = TextBoxReadOnlyCheckBox.Checked;
		}

		private void MaskedTextBoxReadOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SampleMaskedTextBox.ReadOnly = MaskedTextBoxReadOnlyCheckBox.Checked;
		}

		private void NumericUpDownEditorImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (NumericUpDownEditorImageCheckBox.Checked)
				SampleNumericUpDown.EditorImageSize = new Size(16, 16);
			else
				SampleNumericUpDown.EditorImageSize = new Size(0, 0);
		}

		private void NoneAutoCompleteModeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			FontComboBox.AutoCompleteMode =
			   BrushComboBox.AutoCompleteMode = AutoCompleteMode.None;
		}

		private void SuggestAutoCompleteModeRadioButton_CheckedChanged(object sender, EventArgs e)
		{
			FontComboBox.AutoCompleteMode =
			   BrushComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
		}

		private void AppendAutoCompleteModeRadioNutton_CheckedChanged(object sender, EventArgs e)
		{
			FontComboBox.AutoCompleteMode =
			   BrushComboBox.AutoCompleteMode = AutoCompleteMode.Append;
		}

		private void SuggestAppendAutoCompleteModeRadioNutton_CheckedChanged(object sender, EventArgs e)
		{
			FontComboBox.AutoCompleteMode =
			   BrushComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
		}

		private void MultilineEnabledCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			MultilineTextBox.Enabled = MultilineEnabledCheckBox.Checked;
		}

		private void MultilineReadOnlyCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			MultilineTextBox.ReadOnly = MultilineReadOnlyCheckBox.Checked;
		}

		private void MultilineItalicToggleButton_PressedChanged(object sender, EventArgs e)
		{
			if (MultilineItalicToggleButton.Pressed)
				MultilineTextBox.BannerTextStyle = FontStyle.Italic;
			else
				MultilineTextBox.BannerTextStyle = FontStyle.Regular;

		}

		private void MultilineBannerTextBox_TextChanged(object sender, EventArgs e)
		{
			string bannerText = MultilineBannerTextBox.Text;
			if (string.IsNullOrEmpty(bannerText.Trim()))
			{
				MultilineTextBox.BannerText = string.Empty;
				return;
			}

			MultilineTextBox.BannerText = bannerText.Trim();
		}
	}
}
