Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class FrmSuppliers1
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
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Dim p As Integer
    Dim dt1 As Date
    Dim nem, nem1, nem2, nem3 As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Dim CHK As Boolean = False
<<<<<<< HEAD
    Private Sub FrmSuppliers1_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmSuppliers1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmSuppliers1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmSuppliers1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        Me.ButtonPREEVIEW_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.TabPage4.Show()
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.TabPage4.Show()
                        Me.ButtonCancellationAuditingAndACheckingAccounts_Click(sender, e)
                    Case Keys.F9
                        Me.ButtonSearch_Click(sender, e)
                    Case Keys.F10
                        Me.ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonresourcePayment_Click(sender, e)
                    Case Keys.F12
                        Me.CHK = False
                        Me.InternalAuditorType()
                        Me.EDITBUTTON.Enabled = False
                        Me.DELETEBUTTON.Enabled = False
                        Me.BALANCEBUTTON.Enabled = False
                        Me.InternalAuditorERBUTTON.Enabled = False
                        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
                    Case Keys.F5 And (e.Alt And Not e.Control And Not e.Shift)

                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        Me.BALANCEBUTTON_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonXP5_Click(sender, e)
                    Case Keys.K And (e.Alt And Not e.Control And Not e.Shift)
                        Me.TabPage4.Show()
                        Me.Buttoncalcluter_Click(sender, e)
                    Case Keys.M And (e.Alt And Not e.Control And Not e.Shift)
                        Me.TabControl1.SelectedIndex = 1
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
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonresourcePayment.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.ComboSupplierName.Enabled = False
            'Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboSource.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboCondition.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.CheckDate.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
        ElseIf Me.CheckTransferToAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonresourcePayment.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.ComboSupplierName.Enabled = False
            'Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboSource.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboCondition.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.CheckDate.Enabled = False
            If Me.CHK = True Then
                Me.ComboSupplierName.Enabled = True
                'Me.TEXTID.Enabled = True
                Me.DateMovementHistory.Enabled = True
                Me.ComboSource.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.ComboCondition.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.ComboPaymentMethod.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.ComboCheckDrawerName.Enabled = True
                Me.TextCheckNumber.Enabled = True
                Me.CheckDate.Enabled = True
            End If
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonresourcePayment.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.ComboSupplierName.Enabled = False
            'Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboSource.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboCondition.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.CheckDate.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.ComboSupplierName.Enabled = True
            'Me.TEXTID.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboSource.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.ComboCondition.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.ComboPaymentMethod.Enabled = True
            Me.TextFundValue.Enabled = True
            Me.TextValueOfCheck.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.TextCheckNumber.Enabled = True
            Me.CheckDate.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.ComboDebitAccount.Enabled = True
            Me.PicCreditAccount.Enabled = True
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.ButtonSearch.Enabled = LockPrint
        Me.ButtonPREEVIEW.Enabled = LockPrint
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonUpdateA.Enabled = True
        Me.ButtonresourcePayment.Enabled = TransferofAccounts
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonAttachDocument.Enabled = LockAddRow

    End Sub
<<<<<<< HEAD
    Private Sub FrmSuppliers1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmSuppliers1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next

        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
    End Sub
<<<<<<< HEAD
    Private Sub FrmSuppliers1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmSuppliers1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Me.DELETEBUTTON.Enabled = False
        Me.BALANCEBUTTON.Enabled = False
        Me.ButtonSearch.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.BALANCEBUTTON.Enabled = False
        Me.ButtonresourcePayment.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False

        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        Me.CHK = False
        Me.BackWorker2.WorkerReportsProgress = True
        Me.BackWorker2.WorkerSupportsCancellation = True
        Me.BackWorker3.WorkerReportsProgress = True
        Me.BackWorker3.WorkerSupportsCancellation = True

    End Sub
