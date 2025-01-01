Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Text.RegularExpressions
Imports EAGetMail

Public Class FrmEgyMail
    Inherits Form
    Implements IComparer
    Private ReadOnly m_arUidl As New ArrayList
    Private m_bcancel As Boolean = False
    Private ReadOnly m_uidlfile As String = "uidl.txt"
    Friend WithEvents WebMail As WebBrowser
    Friend WithEvents Textserver As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextUser As ComboBox
    Friend WithEvents BtnStart As Button
    Friend WithEvents BtnCancel As Button
    Friend WithEvents Panel4 As Panel
    Friend WithEvents GlassButton1 As Button
    Friend WithEvents LblTotal As Label
    Friend WithEvents Delete As Button
    Friend WithEvents AddMail As Button
    Friend WithEvents Panel1 As Panel
    Private m_curpath As String = ""

    Dim SqlDataAdapter1 As New SqlDataAdapter

#Region "EAGetMail Event Handler"
    Private Sub OnConnected(ByVal sender As Object, ByRef cancel As Boolean)
        LblStatus.Text = "Ì ’· ..."
        cancel = m_bcancel
        Application.DoEvents()
    End Sub



    Private Sub OnReceivingDataStream(ByVal sender As Object, ByVal info As MailInfo, ByVal received As Integer, ByVal total As Integer, ByRef cancel As Boolean)
        PgBar.Minimum = 0
        PgBar.Maximum = total
        PgBar.Value = received
        cancel = m_bcancel
        Application.DoEvents()
    End Sub

    Private Sub OnIdle(ByVal sender As Object, ByRef cancel As Boolean)
        cancel = m_bcancel
        Application.DoEvents()
    End Sub

    Private Sub OnAuthorized(ByVal sender As Object, ByRef cancel As Boolean)
        LblStatus.Text = "Œ„Ê· ..."
        cancel = m_bcancel
        Application.DoEvents()
    End Sub

    Private Sub OnSecuring(ByVal sender As Object, ByRef cancel As Boolean)
        LblStatus.Text = " √„Ì‰ ..."
        cancel = m_bcancel
        Application.DoEvents()
    End Sub
#End Region

#Region "UIDL Functions"
    ' uidl is the identifier of every email on POP3/IMAP4 server, to avoid retrieve
    ' the same email from server more than once, we record the email uidl retrieved every time
    ' if you delete the email from server every time and not to leave a copy of email on
    ' the server, then please remove all the function about uidl.
    Private Shared Function FindUIDL(ByVal infos() As MailInfo, ByVal uidl As String) As Boolean
        Dim count As Integer = infos.Length
        For i As Integer = 0 To count - 1
            If String.Compare(infos(i).UIDL, uidl, False) = 0 Then
                FindUIDL = True
                Exit Function
            End If
        Next
        FindUIDL = False
    End Function

    'remove the local uidl which is not existed on the server.
    Private Sub SyncUIDL(ByVal oServer As MailServer, ByVal infos() As MailInfo)
        Dim s As String = String.Format("{0}#{1} ", oServer.Server, oServer.User)
        Dim n As Integer = 0

        Dim bcontinue As Boolean
        Do
            bcontinue = False
            Dim count As Integer = m_arUidl.Count
            For i As Integer = n To count - 1
                Dim x As String = m_arUidl(i)
                If String.Compare(s, 0, x, 0, s.Length, True) = 0 Then

                    Dim pos As Integer = x.LastIndexOf(" ")
                    If pos <> -1 Then
                        Dim uidl As String = x.Substring(pos + 1)
                        If Not FindUIDL(infos, uidl) Then
                            'this uidl doesn't exist on server, 
                            'so we should remove it from local uidl list to save the storage.
                            bcontinue = True
                            n = i
                            m_arUidl.RemoveAt(i)
                            Exit For
                        End If
                    End If
                End If
            Next
        Loop While bcontinue

    End Sub

    Private Function FindExistedUIDL(ByVal oServer As MailServer, ByVal uidl As String) As Boolean
        Dim s As String = String.Format("{0}#{1} {2}", oServer.Server.ToLower(), oServer.User.ToLower(), uidl)
        Dim count As Integer = m_arUidl.Count
        For i As Integer = 0 To count - 1
            Dim x As String = m_arUidl(i)
            If String.Compare(s, x, False) = 0 Then
                FindExistedUIDL = True
                Exit Function
            End If
        Next
        FindExistedUIDL = False
    End Function

    Private Sub AddUIDL(ByVal oServer As MailServer, ByVal uidl As String)
        Dim s As String = String.Format("{0}#{1} {2}", oServer.Server.ToLower(), oServer.User.ToLower(), uidl)
        m_arUidl.Add(s)
    End Sub

    Private Sub UpdateUIDL()
        Dim s As New StringBuilder
        Dim count As Integer = m_arUidl.Count
        For i As Integer = 0 To count - 1
            s.Append(m_arUidl(i))
            s.Append(vbCrLf)
        Next

        Dim file As String = String.Format("{0}\{1}", m_curpath, m_uidlfile)
        Dim fs As FileStream = Nothing

        Try
            fs = New FileStream(file, FileMode.Create, FileAccess.Write, FileShare.None)
            Dim data() As Byte = System.Text.Encoding.Default.GetBytes(s.ToString())
            fs.Write(data, 0, data.Length)
            fs.Close()
        Catch ep As Exception
            If fs IsNot Nothing Then
                fs.Close()
            End If
            Throw
        End Try
    End Sub

    Private Sub LoadUIDL()

        m_arUidl.Clear()
        Dim filename As String = String.Format("{0}\{1}", m_curpath, m_uidlfile)
        Dim read As StreamReader = Nothing

        Try
            read = File.OpenText(filename)
            Do While True
                Dim line As String = read.ReadLine().Trim(vbCrLf & " " & vbTab.ToCharArray())
                m_arUidl.Add(line)
            Loop
        Catch ep As Exception
        End Try

        If read IsNot Nothing Then
            read.Close()
        End If
    End Sub

