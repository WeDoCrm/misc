namespace Elegant.Ui.Samples.ControlsSample
{
    partial class ListBoxPage
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
            this.ListBoxPagePanel = new Elegant.Ui.Panel();
            this.AllowIntermediateChecksCheckBox = new Elegant.Ui.CheckBox();
            this.BindToDataSetCheckBox = new Elegant.Ui.CheckBox();
            this.CustomItemTextFormattingCheckBox = new Elegant.Ui.CheckBox();
            this.CheckedItemIndicesTextBox = new Elegant.Ui.TextBox();
            this.CheckedItemsIndicesLabel = new Elegant.Ui.Label();
            this.SelectedItemIndicesTextBox = new Elegant.Ui.TextBox();
            this.MultiselectionCheckBox = new Elegant.Ui.CheckBox();
            this.ListBoxSelectedItemIndicesLabel = new Elegant.Ui.Label();
            this.EventsLogLabel = new Elegant.Ui.Label();
            this.CustomDrawingCheckBox = new Elegant.Ui.CheckBox();
            this.EventLogTextBox = new Elegant.Ui.TextBox();
            this.DemoCheckedListBox = new Elegant.Ui.CheckedListBox();
            this.DemoListBox = new Elegant.Ui.ListBox();
            this.ClearSelectionButton = new Elegant.Ui.Button();
            this.SelectAllButton = new Elegant.Ui.Button();
            this.ListBoxPagePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemoCheckedListBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemoListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ListBoxPagePanel
            // 
            this.ListBoxPagePanel.Controls.Add(this.SelectAllButton);
            this.ListBoxPagePanel.Controls.Add(this.ClearSelectionButton);
            this.ListBoxPagePanel.Controls.Add(this.AllowIntermediateChecksCheckBox);
            this.ListBoxPagePanel.Controls.Add(this.BindToDataSetCheckBox);
            this.ListBoxPagePanel.Controls.Add(this.CustomItemTextFormattingCheckBox);
            this.ListBoxPagePanel.Controls.Add(this.CheckedItemIndicesTextBox);
            this.ListBoxPagePanel.Controls.Add(this.CheckedItemsIndicesLabel);
            this.ListBoxPagePanel.Controls.Add(this.SelectedItemIndicesTextBox);
            this.ListBoxPagePanel.Controls.Add(this.MultiselectionCheckBox);
            this.ListBoxPagePanel.Controls.Add(this.ListBoxSelectedItemIndicesLabel);
            this.ListBoxPagePanel.Controls.Add(this.EventsLogLabel);
            this.ListBoxPagePanel.Controls.Add(this.CustomDrawingCheckBox);
            this.ListBoxPagePanel.Controls.Add(this.EventLogTextBox);
            this.ListBoxPagePanel.Controls.Add(this.DemoCheckedListBox);
            this.ListBoxPagePanel.Controls.Add(this.DemoListBox);
            this.ListBoxPagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListBoxPagePanel.Location = new System.Drawing.Point(0, 0);
            this.ListBoxPagePanel.Name = "ListBoxPagePanel";
            this.ListBoxPagePanel.Size = new System.Drawing.Size(652, 450);
            this.ListBoxPagePanel.TabIndex = 0;
            this.ListBoxPagePanel.Text = "ListBoxPagePanel";
            // 
            // AllowIntermediateChecksCheckBox
            // 
            this.AllowIntermediateChecksCheckBox.Id = "f40f9f42-08c5-4e40-b036-592d84f7ce7f";
            this.AllowIntermediateChecksCheckBox.Location = new System.Drawing.Point(331, 408);
            this.AllowIntermediateChecksCheckBox.Name = "AllowIntermediateChecksCheckBox";
            this.AllowIntermediateChecksCheckBox.Size = new System.Drawing.Size(149, 24);
            this.AllowIntermediateChecksCheckBox.TabIndex = 9;
            this.AllowIntermediateChecksCheckBox.Text = "Allow \'Intermediate\' Checks";
            this.AllowIntermediateChecksCheckBox.CheckedChanged += new System.EventHandler(this.AllowIntermediateChecksCheckBox_CheckedChanged);
            // 
            // BindToDataSetCheckBox
            // 
            this.BindToDataSetCheckBox.Id = "f087b793-f0cc-4a5d-b3a2-3902f7546078";
            this.BindToDataSetCheckBox.Location = new System.Drawing.Point(331, 286);
            this.BindToDataSetCheckBox.Name = "BindToDataSetCheckBox";
            this.BindToDataSetCheckBox.Size = new System.Drawing.Size(104, 24);
            this.BindToDataSetCheckBox.TabIndex = 7;
            this.BindToDataSetCheckBox.Text = "Bind to DataSet";
            this.BindToDataSetCheckBox.CheckedChanged += new System.EventHandler(this.BindToDataSetCheckBox_CheckedChanged);
            // 
            // CustomItemTextFormattingCheckBox
            // 
            this.CustomItemTextFormattingCheckBox.Id = "e5e9ee4c-8965-4c0d-9973-e89ee0a05617";
            this.CustomItemTextFormattingCheckBox.Location = new System.Drawing.Point(331, 217);
            this.CustomItemTextFormattingCheckBox.Name = "CustomItemTextFormattingCheckBox";
            this.CustomItemTextFormattingCheckBox.Size = new System.Drawing.Size(165, 24);
            this.CustomItemTextFormattingCheckBox.TabIndex = 4;
            this.CustomItemTextFormattingCheckBox.Text = "Custom Item Text Formatting";
            this.CustomItemTextFormattingCheckBox.CheckedChanged += new System.EventHandler(this.CustomItemTextFormattingCheckBox_CheckedChanged);
            // 
            // CheckedItemIndicesTextBox
            // 
            this.CheckedItemIndicesTextBox.Id = "ece29477-fca0-499a-ba9d-c606ec95b632";
            this.CheckedItemIndicesTextBox.Location = new System.Drawing.Point(331, 384);
            this.CheckedItemIndicesTextBox.Name = "CheckedItemIndicesTextBox";
            this.CheckedItemIndicesTextBox.ReadOnly = true;
            this.CheckedItemIndicesTextBox.Size = new System.Drawing.Size(302, 21);
            this.CheckedItemIndicesTextBox.TabIndex = 8;
            this.CheckedItemIndicesTextBox.TextEditorWidth = 296;
            // 
            // CheckedItemsIndicesLabel
            // 
            this.CheckedItemsIndicesLabel.Location = new System.Drawing.Point(331, 366);
            this.CheckedItemsIndicesLabel.Name = "CheckedItemsIndicesLabel";
            this.CheckedItemsIndicesLabel.Size = new System.Drawing.Size(142, 13);
            this.CheckedItemsIndicesLabel.TabIndex = 7;
            this.CheckedItemsIndicesLabel.Text = "Checked Item Indices";
            // 
            // SelectedItemIndicesTextBox
            // 
            this.SelectedItemIndicesTextBox.Id = "c0d179d1-4077-42d5-9102-4a09ae26d743";
            this.SelectedItemIndicesTextBox.Location = new System.Drawing.Point(331, 185);
            this.SelectedItemIndicesTextBox.Name = "SelectedItemIndicesTextBox";
            this.SelectedItemIndicesTextBox.ReadOnly = true;
            this.SelectedItemIndicesTextBox.Size = new System.Drawing.Size(302, 21);
            this.SelectedItemIndicesTextBox.TabIndex = 3;
            this.SelectedItemIndicesTextBox.TextEditorWidth = 296;
            // 
            // MultiselectionCheckBox
            // 
            this.MultiselectionCheckBox.Checked = true;
            this.MultiselectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MultiselectionCheckBox.Id = "98ebc93b-c907-4340-be0c-0bbee3209cf8";
            this.MultiselectionCheckBox.Location = new System.Drawing.Point(331, 263);
            this.MultiselectionCheckBox.Name = "MultiselectionCheckBox";
            this.MultiselectionCheckBox.Size = new System.Drawing.Size(104, 24);
            this.MultiselectionCheckBox.TabIndex = 6;
            this.MultiselectionCheckBox.Text = "Multiple Selection";
            this.MultiselectionCheckBox.CheckedChanged += new System.EventHandler(this.MultiselectionCheckBox_CheckedChanged);
            // 
            // ListBoxSelectedItemIndicesLabel
            // 
            this.ListBoxSelectedItemIndicesLabel.Location = new System.Drawing.Point(331, 167);
            this.ListBoxSelectedItemIndicesLabel.Name = "ListBoxSelectedItemIndicesLabel";
            this.ListBoxSelectedItemIndicesLabel.Size = new System.Drawing.Size(142, 13);
            this.ListBoxSelectedItemIndicesLabel.TabIndex = 4;
            this.ListBoxSelectedItemIndicesLabel.Text = "List Box Selected Item Indices";
            // 
            // EventsLogLabel
            // 
            this.EventsLogLabel.Location = new System.Drawing.Point(331, 17);
            this.EventsLogLabel.Name = "EventsLogLabel";
            this.EventsLogLabel.Size = new System.Drawing.Size(54, 13);
            this.EventsLogLabel.TabIndex = 4;
            this.EventsLogLabel.Text = "Events Log";
            // 
            // CustomDrawingCheckBox
            // 
            this.CustomDrawingCheckBox.Id = "14003bd8-d5ee-400c-a202-9ba2d3310099";
            this.CustomDrawingCheckBox.Location = new System.Drawing.Point(331, 240);
            this.CustomDrawingCheckBox.Name = "CustomDrawingCheckBox";
            this.CustomDrawingCheckBox.Size = new System.Drawing.Size(104, 24);
            this.CustomDrawingCheckBox.TabIndex = 5;
            this.CustomDrawingCheckBox.Text = "Custom Drawing";
            this.CustomDrawingCheckBox.CheckedChanged += new System.EventHandler(this.CustomDrawingCheckBox_CheckedChanged);
            // 
            // EventLogTextBox
            // 
            this.EventLogTextBox.Id = "732c7828-b1d2-49f0-b658-7489b550d006";
            this.EventLogTextBox.Location = new System.Drawing.Point(331, 33);
            this.EventLogTextBox.Multiline = true;
            this.EventLogTextBox.Name = "EventLogTextBox";
            this.EventLogTextBox.ReadOnly = true;
            this.EventLogTextBox.Size = new System.Drawing.Size(302, 120);
            this.EventLogTextBox.TabIndex = 2;
            this.EventLogTextBox.TextEditorWidth = 296;
            // 
            // DemoCheckedListBox
            // 
            this.DemoCheckedListBox.AutoScroll = true;
            this.DemoCheckedListBox.FormattingEnabled = false;
            this.DemoCheckedListBox.Id = "3f43d799-33ef-4235-8b1c-eb1cbc278b95";
            this.DemoCheckedListBox.Location = new System.Drawing.Point(18, 228);
            this.DemoCheckedListBox.MultipleSelection = true;
            this.DemoCheckedListBox.Name = "DemoCheckedListBox";
            this.DemoCheckedListBox.Size = new System.Drawing.Size(297, 202);
            this.DemoCheckedListBox.TabIndex = 1;
            this.DemoCheckedListBox.Text = "checkedListBox1";
            this.DemoCheckedListBox.UserDefinedFixedHeight = 25;
            this.DemoCheckedListBox.FormatItem += new Elegant.Ui.ListBoxFormatItemEventHandler(this.DemoCheckedListBox_FormatItem);
            this.DemoCheckedListBox.MeasureItem += new Elegant.Ui.ListBoxItemSizeEventHandler(this.DemoCheckedListBox_MeasureItem);
            this.DemoCheckedListBox.DrawItem += new Elegant.Ui.ListBoxDrawItemEventHandler(this.DemoCheckedListBox_DrawItem);
            this.DemoCheckedListBox.SelectionChanged += new System.EventHandler(this.DemoCheckedListBox_SelectionChanged);
            this.DemoCheckedListBox.ItemCheckStateChanged += new Elegant.Ui.ListBoxItemEventHandler(this.DemoCheckedListBox_ItemCheckStateChanged);
            // 
            // DemoListBox
            // 
            this.DemoListBox.AutoScroll = true;
            this.DemoListBox.FormattingEnabled = false;
            this.DemoListBox.Id = "2172c30f-d8a8-4c1f-8dbe-52709e93d973";
            this.DemoListBox.Location = new System.Drawing.Point(18, 17);
            this.DemoListBox.MultipleSelection = true;
            this.DemoListBox.Name = "DemoListBox";
            this.DemoListBox.Size = new System.Drawing.Size(297, 193);
            this.DemoListBox.TabIndex = 0;
            this.DemoListBox.UserDefinedFixedHeight = 25;
            this.DemoListBox.FormatItem += new Elegant.Ui.ListBoxFormatItemEventHandler(this.DemoListBox_FormatItem);
            this.DemoListBox.MeasureItem += new Elegant.Ui.ListBoxItemSizeEventHandler(this.DemoListBox_MeasureItem);
            this.DemoListBox.DrawItem += new Elegant.Ui.ListBoxDrawItemEventHandler(this.DemoListBox_DrawItem);
            this.DemoListBox.SelectionChanged += new System.EventHandler(this.DemoListBox_SelectionChanged);
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.Id = "e8ab7502-14e1-415e-a42b-2defce4d6002";
            this.ClearSelectionButton.Location = new System.Drawing.Point(331, 323);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(118, 23);
            this.ClearSelectionButton.TabIndex = 10;
            this.ClearSelectionButton.Text = "Clear Selection";
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearSelectionButton_Click);
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Id = "181c6ffa-fd1b-4bbd-a53c-1e48638e93b2";
            this.SelectAllButton.Location = new System.Drawing.Point(460, 323);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(118, 23);
            this.SelectAllButton.TabIndex = 10;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // ListBoxPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListBoxPagePanel);
            this.Name = "ListBoxPage";
            this.Size = new System.Drawing.Size(652, 450);
            this.ListBoxPagePanel.ResumeLayout(false);
            this.ListBoxPagePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DemoCheckedListBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DemoListBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel ListBoxPagePanel;
        private ListBox DemoListBox;
        private CheckedListBox DemoCheckedListBox;
        private TextBox EventLogTextBox;
        private CheckBox CustomDrawingCheckBox;
        private Label EventsLogLabel;
        private CheckBox MultiselectionCheckBox;
        private Label ListBoxSelectedItemIndicesLabel;
        private TextBox SelectedItemIndicesTextBox;
        private TextBox CheckedItemIndicesTextBox;
        private Label CheckedItemsIndicesLabel;
        private CheckBox CustomItemTextFormattingCheckBox;
        private CheckBox BindToDataSetCheckBox;
        private CheckBox AllowIntermediateChecksCheckBox;
        private Button SelectAllButton;
        private Button ClearSelectionButton;
    }
}
