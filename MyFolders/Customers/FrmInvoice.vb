Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmInvoice
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    ReadOnly ds1 As New DataSet
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Dim _Type1 As String
    Dim TypeCustomer As String
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB1_chk As Boolean = False
    Public TB2_chk As Boolean = False
    Public TB3_chk As Boolean = False
    Dim IDCAB1 As Int64
    Dim IDCAB2 As Int64
    Dim ITEMNAME_CHK As Boolean = False


    Private Sub FrmInvoice_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmInvoice_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
                        Me.ButtonPREEVIEW_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonXP3_Click(sender, e)
                    Case Keys.F10
                        Me.ButtonCUSTOMER1_Click(sender, e)
                    Case Keys.F11
                        Me.TRANSFERBUTTON_Click(sender, e)
                    Case Keys.F12
                        Me.ButtonDELRECORD_Click(sender, e)
                    Case Keys.F5 And (e.Alt And Not e.Control And Not e.Shift)
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.D And (e.Shift And Not e.Control And Not e.Alt)
                        Me.ButtonXP2_Click(sender, e)
                    Case Keys.S And (e.Shift And Not e.Control And Not e.Alt)
                        Me.ButtonXP1_Click(sender, e)
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
    Private Sub FrmInvoice_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
    End Sub
    Private Sub FrmInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Me.ButtonDELRECORD.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonPostToCustomerTraffic.Enabled = False
        Me.ButtonXP1.Enabled = False
        Me.ButtonXP2.Enabled = False
        Me.ButtonPREEVIEW.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        TestkeyAccounts(keyAccounts.GetValue("TransferAccount_No", TransferAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("TransferAccount_No", TransferAccount_No)
        End If
        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        If TB1_chk = True Then
            str1.CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Invoice  WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1 ='" & Trim(Me.TB1) & "'"
        ElseIf TB2_chk = True Then
            str1.CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Invoice  WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO21 ='" & Trim(Me.TB2) & "'"
        ElseIf TB3_chk = True Then
            str1.CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Invoice  WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO20 ='" & Trim(Me.TB3) & "'"
        End If
        str2.CommandText = "SELECT CSDT, PTRO1, CSDT1, CSDT2, CSDT3, CSDT4, CSDT5, CSDT6, CSDT7, CSDT8 FROM InvoiceDetails ORDER BY PTRO1"
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.ds1.Clear()
        Consum.Open()
        Me.SqlDataAdapter1.Fill(Me.ds1, "Invoice")
        Me.SqlDataAdapter2.Fill(Me.ds1, "InvoiceDetails")
        Me.ds1.Relations.Add("REL5", Me.ds1.Tables("Invoice").Columns("PTRO1"), Me.ds1.Tables("InvoiceDetails").Columns("PTRO1"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "Invoice"
        LoadData()
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL5"


        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        If ComboStore.Items.Count > 0 Then
            Me.ComboStore.SelectedIndex = 0
        End If
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Auditor("Invoice", "USERNAME", "PTRO1", TEXTInvoiceNumber.EditValue, "")
        Logentry = Uses

        FILLCOMBOBOX1("Invoice", "PTRO9", "CUser", CUser, Me.TEXTADDRESS)
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        FILLCOMBOBOXDISTINCT("Invoice", "PTRO5", "PTRO1", "CUser", CUser, Me.CheckedListBox1)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.DataGridView1.AutoGenerateColumns = False
        Me.RecordCount()
        Me.TEXTInvoiceNumber.Enabled = False
        Me.BUTTONCANCEL.Enabled = True
        Me.InstalledPrinters()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.ComboCustomerName.Focus()
        '==============================
        Call MangUsers()
        Me.load1.Enabled = False
    End Sub


    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT PTRO1, PTRO2, PTRO3, PTRO4, PTRO5, PTRO6, PTRO7, PTRO8, PTRO9, PTRO10, PTRO11, PTRO12, PTRO13, PTRO14, PTRO15, PTRO16, PTRO17, PTRO18, PTRO19, PTRO20, PTRO21, PTRO22, PTRO23, PTRO24, PTRO25, PTRO26, PTRO27, PTRO28, PTRO29, PTRO30, PTRO31, WarehouseNumber, WarehouseName, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Invoice  WHERE   CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1 ='" & Strings.Trim(Me.TB1) & "'or PTRO21 ='" & Strings.Trim(Me.TB2) & "'or PTRO20 ='" & Strings.Trim(Me.TB3) & "' ORDER BY PTRO1"
        End With
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        With str2
            .CommandText = "SELECT CSDT, PTRO1, CSDT1, CSDT2, CSDT3, CSDT4, CSDT5, CSDT6, CSDT7, CSDT8 FROM InvoiceDetails ORDER BY PTRO1"
        End With
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.ds1.Clear()
        Consum.Open()
        Me.SqlDataAdapter1.Fill(Me.ds1, "Invoice")
        Me.SqlDataAdapter2.Fill(Me.ds1, "InvoiceDetails")
        Me.ds1.Relations.Add("REL5", Me.ds1.Tables("Invoice").Columns("PTRO1"), Me.ds1.Tables("InvoiceDetails").Columns("PTRO1"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "Invoice"
        LoadData()
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL5"
        FILLCOMBOBOX1("Warehouses", "WarehouseNumber", "CUser", CUser, Me.ComboStore)
        If ComboStore.Items.Count > 0 Then
            Me.ComboStore.SelectedIndex = 0
        End If
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()

        FILLCOMBOBOX1("Invoice", "PTRO9", "CUser", CUser, Me.TEXTADDRESS)
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        FILLCOMBOBOXDISTINCT("Invoice", "PTRO5", "PTRO1", "CUser", CUser, Me.CheckedListBox1)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.DataGridView1.AutoGenerateColumns = False
        Me.RecordCount()
        Me.TEXTInvoiceNumber.Enabled = False
        Me.BUTTONCANCEL.Enabled = True
        Me.InstalledPrinters()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.ComboCustomerName.Focus()
        '==============================
        Call MangUsers()
        Me.load1.Enabled = False
    End Sub

    Private Shared Sub LoadData()
        'Dim Consum As New SqlClient.SqlConnection(constring)
        'Using cmd As New SqlClient.SqlCommand("Select STK7  from STOCKS  WHERE CUser ='" & CUser & "'AND WarehouseNumber='" & ComboStore.SelectedValue & " '", Consum)
        '    Consum.Open()
        '    Using dreader As SqlClient.SqlDataReader = cmd.ExecuteReader
        '        'CSDT7.DataPropertyName = Nothing
        '        'CSDT7.Items.Clear()
        '        ItemName.Clear()
        '        ItemName.Load(dreader)
        '        For i As Integer = 0 To ItemName.Rows.Count - 1
        '            CSDT7.Items.Add(ItemName(i)(0))
        '        Next
        '    End Using
        'End Using
        'CSDT7.DataPropertyName = "CSDT7"
        'Consum.Close()
        'ComboITEMNAME.Items.Clear()
        'CSDT7.Items.Clear()

        'FILLCOMBOBOX10("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.CSDT7)

        'For i As Integer = 0 To DataGridView1.Rows.Count - 1
        '    CSDT7.Items.Add(DataGridView1.Rows(i).Cells("CSDT7").Value)
        'Next
        'Me.DataGridView1.DataSource = Nothing
        'Me.DataGridView1.DataSource = Me.BS
        'Me.DataGridView1.DataMember = "REL5"
        'BS = New BindingSource()
        'Dim dv As New DataView(ds1.Tables(0))
        'BS.DataSource = dv



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
        FILLCOMBOBOX3("STOCKS", "STK7", "CUser", CUser, "WarehouseNumber", ComboStore.Text, Me.ComboITEMNAME)

        'LoadData()

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



    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
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
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds1.Tables("Invoice").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        'Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
        If TEXTQuantity.Text <> "" And Len(Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value) > 0 Then Me.TEXTLetteringQuantity.Text = AmountWord(Me.TEXTQuantity.Text) & " " & Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value

        Me.DISPLAYRECORD()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.AutoEx()
        Me.BUTTONCANCEL.Enabled = True
        Me.TEXTInvoiceNumber.Enabled = False
    End Sub
    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " „‰ " & Me.BS.Count
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
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
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
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
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
            Me.PicMovementRestrictions.Visible = False
        End If
    End Sub
    Private Sub SaveInvoiceDetails()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        'Try
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO InvoiceDetails (PTRO1, CSDT1, CSDT2, CSDT3, CSDT4, CSDT5, CSDT6, CSDT7, CSDT8) VALUES     (@PTRO1, @CSDT1, @CSDT2, @CSDT3, @CSDT4, @CSDT5, @CSDT6, @CSDT7, @CSDT8)", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            '.Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
            .Parameters.Add("@PTRO1", SqlDbType.BigInt, 8, "PTRO1").Value = Me.TEXTInvoiceNumber.EditValue
            .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1")
            .Parameters.Add("@CSDT2", SqlDbType.Date, 8, "CSDT2")
            .Parameters.Add("@CSDT3", SqlDbType.Float, 8, "CSDT3")
            .Parameters.Add("@CSDT4", SqlDbType.Float, 8, "CSDT4")
            .Parameters.Add("@CSDT5", SqlDbType.Float, 8, "CSDT5")
            .Parameters.Add("@CSDT6", SqlDbType.Float, 4, "CSDT6")
            .Parameters.Add("@CSDT7", SqlDbType.NVarChar, 255, "CSDT7")
            .Parameters.Add("@CSDT8", SqlDbType.NVarChar, 255, "CSDT8")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table1", "InvoiceDetails", New DataColumnMapping() {New DataColumnMapping("CSDT", "CSDT"), New DataColumnMapping("PTRO1", "PTRO1"), New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CSDT4", "CSDT4"), New DataColumnMapping("CSDT5", "CSDT5"), New DataColumnMapping("CSDT6", "CSDT6"), New DataColumnMapping("CSDT7", "CSDT7"), New DataColumnMapping("CSDT8", "CSDT8")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds1, "InvoiceDetails")
        Consum.Close()
    End Sub
    Private Sub UPDATEInvoiceDetails()
        On Error Resume Next
        'Try
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("Update InvoiceDetails SET  PTRO1 = @PTRO1, CSDT1 = @CSDT1, CSDT2 = @CSDT2, CSDT3 = @CSDT3, CSDT4 = @CSDT4, CSDT5 = @CSDT5, CSDT6 = @CSDT6, CSDT7 = @CSDT7, CSDT8 = @CSDT8 WHERE  CSDT  = @CSDT", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
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
            .Parameters.Add("@CSDT6", SqlDbType.Float, 4, "CSDT6")
            .Parameters.Add("@CSDT7", SqlDbType.NVarChar, 255, "CSDT7")
            .Parameters.Add("@CSDT8", SqlDbType.NVarChar, 255, "CSDT8")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table12", "InvoiceDetails", New DataColumnMapping() {New DataColumnMapping("CSDT", "CSDT"), New DataColumnMapping("PTRO1", "PTRO1"), New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CSDT4", "CSDT4"), New DataColumnMapping("CSDT5", "CSDT5"), New DataColumnMapping("CSDT6", "CSDT6"), New DataColumnMapping("CSDT7", "CSDT7"), New DataColumnMapping("CSDT8", "CSDT8")})})
        SqlDataAdapter2.UpdateCommand = CMD
        SqlDataAdapter2.Update(Me.ds1, "InvoiceDetails")
        Consum.Close() '
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error2", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ButtonPostToCustomerTraffic.Enabled = LockUpdate
        Me.ButtonTransferofAccounts.Enabled = LockUpdate
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonDELRECORD.Enabled = LockDelete
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonPostToCustomerTraffic.Enabled = TransferofAccounts
        Me.ButtonXP1.Enabled = True
        Me.ButtonXP2.Enabled = True
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.ButtonPREEVIEW.Enabled = LockPrint
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonAttachDocument.Enabled = LockAddRow
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
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TEXTInvoiceNumber.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO1").ToString
            .TEXTCarNumbers.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO2").ToString
            .TEXTQuantity.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO3").ToString
            .TEXTLetteringQuantity.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO4").ToString
            .DateMovementHistory.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO5").ToString
            .TEXTDiscountValue.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO6").ToString
            .TEXTTotalValue.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO7").ToString
            .TEXTTaxRate.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO8").ToString
            .TEXTADDRESS.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO9").ToString
            .TEXTExpenseType.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO10").ToString
            .TEXTNetValue.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO11").ToString
            .TEXTExpensesValue.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO12").ToString
            .TEXTTransfers.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO13").ToString
            .TEXTTotal.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO14").ToString
            .TextCreditAccount.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO17").ToString
            .TEXTTotalN.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO18").ToString
            .CheckTransferToAccounts.Checked = ds1.Tables("Invoice").Rows(BS.Position)("PTRO15").ToString
            .CheckSettlementDone.Checked = ds1.Tables("Invoice").Rows(BS.Position)("PTRO16").ToString
            .ComboCustomerName.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO20").ToString
            .TextCustomerNumber.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO21").ToString
            .TextTaxes.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO19").ToString
            .CheckLogReview.Checked = ds1.Tables("Invoice").Rows(BS.Position)("PTRO22").ToString
            .TextMovementSymbol.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO23").ToString
            .CheckPostToCustomerTraffic.Checked = ds1.Tables("Invoice").Rows(BS.Position)("PTRO24").ToString
            .ComboPaymentMethod.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO25").ToString
            .TextFundValue.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO26").ToString
            .TextValueOfCheck.EditValue = ds1.Tables("Invoice").Rows(BS.Position)("PTRO27").ToString
            .TextCheckNumber.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO28").ToString
            .CheckDate.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO29").ToString

            .ComboCheckDrawerName.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO30").ToString
            .TextCheckDrawerCode.Text = ds1.Tables("Invoice").Rows(BS.Position)("PTRO31").ToString

            .ComboCB1.Text = Me.ds1.Tables("Invoice").Rows(Me.BS.Position)("CB1").ToString
            .ComboBN2.Text = Me.ds1.Tables("Invoice").Rows(Me.BS.Position)("BN2").ToString

            .ComboStore.Text = Me.ds1.Tables("Invoice").Rows(Me.BS.Position)("WarehouseNumber").ToString
            .TextWarehouseName.Text = Me.ds1.Tables("Invoice").Rows(Me.BS.Position)("WarehouseName").ToString

            .TEXTUserName.Text = ds1.Tables("Invoice").Rows(BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = ds1.Tables("Invoice").Rows(Me.BS.Position).Item("Auditor").ToString
            .TextDefinitionDirectorate.Text = ds1.Tables("Invoice").Rows(BS.Position)("COUser").ToString
            .TEXTAddDate.Text = ds1.Tables("Invoice").Rows(BS.Position)("da").ToString
            .TextTimeAdd.Text = ds1.Tables("Invoice").Rows(BS.Position)("ne").ToString
            .TEXTReviewDate.Text = ds1.Tables("Invoice").Rows(BS.Position)("da1").ToString
            .TextreviewTime.Text = ds1.Tables("Invoice").Rows(BS.Position)("ne1").ToString
        End With
        ''Me.CSDT7.Items.Clear()
        LoadData()
        Me.AutoEx()
        Auditor("Invoice", "USERNAME", "PTRO1", Me.TEXTInvoiceNumber.EditValue, "")
        Logentry = Uses

        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        ''Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")
        If TEXTQuantity.Text <> "" And Len(Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value) > 0 Then Me.TEXTLetteringQuantity.Text = AmountWord(Me.TEXTQuantity.Text) & " " & Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value

        Me.FundBalance()
        Me.BUTTONCANCEL.Enabled = True
        Me.TEXTInvoiceNumber.Enabled = False
        ITEMNAME_CHK = False
    End Sub
    Private Sub DELETEDATACUSTOMER1()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "DELETE FROM CABLES  WHERE CAB8 = '" & Me.TEXTInvoiceNumber.EditValue.ToString & "'" & "AND CAB12='›« Ê—… ‰ﬁ·  ›’Ì·Ì…'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA2()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions1, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA3()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATA1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CABLES", "IDCAB", Me.TextCustomerTrafficNumber1, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
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
                NO = ""
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        If IsDBNull(resualt) Then
            IDCAB1 = CType(NO1, Integer) & 1
        Else
            V = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            IDCAB1 = V
        End If
        Consum.Close()
    End Sub
    Private Sub MAXIDCAB2()
        On Error Resume Next
        Dim N As Int64
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES   WHERE CUser='" & CUser & "'and  Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
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
                NO = ""
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        If IsDBNull(resualt) Then
            IDCAB2 = CType(NO1, Integer) & 1
        Else
            V = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            IDCAB2 = V
        End If
        Consum.Close()
    End Sub



    Private Sub UPDATERECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand(" Update Invoice SET  PTRO2 = @PTRO2, PTRO3 = @PTRO3, PTRO4 = @PTRO4, PTRO5 = @PTRO5, PTRO6 = @PTRO6, PTRO7 = @PTRO7, PTRO8 = @PTRO8, PTRO9 = @PTRO9, PTRO10 = @PTRO10, PTRO11 = @PTRO11, PTRO12 = @PTRO12, PTRO13 = @PTRO13, PTRO14 = @PTRO14, PTRO15 = @PTRO15, PTRO16 = @PTRO16, PTRO17 = @PTRO17, PTRO18 = @PTRO18, PTRO19 = @PTRO19, PTRO20 = @PTRO20, PTRO21 = @PTRO21, PTRO22 = @PTRO22, PTRO23 = @PTRO23, PTRO24 = @PTRO24, PTRO25 = @PTRO25, PTRO26 = @PTRO26, PTRO27 = @PTRO27, PTRO28 = @PTRO28, PTRO29 = @PTRO29, PTRO30 = @PTRO30, PTRO31 = @PTRO31, WarehouseNumber = @WarehouseNumber, WarehouseName = @WarehouseName, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE PTRO1 = @PTRO1", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
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
            .Parameters.Add("@PTRO10", SqlDbType.NVarChar).Value = Me.TEXTExpenseType.Text.Trim
            .Parameters.Add("@PTRO11", SqlDbType.NVarChar).Value = Val(Me.TEXTNetValue.Text)
            .Parameters.Add("@PTRO12", SqlDbType.NVarChar).Value = Val(Me.TEXTExpensesValue.EditValue)
            .Parameters.Add("@PTRO13", SqlDbType.NVarChar).Value = Val(Me.TEXTTransfers.EditValue)
            .Parameters.Add("@PTRO14", SqlDbType.NVarChar).Value = Val(Me.TEXTTotal.Text)
            .Parameters.Add("@PTRO17", SqlDbType.NVarChar).Value = Me.TextCreditAccount.Text.Trim
            .Parameters.Add("@PTRO18", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text.Trim
            .Parameters.Add("@PTRO15", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
            .Parameters.Add("@PTRO16", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettlementDone.Checked)
            .Parameters.Add("@PTRO19", SqlDbType.NVarChar).Value = Val(Me.TextTaxes.EditValue)
            .Parameters.Add("@PTRO20", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text.Trim
            .Parameters.Add("@PTRO21", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue.Trim
            .Parameters.Add("@PTRO22", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
            .Parameters.Add("@PTRO23", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@PTRO24", SqlDbType.Bit).Value = Convert.ToInt32(CheckPostToCustomerTraffic.Checked)
            .Parameters.Add("@PTRO25", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text.Trim
            .Parameters.Add("@PTRO26", SqlDbType.Money).Value = Me.TextFundValue.EditValue
            .Parameters.Add("@PTRO27", SqlDbType.Money).Value = Me.TextValueOfCheck.EditValue
            .Parameters.Add("@PTRO28", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
            .Parameters.Add("@PTRO29", SqlDbType.Date).Value = Me.CheckDate.Value.ToString

            .Parameters.Add("@PTRO30", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
            .Parameters.Add("@PTRO31", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text

            .Parameters.Add("@WarehouseNumber", SqlDbType.NVarChar).Value = Me.ComboStore.Text
            .Parameters.Add("@WarehouseName", SqlDbType.NVarChar).Value = Me.TextWarehouseName.Text

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
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("⁄›Ê« .. «·”‰… «·„Õ«”»Ì… €Ì— ’ÕÌÕ… ›·« Ì„ﬂ‰ «·„ﬁ«—‰…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Val(Me.TEXTTotal.Text) <> (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue)) Then
                MsgBox("⁄›Ê« .. ÌÃ» «‰ ÌﬂÊ‰ «Ã„«·Ì «·’‰œÊﬁ Ê«·‘Ìﬂ „”«ÊÌ «·Ï «Ã„«·Ì «·›« Ê—…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim ch As Double
            Dim ch1 As Double
            ch = Me.TEXTTotal.Text
            ch1 = Me.TextFundBalance.Text
            If ch1 < ch Then
                MsgBox("«‰ »Â —’»œ «·’‰œÊﬁ ·« Ìﬂ›Ì ·Â–Â «·Õ—ﬂ…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = True Then
                MsgBox("·«Ì„ﬂ‰  ⁄œ»·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ «· ⁄œÌ· „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonPostToCustomerTraffic.Enabled = True
            Static Dim P As Integer
            P = Me.BS.Position
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.DataGridView1_CurrentCellChanged(sender, e)
            Me.TEXTTotalN.Text = CurrencyJO(TEXTTotal.Text, "jO")
            Me.UPDATERECORD()
            Me.UPDATEInvoiceDetails()
            Me.SaveInvoiceDetails()
            Me.Load_Click(sender, e)
            Me.BS.Position = P
            Me.DataGridView1_CurrentCellChanged(sender, e)
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATERECORD()
            Me.UPDATEInvoiceDetails()
            Me.SaveInvoiceDetails()
            Me.RecordCount()
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·", Me.Text)
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferToAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ Õ–› „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        Else
            Dim resault As Integer
            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ Õ—ﬂ… «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Me.DELETEDATACUSTOMER1()
                MYDELETERECORD("Invoice", "PTRO1", Me.TEXTInvoiceNumber, Me.BS, True)
                MYDELETERECORD("InvoiceDetails", "PTRO1", Me.TEXTInvoiceNumber, Me.BS, True)
                Me.Load_Click(sender, e)
                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›", Me.Text)
            Else
                MsgBox("·«Ì„ﬂ‰ Õ–› «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ Õ–› „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.TextMovementRestrictions.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…") '1
            Else
                Me.DELETEDATMOVESDATA()
                Me.DELETEDATMOVESDATA1()
            End If
            If Me.TextMovementRestrictions1.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…") '1
            Else
                Me.DELETEDATMOVESDATA2()
                Me.DELETEDATMOVESDATA3()
            End If
            If Me.TextFundMovementNumber.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…") '2
            Else
                Me.DELETEDATAempsolf()
            End If
            If Me.TextCheckMovementNumber.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…") '3
            Else
                Me.DELETEDATBANK()
            End If
            If Me.TextCustomerTrafficNumber.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
            Else
                Me.DELETEDATA()
            End If
            If Me.TextCustomerTrafficNumber1.Text = "" Then
                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '4
            Else
                Me.DELETEDATA1()
            End If
            MYDELETERECORD("Invoice", "PTRO1", Me.TEXTInvoiceNumber, Me.BS, True)
            MYDELETERECORD("InvoiceDetails", "PTRO1", Me.TEXTInvoiceNumber, Me.BS, True)
            Me.Load_Click(sender, e)
            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›", Me.Text)
        End If
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim rpt5 As New rptTransportDetails
            Dim rpt2 As New rptTransport6
            If Me.RadioButton1.Checked = True Then
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt5, DBServer, "", "")
                Dim str As String = "SELECT * FROM Invoice   WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1=" & TEXTInvoiceNumber.EditValue
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "Invoice")
                rpt5.SetDataSource(ds)
                Dim txt1 As TextObject
                Dim txt2 As TextObject
                txt2 = rpt5.Section4.ReportObjects("Text15")
                txt1 = rpt5.Section4.ReportObjects("Text14")
                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("PTRO14"), "jO")
                txt2.Text = Year(ds.Tables(0).Rows(0).Item("PTRO5")) & "/" & ds.Tables(0).Rows(0).Item("PTRO1")
                txt1 = rpt5.Section1.ReportObjects("TEXT22")
                txt1.Text = AssociationName
                txt1 = rpt5.Section1.ReportObjects("TEXT21")
                txt1.Text = Directorate
                txt1 = rpt5.Section1.ReportObjects("Text23")
                txt1.Text = Character
                txt1 = rpt5.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt5.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                rpt5.PrintOptions.PrinterName = Me.ComboPrinterName.Text
                rpt5.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
            ElseIf Me.RadioButton2.Checked = True Then
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt5, DBServer, "", "")
                Dim S As Integer
                If Me.CountItems > 0 Then
                    For S = 0 To Me.CheckedListBox1.Items.Count - 1
                        If Me.CheckedListBox1.GetItemChecked(S) = True Then
                            Dim Str1 As String = Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.Items(S)).ToString
                            Dim strArr() As String
                            Dim a As String
                            strArr = Str1.Split("-")
                            a = strArr(0)
                            Dim str As String = "SELECT * FROM Invoice   WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1=" & a
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                            ds.Clear()
                            SqlDataAdapter1.Fill(ds, "Invoice")
                            rpt5.SetDataSource(ds)
                            Dim txt1 As TextObject
                            Dim txt2 As TextObject
                            txt2 = rpt5.Section4.ReportObjects("Text15")
                            txt1 = rpt5.Section4.ReportObjects("Text14")
                            txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("PTRO14"), "jO")
                            txt2.Text = Year(ds.Tables(0).Rows(0).Item("PTRO5")) & "/" & ds.Tables(0).Rows(0).Item("PTRO1")
                            txt1 = rpt5.Section1.ReportObjects("TEXT22")
                            txt1.Text = AssociationName
                            txt1 = rpt5.Section1.ReportObjects("TEXT21")
                            txt1.Text = Directorate
                            txt1 = rpt5.Section1.ReportObjects("Text23")
                            txt1.Text = Character
                            txt1 = rpt5.Section1.ReportObjects("TEXT40")
                            txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                            txt1 = rpt5.Section1.ReportObjects("Text44")
                            txt1.Text = Recorded
                            rpt5.PrintOptions.PrinterName = Me.ComboPrinterName.Text
                            rpt5.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                        End If
                    Next
                End If
            ElseIf Me.RadioButton3.Checked = True Then
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim str As New SqlCommand("SELECT * FROM Invoice  WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO22='" & False & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "Invoice")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt2.Section1.ReportObjects("TEXT22")
                    txt.Text = AssociationName
                    txt = rpt2.Section1.ReportObjects("TEXT21")
                    txt.Text = Directorate
                    txt = rpt2.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt2.Section1.ReportObjects("TEXT40")
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt2.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    rpt2.PrintOptions.PrinterName = Me.ComboPrinterName.Text
                    rpt2.PrintToPrinter(NumericUpDown1.Value, CheckBox1.Checked, NumericUpDown2.Value, NumericUpDown3.Value)
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub InstalledPrinters()
        Dim prtdoc As New PrintDocument
        Dim strDefaultPrinter As String = prtdoc.PrinterSettings.PrinterName
        Dim strPrinter As String
        For Each strPrinter In PrinterSettings.InstalledPrinters
            Me.ComboPrinterName.Items.Add(strPrinter)
            If strPrinter = strDefaultPrinter Then
                Me.ComboPrinterName.SelectedIndex = Me.ComboPrinterName.Items.IndexOf(strPrinter)
            End If
        Next strPrinter
    End Sub
    Private Sub TRANSFERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPostToCustomerTraffic.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            If Me.TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            If Me.CheckTransferToAccounts.Checked = False Then
                MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Button3_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            Static P As Integer
            If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTNetValue.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
                        Else
                            Me.DELETEDATA()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '5
                        Else
                            Me.DELETEDATA1()
                        End If
                        TransforCustomerTraffic()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                '======================================================================================================
            ElseIf Me.ComboPaymentMethod.Text = "‘Ìﬂ" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTNetValue.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
                        Else
                            Me.DELETEDATA()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '5
                        Else
                            Me.DELETEDATA1()
                        End If
                        TransforCustomerTraffic()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
                '=============================================================================================================
            Else
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï Õ—ﬂ… «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï Õ—ﬂ…«·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTNetValue.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCustomerTrafficNumber.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ ‰ﬁœ«", 16, " ‰»Ì…") '4
                        Else
                            Me.DELETEDATA()
                        End If
                        If Me.TextCustomerTrafficNumber1.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡ Ã«—Ì", 16, " ‰»Ì…") '5
                        Else
                            Me.DELETEDATA1()
                        End If
                        TransforCustomerTraffic()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If

            Me.BS.Position = P
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATERECORD()
            Me.UPDATEInvoiceDetails()
            Me.SaveInvoiceDetails()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
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
    Private Sub TEXTBOX5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateMovementHistory.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.ComboCustomerName.Focus()
        End Select
    End Sub
    Private Sub ComboBox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboCustomerName.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextCreditAccount.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX15_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.DataGridView1.Focus()
        End Select
    End Sub
    Private Sub DataGridView1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTExpenseType.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX10_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTExpenseType.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTExpensesValue.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX12_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTTransfers.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX13_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTDiscountValue.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTExpensesValue_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTExpensesValue.DoubleClick
        On Error Resume Next
        Me.TEXTExpensesValue.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTTotalN.TextChanged, TEXTExpensesValue.EditValueChanged, TEXTTransfers.EditValueChanged, TEXTQuantity.EditValueChanged, TEXTNetValue.TextChanged, TEXTDiscountValue.EditValueChanged, TextTaxes.EditValueChanged
        On Error Resume Next
        Me.TEXTTaxRate.Text = Format(Val(Me.TEXTTotalValue.Text) * Val(Me.TextTaxes.EditValue) / 100, "0.000")
        Me.TEXTNetValue.Text = Format(Val(Me.TEXTTotalValue.Text) - Val(Me.TEXTTaxRate.Text), "0.000")
        Me.TEXTTotal.Text = Format(Val(Me.TEXTNetValue.Text) + Val(Me.TEXTExpensesValue.EditValue) + Val(Me.TEXTTransfers.EditValue - Val(Me.TEXTDiscountValue.EditValue)), "0.000")
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        'Me.TEXTLetteringQuantity.Text = CurrencyJO(Me.TEXTQuantity.EditValue, "WEIGHT")


        If TEXTQuantity.Text <> "" And Len(Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value) > 0 Then Me.TEXTLetteringQuantity.Text = AmountWord(Me.TEXTQuantity.Text) & " " & Me.DataGridView1.Item(9, DataGridView1.CurrentRow.Index).Value
    End Sub
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust,cust7,cust22  FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.TEXTADDRESS.Text = ds.Tables(0).Rows(0).Item(1)
            Me.TypeCustomer = ds.Tables(0).Rows(0).Item(2)
        Else
            Me.TextCustomerNumber.EditValue = ""
            Me.TEXTADDRESS.Text = ""
            Me.TypeCustomer = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub ButtonDELRECORD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDELRECORD.Click
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        On Error Resume Next
        Static Dim S As Integer
        S = BS.Position
        Dim resault As Integer
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If BS.Count > 0 Then
            resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
                    Dim n As Integer
                    n = Me.DataGridView1.Rows(row.Index).Cells(0).Value
                    Dim CMD2 As New SqlClient.SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM InvoiceDetails WHERE CSDT=" & n, Consum)
                    CMD2.CommandText = SQL2.CommandText
                    CMD2.ExecuteNonQuery()
                Next
                Consum.Close()
                Me.Load_Click(sender, e)
                Me.BS.Position = S
                Me.Load_Click(sender, e)
                Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–› ”Ã· ”Ã·«  „‰ «·‘»ﬂ…", Me.Text)
            Else
                MessageBox.Show(" „ «Ìﬁ«› ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            MessageBox.Show(" ·«ÌÊÃœ ”Ã·«  „Õœœ… ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Try
            If Me.DataGridView1.SelectedRows.Count > 0 Then
                Dim Consum As New SqlClient.SqlConnection(constring)
                For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
                    Dim n As Integer
                    n = Me.DataGridView1.Rows(row.Index).Cells(0).Value
                    Dim CMD2 As New SqlClient.SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM InvoiceDetails WHERE CSDT=" & n, Consum)
                    CMD2.CommandText = SQL2.CommandText
                    CMD2.ExecuteNonQuery()
                Next
                Consum.Close()
                For i As Integer = Me.DataGridView1.SelectedRows.Count - 1 To 0
                    Me.DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                Next
            Else
                MsgBox("Õœœ «·”·⁄… »‘ﬂ· ÃÌœ ", MsgBoxStyle.Critical, " ‰»ÌÂ")
            End If
            Exit Sub
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, " ‰»ÌÂ")
        End Try
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        On Error Resume Next
        If Me.DataGridView1.SelectedRows.Count = 0 Then
            Me.DataGridView1.Item("CSDT1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If Me.DataGridView1.Item(3, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(3, e.RowIndex).Value = MaxDate.ToString("yyyy-MM-dd")
            If Me.DataGridView1.Item(8, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(8, e.RowIndex).Value = "PVC Resin"
            If Me.DataGridView1.Item(9, e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item(9, e.RowIndex).Value = "ÿ‰"
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
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged, DataGridView1.CellEndEdit, DataGridView1.CellValueChanged
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
    Private Sub ComboITEMNAME_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboITEMNAME.SelectedIndexChanged
        If ITEMNAME_CHK = True Then
            Me.DataGridView1.CurrentRow.Cells("CSDT7").Value = ComboITEMNAME.Text
        End If
        ITEMNAME_CHK = False
    End Sub
    Private Sub ComboITEMNAME_GotFocus(sender As Object, e As EventArgs) Handles ComboITEMNAME.GotFocus
        ITEMNAME_CHK = True
    End Sub

    Private Sub DataGridView1_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView1.DataError
        On Error Resume Next
        If e.Context = DataGridViewDataErrorContexts.Commit Or e.Context = DataGridViewDataErrorContexts.ClipboardContent Or e.Context = DataGridViewDataErrorContexts.CurrentCellChange Or e.Context = DataGridViewDataErrorContexts.Display Or e.Context = DataGridViewDataErrorContexts.Formatting Or e.Context = DataGridViewDataErrorContexts.RowDeletion Or e.Context = DataGridViewDataErrorContexts.Scroll Or e.Context = DataGridViewDataErrorContexts.PreferredSize Or e.Context = DataGridViewDataErrorContexts.LeaveControl Or e.Context = DataGridViewDataErrorContexts.InitialValueRestoration Then
            Resume Next
        End If
    End Sub
    Private Sub TEXTBOX1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTInvoiceNumber.LostFocus
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.Load_Click(sender, e)
        Me.BS.Position = P
    End Sub
    Private Sub RadioButton1_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Try
            If Me.RadioButton1.Checked = True Then
                Me.CheckedListBox1.Enabled = False
            Else
                Me.CheckedListBox1.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
        Try
            Dim s As Integer
            For s = 0 To Me.CheckedListBox1.Items.Count - 1
                If Me.CheckedListBox1.GetItemChecked(s) = False Then
                    Me.CheckedListBox1.SetItemChecked(s, True)
                End If
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click
        Try
            Dim s As Integer
            For s = 0 To Me.CheckedListBox1.Items.Count - 1
                If Me.CheckedListBox1.GetItemChecked(s) = True Then
                    Me.CheckedListBox1.SetItemChecked(s, False)
                End If
            Next
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
    Private Sub ButtonPREEVIEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPREEVIEW.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim rpt1 As New rptTransportDetails
            Dim rpt2 As New rptTransport6
            Dim rpt3 As New rptTransportDetails
            Dim F1 As New FrmPRINT
            If Me.RadioButton1.Checked = True Then
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim str As New SqlCommand("SELECT * FROM Invoice  WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1='" & TEXTInvoiceNumber.EditValue & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "Invoice")
                rpt1.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt1 As TextObject
                    Dim txt2 As TextObject
                    txt2 = rpt1.Section4.ReportObjects("Text15")
                    txt2.Text = Mid(Val(Year(ds.Tables(0).Rows(0).Item("PTRO5"))), 3, 2) & "/" & ds.Tables(0).Rows(0).Item("PTRO1")
                    txt1 = rpt1.Section4.ReportObjects("Text14")
                    txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("PTRO14"), "jO")
                    txt = rpt1.Section1.ReportObjects("TEXT22")
                    txt.Text = AssociationName
                    txt = rpt1.Section1.ReportObjects("TEXT21")
                    txt.Text = Directorate
                    txt = rpt1.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt1.Section1.ReportObjects("TEXT40")
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt1.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F1.CrystalReportViewer1.ReportSource = rpt1
                    F1.CrystalReportViewer1.Zoom(94%)
                    F1.CrystalReportViewer1.Refresh()
                    F1.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf Me.RadioButton3.Checked = True Then
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim str As New SqlCommand("SELECT * FROM Invoice  WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO22='" & False & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "Invoice")
                rpt2.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt2.Section1.ReportObjects("TEXT22")
                    txt.Text = AssociationName
                    txt = rpt2.Section1.ReportObjects("TEXT21")
                    txt.Text = Directorate
                    txt = rpt2.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt2.Section1.ReportObjects("TEXT40")
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt2.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F1.CrystalReportViewer1.ReportSource = rpt2
                    F1.CrystalReportViewer1.Zoom(94%)
                    F1.CrystalReportViewer1.Refresh()
                    F1.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                Dim ds As New DataSet
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
                            Dim F As New FrmPRINT
                            Dim str As New SqlCommand("SELECT * FROM Invoice  WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and PTRO1='" & a & "'", Consum)
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
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
                                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                                txt = rpt1.Section1.ReportObjects("Text44")
                                txt.Text = Recorded
                                F.CrystalReportViewer1.ReportSource = rpt1
                                F.CrystalReportViewer1.Zoom(94%)
                                F.CrystalReportViewer1.Refresh()
                                F.Show()
                            Else
                                MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…" & " - " & Me.CheckedListBox1.GetItemText(Me.CheckedListBox1.Items(S)).ToString, "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                                Exit For
                            End If
                        End If
                    Next
                End If
            End If
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
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DataGridView1.Enabled = False
            Me.TEXTInvoiceNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTQuantity.Enabled = False
            Me.TEXTExpenseType.Enabled = False
            Me.TextTaxes.Enabled = False
            Me.TEXTExpensesValue.Enabled = False
            Me.TEXTTransfers.Enabled = False
            Me.TEXTCarNumbers.Enabled = False
            Me.TEXTDiscountValue.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicAccountLevel.Enabled = False
        ElseIf Me.CheckTransferToAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonPostToCustomerTraffic.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.PRINTBUTTON.Enabled = True

            Me.DataGridView1.Enabled = True
            Me.TEXTInvoiceNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTQuantity.Enabled = True
            Me.TEXTExpenseType.Enabled = True
            Me.TextTaxes.Enabled = True
            Me.TEXTExpensesValue.Enabled = True
            Me.TEXTTransfers.Enabled = True
            Me.TEXTCarNumbers.Enabled = True
            Me.TEXTDiscountValue.Enabled = True
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DataGridView1.Enabled = False
            Me.TEXTInvoiceNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTQuantity.Enabled = False
            Me.TEXTExpenseType.Enabled = False
            Me.TextTaxes.Enabled = False
            Me.TEXTExpensesValue.Enabled = False
            Me.TEXTTransfers.Enabled = False
            Me.TEXTCarNumbers.Enabled = False
            Me.TEXTDiscountValue.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicAccountLevel.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.DataGridView1.Enabled = True
            Me.TEXTInvoiceNumber.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTQuantity.Enabled = True
            Me.TEXTExpenseType.Enabled = True
            Me.TextTaxes.Enabled = True
            Me.TEXTExpensesValue.Enabled = True
            Me.TEXTTransfers.Enabled = True
            Me.TEXTCarNumbers.Enabled = True
            Me.TEXTDiscountValue.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.ComboDebitAccount.Enabled = True
            Me.PicAccountLevel.Enabled = True
        End If

    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferToAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ·«Ì„ﬂ‰ „—«Ã⁄… «·”Ã·«  ﬁ»· «· —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATERECORD()
        Me.Load_Click(sender, e)
        Me.UPDATERECORD()
        Me.BS.Position = P
        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "„—«Ã⁄…", Me.Text)
        Me.RecordCount()
        MsgBox(" „  ⁄„·Ì… «·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „—«Ã⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckLogReview.Checked = False Then
            MsgBox("⁄›Ê« .. Â–« «·”Ã· €Ì— „—«Ã⁄ ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATERECORD()
        Me.Load_Click(sender, e)
        Me.UPDATERECORD()
        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "≈·€«¡ «·„—«Ã⁄", Me.Text)
        Me.BS.Position = P
        MsgBox(" „  ⁄„·Ì… ≈·€«¡«·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
    End Sub




    Private Sub ComboBox5_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
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
            account_noF = ds2.Tables(0).Rows(0).Item(0)
            account_nameF = ds2.Tables(0).Rows(0).Item(2)
            ACCF = ds2.Tables(0).Rows(0).Item(1)
        Else
            account_noF = ""
            account_nameF = ""
            ACCF = ""
        End If

        AutoEx()
    End Sub




    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "›« Ê— ‰ﬁ· „›’·…" & " " & ":" & " " & Me.TEXTInvoiceNumber.EditValue & " " & "» «—ÌŒ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "··⁄„Ì·" & " " & ":" & " " & Me.ComboCustomerName.Text & " " & "„À» … »ÊÀÌﬁ… —ﬁ„" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
        Me.LabelStatement.Text = ExResult

    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp3 As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT DISTINCT STK9 FROM STOCKS WHERE STK7 = '" & Me.DataGridView1.CurrentRow.Cells("CSDT7").Value & " '", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp.Fill(ds)
        'If Me.DataGridView1.CurrentCell.ColumnIndex = 2 Then
        If ds.Tables(0).Rows.Count > 0 Then
            Me.DataGridView1.CurrentRow.Cells("CSDT8").Value = ds.Tables(0).Rows(0).Item(0)
        End If
        'End If
        Adp.Dispose()
        Consum.Close()
    End Sub

    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod.Text = "‰ﬁœ«_‘Ìﬂ" Then
                Connection.ACONET1.Add("«·’‰œÊﬁ")
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
    Private Sub ButtonCUSTOMER1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If CheckPostToCustomerTraffic.Checked = True Then
                MessageBox.Show(" ‰»ÌÂ. ﬁÌœ Õ—ﬂ… «·⁄„·«¡  „—Õ·" & ControlChars.CrLf &
                            "1) «·€«¡  —ÕÌ·  «·Ï Õ—ﬂ… «·⁄„·«¡" & ControlChars.CrLf &
                            "2) ﬁ„ » —ÕÌ· «·Ï «·Õ”‹‹‹‹‹‹‹«»«  ", "Œÿ√", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonTransferofAccounts.Enabled = False
                Exit Sub
            End If

            If TransferofAccounts = False Then
                MsgBox("⁄›Ê« ..€Ì— „”„ÊÕ ·ﬂ » —ÕÌ· «·”Ã·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            If TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            Me.ComboBox1_SelectedIndexChanged(sender, e)
            Dim N As Double
            GetAutoNumber("IDCAB", "CABLES", "CAB3")
            N = AutoNumber
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql2 As New SqlCommand("SELECT DISTINCT IDCAB FROM CABLES WHERE CUser = '" & CUser & " '", Consum)
            Dim ds2 As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
            ds2.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp1.Fill(ds2, "CABLES")
            If ds2.Tables(0).Rows.Count > 0 Then
                If Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.EditValue, N)), "0.000") > 0 Then
                    MsgBox("⁄›Ê« ·« Ì„ﬂ‰..   „   ”ÊÌ… Õ—ﬂ… «·⁄„Ì·", 16, " ‰»ÌÂ")
                    ButtonTransferofAccounts.Enabled = False
                    Exit Sub
                End If
            End If
            Consum.Close()
            Me.Button3_Click(sender, e)
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            Static P As Integer
            If OBCHK6 = True Then

                If Me.CheckTransferToAccounts.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferToAccounts.Checked = True
                        TransforAccounts()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        TransforAccounts()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œÊﬁ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferToAccounts.Checked = False
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œÊﬁ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATAempsolf()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '======================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "‘Ìﬂ" Then
                    If Me.ComboCheckDrawerName.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· «”„ ”«Õ» «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.ComboCheckDrawerName.Focus()
                        Exit Sub
                    End If
                    If Me.TextCheckNumber.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· —ﬁ„ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.TextCheckNumber.Focus()
                        Exit Sub
                    End If
                    If Me.CheckDate.Value = Nothing Then
                        MsgBox("ÌÃ» ≈œŒ«·  «—ÌŒ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.CheckDate.Focus()
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·‘Ìﬂ«   ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod.Text = "‰ﬁœ«_‘Ìﬂ" Then
                    If Me.ComboCheckDrawerName.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· «”„ ”«Õ» «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.ComboCheckDrawerName.Focus()
                        Exit Sub
                    End If
                    If Me.TextCheckNumber.Text = "" Then
                        MsgBox("ÌÃ» ≈œŒ«· —ﬁ„ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.TextCheckNumber.Focus()
                        Exit Sub
                    End If
                    If Me.CheckDate.Value = Nothing Then
                        MsgBox("ÌÃ» ≈œŒ«·  «—ÌŒ «·‘Ìﬂ", 16, " ‰»ÌÂ")
                        Me.CheckDate.Focus()
                        Exit Sub
                    End If
                    If Me.CheckTransferToAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·’‰œÊﬁ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·‘Ìﬂ« ", 16, " ‰»Ì…")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·ﬁÌÊœ «·ÌÊ„Ì… ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            Me.BS.Position = P
            Me.DataGridView1_CurrentCellChanged(sender, e)
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATERECORD()
            Me.UPDATEInvoiceDetails()
            Me.SaveInvoiceDetails()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()

        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
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
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCustomerTrafficNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber.Text.Trim)
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
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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
    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me.AccountsEnquiry()
    End Sub

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("Â·  —Ìœ ≈·€«¡  Õœ»À «·Õ”«»«  «·«› —«÷Ì… ", " Õœ»À «·Õ”«»« ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
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






    Private Sub TransforCustomerTraffic()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing

            nem = " Õ„Ì· ›« Ê—… ‰ﬁ· ⁄·Ï «·⁄„Ì·" & " " & Me.ComboCustomerName.Text
            PMO2 = 1


            DebitAccount_No = keyAccounts.GetValue("CustomerAccount_No", CustomerAccount_No)
            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
            CredAccount_NO = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam
            SEARCHDATA.MaxIDMoves()

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, True, TEXTTotal.Text, TEXTTotal.Text, T3, "ﬁÌœ", "TLA", TextMovementSymbol.EditValue, False)

            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, True, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTTotal.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, True, T2)

            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTInvoiceNumber.EditValue,
                      "„. ›« Ê—… ‰ﬁ·" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‘Ìﬂ"
                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTInvoiceNumber.EditValue,
                     "„ . ›« Ê—… ‰ﬁ·" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‰ﬁœ«_‘Ìﬂ"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTInvoiceNumber.EditValue,
                      "„. ›« Ê—… ‰ﬁ·" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)

                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTInvoiceNumber.EditValue,
                     "„ . ›« Ê—… ‰ﬁ·" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.EditValue, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)




            End Select

        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = " ›« Ê—… ‰ﬁ· —ﬁ„" & " " & Me.TEXTInvoiceNumber.EditValue
        nem1 = "’—› ›« Ê—… ‰ﬁ· —ﬁ„" & " " & Me.TEXTInvoiceNumber.EditValue
        nem2 = " ›« Ê—… ‰ﬁ· »Ì„ÊÃ» „” ‰œ —ﬁ„" & " " & Me.TextCheckNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()


        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "ﬁÌœ", "TL", TextMovementSymbol.EditValue, False)
        If OBCHK6 = True Then
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "‘Ìﬂ"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                              TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Case "‰ﬁœ«_‘Ìﬂ"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTInvoiceNumber.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)


            End Select

        End If

    End Sub

    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
            Case "‘Ìﬂ"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "‰ﬁœ«_‘Ìﬂ"
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub

    Private Sub AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                TextValueOfCheck.EditValue = 0
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
                LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = FundAccount_Name
            Case "‘Ìﬂ"
                TextFundValue.EditValue = 0
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = False
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
            Case "‰ﬁœ«_‘Ìﬂ"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
                LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
        End Select
    End Sub

    Private Sub DELETEDATBANK()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
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
            ElseIf RadioEMPLOYEES.Checked = True Then
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
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
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCustomerTrafficNumber1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber1.Text.Trim)
            f.TB1 = Trim(Me.TextCustomerTrafficNumber1.Text)
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
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
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
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
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
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = SEARCHDATA.MOV1B

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTInvoiceNumber.EditValue)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH

        SEARCHDATA.SEARCHCABLES(Me.TEXTInvoiceNumber.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber.Text = SEARCHDATA.IDCAB
        SEARCHDATA.SEARCHCABLES1(Me.TEXTInvoiceNumber.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber1.Text = SEARCHDATA.IDCAB1
    End Sub


    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("⁄⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… ≈—›«ﬁ «·„” ‰œ« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
           Dim XLO As Int64
            XLO = Me.TEXTInvoiceNumber.EditValue
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
            f.TEXTFileSubject.Text = "„” ‰œ«  „ . ‰ﬁ· "
            f.TextFileDescription.Text = "«—›«ﬁ „” ‰œ«  „ . ‰ﬁ·  ›’Ì·Ì…"
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
                MsgBox("·« ÌÊÃœ «Ì „” ‰œ« ", 64 + 524288, " ‰»ÌÂ")
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
            CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            CB2 = ""
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


End Class