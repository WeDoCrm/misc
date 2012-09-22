Imports System.IO
Imports System.Xml
Imports System.Data
Imports System.Data.SqlClient

Public Class CDBMmanager

    Public Shared Event Var_Trans(ByVal tel_no As String, ByVal tong_date As String, ByVal tong_time As String, ByVal CALL_TYPE As String)
    Public Shared Event Var_Trans2(ByVal tel_no As String, ByVal tong_date As String, ByVal tong_time As String)
    Public Shared Event Var_Trans3(ByVal tel_no As String, _
                                   ByVal TONG_DT As String, _
                                   ByVal TONG_TM As String, _
                                   ByVal CALL_TYPE As String)

    Public Sub SetUserInfo(ByVal com_cd As String, ByVal user_id As String, ByVal pwd As String, ByVal socIP As String, ByVal socPort As String)
        'TEST용
        'Call SetUserInfo(com_cd, user_id, pwd, socIP, socPort, True)

        Call SetUserInfo(com_cd, user_id, pwd, socIP, socPort, False)

    End Sub


    Public Sub SetUserInfo(ByVal com_cd As String, ByVal user_id As String, ByVal pwd As String, ByVal socIP As String, ByVal socPort As String, ByVal isVBCall As Boolean)
        Try
            gsCOM_CD = ""
            gsUSER_ID = ""
            gsUSER_NM = ""
            gsUSR_HP = ""
            gsADDR1 = ""
            gsWOO_NO = ""
            gsH_TELNO = ""
            gsDEPART_CD = ""
            gsGRADE = ""
            gsEXTENSION_NO = ""
            gsWORK_TYPE = ""
            gsENTERING_DD = ""
            gsRETIRE_DD = ""
            gsUSER_EMAIL = ""
            gsDEPART_NM = ""
            gsUSER_PWD = ""
            gsWORK_AREA = ""
            gsCompany = ""
            gsTeam_CD = ""
            gsTeam_NM = ""

            gsCOM_CD = com_cd
            gsUSER_ID = user_id
            gsUSER_PWD = pwd

            gsSocketIP = socIP
            gsSocketPort = socPort

            Call XmlReadMode()          ' DB config 정보 파일 읽기

            Dim SQL As String = " SELECT IFNULL(COM_CD,''),IFNULL(COM_NM,'')  FROM t_company "

            Dim dt1 As DataTable = GetData_table1(gsConString, SQL)

            If dt1.Rows.Count > 0 Then
                Dim i As Integer
                For i = 0 To dt1.Rows.Count - 1
                    com_cd = dt1.Rows(i).Item(0).ToString
                Next
            End If

            dt1 = Nothing

            SQL = " SELECT IFNULL(COM_CD,''),IFNULL(USER_ID,''),IFNULL(USER_NM,''),IFNULL(USR_HP,''),IFNULL(ADDR1,''),IFNULL(WOO_NO,''),IFNULL(H_TELNO,''),IFNULL(DEPART_CD,'') "
            SQL = SQL & " ,IFNULL(GRADE,''),IFNULL(EXTENSION_NO,''),IFNULL(WORK_TYPE,''),IFNULL(ENTERING_DD,''),IFNULL(RETIRE_DD,''),IFNULL(USER_EMAIL,''),IFNULL(DEPART_NM,''),IFNULL(USER_PWD,'')"
            SQL = SQL & " ,IFNULL(WORK_AREA,''),IFNULL(TEAM_CD,''),IFNULL(TEAM_NM,'') "
            SQL = SQL & " ,( SELECT IFNULL(MAX(COM_NM),'') FROM t_company WHERE COM_CD = '" & com_cd & "') "


            SQL = SQL & " FROM T_USER X"
            SQL = SQL & " WHERE COM_CD = '" & com_cd & "'"
            SQL = SQL & " AND USER_ID = '" & user_id & "'"
            SQL = SQL & " AND USER_PWD = '" & pwd & "'"

            dt1 = GetData_table1(gsConString, SQL)

            Call WriteLog("SetUserInfo: " & "com_cd=" & com_cd & " user_id=" & user_id & " pwd=" & pwd & " count=" & dt1.Rows.Count)

            If dt1.Rows.Count > 0 Then

                Dim i As Integer
                Dim CntString As String = "0"

                For i = 0 To dt1.Rows.Count - 1

                    gsCOM_CD = dt1.Rows(i).Item(0).ToString
                    gsUSER_ID = dt1.Rows(i).Item(1).ToString
                    gsUSER_NM = dt1.Rows(i).Item(2).ToString
                    gsUSR_HP = dt1.Rows(i).Item(3).ToString
                    gsADDR1 = dt1.Rows(i).Item(4).ToString
                    gsWOO_NO = dt1.Rows(i).Item(5).ToString
                    gsH_TELNO = dt1.Rows(i).Item(6).ToString
                    gsDEPART_CD = dt1.Rows(i).Item(7).ToString
                    gsGRADE = dt1.Rows(i).Item(8).ToString
                    gsEXTENSION_NO = dt1.Rows(i).Item(9).ToString
                    gsWORK_TYPE = dt1.Rows(i).Item(10).ToString
                    gsENTERING_DD = dt1.Rows(i).Item(11).ToString
                    gsRETIRE_DD = dt1.Rows(i).Item(12).ToString
                    gsUSER_EMAIL = dt1.Rows(i).Item(13).ToString
                    gsDEPART_NM = dt1.Rows(i).Item(14).ToString
                    gsUSER_PWD = dt1.Rows(i).Item(15).ToString
                    gsWORK_AREA = dt1.Rows(i).Item(16).ToString


                    gsTeam_CD = dt1.Rows(i).Item(17).ToString
                    gsTeam_NM = dt1.Rows(i).Item(18).ToString
                    gsCompany = dt1.Rows(i).Item(19).ToString

                Next
            End If

            dt1 = Nothing

        Catch ex As Exception
            Call WriteLog(ex.ToString)
        End Try
    End Sub



    Public Sub New()
        ' This call is required by the Windows Form Designer.
        Elegant.Ui.RibbonLicenser.LicenseKey = "E644-DB48-BFFB-CA0C-53D2-4F3F-C938-C3EF"

        ' 이 호출은 Windows Form 디자이너에 필요합니다.
        InitializeComponent()

        ' InitializeComponent() 호출 뒤에 초기화 코드를 추가하십시오.

    End Sub
End Class
