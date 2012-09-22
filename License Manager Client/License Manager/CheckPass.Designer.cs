namespace License_Manager
{
    partial class CheckPass
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_pass = new System.Windows.Forms.TextBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "비밀번호";
            // 
            // tbx_pass
            // 
            this.tbx_pass.Location = new System.Drawing.Point(82, 14);
            this.tbx_pass.Name = "tbx_pass";
            this.tbx_pass.PasswordChar = '●';
            this.tbx_pass.Size = new System.Drawing.Size(100, 21);
            this.tbx_pass.TabIndex = 1;
            // 
            // btn_confirm
            // 
            this.btn_confirm.Location = new System.Drawing.Point(191, 12);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(75, 23);
            this.btn_confirm.TabIndex = 2;
            this.btn_confirm.Text = "확인";
            this.btn_confirm.UseVisualStyleBackColor = true;
            // 
            // CheckPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(278, 48);
            this.Controls.Add(this.btn_confirm);
            this.Controls.Add(this.tbx_pass);
            this.Controls.Add(this.label1);
            this.Name = "CheckPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbx_pass;
        public System.Windows.Forms.Button btn_confirm;
    }
}