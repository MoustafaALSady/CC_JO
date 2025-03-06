Imports System.Data.SqlClient
Public Class FormMeetings
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
    Private Sub FormMeetings_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FormMeetings_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
        Dim SQL As New SqlCommand("SELECT MAX(IDME) FROM Meetings", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDME) FROM Meetings", Consum)
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
            IDME.Text = 1
        Else
            IDME.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub FormMeetings_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FormMeetings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Me.BS.DataSource = Me.myds.Tables("Meetings")
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
                    Insert_Actions(Me.IDME.Text.Trim, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "تعديل ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "حذف ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "ترحيل الحركة الى الصندوق", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "تعديل ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "حذف ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.IDME.Text.Trim, "إلغاء المراجعة", Me.Text)
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
        If Me.BS.Position < Me.myds.Tables("Meetings").Rows.Count - 1 Then
            Forward = True
        End If
        Me.SHOWBUTTON()
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
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
            Call MangUsers()
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

            'Me.MAXRECORD()
            GetAutoNumber("IDME", "Meetings", "ME3")
            Me.IDME.EditValue = AutoNumber
            'Year & "" & "/" & "" &
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Me.TextME10.Text = Me.IDME.Text
            Me.TextDecisions.Clear()
            Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.ComboDeferred_notDeferred.Focus()
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
        Me.SAVEBUTTON.Enabled = False
        Click1 = True
    End Sub
    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Meetings( IDME, ME1, ME2, ME3, ME4, ME5, ME6, ME7, ME8, ME9, ME10, USERNAME, CUser, COUser, da, ne) VALUES     ( @IDME, @ME1, @ME2, @ME3, @ME4, @ME5, @ME6, @ME7, @ME8, @ME9, @ME10, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Meetings( IDME, ME1, ME2, ME3, ME4, ME5, ME6, ME7, ME8, ME9, ME10, USERNAME, CUser, COUser, da, ne) VALUES     ( @IDME, @ME1, @ME2, @ME3, @ME4, @ME5, @ME6, @ME7, @ME8, @ME9, @ME10, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDME", SqlDbType.BigInt).Value = Me.IDME.EditValue
                .Parameters.Add("@ME1", SqlDbType.NVarChar).Value = Me.ComboAssociationName.Text
                .Parameters.Add("@ME2", SqlDbType.NVarChar).Value = Me.TextAssociationNationalNo.Text
                .Parameters.Add("@ME3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@ME4", SqlDbType.NVarChar).Value = Me.ComboMeetingType.Text.Trim
                .Parameters.Add("@ME5", SqlDbType.NVarChar).Value = Me.ComboDeferred_notDeferred.Text
                .Parameters.Add("@ME6", SqlDbType.Date).Value = Me.NewDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@ME7", SqlDbType.NVarChar).Value = Me.TextMeetingLocation.Text
                .Parameters.Add("@ME8", SqlDbType.NVarChar).Value = Me.TextDecisions.Text
                .Parameters.Add("@ME9", SqlDbType.NVarChar).Value = Me.ComboApproval.Text

                .Parameters.Add("@ME10", SqlDbType.NVarChar).Value = Me.TextME10.Text

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
            Insert_Actions(Me.IDME.Text.Trim, "حفظ", Me.Text)
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
                .CommandText = String.Concat(New String() {"SELECT  IDME, ME1, ME2, ME3, ME4, ME5, ME6, ME7, ME8, ME9, ME10, USERNAME, CUser, COUser, da, ne FROM Meetings  WHERE  CUser='", ModuleGeneral.CUser, "'ORDER BY IDME"})
            }
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT  IDME, ME1, ME2, ME3, ME4, ME5, ME6, ME7, ME8, ME9, ME10, USERNAME, CUser, COUser, da, ne FROM Meetings  WHERE  CUser='", ModuleGeneral.CUser, "'ORDER BY IDME"})
            }
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "Meetings")
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

            FILLCOMBOBOX1("COMPANY", "CMP2", "CUser", CUser, Me.ComboAssociationName)
            Me.BS.DataSource = Me.myds.Tables("Meetings")
            RowCount = BS.Count
            IDME.DataBindings.Add("text", BS, "IDME", True, 1, "")
            ComboAssociationName.DataBindings.Add("text", BS, "ME1", True, 1, "")
            TextAssociationNationalNo.DataBindings.Add("text", BS, "ME2", True, 1, "")
            DateMovementHistory.DataBindings.Add("text", BS, "ME3", True, 1, "")
            ComboMeetingType.DataBindings.Add("text", BS, "ME4", True, 1, "")
            ComboDeferred_notDeferred.DataBindings.Add("text", BS, "ME5", True, 1, "")
            NewDate.DataBindings.Add("text", BS, "ME6", True, 1, "")
            TextMeetingLocation.DataBindings.Add("text", BS, "ME7", True, 1, "")
            TextDecisions.DataBindings.Add("text", BS, "ME8", True, 1, "")
            ComboApproval.DataBindings.Add("text", BS, "ME9", True, 1, "")
            TextME10.DataBindings.Add("text", BS, "ME10", True, 1, "")
            Call MangUsers()
            Me.RecordCount()
            Auditor("Meetings", "USERNAME", "IDME", Me.IDME.EditValue, "")
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
            Dim SQL As New SqlCommand(" Update Meetings SET   ME1 = @ME1, ME2 = @ME2, ME3 = @ME3, ME4 = @ME4, ME5 = @ME5, ME6 = @ME6, ME7 = @ME7, ME8 = @ME8, ME9 = @ME9, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDME = @IDME", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update Meetings SET   ME1 = @ME1, ME2 = @ME2, ME3 = @ME3, ME4 = @ME4, ME5 = @ME5, ME6 = @ME6, ME7 = @ME7, ME8 = @ME8, ME9 = @ME9, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDME = @IDME", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDME", SqlDbType.BigInt).Value = Me.IDME.EditValue
                .Parameters.Add("@ME1", SqlDbType.NVarChar).Value = Me.ComboAssociationName.Text
                .Parameters.Add("@ME2", SqlDbType.NVarChar).Value = Me.TextAssociationNationalNo.Text
                .Parameters.Add("@ME3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@ME4", SqlDbType.NVarChar).Value = Me.ComboMeetingType.Text
                .Parameters.Add("@ME5", SqlDbType.NVarChar).Value = Me.ComboDeferred_notDeferred.Text
                .Parameters.Add("@ME6", SqlDbType.Date).Value = Me.NewDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@ME7", SqlDbType.NVarChar).Value = Me.TextMeetingLocation.Text
                .Parameters.Add("@ME8", SqlDbType.NVarChar).Value = Me.TextDecisions.Text
                .Parameters.Add("@ME9", SqlDbType.NVarChar).Value = Me.ComboApproval.Text
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
            Insert_Actions(Me.IDME.Text.Trim, "تعديل", Me.Text)
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
    Private Sub ComboAssociationName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboAssociationName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CMP5  FROM COMPANY WHERE CMP2 ='" & Me.ComboAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboAssociationName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAssociationName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CMP5  FROM COMPANY WHERE CMP2 ='" & Me.ComboAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextAssociationNationalNo.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextAssociationNationalNo.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
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
            Dim LOMyDOCUMENTSFL As Object
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim NumberMyDOCUMENTS As Object = "ME" & IDME.EditValue
            GetAutoNumberMyDOCUMENTSFL(NumberMyDOCUMENTS)
            LOMyDOCUMENTSFL = SEARCHDATA.NumberMyDOCUMENTSFL

            Dim f As New FrmJPG0
<<<<<<< HEAD
            f.Show()
=======
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
=======
            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = NumberMyDOCUMENTS
            f.TEXTFileNo.Text = LOMyDOCUMENTSFL
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
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim NumberMyDOCUMENTS As Object = "ME" & IDME.EditValue
            Dim str As New SqlCommand("SELECT DOC1, LO FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & NumberMyDOCUMENTS & "'ORDER BY DOC1", Consum)
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