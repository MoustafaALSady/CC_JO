
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FormEmployees3
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim WithEvents BS As New BindingSource
    Dim ds As New DataSet

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private Delegate Sub LoadDataBaseCallBack()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private ReadOnly OverTimeH As DateTime

    Private Sub FrmEmployees3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
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
                        PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        ButtonXP3_Click(sender, e)
                    Case Keys.F10
                        ButtonCUSTOMER1_Click(sender, e)
                    Case Keys.PageDown
                        PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmEmployees3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next

        ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        ConnectDataBase.RunWorkerAsync()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If BS.Position < ds.Tables("EXTRAWORK").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        SHOWBUTTON()
        InternalAuditorType()
        Me.SAVEBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = True
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        RecordCount()
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            ds.EnforceConstraints = False
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT EWRK1, EWRK2, EWRK3, DateEwrk, EWRK4, EWRK5, EWRK6, EWRK7, EWRK8, EWRK9, EWRK10, EWRK11, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM EXTRAWORK   WHERE  CUser='" & CUser & "' and Year(DateEwrk) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY EWRK1"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "EXTRAWORK")
                BS.DataSource = ds
                BS.DataMember = "EXTRAWORK"
            End With
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Me.BS.DataSource = Me.ds.Tables("EXTRAWORK")
            RowCount = Me.BS.Count


            Me.TEXT1.DataBindings.Add("text", Me.BS, "EWRK1", True, 1, "")
            Me.ComboEmployeeName.DataBindings.Add("text", Me.BS, "EWRK2", True, 1, "")
            Me.ComboMonths.DataBindings.Add("text", Me.BS, "EWRK3", True, 1, "")
            Me.DateMovementHistory.DataBindings.Add("text", Me.BS, "DateEwrk", True, 1, "")

            'Me.TimeAttendance.Text = Me.ds.Tables("DateEwrk").Rows(Me.BS.Position)("EWRK4").ToString
            'Me.TimeToLeave.Value = Me.ds.Tables("DateEwrk").Rows(Me.BS.Position)("EWRK5").ToString
            'Me.TEXTBasicWorkingHours.Text = Me.ds.Tables("DateEwrk").Rows(Me.BS.Position)("EWRK6")
            'Me.TEXTOvertimeHours.Text = Me.ds.Tables("DateEwrk").Rows(Me.BS.Position)("EWRK7")

            Me.TimeAttendance.DataBindings.Add("text", Me.BS, "EWRK4", True, 1, "")
            Me.TimeToLeave.DataBindings.Add("text", Me.BS, "EWRK5", True, 1, "")
            Me.TEXTBasicWorkingHours.DataBindings.Add("text", Me.BS, "EWRK6", True, 1, "")
            Me.TEXTOvertimeHours.DataBindings.Add("text", Me.BS, "EWRK7", True, 1, "")
            Me.TEXTEmployeeCode.DataBindings.Add("text", Me.BS, "EWRK8", True, 1, "")

            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "EWRK10", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "EWRK11", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CoUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")

            'OverTimeH = Date.Parse(TEXTOvertimeHours.Text).ToString("mm:hh")
            'TEXTOvertimeHours.Text = OverTimeH.ToString("mm:hh")
            Auditor("EXTRAWORK", "USERNAME", "EWRK1", Me.TEXT1.Text, "")
            Logentry = Uses
            'If ds.Tables("EXTRAWORK").Rows.Count > 0 Then Me.TextOvertimeHourValue.EditValue = SumExtraValuePercentage()
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboEmployeeName)
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboEmployeeName1)
            Call MangUsers()
            RecordCount()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim N As Double
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(EWRK1) FROM EXTRAWORK", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()
            Dim SQL As String = "INSERT INTO EXTRAWORK( EWRK2, EWRK3, DateEwrk, EWRK4, EWRK5, EWRK6, EWRK7, EWRK8, EWRK9, EWRK10, EWRK11, USERNAME, Cuser, COUSER, da, ne) VALUES     ( @EWRK2, @EWRK3, @DateEwrk, @EWRK4, @EWRK5, @EWRK6, @EWRK7, @EWRK8, @EWRK9, @EWRK10, @EWRK11, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EWRK1", SqlDbType.Int).Value = Val(N) + 1
                .Parameters.Add("@EWRK2", SqlDbType.NVarChar).Value = Me.ComboEmployeeName.Text
                .Parameters.Add("@EWRK3", SqlDbType.NVarChar).Value = Me.ComboMonths.Text
                .Parameters.Add("@DateEwrk", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString
                .Parameters.Add("@EWRK4", SqlDbType.DateTime).Value = Me.TimeAttendance.Value
                .Parameters.Add("@EWRK5", SqlDbType.DateTime).Value = Me.TimeToLeave.Value
                .Parameters.Add("@EWRK6", SqlDbType.NVarChar).Value = Me.TEXTBasicWorkingHours.EditValue
                .Parameters.Add("@EWRK7", SqlDbType.NVarChar).Value = Me.TEXTOvertimeHours.Text
                .Parameters.Add("@EWRK8", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.Text
                .Parameters.Add("@EWRK9", SqlDbType.NVarChar).Value = ""
                .Parameters.Add("@EWRK10", SqlDbType.Bit).Value = Convert.ToInt32(CheckTransferAccounts.Checked)
                .Parameters.Add("@EWRK11", SqlDbType.Bit).Value = Convert.ToInt32(CheckLogReview.Checked)
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update EXTRAWORK SET  EWRK2 = @EWRK2, EWRK3 = @EWRK3, DateEwrk = @DateEwrk, EWRK4 = @EWRK4, EWRK5 = @EWRK5, EWRK6 = @EWRK6, EWRK7 = @EWRK7, EWRK8 = @EWRK8, EWRK9 = @EWRK9, EWRK10 = @EWRK10, EWRK11 = @EWRK11, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE EWRK1 = @EWRK1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EWRK1", SqlDbType.Int).Value = Me.TEXT1.Text
                .Parameters.Add("@EWRK2", SqlDbType.NVarChar).Value = Me.ComboEmployeeName.Text
                .Parameters.Add("@EWRK3", SqlDbType.NVarChar).Value = Me.ComboMonths.Text
                .Parameters.Add("@DateEwrk", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString
                .Parameters.Add("@EWRK4", SqlDbType.DateTime).Value = Me.TimeAttendance.Value
                .Parameters.Add("@EWRK5", SqlDbType.DateTime).Value = Me.TimeToLeave.Value
                .Parameters.Add("@EWRK6", SqlDbType.NVarChar).Value = Me.TEXTBasicWorkingHours.EditValue
                .Parameters.Add("@EWRK7", SqlDbType.NVarChar).Value = Me.TEXTOvertimeHours.Text
                .Parameters.Add("@EWRK8", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.Text
                .Parameters.Add("@EWRK9", SqlDbType.NVarChar).Value = ""
                .Parameters.Add("@EWRK10", SqlDbType.Bit).Value = Convert.ToInt32(CheckTransferAccounts.Checked)
                .Parameters.Add("@EWRK11", SqlDbType.Bit).Value = Convert.ToInt32(CheckLogReview.Checked)
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If InternalAuditor = True Then
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                    .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                Else
                    .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                    .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                    .Parameters.Add("@da1", SqlDbType.NVarChar).Value = DBNull.Value
                    .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = DBNull.Value
                End If
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        RECORDSLABEL.Text = BS.Position + 1 & " من " & BS.Count
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try

1:
            ''Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            ''myBuilder.GetUpdateCommand()
            ''SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            ''If Consum.State = ConnectionState.Open Then Consum.Close()
            ''Consum.Open()
            'SqlDataAdapter1.Update(ds, "EXTRAWORK")
            'ds = New DataSet
            'SqlDataAdapter1.Fill(ds, "EXTRAWORK")
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
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                ds = New DataSet
                SqlDataAdapter1.Fill(ds, "EXTRAWORK")
                Exit Sub
            ElseIf e.Cancelled Then

                Exit Sub
            End If
            Application.DoEvents()
            BS.DataSource = ds.Tables("EXTRAWORK")
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            Count()
            Label1.Text = Now
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            Me.SAVEBUTTON.Enabled = False
            Consum.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            PictureBox5.Visible = False
            ComboEmployeeName.Focus()
            ComboEmployeeName.SelectAll()
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboEmployeeName1.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboEmployeeName1.Enabled = False
    End Sub
    Private Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboEmployeeName.KeyDown, TEXTUserName.KeyDown, TEXTReferenceName.KeyDown, TEXTReviewDate.KeyDown, ComboMonths.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub CLEARDATA()
        On Error Resume Next
        Dim txt As Control
        For Each txt In Me.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
        Next
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(EWRK1) FROM EXTRAWORK", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            TEXT1.Text = 1
        Else
            TEXT1.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub

    Private Sub DateTimePicker2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimeToLeave.TextChanged, TimeAttendance.TextChanged, TEXTBasicWorkingHours.EditValueChanged
        On Error Resume Next
        Dim F As Double
        F = DateDiff(DateInterval.Minute, Me.TimeAttendance.Value, Me.TimeToLeave.Value) / 60
        Me.TEXTOvertimeHours.EditValue = Format(F - Val(Me.TEXTBasicWorkingHours.EditValue), "0.00")
    End Sub


    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        RecordCount()
        SAVEBUTTON.Enabled = False
        Me.Cursor = Cursors.WaitCursor
        PictureBox2.Visible = True
        UPDATERECORD()
        BS.EndEdit()
        RowCount = BS.Count
        SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveTab.RunWorkerAsync()
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXT1.Text, "المراجع", Me.Text)
        BS.Position = P
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckLogReview.Checked = False Then
            MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        PictureBox2.Visible = True
        UPDATERECORD()
        BS.EndEdit()
        RowCount = BS.Count
        SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveTab.RunWorkerAsync()
        BS.Position = P
        Insert_Actions(Me.TEXT1.Text, "إلغاء المراجعة", Me.Text)
        MsgBox("تمت عملية إلغاءالمراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboEmployeeName, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboEmployeeName1, e, )
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل  الى الموظـف", 16, "تنبيه")
            Exit Sub
        End If
        On Error Resume Next
        Static P As Integer
        P = BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        PictureBox2.Visible = True
        UPDATERECORD()
        BS.EndEdit()
        RowCount = BS.Count
        SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveTab.RunWorkerAsync()
        RecordCount()
        Insert_Actions(Me.TEXT1.Text, "تعديل", Me.Text)
        Me.SAVEBUTTON.Enabled = False
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        ComboEmployeeName_SelectedIndexChanged(sender, e)
        PictureBox2.Visible = True
        SAVERECORD()
        BS.EndEdit()
        RowCount = BS.Count
        SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveTab.RunWorkerAsync()
        BS.Position = P
        SHOWBUTTON()
        SAVEBUTTON.Enabled = False
        Insert_Actions(Me.TEXT1.Text, "حفظ", Me.Text)

    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()
        RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position + 1
        RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position - 1
        RecordCount()
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        BS.Position = 0
        RecordCount()
    End Sub
    Private Function SumAmountEMP() As Double
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT Sum(EWRK7) AS SUMSUBTOTALS  FROM EXTRAWORK WHERE EWRK8 = '" & Me.TEXTEmployeeCode.Text & "'" & " ", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                SumAmountEMP = Format(ds.Tables(0).Rows(0).Item(0), "0.00")
            Else
                SumAmountEMP = "0.00"
            End If
            Adp.Dispose()
            Consum.Close()
            SumAmountEMP = Format(TextOvertimeHourValue.EditValue * SumAmountEMP, "0.00")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSumExtraValuePercentage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return SumAmountEMP()
        End Try
    End Function
    Private Function SumExtraValuePercentage() As Double
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT SLY24  FROM SALARIES WHERE SLYCod = '" & Me.TEXTEmployeeCode.Text & "' ORDER BY SLY26 DESC ", Consum)

            'Dim query As String = "SELECT [First Name], RunningSpeed FROM Trainee ORDER BY RunningSpeed DESC"
            ' Execute the query and populate your listbox or other data structure with the results


            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                SumExtraValuePercentage = Format((ds.Tables(0).Rows(0).Item(0) / 208) * 1.5, "0.000")
            Else
                SumExtraValuePercentage = "0.000"
            End If

            Adp.Dispose()
            Consum.Close()
            Return SumExtraValuePercentage
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSumExtraValuePercentage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return SumExtraValuePercentage
        End Try

    End Function

    Private Sub UPDATEALLCUSTOMERS2()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update EMPLOYEES SET  EMP23 = @EMP23  WHERE EMP1 = @EMP1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EMP1", SqlDbType.Int).Value = Me.TEXTEmployeeCode.Text.Trim
                .Parameters.Add("@EMP23", SqlDbType.Float).Value = SumAmountEMP()

                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim f As New FrmPRINT
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim txt As TextObject
        On Error Resume Next
        If Me.RadioButton1.Checked Then
            Dim rpt As New rptEmployees14
            If Len(Me.ComboMonths1.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل اسم الشهر", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                ComboMonths1.Focus()
                Exit Sub
            End If
            If Len(Me.ComboEmployeeName.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل اسم الموظف", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                ComboEmployeeName.Focus()
                Exit Sub
            End If
            Dim Consum As New SqlClient.SqlConnection(constring)
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM EXTRAWORK   WHERE  CUser='" & CUser & "' and Year(DateEwrk) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EWRK3 like '" & Me.ComboMonths1.Text & "' AND EWRK2 like '" & ComboEmployeeName1.Text & "'", Consum)
            Dim builder24 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EXTRAWORK")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text1")
            txt.Text = "خلال شهر  " & Me.ComboMonths1.Text
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton2.Checked Then
            Dim rpt As New rptEmployees14
            If Len(Me.ComboMonths1.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل اسم الشهر  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths1.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM EXTRAWORK   WHERE  CUser='" & CUser & "' and Year(DateEwrk) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EWRK3 like '" & Me.ComboMonths1.Text & "'", Consum)
            Dim builder24 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EXTRAWORK")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text1")
            txt.Text = "خلال شهر  " & Me.ComboMonths1.Text
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton3.Checked Then
            Dim rpt As New rptEmployees14
            If Len(Me.ComboMonths1.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل اسم الشهر  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths1.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM EXTRAWORK   WHERE  CUser='" & CUser & "' and Year(DateEwrk) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EWRK11 ='" & False & "'", Consum)
            Dim builder24 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EXTRAWORK")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text1")
            txt.Text = "خلال شهر  " & Me.ComboMonths1.Text
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded

            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()

        End If
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل  الى الموظـف", 16, "تنبيه")
            Exit Sub
        End If
        MYDELETERECORD("EXTRAWORK", "EWRK1", TEXT1, BS, True)
        FrmEmployees3_Load(sender, e)
        Insert_Actions(Me.TEXT1.Text.Trim, "حذف", Me.Text)
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        ADDBUTTON.Enabled = False
        EDITBUTTON.Enabled = False
        SAVEBUTTON.Enabled = True
        BUTTONCANCEL.Enabled = True
        DELETEBUTTON.Enabled = False
        InternalAuditorERBUTTON.Enabled = False
        PRINTBUTTON.Enabled = False
        BS.EndEdit()
        BS.AddNew()
        CLEARDATA1(Me)
        CLEARDATA()
        MAXRECORD()
        Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.TEXTBasicWorkingHours.EditValue = "8.00"
        Me.TimeAttendance.Value = "08:00  AM"
        Me.TimeToLeave.Value = "04:00  PM"
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.CheckLogReview.Checked = False
        Me.CheckTransferAccounts.Checked = False
        InternalAuditorType()
        ComboEmployeeName.Focus()
        Count()
        'Me.SAVEBUTTON.Enabled = True
        'Me.BUTTONCANCEL.Enabled = True
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonTransferToEmployee.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.Panel1.Enabled = False
            Me.Panel2.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonTransferToEmployee.Enabled = True
            Me.Panel1.Enabled = True
            Me.Panel2.Enabled = True
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonTransferToEmployee.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.Panel1.Enabled = False
            Me.Panel2.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.Panel1.Enabled = True
            Me.Panel2.Enabled = True
        End If
    End Sub
    Private Sub ComboEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmployeeName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboEmployeeName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTEmployeeCode.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TextOvertimeHourValue.EditValue = SumExtraValuePercentage()
        Else
            Me.TEXTEmployeeCode.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub ButtonCUSTOMER1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferToEmployee.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
            Exit Sub
        End If
        Dim resault As Integer
        resault = MessageBox.Show("سبنم تحديث الرصيد للموظف " & Me.TextOvertimeHourValue.EditValue, "ترحيل الرصيد", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        If resault = vbYes Then
            UPDATEALLCUSTOMERS2()
            Me.CheckTransferAccounts.Checked = True
            UPDATERECORD()
            SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
            SaveTab.RunWorkerAsync()
            RecordCount()
            Insert_Actions(Me.TEXT1.Text, "تحديث الرصيد للموظف" & " " & Me.ComboEmployeeName.Text, Me.Text)
        Else
            Exit Sub
        End If
    End Sub

End Class