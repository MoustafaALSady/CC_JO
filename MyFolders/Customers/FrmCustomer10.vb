Option Explicit Off
Imports System.Data.Common

Imports System.Data.SqlClient

Public Class FrmCustomer10
    Public WithEvents BS As New BindingSource

    ReadOnly T As Boolean = True, F As Boolean = False
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
    Dim SqlDataAdapter3 As New SqlDataAdapter
    Dim SqlDataAdapter4 As New SqlDataAdapter
    ReadOnly ds1 As New DataSet

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()


    Dim Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim BAD As Boolean = False
    Dim fprint As Boolean = True
    Private ReadOnly account_noF As String
    Private ReadOnly ACCF As String
    Private ReadOnly account_nameF As String
    Dim nem, nem1, nem2 As String
    Dim _Type1 As String
    Dim TypeCustomer As String
    ReadOnly NO As String
    ReadOnly NO1 As Integer = 0
    ReadOnly NO2 As Integer = 0

    Private Sub FrmCUSTOMER11_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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
    Private Sub FrmCUSTOMER10_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        'Me.TabPage1.Show()
        'Me.TabPage2.Show()
    End Sub
    Private Sub FrmCUSTOMER10_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        On Error Resume Next
        Me.Show()
    End Sub
    Private Sub FrmCUSTOMER10_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.ButtonXP4.Enabled = False
        Me.CMDBROWSE.Enabled = False

        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

        TestkeyAccounts(keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No)
        End If

    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("SELECT   CEMP1, CEMP2, CEMP3, CEMP4, CEMP5, CEMP6, CEMP7, CEMP8, CEMP9, CEMP10, CEMP11, CEMP12, CEMP13, CEMP14, CEMP15, CEMP16, CEMP17, CEMP18, CEMP19, CEMP20, CEMP21, CEMP22, CEMP23, CEMP24, CEMP25, CEMP26, CEMP27, CEMP28, CEMP29, CEMP30, CEMP31, CEMP32, CEMP33, CEMP34, CB1, BN2, USERNAME, CUser, COUser, da, ne, da1, ne1 FROM CABLESCOEMPLOYEES  WHERE   CEMP3='" & Me.TEXTCertificateNumber.EditValue & "'ORDER BY CEMP3", Consum)
        Dim str2 As New SqlCommand("SELECT   CCUST, CEMP3, CCUST1, CCUST2, CCUST3, CCUST4, CCUST5 FROM CABLESCO ORDER BY CCUST1 ", Consum)
        Dim str3 As New SqlCommand("SELECT   CEMP, CEMP1, CEMP2, CEMP3, CEMP4 FROM CABLESEMPLOYEES ORDER BY CEMP1 ", Consum)
        Dim str4 As New SqlCommand("SELECT   DOC1, LO, DOC2, DOC4, DOC5 FROM MYDOCUMENTSHOME", Consum)






        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
        Me.SqlDataAdapter3 = New SqlDataAdapter(str3)
        Me.SqlDataAdapter4 = New SqlDataAdapter(str4)
        Me.ds1.Clear()
        Consum.Open()
        Me.SqlDataAdapter1.Fill(Me.ds1, "CABLESCOEMPLOYEES")
        Me.SqlDataAdapter2.Fill(Me.ds1, "CABLESCO")
        Me.SqlDataAdapter3.Fill(Me.ds1, "CABLESEMPLOYEES")
        Me.SqlDataAdapter4.Fill(Me.ds1, "MYDOCUMENTSHOME")
        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("CABLESCOEMPLOYEES").Columns("CEMP3"), Me.ds1.Tables("CABLESCO").Columns("CEMP3"), True)
        Me.ds1.Relations.Add("REL2", Me.ds1.Tables("CABLESCOEMPLOYEES").Columns("CEMP3"), Me.ds1.Tables("CABLESEMPLOYEES").Columns("CEMP3"), True)
        Me.ds1.Relations.Add("REL3", Me.ds1.Tables("CABLESCOEMPLOYEES").Columns("CEMP31"), Me.ds1.Tables("MYDOCUMENTSHOME").Columns("LO"), True)

        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "CABLESCOEMPLOYEES"
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.DataGridView2.DataSource = Me.BS
        Me.DataGridView2.DataMember = "REL2"

        Me.TEXTSearch.DataSource = Me.BS
        Me.TEXTSearch.DisplayMember = "CEMP3"

        Me.DataGridView3.DataSource = Me.BS
        Me.DataGridView3.DataMember = "REL3"
        Me.DataGridView3.Columns("DOC3").Visible = False
        Me.DataGridView3.Columns("DOC6").Visible = False
        Me.DataGridView3.Columns("DOC7").Visible = False
        Me.DataGridView3.Columns("DOC8").Visible = False
        Me.DataGridView3.Columns("date_1").Visible = False
        Me.DataGridView3.Columns("USERNAME").Visible = False
        Me.DataGridView3.Columns("CUser").Visible = False
        Me.DataGridView3.Columns("COUser").Visible = False
        Me.DataGridView3.Columns("DA").Visible = False
        Me.DataGridView3.Columns("NE").Visible = False
        Me.DataGridView3.Columns("DA1").Visible = False
        Me.DataGridView3.Columns("NE1").Visible = False

        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Me.SqlDataAdapter3.Dispose()
        Me.SqlDataAdapter4.Dispose()
        Consum.Close()

        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)


        FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.TEXTSupplier)
        FILLCOMBOBOX1("CABLESCOEMPLOYEES", "CEMP16", "CUser", CUser, Me.TEXTInvoiceValueN)
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        FILLCOMBOBOXDISTINCT("CABLESCOEMPLOYEES", "CEMP5", "CEMP1", "CUser", CUser, Me.ComboSearch)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        TestkeyAccounts(keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No)
        End If
        'Me.ComboSearch.SelectedIndex = Me.TEXTSearch.SelectedIndex
        Me.FundBalance()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboCustomerName, e, )
    End Sub
    Private Sub TEXTBOX10_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.TEXTSupplier, e, )
    End Sub
    Private Sub TEXTBOX5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboITEMNAME, e, )
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
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                PictureBox2False()
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


    Private Sub MAXRECORD11()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(CABLESCOEMPLOYEES.CEMP1) FROM CABLESCOEMPLOYEES  WHERE CUser='" & CUser & "'and Year(CEMP2) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        Dim CMD As New SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        If IsDBNull(resualt) Then
            Me.TEXTID.Text = 1
        Else
            Me.TEXTID.Text = CType(resualt, Integer) + 1
        End If
        Consum.Close()
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.ButtonXP4.Enabled = LockUpdate
        Me.CMDBROWSE.Enabled = True
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
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
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub

    Private Sub SaveCABLESCOEMPLOYEES()
        'On Error Resume Next
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("INSERT INTO CABLESCOEMPLOYEES (  CEMP1, CEMP2, CEMP3, CEMP4, CEMP5, CEMP6, CEMP7, CEMP8, CEMP9, CEMP10, CEMP11, CEMP12, CEMP13, CEMP14, CEMP15, CEMP16, CEMP17, CEMP18, CEMP19, CEMP20, CEMP21, CEMP22, CEMP23, CEMP24, CEMP25, CEMP26, CEMP27, CEMP28, CEMP29, CEMP30, CEMP31, CEMP32, CEMP33, CEMP34, CEMP35, CEMP36, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (  @CEMP1, @CEMP2, @CEMP3, @CEMP4, @CEMP5, @CEMP6, @CEMP7, @CEMP8, @CEMP9, @CEMP10, @CEMP11, @CEMP12, @CEMP13, @CEMP14, @CEMP15, @CEMP16, @CEMP17, @CEMP18, @CEMP19, @CEMP20, @CEMP21, @CEMP22, @CEMP23, @CEMP24, @CEMP25, @CEMP26, @CEMP27, @CEMP28, @CEMP29, @CEMP30, @CEMP31, @CEMP32, @CEMP33, @CEMP34, @CEMP35, @CEMP36, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CEMP1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@CEMP2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CEMP3", SqlDbType.BigInt).Value = Me.TEXTCertificateNumber.EditValue
                .Parameters.Add("@CEMP4", SqlDbType.NVarChar).Value = Me.CreditTransferNumber.Text
                .Parameters.Add("@CEMP5", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text
                .Parameters.Add("@CEMP6", SqlDbType.NVarChar).Value = Me.TEXTLetteringQuantity.Text
                .Parameters.Add("@CEMP7", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                .Parameters.Add("@CEMP8", SqlDbType.NVarChar).Value = Me.TEXTInvoiceValue.Text
                .Parameters.Add("@CEMP9", SqlDbType.NVarChar).Value = Me.TEXTPolicyNumber.Text
                .Parameters.Add("@CEMP10", SqlDbType.NVarChar).Value = Me.TEXTSupplier.Text
                .Parameters.Add("@CEMP11", SqlDbType.Date).Value = Me.DateArrival.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CEMP12", SqlDbType.Date).Value = Me.DateExchange.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CEMP13", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CEMP14", SqlDbType.NVarChar).Value = Me.TEXTPaymentMonth.Text
                .Parameters.Add("@CEMP15", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CEMP16", SqlDbType.NVarChar).Value = Me.TEXTInvoiceValueN.Text
                .Parameters.Add("@CEMP17", SqlDbType.NVarChar).Value = Me.TEXTTotalTips.Text
                .Parameters.Add("@CEMP18", SqlDbType.NVarChar).Value = Me.TEXTTotalClearance.Text
                .Parameters.Add("@CEMP19", SqlDbType.NVarChar).Value = Me.TEXTTotalTipsN.Text
                .Parameters.Add("@CEMP20", SqlDbType.NVarChar).Value = Me.TEXTTotalClearanceN.Text
                .Parameters.Add("@CEMP21", SqlDbType.Bit).Value = False
                .Parameters.Add("@CEMP22", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CEMP23", SqlDbType.NVarChar).Value = Me.TEXTcash.EditValue
                .Parameters.Add("@CEMP24", SqlDbType.NVarChar).Value = "مصاريف مشتريات"
                .Parameters.Add("@CEMP25", SqlDbType.NVarChar).Value = Me.CertificateNumbe.Text
                .Parameters.Add("@CEMP26", SqlDbType.NVarChar).Value = Me.TextQuantity.Text
                .Parameters.Add("@CEMP27", SqlDbType.NVarChar).Value = Me.ComboType.Text
                .Parameters.Add("@CEMP28", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@CEMP29", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.Text
                .Parameters.Add("@CEMP31", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CEMP32", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CEMP33", SqlDbType.Date).Value = Me.CheckDate.Value
                .Parameters.Add("@CEMP30", SqlDbType.Bit).Value = False
                .Parameters.Add("@CEMP34", SqlDbType.Bit).Value = False
                .Parameters.Add("@CEMP35", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CEMP36", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

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
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveCABLESCOEMPLOYEES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SaveCABLESCO()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO CABLESCO (CCUST1, CCUST2, CCUST3, CCUST4, CCUST5, CEMP3) VALUES     (@CCUST1, @CCUST2, @CCUST3, @CCUST4, @CCUST5, @CEMP3)", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CCUST", SqlDbType.Int, 4, "CCUST")
            .Parameters.Add("@CCUST1", SqlDbType.Int, 4, "CCUST1")
            .Parameters.Add("@CCUST2", SqlDbType.Float, 8, "CCUST2")
            .Parameters.Add("@CCUST3", SqlDbType.NVarChar, 255, "CCUST3")
            .Parameters.Add("@CCUST4", SqlDbType.NVarChar, 255, "CCUST4")
            .Parameters.Add("@CCUST5", SqlDbType.Bit, 1, "CCUST5")
            .Parameters.Add("@CEMP3", SqlDbType.BigInt, 8, "CEMP3")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "CABLESCO", New DataColumnMapping() {New DataColumnMapping("CCUST1", "CCUST1"), New DataColumnMapping("CCUST2", "CCUST2"), New DataColumnMapping("CCUST3", "CCUST3"), New DataColumnMapping("CCUST4", "CCUST4"), New DataColumnMapping("CCUST5", "CCUST5"), New DataColumnMapping("CEMP3", "CEMP3"), New DataColumnMapping("CCUST", "CCUST")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds1, "CABLESCO")
        Consum.Close()
    End Sub

    Private Sub SaveCABLESEMPLOYEES()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO CABLESEMPLOYEES (CEMP1, CEMP2, CEMP3, CEMP4) VALUES     (@CEMP1, @CEMP2, @CEMP3, @CEMP4)", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CEMP", SqlDbType.Int, 4, "CEMP")
            .Parameters.Add("@CEMP1", SqlDbType.Int, 4, "CEMP1")
            .Parameters.Add("@CEMP2", SqlDbType.Money, 8, "CEMP2")
            .Parameters.Add("@CEMP3", SqlDbType.BigInt, 8, "CEMP3")
            .Parameters.Add("@CEMP4", SqlDbType.NVarChar, 255, "CEMP4")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter3.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "CABLESEMPLOYEES", New DataColumnMapping() {New DataColumnMapping("CEMP1", "CEMP1"), New DataColumnMapping("CEMP2", "CEMP2"), New DataColumnMapping("CEMP3", "CEMP3"), New DataColumnMapping("CEMP4", "CEMP4"), New DataColumnMapping("CEMP", "CEMP")})})
        SqlDataAdapter3.InsertCommand = CMD
        SqlDataAdapter3.Update(ds1, "CABLESEMPLOYEES")
        Consum.Close()
    End Sub

    Private Sub UPDATECABLESCOEMPLOYEES()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update CABLESCOEMPLOYEES SET CEMP2 = @CEMP2, CEMP3 = @CEMP3, CEMP4 = @CEMP4, CEMP5 = @CEMP5, CEMP6 = @CEMP6, CEMP7 = @CEMP7, CEMP8 = @CEMP8, CEMP9 = @CEMP9, CEMP10 = @CEMP10, CEMP11 = @CEMP11, CEMP12 = @CEMP12, CEMP13 = @CEMP13, CEMP14 = @CEMP14, CEMP15 = @CEMP15, CEMP16 = @CEMP16, CEMP17 = @CEMP17, CEMP18 = @CEMP18, CEMP19 = @CEMP19, CEMP20 = @CEMP20, CEMP21 = @CEMP21, CEMP22 = @CEMP22, CEMP23 = @CEMP23, CEMP24 = @CEMP24, CEMP25 = @CEMP25, CEMP26 = @CEMP26, CEMP27 = @CEMP27, CEMP28 = @CEMP28, CEMP29 = @CEMP29, CEMP30 = @CEMP30, CEMP31 = @CEMP31, CEMP32 = @CEMP32, CEMP33 = @CEMP33, CEMP34 = @CEMP34, CEMP35 = @CEMP35, CEMP36 = @CEMP36, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE  CEMP3 = @CEMP3", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CEMP1", SqlDbType.Int).Value = Me.TEXTID.Text.Trim
                .Parameters.Add("@CEMP2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CEMP3", SqlDbType.BigInt).Value = Me.TEXTCertificateNumber.EditValue
                .Parameters.Add("@CEMP4", SqlDbType.NVarChar).Value = Me.CreditTransferNumber.Text.Trim
                .Parameters.Add("@CEMP5", SqlDbType.NVarChar).Value = Me.ComboITEMNAME.Text.Trim
                .Parameters.Add("@CEMP6", SqlDbType.NVarChar).Value = Me.TEXTLetteringQuantity.Text.Trim
                .Parameters.Add("@CEMP7", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text.Trim
                .Parameters.Add("@CEMP8", SqlDbType.NVarChar).Value = Me.TEXTInvoiceValue.Text.Trim
                .Parameters.Add("@CEMP9", SqlDbType.NVarChar).Value = Me.TEXTPolicyNumber.Text.Trim
                .Parameters.Add("@CEMP10", SqlDbType.NVarChar).Value = Me.TEXTSupplier.Text.Trim
                .Parameters.Add("@CEMP11", SqlDbType.Date).Value = Me.DateArrival.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CEMP12", SqlDbType.Date).Value = Me.DateExchange.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CEMP13", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text.ToString.Trim
                .Parameters.Add("@CEMP14", SqlDbType.NVarChar).Value = Me.TEXTPaymentMonth.Text.Trim
                .Parameters.Add("@CEMP15", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CEMP16", SqlDbType.NVarChar).Value = Me.TEXTInvoiceValueN.Text.Trim
                .Parameters.Add("@CEMP17", SqlDbType.NVarChar).Value = Me.TEXTTotalTips.Text.Trim
                .Parameters.Add("@CEMP18", SqlDbType.NVarChar).Value = Me.TEXTTotalClearance.Text.Trim
                .Parameters.Add("@CEMP19", SqlDbType.NVarChar).Value = Me.TEXTTotalTipsN.Text.Trim
                .Parameters.Add("@CEMP20", SqlDbType.NVarChar).Value = Me.TEXTTotalClearanceN.Text.Trim
                .Parameters.Add("@CEMP21", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@CEMP22", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CEMP23", SqlDbType.NVarChar).Value = Me.TEXTcash.EditValue
                .Parameters.Add("@CEMP24", SqlDbType.NVarChar).Value = "مصاريف مشتريات"
                .Parameters.Add("@CEMP25", SqlDbType.NVarChar).Value = Me.CertificateNumbe.Text.Trim
                .Parameters.Add("@CEMP26", SqlDbType.NVarChar).Value = Me.TextQuantity.Text.Trim
                .Parameters.Add("@CEMP27", SqlDbType.NVarChar).Value = Me.ComboType.Text.Trim
                .Parameters.Add("@CEMP28", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text.Trim
                .Parameters.Add("@CEMP29", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.Text.Trim
                .Parameters.Add("@CEMP31", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CEMP32", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@CEMP33", SqlDbType.Date).Value = Me.CheckDate.Value
                .Parameters.Add("@CEMP30", SqlDbType.Bit).Value = False
                .Parameters.Add("@CEMP34", SqlDbType.Bit).Value = False
                .Parameters.Add("@CEMP35", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CEMP36", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
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
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Consum.Close()
    End Sub

    Private Sub UPDATECABLESCO()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update CABLESCO SET  CCUST1 = @CCUST1, CCUST2 = @CCUST2, CCUST3 = @CCUST3, CCUST4 = @CCUST4, CCUST5 = @CCUST5, CEMP3 = @CEMP3 WHERE  CCUST = @CCUST", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CCUST", SqlDbType.Int, 4, "CCUST")
            .Parameters.Add("@CCUST1", SqlDbType.Int, 4, "CCUST1")
            .Parameters.Add("@CCUST2", SqlDbType.Float, 8, "CCUST2")
            .Parameters.Add("@CCUST3", SqlDbType.NVarChar, 255, "CCUST3")
            .Parameters.Add("@CCUST4", SqlDbType.NVarChar, 255, "CCUST4")
            .Parameters.Add("@CCUST5", SqlDbType.Bit, 1, "CCUST5")
            .Parameters.Add("@CEMP3", SqlDbType.BigInt, 8, "CEMP3")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "CABLESCO", New DataColumnMapping() {New DataColumnMapping("CCUST1", "CCUST1"), New DataColumnMapping("CCUST2", "CCUST2"), New DataColumnMapping("CCUST3", "CCUST3"), New DataColumnMapping("CCUST4", "CCUST4"), New DataColumnMapping("CCUST5", "CCUST5"), New DataColumnMapping("CEMP3", "CEMP3"), New DataColumnMapping("CCUST", "CCUST")})})
        SqlDataAdapter2.UpdateCommand = CMD
        SqlDataAdapter2.Update(ds1, "CABLESCO")
        Consum.Close()
    End Sub

    Private Sub UPDATECABLESEMPLOYEES()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update CABLESEMPLOYEES SET   CEMP1 = @CEMP1, CEMP2 = @CEMP2, CEMP3 = @CEMP3, CEMP4 = @CEMP4 WHERE  CEMP = @CEMP", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CEMP", SqlDbType.Int, 4, "CEMP")
            .Parameters.Add("@CEMP1", SqlDbType.Int, 4, "CEMP1")
            .Parameters.Add("@CEMP2", SqlDbType.Money, 8, "CEMP2")
            .Parameters.Add("@CEMP3", SqlDbType.BigInt, 8, "CEMP3")
            .Parameters.Add("@CEMP4", SqlDbType.NVarChar, 255, "CEMP4")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter3.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "CABLESEMPLOYEES", New DataColumnMapping() {New DataColumnMapping("CEMP1", "CEMP1"), New DataColumnMapping("CEMP2", "CEMP2"), New DataColumnMapping("CEMP3", "CEMP3"), New DataColumnMapping("CEMP4", "CEMP4"), New DataColumnMapping("CEMP", "CEMP")})})
        SqlDataAdapter3.UpdateCommand = CMD
        SqlDataAdapter3.Update(ds1, "CABLESEMPLOYEES")
        Consum.Close()
    End Sub



    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = "م . تخليص مشتريات" & "_" & Me.CertificateNumbe.Text
        nem1 = "صرف نقدي م . مشتريات رقم" & "_" & Me.CertificateNumbe.Text
        nem2 = "م . تخليص مشتريات بيموجب مستند رقم " & "_" & Me.TextCheckNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True

        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotalTips.Text, TEXTTotalTips.Text, T3, "قيد", "ER", TextMovementSymbol.EditValue, False)
        If OBCHK6 = True Then
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TEXTTotalTips.Text, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TEXTTotalTips.Text, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.Text & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "شيك"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextValueOfCheck.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                              TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextValueOfCheck.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.Text & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

            End Select
        End If

    End Sub

    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                TextFundValue.EditValue = Val(TEXTTotalTips.Text)
                TextValueOfCheck.EditValue = 0
            Case "شيك"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text)
            Case "نقدا_شيك"
                TextFundValue.EditValue = Val(TEXTTotalTips.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text) - Val(TextFundValue.EditValue)
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
                TextFundValue.EditValue = Val(TEXTTotalTips.Text)
                TextValueOfCheck.EditValue = 0
            Case "شيك"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text)
            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotalTips.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub

    Private Sub BUTTON1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTON1.Click
        On Error Resume Next
        Me.fprint = True
        Me.DataGridView1.Visible = True
        Me.DataGridView2.Visible = False
        Me.TEXTTotalTips.Visible = True
        Me.TEXTTotalClearance.Visible = False
        Me.TEXTTotalTipsN.Visible = True
        Me.TEXTTotalClearanceN.Visible = False
        Me.Label17.Visible = False
        Me.Label18.Visible = True
    End Sub

    Private Sub BUTTON2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTON2.Click
        On Error Resume Next
        fprint = False
        Me.DataGridView1.Visible = False
        Me.DataGridView2.Visible = True
        Me.TEXTTotalTips.Visible = False
        Me.TEXTTotalClearance.Visible = True
        Me.TEXTTotalTipsN.Visible = False
        Me.TEXTTotalClearanceN.Visible = True
        Me.Label18.Visible = False
        Me.Label17.Visible = True
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

        Me.BAD = True
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        'Me.BUTTON1.Enabled = False
        'Me.BUTTON2.Enabled = False
        'Me.CMDBROWSE.Enabled = False
        'Me.ButtonInsertData.Enabled = False
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        Me.FundBalance()
        Me.BS.Position = Me.BS.Count - 1

        Me.BS.EndEdit()
        Me.BS.AddNew()
        CLEARDATA1(Me)
        Me.MAXRECORD11()
        GetAutoNumber("CEMP3", "CABLESCOEMPLOYEES", "CEMP2")
        Me.TEXTCertificateNumber.EditValue = AutoNumber

        Me.TextMovementSymbol.EditValue = "ER" & Me.TEXTCertificateNumber.EditValue
        Me.TEXTTotalTips.Text = 0
        Me.TEXTTotalClearance.Text = 0
        Me.TextFundValue.EditValue = 0
        Me.TEXTInvoiceValue.Text = 0
        Me.TextQuantity.Text = 0
        Me.TextValueOfCheck.EditValue = 0
        Me.TEXTcash.EditValue = 0
        Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.DateArrival.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.DateExchange.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.TEXTInvoiceValueN.Text = "دولار امريكى"
        Me.CertificateNumbe.Text = "الافراج المسبق"
        'Me.DataGridView1.CurrentRow.Cells.Clear()
        'Me.DataGridView2.CurrentRow.Cells.Clear()
        Me.CreditTransferNumber.Focus()
        TestkeyAccounts(keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No)
        End If
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
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
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Val(Me.TEXTTotalTips.Text) <> (Val(Me.TextValueOfCheck.EditValue) + Val(Me.TEXTcash.EditValue)) Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            Dim ch As Double
            Dim ch1 As Double
            ch = Me.TextFundValue.EditValue
            ch1 = Me.TextFundBalance.Text
            If ch1 < ch Then
                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
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
            End If

            If Me.BAD = True Then
                Me.ADDBUTTON.Enabled = True
                Me.SAVEBUTTON.Enabled = True
                Me.BUTTON1.Enabled = True
                Me.BUTTON2.Enabled = True
                Me.CMDBROWSE.Enabled = True
                Me.ButtonInsertData.Enabled = True
                'BAD = False
            End If
            'GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            'If ExitSub_Check = True Then
            '    frmOPTIONS.ShowDialog()
            '    Exit Sub
            'End If
            Static Dim P As Integer
            P = Me.BS.Position
            Me.TEXTTotalTipsN.Text = CurrencyJO(TEXTTotalTips.Text, "jO")
            Me.TEXTTotalClearanceN.Text = CurrencyJO(TEXTTotalClearance.Text, "jO")
            Me.UPDATECABLESCOEMPLOYEES()
            Me.UPDATECABLESCO()
            Me.UPDATECABLESEMPLOYEES()
            Me.SaveCABLESCO()
            Me.SaveCABLESEMPLOYEES()
            Me.DanLOd()
            Me.BS.Position = P
            Me.TEXTTotalTipsN.Text = CurrencyJO(TEXTTotalTips.Text, "jO")
            Me.TEXTTotalClearanceN.Text = CurrencyJO(TEXTTotalClearance.Text, "jO")
            Me.UPDATECABLESCOEMPLOYEES()
            Me.UPDATECABLESCO()
            Me.UPDATECABLESEMPLOYEES()
            Me.SaveCABLESCO()
            Me.SaveCABLESEMPLOYEES()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
                TransforAccounts()
            Else
                TransferToAccounts_Check = False
            End If

            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P
            Insert_Actions(Me.TEXTID.Text.Trim, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TEXTBOX13_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me. AccountsEnquiry()
    End Sub
    Private Sub TEXTBOX17_TextChanged1(ByVal sender As Object, ByVal e As EventArgs)
        On Error Resume Next
        Me.TEXTTotalTipsN.Text = CurrencyJO(Me.TEXTTotalTips.Text, "jO")
        Me.TEXTTotalClearanceN.Text = CurrencyJO(Me.TEXTTotalClearance.Text, "jO")
    End Sub
    Private Sub DataGridView2_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellEnter
        Try
            If Me.DataGridView2.SelectedRows.Count = 0 Then
                Me.DataGridView2.Item(0, e.RowIndex).Value = Me.DataGridView2.CurrentRow.Index + 1
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView2_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView2.CellMouseDoubleClick
        Try
            Dim resault As Integer
            Dim Consum As New SqlConnection(constring)
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If DataGridView2.SelectedRows.Count > 0 Then
                        For i As Integer = DataGridView2.SelectedRows.Count - 1 To 0
                            Dim n As Integer
                            n = Me.DataGridView2.SelectedRows(i).Cells("CEMP").Value
                            DataGridView2.Rows.RemoveAt(Me.DataGridView2.SelectedRows(i).Index)
                            Dim CMD2 As New SqlCommand With {
                                .CommandType = CommandType.Text,
                                .Connection = Consum
                            }
                            If Consum.State = ConnectionState.Open Then Consum.Close()
                            Consum.Open()
                            Dim SQL2 As New SqlCommand("DELETE FROM CABLESEMPLOYEES WHERE CEMP=" & n, Consum)
                            CMD2.CommandText = SQL2.CommandText
                            CMD2.ExecuteNonQuery()
                        Next
                        Consum.Close()
                    Else
                        MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
                    End If
                    Exit Sub
                Else
                    MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        'Try
        '    Dim resault As Integer
        '    Dim Consum As New SqlClient.SqlConnection(constring)
        '    If (Me.BS.Count > 0) Then
        '        resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        '        If resault = vbYes Then
        '            If Me.DataGridView1.SelectedRows.Count > 0 Then
        '                For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0
        '                    Dim n As Integer
        '                    n = Me.DataGridView1.SelectedRows(i).Cells("CCUST").Value
        '                    DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
        '                    Dim CMD2 As SqlClient.SqlCommand = New SqlClient.SqlCommand
        '                    CMD2.CommandType = CommandType.Text
        '                    CMD2.Connection = Consum
        '                    If Consum.State = ConnectionState.Open Then Consum.Close()
        '                    Consum.Open()
        '                    Dim SQL2 As New SqlCommand("DELETE FROM CABLESCO WHERE CCUST=" & n, Consum)
        '                    CMD2.CommandText = SQL2.CommandText
        '                    CMD2.ExecuteNonQuery()
        '                Next
        '                Consum.Close()
        '            Else
        '                MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
        '            End If
        '            Exit Sub
        '        Else
        '            MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        '            Exit Sub
        '        End If
        '    Else
        '        MessageBox.Show(" لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        'End Try
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        On Error Resume Next
        If Me.DataGridView1.CurrentCell.ColumnIndex = 2 Then
            FrmDATALIST.ListBox1.Visible = True
            FrmDATALIST.ListBox2.Visible = False
            FrmDATALIST.Show()
            Me.DataGridView1.CurrentRow.Cells("CCUST3").Value = FrmDATALIST.Tag
        ElseIf Me.DataGridView1.CurrentCell.ColumnIndex = 3 Then
            If Clipboard.ContainsText Then Me.DataGridView1.CurrentRow.Cells(3).Value = Clipboard.GetText
            'Clipboard.Clear()
            Me.DataGridView1.CurrentRow.Cells(3).Value = Calculator()
        End If
    End Sub
    Private Sub TEXTCertificateNumber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles CreditTransferNumber.LostFocus
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.SaveCABLESCOEMPLOYEES()
        Me.DanLOd()
        Me.BS.Position = P
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        Me.TEXTCertificateNumber.Enabled = False
        CreditTransferNumber.Enabled = False
    End Sub
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateMovementHistory.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTBOX2_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DateMovementHistory.TextChanged
        On Error Resume Next
        Me.DateMovementHistory.Text = Me.DateMovementHistory.Value
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust,cust22 FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)

        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.Text = ds.Tables(0).Rows(0).Item(0)
            TypeCustomer = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextCustomerNumber.Text = ""
            TypeCustomer = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboType.SelectedIndexChanged, TextQuantity.TextChanged
        On Error Resume Next
        If TextQuantity.Text <> "" And Len(Me.ComboType.Text) > 0 Then Me.TEXTLetteringQuantity.Text = AmountWord(Me.TextQuantity.Text) & " " & Me.ComboType.Text
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            'For i As Integer = 0 To DataGridView1.Rows.Count - 1
            '    Dim row As DataGridViewRow = DataGridView1.Rows(i)
            'If row.IsNewRow Then Continue For
            If Me.DataGridView1.SelectedRows.Count = 0 Then
                Me.DataGridView1.Item("CCUST1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
                If Me.DataGridView1.Item("CCUST3", e.RowIndex).FormattedValue.ToString = "م تخليص مرفق بيان بالمصاريف" Then
                    Me.DataGridView1.Item("CCUST2", e.RowIndex).Value = Me.TEXTTotalClearance.Text.Trim
                ElseIf Me.DataGridView1.Item("CCUST3", e.RowIndex).FormattedValue.ToString = "م سحب أذن التسليم من التوكيل التعاوني" And DataGridView1.Item(3, e.RowIndex).FormattedValue.ToString = "0" Then
                    Me.DataGridView1.Item(1, e.RowIndex).Value = "25"
                End If
            Else
                Exit Sub
            End If
            'Next


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ButtonInsertData_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonInsertData.Click
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        If MsgBox("هل تريد اضافة بنود جدول اسماء المصاريف الى شبكة البيانات ؟", vbYesNo + vbQuestion + vbMsgBoxRight + vbDefaultButton2 + vbMsgBoxSetForeground + vbMsgBoxRtlReading, "العملاء") = vbYes Then
            Dim CMD As New SqlCommand("INSERT INTO CABLESEMPLOYEES ( CEMP1, CEMP4, CEMP2, CEMP3 ) SELECT BASICDATA.[BDATA1], BASICDATA.BDATA7, BASICDATA.BDATA5, '" & Me.TEXTCertificateNumber.EditValue & "'" & " FROM BASICDATA WHERE BASICDATA.[BDATA1]<=28", Consum) With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            Me.SAVEBUTTON_Click(sender, e)
            Me.DataGridView1.Visible = False
            Me.DataGridView2.Visible = True
        Else
            Cancel = True
        End If
    End Sub
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP4.Click
        Try
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim XLO As Int64
            XLO = Me.DataGridView3.RowCount
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
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = Val(XLO) + 1
            f.TEXTFileSubject.Text = "مستندات المصاريف"
            f.TextFileDescription.Text = ""
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CMDBROWSE.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Strings.Trim(Me.TextDOC1.Text), "'"}), Consum)
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
            If ds41.Tables(0).Rows(0).Item("DOC1") = Me.TextDOC1.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.TEXTBOX1.Text = Strings.Trim(Me.TextDOC1.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView3.DoubleClick
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Strings.Trim(Me.TextDOC1.Text), "'"}), Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("LO") = Me.TextMovementSymbol.EditValue Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.TEXTBOX1.Text = Strings.Trim(Me.TextDOC1.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
        Try
            Me.TextDOC1.Text = CDbl(Me.DataGridView3("DOC1", Me.DataGridView3.CurrentRow.Index).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboSearch.SelectedIndexChanged
        Try
            If Me.ComboSearch.Text.Length > 0 Then
                Dim Str As String = ComboSearch.Text
                Dim strArr() As String
                Dim a As String
                strArr = Str.Split("-")
                a = strArr(0)
                Dim index As Integer
                index = Me.BS.Find(NameOf(CEMP1), a)
                Me.BS.Position = index
            Else
                Me.BS.Position = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FundBalance()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
    Private Sub TEXTBOX10_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTSupplier.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.TEXTSupplier.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsql)
        ds1.Clear()
        Adp1.Fill(ds1)
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TextSupplierNumber.Text = ds1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSupplierNumber.Text = ""
        End If
        Adp1.Dispose()
        Consum.Close()
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
                    TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                    Me._Type1 = ds.Tables(0).Rows(0).Item(2)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    TypeCustomer = ""
                    Me._Type1 = ""
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
        Me.ComboITEMNAME.Text = Nothing
        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)
    End Sub

    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        Dim total As Double = "0.00"

        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("CCUST2").Value)
        Next
        Me.TEXTTotalTips.Text = total.ToString("0.00")
    End Sub

    Private Sub DataGridView2_CurrentCellChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles DataGridView2.CurrentCellChanged
        On Error Resume Next
        Dim total As Double = "0.00"
        For Each r As DataGridViewRow In Me.DataGridView2.Rows
            total += CDbl(r.Cells("CEMP2").Value)
        Next
        Me.TEXTTotalClearance.Text = total.ToString("0.00")
    End Sub

    Private Sub TextBox53_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextFundValue.EditValueChanged
        Me.TEXTcash.EditValue = Val(Me.TextFundValue.EditValue)
    End Sub
End Class