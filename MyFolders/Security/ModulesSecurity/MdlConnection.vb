Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Text.RegularExpressions

Module MdlConnection

    Private _consum As New SqlClient.SqlConnection
    Public DelUsers As New SqlClient.SqlConnection
    Public ConUsers As New SqlClient.SqlConnection

    Public LocalConnection As Boolean = False
    Public ServerConnection As Boolean = False
    Public AuthenicationSQLServer As Boolean = False
    Public OnLine As Boolean = False

    Public MessageManager As Boolean = True


    Public LocalComp As String
    Public ServerName As String
    Public PORT As String
    Public userIDName As String
    Public BWS1 As String
    Public DBServer As String
    Public SourceServer As String

    Public USERNAME As String
    Public PASSWORD As String

    Public UserMacAddress As String = ""
    '----------------------------------------------------------------
    Public tmpStr As String
    Public tmpStr1 As String
    Public tmpV As String
    Dim FsLocal As IO.FileStream
    Dim SrLocal As IO.StreamReader

    Public Property Consum As SqlConnection
        Get
            Return _consum
        End Get
        Set(value As SqlConnection)
            _consum = value
        End Set
    End Property

    Public Function EncryptConnectionString(ByVal connectionString As String) As String
        Dim b As [Byte]() = System.Text.ASCIIEncoding.ASCII.GetBytes(connectionString)
        Dim encryptedConnectionString As String = Convert.ToBase64String(b)
        Return encryptedConnectionString
    End Function

    Public Function DecryptedConnectionString(_text_to_decrypt As String) As String
        If _text_to_decrypt Is Nothing Then
            Throw New ArgumentNullException(NameOf(_text_to_decrypt))
        End If

        Dim b As Byte() = Convert.FromBase64String(tmpStr.ToString)
        DecryptedConnectionString = System.Text.ASCIIEncoding.ASCII.GetString(b)
        Return DecryptedConnectionString
    End Function

    Public Sub GeneralConnection()
        Call GetConnection()
        If LocalConnection = True Then
            Call ConnectToLocalConnection()
            'MsgBox("-URL- OfLine!")
            OnLine = False
        ElseIf ServerConnection = True Then
            Call ConnectToServerConnection()
            'MsgBox("-URL- OnLine!")
            OnLine = True
        End If


    End Sub

    Private Function UrlIsValid(ByVal url As String) As Boolean
        If url.ToLower().StartsWith("www.") Then url = "http://" & url
        Dim web_response As HttpWebResponse = Nothing
        Try
            Dim web_request As HttpWebRequest =
                HttpWebRequest.Create(url)
            web_response = DirectCast(web_request.GetResponse(), HttpWebResponse)
            Return True
        Catch ex As Exception
            Return False
        Finally
            If web_response IsNot Nothing Then web_response.Close()
        End Try
    End Function

    Public Function TxtURL() As String
        Try
            Dim pattern As String
            pattern = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
            If IsConnectedToInternet() = True Then
                TxtURL = mykey.GetValue("URL", URL).ToString.Trim
                Dim Request As HttpWebRequest = CType(WebRequest.Create(TxtURL.ToString.Trim), HttpWebRequest)
                Dim Reader As New StreamReader(Request.GetResponse.GetResponseStream, System.Text.Encoding.UTF8)
                tmpStr1 = Reader.ReadToEnd()
                If Regex.IsMatch(TxtURL.ToString.Trim, pattern) Then
                    If UrlIsValid(TxtURL.ToString.Trim) Then
                        tmpStr1 = Reader.ReadToEnd()
                        Reader.Dispose()
                        'MsgBox(tmpStr1.ToString)
                    Else
                        MsgBox("-URL- غير صالح!")
                        tstURL = True
                        Dim f As New FrmOptions1
                        f.ShowDialog()
