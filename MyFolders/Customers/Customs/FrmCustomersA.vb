Option Explicit Off
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.SqlClient
Imports DevExpress.XtraSplashScreen

Public Class FrmCustomersA
    Inherits Form

    ReadOnly T As Boolean = True, F As Boolean = False
    Private SqlDataAdapter1 As New SqlDataAdapter
    ReadOnly SqlDataAdapter2 As New SqlDataAdapter


    Private Const CASH_INVOICE_TEXT As String = "فاتورة بيع نقدى"
    Private Const CREDIT_INVOICE_TEXT As String = "فاتورة بيع أجـل"
    Private Const LOADING_TEXT As String = "تحميل البيانات"
    Private Const TOTAL_INVOICE_TEXT As String = "إجمالي الفاتورة"

    ' Read-only fields and data adapters
    Private ds As New DataSet
    Private ReadOnly BS As New BindingSource
    Private ReadOnly SearchTimer As New Timer With {.Interval = 300} ' Debounce timer for search

    ' Instance variables
    Private TotalItems As Double = 0.0
    Private TotalDiscount As Double = 0.0


    Public CompareDiscount As Double = 0.0


    ReadOnly dt As DataTable
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim ItemRow As Boolean = False
    Dim RowCount As Integer = 0

    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Dim p As String
    Dim TypeCustomer As String

    Public TB1 As String
    Public TB2 As String
    Public TB3 As String

    Dim IDCAB1 As Int64
    ReadOnly IDCAB2 As Int64
    Dim Store As Integer
    ReadOnly ChkPD As Boolean = False
    Dim FundValue As Double = 0.000
    Dim ValueOfCheck As Double = 0.000

    Dim CodItem As Integer
    Dim num As String = ""
    Dim CodItemA As Integer = 0

    Dim ItemBalance As Double = 0.0
    Dim PreviousBalance As Double = 0.0
    Dim CurrentBalance As Double = 0.0
    Dim UnitPriceA As Double = 0.0
    Dim SellingPrice As Double = 0.0
    Dim discountPercent As Double = 0.0
    Private Sub FrmCustomersA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.Button3_Click(sender, e)
                    Case Keys.F5
                        'PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.Button4_Click(sender, e)
                    Case Keys.F10
                        Me.ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonTransferofAccounts1_Click(sender, e)
                    Case Keys.F12
                        Me.Button2_Click(sender, e)
                    Case Keys.C And (e.Alt And Not e.Control And Not e.Shift)
                        Me.CmdCust_Click(sender, e)
                    Case Keys.V And (e.Alt And Not e.Control And Not e.Shift)
                        Me.CmdItems_Click(sender, e)
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

    Private Sub FrmCustomersA_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        Try
            Me.BackgroundImage = img
            Me.TabPage1.BackgroundImage = img

            load1.Text = LOADING_TEXT
            load1.Enabled = True
            ' Disable buttons initially
            Me.load1.Enabled = True
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.CmdItems.Enabled = False
            Me.CmdCust.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferofAccounts1.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.FIRSTBUTTON.Enabled = False
            Me.PREVIOUSBUTTON.Enabled = False
            Me.NEXTBUTTON.Enabled = False
            Me.LASTBUTTON.Enabled = False

            ' Setup timer for search debouncing
            AddHandler SearchTimer.Tick, AddressOf SearchTimer_Tick
            PurchSales_Check = True
            TestkeyAccounts(keyAccounts.GetValue("SalesAccount_No", SalesAccount_No))
            If TestkeyAccounts_Check Then
                AccountNoAktevd = keyAccounts.GetValue("SalesAccount_No", SalesAccount_No)
            End If
            PanelAccount.Enabled = Check_OptionsTransforAccounts.Checked
        Catch ex As Exception
            MessageBox.Show($"Load error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub StartBackgroundWorker(worker As BackgroundWorker)
        worker.WorkerSupportsCancellation = True
        worker.WorkerReportsProgress = True
        If Not worker.IsBusy Then worker.RunWorkerAsync()
    End Sub

    Public Sub DanLOd()
        StartBackgroundWorker(BackgroundWorker1)
    End Sub

    Public Sub Load_Click()
        StartBackgroundWorker(BackgroundWorker2)
    End Sub


    'this constraint cannot be enabled as not all values have corresponding parent values
    Private Sub LoadSalesData(cash As Boolean, invoiceNumber As String)
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            Using conn As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("", conn)
                Dim cmd2 As New SqlCommand("", conn)

                ' Select only necessary columns for SALES
                If cash Then
                    LblCASH_INVOICE.Text = CASH_INVOICE_TEXT
                    cmd1.CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, WarehouseNumber, WarehouseName, CB1, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE CUser=@CUser AND Year(SLS3)=@FiscalYear AND deleted=0 AND type_cash=1 AND SLS2=@InvoiceNumber"
                Else
                    LblCASH_INVOICE.Text = CREDIT_INVOICE_TEXT
                    ComboPaymentMethod1.Text = "العملاء مدينين"
                    ComboPaymentMethod1.Enabled = False
                    GroupCHKS.Enabled = False
                    GroupCHKS1.Enabled = False
                    cmd1.CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, WarehouseNumber, WarehouseName, CB1, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE CUser=@CUser AND Year(SLS3)=@FiscalYear AND deleted=0 AND type_cash=0 AND SLS2=@InvoiceNumber"
                End If

                ' Modified SALESITEMS query to match SALES filters
                cmd2.CommandText = "SELECT SITM1, SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, ((SITM5 * SITM6) * (100 - SITM7)) / 100 AS SITM8, SITM9, SITM10, SITM11, SLS2 " &
                               "FROM SALESITEMS " &
                               "WHERE SLS2 IN (" &
                               "    SELECT SLS2 " &
                               "    FROM SALES " &
                               "    WHERE CUser=@CUser " &
                               "      AND Year(SLS3)=@FiscalYear " &
                               "      AND deleted=0 " &
                               "      AND type_cash=@TypeCash " &
                               "      AND SLS2=@InvoiceNumber" &
                               ") " &
                               "ORDER BY SLS2"

                ' Add parameters for cmd1
                cmd1.Parameters.AddWithValue("@CUser", CUser)
                cmd1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                cmd1.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber)

                ' Add parameters for cmd2
                cmd2.Parameters.AddWithValue("@CUser", CUser)
                cmd2.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                cmd2.Parameters.AddWithValue("@TypeCash", cash)
                cmd2.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber)

                conn.Open()
                Using adapter1 As New SqlDataAdapter(cmd1), adapter2 As New SqlDataAdapter(cmd2)
                    ds.Clear()
                    adapter1.Fill(ds, "SALES")
                    adapter2.Fill(ds, "SALESITEMS")
                End Using

                If Not ds.Relations.Contains("REL1") Then
                    Me.ds.Relations.Add("REL1", Me.ds.Tables("SALES").Columns("SLS2"), Me.ds.Tables("SALESITEMS").Columns("SLS2"), True)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Data load error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
    End Sub

    Private Sub LoadSalesData1(cash As Boolean)
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            Using conn As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("", conn)
                Dim cmd2 As New SqlCommand("", conn)

                ' Select only necessary columns for SALES
                If cash Then
                    LblCASH_INVOICE.Text = CASH_INVOICE_TEXT
                    cmd1.CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, WarehouseNumber, WarehouseName, CB1, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE CUser='" & CUser & "' AND Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND deleted ='" & False & "' AND type_cash ='" & True & "' AND (SLS2 ='" & Trim(Me.TB1) & "' OR SLS4 ='" & Trim(Me.TB2) & "' OR SLS13 ='" & Trim(Me.TB3) & "')"
                Else
                    LblCASH_INVOICE.Text = CREDIT_INVOICE_TEXT
                    ComboPaymentMethod1.Text = "العملاء مدينين"
                    ComboPaymentMethod1.Enabled = False
                    GroupCHKS.Enabled = False
                    GroupCHKS1.Enabled = False
                    cmd1.CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, WarehouseNumber, WarehouseName, CB1, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE CUser='" & CUser & "' AND Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND deleted ='" & False & "' AND type_cash ='" & False & "' AND (SLS2 ='" & Trim(Me.TB1) & "' OR SLS4 ='" & Trim(Me.TB2) & "' OR SLS13 ='" & Trim(Me.TB3) & "')"
                End If

                ' Modified SALESITEMS query to only include records with matching SLS2 values
                cmd2.CommandText = "SELECT SITM1, SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, ((SITM5 * SITM6) * (100 - SITM7)) / 100 AS SITM8, SITM9, SITM10, SITM11, SLS2 FROM SALESITEMS WHERE SLS2 IN (SELECT SLS2 FROM SALES WHERE CUser='" & CUser & "' AND Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND deleted ='" & False & "' AND type_cash ='" & cash & "' AND (SLS2 ='" & Trim(Me.TB1) & "' OR SLS4 ='" & Trim(Me.TB2) & "' OR SLS5 ='" & Trim(Me.TB3) & "'))"

                conn.Open()
                Using adapter1 As New SqlDataAdapter(cmd1), adapter2 As New SqlDataAdapter(cmd2)
                    ds.Clear()
                    adapter1.Fill(ds, "SALES")
                    adapter2.Fill(ds, "SALESITEMS")
                End Using
                If Not ds.Tables("SALESITEMS").Columns.Contains("SLS2") OrElse Not ds.Tables("SALES").Columns.Contains("SLS2") Then
                    MessageBox.Show("One or both tables are missing the SLS2 column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                ' Check if required columns exist
                If Not ds.Tables("SALESITEMS").Columns.Contains("SLS2") OrElse Not ds.Tables("SALES").Columns.Contains("SLS2") Then
                    MessageBox.Show("One or both tables are missing the SLS2 column.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                ' Add the relationship if it doesn’t already exist
                If Not ds.Relations.Contains("REL1") Then
                    Me.ds.Relations.Add("REL1", Me.ds.Tables("SALES").Columns("SLS2"), Me.ds.Tables("SALESITEMS").Columns("SLS2"), True)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Data load error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
    End Sub

    'Slow loading table data
    ''-------------------------------
    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        LoadSalesData(Cash, Me.TB1)
        Me.Invoke(Sub()
                      BS.DataSource = ds
                      BS.DataMember = "SALES"
                      ds.EnforceConstraints = True
                      With DataGridView1
                          .DataSource = BS
                          .DataMember = "REL1"
                      End With
                  End Sub)
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        PopulateComboBoxes()
        Button3.Enabled = True
        load1.Text = TOTAL_INVOICE_TEXT
        load1.Enabled = False
        TBBoolean1 = False
        TBBoolean2 = False
        TBBoolean3 = False
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub BackgroundWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        LoadSalesData1(Cash)
        Me.Invoke(Sub()
                      BS.DataSource = ds
                      BS.DataMember = "SALES"
                      ds.EnforceConstraints = True
                      With DataGridView1
                          .DataSource = BS
                          .DataMember = "REL1"
                      End With
                  End Sub)

    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        PopulateComboBoxes()
        Button3.Enabled = True
        load1.Text = TOTAL_INVOICE_TEXT
        load1.Enabled = False
        TBBoolean1 = False
        TBBoolean2 = False
        TBBoolean3 = False
        SplashScreenManager.CloseForm(False)
    End Sub

    Private Sub PopulateComboBoxes()
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, ComboCB1)
        If ComboCB1.Items.Count > 0 Then ComboCB1.SelectedIndex = 0
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, ComboCustomerName)
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, ComboStore)
        MangUsers()
        RecordCount()
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferofAccounts1.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.DataGridView1.Enabled = False
            Me.txtItem2.Enabled = False
            Me.txtq.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTPermissionNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.txtItem2.Enabled = False
            Me.TEXTDiscountPercentage.Enabled = False
            Me.TEXTTaxRate.Enabled = False
            Me.ComboPaymentMethod1.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.CheckDate.Enabled = False
            Me.TextBank.Enabled = False
            Me.TextBranch.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False

            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonTransferofAccounts1.Enabled = True
            Me.ButtonPostToCustomerTraffic.Enabled = True

            Me.DataGridView1.Enabled = True
            Me.txtItem2.Enabled = True
            Me.txtq.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTPermissionNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.txtItem2.Enabled = True
            Me.TEXTDiscountPercentage.Enabled = True
            Me.TEXTTaxRate.Enabled = True
            Me.ComboPaymentMethod1.Enabled = True
            Me.TextFundValue.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.TextCheckNumber.Enabled = True
            Me.CheckDate.Enabled = True
            Me.TextBank.Enabled = True
            Me.TextBranch.Enabled = True
            Me.TextValueOfCheck.Enabled = True
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferofAccounts1.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.DataGridView1.Enabled = False
            Me.txtItem2.Enabled = False
            Me.txtq.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTPermissionNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.txtItem2.Enabled = False
            Me.TEXTDiscountPercentage.Enabled = False
            Me.TEXTTaxRate.Enabled = False
            Me.ComboPaymentMethod1.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.CheckDate.Enabled = False
            Me.TextBank.Enabled = False
            Me.TextBranch.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False

            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonTransferofAccounts1.Enabled = True
            Me.ButtonPostToCustomerTraffic.Enabled = True

            Me.DataGridView1.Enabled = True
            Me.txtItem2.Enabled = True
            Me.txtq.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTPermissionNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.txtItem2.Enabled = True
            Me.TEXTDiscountPercentage.Enabled = True
            Me.TEXTTaxRate.Enabled = True
            Me.ComboPaymentMethod1.Enabled = True
            Me.TextFundValue.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.TextCheckNumber.Enabled = True
            Me.CheckDate.Enabled = True
            Me.TextBank.Enabled = True
            Me.TextBranch.Enabled = True
            Me.TextValueOfCheck.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True

            Me.ComboDebitAccount.Enabled = True
            Me.PicCreditAccount.Enabled = True
        End If
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
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            'Application.DoEvents()
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False


            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            ItemRow = False
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf Me.PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If

    End Sub

    Private Sub Text6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTDiscount.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.CalculateDiscount()
            If CDbl(Val(Me.TEXTDiscount.EditValue)) > CDbl(CompareDiscount) Then
                MsgBox("لا يجب ان يكون الخصم أكبر من قيمة الفاتورة")
                Me.TEXTDiscountPercentage.Focus()
            Else
                Me.Totalcount()
                If Me.EDITBUTTON.Enabled = False Then

                Else
                    Me.EDITBUTTON.Focus()
                End If
            End If
        End If

    End Sub

    Private Sub UPDATEBALANCEITEMS()
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    Dim sql As New SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @QUANTITY WHERE STOCKSITEMS.SKITM4='" & Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value & "'", Consum)
                    Dim CMD As New SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .CommandType = CommandType.Text
                        .Connection = Consum
                        .Parameters.Add("@QUANTITY", System.Data.SqlDbType.Float).Value = Val(Me.TEXTCurrentBalance.Text)
                        .CommandText = sql.CommandText
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub CalculateDiscount()
        Dim Total1 As Double
        Dim Row As DataGridViewRow
        For Each Row In Me.DataGridView1.Rows
            Dim celV1 As DataGridViewTextBoxCell = Row.Cells("SITM8")
            If IsNumeric(celV1.Value) = True Then
                Total1 += celV1.Value
            End If
        Next
        CompareDiscount = CDbl(Total1)
    End Sub

    Private Sub Totalcount()
        Dim Total1 As Double = 0
        Dim Row As DataGridViewRow
        For Each Row In Me.DataGridView1.Rows
            Dim celV1 As DataGridViewTextBoxCell = Row.Cells("SITM8")
            If IsNumeric(celV1.Value) = True Then
                Total1 += celV1.Value
            End If
        Next
        'Me.TEXTTotal.Text = Total1 + CDbl(Val(Me.TEXTSalesTaxes.Text)) - CDbl(Val(Me.TEXTDiscount.EditValue))
    End Sub

    Private Sub TextBox20_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        On Error Resume Next
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
    End Sub

    Public Sub RecordCount()
        Try
            Dim TotalRecords As Integer = Me.BS.Count
            Dim CurrentRecord As Integer = Me.BS.Position + 1

            ' Update records label
            Me.RECORDSLABEL.Text = $"{CurrentRecord} من {TotalRecords}"

            ' Enable/disable navigation buttons based on the current position
            Dim Back As Boolean = Me.BS.Position > 0
            Dim Forward As Boolean = Me.BS.Position < TotalRecords - 1
            Me.FIRSTBUTTON.Enabled = Back
            Me.PREVIOUSBUTTON.Enabled = Back
            Me.NEXTBUTTON.Enabled = Forward
            Me.LASTBUTTON.Enabled = Forward

            ' Display record
            Me.DISPLAYRECORD()

            ' Perform additional calculations and operations
            Me.CalculateDiscount()
            Me.Totalcount()
            Me.AutoEx()
            Me.InternalAuditorType()

            ' Update controls' state
            Me.TEXTInvoiceNumber.Enabled = False
            Me.Button3.Enabled = True
            TotalDiscount = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(r) If(IsDBNull(r.Cells("SITM11").Value), 0, Val(r.Cells("SITM11").Value)))
            TotalItems = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(r) If(IsDBNull(r.Cells("SITM8").Value), 0, Val(r.Cells("SITM8").Value)))

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRecordCount", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    Private Sub DISPLAYRECORD()
        Try
            If Me.ds.Tables("SALES").Rows.Count > 0 Then
                Dim currentRow As DataRow = Me.ds.Tables("SALES").Rows(Me.BS.Position)

                With Me
                    .TEXTID.Text = currentRow("SLS1").ToString()
                    .TEXTInvoiceNumber.EditValue = currentRow("SLS2").ToString()
                    .DateMovementHistory.Text = currentRow("SLS3").ToString()
                    .TEXTPermissionNumber.Text = currentRow("SLS4").ToString()
                    .ComboCustomerName.Text = currentRow("SLS5").ToString()
                    .TEXTItemsTotal.Text = currentRow("SLS6").ToString()
                    .TEXTDiscountPercentage.Text = currentRow("SLS7").ToString()
                    .TEXTDiscount.EditValue = currentRow("SLS8").ToString()
                    .TEXTNetItems.Text = currentRow("SLS9").ToString()
                    .TEXTTaxRate.Text = currentRow("SLS10").ToString()
                    .TEXTSalesTaxes.Text = currentRow("SLS11").ToString()
                    .TextTotalItemsWithTaxes.Text = currentRow("SLS12").ToString()
                    .TextCustomerNumber.EditValue = currentRow("SLS13").ToString()
                    .TEXTTotal.Text = currentRow("SLS14").ToString()
                    .TEXTTotalN.Text = currentRow("SLS15").ToString()
                    .CheckTransferAccounts.Checked = currentRow("SLS17").ToString()
                    .TEXTReviewDate.Text = currentRow("SLS18").ToString()
                    .TextMovementSymbol.EditValue = currentRow("SLS19").ToString()
                    .CheckPostToCustomerTraffic.Checked = currentRow("SLS20").ToString()
                    .ComboPaymentMethod1.Text = currentRow("SLS21").ToString()
                    .TextFundValue.EditValue = currentRow("SLS22").ToString()
                    .TextValueOfCheck.EditValue = currentRow("SLS23").ToString()
                    .ComboCheckDrawerName.Text = currentRow("SLS24").ToString()
                    .TextCheckDrawerCode.Text = currentRow("SLS25").ToString()
                    .TextCheckNumber.Text = currentRow("SLS26").ToString()
                    .CheckDate.Text = currentRow("SLS27").ToString()
                    .TextBank.Text = currentRow("SLS28").ToString()
                    .TextBranch.Text = currentRow("SLS29").ToString()
                    .CheckLogReview.Checked = currentRow("SLS30").ToString()
                    .CheckTransferAccounts1.Checked = currentRow("SLS31").ToString()
                    .ComboStore.Text = currentRow("WarehouseNumber").ToString()
                    .TextWarehouseName.Text = currentRow("WarehouseName").ToString()
                    .ComboCB1.Text = currentRow("CB1").ToString()
                    .RadioButton1.Text = currentRow("TYPE_CASH").ToString()
                    .RadioButton2.Text = currentRow("TYPE_CRDT").ToString()
                    .TEXTUserName.Text = currentRow("USERNAME").ToString()
                    .TextDefinitionDirectorate.Text = currentRow("COUser").ToString()
                    .TEXTReferenceName.Text = currentRow("Auditor").ToString()
                    .TEXTAddDate.Text = currentRow("da").ToString()
                    .TextTimeAdd.Text = currentRow("ne").ToString()
                    .TEXTReviewDate.Text = currentRow("da1").ToString()
                    .TextreviewTime.Text = currentRow("ne1").ToString()
                End With

                Auditor("SALES", "USERNAME", "SLS1", Me.TEXTID.Text, "")
                Logentry = Uses
                'Else
                '    MsgBox("لا يوجد بيانات لعرضها" & vbCrLf & " تنبيه : عرض البيانات " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")

            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorDISPLAYRECORD", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub


    'Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
    'Me.RecordCount()
    'End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.Button2.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.CmdItems.Enabled = True
        Me.CmdCust.Enabled = True
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonTransferofAccounts1.Enabled = TransferofAccounts
        Me.ButtonPostToCustomerTraffic.Enabled = TransferofAccounts
        Me.ButtonAttachDocument.Enabled = LockAddRow
    End Sub

    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTTotalN.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub

    Private Sub TEXT2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.ComboCustomerName.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboCustomerName.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.TEXTPermissionNumber.Focus()
        End If
    End Sub

    Private Sub TEXT3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTPermissionNumber.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.DateMovementHistory.Focus()
        End If
    End Sub

    Private Sub DATETIMEPICKER_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles DateMovementHistory.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtItem2.Focus()
        End If
    End Sub


    Private Sub SaveSALESITEMS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO SALESITEMS (SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, SITM8, SITM9, SITM10, SITM11, SLS2) VALUES     (@SITM2, @SITM3, @SITM4, @SITM5, @SITM6, @SITM7, @SITM8, @SITM9, @SITM10, @SITM11, @SLS2)", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@SITM1", SqlDbType.Int, 4, "SITM1")
            .Parameters.Add("@SITM2", SqlDbType.Int, 4, "SITM2")
            .Parameters.Add("@SITM3", SqlDbType.NVarChar, 255, "SITM3")
            .Parameters.Add("@SITM4", SqlDbType.NVarChar, 255, "SITM4")
            .Parameters.Add("@SITM5", SqlDbType.Float, 8, "SITM5")
            .Parameters.Add("@SITM6", SqlDbType.Float, 8, "SITM6")
            .Parameters.Add("@SITM7", SqlDbType.Float, 8, "SITM7")
            .Parameters.Add("@SITM8", SqlDbType.Float, 8, "SITM8")
            .Parameters.Add("@SITM9", SqlDbType.Float, 8, "SITM9")
            .Parameters.Add("@SITM10", SqlDbType.Float, 8, "SITM10")
            .Parameters.Add("@SITM11", SqlDbType.Float, 8, "SITM11")
            .Parameters.Add("@SLS2", SqlDbType.BigInt, 8, "SLS2")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "SALESITEMS", New DataColumnMapping() {New DataColumnMapping("SITM1", "SITM1"), New DataColumnMapping("SITM2", "SITM2"), New DataColumnMapping("SITM3", "SITM3"), New DataColumnMapping("SITM4", "SITM4"), New DataColumnMapping("SITM5", "SITM5"), New DataColumnMapping("SITM6", "SITM6"), New DataColumnMapping("SITM7", "SITM7"), New DataColumnMapping("SITM8", "SITM8"), New DataColumnMapping("SITM9", "SITM9"), New DataColumnMapping("SITM10", "SITM10"), New DataColumnMapping("SLS2", "SLS2")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds, "SALESITEMS")
        Consum.Close()

    End Sub


    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن حذف  السجل الحالى لأنه مرحل ... يمكن حذف من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        If Me.TextMovementRestrictions.Text = "" Then
            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
        Else
            Me.DELETEDATMOVESDATA()
            Me.DELETEDATMOVESDATA1()
        End If

        If Me.TextFundMovementNumber.Text = "" Then
            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
        Else
            Me.DELETECASHIER()
        End If
        If Me.TextCheckMovementNumber.Text = "" Then
            MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
        Else
            Me.DELETEChecks()
        End If
        MYDELETERECORD("SALES", "SLS1", Me.TEXTID, Me.BS, True)
        MYDELETERECORD("SALESITEMS", "SLS2", Me.TEXTInvoiceNumber, Me.BS, True)
        Me.DanLOd()
        Insert_Actions(Me.TEXTID.Text, "حذف", Me.Text)
    End Sub

    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
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
        If Me.CheckTransferAccounts.Checked And Me.CheckTransferAccounts1.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTReferenceName.Text = CUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.UPDATESALES()
        Me.DanLOd()
        Me.UPDATESALES()
        Me.BS.Position = P
        Me.RecordCount()
        Insert_Actions(Me.TEXTID.Text, "مراجعة", Me.Text)
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTReferenceName.Text = CUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.UPDATESALES()
        Me.DanLOd()
        Me.BS.Position = P
        Me.RecordCount()
        Insert_Actions(Me.TEXTID.Text, "إلغاء مراجعة", Me.Text)
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
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
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub

    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub

    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click

        Try
            Dim ch As Double = Val(Me.TextTotalItemsWithTaxes.Text)
            Dim ch11 As Double = Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue)
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Val(ch).ToString("0.000") <> Val(ch11).ToString("0.000") Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = True Then
                MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
                Exit Sub
            End If
            If (Me.DataGridView1.Rows.Count - 1) = 0 Then
                MsgBox("لا يوجد مواد ... يجب ادخال مادة واحدة على الافل", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Me.Button5_Click(sender, e)

            Me.DataGridView1.ClearSelection()
            Dim nextRow As DataGridViewRow
            nextRow = Me.DataGridView1.Rows(0)
            Me.DataGridView1.Rows(0).Selected = True
            DataGridView1.CurrentCell = DataGridView1("SITM2", DataGridView1.Rows(0).Index)

            Static Dim P As Integer
            Me.p = Me.BS.Position
            If Me.Ch1.Checked = False Then
                Me.Ch1.Checked = True
            End If
            Me.UPDATESALES()
            Me.SaveSALESITEMS()
            Me.UPDATESALESITEMS()
            nextRow = Me.DataGridView1.Rows(0)
            Me.DataGridView1.Rows(0).Selected = True
            'If ItemRow = True Then
            '    MsgBox(1)
            '    Me.DanLOd()
            '    Me.UPDATESALES() '  راس الفاتورة
            '    Me.UPDATESALESITEMS() ' البنود
            'End If

            Me.BS.Position = P


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error EDITBUTTON", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End Try
    End Sub

    Private Sub UPDATESALES()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update SALES SET  SLS1 = @SLS1, SLS3 = @SLS3, SLS4 = @SLS4, SLS5 = @SLS5, SLS6 = @SLS6, SLS7 = @SLS7, SLS8 = @SLS8, SLS9 = @SLS9, SLS10 = @SLS10, SLS11 = @SLS11, SLS12 = @SLS12, SLS13 = @SLS13, SLS14 = @SLS14, SLS15 = @SLS15, SLS16 = @SLS16,  SLS17 = @SLS17, SLS18 = @SLS18, SLS20 = @SLS20, SLS21 = @SLS21, SLS22 = @SLS22, SLS23 = @SLS23, SLS24 = @SLS24, SLS25 = @SLS25, SLS26 = @SLS26, SLS27 = @SLS27, SLS28 = @SLS28, SLS29 = @SLS29, SLS30 = @SLS30, SLS31 = @SLS31,WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  CB1 = @CB1, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, TYPE_CASH = @TYPE_CASH, TYPE_CRDT = @TYPE_CRDT WHERE  SLS2 = @SLS2", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SLS2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumber.EditValue
                .Parameters.Add("@SLS1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@SLS3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS4", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text
                .Parameters.Add("@SLS5", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@SLS6", SqlDbType.NVarChar).Value = Me.TEXTItemsTotal.Text
                .Parameters.Add("@SLS7", SqlDbType.NVarChar).Value = Me.TEXTDiscountPercentage.EditValue
                .Parameters.Add("@SLS8", SqlDbType.NVarChar).Value = Me.TEXTDiscount.EditValue
                .Parameters.Add("@SLS9", SqlDbType.NVarChar).Value = Me.TEXTNetItems.Text
                .Parameters.Add("@SLS10", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.EditValue
                .Parameters.Add("@SLS11", SqlDbType.NVarChar).Value = Me.TEXTSalesTaxes.Text
                .Parameters.Add("@SLS12", SqlDbType.NVarChar).Value = Me.TextTotalItemsWithTaxes.Text
                .Parameters.Add("@SLS13", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@SLS14", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@SLS15", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@SLS17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@SLS18", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS20", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked)
                .Parameters.Add("@SLS21", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod1.Text
                .Parameters.Add("@SLS22", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@SLS23", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@SLS24", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@SLS25", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@SLS26", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@SLS27", SqlDbType.DateTime).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS28", SqlDbType.NVarChar).Value = Me.TextBank.Text
                .Parameters.Add("@SLS29", SqlDbType.NVarChar).Value = Me.TextBranch.Text
                .Parameters.Add("@SLS30", SqlDbType.Bit).Value = Convert.ToInt32(CheckLogReview.Checked)
                .Parameters.Add("@SLS31", SqlDbType.Bit).Value = Convert.ToInt32(CheckTransferAccounts1.Checked)
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Store
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If Cash = True Then
                    .Parameters.Add("@SLS16", SqlDbType.NVarChar).Value = "نقــــــدى"
                    .Parameters.Add("@TYPE_CASH", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CRDT", SqlDbType.Bit).Value = False
                Else
                    .Parameters.Add("@SLS16", SqlDbType.NVarChar).Value = "أجـــــــل"
                    .Parameters.Add("@TYPE_CRDT", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CASH", SqlDbType.Bit).Value = False
                End If
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

    'Private Sub UPDATESALESITEMS()
    '    On Error Resume Next
    '    Dim Consum As New SqlConnection(constring)
    '    Dim SQL As New SqlCommand("UPDATE SALESITEMS SET SITM2 = @SITM2, SITM3 = @SITM3, SITM4 = @SITM4, SITM5 = @SITM5, SITM6 = @SITM6, SITM7 = @SITM7, SITM8 = @SITM8, SITM9 = @SITM9, SITM10 = @SITM10, SITM11 = @SITM11, SLS2 = @SLS2 WHERE SITM1 = @SITM1", Consum)

    '    With SQL.Parameters
    '        .AddWithValue("@SITM1", SqlDbType.Int).SourceColumn = "SITM1"
    '        .AddWithValue("@SITM2", SqlDbType.Int).SourceColumn = "SITM2"
    '        .AddWithValue("@SITM3", SqlDbType.NVarChar).SourceColumn = "SITM3"
    '        .AddWithValue("@SITM4", SqlDbType.NVarChar).SourceColumn = "SITM4"
    '        .AddWithValue("@SITM5", SqlDbType.Float).SourceColumn = "SITM5"
    '        .AddWithValue("@SITM6", SqlDbType.Float).SourceColumn = "SITM6"
    '        .AddWithValue("@SITM7", SqlDbType.Float).SourceColumn = "SITM7"
    '        .AddWithValue("@SITM8", SqlDbType.Float).SourceColumn = "SITM8"
    '        .AddWithValue("@SITM9", SqlDbType.Float).SourceColumn = "SITM9"
    '        .AddWithValue("@SITM10", SqlDbType.Float).SourceColumn = "SITM10"
    '        .AddWithValue("@SITM11", SqlDbType.Float).SourceColumn = "SITM11"
    '        .AddWithValue("@SLS2", SqlDbType.BigInt).SourceColumn = "SLS2"
    '    End With

    '    If Consum.State = ConnectionState.Open Then Consum.Close()
    '    Consum.Open()

    '    Dim SqlDataAdapter2 As New SqlDataAdapter
    '    SqlDataAdapter2.TableMappings.Add("Table", "SALESITEMS")
    '    SqlDataAdapter2.UpdateCommand = SQL
    '    SqlDataAdapter2.Update(ds, "SALESITEMS")

    '    Consum.Close()
    'End Sub

    Private Sub UPDATESALESITEMS()
        Try
            Using Consum As New SqlConnection(constring)
                Consum.Open()

                Using SQL As New SqlCommand("UPDATE SALESITEMS SET SITM2 = @SITM2, SITM3 = @SITM3, SITM4 = @SITM4, SITM5 = @SITM5, SITM6 = @SITM6, SITM7 = @SITM7, SITM8 = @SITM8, SITM9 = @SITM9, SITM10 = @SITM10, SITM11 = @SITM11, SLS2 = @SLS2 WHERE SITM1 = @SITM1", Consum)
                    ' إعداد المعاملات
                    With SQL.Parameters
                        .Add("@SITM1", SqlDbType.Int).SourceColumn = "SITM1"
                        .Add("@SITM2", SqlDbType.Int).SourceColumn = "SITM2"
                        .Add("@SITM3", SqlDbType.NVarChar).SourceColumn = "SITM3"
                        .Add("@SITM4", SqlDbType.NVarChar).SourceColumn = "SITM4"
                        .Add("@SITM5", SqlDbType.Float).SourceColumn = "SITM5"
                        .Add("@SITM6", SqlDbType.Float).SourceColumn = "SITM6"
                        .Add("@SITM7", SqlDbType.Float).SourceColumn = "SITM7"
                        .Add("@SITM8", SqlDbType.Float).SourceColumn = "SITM8"
                        .Add("@SITM9", SqlDbType.Float).SourceColumn = "SITM9"
                        .Add("@SITM10", SqlDbType.Float).SourceColumn = "SITM10"
                        .Add("@SITM11", SqlDbType.Float).SourceColumn = "SITM11"
                        .Add("@SLS2", SqlDbType.BigInt).SourceColumn = "SLS2"
                    End With

                    Dim SqlDataAdapter2 As New SqlDataAdapter
                    SqlDataAdapter2.TableMappings.Add("Table", "SALESITEMS")
                    SqlDataAdapter2.UpdateCommand = SQL
                    ' تحديث البيانات في ds
                    SqlDataAdapter2.Update(ds, "SALESITEMS")
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error updating data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TEXT2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTInvoiceNumber.LostFocus
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.BS.Position = P
        Me.Totalcount()
        Me.TEXTInvoiceNumber.Enabled = False
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
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
        MaxIDMoves()
    End Sub

    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.LblCASH_INVOICE.Text & " " & "رقم" & " " & ":" & " " & Me.TEXTInvoiceNumber.EditValue & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "للعميل" & " " & ":" & " " & Me.ComboCustomerName.Text & " " & "مثبتة بوثيقة رقم" & " " & ":" & " " & Me.TEXTID.Text & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub

    Private Sub CmdCust_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdCust.Click
        On Error Resume Next
        Dim F As New FrmAllCustomers1
        F.Show()
    End Sub

    Private Sub CmdItems_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdItems.Click
        On Error Resume Next
        Dim F As New FrmStocksA1
        F.Show()
    End Sub

    Private Sub MAXIDCAB1()
        On Error Resume Next
        Dim N As Int64
        Dim Consum As New SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlCommand("SELECT MAX(IDCAB) FROM CABLES   WHERE CUser='" & CUser & "'and  Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Strings.Mid(cmd1.ExecuteScalar(), 7, 5)
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
                NO = "0000"
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
        Dim Consum As New SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlCommand("SELECT MAX(IDCAB) FROM CABLES   WHERE CUser='" & CUser & "'and  Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
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
                NO = "0000"
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

    Private Sub DELETEDATMOVESDATA()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA1()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVDELETVE, Me.BS, True)
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

    Private Sub DELETEDATMOVESDATA4()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions2, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA5()
        Try
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELETA, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETECASHIER()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEChecks()
        Try
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATA()
        Try
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATA1()
        Try
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber1, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust,cust22  FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
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

    Private Sub DELETEDATRECORD()
        Try
            If DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, BS, True)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
        Try
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

            Static Dim S As Integer
            S = Me.BS.Position
            Dim result As Integer

            If BS.Count > 0 Then
                result = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If result = vbYes Then
                    If Me.DataGridView1.SelectedRows.Count > 0 Then
                        Dim x As Integer = Me.DataGridView1.CurrentRow.Index
                        Dim x1 As Int64 = Me.DataGridView1.Rows(x).Cells("SITM1").Value

                        Using Consum As New SqlConnection(constring)
                            Using SQL2 As New SqlCommand("DELETE FROM SALESITEMS WHERE SITM1=@SITM1", Consum)
                                SQL2.Parameters.AddWithValue("@SITM1", x1)
                                Consum.Open()
                                SQL2.ExecuteNonQuery()
                            End Using
                        End Using

                        MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, Me.BS, True)

                        For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                            Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                        Next
                    Else
                        MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
                    End If

                    'Me.DanLOd()
                    'Me.BS.Position = S
                    'Me.DanLOd()
                    Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
                    Insert_Actions(Me.TEXTID.Text, "حذف سجل من الشبكة", Me.Text)
                Else
                    MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                End If
            Else
                MessageBox.Show("لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

    'object reference not set to an instance of an object

    Private Sub SEARCHFIFOLIFOAvg()
        Try
            Using Consum As New SqlConnection(constring)
                Dim ds As New DataSet()
                Dim Adp1 As New SqlClient.SqlDataAdapter()
                Dim query As String = String.Empty

                ' Determine the query based on the selected method
                Select Case True
                    Case FIFO
                        query = "SELECT STK25, STK7, STK8, STK15, STK19, SKITM6, SKITM9, SKITM11, SKITM12, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, 
                             ChkPD, IT_DATEP, IT_DATEEX, LeftQty FROM FIFOStocks WHERE STK25 = @STK25"
                    Case LIFO
                        query = "SELECT STK25, STK7, STK8, STK15, STK19, SKITM6, SKITM9, SKITM11, SKITM12, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, 
                             ChkPD, IT_DATEP, IT_DATEEX, LeftQty FROM LIFOStock WHERE STK25 = @STK25"
                    Case AVG
                        query = "SELECT STK25, STK7, STK8, STK15, STK19, SKITM6, SKITM9, SKITM11, SKITM12, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, 
                             ChkPD, IT_DATEP, IT_DATEEX, LeftQty FROM AvgStocks WHERE STK25 = @STK25"
                End Select

                If Not String.IsNullOrEmpty(query) Then
                    ' Create the SQL command and add the necessary parameters
                    Using cmd As New SqlCommand(query, Consum)

                        If DataGridView1.Item("SITM4", DataGridView1.CurrentRow.Index) IsNot Nothing Then
                            cmd.Parameters.AddWithValue("@STK25", Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value)
                            Adp1 = New SqlDataAdapter(cmd)
                            ds.Clear()
                            Adp1.Fill(ds)
                        Else
                            MessageBox.Show("DataGridView1 item 'STK25' is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Return
                        End If
                    End Using
                End If
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    UpdateTextFields(ds.Tables(0).Rows(0))
                Else
                    FetchStockItems(Consum, Adp1, ds)
                End If
            End Using
            Me.TextTotalPurchasePrice.Text = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TextUnitPrice.Text) * (100 - Val(Me.TextDiscountBay.Text)) / 100, "0.000")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSEARCHFIFOLIFOAvg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateTextFields(ByVal row As DataRow)
        Try
            Dim Tax, Tax1 As Boolean
            Dim Tax2 As String
            If row IsNot Nothing Then
                Me.CodItem = row.Item("STK25").ToString()
                Me.num = row.Item("STK7").ToString()
                Tax2 = row.Item("STK7").ToString()
                Me.TextSTK8.Text = row("STK8").ToString()
                Me.TextUnitPrice.Text = row("STK15").ToString()
                Me.TexTSellingPrice.Text = row("STK19").ToString()
                Me.TextDiscountBay.Text = row("SKITM9").ToString()
                Me.TextHashUnit.Text = row("SKITM6").ToString()
                Me.TextOrderLimit.Text = row("SKITM11").ToString()
                Me.TextSalesTaxRate.Text = row("SKITM12").ToString()
                Me.TextDiscountPercentageWhenSelling.Text = row("SKITM15").ToString()
                Me.TextLowestDiscountRateWhenSelling.Text = row("SKITM16").ToString()
                Me.TextHighestDiscountRateWhenSelling.Text = row("SKITM17").ToString()
                Me.TextSecondSellingPrice.Text = row("SKITM18").ToString()
                Me.TextThirdSalePrice.Text = row("SKITM19").ToString()
                Me.TEXTProductionDate.Text = row("IT_DATEP").ToString()
                Me.TEXTExpiryDate.Text = row("IT_DATEEX").ToString()
                Me.TEXTCurrentBalance.Text = row("LeftQty").ToString()
                Boolean.TryParse(row("SKITM20").ToString(), Tax)
                Boolean.TryParse(row("SKITM21").ToString(), Tax1)
                Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax
                Me.CheckItemIsSubjectToSalesTax.Checked = Tax1
            Else
                MessageBox.Show("DataRow is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdateTextFields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FetchStockItems(ByVal Consum As SqlConnection, ByVal Adp1 As SqlDataAdapter, ByVal ds As DataSet)
        If Me.DataGridView2 IsNot Nothing AndAlso Me.DataGridView2.Rows.Count > 0 Then
            For i As Integer = 0 To Me.DataGridView2.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView2.Rows(i)
                If row.IsNewRow Then Continue For
                Dim query As String = "SELECT SKITM3, SKITM4, SKITM5, SKITM6, SKITM8, SKITM9, SKITM11, SKITM12, SKITM14, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, SKITM22, SKITM23, SKITM24, SKITM25, SKITM26, IT_DATEP, IT_DATEEX FROM STOCKSITEMS WHERE CUser = @CUser AND SKITM4 = @SKITM4"
                Using cmd As New SqlCommand(query, Consum)
                    If CUser IsNot Nothing Then cmd.Parameters.AddWithValue("@CUser", CUser)
                    If DataGridView2.Item("STK25", DataGridView2.CurrentRow.Index) IsNot Nothing Then
                        cmd.Parameters.AddWithValue("@SKITM4", Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value)
                        ds.Clear()
                        Adp1 = New SqlDataAdapter(cmd)
                        Adp1.Fill(ds)
                    Else
                        MessageBox.Show("DataGridView1 item 'STK25' is null.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return
                    End If
                End Using
                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    UpdateTextFields(ds.Tables(0).Rows(0))
                End If
            Next

            If Adp1 IsNot Nothing Then Adp1.Dispose()
            If Consum IsNot Nothing AndAlso Consum.State = ConnectionState.Open Then Consum.Close()
        Else
            Return
            'MessageBox.Show("DataGridView2 is null or has no rows.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Try
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

            If Me.CheckTransferAccounts.Checked = True Then
                MsgBox("لايمكن حذف السجلات المحددة لأنه مرحل ... ", 16, "تنبيه")
                Exit Sub
            End If

            If Me.DataGridView1.SelectedRows.Count > 0 Then
                Dim x As Integer = Me.DataGridView1.CurrentRow.Index
                Dim x1 As Int64 = Me.DataGridView1.Rows(x).Cells("SITM1").Value

                Using Consum As New SqlConnection(constring)
                    Using SQL2 As New SqlCommand("DELETE FROM SALESITEMS WHERE SITM1=@SITM1", Consum)
                        SQL2.Parameters.AddWithValue("@SITM1", x1)
                        Consum.Open()
                        SQL2.ExecuteNonQuery()
                    End Using
                End Using

                MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, Me.BS, True)

                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                Next
            Else
                MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
            End If

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            UpdateTotals()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه1")
        End Try

    End Sub

    Private Sub UpdateTotals()



        Double.TryParse(TEXTDiscountPercentage.EditValue?.ToString(), discountPercent)

        Dim discountValue As Double = TotalItems * (discountPercent / 100)
        Dim finalDiscount As Double = TotalDiscount + discountValue

        TEXTItemsTotal.Text = (TotalDiscount + TotalItems).ToString("0.000")
        TEXTDiscount.EditValue = finalDiscount.ToString("0.000")

        TEXTNetItems.Text = (Val(TEXTItemsTotal.Text) - Val(TEXTDiscount.EditValue))

        Dim taxRate As Double
        Double.TryParse(TEXTTaxRate.EditValue?.ToString(), taxRate)
        TEXTSalesTaxes.Text = (Val(TEXTItemsTotal.Text) * taxRate / 100).ToString("0.000")
        TextTotalItemsWithTaxes.Text = (Val(TEXTSalesTaxes.Text) + Val(TEXTNetItems.Text)).ToString("0.000")

        Me.TEXTTotal.Text = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) + Val(Me.TEXTDiscount.EditValue), "0.000")
        Me.TextDiscountBay.Text = Val(Me.TextTotalDiscount.Text)
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        'Me.SEARCHFIFOLIFOAvg()
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        Exit Sub
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next

        If Me.DataGridView1.SelectedRows.Count = 0 Then
            Dim valueSITM6 As Int32 = 0
            Dim valueSTK19 As Double
            Dim DiscountPercentageWhenSelling As Double
            If Me.txtq.Text IsNot Nothing Then
                valueSITM6 = Val(Me.txtq.Text)
            End If

            DiscountPercentageWhenSelling = (Val(Me.TexTSellingPrice.Text) * Val(Me.TextDiscountPercentageWhenSelling.Text) / 100).ToString("0.000")
            valueSTK19 = Val(valueSITM6) * Val(Me.TexTSellingPrice.Text)

            If Me.DataGridView1.Item("SITM2", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM2", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If Me.DataGridView1.Item("SITM3", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM3", e.RowIndex).Value = Me.num.ToString
            If Me.DataGridView1.Item("SITM4", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM4", e.RowIndex).Value = Val(Me.CodItem)
            If Me.DataGridView1.Item("SITM5", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM5", e.RowIndex).Value = Me.DataGridView2.Item("STK19", Me.DataGridView2.CurrentRow.Index).Value()
            If Me.DataGridView1.Item("SITM6", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM6", e.RowIndex).Value = Val(valueSITM6)
            If Me.DataGridView1.Item("SITM7", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM7", e.RowIndex).Value = Val(Me.TextDiscountPercentageWhenSelling.Text)
            If Me.DataGridView1.Item("SITM8", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM8", e.RowIndex).Value = Val(Me.TexTSellingPrice.Text) - Val(DiscountPercentageWhenSelling)
            If Me.DataGridView1.Item("SITM9", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM9", e.RowIndex).Value = Val(Me.TextUnitPrice.Text)
            If Me.DataGridView1.Item("SITM10", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM10", e.RowIndex).Value = Val(valueSTK19)
            If Me.DataGridView1.Item("SITM11", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM11", e.RowIndex).Value = Val(DiscountPercentageWhenSelling)
            If Me.DataGridView1.Item("SLS2", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SLS2", e.RowIndex).Value = TEXTInvoiceNumber.EditValue
                'Exit Sub

            End If
    End Sub

    Private Sub SaveStocks()
        Try
            Dim Consum As New SqlConnection(constring)
            'GetAutoIDSTK()
            IDSTK = GetAutoNumber("STK1", "STOCKS", "STK4")
            CodItemA = Convert.ToInt64(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value)
            ItemBalance = Convert.ToDouble(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value)
            PreviousBalance = SumBalanceItemsA(ComboStore.SelectedItem, CodItemA, IDSTK)

            'PreviousBalance = SumAmounTOTALSTOCKS(CodItem, IDSTK)
            CurrentBalance = SumAmounTOTALSTOCKS(CodItemA, IDSTK) - Convert.ToDouble(ItemBalance)
            UnitPriceA = Convert.ToDouble(Me.TextUnitPrice.Text) * Convert.ToDouble(CurrentBalance)
            SellingPrice = Convert.ToDouble(Me.DataGridView1.Item("SITM5", Me.DataGridView1.CurrentRow.Index).Value) * Convert.ToDouble(CurrentBalance)

            Dim SQL As String = "INSERT INTO STOCKS(STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName,  @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlCommand(SQL, Consum)
            CMD.Parameters.AddWithValue("@STK1", IDSTK)
            CMD.Parameters.AddWithValue("@WarehouseNumber", ComboStore.Text)
            CMD.Parameters.AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
            CMD.Parameters.AddWithValue("@STK3", Me.TEXTPermissionNumber.Text)
            CMD.Parameters.AddWithValue("@STK4", Me.DateMovementHistory.Value.ToString("yyyy-MM-dd"))
            CMD.Parameters.AddWithValue("@STK5", "صرف")
            CMD.Parameters.AddWithValue("@STK6", Me.TEXTInvoiceNumber.EditValue)
            CMD.Parameters.AddWithValue("@STK7", Me.DataGridView1.Item("SITM3", Me.DataGridView1.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK8", Me.TextSTK8.Text)
            CMD.Parameters.AddWithValue("@STK9", Me.TextHashUnit.Text)
            CMD.Parameters.AddWithValue("@STK10", PreviousBalance)
            CMD.Parameters.AddWithValue("@STK11", 0)
            CMD.Parameters.AddWithValue("@STK12", DataGridView1.Item("SITM6", DataGridView1.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK13", CurrentBalance)
            CMD.Parameters.AddWithValue("@STK14", Me.TextOrderLimit.Text)
            CMD.Parameters.AddWithValue("@STK15", Me.TextUnitPrice.Text)
            CMD.Parameters.AddWithValue("@STK16", Me.TextMovementSymbol.EditValue)
            CMD.Parameters.AddWithValue("@STK17", Me.TextDiscountBay.Text)
            CMD.Parameters.AddWithValue("@STK18", UnitPriceA)
            CMD.Parameters.AddWithValue("@STK19", Me.TexTSellingPrice.Text)
            CMD.Parameters.AddWithValue("@STK20", SellingPrice)
            CMD.Parameters.AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
            CMD.Parameters.AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
            CMD.Parameters.AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
            CMD.Parameters.AddWithValue("@STK25", Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
            CMD.Parameters.AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
            CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
            CMD.Parameters.AddWithValue("@CUser", CUser)
            CMD.Parameters.AddWithValue("@COUser", COUser)
            CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            CMD.Parameters.AddWithValue("@IT_DATEP", TEXTProductionDate.Text)
            CMD.Parameters.AddWithValue("@IT_DATEEX", Me.TEXTExpiryDate.Text)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdatStocks()
        Try
            Dim Consum As New SqlConnection(constring)
            'GetAutoIDSTK()

            If DataGridView1.Rows.Count > 0 Then
                IDSTK = GetAutoNumber("STK1", "STOCKS", "STK4")
                CodItemA = Convert.ToInt64(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value)
                ItemBalance = Convert.ToDouble(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value)
                PreviousBalance = SumBalanceItemsA(ComboStore.SelectedItem, CodItemA, IDSTK) + Convert.ToDouble(ItemBalance)
                CurrentBalance = SumAmounTOTALSTOCKS(CodItemA, IDSTK)
                UnitPriceA = Convert.ToDouble(Me.TextUnitPrice.Text) * Convert.ToDouble(CurrentBalance)
                SellingPrice = Convert.ToDouble(Me.DataGridView1.Item("SITM5", Me.DataGridView1.CurrentRow.Index).Value) * Convert.ToDouble(CurrentBalance)

                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    Dim SQL As New SqlCommand(" Update STOCKS SET WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK25 = @STK25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne  WHERE STK1 ='" & Me.TextSTK1A.Text & "'" & "AND STK25= '" & Me.DataGridView1.CurrentRow.Cells("SITM4").Value & "'", Consum)
                    Dim CMD As New SqlCommand(SQL.CommandText) With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = ComboStore.Text
                        .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                        .Parameters.Add("@STK7", SqlDbType.NVarChar).Value = Me.DataGridView1.Item("SITM3", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK8", SqlDbType.NVarChar).Value = Me.TextSTK8.Text
                        .Parameters.Add("@STK9", SqlDbType.NVarChar).Value = Me.TextHashUnit.Text
                        .Parameters.AddWithValue("@STK10", PreviousBalance)
                        .Parameters.AddWithValue("@STK11", 0)
                        .Parameters.AddWithValue("@STK12", DataGridView1.Item("SITM6", DataGridView1.CurrentRow.Index).Value)
                        .Parameters.AddWithValue("@STK13", CurrentBalance)
                        .Parameters.AddWithValue("@STK14", Me.TextOrderLimit.Text)
                        .Parameters.AddWithValue("@STK15", Me.TextUnitPrice.Text)
                        .Parameters.AddWithValue("@STK17", Me.TextDiscountBay.Text)
                        .Parameters.AddWithValue("@STK18", UnitPriceA)
                        .Parameters.AddWithValue("@STK19", Me.TexTSellingPrice.Text)
                        .Parameters.AddWithValue("@STK20", SellingPrice)
                        .Parameters.Add("@STK21", SqlDbType.Float).Value = Me.TextDiscountPercentageWhenSelling.Text
                        .Parameters.Add("@STK22", SqlDbType.Float).Value = Me.TextLowestDiscountRateWhenSelling.Text
                        .Parameters.Add("@STK23", SqlDbType.Float).Value = Me.TextHighestDiscountRateWhenSelling.Text
                        .Parameters.Add("@STK25", SqlDbType.Int).Value = Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                        .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                        .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                        .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdatStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TransforCustomerTraffic()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing
            nem = " تحميل فاتورة مبيعات على" & " " & Me.ComboCheckDrawerName.Text
            PMO2 = 1

            'DebitAccount_No = keyAccounts.GetValue("CustomerAccount_No", CustomerAccount_No)
            'GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            'DebitAccount_Name = ID_Nam
            'GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            'DebitAccount_Cod = ID_Nam

            ''DebitAccount_No = keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No)
            'GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount.Text, 1)
            'CredAccount_NO = ID_Nam

            'GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            'CredAccount_Name = ID_Nam
            'GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            'CredAccount_Cod = ID_Nam

            'AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked), TEXTTotal.Text, TEXTTotal.Text, T3, "قيد", "VE", TextMovementSymbol.EditValue, False)

            'DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_No, TextMovementSymbol.EditValue, TEXT1.Text, Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked), T2)
            'DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTTotal.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked), T2)

            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "نقدا", TEXTInvoiceNumber.EditValue,
                      "فاتورة مبيعات" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "نقدا", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod1.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBank.Text, TextBranch.Text, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, 0)
                Case "شيك"
                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "شيك", TEXTInvoiceNumber.EditValue,
                     "فاتورة مبيعات" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "أجـــــــل", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod1.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBank.Text, TextBranch.Text, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, 0)
                Case "نقدا_شيك"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "نقدا", TEXTInvoiceNumber.EditValue,
                      "فاتورة مبيعات" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "نقدا", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod1.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBank.Text, TextBranch.Text, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, 0)

                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "شيك", TEXTInvoiceNumber.EditValue,
                     "فاتورة مبيعات" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "أجـــــــل", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod1.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBank.Text, TextBranch.Text, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, 0)
            End Select


        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub OptionsTransforAccounts()
        If ComboDebitAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            Accounts_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
            CodAccount = ID_Nam
        End If

        If TextCreditAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount.Text, 1)
            CredAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCreditAccount.Text, 1)
            CredAccount_Cod = ID_Nam
        End If
        If TextSalesTaxCalculation.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextSalesTaxCalculation.Text, 1)
            PurchSalesCalculatingTax_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextSalesTaxCalculation.Text, 1)
            TaxAccount_Cod = ID_Nam
        End If
        If TextDiscountAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextDiscountAccount.Text, 1)
            PurchSalesDiscount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextDiscountAccount.Text, 1)
            DiscountAccount_Cod = ID_Nam
        End If

    End Sub

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                OptionsTransforAccounts()
                Me.PanelAccount.Enabled = True
            Else
                Check_OptionsTransforAccounts.Checked = False
                PanelAccount.Enabled = False
            End If
        Else
            PanelAccount.Enabled = False
        End If
    End Sub

    Private Sub TransforAccounts()
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(Me.TEXTDiscount.EditValue))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
        GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)

        SEARCHDATA.MaxIDMoves()
        TransferToAccounts_Check = True
        nem = "فاتورة مبيعات " & "_" & Me.TextMovementSymbol.EditValue
        nem1 = "فاتورة مبيعات نقدي" & "_" & Me.TextMovementSymbol.EditValue
        nem2 = " فاتورة مبيعات بيموجب مستند رقم" & "_" & Me.TextCheckNumber.Text
        nem3 = "خصم مسموح به لفاتورة مبيعات رقم" & "_" & Me.TEXTInvoiceNumber.EditValue
        nem4 = "حساب ضريبة المبيعات المستحقة "
        PMO2 = 1

        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam

        ChecksAccount_NO = keyAccounts.GetValue("IncomingCheckAAccount_No", IncomingCheckAAccount_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", ChecksAccount_NO, 1)
        ChecksAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", ChecksAccount_NO, 1)
        ChecksAccount_Cod = ID_Nam

        If Cash = True Then
            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قبض", "VE", TextMovementSymbol.EditValue, False)
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, Accounts_NO, TextFundValue.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    If Val(Me.TEXTDiscount.EditValue) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextDiscountAccount.Text, PurchSalesDiscount_No, TEXTDiscount.EditValue, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    Else
                        Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextSalesTaxCalculation.Text, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    End If
                    If OBCHK7 = False Then
                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                                                                                nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                                                False, True, ComboCB1.Text, CB2)
                    End If
                Case "شيك"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, ChecksAccount_NO, TextValueOfCheck.EditValue, 0, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    If Val(Me.TEXTDiscount.EditValue) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextDiscountAccount.Text, PurchSalesDiscount_No, TEXTDiscount.EditValue, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    Else
                        Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextSalesTaxCalculation.Text, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    End If
                    If OBCHK7 = False Then
                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
                                0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, True,
                                TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)
                    End If
                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, ModuleGeneral.CB2.ToString, Accounts_NO, TextFundValue.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ChecksAccount_Name, ChecksAccount_NO, TextValueOfCheck.EditValue, 0, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    If Val(Me.TEXTDiscount.EditValue) > 0 Then
                        DetailsAccountingEntries(PMO2 + 2, TextDiscountAccount.Text, PurchSalesDiscount_No, TEXTDiscount.EditValue, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    Else
                        Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 3, TextCreditAccount.Text, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 4, TextSalesTaxCalculation.Text, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    End If
                    If OBCHK7 = False Then
                        Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                                                                 nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                                 False, True, ComboCB1.Text, CB2)

                        Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
                  0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, True,
                  TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)
                    End If
            End Select
        Else
            nem = " تحميل فاتورة مبيعات على" & " " & "(" & Me.ComboCustomerName.Text & ")"
            nem1 = "فاتورة مبيعات أجـل" & "_" & Me.TextMovementSymbol.EditValue
            DebitAccount_No = keyAccounts.GetValue("CustomerAccount_No", CustomerAccount_No)
            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam
            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قبد", "VE", TextMovementSymbol.EditValue, False)
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextTotalItemsWithTaxes.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            If Val(Me.TEXTDiscount.EditValue) > 0 Then
                DetailsAccountingEntries(PMO2 + 1, TextDiscountAccount.Text, PurchSalesDiscount_No, TEXTDiscount.EditValue, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            Else
                Val(PMO2 - 1)
            End If
            DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                DetailsAccountingEntries(PMO2 + 3, TextSalesTaxCalculation.Text, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            End If
            MAXIDCAB1()
            Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextTotalItemsWithTaxes.Text, 0, "نقدا", TEXTInvoiceNumber.EditValue,
              "فاتورة مبيعات" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "أجـــــــل", TextMovementSymbol.EditValue, TextFundValue.EditValue,
              ComboPaymentMethod1.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextTotalItemsWithTaxes.Text, "jO"),
              TypeCustomer, TextBank.Text, TextBranch.Text, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
              TextCheckDrawerCode.Text, ComboCB1.Text, 0)
        End If



    End Sub

    Private Sub TransforAccountsSalesCost()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing

            DebitAccount_No = keyAccounts.GetValue("CalculatingCostGoodsSold_No", CalculatingCostGoodsSold_No) 'حساب تكلفه البضاعه المباعه
            CredAccount_NO = keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No) 'حساب مخزون البضاعة

            SEARCHDATA.MaxIDMoves()

            nem = " تحميل فاتورة مبيعات على مخزون البضاعة"

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TextTotaUnitPrice.Text, TextTotaUnitPrice.Text, T3, "قيد", "VEA", TextMovementSymbol.EditValue, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextTotaUnitPrice.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, True, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TextTotaUnitPrice.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, True, T2)

        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button3.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.ds.RejectChanges()
        Me.RecordCount()
    End Sub

    Private Sub TextBox14_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextTotalDiscount.TextChanged, TEXTSalesTaxes.TextChanged, TextTotalItemsWithTaxes.TextChanged, TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        AccountsEnquiry()
    End Sub

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod1.SelectedIndexChanged
        On Error Resume Next
        Me.AccountsEnquiry()
    End Sub

    Private Sub AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(Me.TEXTDiscount.EditValue))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
        GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)

        ChecksAccount_NO = keyAccounts.GetValue("IncomingCheckAAccount_No", IncomingCheckAAccount_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", ChecksAccount_NO, 1)
        ChecksAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", ChecksAccount_NO, 1)
        ChecksAccount_Cod = ID_Nam

        If Cash = True Then
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    Me.TextValueOfCheck.Enabled = False
                    Me.TextFundValue.Enabled = True
                    Me.RBCASHA.Enabled = True
                    Me.RBCheck.Enabled = False
                    Me.TextValueOfCheck.EditValue = 0
                    Me.TextFundValue.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                    ComboDebitAccount.Text = FundAccount_Name
                    NUpComboDebitAccount.Value = CodAccount
                    TextCreditAccount.Text = CredAccount_Name
                    NUpCreditAccount.Value = CredAccount_Cod
                Case "شيك"
                    Me.TextFundValue.Enabled = False
                    Me.TextValueOfCheck.Enabled = True
                    Me.TextBank.Enabled = True
                    Me.TextBranch.Enabled = True
                    Me.RBCASHA.Enabled = False
                    Me.RBCheck.Enabled = True
                    Me.TextFundValue.EditValue = 0
                    Me.TextValueOfCheck.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")
                    ComboDebitAccount.Text = ChecksAccount_Name
                    NUpComboDebitAccount.Value = ChecksAccount_Cod
                    TextCreditAccount.Text = CredAccount_Name
                    NUpCreditAccount.Value = CredAccount_Cod
                Case "نقدا_شيك"
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.Enabled = True
                    Me.TextBank.Enabled = True
                    Me.TextBranch.Enabled = True
                    Me.RBCASHA.Enabled = True
                    Me.RBCheck.Enabled = True
                    If Me.RBCASHA.Checked = True Then
                        ValueOfCheck = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) - Val(Me.TextFundValue.EditValue), "0.000")
                        Me.TextValueOfCheck.EditValue = Val(ValueOfCheck).ToString("0.000")
                        FundValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                        Me.TextFundValue.EditValue = Val(FundValue).ToString("0.000")
                    ElseIf Me.RBCheck.Checked = True Then
                        FundValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                        Me.TextFundValue.EditValue = Val(FundValue).ToString("0.000")
                        ValueOfCheck = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) - Val(Me.TextFundValue.EditValue), "0.000")
                        Me.TextValueOfCheck.EditValue = Val(ValueOfCheck).ToString("0.000")
                    End If
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                    ComboDebitAccount.Text = ChecksAccount_Name
                    NUpComboDebitAccount.Value = ChecksAccount_Cod
                    TextCreditAccount.Text = CredAccount_Name
                    NUpCreditAccount.Value = CredAccount_Cod
            End Select
        Else
            Me.GroupCHKS.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.ComboPaymentMethod1.Text = "العملاء مدينين"
            Me.ComboPaymentMethod1.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.TextFundValue.Enabled = True
            Me.RBCASHA.Enabled = True
            Me.RBCheck.Enabled = False
            Me.TextValueOfCheck.EditValue = 0
            Me.TextFundValue.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")
            LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            ComboDebitAccount.Text = DebitAccount_Name
            NUpComboDebitAccount.Value = DebitAccount_Cod
            TextCreditAccount.Text = CredAccount_Name
            NUpCreditAccount.Value = CredAccount_Cod
        End If

        If Val(Me.TEXTDiscount.EditValue) > 0 Then
            TextDiscountAccount.Text = DiscountAccountAE_Name
            NUpDiscountAccount.Value = DiscountAccount_Cod
            NUpDiscountAccount.Enabled = True
            PicDiscountAccount.Enabled = True
        Else
            TextDiscountAccount.Text = Nothing
            NUpDiscountAccount.Enabled = False
            PicDiscountAccount.Enabled = False
        End If

        If Val(Me.TEXTSalesTaxes.Text) > 0 Then
            TextSalesTaxCalculation.Text = CalculatingTaxAccount_Name
            NUpSalesTaxCalculation.Value = TaxAccount_Cod
            NUpSalesTaxCalculation.Enabled = True
            PicSalesTaxCalculation.Enabled = True
        Else
            TextSalesTaxCalculation.Text = Nothing
            NUpSalesTaxCalculation.Enabled = False
            PicSalesTaxCalculation.Enabled = False
        End If

    End Sub

    Private Sub TEXT4_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTItemsTotal.TextChanged, TEXTDiscountPercentage.EditValueChanged, TEXTTaxRate.EditValueChanged, TEXTDiscount.EditValueChanged, TEXTNetItems.TextChanged, TEXTSalesTaxes.TextChanged, TextTotalItemsWithTaxes.TextChanged, TextSITM11.TextChanged, TextValueOfCheck.EditValueChanged, TextFundValue.EditValueChanged
        UpdateTotals()
    End Sub

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
            Me.TextCheckDrawerCode.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                    Me.TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    Me.TypeCustomer = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RadioSUPPLIER.Checked = True Then
                Dim Adp1 As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlDataAdapter(strsql)
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
                Dim Adp2 As SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlDataAdapter(strsq2)
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

    Private Function GetGrdQuantities() As Double
        Dim total As Double = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(row) If(row.Cells("SITM4").Value = CodItem, Val(row.Cells("SITM6").Value), 0))
        TextTot.Text = total.ToString()
        Return total
    End Function

    Private Sub TxtItem_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtItem2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtq.Focus()

            Me.txtq.Text = 1
            Me.txtq.SelectAll()
        End If
    End Sub

    Private Sub TxtItem_TextChanged(sender As Object, e As EventArgs) Handles txtItem2.TextChanged
        SearchTimer.Stop()
        SearchTimer.Start()
    End Sub

    Private Sub SearchTimer_Tick(sender As Object, e As EventArgs)
        SearchTimer.Stop()
        PerformItemSearch(txtItem2.Text)
    End Sub

    Private Sub PerformItemSearch(searchText As String)
        Try
            If String.IsNullOrWhiteSpace(searchText) Then Exit Sub

            Using conn As New SqlConnection(constring)
                Dim query As String = If(FIFO, "SELECT STK25, STK7, STK8, STK15, STK19, SKITM6, SKITM9, SKITM11, SKITM12, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, 
                             ChkPD, IT_DATEP, IT_DATEEX, LeftQty FROM FIFOStocks WHERE CUser = @CUser AND WarehouseNumber = @WarehouseNumber AND STK25 LIKE @SearchText",
                                        If(LIFO, "SELECT STK25, STK7, STK8, STK15, STK19, SKITM6, SKITM9, SKITM11, SKITM12, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, 
                             ChkPD, IT_DATEP, IT_DATEEX, LeftQty FROM LIFOStock WHERE CUser = @CUser AND WarehouseNumber = @WarehouseNumber AND STK25 LIKE @SearchText",
                                        "SELECT STK25, STK7, STK8, STK15, STK19, SKITM6, SKITM9, SKITM11, SKITM12, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, 
                             ChkPD, IT_DATEP, IT_DATEEX, LeftQty FROM AvgStocks WHERE CUser = @CUser AND WarehouseNumber = @WarehouseNumber AND STK25 LIKE @SearchText"))
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@CUser", CUser)
                    cmd.Parameters.AddWithValue("@WarehouseNumber", ComboStore.Text.Trim())
                    cmd.Parameters.AddWithValue("@SearchText", $"%{searchText}%") ' Optimized for index usage

                    conn.Open()
                    Using adapter As New SqlDataAdapter(cmd)
                        Dim dsLocal As New DataSet
                        adapter.Fill(dsLocal)
                        If dsLocal.Tables(0).Rows.Count > 0 Then
                            DataGridView2.DataSource = dsLocal
                            DataGridView2.DataMember = dsLocal.Tables(0).TableName
                            Dim row = dsLocal.Tables(0).Rows(0)
                            CodItem = Integer.Parse(row("STK25").ToString())
                            num = row("STK7").ToString()
                            Tax2 = row.Item("STK7").ToString()
                            Me.TextSTK8.Text = row("STK8").ToString()
                            Me.TextUnitPrice.Text = row("STK15").ToString()
                            Me.TexTSellingPrice.Text = row("STK19").ToString()
                            Me.TextDiscountBay.Text = row("SKITM9").ToString()
                            Me.TextHashUnit.Text = row("SKITM6").ToString()
                            Me.TextOrderLimit.Text = row("SKITM11").ToString()
                            Me.TextSalesTaxRate.Text = row("SKITM12").ToString()
                            Me.TextDiscountPercentageWhenSelling.Text = row("SKITM15").ToString()
                            Me.TextLowestDiscountRateWhenSelling.Text = row("SKITM16").ToString()
                            Me.TextHighestDiscountRateWhenSelling.Text = row("SKITM17").ToString()
                            Me.TextSecondSellingPrice.Text = row("SKITM18").ToString()
                            Me.TextThirdSalePrice.Text = row("SKITM19").ToString()
                            Me.TEXTProductionDate.Text = row("IT_DATEP").ToString()
                            Me.TEXTExpiryDate.Text = row("IT_DATEEX").ToString()
                            Me.TEXTCurrentBalance.Text = row("LeftQty").ToString()
                            Me.CheckPricesMentionedIncludeSalesTax.Checked = row("SKITM20").ToString()
                            Me.CheckItemIsSubjectToSalesTax.Checked = row("SKITM21").ToString()
                            Me.TextBcod.Text = Me.CodItem
                            Call Dgv2()

                        Else
                            ClearFields()
                            MessageBox.Show("لا يوجد بيانات لعرضها", "عرض البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Search error: {ex.Message}", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearFields()
        CodItem = 0
        num = ""
        TextHashUnit.Text = "0"
        TextDiscountBay.Text = "0"
        TextOrderLimit.Text = "0"
        TextSalesTaxRate.Text = "0"
        TexTSellingPrice.Text = "0"
        TextSecondSellingPrice.Text = "0"
        TextDiscountPercentageWhenSelling.Text = "0"
        TextHighestDiscountRateWhenSelling.Text = "0"
        CheckPricesMentionedIncludeSalesTax.Checked = False
        CheckItemIsSubjectToSalesTax.Checked = False
    End Sub


    Private Sub Txtq_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtq.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Try
                Dim qty As Double
                If Not Double.TryParse(txtq.Text, qty) OrElse qty <= 0 Then
                    MsgBox("كم عدد السلعة", MsgBoxStyle.Critical, "تنبيه")
                    Exit Sub
                End If

                Dim totalRequested = GetGrdQuantities() + qty
                Dim balance As Double
                Double.TryParse(Me.TEXTCurrentBalance.Text, balance)
                'lblNETINVOICE.Text = totalRequested
                'lblSALESTAX.Text = balance
                If totalRequested > balance Then
                    MsgBox("عفواً هذه الكميات أكبر من رصيد الصنف", MsgBoxStyle.Exclamation, "تنبيه")
                    txtItem2.Clear()
                    txtItem2.Focus()
                    Exit Sub
                End If

                Dgv1()
                TextBcod.Text = ""
                txtItem2.Text = ""
                txtItem2.Focus()
                GetGrdQuantities()
            Catch ex As Exception
                MessageBox.Show($"Quantity error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Txtq_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtq.TextChanged
        On Error Resume Next
        Me.GetGrdQuantities()
    End Sub

    Private Sub Dgv1()
        Try
            DataGridView1.AllowUserToAddRows = True
            Dim SellingPrice As Double = 0.0
            Dim TxtQolcete As Integer = 0
            Dim DiscountPercentageWhenSelling As Double = 0.0
            Dim Price As Double = 0.0
            Dim CurrentBalanceSelling As Double = 0.0
            Dim SumCurrentBalanceSelling As Double = 0.0
            Dim SumBalanceSelling As Double = 0.0
            Dim SellingPriceA As Double = 0.0
            Dim cx As Integer = 1
            Dim value As Object
            ' Handle DBNull values
            If Me.DataGridView1.CurrentRow IsNot Nothing Then
                value = DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value
                cx = If(IsDBNull(value), 0, Convert.ToInt32(value))
            End If

            If Me.DataGridView2.CurrentRow IsNot Nothing Then
                value = DataGridView2.Item("SKITM15", Me.DataGridView2.CurrentRow.Index).Value
                Price = If(IsDBNull(value), 0.0, Convert.ToDouble(value))

                value = DataGridView2.Item("STK19", Me.DataGridView2.CurrentRow.Index).Value
                SellingPrice = If(IsDBNull(value), 0.0, cx * Convert.ToDouble(value))
            End If

            If Me.txtq IsNot Nothing AndAlso Not String.IsNullOrEmpty(Me.txtq.Text) Then
                TxtQolcete = Val(Me.txtq.Text)
            End If

            If Me.TextItemBalanceAfterSaleA IsNot Nothing AndAlso Me.TextItemBalanceAfterSale IsNot Nothing Then
                CurrentBalanceSelling = Format(Val(SellingPrice) * Val(cx) - Val(Me.TextItemBalanceAfterSaleA.Text) + Val(Me.TextItemBalanceAfterSale.Text) * (100 - Val(DiscountPercentageWhenSelling)) / 100, "0.000")
            End If

            If Me.TextDiscountPercentageWhenSelling IsNot Nothing AndAlso Me.TextUnitPrice IsNot Nothing Then
                DiscountPercentageWhenSelling = (Val(SellingPrice) * Val(Me.TextDiscountPercentageWhenSelling.Text) / 100).ToString("0.000")
                SellingPriceA = Val(SellingPrice) - Val(DiscountPercentageWhenSelling)
            End If

            SumBalanceSelling = Format(Val(CurrentBalanceSelling) * Val(Price) / 100, "0.000")
            SumCurrentBalanceSelling = Format(Val(CurrentBalanceSelling) - Val(SumBalanceSelling), "0.000")

            Dim test As Integer = If(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Any(Function(r) Not IsDBNull(r.Cells("SITM4").Value) AndAlso r.Cells("SITM4").Value = CodItem), 0, 1)
            Dim test2 As Integer = If(Me.DataGridView2.Rows.Cast(Of DataGridViewRow).Any(Function(r) Not IsDBNull(r.Cells(0).Value) AndAlso r.Cells(0).Value = CodItem), 0, 1)

            ' Ensure DataSet is initialized
            If ds Is Nothing Then
                ds = New DataSet()
            End If
            ' Ensure DataTable is initialized and added to the DataSet
            If Not ds.Tables.Contains("REL1") Then
                Dim rel1Table As New DataTable("REL1")
                rel1Table.Columns.Add("SITM1", GetType(Integer))
                rel1Table.Columns.Add("SITM2", GetType(Integer))
                rel1Table.Columns.Add("SITM3", GetType(String))
                rel1Table.Columns.Add("SITM4", GetType(String))
                rel1Table.Columns.Add("SITM5", GetType(String))
                rel1Table.Columns.Add("SITM6", GetType(String))
                rel1Table.Columns.Add("SITM7", GetType(String))
                rel1Table.Columns.Add("SITM8", GetType(Double))
                rel1Table.Columns.Add("SITM9", GetType(Double))
                rel1Table.Columns.Add("SITM10", GetType(Double))
                rel1Table.Columns.Add("SITM11", GetType(Double))
                rel1Table.Columns.Add("SLS2", GetType(Int64))
                ds.Tables.Add(rel1Table)
            End If

            ' Add new row to the DataTable
            If test2 = 0 Then
                If test = 0 Then
                    cx = Val(TxtQolcete) + If(IsDBNull(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value), 0, Val(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value))
                    SellingPrice = Val(DataGridView2.Item("STK19", Me.DataGridView2.CurrentRow.Index).Value) * Val(cx) - Val(DiscountPercentageWhenSelling)
                    For Each row As DataGridViewRow In Me.DataGridView1.Rows
                        If Not IsDBNull(row.Cells("SITM4").Value) AndAlso row.Cells("SITM4").Value = CodItem Then
                            row.Cells("SITM6").Value = Val(cx)
                            row.Cells("SITM8").Value = Val(SellingPrice)
                            row.Cells("SITM10").Value = Val(cx) * Val(TextUnitPrice.Text)
                            row.Cells("SITM11").Value = Val(cx) * Val(DiscountPercentageWhenSelling)
                        End If
                    Next
                Else
                    Me.DataGridView1.AutoGenerateColumns = False
                    Try
                        If DataGridView1.NewRowIndex >= 0 AndAlso DataGridView1.NewRowIndex < DataGridView1.Rows.Count Then
                            Me.DataGridView1.CurrentCell = DataGridView1("SITM2", DataGridView1.NewRowIndex)
                        End If
                    Catch ex As Exception
                        MessageBox.Show($"Error setting current cell: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try

                    Me.DataGridView1.MultiSelect = True
                    'Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                    'Me.DataGridView1.Sort(Me.DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Descending)
                    Me.DataGridView1.Sort(Me.DataGridView1.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
                    Dim newRow As DataRow = ds.Tables("REL1").NewRow()


                    newRow("SITM2") = Me.DataGridView1.CurrentRow.Index + 1
                    newRow("SITM3") = Convert.ToString(num)
                    newRow("SITM4") = Convert.ToString(CodItem)
                    newRow("SITM5") = If(IsDBNull(Me.DataGridView2.Item("STK19", Me.DataGridView2.CurrentRow.Index).Value), 0, Val(Me.DataGridView2.Item("STK19", Me.DataGridView2.CurrentRow.Index).Value))
                    newRow("SITM6") = Convert.ToInt32(TxtQolcete)
                    newRow("SITM7") = Convert.ToDouble(Me.TextDiscountPercentageWhenSelling.Text)
                    newRow("SITM8") = Val(SellingPriceA)
                    newRow("SITM9") = Convert.ToDouble(Me.TextUnitPrice.Text)
                    newRow("SITM10") = Convert.ToInt32(TxtQolcete) * Convert.ToDouble(TextUnitPrice.Text)
                    newRow("SITM11") = Val(DiscountPercentageWhenSelling)
                    newRow("SLS2") = TEXTInvoiceNumber.EditValue
                    If newRow.Table.Rows.Count > 0 Then
                        ds.Tables("REL1").Rows.Add(newRow)
                    End If
                    BS.RaiseListChangedEvents = True
                    BS.ResetBindings(False)
                    'ItemRow = True
                End If
                Dim Sound As IO.Stream = My.Resources.BarCode
                My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            Else
                MsgBox("هذا الصنف غير موجود", MsgBoxStyle.Information, "تنبيه")
                Exit Sub
            End If

            TotalDiscount = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(r) If(IsDBNull(r.Cells("SITM11").Value), 0, Val(r.Cells("SITM11").Value)))
            TotalItems = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(r) If(IsDBNull(r.Cells("SITM8").Value), 0, Val(r.Cells("SITM8").Value)))
            UpdateTotals()
            DataGridView1.Refresh()
        Catch ex As Exception
            MessageBox.Show($"Grid update error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Dgv2()
        On Error Resume Next
        Me.DataGridView2.Columns(0).Visible = True
        Me.DataGridView2.Columns(1).Visible = True
        Me.DataGridView2.Columns("STK8").Visible = False
        Me.DataGridView2.Columns("STK15").Visible = False
        Me.DataGridView2.Columns("STK19").Visible = True
        Me.DataGridView2.Columns("SKITM6").Visible = False
        Me.DataGridView2.Columns("SKITM9").Visible = False
        Me.DataGridView2.Columns("SKITM11").Visible = False
        Me.DataGridView2.Columns("SKITM12").Visible = False
        Me.DataGridView2.Columns("SKITM15").Visible = False
        Me.DataGridView2.Columns("SKITM16").Visible = False
        Me.DataGridView2.Columns("SKITM17").Visible = False
        Me.DataGridView2.Columns("SKITM18").Visible = False
        Me.DataGridView2.Columns("SKITM19").Visible = False
        Me.DataGridView2.Columns("SKITM20").Visible = False
        Me.DataGridView2.Columns("SKITM21").Visible = False
        Me.DataGridView2.Columns("ChkPD").Visible = False
        Me.DataGridView2.Columns("IT_DATEP").Visible = False
        Me.DataGridView2.Columns("IT_DATEEX").Visible = False
        Me.DataGridView2.Columns("LeftQty").Visible = True
        Me.DataGridView2.Columns(0).Width = 100
        Me.DataGridView2.Columns(1).Width = 225
        Me.DataGridView2.Columns("LeftQty").Width = 60
        Me.DataGridView2.Columns("STK19").Width = 60
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Me.DataGridView2.Columns(0).HeaderText = "كود الصنف"
        Me.DataGridView2.Columns(1).HeaderText = "أسم الصنف"
        Me.DataGridView2.Columns("LeftQty").HeaderText = "الرصيد"
        Me.DataGridView2.Columns("STK19").HeaderText = "السعر"
        ''''
        Me.DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView2.MultiSelect = False
        With Me.DataGridView2
            .RowsDefaultCellStyle.BackColor = Color.Beige
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        End With
        ''''''''''''''''''''
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Me.DataGridView1.CurrentRow.Cells("SITM3").Value = Me.num.ToString
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
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1.Fill(ds, "MOVES")
            f.BS.DataMember = "MOVES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("MOV2", Me.TextMovementRestrictions.Text)
            f.TB2 = Me.TextMovementRestrictions.Text
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()

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
            index = f.BS.Find("MOV2", Me.TextMovementRestrictions1.Text)
            f.TB2 = Me.TextMovementRestrictions1.Text
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()

    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions2.Click
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
            index = f.BS.Find("MOV2", Me.TextMovementRestrictions2.Text)
            f.TB2 = Me.TextCreditAccount.Text
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()

    End Sub

    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.TextCheckMovementNumber.Text)
            f.TB1 = Me.TextCheckMovementNumber.Text
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

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CASHIER")
            f.BS.DataMember = "CASHIER"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("CSH1", Me.TextFundMovementNumber.Text)
            f.TB1 = Me.TextFundMovementNumber.Text
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

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber.Text)
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

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber1.Text)
            f.TB1 = Trim(Me.TextCustomerTrafficNumber1.Text)
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

    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextDiscountAccount.Text}))
            End If
            If Me.ComboPaymentMethod1.Text = "نقدا_شيك" Then
                Connection.ACONET1.Add("الصندوق")
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCheckMovementNumber.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCheckMovementNumber.Text}))
            End If
            If Val(Me.TextTotalDiscount.Text) > 0 Then
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextSalesTaxCalculation.Text}))
            End If
            AccountingprocedureAA()
            For XX1 As Integer = 0 To Connection.ACONET2.Count - 1
                Me.ACONETA.AppendText(Connection.ACONET2(XX1) & vbCrLf)
            Next
            MsgBox(Me.ACONETA.Text)
            Connection.ACONET3 = Me.ACONETA.Text
            UPDATE_Auditorsnotes()

        End If
    End Sub

    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click

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
            If Val(Me.TextTotalDiscount.Text) > 0 Then
                If Me.TextDiscountAccount.Text = "" Then
                    MsgBox("عفوا .. لا يمكن ترك حقل حساب خصم مسموح به", 16, "تنبيه")
                    Me.List2.Visible = True
                    Exit Sub
                End If
            End If
            If Me.TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                If Me.TextSalesTaxCalculation.Text = "" Then
                    MsgBox("عفوا .. لا يمكن ترك حقل  حساب ضريبة المبيعات", 16, "تنبيه")
                    Me.List3.Visible = True
                    Exit Sub
                End If
            End If
            Dim ch As Double = Val(Me.TextTotalItemsWithTaxes.Text)
            Dim ch11 As Double = Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue)
            If Val(ch).ToString("0.000") <> Val(ch11).ToString("0.000") Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If

            If CheckTransferAccounts1.Checked = True Then
                MessageBox.Show("تنبيه. قيد تكلفة المبيعات و مخزون البضاعة مرحل" & ControlChars.CrLf &
                            "1) الغاء ترحيل قيد تكلفة المبيعات و مخزون البضاعة" & ControlChars.CrLf &
                            "2) قم بترحـيـل الحســـابات", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonTransferofAccounts.Enabled = False
                Exit Sub
            End If
            GetDiscount_B(Val(Me.TEXTDiscount.EditValue))
            GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
            GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOptions.ShowDialog()
                Exit Sub
            End If
            Me.ComboBox1_SelectedIndexChanged(sender, e)
            Dim N As Double
            Dim Consum As New SqlConnection(constring)
            Dim cmd1 As New SqlCommand("SELECT MAX(IDCAB) FROM CABLES", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(cmd1)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()

            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If

            Dim strsql2 As New SqlCommand("SELECT DISTINCT IDCAB FROM CABLES WHERE CUser = '" & CUser & " '", Consum)
            Dim ds2 As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsql2)
            ds2.Clear()
            Adp1.Fill(ds2, "CABLES")
            'If ds2.Tables(0).Rows.Count > 0 Then
            '    If Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, N)), "0.000") > 0 Then
            '        MsgBox("عفوا لا يمكن..  تم  تسوية حركة العميل", 16, "تنبيه")
            '        Me.ButtonTransferofAccounts.Enabled = False
            '        Exit Sub
            '    End If
            'End If
            Consum.Close()
            Me.Button5_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
            SEARCHDATA.SEARCHMOVESTrueDELETAVE(Me.TextMovementSymbol.EditValue)
            Me.MOVDELETVE.Text = SEARCHDATA.MOVDELETVE

            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            SEARCHDATA.SEARCHMOVESTrueDELETA(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELETA.Text = SEARCHDATA.MOVADELET
            PurchSales_Check = True
            CalculatingTax_B = Format(Val(Me.TEXTSalesTaxes.Text), "0.000")
            Dim resault As Integer
            Static Dim P As Integer
            If OBCHK7 = True Then
                If Me.CheckTransferAccounts.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts.Checked = True
                        TransforAccounts()
                        Insert_Actions(Me.TEXTID.Text, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                        TransforAccounts()
                        Me.AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferAccounts.Checked = False
                            Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Cash = True Then
                    If Me.ComboPaymentMethod1.Text = "نقدا" Then
                        If Me.CheckTransferAccounts.Checked = False Then
                            resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.CheckTransferAccounts.Checked = True
                                TransforAccounts()
                                Insert_Actions(Me.TEXTID.Text, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                    Me.DELETECASHIER()
                                End If
                                If Me.TextCheckMovementNumber.Text = "" Then
                                    MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                                Else
                                    Me.DELETEChecks()
                                End If
                                TransforAccounts()
                                Me.AccountingprocedureA()
                                Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                                If resault = vbYes Then
                                    Me.DELETEDATMOVESDATA()
                                    Me.DELETEDATMOVESDATA1()
                                    Me.DELETECASHIER()
                                    Me.CheckTransferAccounts.Checked = False
                                    Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                                Else
                                    Exit Sub
                                End If
                            End If
                        End If
                        '======================================================================================================
                    ElseIf Me.ComboPaymentMethod1.Text = "شيك" Then
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
                        If Me.CheckTransferAccounts.Checked = False Then
                            resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.CheckTransferAccounts.Checked = True
                                TransforAccounts()
                                Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  الى القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                    Me.DELETECASHIER()
                                End If
                                If Me.TextCheckMovementNumber.Text = "" Then
                                    MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                                Else
                                    Me.DELETEChecks()
                                End If
                                TransforAccounts()
                                Me.AccountingprocedureA()
                                Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                                If resault = vbYes Then
                                    Me.DELETEChecks()
                                    Me.DELETEDATMOVESDATA()
                                    Me.DELETEDATMOVESDATA1()
                                    Me.CheckTransferAccounts.Checked = False
                                    Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة القيود اليومية و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                                Else
                                    Exit Sub
                                End If
                            End If
                        End If
                        '=============================================================================================================
                    ElseIf Me.ComboPaymentMethod1.Text = "نقدا_شيك" Then
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
                        If Me.CheckTransferAccounts.Checked = False Then
                            resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.CheckTransferAccounts.Checked = True
                                TransforAccounts()
                                Insert_Actions(Me.TEXTID.Text, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                    Me.DELETECASHIER()
                                End If
                                If Me.TextCheckMovementNumber.Text = "" Then
                                    MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                                Else
                                    Me.DELETEChecks()
                                End If
                                TransforAccounts()
                                Me.AccountingprocedureA()
                                Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                                If resault = vbYes Then
                                    Me.DELETECASHIER()
                                    Me.DELETEChecks()
                                    Me.DELETEDATMOVESDATA()
                                    Me.DELETEDATMOVESDATA1()
                                    Me.CheckTransferAccounts.Checked = False
                                    Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة الصندزق و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                                Else
                                    Exit Sub
                                End If
                            End If
                        End If
                    End If
                Else
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و العملاء رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            Me.CheckPostToCustomerTraffic.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTID.Text, "ترحيل الى القيود اليومية و العملاء رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                            If Me.TextCustomerTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في مركز العملاء نقدا", 16, "تنبية") '4
                            Else
                                Me.DELETEDATA()
                            End If
                            TransforAccounts()
                            Me.AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  الى القيود اليومية و العملاء رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول العملاء ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATA()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferAccounts.Checked = False
                                Me.CheckPostToCustomerTraffic.Checked = False
                                Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة العملاء رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If


                End If
            End If
            P = Me.BS.Position
            Me.UPDATESALES()
            Me.SaveSALESITEMS()
            Me.UPDATESALESITEMS()
            Me.DanLOd()
            Me.BS.Position = P
            Me.UPDATESALES() '  راس الفاتورة
            Me.UPDATESALESITEMS() ' البنود
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETECABLES()
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETECABLES1()
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber1, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCreditAccount.Click
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicDiscountAccount.Click
        LS2 = True
        Me.PanelAccount_Name.Visible = True
        Me.List2.Visible = True
    End Sub
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicSalesTaxCalculation.Click
        LS3 = True
        Me.PanelAccount_Name.Visible = True
        Me.List3.Visible = True
    End Sub
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List1.MouseDoubleClick
        Me.TextCreditAccount.Text = List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
    Private Sub List2_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List2.MouseDoubleClick
        Me.TextDiscountAccount.Text = List2.SelectedItem(0).ToString
        LS2 = False
        Me.PanelAccount_Name.Visible = False
        Me.List2.Visible = False
    End Sub
    Private Sub List3_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List3.MouseDoubleClick
        Me.TextSalesTaxCalculation.Text = List3.SelectedItem(0).ToString
        LS3 = False
        Me.PanelAccount_Name.Visible = False
        Me.List3.Visible = False
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDiscountAccount.ValueChanged
        Me.List2.DataSource = GetData(NUpDiscountAccount.Value)
        Me.List2.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpSalesTaxCalculation.ValueChanged
        Me.List3.DataSource = GetData(NUpSalesTaxCalculation.Value)
        Me.List3.DisplayMember = "account_name"
    End Sub
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpCreditAccount.Value)
            Me.List1.DisplayMember = "account_name"
        ElseIf LS2 = True Then
            Me.List2.DataSource = GetData(NUpDiscountAccount.Value)
            Me.List2.DisplayMember = "account_name"
        ElseIf LS3 = True Then
            Me.List3.DataSource = GetData(NUpSalesTaxCalculation.Value)
            Me.List3.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub

    Private Sub ButtonPostToCustomerTraffic_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPostToCustomerTraffic.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If CheckPostToCustomerTraffic.Checked = True Then
                MessageBox.Show("تنبيه. قيد حركة العملاء  مرحل" & ControlChars.CrLf &
                            "1) الغاء ترحيل  الى حركة العملاء" & ControlChars.CrLf &
                            "2) قم بترحيل الى الحســـــــابات ", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonTransferofAccounts.Enabled = False
                Exit Sub
            End If
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

            Me.Button5_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
            SEARCHDATA.SEARCHMOVESTrueDELETAVE(Me.TextMovementSymbol.EditValue)
            Me.MOVDELETVE.Text = SEARCHDATA.MOVDELETVE

            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            SEARCHDATA.SEARCHMOVESTrueDELETA(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELETA.Text = SEARCHDATA.MOVADELET
            PurchSales_Check = True
            CalculatingTax_B = Format(Val(Me.TEXTSalesTaxes.Text), "0.000")
            Dim nem As String = "تحميل " & " " & Me.ComboDebitAccount.Text & " " & "على العميل" & " " & Me.ComboCustomerName.Text

            Static P As Integer
            If Me.ComboPaymentMethod1.Text = "نقدا" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى العملاء رفم " & Me.TextItemBalanceAfterSaleA.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.Text, "ترحيل الى العملاء رفم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTCurrentBalance.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في مركز العملاء نقدا", 16, "تنبية") '4
                        Else
                            Me.DELETEDATA()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في مركز العملاء جاري", 16, "تنبية") '5
                        Else
                            Me.DELETEDATA1()
                        End If
                        TransforCustomerTraffic()
                        Me.AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  العملاء رفم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول العملاء ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة العملاء رقم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                '======================================================================================================
            ElseIf Me.ComboPaymentMethod1.Text = "شيك" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى العملاء رفم " & Me.TextItemBalanceAfterSaleA.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  العملاء رفم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTCurrentBalance.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في مركز العملاء نقدا", 16, "تنبية") '4
                        Else
                            Me.DELETEDATA()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في مركز العملاء جاري", 16, "تنبية") '5
                        Else
                            Me.DELETEDATA1()
                        End If
                        TransforCustomerTraffic()
                        Me.AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  حركة العملاء رفم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول العملاء  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة العملاء رقم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                '=============================================================================================================
            Else
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى حركة العملاء رفم " & Me.TextItemBalanceAfterSaleA.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.Text, "ترحيل الى حركةالعملاء رفم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTCurrentBalance.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في مركز العملاء نقدا", 16, "تنبية") '4
                        Else
                            Me.DELETEDATA()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("لايوجد سجلات في مركز العملاء جاري", 16, "تنبية") '5
                        Else
                            Me.DELETEDATA1()
                        End If
                        TransforCustomerTraffic()
                        Me.AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  العملاء رفم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول العملاء ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة العملاء رقم" & " " & Me.TextItemBalanceAfterSaleA.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If
            P = Me.BS.Position
            Me.UPDATESALES()
            Me.SaveSALESITEMS()
            Me.UPDATESALESITEMS()
            Me.DanLOd()
            Me.BS.Position = P
            Me.UPDATESALES() '  راس الفاتورة
            Me.UPDATESALESITEMS() ' البنود
            Me.RecordCount()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch1.CheckedChanged
        If Me.Ch1.Checked = True Then
            Me.DataGridView1.Focus()
            Me.Timsum.Start()
        ElseIf Me.Ch1.Checked = False Then
            Me.txtq.Focus()
            Me.Timsum.Stop()
        End If
    End Sub

    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum.Tick
        Try
            If Me.Ch1.Checked Then
                Dim totalValue As Double
                If Double.TryParse(TEXTTotal.Text, totalValue) AndAlso totalValue > 0 Then
                    Dim fundValue As Double = Convert.ToDouble(TextFundValue.EditValue)
                    Dim checkValue As Double = Convert.ToDouble(TextValueOfCheck.EditValue)
                    Dim discount As Double = Convert.ToDouble(TEXTDiscount.EditValue)
                    Dim suming As Double = fundValue + checkValue - totalValue + discount
                    TextItemBalanceAfterSaleA.Text = If(suming < 0, "0", suming.ToString("0.00"))
                    If (fundValue + checkValue) = 0 Then
                        TextItemBalanceAfterSaleA.Text = "0"
                    End If
                End If

                If DataGridView1.Rows.Count > 0 Then
                    Dim counter As Integer = DataGridView1.CurrentRow.Index + 1
                    Dim nextRow As DataGridViewRow
                    If counter = Me.DataGridView1.RowCount Then
                        ItemRow = True
                        nextRow = Me.DataGridView1.Rows(0)
                        Me.Ch1.Checked = False
                        Me.txtq.Focus()
                        Me.Timsum.Stop()
                        Me.DanLOd()
                        'Me.UPDATESALES() '  راس الفاتورة
                        'Me.UPDATESALESITEMS() ' البنود
                        Me.RecordCount()
                        Me.PictureBox2.Visible = True
                        Me.BS.EndEdit()
                        Me.RowCount = Me.BS.Count

                        Me.SaveTab = New ComponentModel.BackgroundWorker With {
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                        Me.SaveTab.RunWorkerAsync()
                        Insert_Actions(Me.TEXTID.Text, "تعديل ", Me.Text)

                    Else
                        nextRow = Me.DataGridView1.Rows(0)
                        Me.SEARCHFIFOLIFOAvg()

                        nextRow = Me.DataGridView1.Rows(counter)
                        nextRow.Selected = True
                        SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
                        Me.TextSTK1A.Text = STK1A
                        SEARCHSTOCKSID1(Me.DataGridView1.Item("SITM4", DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
                        Me.TextMAXMOV8.Text = STK1B

                        Me.UPDATEBALANCEITEMS()
                        If Me.TextSTK1A.Text = 0 Then
                            Me.SaveStocks()
                        Else
                            Me.UpdatStocks()
                        End If
                    End If
                    Me.DataGridView1.CurrentCell = nextRow.Cells("SITM2")
                    nextRow.Selected = True
                    Me.DataGridView1.Rows(counter).Selected = True
                    ItemRow = True
                End If



            End If

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateItemBalanceAfterSale()
        Try
            If Ch1.Checked AndAlso Double.TryParse(TEXTTotal.Text, Nothing) AndAlso CDbl(TEXTTotal.Text) > 0 Then
                Dim s1 As Double = Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue)
                Dim s2 As Double = CDbl(TEXTTotal.Text)
                Dim s3 As Double = Val(TEXTDiscount.EditValue)
                Dim suming As Double = s1 - s2 + s3
                TextItemBalanceAfterSaleA.Text = If(suming < 0, "0", suming.ToString("0.00"))

                If (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue)) = 0 Then
                    TextItemBalanceAfterSaleA.Text = "0"
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in UpdateItemBalanceAfterSale: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateStockData()
        Try
            Dim currentRowIndex As Integer = Me.DataGridView1.CurrentRow.Index
            If currentRowIndex >= 0 Then
                Dim stockID As Object = Me.DataGridView1.Item("SITM4", currentRowIndex).Value
                If stockID IsNot Nothing Then
                    SEARCHDATA.SEARCHSTOCKSID(stockID, Me.TextMovementSymbol.EditValue)
                    Me.TextSTK1A.Text = SEARCHDATA.STK1A
                    SEARCHDATA.SEARCHSTOCKSID1(stockID, Me.TextMovementSymbol.EditValue)
                    Me.TextMAXMOV8.Text = SEARCHDATA.STK1B
                    Me.SEARCHFIFOLIFOAvg()
                    Me.UPDATEBALANCEITEMS()
                    If Me.TextSTK1A.Text = "0" Then
                        Me.SaveStocks()
                    ElseIf Me.TextMAXMOV8.Text = Me.TextMovementSymbol.EditValue Then
                        Me.UpdatStocks()
                    Else
                        Me.UpdatStocks()
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in UpdateStockData: " & ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ButtonTransferofAccounts1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts1.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
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
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("عفوا .. يجب ترحيل الى قيد الصندوق و المبيعات اولا ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            Me.Button5_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
            SEARCHDATA.SEARCHMOVESTrueDELETAVE(Me.TextMovementSymbol.EditValue)
            Me.MOVDELETVE.Text = SEARCHDATA.MOVDELETVE

            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            SEARCHDATA.SEARCHMOVESTrueDELETA(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELETA.Text = SEARCHDATA.MOVADELET
            TextTotaUnitPrice.Text = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("SITM10").Value).ToString("0.000"))

            Dim resault As Integer
            If Me.CheckTransferAccounts1.Checked = False Then
                resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferAccounts1.Checked = True
                    TransforAccountsSalesCost()
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions1.Text = "" Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        Me.DELETEDATMOVESDATA4()
                        Me.DELETEDATMOVESDATA5()
                    End If
                    TransforAccountsSalesCost()
                    Me.AccountingprocedureA()
                    Insert_Actions(Me.TEXTID.Text, "تعديل ترحيل  الى القيود اليومية رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Else
                    resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول القيود اليومية  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts1.Checked = False
                        Me.DELETEDATMOVESDATA4()
                        Me.DELETEDATMOVESDATA5()
                        Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة القيود اليومية رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                End If
            End If
            p = Me.BS.Position
            Me.UPDATESALES()
            Me.SaveSALESITEMS()
            Me.UPDATESALESITEMS()
            Me.DanLOd()
            Me.BS.Position = p
            Me.UPDATESALES() '  راس الفاتورة
            Me.UPDATESALESITEMS() ' البنود
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Store = Me.ComboStore.Text
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button5.Click
        If Me.BS.Count <= 0 Then
            Interaction.MsgBox("لا يوجد بيانات", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        If DataGridView1.Rows.Count < 0 Then
            Interaction.MsgBox("لا يوجد اصناف", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If
        On Error Resume Next
        SEARCHDATA.SEARCHMAXIDSTOCKS()
        Me.TEXTCurrentBalance.Text = Format(Conversion.Val(ModuleGeneral.SumAmounTOTALSTOCKS(Me.DataGridView1.CurrentRow.Cells.Item("SITM4").Value.ToString, SEARCHDATA.MAXSTK1)), "0.000")
        SEARCHDATA.SumSTOCKS(Me.num.ToString, Me.CodItem)
        Me.TextItemBalance.Text = Conversion.Val(SEARCHDATA.sumSTK)
        If Conversion.Val(Me.txtq.Text) > Conversion.Val(Me.TextItemBalance.Text) Then
            MsgBox("عفواً هذه الكمية أكبر من الموجود بالمخزن" & vbNewLine & "رصيد الصنف يساوي" & vbNewLine & Me.TextItemBalance.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
            Me.txtq.Text = Me.TextItemBalance.Text
            Me.txtq.Focus()
        End If
        Me.TextTotalPurchasePrice.Text = Format(Val(Me.TextUnitPrice.Text) * Val(Me.TextItemBalance.Text) * (100 - Val(TextDiscountBay.Text)) / 100, "0.000")
        Me.TextThirdSalePrice.Text = Format(Val(Me.TexTSellingPrice.Text) * Val(Me.TextItemBalance.Text) * (100 - Val(TextDiscountPercentageWhenSelling.Text)) / 100, "0.000")
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
        SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextMAXMOV8.Text = SEARCHDATA.STK1B
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.Account_No
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.Account_Name = SEARCHDATA.Account_Name
        SEARCHDATA.MaxIDMoves()
        Me.TextMAXMOV1.Text = Conversion.Val(SEARCHDATA.MAXMOV1)
        Me.TextMAXMOV2.Text = Conversion.Val(SEARCHDATA.MAXMOV2)
        Me.TextMAXMOV8.Text = Conversion.Val(SEARCHDATA.MAXMOV8)

        SEARCHDATA.SEARCHMOVESTrueVE(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1VE

        SEARCHDATA.SEARCHMOVESVEA(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = SEARCHDATA.MOV1A

        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions2.Text = SEARCHDATA.MOV1B


        SEARCHDATA.SEARCHMOVESTrueDELETAVE(Me.TextMovementSymbol.EditValue)
        Me.MOVDELETVE.Text = SEARCHDATA.MOVDELETVE

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET

        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHMOVESTrueDELETA(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELETA.Text = SEARCHDATA.MOVADELET


        SEARCHDATA.SEARCHMOVESVEA(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions2.Text = SEARCHDATA.MOV1A
        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTInvoiceNumber.EditValue)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH

        SEARCHDATA.SEARCHCABLES(Me.TEXTInvoiceNumber.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber.Text = SEARCHDATA.IDCAB
        SEARCHDATA.SEARCHCABLES1(Me.TEXTInvoiceNumber.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber1.Text = SEARCHDATA.IDCAB1
    End Sub

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RBCASHA.CheckedChanged, RBCheck.CheckedChanged
        If Me.RBCASHA.Checked = True Then
            Me.TextFundValue.EditValue = Format(Val(Me.TextFundValue.EditValue) + Val(Me.TEXTSalesTaxes.Text), "0.000")
        ElseIf Me.RBCheck.Checked = True Then
            Me.TextValueOfCheck.EditValue = Format(Val(Me.TextValueOfCheck.EditValue) + Val(Me.TEXTSalesTaxes.Text), "0.000")
        End If
        AccountsEnquiry()
    End Sub

    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If
            GetAutoNumberMyDOCUMENTSFL(TextMovementSymbol.EditValue)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim f As New FrmJPG0
            f.Show()
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
            f.BS.EndEdit()
            f.BS.AddNew()
            f.MAXRECORD()
            f.DateP1.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = documentId
            f.TEXTFileSubject.Text = "مستندات فاتورة مبيعات"
            f.TextFileDescription.Text = "ارفاق مستندات فاتورة مبيعات "
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT  DOC1, LO   FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
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

    Private Sub SEARCHDMAXCASHIER()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
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
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        SEARCHDMAXCASHIER()
        GetFundAccount_No(ModuleGeneral.CB2)
        AccountsEnquiry()
    End Sub

End Class
