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
        SQL = SQL & " 			else '정상'end RESULT_CODE, CUSTOMER_NM,COMPANY, DEPARTMENT, JOB_TITLE"
        SQL = SQL & " 			,C_TELNO,H_TELNO "
        SQL = SQL & " 		    ,(select  max(a.customer_id) "
        SQL = SQL & " 			    from t_customer_excel_backup a "
        SQL = SQL & " 			   where a.customer_nm = b.customer_nm "
        SQL = SQL & " 			     and a.com_cd = b.com_cd "
        SQL = SQL & " 				 and ((a.c_telno = b.c_telno and a.c_telno > '') "
        SQL = SQL & " 		   		  or (a.h_telno = b.h_telno and a.h_TELNO > '')) "
        SQL = SQL & " 			) DUP_ID, FAX_NO, EMAIL, CUSTOMER_TYPE "
        SQL = SQL & " 			, WOO_NO,CUSTOMER_ADDR,CUSTOMER_ETC "
        SQL = SQL & " from t_customer_excel_tmp b "
        Return SQL
    End Function




    Public Sub gsSelect()
        Dim dt1 As DataTable
        Try

            Dim SQL As String = genQuery()

            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            '************************************ 체크하자
            dt1 = GetData_table1(gsConString & ";default command timeout=3600;", SQL)

            DataGridView2.DataSource = dt1


        Catch ex As Exception
            Call WriteLog("FRM_CUSTOMER : " & ex.ToString)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            result = 1
            dt1 = Nothing
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