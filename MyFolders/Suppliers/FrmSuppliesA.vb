Option Explicit Off

Imports System.Data.Common
Imports System.Data.SqlClient
Public Class FrmSuppliesA
<<<<<<< HEAD
    Inherits Form
=======
    Inherits System.Windows.Forms.Form
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Public WithEvents BS As New BindingSource
<<<<<<< HEAD
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
=======
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    ReadOnly ds As New DataSet
    ReadOnly dt As DataTable
    Public cod As String = ""
    Public num As String = ""
    Dim test As Integer
    Dim test2 As Integer
    Dim ik As Integer
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Private MOVD1T As String
    Private ReadOnly MOVD1F As String
    Dim p As Integer
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Dim Discount As Double = 0
    Dim CASHA As Double = 0
    ReadOnly SHEK As Double
    ReadOnly SHEK1 As Double
    Public CHA1 As String
    Public CHA3 As String
    Public CHA7 As String
    Public CHA8 As String
    Dim Store As Integer


<<<<<<< HEAD
    Private Sub FrmSuppliesA_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmSuppliesA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmSuppliesA_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub

    Private Sub FrmSuppliesA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.Button3_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.Button4_Click(sender, e)
                    Case Keys.F10
                        Me.ButtonTransferofAccounts_Click(sender, e)
                            'Case Keys.F11
                            '    Me.ButtonCUSTOMER_Click(sender, e)
                    Case Keys.F12
                        Me.Button2_Click(sender, e)
                    Case Keys.A And (e.Alt And Not e.Control And Not e.Shift)
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

<<<<<<< HEAD
    Private Sub FrmSuppliesA_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmSuppliesA_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
    End Sub

<<<<<<< HEAD
    Private Sub FrmSuppliesA_load1(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmSuppliesA_load1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.load1.Text = "تحميل البيانات"
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

        Me.FIRSTBUTTON.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        Me.TextFundValue.EditValue = 0
        PurchSales_Check = False
        TestkeyAccounts(keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No)
        End If
        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
    End Sub

    Public Sub DanLOd()
        On Error Resume Next
        Dim F As Boolean
        Dim T As Boolean
        F = False
        T = True
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Cash = True Then
            Me.Label9.Text = "فاتورة شـراء نقدى"
            With str1
                .CommandText = "SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY17, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne, da1, ne1  FROM BUYS where  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & T & "'and BUY2 ='" & Strings.Trim(Me.TB1) & "'or BUY4 ='" & Strings.Trim(Me.TB2) & "'or BUY5 ='" & Strings.Trim(Me.TB3) & "'ORDER BY BUY2"
<<<<<<< HEAD
                Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
=======
                Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End With
        Else
            Me.Label9.Text = "فاتورة شـراء أجـل"
            With str1
                .CommandText = "SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY17, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne , da1, ne1 FROM BUYS where  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & F & "'and BUY2 ='" & Strings.Trim(Me.TB1) & "'or BUY4 ='" & Strings.Trim(Me.TB2) & "'or BUY5 ='" & Strings.Trim(Me.TB3) & "'ORDER BY BUY2"
<<<<<<< HEAD
                Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
=======
                Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End With
        End If
        Me.ds.EnforceConstraints = False
        Consum.Open()
<<<<<<< HEAD
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT BITM1, BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM9, BITM10, ([BITM5] * [BITM6]) * (100 - [BITM7]) / 100 AS BITM8, BUY2 FROM BUYSITEMS ORDER BY BUY2"
            Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
        End With
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT BITM1, BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM9, BITM10, ([BITM5] * [BITM6]) * (100 - [BITM7]) / 100 AS BITM8, BUY2 FROM BUYSITEMS ORDER BY BUY2"
            Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
        End With
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds, "BUYS")
        Me.SqlDataAdapter2.Fill(Me.ds, "BUYSITEMS")
        Me.ds.Relations.Add("REL1", Me.ds.Tables("BUYS").Columns("BUY2"), Me.ds.Tables("BUYSITEMS").Columns("BUY2"), True)
        Me.BS.DataSource = Me.ds
        Me.BS.DataMember = "BUYS"
        Me.ds.EnforceConstraints = True
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.dt.DefaultView.AllowDelete = "REL1"
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Me.TextFundValue.EditValue = 0
        Me.RecordCount()
        '==============================
        Auditor("BUYS", "USERNAME", "BUY1", Me.TEXT1.Text, "")
        Logentry = Uses
        LabelLogentry.Text = Logentry
        FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboSupplierName)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.ListCreditAccount)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount1.Value, Me.ListCreditAccount1)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount2.Value, Me.ListCreditAccount2)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)

        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.ListCreditAccount.SelectedIndex = Me.TextChecksAccount.SelectedText
        Me.TEXT5CHANGED()
        Me.load1.Text = "إجمالي الفاتورة"
        Me.load1.Enabled = False

        'Me.DataGridView1_CurrentCellChanged(sender, e)

    End Sub

<<<<<<< HEAD
    Public Sub Load1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
=======
    Public Sub Load1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim F As Boolean
        Dim T As Boolean
        F = False
        T = True
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Cash = True Then
            Me.Label9.Text = "فاتورة شـراء نقدى"
            With str1
                .CommandText = "SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY17, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne, da1, ne1  FROM BUYS where  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & T & "'and BUY2 ='" & Strings.Trim(Me.TB1) & "'ORDER BY BUY2"
<<<<<<< HEAD
                Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
=======
                Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End With
        Else
            Me.Label9.Text = "فاتورة شـراء أجـل"
            With str1
                .CommandText = "SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY17, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne , da1, ne1 FROM BUYS where  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & F & "'and BUY2 ='" & Strings.Trim(Me.TB1) & "'ORDER BY BUY2"
<<<<<<< HEAD
                Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
=======
                Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End With
        End If
        Me.ds.EnforceConstraints = False
        Consum.Open()
<<<<<<< HEAD
        Dim str2 As New SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT BITM1, BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM9, BITM10, ([BITM5] * [BITM6]) * (100 - [BITM7]) / 100 AS BITM8, BUY2 FROM BUYSITEMS ORDER BY BUY2"
            Dim builder50 As New SqlCommandBuilder(SqlDataAdapter1)
        End With
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT BITM1, BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM9, BITM10, ([BITM5] * [BITM6]) * (100 - [BITM7]) / 100 AS BITM8, BUY2 FROM BUYSITEMS ORDER BY BUY2"
            Dim builder50 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
        End With
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds, "BUYS")
        Me.SqlDataAdapter2.Fill(Me.ds, "BUYSITEMS")
        Me.ds.Relations.Add("REL1", Me.ds.Tables("BUYS").Columns("BUY2"), Me.ds.Tables("BUYSITEMS").Columns("BUY2"), True)
        Me.BS.DataSource = Me.ds
        Me.BS.DataMember = "BUYS"
        Me.ds.EnforceConstraints = True
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.dt.DefaultView.AllowDelete = "REL1"
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Me.TextFundValue.EditValue = 0

        Me.RecordCount()
        '==============================

        LabelLogentry.Text = Logentry
        FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboSupplierName)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.ListCreditAccount)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount1.Value, Me.ListCreditAccount1)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.ListCreditAccount.SelectedIndex = Me.TextChecksAccount.SelectedText
        Me.TEXT5CHANGED()
        Me.load1.Text = "إجمالي الفاتورة"
        Me.load1.Enabled = False
        Me.DataGridView1_CurrentCellChanged(sender, e)
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboSupplierName, e, )
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboITEMNAME, e, )
    End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboITEMNAME, e, )
    End Sub

    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub

    Private Sub DISPLAYRECORD()
        On Error Resume Next
        'Me.TextFundValue.Clear()
        With Me
            .TEXT1.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY1").ToString
            .TEXTInvoiceNumberA.EditValue = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY2").ToString
            .DateMovementHistory.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY3").ToString
            .TEXTPermissionNumber.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY4").ToString
            .ComboSupplierName.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY5").ToString
            .TEXTItemsTotal.Text = Me.ds.Tables("BUYS").Rows(BS.Position)("BUY6").ToString
            .TEXTDiscountPercentage.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY7").ToString
            .TEXTDiscount.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY8").ToString
            .TEXTNetItems.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY9").ToString
            .TEXTTaxRate.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY10").ToString
            .TEXTSalesTaxes.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY11").ToString
            .TEXTInvoiceNumber.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY13").ToString
            .TextValueOfCheck.EditValue = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY14").ToString
            .TEXTTotaln.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY15").ToString
            .CheckTransferToAccounts.Checked = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY17").ToString
            .TextMovementSymbol.EditValue = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY18").ToString
            .CheckLogReview.Checked = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY19").ToString
            .ComboPaymentMethod.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY20").ToString
            .TextFundValue.EditValue = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY21").ToString
            .TEXTTotal.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY22").ToString
            .TextValueAccountsPayable.EditValue = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY23").ToString
            .ComboCheckDrawerName.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY24").ToString
            .TextCheckDrawerCode.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY25").ToString
            .TextCheckNumber.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY26").ToString
            .CheckDate.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY27").ToString
            .ComboStore.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("WarehouseNumber").ToString
            .TextWarehouseName.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("WarehouseName").ToString
            .ComboCB1.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("CB1").ToString
            .ComboBN2.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BN2").ToString
            '.CheckBox4.Checked = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("BUY28").ToString
            .RadioButton1.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("TYPE_CASH").ToString
            .RadioButton2.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("TYPE_CRDT").ToString
            .TEXTUserName.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("Auditor").ToString
            .TextDefinitionDirectorate.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("COUser").ToString
            .TEXTAddDate.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("da").ToString
            .TextTimeAdd.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("ne").ToString
            .TEXTReviewDate.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("da1").ToString
            .TextreviewTime.Text = Me.ds.Tables("BUYS").Rows(Me.BS.Position)("ne1").ToString
        End With

        Auditor("BUYS", "USERNAME", "BUY1", Me.TEXT1.Text, "")
        Logentry = Uses

        'Me.TEXT4_TextChanged(sender, e)
        If Val(Me.txtTotalDiscount.Text) > 0 Then
            Me.Panel25.Visible = True
        Else
            Me.Panel25.Visible = False
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
        If Me.BS.Position < Me.ds.Tables("BUYS").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.DISPLAYRECORD()
        Me.SEARCHSTOCKSITEMS()
        Me.SEARCHDMAXCASHIER()
        Me.AutoEx()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Call MangUsers()
        Me.TextFundValue.Refresh()
        Me.TEXT5CHANGED()
        Me.TEXTInvoiceNumberA.Enabled = False
        Me.Button3.Enabled = True
        Me.TEXTTotaln.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
    End Sub



