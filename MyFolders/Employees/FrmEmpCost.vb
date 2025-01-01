Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Diagnostics

Public Class FrmEmpCost
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    Dim ds1 As New DataSet
    Dim BAD As Boolean = False
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Public TB1 As String

    Private Sub FrmEMPCOST_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            If CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F1
                        ADDBUTTON_Click(sender, e)
                    Case Keys.F2
                        SAVEBUTTON_Click(sender, e)
                    Case Keys.F3
                        EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        BUTTONCANCEL_Click(sender, e)
                    Case Keys.F6
                        DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        ButtonXP3_Click(sender, e)
                    Case Keys.F10
                        ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.F12
                        ButtonDELRECORD_Click(sender, e)
                    Case Keys.PageDown
                        PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmMYCOST_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage4.Show()
    End Sub
    Private Sub FrmMYCOST_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = False
        'Me.BUTTONCANCEL.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.ButtonDELRECORD.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        'Me.PREVIOUSBUTTON.Enabled = False
        'Me.FIRSTBUTTON.Enabled = False
        'Me.NEXTBUTTON.Enabled = False
        'Me.LASTBUTTON.Enabled = False

        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

        TestkeyAccounts(keyAccounts.GetValue("EmployeeAdvanceAccount_No", EmployeeAdvanceAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("EmployeeAdvanceAccount_No", EmployeeAdvanceAccount_No)
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
        Me.ds1.EnforceConstraints = False
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        Dim str2 As New SqlClient.SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT  CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM EMPCOST  WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'And CST1 ='" & Strings.Trim(Me.TB1) & "'"
        End With
        With str2
            .CommandText = "SELECT  CSDT,  CSDT1,  CSDT2,  CSDT3, CSDT4, CSDT5, CSDT6, CST1 FROM EMPCOSTDETALLS "
        End With

        Consum.Open()
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.ds1.Clear()
        ds1 = New DataSet
        Me.SqlDataAdapter1.Fill(ds1, "EMPCOST")
        Me.SqlDataAdapter2.Fill(ds1, "EMPCOSTDETALLS")
        Me.ds1.Relations.Add("REL1", ds1.Tables("EMPCOST").Columns("CST1"), ds1.Tables("EMPCOSTDETALLS").Columns("CST1"), True)
        Me.BS.DataSource = ds1
        Me.BS.DataMember = "EMPCOST"
        Me.DataGridView1.DataSource = BS
        Me.DataGridView1.DataMember = "REL1"
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Me.RecordCount()

        Auditor("EMPCOST", "USERNAME", "CST1", Me.TEXTID.Text, "")
        Logentry = Uses

        Me.TEXTTotal.Text = CurrencyJO(TextTotalBalance.Text, "jO")
        FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.TEXTEmployeeName)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
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
        Call MangUsers()
        Me.load1.Enabled = False
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Dim str1 As New SqlClient.SqlCommand("SELECT  CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM EMPCOST WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CST1", Consum)
        Dim str2 As New SqlClient.SqlCommand("SELECT  CSDT,  CSDT1,  CSDT2,  CSDT3, CSDT4, CSDT5, CSDT6, CST1 FROM EMPCOSTDETALLS ", Consum)
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.ds1.Clear()
        ds1 = New DataSet
        Me.SqlDataAdapter1.Fill(ds1, "EMPCOST")
        Me.SqlDataAdapter2.Fill(ds1, "EMPCOSTDETALLS")
        Me.ds1.Relations.Add("REL1", ds1.Tables("EMPCOST").Columns("CST1"), ds1.Tables("EMPCOSTDETALLS").Columns("CST1"), True)
        Me.BS.DataSource = ds1
        Me.BS.DataMember = "EMPCOST"
        Me.DataGridView1.DataSource = BS
        Me.DataGridView1.DataMember = "REL1"
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Consum.Close()
        Me.RecordCount()


        Me.TEXTTotal.Text = CurrencyJO(TextTotalBalance.Text, "jO")
        FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.TEXTEmployeeName)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If


        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.RecordCount()
        Call MangUsers()
        Me.load1.Enabled = False
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        RecordCount()
    End Sub
    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = BS.Count
        CurrenRecordst = BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If BS.Position > 0 Then
            Back = True
        End If
        If BS.Position < ds1.Tables("EMPCOST").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        On Error Resume Next
        Me.TEXTTotalDebit.Text = 0.000
        Me.TextTotalCred.Text = 0.000
        Me.TextTotalBalance.Text = 0.000
        For Each r As DataGridViewRow In DataGridView1.Rows
            Me.TEXTTotalDebit.Text += Val(r.Cells("CSDT2").Value)
            Me.TextTotalCred.Text += Val(r.Cells("CSDT3").Value)
        Next
        Me.TEXTTotalDebit.Text = Format(TEXTTotalDebit.Text, "0.000")
        Me.TextTotalCred.Text = Format(TextTotalCred.Text, "0.000")
        Me.TextTotalBalance.Text = Format(TEXTTotalDebit.Text - TextTotalCred.Text, "0.000")
        Me.TEXTTotal.Text = CurrencyJO(TextTotalBalance.Text, "jO")
        If Val(Me.TEXTTotalDebit.Text) = Val(Me.TextTotalCred.Text) Then
            Me.CheckSettled.Checked = True
        Else
            Me.CheckSettled.Checked = False
        End If
        Me.DISPLAYRECORD()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.SAVEBUTTON.Enabled = False
        Me.AutoEx()
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
                PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                DelRow = True
                PictureBox2False()
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
            PictureBox2.Visible = False
            Count()
            'Label20.Text = Now
            If BS.Count < RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
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
            PictureBox2.Visible = False
        End If
    End Sub
    Public Sub Count()
        On Error Resume Next
        RECORDSLABEL.Text = BS.Position + 1 & " من " & BS.Count
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.ButtonDELRECORD.Enabled = LockDelete
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor

    End Sub

    Private Sub TestContrs()
        If TEXTEmployeeName.Text = Nothing Then MessageBox.Show("اسم الموظف - كوده فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If ComboPaymentMethod.Text = Nothing Then MessageBox.Show("طريقة الدفع فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If ComboCB1.Text = Nothing Then MessageBox.Show("رقم الصندوق فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If ComboBN2.Text = Nothing Then MessageBox.Show("رقم الحساب فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If TextCheckNumber.Text = Nothing Then MessageBox.Show("رقم الشيك فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If CheckDate.Value = Nothing Then MessageBox.Show("تاريخ الشيك فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
        If ComboCheckDrawerName.Text = Nothing Then MessageBox.Show("اسم  ساحب الشيك فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Return
    End Sub

    Private Sub SaveEMPCOST()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO EMPCOST (  CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@CST1, @CST2, @CST3, @CST4, @CST5, @CST6, @CST7, @CST8, @CST9, @CST10, @CST11, @CST12, @CST13, @CST14, @CST15, @CST16, @CST17, @CST18, @CST19, @CST20, @CST21, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CST1", SqlDbType.BigInt).Value = Me.TEXTID.EditValue
                .Parameters.Add("@CST2", SqlDbType.NVarChar).Value = Me.TEXTEmployeeName.Text.Trim
                .Parameters.Add("@CST3", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.Text.Trim
                .Parameters.Add("@CST4", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text.Trim
                .Parameters.Add("@CST5", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettled.Checked)
                .Parameters.Add("@CST6", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@CST7", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CST8", SqlDbType.NVarChar).Value = Me.ComboNumberOfYears.Text.Trim
                .Parameters.Add("@CST9", SqlDbType.NVarChar).Value = Me.TEXTMonths.Text.Trim
                .Parameters.Add("@CST10", SqlDbType.NVarChar).Value = Me.TEXTComments.Text.Trim
                .Parameters.Add("@CST11", SqlDbType.NVarChar).Value = Me.TextTotalBalance.Text.Trim
                .Parameters.Add("@CST12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CST13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CST14", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text.Trim
                .Parameters.Add("@CST15", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CST16", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CST17", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text.Trim
                .Parameters.Add("@CST18", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text.Trim
                .Parameters.Add("@CST19", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@CST20", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CST21", SqlDbType.NVarChar).Value = Me.TextMonthlyInstallment.Text.Trim
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
            MessageBox.Show(ex.Message, "ErrorSaveEMPCOST", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub SaveEMPCOSTDETALLS()
        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO EMPCOSTDETALLS (CSDT1,  CSDT2,  CSDT3, CSDT4, CSDT5, CSDT6, CST1) VALUES     (@CSDT1, @CSDT2, @CSDT3, @CSDT4, @CSDT5, @CSDT6, @CST1)", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
                .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1")
                .Parameters.Add("@CSDT2", SqlDbType.Float, 8, "CSDT2")
                .Parameters.Add("@CSDT3", SqlDbType.Float, 8, "CSDT3")
                .Parameters.Add("@CSDT4", SqlDbType.NVarChar, 255, "CSDT4")
                .Parameters.Add("@CSDT5", SqlDbType.DateTime, 8, "CSDT5")
                .Parameters.Add("@CSDT6", SqlDbType.NVarChar, 150, "CSDT6")
                .Parameters.Add("@CST1", SqlDbType.BigInt).Value = TEXTID.EditValue
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "EMPCOSTDETALLS", New DataColumnMapping() {New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CSDT4", "CSDT4"), New DataColumnMapping("CSDT5", "CSDT5"), New DataColumnMapping("CSDT6", "CSDT6"), New DataColumnMapping("CST1", "CST1"), New DataColumnMapping("CSDT", "CSDT")})})
            SqlDataAdapter2.InsertCommand = CMD
            SqlDataAdapter2.Update(ds1, "EMPCOSTDETALLS")
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveEMPCOSTDETALLS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub UPDATEEMPCOST()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update EMPCOST SET   CST2 = @CST2, CST3 = @CST3, CST4 = @CST4, CST5 = @CST5, CST6 = @CST6, CST7 = @CST7, CST8 = @CST8, CST9 = @CST9, CST10 = @CST10, CST11 = @CST11, CST12 = @CST12, CST13 = @CST13, CST14 = @CST14, CST15 = @CST15, CST16 = @CST16, CST17 = @CST17, CST18 = @CST18, CST19 = @CST19, CST20 = @CST20, CST21 = @CST21, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE  CST1 = @CST1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CST1", SqlDbType.BigInt).Value = Me.TEXTID.EditValue
                .Parameters.Add("@CST2", SqlDbType.NVarChar).Value = Me.TEXTEmployeeName.Text.Trim
                .Parameters.Add("@CST3", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.Text.Trim
                .Parameters.Add("@CST4", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text.Trim
                .Parameters.Add("@CST5", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettled.Checked)
                .Parameters.Add("@CST6", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@CST7", SqlDbType.DateTime).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CST8", SqlDbType.NVarChar).Value = Me.ComboNumberOfYears.Text
                .Parameters.Add("@CST9", SqlDbType.NVarChar).Value = Me.TEXTMonths.Text
                .Parameters.Add("@CST10", SqlDbType.NVarChar).Value = Me.TEXTComments.Text.Trim
                .Parameters.Add("@CST11", SqlDbType.NVarChar).Value = Me.TextTotalBalance.Text.Trim
                .Parameters.Add("@CST12", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@CST13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CST14", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text.Trim
                .Parameters.Add("@CST15", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CST16", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CST17", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text.Trim
                .Parameters.Add("@CST18", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text.Trim
                .Parameters.Add("@CST19", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text.Trim
                .Parameters.Add("@CST20", SqlDbType.Date).Value = Me.CheckDate.Value.ToString
                .Parameters.Add("@CST21", SqlDbType.NVarChar).Value = Me.TextMonthlyInstallment.Text.Trim
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@COUser", SqlDbType.Float).Value = COUser
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
    Private Sub UPDATEEMPCOSTDETALLS()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand("Update EMPCOSTDETALLS SET  CSDT1 = @CSDT1, CSDT3 = @CSDT3, CSDT4 = @CSDT4, CSDT5 = @CSDT5, CSDT6 = @CSDT6, CST1 = @CST1 WHERE  CSDT = @CSDT", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
                .Parameters.Add("@CSDT1", SqlDbType.Int, 4, "CSDT1")
                .Parameters.Add("@CSDT2", SqlDbType.Float, 8, "CSDT2")
                .Parameters.Add("@CSDT3", SqlDbType.Float, 8, "CSDT3")
                .Parameters.Add("@CSDT4", SqlDbType.NVarChar, 255, "CSDT4")
                .Parameters.Add("@CSDT5", SqlDbType.DateTime, 8, "CSDT5")
                .Parameters.Add("@CSDT6", SqlDbType.NVarChar, 150, "CSDT6")
                .Parameters.Add("@CST1", SqlDbType.BigInt).Value = TEXTID.EditValue
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table1", "EMPCOSTDETALLS", New DataColumnMapping() {New DataColumnMapping("CSDT1", "CSDT1"), New DataColumnMapping("CSDT2", "CSDT2"), New DataColumnMapping("CSDT3", "CSDT3"), New DataColumnMapping("CSDT4", "CSDT4"), New DataColumnMapping("CSDT5", "CSDT5"), New DataColumnMapping("CSDT6", "CSDT6"), New DataColumnMapping("CST1", "CST1"), New DataColumnMapping("CSDT", "CSDT")})})
            SqlDataAdapter2.UpdateCommand = CMD
            SqlDataAdapter2.Update(ds1, "EMPCOSTDETALLS")
            SqlDataAdapter2.TableMappings.Clear()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATEEMPCOSTDETALLS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            SqlDataAdapter2.TableMappings.Clear()
            Consum.Close()
        Finally
            Consum.Close()
        End Try
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TEXTID.EditValue = ds1.Tables("EMPCOST").Rows(BS.Position)("CST1").ToString
            .TEXTEmployeeName.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST2").ToString
            .TEXTEmployeeCode.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST3").ToString
            .TEXTStatement.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST4").ToString
            .CheckSettled.Checked = ds1.Tables("EMPCOST").Rows(BS.Position)("CST5").ToString
            .CheckTransferAccounts.Checked = ds1.Tables("EMPCOST").Rows(BS.Position)("CST6").ToString
            .DateMovementHistory.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST7").ToString
            .ComboNumberOfYears.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST8").ToString
            .TEXTMonths.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST9").ToString
            .TEXTComments.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST10").ToString
            .TextTotalBalance.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST11").ToString
            .CheckLogReview.Checked = ds1.Tables("EMPCOST").Rows(BS.Position)("CST12").ToString
            .TextMovementSymbol.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST13").ToString
            .ComboPaymentMethod.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST14").ToString
            .TextFundValue.EditValue = ds1.Tables("EMPCOST").Rows(BS.Position)("CST15").ToString
            .TextValueOfCheck.EditValue = ds1.Tables("EMPCOST").Rows(BS.Position)("CST16").ToString
            .ComboCheckDrawerName.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST17").ToString
            .TextCheckDrawerCode.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST18").ToString
            .TextCheckNumber.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST19").ToString
            .CheckDate.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST20").ToString
            .TextMonthlyInstallment.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CST21").ToString
            .ComboCB1.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("CB1").ToString
            .ComboBN2.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("BN2").ToString

            .TEXTUserName.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = ds1.Tables("EMPCOST").Rows(Me.BS.Position).Item("Auditor").ToString
            .TextDefinitionDirectorate.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("COUser").ToString
            .TEXTAddDate.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("da").ToString
            .TextTimeAdd.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("ne").ToString
            .TEXTReviewDate.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("da1").ToString
            .TextreviewTime.Text = ds1.Tables("EMPCOST").Rows(BS.Position)("ne1").ToString
        End With
        FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        Auditor("EMPCOST", "USERNAME", "CST1", Me.TEXTID.EditValue, "")

        Logentry = Uses
    End Sub
    Private Sub TEXTBOX2_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTEmployeeName.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                Connection.ACONET1.Add("الصندوق")
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
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click

        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If TransferofAccounts = False Then
            MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
            Exit Sub
        End If

        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية الترحيل وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If

            If TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            Dim resault As Integer
            If OBCHK9 = True Then
                If Me.CheckTransferAccounts.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts.Checked = True
                        TransforAccounts()
                        Me.UPDATEALLCUSTOMERS2()
                        Me.UPDATEEMPCOST()
                        Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TEXTUserName.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            DELETEDATMOVESDATA()
                            DELETEDATMOVESDATA1()
                        End If
                        TransforAccounts()
                        UPDATEALLCUSTOMERS2()
                        Me.UPDATEEMPCOST()
                        AccountingprocedureA()
                        Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            DELETEDATMOVESDATA()
                            DELETEDATMOVESDATA1()
                            DELETEDATAempsolf()
                            Me.CheckTransferAccounts.Checked = False
                            UPDATEALLCUSTOMERS3()
                            Me.UPDATEEMPCOST()
                            Insert_Actions(Me.TEXTID.Text, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    End If
                End If

            Else
                If ComboPaymentMethod.Text = "نقدا" Then
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            Me.UPDATEALLCUSTOMERS2()
                            Me.UPDATEEMPCOST()
                            Insert_Actions(Me.TEXTID.EditValue.Trim, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TEXTUserName.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                DELETEDATMOVESDATA()
                                DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                DELETEDATBANK()
                            End If
                            TransforAccounts()
                            UPDATEALLCUSTOMERS2()
                            Me.UPDATEEMPCOST()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                DELETEDATMOVESDATA()
                                DELETEDATMOVESDATA1()
                                DELETEDATAempsolf()
                                Me.CheckTransferAccounts.Checked = False
                                UPDATEALLCUSTOMERS3()
                                Me.UPDATEEMPCOST()
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '======================================================================================================
                ElseIf ComboPaymentMethod.Text = "شيك" Then
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
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم " & Me.TextMovementSymbol.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            UPDATEALLCUSTOMERS2()
                            Me.UPDATEEMPCOST()
                            Insert_Actions(Me.TEXTID.EditValue, " ترحيل  الى القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TEXTUserName.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                DELETEDATMOVESDATA()
                                DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                DELETEDATBANK()
                            End If
                            TransforAccounts()
                            UPDATEALLCUSTOMERS2()
                            Me.UPDATEEMPCOST()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                DELETEDATBANK()
                                DELETEDATMOVESDATA()
                                DELETEDATMOVESDATA1()
                                UPDATEALLCUSTOMERS3()
                                Me.CheckTransferAccounts.Checked = False
                                Me.UPDATEEMPCOST()
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الشيكات رقم" & " " & Me.TextMovementSymbol.Text, Me.Text)
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
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم " & Me.TextMovementSymbol.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
                            UPDATEALLCUSTOMERS2()
                            Me.UPDATEEMPCOST()
                            Insert_Actions(Me.TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TEXTUserName.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                DELETEDATMOVESDATA()
                                DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                DELETEDATAempsolf()
                            End If
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                DELETEDATBANK()
                            End If
                            TransforAccounts()
                            UPDATEALLCUSTOMERS2()
                            Me.UPDATEEMPCOST()
                            AccountingprocedureA()
                            Insert_Actions(Me.TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                DELETEDATBANK()
                                DELETEDATAempsolf()
                                DELETEDATMOVESDATA()
                                DELETEDATMOVESDATA1()
                                UPDATEALLCUSTOMERS3()
                                Me.CheckTransferAccounts.Checked = False
                                EDITBUTTON_Click(sender, e)
                                Insert_Actions(Me.TEXTID.EditValue, "حذف ترحيل حركة الصندزق و الشيكات رقم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If

            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub ButtonDELRECORD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDELRECORD.Click
        On Error Resume Next
        'If LockDelete = True Then
        '    MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
        '    Exit Sub
        'End If
        Static Dim S As Integer
        S = BS.Position
        Dim resault As Integer
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If BS.Count > 0 Then
            resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                For Each row As DataGridViewRow In DataGridView1.SelectedRows
                    Dim n As Integer
                    n = Me.DataGridView1.Rows(row.Index).Cells(0).Value
                    Dim CMD2 As New SqlClient.SqlCommand With {
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM EMPCOSTDETALLS WHERE CSDT=" & n, Consum)
                    CMD2.CommandText = SQL2.CommandText
                    CMD2.ExecuteNonQuery()
                Next
                Consum.Close()
                Load_Click(sender, e)
                BS.Position = S
                EDITBUTTON_Click(sender, e)
            Else
                MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Else
            MessageBox.Show(" لايوجد سجل حالى لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        BS.Position = 0
        RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position - 1
        RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Position + 1
        RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        BS.Position = BS.Count - 1
        RecordCount()
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
        BAD = True
        On Error Resume Next
        BS.Position = BS.Count - 1

        CLEARDATA1(Me)
        BS.EndEdit()
        BS.AddNew()

        GetAutoNumber("CST1", "EMPCOST", "CST7")
        Me.TEXTID.EditValue = AutoNumber
        Me.TEXTID1.Text = AutoNumber
        Me.TextMovementSymbol.Text = "AS" & Me.TEXTID.EditValue
        Me.TEXTID1.Enabled = True
        Me.TEXTID1.Focus()

        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")

        Me.ComboNumberOfYears.Text = "1"
        Me.TEXTTotalDebit.Text = "0"
        Me.TEXTEmployeeName.Text = ""
        Me.TEXTEmployeeCode.Text = ""
        Me.TEXTStatement.Text = "سلفة الموظفين"
        Me.TEXTComments.Text = ""
        Me.TEXTTotal.Text = ""
        Me.TextTotalCred.Text = "0.000"
        Me.TextTotalBalance.Text = "0.000"
        Me.TextMonthlyInstallment.Text = "0.000"
        Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")

        Me.ComboPaymentMethod.Text = ""
        Me.ComboCB1.Text = ""
        Me.TextFundValue.EditValue = ""

        Me.ComboBN2.Text = ""
        Me.TextCheckNumber.Text = ""
        Me.CheckDate.Value = Nothing
        Me.TextValueOfCheck.EditValue = ""
        Me.ComboCheckDrawerName.Text = ""


        Me.CheckSettled.Checked = True
        Me.CheckTransferAccounts.Checked = True
        Me.CheckLogReview.Checked = True
        Me.CheckSettled.Checked = False
        Me.CheckTransferAccounts.Checked = False
        Me.CheckLogReview.Checked = False



        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If


        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
        InternalAuditorType()
        'Me.ADDBUTTON.Enabled = False
        'Me.EDITBUTTON.Enabled = False
        'Me.SAVEBUTTON.Enabled = True
        'Me.BUTTONCANCEL.Enabled = True
        'Me.DELETEBUTTON.Enabled = False
        'Me.ButtonDELRECORD.Enabled = False
        'Me.ButtonTransferofAccounts.Enabled = False
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        Try

            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOPTIONS.ShowDialog()
                Exit Sub
            End If
            Static Dim P As Integer
            Me.DataGridView1_CurrentCellChanged(sender, e)
            P = BS.Position
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")

            Me.TEXTTotalDebit.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
            Me.TextTotalCred.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT3").Value))).ToString("0.000")

            If TEXTEmployeeName.Text = Nothing Then MessageBox.Show("اسم الموظف - كوده فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If ComboPaymentMethod.Text = Nothing Then MessageBox.Show("طريقة الدفع فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If ComboCB1.Text = Nothing Then MessageBox.Show("رقم الصندوق فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
            If Me.ComboPaymentMethod.Text = "شيك" Or Me.ComboPaymentMethod.Text = "نقدا_شيك" Then
                GroupCHKS.Enabled = True
                GroupCHKS1.Enabled = True
                'TextCheckNumber.Enabled = True
                'CheckDate.Enabled = True
                'ComboCheckDrawerName.Enabled = True
                If ComboBN2.Text = Nothing Then MessageBox.Show("رقم الحساب فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If TextCheckNumber.Text = Nothing Then MessageBox.Show("رقم الشيك فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If CheckDate.Value = Nothing Then MessageBox.Show("تاريخ الشيك فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If ComboCheckDrawerName.Text = Nothing Then MessageBox.Show("اسم  ساحب الشيك فارغ", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub
                If Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue) <> Val(TextTotalBalance.Text) Then
                    MessageBox.Show("يجب ان تكون قيمة الصندوق و قيمة الشيك مساوية الى اجمالى الرصيد", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            ElseIf Me.ComboPaymentMethod.Text = "نقدا" Then
                GroupCHKS.Enabled = False
                GroupCHKS1.Enabled = False
                'TextCheckNumber.Enabled = False
                'CheckDate.Enabled = False
                'ComboCheckDrawerName.Enabled = False
                If Val(TextFundValue.EditValue) <> Val(TextTotalBalance.Text) Then
                    MessageBox.Show("يجب ان تكون قيمة الصندوق  مساوية الى اجمالى الرصيد", "تنبية", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If
            End If



            Me.UPDATEEMPCOST()
            Me.SaveEMPCOSTDETALLS()
            Me.RecordCount()
            Me.Load_Click(sender, e)
            Me.BS.Position = P
            Me.UPDATEEMPCOST()
            Me.UPDATEEMPCOSTDETALLS()
            Me.SaveEMPCOSTDETALLS()
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

            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
            RecordCount()
            SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        'Me.DataGridView1_CurrentCellChanged(sender, e)
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.SumAmountEMP()
        Me.TextTotalBalance.Text = Format(Me.TEXTTotalDebit.Text - Me.TextTotalCred.Text, "0.000")
        Me.TEXTTotal.Text = CurrencyJO(Me.TextTotalBalance.Text, "jO")
        Me.UPDATEEMPCOST()
        Me.UPDATEEMPCOSTDETALLS()
        Me.SaveEMPCOSTDETALLS()
        Me.Load_Click(sender, e)
        Me.SumAmountEMP()
        Me.TextTotalBalance.Text = Format(Me.TEXTTotalDebit.Text - Me.TextTotalCred.Text, "0.000")
        Me.TEXTTotal.Text = CurrencyJO(Me.TextTotalBalance.Text, "jO")
        Me.UPDATEEMPCOST()
        Me.UPDATEEMPCOSTDETALLS()
        Me.SaveEMPCOSTDETALLS()
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        Insert_Actions(Me.TEXTID.EditValue, "تعديل", Me.Text)
        RecordCount()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = True
        Me.ButtonDELRECORD.Enabled = True
        Me.ButtonTransferofAccounts.Enabled = True
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "Error111", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'End Try
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            Dim resault As Integer
            resault = MessageBox.Show("هل تريد حذف السجل الحالى ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                MYDELETERECORD("EMPCOSTDETALLS", "CST1", Me.TEXTID, Me.BS, True)
                MYDELETERECORD("EMPCOST", "CST1", Me.TEXTID, Me.BS, True)
                Me.Load_Click(sender, e)
                Me.SumAmountEMP()
                Me.DataGridView1_CurrentCellChanged(sender, e)
                Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
            Else
                Exit Sub
            End If
        Else
            MYDELETERECORD("EMPCOSTDETALLS", "CST1", Me.TEXTID, Me.BS, True)
            MYDELETERECORD("EMPCOST", "CST1", Me.TEXTID, Me.BS, True)
            Me.Load_Click(sender, e)
            Me.SumAmountEMP()
            Me.DataGridView1_CurrentCellChanged(sender, e)
            Insert_Actions(Me.TEXTID.EditValue, "حذف", Me.Text)
        End If
    End Sub
    Private Sub TEXTID_KeyDown(sender As Object, e As KeyEventArgs) Handles TEXTID1.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                TEXTID1.SendToBack()
                TEXTID.BringToFront()
                Me.TEXTEmployeeName.Focus()
        End Select

    End Sub

    Private Sub TEXTID_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTID1.LostFocus
        On Error Resume Next
        Static P As Integer
        P = Me.BS.Position
        Me.SaveEMPCOST()
        Me.Load_Click(sender, e)
        Me.BS.Position = P
        Me.TEXTID1.Enabled = False
        Me.TextCheckNumber.Text = ""
        TEXTEmployeeName.Focus()
        If BAD = True Then
            Me.ADDBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
        Else
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = True
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = True
            Me.ButtonDELRECORD.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
        End If
    End Sub
    Private Sub TEXTStatement_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTStatement.LostFocus





    End Sub
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboNumberOfYears.SelectedIndexChanged
        On Error Resume Next
        Me.TEXTMonths.Text = Format(Val(Me.ComboNumberOfYears.Text) * 12)
        Int(Me.TEXTMonths)
        Me.TEXTTotalDebit.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
        Me.TextTotalCred.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT3").Value))).ToString("0.000")
    End Sub
    Private Sub ComboBox1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboNumberOfYears.LostFocus
        On Error Resume Next
        Me.TEXTMonths.Text = Format(Val(Me.ComboNumberOfYears.Text) * 12)
        Int(Me.TEXTMonths)
    End Sub
    Private Sub TextBox11_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTTotalDebit.TextChanged, TextTotalCred.TextChanged, TextTotalBalance.TextChanged, ComboPaymentMethod.TextChanged
        On Error Resume Next
        Me.TEXTTotalDebit.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
        Me.TextTotalCred.Text = Val(Me.DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT3").Value))).ToString("0.000")

        Me.TEXTTotalDebit.Text = Format(Val(Me.TEXTTotalDebit.Text) * Val(Me.ComboNumberOfYears.Text), "0.000")
        Me.TextTotalBalance.Text = Format(Val(Me.TEXTTotalDebit.Text) * Val(Me.ComboNumberOfYears.Text) - Val(Me.TextTotalCred.Text), "0.000")
        Me.TextMonthlyInstallment.Text = Format(Val(Me.TEXTTotalDebit.Text) / (Val(Me.ComboNumberOfYears.Text) * 12), "0.000")

        'SumAmountEMP()
        'Me.TEXTTotal.Text = CurrencyJO(TextTotalBalance.Text, "jO")
    End Sub
    Private Sub TEXTEmployeeName_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTEmployeeName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.TEXTEmployeeName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TEXTEmployeeCode.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TEXTEmployeeCode.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub UPDATEALLCUSTOMERS2()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update EMPLOYEES SET  EMP21 = @EMP21  WHERE EMP1 = @EMP1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EMP21", SqlDbType.Float).Value = SumAmountEMP()
                .Parameters.Add("@EMP1", SqlDbType.Int).Value = Me.TEXTEmployeeCode.Text.Trim
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
    Private Function SumAmountEMP() As Double
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT Sum(CSDT2) AS SumDEBIT ,Sum(CSDT3) AS SumCREDIT  FROM EMPCOSTDETALLS WHERE CST1 = '" & Me.TEXTID.Text & "'" & " ", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                SumAmountEMP = Format(ds.Tables(0).Rows(0).Item(0) - ds.Tables(0).Rows(0).Item(1), "0.000")
            Else
                SumAmountEMP = "0.00"
            End If
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
        Return SumAmountEMP
    End Function

    Private Sub UPDATEALLCUSTOMERS3()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand(" Update EMPLOYEES SET  EMP21 = @EMP21  ", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@EMP21", SqlDbType.NVarChar).Value = "0.00"
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
    Private Sub TEXTBOX5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTTotalDebit.TextChanged, TextTotalCred.TextChanged
        Try
            Me.TextTotalBalance.Text = Val(Me.TEXTTotalDebit.Text) - Val(Me.TextTotalCred.Text)
            Me.TEXTTotal.Text = CurrencyJO(TextTotalBalance.Text, "jO")
            If Val(Me.TEXTTotalDebit.Text) = Val(Me.TextTotalCred.Text) Then
                Me.CheckSettled.Checked = True
            Else
                Me.CheckSettled.Checked = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
        Try
            DataGridView1.Item("CSDT1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
            If Me.DataGridView1.Item("CSDT5", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("CSDT5", e.RowIndex).Value = MaxDate.ToString("yyyy-MM-dd")
            If Me.DataGridView1.Item("CSDT2", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("CSDT2", e.RowIndex).Value = "0.00"
            If Me.DataGridView1.Item("CSDT3", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("CSDT3", e.RowIndex).Value = Val(Me.TextMonthlyInstallment.Text)
            If Me.DataGridView1.Item("CSDT4", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("CSDT4", e.RowIndex).Value = "سداد سلفة موظف"
            If Me.DataGridView1.Item("CSDT6", e.RowIndex).Value Is DBNull.Value Then Me.DataGridView1.Item("CSDT6", e.RowIndex).Value = Me.TextMovementSymbol.EditValue
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
        On Error Resume Next
        Me.TEXTTotalDebit.Text = 0
        Me.TextTotalCred.Text = 0
        Me.TextTotalBalance.Text = 0
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            Me.TEXTTotalDebit.Text += Val(r.Cells("CSDT2").Value)
            Me.TextTotalCred.Text += Val(r.Cells("CSDT3").Value)
        Next


        Me.TEXTTotalDebit.Text = Format(Me.TEXTTotalDebit.Text, "0.000")
        Me.TextTotalCred.Text = Format(Me.TextTotalCred.Text, "0.000")
        Me.TextTotalBalance.Text = Format(Me.TEXTTotalDebit.Text - Me.TextTotalCred.Text, "0.000")
        Me.TEXTTotal.Text = CurrencyJO(Me.TextTotalBalance.Text, "jO")
        If Val(Me.TEXTTotalDebit.Text) = Val(Me.TextTotalCred.Text) Then
            Me.CheckSettled.Checked = True
        Else
            Me.CheckSettled.Checked = False
        End If
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.DataGridView1.Enabled = False
            Me.Panel2.Enabled = False
            Me.Panel3.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False

        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = True
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

            Me.Panel2.Enabled = True
            Me.Panel3.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.TabPage2.Enabled = True
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.ButtonDELRECORD.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True

            'Me.DataGridView1.Enabled = False
            Me.Panel2.Enabled = False
            Me.Panel3.Enabled = False
            Me.DataGridView1.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.Panel2.Enabled = True
            Me.Panel3.Enabled = True
            Me.DataGridView1.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.PanelAccount.Enabled = True
        End If
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
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
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATEEMPCOST()
        Me.Load_Click(sender, e)
        Me.UPDATEEMPCOST()
        Me.BS.Position = P
        MsgBox("تمت عمليةالمراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXTID.EditValue, "مراجعة", Me.Text)
        Me.RecordCount()
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATEEMPCOST()
        Me.Load_Click(sender, e)
        Me.UPDATEEMPCOST()
        Me.BS.Position = P
        MsgBox("تمت عملية إلغاءالمراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TEXTID.EditValue, "إلغاء المراجع", Me.Text)

    End Sub

    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Dim Adp2 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
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
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
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
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpCreditAccount.Value)
            Me.List1.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "سلفة الموظفين رقم " & " " & ":" & " " & Me.TEXTID.Text & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "للموظف" & " " & ":" & " " & Me.TEXTEmployeeName.Text & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
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
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
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
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.Text)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C
        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.Text, Me.TEXTID.Text)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.Text)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH

    End Sub
    Private Sub FundBalance()
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



    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
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


    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = "صرف سلفة الموظفين نقدا "
        nem1 = "صرف رواتب الموظفين نقدا "
        nem2 = "صرف سلفة الموظفين بيموجب مستند رقم " & " " & Me.TextCheckNumber.Text.Trim
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No

        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam


        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True

        If Check_OptionsTransforAccounts.Checked = True Then
            OptionsTransforAccountsTo(ComboPaymentMethod.Text, ComboDebitAccount.Text, TextCreditAccount.Text)
        End If
        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TextTotalBalance.Text, TextTotalBalance.Text, T3, "صرف", "AS", TextMovementSymbol.Text, False)

        If OBCHK9 = True Then
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextTotalBalance.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.Text, TEXTID.Text, False, T2)
            DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TextTotalBalance.Text, nem1, CodAccount, TextMovementSymbol.Text, TEXTID.Text, False, T2)
        Else
            Select Case Me.ComboPaymentMethod.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextTotalBalance.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.Text, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextTotalBalance.Text, nem1, CodAccount, TextMovementSymbol.Text, TEXTID.Text, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.Text, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.Text & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "شيك"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextTotalBalance.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.Text, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.Text, TEXTID.Text, False, T2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.Text, False, ComboCB1.Text, ComboBN2.Text)

                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextTotalBalance.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.Text, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.Text, TEXTID.Text, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.Text, TEXTID.Text, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.Text, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.Text & "0",
                                                                False, True, ComboCB1.Text, CB2)

                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.Text, False, ComboCB1.Text, ComboBN2.Text)


            End Select
        End If
        Me.UPDATEEMPCOST()
    End Sub



    Private Sub  AccountsEnquiry()
        On Error Resume Next

        DebitAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing



        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextValueOfCheck.EditValue = "0.000"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.ComboCB1.Enabled = True
                Me.ComboBN2.Enabled = False
                GroupCHKS.Enabled = False
                GroupCHKS1.Enabled = False
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"

                TextCreditAccount.Text = FundAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
            Case "شيك"
                Me.TextFundValue.EditValue = "0.000"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.ComboCB1.Enabled = False
                Me.ComboBN2.Enabled = True
                GroupCHKS.Enabled = True
                GroupCHKS1.Enabled = True
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.ComboCB1.Enabled = True
                Me.ComboBN2.Enabled = True
                GroupCHKS.Enabled = True
                GroupCHKS1.Enabled = True
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod


        End Select
    End Sub
    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
         AccountsEnquiry()
    End Sub

End Class