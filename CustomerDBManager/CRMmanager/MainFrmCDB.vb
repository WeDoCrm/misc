Imports MySql.Data
Imports MySql.Data.MySqlClient

Public Class MainFrmCDB
    Private ss As New CDBMmanager

    '    작업상태
    '1. 초기 INIT
    '2. 백업 BACKED_UP  
    '3. 삭제 DELETED
    '4. 업로드 UPLOADED
    '5. 승인  CONFIRMED
    '6. 복구 RECOVERED = INIT
    Enum TASKMODE
        INIT = 0
        BACKED_UP = 1
        DELETED = 2
        UPLOADED = 3
        CONFIRMED = 4
        RECOVERED = 5
    End Enum

    Enum TABLEMODE
        T_CUSTOMER_EXCEL_BACKUP = 0
        T_CUSTOMER_TELNO_EXCEL_BACKUP = 1
        T_CUSTOMER_HISTORY_EXCEL_BACKUP = 2

        T_CUSTOMER_EXCEL_TMP = 3
    End Enum

    Public Enum UPLOADRESULT
        SUCCESS = 0
        NO_HP_NO_PHONE = 1
        PHONE_IS_HP = 2
        HP_NO_HP = 3
        NO_CUSTOMER_NAME = 4
    End Enum


    Dim MsgNoHPNoPhone As String = "전화번호/휴대폰 모두 없음"  'upload_result = '1'
    Dim MsgPhoneIsHP As String = "전화가 휴대폰 형식"  'upload_result = '2'
    Dim MsgHPNoHP As String = "휴대폰이 휴대폰 형식아님"  'upload_result = '3'  '정상 upload_result = '0'
    Dim MsgNoCustomerName As String = "고객명 없음"

    Dim mTaskMode As TASKMODE = TASKMODE.INIT
    Dim mCntTotal As Integer = 0
    Dim mCnt As Integer = 0
    Dim mCntDup As Integer = 0
    Dim mCntWrongPhoneFormat As Integer = 0
    Dim mCntError As Integer = 0

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        Elegant.Ui.RibbonLicenser.LicenseKey = "E644-DB48-BFFB-CA0C-53D2-4F3F-C938-C3EF"

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        switchTask()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub MainFrmCDB_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If mTaskMode = TASKMODE.DELETED Then
            If MsgBoxResult.Ok = MsgBox("고객데이터가 삭제된 상태입니다." & vbNewLine & _
                                        "복구하거나 고객정보를 업로드완료후 종료하세요.", MsgBoxStyle.OkOnly, "데이터 삭제 경고") Then
                e.Cancel = True
            End If
        End If


        If mTaskMode = TASKMODE.UPLOADED Then
            If MsgBoxResult.Ok = MsgBox("고객데이터가 삭제된 후 업로드가 완료되지 않았습니다." & vbNewLine & _
                                        "복구하거나 고객정보를 업로드완료후 종료하세요.", MsgBoxStyle.OkOnly, "데이터 삭제 경고") Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub MainFrmCDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call ss.SetUserInfo("9997", "admin", "admin", "", "", False)
        lblCompany.Text = gsCompany & "( " & gsCOM_CD & " )"

        stLabel1.Text = "DB server IP : " & XmlRead(1, "db")
        stLabel2.Text = gsUSER_ID
        stLabel3.Text = gsUSER_NM
    End Sub

    Sub switchTask()
        Select Case mTaskMode
            Case TASKMODE.INIT
                gbBackup.Enabled = True
                gbDelete.Enabled = False
                gbUpload.Enabled = False
                gbRecovery.Enabled = False
            Case TASKMODE.BACKED_UP
                gbBackup.Enabled = True
                gbDelete.Enabled = True
                gbUpload.Enabled = False
                gbRecovery.Enabled = False
            Case TASKMODE.DELETED
                gbBackup.Enabled = True
                gbDelete.Enabled = True
                gbUpload.Enabled = True
                gbRecovery.Enabled = False
            Case TASKMODE.UPLOADED
                gbBackup.Enabled = True
                gbDelete.Enabled = True
                gbUpload.Enabled = True
                gbRecovery.Enabled = True
            Case TASKMODE.RECOVERED
                gbBackup.Enabled = True
                gbDelete.Enabled = False
                gbUpload.Enabled = False
                gbRecovery.Enabled = False
        End Select
    End Sub


    Function doBackup() As Boolean
        Dim Sql As String = ""
        If Not doExistTable(TABLEMODE.T_CUSTOMER_EXCEL_BACKUP) Then
            If Not doCommandSql(sqlCreateCustomerExcelBackup) Then
                Return False
            End If
        End If
        Sql = "truncate table t_customer_excel_backup"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "alter table t_customer_excel_backup disable keys"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer_excel_backup select * from t_customer"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "alter table t_customer_excel_backup enable keys"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        If Not doExistTable(TABLEMODE.T_CUSTOMER_EXCEL_TMP) Then
            If Not doCommandSql(sqlCreateCustomerExcelTmp) Then
                Return False
            End If
        Else '테이블있지만, upload_result가 없는 경우 신규로 삭제/생성해줌.
            If Not doExistTable(TABLEMODE.T_CUSTOMER_EXCEL_TMP, "upload_result") Then
                Sql = "drop table t_customer_excel_tmp"
                If Not doCommandSql(Sql) Then
                    Return False
                End If
                If Not doCommandSql(sqlCreateCustomerExcelTmp) Then
                    Return False
                End If
            End If
        End If

        Sql = "truncate table t_customer_excel_tmp"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        If Not doExistTable(TABLEMODE.T_CUSTOMER_HISTORY_EXCEL_BACKUP) Then
            If Not doCommandSql(sqlCreateCustomerHistoryExcelBackup) Then
                Return False
            End If
        End If
        Sql = "truncate table t_customer_history_excel_backup"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer_history_excel_backup select * from t_customer_history"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        If Not doExistTable(TABLEMODE.T_CUSTOMER_TELNO_EXCEL_BACKUP) Then
            If Not doCommandSql(sqlCustomerTelnoExcelBackup) Then
                Return False
            End If
        End If
        Sql = "truncate table t_customer_telno_excel_backup"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer_telno_excel_backup select * from t_customer_telno"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        Return True
    End Function

    Function doDelete() As Boolean
        Dim Sql As String = ""
        Sql = "truncate table t_customer"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Return True
    End Function

    Function doUpload() As Boolean
        Try
            mCnt = 0
            mCntDup = 0
            mCntWrongPhoneFormat = 0
            mCntError = 0

            Dim msgMerge As String
            If cbMergeYN.Checked Then
                msgMerge = "**백업된 기존 고객정보와 취합됩니다.(신규만 등록하는 경우 취합 체크해제) "
            Else
                msgMerge = "**고객정보가 엑셀업로드된 정보로 교체됩니다.(기존 정보와 취합하는 경우 취합 체크선택) "
            End If
            Dim Sql As String = "truncate table t_customer_excel_tmp"
            If Not doCommandSql(Sql) Then
                Return False
            End If
            With OpenFileDialog1
                .CheckFileExists = True
                .CheckPathExists = True
                .Filter = "Excel통합문서(*.xlsx)|*.xlsx|Excel97-2003문서(*.xls)|*.xls"
                .FileName = "고객정보(등록용)"
                .Title = "고객정보 가져오기"
                .Multiselect = False
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Try
                        Call Excells_Import(OpenFileDialog1.FileName)
                    Catch ex As Exception
                        WriteLog(ex.ToString)
                    End Try


                    If mCnt > 0 Then
                        If mCntDup > 0 Then '처리건 & 중복건 있음
                            If MsgBoxResult.Yes = MsgBox(" 정상 " & mCnt & "건" & vbNewLine & _
                                                         " 중복 " & mCntDup & "건" & vbNewLine & _
                                                         " 오류 " & mCntWrongPhoneFormat & "건(전화번호형식오류)" & vbNewLine & _
                                                         " 오류 " & mCntError & "건(기타오류)" & vbNewLine & _
                                                         " 기존 고객정보와 중복건이 있습니다. 결과를 확인하시겠습니까? ", MsgBoxStyle.YesNo, "정보") Then
                                doShowResult()
                            End If

                            If MsgBoxResult.Yes = MsgBox("처리를 계속 진행하시겠습니까? " & vbNewLine _
                                                         & "계속 진행하면 기존중복건은 덮어쓰기가 됩니다." & vbNewLine _
                                                         & msgMerge, MsgBoxStyle.YesNo, "정보") Then

                                If Not txUpdateCustomer() Then
                                    MsgBox("처리가 비정상종료 되었습니다.", MsgBoxStyle.OkOnly, "정보")
                                    Return False
                                End If
                                '처리후 맵핑된 번호도 업데이트 정리
                                Call txUpdateCustomerTelNo()
                            Else '작업취소
                                MsgBox("처리가 취소되었습니다.", MsgBoxStyle.OkOnly, "정보")
                                Return True
                            End If

                            '중복건 포함 정상건 처리
                            MsgBox(" 정상 " & mCnt & "건" & vbNewLine & _
                                 " 중복 " & mCntDup & "건" & vbNewLine & _
                                 " 처리가 완료되었습니다.", MsgBoxStyle.OkOnly, "정보")

                            '추가로 상담이력 업데이트
                            If MsgBoxResult.Yes = MsgBox("중복된 고객의 상담이력을 신규 고객정보로 갱신하시겠습니까?", MsgBoxStyle.YesNo, "정보") Then
                                Dim nCntTx As Integer = 0
                                If txUpdateCustomerHistory() Then
                                    MsgBox(" 상담이력정보가 갱신되었습니다.", MsgBoxStyle.OkOnly, "정보")
                                Else
                                    MsgBox("이력 갱신처리가 비정상종료 되었습니다.", MsgBoxStyle.OkOnly, "정보")
                                    Return False
                                End If
                            Else
                                MsgBox("상담이력의 갱신처리가 취소되었습니다." & vbNewLine & _
                                       " 처리가 완료되었습니다.", MsgBoxStyle.OkOnly, "정보")
                            End If
                        Else ' If mCntDup > 0 Then
                            If MsgBoxResult.Yes = MsgBox(" 정상 " & mCnt & "건" & vbNewLine & _
                                     "결과를 확인하시겠습니까? ", MsgBoxStyle.YesNo, "정보") Then
                                doShowResult()
                            End If

                            If MsgBoxResult.Yes = MsgBox("처리를 완료하시겠습니까?" & vbNewLine _
                                                         & msgMerge, MsgBoxStyle.YesNo, "정보") Then

                                If Not txUpdateCustomer() Then
                                    MsgBox("처리가 비정상종료 되었습니다.", MsgBoxStyle.OkOnly, "정보")
                                    Return False
                                End If
                                Call txUpdateCustomerTelNo()
                                MsgBox(mCnt & "건이 처리되었습니다.", MsgBoxStyle.OkOnly, "정보")
                            Else
                                MsgBox("처리가 취소되었습니다.", MsgBoxStyle.OkOnly, "정보")
                            End If
                        End If ' If mCntDup > 0 Then
                    Else 'If mCnt > 0 Then
                        '여기선 0건으로 보임
                        MsgBox(mCnt & "건이 처리되었습니다.", MsgBoxStyle.OkOnly, "정보")
                    End If
                End If
            End With



        Catch ex As Exception
            WriteLog(ex.ToString)
            Return False
        End Try
        Return True
    End Function


    Function doRecover() As Boolean
        Dim Sql As String = "truncate table t_customer"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "alter table t_customer disable keys"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer select * from t_customer_excel_backup "
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "alter table t_customer enable keys"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        Sql = "truncate table t_customer_telno"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer_telno select * from t_customer_telno_excel_backup "
        If Not doCommandSql(Sql) Then
            Return False
        End If

        Sql = "truncate table t_customer_history"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer_history select * from t_customer_history_excel_backup "
        If Not doCommandSql(Sql) Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        If mTaskMode = TASKMODE.BACKED_UP Or mTaskMode = TASKMODE.DELETED Or mTaskMode = TASKMODE.UPLOADED Then
            MsgBox("고객정보가 이미 백업되어었습니다." & vbCrLf & "초기나 업로드 최종완료후 또는 복구후에만 백업할수 있습니다.", MsgBoxStyle.OkOnly, "알림")
            Exit Sub
        End If
        If doBackup() Then
            MsgBox("고객정보가 백업되었습니다.", MsgBoxStyle.OkOnly, "알림")
            mTaskMode = TASKMODE.BACKED_UP
            Call switchTask()
        Else
            MsgBox("고객정보 백업에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
            'Else
            '    mTaskMode = TASKMODE.INIT
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If doDelete() Then
            MsgBox("고객정보가 삭제되었습니다.", MsgBoxStyle.OkOnly, "알림")
            mTaskMode = TASKMODE.DELETED
            Call switchTask()
        Else
            MsgBox("고객정보 삭제에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
            '    mTaskMode = TASKMODE.INIT
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If doUpload() Then
            mTaskMode = TASKMODE.UPLOADED
            Call switchTask()
            'Else
            '    mTaskMode = TASKMODE.INIT
        End If

    End Sub

    Private Sub btnRecovery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecovery.Click
        If doRecover() Then
            mTaskMode = TASKMODE.INIT
            Call switchTask()
            MsgBox("고객정보가 복구되었습니다.", MsgBoxStyle.OkOnly, "알림")
            'Else
            '    mTaskMode = TASKMODE.INIT
        End If
    End Sub

    Private Sub btnResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResult.Click
        Call doShowResult()
    End Sub

    Private Sub doShowResult()
        Try
            Dim frm As FRM_RESULT = New FRM_RESULT

            frm.setSumCnt(mCntTotal, mCnt, mCntDup, mCntError, mCntWrongPhoneFormat)
            frm.ShowDialog()
            frm.Focus()
        Catch ex As Exception
            Call WriteLog(Me.Name & " : " & ex.ToString)
        End Try
    End Sub

    Function doExistTable(ByVal mode As TABLEMODE) As Boolean
        Return doExistTable(mode, "")
    End Function

    Function doExistTable(ByVal mode As TABLEMODE, ByVal fieldName As String) As Boolean
        Dim tableName As String = ""
        Dim isExist As Boolean = False
        Select Case mode
            Case TABLEMODE.T_CUSTOMER_EXCEL_BACKUP
                tableName = "t_customer_excel_backup"
            Case TABLEMODE.T_CUSTOMER_TELNO_EXCEL_BACKUP
                tableName = "t_customer_telno_excel_backup"
            Case TABLEMODE.T_CUSTOMER_HISTORY_EXCEL_BACKUP
                tableName = "t_customer_history_excel_backup"
            Case TABLEMODE.T_CUSTOMER_EXCEL_TMP
                tableName = "t_customer_excel_tmp"
        End Select

        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim Sql As String = ""
            If fieldName.Trim() = "" Then
                Sql = "select * from information_schema.tables where table_schema = 'wedo_db' and table_name = '" & tableName & "'"
            Else
                Sql = "select * from information_schema.COLUMNS where table_schema = 'wedo_db' and table_name = '" & tableName & "'" & _
                    " and column_name = '" & fieldName & "'"
            End If
            Dim dt1 As DataTable = GetData_table1(gsConString, Sql)

            If dt1.Rows.Count > 0 Then
                isExist = True
            End If

        Catch ex As Exception
            Call WriteLog(Me.Name.ToString & " : " & ex.ToString)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
        Return isExist
    End Function

    Function txUpdateCustomer() As Boolean
        '중복제외한 구 고객정보를 올린다.
        If cbMergeYN.Checked Then
            Dim Sql As String = "truncate table t_customer"
            If Not doCommandSql(Sql) Then
                Return False
            End If
            Sql = "alter table t_customer disable keys"
            If Not doCommandSql(Sql) Then
                Return False
            End If

            If Not doCommandSql(sqlCustomerUpdateOld) Then
                Return False
            End If
            Sql = "alter table t_customer enable keys"
            If Not doCommandSql(Sql) Then
                Return False
            End If
        End If

        '신규 고객정보를 올린다.
        If Not doCommandSql(sqlCustomerUpdateNew) Then
            Return False
        End If

        Return True
    End Function

    Function txUpdateCustomerEx() As Boolean
        Dim objConn As MySqlConnection
        Dim objCmd As MySqlCommand
        Dim Trans As MySqlTransaction

        objConn = New MySqlConnection(gsConString)
        objConn.Open()

        '*** Start Transaction ***'  
        Trans = objConn.BeginTransaction(IsolationLevel.ReadCommitted)

        Try

            '*** Query 1 ***'  
            objCmd = New MySqlCommand()
            With objCmd
                .Connection = objConn
                .Transaction = Trans
                .CommandType = CommandType.Text
                .CommandText = sqlCustomerUpdateOld
            End With
            objCmd.ExecuteNonQuery()

            '*** Query 2 ***'  
            objCmd = New MySqlCommand()
            With objCmd
                .Connection = objConn
                .Transaction = Trans
                .CommandType = CommandType.Text
                .CommandText = sqlCustomerUpdateNew
            End With
            objCmd.ExecuteNonQuery()

            Trans.Commit()  '*** Commit Transaction ***'  

        Catch ex As Exception
            Trans.Rollback() '*** RollBack Transaction ***'  
        Finally
            objCmd = Nothing
            objConn.Close()
            objConn = Nothing
        End Try

    End Function

    Function txUpdateCustomerTelNo() As Boolean
        If Not doCommandSql(sqlUpdateCustomerTelNo) Then
            Return False
        End If
        Return True
    End Function

    Function txUpdateCustomerHistory() As Boolean
        If Not doCommandSql(sqlUpdateCustomerHistory) Then
            Return False
        End If
        Return True
    End Function




    'Private Sub OpenFileDialog1_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
    '    Try
    '        Call Excells_Import(OpenFileDialog1.FileName)
    '    Catch ex As Exception
    '        WriteLog(ex.ToString)
    '    End Try
    'End Sub

    Public Sub Excells_Import(ByVal filepath As String)
        Dim dt As DataTable
        Dim dt2 As New DataTable
        Dim dt1 As DataTable
        Dim Sql As String = ""
        Dim ext As String = ""
        Dim i As Integer = 0
        Dim nExcelCnt As Integer = 0
        Dim nOkCnt As Integer = 0
        Dim nErrCntWrongPhoneFormat As Integer = 0
        Dim nErrCnt As Integer = 0
        Dim defCustLevel As String = "03"
        Dim ExcelResult As UPLOADRESULT = UPLOADRESULT.SUCCESS

        Try
            i = filepath.LastIndexOf(".")
            If i > 0 Then ext = filepath.Substring(i + 1)
            dt = GetDataFromExcel(filepath, ext)
            'WriteLog("excells_Import : " & dt.Rows.Count & " ext:" & ext)
            ''테이블에 insert

            If (giCustomerImportColCount + 3) <> dt.Columns.Count Then
                MsgBox("고객정보를 아래 양식에 맞게 수정하세요." & vbNewLine & vbNewLine _
              & "경로: {프로그램설치경로}\sample\고객정보대장-샘플.xlsx" & vbNewLine & vbNewLine _
              & "필수필드갯수:" & (giCustomerImportColCount + 3) & " 현재파일필드갯수:" & dt.Columns.Count, _
                    MsgBoxStyle.OkOnly, "포맷오류")
                Return
            End If

            mCntTotal = dt.Rows.Count

            For nExcelCnt = 0 To dt.Rows.Count - 1
                'WriteLog("i : " & i & " dt.Rows(i)(0) : " & dt.Rows(i)(0).ToString().Trim & " dt.Rows(i)(1) : " & dt.Rows(i)(1).ToString().Trim & " dt.Rows(i)(2) : " & dt.Rows(i)(2).ToString().Trim & " dt.Rows(i)(3) : " & dt.Rows(i)(3).ToString().Trim)
                '칼럼명인 경우 스킵
                If dt.Rows(nExcelCnt)(0).ToString().Trim = gsCheckCustomerColumnName Then
                    Continue For
                End If
                ExcelResult = UPLOADRESULT.SUCCESS

                If dt.Rows(nExcelCnt)(0).ToString().Trim = "" Then
                    nErrCnt += 1

                    ExcelResult = UPLOADRESULT.NO_CUSTOMER_NAME
                    WriteLog("i : " & nExcelCnt & _
                             "[" & dt.Rows(nExcelCnt)(0).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(1).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(2).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(3).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(4).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(5).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(6).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(7).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(8).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(9).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(10).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(11).ToString().Trim & "]" & _
                             MsgNoCustomerName)
                    'Continue For
                End If


                If (dt.Rows(nExcelCnt)(4).ToString().Trim() = "" _
                    And dt.Rows(nExcelCnt)(5).ToString().Trim() = "") Then
                    nErrCntWrongPhoneFormat += 1

                    ExcelResult = UPLOADRESULT.NO_HP_NO_PHONE
                    WriteLog("i:" & nExcelCnt & _
                             "[" & dt.Rows(nExcelCnt)(0).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(1).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(2).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(3).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(4).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(5).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(6).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(7).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(8).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(9).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(10).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(11).ToString().Trim & "]" & _
                             MsgNoHPNoPhone)
                    'Continue For
                End If

                If (dt.Rows(nExcelCnt)(4).ToString().Trim() <> "" _
                    And IsHPNumber(dt.Rows(nExcelCnt)(4).ToString())) Then
                    nErrCntWrongPhoneFormat += 1
                    ExcelResult = UPLOADRESULT.PHONE_IS_HP
                    WriteLog("i:" & nExcelCnt & _
                             "[" & dt.Rows(nExcelCnt)(0).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(1).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(2).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(3).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(4).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(5).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(6).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(7).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(8).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(9).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(10).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(11).ToString().Trim & "]" & _
                             MsgPhoneIsHP)
                    'Continue For
                End If
                If (dt.Rows(nExcelCnt)(5).ToString().Trim() <> "" _
                    And Not IsHPNumber(dt.Rows(nExcelCnt)(5).ToString())) Then
                    nErrCntWrongPhoneFormat += 1

                    ExcelResult = UPLOADRESULT.HP_NO_HP
                    WriteLog("i:" & nExcelCnt & _
                             "[" & dt.Rows(nExcelCnt)(0).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(1).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(2).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(3).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(4).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(5).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(6).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(7).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(8).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(9).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(10).ToString().Trim & "]" & _
                             "[" & dt.Rows(nExcelCnt)(11).ToString().Trim & "]" & _
                             MsgHPNoHP)
                    'Continue For
                End If
                If dt.Rows(nExcelCnt)(8).ToString().Trim = "" Then
                    defCustLevel = "03"
                Else
                    defCustLevel = dt.Rows(nExcelCnt)(8).ToString().Trim
                End If
                Sql = "INSERT INTO T_CUSTOMER_EXCEL_TMP(COM_CD,CUSTOMER_NM, " & _
                            "COMPANY,DEPARTMENT,JOB_TITLE, " & _
                            "C_TELNO,H_TELNO,FAX_NO,EMAIL,CUSTOMER_TYPE,WOO_NO, " & _
                            "CUSTOMER_ADDR,CUSTOMER_ETC,C_TELNO1,H_TELNO1,UPLOAD_RESULT) " & _
                            " Values('" & _
                            gsCOM_CD & "','" & _
                            dt.Rows(nExcelCnt)(0).ToString().Trim & "','" & _
                            dt.Rows(nExcelCnt)(1).ToString().Trim & "','" & _
                            dt.Rows(nExcelCnt)(2).ToString().Trim & "','" & _
                            dt.Rows(nExcelCnt)(3).ToString().Trim & "','" & _
                            dt.Rows(nExcelCnt)(4).ToString().Replace("-", "").Replace(" ", "").Trim & "','" & _
                            dt.Rows(nExcelCnt)(5).ToString().Replace("-", "").Replace(" ", "").Trim & "','" & _
                            dt.Rows(nExcelCnt)(6).ToString().Replace("-", "").Replace(" ", "").Trim & "','" & _
                            dt.Rows(nExcelCnt)(7).ToString().Trim & "','" & _
                            defCustLevel & "','" & _
                            dt.Rows(nExcelCnt)(9).ToString().Replace("-", "").Replace(" ", "").Trim & "','" & _
                            dt.Rows(nExcelCnt)(10).ToString().Trim & "','" & _
                            dt.Rows(nExcelCnt)(11).ToString().Trim & "','" & _
                            dt.Rows(nExcelCnt)(4).ToString().Replace("-", "").Replace(" ", "").Trim & "','" & _
                            dt.Rows(nExcelCnt)(5).ToString().Replace("-", "").Replace(" ", "").Trim & "','" & _
                            ExcelResult & "')"
                'WriteLog(temp)
                dt2 = Mysql_GetData_table(gsConString, Sql)
                If dt2 Is Nothing Then
                    nErrCnt += 1
                Else
                    nOkCnt += 1
                End If
                dt2.Reset()
            Next

            Sql = "select distinct a.customer_id new_customer_id " & _
                      " from t_customer_excel_tmp a,  " & _
                      "      t_customer_excel_backup b " & _
                      " where a.customer_nm = b.customer_nm " & _
                      " and a.com_cd = b.com_cd " & _
                      " and ((a.c_telno = b.c_telno and a.c_telno > '') " & _
                      "		or (a.h_telno = b.h_telno and a.h_TELNO > '')) "
            dt1 = GetData_table1(gsConString, Sql)


            mCntDup = dt1.Rows.Count
            mCnt = nOkCnt
            mCntWrongPhoneFormat = nErrCntWrongPhoneFormat
            mCntError = nErrCnt

            WriteLog("*** Target Count : " & dt.Rows.Count & " => Insert Count : OK[" & nOkCnt & "] DUP[" & dt1.Rows.Count & "] " & "Format Error[" & nErrCntWrongPhoneFormat & "]" & "Etc Error[" & nErrCnt & "]")
        Catch ex As Exception
            WriteLog(ex.ToString)
        Finally
            dt = Nothing
            dt1 = Nothing
            dt2 = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If nOkCnt > 0 Then Call Audit_Log(AUDIT_TYPE.CUSTOMER_IMPORT, "Customer Import:" & CStr(nOkCnt))
        End Try
    End Sub
End Class