<<<<<<< HEAD
    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        Me.TEXT5CHANGED()
    End Sub

    Private Sub TEXT4_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTItemsTotal.TextChanged, TEXTDiscountPercentage.EditValueChanged, TEXTTaxRate.EditValueChanged, TEXTDiscount.TextChanged, TEXTNetItems.TextChanged, TEXTSalesTaxes.TextChanged, TextValueOfCheck.EditValueChanged, TextFundValue.EditValueChanged, TextValueAccountsPayable.EditValueChanged, txtTotalDiscount.TextChanged
=======
    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        Me.TEXT5CHANGED()
    End Sub

    Private Sub TEXT4_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTItemsTotal.TextChanged, TEXTDiscountPercentage.EditValueChanged, TEXTTaxRate.EditValueChanged, TEXTDiscount.TextChanged, TEXTNetItems.TextChanged, TEXTSalesTaxes.TextChanged, TextValueOfCheck.EditValueChanged, TextFundValue.EditValueChanged, TextValueAccountsPayable.EditValueChanged, txtTotalDiscount.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim totl1 As Double
        Dim totl2 As Double
        Dim totl3 As Double

        Me.Discount = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM10").Value))
        Me.TEXTItemsTotal.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM8").Value)) + Val(Me.Discount)).ToString("0.000")

        totl3 = Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("BITM8").Value))
        Me.TEXTDiscount.Text = Format(Val(totl3) * Val(Me.TEXTDiscountPercentage.EditValue) / 100, "0.000") + Val(Me.Discount)
        'Me.TEXTNetItems.Text = Format(Val(Me.TEXTItemsTotal.Text) - (Val(Me.TEXTDiscount.Text) + Val(Me.Discount)), "0.000")
        Discount_B = Format(Val(Me.TEXTDiscount.Text), "0.000")
        Me.TEXTNetItems.Text = Format(Val(Me.TEXTItemsTotal.Text) - Val(Discount_B), "0.000")

        Me.TEXTSalesTaxes.Text = Format(Val(Me.TEXTItemsTotal.Text) * Val(Me.TEXTTaxRate.EditValue) / 100, "0.000")
        Me.txtTotalDiscount.Text = Format(Val(Discount_B), "0.000")

        totl1 = Val(Me.txtTotalDiscount.Text)
        totl2 = Format(Val(Me.TEXTItemsTotal.Text) + Val(Me.TEXTSalesTaxes.Text), "0.000")
        Me.TEXTTotal.Text = Format(Val(totl2), "0.000")
        Me.TEXTTotaln.Text = CurrencyJO(Val(Me.TEXTTotal.Text), "jO")
        'CASHA = totl2.ToString("0.000")
        TEXT5CHANGED()
    End Sub


    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
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
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.Background)
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

    Private Sub SaveBUYSITEMS()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO BUYSITEMS (BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM8, BITM9, BITM10, BUY2) VALUES     (@BITM2, @BITM3, @BITM4, @BITM5, @BITM6, @BITM7, @BITM8, @BITM9, @BITM10, @BUY2)", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO BUYSITEMS (BITM2, BITM3, BITM4, BITM5, BITM6, BITM7, BITM8, BITM9, BITM10, BUY2) VALUES     (@BITM2, @BITM3, @BITM4, @BITM5, @BITM6, @BITM7, @BITM8, @BITM9, @BITM10, @BUY2)", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
    End Sub

<<<<<<< HEAD
    Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
        Me.ButtonViewrestrictions_Click(sender, e)
=======
    Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
        Me.Button1_Click(sender, e)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.Button2.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonAttachDocument.Enabled = LockAddRow
        Me.CmdItems.Enabled = True
        Me.CmdCust.Enabled = True
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.TEXTInvoiceNumberA.Enabled = False
            Me.ComboSupplierName.Enabled = False
            Me.TEXTPermissionNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.txtItem2.Enabled = False
            Me.txtq.Enabled = False
            Me.TEXTDiscountPercentage.Enabled = False
            Me.TEXTTaxRate.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueAccountsPayable.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.CheckDate.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.Panel10.Enabled = False
            Me.Panel11.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.Panel6.Enabled = False
            Me.Panel7.Enabled = False
            Me.Panel8.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
            Me.PicCreditAccount1.Enabled = False
        ElseIf Me.CheckTransferToAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.ComboSupplierName.Enabled = True
            Me.TEXTPermissionNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.txtItem2.Enabled = True
            Me.txtq.Enabled = True
            Me.TEXTDiscountPercentage.Enabled = True
            Me.TEXTTaxRate.Enabled = True
            Me.ComboPaymentMethod.Enabled = True
            Me.TextFundValue.Enabled = True
            Me.TextValueAccountsPayable.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.CheckDate.Enabled = True
            Me.TextCheckNumber.Enabled = True
            Me.TextValueOfCheck.Enabled = True
            Me.Panel10.Enabled = True
            Me.Panel11.Enabled = True
            Me.Panel6.Enabled = True
            Me.Panel7.Enabled = True
            Me.Panel8.Enabled = True
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.Button3.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.Button2.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.TEXTInvoiceNumberA.Enabled = False
            Me.ComboSupplierName.Enabled = False
            Me.TEXTPermissionNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.txtItem2.Enabled = False
            Me.txtq.Enabled = False
            Me.TEXTDiscountPercentage.Enabled = False
            Me.TEXTTaxRate.Enabled = False
            Me.ComboPaymentMethod.Enabled = False
            Me.TextFundValue.Enabled = False
            Me.TextValueAccountsPayable.Enabled = False
            Me.ComboCheckDrawerName.Enabled = False
            Me.CheckDate.Enabled = False
            Me.TextCheckNumber.Enabled = False
            Me.TextValueOfCheck.Enabled = False
            Me.Panel10.Enabled = False
            Me.Panel11.Enabled = False
            Me.Panel6.Enabled = False
            Me.Panel7.Enabled = False
            Me.Panel8.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
            Me.PicCreditAccount1.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.ComboSupplierName.Enabled = True
            Me.TEXTPermissionNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.txtItem2.Enabled = True
            Me.txtq.Enabled = True
            Me.TEXTDiscountPercentage.Enabled = True
            Me.TEXTTaxRate.Enabled = True
            Me.ComboPaymentMethod.Enabled = True
            Me.TextFundValue.Enabled = True
            Me.TextValueAccountsPayable.Enabled = True
            Me.ComboCheckDrawerName.Enabled = True
            Me.CheckDate.Enabled = True
            Me.TextCheckNumber.Enabled = True
            Me.TextValueOfCheck.Enabled = True
            Me.Panel10.Enabled = True
            Me.Panel11.Enabled = True
            Me.Panel6.Enabled = True
            Me.Panel7.Enabled = True
            Me.Panel8.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.ComboDebitAccount.Enabled = True
            Me.PicCreditAccount.Enabled = True
            Me.PicCreditAccount1.Enabled = True
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As KeyEventArgs) Handles TEXTInvoiceNumberA.KeyDown, TEXT1.KeyDown, TEXTPermissionNumber.KeyDown, TEXTItemsTotal.KeyDown, TEXTNetItems.KeyDown, TEXTSalesTaxes.KeyDown, TEXTInvoiceNumber.KeyDown, TEXTTotaln.KeyDown, TEXTUserName.KeyDown, TEXTReferenceName.KeyDown, TEXTAddDate.KeyDown, DateMovementHistory.KeyDown, ComboSupplierName.KeyDown, TEXTDiscount.KeyDown
=======
    Private Sub TEXT2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTInvoiceNumberA.KeyDown, TEXT1.KeyDown, TEXTPermissionNumber.KeyDown, TEXTItemsTotal.KeyDown, TEXTNetItems.KeyDown, TEXTSalesTaxes.KeyDown, TEXTInvoiceNumber.KeyDown, TEXTTotaln.KeyDown, TEXTUserName.KeyDown, TEXTReferenceName.KeyDown, TEXTAddDate.KeyDown, DateMovementHistory.KeyDown, ComboSupplierName.KeyDown, TEXTDiscount.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                TEXTPermissionNumber.Focus()
        End Select
    End Sub

<<<<<<< HEAD
    Private Sub TEXT2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTInvoiceNumberA.LostFocus
=======
    Private Sub TEXT2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTInvoiceNumberA.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.BS.Position = P
    End Sub

<<<<<<< HEAD
    Private Sub TEXT2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTInvoiceNumberA.KeyPress
=======
    Private Sub TEXT2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTInvoiceNumberA.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            ComboSupplierName.Focus()
        End If
    End Sub


<<<<<<< HEAD
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboSupplierName.KeyPress
=======
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSupplierName.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            TEXTPermissionNumber.Focus()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TEXT3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTPermissionNumber.KeyPress
=======
    Private Sub TEXT3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTPermissionNumber.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            DateMovementHistory.Focus()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub DATETIMEPICKER_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles DateMovementHistory.KeyPress
=======
    Private Sub DATETIMEPICKER_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateMovementHistory.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            txtItem2.Focus()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferToAccounts.Checked = True Then
            MsgBox("لايمكن حذف السجل الحالى لأنه مرحل ... يمكن حذف من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If

        Me.DELETEDATBANK()
        Me.DELETEDATCASHIER()
        Me.DELETEDATACUSTOMER1()
        Me.DELETEDATMOVESDATA()
        Me.DELETEDATMOVESDATA1()
        Me.DELETEDATMOVESDATARecord()
        Me.DELETEDATBANK1()
        MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, Me.BS, True)

        MYDELETERECORD("BUYS", "BUY1", Me.TEXT1, Me.BS, True)
        MYDELETERECORD("BUYSITEMS", "BUY2", Me.TEXTInvoiceNumberA, Me.BS, True)
        'Me.danLOd()
        Insert_Actions(Me.TEXT1.Text.Trim, "حذف", Me.Text)
    End Sub

