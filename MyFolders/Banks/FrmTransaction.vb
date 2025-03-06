Option Explicit Off

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmTransaction
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter
    Private WithEvents ConnectDataBase As BackgroundWorker
    Private WithEvents SaveTab As BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents RefreshTab As BackgroundWorker
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim nem As String
    Dim Documenttype As String
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Dim CHK As Boolean = False
    Dim Deposit As Boolean = False


<<<<<<< HEAD
    Private Sub FrmTransaction_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmTransaction_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmTransaction_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmTransaction_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonXP1_Click(sender, e)
                    Case Keys.F9
                        Me.ButtonSearch_Click(sender, e)
                    Case Keys.F10
                        Me.ButtonTRANSFER_Click(sender, e)
                    Case Keys.F12
                        Me.CHK = True
                        Me.InternalAuditorType()
                        Me.EDITBUTTON.Enabled = False
                        Me.DELETEBUTTON.Enabled = False
                        Me.BALANCEBUTTON.Enabled = False
                        Me.InternalAuditorERBUTTON.Enabled = False
                        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        Me.BALANCEBUTTON_Click(sender, e)
                    Case Keys.D And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonCertifacate_Click(sender, e)
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
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonEnquiry.Enabled = True
            Me.ButtonSavingsCertificates.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboAccountNumber.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.PanelAccount.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonEnquiry.Enabled = True
            Me.ButtonSavingsCertificates.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboAccountNumber.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TEXTStatement.Enabled = False
            If Me.CHK = True Then
                Me.ComboAccountNumber.Enabled = True
                Me.DateMovementHistory.Enabled = True
                Me.ComboConstraintType.Enabled = True
                Me.ComboAccountType.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.GroupPaymentMethod.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                Me.PanelAccount.Enabled = True
            End If
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonEnquiry.Enabled = True
            Me.ButtonSavingsCertificates.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboAccountNumber.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.PanelAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.ComboAccountNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboConstraintType.Enabled = True
            Me.ComboAccountType.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.PanelAccount.Enabled = True
        End If
    End Sub
<<<<<<< HEAD
    Private Sub FrmDeposits_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmDeposits_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
    End Sub
<<<<<<< HEAD
    Private Sub FrmTransaction_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmTransaction_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.ButtonEnquiry.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.BALANCEBUTTON.Enabled = False
        Me.ButtonSavingsCertificates.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False

        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        Me.FundBalance()
        Me.CHK = False

        Me.BackWorker2.WorkerReportsProgress = True
        Me.BackWorker2.WorkerSupportsCancellation = True
        Me.BackWorker3.WorkerReportsProgress = True
        Me.BackWorker3.WorkerSupportsCancellation = True

    End Sub
