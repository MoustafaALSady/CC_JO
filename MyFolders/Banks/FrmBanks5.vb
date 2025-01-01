Option Explicit Off
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Runtime.CompilerServices
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmBanks5
    Inherits Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlDataAdapter

    Private WithEvents ConnectDataBase As BackgroundWorker
    Private WithEvents SaveTab As BackgroundWorker
    Private WithEvents RefreshTab As BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0


    Dim _Type As String
    ReadOnly _Type1 As String
    Dim nem As String
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String

    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Private pp As String

    Dim CHK As Boolean = False
    Private Sub FrmBanks5_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmBanks5_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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
                        Me.TabPage4.Show()
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.TabPage4.Show()
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.TabPage4.Show()
                        Me.ButtonCancellationAuditingAndACheckingAccounts_Click(sender, e)
                    Case Keys.F9
                        Me.ButtonSearch_Click(sender, e)
                    Case Keys.F10
                        Me.TabPage4.Show()
                        Me.ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.F11
                        Me.TabPage4.Show()
                        Me.ButtonTransferOfCustodyOfEmployees_Click(sender, e)
                    Case Keys.F12
                        Me.CHK = True
                        Me.InternalAuditorType()
                        Me.EDITBUTTON.Enabled = False
                        Me.DELETEBUTTON.Enabled = False
                        Me.BALANCEBUTTON.Enabled = False
                        Me.InternalAuditorERBUTTON.Enabled = False
                        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
                    Case Keys.D And (e.Alt And Not e.Control And Not e.Shift)
                        Me.TabPage4.Show()
                        Me.ButtonXP1_Click(sender, e)
                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        Me.BALANCEBUTTON_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonUpdateA_Click(sender, e)
                    Case Keys.K And (e.Alt And Not e.Control And Not e.Shift)
                        Me.TabPage3.Show()
                        Me.Buttoncalcluter_Click(sender, e)
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
    Private Sub FrmBanks5_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
        Me.TabPage1.Show()
    End Sub
    Private Sub FrmBanks5_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Me.ButtonTransferOfCustodyOfEmployees.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        'Me.ButtonXP1.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        Me.BackW1.WorkerReportsProgress = True
        Me.BackW1.WorkerSupportsCancellation = True
        Me.BackW2.WorkerReportsProgress = True
        Me.BackW2.WorkerSupportsCancellation = True
        Me.BackW3.WorkerReportsProgress = True
        Me.BackW3.WorkerSupportsCancellation = True
        Me.CHK = False
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.BackW2 = New BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackW2.RunWorkerAsync()
        Me.load1.Enabled = False
        T = True
        F = False
        'SEARCHDATA.MAXIDMOVES()
        Me.CHK = False

    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboStaffMovement, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next

        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferOfCustodyOfEmployees.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = False

            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TextTimeAdd.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.ComboMotionSource.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboDetails.Enabled = False
            'Me.GroupBox5.Enabled = False
            'Me.Panel6.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonSearch.Enabled = True
            If Me.TextMovementSymbol1.Text.ToString <> "CH" Then
                Me.Panel6.Enabled = False
                Me.ButtonTransferofAccounts.Enabled = False
            Else
                Me.Panel6.Enabled = True
                Me.ButtonTransferofAccounts.Enabled = True
            End If
            Me.ButtonTransferOfCustodyOfEmployees.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonPrintReceiptDischarge.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

            Me.DateMovementHistory.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextTimeAdd.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.ComboMotionSource.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboDetails.Enabled = False
            If Me.CHK = True Then
                Me.EDITBUTTON.Enabled = False
                Me.DELETEBUTTON.Enabled = False
                Me.BUTTONCANCEL.Enabled = True
                Me.ButtonUpdateA.Enabled = True
                Me.ButtonSearch.Enabled = True
                If Me.TextMovementSymbol1.Text.ToString <> "CH" Then
                    Me.Panel6.Enabled = False
                    Me.ButtonTransferofAccounts.Enabled = False
                Else
                    Me.Panel6.Enabled = True
                    Me.ButtonTransferofAccounts.Enabled = True
                End If
                Me.ButtonTransferOfCustodyOfEmployees.Enabled = True
                Me.PRINTBUTTON.Enabled = True
                Me.ButtonPrintReceiptDischarge.Enabled = True
                Me.InternalAuditorERBUTTON.Enabled = True
                Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

                Me.DateMovementHistory.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.ComboConstraintType.Enabled = True
                Me.ComboPaymentMethod.Enabled = True
                Me.TextTimeAdd.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.ComboMotionSource.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.ComboDetails.Enabled = True
            End If
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferOfCustodyOfEmployees.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TextTimeAdd.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.ComboMotionSource.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboDetails.Enabled = False
            'Me.GroupBox5.Enabled = False
            'Me.Panel6.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.DateMovementHistory.Enabled = True
            Me.ComboConstraintType.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.ComboPaymentMethod.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.ComboMotionSource.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.ComboDetails.Enabled = True
            Me.GroupCheckDrawerNameOptions.Enabled = True
            Me.Panel6.Enabled = True
        End If
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("CASHIER").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmounJOBALANCE()
        'Me.SEARCHFROM()
        Me.TextMovementSymbol1.Text = Strings.LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.Label14.Text = Me.ComboDetails.Text
        Me.DateMovementHistory.Value = Me.TextDateMovementHistory.Text
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTCredit.EditValue) + Val(Me.TEXTDebit.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.AutoEx()
        'Call Me.AddType1()

        'Me.ComboCB1_SelectedIndexChanged(sender, e)

        MAXRECORD()
        Me.InternalAuditorType()
        If Me.TextMovementSymbol1.Text.ToString.Trim = "PR" Then 'المشتريات 
            SEARCHDATA.SEARCHBUYSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioLnvoiceStatusCash_Credit.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
        ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "VE" Then 'المبيعات 
            SEARCHDATA.SEARCHSLSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioLnvoiceStatusCash_Credit.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
        End If
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.BackW1 = New BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackW1.RunWorkerAsync()
        T = True
        F = False
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub

    Private Sub BackW1_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackW1.DoWork
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())

            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = String.Concat(New String() {"SELECT  CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17, CSH18, CSH19, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM CASHIER  WHERE  CUser='", ModuleGeneral.CUser, "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH1 ='", Strings.Trim(Me.TB1), "' or CSH4 ='", Strings.Trim(Me.TB2), "' or CSH15 ='", Strings.Trim(Me.TB3), "'ORDER BY CSH1"})
            End With
            Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Me.myds = New DataSet
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "CASHIER")
            Me.myds.RejectChanges()
            Consum.Close()
            
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorBackW1.DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub BackW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackW1.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            'FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            'FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB2)
            'If ComboCB1.Items.Count > 0 Then
            '    Me.ComboCB1.SelectedIndex = 0
            'End If
            'If ComboCB2.Items.Count > 0 Then
            '    Me.ComboCB2.SelectedIndex = 0
            'End If
            Me.BS.DataSource = Me.myds.Tables("CASHIER")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "CSH1", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CSH2", True, 1, "")
            Me.ComboConstraintType.DataBindings.Add("text", Me.BS, "CSH3", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CSH4", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CSH5", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CSH6", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CSH7", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CSH8", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CSH9", True, 1, "")
            Me.ComboMotionSource.DataBindings.Add("text", Me.BS, "CSH10", True, 1, "")
            Me.ComboDetails.DataBindings.Add("text", Me.BS, "CSH11", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CSH12", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CSH14", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CSH15", True, 1, "")
            Me.CheckStaffMovement.DataBindings.Add("Checked", Me.BS, "CSH16", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "CSH17", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CSH18", True, 1, "")
            Me.TextCB2.DataBindings.Add("text", Me.BS, "CSH19", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")

            Me.TextMovementSymbol1.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
            Me.Label14.Text = Me.ComboDetails.Text
            Auditor("CASHIER", "USERNAME", "CSH1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement)

            'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
            'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.List1)

            Me.ComboCB1_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Try
            Dim strSQL1 As New SqlCommand("SELECT distinct  CSH11 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.ComboDetails.Items.Add(DR(0))
            Loop
        Catch ex As Exception

        Finally

        End Try
        Try
            Dim strSQL2 As New SqlCommand("SELECT distinct  CSH10 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.ComboMotionSource.Items.Add(DR(0))
            Loop
        Catch ex As Exception

        Finally

        End Try
        Try
            Dim strSQL3 As New SqlCommand("SELECT distinct  CSH12 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Consum.Open()
            DR = strSQL3.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.TEXTStatement.Items.Add(DR(0))
            Loop
        Catch ex As Exception

        Finally

        End Try

        Call MangUsers()
        Me.SHOWBUTTON()
        Me.RecordCount()

        Me.BUTTONCANCEL.Enabled = True
        Me.LabelLoad.Visible = False
        Call CloseDB()
    End Sub
    Private Sub DISPLAYRECORD()
        Try
            With Me
                .TEXTID.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH1").ToString
                .TextDateMovementHistory.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH2").ToString
                .ComboConstraintType.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH3").ToString
                .TextMovementSymbol.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH4").ToString
                .ComboPaymentMethod.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH5").ToString
                .TEXTPreviousBalance.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH6").ToString
                .TEXTDebit.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH7").ToString
                .TEXTCredit.EditValue = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH8").ToString
                .TEXTCurrentBalance.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH9").ToString
                .ComboMotionSource.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH10").ToString
                .ComboDetails.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH11").ToString
                .TEXTStatement.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH12").ToString
                .CheckLogReview.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH14").ToString
                .TEXTDocumentNumber.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH15").ToString
                .CheckStaffMovement.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH16").ToString
                .CheckTransferAccounts.Checked = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH17").ToString
                .ComboCB1.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH18").ToString
                .TextCB2.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("CSH19").ToString
                .TEXTUserName.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("USERNAME").ToString
                .TEXTReferenceName.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("Auditor").ToString
                .TextDefinitionDirectorate.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("COUser").ToString
                .TEXTAddDate.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("da").ToString
                .TextTimeAdd.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("ne").ToString
                .TEXTReviewDate.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("da1").ToString
                .TextreviewTime.Text = Me.myds.Tables("CASHIER").Rows(Me.BS.Position).Item("ne1").ToString
            End With
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "ErrorDISPLAYRECORD", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Auditor("CASHIER", "USERNAME", "CSH1", Me.TEXTID.EditValue, "")
        Logentry = Uses
        ModuleGeneral.FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", ModuleGeneral.CUser, Me.ComboStaffMovement)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB2)
        'ModuleGeneral.FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
        'ModuleGeneral.FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.List1)

        'Me.ComboCB1_SelectedIndexChanged(sender, e)

        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Try
            Dim command As New SqlCommand("SELECT distinct  CSH11 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", connection)
            connection.Open()
            ModuleGeneral.DR = command.ExecuteReader(CommandBehavior.CloseConnection)
            Do While ModuleGeneral.DR.Read
                Me.ComboDetails.Items.Add(RuntimeHelpers.GetObjectValue(ModuleGeneral.DR.Item(0)))
            Loop
            connection.Close()
        Catch exception5 As Exception
            Dim exception2 As Exception = exception5
        End Try
        Try
            Dim command2 As New SqlCommand("SELECT distinct  CSH10 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", connection)
            connection.Open()
            ModuleGeneral.DR = command2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While ModuleGeneral.DR.Read
                Me.ComboMotionSource.Items.Add(RuntimeHelpers.GetObjectValue(ModuleGeneral.DR.Item(0)))
            Loop
            connection.Close()
        Catch exception6 As Exception
            Dim exception3 As Exception = exception6
        End Try
        Try
            Dim command3 As New SqlCommand("SELECT distinct  CSH12 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", connection)
            connection.Open()
            ModuleGeneral.DR = command3.ExecuteReader(CommandBehavior.CloseConnection)
            Do While ModuleGeneral.DR.Read
                Me.TEXTStatement.Items.Add(RuntimeHelpers.GetObjectValue(ModuleGeneral.DR.Item(0)))
            Loop
            connection.Close()
        Catch exception7 As Exception
            Dim exception4 As Exception = exception7
        End Try
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.RecordCount()
        Me.BUTTONCANCEL.Enabled = True
    End Sub
    Private Sub BackW2_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackW2.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17, CSH18, CSH19, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM CASHIER  WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1"
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
                Me.myds = New DataSet
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "CASHIER")
                Me.SqlDataAdapter1.Fill(myds, "CASHIER")
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Me.myds.RejectChanges()
            End With

        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorBackW2.DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            If Consum.State = ConnectionState.Open Then Consum.Close()
        End Try
    End Sub
    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.LabelLoad.Visible = True
                Me.LabelLoad.ForeColor = Color.Yellow
                Me.LabelLoad.Text = "فضلا انتظر قليلا .. يتم تحميل سجلات الحقل"
            Else
                Me.LabelLoad.ForeColor = Color.Red
                Me.LabelLoad.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub BackW2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackW2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboCB2.Items.Count > 0 Then
                Me.ComboCB2.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("CASHIER")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", BS, "CSH1", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", BS, "CSH2", True, 1, "")
            Me.ComboConstraintType.DataBindings.Add("text", BS, "CSH3", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", BS, "CSH4", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", BS, "CSH5", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", BS, "CSH6", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", BS, "CSH7", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", BS, "CSH8", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", BS, "CSH9", True, 1, "")
            Me.ComboMotionSource.DataBindings.Add("text", BS, "CSH10", True, 1, "")
            Me.ComboDetails.DataBindings.Add("text", BS, "CSH11", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", BS, "CSH12", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", BS, "CSH14", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", BS, "CSH15", True, 1, "")
            Me.CheckStaffMovement.DataBindings.Add("Checked", BS, "CSH16", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", BS, "CSH17", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CSH18", True, 1, "")
            Me.TextCB2.DataBindings.Add("text", Me.BS, "CSH19", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", BS, "ne1", True, 1, "")

            Me.TextMovementSymbol1.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
            Me.Label14.Text = Me.ComboDetails.Text
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement)
            Me.ComboCB1_SelectedIndexChanged(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBackW2.RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
        'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.List1)
        Auditor("CASHIER", "USERNAME", "CSH1", Me.TEXTID.EditValue, "")
        Logentry = Uses
        Label15.Text = Logentry.ToString
        Try
            Dim strSQL1 As New SqlCommand("SELECT distinct  CSH11 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.ComboDetails.Items.Add(DR(0))
            Loop
        Catch ex As Exception

        Finally

        End Try
        Try
            Dim strSQL2 As New SqlCommand("SELECT distinct  CSH10 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.ComboMotionSource.Items.Add(DR(0))
            Loop
        Catch ex As Exception

        Finally

        End Try
        Try
            Dim strSQL3 As New SqlCommand("SELECT distinct  CSH12 FROM CASHIER   WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Consum.Open()
            DR = strSQL3.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                Me.TEXTStatement.Items.Add(DR(0))
            Loop
        Catch ex As Exception

        Finally

        End Try
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.RecordCount()
        Me.BUTTONCANCEL.Enabled = True
        Me.LabelLoad.Visible = False
        Call CloseDB()
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update CASHIER SET  CSH2 = @CSH2, CSH3 = @CSH3, CSH4 = @CSH4, CSH5 = @CSH5, CSH6 = @CSH6, CSH7 = @CSH7, CSH8 = @CSH8, CSH9 = @CSH9, CSH10 = @CSH10, CSH11 = @CSH11, CSH12 = @CSH12, CSH14 = @CSH14, CSH15 = @CSH15, CSH16 = @CSH16, CSH17 = @CSH17, CSH18 = @CSH18, CSH19 = @CSH19, CUser = @CUser, COUser = @COUser, USERNAME = @USERNAME, Auditor = @Auditor, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE CSH1 = @CSH1 ", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSH1", SqlDbType.Int).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CSH2", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@CSH3", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@CSH4", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CSH5", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CSH6", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CSH7", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CSH8", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CSH9", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CSH10", SqlDbType.NVarChar).Value = Me.ComboMotionSource.Text
                .Parameters.Add("@CSH11", SqlDbType.NVarChar).Value = Me.ComboDetails.Text
                .Parameters.Add("@CSH12", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CSH14", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CSH15", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CSH16", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckStaffMovement.Checked)
                .Parameters.Add("@CSH17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@CSH18", SqlDbType.Int).Value = Me.ComboCB1.Text
                .Parameters.Add("@CSH19", SqlDbType.NVarChar).Value = Me.TextCB2.Text
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


    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "CASHIER")
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
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = myds.Tables("CASHIER")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Me.Count()
            If DelRow = False Then
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
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "CASHIER")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "CASHIER")
            'myds.RejectChanges()
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
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.ButtonUpdateA_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("CASHIER")
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
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل الحركة الى الحسابات", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل االى حركة عهدة الموظفين", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل حركة عهدة الموظفين", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة عهدة الموظفين", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
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
        End If
    End Sub


    Private Sub TEXT4_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXT5_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXT3_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.TextChanged, TEXTPreviousBalance.TextChanged, TEXTCurrentBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Me.InternalAuditorBalance()
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonTransferOfCustodyOfEmployees.Enabled = TransferofAccounts
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub

    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        On Error Resume Next
        Select Case Me.ComboConstraintType.Text
            Case "قبض"
                Me.TEXTCredit.Enabled = False
                Me.TEXTCredit.EditValue = "0"
                Me.TEXTDebit.Enabled = True
            Case "صرف"
                Me.TEXTCredit.Enabled = True
                Me.TEXTDebit.EditValue = "0"
                Me.TEXTDebit.Enabled = False
        End Select
    End Sub
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles ComboConstraintType.KeyDown, ComboPaymentMethod.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub CLEARDATA()
        On Error Resume Next
        Dim txt As Control
        For Each txt In Me.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
        Next
    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            N = 1
        Else
            N = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        'Me.TEXT1.Text = Val(N)
        'Me.lblNOWBALANCE.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub

    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
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
        Me.BS.Position = BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextMovementSymbol1.Text.ToString <> "CH" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن تعدبل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى من شاشة " & "  " & Me.ComboMotionSource.Text, "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTCredit.EditValue) + Val(Me.TEXTDebit.EditValue), "0.000")
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Click2 = True
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub SumAmounJOBALANCE()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CSH7-CSH8)   FROM CASHIER WHERE CUser='" & CUser & "' and Year(CSH2)  ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and (CSH18) =  '" & Me.ComboCB1.Text & "'", Consum)
        'Dim strsql As New SqlCommand("SELECT Sum(EBNK4-EBNK5)  FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK10 = '" & Me.TEXTBN2.Text & "'AND EBNK1 <'" & Me.TextBox1.Text & "'", Consum)

        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXTTotal.Text = "0"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub GETBANKNOWBALANCE()
        'On Error Resume Next
        Try
            Dim n As Double
            Dim F As Double
            n = BS.Position
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorGETBANKNOWBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub InternalAuditorBalance()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(CASHIER.CSH7) AS SumDEBIT,Sum(CASHIER.CSH8) AS SumCREDIT FROM CASHIER  WHERE CUser='" & CUser & "' and  (CASHIER.CSH18)='" & Me.ComboCB1.Text & "' AND CASHIER.CSH1 <'" & Me.TEXTID.EditValue & "'", Consum)
            '(CASHIER.CSH18)='" & Me.ComboCB1.Text & "'AND CASHIER.CSH1 <'" & Me.TEXT1.Text & "'", Consum)
            'Dim strsql As New SqlCommand("SELECT Sum(CSH7-CSH8)   FROM CASHIER WHERE CUser='" & CUser & "' and Year(CSH2)  ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and (CSH18) =  '" & Me.TextCB2.Text & "'AND CSH1  <'" & Me.TEXT1.Text & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
            ds.Clear()
            Adp1.Fill(ds, "CASHIER")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
            Else

            End If
            Adp1.Dispose()
            Consum.Close()

            'Dim Consum As New SqlClient.SqlConnection(constring)
            'Dim N As Double
            'Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
            'If Consum.State = ConnectionState.Open Then Consum.Close()
            'Consum.Open()
            'Dim resualt As Object = cmd1.ExecuteScalar()
            'If IsDBNull(resualt) Then
            '    N = 1
            'Else
            '    N = CType(resualt, Integer)
            'End If
            'Consum.Close()
            'Me.TEXT3.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
        Catch ex As Exception
            Me.TEXTPreviousBalance.Text = "0"
        End Try
    End Sub
    Private Sub BackW3_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackW3.DoWork
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
            Me.InternalAuditorBalance()
            Me.UPDATERECORD()

            For CBCount = 1 To CInt(Me.BS.Count)
                If Me.BackW3.CancellationPending Then
                    e.Cancel = True
                    Return
                End If
                Me.BS.Position = CBCount
                Me.BackW3.ReportProgress(CBCount)
                'Me.GETBANKNOWBALANCE()
                'Me.SumAmounJOBALANCE()
                Me.InternalAuditorBalance()
                Me.UPDATERECORD()
            Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDoWorkBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BackW3_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackW3.ProgressChanged
        On Error Resume Next
        Me.CircularProgress1.Value = e.ProgressPercentage
        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.LabelLoad.Text = ProgressBar1.Value & "%"
        Dim num2 As Integer = CInt(Math.Round(CDbl(CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum) * 100)))
        Using graphics As Graphics = Me.ProgressBar1.CreateGraphics
            Dim point As New PointF(CSng(CDbl(Me.ProgressBar1.Width) / 2) - (graphics.MeasureString(num2.ToString & "%", SystemFonts.DefaultFont).Width / 2.0!), CSng(CDbl(Me.ProgressBar1.Height) / 2) - (graphics.MeasureString(num2.ToString & "%", SystemFonts.DefaultFont).Height / 2.0!))
            graphics.DrawString(num2.ToString & "%", SystemFonts.DefaultFont, Brushes.Black, point)
        End Using
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorProgressChangedBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub
    Private Sub BackW3_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackW3.RunWorkerCompleted
        Try
            If e.Cancelled Then
                Me.BackW3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.CircularProgress1.IsRunning = False
                Me.CircularProgress1.Visible = False
                Me.Label15.Text = 0
                Me.LabelLoad.Visible = False
            ElseIf e.Error IsNot Nothing Then
                Me.Label14.Text = "Error: " & e.Error.Message
            Else
                Me.BackW3.CancelAsync()
                Me.ProgressBar1.Visible = False
                Me.CircularProgress1.IsRunning = False
                Me.CircularProgress1.Visible = False
                Me.Label15.Text = 0
                Me.Label15.Visible = False
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
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BALANCEBUTTON.Click
        'On Error Resume Next
        'Dim I As Integer
        'If TestNet = False Then
        '    MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
        '    Exit Sub
        'End If
        'If Me.BS.Count = 0 Then Beep() : Exit Sub
        'If LockUpdate = False Then
        '    MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
        '    Exit Sub
        'End If
        'On Error Resume Next
        ''Me.Cursor = Cursors.WaitCursor
        'BS.Position = 0
        'For I = 0 To BS.Count + 1
        '    Me.BS.Position = I
        '    Me.ProgressBar1.Visible = True
        '    Me.ProgressBar1.Minimum = 1
        '    Me.ProgressBar1.Maximum = (Me.BS.Count + 1)
        '    Me.ProgressBar1.Value = I
        '    Dim percent As Integer = CInt((CDbl(Me.ProgressBar1.Value - Me.ProgressBar1.Minimum) / CDbl(Me.ProgressBar1.Maximum - Me.ProgressBar1.Minimum)) * 100)
        '    Using gr As Graphics = Me.ProgressBar1.CreateGraphics()
        '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(Me.ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), Me.ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        '    End Using
        '    Me.PictureBox2.Visible = True
        '    Me.GETBANKNOWBALANCE()
        '    Me.UPDATERECORD()
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
        Click3 = True
        Me.CircularProgress1.Visible = True
        Me.CircularProgress1.IsRunning = True

        Me.LabelLoad.Visible = True
        Me.ProgressBar1.Visible = True
        'Me.PictureBox2.Visible = True
        Me.Label15.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        'Me.ProgressBar1.Value = 0
        If Not Me.BackW3.IsBusy Then
            Me.BackW3.RunWorkerAsync()
        End If



    End Sub
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles stepBALANCE.Click
        If Me.BackW3.IsBusy Then
            Me.BackW3.CancelAsync()
        End If

    End Sub

    Private Sub AddType1()
        On Error Resume Next
        If RadioClient.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSupplier.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEmployee.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub

    Private Sub RadioClient1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioClient.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioSupplier1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSupplier.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioEmployee1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEmployee.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioWithoutRestriction1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioWithoutRestriction.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPrintReceiptDischarge.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim txtFROMDate As String
        Dim txtToDate As String
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim f As New FrmPRINT
        Dim ds As New DataSet

        If Me.RdRes.Checked = True Then
            Dim strsq1 As New SqlCommand("SELECT CSH3 FROM cash   WHERE CSH1='" & Me.TEXTID.EditValue & "'" & "AND CSH3='قبض'", Consum)
            Dim dsType As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
            dsType.Clear()
            Adp1.Fill(dsType, "cash")
            Me._Type = "قبض"
            Adp1.Dispose()
        ElseIf Me.RdCus.Checked = True Then
            Dim strsq2 As New SqlCommand("SELECT CSH3 FROM cash   WHERE CSH1='" & Me.TEXTID.EditValue & "'" & "AND CSH3='صرف'", Consum)
            Dim dsType1 As New DataSet
            Dim Adp2 As New SqlDataAdapter(strsq2)
            dsType1.Clear()
            Adp2.Fill(dsType1, "cash")
            Adp2.Dispose()
            Me._Type = "صرف"
        End If

        If RdRes.Checked = True Then
            Dim rpt As New rptcash11
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim strAs1 As New SqlCommand("SELECT * FROM cash  WHERE CSH1 ='" & Me.TEXTID.EditValue & "'" & "AND CSH3='" & Me._Type & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(strAs1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "cash")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim txt As TextObject
                Dim txt1 As TextObject
                f.CrystalReportViewer1.ReportSource = rpt
                ' txt = rpt.Section1.ReportObjects("Text8")
                ' txt.Text = "خلال الفترة من  " & Format(Me.DateTimePicker3.Value, "dd - MM - yyyy") & "  الى  " & Format(Me.DateTimePicker4.Value, "dd - MM - yyyy")
                txt1 = rpt.Section1.ReportObjects("TEXT6")
                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("CSH7"), "jO")
                txt1 = rpt.Section1.ReportObjects("TEXT69")
                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("CSH7"), "jO")
                txt1 = rpt.Section1.ReportObjects("TEXT1")
                txt1.Text = Me._Type1
                txt1 = rpt.Section1.ReportObjects("TEXT2")
                txt1.Text = Me._Type1
                txt = rpt.Section1.ReportObjects("Text7")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT42")
                txt.Text = Character
                txt = rpt.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1

                txt = rpt.Section1.ReportObjects("TEXT44")
                txt.Text = Recorded
                txt = rpt.Section1.ReportObjects("Text56")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT64")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT63")
                txt.Text = Character
                txt = rpt.Section1.ReportObjects("Text77")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1

                txt = rpt.Section1.ReportObjects("Text76")
                txt.Text = Recorded
                txt = rpt.Section1.ReportObjects("Text4")
                txt.Text = Me.ComboCheckDrawerName.Text
                txt = rpt.Section1.ReportObjects("Text74")
                txt.Text = Me.ComboCheckDrawerName.Text
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                Consum.Close()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RdCus.Checked = True Then
            Dim ds1 As New DataSet
            Dim rpt As New rptcash21
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim strAs2 As New SqlCommand("SELECT * FROM cash  WHERE CSH1 ='" & Me.TEXTID.EditValue & "'" & "AND CSH3='" & Me._Type & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(strAs2)
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "cash")
            rpt.SetDataSource(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Dim txt As TextObject
                Dim txt1 As TextObject
                f.CrystalReportViewer1.ReportSource = rpt
                ' txt = rpt.Section1.ReportObjects("Text8")
                ' txt.Text = "خلال الفترة من  " & Format(Me.DateTimePicker3.Value, "dd - MM - yyyy") & "  الى  " & Format(Me.DateTimePicker4.Value, "dd - MM - yyyy")
                txt1 = rpt.Section1.ReportObjects("Text4")
                txt1.Text = CurrencyJO(ds1.Tables(0).Rows(0).Item("CSH8"), "jO")
                txt1 = rpt.Section1.ReportObjects("Text90")
                txt1.Text = CurrencyJO(ds1.Tables(0).Rows(0).Item("CSH8"), "jO")
                txt1 = rpt.Section1.ReportObjects("TEXT15")
                txt1.Text = Me._Type1
                txt1 = rpt.Section1.ReportObjects("TEXT22")
                txt1.Text = Me._Type1

                txt = rpt.Section1.ReportObjects("Text7")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT42")
                txt.Text = Character
                txt = rpt.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1

                txt = rpt.Section1.ReportObjects("TEXT44")
                txt.Text = Recorded
                txt = rpt.Section1.ReportObjects("Text18")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT19")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT50")
                txt.Text = Character
                txt = rpt.Section1.ReportObjects("Text48")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1

                txt = rpt.Section1.ReportObjects("Text45")
                txt.Text = Recorded
                txt = rpt.Section1.ReportObjects("Text32")
                txt.Text = Me.ComboCheckDrawerName.Text
                txt = rpt.Section1.ReportObjects("Text91")
                txt.Text = Me.ComboCheckDrawerName.Text
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                Consum.Close()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        End If
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim f As New FrmPRINT
        Dim txt As TextObject
        Dim rpt As New rptBanks20
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        'On Error Resume Next
        Try
            If Me.RadioAllAccounts.Checked = True Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim ds As New DataSet
                Dim strAs As New SqlCommand("SELECT * FROM CASHIER    WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(strAs)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CASHIER")
                rpt.SetDataSource(ds)
                f.CrystalReportViewer1.ReportSource = rpt
                txt = rpt.Section1.ReportObjects("Text8")
                txt.Text = "خلال الفترة من  " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & "  الى  " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT11")
                txt.Text = Directorate
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                Consum.Close()
            ElseIf Me.RadioOneAccount.Checked = True Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim ds As New DataSet
                Dim strAs As New SqlCommand("SELECT * FROM CASHIER    WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH18='" & Me.ComboCB2.Text & "'", Consum)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlDataAdapter(strAs)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CASHIER")
                rpt.SetDataSource(ds)
                f.CrystalReportViewer1.ReportSource = rpt
                txt = rpt.Section1.ReportObjects("Text8")
                txt.Text = "خلال الفترة من  " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & "  الى  " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT11")
                txt.Text = Directorate
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                Consum.Close()
            ElseIf Me.RadioUnreviewedRecords.Checked = True Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str1 As New SqlCommand("SELECT * FROM CASHIER    WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH14='" & False & "'", Consum)
                SqlDataAdapter2 = New SqlDataAdapter(str1)
                ds1.Clear()
                SqlDataAdapter2.Fill(ds1, "CASHIER")
                rpt.SetDataSource(ds1.Tables("CASHIER"))
                If ds1.Tables(0).Rows.Count > 0 Then
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    f.CrystalReportViewer1.ReportSource = rpt
                    f.CrystalReportViewer1.Zoom(90%)
                    f.CrystalReportViewer1.RefreshReport()
                    f.Show()
                    Consum.Close()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorPRINT", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
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
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")

        Me.DateMovementHistory.Enabled = False
        Me.ComboConstraintType.Enabled = False
        Me.TEXTDocumentNumber.Enabled = False
        Me.TextTimeAdd.Enabled = False
        Me.ComboPaymentMethod.Enabled = False
        Me.TEXTDebit.Enabled = False
        Me.TEXTCredit.Enabled = False
        Me.ComboMotionSource.Enabled = False
        Me.TEXTStatement.Enabled = False
        Me.ComboDetails.Enabled = False
        Me.RecordCount()

        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Click10 = True
    End Sub
    Private Sub ButtonCancellationAuditingAndACheckingAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        Try
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
            Me.SaveTab = New BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P
            Click11 = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        On Error Resume Next
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن حذف  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckStaffMovement.Checked = True Then
            Dim resault As Integer
            resault = MessageBox.Show("هل تريد حذف السجل الحالى من حركة عهدة الموظفين", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Me.DELETEDATAempsolf()
                MYDELETERECORD("CASHIER", "CSH1", Me.TEXTID, Me.BS, True)
                Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
            Else
                Exit Sub
            End If
        Else
            Exit Sub
        End If

    End Sub
    Private Sub ComboStaffMovement_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboStaffMovement.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboStaffMovement.Text & "'", Consum)
        Dim builder22 As New SqlCommandBuilder(SqlDataAdapter1)
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextStaffNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextStaffNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            MYDELETERECORD("EMPSOLF", "CSH1", Me.TextEmployeeContractNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonTransferOfCustodyOfEmployees_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferOfCustodyOfEmployees.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If TransferofAccounts = False Then
                MsgBox("عفوا .. غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboStaffMovement.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل اسم الموظف فارغ", 16, "تنبيه")
                Me.ComboStaffMovement.Focus()
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("عفوا .. يجب ترحيل اولا الى الحســـــــابات اولا ", 16, "تنبيه")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            Static P As Integer
            Dim MECB1 As String
            MECB1 = Me.ComboCB1.Text
            If Val(Me.TEXTTotal.Text) > 0 Then
                If Me.CheckStaffMovement.Checked = False Then
                    resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة عهدة الموظفين " & "للموظف " & Me.ComboStaffMovement.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Try
                            Cash = True
                            Dim ch As Double
                            Dim ch1 As Double


                            GetAutoNumber("CSH1", "CASHIER", "CSH2")
                            Me.TEXTID.EditValue = AutoNumber
                            ch = Format(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, TEXTID.EditValue), "0.000")
                            CLEARDATA1(Me)

                            Me.ComboDebitAccount_SelectedIndexChanged(sender, e)
                            Me.ComboCB1.Text = MECB1
                            Me.ComboCB1_SelectedIndexChanged(sender, e)

                            Me.TextMovementSymbol.EditValue = "CH" & TEXTID.EditValue
                            Me.ComboPaymentMethod.Text = "نقداً"
                            Me.ComboDetails.Text = "تحويل نقدي الى عهد الموظفين لغاية الايداع في البنك"
                            Me.TEXTStatement.Text = "تحويل نقدي الى عهد الموظفين"

                            Dim Frm As New mane
                            Frm.TextPermissionNumber.Enabled = False
                            Frm.TEXTValues.EditValue = Format(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, TEXTID.EditValue), "0.000")
                            Frm.ShowDialog()
                            Cash = True
                            Frm.TextPermissionNumber.Enabled = False
                            Me.TEXTCredit.EditValue = Frm.TEXTValues.EditValue
                            ch1 = Me.TEXTCredit.EditValue
                            If ch < ch1 Then
                                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                                BUTTONCANCEL_Click(sender, e)
                                Exit Sub
                            End If
                            Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TEXTCredit.EditValue, Me.Text, ComboDetails.Text, True, TEXTID.EditValue, True, True, ComboCB1.Text, TextCB2.Text)
                        Catch ex As Exception
                            MessageBox.Show(ex.Message, "ErrorMACASHIER", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                        TransferToCashMovements()
                        Click7 = True
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Cash = True
                        Me.ComboDebitAccount.Text = "عهد الموظفين"
                        Me.ComboDebitAccount_SelectedIndexChanged(sender, e)
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextEmployeeContractNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في عهدة الموظفين", 16, "تنبية")
                        Else
                            Me.DELETEDATAempsolf()
                        End If
                        TransferToCashMovements()
                        Click8 = True
                        AccountingprocedureA()
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة عهدة الموظفين", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextEmployeeContractNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في عهدة الموظفين", 16, "تنبية")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                Me.DELETEDATMOVESDATA2()
                                Me.DELETEDATMOVESDATA3()
                            End If
                            MYDELETERECORD("CASHIER", "CSH1", Me.TEXTID, Me.BS, True)
                            Me.CheckStaffMovement.Checked = False
                            Click9 = True
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                P = Me.BS.Position
                Me.PictureBox2.Visible = True
                Me.BS.EndEdit()
                Me.RowCount = Me.BS.Count
                'Me.UPDATERECORD()
                Me.SaveTab = New BackgroundWorker With {
                    .WorkerReportsProgress = True,
                    .WorkerSupportsCancellation = True
                }
                Me.SaveTab.RunWorkerAsync()
                Me.BS.Position = P
                'Me.ButtonUpdateA_Click(sender, e)
            Else
                MsgBox("لايمكن تحويل الحساب الدائن الى عهد الموظفين", 16, "تنبية")
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorMA", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearch.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim F As New FrmAdvancedSearchMoviesCashier
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboDebitAccount_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
        ds2.Clear()
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.account_noF = ds2.Tables(0).Rows(0).Item(0)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(2)
            Me.account_nameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.account_noF = ""
            Me.ACCF = ""
            Me.account_nameF = ""
        End If
        Consum.Close()
    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.TEXTStatement.Text & " " & "رقم" & " " & ":" & " " & Me.TEXTID.EditValue & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "حساب" & " " & ":" & " " & Me.ComboMotionSource.Text & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub


    Private Sub SaveMOVESDATARecord()
        Try
            Dim Box2, Box3, Box4, Box5 As Integer
            nem = Me.ComboDetails.Text.Trim
            pp = "1"
            'GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Module1.CB2, 1)
            'Box = ID_Nam
            'GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Module1.CB2, 1)
            'Box1 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboDebitAccount.Text, 1)
            Box2 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboDebitAccount.Text, 1)
            Box3 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.TextCreditAccount.Text, 1)
            Box4 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.TextCreditAccount.Text, 1)
            Box5 = ID_Nam
            Dim v As Double = 0
            If Me.TEXTDebit.EditValue > 0 Then
                v = Me.TEXTDebit.EditValue
            ElseIf Me.TEXTCredit.EditValue > 0 Then
                v = Me.TEXTCredit.EditValue
            End If
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            Dim CMD As New SqlCommand
            With strSQL
                .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                 & pp.ToString & "','" & Me.ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & Val(v) & "','" & 0.0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTDocumentNumber.Text.Trim & "','" & False & "','" & T2.ToString.Trim & "')"
                CMD.CommandType = CommandType.Text
                CMD.Connection = Consum
                CMD.CommandText = strSQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()

                .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & pp.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0.0 & "','" & Val(v) & "','" & nem.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTDocumentNumber.Text.Trim & "','" & False & "','" & T2.ToString.Trim & "')"
                CMD.CommandType = CommandType.Text
                CMD.Connection = Consum
                CMD.CommandText = strSQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()

            End With
        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorSaveMOVESDATARecord", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub TransferToCashMovements()
        Try
            Dim PreviousBalance As Double = 0
            Dim CurrentBalanceA As Double = 0
            nem = "تحويل نقدي الى عهد الموظفين" & " " & "على الموظف" & " " & Me.ComboStaffMovement.Text.Trim
            nem1 = "تحويل حساب الصندوق الى عهد الموظفين"
            PMO2 = 1
            PreviousBalance = Format(Val(SumAmounTOTALBALANCEEMPSOLF(Me.TextStaffNumber.Text, TEXTID.EditValue)), "0.000")
            CurrentBalance = (PreviousBalance - Val(Me.TEXTCredit.EditValue))

            If keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No) IsNot Nothing Then
                MsgBox(1)
                DebitAccount_No = keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No)
            End If
            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetFundAccount_No(TextCB2.Text)
            GetUpAccounts(ComboPaymentMethod.Text, DebitAccount_No)


            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam

            SEARCHDATA.MaxIDMoves()
            TransferToAccounts_Check = True

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), LabelAutoEx.Text, False, TEXTCredit.EditValue, TEXTCredit.EditValue, T3, "قيد", "CH", TextMovementSymbol.EditValue, False)

            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTCredit.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, FundAccount_Name, FundAccount_No, 0, TEXTCredit.EditValue, nem, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

            Insert_EMPSOLF("ايداع", Me.TEXTID.EditValue, PreviousBalance, TEXTCredit.EditValue, 0, CurrentBalance, Me.ComboMotionSource.Text, Me.ComboDetails.Text, True, Me.ComboStaffMovement.Text, Me.TextStaffNumber.Text, Me.TextMovementSymbol.EditValue, False, Me.ComboCB1.Text, 0)

        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveMOVES()
        Try
            SEARCHDATA.MAXIDMOVES()
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2.ToString.Trim
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.Bit).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = Conversion.Val(SEARCHDATA.MAXMOV8)
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "CH"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
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
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
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
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextMovementSymbol1.Text.ToString <> "CH" Then
                MsgBox("عفوا .. لايمكن ترحيل  السجل الحالى لأنه مرحل", 16, "تنبيه")
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
            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            Static P As Integer
            Me.ComboDebitAccount_SelectedIndexChanged(sender, e)
            If Me.CheckTransferAccounts.Checked = False Then
                resault = MessageBox.Show("  سبنم ترحيل الحركة الحالى الى القيود اليومية " & "حساب " & Me.ComboDebitAccount.Text, "ترحيل القيود", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferAccounts.Checked = True
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    Click4 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل الحركة الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions.Text = "" Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    Me.ButtonUpdateA_Click(sender, e)
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    Click5 = True
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("هل تريد حذف الحركة الحالى من جدول القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        Me.CheckTransferAccounts.Checked = False
                        Click6 = True
                    Else
                        Exit Sub
                    End If
                End If
            End If
            P = Me.BS.Position
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTCurrentBalance.Text = Format(Val(TEXTPreviousBalance.Text) - Val(Me.TEXTCredit.EditValue) + Val(Me.TEXTDebit.EditValue), "0.000")
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.UPDATERECORD()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementSourceNumber.Click
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.TextMovementSymbol1.Text.ToString.Trim = "SD" Then ' شهادات الاسهم _ الودائع SD
                SEARCHDATA.SEARCHID2(Me.TextMovementSymbol.EditValue)
                Dim F1 As New FrmDeposits With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                F1.Show()
                F1.DanLOd()

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "WD" Then 'السحب والإيداع WD
                SEARCHDATA.SEARCHID3(Me.TextMovementSymbol.EditValue)
                Dim F2 As New FrmTransaction With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                F2.Show()
                F2.DanLOd()
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "BA" Then  'البنك 
                SEARCHDATA.SEARCHID4(Me.TextMovementSymbol.EditValue)
                Dim F3 As New FrmJO With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                F3.Show()
                F3.DanLOd()

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "BT" Then   'فاتورة نقل   
                SEARCHDATA.SEARCHID5(Me.TextMovementSymbol.EditValue)
                Dim F4 As New FrmTRANSPORT With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                F4.Show()
                F4.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "TL" Then   'فاتورة نقل تفصيلية  
                SEARCHDATA.SEARCHID6(Me.TextMovementSymbol.EditValue)
                Dim F5 As New FrmInvoice With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                F5.Show()
                F5.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "ER" Then 'م تخليص 
                SEARCHDATA.SEARCHID7(Me.TextMovementSymbol.EditValue)
                Dim F6 As New FrmCUSTOMER11 With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                F6.Show()
                F6.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "GE" Then  'م . عامة  
                SEARCHDATA.SEARCHID8(Me.TextMovementSymbol.EditValue)
                Dim F7 As New FrmMyCosts With {
                    .TB1 = Me.TextMovementSourceNumber.Text.Trim
                }
                F7.Show()
                F7.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "PR" Then 'المشتريات 
                Dim F8 As New FrmSuppliesA
                If Me.RadioLnvoiceStatusCash_Credit.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                F8.TB1 = Trim(TextMovementSourceNumber.Text)
                F8.Show()
                F8.Load1_Click(sender, e)
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "VE" Then 'المبيعات 
                SEARCHDATA.SEARCHID10(Me.TextMovementSymbol.EditValue)
                Dim F9 As New FrmCustomersA
                If Me.RadioLnvoiceStatusCash_Credit.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                F9.TB1 = Trim(TextMovementSourceNumber.Text)
                F9.Show()
                F9.DanLOd()

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "QR" Then 'المبيعات
                Dim ds8 As New DataSet
                Dim SqlDataAdapter8 As New SqlDataAdapter
                Dim SqlConnection8 As New SqlConnection
                Dim F8 As New Form_mabeat
                ds8.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT DataTS, TS9 FROM TodaySales WHERE   CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TS9 ='" & TextMovementSourceNumber.Text & "'ORDER BY ID", Consum)
                SqlDataAdapter8 = New SqlDataAdapter(str)
                ds8.Clear()
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                SqlDataAdapter8.Fill(ds8, "TodaySales")
                F8.BS.DataMember = "TodaySales"
                F8.BS.DataSource = ds8
                Dim index As Integer
                index = F8.BS.Find("TS9", Me.TextMovementSourceNumber.Text.Trim)
                If ds8.Tables.Item(0).Rows.Count > 0 Then
                    F8.Textdaee1.Text = ds8.Tables(0).Rows(0).Item(0)
                    F8.Show()
                    F8.BuakrT_Click(sender, e)
                Else
                    Me.TextMovementSourceNumber.Text = Nothing
                End If
                Consum.Close()
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "PA" Then 'الدفعات
                SEARCHDATA.SEARCHID1(Me.TextMovementSymbol.EditValue)
                Dim ds As New DataSet
                Dim SqlDataAdapter1 As New SqlDataAdapter
                Dim F As New CustomerPay
                ds.EnforceConstraints = False
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim str As New SqlCommand("SELECT Loa1 FROM LoansPa WHERE  CUser ='" & CUser & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                Consum.Close()
                SqlDataAdapter1.Fill(ds, "LoansPa")
                F.BS.DataMember = "LoansPa"
                F.BS.DataSource = ds
                Dim index As Integer
                index = F.BS.Find("Loa1", Me.TextMovementSourceNumber.Text)
                F.Show()
                F.CustomerPay_Load(sender, e)
                F.BS.Position = index
                SqlDataAdapter1.Dispose()
                Consum.Close()
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "LO" Then 'الذمم المدينة
                SEARCHDATA.SEARCHID11(Me.TextMovementSymbol.EditValue)
                Dim F As New Loans With {
                    .TB1 = Trim(Me.TextMovementSourceNumber.Text)
                }
                F.Show()
                F.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "ES" Then
                Dim DataSet As New DataSet
                Dim Adapter As New SqlDataAdapter
                Dim Employees As New FormEmployees4
                DataSet.EnforceConstraints = False
                Dim selectCommand As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE   CUser ='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY SLY1", Consum)
                Adapter = New SqlDataAdapter(selectCommand)
                DataSet.Clear()
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Adapter.Fill(DataSet, "SALARIES")
                Employees.BS.DataMember = "SALARIES"
                Employees.BS.DataSource = DataSet
                Dim num12 As Integer = Employees.BS.Find("SLY1", Me.TextMovementSourceNumber.Text)
                Employees.Show()
                Employees.Load1.PerformClick()
                Employees.BS.Position = num12
                Adapter.Dispose()
                Consum.Close()
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "AS" Then
                Dim DataSet As New DataSet
                Dim Adapter As New SqlDataAdapter
                Dim Employees As New FrmEmpCost
                DataSet.EnforceConstraints = False
                Dim selectCommand As New SqlCommand("SELECT CST1 FROM EMPCOST WHERE   CUser ='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CST1", Consum)
                Adapter = New SqlDataAdapter(selectCommand)
                Dim builder12 As New SqlCommandBuilder(Adapter)
                DataSet.Clear()
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Adapter.Fill(DataSet, "EMPCOST")
                Employees.BS.DataMember = "EMPCOST"
                Employees.BS.DataSource = DataSet
                Dim num12 As Integer = Employees.BS.Find("CST1", Me.TextMovementSourceNumber.Text)
                Employees.Show()
                Employees.load1.PerformClick()
                Employees.BS.Position = num12
                Adapter.Dispose()
                Consum.Close()
            Else
                Me.TextMovementSourceNumber.Text = Me.TextMovementSymbol1.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.RefreshTab = New BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
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
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicEmployeeContractNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmEmpsolf
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM EMPSOLF WHERE  CUser='" & CUser & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPSOLF")
            f.BS.DataMember = "EMPSOLF"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("CSH1", Me.TextEmployeeContractNumber.Text.Trim)
            f.TB1 = Me.TextEmployeeContractNumber.Text.Trim
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
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicAccountLevel.Click
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List1.MouseDoubleClick
        TextCreditAccount.Text = List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
    Private Sub NumericUpDown1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHAccount_no(Me.ComboMotionSource.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name

        If Me.TextMovementSymbol1.Text.ToString.Trim = "PR" Then 'المشتريات 
            SEARCHDATA.SEARCHBUYSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioLnvoiceStatusCash_Credit.Checked = Conversion.Val(SEARCHDATA.BUYCASH)
        ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "VE" Then 'المبيعات 
            SEARCHDATA.SEARCHSLSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioLnvoiceStatusCash_Credit.Checked = Conversion.Val(SEARCHDATA.SLSCASH)
        End If
        If Me.CheckStaffMovement.Checked = True Then
            SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
            Me.TextMovementRestrictions.Text = Conversion.Val(SEARCHDATA.MOV1C)
        Else
            SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
            Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1B
        End If
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = Conversion.Val(SEARCHDATA.MOV1C)


        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET


        SEARCHDATA.SEARCHEMPSOLF(Me.TextMovementSymbol.EditValue)
        Me.TextEmployeeContractNumber.Text = Conversion.Val(SEARCHDATA.CSH1E)
        Me.SEARCHFROM()
    End Sub
    Private Sub SEARCHFROM()
        Try
            If Me.TextMovementSymbol1.Text.ToString.Trim = "SD" Then
                SEARCHDATA.SEARCHID2(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.TBNK1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "WD" Then
                SEARCHDATA.SEARCHID3(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.TBNK1A.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "BA" Then
                SEARCHDATA.SEARCHID4(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.EBNK1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "BT" Then
                SEARCHDATA.SEARCHID5(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.PTRO1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "TL" Then
                SEARCHDATA.SEARCHID6(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.PTRO1A.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "ER" Then
                SEARCHDATA.SEARCHID7(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.CEMP3.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "GE" Then
                SEARCHDATA.SEARCHID8(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.CST1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "PR" Then
                SEARCHDATA.SEARCHID9(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.BUY1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "VE" Then
                SEARCHDATA.SEARCHID10(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.SLS1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "QR" Then
                Dim Consum As New SqlConnection(ModuleGeneral.constring)
                Dim ds8 As New DataSet
                Dim SqlDataAdapter8 As New SqlDataAdapter
                Dim SqlConnection8 As New SqlConnection
                Dim f8 As New Form_mabeat
                ds8.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT TS9 FROM TodaySales WHERE   CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY ID", Consum)
                SqlDataAdapter8 = New SqlDataAdapter(str)
                ds8.Clear()
                Consum.Open()
                SqlDataAdapter8.Fill(ds8, "TodaySales")
                If ds8.Tables.Item(0).Rows.Count > 0 Then
                    Me.TextMovementSourceNumber.Text = ds8.Tables.Item(0).Rows.Item(0).Item(0)
                Else
                    Me.TextMovementSourceNumber.Text = Nothing
                End If
                Consum.Close()
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "PA" Then
                SEARCHDATA.SEARCHID(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.Loa1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "LO" Then
                SEARCHDATA.SEARCHID1(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.Lo1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "KS" Then
                SEARCHDATA.SEARCHID11(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.IDCH1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "ES" Then
                SEARCHDATA.SEARCHID12(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.SLY1.ToString
            ElseIf Me.TextMovementSymbol1.Text.ToString.Trim = "AS" Then
                SEARCHDATA.SEARCHEMPCOSTID(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = SEARCHDATA.IDEmpCost
            Else
                Me.TextMovementSourceNumber.Text = Me.TextMovementSymbol1.Text
            End If
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
        End Try
    End Sub

    Private Sub FrmBanks5_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.BackW3.IsBusy Then
            Me.BackW3.CancelAsync()
        End If
    End Sub
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
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
        MAXRECORD()
        LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
    End Sub


    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles DateMovementHistory.ValueChanged
        On Error Resume Next
        Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub





End Class