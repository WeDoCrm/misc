Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Threading
Imports MySql.Data
Imports MySql.Data.MySqlClient

Module MiniCTI
	
    Public gsCOM_CD As String
    Public gsUSER_ID As String
    Public gsUSER_NM As String
    Public gsUSR_HP As String
    Public gsADDR1 As String
    Public gsWOO_NO As String
    Public gsH_TELNO As String
    Public gsDEPART_CD As String
    Public gsGRADE As String
    Public gsEXTENSION_NO As String
    Public gsWORK_TYPE As String
    Public gsENTERING_DD As String
    Public gsRETIRE_DD As String
    Public gsUSER_EMAIL As String
    Public gsDEPART_NM As String
    Public gsUSER_PWD As String
    Public gsWORK_AREA As String
    Public gsCompany As String

    Public gsTeam_CD As String
    Public gsTeam_NM As String

    Public gsSocketIP As String
    Public gsSocketPort As String


    Public gsConString As String                  ' DB Con String
    Public Const file_path As String = "C:\MiniCTI"
    Public Const config_file As String = "\config\MiniCTI_config.xml"
    Public Const gsAppVersion As String = "Ver 2.1.1.2"
    Public gsPopUpOption As String = "MDI"
    Public LogName As String = "\log\DbMgmt_"
    Public BulkFileName As String = "\log\DbBulkFile"

    Public gsUseARS As String = "N"

    Public FormAliveYN As String = "N"

    Public DBConReadYn As String = "N"                      ' DB Connection string read 여부

    Public gbIsCustomerTablePatched As Boolean = False

    Public Const gsExcelSheetCustomer As String = "고객정보"
    Public Const gsCheckCustomerColumnName As String = "고객명"
    Public Const giCustomerImportColCount As Integer = 9


    Public Function gfTelNoTransReturn(ByVal telno As String) As String
        Dim tel As String = "000-0000-0000"

        Try
            Dim tel_no As String = telno.Trim.Substring(0, 3)

            Dim pre_tel_no As String = "0000"
            Dim mid_tel_no As String = "0000"
            Dim last_tel_no As String = "0000"

            If tel_no = "010" Or tel_no = "011" Or tel_no = "016" Or tel_no = "017" Or tel_no = "018" Or tel_no = "019" Then
                pre_tel_no = tel_no
                Dim rest_telno As String = telno.Substring(3)
                If rest_telno.Length = 7 Then
                    mid_tel_no = telno.Substring(3, 3)
                    last_tel_no = telno.Substring(6)
                ElseIf rest_telno.Length = 8 Then
                    mid_tel_no = telno.Substring(3, 4)
                    last_tel_no = telno.Substring(7)
                End If

                tel = pre_tel_no + "-" + mid_tel_no + "-" + last_tel_no
            Else

                tel_no = telno.Trim.Substring(0, 2)

                If tel_no = "02" Then            ' 서울 지역일때
                    pre_tel_no = "02"

                    Dim rest_telno As String = telno.Substring(2)
                    If rest_telno.Length = 7 Then
                        mid_tel_no = telno.Substring(2, 3)
                        last_tel_no = telno.Substring(5)
                    ElseIf rest_telno.Length = 8 Then
                        mid_tel_no = telno.Substring(2, 4)
                        last_tel_no = telno.Substring(6)
                    End If

                    tel = pre_tel_no + "-" + mid_tel_no + "-" + last_tel_no
                Else
                    pre_tel_no = telno.Substring(0, 3)

                    Dim rest_telno As String = telno.Substring(3)
                    If rest_telno.Length = 7 Then
                        mid_tel_no = telno.Substring(3, 3)
                        last_tel_no = telno.Substring(6)
                    ElseIf rest_telno.Length = 8 Then
                        mid_tel_no = telno.Substring(3, 4)
                        last_tel_no = telno.Substring(7)
                    End If

                    tel = pre_tel_no + "-" + mid_tel_no + "-" + last_tel_no
                End If

            End If

        Catch ex As Exception
            tel = "000-0000-0000"
        End Try

        Return tel

    End Function

    Public Function IsHPNumber(ByVal num As String) As Boolean
        num = num.Replace("-", "")

        If num.Trim() = "" Or num.Length > 11 Or num.Length < 10 Then
            Return False
        End If

        Dim tel_no As String = num.Trim.Substring(0, 3)

        If tel_no = "010" Or tel_no = "011" Or tel_no = "016" Or tel_no = "017" Or tel_no = "018" Or tel_no = "019" Then
            Return True
        Else
            Return False
        End If
    End Function

    'Public Sub popup1()
    '    Dim newF As New FRM_CUSTOMER_POPUP
    '    newF.Show()

    'End Sub

    Public Function XmlRead(ByVal n As Integer, ByVal keyname As String) As String
        Try
            Dim doc As XmlDocument = New XmlDocument()
            doc.Load(file_path & config_file)

            Dim root As XmlElement = doc.DocumentElement


            Dim elemList As XmlNodeList = root.GetElementsByTagName(keyname)

            Return elemList.Item(0).ChildNodes(n).FirstChild.Value.ToString

            Exit Function

        Catch ex As Exception
            Call WriteLog("Error(XMLRead) : " & ex.ToString)
            Throw New Exception(ex.ToString)
            Return ""
        End Try

    End Function

    Public Sub XmlReadMode()
        Try
            gsConString = "Data Source=" & XmlRead(1, "db") & ";Initial Catalog=" & XmlRead(2, "db") & ";User ID=" & XmlRead(3, "db") & ";Password=" & XmlRead(4, "db")
            DBConReadYn = "Y"
            gsUseARS = XmlRead(0, "worktype")
        Catch ex As Exception
            Call WriteLog(ex.ToString)
            Throw New Exception(ex.ToString)
            DBConReadYn = "N"
            gsConString = ""
        End Try
    End Sub

    '**********************************************************************************************************
    '****************************** 모두 이함수 사용합시다 ****************************************************
    '**********************************************************************************************************
    Public Function GetData_table1(ByVal constring As String, ByVal strSql As String) As DataTable

        Dim con As MySqlClient.MySqlConnection
        Dim com As MySqlClient.MySqlCommand
        Dim da As MySqlClient.MySqlDataAdapter
        Dim dt As New DataTable
        Dim temp As String = ""

        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            con = New MySqlClient.MySqlConnection(constring)
            com = New MySqlClient.MySqlCommand(strSql, con)
            da = New MySqlClient.MySqlDataAdapter(com)

            com.CommandType = CommandType.Text
            com.CommandText = strSql

            con.Open()
            da.Fill(dt)

        Catch ex As Exception
            Call WriteLog(ex.ToString)
            Throw New Exception("GetData_table1 Error")
        Finally
            GetData_table1 = dt
            con.Close()

            dt = Nothing
            da = Nothing
            com = Nothing
            con = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        End Try
    End Function

    Public Function GetData_table_Error(ByVal constring As String, ByVal strSql As String) As DataTable

        Dim con As MySqlClient.MySqlConnection
        Dim com As MySqlClient.MySqlCommand
        Dim da As MySqlClient.MySqlDataAdapter
        Dim dt As New DataTable
        Dim temp As String = ""

        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            con = New MySqlClient.MySqlConnection(constring)
            com = New MySqlClient.MySqlCommand(strSql, con)
            da = New MySqlClient.MySqlDataAdapter(com)

            com.CommandType = CommandType.Text
            com.CommandText = strSql

            con.Open()
            da.Fill(dt)
        Catch ex As Exception
            Call WriteLog(ex.ToString)
            Throw New Exception("GetData_table_Error")
        Finally
            GetData_table_Error = dt
            con.Close()
            dt = Nothing
            da = Nothing
            com = Nothing
            con = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default

        End Try
    End Function


    Public Function GetData_exe(ByVal constring As String, ByVal procedurename As String, ByVal ParamArray parameters() As String) As Boolean

        Dim bol As Boolean = True
        Dim s_dbcon As String = constring
        Dim con As SqlClient.SqlConnection
        Dim com As SqlClient.SqlCommand
        Dim da As SqlClient.SqlDataAdapter
        Dim ds As DataSet
        Dim querystring As String = "Exec "     '프로시져 실행구문을 작성한다.
        Dim i As Integer


        Try

            con = New SqlClient.SqlConnection(s_dbcon)
            com = New SqlClient.SqlCommand
            da = New SqlClient.SqlDataAdapter(com)
            ds = New DataSet

            querystring = querystring & procedurename & " "     '프로시져의 명을 실행구문에 추가한다.

            If parameters.Length > 0 Then
                querystring = querystring & "'" & parameters(0).Replace("'", "''") & "'"        '첫번째 파라메터를 실행구문에 추가한다.
            End If

            For i = 1 To parameters.Length - 1
                querystring = querystring & ", '" & parameters(i).Replace("'", "''") & "'"      '두번째 이후 파라메터들을 실행구문에 추가한다.
            Next

            com.CommandText = querystring

            com.Connection = con
            con.Open()

            Dim j As Integer = com.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            bol = False
            Call WriteLog("Exception : " & ex.ToString)
            Throw New Exception("GetData_exe")
        End Try

        Return bol

    End Function

    Public Sub WriteLog(ByVal msg As String)

        Dim strNow As String
        Dim strNow1 As String

        Try
            strNow = Format(Now, "yyyyMMddHHmmss")

            '파일 스트림 생성
            Dim fs As FileStream = New FileStream(file_path & LogName & strNow.Substring(0, 8) & ".log", FileMode.Append)

            '파일 입력 작업을 위해 StreamWriter 객체를 얻는다
            Dim sw As StreamWriter = New StreamWriter(fs, System.Text.Encoding.Default)

            strNow1 = "[" & Format(Now, "yyyy-MM-dd HH:mm:ss") & "]"

            sw.WriteLine(strNow1)
            sw.WriteLine("          " & msg)

            sw.Close()
            fs = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Public Sub WriteBulkDataFile(ByVal record As String)

        Try

            '파일 스트림 생성
            Dim fs As FileStream = New FileStream(file_path & BulkFileName, FileMode.Append)

            '파일 입력 작업을 위해 StreamWriter 객체를 얻는다
            Dim sw As StreamWriter = New StreamWriter(fs, System.Text.Encoding.Default)

            sw.WriteLine(record)

            sw.Close()
            fs = Nothing

        Catch ex As Exception

        End Try
    End Sub

    Public Sub log_delete()

        Dim log_delete_day As String = DateTime.Now.AddDays(-5).ToString.Substring(0, 10).Replace("-", "")

        Try
            Dim dir1 As DirectoryInfo = New DirectoryInfo(file_path & "\log")
            Dim datfiles() As FileInfo = dir1.GetFiles("*.log")

            Dim f As FileInfo

            For Each f In datfiles
                ' 0      1     2  3    4     5 
                'Online_Daemon_To_Host_lib_20101118.log()
                Dim f_name() As String = f.Name.ToString.Split("_")
                'If f.Name.Contains(log_delete_day) = False Then
                '    Call WriteLog("Log Data 삭제 --> 삭제 파일명 : " & f.Name.ToString.Trim)
                '    f.Delete()
                'End If

                If f_name(5).ToString.Replace(".log", "") < log_delete_day Then
                    f.Delete()
                    Call WriteLog("Log Data  --> File Name : " & f.Name.ToString.Trim)
                End If

            Next

            f = Nothing
            dir1 = Nothing

        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try

    End Sub

    Public Function Mysql_GetData_table(ByVal constring As String, ByVal sqltext As String, ByVal ParamArray parameters() As String) As DataTable

        Dim s_dbcon As String = constring
        Dim con As MySqlConnection
        Dim com As MySqlCommand
        Dim da As MySqlDataAdapter
        Dim dt As New DataTable
        Dim temp As String = ""

        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        con = New MySqlConnection(constring) 'SqlClient.SqlConnection(s_dbcon)
        com = New MySqlCommand
        da = New MySqlDataAdapter(com)

        Try
            com.CommandText = sqltext     '쿼리 실행구문
            'WriteLog(sqltext)
            com.Connection = con
            con.Open()
            If sqltext.Trim.ToLower.StartsWith("select") = True Then
                da.Fill(dt)
            Else
                Dim j As Integer = com.ExecuteNonQuery()
            End If
            com.Parameters.Clear()
        Catch ex As Exception
            Call WriteLog(ex.ToString)
            Throw New Exception("Mysql_GetData_table")
        Finally
            con.Close()
            dt = Nothing
            da = Nothing
            com = Nothing
            con = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
        Return dt
    End Function

    Public Function Mysql_Transact_Data(ByVal constring As String, ByVal sqltext As String, ByVal ParamArray parameters() As String) As Integer

        Dim s_dbcon As String = constring
        Dim con As MySqlConnection
        Dim com As MySqlCommand
        Dim da As MySqlDataAdapter
        Dim dt As New DataTable
        Dim temp As String = ""
        Dim iRow As Integer

        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        con = New MySqlConnection(constring) 'SqlClient.SqlConnection(s_dbcon)
        com = New MySqlCommand
        da = New MySqlDataAdapter(com)

        Try
            com.CommandText = sqltext     '쿼리 실행구문
            'WriteLog(sqltext)
            com.Connection = con
            con.Open()
            If sqltext.Trim.ToLower.StartsWith("select") = True Then
                Throw (New Exception("Query is not available with this method."))
            Else
                iRow = com.ExecuteNonQuery()
            End If
            com.Parameters.Clear()
        Catch ex As Exception
            Call WriteLog(ex.ToString)
            Throw New Exception("Mysql_Transact_Data")
        Finally
            con.Close()
            da = Nothing
            com = Nothing
            con = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try

        Return iRow
    End Function


    Public Function Mysql_Command(ByVal constring As String, ByVal sqltext As String, ByVal ParamArray parameters() As String) As Integer

        Dim s_dbcon As String = constring
        Dim con As MySqlConnection
        Dim com As MySqlCommand
        Dim da As MySqlDataAdapter
        Dim dt As New DataTable
        Dim temp As String = ""
        Dim iRow As Integer

        Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        con = New MySqlConnection(constring) 'SqlClient.SqlConnection(s_dbcon)
        com = New MySqlCommand
        da = New MySqlDataAdapter(com)

        Try
            com.CommandText = sqltext     '쿼리 실행구문
            'WriteLog(sqltext)
            com.Connection = con
            con.Open()
            If sqltext.Trim.ToLower.StartsWith("select") = True Then
                Throw (New Exception("Query is not available with this method."))
            Else
                iRow = com.ExecuteNonQuery()
            End If
            com.Parameters.Clear()
        Catch ex As Exception
            Call WriteLog(ex.ToString)
            Throw New Exception("Mysql_Command")
        Finally
            con.Close()
            da = Nothing
            com = Nothing
            con = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
        Return iRow
    End Function

    Public Sub CB_Set(ByVal constring As String, ByVal sqltext As String, ByVal obj As Object, ByVal TextField As String, ByVal ValueField As String, ByVal SelectValue As Object, ByVal ParamArray parameters() As String)
        Dim dt As DataTable
        Try
            dt = Mysql_GetData_table(constring, sqltext, parameters)
            obj.DataSource = dt
            obj.DisplayMember = TextField
            obj.ValueMember = ValueField
            If SelectValue = Nothing Then Exit Try
            If obj.ValueMember.Contains(SelectValue) = True Then
                obj.SelectedValue = SelectValue
            End If

        Catch ex As Exception
            WriteLog(ex.ToString)
        Finally
            dt = Nothing
        End Try
    End Sub

    Public Sub CB_Set2(ByVal obj As ComboBox, ByVal type As String, ByVal iSTART As Short, ByVal iEND As Short, ByVal iInterval As Short, ByVal SelectText As String, ByVal ParamArray parameters() As String)

        Dim i As Short = iEND - iSTART '+ 1
        Dim j As Short = 0
        Dim k As Short = 0

        Try
            If i < 1 OrElse iInterval < 1 Then Exit Try
            obj.Items.Clear()
            k = i / iInterval
            Dim ItemObject(k) As System.Object

            Select Case type.ToLower.Trim
                Case "datetime"
                    While j <= k
                        i = iSTART + (iInterval * j)
                        'WriteLog("j:" & j & " i:" & i)
                        If i < 10 Then
                            ItemObject(j) = "0" & CStr(i)
                        Else
                            ItemObject(j) = CStr(i)
                        End If
                        j += 1
                    End While
                    obj.Items.AddRange(ItemObject)
                Case Else
                    While j <= k
                        i = iSTART + (iInterval * j)
                        ItemObject(j) = CStr(i)
                        j += 1
                    End While
                    obj.Items.AddRange(ItemObject)
            End Select

            If parameters.Length > 0 Then
                Select Case parameters(0).Trim.ToLower
                    Case "add"
                        obj.Items.Insert(0, "")
                        obj.SelectedIndex = 0
                    Case Else
                End Select
            End If
            If obj.FindString(SelectText) >= 0 Then
                'obj.SelectedText = SelectText
                obj.Text = SelectText
            End If

            ItemObject = Nothing
        Catch ex As Exception
            WriteLog(ex.ToString)
        Finally

        End Try
    End Sub

    Public Sub GV_DataBind(ByVal constring As String, ByVal sqltext As String, ByVal obj As DataGridView, ByVal ParamArray parameters() As String)
        Dim dt As DataTable

        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
            obj.AutoGenerateColumns = False
            dt = Mysql_GetData_table(constring, sqltext, parameters)
            If dt.Rows.Count = 1 AndAlso dt.Rows(0).Item(0).ToString = "합계" Then  '데이타가 없는 경우 합계도 안보여주기.
                obj.DataSource = Nothing
            Else
                obj.DataSource = dt
            End If
        Catch ex As Exception
            WriteLog(ex.ToString)
        Finally
            dt = Nothing
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try

    End Sub

    Public Function Get_TELNO(ByVal tenno1 As String)
        Dim telno As String = tenno1.Replace("-", "").Trim
        Try
            If telno.Length < 7 Then Exit Try
            Select Case telno.Length
                Case 7
                    telno = telno.Substring(0, 3) & "-" & telno.Substring(3)
                Case 8
                    If telno.StartsWith("2") = True Then
                        telno = "02-" & telno.Substring(1, 3) & "-" & telno.Substring(4)
                    Else
                        telno = telno.Substring(0, 4) & "-" & telno.Substring(4)
                    End If
                Case Else
                    If telno.StartsWith("0") = False Then telno = "0" & telno
                    If telno.StartsWith("02") = True Then '024445555   9  0244445555
                        telno = "02-" & telno.Substring(2, telno.Length - 6) & "-" & telno.Substring(telno.Length - 4)
                    Else  '0101234567 10    01012345678 11
                        telno = telno.Substring(0, 3) & "-" & telno.Substring(3, telno.Length - 7) & "-" & telno.Substring(telno.Length - 4)
                    End If
            End Select

        Catch ex As Exception
            WriteLog(ex.ToString)
        Finally
            Get_TELNO = telno
        End Try

    End Function

    Enum AUDIT_TYPE
        CUSTOMER_IMPORT = 0
        CUSTOMER_EXPORT = 1
        CODE_ADD = 2
        CODE_DEL = 3
        CODE_MOD = 4
        PWD_MOD = 5
        CALLLOG_DOWN = 6
        USER_ADD = 7
        USER_DEL = 8
        USER_MOD = 9
    End Enum

    Public Sub Audit_Log(ByVal auditType As AUDIT_TYPE, ByVal auditDesc As String)

        Dim tm As String = Format(Now, "yyyyMMddHHmmss")
        Dim auditCode As String = "0000"
        Dim auditCodeDesc As String = "0000"
        Try
            'select COM_CD,CUSTOMER_ID,TELNO_TYPE,TELNO from t_customer_telno
            'gsCOM_CD

            Select Case auditType
                Case AUDIT_TYPE.CUSTOMER_IMPORT
                    auditCode = "0001"
                    auditCodeDesc = auditCode & ":CUSTOMER_IMPORT"
                Case AUDIT_TYPE.CUSTOMER_EXPORT
                    auditCode = "0002"
                    auditCodeDesc = auditCode & ":CUSTOMER_EXPORT"
                Case AUDIT_TYPE.CODE_ADD
                    auditCode = "0003"
                    auditCodeDesc = auditCode & ":CODE_ADD"
                Case AUDIT_TYPE.CODE_DEL
                    auditCode = "0004"
                    auditCodeDesc = auditCode & ":CODE_DEL"
                Case AUDIT_TYPE.CODE_MOD
                    auditCode = "0005"
                    auditCodeDesc = auditCode & ":CODE_MOD"
                Case AUDIT_TYPE.PWD_MOD
                    auditCode = "0006"
                    auditCodeDesc = auditCode & ":PWD_MOD"
                Case AUDIT_TYPE.CALLLOG_DOWN
                    auditCode = "0007"
                    auditCodeDesc = auditCode & ":CALLLOG_DOWN"
                Case AUDIT_TYPE.USER_ADD
                    auditCode = "0008"
                    auditCodeDesc = auditCode & ":USER_ADD"
                Case AUDIT_TYPE.USER_DEL
                    auditCode = "0009"
                    auditCodeDesc = auditCode & ":USER_DEL"
                Case AUDIT_TYPE.USER_MOD
                    auditCode = "0010"
                    auditCodeDesc = auditCode & ":USER_MOD"
            End Select

            Dim SQL As String = " INSERT INTO t_auditlog( COM_CD,USER_ID,AUDIT_DD,AUDIT_CD, AUDIT_DESC) VALUES( "
            SQL = SQL & "'" & gsCOM_CD & "'"
            SQL = SQL & ",'" & gsUSER_ID & "'"
            SQL = SQL & ",'" & tm & "'"
            SQL = SQL & ",'" & auditCode & "'"
            SQL = SQL & ",'" & auditDesc & "')"

            Dim dt As DataTable = GetData_table1(gsConString, SQL)

            dt = Nothing

            Call WriteLog("Audit_Log: " & "[" & gsCOM_CD & "][" & gsUSER_ID & "][" & tm & "][" & auditCodeDesc & "]")

        Catch ex As Exception
            Call WriteLog("Audit_Log:Write Error:" & "[" & gsCOM_CD & "][" & gsUSER_ID & "][" & tm & "][" & auditCodeDesc & "]")
            Call WriteLog("Audit_Log:Write Error:" & ex.ToString)
        End Try
    End Sub

    Public Sub setComboSelect(ByVal sender As System.Object, ByVal idx As Integer)
        Dim cBox As ComboBox = sender
        If cBox.Items.Count >= idx + 1 Then
            cBox.SelectedIndex = idx
        Else
            cBox.SelectedIndex = 0
        End If
    End Sub


    'Mysql_Transact_Data
    Public Function doCommandSql(ByVal Sql As String) As Boolean
        Dim isGood As Boolean = False
        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            If Mysql_Command(gsConString, Sql) >= 0 Then
                isGood = True
            End If


        Catch ex As Exception
            Call WriteLog(Sql & " : " & ex.ToString)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
        Return isGood
    End Function


    Public Function doRunQuery(ByVal Sql As String) As Boolean
        Dim isGood As Boolean = False
        Try
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor

            Dim dt1 As DataTable = GetData_table1(gsConString, sql)

            isGood = True

        Catch ex As Exception
            Call WriteLog(Sql & " : " & ex.ToString)
        Finally
            Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
        End Try
        Return isGood
    End Function

    Public Function ToQuotedStr(ByVal value As String) As String
        Return value.Trim.Replace("'", "''")
    End Function

    Public sqlCustomerFields As String = "COM_CD, CUSTOMER_ID, CUSTOMER_NM, C_TELNO, H_TELNO, FAX_NO, COMPANY, DEPARTMENT " & _
                                         ", JOB_TITLE, EMAIL, CUSTOMER_TYPE, WOO_NO, CUSTOMER_ADDR, CUSTOMER_ETC, C_TELNO1, H_TELNO1, UPDATE_DATE, TEMP_ID " & _
                                         ", TONG_USER, USER_DEF"

    Public sqlCustomerHistoryFields As String = "COM_CD, CUSTOMER_ID, TOND_DD, TONG_TIME, TONG_USER, CALL_TYPE " & _
                                                ", CONSULT_RESULT, CONSULT_TYPE, TONG_CONTENTS, TONG_TELNO, TELNO_TYPE, CUSTOMER_NM " & _
                                                ", BK_YN, HANDLE_TYPE, CALL_BACK_YN, CALL_BACK_RESULT, CALL_BACK_AGENT, UPDATE_DATE " & _
                                                ", PREV_TONG_DD, PREV_TONG_TIME, PREV_TONG_USER, TRANS_YN, TEMP_ID "

    Public sqlUpdateCustomerId As String = "  set customer_id = (select max(a.customer_id) from t_customer a,  " & _
                                    "  												       t_customer_excel_backup b " & _
                                    "  												 where a.customer_nm = b.customer_nm " & _
                                    "  												   and a.com_cd = b.com_cd " & _
                                    "  												  and ((a.c_telno = b.c_telno and a.c_telno > '') " & _
                                    "         												or (a.h_telno = b.h_telno and a.h_TELNO > '')) " & _
                                    "  												   and b.customer_id = c.customer_id) " & _
                                    "  where customer_id = (select b.customer_id from t_customer a,  " & _
                                    "  												       t_customer_excel_backup b " & _
                                    "  												 where a.customer_nm = b.customer_nm " & _
                                    "  												   and a.com_cd = b.com_cd " & _
                                    "  												  and ((a.c_telno = b.c_telno and a.c_telno > '') " & _
                                    "         												or (a.h_telno = b.h_telno and a.h_TELNO > '')) " & _
                                    "  												   and b.customer_id = c.customer_id) "

    Public sqlUpdateCustomerTelNo As String = " update t_customer_telno c " & sqlUpdateCustomerId

    Public sqlUpdateCustomerHistory As String = " update t_customer_history c " & sqlUpdateCustomerId

    Public sqlDropCustomerExcelBackup As String = " DROP TABLE `t_customer_excel_backup`; "

    Public sqlCreateCustomerExcelBackup As String = " CREATE TABLE `t_customer_excel_backup` ( " & _
                                                "   `COM_CD` varchar(4) NOT NULL, " & _
                                                "   `CUSTOMER_ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT, " & _
                                                "   `CUSTOMER_NM` varchar(20) DEFAULT NULL, " & _
                                                "   `C_TELNO` varchar(20) DEFAULT NULL, " & _
                                                "   `H_TELNO` varchar(20) DEFAULT NULL, " & _
                                                "   `FAX_NO` varchar(20) DEFAULT NULL, " & _
                                                "   `COMPANY` varchar(100) DEFAULT NULL, " & _
                                                "   `DEPARTMENT` varchar(100) DEFAULT NULL, " & _
                                                "   `JOB_TITLE` varchar(100) DEFAULT NULL, " & _
                                                "   `EMAIL` varchar(100) DEFAULT NULL, " & _
                                                "   `CUSTOMER_TYPE` varchar(4) DEFAULT NULL, " & _
                                                "   `TEMP_ID` varchar(40) DEFAULT NULL, " & _
                                                "   `WOO_NO` varchar(8) DEFAULT NULL, " & _
                                                "   `CUSTOMER_ADDR` varchar(120) DEFAULT NULL, " & _
                                                "   `CUSTOMER_ETC` varchar(100) DEFAULT NULL, " & _
                                                "   `C_TELNO1` varchar(20) DEFAULT NULL, " & _
                                                "   `H_TELNO1` varchar(20) DEFAULT NULL, " & _
                                                "   `TONG_USER` varchar(45) DEFAULT NULL, " & _
                                                "   `USER_DEF`  varchar(100) DEFAULT NULL, " & _
                                                "   `UPDATE_DATE` varchar(14) DEFAULT NULL, " & _
                                                "   PRIMARY KEY (`CUSTOMER_ID`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_BACKUP01` (`COM_CD`,`CUSTOMER_ID`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_BACKUP02` (`C_TELNO1`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_BACKUP03` (`H_TELNO1`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_BACKUP04` (`TEMP_ID`) " & _
                                                " ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=euckr; "

    Public sqlDropCustomerExcelTmp As String = " DROP TABLE `t_customer_excel_tmp`; "

    Public sqlCreateCustomerExcelTmp As String = " CREATE TABLE `t_customer_excel_tmp` ( " & _
                                                "   `COM_CD` varchar(4) NOT NULL, " & _
                                                "   `CUSTOMER_ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT, " & _
                                                "   `CUSTOMER_NM` varchar(20) DEFAULT NULL, " & _
                                                "   `C_TELNO` varchar(20) DEFAULT NULL, " & _
                                                "   `H_TELNO` varchar(20) DEFAULT NULL, " & _
                                                "   `FAX_NO` varchar(20) DEFAULT NULL, " & _
                                                "   `COMPANY` varchar(100) DEFAULT NULL, " & _
                                                "   `DEPARTMENT` varchar(100) DEFAULT NULL, " & _
                                                "   `JOB_TITLE` varchar(100) DEFAULT NULL, " & _
                                                "   `EMAIL` varchar(100) DEFAULT NULL, " & _
                                                "   `CUSTOMER_TYPE` varchar(4) DEFAULT NULL, " & _
                                                "   `TEMP_ID` varchar(40) DEFAULT NULL, " & _
                                                "   `WOO_NO` varchar(8) DEFAULT NULL, " & _
                                                "   `CUSTOMER_ADDR` varchar(120) DEFAULT NULL, " & _
                                                "   `CUSTOMER_ETC` varchar(100) DEFAULT NULL, " & _
                                                "   `C_TELNO1` varchar(20) DEFAULT NULL, " & _
                                                "   `H_TELNO1` varchar(20) DEFAULT NULL, " & _
                                                "   `TONG_USER` varchar(45) DEFAULT NULL, " & _
                                                "   `USER_DEF`  varchar(100) DEFAULT NULL, " & _
                                                "   `UPDATE_DATE` varchar(14) DEFAULT NULL, " & _
                                                "   `UPLOAD_RESULT` varchar(1) DEFAULT NULL, " & _
                                                "   PRIMARY KEY (`CUSTOMER_ID`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_TMP01` (`COM_CD`,`CUSTOMER_ID`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_TMP02` (`C_TELNO1`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_TMP03` (`H_TELNO1`), " & _
                                                "   KEY `idx_T_CUSTOMER_EXCEL_TMP04` (`TEMP_ID`) " & _
                                                " ) ENGINE=InnoDB AUTO_INCREMENT=1 DEFAULT CHARSET=euckr; "

    Public sqlDropCustomerHistoryExcelBackup As String = " DROP TABLE `t_customer_history_excel_backup`; "

    Public sqlCreateCustomerHistoryExcelBackup As String = "CREATE TABLE `t_customer_history_excel_backup` ( " & _
                                                        "   `COM_CD` varchar(4) NOT NULL, " & _
                                                        "   `CUSTOMER_ID` bigint(20) unsigned NOT NULL, " & _
                                                        "   `TOND_DD` varchar(8) NOT NULL, " & _
                                                        "   `TONG_TIME` varchar(6) NOT NULL, " & _
                                                        "   `TONG_USER` varchar(45) NOT NULL, " & _
                                                        "   `CALL_TYPE` varchar(1) DEFAULT NULL, " & _
                                                        "   `CONSULT_RESULT` varchar(4) DEFAULT NULL, " & _
                                                        "   `CONSULT_TYPE` varchar(4) DEFAULT NULL, " & _
                                                        "   `TONG_CONTENTS` varchar(100) DEFAULT NULL, " & _
                                                        "   `TONG_TELNO` varchar(20) DEFAULT NULL, " & _
                                                        "   `TELNO_TYPE` varchar(4) DEFAULT NULL, " & _
                                                        "   `CUSTOMER_NM` varchar(20) DEFAULT NULL, " & _
                                                        "   `BK_YN` varchar(1) DEFAULT NULL, " & _
                                                        "   `HANDLE_TYPE` varchar(1) DEFAULT '0', " & _
                                                        "   `CALL_BACK_YN` varchar(1) DEFAULT 'N', " & _
                                                        "   `CALL_BACK_RESULT` varchar(1) DEFAULT '2', " & _
                                                        "   `CALL_BACK_AGENT` varchar(50) DEFAULT NULL, " & _
                                                        "   `UPDATE_DATE` varchar(14) DEFAULT NULL, " & _
                                                        "   `PREV_TONG_DD` varchar(8) DEFAULT NULL, " & _
                                                        "   `PREV_TONG_TIME` varchar(6) DEFAULT NULL, " & _
                                                        "   `PREV_TONG_USER` varchar(45) DEFAULT NULL, " & _
                                                        "   `TRANS_YN` varchar(1) DEFAULT NULL, " & _
                                                        "   `TEMP_ID` varchar(40) DEFAULT NULL, " & _
                                                        "   PRIMARY KEY (`COM_CD`,`CUSTOMER_ID`,`TOND_DD`,`TONG_TIME`,`TONG_USER`), " & _
                                                        "   KEY `idx_T_CUSTOMER_HISTORY_EXCEL_BACKUP01` (`COM_CD`,`CUSTOMER_ID`,`TOND_DD`,`TONG_TIME`,`TONG_USER`), " & _
                                                        "   KEY `idx_T_CUSTOMER_HISTORY_EXCEL_BACKUP02` (`COM_CD`,`TOND_DD`,`TONG_TIME`,`TONG_USER`), " & _
                                                        "   KEY `idx_T_CUSTOMER_HISTORY_EXCEL_BACKUP03` (`CUSTOMER_NM`), " & _
                                                        "   KEY `idx_T_CUSTOMER_HISTORY_EXCEL_BACKUP04` (`PREV_TONG_DD`,`PREV_TONG_TIME`,`PREV_TONG_USER`,`TRANS_YN`) USING BTREE, " & _
                                                        "   KEY `idx_T_CUSTOMER_HISTORY_EXCEL_BACKUP05` (`TEMP_ID`) " & _
                                                        " ) ENGINE=InnoDB DEFAULT CHARSET=euckr; "

    Public sqlDropCustomerTelnoExcelBackup As String = " DROP TABLE `t_customer_telno_excel_backup`; "

    Public sqlCreateCustomerTelnoExcelBackup As String = "CREATE TABLE `t_customer_telno_excel_backup` ( " & _
                                                "   `COM_CD` varchar(4) NOT NULL, " & _
                                                "   `CUSTOMER_ID` bigint(20) unsigned NOT NULL, " & _
                                                "   `TELNO_TYPE` varchar(4) DEFAULT NULL, " & _
                                                "   `TELNO` varchar(20) NOT NULL, " & _
                                                "   PRIMARY KEY (`COM_CD`,`CUSTOMER_ID`,`TELNO`), " & _
                                                "   KEY `idxt_customer_telno_excel_backup01` (`COM_CD`,`CUSTOMER_ID`) " & _
                                                " ) ENGINE=InnoDB DEFAULT CHARSET=euckr; "

    Public sqlCustomerUpdateOld As String = "insert into t_customer (" & sqlCustomerFields & ")" & _
                                            "select " & sqlCustomerFields & " from t_customer_excel_backup a " & _
                                            "where not exists ( " & _
                                            "select 1  " & _
                                            "from t_customer_excel_tmp b " & _
                                            "where b.CUSTOMER_NM = a.CUSTOMER_NM " & _
                                            "  and b.C_TELNO = a.C_TELNO " & _
                                            "  and b.H_TELNO = a.H_TELNO " & _
                                            ") "

    Public sqlCustomerUpdateNew As String = " INSERT INTO T_CUSTOMER " & _
                                            " 			 (COM_CD,CUSTOMER_NM,   " & _
                                            "        COMPANY,DEPARTMENT,JOB_TITLE,   " & _
                                            "        C_TELNO,H_TELNO,FAX_NO,EMAIL,CUSTOMER_TYPE,WOO_NO,   " & _
                                            "        CUSTOMER_ADDR,CUSTOMER_ETC,C_TELNO1,H_TELNO1)   " & _
                                            " select COM_CD,CUSTOMER_NM,   " & _
                                            "        COMPANY,DEPARTMENT,JOB_TITLE,   " & _
                                            "        C_TELNO,H_TELNO,FAX_NO,EMAIL,if (ifnull(customer_type,'')='','03',customer_type),WOO_NO,   " & _
                                            "        CUSTOMER_ADDR,CUSTOMER_ETC,C_TELNO1,H_TELNO1 " & _
                                            "   from t_customer_excel_tmp " & _
                                            "  where upload_result = '0' "
End Module
