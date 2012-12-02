namespace Elegant.Ui.Samples.ControlsSample
{
	partial class ColorPickerPage
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
			this.SelectedShapeComboBox = new Elegant.Ui.ComboBox();
			this.controlsSampleGroupBox1 = new GroupBox();
			this.HSLRadioButton = new Elegant.Ui.RadioButton();
			this.LSHRadioButton = new Elegant.Ui.RadioButton();
			this.ModeSelectionVisibleCheckBox = new Elegant.Ui.CheckBox();
			this.ShowColorDialogButton = new Elegant.Ui.Button();
			this.separator1 = new Elegant.Ui.Separator();
			this.label2 = new Elegant.Ui.Label();
			this.label1 = new Elegant.Ui.Label();
			this.RoundedRectangle = new Elegant.Ui.Samples.ControlsSample.ShapeControl();
			this.Circle = new Elegant.Ui.Samples.ControlsSample.ShapeControl();
			this.Octagon = new Elegant.Ui.Samples.ControlsSample.ShapeControl();
			this.Star = new Elegant.Ui.Samples.ControlsSample.ShapeControl();
			this.BorderColorPicker = new Elegant.Ui.DropDownColorPicker();
			this.BackgroundColorPicker = new Elegant.Ui.DropDownColorPicker();
			this.moreColorsButton1 = new Elegant.Ui.MoreColorsButton();
			this.moreColorsButton2 = new Elegant.Ui.MoreColorsButton();
			this.panel1.SuspendLayout();
			this.controlsSampleGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.BorderColorPicker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BorderColorPicker.Popup)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundColorPicker)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundColorPicker.Popup)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.panel1.Controls.Add(this.SelectedShapeComboBox);
			this.panel1.Controls.Add(this.controlsSampleGroupBox1);
			this.panel1.Controls.Add(this.ShowColorDialogButton);
			this.panel1.Controls.Add(this.separator1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.RoundedRectangle);
			this.panel1.Controls.Add(this.Circle);
			this.panel1.Controls.Add(this.Octagon);
			this.panel1.Controls.Add(this.Star);
			this.panel1.Controls.Add(this.BorderColorPicker);
			this.panel1.Controls.Add(this.BackgroundColorPicker);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(635, 452);
			this.panel1.TabIndex = 0;
			this.panel1.Text = "panel1";
			// 
			// SelectedShapeComboBox
			// 
			this.SelectedShapeComboBox.Editable = false;
			this.SelectedShapeComboBox.FormattingEnabled = false;
			this.SelectedShapeComboBox.Id = "e7a98560-abc6-4c92-b8a0-c838e4f71c40";
			this.SelectedShapeComboBox.KeyTip = "S";
			this.SelectedShapeComboBox.LabelText = "Selected shape:";
			this.SelectedShapeComboBox.Location = new System.Drawing.Point(186, 18);
			this.SelectedShapeComboBox.Name = "SelectedShapeComboBox";
			this.SelectedShapeComboBox.ScreenTip.Caption = "Selected shape";
			this.SelectedShapeComboBox.ScreenTip.Text = "Changes the selected shape";
			this.SelectedShapeComboBox.Size = new System.Drawing.Size(201, 21);
			this.SelectedShapeComboBox.TabIndex = 2;
			this.SelectedShapeComboBox.TextEditorWidth = 102;
			// 
			// controlsSampleGroupBox1
			// 
			this.controlsSampleGroupBox1.Controls.Add(this.HSLRadioButton);
			this.controlsSampleGroupBox1.Controls.Add(this.LSHRadioButton);
			this.controlsSampleGroupBox1.Controls.Add(this.ModeSelectionVisibleCheckBox);
			this.controlsSampleGroupBox1.Location = new System.Drawing.Point(355, 271);
			this.controlsSampleGroupBox1.Name = "controlsSampleGroupBox1";
			this.controlsSampleGroupBox1.Size = new System.Drawing.Size(264, 129);
			this.controlsSampleGroupBox1.TabIndex = 8;
			this.controlsSampleGroupBox1.TabStop = false;
			this.controlsSampleGroupBox1.Text = "Settings";
			// 
			// HSLRadioButton
			// 
			this.HSLRadioButton.Checked = true;
			this.HSLRadioButton.Id = "b2a3f5b0-814c-4347-bac7-659951dadc40";
			this.HSLRadioButton.KeyTip = "H";
			this.HSLRadioButton.Location = new System.Drawing.Point(16, 55);
			this.HSLRadioButton.Name = "HSLRadioButton";
			this.HSLRadioButton.RadioGroupName = "2";
			this.HSLRadioButton.ScreenTip.Text = "Set color selection to Hue Saturation Lightness mode";
			this.HSLRadioButton.Size = new System.Drawing.Size(146, 23);
			this.HSLRadioButton.TabIndex = 1;
			this.HSLRadioButton.Text = "Hue Saturation Lightness";
			// 
			// LSHRadioButton
			// 
			this.LSHRadioButton.Id = "c4691467-a600-4ef6-bede-594d5d4f4cda";
			this.LSHRadioButton.KeyTip = "L";
			this.LSHRadioButton.Location = new System.Drawing.Point(16, 83);
			this.LSHRadioButton.Name = "LSHRadioButton";
			this.LSHRadioButton.RadioGroupName = "2";
			this.LSHRadioButton.ScreenTip.Text = "Set color selection to Lightness Saturation Hue mode";
			this.LSHRadioButton.Size = new System.Drawing.Size(146, 23);
			this.LSHRadioButton.TabIndex = 2;
			this.LSHRadioButton.Text = "Lightness Saturation Hue";
			// 
			// ModeSelectionVisibleCheckBox
			// 
			this.ModeSelectionVisibleCheckBox.Id = "222360fd-f75d-4796-924c-42e4e5af5830";
			this.ModeSelectionVisibleCheckBox.KeyTip = "M";
			this.ModeSelectionVisibleCheckBox.Location = new System.Drawing.Point(16, 28);
			this.ModeSelectionVisibleCheckBox.Name = "ModeSelectionVisibleCheckBox";
			this.ModeSelectionVisibleCheckBox.ScreenTip.Text = "Set check if you what to allow changes of color selection mode, otherwise unchek";
			this.ModeSelectionVisibleCheckBox.Size = new System.Drawing.Size(146, 23);
			this.ModeSelectionVisibleCheckBox.TabIndex = 0;
			this.ModeSelectionVisibleCheckBox.Text = "Mode selection visible";
			// 
			// ShowColorDialogButton
			// 
			this.ShowColorDialogButton.Id = "3e022aa4-86ed-410d-9f6f-5af028dde86b";
			this.ShowColorDialogButton.KeyTip = "D";
			this.ShowColorDialogButton.Location = new System.Drawing.Point(74, 289);
			this.ShowColorDialogButton.Name = "ShowColorDialogButton";
			this.ShowColorDialogButton.ScreenTip.Text = "Show color dialog";
			this.ShowColorDialogButton.Size = new System.Drawing.Size(103, 23);
			this.ShowColorDialogButton.TabIndex = 7;
			this.ShowColorDialogButton.Text = "Show color dialog";
			this.ShowColorDialogButton.Click += new System.EventHandler(this.ShowColorDialogButton_Click);
			// 
			// separator1
			// 
			this.separator1.Id = "27bc221a-8c37-4fbd-8ac7-92acf1826458";
			this.separator1.Location = new System.Drawing.Point(12, 239);
			this.separator1.Name = "separator1";
			this.separator1.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.separator1.Size = new System.Drawing.Size(610, 17);
			this.separator1.TabIndex = 3;
			this.separator1.Text = "Color dialog";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 22);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "Border color:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(87, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Background color:";
			// 
			// RoundedRectangle
			// 
			this.RoundedRectangle.Id = "a16e46cc-95c7-4e89-8f72-92790f008593";
			this.RoundedRectangle.KeyTip = "R";
			this.RoundedRectangle.Location = new System.Drawing.Point(384, 98);
			this.RoundedRectangle.Name = "RoundedRectangle";
			this.RoundedRectangle.Padding = new System.Windows.Forms.Padding(3);
			this.RoundedRectangle.RadioGroupName = "1";
			this.RoundedRectangle.ScreenTip.Text = "Rounded rectangle";
			this.RoundedRectangle.ShapeType = Elegant.Ui.Samples.ControlsSample.ShapeType.RoundedRectangle;
			this.RoundedRectangle.Size = new System.Drawing.Size(117, 117);
			this.RoundedRectangle.TabIndex = 6;
			this.RoundedRectangle.PressedChanged += new System.EventHandler(this.Shape_PressedChanged);
			// 
			// Circle
			// 
			this.Circle.Id = "3e31d7e8-8362-4b05-b0a6-3b165206ec52";
			this.Circle.KeyTip = "C";
			this.Circle.Location = new System.Drawing.Point(258, 98);
			this.Circle.Name = "Circle";
			this.Circle.Padding = new System.Windows.Forms.Padding(3);
			this.Circle.RadioGroupName = "1";
			this.Circle.ScreenTip.Text = "Circle";
			this.Circle.ShapeType = Elegant.Ui.Samples.ControlsSample.ShapeType.Circle;
			this.Circle.Size = new System.Drawing.Size(117, 117);
			this.Circle.TabIndex = 5;
			this.Circle.PressedChanged += new System.EventHandler(this.Shape_PressedChanged);
			// 
			// Octagon
			// 
			this.Octagon.Id = "784cf2b0-b4c4-4a3b-bc8f-6a587e6dc8d3";
			this.Octagon.KeyTip = "O";
			this.Octagon.Location = new System.Drawing.Point(14, 98);
			this.Octagon.Name = "Octagon";
			this.Octagon.Padding = new System.Windows.Forms.Padding(3);
			this.Octagon.RadioGroupName = "1";
			this.Octagon.ScreenTip.Text = "Octagon";
			this.Octagon.ShapeType = Elegant.Ui.Samples.ControlsSample.ShapeType.Octagon;
			this.Octagon.Size = new System.Drawing.Size(117, 117);
			this.Octagon.TabIndex = 3;
			this.Octagon.PressedChanged += new System.EventHandler(this.Shape_PressedChanged);
			// 
			// Star
			// 
			this.Star.Id = "b3457452-a24f-44da-8e9b-fa3781786622";
			this.Star.KeyTip = "T";
			this.Star.Location = new System.Drawing.Point(136, 98);
			this.Star.Name = "Star";
			this.Star.Padding = new System.Windows.Forms.Padding(3);
			this.Star.RadioGroupName = "1";
			this.Star.ScreenTip.Text = "Star";
			this.Star.ShapeType = Elegant.Ui.Samples.ControlsSample.ShapeType.Star;
			this.Star.Size = new System.Drawing.Size(117, 117);
			this.Star.TabIndex = 4;
			this.Star.PressedChanged += new System.EventHandler(this.Shape_PressedChanged);
			// 
			// BorderColorPicker
			// 
			this.BorderColorPicker.DropDownStyle = Elegant.Ui.DropDownControlStyle.SplitButton;
			this.BorderColorPicker.Id = "d13e83fb-0923-4209-ba9f-beeb8c9de70b";
			this.BorderColorPicker.InformativenessFixedLevel = "Elegant.Ui.GalleryInformativenessLevel:DropDownSmallImage";
			this.BorderColorPicker.ItemCategories.AddRange(new Elegant.Ui.GalleryItemCategory[] {
            new Elegant.Ui.ColorItemCategory("StandardColors", null, false, true, null),
            new Elegant.Ui.ColorItemCategory("RecentColors", null, false, true, null)});
			this.BorderColorPicker.Items.AddRange(new object[] {
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), null, "StandardColors")});
			this.BorderColorPicker.KeyTip = "B";
			this.BorderColorPicker.Location = new System.Drawing.Point(105, 16);
			this.BorderColorPicker.MaskColor = System.Drawing.Color.Black;
			this.BorderColorPicker.MoreColorsButton = this.moreColorsButton1;
			this.BorderColorPicker.Name = "BorderColorPicker";
			// 
			// 
			// 
			this.BorderColorPicker.Popup.Items.AddRange(new System.Windows.Forms.Control[] {
            this.moreColorsButton1});
			this.BorderColorPicker.Popup.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
			this.BorderColorPicker.Popup.Size = new System.Drawing.Size(100, 100);
			this.BorderColorPicker.PopupMinimumItemsInRowCount = 8;
			this.BorderColorPicker.ScreenTip.Caption = "Border Color";
			this.BorderColorPicker.ScreenTip.Text = "Changes the border color of the selected shape";
			this.BorderColorPicker.Size = new System.Drawing.Size(44, 23);
			this.BorderColorPicker.SmallImageColorMask = global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.BorderColorPickerImage;
			this.BorderColorPicker.SmallImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.BorderColorPickerImage)});
			this.BorderColorPicker.TabIndex = 0;
			this.BorderColorPicker.SelectedColorChanged += new System.EventHandler<Elegant.Ui.ColorPropertyChangedEventArgs>(this.BorderColorPicker_SelectedColorChanged);
			// 
			// BackgroundColorPicker
			// 
			this.BackgroundColorPicker.DropDownStyle = Elegant.Ui.DropDownControlStyle.SplitButton;
			this.BackgroundColorPicker.Id = "f425b2dd-403c-4521-b52e-2fb2891aa1fc";
			this.BackgroundColorPicker.InformativenessFixedLevel = "Elegant.Ui.GalleryInformativenessLevel:DropDownSmallImage";
			this.BackgroundColorPicker.ItemCategories.AddRange(new Elegant.Ui.GalleryItemCategory[] {
            new Elegant.Ui.ColorItemCategory("StandardColors", null, false, true, null),
            new Elegant.Ui.ColorItemCategory("RecentColors", null, false, true, null)});
			this.BackgroundColorPicker.Items.AddRange(new object[] {
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(160))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(255))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64))))), null, "StandardColors"),
            new Elegant.Ui.ColorItem(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), null, "StandardColors")});
			this.BackgroundColorPicker.KeyTip = "G";
			this.BackgroundColorPicker.Location = new System.Drawing.Point(105, 50);
			this.BackgroundColorPicker.MaskColor = System.Drawing.Color.Black;
			this.BackgroundColorPicker.MoreColorsButton = this.moreColorsButton2;
			this.BackgroundColorPicker.Name = "BackgroundColorPicker";
			// 
			// 
			// 
			this.BackgroundColorPicker.Popup.Items.AddRange(new System.Windows.Forms.Control[] {
            this.moreColorsButton2});
			this.BackgroundColorPicker.Popup.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
			this.BackgroundColorPicker.Popup.Size = new System.Drawing.Size(100, 100);
			this.BackgroundColorPicker.PopupMinimumItemsInRowCount = 8;
			this.BackgroundColorPicker.ScreenTip.Caption = "Background color";
			this.BackgroundColorPicker.ScreenTip.Text = "Changes the background color of the selected shape";
			this.BackgroundColorPicker.Size = new System.Drawing.Size(44, 23);
			this.BackgroundColorPicker.SmallImageColorMask = global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.BackgroundColorPickerImage;
			this.BackgroundColorPicker.SmallImages.Images.AddRange(new Elegant.Ui.ControlImage[] {
            new Elegant.Ui.ControlImage("Normal", global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.BackgroundColorPickerImage)});
			this.BackgroundColorPicker.TabIndex = 1;
			this.BackgroundColorPicker.SelectedColorChanged += new System.EventHandler<Elegant.Ui.ColorPropertyChangedEventArgs>(this.BackgroundColorPicker_SelectedColorChanged);
			// 
			// moreColorsButton1
			// 
			this.moreColorsButton1.Id = "558f09df-93a0-45a7-845a-1cc92d3926f9";
			this.moreColorsButton1.Location = new System.Drawing.Point(0, 0);
			this.moreColorsButton1.Name = "moreColorsButton1";
			this.moreColorsButton1.Size = new System.Drawing.Size(144, 23);
			this.moreColorsButton1.TabIndex = 2;
			// 
			// moreColorsButton2
			// 
			this.moreColorsButton2.Id = "6a107828-40c5-4c47-b6aa-51409ddd9686";
			this.moreColorsButton2.Location = new System.Drawing.Point(0, 0);
			this.moreColorsButton2.Name = "moreColorsButton2";
			this.moreColorsButton2.Size = new System.Drawing.Size(144, 23);
			this.moreColorsButton2.TabIndex = 2;
			// 
			// ColorPickerPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panel1);
			this.Name = "ColorPickerPage";
			this.Size = new System.Drawing.Size(635, 452);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.controlsSampleGroupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.BorderColorPicker.Popup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BorderColorPicker)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundColorPicker.Popup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BackgroundColorPicker)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Panel panel1;
		private DropDownColorPicker BackgroundColorPicker;
		private DropDownColorPicker BorderColorPicker;
		private Elegant.Ui.Samples.ControlsSample.ShapeControl Star;
		private Elegant.Ui.Samples.ControlsSample.ShapeControl Circle;
		private Elegant.Ui.Samples.ControlsSample.ShapeControl Octagon;
		private Label label2;
		private Label label1;
		private Separator separator1;
		private Button ShowColorDialogButton;
		private GroupBox controlsSampleGroupBox1;
		private ComboBox SelectedShapeComboBox;
		private CheckBox ModeSelectionVisibleCheckBox;
		private RadioButton HSLRadioButton;
		private RadioButton LSHRadioButton;
		private ShapeControl RoundedRectangle;
		private MoreColorsButton moreColorsButton1;
		private MoreColorsButton moreColorsButton2;
	}
}
