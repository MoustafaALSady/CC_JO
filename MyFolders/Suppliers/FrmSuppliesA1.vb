Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Public Class FrmSuppliesA1
    Inherits System.Windows.Forms.Form
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    ReadOnly ds As New DataSet
    ReadOnly dt As DataTable
    Dim test As Integer
    Dim test2 As Integer
    Dim ik As Integer
    Public cod As String = ""
    Public num As String = ""
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim DiscountA As Double = 0
    ReadOnly DiscountB As Double = 0


    Private Sub FrmSuppliesA_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmSuppliesA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub FrmSuppliesA_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Call MangUsers()
    End Sub
    Private Sub FrmSuppliesA1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboSupplierName)
        Me.SHOWBUTTON()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False

        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)
        PurchSales_Check = False

        TestkeyAccounts(keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No)
        End If

    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Dim F As Boolean
        Dim T As Boolean
        F = False
        T = True
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        If Cash = True Then
            Me.Label9.Text = "فاتورة شـراء نقدى"
            With str1
                .CommandText = "SELECT   BUY1, BUY2, BUY3  FROM BUYS where  CUser='" & CUser & "' and BUY2 ='" & Me.TEXTInvoiceNumberA.EditValue & "' and deleted ='" & False & "' and type_cash ='" & T & "'ORDER BY BUY2"
                '.CommandText = "SELECT   BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY17, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27,
            End With
        Else
            Me.Label9.Text = "فاتورة شـراء أجـل"
            With str1
                .CommandText = "SELECT  BUY1, BUY2, BUY3  FROM BUYS where  CUser='" & CUser & "' and BUY2 ='" & Me.TEXTInvoiceNumberA.EditValue & "' and deleted ='" & False & "' and type_cash ='" & F & "'ORDER BY BUY2"
            End With
        End If
        Me.ds.EnforceConstraints = False
        Consum.Open()
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        With str2
            '.CommandText = "SELECT  BITM1, BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM9, BITM10, ([BITM5] * [BITM6]) * (100 - [BITM7]) / 100 AS BITM8, BUY2 FROM BUYSITEMS ORDER BY BUY2"
            .CommandText = "SELECT  BITM1, BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM8, BITM9, BITM10, BUY2 From BUYSITEMS"

        End With
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.ds.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds, "BUYS")
        Me.SqlDataAdapter2.Fill(Me.ds, "BUYSITEMS")
        'ds.Tables("BUYS").PrimaryKey = New DataColumn() {ds.Tables("BUYS").Columns("BUY2")}
        'ds.Tables("BUYSITEMS").PrimaryKey = New DataColumn() {ds.Tables("BUYSITEMS").Columns("BUY2")}
        Me.ds.Relations.Add("REL1", Me.ds.Tables("BUYS").Columns("BUY2"), Me.ds.Tables("BUYSITEMS").Columns("BUY2"), True)
        Me.BS.DataSource = ds
        Me.BS.DataMember = "BUYS"
        Me.ds.EnforceConstraints = True
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.dt.DefaultView.AllowDelete = "REL1"
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Me. AccountsEnquiry()
        PurchSales_Check = False
        TestkeyAccounts(keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No)
        End If
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboSupplierName, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboITEMNAME, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXT19_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
    End Sub

    Private Sub MAXRECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim SQL As New SqlCommand("SELECT MAX(BUYS.BUY1) FROM BUYS WHERE  Year(BUY3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
        Dim CMD As New SqlClient.SqlCommand
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
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If
    End Sub
    Private Sub SaveBuys()
        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO BUYS( BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY13, BUY14, BUY15, BUY16, BUY17, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28,WarehouseNumber, WarehouseName,  CB1, BN2, USERNAME, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne ) VALUES (@BUY1, @BUY2, @BUY3, @BUY4, @BUY5, @BUY6, @BUY7, @BUY8, @BUY9, @BUY10, @BUY11, @BUY13, @BUY14, @BUY15, @BUY16, @BUY17, @BUY18, @BUY19, @BUY20, @BUY21, @BUY22, @BUY23, @BUY24, @BUY25, @BUY26, @BUY27, @BUY28,@WarehouseNumber, @WarehouseName,  @CB1, @BN2, @USERNAME, @CUser, @COUser, @TYPE_CASH, @TYPE_CRDT, @Deleted, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@BUY1", SqlDbType.Int).Value = Me.TEXTID.Text
                .Parameters.Add("@BUY2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumberA.EditValue
                .Parameters.Add("@BUY3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@BUY4", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text
                .Parameters.Add("@BUY5", SqlDbType.NVarChar).Value = Me.ComboSupplierName.Text
                .Parameters.Add("@BUY6", SqlDbType.NVarChar).Value = Me.TEXTItemsTotal.Text
                .Parameters.Add("@BUY7", SqlDbType.NVarChar).Value = Me.TEXTDiscountPercentage.EditValue
                .Parameters.Add("@BUY8", SqlDbType.NVarChar).Value = Me.TEXTDiscount.Text
                .Parameters.Add("@BUY9", SqlDbType.NVarChar).Value = Me.TEXTNetItems.Text
                .Parameters.Add("@BUY10", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.EditValue
                .Parameters.Add("@BUY11", SqlDbType.NVarChar).Value = Me.TEXTSalesTaxes.Text
                .Parameters.Add("@BUY13", SqlDbType.NVarChar).Value = Me.TEXTInvoiceNumber.Text
                .Parameters.Add("@BUY14", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@BUY15", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@BUY17", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@BUY18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@BUY19", SqlDbType.Bit).Value = False
                .Parameters.Add("@BUY20", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@BUY21", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@BUY22", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text
                .Parameters.Add("@BUY23", SqlDbType.NVarChar).Value = Me.TextValueAccountsPayable.EditValue
                .Parameters.Add("@BUY24", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@BUY25", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@BUY26", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@BUY27", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@BUY28", SqlDbType.Bit).Value = False
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@Deleted", SqlDbType.Bit).Value = False
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If Cash = True Then
                    .Parameters.Add("@BUY16", SqlDbType.NVarChar).Value = "نقــــــدى"
                    .Parameters.Add("@TYPE_CASH", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CRDT", SqlDbType.Bit).Value = False
                Else
                    .Parameters.Add("@BUY16", SqlDbType.NVarChar).Value = "أجـــــــل"
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
            MessageBox.Show(ex.Message, "ErrorSaveBuys", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveBuysItems()
        On Error Resume Next
        'Me.danLOd()
        'Try
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim SQL As New SqlClient.SqlCommand("INSERT INTO BUYSITEMS (BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM8, BITM9, BITM10, BUY2) VALUES     (@BITM2, @BITM3, @BITM4, @BITM5, @BITM6, @BITM7, @BITM8, @BITM9, @BITM10, @BUY2)", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@BITM1", SqlDbType.Int, 4, "BITM1")
            .Parameters.Add("@BITM2", SqlDbType.Int, 4, "BITM2")
            .Parameters.Add("@BITM3", SqlDbType.NVarChar, 255, "BITM3")
            .Parameters.Add("@BITM4", SqlDbType.NVarChar, 255, "BITM4")
            .Parameters.Add("@BITM5", SqlDbType.Float, 8, "BITM5")
            .Parameters.Add("@BITM6", SqlDbType.Float, 8, "BITM6")
            .Parameters.Add("@BITM7", SqlDbType.Float, 8, "BITM7")
            .Parameters.Add("@BITM8", SqlDbType.Float, 8, "BITM8")
            .Parameters.Add("@BITM9", SqlDbType.Float, 8, "BITM9")
            .Parameters.Add("@BITM10", SqlDbType.Float, 8, "BITM10")
            .Parameters.Add("@BUY2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumberA.EditValue
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "BUYSITEMS", New DataColumnMapping() {New DataColumnMapping("BITM1", "BITM1"), New DataColumnMapping("BITM2", "BITM2"), New DataColumnMapping("BITM3", "BITM3"), New DataColumnMapping("BITM4", "BITM4"), New DataColumnMapping("BITM5", "BITM5"), New DataColumnMapping("BITM6", "BITM6"), New DataColumnMapping("BITM7", "BITM7"), New DataColumnMapping("BITM8", "BITM8"), New DataColumnMapping("BITM9", "BITM9"), New DataColumnMapping("BUY2", "BUY2")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds, "BUYSITEMS")
        Consum.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorSaveBuysItems", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub UpdateBuys()
        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update BUYS SET   BUY3 = @BUY3, BUY4 = @BUY4, BUY5 = @BUY5, BUY6 = @BUY6, BUY7 = @BUY7, BUY8 = @BUY8, BUY9 = @BUY9, BUY10 = @BUY10, BUY11 = @BUY11, BUY13 = @BUY13, BUY14 = @BUY14, BUY15 = @BUY15, BUY17 = @BUY17, BUY18 = @BUY18, BUY19 = @BUY19, BUY20 = @BUY20, BUY21 = @BUY21, BUY22 = @BUY22, BUY23 = @BUY23, BUY24 = @BUY24, BUY25 = @BUY25, BUY26 = @BUY26, BUY27 = @BUY27, BUY28 = @BUY28,WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, Deleted = @Deleted, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, BUY16 = @BUY16, TYPE_CASH = @TYPE_CASH, TYPE_CRDT = @TYPE_CRDT WHERE  BUY2 = @BUY2", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                '.Parameters.Add("@BUY1", SqlDbType.Int).Value = Me.TEXT1.Text.Trim
                .Parameters.Add("@BUY2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumberA.EditValue
                .Parameters.Add("@BUY3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@BUY4", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text.Trim
                .Parameters.Add("@BUY5", SqlDbType.NVarChar).Value = Me.ComboSupplierName.Text.Trim
                .Parameters.Add("@BUY6", SqlDbType.NVarChar).Value = Me.TEXTItemsTotal.Text.Trim
                .Parameters.Add("@BUY7", SqlDbType.NVarChar).Value = Me.TEXTDiscountPercentage.EditValue
                .Parameters.Add("@BUY8", SqlDbType.NVarChar).Value = Me.TEXTDiscount.Text.Trim
                .Parameters.Add("@BUY9", SqlDbType.NVarChar).Value = Me.TEXTNetItems.Text.Trim
                .Parameters.Add("@BUY10", SqlDbType.NVarChar).Value = Me.TEXTTaxRate.EditValue
                .Parameters.Add("@BUY11", SqlDbType.NVarChar).Value = Me.TEXTSalesTaxes.Text.Trim
                .Parameters.Add("@BUY13", SqlDbType.NVarChar).Value = Me.TEXTInvoiceNumber.Text.Trim
                .Parameters.Add("@BUY14", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@BUY15", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text.Trim
                .Parameters.Add("@BUY17", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@BUY18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@BUY19", SqlDbType.Bit).Value = False
                .Parameters.Add("@BUY20", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text.Trim
                .Parameters.Add("@BUY21", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@BUY22", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text.Trim
                .Parameters.Add("@BUY23", SqlDbType.NVarChar).Value = Me.TextValueAccountsPayable.EditValue
                .Parameters.Add("@BUY24", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text.Trim
                .Parameters.Add("@BUY25", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text.Trim
                .Parameters.Add("@BUY26", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@BUY27", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@BUY28", SqlDbType.Bit).Value = False
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@Deleted", SqlDbType.Bit).Value = False
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                If Cash = True Then
                    .Parameters.Add("@BUY16", SqlDbType.NVarChar).Value = "نقــــــدى"
                    .Parameters.Add("@TYPE_CASH", SqlDbType.Bit).Value = True
                    .Parameters.Add("@TYPE_CRDT", SqlDbType.Bit).Value = False
                Else
                    .Parameters.Add("@BUY16", SqlDbType.NVarChar).Value = "أجـــــــل"
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
            MessageBox.Show(ex.Message, "ErrorUpdateBuys", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UpdateBuysItems()
        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand("Update BUYSITEMS SET BITM2 = @BITM2, BITM3 = @BITM3, BITM4 = @BITM4, BITM5 = @BITM5, BITM6 = @BITM6, BITM7 = @BITM7, BITM8 = @BITM8, BITM9 = @BITM9, BITM10 = @BITM10, BUY2 = @BUY2  WHERE   BITM1 = @BITM1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@BITM1", SqlDbType.Int, 4, "BITM1")
                .Parameters.Add("@BITM2", SqlDbType.Int, 4, "BITM2")
                .Parameters.Add("@BITM3", SqlDbType.NVarChar, 255, "BITM3")
                .Parameters.Add("@BITM4", SqlDbType.NVarChar, 255, "BITM4")
                .Parameters.Add("@BITM5", SqlDbType.Float, 8, "BITM5")
                .Parameters.Add("@BITM6", SqlDbType.Float, 8, "BITM6")
                .Parameters.Add("@BITM7", SqlDbType.Float, 8, "BITM7")
                .Parameters.Add("@BITM8", SqlDbType.Float, 8, "BITM8")
                .Parameters.Add("@BITM9", SqlDbType.Float, 8, "BITM9")
                .Parameters.Add("@BITM10", SqlDbType.Float, 8, "BITM10")
                .Parameters.Add("@BUY2", SqlDbType.BigInt, 8, "BUY2")
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "BUYSITEMS", New DataColumnMapping() {New DataColumnMapping("BITM1", "BITM1"), New DataColumnMapping("BITM2", "BITM2"), New DataColumnMapping("BITM3", "BITM3"), New DataColumnMapping("BITM4", "BITM4"), New DataColumnMapping("BITM5", "BITM5"), New DataColumnMapping("BITM6", "BITM6"), New DataColumnMapping("BITM7", "BITM7"), New DataColumnMapping("BITM8", "BITM8"), New DataColumnMapping("BITM9", "BITM9"), New DataColumnMapping("BUY2", "BUY2")})})
            SqlDataAdapter2.UpdateCommand = CMD
            SqlDataAdapter2.Update(ds, "BUYSITEMS")
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUpdateBuysItems", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        Me.TextBalance.Text = Format(Val(Me.DataGridView1.CurrentRow.Cells("BITM6").Value), "0.000")
        'Me.TextBox13.Text = Format(Val(Me.TextBalance.Text) + Val(Me.TextBox11.Text), "0.000")

    End Sub
    Private Sub SaveStocks()
        Try
            GetAutoIDSTK()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO STOCKS(STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     (@STK1, @WarehouseNumber, @WarehouseName,  @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlClient.SqlCommand(SQL, Consum)
            With CMD.Parameters
                .AddWithValue("@STK1", IDSTK)
                .AddWithValue("@WarehouseNumber", Me.ComboStore.Text)
                .AddWithValue("@WarehouseName", Me.TextWarehouseName.Text)
                .AddWithValue("@STK3", Me.TEXTPermissionNumber.Text)
                .AddWithValue("@STK4", Me.DateMovementHistory.Value.ToString("yyyy-MM-dd"))
                .AddWithValue("@STK5", "استلام")
                .AddWithValue("@STK6", Me.TEXTInvoiceNumberA.EditValue)
                .AddWithValue("@STK7", Me.DataGridView1.Item("BITM3", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK8", Me.TextGroupName.Text)
                .AddWithValue("@STK9", Me.TextHashUnit.Text)
                .AddWithValue("@STK10", Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM4").Value, IDSTK)), "0.000"))
                .AddWithValue("@STK11", Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK12", "0")
                .AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM4").Value, IDSTK)), "0.000") + Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK14", Me.TEXTOrderLimit.Text)
                .AddWithValue("@STK15", Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK16", Me.TextMovementSymbol.EditValue)
                .AddWithValue("@STK17", Me.TXTDiscountA.Text)
                .AddWithValue("@STK18", Format(Val(Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(Me.TXTDiscountA.Text)) / 100, "0.000"))
                .AddWithValue("@STK19", Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK20", Format(Val(Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000"))
                .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
                .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
                .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
                .AddWithValue("@STK25", Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                .AddWithValue("@USERNAME", USERNAME)
                .AddWithValue("@CUser", CUser)
                .AddWithValue("@COUser", COUser)
                .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                .AddWithValue("@IT_DATEP", Me.ProductionDate.Text)
                .AddWithValue("@IT_DATEEX", Me.ExpiryDate.Text)
            End With
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATEBALANCEITEMS()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim sql As New SqlClient.SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @SKITM7  WHERE STOCKSITEMS.SKITM4='" & Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .CommandType = CommandType.Text
                        .Connection = Consum
                        .Parameters.Add("@SKITM7", System.Data.SqlDbType.Float).Value = Val(Me.TEXTCurrentBalance.Text) '2
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
    Private Sub UpdatStocks()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim idSTK As Int64
            GetAutoNumber("STK1", "STOCKS", "STK4")
            idSTK = AutoNumber
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    Dim SQL As New SqlClient.SqlCommand(" Update STOCKS SET WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK3 = @STK3, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK25 = @STK25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE STK1 ='" & Me.TextSTK1A.Text & "'" & "AND STK7= '" & Me.DataGridView1.CurrentRow.Cells("BITM3").Value & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand(SQL.CommandText) With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                        .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                        .Parameters.Add("@STK3", SqlDbType.NVarChar).Value = Me.TEXTPermissionNumber.Text
                        .Parameters.Add("@STK7", SqlDbType.NVarChar).Value = Me.DataGridView1.Item("BITM3", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK8", SqlDbType.NVarChar).Value = Me.TextGroupName.Text
                        .Parameters.Add("@STK9", SqlDbType.NVarChar).Value = Me.TextHashUnit.Text
                        .Parameters.Add("@STK10", SqlDbType.Float).Value = Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM4").Value, idSTK)), "0.000")
                        .Parameters.Add("@STK11", SqlDbType.Float).Value = Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK12", SqlDbType.Float).Value = "0"
                        .Parameters.Add("@STK13", SqlDbType.Float).Value = Format(Val(SumAmounTOTALSTOCKS(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM4").Value, idSTK)), "0.000") + Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK14", SqlDbType.Float).Value = Me.TEXTOrderLimit.Text
                        .Parameters.Add("@STK15", SqlDbType.Float).Value = Me.TEXTUnitPrice.Text
                        .Parameters.Add("@STK17", SqlDbType.Float).Value = Me.TXTDiscountA.Text
                        .Parameters.Add("@STK18", SqlDbType.Float).Value = Format(Val(Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(Me.TXTDiscountA.Text)) / 100, "0.000")
                        .Parameters.Add("@STK19", SqlDbType.Float).Value = Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK20", SqlDbType.Float).Value = Format(Val(Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000")
                        .Parameters.Add("@STK21", SqlDbType.Float).Value = Me.TextDiscountPercentageWhenSelling.Text
                        .Parameters.Add("@STK22", SqlDbType.Float).Value = Me.TextLowestDiscountRateWhenSelling.Text
                        .Parameters.Add("@STK23", SqlDbType.Float).Value = Me.TextHighestDiscountRateWhenSelling.Text
                        .Parameters.Add("@STK25", SqlDbType.Int).Value = Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@CUser", SqlDbType.Int).Value = CUser
                        .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub TEXTInvoiceNumberA_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTInvoiceNumber.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTPermissionNumber.Focus()
        End Select
    End Sub
    Private Sub TEXTInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTInvoiceNumberA.LostFocus
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.DanLOd()
        Me.BS.Position = P
        Me.TEXTInvoiceNumberA.Enabled = False
    End Sub
    Private Sub TEXTInvoiceNumberA_GotFocus(sender As Object, e As EventArgs) Handles TEXTInvoiceNumberA.GotFocus
        Me.TEXTInvoiceNumberA.Enabled = True
        Me.ComboSupplierName.Text = "مورد عام"
        Me.SaveBuys()
    End Sub

    Private Sub TEXTInvoiceNumberA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTInvoiceNumberA.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.ComboSupplierName.Focus()
        End If
    End Sub
    Private Sub ComboSupplierName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSupplierName.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            Me.TEXTPermissionNumber.Focus()
        End If
    End Sub
    Private Sub TEXTPermissionNumber_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTPermissionNumber.KeyPress
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
        Call MangUsers()
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.BS.EndEdit()
        Me.BS.AddNew()
        CLEARDATA1(Me)
        Me.SEARCHDMAXCASHIER()
        Me.MAXRECORD()
        GetAutoNumber("BUY2", "BUYS", "BUY3")
        Me.TEXTInvoiceNumberA.EditValue = AutoNumber
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.TEXTInvoiceNumberA.Enabled = True
        Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
        Me.TextMovementSymbol.EditValue = "PR" & Me.TEXTInvoiceNumberA.EditValue
        Me.ComboSupplierName.Text = "مورد عام"
        Me.TextFundValue.EditValue = "0"
        Me.TextValueAccountsPayable.EditValue = "0"
        Me.TextValueOfCheck.EditValue = "0"
        Me.TEXTInvoiceNumber.SendToBack()
        Me.TEXTInvoiceNumberA.BringToFront()
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
        Me.TEXTInvoiceNumberA.Focus()
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        Try
            Dim ch As Double
            Dim ch11 As Double
            ch = Me.TextFundValue.EditValue
            ch11 = Me.TextFundBalance.Text
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            'If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            'If Val(Me.TextBox20.Text) <> (Val(Me.TextBox14.Text) + Val(Me.TextBox41.Text) + Val(Me.TEXT19.Text)) Then
            '    MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
            '    Exit Sub
            'End If
            If ch11 < ch Then
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
            ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك_ذمم_دائنة" Then
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
            GetDiscount_B(Val(Me.TEXTDiscount.Text))
            GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOPTIONS.ShowDialog()
                Exit Sub
            End If
            If Me.Ch1.Checked = False Then
                Me.Ch1.Checked = True
            End If
            PurchSales_Check = False
            CalculatingTax_B = Format(Val(Me.TEXTSalesTaxes.Text), "0.000")
            Me.DataGridView1.ClearSelection()
            Dim nextRow As DataGridViewRow
            nextRow = Me.DataGridView1.Rows(0)
            DataGridView1.Rows(0).Selected = True
            DataGridView1.CurrentCell = DataGridView1("BITM2", DataGridView1.Rows(0).Index)

            SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
            Me.TextSTK1B.Text = SEARCHDATA.STK1B

            Static Dim P As Integer
            P = Me.BS.Position
            Me.UpdateBuys()
            Me.SaveBuysItems()
            Me.DanLOd()
            nextRow = Me.DataGridView1.Rows(0)
            Me.DataGridView1.Rows(0).Selected = True
            Me.BS.Position = P
            'Me.SaveBuys()
            Me.UpdateBuys()
            Me.SaveBuysItems()
            SaveStocks()
            'UpdatStocks()

            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
                TransforAccounts()
            Else
                TransferToAccounts_Check = False
            End If

            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Insert_Actions(Me.TEXTID.Text, "حقظ ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT SKITM4,SKITM5,SKITM8,SKITM14,SKITM5 FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4 = '" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value & " '", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.cod = ds.Tables(0).Rows(0).Item("SKITM4")
            Me.num = ds.Tables(0).Rows(0).Item("SKITM5")
            Me.DataGridView1.CurrentRow.Cells("BITM3").Value = num
            Me.DataGridView1.CurrentRow.Cells("BITM4").Value = cod
        End If
        If Me.DataGridView1.CurrentCell.ColumnIndex = "BITM3" Then
            If ds.Tables(0).Rows.Count > 0 Then
                Me.cod = ds.Tables(0).Rows(0).Item("SKITM4")
                Me.num = ds.Tables(0).Rows(0).Item("SKITM5")
                Me.DataGridView1.CurrentRow.Cells("BITM3").Value = num
                Me.DataGridView1.CurrentRow.Cells("BITM4").Value = cod
            End If
        End If
        Dim VS1 As Double = "0.000"
        Dim VS2 As Double = "0.000"
        VS1 = Format(Val(Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value), "0.000")
        VS2 = Format(Val(VS1) * Val(Me.DataGridView1.Item("BITM7", Me.DataGridView1.CurrentRow.Index).Value) / 100, "0.000")
        Me.DataGridView1.CurrentRow.Cells("BITM8").Value = Val(Me.DataGridView1.CurrentRow.Cells("BITM5").Value * Me.DataGridView1.CurrentRow.Cells("BITM6").Value) - Val(VS2)
        Me.DataGridView1.CurrentRow.Cells("BITM10").Value = Val(VS1) * Val(Me.DataGridView1.Item("BITM7", Me.DataGridView1.CurrentRow.Index).Value) / 100

        Me.SEARCHSTOCKSITEMS()
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        Dim total As Double
        Dim tota2 As Double
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("BITM8").Value)
            tota2 += CDbl(r.Cells("BITM10").Value)
        Next
        Me.Timsum.Start()
        'Me.TEXTItemsTotal.Text = total.ToString("0.00")
        'Me.txtDiscount.Text = tota2.ToString("0.00")
        'Me.TEXT4_TextChanged(sender, e)
    End Sub
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        Me.SEARCHSTOCKSITEMS()
    End Sub
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        Exit Sub
    End Sub
    Private Sub SEARCHSTOCKSITEMS()
        Dim Tax As Boolean
        Dim Tax1 As Boolean
        Dim Tax2 As String
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.DataGridView1.Rows.Count > 0 Then
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                If row.IsNewRow Then Continue For

                Dim strsql1 As New SqlClient.SqlCommand("SELECT SKITM3,SKITM4,SKITM5,SKITM6,SKITM8,SKITM9,SKITM11,SKITM12,SKITM14,SKITM15,SKITM16,SKITM17,SKITM18,SKITM19,SKITM20,SKITM21,SKITM22,SKITM23,SKITM24,SKITM25,SKITM26,IT_DATEP,IT_DATEEX FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4='" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                Dim ds As New DataSet
                Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
                On Error Resume Next
                ds.Clear()
                Adp1.Fill(ds, "STOCKSITEMS")
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextGroupName.Text = ds.Tables(0).Rows(0).Item("SKITM3")
                    Tax2 = ds.Tables(0).Rows(0).Item(1)
                    Me.ComboITEMNAME.Text = ds.Tables(0).Rows(0).Item("SKITM5")
                    Me.TextHashUnit.Text = ds.Tables(0).Rows(0).Item("SKITM6")
                    Me.TEXTUnitPrice.Text = ds.Tables(0).Rows(0).Item("SKITM8")
                    Me.TXTDiscountA.Text = ds.Tables(0).Rows(0).Item("SKITM9")
                    Me.TextTotalPurchasePrice.Text = ds.Tables(0).Rows(0).Item("SKITM10")
                    Me.TEXTOrderLimit.Text = ds.Tables(0).Rows(0).Item("SKITM11")
                    Me.TextSalesTaxRate.Text = ds.Tables(0).Rows(0).Item("SKITM12")
                    Me.TexTSellingPrice.Text = ds.Tables(0).Rows(0).Item("SKITM14")
                    Me.TextDiscountPercentageWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM15")
                    Me.TextLowestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM16")
                    Me.TextHighestDiscountRateWhenSelling.Text = ds.Tables(0).Rows(0).Item("SKITM17")
                    Me.TextSecondSellingPrice.Text = ds.Tables(0).Rows(0).Item("SKITM18")
                    Me.TextThirdSalePrice.Text = ds.Tables(0).Rows(0).Item("SKITM19")
                    Tax = ds.Tables(0).Rows(0).Item("SKITM20")
                    Tax1 = ds.Tables(0).Rows(0).Item("SKITM21")
                    Me.TextHashUnit1.Text = ds.Tables(0).Rows(0).Item("SKITM22")
                    Me.TextHashUnit2.Text = ds.Tables(0).Rows(0).Item("SKITM23")
                    Me.TextHashUnitNumber.Text = ds.Tables(0).Rows(0).Item("SKITM24")
                    Me.TextHashUnitNumber1.Text = ds.Tables(0).Rows(0).Item("SKITM25")
                    Me.TextHashUnitNumber2.Text = ds.Tables(0).Rows(0).Item("SKITM26")
                    Me.ProductionDate.Text = ds.Tables(0).Rows(0).Item("IT_DATEP")
                    Me.ExpiryDate.Text = ds.Tables(0).Rows(0).Item("IT_DATEEX")
                    Me.CheckPricesMentionedIncludeSalesTax.Checked = Tax.ToString
                    Me.CheckItemIsSubjectToSalesTax.Checked = Tax1.ToString
                Else
                    Me.TextGroupName.Text = ""
                    Me.ComboITEMNAME.Text = ""
                    Me.TextHashUnitNumber.Text = ""
                    Me.TEXTOrderLimit.Text = ""
                    Me.TextSalesTaxRate.Text = ""
                    Me.ProductionDate.Text = ""
                    Me.ExpiryDate.Text = ""
                    Me.ComboITEMNAME.Text = ""
                End If
                Adp1.Dispose()
            Next
        End If
        Consum.Close()
    End Sub


    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing
        AccountsPayableAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(Me.TEXTDiscount.Text))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam

        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True

        nem = " فاتورة مشتريات رقم " & "_" & Me.TEXTInvoiceNumberA.EditValue
        nem1 = " فاتورة مشتريات نقدي رقم " & "_" & Me.TEXTInvoiceNumberA.EditValue
        nem2 = " فاتورة مشتريات بيموجب مستند رقم " & "_" & Me.TextCheckNumber.Text
        nem3 = " فاتورة مشتريات ذمم دائنة "
        nem4 = " خصم مكتسب لفاتورة مشتريات رقم" & "_" & Me.TEXTInvoiceNumberA.EditValue
        nem5 = "حساب ضريبة المبيعات المستحقة "
        PMO2 = 1

        Dim PaymentMethod As String
        If ComboPaymentMethod.Text = "نقدا" Then
            PaymentMethod = "نقدا"
        ElseIf ComboPaymentMethod.Text = "شيك" Then
            PaymentMethod = "شيك"
        ElseIf ComboPaymentMethod.Text = "نقدا_شيك" Then
            PaymentMethod = "نقدا_شيك"
        ElseIf ComboPaymentMethod.Text = "ذمم_دائنة" Then
            PaymentMethod = "نقدا"
        ElseIf ComboPaymentMethod.Text = "نقدا_ذمم_دائنة" Then
            PaymentMethod = "نقدا"
        Else
            PaymentMethod = "نقدا_شيك"
        End If

        Dim ch As Double
        ch = Format(Val(Me.TEXTNetItems.Text) + Val(Discount_B), "0.000")

        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قيد", "PR", TextMovementSymbol.EditValue, False)

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 3, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If

            Case "شيك"
                Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 3, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If

            Case "نقدا_شيك"
                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 3, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 4, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If

            Case "ذمم_دائنة"
                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, AccountsPayableAccount_Name, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 3, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If

            Case "نقدا_ذمم_دائنة"
                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)
                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 3, AccountsPayableAccount_Name, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 4, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If
            Case "شيك_ذمم_دائنة"
                Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 3, AccountsPayableAccount_Name, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 4, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If

            Case "نقدا_شيك_ذمم_دائنة"

                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)


                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, CalculatingTaxAccount_Name, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                Else
                    Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 3, ChecksAccount_Name, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 4, AccountsPayableAccount_Name, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                If Val(Me.TEXTDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 5, DiscountAccountAE_Name, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                End If

        End Select


    End Sub

    Private Sub  AccountsEnquiry()
        On Error Resume Next

        Me.DiscountA = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM10").Value))
        Me.TEXTItemsTotal.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM8").Value)) + Val(DiscountA)).ToString("0.000")
        Dim CASHA As Double = 0
        PurchSales_Check = False
        CalculatingTax_B = Val(Me.TEXTSalesTaxes.Text)

        CASHA = Format(Val(Me.TEXTNetItems.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")

        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing
        AccountsPayableAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(Me.TEXTDiscount.Text))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextValueAccountsPayable.Enabled = False
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.TextValueAccountsPayable.EditValue = "0.000"
                Me.TextFundValue.EditValue = Format(Val(CASHA), "0.000")
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            Case "شيك"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.TextValueAccountsPayable.Enabled = False
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueAccountsPayable.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = Format(Val(CASHA), "0.000")
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
            Case "نقدا_شيك"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.TextValueAccountsPayable.Enabled = False
                Me.TextValueAccountsPayable.EditValue = "0.000"
                Me.TextFundValue.EditValue = Format(Val(CASHA) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            Case "ذمم_دائنة"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = False
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.TextValueAccountsPayable.EditValue = Format(Val(CASHA), "0.000")
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
            Case "نقدا_ذمم_دائنة"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = Format(Val(CASHA) - Val(Me.TextValueAccountsPayable.EditValue), "0.000")
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            Case "شيك_ذمم_دائنة"
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = "0.000"
                TextValueOfCheck.EditValue = Format(Val(CASHA) - Val(Me.TextValueAccountsPayable.EditValue), "0.000")
            Case "نقدا_شيك_ذمم_دائنة"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = Format(Val(CASHA) - (Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextValueAccountsPayable.EditValue)), "0.000")
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
        End Select
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        DataGridView1.Rows(0).Selected = True
        DataGridView1.CurrentCell = DataGridView1("BITM2", DataGridView1.Rows(0).Index)
        Me. AccountsEnquiry()
    End Sub
    Private Sub TEXT4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTItemsTotal.TextChanged, TEXTDiscountPercentage.EditValueChanged, TEXTTaxRate.EditValueChanged, TEXTDiscount.TextChanged, TEXTNetItems.TextChanged, TEXTSalesTaxes.TextChanged, TextValueOfCheck.EditValueChanged, TextFundValue.EditValueChanged, TextValueAccountsPayable.EditValueChanged, txtDiscount.TextChanged

        On Error Resume Next
        Dim totl1 As Double
        Dim totl2 As Double

        Me.DiscountA = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM10").Value))
        Me.TEXTItemsTotal.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM8").Value)) + Val(DiscountA)).ToString("0.000")
        totl1 = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM8").Value))
        Me.TEXTDiscount.Text = Format(Val(totl1) * Val(Me.TEXTDiscountPercentage.EditValue) / 100, "0.000") + Val(DiscountA)
        Discount_B = Format(Val(Me.TEXTDiscount.Text), "0.000")
        'Me.TEXTNetItems.Text = Format(Val(Me.TEXTItemsTotal.Text) - Val(DiscountB), "0.000")
        Me.TEXTNetItems.Text = Format(Val(Me.TEXTItemsTotal.Text) - Val(Discount_B), "0.000")
        Me.TEXTSalesTaxes.Text = Format(Val(Me.TEXTItemsTotal.Text) * Val(Me.TEXTTaxRate.EditValue) / 100, "0.000")

        totl2 = Val(Me.TEXTItemsTotal.Text) + Val(Me.TEXTSalesTaxes.Text)
        Me.TEXTTotal.Text = totl2.ToString("0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")

        'CASHA = totl2.ToString("0.000")

         AccountsEnquiry()
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
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
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
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TxtItem2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem2.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Me.txtq.Focus()

            Me.SEARCHSTOCKSITEMS()
            Me.txtq.Text = 1
            Me.txtq.SelectAll()
        End If
    End Sub
    Private Sub TxtItem2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem2.TextChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str As New SqlCommand("", Consum)
        With str
            If Trim(txtItem2.Text) <> "" Then
                .CommandText = "SELECT * FROM STOCKSITEMS WHERE   CUser ='" & CUser & "'  and SKITM4 like'" & Trim(Me.txtItem2.Text) & "%'" & "or SKITM5 like'" & Trim(Me.txtItem2.Text) & "%'"

                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim ds As New DataSet
                Dim dt As New DataTable
                Dim Adp1 As New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                Adp1.Fill(ds, "STOCKSITEMS")
                Adp1.Fill(dt)
                Me.cod = ""
                Me.num = ""
                If DataGridView1.Rows.Count >= 2 Then
                    DataGridView1.Rows(0).Selected = True
                    DataGridView1.CurrentCell = DataGridView1("BITM2", DataGridView1.Rows(0).Index)
                End If
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.DataGridView2.DataSource = ds
                    Me.DataGridView2.DataMember = "STOCKSITEMS"
                    Me.cod = ds.Tables(0).Rows(0).Item("SKITM4")
                    Me.num = ds.Tables(0).Rows(0).Item("SKITM5")
                Else
                    Me.cod = ""
                    Me.num = ""
                    MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
                    Exit Sub
                End If
                Consum.Close()
            End If
        End With
        Me.txtq.Text = 1
        Me.Tot()
        Call Dgv2()
        'Me.DataGridView1.CurrentCell = Me.DataGridView1("BITM3", Me.DataGridView1.NewRowIndex)
    End Sub
    Public rec As DataRow
    Function GetSelectedRow(ByVal datagridview As DataGridView) As DataRow
        If datagridview Is Nothing Then
            Throw New ArgumentNullException(NameOf(datagridview))
        End If

        For Each x As DataGridViewRow In Me.DataGridView2.SelectedRows
            rec = CType(x.DataBoundItem, DataRowView).Row
        Next
        Return rec
    End Function
    Private Sub Txtq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtq.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 1).Selected = True
            Me.DataGridView1.MultiSelect = False
            Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.DataGridView1.Sort(Me.DataGridView1.Columns("BITM2"), System.ComponentModel.ListSortDirection.Descending)
            Me.DataGridView1.Sort(Me.DataGridView1.Columns("BITM2"), System.ComponentModel.ListSortDirection.Ascending)
            Call Dgv1()
            Me.txtItem2.Text = ""
            Me.txtItem2.Focus()
        End If
    End Sub
    Private Sub Txtq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtq.TextChanged
        On Error Resume Next

    End Sub
    Private Sub Tot()
        Dim Total1 As Double
        Dim Row As DataGridViewRow
        For Each Row In Me.DataGridView1.Rows
            Dim celV1 As DataGridViewTextBoxCell = Row.Cells("BITM8")
            If IsNumeric(celV1.Value) = True Then
                Total1 += celV1.Value
            End If
        Next
        Me.txtDiscount.Text = Total1
    End Sub
    Private Sub Dgv1()
        On Error Resume Next
        Me.DataGridView1.AllowUserToAddRows = True
        Static Dim P As Integer
        P = Me.BS.Position
        P = Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count - 2).Index
        SendKeys.Send("{DOWN}")
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
        Dim x As Integer
        For x = 0 To Me.DataGridView1.Rows.Count - 2
            Dim row As DataGridViewRow = Me.DataGridView1.Rows(x)
            If row.IsNewRow Then Continue For
        Next
        test = 1
        test2 = 1
        ik = 0
        '''''''''''''''''''''''''''''''''''''''
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            If r.Cells("BITM4").Value = Me.cod Then
                test = 0
            End If
        Next
        For Each itm As DataGridViewRow In Me.DataGridView2.Rows
            If itm.Cells("SKITM4").Value = Me.cod Then
                test2 = 0
            End If
        Next
        w1 = Val(Me.DataGridView2.Item("SKITM8", Me.DataGridView2.CurrentRow.Index).Value())
        w2 = txtq.Text.Trim
        w3 = Val(TXTDiscountA.Text)
        wsum = Format((Val(w2) * Val(w3) - Val(w3)) * (100 - Val(w3)) / 100, "0.000")
        '''''''''''''''''''''''''''''''''''''''
        r1 = txtq.Text.Trim
        r2 = Val(Me.DataGridView2.Item("SKITM8", Me.DataGridView2.CurrentRow.Index).Value())
        rsum = Format(Val(wsum) * Val(r2) / 100, "0.000")
        sum2 = Format(Val(wsum) - Val(rsum), "0.000")
        If test2 = 0 Then
            If test = 0 Then
                For Each row1 As DataGridViewRow In Me.DataGridView1.Rows
                    If row1.Cells("BITM4").Value = cod Then
                        w1 = Val(DataGridView2.Item("SKITM8", Me.DataGridView2.CurrentRow.Index).Value())
                        w13 = Val(row1.Cells("BITM5").Value)
                        w11 = Val(row1.Cells("BITM8").Value)
                        w12 = Val(row1.Cells("BITM6").Value) * Val(w13)
                        cx = Val(Me.txtq.Text.Trim) + Val(row1.Cells("BITM6").Value)
                        row1.Cells("BITM6").Value = Val(cx)
                        row1.Cells("BITM8").Value = Val(sum2)
                        row1.Cells("BITM9").Value = Me.TexTSellingPrice.Text
                    End If
                Next
            Else
                Me.DataGridView1.AutoGenerateColumns = False
                Me.DataGridView1.CurrentCell = DataGridView1("BITM2", DataGridView1.NewRowIndex)
                Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count).Selected = True
                Me.DataGridView1.MultiSelect = False
                Me.DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
                Me.DataGridView1.Sort(Me.DataGridView1.Columns("BITM2"), System.ComponentModel.ListSortDirection.Descending)
                Me.DataGridView1.Sort(Me.DataGridView1.Columns("BITM2"), System.ComponentModel.ListSortDirection.Ascending)

                Me.DataGridView1.Rows.Add()
                Me.DataGridView1.CurrentRow.Cells("BITM2").Value = Me.DataGridView1.CurrentRow.Index + 1
                Me.DataGridView1.CurrentRow.Cells("BITM3").Value = Me.num.ToString
                Me.DataGridView1.CurrentRow.Cells("BITM4").Value = Me.cod.ToString
                Me.DataGridView1.CurrentRow.Cells("BITM5").Value = Me.TEXTUnitPrice.Text
                Me.DataGridView1.CurrentRow.Cells("BITM6").Value = Me.txtq.Text
                Me.DataGridView1.CurrentRow.Cells("BITM7").Value = Me.TXTDiscountA.Text
                Me.DataGridView1.CurrentRow.Cells("BITM8").Value = sum2
                Me.DataGridView1.CurrentRow.Cells("BITM9").Value = Me.TexTSellingPrice.Text
            End If
            Dim Sound As System.IO.Stream = My.Resources.BarCode
            My.Computer.Audio.Play(Sound, AudioPlayMode.Background)
            If DataGridView1.Rows.Count <= 2 Then
                Me.DataGridView1.CurrentCell = DataGridView1("BITM2", DataGridView1.NewRowIndex)
            End If

        End If
    End Sub
    Private Sub Dgv2()
        On Error Resume Next
        '''''''''''''''''
        Me.DataGridView2.Columns(0).Visible = False
        Me.DataGridView2.Columns(1).Visible = False
        Me.DataGridView2.Columns(2).Visible = False
        Me.DataGridView2.Columns(3).Visible = False
        Me.DataGridView2.Columns(5).Visible = False
        Me.DataGridView2.Columns(6).Visible = False
        Me.DataGridView2.Columns(8).Visible = False
        Me.DataGridView2.Columns(9).Visible = False
        Me.DataGridView2.Columns(10).Visible = False
        Me.DataGridView2.Columns(11).Visible = False
        Me.DataGridView2.Columns(12).Visible = False
        Me.DataGridView2.Columns(13).Visible = False
        Me.DataGridView2.Columns(14).Visible = False
        Me.DataGridView2.Columns(15).Visible = False
        Me.DataGridView2.Columns(16).Visible = False
        Me.DataGridView2.Columns(17).Visible = False
        Me.DataGridView2.Columns(18).Visible = False
        Me.DataGridView2.Columns(19).Visible = False
        Me.DataGridView2.Columns(20).Visible = False
        Me.DataGridView2.Columns(21).Visible = False
        Me.DataGridView2.Columns(22).Visible = False
        Me.DataGridView2.Columns(23).Visible = False
        Me.DataGridView2.Columns(24).Visible = False
        Me.DataGridView2.Columns(25).Visible = False
        Me.DataGridView2.Columns(26).Visible = False
        Me.DataGridView2.Columns(27).Visible = False
        Me.DataGridView2.Columns(28).Visible = False
        Me.DataGridView2.Columns("ChkPD").Visible = False
        Me.DataGridView2.Columns("WarehouseNumber").Visible = False
        Me.DataGridView2.Columns("WarehouseName").Visible = False

        Me.DataGridView2.Columns("IT_DATEP").Visible = False
        Me.DataGridView2.Columns("IT_DATEEX").Visible = False
        Me.DataGridView2.Columns("USERNAME").Visible = False
        Me.DataGridView2.Columns("Auditor").Visible = False
        Me.DataGridView2.Columns("CUser").Visible = False
        Me.DataGridView2.Columns("COUser").Visible = False
        Me.DataGridView2.Columns("da").Visible = False
        Me.DataGridView2.Columns("ne").Visible = False
        Me.DataGridView2.Columns("da1").Visible = False
        Me.DataGridView2.Columns("ne1").Visible = False

        Me.DataGridView2.Columns("SKITM5").Visible = True
        Me.DataGridView2.Columns("SKITM7").Visible = True
        Me.DataGridView2.Columns("SKITM8").Visible = True
        Me.DataGridView2.Columns("SKITM5").Width = 155
        Me.DataGridView2.Columns("SKITM7").Width = 60
        Me.DataGridView2.Columns("SKITM8").Width = 60
        ''''''''''''''''''''''''''''''''''''''''''''''''
        Me.DataGridView2.Columns("SKITM5").HeaderText = "أسم الصنف"
        Me.DataGridView2.Columns("SKITM7").HeaderText = "الرصيد"
        Me.DataGridView2.Columns("SKITM8").HeaderText = "السعر"
        ''''
        Me.DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView2.MultiSelect = False
        With Me.DataGridView2
            .RowsDefaultCellStyle.BackColor = Color.Beige
            .AlternatingRowsDefaultCellStyle.BackColor = Color.White
        End With
    End Sub
    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Me.DataGridView1.CurrentRow.Cells("BITM3").Value = Me.num.ToString.Trim
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next
        If Me.DataGridView1.SelectedRows.Count = 0 Then
            Me.DataGridView1.Item("BITM2", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If DataGridView1.Item("BITM3", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("BITM3", e.RowIndex).Value = Me.num.ToString.Trim
            If DataGridView1.Item("BITM4", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("BITM4", e.RowIndex).Value = Me.cod.ToString.Trim
            Exit Sub
        End If
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
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
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timsum.Tick
        On Error Resume Next
        If Me.Ch1.Checked = True Then
            Dim dgvRow As New DataGridViewRow
            For Each dgvRow In Me.DataGridView1.Rows
                If dgvRow.Index Mod 2 = 0 Then
                    Me.DataGridView1.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.LightYellow
                End If
            Next
            Me.SEARCHSTOCKSITEMS()

            If Me.DataGridView1.Rows.Count = 0 Then

            Else
                Dim counter As Integer = Me.DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = Me.DataGridView1.RowCount Then
                    nextRow = Me.DataGridView1.Rows(0)
                    Me.Ch1.Checked = False
                    Me.txtq.Focus()
                    Me.Timsum.Stop()
                Else
                    nextRow = DataGridView1.Rows(counter)
                    nextRow.Selected = True
                    Me.SEARCHSTOCKSITEMS()
                    Me.UPDATEBALANCEITEMS()
                    Me.TextTotalPurchasePrice.Text = Format(Val(Me.TEXTUnitPrice.Text) * Val(Me.TextBalance.Text) * (100 - Val(Me.TXTDiscountA.Text)) / 100, "0.000")
                    Me.TEXTUnitPrice.Text = Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value()

                    SEARCHDATA.SEARCHMAXIDSTOCKS()
                    Me.TEXTCurrentBalance.Text = Format(Conversion.Val(ModuleGeneral.SumAmounTOTALSTOCKS(Me.DataGridView1.CurrentRow.Cells.Item("BITM4").Value.ToString.Trim, SEARCHDATA.MAXSTK1)), "0.000")

                    SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
                    Me.TextSTK1A.Text = SEARCHDATA.STK1A

                    SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
                    Me.TextSTK1B.Text = SEARCHDATA.STK1B
                    If Val(Me.TextSTK1A.Text) = 0 Then
                        Me.SaveStocks()
                    ElseIf Val(Me.TextSTK1B.Text) = Val(Me.TextMovementSymbol.EditValue) Then
                        Me.UpdatStocks()
                    Else
                        Me.UpdatStocks()
                    End If
                End If

                Me.DataGridView1.CurrentCell = nextRow.Cells("BITM2")
                nextRow.Selected = True
                Me.DataGridView1.Rows(counter).Selected = True
            End If
        End If
    End Sub

    Private Sub TextBox46_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextCheckNumber.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.CheckDate.Focus()
        End Select
    End Sub
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
        On Error Resume Next
        If Me.Ch1.Checked = True Then
            Me.DataGridView1.Focus()

            Me.Timsum.Start()
        ElseIf Me.Ch1.Checked = False Then
            Me.txtq.Focus()
            Me.Timsum.Stop()
        End If
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
        Dim F As New FrmSuppliersB
        F.Show()
    End Sub

    Private Sub CmdItems_Click(sender As Object, e As EventArgs) Handles CmdItems.Click
        On Error Resume Next
        Dim F As New FrmStocksA1
        F.Show()
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
    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub
End Class