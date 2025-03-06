Imports System.Data.SqlClient
Public Class FormManagementCommittee
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveDataBase As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Private WithEvents SearchTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    ReadOnly CSH As Double = 0

<<<<<<< HEAD
    Private Sub FormManagementCommittee_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FormManagementCommittee_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
                Case Keys.F5
                    'PRINTBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDMC) FROM ManagementCommittee", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDMC) FROM ManagementCommittee", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            IDMC.Text = 1
        Else
            IDMC.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub FormManagementCommittee_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FormManagementCommittee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.BackgroundImage = img
<<<<<<< HEAD
            Me.BackWorker2 = New ComponentModel.BackgroundWorker With {
=======
            Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.BackWorker2.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:

        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            'If DelRow = True Then
            '    Me.ButtonXP5_Click(sender, e)
            '    Exit Sub
            'ElseIf e.Cancelled Then
            '    Exit Sub
            'End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("ManagementCommittee")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "تعديل ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "حذف ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "ترحيل الحركة الى الصندوق", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "تعديل ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "حذف ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.IDMC.Text.Trim, "إلغاء المراجعة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
            Click4 = False
            Click5 = False
            Click6 = False
            Click7 = False
            Click8 = False
            Click9 = False
            Click10 = False
            Click11 = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("ManagementCommittee").Rows.Count - 1 Then
            Forward = True
        End If
        Me.SHOWBUTTON()
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        If Me.RadioButton1.Checked = False Then
            Me.RadioButton2.Checked = True
        Else
            Me.RadioButton2.Checked = False
        End If
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

            Me.MAXRECORD()
            Me.TextMC6.Text = "MC" & Me.IDMC.Text
            Me.ComboMemberName.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.addv
=======
            Dim Sound As System.IO.Stream = My.Resources.addv
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        'If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.SAVEBUTTON.Enabled = False

        Static P As Integer
        P = Me.BS.Count
        Me.SAVERECORD()
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
        Me.BS.Position = P
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub
    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO ManagementCommittee( IDMC, MC1, MC2, MC3, MC4, MC5, MC6, MC7, USERNAME, CUser, COUser, da, ne) VALUES     ( @IDMC, @MC1, @MC2, @MC3, @MC4, @MC5, @MC6, @MC7, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO ManagementCommittee( IDMC, MC1, MC2, MC3, MC4, MC5, MC6, MC7, USERNAME, CUser, COUser, da, ne) VALUES     ( @IDMC, @MC1, @MC2, @MC3, @MC4, @MC5, @MC6, @MC7, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDMC", SqlDbType.Int).Value = Me.IDMC.Text
                .Parameters.Add("@MC1", SqlDbType.NVarChar).Value = Me.ComboMemberName.Text
                .Parameters.Add("@MC2", SqlDbType.NVarChar).Value = Me.TextNationalNo.Text
                .Parameters.Add("@MC3", SqlDbType.NVarChar).Value = Me.ComboAdescription.Text
                .Parameters.Add("@MC4", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
                .Parameters.Add("@MC5", SqlDbType.Date).Value = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MC6", SqlDbType.NVarChar).Value = Me.TextMC6.Text
                If Me.RadioButton1.Checked = True Then
                    .Parameters.Add("@MC7", SqlDbType.Bit).Value = True
                Else
                    .Parameters.Add("@MC7", SqlDbType.Bit).Value = False
                End If
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            Insert_Actions(Me.IDMC.Text.Trim, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then

            Else

                Me.Close()
            End If
        End If
    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT  IDMC, MC1, MC2, MC3, MC4, MC5, MC6, MC7, USERNAME, CUser, COUser, da, ne FROM ManagementCommittee  WHERE  CUser='", ModuleGeneral.CUser, "'ORDER BY IDMC"})
            }
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT  IDMC, MC1, MC2, MC3, MC4, MC5, MC6, MC7, USERNAME, CUser, COUser, da, ne FROM ManagementCommittee  WHERE  CUser='", ModuleGeneral.CUser, "'ORDER BY IDMC"})
            }
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "ManagementCommittee")
            Me.myds.RejectChanges()
            Consum.Close()


        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX3("AllCustomers", "cust2", "CUser", CUser, "cust33", Trim("True"), Me.ComboMemberName)
            Me.BS.DataSource = Me.myds.Tables("ManagementCommittee")
            RowCount = BS.Count
            IDMC.DataBindings.Add("text", BS, "IDMC", True, 1, "")
            ComboMemberName.DataBindings.Add("text", BS, "MC1", True, 1, "")
            TextNationalNo.DataBindings.Add("text", BS, "MC2", True, 1, "")
            ComboAdescription.DataBindings.Add("text", BS, "MC3", True, 1, "")
            TEXTPHONE.DataBindings.Add("text", BS, "MC4", True, 1, "")
            DateTimePicker1.DataBindings.Add("text", BS, "MC5", True, 1, "")
            TextMC6.DataBindings.Add("text", BS, "MC6", True, 1, "")
            RadioButton1.DataBindings.Add("Checked", BS, "MC7", True, 1, "")


            If Me.RadioButton1.Checked = False Then
                Me.RadioButton2.Checked = True
            Else
                Me.RadioButton2.Checked = False
            End If
            Call MangUsers()
            Me.RecordCount()
            Auditor("ManagementCommittee", "USERNAME", "IDMC", Me.IDMC.Text, "")
            Logentry = Uses
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update ManagementCommittee SET   MC1 = @MC1, MC2 = @MC2, MC3 = @MC3, MC4 = @MC4, MC5 = @MC5, MC6 = @MC6, MC7 = @MC7, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDMC = @IDMC", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update ManagementCommittee SET   MC1 = @MC1, MC2 = @MC2, MC3 = @MC3, MC4 = @MC4, MC5 = @MC5, MC6 = @MC6, MC7 = @MC7, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDMC = @IDMC", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDMC", SqlDbType.Int).Value = Me.IDMC.Text
                .Parameters.Add("@MC1", SqlDbType.NVarChar).Value = Me.ComboMemberName.Text
                .Parameters.Add("@MC2", SqlDbType.NVarChar).Value = Me.TextNationalNo.Text
                .Parameters.Add("@MC3", SqlDbType.NVarChar).Value = Me.ComboAdescription.Text
                .Parameters.Add("@MC4", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
                .Parameters.Add("@MC5", SqlDbType.Date).Value = Me.DateTimePicker1.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MC6", SqlDbType.NVarChar).Value = Me.TextMC6.Text
                If Me.RadioButton1.Checked = True Then
                    .Parameters.Add("@MC7", SqlDbType.Bit).Value = True
                Else
                    .Parameters.Add("@MC7", SqlDbType.Bit).Value = False
                End If
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If InternalAuditor = True Then
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                Else
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                End If
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            Insert_Actions(Me.IDMC.Text.Trim, "تعديل", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        'If Me.CheckBox3.Checked = True Then
        '    MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
        '    Exit Sub
        'End If
        Static P As Integer
        P = Me.BS.Position

        Me.UPDATERECORD()
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
        Click2 = True
    End Sub

<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.CancelEdit()

    End Sub




<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboMemberName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT cust3, cust14  FROM AllCustomers WHERE cust2 ='" & Me.ComboMemberName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMemberName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT cust3, cust14  FROM AllCustomers WHERE cust2 ='" & Me.ComboMemberName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextNationalNo.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TEXTPHONE.Text = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextNationalNo.Text = ""
            Me.TEXTPHONE.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
=======
    Private Sub ButtonX3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            GetAutoNumberMyDOCUMENTSFL(TextNationalNo.Text)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim f As New FrmJPG0
            f.Show()
=======
            Dim XLO As Int64
            XLO = Me.IDMC.Text
            Dim f As New FrmJPG0
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
<<<<<<< HEAD
            f.BS.EndEdit()
            f.BS.AddNew()
            f.MAXRECORD()
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextNationalNo.Text
            f.TEXTFileNo.Text = documentId
=======
            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMC6.Text
            f.TEXTFileNo.Text = Me.TEXTPHONE.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.TEXTFileSubject.Text = "مستندات لجنة الادارة / المراقبة"
            f.TextFileDescription.Text = "ارفاق مستندات لجنة الادارة / المراقبة"
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonX11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub ButtonX11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMC6.Text) & "'ORDER BY DOC1", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds41.Clear()
            SqlDataAdapter1.Fill(ds41, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds41
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds41.Tables(0).Rows.Count > 0 Then
                Dim DOC1 As String = Strings.Trim(ds41.Tables(0).Rows(0).Item(0))
                Dim LO As String = Trim(ds41.Tables(0).Rows(0).Item(1))
                index = f.BS.Find("DOC1", DOC1)
                f.Show()
                f.FrmJPG_Load(sender, e)
                f.TEXTBOX1.Text = Strings.Trim(DOC1)
                f.TextTransactionNumber.Text = Strings.Trim(LO)
                f.DanLOd()
                f.BS.Position = index
                f.PHOTO = True
                f.RecordCount()
                'If Me.CheckBox2.Checked = True Then
                '    f.PHOTOSCAN.Enabled = False
                '    f.LOGOBUTTON.Enabled = False
                '    f.EDITBUTTON.Enabled = False
                '    f.DELETEBUTTON.Enabled = False
                'End If
            Else
                MsgBox("لا يوجد اي مستندات", 64 + 524288, "تنبيه")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
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
        Me.RecordCount()
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
End Class