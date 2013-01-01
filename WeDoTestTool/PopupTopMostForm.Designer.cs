namespace Elegant.Ui.Samples.ControlsSample
{
    partial class PopupTopMostForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // PopupTopMostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "PopupTopMostForm";
            this.Text = "PopupTopMostForm";
            this.Deactivate += new System.EventHandler(this.PopupTopMostForm_Deactivate);
            this.Activated += new System.EventHandler(this.PopupTopMostForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PopupTopMostForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
    }
}