#End Region

#Region "Parse and Display Mails"
    Private Sub LoadMails()
        LstMail.Items.Clear()
        Dim mailFolder As String = String.Format("{0}\inbox", m_curpath)
        If Not Directory.Exists(mailFolder) Then
            Directory.CreateDirectory(mailFolder)
        End If
        Dim files() As String = Directory.GetFiles(mailFolder, "*.eml")
        Dim count As Integer = files.Length
        For i As Integer = 0 To count - 1
            Dim fullname As String = files(i)
            'For evaluation usage, please use "TryIt" as the license code, otherwise the 
            '"invalid license code" exception will be thrown. However, the object will expire in 1-2 months, then
            '"trial version expired" exception will be thrown.
            Dim oMail As New Mail("TryIt")

            'Load( file, true ) only load the email header to Mail object to save the CPU and memory
            ' the Mail object will load the whole email file later automatically if bodytext or attachment is required..
            oMail.Load(fullname, True)
            Dim item As New ListViewItem(oMail.From.ToString())
            item.SubItems.Add(oMail.Subject)
            item.SubItems.Add(oMail.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))
            item.Tag = fullname
            LstMail.Items.Add(item)
            Dim pos As Integer = fullname.LastIndexOf(".")
            Dim mainName As String = fullname.Substring(0, pos)
            Dim htmlName As String = mainName + ".htm"
            If Not File.Exists(htmlName) Then
                ' this email is unread, we set the font style to bold.
                item.Font = New Font(item.Font, FontStyle.Bold)
            End If
            oMail.Clear()
        Next
    End Sub

    Private Shared Function FormatHtmlTag(ByVal src As String) As String
        src = src.Replace(">", "&gt;")
        src = src.Replace("<", "&lt;")
        FormatHtmlTag = src
    End Function

    'we generate a html + attachment folder for every email, once the html is create,
    ' next time we don't need to parse the email again.
    Private Shared Sub GenerateHtmlForEmail(ByVal htmlName As String, ByVal emlFile As String, ByVal tempFolder As String)
        'For evaluation usage, please use "TryIt" as the license code, otherwise the 
        '"invalid license code" exception will be thrown. However, the object will expire in 1-2 months, then
        '"trial version expired" exception will be thrown.
        Dim oMail As New Mail("TryIt")
        oMail.Load(emlFile, False)

        If oMail.IsEncrypted Then
            Try
                'this email is encrypted, we decrypt it by user default certificate.
                ' you can also use specified certificate like this
                ' oCert = new Certificate()
                'oCert.Load("c:\test.pfx", "pfxpassword", Certificate.CertificateKeyLocation.CRYPT_USER_KEYSET)
                ' oMail = oMail.Decrypt( oCert )
                oMail = oMail.Decrypt(Nothing)
            Catch ep As Exception
                MessageBox.Show(ep.Message)
                oMail.Load(emlFile, False)
            End Try
        End If

        If oMail.IsSigned Then
            Try
                'this email is digital signed.
                Dim cert As Certificate = oMail.VerifySignature()
                MessageBox.Show("This email contains a valid digital signature.")
                'you can add the certificate to your certificate storage like this
                'cert.AddToStore( Certificate.CertificateStoreLocation.CERT_SYSTEM_STORE_CURRENT_USER,"addressbook" );
                ' then you can use send the encrypted email back to this sender.
            Catch ep As Exception
                MessageBox.Show(ep.Message)
            End Try
        End If

        Dim html As String = oMail.HtmlBody
        Dim hdr As New StringBuilder
        hdr.Append("<font face=""Courier New,Arial"" size=2>")
        hdr.Append("<b>From:</b> " + FormatHtmlTag(oMail.From.ToString()) + "<br>")

        Dim addrs() As MailAddress = oMail.To
        Dim count As Integer = addrs.Length
        If count > 0 Then
            hdr.Append("<b>To:</b> ")
            For i As Integer = 0 To count - 1
                hdr.Append(FormatHtmlTag(addrs(i).ToString()))
                If i < count - 1 Then
                    hdr.Append(";"c)
                End If
            Next
            hdr.Append("<br>")
        End If

        addrs = oMail.Cc
        count = addrs.Length
        If count > 0 Then
            hdr.Append("<b>Cc:</b> ")
            For i As Integer = 0 To count - 1

                hdr.Append(FormatHtmlTag(addrs(i).ToString()))
                If i < count - 1 Then
                    hdr.Append(";"c)
                End If
            Next
            hdr.Append("<br>")
        End If

        hdr.Append(String.Format("<b>Subject:</b>{0}<br>" & vbCrLf, FormatHtmlTag(oMail.Subject)))

        Dim atts() As Attachment = oMail.Attachments
        count = atts.Length
        If count > 0 Then

            If Not Directory.Exists(tempFolder) Then
                Directory.CreateDirectory(tempFolder)
            End If

            hdr.Append("<b>Attachments:</b>")
            For i As Integer = 0 To count - 1
                Dim att As Attachment = atts(i)
                'this attachment is in OUTLOOK RTF format, decode it here.
                If String.Compare(att.Name, "winmail.dat") = 0 Then
                    Dim tatts() As Attachment
                    Try
                        tatts = Mail.ParseTNEF(att.Content, True)
                        Dim y As Integer = tatts.Length
                        For x As Integer = 0 To y - 1
                            Dim tatt As Attachment = tatts(x)
                            Dim tattname As String = String.Format("{0}\{1}", tempFolder, tatt.Name)
                            tatt.SaveAs(tattname, True)
                            hdr.Append(String.Format("<a href=""{0}"" target=""_blank"">{1}</a> ", tattname, tatt.Name))
                        Next
                    Catch ep As Exception
                        MessageBox.Show(ep.Message)
                    End Try
                Else
                    Dim attname As String = String.Format("{0}\{1}", tempFolder, att.Name)
                    att.SaveAs(attname, True)
                    hdr.Append(String.Format("<a href=""{0}"" target=""_blank"">{1}</a> ", attname, att.Name))
                    If att.ContentID.Length > 0 Then
                        'show embedded image.
                        html = html.Replace("cid:" + att.ContentID, attname)
                    ElseIf String.Compare(att.ContentType, 0, "image/", 0, "image/".Length, True) = 0 Then
                        'show attached image.
                        html += String.Format("<hr><img src=""{0}"">", attname)
                    End If
                End If
            Next
        End If

        Dim reg As New Regex("(<meta[^>]*charset[ \t]*=[ \t""]*)([^<> \r\n""]*)", RegexOptions.Multiline Or RegexOptions.IgnoreCase)
        html = reg.Replace(html, "$1utf-8")
        If Not reg.IsMatch(html) Then
            hdr.Insert(0, "<meta HTTP-EQUIV=""Content-Type"" Content=""text-html; charset=utf-8"">")
        End If

        html = hdr.ToString() + "<hr>" + html
        Dim fs As New FileStream(htmlName, FileMode.Create, FileAccess.Write, FileShare.None)
        Dim data() As Byte = System.Text.UTF8Encoding.UTF8.GetBytes(html)
        fs.Write(data, 0, data.Length)
        fs.Close()
        oMail.Clear()
    End Sub
    Private Sub ShowMail(ByVal fileName As String)
        Try
            Dim pos As Integer = fileName.LastIndexOf(".")
            Dim mainName As String = fileName.Substring(0, pos)
            Dim htmlName As String = mainName + ".htm"
            Dim tempFolder As String = mainName
            If Not File.Exists(htmlName) Then
                GenerateHtmlForEmail(htmlName, fileName, tempFolder)
            End If
            WebMail.Navigate(htmlName)
        Catch ep As Exception
            MessageBox.Show(ep.Message)
        End Try
    End Sub
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.IContainer
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TextPassword As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents LstAuthType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LstProtocol As ComboBox
    Friend WithEvents ChkLeaveCopy As CheckBox
    Friend WithEvents LblStatus As Label
    Friend WithEvents PgBar As ProgressBar
    Friend WithEvents ChkSSL As CheckBox

    Friend WithEvents LstMail As ListView
    Friend WithEvents ColFrom As ColumnHeader
    Friend WithEvents ColSubject As ColumnHeader
    Friend WithEvents ColDate As ColumnHeader
    Friend WithEvents Label6 As Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(FrmEgyMail))
        Me.GroupBox1 = New GroupBox
        Me.Panel4 = New Panel
        Me.BtnCancel = New Button
        Me.BtnStart = New Button
        Me.PgBar = New ProgressBar
        Me.TextUser = New ComboBox
        Me.Panel2 = New Panel
        Me.LblStatus = New Label
        Me.Label6 = New Label
        Me.Textserver = New TextBox
        Me.Label10 = New Label
        Me.ChkLeaveCopy = New CheckBox
        Me.LstProtocol = New ComboBox
        Me.Label5 = New Label
        Me.LstAuthType = New ComboBox
        Me.Label4 = New Label
        Me.ChkSSL = New CheckBox
        Me.TextPassword = New TextBox
        Me.Label3 = New Label
        Me.Label2 = New Label
        Me.LstMail = New ListView
        Me.ColFrom = New ColumnHeader
        Me.ColSubject = New ColumnHeader
        Me.ColDate = New ColumnHeader
        Me.WebMail = New WebBrowser
        Me.GlassButton1 = New Button
        Me.LblTotal = New Label
        Me.Delete = New Button
        Me.AddMail = New Button
        Me.Panel1 = New Panel
        Me.GroupBox1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel4)
        Me.GroupBox1.Controls.Add(Me.PgBar)
        Me.GroupBox1.Controls.Add(Me.TextUser)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Textserver)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ChkLeaveCopy)
        Me.GroupBox1.Controls.Add(Me.LstProtocol)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.LstAuthType)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.ChkSSL)
        Me.GroupBox1.Controls.Add(Me.TextPassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Left
        Me.GroupBox1.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New Point(0, 0)
        Me.GroupBox1.Name = "groupBox1"
        Me.GroupBox1.Size = New Size(232, 413)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "„⁄·Ê„«  «·Õ”«»"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.BtnCancel)
        Me.Panel4.Controls.Add(Me.BtnStart)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel4.Location = New Point(3, 218)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New Size(226, 32)
        Me.Panel4.TabIndex = 553
        '
        'btnCancel
        '
        Me.BtnCancel.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnCancel.Location = New Point(-1, 0)
        Me.BtnCancel.Name = "btnCancel"
        Me.BtnCancel.Size = New Size(110, 30)
        Me.BtnCancel.TabIndex = 552
        Me.BtnCancel.Text = "≈·€«¡"
        Me.BtnCancel.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.BtnStart.Dock = System.Windows.Forms.DockStyle.Right
        Me.BtnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnStart.Location = New Point(109, 0)
        Me.BtnStart.Name = "btnStart"
        Me.BtnStart.Size = New Size(115, 30)
        Me.BtnStart.TabIndex = 555
        Me.BtnStart.Text = "œŒÊ·"
        Me.BtnStart.UseVisualStyleBackColor = True
        '
        'pgBar
        '
        Me.PgBar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.PgBar.Location = New Point(3, 250)
        Me.PgBar.Name = "pgBar"
        Me.PgBar.Size = New Size(226, 32)
        Me.PgBar.TabIndex = 15
        Me.PgBar.Visible = False
        '
        'textUser
        '
        Me.TextUser.FormattingEnabled = True
        Me.TextUser.Location = New Point(9, 21)
        Me.TextUser.Name = "textUser"
        Me.TextUser.Size = New Size(148, 23)
        Me.TextUser.TabIndex = 554
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LblStatus)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New Point(3, 282)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(226, 128)
        Me.Panel2.TabIndex = 553
        '
        'lblStatus
        '
        Me.LblStatus.AutoSize = True
        Me.LblStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LblStatus.Location = New Point(3, 9)
        Me.LblStatus.Name = "lblStatus"
        Me.LblStatus.Size = New Size(0, 15)
        Me.LblStatus.TabIndex = 14
        '
        'label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New Point(2, 31)
        Me.Label6.Name = "label6"
        Me.Label6.Size = New Size(216, 69)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = " Õ–Ì—: ≈–« ·„ Ì „  ÕœÌœ "" —ﬂ ‰”Œ… „‰ «·—”«·… ⁄·Ï «·Œ«œ„"" ° ›”Ì „ Õ–› —”«∆· «·»—Ìœ" &
            " «·≈·ﬂ —Ê‰Ì «·„ÊÃÊœ… ⁄·Ï «·Œ«œ„!"
        '
        'textserver
        '
        Me.Textserver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Textserver.Enabled = False
        Me.Textserver.Location = New Point(9, 69)
        Me.Textserver.Name = "textserver"
        Me.Textserver.Size = New Size(148, 22)
        Me.Textserver.TabIndex = 551
        '
        'label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New Point(194, 76)
        Me.Label10.Name = "label10"
        Me.Label10.Size = New Size(32, 15)
        Me.Label10.TabIndex = 550
        Me.Label10.Text = "«·Œ«œ„"
        '
        'chkLeaveCopy
        '
        Me.ChkLeaveCopy.AutoSize = True
        Me.ChkLeaveCopy.ForeColor = System.Drawing.Color.Black
        Me.ChkLeaveCopy.Location = New Point(59, 178)
        Me.ChkLeaveCopy.Name = "chkLeaveCopy"
        Me.ChkLeaveCopy.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkLeaveCopy.Size = New Size(167, 19)
        Me.ChkLeaveCopy.TabIndex = 11
        Me.ChkLeaveCopy.Text = " —ﬂ ‰”Œ… „‰ «·—”«·… ⁄·Ï «·Œ«œ„"
        '
        'lstProtocol
        '
        Me.LstProtocol.Location = New Point(9, 145)
        Me.LstProtocol.Name = "lstProtocol"
        Me.LstProtocol.Size = New Size(148, 23)
        Me.LstProtocol.TabIndex = 10
        '
        'label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New Point(176, 153)
        Me.Label5.Name = "label5"
        Me.Label5.Size = New Size(50, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "»—Ê ÊﬂÊ·"
        '
        'lstAuthType
        '
        Me.LstAuthType.Location = New Point(9, 119)
        Me.LstAuthType.Name = "lstAuthType"
        Me.LstAuthType.Size = New Size(148, 23)
        Me.LstAuthType.TabIndex = 8
        '
        'label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New Point(162, 127)
        Me.Label4.Name = "label4"
        Me.Label4.Size = New Size(64, 15)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "‰Ê⁄ «·„’«œﬁ…"
        '
        'chkSSL
        '
        Me.ChkSSL.AutoSize = True
        Me.ChkSSL.ForeColor = System.Drawing.Color.Black
        Me.ChkSSL.Location = New Point(139, 97)
        Me.ChkSSL.Name = "chkSSL"
        Me.ChkSSL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkSSL.Size = New Size(87, 19)
        Me.ChkSSL.TabIndex = 6
        Me.ChkSSL.Text = "« ’«· (SSL)"
        '
        'textPassword
        '
        Me.TextPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPassword.Location = New Point(9, 46)
        Me.TextPassword.Name = "textPassword"
        Me.TextPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextPassword.Size = New Size(148, 22)
        Me.TextPassword.TabIndex = 5
        '
        'label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New Point(178, 54)
        Me.Label3.Name = "label3"
        Me.Label3.Size = New Size(48, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "ﬂ·„Â «·”—"
        '
        'label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New Point(156, 29)
        Me.Label2.Name = "label2"
        Me.Label2.Size = New Size(70, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = " »—Ìœ «·ﬂ —Ê‰Ì"
        '
        'lstMail
        '
        Me.LstMail.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.LstMail.BackColor = System.Drawing.SystemColors.Window
        Me.LstMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LstMail.Columns.AddRange(New ColumnHeader() {Me.ColFrom, Me.ColSubject, Me.ColDate})
        Me.LstMail.Dock = System.Windows.Forms.DockStyle.Top
        Me.LstMail.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LstMail.FullRowSelect = True
        Me.LstMail.HideSelection = False
        Me.LstMail.HoverSelection = True
        Me.LstMail.Location = New Point(232, 0)
        Me.LstMail.Name = "lstMail"
        Me.LstMail.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LstMail.Size = New Size(492, 170)
        Me.LstMail.TabIndex = 1
        Me.LstMail.UseCompatibleStateImageBehavior = False
        Me.LstMail.View = System.Windows.Forms.View.Details
        '
        'colFrom
        '
        Me.ColFrom.Text = "„‰ ⁄‰œ"
        Me.ColFrom.Width = 100
        '
        'colSubject
        '
        Me.ColSubject.Text = "„Ê÷Ê⁄"
        Me.ColSubject.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColSubject.Width = 200
        '
        'colDate
        '
        Me.ColDate.Text = " «—ÌŒ"
        Me.ColDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ColDate.Width = 150
        '
        'webMail
        '
        Me.WebMail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebMail.Location = New Point(232, 199)
        Me.WebMail.MinimumSize = New Size(20, 20)
        Me.WebMail.Name = "webMail"
        Me.WebMail.Size = New Size(492, 214)
        Me.WebMail.TabIndex = 6
        '
        'GlassButton1
        '
        Me.GlassButton1.AutoSize = True
        Me.GlassButton1.BackgroundImage = Global.CC_JO.My.Resources.Resources.btn2
        Me.GlassButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.GlassButton1.Dock = System.Windows.Forms.DockStyle.Right
        Me.GlassButton1.Font = New Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GlassButton1.ForeColor = System.Drawing.Color.DarkMagenta
        Me.GlassButton1.Location = New Point(459, 0)
        Me.GlassButton1.Name = "GlassButton1"
        Me.GlassButton1.Size = New Size(31, 27)
        Me.GlassButton1.TabIndex = 7
        Me.GlassButton1.Text = "+"
        Me.GlassButton1.UseVisualStyleBackColor = True
        '
        'lblTotal
        '
        Me.LblTotal.AutoSize = True
        Me.LblTotal.BackColor = System.Drawing.Color.Transparent
        Me.LblTotal.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LblTotal.ForeColor = System.Drawing.Color.Black
        Me.LblTotal.Location = New Point(5, 10)
        Me.LblTotal.Name = "lblTotal"
        Me.LblTotal.Size = New Size(0, 15)
        Me.LblTotal.TabIndex = 4
        '
        'Delete
        '
        Me.Delete.Dock = System.Windows.Forms.DockStyle.Right
        Me.Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Delete.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Delete.ForeColor = System.Drawing.Color.Black
        Me.Delete.Location = New Point(384, 0)
        Me.Delete.Name = "Delete"
        Me.Delete.Size = New Size(75, 27)
        Me.Delete.TabIndex = 552
        Me.Delete.Text = "Delete"
        Me.Delete.UseVisualStyleBackColor = True
        '
        'AddMail
        '
        Me.AddMail.Dock = System.Windows.Forms.DockStyle.Right
        Me.AddMail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddMail.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.AddMail.ForeColor = System.Drawing.Color.Black
        Me.AddMail.Location = New Point(309, 0)
        Me.AddMail.Name = "AddMail"
        Me.AddMail.Size = New Size(75, 27)
        Me.AddMail.TabIndex = 551
        Me.AddMail.Text = "AddMail"
        Me.AddMail.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.AddMail)
        Me.Panel1.Controls.Add(Me.Delete)
        Me.Panel1.Controls.Add(Me.LblTotal)
        Me.Panel1.Controls.Add(Me.GlassButton1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New Point(232, 170)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(492, 29)
        Me.Panel1.TabIndex = 552
        '
        'frmEgyMail
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New Size(724, 413)
        Me.Controls.Add(Me.WebMail)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.LstMail)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.KeyPreview = True
        Me.Name = "frmEgyMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Mail-≈” ﬁ»«·"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmEgyMail_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        'Me.BackgroundImage = My.Resources.Seven_6
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        WebMail.Navigate("about:blank")
        LstProtocol.Items.Add("POP3")
        LstProtocol.Items.Add("IMAP4")
        LstProtocol.SelectedIndex = 0
        ChkSSL.Checked = True
        LstAuthType.Items.Add("USER/LOGIN")
        LstAuthType.Items.Add("APOP")
        LstAuthType.Items.Add("NTLM")
        LstAuthType.SelectedIndex = 0
        ChkLeaveCopy.Checked = True
        Label10.Enabled = False
        Textserver.Enabled = False
        Dim path As String = Application.ExecutablePath
        Dim pos As Integer = path.LastIndexOf("\")
        If pos <> -1 Then
            path = path.Substring(0, pos)
        End If
        m_curpath = path
        LstMail.Sorting = System.Windows.Forms.SortOrder.Descending
        LstMail.ListViewItemSorter = Me
        LoadMails()
        LblTotal.Text = String.Format("Total {0} email(s)", LstMail.Items.Count)
        'FILLCOMBOBOX("AddMail", "FIELD3", textUser)
        FILLCOMBOBOX1("AddMail", "FIELD3", "CUser", CUser, Me.TextUser)
        'textserver.Enabled = True
    End Sub

#Region "IComparer Members"
    Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements IComparer.Compare
        Dim itemx As ListViewItem = x
        Dim itemy As ListViewItem = y

        Dim sx() As Char = itemx.SubItems(2).Text.ToCharArray()
        Dim sy() As Char = itemy.SubItems(2).Text.ToCharArray()
        If sx.Length <> sy.Length Then
            Compare = -1
            Exit Function
        End If
        Dim count As Integer = sx.Length
        For i As Integer = 0 To count - 1

            If sx(i) > sy(i) Then
                Compare = -1
                Exit Function
            ElseIf sx(i) < sy(i) Then
                Compare = 1
                Exit Function
            End If
        Next
        Compare = 0
    End Function

#End Region
    Private Sub BtnDel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Delete.Click
        Dim items As ListView.SelectedListViewItemCollection = LstMail.SelectedItems
        If items.Count = 0 Then
            Exit Sub
        End If
        If MessageBox.Show("Do you want to delete all selected emails",
                                 "",
                                 MessageBoxButtons.YesNo) = DialogResult.No Then
            Exit Sub
        End If
        Do While items.Count > 0
            Try
                Dim fileName As String = items(0).Tag
                File.Delete(fileName)
                Dim pos As Integer = fileName.LastIndexOf(".")
                Dim tempFolder As String = fileName.Substring(0, pos)
                Dim htmlName As String = tempFolder + ".htm"
                If File.Exists(htmlName) Then
                    File.Delete(htmlName)
                End If

                If Directory.Exists(tempFolder) Then
                    Directory.Delete(tempFolder, True)
                End If
                LstMail.Items.Remove(items(0))
            Catch ep As Exception
                MessageBox.Show(ep.Message)
                Exit Do
            End Try
        Loop
        LblTotal.Text = String.Format("Total {0} email(s)", LstMail.Items.Count)
        WebMail.Navigate("about:blank")
    End Sub
    Private Sub BtnStart_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnStart.Click
        LstMail.Items.Clear()
        Dim server, user, password As String
        server = ""
        user = TextUser.Text.Trim()
        password = TextPassword.Text.Trim()
        If user.Contains("yahoo.com") Then
            LstProtocol.Text = "POP3"
            Label10.Enabled = False
            Textserver.Enabled = False
            server = "pop.mail.yahoo.com"
            Textserver.Text = server
        ElseIf user.Contains("hotmail.com") Or user.Contains("live.com") Then
            LstProtocol.Text = "POP3"
            Label10.Enabled = False
            Textserver.Enabled = False
            server = "pop3.live.com"
            Textserver.Text = server
        ElseIf user.Contains("gmail.com") Then
            Label10.Enabled = False
            Textserver.Enabled = False
            server = "pop.gmail.com"
            Textserver.Text = server
            LstProtocol.Text = "IMAP4"
        Else
            LstProtocol.Text = "POP3"
            Label10.Enabled = True
            Textserver.Enabled = True
            Textserver.Focus()
            Exit Sub
        End If
        If server.Length = 0 Or user.Length = 0 Or password.Length = 0 Then
            MessageBox.Show("Please input server, user and password.")
            Exit Sub
        End If
        BtnStart.Enabled = False
        BtnCancel.Enabled = True

        Dim authType As ServerAuthType = ServerAuthType.AuthLogin
        If LstAuthType.SelectedIndex = 1 Then
            authType = ServerAuthType.AuthCRAM5
        ElseIf LstAuthType.SelectedIndex = 2 Then
            authType = ServerAuthType.AuthNTLM
        End If
        Dim protocol As ServerProtocol = ServerProtocol.Pop3
        If LstProtocol.SelectedIndex = 1 Then
            protocol = ServerProtocol.Imap4
        End If
        Dim oServer As New MailServer(server, user, password,
        ChkSSL.Checked, authType, protocol)
        Dim oClient As New MailClient("TryIt")
        'oClient.GetMailInfosParam.GetMailInfosOptions = GetMailInfosOptionType.NewOnly
        AddHandler oClient.OnAuthorized, AddressOf OnAuthorized
        AddHandler oClient.OnConnected, AddressOf OnConnected
        AddHandler oClient.OnIdle, AddressOf OnIdle
        AddHandler oClient.OnSecuring, AddressOf OnSecuring
        AddHandler oClient.OnReceivingDataStream, AddressOf OnReceivingDataStream
        Dim bLeaveCopy As Boolean = ChkLeaveCopy.Checked
        Try
            LoadUIDL()
            Dim mailFolder As String = String.Format("{0}\inbox", m_curpath)
            If Not Directory.Exists(mailFolder) Then
                Directory.CreateDirectory(mailFolder)
            End If
            m_bcancel = False
            oClient.Connect(oServer)
            Dim infos() As MailInfo = oClient.GetMailInfos()
            LblStatus.Text = String.Format("Total {0} email(s)", infos.Length)
            SyncUIDL(oServer, infos)
            Dim count As Integer = infos.Length
            For i As Integer = 0 To count - 1
                Dim info As MailInfo = infos(i)
                If FindExistedUIDL(oServer, info.UIDL) Then
                    'this email has existed on local disk.
                    LblStatus.Text = "1 ..."
                Else
                    LblStatus.Text = "2 ..."
                    PgBar.Visible = True
                    LblStatus.Text = String.Format("Retrieving {0}/{1}...", info.Index, count)
                    Dim oMail As Mail = oClient.GetMail(info)
                    Dim d As System.DateTime = System.DateTime.Now
                    Dim cur As New Globalization.CultureInfo("en-US")
                    Dim sdate As String = d.ToString("yyyyMMddHHmmss", cur)
                    Dim fileName As String = String.Format("{0}\{1}{2}{3}.eml", mailFolder, sdate, d.Millisecond.ToString("d3"), i)
                    oMail.SaveAs(fileName, True)

                    Dim item As New ListViewItem(oMail.From.ToString())
                    item.SubItems.Add(oMail.Subject)
                    item.SubItems.Add(oMail.ReceivedDate.ToString("yyyy-MM-dd HH:mm:ss"))
                    item.Font = New Font(item.Font, FontStyle.Bold)
                    item.Tag = fileName
                    LstMail.Items.Insert(0, item)
                    oMail.Clear()

                    LblTotal.Text = String.Format("Total {0} email(s)", LstMail.Items.Count)


                    If bLeaveCopy Then
                        LblStatus.Text = "3 ..."
                        'add the email uidl to uidl file to avoid we retrieve it next time. 
                        AddUIDL(oServer, info.UIDL)
                    End If
                End If
            Next

            If Not bLeaveCopy Then
                LblStatus.Text = "Deleting ..."
                For i As Integer = 0 To count - 1
                    oClient.Delete(infos(i))
                    PgBar.Visible = True
                Next
            End If
            oClient.Quit()
        Catch ep As Exception
            MessageBox.Show(ep.Message)
        End Try

        UpdateUIDL()
        LblStatus.Text = "Completed ..."
        PgBar.Maximum = 100
        PgBar.Minimum = 0
        PgBar.Value = 0
        PgBar.Visible = False
        BtnStart.Enabled = True
        BtnCancel.Enabled = False
    End Sub
    Private Sub LstMail_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LstMail.Click
        Dim items As ListView.SelectedListViewItemCollection = LstMail.SelectedItems
        If items.Count = 0 Then
            Exit Sub
        End If
        Dim item As ListViewItem = items(0)
        ShowMail(item.Tag)
        item.Font = New Font(item.Font, FontStyle.Regular)
    End Sub
    Private Sub BtnCancel_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnCancel.Click
        m_bcancel = True
    End Sub
    Private Sub TextUser_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextUser.TextChanged
        Try
            Dim server, user, password As String
            server = ""
            user = TextUser.Text.Trim()
            password = TextPassword.Text.Trim()
            If user.Contains("yahoo.com") Then
                LstProtocol.Text = "POP3"
                Label10.Enabled = False
                Textserver.Enabled = False
                server = "pop.mail.yahoo.com"
                Textserver.Text = server
            ElseIf user.Contains("hotmail.com") Or user.Contains("live.com") Then
                LstProtocol.Text = "POP3"
                Label10.Enabled = False
                Textserver.Enabled = False
                server = "pop3.live.com"
                Textserver.Text = server
            ElseIf user.Contains("gmail.com") Then
                Label10.Enabled = False
                Textserver.Enabled = False
                server = "pop.gmail.com"
                Textserver.Text = server
                LstProtocol.Text = "IMAP4"
            Else
                LstProtocol.Text = "POP3"
                Label10.Enabled = True
                Textserver.Enabled = True
                Textserver.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub AddMail_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles AddMail.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim f As New FrmSettingEmailserver
            f.Show()
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub TextUser_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextUser.SelectedIndexChanged
        Try
            'textserver.Enabled = True
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)

            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            strSQL.CommandText = "SELECT DISTINCT FIELD4,FIELD5 FROM  AddMail WHERE FIELD3='" & Me.TextUser.Text & "'"
            SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim I As Integer
            Dim DS As New DataSet
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            DS = New DataSet
            SqlDataAdapter1.Fill(DS, "AddMail")
            DS.Clear()
            SqlDataAdapter1.Fill(DS, "TBL")
            TextPassword.Text = ""
            Textserver.Text = ""
            For I = 0 To DS.Tables("TBL").Rows.Count - 1
                TextPassword.Text = DS.Tables("TBL").Rows(I).Item(0)
                Textserver.Text = DS.Tables("TBL").Rows(I).Item(1)
            Next I
            SqlDataAdapter1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub GlassButton1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles GlassButton1.Click
        Dim txt As Control
        If Me.LstMail.Visible = True Then
            For Each txt In Me.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Or TypeOf txt Is GroupBox Or TypeOf txt Is ListView Then
                    txt.Visible = False
                End If
            Next
            'Panel3.BringToFront()
            'Panel3.Visible = True
            'Panel3.Dock = DockStyle.Fill
            Panel1.BringToFront()
            Panel1.Visible = True
            Panel1.Dock = DockStyle.Top

            Me.WebMail.BringToFront()
            Me.WebMail.Dock = DockStyle.Fill

            Me.GlassButton1.Visible = True
            Me.GlassButton1.SendToBack()
            Me.GlassButton1.Text = "-"
            Me.GlassButton1.Visible = True
            Me.GlassButton1.Dock = DockStyle.Right
        Else
            For Each txt In Me.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Or TypeOf txt Is GroupBox Or TypeOf txt Is ListView Then
                    txt.Visible = True
                End If
            Next
            Me.Panel1.BringToFront()
            Me.Panel1.Visible = True
            Me.Panel1.Dock = DockStyle.Top

            Me.WebMail.BringToFront()
            Me.WebMail.Dock = DockStyle.Fill

            Me.GlassButton1.SendToBack()
            Me.GlassButton1.Text = "+"
            Me.GlassButton1.Dock = DockStyle.Right
            Me.GlassButton1.Visible = True




        End If
    End Sub


End Class