<<<<<<< HEAD
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
=======
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        If Me.CheckTransferToAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.UPDATEBUYS()
        Me.DanLOd()
        Me.BS.Position = P
        Me.UPDATEBUYS()
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXT1.Text.Trim, "مراجعة", Me.Text)
        Me.RecordCount()
    End Sub

<<<<<<< HEAD
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        P = BS.Position
        P = BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TextDefinitionDirectorate.Text = COUser
        Me.UPDATEBUYS()
        Me.DanLOd()
        Me.BS.Position = P
        Me.UPDATEBUYS()
        Me.RecordCount()
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXT1.Text.Trim, "إلغاء المراجعة", Me.Text)
    End Sub

<<<<<<< HEAD
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles FIRSTBUTTON.Click
=======
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PREVIOUSBUTTON.Click
=======
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles NEXTBUTTON.Click
=======
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
<<<<<<< HEAD
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles LASTBUTTON.Click
=======
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub

<<<<<<< HEAD
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim ch As Double
        Dim ch11 As Double
        ch = Me.TextFundValue.EditValue
        ch11 = Me.TextFundBalance.Text
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(Me.DateMovementHistory.Value.ToString) > FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If ch11 < ch Then
                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                Exit Sub
            End If
            Dim ch1 As Double
            Dim ch2 As Double
<<<<<<< HEAD
            ch1 = Convert.ToDouble(TEXTTotal.Text) - Convert.ToDouble(Discount_B)