<<<<<<< HEAD
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New ComponentModel.BackgroundWorker With {
=======
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboSupplierName, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboPaymentMethod, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboSupplierName, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboPaymentMethod, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.TEXTStatement, e, )
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
<<<<<<< HEAD
        Me.BackWorker2 = New ComponentModel.BackgroundWorker With {
=======
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try
1:

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Auditor, Cuser, COUser, da, ne, da1, ne1  FROM Suppliers1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and IDCAB ='" & Strings.Trim(Me.TB1) & "'"
                Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Auditor, Cuser, COUser, da, ne, da1, ne1  FROM Suppliers1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and IDCAB ='" & Strings.Trim(Me.TB1) & "'"
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                If Consum.State = ConnectionState.Closed Then Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "Suppliers1")
                Me.SqlDataAdapter1.Fill(Me.myds, "Suppliers1")
                Me.myds.RejectChanges()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End With
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
        ''

    End Sub
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("Suppliers1")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "IDCAB", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CAB2", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CAB3", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CAB4", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CAB5", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CAB6", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CAB7", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CAB8", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CAB9", True, 1, "")
            Me.ComboSupplierName.DataBindings.Add("text", Me.BS, "CAB10", True, 1, "")
            Me.TextSupplierNumber.DataBindings.Add("text", Me.BS, "CAB11", True, 1, "")
            Me.ComboCondition.DataBindings.Add("text", Me.BS, "CAB12", True, 1, "")
            Me.CheckTransferToAccounts.DataBindings.Add("Checked", Me.BS, "CAB13", True, 1, "")
            Me.TextFundValue.DataBindings.Add("text", Me.BS, "CAB14", True, 1, "") 'نقدا
            Me.TextValueOfCheck.DataBindings.Add("text", Me.BS, "CAB15", True, 1, "")
            Me.ComboSource.DataBindings.Add("text", Me.BS, "CAB16", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CAB17", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CAB18", True, 1, "")
            Me.CheckSettlementDone.DataBindings.Add("Checked", Me.BS, "CAB19", True, 1, "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", Me.BS, "CAB20", True, 1, "")
            Me.TextCheckDrawerCode.DataBindings.Add("text", Me.BS, "CAB21", True, 1, "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "CAB22", True, 1, "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "CAB23", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")
            Me.ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Me.SumAmounCABLESBALANCE()
            FundBalance()

            Auditor("Suppliers1", "USERNAME", "IDCAB", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboSupplierName)
            FILLCOMBOBOX1("CABLES", "CAB9", "CUser", CUser, Me.TEXTStatement)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpDebitAccount.Value, Me.ComboDebitAccount)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.Text, 2)
        GetAutoNumber("CSH1", "CASHIER", "CSH2")

        Try
            Dim strSQL2 As New SqlCommand("SELECT distinct  CAB15 FROM Suppliers1 ", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.ComboSource.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim strSQL5 As New SqlCommand("SELECT distinct  CAB9 FROM Suppliers1 ", Consum)
            Consum.Open()
            DR = strSQL5.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.TEXTStatement.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Me.BUTTONCANCEL.Enabled = True
        Me.LabelLoadDataBase.Visible = False
        Call CloseDB()
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Auditor, Cuser, COUser, da, ne, da1, ne1  FROM Suppliers1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Auditor, Cuser, COUser, da, ne, da1, ne1  FROM Suppliers1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                If Consum.State = ConnectionState.Closed Then Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "Suppliers1")
                Me.SqlDataAdapter1.Fill(Me.myds, "Suppliers1")
                Me.myds.RejectChanges()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End With
            Auditor("Suppliers1", "USERNAME", "IDCAB", Me.TEXTID.EditValue, "")
            Logentry = Uses
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
        ''

    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.LabelLoadDataBase.Visible = True
                Me.LabelLoadDataBase.ForeColor = Color.Yellow
                Me.LabelLoadDataBase.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
            Else
                Me.LabelLoadDataBase.ForeColor = Color.Red
                Me.LabelLoadDataBase.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)

            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("Suppliers1")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "IDCAB", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CAB2", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CAB3", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CAB4", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CAB5", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CAB6", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CAB7", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CAB8", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CAB9", True, 1, "")
            Me.ComboSupplierName.DataBindings.Add("text", Me.BS, "CAB10", True, 1, "")
            Me.TextSupplierNumber.DataBindings.Add("text", Me.BS, "CAB11", True, 1, "")
            Me.ComboCondition.DataBindings.Add("text", Me.BS, "CAB12", True, 1, "")
            Me.CheckTransferToAccounts.DataBindings.Add("Checked", Me.BS, "CAB13", True, 1, "")
            Me.TextFundValue.DataBindings.Add("text", Me.BS, "CAB14", True, 1, "") 'نقدا
            Me.TextValueOfCheck.DataBindings.Add("text", Me.BS, "CAB15", True, 1, "")
            Me.ComboSource.DataBindings.Add("text", Me.BS, "CAB16", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CAB17", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CAB18", True, 1, "")
            Me.CheckSettlementDone.DataBindings.Add("Checked", Me.BS, "CAB19", True, 1, "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", Me.BS, "CAB20", True, 1, "")
            Me.TextCheckDrawerCode.DataBindings.Add("text", Me.BS, "CAB21", True, 1, "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "CAB22", True, 1, "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "CAB23", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")
            Me.ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Me.SumAmounCABLESBALANCE()
            FundBalance()
            Auditor("Suppliers1", "USERNAME", "IDCAB", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboSupplierName)
            FILLCOMBOBOX1("CABLES", "CAB9", "CUser", CUser, Me.TEXTStatement)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpDebitAccount.Value, Me.ComboDebitAccount)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.Text, 2)
        GetAutoNumber("CSH1", "CASHIER", "CSH2")
        Try
            Dim strSQL2 As New SqlCommand("SELECT distinct  CAB15 FROM Suppliers1 ", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.ComboSource.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim strSQL5 As New SqlCommand("SELECT distinct  CAB9 FROM Suppliers1 ", Consum)
            Consum.Open()
            DR = strSQL5.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.TEXTStatement.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Me.BUTTONCANCEL.Enabled = True
        Me.LabelLoadDataBase.Visible = False
        Call CloseDB()
    End Sub
    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE Suppliers1 SET CAB2 = @CAB2, CAB3 = @CAB3, CAB4 = @CAB4, CAB5 = @CAB5, CAB6 = @CAB6, CAB7 = @CAB7, CAB8 = @CAB8, CAB9 = @CAB9, CAB10 = @CAB10, CAB11 = @CAB11, CAB12 = @CAB12, CAB13 = @CAB13, CAB14 = @CAB14, CAB15 = @CAB15, CAB16 = @CAB16, CAB17 = @CAB17, CAB18 = @CAB18, CAB19 = @CAB19, CAB20 = @CAB20, CAB21 = @CAB21, CAB22 = @CAB22, CAB23 = @CAB23, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE IDCAB = @IDCAB", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE Suppliers1 SET CAB2 = @CAB2, CAB3 = @CAB3, CAB4 = @CAB4, CAB5 = @CAB5, CAB6 = @CAB6, CAB7 = @CAB7, CAB8 = @CAB8, CAB9 = @CAB9, CAB10 = @CAB10, CAB11 = @CAB11, CAB12 = @CAB12, CAB13 = @CAB13, CAB14 = @CAB14, CAB15 = @CAB15, CAB16 = @CAB16, CAB17 = @CAB17, CAB18 = @CAB18, CAB19 = @CAB19, CAB20 = @CAB20, CAB21 = @CAB21, CAB22 = @CAB22, CAB23 = @CAB23, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE IDCAB = @IDCAB", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCAB", SqlDbType.Int).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CAB2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CAB7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.ComboSupplierName.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextSupplierNumber.Text
                .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = Me.ComboCondition.Text
                .Parameters.Add("@CAB13", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
                .Parameters.Add("@CAB14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CAB15", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CAB16", SqlDbType.NVarChar).Value = Me.ComboSource.Text
                .Parameters.Add("@CAB17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CAB18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.Text
                .Parameters.Add("@CAB19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettlementDone.Checked)
                .Parameters.Add("@CAB20", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CAB21", SqlDbType.Int).Value = Val(Me.TextCheckDrawerCode.Text)
                .Parameters.Add("@CAB22", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CAB23", SqlDbType.Date).Value = Me.CheckDate.Text.Trim
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text

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
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try

1:          Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "Suppliers1")
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
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("Suppliers1")
            Me.PictureBox2.Visible = False
            Me.TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            Me.Count()
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try

1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "Suppliers1")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "Suppliers1")
            'myds.RejectChanges()
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Me.BS.DataSource = Me.myds.Tables("Suppliers1")
            Me.TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            Me.SumAmounFINALBALANCE5CASHANDCHEQUES()
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "الارصدة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
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
            Me.PictureBox4.Visible = False
            Me.PictureBox5.Visible = False
            Me.ComboSupplierName.Focus()
            Me.ComboSupplierName.SelectAll()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.RecordCount()
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
        If Me.BS.Position < Me.myds.Tables("Suppliers1").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward

        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.Text, 2)
        Me.AutoEx()
        Me.SumAmounCABLESBALANCE()
        Me.SumAmounFINALBALANCE5()
        Me.SumAmounFINALBALANCE4()
        Me.dt1 = Me.TextDateMovementHistory.Text
        Me.DateMovementHistory.Value = Me.dt1.ToString("yyyy-MM-dd")
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.AddType1()
    End Sub

    Private Sub SumAmounCABLESBALANCE()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp1 = New SqlDataAdapter(strsql)
=======
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Me.TEXTTotal.Text = Format(Val(SUM1), "0.000")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE5CASHANDCHEQUES1()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "' ", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp1 = New SqlDataAdapter(strsql)
=======
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Me.TEXTCurrentBalance.Text = Format(Val(SUM1), "0.000")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE5CASHANDCHEQUES()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'AND Suppliers1.IDCAB <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp1 = New SqlDataAdapter(strsql)
=======
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Me.TEXTPreviousBalance.Text = Format(Val(SUM1), "0.000")
        Consum.Close()
        Me.SumAmounFINALBALANCE5CASHANDCHEQUES1()

    End Sub
    Private Sub GETCABLENOWBALANCE()
        On Error Resume Next
        Dim n As Double
        Dim F As Double
        n = Me.BS.Position
        Me.BS.EndEdit()
        If Me.BS.Position = 0 Then
            Me.TEXTPreviousBalance.Text = 0
        ElseIf Me.BS.Position > 0 Then
            F = 0
            Me.BS.Position = Me.BS.Position - 1
            F = Val(Me.TEXTCurrentBalance.Text)
            Me.BS.Position = Me.BS.Position + 1
            Me.TEXTPreviousBalance.Text = F
            'Me.SumAmounFINALBALANCE5CASHANDCHEQUES()
        End If
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
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextLSet.Text.ToString <> "SU" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن تعدبل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.PictureBox2.Visible = True
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
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub ButtonPREEVIEW_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPREEVIEW.Click
=======
    Private Sub ButtonPREEVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPREEVIEW.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
<<<<<<< HEAD
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.RadioButton1.Checked = True Then
            Dim rpt As New rptSuppliers11
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If

            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Suppliers1   WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB11='" & Me.TextSupplierNumber.Text & "'", Consum)
            Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("Text21")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.CloseView(NUpDebitAccount.Value)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton2.Checked = True Then
            Dim rpt As New rptSupplies1
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If

            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("Text21")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.CloseView(NUpDebitAccount.Value)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RadioButton7.Checked = True Then
            Dim rpt As New rptSupplies1
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If

            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB17='" & False & "'", Consum)
            Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("Text21")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.CloseView(NUpDebitAccount.Value)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If



        End If

    End Sub
<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckSettlementDone.Checked = True Then
            MsgBox("لايمكن حذف  السجل الحالى لأنه تم التسوية ... يمكن حذف من خلال زر تسديد مورد", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextLSet.Text.ToString <> "SU" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن حذف  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        MYDELETERECORD("Suppliers1", "IDCAB", Me.TEXTID, Me.BS, True)
        Me.ButtonXP5_Click(sender, e)
        Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
    End Sub
<<<<<<< HEAD
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BALANCEBUTTON.Click
=======
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        On Error Resume Next
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Dim I As Integer
        For I = 0 To Me.BS.Count + 1
            Me.BS.Position = I
            Me.ProgressBar1.Visible = True
            Me.ProgressBar1.Minimum = 1
            Me.ProgressBar1.Maximum = Me.BS.Count - 1
            Me.ProgressBar1.Value = I
            Me.GETCABLENOWBALANCE()
            Me.UPDATERECORD()
        Next
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
        Me.BS.Position = 0
        Me.ProgressBar1.Visible = False
        Me.PictureBox2.Visible = False
        Click3 = True
        'Me.ProgressBar1.Visible = True
        'Me.PictureBox2.Visible = True
        'Me.ProgressBar1.Minimum = 1
        'Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        'If Not Me.BackWorker3.IsBusy Then
        '    Me.BackWorker3.CancelAsync()
        'End If
    End Sub
<<<<<<< HEAD
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles stepBALANCE.Click
=======
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stepBALANCE.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub
    Private Sub BackWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker3.DoWork
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            For I = 1 To CInt(Me.BS.Count)
                If Me.BackWorker3.CancellationPending Then
                    e.Cancel = True
                    Return
                End If
                Me.BS.Position = I
                Me.BackWorker3.ReportProgress(I)
            Next
            Me.GETCABLENOWBALANCE()
            Me.UPDATERECORD()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDoWorkBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
        On Error Resume Next
        Me.ProgressBar1.Value = e.ProgressPercentage
        Dim num2 As Integer = CInt(Math.Round(CDbl(CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum) * 100)))
        Using graphics As Graphics = Me.ProgressBar1.CreateGraphics
            Dim point As New PointF(CSng(CDbl(Me.ProgressBar1.Width) / 2) - (graphics.MeasureString(num2.ToString & "%", SystemFonts.DefaultFont).Width / 2.0!), CSng(CDbl(Me.ProgressBar1.Height) / 2) - (graphics.MeasureString(num2.ToString & "%", SystemFonts.DefaultFont).Height / 2.0!))
            graphics.DrawString(num2.ToString & "%", SystemFonts.DefaultFont, Brushes.Black, point)
        End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorProgressChangedBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub BackWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker3.RunWorkerCompleted
        Try
            If e.Cancelled Then
                Me.BackWorker3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.PictureBox2.Visible = False
            ElseIf e.Error IsNot Nothing Then
                Me.Label14.Text = "Error: " & e.Error.Message
            Else
                Me.BackWorker3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.PictureBox2.Visible = False
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
                'Me.BS.Position = 0
                ModuleGeneral.Click3 = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompletedBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If RECORDSLABEL.Text.Trim = "" Then Beep() : Exit Sub
        Me.BS.MoveFirst()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If RECORDSLABEL.Text.Trim = "" Then Beep() : Exit Sub
        Me.BS.MovePrevious()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If RECORDSLABEL.Text.Trim = "" Then Beep() : Exit Sub
        Me.BS.MoveNext()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If RECORDSLABEL.Text.Trim = "" Then Beep() : Exit Sub
        Me.BS.MoveLast()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX3_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX11_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
=======
    Private Sub TEXTBOX11_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged, TEXTCurrentBalance.TextChanged
=======
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged, TEXTCurrentBalance.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTCredit.EditValue) - Val(Me.TEXTDebit.EditValue), "0.000")
        On Error Resume Next
        If Val(Me.TEXTCurrentBalance.Text) = "0" Then
            Me.CheckSettlementDone.Checked = True
        Else
            Me.CheckSettlementDone.Checked = False
        End If
        'If Val(Me.TEXTBOX4.Text) = "0" Then
        '    Me.ComboBox2.Text = "نقدا"
        '    Me.ComboBox2.Enabled = False
        '    Me.GroupCHKS.Enabled = False
        '    Me.GroupCHKS1.Enabled = False
        'Else
        '    Me.ComboBox2.Enabled = True
        '    Me.GroupCHKS.Enabled = True
        '    Me.GroupCHKS1.Enabled = True
        'End If
    End Sub
<<<<<<< HEAD
    Private Sub TEXTDebit_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTDebit.KeyPress
=======
    Private Sub TEXTDebit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTDebit.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub SumAmounFINALBALANCE5()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'" & "AND CAB6='نقدا'", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp1 = New SqlDataAdapter(strsql)
=======
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        'Me.TextBox15.Text = Format(Val(SUM1), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE4()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'" & "AND CAB6='شيك'", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp1 = New SqlDataAdapter(strsql)
=======
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        'Me.TextBox16.Text = Format(Val(SUM1), "0.000")
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1,sup2,cuser,couser  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1,sup2,cuser,couser  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextSupplierNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSupplierNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        Me.SumAmounFINALBALANCE5CASHANDCHEQUES()
    End Sub
    Private Function UPDATEALLCUSTOMERS1()
<<<<<<< HEAD
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        Dim con As SqlConnection
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsql)
=======
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        Dim con As SqlClient.SqlConnection
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables("Suppliers1").Rows.Count > 0 Then
            UPDATEALLCUSTOMERS1 = Format(Val(ds1.Tables("Suppliers1").Rows(0).Item(0)), "0.000")
        Else
            UPDATEALLCUSTOMERS1 = "0"
        End If
        Consum.Close()
    End Function
