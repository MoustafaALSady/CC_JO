Option Explicit Off

Imports System.Data.SqlClient

Public Class FormFiscalYear
<<<<<<< HEAD
    Inherits Form
=======
    Inherits System.Windows.Forms.Form
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

<<<<<<< HEAD
    Private Sub FormFiscalYear_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next

        Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
    Private Sub FormFiscalYear_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next

        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.RecordCount()
    End Sub

    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            TestNet = True
            Me.LoadDataBase()
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                .CommandText = "SELECT Year1, Year2, Year3, Year4, ye1, ye2, CUser, COUser FROM FiscalYear WHERE CUser='" & CUser & "' and ye1 ='" & True & "'"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.ds = New DataSet
                SqlDataAdapter1.Fill(Me.ds, "FiscalYear")
            End With
            Consum.Close()
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



    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("FiscalYear")
            Me.RowCount = Me.BS.Count
            Me.TextYear1.DataBindings.Add("text", Me.BS, "Year1", True, 1, "")
            Me.OpeningDate.DataBindings.Add("text", Me.BS, "Year2", True, 1, "")
            Me.FinalDate.DataBindings.Add("text", Me.BS, "Year3", True, 1, "")
            Me.CurrentDate.DataBindings.Add("text", Me.BS, "Year4", True, 1, "")
            Me.CheckActiveFiscalYear.DataBindings.Add("Checked", Me.BS, "YE1", True, 1, "")
            'Me.CheckInactiveFiscalYear.DataBindings.Add("Checked", Me.BS, "YE2", True, 1, "")
            Me.Textcuser.DataBindings.Add("text", Me.BS, "cuser", True, 1, "")
            Me.Textcouser.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TextFiscalYear.Text = FiscalYear_currentDateMustBeInFiscalYear()
            Me.TextYear.Text = Year(ServerDateTime.Date.ToString.Trim)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False

            ActiveFiscalYear = CheckActiveFiscalYear.Checked
            'InactiveFiscalYear = CheckInactiveFiscalYear.Checked
            'MethodActiveFiscalYear()
            Me.CheckActiveFiscalYear.Checked = mykey.GetValue("ActiveFiscalYear", False)
            'Me.CheckInactiveFiscalYear.Checked = mykey.GetValue("InactiveFiscalYear", False)
            Me.CurrentDate.Value = ServerDateTime.Date.ToString("yyyy-MM-dd")

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
                Me.label5.ForeColor = Color.Yellow
                Me.label5.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
                Me.label5.Visible = False
            Else
                Me.label5.ForeColor = Color.Red
                Me.label5.Text = "الاتصال بالانترنت غير متوفر"
<<<<<<< HEAD
                Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
                Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.ConnectDataBase.RunWorkerAsync()
            End If
        End If
    End Sub

    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO FiscalYear(   Year2, Year3, Year4, YE1,  CUser, COUser) VALUES     ( @Year2, @Year3, @Year4, @YE1 , @CUser, @COUser)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO FiscalYear(   Year2, Year3, Year4, YE1,  CUser, COUser) VALUES     ( @Year2, @Year3, @Year4, @YE1 , @CUser, @COUser)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@Year2", SqlDbType.Date).Value = Me.OpeningDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@Year3", SqlDbType.Date).Value = CDate(Me.FinalDate.Value.ToString("yyyy-MM-dd"))
                .Parameters.Add("@Year4", SqlDbType.Date).Value = CDate(Me.CurrentDate.Value.ToString("yyyy-MM-dd"))
                .Parameters.Add("@YE1", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckActiveFiscalYear.Checked)
                '.Parameters.Add("@YE2", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckInactiveFiscalYear.Checked)
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update FiscalYear SET   Year2 = @Year2, Year3 = @Year3, Year4 = @Year4, YE1 = @YE1 WHERE Year1 = @Year1", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update FiscalYear SET   Year2 = @Year2, Year3 = @Year3, Year4 = @Year4, YE1 = @YE1 WHERE Year1 = @Year1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@Year1", SqlDbType.NVarChar).Value = Me.TextYear1.Text
                .Parameters.Add("@Year2", SqlDbType.Date).Value = Me.OpeningDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@Year3", SqlDbType.Date).Value = Me.FinalDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@Year4", SqlDbType.Date).Value = Me.CurrentDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@YE1", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckActiveFiscalYear.Checked)
                '.Parameters.Add("@YE2", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckInactiveFiscalYear.Checked)
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub MAXRECORD()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(Year1) FROM FiscalYear", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(Year1) FROM FiscalYear", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
            V = .ExecuteScalar()
        End With
        Me.TextYear1.Text = Val(V) + 1
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim StartDateTime As DateTime
        Dim EndDateTime As DateTime
        Dim T As Boolean
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If Complete = True Then
            LockSave = True
        Else
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

        End If

        StartDateTime = Me.OpeningDate.Value
        EndDateTime = Me.FinalDate.Value
        T = CheckActiveFiscalYear.Checked
        'If FiscalYear_currentDateMustBeInFiscalYear() < TextBox3.Text Then
        '    MessageBox.Show("بداية السنة الحالي: " & FiscalYear_currentDateMustBeInFiscalYear() & _
        '             Chr(10) & Chr(13) & "نهاية السنة الحالي: " & FiscalYear_currentDateMustBeInFiscalYear())
        '    Exit Sub
        'End If
        'If FiscalYear_closed() = False Then
        '    MsgBox("السنة المالية نشطة", 16, "تنبيه")
        '    Exit Sub
        'End If

        'insert_FiscalYear(TextBox1.Text, fiscalYearStart.Value, fiscalYearEnd.Value, ServerDateTime.ToString("yyyy-MM-dd"))
        Static P As Integer
        P = Me.BS.Count
        Me.SAVERECORD()
        Me.RecordCount()
        Me.SAVEBUTTON.Enabled = False
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
        Me.BS.Position = P + 1
        Insert_Actions(Me.TextYear1.Text.Trim, "حفظ", Me.Text)

    End Sub

    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        txtDisplayPageNo.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("FiscalYear").Rows.Count - 1 Then
            Forward = True
        End If
        Me.btnFirstPage.Enabled = Back
        Me.btnPreviousPage.Enabled = Back
        Me.btnNextPage.Enabled = Forward
        Me.btnLastPage.Enabled = Forward

    End Sub

