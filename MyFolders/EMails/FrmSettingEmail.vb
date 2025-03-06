Imports System.Data.OleDb

Imports System.Data.SqlClient

Public Class FrmSettingEmail

    Private ReadOnly cmd As New SqlCommand
    Private SqlDataAdapter1 As New SqlDataAdapter
    Public ds As New DataSet
    Dim WithEvents BS As New BindingSource
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0


<<<<<<< HEAD
    Private Sub FrmSettingEmail_KeyDown1(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmSettingEmail_KeyDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)
                Case Keys.F3
                    EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    BUTTONCANCEL_Click(sender, e)
                Case Keys.Delete
                    DELETEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmSettingEmail_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmSettingEmail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next

<<<<<<< HEAD
            Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
            Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.ConnectDataBase.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '==============================
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = True
        Me.RecordCount()
        Consum.Close()
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())


<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT FIELD1, FIELD2, FIELD3, FIELD4, FIELD5, FIELD6, upsize_ts, CUser, COUser, da, ne FROM TSettingEmail  WHERE  CUser='" & CUser & "' ORDER BY Field1"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.ds.Clear()
                Me.ds = New DataSet
                SqlDataAdapter1.Fill(Me.ds, "TSettingEmail")
            End With
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If TestNet = True Then

        Else
            Me.Close()
        End If

    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("TSettingEmail")
            Me.RowCount = Me.BS.Count
            Me.TextCod.DataBindings.Add("text", Me.BS, "Field1", True, 1, "")
            Me.TextSmtp.DataBindings.Add("text", Me.BS, "Field2", True, 1, "")
            Me.TextPort.DataBindings.Add("text", Me.BS, "Field3", True, 1, "")
            Me.TextEmail.DataBindings.Add("text", Me.BS, "Field4", True, 1, "")
            Me.TextPws.DataBindings.Add("text", Me.BS, "Field5", True, 1, "")
            Me.TextUserName.DataBindings.Add("text", Me.BS, "Field6", True, 1, "")
            Me.Textcuser.DataBindings.Add("text", Me.BS, "cuser", True, 1, "")
            Me.TextCOUser.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try

1:
            SqlDataAdapter1.Update(Me.ds, "TSettingEmail")
            Me.ds = New DataSet
            SqlDataAdapter1.Fill(Me.ds, "TSettingEmail")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                Me.DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then

                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.ds.Tables("TSettingEmail")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            Me.Label1.Text = Now
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
    End Sub
<<<<<<< HEAD
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("TSettingEmail").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
    End Sub
<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.ADDBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = False
        Dim n As Double
        Dim s As Double
        n = BS.Count
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        s = Val(Me.TextCod.Text)
        Me.BS.EndEdit()
        Me.BS.AddNew()
        If n = 0 Then
            Me.TextCod.Text = 1
        Else
            If n >= s Then
                Me.TextCod.Text = Val(n) + 1
            Else
                Me.TextCod.Text = Val(s) + 1
            End If
        End If

        Me.TextSmtp.Focus()
        Me.TextSmtp.Text = ""
        Me.TextPort.Text = ""
        Me.TextEmail.Text = "587"
        Me.TextUserName.Text = ""
        Me.TextPws.Text = ""
        Me.Textcuser.Text = CUser
        Me.TextCOUser.Text = COUser
    End Sub
<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Static P As Integer
        P = Me.BS.Count
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.Textcuser.Text = CUser.ToString.Trim
            Me.TextCOUser.Text = COUser.ToString.Trim
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Static n As Integer
        n = Me.BS.Position

        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.Textcuser.Text = CUser
            Me.TextCOUser.Text = COUser
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.BS.CancelEdit()
    End Sub
<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If LockDelete = True Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim resault As Integer
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("سبنم حذف السجل الحالى", "حذف سجل ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    cmd.Connection = Consum
                    cmd.CommandText = "delete from TSettingEmail where FIELD1=" & TextCod.Text
                    Consum.Open()
                    cmd.ExecuteNonQuery()
                    MessageBox.Show(" تمت عملية الحذف", "حذف بيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Consum.Close()
                    FrmSettingEmail_Load(sender, e)
                Else
                    MessageBox.Show("تم ايقاف عملية الحذف", "حذف سجل", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" لايوجد سجل حالى لاتمام عملية الحذف", "حذف سجل", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As OleDbException
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX4_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextEmail.TextChanged
=======
    Private Sub TEXTBOX4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmail.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim server, user, password As String
            server = ""
            user = Me.TextEmail.Text.Trim()
            password = Me.TextUserName.Text.Trim()
            If user.Contains("yahoo.com") Then
                server = "smtp.mail.yahoo.com"
                Me.TextSmtp.Text = server
                Me.TextPort.Text = "587"
            ElseIf user.Contains("hotmail.com") Or user.Contains("live.com") Then
                server = "smtp.live.com"
                Me.TextSmtp.Text = server
                Me.TextPort.Text = "465"
            ElseIf user.Contains("gmail.com") Then
                server = "smtp.gmail.com"
                Me.TextSmtp.Text = server
                Me.TextPort.Text = "587"
            Else
                Me.TextSmtp.Text = ""
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextCOUser.TextChanged

    End Sub
End Class