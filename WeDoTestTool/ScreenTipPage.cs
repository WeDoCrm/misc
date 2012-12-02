using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class ScreenTipPage : SamplePageBase
	{
		public ScreenTipPage()
		{
			InitializeComponent();
			ImagePathErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
			ImageFileDialog.Filter = "All images| *.png;*.jpg;*.jpeg;*.gif;*.bmp |PNG Images (*.png)|*.png|JPEG Images (*.jpg,*.jpeg)|*.jpg;*.jpeg|GIF Images (*.gif)|*.gif|Windows Bitmaps (*.bmp)|*.bmp";
			FillImageScaleModeComboBox();
		}

		private void FillImageScaleModeComboBox()
		{
			ImageScaleModeComboBox.DataSource = Enum.GetValues(typeof (ScreenTipImageScaleMode));
			ImageScaleModeComboBox.SelectedIndex = 0;
			ImageScaleModeComboBox.SelectedIndexChanged += new EventHandler(ImageScaleModeComboBox_SelectedIndexChanged);
		}

		void ImageScaleModeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ScreenTipPanelLabel.ScreenTip.ImageScaleMode = (ScreenTipImageScaleMode)ImageScaleModeComboBox.SelectedItem;
		}

		private void CaptionTextBox_TextChanged(object sender, EventArgs e)
		{
			if (string.Equals(CaptionTextBox.Text.Trim(), ScreenTipPanelLabel.ScreenTip.Caption))
			{
				return;
			}

			ScreenTipPanelLabel.ScreenTip.Caption = CaptionTextBox.Text.Trim();
		}

		private void TextTextBox_TextChanged(object sender, EventArgs e)
		{
			if (string.Equals(TextTextBox.Text.Trim(), ScreenTipPanelLabel.ScreenTip.Text))
			{
				return;
			}

			ScreenTipPanelLabel.ScreenTip.Text = TextTextBox.Text.Trim();
		}

		private void ImageTextBox_TextChanged(object sender, EventArgs e)
		{
			string imagePath = ImageTextBox.Text.Trim();
			if (string.IsNullOrEmpty(imagePath))
			{
				return;
			}

			LoadImage(imagePath);
		}

		private void LoadImage(string imagePath)
		{
			try
			{
				Image img = Image.FromFile(imagePath);
				if (img != null)
				{
					ScreenTipPanelLabel.ScreenTip.Image = img;
					ImagePathErrorProvider.Clear();
				}
				else
				{
					SetErrorProvaider("Invalid image path");
				}
			}
			catch(Exception e)
			{
				SetErrorProvaider(e.Message);
			}
		}

		private void SetErrorProvaider(string errorText)
		{
			ImagePathErrorProvider.SetIconAlignment(ImageTextBox, ErrorIconAlignment.MiddleRight);
			ImagePathErrorProvider.SetIconPadding(ImageTextBox, -20);
			ImagePathErrorProvider.SetError(ImageTextBox, errorText);
		}

		private void ImagePathButton_Click(object sender, EventArgs e)
		{
			ImageFileDialog.ShowDialog(this);
			ImageTextBox.Text = ImageFileDialog.FileName;
		}

		private Image _screenTipImage;

		private void ImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ImagePathButton.Enabled = ImageTextBox.Enabled = ImageCheckBox.Checked;

			if (!ImageCheckBox.Checked)
			{
				_screenTipImage = ScreenTipPanelLabel.ScreenTip.Image;
				ScreenTipPanelLabel.ScreenTip.Image = null;
			}
			else
			{
				ScreenTipPanelLabel.ScreenTip.Image = _screenTipImage;
			}
		}
	}
}
