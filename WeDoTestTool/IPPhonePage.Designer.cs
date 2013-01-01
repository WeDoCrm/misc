namespace Elegant.Ui.Samples.ControlsSample
{
    partial class IPPhonePage
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
            this.SelectAllButton.Id = "e56d6cf5-28c0-4e44-8cf1-5a77a064055a";
            this.SelectAllButton.Location = new System.Drawing.Point(537, 298);
            this.SelectAllButton.Name = "SelectAllButton";
            this.SelectAllButton.Size = new System.Drawing.Size(138, 21);
            this.SelectAllButton.TabIndex = 10;
            this.SelectAllButton.Text = "Select All";
            this.SelectAllButton.Click += new System.EventHandler(this.SelectAllButton_Click);
            // 
            // ClearSelectionButton
            // 
            this.ClearSelectionButton.Id = "4082b478-eb48-4e01-88bb-f3a77bd740e4";
            this.ClearSelectionButton.Location = new System.Drawing.Point(386, 298);
            this.ClearSelectionButton.Name = "ClearSelectionButton";
            this.ClearSelectionButton.Size = new System.Drawing.Size(138, 21);
            this.ClearSelectionButton.TabIndex = 10;
            this.ClearSelectionButton.Text = "Clear Selection";
            this.ClearSelectionButton.Click += new System.EventHandler(this.ClearSelectionButton_Click);
            // 
            // AllowIntermediateChecksCheckBox
            // 
            this.AllowIntermediateChecksCheckBox.Id = "ecc9c065-a2fe-428f-856b-8e036199c4b8";
            this.AllowIntermediateChecksCheckBox.Location = new System.Drawing.Point(386, 377);
            this.AllowIntermediateChecksCheckBox.Name = "AllowIntermediateChecksCheckBox";
            this.AllowIntermediateChecksCheckBox.Size = new System.Drawing.Size(174, 22);
            this.AllowIntermediateChecksCheckBox.TabIndex = 9;
            this.AllowIntermediateChecksCheckBox.Text = "Allow \'Intermediate\' Checks";
            this.AllowIntermediateChecksCheckBox.CheckedChanged += new System.EventHandler(this.AllowIntermediateChecksCheckBox_CheckedChanged);
            // 
            // BindToDataSetCheckBox
            // 
            this.BindToDataSetCheckBox.Id = "55451e82-7bae-4b8d-9206-99f36dc4788f";
            this.BindToDataSetCheckBox.Location = new System.Drawing.Point(386, 264);
            this.BindToDataSetCheckBox.Name = "BindToDataSetCheckBox";
            this.BindToDataSetCheckBox.Size = new System.Drawing.Size(121, 22);
            this.BindToDataSetCheckBox.TabIndex = 7;
            this.BindToDataSetCheckBox.Text = "Bind to DataSet";
            this.BindToDataSetCheckBox.CheckedChanged += new System.EventHandler(this.BindToDataSetCheckBox_CheckedChanged);
            // 
            // CustomItemTextFormattingCheckBox
            // 
            this.CustomItemTextFormattingCheckBox.Id = "29f57017-dad9-4456-a340-3996e31e8649";
            this.CustomItemTextFormattingCheckBox.Location = new System.Drawing.Point(386, 200);
            this.CustomItemTextFormattingCheckBox.Name = "CustomItemTextFormattingCheckBox";
            this.CustomItemTextFormattingCheckBox.Size = new System.Drawing.Size(192, 22);
            this.CustomItemTextFormattingCheckBox.TabIndex = 4;
            this.CustomItemTextFormattingCheckBox.Text = "Custom Item Text Formatting";
            this.CustomItemTextFormattingCheckBox.CheckedChanged += new System.EventHandler(this.CustomItemTextFormattingCheckBox_CheckedChanged);
            // 
            // CheckedItemIndicesTextBox
            // 
            this.CheckedItemIndicesTextBox.Id = "61bd4570-5478-44d3-8e73-6c7ea94d9867";
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
            this.SelectedItemIndicesTextBox.Id = "10ee4d6f-bf63-444d-be31-d4f6f3e5007e";
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
            this.MultiselectionCheckBox.Id = "3dfc0db6-52e1-442f-b09f-7b21f8bf5464";
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
            this.CustomDrawingCheckBox.Id = "a9336394-44c6-49b0-a14e-83e353f8cd00";
            this.CustomDrawingCheckBox.Location = new System.Drawing.Point(386, 222);
            this.CustomDrawingCheckBox.Name = "CustomDrawingCheckBox";
            this.CustomDrawingCheckBox.Size = new System.Drawing.Size(121, 22);
            this.CustomDrawingCheckBox.TabIndex = 5;
            this.CustomDrawingCheckBox.Text = "Custom Drawing";
            this.CustomDrawingCheckBox.CheckedChanged += new System.EventHandler(this.CustomDrawingCheckBox_CheckedChanged);
            // 
            // EventLogTextBox
            // 
            this.EventLogTextBox.Id = "ff023324-dec5-4783-a634-c8966bdbb0e0";
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
            this.DemoCheckedListBox.Id = "a0e607b1-8210-41ce-8932-42788d1fa782";
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
            this.DemoListBox.Id = "7b088c93-f38a-4d29-9a6c-a5e4c42e3c85";
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
            // IPPhonePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListBoxPagePanel);
            this.Name = "IPPhonePage";
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