=======
            ch1 = Val(TEXTTotal.Text).ToString("0.000") - Val(Discount_B).ToString("0.000")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CASHA = Val(ch1).ToString("0.000")
            ch2 = Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextValueAccountsPayable.EditValue)
            If Val(CASHA).ToString("0.000") <> Val(ch2).ToString("0.000") Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك والذمم الدائنة واجمالي الخصم مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = True Then
                MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
                Exit Sub
            End If
            Me.DataGridView1.ClearSelection()
            Dim nextRow As DataGridViewRow
            nextRow = Me.DataGridView1.Rows(0)
            Me.DataGridView1.Rows(0).Selected = True
            DataGridView1.CurrentCell = DataGridView1("BITM2", DataGridView1.Rows(0).Index)

            'Dim indx As Integer = DataGridView1.CurrentRow.Index
            'Me.DataGridView1.CurrentCell = Me.DataGridView1.Rows(indx).Cells("BITM2")
            'Me.DataGridView1.Rows(indx).Selected = True

            If Me.Ch1.Checked = False Then
                Me.Ch1.Checked = True
            End If
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Static Dim P As Integer
            P = Me.BS.Position
            Me.UPDATEBUYS()
            Me.SaveBUYSITEMS()
            Me.UPDATEBUYSITEMS() ' البنود
            Me.DanLOd()
            nextRow = Me.DataGridView1.Rows(0)
            Me.DataGridView1.Rows(0).Selected = True
            Me.BS.Position = P
            Me.UPDATEBUYS() '  راس الفاتورة
            Me.UPDATEBUYSITEMS() ' البنود
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل  ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try

    End Sub

    Private Sub UPDATEBUYS()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update BUYS SET  BUY1 = @BUY1, BUY3 = @BUY3, BUY4 = @BUY4, BUY5 = @BUY5, BUY6 = @BUY6, BUY7 = @BUY7, BUY8 = @BUY8, BUY9 = @BUY9, BUY10 = @BUY10, BUY11 = @BUY11, BUY13 = @BUY13, BUY14 = @BUY14, BUY15 = @BUY15, BUY17 = @BUY17, BUY18 = @BUY18, BUY19 = @BUY19, BUY20 = @BUY20, BUY21 = @BUY21, BUY22 = @BUY22, BUY23 = @BUY23, BUY24 = @BUY24, BUY25 = @BUY25, BUY26 = @BUY26, BUY27 = @BUY27,WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, Deleted = @Deleted, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, BUY16 = @BUY16, TYPE_CASH = @TYPE_CASH, TYPE_CRDT = @TYPE_CRDT WHERE  BUY2 = @BUY2", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update BUYS SET  BUY1 = @BUY1, BUY3 = @BUY3, BUY4 = @BUY4, BUY5 = @BUY5, BUY6 = @BUY6, BUY7 = @BUY7, BUY8 = @BUY8, BUY9 = @BUY9, BUY10 = @BUY10, BUY11 = @BUY11, BUY13 = @BUY13, BUY14 = @BUY14, BUY15 = @BUY15, BUY17 = @BUY17, BUY18 = @BUY18, BUY19 = @BUY19, BUY20 = @BUY20, BUY21 = @BUY21, BUY22 = @BUY22, BUY23 = @BUY23, BUY24 = @BUY24, BUY25 = @BUY25, BUY26 = @BUY26, BUY27 = @BUY27,WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName,  CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, Deleted = @Deleted, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1, BUY16 = @BUY16, TYPE_CASH = @TYPE_CASH, TYPE_CRDT = @TYPE_CRDT WHERE  BUY2 = @BUY2", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@BUY2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumberA.EditValue
                .Parameters.Add("@BUY1", SqlDbType.Int).Value = Me.TEXT1.Text.Trim
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
                .Parameters.Add("@BUY14", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue.Trim
                .Parameters.Add("@BUY15", SqlDbType.NVarChar).Value = Me.TEXTTotaln.Text.Trim
                .Parameters.Add("@BUY17", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
                .Parameters.Add("@BUY18", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@BUY19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@BUY20", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text.Trim
                .Parameters.Add("@BUY21", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue.Trim
                .Parameters.Add("@BUY22", SqlDbType.NVarChar).Value = Me.TEXTTotal.Text.Trim
                .Parameters.Add("@BUY23", SqlDbType.NVarChar).Value = Me.TextValueAccountsPayable.EditValue.Trim
                .Parameters.Add("@BUY24", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text.Trim
                .Parameters.Add("@BUY25", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text.Trim
                .Parameters.Add("@BUY26", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@BUY27", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Store
                .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text

                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@Deleted", SqlDbType.Bit).Value = Convert.ToInt32(CheckBox1.Checked)
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

    Private Sub UPDATEBUYSITEMS()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update BUYSITEMS SET BITM2 = @BITM2, BITM3 = @BITM3, BITM4 = @BITM4, BITM5 = @BITM5, BITM6 = @BITM6, BITM7 = @BITM7, BITM8 = @BITM8, BITM9 = @BITM9, BITM10 = @BITM10, BUY2 = @BUY2  WHERE   BITM1 = @BITM1", Consum)
        Dim CMD As New SqlCommand With {
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("Update BUYSITEMS SET BITM2 = @BITM2, BITM3 = @BITM3, BITM4 = @BITM4, BITM5 = @BITM5, BITM6 = @BITM6, BITM7 = @BITM7, BITM8 = @BITM8, BITM9 = @BITM9, BITM10 = @BITM10, BUY2 = @BUY2  WHERE   BITM1 = @BITM1", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            .Parameters.Add("@BITM5", SqlDbType.Float, 8, "BITM5").Value = DataGridView1.Item("BITM5", DataGridView1.CurrentRow.Index).Value
            .Parameters.Add("@BITM6", SqlDbType.Float, 8, "BITM6").Value = DataGridView1.Item("BITM6", DataGridView1.CurrentRow.Index).Value
            .Parameters.Add("@BITM7", SqlDbType.Float, 8, "BITM7").Value = DataGridView1.Item("BITM7", DataGridView1.CurrentRow.Index).Value
            .Parameters.Add("@BITM8", SqlDbType.Float, 8, "BITM8").Value = DataGridView1.Item("BITM8", DataGridView1.CurrentRow.Index).Value
            .Parameters.Add("@BITM9", SqlDbType.Float, 8, "BITM9").Value = DataGridView1.Item("BITM9", DataGridView1.CurrentRow.Index).Value
            .Parameters.Add("@BITM10", SqlDbType.Float, 8, "BITM10").Value = DataGridView1.Item("BITM10", DataGridView1.CurrentRow.Index).Value
            .Parameters.Add("@BUY2", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumberA.EditValue


            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "BUYSITEMS", New DataColumnMapping() {New DataColumnMapping("BITM1", "BITM1"), New DataColumnMapping("BITM2", "BITM2"), New DataColumnMapping("BITM3", "BITM3"), New DataColumnMapping("BITM4", "BITM4"), New DataColumnMapping("BITM5", "BITM5"), New DataColumnMapping("BITM6", "BITM6"), New DataColumnMapping("BITM7", "BITM7"), New DataColumnMapping("BITM8", "BITM8"), New DataColumnMapping("BITM9", "BITM9"), New DataColumnMapping("BUY2", "BUY2")})})
        SqlDataAdapter2.UpdateCommand = CMD
        SqlDataAdapter2.Update(ds, "BUYSITEMS")
        Consum.Close()
    End Sub


<<<<<<< HEAD
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
=======
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Try
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = True Then
                MsgBox("لايمكن حذف السجلات المحددة لأنه مرحل ... ", 16, "تنبيه")
                Exit Sub
            End If
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                Dim x As Integer = Me.DataGridView1.CurrentRow.Index
                Dim x1 As Integer = Me.DataGridView1.Rows(x).Cells("BITM1").Value
                Dim SQL2 As New SqlCommand("DELETE FROM BUYSITEMS WHERE BITM1=" & x1, Consum)
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                SQL2.ExecuteNonQuery()
                Consum.Close()
                MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, Me.BS, True)
                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                Next
            Else
                MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
            End If
            Me.TEXTTotaln.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Insert_Actions(Me.TEXT1.Text.Trim, "حذف سجل من الشبكة", Me.Text)
            Exit Sub

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT SKITM4,SKITM5,SKITM8,SKITM14,SKITM5 FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4 = '" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value & " '", Consum)
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT SKITM4,SKITM5,SKITM8,SKITM14,SKITM5 FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4 = '" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value & " '", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
=======
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        'Dim total As Double
        'Dim tota2 As Double
        'Dim tota3 As Double

        Dim VS1 As Double = "0.000"
        Dim VS2 As Double = "0.000"
        'Me.DataGridView1.CurrentRow.Cells("BITM10").Value = Val(Me.DataGridView1.CurrentRow.Cells("BITM8").Value * Me.DataGridView1.CurrentRow.Cells("BITM7").Value) / 100

        VS1 = Format(Val(Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value), "0.000")
        Me.DataGridView1.CurrentRow.Cells("BITM10").Value = Val(VS1) * Val(Me.DataGridView1.Item("BITM7", Me.DataGridView1.CurrentRow.Index).Value) / 100

        VS2 = Format(Val(VS1) * Val(Me.DataGridView1.Item("BITM7", Me.DataGridView1.CurrentRow.Index).Value) / 100, "0.000")
        Me.DataGridView1.CurrentRow.Cells("BITM8").Value = Val(Me.DataGridView1.CurrentRow.Cells("BITM5").Value * Me.DataGridView1.CurrentRow.Cells("BITM6").Value) - Val(VS2)



        'For Each r As DataGridViewRow In DataGridView1.Rows
        '    total += CDbl(r.Cells("BITM8").Value)
        '    Me.Discount += CDbl(r.Cells("BITM10").Value)
        'Next
        Me.Timsum.Start()
        'Me.TEXT4.Text = Val(total.ToString("0.000"))
        'Me.txtDiscount.Text = Me.Discount.ToString("0.000") + Val(Me.TEXT6.Text)
        'Me.TEXT4_TextChanged(sender, e)
        'Me.TextBox14_TextChanged(sender, e)

    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectionChanged
=======
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim total As Double
        Me.SEARCHSTOCKSITEMS()
        'Me.TextBox14_TextChanged(sender, e)
        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
        Me.TextBalance.Text = Format(Val(Me.DataGridView1.CurrentRow.Cells("BITM6").Value), "0.000")
        If DataGridView1.SelectedRows.Count = 0 Then Return
        DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.SelectedRows(0).Index

        'For Each r As DataGridViewRow In DataGridView1.Rows
        '    total += CDbl(r.Cells("BITM8").Value)
        '    Me.Discount += CDbl(r.Cells("BITM10").Value)
        'Next
        'Me.TEXT4.Text = Val(total.ToString("0.000"))
        'Me.txtDiscount.Text = Val(Me.Discount.ToString("0.000")) ' + Val(Me.TEXT6.Text)
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        Exit Sub
    End Sub
    Private Sub DataGridView1_Sorted(ByVal sender As System.Object, ByVal e As EventArgs) Handles DataGridView1.Sorted
=======
    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        Exit Sub
    End Sub
    Private Sub DataGridView1_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView1.Sorted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        DataGridView1.CurrentRow.Selected = Nothing
    End Sub



<<<<<<< HEAD
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button2.Click
=======
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim S As Integer
        S = Me.BS.Position
        Dim resault As Integer
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If BS.Count > 0 Then
            resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If Me.DataGridView1.SelectedRows.Count > 0 Then
                    Dim x As Integer = Me.DataGridView1.CurrentRow.Index
                    Dim x1 As Integer = Me.DataGridView1.Rows(x).Cells("BITM1").Value
                    Dim SQL2 As New SqlCommand("DELETE FROM BUYSITEMS WHERE BITM1=" & x1, Consum)
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    SQL2.ExecuteNonQuery()
                    Consum.Close()
                    MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, Me.BS, True)
                    For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                        Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                    Next
                Else
                    MsgBox("حدد السلعة بشكل جيد ", MsgBoxStyle.Critical, "تنبيه")
                End If
                Me.DanLOd()
                Me.BS.Position = S
                Me.DanLOd()
                Me.TEXTTotaln.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
                Insert_Actions(Me.TEXT1.Text.Trim, "حذف سجل من الشبكة", Me.Text)
            Else
                MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            MessageBox.Show(" لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub

<<<<<<< HEAD
    Private Sub CmdCust_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdCust.Click
=======
    Private Sub CmdCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdCust.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim F As New FrmSuppliersB
        F.Show()
    End Sub

<<<<<<< HEAD
    Private Sub CmdItems_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles CmdItems.Click
=======
    Private Sub CmdItems_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdItems.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim F As New FrmStocksA1
        F.Show()
    End Sub

    Private Sub DELETEDATCASHIER()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub



    Private Sub DELETEDATCASHIER1()
        Try
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber1, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATACUSTOMER1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim sql As String = "DELETE FROM Suppliers1  WHERE CAB8 = '" & Me.TEXTInvoiceNumberA.EditValue & "'" & "AND CAB12 ='نقدا'" & " AND CAB18='" & Me.TextMovementSymbol.EditValue & "'"
        Dim cmd As New SqlCommand(sql, Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "DELETE FROM Suppliers1  WHERE CAB8 = '" & Me.TEXTInvoiceNumberA.EditValue & "'" & "AND CAB12 ='نقدا'" & " AND CAB18='" & Me.TextMovementSymbol.EditValue & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
=======
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")

        If ds.Tables(0).Rows.Count > 0 Then
            Me.account_noF = ds2.Tables(0).Rows(0).Item(0)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(2)
            Me.account_nameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.account_noF = ""
            Me.ACCF = ""
            Me.account_nameF = ""
        End If
        Me.TextMovementRestrictions1.Text = Me.account_nameF
    End Sub


    Private Sub SEARCHSTOCKSITEMS()
        Dim Tax As Boolean
        Dim Tax1 As Boolean
        Dim Tax2 As String
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If DataGridView1.Rows.Count > 0 Then
            For i As Integer = 0 To DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = DataGridView1.Rows(i)
                If row.IsNewRow Then Continue For

<<<<<<< HEAD
                Dim strsql1 As New SqlCommand("SELECT SKITM3,SKITM4,SKITM5,SKITM6,SKITM8,SKITM9,SKITM11,SKITM12,SKITM14,SKITM15,SKITM16,SKITM17,SKITM18,SKITM19,SKITM20,SKITM21,SKITM22,SKITM23,SKITM24,SKITM25,SKITM26,IT_DATEP,IT_DATEEX FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4='" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                Dim ds As New DataSet
                Dim Adp1 As New SqlDataAdapter(strsql1)
=======
                Dim strsql1 As New SqlClient.SqlCommand("SELECT SKITM3,SKITM4,SKITM5,SKITM6,SKITM8,SKITM9,SKITM11,SKITM12,SKITM14,SKITM15,SKITM16,SKITM17,SKITM18,SKITM19,SKITM20,SKITM21,SKITM22,SKITM23,SKITM24,SKITM25,SKITM26,IT_DATEP,IT_DATEEX FROM STOCKSITEMS WHERE CUser ='" & CUser & "'  and SKITM4='" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                Dim ds As New DataSet
                Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                On Error Resume Next
                ds.Clear()
                Adp1.Fill(ds, "STOCKSITEMS")
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextGroupName.Text = ds.Tables(0).Rows(0).Item("SKITM3")
                    Tax2 = ds.Tables(0).Rows(0).Item(1)
                    Me.ComboITEMNAME.Text = ds.Tables(0).Rows(0).Item("SKITM5")
                    Me.TextHashUnit.Text = ds.Tables(0).Rows(0).Item("SKITM6")
                    Me.TEXTUnitPrice.Text = ds.Tables(0).Rows(0).Item("SKITM8")
                    Me.TXTDiscount.Text = ds.Tables(0).Rows(0).Item("SKITM9")
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

    Private Sub SEARCHDMAXCASHIER()
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

    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "فاتورة رقم" & " " & ":" & " " & Me.TEXT1.Text & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "من حساب المشتريات" & vbNewLine
        LabelStatement.Text = ExResult
    End Sub


    Private Sub DELETEDATMOVESDATARecord()
        Try
            If DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    MYDELETERECORD("MOVESDATA", "MOV2", Me.TextMovementRestrictions.Text, Me.BS, True)
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub




    Private Sub SaveStocks()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            GetAutoIDSTK()
            Dim SQL As String = "INSERT INTO STOCKS(STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     ( @STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            GetAutoIDSTK()
            Dim SQL As String = "INSERT INTO STOCKS(STK1, WarehouseNumber, WarehouseName,  STK3, STK4, STK5, STK6, STK7, STK8, STK9, STK10, STK11, STK12, STK13, STK14, STK15, STK16, STK17, STK18, STK19, STK20, STK21, STK22, STK23, STK25, STK24, STK26, USERNAME, CUser, COUser, da, ne, IT_DATEP, IT_DATEEX) VALUES     ( @STK1, @WarehouseNumber, @WarehouseName, @STK3, @STK4, @STK5, @STK6, @STK7, @STK8, @STK9, @STK10, @STK11, @STK12, @STK13, @STK14, @STK15, @STK16, @STK17, @STK18, @STK19, @STK20, @STK21, @STK22, @STK23, @STK25, @STK24, @STK26, @USERNAME, @CUser, @COUser, @da, @ne, @IT_DATEP, @IT_DATEEX)"
            Dim CMD As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
                .AddWithValue("@STK13", Format(Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM4").Value, IDSTK)), "0.000") + Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK14", Me.TEXTOrderLimit.Text)
                .AddWithValue("@STK15", Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK16", Me.TextMovementSymbol.EditValue)
                .AddWithValue("@STK17", Me.TXTDiscount.Text)
                .AddWithValue("@STK18", Format(Val(Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(Me.TXTDiscount.Text)) / 100, "0.000"))
                .AddWithValue("@STK19", Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK20", Format(Val(Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(Me.DataGridView1.Rows(Me.DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000"))
                .AddWithValue("@STK21", Me.TextDiscountPercentageWhenSelling.Text)
                .AddWithValue("@STK22", Me.TextLowestDiscountRateWhenSelling.Text)
                .AddWithValue("@STK23", Me.TextHighestDiscountRateWhenSelling.Text)
                .AddWithValue("@STK24", Convert.ToInt32(Me.CheckPricesMentionedIncludeSalesTax.Checked).ToString)
                .AddWithValue("@STK25", Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value)
                .AddWithValue("@STK26", Convert.ToInt32(Me.CheckItemIsSubjectToSalesTax.Checked).ToString)
                .AddWithValue("@USERNAME", USERNAME)
                .AddWithValue("@CUser", CUser)
                .AddWithValue("@COUser", COUser)
                .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                .AddWithValue("@IT_DATEP", ProductionDate.Text)
                .AddWithValue("@IT_DATEEX", ExpiryDate.Text)
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

    Private Sub UpdatEBALANCEITEMS()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
<<<<<<< HEAD
                    Dim sql As New SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @SKITM7  WHERE STOCKSITEMS.SKITM4='" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                    Dim CMD As New SqlCommand With {
=======
                    Dim sql As New SqlClient.SqlCommand("UPDATE STOCKSITEMS SET SKITM7 = @SKITM7  WHERE STOCKSITEMS.SKITM4='" & DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim idSTK As Int64
            GetAutoNumber("STK1", "STOCKS", "STK4")
            idSTK = AutoNumber
            Consum.Close()
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
<<<<<<< HEAD
                    Dim SQL As New SqlCommand(" Update STOCKS SET WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK3 = @STK3, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK25 = @STK25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE STK1 ='" & Me.TextSTK1A.Text & "'" & "AND STK7= '" & Me.DataGridView1.CurrentRow.Cells("BITM3").Value & "'", Consum)
                    Dim CMD As New SqlCommand(SQL.CommandText) With {
=======
                    Dim SQL As New SqlClient.SqlCommand(" Update STOCKS SET WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, STK3 = @STK3, STK7 = @STK7, STK8 = @STK8, STK9 = @STK9, STK10 = @STK10, STK11 = @STK11, STK12 = @STK12, STK13 = @STK13, STK14 = @STK14, STK15 = @STK15, STK17 = @STK17, STK18 = @STK18, STK19 = @STK19, STK20 = @STK20, STK21 = @STK21, STK22 = @STK22, STK23 = @STK23, STK25 = @STK25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE STK1 ='" & Me.TextSTK1A.Text & "'" & "AND STK7= '" & Me.DataGridView1.CurrentRow.Cells("BITM3").Value & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand(SQL.CommandText) With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
                        .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text
                        .Parameters.Add("@STK3", SqlDbType.NVarChar).Value = TEXTPermissionNumber.Text
                        .Parameters.Add("@STK7", SqlDbType.NVarChar).Value = DataGridView1.Item("BITM3", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK8", SqlDbType.NVarChar).Value = TextGroupName.Text
                        .Parameters.Add("@STK9", SqlDbType.NVarChar).Value = TextHashUnit.Text
                        .Parameters.Add("@STK10", SqlDbType.Float).Value = Format(Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("BITM4").Value, idSTK)), "0.000")
                        .Parameters.Add("@STK11", SqlDbType.Float).Value = DataGridView1.Item("BITM6", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK12", SqlDbType.Float).Value = "0"
                        .Parameters.Add("@STK13", SqlDbType.Float).Value = Format(Val(SumAmounTOTALSTOCKS(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("BITM4").Value, idSTK)), "0.000") + DataGridView1.Item("BITM6", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK14", SqlDbType.Float).Value = TEXTOrderLimit.Text
                        .Parameters.Add("@STK15", SqlDbType.Float).Value = TEXTUnitPrice.Text
                        .Parameters.Add("@STK17", SqlDbType.Float).Value = TXTDiscount.Text
                        .Parameters.Add("@STK18", SqlDbType.Float).Value = Format(Val(DataGridView1.Item("BITM5", DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(TXTDiscount.Text)) / 100, "0.000")
                        .Parameters.Add("@STK19", SqlDbType.Float).Value = DataGridView1.Item("BITM9", DataGridView1.CurrentRow.Index).Value
                        .Parameters.Add("@STK20", SqlDbType.Float).Value = Format(Val(DataGridView1.Item("BITM9", DataGridView1.CurrentRow.Index).Value) * Val(Format(Val(DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells("BITM6").Value), "0.000")) * (100 - Val(TextDiscountPercentageWhenSelling.Text)) / 100, "0.000")
                        .Parameters.Add("@STK21", SqlDbType.Float).Value = TextDiscountPercentageWhenSelling.Text
                        .Parameters.Add("@STK22", SqlDbType.Float).Value = TextLowestDiscountRateWhenSelling.Text
                        .Parameters.Add("@STK23", SqlDbType.Float).Value = TextHighestDiscountRateWhenSelling.Text
                        .Parameters.Add("@STK25", SqlDbType.Int).Value = DataGridView1.Item("BITM4", DataGridView1.CurrentRow.Index).Value
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
            MessageBox.Show(ex.Message, "ErrorUpdatStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub DELETEDATRECORD()
        Try
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    MYDELETERECORD("STOCKS", "STK1", Me.TextSTK1A, Me.BS, True)
                    Consum.Close()
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Sub AccountingprocedureA()
        'Accountingprocedure = True
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCalculatingTaxAccount.Text}))
            End If
            If Me.ComboPaymentMethod.Text = "نقدا_شيك" Or Me.ComboPaymentMethod.Text = "نقدا_شيك_ذمم_دائنة" Then
                Connection.ACONET1.Add("الصندوق")
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextChecksAccount.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextChecksAccount.Text}))
            End If
            Connection.ACONET1.Add(String.Concat(New String() {Me.TextAccountsPayableAccount.Text}))
            If Val(Me.txtTotalDiscount.Text) > 0 Then
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextDiscountAccountAE.Text}))
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

    Private Sub OptionsTransforAccounts()
        If ComboDebitAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            DebitAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
            DebitAccount_Cod = ID_Nam
        End If
        If TextChecksAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextChecksAccount.Text, 1)
            ChecksAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextChecksAccount.Text, 1)
            ChecksAccount_Cod = ID_Nam
        End If
        If TextAccountsPayableAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextAccountsPayableAccount.Text, 1)
            PayableAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextAccountsPayableAccount.Text, 1)
            PayableAccount_Cod = ID_Nam
        End If
        If TextCalculatingTaxAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCalculatingTaxAccount.Text, 1)
            PurchSalesCalculatingTax_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCalculatingTaxAccount.Text, 1)
            TaxAccount_Cod = ID_Nam
        End If
        If TextDiscountAccountAE.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextDiscountAccountAE.Text, 1)
            PurchSalesDiscount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextDiscountAccountAE.Text, 1)
            DiscountAccount_Cod = ID_Nam
        End If
    End Sub

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                OptionsTransforAccounts()
                PanelAccount.Enabled = True
            Else
                Check_OptionsTransforAccounts.Checked = False
                PanelAccount.Enabled = False
            End If
        Else
            PanelAccount.Enabled = False
        End If
    End Sub

    Private Sub TransforAccounts()
        Try
            nem = " فاتورة مشتريات رقم " & "_" & Me.TEXTInvoiceNumberA.EditValue
            nem1 = " فاتورة مشتريات نقدي رقم " & "_" & Me.TextFundMovementNumber.Text
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
            GetPurchSales_Check()

            GetFundAccount_No(ModuleGeneral.CB2)
            Accounts_NO = FundAccount_No

            GetDiscount_B(Val(Me.TEXTDiscount.Text))
            GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))

            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
            CodAccount = ID_Nam

            If Check_OptionsTransforAccounts.Checked = True Then
                OptionsTransforAccounts()
            End If
            Dim ch As Double
            Discount = Me.txtTotalDiscount.Text
