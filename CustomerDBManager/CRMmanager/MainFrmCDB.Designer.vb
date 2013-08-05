<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFrmCDB
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFrmCDB))
        Me.gbBackup = New System.Windows.Forms.GroupBox
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnBackup = New System.Windows.Forms.Button
        Me.gbDelete = New System.Windows.Forms.GroupBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.btnDelete = New System.Windows.Forms.Button
        Me.gbUpload = New System.Windows.Forms.GroupBox
        Me.cbMergeYN = New System.Windows.Forms.CheckBox
        Me.btnResult = New System.Windows.Forms.Button
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.btnUpload = New System.Windows.Forms.Button
        Me.gbRecovery = New System.Windows.Forms.GroupBox
        Me.TextBox5 = New System.Windows.Forms.TextBox
        Me.btnRecovery = New System.Windows.Forms.Button
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.stLabel1 = New System.Windows.Forms.ToolStripStatusLabel
        Me.stLabel2 = New System.Windows.Forms.ToolStripStatusLabel
        Me.stLabel3 = New System.Windows.Forms.ToolStripStatusLabel
        Me.AquaSkin2 = New SkinSoft.AquaSkin.AquaSkin(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.lblCompany = New System.Windows.Forms.Label
        Me.TimerUpload = New System.Windows.Forms.Timer(Me.components)
        Me.BackgroundWorkerMain = New System.ComponentModel.BackgroundWorker
        Me.Button1 = New System.Windows.Forms.Button
        Me.gbBackup.SuspendLayout()
        Me.gbDelete.SuspendLayout()
        Me.gbUpload.SuspendLayout()
        Me.gbRecovery.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.AquaSkin2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbBackup
        '
        Me.gbBackup.Controls.Add(Me.TextBox1)
        Me.gbBackup.Controls.Add(Me.btnBackup)
        Me.gbBackup.Location = New System.Drawing.Point(53, 63)
        Me.gbBackup.Name = "gbBackup"
        Me.gbBackup.Size = New System.Drawing.Size(596, 64)
        Me.gbBackup.TabIndex = 0
        Me.gbBackup.TabStop = False
        Me.gbBackup.Text = "고객정보 백업"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox1.Location = New System.Drawing.Point(144, 20)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(412, 35)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "현재 사용중인 고객데이터를 백업합니다."
        '
        'btnBackup
        '
        Me.btnBackup.Location = New System.Drawing.Point(15, 20)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(96, 35)
        Me.btnBackup.TabIndex = 0
        Me.btnBackup.Text = "백업"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'gbDelete
        '
        Me.gbDelete.Controls.Add(Me.TextBox2)
        Me.gbDelete.Controls.Add(Me.btnDelete)
        Me.gbDelete.Location = New System.Drawing.Point(53, 137)
        Me.gbDelete.Name = "gbDelete"
        Me.gbDelete.Size = New System.Drawing.Size(596, 64)
        Me.gbDelete.TabIndex = 1
        Me.gbDelete.TabStop = False
        Me.gbDelete.Text = "고객정보 삭제"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox2.Location = New System.Drawing.Point(144, 20)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(412, 35)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "고객정보 불러오기를 위해 백업한 고객데이터를 삭제합니다. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "**추후 작업취소시 복구가 가능합니다."
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(15, 20)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(96, 35)
        Me.btnDelete.TabIndex = 0
        Me.btnDelete.Text = "삭제"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'gbUpload
        '
        Me.gbUpload.Controls.Add(Me.cbMergeYN)
        Me.gbUpload.Controls.Add(Me.btnResult)
        Me.gbUpload.Controls.Add(Me.TextBox4)
        Me.gbUpload.Controls.Add(Me.btnUpload)
        Me.gbUpload.Location = New System.Drawing.Point(53, 213)
        Me.gbUpload.Name = "gbUpload"
        Me.gbUpload.Size = New System.Drawing.Size(596, 64)
        Me.gbUpload.TabIndex = 3
        Me.gbUpload.TabStop = False
        Me.gbUpload.Text = "고객정보 불러오기"
        '
        'cbMergeYN
        '
        Me.cbMergeYN.AutoSize = True
        Me.cbMergeYN.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.cbMergeYN.Location = New System.Drawing.Point(149, 40)
        Me.cbMergeYN.Name = "cbMergeYN"
        Me.cbMergeYN.Size = New System.Drawing.Size(194, 17)
        Me.cbMergeYN.TabIndex = 3
        Me.cbMergeYN.Text = "백업된 기존 고객정보와 취합"
        Me.cbMergeYN.UseVisualStyleBackColor = True
        '
        'btnResult
        '
        Me.btnResult.Location = New System.Drawing.Point(494, 20)
        Me.btnResult.Name = "btnResult"
        Me.btnResult.Size = New System.Drawing.Size(96, 35)
        Me.btnResult.TabIndex = 2
        Me.btnResult.Text = "결과보기"
        Me.btnResult.UseVisualStyleBackColor = True
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox4.Location = New System.Drawing.Point(144, 20)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(412, 35)
        Me.TextBox4.TabIndex = 1
        Me.TextBox4.Text = "고객정보 불러오기를 위해 엑셀파일을 업로드합니다."
        '
        'btnUpload
        '
        Me.btnUpload.Location = New System.Drawing.Point(15, 20)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(96, 35)
        Me.btnUpload.TabIndex = 0
        Me.btnUpload.Text = "엑셀 업로드"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'gbRecovery
        '
        Me.gbRecovery.Controls.Add(Me.TextBox5)
        Me.gbRecovery.Controls.Add(Me.btnRecovery)
        Me.gbRecovery.Location = New System.Drawing.Point(53, 292)
        Me.gbRecovery.Name = "gbRecovery"
        Me.gbRecovery.Size = New System.Drawing.Size(596, 64)
        Me.gbRecovery.TabIndex = 4
        Me.gbRecovery.TabStop = False
        Me.gbRecovery.Text = "고객정보 복구"
        '
        'TextBox5
        '
        Me.TextBox5.BackColor = System.Drawing.SystemColors.Control
        Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextBox5.Location = New System.Drawing.Point(144, 20)
        Me.TextBox5.Multiline = True
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(412, 35)
        Me.TextBox5.TabIndex = 1
        Me.TextBox5.Text = "작업이 취소되고 기존 백업된 고객정보가 복구됩니다."
        '
        'btnRecovery
        '
        Me.btnRecovery.Location = New System.Drawing.Point(15, 20)
        Me.btnRecovery.Name = "btnRecovery"
        Me.btnRecovery.Size = New System.Drawing.Size(96, 35)
        Me.btnRecovery.TabIndex = 0
        Me.btnRecovery.Text = "복구"
        Me.btnRecovery.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.stLabel1, Me.stLabel2, Me.stLabel3})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 432)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(702, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'stLabel1
        '
        Me.stLabel1.Name = "stLabel1"
        Me.stLabel1.Size = New System.Drawing.Size(72, 17)
        Me.stLabel1.Text = "DB server IP"
        '
        'stLabel2
        '
        Me.stLabel2.Name = "stLabel2"
        Me.stLabel2.Size = New System.Drawing.Size(44, 17)
        Me.stLabel2.Text = "User id"
        '
        'stLabel3
        '
        Me.stLabel3.Name = "stLabel3"
        Me.stLabel3.Size = New System.Drawing.Size(64, 17)
        Me.stLabel3.Text = "User name"
        '
        'AquaSkin2
        '
        Me.AquaSkin2.AquaStyle = SkinSoft.AquaSkin.AquaStyle.Panther
        Me.AquaSkin2.License = CType(resources.GetObject("AquaSkin2.License"), SkinSoft.AquaSkin.Licensing.AquaSkinLicense)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.SupportMultiDottedExtensions = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCompany)
        Me.GroupBox1.Location = New System.Drawing.Point(55, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(245, 50)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "고객회사 정보"
        '
        'lblCompany
        '
        Me.lblCompany.Location = New System.Drawing.Point(14, 21)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(195, 20)
        Me.lblCompany.TabIndex = 0
        Me.lblCompany.Text = "Label1"
        '
        'TimerUpload
        '
        Me.TimerUpload.Interval = 1000
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(461, 371)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'MainFrmCDB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 454)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbRecovery)
        Me.Controls.Add(Me.gbUpload)
        Me.Controls.Add(Me.gbDelete)
        Me.Controls.Add(Me.gbBackup)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainFrmCDB"
        Me.Text = "고객정보 작업관리"
        Me.gbBackup.ResumeLayout(False)
        Me.gbBackup.PerformLayout()
        Me.gbDelete.ResumeLayout(False)
        Me.gbDelete.PerformLayout()
        Me.gbUpload.ResumeLayout(False)
        Me.gbUpload.PerformLayout()
        Me.gbRecovery.ResumeLayout(False)
        Me.gbRecovery.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.AquaSkin2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbBackup As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnBackup As System.Windows.Forms.Button
    Friend WithEvents gbDelete As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents gbUpload As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnUpload As System.Windows.Forms.Button
    Friend WithEvents gbRecovery As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents btnRecovery As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents stLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents stLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Private WithEvents AquaSkin2 As SkinSoft.AquaSkin.AquaSkin
    Friend WithEvents stLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents btnResult As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCompany As System.Windows.Forms.Label
    Friend WithEvents cbMergeYN As System.Windows.Forms.CheckBox
    Friend WithEvents TimerUpload As System.Windows.Forms.Timer
    Friend WithEvents BackgroundWorkerMain As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