<<<<<<< HEAD
    Private Sub TextBox19_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextGoTo.TextChanged
=======
    Private Sub TextBox19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextGoTo.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.TextGoTo.TextLength > 0 Then
                Dim index As Integer
                index = Me.BS.Find("IDCAB", Me.TextGoTo.Text.Trim)
                Me.BS.Position = index
                Me.RecordCount()
            Else
                Me.BS.Position = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim F As New FrmAdvancedSearchSuppliers
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttoncalcluter.Click
=======
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Process.Start("calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
=======
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferToAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.RecordCount()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
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
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXTID.EditValue, "المراجع", Me.Text)
    End Sub

<<<<<<< HEAD
    Private Sub ButtonCancellationAuditingAndACheckingAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub ButtonCancellationAuditingAndACheckingAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.PictureBox2.Visible = True
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
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXTID.EditValue, "إلغاء المراجعة", Me.Text)
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonUpdateA.Click
=======
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
<<<<<<< HEAD
            Me.RefreshTab = New ComponentModel.BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButtonSearch_Click_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearch.Click
=======
    Private Sub ButtonSearch_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim F As New FrmAdvancedSearchSuppliers
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


<<<<<<< HEAD
    Private Sub ButtonresourcePayment_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonresourcePayment.Click