<<<<<<< HEAD
            ch = Format(Val(Me.TEXTNetItems.Text) + Convert.ToDouble(Discount_B), "0.000")
=======
            ch = Format(Val(Me.TEXTNetItems.Text) + Val(Discount_B), "0.000")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), LabelStatement.Text, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قيد", "PR", TextMovementSymbol.EditValue, False)
            If OBCHK5 = True Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                Else
                    PMO2 = Val(PMO2 - 1)
                End If
                DetailsAccountingEntries(PMO2 + 2, TextChecksAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                If Val(Me.txtTotalDiscount.Text) > 0 Then
                    DetailsAccountingEntries(PMO2 + 3, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                End If
            Else
                If ComboPaymentMethod.Text.Trim = "نقدا" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If

                    DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                ElseIf ComboPaymentMethod.Text.Trim = "شيك" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, TextChecksAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                ElseIf ComboPaymentMethod.Text.Trim = "نقدا_شيك" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 3, TextChecksAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 4, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)
                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                ElseIf ComboPaymentMethod.Text.Trim = "ذمم_دائنة" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, TextAccountsPayableAccount.Text, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                ElseIf ComboPaymentMethod.Text.Trim = "نقدا_ذمم_دائنة" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue.Trim, nem1, CodAccount, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 3, TextAccountsPayableAccount.Text, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 4, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)
                    Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                ElseIf Me.ComboPaymentMethod.Text = "شيك_ذمم_دائنة" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If

                    DetailsAccountingEntries(PMO2 + 2, TextChecksAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 3, TextAccountsPayableAccount.Text, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 4, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)
                    Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

                ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك_ذمم_دائنة" Then
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(ch), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.TEXTSalesTaxes.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 1, TextCalculatingTaxAccount.Text, PurchSalesCalculatingTax_No, TEXTSalesTaxes.Text, 0, nem5, TaxAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 2, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 3, TextChecksAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 4, TextAccountsPayableAccount.Text, PayableAccount_NO, 0, TextValueAccountsPayable.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    If Val(Me.txtTotalDiscount.Text) > 0 Then
                        DetailsAccountingEntries(PMO2 + 5, TextDiscountAccountAE.Text, PurchSalesDiscount_No, 0, TEXTDiscount.Text, nem1, DiscountAccount_Cod, TextMovementSymbol.EditValue, TEXT1.Text, False, T2)
                    End If
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, ComboSupplierName.Text, False, TEXTInvoiceNumberA.EditValue, False, True, ComboCB1.Text, ModuleGeneral.CB2)
                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)
                    Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextValueAccountsPayable.EditValue, PaymentMethod, TEXTInvoiceNumberA.EditValue,
                               "من حساب حركة المورد" & "_" & Me.ComboSupplierName.Text, ComboSupplierName.Text, TextSupplierNumber.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)
                End If
            End If

        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorSaveMOVESDATARecord", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub TEXT5CHANGED()
        On Error Resume Next
        PurchSales_Check = False
        CalculatingTax_B = Val(Me.TEXTSalesTaxes.Text)
<<<<<<< HEAD
        CASHA = Convert.ToDouble(TEXTTotal.Text) - Convert.ToDouble(Discount_B)
