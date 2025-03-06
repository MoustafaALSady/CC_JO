Option Explicit Off
Imports System.Data.Common
Imports System.Data.SqlClient
Public Class FrmMyCosts1
<<<<<<< HEAD
    Inherits Form
    Dim BAD As Boolean = False
    Dim SqlDataAdapter1 As New SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Dim BAD As Boolean = False
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    ReadOnly ds1 As New DataSet
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Public WithEvents BS As New BindingSource
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim NO As String
    Dim NO1 As Integer = 0


<<<<<<< HEAD
    Private Sub FrmMyCosts1_Activated(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmMyCosts_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
=======
    Private Sub FrmMyCosts1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmMyCosts_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub FrmMyCosts_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmMyCosts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SHOWBUTTON()
        Me.FundBalance()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False

        Me.TEXTStatement.DataSource = GetData(3)
        Me.TEXTStatement.DisplayMember = "account_name"
        If TEXTStatement.Items.Count > 0 Then
            Me.TEXTStatement.SelectedIndex = 0
        End If
        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

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
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            Me.PictureBox5.Visible = False
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub SaveMYCOSTS()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO MYCOSTS (CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, cuser, couser, da, ne, da1, ne1) VALUES     (@CST1, @CST2, @CST3, @CST4, @CST5, @CST6, @CST7, @CST8, @CST9, @CST10, @CST11, @CST12, @CST13, @CST14, @CST15, @CST16, @CST17, @CST18, @CST19, @CST20, @CST21, @CB1, @BN2, @USERNAME, @cuser, @couser, @da, @ne, @da1, @ne1)", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO MYCOSTS (CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, cuser, couser, da, ne, da1, ne1) VALUES     (@CST1, @CST2, @CST3, @CST4, @CST5, @CST6, @CST7, @CST8, @CST9, @CST10, @CST11, @CST12, @CST13, @CST14, @CST15, @CST16, @CST17, @CST18, @CST19, @CST20, @CST21, @CB1, @BN2, @USERNAME, @cuser, @couser, @da, @ne, @da1, @ne1)", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CST1", SqlDbType.BigInt).Value = Me.TEXTInvoiceNumber.EditValue
            .Parameters.Add("@CST2", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
            .Parameters.Add("@CST3", SqlDbType.NVarChar).Value = Me.TEXTMonths.Text
            .Parameters.Add("@CST4", SqlDbType.NVarChar).Value = Me.TEXTDetails.Text
            .Parameters.Add("@CST5", SqlDbType.Bit).Value = False
            .Parameters.Add("@CST6", SqlDbType.Bit).Value = False
            .Parameters.Add("@CST7", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@CST8", SqlDbType.NVarChar).Value = Me.TEXTCustomerName.Text
            .Parameters.Add("@CST9", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
            .Parameters.Add("@CST10", SqlDbType.NVarChar).Value = Me.TextNotes.Text
            .Parameters.Add("@CST11", SqlDbType.Float).Value = Me.TEXTTotal.Text
            .Parameters.Add("@CST12", SqlDbType.Bit).Value = False
            .Parameters.Add("@CST13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@CST14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
            .Parameters.Add("@CST15", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
            .Parameters.Add("@CST16", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
            .Parameters.Add("@CST17", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
            .Parameters.Add("@CST18", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
            .Parameters.Add("@CST19", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@CST20", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
            .Parameters.Add("@CST21", SqlDbType.Bit).Value = False
            .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
            .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
            .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
            .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
            .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub SaveMYCOSTDETAILS()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO MYCOSTDETAILS (CSDT1, CSDT2, CSDT3, CST1) VALUES     (@CSDT1, @CSDT2, @CSDT3, @CST1)", Consum)
        Dim CMD As New SqlCommand With {
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO MYCOSTDETAILS (CSDT1, CSDT2, CSDT3, CST1) VALUES     (@CSDT1, @CSDT2, @CSDT3, @CST1)", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand(" Update MYCOSTS SET  CST2 = @CST2, CST3 = @CST3, CST4 = @CST4, CST5 = @CST5, CST6 = @CST6, CST7 = @CST7, CST8 = @CST8, CST9 = @CST9, CST10 = @CST10, CST11 = @CST11, CST12 = @CST12, CST13 = @CST13, CST14 = @CST14, CST15 = @CST15, CST16 = @CST16, CST17 = @CST17, CST18 = @CST18, CST19 = @CST19, CST20 = @CST20, CST21 = @CST21, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, cuser = @cuser, couser = @couser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE  CST1 = @CST1", Consum)
        Dim CMD As New SqlCommand With {
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand(" Update MYCOSTS SET  CST2 = @CST2, CST3 = @CST3, CST4 = @CST4, CST5 = @CST5, CST6 = @CST6, CST7 = @CST7, CST8 = @CST8, CST9 = @CST9, CST10 = @CST10, CST11 = @CST11, CST12 = @CST12, CST13 = @CST13, CST14 = @CST14, CST15 = @CST15, CST16 = @CST16, CST17 = @CST17, CST18 = @CST18, CST19 = @CST19, CST20 = @CST20, CST21 = @CST21, CB1 = @CB1, BN2 = @BN2, USERNAME = @USERNAME, cuser = @cuser, couser = @couser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE  CST1 = @CST1", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            .Parameters.Add("@CST5", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
            .Parameters.Add("@CST6", SqlDbType.Bit).Value = False
            .Parameters.Add("@CST7", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@CST8", SqlDbType.NVarChar).Value = Me.TEXTCustomerName.Text
            .Parameters.Add("@CST9", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
            .Parameters.Add("@CST10", SqlDbType.NVarChar).Value = Me.TextNotes.Text
            .Parameters.Add("@CST11", SqlDbType.Float).Value = Me.TEXTTotal.Text
            .Parameters.Add("@CST12", SqlDbType.Bit).Value = False
            .Parameters.Add("@CST13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@CST14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
            .Parameters.Add("@CST15", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
            .Parameters.Add("@CST16", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
            .Parameters.Add("@CST17", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
            .Parameters.Add("@CST18", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
            .Parameters.Add("@CST19", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@CST20", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
            .Parameters.Add("@CST21", SqlDbType.Bit).Value = False
            .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
            .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
            .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
            .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
            .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub UPDATEMYCOSTDETAILS()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update MYCOSTDETAILS SET  CSDT1 = @CSDT1, CSDT2 = @CSDT2, CSDT3 = @CSDT3, CST1 = @CST1 WHERE  CSDT = @CSDT", Consum)
        Dim CMD As New SqlCommand With {
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("Update MYCOSTDETAILS SET  CSDT1 = @CSDT1, CSDT2 = @CSDT2, CSDT3 = @CSDT3, CST1 = @CST1 WHERE  CSDT = @CSDT", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@CSDT", SqlDbType.Int, 4, "CSDT")
            .Parameters.Add("@CSDT1", SqlDbType.Int, 4).Value = Me.TEXTInvoiceNumber.EditValue
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
<<<<<<< HEAD
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
=======
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
    Private Sub MAXRECORD1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim V As Int64
        Dim SQL As New SqlCommand("SELECT MAX(MYCOSTS.CST1) FROM MYCOSTS   WHERE CUser='" & CUser & "'and   Year(CST7) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
<<<<<<< HEAD
        Dim CMD As New SqlCommand
=======
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        Dim noD As Object = Strings.Mid(CMD.ExecuteScalar(), 7)
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
<<<<<<< HEAD
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
=======
    Private Sub DataGridView1_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.CurrentCellChanged
=======
    Private Sub DataGridView1_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim ItemsTotal As Double = Val(DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
        Me.TEXTTotal.Text = ItemsTotal.ToString("0.000")
    End Sub
<<<<<<< HEAD
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
=======
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Me.DataGridView1.CurrentCell.ColumnIndex = 2 Then
            Me.DataGridView1.CurrentRow.Cells(2).Value = Calculator()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
=======
    Private Sub DataGridView1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.DataGridView1.Item("CSDT1", e.RowIndex).Value = Me.DataGridView1.CurrentRow.Index + 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error1011", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView1.SelectionChanged
=======
    Private Sub DataGridView1_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.SelectionChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim ItemsTotal As Double = Val(DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
        Me.TEXTTotal.Text = ItemsTotal.ToString("0.000")
    End Sub
<<<<<<< HEAD
    Private Sub DateTimePicker1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles DateMovementHistory.KeyUp
=======
    Private Sub DateTimePicker1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DateMovementHistory.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTMonths.Focus()
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX3_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTMonths.KeyUp
=======
    Private Sub TEXTBOX3_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTMonths.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TEXTDetails.Focus()
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTBOX4_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTDetails.KeyUp
=======
    Private Sub TEXTBOX4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTDetails.KeyUp
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                Me.TextNotes.Focus()
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        Call MangUsers()
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        FILLCOMBOBOXDISTINCT("AllCustomers", "cust2", "IDcust", "CUser", CUser, Me.ComboCustomerName)
        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)

        Me.TEXTStatement.DataSource = GetData(3)
        Me.TEXTStatement.DisplayMember = "account_name"

        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        Me.BAD = True
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        Me.TEXTInvoiceNumber.Enabled = True
        Dim s As Integer
        Dim n As Double
        n = Me.BS.Count
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        s = Val(Me.TEXTInvoiceNumber.EditValue)
        Me.BS.EndEdit()
        Me.BS.AddNew()
        CLEARDATA1(Me)
        Me.TEXTInvoiceNumber.Enabled = True
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

        Me.TextMovementSymbol.EditValue = "GE" & Me.TEXTInvoiceNumber.EditValue
        'Me.TEXTBOX2.Text = ""
        Me.TEXTMonths.Text = ""
        Me.TEXTDetails.Text = "(" & "اصدار فاتورة مصروفات" & ")" & ""
        Me.TEXTTotal.Text = "0"
        Me.TextNotes.Text = ""
        Me.TEXTCustomerName.Text = "==لا يوجد عميل=="
        Me.TextCustomerNumber.EditValue = "0"
        Me.ComboPaymentMethod.Text = "نقدا"
        Me.TextFundValue.EditValue = "0"
        Me.TextValueOfCheck.EditValue = "0"
        Me.ComboCheckDrawerName.Text = ""
        Me.TextCheckDrawerCode.Text = "0"
        Me.TextCheckNumber.Text = "0"
        Me.CheckDate.Value = Nothing
        Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
        Me.DataGridView1.CurrentRow.Cells.Clear()

        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
        Me.AccountsEnquiry()
        Me.FundBalance()
        Me.TEXTInvoiceNumber.Focus()
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
    End Sub
<<<<<<< HEAD
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SAVEBUTTON.Click
=======
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            If Year(DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If

            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            If ExitSub_Check = True Then
                FrmOptions.ShowDialog()
                Exit Sub
            End If
            If OBCHK6 = False Then
                If Val(Me.TEXTTotal.Text) <> (Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue)) Then
                    MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                    Exit Sub
                End If
                Dim ch As Double = "0.00"
                Dim ch1 As Double = "0.00"
                ch = Me.TextFundValue.EditValue
                ch1 = Me.TextFundBalance.Text
                If ch1 < ch Then
                    MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                    Exit Sub
                End If
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
                Me.ADDBUTTON.Enabled = False
                Me.SAVEBUTTON.Enabled = True
                Me.BAD = False
            Else
                Me.ADDBUTTON.Enabled = True
                Me.SAVEBUTTON.Enabled = False
            End If
            Static Dim P As Integer
            P = Me.BS.Position
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTS()
            Me.SaveMYCOSTDETAILS()
            Me.DanLOd()
            Dim ItemsTotal As Double = Val(DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
            Me.TEXTTotal.Text = ItemsTotal.ToString("0.000")
            Me.BS.Position = P
            Me.UPDATEMYCOSTS()
            Me.UPDATEMYCOSTDETAILS()
            Me.SaveMYCOSTS()
            Me.SaveMYCOSTDETAILS()
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

<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.BS.Position = P
            Insert_Actions(Me.TEXTInvoiceNumber.EditValue, "حفظ", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Dim str1 As String = "SELECT CST1, CST2, CST3, CST4, CST5, CST6, CST7, CST8, CST9, CST10, CST11, CST12, CST13, CST14, CST15, CST16, CST17, CST18, CST19, CST20, CST21, CB1, BN2, USERNAME, cuser, couser, da, ne, da1, ne1 FROM MYCOSTS WHERE  CST1='" & Me.TEXTInvoiceNumber.EditValue & "' ORDER BY CST1 "
        Dim str2 As String = "SELECT CSDT, CST1, CSDT1, CSDT2, CSDT3 FROM MYCOSTDETAILS ORDER BY CSDT1 "
<<<<<<< HEAD
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1, Consum)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2, Consum)
=======
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1, Consum)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        Me.SHOWBUTTON()
        Me.SAVEBUTTON.Enabled = False
        Call MangUsers()
        Me.FundBalance()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
    End Sub
<<<<<<< HEAD
    Private Sub TEXTInvoiceNumber_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TEXTInvoiceNumber.KeyDown
=======
    Private Sub TEXTInvoiceNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TEXTInvoiceNumber.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TEXTInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TEXTInvoiceNumber.LostFocus
=======
    Private Sub TEXTInvoiceNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTInvoiceNumber.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Static P As Integer
        P = Me.BS.Position
        SaveMYCOSTS()
        Me.DanLOd()
        Me.BS.Position = P
        If Me.BAD = True Then
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
        Else
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim Str1 As String = Me.ComboCustomerName.Text
        Dim strArr() As String
        Dim a As String
        strArr = Str1.Split("-")
        a = strArr(0)
        If ComboCustomerName.Text.Length > 0 Then
            Me.TEXTCustomerName.Text = strArr(1)
            Me.TextCustomerNumber.EditValue = strArr(0)
        Else
            Me.TEXTCustomerName.Text = ""
            Me.TextCustomerNumber.EditValue = ""
        End If
        Me.ComboCustomerName.Enabled = False
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
=======
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.ComboCustomerName.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub FundBalance()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub



    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = "صرف مصاريف نقدية "
        nem1 = "صرف مصاريف نقدية " & " " & Me.TEXTStatement.Text.Trim
        nem2 = "صرف مصاريف بيموجب مستند رقم " & " " & TextCheckNumber.Text.Trim
        PMO2 = 1

        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        SEARCHDATA.MAXIDMOVES()

        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TEXTTotal.Text, TEXTTotal.Text, T3, "قيد", "GE", TextMovementSymbol.EditValue, False)

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TEXTTotal.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TEXTTotal.Text, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTInvoiceNumber.EditValue, False, T2)

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


    End Sub
    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        Dim ItemsTotal As Double = Val(DataGridView1.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells("CSDT2").Value))).ToString("0.000")
        Me.TEXTTotal.Text = ItemsTotal.ToString("0.000")
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
        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam


        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", AccountNoAktevd, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", AccountNoAktevd, 1)
        DebitAccount_Cod = ID_Nam

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"

                Me.TextValueOfCheck.Enabled = False
                Me.TextFundValue.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
            Case "شيك"
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
<<<<<<< HEAD
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                    TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    TypeCustomer = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RadioSUPPLIER.Checked = True Then
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
            ElseIf Me.RadioEMPLOYEES.Checked = True Then
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
    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        Me. AccountsEnquiry()
    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox17_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        Me. AccountsEnquiry()
    End Sub

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
        GetFundAccount_No(ModuleGeneral.CB2)
         AccountsEnquiry()
        FundBalance()

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



    Private Sub TEXTStatement_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TEXTStatement.SelectedIndexChanged
        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TEXTStatement.Text, 1)
        AccountNoAktevd = ID_Nam
         AccountsEnquiry()
    End Sub
End Class