Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FormFixedAssets
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0


    Private Sub FormFixedAssets_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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
                    PRINTBUTTON_Click(sender, e)
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
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDFA) FROM FixedAssets", Consum)
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            IDFA.Text = 1
        Else
            IDFA.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub FormFixedAssets_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next

            Me.BackWorker2 = New ComponentModel.BackgroundWorker With {
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
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "FixedAssets")

            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("FixedAssets")
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
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "تعديل ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "حذف ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "ترحيل الحركة الى الصندوق", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "تعديل ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "حذف ترحيل الحركة الى الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TextBox1.Text.Trim, "إلغاء المراجعة", Me.Text)
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
        If Me.BS.Position < Me.myds.Tables("FixedAssets").Rows.Count - 1 Then
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
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
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
            'FundBalance()
            Me.MAXRECORD()
            Me.DatePurchase.Value = MaxDate.ToString("yyyy-MM-dd")
            Me.TextCostPrice.Text = "0.00"
            Me.TextConsumptionRate.Text = 10

            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Dim Sound As IO.Stream = My.Resources.addv
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
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
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
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
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO FixedAssets(  IDFA, FA1, FA2, FA3, FA4, FA5, FA6, FA7, FA8, FA9, FA10, FA11, FA12, USERNAME, CUser, COUser, da, ne) VALUES   (   @IDFA, @FA1, @FA2, @FA3, @FA4, @FA5, @FA6, @FA7, @FA8, @FA9, @FA10, @FA11, @FA12, @USERNAME, @CUser, @COUser, @da, @ne)"

            Dim cmd As New SqlCommand(Sql, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDFA", SqlDbType.Int).Value = Me.IDFA.Text.Trim
                .Parameters.Add("@FA1", SqlDbType.NVarChar).Value = Me.TextBox1.Text.Trim
                .Parameters.Add("@FA2", SqlDbType.NVarChar).Value = Me.TextSubjectName.Text.Trim
                .Parameters.Add("@FA3", SqlDbType.Int).Value = Me.TextNumber_quantity.Text.Trim
                .Parameters.Add("@FA4", SqlDbType.Money).Value = Me.TextCostPrice.Text.Trim
                .Parameters.Add("@FA5", SqlDbType.Money).Value = Me.TextConsumptionRate.Text.Trim
                .Parameters.Add("@FA6", SqlDbType.Money).Value = Me.TextCurrentConsumption.Text.Trim
                .Parameters.Add("@FA7", SqlDbType.Money).Value = Me.TextTotalPreviousConsumption.Text.Trim
                .Parameters.Add("@FA8", SqlDbType.Date).Value = Me.DatePurchase.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@FA9", SqlDbType.Date).Value = Me.DateDepreciation.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@FA10", SqlDbType.Int).Value = Me.TextNumberYearsDepreciation.Text.Trim
                .Parameters.Add("@FA11", SqlDbType.NVarChar).Value = Me.TextInvoiceNumber.Text.Trim
                .Parameters.Add("@FA12", SqlDbType.NVarChar).Value = Me.TextComments.Text.Trim



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
            Insert_Actions(Me.IDFA.Text, " حفظ", Me.Text)

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

            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT   IDFA, FA1, FA2, FA3, FA4, FA5, FA6, FA7, FA8, FA9, FA10, FA11, FA12, USERNAME, Auditor, CUser, COUser, da, ne FROM FixedAssets  WHERE  CUser='", ModuleGeneral.CUser, "'ORDER BY IDFA"})
            }

            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "FixedAssets")
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
            Me.BS.DataSource = Me.myds.Tables("FixedAssets")
            Me.RowCount = Me.BS.Count
            Me.IDFA.DataBindings.Add("text", Me.BS, "IDFA", True, 1, "")
            Me.TextBox1.DataBindings.Add("text", Me.BS, "FA1", True, 1, "")
            Me.TextSubjectName.DataBindings.Add("text", Me.BS, "FA2", True, 1, "")
            Me.TextNumber_quantity.DataBindings.Add("text", Me.BS, "FA3", True, 1, "")
            Me.TextCostPrice.DataBindings.Add("text", Me.BS, "FA4", True, 1, "")
            Me.TextConsumptionRate.DataBindings.Add("text", Me.BS, "FA5", True, 1, "")
            Me.TextCurrentConsumption.DataBindings.Add("text", Me.BS, "FA6", True, 1, "")
            Me.TextTotalPreviousConsumption.DataBindings.Add("text", Me.BS, "FA7", True, 1, "")
            Me.DatePurchase.DataBindings.Add("text", Me.BS, "FA8", True, 1, "")
            Me.DateDepreciation.DataBindings.Add("text", Me.BS, "FA9", True, 1, "")
            Me.TextNumberYearsDepreciation.DataBindings.Add("text", Me.BS, "FA10", True, 1, "")
            Me.TextInvoiceNumber.DataBindings.Add("text", Me.BS, "FA11", True, 1, "")
            Me.TextComments.DataBindings.Add("text", Me.BS, "FA12", True, 1, "")

            Me.DataGridView1.DataSource = Me.BS
            'Me.DataGridView1.Columns(1).HeaderText = "رقم تسلسلي"
            Me.DataGridView1.Columns(2).HeaderText = "اسم المادة"
            Me.DataGridView1.Columns(3).HeaderText = "العدد \ كمية"
            Me.DataGridView1.Columns(4).HeaderText = "سعر التكلفة"
            Me.DataGridView1.Columns(8).HeaderText = "تاريخ الشراء"

            Me.DataGridView1.Columns(0).Visible = False
            Me.DataGridView1.Columns(1).Visible = False
            Me.DataGridView1.Columns(5).Visible = False
            Me.DataGridView1.Columns(6).Visible = False
            Me.DataGridView1.Columns(7).Visible = False
            Me.DataGridView1.Columns(9).Visible = False
            Me.DataGridView1.Columns(10).Visible = False
            Me.DataGridView1.Columns(11).Visible = False

            Me.DataGridView1.Columns(12).Visible = False
            Me.DataGridView1.Columns(13).Visible = False
            Me.DataGridView1.Columns(14).Visible = False
            Me.DataGridView1.Columns(15).Visible = False
            Me.DataGridView1.Columns(16).Visible = False
            Me.DataGridView1.Columns(17).Visible = False
            Me.DataGridView1.Columns(18).Visible = False
            'Me.DataGridView1.Columns(19).Visible = False
            'FILLCOMBOBOX1("COMPANY", "CMP2", "COUser", COUser, Me.ComboBoxEx2)
            'FILLCOMBOBOX3("Users", "UserName", "COUser", COUser, "InternalAuditor", Trim("True"), Me.ComboBoxEx3)
            'FILLCOMBOBOX1("FiscalYear", "Year(Year4)", "CUser", CUser, Me.ComboBoxEx1)
            Call MangUsers()
            Me.RecordCount()
            Auditor("FixedAssets", "USERNAME", "IDFA", Me.IDFA.Text, "")
            Logentry = Uses
            If InternalAuditor = False Then

                'MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update FixedAssets SET  FA1 = @FA1, FA2 = @FA2, FA3 = @FA3, FA4 = @FA4, FA5 = @FA5, FA6 = @FA6, FA7 = @FA7, FA8 = @FA8, FA9 = @FA9, FA10 = @FA10,FA11 = @FA11, FA12 = @FA12, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFA = @IDFA", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD


                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDFA", SqlDbType.Int).Value = Me.IDFA.Text.Trim

                .Parameters.Add("@FA1", SqlDbType.NVarChar).Value = Me.TextBox1.Text.Trim
                .Parameters.Add("@FA2", SqlDbType.NVarChar).Value = Me.TextSubjectName.Text.Trim
                .Parameters.Add("@FA3", SqlDbType.Int).Value = Me.TextNumber_quantity.Text.Trim
                .Parameters.Add("@FA4", SqlDbType.Money).Value = Me.TextCostPrice.Text.Trim
                .Parameters.Add("@FA5", SqlDbType.Money).Value = Me.TextConsumptionRate.Text.Trim
                .Parameters.Add("@FA6", SqlDbType.Money).Value = Me.TextCurrentConsumption.Text.Trim
                .Parameters.Add("@FA7", SqlDbType.Money).Value = Me.TextTotalPreviousConsumption.Text.Trim
                .Parameters.Add("@FA8", SqlDbType.Date).Value = Me.DatePurchase.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@FA9", SqlDbType.Date).Value = Me.DateDepreciation.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@FA10", SqlDbType.Int).Value = Me.TextNumberYearsDepreciation.Text.Trim
                .Parameters.Add("@FA11", SqlDbType.NVarChar).Value = Me.TextInvoiceNumber.Text.Trim
                .Parameters.Add("@FA12", SqlDbType.NVarChar).Value = Me.TextComments.Text.Trim
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
            Insert_Actions(Me.IDFA.Text, " تعديل", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
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
        Me.SaveTab = New ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Click2 = True
    End Sub

    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()

    End Sub

    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
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
        Dim Consum As New SqlConnection(constring)
        Dim rpt As New CrystalFixedAssets
        Dim F As New FrmPRINT
        GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM FixedAssets   WHERE  CUser='" & ModuleGeneral.CUser & "'   ", Consum)
        Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
        SqlDataAdapter1 = New SqlDataAdapter(str)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "FixedAssets")
        rpt.SetDataSource(ds)
        Dim txt As TextObject
        'txt = rpt.Section1.ReportObjects("Text15")

        txt = rpt.Section1.ReportObjects("Text15")
        txt.Text = AssociationName
        txt = rpt.Section1.ReportObjects("Text32")
        txt.Text = Directorate
        'txt = rpt.Section1.ReportObjects("Text13")
        'txt.Text = Character
        'txt = rpt.Section1.ReportObjects("Text40")
        'txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
        'txt = rpt.Section1.ReportObjects("Text44")
        'txt.Text = Recorded
        F.CrystalReportViewer1.ReportSource = rpt
        F.CrystalReportViewer1.Zoom(90%)
        F.CrystalReportViewer1.Refresh()
        F.Show()

    End Sub




    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextConsumptionRate.TextChanged, DatePurchase.ValueChanged, TextCurrentConsumption.TextChanged, TextTotalPreviousConsumption.TextChanged
        On Error Resume Next
        Me.TextNumberYearsDepreciation.Text = FiscalYear_currentDateMustBeInFiscalYear() - Year(DatePurchase.Value)
        'Me.TextBox6.Text = Val(Me.TextBox4.Text) * Val(Me.TextBox5.Text)
        Me.TextCurrentConsumption.Text = Format(Val(Val(Me.TextCostPrice.Text) / 100 * Val(Me.TextConsumptionRate.Text)), "0.000")


        Me.TextTotalPreviousConsumption.Text = Val(Me.TextNumberYearsDepreciation.Text) * Val(Me.TextCurrentConsumption.Text)
    End Sub

    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub

    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub

    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub

    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub


End Class