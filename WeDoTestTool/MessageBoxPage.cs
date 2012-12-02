using System;
using System.Windows.Forms;

namespace Elegant.Ui.Samples.ControlsSample
{
	public partial class MessageBoxPage : SamplePageBase
	{
		public MessageBoxPage()
		{
			InitializeComponent();
			InitializeComboBoxes();
		}

		private void InitializeComboBoxes()
		{
			ButtonsComboBox.DataSource = Enum.GetValues(typeof (MessageBoxButtons));
			ButtonsComboBox.SelectedItem = ButtonsComboBox.Items[0];

			IconComboBox.DataSource = Enum.GetNames(typeof(MessageBoxIcon));
			IconComboBox.SelectedIndex = IconComboBox.Items.IndexOf(MessageBoxIcon.Information.ToString());

			DefaultButtonComboBox.DataSource = Enum.GetValues(typeof(MessageBoxDefaultButton));
			DefaultButtonComboBox.SelectedItem = DefaultButtonComboBox.Items[0];
		}

		private void ShowMessageBoxButton_Click(object sender, EventArgs e)
		{
			string text = TextTextBox.Text;
			string caption = CaptionTextBox.Text;
			MessageBoxButtons buttons = (MessageBoxButtons)ButtonsComboBox.SelectedItem;
			MessageBoxIcon icon = (MessageBoxIcon)Enum.Parse(typeof(MessageBoxIcon), IconComboBox.SelectedItem.ToString());
			MessageBoxDefaultButton defaultButton = (MessageBoxDefaultButton)DefaultButtonComboBox.SelectedItem;

			if(RightToLeft != RightToLeft.Yes)
				MessageBox.Show(this, text, caption, buttons, icon, defaultButton);
			else
				MessageBox.Show(this, text, caption, buttons, icon, defaultButton, MessageBoxOptions.RtlReading);
		}
	}
}