=======
        CASHA = Val(TEXTTotal.Text).ToString("0.000") - Val(Discount_B).ToString("0.000")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing
        AccountsPayableAccount_Name = Nothing

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        GetDiscount_B(Val(Me.TEXTDiscount.Text))
        GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))

        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

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
                LabelChecksAccount.Text = FundAccount_Name
                TextChecksAccount.Text = FundAccount_Name
                TextAccountsPayableAccount.Text = Nothing
                NUpCreditAccount.Value = ChecksAccount_Cod

                NUpCreditAccount.Enabled = True
                NUpCreditAccount1.Enabled = False
                PicCreditAccount.Enabled = True
                PicCreditAccount1.Enabled = False
            Case "شيك"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.TextValueAccountsPayable.Enabled = False
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueAccountsPayable.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = Format(Val(CASHA), "0.000")
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextChecksAccount.Text = ChecksAccount_Name
                TextAccountsPayableAccount.Text = Nothing
                NUpCreditAccount.Value = ChecksAccount_Cod
                LabelChecksAccount.Text = "حساب شيكات صادرة"

                NUpCreditAccount.Enabled = True
                NUpCreditAccount1.Enabled = False
                PicCreditAccount.Enabled = True
                PicCreditAccount1.Enabled = False
            Case "نقدا_شيك"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.TextValueAccountsPayable.Enabled = False
                Me.TextValueAccountsPayable.EditValue = "0.000"
                Me.TextFundValue.EditValue = Format(Val(CASHA) - Val(Me.TextValueOfCheck.EditValue), "0.000")
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextChecksAccount.Text = ChecksAccount_Name

                TextAccountsPayableAccount.Text = Nothing
                NUpCreditAccount.Value = ChecksAccount_Cod
                LabelChecksAccount.Text = "حساب شيكات صادرة"

                NUpCreditAccount.Enabled = True
                NUpCreditAccount1.Enabled = False
                PicCreditAccount.Enabled = True
                PicCreditAccount1.Enabled = False
            Case "ذمم_دائنة"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = False
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = "0.000"
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.TextValueAccountsPayable.EditValue = Format(Val(CASHA), "0.000")
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextChecksAccount.Text = Nothing
                TextAccountsPayableAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount1.Value = PayableAccount_Cod
                LabelChecksAccount.Text = "حساب شيكات صادرة"

                NUpCreditAccount1.Enabled = True
                NUpCreditAccount.Enabled = False
                PicCreditAccount1.Enabled = True
                PicCreditAccount.Enabled = False
            Case "نقدا_ذمم_دائنة"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = Format(Val(CASHA) - Val(Me.TextValueAccountsPayable.EditValue), "0.000")
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                LabelChecksAccount.Text = FundAccount_Name
                TextChecksAccount.Text = Nothing
                TextAccountsPayableAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount1.Value = PayableAccount_Cod

                NUpCreditAccount1.Enabled = True
                NUpCreditAccount.Enabled = False
                PicCreditAccount1.Enabled = True
                PicCreditAccount.Enabled = False
            Case "شيك_ذمم_دائنة"
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = "0.000"
                TextValueOfCheck.EditValue = Format(Val(CASHA) - Val(Me.TextValueAccountsPayable.EditValue), "0.000")
                TextChecksAccount.Text = ChecksAccount_Name
                TextAccountsPayableAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
                NUpCreditAccount1.Value = PayableAccount_Cod
                LabelChecksAccount.Text = "حساب شيكات صادرة"
                NUpCreditAccount1.Enabled = True
                NUpCreditAccount.Enabled = True
                PicCreditAccount1.Enabled = True
                PicCreditAccount.Enabled = True
            Case "نقدا_شيك_ذمم_دائنة"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.TextValueAccountsPayable.Enabled = True
                Me.TextFundValue.EditValue = Format(Val(CASHA) - (Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextValueAccountsPayable.EditValue)), "0.000")
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                LabelChecksAccount.Text = "حساب شيكات صادرة"
                TextChecksAccount.Text = ChecksAccount_Name
                TextAccountsPayableAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
                NUpCreditAccount1.Value = PayableAccount_Cod
                NUpCreditAccount1.Enabled = True
                NUpCreditAccount.Enabled = True
                PicCreditAccount1.Enabled = True
                PicCreditAccount.Enabled = True
        End Select
        If Val(Me.txtTotalDiscount.Text) > 0 Then
            TextDiscountAccountAE.Text = DiscountAccountAE_Name
            NUpCreditAccount2.Value = DiscountAccount_Cod
            NUpCreditAccount2.Enabled = True
            PicCreditAccount2.Enabled = True
        Else
            TextDiscountAccountAE.Text = Nothing
            NUpCreditAccount2.Enabled = False
            PicCreditAccount2.Enabled = False
        End If
        If Val(Me.TEXTSalesTaxes.Text) > 0 Then
            TextCalculatingTaxAccount.Text = CalculatingTaxAccount_Name
            NUpDebitAccount.Value = TaxAccount_Cod
            NUpDebitAccount.Enabled = True
            PicDebitAccount.Enabled = True
        Else
            TextCalculatingTaxAccount.Text = Nothing
            NUpDebitAccount.Enabled = False
            PicDebitAccount.Enabled = False
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
=======
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            GetDiscount_B(Val(Me.TEXTDiscount.Text))
            GetCalculatingTax_B(Val(Me.TEXTSalesTaxes.Text))
            If ExitSub_Check = True Then
                FrmOPTIONS.ShowDialog()
                Exit Sub
            End If
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
=======
            If Val(Me.txtTotalDiscount.Text) > 0 Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                If Me.TextCalculatingTaxAccount.Text = "" Then
                    MsgBox("عفوا .. لا يمكن ترك حقل حساب  ضريبة المشتريات المضافة", 16, "تنبيه")
                    Me.ListDebitAccount.Visible = True
                    Exit Sub
                End If
            End If
            If Me.TextChecksAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Me.ListCreditAccount.Visible = True
                Exit Sub
            End If
<<<<<<< HEAD
            If Val(Me.TEXTDiscount.Text) > 0 Then
=======
            If Val(Me.TEXTSalesTaxes.Text) > 0 Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                If Me.TextDiscountAccountAE.Text = "" Then
                    MsgBox("عفوا .. لا يمكن ترك حقل حساب خصم مكتسب", 16, "تنبيه")
                    Me.ListCreditAccount2.Visible = True
                    Exit Sub
                End If
            End If

            Dim ch1 As Double
            Dim ch2 As Double
<<<<<<< HEAD
            ch1 = Convert.ToDouble(TEXTTotal.Text) - Convert.ToDouble(Discount_B)
            CASHA = Convert.ToDouble(ch1)
            ch2 = Convert.ToDouble(Me.TextFundValue.EditValue) + Convert.ToDouble(Me.TextValueOfCheck.EditValue) + Convert.ToDouble(Me.TextValueAccountsPayable.EditValue)
            If Convert.ToDouble(CASHA) <> Convert.ToDouble(ch2) Then
=======
            ch1 = Val(TEXTTotal.Text).ToString("0.000") - Val(Discount_B).ToString("0.000")
            CASHA = Val(ch1).ToString("0.000")
            ch2 = Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextValueAccountsPayable.EditValue)
            If Val(CASHA).ToString("0.000") <> Val(ch2).ToString("0.000") Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك والذمم الدائنة واجمالي الخصم مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            Me.AccountingprocedureA()
<<<<<<< HEAD
            Me.ButtonViewrestrictions_Click(sender, e)
