Option Explicit Off

Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmChecks
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
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Dim TR As Boolean
    Dim nem As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Dim CHK As Boolean = False

<<<<<<< HEAD
    Private Sub FrmChecks_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmChecks_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FrmChecks_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmChecks_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        ButtonXP1_Click(sender, e)
                    Case Keys.F9
                        Load_Click(sender, e)
                    Case Keys.F10
                        ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.F12
                        Me.CHK = True
                        Me.InternalAuditorType()
                        Me.EDITBUTTON.Enabled = False
                        Me.DELETEBUTTON.Enabled = False
                        Me.BALANCEBUTTON.Enabled = False
                        Me.InternalAuditorERBUTTON.Enabled = False
                        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False

                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        BALANCEBUTTON_Click(sender, e)
                    Case Keys.D And (e.Alt And Not e.Control And Not e.Shift)
                        ButtonXP4_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        ButtonXP5_Click(sender, e)
                    Case Keys.PageDown
                        PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub FrmChecks_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmChecks_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
        Me.TabPage1.Show()
    End Sub

<<<<<<< HEAD
    Private Sub FrmChecks_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmChecks_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        Me.MAIN5.BackgroundImage = img
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
        Me.ButtonPrintReceiptDischarge.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.BALANCEBUTTON.Enabled = False
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