=======
    Private Sub ButtonresourcePayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonresourcePayment.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = False Then
                MsgBox("عفوا .. يجب ترحيل اولا الى الحســـــــابات اولا ", 16, "تنبيه")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            Dim MA As Integer
            'Dim MA1 As Integer
            Dim FF As Integer
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim cmd1 As New SqlCommand("SELECT MAX(IDCAB) FROM Suppliers1", Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM Suppliers1", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                MA = 1
            Else
                MA = CType(resualt, Integer) + 1
            End If

            FundBalance()
            Dim n As Double
            Dim s As Double
            Dim ch As Double
            Dim ch1 As Double

            Static P As Integer
            Consum.Close()
            'If Me.TextBox7.Text >= 0 Then
            If Me.ComboPaymentMethod.Text = "نقدا" Then
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للمورد " & Me.ComboSupplierName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Try
                            s = Val(Me.Text1.Text)
                            Dim naum, naum1, naum2, naum3, naum4 As String
                            naum = Me.ComboSupplierName.Text
                            naum1 = Me.TextFundValue.EditValue
                            naum2 = Me.ComboCB1.Text
                            naum3 = Me.ComboBN2.Text
                            naum4 = Me.ComboPaymentMethod.Text
                            Dim d As Date = ServerDateTime.ToString("yyyy-MM-dd")
                            Me.CheckSettlementDone.Checked = True
                            Me.CheckTransferToAccounts.Checked = True
                            Me.CheckLogReview.Checked = True
                            Application.DoEvents()
                            Me.BS.EndEdit()
                            Me.BS.AddNew()
                            CLEARDATA1(Me)
                            Me.CheckSettlementDone.Checked = True
                            Me.CheckTransferToAccounts.Checked = True
                            Me.CheckLogReview.Checked = False
                            Me.ComboSupplierName.Text = naum
                            Me.ComboBox1_SelectedIndexChanged(sender, e)
                            Me.ComboBox5_SelectedIndexChanged(sender, e)
                            Me.TEXTID.EditValue = Val(MA)
                            Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                            Me.ComboSource.Text = "حركات الموردين"
                            Me.TEXTCredit.EditValue = "0.00"
                            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                            Me.ComboCondition.Text = "نقدا"
                            Me.TEXTStatement.Text = "سداد للمورد" & "- " & Me.ComboSupplierName.Text
                            Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TextMovementSymbol.Text = "SU" & Me.TEXTID.EditValue
                            Me.ComboPaymentMethod.Text = "نقداً"
                            Me.ComboSupplierName.Text = naum
                            Me.TextFundValue.EditValue = naum1
                            Me.ComboCB1.Text = naum2
                            Me.ComboBN2.Text = naum3
                            Me.ComboPaymentMethod.Text = naum4
                            Me.TextValueOfCheck.EditValue = "0.00"
                            Dim Frm As New SuppliersPay1
                            Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Frm.ShowDialog()
                            Me.TEXTDebit.EditValue = Val(Frm.TextB1.Text)
                            FF = Val(Frm.TextB1.Text)
                            Me.TEXTDebit.EditValue = FF
                            ch = Val(Me.TextFundBalance.Text)
                            ch1 = Me.TEXTDebit.EditValue
                            If ch < ch1 Then
                                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                                Me.BUTTONCANCEL_Click(sender, e)
                                Exit Sub
                            End If
                            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.CheckLogReview.Checked = False
                            Me.Count()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        P = Me.BS.Position
                        Dim d1 As Date = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")

                        Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), TEXTDebit.EditValue, TEXTCredit.EditValue, ComboPaymentMethod.Text, TEXTDocumentNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, ComboSource.Text, TextMovementSymbol.Text,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                        Me.RecordCount()
                        Me.TextDateMovementHistory.Text = d1

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.Text, 0, TextFundValue.EditValue, Me.Text,
                                              "سداد من حساب حركة الموردين رقم " & " _ " & Me.TEXTID.EditValue, False, TEXTID.EditValue,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)


                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للمورد" & "- " & Me.ComboSupplierName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        ch = Val(Me.TextFundBalance.Text)
                        ch1 = Me.TEXTDebit.EditValue
                        If ch < ch1 Then
                            MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                            Me.BUTTONCANCEL_Click(sender, e)
                            Exit Sub
                        End If
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.Count()
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDATMOVESDATA2()
                        End If
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.Text, 0, TextFundValue.EditValue, Me.Text,
                                              "سداد من حساب حركة الموردين رقم " & " _ " & Me.TEXTID.EditValue, False, TEXTID.EditValue,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)


                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                        Me.RecordCount()
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل حركة الموردين", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة الموردين", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            P = Me.BS.Position
                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATCASHIER1()
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text = "شيك" Then
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للمورد " & Me.ComboSupplierName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Try
                            n = Me.BS.Count
                            Me.BS.Position = Me.BS.Count - 1
                            s = Val(Me.Text1.Text)
                            Dim naum, naum1, naum3, naum4, naum5, naum6, naum7, naum8, naum9 As String
                            naum = Me.ComboSupplierName.Text
                            naum1 = Me.ComboCheckDrawerName.Text
                            naum6 = Me.TextCheckDrawerCode.Text
                            naum3 = Me.TextValueOfCheck.EditValue
                            naum4 = Me.TextCheckNumber.Text
                            naum5 = Me.CheckDate.Text
                            naum7 = Me.ComboCB1.Text
                            naum8 = Me.ComboBN2.Text
                            naum9 = Me.ComboPaymentMethod.Text
                            Dim d As Date = ServerDateTime.ToString("yyyy-MM-dd")
                            Me.CheckSettlementDone.Checked = True
                            Me.CheckTransferToAccounts.Checked = True
                            Me.CheckLogReview.Checked = True
                            Application.DoEvents()
                            Me.BS.EndEdit()
                            Me.BS.AddNew()
                            CLEARDATA1(Me)
                            Me.CheckSettlementDone.Checked = True
                            Me.CheckTransferToAccounts.Checked = True
                            Me.CheckLogReview.Checked = False
                            Me.TEXTID.EditValue = Val(MA)
                            Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                            Me.ComboSource.Text = "حركات الموردين"
                            Me.TEXTCredit.EditValue = "0.00"
                            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                            Me.ComboCondition.Text = "نقدا"
                            Me.TEXTStatement.Text = "سداد للمورد" & "- " & Me.ComboSupplierName.Text
                            Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TextMovementSymbol.Text = "SU" & Me.TEXTID.EditValue
                            Me.ComboPaymentMethod.Text = "نقداً"
                            Me.ComboSupplierName.Text = naum
                            Me.ComboCheckDrawerName.Text = naum1
                            Me.TextValueOfCheck.EditValue = naum3
                            Me.TextCheckNumber.Text = naum4
                            Me.CheckDate.Text = naum5
                            Me.TextCheckDrawerCode.Text = naum6
                            Me.ComboCB1.Text = naum7
                            Me.ComboBN2.Text = naum8
                            Me.ComboPaymentMethod.Text = naum9
                            Me.TextFundValue.EditValue = "0.00"
                            Me.ComboBox1_SelectedIndexChanged(sender, e)
                            Me.ComboBox5_SelectedIndexChanged(sender, e)
                            Dim Frm As New SuppliersPay1
                            Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Frm.ShowDialog()
                            Me.TEXTDebit.EditValue = Val(Frm.TextB1.Text)
                            FF = Val(Frm.TextB1.Text)
                            Me.TEXTDebit.EditValue = FF
                            ch = Val(Me.TextFundBalance.Text)
                            ch1 = Me.TEXTDebit.EditValue
                            If ch < ch1 Then
                                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                                Me.BUTTONCANCEL_Click(sender, e)
                                Exit Sub
                            End If
                            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.CheckLogReview.Checked = False
                            Me.Count()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        P = Me.BS.Position
                        Dim d1 As Date = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")

                        Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), TEXTDebit.EditValue, TEXTCredit.EditValue, ComboPaymentMethod.Text, TEXTDocumentNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, ComboSource.Text, TextMovementSymbol.Text,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                        Me.RecordCount()
                        Me.TextDateMovementHistory.Text = d1

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), 0,
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                          TextMovementSymbol.Text, False, ComboCB1.Text, ComboBN2.Text)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للمورد" & "- " & Me.ComboSupplierName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        ch = Val(Me.TextFundBalance.Text)
                        ch1 = Me.TEXTDebit.EditValue
                        If ch < ch1 Then
                            MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                            Me.BUTTONCANCEL_Click(sender, e)
                            Exit Sub
                        End If
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.Count()
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDATMOVESDATA2()
                        End If
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), 0,
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                          TextMovementSymbol.Text, False, ComboCB1.Text, ComboBN2.Text)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                        Me.RecordCount()
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل حركة الموردين", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة الموردين", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATBANK1()
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للمورد " & Me.ComboSupplierName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Try
                            n = Me.BS.Count
                            Me.BS.Position = Me.BS.Count - 1
                            s = Val(Me.Text1.Text)
                            Dim naum, naum1, naum2, naum3, naum4, naum5, naum6, naum7, naum8, naum9 As String
                            naum = Me.ComboSupplierName.Text
                            naum1 = Me.ComboCheckDrawerName.Text
                            naum6 = Me.TextCheckDrawerCode.Text
                            naum2 = Me.TextFundValue.EditValue
                            naum3 = Me.TextValueOfCheck.EditValue
                            naum4 = Me.TextCheckNumber.Text
                            naum5 = Me.CheckDate.Text
                            naum7 = Me.ComboCB1.Text
                            naum8 = Me.ComboBN2.Text
                            naum9 = Me.ComboPaymentMethod.Text
                            Dim d As Date = ServerDateTime.ToString("yyyy-MM-dd")
                            Me.CheckSettlementDone.Checked = True
                            Me.CheckTransferToAccounts.Checked = True
                            Me.CheckLogReview.Checked = True
                            Application.DoEvents()
                            Me.BS.EndEdit()
                            Me.BS.AddNew()
                            CLEARDATA1(Me)
                            Me.CheckSettlementDone.Checked = True
                            Me.CheckTransferToAccounts.Checked = True
                            Me.CheckLogReview.Checked = False
                            Me.ComboSupplierName.Text = naum
                            Me.ComboBox1_SelectedIndexChanged(sender, e)
                            Me.ComboBox5_SelectedIndexChanged(sender, e)
                            Me.TEXTID.EditValue = Val(MA)
                            Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                            Me.ComboSource.Text = "حركات الموردين"
                            Me.TEXTCredit.EditValue = "0.00"
                            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                            Me.ComboCondition.Text = "نقدا"
                            Me.TEXTStatement.Text = "سداد للمورد" & "- " & Me.ComboSupplierName.Text
                            Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.TextMovementSymbol.Text = "SU" & Me.TEXTID.EditValue
                            Me.ComboPaymentMethod.Text = "نقداً"
                            Me.ComboSupplierName.Text = naum
                            Me.ComboCheckDrawerName.Text = naum1
                            Me.TextFundValue.EditValue = naum2
                            Me.TextValueOfCheck.EditValue = naum3
                            Me.TextCheckNumber.Text = naum4
                            Me.CheckDate.Text = naum5
                            Me.TextCheckDrawerCode.Text = naum6
                            Me.ComboCB1.Text = naum7
                            Me.ComboBN2.Text = naum8
                            Me.ComboPaymentMethod.Text = naum9
                            Dim Frm As New SuppliersPay1
                            Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Frm.ShowDialog()
                            Me.TEXTDebit.EditValue = Val(Frm.TextB1.Text)
                            FF = Val(Frm.TextB1.Text)
                            Me.TEXTDebit.EditValue = FF
                            ch = Val(Me.TextFundBalance.Text)
                            ch1 = Me.TEXTDebit.EditValue
                            If ch < ch1 Then
                                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                                Me.BUTTONCANCEL_Click(sender, e)
                                Exit Sub
                            End If
                            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                            Me.CheckLogReview.Checked = False
                            Me.Count()
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        P = Me.BS.Position
                        Dim d1 As Date = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")

                        Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), TEXTDebit.EditValue, TEXTCredit.EditValue, ComboPaymentMethod.Text, TEXTDocumentNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, ComboSource.Text, TextMovementSymbol.Text,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                        Me.RecordCount()
                        Me.TextDateMovementHistory.Text = d1

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.Text, 0, TextFundValue.EditValue, Me.Text,
                                              "سداد من حساب حركة الموردين رقم " & " _ " & Me.TEXTID.EditValue, False, TEXTID.EditValue,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), 0,
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                          TextMovementSymbol.Text, False, ComboCB1.Text, ComboBN2.Text)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.BS.Position = P
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للمورد" & "- " & Me.ComboSupplierName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        P = Me.BS.Position
                        ch = Val(Me.TextFundBalance.Text)
                        ch1 = Me.TEXTDebit.EditValue
                        If ch < ch1 Then
                            MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                            Me.BUTTONCANCEL_Click(sender, e)
                            Exit Sub
                        End If
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.TextSupplierNumber.Text, MA)), "0.000")
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDATMOVESDATA2()
                        End If
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.Text, 0, TextFundValue.EditValue, Me.Text,
                                              "سداد من حساب حركة الموردين رقم " & " _ " & Me.TEXTID.EditValue, False, TEXTID.EditValue,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), 0,
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                          TextMovementSymbol.Text, False, ComboCB1.Text, ComboBN2.Text)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                        Me.RecordCount()
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.BS.Position = P
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل حركة الموردين", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة الموردين", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            P = Me.BS.Position

                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATCASHIER1()
                            Me.DELETEDATBANK1()
                            Me.UPDATERECORD()
                            Me.BS.RemoveCurrent()
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
                        Else
                            Exit Sub
                        End If
                    End If
                End If

            End If
            P = Me.BS.Position
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.Position = P
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioResetText.CheckedChanged
=======
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call Me.AddType1()
    End Sub

    Private Sub AddType1()
        On Error Resume Next
        If RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RadioSUPPLIER.Checked = True Then
