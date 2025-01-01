Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Text.RegularExpressions

Module MdlConnection

    Private _consum As New SqlConnection
    Public DelUsers As New SqlConnection
    Public ConUsers As New SqlConnection

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
    ReadOnly FsLocal As FileStream
    ReadOnly SrLocal As StreamReader
    Private ReadOnly ds As New DataSet
    Public Property Consum As SqlConnection
        Get
            Return _consum
        End Get
        Set(value As SqlConnection)
            _consum = value
        End Set
    End Property

    Public Function EncryptConnectionString(connectionString As String) As String
        Dim b As Byte() = Encoding.ASCII.GetBytes(connectionString)
        Return Convert.ToBase64String(b)
    End Function

    Public Function DecryptedConnectionString(textToDecrypt As String) As String
        If textToDecrypt Is Nothing Then
            Throw New ArgumentNullException(NameOf(textToDecrypt))
        End If

        Dim b As Byte() = Convert.FromBase64String(textToDecrypt)
        Return Encoding.ASCII.GetString(b)
    End Function

    Public Sub GeneralConnection()
        GetConnection()
        If LocalConnection Then
            ConnectToLocalConnection()
            OnLine = False
        ElseIf ServerConnection Then
            ConnectToServerConnection()
            OnLine = True
        End If
    End Sub

    Private Function UrlIsValid(url As String) As Boolean
        If url.ToLower().StartsWith("www.") Then url = "http://" & url
        Try
            Dim webRequest As HttpWebRequest = HttpWebRequest.Create(url)
            Using webResponse As HttpWebResponse = DirectCast(webRequest.GetResponse(), HttpWebResponse)
                Return True
            End Using
        Catch ex As Exception
            Return False
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
        If IsConnectedToInternet() Then
            Dim url As String = mykey.GetValue("URL1", "").ToString().Trim()
            Dim request As HttpWebRequest = CType(WebRequest.Create(url), HttpWebRequest)
            Using reader As New StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8)
                tmpV = reader.ReadToEnd().ToString().Trim()
            End Using
        End If
        Return tmpV
    End Function

    Public Function IsConnectedToInternet() As Boolean
        If Environment.OSVersion.Version.Major >= 6 Then
            Dim networks = Activator.CreateInstance(Type.GetTypeFromCLSID(New Guid("{DCB00C01-570F-4A9B-8D69-199FDBA5723B}")))
            Return networks.IsConnectedToInternet
        Else
            Dim flags As UInteger = 0
            Return InternetGetConnectedState(flags, 0)
        End If
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

    Private Function SourceFileExists() As Boolean
        If Not IO.File.Exists(Application.StartupPath & "\" & "ConStr.XML") Then
            MessageBox.Show("ملف المصدر غير موجود !")
            Return False
        End If
        Return True
    End Function

    Public Function URL_F() As String
        Try
            Dim pattern As String = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
            Using fs As New FileStream(Application.StartupPath & "/URL.txt", IO.FileMode.Open)
                Using sr As New StreamReader(fs)
                    URL = Trim(sr.ReadToEnd().ToString())
                End Using
            End Using
            If IsConnectedToInternet() Then
                If Regex.IsMatch(URL.ToString().Trim(), pattern) AndAlso UrlIsValid(URL.ToString().Trim()) Then
                    Dim request As HttpWebRequest = CType(WebRequest.Create(URL.ToString().Trim()), HttpWebRequest)
                    Using reader As New StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8)
                        tmpStr1 = reader.ReadToEnd()
                    End Using
                Else
                    Call TxtURL()
                End If
            Else
                tmpStr1 = mykey.GetValue("tmpStr", "").ToString().Trim()
                If FrmLOGIN.Visible Then
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
        tmpStr = mykey.GetValue("tmpStr", "").ToString().Trim()
        If tmpStr1.ToString() = tmpStr.ToString().Trim() Then
            Return True
        Else
            Call TxtURL()
            Return False
        End If
    End Function

    Private Sub WriteToFile(path As String, content As String)
        Using fs As FileStream = File.Create(path)
            Dim info As Byte() = New UTF8Encoding(True).GetBytes(content)
            fs.Write(info, 0, info.Length)
        End Using
    End Sub

    Sub Mainpath()
        Call SourceFileExists()
        Call Viild()
        Dim path As String = Application.StartupPath & "\" & "ConStr.XML"
        If SourceFileExists() Then
            If File.ReadAllText(path).Length <> 0 Then
                If Viild() Then
                    WriteToFile(path, tmpStr1.ToString().Trim())
                Else
                    tmpStr1 = mykey.GetValue("tmpStr", "").ToString().Trim()
                    WriteToFile(path, tmpStr.ToString().Trim())
                End If
            Else
                If Viild() Then
                    WriteToFile(path, mykey.GetValue("tmpStr", "").ToString().Trim())
                Else
                    If Viild() Then
                        WriteToFile(path, tmpStr1.ToString().Trim())
                    Else
                        Try
                            Dim pattern As String = "http(s)?://([\w+?\.\w+])+([a-zA-Z0-9\~\!\@\#\$\%\^\&\*\(\)_\-\=\+\\\/\?\.\:\;\'\,]*)?"
                            If IsConnectedToInternet() Then
                                Dim TxtURL As String = mykey.GetValue("URL", "").ToString().Trim()
                                Dim request As HttpWebRequest = CType(WebRequest.Create(TxtURL.ToString().Trim()), HttpWebRequest)
                                Using reader As New StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8)
                                    If Regex.IsMatch(TxtURL.ToString().Trim(), pattern) AndAlso UrlIsValid(TxtURL.ToString().Trim()) Then
                                        tmpStr = reader.ReadToEnd()
                                    Else
                                        tmpStr1 = mykey.GetValue("tmpStr", "").ToString().Trim()
                                    End If
                                End Using
                            Else
                                If FrmLOGIN.Visible Then
                                    MsgBox("السيرفر غير متوفر حاليا. سيتم الاتصال في الإعدادات السابقة", 64 + 524288, "سيرفر قواعد البيانات")
                                End If
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.OkOnly, "(TxtURL)  خادم شبكة")
                        End Try
                        tmpStr1 = mykey.GetValue("tmpStr", "").ToString().Trim()
                        WriteToFile(path, tmpStr.ToString().Trim())
                    End If
                End If
            End If
        Else
            WriteToFile(path, mykey.GetValue("tmpStr", "").ToString().Trim())
        End If
    End Sub

    Public Sub GetConnectionLocalComputer()

        Dim lines() As String = ReadConnectionFile()
        If lines Is Nothing Then Return

        Dim su1 As Integer = lines(6).Length - 8
        Dim su2 As Integer = lines(7).Length - 8
        Dim su3 As Integer = lines(8).Length - 2

        LocalConnection = String.IsNullOrEmpty(lines(0)) OrElse Convert.ToBoolean(lines(0))
        ServerConnection = Not String.IsNullOrEmpty(lines(1)) AndAlso Convert.ToBoolean(lines(1))
        AuthenicationSQLServer = Not String.IsNullOrEmpty(lines(2)) AndAlso Convert.ToBoolean(lines(2))

        If AuthenicationSQLServer Then
            LocalComp = lines(3)
            userIDName = lines(6).Substring(0, su1).Trim()
            BWS1 = lines(7).Substring(0, su2).Trim()
            DBServer = lines(8).Substring(0, su3).Trim()
            ServerName = LocalComp
        Else
            LocalComp = lines(3)
            DBServer = lines(8).Substring(0, su3).Trim()
            ServerName = LocalComp
        End If
    End Sub

    Private Function ReadConnectionFile() As String()
        Try
            Using fs As New FileStream(Application.StartupPath & "\ConStr.XML", IO.FileMode.Open)
                Using sr As New StreamReader(fs)
                    Dim conStr As String = sr.ReadToEnd()
                    Dim decryptedConnection As String = Encoding.ASCII.GetString(Convert.FromBase64String(conStr))
                    Return decryptedConnection.Split(vbCrLf)
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.OkOnly, "(CC-JO) خادم شبكة")
            Return Nothing
        End Try
    End Function

    Public Sub GetConnection()
        Try
            If tstURL Then Exit Sub

            OnLine = IsConnectedToInternet()
            Mainpath()

            If ReadConnectionFile() Is Nothing Then Return

            Dim su As Integer = ReadConnectionFile()(4).Length - 6
            Dim su1 As Integer = ReadConnectionFile()(8).Length - 2
            Dim su2 As Integer = ReadConnectionFile()(6).Length - 8
            Dim su3 As Integer = ReadConnectionFile()(7).Length - 8

            LocalConnection = String.IsNullOrEmpty(ReadConnectionFile()(0)) OrElse Convert.ToBoolean(ReadConnectionFile()(0))
            ServerConnection = Not String.IsNullOrEmpty(ReadConnectionFile()(1)) AndAlso Convert.ToBoolean(ReadConnectionFile()(1))
            AuthenicationSQLServer = Not String.IsNullOrEmpty(ReadConnectionFile()(2)) AndAlso Convert.ToBoolean(ReadConnectionFile()(2))
            If ServerConnection Then
                LocalComp = ReadConnectionFile()(3).Trim()
                SourceServer = ReadConnectionFile()(4).Substring(0, su).Trim()
                PORT = ReadConnectionFile()(5).Trim()
                userIDName = ReadConnectionFile()(6).Substring(0, su2).Trim()
                BWS1 = ReadConnectionFile()(7).Substring(0, su3).Trim()
                DBServer = ReadConnectionFile()(8).Substring(0, su1).Trim()
                ServerName = SourceServer
            Else
                GetConnectionLocalComputer()
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "(CC-JO) خادم شبكة")
        End Try

    End Sub

    Public Sub ConnectToLocalConnection()
        Try
            If AuthenicationSQLServer Then
                Consum.ConnectionString = $"Data Source={ServerName};Initial Catalog={DBServer};User Id={userIDName};Password={BWS1};"
                ConUsers.ConnectionString = Consum.ConnectionString
                DelUsers.ConnectionString = Consum.ConnectionString
            Else
                Consum.ConnectionString = $"Data Source={ServerName};Initial Catalog={DBServer};Integrated Security=True"
                ConUsers.ConnectionString = Consum.ConnectionString
                DelUsers.ConnectionString = Consum.ConnectionString
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.OkOnly, "كمبوتر المحلي ")
        End Try
    End Sub

    Public Sub ConnectToServerConnection()
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each nic As NetworkInterface In adapters
                If nic.NetworkInterfaceType <> NetworkInterfaceType.Loopback AndAlso nic.NetworkInterfaceType <> NetworkInterfaceType.Tunnel AndAlso nic.NetworkInterfaceType <> NetworkInterfaceType.Unknown Then
                    UserMacAddress &= nic.GetPhysicalAddress().ToString().Trim()
                End If
            Next

            'Dim site As Net.IPHostEntry = Net.Dns.GetHostEntry("www.msn.com")
            TestNet = True
            Consum.ConnectionString = $"Data Source={ServerName},{PORT};Initial Catalog={DBServer};User Id={userIDName};Password={BWS1};"
            ConUsers.ConnectionString = Consum.ConnectionString
            DelUsers.ConnectionString = Consum.ConnectionString
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.OkOnly, "اسم السيرفر")
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
            Using Consum As New SqlConnection(constring)

                Dim Users1 As New SqlCommand("SELECT ID, UserName, BlockUser, LockAddRow, LockDelete, LockSave, LockUpdate, Printpreview, TransferofAccounts, InternalAuditor, CollaborationManager, HeadofAuditingDepartment, ExternalAuditor, RAdmin1 FROM Users", Consum)
                Dim Adp1 As New SqlDataAdapter(Users1)
                ds.Clear()
                Consum.Open()
                Adp1.Fill(ds, "Users")
            End Using

            AuditorClose()
            CollaborationManagerClose()
            HeadOFExternalAccountsDepartmentClose()
            ExternalAuditorClose()

            FiscalYear()
            LoadFiscalYear()
            Inprogress()
            Complete()

            If ds.Tables(0).Rows.Count > 0 Then
                LockPrint = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND Printpreview=1").ToString() > 0
                InternalAuditor = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND InternalAuditor=1").ToString() > 0
                Managers = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND CollaborationManager=1").ToString() > 0
                HeadofAuditingDepartment = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND HeadofAuditingDepartment=1").ToString() > 0
                ExternalAuditor = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND ExternalAuditor=1").ToString() > 0
                RAdmin = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND RAdmin1=1").ToString() > 0
            Else
                MsgBox("لا يوجد مستخدمين", 64 + 524288, "صلاحيات المستخدمين")
            End If

            If Not LoadFiscalYear() Then
                LockAddRow = False
                LockSave = False
                MessageBox.Show("لا يوجد السنة المالية لهذه الجمعية " & ControlChars.CrLf & "1) يجب فتح سنة مالية جديدة" & ControlChars.CrLf, "السنة المالية", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            Else
                HandleFiscalYearStatus()
            End If
        Catch Ex As Exception
            MsgBox(" يوجد مشكلة في اتصال الصلاحيات _ نوصي بشدة اعادة تشغيل النظام", 64 + 524288, "صلاحيات المستخدمين")
        End Try
    End Sub

    Private Sub SetUserPermissions()
        If ds.Tables(0).Rows.Count > 0 Then
            LockAddRow = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND LockAddRow=1").ToString() > 0
            LockSave = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND LockSave=1").ToString() > 0
            LockUpdate = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND LockUpdate=1").ToString() > 0
            LockDelete = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND LockDelete=1").ToString() > 0
            TransferofAccounts = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND TransferofAccounts=1").ToString() > 0
            LockPrint = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND Printpreview=1").ToString() > 0
        End If
    End Sub

    Private Sub HandleFiscalYearStatus()
        If Not ExternalAuditorClose() Then
            If HeadOFExternalAccountsDepartmentClose() Then
                MessageHeadOFExternalAccountsDepartment()
            ElseIf CollaborationManagerClose() Then
                MessageCollaborationManager()
            ElseIf AuditorClose() Then
                MessageAuditor()
            End If
            SetUserPermissions()
        ElseIf Not Inprogress() Then
            MessageManager = True
            If AuditorClose() Then
                LockAddRow = False
                LockSave = False
                LockUpdate = False
                LockDelete = False
                If Complete() Then
                    MessageComplete()
                    Exit Sub
                End If
            End If
            SetUserPermissions()
            MsgBox(2)
        Else
            MessageInprogress()
            MsgBox(3)
            Exit Sub
        End If
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
            Using Consum As New SqlConnection(constring)
                Dim strSQL3 As New SqlCommand("SELECT FL6 FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL6 = @True", Consum)
                strSQL3.Parameters.AddWithValue("@CUser", CUser)
                strSQL3.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQL3.Parameters.AddWithValue("@True", True)

                Dim ds3 As New DataSet
                Dim FinancialList4 As New SqlDataAdapter(strSQL3)
                FinancialList4.Fill(ds3, "FinancialList")

                If ds3.Tables(0).Rows.Count > 0 Then
                    Return ds3.Tables(0).Rows(0).Item(0)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorAuditorClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return False
    End Function
    ' مدير التعاون

    Public Function CollaborationManagerClose() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim strSQL As New SqlCommand("SELECT FL7 FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL7 = @True", Consum)
                strSQL.Parameters.AddWithValue("@CUser", CUser)
                strSQL.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQL.Parameters.AddWithValue("@True", True)
                Dim ds As New DataSet
                Dim FinancialList1 As New SqlDataAdapter(strSQL)
                FinancialList1.Fill(ds, "FinancialList")

                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0).Rows(0).Item(0)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCollaborationManagerClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return False
    End Function
    ' رئيس قسم الحسابات الخارجية

    Public Function HeadOFExternalAccountsDepartmentClose() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim strSQL As New SqlCommand("SELECT FL8 FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL8 = @True", Consum)
                strSQL.Parameters.AddWithValue("@CUser", CUser)
                strSQL.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQL.Parameters.AddWithValue("@True", True)
                Dim ds As New DataSet
                Dim FinancialList1 As New SqlDataAdapter(strSQL)
                FinancialList1.Fill(ds, "FinancialList")

                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0).Rows(0).Item(0)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCollaborationManagerClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return False
    End Function
    ' مدقق الحسابات الخارجية

    Public Function ExternalAuditorClose() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim strSQL As New SqlCommand("SELECT FL9 FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL9 = @True", Consum)
                strSQL.Parameters.AddWithValue("@CUser", CUser)
                strSQL.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQL.Parameters.AddWithValue("@True", True)
                Dim ds As New DataSet
                Dim FinancialList1 As New SqlDataAdapter(strSQL)
                FinancialList1.Fill(ds, "FinancialList")

                If ds.Tables(0).Rows.Count > 0 Then
                    Return ds.Tables(0).Rows(0).Item(0)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorCollaborationManagerClose", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return False
    End Function

    Public Function LoadFiscalYear() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim strSQLFy1 As New SqlCommand("SELECT YE1 FROM FiscalYear WHERE CUser = @CUser AND YE1 = @YE1", Consum)
                strSQLFy1.Parameters.AddWithValue("@CUser", CUser)
                strSQLFy1.Parameters.AddWithValue("@YE1", True)
                Dim dsFy1 As New DataSet
                Dim Fy1 As New SqlDataAdapter(strSQLFy1)
                Fy1.Fill(dsFy1, "FiscalYear")
                Return dsFy1.Tables(0).Rows.Count > 0
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorLoadFiscalYear", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Public Function FiscalYear() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim strSQLFL2 As New SqlCommand("SELECT IDFL FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL6 = @FL6", Consum)
                strSQLFL2.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
                strSQLFL2.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQLFL2.Parameters.AddWithValue("@FL6", False)

                Dim dsFL2 As New DataSet
                Dim FL2 As New SqlDataAdapter(strSQLFL2)
                FL2.Fill(dsFL2)

                Return dsFL2.Tables(0).Rows.Count > 0
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorFiscalYear", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    'قيد العمل محاسب
    Public Function Inprogress() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim X As Integer = 1
                Dim XX As Integer = 4
                Dim strSQLFL1 As New SqlCommand("SELECT IDFL FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL5 = @FL5 AND FL10 BETWEEN @X AND @XX", Consum)
                strSQLFL1.Parameters.AddWithValue("@CUser", CUser)
                strSQLFL1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQLFL1.Parameters.AddWithValue("@FL5", True)
                strSQLFL1.Parameters.AddWithValue("@X", X)
                strSQLFL1.Parameters.AddWithValue("@XX", XX)

                Dim dsFL1 As New DataSet
                Dim FL1 As New SqlDataAdapter(strSQLFL1)
                FL1.Fill(dsFL1)

                Return dsFL1.Tables(0).Rows.Count > 0
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorInprogress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    ' مكتمل
    Public Function Complete() As Boolean
        Try
            Using Consum As New SqlConnection(constring)
                Dim strSQLFL3 As New SqlCommand("SELECT IDFL FROM FinancialList WHERE CUser = @CUser AND FL3 = @FiscalYear AND FL5 = @True AND FL6 = @True AND FL7 = @True AND FL8 = @True AND FL9 = @True", Consum)
                strSQLFL3.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
                strSQLFL3.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strSQLFL3.Parameters.AddWithValue("@True", True)

                Dim dsFL3 As New DataSet
                Dim FL3 As New SqlDataAdapter(strSQLFL3)
                FL3.Fill(dsFL3)

                Return dsFL3.Tables(0).Rows.Count > 0
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComplete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

End Module