<<<<<<< HEAD
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ConnectDataBase = New BackgroundWorker With {
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
    Private Sub TEXTBOX6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TEXTBOX6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & Me.BS.Count
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
        CurrenRecordst = BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("Checks").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmounJOBALANCE()
        Me.TEXTTotalN.Text = CurrencyJO(CDec(Me.TEXTTotal.Text), "jO")
        Me.TextMovementSymbol2.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        If Me.CheckEW.Checked = True And Me.CheckKS.Checked = False Then
            Me.CMENUA.Visible = False
            Me.CMENUB.Visible = False
            Me.CMENUD.Visible = False
            Me.CMENUC.Visible = False
            Me.CMENUKS.Visible = True
            Me.CMENUD1.Visible = True
        ElseIf Me.CheckEW.Checked = True And Me.CheckKS.Checked = True Then
            Me.CMENUA.Visible = False
            Me.CMENUB.Visible = False
            Me.CMENUD.Visible = False
            Me.CMENUC.Visible = False
            Me.CMENUKS.Visible = True
            Me.CMENUD1.Visible = False
        ElseIf Me.CheckEW.Checked = False And Me.CheckKS.Checked = False Then
            Me.CMENUA.Visible = True
            Me.CMENUB.Visible = True
            Me.CMENUD.Visible = True
            Me.CMENUC.Visible = True
            Me.CMENUKS.Visible = True
            Me.CMENUD1.Visible = False
        ElseIf Me.CheckEW.Checked = False And Me.CheckKS.Checked = True Then
            Me.CMENUA.Visible = False
            Me.CMENUB.Visible = False
            Me.CMENUD.Visible = False
            Me.CMENUC.Visible = False
            Me.CMENUKS.Visible = True
            Me.CMENUD1.Visible = False
        End If
        If Me.TextMovementSymbol2.Text.ToString.Trim = "PR" Then '«·„‘ —Ì«  
            SEARCHDATA.SEARCHBUYSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioButton4.Checked = CBool(Conversion.Val(SEARCHDATA.BUYCASH))
        ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "VE" Then '«·„»Ì⁄«  
            SEARCHDATA.SEARCHSLSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioButton4.Checked = CBool(Conversion.Val(SEARCHDATA.SLSCASH))
        End If
        Me.InternalAuditorType()
        Me.BUTTONCANCEL.Enabled = True
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonAttachDocument.Enabled = LockAddRow
        Me.CMENUA.Enabled = TransferofAccounts
        Me.CMENUB.Enabled = TransferofAccounts
        Me.CMENUKS.Enabled = TransferofAccounts
        Me.CMENUD.Enabled = TransferofAccounts
        Me.CMENUC.Enabled = TransferofAccounts
        Me.CMENUD1.Enabled = TransferofAccounts
    End Sub

    Private Sub SumAmounJOBALANCE()
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.CheckEW.Checked = False Then
            Dim strSQL1 As New SqlCommand("SELECT Sum(ch5-ch6)  FROM Checks WHERE CUser = '" & CUser & "'" & "AND CH15='Ê«—œ'", Consum)
            Dim ds As New DataSet
<<<<<<< HEAD
            Adp = New SqlDataAdapter(strSQL1)
=======
            Adp = New SqlClient.SqlDataAdapter(strSQL1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp.Fill(ds)
            Adp.Fill(ds, "Checks")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Me.TEXTTotal.Text = "0"
            End If
            Adp.Dispose()
        ElseIf Me.CheckEW.Checked = True Then
            Dim strSQL2 As New SqlCommand("SELECT Sum(ch6-ch5)  FROM Checks WHERE CUser = '" & CUser & "'" & "AND CH15='’«œ—'", Consum)
            Dim ds As New DataSet
<<<<<<< HEAD
            Adp = New SqlDataAdapter(strSQL2)
=======
            Adp = New SqlClient.SqlDataAdapter(strSQL2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp.Fill(ds)
            Adp.Fill(ds, "Checks")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Me.TEXTTotal.Text = "0"
            End If
            Adp.Dispose()
        End If
        Consum.Close()
    End Sub

    Public Sub DanLOd()
        On Error Resume Next
<<<<<<< HEAD
        Me.BackWorker2 = New BackgroundWorker With {
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

<<<<<<< HEAD
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackWorker2.DoWork
=======
    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strSQL As New SqlCommand("", Consum)
            With strSQL
                .CommandText = String.Concat(New String() {"SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='", ModuleGeneral.CUser, "'  and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and IDCH ='", Trim(Me.TB1), "' or CH1 ='", Trim(Me.TB2), "' or CH7 ='", Trim(Me.TB3), "'or CH8 ='", Trim(Me.TB4), "'ORDER BY IDCH"})
                Me.SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = String.Concat(New String() {"SELECT  IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='", ModuleGeneral.CUser, "'  and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and IDCH ='", Trim(Me.TB1), "' or CH1 ='", Trim(Me.TB2), "' or CH7 ='", Trim(Me.TB3), "'or CH8 ='", Trim(Me.TB4), "'ORDER BY IDCH"})
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim builder10 As New SqlCommandBuilder(Me.SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                'SqlDataAdapter1.TableMappings.Add("Table1", "Checks")

                Me.SqlDataAdapter1.Fill(Me.myds, "Checks")
                Me.myds.RejectChanges()
            End With
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
            Me.BS.DataSource = Me.myds.Tables("Checks")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "IDCH", True, CType(1, DataSourceUpdateMode), "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "CH1", True, CType(1, DataSourceUpdateMode), "")
            Me.DateMovementHistory.DataBindings.Add("text", Me.BS, "CH2", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "CH3", True, CType(1, DataSourceUpdateMode), "")
            Me.ComboCheckStatus.DataBindings.Add("text", Me.BS, "CH4", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CH5", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CH6", True, CType(1, DataSourceUpdateMode), "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", Me.BS, "CH7", True, CType(1, DataSourceUpdateMode), "")
            Me.TextCheckDrawerNumber.DataBindings.Add("text", Me.BS, "CH8", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CH9", True, CType(1, DataSourceUpdateMode), "")
            Me.ComboConstraintType.DataBindings.Add("text", Me.BS, "CH10", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CH11", True, CType(1, DataSourceUpdateMode), "")
            Me.TextBN3.DataBindings.Add("text", Me.BS, "CH12", True, CType(1, DataSourceUpdateMode), "")
            Me.RightDate.DataBindings.Add("text", Me.BS, "CH13", True, CType(1, DataSourceUpdateMode), "")
            Me.TextBN4.DataBindings.Add("text", Me.BS, "CH14", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckEW.DataBindings.Add("Checked", Me.BS, "CH15", True, CType(1, DataSourceUpdateMode), "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CH16", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckKS.DataBindings.Add("Checked", Me.BS, "CH17", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CH18", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "CH19", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckA.DataBindings.Add("Checked", Me.BS, "CH20", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckB.DataBindings.Add("Checked", Me.BS, "CH21", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckD.DataBindings.Add("Checked", Me.BS, "CH22", True, CType(1, DataSourceUpdateMode), "")
            Me.CheckC.DataBindings.Add("Checked", Me.BS, "CH23", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTTotal.DataBindings.Add("text", Me.BS, "CH24", True, CType(1, DataSourceUpdateMode), "")
            Me.TextPreviousCheckStatus.DataBindings.Add("text", Me.BS, "CH25", True, CType(1, DataSourceUpdateMode), "")
            Me.ComboCurrentCheckStatus.DataBindings.Add("text", Me.BS, "CH26", True, CType(1, DataSourceUpdateMode), "")

            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, CType(1, DataSourceUpdateMode), "")
            Me.ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, CType(1, DataSourceUpdateMode), "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, CType(1, DataSourceUpdateMode), "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, CType(1, DataSourceUpdateMode), "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, CType(1, DataSourceUpdateMode), "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, CType(1, DataSourceUpdateMode), "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, CType(1, DataSourceUpdateMode), "")

            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
<<<<<<< HEAD
            FILLCOMBOBOX3("Checks", "CH1", "CUser", CUser, "CH17", CStr(False), Me.ComboCheckNumber)
=======
            FILLCOMBOBOX10("Checks", "CH1", "CUser", CUser, "CH17", CStr(False), Me.ComboCheckNumber)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            FILLCOMBOBOX1("Checks", "CH1", "CUser", CUser, Me.ComboCheckNumber)
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Auditor("Checks", "USERNAME", "IDCH", Me.TEXTID.EditValue, "")
            Logentry = Uses
            Call MangUsers()
            Me.SHOWBUTTON()
            Me.RecordCount()
            Me.PictureBox5.Visible = False
            Me.Label15.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub

    Private Sub DISPLAYRECORD()
        Try
            With Me
                .TEXTID.EditValue = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("IDCH").ToString
                .TextCheckNumber.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH1").ToString
                .DateMovementHistory.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH2").ToString
                .CheckDate.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH3").ToString
                .ComboCheckStatus.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH4").ToString
                .TEXTDebit.EditValue = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH5").ToString
                .TEXTCredit.EditValue = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH6").ToString
                .ComboCheckDrawerName.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH7").ToString
                .TextCheckDrawerNumber.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH8").ToString
                .TEXTStatement.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH9").ToString
                .ComboConstraintType.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH10").ToString
                .TEXTDocumentNumber.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH11").ToString
                .TextBN3.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH12").ToString
                .RightDate.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH13").ToString
                .TextBN4.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH14").ToString
                .CheckEW.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH15").ToString)
                .TextMovementSymbol.EditValue = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH16").ToString
                .CheckKS.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH17").ToString)
                .CheckLogReview.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH18").ToString)
                .CheckTransferAccounts.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH19").ToString)
                .CheckA.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH20").ToString)
                .CheckB.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH21").ToString)
                .CheckD.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH22").ToString)
                .CheckC.Checked = CBool(Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH23").ToString)
                .TEXTTotal.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH24").ToString
                .TextPreviousCheckStatus.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH25").ToString
                .ComboCurrentCheckStatus.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("CH26").ToString
                .TEXTUserName.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("USERNAME").ToString
                .TEXTReferenceName.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("Auditor").ToString
                .TextDefinitionDirectorate.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("COUser").ToString
                .TEXTAddDate.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("da").ToString
                .TextTimeAdd.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("ne").ToString
                .TEXTReviewDate.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("da1").ToString
                .TextreviewTime.Text = Me.myds.Tables("Checks").Rows(Me.BS.Position).Item("ne1").ToString
                Auditor("Checks", "USERNAME", "IDCH", Me.TEXTID.EditValue, "")
                Logentry = Uses
                FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
                FILLCOMBOBOX1("Checks", "CH1", "CUser", CUser, Me.ComboCheckNumber)
                FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
                FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
                Call MangUsers()
                Me.SHOWBUTTON()
                Me.RecordCount()
                Me.PictureBox5.Visible = False
                Me.Label15.Visible = False
            End With
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
                .CommandText = "SELECT   IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks WHERE  CUser='" & CUser & "' and Year(CH3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                '  WHERE  CUser='" & CUser & "' and CH17 = '" & False & "'"     
                SqlDataAdapter1 = New SqlDataAdapter(strSQL)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT   IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks WHERE  CUser='" & CUser & "' and Year(CH3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                '  WHERE  CUser='" & CUser & "' and CH17 = '" & False & "'"     
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                myds = New DataSet
                Consum.Open()
                SqlDataAdapter1.TableMappings.Add("Table1", "Checks")
                SqlDataAdapter1.Fill(myds, "Checks")
                myds.RejectChanges()
            End With
            Consum.Close()
            Auditor("Checks", "USERNAME", "IDCH", Me.TEXTID.EditValue, "")
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
                Me.Label15.Visible = True
                Me.Label15.ForeColor = Color.Yellow
                Me.Label15.Text = "›÷·« «‰ Ÿ— ﬁ·Ì·« .. Ì „  Õ„Ì· ”Ã·«  «·Õﬁ·"
                Me.PictureBox5.Visible = True
            Else
                Me.Label15.ForeColor = Color.Red
                Me.Label15.Text = "«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—"
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
            BS.DataSource = myds.Tables("Checks")
            RowCount = BS.Count
            TEXTID.DataBindings.Add("text", BS, "IDCH", True, CType(1, DataSourceUpdateMode), "")
            TextCheckNumber.DataBindings.Add("text", BS, "CH1", True, CType(1, DataSourceUpdateMode), "")
            DateMovementHistory.DataBindings.Add("text", BS, "CH2", True, CType(1, DataSourceUpdateMode), "")
            CheckDate.DataBindings.Add("text", BS, "CH3", True, CType(1, DataSourceUpdateMode), "")
            ComboCheckStatus.DataBindings.Add("text", BS, "CH4", True, CType(1, DataSourceUpdateMode), "")
            TEXTDebit.DataBindings.Add("text", BS, "CH5", True, CType(1, DataSourceUpdateMode), "")
            TEXTCredit.DataBindings.Add("text", BS, "CH6", True, CType(1, DataSourceUpdateMode), "")
            ComboCheckDrawerName.DataBindings.Add("text", BS, "CH7", True, CType(1, DataSourceUpdateMode), "")
            TextCheckDrawerNumber.DataBindings.Add("text", BS, "CH8", True, CType(1, DataSourceUpdateMode), "")
            TEXTStatement.DataBindings.Add("text", BS, "CH9", True, CType(1, DataSourceUpdateMode), "")
            ComboConstraintType.DataBindings.Add("text", BS, "CH10", True, CType(1, DataSourceUpdateMode), "")
            TEXTDocumentNumber.DataBindings.Add("text", BS, "CH11", True, CType(1, DataSourceUpdateMode), "")
            TextBN3.DataBindings.Add("text", BS, "CH12", True, CType(1, DataSourceUpdateMode), "")
            RightDate.DataBindings.Add("text", BS, "CH13", True, CType(1, DataSourceUpdateMode), "")
            TextBN4.DataBindings.Add("text", BS, "CH14", True, CType(1, DataSourceUpdateMode), "")
            CheckEW.DataBindings.Add("Checked", BS, "CH15", True, CType(1, DataSourceUpdateMode), "")
            TextMovementSymbol.DataBindings.Add("text", BS, "CH16", True, CType(1, DataSourceUpdateMode), "")
            CheckKS.DataBindings.Add("Checked", BS, "CH17", True, CType(1, DataSourceUpdateMode), "")
            CheckLogReview.DataBindings.Add("Checked", BS, "CH18", True, CType(1, DataSourceUpdateMode), "")
            CheckTransferAccounts.DataBindings.Add("Checked", BS, "CH19", True, CType(1, DataSourceUpdateMode), "")
            CheckA.DataBindings.Add("Checked", BS, "CH20", True, CType(1, DataSourceUpdateMode), "")
            CheckB.DataBindings.Add("Checked", BS, "CH21", True, CType(1, DataSourceUpdateMode), "")
            CheckD.DataBindings.Add("Checked", BS, "CH22", True, CType(1, DataSourceUpdateMode), "")
            CheckC.DataBindings.Add("Checked", BS, "CH23", True, CType(1, DataSourceUpdateMode), "")
            TEXTTotal.DataBindings.Add("text", BS, "CH24", True, CType(1, DataSourceUpdateMode), "")
            TextPreviousCheckStatus.DataBindings.Add("text", BS, "CH25", True, CType(1, DataSourceUpdateMode), "")
            ComboCurrentCheckStatus.DataBindings.Add("text", BS, "CH26", True, CType(1, DataSourceUpdateMode), "")
            ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, CType(1, DataSourceUpdateMode), "")
            ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, CType(1, DataSourceUpdateMode), "")
            TEXTUserName.DataBindings.Add("text", BS, "USERNAME", True, CType(1, DataSourceUpdateMode), "")
            TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, CType(1, DataSourceUpdateMode), "")
            TextDefinitionDirectorate.DataBindings.Add("text", BS, "COUser", True, CType(1, DataSourceUpdateMode), "")
            TEXTAddDate.DataBindings.Add("text", BS, "da", True, CType(1, DataSourceUpdateMode), "")
            TextTimeAdd.DataBindings.Add("text", BS, "ne", True, CType(1, DataSourceUpdateMode), "")
            TEXTReviewDate.DataBindings.Add("text", BS, "da1", True, CType(1, DataSourceUpdateMode), "")
            TextreviewTime.DataBindings.Add("text", BS, "ne1", True, CType(1, DataSourceUpdateMode), "")
            Auditor("Checks", "USERNAME", "IDCH", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
            FILLCOMBOBOX1("Checks", "CH1", "CUser", CUser, Me.ComboCheckNumber)
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Call MangUsers()
            Me.SHOWBUTTON()
            Me.RecordCount()
            Me.PictureBox5.Visible = False
            Me.Label15.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub

    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update Checks SET CH1 = @CH1, CH2 = @CH2, CH3 = @CH3, CH4 = @CH4, CH5 = @CH5, CH6 = @CH6, CH7 = @CH7, CH8 = @CH8, CH9 = @CH9, CH10 = @CH10, CH11 = @CH11, CH12 = @CH12, CH13 = @CH13, CH14 = @CH14, CH15 = @CH15, CH16 = @CH16, CH17 = @CH17, CH18 = @CH18, CH19 = @CH19, CH20 = @CH20, CH21 = @CH21, CH22 = @CH22, CH23 = @CH23, CH24 = @CH24, CH25 = @CH25, CH26 = @CH26, CB1 = @CB1, BN2 = @BN2, CUser = @CUser, COUser = @COUser, USERNAME = @USERNAME, Auditor = @Auditor, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE IDCH = @IDCH ", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update Checks SET CH1 = @CH1, CH2 = @CH2, CH3 = @CH3, CH4 = @CH4, CH5 = @CH5, CH6 = @CH6, CH7 = @CH7, CH8 = @CH8, CH9 = @CH9, CH10 = @CH10, CH11 = @CH11, CH12 = @CH12, CH13 = @CH13, CH14 = @CH14, CH15 = @CH15, CH16 = @CH16, CH17 = @CH17, CH18 = @CH18, CH19 = @CH19, CH20 = @CH20, CH21 = @CH21, CH22 = @CH22, CH23 = @CH23, CH24 = @CH24, CH25 = @CH25, CH26 = @CH26, CB1 = @CB1, BN2 = @BN2, CUser = @CUser, COUser = @COUser, USERNAME = @USERNAME, Auditor = @Auditor, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE IDCH = @IDCH ", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCH", SqlDbType.Int).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CH1", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CH2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CH3", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CH4", SqlDbType.NVarChar).Value = Me.ComboCheckStatus.Text
                .Parameters.Add("@CH5", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CH6", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CH7", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CH8", SqlDbType.NVarChar).Value = Me.TextCheckDrawerNumber.Text
                .Parameters.Add("@CH9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CH10", SqlDbType.NVarChar).Value = Me.ComboConstraintType.Text
                .Parameters.Add("@CH11", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CH12", SqlDbType.NVarChar).Value = Me.TextBN3.Text
                .Parameters.Add("@CH13", SqlDbType.Date).Value = RightDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CH14", SqlDbType.NVarChar).Value = Me.TextBN4.Text
                .Parameters.Add("@CH15", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckEW.Checked)
                .Parameters.Add("@CH16", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CH17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckKS.Checked)
                .Parameters.Add("@CH18", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CH19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@CH20", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckA.Checked)
                .Parameters.Add("@CH21", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckB.Checked)
                .Parameters.Add("@CH22", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckD.Checked)
                .Parameters.Add("@CH23", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckC.Checked)
                .Parameters.Add("@CH24", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@CH25", SqlDbType.NVarChar).Value = Me.TextPreviousCheckStatus.Text
                .Parameters.Add("@CH26", SqlDbType.NVarChar).Value = Me.ComboCurrentCheckStatus.Text
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

<<<<<<< HEAD
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles RefreshTab.DoWork
=======
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:
            myds = New DataSet
            SqlDataAdapter1.Fill(myds, "Checks")
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
            BS.DataSource = myds.Tables("Checks")
            PictureBox2.Visible = False
            TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            Count()
            If DelRow = False Then
                If BS.Count < RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - BS.Count, CType(48 + 524288, MsgBoxStyle), " ÕœÌÀ «·”Ã·« ")
                ElseIf BS.Count > RowCount Then
                    MsgBox("  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & BS.Count - RowCount, CType(48 + 524288, MsgBoxStyle), " ÕœÌÀ «·”Ã·« ")
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
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
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
            BS.DataSource = myds.Tables("Checks")
            TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            PictureBox2.Visible = False
            Count()
            If BS.Count < RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & RowCount - BS.Count, CType(64 + 524288, MsgBoxStyle), " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & BS.Count - RowCount, CType(64 + 524288, MsgBoxStyle), " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click2 = True Then
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
                    Insert_Actions(Me.TEXTID.EditValue, " ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click12 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click13 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click14 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click15 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click16 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click17 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click18 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click19 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click20 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click21 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click22 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click23 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ⁄œÌ·  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click24 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "Õ–›  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï „‰" & " " & Me.TextPreviousCheckStatus.Text & " " & "«·Ï" & " " & Me.ComboCheckStatus.Text, Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click25 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, " ÕÊÌ· ‘Ìﬂ", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click26 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "«·„—«Ã⁄", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click27 = True Then
                Try
                    Insert_Actions(Me.TEXTID.EditValue, "≈·€«¡ «·„—«Ã⁄…", Me.Text)
                Catch ex As Exception
                    MsgBox("ÕœÀ Œÿ«¡", MsgBoxStyle.Information, "„⁄·Ê„« ")
                Finally
                    Consum.Close()
                End Try

            End If
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
            Click15 = False
            Click16 = False
            Click17 = False
            Click18 = False
            Click19 = False
            Click20 = False
            Click21 = False
            Click22 = False
            Click23 = False
            Click24 = False
            Click25 = False
            Click26 = False
            Click27 = False
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", CType(64 + 524288, MsgBoxStyle), "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
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
            PictureBox2.Visible = False
            PictureBox5.Visible = False
        End If
    End Sub

    Private Sub GETBANKNOWBALANCE()
        On Error Resume Next
        Dim n As Double
        Dim F As Double
        n = BS.Position
        BS.EndEdit()
        If BS.Position = 0 Then
            Me.TEXTTotal.Text = CStr(0)
        ElseIf BS.Position > 0 Then
            F = 0
            BS.Position = BS.Position - 1
            F = Val(TEXTTotal.Text)
            BS.Position = BS.Position + 1
            Me.TEXTTotal.Text = CStr(F)
        End If
    End Sub

    Private Sub MAXRECORD()
        On Error Resume Next
        Dim N As Double
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(IDCH) FROM Checks", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCH) FROM Checks", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            N = 1
        Else
            N = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Me.TEXTID.EditValue = CStr(Val(N))
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
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Year(CDate(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd"))) > FiscalYear_currentDateMustBeInFiscalYear() Then
            MsgBox("⁄›Ê« .. «·”‰… «·„Õ«”»Ì… €Ì— ’ÕÌÕ… ›·« Ì„ﬂ‰ «·„ﬁ«—‰…", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.TextMovementSymbol2.Text.Trim <> "KS" Then
            Dim resault As Integer
            resault = MessageBox.Show("·«Ì„ﬂ‰  ⁄œ»·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ·" & vbCrLf & vbCrLf & "ÌÃ» «·€«¡ «· —ÕÌ· ··”Ã· «·Õ«·Ï „‰ ‘«‘… " & "  " & Me.ComboDebitAccount.Text, "”Ã· „—Õ·", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰  ⁄œ»·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ «· ⁄œÌ· „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        Static P As Integer
        P = BS.Position
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        RecordCount()
        Me.Cursor = Cursors.WaitCursor
        PictureBox2.Visible = True
        UPDATERECORD()
        BS.EndEdit()
        RowCount = BS.Count
<<<<<<< HEAD
        SaveTab = New BackgroundWorker With {
=======
        SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        SaveTab.RunWorkerAsync()
        BS.Position = P
        SHOWBUTTON()
        Click2 = True
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
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ Õ–› „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        Else
            Dim resault As Integer
            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ Õ—ﬂ… «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                MYDELETERECORD("Checks", "IDCH", TEXTID, BS, True)
                FrmChecks_Load(sender, e)
                Insert_Actions(Me.TEXTID.EditValue, "Õ–›", Me.Text)
            Else
                Exit Sub
            End If
        End If
    End Sub

<<<<<<< HEAD
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        Dim rpt As New Checks2
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
        If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
            MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.RadioButton1.Checked = True Then
            If Len(Me.ComboCheckNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·Õ”«»  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboCheckNumber.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Checks   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND  " & "CH1 like '" & Me.ComboCheckNumber.Text & "'", Consum)
            Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = CType(rpt.Section1.ReportObjects("Text5"), TextObject)
            txt.Text = "Œ·«· «·› —… „‰" & "_" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = CType(rpt.Section1.ReportObjects("Text12"), TextObject)
            txt.Text = AssociationName
            txt = CType(rpt.Section1.ReportObjects("Text13"), TextObject)
            txt.Text = Directorate
            txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
            txt.Text = Character
            txt = CType(rpt.Section1.ReportObjects("TEXT40"), TextObject)
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton2.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Checks   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = CType(rpt.Section1.ReportObjects("Text5"), TextObject)
            txt.Text = "Œ·«· «·› —… „‰" & "_" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = CType(rpt.Section1.ReportObjects("Text12"), TextObject)
            txt.Text = AssociationName
            txt = CType(rpt.Section1.ReportObjects("Text13"), TextObject)
            txt.Text = Directorate
            txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
            txt.Text = Character
            txt = CType(rpt.Section1.ReportObjects("TEXT40"), TextObject)
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        ElseIf Me.RadioButton3.Checked = True Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Checks   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND  " & "CH18 ='" & False & "'", Consum)
            Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            rpt.SetDataSource(ds)
            Dim txt As TextObject
            txt = CType(rpt.Section1.ReportObjects("Text5"), TextObject)
            txt.Text = "Œ·«· «·› —… „‰" & "_" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = CType(rpt.Section1.ReportObjects("Text12"), TextObject)
            txt.Text = AssociationName
            txt = CType(rpt.Section1.ReportObjects("Text13"), TextObject)
            txt.Text = Directorate
            txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
            txt.Text = Character
            txt = CType(rpt.Section1.ReportObjects("TEXT40"), TextObject)
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = CType(rpt.Section1.ReportObjects("Text44"), TextObject)
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
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ·«Ì„ﬂ‰ „—«Ã⁄… «·”Ã·«  ﬁ»· «· —ÕÌ· «·Ï «·Õ”«»« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
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
        Click26 = True
    End Sub

<<<<<<< HEAD
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. Â–« «·”Ã· €Ì— „—«Ã⁄ ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
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

    End Sub

<<<<<<< HEAD
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BALANCEBUTTON.Click
=======
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        Me.ProgressBar1.Visible = True
        Me.PictureBox2.Visible = True
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
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockUpdate = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·«—’œ… „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        For I = 1 To BS.Count + 1
            If Me.BackWorker3.CancellationPending Then
                e.Cancel = True
                Return
            End If
            Me.BackWorker3.ReportProgress(I)
            Me.BS.Position = I
            Me.InternalAuditorBalance()
            Me.UPDATERECORD()
        Next
    End Sub

<<<<<<< HEAD
    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
=======
    Private Sub BackWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackWorker3.ProgressChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Label5.Visible = True
        Me.Label5.Text = e.ProgressPercentage.ToString
        Me.ProgressBar1.Value = e.ProgressPercentage
        Me.TEXTBOX8_SelectedIndexChanged(sender, e)
        Dim percent As Integer = CInt(CDbl(ProgressBar1.Value - ProgressBar1.Minimum) / CDbl(ProgressBar1.Maximum - ProgressBar1.Minimum) * 100)
        Using gr As Graphics = ProgressBar1.CreateGraphics()
            gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(CSng(ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F)), CSng(ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F))))
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
            Me.Label15.Text = CStr(0)
            Me.Label15.Visible = False
        ElseIf e.Error IsNot Nothing Then
            Me.Label14.Text = "Error: " & e.Error.Message
        Else
            Me.BackWorker3.CancelAsync()
            Me.ProgressBar1.Visible = False
            Me.PictureBox2.Visible = False
            Me.Label5.Text = CStr(0)
            Me.Label5.Visible = False
            Me.SaveTab = New BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = 0
            ModuleGeneral.Click3 = True
        End If
    End Sub

<<<<<<< HEAD
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.Click
=======
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ComboCheckNumber.Enabled = True
    End Sub

<<<<<<< HEAD
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.Click
=======
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.ComboCheckNumber.Enabled = False
    End Sub

    Private Sub InternalAuditorBalance()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            If Me.CheckEW.Checked = False Then
                Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='Ê«—œ'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
                Dim ds As New DataSet
                Dim Adp1 As New SqlDataAdapter(strsq1)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.CheckEW.Checked = False Then
                Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='Ê«—œ'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
                Dim ds As New DataSet
                Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp1.Fill(ds, "Checks")
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
                Else
                    Me.TEXTTotal.Text = "0"
                End If
                Adp1.Dispose()
            ElseIf Me.CheckEW.Checked = True Then
                Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='’«œ—'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
                Dim ds As New DataSet
<<<<<<< HEAD
                Dim Adp1 As New SqlDataAdapter(strsq1)
=======
                Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp1.Fill(ds, "Checks")
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(1)) - Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
                Else
                    Me.TEXTTotal.Text = "0"
                End If
                Adp1.Dispose()
            End If
            Consum.Close()
        Catch ex As Exception
            Me.TEXTTotal.Text = "0"
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCredit.DoubleClick
=======
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTDebit.DoubleClick
=======
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
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
=======
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub

    Private Sub DELETEDATACASHIER()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
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
            MYDELETERECORD("MOVES", "MOV2", Me.TextKS, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA3()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TextKS, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA4()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextA, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA5()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TextA, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA6()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextB, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA7()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TextB, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA8()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextC, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA9()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TextC, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA10()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextD, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA11()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TextD, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX8_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT  COUNT(*) FROM Checks  WHERE (Checks.CH1)='" & Me.TextCheckNumber.Text & "'AND (Checks.EBNK17)='" & Me.ComboBN2.Text & "' AND Checks.IDCH < " & Val(Me.TEXTID.EditValue), Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
    Private Sub TEXTBOX8_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlClient.SqlCommand("SELECT  COUNT(*) FROM Checks  WHERE (Checks.CH1)='" & Me.TextCheckNumber.Text & "'AND (Checks.EBNK17)='" & Me.ComboBN2.Text & "' AND Checks.IDCH < " & Val(Me.TEXTID.EditValue), Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Consum.Open()
            Adp1.Fill(ds, "BANKS")
            If Me.TextBN3.Text.Contains("”Õ» »‘Ìﬂ") Or Me.TextBN3.Text.Contains("”Õ» »‘Ìﬂ") Then
            Else
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TEXTDocumentNumber.Text = CStr(Val(ds.Tables("BANKS").Rows(0).Item(0)) + 1)
                Else
                    Me.TEXTDocumentNumber.Text = CStr(1)
                End If
            End If
            Adp1.Dispose()
            Consum.Close()
        Catch ex As Exception
            Me.TEXTDocumentNumber.Text = CStr(1)
        End Try
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonPrintReceiptDischarge.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.CMENUA.Enabled = False
            Me.CMENUB.Enabled = False
            Me.CMENUKS.Enabled = False
            Me.CMENUD.Enabled = False
            Me.CMENUC.Enabled = False
            Me.CMENUD1.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboCheckStatus.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.CheckDate.Enabled = False
            Me.RightDate.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.ComboCurrentCheckStatus.Enabled = False
            Me.ComboBN2.Enabled = False
            Me.ComboCB1.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.BALANCEBUTTON.Enabled = True
            'Me.ButtonXP2.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonPrintReceiptDischarge.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.DateMovementHistory.Enabled = False
            Me.TextCheckNumber.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.CheckDate.Enabled = True
            Me.RightDate.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.ComboConstraintType.Enabled = True
            Me.ComboCurrentCheckStatus.Enabled = True
            Me.ComboBN2.Enabled = True
            Me.ComboCB1.Enabled = True
            If Me.TextMovementSymbol2.Text.ToString = "KS" Then
                'Me.Panel14.Enabled = True
                Me.ButtonTransferofAccounts.Enabled = True
            Else
                'Me.Panel14.Enabled = False
                Me.ButtonTransferofAccounts.Enabled = False
            End If
            If Me.CHK = True Then
                Me.DateMovementHistory.Enabled = True
                Me.TextCheckNumber.Enabled = True
                Me.ComboCheckDrawerName.Enabled = True
                Me.CheckDate.Enabled = True
                Me.RightDate.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.ComboCheckDrawerName.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.ComboConstraintType.Enabled = True
                Me.ComboCurrentCheckStatus.Enabled = True
                Me.ComboBN2.Enabled = True
                Me.ComboCB1.Enabled = True
            End If

        ElseIf Me.CheckLogReview.Checked = True And Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonPrintReceiptDischarge.Enabled = True
            Me.CMENUA.Enabled = False
            Me.CMENUB.Enabled = False
            Me.CMENUKS.Enabled = False
            Me.CMENUD.Enabled = False
            Me.CMENUC.Enabled = False
            Me.CMENUD1.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.DateMovementHistory.Enabled = False
            Me.ComboCheckStatus.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.CheckDate.Enabled = False
            Me.RightDate.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.ComboConstraintType.Enabled = False
            Me.Panel14.Enabled = False
            Me.ComboBN2.Enabled = False
            Me.ComboCB1.Enabled = False
        Else
            SHOWBUTTON()
            Me.CMENUA.Enabled = True
            Me.CMENUB.Enabled = True
            Me.CMENUKS.Enabled = True
            Me.CMENUD.Enabled = True
            Me.CMENUC.Enabled = True
            Me.CMENUD1.Enabled = True

            Me.DateMovementHistory.Enabled = True
            Me.ComboCheckStatus.Enabled = True
            Me.TextCheckNumber.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.CheckDate.Enabled = True
            Me.RightDate.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.ComboConstraintType.Enabled = True
            Me.ComboCurrentCheckStatus.Enabled = True
            Me.Panel14.Enabled = True
            Me.ComboBN2.Enabled = True
            Me.ComboCB1.Enabled = True
        End If

    End Sub

    Private Sub SaveMOVES1()
        Try
            SEARCHDATA.MaxIDMoves()
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
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2.ToString.Trim
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.DateMovementHistory.Text.Trim
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = TR
                If Me.CheckEW.Checked = True Then
                    .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                    .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                Else
                    .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                    .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                End If
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "ﬁÌœ"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = Me.TextKS1.Text.Trim
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

    Private Sub SaveMOVES()
        Try
            SEARCHDATA.MaxIDMoves()
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
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2.ToString.Trim
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.DateMovementHistory.Text.Trim
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                If Me.CheckEW.Checked = True Then
                    .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                    .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                Else
                    .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                    .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                End If
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "ﬁÌœ"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "KS"
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
            nem = "«Ìœ«⁄«  «·‘Ìﬂ« "
            pp = "1"
            A = TEXTTotal.Text
            S = "„⁄«„·«  «·‘Ìﬂ« "
            C = "0.00"
            'GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Module1.CB2, 1)
            'Box = CInt(ID_Nam)
            'GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Module1.CB2, 1)
            'Box1 = CInt(ID_Nam)

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            Box2 = CInt(ID_Nam)
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
            Box3 = CInt(ID_Nam)

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", List1.Text, 1)
            Box4 = CInt(ID_Nam)
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", List1.Text, 1)
            Box5 = CInt(ID_Nam)
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
                If CDbl(Me.TEXTCredit.EditValue) > 0 Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & CDbl(pp.ToString) & "','" & ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & TEXTCredit.EditValue & "','" & "0.00" & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & CDbl(pp.ToString) + 1 & "','" & TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & "0.00" & "','" & TEXTCredit.EditValue & "','" & nem.Trim & "','" & Box5.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                Else
                    .CommandText = "Insert Into MOVESDATA(MOVD2,MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & CDbl(pp.ToString) & "','" & ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & TEXTDebit.EditValue & "','" & "0.00" & "','" & S.Trim & "','" & Box3.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2,MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & CDbl(pp.ToString) + 1 & "','" & TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & "0.00" & "','" & TEXTDebit.EditValue & "','" & S.Trim & "','" & Box5.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
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

    Private Sub ComboBoxTrueFalse()
        Try
            If Me.ComboCheckStatus.Text.Trim = "Õ«›Ÿ… «·‘Ìﬂ« " Then
                Me.CheckA.Checked = True
                Me.CheckB.Checked = False
                Me.CheckC.Checked = False
                Me.CheckD.Checked = False
                Me.CheckKS.Checked = False
                TR = CheckA.Checked
            ElseIf Me.ComboCheckStatus.Text.Trim = "‘Ìﬂ«  „Êœ∆⁄… ›Ì «·»‰ﬂ  Õ  «· Õ’Ì·" Then
                Me.CheckA.Checked = False
                Me.CheckB.Checked = True
                Me.CheckC.Checked = False
                Me.CheckD.Checked = False
                Me.CheckKS.Checked = False
                TR = CheckB.Checked
            ElseIf Me.ComboCheckStatus.Text.Trim = "„’—Ê›" Then
                Me.CheckA.Checked = False
                Me.CheckB.Checked = False
                Me.CheckC.Checked = False
                Me.CheckD.Checked = False
                Me.CheckKS.Checked = True
                TR = CheckKS.Checked
            ElseIf Me.ComboCheckStatus.Text.Trim = "‘Ìﬂ«  „—Ã⁄… (Ê«—œ…)" Then
                Me.CheckA.Checked = False
                Me.CheckB.Checked = False
                Me.CheckC.Checked = False
                Me.CheckD.Checked = True
                Me.CheckKS.Checked = False
                TR = CheckD.Checked
            ElseIf Me.ComboCheckStatus.Text.Trim = "‘Ìﬂ«  „—Ã⁄… (’«œ—Â)" Then
                Me.CheckA.Checked = False
                Me.CheckB.Checked = False
                Me.CheckC.Checked = False
                Me.CheckD.Checked = True
                Me.CheckKS.Checked = False
                TR = CheckD.Checked
            ElseIf Me.ComboCheckStatus.Text.Trim = "‘Ìﬂ«  „—Ã⁄… ›Ì «·»‰ﬂ" Then
                Me.CheckA.Checked = False
                Me.CheckB.Checked = False
                Me.CheckC.Checked = True
                Me.CheckD.Checked = False
                Me.CheckKS.Checked = False
                TR = CheckC.Checked
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Shared Sub TransforAccounts()
        'Try
        '        DebitAccount_Name = Nothing
        '        CredAccount_Name = Nothing
        '        FundAccount_Name = Nothing
        '        ChecksAccount_Name = Nothing
        '        nem = "Õ—ﬂ«  «·”Õ» Ê«·«Ìœ«⁄«  "
        '        nem1 = "«” ·«„ ‰ﬁœÌ „‰ Õ”«»" & " " & Me.ComboAccountType.Text
        '        nem2 = "’—› ‘Ìﬂ —ﬁ„ „‰ Õ”«»" & " " & Me.ComboAccountType.Text & "_" & Me.TextCheckNumber.Text
        '        PMO2 = 1
        '        ''Me.ComboCB1_SelectedIndexChanged(sender, e)

        '        NewMethod()

        '        Dim DocumentTapy As String
        '        If OBCHK1 = False Then
        '            DocumentTapy = "ﬁ»÷"
        '        Else
        '            DocumentTapy = "ﬁÌœ"
        '        End If
        '        SEARCHDATA.MAXIDMOVES()
        '        TransferToAccounts_Check = True

        '        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTCurrentBalance.EditValue, TEXTCurrentBalance.EditValue, T3, DocumentTapy, "WD", TextMovementSymbol.EditValue, False)
        '        If OBCHK1 = True Then
        '            If Me.Deposit = True Then  ' «Ìœ«⁄
        '                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTCredit.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '            ElseIf Me.Deposit = False Then ' ”Õ»
        '                nem1 = "’—› ‰ﬁœÌ „‰ Õ”«»" & " " & Me.ComboAccountType.Text
        '                DetailsAccountingEntries(PMO2, TextCreditAccount.Text, DebitAccount_No, TEXTDebit.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                DetailsAccountingEntries(PMO2 + 1, ComboDebitAccount.Text, CredAccount_NO, 0, TEXTDebit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '            End If
        '        Else
        '            If Me.ComboConstraintType.Text = "«Ìœ«⁄" Then
        '                Documenttype = "ﬁ»÷"
        '            Else
        '                Documenttype = "’—›"
        '            End If
        '            If CDbl(Me.TEXTCredit.EditValue) > 0 Then  ' «Ìœ«⁄
        '                If Me.ComboPaymentMethod1.Text.Trim = "‘Ìﬂ" Then
        '                    MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ÕÌ· «·Õ”«»  ›Ì Õ«·… ÿ—Ìﬁ… «·œ›⁄(‘Ìﬂ) ÌÃ»  €Ì— ÿ—Ìﬁ… «·œ›⁄ «·Ï ‰ﬁœ« ", 16, " ‰»ÌÂ")
        '                    Exit Sub
        '                End If
        '                If Me.ComboPaymentMethod1.Text.Trim = "‰ﬁœ«_‘Ìﬂ" Then
        '                    MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ÕÌ· «·Õ”«»  ›Ì Õ«·… ÿ—Ìﬁ… «·œ›⁄(‰ﬁœ«_‘Ìﬂ) ÌÃ»  €Ì— ÿ—Ìﬁ… «·œ›⁄ «·Ï ‰ﬁœ«", 16, " ‰»ÌÂ")
        '                    Exit Sub
        '                End If
        '                If Me.ComboPaymentMethod1.Text.Trim = "‰ﬁœ«" Then
        '                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, FundAccount_No, TEXTCredit.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, CredAccount_NO, 0, TEXTCredit.EditValue, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        '                    insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
        '                                                                  nem, False, TEXTID.EditValue & "0",
        '                                                                  False, True, ComboCB1.Text, Module1.CB2)
        '                End If
        '            Else ' ”Õ»

        '                nem1 = "’—› ‰ﬁœÌ „‰ Õ”«»" & " " & Me.ComboAccountType.Text
        '                If Me.ComboPaymentMethod1.Text.Trim = "‰ﬁœ«" Then
        '                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextFundValue.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, FundAccount_No, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        '                    insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
        '                                                                  nem1, False, TEXTID.EditValue & "0",
        '                                                                  False, True, ComboCB1.Text, Module1.CB2)
        '                ElseIf Me.ComboPaymentMethod1.Text.Trim = "‘Ìﬂ" Then
        '                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextValueOfCheck.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        '                    insert_Checks(TextCheckNumber.Text, maxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
        '                   TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4.ToString, True,
        '                   TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

        '                ElseIf Me.ComboPaymentMethod1.Text.Trim = "‰ﬁœ«_‘Ìﬂ" Then
        '                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTDebit.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                    DetailsAccountingEntries(PMO2 + 1, Module1.CB2.ToString, FundAccount_No, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
        '                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

        '                    insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), Documenttype.ToString, TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
        '                                                                  nem, False, TEXTID.EditValue & "0",
        '                                                                  False, True, ComboCB1.Text, Module1.CB2)

        '                    insert_Checks(TextCheckNumber.Text, maxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
        '                   TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4.ToString, True,
        '                   TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)
        '                End If
        '            End If
        '        End If
        '    Catch er As Exception
        '        MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    End Try
    End Sub

    Private Sub SaveMOVESDATARecord1()
        Try
            Dim A, C, S As String
            Dim Box2, Box3, Box4, Box5 As Integer
            nem = "„⁄«„·«  «·‘Ìﬂ« "
            pp = "1"
            A = TEXTTotal.Text
            S = "„⁄«„·«  «·‘Ìﬂ« "
            C = "0.00"
            'GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Module1.CB2, 1)
            'Box = CInt(ID_Nam)
            'GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Module1.CB2, 1)
            'Box1 = CInt(ID_Nam)

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            Box2 = CInt(ID_Nam)
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
            Box3 = CInt(ID_Nam)

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", List1.Text, 1)
            Box4 = CInt(ID_Nam)
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", List1.Text, 1)
            Box5 = CInt(ID_Nam)
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
                If CDbl(Me.TEXTCredit.EditValue) > 0 Then

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & CDbl(pp.ToString) & "','" & ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & TEXTCredit.EditValue & "','" & "0.00" & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & CDbl(pp.ToString) + 1 & "','" & TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & "0.00" & "','" & TEXTCredit.EditValue & "','" & nem.Trim & "','" & Box5.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                Else
                    .CommandText = "Insert Into MOVESDATA(MOVD2,MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & CDbl(pp.ToString) & "','" & ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & TEXTDebit.EditValue & "','" & "0.00" & "','" & S.Trim & "','" & Box3.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2,MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & CDbl(pp.ToString) + 1 & "','" & TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & "0.00" & "','" & TEXTDebit.EditValue & "','" & S.Trim & "','" & Box5.ToString.Trim & "','" & TextMovementSymbol.EditValue & "','" & TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
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
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
=======
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
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
            account_noF = CStr(ds2.Tables(0).Rows(0).Item(0))
            ACCF = CStr(ds2.Tables(0).Rows(0).Item(2))
            account_nameF = CStr(ds2.Tables(0).Rows(0).Item(1))
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
        ExResult = "Õ—ﬂ… ‘Ìﬂ«  »‰ﬂÌ…" & " " & ":" & " " & Me.TEXTID.EditValue & " " & "» «—ÌŒ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "··Õ”«»" & " " & ":" & " " & Me.ComboCheckDrawerName.Text & " " & "„À» … »ÊÀÌﬁ… —ﬁ„" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
        Me.LabelAutoEx.Text = ExResult
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

<<<<<<< HEAD
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
=======
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« .. €Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.TextMovementSymbol2.Text.ToString <> "KS" Then
                MsgBox("⁄›Ê« ... ·«Ì„ﬂ‰  —ÕÌ·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ·", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = CStr(SEARCHDATA.MOVDELET)
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = CStr(SEARCHDATA.MOV1DELET)
            Static P As Integer
            If Me.CheckTransferAccounts.Checked = False Then
                resault = MessageBox.Show("  ”»‰„  —ÕÌ· «·Õ—ﬂ… «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… " & "Õ”«» " & Me.ComboDebitAccount.Text, " —ÕÌ· «·ﬁÌÊœ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    Me.CheckTransferAccounts.Checked = True
                    P = Me.BS.Position
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
                    Click4 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show("  „  —ÕÌ· «·Õ—ﬂ… «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    P = Me.BS.Position
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
                    Click5 = True
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("Â·  —Ìœ Õ–› «·Õ—ﬂ… «·Õ«·Ï „‰ ÃœÊ· «·ﬁÌÊœ «·ÌÊ„Ì…", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                        Me.CheckTransferAccounts.Checked = False
                        P = Me.BS.Position
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

<<<<<<< HEAD
    Private Sub TEXTBOX4_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        If Me.CheckEW.Checked = False Then
            Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='Ê«—œ'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
    Private Sub TEXTBOX4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.CheckEW.Checked = False Then
            Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='Ê«—œ'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp1.Fill(ds, "Checks")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
            Else
                Me.TEXTTotal.Text = "0"
            End If
            Adp1.Dispose()
        ElseIf Me.CheckEW.Checked = True Then
            Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='’«œ—'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
<<<<<<< HEAD
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp1.Fill(ds, "Checks")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(1)) - Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Me.TEXTTotal.Text = "0"
            End If
            Adp1.Dispose()
        End If
        Consum.Close()
        Me.TEXTTotal.Text = Format(Val(TEXTTotal.Text) + Val(TEXTDebit.EditValue) - Val(TEXTCredit.EditValue), "0.000")
    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX5_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        If Me.CheckEW.Checked = False Then
            Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='Ê«—œ'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
    Private Sub TEXTBOX5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.CheckEW.Checked = False Then
            Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='Ê«—œ'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp1.Fill(ds, "Checks")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Val(ds.Tables(0).Rows(0).Item(1)), "0.000")
            Else
                Me.TEXTTotal.Text = "0"
            End If
            Adp1.Dispose()
        ElseIf Me.CheckEW.Checked = True Then
            Dim strsq1 As New SqlCommand("SELECT Sum(Checks.CH5) AS SumDEBIT,Sum(Checks.CH6) AS SumCREDIT FROM Checks  WHERE (Checks.CH17)='" & Me.ComboBN2.Text & "'" & "AND CH15='’«œ—'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
            Dim ds As New DataSet
<<<<<<< HEAD
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Adp1.Fill(ds, "Checks")
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(1)) - Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
            Else
                Me.TEXTTotal.Text = "0"
            End If
            Adp1.Dispose()
        End If
        Consum.Close()
        Me.TEXTTotal.Text = Format(Val(TEXTTotal.Text) + Val(TEXTDebit.EditValue) - Val(TEXTCredit.EditValue), "0.000")
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckStatus.TextChanged
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CH4  FROM Checks  WHERE CH1='" & Me.TextCheckNumber.Text & "'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
=======
    Private Sub ComboBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckStatus.TextChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CH4  FROM Checks  WHERE CH1='" & Me.TextCheckNumber.Text & "'" & "AND Checks.IDCH <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp1.Fill(ds, "Checks")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextPreviousCheckStatus.Text = CStr(ds.Tables(0).Rows(0).Item(0))
        Else
            Me.TextPreviousCheckStatus.Text = CStr(0)
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicAccountLevel.Click
=======
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
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
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
=======
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub

<<<<<<< HEAD
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
=======
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
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
    Private Sub CMENUA_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMENUA.Click
=======
    Private Sub CMENUA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENUA.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            If TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
            Me.TextKS1.Text = L2.Text
            Static P As Integer
            If Me.CheckA.Checked = False And Me.CheckB.Checked = False And Me.CheckC.Checked = False And Me.CheckD.Checked = False Then
                resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & " ÕÊÌ· " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then

                    Me.CheckA.Checked = True
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                    Click7 = True
                Else
                    Exit Sub
                End If
            ElseIf Me.CheckA.Checked = True And Me.CheckB.Checked = False And Me.CheckC.Checked = False And Me.CheckD.Checked = False Then
                resault = MessageBox.Show("  „  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï ”«»ﬁ««·Ï  " & " " & "Õ”«» " & Me.ComboCheckStatus.Text & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextA.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA4()
                        Me.DELETEDATMOVESDATA5()
                    End If
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                    Click8 = True
                    AccountingprocedureA()
                Else
                    resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then

                        If Me.TextA.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA4()
                            Me.DELETEDATMOVESDATA5()
                        End If
                        Me.CheckA.Checked = False
                        Me.CheckB.Checked = False
                        Me.CheckC.Checked = False
                        Me.CheckD.Checked = False
                        Me.CheckKS.Checked = False
                        Click9 = True
                    Else
                        Exit Sub
                    End If
                End If
                P = Me.BS.Position
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
            Else
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  ÕÊÌ· «·Õ”«» «·Ï Õ«›Ÿ… «·‘Ìﬂ« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub CMENUB_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMENUB.Click
=======
    Private Sub CMENUB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENUB.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If ComboDebitAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TextCreditAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Me.List1.Visible = True
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        Me.Button1_Click(sender, e)
        SEARCHDATA.MaxIDMoves()

        Static P As Integer
        Me.TextKS1.Text = L3.Text
        If Me.CheckA.Checked = True And Me.CheckB.Checked = False And Me.CheckC.Checked = False And Me.CheckD.Checked = False And Me.CheckKS.Checked = False Then
            resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & "Õ”«» " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Try
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = True
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click10 = True
            Else
                Exit Sub
            End If
        ElseIf Me.CheckA.Checked = False And Me.CheckB.Checked = True And Me.CheckC.Checked = False And Me.CheckD.Checked = False Then
            resault = MessageBox.Show("  „  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï ”«»ﬁ««·Ï  " & " " & "Õ”«» " & Me.ComboCheckStatus.Text & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If Me.TextB.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATMOVESDATA6()
                    Me.DELETEDATMOVESDATA7()
                End If
                Try
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = True
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click11 = True
                AccountingprocedureA()
            Else
                resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                    If Me.TextB.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA6()
                        Me.DELETEDATMOVESDATA7()
                    End If
                    Click12 = True
                Else
                    Exit Sub
                End If
            End If
            P = Me.BS.Position
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
        Else
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  ÕÊÌ· «·Õ”«» «·Ï ‘Ìﬂ«  „Êœ∆⁄… ›Ì «·»‰ﬂ  Õ  «· Õ’Ì·", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
    End Sub

<<<<<<< HEAD
    Private Sub CMENUC_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMENUC.Click
=======
    Private Sub CMENUC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENUC.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.ComboDebitAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.TextCreditAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Me.List1.Visible = True
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        Me.Button1_Click(sender, e)
        SEARCHDATA.MaxIDMoves()
        Static P As Integer
        Me.TextKS1.Text = L4.Text
        If Me.CheckA.Checked = False And Me.CheckB.Checked = True And Me.CheckC.Checked = False And Me.CheckD.Checked = False Then
            resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & "Õ”«» " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Try
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = True
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click16 = True
            Else
                Exit Sub
            End If
        ElseIf Me.CheckA.Checked = False And Me.CheckB.Checked = False And Me.CheckC.Checked = True And Me.CheckD.Checked = False Then
            resault = MessageBox.Show("  „  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï ”«»ﬁ««·Ï  " & " " & "Õ”«» " & Me.ComboCheckStatus.Text & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If Me.TextC.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATMOVESDATA8()
                    Me.DELETEDATMOVESDATA9()
                End If
                Me.SaveMOVES1()
                Me.SaveMOVESDATARecord1()
                Click17 = True
                AccountingprocedureA()
            Else
                resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextC.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA8()
                        Me.DELETEDATMOVESDATA9()
                    End If
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckKS.Checked = False
                    Click18 = True
                Else
                    Exit Sub
                End If
            End If
            P = Me.BS.Position
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
        Else
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  ÕÊÌ· «·Õ”«» «·Ï ‘Ìﬂ«  „—Ã⁄… ›Ì «·»‰ﬂ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If

    End Sub

<<<<<<< HEAD
    Private Sub CMENUD_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMENUD.Click
=======
    Private Sub CMENUD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENUD.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If ComboDebitAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TextCreditAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Me.List1.Visible = True
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        Me.Button1_Click(sender, e)
        SEARCHDATA.MaxIDMoves()
        Static P As Integer
        Me.TextKS1.Text = L5.Text
        If Me.CheckA.Checked = False And Me.CheckB.Checked = False And Me.CheckC.Checked = True And Me.CheckD.Checked = False Then
            resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & "Õ”«» " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Try
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = True
                    Me.CheckKS.Checked = False
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click19 = True
            Else
                Exit Sub
            End If
        ElseIf Me.CheckA.Checked = False And Me.CheckB.Checked = False And Me.CheckC.Checked = False And Me.CheckD.Checked = True Then
            resault = MessageBox.Show("  „  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï ”«»ﬁ««·Ï  " & " " & "Õ”«» " & Me.ComboCheckStatus.Text & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If Me.TextD.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATMOVESDATA10()
                    Me.DELETEDATMOVESDATA11()
                End If
                Try
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = True
                    Me.CheckKS.Checked = False
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click20 = True
                AccountingprocedureA()
            Else
                resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextD.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA10()
                        Me.DELETEDATMOVESDATA11()
                    End If
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                    Click21 = True
                Else
                    Exit Sub
                End If
            End If
            P = Me.BS.Position
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
        Else
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  ÕÊÌ· «·Õ”«» «·Ï  ‘Ìﬂ«  „—Ã⁄…(Ê«—œ…)«", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If

    End Sub

<<<<<<< HEAD
    Private Sub CMENUD1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMENUD1.Click
=======
    Private Sub CMENUD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENUD1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If ComboDebitAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TextCreditAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Me.List1.Visible = True
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        Me.Button1_Click(sender, e)
        SEARCHDATA.MaxIDMoves()
        Static P As Integer
        Me.TextKS1.Text = L5.Text
        Me.CheckD.Checked = True
        'If Me.CheckA.Checked = False And Me.CheckB.Checked = False And Me.CheckC.Checked = False And Me.CheckD.Checked = True Then
        If Me.CheckD.Checked = False Then
            resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & "Õ”«» " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Try
                    SaveMOVES1()
                    SaveMOVESDATARecord1()
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = True
                    Me.CheckKS.Checked = False
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click22 = True
            Else
                Exit Sub
            End If
        Else
            resault = MessageBox.Show("  „  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï ”«»ﬁ««·Ï  " & " " & "Õ”«» " & Me.ComboCheckStatus.Text & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If Me.TextC.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATMOVESDATA8()
                    Me.DELETEDATMOVESDATA9()
                End If
                Try
                    Me.SaveMOVES1()
                    Me.SaveMOVESDATARecord1()
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = True
                    Me.CheckKS.Checked = False
                Catch ex As Exception
                    MessageBox.Show(ex.Message & ex.Source)
                End Try
                Click23 = True
                AccountingprocedureA()
            Else
                resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then

                    If Me.TextC.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA8()
                        Me.DELETEDATMOVESDATA9()
                    End If
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                    Click24 = True
                Else
                    Exit Sub
                End If
            End If
            Exit Sub
        End If
        P = Me.BS.Position
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

        'Else
        'MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  ÕÊÌ· «·Õ”«» «·Ï ‘Ìﬂ«  „—Ã⁄…(’«œ—…)«", 16, " ‰»ÌÂ")
        'Exit Sub
        'End If
    End Sub

<<<<<<< HEAD
    Private Sub CMENUKS_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMENUKS.Click
=======
    Private Sub CMENUKS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENUKS.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If ComboDebitAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If TextCreditAccount.Text = "" Then
            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Me.List1.Visible = True
            Exit Sub
        End If
        Me.ComboCB1_SelectedIndexChanged(sender, e)
        TR = True
        Static P As Integer
        Me.Button1_Click(sender, e)
        SEARCHDATA.MaxIDMoves()
        Me.TextKS1.Text = L1.Text
        Dim ch As Double
        Dim ch1 As Double
        ch = Me.TEXTCredit.EditValue
        ch1 = Me.TextFundBalance.Text
        If Me.CheckKS.Checked = False Then
            If Me.CheckEW.Checked = True Then
                resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & "Õ”«» " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = True
                    Me.FundBalance()
                    If Me.TextCreditAccount.Text = ModuleGeneral.CB2.ToString Then
                        If Me.ComboCB1.Text.Trim = "" Then
                            MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ·  —ﬁ„ «·’‰œÊﬁ ›«—€", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                            Me.ComboCB1.Focus()
                            Exit Sub
                        End If
                        If ch1 < ch Then
                            MsgBox("⁄›Ê« ..  —’»œ «·’‰œÊﬁ ·« Ìﬂ›Ì ·Â–Â «·Õ—ﬂ…", 16, " ‰»ÌÂ")
                            Exit Sub
                        End If
                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, TEXTDebit.EditValue, TEXTCredit.EditValue, Me.Text,
                                 " ﬁÌœ ‘Ìﬂ —ﬁ„" & " _ " & Me.TextCheckNumber.Text, False, TEXTID.EditValue, False, True, ComboCB1.Text, CB2)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    Else
                        Insert_BANKJO(TEXTDebit.EditValue, TEXTCredit.EditValue, TextCheckNumber.Text, " ﬁÌœ ‘Ìﬂ", TextCheckNumber.Text & " " & "_" & " " & " : ﬁÌœ ‘Ìﬂ —ﬁ„", ComboBN2.Text, TextBN3.Text, TextMovementSymbol.EditValue, False, True, ComboCB1.Text)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    End If
                    Click13 = True
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show("  ”»‰„  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï «·Ï  " & "Õ”«» " & Me.ComboCheckStatus.Text, " ÕÊÌ· «·‘Ìﬂ« ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = True

                    If Me.ComboDebitAccount.Text.Trim = ModuleGeneral.CB2.ToString.Trim Then
                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, TEXTDebit.EditValue, TEXTCredit.EditValue, Me.Text,
                                 " ﬁÌœ ‘Ìﬂ —ﬁ„" & " _ " & Me.TextCheckNumber.Text, False, TEXTID.EditValue, False, True, ComboCB1.Text, CB2)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    Else
                        Insert_BANKJO(TEXTDebit.EditValue, TEXTCredit.EditValue, TextCheckNumber.Text, " ﬁÌœ ‘Ìﬂ", TextCheckNumber.Text & " " & "_" & " " & " : ﬁÌœ ‘Ìﬂ —ﬁ„", ComboBN2.Text, TextBN3.Text, TextMovementSymbol.EditValue, False, True, ComboCB1.Text)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    End If
                    Click13 = True
                Else
                    Exit Sub
                End If
            End If
        Else
            resault = MessageBox.Show("  „  ÕÊÌ· Õ—ﬂ… «·‘Ìﬂ «·Õ«·Ï ”«»ﬁ««·Ï  " & " " & "Õ”«» " & Me.ComboCheckStatus.Text & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If Me.TextKS.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATMOVESDATA2()
                    Me.DELETEDATMOVESDATA3()
                End If

                If Me.TextBankTransactionNumber.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·»‰ﬂ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATBANK()
                End If
                If Me.TextFundMovementNumber.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", CType(16, MsgBoxStyle), " ‰»Ì…")
                Else
                    Me.DELETEDATACASHIER()
                End If
                If Me.CheckEW.Checked = True Then
                    If Me.TextCreditAccount.Text = ModuleGeneral.CB2 Then
                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, TEXTDebit.EditValue, TEXTCredit.EditValue, Me.Text,
                                 " ﬁÌœ ‘Ìﬂ —ﬁ„" & " _ " & Me.TextCheckNumber.Text, False, TEXTID.EditValue, False, True, ComboCB1.Text, CB2)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    Else
                        Insert_BANKJO(TEXTDebit.EditValue, TEXTCredit.EditValue, TextCheckNumber.Text, " ﬁÌœ ‘Ìﬂ", TextCheckNumber.Text & " " & "_" & " " & " : ﬁÌœ ‘Ìﬂ —ﬁ„", ComboBN2.Text, TextBN3.Text, TextMovementSymbol.EditValue, False, True, ComboCB1.Text)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    End If
                Else
                    If Me.ComboDebitAccount.Text = ModuleGeneral.CB2 Then
                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, TEXTDebit.EditValue, TEXTCredit.EditValue, Me.Text,
                                 " ﬁÌœ ‘Ìﬂ —ﬁ„" & " _ " & Me.TextCheckNumber.Text, False, TEXTID.EditValue, False, True, ComboCB1.Text, CB2)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    Else
                        Insert_BANKJO(TEXTDebit.EditValue, TEXTCredit.EditValue, TextCheckNumber.Text, " ﬁÌœ ‘Ìﬂ", TextCheckNumber.Text & " " & "_" & " " & " : ﬁÌœ ‘Ìﬂ —ﬁ„", ComboBN2.Text, TextBN3.Text, TextMovementSymbol.EditValue, False, True, ComboCB1.Text)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                    End If
                End If
                AccountingprocedureA()
            Else
                resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextKS.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATMOVESDATA2()
                        Me.DELETEDATMOVESDATA3()
                    End If
                    If Me.TextBankTransactionNumber.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·»‰ﬂ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATBANK()
                    End If
                    If Me.TextFundMovementNumber.Text = "" Then
                        MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", CType(16, MsgBoxStyle), " ‰»Ì…")
                    Else
                        Me.DELETEDATACASHIER()
                    End If

                    Me.CheckA.Checked = False
                    Me.CheckB.Checked = False
                    Me.CheckC.Checked = False
                    Me.CheckD.Checked = False
                    Me.CheckKS.Checked = False
                    Click15 = True
                Else
                    Exit Sub
                End If
            End If
        End If
        P = Me.BS.Position
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
    End Sub

    Private Sub SEARCHFROM()
        Try
            If Me.TextMovementSymbol2.Text.ToString.Trim = "SD" Then ' ‘Â«œ«  «·«”Â„ _ «·Êœ«∆⁄ SD
                SEARCHDATA.SEARCHID2(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.TBNK1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "WD" Then '«·”Õ» Ê«·≈Ìœ«⁄ WD
                SEARCHDATA.SEARCHID3(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.TBNK1A)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "BA" Then  '«·»‰ﬂ 
                SEARCHDATA.SEARCHID4(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.EBNK1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "BT" Then   '›« Ê—… ‰ﬁ·   
                SEARCHDATA.SEARCHID5(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.PTRO1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "TL" Then   '›« Ê—… ‰ﬁ·  ›’Ì·Ì…  
                SEARCHDATA.SEARCHID6(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.PTRO1A)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "ER" Then '„  Œ·Ì’ 
                SEARCHDATA.SEARCHID7(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.CEMP3)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "GE" Then  '„ . ⁄«„…  
                SEARCHDATA.SEARCHID8(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.CST1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "PR" Then '«·„‘ —Ì«  
                SEARCHDATA.SEARCHID9(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.BUY1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "VE" Then '«·„»Ì⁄«  
                SEARCHDATA.SEARCHID10(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.SLS1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "PA" Then '«·œ›⁄« 
                SEARCHDATA.SEARCHID(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.Loa1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "LO" Then '«·–„„ «·„œÌ‰…
                SEARCHDATA.SEARCHID1(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.Lo1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "ES" Then
                SEARCHDATA.SEARCHID12(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.SLY1)
            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "AS" Then
                SEARCHDATA.SEARCHEMPCOSTID(Me.TextMovementSymbol.EditValue)
                Me.TextMovementSourceNumber.Text = CStr(SEARCHDATA.IDEmpCost)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSEARCHFROM", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementSourceNumber.Click
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementSourceNumber.Click
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.TextMovementSymbol2.Text.ToString.Trim = "SD" Then ' ‘Â«œ«  «·«”Â„ _ «·Êœ«∆⁄ SD
                Dim f1 As New FrmDeposits With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                f1.Show()
                f1.DanLOd()

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "WD" Then '«·”Õ» Ê«·≈Ìœ«⁄ WD
                Dim f2 As New FrmTransaction With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                f2.Show()
                f2.DanLOd()

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "BA" Then  '«·»‰ﬂ 
                Dim f3 As New FrmJO With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                f3.Show()
                f3.DanLOd()

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "BT" Then   '›« Ê—… ‰ﬁ·   
                Dim f4 As New FrmTRANSPORT With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                f4.Show()
                f4.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "TL" Then   '›« Ê—… ‰ﬁ·  ›’Ì·Ì…  
                Dim f5 As New FrmInvoice With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                f5.Show()
                f5.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "ER" Then '„  Œ·Ì’ 
                Dim f6 As New FrmCUSTOMER11 With {
                    .TB1 = Me.TextMovementSourceNumber.Text
                }
                f6.Show()
                f6.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "GE" Then  '„ . ⁄«„…  
                Dim f7 As New FrmMyCosts With {
                    .TB1 = CInt(Trim(Me.TextMovementSourceNumber.Text))
                }
                f7.Show()
                f7.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "PR" Then '«·„‘ —Ì«  
                Dim f8 As New FrmSuppliesA
                If Me.RadioButton4.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                f8.TB1 = Trim(TextMovementSourceNumber.Text)
                f8.Show()
                f8.Load1_Click(sender, e)

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "VE" Then '«·„»Ì⁄«  
                Dim f9 As New FrmCustomersA
                If Me.RadioButton4.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                f9.TB1 = Trim(Me.TextMovementSourceNumber.Text)
                f9.Show()
<<<<<<< HEAD
                f9.DanLOd()
=======
                f9.Load_Click(sender, e)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "LO" Then '«·–„„ «·„œÌ‰…
                Dim f As New Loans With {
                    .TB1 = Trim(Me.TextMovementSourceNumber.Text)
                }
                f.Show()
                f.Load_Click(sender, e)

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "PA" Then '«·œ›⁄« 
                Dim ds10 As New DataSet
<<<<<<< HEAD
                Dim SqlDataAdapter10 As New SqlDataAdapter
=======
                Dim SqlDataAdapter10 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim f As New SuppliersPay
                ds10.EnforceConstraints = False
                Consum.Open()
                Dim str As New SqlCommand("SELECT Loa1 FROM LoansPa WHERE   CUser='" & CUser & "' and Year(Loa5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY Loa1", Consum)
<<<<<<< HEAD
                SqlDataAdapter1 = New SqlDataAdapter(str)
=======
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds10.Clear()
                Consum.Close()
                SqlDataAdapter10.Fill(ds10, "LoansPa")
                f.BS.DataMember = "LoansPa"
                f.BS.DataSource = ds10
                Dim index As Integer
                index = f.BS.Find("Loa1", Me.TextMovementSourceNumber.Text)
                f.Show()
                f.BS.Position = index
                SqlDataAdapter10.Dispose()
                Consum.Close()

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "ES" Then
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter
                Dim employees As New FormEmployees4
                dataSet.EnforceConstraints = False
                Dim selectCommand As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE   CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY SLY1", Consum)
                adapter = New SqlDataAdapter(selectCommand)
                Dim builder12 As New SqlCommandBuilder(adapter)
                dataSet.Clear()
                Consum.Open()
                adapter.Fill(dataSet, "SALARIES")
                employees.BS.DataMember = "SALARIES"
                employees.BS.DataSource = dataSet
                Dim num12 As Integer = employees.BS.Find("SLY1", Me.TextMovementSourceNumber.Text)
                employees.Show()
                employees.Load1.PerformClick()
                employees.BS.Position = num12
                adapter.Dispose()
                Consum.Close()

            ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "AS" Then
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter
                Dim employees As New FrmEmpCost
                dataSet.EnforceConstraints = False
                Dim selectCommand As New SqlCommand("SELECT CST1 FROM EMPCOST WHERE   CUser ='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CST1", Consum)
                adapter = New SqlDataAdapter(selectCommand)
                Dim builder12 As New SqlCommandBuilder(adapter)
                dataSet.Clear()
                Consum.Open()
                adapter.Fill(dataSet, "EMPCOST")
                employees.BS.DataMember = "EMPCOST"
                employees.BS.DataSource = dataSet
                Dim num12 As Integer = employees.BS.Find("CST1", Me.TextMovementSourceNumber.Text)
                employees.Show()
                employees.load1.PerformClick()
                employees.BS.Position = num12
                adapter.Dispose()
                Consum.Close()
            Else
                Me.TextMovementSourceNumber.Text = Me.TEXTStatement.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub DELETEDATBANK()
        Try
            MYDELETERECORD("BANKJO", "EBNK1", TextBankTransactionNumber, BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub PBS_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PBS.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBS.Click
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
            index = f.BS.Find("MOV2", Me.TextKS.Text)
            f.TB2 = Me.TextKS.Text.Trim
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicBankTransactionNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicBankTransactionNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmJO
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT EBNK1 FROM BANKJO WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY EBNK1", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "BANKJO")
            f.BS.DataMember = "BANKJO"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("EBNK1", Me.TextBankTransactionNumber.Text.Trim)
            f.TB1 = Me.TextBankTransactionNumber.Text
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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
    Private Sub PBA_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PBA.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PBA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBA.Click
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
            index = f.BS.Find("MOV2", Me.TextA.Text.Trim)
            f.TB2 = Me.TextA.Text.Trim
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
    Private Sub PBB_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PBB.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PBB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBB.Click
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
            index = f.BS.Find("MOV2", Me.TextB.Text.Trim)
            f.TB2 = Me.TextB.Text.Trim
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
    Private Sub PBC_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PBC.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PBC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBC.Click
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
            index = f.BS.Find("MOV2", Me.TextC.Text.Trim)
            f.TB2 = Me.TextC.Text.Trim
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
    Private Sub PBD_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PBD.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PBD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PBD.Click
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
            index = f.BS.Find("MOV2", Me.TextD.Text.Trim)
            f.TB2 = Me.TextD.Text.Trim
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
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPrintReceiptDischarge.Click
=======
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintReceiptDischarge.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", CType(16, MsgBoxStyle), " ‰»ÌÂ")
            Exit Sub
        End If
        On Error Resume Next
        Dim txtFROMDate As String
        Dim txtToDate As String
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
<<<<<<< HEAD
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmPRINT
        Dim ds As New DataSet
        If RdRes.Checked = True Then
            Dim rpt As New rptChecks11
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim strAs1 As New SqlCommand("SELECT * FROM Checks  WHERE IDCH ='" & Me.TEXTID.EditValue & "'" & "AND CH10='" & Me.ComboConstraintType.Text & "'", Consum)
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(strAs1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strAs1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                Dim txt As TextObject
                Dim txt1 As TextObject
                f.CrystalReportViewer1.ReportSource = rpt
                ' txt = rpt.Section1.ReportObjects("Text8")
                ' txt.Text = "Œ·«· «·› —… „‰  " & Format(Me.DateTimePicker3.Value, "dd - MM - yyyy") & "  «·Ï  " & Format(Me.DateTimePicker4.Value, "dd - MM - yyyy")
                txt1 = CType(rpt.Section1.ReportObjects("TEXT6"), TextObject)
                txt1.Text = CurrencyJO(CDec(ds.Tables(0).Rows(0).Item("CH5")), "jO")
                txt1 = CType(rpt.Section1.ReportObjects("TEXT69"), TextObject)
                txt1.Text = CurrencyJO(CDec(ds.Tables(0).Rows(0).Item("CH5")), "jO")

                'txt1 = rpt.Section1.ReportObjects("TEXT1")
                'txt1.Text = Me._Type1
                'txt1 = rpt.Section1.ReportObjects("TEXT2")
                'txt1.Text = Me._Type1
                txt1 = CType(rpt.Section1.ReportObjects("TEXT15"), TextObject)
                txt1.Text = Me.TextKS.Text
                txt1 = CType(rpt.Section1.ReportObjects("TEXT16"), TextObject)
                txt1.Text = Me.TextKS.Text

                txt = CType(rpt.Section1.ReportObjects("Text7"), TextObject)
                txt.Text = AssociationName
                txt = CType(rpt.Section1.ReportObjects("TEXT9"), TextObject)
                txt.Text = Directorate
                txt = CType(rpt.Section1.ReportObjects("TEXT42"), TextObject)
                txt.Text = Character
                txt = CType(rpt.Section1.ReportObjects("TEXT40"), TextObject)
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1

                txt = CType(rpt.Section1.ReportObjects("TEXT44"), TextObject)
                txt.Text = Recorded

                txt = CType(rpt.Section1.ReportObjects("Text56"), TextObject)
                txt.Text = AssociationName
                txt = CType(rpt.Section1.ReportObjects("TEXT64"), TextObject)
                txt.Text = Directorate
                txt = CType(rpt.Section1.ReportObjects("TEXT63"), TextObject)
                txt.Text = Character
                txt = CType(rpt.Section1.ReportObjects("Text77"), TextObject)
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1

                txt = CType(rpt.Section1.ReportObjects("Text76"), TextObject)
                txt.Text = Recorded

                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            Else
                MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        ElseIf Me.RdCus.Checked = True Then
            Dim ds1 As New DataSet
            Dim rpt As New rptChecks21
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim strAs2 As New SqlCommand("SELECT * FROM Checks  WHERE IDCH ='" & Me.TEXTID.EditValue & "'" & "AND CH10='" & Me.ComboConstraintType.Text & "'", Consum)
            Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(strAs2)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strAs2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "Checks")
            rpt.SetDataSource(ds1)
            If ds1.Tables(0).Rows.Count > 0 Then
                Dim txt As TextObject
                Dim txt1 As TextObject
                f.CrystalReportViewer1.ReportSource = rpt
                ' txt = rpt.Section1.ReportObjects("Text8")
                ' txt.Text = "Œ·«· «·› —… „‰  " & Format(Me.DateTimePicker3.Value, "dd - MM - yyyy") & "  «·Ï  " & Format(Me.DateTimePicker4.Value, "dd - MM - yyyy")
                txt1 = CType(rpt.Section1.ReportObjects("Text4"), TextObject)
                txt1.Text = CurrencyJO(CDec(ds1.Tables(0).Rows(0).Item("CH6")), "jO")
                txt1 = CType(rpt.Section1.ReportObjects("Text90"), TextObject)
                txt1.Text = CurrencyJO(CDec(ds1.Tables(0).Rows(0).Item("CH6")), "jO")

                'txt1 = rpt.Section1.ReportObjects("TEXT15")
                'txt1.Text = Me._Type1
                'txt1 = rpt.Section1.ReportObjects("TEXT22")
                'txt1.Text = Me._Type1
                txt1 = CType(rpt.Section1.ReportObjects("TEXT6"), TextObject)
                txt1.Text = Me.TextKS.Text
                txt1 = CType(rpt.Section1.ReportObjects("TEXT21"), TextObject)
                txt1.Text = Me.TextKS.Text

                txt = CType(rpt.Section1.ReportObjects("Text7"), TextObject)
                txt.Text = AssociationName
                txt = CType(rpt.Section1.ReportObjects("TEXT9"), TextObject)
                txt.Text = Directorate

                txt = CType(rpt.Section1.ReportObjects("TEXT42"), TextObject)
                txt.Text = Character
                txt = CType(rpt.Section1.ReportObjects("TEXT40"), TextObject)
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1

                txt = CType(rpt.Section1.ReportObjects("TEXT44"), TextObject)
                txt.Text = Recorded

                txt = CType(rpt.Section1.ReportObjects("Text18"), TextObject)
                txt.Text = AssociationName
                txt = CType(rpt.Section1.ReportObjects("TEXT19"), TextObject)
                txt.Text = Directorate

                txt = CType(rpt.Section1.ReportObjects("TEXT50"), TextObject)
                txt.Text = Character
                txt = CType(rpt.Section1.ReportObjects("Text48"), TextObject)
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1

                txt = CType(rpt.Section1.ReportObjects("Text45"), TextObject)
                txt.Text = Recorded

                'txt = rpt.Section1.ReportObjects("Text32")
                'txt.Text = Me.ComboBox9.Text
                'txt = rpt.Section1.ReportObjects("Text91")
                'txt.Text = Me.ComboBox9.Text
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            Else
                MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        End If
        '  Catch ex As Exception
        'MessageBox.Show(ex.Message & ex.Source)
        '   End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonUpdateA.Click
=======
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            PictureBox2.Visible = True
<<<<<<< HEAD
            RefreshTab = New BackgroundWorker With {
=======
            RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboCheckStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckStatus.SelectedIndexChanged
=======
    Private Sub ComboCheckStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckStatus.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'Me.ComboDebitAccount.DataSource = GetDataCheck()
        'Me.ComboDebitAccount.DisplayMember = "account_name"
        'Me.List1.DataSource = GetDataCheck()
        'Me.List1.DisplayMember = "account_name"
        ComboBoxTrueFalse()

        'If Me.ComboBox2.Text.Trim = "Õ«›Ÿ… «·‘Ìﬂ« " Then
        '    Me.CheckA.Checked = True
        '    Me.CheckKS.Checked = False
        '    Me.CheckB.Checked = False
        '    Me.CheckD.Checked = False
        '    Me.CheckC.Checked = False
        'ElseIf Me.ComboBox2.Text.Trim = "‘Ìﬂ«  „Êœ∆⁄… ›Ì «·»‰ﬂ  Õ  «· Õ’Ì·" Then
        '    Me.CheckB.Checked = True
        '    Me.CheckKS.Checked = False
        '    Me.CheckA.Checked = False
        '    Me.CheckD.Checked = False
        '    Me.CheckC.Checked = False
        'ElseIf Me.ComboBox2.Text.Trim = "„’—Ê›" Then
        '    Me.CheckKS.Checked = True
        '    Me.CheckA.Checked = False
        '    Me.CheckB.Checked = False
        '    Me.CheckD.Checked = False
        '    Me.CheckC.Checked = False
        'ElseIf Me.ComboBox2.Text.Trim = "‘Ìﬂ«  „—Ã⁄… (Ê«—œ…)" Then
        '    Me.CheckD.Checked = True
        '    Me.CheckKS.Checked = False
        '    Me.CheckA.Checked = False
        '    Me.CheckB.Checked = False
        '    Me.CheckC.Checked = False
        'ElseIf Me.ComboBox2.Text.Trim = "‘Ìﬂ«  „—Ã⁄… (’«œ—Â)" Then
        '    Me.CheckD.Checked = True
        '    Me.CheckKS.Checked = False
        '    Me.CheckA.Checked = False
        '    Me.CheckB.Checked = False
        '    Me.CheckC.Checked = False
        'ElseIf Me.ComboBox2.Text.Trim = "‘Ìﬂ«  „—Ã⁄… ›Ì «·»‰ﬂ" Then
        '    Me.CheckC.Checked = True
        '    Me.CheckKS.Checked = False
        '    Me.CheckA.Checked = False
        '    Me.CheckB.Checked = False
        '    Me.CheckD.Checked = False
        'End If
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCheckStatus.LostFocus
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CH4  FROM Checks  WHERE CH1='" & Me.TextCheckNumber.Text & "'AND Checks.CH1 <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsq1)
=======
    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCheckStatus.LostFocus
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT CH4  FROM Checks  WHERE CH1='" & Me.TextCheckNumber.Text & "'AND Checks.CH1 <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds, "Checks")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextPreviousCheckStatus.Text = CStr(ds.Tables(0).Rows(0).Item(0))
        Else
            Me.TextPreviousCheckStatus.Text = CStr(0)
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles ComboCheckStatus.KeyUp
=======
    Private Sub ComboBox2_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboCheckStatus.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.ComboConstraintType.Focus()
        End Select
    End Sub

<<<<<<< HEAD
    Private Sub ComboBoxA2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboCheckStatus.KeyPress
=======
    Private Sub ComboBoxA2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCheckStatus.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Char.IsControl(e.KeyChar) = False Then
            If Char.IsDigit(e.KeyChar) Then
            Else
                e.Handled = True
            End If
        End If
        If Asc(e.KeyChar) = Keys.Enter Then
            ComboCurrentCheckStatus.Focus()
            Me.ComboCurrentCheckStatus.Text = Me.ComboCheckStatus.Text
        End If
    End Sub

<<<<<<< HEAD
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SEARCHDATA.MaxIDMoves()

        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = CStr(SEARCHDATA.Account_No)
        Me.ACCF = CStr(SEARCHDATA.ACC)
        Me.account_nameF = SEARCHDATA.Account_Name
        If Me.TextMovementSymbol2.Text.ToString.Trim = "PR" Then '«·„‘ —Ì«  
            SEARCHDATA.SEARCHBUYSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioButton4.Checked = CBool(Conversion.Val(SEARCHDATA.BUYCASH))
        ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "VE" Then '«·„»Ì⁄«  
            SEARCHDATA.SEARCHSLSCASH(Me.TextMovementSymbol.EditValue)
            Me.RadioButton4.Checked = CBool(Conversion.Val(SEARCHDATA.SLSCASH))
        End If
        If Me.CheckEW.Checked = True Then
            SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
            Me.TextMovementRestrictions.Text = CStr(Conversion.Val(SEARCHDATA.MOV1C))
        ElseIf Me.CheckEW.Checked = False Then
            SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
            Me.TextMovementRestrictions.Text = CStr(Conversion.Val(SEARCHDATA.MOV1B))
        End If
        If Me.TextMovementSymbol2.Text.ToString.Trim = "VE" Then
            SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
            Me.TextMovementRestrictions.Text = CStr(Conversion.Val(SEARCHDATA.MOV1C))
        ElseIf Me.TextMovementSymbol2.Text.ToString.Trim = "KS" Then
            SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
            Me.TextMovementRestrictions.Text = CStr(Conversion.Val(SEARCHDATA.MOV1C))
        End If

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = CStr(SEARCHDATA.MOVDELET)
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = CStr(SEARCHDATA.MOV1DELET)

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue & "0")
        Me.TextFundMovementNumber.Text = CStr(SEARCHDATA.CSH1)

        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
        Me.TextFundMovementNumber.Text = CStr(SEARCHDATA.CSH1B)

        SEARCHDATA.SEARCHBANKJO(Me.TextMovementSymbol.EditValue)
        Me.TextBankTransactionNumber.Text = CStr(SEARCHDATA.EBNK1JO)

        SEARCHDATA.SEARCHMOVESKS(Me.TextMovementSymbol.EditValue)
        Me.TextKS.Text = CStr(SEARCHDATA.MOV2KS)
        SEARCHDATA.SEARCHMOVESKSA(Me.TextMovementSymbol.EditValue)
        Me.TextA.Text = CStr(SEARCHDATA.MOV2KSA)
        SEARCHDATA.SEARCHMOVESKSB(Me.TextMovementSymbol.EditValue)
        Me.TextB.Text = CStr(SEARCHDATA.MOV2KSB)
        SEARCHDATA.SEARCHMOVESKSC(Me.TextMovementSymbol.EditValue)
        Me.TextC.Text = CStr(SEARCHDATA.MOV2KSC)
        SEARCHDATA.SEARCHMOVESKSD(Me.TextMovementSymbol.EditValue)
        Me.TextD.Text = CStr(SEARCHDATA.MOV2KSD)
        Me.SEARCHFROM()

    End Sub

<<<<<<< HEAD
    Private Sub FrmChecks_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
=======
    Private Sub FrmChecks_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("⁄⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… ≈—›«ﬁ «·„” ‰œ« ", CType(16, MsgBoxStyle), " ‰»ÌÂ")
                Exit Sub
            End If
<<<<<<< HEAD
            GetAutoNumberMyDOCUMENTSFL(TextMovementSymbol.EditValue)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim f As New FrmJPG0
            f.Show()
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
=======
           Dim XLO As Int64
            XLO = CInt(Me.TEXTID.EditValue)
            Dim f As New FrmJPG0
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
<<<<<<< HEAD
            f.BS.EndEdit()
            f.BS.AddNew()
            f.MAXRECORD()
            f.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = documentId
=======

            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
            f.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = CStr(Val(XLO))
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.TEXTFileSubject.Text = "„” ‰œ«  «·‘Ìﬂ« "
            f.TextFileDescription.Text = "«—›«ﬁ „” ‰œ«  «·‘Ìﬂ« "
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
                Dim DOC1 As String = Strings.Trim(CStr(ds41.Tables(0).Rows(0).Item(0)))
                Dim LO As String = Trim(CStr(ds41.Tables(0).Rows(0).Item(1)))
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
                MsgBox("·« ÌÊÃœ «Ì „” ‰œ« ", CType(64 + 524288, MsgBoxStyle), " ‰»ÌÂ")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()

    End Sub

<<<<<<< HEAD
    Private Sub TEXTBOX10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboConstraintType.SelectedIndexChanged
=======
    Private Sub TEXTBOX10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboConstraintType.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        AccountsEnquiry()
    End Sub

    Private Sub AccountsEnquiry()
        On Error Resume Next
        Select Case Me.ComboConstraintType.Text
            Case "ﬁ»÷"
                Me.CheckEW.Checked = False
                Me.TEXTCredit.EditValue = 0
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = False
            Case "’—›"
                Me.CheckEW.Checked = True
                Me.TEXTDebit.EditValue = 0
                Me.TEXTDebit.Enabled = False
                Me.TEXTCredit.Enabled = True

        End Select
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
            Me.TextBN4.Text = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            Me.TextBN4.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
=======
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call Me.AddType1()
    End Sub

    Private Sub AddType1()
        On Error Resume Next
        If Me.RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
            Me.TextCheckDrawerNumber.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub

<<<<<<< HEAD
    Private Sub ComboCheckDrawerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboCheckDrawerName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
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
                    Me.TextCheckDrawerNumber.Text = ds.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerNumber.Text = 0
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
                    Me.TextCheckDrawerNumber.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerNumber.Text = 0
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
                    Me.TextCheckDrawerNumber.Text = ds2.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerNumber.Text = 0
                End If
                Adp2.Dispose()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            Dim Adp As SqlDataAdapter
            Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim Adp As SqlClient.SqlDataAdapter
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
            FundBalance()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCB1_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub


End Class