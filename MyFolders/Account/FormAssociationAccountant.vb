Imports System.Data.SqlClient

Public Class FormAssociationAccountant
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
<<<<<<< HEAD
    Public SqlDataAdapter1 As New SqlDataAdapter
=======
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim IDFL As Integer = 0

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

<<<<<<< HEAD
    Private Sub FormAssociationaccountant_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackWorker2 = New ComponentModel.BackgroundWorker With {
=======
    Private Sub FormAssociationaccountant_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()
    End Sub

<<<<<<< HEAD
    Private Sub ComboBAssociationName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBAssociationName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CMP5  FROM COMPANY WHERE CMP2 ='" & Me.ComboBAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBAssociationName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBAssociationName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CMP5  FROM COMPANY WHERE CMP2 ='" & Me.ComboBAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextAssociationNationalNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextAssociationNationalNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub SAVERECORD()
        Try
            MAXIDBudget()
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO FinancialList( IDFL, FL1, FL2, FL3, FL4, FL5, FL6, FL7, FL8, FL9, FL10, FL11, FL12, FL13, FL14, FL15, USERNAME, CUser, COUser, da, ne) VALUES     ( @IDFL, @FL1, @FL2, @FL3, @FL4, @FL5, @FL6, @FL7, @FL8, @FL9, @FL10, @FL11, @FL12, @FL13, @FL14, @FL15, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO FinancialList( IDFL, FL1, FL2, FL3, FL4, FL5, FL6, FL7, FL8, FL9, FL10, FL11, FL12, FL13, FL14, FL15, USERNAME, CUser, COUser, da, ne) VALUES     ( @IDFL, @FL1, @FL2, @FL3, @FL4, @FL5, @FL6, @FL7, @FL8, @FL9, @FL10, @FL11, @FL12, @FL13, @FL14, @FL15, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDFL", SqlDbType.NVarChar).Value = SEARCHDATA.MAXBudget
                .Parameters.Add("@FL1", SqlDbType.NVarChar).Value = Me.ComboBAssociationName.Text
                .Parameters.Add("@FL2", SqlDbType.Int).Value = Me.TextAssociationNationalNumber.Text
                .Parameters.Add("@FL3", SqlDbType.NVarChar).Value = Me.ComboFiscalYear.Text
                .Parameters.Add("@FL4", SqlDbType.NVarChar).Value = Me.ComboAuditor.Text
                .Parameters.Add("@FL5", SqlDbType.Bit).Value = False
                .Parameters.Add("@FL6", SqlDbType.Bit).Value = False
                .Parameters.Add("@FL7", SqlDbType.Bit).Value = False
                .Parameters.Add("@FL8", SqlDbType.Bit).Value = False
                .Parameters.Add("@FL9", SqlDbType.Bit).Value = False
                .Parameters.Add("@FL10", SqlDbType.Int).Value = 0
                .Parameters.Add("@FL11", SqlDbType.NVarChar).Value = "جاري العمل "
                .Parameters.Add("@FL12", SqlDbType.NVarChar).Value = "0 "
                .Parameters.Add("@FL13", SqlDbType.NVarChar).Value = "0 "
                .Parameters.Add("@FL14", SqlDbType.NVarChar).Value = "0 "
                .Parameters.Add("@FL15", SqlDbType.NVarChar).Value = "0 "
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()

            MsgBox("تمت  الحفظ بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            Insert_Actions(SEARCHDATA.MAXBudget - 1, "حفظ", Me.Text)
            Me.ButtonSave.Enabled = False


<<<<<<< HEAD
            Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSave.Click
=======
    Private Sub ButtonSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSave.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        SAVERECORD()
    End Sub

<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
=======
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If

            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If

            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim NumberDOCUMENTS As Object = "BU" & Year & Me.TextAssociationNationalNumber.Text
            GetAutoNumberDOCUMENTSFL(NumberDOCUMENTS)
            Me.IDFL = SEARCHDATA.NumberDOCUMENTSFL


            Dim f As New FormDOCUMENTS
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButLogq.Enabled = True
            f.BUD = True
            f.Show()
            f.ADDBUTTON_Click(sender, e)

            CLEARDATA1(Me)
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextFileNo.Text = IDFL
            f.TextTransactionNumber.Text = NumberDOCUMENTS
            f.TEXTFileSubject.Text = "الموازنه"
            f.TextFileDescription.Text = "ارفاق مستندات الموازنه"
            f.PictureBox1.Image = Nothing
            f.TextFileNo.Enabled = False
            f.TextTransactionNumber.Enabled = False
            Insert_Actions(SEARCHDATA.MAXBudget - 1, "ارفاق مستندات الموازنه", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonViewDocuments_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim f As New FormDOCUMENTS With {
                .XU = "BU" & Year & Me.TextAssociationNationalNumber.Text,
=======
    Private Sub ButtonViewDocuments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim f As New FormDOCUMENTS With {
                .XU = "BU" & Me.TextAssociationNationalNumber.Text,
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .BUD = True
            }
            f.Show()
            f.Ts_TextChanged()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonButtonAddFundInventory_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonButtonAddFundInventory.Click
=======
    Private Sub ButtonButtonAddFundInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonButtonAddFundInventory.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim F As New FormInventoryBox
        F.Show()
    End Sub



<<<<<<< HEAD
    Private Sub ButtonAddAssociationProjects_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAddAssociationProjects.Click
=======
    Private Sub ButtonAddAssociationProjects_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddAssociationProjects.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim F As New FormAssociationProjects

        F.Show()
    End Sub

<<<<<<< HEAD
    Private Sub ButtonApproval_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonApproval.Click
        AccountantA = True
        FinanceAuditA = False
        'Dim f As New FinaBalances1
        'f.Show()
        'Dim currentRowIndex As Integer = f.GridView1.FocusedRowHandle
        'Dim value As Object = f.GridView1.GetRowCellValue(currentRowIndex, f.GridView1.Columns("ID"))
        ''For Each r As DataGridViewRow In f.DataGridView1.Rows
        'For i As Integer = 0 To f.GridView1.DataRowCount - 1
        '    If value <> "" Then
        '        If f.GridView1.RowCount > 0 Then
        '            MsgBox("لايمكن اعتماد الموازنة الحالية يجب مراجعة و تدقيق جميع السجلات ... ", 16, "تنبيه")
=======
    Private Sub ButtonApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApproval.Click
        AccountantA = True
        FinanceAuditA = False
        'Dim f As New Finabalances1
        'f.Show()
        'For Each r As DataGridViewRow In f.DataGridView1.Rows
        '    If r.Cells("IDNumber").Value <> "" Then
        '        If f.DataGridView1.RowCount > 0 Then
        '            MsgBox("لايمكن اعتماد الموازنة الحالية يجب ترحيل جميع السجلات  ... ", 16, "تنبيه")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        '            Exit Sub
        '        Else
        '            f.Close()
        '        End If
<<<<<<< HEAD
        '    ElseIf value = "" Then
=======
        '    ElseIf r.Cells("IDNumber").Value = "" Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        '        '
        '    End If
        'Next
        'f.Close()

        Try
            If Me.IDFL1.Text = Nothing Then
                MsgBox("الرجاء اضافة ميزانية والنقر على امر حفظ ... ", 16, "تنبيه")
                Exit Sub
            Else
<<<<<<< HEAD
                Dim Consum As New SqlConnection(constring)

                Dim SQL As New SqlCommand(" Update FinancialList SET    FL3 = @FL3, FL4 = @FL4, FL5 = @FL5, FL10 = @FL10, FL11 = @FL11, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
                Dim CMD As New SqlCommand With {
=======
                Dim Consum As New SqlClient.SqlConnection(constring)

                Dim SQL As New SqlCommand(" Update FinancialList SET    FL3 = @FL3, FL4 = @FL4, FL5 = @FL5, FL10 = @FL10, FL11 = @FL11, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
                Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                With CMD
                    .CommandType = CommandType.Text
                    .Connection = Consum
                    .Parameters.Add("@IDFL", SqlDbType.Int).Value = Val(Me.IDFL1.Text)
                    .Parameters.Add("@FL3", SqlDbType.NVarChar).Value = Me.ComboFiscalYear.Text
                    .Parameters.Add("@FL4", SqlDbType.NVarChar).Value = Me.ComboAuditor.Text
                    .Parameters.Add("@FL5", SqlDbType.Bit).Value = True
                    .Parameters.Add("@FL10", SqlDbType.Int).Value = 1
                    .Parameters.Add("@FL11", SqlDbType.NVarChar).Value = "تم الانتهاء من العمل وجاري ارسالها الي مدقق الحسابات"
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
<<<<<<< HEAD
                Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
                Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.RefreshTab.RunWorkerAsync()


                MsgBox("تمت  أعتماد الموازنة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
                Insert_Actions(SEARCHDATA.MAXBudget - 1, "أعتماد الموازنة", Me.Text)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub ButtonRefusal_Click(sender As Object, e As EventArgs) Handles ButtonRefusal.Click
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)

            Dim SQL As New SqlCommand(" Update FinancialList SET    FL3 = @FL3, FL4 = @FL4, FL5 = @FL5, FL10 = @FL10, FL11 = @FL11, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)

            Dim SQL As New SqlCommand(" Update FinancialList SET    FL3 = @FL3, FL4 = @FL4, FL5 = @FL5, FL10 = @FL10, FL11 = @FL11, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDFL", SqlDbType.Int).Value = Val(Me.IDFL1.Text)
                .Parameters.Add("@FL3", SqlDbType.NVarChar).Value = Me.ComboFiscalYear.Text
                .Parameters.Add("@FL4", SqlDbType.NVarChar).Value = Me.ComboAuditor.Text

                .Parameters.Add("@FL5", SqlDbType.Bit).Value = False
                .Parameters.Add("@FL10", SqlDbType.Int).Value = 0
                .Parameters.Add("@FL11", SqlDbType.NVarChar).Value = "تم إرجاع الميزانية للتعديل"

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
<<<<<<< HEAD
            Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
            Me.RefreshTab.RunWorkerAsync()
            'إرجاع الميزانية للتعديل

            MsgBox("تم إرجاع الميزانية للتعديل بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
            Insert_Actions(SEARCHDATA.MAXBudget - 1, "إرجاع الميزانية للتعديل", Me.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonX12_Click(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub ButtonX12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AccountantA = False
        FinanceAuditA = True
        Dim f As New FinaBalances1
        f.Show()
<<<<<<< HEAD
        Dim currentRowIndex As Integer = f.GridView1.FocusedRowHandle
        Dim value As Object = f.GridView1.GetRowCellValue(currentRowIndex, f.GridView1.Columns("ID"))
        'For Each r As DataGridViewRow In f.DataGridView1.Rows
        For i As Integer = 0 To f.GridView1.DataRowCount - 1
            If value <> "" Then
                If f.GridView1.RowCount > 0 Then
=======
        For Each r As DataGridViewRow In f.DataGridView1.Rows
            If r.Cells("IDNumber").Value <> "" Then
                If f.DataGridView1.RowCount > 0 Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    MsgBox("لايمكن اعتماد الموازنة الحالية يجب مراجعة و تدقيق جميع السجلات ... ", 16, "تنبيه")
                    Exit Sub
                Else
                    f.Close()
                End If
<<<<<<< HEAD
            ElseIf value = "" Then
=======
            ElseIf r.Cells("IDNumber").Value = "" Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                '
            End If
        Next
        f.Close()

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
                .CommandText = " select   IDFL, FL1, FL2, FL3, FL4, FL5, FL10, FL11, FL12,  USERNAME, Auditor, CUser, COUser, da, ne  FROM FinancialList   WHERE  CUser='" & ModuleGeneral.CUser & "'and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' "
            }
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = " select   IDFL, FL1, FL2, FL3, FL4, FL5, FL10, FL11, FL12,  USERNAME, Auditor, CUser, COUser, da, ne  FROM FinancialList   WHERE  CUser='" & ModuleGeneral.CUser & "'and FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' "
            }
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.myds.Clear()
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "FinancialList")
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
            Me.BS.DataSource = Me.myds.Tables("FinancialList")
            RowCount = BS.Count
            IDFL1.DataBindings.Add("text", BS, "IDFL", True, 1, "")
            ComboBAssociationName.DataBindings.Add("text", BS, "FL1", True, 1, "")
            TextAssociationNationalNumber.DataBindings.Add("text", BS, "FL2", True, 1, "")
            ComboFiscalYear.DataBindings.Add("text", BS, "FL3", True, 1, "")
            ComboAuditor.DataBindings.Add("text", BS, "FL4", True, 1, "")
            Me.CheckApproved.DataBindings.Add("Checked", BS, "FL5", True, 1, "")
            TextFL10.DataBindings.Add("text", BS, "FL10", True, 1, "")
            TextCondition.DataBindings.Add("text", BS, "FL11", True, 1, "")
            TextReasonsForRejectingBudget.DataBindings.Add("text", BS, "FL12", True, 1, "")
            'TextFL10
            Call MangUsers()
            Auditor("FinancialList", "USERNAME", "IDFL", Me.IDFL1.Text, "")
            Logentry = Uses
            If myds.Tables(0).Rows.Count > 0 Then
                Me.ButtonSave.Enabled = False
                If CheckApproved.Checked = True And TextFL10.Text = "0" Then
                    Me.ButtonApproval.Enabled = True
                ElseIf CheckApproved.Checked = False And TextFL10.Text = "0" Then
                    Me.ButtonApproval.Enabled = True
                Else
                    Me.ButtonApproval.Enabled = False
                End If
                'AndAlso TextFL10.Text <= 5
                If CheckApproved.Checked = True And TextFL10.Text = 1 Then
                    Me.ButtonRefusal.Enabled = True
                Else
                    Me.ButtonRefusal.Enabled = False
                End If
            Else
                Me.ButtonSave.Enabled = True
            End If
            FILLCOMBOBOX3("Users", "UserName", "COUser", COUser, "InternalAuditor", 1, Me.ComboAuditor)
<<<<<<< HEAD
            FILLCOMBOBOX3("FiscalYear", "Year(Year2)", "CUser", CUser, "YE1", 1, Me.ComboFiscalYear)
=======
            FILLCOMBOBOX10("FiscalYear", "Year(Year2)", "CUser", CUser, "YE1", 1, Me.ComboFiscalYear)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            FILLCOMBOBOX1("COMPANY", "CMP2", "CUser", CUser, Me.ComboBAssociationName)


            If AuditorClose() = True Or CollaborationManagerClose() = True Or HeadOFExternalAccountsDepartmentClose() = True Or ExternalAuditorClose() = True Then
                Me.ButtonAttachDocument.Enabled = False
                Me.ButtonButtonAddFundInventory.Enabled = False
                Me.ButtonAddAssociationProjects.Enabled = False
                Me.ButtonApproval.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds.Clear()
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "FinancialList")

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
            Me.BS.DataSource = myds.Tables("FinancialList")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            'Me.count()


            If Me.myds.Tables(0).Rows.Count > 0 Then
                Me.ButtonSave.Enabled = False
            Else
                Me.ButtonSave.Enabled = True
            End If

            If CheckApproved.Checked = True And TextFL10.Text = "0" Then
                Me.ButtonApproval.Enabled = True
            Else
                Me.ButtonApproval.Enabled = False
            End If

            If AuditorClose() = True Or CollaborationManagerClose() = True Or HeadOFExternalAccountsDepartmentClose() = True Or ExternalAuditorClose() = True Then
                Me.ButtonAttachDocument.Enabled = False
                Me.ButtonButtonAddFundInventory.Enabled = False
                Me.ButtonAddAssociationProjects.Enabled = False
                Me.ButtonApproval.Enabled = False
            End If
            If Me.DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                Me.DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRefreshData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


End Class