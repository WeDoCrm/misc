namespace Elegant.Ui.Samples.ControlsSample
{
	partial class MessageBoxPage
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new Elegant.Ui.Panel();
			this.controlsSampleGroupBox1 = new GroupBox();
			this.CaptionTextBox = new Elegant.Ui.TextBox();
			this.TextTextBox = new Elegant.Ui.TextBox();
			this.DefaultButtonComboBox = new Elegant.Ui.ComboBox();
			this.IconComboBox = new Elegant.Ui.ComboBox();
			this.ButtonsComboBox = new Elegant.Ui.ComboBox();
			this.ShowMessageBoxButton = new Elegant.Ui.Button();
			this.panel1.SuspendLayout();
			this.controlsSampleGroupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.controlsSampleGroupBox1);
			this.panel1.Controls.Add(this.ShowMessageBoxButton);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Id = "a7ba0360-c491-4949-9866-b24509d3e87a";
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(437, 400);
			this.panel1.TabIndex = 0;
			this.panel1.Text = "panel1";
			// 
			// controlsSampleGroupBox1
			// 
			this.controlsSampleGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.controlsSampleGroupBox1.Controls.Add(this.CaptionTextBox);
			this.controlsSampleGroupBox1.Controls.Add(this.TextTextBox);
			this.controlsSampleGroupBox1.Controls.Add(this.DefaultButtonComboBox);
			this.controlsSampleGroupBox1.Controls.Add(this.IconComboBox);
			this.controlsSampleGroupBox1.Controls.Add(this.ButtonsComboBox);
			this.controlsSampleGroupBox1.Location = new System.Drawing.Point(155, 9);
			this.controlsSampleGroupBox1.Name = "controlsSampleGroupBox1";
			this.controlsSampleGroupBox1.Size = new System.Drawing.Size(264, 199);
			this.controlsSampleGroupBox1.TabIndex = 1;
			this.controlsSampleGroupBox1.TabStop = false;
			this.controlsSampleGroupBox1.Text = "Settings";
			// 
			// CaptionTextBox
			// 
			this.CaptionTextBox.Id = "23d14b25-9a04-4480-b692-65f70b0ee235";
			this.CaptionTextBox.KeyTip = "C";
			this.CaptionTextBox.LabelAreaWidthTemplate = "Caption:";
			this.CaptionTextBox.LabelText = "Caption:";
			this.CaptionTextBox.Location = new System.Drawing.Point(21, 58);
			this.CaptionTextBox.Name = "CaptionTextBox";
			this.CaptionTextBox.ScreenTip.Text = "Caption";
			this.CaptionTextBox.Size = new System.Drawing.Size(223, 21);
			this.CaptionTextBox.TabIndex = 2;
			this.CaptionTextBox.Text = "Elegant UI";
			this.CaptionTextBox.TextEditorWidth = 175;
			// 
			// TextTextBox
			// 
			this.TextTextBox.Id = "586f447e-55d7-42e8-9c80-8ab7be57a086";
			this.TextTextBox.KeyTip = "T";
			this.TextTextBox.LabelAreaWidthTemplate = "Caption:";
			this.TextTextBox.LabelText = "Text:";
			this.TextTextBox.Location = new System.Drawing.Point(21, 24);
			this.TextTextBox.Name = "TextTextBox";
			this.TextTextBox.ScreenTip.Text = "Text";
			this.TextTextBox.Size = new System.Drawing.Size(223, 21);
			this.TextTextBox.TabIndex = 1;
			this.TextTextBox.Text = "Message box";
			this.TextTextBox.TextEditorWidth = 175;
			// 
			// DefaultButtonComboBox
			// 
			this.DefaultButtonComboBox.DrawMode = System.Windows.Forms.DrawMode.Normal;
			this.DefaultButtonComboBox.DroppedDown = false;
			this.DefaultButtonComboBox.Editable = false;
			this.DefaultButtonComboBox.FormatInfo = null;
			this.DefaultButtonComboBox.FormatString = "";
			this.DefaultButtonComboBox.FormattingEnabled = false;
			this.DefaultButtonComboBox.Id = "197fc96c-114d-4510-b30d-5cdffa9b209c";
			this.DefaultButtonComboBox.KeyTip = "D";
			this.DefaultButtonComboBox.LabelAreaWidthTemplate = "Message box options:";
			this.DefaultButtonComboBox.LabelText = "Default button:";
			this.DefaultButtonComboBox.Location = new System.Drawing.Point(21, 162);
			this.DefaultButtonComboBox.Name = "DefaultButtonComboBox";
			this.DefaultButtonComboBox.ScreenTip.Text = "Default button";
			this.DefaultButtonComboBox.Size = new System.Drawing.Size(223, 21);
			this.DefaultButtonComboBox.Sorted = false;
			this.DefaultButtonComboBox.TabIndex = 5;
			this.DefaultButtonComboBox.TextEditorWidth = 98;
			// 
			// IconComboBox
			// 
			this.IconComboBox.DrawMode = System.Windows.Forms.DrawMode.Normal;
			this.IconComboBox.DroppedDown = false;
			this.IconComboBox.Editable = false;
			this.IconComboBox.FormatInfo = null;
			this.IconComboBox.FormatString = "";
			this.IconComboBox.FormattingEnabled = false;
			this.IconComboBox.Id = "b27022ed-d750-4844-bafd-9e9b09fd0889";
			this.IconComboBox.KeyTip = "I";
			this.IconComboBox.LabelAreaWidthTemplate = "Message box options:";
			this.IconComboBox.LabelText = "Message box icon:";
			this.IconComboBox.Location = new System.Drawing.Point(21, 127);
			this.IconComboBox.Name = "IconComboBox";
			this.IconComboBox.ScreenTip.Text = "Icon";
			this.IconComboBox.Size = new System.Drawing.Size(223, 21);
			this.IconComboBox.Sorted = false;
			this.IconComboBox.TabIndex = 4;
			this.IconComboBox.TextEditorWidth = 101;
			// 
			// ButtonsComboBox
			// 
			this.ButtonsComboBox.DrawMode = System.Windows.Forms.DrawMode.Normal;
			this.ButtonsComboBox.DroppedDown = false;
			this.ButtonsComboBox.Editable = false;
			this.ButtonsComboBox.FormatInfo = null;
			this.ButtonsComboBox.FormatString = "";
			this.ButtonsComboBox.FormattingEnabled = false;
			this.ButtonsComboBox.Id = "f4469f54-ae8a-4183-99df-e4cbcc3331b6";
			this.ButtonsComboBox.KeyTip = "B";
			this.ButtonsComboBox.LabelAreaWidthTemplate = "Message box options:";
			this.ButtonsComboBox.LabelText = "Message box buttons:";
			this.ButtonsComboBox.Location = new System.Drawing.Point(21, 92);
			this.ButtonsComboBox.Name = "ButtonsComboBox";
			this.ButtonsComboBox.ScreenTip.Text = "Buttons";
			this.ButtonsComboBox.Size = new System.Drawing.Size(223, 21);
			this.ButtonsComboBox.Sorted = false;
			this.ButtonsComboBox.TabIndex = 3;
			// 
			// ShowMessageBoxButton
			// 
			this.ShowMessageBoxButton.Id = "1e2ec7bb-cb68-4556-9621-b747ebde4f54";
			this.ShowMessageBoxButton.KeyTip = "S";
			this.ShowMessageBoxButton.Location = new System.Drawing.Point(25, 32);
			this.ShowMessageBoxButton.Name = "ShowMessageBoxButton";
			this.ShowMessageBoxButton.ScreenTip.Text = "Show message box";
			this.ShowMessageBoxButton.Size = new System.Drawing.Size(75, 23);
			this.ShowMessageBoxButton.TabIndex = 0;
			this.ShowMessageBoxButton.Text = "Show";
			this.ShowMessageBoxButton.Click += new System.EventHandler(this.ShowMessageBoxButton_Click);
			// 
			// MessageBoxPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "MessageBoxPage";
			this.Size = new System.Drawing.Size(437, 400);
			this.panel1.ResumeLayout(false);
			this.controlsSampleGroupBox1.ResumeLayout(false);
			this.controlsSampleGroupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private Button ShowMessageBoxButton;
		private GroupBox controlsSampleGroupBox1;
		private ComboBox IconComboBox;
		private ComboBox ButtonsComboBox;
		private ComboBox DefaultButtonComboBox;
		private TextBox CaptionTextBox;
		private TextBox TextTextBox;
	}
}
