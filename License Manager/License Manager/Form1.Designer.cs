namespace License_Manager
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgv1 = new System.Windows.Forms.DataGridView();
            this.companyCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.companyName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isCheckToday = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.expireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.notifydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seatLimit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.con_menu_stip_show = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_close = new System.Windows.Forms.Button();
            this.btn_mac_refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv1
            // 
            this.dgv1.BackgroundColor = System.Drawing.Color.White;
            this.dgv1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyCode,
            this.companyName,
            this.isCheckToday,
            this.expireDate,
            this.notifydate,
            this.seatLimit,
            this.MAC});
            this.dgv1.Location = new System.Drawing.Point(11, 40);
            this.dgv1.Name = "dgv1";
            this.dgv1.RowHeadersVisible = false;
            this.dgv1.RowTemplate.Height = 23;
            this.dgv1.Size = new System.Drawing.Size(675, 210);
            this.dgv1.TabIndex = 0;
            // 
            // companyCode
            // 
            this.companyCode.Frozen = true;
            this.companyCode.HeaderText = "회사코드";
            this.companyCode.Name = "companyCode";
            this.companyCode.ReadOnly = true;
            this.companyCode.Width = 80;
            // 
            // companyName
            // 
            this.companyName.Frozen = true;
            this.companyName.HeaderText = "회사명";
            this.companyName.Name = "companyName";
            this.companyName.ReadOnly = true;
            // 
            // isCheckToday
            // 
            this.isCheckToday.Frozen = true;
            this.isCheckToday.HeaderText = "일접속";
            this.isCheckToday.Name = "isCheckToday";
            this.isCheckToday.ReadOnly = true;
            this.isCheckToday.Width = 70;
            // 
            // expireDate
            // 
            this.expireDate.Frozen = true;
            this.expireDate.HeaderText = "만료일자";
            this.expireDate.Name = "expireDate";
            this.expireDate.ReadOnly = true;
            // 
            // notifydate
            // 
            this.notifydate.Frozen = true;
            this.notifydate.HeaderText = "경고일자";
            this.notifydate.Name = "notifydate";
            // 
            // seatLimit
            // 
            this.seatLimit.Frozen = true;
            this.seatLimit.HeaderText = "최대사용자수";
            this.seatLimit.Name = "seatLimit";
            this.seatLimit.ReadOnly = true;
            // 
            // MAC
            // 
            this.MAC.Frozen = true;
            this.MAC.HeaderText = "MAC";
            this.MAC.Name = "MAC";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "고객추가";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(109, 11);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "라이선스 갱신";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "라이선스 매니저";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.con_menu_stip_show});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(111, 26);
            // 
            // con_menu_stip_show
            // 
            this.con_menu_stip_show.Name = "con_menu_stip_show";
            this.con_menu_stip_show.Size = new System.Drawing.Size(110, 22);
            this.con_menu_stip_show.Text = "보이기";
            this.con_menu_stip_show.Click += new System.EventHandler(this.con_menu_stip_show_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(578, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(106, 23);
            this.btn_close.TabIndex = 4;
            this.btn_close.Text = "종료";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_close_MouseClick);
            // 
            // btn_mac_refresh
            // 
            this.btn_mac_refresh.Location = new System.Drawing.Point(466, 11);
            this.btn_mac_refresh.Name = "btn_mac_refresh";
            this.btn_mac_refresh.Size = new System.Drawing.Size(106, 23);
            this.btn_mac_refresh.TabIndex = 5;
            this.btn_mac_refresh.Text = "MAC 초기화";
            this.btn_mac_refresh.UseVisualStyleBackColor = true;
            this.btn_mac_refresh.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btn_mac_refresh_MouseClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 262);
            this.Controls.Add(this.btn_mac_refresh);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "라이선스 매니저";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyName;
        private System.Windows.Forms.DataGridViewTextBoxColumn isCheckToday;
        private System.Windows.Forms.DataGridViewTextBoxColumn expireDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn notifydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn seatLimit;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAC;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem con_menu_stip_show;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Button btn_mac_refresh;
    }
}

