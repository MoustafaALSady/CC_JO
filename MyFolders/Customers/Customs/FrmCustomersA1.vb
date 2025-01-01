Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Public Class FrmCustomersA1
    Inherits System.Windows.Forms.Form

    ReadOnly T As Boolean = True, F As Boolean = False
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    ReadOnly SqlDataAdapter3 As New SqlClient.SqlDataAdapter
    Public CompareDiscount As Double = 0
    Dim cod As Integer
    Dim num As String = ""
    ReadOnly ds As New DataSet
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim TypeCustomer As String
    Public WithEvents BS As New BindingSource
    Dim test As Integer
    Dim test2 As Integer
    Dim ik As Integer
    Dim NO As String
    Dim NO1 As Integer = 0
    ReadOnly NO2 As Integer = 0
    Dim ChkPD As Boolean = False
    Dim TransforAccountsSalesCost_Check As Boolean = False
    Dim UnitPrice As Double = 0
    Dim TotalUnitPrice As Double = 0

    Private Sub FrmCustomersA1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmCustomersA1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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

    Private Sub FrmCustomersA1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
    End Sub

    Private Sub FrmCustomersA1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        Me.SHOWBUTTON()
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False

        PurchSales_Check = True
        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

        TestkeyAccounts(keyAccounts.GetValue("SalesAccount_No", SalesAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("SalesAccount_No", SalesAccount_No)
        End If

    End Sub


    Public Sub DanLOd()
        On Error Resume Next
        'Try
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        If Cash = True Then
            Me.Label9.Text = "فاتورة بيع نقدى"
            str1.CommandText = "SELECT SLS2  FROM SALES  WHERE   CUser='" & CUser & "' and SLS2 ='" & Me.TEXTInvoiceNumber.EditValue & "' and deleted ='" & False & "' and type_cash ='" & True & "'ORDER BY SLS2"
        Else
            Me.Label9.Text = "فاتورة بيع أجـل"
            Me.ComboPaymentMethod.Text = "العملاء مدينين"
            Me.ComboPaymentMethod.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.GroupCHKS1.Enabled = False
            str1.CommandText = "SELECT  SLS2  FROM SALES  WHERE   CUser='" & CUser & "' and SLS2 ='" & Me.TEXTInvoiceNumber.EditValue & "' and  deleted ='" & False & "' and type_cash ='" & False & "'ORDER BY SLS2"
        End If
        str2.CommandText = "SELECT SITM1, SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, (([SITM5] * [SITM6]) * (100 - [SITM7])) / 100 AS SITM8, SITM9, SITM10, SITM11, SLS2 FROM SALESITEMS ORDER BY SLS2"
        Me.ds.EnforceConstraints = False
        Consum.Open()

        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.ds.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds, "SALES")
        Me.SqlDataAdapter2.Fill(Me.ds, "SALESITEMS")
        Me.ds.Relations.Add("REL1", Me.ds.Tables("SALES").Columns("SLS2"), Me.ds.Tables("SALESITEMS").Columns("SLS2"), True)
        Me.BS.DataSource = Me.ds
        Me.BS.DataMember = "SALES"
        Me.ds.EnforceConstraints = True
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"

        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()

        SEARCHDATA.SEARCHMAXIDSTOCKS()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        PurchSales_Check = True
        TestkeyAccounts(keyAccounts.GetValue("SalesAccount_No", SalesAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("SalesAccount_No", SalesAccount_No)
        End If

        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrordanLOd", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCustomerName, e, )
    End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
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
            Dim Sound As System.IO.Stream = My.Resources.save
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

    Private Sub Text6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTDiscount.KeyPress
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
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    Dim sql As New SqlClient.SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @QUANTITY WHERE STOCKSITEMS.SKITM4='" & Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand With {
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

    Private Sub TEXTTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTTotal.TextChanged
        On Error Resume Next
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub

    Private Sub MAXRECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As New SqlCommand("SELECT MAX(SALES.SLS1) FROM SALES  WHERE CUser='" & CUser & "'and Year(SALES.SLS3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        Dim noD As Object = Strings.Mid(CMD.ExecuteScalar(), 6)
        If IsDBNull(resualt) Then
            Me.TEXTID.Text = 1
        Else
            Me.TEXTID.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub



    Private Sub TEXTInvoiceNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTInvoiceNumber.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.ComboCustomerName.Focus()
        End If
    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCustomerName.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.TEXTPermissionNumber.Focus()
        End If
    End Sub

    Private Sub TEXT3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTPermissionNumber.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.DateMovementHistory.Focus()
        End If
    End Sub

    Private Sub DATETIMEPICKER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateMovementHistory.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.txtItem2.Focus()
        End If
    End Sub

    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Call MangUsers()
        On Error Resume Next
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
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
            TransforAccountsSalesCost_Check = True
        Else
            TransferToAccounts_Check = False
            TransforAccountsSalesCost_Check = False
        End If
        Me.TEXTInvoiceNumber.Enabled = True
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
    End Sub

    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
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
            SEARCHDATA.SumSTOCKS(Me.num.ToString, Me.cod.ToString)
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
            Me.DanLOd()
            nextRow = Me.DataGridView1.Rows(0)
            nextRow.Selected = True
            Me.DataGridView1.Rows(0).Selected = True
            Me.BS.Position = P + 1
            Me.SaveSALESITEMS()
            SaveStocks()
            UpdatStocks()



            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
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
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO SALES (SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31,WarehouseNumber, WarehouseName,  CB1, USERNAME, CUser, COUser, da, ne, TYPE_CASH, TYPE_CRDT, DELETED) VALUES     (@SLS1, @SLS2, @SLS3, @SLS4, @SLS5, @SLS6, @SLS7, @SLS8, @SLS9, @SLS10, @SLS11, @SLS12, @SLS13, @SLS14, @SLS15, @SLS16, @SLS17, @SLS19, @SLS20, @SLS21, @SLS22, @SLS23, @SLS24, @SLS25, @SLS26, @SLS27, @SLS28, @SLS29, @SLS30, @SLS31,@WarehouseNumber, @WarehouseName,  @CB1, @USERNAME, @CUser, @COUser,  @da, @ne, @TYPE_CASH, @TYPE_CRDT, @DELETED)", Consum)
            Dim CMD As New SqlClient.SqlCommand
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO SALESITEMS (SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, SITM8, SITM9, SITM10, SITM11, SLS2) VALUES     (@SITM2, @SITM3, @SITM4, @SITM5, @SITM6, @SITM7, @SITM8, @SITM9, @SITM10, @SITM11, @SLS2)", Consum)
        Dim CMD As New SqlClient.SqlCommand
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
            Dim SQL As New SqlClient.SqlCommand(" Update SALES SET  SLS2 = @SLS2, SLS3 = @SLS3, SLS4 = @SLS4, SLS5 = @SLS5, SLS6 = @SLS6, SLS7 = @SLS7, SLS8 = @SLS8, SLS9 = @SLS9, SLS10 = @SLS10, SLS11 = @SLS11, SLS12 = @SLS12, SLS13 = @SLS13, SLS14 = @SLS14, SLS15 = @SLS15, SLS16 = @SLS16,  SLS17 = @SLS17, SLS18 = @SLS18, SLS20 = @SLS20, SLS21 = @SLS21, SLS22 = @SLS22, SLS23 = @SLS23, SLS24 = @SLS24, SLS25 = @SLS25, SLS26 = @SLS26, SLS27 = @SLS27, SLS28 = @SLS28, SLS29 = @SLS29, SLS30 = @SLS30, SLS31 = @SLS31,WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  CB1 = @CB1, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, TYPE_CASH = @TYPE_CASH, TYPE_CRDT = @TYPE_CRDT WHERE  SLS2 = @SLS2", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
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

        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("Update SALESITEMS SET   SITM2 = @SITM2, SITM3 = @SITM3, SITM4 = @SITM4, SITM5 = @SITM5, SITM6 = @SITM6, SITM7 = @SITM7, SITM8 = @SITM8, SITM9 = @SITM9, SITM10 = @SITM10, SITM11 = @SITM11, SLS2 = @SLS2 WHERE   SITM1 = @SITM1", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
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

    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTInvoiceNumber.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub

    Private Sub TEXTInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTInvoiceNumber.LostFocus
        Static Dim P As Integer
        P = Me.BS.Position
        Me.DanLOd()
        Me.BS.Position = P
        'Me.Totalcount()
        Me.TEXTInvoiceNumber.Enabled = False
    End Sub

    Private Sub TEXTInvoiceNumber_GotFocus(sender As Object, e As EventArgs) Handles TEXTInvoiceNumber.GotFocus
        Me.TEXTInvoiceNumber.Enabled = True
        Me.SaveSALES()
    End Sub

    Private Sub SEARCHFIFOLIFOAvg()
        Dim Tax As Boolean
        Dim Tax1 As Boolean
        Dim Tax2 As String
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter()
        If FIFO = True Then
            Dim strsql1 As New SqlCommand("SELECT * FROM FIFOStocks WHERE STK25='" & Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value & "'", Consum)
            Adp1 = New SqlDataAdapter(strsql1)
            ds.Clear()
            ds = New DataSet
            Adp1.Fill(ds, "FIFOStocks")
        ElseIf LIFO = True Then
            Dim strsql2 As New SqlCommand("SELECT * FROM LIFOStock WHERE STK25='" & Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value & "'", Consum)
            Adp1 = New SqlDataAdapter(strsql2)
            ds.Clear()
            ds = New DataSet
            Adp1.Fill(ds, "LIFOStock")
        ElseIf AVG = True Then
            Dim strsql3 As New SqlCommand("SELECT * FROM AvgStocks WHERE STK25='" & Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value & "'", Consum)
            Adp1 = New SqlDataAdapter(strsql3)
            ds.Clear()
            ds = New DataSet
            Adp1.Fill(ds, "AvgStocks")
            Adp1.Dispose()
            Consum.Close()
        End If


        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextSTK8.Text = ds.Tables(0).Rows(0).Item("STK8")
            Tax2 = ds.Tables(0).Rows(0).Item("STK7")
            UnitPrice = ds.Tables(0).Rows(0).Item("STK15")
            Me.TexTSellingPrice.Text = ds.Tables(0).Rows(0).Item("STK19")
            Me.TextDiscountBay.Text = ds.Tables(0).Rows(0).Item("SKITM9")
            Me.TextHashUnit.Text = ds.Tables(0).Rows(0).Item("SKITM6")
            Me.TextOrderLimit.Text = ds.Tables(0).Rows(0).Item("SKITM11")
            Me.TextSalesTaxRate.Text = ds.Tables(0).Rows(0).Item("SKITM12")

            Me.TextDiscountPercentageWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM15")
            Me.TextLowestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM16")
            Me.TextHighestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM17")
            Me.TextSecondSellingPrice.Text = ds.Tables(0).Rows(0).Item("SKITM18")
            Me.TextThirdSalePrice.Text = ds.Tables(0).Rows(0).Item("SKITM19")
            Tax = ds.Tables(0).Rows(0).Item("SKITM20")
            Tax1 = ds.Tables(0).Rows(0).Item("SKITM21")
            Me.TEXTProductionDate.Text = ds.Tables(0).Rows(0).Item("IT_DATEP")
            Me.TEXTExpiryDate.Text = ds.Tables(0).Rows(0).Item("IT_DATEEX")
            Me.TEXTCurrentBalance.Text = ds.Tables(0).Rows(0).Item("LeftQty")
            Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax.ToString
            Me.CheckItemIsSubjectToSalesTax.Checked = Tax1.ToString
        Else
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    Consum = New SqlClient.SqlConnection(constring)
                    Dim strsql1 As New SqlClient.SqlCommand("SELECT SKITM3,SKITM4,SKITM5,SKITM6,SKITM8,SKITM9,SKITM11,SKITM12,SKITM14,SKITM15,SKITM16,SKITM17,SKITM18,SKITM19,SKITM20,SKITM21,SKITM22,SKITM23,SKITM24,SKITM25,SKITM26,IT_DATEP,IT_DATEEX FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4='" & DataGridView1.Item("SITM4", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                    ds.Clear()
                    ds = New DataSet
                    Adp1 = New SqlClient.SqlDataAdapter(strsql1)
                    Adp1.Fill(ds, "STOCKSITEMS")
                    If ds.Tables(0).Rows.Count > 0 Then
                        Tax2 = ds.Tables(0).Rows(0).Item("SKITM5")
                        Me.TextHashUnit.Text = ds.Tables(0).Rows(0).Item("SKITM6")
                        UnitPrice = ds.Tables(0).Rows(0).Item("SKITM8")
                        Me.TextDiscountBay.Text = ds.Tables(0).Rows(0).Item("SKITM9")
                        Me.TextOrderLimit.Text = ds.Tables(0).Rows(0).Item("SKITM11")
                        'Me.TextTotalPurchasePrice.Text = ds.Tables(0).Rows(0).Item("SKITM10")
                        Me.TextSalesTaxRate.Text = ds.Tables(0).Rows(0).Item("SKITM12")
                        Me.TexTSellingPrice.Text = ds.Tables(0).Rows(0).Item("SKITM14")
                        Me.TextDiscountPercentageWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM15")
                        Me.TextLowestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM16")
                        Me.TextHighestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM17")
                        Me.TextSecondSellingPrice.Text = ds.Tables(0).Rows(0).Item("SKITM18")
                        Me.TextThirdSalePrice.Text = ds.Tables(0).Rows(0).Item("SKITM19")
                        Tax = ds.Tables(0).Rows(0).Item("SKITM20")
                        Tax1 = ds.Tables(0).Rows(0).Item("SKITM21")
                        Me.TEXTProductionDate.Text = ds.Tables(0).Rows(0).Item("IT_DATEP")
                        Me.TEXTExpiryDate.Text = ds.Tables(0).Rows(0).Item("IT_DATEEX")
                        Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax.ToString
                        Me.CheckItemIsSubjectToSalesTax.Checked = Tax1.ToString
                    Else

                    End If

                Next

                Adp1.Dispose()
                Consum.Close()
            End If



            '    Me.TextHashUnit.Text = "0"
            '    Me.TextUnitPrice.Text = "0"
            '    Me.TextDiscountBay.Text = "0"
            '    Me.TextOrderLimit.Text = "0"
            '    Me.TextSalesTaxRate.Text = "0"
            '    'Me.TexTSellingPrice.Text = "0"
            '    'Me.TextSecondSellingPrice.Text = "0"
            '    Me.TextHighestDiscountRateWhenSelling.Text = "0"
            '    Me.CheckPricesMentionedIncludeSalesTax.Checked = False
            '    Me.CheckItemIsSubjectToSalesTax.Checked = False
        End If
        Me.TextUnitPrice.Text = Val(UnitPrice).ToString("0.000")
        Me.TextTotalPurchasePrice.Text = Format(Val(Me.TEXTCurrentBalance.Text) * Val(Me.TextUnitPrice.Text) * (100 - Val(Me.TextDiscountBay.Text)) / 100, "0.000")
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
        SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextMAXMOV8.Text = SEARCHDATA.STK1B
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust,cust22  FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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

    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
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

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Try
            TEXT4_TextChanged(sender, e)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try

    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        Dim total As Double = "0.00"
        Dim tota2 As Double = "0.00"
        Dim tota3 As Double = "0.00"
        Dim VA1 As Double = "0.00"
        Dim VS1 As Double = "0.00"
        Dim VS2 As Double = "0.00"
        Dim VS3 As Double = "0.00"

        Me.SEARCHFIFOLIFOAvg()
        VA1 = Format(Val(Me.DataGridView1.Item("SITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value), "0.000")
        VS1 = Format(Val(Me.DataGridView1.Item("SITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value), "0.000")
        VS2 = Format(Val(VS1) * Val(Me.DataGridView1.Item("SITM7", DataGridView1.CurrentRow.Index).Value) / 100, "0.000")
        VS3 = Format(Val(Me.DataGridView1.Item("SITM9", Me.DataGridView1.CurrentRow.Index).Value) * Val(Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value), "0.000")
        Me.TextSalesTaxRateA.Text = Format(Val(VA1) * Val(Me.TextSalesTaxRate.Text) / 100, "0.000")
        TextUnitPrice.Text = Val(UnitPrice).ToString("0.000")

        Me.DataGridView1.CurrentRow.Cells("SITM9").Value = Val(Me.TextUnitPrice.Text)
        Me.DataGridView1.CurrentRow.Cells("SITM10").Value = Me.DataGridView1.CurrentRow.Cells("SITM6").Value * Val(Me.TextUnitPrice.Text)
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            If Me.RadS.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM7").Value = Me.TextDiscountPercentageWhenSelling.Text
            ElseIf Me.RadS1.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM7").Value = Me.TextLowestDiscountRateWhenSelling.Text
            ElseIf Me.RadS2.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM7").Value = Me.TextHighestDiscountRateWhenSelling.Text
            End If

            If Me.RdRes.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM5").Value = Me.TexTSellingPrice.Text
                Me.DataGridView1.CurrentRow.Cells("SITM11").Value = Val(VS2)
            ElseIf Me.RdCus.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM5").Value = Me.TextSecondSellingPrice.Text
                Me.DataGridView1.CurrentRow.Cells("SITM11").Value = Val(VS2)
            ElseIf Me.Radio1.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM5").Value = Me.TextThirdSalePrice.Text
                Me.DataGridView1.CurrentRow.Cells("SITM11").Value = Val(VS2)
            End If

            If Me.CheckItemIsSubjectToSalesTax.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM8").Value = Val(Me.DataGridView1.CurrentRow.Cells("SITM5").Value * Me.DataGridView1.CurrentRow.Cells("SITM6").Value + Me.TextSalesTaxRateA.Text) - Val(VS2)
            ElseIf Me.CheckPricesMentionedIncludeSalesTax.Checked = True Then
                Me.DataGridView1.CurrentRow.Cells("SITM8").Value = Val(Me.DataGridView1.CurrentRow.Cells("SITM5").Value * Me.DataGridView1.CurrentRow.Cells("SITM6").Value) - Val(VS2)
            End If
            'tota1 += CDbl(r.Cells("SITM8").Value)
            tota2 += CDbl(r.Cells("SITM10").Value)
            tota3 += CDbl(r.Cells("SITM11").Value)
        Next
        tota2 = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("SITM10").Value).ToString("0.000"))
        Me.TextSITM11.Text = (From row In DataGridView1.Rows Select CDbl(row.Cells("SITM11").Value)).Sum()
        Me.Text_TotalUnitPrice.Text = tota2.ToString("0.000")
        'Me.Timsum1.Start()
        ''Me.TEXTItemsTotal.Text = Val(Me.TextSITM11.Text) + total.ToString("0.000")
        ''Me.TEXTDiscount.Text = tota3.ToString("0.000")
        Me.TEXTItemsTotal.Text = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("SITM8").Value).ToString("0.000")) + tota3.ToString("0.000")

        Me.TEXT4_TextChanged(sender, e)
    End Sub

    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        Me.SEARCHFIFOLIFOAvg()
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("SITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next
        'Me.SEARCHFIFOLIFOAvg()
        If Me.DataGridView1.SelectedRows.Count = 0 Then
            Me.DataGridView1.Item("SITM2", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If Me.DataGridView1.Item("SITM3", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM3", e.RowIndex).Value = Me.num.ToString
            If Me.DataGridView1.Item("SITM4", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("SITM4", e.RowIndex).Value = Me.cod.ToString
            'Exit Sub
        End If
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        Exit Sub
    End Sub


    Private Sub SaveStocks()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            GetAutoIDSTK()
            Dim SQL As String = "INSERT INTO STOCKS(  STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlClient.SqlCommand(SQL, Consum)
            CMD.Parameters.AddWithValue("@STK1", IDSTK)
            CMD.Parameters.AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
            CMD.Parameters.AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
            CMD.Parameters.AddWithValue("@STK3", Me.TEXTPermissionNumber.Text)
            CMD.Parameters.AddWithValue("@STK4", Me.DateMovementHistory.Value.ToString("yyyy-MM-dd"))
            CMD.Parameters.AddWithValue("@STK5", "صرف")
            CMD.Parameters.AddWithValue("@STK6", Me.TEXTInvoiceNumber.EditValue)
            CMD.Parameters.AddWithValue("@STK7", Me.DataGridView1.Item("SITM3", Me.DataGridView1.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK8", Me.TextSTK8.Text)
            CMD.Parameters.AddWithValue("@STK9", Me.TextHashUnit.Text)
            CMD.Parameters.AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000"))
            CMD.Parameters.AddWithValue("@STK11", 0)
            CMD.Parameters.AddWithValue("@STK12", DataGridView1.Item("SITM6", DataGridView1.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000") - Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value)
            CMD.Parameters.AddWithValue("@STK14", Me.TextOrderLimit.Text)
            CMD.Parameters.AddWithValue("@STK15", Me.TextUnitPrice.Text)
            CMD.Parameters.AddWithValue("@STK16", Me.TextMovementSymbol.EditValue)
            CMD.Parameters.AddWithValue("@STK17", Me.TextDiscountBay.Text)
            CMD.Parameters.AddWithValue("@STK18", Format(Val(Me.TextUnitPrice.Text) * Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000"))
            CMD.Parameters.AddWithValue("@STK19", Me.TexTSellingPrice.Text)
            CMD.Parameters.AddWithValue("@STK20", Format(Val(Me.DataGridView1.Item("SITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000"))
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
            CMD.Parameters.AddWithValue("@IT_DATEEX", TEXTExpiryDate.Text)
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
            Dim Consum As New SqlClient.SqlConnection(constring)
            GetAutoIDSTK()
            If DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    Dim SQL As New SqlClient.SqlCommand(" Update STOCKS SET WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK25 = @STK25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne  WHERE STK1 ='" & Me.TextSTK1A.Text & "'" & "AND STK25= '" & Me.DataGridView1.CurrentRow.Cells("SITM4").Value & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand(SQL.CommandText) With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                        .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                        .Parameters.Add("@STK7", SqlDbType.NVarChar).Value = Me.DataGridView1.Item("SITM3", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK8", SqlDbType.NVarChar).Value = Me.TextSTK8.Text
                        .Parameters.Add("@STK9", SqlDbType.NVarChar).Value = Me.TextHashUnit.Text
                        .Parameters.Add("@STK10", SqlDbType.Float).Value = Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000") + Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK11", SqlDbType.Float).Value = "0"
                        .Parameters.Add("@STK12", SqlDbType.Float).Value = Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK13", SqlDbType.Float).Value = Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000")
                        .Parameters.Add("@STK14", SqlDbType.NVarChar).Value = Me.TextOrderLimit.Text
                        .Parameters.Add("@STK15", SqlDbType.Float).Value = Me.TextUnitPrice.Text
                        .Parameters.Add("@STK17", SqlDbType.Float).Value = Me.TextDiscountBay.Text
                        .Parameters.Add("@STK18", SqlDbType.Float).Value = Format(Val(Me.TextUnitPrice.Text) * Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000")
                        .Parameters.Add("@STK19", SqlDbType.NVarChar).Value = Me.TexTSellingPrice.Text
                        .Parameters.Add("@STK20", SqlDbType.Float).Value = Format(Val(Me.DataGridView1.Item("SITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("SITM4").Value, IDSTK)), "0.000")
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



    Private Sub MAXIDCAB1()
        On Error Resume Next
        Dim N As Int64
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES   WHERE CUser='" & CUser & "'and  Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
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

    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
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

    Private Sub  AccountsEnquiry()
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

    Private Sub TEXT4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTItemsTotal.TextChanged, TEXTDiscountPercentage.EditValueChanged, TEXTTaxRate.EditValueChanged, TEXTSalesTaxes.EnabledChanged, TEXTDiscount.TextChanged, TEXTNetItems.TextChanged, TEXTSalesTaxes.TextChanged, TEXTTotalItemsWithTaxes.TextChanged, TextSITM11.TextChanged, TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged, TextDiscountBay.TextChanged
        On Error Resume Next
        Dim TotalDiscount As Double = Val(DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("SITM11").Value))).ToString("0.000")
        Dim ItemsTotal As Double = Val(DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("SITM8").Value))).ToString("0.000")

        Me.TEXTDiscount.Text = Val(TotalDiscount).ToString("0.000") + (Val(Me.TEXTItemsTotal.Text) * Val(Me.TEXTDiscountPercentage.EditValue / 100).ToString("0.000"))
        Me.TEXTItemsTotal.Text = Val(ItemsTotal + TotalDiscount).ToString("0.000")

        Me.TEXTNetItems.Text = Format(Val(Me.TEXTItemsTotal.Text) - Val(Me.TEXTDiscount.Text), "0.000")
        Me.TEXTSalesTaxes.Text = Format(Val(Me.TEXTItemsTotal.Text) * Val(Me.TEXTTaxRate.EditValue) / 100, "0.000")
        Me.TEXTTotalItemsWithTaxes.Text = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")
        Me.TextTotalDiscount.Text = Format(Val(Me.TEXTDiscount.Text) + Val(Me.TextSITM11.Text), "0.000")
        Me.TEXTTotal.Text = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text) + Val(Me.TEXTDiscount.Text), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
        ', TEXTDiscountPercentage.EditValueChanged
        ', TEXTSalesTaxes.EditValueChanged

        Me. AccountsEnquiry()
    End Sub

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

    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function GetGrdQuantities()
        Dim Tot As Double
        For Each row As DataGridViewRow In Me.DataGridView1.Rows
            If row.Cells("SITM4").Value = Me.cod.ToString Then
                Tot += Val(row.Cells("SITM6").Value)
            End If
            Me.TextTot.Text = Tot
        Next
        Return Tot
    End Function

    Private Sub TxtItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            SEARCHDATA.SumSTOCKS(Me.num.ToString, Me.cod.ToString)
            Me.TextItemBalance.Text = Conversion.Val(SEARCHDATA.sumSTK)
            If Conversion.Val(Me.txtq.Text) > Conversion.Val(Me.TextItemBalance.Text) Then
                Interaction.MsgBox("عفواً هذه الكمية أكبر من الموجود بالمخزن" & ChrW(13) & ChrW(10) & "رصيد الصنف يساوي" & ChrW(13) & ChrW(10) & Me.TextItemBalance.Text, MsgBoxStyle.MsgBoxRight Or MsgBoxStyle.Exclamation, Nothing)
                Me.txtq.Text = Me.TextItemBalance.Text
                Me.txtq.Focus()
            End If

            Me.txtq.Focus()

            Me.txtq.Text = 1
            Me.txtq.SelectAll()
        End If
    End Sub

    Private Sub TxtItem_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem2.TextChanged
        On Error Resume Next
        Dim Total As Double
        Dim item As Double
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim Adp1 As New SqlClient.SqlDataAdapter()
        Dim str As New SqlCommand("", Consum)
        If FIFO = True Then
            str = New SqlCommand("", Consum)
            If Trim(Me.txtItem2.Text) <> "" Then
                str.CommandText = "SELECT * FROM FIFOStocks WHERE CUser ='" & CUser & "'  and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' And STK25 Like'" & Trim(Me.txtItem2.Text) & "%'" & "or STK7 like'" & Trim(Me.txtItem2.Text) & "%'"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                ds = New DataSet
                dt = New DataTable
                Adp1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                Adp1.Fill(ds, "FIFOStocks")
                Adp1.Fill(dt)
                Me.cod = ""
                Me.num = ""
            End If
        ElseIf LIFO = True Then
            str = New SqlCommand("", Consum)
            If Trim(txtItem2.Text) <> "" Then
                str.CommandText = "SELECT * FROM  LIFOStock WHERE CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.txtItem2.Text) & "%'" & "or STK7 like'" & Trim(Me.txtItem2.Text) & "%'"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                ds = New DataSet
                dt = New DataTable
                Adp1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                Adp1.Fill(ds, "LIFOStock")
                Adp1.Fill(dt)
                Me.cod = ""
                Me.num = ""
            End If
        ElseIf AVG = True Then
            str = New SqlCommand("", Consum)
            If Trim(Me.txtItem2.Text) <> "" Then
                str.CommandText = "SELECT * FROM  AvgStocks WHERE  CUser ='" & CUser & "' and WarehouseNumber ='" & Trim(Me.ComboStore.Text) & "' and STK25 like'" & Trim(Me.txtItem2.Text) & "%'" & "or STK7 like'" & Trim(Me.txtItem2.Text) & "%'"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                ds = New DataSet
                dt = New DataTable
                Adp1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                Adp1.Fill(ds, "AvgStocks")
                Adp1.Fill(dt)
                Me.cod = ""
                Me.num = ""
            End If
        End If
        If DataGridView1.Rows.Count >= 2 Then
            DataGridView1.Rows(0).Selected = True
            DataGridView1.CurrentCell = DataGridView1("SITM2", DataGridView1.Rows(0).Index)
        End If
        If ds.Tables(0).Rows.Count > 0 Then
            Me.DataGridView2.DataSource = ds
            Me.DataGridView2.DataMember = "FIFOStocks"
            Me.cod = ds.Tables(0).Rows(0).Item("STK25")
            Me.num = ds.Tables(0).Rows(0).Item("STK7")
            Me.TextSTK8.Text = ds.Tables(0).Rows(0).Item("STK8")
            Tax2 = ds.Tables(0).Rows(0).Item(1)
            Me.TextOrderLimit.Text = ds.Tables(0).Rows(0).Item("SKITM11")
            Me.TextUnitPrice.Text = ds.Tables(0).Rows(0).Item("STK15")
            Me.TexTSellingPrice.Text = ds.Tables(0).Rows(0).Item(8)
            Me.TextDiscountBay.Text = ds.Tables(0).Rows(0).Item(9)
            Me.TextHashUnit.Text = ds.Tables(0).Rows(0).Item(10)
            Me.TextHighestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item(11)
            Me.TextSalesTaxRate.Text = ds.Tables(0).Rows(0).Item("SKITM12")

            Me.TextDiscountPercentageWhenSelling.Text = ds.Tables(0).Rows(0).Item(15)
            Me.TextLowestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item(16)
            Me.TextHighestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item(17)
            Tax = ds.Tables(0).Rows(0).Item(20)
            Tax1 = ds.Tables(0).Rows(0).Item(21)
            ChkPD = ds.Tables(0).Rows(0).Item("ChkPD")
            Me.TEXTProductionDate.Text = ds.Tables(0).Rows(0).Item(24)
            Me.TEXTExpiryDate.Text = ds.Tables(0).Rows(0).Item(25)
            Me.TEXTCurrentBalance.Text = ds.Tables(0).Rows(0).Item(29)
            Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax.ToString
            Me.CheckItemIsSubjectToSalesTax.Checked = Tax1.ToString
            'For i As Integer = 0 To DataGridView1.Rows.Count - 1
            '    If Me.DataGridView1.Rows(i).Cells("SITM4").Value = Me.cod.ToString Then
            '        Total += Val(Me.DataGridView1.Rows(i).Cells("SITM6").Value)
            '        item = Val(Me.DataGridView1.Rows(i).Cells("SITM6").Value)
            '    End If
            'Next

        Else
            Me.cod = ""
            Me.num = ""
            Me.TextHashUnit.Text = "0"
            'Me.TextUnitPrice.Text = "0"
            Me.TextUnitPrice.Text = Val(UnitPrice).ToString("0.000")
            Me.TextDiscountBay.Text = "0"
            Me.TextOrderLimit.Text = "0"
            Me.TextSalesTaxRate.Text = "0"
            Me.TexTSellingPrice.Text = "0"
            Me.TextSecondSellingPrice.Text = "0"
            Me.TextDiscountPercentageWhenSelling.Text = "0"
            Me.TextHighestDiscountRateWhenSelling.Text = "0"
            Me.CheckPricesMentionedIncludeSalesTax.Checked = False
            Me.CheckItemIsSubjectToSalesTax.Checked = False
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Exit Sub
        End If
        Consum.Close()
        Me.TextBcod.Text = Me.cod

        Call Dgv2()


        Me.TextItemBalanceAfterSaleA.Text = ""
        Me.TextItemBalanceAfterSale.Text = ""
        Me.TextBcod.Text = Me.cod
        Me.GetGrdQuantities()
        Me.TextItemBalance.Text = Format(Val(Me.TextItemBalance.Text) - Val(Me.TextTot.Text), "0.000")
        If Me.DataGridView2.Item(DataGridView2.CurrentCell.ColumnIndex, Me.DataGridView2.CurrentRow.Index).EditedFormattedValue <> Nothing Then
            Dim v As Integer = Me.DataGridView2.Item(0, Me.DataGridView2.CurrentRow.Index).EditedFormattedValue
            For Each row As DataGridViewRow In DataGridView2.Rows
                If row.Cells(Me.DataGridView2.CurrentCell.ColumnIndex).RowIndex <> Me.DataGridView2.CurrentRow.Index Then
                    If row.Cells(0).Value <> v Then
                        Me.TextNetItemsA.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) - Val(Total)
                        Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() = Val(Me.TextNetItemsA.Text)
                        '-----------------------------------------------
                    Else
                        If Me.TextNetItemsA.Text > 0 Then
                            Me.TextNetItemsA.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) - Val(Total)
                            Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() = Val(Me.TextNetItemsA.Text) '
                            '-----------------------------------------------
                        ElseIf Me.TextNetItemsA.Text <= 0 Then
                            Dim counter As Integer = Me.DataGridView2.CurrentRow.Index + 1
                            Dim nextRow As DataGridViewRow
                            If counter = Me.DataGridView2.RowCount Then
                                nextRow = Me.DataGridView2.Rows(0)
                            Else
                                nextRow = Me.DataGridView2.Rows(counter)
                                nextRow.Selected = True
                                Me.TextNetItemsSale.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) + Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value() - Val(Total)
                                Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value() = Val(Me.TextNetItemsSale.Text)
                                Me.TextNetItemsA.Text = 0
                                If Me.DataGridView2.SelectedRows.Count > 0 Then
                                    For i As Integer = Me.DataGridView2.SelectedRows.Count - 1 To 0
                                        Me.DataGridView2.Rows.RemoveAt(Me.DataGridView2.SelectedRows(i).Index - 1)
                                    Next
                                End If
                                '-----------------------------------------------
                                If Me.TextNetItemsSale.Text <= 0 Then
                                    nextRow = Me.DataGridView2.Rows(counter)
                                    nextRow.Selected = True
                                    Me.TextNetItemsSale.Text = 0
                                    Me.TextItemBalanceA.Text = Val(Me.TextItemBalance.Text) - Val(Me.TextTot.Text)
                                    Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value() = Val(Me.TextItemBalanceA.Text)
                                End If
                                Me.DataGridView2.CurrentCell = nextRow.Cells(1)
                                nextRow.Selected = True
                                Me.DataGridView2.Rows(counter).Selected = True
                            End If
                        End If
                    End If
                    Return
                End If
            Next
        End If

        Me.TextItemBalanceAfterSaleA.Text = 0
        Me.TextNetItemsAvailableSale.Text = 0
    End Sub
    Public rec As DataRow

    Private Sub Txtq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtq.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            If Me.txtq.Text = "" Or Me.txtq.Text = "0" Then
                MsgBox("كم عدد السلعة  ", MsgBoxStyle.Critical, "تنبيه")
                Exit Sub
            End If
            Dim firstDate As String, days As Integer
            Dim secondDate As Date
            firstDate = Me.TEXTExpiryDate.Text
            secondDate = CDate(firstDate)
            If ItemsExpirationDate = True Then
                If ChkPD = True Then
                    If ServerDateTime.ToString("yyyy-MM-dd") >= secondDate Then
                        MsgBox("إنتهاء صالحية السلعة  ", MsgBoxStyle.Critical, "تنبيه")
                        Exit Sub
                    End If
                End If

            End If

            'SEARCHMAXIDSTOCKS()
            Me.TEXTCurrentBalance.Text = Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.CurrentRow.Cells("SITM4").Value.ToString, MAXSTK1)), "0.000")
            SumSTOCKS(num.ToString, Me.cod.ToString)
            Me.TextItemBalance.Text = Val(sumSTK)
            If CDbl(Val(Me.txtq.Text)) > CDbl(Val(Me.TextItemBalance.Text)) Then
                MsgBox("لا يجب ان يكون العدد الفاتورة أكبر من رصيد المخزون ")
                Exit Sub
            End If
            Dim Tot As Double
            Dim item1 As Double
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                If Me.DataGridView1.Rows(i).Cells("SITM4").Value = Me.TextBcod.Text Then
                    Tot += Val(Me.DataGridView1.Rows(i).Cells("SITM6").Value)
                    item1 = Val(Me.DataGridView2.Item(19, Me.DataGridView2.CurrentRow.Index).Value())
                End If
            Next
            If Val(Val(Tot) + Val(Me.txtq.Text)) > Val(Me.TextItemBalance.Text) Then
                MsgBox("عفواً هذه الكميات أكبر من رصيد الصنف", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
                Me.txtItem2.Clear()
                Me.txtItem2.Focus()
                Exit Sub
            End If
            If Val(Me.txtq.Text) > Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() + Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value())) Then
                MsgBox("عفواً غير مسموح يوجد اكثر من سعرين في سجل واحد", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight)
                Me.txtq.Text = Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value() + Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index + 1).Value()))
                Me.txtq.Focus()
                Exit Sub
            End If

            'Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Selected = True
            'Me.DataGridView1.MultiSelect = False
            'Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            'Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Descending)
            'Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Ascending)
            'Me.TextBox26.Text = Strings.Format((((Conversion.Val(Me.TextBox6.Text) * Conversion.Val(Me.TextBox10.Text)) * (100 - Conversion.Val(Me.TextBox8.Text))) / 100), "0.000")
            'Me.TextBox27.Text = Strings.Format((((Conversion.Val(Me.TextBox25.Text) * Conversion.Val(Me.TextBox10.Text)) * (100 - Conversion.Val(Me.TextBox28.Text))) / 100), "0.000")

            If Val(Tot) + Val(Me.txtq.Text) <= Val(Me.TextItemBalance.Text) Then
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Selected = True
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Descending)
                Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Ascending)
                If Me.txtq.Text > Val(Me.DataGridView2.Item("LeftQty", Me.DataGridView2.CurrentRow.Index).Value()) Then
                    Me.TextNetItemsAvailableSale.Text = Val(Val(Me.txtq.Text) - Me.TextNetItemsA.Text)
                    Me.TextItemBalanceAfterSale.Text = Val(Me.TextNetItemsAvailableSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index + 1).Value()))
                    Me.TextItemBalanceAfterSaleA.Text = Val(Me.TextNetItemsAvailableSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
                End If
                If Me.txtq.Text > Val(Me.TextNetItemsSale.Text) Then
                    Me.TextNetItemsAfterSale.Text = Val(Val(Me.txtq.Text - Me.TextNetItemsSale.Text))
                    Me.TextItemBalanceAfterSale.Text = Val(Me.TextNetItemsAfterSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index + 1).Value()))
                    Me.TextItemBalanceAfterSaleA.Text = Val(Me.TextNetItemsAfterSale.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
                End If
                If Me.txtq.Text < Val(Me.TextItemBalanceA.Text) Then
                    Me.TextItemBalanceAfterSaleA.Text = 0
                    Me.TextItemBalanceAfterSale.Text = 0
                    Me.TextNetItemsAvailableSale.Text = 0
                    Me.TextNetItemsAfterSale.Text = 0
                Else
                    Me.TextNetItemsB.Text = Val(Me.txtq.Text - Val(Me.TextItemBalanceA.Text))
                    Me.TextItemBalanceAfterSale.Text = Val(Me.TextItemBalanceA.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
                    Me.TextItemBalanceAfterSaleA.Text = Val(Me.TextItemBalanceA.Text * Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()))
                End If
                Call Dgv1()
                Me.TextBcod.Text = ""
                Me.txtItem2.Text = ""
                Me.txtItem2.Focus()
                GetGrdQuantities()
            End If
        End If
    End Sub

    Private Sub Txtq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtq.TextChanged
        On Error Resume Next
        Me.GetGrdQuantities()
    End Sub



    Private Sub Dgv1()
        On Error Resume Next
        Me.DataGridView1.AllowUserToAddRows = True
        Static Dim P As Integer
        P = Me.BS.Position
        P = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 2).Index
        SendKeys.Send("{DOWN}")
        Dim v As Integer = Me.DataGridView2.Item(0, Me.DataGridView2.CurrentRow.Index).EditedFormattedValue
        Dim w1 As Double
        Dim w2 As Double
        Dim w3 As Double
        Dim wsum As Double
        '''''''''''''''''''''''''''''''''''''''
        Dim r1 As Double
        Dim r2 As Double
        Dim rsum As Double
        Dim rsum1 As Double
        Dim sum2 As Double
        Dim tota4 As Double
        Dim naem As String
        Dim cx As Double
        Dim w11 As Double
        Dim w12 As Double
        Dim w13 As Double
        Me.SEARCHFIFOLIFOAvg()
        '''''''''''''''''''''''''''''''''''''''
        Me.test = 1
        Me.test2 = 1
        ik = 0
        '''''''''''''''''''''''''''''''''''''''
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            If r.Cells("SITM4").Value = Me.cod Then
                Me.test = 0
            End If
        Next
        For Each itm As DataGridViewRow In Me.DataGridView2.Rows
            If itm.Cells("STK25").Value = Me.cod Then
                Me.test2 = 0
            End If
        Next
        '''''''''''''''''''''''''''''''''''''''
        w1 = Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value())
        w2 = Me.txtq.Text
        w3 = Val(Me.TextDiscountPercentageWhenSelling.Text) 'Val(TextBox28.Text)SKITM15
        wsum = Format(Val(w1) * Val(w2) - Val(Me.TextItemBalanceAfterSaleA.Text) + Val(Me.TextItemBalanceAfterSale.Text) * (100 - Val(w3)) / 100, "0.000")
        '''''''''''''''''''''''''''''''''''''''
        r1 = Me.txtq.Text
        r2 = Val(Me.DataGridView2.Item("SKITM15", Me.DataGridView2.CurrentRow.Index).Value())
        rsum = Format(Val(wsum) * Val(r2) / 100, "0.000")
        sum2 = Format(Val(wsum) - Val(rsum), "0.000")
        Dim num1 As Double = Me.DataGridView1.Item("SITM7", Me.DataGridView1.CurrentRow.Index).Value
        Dim num2 As Double = Me.DataGridView1.Item("SITM6", Me.DataGridView1.CurrentRow.Index).Value * Val(num1)
        Dim num3 As Double = Me.DataGridView1.Item("SITM9", Me.DataGridView1.CurrentRow.Index).Value
        Dim num4 As Double = Val(txtq.Text) * Val(TextUnitPrice.Text)

        If Me.test2 = 0 Then
            If Me.test = 0 Then
                For Each row1 As DataGridViewRow In Me.DataGridView1.Rows
                    If row1.Cells("SITM4").Value = Me.cod Then
                        w1 = Val(Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value())
                        w13 = Val(row1.Cells("SITM7").Value)
                        w11 = Val(row1.Cells("SITM8").Value)
                        w12 = Val(row1.Cells("SITM6").Value) * Val(w13)
                        '''''''''''''''''''''''''''''''''''''''
                        cx = Val(txtq.Text) + Val(row1.Cells("SITM6").Value)
                        wsum = Format((Val(w1) * Val(txtq.Text)) + Val(w11) - Val(Me.TextItemBalanceAfterSaleA.Text) + Val(Me.TextItemBalanceAfterSale.Text) * (100 - Val(w3)) / 100, "0.000")
                        '''''''''''''''''''''''''''''''''''''''
                        rsum1 = Format(Val(w12) + Val(rsum), "0.000")
                        sum2 = Format(Val(wsum) - Val(rsum), "0.000")
                        '''''''''''''''''''''''''''''''''''''''
                        row1.Cells("SITM6").Value = Val(cx)
                        row1.Cells("SITM8").Value = Val(sum2)
                        row1.Cells("SITM10").Value = Val(cx) * Val(TextUnitPrice.Text)
                    End If
                Next
            Else
                Me.DataGridView1.AutoGenerateColumns = False
                Me.DataGridView1.CurrentCell = Me.DataGridView1("SITM2", Me.DataGridView1.NewRowIndex)
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Selected = True
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Descending)
                Me.DataGridView1.Sort(Me.DataGridView1.Columns("SITM2"), System.ComponentModel.ListSortDirection.Ascending)

                Me.DataGridView1.Rows.Add()
                Me.DataGridView1.CurrentRow.Cells("SITM2").Value = Me.DataGridView1.CurrentRow.Index + 1
                Me.DataGridView1.CurrentRow.Cells("SITM3").Value = Me.num.ToString
                Me.DataGridView1.CurrentRow.Cells("SITM4").Value = Me.TextBcod.Text
                Me.DataGridView1.CurrentRow.Cells("SITM5").Value = Me.DataGridView2.Item(8, Me.DataGridView2.CurrentRow.Index).Value()
                Me.DataGridView1.CurrentRow.Cells("SITM6").Value = Me.txtq.Text
                Me.DataGridView1.CurrentRow.Cells("SITM7").Value = Me.TextDiscountPercentageWhenSelling.Text
                Me.DataGridView1.CurrentRow.Cells("SITM8").Value = Val(sum2)
                Me.DataGridView1.CurrentRow.Cells("SITM9").Value = Me.TextUnitPrice.Text
                Me.DataGridView1.CurrentRow.Cells("SITM10").Value = Val(txtq.Text) * Val(TextUnitPrice.Text)
            End If
            'If DataGridView1.Rows.Count <= 2 Then
            '    Me.DataGridView1.CurrentCell = DataGridView1("SITM2", DataGridView1.NewRowIndex)
            'End If

            Text_TotalUnitPrice.Text = DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("SITM10").Value).ToString("0.000"))
            Dim Sound As System.IO.Stream = My.Resources.BarCode
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)

        Else
            MsgBox("هذا الصنف غير موجود", MsgBoxStyle.Information, "تنبيه")
        End If
        'Me.Timsum1.Start()
    End Sub

    Private Sub Dgv2()
        On Error Resume Next
        Me.DataGridView2.Columns(0).Visible = False
        Me.DataGridView2.Columns(1).Visible = True
        Me.DataGridView2.Columns("STK4").Visible = False
        Me.DataGridView2.Columns(3).Visible = False
        Me.DataGridView2.Columns(4).Visible = False
        Me.DataGridView2.Columns(5).Visible = False
        Me.DataGridView2.Columns(6).Visible = False
        Me.DataGridView2.Columns(7).Visible = False
        Me.DataGridView2.Columns(8).Visible = True
        Me.DataGridView2.Columns(9).Visible = False
        Me.DataGridView2.Columns(10).Visible = False
        Me.DataGridView2.Columns(11).Visible = False
        Me.DataGridView2.Columns(12).Visible = False
        Me.DataGridView2.Columns(13).Visible = False
        Me.DataGridView2.Columns("value1").Visible = False
        Me.DataGridView2.Columns("value2").Visible = False
        Me.DataGridView2.Columns("SKITM12").Visible = False
        Me.DataGridView2.Columns("SKITM13").Visible = False
        Me.DataGridView2.Columns("SKITM14").Visible = False
        Me.DataGridView2.Columns("SKITM15").Visible = False
        Me.DataGridView2.Columns("SKITM16").Visible = False
        Me.DataGridView2.Columns("SKITM17").Visible = False
        Me.DataGridView2.Columns("SKITM18").Visible = False
        Me.DataGridView2.Columns("SKITM19").Visible = False
        Me.DataGridView2.Columns("SKITM20").Visible = False
        Me.DataGridView2.Columns("SKITM21").Visible = False
        Me.DataGridView2.Columns("SKITM22").Visible = False
        Me.DataGridView2.Columns("SKITM23").Visible = False
        Me.DataGridView2.Columns("value").Visible = False
        Me.DataGridView2.Columns("WarehouseNumber").Visible = False
        Me.DataGridView2.Columns("WarehouseName").Visible = False
        Me.DataGridView2.Columns("SoldUpToNow").Visible = False
        Me.DataGridView2.Columns("TotalProduced").Visible = False
        Me.DataGridView2.Columns("LeftQty").Visible = True
        Me.DataGridView2.Columns("ChkPD").Visible = False
        Me.DataGridView2.Columns("IT_DATEP").Visible = False
        Me.DataGridView2.Columns("IT_DATEEX").Visible = False
        Me.DataGridView2.Columns("USERNAME").Visible = False
        Me.DataGridView2.Columns("CUser").Visible = False
        Me.DataGridView2.Columns("COUser").Visible = False

        Me.DataGridView2.Columns(1).Width = 165
        Me.DataGridView2.Columns("LeftQty").Width = 60
        Me.DataGridView2.Columns(8).Width = 60
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Me.DataGridView2.Columns(1).HeaderText = "أسم الصنف"
        Me.DataGridView2.Columns("LeftQty").HeaderText = "الرصيد"
        Me.DataGridView2.Columns(8).HeaderText = "السعر"
        ''''
        Me.DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView2.MultiSelect = False
        With Me.DataGridView2
            .RowsDefaultCellStyle.BackColor = Color.Beige
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        End With
        ''''''''''''''''''''
    End Sub

    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Me.DataGridView1.CurrentRow.Cells("SITM3").Value = Me.num.ToString
        Me.DataGridView1.CurrentRow.Cells("SITM4").Value = Me.cod.ToString
    End Sub



    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
        If Me.Ch1.Checked = True Then
            Me.DataGridView1.Focus()
            Me.Timsum.Start()
        ElseIf Me.Ch1.Checked = False Then
            Me.txtq.Focus()
            Me.Timsum.Stop()
        End If
    End Sub

    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timsum.Tick
        On Error Resume Next
        If Me.Ch1.Checked = True Then

            If Me.TEXTTotal.Text > 0 Then
                Dim s1 As Double = Me.TextFundValue.EditValue + Me.TextValueOfCheck.EditValue
                Dim s2 As Double = Me.TEXTTotal.Text
                Dim s3 As Double = Me.TEXTDiscount.Text
                Dim suming As Double
                suming = s1 - s2 + s3
                Me.TextItemBalanceAfterSaleA.Text = suming.ToString("0.00")
            End If
            If Me.TextItemBalanceAfterSaleA.Text.Contains("-") Then
                Me.TextItemBalanceAfterSaleA.Text = "0"
            End If
            If Me.TEXTTotal.Text = "0" Then
                Me.TextItemBalanceAfterSaleA.Text = "0"
            End If
            If Me.TextFundValue.EditValue + Me.TextValueOfCheck.EditValue = "0" Or Me.TextFundValue.EditValue + Me.TextValueOfCheck.EditValue = "" Then
                Me.TextItemBalanceAfterSaleA.Text = "0"
            End If
            If Me.DataGridView1.Rows.Count = 0 Then

            Else
                Dim counter As Integer = Me.DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = Me.DataGridView1.RowCount Then
                    nextRow = Me.DataGridView1.Rows(0)
                    Me.Ch1.Checked = False
                    Me.txtq.Focus()
                    Me.Timsum.Stop()
                    If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                        TransferToAccounts_Check = True
                        TransforAccountsSalesCost_Check = True
                        TransforAccounts()
                        TransforAccountsSalesCost()
                    Else
                        TransferToAccounts_Check = False
                        TransforAccountsSalesCost_Check = False
                    End If
                Else
                    nextRow = Me.DataGridView1.Rows(counter)
                    nextRow.Selected = True
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
                End If
                Me.DataGridView1.CurrentCell = nextRow.Cells("SITM2")
                nextRow.Selected = True
                Me.DataGridView1.Rows(counter).Selected = True
            End If
        End If
    End Sub



    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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