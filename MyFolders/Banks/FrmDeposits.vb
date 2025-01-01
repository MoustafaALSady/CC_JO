Option Explicit Off

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmDeposits
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private Account_NoF As String
    Private ACCF As String
    Private Account_NameF As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Dim CHK As Boolean = False

    Private Sub FrmDeposits_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmDeposits_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub FrmDeposits_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
        Me.TabPage1.Show()
    End Sub
    Private Sub FrmDeposits_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.ButtonXP2.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.PRINTBUTTON.Enabled = False
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
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
        AutoComplete(Me.ComboMembersCode, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboMembersCode.KeyPress

        On Error Resume Next
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.ComboMembersCode.Enabled = False
        End If
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
            Me.ButtonXP2.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.ComboAccountNumber.Enabled = False
            Me.TEXTReleaseDate.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTPreviousBalance.Enabled = False
            Me.TextCertificateAmount.Enabled = False
            Me.TEXTReturnRatio.Enabled = False
            Me.TEXTDuration.Enabled = False
            Me.ComboDistributionRate.Enabled = False
            Me.TEXTEndCertificate.Enabled = False
            Me.TEXTCurrentBatch.Enabled = False
            Me.PanelAccount.Enabled = False
            Me.Panel2.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonXP2.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.ComboAccountNumber.Enabled = False
            Me.TEXTReleaseDate.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTPreviousBalance.Enabled = False
            Me.TextCertificateAmount.Enabled = False
            Me.TEXTReturnRatio.Enabled = False
            Me.TEXTDuration.Enabled = False
            Me.ComboDistributionRate.Enabled = False
            Me.TEXTEndCertificate.Enabled = False
            Me.TEXTCurrentBatch.Enabled = False
            Me.ComboMembersCode.Enabled = False
            If Me.CHK = True Then
                Me.ComboAccountNumber.Enabled = True
                Me.TEXTReleaseDate.Enabled = True
                Me.ComboAccountType.Enabled = True
                'Me.TEXTPreviousBalance.Enabled = True
                Me.TextCertificateAmount.Enabled = True
                Me.TEXTReturnRatio.Enabled = True
                Me.TEXTDuration.Enabled = True
                Me.ComboDistributionRate.Enabled = True
                Me.TEXTEndCertificate.Enabled = True
                Me.TEXTCurrentBatch.Enabled = True
                Me.PanelAccount.Enabled = True
                Me.Panel2.Enabled = True
            End If
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonXP2.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.ComboAccountNumber.Enabled = False
            Me.TEXTReleaseDate.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTPreviousBalance.Enabled = False
            Me.TextCertificateAmount.Enabled = False
            Me.TEXTReturnRatio.Enabled = False
            Me.TEXTDuration.Enabled = False
            Me.ComboDistributionRate.Enabled = False
            Me.TEXTEndCertificate.Enabled = False
            Me.TEXTCurrentBatch.Enabled = False
            Me.PanelAccount.Enabled = False
            Me.Panel2.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.ComboAccountNumber.Enabled = True
            Me.TEXTReleaseDate.Enabled = True
            Me.ComboAccountType.Enabled = True
            'Me.TEXTPreviousBalance.Enabled = True
            Me.TextCertificateAmount.Enabled = True
            Me.TEXTReturnRatio.Enabled = True
            Me.TEXTDuration.Enabled = True
            Me.ComboDistributionRate.Enabled = True
            Me.TEXTEndCertificate.Enabled = True
            Me.TEXTCurrentBatch.Enabled = True
            Me.PanelAccount.Enabled = True
            Me.Panel2.Enabled = True
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
        If Me.BS.Position < Me.myds.Tables("Deposits").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmounBALANCE()
        Me.AutoEx()
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.TEXTEndCertificate.Text = Format(DateAdd(DateInterval.Year, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(TEXTReleaseDate.Text)), "yyyy/MM/dd")

        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        'Me.ComboCB1_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try

            Me.Invoke(New LoadDataBaseCallBack(AddressOf Me.LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Deposits  WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK1 ='" & Strings.Trim(Me.TB1) & "' or TBNK6 ='" & Strings.Trim(Me.TB2) & "' or TBNK20 ='" & Strings.Trim(Me.TB3) & "'or TBNK21 ='" & Strings.Trim(Me.TB4) & "'ORDER BY TBNK1"
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(Me.SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "Deposits")
                Me.SqlDataAdapter1.Fill(Me.myds, "Deposits")
                Me.myds.RejectChanges()
                Consum.Close()
            End With
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "ErrorBackWorker2_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Me.load1.Enabled = False
    End Sub
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("Deposits")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "TBNK1", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "TBNK2", True, 1, "")
            Me.TEXTReleaseDate.DataBindings.Add("text", Me.BS, "TBNK3", True, 1, "")
            Me.TEXTReturnRatio.DataBindings.Add("text", Me.BS, "TBNK4", True, 1, "")
            Me.TextCertificateAmount.DataBindings.Add("text", Me.BS, "TBNK5", True, 1, "")
            Me.ComboAccountNumber.DataBindings.Add("text", Me.BS, "TBNK6", True, 1, "")
            Me.TEXTReturnValue.DataBindings.Add("text", Me.BS, "TBNK7", True, 1, "")
            Me.ComboDistributionRate.DataBindings.Add("text", Me.BS, "TBNK8", True, 1, "")
            Me.TEXTEndCertificate.DataBindings.Add("text", Me.BS, "TBNK9", True, 1, "")
            Me.TEXTCurrentBatch.DataBindings.Add("text", Me.BS, "TBNK10", True, 1, "")
            Me.TEXTTotal.DataBindings.Add("text", Me.BS, "TBNK11", True, 1, "")
            Me.CheckOpeningBalance.DataBindings.Add("Checked", Me.BS, "TBNK12", True, 1, "")
            Me.TextNumberPayments.DataBindings.Add("text", Me.BS, "TBNK13", True, 1, "")
            Me.TextPaymentValue.DataBindings.Add("text", Me.BS, "TBNK14", True, 1, "")
            Me.TextResidualYield.DataBindings.Add("text", Me.BS, "TBNK15", True, 1, "")
            Me.TextRemainingPayments.DataBindings.Add("text", Me.BS, "TBNK16", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "TBNK17", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "TBNK18", True, 1, "")
            Me.ComboAccountType.DataBindings.Add("text", Me.BS, "TBNK19", True, 1, "")
            Me.TextMembersName.DataBindings.Add("text", Me.BS, "TBNK20", True, 1, "")
            Me.TextMembersCode.DataBindings.Add("text", Me.BS, "TBNK21", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "TBNK22", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "TBNK23", True, 1, "")
            Me.TEXTDuration.DataBindings.Add("text", Me.BS, "TBNK24", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CoUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Auditor("Deposits", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber1)
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
            FILLCOMBOBOXDISTINCT("AllCustomers", "cust2", "IDcust", "CUser", CUser, Me.ComboMembersCode)
            Me.ComboCB1_SelectedIndexChanged(sender, e)

            Me.SumAmounBALANCE()
            Me.RecordCount()
            Me.ComboMembersCode.Text = "00000"
            Me.BUTTONCANCEL.Enabled = True
            'Me.ComboMembersCode.Enabled = False
            Call MangUsers()

            TestkeyAccounts(keyAccounts.GetValue("StockAccount_No", StockAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("StockAccount_No", StockAccount_No)
            End If
            'SetUpComboBox(ComboAccountType)
            GetNoRecord("ACCOUNTSTREE", "Account_No", "Account_Name", ComboAccountType.Text, 1)
            AccountNoAktevd = ID_Nam

            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If
            Me.LabelLoadData.Visible = False
            Me.PictureBox5.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBackWorker2_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Consum.Close()
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackWorker2.RunWorkerAsync()
        Me.load1.Enabled = False
        Me.CHK = False
    End Sub
    Private Sub DISPLAYRECORD()
        Try
            Me.BS.DataSource = Me.myds.Tables("Deposits")
            Me.RowCount = Me.BS.Count
            With Me
                .TEXTID.EditValue = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK1").ToString
                .TEXTPreviousBalance.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK2").ToString
                .TEXTReleaseDate.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK3").ToString
                .TEXTReturnRatio.EditValue = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK4").ToString
                .TextCertificateAmount.EditValue = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK5").ToString
                .ComboAccountNumber.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK6").ToString
                .TEXTReturnValue.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK7").ToString
                .ComboDistributionRate.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK8").ToString
                .TEXTEndCertificate.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK9").ToString
                .TEXTCurrentBatch.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK10").ToString
                .TEXTTotal.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK11").ToString
                .CheckOpeningBalance.Checked = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK12").ToString
                .TextNumberPayments.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK13").ToString
                .TextPaymentValue.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK14").ToString
                .TextResidualYield.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK15").ToString
                .TextRemainingPayments.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK16").ToString
                .CheckLogReview.Checked = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK17").ToString
                .TextMovementSymbol.EditValue = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK18").ToString
                .ComboAccountType.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK19").ToString
                .TextMembersName.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK20").ToString
                .TextMembersCode.EditValue = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK21").ToString
                .CheckTransferAccounts.Checked = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK22").ToString
                .TEXTDocumentNumber.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK23").ToString
                .TEXTDuration.EditValue = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("TBNK24").ToString
                .TEXTUserName.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("USERNAME").ToString
                .TEXTReferenceName.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("Auditor").ToString
                .TextDefinitionDirectorate.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("COUser").ToString
                .TEXTAddDate.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("da").ToString
                .TextTimeAdd.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("ne").ToString
                .TEXTReviewDate.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("da1").ToString
                .TextreviewTime.Text = Me.myds.Tables("Deposits").Rows(Me.BS.Position).Item("ne1").ToString
                Auditor("Deposits", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
                Logentry = Uses
                FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber1)
                FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
                FILLCOMBOBOXDISTINCT("AllCustomers", "cust2", "IDcust", "CUser", CUser, Me.ComboMembersCode)

                Me.SumAmounBALANCE()
                Me.RecordCount()
                Me.ComboMembersCode.Text = ""
                Me.BUTTONCANCEL.Enabled = True
                Me.ComboMembersCode.Enabled = False
                Call MangUsers()
                Me.LabelLoadData.Visible = False
                Me.PictureBox5.Visible = False
            End With
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "ErrorDISPLAYRECORD", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Consum.Close()
    End Sub

    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf Me.LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Deposits  WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY TBNK1"
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(Me.SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "Deposits")
                Me.SqlDataAdapter1.Fill(Me.myds, "Deposits")
                Me.myds.RejectChanges()
                Consum.Close()
            End With
            Auditor("Deposits", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorConnectDataBase_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Me.PictureBox5.Visible = True
                Me.LabelLoadData.Visible = True
                Me.LabelLoadData.ForeColor = Color.Yellow
                Me.LabelLoadData.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
            Else
                Me.LabelLoadData.ForeColor = Color.Red
                Me.LabelLoadData.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub

            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("Deposits")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "TBNK1", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "TBNK2", True, 1, "")
            Me.TEXTReleaseDate.DataBindings.Add("text", Me.BS, "TBNK3", True, 1, "")
            Me.TEXTReturnRatio.DataBindings.Add("text", Me.BS, "TBNK4", True, 1, "")
            Me.TextCertificateAmount.DataBindings.Add("text", Me.BS, "TBNK5", True, 1, "")
            Me.ComboAccountNumber.DataBindings.Add("text", Me.BS, "TBNK6", True, 1, "")
            Me.TEXTReturnValue.DataBindings.Add("text", Me.BS, "TBNK7", True, 1, "")
            Me.ComboDistributionRate.DataBindings.Add("text", Me.BS, "TBNK8", True, 1, "")
            Me.TEXTEndCertificate.DataBindings.Add("text", Me.BS, "TBNK9", True, 1, "")
            Me.TEXTCurrentBatch.DataBindings.Add("text", Me.BS, "TBNK10", True, 1, "")
            Me.TEXTTotal.DataBindings.Add("text", Me.BS, "TBNK11", True, 1, "")
            Me.CheckOpeningBalance.DataBindings.Add("Checked", Me.BS, "TBNK12", True, 1, "")
            Me.TextNumberPayments.DataBindings.Add("text", Me.BS, "TBNK13", True, 1, "")
            Me.TextPaymentValue.DataBindings.Add("text", Me.BS, "TBNK14", True, 1, "")
            Me.TextResidualYield.DataBindings.Add("text", Me.BS, "TBNK15", True, 1, "")
            Me.TextRemainingPayments.DataBindings.Add("text", Me.BS, "TBNK16", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "TBNK17", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "TBNK18", True, 1, "")
            Me.ComboAccountType.DataBindings.Add("text", Me.BS, "TBNK19", True, 1, "")
            Me.TextMembersName.DataBindings.Add("text", Me.BS, "TBNK20", True, 1, "")
            Me.TextMembersCode.DataBindings.Add("text", Me.BS, "TBNK21", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "TBNK22", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "TBNK23", True, 1, "")
            Me.TEXTDuration.DataBindings.Add("text", Me.BS, "TBNK24", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CoUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Auditor("Deposits", "USERNAME", "TBNK1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber1)
            FILLCOMBOBOX1("Deposits", "TBNK6", "CUser", CUser, Me.ComboAccountNumber)
            FILLCOMBOBOXDISTINCT("AllCustomers", "cust2", "IDcust", "CUser", CUser, Me.ComboMembersCode)

            Me.SumAmounBALANCE()
            Me.RecordCount()
            Me.ComboMembersCode.Text = ""
            Me.BUTTONCANCEL.Enabled = True
            Me.ComboMembersCode.Enabled = False
            Call MangUsers()

            TestkeyAccounts(keyAccounts.GetValue("StockAccount_No", StockAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("StockAccount_No", StockAccount_No)
            End If
            SetUpComboBox(ComboAccountType)
            GetNoRecord("ACCOUNTSTREE", "Account_No", "Account_Name", ComboAccountType.Text, 1)
            AccountNoAktevd = ID_Nam

            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If
            Me.LabelLoadData.Visible = False
            Me.PictureBox5.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Consum.Close()
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update Deposits SET  TBNK2 = @TBNK2, TBNK3 = @TBNK3, TBNK4 = @TBNK4, TBNK5 = @TBNK5, TBNK6 = @TBNK6, TBNK7 = @TBNK7, TBNK8 = @TBNK8, TBNK9 = @TBNK9, TBNK10 = @TBNK10, TBNK11 = @TBNK11, TBNK12 = @TBNK12, TBNK13 = @TBNK13, TBNK14 = @TBNK14, TBNK15 = @TBNK15, TBNK16 = @TBNK16, TBNK17 = @TBNK17, TBNK18 = @TBNK18, TBNK19 = @TBNK19, TBNK20 = @TBNK20, TBNK21 = @TBNK21, TBNK22 = @TBNK22, TBNK23 = @TBNK23, TBNK24 = @TBNK24, CB1 = @CB1, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE TBNK1 = @TBNK1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@TBNK1", SqlDbType.BigInt).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@TBNK2", SqlDbType.Money).Value = Val(Me.TEXTPreviousBalance.Text)
                .Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.TEXTReleaseDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@TBNK4", SqlDbType.Money).Value = Val(Me.TEXTReturnRatio.EditValue)
                .Parameters.Add("@TBNK5", SqlDbType.Money).Value = Val(Me.TextCertificateAmount.EditValue)
                .Parameters.Add("@TBNK6", SqlDbType.BigInt).Value = Val(Me.ComboAccountNumber.Text)
                .Parameters.Add("@TBNK7", SqlDbType.Money).Value = Val(Me.TEXTReturnValue.Text)
                .Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboDistributionRate.Text
                .Parameters.Add("@TBNK9", SqlDbType.Date).Value = Me.TEXTEndCertificate.Value.ToString
                .Parameters.Add("@TBNK10", SqlDbType.Date).Value = Me.TEXTCurrentBatch.Value.ToString
                .Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@TBNK12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckOpeningBalance.Checked)
                .Parameters.Add("@TBNK13", SqlDbType.Money).Value = Val(Me.TextNumberPayments.Text)
                .Parameters.Add("@TBNK14", SqlDbType.Money).Value = Val(Me.TextPaymentValue.Text)
                .Parameters.Add("@TBNK15", SqlDbType.Money).Value = Val(Me.TextResidualYield.Text)
                .Parameters.Add("@TBNK16", SqlDbType.Money).Value = Val(Me.TextRemainingPayments.Text)
                .Parameters.Add("@TBNK17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@TBNK19", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                .Parameters.Add("@TBNK20", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                .Parameters.Add("@TBNK21", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                .Parameters.Add("@TBNK22", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@TBNK24", SqlDbType.NVarChar).Value = Me.TEXTDuration.EditValue
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
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
            MessageBox.Show(ex.Message, "ErrorUPDATERECORD", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "Deposits")
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
            Me.BS.DataSource = myds.Tables("Deposits")
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
            Me.Count()
            If Me.DelRow = False Then
                If Me.BS.Count < RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS.Count > RowCount Then
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
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If Me.DelRow = True Then
                Me.ButtonXP5_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("Deposits")
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
            Dim Sound As System.IO.Stream = My.Resources.save
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
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى الحركات الدائنة والمدينة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل الى الحركات الدائنة والمدينة ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل الى الحركات الدائنة والمدينة ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
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
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonXP2.Enabled = LockUpdate
        Me.ButtonAttachDocument.Enabled = LockAddRow

    End Sub
    Private Sub SumAmounBALANCE()
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT Sum(TBNK2 + TBNK15)  FROM Deposits WHERE CUser='" & CUser & "'", Consum)
        Dim ds1 As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds1.Clear()
        Consum.Open()
        Adp.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotal.Text = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXTTotal.Text = 0
        End If
        Adp.Dispose()
        Consum.Close()
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
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        'If Year(Me.TEXTBOX3.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
        '    MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
        '    Exit Sub
        'End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        'Dim x As Double = Val(Me.TextBox29.Text) + Val(Me.TEXTBOX2.Text)
        'If Me.TEXT3.Text = "الاسهم" And Val(x) > Val(BANSL) Then
        '    MessageBox.Show("لا يمكن ان تكون قيمة اسهم العضو اكبر من قيمة اسهم الجمعة المكتتبة:" & ControlChars.CrLf & _
        '                   "1) اسهم الجمعة المكتتبة = " & "(" & Val(BANSL) & ")" & " " & "دينار اردني" & ControlChars.CrLf & _
        '                   "2) يمكن ان تغير نوع الحساب ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    Exit Sub
        'End If
        'Exit Sub

        Static P As Integer
        P = Me.BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTReferenceName.Text = CUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.UPDATERECORD()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Me.SHOWBUTTON()
        Click2 = True
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        BS.CancelEdit()
        RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن حذف  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        MYDELETERECORD("Deposits", "TBNK1", Me.TEXTID, Me.BS, True)
        Me.BS.Position = P
        Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
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
        Dim rpt As New rptCertifacate
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
            MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.RadioButton1.Checked = True Then
            If Len(Me.ComboAccountNumber1.Text) = 0 Then
                MessageBox.Show("من فضلك ادخل رقم الشهادة  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboAccountNumber1.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM Deposits  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND TBNK6 like '" & Me.ComboAccountNumber1.Text & "'", Consum)
            Dim builder12 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Deposits")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("TEXT42")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("TEXT23")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT43")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT48")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton2.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM Deposits  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder12 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            SqlDataAdapter1.Fill(ds, "Deposits")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("TEXT42")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("TEXT23")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT43")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT48")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton3.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM Deposits  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and TBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND TBNK17='" & False & "'", Consum)
            Dim builder12 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Deposits")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = rpt.Section1.ReportObjects("Text10")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("TEXT42")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("TEXT23")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT43")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT48")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
            Consum.Close()
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
        Try
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
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim N As Double
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(TBNK1) FROM Deposits", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()
            Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES1(Me.ComboAccountNumber.Text, Me.ComboAccountType.Text, N)), "0.000")
            Me.CheckLogReview.Checked = True
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.TEXTReferenceName.Text = CUser
            Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.TextDefinitionDirectorate.Text = COUser
            Me.ComboAccountNumber.Enabled = False
            Me.TEXTReleaseDate.Enabled = False
            Me.ComboAccountType.Enabled = False
            Me.TEXTPreviousBalance.Enabled = False
            Me.TextCertificateAmount.Enabled = False
            Me.TEXTReturnRatio.Enabled = False
            Me.TEXTDuration.Enabled = False
            Me.TEXTReturnValue.Enabled = False
            Me.ComboDistributionRate.Enabled = False
            Me.TEXTEndCertificate.Enabled = False
            Me.TEXTCurrentBatch.Enabled = False
            Me.ComboMembersCode.Enabled = False
            Me.RecordCount()
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
            Click7 = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Click8 = True
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
            For I = 1 To Me.BS.Count + 1
                If Me.BackWorker3.CancellationPending Then
                    e.Cancel = True
                    Return
                End If
                Me.BS.Position = I
                Me.BackWorker3.ReportProgress(I)
                'Me.InternalAuditorBalance()
                Me.UPDATERECORD()
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDoWorkBALANCE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
        On Error Resume Next
        Me.ProgressBar1.Value = e.ProgressPercentage
        Dim percent As Integer = CInt(CDbl(ProgressBar1.Value - ProgressBar1.Minimum) / CDbl(ProgressBar1.Maximum - ProgressBar1.Minimum) * 100)
        Using gr As Graphics = ProgressBar1.CreateGraphics()
            gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        End Using
    End Sub
    Private Sub BackWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker3.RunWorkerCompleted
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

    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
        On Error Resume Next
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        Me.ProgressBar1.Visible = True
        Me.PictureBox2.Visible = True
        Me.BackWorker3.RunWorkerAsync()
        If Not Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub
    Private Sub InternalAuditorBalance()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT  Sum(Deposits.TBNK2) AS SumDEBIT1 FROM Deposits  WHERE (Deposits.TBNK6)='" & Me.ComboAccountNumber.Text.Trim & "'AND (Deposits.TBNK19)='" & Me.ComboAccountType.Text.Trim & "'AND Deposits.TBNK1 <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds, "Deposits")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTPreviousBalance.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        ElseIf ds.Tables(0).Rows.Count = 0 Then
            Me.TEXTPreviousBalance.Text = "0"
        End If
        Me.TEXTEndCertificate.Text = Format(DateAdd(DateInterval.Year, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(Me.TEXTReleaseDate.Text)), "yyyy/MM/dd")
        Me.TextRemainingPayments.Text = DateDiff(DateInterval.Month, Convert.ToDateTime(Me.TEXTCurrentBatch.Text), Convert.ToDateTime(Me.TEXTEndCertificate.Text)) / Val(MYGROUPS(Me.ComboDistributionRate.Text))
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboAccountNumber1.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboAccountNumber1.Enabled = False
    End Sub
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub
    Private Sub ComboAccountNumber_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboAccountNumber.SelectedIndexChanged
        Me.InternalAuditorBalance()
    End Sub
    Private Sub ComboAccountNumber_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboAccountNumber.SelectedValueChanged
        Me.InternalAuditorBalance()
    End Sub
    Private Sub TEXTBOX2_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTReturnValue.TextChanged, ComboAccountNumber.TextChanged, TEXTReleaseDate.ValueChanged, TextNumberPayments.TextChanged, TextPaymentValue.TextChanged, TextResidualYield.TextChanged, TEXTCurrentBatch.ValueChanged, ComboDistributionRate.TextChanged, TEXTReturnRatio.EditValueChanged, TEXTDuration.EditValueChanged
        On Error Resume Next
        Me.InternalAuditorBalance()

        Me.TEXTReturnValue.Text = Format(Val((Val(Me.TEXTPreviousBalance.Text) + Val(Me.TextCertificateAmount.EditValue)) * Val(Me.TEXTReturnRatio.EditValue) / 100) * Val(Me.TEXTDuration.EditValue), "0.000")
        Me.TextNumberPayments.Text = Format(Val(Val(Me.TEXTDuration.EditValue) * 12) / Val(Me.MYGROUPS(Me.ComboDistributionRate.Text)), "0.000")
        Me.TextPaymentValue.Text = Format(Val(Me.TEXTReturnValue.Text) / Val(Me.TextNumberPayments.Text), "0.000")
        Me.TextResidualYield.Text = Format(Val(Me.TextRemainingPayments.Text) * Val(Me.TextPaymentValue.Text), "0.000")
        Me.TEXTEndCertificate.Text = Format(DateAdd(DateInterval.Year, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(Me.TEXTReleaseDate.Text)), "yyyy/MM/dd")
        Me.TEXTCurrentBatch.Text = Format(DateAdd(DateInterval.Month, Convert.ToDouble(Me.TEXTDuration.EditValue), Convert.ToDateTime(Me.TEXTReleaseDate.Text)), "yyyy/MM/dd")

        Me.TextRemainingPayments.Text = DateDiff(DateInterval.Month, Convert.ToDateTime(Me.TEXTCurrentBatch.Text), Convert.ToDateTime(Me.TEXTEndCertificate.Text)) / Val(Me.MYGROUPS(Me.ComboDistributionRate.Text))

        If Me.ComboDistributionRate.Text = "نصف سنوى تصاعدى" Then
            Select Case Val(Me.TextRemainingPayments.Text) / 2
                Case Is = 0
                    Me.TEXTReturnRatio.EditValue = 0.12
                Case Is <= 1
                    Me.TEXTReturnRatio.EditValue = 0.1125
                Case Is <= 2
                    Me.TEXTReturnRatio.EditValue = 0.1075
                Case Is <= 3
                    Me.TEXTReturnRatio.EditValue = 0.105
                Case Is <= 4
                    Me.TEXTReturnRatio.EditValue = 0.10375
                Case Is <= 5
                    Me.TEXTReturnRatio.EditValue = 0.1025
                Case Is <= 6
                    Me.TEXTReturnRatio.EditValue = 0.10125
                Case Is <= 7
                    Me.TEXTReturnRatio.EditValue = 0.1
                Case Is <= 8
                    Me.TEXTReturnRatio.EditValue = 0.9875
                Case Is <= 9
                    Me.TEXTReturnRatio.EditValue = 0.0975
            End Select
        End If
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
    Private Function MYGROUPS(ByVal str As String) As Double
        On Error Resume Next
        Select Case str
            Case "شهرى"
                MYGROUPS = 1
            Case "ريع سنوى"
                MYGROUPS = 3
            Case "نصف سنوى"
                MYGROUPS = 6
            Case "نصف سنوى تصاعدى"
                MYGROUPS = 6
            Case "سنوى"
                MYGROUPS = 12
        End Select
    End Function
    Private Shared Function FEXISTS(ByVal s1 As String, ByVal s2 As String, ByVal s3 As String, ByVal s4 As String) As Boolean
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Try
            Dim strsq1 As New SqlCommand("SELECT TBNK9,TBNK3,TBNK11,TBNK10 FROM PTRANSACTION WHERE TBNK6 ='" & s1 & "'" & "AND  TBNK9='" & s2 & "'" & "AND  TBNK8='" & s3 & "'" & "AND  TBNK11='" & s4 & "'", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlClient.SqlDataAdapter(strsq1)
            ds1.Clear()
            Consum.Open()
            Adp1.Fill(ds1)
            Adp1.Dispose()
            If ds1.Tables(0).Rows.Count > 0 Then
                FEXISTS = True
            Else
                FEXISTS = False
            End If
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
        Return FEXISTS
    End Function
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
    Private Sub ButtonTRANSFER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            'Dim x As Double = Val(Me.TextBox29.Text) + Val(Me.TEXTBOX2.Text)
            'If Me.TEXT3.Text = "الاسهم" And Val(x) > Val(BANSL) Then
            '    MessageBox.Show("لا يمكن ان تكون قيمة اسهم العضو اكبر من قيمة اسهم الجمعة المكتتبة:" & ControlChars.CrLf & _
            '                   "1) اسهم الجمعة المكتتبة = " & "(" & Val(BANSL) & ")" & " " & "دينار اردني" & ControlChars.CrLf & _
            '                   "2) يمكن ان تغير نوع الحساب ", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Exit Sub
            'End If
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

            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            Static P As Integer
            If Me.CheckTransferAccounts.Checked = False Then
                resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى الحركات الدائنة والمدينة ", "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferAccounts.Checked = True
                    Me.INSERTPTRANSACTION()
                    TransforAccounts()
                    Click4 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextFundMovementNumber.Text = Nothing Then
                        MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                    Else
                        Me.DELETEDATAempsolf()
                    End If
                    If FEXISTS(Me.ComboAccountNumber.Text, Me.TEXTDocumentNumber.Text, Me.ComboAccountType.Text, Me.TextMovementSymbol.EditValue) = True Then
                        Me.UPDATPTRANSACTION()
                    Else
                        Me.DELETEDATACUSTOMER1()
                        Me.INSERTPTRANSACTION()
                    End If
                    If Me.TextMovementRestrictions.Text = Nothing Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    TransforAccounts()
                    Click5 = True
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الحركات الدائنة والمدينة", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts.Checked = False
                        Me.DELETEDATACUSTOMER1()
                        Me.DELETEDATAempsolf()
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                        Click6 = True
                    Else
                        Exit Sub
                    End If
                End If
            End If
            P = BS.Position
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.TEXTReferenceName.Text = CUser
            Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.TextDefinitionDirectorate.Text = COUser
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
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATACUSTOMER1()
        Dim s2 As Date = Me.TEXTCurrentBatch.Text
        Dim s3 As String = Me.TEXTID.EditValue
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "DELETE FROM PTRANSACTION  WHERE TBNK6 ='" & Me.ComboAccountNumber.Text & "'" & "AND  TBNK9='" & s3 & "'" & "AND  year(TBNK3)='" & s2.Year & "'" & "AND  month(TBNK3)='" & s2.Month & "'" & "AND  day(TBNK3)='" & s2.Day & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub

    Private Sub INSERTPTRANSACTION()

        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim N As Int64
            GetAutoNumber("TBNK1", "PTRANSACTION", "TBNK3")
            N = AutoNumber


            Dim SQL As String = "INSERT INTO PTRANSACTION( TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK22, TBNK23, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK22, @TBNK23, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With cmd
                cmd.CommandType = CommandType.Text
                cmd.Connection = Consum
                cmd.Parameters.Add("@TBNK1", SqlDbType.BigInt).Value = N
                cmd.Parameters.Add("@TBNK2", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(CType(ComboAccountNumber.Text, Integer), ComboAccountType.Text, N)), "0.000")
                cmd.Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.TEXTReleaseDate.Value.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@TBNK4", SqlDbType.NVarChar).Value = 0
                'If OBCHK1 = False Then
                cmd.Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TextCertificateAmount.EditValue
                'Else
                '    cmd.Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text.Trim
                'End If
                cmd.Parameters.Add("@TBNK6", SqlDbType.NVarChar).Value = Me.ComboAccountNumber.Text
                cmd.Parameters.Add("@TBNK7", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(CType(ComboAccountNumber.Text, Integer), Me.ComboAccountType.Text, N)), "0.000")
                cmd.Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                cmd.Parameters.Add("@TBNK9", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                cmd.Parameters.Add("@TBNK10", SqlDbType.NVarChar).Value = Me.ComboDistributionRate.Text
                cmd.Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                cmd.Parameters.Add("@TBNK12", SqlDbType.NVarChar).Value = False
                cmd.Parameters.Add("@TBNK13", SqlDbType.NVarChar).Value = False
                cmd.Parameters.Add("@TBNK14", SqlDbType.NVarChar).Value = "نقدا"
                cmd.Parameters.Add("@TBNK15", SqlDbType.NVarChar).Value = 0.000
                cmd.Parameters.Add("@TBNK16", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                cmd.Parameters.Add("@TBNK17", SqlDbType.NVarChar).Value = True
                cmd.Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = "ايداع"
                cmd.Parameters.Add("@TBNK22", SqlDbType.NVarChar).Value = Me.TextMembersName.Text
                cmd.Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                cmd.Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                cmd.Parameters.Add("@BN2", SqlDbType.NVarChar).Value = 0

                cmd.Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                cmd.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                cmd.Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                cmd.Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                cmd.Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                cmd.Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                cmd.CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorINSERTPTRANSACTION", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Function SumAmounTOTALCASHANDCHEQUES(ByVal cust As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Adp2 As SqlClient.SqlDataAdapter
        Dim Adp3 As SqlClient.SqlDataAdapter
        Dim SUM1, SUM2, SUM3 As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(TBNK4-TBNK5)  FROM PTRANSACTION WHERE TBNK6 = '" & cust & "'AND PTRANSACTION.TBNK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALCASHANDCHEQUES = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALCASHANDCHEQUES = "0"
        End If
        Consum.Close()
    End Function
    Public Function SumAmounTOTALCASHANDCHEQUES1(ByVal cust As String, ByVal TYB As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(TBNK5-TBNK4)  FROM PTRANSACTION WHERE TBNK6 = '" & cust & "'AND PTRANSACTION.TBNK8 ='" & TYB & "'AND PTRANSACTION.TBNK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALCASHANDCHEQUES1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALCASHANDCHEQUES1 = "0"
        End If
        Consum.Close()
    End Function
    Private Sub UPDATPTRANSACTION()

        Try
            Dim N As Double
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(TBNK1) FROM PTRANSACTION", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer)
            End If
            Consum.Close()
            Dim S1 As String = Me.ComboAccountNumber.Text
            Dim S2 As Date = Me.TEXTReleaseDate.Text
            Dim S3 As String = Me.TEXTDocumentNumber.Text
            Dim SQL As New SqlCommand(" Update PTRANSACTION SET  TBNK2 = @TBNK2, TBNK3 = @TBNK3, TBNK4 = @TBNK4, TBNK5 = @TBNK5, TBNK6 = @TBNK6, TBNK7 = @TBNK7, TBNK8 = @TBNK8, TBNK9 = @TBNK9, TBNK10 = @TBNK10, TBNK11 = @TBNK11, TBNK12 = @TBNK12, TBNK13 = @TBNK13, TBNK14 = @TBNK14, TBNK15 = @TBNK15, TBNK16 = @TBNK16, TBNK17 = @TBNK17, TBNK18 = @TBNK18, TBNK22 = @TBNK22, TBNK23 = @TBNK23, CB1 = @CB1, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE TBNK6 ='" & S1 & "'" & "AND  TBNK9='" & S3 & "'" & "AND  year(TBNK3)='" & S2.Year & "'" & "AND  month(TBNK3)='" & S2.Month & "'" & "AND  day(TBNK3)='" & S2.Day & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@TBNK1", SqlDbType.Int).Value = N
                .Parameters.Add("@TBNK2", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(Me.ComboAccountNumber.Text, Me.ComboAccountType.Text, N)), "0.000")
                .Parameters.Add("@TBNK3", SqlDbType.Date).Value = Me.TEXTReleaseDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@TBNK4", SqlDbType.NVarChar).Value = 0
                .Parameters.Add("@TBNK5", SqlDbType.NVarChar).Value = Me.TextCertificateAmount.EditValue
                .Parameters.Add("@TBNK6", SqlDbType.Int).Value = Me.ComboAccountNumber.Text
                .Parameters.Add("@TBNK7", SqlDbType.NVarChar).Value = Format(Val(SumAmounTOTALCASHANDCHEQUES2(Me.ComboAccountNumber.Text, Me.ComboAccountType.Text, N)), "0.000")
                .Parameters.Add("@TBNK8", SqlDbType.NVarChar).Value = Me.ComboAccountType.Text
                .Parameters.Add("@TBNK9", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text.Trim
                .Parameters.Add("@TBNK10", SqlDbType.NVarChar).Value = Me.ComboDistributionRate.Text.Trim
                .Parameters.Add("@TBNK11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@TBNK12", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@TBNK13", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@TBNK14", SqlDbType.NVarChar).Value = "نقدا"
                .Parameters.Add("@TBNK15", SqlDbType.NVarChar).Value = "0.00"
                .Parameters.Add("@TBNK16", SqlDbType.NVarChar).Value = "0.00"
                .Parameters.Add("@TBNK17", SqlDbType.NVarChar).Value = True
                .Parameters.Add("@TBNK18", SqlDbType.NVarChar).Value = "ايداع"
                .Parameters.Add("@TBNK22", SqlDbType.NVarChar).Value = Me.TextMembersName.Text.Trim
                .Parameters.Add("@TBNK23", SqlDbType.NVarChar).Value = Me.TextMembersCode.EditValue
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text.Trim

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                .ExecuteNonQuery()
                Consum.Close()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub TextBox20_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextGoTo.TextChanged
        Try
            If Me.TextGoTo.TextLength > 0 Then
                Dim index As Integer
                index = Me.BS.Find("TBNK1", Me.TextGoTo.Text.Trim)
                Me.BS.Position = index
                RecordCount()
            Else
                Me.BS.Position = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = "تسجيل حساب" & " " & Me.ComboAccountType.Text
        nem1 = "استلام نقدي من حساب" & " " & Me.ComboAccountType.Text
        PMO2 = 1

        GetNoRecord("ACCOUNTSTREE", "Account_No", "Account_Name", ComboAccountType.Text, 1)
        CredAccount_NO = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", CredAccount_NO, 1)
        CredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", CredAccount_NO, 1)
        CredAccount_Cod = ID_Nam

        GetNoRecord("ACCOUNTSTREE", "account_no", "Account_Name", ModuleGeneral.CB2, 1)
        FundAccount_No = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
        FundAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MaxIDMoves()
        TransferToAccounts_Check = True
        Dim DocumentTapy As String
        If OBCHK1 = False Then
            DocumentTapy = "قبض"
        Else
            DocumentTapy = "قيد"
        End If
        AccountingEntries(T1, T2, TEXTReleaseDate.Value.ToString("yyyy-MM-dd"), nem, False, TextCertificateAmount.EditValue, TextCertificateAmount.EditValue, T3, DocumentTapy, "SD", TextMovementSymbol.EditValue, False)

        If OBCHK1 = False Then
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, FundAccount_No, TextCertificateAmount.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        Else
            GetNoRecord("ACCOUNTSTREE", "Account_No", "Account_Name", ComboDebitAccount.Text, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, FundAccount_No, TextCertificateAmount.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        End If
        DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, CredAccount_NO, 0, TextCertificateAmount.EditValue, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        If OBCHK1 = False Then
            Insert_CASHIER(TEXTReleaseDate.Value.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextCertificateAmount.Text, 0, Me.Text,
               nem1, False, TEXTID.EditValue,
               False, True, ComboCB1.Text, ModuleGeneral.CB2)
        End If

    End Sub

    Private Sub ComboConstraintType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboAccountType.SelectedIndexChanged
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        If ComboAccountType.Items.Count > 0 Then
            GetNoRecord("ACCOUNTSTREE", "Account_No", "Account_Name", ComboAccountType.Text, 1)
            CredAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "Account_Name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam
        End If
        ComboDebitAccount.Text = FundAccount_Name
        NUpComboDebitAccount.Value = CodAccount
        LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
        TextCreditAccount.Text = CredAccount_Name
        NUpCreditAccount.Value = CredAccount_Cod
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

    Private Sub DELETEDATMOVESDATA()
        Try
            ModuleGeneral.MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA1()
        Try
            ModuleGeneral.MYDELETERECORD("MOVESDATA", "MOV2", MOVESFalseDELET, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT Account_No,ACC,Account_Name,ACC1 FROM ACCOUNTSTREE WHERE Account_Name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
        ds2.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.Account_NoF = ds2.Tables(0).Rows(0).Item(0)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(2)
            Me.Account_NameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.Account_NoF = ""
            Me.ACCF = ""
            Me.Account_NameF = ""
        End If

        AutoEx()

    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.Text & " " & ":" & " " & Me.TEXTID.EditValue & " " & "بتاريخ" & " " & ":" & " " & Me.TEXTReleaseDate.Text & " "
        ExResult += "للعضو " & " " & ":" & " " & Me.TextMembersName.Text & " " & "مثبتة بوثيقة رقم" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            ModuleGeneral.MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboMembersCode.SelectedIndexChanged
        Dim Str1 As String = Me.ComboMembersCode.Text
        Dim strArr() As String
        Dim a As String
        strArr = Str1.Split("-")
        a = strArr(0)
        If Me.ComboMembersCode.Text.Length > 0 Then
            Me.TextMembersName.Text = strArr(1)
            Me.TextMembersCode.EditValue = strArr(0)
            Me.ComboMembersCode.Enabled = False
        Else
            Me.TextMembersName.Text = ""
            Me.TextMembersCode.EditValue = ""
        End If
    End Sub
    Private Sub PB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
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
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "Account_Name"
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "Account_Name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpCreditAccount.Value)
            Me.List1.DisplayMember = "Account_Name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "Account_Name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
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
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click
        Try
            Me.ComboMembersCode.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.MaxIDMoves()
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.Account_NoF = SEARCHDATA.Account_No
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.Account_Name = SEARCHDATA.Account_Name

        Me.TextMovementRestrictions.Text = Nothing
        Me.TextFundMovementNumber.Text = Nothing
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = Conversion.Val(SEARCHDATA.MOV1C)
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)


        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHCASHIER1(Trim(Me.TextMovementSymbol.EditValue), Trim(Me.TEXTID.EditValue))
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B.ToString.Trim
    End Sub
    Private Sub FrmDeposits_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
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
            f.DateP1.Text = Me.TEXTReleaseDate.Value.ToString("yyyy-MM-dd")
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
                Dim DOC1 As String = Trim(ds41.Tables(0).Rows(0).Item(0))
                Dim LO As String = Trim(ds41.Tables(0).Rows(0).Item(1))
                index = f.BS.Find("DOC1", DOC1)
                f.Show()
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
        ComboConstraintType_SelectedIndexChanged(sender, e)
        'GetFundAccount_No(Module1.CB2)
        'GetUpAccounts("نقدا", AccountNoAktevd)
        'LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
        FundBalance()
    End Sub

    Private Sub FundBalance()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub


End Class