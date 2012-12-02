using System;
using System.Drawing;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class ButtonsPage : SamplePageBase
	{
		public ButtonsPage()
		{
			InitializeComponent();
			InitializeImageAlignComboBox();
			InitializeTextAlignComboBox();
			InitializeTextImageRelationAlignComboBox();
			InitializeCheckAlignComboBox();
			SetCheckAndRadioVisibility(true, false, false);
			SetButtonVisibility(true, false, false);

			CheckAlignComboBox.SelectedIndexChanged += CheckAlignComboBox_SelectedIndexChanged;
			TextImageRelationComboBox.SelectedIndexChanged += TextImageRelationComboBox_SelectedIndexChanged;
			TextAlignComboBox.SelectedIndexChanged += TextAlignComboBox_SelectedIndexChanged;
			DisableButtonPageAllControlsCheckBox.CheckedChanged += DisableAllControlsCheckBox_CheckedChanged;
			ImageAlignComboBox.SelectedIndexChanged += ImageAlignComboBox_SelectedIndexChanged;
		}

		private void DisableAllControlsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SimpleButton.Enabled =
				ButtonWithImage.Enabled =
				ButtonWithStateSensitiveImage.Enabled =
				SimpleToggleButton.Enabled =
				ToggleButtonWithImage.Enabled =
				ToggleButtonWithStateSensitiveImage.Enabled =
				SimpleDropDown.Enabled =
				DropDownWithImage.Enabled =
				DropDownWithStateSensitiveImage.Enabled =
				SimpleSplitButton.Enabled =
				SplitButtonWithImage.Enabled =
				SplitButtonWithStateSensitiveImage.Enabled =
				TestSplitButton.Enabled =
				ImageAlignComboBox.Enabled =
				TextAlignComboBox.Enabled =
				TextImageRelationComboBox.Enabled =
				WithImageCheckBox.Enabled = !DisableButtonPageAllControlsCheckBox.Checked;

			if (WithImageCheckBox.Checked && !DisableButtonPageAllControlsCheckBox.Checked)
			{
				WithStaySensitiveImageCheckBox.Enabled = true;
			}
			else
				WithStaySensitiveImageCheckBox.Enabled = false;
		}

		private void ImageAlignComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			TestSplitButton.ImageAlign = (ContentAlignment)ImageAlignComboBox.SelectedItem;
		}

		private void TextAlignComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			TestSplitButton.TextAlign = (ContentAlignment)TextAlignComboBox.SelectedItem;
		}

		private void TextImageRelationComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			TestSplitButton.TextImageRelation = (TextImageRelation)TextImageRelationComboBox.SelectedItem;
		}

		private void CheckAlignComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CheckBox.CheckAlign =
			CheckBoxWithImage.CheckAlign = 
			CheckBoxWithStateSensitiveImage.CheckAlign =
			ThreeStateCheckBox.CheckAlign =
			ThreeStateCheckBoxWithImage.CheckAlign =
			ThreeStateCheckBoxWithStateSensitiveImage.CheckAlign =
			SampleRadioButton1.CheckAlign =
			RadioButton1WithImage.CheckAlign =
			RadioButton1WithStateSensitiveImage.CheckAlign =
			SampleRadioButton2.CheckAlign =
			RadioButton2WithImage.CheckAlign =
			RadioButton2WithStateSensitiveImage.CheckAlign =
			SampleRadioButton3.CheckAlign =
			RadioButton3WithImage.CheckAlign =
			RadioButton3WithStateSensitiveImage.CheckAlign = (ContentAlignment)CheckAlignComboBox.SelectedItem;
		}

		private void InitializeImageAlignComboBox()
		{
			ImageAlignComboBox.DataSource = Enum.GetValues(typeof(ContentAlignment));
			ImageAlignComboBox.SelectedItem = TestSplitButton.ImageAlign;
		}

		private void InitializeTextAlignComboBox()
		{
			TextAlignComboBox.DataSource = Enum.GetValues(typeof(ContentAlignment));
			TextAlignComboBox.SelectedItem = TestSplitButton.TextAlign;
		}

		private void InitializeTextImageRelationAlignComboBox()
		{
			TextImageRelationComboBox.DataSource = Enum.GetValues(typeof(TextImageRelation));
			TextImageRelationComboBox.SelectedItem = TestSplitButton.TextImageRelation;
		}

		private void InitializeCheckAlignComboBox()
		{
			CheckAlignComboBox.DataSource = Enum.GetValues(typeof(ContentAlignment));
			CheckAlignComboBox.SelectedItem = CheckBoxWithStateSensitiveImage.CheckAlign;
		}

		void SetButtonVisibility(bool simple, bool withImage, bool withStaySensitiveImage)
		{
			SimpleButton.Visible =
				SimpleDropDown.Visible =
				SimpleSplitButton.Visible =
				SimpleToggleButton.Visible =
				SimpleButton.Enabled =
				SimpleDropDown.Enabled =
				SimpleSplitButton.Enabled =
				SimpleToggleButton.Enabled = simple;

			ButtonWithImage.Visible =
				DropDownWithImage.Visible =
				SplitButtonWithImage.Visible =
				ToggleButtonWithImage.Visible =
				ButtonWithImage.Enabled =
				DropDownWithImage.Enabled =
				SplitButtonWithImage.Enabled =
				ToggleButtonWithImage.Enabled = withImage;

			ButtonWithStateSensitiveImage.Visible =
				DropDownWithStateSensitiveImage.Visible =
				SplitButtonWithStateSensitiveImage.Visible =
				ToggleButtonWithStateSensitiveImage.Visible =
				ButtonWithStateSensitiveImage.Enabled =
				DropDownWithStateSensitiveImage.Enabled =
				SplitButtonWithStateSensitiveImage.Enabled =
				ToggleButtonWithStateSensitiveImage.Enabled = withStaySensitiveImage;
		}

		private void WithImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			WithStaySensitiveImageCheckBox.Enabled = WithImageCheckBox.Checked;

			if (WithImageCheckBox.Checked && WithStaySensitiveImageCheckBox.Checked)
			{
				SetButtonVisibility(false, false, true);
				return;
			}
			else if (WithImageCheckBox.Checked && !WithStaySensitiveImageCheckBox.Checked)
			{
				SetButtonVisibility(false, true, false);
				return;
			}

			SetButtonVisibility(true, false, false);
		}

		private void WithStaySensitiveImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetButtonVisibility(false, !WithStaySensitiveImageCheckBox.Checked, WithStaySensitiveImageCheckBox.Checked);
		}

		private void DisableCheckAndRadioPageAllControlsCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			ThreeStateCheckBox.Enabled =
				CheckBox.Enabled = 
				SampleRadioButton1.Enabled =
				SampleRadioButton2.Enabled =
				SampleRadioButton3.Enabled =
				RadioGroupToggleButton1.Enabled =
				RadioGroupToggleButton2.Enabled =
				RadioGroupToggleButton3.Enabled =
				RadioGroupToggleButton4.Enabled =
				RadioGroupToggleButton5.Enabled =
				CheckBoxWithImage.Enabled =
				ThreeStateCheckBoxWithImage.Enabled =
				RadioButton1WithImage.Enabled =
				RadioButton2WithImage.Enabled =
				RadioButton3WithImage.Enabled =
				CheckBoxWithStateSensitiveImage.Enabled =
				ThreeStateCheckBoxWithStateSensitiveImage.Enabled =
				RadioButton1WithStateSensitiveImage.Enabled =
				RadioButton2WithStateSensitiveImage.Enabled =
				RadioButton3WithStateSensitiveImage.Enabled = 
				CheckAlignComboBox.Enabled = 
				CheckAndRadioWithImageCheckBox.Enabled = !DisableCheckAndRadioPageAllControlsCheckBox.Checked;

			if (CheckAndRadioWithImageCheckBox.Checked && !DisableCheckAndRadioPageAllControlsCheckBox.Checked)
			{
				CheckAndRadioWithStateSensitiveImageCheckBox.Enabled = true;
			}
			else
				CheckAndRadioWithStateSensitiveImageCheckBox.Enabled = false;
		}

		void SetCheckAndRadioVisibility(bool simple, bool withImage, bool withStaySensitiveImage)
		{
			bool first = SampleRadioButton1.Checked || RadioButton1WithImage.Checked || RadioButton1WithStateSensitiveImage.Checked;
			bool second = SampleRadioButton2.Checked || RadioButton2WithImage.Checked || RadioButton2WithStateSensitiveImage.Checked;
			bool third = SampleRadioButton3.Checked || RadioButton3WithImage.Checked || RadioButton3WithStateSensitiveImage.Checked;

			CheckBox.Visible =
				ThreeStateCheckBox.Visible =
				SampleRadioButton1.Visible =
				SampleRadioButton2.Visible =
				SampleRadioButton3.Visible =
				CheckBox.Enabled =
				ThreeStateCheckBox.Enabled =
				SampleRadioButton1.Enabled =
				SampleRadioButton2.Enabled =
				SampleRadioButton3.Enabled = simple;
			if (simple)
			{
				SampleRadioButton1.Checked = first;
				SampleRadioButton2.Checked = second;
				SampleRadioButton3.Checked = third;
			}

			CheckBoxWithImage.Visible =
				ThreeStateCheckBoxWithImage.Visible =
				RadioButton1WithImage.Visible =
				RadioButton2WithImage.Visible =
				RadioButton3WithImage.Visible =
				CheckBoxWithImage.Enabled =
				ThreeStateCheckBoxWithImage.Enabled =
				RadioButton1WithImage.Enabled =
				RadioButton2WithImage.Enabled =
				RadioButton3WithImage.Enabled = withImage;
			if (withImage)
			{
				RadioButton1WithImage.Checked = first;
				RadioButton2WithImage.Checked = second;
				RadioButton3WithImage.Checked = third;
			}

			CheckBoxWithStateSensitiveImage.Visible =
				ThreeStateCheckBoxWithStateSensitiveImage.Visible =
				RadioButton1WithStateSensitiveImage.Visible =
				RadioButton2WithStateSensitiveImage.Visible =
				RadioButton3WithStateSensitiveImage.Visible =
				CheckBoxWithStateSensitiveImage.Enabled =
				ThreeStateCheckBoxWithStateSensitiveImage.Enabled =
				RadioButton1WithStateSensitiveImage.Enabled =
				RadioButton2WithStateSensitiveImage.Enabled =
				RadioButton3WithStateSensitiveImage.Enabled = withStaySensitiveImage;
			if (withStaySensitiveImage)
			{
				RadioButton1WithStateSensitiveImage.Checked = first;
				RadioButton2WithStateSensitiveImage.Checked = second;
				RadioButton3WithStateSensitiveImage.Checked = third;
			}
		}
		private void CheckAndRadioWithImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckAndRadioWithStateSensitiveImageCheckBox.Enabled = CheckAndRadioWithImageCheckBox.Checked;

			if (CheckAndRadioWithImageCheckBox.Checked && CheckAndRadioWithStateSensitiveImageCheckBox.Checked)
			{
				SetCheckAndRadioVisibility(false, false, true);
				return;
			}
			else if (CheckAndRadioWithImageCheckBox.Checked && !CheckAndRadioWithStateSensitiveImageCheckBox.Checked)
			{
				SetCheckAndRadioVisibility(false, true, false);
				return;
			}

			SetCheckAndRadioVisibility(true, false, false);
		}

		private void CheckAndRadioWithStateSensitiveImageCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetCheckAndRadioVisibility(false, !CheckAndRadioWithStateSensitiveImageCheckBox.Checked, CheckAndRadioWithStateSensitiveImageCheckBox.Checked);
		}

		bool _checking;

		private void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			if (_checking)
				return;

			try
			{
				_checking = true;
				CheckBox checkBox = (CheckBox)sender;
				SetCheckBoxesState(checkBox.CheckState);
			}
			finally
			{
				_checking = false;
			}
		}

		private void SetCheckBoxesState(CheckState checkState)
		{
			CheckBox.CheckState =
			CheckBoxWithImage.CheckState = 
			CheckBoxWithStateSensitiveImage.CheckState = checkState;
		}
		
		private void SetThreeStateCheckBoxesState(CheckState checkState)
		{
			ThreeStateCheckBox.CheckState =
			ThreeStateCheckBoxWithImage.CheckState =
			ThreeStateCheckBoxWithStateSensitiveImage.CheckState = checkState;
		}

		bool _checkingIndeterming;

		private void ThreeStateCheckBox_CheckStateChanged(object sender, EventArgs e)
		{
			if (_checkingIndeterming)
				return;

			try
			{
				_checkingIndeterming = true;
				CheckBox checkBox = (CheckBox)sender;
				SetThreeStateCheckBoxesState(checkBox.CheckState);
			}
			finally
			{
				_checkingIndeterming = false;
			}
		}

		private void FlatStyleCheckBox_CheckedChanged(object sender, EventArgs e)
		{
			SetFlatStyle(FlatStyleCheckBox.Checked);
		}

		private void SetFlatStyle(bool flat)
		{
			FlatStyle flatStyle = flat ? FlatStyle.Flat : FlatStyle.Standard;

			SimpleButton.FlatStyle =
				SimpleDropDown.FlatStyle =
				SimpleSplitButton.FlatStyle =
				SimpleToggleButton.FlatStyle =
				SimpleButton.FlatStyle =
				SimpleDropDown.FlatStyle =
				SimpleSplitButton.FlatStyle =
				SimpleToggleButton.FlatStyle = flatStyle;

			ButtonWithImage.FlatStyle =
				DropDownWithImage.FlatStyle =
				SplitButtonWithImage.FlatStyle =
				ToggleButtonWithImage.FlatStyle =
				ButtonWithImage.FlatStyle =
				DropDownWithImage.FlatStyle =
				SplitButtonWithImage.FlatStyle =
				ToggleButtonWithImage.FlatStyle = flatStyle;

			ButtonWithStateSensitiveImage.FlatStyle =
				DropDownWithStateSensitiveImage.FlatStyle =
				SplitButtonWithStateSensitiveImage.FlatStyle =
				ToggleButtonWithStateSensitiveImage.FlatStyle =
				ButtonWithStateSensitiveImage.FlatStyle =
				DropDownWithStateSensitiveImage.FlatStyle =
				SplitButtonWithStateSensitiveImage.FlatStyle =
				ToggleButtonWithStateSensitiveImage.FlatStyle = flatStyle;
		}
	}
}