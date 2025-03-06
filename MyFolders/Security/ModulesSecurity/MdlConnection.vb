Option Explicit On
Imports System.Data.SqlClient
Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Text
Imports System.Text.RegularExpressions

Module MdlConnection

<<<<<<< HEAD
    Private _consum As New SqlConnection
    Public DelUsers As New SqlConnection
    Public ConUsers As New SqlConnection
=======
    Private _consum As New SqlClient.SqlConnection
    Public DelUsers As New SqlClient.SqlConnection
    Public ConUsers As New SqlClient.SqlConnection
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

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
<<<<<<< HEAD
    ReadOnly FsLocal As FileStream
    ReadOnly SrLocal As StreamReader
    Private ReadOnly ds As New DataSet
=======
    Dim FsLocal As IO.FileStream
    Dim SrLocal As IO.StreamReader

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Property Consum As SqlConnection
        Get
            Return _consum
        End Get
        Set(value As SqlConnection)
            _consum = value
        End Set
    End Property

<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                                    MsgBox("السيرفر غير متوفر حاليا. سيتم الاتصال في الإعدادات السابقة", 64 + 524288, "سيرفر قواعد البيانات")
                                End If
                            End If
                        Catch ex As Exception
<<<<<<< HEAD
                            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.OkOnly, "(TxtURL)  خادم شبكة")
                        End Try
                        tmpStr1 = mykey.GetValue("tmpStr", "").ToString().Trim()
                        WriteToFile(path, tmpStr.ToString().Trim())
                    End If
                End If
            End If
        Else
            WriteToFile(path, mykey.GetValue("tmpStr", "").ToString().Trim())
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End If
    End Sub

    Public Sub GetConnectionLocalComputer()

<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Else
                GetConnectionLocalComputer()
            End If
        Catch Ex As Exception
            MsgBox(Ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "(CC-JO) خادم شبكة")
        End Try

    End Sub

    Public Sub ConnectToLocalConnection()
        Try
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Try
    End Sub

    Public Sub ConnectToServerConnection()
        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each nic As NetworkInterface In adapters
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
=======

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
            Using Consum As New SqlConnection(constring)

                Dim Users1 As New SqlCommand("SELECT ID, UserName, BlockUser, LockAddRow, LockDelete, LockSave, LockUpdate, Printpreview, TransferofAccounts, InternalAuditor, CollaborationManager, HeadofAuditingDepartment, ExternalAuditor, RAdmin1 FROM Users", Consum)
                Dim Adp1 As New SqlDataAdapter(Users1)
                ds.Clear()
                Consum.Open()
                Adp1.Fill(ds, "Users")
            End Using
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim ds As New DataSet
            Dim Users1 As New SqlCommand("Select ID ,UserName  ,BlockUser,LockAddRow ,LockDelete,LockSave  ,LockUpdate,Printpreview, TransferofAccounts ,InternalAuditor ,CollaborationManager ,HeadofAuditingDepartment,ExternalAuditor ,RAdmin1 from Users", Consum)
            Dim Adp1 As New SqlClient.SqlDataAdapter(Users1)
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp1.Fill(ds, "Users")
            If Consum.State = ConnectionState.Open Then Consum.Close()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            AuditorClose()
            CollaborationManagerClose()
            HeadOFExternalAccountsDepartmentClose()
            ExternalAuditorClose()

            FiscalYear()
            LoadFiscalYear()
            Inprogress()
            Complete()

            If ds.Tables(0).Rows.Count > 0 Then
<<<<<<< HEAD
                LockPrint = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND Printpreview=1").ToString() > 0
                InternalAuditor = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND InternalAuditor=1").ToString() > 0
                Managers = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND CollaborationManager=1").ToString() > 0
                HeadofAuditingDepartment = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND HeadofAuditingDepartment=1").ToString() > 0
                ExternalAuditor = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND ExternalAuditor=1").ToString() > 0
                RAdmin = ds.Tables("Users").Compute("Count(UserName)", $"UserName LIKE '{USERNAME}' AND RAdmin1=1").ToString() > 0
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Else
                MsgBox("لا يوجد مستخدمين", 64 + 524288, "صلاحيات المستخدمين")
            End If

<<<<<<< HEAD
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
=======

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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Function
    ' مدير التعاون

    Public Function CollaborationManagerClose() As Boolean
        Try
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Function
    ' رئيس قسم الحسابات الخارجية

    Public Function HeadOFExternalAccountsDepartmentClose() As Boolean
        Try
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Function
    ' مدقق الحسابات الخارجية

    Public Function ExternalAuditorClose() As Boolean
        Try
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Function

    Public Function LoadFiscalYear() As Boolean
        Try
<<<<<<< HEAD
            Using Consum As New SqlConnection(constring)
                Dim strSQLFy1 As New SqlCommand("SELECT YE1 FROM FiscalYear WHERE CUser = @CUser AND YE1 = @YE1", Consum)
                strSQLFy1.Parameters.AddWithValue("@CUser", CUser)
                strSQLFy1.Parameters.AddWithValue("@YE1", True)
                Dim dsFy1 As New DataSet
                Dim Fy1 As New SqlDataAdapter(strSQLFy1)
                Fy1.Fill(dsFy1, "FiscalYear")
                Return dsFy1.Tables(0).Rows.Count > 0
            End Using
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorLoadFiscalYear", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

    Public Function FiscalYear() As Boolean
        Try
<<<<<<< HEAD
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
=======
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

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Return False
        End Try
    End Function

    'قيد العمل محاسب
    Public Function Inprogress() As Boolean
        Try
<<<<<<< HEAD
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
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorInprogress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

<<<<<<< HEAD
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
=======

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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComplete", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return False
        End Try
    End Function

End Module
