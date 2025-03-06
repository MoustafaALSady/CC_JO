
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FormInventoryBox
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
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim CSH As Double = 0
<<<<<<< HEAD
    Private Sub FormInventoryBox_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FormInventoryBox_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDLOBOX) FROM InventoryBox", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(IDLOBOX) FROM InventoryBox", Consum)
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
            TextNo.Text = CStr(1)
        Else
            TextNo.Text = CStr(CType(resualt, Integer) + 1)
        End If
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub FormInventoryBox_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FormInventoryBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "InventoryBox")

        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                Me.PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                Me.PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "ErrorRefreshData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = myds.Tables("InventoryBox")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Me.Count()
            If Me.DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, CType(48 + 524288, MsgBoxStyle), "تحديث السجلات")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, CType(48 + 524288, MsgBoxStyle), "تحديث السجلات")
                End If
            Else
                Me.DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRefreshData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:

            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "InventoryBox")

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
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", CType(16, MsgBoxStyle), "تنبيه")
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
<<<<<<< HEAD
            Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()

            Application.DoEvents()
            'Me.BS.DataSource = Me.myds.Tables("InventoryBox")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, CType(64 + 524288, MsgBoxStyle), " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, CType(64 + 524288, MsgBoxStyle), " نجاح الحفظ والتغييرات")
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
                    Insert_Actions(Me.TextNo.Text.Trim, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TextNo.Text.Trim, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TextNo.Text.Trim, "إلغاء المراجعة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click11 = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", CType(64 + 524288, MsgBoxStyle), "نجاح الحفظ والتغييرات والتحديث")
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
        If Me.BS.Position < Me.myds.Tables("InventoryBox").Rows.Count - 1 Then
            Forward = True
        End If
        Me.TextAmountsInWriting.Text = CurrencyJO(CDec(Me.TextcurrentAmounts.EditValue), "jO")
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
                MsgBox("الاتصال بالانترنت غير متوفر", CType(16, MsgBoxStyle), "تنبيه")
                Exit Sub
            End If
            Call MangUsers()
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", CType(16, MsgBoxStyle), "تنبيه")
                Exit Sub
            End If
            FundBalance()
            Me.MAXRECORD()
            Me.DateT.Value = CDate(MaxDate.ToString("yyyy-MM-dd"))
            Me.TextReceiptVoucherFrom.Text = CStr(0)
            Me.TextReceiptVoucher.Text = CStr(0)
            Me.TextPaymentVoucherFrom.Text = CStr(0)
            Me.TextPaymentVoucher.Text = CStr(0)
            Me.TextRecordingDocumentFrom.Text = CStr(0)
            Me.TextRecordingDocument.Text = CStr(0)
            Me.TextcurrentAmounts.EditValue = CStr(Val(Me.CSH))
            Me.TextAmountsInWriting.Text = CurrencyJO(CDec(Me.TextcurrentAmounts.EditValue), "jO")
            Me.TextReceiptVoucherFrom.Focus()
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
            MsgBox("الاتصال بالانترنت غير متوفر", CType(16, MsgBoxStyle), "تنبيه")
            Exit Sub
        End If
        'If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", CType(16, MsgBoxStyle), "تنبيه")
            Exit Sub
        End If
        Me.SAVEBUTTON.Enabled = False

        Static P As Integer
        P = Me.BS.Count
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        'Me.FormInventoryBox_Load(sender, e)
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
            Dim SQL As String = "INSERT INTO InventoryBox( LOBOX, LOBOX1, LOBOX2, LOBOX3, LOBOX4, LOBOX5, LOBOX6, LOBOX7, LOBOX8, LOBOX9, CB1, CB2, USERNAME, CUser, COUser, da, ne) VALUES     ( @LOBOX, @LOBOX1, @LOBOX2, @LOBOX3, @LOBOX4, @LOBOX5, @LOBOX6, @LOBOX7, @LOBOX8, @LOBOX9, @CB1, @CB2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO InventoryBox( LOBOX, LOBOX1, LOBOX2, LOBOX3, LOBOX4, LOBOX5, LOBOX6, LOBOX7, LOBOX8, LOBOX9, CB1, CB2, USERNAME, CUser, COUser, da, ne) VALUES     ( @LOBOX, @LOBOX1, @LOBOX2, @LOBOX3, @LOBOX4, @LOBOX5, @LOBOX6, @LOBOX7, @LOBOX8, @LOBOX9, @CB1, @CB2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDLOBOX", SqlDbType.Int).Value = Me.TextNo.Text.Trim
                .Parameters.Add("@LOBOX", SqlDbType.Date).Value = Me.DateT.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@LOBOX1", SqlDbType.Int).Value = Me.TextReceiptVoucherFrom.Text.Trim
                .Parameters.Add("@LOBOX2", SqlDbType.Int).Value = Me.TextReceiptVoucher.Text.Trim
                .Parameters.Add("@LOBOX3", SqlDbType.Int).Value = Me.TextPaymentVoucherFrom.Text.Trim
                .Parameters.Add("@LOBOX4", SqlDbType.Int).Value = Me.TextPaymentVoucher.Text.Trim
                .Parameters.Add("@LOBOX5", SqlDbType.Int).Value = Me.TextRecordingDocumentFrom.Text.Trim
                .Parameters.Add("@LOBOX6", SqlDbType.Int).Value = Me.TextRecordingDocument.Text.Trim
                .Parameters.Add("@LOBOX7", SqlDbType.Float).Value = Me.TextcurrentAmounts.EditValue.Trim
                .Parameters.Add("@LOBOX8", SqlDbType.NVarChar).Value = Me.TextAmountsInWriting.Text.Trim
                .Parameters.Add("@LOBOX9", SqlDbType.NVarChar).Value = Me.TextNotes.Text.Trim
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text.Trim
                .Parameters.Add("@CB2", SqlDbType.NVarChar).Value = Me.TextCB2.Text.Trim
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
            Insert_Actions(Me.TextNo.Text, "حفظ", Me.Text)
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
                .CommandText = String.Concat(New String() {"SELECT  IDLOBOX, LOBOX, LOBOX1, LOBOX2, LOBOX3, LOBOX4, LOBOX5, LOBOX6, LOBOX7, LOBOX8, LOBOX9, CB1, CB2, USERNAME, CUser, COUser, da, ne FROM InventoryBox  WHERE  CUser='", ModuleGeneral.CUser, "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDLOBOX"})
            }
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT  IDLOBOX, LOBOX, LOBOX1, LOBOX2, LOBOX3, LOBOX4, LOBOX5, LOBOX6, LOBOX7, LOBOX8, LOBOX9, CB1, CB2, USERNAME, CUser, COUser, da, ne FROM InventoryBox  WHERE  CUser='", ModuleGeneral.CUser, "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDLOBOX"})
            }
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "InventoryBox")
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
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            Me.ComboCB1.SelectedIndex = 0
            Me.BS.DataSource = Me.myds.Tables("InventoryBox")
            Me.RowCount = Me.BS.Count
            Me.TextNo.DataBindings.Add("text", Me.BS, "IDLOBOX", True, CType(1, DataSourceUpdateMode), "")
            Me.DateT.DataBindings.Add("text", Me.BS, "LOBOX", True, CType(1, DataSourceUpdateMode), "")
            Me.TextReceiptVoucherFrom.DataBindings.Add("text", Me.BS, "LOBOX1", True, CType(1, DataSourceUpdateMode), "")
            Me.TextReceiptVoucher.DataBindings.Add("text", Me.BS, "LOBOX2", True, CType(1, DataSourceUpdateMode), "")
            Me.TextPaymentVoucherFrom.DataBindings.Add("text", Me.BS, "LOBOX3", True, CType(1, DataSourceUpdateMode), "")
            Me.TextPaymentVoucher.DataBindings.Add("text", Me.BS, "LOBOX4", True, CType(1, DataSourceUpdateMode), "")
            Me.TextRecordingDocumentFrom.DataBindings.Add("text", Me.BS, "LOBOX5", True, CType(1, DataSourceUpdateMode), "")
            Me.TextRecordingDocument.DataBindings.Add("text", Me.BS, "LOBOX6", True, CType(1, DataSourceUpdateMode), "")
            Me.TextcurrentAmounts.DataBindings.Add("text", Me.BS, "LOBOX7", True, CType(1, DataSourceUpdateMode), "")
            Me.TextAmountsInWriting.DataBindings.Add("text", Me.BS, "LOBOX8", True, CType(1, DataSourceUpdateMode), "")
            Me.TextNotes.DataBindings.Add("text", Me.BS, "LOBOX9", True, CType(1, DataSourceUpdateMode), "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, CType(1, DataSourceUpdateMode), "")
            Me.TextCB2.DataBindings.Add("text", Me.BS, "CB2", True, CType(1, DataSourceUpdateMode), "")
            Call MangUsers()
            Me.RecordCount()
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Auditor("InventoryBox", "USERNAME", "IDLOBOX", Me.TextNo.Text, "")
            Logentry = Uses

            If InternalAuditor = False Then
                'MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update InventoryBox SET  LOBOX = @LOBOX, LOBOX1 = @LOBOX1, LOBOX2 = @LOBOX2, LOBOX3 = @LOBOX3, LOBOX4 = @LOBOX4, LOBOX5 = @LOBOX5, LOBOX6 = @LOBOX6, LOBOX7 = @LOBOX7, LOBOX8 = @LOBOX8, LOBOX9 = @LOBOX9, CB1 = @CB1, CB2 = @CB2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDLOBOX = @IDLOBOX", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update InventoryBox SET  LOBOX = @LOBOX, LOBOX1 = @LOBOX1, LOBOX2 = @LOBOX2, LOBOX3 = @LOBOX3, LOBOX4 = @LOBOX4, LOBOX5 = @LOBOX5, LOBOX6 = @LOBOX6, LOBOX7 = @LOBOX7, LOBOX8 = @LOBOX8, LOBOX9 = @LOBOX9, CB1 = @CB1, CB2 = @CB2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDLOBOX = @IDLOBOX", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDLOBOX", SqlDbType.Int).Value = Me.TextNo.Text.Trim
                .Parameters.Add("@LOBOX", SqlDbType.Date).Value = Me.DateT.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@LOBOX1", SqlDbType.Int).Value = Me.TextReceiptVoucherFrom.Text.Trim
                .Parameters.Add("@LOBOX2", SqlDbType.Int).Value = Me.TextReceiptVoucher.Text.Trim
                .Parameters.Add("@LOBOX3", SqlDbType.Int).Value = Me.TextPaymentVoucherFrom.Text.Trim
                .Parameters.Add("@LOBOX4", SqlDbType.Int).Value = Me.TextPaymentVoucher.Text.Trim
                .Parameters.Add("@LOBOX5", SqlDbType.Int).Value = Me.TextRecordingDocumentFrom.Text.Trim
                .Parameters.Add("@LOBOX6", SqlDbType.Int).Value = Me.TextRecordingDocument.Text.Trim
                .Parameters.Add("@LOBOX7", SqlDbType.NVarChar).Value = Me.TextcurrentAmounts.EditValue.Trim
                .Parameters.Add("@LOBOX8", SqlDbType.NVarChar).Value = Me.TextAmountsInWriting.Text.Trim
                .Parameters.Add("@LOBOX9", SqlDbType.NVarChar).Value = Me.TextNotes.Text.Trim
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text.Trim
                .Parameters.Add("@CB2", SqlDbType.NVarChar).Value = Me.TextCB2.Text.Trim
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
            Insert_Actions(Me.TextNo.Text, "تعديل", Me.Text)
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
            MsgBox("الاتصال بالانترنت غير متوفر", CType(16, MsgBoxStyle), "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", CType(16, MsgBoxStyle), "تنبيه")
            Exit Sub
        End If

        'If Me.CheckBox3.Checked = True Then
        '    MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
        '    Exit Sub
        'End If
        Static P As Integer
        P = Me.BS.Position
        Me.TextAmountsInWriting.Text = CurrencyJO(CDec(Me.TextcurrentAmounts.EditValue), "jO")
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
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", CType(16, MsgBoxStyle), "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", CType(16, MsgBoxStyle), "تنبيه")
            Exit Sub
        End If
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim rpt As New CrystalInventoryBox
        Dim F As New FrmPRINT
        GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
        Dim ds As New DataSet
        Dim str As New SqlCommand("SELECT * FROM InventoryBox   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'   AND CB1='" & Me.ComboCB1.Text & "'  ", Consum)
        Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
        SqlDataAdapter1 = New SqlDataAdapter(str)
=======
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "InventoryBox")
        rpt.SetDataSource(ds)
        Dim txt As TextObject
        txt = CType(rpt.Section1.ReportObjects("Text15"), TextObject)

        txt = CType(rpt.Section1.ReportObjects("Text15"), TextObject)
        txt.Text = AssociationName
        txt = CType(rpt.Section1.ReportObjects("Text8"), TextObject)
        txt.Text = Directorate
        txt = CType(rpt.Section1.ReportObjects("Text13"), TextObject)
        txt.Text = Character
        txt = CType(rpt.Section1.ReportObjects("Text40"), TextObject)
        txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
        txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
        txt.Text = Recorded
        F.CrystalReportViewer1.ReportSource = rpt
        F.CrystalReportViewer1.Zoom(90%)
        F.CrystalReportViewer1.Refresh()
        F.Show()

    End Sub
    Private Sub FundBalance()
        On Error Resume Next
        Dim N As Double
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = CDbl(cmd1.ExecuteScalar)
        Consum.Close()
        Me.CSH = CDbl(Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000"))
    End Sub
<<<<<<< HEAD
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCB2.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextCB2.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        Me.FundBalance()
        Me.TextcurrentAmounts.EditValue = CStr(Val(Me.CSH))
        Me.TextAmountsInWriting.Text = CurrencyJO(CDec(Me.TextcurrentAmounts.EditValue), "jO")
    End Sub

<<<<<<< HEAD
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub

<<<<<<< HEAD
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub

<<<<<<< HEAD
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub

<<<<<<< HEAD
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub

End Class