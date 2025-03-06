
Imports System.Data.SqlClient
Imports System.Net.Mail


Public Class FrmConnect
<<<<<<< HEAD
    Inherits Form
    Private WithEvents SmtpServer As New SmtpClient()
    Public ds As New DataSet

    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP2.Click

        Try
            Dim Consum As New SqlConnection(constring)
=======
    Inherits System.Windows.Forms.Form
    Private WithEvents SmtpServer As New SmtpClient()
    Public ds As New DataSet

    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click

        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.EnforceConstraints = False
            Consum.Open()
            Me.PictureBox1.Visible = True
            ButtonXP2.Enabled = False
            Dim str5 As New SqlCommand("SELECT * FROM  TSettingEmail WHERE FIELD4='" & "ma965880@gmail.com" & "'", Consum)
            Dim ADP5 As New SqlDataAdapter(str5)
            ds.Clear()
            ADP5.Fill(ds, "TSettingEmail")
            ADP5.Fill(ds, "TBL")
            'Dim s As Integer

            Dim S1 As String = ds.Tables("TBL").Rows(0).Item(1)
            Dim S2 As String = ds.Tables("TBL").Rows(0).Item(2)
            Dim S3 As String = ds.Tables("TBL").Rows(0).Item(3)
            Dim S4 As String = ds.Tables("TBL").Rows(0).Item(4)
            Dim mail As New MailMessage()
            SmtpServer.Credentials = New Net.NetworkCredential(S3, S4)
            SmtpServer.Port = S2
            SmtpServer.Host = S1
            SmtpServer.EnableSsl = True
            mail.From = New MailAddress(TEXTBOX3.Text, TEXTBOX2.Text, System.Text.Encoding.UTF8)
            mail.To.Add("ma965880@gmail.com")
            mail.Subject = " إدارة الجمعيات التعاونية _" & Me.TEXTBOX1.Text.ToString
            mail.SubjectEncoding = System.Text.Encoding.UTF8
            mail.Body = Me.TEXTBOX4.Text.ToString
            mail.BodyEncoding = System.Text.Encoding.UTF8
            mail.Body = Me.TEXTBOX3.Text.ToString
            mail.BodyEncoding = System.Text.Encoding.UTF8
            mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure
            SmtpServer.EnableSsl = True
            SmtpServer.SendAsync(mail, Nothing)
        Catch ex As Exception
            ButtonXP2.Enabled = True
            Me.PictureBox1.Visible = False
            MessageBox.Show(ex.Message, "رسالة غير ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub
    Private Sub SmtpServer_SendCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles SmtpServer.SendCompleted
        Try
            ButtonXP2.Enabled = True
            Me.PictureBox1.Visible = False
            MessageBox.Show("تم ارسال الأيميل بنجاح", "رسالة تاجحة", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As SqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub MNUCOPY_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUCOPY.Click
=======
    Private Sub MNUCOPY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUCOPY.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            TEXTBOX4.Copy()
        Catch exc As Exception
            MessageBox.Show("نسخ", "غير قادر على نسخ الملف", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub MNUNDEO_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUNDEO.Click
=======
    Private Sub MNUNDEO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUNDEO.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TEXTBOX4.CanUndo Then TEXTBOX4.Undo()
        Catch ex As Exception
            If TEXTBOX4.CanUndo Then TEXTBOX4.Undo()
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub MNUCUT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUCUT.Click
=======
    Private Sub MNUCUT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUCUT.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            TEXTBOX4.Cut()
        Catch exc As Exception
            MessageBox.Show("قص", "خطا في القص", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub MNUPASTE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUPASTE.Click
=======
    Private Sub MNUPASTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUPASTE.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            TEXTBOX4.Paste()
        Catch exc As Exception
            MessageBox.Show("لصق", "لا يمكن لصق المحتوى", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub MNUSELALL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles MNUSELALL.Click
=======
    Private Sub MNUSELALL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUSELALL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            TEXTBOX4.SelectAll()
        Catch exc As Exception
            MessageBox.Show("تحديد", "لا يمكن تحديد جميع مكونات المستند", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmConnect_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FrmConnect_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub


<<<<<<< HEAD
    Private Sub FrmConnect_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmConnect_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.TEXTBOX3.Focus()
    End Sub

End Class