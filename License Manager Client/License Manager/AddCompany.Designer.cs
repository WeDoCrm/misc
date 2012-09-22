namespace License_Manager
{
    partial class AddCompany
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
            this.tbx_code = new System.Windows.Forms.TextBox();
            this.tbx_name = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_expire = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "회사코드";
            // 
            // tbx_code
            // 
            this.tbx_code.Location = new System.Drawing.Point(82, 32);
            this.tbx_code.Name = "tbx_code";
            this.tbx_code.Size = new System.Drawing.Size(100, 21);
            this.tbx_code.TabIndex = 1;
            // 
            // tbx_name
            // 
            this.tbx_name.Location = new System.Drawing.Point(82, 62);
            this.tbx_name.Name = "tbx_name";
            this.tbx_name.Size = new System.Drawing.Size(100, 21);
            this.tbx_name.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "회사명";
            // 
            // tbx_expire
            // 
            this.tbx_expire.Location = new System.Drawing.Point(82, 92);
            this.tbx_expire.Name = "tbx_expire";
            this.tbx_expire.Size = new System.Drawing.Size(100, 21);
            this.tbx_expire.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "만료일자";
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(66, 138);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 6;
            this.btn_add.Text = "추가";
            this.btn_add.UseVisualStyleBackColor = true;
            // 
            // AddCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 173);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.tbx_expire);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbx_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_code);
            this.Controls.Add(this.label1);
            this.Name = "AddCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "고객추가";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbx_code;
        public System.Windows.Forms.TextBox tbx_name;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbx_expire;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Button btn_add;
    }
}