=======
            Me.Button1_Click(sender, e)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            nextRow = Me.DataGridView1.Rows(0)
            If Me.Ch1.Checked = False Then
                Me.Ch1.Checked = True
            End If

            If OBCHK5 = True Then
                If Me.CheckTransferToAccounts.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferToAccounts.Checked = True
                        TransforAccounts()
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
                        Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferToAccounts.Checked = False
                            Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else

                If Me.ComboPaymentMethod.Text = "نقدا" Then
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATCASHIER()
                                Me.DELETEDATACUSTOMER1()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, " ترحيل  الى القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة القيود اليومية و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                DELETEDATCASHIER()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة الصندزق و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "ذمم_دائنة" Then

                    If Me.TextAccountsPayableAccount.Text = "" Then
                        MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                        Me.ListCreditAccount1.Visible = True
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الموردين رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            If Me.TextAccountsPayableAccount.Text = "" Then
                                MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                                Me.ListCreditAccount1.Visible = True
                                Exit Sub
                            End If
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  حركة القيود اليومية و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الموردين  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATACUSTOMER1()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة القيود اليومية و الموردين رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "نقدا_ذمم_دائنة" Then

                    If Me.TextAccountsPayableAccount.Text = "" Then
                        MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                        Me.ListCreditAccount1.Visible = True
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الموردين رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "ترحيل الى القيود اليومية و الصندزق و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            If Me.TextAccountsPayableAccount.Text = "" Then
                                MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                                Me.ListCreditAccount1.Visible = True
                                Exit Sub
                            End If

                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الصندزق و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATACUSTOMER1()
                                Me.DELETEDATCASHIER()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة الصندزق و الموردين رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf Me.ComboPaymentMethod.Text = "شيك_ذمم_دائنة" Then

                    If Me.TextAccountsPayableAccount.Text = "" Then
                        MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                        Me.ListCreditAccount1.Visible = True
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
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات و الموردين رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "ترحيل الى القيود اليومية و الشيكات و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            If Me.TextAccountsPayableAccount.Text = "" Then
                                MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                                Me.ListCreditAccount1.Visible = True
                                Exit Sub
                            End If
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الشيكات و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATACUSTOMER1()
                                Me.DELETEDATCASHIER()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة الشيكات و الموردين رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك_ذمم_دائنة" Then

                    If Me.TextAccountsPayableAccount.Text = "" Then
                        MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                        Me.ListCreditAccount1.Visible = True
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
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات و الموردين رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "ترحيل الى القيود اليومية و الصندزق و الشيكات و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                                Me.DELETEDATCASHIER()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Me.TextSupplierTrafficNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                            Else
                                Me.DELETEDATACUSTOMER1()
                            End If
                            If Me.TextAccountsPayableAccount.Text = "" Then
                                MsgBox("عفوا .. لا يمكن ترك حقل حساب ذمم دائنة فارغ", 16, "تنبيه")
                                Me.ListCreditAccount1.Visible = True
                                Exit Sub
                            End If
                            TransforAccounts()
                            Insert_Actions(Me.TEXT1.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات و المردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATCASHIER()
                                Me.DELETEDATACUSTOMER1()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXT1.Text.Trim, "حذف ترحيل حركة الصندزق و الشيكات  و الموردين رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If


            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            p = BS.Position
            Me.UPDATEBUYS()
            Me.SaveBUYSITEMS()
            Me.UPDATEBUYSITEMS()
            Me.UPDATEBUYSITEMS() ' البنود
            Me.DanLOd()
            nextRow = Me.DataGridView1.Rows(0)
            Me.BS.Position = p
            Me.UPDATEBUYS() '  راس الفاتورة
            Me.UPDATEBUYSITEMS() ' البنود
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub



<<<<<<< HEAD
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.DoubleClick
        Dim Consum As New SqlConnection(constring)
        Dim ds1 As New DataSet
        On Error Resume Next
        Dim strsql3 As New SqlCommand("SELECT STK1 FROM STOCKS WHERE STK16 =" & Me.TextSTK1B.Text & "AND STK7= '" & Me.DataGridView1.CurrentRow.Cells("SITM3").Value.ToString & "'", Consum)
        Dim Adp1 As New SqlDataAdapter(strsql3)
=======
    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds1 As New DataSet
        On Error Resume Next
        Dim strsql3 As New SqlClient.SqlCommand("SELECT STK1 FROM STOCKS WHERE STK16 =" & Me.TextSTK1B.Text.Trim & "AND STK7= '" & Me.DataGridView1.CurrentRow.Cells("SITM3").Value.ToString & "'", Consum)
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        Adp1.Fill(ds1, "STOCKS")
        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TextSTK1A.Text = ds1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextSTK1A.Text = 0
        End If
        For i As Integer = 0 To DataGridView1.Rows.Count - 2
            Dim row As DataGridViewRow = DataGridView1.Rows(i)
            If row.IsNewRow Then Continue For

            If Me.DataGridView1.CurrentRow.Cells("SITM3").Value = "" Then
                Exit Sub
            Else
                If Me.TextSTK1A.Text = 0 Then
<<<<<<< HEAD
                    'Me.SaveStocks()
=======
                    Me.SaveStocks()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ElseIf Me.TextSTK1B.Text = Me.TextMovementSymbol.EditValue Then
                    Me.UpdatStocks()
                Else
                    Me.UpdatStocks()
                End If
            End If
        Next
    End Sub

<<<<<<< HEAD
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button3.Click
=======
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.ds.RejectChanges()
        Me.RecordCount()
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
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber1, Me.BS, True)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA()
        Try
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
            SEARCHDATA.MAXIDMOVES()
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
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions1.Click
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
<<<<<<< HEAD
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.TextCheckMovementNumber1.Text.Trim)
            f.TB1 = Me.TextCheckMovementNumber1.Text.Trim
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
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber1.Click
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
<<<<<<< HEAD
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicSupplierTrafficNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSupplierTrafficNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmSuppliers1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            f.BS.DataMember = "Suppliers1"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextSupplierTrafficNumber.Text.Trim)
            f.TB1 = Me.TextSupplierTrafficNumber.Text.Trim
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
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicSupplierTrafficNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSupplierTrafficNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmSuppliers1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            f.BS.DataMember = "Suppliers1"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextSupplierTrafficNumber1.Text.Trim)
            f.TB1 = Me.TextSupplierTrafficNumber1.Text.Trim
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
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RBEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RBCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RBSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RBNothing.CheckedChanged
=======
    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBNothing.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call Me.AddType1()
    End Sub

    Private Sub AddType1()
        On Error Resume Next
        If Me.RBCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf Me.RBSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf Me.RBEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()

    End Sub

<<<<<<< HEAD
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RBCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.RBCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RBSUPPLIER.Checked = True Then
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
                    Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf Me.RBEMPLOYEES.Checked = True Then
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

<<<<<<< HEAD
    Private Sub TxtItem2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtItem2.KeyPress
=======
    Private Sub TxtItem2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItem2.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            Me.txtq.Focus()
            Me.SEARCHSTOCKSITEMS()
            Me.txtq.Text = 1
            Me.txtq.SelectAll()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TxtItem2_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtItem2.TextChanged
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub TxtItem2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItem2.TextChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim str As New SqlCommand("", Consum)
        With str
            If Trim(Me.txtItem2.Text) <> "" Then
                .CommandText = "SELECT * FROM STOCKSITEMS WHERE   CUser ='" & CUser & "'  and SKITM4 like'" & Trim(Me.txtItem2.Text) & "%'" & "or SKITM5 like'" & Trim(Me.txtItem2.Text) & "%'"
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim ds As New DataSet
                Dim dt As New DataTable
<<<<<<< HEAD
                Dim Adp1 As New SqlDataAdapter(str)
=======
                Dim Adp1 As New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Tot()
        Call Dgv2()
        'Me.DataGridView1.CurrentCell = Me.DataGridView1("BITM3", Me.DataGridView1.NewRowIndex)
    End Sub

<<<<<<< HEAD
    Private Sub Txtq_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtq.KeyPress
=======
    Private Sub Txtq_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtq.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub Txtq_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles txtq.TextChanged
