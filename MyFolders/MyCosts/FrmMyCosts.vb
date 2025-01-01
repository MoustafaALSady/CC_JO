Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmMyCosts
    Inherits Form

    ReadOnly BAD As Boolean = False
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
    Dim ds1 As New DataSet
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Public WithEvents BS As New BindingSource

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0

    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String

    Dim _Type1 As String
    Dim TypeCustomer As String
    Public TB1 As Integer
    Public TB2 As String
    Public TB3 As String
    Dim IDCAB1 As Int64
    Dim IDCAB2 As Int64
    Private Sub FrmMyCosts_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmMyCosts_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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
                        TRANSFERBUTTON_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonXP2_Click(sender, e)
                    Case Keys.F12
                        Me.ButtonDELRECORD_Click(sender, e)
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
    Private Sub FrmMyCosts_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage4.Show()
        Me.TabPage1.Show()
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Dim str1 As String = "SELECT CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, Auditor, cuser, couser, da, ne, da1, ne1 FROM MYCOSTS WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CST1 ='" & Trim(Me.TB1) & "'or CST8 ='" & Strings.Trim(Me.TB2) & "'or CST9 ='" & Strings.Trim(Me.TB3) & "'"
        Dim str2 As String = "SELECT CSDT, CST1, CSDT1, CSDT2, CSDT3 FROM MYCOSTDETAILS  "
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1, Consum)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2, Consum)
        Me.ds1.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds1, "MYCOSTS")
        Me.SqlDataAdapter2.Fill(Me.ds1, "MYCOSTDETAILS")
        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("MYCOSTS").Columns("CST1"), Me.ds1.Tables("MYCOSTDETAILS").Columns("CST1"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "MYCOSTS"
        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()

        Call MangUsers()
        Me.SHOWBUTTON()
        Me.RecordCount()
        '==============================
        Auditor("MYCOSTS", "USERNAME", "CST1", Me.TEXTInvoiceNumber.EditValue, "")
        Logentry = Uses
        Me.FundBalance()
        Me.SumAmountMycost()
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.load1.Enabled = False

        FILLCOMBOBOX1("MYCOSTS", "CST4", "CUser", CUser, Me.TEXTDetails)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        'FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", 3, Me.TEXTBOX2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Me.ds1.EnforceConstraints = False
        Dim str1 As New SqlCommand("", Consum) With {
            .CommandText = "SELECT CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, Auditor, cuser, couser, da, ne, da1, ne1 FROM MYCOSTS   WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CST1 ='" & Trim(Me.TB1) & "'" & "or CST9 ='" & Trim(Me.TB3) & "'" & "or CST8 ='" & Trim(Me.TB2) & "'"
        }

        Dim str2 As New SqlCommand("SELECT CSDT, CST1, CSDT1, CSDT2, CSDT3 FROM MYCOSTDETAILS", Consum)
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
        Me.ds1.Clear()
        Me.ds1 = New DataSet
        Me.SqlDataAdapter1.Fill(Me.ds1, "MYCOSTS")
        Me.SqlDataAdapter2.Fill(Me.ds1, "MYCOSTDETAILS")
        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("MYCOSTS").Columns("CST1"), Me.ds1.Tables("MYCOSTDETAILS").Columns("CST1"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "MYCOSTS"
        Me.ds1.EnforceConstraints = True
        Me.DataGridView1.DataSource = Nothing
        Me.DataGridView1.DataMember = Nothing

        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.SumAmountMycost()
        Me.RecordCount()
        '==============================
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")


        FILLCOMBOBOX1("MYCOSTS", "CST4", "CUser", CUser, Me.TEXTDetails)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If

        Me.load1.Enabled = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
    Private Sub FrmMyCosts_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        'Me.BUTTONCANCEL_Click(sender, e)

        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
    End Sub
    Private Sub ComboBox10_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) 'Handles ComboBox10.KeyPress
        AutoComplete(ComboCustomerName, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboDebitAccount, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) 'Handles ComboBox6.KeyPress
        AutoComplete(ComboCheckDrawerName, e, )
    End Sub
    Private Sub TEXTBOX2_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTStatement.Enter
        Call FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.TextCreditAccount)
    End Sub
    Private Sub TEXTBOX2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) 'Handles TEXTBOX2.KeyPress
        AutoComplete(Me.TEXTStatement, e, )
    End Sub
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
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
    Private Sub SumAmountMycost()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim total As Double = "0.000"
        On Error Resume Next

        Dim strsql As New SqlCommand("SELECT Sum(CSDT2) AS SUMSUBTOTALS FROM MYCOSTDETAILS WHERE CST1 = '" & Me.TEXTInvoiceNumber.EditValue & "'" & " GROUP BY CST1", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            total = ds.Tables(0).Rows(0).Item(0)
        Else
            total = "0.000"
        End If
        Me.TEXTTotal.Text = total.ToString("0.000")
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
        If Me.BS.Position < Me.ds1.Tables("MYCOSTS").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.SumAmountMycost()
        Me.DISPLAYRECORD()
        Me.Count()
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam
        'Label21.Text = AccountNoAktevd

        Me. AccountsEnquiry()
        Me.FundBalance()
        Me.InternalAuditorType()
        Me.TrueFalse()
        Me.AddType1()


        Me.TEXTInvoiceNumber.Enabled = False
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        FILLCOMBOBOXDISTINCT("AllCustomers", "cust2", "IDcust", "CUser", CUser, Me.ComboCustomerName)
        With Me
            .TEXTInvoiceNumber.EditValue = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST1").ToString
            .TEXTStatement.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST2").ToString
            .TEXTMonths.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST3").ToString
            .TEXTDetails.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST4").ToString
            .CheckTransferToAccounts.Checked = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST5").ToString
            .CheckPostToCustomerTraffic.Checked = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST6").ToString
            .DateMovementHistory.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST7").ToString
            .TEXTCustomerName.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST8").ToString
            .TextCustomerNumber.EditValue = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST9").ToString
            .TextNotes.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST10").ToString
            .TEXTTotal.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST11").ToString
            .CheckSettlementDone.Checked = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST12").ToString
            .TextMovementSymbol.EditValue = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST13").ToString
            .TextFundValue.EditValue = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST14").ToString
            .TextValueOfCheck.EditValue = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST15").ToString
            .ComboPaymentMethod.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST16").ToString
            .ComboCheckDrawerName.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST17").ToString
            .TextCheckDrawerCode.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST18").ToString
            .CheckDate.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST19").ToString
            .TextCheckNumber.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST20").ToString
            .CheckLogReview.Checked = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CST21").ToString

            .ComboCB1.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("CB1").ToString
            .ComboBN2.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("BN2").ToString

            .TEXTUserName.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position).Item("Auditor").ToString
            .TextDefinitionDirectorate.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("COUser").ToString
            .TEXTAddDate.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("da").ToString
            .TextTimeAdd.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("ne").ToString
            .TEXTReviewDate.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("da1").ToString
            .TextreviewTime.Text = Me.ds1.Tables("MYCOSTS").Rows(Me.BS.Position)("ne1").ToString
        End With
        Auditor("MYCOSTS", "USERNAME", "CST1", Me.TEXTInvoiceNumber.EditValue, "")
        Logentry = Uses






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
                Me.DelRow = True
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
            Count()
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
            Me.PictureBox5.Visible = False
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonDELRECORD.Enabled = LockDelete
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonPostToCustomerTraffic.Enabled = TransferofAccounts
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonXP1.Enabled = LockUpdate
        Me.ButtonAttachDocument.Enabled = LockAddRow
    End Sub
    Private Sub SaveMYCOSTDETAILS()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO MYCOSTDETAILS (CSDT1, CSDT2, CSDT3, CST1) VALUES     (@CSDT1, @CSDT2, @CSDT3, @CST1)", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
            .Parameters.Add("@CST1", SqlDbType.BigInt, 8).Value = Me.TEXTInvoiceNumber.EditValue
            .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1")
            .Parameters.Add("@CSDT2", SqlDbType.Float, 8, "CSDT2")
            .Parameters.Add("@CSDT3", SqlDbType.NVarChar, 255, "CSDT3")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "MYCOSTDETAILS", New DataColumnMapping() {New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CST1", "CST1"), New DataColumnMapping("CSDT", "CSDT")})})
        SqlDataAdapter2.InsertCommand = CMD
        SqlDataAdapter2.Update(ds1, "MYCOSTDETAILS")
        Consum.Close()
    End Sub
    Private Sub UPDATEMYCOSTS()
        'On Error Resume Next
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update MYCOSTS SET  CST2 = @CST2, CST3 = @CST3, CST4 = @CST4, CST5 = @CST5, CST6 = @CST6, CST7 = @CST7, CST8 = @CST8, CST9 = @CST9, CST10 = @CST10, CST11 = @CST11, CST12 = @CST12, CST13 = @CST13, CST14 = @CST14, CST15 = @CST15, CST16 = @CST16, CST17 = @CST17, CST18 = @CST18, CST19 = @CST19, CST20 = @CST20, CST21 = @CST21, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, cuser = @cuser, couser = @couser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE  CST1 = @CST1", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CST1", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumber.EditValue
                .Parameters.Add("@CST2", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CST3", SqlDbType.NVarChar).Value = Me.TEXTMonths.Text
                .Parameters.Add("@CST4", SqlDbType.NVarChar).Value = Me.TEXTDetails.Text
                .Parameters.Add("@CST5", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferToAccounts.Checked)
                .Parameters.Add("@CST6", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckPostToCustomerTraffic.Checked)
                .Parameters.Add("@CST7", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CST8", SqlDbType.NVarChar).Value = Me.TEXTCustomerName.Text
                .Parameters.Add("@CST9", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@CST10", SqlDbType.NVarChar).Value = Me.TextNotes.Text
                .Parameters.Add("@CST11", SqlDbType.Float).Value = Me.TEXTTotal.Text
                .Parameters.Add("@CST12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettlementDone.Checked)
                .Parameters.Add("@CST13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CST14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CST15", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CST16", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CST17", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CST18", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@CST19", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CST20", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@CST21", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
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
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorUPDAT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATEMYCOSTDETAILS()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update MYCOSTDETAILS SET  CSDT1 = @CSDT1, CSDT2 = @CSDT2, CSDT3 = @CSDT3, CST1 = @CST1 WHERE  CSDT = @CSDT", Consum)
        Dim CMD As New SqlCommand With {
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
            .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1") '.Value = Me.TEXTBOX1.Text.Trim
            .Parameters.Add("@CSDT2", SqlDbType.Float, 8, "CSDT2")
            .Parameters.Add("@CSDT3", SqlDbType.NVarChar, 255, "CSDT3")
            .Parameters.Add("@CST1", SqlDbType.BigInt, 8, "CST1")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "MYCOSTDETAILS", New DataColumnMapping() {New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CST1", "CST1"), New DataColumnMapping("CSDT", "CSDT")})})
        SqlDataAdapter2.UpdateCommand = CMD
        SqlDataAdapter2.Update(ds1, "MYCOSTDETAILS")
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
            If Me.CheckPostToCustomerTraffic.Checked = True Then
                MsgBox("⁄›Ê« .. ÌÃ» ≈·€«¡ «· —ÕÌ· «·Ï Õ—ﬂ… «·⁄„·«¡ ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOPTIONS.ShowDialog()
                Exit Sub
            End If
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Button3_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

            If OBCHK6 = True Then
                If Me.CheckTransferToAccounts.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferToAccounts.Checked = True
                        TransforAccounts()
                        '======================================
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
                        '======================================
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œÊﬁ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            '======================================
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
                            '======================================
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
                            '======================================
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œÊﬁ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                '======================================
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
                            '======================================
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
                            '======================================
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·‘Ìﬂ«   ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                '======================================
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
                        resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œÊﬁ Ê «·‘Ìﬂ«  —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferToAccounts.Checked = True
                            TransforAccounts()
                            '======================================
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
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
                            '======================================
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·Ï «·ﬁÌÊœ «·ÌÊ„Ì… Ê «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·’‰œ“ﬁ Ê «·‘Ìﬂ«  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferToAccounts.Checked = False
                                '======================================
                                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·’‰œ“ﬁ Ê «·‘Ìﬂ«  —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            Static Dim P As Integer
            P = Me.BS.Position
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTDETAILS()
            Me.DanLOd()
            Me.BS.Position = P
            Me.SumAmountMycost()
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTDETAILS()
            Me.RecordCount()
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
    Private Sub ButtonDELRECORD_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDELRECORD.Click
        Try
            If LockDelete = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Static Dim S As Integer
            S = Me.BS.Position
            Dim resault As Integer
            Dim Consum As New SqlConnection(constring)
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    For Each row As DataGridViewRow In DataGridView1.SelectedRows
                        Dim n As Integer
                        n = Me.DataGridView1.Rows(row.Index).Cells("CSDT").Value
                        Dim CMD2 As New SqlCommand With {
                            .CommandType = CommandType.Text,
                            .Connection = Consum
                        }
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        Dim SQL2 As New SqlCommand("DELETE FROM MYCOSTDETAILS WHERE CSDT=" & n, Consum)
                        CMD2.CommandText = SQL2.CommandText
                        CMD2.ExecuteNonQuery()
                    Next
                    Consum.Close()
                    Me.BS.Position = S
                    DanLOd()
                    Me.SumAmountMycost()
                    Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
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
            If LockDelete = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… Õ–› «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Dim Consum As New SqlConnection(constring)
            Static Dim S As Integer
            S = Me.BS.Position
            Dim resault As Integer
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("”»‰„ Õ–› «·”Ã·«  «·„Õœœ…", "Õ–› «·”Ã·«  «·„Õœœ…", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    For Each row As DataGridViewRow In DataGridView1.SelectedRows
                        Dim n As Integer
                        n = Me.DataGridView1.Rows(row.Index).Cells("CSDT").Value
                        Dim CMD2 As New SqlCommand With {
                            .CommandType = CommandType.Text,
                            .Connection = Consum
                        }
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        Dim SQL2 As New SqlCommand("DELETE FROM MYCOSTDETAILS WHERE CSDT=" & n, Consum)
                        CMD2.CommandText = SQL2.CommandText
                        CMD2.ExecuteNonQuery()
                    Next
                    Consum.Close()
                    Me.BS.Position = S
                    DanLOd()
                    Me.SumAmountMycost()
                    Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
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
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        Dim total As Double = "0.000"
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("CSDT2").Value)
        Next
        Me.TEXTTotal.Text = total.ToString("0.000")
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If Me.DataGridView1.CurrentCell.ColumnIndex = 2 Then
            Me.DataGridView1.CurrentRow.Cells(2).Value = Calculator()
        End If
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            Me.DataGridView1.Item("CSDT1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error1011", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectionChanged
        On Error Resume Next
        Dim total As Double
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("CSDT2").Value)
        Next
        Me.TEXTTotal.Text = total.ToString("0.000")
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
    Private Sub DateTimePicker1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateMovementHistory.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTMonths.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTMonths.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTDetails.Focus()
        End Select
    End Sub
    Private Sub TEXTBOX4_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTDetails.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextNotes.Focus()
        End Select
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        Me.TEXTStatement.DataSource = GetData(3)
        Me.TEXTStatement.DisplayMember = "account_name"
        If TEXTStatement.Items.Count > 0 Then
            Me.TEXTStatement.SelectedIndex = 0
        End If
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockUpdate = False Then
                MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… «÷«›… Ê ⁄œÌ· «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            If Year(DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("⁄›Ê« .. «·”‰… «·„Õ«”»Ì… €Ì— ’ÕÌÕ… ›·« Ì„ﬂ‰ «·„ﬁ«—‰…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Val(Me.TEXTTotal.Text) <> (Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue)) Then
                MsgBox("⁄›Ê« .. ÌÃ» «‰ ÌﬂÊ‰ «Ã„«·Ì «·’‰œÊﬁ Ê«·‘Ìﬂ „”«ÊÌ «·Ï «Ã„«·Ì «·›« Ê—…", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.Button3_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            Dim ch As Double
            Dim ch1 As Double
            ch = Me.TextDefinitionDirectorate.Text
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
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = True
            Me.ButtonDELRECORD.Enabled = True
            Static Dim P As Integer
            P = Me.BS.Position
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh: mm:ss tt")
            Me.SumAmountMycost()
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTDETAILS()
            Me.DanLOd()
            Me.BS.Position = P
            Me.SumAmountMycost()
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTDETAILS()
            Me.RecordCount()
            'Me.Cursor = Cursors.WaitCursor
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
        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·", Me.Text)
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
        If Me.CheckPostToCustomerTraffic.Checked = True Then
            Dim resault As Integer
            resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ Õ—ﬂ… «·⁄„·«¡", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                MYDELETERECORD("MYCOSTDETAILS", "CST1", Me.TEXTInvoiceNumber, Me.BS, True)
                MYDELETERECORD("MYCOSTS", "CST1", Me.TEXTInvoiceNumber, Me.BS, True)
                If Me.TextMovementRestrictions.Text = "" Then
                    MsgBox("·«ÌÊÃœ ”Ã·«  ›Ì «·ﬁÌÊœ", 16, " ‰»Ì…") '1
                Else
                    DELETEDATMOVESDATA()
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
                    DELETEDATBANK()
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
                Me.Load_Click(sender, e)
                Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›", Me.Text) '6
            Else
                Exit Sub
            End If
        Else
            MYDELETERECORD("MYCOSTDETAILS", "CST1", Me.TEXTInvoiceNumber, Me.BS, True)
            MYDELETERECORD("MYCOSTS", "CST1", Me.TEXTInvoiceNumber, Me.BS, True)
            Me.DanLOd()
            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›", Me.Text)
        End If
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
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

            If Me.RadioButton2.Checked Then
                Dim Consum As New SqlConnection(constring)
                Dim SqlDataAdapter1 As New SqlDataAdapter
                Dim F As New FrmPRINT
                Dim rpt5 As New rptMyCosts
                GETSERVERNAMEANDDATABASENAME(rpt5, DBServer, "", "")
                txt = rpt5.Section4.ReportObjects("Text5")
                Dim ds As New DataSet
                Dim str As String = "SELECT * FROM MYCOSTS  WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CST1 ='" & Strings.Trim(Me.TEXTInvoiceNumber.EditValue) & "'"
                SqlDataAdapter1 = New SqlDataAdapter(str, Consum)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "MYCOSTS")
                rpt5.SetDataSource(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim txt2 As TextObject
                    txt2 = rpt5.Section4.ReportObjects("Text5")
                    txt2.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("CST11"), "jO")
                    txt1 = rpt5.Section1.ReportObjects("Text22")
                    txt1.Text = AssociationName
                    txt1 = rpt5.Section1.ReportObjects("Text21")
                    txt1.Text = Directorate
                    txt1 = rpt5.Section1.ReportObjects("Text23")
                    txt1.Text = Character
                    txt1 = rpt5.Section1.ReportObjects("TEXT40")
                    txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt1 = rpt5.Section1.ReportObjects("Text44")
                    txt1.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt5
                    F.CrystalReportViewer1.Zoom(94%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Consum.Close()
            ElseIf Me.RadioButton3.Checked Then
                Dim Consum As New SqlConnection(constring)
                Dim F As New FrmPRINT
                Dim rpt6 As New rptMyCosts61
                GETSERVERNAMEANDDATABASENAME(rpt6, DBServer, "", "")
                'txt = rpt6.Section4.ReportObjects("Text5")
                Dim ds1 As New DataSet
                Dim str1 As String = "SELECT * FROM MYCOSTS  WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CST21 ='" & False & "'"
                SqlDataAdapter1 = New SqlDataAdapter(str1, Consum)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "MYCOSTS")
                If ds1.Tables(0).Rows.Count > 0 Then
                    rpt6.SetDataSource(ds1)
                    txt1 = rpt6.Section1.ReportObjects("Text22")
                    txt1.Text = AssociationName
                    txt1 = rpt6.Section1.ReportObjects("Text21")
                    txt1.Text = Directorate
                    txt1 = rpt6.Section1.ReportObjects("Text23")
                    txt1.Text = Character
                    txt1 = rpt6.Section1.ReportObjects("TEXT40")
                    txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt1 = rpt6.Section1.ReportObjects("Text44")
                    txt1.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt6
                    F.CrystalReportViewer1.Zoom(94%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Consum.Close()
            ElseIf Me.RadioButton1.Checked Then
                Dim Consum As New SqlConnection(constring)
                Dim SqlDataAdapter1 As New SqlDataAdapter
                Dim SqlDataAdapter2 As New SqlDataAdapter
                Dim F As New FrmPRINT
                Dim rpt6 As New rptMyCosts7
                GETSERVERNAMEANDDATABASENAME(rpt6, DBServer, "", "")
                Dim dsr1 As New DataSet

                Consum.Open()
                Dim str1 As New SqlCommand("", Consum)
                Dim str2 As New SqlCommand("", Consum)
                With str1
                    .CommandText = "SELECT CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, USERNAME, Auditor, cuser, couser, da, ne, da1, ne1 FROM MYCOSTS WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                End With
                With str2
                    .CommandText = "SELECT CSDT, CST1, CSDT1, CSDT2, CSDT3 FROM MYCOSTDETAILS ORDER BY CSDT1 "
                End With
                dsr1.EnforceConstraints = False
                SqlDataAdapter1 = New SqlDataAdapter(str1)
                SqlDataAdapter2 = New SqlDataAdapter(str2)
                dsr1.Clear()
                SqlDataAdapter1.Fill(dsr1, "MYCOSTS")
                SqlDataAdapter2.Fill(dsr1, "MYCOSTDETAILS")
                dsr1.Relations.Add("REL1", dsr1.Tables("MYCOSTS").Columns("CST1"), dsr1.Tables("MYCOSTDETAILS").Columns("CST1"), True)
                If ds1.Tables(0).Rows.Count > 0 Then
                    rpt6.SetDataSource(dsr1)
                    txt1 = rpt6.Section1.ReportObjects("Text22")
                    txt1.Text = AssociationName
                    txt1 = rpt6.Section1.ReportObjects("Text21")
                    txt1.Text = Directorate
                    txt1 = rpt6.Section1.ReportObjects("Text23")
                    txt1.Text = Character
                    txt1 = rpt6.Section1.ReportObjects("TEXT40")
                    txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                    txt1 = rpt6.Section1.ReportObjects("Text44")
                    txt1.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt6
                    F.CrystalReportViewer1.Zoom(94%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                Else
                    MessageBox.Show("·« ÊÃœ »Ì«‰«  Õ«·Ì… ··ÿ»«⁄…", "ÿ»«⁄…", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Consum.Close()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub TEXTInvoiceNumber_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTInvoiceNumber.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TEXTInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTInvoiceNumber.LostFocus
        On Error Resume Next
        Static P As Integer
        P = Me.BS.Position
        Me.SumAmountMycost()
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
        Me.BS.Position = P
        If Me.BAD = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.PRINTBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
        Else
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = True
            Me.ButtonDELRECORD.Enabled = True
        End If
    End Sub

    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged

        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT cust22  FROM AllCustomers WHERE IDcust ='" & Me.TextCustomerNumber.EditValue & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            TypeCustomer = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TypeCustomer = ""
        End If
        Adp.Dispose()
        Consum.Close()
        Dim Str1 As String = Me.ComboCustomerName.Text
        Dim strArr() As String
        Dim a As String
        strArr = Str1.Split("-")
        a = strArr(0)
        If Me.ComboCustomerName.Text.Length > 0 Then
            Me.TEXTCustomerName.Text = strArr(1)
            Me.TextCustomerNumber.EditValue = strArr(0)
        Else
            Me.TEXTCustomerName.Text = ""
            Me.TextCustomerNumber.EditValue = ""
        End If
        Me.ComboCustomerName.Enabled = False
    End Sub
    Private Sub MAXIDCAB1()
        On Error Resume Next
        Dim N As Int64
        Dim Consum As New SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlCommand("SELECT MAX(IDCAB) FROM CABLES  WHERE CUser='" & CUser & "'and   Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
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
        Dim cmd1 As New SqlCommand("SELECT MAX(IDCAB) FROM CABLES  WHERE CUser='" & CUser & "'and   Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
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


    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
        Try
            Me.ComboCustomerName.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub TrueFalse()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonXP1.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonAttachDocument.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.DataGridView1.Enabled = False
        Else
            If Me.CheckPostToCustomerTraffic.Checked = True Then
                Me.EDITBUTTON.Enabled = False
                Me.BUTTONCANCEL.Enabled = True
                Me.DELETEBUTTON.Enabled = False
                Me.PRINTBUTTON.Enabled = True
                Me.ButtonXP1.Enabled = True
                Me.InternalAuditorERBUTTON.Enabled = True
            Else
                Me.SHOWBUTTON()
            End If
        End If


    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckTransferToAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            Me.TEXTInvoiceNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTMonths.Enabled = False
            Me.TEXTDetails.Enabled = False
            Me.TextNotes.Enabled = False
        ElseIf Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False
            Me.DataGridView1.Enabled = False

            Me.TEXTInvoiceNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTMonths.Enabled = False
            Me.TEXTDetails.Enabled = False
            Me.TextNotes.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicAccountLevel.Enabled = False
        ElseIf Me.CheckTransferToAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.DELETEBUTTON.Enabled = False
            Me.PRINTBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonPostToCustomerTraffic.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonAttachDocument.Enabled = False
            Me.DataGridView1.Enabled = False

            Me.TEXTInvoiceNumber.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.TEXTMonths.Enabled = False
            Me.TEXTDetails.Enabled = False
            Me.TextNotes.Enabled = False
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
            Me.TEXTMonths.Enabled = True
            Me.TEXTDetails.Enabled = True
            Me.TextNotes.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.ComboDebitAccount.Enabled = True
            Me.PicAccountLevel.Enabled = True
        End If





    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
        'On Error Resume Next
        Try
            If TestNet = False Then
                MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
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
            Me.TextDefinitionDirectorate.Text = USERNAME
            Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.UPDATEMYCOSTS()
            Me.Load_Click(sender, e)
            Me.CheckLogReview.Checked = True
            Me.UPDATEMYCOSTS()
            Me.BS.Position = P
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
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorInternalAuditorER", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "„—«Ã⁄…", Me.Text)
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATEMYCOSTS()
        Me.Load_Click(sender, e)
        Me.CheckLogReview.Checked = False
        Me.UPDATEMYCOSTS()
        Me.BS.Position = P
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
        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "≈·€«¡ «·„—«Ã⁄", Me.Text)
    End Sub



    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
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
            Me.account_noF = ""
            Me.account_nameF = ""
            Me.ACCF = ""
        End If

        AutoEx()
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
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.TEXTStatement.Text & " " & ":" & " " & "» «—ÌŒ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "··⁄„Ì·" & " " & ":" & " " & Me.TEXTCustomerName.Text & " " & "„À» … »”‰œ —ﬁ„" & " " & ":" & " " & Me.TextMovementSymbol.EditValue & vbNewLine
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
    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
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

            nem = " Õ„Ì· " & " " & TEXTStatement.Text & " " & "⁄·Ï «·⁄„Ì·" & " " & TEXTCustomerName.Text
            PMO2 = 1


            DebitAccount_No = keyAccounts.GetValue("CustomerAccount_No", CustomerAccount_No)

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
            CredAccount_NO = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam
            SEARCHDATA.MaxIDMoves()

            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, True, TEXTTotal.Text, TEXTTotal.Text, T3, "ﬁÌœ", "GEA", TextMovementSymbol.EditValue, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, True, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TEXTTotal.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, True, T2)

            Select Case Me.ComboPaymentMethod.Text
                Case "‰ﬁœ«"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTInvoiceNumber.EditValue,
                      TEXTStatement.Text, TEXTCustomerName.Text, TextCustomerNumber.EditValue, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‘Ìﬂ"
                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTInvoiceNumber.EditValue,
                     TEXTStatement.Text, TEXTCustomerName.Text, TextCustomerNumber.EditValue, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, TextCheckNumber.Text, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)
                Case "‰ﬁœ«_‘Ìﬂ"
                    MAXIDCAB1()
                    Insert_CABLES(IDCAB1, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextFundValue.EditValue, 0, "‰ﬁœ«", TEXTInvoiceNumber.EditValue,
                      TEXTStatement.Text, TEXTCustomerName.Text, TextCustomerNumber.EditValue, "‰ﬁœ«", TextMovementSymbol.EditValue, TextFundValue.EditValue,
                      ComboPaymentMethod.Text, 0, Me.Text, CheckDate.Value.ToString("yyyy-MM-dd"), CurrencyJO(Me.TextFundValue.EditValue, "jO"),
                      TypeCustomer, TextBN3.Text, BN4, True, False, TextValueOfCheck.EditValue, ComboCheckDrawerName.Text,
                      TextCheckDrawerCode.Text, ComboCB1.Text, ComboBN2.Text)

                    MAXIDCAB2()
                    Insert_CABLES(IDCAB2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), TextValueOfCheck.EditValue, 0, "‘Ìﬂ", TEXTInvoiceNumber.EditValue,
                     TEXTStatement.Text, TEXTCustomerName.Text, TextCustomerNumber.EditValue, "√Ã‹‹‹‹‹‹‹·", TextMovementSymbol.EditValue, TextFundValue.EditValue,
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

        nem = "’—› „’«—Ì› ‰ﬁœÌ… "
        nem1 = "’—› „’«—Ì› ‰ﬁœÌ… " & " " & Me.TEXTStatement.Text.Trim
        nem2 = "’—› „’«—Ì› »Ì„ÊÃ» „” ‰œ —ﬁ„ " & " " & TextCheckNumber.Text.Trim
        PMO2 = 1

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam


        SEARCHDATA.MaxIDMoves()
        TransferToAccounts_Check = True

        If Check_OptionsTransforAccounts.Checked = True Then
            OptionsTransforAccountsTo(ComboPaymentMethod.Text, ComboDebitAccount.Text, TextCreditAccount.Text)
        End If
        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "ﬁÌœ", "GE", TextMovementSymbol.EditValue, False)

        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TEXTTotal.Text, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

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
        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam


        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", AccountNoAktevd, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", AccountNoAktevd, 1)
        DebitAccount_Cod = ID_Nam

        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        Select Case Me.ComboPaymentMethod.Text
            Case "‰ﬁœ«"
                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
                LabelFundBalance.Text = "—’Ìœ" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = ModuleGeneral.CB2.ToString

            Case "‘Ìﬂ"
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
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                    Me.TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                    Me._Type1 = ds.Tables(0).Rows(0).Item(2)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    Me.TypeCustomer = ""
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
            If Me.CheckTransferToAccounts.Checked = False Then
                MsgBox("⁄›Ê« .. ÌÃ»  —ÕÌ· «Ê·« «·Ï «·Õ”‹‹‹‹‹‹‹«»«  «Ê·« ", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·„œÌ‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            If Me.TextCreditAccount.Text = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ﬂ Õﬁ· Õ”«» «·œ«∆‰ ›«—€", 16, " ‰»ÌÂ")
                Exit Sub
            End If

            If Me.TextCustomerNumber.EditValue = "" Then
                MsgBox("⁄›Ê« .. ·« Ì„ﬂ‰  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ ÌÃ» «Œ Ì«— ⁄„Ì·", 16, " ‰»ÌÂ")
                Exit Sub
            End If
            Me.ComboBox1_SelectedIndexChanged(sender, e)
            Me.Button3_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Static Dim P As Integer
            P = Me.BS.Position
            If Me.ComboPaymentMethod.Text = "‰ﬁœ«" Then
                If Me.CheckPostToCustomerTraffic.Checked = False Then
                    resault = MessageBox.Show("”»‰„  —ÕÌ· «·”Ã· «·Õ«·Ï «·Ï «·⁄„·«¡ —›„ " & Me.TextMovementSymbol.EditValue, " —ÕÌ· ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckPostToCustomerTraffic.Checked = True
                        TransforCustomerTraffic()
                        '======================================
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
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
                        '======================================
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡ ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            '======================================
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
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
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
                        '======================================
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " ⁄œÌ·  —ÕÌ·  Õ—ﬂ… «·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        resault = MessageBox.Show("Â·  —Ìœ Õ–› «·”Ã· «·Õ«·Ï „‰ ÃœÊ· «·⁄„·«¡  ", "Õ–› ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATA1()
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckPostToCustomerTraffic.Checked = False
                            '======================================
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
                        '======================================
                        Insert_Actions(Me.TEXTInvoiceNumber.EditValue, " —ÕÌ· «·Ï Õ—ﬂ…«·⁄„·«¡ —›„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show("  „  —ÕÌ· «·”Ã· «·Õ«·Ï  ”«»ﬁ«" & " " & "Â·  —Ìœ  Õœ»ÀÂ «„ ·« ", " ÕœÌÀ ”Ã·", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
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
                        '======================================
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
                            '======================================
                            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "Õ–›  —ÕÌ· Õ—ﬂ… «·⁄„·«¡ —ﬁ„" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTDETAILS()
            Me.DanLOd()
            Me.BS.Position = P
            Me.SumAmountMycost()
            Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTDETAILS()
            Me.RecordCount()
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
    Private Sub TEXTStatement_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TEXTStatement.SelectedIndexChanged
        On Error Resume Next
        Dim Str1 As String = Me.TEXTStatement.Text
        Dim strArr() As String
        Dim a As String
        strArr = Str1.Split("-")
        a = strArr(0)
        Me.TEXTStatement.Items.Clear()
         AccountsEnquiry()
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
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE  CUser='" & CUser & "' and CH17 ='" & False & "'", Consum)
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
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
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
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber.Click
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
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
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
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpCreditAccount.Value)
            Me.List1.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
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

    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJPG
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO   FROM MYDOCUMENTSHOME  WHERE  CUser='" & CUser & "'and  LO ='" & Trim(Me.TextMovementSymbol.EditValue) & "'ORDER BY DOC1", Consum)
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
                MsgBox("·« ÌÊÃœ «Ì „” ‰œ« ", 64 + 524288, " ‰»ÌÂ")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("⁄⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… ≈—›«ﬁ «·„” ‰œ« ", 16, " ‰»ÌÂ")
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
            f.TEXTFileSubject.Text = "„” ‰œ«  «·„’—Ê›« "
            f.TextFileDescription.Text = "«—›«ﬁ „” ‰œ«  «·„’—Ê›« "
            f.PictureBox1.Image = Nothing
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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
        GetFundAccount_No(ModuleGeneral.CB2)
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