<<<<<<< HEAD
                Dim Adp1 As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlDataAdapter(strsql)
=======
                Dim Adp1 As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds1.Clear()
                Adp1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf Me.RadioEMPLOYEES.Checked = True Then
<<<<<<< HEAD
                Dim Adp2 As SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlDataAdapter(strsq2)
=======
                Dim Adp2 As SqlClient.SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlClient.SqlDataAdapter(strsq2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
=======
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")

        If ds2.Tables(0).Rows.Count > 0 Then
            Me.account_noF = ds2.Tables(0).Rows(0).Item(0)
            Me.account_nameF = ds2.Tables(0).Rows(0).Item(2)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.account_noF = ""
            Me.account_nameF = ""
            Me.ACCF = ""
        End If
        Me.Text1.Text = Me.ACCF
        Me.Text2.Text = Me.account_noF

    End Sub

    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "فاتورة رقم" & " " & ":" & " " & Me.TEXTID.EditValue & " " & "بتاريخ" & " " & ":" & " " & Me.TextDateMovementHistory.Text & " "
        ExResult += "من حساب الموردين" & " " & ":" & " " & Me.ComboSupplierName.Text & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV1 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MOVES")
            f.BS.DataMember = "MOVES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("MOV1", Me.TextMovementRestrictions.Text.Trim)
            f.TB1 = Me.TextMovementRestrictions.Text.Trim
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

<<<<<<< HEAD
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV1 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MOVES")
            f.BS.DataMember = "MOVES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("MOV1", Me.TextMovementRestrictions1.Text.Trim)
            f.TB1 = Me.TextMovementRestrictions1.Text.Trim
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

<<<<<<< HEAD
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

    Private Sub DELETEDATCASHIER()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATCASHIER1()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATBANK()
        Try
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATBANK1()
        Try
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub SaveMOVES()
        Try
            SEARCHDATA.MAXIDMOVES()
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1
                .Parameters.Add("@MOV2", SqlDbType.NVarChar).Value = T2
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "قيد"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "SU"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.Text
                .Parameters.Add("@MOV12", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
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

    Private Sub SaveMOVES1()
        Try
            SEARCHDATA.MAXIDMOVES()
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1
                .Parameters.Add("@MOV2", SqlDbType.NVarChar).Value = T2
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = True
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "صرف"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "SU"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.Text
                .Parameters.Add("@MOV12", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
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

    Private Sub DELETEDATMOVES()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATARecord()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA1()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions1, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA2()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELET, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub SaveMOVESDATARecord()

        Try
            Dim Box, Box1, Box2, Box3, Box4, Box5 As Integer
            nem = " فاتورة رقم " & "_" & Me.Text2.Text
            nem1 = " فاتورة الموردين نقدي رقم " & "_" & Me.TEXTID.EditValue
            nem2 = " فاتورة بيموجب مستند رقم " & "_" & Me.TextCheckNumber.Text
            nem3 = " فاتورة الموردين ذمم دائنة "
            p = "1"

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            Box = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
            Box1 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboDebitAccount.Text, 1)
            Box2 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboDebitAccount.Text, 1)
            Box3 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.TextCreditAccount.Text, 1)
            Box4 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.TextCreditAccount.Text, 1)
            Box5 = ID_Nam
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            Dim CMD As New SqlCommand
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            With strSQL
                .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TEXTCredit.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.Text & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2 & "')"
                CMD.CommandType = CommandType.Text
                CMD.Connection = Consum
                CMD.CommandText = strSQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()

                .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & p.ToString + 1 & "','" & Me.TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TEXTCredit.EditValue & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.Text & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2 & "')"
                CMD.CommandType = CommandType.Text
                CMD.Connection = Consum
                CMD.CommandText = strSQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()


            End With
        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub SaveMOVESDATARecord1()
        Try
            Dim Box, Box1, Box2, Box3, Box4, Box5 As Integer
            nem = "سداد فاتورة الموردين رقم " & "_" & Me.TEXTID.EditValue
            nem1 = "سداد فاتورة الموردين نقدي رقم " & "_" & Me.TEXTID.EditValue
            nem2 = "سداد فاتورة الموردين بيموجب مستند رقم " & "_" & Me.TextCheckNumber.Text
            nem3 = "سداد فاتورة الموردين ذمم دائنة "
            p = "1"
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            Box = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
            Box1 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboDebitAccount.Text, 1)
            Box2 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboDebitAccount.Text, 1)
            Box3 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.TextCreditAccount.Text, 1)
            Box4 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.TextCreditAccount.Text, 1)
            Box5 = ID_Nam


