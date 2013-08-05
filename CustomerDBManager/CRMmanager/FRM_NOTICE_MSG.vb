Public NotInheritable Class FRM_NOTICE_MSG

    Public Sub SetProgress(ByVal index As Integer)
        LabelProgress.Text = "고객정보를 로딩중입니다...(" & index & "건)"
    End Sub

End Class
