Option Explicit Off
Imports System.ComponentModel
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Threading.Tasks
Imports DevExpress.XtraSplashScreen

Public Class FrmCustomersA1
    Inherits Form

    ReadOnly T As Boolean = True, F As Boolean = False
    Private ReadOnly SqlDataAdapter1 As New SqlDataAdapter
    Private ReadOnly SqlDataAdapter2 As New SqlDataAdapter
    ReadOnly SqlDataAdapter3 As New SqlDataAdapter
    Public CompareDiscount As Double = 0
    Dim CodItem As Integer = 0
    Dim CodItemA As Integer = 0
    Dim num As String = ""
    Private ds As New DataSet
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim TypeCustomer As String
    Public WithEvents BS As New BindingSource

    Dim NO As String
    Dim NO1 As Integer = 0
    ReadOnly NO2 As Integer = 0
    Dim ChkPD As Boolean = False
    Dim TransforAccountsSalesCost_Check As Boolean = False
    Dim UnitPrice As Double = 0
    Dim TotalUnitPrice As Double = 0


    Dim ItemBalance As Double = 0.0
    Dim PreviousBalance As Double = 0.0
    Dim CurrentBalance As Double = 0.0
    Dim UnitPriceA As Double = 0.0
    Dim SellingPrice As Double = 0.0
    Private ReadOnly SearchTimer As New Timer With {.Interval = 300} ' Debounce timer for search
    Private TotalItems As Double = 0.0
    Private TotalDiscount As Double = 0.0
    Dim discountPercent As Double = 0.0

    Private Sub FrmCustomersA1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmCustomersA1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.SHOWBUTTON()
        'FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub

    Private Async Sub BackgroundWorker1_DoWork(sender As Object, e As DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            Using Consum As New SqlConnection(constring)
                Dim str1 As New SqlCommand("", Consum)
                Dim str2 As New SqlCommand("", Consum)

                If Cash = True Then
                    Me.Label9.Text = "فاتورة بيع نقدى"
                    str1.CommandText = "SELECT SLS2 FROM SALES WHERE CUser=@CUser AND SLS2=@InvoiceNumber AND deleted=0 AND type_cash=1 ORDER BY SLS2"
                Else
                    Me.Label9.Text = "فاتورة بيع أجـل"
                    Me.ComboPaymentMethod.Text = "العملاء مدينين"
                    Me.ComboPaymentMethod.Enabled = False
                    Me.GroupCHKS.Enabled = False
                    Me.GroupCHKS1.Enabled = False
                    str1.CommandText = "SELECT SLS2 FROM SALES WHERE CUser=@CUser AND SLS2=@InvoiceNumber AND deleted=0 AND type_cash=0 ORDER BY SLS2"
                End If

                str2.CommandText = "SELECT SITM1, SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, 
                               (([SITM5] * [SITM6]) * (100 - [SITM7])) / 100 AS SITM8, 
                               SITM9, SITM10, SITM11, SLS2 
                               FROM SALESITEMS 
                               WHERE SLS2 IN (SELECT SLS2 FROM SALES WHERE CUser=@CUser AND SLS2=@InvoiceNumber AND deleted=0 AND type_cash=@TypeCash) 
                               ORDER BY SLS2"

                str1.Parameters.AddWithValue("@CUser", CUser)
                str1.Parameters.AddWithValue("@InvoiceNumber", Me.TEXTInvoiceNumber.EditValue)
                str2.Parameters.AddWithValue("@CUser", CUser)
                str2.Parameters.AddWithValue("@InvoiceNumber", Me.TEXTInvoiceNumber.EditValue)
                str2.Parameters.AddWithValue("@TypeCash", If(Cash, 1, 0))

                Await Consum.OpenAsync()

                Using adapter1 As New SqlDataAdapter(str1), adapter2 As New SqlDataAdapter(str2)
                    Me.ds.Clear()
                    Await Task.Run(Sub()
                                       adapter1.Fill(Me.ds, "SALES")
                                       adapter2.Fill(Me.ds, "SALESITEMS")
                                   End Sub)
                End Using

                If Not Me.ds.Relations.Contains("REL1") Then
                    Me.ds.Relations.Add("REL1", Me.ds.Tables("SALES").Columns("SLS2"),
                                    Me.ds.Tables("SALESITEMS").Columns("SLS2"), True)
                End If
            End Using

            Me.Invoke(Sub()
                          Me.BS.DataSource = Me.ds
                          Me.BS.DataMember = "SALES"
                          Me.ds.EnforceConstraints = True
                          Me.DataGridView1.DataSource = Me.BS
                          Me.DataGridView1.DataMember = "REL1"
                      End Sub)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBackgroundWorker1_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            SplashScreenManager.CloseForm(False)
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted

        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        PurchSales_Check = True

        TestkeyAccounts(keyAccounts.GetValue("SalesAccount_No", SalesAccount_No))
        If TestkeyAccounts_Check Then
            AccountNoAktevd = keyAccounts.GetValue("SalesAccount_No", SalesAccount_No)
        End If
        SplashScreenManager.CloseForm(False)
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
                MessageBox.Show(ex.Message, "ErrorSaveData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            Application.DoEvents()
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.LablAA.Visible = True
            Me.LabStatus.Visible = True
            Me.LabStatus.Text = "تمت عملية ترحيل البيانات بنجاح"

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
            If CDbl(Val(Me.TEXTDiscount.Text)) > CDbl(CompareDiscount) Then
                MsgBox("لا يجب ان يكون الخصم أكبر من قيمة الفاتورة")
                Me.TEXTDiscount.Clear()
                Me.TEXTDiscountPercentage.Focus()
            Else
                'Me.Totalcount()
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
        Me.TEXTTotal.Text = Total1 + CDbl(Val(Me.TEXTTotalItemsWithTaxes.Text)) + CDbl(Val(Me.TEXTSalesTaxes.Text)) - CDbl(Val(Me.TEXTDiscount.Text))
    End Sub

    Private Sub TEXTTotal_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTTotal.TextChanged
        On Error Resume Next
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub

    'Code Optimization
    Private Sub MAXRECORD()
        Try
            Using Consum As New SqlConnection(constring)
                Dim SQL As New SqlCommand("SELECT MAX(SALES.SLS1) FROM SALES WHERE CUser=@CUser AND Year(SALES.SLS3) = @FiscalYear", Consum)
                SQL.Parameters.AddWithValue("@CUser", CUser)
                SQL.Parameters.AddWithValue("@FiscalYear", Val(FiscalYear_currentDateMustBeInFiscalYear()))

                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                Consum.Open()

                Dim result As Object = SQL.ExecuteScalar()
                If IsDBNull(result) OrElse result Is Nothing Then
                    Me.TEXTID.Text = 1
                Else
                    Me.TEXTID.Text = CType(result, Integer) + 1
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in MAXRECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TEXTInvoiceNumber_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTInvoiceNumber.KeyPress
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


    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        If Not LockAddRow Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        Try
            MangUsers()

            Me.BS.Position = Me.BS.Count - 1
            Me.BS.EndEdit()
            Me.BS.AddNew()

            CLEARDATA1(Me)
            Me.TEXTInvoiceNumber.Enabled = True

            Me.MAXRECORD()
            GetAutoNumber("SLS2", "SALES", "SLS3")
            Me.TEXTInvoiceNumber.EditValue = AutoNumber
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")

            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)

            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If

            TransferToAccounts_Check = ItWillBeAnAccountingEntryWhenAdding_Check
            TransforAccountsSalesCost_Check = ItWillBeAnAccountingEntryWhenAdding_Check

            Me.TextMovementSymbol.EditValue = "VE" & Me.TEXTInvoiceNumber.EditValue
            Me.ComboCustomerName.Text = "عميل عام"
            Me.TextCustomerNumber.EditValue = 0
            Me.TextFundValue.EditValue = 0
            Me.TEXTPermissionNumber.Text = 0
            Me.TextCheckDrawerCode.Text = 0
            Me.TextValueOfCheck.EditValue = 0
            Me.TEXTInvoiceNumber.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True

        Catch ex As Exception
            MsgBox("An error occurred: " & ex.Message, 16, "Error")
        End Try
    End Sub


    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Try
            Dim ch As Double = Val(Me.TEXTTotalItemsWithTaxes.Text)
            Dim ch11 As Double = Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue)
            'Dim ch12 As Double = Me.TEXT19.Text

            Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Descending)
            Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Ascending)

            Me.DataGridView1.ClearSelection()
            Dim nextRow As DataGridViewRow
            nextRow = Me.DataGridView1.Rows(0)
            Me.DataGridView1.Rows(0).Selected = True
            DataGridView1.CurrentCell = DataGridView1("SITM2", DataGridView1.Rows(0).Index)
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Val(ch).ToString("0.000") <> Val(ch11).ToString("0.000") Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboPaymentMethod.Text = "شيك" Then
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
            ElseIf Me.ComboPaymentMethod.Text = "شيك و نقدا" Then
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
            End If
            GetDiscount_B(Val(Me.TEXTDiscount.Text))
            GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOptions.ShowDialog()
                Exit Sub
            End If
            TotalUnitPrice = Val(Me.Text_TotalUnitPrice.Text).ToString("0.000")
            If Me.Ch1.Checked = False Then
                Ch1.Checked = True
            End If
            SEARCHDATA.SEARCHMAXIDSTOCKS()
            Me.TEXTCurrentBalance.Text = Format(Conversion.Val(ModuleGeneral.SumAmounTOTALSTOCKS(Me.DataGridView1.CurrentRow.Cells.Item("SITM4").Value.ToString, SEARCHDATA.MAXSTK1)), "0.000")
            SEARCHDATA.SumSTOCKS(Me.num.ToString, Me.CodItem)
            Me.TextItemBalance.Text = Conversion.Val(SEARCHDATA.sumSTK)
            If Conversion.Val(Me.txtq.Text) > Conversion.Val(Me.TextItemBalance.Text) Then
                MsgBox("عفواً هذه الكمية أكبر من الموجود بالمخزن" & vbNewLine & "رصيد الصنف يساوي" & vbNewLine & Me.TextItemBalance.Text, MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
                Me.txtq.Text = Me.TextItemBalance.Text
                Me.txtq.Focus()
            End If
            PurchSales_Check = True
            CalculatingTax_B = Format(Val(Me.TEXTSalesTaxes.Text), "0.000")
            Me.TextTotalPurchasePrice.Text = Format(Val(Me.TextUnitPrice.Text) * Val(Me.TextItemBalance.Text) * (100 - Val(TextDiscountBay.Text)) / 100, "0.000")
            SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
            Me.TextSTK1A.Text = SEARCHDATA.STK1A
            SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
            Me.TextMAXMOV8.Text = SEARCHDATA.STK1B
            Static Dim P As Integer
            P = Me.BS.Position

            Me.UPDATESALES()
            Me.SaveSALESITEMS()
            Me.UPDATESALESITEMS()
            Me.BackgroundWorker1.WorkerSupportsCancellation = True
            Me.BackgroundWorker1.WorkerReportsProgress = True
            If Not Me.BackgroundWorker1.IsBusy Then
                Me.BackgroundWorker1.RunWorkerAsync()
            End If
            nextRow = Me.DataGridView1.Rows(0)
            nextRow.Selected = True
            Me.DataGridView1.Rows(0).Selected = True
            Me.BS.Position = P + 1
            Me.SaveSALESITEMS()
            'SaveStocks()
            'UpdatStocks()
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.SAVEBUTTON.Enabled = False
            Me.KeyPreview = False
            Insert_Actions(Me.TEXTID.Text, "حقظ ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVEBUTTON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveSALES()
        'On Error Resume Next
        Try
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim SQL As New SqlCommand("INSERT INTO SALES (SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31,WarehouseNumber, WarehouseName,  CB1, USERNAME, CUser, COUser, da, ne, TYPE_CASH, TYPE_CRDT, DELETED) VALUES     (@SLS1, @SLS2, @SLS3, @SLS4, @SLS5, @SLS6, @SLS7, @SLS8, @SLS9, @SLS10, @SLS11, @SLS12, @SLS13, @SLS14, @SLS15, @SLS16, @SLS17, @SLS19, @SLS20, @SLS21, @SLS22, @SLS23, @SLS24, @SLS25, @SLS26, @SLS27, @SLS28, @SLS29, @SLS30, @SLS31,@WarehouseNumber, @WarehouseName,  @CB1, @USERNAME, @CUser, @COUser,  @da, @ne, @TYPE_CASH, @TYPE_CRDT, @DELETED)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SLS1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@SLS2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumber.EditValue
                .Parameters.Add("@SLS3", SqlDbType.Date).Value = MaxDate.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS4", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text
                .Parameters.Add("@SLS5", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@SLS6", SqlDbType.NVarChar).Value = Me.TEXTItemsTotal.Text
                .Parameters.Add("@SLS7", SqlDbType.NVarChar).Value = Me.TEXTDiscountPercentage.EditValue
                .Parameters.Add("@SLS8", SqlDbType.NVarChar).Value = Me.TEXTDiscount.Text
                .Parameters.Add("@SLS9", SqlDbType.NVarChar).Value = Me.TEXTNetItems.Text
                .Parameters.Add("@SLS10", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.EditValue
                .Parameters.Add("@SLS11", SqlDbType.NVarChar).Value = Me.TEXTSalesTaxes.Text
                .Parameters.Add("@SLS12", SqlDbType.NVarChar).Value = Me.TEXTTotalItemsWithTaxes.Text
                .Parameters.Add("@SLS13", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@SLS14", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@SLS15", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@SLS17", SqlDbType.Bit).Value = False
                '.Parameters.Add("@SLS18", SqlDbType.NVarChar).Value = maxDate.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS19", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@SLS20", SqlDbType.Bit).Value = False
                .Parameters.Add("@SLS21", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@SLS22", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@SLS23", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@SLS24", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@SLS25", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@SLS26", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@SLS27", SqlDbType.DateTime).Value = MaxDate.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS28", SqlDbType.NVarChar).Value = Me.TextBank.Text
                .Parameters.Add("@SLS29", SqlDbType.NVarChar).Value = Me.TextBranch.Text
                .Parameters.Add("@SLS30", SqlDbType.Bit).Value = False
                .Parameters.Add("@SLS31", SqlDbType.Bit).Value = False
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.Int).Value = CUser
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
                .Parameters.Add("@DELETED", SqlDbType.Bit).Value = False
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveSALES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveSALESITEMS()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO SALESITEMS (SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, SITM8, SITM9, SITM10, SITM11, SLS2) VALUES     (@SITM2, @SITM3, @SITM4, @SITM5, @SITM6, @SITM7, @SITM8, @SITM9, @SITM10, @SITM11, @SLS2)", Consum)
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
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

    Private Sub UPDATESALES()
        Try
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim SQL As New SqlCommand(" Update SALES SET  SLS2 = @SLS2, SLS3 = @SLS3, SLS4 = @SLS4, SLS5 = @SLS5, SLS6 = @SLS6, SLS7 = @SLS7, SLS8 = @SLS8, SLS9 = @SLS9, SLS10 = @SLS10, SLS11 = @SLS11, SLS12 = @SLS12, SLS13 = @SLS13, SLS14 = @SLS14, SLS15 = @SLS15, SLS16 = @SLS16,  SLS17 = @SLS17, SLS18 = @SLS18, SLS20 = @SLS20, SLS21 = @SLS21, SLS22 = @SLS22, SLS23 = @SLS23, SLS24 = @SLS24, SLS25 = @SLS25, SLS26 = @SLS26, SLS27 = @SLS27, SLS28 = @SLS28, SLS29 = @SLS29, SLS30 = @SLS30, SLS31 = @SLS31,WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  CB1 = @CB1, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, TYPE_CASH = @TYPE_CASH, TYPE_CRDT = @TYPE_CRDT WHERE  SLS2 = @SLS2", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SLS1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@SLS2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumber.EditValue
                .Parameters.Add("@SLS3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS4", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text
                .Parameters.Add("@SLS5", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@SLS6", SqlDbType.NVarChar).Value = Me.TEXTItemsTotal.Text
                .Parameters.Add("@SLS7", SqlDbType.NVarChar).Value = Me.TEXTDiscountPercentage.EditValue
                .Parameters.Add("@SLS8", SqlDbType.NVarChar).Value = Me.TEXTDiscount.Text
                .Parameters.Add("@SLS9", SqlDbType.NVarChar).Value = Me.TEXTNetItems.Text
                .Parameters.Add("@SLS10", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.EditValue
                .Parameters.Add("@SLS11", SqlDbType.NVarChar).Value = Me.TEXTSalesTaxes.Text
                .Parameters.Add("@SLS12", SqlDbType.NVarChar).Value = Me.TEXTTotalItemsWithTaxes.Text
                .Parameters.Add("@SLS13", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@SLS14", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@SLS15", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@SLS17", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@SLS18", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS21", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@SLS22", SqlDbType.Money).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@SLS23", SqlDbType.Money).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@SLS24", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@SLS25", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@SLS26", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@SLS27", SqlDbType.DateTime).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLS28", SqlDbType.NVarChar).Value = Me.TextBank.Text
                .Parameters.Add("@SLS29", SqlDbType.NVarChar).Value = Me.TextBranch.Text
                .Parameters.Add("@SLS30", SqlDbType.Bit).Value = False
                .Parameters.Add("@SLS31", SqlDbType.Bit).Value = Convert.ToInt32(TransforAccountsSalesCost_Check)
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If Cash = True Then
                    .Parameters.Add("@SLS16", SqlDbType.NVarChar).Value = "نقــــــدى"
                    .Parameters.Add("@SLS20", SqlDbType.Bit).Value = False
                    .Parameters.Add("@TYPE_CASH", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CRDT", SqlDbType.Bit).Value = False
                Else
                    .Parameters.Add("@SLS16", SqlDbType.NVarChar).Value = "أجـــــــل"
                    .Parameters.Add("@SLS20", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CRDT", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CASH", SqlDbType.Bit).Value = False
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

    Private Sub UPDATESALESITEMS()
        On Error Resume Next

        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update SALESITEMS SET   SITM2 = @SITM2, SITM3 = @SITM3, SITM4 = @SITM4, SITM5 = @SITM5, SITM6 = @SITM6, SITM7 = @SITM7, SITM8 = @SITM8, SITM9 = @SITM9, SITM10 = @SITM10, SITM11 = @SITM11, SLS2 = @SLS2 WHERE   SITM1 = @SITM1", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
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
        SqlDataAdapter2.UpdateCommand = CMD
        SqlDataAdapter2.Update(ds, "SALESITEMS")
        Consum.Close()
    End Sub

    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTInvoiceNumber.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub

    Private Sub TEXTInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTInvoiceNumber.LostFocus
        Static Dim P As Integer
        P = Me.BS.Position
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        Me.BackgroundWorker1.WorkerReportsProgress = True
        If Not Me.BackgroundWorker1.IsBusy Then
            Me.BackgroundWorker1.RunWorkerAsync()
        End If
        Me.BS.Position = P
        Me.TEXTInvoiceNumber.Enabled = False
    End Sub

    Private Sub TEXTInvoiceNumber_GotFocus(sender As Object, e As EventArgs) Handles TEXTInvoiceNumber.GotFocus
        Me.TEXTInvoiceNumber.Enabled = True
        Me.SaveSALES()
    End Sub

    'Code Optimization
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
                        cmd.Parameters.AddWithValue("@STK25", Me.DataGridView2.Item("STK25", Me.DataGridView2.CurrentRow.Index).Value)
                        Adp1 = New SqlDataAdapter(cmd)
                        ds.Clear()
                        Adp1.Fill(ds)
                    End Using
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    'MsgBox("UpdateTextFields")
                    'UpdateTextFields(ds.Tables(0).Rows(0))
                Else
                    'MsgBox("FetchStockItems")
                    FetchStockItems(Consum, Adp1, ds)
                End If
            End Using
            Me.TextUnitPrice.Text = Val(UnitPrice).ToString("0.000")
            Me.TextTotalPurchasePrice.Text = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TextUnitPrice.Text) * (100 - Val(Me.TextDiscountBay.Text)) / 100, "0.000")

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSEARCHFIFOLIFOAvg", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateTextFields(ByVal row As DataRow)
        Try
            Dim Tax, Tax1 As Boolean
            Dim Tax2 As String
            Tax2 = row.Item("STK7")
            Me.TextSTK8.Text = row("STK8").ToString()
            UnitPrice = row("STK15")
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
            Me.CheckPricesMentionedIncludeSalesTax.Checked = Boolean.TryParse(row("SKITM20").ToString(), Tax)
            Me.CheckItemIsSubjectToSalesTax.Checked = Boolean.TryParse(row("SKITM21").ToString(), Tax1)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdateTextFields", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FetchStockItems(ByVal Consum As SqlConnection, ByVal Adp1 As SqlDataAdapter, ByVal ds As DataSet)
        If Me.DataGridView2.Rows.Count > 0 Then
            For i As Integer = 0 To Me.DataGridView2.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView2.Rows(i)
                If row.IsNewRow Then Continue For

                Dim query As String = "SELECT SKITM3, SKITM4, SKITM5, SKITM6, SKITM8, SKITM9, SKITM11, SKITM12, SKITM14, SKITM15, SKITM16, SKITM17, SKITM18, SKITM19, SKITM20, SKITM21, SKITM22, SKITM23, SKITM24, SKITM25, SKITM26, IT_DATEP, IT_DATEEX FROM STOCKSITEMS WHERE CUser = @CUser AND SKITM4 = @SKITM4"
                Using cmd As New SqlCommand(query, Consum)
                    cmd.Parameters.AddWithValue("@CUser", CUser)
                    cmd.Parameters.AddWithValue("@SKITM4", Me.DataGridView2.Item("STK25", Me.DataGridView2.CurrentRow.Index).Value)
                    ds.Clear()
                    Adp1 = New SqlDataAdapter(cmd)
                    Adp1.Fill(ds)
                End Using

                If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                    UpdateTextFields(ds.Tables(0).Rows(0))
                End If
            Next

            If Adp1 IsNot Nothing Then Adp1.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
        End If
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

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                Next
            Else
                MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
            End If
            Exit Sub

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



    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        'Me.SEARCHFIFOLIFOAvg()
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next
        'Me.SEARCHFIFOLIFOAvg()
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

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        Exit Sub
    End Sub

    Private Sub SaveStocks()
        Try
            Dim Consum As New SqlConnection(constring)
            'GetAutoIDSTK()
            IDSTK = GetAutoNumber("STK1", "STOCKS", "STK4")
            CodItemA = Convert.ToInt64(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value)
            ItemBalance = Convert.ToDouble(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value)
            PreviousBalance = SumBalanceItemsA(ComboStore.SelectedItem, CodItemA, IDSTK)

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

    Private Function SumTOTALSTOCKS(ByVal CodItem As Integer, ByVal WarehouseNumber As Integer, ByVal IDSTK As Integer) As Decimal
        Dim result As Decimal = 0.0
        Dim query As String = "SELECT SUM(STK11 - STK12) FROM STOCKS WHERE CUser = @CUser AND WarehouseNumber = @WarehouseNumber AND STK25 = @CodItem AND STOCKS.STK1 <= @IDSTK"

        Using connection As New SqlClient.SqlConnection(constring)
            Using command As New SqlClient.SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@WarehouseNumber", WarehouseNumber)
                command.Parameters.AddWithValue("@CodItem", CodItem)
                command.Parameters.AddWithValue("@IDSTK", IDSTK)

                Try
                    connection.Open()
                    Dim resultObj As Object = command.ExecuteScalar()
                    If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                        result = Convert.ToDecimal(resultObj)
                    End If
                Catch ex As OverflowException
                    MessageBox.Show("Overflow occurred: " & ex.Message, "ErrorSumTotalStocksOver", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "ErrorSumTotalStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return result

    End Function

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

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me.AccountsEnquiry()
    End Sub

    Private Sub TransforAccountsSalesCost()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing
            DebitAccount_No = keyAccounts.GetValue("CalculatingCostGoodsSold_No", CalculatingCostGoodsSold_No) 'حساب تكلفه البضاعه المباعه
            CredAccount_NO = keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No) 'حساب مخزون البضاعة
            If keyAccounts.GetValue("CalculatingCostGoodsSold_No", CalculatingCostGoodsSold_No) = Nothing Then
                MsgBox("رقم حساب تكلفه البضاعه المباعه فارغ")
                Exit Sub
            End If
            If keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No) = Nothing Then
                MsgBox("رقم حساب مخزون البضاعة فارغ")
                Exit Sub
            End If

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


            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TotalUnitPrice, TotalUnitPrice, T3, "قيد", "VEA", TextMovementSymbol.EditValue, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TotalUnitPrice, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, True, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TotalUnitPrice, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, True, T2)

        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TransforAccounts()
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(Me.TEXTDiscount.Text))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

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
            Select Case Me.ComboPaymentMethod.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, ModuleGeneral.CB2.ToString, Accounts_NO, TextFundValue.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    If Val(Me.TEXTDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, DiscountAccountAE_Name, PurchSalesDiscount_No, TEXTDiscount.Text, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    Else
                        Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, CredAccount_Name, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    End If
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                                                            nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                            False, True, ComboCB1.Text, CB2)
                Case "شيك"

                    DetailsAccountingEntries(PMO2, ChecksAccount_Name, ChecksAccount_NO, TextValueOfCheck.EditValue, 0, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    If Val(Me.TEXTDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, DiscountAccountAE_Name, PurchSalesDiscount_No, TEXTDiscount.Text, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    Else
                        Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, CredAccount_Name, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    End If
                    Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
              0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, True,
              TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)
                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, ModuleGeneral.CB2.ToString, Accounts_NO, TextFundValue.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ChecksAccount_Name, ChecksAccount_NO, TextValueOfCheck.EditValue, 0, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    If Val(Me.TEXTDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 2, DiscountAccountAE_Name, PurchSalesDiscount_No, TEXTDiscount.Text, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    Else
                        Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 3, CredAccount_Name, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 4, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    End If
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFundValue.EditValue, 0, Me.Text,
                                             nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                             False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue,
              0, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "قبض", T2, TextBank.Text, TextBranch.Text, True,
              TextMovementSymbol.EditValue, False, ComboCB1.Text, 0)

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

            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotalItemsWithTaxes.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            If Val(Me.TEXTDiscount.Text) > 0 Then
                DetailsAccountingEntries(PMO2 + 1, DiscountAccountAE_Name, PurchSalesDiscount_No, TEXTDiscount.Text, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            Else
                Val(PMO2 - 1)
            End If
            DetailsAccountingEntries(PMO2 + 2, CredAccount_Name, CredAccount_NO, 0, TEXTItemsTotal.Text, nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                DetailsAccountingEntries(PMO2 + 3, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, 0, TEXTSalesTaxes.Text, nem4, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            End If

            MAXIDCAB1()
            Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TEXTTotalItemsWithTaxes.Text, 0, "نقدا", TEXTInvoiceNumber.EditValue,
              "فاتورة مبيعات" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "أجـــــــل", TextMovementSymbol.EditValue, TextFundValue.EditValue,
              "العملاء مدينين", 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TEXTTotalItemsWithTaxes.Text, "jO"),
              TypeCustomer, TextBank.Text, TextBranch.Text, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
              TextCheckDrawerCode.Text, ComboCB1.Text, 0)

        End If

    End Sub

    Private Sub AccountsEnquiry()
        On Error Resume Next

        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(Me.TEXTDiscount.Text))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        If Cash = True Then
            Select Case Me.ComboPaymentMethod.Text
                Case "نقدا"
                    Me.TextValueOfCheck.Enabled = False
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.EditValue = "0.00"
                    Me.TextFundValue.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                Case "شيك"
                    Me.TextFundValue.Enabled = False
                    Me.TextValueOfCheck.Enabled = True
                    Me.TextTotalPurchasePrice.Enabled = True
                    Me.TextBank.Enabled = True
                    Me.TextBranch.Enabled = True
                    Me.TextFundValue.EditValue = "0.00"
                    Me.TextValueOfCheck.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")

                Case "نقدا_شيك"
                    Me.TextFundValue.Enabled = True
                    Me.TextValueOfCheck.Enabled = True
                    Me.TextTotalPurchasePrice.Enabled = True
                    Me.TextBank.Enabled = True
                    Me.TextBranch.Enabled = True
                    Me.TextFundValue.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                    LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            End Select
        Else
            Me.ComboPaymentMethod.Text = "العملاء مدينين"
            Me.ComboPaymentMethod.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.TextFundValue.Enabled = True
            Me.TextValueOfCheck.EditValue = "0.000"
            Me.TextFundValue.EditValue = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) - Val(Me.TEXTDiscount.Text), "0.000")
            LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"

        End If
    End Sub

    Private Sub TEXT4_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTItemsTotal.TextChanged, TEXTDiscountPercentage.EditValueChanged, TEXTTaxRate.EditValueChanged, TEXTSalesTaxes.EnabledChanged, TEXTDiscount.TextChanged, TEXTNetItems.TextChanged, TEXTSalesTaxes.TextChanged, TEXTTotalItemsWithTaxes.TextChanged, TextSITM11.TextChanged, TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged, TextDiscountBay.TextChanged
        UpdateTotals()
        Me.AccountsEnquiry()
    End Sub

    Private Sub UpdateTotals()



        Double.TryParse(TEXTDiscountPercentage.EditValue?.ToString(), discountPercent)

        Dim discountValue As Double = TotalItems * (discountPercent / 100)
        Dim finalDiscount As Double = TotalDiscount + discountValue

        TEXTItemsTotal.Text = (TotalDiscount + TotalItems).ToString("0.000")
        TEXTDiscount.Text = finalDiscount.ToString("0.000")

        TEXTNetItems.Text = (Val(TEXTItemsTotal.Text) - Val(TEXTDiscount.Text))

        Dim taxRate As Double
        Double.TryParse(TEXTTaxRate.EditValue?.ToString(), taxRate)
        TEXTSalesTaxes.Text = (Val(TEXTItemsTotal.Text) * taxRate / 100).ToString("0.000")
        TEXTTotalItemsWithTaxes.Text = (Val(TEXTSalesTaxes.Text) + Val(TEXTNetItems.Text)).ToString("0.000")

        Me.TEXTTotal.Text = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) + Val(Me.TEXTDiscount.Text), "0.000")
        Me.TextDiscountBay.Text = Val(Me.TextTotalDiscount.Text)
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
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
        'SearchTimer.Stop()
        'SearchTimer.Start()
        PerformItemSearch(txtItem2.Text)
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
        Me.DataGridView1.CurrentRow.Cells("SITM4").Value = Me.CodItem
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
                UpdateItemBalanceAfterSale()
                If Me.DataGridView1.Rows.Count > 0 Then
                    ProcessNextRow()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorTimsum_Tick", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateItemBalanceAfterSale()

        If Me.TEXTTotal.Text > 0 Then
            Dim fundValue As Double = Convert.ToDouble(Me.TextFundValue.EditValue)
            Dim checkValue As Double = Convert.ToDouble(Me.TextValueOfCheck.EditValue)
            Dim totalValue As Double = Convert.ToDouble(Me.TEXTTotal.Text)
            Dim discountValue As Double = Convert.ToDouble(Me.TEXTDiscount.Text)
            Dim balanceAfterSale As Double = fundValue - totalValue + discountValue
            Me.TextItemBalanceAfterSaleA.Text = balanceAfterSale.ToString("0.00")
        End If
        If Me.TEXTTotal.Text = "0" OrElse Me.TextFundValue.EditValue + Me.TextValueOfCheck.EditValue = "0" Then
            Me.TextItemBalanceAfterSaleA.Text = "0"
        End If
    End Sub

    'Code Optimization

    Private Sub ProcessNextRow()
        Dim counter As Integer = Me.DataGridView1.CurrentRow.Index + 1
        If counter = Me.DataGridView1.RowCount Then
            Dim NextRow As DataGridViewRow = Me.DataGridView1.Rows(0)
            Me.Ch1.Checked = False
            Me.txtq.Focus()
            Me.Timsum.Stop()

            If ItWillBeAnAccountingEntryWhenAdding_Check Then
                TransferToAccounts_Check = True
                TransforAccountsSalesCost_Check = True
                TransforAccounts()
                TransforAccountsSalesCost()
            Else
                TransferToAccounts_Check = False
                TransforAccountsSalesCost_Check = False
            End If
        Else
            Dim NextRow As DataGridViewRow = Me.DataGridView1.Rows(counter)
            NextRow.Selected = True
            UpdateStockData()
            Me.DataGridView1.CurrentCell = NextRow.Cells("SITM2")
            NextRow.Selected = True
        End If
    End Sub

    Private Sub UpdateStockData()
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
        SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextMAXMOV8.Text = SEARCHDATA.STK1B
        Me.SEARCHFIFOLIFOAvg()
        Me.UPDATEBALANCEITEMS()
        If Me.TextSTK1A.Text = 0 Then
            Me.SaveStocks()
        ElseIf Me.TextMAXMOV8.Text = Me.TextMovementSymbol.EditValue Then
            Me.UpdatStocks()
        Else
            Me.UpdatStocks()
        End If
    End Sub

    'Private Sub HandleAccountingEntries()
    '    If ItWillBeAnAccountingEntryWhenAdding_Check Then
    '        TransferToAccounts_Check = True
    '        TransforAccountsSalesCost_Check = True
    '        TransforAccounts()
    '        TransforAccountsSalesCost()
    '    Else
    '        TransferToAccounts_Check = False
    '        TransforAccountsSalesCost_Check = False
    '    End If
    'End Sub

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
            Me.TextWarehouseName.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextWarehouseName.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Private Sub CmdCust_Click(sender As Object, e As EventArgs) Handles CmdCust.Click
        On Error Resume Next
        Dim F As New FrmAllCustomers1
        F.Show()
    End Sub

    Private Sub CmdItems_Click(sender As Object, e As EventArgs) Handles CmdItems.Click
        On Error Resume Next
        Dim F As New FrmStocksA1
        F.Show()
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