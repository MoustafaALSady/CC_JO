Option Explicit Off
Imports System.Data.SqlClient
Public Class FrmCUSTOMER2
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()

    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Dim NO As String
    Dim NO1 As Integer = 0


    Private Sub FrmCUSTOMER1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
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
    Private Sub FrmCUSTOMER2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmCUSTOMER2_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
    End Sub
    Private Sub FrmCUSTOMER2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.SHOWBUTTON()
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.CombocustomerName)
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(CombocustomerName, e, )
    End Sub
    Private Sub TEXTBOX9_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(TEXTStatement, e, )
    End Sub
    Private Sub ComboBox7_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboCheckDrawerName, e, )
    End Sub

    Public Sub RefreshData()
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            'TEXTID.Clear()
            PictureBox2.Visible = True
            RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim V As Int64
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDCAB) FROM CABLES   WHERE CUser='" & CUser & "'and   Year(CAB3) = '" & Val(FiscalYear_currentDateMustBeInFiscalYear()) & " '", Consum)
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
            Me.TEXTID.EditValue = CType(NO1, Integer) & 1
        Else
            V = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
            Me.TEXTID.EditValue = V
        End If
        Consum.Close()
    End Sub
    Private Sub SAVERECORD()
        Try
            MAXRECORD()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim sql As String = "INSERT INTO CABLES(IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CAB24, CAB25, CAB26, CAB27, CAB28, CB1, BN2, USERNAME, Cuser, COUSER, da, ne) VALUES  (@IDCAB, @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB7, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB13, @CAB14, @CAB15, @CAB16, @CAB17, @CAB18, @CAB19, @CAB20, @CAB21, @CAB22, @CAB23, @CAB24, @CAB25, @CAB26, @CAB27, @CAB28, @CB1, @BN2, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(sql, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@IDCAB", SqlDbType.BigInt).Value = Val(Me.TEXTID.EditValue)
                .Parameters.Add("@CAB2", SqlDbType.NVarChar).Value = Me.TEXTPreviousBalance.Text
                .Parameters.Add("@CAB3", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CAB4", SqlDbType.NVarChar).Value = Me.TEXTDebit.EditValue
                .Parameters.Add("@CAB5", SqlDbType.NVarChar).Value = Me.TEXTCredit.EditValue
                .Parameters.Add("@CAB6", SqlDbType.NVarChar).Value = Me.TEXTType.Text
                .Parameters.Add("@CAB7", SqlDbType.NVarChar).Value = Me.TEXTCurrentBalance.Text
                .Parameters.Add("@CAB8", SqlDbType.NVarChar).Value = Me.TEXTDocumentNumber.Text
                .Parameters.Add("@CAB9", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@CAB10", SqlDbType.NVarChar).Value = Me.CombocustomerName.Text
                .Parameters.Add("@CAB11", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@CAB12", SqlDbType.NVarChar).Value = Me.TextCondition.Text
                .Parameters.Add("@CAB13", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CAB14", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@CAB15", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@CAB16", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@CAB17", SqlDbType.NVarChar).Value = Me.ComboSource.Text
                .Parameters.Add("@CAB18", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@CAB19", SqlDbType.NVarChar).Value = Me.TEXTTotalN.Text
                .Parameters.Add("@CAB20", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB21", SqlDbType.NVarChar).Value = Me.TextCustomerType.Text
                .Parameters.Add("@CAB22", SqlDbType.NVarChar).Value = Me.TextBank.Text
                .Parameters.Add("@CAB23", SqlDbType.NVarChar).Value = Me.TextBranch.Text
                .Parameters.Add("@CAB24", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB25", SqlDbType.Bit).Value = False
                .Parameters.Add("@CAB26", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@CAB27", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@CAB28", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = 0

                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = sql
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            myds = New DataSet
            SqlDataAdapter1.Fill(myds, "CABLES")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            BS.DataSource = myds.Tables("CABLES")
            PictureBox2.Visible = False
            TEXTCredit.Enabled = True
            Me.Cursor = Cursors.Default

            If DelRow = False Then
                If BS.Count < RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & RowCount - BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf BS.Count > RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & BS.Count - RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "CABLES")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "CABLES")
            'myds.RejectChanges()
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
                PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                PictureBox2False()
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.RefreshData()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("CABLES")
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
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.CombocustomerName.Focus()
            Me.CombocustomerName.SelectAll()
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Call MangUsers()
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            CLEARDATA1(Me)
            Application.DoEvents()
            Me.BS.CancelEdit()
            Dim n As Double
            Dim F As Double
            n = BS.Count
            Dim s As Integer
            Me.BS.Position = Me.BS.Count - 1
            F = Val(Me.TEXTCurrentBalance.Text)
            s = Val(Me.TEXTID.EditValue)
            BS.EndEdit()
            BS.AddNew()
            CLEARDATA1(Me)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Me.FundBalance()
            Me.MAXRECORD()
            Me.TextMovementSymbol.EditValue = "CA" & Me.TEXTID.EditValue
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.TextDateMovementHistory.Text = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            Me.TEXTType.Text = "نقدا"
            Me.ComboSource.Text = "العملاء"
            Me.TEXTDebit.EditValue = 0
            Me.TEXTCredit.EditValue = 0
            Me.TextCondition.Text = "نقدا"
            Me.TEXTDocumentNumber.Text = Me.TEXTID.EditValue
            Me.TEXTStatement.Text = "حركات العملاء"
            Me.DateMovementHistory.Focus()
            Me.TEXTID.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Dim Sound As System.IO.Stream = My.Resources.addv
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)

    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        'If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockSave = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Count
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.Cursor = Cursors.WaitCursor
        Me.PictureBox2.Visible = True
        Me.SAVERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Insert_Actions(Me.TEXTID.EditValue, "حفظ", Me.Text)
    End Sub
    Private Sub TEXTDebit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTDebit.DoubleClick
        On Error Resume Next
        Me.TEXTDebit.EditValue = Calculator()
    End Sub
    Private Sub TEXTCredit_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTCredit.DoubleClick
        On Error Resume Next
        Me.TEXTCredit.EditValue = Calculator()
    End Sub
    Private Sub TEXTBOX_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TEXTPreviousBalance.TextChanged, TEXTDebit.EditValueChanged, TEXTCredit.EditValueChanged, TEXTCurrentBalance.TextChanged
        On Error Resume Next
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Me.TEXTTotal.Text = Me.TEXTCurrentBalance.Text
        Me.TEXTTotalN.Text = CurrencyJO(Me.TEXTTotal.Text, "jO")
    End Sub
    Private Sub TEXTDebit_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTDebit.KeyPress
        On Error Resume Next
        If (e.KeyChar < "0" Or e.KeyChar > "9") And Asc(e.KeyChar) <> 8 And e.KeyChar <> "." And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub SumAmounFINALBALANCE5()
        On Error Resume Next
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE CAB11 = '" & Me.TextCustomerNumber.EditValue & "'" & "AND CAB6='نقدا'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextFundValue.EditValue = Format(Val(SUM1), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE4()
        On Error Resume Next
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE CAB11 = '" & Me.TextCustomerNumber.EditValue & "'" & "AND CAB6='شيك'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextValueOfCheck.EditValue = Format(Val(SUM1), "0.000")
    End Sub
    Private Sub SumAmounFINALBALANCE5CASHANDCHEQUES()
        On Error Resume Next
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT Sum(CAB4-CAB5) FROM CABLES WHERE CAB11 = '" & Me.TextCustomerNumber.EditValue & "'AND CABLES.IDCAB <'" & Me.TEXTID.EditValue & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        Me.TEXTPreviousBalance.Text = Format(Val(SUM1), "0.000")
        Me.TEXTCurrentBalance.Text = Format(Val(Me.TEXTPreviousBalance.Text) + Val(Me.TEXTDebit.EditValue) - Val(Me.TEXTCredit.EditValue), "0.000")
        Consum.Close()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CombocustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql As New SqlCommand("SELECT IDcust,cust22  FROM AllCustomers WHERE cust2 ='" & Me.CombocustomerName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.TextCustomerType.Text = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextCustomerNumber.EditValue = ""
            Me.TextCustomerType.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        Me.SumAmounFINALBALANCE5CASHANDCHEQUES()
    End Sub
    Private Sub FundBalance()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
        Consum.Close()
    End Sub
    Private Sub RadioButton20_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton18_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton17_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
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
    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
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
        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TEXTTotal.Text)
                TextValueOfCheck.EditValue = 0
            Case "شيك"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text)
            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TEXTTotal.Text) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TEXTTotal.Text) - Val(TextFundValue.EditValue)
        End Select
    End Sub


    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me. AccountsEnquiry()
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
        FundBalance()
        LabelFundBalance.Text = "رصيد" & " " & ModuleGeneral.CB2 & " " & ":"

    End Sub
End Class