<<<<<<< HEAD
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.RecordCount()
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'SqlDataAdapter1.Update(Me.ds, "FiscalYear")
            'Me.ds = New DataSet
            'SqlDataAdapter1.Fill(Me.ds, "FiscalYear")
            'SAVERECORD()
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
                MsgBox("يوجد تكرار في رقم الهاتف المدخل", 16, "تنبيه")
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
            Me.BS.DataSource = Me.ds.Tables("FiscalYear")
            'Me.TextBox5.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
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
        End If
    End Sub

<<<<<<< HEAD
    Private Sub FiscalYearStart_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        FiscalYear_currentDateMustBeInFiscalYear()
    End Sub

    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub FiscalYearStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FiscalYear_currentDateMustBeInFiscalYear()
    End Sub

    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Complete = True Then
                LockAddRow = True
            Else
                If LockAddRow = False Then
                    MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                    Exit Sub
                End If
            End If

            Dim n As Integer
            n = Me.BS.Count
            Me.BS.Position = Me.BS.Count - 1
            Me.BS.EndEdit()
            Application.DoEvents()
            Me.BS.AddNew()
            Me.MAXRECORD()
            'Me.TextBox5.Text = ServerDateTime.Day.ToString("1") + "-" + ServerDateTime.Minute.ToString("1") + "-" + (Year(ServerDateTime) + "1").ToString("yyyy-MM-dd").Trim
            'Me.TextBox4.Text = ServerDateTime.Day.ToString("31") + "-" + ServerDateTime.Minute.ToString("12") + "-" + (Year(ServerDateTime) + "1").ToString("yyyy-MM-dd").Trim
            Me.Textcuser.Text = CUser
            Me.Textcouser.Text = COUser
            Me.OpeningDate.Value = CDate(ServerDateTime.Day.ToString("1") + "-" + ServerDateTime.Minute.ToString("1") + "-" + (Year(ServerDateTime) + "1").ToString.Trim)
            Me.FinalDate.Value = CDate(ServerDateTime.Day.ToString("31") + "-" + ServerDateTime.Minute.ToString("12") + "-" + (Year(ServerDateTime) + "1").ToString.Trim)
            Me.CurrentDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.CheckActiveFiscalYear.Checked = True
            'Me.CheckInactiveFiscalYear.Checked = False
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
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnLastPage.Click
=======
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
    End Sub

<<<<<<< HEAD
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNextPage.Click
=======
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
    End Sub

<<<<<<< HEAD
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnPreviousPage.Click
=======
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
    End Sub

<<<<<<< HEAD
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnFirstPage.Click
=======
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstPage.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
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
        If Complete = True Then
            LockUpdate = True
        Else
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
        End If

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
        Insert_Actions(Me.TextYear1.Text.Trim, "تعديل", Me.Text)
    End Sub

    Private Sub CheckActiveFiscalYear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckActiveFiscalYear.CheckedChanged
        MethodActiveFiscalYear()
    End Sub
    'Private Sub CheckInactiveFiscalYear_CheckedChanged(sender As Object, e As EventArgs) Handles CheckInactiveFiscalYear.CheckedChanged
    '    MethodActiveFiscalYear()
    'End Sub

    Private Sub MethodActiveFiscalYear()
        If Me.CheckActiveFiscalYear.Checked = True Then
            mykey.SetValue("ActiveFiscalYear", True)
            'Me.CheckInactiveFiscalYear.Enabled = False
        Else
            mykey.SetValue("ActiveFiscalYear", False)
            'Me.CheckInactiveFiscalYear.Enabled = True
        End If
        'If Me.CheckInactiveFiscalYear.Checked = True Then
        '    mykey.SetValue("InactiveFiscalYear", True)
        '    'CheckActiveFiscalYear.Enabled = False
        'Else
        '    mykey.SetValue("InactiveFiscalYear", False)
        '    'CheckActiveFiscalYear.Enabled = True
        'End If
    End Sub

End Class