<<<<<<< HEAD
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        ConnectDataBase = New BackgroundWorker With {
=======
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(ComboDebitAccount, e, )
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
<<<<<<< HEAD
        BackWorker2 = New BackgroundWorker With {
=======
        BackWorker2 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        BackWorker2.RunWorkerAsync()
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
<<<<<<< HEAD
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackWorker2.DoWork
=======
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM PTRANSACTION  WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK1 ='" & Strings.Trim(Me.TB1) & "'or TBNK6 ='" & Strings.Trim(Me.TB2) & "'or TBNK22 ='" & Strings.Trim(Me.TB3) & "' or  TBNK23 ='" & Strings.Trim(Me.TB4) & "'ORDER BY TBNK1"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM PTRANSACTION  WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK1 ='" & Strings.Trim(Me.TB1) & "'or TBNK6 ='" & Strings.Trim(Me.TB2) & "'or TBNK22 ='" & Strings.Trim(Me.TB3) & "' or  TBNK23 ='" & Strings.Trim(Me.TB4) & "'ORDER BY TBNK1"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                myds = New DataSet
                Consum.Open()
                SqlDataAdapter1.Fill(myds, "PTRANSACTION")
                Consum.Close()
                myds.RejectChanges()
            End With
            Auditor("PTRANSACTION", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorBackWorker2.DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Call CloseDB()
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
=======
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            BS.DataSource = myds.Tables("PTRANSACTION")
            RowCount = BS.Count
            TEXTID.DataBindings.Add("text", BS, "TBNK1", True, 1, "")
            TEXTPreviousBalance.DataBindings.Add("text", BS, "TBNK2", True, 1, "")
            TextDateMovementHistory.DataBindings.Add("text", BS, "TBNK3", True, 1, "")
            TEXTDebit.DataBindings.Add("text", BS, "TBNK4", True, 1, "")
            TEXTCredit.DataBindings.Add("text", BS, "TBNK5", True, 1, "")
            ComboAccountNumber.DataBindings.Add("text", BS, "TBNK6", True, 1, "")
            TEXTCurrentBalance.DataBindings.Add("text", BS, "TBNK7", True, 1, "")
            ComboAccountType.DataBindings.Add("text", BS, "TBNK8", True, 1, "")
            TEXTDocumentNumber.DataBindings.Add("text", BS, "TBNK9", True, 1, "")
            TEXTStatement.DataBindings.Add("text", BS, "TBNK10", True, 1, "")
            TextMovementSymbol.DataBindings.Add("text", BS, "TBNK11", True, 1, "")
            CheckArchivingDocumentWithScanner.DataBindings.Add("Checked", BS, "TBNK12", True, 1, "")
            CheckLogReview.DataBindings.Add("Checked", BS, "TBNK13", True, 1, "")
            ComboPaymentMethod1.DataBindings.Add("text", BS, "TBNK14", True, 1, "")
            TextValueOfCheck.DataBindings.Add("text", BS, "TBNK15", True, 1, "")
            TextFundValue.DataBindings.Add("text", BS, "TBNK16", True, 1, "")
            CheckTransferAccounts.DataBindings.Add("Checked", BS, "TBNK17", True, 1, "")
            ComboConstraintType.DataBindings.Add("text", BS, "TBNK18", True, 1, "")
            TextCheckNumber.DataBindings.Add("text", BS, "TBNK19", True, 1, "")
            CheckDate.DataBindings.Add("text", BS, "TBNK20", True, 1, "")
            ComboCheckDrawerName.DataBindings.Add("text", BS, "TBNK21", True, 1, "")
            TextMembersName.DataBindings.Add("text", BS, "TBNK22", True, 1, "")
            TextMembersCode.DataBindings.Add("text", BS, "TBNK23", True, 1, "")
            TextCheckDrawerCode.DataBindings.Add("text", BS, "TBNK24", True, 1, "")

            ComboCB1.DataBindings.Add("text", BS, "CB1", True, 1, "")
            ComboBN2.DataBindings.Add("text", BS, "BN2", True, 1, "")

            TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
            TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
            TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, 1, "")
            TextreviewTime.DataBindings.Add("text", BS, "ne1", True, 1, "")



            Auditor("PTRANSACTION", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber1)
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
            'FILLCOMBOBOX1("PTRANSACTION", "TBNK8", "CUser", CUser, Me.ComboAccountType)
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Me.ComboBN2_SelectedIndexChanged(sender, e)
            SetUpComboBox(ComboAccountType)
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
            AccountNoAktevd = ID_Nam

            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If

            TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Call MangUsers()
        If Me.TextLSet.Text.ToString <> "WD" Then
            ButtonTransferofAccounts.Enabled = False
        Else
            ButtonTransferofAccounts.Enabled = True
        End If
        Me.BUTTONCANCEL.Enabled = True
        Me.Label5.Visible = False
    End Sub
    Private Sub DISPLAYRECORD()
        Try
            With Me
                .TEXTID.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK1").ToString
                .TEXTPreviousBalance.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK2").ToString
                .TextDateMovementHistory.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK3").ToString
                .TEXTDebit.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK4").ToString
                .TEXTCredit.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK5").ToString
                .ComboAccountNumber.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK6").ToString
                .TEXTCurrentBalance.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK7").ToString
                .ComboAccountType.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK8").ToString
                .TEXTDocumentNumber.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK9").ToString
                .TEXTStatement.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK10").ToString
                .TextMovementSymbol.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK11").ToString
                .CheckArchivingDocumentWithScanner.Checked = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK12").ToString
                .CheckLogReview.Checked = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK13").ToString
                .ComboPaymentMethod1.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK14").ToString
                .TextValueOfCheck.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK15").ToString
                .TextFundValue.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK16").ToString
                .CheckTransferAccounts.Checked = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK17").ToString
                .ComboConstraintType.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK18").ToString
                .TextCheckNumber.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK19").ToString
                .CheckDate.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK20").ToString
                .TextMembersName.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK22").ToString
                .TextMembersCode.EditValue = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("TBNK23").ToString


                .TEXTUserName.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("USERNAME").ToString
                .TEXTReferenceName.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("Auditor").ToString
                .TextDefinitionDirectorate.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("COUser").ToString
                .TEXTAddDate.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("da").ToString
                .TextTimeAdd.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("ne").ToString
                .TEXTReviewDate.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("da1").ToString
                .TextreviewTime.Text = Me.myds.Tables("PTRANSACTION").Rows(Me.BS.Position).Item("ne1").ToString
            End With
            Auditor("PTRANSACTION", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber1)
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
            FILLCOMBOBOX1("PTRANSACTION", "TBNK8", "CUser", CUser, Me.ComboAccountType)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            RecordCount()
            'Me.ComboCB1_SelectedIndexChanged(sender, e)
            'Me.ComboBN2_SelectedIndexChanged(sender, e)
            Call MangUsers()
            If Me.TextLSet.Text.ToString <> "WD" Then
                ButtonTransferofAccounts.Enabled = False
            Else
                ButtonTransferofAccounts.Enabled = True
            End If
            Me.BUTTONCANCEL.Enabled = True
            Me.Label5.Visible = False
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Consum.Close()
    End Sub


<<<<<<< HEAD
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles ConnectDataBase.DoWork
=======
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            myds.EnforceConstraints = False
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM PTRANSACTION  WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY TBNK1"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM PTRANSACTION  WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY TBNK1"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                myds = New DataSet
                Consum.Open()
                SqlDataAdapter1.Fill(myds, "PTRANSACTION")
                Consum.Close()
                myds.RejectChanges()
            End With
            Auditor("PTRANSACTION", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "Error1", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Call CloseDB()
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf Me.LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Label5.Visible = True
                Label5.ForeColor = Color.Yellow
                Label5.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
            Else
                Label5.ForeColor = Color.Red
                Label5.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
=======
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            BS.DataSource = myds.Tables("PTRANSACTION")
            RowCount = BS.Count
            TEXTID.DataBindings.Add("text", BS, "TBNK1", True, 1, "")
            TEXTPreviousBalance.DataBindings.Add("text", BS, "TBNK2", True, 1, "")
            TextDateMovementHistory.DataBindings.Add("text", BS, "TBNK3", True, 1, "")
            TEXTDebit.DataBindings.Add("text", BS, "TBNK4", True, 1, "")
            TEXTCredit.DataBindings.Add("text", BS, "TBNK5", True, 1, "")
            ComboAccountNumber.DataBindings.Add("text", BS, "TBNK6", True, 1, "")
            TEXTCurrentBalance.DataBindings.Add("text", BS, "TBNK7", True, 1, "")
            ComboAccountType.DataBindings.Add("text", BS, "TBNK8", True, 1, "")
            TEXTDocumentNumber.DataBindings.Add("text", BS, "TBNK9", True, 1, "")
            TEXTStatement.DataBindings.Add("text", BS, "TBNK10", True, 1, "")
            TextMovementSymbol.DataBindings.Add("text", BS, "TBNK11", True, 1, "")
            CheckArchivingDocumentWithScanner.DataBindings.Add("Checked", BS, "TBNK12", True, 1, "")
            CheckLogReview.DataBindings.Add("Checked", BS, "TBNK13", True, 1, "")
            ComboPaymentMethod1.DataBindings.Add("text", BS, "TBNK14", True, 1, "")
            TextValueOfCheck.DataBindings.Add("text", BS, "TBNK15", True, 1, "")
            TextFundValue.DataBindings.Add("text", BS, "TBNK16", True, 1, "")
            CheckTransferAccounts.DataBindings.Add("Checked", BS, "TBNK17", True, 1, "")
            ComboConstraintType.DataBindings.Add("text", BS, "TBNK18", True, 1, "")
            TextCheckNumber.DataBindings.Add("text", BS, "TBNK19", True, 1, "")
            CheckDate.DataBindings.Add("text", BS, "TBNK20", True, 1, "")
            ComboCheckDrawerName.DataBindings.Add("text", BS, "TBNK21", True, 1, "")
            TextMembersName.DataBindings.Add("text", BS, "TBNK22", True, 1, "")
            TextMembersCode.DataBindings.Add("text", BS, "TBNK23", True, 1, "")
            TextCheckDrawerCode.DataBindings.Add("text", BS, "TBNK24", True, 1, "")
            ComboCB1.DataBindings.Add("text", BS, "CB1", True, 1, "")
            ComboBN2.DataBindings.Add("text", BS, "BN2", True, 1, "")
            TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
            TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
            TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, 1, "")
            TextreviewTime.DataBindings.Add("text", BS, "ne1", True, 1, "")

            Auditor("PTRANSACTION", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber1)
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
            'FILLCOMBOBOX1("PTRANSACTION", "TBNK8", "CUser", CUser, Me.ComboAccountType)
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Me.ComboBN2_SelectedIndexChanged(sender, e)
            TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            RecordCount()

            TestkeyAccounts(keyAccounts.GetValue("StockAccount_No", StockAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("StockAccount_No", StockAccount_No)
            End If
            SetUpComboBox(ComboAccountType)
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
            AccountNoAktevd = ID_Nam
            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Call MangUsers()
        If Me.TextLSet.Text.ToString <> "WD" Then
            ButtonTransferofAccounts.Enabled = False
        Else
            ButtonTransferofAccounts.Enabled = True
        End If
        Me.BUTTONCANCEL.Enabled = True
        Me.Label5.Visible = False
    End Sub
    Public Sub Count()
        On Error Resume Next
        RECORDSLABEL.Text = BS.Position + 1 & " من " & BS.Count
    End Sub
<<<<<<< HEAD
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles RefreshTab.DoWork
=======
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:
            myds = New DataSet
            SqlDataAdapter1.Fill(myds, "PTRANSACTION")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
=======
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = myds.Tables("PTRANSACTION")
            PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Count()
            If DelRow = False Then
                If BS.Count < RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf BS.Count > RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SaveTab.DoWork
=======
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
=======
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If DelRow = True Then
                ButtonXP5_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            BS.DataSource = myds.Tables("PTRANSACTION")
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            Count()
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
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
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ترحيل  الى القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click12 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة الصندزق و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click13 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click14 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "إلغاء المراجعة", Me.Text)
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
            Click12 = False
            Click13 = False
            Click14 = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        End If
    End Sub
<<<<<<< HEAD
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
=======
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        RecordCount()
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("PTRANSACTION").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.AutoEx()
        Me. AccountsEnquiry()
        Me.TEXTTotaln.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.DateMovementHistory.Value = Me.TextDateMovementHistory.Text
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.EditValue, 2)

        Me.FundBalance()
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
         AccountsEnquiry()
        If Me.TextLSet.Text.ToString <> "WD" Then
            Me.ButtonTransferofAccounts.Enabled = False
        Else
            Me.ButtonTransferofAccounts.Enabled = True
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockUpdate
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonSavingsCertificates.Enabled = True
        Me.ButtonAttachDocument.Enabled = LockAddRow
    End Sub

    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update PTRANSACTION SET  TBNK2 = @TBNK2, TBNK3 = @TBNK3, TBNK4 = @TBNK4, TBNK5 = @TBNK5, TBNK6 = @TBNK6, TBNK7 = @TBNK7, TBNK8 = @TBNK8, TBNK9 = @TBNK9, TBNK10 = @TBNK10, TBNK11 = @TBNK11, TBNK12 = @TBNK12, TBNK13 = @TBNK13, TBNK14 = @TBNK14, TBNK15 = @TBNK15, TBNK16 = @TBNK16, TBNK17 = @TBNK17, TBNK18 = @TBNK18, TBNK19 = @TBNK19, TBNK20 = @TBNK20, TBNK21 = @TBNK21, TBNK22 = @TBNK22, TBNK23 = @TBNK23, TBNK24 = @TBNK24, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE TBNK1 = @TBNK1", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update PTRANSACTION SET  TBNK2 = @TBNK2, TBNK3 = @TBNK3, TBNK4 = @TBNK4, TBNK5 = @TBNK5, TBNK6 = @TBNK6, TBNK7 = @TBNK7, TBNK8 = @TBNK8, TBNK9 = @TBNK9, TBNK10 = @TBNK10, TBNK11 = @TBNK11, TBNK12 = @TBNK12, TBNK13 = @TBNK13, TBNK14 = @TBNK14, TBNK15 = @TBNK15, TBNK16 = @TBNK16, TBNK17 = @TBNK17, TBNK18 = @TBNK18, TBNK19 = @TBNK19, TBNK20 = @TBNK20, TBNK21 = @TBNK21, TBNK22 = @TBNK22, TBNK23 = @TBNK23, TBNK24 = @TBNK24, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE TBNK1 = @TBNK1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@TBNK1", SqlDbType.BigInt).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@TBNK2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.EditValue
                .Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@TBNK4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@TBNK6", SqlDbType.NVarChar).Value = Me.ComboAccountNumber.Text
                .Parameters.Add("@TBNK7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.EditValue
                .Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                .Parameters.Add("@TBNK9", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@TBNK10", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@TBNK12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckArchivingDocumentWithScanner.Checked)
                .Parameters.Add("@TBNK13", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@TBNK14", SqlDbType.NVarChar).Value = ComboPaymentMethod1.Text
                .Parameters.Add("@TBNK15", SqlDbType.NVarChar).Value = TextFundValue.EditValue
                .Parameters.Add("@TBNK16", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@TBNK17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@TBNK19", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@TBNK20", SqlDbType.Date).Value = Me.CheckDate.Value.ToString
                .Parameters.Add("@TBNK21", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@TBNK22", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                .Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                .Parameters.Add("@TBNK24", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

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

                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub GETBANKNOWBALANCE()
        On Error Resume Next
        Dim n As Double
        Dim F As Double
        n = BS.Position
        BS.EndEdit()
        If BS.Position = 0 Then
            Me.TEXTPreviousBalance.EditValue = 0
        ElseIf BS.Position > 0 Then
            F = 0
            BS.Position = BS.Position - 1
            F = Val(TEXTCurrentBalance.EditValue)
            BS.Position = BS.Position + 1
            Me.TEXTPreviousBalance.EditValue = F
        End If
    End Sub
<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = 0
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = BS.Position - 1
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = BS.Position + 1
        RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
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
        If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
            MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
            Exit Sub
        End If
        Dim ch As Double
        Dim ch1 As Double
        ch = Me.TEXTDebit.EditValue
        ch1 = Me.TextFundBalance.Text
        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                ch = "0.00"
                ch1 = "0.00"
                'Dim x As Double = Val(Me.TEXTBOX2.Text) + Val(Me.TEXTBOX5.Text)
                'If Me.TEXTBOX8.Text = "الاسهم" And Val(x) > Val(BANSL) Then
                '    MessageBox.Show("لا يمكن ان تكون قيمة اسهم العضو اكبر من قيمة اسهم الجمعة المكتتبة:" & ControlChars.CrLf & _
                '                   "1) اسهم الجمعة المكتتبة = " & "(" & Val(BANSL) & ")" & " " & "دينار اردني" & ControlChars.CrLf & _
                '                   "2) يمكن ان تغير نوع الحساب ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
            Case "سحب"
                If ch1 < ch Then
                    MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                    Exit Sub
                End If
        End Select
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
        If Me.TextLSet.Text.ToString <> "WD" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن تعدبل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى من شاشة شهادات أدخار _ الودائع ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
<<<<<<< HEAD
        Me.SaveTab = New BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Click2 = True
        'Catch ex As Exception
        '    MsgBox(" خطاء", MsgBoxStyle.Information, "معلومات")
        'Finally

        'End Try

    End Sub
<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        BS.CancelEdit()
        RecordCount()
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
        TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
        If Me.TextLSet.Text.ToString <> "WD" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن حذف  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى من شاشة شهادات أدخار _ الودائع ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.TextMovementRestrictions.Text = "" Then
            MsgBox("لايوجد سجلات في القيود", 16, "تنبية") '1
        Else
            DELETEDATMOVESDATA()
            DELETEDATMOVESDATA1()
        End If
        If Me.TextFundMovementNumber.Text = "" Then
            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية") '2
        Else
            DELETEDATAempsolf()
        End If
        If Me.TextCheckMovementNumber.Text = "" Then
            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية") '3
        Else
            DELETEDATBANK()
        End If
        MYDELETERECORD("PTRANSACTION", "TBNK1", TEXTID, BS, True)
        Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text) '6
    End Sub
<<<<<<< HEAD
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Dim rpt As New rptPTRANSACTION
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
<<<<<<< HEAD
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
            MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.RadioButton1.Checked = True Then
            If Len(Me.ComboAccountNumber1.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل رقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboAccountNumber1.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim DataSetTab30 As New DataSet
            Dim str As New SqlCommand("SELECT * FROM PTRANSACTION  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND TBNK6 like '" & Me.ComboAccountNumber1.Text & "'", Consum)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            DataSetTab30.Clear()
            SqlDataAdapter1.Fill(DataSetTab30, "PTRANSACTION")
            rpt.SetDataSource(DataSetTab30)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton2.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim DataSetTab30 As New DataSet
            Dim str As New SqlCommand("SELECT * FROM PTRANSACTION  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            DataSetTab30.Clear()
            SqlDataAdapter1.Fill(DataSetTab30, "PTRANSACTION")
            rpt.SetDataSource(DataSetTab30)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton3.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim DataSetTab30 As New DataSet
            Dim str As New SqlCommand("SELECT * FROM PTRANSACTION  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND TBNK13 ='" & False & "'", Consum)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            DataSetTab30.Clear()
            SqlDataAdapter1.Fill(DataSetTab30, "PTRANSACTION")
            rpt.SetDataSource(DataSetTab30)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
            Consum.Close()
        End If
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
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.RecordCount()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
<<<<<<< HEAD
        Me.SaveTab = New BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Click13 = True
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        If Me.CheckLogReview.Checked = False Then
            MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
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
        Me.RecordCount()
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
<<<<<<< HEAD
        Me.SaveTab = New BackgroundWorker With {
=======
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Click14 = True
    End Sub
<<<<<<< HEAD
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BALANCEBUTTON.Click
=======
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ProgressBar1.Visible = True
        Me.PictureBox2.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        Click3 = True
        If Not Me.BackWorker3.IsBusy Then
            Me.BackWorker3.RunWorkerAsync()
        End If
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
<<<<<<< HEAD
    Private Sub BackWorker3_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackWorker3.DoWork
=======
    Private Sub BackWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker3.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
                Me.InternalAuditorBalance()
                Me.UPDATERECORD()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDoWorkBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
=======
    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ProgressBar1.Value = e.ProgressPercentage
        Dim percent As Integer = CInt(CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum) * 100)
        Using gr As Graphics = Me.ProgressBar1.CreateGraphics()
            gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        End Using

    End Sub
<<<<<<< HEAD
    Private Sub BackWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackWorker3.RunWorkerCompleted
=======
    Private Sub BackWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker3.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            Me.SaveTab = New BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = 0
            ModuleGeneral.Click3 = True
        End If
    End Sub
    Private Sub InternalAuditorBalance()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION  WHERE (PTRANSACTION.TBNK6)='" & Me.ComboAccountNumber.Text.Trim & "' AND (PTRANSACTION.TBNK8)='" & Me.ComboAccountType.Text.Trim & "'AND PTRANSACTION.TBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION  WHERE (PTRANSACTION.TBNK6)='" & Me.ComboAccountNumber.Text.Trim & "' AND (PTRANSACTION.TBNK8)='" & Me.ComboAccountType.Text.Trim & "'AND PTRANSACTION.TBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp1.Fill(ds, "PTRANSACTION")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.EditValue = Format(Val(ds.Tables(0).Rows(0).Item(1)) - Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            ElseIf ds.Tables(0).Rows.Count = 0 Then
                Me.TEXTPreviousBalance.EditValue = 0
            End If
            Adp1.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            Me.TEXTPreviousBalance.EditValue = 0
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboAccountNumber1.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboAccountNumber1.Enabled = False
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboAccountNumber1.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboAccountNumber1.Enabled = False
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX6_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboAccountNumber.SelectedIndexChanged
=======
    Private Sub TEXTBOX6_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboAccountNumber.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SEARCHDATAITEMS10()
        InternalAuditorBalance()

    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX6_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboAccountNumber.SelectedValueChanged
=======
    Private Sub TEXTBOX6_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboAccountNumber.SelectedValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SEARCHDATAITEMS10()
        InternalAuditorBalance()

    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX16_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TextValueOfCheck.DoubleClick
        On Error Resume Next
        Me.TextValueOfCheck.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged1(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTPreviousBalance.EditValueChanged, TEXTCurrentBalance.EditValueChanged, ComboAccountNumber.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
=======
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX16_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextValueOfCheck.DoubleClick
        On Error Resume Next
        Me.TextValueOfCheck.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.EditValueChanged, TEXTCurrentBalance.EditValueChanged, ComboAccountNumber.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        InternalAuditorBalance()
        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                Me.TextFundValue.EditValue = Format(Val(Me.TEXTCredit.EditValue), "0.000")
                Me.TEXTCurrentBalance.EditValue = Format(Val(Me.TEXTPreviousBalance.EditValue) + Val(Me.TextFundValue.EditValue), "0.000")
            Case "سحب"
                Select Case Me.ComboPaymentMethod1.Text
                    Case "نقدا"
                        Me.TextFundValue.EditValue = Format(Val(Me.TEXTDebit.EditValue), "0.000")
                        Me.TEXTCurrentBalance.EditValue = Format(Val(Me.TEXTPreviousBalance.EditValue) - Val(Me.TextFundValue.EditValue), "0.000")
                    Case "شيك"
                        Me.TextValueOfCheck.EditValue = Format(Val(Me.TEXTDebit.EditValue), "0.000")
                        Me.TEXTCurrentBalance.EditValue = Format(Val(Me.TEXTPreviousBalance.EditValue) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                    Case "نقدا_شيك"
                        Me.TEXTCurrentBalance.EditValue = Format(Val(Me.TEXTPreviousBalance.EditValue) - Val(Me.TEXTDebit.EditValue), "0.000")
                End Select
        End Select

        Me.TEXTTotal.Text = TEXTCurrentBalance.EditValue
        Me.TEXTTotaln.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateFrom.KeyUp
=======
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateFrom.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateTO.Focus()
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX13_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateTO.KeyDown
=======
    Private Sub TEXTBOX13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTO.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX13_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateTO.KeyUp
=======
    Private Sub TEXTBOX13_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTO.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.PRINTBUTTON_Click(sender, e)
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub ButtonCertifacate_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSavingsCertificates.Click
        On Error Resume Next
        Me.Close()
        Dim ds1 As New DataSet
        Dim SqlDataAdapter2 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f1 As New FrmDeposits
        ds1.EnforceConstraints = False
        Dim str As New SqlCommand("SELECT TBNK1 FROM Deposits WHERE   CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY TBNK1", Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str)
        Dim builder68 As New SqlCommandBuilder(SqlDataAdapter2)
=======
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub ButtonCertifacate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSavingsCertificates.Click
        On Error Resume Next
        Me.Close()
        Dim ds1 As New DataSet
        Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f1 As New FrmDeposits
        ds1.EnforceConstraints = False
        Dim str As New SqlCommand("SELECT TBNK1 FROM Deposits WHERE   CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY TBNK1", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
        Dim builder68 As New SqlClient.SqlCommandBuilder(SqlDataAdapter2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        Consum.Open()
        SqlDataAdapter2.Fill(ds1, "Deposits")
        f1.BS.DataMember = "Deposits"
        f1.BS.DataSource = ds1
        Dim index As Integer
        index = f1.BS.Find("TBNK18", TextMovementSymbol.EditValue)
        f1.TB1 = Me.TextMovementSymbol.EditValue
        f1.Show()
        f1.Load_Click(sender, e)
        f1.BS.Position = index
        SqlDataAdapter2.Dispose()
        Consum.Close()

    End Sub
<<<<<<< HEAD
    Private Sub TextGoTo_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextGoTo.TextChanged
=======
    Private Sub TextGoTo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextGoTo.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.TextGoTo.TextLength > 0 Then
                Dim index As Integer
                index = BS.Find("TBNK1", Me.TextGoTo.Text)
                BS.Position = index
                RecordCount()
            Else
                BS.Position = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEnquiry.Click
=======
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnquiry.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim F As New FrmAdvancedSearchMoviesTransaction
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub



<<<<<<< HEAD
    Private Sub ComboBox5_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
=======
    Private Sub ComboBox5_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Consum.Open()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.account_noF = ds2.Tables(0).Rows(0).Item(0)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(2)
            Me.account_nameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            account_noF = ""
            ACCF = ""
            account_nameF = ""
        End If
        AutoEx()
        Consum.Close()
    End Sub


    Private Sub SEARCHDATAITEMS10()
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK20, TBNK21 FROM Deposits WHERE TBNK6 = '" & Me.ComboAccountNumber.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK20, TBNK21 FROM Deposits WHERE TBNK6 = '" & Me.ComboAccountNumber.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        ds2.Clear()
        Consum.Open()
        Adp1.Fill(ds2, "Deposits")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextMembersName.Text = ds2.Tables(0).Rows(0).Item(0)
            Me.TextMembersCode.EditValue = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.TextMembersName.Text = ""
            Me.TextMembersCode.EditValue = ""
        End If
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
        'Me.TextBox45.Text = Format(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N), "0.000")
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.Text & " " & ":" & " " & Me.TextMovementSymbol.EditValue & " " & "|" & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " " & "|" & " "
        ExResult += "لرقم حساب" & " " & ":" & " " & Me.ComboAccountNumber.Text & vbNewLine
        LabelAutoEx.Text = ExResult
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub TransforAccounts()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            FundAccount_Name = Nothing
            ChecksAccount_Name = Nothing
            nem = "حركات السحب والايداعات "
            nem1 = "استلام نقدي من حساب" & " " & Me.ComboAccountType.Text
            nem2 = "صرف شيك رقم من حساب" & " " & Me.ComboAccountType.Text & "_" & Me.TextCheckNumber.Text
            PMO2 = 1
            ''Me.ComboCB1_SelectedIndexChanged(sender, e)

            NewMethod()

            Dim DocumentTapy As String
            If OBCHK1 = False Then
                DocumentTapy = "قبض"
            Else
                DocumentTapy = "قيد"
            End If
            SEARCHDATA.MAXIDMOVES()
            TransferToAccounts_Check = True

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTCurrentBalance.EditValue, TEXTCurrentBalance.EditValue, T3, DocumentTapy, "WD", TextMovementSymbol.EditValue, False)
            If OBCHK1 = True Then
                If Me.Deposit = True Then  ' ايداع
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTCredit.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                ElseIf Me.Deposit = False Then ' سحب
                    nem1 = "صرف نقدي من حساب" & " " & Me.ComboAccountType.Text
                    DetailsAccountingEntries(PMO2, TextCreditAccount.Text, DebitAccount_No, TEXTDebit.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ComboDebitAccount.Text, CredAccount_NO, 0, TEXTDebit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                End If
            Else
                If Me.ComboConstraintType.Text = "ايداع" Then
                    Documenttype = "قبض"
                Else
                    Documenttype = "صرف"
                End If
                If Me.Deposit = True Then  ' ايداع
                    If Me.ComboPaymentMethod1.Text.Trim = "شيك" Then
                        MsgBox("عفوا .. لا يمكن ترحيل الحساب  في حالة طريقة الدفع(شيك) يجب تغير طريقة الدفع الى نقدا ", 16, "تنبيه")
                        Exit Sub
                    End If
                    If Me.ComboPaymentMethod1.Text.Trim = "نقدا_شيك" Then
                        MsgBox("عفوا .. لا يمكن ترحيل الحساب  في حالة طريقة الدفع(نقدا_شيك) يجب تغير طريقة الدفع الى نقدا", 16, "تنبيه")
                        Exit Sub
                    End If
                    If Me.ComboPaymentMethod1.Text.Trim = "نقدا" Then
                        DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, FundAccount_No, TEXTCredit.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                                                                      nem, False, TEXTID.EditValue & "0",
                                                                      False, True, ComboCB1.Text, ModuleGeneral.CB2)
                    End If
                ElseIf Me.Deposit = False Then ' سحب
                    nem1 = "صرف نقدي من حساب" & " " & Me.ComboAccountType.Text
                    If Me.ComboPaymentMethod1.Text.Trim = "نقدا" Then
                        DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextFundValue.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, FundAccount_No, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype, TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                      nem1, False, TEXTID.EditValue & "0",
                                                                      False, True, ComboCB1.Text, ModuleGeneral.CB2)

                    ElseIf Me.ComboPaymentMethod1.Text.Trim = "شيك" Then
                        DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextValueOfCheck.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                       TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                       TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                    ElseIf Me.ComboPaymentMethod1.Text.Trim = "نقدا_شيك" Then
                        DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTDebit.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2, FundAccount_No, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                        DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype, TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                      nem, False, TEXTID.EditValue & "0",
                                                                      False, True, ComboCB1.Text, ModuleGeneral.CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                       TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4.ToString, True,
                       TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)
                    End If
                End If
            End If
        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub NewMethod()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboAccountType.Text, 1)
        AccountNoAktevd = ID_Nam

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)

        If Me.Deposit = True Then  ' ايداع

            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", AccountNoAktevd, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", AccountNoAktevd, 1)
            CredAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam


        Else ' سحب
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", AccountNoAktevd, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", AccountNoAktevd, 1)
            DebitAccount_Cod = ID_Nam



            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam
        End If
    End Sub



    Private Sub  AccountsEnquiry()
        On Error Resume Next
        NewMethod()
        If Me.Deposit = True Then  ' ايداع
            ComboDebitAccount.Text = FundAccount_Name
            NUpComboDebitAccount.Value = CodAccount

            TextCreditAccount.Text = CredAccount_Name
            NUpCreditAccount.Value = CredAccount_Cod
        Else
            ComboDebitAccount.Text = DebitAccount_Name
            NUpComboDebitAccount.Value = DebitAccount_Cod
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.Enabled = False
                    Me.ComboCB1.Enabled = True
                    Me.LabelCB1.Enabled = True
                    Me.GroupCHKS.Enabled = False
                    Me.GroupCHKS1.Enabled = False
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                    TextFundValue.EditValue = TEXTDebit.EditValue
                    TextValueOfCheck.EditValue = 0
                    TextCreditAccount.Text = FundAccount_Name
                    NUpCreditAccount.Value = CodAccount
                Case "شيك"
                    Me.TextFundValue.Enabled = False
                    Me.TextValueOfCheck.Enabled = True
                    Me.ComboCB1.Enabled = False
                    Me.LabelCB1.Enabled = False
                    Me.GroupCHKS.Enabled = True
                    Me.GroupCHKS1.Enabled = True
                    TextFundValue.EditValue = 0
                    TextValueOfCheck.EditValue = TEXTDebit.EditValue
                    TextCreditAccount.Text = ChecksAccount_Name
                    NUpCreditAccount.Value = ChecksAccount_Cod
                Case "نقدا_شيك"
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.Enabled = True
                    Me.ComboCB1.Enabled = True
                    Me.LabelCB1.Enabled = True
                    Me.GroupCHKS.Enabled = True
                    Me.GroupCHKS1.Enabled = True
                    TextFundValue.EditValue = Val(TEXTDebit.EditValue) - Val(TextValueOfCheck.EditValue)
                    TextValueOfCheck.EditValue = Val(TEXTDebit.EditValue) - Val(TextFundValue.EditValue)
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                    TextCreditAccount.Text = ChecksAccount_Name
                    NUpCreditAccount.Value = ChecksAccount_Cod
            End Select


        End If

    End Sub

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                OptionsTransforAccountsTo("نقدا", ComboDebitAccount.Text, TextCreditAccount.Text)
                PanelAccount.Enabled = True
            Else
                Check_OptionsTransforAccounts.Checked = False
                PanelAccount.Enabled = False
            End If
        Else
            PanelAccount.Enabled = False
        End If
    End Sub

    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        If Me.Deposit = True Then  ' ايداع
            TextFundValue.EditValue = Val(TEXTCredit.EditValue)
        Else
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    TextFundValue.EditValue = Val(TEXTDebit.EditValue)
                    TextValueOfCheck.EditValue = 0
                Case "شيك"
                    TextFundValue.EditValue = 0
                    TextValueOfCheck.EditValue = Val(TEXTDebit.EditValue)
                Case "نقدا_شيك"
                    TextFundValue.EditValue = Val(TEXTDebit.EditValue) - Val(TextValueOfCheck.EditValue)
                    TextValueOfCheck.EditValue = Val(TEXTDebit.EditValue) - Val(TextFundValue.EditValue)
            End Select
        End If
    End Sub



    Private Sub TEXTBOXCHK()
        On Error Resume Next
        Select Case Me.ComboPaymentMethod1.Text
            Case "شيك"
                If Me.ComboCheckDrawerName.Text = "" Then
                    MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                    Me.ComboCheckDrawerName.Focus()
                End If
                If Me.TextCheckNumber.Text = "" Then
                    MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                    Me.TextCheckNumber.Focus()
                End If
                If Me.CheckDate.Value = "" Then
                    MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                    Me.CheckDate.Focus()
                End If
            Case "نقدا_شيك"
                If Me.ComboCheckDrawerName.Text = "" Then
                    MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                    Me.ComboCheckDrawerName.Focus()
                End If
                If Me.TextCheckNumber.Text = "" Then
                    MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                    Me.TextCheckNumber.Focus()
                End If
                If Me.CheckDate.Value = "" Then
                    MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                    Me.CheckDate.Focus()
                End If
        End Select
    End Sub

    Private Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod1.Text = "نقدا_شيك" Then
                Connection.ACONET1.Add("الصندوق")
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
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

<<<<<<< HEAD
    Private Sub ButtonTRANSFER_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
=======
    Private Sub ButtonTRANSFER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
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
            Me.TextLSet.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
            If Me.TextLSet.Text.ToString <> "WD" Then
                Dim resault1 As Integer
                resault1 = MessageBox.Show("لايمكن ترحيل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى من شاشة شهادات أدخار _ الودائع ", "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
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
            'Me.ComboConstraintType_SelectedIndexChanged(sender, e)

            If Me.ComboConstraintType.Text = "ايداع" Then
                Me.Documenttype = "قبض"
                'Dim x As Double = Val(Me.TEXTBOX2.Text) + Val(Me.TEXTBOX5.Text)
                'If Me.TEXTBOX8.Text = "الاسهم" And Val(x) > Val(BANSL) Then
                '    MessageBox.Show("لا يمكن ان تكون قيمة اسهم العضو اكبر من قيمة اسهم الجمعة المكتتبة:" & ControlChars.CrLf & _
                '                   "1) اسهم الجمعة المكتتبة = " & "(" & Val(BANSL) & ")" & " " & "دينار اردني" & ControlChars.CrLf & _
                '                   "2) يمكن ان تغير نوع الحساب ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                '    Exit Sub
                'End If
            Else
                Me.Documenttype = "صرف"
            End If

            Me.Button1_Click(sender, e)
            Call AccountingprocedureA()
            Static P As Integer
            If OBCHK1 = True Then
                If Me.CheckTransferAccounts.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts.Checked = True
                        TransforAccounts()
                        Click4 = True
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        Me.SEARCHDATAITEMS10()
                        TransforAccounts()
                        Click5 = True
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferAccounts.Checked = False
                            Click6 = True
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Me.ComboPaymentMethod1.Text = "نقدا" Then
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            Click4 = True
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            Me.SEARCHDATAITEMS10()
                            TransforAccounts()
                            Click5 = True
                            'AccountingprocedureA()
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferAccounts.Checked = False
                                Click6 = True
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '======================================================================================================
                ElseIf Me.ComboPaymentMethod1.Text = "شيك" Then
                    TEXTBOXCHK()
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            Click7 = True
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            Me.SEARCHDATAITEMS10()
                            TransforAccounts()
                            Click8 = True
                            'AccountingprocedureA()
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATBANK()
                                Me.CheckTransferAccounts.Checked = False
                                Click9 = True
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod1.Text = "نقدا_شيك" Then
                    TEXTBOXCHK()
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            Click10 = True
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            Me.SEARCHDATAITEMS10()
                            TransforAccounts()
                            Click11 = True
                            'AccountingprocedureA()
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.CheckTransferAccounts.Checked = False
                                Click12 = True
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            P = Me.BS.Position
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod1.SelectedIndexChanged
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod1.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
         AccountsEnquiry()
    End Sub

    Private Sub DELETEDATBANK()
        Try
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA1()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboConstraintType.SelectedIndexChanged
=======
    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Select Case Me.ComboConstraintType.Text
            Case "ايداع"
                '188; 15
                Me.Label11.Text = "رقم مستند (قبض)"
                Me.Label11.Location = New Point(229, 101)
                Me.TEXTDebit.Enabled = False
                Me.TEXTCredit.Enabled = True
                Me.Deposit = True
                ComboPaymentMethod1.Text = "نقدا"
                ComboPaymentMethod1.Enabled = False
            Case "سحب"
                ComboPaymentMethod1.Enabled = True
                Me.Label11.Text = "رقم مستند (صرف)"
                Me.Label11.Location = New Point(226, 101)
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = False
                Me.Deposit = False
        End Select
         AccountsEnquiry()
    End Sub

    Private Sub ComboAccountType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAccountType.SelectedIndexChanged
         AccountsEnquiry()
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicAccountLevel.Click
=======
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
<<<<<<< HEAD
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List1.MouseDoubleClick
=======
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List1.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        TextCreditAccount.Text = List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
<<<<<<< HEAD
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
=======
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
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
<<<<<<< HEAD
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton7.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton6.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton5.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton4.CheckedChanged
=======
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            Me.TextCheckDrawerCode.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        If RadioButton7.Checked = True Then
            Dim Adp As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            On Error Resume Next
            Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        If RadioButton7.Checked = True Then
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            On Error Resume Next
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
        ElseIf RadioButton6.Checked = True Then
<<<<<<< HEAD
            Dim Adp1 As SqlDataAdapter
            On Error Resume Next
            Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlDataAdapter(strsql)
=======
            Dim Adp1 As SqlClient.SqlDataAdapter
            On Error Resume Next
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
        ElseIf RadioButton5.Checked = True Then
<<<<<<< HEAD
            Dim Adp2 As SqlDataAdapter
            On Error Resume Next
            Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds2 As New DataSet
            Adp2 = New SqlDataAdapter(strsq2)
=======
            Dim Adp2 As SqlClient.SqlDataAdapter
            On Error Resume Next
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
    End Sub
<<<<<<< HEAD
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
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
            Me.RefreshTab = New BackgroundWorker With {
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = Conversion.Val(SEARCHDATA.MOV1C)
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)


        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
        If Strings.LSet(Me.TextMovementSymbol.EditValue, 2) = "SD" Then
            SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TEXTDocumentNumber.Text)
            Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B
        Else
            SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
            Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        End If
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
    End Sub
<<<<<<< HEAD
    Private Sub FrmTransaction_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
=======
    Private Sub FrmTransaction_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
            Me.Dispose()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
            If BS.Count = 0 Then
                Beep()
                Return
            End If
            If Not LockAddRow Then
                MessageBox.Show("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            GetAutoNumberMyDOCUMENTSFL(TextMovementSymbol.EditValue)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim documentForm As New FrmJPG0
            documentForm.Show()
            documentForm.ADDBUTTON.Enabled = False
            documentForm.SAVEBUTTON.Enabled = True
            documentForm.ButScan.Enabled = True
            documentForm.ButSaveFile.Enabled = False
            documentForm.ButLogq.Enabled = True
            documentForm.ButEditImage.Enabled = False
            documentForm.BS.EndEdit()
            documentForm.BS.AddNew()
            documentForm.MAXRECORD()
            documentForm.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            documentForm.TextLO.Text = Me.TextMovementSymbol.EditValue
            documentForm.TEXTFileNo.Text = documentId
            documentForm.TEXTFileSubject.Text = "مستندات الاعضاء"
            documentForm.TextFileDescription.Text = "ارفاق مستندات الاعضاء"
            documentForm.PictureBox1.Image = Nothing
            documentForm.TEXTBOX1.Enabled = False
            documentForm.TextLO.Enabled = False
            documentForm.TEXTFileNo.Enabled = False

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
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
            f.TEXTFileSubject.Text = "مستندات الاعضاء"
            f.TextFileDescription.Text = "ارفاق مستندات الاعضاء"
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
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
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
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
         AccountsEnquiry()
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