1:                      tmpStr1 = mykey.GetValue("tmpStr", "").ToString.Trim()
                    End If
                Else
                    MsgBox("-URL- غير صالح!")
                End If
            Else
                If FrmLOGIN.Visible = True Then
                    MsgBox("السيرفر غير متوفر حاليا. سيتم الاتصال في الإعدادات السابقة", 64 + 524288, "سيرفر قواعد البيانات")
                End If
            End If
        Catch ex As Exception
            'MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "(TxtURL)  خادم شبكة")
            GoTo 1

        Finally

        End Try
        Return tmpStr1
    End Function

    Public Function TxtURL1() As String
        On Error Resume Next
        If IsConnectedToInternet() = True Then
            TxtURL1 = mykey.GetValue("URL1", "")
            Dim Request As HttpWebRequest = WebRequest.Create(TxtURL1)
            Dim Reader As New StreamReader(Request.GetResponse.GetResponseStream, System.Text.Encoding.UTF8)
            tmpV = Reader.ReadToEnd().ToString.Trim
            Reader.Dispose()
            'MsgBox("السيرفر  متوفرل ", 64 + 524288, "سيرفر قواعد البيانات")
        Else
            'MsgBox("السيرفر  متوفر  سيتم الاتصال ", 64 + 524288, "سيرفر قواعد البيانات")
        End If
    End Function

    Public Function IsConnectedToInternet() As Boolean
        If System.Environment.OSVersion.Version.Major >= 6 Then
            'Vista and Up
            'Dim Networks As New NETWORKLIST.NetworkListManager
            Dim Networks = Activator.CreateInstance(Type.GetTypeFromCLSID(New Guid("{DCB00C01-570F-4A9B-8D69-199FDBA5723B}")))
            If Networks.IsConnectedToInternet Then
                Return True
            Else
                Return False
            End If
        Else
            Dim flags As UInteger = 0
            If InternetGetConnectedState(flags, 0) Then
                Return True
            Else
                Return False
            End If
        End If
        'Return True
    End Function

    Public Declare Function InternetGetConnectedState Lib "wininet.dll" (ByVal Flag As UInteger, ByVal Reserved As UInteger) As Boolean

    Public Function CheckAddress(ByVal URL As String) As Boolean
        Try
            Dim request As WebRequest = WebRequest.Create(URL)
            Dim response As WebResponse = request.GetResponse()
        Catch ex As Exception
            Return False
        End Try
        Return True
    End Function

    Private Function SourceFileExists() As Boolean ' وظيفة للبحث عن الملف
        If Not IO.File.Exists(Application.StartupPath & "\" & "ConStr.XML") Then
            MessageBox.Show("ملف المصدر غير موجود !")
        Else
            SourceFileExists = True
        End If
        Return SourceFileExists
    End Function

    Public Function URL_F() As String
        'On Error Resume Next
        Try
            Dim pattern As String
            Dim fs As IO.FileStream
            Dim sr As IO.StreamReader
            pattern = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
            fs = New IO.FileStream(Application.StartupPath & "/URL.txt", IO.FileMode.Open)
            sr = New IO.StreamReader(fs)
            URL = Trim(sr.ReadToEnd.ToString())
            fs.Close()
            sr.Close()
            If IsConnectedToInternet() = True Then
                If Regex.IsMatch(URL.ToString.Trim, pattern) Then
                    If UrlIsValid(URL.ToString.Trim) Then
                        Dim Request As HttpWebRequest = WebRequest.Create(URL.ToString.Trim)
                        Dim Reader As New StreamReader(Request.GetResponse.GetResponseStream, System.Text.Encoding.UTF8)
                        tmpStr1 = Reader.ReadToEnd()
                        'MessageBox.Show(tmpStr1.ToString)
                        Reader.Dispose()
                    Else
                        'MessageBox.Show("غير صالح (URL_F..)رابط")
                        Call TxtURL()
                    End If
                Else
                    'MessageBox.Show("غير صالح (URL..)رابط")
                    Call TxtURL()
                End If
                '==============================================================
            Else
                tmpStr1 = mykey.GetValue("tmpStr", "").ToString.Trim()
                'MsgBox(tmpStr1.ToString)
                If FrmLOGIN.Visible = True Then
                    MsgBox("السيرفر غير متوفر حاليا. سيتم الاتصال في الإعدادات السابقة", 64 + 524288, "سيرفر قواعد البيانات")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "(CC-JO)  TxtURL")
        End Try
        Return tmpStr1
    End Function

    Public Function Viild() As Boolean
        Call URL_F()
        tmpStr = mykey.GetValue("tmpStr", "").ToString.Trim()
        If tmpStr1.ToString = tmpStr.ToString.Trim Then
            Viild = True
            'MessageBox.Show("TxtURL- viild")
        Else
            'MessageBox.Show("(URLI...1)- viild")
            Call TxtURL()
            Viild = False
        End If
    End Function

    Sub Mainpath()
        'Dim serviceNew As New localhost.Service1
        'MsgBox(serviceNew.HelloWorld())
        Call SourceFileExists()
        Call Viild()
        Dim path As String = Application.StartupPath & "\" & "ConStr.XML"
        If SourceFileExists() = True Then
            If File.ReadAllText(path).Length <> 0 Then 'فارغ الاتصال ملف
                If Viild() = True Then
                    Dim fs1 As FileStream = File.Create(path)
                    Dim info1 As Byte() = New UTF8Encoding(True).GetBytes(tmpStr1.ToString.Trim)
                    fs1.Write(info1, 0, info1.Length)
                    fs1.Close()
                    'MessageBox.Show("0-0 !")
                ElseIf Viild() = False Then
                    tmpStr1 = mykey.GetValue("tmpStr", "").ToString.Trim()
                    Dim fs2 As FileStream = File.Create(path)
                    Dim info2 As Byte() = New UTF8Encoding(True).GetBytes(tmpStr.ToString.Trim)
                    fs2.Write(info2, 0, info2.Length)
                    fs2.Close()
                    'MessageBox.Show("2-0 !")
                End If
            ElseIf File.ReadAllText(path).Length = 0 Then
                If Viild() = True Then
                    Dim fs4 As FileStream = File.Create(path)
                    Dim info4 As Byte() = New UTF8Encoding(True).GetBytes(mykey.GetValue("tmpStr", "").ToString.Trim)
                    fs4.Write(info4, 0, info4.Length)
                    fs4.Close()
                    'MessageBox.Show("1-1 !")
                ElseIf Viild() = False Then
                    If Viild() = True Then
                        Dim fs2 As FileStream = File.Create(path)
                        Dim info2 As Byte() = New UTF8Encoding(True).GetBytes(tmpStr1.ToString.Trim)
                        fs2.Write(info2, 0, info2.Length)
                        fs2.Close()
                        'MessageBox.Show("2-1 !")
                    Else
                        Try
                            Dim pattern As String
                            Dim TxtURL As String
                            pattern = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
                            If IsConnectedToInternet() = True Then
                                TxtURL = mykey.GetValue("URL", "").ToString.Trim()
                                Dim Request As HttpWebRequest = WebRequest.Create(TxtURL.ToString.Trim)
                                Dim Reader As New StreamReader(Request.GetResponse.GetResponseStream, System.Text.Encoding.UTF8)
                                'tmpStr1 = Reader.ReadToEnd()
                                If Regex.IsMatch(TxtURL.ToString.Trim, pattern) Then
                                    If UrlIsValid(TxtURL.ToString.Trim) Then
                                        tmpStr = Reader.ReadToEnd()
                                        Reader.Dispose()
                                        'MessageBox.Show(tmpStr)
                                    Else
