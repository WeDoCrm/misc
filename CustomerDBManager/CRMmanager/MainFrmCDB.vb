Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Excel


Public Class MainFrmCDB
    Private ss As New CDBMmanager

    '    작업상태
    '1. 초기 INIT
    '2. 백업 BACKED_UP  
    '3. 삭제 DELETED
    '4. 업로드 UPLOADED
    '5. 승인  CONFIRMED
    '6. 복구 RECOVERED = INIT
    Enum TaskMode
        INIT = 0
        BACKED_UP = 1
        DELETED = 2
        UPLOADED = 3
        CONFIRMED = 4
        RECOVERED = 5
    End Enum

    Enum TableMode
        T_CUSTOMER_EXCEL_BACKUP = 0
        T_CUSTOMER_TELNO_EXCEL_BACKUP = 1
        T_CUSTOMER_HISTORY_EXCEL_BACKUP = 2
        T_CUSTOMER_EXCEL_TMP = 3
        T_CUSTOMER = 4
        T_CUSTOMER_HISTORY = 5
    End Enum

    Public Enum UploadResult
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

    Dim mTaskMode As TaskMode = TaskMode.INIT
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
        'If mTaskMode = TASKMODE.DELETED Then
        '    If MsgBoxResult.Ok = MsgBox("고객데이터가 삭제된 상태입니다." & vbNewLine & _
        '                                "복구하거나 고객정보를 업로드완료후 종료하세요.", MsgBoxStyle.OkOnly, "데이터 삭제 경고") Then
        '        e.Cancel = True
        '    End If
        'End If


        If mTaskMode = TaskMode.DELETED Then
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
            Case TaskMode.INIT
                gbBackup.Enabled = True
                gbDelete.Enabled = False
                gbUpload.Enabled = False
                gbRecovery.Enabled = False
            Case TaskMode.BACKED_UP
                gbBackup.Enabled = True
                gbDelete.Enabled = True
                gbUpload.Enabled = False
                gbRecovery.Enabled = False
            Case TaskMode.DELETED
                gbBackup.Enabled = True
                gbDelete.Enabled = True
                gbUpload.Enabled = True
                gbRecovery.Enabled = True
            Case TaskMode.UPLOADED
                gbBackup.Enabled = True
                gbDelete.Enabled = True
                gbUpload.Enabled = True
                gbRecovery.Enabled = True
            Case TaskMode.RECOVERED
                gbBackup.Enabled = True
                gbDelete.Enabled = False
                gbUpload.Enabled = False
                gbRecovery.Enabled = False
        End Select
    End Sub


    Function doBackup() As Boolean
        Dim Sql As String = ""
        'T_CUSTOMER 버전체크 및 신규필드추가
        '1. TEMP_ID필드 체크 및 추가
        Dim sqlUpdate01 As String = "alter table t_customer add column TEMP_ID varchar(40) DEFAULT NULL"
        If Not doExistTable(TableMode.T_CUSTOMER, "TEMP_ID") Then
            Call doCommandSql(sqlUpdate01)
        End If
        '2. TONG_USER필드 체크 및 추가
        Dim sqlUpdate02 As String = "alter table t_customer add column TONG_USER varchar(45) DEFAULT NULL"
        If Not doExistTable(TableMode.T_CUSTOMER, "TONG_USER") Then
            Call doCommandSql(sqlUpdate02)
        End If
        '3. USER_DEF필드 체크 및 추가
        Dim sqlUpdate03 As String = "alter table t_customer add column USER_DEF varchar(100) DEFAULT NULL"
        If Not doExistTable(TableMode.T_CUSTOMER, "USER_DEF") Then
            Call doCommandSql(sqlUpdate03)
        End If

        'T_CUSTOMER_HISTORY 버전체크 및 신규필드추가

        'T_CUSTOMER_EXCEL_BACKUP 재생성
        If Not doExistTable(TableMode.T_CUSTOMER_EXCEL_BACKUP) Then
            If Not doCommandSql(sqlCreateCustomerExcelBackup) Then
                Return False
            End If
        Else '테이블있지만, temp_id, 가 없는 경우 신규로 삭제/생성해줌.
            If Not doExistTable(TableMode.T_CUSTOMER_EXCEL_BACKUP, "TEMP_ID") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_EXCEL_BACKUP, "TONG_USER") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_EXCEL_BACKUP, "USER_DEF") _
            Then
                If Not doCommandSql(sqlDropCustomerExcelBackup) Then
                    Return False
                End If
                If Not doCommandSql(sqlCreateCustomerExcelBackup) Then
                    Return False
                End If
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
        Sql = "insert into t_customer_excel_backup (" & sqlCustomerFields & ") select " & sqlCustomerFields & " from t_customer"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "alter table t_customer_excel_backup enable keys"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        'T_CUSTOMER_EXCEL_TMP 재생성
        If Not doExistTable(TableMode.T_CUSTOMER_EXCEL_TMP) Then
            If Not doCommandSql(sqlCreateCustomerExcelTmp) Then
                Return False
            End If
        Else '테이블있지만, upload_result 또는 temp_id 가 없는 경우 신규로 삭제/생성해줌.
            If Not doExistTable(TableMode.T_CUSTOMER_EXCEL_TMP, "UPLOAD_RESULT") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_EXCEL_TMP, "TEMP_ID") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_EXCEL_TMP, "TONG_USER") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_EXCEL_TMP, "USER_DEF") _
            Then
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

        'T_CUSTOMER_HISTORY_EXCEL_BACKUP 재생성
        If Not doExistTable(TableMode.T_CUSTOMER_HISTORY_EXCEL_BACKUP) Then
            If Not doCommandSql(sqlCreateCustomerHistoryExcelBackup) Then
                Return False
            End If
        Else '테이블있지만, temp_id가 없는 경우 신규로 삭제/생성해줌.
            If Not doExistTable(TableMode.T_CUSTOMER_HISTORY_EXCEL_BACKUP, "TEMP_ID") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_HISTORY_EXCEL_BACKUP, "TONG_USER") _
                OrElse Not doExistTable(TableMode.T_CUSTOMER_HISTORY_EXCEL_BACKUP, "USER_DEF") _
            Then
                If Not doCommandSql(sqlDropCustomerHistoryExcelBackup) Then
                    Return False
                End If
                If Not doCommandSql(sqlCreateCustomerHistoryExcelBackup) Then
                    Return False
                End If
            End If
        End If
        Sql = "truncate table t_customer_history_excel_backup"
        If Not doCommandSql(Sql) Then
            Return False
        End If
        Sql = "insert into t_customer_history_excel_backup ( " & sqlCustomerHistoryFields & " ) select " & sqlCustomerHistoryFields & " from t_customer_history"
        If Not doCommandSql(Sql) Then
            Return False
        End If

        If Not doExistTable(TableMode.T_CUSTOMER_TELNO_EXCEL_BACKUP) Then
            If Not doCommandSql(sqlCreateCustomerTelnoExcelBackup) Then
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

        Dim resultMsg As String = ""

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
                                Return False
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
                                Return False
                            End If
                        End If ' If mCntDup > 0 Then
                    Else 'If mCnt > 0 Then
                        '여기선 0건으로 보임
                        MsgBox(mCnt & "건이 처리되었습니다." & vbNewLine & "엑셀파일이 열려있는지 확인하세요.", MsgBoxStyle.OkOnly, "정보")
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
        Sql = "insert into t_customer (" & sqlCustomerFields & ") select " & sqlCustomerFields & " from t_customer_excel_backup "
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
        Sql = "insert into t_customer_history ( " & sqlCustomerHistoryFields & " ) select " & sqlCustomerHistoryFields & " from t_customer_history_excel_backup "
        If Not doCommandSql(Sql) Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        If mTaskMode = TaskMode.BACKED_UP Or mTaskMode = TaskMode.DELETED Or mTaskMode = TaskMode.UPLOADED Then
            MsgBox("고객정보가 이미 백업되어었습니다." & vbCrLf & "초기나 업로드 최종완료후 또는 복구후에만 백업할수 있습니다.", MsgBoxStyle.OkOnly, "알림")
            Exit Sub
        End If
        If doBackup() Then
            MsgBox("고객정보가 백업되었습니다.", MsgBoxStyle.OkOnly, "알림")
            mTaskMode = TaskMode.BACKED_UP
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
            mTaskMode = TaskMode.DELETED
            Call switchTask()
        Else
            MsgBox("고객정보 삭제에 실패하였습니다.", MsgBoxStyle.OkOnly, "알림")
            '    mTaskMode = TASKMODE.INIT
        End If
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        If doUpload() Then
            mTaskMode = TaskMode.UPLOADED
            Call switchTask()
            'Else
            '    mTaskMode = TASKMODE.INIT
        End If

    End Sub

    Private Sub btnRecovery_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecovery.Click
        If doRecover() Then
            mTaskMode = TaskMode.INIT
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

    Function doExistTable(ByVal mode As TableMode) As Boolean
        Return doExistTable(mode, "")
    End Function

    Function doExistTable(ByVal mode As TableMode, ByVal fieldName As String) As Boolean
        Dim tableName As String = ""
        Dim isExist As Boolean = False
        Select Case mode
            Case TableMode.T_CUSTOMER_EXCEL_BACKUP
                tableName = "t_customer_excel_backup"
            Case TableMode.T_CUSTOMER_TELNO_EXCEL_BACKUP
                tableName = "t_customer_telno_excel_backup"
            Case TableMode.T_CUSTOMER_HISTORY_EXCEL_BACKUP
                tableName = "t_customer_history_excel_backup"
            Case TableMode.T_CUSTOMER_EXCEL_TMP
                tableName = "t_customer_excel_tmp"
            Case TableMode.T_CUSTOMER
                tableName = "t_customer"
            Case TableMode.T_CUSTOMER_HISTORY
                tableName = "t_customer_history"
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

    '칼럼명인 경우 skip
    '첫번째 데이터 항목(고객명)이 ""인 경우 skip
    '직장번호(5번째)핸드폰번호(6번째)모두 값이없는 경우 번호에러 => NO_HP_NO_PHONE
    '직장번호에 핸드폰번호있는 경우 번호에러                     => PHONE_IS_HP
    '핸드폰번호에 핸드폰번호가 아닌 경우 번호에러                => HP_NO_HP
    '고객정보는 '일반고객'이 기본값
    '직장번호항목값이 이미 등록된 직장번호값으로 존재하는 경우 중복
    '핸드폰항목값이 이미 등록된 핸드폰항목값으로 존재하는 경우 중복
    Public Sub Excells_Import(ByVal filepath As String)
        Dim resultCnt As Integer = 0
        Dim dtDupCheck As DataTable
        Dim sqlPre As String = ""
        Dim sqlMain As String = ""
        Dim sqlValue As String = ""
        Dim ext As String = ""
        Dim i As Integer = 0
        Dim nExcelCnt As Integer = 0
        Dim nOkCnt As Integer = 0
        Dim nErrCntWrongPhoneFormat As Integer = 0
        Dim nErrCnt As Integer = 0
        Dim defCustLevel As String = "03"
        Dim ExcelResult As UploadResult = UploadResult.SUCCESS
        Dim curCountForCommit As Integer = 0
        Dim commitCount As Integer = 100
        Dim curCount As Integer = 0
        Dim hasData As Boolean = False

        Dim xField00 As String = ""
        Dim xField01 As String = ""
        Dim xField02 As String = ""
        Dim xField03 As String = ""
        Dim xField04 As String = ""
        Dim xField05 As String = ""
        Dim xField06 As String = ""
        Dim xField07 As String = ""
        Dim xField08 As String = ""
        Dim xField09 As String = ""
        Dim xField10 As String = ""
        Dim xField11 As String = ""

        Try

            'TimerUpload.Start()
            'System.Threading.Thread.Sleep(1000)

            'Dim filePath As String = "c:\\work\\temp\\고객정보추출목록20120721.xlsx"

            Dim stream As FileStream = File.Open(filepath, FileMode.Open, FileAccess.Read)

            Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream)

            Dim result As DataSet = excelReader.AsDataSet()

            excelReader.IsFirstRowAsColumnNames = True

            mCntTotal = excelReader.ResultsCount

            sqlPre = "INSERT INTO T_CUSTOMER_EXCEL_TMP(COM_CD,CUSTOMER_NM, " & _
                        "COMPANY,DEPARTMENT,JOB_TITLE, " & _
                        "C_TELNO,H_TELNO,FAX_NO,EMAIL,CUSTOMER_TYPE,WOO_NO, " & _
                        "CUSTOMER_ADDR,CUSTOMER_ETC,C_TELNO1,H_TELNO1,UPLOAD_RESULT) " & _
                        " Values"

            While True
                hasData = excelReader.Read()



                '데이터가 더이상없으면 이전 추가된 sql만 실행하고 빠져나옴
                If Not hasData OrElse excelReader.GetString(0) Is Nothing Then
                    WriteLog("No More Data: excelReader.ExceptionMessage:" & excelReader.ExceptionMessage)

                    If curCountForCommit > 0 Then
                        Mysql_Transact_Data(gsConString, sqlMain)
                    End If
                    Exit While
                End If

                '칼럼명인 경우 skip
                If excelReader.GetString(0).ToString().Trim = gsCheckCustomerColumnName Then
                    Continue While
                End If

                ExcelResult = UploadResult.SUCCESS

                '첫번째 데이터 항목(고객명)이 ""인 경우 skip
                If excelReader.GetString(0).ToString().Trim = "" Then
                    nErrCnt += 1
                    Continue While
                End If

                'Null check
                If excelReader.GetString(0) Is Nothing Then
                    xField00 = ""
                Else
                    xField00 = excelReader.GetString(0).ToString()
                End If
                If excelReader.GetString(1) Is Nothing Then
                    xField01 = ""
                Else
                    xField01 = excelReader.GetString(1).ToString()
                End If
                If excelReader.GetString(2) Is Nothing Then
                    xField02 = ""
                Else
                    xField02 = excelReader.GetString(2).ToString()
                End If
                If excelReader.GetString(3) Is Nothing Then
                    xField03 = ""
                Else
                    xField03 = excelReader.GetString(3).ToString()
                End If
                If excelReader.GetString(4) Is Nothing Then
                    xField04 = ""
                Else
                    xField04 = excelReader.GetString(4).ToString()
                End If
                If excelReader.GetString(5) Is Nothing Then
                    xField05 = ""
                Else
                    xField05 = excelReader.GetString(5).ToString()
                End If
                If excelReader.GetString(6) Is Nothing Then
                    xField06 = ""
                Else
                    xField06 = excelReader.GetString(6).ToString()
                End If
                If excelReader.GetString(7) Is Nothing Then
                    xField07 = ""
                Else
                    xField07 = excelReader.GetString(7).ToString()
                End If
                If excelReader.GetString(8) Is Nothing Then
                    xField08 = ""
                Else
                    xField08 = excelReader.GetString(8).ToString()
                End If
                If excelReader.GetString(9) Is Nothing Then
                    xField09 = ""
                Else
                    xField09 = excelReader.GetString(9).ToString()
                End If
                If excelReader.GetString(10) Is Nothing Then
                    xField10 = ""
                Else
                    xField10 = excelReader.GetString(10).ToString()
                End If
                If excelReader.GetString(11) Is Nothing Then
                    xField11 = ""
                Else
                    xField11 = excelReader.GetString(11).ToString()
                End If



                '직장번호(5번째)핸드폰번호(6번째)모두 값이없는 경우 번호에러 => NO_HP_NO_PHONE
                If (xField04.Trim() = "" _
                    And xField05.Trim() = "") Then
                    nErrCntWrongPhoneFormat += 1

                    ExcelResult = UploadResult.NO_HP_NO_PHONE
                    WriteLog("i:" & nExcelCnt & _
                             "[" & xField00.Trim & "]" & _
                             "[" & xField01.Trim & "]" & _
                             "[" & xField02.Trim & "]" & _
                             "[" & xField03.Trim & "]" & _
                             "[" & xField04.Trim & "]" & _
                             "[" & xField05.Trim & "]" & _
                             "[" & xField06.Trim & "]" & _
                             "[" & xField07.Trim & "]" & _
                             "[" & xField08.Trim & "]" & _
                             "[" & xField09.Trim & "]" & _
                             "[" & xField10.Trim & "]" & _
                             "[" & xField11.Trim & "]" & _
                             MsgNoHPNoPhone)
                    'Continue For
                End If

                ''직장번호에 핸드폰번호있는 경우 번호에러                     => PHONE_IS_HP
                'If (xField04.Trim() <> "" _
                '     And IsHPNumber(xField04)) Then
                '    nErrCntWrongPhoneFormat += 1
                '    ExcelResult = UploadResult.PHONE_IS_HP
                '    WriteLog("i:" & nExcelCnt & _
                '             "[" & xField00.Trim & "]" & _
                '             "[" & xField01.Trim & "]" & _
                '             "[" & xField02.Trim & "]" & _
                '             "[" & xField03.Trim & "]" & _
                '             "[" & xField04.Trim & "]" & _
                '             "[" & xField05.Trim & "]" & _
                '             "[" & xField06.Trim & "]" & _
                '             "[" & xField07.Trim & "]" & _
                '             "[" & xField08.Trim & "]" & _
                '             "[" & xField09.Trim & "]" & _
                '             "[" & xField10.Trim & "]" & _
                '             "[" & xField11.Trim & "]" & _
                '             MsgPhoneIsHP)
                '    'Continue For
                'End If

                '핸드폰번호에 핸드폰번호가 아닌 경우 번호에러                => HP_NO_HP
                If (xField05.Trim() <> "" _
                        And Not IsHPNumber(xField05)) Then
                    nErrCntWrongPhoneFormat += 1

                    ExcelResult = UploadResult.HP_NO_HP
                    WriteLog("i:" & nExcelCnt & _
                             "[" & xField00.Trim & "]" & _
                             "[" & xField01.Trim & "]" & _
                             "[" & xField02.Trim & "]" & _
                             "[" & xField03.Trim & "]" & _
                             "[" & xField04.Trim & "]" & _
                             "[" & xField05.Trim & "]" & _
                             "[" & xField06.Trim & "]" & _
                             "[" & xField07.Trim & "]" & _
                             "[" & xField08.Trim & "]" & _
                             "[" & xField09.Trim & "]" & _
                             "[" & xField10.Trim & "]" & _
                             "[" & xField11.Trim & "]" & _
                             MsgHPNoHP)
                    'Continue For
                End If

                '고객정보는 '일반고객'이 기본값
                If xField08.Trim = "" Then
                    defCustLevel = "03"
                Else
                    defCustLevel = xField08.Trim
                End If


                sqlValue = "('" & _
                                gsCOM_CD & "','" & _
                                ToQuotedStr(xField00.Trim) & "','" & _
                                ToQuotedStr(xField01.Trim) & "','" & _
                                ToQuotedStr(xField02.Trim) & "','" & _
                                ToQuotedStr(xField03.Trim) & "','" & _
                                xField04.Replace("-", "").Replace(" ", "").Trim & "','" & _
                                xField05.Replace("-", "").Replace(" ", "").Trim & "','" & _
                                xField06.Replace("-", "").Replace(" ", "").Trim & "','" & _
                                ToQuotedStr(xField07.Trim) & "','" & _
                                defCustLevel & "','" & _
                                xField09.Replace("-", "").Replace(" ", "").Trim & "','" & _
                                ToQuotedStr(xField10.Trim) & "','" & _
                                ToQuotedStr(xField11.Trim) & "','" & _
                                xField04.Replace("-", "").Replace(" ", "").Trim & "','" & _
                                xField05.Replace("-", "").Replace(" ", "").Trim & "','" & _
                                ExcelResult & "')"

                If curCountForCommit = 0 Then
                    sqlMain = sqlPre & sqlValue
                Else
                    sqlMain = sqlMain & "," & sqlValue
                End If

                curCountForCommit += 1
                curCount += 1

                If ExcelResult = UploadResult.SUCCESS Then
                    nOkCnt += 1
                End If

                If curCountForCommit = commitCount OrElse Not hasData Then
                    Mysql_Transact_Data(gsConString, sqlMain)
                    curCountForCommit = 0
                    sqlMain = ""
                End If

                If Not hasData Then
                    Exit While
                End If

            End While

            excelReader.Close()

            '고객정보는 '일반고객'이 기본값
            '직장번호항목값이 이미 등록된 직장번호값으로 존재하는 경우 중복
            '핸드폰항목값이 이미 등록된 핸드폰항목값으로 존재하는 경우 중복
            Dim sqlSelect As String = "select distinct a.customer_id new_customer_id " & _
                      " from t_customer_excel_tmp a,  " & _
                      "      t_customer_excel_backup b " & _
                      " where a.customer_nm = b.customer_nm " & _
                      " and a.com_cd = b.com_cd " & _
                      " and ((a.c_telno = b.c_telno and a.c_telno > '') " & _
                      "		or (a.h_telno = b.h_telno and a.h_TELNO > '')) "
            dtDupCheck = GetData_table1(gsConString & ";default command timeout=3600;", sqlSelect)


            mCntDup = dtDupCheck.Rows.Count
            nOkCnt = nOkCnt - mCntDup - nErrCnt
            mCnt = nOkCnt
            mCntWrongPhoneFormat = nErrCntWrongPhoneFormat
            mCntError = nErrCnt

            WriteLog("*** 전체대상건[" & mCntTotal & "] 정상입력건[" & nOkCnt & "] 중복건[" & mCntDup & "] 번호오류[" & nErrCntWrongPhoneFormat & "] 기타오류/등록오류[" & nErrCnt & "]")
        Catch ex As Exception
            'WriteLog(ex.ToString)
            Throw New Exception(ex.ToString)
        Finally
            dtDupCheck = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            If nOkCnt > 0 Then Call Audit_Log(AUDIT_TYPE.CUSTOMER_IMPORT, "Customer Import:" & CStr(nOkCnt))
            'frm.Close()
            'TimerUpload.Stop()
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            With OpenFileDialog1
                .CheckFileExists = True
                .CheckPathExists = True
                .Filter = "Excel통합문서(*.xlsx)|*.xlsx|Excel97-2003문서(*.xls)|*.xls"
                .FileName = "고객정보(등록용)"
                .Title = "고객정보 가져오기"
                .Multiselect = False
                If .ShowDialog() = Windows.Forms.DialogResult.OK Then


                    Try

                        Dim hasData As Boolean = False
                        Dim filePath As String = OpenFileDialog1.FileName

                        Dim stream As FileStream = File.Open(filepath, FileMode.Open, FileAccess.Read)

                        Dim excelReader As IExcelDataReader = ExcelReaderFactory.CreateOpenXmlReader(stream)

                        Dim result As DataSet = excelReader.AsDataSet()

                        excelReader.IsFirstRowAsColumnNames = True

                        mCntTotal = excelReader.ResultsCount

                        While True
                            hasData = excelReader.Read()



                            '데이터가 더이상없으면 이전 추가된 sql만 실행하고 빠져나옴
                            If Not hasData Then
                                WriteLog("excelReader.ExceptionMessage:" & excelReader.ExceptionMessage)

                                Exit While
                            End If

                            If excelReader Is Nothing Then
                                WriteLog("excelReader Is Nothing")
                                WriteLog("No More Data: excelReader.ExceptionMessage:" & excelReader.ExceptionMessage)
                            End If

                            If excelReader.GetString(0) Is Nothing Then
                                WriteLog("excelReader.GetString(0) Is Nothing")
                                WriteLog("No More Data: excelReader.ExceptionMessage:" & excelReader.ExceptionMessage)
                            End If
                            If excelReader.IsValid Then
                                WriteLog("i:" & excelReader.ResultsCount & _
                                             "[" & excelReader.GetString(0).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(1).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(2).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(3).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(4).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(5).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(6).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(7).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(8).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(9).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(10).ToString().Trim & "]" & _
                                             "[" & excelReader.GetString(11).ToString().Trim & "]")
                            End If


                            'Continue For
                            

                            If Not hasData Then
                                Exit While
                            End If

                        End While

                        excelReader.Close()

                    Catch ex As Exception
                        WriteLog(ex.ToString)
                    Finally
                        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
                    End Try

                End If
            End With



        Catch ex As Exception
            WriteLog(ex.ToString)
        End Try
    End Sub
End Class