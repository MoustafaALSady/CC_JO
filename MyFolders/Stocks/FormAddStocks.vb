



Imports System.Data.SqlClient
Public Class FormAddStocks

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
    Private Sub FormAddStocks_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)
                Case Keys.F3
                    EDITBUTTON_Click(sender, e)
                Case Keys.F4
                    'BUTTONCANCEL_Click(sender, e)
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
    Private Sub FormAddStocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Integer
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(WarehouseNumber) FROM Warehouses  WHERE CUser='" & CUser & "'", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(WarehouseNumber) FROM Warehouses  WHERE CUser='" & CUser & "'", Consum)
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
            Me.TextWarehouseNumber.Text = CUser & 1
        Else
            Me.TextWarehouseNumber.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ButAdd.Enabled = LockAddRow
        Me.ButSave.Enabled = LockSave
        Me.ButEdit.Enabled = LockUpdate
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
            Me.BS.DataSource = Me.myds.Tables("Warehouses")
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
        If Me.BS.Position < Me.myds.Tables("BankNames").Rows.Count - 1 Then
            Forward = True
        End If
        Me.SHOWBUTTON()
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.ButAdd.Enabled = True
        Me.ButSave.Enabled = False
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButAdd.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButAdd.Click
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
            MAXRECORD()
            Me.TextWarehouseName.Text = ""
            Me.TextLocation.Text = ""


            Me.ButAdd.Enabled = False
            Me.ButSave.Enabled = True
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
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButSave.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButSave.Click
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
        Me.ButSave.Enabled = False
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
        Me.ButAdd.Enabled = True
        Me.ButSave.Enabled = False
    End Sub
    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Warehouses(  WarehouseNumber, WarehouseName, Location,USERNAME, CUser, COUser) VALUES     ( @WarehouseNumber,  @WarehouseName, @Location,@USERNAME,  @CUser, @COUser)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO Warehouses(  WarehouseNumber, WarehouseName, Location,USERNAME, CUser, COUser) VALUES     ( @WarehouseNumber,  @WarehouseName, @Location,@USERNAME,  @CUser, @COUser)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@WarehouseNumber", SqlDbType.Int).Value = Me.TextWarehouseNumber.Text.Trim
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text.Trim
                .Parameters.Add("@Location", SqlDbType.NVarChar).Value = Me.TextLocation.Text.Trim
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            Insert_Actions(Me.TextIDW.Text.Trim, "حفظ", Me.Text)
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
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandText = String.Concat(New String() {"SELECT  IDW,  WarehouseNumber , WarehouseName, Location,CUser, COUser FROM Warehouses  WHERE  CUser='", ModuleGeneral.CUser, "'ORDER BY IDW"})
            }
            'strSQL.CommandText = "SELECT  IDW, WarehouseName, Location, WarehouseNumber , CUser, COUser FROM Warehouses  WHERE  CUser='" & CUser & "'ORDER BY IDW"

<<<<<<< HEAD
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "Warehouses")
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
            Me.BS.DataSource = Me.myds.Tables("Warehouses")
            RowCount = Me.BS.Count
            Me.TextIDW.DataBindings.Add("text", BS, "IDW", True, 1, "")
            Me.TextWarehouseNumber.DataBindings.Add("text", BS, "WarehouseNumber", True, 1, "")
            Me.TextWarehouseName.DataBindings.Add("text", BS, "WarehouseName", True, 1, "")
            Me.TextLocation.DataBindings.Add("text", BS, "Location", True, 1, "")


            Call MangUsers()
            Me.RecordCount()
            Me.ButAdd.Enabled = True
            Me.ButSave.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update Warehouses SET  WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, Location = @Location  WHERE IDW = @IDW", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update Warehouses SET  WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, Location = @Location  WHERE IDW = @IDW", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDW", SqlDbType.Int).Value = Me.TextIDW.Text
                .Parameters.Add("@WarehouseNumber", SqlDbType.Int).Value = Me.TextWarehouseNumber.Text.Trim
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text.Trim
                .Parameters.Add("@Location", SqlDbType.NVarChar).Value = Me.TextLocation.Text.Trim

                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            Insert_Actions(Me.TextIDW.Text.Trim, "تعديل", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub



<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButEdit.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButEdit.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'On Error Resume Next
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

    Private Sub ButCANCEL_Click(sender As Object, e As EventArgs) Handles ButCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()
    End Sub


End Class