1:                                      tmpStr1 = mykey.GetValue("tmpStr", "").ToString.Trim()
                                    End If
                                Else
                                    MsgBox("-URL- غير صالح!")
                                End If
                            Else
                                If FrmLOGIN.Visible = True Then
                                    MsgBox("السيرفر غير متوفر حاليا. سيتم الاتصال في الإعدادات السابقة", 64 + 524288, "سيرفر قواعد البيانات")
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "(TxtURL)  خادم شبكة")
                            GoTo 1
                        End Try
                        tmpStr1 = mykey.GetValue("tmpStr", "").ToString.Trim()
                        Dim fs2 As FileStream = File.Create(path)
                        Dim info2 As Byte() = New UTF8Encoding(True).GetBytes(tmpStr.ToString.Trim)
                        fs2.Write(info2, 0, info2.Length)
                        fs2.Close()
                        'MessageBox.Show("2-2 !")
                    End If
                Else
                    'Dim fs4 As FileStream = File.Create(path)
                    'Dim info4 As Byte() = New UTF8Encoding(True).GetBytes(mykey.GetValue("tmpStr", "").ToString.Trim)
                    'fs4.Write(info4, 0, info4.Length)
                    'fs4.Close()
                    '
                End If
            End If
        Else
            Dim fs4 As FileStream = File.Create(path)
            Dim info4 As Byte() = New UTF8Encoding(True).GetBytes(mykey.GetValue("tmpStr", "").ToString.Trim)
            fs4.Write(info4, 0, info4.Length)
            fs4.Close()
            'MessageBox.Show("3-0 !")
        End If
    End Sub

    Public Sub GetConnectionLocalComputer()

        Dim Lines() As String
        FsLocal = New IO.FileStream(Application.StartupPath & "\ConStr.XML", IO.FileMode.Open)
        SrLocal = New IO.StreamReader(FsLocal)
        Dim ConStr As String = SrLocal.ReadToEnd
        SrLocal.Close()
        FsLocal.Close()
        Dim DecryptedConnection As String
        Dim b As Byte() = Convert.FromBase64String(ConStr.ToString)
        DecryptedConnection = System.Text.ASCIIEncoding.ASCII.GetString(b)
        Lines = DecryptedConnection.ToString.Split(vbCrLf)
        Dim su1 As Integer = Lines(6).Length - 8
        Dim su2 As Integer = Lines(7).Length - 8
        Dim su3 As Integer = Lines(8).Length - 2
        If Lines(0) = "" Then
            LocalConnection = True
        Else
            LocalConnection = Convert.ToBoolean(Lines(0))
        End If
        If Lines(1) = "" Then
            ServerConnection = False
        Else
            ServerConnection = Convert.ToBoolean(Lines(1))
        End If
        If Lines(2) = "" Then
            AuthenicationSQLServer = False
        Else
            AuthenicationSQLServer = Convert.ToBoolean(Lines(2))
        End If
        If AuthenicationSQLServer = True Then
            MdlConnection.LocalComp = Lines(3)
            MdlConnection.userIDName = Lines(6).Substring(0, su1).Trim
            MdlConnection.BWS1 = Lines(7).Substring(0, su2).Trim
            MdlConnection.DBServer = Lines(8).Substring(0, su3).Trim
            MdlConnection.ServerName = LocalComp
        Else
            MdlConnection.LocalComp = Lines(3)
            MdlConnection.DBServer = Lines(8).Substring(0, su3).Trim
            MdlConnection.ServerName = LocalComp
        End If

    End Sub

    Public Sub GetConnection()
        Try
            If tstURL = True Then
                Exit Try
            End If
            Dim fs As IO.FileStream
            Dim sr As IO.StreamReader
            Dim Lines() As String
            '=====================================================================
            If IsConnectedToInternet() = True Then
                OnLine = True
            Else
                OnLine = False
                'MessageBox.Show("الاتصال بالانترنت غير متوفر !")
            End If
            MdlConnection.Mainpath()
            fs = New IO.FileStream(Application.StartupPath & "\ConStr.XML", IO.FileMode.Open)
            sr = New IO.StreamReader(fs)
            Dim ConStr As String = sr.ReadToEnd
            sr.Close()
            fs.Close()
            Dim DecryptedConnection As String
            Dim b As Byte() = Convert.FromBase64String(ConStr.ToString)
            DecryptedConnection = System.Text.ASCIIEncoding.ASCII.GetString(b)
            Lines = DecryptedConnection.ToString.Split(vbCrLf)
            Dim su As Integer = Lines(4).Length - 6
            Dim su1 As Integer = Lines(8).Length - 2
            Dim su2 As Integer = Lines(6).Length - 8
            Dim su3 As Integer = Lines(7).Length - 8
            If Lines(0) = "" Then
                LocalConnection = True
            Else
                LocalConnection = Convert.ToBoolean(Lines(0))
            End If
            If Lines(1) = "" Then
                ServerConnection = False
            Else
                ServerConnection = Convert.ToBoolean(Lines(1))
            End If
            If Lines(2) = "" Then
                AuthenicationSQLServer = False
            Else
                AuthenicationSQLServer = Convert.ToBoolean(Lines(2))
            End If
            If ServerConnection = True Then
                MdlConnection.LocalComp = Lines(3).Trim
                MdlConnection.SourceServer = Lines(4).Substring(0, su).Trim
                MdlConnection.PORT = Lines(5).Trim
                MdlConnection.userIDName = Lines(6).Substring(0, su2).Trim
                MdlConnection.BWS1 = Lines(7).Substring(0, su3).Trim
                MdlConnection.DBServer = Lines(8).Substring(0, su1).Trim
                MdlConnection.ServerName = SourceServer
            Else
                GetConnectionLocalComputer()
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "(CC-JO) خادم شبكة")
        End Try

    End Sub

    Public Sub ConnectToLocalConnection()
        Try
            'Dim s As String = "192.168.2.137,1477"
            'Dim db As String = "DB_A3F994_co"
            'Data Source = .\ SQLExpress;Initial Catalog=CC_JO;Integrated Security=True

            'Consum.ConnectionString = "Data Source=" + s + "," + PORT + ";Initial Catalog=" + db + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            'Consum.ConnectionString =Data Source="192.168.2.137,1477";Initial Catalog"DB_A3F994_co";User ID=sa;Password="2710/m"
            'Consum.ConnectionString = "Data Source="192.168.2.137, 1477" ;Initial Catalog=" + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            If AuthenicationSQLServer = True Then
                Consum.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ConUsers.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
                DelUsers.ConnectionString = "Data Source=" + ServerName + ";Initial Catalog=" + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            Else
                Consum.ConnectionString = "Data Source =" + ServerName + ";Initial Catalog=" + DBServer + ";Integrated Security=True"
                ConUsers.ConnectionString = "Data Source =" + ServerName + ";Initial Catalog=" + DBServer + ";Integrated Security=True"
                DelUsers.ConnectionString = "Data Source =" + ServerName + ";Initial Catalog=" + DBServer + ";Integrated Security=True"
            End If

            Return
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "كمبوتر المحلي ")
        End Try
    End Sub

    Public Sub ConnectToServerConnection()
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each nic As NetworkInterface In adapters
                Dim type As NetworkInterfaceType = nic.NetworkInterfaceType
                If type <> NetworkInterfaceType.Loopback AndAlso type <> NetworkInterfaceType.Tunnel AndAlso type <> NetworkInterfaceType.Unknown Then
                    UserMacAddress &= nic.GetPhysicalAddress().ToString.Trim()
                End If
            Next
            'If UserMacAddress.Trim = "" Then
            '    MsgBox("الرجاءالاتصال بإدارة ومحاسبة الجمعيات التعاونية", 16, "تنبيه بوجود خطا ما")
            '    End
            'End If
            Dim Site As Net.IPHostEntry = Net.Dns.GetHostEntry("www.msn.com")
            TestNet = True
            Consum.ConnectionString = "Data Source=" + ServerName + "," + PORT + ";Initial Catalog= " + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            ConUsers.ConnectionString = "Data Source=" + ServerName + "," + PORT + ";Initial Catalog= " + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            DelUsers.ConnectionString = "Data Source=" + ServerName + "," + PORT + ";Initial Catalog= " + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            Return
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "اسم السيرفر")
        End Try
    End Sub

    Public Sub ConnectDB()
        Try
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            Else
                Consum.Open()
            End If
        Catch ex As Exception
            MsgBox("...تعذر الاتصال بقاعدة البيانات ")
        End Try
    End Sub

    Public Sub CloseDB()
        Try
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
        Catch ex As Exception
            MsgBox("...تعذر قطع الاتصال بقاعدة البيانات ")
        End Try
    End Sub


    Public Sub CloseConUsers()
        Try
            If ConUsers.State = ConnectionState.Open Then
                ConUsers.Close()
            End If
        Catch ex As Exception
            MsgBox("(1)تعذر قطع الاتصال بقاعدة البيانات")
        End Try
    End Sub

    Public Sub MangUsers()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim ds As New DataSet
            Dim Users1 As New SqlCommand("Select ID ,UserName  ,BlockUser,LockAddRow ,LockDelete,LockSave  ,LockUpdate,Printpreview, TransferofAccounts ,InternalAuditor ,CollaborationManager ,HeadofAuditingDepartment,ExternalAuditor ,RAdmin1 from Users", Consum)
            Dim Adp1 As New SqlClient.SqlDataAdapter(Users1)
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp1.Fill(ds, "Users")
            If Consum.State = ConnectionState.Open Then Consum.Close()

            AuditorClose()
            CollaborationManagerClose()
            HeadOFExternalAccountsDepartmentClose()
            ExternalAuditorClose()

            FiscalYear()
            LoadFiscalYear()
            Inprogress()
            Complete()

            If ds.Tables(0).Rows.Count > 0 Then
                If ds.Tables("Users").Compute("Count(UserName)", "UserName Like '" & USERNAME & "' and  Printpreview=1").ToString > 0 Then
                    LockPrint = True
                Else
                    LockPrint = False
                End If
                If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  InternalAuditor=1").ToString > 0 Then
                    InternalAuditor = True
                Else
                    InternalAuditor = False
                End If

                If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  CollaborationManager=1").ToString > 0 Then
                    Managers = True
                Else
                    Managers = False
                End If
                If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  HeadofAuditingDepartment=1").ToString > 0 Then
                    HeadofAuditingDepartment = True
                Else
                    HeadofAuditingDepartment = False
                End If
                If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  ExternalAuditor=1").ToString > 0 Then
                    ExternalAuditor = True
                Else
                    ExternalAuditor = False
                End If
                If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  RAdmin1=1").ToString > 0 Then
                    RAdmin = True
                Else
                    RAdmin = False
                End If
            Else
                MsgBox("لا يوجد مستخدمين", 64 + 524288, "صلاحيات المستخدمين")
            End If


            If LoadFiscalYear() = False Then
                LockAddRow = False
                LockSave = False
                MessageBox.Show("لا يوجد السنة المالية لهذه الجمعية " & ControlChars.CrLf &
                 "1) يجب فتح سنة مالية جديدة" & ControlChars.CrLf, "السنة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                If ExternalAuditorClose() = False And HeadOFExternalAccountsDepartmentClose() = True Then
                    MessageHeadOFExternalAccountsDepartment()
                ElseIf ExternalAuditorClose() = False And CollaborationManagerClose() = True Then
                    MessageCollaborationManager()
                ElseIf ExternalAuditorClose() = False And AuditorClose() = True Then
                    MessageAuditor()
                Else
                    If Inprogress() = False Then
                        MessageManager = True
                        If AuditorClose() = True Then
                            LockAddRow = False
                            LockSave = False
                            LockUpdate = False
                            LockDelete = False
                            If Complete() = True Then
                                MessageComplete()
                                Exit Sub
                            End If
                        End If
                        If ds.Tables(0).Rows.Count > 0 Then
                            If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  LockAddRow =1").ToString > 0 Then
                                LockAddRow = True
                            Else
                                LockAddRow = False
                            End If
                            If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  LockSave =1").ToString > 0 Then
                                LockSave = True
                            Else
                                LockSave = False
                            End If
                            If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  LockUpdate=1").ToString > 0 Then
                                LockUpdate = True
                            Else
                                LockUpdate = False
                            End If
                            If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  LockDelete=1").ToString > 0 Then
                                LockDelete = True
                            Else
                                LockDelete = False
                            End If
                            If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  TransferofAccounts=1").ToString > 0 Then
                                TransferofAccounts = True
                            Else
                                TransferofAccounts = False
                            End If
                            If ds.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  Printpreview=1").ToString > 0 Then
                                LockPrint = True
                            Else
                                LockPrint = False
                            End If
                        End If

                    ElseIf Inprogress() = True Then
                        MessageInprogress()
                        Exit Sub
                    End If
                End If
            End If

            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch Ex As Exception
            MsgBox(" يوجد مشكلة في اتصال الصلاحيات _ نوصي بشدة اعادة تشغيل النظام", 64 + 524288, "صلاحيات المستخدمين")
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Finally
            If Consum.State = ConnectionState.Open Then Consum.Close()
        End Try
    End Sub

    Private Sub MessageInprogress()
        If MessageManager = True Then
            MessageBox.Show("السنة مالية الحالية" & " " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")" & " " & "قيد المصادقة عليها" & ControlChars.CrLf &
                             "1) لا يجب اضافة او تعديل بيانات حتى يتم الانتهاء من المصادقة عليها" & ControlChars.CrLf &
                             "2) بعد الانتهاء من مصدقة الميزانية يجب تكوين قيد ختـامـي من شاشة الحسابات الختامية" & ControlChars.CrLf &
                             "3) يجب فتح سنة مالية جديدة", "الميزانية العامة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LockAddRow = False
        LockSave = False
        LockUpdate = False
        LockDelete = False
    End Sub

    Private Sub MessageComplete()
        If MessageManager = True Then
            MessageBox.Show("تم الانتهاء من الميزانية العامة لعام " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")" & "المنتهي" & ControlChars.CrLf &
                     "1) يجب فتح سنة مالية جديدة" & ControlChars.CrLf &
                     "2) تكوين قيد ختـامـي من شاشة الحسابات الختامية", "الميزانية العامة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LockAddRow = False
        LockSave = False
        LockUpdate = False
        LockDelete = False
    End Sub

    Private Sub MessageHeadOFExternalAccountsDepartment()
        If MessageManager = True Then
            MessageBox.Show("السنة مالية الحالية" & " " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")" & " " & "قيد المصادقة عليها" & ControlChars.CrLf &
                         "1) لا يجب اضافة او تعديل بيانات حتى يتم الانتهاء من المصادقة عليها" & ControlChars.CrLf &
                         "2) بعد الانتهاء من مصدقة الميزانية يجب تكوين قيد ختـامـي من شاشة الحسابات الختامية" & ControlChars.CrLf &
                         "3) يجب فتح سنة مالية جديدة" & ControlChars.CrLf &
                         "4) الحالة : موجدة عند رئيس قسم الحسابات الخارجية", "الميزانية العامة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LockAddRow = False
        LockSave = False
        LockUpdate = False
        LockDelete = False
    End Sub

    Private Sub MessageCollaborationManager()
        If MessageManager = True Then
            MessageBox.Show("السنة مالية الحالية" & " " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")" & " " & "قيد المصادقة عليها" & ControlChars.CrLf &
                         "1) لا يجب اضافة او تعديل بيانات حتى يتم الانتهاء من المصادقة عليها" & ControlChars.CrLf &
                         "2) بعد الانتهاء من مصدقة الميزانية يجب تكوين قيد ختـامـي من شاشة الحسابات الختامية" & ControlChars.CrLf &
                         "3) يجب فتح سنة مالية جديدة" & ControlChars.CrLf &
                         "4) الحالة : موجدة عند مدير التعاون", "الميزانية العامة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LockAddRow = False
        LockSave = False
        LockUpdate = False
        LockDelete = False
    End Sub

    Private Sub MessageAuditor()
        If MessageManager = True Then
            MessageBox.Show("السنة مالية الحالية" & " " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")" & " " & "قيد المصادقة عليها" & ControlChars.CrLf &
                     "1) لا يجب اضافة او تعديل بيانات حتى يتم الانتهاء من المصادقة عليها" & ControlChars.CrLf &
                     "2) بعد الانتهاء من مصدقة الميزانية يجب تكوين قيد ختـامـي من شاشة الحسابات الختامية" & ControlChars.CrLf &
                     "3) يجب فتح سنة مالية جديدة" & ControlChars.CrLf &
                     "4) الحالة : موجدة عند مدقق الحسابات", "الميزانية العامة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
        LockAddRow = False
        LockSave = False
        LockUpdate = False
        LockDelete = False
    End Sub

    ' مدقق الحسابات
    Public Function AuditorClose() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim FinancialList4 As SqlClient.SqlDataAdapter
            Dim strSQL3 As New SqlCommand("SELECT  FL6  FROM FinancialList  WHERE CUser ='" & CUser & "'  and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and FL6 ='" & True & "'", Consum)
            Dim ds3 As New DataSet
            FinancialList4 = New SqlClient.SqlDataAdapter(strSQL3)
            ds3.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FinancialList4.Fill(ds3, "FinancialList")
            If ds3.Tables(0).Rows.Count > 0 Then AuditorClose = ds3.Tables(0).Rows(0).Item(0)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return AuditorClose
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorAuditorClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    ' مدير التعاون

    Public Function CollaborationManagerClose() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim FinancialList1 As SqlClient.SqlDataAdapter
            Dim strSQL As New SqlCommand("SELECT  FL7  FROM FinancialList  WHERE CUser ='" & CUser & "' and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'   and FL7 ='" & True & "'", Consum)
            Dim ds As New DataSet
            FinancialList1 = New SqlClient.SqlDataAdapter(strSQL)
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FinancialList1.Fill(ds, "FinancialList")
            If ds.Tables(0).Rows.Count > 0 Then CollaborationManagerClose = ds.Tables(0).Rows(0).Item(0)
            FinancialList1.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return CollaborationManagerClose
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCollaborationManagerClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    ' رئيس قسم الحسابات الخارجية

    Public Function HeadOFExternalAccountsDepartmentClose() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim FinancialList2 As SqlClient.SqlDataAdapter
            Dim strSQL1 As New SqlCommand("SELECT   FL8  FROM FinancialList  WHERE CUser ='" & CUser & "' and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'   and FL8 ='" & True & "'", Consum)
            Dim ds1 As New DataSet
            FinancialList2 = New SqlClient.SqlDataAdapter(strSQL1)
            ds1.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FinancialList2.Fill(ds1, "FinancialList")
            If ds1.Tables(0).Rows.Count > 0 Then HeadOFExternalAccountsDepartmentClose = ds1.Tables(0).Rows(0).Item(0)
            FinancialList2.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return HeadOFExternalAccountsDepartmentClose
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorHeadOFExternalAccountsDepartmentClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function
    ' مدقق الحسابات الخارجية

    Public Function ExternalAuditorClose() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim FinancialList3 As SqlClient.SqlDataAdapter
            Dim strSQL2 As New SqlCommand("SELECT   FL9  FROM FinancialList  WHERE CUser ='" & CUser & "'  and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and FL9 ='" & True & "'", Consum)
            Dim ds2 As New DataSet
            FinancialList3 = New SqlClient.SqlDataAdapter(strSQL2)
            ds2.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FinancialList3.Fill(ds2, "FinancialList")
            If ds2.Tables(0).Rows.Count > 0 Then ExternalAuditorClose = ds2.Tables(0).Rows(0).Item(0)
            FinancialList3.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return ExternalAuditorClose
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorExternalAuditorClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Public Function LoadFiscalYear() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim Fy1 As SqlClient.SqlDataAdapter
            Dim strSQLFy1 As New SqlCommand("SELECT  YE1  FROM FiscalYear WHERE CUser ='" & CUser & "' and YE1 ='" & True & "'", Consum)
            Dim dsFy1 As New DataSet
            Fy1 = New SqlClient.SqlDataAdapter(strSQLFy1)
            dsFy1.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Fy1.Fill(dsFy1, "FiscalYear")
            If dsFy1.Tables(0).Rows.Count > 0 Then
                LoadFiscalYear = True
            Else
                LoadFiscalYear = False
            End If
            Fy1.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return LoadFiscalYear
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorLoadFiscalYear", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Public Function FiscalYear() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim FL2 As SqlClient.SqlDataAdapter
            Dim strSQLFL2 As New SqlCommand("SELECT IDFL  FROM FinancialList WHERE CUser ='" & ModuleGeneral.CUser & "' and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and FL6 ='" & False & "'", Consum)
            Dim dsFL2 As New DataSet
            FL2 = New SqlClient.SqlDataAdapter(strSQLFL2)
            dsFL2.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FL2.Fill(dsFL2)
            If dsFL2.Tables(0).Rows.Count > 0 Then
                FiscalYear = True
            Else
                FiscalYear = False
            End If
            FL2.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return FiscalYear
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorFiscalYear", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Return False
        End Try
    End Function

    'قيد العمل محاسب
    Public Function Inprogress() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim X As Integer = 1
            Dim XX As Integer = 4
            '>= 1 AndAlso XX <= 5
            Dim FL1 As SqlClient.SqlDataAdapter
            Dim strSQLFL1 As New SqlCommand("SELECT IDFL  FROM FinancialList WHERE CUser ='" & CUser & "' and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and FL5 ='" & True & "' and FL10 BETWEEN'" & X & "' And '" & XX & "'  ", Consum)
            Dim dsFL1 As New DataSet
            FL1 = New SqlClient.SqlDataAdapter(strSQLFL1)
            dsFL1.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FL1.Fill(dsFL1)
            If dsFL1.Tables(0).Rows.Count > 0 Then
                Inprogress = True
            Else
                Inprogress = False
            End If
            FL1.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return Inprogress
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorInprogress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function


    ' مكتمل
    Public Function Complete() As Boolean
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim FL3 As SqlClient.SqlDataAdapter
            Dim strSQLFL3 As New SqlCommand("SELECT IDFL   FROM FinancialList WHERE CUser ='" & ModuleGeneral.CUser & "' and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and FL5 ='" & True & "' and FL6 ='" & True & "' and FL7 ='" & True & "' and FL8 ='" & True & "' and FL9 ='" & True & "'", Consum)
            Dim dsFL3 As New DataSet
            FL3 = New SqlClient.SqlDataAdapter(strSQLFL3)
            dsFL3.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            FL3.Fill(dsFL3)
            If dsFL3.Tables(0).Rows.Count > 0 Then
                Complete = True

            Else
                Complete = False
            End If
            FL3.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Return Complete
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComplete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

End Module
