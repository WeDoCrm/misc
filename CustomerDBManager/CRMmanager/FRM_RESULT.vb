Option Strict On
Option Explicit On

Public Class FRM_RESULT
    Private ss As New CDBMmanager
    Private result As Integer = 0

    Public Sub setSumCnt(ByVal nCntTotal As Integer, ByVal nCnt As Integer, ByVal nDup As Integer, ByVal nErr As Integer, ByVal nErrFormat As Integer)
        lblCnt.Text = "정상" & nCnt & "건"
        lblDupCnt.Text = "중복" & nDup & "건"
        lblErrCnt.Text = "오류" & nErr & "건"
        lblErrFormatCnt.Text = "포맷오류" & nErrFormat & "건"

    End Sub

    Public Function genQuery() As String
        '       select CUSTOMER_NM,COMPANY, DEPARTMENT, JOB_TITLE
        '			,C_TELNO,H_TELNO,FAX_NO, EMAIL, CUSTOMER_TYPE
        '			,WOO_NO,CUSTOMER_ADDR,CUSTOMER_ETC
        '		,(select  b.customer_id
        '			  from t_customer_excel_backup a
        '			 where a.customer_nm = b.customer_nm
        '			   and a.com_cd = b.com_cd
        '				 and ((a.c_telno = b.c_telno and a.c_telno > '')
        '						or (a.h_telno = b.h_telno and a.h_TELNO > ''))
        '			) dup_id
        'from t_customer b
        Dim SQL As String = " select case when upload_result = '1' then 'Phone/HP정보없음'"
        SQL = SQL & " 			when upload_result = '2' then 'Phone이 HP포맷'"
        SQL = SQL & " 			when upload_result = '3' then 'HP포맷오류'"
        SQL = SQL & " 			when upload_result = '4' then '고객명없음'"
        SQL = SQL & " 			else '정상'end RESULT, CUSTOMER_NM,COMPANY, DEPARTMENT, JOB_TITLE"
        SQL = SQL & " 			,C_TELNO,H_TELNO "
        SQL = SQL & " 		    ,(select  max(a.customer_id) "
        SQL = SQL & " 			    from t_customer_excel_backup a "
        SQL = SQL & " 			   where a.customer_nm = b.customer_nm "
        SQL = SQL & " 			     and a.com_cd = b.com_cd "
        SQL = SQL & " 				 and ((a.c_telno = b.c_telno and a.c_telno > '') "
        SQL = SQL & " 		   		  or (a.h_telno = b.h_telno and a.h_TELNO > '')) "
        SQL = SQL & " 			) dup_id "
        SQL = SQL & " 			,FAX_NO, EMAIL, CUSTOMER_TYPE "
        SQL = SQL & " 			,WOO_NO,CUSTOMER_ADDR,CUSTOMER_ETC "
        SQL = SQL & " from t_customer_excel_tmp b "
        Return SQL
    End Function

    Public Sub gsSelect()
        Try

            Dim SQL As String = genQuery()

            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '************************************ 체크하자
            Dim dt1 As DataTable = GetData_table1(gsConString, SQL)
            DataGridView2.DataSource = Nothing


            DataGridView2.Columns.Clear()

            DataGridView2.DataSource = dt1
            DataGridView2.Columns.Item(0).HeaderText = "업로드결과"
            DataGridView2.Columns.Item(0).Width = 150

            DataGridView2.Columns.Item(1).HeaderText = "고객명"
            DataGridView2.Columns.Item(1).Width = 100

            DataGridView2.Columns.Item(2).HeaderText = "회사"
            DataGridView2.Columns.Item(2).Width = 80

            DataGridView2.Columns.Item(3).HeaderText = "소속"
            DataGridView2.Columns.Item(3).Width = 80

            DataGridView2.Columns.Item(4).HeaderText = "직급"
            DataGridView2.Columns.Item(4).Width = 80

            DataGridView2.Columns.Item(5).HeaderText = "전화번호"
            DataGridView2.Columns.Item(5).Width = 80

            DataGridView2.Columns.Item(6).HeaderText = "핸드폰"
            DataGridView2.Columns.Item(6).Width = 80

            DataGridView2.Columns.Item(7).HeaderText = "기존고객ID"
            DataGridView2.Columns.Item(7).Width = 120

            DataGridView2.Columns.Item(8).HeaderText = "팩스"
            DataGridView2.Columns.Item(8).Width = 100

            DataGridView2.Columns.Item(9).HeaderText = "이메일"
            DataGridView2.Columns.Item(9).Width = 120

            DataGridView2.Columns.Item(10).HeaderText = "고객유형"
            DataGridView2.Columns.Item(10).Width = 120

            DataGridView2.Columns.Item(11).HeaderText = "우편번호"
            DataGridView2.Columns.Item(11).Width = 120

            DataGridView2.Columns.Item(12).HeaderText = "고객주소"
            DataGridView2.Columns.Item(12).Width = 120

            DataGridView2.Columns.Item(13).HeaderText = "비고"
            DataGridView2.Columns.Item(13).Width = 120

            dt1 = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            Call WriteLog("FRM_CUSTOMER : " & ex.ToString)
        Finally
            result = 1
        End Try
    End Sub

    Public Sub gsFormExit()
        Try
            Me.Close()
        Catch ex As Exception
            Call WriteLog("FRM_CUSTOMER : " & ex.ToString)
        End Try
    End Sub


    Private Sub FRM_CALLER_LIST_Deactivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Deactivate
        Call gsFormExit()
    End Sub


    Private Sub DataGridView2_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView2.CellPainting
        If e.Value IsNot Nothing And e.RowIndex >= 0 Then
            If Me.DataGridView2.Item(7, e.RowIndex).Value.ToString.Trim() <> "" Then
                e.CellStyle.ForeColor = Color.Red
            End If
            If Me.DataGridView2.Item(0, e.RowIndex).Value.ToString.Trim() <> "정상" Then
                e.CellStyle.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub FRM_RESULT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call gsSelect()
    End Sub

    Protected Overrides Sub Finalize()
        DataGridView2.Dispose()
        MyBase.Finalize()
    End Sub
End Class