<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            Dim CMD As New SqlCommand
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            With strSQL
                If Me.ComboPaymentMethod.Text.Trim = "نقدا" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TextFundValue.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & p.ToString + 1 & "','" & Me.TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextFundValue.EditValue & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.ComboPaymentMethod.Text.Trim = "شيك" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TextValueOfCheck.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
          & p.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextValueOfCheck.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.ComboPaymentMethod.Text.Trim = "نقدا_شيك" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
             & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TEXTDebit.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & p.ToString + 1 & "','" & ModuleGeneral.CB2.ToString & "','" & Box.ToString.Trim & "','" & 0 & "','" & Me.TextFundValue.EditValue & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & p.ToString + 2 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextValueOfCheck.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.Text.Trim & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2 & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                End If
            End With
        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



<<<<<<< HEAD
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List1.MouseDoubleClick
=======
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List1.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextCreditAccount.Text = Me.List1.SelectedItem(0).ToString
        Me.List1.Visible = False
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
<<<<<<< HEAD
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCreditAccount.Click
=======
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCreditAccount.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
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


    Sub AccountingprocedureA()
        'Accountingprocedure = True
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                Connection.ACONET1.Add("الصندوق")
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            End If
            Me.ACONETA.Clear()
            AccountingprocedureAA()
            For XX1 As Integer = 0 To Connection.ACONET2.Count - 1
                Me.ACONETA.AppendText(Connection.ACONET2(XX1) & vbCrLf)
            Next
            MsgBox(Me.ACONETA.Text)
            Connection.ACONET3 = Me.ACONETA.Text.Trim
            UPDATE_Auditorsnotes()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
