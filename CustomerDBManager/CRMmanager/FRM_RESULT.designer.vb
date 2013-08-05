<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_RESULT
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
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

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기를 사용하여 수정하지 마십시오.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_RESULT))
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.lblCnt = New System.Windows.Forms.Label
        Me.lblDupCnt = New System.Windows.Forms.Label
        Me.lblErrCnt = New System.Windows.Forms.Label
        Me.lblErrFormatCnt = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.RESULT_CODE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUSTOMER_NM = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.COMPANY = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DEPARTMENT = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.JOB_TITLE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.C_TELNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.H_TELNO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DUP_ID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FAX_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.EMAIL = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUSTOMER_TYPE = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.WOO_NO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUSTOMER_ADDR = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CUSTOMER_ETC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AquaSkin2 = New SkinSoft.AquaSkin.AquaSkin(Me.components)
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AquaSkin2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView2.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RESULT_CODE, Me.CUSTOMER_NM, Me.COMPANY, Me.DEPARTMENT, Me.JOB_TITLE, Me.C_TELNO, Me.H_TELNO, Me.DUP_ID, Me.FAX_NO, Me.EMAIL, Me.CUSTOMER_TYPE, Me.WOO_NO, Me.CUSTOMER_ADDR, Me.CUSTOMER_ETC})
        Me.DataGridView2.GridColor = System.Drawing.SystemColors.ActiveCaption
        Me.DataGridView2.Location = New System.Drawing.Point(12, 91)
        Me.DataGridView2.MultiSelect = False
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("굴림", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView2.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(872, 573)
        Me.DataGridView2.TabIndex = 80
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.FileName = "c"
        '
        'lblCnt
        '
        Me.lblCnt.AutoSize = True
        Me.lblCnt.Location = New System.Drawing.Point(41, 20)
        Me.lblCnt.Name = "lblCnt"
        Me.lblCnt.Size = New System.Drawing.Size(57, 12)
        Me.lblCnt.TabIndex = 81
        Me.lblCnt.Text = "정상 00건"
        '
        'lblDupCnt
        '
        Me.lblDupCnt.AutoSize = True
        Me.lblDupCnt.Location = New System.Drawing.Point(41, 37)
        Me.lblDupCnt.Name = "lblDupCnt"
        Me.lblDupCnt.Size = New System.Drawing.Size(57, 12)
        Me.lblDupCnt.TabIndex = 82
        Me.lblDupCnt.Text = "중복 00건"
        '
        'lblErrCnt
        '
        Me.lblErrCnt.AutoSize = True
        Me.lblErrCnt.Location = New System.Drawing.Point(41, 54)
        Me.lblErrCnt.Name = "lblErrCnt"
        Me.lblErrCnt.Size = New System.Drawing.Size(57, 12)
        Me.lblErrCnt.TabIndex = 83
        Me.lblErrCnt.Text = "오류 00건"
        '
        'lblErrFormatCnt
        '
        Me.lblErrFormatCnt.AutoSize = True
        Me.lblErrFormatCnt.Location = New System.Drawing.Point(16, 71)
        Me.lblErrFormatCnt.Name = "lblErrFormatCnt"
        Me.lblErrFormatCnt.Size = New System.Drawing.Size(81, 12)
        Me.lblErrFormatCnt.TabIndex = 84
        Me.lblErrFormatCnt.Text = "포맷오류 00건"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(103, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(561, 12)
        Me.Label1.TabIndex = 85
        Me.Label1.Text = ": 적색글씨.  기존 등록 고객중 고객명과 전화 또는 고객명과 휴대폰정보가 동일한 고객정보가 있는 경우"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(103, 54)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(439, 12)
        Me.Label2.TabIndex = 86
        Me.Label2.Text = ": 고객등록중 등록정보 오류로 등록실패인 경우(예: 고객명 없음). 목록에는 없음."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(103, 71)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(489, 12)
        Me.Label3.TabIndex = 87
        Me.Label3.Text = ": 적색바탕. 고객등록중 전화 또는 휴대폰 번호오류(두 번호 모두 없음/잘못된 휴대폰번호)"
        '
        'RESULT_CODE
        '
        Me.RESULT_CODE.DataPropertyName = "RESULT_CODE"
        Me.RESULT_CODE.HeaderText = "업로드결과"
        Me.RESULT_CODE.Name = "RESULT_CODE"
        Me.RESULT_CODE.ReadOnly = True
        Me.RESULT_CODE.Width = 150
        '
        'CUSTOMER_NM
        '
        Me.CUSTOMER_NM.DataPropertyName = "CUSTOMER_NM"
        Me.CUSTOMER_NM.HeaderText = "고객명"
        Me.CUSTOMER_NM.Name = "CUSTOMER_NM"
        Me.CUSTOMER_NM.ReadOnly = True
        '
        'COMPANY
        '
        Me.COMPANY.DataPropertyName = "COMPANY"
        Me.COMPANY.HeaderText = "회사"
        Me.COMPANY.Name = "COMPANY"
        Me.COMPANY.ReadOnly = True
        Me.COMPANY.Width = 80
        '
        'DEPARTMENT
        '
        Me.DEPARTMENT.DataPropertyName = "DEPARTMENT"
        Me.DEPARTMENT.HeaderText = "소속"
        Me.DEPARTMENT.Name = "DEPARTMENT"
        Me.DEPARTMENT.ReadOnly = True
        Me.DEPARTMENT.Width = 80
        '
        'JOB_TITLE
        '
        Me.JOB_TITLE.DataPropertyName = "JOB_TITLE"
        Me.JOB_TITLE.FillWeight = 80.0!
        Me.JOB_TITLE.HeaderText = "직급"
        Me.JOB_TITLE.Name = "JOB_TITLE"
        Me.JOB_TITLE.ReadOnly = True
        '
        'C_TELNO
        '
        Me.C_TELNO.DataPropertyName = "C_TELNO"
        Me.C_TELNO.FillWeight = 80.0!
        Me.C_TELNO.HeaderText = "전화번호"
        Me.C_TELNO.Name = "C_TELNO"
        Me.C_TELNO.ReadOnly = True
        '
        'H_TELNO
        '
        Me.H_TELNO.DataPropertyName = "H_TELNO"
        Me.H_TELNO.FillWeight = 80.0!
        Me.H_TELNO.HeaderText = "핸드폰"
        Me.H_TELNO.Name = "H_TELNO"
        Me.H_TELNO.ReadOnly = True
        '
        'DUP_ID
        '
        Me.DUP_ID.DataPropertyName = "DUP_ID"
        Me.DUP_ID.FillWeight = 120.0!
        Me.DUP_ID.HeaderText = "기존고객ID"
        Me.DUP_ID.Name = "DUP_ID"
        Me.DUP_ID.ReadOnly = True
        '
        'FAX_NO
        '
        Me.FAX_NO.DataPropertyName = "FAX_NO"
        Me.FAX_NO.HeaderText = "팩스"
        Me.FAX_NO.Name = "FAX_NO"
        Me.FAX_NO.ReadOnly = True
        '
        'EMAIL
        '
        Me.EMAIL.DataPropertyName = "EMAIL"
        Me.EMAIL.FillWeight = 120.0!
        Me.EMAIL.HeaderText = "이메일"
        Me.EMAIL.Name = "EMAIL"
        Me.EMAIL.ReadOnly = True
        '
        'CUSTOMER_TYPE
        '
        Me.CUSTOMER_TYPE.DataPropertyName = "CUSTOMER_TYPE"
        Me.CUSTOMER_TYPE.FillWeight = 120.0!
        Me.CUSTOMER_TYPE.HeaderText = "고객유형"
        Me.CUSTOMER_TYPE.Name = "CUSTOMER_TYPE"
        Me.CUSTOMER_TYPE.ReadOnly = True
        '
        'WOO_NO
        '
        Me.WOO_NO.DataPropertyName = "WOO_NO"
        Me.WOO_NO.HeaderText = "우편번호"
        Me.WOO_NO.Name = "WOO_NO"
        Me.WOO_NO.ReadOnly = True
        Me.WOO_NO.Width = 120
        '
        'CUSTOMER_ADDR
        '
        Me.CUSTOMER_ADDR.DataPropertyName = "CUSTOMER_ADDR"
        Me.CUSTOMER_ADDR.HeaderText = "고객주소"
        Me.CUSTOMER_ADDR.Name = "CUSTOMER_ADDR"
        Me.CUSTOMER_ADDR.ReadOnly = True
        Me.CUSTOMER_ADDR.Width = 120
        '
        'CUSTOMER_ETC
        '
        Me.CUSTOMER_ETC.DataPropertyName = "CUSTOMER_ETC"
        Me.CUSTOMER_ETC.HeaderText = "비고"
        Me.CUSTOMER_ETC.Name = "CUSTOMER_ETC"
        Me.CUSTOMER_ETC.ReadOnly = True
        Me.CUSTOMER_ETC.Width = 120
        '
        'AquaSkin2
        '
        Me.AquaSkin2.AquaStyle = SkinSoft.AquaSkin.AquaStyle.Panther
        Me.AquaSkin2.License = CType(resources.GetObject("AquaSkin2.License"), SkinSoft.AquaSkin.Licensing.AquaSkinLicense)
        '
        'FRM_RESULT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 676)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblErrFormatCnt)
        Me.Controls.Add(Me.lblErrCnt)
        Me.Controls.Add(Me.lblDupCnt)
        Me.Controls.Add(Me.lblCnt)
        Me.Controls.Add(Me.DataGridView2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FRM_RESULT"
        Me.Text = "업로드 결과보기"
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AquaSkin2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents lblCnt As System.Windows.Forms.Label
    Friend WithEvents lblDupCnt As System.Windows.Forms.Label
    Friend WithEvents lblErrCnt As System.Windows.Forms.Label
    Friend WithEvents lblErrFormatCnt As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents RESULT_CODE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMER_NM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COMPANY As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DEPARTMENT As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents JOB_TITLE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents C_TELNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents H_TELNO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DUP_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FAX_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EMAIL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMER_TYPE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WOO_NO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMER_ADDR As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CUSTOMER_ETC As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents AquaSkin2 As SkinSoft.AquaSkin.AquaSkin
End Class
