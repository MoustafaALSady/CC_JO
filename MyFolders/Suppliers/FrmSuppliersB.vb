Option Explicit Off

Imports System.Data.SqlClient
Public Class FrmSuppliersB
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    ReadOnly myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
<<<<<<< HEAD
    Private Sub FrmSuppliers_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmSuppliers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    Me.SAVEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmSuppliersB_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmSuppliersB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub
<<<<<<< HEAD

    Private Sub SAVERECORD()
        Try
            Using Consum As New SqlConnection(constring)
                Dim SQL As String = "INSERT INTO SUPPLIER(sup2, sup3, sup4, sup5, sup7, USERNAME, Cuser, COUser, da, ne) VALUES (@sup2, @sup3, @sup4, @sup5, @sup7, @USERNAME, @Cuser, @COUser, @da, @ne)"
                Using cmd As New SqlCommand(SQL, Consum)
                    With cmd
                        .CommandType = CommandType.Text
                        ' Ensure all parameters are added
                        .Parameters.AddWithValue("@sup2", If(String.IsNullOrEmpty(Me.TEXTAgentName.Text), DBNull.Value, Me.TEXTAgentName.Text))
                        .Parameters.AddWithValue("@sup3", If(String.IsNullOrEmpty(Me.TEXTSupplierName.Text), DBNull.Value, Me.TEXTSupplierName.Text))
                        .Parameters.AddWithValue("@sup4", If(String.IsNullOrEmpty(Me.TEXTPHONE.EditValue), DBNull.Value, Me.TEXTPHONE.EditValue))
                        .Parameters.AddWithValue("@sup5", If(String.IsNullOrEmpty(Me.TextE_mail.EditValue), DBNull.Value, Me.TextE_mail.EditValue))
                        .Parameters.AddWithValue("@sup7", If(String.IsNullOrEmpty(Me.TextITEMNAME.Text), DBNull.Value, Me.TextITEMNAME.Text))
                        .Parameters.AddWithValue("@USERNAME", If(String.IsNullOrEmpty(USERNAME), DBNull.Value, USERNAME))
                        .Parameters.AddWithValue("@CUser", If(String.IsNullOrEmpty(CUser), DBNull.Value, CUser))
                        .Parameters.AddWithValue("@COUser", If(String.IsNullOrEmpty(COUser), DBNull.Value, COUser))
                        .Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                        .Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                    End With

                    Consum.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error SAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

=======
    Private Sub SAVERECORD()
        ''On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO SUPPLIER( sup2, sup3, sup4, sup5, sup7, USERNAME, Cuser, COUser, da, ne) VALUES     ( @sup2, @sup3, @sup4, @sup5, @sup7, @USERNAME, @Cuser, @COUser, @da, @ne)"
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@sup1", SqlDbType.Int).Value = Me.TEXTBOX1.Text
                .Parameters.Add("@sup2", SqlDbType.NVarChar).Value = Me.TEXTAgentName.Text
                .Parameters.Add("@sup3", SqlDbType.NVarChar).Value = Me.TEXTSupplierName.Text
                .Parameters.Add("@sup4", SqlDbType.NVarChar).Value = Me.TEXTPHONE.EditValue
                .Parameters.Add("@sup5", SqlDbType.NVarChar).Value = Me.TextE_mail.EditValue
                .Parameters.Add("@sup7", SqlDbType.NVarChar).Value = Me.TextITEMNAME.Text
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.Update(myds, "SUPPLIER")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "SUPPLIER")
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                'Button9.PerformClick()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("SUPPLIER")

            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

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
                    Insert_Actions(Me.TEXTBOX1.Text, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTBOX1.Text, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
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
    End Sub
    Private Sub MAXRECORD1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(SUPPLIER.sup1) FROM SUPPLIER", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(SUPPLIER.sup1) FROM SUPPLIER", Consum)
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
            Me.TEXTBOX1.Text = 1
        Else
            Me.TEXTBOX1.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
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
            CLEARDATA1(Me)
            Application.DoEvents()
            Me.BS.CancelEdit()
            Me.MAXRECORD1()
            Me.TEXTAgentName.Focus()
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
        'If BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Static P As Integer
        P = Me.BS.Count
        Me.PictureBox2.Visible = True
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = BS.Count
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

End Class