=======
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextLSet.Text.ToString <> "SU" Then
                MsgBox("عفوا .. لايمكن ترحيل  السجل الحالى لأنه مرحل", 16, "تنبيه")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            If TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckSettlementDone.Checked = True Then
                MsgBox("لايمكن ترحيل  السجل الحالى لأنه تم التسوية ... يمكن ترحيل من خلال زر تسديد مورد", 16, "تنبيه")
                Exit Sub
            End If
            'AccountingprocedureA()
            'Exit Sub
            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            Static P As Integer
            'If OBCHK3 = True Then

            'Else

            'End If

            If Me.CheckTransferToAccounts.Checked = False Then
                resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية رفم " & Me.TEXTID.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferToAccounts.Checked = True
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    P = Me.BS.Position
                    Me.Cursor = Cursors.WaitCursor
                    Me.PictureBox2.Visible = True
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
                    Me.BS.Position = P
                    Me.RecordCount()
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions.Text = Nothing Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        Me.DELETEDATMOVES()
                        Me.DELETEDATMOVESDATARecord()
                    End If
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    P = Me.BS.Position
                    Me.Cursor = Cursors.WaitCursor
                    Me.PictureBox2.Visible = True
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
                    Me.BS.Position = P
                    Me.RecordCount()
                    AccountingprocedureA()
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                Else
                    resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول القيود اليومية ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.DELETEDATMOVES()
                        Me.DELETEDATMOVESDATARecord()
                        Me.CheckTransferToAccounts.Checked = False
                        P = Me.BS.Position
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
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
                        Me.BS.Position = P
                        Me.RecordCount()
                        Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية  رقم" & " " & Me.TEXTID.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
