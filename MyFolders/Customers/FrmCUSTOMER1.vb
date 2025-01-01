Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCUSTOMER1
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
    Dim pp As Integer
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Dim dt1 As Date
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String

    Dim CHK As Boolean = False
    Private Sub FrmCUSTOMER1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub

    Private Sub FrmCUSTOMER1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.TabPage3.Show()
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.TabPage3.Show()
                        Me.ButtonXP4_Click(sender, e)
                    Case Keys.F9
                        Me.ButtonSearch_Click(sender, e)
                    Case Keys.F10
                        Me.TRANSFERBUTTON_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonXP6_Click(sender, e)
                    Case Keys.F12
                        Me.CHK = True
                        Me.InternalAuditorType()
                        Me.EDITBUTTON.Enabled = False
                        Me.DELETEBUTTON.Enabled = False
                        Me.BALANCEBUTTON.Enabled = False
                        Me.InternalAuditorERBUTTON.Enabled = False
                        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
                    Case Keys.F5 And (e.Alt And Not e.Control And Not e.Shift)
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        Me.BALANCEBUTTON_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonXP5_Click(sender, e)
                    Case Keys.K And (e.Alt And Not e.Control And Not e.Shift)
                        Me.TabPage3.Show()
                        Me.Buttoncalcluter_Click(sender, e)
                    Case Keys.M And (e.Alt And Not e.Control And Not e.Shift)
                        Me.TabControl1.SelectedIndex = 1
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
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonPREEVIEW.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtoncustomerPayment.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.ComboCustomerName.Enabled = False
            Me.TextDateMovementHistory.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTType.Enabled = False
            Me.ComboSource.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TextCondition.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            'Me.Panel1.Enabled = False

        ElseIf Me.CheckTransferToAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonPREEVIEW.Enabled = True
            Me.ButtonSearch.Enabled = True

            Me.ButtoncustomerPayment.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True
            If Me.TextLSet1.Text.ToString <> "CA" Then
                Me.ButtonTransferofAccounts.Enabled = False
            Else
                Me.ButtonTransferofAccounts.Enabled = True
            End If
            Me.ComboCustomerName.Enabled = False
            Me.TextDateMovementHistory.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTType.Enabled = False
            Me.ComboSource.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TextCondition.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.Panel1.Enabled = True
            If Me.CHK = True Then
                Me.ComboCustomerName.Enabled = True
                Me.TextDateMovementHistory.Enabled = True
                Me.DateMovementHistory.Enabled = True
                Me.TEXTType.Enabled = True
                Me.ComboSource.Enabled = True
                Me.TEXTDebit.Enabled = True
                Me.TEXTCredit.Enabled = True
                Me.TEXTDocumentNumber.Enabled = True
                Me.TextCondition.Enabled = True
                Me.TEXTStatement.Enabled = True
                Me.ComboPaymentMethod.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.ComboCheckDrawerName.Enabled = True
                Me.GroupPaymentMethod.Enabled = True
                Me.GroupCHKS1.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.Panel1.Enabled = True
            End If
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BALANCEBUTTON.Enabled = False
            Me.ButtonUpdateA.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonPREEVIEW.Enabled = True
            Me.ButtonSearch.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtoncustomerPayment.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = False

            Me.ComboCustomerName.Enabled = False
            Me.TextDateMovementHistory.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTType.Enabled = False
            Me.ComboSource.Enabled = False
            Me.TEXTDebit.Enabled = False
            Me.TEXTCredit.Enabled = False
            Me.TEXTDocumentNumber.Enabled = False
            Me.TextCondition.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            'Me.Panel1.Enabled = False

        Else
            Me.SHOWBUTTON()
            Me.ComboCustomerName.Enabled = True
            Me.TextDateMovementHistory.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.TEXTType.Enabled = True
            Me.ComboSource.Enabled = True
            Me.TEXTDebit.Enabled = True
            Me.TEXTCredit.Enabled = True
            Me.TEXTDocumentNumber.Enabled = True
            Me.TextCondition.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.ComboPaymentMethod.Enabled = True
            Me.TextFundValue.Enabled = True
            Me.TextValueOfCheck.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.Panel1.Enabled = True
        End If
    End Sub
    Private Sub FrmCUSTOMER1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmCUSTOMER1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage3.Show()
    End Sub

    Private Sub FrmCUSTOMER1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.ButtonUpdateA.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.ButtonPREEVIEW.Enabled = False
        Me.ButtonSearch.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtoncustomerPayment.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.ButtonXP1.Enabled = False
        Me.ButtonXP2.Enabled = False
        Me.ButtonXP3.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        Me. AccountsEnquiry()

        Me.CHK = False
        Me.BackWorker2.WorkerReportsProgress = True
        Me.BackWorker2.WorkerSupportsCancellation = True
        Me.BackWorker3.WorkerReportsProgress = True
        Me.BackWorker3.WorkerSupportsCancellation = True

        'MakeButtonMultiline(ButtonXP3)

        'MakeButtonMultiline(ButtonXP2)


    End Sub
    Private Sub ButtonXP2_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ButtonXP2.Paint
        e.Graphics.TranslateTransform(25, 30)
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString("الغاء التــحـديـد", ButtonXP2.Font, Brushes.SteelBlue, 0, 0)

    End Sub
    Private Sub ButtonXP3_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles ButtonXP3.Paint
        e.Graphics.TranslateTransform(25, 30)
        e.Graphics.RotateTransform(90)
        e.Graphics.DrawString("تـحـديـد الكـل", ButtonXP3.Font, Brushes.SteelBlue, 0, 0)

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
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCustomerName, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCustomerName1, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.TEXTStatement, e, )
    End Sub
    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CAB24, CAB25, CAB26, CAB27, CAB28, CB1, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "CABLES")
                Me.SqlDataAdapter1.Fill(Me.myds, "CABLES")
                Me.myds.RejectChanges()
            End With
            Consum.Close()
            Auditor("CABLES", "USERNAME", "IDCAB", Me.TEXTID.EditValue, "")
            Logentry = Uses
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
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
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                'Me.Label20.Visible = False
                'Me.PictureBox4.Image = ImageList2.Images(2)
                'Me.Label20.ForeColor = Color.Yellow
                'Me.Label20.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
            Else
                'Me.Label20.ForeColor = Color.Red
                'Me.Label20.Text = "الاتصال بالانترنت غير متوفر"
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
            Me.BS.DataSource = Me.myds.Tables("CABLES")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "IDCAB", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CAB2", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CAB3", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CAB4", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CAB5", True, 1, "")
            Me.TEXTType.DataBindings.Add("text", Me.BS, "CAB6", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CAB7", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CAB8", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CAB9", True, 1, "")
            Me.ComboCustomerName.DataBindings.Add("text", Me.BS, "CAB10", True, 1, "")
            Me.TextCustomerNumber.DataBindings.Add("text", Me.BS, "CAB11", True, 1, "")
            Me.TextCondition.DataBindings.Add("text", Me.BS, "CAB12", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CAB13", True, 1, "")
            Me.TextFundValue.DataBindings.Add("text", Me.BS, "CAB14", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CAB15", True, 1, "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "CAB16", True, 1, "")
            Me.ComboSource.DataBindings.Add("text", Me.BS, "CAB17", True, 1, "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "CAB18", True, 1, "")
            Me.TEXTTotalN.DataBindings.Add("text", Me.BS, "CAB19", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CAB20", True, 1, "")
            Me.TextCustomerType.DataBindings.Add("text", Me.BS, "CAB21", True, 1, "")
            Me.TextBank.DataBindings.Add("text", Me.BS, "CAB22", True, 1, "")
            Me.TextBranch.DataBindings.Add("text", Me.BS, "CAB23", True, 1, "")
            Me.CheckTransferToAccounts.DataBindings.Add("Checked", Me.BS, "CAB24", True, 1, "")
            Me.CheckSettlementDone.DataBindings.Add("Checked", Me.BS, "CAB25", True, 1, "")
            Me.TextValueOfCheck.DataBindings.Add("text", Me.BS, "CAB26", True, 1, "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", Me.BS, "CAB27", True, 1, "")
            Me.TextCheckDrawerCode.DataBindings.Add("text", Me.BS, "CAB28", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", BS, "CB1", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")
            If Me.myds.Tables("CABLES").Rows.Count > 0 Then
                dt1 = Me.TextDateMovementHistory.Text
                Me.DateMovementHistory.Value = dt1.ToString("yyyy-MM-dd")
            End If

            FILLCOMBOBOX1("CABLESCOEMPLOYEES", "CEMP3", "CUser", CUser, Me.CertificateNumbe)
            FILLCOMBOBOXDISTINCT("Invoice", "PTRO5", "PTRO1", "CUser", CUser, Me.CheckedListBox1)
            FILLCOMBOBOXDISTINCT("CABLESCOEMPLOYEES", "CEMP3", "CEMP1", "CUser", CUser, Me.CheckedListBox2)
            FILLCOMBOBOXDISTINCT("MYCOSTS", "CST7", "CST1", "CUser", CUser, Me.CheckedListBox3)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpComboDebitAccount.Value, Me.ComboDebitAccount)


            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName1)
            'FILLCOMBOBOX1("CABLES", "CAB9", "CUser", CUser, Me.TEXTBOX9)


            Me.ButtonXP2.Enabled = False
            Me.ButtonXP3.Enabled = False
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
            Me.CertificateNumbe.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.CertificateType.Enabled = False
            Me.InstalledPrinters()
            Me.SumAmounCABLESBALANCE()
            Me.SumAmounFINALBALANCE5()
            Me.SumAmounFINALBALANCE4()
            Call MangUsers()
            Me.RecordCount()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim strSQL1 As New SqlCommand("SELECT distinct  CAB6 FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                TEXTType.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim strSQL2 As New SqlCommand("SELECT distinct  CAB17 FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                ComboSource.Items.Add(DR(0))
                CertificateType.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim strSQL5 As New SqlCommand("SELECT distinct  CAB9 FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            Consum.Open()
            DR = strSQL5.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                TEXTStatement.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Me.TextLSet1.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.BUTTONCANCEL.Enabled = True

        Consum.Close()
    End Sub

    Private Sub BackWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork
        Try
1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CAB24, CAB25, CAB26, CAB27, CAB28, CB1, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and IDCAB ='" & Strings.Trim(Me.TB1) & "'ORDER BY IDCAB"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                Me.myds = New DataSet
                Consum.Open()
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "CABLES")
                Me.SqlDataAdapter1.Fill(Me.myds, "CABLES")
                Me.myds.RejectChanges()
            End With
            Consum.Close()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorDoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Finally
            Call CloseDB()
        End Try
    End Sub
    Private Sub BackWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackWorker2.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.BS.DataSource = Me.myds.Tables("CABLES")
            Me.RowCount = Me.BS.Count
            Me.TEXTID.DataBindings.Add("text", Me.BS, "IDCAB", True, 1, "")
            Me.TEXTPreviousBalance.DataBindings.Add("text", Me.BS, "CAB2", True, 1, "")
            Me.TextDateMovementHistory.DataBindings.Add("text", Me.BS, "CAB3", True, 1, "")
            Me.TEXTDebit.DataBindings.Add("text", Me.BS, "CAB4", True, 1, "")
            Me.TEXTCredit.DataBindings.Add("text", Me.BS, "CAB5", True, 1, "")
            Me.TEXTType.DataBindings.Add("text", Me.BS, "CAB6", True, 1, "")
            Me.TEXTCurrentBalance.DataBindings.Add("text", Me.BS, "CAB7", True, 1, "")
            Me.TEXTDocumentNumber.DataBindings.Add("text", Me.BS, "CAB8", True, 1, "")
            Me.TEXTStatement.DataBindings.Add("text", Me.BS, "CAB9", True, 1, "")
            Me.ComboCustomerName.DataBindings.Add("text", Me.BS, "CAB10", True, 1, "")
            Me.TextCustomerNumber.DataBindings.Add("text", Me.BS, "CAB11", True, 1, "")
            Me.TextCondition.DataBindings.Add("text", Me.BS, "CAB12", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "CAB13", True, 1, "")
            Me.TextFundValue.DataBindings.Add("text", Me.BS, "CAB14", True, 1, "")
            Me.ComboPaymentMethod.DataBindings.Add("text", Me.BS, "CAB15", True, 1, "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "CAB16", True, 1, "")
            Me.ComboSource.DataBindings.Add("text", Me.BS, "CAB17", True, 1, "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "CAB18", True, 1, "")
            Me.TEXTTotalN.DataBindings.Add("text", Me.BS, "CAB19", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "CAB20", True, 1, "")
            Me.TextCustomerType.DataBindings.Add("text", Me.BS, "CAB21", True, 1, "")
            Me.TextBank.DataBindings.Add("text", Me.BS, "CAB22", True, 1, "")
            Me.TextBranch.DataBindings.Add("text", Me.BS, "CAB23", True, 1, "")
            Me.CheckTransferToAccounts.DataBindings.Add("Checked", Me.BS, "CAB24", True, 1, "")
            Me.CheckSettlementDone.DataBindings.Add("Checked", Me.BS, "CAB25", True, 1, "")
            Me.TextValueOfCheck.DataBindings.Add("text", Me.BS, "CAB26", True, 1, "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", Me.BS, "CAB27", True, 1, "")
            Me.TextCheckDrawerCode.DataBindings.Add("text", Me.BS, "CAB28", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", BS, "CB1", True, 1, "")
            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")

            If Me.myds.Tables("CABLES").Rows.Count > 0 Then
                dt1 = Me.TextDateMovementHistory.Text
                Me.DateMovementHistory.Value = dt1.ToString("yyyy-MM-dd")
            End If
            Me.DateMovementHistory.Value = dt1.ToString("yyyy-MM-dd")
            Auditor("CABLES", "USERNAME", "IDCAB", Me.TEXTID.EditValue, "")
            Logentry = Uses
            FILLCOMBOBOX1("CABLESCOEMPLOYEES", "CEMP3", "CUser", CUser, Me.CertificateNumbe)
            FILLCOMBOBOXDISTINCT("Invoice", "PTRO5", "PTRO1", "CUser", CUser, Me.CheckedListBox1)
            FILLCOMBOBOXDISTINCT("CABLESCOEMPLOYEES", "CEMP3", "CEMP1", "CUser", CUser, Me.CheckedListBox2)
            FILLCOMBOBOXDISTINCT("MYCOSTS", "CST7", "CST1", "CUser", CUser, Me.CheckedListBox3)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpComboDebitAccount.Value, Me.ComboDebitAccount)
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName1)
            Me.ButtonXP2.Enabled = False
            Me.ButtonXP3.Enabled = False
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
            Me.CertificateNumbe.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.CertificateType.Enabled = False
            Me.InstalledPrinters()
            Me.SumAmounCABLESBALANCE()
            Me.SumAmounFINALBALANCE5()
            Me.SumAmounFINALBALANCE4()
            Call MangUsers()
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Try
            Dim strSQL1 As New SqlCommand("SELECT distinct  CAB6 FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                TEXTType.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim strSQL2 As New SqlCommand("SELECT distinct  CAB17 FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                ComboSource.Items.Add(DR(0))
                CertificateType.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Try
            Dim strSQL5 As New SqlCommand("SELECT distinct  CAB9 FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            Consum.Open()
            DR = strSQL5.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                TEXTStatement.Items.Add(DR(0))
            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Me.TextLSet1.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.BUTTONCANCEL.Enabled = True

        Consum.Close()
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As New SqlCommand("UPDATE CABLES SET CAB2 = @CAB2, CAB3 = @CAB3, CAB4 = @CAB4, CAB5 = @CAB5, CAB6 = @CAB6, CAB7 = @CAB7, CAB8 = @CAB8, CAB9 = @CAB9, CAB10 = @CAB10, CAB11 = @CAB11, CAB12 = @CAB12, CAB13 = @CAB13, CAB14 = @CAB14, CAB15 = @CAB15, CAB16 = @CAB16, CAB17 = @CAB17, CAB18 = @CAB18, CAB19 = @CAB19, CAB20 = @CAB20, CAB21 = @CAB21, CAB22 = @CAB22, CAB23 = @CAB23, CAB24 = @CAB24, CAB25 = @CAB25, CAB26 = @CAB26, CAB27 = @CAB27, CAB28 = @CAB28, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE IDCAB = @IDCAB", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCAB", SqlDbType.BigInt).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CAB2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = Me.TEXTType.Text
                .Parameters.Add("@CAB7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = Me.TextCondition.Text
                .Parameters.Add("@CAB13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CAB14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CAB15", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CAB16", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CAB17", SqlDbType.NVarChar).Value = Me.ComboSource.Text
                .Parameters.Add("@CAB18", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CAB19", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@CAB20", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CAB21", SqlDbType.NVarChar).Value = Me.TextCustomerType.Text
                .Parameters.Add("@CAB22", SqlDbType.NVarChar).Value = Me.TextBank.Text
                .Parameters.Add("@CAB23", SqlDbType.NVarChar).Value = Me.TextBranch.Text
                .Parameters.Add("@CAB24", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
                .Parameters.Add("@CAB25", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettlementDone.Checked)
                .Parameters.Add("@CAB26", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CAB27", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CAB28", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = 0
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
            MessageBox.Show(ex.Message, "ErrorUPDATERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "CABLES")
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
                MessageBox.Show(ex.Message, "ErrorRefreshData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("CABLES")
            Me.PictureBox2.Visible = False
            Me.TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default
            Me.Count()
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
            MessageBox.Show(Ex.Message, "ErrorRefreshData_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "CABLES")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "CABLES")
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
                MessageBox.Show(ex.Message, "ErrorSaveData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Me.BS.DataSource = Me.myds.Tables("CABLES")
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
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorSaveData_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.ComboCustomerName.Focus()
            Me.ComboCustomerName.SelectAll()
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
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("CABLES").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmounCABLESBALANCE()
        Me.SumAmounFINALBALANCE4()
        Me.SumAmounFINALBALANCE5()
        Me.FundBalance()
        Me.AutoEx()
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.DateMovementHistory.Value = Me.TextDateMovementHistory.Text
        dt1 = Me.TextDateMovementHistory.Text
        Me.DateMovementHistory.Value = dt1.ToString("yyyy-MM-dd")
        Me.TextLSet1.Text = LSet(Me.TextMovementSymbol.EditValue, 2)
        Me.SEARCHFROM()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.BALANCEBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.ButtonPREEVIEW.Enabled = LockPrint
        Me.ButtonSearch.Enabled = LockPrint
        Me.ButtonXP1.Enabled = LockPrint
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtoncustomerPayment.Enabled = LockUpdate
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonAttachDocument.Enabled = LockAddRow

    End Sub
    Private Sub SumAmounCABLESBALANCE()
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5)  FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotal.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            Me.TEXTTotal.Text = "0"
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE5()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextCustomerNumber.EditValue & "'" & "AND CAB6='نقدا'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE4()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextCustomerNumber.EditValue & "'" & "AND CAB6='شيك'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
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
            Me.SumAmounFINALBALANCE5CASHANDCHEQUES()
        End If
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
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
        If Me.CheckTransferToAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckSettlementDone.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه تم التسوية ... يمكن التعديل من خلال زر تسديد عميل", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextLSet1.Text.ToString <> "CA" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن تعدبل  السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى من شاشة " & "  " & Me.ComboSource.Text, "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATEALLCUSTOMERS2()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.SumAmounFINALBALANCE5CASHANDCHEQUES()
        Insert_Actions(Me.TEXTID.EditValue, "تعديل", Me.Text)
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextLSet1.Text.ToString <> "CA" Then
            Dim resault As Integer
            resault = MessageBox.Show("لايمكن حذف السجل الحالى لأنه مرحل" & vbCrLf & vbCrLf & "يجب الغاء الترحيل للسجل الحالى من شاشة " & "  " & Me.ComboSource.Text, "سجل مرحل", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
        If Me.CheckSettlementDone.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه تم التسوية ... يمكن التعديل من خلال زر تسديد عميل", 16, "تنبيه")
            Exit Sub
        End If
        MYDELETERECORD("CABLES", "IDCAB", Me.TEXTID, Me.BS, True)
        Me.UPDATEALLCUSTOMERS2()
        Me.ButtonXP5_Click(sender, e)
        Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
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
                Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
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
    Private Sub BALANCEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BALANCEBUTTON.Click
        On Error Resume Next
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
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        'Dim I As Integer
        'For I = 0 To Me.BS.Count + 1
        '    Me.BS.Position = I
        '    Me.PictureBox5.Visible = True
        '    Me.ProgressBar1.Visible = True
        '    Me.ProgressBar1.Minimum = 1
        '    Me.ProgressBar1.Maximum = Me.BS.Count - 1
        '    Me.ProgressBar1.Value = I
        '    Me.GETCABLENOWBALANCE()
        '    Me.UPDATERECORD()
        '    Dim percent As Integer = CInt((CDbl(ProgressBar1.Value - ProgressBar1.Minimum) / CDbl(ProgressBar1.Maximum - ProgressBar1.Minimum)) * 100)
        '    Using gr As Graphics = ProgressBar1.CreateGraphics()
        '        gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        '    End Using
        'Next
        'If Consum.State = ConnectionState.Open Then Consum.Close()
        'Me.BS.EndEdit()
        'Me.RowCount = Me.BS.Count
        'Me.SaveTab = New System.ComponentModel.BackgroundWorker
        'Me.SaveTab.WorkerReportsProgress = True
        'Me.SaveTab.WorkerSupportsCancellation = True
        'Me.SaveTab.RunWorkerAsync()
        'Me.Cursor = Cursors.WaitCursor
        'Me.PictureBox2.Visible = True
        'Me.BS.Position = 0
        'Me.ProgressBar1.Visible = False
        'Me.PictureBox2.Visible = False
        'insert_Actions(Me.TEXTBOX1.Text.Trim, "الارصدة", Me.Text)
        Me.ProgressBar1.Visible = True
        Me.PictureBox2.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = CInt(Me.BS.Count)
        If Not Me.BackWorker3.IsBusy Then
            Me.BackWorker3.RunWorkerAsync()
        End If
    End Sub
    Private Sub StepBALANCE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles stepBALANCE.Click
        If Me.BackWorker3.IsBusy Then
            Me.BackWorker3.CancelAsync()
        End If
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.MoveFirst()
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.MovePrevious()
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.MoveNext()
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.MoveLast()
        Me.RecordCount()
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        On Error Resume Next
        If Me.RadioButton2.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.CertificateNumbe.Enabled = False
        Me.CertificateType.Enabled = False
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.CheckedChanged
        On Error Resume Next
        If Me.RadioButton3.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        On Error Resume Next
        Me.CertificateNumbe.Enabled = True
        Me.CertificateType.Enabled = False
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.CheckedChanged
        On Error Resume Next
        If Me.RadioButton4.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        On Error Resume Next
        Me.CertificateNumbe.Enabled = True
        Me.CertificateType.Enabled = False
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        On Error Resume Next
        If Me.RadioButton1.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.CertificateNumbe.Enabled = False
        Me.CertificateType.Enabled = False
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged
        On Error Resume Next
        If Me.RadioButton6.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton6.Click
        On Error Resume Next
        Me.CertificateNumbe.Enabled = False
        Me.CertificateType.Enabled = False
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged
        On Error Resume Next
        If Me.RadioButton5.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        On Error Resume Next
        Me.CertificateNumbe.Enabled = False
        Me.CertificateType.Enabled = False
    End Sub
    Private Sub TEXTBOX3_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTBOX11_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateFrom.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateTO.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.PRINTBUTTON_Click(sender, e)
        End Select
    End Sub
    Private Sub CertificateNumbe_KeyUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CertificateNumbe.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.PRINTBUTTON_Click(sender, e)
        End Select
    End Sub
    Private Sub TEXTBOX4_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX5_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged, TEXTCurrentBalance.TextChanged
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
    End Sub

    Private Sub TEXTBOX4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTDebit.KeyPress
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust,cust22,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.TextCustomerType.Text = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextCustomerNumber.EditValue = ""
            Me.TextCustomerType.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        SumAmounFINALBALANCE5CASHANDCHEQUES()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCustomerName1.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds, "AllCustomers")
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber1.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextCustomerNumber1.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Function UPDATEALLCUSTOMERS1()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextCustomerNumber.EditValue & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds1.Clear()
        Adp1.Fill(ds1)
        If ds1.Tables("CABLES").Rows.Count > 0 Then
            UPDATEALLCUSTOMERS1 = Format(Val(ds1.Tables("CABLES").Rows(0).Item(0)), "0.000")
        Else
            UPDATEALLCUSTOMERS1 = "0"
        End If
        Adp1.Dispose()
        Consum.Close()
    End Function
    Private Sub UPDATEALLCUSTOMERS2()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("Update AllCustomers SET   cust16 = @cust16  WHERE IDcust = @IDcust", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            '.Parameters.Add("@IDcust", SqlDbType.Int).Value = Me.TextBox17.Text.Trim
            .Parameters.Add("@cust16", SqlDbType.Money).Value = Me.TEXTCurrentBalance.Text
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE5CASHANDCHEQUES()
        On Error Resume Next
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextCustomerNumber.EditValue & "'AND CABLES.IDCAB <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Me.TEXTPreviousBalance.Text = Format(Val(SUM1), "0.000")
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Consum.Close()
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            SEARCHDATA.SEARCHID5(Me.TEXTCredit.EditValue)
            If Me.TextLSet1.Text.ToString.Trim = "BT" Then   'فاتورة نقل   
                Dim f4 As New FrmTRANSPORT With {
                    .TB1 = Me.TextSEARCHFROM.Text
                }
                f4.Show()
                f4.Load_Click(sender, e)
            ElseIf Me.TextLSet1.Text.ToString.Trim = "TL" Then   'فاتورة نقل تفصيلية  
                Dim f5 As New FrmInvoice With {
                    .TB1 = Me.TextSEARCHFROM.Text
                }
                f5.Show()
                f5.Load_Click(sender, e)
            ElseIf Me.TextLSet1.Text.ToString.Trim = "ER" Then 'م تخليص 
                Dim f6 As New FrmCUSTOMER11 With {
                    .TB1 = Me.TextSEARCHFROM.Text
                }
                f6.Show()
                f6.Load_Click(sender, e)
            ElseIf Me.TextLSet1.Text.ToString.Trim = "GE" Then  'م . عامة  
                Dim f7 As New FrmMyCosts With {
                    .TB1 = Me.TextSEARCHFROM.Text.Trim
                }
                f7.Show()
                f7.Load_Click(sender, e)
            ElseIf Me.TextLSet1.Text.ToString.Trim = "VE" Then 'المبيعات 
                Dim f9 As New FrmCustomersA
                If Me.RadioButton5.Checked = True Then
                    Cash = True
                Else
                    Cash = False
                End If
                f9.TB1 = Trim(TextSEARCHFROM.Text)
                f9.Show()
                f9.Load_Click(sender, e)
            Else
                Me.TextSEARCHFROM.Text = Me.TEXTCurrentBalance.Text
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SEARCHFROM()
        Try
            If Me.TextLSet1.Text.ToString.Trim = "BT" Then
                SEARCHDATA.SEARCHID5(Me.TextMovementSymbol.EditValue)
                Me.TextSEARCHFROM.Text = SEARCHDATA.PTRO1.ToString
            ElseIf Me.TextLSet1.Text.ToString.Trim = "TL" Then
                SEARCHDATA.SEARCHID6(Me.TextMovementSymbol.EditValue)
                Me.TextSEARCHFROM.Text = SEARCHDATA.PTRO1A.ToString
            ElseIf Me.TextLSet1.Text.ToString.Trim = "ER" Then
                SEARCHDATA.SEARCHID7(Me.TextMovementSymbol.EditValue)
                Me.TextSEARCHFROM.Text = SEARCHDATA.CEMP3.ToString
            ElseIf Me.TextLSet1.Text.ToString.Trim = "GE" Then
                SEARCHDATA.SEARCHID8(Me.TextMovementSymbol.EditValue)
                Me.TextSEARCHFROM.Text = SEARCHDATA.CST1.ToString
            ElseIf Me.TextLSet1.Text.ToString.Trim = "VE" Then
                SEARCHDATA.SEARCHID10(Me.TextMovementSymbol.EditValue)
                Me.TextSEARCHFROM.Text = SEARCHDATA.SLS1.ToString
            ElseIf Me.TextLSet1.Text.ToString.Trim = "KS" Then
                SEARCHDATA.SEARCHID11(Me.TextMovementSymbol.EditValue)
                Me.TextSEARCHFROM.Text = SEARCHDATA.IDCH1.ToString
            Else
                Me.TextSEARCHFROM.Text = Me.TextLSet1.Text
            End If
        Catch exception1 As Exception
            Dim exception As Exception = exception1
            MessageBox.Show(exception.Message)
        End Try
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged
        On Error Resume Next
        If Me.RadioButton7.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton7.Click
        Try
            Me.CertificateType.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TextBox19_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextGoTo.TextChanged
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
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        Try
            Dim F As New FrmAdvancedSearchMoviesCustomers
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonPREEVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPREEVIEW.Click
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
        If Len(Me.ComboCustomerName1.Text) = 0 Then
            MessageBox.Show("من فضلك حدد اسم العميل  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.ComboCustomerName1.Focus()
            Exit Sub
        End If
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Try
            If Me.RadioButton1.Checked = True Then
                Dim rpt As New rptCustomer11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLES   WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB11='" & TextCustomerNumber1.Text & "'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
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
                    F.CrystalReportViewer1.CloseView(NumericUpDown1.Value)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton12.Checked = True Then
                Dim rpt As New rptCustomer11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLES  WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB20='" & False & "'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
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
                    F.CrystalReportViewer1.CloseView(NumericUpDown1.Value)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton11.Checked = True Then
                Dim rpt As New rptReceivableDisclosure
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Me.ComboCustomerName1.Enabled = False
                Me.TextCustomerNumber1.Enabled = False
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlClient.SqlCommand("SELECT * FROM CustomersCABLES2   WHERE  CUser ='" & CUser & "'  AND Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND lo19 ='" & False & "'", Consum)
                Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                Dim ds As New DataSet
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CustomersCABLES2")
                rpt.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("Text4")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT8")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton2.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt1 As New rptAccount
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlClient.SqlCommand("SELECT * FROM DETAILSACCOUNT   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
                Dim builder36 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "DETAILSACCOUNT")
                rpt1.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt1.Section1.ReportObjects("Text4")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt1.Section1.ReportObjects("Text8")
                    txt.Text = AssociationName
                    txt = rpt1.Section1.ReportObjects("TEXT9")
                    txt.Text = Directorate
                    txt = rpt1.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    txt = rpt1.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    F.CrystalReportViewer1.ReportSource = rpt1
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton3.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                If Len(Me.CertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.CertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt2 As New rptCustomer1
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlClient.SqlCommand("SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Me.CertificateNumbe.Text & "' AND CEMP29=" & TextCustomerNumber1.Text, Consum)
                Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt2.Section1.ReportObjects("TEXT21")
                    txt.Text = AssociationName
                    txt = rpt2.Section1.ReportObjects("TEXT22")
                    txt.Text = Directorate
                    txt = rpt2.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt2.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    txt = rpt2.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt2
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton4.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                If Len(Me.CertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.CertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt3 As New rptCustomer33
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlClient.SqlCommand("SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Me.CertificateNumbe.Text & "' AND CEMP29=" & TextCustomerNumber1.Text, Consum)
                Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt3.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt3.Section1.ReportObjects("TEXT21")
                    txt.Text = AssociationName
                    txt = rpt3.Section1.ReportObjects("TEXT2")
                    txt.Text = Directorate
                    txt = rpt3.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    txt = rpt3.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    F.CrystalReportViewer1.ReportSource = rpt3
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton5.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt1 As New rptCustomer11
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim str As New SqlClient.SqlCommand("SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextCustomerNumber1.Text & " AND CAB6='" & Me.RadioButton5.Text.Trim & "'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                If ds.Tables(0).Rows.Count > 0 Then
                    rpt1.SetDataSource(ds)
                    txt = rpt1.Section1.ReportObjects("TEXT21")
                    txt.Text = AssociationName
                    txt = rpt1.Section1.ReportObjects("TEXT10")
                    txt.Text = Directorate
                    txt = rpt1.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    F.CrystalReportViewer1.ReportSource = rpt1
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton6.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt2 As New rptCustomer11
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim str As New SqlClient.SqlCommand("SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextCustomerNumber1.Text & " AND CAB6='" & Me.RadioButton6.Text.Trim & "'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt2.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt2.Section1.ReportObjects("TEXT21")
                    txt.Text = AssociationName
                    txt = rpt2.Section1.ReportObjects("TEXT10")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt2
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton7.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt2 As New rptCustomer11
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextCustomerNumber1.Text & " AND CAB17='" & Me.CertificateType.Text & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt2.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt2.Section1.ReportObjects("TEXT21")
                    txt.Text = AssociationName
                    txt = rpt2.Section1.ReportObjects("TEXT10")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt2
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton8.Checked = True Then
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
                Dim ds As New DataSet
                Dim rpt1 As New rptTransportDetails
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim S As Integer
                If Me.CountItems > 0 Then
                    For S = 0 To Me.CheckedListBox1.Items.Count - 1
                        If Me.CheckedListBox1.GetItemChecked(S) = True Then
                            Dim Str1 As String = Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.Items(S)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(0)
                            Dim F20 As New FrmPRINT
                            Dim str As String = "SELECT * FROM Invoice  WHERE PTRO1=" & a
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "Invoice")
                            rpt1.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                Dim txt1 As TextObject
                                Dim txt2 As TextObject
                                txt2 = rpt1.Section4.ReportObjects("Text15")
                                txt1 = rpt1.Section4.ReportObjects("Text14")
                                txt2.Text = Year(ds.Tables(0).Rows(0).Item("PTRO5")) & "/" & ds.Tables(0).Rows(0).Item("PTRO1")
                                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("PTRO14"), "jO")
                                txt = rpt1.Section1.ReportObjects("TEXT22")
                                txt.Text = AssociationName
                                txt = rpt1.Section1.ReportObjects("TEXT21")
                                txt.Text = Directorate
                                txt = rpt1.Section1.ReportObjects("Text23")
                                txt.Text = Character
                                txt = rpt1.Section1.ReportObjects("TEXT40")
                                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                                txt = rpt1.Section1.ReportObjects("Text44")
                                txt.Text = Recorded
                                F20.CrystalReportViewer1.ReportSource = rpt1
                                F20.CrystalReportViewer1.Zoom(94%)
                                F20.CrystalReportViewer1.Refresh()
                                F20.Show()
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة" & " - " & Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.Items(S)).ToString, "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit For
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد رقم الفاتورة المطلوب طباعتها", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    CheckedListBox1.Focus()
                    Exit Sub
                End If

            ElseIf Me.RadioButton9.Checked = True Then
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
                Dim rpt15 As New rptMyCosts51
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt15, DBServer, "", "")
                If Me.CountItems3 > 0 Then
                    For s5 As Integer = 0 To Me.CheckedListBox3.Items.Count - 1
                        If Me.CheckedListBox3.GetItemChecked(s5) = True Then
                            Dim Str1 As String = Me.CheckedListBox3.GetItemText(Me.CheckedListBox3.Items(s5)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(0)
                            Dim F5 As New FrmPRINT
                            Dim str As New SqlClient.SqlCommand("SELECT * FROM MYCOSTS   WHERE CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CST1='" & CInt(a) & "'", Consum)
                            Dim builder29 As New SqlCommandBuilder(SqlDataAdapter1)
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "MYCOSTS")
                            rpt15.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                Dim txt2 As TextObject
                                txt2 = rpt15.Section4.ReportObjects("Text5")
                                txt2.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("CST11"), "jO")
                                rpt15.SetDataSource(ds)
                                txt = rpt15.Section1.ReportObjects("Text22")
                                txt.Text = AssociationName
                                txt = rpt15.Section1.ReportObjects("Text21")
                                txt.Text = Directorate
                                txt = rpt15.Section1.ReportObjects("Text23")
                                txt.Text = Character
                                txt = rpt15.Section1.ReportObjects("TEXT40")
                                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                                txt = rpt15.Section1.ReportObjects("Text44")
                                txt.Text = Recorded
                                F5.CrystalReportViewer1.ReportSource = rpt15
                                F5.CrystalReportViewer1.Zoom(94%)
                                F5.CrystalReportViewer1.Refresh()
                                F5.Show()
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد رقم الفاتورة المطلوب طباعتها", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    CheckedListBox3.Focus()
                    Exit Sub
                End If

            ElseIf Me.RadioButton10.Checked = True Then
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
                Dim ds As New DataSet
                Dim rpt6 As New rptCustomer51
                GETSERVERNAMEANDDATABASENAME(rpt6, DBServer, "", "")
                If Me.CountItems2 > 0 Then
                    For s1 As Integer = 0 To Me.CheckedListBox2.Items.Count - 1
                        If Me.CheckedListBox2.GetItemChecked(s1) = True Then
                            Dim Str1 As String = Me.CheckedListBox2.GetItemText(Me.CheckedListBox2.Items(s1)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(1)
                            Dim F25 As New FrmPRINT
                            Dim str As String = "SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & a & "' AND CEMP29=" & TextCustomerNumber1.Text
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                            rpt6.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                txt = rpt6.Section1.ReportObjects("TEXT22")
                                txt.Text = AssociationName
                                txt = rpt6.Section1.ReportObjects("TEXT21")
                                txt.Text = Directorate
                                txt = rpt6.Section1.ReportObjects("Text23")
                                txt.Text = Character
                                txt = rpt6.Section1.ReportObjects("TEXT40")
                                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                                txt = rpt6.Section1.ReportObjects("Text44")
                                txt.Text = Recorded
                                F25.CrystalReportViewer1.ReportSource = rpt6
                                F25.CrystalReportViewer1.Zoom(90%)
                                F25.CrystalReportViewer1.Refresh()
                                F25.Show()
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
                Dim rpt10 As New rptCustomer10
                GETSERVERNAMEANDDATABASENAME(rpt10, DBServer, "", "")
                If Me.CountItems2 > 0 Then
                    For s20 As Integer = 0 To Me.CheckedListBox2.Items.Count - 1
                        If Me.CheckedListBox2.GetItemChecked(s20) = True Then
                            Dim Str1 As String = Me.CheckedListBox2.GetItemText(Me.CheckedListBox2.Items(s20)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(1)
                            Dim F10 As New FrmPRINT
                            Dim str10 As String = "SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & a & "' AND CEMP29=" & TextCustomerNumber1.Text
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str10, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                            rpt10.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                txt = rpt10.Section1.ReportObjects("TEXT22")
                                txt.Text = AssociationName
                                txt = rpt10.Section1.ReportObjects("TEXT21")
                                txt.Text = Directorate
                                txt = rpt10.Section1.ReportObjects("Text23")
                                txt.Text = Character
                                txt = rpt10.Section1.ReportObjects("TEXT40")
                                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                                txt = rpt10.Section1.ReportObjects("Text44")
                                txt.Text = Recorded
                                F10.CrystalReportViewer1.ReportSource = rpt10
                                F10.CrystalReportViewer1.Zoom(90%)
                                F10.CrystalReportViewer1.Refresh()
                                F10.Show()
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد رقم الشهادة الخدمية المطلوب طباعتها", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    CheckedListBox2.Focus()
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Function CountItems() As Integer
        Dim n As Integer
        Try
            Dim i As Integer
            For i = 0 To Me.CheckedListBox1.Items.Count - 1
                If Me.CheckedListBox1.GetItemChecked(i) = True Then
                    n += 1
                End If
            Next
            CountItems = Val(n)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Private Function CountItems2() As Integer
        Dim n As Integer
        Try
            Dim i As Integer
            For i = 0 To Me.CheckedListBox2.Items.Count - 1
                If Me.CheckedListBox2.GetItemChecked(i) = True Then
                    n += 1
                End If
            Next
            CountItems2 = Val(n)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Private Function CountItems3() As Integer
        Dim n As Integer
        Try
            Dim i As Integer
            For i = 0 To Me.CheckedListBox3.Items.Count - 1
                If Me.CheckedListBox3.GetItemChecked(i) = True Then
                    n += 1
                End If
            Next
            CountItems3 = Val(n)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return n
    End Function
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        Try
            Process.Start("calc.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub RadioButton10_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton10.CheckedChanged
        On Error Resume Next
        If Me.RadioButton10.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = True
            Me.CheckedListBox3.Enabled = False
            Me.ButtonXP2.Enabled = True
            Me.ButtonXP3.Enabled = True
        Else
            Me.ButtonXP2.Enabled = False
            Me.ButtonXP3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton8_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton8.CheckedChanged
        On Error Resume Next
        If Me.RadioButton8.Checked = True Then
            Me.CheckedListBox1.Enabled = True
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = False
            Me.ButtonXP2.Enabled = True
            Me.ButtonXP3.Enabled = True
        Else
            Me.ButtonXP2.Enabled = False
            Me.ButtonXP3.Enabled = False
        End If
    End Sub
    Private Sub RadioButton9_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton9.CheckedChanged
        On Error Resume Next
        If Me.RadioButton9.Checked = True Then
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = False
            Me.CheckedListBox3.Enabled = True
            Me.ButtonXP2.Enabled = True
            Me.ButtonXP3.Enabled = True
        Else
            Me.ButtonXP2.Enabled = False
            Me.ButtonXP3.Enabled = False
        End If
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP3.Click
        Try
            If Me.CheckedListBox1.Enabled = True Then
                Dim s As Integer
                For s = 0 To Me.CheckedListBox1.Items.Count - 1
                    If Me.CheckedListBox1.GetItemChecked(s) = False Then
                        Me.CheckedListBox1.SetItemChecked(s, True)
                    End If
                Next
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
            ElseIf Me.CheckedListBox2.Enabled = True Then
                Dim s As Integer
                For s = 0 To Me.CheckedListBox2.Items.Count - 1
                    If Me.CheckedListBox2.GetItemChecked(s) = False Then
                        Me.CheckedListBox2.SetItemChecked(s, True)
                    End If
                Next
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
            ElseIf Me.CheckedListBox3.Enabled = True Then
                Dim s As Integer
                For s = 0 To Me.CheckedListBox3.Items.Count - 1
                    If Me.CheckedListBox3.GetItemChecked(s) = False Then
                        Me.CheckedListBox3.SetItemChecked(s, True)
                    End If
                Next
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click
        Try
            If Me.CheckedListBox1.Enabled = True Then
                Dim s As Integer
                For s = 0 To Me.CheckedListBox1.Items.Count - 1
                    If Me.CheckedListBox1.GetItemChecked(s) = True Then
                        Me.CheckedListBox1.SetItemChecked(s, False)
                    End If
                Next
                Me.ButtonXP2.Enabled = False
            ElseIf Me.CheckedListBox2.Enabled = True Then
                Dim s As Integer
                For s = 0 To Me.CheckedListBox2.Items.Count - 1
                    If Me.CheckedListBox2.GetItemChecked(s) = True Then
                        Me.CheckedListBox2.SetItemChecked(s, False)
                    End If
                Next
                Me.ButtonXP2.Enabled = False
            ElseIf Me.CheckedListBox3.Enabled = True Then
                Dim s As Integer
                For s = 0 To Me.CheckedListBox3.Items.Count - 1
                    If Me.CheckedListBox3.GetItemChecked(s) = True Then
                        Me.CheckedListBox3.SetItemChecked(s, False)
                    End If
                Next
                Me.ButtonXP2.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub InstalledPrinters()
        Dim prtdoc As New PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
        Dim strPrinter As String
        For Each strPrinter In PrinterSettings.InstalledPrinters
            ComboBox5.Items.Add(strPrinter)
            If strPrinter = strDefaultPrinter Then
                Me.ComboBox5.SelectedIndex = Me.ComboBox5.Items.IndexOf(strPrinter)
            End If
        Next strPrinter
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
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        If Len(Me.ComboCustomerName1.Text) = 0 Then
            MessageBox.Show("من فضلك حدد اسم العميل  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.ComboCustomerName1.Focus()
            Exit Sub
        End If


        Dim Consum As New SqlClient.SqlConnection(constring)
        Try

            Dim SqlDataAdapter1 As SqlDataAdapter
            If Me.RadioButton1.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt1 As New rptCustomer11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB11='" & TextCustomerNumber1.Text & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                rpt1.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt As TextObject
                    txt = rpt1.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    rpt1.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt1.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton12.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt1 As New rptCustomer11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB20='" & False & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                rpt1.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt As TextObject
                    txt = rpt1.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    rpt1.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt1.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton2.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt1 As New rptAccount
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM DETAILSACCOUNT   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "DETAILSACCOUNT")
                rpt1.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt As TextObject
                    txt = rpt1.Section1.ReportObjects("Text4")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    rpt1.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt1.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton3.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                If Len(Me.CertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.CertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt2 As New rptCustomer1
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Me.CertificateNumbe.Text & "' AND CEMP29=" & TextCustomerNumber1.Text
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    rpt2.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt2.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton4.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                If Len(Me.CertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.CertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt3 As New rptCustomer33
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Val(Me.CertificateNumbe.Text) & "' AND CEMP29=" & TextCustomerNumber1.Text
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt3.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    rpt3.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt3.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton5.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt1 As New rptCustomer11
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & Me.TextCustomerNumber1.Text & " AND CAB6='" & Me.RadioButton5.Text.Trim & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                If ds.Tables(0).Rows.Count > 0 Then
                    rpt1.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt1.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    rpt1.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt1.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton6.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt2 As New rptCustomer11
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & Me.TextCustomerNumber1.Text & " AND CAB6='" & Me.RadioButton6.Text.Trim & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt As TextObject
                    txt = rpt2.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    rpt2.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt2.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton7.Checked = True Then
                Me.ButtonXP2.Enabled = False
                Me.ButtonXP3.Enabled = False
                Dim rpt2 As New rptCustomer11
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM CABLES   WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextCustomerNumber1.Text & " AND CAB17='" & Me.CertificateType.Text & "'"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLES")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt As TextObject
                    txt = rpt2.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    rpt2.PrintOptions.PrinterName = Me.ComboBox5.Text
                    rpt2.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton8.Checked = True Then
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
                Dim ds As New DataSet
                Dim rpt1 As New rptTransportDetails
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim S As Integer
                If Me.CountItems > 0 Then
                    For S = 0 To Me.CheckedListBox1.Items.Count - 1
                        If Me.CheckedListBox1.GetItemChecked(S) = True Then
                            Dim Str1 As String = Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.Items(S)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(0)
                            Dim str As String = "SELECT * FROM Invoice  WHERE PTRO1=" & a
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "Invoice")
                            rpt1.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                Dim txt1 As TextObject
                                Dim txt2 As TextObject
                                txt2 = rpt1.Section4.ReportObjects("Text15")
                                txt1 = rpt1.Section4.ReportObjects("Text14")
                                txt2.Text = Year(ds.Tables(0).Rows(0).Item("PTRO5")) & "/" & ds.Tables(0).Rows(0).Item("PTRO1")
                                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("PTRO14"), "jO")
                                rpt1.PrintOptions.PrinterName = Me.ComboBox5.Text
                                rpt1.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة" & " - " & Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.Items(S)).ToString, "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit For
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد رقم الفاتورة المطلوب طباعتها", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    CheckedListBox1.Focus()
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = True
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = False
            ElseIf Me.RadioButton9.Checked = True Then
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
                Dim rpt15 As New rptMyCosts51
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt15, DBServer, "", "")
                If Me.CountItems3 > 0 Then
                    For s5 As Integer = 0 To Me.CheckedListBox3.Items.Count - 1
                        If Me.CheckedListBox3.GetItemChecked(s5) = True Then
                            Dim Str1 As String = Me.CheckedListBox3.GetItemText(Me.CheckedListBox3.Items(s5)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(0)
                            Dim str As String = "SELECT * FROM MYCOSTS   WHERE CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CST1=" & CInt(a)
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "MYCOSTS")
                            rpt15.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                Dim txt2 As TextObject
                                txt2 = rpt15.Section4.ReportObjects("Text5")
                                txt2.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("CST11"), "jO")
                                rpt15.SetDataSource(ds)
                                rpt15.PrintOptions.PrinterName = Me.ComboBox5.Text
                                rpt15.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد رقم الفاتورة المطلوب طباعتها", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    CheckedListBox3.Focus()
                    Exit Sub
                End If
                Me.CheckedListBox1.Enabled = False
                Me.CheckedListBox2.Enabled = False
                Me.CheckedListBox3.Enabled = True
            ElseIf Me.RadioButton10.Checked = True Then
                Me.ButtonXP2.Enabled = True
                Me.ButtonXP3.Enabled = True
                Dim ds As New DataSet
                Dim rpt6 As New rptCustomer51
                GETSERVERNAMEANDDATABASENAME(rpt6, DBServer, "", "")
                If Me.CountItems2 > 0 Then
                    For s1 As Integer = 0 To Me.CheckedListBox2.Items.Count - 1
                        If Me.CheckedListBox2.GetItemChecked(s1) = True Then
                            Dim Str1 As String = Me.CheckedListBox2.GetItemText(Me.CheckedListBox2.Items(s1)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(1)
                            Dim str As String = "SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & a & "' AND CEMP29=" & TextCustomerNumber1.Text
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                            rpt6.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                rpt6.PrintOptions.PrinterName = Me.ComboBox5.Text
                                rpt6.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit Sub
                            End If
                        End If
                    Next
                End If
                Dim rpt10 As New rptCustomer10
                GETSERVERNAMEANDDATABASENAME(rpt10, DBServer, "", "")
                If Me.CountItems2 > 0 Then
                    For s20 As Integer = 0 To Me.CheckedListBox2.Items.Count - 1
                        If Me.CheckedListBox2.GetItemChecked(s20) = True Then
                            Dim Str1 As String = Me.CheckedListBox2.GetItemText(Me.CheckedListBox2.Items(s20)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(1)
                            Dim str10 As String = "SELECT * FROM CABLESCOEMPLOYEES   WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & a & "' AND CEMP29=" & TextCustomerNumber1.Text
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str10, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                            rpt10.SetDataSource(ds)
                            If ds.Tables(0).Rows.Count > 0 Then
                                rpt10.PrintOptions.PrinterName = Me.ComboBox5.Text
                                rpt10.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                            Else
                                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit Sub
                            End If
                        End If
                    Next
                Else
                    MessageBox.Show("من فضلك حدد رقم الشهادة الخدمية المطلوب طباعتها", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    CheckedListBox2.Focus()
                    Exit Sub
                End If
            End If
            Me.CheckedListBox1.Enabled = False
            Me.CheckedListBox2.Enabled = True
            Me.CheckedListBox3.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub LinkLabel2_Click(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Width = 872
            Me.Height = 562
            Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
        Try
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Width = 495
            Me.Height = 455
            Me.Location = New Point((Screen.PrimaryScreen.Bounds.Width - Me.Width) / 2, (Screen.PrimaryScreen.Bounds.Height - Me.Height) / 2)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        If Me.CheckTransferToAccounts.Checked = False Then
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
        Insert_Actions(Me.TEXTID.EditValue, "المراجع", Me.Text)
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
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
        Me.FIRSTBUTTON_Click(sender, e)
        Insert_Actions(Me.TEXTID.EditValue, "إلغاء المراجعة", Me.Text)
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
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
    Private Sub SaveMOVES()
        Try
            SEARCHDATA.MAXIDMOVES()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, Realname, USERNAME, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @Realname, @USERNAME, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2.ToString.Trim
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = Me.TextDateMovementHistory.Text.Trim
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.Bit).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text.Trim
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text.Trim
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "قيد"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "CA"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@MOV12", SqlDbType.Bit).Value = False
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
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
        ds2.Clear()
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
        Consum.Close()
    End Sub
    Private Sub AutoEx()
        On Error Resume Next
        Dim ExResult As String
        ExResult = Me.TextCreditAccount.Text & " " & Me.TEXTID.EditValue & " " & "بتاريخ" & " " & ":" & " " & Me.TextDateMovementHistory.Text & " "
        ExResult += "للعميل" & " " & ":" & " " & Me.ComboCustomerName.Text & " " & "مثبتة بوثيقة رقم" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            MYDELETERECORD("CASHIER", "CSH1", TextFundMovementNumber, BS, True)
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
    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
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
                Dim Adp1 As SqlClient.SqlDataAdapter
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
            ElseIf Me.RadioEMPLOYEES.Checked = True Then
                Dim Adp2 As SqlClient.SqlDataAdapter
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
            Else

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveMOVESDATARecord()
        Try
            Dim Box, Box1, Box2, Box3, Box4, Box5 As Integer
            nem = " تحميل على العملاء مدينين رقم" & " " & Me.TEXTID.EditValue
            nem1 = "صرف نقدا للعملاء مدينين رقم " & "_" & Me.TEXTID.EditValue
            nem2 = " صرف شيك للعملاء مدينين_ بيموجب مستند رقم" & "_" & Me.TextCheckNumber.Text
            pp = "1"

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

            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With strSQL
                If OBCHK2 = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                    & pp.ToString & "','" & Me.ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TEXTDebit.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextFundValue.EditValue & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                Else
                    If Me.ComboPaymentMethod.Text = "نقدا" Then
                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                         & pp.ToString & "','" & Me.ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TEXTDebit.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()
                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                 & pp.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextFundValue.EditValue & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()
                    ElseIf Me.ComboPaymentMethod.Text = "شيك" Then
                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                       & pp.ToString & "','" & Me.ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TEXTDebit.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()
                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextValueOfCheck.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()
                    ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 1 & "','" & Me.ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TEXTDebit.EditValue & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()

                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                       & pp.ToString & "','" & ModuleGeneral.CB2.ToString & "','" & Box.ToString.Trim & "','" & 0 & "','" & Me.TextFundValue.EditValue & "','" & nem.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()

                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                      & pp.ToString + 2 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextValueOfCheck.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()

                    Else
                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                      & pp.ToString & "','" & Me.ComboDebitAccount.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TEXTDebit.EditValue & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()


                        .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                      & pp.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TEXTDebit.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & False & "','" & T2.ToString.Trim & "')"
                        CMD.CommandType = CommandType.Text
                        CMD.Connection = Consum
                        CMD.CommandText = strSQL.CommandText
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        Consum.Close()
                    End If
                End If
            End With
        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RadioButton20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton7.CheckedChanged, RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton6.CheckedChanged, RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton5.CheckedChanged, RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If Me.RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf Me.RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf Me.RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List1.MouseDoubleClick
        Me.TextCreditAccount.Text = Me.List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
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
    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
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
    Private Sub TRANSFERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextLSet1.Text.ToString <> "CA" Then
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
                MsgBox("عفوا لا يمكن... تم  تسوية حركة العميل", 16, "تنبيه")
                Exit Sub
            End If
            Static P As Integer
            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            Me.ComboCB1_SelectedIndexChanged(sender, e)
            If OBCHK2 = True Then
                If Me.CheckTransferToAccounts.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TEXTID.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
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
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P
                        Me.RecordCount()
                        Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TEXTID.EditValue, Me.Text)
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
                        Me.SaveMOVES()
                        Me.SaveMOVESDATARecord()
                        P = Me.BS.Position
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
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferToAccounts.Checked = False
                            P = Me.BS.Position
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
                            Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TEXTID.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Me.ComboPaymentMethod.Text = "نقدا" Then
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TEXTID.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                           " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue & "0",
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)
                            P = Me.BS.Position
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
                            Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TEXTID.EditValue, Me.Text)
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
                            Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                           " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue & "0",
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)
                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            P = Me.BS.Position
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
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                P = Me.BS.Position
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
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TEXTID.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '======================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "شيك" Then
                    If Me.ComboCheckDrawerName.Text = "" Then
                        MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                        Me.ComboCheckDrawerName.Focus()
                        Exit Sub
                    End If
                    If Me.TextCheckNumber.Text = "" Then
                        MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                        Me.TextCheckNumber.Focus()
                        Exit Sub
                    End If
                    If Me.CheckDate.Value = Nothing Then
                        MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                        Me.CheckDate.Focus()
                        Exit Sub
                    End If
                    If Me.TextBank.Text = "" Then
                        MsgBox("يجب إدخال اسم البنك", 16, "تنبيه")
                        Me.TextBank.Focus()
                        Exit Sub
                    End If
                    If Me.TextBranch.Text = "" Then
                        MsgBox("يجب إدخال الفرع", 16, "تنبيه")
                        Me.TextBranch.Focus()
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم " & Me.TEXTID.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True

                            Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBank.Text, TextBranch.Text, True,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            P = Me.BS.Position
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
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الشيكات رفم" & " " & Me.TEXTID.EditValue, Me.Text)
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
                            Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBank.Text, TextBranch.Text, True,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            P = Me.BS.Position
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
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                P = Me.BS.Position
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
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الشيكات رقم" & " " & Me.TEXTID.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                    If Me.ComboCheckDrawerName.Text = "" Then
                        MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                        Me.ComboCheckDrawerName.Focus()
                        Exit Sub
                    End If
                    If Me.TextCheckNumber.Text = "" Then
                        MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                        Me.TextCheckNumber.Focus()
                        Exit Sub
                    End If
                    If Me.CheckDate.Value = Nothing Then
                        MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                        Me.CheckDate.Focus()
                        Exit Sub
                    End If
                    If Me.TextBank.Text = "" Then
                        MsgBox("يجب إدخال اسم البنك", 16, "تنبيه")
                        Me.TextBank.Focus()
                        Exit Sub
                    End If
                    If Me.TextBranch.Text = "" Then
                        MsgBox("يجب إدخال الفرع", 16, "تنبيه")
                        Me.TextBranch.Focus()
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم " & Me.TEXTID.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                           " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue & "0",
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)
                            Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBank.Text, TextBranch.Text, True,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            P = Me.BS.Position
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
                            Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TEXTID.EditValue, Me.Text)
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

                            Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                           " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue & "0",
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)

                            Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBank.Text, TextBranch.Text, True,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)


                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            P = Me.BS.Position
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
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                P = Me.BS.Position
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
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة الصندزق و الشيكات رقم" & " " & Me.TEXTID.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                Else
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية  رفم " & Me.TEXTID.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
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
                            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                                .WorkerReportsProgress = True,
                                .WorkerSupportsCancellation = True
                            }
                            Me.SaveTab.RunWorkerAsync()
                            Me.BS.Position = P
                            Me.RecordCount()
                            Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TEXTID.EditValue, Me.Text)
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
                            Me.SaveMOVES()
                            Me.SaveMOVESDATARecord()
                            P = Me.BS.Position
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
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية رفم" & " " & Me.TEXTID.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول القيود اليومية ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                P = Me.BS.Position
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
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية رقم" & " " & Me.TEXTID.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions1.Click
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

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
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

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber1.Click
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
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CASHIER")
            f.BS.DataMember = "CASHIER"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("CSH1", Me.TextFundMovementNumber1.Text.Trim)
            f.TB1 = Me.TextFundMovementNumber1.Text
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
    Private Sub ButtonXP6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtoncustomerPayment.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية الترحيل وتعديل السجلات من البرنامج", 16, "تنبيه")
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
            If Me.CheckTransferToAccounts.Checked = False Then
                MsgBox("عفوا .. يجب ترحيل اولا الى الحســـــــابات اولا ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            Dim MA As Integer
            Dim MA1 As Integer
            Dim FF As Integer
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim Year As String
            Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            Dim noD As Object = Strings.Mid(cmd1.ExecuteScalar(), 3, 5)
            If IsDBNull(resualt) Then
                MA = CType(Year, Integer) & 1
            Else
                MA = CType(Year, Integer) & CType(noD, Integer) + 1
            End If
            Dim cmd2 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt1 As Object = cmd2.ExecuteScalar()
            If IsDBNull(resualt1) Then
                MA1 = 1
            Else
                MA1 = CType(resualt1, Integer) + 1
            End If
            Static P As Integer
            Consum.Close()
            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            If Me.ComboPaymentMethod.Text = "نقدا" Then
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Dim naum, naum1 As String
                        naum = Me.ComboCustomerName.Text
                        naum1 = Me.TextFundValue.EditValue

                        Me.BS.Position = Me.BS.Count - 1
                        Application.DoEvents()
                        Me.BS.EndEdit()
                        Me.BS.AddNew()
                        CLEARDATA1(Me)
                        Me.CheckTransferToAccounts.Checked = False
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.ComboCustomerName.Text = naum
                        Me.ComboBox1_SelectedIndexChanged(sender, e)
                        Me.TEXTID.EditValue = Val(MA)
                        Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")

                        Me.ComboSource.Text = "حركات العملاء"
                        Me.TEXTDebit.EditValue = "0.00"
                        Me.TEXTType.Text = "نقدا"
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                        Me.TextCondition.Text = "نقدا"
                        Me.TEXTStatement.Text = "سداد من العميل" & "- " & Me.ComboCustomerName.Text
                        Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TextMovementSymbol.EditValue = "CA" & Me.TEXTID.EditValue
                        Me.ComboPaymentMethod.Text = "نقدا"
                        Me.TextCheckNumber.Text = "0"
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.ComboCustomerName.Text = naum
                        Me.TextFundValue.EditValue = naum1
                        Me.TextValueOfCheck.EditValue = "0.00"
                        Dim Frm As New CustomerPay1
                        Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Frm.ShowDialog(Me)
                        Me.TEXTCredit.EditValue = Val(Frm.TextB1.Text)
                        FF = Val(Frm.TextB1.Text)
                        Me.TEXTCredit.EditValue = FF
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        P = Me.BS.Position
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.RecordCount()
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        Me.SAVERECORD()
                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                           "سداد من حساب العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue,
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P + 1
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للعميل" & "- " & Me.ComboCustomerName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم تسويةالسجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        P = Me.BS.Position
                        Me.TEXTCredit.EditValue = Me.TEXTCredit.EditValue
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If
                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                           "سداد من حساب العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue,
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.RecordCount()
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.UPDATERECORD()
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل  تسوية حركة العملاء", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة العملاء", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            P = BS.Position
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.DELETEDATCASHIER1()
                            Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.UPDATERECORD()
                            Me.BS.RemoveCurrent()
                            Me.BS.EndEdit()
                            Me.RowCount = Me.BS.Count
                            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                                .WorkerReportsProgress = True,
                                .WorkerSupportsCancellation = True
                            }
                            Me.SaveTab.RunWorkerAsync()
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text = "شيك" Then
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Dim naum, naum1, naum3, naum4, naum5, naum6, naum7 As String
                        naum = Me.ComboCustomerName.Text
                        naum1 = Me.ComboPaymentMethod.Text
                        naum3 = Me.TextValueOfCheck.EditValue
                        naum4 = Me.TextCheckNumber.Text
                        naum5 = Me.CheckDate.Text
                        naum6 = Me.TextBank.Text
                        naum7 = Me.TextBranch.Text
                        Me.BS.Position = Me.BS.Count - 1
                        Application.DoEvents()
                        Me.BS.EndEdit()
                        Me.BS.AddNew()
                        CLEARDATA1(Me)
                        Me.CheckTransferToAccounts.Checked = False
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.ComboCustomerName.Text = naum
                        Me.ComboBox1_SelectedIndexChanged(sender, e)
                        Me.TEXTID.EditValue = Val(MA)
                        Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.ComboSource.Text = "حركات العملاء"
                        Me.TEXTDebit.EditValue = "0.00"
                        Me.TEXTType.Text = "شيك"
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                        Me.TextCondition.Text = "نقدا"
                        Me.TEXTStatement.Text = "سداد من العميل" & "- " & Me.ComboCustomerName.Text
                        Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TextMovementSymbol.EditValue = "CA" & Me.TEXTID.EditValue
                        Me.ComboPaymentMethod.Text = "نقدا"
                        Me.TextCheckNumber.Text = "0"
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.ComboCustomerName.Text = naum
                        Me.ComboPaymentMethod.Text = naum1
                        Me.TextValueOfCheck.EditValue = naum3
                        Me.TextCheckNumber.Text = naum4
                        Me.CheckDate.Text = naum5
                        Me.TextBank.Text = naum6
                        Me.TextBranch.Text = naum7
                        Me.TextFundValue.EditValue = "0.00"
                        Dim Frm As New CustomerPay1
                        Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Frm.ShowDialog(Me)
                        Me.TEXTCredit.EditValue = Val(Frm.TextB1.Text)
                        FF = Val(Frm.TextB1.Text)
                        Me.TEXTCredit.EditValue = FF
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.Count()
                        P = Me.BS.Position
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.RecordCount()
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        Me.SAVERECORD()

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
                          0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, False,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P + 1
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للعميل" & "- " & Me.ComboCustomerName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم تسويةالسجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        P = Me.BS.Position
                        Me.TEXTCredit.EditValue = Me.TEXTCredit.EditValue
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If
                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
                          0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, False,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.RecordCount()
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.UPDATERECORD()
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل  تسوية حركة العملاء", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة الشيكات", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            P = BS.Position
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.DELETEDATBANK1()
                            Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.UPDATERECORD()
                            Me.BS.RemoveCurrent()
                            Me.BS.EndEdit()
                            Me.RowCount = Me.BS.Count
                            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                                .WorkerReportsProgress = True,
                                .WorkerSupportsCancellation = True
                            }
                            Me.SaveTab.RunWorkerAsync()
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Dim naum, naum1, naum2, naum3, naum4, naum5, naum6, naum7 As String
                        naum = Me.ComboCustomerName.Text
                        naum1 = Me.ComboPaymentMethod.Text
                        naum2 = Me.TextFundValue.EditValue
                        naum3 = Me.TextValueOfCheck.EditValue
                        naum4 = Me.TextCheckNumber.Text
                        naum5 = Me.CheckDate.Text
                        naum6 = Me.TextBank.Text
                        naum7 = Me.TextBranch.Text
                        Me.BS.EndEdit()
                        Me.BS.AddNew()
                        CLEARDATA1(Me)
                        Me.CheckTransferToAccounts.Checked = False
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.TEXTID.EditValue = Val(MA)
                        Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.ComboSource.Text = "حركات العملاء"
                        Me.TEXTDebit.EditValue = "0.00"
                        Me.TEXTType.Text = "شيك"
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                        Me.TextCondition.Text = "نقدا_شيك"
                        Me.TEXTStatement.Text = "سداد من العميل" & "- " & Me.ComboCustomerName.Text
                        Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TextMovementSymbol.EditValue = "CA" & Me.TEXTID.EditValue
                        Me.TextCheckNumber.Text = "0"
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.ComboCustomerName.Text = naum
                        Me.ComboPaymentMethod.Text = naum1
                        Me.TextFundValue.EditValue = naum2
                        Me.TextValueOfCheck.EditValue = naum3
                        Me.TextCheckNumber.Text = naum4
                        Me.CheckDate.Text = naum5
                        Me.TextBank.Text = naum6
                        Me.TextBranch.Text = naum7
                        Me.ComboBox1_SelectedIndexChanged(sender, e)
                        Me.ComboBox6_SelectedIndexChanged(sender, e)
                        Dim Frm As New CustomerPay1
                        Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Frm.ShowDialog(Me)
                        Me.TEXTCredit.EditValue = Val(Frm.TextB1.Text)
                        FF = Val(Frm.TextB1.Text)
                        Me.TEXTCredit.EditValue = FF
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.Count()
                        P = Me.BS.Position
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        Me.SAVERECORD()
                        Me.RecordCount()

                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                           "سداد من حساب العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue,
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
                          0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, False,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P + 1
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للعميل" & "- " & Me.ComboCustomerName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم تسويةالسجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        P = Me.BS.Position
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If

                        Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                           "سداد من حساب العميل  " & " _ " & Me.ComboCustomerName.Text, False, TEXTID.EditValue,
                           False, True, ComboCB1.Text, ModuleGeneral.CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
                          0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, False,
                          TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
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
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل  تسوية حركة العملاء", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة الصندوق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            P = BS.Position
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()

                            Me.DELETEDATBANK1()
                            Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.UPDATERECORD()
                            Me.BS.RemoveCurrent()
                            Me.BS.EndEdit()
                            Me.RowCount = Me.BS.Count
                            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                                .WorkerReportsProgress = True,
                                .WorkerSupportsCancellation = True
                            }
                            Me.SaveTab.RunWorkerAsync()
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Me.CheckSettlementDone.Checked = False Then
                    resault = MessageBox.Show("  سيتـم تسديد " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Dim naum, naum1, naum2, naum3, naum4, naum5, naum6, naum7 As String
                        naum = Me.ComboCustomerName.Text
                        naum1 = Me.ComboPaymentMethod.Text
                        naum2 = Me.TextFundValue.EditValue
                        naum3 = Me.TextValueOfCheck.EditValue
                        naum4 = Me.TextCheckNumber.Text
                        naum5 = Me.CheckDate.Text
                        naum6 = Me.TextBank.Text
                        naum7 = Me.TextBranch.Text
                        Me.BS.EndEdit()
                        Me.BS.AddNew()
                        CLEARDATA1(Me)
                        Me.CheckTransferToAccounts.Checked = False
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = True
                        Me.CheckTransferToAccounts.Checked = True
                        Me.TEXTID.EditValue = Val(MA)
                        Me.TEXTPreviousBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.ComboSource.Text = "حركات العملاء"
                        Me.TEXTDebit.EditValue = "0.00"
                        Me.TEXTType.Text = "اخرى"
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
                        Me.TextCondition.Text = "اخرى"
                        Me.TEXTStatement.Text = "سداد من العميل" & "- " & Me.ComboCustomerName.Text
                        Me.TEXTTotal.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.TextMovementSymbol.EditValue = "CA" & Me.TEXTID.EditValue
                        Me.TextCheckNumber.Text = "0"
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.ComboCustomerName.Text = naum
                        Me.ComboPaymentMethod.Text = naum1
                        Me.TextFundValue.EditValue = naum2
                        Me.TextValueOfCheck.EditValue = naum3
                        Me.TextCheckNumber.Text = naum4
                        Me.CheckDate.Text = naum5
                        Me.TextBank.Text = naum6
                        Me.TextBranch.Text = naum7
                        Me.ComboBox1_SelectedIndexChanged(sender, e)
                        Me.ComboBox6_SelectedIndexChanged(sender, e)
                        Dim Frm As New CustomerPay1
                        Frm.TextB1.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Frm.ShowDialog(Me)
                        Me.TEXTCredit.EditValue = Val(Frm.TextB1.Text)
                        FF = Val(Frm.TextB1.Text)
                        Me.TEXTCredit.EditValue = FF
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.Count()
                        P = Me.BS.Position
                        Me.TextDateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        Me.SAVERECORD()
                        Me.RecordCount()
                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count
                        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Me.BS.Position = P + 1
                        Insert_Actions(Me.TEXTID.EditValue, "سداد للعميل" & "- " & Me.ComboCustomerName.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم تسويةالسجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        P = Me.BS.Position
                        Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, MA)), "0.000")
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.CheckSettlementDone.Checked = True
                        Me.CheckLogReview.Checked = False
                        Me.CheckTransferToAccounts.Checked = True
                        Me.Cursor = Cursors.WaitCursor
                        Me.PictureBox2.Visible = True
                        If Me.TextMovementRestrictions1.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATCASHIER1()
                        End If
                        If Me.TextCheckMovementNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                        Else
                            Me.DELETEDATBANK1()
                        End If

                        Me.SaveMOVES1()
                        Me.SaveMOVESDATARecord1()
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
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل  تسوية حركة العملاء", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة العملاء ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckSettlementDone.Checked = False
                            P = BS.Position
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.DELETEDATBANK1()
                            Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) - Val(Me.TEXTDebit.EditValue) + Val(Me.TEXTCredit.EditValue), "0.000")
                            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف السجل") = MsgBoxResult.Cancel Then Exit Sub
                            Me.Cursor = Cursors.WaitCursor
                            Me.PictureBox2.Visible = True
                            Me.UPDATERECORD()
                            Me.BS.RemoveCurrent()
                            Me.BS.EndEdit()
                            Me.RowCount = Me.BS.Count
                            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
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
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim N As Double
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
            Dim sql As String = "INSERT INTO CABLES(IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CAB24, CAB25, CAB26, CAB27, CAB28, CB1, BN2, USERNAME, Cuser, COUSER, da, ne) VALUES  (@IDCAB, @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB7, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB13, @CAB14, @CAB15, @CAB16, @CAB17, @CAB18, @CAB19, @CAB20, @CAB21, @CAB22, @CAB23, @CAB24, @CAB25, @CAB26, @CAB27, @CAB28, @CB1, @BN2, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(sql, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCAB", SqlDbType.BigInt).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CAB2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = Me.TextDateMovementHistory.Text
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = Me.TEXTType.Text
                .Parameters.Add("@CAB7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = Me.TextCondition.Text
                .Parameters.Add("@CAB13", SqlDbType.NVarChar).Value = Me.TextCustomerType.Text
                .Parameters.Add("@CAB14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CAB15", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CAB16", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CAB17", SqlDbType.NVarChar).Value = Me.ComboSource.Text
                .Parameters.Add("@CAB18", SqlDbType.Date).Value = Me.CheckDate.Text
                .Parameters.Add("@CAB19", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@CAB20", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB21", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CAB22", SqlDbType.NVarChar).Value = Me.TextBank.Text
                .Parameters.Add("@CAB23", SqlDbType.NVarChar).Value = Me.TextBranch.Text
                .Parameters.Add("@CAB24", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB25", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB26", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CAB27", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CAB28", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = 0
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = sql
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DELETEDATCASHIER1()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber1, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SaveMOVES1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            SEARCHDATA.MAXIDMOVES()
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2.ToString.Trim
                .Parameters.Add("@MOV3", SqlDbType.DateTime).Value = MaxDate.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Me.LabelAutoEx.Text.Trim
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = True
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text.Trim
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text.Trim
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "قبض"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "CA"
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
    Private Sub DELETEDATMOVES()
        Try
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions1.Text, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SaveMOVESDATARecord1()
        Try
            Dim p As Integer
            Dim Box, Box1, Box2, Box3, Box4, Box5 As Integer
            nem = "سداد فاتورة العملاء رقم " & "_" & Me.TEXTID.EditValue
            nem1 = "سداد فاتورة العملاء نقدي رقم " & "_" & Me.TEXTID.EditValue
            nem2 = "سداد فاتورة العملاء بيموجب مستند رقم " & "_" & Me.TextCheckNumber.Text
            nem3 = "سداد فاتورة العملاء ذمم مدينة "
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

            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            Dim CMD As New SqlClient.SqlCommand

            With strSQL
                If Me.ComboPaymentMethod.Text.Trim = "نقدا" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TextFundValue.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
               & p.ToString + 1 & "','" & Me.TextCreditAccount.Text & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextFundValue.EditValue & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.ComboPaymentMethod.Text.Trim = "شيك" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TextValueOfCheck.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
          & p.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TextValueOfCheck.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.ComboPaymentMethod.Text.Trim = "نقدا_شيك" Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                   & p.ToString & "','" & ModuleGeneral.CB2.ToString & "','" & Box.ToString.Trim & "','" & Me.TextFundValue.EditValue & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                   & p.ToString + 1 & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TextValueOfCheck.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & p.ToString + 2 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TEXTCredit.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & True & "','" & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                Else

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                   & p.ToString & "','" & Me.ComboDebitAccount.Text & "','" & Box2.ToString.Trim & "','" & Me.TEXTCredit.EditValue & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & "','" & True & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                & p.ToString + 1 & "','" & Me.TextCreditAccount.Text.Trim & "','" & Box4.ToString.Trim & "','" & 0 & "','" & Me.TEXTCredit.EditValue & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextMovementSymbol.EditValue & "','" & Me.TEXTID.EditValue & True & "','" & "','" & T2.ToString.Trim & "')"
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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHAccount_no(Me.ComboBox5.Text)
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
        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
        Me.TextFundMovementNumber1.Text = SEARCHDATA.CSH1B

        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
        SEARCHDATA.SEARCHDIDChecks1(Me.TEXTDocumentNumber.Text, Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber1.Text = SEARCHDATA.IDCH2

    End Sub

    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
            Case "شيك"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "نقدا_شيك"
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub

    Private Sub  AccountsEnquiry()
        On Error Resume Next
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
            Case "شيك"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me. AccountsEnquiry()
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
            f.TEXTFileSubject.Text = "مستندات حسابات العملاء "
            f.TextFileDescription.Text = "ارفاق مستندات حسابات العملاء"
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
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        FundBalance()
        LabelFundBalance.Text = "رصيد" & " " & ModuleGeneral.CB2 & " " & ":"
    End Sub


    Private Sub DateMovementHistory_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DateMovementHistory.ValueChanged
        On Error Resume Next
        Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub

End Class

