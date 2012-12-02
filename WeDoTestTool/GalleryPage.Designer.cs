namespace Elegant.Ui.Samples.ControlsSample
{
    partial class GalleryPage
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
			this.GalleryPagePanel = new Elegant.Ui.Panel();
			this.GalleryContainerPanel = new Elegant.Ui.Samples.ControlsSample.GalleryContainerPanel();
			this.SampleGallery = new Elegant.Ui.Gallery();
			this.GallerySettingsPanel = new Elegant.Ui.Panel();
			this.CustomPaintingDemoToggleButton = new Elegant.Ui.ToggleButton();
			this.ExpandButtonVisibleCheckBox = new Elegant.Ui.CheckBox();
			this.FilterDropDownVisibleCheckBox = new Elegant.Ui.CheckBox();
			this.FilterEnabledCheckBox = new Elegant.Ui.CheckBox();
			this.DropDownCheckBox = new Elegant.Ui.CheckBox();
			this.PopupMinimumItemsInRowCountNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.MaximumItemsInRowCountNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.MinimumItemsInRowCountNumericUpDown = new Elegant.Ui.NumericUpDown();
			this.PopupResizeModeComboBox = new Elegant.Ui.ComboBox();
			this.InteractionModeComboBox = new Elegant.Ui.ComboBox();
			this.GalleryPagePanel.SuspendLayout();
			this.GalleryContainerPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.SampleGallery)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.SampleGallery.Popup)).BeginInit();
			this.GallerySettingsPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.PopupMinimumItemsInRowCountNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumItemsInRowCountNumericUpDown)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.MinimumItemsInRowCountNumericUpDown)).BeginInit();
			this.SuspendLayout();
			// 
			// GalleryPagePanel
			// 
			this.GalleryPagePanel.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.GalleryPagePanel.Controls.Add(this.GalleryContainerPanel);
			this.GalleryPagePanel.Controls.Add(this.GallerySettingsPanel);
			this.GalleryPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.GalleryPagePanel.Location = new System.Drawing.Point(0, 0);
			this.GalleryPagePanel.Name = "GalleryPagePanel";
			this.GalleryPagePanel.Size = new System.Drawing.Size(659, 455);
			this.GalleryPagePanel.TabIndex = 0;
			// 
			// GalleryContainerPanel
			// 
			this.GalleryContainerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.GalleryContainerPanel.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.GalleryContainerPanel.Controls.Add(this.SampleGallery);
			this.GalleryContainerPanel.Location = new System.Drawing.Point(18, 18);
			this.GalleryContainerPanel.Name = "GalleryContainerPanel";
			this.GalleryContainerPanel.Size = new System.Drawing.Size(358, 416);
			this.GalleryContainerPanel.TabIndex = 2;
			// 
			// SampleGallery
			// 
			this.SampleGallery.Dock = System.Windows.Forms.DockStyle.Fill;
			this.SampleGallery.ExpandButtonVisible = false;
			this.SampleGallery.Id = "168c8978-8864-4977-8516-abad9eabd7c2";
			this.SampleGallery.ItemCategories.AddRange(new Elegant.Ui.GalleryItemCategory[] {
            new Elegant.Ui.GalleryItemCategory("Winter", "Winter", true, true, null),
            new Elegant.Ui.GalleryItemCategory("Spring", "Spring", true, true, null),
            new Elegant.Ui.GalleryItemCategory("Summer", "Summer", true, true, null),
            new Elegant.Ui.GalleryItemCategory("Fall", "Fall", true, true, null)});
			this.SampleGallery.ItemCategoryFilters.AddRange(new Elegant.Ui.GalleryItemCategoryFilter[] {
            new Elegant.Ui.GalleryItemCategoryFilter("Winter", new string[] {
                        "Winter"}),
            new Elegant.Ui.GalleryItemCategoryFilter("Spring", new string[] {
                        "Spring"}),
            new Elegant.Ui.GalleryItemCategoryFilter("Summer", new string[] {
                        "Summer"}),
            new Elegant.Ui.GalleryItemCategoryFilter("Fall", new string[] {
                        "Fall"}),
            new Elegant.Ui.GalleryItemCategoryFilter("All Seasons", new string[] {
                        "Winter",
                        "Spring",
                        "Summer",
                        "Fall"})});
			this.SampleGallery.ItemContentPadding = new System.Windows.Forms.Padding(6);
			this.SampleGallery.ItemHeight = 115;
			this.SampleGallery.Items.AddRange(new object[] {
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter1, null, "Winter: Image 1", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter2, null, "Winter: Image 2", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter3, null, "Winter: Image 3", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter4, null, "Winter: Image 4", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter5, null, "Winter: Image 5", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter6, null, "Winter: Image 6", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter7, null, "Winter: Image 7", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter8, null, "Winter: Image 8", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter9, null, "Winter: Image 9", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Winter10, null, "Winter: Image 10", "Winter"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring1, null, "Spring: Image 1", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring2, null, "Spring: Image 2", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring3, null, "Spring: Image 3", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring4, null, "Spring: Image 4", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring5, null, "Spring: Image 5", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring6, null, "Spring: Image 6", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring7, null, "Spring: Image 7", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Spring8, null, "Spring: Image 8", "Spring"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer1, null, "Summer: Image 1", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer2, null, "Summer: Image 2", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer3, null, "Summer: Image 3", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer4, null, "Summer: Image 4", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer5, null, "Summer: Image 5", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer6, null, "Summer: Image 6", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer7, null, "Summer: Image 7", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Summer8, null, "Summer: Image 8", "Summer"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall1, null, "Fall: Image 1", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall2, null, "Fall: Image 2", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall3, null, "Fall: Image 3", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall4, null, "Fall: Image 4", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall5, null, "Fall: Image 5", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall6, null, "Fall: Image 6", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall7, null, "Fall: Image 7", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall8, null, "Fall: Image 8", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall9, null, "Fall: Image 9", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall10, null, "Fall: Image 10", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall11, null, "Fall: Image 11", "Fall"),
            new Elegant.Ui.GalleryItem(global::Elegant.Ui.Samples.ControlsSample.Properties.Resources.Fall2, null, "Fall: Image 12", "Fall")});
			this.SampleGallery.ItemWidth = 150;
			this.SampleGallery.Location = new System.Drawing.Point(0, 0);
			this.SampleGallery.Name = "SampleGallery";
			// 
			// 
			// 
			this.SampleGallery.Popup.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom;
			this.SampleGallery.Popup.Size = new System.Drawing.Size(100, 100);
			this.SampleGallery.Size = new System.Drawing.Size(358, 416);
			this.SampleGallery.TabIndex = 0;
			this.SampleGallery.Text = "Sample Gallery";
			// 
			// GallerySettingsPanel
			// 
			this.GallerySettingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.GallerySettingsPanel.AutoScrollMargin = new System.Drawing.Size(0, 0);
			this.GallerySettingsPanel.Controls.Add(this.CustomPaintingDemoToggleButton);
			this.GallerySettingsPanel.Controls.Add(this.ExpandButtonVisibleCheckBox);
			this.GallerySettingsPanel.Controls.Add(this.FilterDropDownVisibleCheckBox);
			this.GallerySettingsPanel.Controls.Add(this.FilterEnabledCheckBox);
			this.GallerySettingsPanel.Controls.Add(this.DropDownCheckBox);
			this.GallerySettingsPanel.Controls.Add(this.PopupMinimumItemsInRowCountNumericUpDown);
			this.GallerySettingsPanel.Controls.Add(this.MaximumItemsInRowCountNumericUpDown);
			this.GallerySettingsPanel.Controls.Add(this.MinimumItemsInRowCountNumericUpDown);
			this.GallerySettingsPanel.Controls.Add(this.PopupResizeModeComboBox);
			this.GallerySettingsPanel.Controls.Add(this.InteractionModeComboBox);
			this.GallerySettingsPanel.Location = new System.Drawing.Point(379, 18);
			this.GallerySettingsPanel.Name = "GallerySettingsPanel";
			this.GallerySettingsPanel.Size = new System.Drawing.Size(272, 416);
			this.GallerySettingsPanel.TabIndex = 1;
			// 
			// CustomPaintingDemoToggleButton
			// 
			this.CustomPaintingDemoToggleButton.Id = "182b1144-4f7e-4ff2-aed9-2e060b201899";
			this.CustomPaintingDemoToggleButton.KeyTip = "CP";
			this.CustomPaintingDemoToggleButton.Location = new System.Drawing.Point(10, 359);
			this.CustomPaintingDemoToggleButton.Name = "CustomPaintingDemoToggleButton";
			this.CustomPaintingDemoToggleButton.ScreenTip.Text = "Custom Painting Demo";
			this.CustomPaintingDemoToggleButton.Size = new System.Drawing.Size(154, 28);
			this.CustomPaintingDemoToggleButton.TabIndex = 9;
			this.CustomPaintingDemoToggleButton.Text = "Custom Painting Demo";
			this.CustomPaintingDemoToggleButton.PressedChanged += new System.EventHandler(this.CustomPaintingDemoToggleButton_PressedChanged);
			// 
			// ExpandButtonVisibleCheckBox
			// 
			this.ExpandButtonVisibleCheckBox.Id = "2f0a86bd-7352-46e8-b5de-7ac0953e5509";
			this.ExpandButtonVisibleCheckBox.KeyTip = "E";
			this.ExpandButtonVisibleCheckBox.Location = new System.Drawing.Point(10, 305);
			this.ExpandButtonVisibleCheckBox.Name = "ExpandButtonVisibleCheckBox";
			this.ExpandButtonVisibleCheckBox.ScreenTip.Text = "Expand Button Visible";
			this.ExpandButtonVisibleCheckBox.Size = new System.Drawing.Size(131, 23);
			this.ExpandButtonVisibleCheckBox.TabIndex = 8;
			this.ExpandButtonVisibleCheckBox.Text = "Expand Button Visible";
			// 
			// FilterDropDownVisibleCheckBox
			// 
			this.FilterDropDownVisibleCheckBox.Checked = true;
			this.FilterDropDownVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.FilterDropDownVisibleCheckBox.Enabled = false;
			this.FilterDropDownVisibleCheckBox.Id = "42aad5f2-e983-44b6-a84c-3bdb575252c8";
			this.FilterDropDownVisibleCheckBox.KeyTip = "FD";
			this.FilterDropDownVisibleCheckBox.Location = new System.Drawing.Point(10, 271);
			this.FilterDropDownVisibleCheckBox.Name = "FilterDropDownVisibleCheckBox";
			this.FilterDropDownVisibleCheckBox.ScreenTip.Text = "Filter Drop-Down Visible";
			this.FilterDropDownVisibleCheckBox.Size = new System.Drawing.Size(142, 23);
			this.FilterDropDownVisibleCheckBox.TabIndex = 7;
			this.FilterDropDownVisibleCheckBox.Text = "Filter Drop-Down Visible";
			// 
			// FilterEnabledCheckBox
			// 
			this.FilterEnabledCheckBox.Id = "05397b50-6b96-443a-874f-b8d85754b194";
			this.FilterEnabledCheckBox.KeyTip = "FR";
			this.FilterEnabledCheckBox.Location = new System.Drawing.Point(10, 237);
			this.FilterEnabledCheckBox.Name = "FilterEnabledCheckBox";
			this.FilterEnabledCheckBox.ScreenTip.Text = "Filter Enabled";
			this.FilterEnabledCheckBox.Size = new System.Drawing.Size(95, 23);
			this.FilterEnabledCheckBox.TabIndex = 6;
			this.FilterEnabledCheckBox.Text = "Filter Enabled";
			// 
			// DropDownCheckBox
			// 
			this.DropDownCheckBox.Id = "87e2bc1a-1b11-4353-990c-3f6ee185c61c";
			this.DropDownCheckBox.KeyTip = "D";
			this.DropDownCheckBox.Location = new System.Drawing.Point(10, 0);
			this.DropDownCheckBox.Name = "DropDownCheckBox";
			this.DropDownCheckBox.ScreenTip.Text = "Drop-Down mode";
			this.DropDownCheckBox.Size = new System.Drawing.Size(80, 23);
			this.DropDownCheckBox.TabIndex = 0;
			this.DropDownCheckBox.Text = "Drop-Down";
			// 
			// PopupMinimumItemsInRowCountNumericUpDown
			// 
			this.PopupMinimumItemsInRowCountNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
			this.PopupMinimumItemsInRowCountNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.PopupMinimumItemsInRowCountNumericUpDown.Id = "d00a7fa7-88c4-48a2-b732-11b30841cd29";
			this.PopupMinimumItemsInRowCountNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithImageAndLabel";
			this.PopupMinimumItemsInRowCountNumericUpDown.KeyTip = "PI";
			this.PopupMinimumItemsInRowCountNumericUpDown.LabelText = "Popup Minimum Items In Row Count";
			this.PopupMinimumItemsInRowCountNumericUpDown.Location = new System.Drawing.Point(10, 150);
			this.PopupMinimumItemsInRowCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.PopupMinimumItemsInRowCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.PopupMinimumItemsInRowCountNumericUpDown.Name = "PopupMinimumItemsInRowCountNumericUpDown";
			this.PopupMinimumItemsInRowCountNumericUpDown.ScreenTip.Text = "Popup Minimum Items In Row Count";
			this.PopupMinimumItemsInRowCountNumericUpDown.Size = new System.Drawing.Size(252, 21);
			this.PopupMinimumItemsInRowCountNumericUpDown.TabIndex = 4;
			this.PopupMinimumItemsInRowCountNumericUpDown.TextEditorWidth = 55;
			this.PopupMinimumItemsInRowCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// MaximumItemsInRowCountNumericUpDown
			// 
			this.MaximumItemsInRowCountNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
			this.MaximumItemsInRowCountNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.MaximumItemsInRowCountNumericUpDown.Id = "c6e6de09-e14b-4eee-90d5-3fd5648a7e6f";
			this.MaximumItemsInRowCountNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithImageAndLabel";
			this.MaximumItemsInRowCountNumericUpDown.KeyTip = "XI";
			this.MaximumItemsInRowCountNumericUpDown.LabelAreaWidthTemplate = "Popup Minimum Items In Row Count";
			this.MaximumItemsInRowCountNumericUpDown.LabelText = "Maximum Items In Row Count";
			this.MaximumItemsInRowCountNumericUpDown.Location = new System.Drawing.Point(10, 115);
			this.MaximumItemsInRowCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.MaximumItemsInRowCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MaximumItemsInRowCountNumericUpDown.Name = "MaximumItemsInRowCountNumericUpDown";
			this.MaximumItemsInRowCountNumericUpDown.ScreenTip.Text = "Maximum Items In Row Count";
			this.MaximumItemsInRowCountNumericUpDown.Size = new System.Drawing.Size(252, 21);
			this.MaximumItemsInRowCountNumericUpDown.TabIndex = 3;
			this.MaximumItemsInRowCountNumericUpDown.TextEditorWidth = 55;
			this.MaximumItemsInRowCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// MinimumItemsInRowCountNumericUpDown
			// 
			this.MinimumItemsInRowCountNumericUpDown.BackColor = System.Drawing.SystemColors.Window;
			this.MinimumItemsInRowCountNumericUpDown.BannerTextStyle = System.Drawing.FontStyle.Regular;
			this.MinimumItemsInRowCountNumericUpDown.Id = "d7913195-506e-4a55-961d-1641f4addb06";
			this.MinimumItemsInRowCountNumericUpDown.InformativenessFixedLevel = "Elegant.Ui.NumericUpDownInformativenessLevel:NumericUpDownWithImageAndLabel";
			this.MinimumItemsInRowCountNumericUpDown.KeyTip = "NI";
			this.MinimumItemsInRowCountNumericUpDown.LabelAreaWidthTemplate = "Popup Minimum Items In Row Count";
			this.MinimumItemsInRowCountNumericUpDown.LabelText = "Minimum Items In Row Count";
			this.MinimumItemsInRowCountNumericUpDown.Location = new System.Drawing.Point(10, 80);
			this.MinimumItemsInRowCountNumericUpDown.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
			this.MinimumItemsInRowCountNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.MinimumItemsInRowCountNumericUpDown.Name = "MinimumItemsInRowCountNumericUpDown";
			this.MinimumItemsInRowCountNumericUpDown.ScreenTip.Text = "Minimum Items In Row Count";
			this.MinimumItemsInRowCountNumericUpDown.Size = new System.Drawing.Size(252, 21);
			this.MinimumItemsInRowCountNumericUpDown.TabIndex = 2;
			this.MinimumItemsInRowCountNumericUpDown.TextEditorWidth = 55;
			this.MinimumItemsInRowCountNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// PopupResizeModeComboBox
			// 
			this.PopupResizeModeComboBox.BackColor = System.Drawing.SystemColors.Window;
			this.PopupResizeModeComboBox.Editable = false;
			this.PopupResizeModeComboBox.FormattingEnabled = false;
			this.PopupResizeModeComboBox.Id = "c0579f7f-e060-4ec2-b1b8-b07363debff9";
			this.PopupResizeModeComboBox.InformativenessFixedLevel = "Elegant.Ui.ComboBoxInformativenessLevel:ComboBoxWithImageAndLabel";
			this.PopupResizeModeComboBox.KeyTip = "PR";
			this.PopupResizeModeComboBox.LabelText = "Popup Resize Mode";
			this.PopupResizeModeComboBox.Location = new System.Drawing.Point(10, 185);
			this.PopupResizeModeComboBox.Name = "PopupResizeModeComboBox";
			this.PopupResizeModeComboBox.ScreenTip.Text = "Popup Resize Mode";
			this.PopupResizeModeComboBox.Size = new System.Drawing.Size(252, 21);
			this.PopupResizeModeComboBox.TabIndex = 5;
			this.PopupResizeModeComboBox.TextEditorWidth = 134;
			// 
			// InteractionModeComboBox
			// 
			this.InteractionModeComboBox.BackColor = System.Drawing.SystemColors.Window;
			this.InteractionModeComboBox.Editable = false;
			this.InteractionModeComboBox.FormattingEnabled = false;
			this.InteractionModeComboBox.Id = "89ea0903-145e-4751-a844-a57a54604cd2";
			this.InteractionModeComboBox.InformativenessFixedLevel = "Elegant.Ui.ComboBoxInformativenessLevel:ComboBoxWithImageAndLabel";
			this.InteractionModeComboBox.KeyTip = "IM";
			this.InteractionModeComboBox.LabelText = "Interaction Mode";
			this.InteractionModeComboBox.Location = new System.Drawing.Point(10, 45);
			this.InteractionModeComboBox.Name = "InteractionModeComboBox";
			this.InteractionModeComboBox.ScreenTip.Text = "Interaction Mode";
			this.InteractionModeComboBox.Size = new System.Drawing.Size(252, 21);
			this.InteractionModeComboBox.TabIndex = 1;
			this.InteractionModeComboBox.TextEditorWidth = 150;
			// 
			// GalleryPage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.GalleryPagePanel);
			this.Name = "GalleryPage";
			this.Size = new System.Drawing.Size(659, 455);
			this.GalleryPagePanel.ResumeLayout(false);
			this.GalleryContainerPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.SampleGallery.Popup)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.SampleGallery)).EndInit();
			this.GallerySettingsPanel.ResumeLayout(false);
			this.GallerySettingsPanel.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.PopupMinimumItemsInRowCountNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MaximumItemsInRowCountNumericUpDown)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.MinimumItemsInRowCountNumericUpDown)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private Panel GalleryPagePanel;
        private Gallery SampleGallery;
        private Panel GallerySettingsPanel;
        private CheckBox DropDownCheckBox;
        private NumericUpDown PopupMinimumItemsInRowCountNumericUpDown;
        private NumericUpDown MaximumItemsInRowCountNumericUpDown;
        private NumericUpDown MinimumItemsInRowCountNumericUpDown;
        private ComboBox PopupResizeModeComboBox;
        private ComboBox InteractionModeComboBox;
        private CheckBox FilterEnabledCheckBox;
        private CheckBox ExpandButtonVisibleCheckBox;
        private CheckBox FilterDropDownVisibleCheckBox;
        private GalleryContainerPanel GalleryContainerPanel;
        private ToggleButton CustomPaintingDemoToggleButton;
    }
}
