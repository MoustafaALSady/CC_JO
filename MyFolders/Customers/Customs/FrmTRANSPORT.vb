Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmTRANSPORT
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim ds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB1_chk As Boolean = False
    Public TB2_chk As Boolean = False
    Public TB3_chk As Boolean = False
    Dim TypeCustomer As String
    Dim IDCAB1 As Int64
    Dim IDCAB2 As Int64

    Private Sub FrmTRANSPORT_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmTRANSPORT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonXP3_Click(sender, e)
                    Case Keys.F10
                        Me.TRANSFERBUTTON_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonXP2_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonXP5_Click(sender, e)
                    Case Keys.PageDown
                        Me.PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        Me.NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmTRANSPORT_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
        Me.TabPage1.Show()
    End Sub
    Private Sub FrmTRANSPORT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonPostToCustomerTraffic.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False

        TestkeyAccounts(keyAccounts.GetValue("TransferAccount_No", TransferAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("TransferAccount_No", TransferAccount_No)
        End If

        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboCustomerName, e, )
    End Sub
    Private Sub ComboBox16_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboITEMNAME, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboDebitAccount, e, )
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            TestNet = True
            Me.LoadDataBase()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                If TB1_chk = True Then
                    .CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, CB1, BN2, WarehouseNumber, WarehouseName, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM PETRO   WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1 ='" & Trim(Me.TB1) & "'"
                ElseIf TB2_chk = True Then
                    .CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, CB1, BN2, WarehouseNumber, WarehouseName, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM PETRO   WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO21 ='" & Strings.Trim(Me.TB2) & "'"
                ElseIf TB3_chk = True Then
                    MsgBox(TB3.ToString)
                    .CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, CB1, BN2, WarehouseNumber, WarehouseName, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM PETRO   WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO20 ='" & Strings.Trim(Me.TB3) & "'"
                End If
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Me.ds = New DataSet
                Consum.Open()
                SqlDataAdapter1.Fill(ds, "PETRO")
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
        Finally
            Call CloseDB()
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
    Private Sub MAXRECORD1()
        On Error Resume Next
        Dim V As Integer
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(PETRO.PTRO1) FROM PETRO", Consum)
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
            Me.TEXTID.EditValue = 1
        Else
            Me.TEXTID.EditValue = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub

            FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.ds.Tables("PETRO")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "PTRO1", True, 1, "")
            Me.TEXTCarNumbers.DataBindings.Add("text", Me.BS, "PTRO2", True, 1, "")
            Me.TEXTQuantity.DataBindings.Add("text", Me.BS, "PTRO3", True, 1, "")
            Me.TEXTLetteringQuantity.DataBindings.Add("text", Me.BS, "PTRO4", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "PTRO5", True, 1, "")
            Me.TEXTUnitPrice.DataBindings.Add("text", Me.BS, "PTRO6", True, 1, "")
            Me.TEXTTotalValue.DataBindings.Add("text", Me.BS, "PTRO7", True, 1, "")
            Me.TEXTTaxRate.DataBindings.Add("text", Me.BS, "PTRO8", True, 1, "")
            Me.ComboITEMNAME.DataBindings.Add("text", Me.BS, "PTRO9", True, 1, "")
            Me.TextCreditAccount.DataBindings.Add("text", Me.BS, "PTRO10", True, 1, "")
            Me.TEXTNetValue.DataBindings.Add("text", Me.BS, "PTRO11", True, 1, "")
            Me.TEXTLoadingExpenses.DataBindings.Add("text", Me.BS, "PTRO12", True, 1, "")
            Me.TEXTTransfers.DataBindings.Add("text", Me.BS, "PTRO13", True, 1, "")
            Me.TEXTTotal.DataBindings.Add("text", Me.BS, "PTRO14", True, 1, "")
            Me.CheckTransferToAccounts.DataBindings.Add("Checked", Me.BS, "PTRO15", True, 1, "")
            Me.CheckSettlementDone.DataBindings.Add("Checked", Me.BS, "PTRO16", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "PTRO17", True, 1, "")
            Me.TEXTTotalN.DataBindings.Add("text", Me.BS, "PTRO18", True, 1, "")
            Me.TextTaxes.DataBindings.Add("text", Me.BS, "PTRO19", True, 1, "")
            Me.ComboCustomerName.DataBindings.Add("text", Me.BS, "PTRO20", True, 1, "")
            Me.TextCustomerNumber.DataBindings.Add("text", Me.BS, "PTRO21", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "PTRO22", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "PTRO23", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "PTRO24", True, 1, "")
            Me.TextFundValue.DataBindings.Add("text", Me.BS, "PTRO25", True, 1, "")
            Me.TextValueOfCheck.DataBindings.Add("text", Me.BS, "PTRO26", True, 1, "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "PTRO27", True, 1, "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "PTRO28", True, 1, "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", BS, "PTRO29", True, 1, "")
            Me.TextCheckDrawerCode.DataBindings.Add("text", BS, "PTRO30", True, 1, "")
            Me.CheckPostToCustomerTraffic.DataBindings.Add("Checked", Me.BS, "PTRO31", True, 1, "")

            Me.ComboCB1.DataBindings.Add("text", BS, "CB1", True, 1, "")
            Me.ComboBN2.DataBindings.Add("text", BS, "BN2", True, 1, "")

            Me.ComboStore.DataBindings.Add("text", BS, "WarehouseNumber", True, 1, "")
            Me.TextWarehouseName.DataBindings.Add("text", BS, "WarehouseName", True, 1, "")






            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")

            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)

            FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)


            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpComboDebitAccount.Value, Me.ComboDebitAccount)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpCreditAccount.Value, Me.List1)
            Me.InternalAuditorType()
            Auditor("PETRO", "USERNAME", "PTRO1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            Me.AutoEx()
            Call MangUsers()
            Me.RecordCount()
            Me.InternalAuditorType()
            Me.BUTTONCANCEL.Enabled = True

            TestkeyAccounts(keyAccounts.GetValue("TransferAccount_No", TransferAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("TransferAccount_No", TransferAccount_No)
            End If
            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub UPDATERECORD()
        Try
            'On Error Resume Next
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE PETRO SET PTRO2 = @PTRO2, PTRO3 = @PTRO3, PTRO4 = @PTRO4, PTRO5 = @PTRO5, PTRO6 = @PTRO6, PTRO7 = @PTRO7, PTRO8 = @PTRO8, PTRO9 = @PTRO9, PTRO10 = @PTRO10, PTRO11 = @PTRO11, PTRO12 = @PTRO12, PTRO13 = @PTRO13, PTRO14 = @PTRO14, PTRO15 = @PTRO15, PTRO16 = @PTRO16, PTRO17 = @PTRO17, PTRO18 = @PTRO18, PTRO19 = @PTRO19, PTRO20 = @PTRO20, PTRO21 = @PTRO21, PTRO22 = @PTRO22, PTRO23 = @PTRO23, PTRO24 = @PTRO24, PTRO25 = @PTRO25, PTRO26 = @PTRO26, PTRO27 = @PTRO27, PTRO28 = @PTRO28, PTRO29 = @PTRO29, PTRO30 = @PTRO30, PTRO31 = @PTRO31, CB1 = @CB1, WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE PTRO1 = @PTRO1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@PTRO1", SqlDbType.Int).Value = Me.TEXTID.EditValue
                .Parameters.Add("@PTRO2", SqlDbType.Int).Value = Me.TEXTCarNumbers.EditValue
                .Parameters.Add("@PTRO3", SqlDbType.Money).Value = Me.TEXTQuantity.EditValue
                .Parameters.Add("@PTRO4", SqlDbType.NVarChar).Value = Me.TEXTLetteringQuantity.Text
                .Parameters.Add("@PTRO5", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@PTRO6", SqlDbType.NVarChar).Value = Me.TEXTUnitPrice.EditValue
                .Parameters.Add("@PTRO7", SqlDbType.NVarChar).Value = Me.TEXTTotalValue.Text
                .Parameters.Add("@PTRO8", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.Text
                .Parameters.Add("@PTRO9", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text
                .Parameters.Add("@PTRO10", SqlDbType.NVarChar).Value = Me.TextCreditAccount.Text
                .Parameters.Add("@PTRO11", SqlDbType.NVarChar).Value = Me.TEXTNetValue.Text
                .Parameters.Add("@PTRO12", SqlDbType.NVarChar).Value = Me.TEXTLoadingExpenses.EditValue
                .Parameters.Add("@PTRO13", SqlDbType.NVarChar).Value = Me.TEXTTransfers.Text
                .Parameters.Add("@PTRO14", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@PTRO15", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
                .Parameters.Add("@PTRO16", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettlementDone.Checked)
                .Parameters.Add("@PTRO17", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@PTRO18", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@PTRO19", SqlDbType.NVarChar).Value = Me.TextTaxes.EditValue
                .Parameters.Add("@PTRO20", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@PTRO21", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@PTRO22", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@PTRO23", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@PTRO24", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@PTRO25", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@PTRO26", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@PTRO27", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@PTRO28", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")

                .Parameters.Add("@PTRO29", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@PTRO30", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

                .Parameters.Add("@PTRO31", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked)

                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text

                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

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
                .CommandText = sql.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDAT", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & BS.Count
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try

1:          Me.ds = New DataSet
            SqlDataAdapter1.Fill(ds, "PETRO")
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.ds.Tables("PETRO")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Me.Count()
            If Me.DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                End If
            Else
                Me.DelRow = False
            End If
            Consum.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.Update(ds, "PETRO")
            'ds = New DataSet
            'SqlDataAdapter1.Fill(ds, "PETRO")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                Me.PictureBox2False()
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
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
                Me.ButtonXP5_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.ds.Tables("PETRO")
            Me.TEXTID.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & BS.Count - RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            End If
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
            Consum.Close()
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
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds.Tables("PETRO").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.TrueFalse()
        Me.AutoEx()
        Me.DateMovementHistory.Text = Me.TextDateMovementHistory.Text
        AccountsEnquiry()
        Me.FundBalance()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonPostToCustomerTraffic.Enabled = TransferofAccounts
        Me.ButtonUpdateA.Enabled = True
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonAttachDocument.Enabled = LockUpdate
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Private Sub UPDATEDATA()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "UPDATE PLASTIC SET PLST3 = @PLST3, PLST5 = @PLST5, PLST6 = @PLST6, PLST8 = @PLST8, PLST9 = @PLST9 WHERE PLST8 = '" & Me.TEXTID.EditValue & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
        cmd.Parameters.Add("@PLST3", SqlDbType.DateTime).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
        cmd.Parameters.Add("@PLST5", SqlDbType.Float).Value = Me.TEXTTotal.Text
        cmd.Parameters.Add("@PLST6", SqlDbType.NVarChar).Value = "›« Ê—… ‰ﬁ·"
        cmd.Parameters.Add("@PLST8", SqlDbType.NVarChar).Value = Me.TEXTID.EditValue
        cmd.Parameters.Add("@PLST9", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If RadioButton7.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioButton6.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioButton5.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
    Private Sub DELETEDATA()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "DELETE FROM PLASTIC  WHERE PLST8 = '" & Me.TEXTID.EditValue & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub INSERTDATA()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(PLST1) FROM PLASTIC", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Dim sql As String = "INSERT INTO PLASTIC( PLST3, PLST5, PLST6, PLST8, PLST9) VALUES  ( @PLST3, @PLST5, @PLST6, @PLST8, @PLST9)"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
        cmd.Parameters.Add("@PLST1", SqlDbType.Int).Value = Val(N) + 1
        cmd.Parameters.Add("@PLST3", SqlDbType.DateTime).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
        cmd.Parameters.Add("@PLST5", SqlDbType.Float).Value = Me.TEXTTotal.Text
        cmd.Parameters.Add("@PLST6", SqlDbType.NVarChar).Value = "›« Ê—… ‰ﬁ·"
        cmd.Parameters.Add("@PLST8", SqlDbType.NVarChar).Value = Me.TEXTID.EditValue
        cmd.Parameters.Add("@PLST9", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub DELETEDATACUSTOMER1()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "DELETE FROM CABLES  WHERE CAB8 = '" & Me.TEXTID.EditValue.ToString & "'" & "AND CAB12='›« Ê—… ‰ﬁ·'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub DELETEDATA1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATA2()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber1, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub MAXIDCAB1()
        On Error Resume Next
        Dim N As Int64
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES WHERE CUser='" & CUser & "'and   Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Strings.Mid(cmd1.ExecuteScalar(), 7)
        NO1 = CType(Year, Integer) & String.Concat(New String() {CUser})
        Dim cusera As Double = CDbl(CUser)
        Select Case cusera
            Case 1 To 9
                NO = "000"
            Case 10 To 99
                NO = "00"
            Case 100 To 999
                NO = "0"
            Case Else
                NO = ""
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        If IsDBNull(resualt) Then
            IDCAB1 = CType(NO1, Integer) & 1
        Else
            N = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            IDCAB1 = N
        End If
        Consum.Close()
    End Sub
    Private Sub MAXIDCAB2()
        On Error Resume Next
        Dim N As Int64
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES WHERE CUser='" & CUser & "'and   Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Strings.Mid(cmd1.ExecuteScalar(), 7)
        NO1 = CType(Year, Integer) & String.Concat(New String() {CUser})
        Dim cusera As Double = CDbl(CUser)
        Select Case cusera
            Case 1 To 9
                NO = "000"
            Case 10 To 99
                NO = "00"
            Case 100 To 999
                NO = "0"
            Case Else
                NO = ""
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        If IsDBNull(resualt) Then
            IDCAB2 = CType(NO1, Integer) & 1
        Else
            N = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            IDCAB2 = N
        End If
        Consum.Close()
    End Sub


    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        Try
            Me.FundBalance()
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Year(DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("⁄›Ê« .. «·”‰… «·„Õ«”»Ì… €Ì— ’ÕÌÕ… ›·« Ì„ﬂ‰ «·„ﬁ«—‰…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Val(TEXTTotal.Text) <> (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue)) Then
                MsgBox("⁄›Ê« .. ÌÃ» «‰ ÌﬂÊ‰ «Ã„«·Ì «·’‰œÊﬁ Ê«·‘Ìﬂ „”«ÊÌ «·Ï «Ã„«·Ì «·›« Ê—…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim ch As Double
            Dim ch1 As Double
            ch = Format(Val(TEXTTotalN.Text), "0.000")
            ch1 = Format(Val(TextFundBalance.Text), "0.000")
            If ch1 < ch Then
                MsgBox("«‰ »Â —’»œ «·’‰œÊﬁ ·« Ìﬂ›Ì ·Â–Â «·Õ—ﬂ…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = True Then
                MsgBox("·«Ì„ﬂ‰  ⁄œ»·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ «· ⁄œÌ· „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Static P As Integer
            P = Me.BS.Position
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.TEXTBOX3_TextChanged(sender, e)
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P
            Me.RecordCount()
            Me.SHOWBUTTON()
            Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub FundBalance()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
        Me.SHOWBUTTON()
        Me.TrueFalse()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferToAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ Õ–› „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        Else
            Dim resault As Integer
            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ Õ—ﬂ… «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Me.DELETEDATACUSTOMER1()
                MYDELETERECORD("PETRO", "PTRO1", TEXTID, BS, True)
                FrmTRANSPORT_Load(sender, e)
                Insert_Actions(Me.TEXTID.EditValue, "Õ–›", Me.Text)
            Else
                Exit Sub
            End If

            If Me.TextMovementRestrictions.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…") '1
            Else
                Me.DELETEDATMOVESDATA()
                Me.DELETEDATMOVESDATA1()
            End If
            If Me.TextMovementRestrictions1.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…") '2
            Else
                Me.DELETEDATMOVESDATA2()
                Me.DELETEDATMOVESDATA3()
            End If
            If Me.TextFundMovementNumber.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…") '3
            Else
                DELETEDATAempsolf()
            End If
            If Me.TextCheckMovementNumber.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…") '4
            Else
                Me.DELETEDATBANK()
            End If
            If Me.TextCustomerTrafficNumber.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '5
            Else
                Me.DELETEDATA1()
            End If
            If Me.TextCustomerTrafficNumber1.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '6
            Else
                Me.DELETEDATA2()
            End If
            MYDELETERECORD("PETRO", "PTRO1", TEXTID, BS, True) '7
            Me.ButtonXP5_Click(sender, e)
            Insert_Actions(Me.TEXTID.EditValue, "Õ–›", Me.Text)
        End If
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim F As New FrmPRINT
            Dim txtFromDate As String
            Dim txtToDate As String
            txtFromDate = Format(Me.DateFrom.Value, "dd-MM-yyyy")
            txtToDate = Format(Me.DateTO.Value, "dd-MM-yyyy")
            If Me.CheckUnreviewedRecords.Checked = False Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt5 As New rptTransport51
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt5, DBServer, "", "")
                Dim str As New SqlClient.SqlCommand("SELECT * FROM PETRO  WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO5 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
                Dim builder32 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "PETRO")

                If ds.Tables(0).Rows.Count > 0 Then
                    rpt5.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt5.Section1.ReportObjects("Text8")
                    txt.Text = "Œ·«· «·› —… „‰" & " " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt5.Section1.ReportObjects("TEXT22")
                    txt.Text = AssociationName
                    txt = rpt5.Section1.ReportObjects("TEXT21")
                    txt.Text = Directorate
                    txt = rpt5.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt5.Section1.ReportObjects("TEXT40")
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt5.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt5
                    F.CrystalReportViewer1.Zoom(94%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Consum.Close()
            ElseIf Me.CheckUnreviewedRecords.Checked = True Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt6 As New rptTransport51
                Dim ds6 As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt6, DBServer, "", "")
                Dim str1 As New SqlClient.SqlCommand("SELECT * FROM PETRO  WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO5 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND  " & "PTRO22 ='" & False & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
                ds6.Clear()
                SqlDataAdapter1.Fill(ds6, "PETRO")
                If ds6.Tables(0).Rows.Count > 0 Then
                    rpt6.SetDataSource(ds6)
                    Dim txt As TextObject
                    txt = rpt6.Section1.ReportObjects("Text8")
                    txt.Text = "Œ·«· «·› —… „‰" & " " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt6.Section1.ReportObjects("TEXT22")
                    txt.Text = AssociationName
                    txt = rpt6.Section1.ReportObjects("TEXT21")
                    txt.Text = Directorate
                    txt = rpt6.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt6.Section1.ReportObjects("TEXT40")
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt6.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt6
                    F.CrystalReportViewer1.Zoom(94%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                    'MessageBox.Show(" ÊÃœ »Ì«‰«  Õ«·Ì… ", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Else
                    MessageBox.Show("...·«  ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If


            End If
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            If Me.ComboPaymentMethod.Text = "‰ﬁœ«_‘Ìﬂ" Then
                Connection.ACONET1.Add("«·’‰œÊﬁ")
                Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            End If
            AccountingprocedureAA()
            For XX1 As Integer = 0 To Connection.ACONET2.Count - 1
                Me.ACONETA.AppendText(Connection.ACONET2(XX1) & vbCrLf)
            Next
            MsgBox(Me.ACONETA.Text)
            Connection.ACONET3 = Me.ACONETA.Text.Trim
            UPDATE_Auditorsnotes()

        End If
    End Sub
    Private Sub TRANSFERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If CheckPostToCustomerTraffic.Checked = True Then
                MessageBox.Show(" ‰»ÌÂ. ﬁÌœ Õ—ﬂ… «·⁄„·«¡  „—Õ·" & ControlChars.CrLf &
                            "1) «·€«¡  —ÕÌ·  «·Ï Õ—ﬂ… «·⁄„·«¡" & ControlChars.CrLf &
                            "2) ﬁ„ » —ÕÌ· «·Ï «·Õ”‹‹‹‹‹‹‹«»«  ", "Œÿ√", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonTransferofAccounts.Enabled = False
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            Dim N As Double
            Me.ComboBox1_SelectedIndexChanged(sender, e)
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()

            If Me.CheckPostToCustomerTraffic.Checked = True Then
                If Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, N)), "0.000") = 0 Then
                    MsgBox("⁄›Ê« ·« Ì„ﬂ‰..   „   ”ÊÌ… Õ—ﬂ… «·⁄„Ì·", 16, " ‰»ÌÂ")
                    Me.ButtonTransferofAccounts.Enabled = False
                    Exit Sub
                End If
            End If
            Me.ButtonViewrestrictions_Click(sender, e)

            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Static P As Integer
            If OBCHK6 = True Then
                If Me.CheckTransferToAccounts.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferToAccounts.Checked = True
                        TransforAccounts()
                        Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        TransforAccounts()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œÊﬁ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferToAccounts.Checked = False
                            Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œÊﬁ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '======================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "‘Ìﬂ" Then
                    If Me.ComboCheckDrawerName.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· «”„ ”«Õ» «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.ComboCheckDrawerName.Focus()
                        Exit Sub
                    End If
                    If Me.TextCheckNumber.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· —ﬁ„ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.TextCheckNumber.Focus()
                        Exit Sub
                    End If
                    If Me.CheckDate.Value = Nothing Then
                        MsgBox("ÌÃ» ≈œŒ«·  «—ÌŒ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.CheckDate.Focus()
                        Exit Sub
                    End If

                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·‘Ìﬂ«   ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "‰ﬁœ«_‘Ìﬂ" Then
                    If Me.ComboCheckDrawerName.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· «”„ ”«Õ» «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.ComboCheckDrawerName.Focus()
                        Exit Sub
                    End If
                    If Me.TextCheckNumber.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· —ﬁ„ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.TextCheckNumber.Focus()
                        Exit Sub
                    End If
                    If Me.CheckDate.Value = Nothing Then
                        MsgBox("ÌÃ» ≈œŒ«·  «—ÌŒ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.CheckDate.Focus()
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œÊﬁ Ê «·‘Ìﬂ«  —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œ“ﬁ Ê «·‘Ìﬂ«  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            P = Me.BS.Position
            Me.TEXTBOX3_TextChanged(sender, e)
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P
            Me.RecordCount()
            Me.SHOWBUTTON()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub TEXTBOX3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTQuantity.EditValueChanged
        On Error Resume Next
        Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
    End Sub
    Private Sub TEXTBOX20_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTO.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.PRINTBUTTON_Click(sender, e)
        End Select
    End Sub
    Private Sub TEXTBOX19_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateFrom.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateTO.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTNetValue.TextChanged, TEXTTotalValue.TextChanged, TEXTTaxRate.TextChanged, TEXTUnitPrice.EditValueChanged, TextTaxes.EditValueChanged, TEXTQuantity.EditValueChanged, TEXTLoadingExpenses.EditValueChanged, TEXTTransfers.EditValueChanged

        On Error Resume Next
        Me.TEXTTotalValue.Text = Format(Val(Me.TEXTQuantity.EditValue) * Val(Me.TEXTUnitPrice.EditValue), "0.000")
        Me.TEXTTaxRate.Text = Format(Val(Me.TEXTTotalValue.Text) * Val(Me.TextTaxes.EditValue), "0.000")
        Me.TEXTNetValue.Text = Format(Val(Me.TEXTTotalValue.Text) - Val(Me.TEXTTaxRate.Text), "0.000")
        Me.TEXTTotal.Text = Format(Val(Me.TEXTTaxRate.Text) + Val(Me.TEXTLoadingExpenses.EditValue) + Val(Me.TEXTTransfers.Text), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
    End Sub
    Private Sub TEXTUnitPrice_LostFocus(sender As Object, e As EventArgs) Handles TEXTUnitPrice.LostFocus
        TEXTBOX2_TextChanged(sender, e)
    End Sub
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust, cust22 FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "AllCustomers")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            TypeCustomer = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextCustomerNumber.EditValue = ""
            TypeCustomer = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferToAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ·«Ì„ﬂ‰ „—«Ã⁄… «·”Ã·«  ﬁ»· «· —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.RecordCount()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Insert_Actions(Me.TEXTID.EditValue, "«·„—«Ã⁄", Me.Text)
        MsgBox(" „  ⁄„·Ì… «·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckLogReview.Checked = False Then
            MsgBox("⁄›Ê« .. Â–« «·”Ã· €Ì— „—«Ã⁄ ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Insert_Actions(Me.TEXTID.EditValue, "≈·€«¡ «·„—«Ã⁄…", Me.Text)
        MsgBox(" „  ⁄„·Ì… ≈·€«¡ «·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
    End Sub
    Private Sub TrueFalse()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False
        Else
            If Me.CheckTransferToAccounts.Checked = True Then
                Me.EDITBUTTON.Enabled = False
                Me.BUTTONCANCEL.Enabled = True
                Me.DELETEBUTTON.Enabled = False
                Me.PRINTBUTTON.Enabled = True
                Me.InternalAuditorERBUTTON.Enabled = True
            Else
                Me.SHOWBUTTON()
            End If
        End If

    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTCarNumbers.Enabled = False
            Me.ComboITEMNAME.Enabled = False
            Me.TEXTQuantity.Enabled = False
            Me.TEXTTotalValue.Enabled = False
            Me.TextTaxes.Enabled = False
            Me.TEXTTaxRate.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTLoadingExpenses.Enabled = False
            Me.TEXTTransfers.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False
        ElseIf Me.CheckTransferToAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonPostToCustomerTraffic.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

            Me.DateMovementHistory.Enabled = True
            Me.TEXTCarNumbers.Enabled = True
            Me.ComboITEMNAME.Enabled = True
            Me.TEXTQuantity.Enabled = True
            Me.TEXTTotalValue.Enabled = True
            Me.TextTaxes.Enabled = True
            Me.TEXTTaxRate.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTLoadingExpenses.Enabled = True
            Me.TEXTTransfers.Enabled = True
            Me.TEXTStatement.Enabled = True
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTCarNumbers.Enabled = False
            Me.ComboITEMNAME.Enabled = False
            Me.TEXTQuantity.Enabled = False
            Me.TEXTTotalValue.Enabled = False
            Me.TextTaxes.Enabled = False
            Me.TEXTTaxRate.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTLoadingExpenses.Enabled = False
            Me.TEXTTransfers.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.DateMovementHistory.Enabled = True
            Me.TEXTCarNumbers.Enabled = True
            Me.ComboITEMNAME.Enabled = True
            Me.TEXTQuantity.Enabled = True
            Me.TEXTTotalValue.Enabled = True
            Me.TextTaxes.Enabled = True
            Me.TEXTTaxRate.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTLoadingExpenses.Enabled = True
            Me.TEXTTransfers.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.PanelAccount.Enabled = True
        End If
    End Sub


    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds.Tables(0).Rows.Count > 0 Then
            account_noF = ds2.Tables(0).Rows(0).Item(0)
            ACCF = ds2.Tables(0).Rows(0).Item(2)
            account_nameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            account_noF = ""
            ACCF = ""
            account_nameF = ""
        End If

        Consum.Close()

        AutoEx()
    End Sub

    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.TextCreditAccount.Text & " " & ":" & " " & Me.TEXTID.EditValue & " " & "» «—ÌŒ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "··⁄„Ì·" & " " & ":" & " " & Me.ComboCustomerName.Text & " " & "„À» … »ÊÀÌﬁ… —ﬁ„" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
        LabelAutoEx.Text = ExResult
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            MYDELETERECORD("CASHIER", "CSH1", TextFundMovementNumber, BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("Â·  —Ìœ ≈·€«¡  Õœ»À «·Õ”«»«  «·«› —«÷Ì… ", " Õœ»À «·Õ”«»« ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                OptionsTransforAccountsTo(ComboPaymentMethod.Text, ComboDebitAccount.Text, TextCreditAccount.Text)
                PanelAccount.Enabled = True
            Else
                Check_OptionsTransforAccounts.Checked = False
                PanelAccount.Enabled = False
            End If
        Else
            PanelAccount.Enabled = False
        End If
    End Sub






    Private Sub TransforCustomerTraffic()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing

            nem = " Õ„Ì· " & " " & Me.TextCreditAccount.Text.Trim & " " & "⁄·Ï «·⁄„Ì·" & " " & Me.ComboCheckDrawerName.Text.Trim

            PMO2 = 1
            DebitAccount_No = keyAccounts.GetValue("CustomerAccount_No", CustomerAccount_No)
            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            CredAccount_NO = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam

            SEARCHDATA.MaxIDMoves()

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, True, TEXTTotal.Text, TEXTTotal.Text, T3, "ﬁÌœ", "BTA", TextMovementSymbol.EditValue, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, True, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTTotal.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, True, T2)

            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTID.EditValue,
                      "„. ›« Ê—… ‰ﬁ·" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‘Ìﬂ"
                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTID.EditValue,
                     "„ . ›« Ê—… ‰ﬁ·" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‰ﬁœ«_‘Ìﬂ"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTID.EditValue,
                      "„. ›« Ê—… ‰ﬁ·" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)

                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTID.EditValue,
                     "„ . ›« Ê—… ‰ﬁ·" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
            End Select

        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = " ›« Ê—… ‰ﬁ· —ﬁ„" & " " & Me.TEXTID.EditValue
        nem1 = "’—› ›« Ê—… ‰ﬁ· —ﬁ„" & " " & Me.TEXTID.EditValue
        nem2 = " ›« Ê—… ‰ﬁ· »Ì„ÊÃ» „” ‰œ —ﬁ„" & " " & Me.TextCheckNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()


        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "ﬁÌœ", "TL", TextMovementSymbol.EditValue, False)
        If OBCHK6 = True Then
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "‘Ìﬂ"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                              TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Case "‰ﬁœ«_‘Ìﬂ"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)


            End Select

        End If

    End Sub
    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
            Case "‘Ìﬂ"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "‰ﬁœ«_‘Ìﬂ"
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub


    Private Sub  AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
                LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = FundAccount_Name
            Case "‘Ìﬂ"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
            Case "‰ﬁœ«_‘Ìﬂ"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
                LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
        End Select
    End Sub
    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
         AccountsEnquiry()
    End Sub

    Private Sub DELETEDATBANK()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("Checks", "IDCH", TextCheckMovementNumber, BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", TextMovementRestrictions, BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", MOVESFalseDELET, BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA2()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", TextMovementRestrictions1, BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA3()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", MOVESTrueDELET, BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.RadioButton7.Checked = True Then
            Dim Adp As SqlClient.SqlDataAdapter
            On Error Resume Next
            Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                TypeCustomer = ds.Tables(0).Rows(0).Item(1)
            Else
                Me.TextCheckDrawerCode.Text = ""
                TypeCustomer = ""
            End If
            Adp.Dispose()
            Consum.Close()
        ElseIf Me.RadioButton6.Checked = True Then
            Dim Adp1 As SqlClient.SqlDataAdapter
            On Error Resume Next
            Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlClient.SqlDataAdapter(strsql)
            ds1.Clear()
            Adp1.Fill(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
            Else
                Me.TextCheckDrawerCode.Text = ""
            End If
            Adp1.Dispose()
            Consum.Close()
        ElseIf Me.RadioButton5.Checked = True Then
            Dim Adp2 As SqlClient.SqlDataAdapter
            On Error Resume Next
            Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds2 As New DataSet
            Adp2 = New SqlClient.SqlDataAdapter(strsq2)
            ds2.Clear()
            Adp2.Fill(ds2)
            If ds2.Tables(0).Rows.Count > 0 Then
                Me.TextCheckDrawerCode.Text = ds2.Tables(0).Rows(0).Item(0)
            Else
                Me.TextCheckDrawerCode.Text = ""
            End If
            Adp2.Dispose()
            Consum.Close()
        End If
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPostToCustomerTraffic.Click
        Try
            Dim resault As Integer
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = False Then
                MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.ComboBox1_SelectedIndexChanged(sender, e)
            Me.ButtonViewrestrictions_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Static P As Integer
            If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Ï «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
                        Else
                            Me.DELETEDATA1()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '5
                        Else
                            Me.DELETEDATA2()
                        End If
                        TransforCustomerTraffic()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                '======================================================================================================
            ElseIf ComboPaymentMethod.Text = "‘Ìﬂ" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
                        Else
                            Me.DELETEDATA1()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '5
                        Else
                            Me.DELETEDATA2()
                        End If
                        TransforCustomerTraffic()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA1()
                            Me.DELETEDATA2()
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                '=============================================================================================================
            Else
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï Õ—ﬂ… «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Ï Õ—ﬂ…«·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
                        Else
                            Me.DELETEDATA1()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '5
                        Else
                            Me.DELETEDATA2()
                        End If
                        ''========================================
                        TransforCustomerTraffic()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA1()
                            Me.DELETEDATA2()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If
            P = Me.BS.Position
            Me.TEXTBOX3_TextChanged(sender, e)
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MOVES")
            f.BS.DataMember = "MOVES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("MOV2", Me.TextMovementRestrictions.Text.Trim)
            f.TB2 = Me.TextMovementRestrictions.Text.Trim
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MOVES")
            f.BS.DataMember = "MOVES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("MOV2", Me.TextMovementRestrictions1.Text.Trim)
            f.TB2 = Me.TextMovementRestrictions1.Text.Trim
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.TextCheckMovementNumber.Text.Trim)
            f.TB1 = Me.TextCheckMovementNumber.Text.Trim
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CASHIER")
            f.BS.DataMember = "CASHIER"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("CSH1", Me.TextFundMovementNumber.Text.Trim)
            f.TB1 = Me.TextFundMovementNumber.Text.Trim
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCustomerTrafficNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber.Text.Trim)
            f.TB1 = Trim(Me.TextCustomerTrafficNumber.Text)
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCustomerTrafficNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT * FROM CABLES WHERE  CUser='" & CUser & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber1.Text.Trim)
            f.TB1 = Trim(Me.TextCustomerTrafficNumber1.Text)
            f.Show()
            f.DanLOd()
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            'TEXTID.Clear()
            PictureBox2.Visible = True
            RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List1.MouseDoubleClick
        TextCreditAccount.Text = List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpCreditAccount.Value)
            Me.List1.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub

    Private Sub ButtonViewrestrictions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = Conversion.Val(SEARCHDATA.MOV1C)
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = Conversion.Val(SEARCHDATA.MOV1B)

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
        SEARCHDATA.SEARCHCABLES(Me.TEXTID.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber.Text = SEARCHDATA.IDCAB
        SEARCHDATA.SEARCHCABLES1(Me.TEXTID.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber1.Text = SEARCHDATA.IDCAB1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
    End Sub

    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork

    End Sub

    Private Sub BackWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker3.DoWork

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("⁄⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… ≈—›«ﬁ «·„” ‰œ« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
           Dim XLO As Int64
            XLO = Me.TEXTID.EditValue
            Dim f As New FrmJPG0
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = Val(XLO)
            f.TEXTFileSubject.Text = "„” ‰œ«  „ . ‰ﬁ· "
            f.TextFileDescription.Text = "«—›«ﬁ „” ‰œ«  „ . ‰ﬁ· „Ã„⁄… "
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO  FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
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
                If Me.CheckLogReview.Checked = True Then
                    f.ButScan.Enabled = False
                    f.ButLogq.Enabled = False
                    f.EDITBUTTON.Enabled = False
                    f.DELETEBUTTON.Enabled = False
                End If
            Else
                MsgBox("·« ÌÊÃœ «Ì „” ‰œ« ", 64 + 524288, " ‰»ÌÂ")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
         AccountsEnquiry()
        FundBalance()
    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()

        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)
    End Sub



    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)
            BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateMovementHistory.ValueChanged
        On Error Resume Next
        Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub


End Class