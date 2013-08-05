<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_NOTICE_MSG
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
        Me.ProgressBar1 = New Elegant.Ui.ProgressBar
        Me.LabelProgress = New Elegant.Ui.Label
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.DesiredWidth = 222
        Me.ProgressBar1.Id = "cb0d8aef-a4f0-4ee7-98cc-20fd440daa32"
        Me.ProgressBar1.Location = New System.Drawing.Point(65, 46)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(222, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.Text = "ProgressBar1"
        '
        'LabelProgress
        '
        Me.LabelProgress.Location = New System.Drawing.Point(65, 20)
        Me.LabelProgress.Name = "LabelProgress"
        Me.LabelProgress.Size = New System.Drawing.Size(203, 24)
        Me.LabelProgress.TabIndex = 1
        Me.LabelProgress.Text = "고객정보를 로딩중입니다..."
        '
        'FRM_NOTICE_MSG
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(364, 92)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelProgress)
        Me.Controls.Add(Me.ProgressBar1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_NOTICE_MSG"
        Me.Padding = New System.Windows.Forms.Padding(10, 8, 10, 8)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "고객정보 로드작업"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As Elegant.Ui.ProgressBar
    Friend WithEvents LabelProgress As Elegant.Ui.Label

End Class
