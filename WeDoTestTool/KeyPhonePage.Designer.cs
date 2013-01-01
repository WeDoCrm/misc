namespace Elegant.Ui.Samples.ControlsSample
{
    partial class KeyPhonePage
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
            this.components = new System.ComponentModel.Container();
            this.ListBoxPagePanel = new Elegant.Ui.Panel();
            this.SelectAllButton = new Elegant.Ui.Button();
            this.ClearSelectionButton = new Elegant.Ui.Button();
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.ListBoxPagePanel.Size = new System.Drawing.Size(761, 415);
            this.ListBoxPagePanel.TabIndex = 0;
            this.ListBoxPagePanel.Text = "ListBoxPagePanel";
            // 
            // SelectAllButton
            // 
            this.SelectAllButton.Id = "cd9a9d7f-2027-4898-aeb1-79a0bf80f7f4";
            this.SelectAllButton.Location = new System.Drawing.Point(537, 298);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(138, 21);
            this.SelectAllButton.TabIndex = 10;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.Id = "a2f773a3-6460-48c0-bde2-d2addb7d956b";
            this.ClearSelectionButton.Location = new System.Drawing.Point(386, 298);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(138, 21);
            this.ClearSelectionButton.TabIndex = 10;
            this.ClearSelectionButton.Text = "Clear Selection";
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearSelectionButton_Click);
            // 
            // AllowIntermediateChecksCheckBox
            // 
            this.AllowIntermediateChecksCheckBox.Id = "ce89699d-b9c0-4ad6-9b57-c6b94872bc2b";
            this.AllowIntermediateChecksCheckBox.Location = new System.Drawing.Point(386, 377);
            this.AllowIntermediateChecksCheckBox.Name = "AllowIntermediateChecksCheckBox";
            this.AllowIntermediateChecksCheckBox.Size = new System.Drawing.Size(174, 22);
            this.AllowIntermediateChecksCheckBox.TabIndex = 9;
            this.AllowIntermediateChecksCheckBox.Text = "Allow \'Intermediate\' Checks";
            this.AllowIntermediateChecksCheckBox.CheckedChanged += new System.EventHandler(this.AllowIntermediateChecksCheckBox_CheckedChanged);
            // 
            // BindToDataSetCheckBox
            // 
            this.BindToDataSetCheckBox.Id = "52c43e8f-309b-49a6-baec-1b04d2929761";
            this.BindToDataSetCheckBox.Location = new System.Drawing.Point(386, 264);
            this.BindToDataSetCheckBox.Name = "BindToDataSetCheckBox";
            this.BindToDataSetCheckBox.Size = new System.Drawing.Size(121, 22);
            this.BindToDataSetCheckBox.TabIndex = 7;
            this.BindToDataSetCheckBox.Text = "Bind to DataSet";
            this.BindToDataSetCheckBox.CheckedChanged += new System.EventHandler(this.BindToDataSetCheckBox_CheckedChanged);
            // 
            // CustomItemTextFormattingCheckBox
            // 
            this.CustomItemTextFormattingCheckBox.Id = "b8a78ed1-ea50-4e69-a69d-1bbd15d270bc";
            this.CustomItemTextFormattingCheckBox.Location = new System.Drawing.Point(386, 200);
            this.CustomItemTextFormattingCheckBox.Name = "CustomItemTextFormattingCheckBox";
            this.CustomItemTextFormattingCheckBox.Size = new System.Drawing.Size(192, 22);
            this.CustomItemTextFormattingCheckBox.TabIndex = 4;
            this.CustomItemTextFormattingCheckBox.Text = "Custom Item Text Formatting";
            this.CustomItemTextFormattingCheckBox.CheckedChanged += new System.EventHandler(this.CustomItemTextFormattingCheckBox_CheckedChanged);
            // 
            // CheckedItemIndicesTextBox
            // 
            this.CheckedItemIndicesTextBox.Id = "5146d667-51db-426c-84e0-55fd5145d1b7";
            this.CheckedItemIndicesTextBox.Location = new System.Drawing.Point(386, 354);
            this.CheckedItemIndicesTextBox.Name = "CheckedItemIndicesTextBox";
            this.CheckedItemIndicesTextBox.ReadOnly = true;
            this.CheckedItemIndicesTextBox.Size = new System.Drawing.Size(352, 20);
            this.CheckedItemIndicesTextBox.TabIndex = 8;
            this.CheckedItemIndicesTextBox.TextEditorWidth = 296;
            // 
            // CheckedItemsIndicesLabel
            // 
            this.CheckedItemsIndicesLabel.Location = new System.Drawing.Point(386, 338);
            this.CheckedItemsIndicesLabel.Name = "CheckedItemsIndicesLabel";
            this.CheckedItemsIndicesLabel.Size = new System.Drawing.Size(166, 12);
            this.CheckedItemsIndicesLabel.TabIndex = 7;
            this.CheckedItemsIndicesLabel.Text = "Checked Item Indices";
            // 
            // SelectedItemIndicesTextBox
            // 
            this.SelectedItemIndicesTextBox.Id = "78c2d103-b8ad-4f66-a523-6e159fe833e2";
            this.SelectedItemIndicesTextBox.Location = new System.Drawing.Point(386, 171);
            this.SelectedItemIndicesTextBox.Name = "SelectedItemIndicesTextBox";
            this.SelectedItemIndicesTextBox.ReadOnly = true;
            this.SelectedItemIndicesTextBox.Size = new System.Drawing.Size(352, 20);
            this.SelectedItemIndicesTextBox.TabIndex = 3;
            this.SelectedItemIndicesTextBox.TextEditorWidth = 296;
            // 
            // MultiselectionCheckBox
            // 
            this.MultiselectionCheckBox.Checked = true;
            this.MultiselectionCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MultiselectionCheckBox.Id = "23c535b6-2751-4d35-acbe-8807dce3a7da";
            this.MultiselectionCheckBox.Location = new System.Drawing.Point(386, 243);
            this.MultiselectionCheckBox.Name = "MultiselectionCheckBox";
            this.MultiselectionCheckBox.Size = new System.Drawing.Size(121, 22);
            this.MultiselectionCheckBox.TabIndex = 6;
            this.MultiselectionCheckBox.Text = "Multiple Selection";
            this.MultiselectionCheckBox.CheckedChanged += new System.EventHandler(this.MultiselectionCheckBox_CheckedChanged);
            // 
            // ListBoxSelectedItemIndicesLabel
            // 
            this.ListBoxSelectedItemIndicesLabel.Location = new System.Drawing.Point(386, 154);
            this.ListBoxSelectedItemIndicesLabel.Name = "ListBoxSelectedItemIndicesLabel";
            this.ListBoxSelectedItemIndicesLabel.Size = new System.Drawing.Size(201, 12);
            this.ListBoxSelectedItemIndicesLabel.TabIndex = 4;
            this.ListBoxSelectedItemIndicesLabel.Text = "List Box Selected Item Indices";
            // 
            // EventsLogLabel
            // 
            this.EventsLogLabel.Location = new System.Drawing.Point(386, 16);
            this.EventsLogLabel.Name = "EventsLogLabel";
            this.EventsLogLabel.Size = new System.Drawing.Size(73, 12);
            this.EventsLogLabel.TabIndex = 4;
            this.EventsLogLabel.Text = "Events Log";
            // 
            // CustomDrawingCheckBox
            // 
            this.CustomDrawingCheckBox.Id = "b2e99348-2b39-4a73-8997-055b2d994841";
            this.CustomDrawingCheckBox.Location = new System.Drawing.Point(386, 222);
            this.CustomDrawingCheckBox.Name = "CustomDrawingCheckBox";
            this.CustomDrawingCheckBox.Size = new System.Drawing.Size(121, 22);
            this.CustomDrawingCheckBox.TabIndex = 5;
            this.CustomDrawingCheckBox.Text = "Custom Drawing";
            this.CustomDrawingCheckBox.CheckedChanged += new System.EventHandler(this.CustomDrawingCheckBox_CheckedChanged);
            // 
            // EventLogTextBox
            // 
            this.EventLogTextBox.Id = "78867c0e-4b20-4313-8f8c-587483f9918f";
            this.EventLogTextBox.Location = new System.Drawing.Point(386, 30);
            this.EventLogTextBox.Multiline = true;
            this.EventLogTextBox.Name = "EventLogTextBox";
            this.EventLogTextBox.ReadOnly = true;
            this.EventLogTextBox.Size = new System.Drawing.Size(352, 111);
            this.EventLogTextBox.TabIndex = 2;
            this.EventLogTextBox.TextEditorWidth = 296;
            // 
            // DemoCheckedListBox
            // 
            this.DemoCheckedListBox.AutoScroll = true;
            this.DemoCheckedListBox.FormattingEnabled = false;
            this.DemoCheckedListBox.Id = "4e597100-d633-4743-9a8c-16ce0c5e82d2";
            this.DemoCheckedListBox.Location = new System.Drawing.Point(21, 210);
            this.DemoCheckedListBox.MultipleSelection = true;
            this.DemoCheckedListBox.Name = "DemoCheckedListBox";
            this.DemoCheckedListBox.Size = new System.Drawing.Size(346, 186);
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
            this.DemoListBox.Id = "62e88722-b2f3-445a-ad1e-d158a2bf3042";
            this.DemoListBox.Location = new System.Drawing.Point(21, 16);
            this.DemoListBox.MultipleSelection = true;
            this.DemoListBox.Name = "DemoListBox";
            this.DemoListBox.Size = new System.Drawing.Size(346, 178);
            this.DemoListBox.TabIndex = 0;
            this.DemoListBox.UserDefinedFixedHeight = 25;
            this.DemoListBox.FormatItem += new Elegant.Ui.ListBoxFormatItemEventHandler(this.DemoListBox_FormatItem);
            this.DemoListBox.MeasureItem += new Elegant.Ui.ListBoxItemSizeEventHandler(this.DemoListBox_MeasureItem);
            this.DemoListBox.DrawItem += new Elegant.Ui.ListBoxDrawItemEventHandler(this.DemoListBox_DrawItem);
            this.DemoListBox.SelectionChanged += new System.EventHandler(this.DemoListBox_SelectionChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // KeyPhonePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListBoxPagePanel);
            this.Name = "KeyPhonePage";
            this.Size = new System.Drawing.Size(761, 415);
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
        private System.Windows.Forms.Timer timer1;
    }
}
