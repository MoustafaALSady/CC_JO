Option Explicit Off

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmJO
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker

    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim nem As String
    Dim T, F As Boolean
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Dim CHK As Boolean = False

    Private Sub FrmJO_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmJO_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
                        Me.ButtonXP2_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonTransferToCashMovements_Click(sender, e)
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
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonUpdateA_Click(sender, e)
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
    Private Sub FrmJO_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
        Me.TabPage1.Show()
    End Sub
    Private Sub FrmJO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.ButtonTransferToCashMovements.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False

        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        Me.CHK = False
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        ConnectDataBase.RunWorkerAsync()
        T = True
        F = False
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
    Private Sub TEXTBOX6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboBN2, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & Me.BS.Count
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
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
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("BANKJO").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmounJOBALANCE()
        Me.AutoEx()
        Me.TEXTTEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.DateMovementHistory.Value = Me.TextDateMovementHistory.Text
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        If Me.TextLSet.Text.ToString <> "BA" Then
            Me.ButtonTransferofAccounts.Enabled = False
        Else
            Me.ButtonTransferofAccounts.Enabled = True
        End If
        If Me.TEXTDebit.EditValue > 0 Then
            Me.ButtonTransferToCashMovements.Enabled = True
        Else
            Me.ButtonTransferToCashMovements.Enabled = False
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.ButtonUpdateA.Enabled = True
        Me.ButtonEnquiry.Enabled = LockPrint
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonTransferToCashMovements.Enabled = TransferofAccounts
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonAttachDocument.Enabled = LockAddRow
    End Sub

    Public Sub DanLOd()
        On Error Resume Next
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()
        T = True
        F = False
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())

            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = String.Concat(New String() {"SELECT EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM BANKJO  WHERE  CUser='", ModuleGeneral.CUser, "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK1 ='", Strings.Trim(Me.TB1), "' or EBNK6 ='", Strings.Trim(Me.TB2), "' or EBNK10 ='", Strings.Trim(Me.TB3), "'ORDER BY EBNK1"})
            }
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "BANKJO")
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
            FILLCOMBOBOX1("BankNames", "BN1", "CUser", CUser, Me.ComboBN2)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("BANKJO")
            RowCount = BS.Count
            TEXTID.DataBindings.Add("text", BS, "EBNK1", True, 1, "")
            TEXTPreviousBalance.DataBindings.Add("text", BS, "EBNK2", True, 1, "")
            TextDateMovementHistory.DataBindings.Add("text", BS, "EBNK3", True, 1, "")
            TEXTDebit.DataBindings.Add("text", BS, "EBNK4", True, 1, "")
            TEXTCredit.DataBindings.Add("text", BS, "EBNK5", True, 1, "")
            TEXTDocumentNumber.DataBindings.Add("text", BS, "EBNK6", True, 1, "")
            TEXTCurrentBalance.DataBindings.Add("text", BS, "EBNK7", True, 1, "")
            ComboConstraintType.DataBindings.Add("text", BS, "EBNK8", True, 1, "")
            TEXTStatement.DataBindings.Add("text", BS, "EBNK9", True, 1, "")
            ComboBN2.DataBindings.Add("text", BS, "EBNK10", True, 1, "")
            TextBN3.DataBindings.Add("text", BS, "EBNK11", True, 1, "")
            CheckTransferToClients.DataBindings.Add("Checked", BS, "EBNK12", True, 1, "")
            TextMovementSymbol.DataBindings.Add("text", BS, "EBNK13", True, 1, "")
            CheckLogReview.DataBindings.Add("Checked", BS, "EBNK14", True, 1, "")
            CheckTransferAccounts.DataBindings.Add("Checked", BS, "EBNK15", True, 1, "")
            CheckTransferFund.DataBindings.Add("Checked", BS, "EBNK16", True, 1, "")
            TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
            TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
            TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, 1, "")
            TextreviewTime.DataBindings.Add("text", BS, "ne1", True, 1, "")

            Auditor("BANKJO", "USERNAME", "EBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("BANKJO", "EBNK8", "CUser", CUser, Me.ComboConstraintType)
            FILLCOMBOBOX1("BANKJO", "EBNK9", "CUser", CUser, Me.TEXTStatement)

            FILLCOMBOBOX1("BANKJO", "EBNK10", "CUser", CUser, Me.ComboBN2_1)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpCreditAccount.Value, Me.List1)
            TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            SumAmounJOBALANCE()
            Call MangUsers()
            RecordCount()
            FundBalance()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.BUTTONCANCEL.Enabled = True
        If Me.TextLSet.Text.ToString <> "BA" Then
            ButtonTransferofAccounts.Enabled = False
        Else
            ButtonTransferofAccounts.Enabled = True
        End If
        Label5.Visible = False
    End Sub
    Private Sub DISPLAYRECORD()
        Try
            With Me
                .TEXTID.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK1").ToString
                .TEXTPreviousBalance.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK2").ToString
                .TextDateMovementHistory.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK3").ToString
                .TEXTDebit.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK4").ToString
                .TEXTCredit.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK5").ToString
                .TEXTDocumentNumber.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK6").ToString
                .TEXTCurrentBalance.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK7").ToString
                .ComboConstraintType.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK8").ToString
                .TEXTStatement.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK9").ToString
                .ComboBN2.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK10").ToString
                .TextBN3.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK11").ToString
                .CheckTransferToClients.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK12").ToString
                .TextMovementSymbol.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK13").ToString
                .CheckLogReview.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK14").ToString
                .CheckTransferAccounts.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK15").ToString
                .CheckTransferFund.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("EBNK16").ToString
                .TEXTUserName.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("USERNAME").ToString
                .TEXTReferenceName.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("Auditor").ToString
                .TextDefinitionDirectorate.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("COUser").ToString
                .TEXTAddDate.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("da").ToString
                .TextTimeAdd.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("ne").ToString
                .TEXTReviewDate.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("da1").ToString
                .TextreviewTime.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("ne1").ToString

                Auditor("BANKJO", "USERNAME", "EBNK1", Me.TEXTID.EditValue, "")
                Logentry = Uses
                FILLCOMBOBOX1("BANKJO", "EBNK8", "CUser", CUser, Me.ComboConstraintType)
                FILLCOMBOBOX1("BANKJO", "EBNK9", "CUser", CUser, Me.TEXTStatement)
                FILLCOMBOBOX1("BankNames", "BN1", "CUser", CUser, Me.ComboBN2)
                FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
                FILLCOMBOBOX1("BANKJO", "EBNK10", "CUser", CUser, Me.ComboBN2_1)
                FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpCreditAccount.Value, Me.List1)
                TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
                SumAmounJOBALANCE()
                Call MangUsers()
                FundBalance()
            End With
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Me.BUTTONCANCEL.Enabled = True
        If Me.TextLSet.Text.ToString <> "BA" Then
            ButtonTransferofAccounts.Enabled = False
        Else
            ButtonTransferofAccounts.Enabled = True
        End If
        Label5.Visible = False
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())

            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = "SELECT EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM BANKJO WHERE   CUser='" & ModuleGeneral.CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY EBNK1"
            }
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
            myds = New DataSet
            Consum.Open()
            SqlDataAdapter1.Fill(myds, "BANKJO")
            myds.RejectChanges()
            Consum.Close()
            Auditor("BANKJO", "USERNAME", "EBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
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
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.Label5.Visible = True
                'Me.Label5.ForeColor = Color.Yellow
                Me.Label5.Text = "..  „ «·« ’«· »«·«‰ —‰  .. Ì „ «·«‰  Õ„Ì· ”Ã·«  «·ﬁ«⁄œ…"
            Else
                'Me.Label5.ForeColor = Color.Red
                Me.Label5.Text = "«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—"
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("BankNames", "BN1", "CUser", CUser, Me.ComboBN2)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            BS.DataSource = myds.Tables("BANKJO")
            RowCount = BS.Count
            TEXTID.DataBindings.Add("text", BS, "EBNK1", True, 1, "")
            TEXTPreviousBalance.DataBindings.Add("text", BS, "EBNK2", True, 1, "")
            TextDateMovementHistory.DataBindings.Add("text", BS, "EBNK3", True, 1, "")
            TEXTDebit.DataBindings.Add("text", BS, "EBNK4", True, 1, "")
            TEXTCredit.DataBindings.Add("text", BS, "EBNK5", True, 1, "")
            TEXTDocumentNumber.DataBindings.Add("text", BS, "EBNK6", True, 1, "")
            TEXTCurrentBalance.DataBindings.Add("text", BS, "EBNK7", True, 1, "")
            ComboConstraintType.DataBindings.Add("text", BS, "EBNK8", True, 1, "")
            TEXTStatement.DataBindings.Add("text", BS, "EBNK9", True, 1, "")
            ComboBN2.DataBindings.Add("text", BS, "EBNK10", True, 1, "")
            TextBN3.DataBindings.Add("text", BS, "EBNK11", True, 1, "")
            CheckTransferToClients.DataBindings.Add("Checked", BS, "EBNK12", True, 1, "")
            TextMovementSymbol.DataBindings.Add("text", BS, "EBNK13", True, 1, "")
            CheckLogReview.DataBindings.Add("Checked", BS, "EBNK14", True, 1, "")
            CheckTransferAccounts.DataBindings.Add("Checked", BS, "EBNK15", True, 1, "")
            CheckTransferFund.DataBindings.Add("Checked", BS, "EBNK16", True, 1, "")
            TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
            TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
            TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, 1, "")
            TextreviewTime.DataBindings.Add("text", BS, "ne1", True, 1, "")

            Auditor("BANKJO", "USERNAME", "EBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("BANKJO", "EBNK8", "CUser", CUser, Me.ComboConstraintType)
            FILLCOMBOBOX1("BANKJO", "EBNK9", "CUser", CUser, Me.TEXTStatement)
            FILLCOMBOBOX1("BANKJO", "EBNK10", "CUser", CUser, Me.ComboBN2_1)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpCreditAccount.Value, Me.List1)
            TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            SumAmounJOBALANCE()
            Call MangUsers()
            RecordCount()
            FundBalance()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Me.BUTTONCANCEL.Enabled = True
        If Me.TextLSet.Text.ToString <> "BA" Then
            Me.ButtonTransferofAccounts.Enabled = False
        Else
            Me.ButtonTransferofAccounts.Enabled = True
        End If
        Me.Label5.Visible = False
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update BANKJO SET  EBNK2 = @EBNK2, EBNK3 = @EBNK3, EBNK4 = @EBNK4, EBNK5 = @EBNK5, EBNK6 = @EBNK6, EBNK7 = @EBNK7, EBNK8 = @EBNK8, EBNK9 = @EBNK9, EBNK10 = @EBNK10, EBNK11 = @EBNK11, EBNK12 = @EBNK12, EBNK13 = @EBNK13, EBNK14 = @EBNK14, EBNK15 = @EBNK15, EBNK16 = @EBNK16, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE EBNK1 = @EBNK1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EBNK1", SqlDbType.Int).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@EBNK2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@EBNK3", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@EBNK4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@EBNK5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@EBNK6", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@EBNK7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@EBNK8", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@EBNK9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@EBNK10", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@EBNK11", SqlDbType.NVarChar).Value = Me.TextBN3.Text
                .Parameters.Add("@EBNK12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToClients.Checked)
                .Parameters.Add("@EBNK13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@EBNK14", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@EBNK15", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@EBNK16", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferFund.Checked)
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
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try

1:          myds = New DataSet
            SqlDataAdapter1.Fill(myds, "BANKJO")
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
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("BANKJO")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Count()
            If DelRow = False Then
                If Me.BS.Count < RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - Me.BS.Count, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
                ElseIf Me.BS.Count > RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - RowCount, 48 + 524288, " ÕœÌÀ «·”Ã·« ")
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
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.ButtonUpdateA_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("BANKJO")
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & BS.Count - RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ›Ÿ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "«·«—’œ…", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Õ—ﬂ… «·Ï «·Õ”«»« ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ· «·Õ—ﬂ… «·Ï «·Õ”«»« ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· «·Õ—ﬂ… «·Ï «·Õ”«»« ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " —ÕÌ· «·Õ—ﬂ… «·Ï «·’‰œÊﬁ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  —ÕÌ· «·Õ—ﬂ… «·Ï «·’‰œÊﬁ ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  —ÕÌ· «·Õ—ﬂ… «·Ï «·’‰œÊﬁ ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "«·„—«Ã⁄", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "≈·€«¡ «·„—«Ã⁄…", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
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
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
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
        End If
    End Sub
    Private Sub GETBANKNOWBALANCE()
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
        End If
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
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
            MsgBox("⁄›Ê« .. «·”‰… «·„Õ«”»Ì… €Ì— ’ÕÌÕ… ›·« Ì„ﬂ‰ «·„ﬁ«—‰…", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰  ⁄œ»·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ «· ⁄œÌ· „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
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
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Click2 = True
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()
        RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ «· ⁄œÌ· „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        Else
            Dim resault As Integer
            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ Õ—ﬂ… «·»‰ﬂ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                MYDELETERECORD("BANKJO", "EBNK1", TEXTID, BS, True)
                Insert_Actions(Me.TEXTID.EditValue, "Õ–›", Me.Text)
            Else
                Exit Sub
            End If
        End If
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim rpt As New rptjo
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
            MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.RadioButton1.Checked = True Then
            If Len(Me.ComboBN2_1.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·Õ”«»  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboBN2_1.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM BANKJO   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND  " & "EBNK10 = '" & Me.ComboBN2.Text & "'", Consum)
            Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "BANKJO")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "Œ·«· «·› —… „‰" & " " & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " " & " «·Ï " & " " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton2.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM BANKJO   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "BANKJO")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "Œ·«· «·› —… „‰" & " " & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " " & " «·Ï " & " " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton3.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM BANKJO   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND  " & "EBNK14 ='" & False & "'", Consum)
            Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "BANKJO")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "Œ·«· «·› —… „‰" & " " & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " " & " «·Ï " & " " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
            Consum.Close()
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
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
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ·«Ì„ﬂ‰ „—«Ã⁄… «·”Ã·«  ﬁ»· «· —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
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
        Click10 = True
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        If Me.CheckLogReview.Checked = False Then
            MsgBox("⁄›Ê« .. Â–« «·”Ã· €Ì— „—«Ã⁄ ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTReferenceName.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.RecordCount()
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
        Click11 = True
    End Sub
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
        'Dim I As Integer
        'On Error Resume Next
        'If TestNet = False Then
        '    MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
        '    Exit Sub
        'End If
        'If Me.BS.Count = 0 Then Beep() : Exit Sub
        'If LockUpdate = False Then
        '    MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·«—’œ… „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
        '    Exit Sub
        'End If
        'On Error Resume Next
        'For I = 0 To Me.BS.Count + 1
        '    Me.BS.Position = I
        '    Me.ProgressBar1.Visible = True
        '    Me.ProgressBar1.Minimum = 1
        '    Me.ProgressBar1.Maximum = Me.BS.Count - 1
        '    Me.ProgressBar1.Value = I
        '    Me.TEXTBOX8_SelectedIndexChanged(sender, e)
        '    'Me.GETBANKNOWBALANCE()
        '    InternalAuditorBalance()
        '    Me.PictureBox2.Visible = True
        '    Me.UPDATERECORD()
        '    Dim percent As Integer = CInt((CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum)) * 100)
        '    Using gr As Graphics = Me.ProgressBar1.CreateGraphics()
        '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        '    End Using
        '    Me.Cursor = Cursors.WaitCursor
        'Next
        'Me.BS.EndEdit()
        'Me.RowCount = Me.BS.Count
        'Me.SaveTab = New System.ComponentModel.BackgroundWorker
        'Me.SaveTab.WorkerReportsProgress = True
        'Me.SaveTab.WorkerSupportsCancellation = True
        'Me.SaveTab.RunWorkerAsync()
        'Me.BS.Position = 0
        'Me.ProgressBar1.Visible = False
        'Me.PictureBox2.Visible = False
        'Click3 = True
        Me.CircularProgress1.Visible = True
        Me.CircularProgress1.IsRunning = True

        Me.Label5.Visible = True
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        Me.BackWorker3 = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        If Not Me.BackWorker3.IsBusy Then
            Me.BackWorker3.RunWorkerAsync()
        End If
    End Sub
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stepBALANCE.Click
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub
    Private Sub BackWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker3.DoWork
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·«—’œ… „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.InternalAuditorBalance()
            Me.UPDATERECORD()
            For IBSCount = 1 To CInt(Me.BS.Count)
                If Me.BackWorker3.CancellationPending Then
                    e.Cancel = True
                    Return
                End If
                Me.BS.Position = IBSCount
                Me.BackWorker3.ReportProgress(IBSCount)

                Me.InternalAuditorBalance()
                Me.UPDATERECORD()
            Next
            'Me.GETBANKNOWBALANCE()
            'Me.SumAmounJOBALANCE()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDoWorkBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
        On Error Resume Next
        Me.CircularProgress1.Value = e.ProgressPercentage
        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.Label5.Text = ProgressBar1.Value & "%"
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
                Me.CircularProgress1.IsRunning = False
                Me.CircularProgress1.Visible = False
                Me.Label5.Visible = False
            ElseIf e.Error IsNot Nothing Then
                Me.Label14.Text = "Error: " & e.Error.Message
            Else
                Me.BackWorker3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.CircularProgress1.IsRunning = False
                Me.CircularProgress1.Visible = False
                Me.Label5.Visible = False
                Me.SaveTab = New BackgroundWorker With {
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.SaveTab.RunWorkerAsync()
                Me.BS.Position = 0
                ModuleGeneral.Click3 = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompletedBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboBN2_1.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboBN2_1.Enabled = False
    End Sub
    Private Sub InternalAuditorBalance()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(BANKJO.EBNK4) AS SumDEBIT,Sum(BANKJO.EBNK5) AS SumCREDIT FROM BANKJO  WHERE (BANKJO.EBNK10)='" & Me.ComboBN2.Text & "'AND BANKJO.EBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
            ds.Clear()
            Adp1.Fill(ds, "BANKJO")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
            Else
                Me.TEXTPreviousBalance.Text = "0"
            End If
            Adp1.Dispose()
            Consum.Close()
        Catch ex As Exception
            Me.TEXTPreviousBalance.Text = "0"
        End Try
    End Sub
    Private Sub SumAmounJOBALANCE()
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT Sum(EBNK4-EBNK5)  FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK10 = '" & Me.ComboBN2.Text & "'AND EBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "BANKJO")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXTTotal.Text = "0"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)

        Else
            Me.TextBN3.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTCurrentBalance.TextChanged, ComboBN2.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Me.InternalAuditorBalance()
        Me.TEXTCurrentBalance.Text = Format(Val(TEXTPreviousBalance.Text) + Val(TEXTDebit.EditValue) - Val(TEXTCredit.EditValue), "0.000")
    End Sub
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateFrom.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DateTO.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX13_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTO.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTBOX13_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTO.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.PRINTBUTTON_Click(sender, e)
        End Select
    End Sub
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub UPDATERECORDCASHIER()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Dim SQL As New SqlClient.SqlCommand(" Update CASHIER SET  CSH2 = @CSH2, CSH3 = @CSH3, CSH4 = @CSH4, CSH5 = @CSH5, CSH7 = @CSH7, CSH8 = @CSH8, CSH10 = @CSH10, CSH11 = @CSH11, CSH12 = @CSH12, CSH15 = @CSH15, CSH17 = @CSH17, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE CSH4 = '" & Me.TextMovementSymbol.EditValue.ToString & "'" & "AND CSH15 = '" & Me.TEXTDocumentNumber.Text.ToString & "'", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CSH2", SqlDbType.DateTime).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@CSH3", SqlDbType.NVarChar).Value = "ﬁÌœ"
            .Parameters.Add("@CSH4", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@CSH5", SqlDbType.NVarChar).Value = "‰ﬁœ«"
            .Parameters.Add("@CSH7", SqlDbType.Float).Value = Me.TEXTCredit.EditValue
            .Parameters.Add("@CSH8", SqlDbType.Float).Value = Me.TEXTDebit.EditValue
            .Parameters.Add("@CSH10", SqlDbType.NVarChar).Value = "Ì‰ﬂ"
            .Parameters.Add("@CSH11", SqlDbType.NVarChar).Value = " ÕÊÌ· „‰ «·»‰ﬂ «·Ï «·’‰œÊﬁ"
            .Parameters.Add("@CSH12", SqlDbType.NVarChar).Value = "„‰ Õ”«» «·»‰ﬂ —ﬁ„ " & TEXTDocumentNumber.Text
            .Parameters.Add("@CSH15", SqlDbType.NVarChar).Value = TEXTID.EditValue
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
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
    End Sub
    Private Sub DELETEDATACASHIER()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As String = "DELETE FROM CASHIER  WHERE CSH4 = '" & Me.TEXTID.EditValue.ToString & "'" & "AND CSH10='Ì‰Êﬂ'"
            Dim cmd As New SqlClient.SqlCommand(sql, Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonTransferToCashMovements_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferToCashMovements.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            Static P As Integer
            P = BS.Position
            Me.ComboBN2_SelectedIndexChanged(sender, e)
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Dim MECB1, MECB2, MEBN2, MEBN3 As String
            Dim ch As Double
            Dim ch1 As Double
            MEBN2 = Me.ComboBN2.Text
            MEBN3 = Me.TextBN3.Text
            MECB1 = Me.ComboCB1.Text
            MECB2 = ModuleGeneral.CB2
            SumAmounJOBALANCE()
            Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.CheckLogReview.Checked = False
            If Me.CheckTransferFund.Checked = False Then
                resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï Õ—ﬂ… «·’‰œÊﬁ ", " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferFund.Checked = True
                    BS.Position = BS.Count - 1
                    F = Val(TEXTCurrentBalance.Text)
                    Try
                        CLEARDATA1(Me)
                        GetAutoNumber("EBNK1", "BANKJO", "EBNK3")
                        Me.TEXTID.EditValue = AutoNumber
                        Me.TextMovementSymbol.EditValue = "BA" & TEXTID.EditValue
                        Me.ComboConstraintType.Text = " ÕÊÌ· »‰ﬂÌ «·Ï Õ”«» «·’‰œÊﬁ"
                        Me.TEXTStatement.Text = " ÕÊÌ· »‰ﬂÌ «·Ï Õ”«» «·’‰œÊﬁ "
                        Me.ComboBN2.Text = MEBN2
                        Me.TextBN3.Text = MEBN3
                        Dim Frm As New mane
                        Frm.TEXTValues.Text = Format(Val(SumAmounTOTALBALANCE(AutoNumber, TEXTID.EditValue)), "0.000")
                        Frm.ShowDialog()
                        Me.TEXTCredit.EditValue = Val(Frm.TEXTValues.Text)
                        Me.TEXTDocumentNumber.Text = Frm.TextPermissionNumber.Text
                        ch = Format(Val(SumAmounTOTALBALANCE(AutoNumber, TEXTID.EditValue)), "0.000")
                        ch1 = Me.TEXTCredit.EditValue
                        If Val(ch) < Val(ch1) Then
                            MsgBox("«‰ »Â —’»œ «·⁄Âœ… ·« Ìﬂ›Ì ·Â–Â «·Õ—ﬂ…", 16, " ‰»ÌÂ")
                            Me.BUTTONCANCEL_Click(sender, e)
                            Exit Sub
                        End If
                        Dim sstring As String = "„‰ Õ”«» Õ—ﬂ… »‰ﬂ —ﬁ„ " & TEXTID.EditValue
                        Insert_BANKJO(0, Me.TEXTCredit.EditValue, Me.TEXTDocumentNumber.Text, Me.ComboConstraintType.Text, sstring, Me.ComboBN2.Text, Me.TextBN3.Text, Me.TextMovementSymbol.EditValue, False, True, Me.ComboCB1.Text)
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                    Me.PictureBox2.Visible = True
                    TransferToCashMovements()
                    Click7 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.ComboDebitAccount.Text = "«·’‰œÊﬁ"
                    Me.ComboBox5_SelectedIndexChanged(sender, e)
                    If Me.TextMovementRestrictions1.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA2()
                        Me.DELETEDATMOVESDATA3()
                    End If
                    If Me.TextFundMovementNumber.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì Õ—ﬂ… «·’‰œÊﬁ", 16, " ‰»Ì…")
                    Else
                        Me.DELETEDATAempsolf()
                    End If
                    TransferToCashMovements()
                    Me.PictureBox2.Visible = True
                    Click8 = True
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· Õ—ﬂ… «·’‰œÊﬁ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì Õ—ﬂ… «·’‰œÊﬁ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATAempsolf()
                        End If
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        Me.CheckTransferFund.Checked = False
                        Me.PictureBox2.Visible = True
                        Click9 = True
                    Else
                        Exit Sub
                    End If
                End If
            End If
            P = Me.BS.Position
            BS.EndEdit()
            BS.AddNew()
            Me.RowCount = Me.BS.Count
            Me.BS.Position = P
            'Me.UPDATERECORD()
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATAempsolf()
        Try
            MYDELETERECORD("CASHIER", "CSH1", TextFundMovementNumber, Me.BS, True)
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
    Private Sub DELETEDATMOVESDATA2()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions1, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA3()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELET, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnquiry.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… ﬁ—«  «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim F As New FrmAdvancedSearchMoviesBanks
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextGoTo.TextChanged
        Try
            If Me.TextGoTo.TextLength > 0 Then
                Dim index As Integer
                index = Me.BS.Find("EBNK1", Me.TextGoTo.Text.Trim)
                Me.BS.Position = index
                Me.RecordCount()
            Else
                Me.BS.Position = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TEXTBOX8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        'Try
        'Dim con As New SqlClient.SqlConnection(constring)
        'Dim strsq1 As New SqlClient.SqlCommand("SELECT  COUNT(*) FROM BANKJO  WHERE (BANKJO.EBNK10)='" & Me.TEXTBN2.Text & "'AND BANKJO.EBNK1 < " & Val(Me.TEXTBOX1.Text), con)
        'Dim ds As New DataSet
        'Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        'ds.Clear()
        'con.Open()
        'Adp1.Fill(ds, "BANKJO")
        'If Me.TEXTBOX8.Text.Contains("”Õ» »«·‘Ìﬂ") Or Me.TEXTBOX8.Text.Contains("”Õ» »«·‘Ìﬂ «·»‰ﬂÌ") Then
        'Else
        '    If ds.Tables(0).Rows.Count > 0 Then
        '        Me.TEXTBOX9.Text = Val(ds.Tables("BANKJO").Rows(0).Item(0)) + 1
        '    Else
        '        Me.TEXTBOX9.Text = 1
        '    End If
        'End If
        'Adp1.Dispose()
        'con.Close()
        On Error Resume Next
        Select Case Me.ComboConstraintType.Text
            Case "«Ìœ«⁄"
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.EditValue = 0
                Me.TEXTCredit.Enabled = False
            Case "”Õ»"
                Me.TEXTDebit.Enabled = False
                Me.TEXTDebit.EditValue = 0
                Me.TEXTCredit.Enabled = True
        End Select
        'Catch ex As Exception
        '    'Me.TEXTBOX9.Text = 1
        'End Try
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferToCashMovements.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ComboBN2.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.PanelCB1.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.ButtonTransferToCashMovements.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ComboBN2.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TEXTStatement.Enabled = False
            'If Me.TextLSet.Text = "BA" Then
            '    Me.PanelCB1.Enabled = True
            'Else
            '    Me.PanelCB1.Enabled = False
            'End If
            If Me.CHK = True Then
                Me.ComboBN2.Enabled = True
                Me.DateMovementHistory.Enabled = True
                Me.ComboConstraintType.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.PanelCB1.Enabled = True
            End If
        ElseIf Me.CheckLogReview.Checked = True And Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferToCashMovements.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ComboBN2.Enabled = False
            Me.ButtonAttachDocument.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TEXTStatement.Enabled = False
            'If Me.TextLSet.Text = "BA" Then
            '    Me.PanelCB1.Enabled = True
            'Else
            '    Me.PanelCB1.Enabled = False
            'End If
        Else
            Me.SHOWBUTTON()
            Me.ComboBN2.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboConstraintType.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.PanelCB1.Enabled = True
        End If
    End Sub
    Private Sub SaveMOVES()
        Try
            SEARCHDATA.MAXIDMOVES()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2.ToString.Trim
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text.Trim
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text.Trim
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "ﬁÌœ"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "BA"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOV12", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
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


    Private Sub SaveMOVESDATARecord()
        Try
            Dim A, C, S As String
            Dim Box2, Box3, Box4, Box5 As Integer
            nem = "«Ìœ«⁄« "
            pp = "1"
            A = TEXTPreviousBalance.Text
            S = "”ÕÊ»« "
            C = "0.00"

            'GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Module1.CB2, 1)
            'Box = ID_Nam
            'GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Module1.CB2, 1)
            'Box1 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            Box2 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
            Box3 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", List1.Text, 1)
            Box4 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", List1.Text, 1)
            Box5 = ID_Nam
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            Dim CMD As New SqlClient.SqlCommand

            With strSQL
                If TEXTCredit.EditValue = "0" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & pp.ToString & "','" & ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & TEXTDebit.EditValue & "','" & TEXTCredit.EditValue & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & pp.ToString + 1 & "','" & List1.Text.Trim & "','" & Box4.ToString.Trim & "','" & TEXTCredit.EditValue & "','" & TEXTDebit.EditValue & "','" & nem.Trim & "','" & Box5.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                Else

                    .CommandText = "Insert Into MOVESDATA(MOVD2,MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & pp.ToString & "','" & ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & TEXTCredit.EditValue & "','" & TEXTDebit.EditValue & "','" & S.Trim & "','" & Box3.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2,MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & pp.ToString + 1 & "','" & List1.Text.Trim & "','" & Box4.ToString.Trim & "','" & TEXTDebit.EditValue & "','" & TEXTCredit.EditValue & "','" & S.Trim & "','" & Box5.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & "','" & False & "','" & T2.ToString.Trim & "')"
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



    Private Sub TransferToCashMovements()
        Try
            nem = " ÕÊÌ· Õ”«» «·»‰ﬂ"
            nem1 = " ÕÊÌ· Õ”«» «·»‰ﬂ «·Ï «·’‰œÊﬁ"
            nem2 = " ÕÊÌ· Õ”«» ⁄Âœ… «·„ÊŸ›Ì‰ «·Ï «·»‰ﬂ"
            PMO2 = 1


            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextBN3.Text, 1)
            CredAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam

            SEARCHDATA.MAXIDMOVES()
            TransferToAccounts_Check = True

            AccountingEntries(T1, T2, MaxDate.ToString("yyyy-MM-dd"), LabelAutoEx.Text, True, TEXTCredit.EditValue, TEXTCredit.EditValue, T3, "ﬁÌœ", "BA", TextMovementSymbol.EditValue, False)

            DetailsAccountingEntries(PMO2, FundAccount_Name, FundAccount_No, TEXTCredit.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)


            Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "ﬁÌœ", TextMovementSymbol.EditValue, TEXTCredit.EditValue, 0, Me.Text,
                                   TEXTStatement.Text, False, TEXTDocumentNumber.Text, True, True, ComboCB1.Text, CB2)


        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "Õ—ﬂ«  »‰ﬂÌ…" & " " & ":" & " " & Me.TEXTID.EditValue & " " & "» «—ÌŒ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "   ··Õ”«» " & " " & ":" & " " & Me.ComboBN2.Text & " " & "„À» … »ÊÀÌﬁ… —ﬁ„" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
        LabelAutoEx.Text = ExResult
    End Sub
    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            AccountingprocedureAA()
            For XX1 As Integer = 0 To Connection.ACONET2.Count - 1
                Me.ACONETA.AppendText(Connection.ACONET2(XX1) & vbCrLf)
            Next
            MsgBox(Me.ACONETA.Text)
            Connection.ACONET3 = Me.ACONETA.Text.Trim
            UPDATE_Auditorsnotes()
        End If
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.TextLSet.Text.ToString <> "BA" Then
                MsgBox("⁄›Ê« .. ·«Ì„ﬂ‰  —ÕÌ·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ·", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            Me.CheckLogReview.Checked = False
            Static P As Integer
            If Me.CheckTransferAccounts.Checked = False Then
                resault = MessageBox.Show("  ”»‰„  —ÕÌ· «·Õ—ﬂ… «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… " & "Õ”«» " & Me.ComboDebitAccount.Text, " —ÕÌ· «·ﬁÌÊœ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    Me.CheckTransferAccounts.Checked = True
                    P = BS.Position
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
                    Click4 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show("  „  —ÕÌ· «·Õ—ﬂ… «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.ComboBox5_SelectedIndexChanged(sender, e)
                    If Me.TextMovementRestrictions.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    P = BS.Position
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
                    Click5 = True
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("Â·  —Ìœ Õ–› «·Õ—ﬂ… «·Õ«·Ï „‰ ÃœÊ· «·ﬁÌÊœ «·ÌÊ„Ì…", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        Me.CheckTransferAccounts.Checked = False
                        P = Me.BS.Position
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
                        Click6 = True
                    Else
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
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
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
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
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim SqlConnection2 As New SqlClient.SqlConnection
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
    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim SqlConnection2 As New SqlClient.SqlConnection
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()


        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = Conversion.Val(SEARCHDATA.MOV1C)
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = Conversion.Val(SEARCHDATA.MOV1B)

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET


        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TEXTDocumentNumber.Text)
        Me.TextFundMovementNumber.Text = Conversion.Val(SEARCHDATA.CSH1B)
    End Sub
    Private Sub FrmJO_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
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
            f.TEXTFileSubject.Text = "„” ‰œ«  «·»‰ﬂ"
            f.TextFileDescription.Text = "«—›«ﬁ „” ‰œ«  «·»‰ﬂ"
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
            Dim str As New SqlCommand("SELECT DOC1, LO FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
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
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        FundBalance()
    End Sub

    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateMovementHistory.ValueChanged
        On Error Resume Next
        Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub
End Class