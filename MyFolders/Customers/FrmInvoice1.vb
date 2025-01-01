Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Public Class FrmInvoice1
    Inherits Form
    Dim BAD As Boolean = False
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
    ReadOnly ds1 As New DataSet

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim _Type1 As String
    Dim TypeCustomer As String
    Dim NO As String
    Dim NO1 As Integer = 0
    Dim ITEMNAME_CHK As Boolean = False

    Private Sub FrmInvoice_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmInvoice_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    Me.SAVEBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmInvoice1_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
    End Sub
    Private Sub FrmInvoice1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

        TestkeyAccounts(keyAccounts.GetValue("TransferAccount_No", TransferAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("TransferAccount_No", TransferAccount_No)
        End If
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO29, PTRO30, PTRO31, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, CUser, COUser, da, ne, da1, ne1 FROM Invoice  WHERE   PTRO1='" & Me.TEXTInvoiceNumber.EditValue & "'ORDER BY PTRO1"
        End With
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT  CSDT, PTRO1, CSDT1, CSDT2, CSDT3, CSDT4, CSDT5, CSDT6, CSDT7, CSDT8 FROM InvoiceDetails ORDER BY PTRO1"
        End With
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
        Me.ds1.Clear()
        Consum.Open()
        Me.SqlDataAdapter1.Fill(Me.ds1, "Invoice")
        Me.SqlDataAdapter2.Fill(Me.ds1, "InvoiceDetails")
        Me.ds1.Relations.Add("REL5", Me.ds1.Tables("Invoice").Columns("PTRO1"), Me.ds1.Tables("InvoiceDetails").Columns("PTRO1"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "Invoice"

        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL5"
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        Me.ComboStore.SelectedIndex = 0
        FILLCOMBOBOX1("Invoice", "PTRO9", "CUser", CUser, Me.TEXTADDRESS)
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        LoadData()

        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.ComboCustomerName.Focus()
        Me.FundBalance()
        Call MangUsers()
        TestkeyAccounts(keyAccounts.GetValue("TransferAccount_No", TransferAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("TransferAccount_No", TransferAccount_No)
        End If
    End Sub
    Private Shared Sub LoadData()
        'Dim Consum As New SqlClient.SqlConnection(constring)
        'Using cmd As New SqlClient.SqlCommand("Select STK7  from STOCKS  WHERE CUser ='" & CUser & "'AND WarehouseNumber='" & ComboStore.Text & " '", Consum)
        '    Consum.Open()
        '    Using dreader As SqlClient.SqlDataReader = cmd.ExecuteReader
        '        ItemName.Clear()
        '        ItemName.Load(dreader)
        '        Me.CSDT7.Items.Clear()
        '        For i As Integer = 0 To ItemName.Rows.Count - 1
        '            Me.CSDT7.Items.Add(ItemName(i)(0))
        '        Next
        '    End Using
        'End Using
        'Consum.Close()
        'CSDT7.Items.Clear()

        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    CSDT7.Items.Add(DataGridView1.Rows(i).Cells("CSDT7").Value)
        'Next
    End Sub
    Private Sub DataGridView1_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DataGridView1.EditingControlShowing
        'If DataGridView1.CurrentCell.ColumnIndex = 1 Then
        If TypeOf e.Control Is DataGridViewComboBoxEditingControl Then
            'Dim comb As DataGridViewComboBoxEditingControl = TryCast(e.Control, DataGridViewComboBoxEditingControl)
            CType(e.Control, ComboBox).DropDownStyle = ComboBoxStyle.DropDown
            CType(e.Control, ComboBox).AutoCompleteSource = AutoCompleteSource.ListItems
            CType(e.Control, ComboBox).AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        End If

        'End If

    End Sub

    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCustomerName, e, )
    End Sub
    Private Sub ComboBox16_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub AddType1()
        On Error Resume Next
        If RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
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
                DelRow = True
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
            Dim Sound As IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
    Private Sub SAVERECORD()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO Invoice(PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31,WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@PTRO1, @PTRO2, @PTRO3, @PTRO4, @PTRO5, @PTRO6, @PTRO7, @PTRO8, @PTRO9, @PTRO10, @PTRO11, @PTRO12, @PTRO13, @PTRO14, @PTRO15, @PTRO16, @PTRO17, @PTRO18, @PTRO19, @PTRO20, @PTRO21, @PTRO22, @PTRO23, @PTRO24, @PTRO25, @PTRO26, @PTRO27, @PTRO28, @PTRO29, @PTRO30, @PTRO31,@WarehouseNumber, @WarehouseName, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@PTRO1", SqlDbType.BigInt).Value = Val(Me.TEXTInvoiceNumber.EditValue)
            .Parameters.Add("@PTRO2", SqlDbType.Int).Value = Val(Me.TEXTCarNumbers.EditValue)
            .Parameters.Add("@PTRO3", SqlDbType.NVarChar).Value = Val(Me.TEXTQuantity.EditValue)
            .Parameters.Add("@PTRO4", SqlDbType.NVarChar).Value = Me.TEXTLetteringQuantity.Text
            .Parameters.Add("@PTRO5", SqlDbType.DateTime).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@PTRO6", SqlDbType.NVarChar).Value = Val(Me.TEXTDiscountValue.EditValue)
            .Parameters.Add("@PTRO7", SqlDbType.NVarChar).Value = Val(Me.TEXTTotalValue.Text)
            .Parameters.Add("@PTRO8", SqlDbType.NVarChar).Value = Val(Me.TEXTTaxRate.Text)
            .Parameters.Add("@PTRO9", SqlDbType.NVarChar).Value = Me.TEXTADDRESS.Text
            .Parameters.Add("@PTRO10", SqlDbType.NVarChar).Value = Me.TEXTExpenseType.Text
            .Parameters.Add("@PTRO11", SqlDbType.NVarChar).Value = Val(Me.TEXTNetValue.Text)
            .Parameters.Add("@PTRO12", SqlDbType.NVarChar).Value = Val(Me.TEXTExpensesValue.EditValue)
            .Parameters.Add("@PTRO13", SqlDbType.NVarChar).Value = Val(Me.TEXTTransfers.EditValue)
            .Parameters.Add("@PTRO14", SqlDbType.NVarChar).Value = Val(Me.TEXTTotal.Text)
            .Parameters.Add("@PTRO17", SqlDbType.NVarChar).Value = "فاتورة نقل مفصلة"
            .Parameters.Add("@PTRO18", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
            .Parameters.Add("@PTRO15", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO16", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO19", SqlDbType.NVarChar).Value = Val(Me.TextTaxes.EditValue)
            .Parameters.Add("@PTRO20", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
            .Parameters.Add("@PTRO21", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
            .Parameters.Add("@PTRO22", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO23", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@PTRO24", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO25", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
            .Parameters.Add("@PTRO26", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
            .Parameters.Add("@PTRO27", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
            .Parameters.Add("@PTRO28", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
            .Parameters.Add("@PTRO29", SqlDbType.Date).Value = Me.CheckDate.Value.ToString

            .Parameters.Add("@PTRO30", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
            .Parameters.Add("@PTRO31", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

            .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
            .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

            .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
            .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
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
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source)
        'End Try
        Consum.Close()

    End Sub
    Private Sub SaveInvoiceDetails()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As String = "INSERT INTO InvoiceDetails (CSDT1, CSDT2, CSDT3, CSDT4, CSDT5, CSDT6, CSDT7, CSDT8, PTRO1) VALUES     (@CSDT1, @CSDT2, @CSDT3, @CSDT4, @CSDT5, @CSDT6, @CSDT7, @CSDT8, @PTRO1)"
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@PTRO1", SqlDbType.BigInt, 8, "PTRO1").Value = Me.TEXTInvoiceNumber.EditValue
            .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1")
            .Parameters.Add("@CSDT2", SqlDbType.Date, 8, "CSDT2")
            .Parameters.Add("@CSDT3", SqlDbType.Float, 8, "CSDT3")
            .Parameters.Add("@CSDT4", SqlDbType.Float, 8, "CSDT4")
            .Parameters.Add("@CSDT5", SqlDbType.Float, 8, "CSDT5")
            .Parameters.Add("@CSDT7", SqlDbType.NVarChar, 255, "CSDT7")
            .Parameters.Add("@CSDT6", SqlDbType.Float, 4, "CSDT6")
            .Parameters.Add("@CSDT8", SqlDbType.NVarChar, 255, "CSDT8")
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table1", "InvoiceDetails", New DataColumnMapping() {New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CSDT4", "CSDT4"), New DataColumnMapping("CSDT5", "CSDT5"), New DataColumnMapping("CSDT6", "CSDT6"), New DataColumnMapping("CSDT7", "CSDT7"), New DataColumnMapping("CSDT8", "CSDT8"), New DataColumnMapping("PTRO1", "PTRO1"), New DataColumnMapping("CSDT", "CSDT")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds1, "InvoiceDetails")
        Consum.Close()
    End Sub
    Private Sub UPDATERECORD()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand(" Update Invoice SET  PTRO2 = @PTRO2, PTRO3 = @PTRO3, PTRO4 = @PTRO4, PTRO5 = @PTRO5, PTRO6 = @PTRO6, PTRO7 = @PTRO7, PTRO8 = @PTRO8, PTRO9 = @PTRO9, PTRO10 = @PTRO10, PTRO11 = @PTRO11, PTRO12 = @PTRO12, PTRO13 = @PTRO13, PTRO14 = @PTRO14, PTRO15 = @PTRO15, PTRO16 = @PTRO16, PTRO17 = @PTRO17, PTRO18 = @PTRO18, PTRO19 = @PTRO19, PTRO20 = @PTRO20, PTRO21 = @PTRO21, PTRO22 = @PTRO22, PTRO23 = @PTRO23, PTRO24 = @PTRO24, PTRO25 = @PTRO25, PTRO26 = @PTRO26, PTRO27 = @PTRO27, PTRO28 = @PTRO28, PTRO29 = @PTRO29, PTRO30 = @PTRO30, PTRO31 = @PTRO31, WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, CUser = @CUser, da = @da, ne = @ne, COUser = @COUser, da1 = @da1, ne1 = @ne1 WHERE PTRO1 = @PTRO1", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@PTRO1", SqlDbType.BigInt).Value = Val(Me.TEXTInvoiceNumber.EditValue)
            .Parameters.Add("@PTRO2", SqlDbType.Int).Value = Val(Me.TEXTCarNumbers.EditValue)
            .Parameters.Add("@PTRO3", SqlDbType.NVarChar).Value = Val(Me.TEXTQuantity.EditValue)
            .Parameters.Add("@PTRO4", SqlDbType.NVarChar).Value = Me.TEXTLetteringQuantity.Text
            .Parameters.Add("@PTRO5", SqlDbType.DateTime).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@PTRO6", SqlDbType.NVarChar).Value = Val(Me.TEXTDiscountValue.EditValue)
            .Parameters.Add("@PTRO7", SqlDbType.NVarChar).Value = Val(Me.TEXTTotalValue.Text)
            .Parameters.Add("@PTRO8", SqlDbType.NVarChar).Value = Val(Me.TEXTTaxRate.Text)
            .Parameters.Add("@PTRO9", SqlDbType.NVarChar).Value = Me.TEXTADDRESS.Text.Trim
            .Parameters.Add("@PTRO10", SqlDbType.NVarChar).Value = Me.TEXTExpenseType.Text
            .Parameters.Add("@PTRO11", SqlDbType.NVarChar).Value = Val(Me.TEXTNetValue.Text)
            .Parameters.Add("@PTRO12", SqlDbType.NVarChar).Value = Val(Me.TEXTExpensesValue.EditValue)
            .Parameters.Add("@PTRO13", SqlDbType.NVarChar).Value = Val(Me.TEXTTransfers.EditValue)
            .Parameters.Add("@PTRO14", SqlDbType.NVarChar).Value = Val(Me.TEXTTotal.Text)
            .Parameters.Add("@PTRO17", SqlDbType.NVarChar).Value = "فاتورة نقل مفصلة"
            .Parameters.Add("@PTRO18", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
            .Parameters.Add("@PTRO15", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
            .Parameters.Add("@PTRO16", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO19", SqlDbType.NVarChar).Value = Val(Me.TextTaxes.EditValue)
            .Parameters.Add("@PTRO20", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
            .Parameters.Add("@PTRO21", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
            .Parameters.Add("@PTRO22", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO23", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@PTRO24", SqlDbType.Bit).Value = False
            .Parameters.Add("@PTRO25", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
            .Parameters.Add("@PTRO26", SqlDbType.Money).Value = Me.TextFundValue.EditValue
            .Parameters.Add("@PTRO27", SqlDbType.Money).Value = Me.TextValueOfCheck.EditValue
            .Parameters.Add("@PTRO28", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
            .Parameters.Add("@PTRO29", SqlDbType.Date).Value = Me.CheckDate.Value.ToString

            .Parameters.Add("@PTRO30", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
            .Parameters.Add("@PTRO31", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

            .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
            .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

            .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
            .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
            .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
            .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
            .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub UPDATEInvoiceDetails()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As String = "Update InvoiceDetails SET  CSDT1 = @CSDT1, CSDT2 = @CSDT2, CSDT3 = @CSDT3, CSDT4 = @CSDT4, CSDT5 = @CSDT5, CSDT6 = @CSDT6, CSDT7 = @CSDT7, CSDT8 = @CSDT8, PTRO1 = @PTRO1 WHERE  CSDT = @CSDT"
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
            .Parameters.Add("@PTRO1", SqlDbType.BigInt, 8, "PTRO1").Value = Me.TEXTInvoiceNumber.EditValue
            .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1")
            .Parameters.Add("@CSDT2", SqlDbType.Date, 8, "CSDT2")
            .Parameters.Add("@CSDT3", SqlDbType.Float, 8, "CSDT3")
            .Parameters.Add("@CSDT4", SqlDbType.Float, 8, "CSDT4")
            .Parameters.Add("@CSDT5", SqlDbType.Float, 8, "CSDT5")
            .Parameters.Add("@CSDT7", SqlDbType.NVarChar, 255, "CSDT7")
            .Parameters.Add("@CSDT6", SqlDbType.Float, 4, "CSDT6")
            .Parameters.Add("@CSDT8", SqlDbType.NVarChar, 255, "CSDT8")
            .CommandText = SQL
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table2", "InvoiceDetails", New DataColumnMapping() {New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CSDT4", "CSDT4"), New DataColumnMapping("CSDT5", "CSDT5"), New DataColumnMapping("CSDT6", "CSDT6"), New DataColumnMapping("CSDT7", "CSDT7"), New DataColumnMapping("CSDT8", "CSDT8"), New DataColumnMapping("PTRO1", "PTRO1"), New DataColumnMapping("CSDT", "CSDT")})})
        SqlDataAdapter2.UpdateCommand = CMD
        SqlDataAdapter2.Update(ds1, "InvoiceDetails")
        Consum.Close() '
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub MAXRECORD1()
        On Error Resume Next
        Dim Year As String
        Dim V As Int64
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(Invoice.PTRO1) FROM Invoice   WHERE CUser='" & CUser & "'and Year(PTRO5) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        Dim noD As Object = Strings.Mid(Val(CMD.ExecuteScalar()), 7)
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
                NO = ""
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        If IsDBNull(resualt) Then
            Me.TEXTInvoiceNumber.EditValue = CType(NO1, Integer) & 1
        Else
            V = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            Me.TEXTInvoiceNumber.EditValue = V
        End If
        Consum.Close()
    End Sub
    Private Sub FundBalance()
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
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        Call MangUsers()
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Me.TEXTInvoiceNumber.Enabled = True
        Dim n As Double
        Dim s As Double
        n = Me.BS.Count
        Me.BS.Position = Me.BS.Count - 1
        s = Val(Me.TEXTInvoiceNumber.EditValue)
        On Error Resume Next
        Me.BS.EndEdit()
        Me.BS.AddNew()
        CLEARDATA1(Me)
        Me.TEXTInvoiceNumber.Enabled = True
        Me.FundBalance()
        If n = 0 Then
            Me.TEXTInvoiceNumber.EditValue = 1
        Else
            If n >= s Then
                Me.TEXTInvoiceNumber.EditValue = Val(n) + 1
            Else
                Me.TEXTInvoiceNumber.EditValue = Val(s) + 1
            End If
        End If
        Me.MAXRECORD1()
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        Me.ComboStore.SelectedIndex = 0
        LoadData()

        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.TextMovementSymbol.EditValue = "TL" & Me.TEXTInvoiceNumber.EditValue
        Me.TEXTQuantity.EditValue = 0
        Me.TEXTCarNumbers.EditValue = 0
        Me.TEXTTotalValue.Text = 0
        Me.TEXTNetValue.Text = 0
        Me.TEXTExpensesValue.EditValue = 0
        Me.TEXTTransfers.EditValue = 0
        Me.TEXTDiscountValue.EditValue = 0
        Me.TextTaxes.EditValue = 0
        Me.TEXTTaxRate.Text = 0
        Me.TextFundValue.EditValue = 0
        Me.TextValueOfCheck.EditValue = 0
        Me.TextTaxes.EditValue = Val(2 / 100)
        Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.TEXTADDRESS.Text = ""
        Me.ComboCustomerName.SelectedIndex = 0
        Me.TEXTExpenseType.Text = "مصاريف تحميل"
        Me.DataGridView1.Rows.Clear()
        Me.TEXTInvoiceNumber.Focus()
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Val(TEXTTotal.Text) <> (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue)) Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            Dim ch As Double
            Dim ch1 As Double
            ch = Convert.ToDouble(Me.TEXTTotal.Text)
            ch1 = Convert.ToDouble(Me.TextFundBalance.Text)
            If Convert.ToDouble(ch) > Convert.ToDouble(ch1) Then
                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboPaymentMethod.Text = "شيك" Then
                If Me.ComboBN2.Text = "" Then
                    MsgBox("يجب إدخال رقم حساب الشيك", 16, "تنبيه")
                    Me.ComboBN2.Focus()
                    Exit Sub
                End If
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
            ElseIf Me.ComboPaymentMethod.Text = "شيك و نقدا" Then
                If Me.ComboBN2.Text = "" Then
                    MsgBox("يجب إدخال رقم حساب الشيك", 16, "تنبيه")
                    Me.ComboBN2.Focus()
                    Exit Sub
                End If
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
            End If

            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOptions.ShowDialog()
                Exit Sub
            End If


            If Me.BAD = True Then
                Me.ADDBUTTON.Enabled = False
                Me.SAVEBUTTON.Enabled = True
                Me.BAD = False
            Else
                Me.ADDBUTTON.Enabled = True
                Me.SAVEBUTTON.Enabled = True
            End If
            Static Dim P As Integer
            P = Me.BS.Position
            Me.DataGridView1_CurrentCellChanged(sender, e)
            Me.TEXTTotalN.Text = CurrencyJO(TEXTTotal.Text, "jO")
            Me.UPDATERECORD()
            Me.UPDATEInvoiceDetails()
            Me.SAVERECORD()
            Me.SaveInvoiceDetails()
            Me.DanLOd()
            Me.BS.Position = P
            Me.DataGridView1_CurrentCellChanged(sender, e)
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATERECORD()
            Me.UPDATEInvoiceDetails()
            Me.SAVERECORD()
            Me.SaveInvoiceDetails()
            Me.Cursor = Cursors.WaitCursor
            PictureBox2.Visible = True
            BS.EndEdit()
            RowCount = BS.Count

            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
                TransforAccounts()
            Else
                TransferToAccounts_Check = False
            End If

            SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            SaveTab.RunWorkerAsync()
            BS.Position = P
            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub TEXTBOX5_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateMovementHistory.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.ComboCustomerName.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX15_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DataGridView1.Focus()
        End Select
    End Sub
    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DataGridView1.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTExpenseType.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX10_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTExpenseType.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTExpensesValue.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTTransfers.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX13_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTDiscountValue.Focus()
        End Select
    End Sub
    Private Sub TEXTCarNumbers_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTCarNumbers.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTExpensesValue_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTExpensesValue.DoubleClick
        On Error Resume Next
        Me.TEXTExpensesValue.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX3_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTTotalN.TextChanged, TEXTExpensesValue.EditValueChanged, TEXTTransfers.EditValueChanged, TEXTQuantity.EditValueChanged, TEXTNetValue.TextChanged, TEXTDiscountValue.EditValueChanged, TextTaxes.EditValueChanged
        On Error Resume Next
        Me.TEXTTaxRate.Text = Format(Val(Me.TEXTTotalValue.Text) * Val(Me.TextTaxes.EditValue) / 100, "0.000")
        Me.TEXTNetValue.Text = Format(Val(Me.TEXTTotalValue.Text) - Val(Me.TEXTTaxRate.Text), "0.000")
        Me.TEXTTotal.Text = Format(Val(Me.TEXTNetValue.Text) + Val(Me.TEXTExpensesValue.EditValue) + Val(Me.TEXTTransfers.EditValue - Val(Me.TEXTDiscountValue.EditValue)), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        'Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
        If TEXTQuantity.Text <> "" And Len(Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value) > 0 Then Me.TEXTLetteringQuantity.Text = AmountWord(Me.TEXTQuantity.Text) & " " & Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value

    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust,cust7,cust22  FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.TEXTADDRESS.Text = ds.Tables(0).Rows(0).Item(1)
            TypeCustomer = ds.Tables(0).Rows(0).Item(2)
        Else
            Me.TextCustomerNumber.EditValue = ""
            Me.TEXTADDRESS.Text = ""
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
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next
        If Me.DataGridView1.SelectedRows.Count = 0 Then
            Me.DataGridView1.Item("CSDT1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If Me.DataGridView1.Item(3, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(3, e.RowIndex).Value = MaxDate.ToString("yyyy-MM-dd")
            If Me.DataGridView1.Item(8, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(8, e.RowIndex).Value = "PVC Resin"
            If Me.DataGridView1.Item(9, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(9, e.RowIndex).Value = "طن"
            If Me.DataGridView1.Item(4, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(4, e.RowIndex).Value = 25
            If Me.DataGridView1.Item(5, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(5, e.RowIndex).Value = 1
            If Me.DataGridView1.Item(7, e.RowIndex).Value Is DBNull.Value Then
                Me.DataGridView1.CurrentRow.Cells(7).Value = Val(Me.DataGridView1.CurrentRow.Cells(5).Value * Me.DataGridView1.CurrentRow.Cells(6).Value)
            End If

        Else
            Exit Sub
        End If
        If Me.DataGridView1.CurrentCell.ColumnIndex = 7 Or Me.DataGridView1.CurrentCell.ColumnIndex = 5 Or Me.DataGridView1.CurrentCell.ColumnIndex = 6 Then
            Me.DataGridView1.CurrentRow.Cells(7).Value = Val(Me.DataGridView1.CurrentRow.Cells(5).Value * Me.DataGridView1.CurrentRow.Cells(6).Value)
        End If
    End Sub
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.GotFocus, DataGridView1.CurrentCellChanged, DataGridView1.CellValueChanged, DataGridView1.CellEndEdit
        On Error Resume Next
        Me.TEXTQuantity.EditValue = 0
        Me.TEXTCarNumbers.EditValue = 0
        Me.TEXTTotalValue.Text = 0
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            Me.TEXTQuantity.EditValue += Val(r.Cells(4).Value)
            Me.TEXTCarNumbers.EditValue += Val(r.Cells(5).Value)
            Me.TEXTTotalValue.Text += Val(r.Cells(7).Value)
            Me.DataGridView1.CurrentRow.Cells(7).Value = Val(Me.DataGridView1.CurrentRow.Cells(5).Value * Me.DataGridView1.CurrentRow.Cells(6).Value)
        Next
        Me.TEXTBOX3_TextChanged(sender, e)
    End Sub
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        If e.Context = DataGridViewDataErrorContexts.Commit Or e.Context = DataGridViewDataErrorContexts.ClipboardContent Or e.Context = DataGridViewDataErrorContexts.CurrentCellChange Or e.Context = DataGridViewDataErrorContexts.Display Or e.Context = DataGridViewDataErrorContexts.Formatting Or e.Context = DataGridViewDataErrorContexts.RowDeletion Or e.Context = DataGridViewDataErrorContexts.Scroll Or e.Context = DataGridViewDataErrorContexts.PreferredSize Or e.Context = DataGridViewDataErrorContexts.LeaveControl Or e.Context = DataGridViewDataErrorContexts.InitialValueRestoration Then
            Resume Next
        End If
    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT STK9 FROM STOCKS WHERE STK7 = '" & Me.DataGridView1.CurrentRow.Cells("CSDT7").Value & " '", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        'If Me.DataGridView1.CurrentCell.ColumnIndex = 2 Then
        If ds.Tables(0).Rows.Count > 0 Then
            Me.DataGridView1.CurrentRow.Cells("CSDT8").Value = ds.Tables(0).Rows(0).Item(0)
        End If
        'End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub TEXTBOX1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTInvoiceNumber.LostFocus
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.SAVERECORD()
        Me.DanLOd()
        Me.BS.Position = P

        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
    End Sub
    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me. AccountsEnquiry()
    End Sub




    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = " فاتورة نقل رقم" & " " & Me.TEXTInvoiceNumber.EditValue
        nem1 = "صرف فاتورة نقل رقم" & " " & Me.TEXTInvoiceNumber.EditValue
        nem2 = " فاتورة نقل بيموجب مستند رقم" & " " & Me.TextCheckNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True

        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قيد", "TL", TextMovementSymbol.EditValue, False)
        If OBCHK6 = True Then
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "شيك"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                              TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)


            End Select

        End If

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
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextValueOfCheck.EditValue = 0
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            Case "شيك"
                Me.TextFundValue.EditValue = 0
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "نقدا_شيك"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
        End Select
    End Sub
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                    TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                    Me._Type1 = ds.Tables(0).Rows(0).Item(2)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    Me._Type1 = ""
                    TypeCustomer = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf RadioSUPPLIER.Checked = True Then
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
            ElseIf RadioEMPLOYEES.Checked = True Then
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
        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)

    End Sub
    Private Sub ComboITEMNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboITEMNAME.SelectedIndexChanged


        If ITEMNAME_CHK = True Then
            Me.DataGridView1.CurrentCell = Me.DataGridView1("CSDT1", Me.DataGridView1.NewRowIndex)
            Me.DataGridView1.CurrentRow.Cells("CSDT7").Value = ComboITEMNAME.Text
        End If

        ITEMNAME_CHK = False
    End Sub
    Private Sub ComboITEMNAME_GotFocus(sender As Object, e As EventArgs) Handles ComboITEMNAME.GotFocus
        ITEMNAME_CHK = True
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
         AccountsEnquiry()
        FundBalance()
    End Sub

    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
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

End Class