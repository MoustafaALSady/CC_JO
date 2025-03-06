Option Explicit Off

Imports System.Data.Common
Imports System.Data.SqlClient
Public Class LoansA
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As New SqlDataAdapter
    Public SqlDataAdapter2 As New SqlDataAdapter
    Public SqlDataAdapter3 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Public SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    Public SqlDataAdapter3 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public ds1 As New DataSet
    Public dt As New DataSet
    Public da As SqlDataAdapter
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    ReadOnly nemcust2, nemcust7 As String
    Dim NO As String
    Dim NO1 As Integer = 0
    Dim ppp As String
<<<<<<< HEAD
    Private Sub LoansA_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub LoansA_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    SAVEBUTTON_Click(sender, e)

                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmDepositsA_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmDepositsA_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.ds1.EnforceConstraints = False
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT lo1, lo, lo2, lo3, lo4, lo5, lo6, lo7, lo8, lo9, lo10,lo11, lo12, lo13, lo14, lo15, lo16, lo17, lo18, lo19, lo20, lo21, lo22, lo23, lo24, lo25, lo26, lo27, lo30, AsUser, Directorate,Recorded ,USERNAME , cuser, coUser, da, ne, da1, ne1 FROM Loans   WHERE   lo='" & Me.TextCostomrNumber.EditValue & "'ORDER BY LO"
        End With
        Dim str2 As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, CUser, COUser, da, ne  FROM LoansPa ", Consum)
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT lo1, lo, lo2, lo3, lo4, lo5, lo6, lo7, lo8, lo9, lo10,lo11, lo12, lo13, lo14, lo15, lo16, lo17, lo18, lo19, lo20, lo21, lo22, lo23, lo24, lo25, lo26, lo27, lo30, AsUser, Directorate,Recorded ,USERNAME , cuser, coUser, da, ne, da1, ne1 FROM Loans   WHERE   lo='" & Me.TextCostomrNumber.EditValue & "'ORDER BY LO"
        End With
        Dim str2 As New SqlClient.SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, CUser, COUser, da, ne  FROM LoansPa ", Consum)
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Me.ds1.Clear()
        SqlDataAdapter1.Fill(Me.ds1, "Loans")
        SqlDataAdapter2.Fill(Me.ds1, "LoansPa")

        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("Loans").Columns("LO"), Me.ds1.Tables("LoansPa").Columns("LO"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "Loans"
        Me.DataGridView1.AutoGenerateColumns = False


        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"


<<<<<<< HEAD
        Dim star As New SqlCommand("SELECT * FROM LoansPa ", Consum)
=======
        Dim star As New SqlClient.SqlCommand("SELECT * FROM LoansPa ", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.da = New SqlDataAdapter(star)

        Me.dt = New DataSet
        Me.da.Fill(Me.dt, "LoansPa")

        Me.ds1.EnforceConstraints = True
        SqlDataAdapter1.Dispose()
        SqlDataAdapter2.Dispose()
        SqlDataAdapter3.Dispose()
        Consum.Close()
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)

        Call MangUsers()
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
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
            ElseIf Me.BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
            Me.TextNetDebt.Text = Format(Val(Me.TextMiligDebt.EditValue) * Val(Me.TextProfitRatio.EditValue) / 100 * Val(Me.ComboNumberOfYears.Text) + Val(Me.TextMiligDebt.EditValue) - Val(Me.TextFirstBatch.EditValue), "0.000")
            Me.TextMonthlyInstallment.Text = Format(Val(Me.TextNetDebt.Text) / (Val(Me.ComboNumberOfYears.Text) * 12), "0.000")
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.save
=======
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            Me.PictureBox5.Visible = False
        End If
    End Sub

    Private Sub MAXRECORD1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim Year As String
        Dim V As Int64
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        'Dim noD As Object = Strings.Mid(CMD.ExecuteScalar(), 7)
        'NO1 = CType(Year, Integer) & String.Concat(New String() {CUser})
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

<<<<<<< HEAD
        Dim SQL As New SqlCommand("SELECT MAX(Lo) FROM Loans  WHERE CUser='" & CUser & "'and Year(LO2) = '" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
=======
        Dim SQL As New SqlClient.SqlCommand("SELECT MAX(Lo) FROM Loans  WHERE CUser='" & CUser & "'and Year(LO2) = '" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt2 As Object = SQL.ExecuteScalar()
        Dim noD As Object = Strings.Mid(SQL.ExecuteScalar(), 7)
        If IsDBNull(resualt2) Then
            Me.TextCostomrNumber.EditValue = CType(NO1, Integer) & 1
        Else
            Me.TextCostomrNumber.EditValue = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
        End If
        Consum.Close()


        'NO2 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        'If IsDBNull(resualt) Then
        '    Me.TextBox39.Text = CType(NO2, Integer) & 1
        'Else
        '    V = String.Concat(New String() {NO2}) & CType(noD, Integer) + 1
        '    Me.TextBox39.Text = V
        'End If
        'Consum.Close()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
    End Sub
<<<<<<< HEAD
    Private Sub LoansA_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub LoansA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.BackgroundImage = img
            Me.TabPage1.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.SHOWBUTTON()
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockAddRow = False Then
                Me.ADDBUTTON.Enabled = False
                Me.SAVEBUTTON.Enabled = False
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

            TestkeyAccounts(keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim strsql As New SqlCommand("select IDcust,cust3,cust7,cust33,CUser from AllCustomers where cust2 = '" & ComboCustomerName.Text & "'", Consum)
<<<<<<< HEAD
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.TextNationalNo.Text = ds.Tables(0).Rows(0).Item(1)
            Me.TextAddress.Text = ds.Tables(0).Rows(0).Item(2)
            Me.CheckMember.Checked = ds.Tables(0).Rows(0).Item(3)
        Else
            Me.TextCustomerNumber.EditValue = ""
            Me.TextNationalNo.Text = ""
            Me.TextAddress.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD
    Private Sub TextBox16_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextFirstBatch.EditValueChanged, TextProfitRatio.EditValueChanged, TextMiligDebt.EditValueChanged, ComboNumberOfYears.TextChanged
=======
    Private Sub TextBox16_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFirstBatch.EditValueChanged, TextProfitRatio.EditValueChanged, TextMiligDebt.EditValueChanged, ComboNumberOfYears.TextChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TextNetDebt.Text = Format(Val(Me.TextMiligDebt.EditValue) * Val(Me.TextProfitRatio.EditValue) / 100 * Val(Me.ComboNumberOfYears.Text) + Val(Me.TextMiligDebt.EditValue) - Val(Me.TextFirstBatch.EditValue), "0.000")
        Me.TextMonthlyInstallment.Text = Format(Val(Me.TextNetDebt.Text) / (Val(Me.ComboNumberOfYears.Text) * 12), "0.000")
        Me.TextTotalDebt.Text = Format(Val(Me.TextMiligDebt.EditValue) * Val(Me.TextProfitRatio.EditValue) / 100 * Val(Me.ComboNumberOfYears.Text) + Val(Me.TextMiligDebt.EditValue), "0.000")
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboNumberOfYears.SelectedIndexChanged
=======
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboNumberOfYears.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TextTotalDebtA.Text = Format(Val(Me.ComboNumberOfYears.Text) * 12)
        Int(Me.TextTotalDebtA)
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox4_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles ComboNumberOfYears.LostFocus
=======
    Private Sub ComboBox4_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboNumberOfYears.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TextTotalDebtA.Text = Format(Val(Me.ComboNumberOfYears.Text) * 12)
        Int(Me.TextTotalDebtA)
    End Sub







<<<<<<< HEAD
    Private Sub TEXTBOX11_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles DateMovementHistory.KeyPress
=======
    Private Sub TEXTBOX11_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles DateMovementHistory.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboCustomerName, e, )
        If Asc(e.KeyChar) = 13 Then
            Me.ComboCustomerName.Focus()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboCustomerName, e, )
        If Asc(e.KeyChar) = 13 Then
            Me.TEXTStatement.Focus()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTStatement.KeyPress
=======
    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TEXTStatement.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            Me.ComboNumberOfYears.Focus()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboNumberOfYears.KeyPress
=======
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboNumberOfYears.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            Me.TextMiligDebt.Focus()
            Me.TextTotalDebtA.Text = Format(Val(Me.ComboNumberOfYears.Text) * 12)
            Int(Me.TextTotalDebtA)
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TextBox12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            Me.TextProfitRatio.Focus()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TextBox13_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            Me.TextFirstBatch.Focus()
        End If
    End Sub
<<<<<<< HEAD
    Private Sub TextCostomrNumber_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextDebtNumber.KeyDown
=======
    Private Sub TextCostomrNumber_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextDebtNumber.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
<<<<<<< HEAD
    Private Sub TextCostomrNumber_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextDebtNumber.LostFocus
=======
    Private Sub TextCostomrNumber_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextDebtNumber.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        On Error Resume Next
        Static P As Integer
        P = Me.BS.Position
        Me.SaveLoans()
        Me.DanLOd()
        Me.BS.Position = P
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        Me.TextDebtNumber.Enabled = False
        Me.DateMovementHistory.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub TextBox39_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub TextBox39_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Asc(e.KeyChar) = 13 Then
            Me.DateMovementHistory.Focus()
        End If
    End Sub

<<<<<<< HEAD
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
=======
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Call MangUsers()
            If LockAddRow = False Then
                Me.SAVEBUTTON.Enabled = False
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.BS.Position = Me.BS.Count - 1
            Me.BS.EndEdit()
            Me.BS.AddNew()
            CLEARDATA1(Me)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)


            GetAutoNumber("Lo", "Loans", "LO2")
            Me.TextCostomrNumber.EditValue = AutoNumber
            Me.TextDebtNumber.Text = AutoNumber
            Me.TextMovementSymbol.EditValue = "LO" & Me.TextCostomrNumber.EditValue
            'Me.TextDebtNumber.Text = Mid(TextCostomrNumber.EditValue, 7, Len(TextCostomrNumber.EditValue))

            Me.TextAssociationName.Text = AssociationName
            Me.TextDirectorateName.Text = Directorate
            Me.TextRegisteredUnderNo.Text = Recorded
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.ComboCustomerName.Text = ""
            Me.ComboNumberOfYears.Text = 1
            Me.TextCustomerNumber.EditValue = ""
            Me.TextNationalNo.Text = ""
            Me.TextAddress.Text = ""
            Me.TEXTStatement.Text = ""
            Me.TextPreviousPayments.Text = 0
            Me.DateMovementHistory.Text = MaxDate.ToString("yyyy-MM-dd")
            Me.TextMiligDebt.EditValue = 0
            Me.TextProfitRatio.EditValue = 0
            Me.TextTotalDebt.Text = 0
            Me.TextMonthlyInstallment.Text = 0
            Me.TextFirstBatch.EditValue = 0
            Me.TextNetDebt.Text = 0
            Me.TextTotalDebtA.Text = 0
            Me.TextTextNetDebtA.Text = 0
            Me.ComboLoanType.Text = "ذمم مدينة للجمعية"
            'Me.TextDebtNumber.Focus()
            Me.ADDBUTTON.Enabled = False
            Me.SAVEBUTTON.Enabled = True
            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
            Else
                TransferToAccounts_Check = False
            End If
<<<<<<< HEAD
            Dim Sound As IO.Stream = My.Resources.addv
=======
            Dim Sound As System.IO.Stream = My.Resources.addv
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

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
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboCustomerName.Text = "" Then
                MsgBox("لا يمكن ترك حقل اسم العميل فارغ", 16, "تنبيه")
                Me.ComboCustomerName.Focus()
                Exit Sub
            End If

            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")

            Static Dim P As Integer
            P = Me.BS.Position
            Me.SaveLoans()
            Me.SaveLoansPa()
            Me.DanLOd()
            Me.BS.Position = P
            Me.SaveLoans()
            Me.UPDATELoans()
            Me.SaveLoansPa()
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
            Me.BS.Position = P + 1
            Me.ButtonXP1_Click(sender, e)
            Insert_Actions(Me.TextDebtNumber.Text.Trim, "حفظ", Me.Text)
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error96", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub SaveLoans()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)

        Dim SQL As New SqlCommand("INSERT INTO Loans (lo1, lo, lo2, lo3, lo4, lo5, lo6, lo7, lo8, lo9, lo10,lo11, lo12, lo13, lo14, lo15, lo16, lo17, lo18, lo19, lo30, AsUser ,USERNAME , cuser, coUser, Directorate,Recorded, da, ne) VALUES     (@lo1,@lo,@lo2,@lo3,@lo4,@lo5,@lo6,@lo7,@lo8,@lo9,@lo10,@lo11,@lo12,@lo13,@lo14,@lo15,@lo16,@lo17,@lo18,@lo19,@lo30, @AsUser, @USERNAME, @cuser, @coUser, @Directorate, @Recorded, @da, @ne)", Consum)
        Dim CMD As New SqlCommand
=======
        Dim Consum As New SqlClient.SqlConnection(constring)

        Dim SQL As New SqlClient.SqlCommand("INSERT INTO Loans (lo1, lo, lo2, lo3, lo4, lo5, lo6, lo7, lo8, lo9, lo10,lo11, lo12, lo13, lo14, lo15, lo16, lo17, lo18, lo19, lo30, AsUser ,USERNAME , cuser, coUser, Directorate,Recorded, da, ne) VALUES     (@lo1,@lo,@lo2,@lo3,@lo4,@lo5,@lo6,@lo7,@lo8,@lo9,@lo10,@lo11,@lo12,@lo13,@lo14,@lo15,@lo16,@lo17,@lo18,@lo19,@lo30, @AsUser, @USERNAME, @cuser, @coUser, @Directorate, @Recorded, @da, @ne)", Consum)
        Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@lo1", SqlDbType.BigInt).Value = Me.TextDebtNumber.Text
            .Parameters.Add("@lo", SqlDbType.BigInt).Value = Me.TextCostomrNumber.EditValue
            .Parameters.Add("@lo2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
            .Parameters.Add("@lo3", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
            .Parameters.Add("@lo4", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
            .Parameters.Add("@lo5", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
            .Parameters.Add("@lo6", SqlDbType.NVarChar).Value = Me.TextNationalNo.Text
            .Parameters.Add("@lo7", SqlDbType.NVarChar).Value = Me.TextAddress.Text
            .Parameters.Add("@lo8", SqlDbType.Float).Value = Me.TextMiligDebt.EditValue
            .Parameters.Add("@lo9", SqlDbType.Float).Value = Me.TextProfitRatio.EditValue
            .Parameters.Add("@lo10", SqlDbType.NVarChar).Value = Me.ComboNumberOfYears.Text
            .Parameters.Add("@lo11", SqlDbType.Float).Value = Me.TextFirstBatch.EditValue
            .Parameters.Add("@lo12", SqlDbType.Float).Value = Me.TextTotalDebt.Text
            .Parameters.Add("@lo13", SqlDbType.Float).Value = Me.TextMonthlyInstallment.Text
            .Parameters.Add("@lo14", SqlDbType.Float).Value = Me.TextNetDebt.Text
            .Parameters.Add("@lo15", SqlDbType.Int).Value = Me.TextTotalDebtA.Text
            .Parameters.Add("@lo16", SqlDbType.Bit).Value = False
            .Parameters.Add("@lo17", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
            .Parameters.Add("@lo18", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
            .Parameters.Add("@lo19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckMember.Checked)
            .Parameters.Add("@lo30", SqlDbType.NVarChar).Value = Me.ComboLoanType.Text
            .Parameters.Add("@AsUser", SqlDbType.NVarChar).Value = AssociationName
            .Parameters.Add("@Directorate", SqlDbType.NVarChar).Value = Directorate
            .Parameters.Add("@Recorded", SqlDbType.NVarChar).Value = Recorded
            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
            .Parameters.Add("@cuser", SqlDbType.Int).Value = CUser
            .Parameters.Add("@coUser", SqlDbType.NVarChar).Value = COUser
            .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
            .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        CMD.ExecuteNonQuery()
        Consum.Close()
    End Sub
    Private Sub SaveLoansPa()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim PA As String = "PA" & "/" & TextDebtNumber.Text
        For x As Integer = 0 To Me.DataGridView1.RowCount - 2
            Dim SQL As New SqlCommand("INSERT INTO LoansPa(Lo, Loa2, Loa3,Loa7, Loa8, Loa9, Loa10, Loa11, Loa25) VALUES     (@Lo, @Loa, @Loa2, @Loa3, @Loa7, @Loa8, @Loa9, @Loa10, @Loa11, @Loa25)", Consum)
            Dim CMD As New SqlCommand
            With CMD.Parameters
                .AddWithValue("@Lo", Me.TextCostomrNumber.EditValue)
                .AddWithValue("@Loa", Me.DataGridView2.Rows(x).Cells(0).Value)
                .AddWithValue("@Loa2", Me.DataGridView2.Rows(x).Cells("dat1").Value)
                .AddWithValue("@Loa3", "لم يتم التسديد")
                .AddWithValue("@Loa7", Me.DataGridView2.Rows(x).Cells(1).Value)
                .AddWithValue("@Loa8", Me.TextNetDebt.Text)
                .AddWithValue("@Loa9", Me.TextNetDebt.Text)
                .AddWithValue("@Loa10", Me.TextCustomerNumber.EditValue)
                .AddWithValue("@Loa11", Me.ComboCustomerName.Text)
                .AddWithValue("@Loa25", PA.ToString & "/" & Me.DataGridView2.Rows(x).Cells(0).Value)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim PA As String = "PA" & "/" & TextDebtNumber.Text
        For x As Integer = 0 To Me.DataGridView1.RowCount - 2
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO LoansPa(Loa, Loa2, Loa3,Loa7, Loa8, Loa9, Loa10, Loa11, Loa25) VALUES     (@Loa, @Loa2, @Loa3, @Loa7, @Loa8, @Loa9, @Loa10, @Loa11, @Loa25)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD.Parameters
                .AddWithValue("@Lo", Me.TextCostomrNumber.EditValue).DbType = DbType.String
                .AddWithValue("@Loa", Me.DataGridView2.Rows(x).Cells(0).Value).DbType = DbType.String
                .AddWithValue("@Loa2", Me.DataGridView2.Rows(x).Cells("dat1").Value).DbType = DbType.String
                .AddWithValue("@Loa3", "لم يتم التسديد").DbType = DbType.String
                .AddWithValue("@Loa7", Me.DataGridView2.Rows(x).Cells(1).Value).DbType = DbType.String
                .AddWithValue("@Loa8", Me.TextNetDebt.Text).DbType = DbType.String
                .AddWithValue("@Loa9", Me.TextNetDebt.Text).DbType = DbType.String
                .AddWithValue("@Loa10", Me.TextCustomerNumber.EditValue).DbType = DbType.String
                .AddWithValue("@Loa11", Me.ComboCustomerName.Text).DbType = DbType.String
                .AddWithValue("@Loa25", PA.ToString & "/" & Me.DataGridView2.Rows(x).Cells(0).Value).DbType = DbType.String
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            SqlDataAdapter2.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table", "LoansPa", New DataColumnMapping() {New DataColumnMapping("Loa1", "Loa1"), New DataColumnMapping("Loa", "Loa"), New DataColumnMapping("Loa2", "Loa2"), New DataColumnMapping("Loa3", "Loa3"), New DataColumnMapping("Loa4", "Loa4"), New DataColumnMapping("Loa5", "Loa5"), New DataColumnMapping("Loa6", "Loa6"), New DataColumnMapping("Loa7", "Loa7"), New DataColumnMapping("Loa8", "Loa8"), New DataColumnMapping("Lo1", "Lo1")})})
            SqlDataAdapter2.InsertCommand = CMD
            SqlDataAdapter2.Update(ds1, "LoansPa")
            Consum.Close()
        Next
    End Sub
    Private Sub UPDATELoans()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  Loans SET   lo2 = @lo2, lo3 = @lo3, lo4 = @lo4, lo5 = @lo5, lo6 = @lo6, lo7 = @lo7, lo8 = @lo8, lo9 = @lo9, lo10 = @lo10, lo11 = @lo11, lo12 = @lo12, lo13 = @lo13, lo14 = @lo14, lo15 = @lo15, lo16 = @lo16, lo17 = @lo17, lo18 = @lo18, lo19 = @lo19, lo30 = @lo30, AsUser = @AsUser, USERNAME = @USERNAME, cuser = @cuser, couser = @couser, Directorate = @Directorate, Recorded = @Recorded, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE lo1 = @lo1", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  Loans SET   lo2 = @lo2, lo3 = @lo3, lo4 = @lo4, lo5 = @lo5, lo6 = @lo6, lo7 = @lo7, lo8 = @lo8, lo9 = @lo9, lo10 = @lo10, lo11 = @lo11, lo12 = @lo12, lo13 = @lo13, lo14 = @lo14, lo15 = @lo15, lo16 = @lo16, lo17 = @lo17, lo18 = @lo18, lo19 = @lo19, lo30 = @lo30, AsUser = @AsUser, USERNAME = @USERNAME, cuser = @cuser, couser = @couser, Directorate = @Directorate, Recorded = @Recorded, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE lo1 = @lo1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
<<<<<<< HEAD
                .Parameters.Add("@lo1", SqlDbType.BigInt).Value = Me.TextDebtNumber.Text
=======
                .Parameters.Add("@lo1", SqlDbType.Int).Value = Me.TextDebtNumber.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .Parameters.Add("@lo2", SqlDbType.Date).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@lo3", SqlDbType.NVarChar).Value = Me.TEXTStatement.Text
                .Parameters.Add("@lo4", SqlDbType.NVarChar).Value = Me.TextCustomerNumber.EditValue
                .Parameters.Add("@lo5", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                .Parameters.Add("@lo6", SqlDbType.NVarChar).Value = Me.TextNationalNo.Text
                .Parameters.Add("@lo7", SqlDbType.NVarChar).Value = Me.TextAddress.Text
                .Parameters.Add("@lo8", SqlDbType.Float).Value = Val(Me.TextMiligDebt.EditValue)
                .Parameters.Add("@lo9", SqlDbType.Float).Value = Val(Me.TextProfitRatio.EditValue)
                .Parameters.Add("@lo10", SqlDbType.NVarChar).Value = Me.ComboNumberOfYears.Text
                .Parameters.Add("@lo11", SqlDbType.Float).Value = Val(Me.TextFirstBatch.EditValue)
                .Parameters.Add("@lo12", SqlDbType.Float).Value = Val(Me.TextTotalDebt.Text)
                .Parameters.Add("@lo13", SqlDbType.Float).Value = Val(Me.TextMonthlyInstallment.Text)
                .Parameters.Add("@lo14", SqlDbType.Float).Value = Val(Me.TextNetDebt.Text)
                .Parameters.Add("@lo15", SqlDbType.Int).Value = Val(Me.TextTotalDebtA.Text)
                .Parameters.Add("@lo16", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@lo17", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@lo18", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@lo19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckMember.Checked)
                .Parameters.Add("@lo30", SqlDbType.NVarChar).Value = Me.ComboLoanType.Text

                .Parameters.Add("@AsUser", SqlDbType.NVarChar).Value = AssociationName
                .Parameters.Add("@Directorate", SqlDbType.NVarChar).Value = Directorate
                .Parameters.Add("@Recorded", SqlDbType.NVarChar).Value = Recorded
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@coUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .Parameters.Add("@da1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne1", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL.CommandText
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub UPDATELoansPa()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    If Not System.Convert.IsDBNull(Me.DataGridView1("Loa6", i).Value) Then
                        If Me.DataGridView1.Rows(i).Cells("Loa6").Value = Me.TextMonthlyInstallment.Text.Trim Then
                            ppp = "تم التسديد"
                        ElseIf Me.DataGridView1.Rows(i).Cells("Loa6").Value < Me.TextMonthlyInstallment.Text.Trim Then
                            ppp = "لم يسدد كامل الاقسط"
                        ElseIf Me.DataGridView1.Rows(i).Cells("Loa6").Value = "" Then
                            ppp = "لم يتم التسديد"
                        End If
                        Dim PA As String = "PA" & "/" & TextDebtNumber.Text
<<<<<<< HEAD
                        Dim SQL As New SqlCommand(" UPDATE LoansPa SET  Loa = @Loa, Loa2 = @Loa2, Loa3 = @Loa3, Loa6 = @Loa6, Loa7 = @Loa7, Loa8 = @Loa8, Loa9 = @Loa9, Loa10 = @Loa10, Loa11 = @Loa11, Lo25 = @Lo25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE Loa1 = '" & Me.DataGridView1.Rows(i).Cells("Loa1").Value & "'", Consum)
                        Dim CMD As New SqlCommand With {
=======
                        Dim SQL As New SqlCommand(" UPDATE LoansPa SET Lo = @Lo, Loa = @Loa, Loa2 = @Loa2, Loa3 = @Loa3, Loa6 = @Loa6, Loa7 = @Loa7, Loa8 = @Loa8, Loa9 = @Loa9, Loa10 = @Loa10, Loa11 = @Loa11, Lo25 = @Lo25, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE Loa1 = '" & Me.DataGridView1.Rows(i).Cells("Loa1").Value & "'", Consum)
                        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            .CommandType = CommandType.Text,
                            .Connection = Consum
                        }
                        With CMD
                            .CommandType = CommandType.Text
                            .Connection = Consum
<<<<<<< HEAD
                            '.Parameters.Add("@Lo", SqlDbType.BigInt).Value = Me.TextCostomrNumber.EditValue
=======
                            .Parameters.Add("@Lo", SqlDbType.BigInt).Value = Me.TextCostomrNumber.EditValue
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            .Parameters.Add("@Loa", SqlDbType.Int).Value = Me.DataGridView1.Rows(i).Cells(0).Value
                            .Parameters.Add("@Loa2", SqlDbType.Date).Value = Me.DataGridView1.Rows(i).Cells("Loa2").Value
                            .Parameters.Add("@Loa3", SqlDbType.NVarChar).Value = ppp.Trim.ToLower
                            .Parameters.Add("@Loa6", SqlDbType.Float).Value = "0.00"
                            .Parameters.Add("@Loa7", SqlDbType.Float).Value = Me.TextMonthlyInstallment.Text
                            .Parameters.Add("@Loa8", SqlDbType.Float).Value = Me.TextNetDebt.Text
                            .Parameters.Add("@Loa9", SqlDbType.Float).Value = Me.TextNetDebt.Text
<<<<<<< HEAD
                            .Parameters.Add("@Loa10", SqlDbType.BigInt).Value = Me.TextCustomerNumber.EditValue
=======
                            .Parameters.Add("@Loa10", SqlDbType.Int).Value = Me.TextCustomerNumber.EditValue
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            .Parameters.Add("@Loa11", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                            .Parameters.Add("@Lo25", SqlDbType.NVarChar).Value = PA.ToString & "/" & Me.DataGridView1.Rows(i).Cells(0).Value
                            .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                            .Parameters.Add("@CUser", SqlDbType.Int).Value = CUser
                            .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                            .CommandText = SQL.CommandText
                        End With
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        CMD.ExecuteNonQuery()
                        CMD.Parameters.Clear()
                        Consum.Close()
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error100", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
=======
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية التعديل على السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT Lo  FROM LoansPa  WHERE Lo='" & Convert.ToInt64(Me.DataGridView1.Rows(0).Cells(1).Value) & "'", Consum)
            Dim CMD As New SqlCommand
            Dim ds5 As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlClient.SqlCommand("SELECT *  FROM LoansPa  WHERE Lo='" & Me.DataGridView1.Rows(0).Cells(1).Value & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand
            Dim ds5 As New DataSet
            Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds5.Clear()
            Adp1.Fill(ds5, "LoansPa")
            If ds5.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("تم تسجيل بيانات الاقساط سابقاً", "تكرار الاقساط", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Me.UPDATELoansPa()
                Me.ButtonXP1.Enabled = False
                Exit Sub
            Else
                Dim counter As Integer = Integer.Parse(Me.TextTotalDebtA.Text)
                Dim day = DateMovementHistory.Value.Day
                Dim month As Integer = Me.DateMovementHistory.Value.Month
                Dim year As Integer = Me.DateMovementHistory.Value.Year
<<<<<<< HEAD
                Dim ID As Int64 = Me.TextCustomerNumber.EditValue
=======
                Dim ID As Integer = Me.TextCustomerNumber.EditValue
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim n As String = Me.ComboCustomerName.Text
                Dim B As String = Me.TextNetDebt.Text
                Dim p As String = "لم يتم التسديد"
                Dim p1 As String = "تم التسديد مجموع دفعات سابقة"
<<<<<<< HEAD
                Dim a As Int64 = Convert.ToInt64(Me.TextDebtNumber.Text)
=======
                Dim a As Integer = Me.TextDebtNumber.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim s = ""
                Dim PA As String = "PA" & "/" & Me.TextCostomrNumber.EditValue


                Dim Residual1 As Double = 0
                Dim Remaind As Double = Val(Me.TextNetDebt.Text) - Val(Me.TextPreviousPayments.Text)
                Me.TextTotalDebtA.Text = GetNoOfInstallments(Val(Remaind - 1), Val(Me.TextMonthlyInstallment.Text))
                Dim PaidPremiums As Double = Val(Me.TextTotalDebtA.Text) * Val(Me.TextMonthlyInstallment.Text)
                Residual1 = Val(Remaind) - Val(PaidPremiums)
                Remainder = GetRemainder(Val(Remaind), Val(Me.TextTotalDebtA.Text))
                If day <= 25 Then
                    counter -= 1
                End If
                If Remainder > 0 Then
                    'Me.TextBox27.Text = Val(Me.TextBox27.Text) + 1
                End If

                If Val(Residual1) < 0 Then
                    Residual1 = Val(Me.TextMonthlyInstallment.Text) + Val(Residual1)
                    Me.TextTotalDebtA.Text = Val(Me.TextTotalDebtA.Text) - 1
                End If

                If Me.TextPreviousPayments.Text > 0 Then
                    Me.DataGridView2.Rows.Add(0, 0, month.ToString + "-" + year.ToString, p1.Trim.ToLower, Me.TextCostomrNumber.EditValue, Val(Me.TextPreviousPayments.Text), Val(Remaind), Me.TextCostomrNumber.EditValue, True)
                End If
                For I As Integer = 1 To Val(Me.TextTotalDebtA.Text)
                    Me.DataGridView2.Rows.Add(I, Me.TextMonthlyInstallment.Text, month.ToString + "-" + year.ToString, p.Trim.ToLower, Me.TextCostomrNumber.EditValue, "0.00", Val(Remaind), Me.TextCostomrNumber.EditValue, False)
                    month += 1
                    If month > 12 Then
                        month = 1
                        year += 1
                    End If
                Next
                month += 1
                If month > 12 Then
                    month = 1
                    year += 1
                End If
                Me.DataGridView2.Rows.Add(Val(Me.TextTotalDebtA.Text) + 1, Val(Residual1), month.ToString + "-" + year.ToString, p.Trim.ToLower, Me.TextCostomrNumber.EditValue, "0.00", Val(Remaind), Me.TextCostomrNumber.EditValue, False)

                Me.DanLOd()
                Dim x
                For x = 0 To Me.DataGridView2.Rows.Count - 2
                    Dim row As DataGridViewRow = DataGridView2.Rows(x)
                    If row.IsNewRow Then Continue For
                    Dim dr As DataRow = dt.Tables("LoansPa").NewRow
                    dr.Item("Loa") = Me.DataGridView2.Rows(x).Cells("InstallmentID").Value
<<<<<<< HEAD
                    dr.Item("Lo") = Convert.ToInt64(Me.DataGridView2.Rows(x).Cells("ID").Value)
=======
                    dr.Item("Lo") = Me.DataGridView2.Rows(x).Cells("ID").Value
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    dr.Item("Loa2") = Me.DataGridView2.Rows(x).Cells("dat1").Value
                    dr.Item("Loa3") = Me.DataGridView2.Rows(x).Cells("p").Value
                    dr.Item("Loa4") = Me.DataGridView2.Rows(x).Cells("loa04").Value
                    dr.Item("Loa6") = Me.DataGridView2.Rows(x).Cells("loa06").Value
                    dr.Item("Loa7") = Me.DataGridView2.Rows(x).Cells("InstallmentValue").Value
                    dr.Item("Loa8") = Me.DataGridView2.Rows(x).Cells("Remaind1").Value
                    dr.Item("Loa9") = B.Trim
<<<<<<< HEAD
                    dr.Item("Loa10") = Convert.ToInt64(ID)
=======
                    dr.Item("Loa10") = ID.ToString
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    dr.Item("Loa11") = n.Trim

                    dr.Item("Loa14") = Me.DataGridView2.Rows(x).Cells("loa14").Value
                    If Me.CheckMember.Checked = True Then
                        dr.Item("Loa15") = True
                    Else
                        dr.Item("Loa15") = False
                    End If
                    dr.Item("Loa16") = False
                    dr.Item("Lo25") = PA.Trim.ToLower & "/" & Me.DataGridView2.Rows(x).Cells(0).Value
                    dr.Item("USERNAME") = USERNAME
                    dr.Item("CUser") = CUser
                    dr.Item("COUser") = COUser
                    dt.Tables("LoansPa").Rows.Add(dr)
                    builder67 = New SqlCommandBuilder(da)
                    da.Update(dt, "LoansPa")
                    Me.DataGridView1.Refresh()
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Next
                Me.DataGridView2.Rows.Clear()
                Me.UPDATELoans()
                Me.UPDATELoansPa()
                Me.DanLOd()
                Me.DataGridView1.Refresh()
            End If
            Adp1.Dispose()
            Consum.Close()
<<<<<<< HEAD
            Insert_Actions(Me.TextDebtNumber.Text, "تقسيم دفعات العميل " & " " & Me.ComboCustomerName.Text, Me.Text)
=======
            Insert_Actions(Me.TextDebtNumber.Text.Trim, "تقسيم دفعات العميل " & " " & Me.ComboCustomerName.Text, Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error101", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            Consum.Close()
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
=======
    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If DataGridView1.Item(e.ColumnIndex, e.RowIndex).EditedFormattedValue <> Nothing Then
            Dim v As Integer = DataGridView1.Item(0, e.RowIndex).EditedFormattedValue
            For Each row As DataGridViewRow In DataGridView1.Rows
                If Not row.IsNewRow And Not row.Cells(e.ColumnIndex).Selected Then
                    If row.Cells(e.ColumnIndex).RowIndex <> e.RowIndex Then
                        If row.Cells(0).Value <> Nothing Then
                            If row.Cells(0).Value = v Then
                                MsgBox("المعلومة التي تم إدخالها مكررة, المرجو تحديد واحدة أخرى...")
                                e.Cancel = True
                                Return
                            End If
                        End If
                    End If
                End If
            Next
        End If
    End Sub
#Region "   Functions   "
    Shared Function GetNoOfInstallments(ByVal Total As Double, ByVal InstallmentValue As Double) As Double
        Return Math.Round(Total / InstallmentValue)
    End Function

    Shared Function GetRemainder(ByVal Total As Double, ByVal NoOfInstallments As Integer) As Double
        Return Math.IEEERemainder(Total, NoOfInstallments)
    End Function
#End Region


<<<<<<< HEAD
    Private Sub Pp1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextPreviousPayments.LostFocus
=======
    Private Sub Pp1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextPreviousPayments.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Val(Me.TextPreviousPayments.Text) >= Val(Me.TextNetDebt.Text) Then
            MsgBox("لا يمكن ان يكون مجموع الدفعات السابقة اكبر او يساوي  صافي الدين")
            Me.SAVEBUTTON.Enabled = False
            Me.TextPreviousPayments.Focus()
            Exit Sub
        Else
            Me.SAVEBUTTON.Enabled = True
        End If
    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboCB1.SelectedIndexChanged

<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
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
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        FundBalance()
        LabelFundBalance.Text = "رصيد" & " " & ModuleGeneral.CB2 & " " & ":"
    End Sub


    Private Sub TransforAccounts()
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing

        nem = "عقد المبيعات الاجلة رقم" & "_" & Me.TextDebtNumber.Text
        nem1 = "سداد الدفعة الاولى من عقد المبيعات الاجلة رقم " & "_" & Me.TextDebtNumber.Text
        PMO2 = 1

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_no = FundAccount_No
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam

        DebitAccount_No = keyAccounts.GetValue("ReceivablesAccount_No", ReceivablesAccount_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
        DebitAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
        DebitAccount_Cod = ID_Nam


        CredAccount_NO = 42002
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
        CredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
        CredAccount_Cod = ID_Nam





        SEARCHDATA.MAXIDMOVES()
        TransferToAccounts_Check = True

        Dim x As Double = Val(Me.TextTotalDebt.Text) - (Val(Me.TextPreviousPayments.Text) + Val(Me.TextFirstBatch.Text))

<<<<<<< HEAD
=======

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TextNetDebt.Text, TextNetDebt.Text, T3, "قيد", "LO", TextMovementSymbol.EditValue, False)

        If OBCHK2 = True Then
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(x), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, Val(x), nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
        Else
            If Me.TextFirstBatch.EditValue = 0 Then
                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(x), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, Accounts_no, 0, Val(x), nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
            Else
<<<<<<< HEAD
                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextNetDebt.Text, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2, Accounts_NO, TextFirstBatch.EditValue, 0, nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
=======
                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextNetDebt.Text, 0, nem1, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2, Accounts_NO, TextFirstBatch.EditValue, 0, nem, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                DetailsAccountingEntries(PMO2 + 2, CredAccount_Name, CredAccount_NO, 0, TextTotalDebt.Text, nem, CredAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)

                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.EditValue, TextFirstBatch.EditValue, 0, Me.Text,
                                             " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TextDebtNumber.Text & "0",
                                             False, True, ComboCB1.Text, ModuleGeneral.CB2)

            End If
        End If
    End Sub

<<<<<<< HEAD
=======
    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Private Sub FundBalance()
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




End Class