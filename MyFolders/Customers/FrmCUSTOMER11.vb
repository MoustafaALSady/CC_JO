Option Explicit Off
Imports System.Data.Common

Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class FrmCUSTOMER11
    Inherits Form

    ReadOnly T As Boolean = True, F As Boolean = False
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
    Dim SqlDataAdapter3 As New SqlDataAdapter
    Dim SqlDataAdapter4 As New SqlDataAdapter
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker

    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()


    Public WithEvents BS As New BindingSource
    ReadOnly ds1 As New DataSet

    Dim Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim fprint As Boolean = True
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String


    Dim _Type1 As String
    Dim TypeCustomer As String
    Public ID As Integer
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Public TB4 As String
    Public TB5 As String
    Public TB6 As String
    Dim IDCAB1 As Int64
    Dim IDCAB2 As Int64

    Private Sub FrmCUSTOMER11_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonXP3_Click(sender, e)
                    Case Keys.F10
                        Me.TRANSFERBUTTON_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonXP2_Click(sender, e)
                    Case Keys.F12
                        Me.BUTTONDELRECORD_Click(sender, e)
                    Case Keys.A And (e.Shift And Not e.Control And Not e.Alt)
                        Me.BUTTON1_Click(sender, e)
                    Case Keys.B And (e.Shift And Not e.Control And Not e.Alt)
                        Me.BUTTON2_Click(sender, e)
                    Case Keys.A And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonInsertData_Click(sender, e)
                    Case Keys.B And (e.Alt And Not e.Control And Not e.Shift)
                        Me.CMDBROWSE_Click_1(sender, e)
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
    Private Sub FrmCUSTOMER11_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
    End Sub
    Private Sub FrmCUSTOMER11_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
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
        Me.BUTTONPerks.Enabled = False
        Me.BUTTONClearance.Enabled = False
        Me.ButtonPostToCustomerTraffic.Enabled = False
        Me.ButtonInsertData.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonAttachDocument.Enabled = False
        Me.ButtonViewDocuments.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.BUTTONDELRECORD.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        TestkeyAccounts(keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No)
        End If
        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        'Dim f As New frmCustomer12
        'f.SearchBUTTON.PerformClick()
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("SELECT   CEMP1, CEMP2, CEMP3, CEMP4, CEMP5, CEMP6, CEMP7, CEMP8, CEMP9, CEMP10, CEMP11, CEMP12, CEMP13, CEMP14, CEMP15, CEMP16, CEMP17, CEMP18, CEMP19, CEMP20, CEMP21, CEMP22, CEMP23, CEMP24, CEMP25, CEMP26, CEMP27, CEMP28, CEMP29, CEMP30, CEMP31, CEMP32, CEMP33, CEMP34, CEMP35, CEMP36, CB1, BN2, USERNAME, CUser, COUser, da, ne, da1, ne1 FROM CABLESCOEMPLOYEES  WHERE   CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Strings.Trim(Me.TB1) & "'or CEMP4 ='" & Strings.Trim(Me.TB2) & "'or CEMP9 ='" & Strings.Trim(Me.TB3) & "' and CEMP10 ='" & Strings.Trim(Me.TB4) & "'or CEMP28 ='" & Strings.Trim(Me.TB5) & "'or CEMP29 ='" & Strings.Trim(Me.TB6) & "'ORDER BY CEMP1", Consum)
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

        Me.DataGridView1.Columns("CEMP3").Visible = False

        'Me.BUTTONClearance.PerformClick()
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Me.SqlDataAdapter3.Dispose()
        Me.SqlDataAdapter4.Dispose()
        Consum.Close()
        Auditor("CABLESCOEMPLOYEES", "USERNAME", "CEMP1", Me.TEXTID.Text, "")
        Logentry = Uses
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
        Me.ComboSearch.SelectedIndex = Me.TEXTSearch.SelectedIndex
        'Me.SumAmounCABLESCOt()
        'Me.SumAmounCABLESEMPLOYEES()
        'Me.SumAmounCABLESCOtFOLLOWACCOUNT()
        Me.RecordCount()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.load1.Enabled = False
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("SELECT   CEMP1, CEMP2, CEMP3, CEMP4, CEMP5, CEMP6, CEMP7, CEMP8, CEMP9, CEMP10, CEMP11, CEMP12, CEMP13, CEMP14, CEMP15, CEMP16, CEMP17, CEMP18, CEMP19, CEMP20, CEMP21, CEMP22, CEMP23, CEMP24, CEMP25, CEMP26, CEMP27, CEMP28, CEMP29, CEMP30, CEMP31, CEMP32, CEMP33, CEMP34, CEMP35, CEMP36, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM CABLESCOEMPLOYEES  WHERE   CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Strings.Trim(Me.TB1) & "'or CEMP4 ='" & Strings.Trim(Me.TB2) & "'or CEMP9 ='" & Strings.Trim(Me.TB3) & "' and CEMP10 ='" & Strings.Trim(Me.TB4) & "'or CEMP28 ='" & Strings.Trim(Me.TB5) & "'or CEMP29 ='" & Strings.Trim(Me.TB6) & "'ORDER BY CEMP3", Consum)
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
        Me.DataGridView1.Columns("CEMP3").Visible = False

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
        Me.BUTTON1_Click(sender, e)
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
        Me.ComboSearch.SelectedIndex = Me.TEXTSearch.SelectedIndex
        Me.SumAmounCABLESCOt()
        Me.SumAmounCABLESEMPLOYEES()
        Me.SumAmounCABLESCOtFOLLOWACCOUNT()
        Me.RecordCount()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.load1.Enabled = False
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
    Private Sub TEXTBOX25_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub SumAmounCABLESCOt()
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CCUST2) AS SUMSUBTOTALS FROM CABLESCO WHERE CEMP3 = " & Me.TEXTCertificateNumber.EditValue & " GROUP BY CEMP3", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotalTips.Text = Format(ds.Tables(0).Rows(0).Item(0), "0.000")
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub SumAmounCABLESEMPLOYEES()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CEMP2) AS SUMSUBTOTALS FROM CABLESEMPLOYEES WHERE CEMP3 = " & Me.TEXTCertificateNumber.EditValue & " GROUP BY CEMP3", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotalClearance.Text = Format(ds.Tables(0).Rows(0).Item(0), "0.000")
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub SumAmounCABLESCOtFOLLOWACCOUNT()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT Sum(CCUST2) AS SUMSUBTOTALSFOLLOWACCOUNT FROM CABLESCO WHERE CEMP3 = " & Me.TEXTCertificateNumber.EditValue & " GROUP BY CEMP3", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        Me.TEXTcash.EditValue = Val(Me.TextFundValue.EditValue)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTTotalTips.Text = Val(ds.Tables(0).Rows(0).Item(0))
            Me.TextValueOfCheck.EditValue = Format(Val(Me.TEXTTotalTips.Text) - Val(Me.TEXTcash.EditValue), "0.000")
        Else
            Me.TextValueOfCheck.EditValue = "0"
            Me.TEXTcash.EditValue = Format(Val(Me.TEXTTotalTips.Text), "0.000")
        End If

        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
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
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " „‰ " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds1.Tables("CABLESCOEMPLOYEES").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.DISPLAYRECORD()
        Me.SumAmounCABLESCOt()
        Me.SumAmounCABLESEMPLOYEES()
        Me.SumAmounCABLESCOtFOLLOWACCOUNT()
        Me. AccountsEnquiry()
        Me.FundBalance()
        Me.AutoEx()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.BUTTONCANCEL.Enabled = True
        Me.TEXTID.Enabled = False
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
                MsgBox("ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› «·”Ã· «·„Õœœ" & vbCrLf & "”Ê› Ì „  ÕœÌÀ «·”Ã·«  «·¬‰", 16, " ‰»ÌÂ")
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
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »Õ–› ”Ã·«  ⁄œœ " & Me.RowCount - Me.BS.Count, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox(" „  ⁄„·Ì… «·Õ›Ÿ ›Ì ﬁ«⁄œ… «·»Ì«‰«  »‰Ã«Õ" & vbCrLf & "  ‰»ÌÂ : ﬁ«„ «Õœ «·„” Œœ„Ì‰ »«÷«›… ”Ã·«  ⁄œœ " & Me.BS.Count - Me.RowCount, 64 + 524288, " ‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—« ")
                Exit Sub
            End If
            Dim Sound As IO.Stream = My.Resources.save
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
        End If
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TEXTID.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP1").ToString
            .DateMovementHistory.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP2").ToString
            .TEXTCertificateNumber.EditValue = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP3").ToString
            .CreditTransferNumber.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP4").ToString
            .ComboITEMNAME.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP5").ToString
            .TEXTLetteringQuantity.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP6").ToString
            .TextWarehouseName.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP7").ToString
            .TEXTInvoiceValue.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP8").ToString
            .TEXTPolicyNumber.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP9").ToString
            .TEXTSupplier.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP10").ToString
            .DateArrival.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP11").ToString
            .DateExchange.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP12").ToString
            .ComboPaymentMethod.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP13").ToString
            .TEXTPaymentMonth.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP14").ToString
            .TextFundValue.EditValue = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP15").ToString
            .TEXTInvoiceValueN.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP16").ToString
            .TEXTTotalTips.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP17").ToString
            .TEXTTotalClearance.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP18").ToString
            .TEXTTotalTipsN.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP19").ToString
            .TEXTTotalClearanceN.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP20").ToString
            .CheckTransferAccounts.Checked = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP21").ToString
            .TextValueOfCheck.EditValue = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP22").ToString
            .TEXTcash.EditValue = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP23").ToString
            .ComboDebitAccount.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP24").ToString
            .CertificateNumbe.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP25").ToString
            .TextQuantity.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP26").ToString
            .ComboType.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP27").ToString
            .ComboCustomerName.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP28").ToString
            .TextCustomerNumber.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP29").ToString
            .CheckLogReview.Checked = ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP30").ToString
            .TextMovementSymbol.EditValue = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP31").ToString
            .TextCheckNumber.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP32").ToString
            .CheckDate.Text = ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP33").ToString
            .CheckPostToCustomerTraffic.Checked = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP34").ToString
            .ComboCheckDrawerName.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP35").ToString
            .TextCheckDrawerCode.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CEMP36").ToString

            .ComboCB1.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("CB1").ToString
            .ComboBN2.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("BN2").ToString

            .TEXTUserName.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position).Item("Auditor").ToString
            .TextDefinitionDirectorate.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("COUser").ToString
            .TEXTAddDate.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("da").ToString
            .TextTimeAdd.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("ne").ToString
            .TEXTReviewDate.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("da1").ToString
            .TextreviewTime.Text = Me.ds1.Tables("CABLESCOEMPLOYEES").Rows(Me.BS.Position)("ne1").ToString
            Auditor("CABLESCOEMPLOYEES", "USERNAME", "CEMP1", Me.TEXTID.Text, "")
            Logentry = Uses
            TestkeyAccounts(keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("PurchaseExpenseAccount_No", PurchaseExpenseAccount_No)
            End If
            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If

            Me.FundBalance()
            Call MangUsers()
            Me.BUTTONCANCEL.Enabled = True
        End With
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.BUTTONDELRECORD.Enabled = LockDelete
        Me.ButtonInsertData.Enabled = LockUpdate
        Me.BUTTONClearance.Enabled = True
        Me.BUTTONPerks.Enabled = True
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonPostToCustomerTraffic.Enabled = TransferofAccounts
        Me.ButtonAttachDocument.Enabled = LockUpdate
        Me.ButtonViewDocuments.Enabled = True
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub
    Private Sub DELETEDATA()
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
    Private Sub DELETEDATA1()
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
                NO = ""
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        If IsDBNull(resualt) Then
            IDCAB2 = CType(NO1, Integer) & 1
        Else
            N = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            IDCAB2 = N
        End If
        Consum.Close()
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
            ID = Val(Me.TEXTCertificateNumber.EditValue)
            Dim SQL As New SqlCommand(" Update CABLESCOEMPLOYEES SET CEMP2 = @CEMP2, CEMP4 = @CEMP4, CEMP5 = @CEMP5, CEMP6 = @CEMP6, CEMP7 = @CEMP7, CEMP8 = @CEMP8, CEMP9 = @CEMP9, CEMP10 = @CEMP10, CEMP11 = @CEMP11, CEMP12 = @CEMP12, CEMP13 = @CEMP13, CEMP14 = @CEMP14, CEMP15 = @CEMP15, CEMP16 = @CEMP16, CEMP17 = @CEMP17, CEMP18 = @CEMP18, CEMP19 = @CEMP19, CEMP20 = @CEMP20, CEMP21 = @CEMP21, CEMP22 = @CEMP22, CEMP23 = @CEMP23, CEMP24 = @CEMP24, CEMP25 = @CEMP25, CEMP26 = @CEMP26, CEMP27 = @CEMP27, CEMP28 = @CEMP28, CEMP29 = @CEMP29, CEMP30 = @CEMP30, CEMP31 = @CEMP31, CEMP32 = @CEMP32, CEMP33 = @CEMP33, CEMP34 = @CEMP34, CEMP35 = @CEMP35, CEMP36 = @CEMP36, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE  CEMP3 = @CEMP3", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CEMP3", SqlDbType.BigInt).Value = Me.TEXTCertificateNumber.EditValue

                .Parameters.Add("@CEMP1", SqlDbType.Int).Value = Me.TEXTID.Text.Trim
                .Parameters.Add("@CEMP2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
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
                .Parameters.Add("@CEMP21", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@CEMP22", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CEMP23", SqlDbType.NVarChar).Value = Me.TEXTcash.EditValue
                .Parameters.Add("@CEMP24", SqlDbType.NVarChar).Value = Me.ComboDebitAccount.Text.Trim
                .Parameters.Add("@CEMP25", SqlDbType.NVarChar).Value = Me.CertificateNumbe.Text.Trim
                .Parameters.Add("@CEMP26", SqlDbType.NVarChar).Value = Me.TextQuantity.Text.Trim
                .Parameters.Add("@CEMP27", SqlDbType.NVarChar).Value = Me.ComboType.Text.Trim
                .Parameters.Add("@CEMP28", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text.Trim
                .Parameters.Add("@CEMP29", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.Text.Trim
                .Parameters.Add("@CEMP31", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CEMP32", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@CEMP33", SqlDbType.Date).Value = Me.CheckDate.Value
                .Parameters.Add("@CEMP30", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CEMP34", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked)
                .Parameters.Add("@CEMP35", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CEMP36", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
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
    Private Sub FrmCUSTOMER11_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Activated
        On Error Resume Next
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


            nem = "  Õ„Ì· „ .  Œ·Ì’ „‘ —Ì«  ⁄·Ï" & " " & Me.ComboCheckDrawerName.Text.Trim
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
            SEARCHDATA.MAXIDMOVES()

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, True, TEXTTotalTips.Text, TEXTTotalTips.Text, T3, "ﬁÌœ", "ERA", TextMovementSymbol.EditValue, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, True, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTTotalTips.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, True, T2)

            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTCertificateNumber.EditValue,
                      "„. ›« Ê—… ‰ﬁ·" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.Text, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‘Ìﬂ"
                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTCertificateNumber.EditValue,
                     "„ . ›« Ê—… ‰ﬁ·" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.Text, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‰ﬁœ«_‘Ìﬂ"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTCertificateNumber.EditValue,
                      "„. ›« Ê—… ‰ﬁ·" & "  " & Me.ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.Text, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)

                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTCertificateNumber.EditValue,
                     "„ . ›« Ê—… ‰ﬁ·" & "  " & ComboCustomerName.Text, ComboCustomerName.Text, TextCustomerNumber.Text, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
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

        nem = "„ .  Œ·Ì’ „‘ —Ì« " & "_" & Me.CertificateNumbe.Text
        nem1 = "’—› ‰ﬁœÌ „ . „‘ —Ì«  —ﬁ„" & "_" & Me.CertificateNumbe.Text
        nem2 = "„ .  Œ·Ì’ „‘ —Ì«  »Ì„ÊÃ» „” ‰œ —ﬁ„ " & "_" & Me.TextCheckNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()


        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotalTips.Text, TEXTTotalTips.Text, T3, "ﬁÌœ", "ER", TextMovementSymbol.EditValue, False)
        If OBCHK6 = True Then
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
            DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TEXTTotalTips.Text, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TEXTTotalTips.Text, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.Text & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "‘Ìﬂ"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                              TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Case "‰ﬁœ«_‘Ìﬂ"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotalTips.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.Text, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "’—›", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.Text & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "’—›", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

            End Select
        End If

    End Sub

    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                TextFundValue.EditValue = Val(TEXTTotalTips.Text)
                TextValueOfCheck.EditValue = 0
            Case "‘Ìﬂ"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text)
            Case "‰ﬁœ«_‘Ìﬂ"
                TextFundValue.EditValue = Val(TEXTTotalTips.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub

    Private Sub  AccountsEnquiry()
        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod
        On Error Resume Next
        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotalTips.Text)
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
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text)
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
            Case "‰ﬁœ«_‘Ìﬂ"
                Me.TextValueOfCheck.Enabled = True
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotalTips.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotalTips.Text) - Val(TextFundValue.EditValue)
                LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
        End Select
    End Sub

    Private Sub BUTTON1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONClearance.Click
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

    Private Sub BUTTON2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONPerks.Click
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

    Private Sub TRANSFERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
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
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Me.List1.Visible = True
                Exit Sub
            End If
            Me.ComboBox2_SelectedIndexChanged(sender, e)
            Me.Button3_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            Dim N As Double
            GetAutoNumber("IDCAB", "CABLES", "CAB3")
            N = AutoNumber
            Dim Consum As New SqlConnection(constring)
            Dim strsql2 As New SqlCommand("SELECT DISTINCT IDCAB FROM CABLES WHERE CUser = '" & CUser & " '", Consum)
            Dim ds2 As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsql2)
            ds2.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp1.Fill(ds2, "CABLES")
            If ds2.Tables(0).Rows.Count > 0 Then
                If Format(Val(SumAmounTOTALCASHANDCHEQUES(Me.TextCustomerNumber.Text, N)), "0.000") > 0 Then
                    MsgBox("⁄›Ê« ·« Ì„ﬂ‰..   „   ”ÊÌ… Õ—ﬂ… «·⁄„Ì·", 16, " ‰»ÌÂ")
                    Me.ButtonTransferofAccounts.Enabled = False
                    Exit Sub
                End If
            End If
            Consum.Close()
            Static P As Integer
            If OBCHK6 = True Then
                If Me.CheckTransferAccounts.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·’‰œÊﬁ Ê «·⁄„Ì· " & Me.ComboCustomerName.Text, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts.Checked = True
                        '==================================
                        TransforAccounts()
                        Insert_Actions(Me.TEXTID.Text.Trim, " —ÕÌ· ««·Ï Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„Ì·" & " " & Me.ComboCustomerName.Text, Me.Text)
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
                        '==================================
                        TransforAccounts()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„Ì·" & " " & Me.ComboCustomerName.Text, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = False
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            '==================================
                            Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„Ì·" & " " & Me.ComboCustomerName.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                Me.TextFundValue.Enabled = False
                If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·’‰œÊﬁ Ê «·⁄„Ì· " & Me.ComboCustomerName.Text, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            Insert_Actions(Me.TEXTID.Text.Trim, " —ÕÌ· ««·Ï Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„Ì·" & " " & Me.ComboCustomerName.Text, Me.Text)
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
                            '==================================
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„Ì·" & " " & Me.ComboCustomerName.Text, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.CheckTransferAccounts.Checked = False
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATAempsolf()
                                '==================================
                                Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·’‰œÊﬁ Ê «·⁄„Ì·" & " " & Me.ComboCustomerName.Text, Me.Text)
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
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            '==================================
                            TransforAccounts()
                            Insert_Actions(Me.TEXTID.Text.Trim, "  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                            '==================================
                            TransforAccounts()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·‘Ìﬂ«   ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATBANK()
                                Me.CheckTransferAccounts.Checked = False
                                '==================================
                                Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œÊﬁ Ê «·‘Ìﬂ«  —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            '======================================
                            Insert_Actions(Me.TEXTID.Text.Trim, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                            Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  ", Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œ“ﬁ Ê «·‘Ìﬂ«  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.CheckTransferAccounts.Checked = False
                                Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  ", Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            Me.BS.Position = P
            Me.SumAmounCABLESCOt()
            Me.SumAmounCABLESEMPLOYEES()
            Me.SumAmounCABLESCOtFOLLOWACCOUNT()
            Me.UPDATECABLESCOEMPLOYEES()
            Me.UPDATECABLESCO()
            Me.UPDATECABLESEMPLOYEES()
            Me.SaveCABLESEMPLOYEES()
            Me.SaveCABLESCO()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim F As New FrmPRINT
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        If Me.CheckUnreviewedRecords.Checked = True Then
            Dim ds As New DataSet
            Dim rpt11 As New rptCustomer121
            GETSERVERNAMEANDDATABASENAME(rpt11, DBServer, "", "")
            Dim str1 As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES    WHERE  CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  CEMP30 ='" & False & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
            rpt11.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt = rpt11.Section1.ReportObjects("TEXT22")
                txt.Text = AssociationName
                txt = rpt11.Section1.ReportObjects("TEXT21")
                txt.Text = Directorate
                txt = rpt11.Section1.ReportObjects("Text23")
                txt.Text = Character
                txt = rpt11.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt11.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                F.CrystalReportViewer1.ReportSource = rpt11
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            Else
                MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            If fprint = True Then
                If Len(Me.TEXTCertificateNumber.EditValue) = 0 Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·‘Â«œ…  «· Ï  »ÕÀ ⁄‰Â«", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.TEXTCertificateNumber.Focus()
                    Exit Sub
                End If
                Dim rpt5 As New rptCustomer51
                Dim ds As New DataSet
                GETSERVERNAMEANDDATABASENAME(rpt5, DBServer, "", "")
                Dim str As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES  WHERE  CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Me.TEXTCertificateNumber.EditValue & "' AND CEMP29='" & TextCustomerNumber.Text & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt5.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    txt = rpt5.Section1.ReportObjects("TEXT22")
                    txt.Text = AssociationName
                    txt = rpt5.Section1.ReportObjects("TEXT21")
                    txt.Text = Directorate
                    txt = rpt5.Section1.ReportObjects("Text23")
                    txt.Text = Character
                    txt = rpt5.Section1.ReportObjects("TEXT40")
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt5.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt5
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            ElseIf fprint = False Then
                If Len(Me.TEXTCertificateNumber.EditValue) = 0 Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·‘Â«œ…  «· Ï  »ÕÀ ⁄‰Â«", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.TEXTCertificateNumber.Focus()
                    Exit Sub
                End If
                Dim rpt10 As New rptCustomer10
                GETSERVERNAMEANDDATABASENAME(rpt10, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES  WHERE  CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CEMP3 ='" & Me.TEXTCertificateNumber.EditValue & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
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
                    txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt = rpt10.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt10
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            End If
        End If
    End Sub

    Private Sub BUTTONDELRECORD_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONDELRECORD.Click
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim S As Integer
        S = Me.BS.Position
        Dim resault As Integer
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        If BS.Count > 0 Then
            resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If fprint = True Then
                    Me.Cursor = Cursors.WaitCursor
                    For Each row As DataGridViewRow In Me.DataGridView1.SelectedRows
                        Dim n As Integer
                        n = Me.DataGridView1.Rows(row.Index).Cells("CCUST").Value
                        Dim CMD2 As New SqlCommand With {
                            .CommandType = CommandType.Text,
                            .Connection = Consum
                        }
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        Dim SQL2 As New SqlCommand("DELETE FROM CABLESCO WHERE CCUST=" & n, Consum)
                        CMD2.CommandText = SQL2.CommandText
                        CMD2.ExecuteNonQuery()
                    Next
                    Consum.Close()
                    Me.Load_Click(sender, e)
                    Me.BS.Position = S
                    Me.SumAmounCABLESCOt()
                    Me.SumAmounCABLESEMPLOYEES()
                    Me.SumAmounCABLESCOtFOLLOWACCOUNT()
                    Me.TEXTTotalTipsN.Text = CurrencyJO(Me.TEXTTotalTips.Text, "jO")
                    Me.TEXTTotalClearanceN.Text = CurrencyJO(Me.TEXTTotalClearance.Text, "jO")
                    Me.EDITBUTTON_Click(sender, e)
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.WaitCursor
                    For Each row As DataGridViewRow In Me.DataGridView2.SelectedRows
                        Dim n As Integer
                        n = Me.DataGridView2.Rows(row.Index).Cells("CEMP").Value
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
                    Me.BS.Position = S
                    Me.SumAmounCABLESCOt()
                    Me.SumAmounCABLESEMPLOYEES()
                    Me.SumAmounCABLESCOtFOLLOWACCOUNT()
                    Me.TEXTTotalTipsN.Text = CurrencyJO(Me.TEXTTotalTips.Text, "jO")
                    Me.TEXTTotalClearanceN.Text = CurrencyJO(Me.TEXTTotalClearance.Text, "jO")
                    Me.EDITBUTTON_Click(sender, e)
                    Me.Cursor = Cursors.Default
                End If
                Insert_Actions(Me.TEXTID.Text.Trim, " Õ–› ”Ã· „‰ «·‘»ﬂ…", Me.Text)
            Else
                MessageBox.Show(" „ «Ìﬁ«› ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            MessageBox.Show(" ·«ÌÊÃœ ”Ã· Õ«·Ï ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If

    End Sub

    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
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
            If Val(Me.TEXTTotalTips.Text) <> (Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextFundValue.EditValue)) Then
                MsgBox("⁄›Ê« .. ÌÃ» «‰ ÌﬂÊ‰ «Ã„«·Ì «·’‰œÊﬁ Ê«·‘Ìﬂ „”«ÊÌ «·Ï «Ã„«·Ì «·›« Ê—…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim ch As Double
            Dim ch1 As Double
            ch = Me.TextFundValue.EditValue
            ch1 = Me.TextFundBalance.Text
            If ch1 < ch Then
                MsgBox("«‰ »Â —’»œ «·’‰œÊﬁ ·« Ìﬂ›Ì ·Â–Â «·Õ—ﬂ…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = True Then
                MsgBox("·«Ì„ﬂ‰  ⁄œ»·  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ «· ⁄œÌ· „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.BUTTONDELRECORD.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.BUTTONClearance.Enabled = True
            Me.BUTTONPerks.Enabled = True
            Me.ButtonViewDocuments.Enabled = True
            Me.ButtonInsertData.Enabled = True
            Static Dim P As Integer
            P = Me.BS.Position
            Me.SumAmounCABLESCOt()
            Me.SumAmounCABLESEMPLOYEES()
            Me.SumAmounCABLESCOtFOLLOWACCOUNT()
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.TEXTTotalTipsN.Text = CurrencyJO(TEXTTotalTips.Text, "jO")
            Me.TEXTTotalClearanceN.Text = CurrencyJO(TEXTTotalClearance.Text, "jO")
            Me.UPDATECABLESCOEMPLOYEES()
            Me.UPDATECABLESCO()
            Me.UPDATECABLESEMPLOYEES()
            Me.SaveCABLESEMPLOYEES()
            Me.SaveCABLESCO()
            Me.Load_Click(sender, e)
            Me.BS.Position = P
            Me.SumAmounCABLESCOt()
            Me.SumAmounCABLESEMPLOYEES()
            Me.SumAmounCABLESCOtFOLLOWACCOUNT()
            Me.TEXTTotalTipsN.Text = CurrencyJO(Me.TEXTTotalTips.Text, "jO")
            Me.TEXTTotalClearanceN.Text = CurrencyJO(Me.TEXTTotalClearance.Text, "jO")
            Me.UPDATECABLESCOEMPLOYEES()
            Me.UPDATECABLESCO()
            Me.UPDATECABLESEMPLOYEES()
            Me.SaveCABLESEMPLOYEES()
            Me.SaveCABLESCO()
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
            Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub

    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
        If LockDelete = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("·«Ì„ﬂ‰ Õ–›  «·”Ã· «·Õ«·Ï ·√‰Â „—Õ· ... Ì„ﬂ‰ Õ–› „‰ Œ·«· “—  —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        Else
            Dim resault As Integer
            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ Õ—ﬂ… «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                MYDELETERECORD("CABLESCO", "CEMP3", Me.TEXTCertificateNumber, Me.BS, True)
                MYDELETERECORD("CABLESEMPLOYEES", "CEMP3", Me.TEXTCertificateNumber, Me.BS, True)
                MYDELETERECORD("CABLESCOEMPLOYEES", "CEMP1", Me.TEXTID, Me.BS, True)
                If Me.TextMovementRestrictions.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…")
                Else
                    Me.DELETEDATMOVESDATA()
                    Me.DELETEDATMOVESDATA1()
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
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡", 16, " ‰»Ì…")
                Else
                    Me.DELETEDATA()
                End If
                If Me.TextCustomerTrafficNumber1.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì „—ﬂ“ «·⁄„·«¡", 16, " ‰»Ì…")
                Else
                    Me.DELETEDATA1()
                End If
                Me.Load_Click(sender, e)
            Else
                Exit Sub
            End If
            MYDELETERECORD("CABLESCO", "CEMP3", Me.TEXTCertificateNumber, Me.BS, True)
            MYDELETERECORD("CABLESEMPLOYEES", "CEMP3", Me.TEXTCertificateNumber, Me.BS, True)
            MYDELETERECORD("CABLESCOEMPLOYEES", "CEMP1", Me.TEXTID, Me.BS, True)
            Me.Load_Click(sender, e)
            Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›", Me.Text)
        End If
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

    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs)
        'Dim F As New frmMyDocuments
        'On Error Resume Next

        'If File.Exists("D:\CO_MAS\MyDATA\DOCUMENTS\" & Today.Year & "\gc\Customs_Charges\" & Me.TEXTBOX3.Text + ".pdf") = True Then
        '    If Not Val(Microsoft.VisualBasic.Right("C:\Program Files\Adobe\Reader 9.0", 3)) >= 9 Then
        '        F.OpenFileDialog1.FileName = "D:\CO_MAS\MyDATA\DOCUMENTS\" & Today.Year & "\gc\Customs_Charges\" & Me.TEXTBOX3.Text + ".pdf"
        '        F.WebBrowser1.Visible = False
        '        F.AxAcroPDF1.Visible = True
        '        F.AxAcroPDF1.LoadFile(F.OpenFileDialog1.FileName)
        '        F.AxAcroPDF1.setShowToolbar(True)
        '        F.AxAcroPDF1.setView("fit width")
        '        F.AxAcroPDF1.setLayoutMode("continuous")
        '        F.AxAcroPDF1.Show()
        '        F.Show()
        '    Else
        '        F.AxAcroPDF1.Visible = False
        '        F.WebBrowser1.Visible = True
        '        F.OpenFileDialog1.FileName = "D:\CO_MAS\MyDATA\DOCUMENTS\" & Today.Year & "\gc\Customs_Charges\" & Me.TEXTBOX3.Text + ".pdf"
        '        F.WebBrowser1.Navigate(F.OpenFileDialog1.FileName)
        '        F.Show()
        '    End If
        'ElseIf File.Exists("D:\CO_MAS\MyDATA\DOCUMENTS\" & Today.Year & "\gp\Customs_Charges\" & Me.TEXTBOX3.Text + ".pdf") = True Then
        '    If Not Val(Microsoft.VisualBasic.Right("C:\Program Files\Adobe\Reader 9.0", 3)) >= 9 Then
        '        F.OpenFileDialog1.FileName = "D:\CO_MAS\MyDATA\DOCUMENTS\" & Today.Year & "\gp\Customs_Charges\" & Me.TEXTBOX3.Text + ".pdf"
        '        F.WebBrowser1.Visible = False
        '        F.AxAcroPDF1.Visible = True
        '        F.AxAcroPDF1.LoadFile(F.OpenFileDialog1.FileName)
        '        F.AxAcroPDF1.setShowToolbar(True)
        '        F.AxAcroPDF1.setView("fit width")
        '        F.AxAcroPDF1.setLayoutMode("continuous")
        '        F.AxAcroPDF1.Show()
        '        F.Show()
        '    Else
        'F.AxAcroPDF1.Visible = False
        '        F.WebBrowser1.Visible = True
        '        F.OpenFileDialog1.FileName = "D:\CO_MAS\MyDATA\DOCUMENTS\" & Today.Year & "\gp\Customs_Charges\" & Me.TEXTBOX3.Text + ".pdf"
        '        F.WebBrowser1.Navigate(F.OpenFileDialog1.FileName)
        '        F.Show()
        '    End If
        'Else
        '    MessageBox.Show(" Â–« «·„·› €Ì— „ÊÃÊœ ﬁÏ «·„”«— «·„Õœœ", Me.TEXTBOX3.Text + ".pdf", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
        '    F.Show()
        'End If
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
                resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
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
                        MsgBox("Õœœ «·”·⁄… »‘ﬂ· ÃÌœ ", MsgBoxStyle.Critical, " ‰»ÌÂ")
                    End If
                    Exit Sub
                Else
                    MessageBox.Show(" „ «Ìﬁ«› ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" ·«ÌÊÃœ ”Ã·«  „Õœœ… ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, " ‰»ÌÂ")
        End Try
    End Sub
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseDoubleClick
        Try
            Dim resault As Integer
            Dim Consum As New SqlConnection(constring)
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.DataGridView1.SelectedRows.Count > 0 Then
                        For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0
                            Dim n As Integer
                            n = Me.DataGridView1.SelectedRows(i).Cells("CCUST").Value
                            DataGridView1.Rows.RemoveAt(Me.DataGridView1.SelectedRows(i).Index)
                            Dim CMD2 As New SqlCommand With {
                                .CommandType = CommandType.Text,
                                .Connection = Consum
                            }
                            If Consum.State = ConnectionState.Open Then Consum.Close()
                            Consum.Open()
                            Dim SQL2 As New SqlCommand("DELETE FROM CABLESCO WHERE CCUST=" & n, Consum)
                            CMD2.CommandText = SQL2.CommandText
                            CMD2.ExecuteNonQuery()
                        Next
                        Consum.Close()
                    Else
                        MsgBox("Õœœ «·”·⁄… »‘ﬂ· ÃÌœ ", MsgBoxStyle.Critical, " ‰»ÌÂ")
                    End If
                    Exit Sub
                Else
                    MessageBox.Show(" „ «Ìﬁ«› ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" ·«ÌÊÃœ ”Ã·«  „Õœœ… ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, " ‰»ÌÂ")
        End Try
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
    Private Sub TEXTCertificateNumber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTCertificateNumber.LostFocus
        On Error Resume Next
        Static Dim P As Integer
        P = Me.BS.Position
        Me.Load_Click(sender, e)
        Me.BS.Position = P
        'CLEANRECORD()
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
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
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
    Public Function SumAmounTOTALCASHANDCHEQUES(ByVal cust As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB4-CAB5)  FROM CABLES WHERE CAB11 = '" & cust & "'AND CABLES.CAB1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALCASHANDCHEQUES = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALCASHANDCHEQUES = "0"
        End If
        Consum.Close()
    End Function
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboType.SelectedIndexChanged, TextQuantity.TextChanged
        On Error Resume Next
        If TextQuantity.Text <> "" And Len(Me.ComboType.Text) > 0 Then Me.TEXTLetteringQuantity.Text = AmountWord(Me.TextQuantity.Text) & " " & Me.ComboType.Text
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            Me.SumAmounCABLESEMPLOYEES()
            'For i As Integer = 0 To DataGridView1.Rows.Count - 1
            '    Dim row As DataGridViewRow = DataGridView1.Rows(i)
            'If row.IsNewRow Then Continue For
            If Me.DataGridView1.SelectedRows.Count = 0 Then
                Me.DataGridView1.Item("CCUST1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
                If Me.DataGridView1.Item("CCUST3", e.RowIndex).FormattedValue.ToString = "„  Œ·Ì’ „—›ﬁ »Ì«‰ »«·„’«—Ì›" Then
                    Me.DataGridView1.Item("CCUST2", e.RowIndex).Value = Me.TEXTTotalClearance.Text.Trim
                ElseIf Me.DataGridView1.Item("CCUST3", e.RowIndex).FormattedValue.ToString = "„ ”Õ» √–‰ «· ”·Ì„ „‰ «· ÊﬂÌ· «· ⁄«Ê‰Ì" And DataGridView1.Item(3, e.RowIndex).FormattedValue.ToString = "0" Then
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
        If MsgBox("Â·  —Ìœ «÷«›… »‰Êœ ÃœÊ· «”„«¡ «·„’«—Ì› «·Ï ‘»ﬂ… «·»Ì«‰«  ø", vbYesNo + vbQuestion + vbMsgBoxRight + vbDefaultButton2 + vbMsgBoxSetForeground + vbMsgBoxRtlReading, "«·⁄„·«¡") = vbYes Then
            Dim CMD As New SqlCommand("INSERT INTO CABLESEMPLOYEES ( CEMP1, CEMP4, CEMP2, CEMP3 ) SELECT BASICDATA.[BDATA1], BASICDATA.BDATA7, BASICDATA.BDATA5, '" & Me.TEXTCertificateNumber.EditValue & "'" & " FROM BASICDATA WHERE BASICDATA.[BDATA1]<=28", Consum) With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
            Me.EDITBUTTON_Click(sender, e)
            Me.DataGridView1.Visible = False
            Me.DataGridView2.Visible = True
        Else
            Cancel = True
        End If
    End Sub
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
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
            f.TEXTFileSubject.Text = "„” ‰œ«  «·„’«—Ì›"
            f.TextFileDescription.Text = ""
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CMDBROWSE_Click_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Trim(Me.TextDOC1.Text), "'"}), Consum)
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
                f.Show()
                f.TEXTBOX1.Text = Trim(Me.TextDOC1.Text)
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
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            'Dim str As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT * FROM MYDOCUMENTSHOME WHERE  CUser='" & CUser & "'ORDER BY DOC1", Consum)
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
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextDOC1.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.Show()
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
                Me.RecordCount()
            Else
                Me.BS.Position = 0
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub CLEANRECORD()
        Try
            Dim Consum As New SqlConnection(constring)
            Static Dim S As Integer
            S = Me.BS.Position
            If Me.BS.Count > 0 Then
                Dim CMD1 As New SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim SQL1 As New SqlCommand("DELETE FROM CABLESCO WHERE CEMP3=" & Me.TEXTCertificateNumber.EditValue & " AND CCUST2 IS NULL ", Consum)
                CMD1.CommandText = SQL1.CommandText
                CMD1.ExecuteNonQuery()
                Dim CMD2 As New SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                Dim SQL2 As New SqlCommand("DELETE FROM CABLESEMPLOYEES WHERE CEMP3=" & Me.TEXTCertificateNumber.EditValue & " AND CEMP2 IS NULL ", Consum)
                CMD2.CommandText = SQL2.CommandText
                CMD2.ExecuteNonQuery()
                Consum.Close()
                'load_Click(sender, e)
                Me.BS.Position = S
                Me.SumAmounCABLESCOt()
                Me.SumAmounCABLESEMPLOYEES()
                Me.SumAmounCABLESCOtFOLLOWACCOUNT()
                Me.TEXTTotalTipsN.Text = CurrencyJO(Me.TEXTTotalTips.Text, "jO")
                Me.TEXTTotalClearanceN.Text = CurrencyJO(Me.TEXTTotalClearance.Text, "jO")
                'EDITBUTTON_Click(sender, e)
            Else
                MessageBox.Show(" ·«ÌÊÃœ ”Ã· Õ«·Ï ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› ”Ã·", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
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
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BUTTONDELRECORD.Enabled = False
            Me.ButtonInsertData.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.DataGridView1.Enabled = False
            Me.DataGridView2.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.CertificateNumbe.Enabled = False
            Me.CreditTransferNumber.Enabled = False
            Me.ComboITEMNAME.Enabled = False
            Me.TextWarehouseName.Enabled = False
            Me.TextQuantity.Enabled = False
            Me.ComboType.Enabled = False
            Me.TEXTPolicyNumber.Enabled = False
            Me.TEXTSupplier.Enabled = False
            Me.DateArrival.Enabled = False
            Me.DateExchange.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTPaymentMonth.Enabled = False
            Me.TEXTInvoiceValue.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.Panel2.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BUTTONDELRECORD.Enabled = False
            Me.ButtonInsertData.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonPostToCustomerTraffic.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

            Me.DataGridView1.Enabled = True
            Me.DataGridView2.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.CertificateNumbe.Enabled = True
            Me.CreditTransferNumber.Enabled = True
            Me.ComboITEMNAME.Enabled = True
            Me.TextWarehouseName.Enabled = True
            Me.TextQuantity.Enabled = True
            Me.ComboType.Enabled = True
            Me.TEXTPolicyNumber.Enabled = True
            Me.TEXTSupplier.Enabled = True
            Me.DateArrival.Enabled = True
            Me.DateExchange.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTPaymentMonth.Enabled = True
            Me.TEXTInvoiceValue.Enabled = True
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.BUTTONDELRECORD.Enabled = False
            Me.ButtonInsertData.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

            Me.DataGridView1.Enabled = False
            Me.DataGridView2.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.CertificateNumbe.Enabled = False
            Me.CreditTransferNumber.Enabled = False
            Me.ComboITEMNAME.Enabled = False
            Me.TextWarehouseName.Enabled = False
            Me.TextQuantity.Enabled = False
            Me.ComboType.Enabled = False
            Me.TEXTPolicyNumber.Enabled = False
            Me.TEXTSupplier.Enabled = False
            Me.DateArrival.Enabled = False
            Me.DateExchange.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTPaymentMonth.Enabled = False
            Me.TEXTInvoiceValue.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.Panel2.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.DataGridView1.Enabled = True
            Me.DataGridView2.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.CertificateNumbe.Enabled = True
            Me.CreditTransferNumber.Enabled = True
            Me.ComboITEMNAME.Enabled = True
            Me.TextWarehouseName.Enabled = True
            Me.TextQuantity.Enabled = True
            Me.ComboType.Enabled = True
            Me.TEXTPolicyNumber.Enabled = True
            Me.TEXTSupplier.Enabled = True
            Me.DateArrival.Enabled = True
            Me.DateExchange.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.TEXTPaymentMonth.Enabled = True
            Me.TEXTInvoiceValue.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.Panel2.Enabled = True
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
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
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("⁄›Ê« .. ·«Ì„ﬂ‰ „—«Ã⁄… «·”Ã·«  ﬁ»· «· —ÕÌ· «·Ï «·Õ”«»« ", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATECABLESCOEMPLOYEES()
        Me.Load_Click(sender, e)
        Me.UPDATECABLESCOEMPLOYEES()
        Me.BS.Position = P
        Insert_Actions(Me.TEXTID.Text.Trim, "„—«Ã⁄…", Me.Text)
        Me.RecordCount()
        MsgBox(" „  ⁄„·Ì… «·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        Me.UPDATECABLESCOEMPLOYEES()
        Me.Load_Click(sender, e)
        Me.UPDATECABLESCOEMPLOYEES()
        Insert_Actions(Me.TEXTID.Text.Trim, "≈·€«¡ «·„—«Ã⁄", Me.Text)
        Me.BS.Position = P
        MsgBox(" „  ⁄„·Ì… ≈·€«¡ «·„—«Ã⁄… »‰Ã«Õ", 64 + 524288, "‰Ã«Õ «·Õ›Ÿ Ê«· €ÌÌ—«  Ê«· ÕœÌÀ")
    End Sub



    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs)
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.TextCreditAccount.Text & " '", Consum)
        Consum = New SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")

        If ds2.Tables(0).Rows.Count > 0 Then
            Me.account_noF = ds2.Tables(0).Rows(0).Item(0)
            Me.account_nameF = ds2.Tables(0).Rows(0).Item(2)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.account_nameF = ""
            Me.account_nameF = ""
            Me.ACCF = ""
        End If

    End Sub





    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.ComboDebitAccount.Text & "_" & Me.TEXTID.Text & " " & "» «—ÌŒ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "··⁄„Ì·" & " " & ":" & " " & Me.ComboCustomerName.Text & " " & "„À» … »ÊÀÌﬁ… —ﬁ„" & " " & ":" & " " & Me.TEXTCertificateNumber.EditValue & vbNewLine
        Me.LabelStatement.Text = ExResult
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
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

    Private Sub DELETEDATBANK()
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlConnection(constring)
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
            Dim Consum As New SqlConnection(constring)
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
            Dim Consum As New SqlConnection(constring)
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
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
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
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPostToCustomerTraffic.Click
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
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Static P As Integer
            Me.Button3_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        Insert_Actions(Me.TEXTID.Text.Trim, " —ÕÌ· «·Ï «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.DateArrival.Text = "" Then
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
                        Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                        Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.DateArrival.Text = "" Then
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
                        Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                        Insert_Actions(Me.TEXTID.Text.Trim, " —ÕÌ· «·Ï Õ—ﬂ…«·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.DateArrival.Text = "" Then
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
                        Insert_Actions(Me.TEXTID.Text.Trim, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            Insert_Actions(Me.TEXTID.Text.Trim, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If
            Me.BS.Position = P
            Me.SumAmounCABLESCOt()
            Me.SumAmounCABLESEMPLOYEES()
            Me.SumAmounCABLESCOtFOLLOWACCOUNT()
            Me.UPDATECABLESCOEMPLOYEES()
            Me.UPDATECABLESCO()
            Me.UPDATECABLESEMPLOYEES()
            Me.SaveCABLESEMPLOYEES()
            Me.SaveCABLESCO()
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
    Private Sub PictureBox5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions.Click
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
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
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
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber.Click
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
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber.Text.Trim)
            f.TB1 = Me.TextCustomerTrafficNumber.Text.Trim
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
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber1.Click
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
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber1.Text.Trim)
            f.TB1 = Me.TextCustomerTrafficNumber1.Text.Trim
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
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicAccountLevel.Click
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List1.MouseDoubleClick
        Me.TextCreditAccount.Text = Me.List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
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

    Private Sub BackWorker2_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker2.DoWork

    End Sub

    Private Sub BackWorker3_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackWorker3.DoWork

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



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.SEARCHAccount_no(Me.TextCreditAccount.Text)
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

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTID.Text)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH

        SEARCHDATA.SEARCHCABLES(Me.TEXTCertificateNumber.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber.Text = SEARCHDATA.IDCAB
        SEARCHDATA.SEARCHCABLES1(Me.TEXTCertificateNumber.EditValue, Me.TextMovementSymbol.EditValue)
        Me.TextCustomerTrafficNumber1.Text = SEARCHDATA.IDCAB1
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
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
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
            ModuleGeneral.BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            ModuleGeneral.BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub


End Class