Option Explicit Off

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmEmpsolf
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim nem As String
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Dim CHK As Boolean = False
    Dim DocumentNumber As String
    Dim TestAccountNoAktevd_Check As Boolean = False



    Private Sub Frmempsolf_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub Frmempsolf_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
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
                    Case Keys.K And (e.Alt And Not e.Control And Not e.Shift)
                        Me.Buttoncalcluter_Click(sender, e)
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

    Private Sub Frmempsolf_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
    End Sub

    Private Sub Frmempsolf_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonUpdateA.Enabled = False

        Me.ButtonTransferToCashMovements.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False

        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False

        Me.BackWorker3.WorkerReportsProgress = True
        Me.BackWorker3.WorkerSupportsCancellation = True

        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If

        Me.CHK = False
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

    Private Sub DISPLAYRECORD()
        Try
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If
            With Me
                .TEXTID.EditValue = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH1").ToString
                .TextDateMovementHistory.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH2").ToString
                .ComboConstraintType.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH3").ToString
                .TEXTDocumentNumber.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH4").ToString
                .ComboPaymentMethod.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH5").ToString
                .TEXTPreviousBalance.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH6").ToString
                .TEXTDebit.EditValue = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH7").ToString
                .TEXTCredit.EditValue = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH8").ToString
                .TEXTCurrentBalance.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH9").ToString
                .ComboMotionSource.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH10").ToString
                .ComboNotes.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH11").ToString
                .TEXTStatement.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH12").ToString
                .CheckTransferAccounts.Checked = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH13").ToString
                .ComboStaffMovement.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH14").ToString
                .TextStaffNumber.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH15").ToString
                .CheckLogReview.Checked = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH16").ToString
                .TextMovementSymbol.EditValue = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH17").ToString
                .CheckCarryCash.Checked = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("CSH18").ToString
                .TEXTUserName.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("USERNAME").ToString
                .TEXTReferenceName.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("Auditor").ToString
                .TextDefinitionDirectorate.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("COUser").ToString
                .TEXTAddDate.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("da").ToString
                .TextTimeAdd.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("ne").ToString
                .TEXTReviewDate.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("da1").ToString
                .TextreviewTime.Text = Me.myds.Tables("EMPSOLF").Rows(Me.BS.Position).Item("ne1").ToString
                Me.TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
                AutoEx()
                Auditor("EMPSOLF", "USERNAME", "CSH1", Me.TEXTID.EditValue, "")
                Logentry = Uses
                FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement)
                FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement1)
                'FILLCOMBOBOX1("BANKJO", "EBNK10", "CUser", CUser, Me.ComboBox8)
                'Me.ComboCB1_SelectedIndexChanged(sender, e)
                'Me.ComboBN2_SelectedIndexChanged(sender, e)

                FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpComboDebitAccount.Value, Me.ComboDebitAccount)
                FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpCreditAccount.Value, Me.List1)
                RecordCount()
                Me.BUTTONCANCEL.Enabled = True
                Call MangUsers()
                Label6.Visible = False
            End With
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Hand)
        End Try
        Consum.Close()
    End Sub

    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboStaffMovement, e, )
    End Sub

    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboDebitAccount, e, )
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferToCashMovements.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboMotionSource.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboNotes.Enabled = False
            Me.ComboStaffMovement.Enabled = False
            Me.PanelAccount.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonTransferToCashMovements.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboMotionSource.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboNotes.Enabled = False
            Me.ComboStaffMovement.Enabled = False
            'If Me.TextBox7.Text = "PS" Then
            '    Me.Panel7.Enabled = True
            'Else
            '    Me.Panel7.Enabled = False
            'End If
            If Me.CHK = True Then
                Me.DateMovementHistory.Enabled = True
                Me.ComboConstraintType.Enabled = True
                Me.ComboPaymentMethod.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.ComboMotionSource.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.ComboNotes.Enabled = True
                Me.ComboStaffMovement.Enabled = True
                Me.PanelAccount.Enabled = True
            End If
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferToCashMovements.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.TEXTID.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboMotionSource.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboNotes.Enabled = False
            Me.ComboStaffMovement.Enabled = False
            'If Me.TextBox7.Text = "PS" Then
            '    Me.Panel7.Enabled = True
            'Else
            '    Me.Panel7.Enabled = False
            'End If
        Else
            Me.SHOWBUTTON()
            Me.DateMovementHistory.Enabled = True
            Me.ComboConstraintType.Enabled = True
            Me.ComboPaymentMethod.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.ComboMotionSource.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.ComboNotes.Enabled = True
            Me.ComboStaffMovement.Enabled = True
            Me.PanelAccount.Enabled = True
        End If

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

    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = String.Concat(New String() {"SELECT   CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH13, CSH14, CSH15, CSH16, CSH17, CSH18, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1  FROM EMPSOLF  WHERE  CUser='", ModuleGeneral.CUser, "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH1 ='", Strings.Trim(Me.TB1), "' or CSH14 ='", Strings.Trim(Me.TB2), "' or CSH15 ='", Strings.Trim(Me.TB3), "'ORDER BY CSH1"})
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "EMPSOLF")
                Me.SqlDataAdapter1.Fill(myds, "EMPSOLF")
                Consum.Close()
                Me.myds.RejectChanges()
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
        Me.load1.Enabled = False
    End Sub

    Private Sub BackWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker2.ProgressChanged
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
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
            Me.BS.DataSource = Me.myds.Tables("EMPSOLF")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "CSH1", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CSH2", True, 1, "")
            Me.ComboConstraintType.DataBindings.Add("text", Me.BS, "CSH3", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CSH4", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CSH5", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CSH6", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CSH7", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CSH8", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CSH9", True, 1, "")
            Me.ComboMotionSource.DataBindings.Add("text", Me.BS, "CSH10", True, 1, "")
            Me.ComboNotes.DataBindings.Add("text", Me.BS, "CSH11", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CSH12", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "CSH13", True, 1, "")
            Me.ComboStaffMovement.DataBindings.Add("text", Me.BS, "CSH14", True, 1, "")
            Me.TextStaffNumber.DataBindings.Add("text", Me.BS, "CSH15", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CSH16", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CSH17", True, 1, "")
            Me.CheckCarryCash.DataBindings.Add("Checked", Me.BS, "CSH18", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")
            Me.ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CoUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Me.TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            Me.AutoEx()
            Auditor("EMPSOLF", "USERNAME", "CSH1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement)
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement1)
            'FILLCOMBOBOX1("BANKJO", "EBNK10", "CUser", CUser, Me.ComboBox8)


            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.List1)
            Me.RecordCount()


            Me.BUTTONCANCEL.Enabled = True
            Call MangUsers()
            Consum.Close()
            Label6.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub

    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:

            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT   CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH13, CSH14, CSH15, CSH16, CSH17, CSH18, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1  FROM EMPSOLF  WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1"
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "EMPSOLF")
                Me.SqlDataAdapter1.Fill(myds, "EMPSOLF")
                Me.myds.RejectChanges()
                Consum.Close()
            End With

            'Auditor("EMPSOLF", "USERNAME", "CSH1", Me.TEXT1.Text, "")
            'Logentry = Uses
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorDoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.Label6.Visible = True
                Me.Label6.ForeColor = Color.Yellow
                Me.Label6.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
            Else
                Me.Label6.ForeColor = Color.Red
                Me.Label6.Text = "الاتصال بالانترنت غير متوفر"
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
            Me.BS.DataSource = Me.myds.Tables("EMPSOLF")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "CSH1", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CSH2", True, 1, "")
            Me.ComboConstraintType.DataBindings.Add("text", Me.BS, "CSH3", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CSH4", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CSH5", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CSH6", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CSH7", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CSH8", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CSH9", True, 1, "")
            Me.ComboMotionSource.DataBindings.Add("text", Me.BS, "CSH10", True, 1, "")
            Me.ComboNotes.DataBindings.Add("text", Me.BS, "CSH11", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CSH12", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "CSH13", True, 1, "")
            Me.ComboStaffMovement.DataBindings.Add("text", Me.BS, "CSH14", True, 1, "")
            Me.TextStaffNumber.DataBindings.Add("text", Me.BS, "CSH15", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CSH16", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CSH17", True, 1, "")
            Me.CheckCarryCash.DataBindings.Add("Checked", Me.BS, "CSH18", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")
            Me.ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "CoUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            Me.TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)
            Me.AutoEx()
            Auditor("EMPSOLF", "USERNAME", "CSH1", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement)
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboStaffMovement1)
            'FILLCOMBOBOX1("BANKJO", "EBNK10", "CUser", CUser, Me.ComboBox8)


            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.List1)
            Me.RecordCount()

            Call MangUsers()
            Consum.Close()
            Label6.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update EMPSOLF SET  CSH2 = @CSH2, CSH3 = @CSH3, CSH4 = @CSH4, CSH5 = @CSH5, CSH6 = @CSH6, CSH7 = @CSH7, CSH8 = @CSH8, CSH9 = @CSH9, CSH10 = @CSH10, CSH11 = @CSH11, CSH12 = @CSH12, CSH13 = @CSH13, CSH14 = @CSH14, CSH15 = @CSH15, CSH16 = @CSH16, CSH17 = @CSH17, CSH18 = @CSH18, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE CSH1 = @CSH1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSH1", SqlDbType.Int).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CSH2", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@CSH3", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@CSH4", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CSH5", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CSH6", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CSH7", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CSH8", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CSH9", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CSH10", SqlDbType.NVarChar).Value = Me.ComboMotionSource.Text
                .Parameters.Add("@CSH11", SqlDbType.NVarChar).Value = Me.ComboNotes.Text
                .Parameters.Add("@CSH12", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CSH13", SqlDbType.Bit).Value = Convert.ToInt32(CheckTransferAccounts.Checked)
                .Parameters.Add("@CSH14", SqlDbType.NVarChar).Value = Me.ComboStaffMovement.Text
                .Parameters.Add("@CSH15", SqlDbType.NVarChar).Value = Me.TextStaffNumber.Text
                .Parameters.Add("@CSH16", SqlDbType.Bit).Value = Convert.ToInt32(CheckLogReview.Checked)
                .Parameters.Add("@CSH17", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CSH18", SqlDbType.Bit).Value = Convert.ToInt32(CheckCarryCash.Checked)

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
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Public Sub Count()
        On Error Resume Next
        RECORDSLABEL.Text = BS.Position + 1 & " من " & BS.Count
    End Sub

    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            myds = New DataSet
            SqlDataAdapter1.Fill(myds, "EMPSOLF")
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = myds.Tables("EMPSOLF")
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
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                PictureBox2False()
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
            BS.DataSource = myds.Tables("EMPSOLF")
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
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الحركة الى القيود اليومية و الصندوق", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل الحركة الى القيود اليومية الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل الحركة الى القيود اليومية و الصندوق ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "ترحيل الحركة الى القيود اليومية و البنك", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل الحركة الى القيود اليومية البنك ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click12 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل الحركة الى القيود اليومية البنك ", Me.Text)
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
            Me.ComboStaffMovement.Focus()
            Me.ComboStaffMovement.SelectAll()
        End If
    End Sub

    Private Sub TEXT4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub

    Private Sub TEXT5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub

    Private Sub TEXT3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTCurrentBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")

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
        If Me.BS.Position < Me.myds.Tables("EMPSOLF").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmounJOBALANCE()
        Me.AutoEx()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.TextLSet.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.TextDateMovementHistory.Text = CDate(Me.TextDateMovementHistory.Text).ToShortDateString
        Me.DateMovementHistory.Value = Me.TextDateMovementHistory.Text
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        AccountsEnquiry()
        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
        Me.BUTTONCANCEL.Enabled = True
    End Sub

    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub

    Private Sub SumAmounJOBALANCE()
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CSH7 - CSH8)  FROM EMPSOLF WHERE CUser='" & CUser & "' ", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ButtonTransferToCashMovements.Enabled = TransferofAccounts
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonUpdateA.Enabled = True
        Me.ButtonAttachDocument.Enabled = LockAddRow
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
            F = Val(TEXTCurrentBalance.Text)
            Me.BS.Position = Me.BS.Position + 1
            Me.TEXTPreviousBalance.Text = F
        End If
    End Sub

    Private Sub ComboConstraintType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
        Select Case Trim(Me.ComboConstraintType.Text)
            Case "ايداع"
                Me.TEXTCredit.Enabled = False
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.EditValue = "0.00"
            Case "سحب"
                Me.TEXTCredit.Enabled = True
                Me.TEXTDebit.Enabled = False
                Me.TEXTDebit.EditValue = "0.00"
        End Select
    End Sub

    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTDocumentNumber.KeyDown, TEXTPreviousBalance.KeyDown, TEXTCurrentBalance.KeyDown, ComboConstraintType.KeyDown, ComboPaymentMethod.KeyDown, DateMovementHistory.KeyDown
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

    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
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
        If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
            MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTCurrentBalance.Text = Format(Val(TEXTPreviousBalance.Text) + Val(TEXTDebit.EditValue) - Val(TEXTCredit.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
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
        Me.BS.Position = P
        Click2 = True
    End Sub

    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub

    Private Sub BackWorker3_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles BackWorker3.DoWork
        Dim I As Integer
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        For I = 0 To BS.Count + 1
            If Me.BackWorker3.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Me.BackWorker3.ReportProgress(I)
            System.Threading.Thread.Sleep(1)
        Next
    End Sub

    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
        On Error Resume Next
        Me.Label13.Text = e.ProgressPercentage.ToString
        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.PictureBox2.Visible = True
        Me.InternalAuditorBalance()
        Me.UPDATERECORD()
    End Sub

    Private Sub BackWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackWorker3.RunWorkerCompleted
        If e.Cancelled Then
            Me.Label13.Text = 0
            Me.BackWorker3.CancelAsync()
            Me.ProgressBar1.Visible = False
            Me.PictureBox2.Visible = False
        ElseIf e.Error IsNot Nothing Then
            Me.Label13.Text = "Error111: " & e.Error.Message
        Else
            Me.BackWorker3.CancelAsync()
            Me.Label13.Text = 0
            Me.ProgressBar1.Visible = False
            Me.PictureBox2.Visible = False
            Me.PictureBox2.Visible = False
            Me.SaveTab = New BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = 0
            Me.ProgressBar1.Visible = False
            Me.PictureBox2.Visible = False
            ModuleGeneral.Click3 = True
        End If
    End Sub

    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
        'Dim I As Integer
        On Error Resume Next
        'If TestNet = False Then
        '    MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
        '    Exit Sub
        'End If
        'If BS.Count = 0 Then Beep() : Exit Sub
        'If LockUpdate = False Then
        '    MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة الارصدة من البرنامج", 16, "تنبيه")
        '    Exit Sub
        'End If
        'Me.Cursor = Cursors.WaitCursor
        'For I = 0 To BS.Count + 1
        '    BS.Position = I
        '    ProgressBar1.Visible = True
        '    ProgressBar1.Minimum = 1
        '    ProgressBar1.Maximum = BS.Count - 1
        '    ProgressBar1.Value = I
        '    InternalAuditorBalance()
        '    UPDATERECORD()
        'Next
        'Me.Cursor = Cursors.WaitCursor
        'PictureBox2.Visible = True
        'BS.EndEdit()
        'RowCount = BS.Count
        'SaveTab = New System.ComponentModel.BackgroundWorker
        'SaveTab.WorkerReportsProgress = True
        'SaveTab.WorkerSupportsCancellation = True
        'SaveTab.RunWorkerAsync()
        'BS.Position = 0
        'ProgressBar1.Visible = False
        'PictureBox2.Visible = False
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        If Not Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
        'Consum.Close()
    End Sub

    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim f As New FrmPRINT
        Dim ds1 As New DataSet
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim txt As TextObject
        Dim txt1 As TextObject
        txtFROMDate = Format(Me.DateFrom.Value, "yyyy/MM/dd")
        txtToDate = Format(Me.DateTO.Value, "yyyy/MM/dd")
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        If Me.RadioButton1.Checked = True Then
            Dim rpt As New rptBanks21
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM EMPSOLF  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN'" & txtFROMDate & "'AND'" & txtToDate & "'AND" & " CSH14='" & Me.ComboStaffMovement1.Text & "'ORDER BY CSH1", Consum)
            Dim builder23 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPSOLF")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text8")
            txt1 = rpt.Section1.ReportObjects("Text13")
            txt.Text = "  خلال الفترة من  " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & "  الى  " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt1.Text = "اسم الموظف  " & "  :  " & ComboStaffMovement1.Text

            txt = rpt.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton2.Checked = True Then
            Dim rpt1 As New rptBanks21
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM EMPSOLF  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  CSH2 BETWEEN'" & txtFROMDate & "'AND'" & txtToDate & "'ORDER BY CSH1", Consum)
            Dim builder23 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPSOLF")
            rpt1.SetDataSource(ds)
            txt = rpt1.Section1.ReportObjects("Text8")
            txt.Text = "خلال الفترة من  " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt1.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt1.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt1.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt1.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt1.Section1.ReportObjects("Text44")
            txt.Text = Recorded

            f.CrystalReportViewer1.ReportSource = rpt1
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton3.Checked = True Then
            Dim rpt1 As New rptBanks21
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM EMPSOLF  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  CSH2 BETWEEN'" & txtFROMDate & "'AND'" & txtToDate & "'AND" & " CSH16='" & False & "'ORDER BY CSH1", Consum)
            Dim builder23 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPSOLF")
            rpt1.SetDataSource(ds)
            txt = rpt1.Section1.ReportObjects("Text8")
            txt.Text = "خلال الفترة من  " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt1.Section1.ReportObjects("Text12")
            txt.Text = AssociationName
            txt = rpt1.Section1.ReportObjects("Text15")
            txt.Text = Directorate
            txt = rpt1.Section1.ReportObjects("Text14")
            txt.Text = Character
            txt = rpt1.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt1.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt1
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
            Consum.Close()
        End If
    End Sub

    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
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
        Me.RecordCount()
        Me.InternalAuditorType()
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
        Click13 = True
    End Sub

    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
            If Me.CheckLogReview.Checked = False Then
                MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
                Exit Sub
            End If
            Static Dim P As Integer
            P = BS.Position
            Me.CheckLogReview.Checked = False
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
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
            Click14 = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن حذف  السجل الحالى لأنه مرحل ... يمكن حذف من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        Else
            Dim resault As Integer
            resault = MessageBox.Show("هل تريد حذف السجل الحالى من حركة الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                DELETEDATCASHIER()
                MYDELETERECORD("EMPSOLF", "CSH1", TEXTID, BS, True)
                Frmempsolf_Load(sender, e)
                Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
            Else
                Exit Sub
            End If
        End If
    End Sub


    Private Sub ComboStaffMovement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboStaffMovement.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboStaffMovement.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "EMPLOYEES")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextStaffNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextStaffNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        InternalAuditorBalance()
    End Sub



    Private Sub DELETEDATCASHIER()
        Try
            MYDELETERECORD("CASHIER", "CSH1", TextFundMovementNumber, BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATCASHIER1()
        Try
            MYDELETERECORD("CASHIER", "CSH1", TextFundMovementNumber1, BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub


    Private Sub DELETBANKJO()
        Try
            MYDELETERECORD("BANKJO", "EBNK1", TextBankTransactionNumber, BS, True)
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

    Private Sub DELETEMPSOLF()
        Try
            MYDELETERECORD("EMPSOLF", "CSH1", Me.TEXTID, Me.BS, True)
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

    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextLSet.Text.ToString <> "PS" Then
                MsgBox("عفوا .. لايمكن ترحيل  السجل الحالى لأنه مرحل", 16, "تنبيه")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If
            If TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            Me.Button1_Click(sender, e)

            Static P As Integer
            TestAccountNoAktevd_Check = True
            'If OBCHK4 = True Then

            'End If
            If Me.CheckTransferAccounts.Checked = False Then
                resault = MessageBox.Show("  سبنم ترحيل الحركة الحالى الى القيود اليومية " & "حساب " & Me.ComboStaffMovement1.Text, "ترحيل القيود", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferAccounts.Checked = True
                    TransforAccounts()
                    Click4 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل الحركة الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.ComboBox5_SelectedIndexChanged(sender, e)
                    If Me.TextMovementRestrictions.Text = "" Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    If Me.TextFundMovementNumber.Text = "" Then
                        MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                    Else
                        Me.DELETEDATCASHIER()
                    End If
                    TransforAccounts()
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
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER()
                        End If
                        Me.CheckTransferAccounts.Checked = False
                        Click6 = True
                    Else
                        Exit Sub
                    End If
                End If
            End If
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.UPDATERECORD()
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

    Private Sub SEARCHBANK()
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT EBNK6 FROM BANKJO WHERE EBNK13 = '" & Me.TextMovementSymbol.EditValue & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "BANKJO")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            DocumentNumber = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            DocumentNumber = "0"
        End If
        connection.Close()
    End Sub

    Private Sub ButtonTransferToCashMovements_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonTransferToCashMovements.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("عفوا .. يجب ترحيل اولا الى الحســـــــابات اولا ", 16, "تنبيه")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            Dim ch As Double
            Dim ch1 As Double
            Static P As Integer
            Consum.Close()
            Me.PanelAccount.Enabled = True
            Dim MECB1, MECB2, MEBN2, MEBN3 As String

            MECB1 = Me.ComboCB1.Text
            MEBN2 = Me.ComboBN2.Text
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Me.ComboBN2_SelectedIndexChanged(sender, e)
            MEBN3 = ModuleGeneral.BN3
            If Me.Radcsh.Checked = True Then
                If Me.CheckCarryCash.Checked = False Then
                    resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة الصندوق " & "للموظف " & Me.ComboStaffMovement.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Cash = True
                        CLEARDATA1(Me)
                        GetAutoNumber("CSH1", "EMPSOLF", "CSH2")
                        TEXTID.EditValue = AutoNumber
                        Me.TextMovementSymbol.EditValue = "PS" & Me.TEXTID.EditValue
                        Me.ComboCB1.Text = MECB1
                        MECB2 = ModuleGeneral.CB2
                        Me.TEXTDocumentNumber.Text = TEXTID.EditValue
                        Me.ComboNotes.Text = "الايداع في الصندوق"
                        Me.TEXTStatement.Text = "حركات عهد الموظفين"

                        Dim Frm As New mane
                        Frm.TEXTValues.Text = Format(Val(SumAmounTOTALBALANCEEMPSOLF(Me.TextStaffNumber.Text, TEXTID.EditValue)), "0.000")
                        Frm.TextPermissionNumber.Enabled = False
                        Frm.ShowDialog()

                        Me.TEXTCredit.EditValue = Val(Frm.TEXTValues.Text)
                        ch = Format(Val(SumAmounTOTALBALANCEEMPSOLF(Me.TextStaffNumber.Text, TEXTID.EditValue)), "0.000")
                        ch1 = Val(Me.TEXTCredit.EditValue)
                        If Val(ch) < Val(ch1) Then
                            MsgBox("انتبه رصبد العهدة لا يكفي لهذه الحركة", 16, "تنبيه")
                            Me.BUTTONCANCEL_Click(sender, e)
                            Exit Sub
                        End If
                        Insert_EMPSOLF("صرف", Me.TEXTID.EditValue, 0, Me.TEXTCredit.EditValue, Me.ComboMotionSource.Text, Me.TEXTStatement.Text, Me.CheckTransferAccounts.Checked, Me.ComboStaffMovement.Text, Me.TextStaffNumber.Text, Me.TextMovementSymbol.EditValue, True, Me.ComboCB1.Text, Me.ComboBN2.Text)
                        TransferToCashMovements()
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
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        Me.DELETEDATCASHIER1()
                        TransferToCashMovements()
                        Me.TEXTCurrentBalance.Text = Format(Val(TEXTPreviousBalance.Text) + Val(TEXTDebit.EditValue) - Val(TEXTCredit.EditValue), "0.000")
                        Click8 = True
                        AccountingprocedureA()
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.DELETEDATCASHIER1()
                            Me.DELETEMPSOLF()
                            Me.CheckCarryCash.Checked = False
                            Me.TEXTCurrentBalance.Text = Format(Val(TEXTPreviousBalance.Text) + Val(TEXTDebit.EditValue) - Val(TEXTCredit.EditValue), "0.000")
                            Click9 = True
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.Radbank.Checked = True Then
                If Me.CheckCarryCash.Checked = False Then
                    resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة البنك " & "للموظف " & Me.ComboStaffMovement.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        'Me.BS.Position = Me.BS.Count - 1
                        'Me.BS.EndEdit()
                        'Me.BS.AddNew()
                        CLEARDATA1(Me)
                        Me.CheckCarryCash.Checked = True
                        Cash = False
                        GetAutoNumber("CSH1", "EMPSOLF", "CSH2")
                        TEXTID.EditValue = AutoNumber
                        Me.TextMovementSymbol.EditValue = "PS" & Me.TEXTID.EditValue
                        Me.ComboBN2.Text = MEBN2
                        Me.ComboBN2_SelectedIndexChanged(sender, e)
                        MEBN3 = ModuleGeneral.BN3
                        Me.ComboMotionSource.Text = "عهدة الموظفين"
                        Me.TEXTStatement.Text = "حركات عهد الموظفين"

                        Dim Frm As New mane
                        Frm.TEXTValues.Text = Format(Val(SumAmounTOTALBALANCEEMPSOLF(Me.TextStaffNumber.Text, TEXTID.EditValue)), "0.000")
                        Frm.TextPermissionNumber.Enabled = True
                        Frm.ShowDialog()
                        Me.TEXTCredit.EditValue = Val(Frm.TEXTValues.Text)
                        Me.TEXTDocumentNumber.Text = Val(Frm.TextPermissionNumber.Text)
                        ch = Format(Val(SumAmounTOTALBALANCEEMPSOLF(Me.TextStaffNumber.Text, TEXTID.EditValue)), "0.000")
                        ch1 = Me.TEXTCredit.EditValue

                        If Val(ch) < Val(ch1) Then
                            MsgBox("انتبه رصبد العهدة لا يكفي لهذه الحركة", 16, "تنبيه")
                            Me.BUTTONCANCEL_Click(sender, e)
                            Exit Sub
                        End If

                        Insert_EMPSOLF("صرف", Me.TEXTID.EditValue, 0, Me.TEXTCredit.EditValue, Me.ComboMotionSource.Text, Me.TEXTStatement.Text, Me.CheckTransferAccounts.Checked, Me.ComboStaffMovement.Text, Me.TextStaffNumber.Text, Me.TextMovementSymbol.EditValue, True, Me.ComboCB1.Text, Me.ComboBN2.Text)
                        TransferToCashMovements()
                        Click10 = True
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.TextLSet.Text = LSet(TextMovementSymbol.EditValue, 2)

                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        DELETBANKJO()
                        TransferToCashMovements()
                        Click11 = True
                        AccountingprocedureA()
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة البنك", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.DELETBANKJO()
                            MYDELETERECORD("EMPSOLF", "CSH1", Me.TEXTID, BS, True)
                            Me.CheckCarryCash.Checked = False
                            Click12 = True
                        Else
                            MsgBox("يجب اخيار ترحيل الى الصندوق او الى البنك", 16, "تنبية")
                            Exit Sub
                        End If
                    End If
                End If
            Else
                MsgBox("يجب اخيار ترحيل الى الصندوق او الى البنك", 16, "تنبية")
                Exit Sub
            End If
            P = Me.BS.Position
            Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
            Me.UPDATERECORD()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.BS.Position = P
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub InternalAuditorBalance()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Sum(EMPSOLF.CSH7) AS SumDEBIT,Sum(EMPSOLF.CSH8) AS SumCREDIT FROM EMPSOLF  WHERE (EMPSOLF.CSH15)='" & Me.TextStaffNumber.Text & "'AND EMPSOLF.CSH1 <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim DataSetTab20 As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
            DataSetTab20.Clear()
            Adp1.Fill(DataSetTab20, "EMPSOLF")
            If DataSetTab20.Tables(0).Rows.Count > 0 Then
                Me.TEXTPreviousBalance.Text = Format(Val(DataSetTab20.Tables(0).Rows(0).Item(0)) - Val(DataSetTab20.Tables(0).Rows(0).Item(1)), "0.000")
            Else
                Me.TEXTPreviousBalance.Text = "0"
            End If
            Adp1.Dispose()
            Consum.Close()
        Catch ex As Exception
            Me.TEXTPreviousBalance.Text = "0"
        End Try
    End Sub

    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboStaffMovement1.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboStaffMovement1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Adp.Fill(ds, "EMPLOYEES")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextStaffNumber1.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextStaffNumber1.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        InternalAuditorBalance()
    End Sub


    Private Function SumAmountEMP() As Double
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT Sum(EMPSOLF.CSH7) ,Sum(EMPSOLF.CSH8)  FROM EMPSOLF  WHERE (EMPSOLF.CSH18)='" & Me.TextStaffNumber.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                SumAmountEMP = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
            Else
                SumAmountEMP = "0.00"
            End If
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
        Return SumAmountEMP
    End Function

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
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


    Private Sub AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing

        If keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No) IsNot Nothing Then
            DebitAccount_No = keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No)
            DebitAccount_No = ID_Nam
        End If
        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", DebitAccount_No, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", DebitAccount_No, 1)
        DebitAccount_Cod = ID_Nam
        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, DebitAccount_No)

        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        GetFundAccount_No(ModuleGeneral.CB2)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", FundAccount_No, 1)
        FundAccount_Name = ID_Nam

        Me.ComboCB1.Enabled = True
        Me.LabelCB1.Enabled = True
        LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
        TextCreditAccount.Text = FundAccount_Name

    End Sub


    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing

        nem = " حساب عهدة الموظفين"
        nem1 = " حساب عهدة الموظفين الى الصندوق"
        PMO2 = 1
        If keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No) IsNot Nothing Then
            DebitAccount_No = keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No)
        End If
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
        DebitAccount_Cod = ID_Nam

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, DebitAccount_No)

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", FundAccount_No, 1)
        FundAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", FundAccount_No, 1)
        CodAccount = ID_Nam

        SEARCHDATA.MAXIDMOVES()

        AccountingEntries(T1, T2, MaxDate.ToString("yyyy-MM-dd"), nem, False, TEXTDebit.EditValue, TEXTDebit.EditValue, T3, "قيد", "PS", TextMovementSymbol.EditValue, False)
        DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTDebit.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, FundAccount_No, 0, TEXTDebit.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TEXTDebit.EditValue, Me.Text,
                                              "من حساب حركة عهدة الموظفين اسم و رقم " & " _ " & Me.ComboStaffMovement.Text & "_" & TextStaffNumber.Text, False, TEXTDocumentNumber.Text,
                                              False, True, ComboCB1.Text, ModuleGeneral.CB2)


    End Sub



    Private Sub NewMethod()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        TestkeyAccounts(keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("CalculationEmployeeEngagement_No", CalculationEmployeeEngagement_No)
        End If
        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", AccountNoAktevd, 1)
        CredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", AccountNoAktevd, 1)
        CredAccount_Cod = ID_Nam
        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, DebitAccount_No)

        If Me.Radcsh.Checked = True Then  ' ايداع
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2, 1)
            FundAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
            FundAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", FundAccount_No, 1)
            CodAccount = ID_Nam
        ElseIf Radbank.Checked = True Then ' بنك
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.BN3, 1)
            DebitAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam
        End If
    End Sub

    Private Sub TransferToCashMovements()
        Try
            nem = "تحويل حساب عهدة الموظفين"
            nem1 = "تحويل حساب عهدة الموظفين الى الصندوق"
            nem2 = "تحويل حساب عهدة الموظفين الى البنك"
            PMO2 = 1

            NewMethod()

            SEARCHDATA.MAXIDMOVES()
            TransferToAccounts_Check = True

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), Label30.Text, True, TEXTDebit.EditValue, TEXTDebit.EditValue, T3, "قيد", "PS", TextMovementSymbol.EditValue, False)
            If Me.Radcsh.Checked = True Then  ' صندوق
                DetailsAccountingEntries(PMO2, FundAccount_Name, FundAccount_No, TEXTCredit.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            ElseIf Radbank.Checked = True Then ' بنك
                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTCredit.EditValue, 0, nem2, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            End If

            If Me.Radcsh.Checked = True Then
                DELETEDATCASHIER1()
                DELETBANKJO()
                SEARCHBANK()
                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "قيد", TextMovementSymbol.EditValue, TEXTCredit.EditValue, 0, Me.Text,
                                   TEXTStatement.Text, False, TEXTID.EditValue & "0", True, True, ComboCB1.Text, CB2)
            ElseIf Me.Radbank.Checked = True Then
                Dim s As String = "من حساب حركة عهدة الموظفين رقم " & TextStaffNumber.Text
                SEARCHBANK()
                DELETEDATCASHIER1()
                DELETBANKJO()
                Insert_BANKJO(TEXTCredit.EditValue, 0, ComboBN2.Text, TextStaffNumber.Text & " " & "_" & " " & " : ايداع نقدي موظف رقم", s, ComboBN2.Text, BN3, TextMovementSymbol.EditValue, False, True, ComboCB1.Text)
            End If

        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
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

    Private Sub NumericUpDown1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged

        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub

    Private Sub NumericUpDown2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
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

    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
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
        Consum.Close()
        AutoEx()
    End Sub

    Private Sub AutoEx()
        On Error Resume Next
        Dim ExResult As String
        ExResult = "حركات عهد الموظفين" & " " & ":" & " " & Me.TextStaffNumber1.Text & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "للرقم" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & " " & "مثبتة بوثيقة رقم" & " " & ":" & " " & Me.TEXTID.EditValue & vbNewLine
        Label30.Text = ExResult
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

    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.TextStaffNumber1.Clear()
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

    Private Sub PicFundMovementNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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

    Private Sub PicFundMovementNumber1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber1.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
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
            index = f.BS.Find("CSH1", Me.TextFundMovementNumber1.Text.Trim)
            f.TB1 = Me.TextFundMovementNumber1.Text.Trim
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


    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBankTransactionNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmJO
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT EBNK1 FROM BANKJO WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY EBNK1", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "BANKJO")
            f.BS.DataMember = "BANKJO"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("EBNK1", Me.TextBankTransactionNumber.Text)
            f.TB1 = Me.TextBankTransactionNumber.Text
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
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHAccount_no(Me.ComboStaffMovement1.Text)
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

        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
        Me.TextFundMovementNumber1.Text = SEARCHDATA.CSH1

        SEARCHDATA.SEARCHBANKJO(Me.TextMovementSymbol.EditValue)
        Me.TextBankTransactionNumber.Text = SEARCHDATA.EBNK1JO
    End Sub

    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stepBALANCE.Click
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub

    Private Sub Frmempsolf_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If
           Dim XLO As Int64
            XLO = CInt(Me.TEXTID.EditValue)
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
            f.TEXTFileSubject.Text = "مستندات عهدة الموظفين"
            f.TextFileDescription.Text = "ارفاق مستندات عهدة الموظفين"
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
                MsgBox("لا يوجد اي مستندات", 64 + 524288, "تنبيه")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        AccountsEnquiry()
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
        AccountsEnquiry()
        FundBalance()
    End Sub

    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4   FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            ModuleGeneral.BN3 = ds.Tables(0).Rows(0).Item(0)
            ModuleGeneral.BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            ModuleGeneral.BN3 = ""
            ModuleGeneral.BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        AccountsEnquiry()
    End Sub

    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateMovementHistory.ValueChanged
        On Error Resume Next
        Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub

End Class