=======
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.EditValue = "0.00"
                Me.TextValueOfCheck.EditValue = "0.00"
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
            Case "شيك"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.TextFundValue.EditValue = "0.00"
                Me.TextValueOfCheck.EditValue = "0.00"
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.EditValue = "0.00"
                Me.TextValueOfCheck.EditValue = "0.00"
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True

        End Select
    End Sub

<<<<<<< HEAD
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        Me.account_nameF = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.Text.Trim)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C

        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.Text)
        Me.TextMovementRestrictions1.Text = SEARCHDATA.MOV1B

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.Text)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.Text, Me.TEXTDocumentNumber.Text)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.Text)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
    End Sub
<<<<<<< HEAD
    Private Sub FrmSuppliers1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
=======
    Private Sub FrmSuppliers1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click

        Try
=======
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click

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
            GetAutoNumberMyDOCUMENTSFL(TextMovementSymbol.Text)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim f As New FrmJPG0
            f.Show()
=======
           Dim XLO As Int64
            XLO = Me.TEXTID.EditValue
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
            f.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.Text
            f.TEXTFileNo.Text = documentId
=======
            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.Text
            f.TEXTFileNo.Text = Val(XLO)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.TEXTFileSubject.Text = "مستندات حسابات الموردين "
            f.TextFileDescription.Text = "ارفاق مستندات حسابات الموردين"
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO  FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.Text) & "'ORDER BY DOC1", Consum)
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
                If Me.CheckLogReview.Checked = True Then
                    f.ButScan.Enabled = False
                    f.ButLogq.Enabled = False
                    f.EDITBUTTON.Enabled = False
                    f.DELETEBUTTON.Enabled = False
                End If
            Else
                MsgBox("لا يوجد اي مستندات", 64 + 524288, "تنبيه")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub
    Private Sub FundBalance()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
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
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        FundBalance()
    End Sub
<<<<<<< HEAD
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles DateMovementHistory.ValueChanged
=======
    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateMovementHistory.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub
End Class