=======
    Private Sub Txtq_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtq.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        'Me.txtbilltotal.Text = Total1
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

        w1 = Val(DataGridView2.Item("SKITM8", Me.DataGridView2.CurrentRow.Index).Value())
        w2 = txtq.Text
        w3 = Val(TXTDiscount.Text)
        wsum = Format((Val(w2) * Val(w3) - Val(w3)) * (100 - Val(w3)) / 100, "0.000")
        '''''''''''''''''''''''''''''''''''''''
        r1 = txtq.Text
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
                        cx = Val(Me.txtq.Text) + Val(row1.Cells("BITM6").Value)
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
                Me.DataGridView1.CurrentRow.Cells("BITM7").Value = Me.TXTDiscount.Text
                Me.DataGridView1.CurrentRow.Cells("BITM8").Value = sum2
                Me.DataGridView1.CurrentRow.Cells("BITM9").Value = Me.TexTSellingPrice.Text

            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.BarCode
=======
            Dim Sound As System.IO.Stream = My.Resources.BarCode
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Me.DataGridView1.CurrentRow.Cells("BITM3").Value = num.ToString.Trim
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
=======
    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick
        Me.DataGridView1.CurrentRow.Cells("BITM3").Value = num.ToString.Trim
    End Sub

    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.DataGridView1.SelectedRows.Count = 0 Then
            Me.DataGridView1.Item("BITM2", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If Me.DataGridView1.Item("BITM3", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("BITM3", e.RowIndex).Value = num.ToString.Trim
            If Me.DataGridView1.Item("BITM4", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("BITM4", e.RowIndex).Value = cod.ToString.Trim
            Exit Sub
        End If
    End Sub


<<<<<<< HEAD
    Private Sub PicDebitAccount_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicDebitAccount.Click
=======
    Private Sub PicDebitAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicDebitAccount.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListDebitAccount.Visible = True
    End Sub
<<<<<<< HEAD
    Private Sub PicCreditAccount_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCreditAccount.Click
=======
    Private Sub PicCreditAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCreditAccount.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS2 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListCreditAccount.Visible = True
    End Sub
<<<<<<< HEAD
    Private Sub PicCreditAccount1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCreditAccount1.Click
=======
    Private Sub PicCreditAccount1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCreditAccount1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS3 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListCreditAccount1.Visible = True
    End Sub
<<<<<<< HEAD
    Private Sub PicCreditAccount2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCreditAccount2.Click
=======
    Private Sub PicCreditAccount2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCreditAccount2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS4 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListCreditAccount2.Visible = True
    End Sub

<<<<<<< HEAD
    Private Sub List0_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListDebitAccount.MouseDoubleClick
=======
    Private Sub List0_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListDebitAccount.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextCalculatingTaxAccount.Text = Me.ListDebitAccount.SelectedItem(0).ToString
        Me.PanelAccount_Name.Visible = False
        Me.ListDebitAccount.Visible = False
        LS1 = False
    End Sub
<<<<<<< HEAD
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListCreditAccount.MouseDoubleClick
=======
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListCreditAccount.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextChecksAccount.Text = Me.ListCreditAccount.SelectedItem(0).ToString
        Me.PanelAccount_Name.Visible = False
        Me.ListCreditAccount.Visible = False
        LS2 = False
    End Sub
<<<<<<< HEAD
    Private Sub List2_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListCreditAccount1.MouseDoubleClick
=======
    Private Sub List2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListCreditAccount1.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextAccountsPayableAccount.Text = Me.ListCreditAccount1.SelectedItem(0).ToString
        Me.PanelAccount_Name.Visible = False
        Me.ListCreditAccount1.Visible = False
        LS3 = False
    End Sub
<<<<<<< HEAD
    Private Sub List3_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListCreditAccount2.MouseDoubleClick
=======
    Private Sub List3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListCreditAccount2.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextDiscountAccountAE.Text = Me.ListCreditAccount2.SelectedItem(0).ToString
        Me.PanelAccount_Name.Visible = False
        Me.ListCreditAccount2.Visible = False
        LS4 = False
    End Sub


<<<<<<< HEAD
    Private Sub NUpComboDebitAccount_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub

    Private Sub NUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.ListCreditAccount.DataSource = GetData(NUpCreditAccount.Value)
        Me.ListCreditAccount.DisplayMember = "account_name"
    End Sub
    Private Sub NUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount1.ValueChanged
        Me.ListCreditAccount1.DataSource = GetData(NUpCreditAccount1.Value)
        Me.ListCreditAccount1.DisplayMember = "account_name"
    End Sub
    Private Sub NUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount2.ValueChanged
        Me.ListCreditAccount2.DataSource = GetData(NUpCreditAccount2.Value)
        Me.ListCreditAccount2.DisplayMember = "account_name"
    End Sub
    Private Sub NUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDebitAccount.ValueChanged
=======
    Private Sub NUpComboDebitAccount_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub

    Private Sub NUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.ListCreditAccount.DataSource = GetData(NUpCreditAccount.Value)
        Me.ListCreditAccount.DisplayMember = "account_name"
    End Sub
    Private Sub NUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount1.ValueChanged
        Me.ListCreditAccount1.DataSource = GetData(NUpCreditAccount1.Value)
        Me.ListCreditAccount1.DisplayMember = "account_name"
    End Sub
    Private Sub NUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount2.ValueChanged
        Me.ListCreditAccount2.DataSource = GetData(NUpCreditAccount2.Value)
        Me.ListCreditAccount2.DisplayMember = "account_name"
    End Sub
    Private Sub NUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDebitAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ListDebitAccount.DataSource = GetData(NUpDebitAccount.Value)
        Me.ListDebitAccount.DisplayMember = "account_name"
    End Sub

    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.ListDebitAccount.DataSource = GetData(NUpDebitAccount.Value)
            Me.ListDebitAccount.DisplayMember = "account_name"
        ElseIf LS2 = True Then
            Me.ListCreditAccount.DataSource = GetData(NUpCreditAccount.Value)
            Me.ListCreditAccount.DisplayMember = "account_name"
        ElseIf LS3 = True Then
            Me.ListCreditAccount1.DataSource = GetData(NUpCreditAccount1.Value)
            Me.ListCreditAccount1.DisplayMember = "account_name"
        ElseIf LS4 = True Then
            Me.ListCreditAccount2.DataSource = GetData(NUpCreditAccount2.Value)
            Me.ListCreditAccount2.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub



<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSupplierName.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboSupplierName.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum.Tick
=======
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timsum.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
                    nextRow = Me.DataGridView1.Rows(counter)
                    nextRow.Selected = True
                    GetAutoNumber("STK1", "STOCKS", "STK4")
                    IDSTK = AutoNumber
                    SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
                    Me.TextSTK1A.Text = SEARCHDATA.STK1A
                    SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
                    Me.TextSTK1B.Text = SEARCHDATA.STK1B

                    Me.SEARCHSTOCKSITEMS()
                    Me.UpdatEBALANCEITEMS()
                    Me.TEXTUnitPrice.Text = Me.DataGridView1.Item("BITM5", Me.DataGridView1.CurrentRow.Index).Value()

                    Me.TextTotalSellingPrice.Text = Format(Val(Me.DataGridView1.Item("BITM9", Me.DataGridView1.CurrentRow.Index).Value()) * Val(Me.DataGridView1.Item("BITM6", Me.DataGridView1.CurrentRow.Index).Value()) _
                                               - Val(Me.TextDiscountPercentageWhenSelling.Text) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000")

                    If Me.TextSTK1A.Text = 0 Then
                        Me.SaveStocks()
                    ElseIf Me.TextSTK1B.Text = Me.TextMovementSymbol.EditValue Then
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

<<<<<<< HEAD
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch1.CheckedChanged
=======
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ch1.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Me.Ch1.Checked = True Then
            Me.DataGridView1.Focus()
            Me.Timsum.Start()
        ElseIf Me.Ch1.Checked = False Then
            Me.txtq.Focus()
            Me.Timsum.Stop()
        End If
    End Sub

<<<<<<< HEAD
    Public Sub Check7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Check7.CheckedChanged
=======
    Public Sub Check7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Check7.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'On Error Resume Next
        'FormOP = 1
        'Dim parent As Form = Me.FindForm
        'Dim f As New FormLASTchecks
        'f.Location = New Point(parent.Left + Check7.Left + 6, parent.Top + Check7.Bottom + Check7.Height)
        'If Me.Check7.Checked = True Then

        'If Check7.Checked = True Then
        'f.Show(Me)
        'f.Show()
        'CHA1 = TextBox46.Text
        'CHA3 = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        'CHA7 = ComboBox6.Text.Trim
        'CHA8 = TextBox51.Text
        'f.TextBox1.Text = CHA1
        'f.TextBox2.Text = CHA3
        'f.TextBox3.Text = CHA7
        'f.TextBox4.Text = CHA8


        'ElseIf Check7.Checked = False Then
        '    f.Close()
        'End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox46_TextChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextCheckNumber.TextChanged
=======
    Private Sub TextBox46_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCheckNumber.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Dim f As New FormLASTchecks
        'f.FormLASTchecks_Load(sender, e)
        ''f.Show(Me)
        'CHA1 = TextBox46.Text
        'CHA3 = DateTimePicker1.Value.ToString()
        'CHA7 = ComboBox6.Text.Trim
        'CHA8 = TextBox51.Text

        'f.TextBox1.Text = CHA1
        'f.TextBox2.Text = CHA3
        'f.TextBox3.Text = CHA7
        'f.TextBox4.Text = CHA8
    End Sub

<<<<<<< HEAD
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles CheckDate.ValueChanged
=======
    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDate.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Dim f As New FormLASTchecks
        'f.FormLASTchecks_Load(sender, e)
        ''f.Show(Me)
        'CHA1 = TextBox46.Text
        'CHA3 = DateTimePicker1.Value.ToString()
        'CHA7 = ComboBox6.Text.Trim
        'CHA8 = TextBox51.Text

        'f.TextBox1.Text = CHA1
        'f.TextBox2.Text = CHA3
        'f.TextBox3.Text = CHA7
        'f.TextBox4.Text = CHA8
    End Sub

<<<<<<< HEAD
    Private Sub TextBox46_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextCheckNumber.KeyUp
=======
    Private Sub TextBox46_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextCheckNumber.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.CheckDate.Focus()
        End Select
    End Sub

<<<<<<< HEAD
    Private Sub ButtonViewrestrictions_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.BS.Position < Me.ds.Tables("BUYS").Rows.Count - 1 Then
            Interaction.MsgBox("لا يوجد بيانات", MsgBoxStyle.Critical, "تنبيه")
            Exit Sub
        End If

        SEARCHDATA.SEARCHMAXIDSTOCKS()
        Me.TEXTCurrentBalance.Text = Format(Conversion.Val(ModuleGeneral.SumAmounTOTALSTOCKS(Me.DataGridView1.CurrentRow.Cells.Item("BITM4").Value.ToString.Trim, SEARCHDATA.MAXSTK1)), "0.000")
        Me.TextTotalPurchasePrice.Text = Format(Val(Me.TEXTUnitPrice.Text) * Val(Me.TextBalance.Text) * (100 - Val(Me.TXTDiscount.Text)) / 100, "0.000")
        Me.TextTotalSellingPrice.Text = Format(Val(Me.TexTSellingPrice.Text) * Val(Me.TextBalance.Text) * (100 - Val(Me.TextDiscountPercentageWhenSelling.Text)) / 100, "0.000")
        SEARCHDATA.SEARCHSTOCKSID1(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1B.Text = SEARCHDATA.STK1B
        SEARCHDATA.SumSTOCKS(Me.num.ToString.Trim, Me.cod.ToString.Trim)
        Me.TextBalance.Text = Conversion.Val(SEARCHDATA.sumSTK)
<<<<<<< HEAD
        MaxIDMoves()
=======
        MAXIDMOVES()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        SEARCHDATA.SEARCHSTOCKSID(Me.DataGridView1.Item("BITM4", Me.DataGridView1.CurrentRow.Index).Value, Me.TextMovementSymbol.EditValue)
        Me.TextSTK1A.Text = SEARCHDATA.STK1A
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
<<<<<<< HEAD
        Me.account_noF = SEARCHDATA.Account_No
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.Account_Name = SEARCHDATA.Account_Name
=======
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = SEARCHDATA.MOV1B

        SEARCHDATA.SEARCHMOVESDATATrue(Me.TextMovementSymbol.EditValue)
        Me.MOVD1T = SEARCHDATA.MOVD1A

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTInvoiceNumberA.EditValue)
        Me.TextFundMovementNumber1.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TEXTInvoiceNumberA.EditValue)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B

        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
        SEARCHDATA.SEARCHDIDChecks1(Me.TextMovementSymbol.EditValue, Me.TextMovementRestrictions1.Text)
        Me.TextCheckMovementNumber1.Text = SEARCHDATA.IDCH2

        SEARCHDATA.SEARCHDSuppliers(Me.TEXTInvoiceNumberA.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextSupplierTrafficNumber.Text = SEARCHDATA.IDCABS

        SEARCHDATA.SEARCHDSuppliers1(Me.TEXTInvoiceNumberA.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextSupplierTrafficNumber1.Text = SEARCHDATA.IDCABS1

        If Me.TextSupplierTrafficNumber1.Text = Nothing Then
            SEARCHDATA.SEARCHDSuppliers2(Me.TEXTInvoiceNumberA.EditValue, Me.TextMovementSymbol.EditValue)
            Me.TextSupplierTrafficNumber1.Text = IDCABS2
        ElseIf Me.TextSupplierTrafficNumber1.Text = "0" Then
            SEARCHDATA.SEARCHDSuppliers2(Me.TEXTInvoiceNumberA.EditValue, Me.TextMovementSymbol.EditValue)
            Me.TextSupplierTrafficNumber1.Text = IDCABS2
        End If




    End Sub

    Private Sub ComboStore_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboStore.SelectedIndexChanged
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT WarehouseName  FROM Warehouses WHERE WarehouseNumber ='" & Me.ComboStore.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
=======
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            GetAutoNumberMyDOCUMENTSFL(TextMovementSymbol.EditValue)
            Dim documentId As Object = SEARCHDATA.NumberMyDOCUMENTSFL
            Dim f As New FrmJPG0
            f.Show()
=======
           Dim XLO As Int64
            XLO = Me.TEXTInvoiceNumber.Text
            Dim f As New FrmJPG0
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
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
            f.TEXTFileNo.Text = Val(XLO)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.TEXTFileSubject.Text = "مستندات المشتريات"
            f.TextFileDescription.Text = "ارفاق مستندات المشتريات"
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
            Dim str As New SqlCommand("SELECT DOC1, LO  FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
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
                Dim DOC1 As String = Trim(ds41.Tables(0).Rows(0).Item(0))
                Dim LO As String = Trim(ds41.Tables(0).Rows(0).Item(1))
                index = f.BS.Find("DOC1", DOC1)
                f.Show()
                f.TEXTBOX1.Text = Strings.Trim(DOC1)
                f.TextTransactionNumber.Text = Strings.Trim(LO)
                f.FrmJPG_Load(sender, e)
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

<<<<<<< HEAD
    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======


    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        TEXT5CHANGED()
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
            BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

End Class
