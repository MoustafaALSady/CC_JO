Option Explicit Off
Imports System.Data.SqlClient

Public Class Loans1
    Public xx As Integer = 0
    ReadOnly InvDataset As New DataSet, Flt As String
    Dim adp As New SqlDataAdapter
    Public WithEvents BS As New BindingSource
    Dim nem, nem1, nem2, nem3, nem4, nem5 As String
    Dim pp As Integer
    Dim tota1 As Double
    ReadOnly tota2 As Double
    Dim xx1 As Double = 0
    Dim xx2 As Double = 0
    Dim xx3 As Double = 0
    Dim xx4 As Double = 0
    Dim xx5 As Double = 0
    Dim xxk1 As Double = 0
    Dim xxk2 As Double = 0
    Dim xxk3 As Double = 0
    Dim xxk4 As Double = 0
    Dim xxk5 As Double = 0
    Dim xxk7 As Double = 0
    ReadOnly sumk As Double = 0
    Dim test As Integer
    Dim test1 As Integer
    Dim test2 As Integer
    Dim PremiumsK As Integer
    Dim ppp As String
    Dim te1 As String

    Private Sub Loans1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Timer1.Enabled = False
    End Sub
    Private Sub Premiums()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("select Loa7  from LoansPa  WHERE  CUser='" & CUser & "' and Loa2<='" & ServerDateTime.ToString("yyyy-MM-dd") & "' and Loa6='" & 0 & "'and Loa15='" & True & "'ORDER BY Lo", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Consum.Open()
        Adp1.Fill(ds2, "PTRANSACTION")
        Consum.Close()
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.PremiumsK = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.PremiumsK = ""
        End If
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ButtonTransferOfInstallmentsReceived.Enabled = LockAddRow
        Me.ButtonTransferOfInstallmentsReceived.Enabled = LockSave
    End Sub
    Private Sub Loans1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Call Premiums()
        Me.Label1.Text = CUser
        Dim N As Integer
        Dim firstDate As String, days As Integer
        Dim secondDate As Date
        Me.DataGridView1.Rows.Clear()
        N = 1
        Dim ds As DataSet
        ds = New DataSet
        DataGridView1.Rows.Clear()
        Dim Consum As New SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "select Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, CUser, COUser, da, ne  from LoansPa  WHERE  CUser='" & CUser & "' and Loa2<='" & ServerDateTime.ToString("yyyy-MM-dd") & "' and Loa6<'" & PremiumsK & "'and Loa15='" & True & "'ORDER BY Lo"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        adp = New SqlDataAdapter(strSQL)
        Dim oCommandBuilder As New SqlCommandBuilder(adp)
        adp.Fill(ds, "LoansPa")
        If Me.BindingContext(ds, "LoansPa").Count = 0 Then
            MsgBox("لا يوجد بيانات لعرضها", 64 + 524288, "عرض البيانات")
            Me.ButtonTransferOfInstallmentsReceived.Enabled = False
            Exit Sub
        End If
        For I As Integer = 0 To ds.Tables("LoansPa").Rows.Count - 1
            firstDate = ds.Tables("LoansPa").Rows(I).Item("Loa2")
            secondDate = CDate(firstDate)
            days = DateDiff(DateInterval.Day, ServerDateTime, secondDate)
            If days <= 31 Then
                If days <= 10 Then
                    Me.DataGridView1.Columns(4).CellTemplate.Style.BackColor = Color.DarkRed
                    Me.DataGridView1.Columns(4).CellTemplate.Style.ForeColor = Color.Yellow
                End If
                If days > 10 AndAlso days <= 20 Then
                    Me.DataGridView1.Columns(4).CellTemplate.Style.BackColor = Color.HotPink
                    Me.DataGridView1.Columns(4).CellTemplate.Style.ForeColor = Color.DarkBlue
                    Me.DataGridView1.Columns(2).CellTemplate.Style.ForeColor = Color.Red
                End If
                If days > 20 Then
                    Me.DataGridView1.Columns(4).CellTemplate.Style.BackColor = Color.Pink
                    Me.DataGridView1.Columns(4).CellTemplate.Style.ForeColor = Color.DarkBlue
                    Me.DataGridView1.Columns(2).CellTemplate.Style.ForeColor = Color.DarkBlue
                End If
                Dim str As String() = {N, ds.Tables("LoansPa").Rows(I).Item("Lo"), _
                ds.Tables("LoansPa").Rows(I).Item("Loa10"), ds.Tables("LoansPa").Rows(I).Item("Loa11"), _
                ds.Tables("LoansPa").Rows(I).Item("Loa3"), ds.Tables("LoansPa").Rows(I).Item("Loa2"), CDbl(ds.Tables("LoansPa").Rows(I).Item("Loa7") - ds.Tables("LoansPa").Rows(I).Item("Loa6")), ds.Tables("LoansPa").Rows(I).Item("Loa8"), days, ds.Tables("LoansPa").Rows(I).Item("Lo25"), ds.Tables("LoansPa").Rows(I).Item("Loa1")}
                Me.DataGridView1.Rows.Add(str)
                N += 1
            End If
        Next
        Me.Blinking()
        Me.TextBox8.Text = "0.00"
        Consum.Close()
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown1.Value, Me.ComboBox1)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown2.Value, Me.ComboBox2)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown3.Value, Me.ComboBox3)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown4.Value, Me.ComboBox4)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown5.Value, Me.ComboBox5)
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NumericUpDown6.Value, Me.ComboBox6)
        Me.SHOWBUTTON()
    End Sub
    Private Sub Blinking()
        Dim I As Integer
        For I = 0 To Me.DataGridView1.Rows.Count - 1
            Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)
            Dim Days As DataGridViewTextBoxCell = row.Cells("days1")
            If Days.Value <= 10 Then
                Timer1.Enabled = True
                Timer1.Interval = 1
            End If
        Next
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick

        If xx >= 1 And xx <= 20 Then
            For I As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)
                Dim Days As DataGridViewTextBoxCell = row.Cells("days1")
                If Days.Value <= 10 Then
                    row.Cells(2).Style.ForeColor = Color.Yellow
                    row.Cells(2).Style.BackColor = Color.Red
                    row.Cells(5).Style.BackColor = Color.Yellow
                End If
            Next
            If xx = 1 Then
                My.Computer.Audio.PlaySystemSound( _
                                       System.Media.SystemSounds.Exclamation)
            End If
        End If
        If xx >= 21 And xx <= 50 Then
            For I As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Dim row As DataGridViewRow = Me.DataGridView1.Rows(I)
                Dim Days As DataGridViewTextBoxCell = row.Cells("days1")
                If Days.Value <= 10 Then
                    row.Cells(2).Style.ForeColor = Color.Red
                    row.Cells(2).Style.BackColor = Color.Yellow
                    row.Cells(5).Style.BackColor = Color.Red
                End If
            Next
            If xx = 22 Then
                My.Computer.Audio.PlaySystemSound( _
                  System.Media.SystemSounds.Exclamation)
            End If
        End If
        If xx >= 50 Then
            xx = 1
        End If
        xx += 1
    End Sub
    Private Sub ToolStripButton2_Click_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles ToolStripButton2.Click
        Me.Timer1.Stop()
        Me.Close()
    End Sub
    Public rec As DataRow


    Private Sub SEARCHDATAITEMS10()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK6 FROM PTRANSACTION WHERE TBNK23 = '" & Val(Me.DataGridView1.Item("Loa10", Me.DataGridView1.CurrentRow.Index).Value()) & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds2, "PTRANSACTION")
        Consum.Close()

        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TEXTBOX6.Text = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TEXTBOX6.Text = ""
        End If
    End Sub
    Private Sub SEARCHDATAITEMS1()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK6 FROM PTRANSACTION WHERE TBNK23 = '" & Val(Me.DataGridView3.Item("LOK2", Me.DataGridView3.CurrentRow.Index).Value()) & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds2, "PTRANSACTION")
        Consum.Close()

        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextBox19.Text = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextBox19.Text = ""
        End If
    End Sub
    Private Sub PtransactionEnquiry()
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT DISTINCT TBNK6,TBNK8 ,TBNK22 ,TBNK23 FROM PTRANSACTION WHERE  TBNK23 ='" & Val(Me.DataGridView1.Item("Loa10", Me.DataGridView1.CurrentRow.Index).Value()) & "'"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim Adp1 As New SqlDataAdapter(str1)
            On Error Resume Next
            ds.Clear()
            Adp1.Fill(ds, "PTRANSACTION")
            Adp1.Fill(dt)
            Consum.Close()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "PTRANSACTION"


        End With
    End Sub
    Private Sub FundBalance()
        Me.InternalAuditorBalance1()
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT DISTINCT LOK2 ,LOK3,TBNK7 ,LOK FROM LoansK WHERE  LOK ='" & Val(DataGridView1.Item("Lo", Me.DataGridView1.CurrentRow.Index).Value()) & "'" & " AND TBNK7> '" & 0 & "'"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim Adp1 As New SqlDataAdapter(str1)
            On Error Resume Next
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp1.Fill(ds, "LoansK")
            Adp1.Fill(dt)
            Consum.Close()
            DataGridView3.DataSource = ds
            DataGridView3.DataMember = "LoansK"
        End With
    End Sub
    Private Sub SEARCHDATAITEMS13()
        Dim Consum As New SqlConnection(constring)
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT DISTINCT TBNK6,TBNK8 ,TBNK22 ,TBNK23 FROM PTRANSACTION WHERE  TBNK23 ='" & Val(DataGridView3.Item("LOK2", DataGridView3.CurrentRow.Index).Value()) & "'"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim ds As New DataSet
            Dim dt As New DataTable
            Dim Adp1 As New SqlDataAdapter(str1)
            On Error Resume Next
            ds.Clear()
            Adp1.Fill(ds, "PTRANSACTION")
            Adp1.Fill(dt)
            Consum.Close()
            DataGridView2.Rows.Clear()
            DataGridView2.DataSource = ds
            DataGridView2.DataMember = "PTRANSACTION"
        End With
    End Sub
    Private Sub InternalAuditorBalance()
        Dim Adp1 As SqlDataAdapter
        Dim Adp2 As SqlDataAdapter
        Dim Adp3 As SqlDataAdapter
        Dim Adp4 As SqlDataAdapter
        Dim Adp5 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1, SUM2, SUM3, SUM4, SUM5 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TEXTBOX6.Text & "'" & "AND TBNK8='امانات'", Consum)
        Dim strsq2 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TEXTBOX6.Text & "'" & "AND TBNK8='توفير'", Consum)
        Dim strsq3 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TEXTBOX6.Text & "'" & "AND TBNK8='الودائع'", Consum)
        Dim strsq4 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TEXTBOX6.Text & "'" & "AND TBNK8='شهادة إدخار'", Consum)
        Dim strsq5 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TEXTBOX6.Text & "'" & "AND TBNK8='الاسهم'", Consum)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim ds4 As New DataSet
        Dim ds5 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        Adp2 = New SqlDataAdapter(strsq2)
        Adp3 = New SqlDataAdapter(strsq3)
        Adp4 = New SqlDataAdapter(strsq4)
        Adp5 = New SqlDataAdapter(strsq5)
        ds1.Clear()
        ds2.Clear()
        ds3.Clear()
        ds4.Clear()
        ds5.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp2.Fill(ds2)
        Adp3.Fill(ds3)
        Adp4.Fill(ds4)
        Adp5.Fill(ds5)
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(1)) - Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        If ds2.Tables(0).Rows.Count > 0 Then
            SUM2 = Format(Val(ds2.Tables(0).Rows(0).Item(1)) - Val(ds2.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM2 = "0"
        End If
        If ds3.Tables(0).Rows.Count > 0 Then
            SUM3 = Format(Val(ds3.Tables(0).Rows(0).Item(1)) - Val(ds3.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM3 = "0"
        End If
        If ds4.Tables(0).Rows.Count > 0 Then
            SUM4 = Format(Val(ds4.Tables(0).Rows(0).Item(1)) - Val(ds4.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM4 = "0"
        End If
        If ds5.Tables(0).Rows.Count > 0 Then
            SUM5 = Format(Val(ds5.Tables(0).Rows(0).Item(1)) - Val(ds5.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM5 = "0"
        End If
        Me.Taa1.Text = SUM1
        Me.Taa2.Text = SUM2
        Me.Taa3.Text = SUM3
        Me.Taa4.Text = SUM4
        Me.Taa5.Text = SUM5
        Adp1.Dispose()
        Adp2.Dispose()
        Adp3.Dispose()
        Adp4.Dispose()
        Adp5.Dispose()
        Consum.Close()
    End Sub
    Private Sub InternalAuditorBalance1()
        Dim Adp1 As SqlDataAdapter
        Dim Adp2 As SqlDataAdapter
        Dim Adp3 As SqlDataAdapter
        Dim Adp4 As SqlDataAdapter
        Dim Adp5 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1, SUM2, SUM3, SUM4, SUM5 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextBox19.Text & "'" & "AND TBNK8='امانات'", Consum)
        Dim strsq2 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextBox19.Text & "'" & "AND TBNK8='توفير'", Consum)
        Dim strsq3 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextBox19.Text & "'" & "AND TBNK8='الودائع'", Consum)
        Dim strsq4 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextBox19.Text & "'" & "AND TBNK8='شهادة إدخار'", Consum)
        Dim strsq5 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextBox19.Text & "'" & "AND TBNK8='الاسهم'", Consum)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim ds4 As New DataSet
        Dim ds5 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        Adp2 = New SqlDataAdapter(strsq2)
        Adp3 = New SqlDataAdapter(strsq3)
        Adp4 = New SqlDataAdapter(strsq4)
        Adp5 = New SqlDataAdapter(strsq5)
        ds1.Clear()
        ds2.Clear()
        ds3.Clear()
        ds4.Clear()
        ds5.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp2.Fill(ds2)
        Adp3.Fill(ds3)
        Adp4.Fill(ds4)
        Adp5.Fill(ds5)
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(1)) - Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM1 = "0"
        End If
        If ds2.Tables(0).Rows.Count > 0 Then
            SUM2 = Format(Val(ds2.Tables(0).Rows(0).Item(1)) - Val(ds2.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM2 = "0"
        End If
        If ds3.Tables(0).Rows.Count > 0 Then
            SUM3 = Format(Val(ds3.Tables(0).Rows(0).Item(1)) - Val(ds3.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM3 = "0"
        End If
        If ds4.Tables(0).Rows.Count > 0 Then
            SUM4 = Format(Val(ds4.Tables(0).Rows(0).Item(1)) - Val(ds4.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM4 = "0"
        End If
        If ds5.Tables(0).Rows.Count > 0 Then
            SUM5 = Format(Val(ds5.Tables(0).Rows(0).Item(1)) - Val(ds5.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SUM5 = "0"
        End If
        Me.Taak1.Text = SUM1
        Me.Taak2.Text = SUM2
        Me.Taak3.Text = SUM3
        Me.Taak4.Text = SUM4
        Me.Taak5.Text = SUM5
        Val(sumk = Val(SUM1) + Val(SUM2) + Val(SUM3) + Val(SUM4) + Val(SUM5))
        Adp1.Dispose()
        Adp2.Dispose()
        Adp3.Dispose()
        Adp4.Dispose()
        Adp5.Dispose()
        Consum.Close()
    End Sub
    Private Sub InternalAuditorAccount_name()
        Dim Adp1 As SqlDataAdapter
        Dim Adp2 As SqlDataAdapter
        Dim Adp3 As SqlDataAdapter
        Dim Adp4 As SqlDataAdapter
        Dim Adp5 As SqlDataAdapter
        Dim Adp6 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim account_name1, account_name2, account_name3, account_name4, account_name5, account_name6 As String
        Dim account_no1, account_no2, account_no3, account_no4, account_no5, account_no6 As String
        On Error Resume Next
        Me.NumericUpDown1.Value = "2"
        Me.NumericUpDown2.Value = "2"
        Me.NumericUpDown3.Value = "2"
        Me.NumericUpDown4.Value = "2"
        Me.NumericUpDown5.Value = "2"
        Me.NumericUpDown6.Value = "1"
        Dim strsq1 As New SqlCommand("SELECT account_name,account_no FROM ACCOUNTSTREE WHERE account_no = '212002'", Consum)
        Dim strsq2 As New SqlCommand("SELECT account_name,account_no FROM ACCOUNTSTREE WHERE account_no = '212011'", Consum)
        Dim strsq3 As New SqlCommand("SELECT account_name,account_no FROM ACCOUNTSTREE WHERE account_no = '212001'", Consum)
        Dim strsq4 As New SqlCommand("SELECT account_name,account_no FROM ACCOUNTSTREE WHERE account_no = '212012'", Consum)
        Dim strsq5 As New SqlCommand("SELECT account_name,account_no FROM ACCOUNTSTREE WHERE account_no = '211001'", Consum)
        Dim strsq6 As New SqlCommand("SELECT account_name,account_no FROM ACCOUNTSTREE WHERE account_no = '111003'", Consum)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim ds4 As New DataSet
        Dim ds5 As New DataSet
        Dim ds6 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        Adp2 = New SqlDataAdapter(strsq2)
        Adp3 = New SqlDataAdapter(strsq3)
        Adp4 = New SqlDataAdapter(strsq4)
        Adp5 = New SqlDataAdapter(strsq5)
        Adp6 = New SqlDataAdapter(strsq6)
        ds1.Clear()
        ds2.Clear()
        ds3.Clear()
        ds4.Clear()
        ds5.Clear()
        ds6.Clear()
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp2.Fill(ds2)
        Adp3.Fill(ds3)
        Adp4.Fill(ds4)
        Adp5.Fill(ds5)
        Adp6.Fill(ds6)
        If ds1.Tables(0).Rows.Count > 0 Then
            account_name1 = ds1.Tables(0).Rows(0).Item(0)
            account_no1 = ds1.Tables(0).Rows(0).Item(1)
        Else
            account_name1 = ""
            account_no1 = ""
        End If
        If ds2.Tables(0).Rows.Count > 0 Then
            account_name2 = ds2.Tables(0).Rows(0).Item(0)
            account_no2 = ds2.Tables(0).Rows(0).Item(1)
        Else
            account_name2 = ""
            account_no2 = ""
        End If
        If ds3.Tables(0).Rows.Count > 0 Then
            account_name3 = ds3.Tables(0).Rows(0).Item(0)
            account_no3 = ds3.Tables(0).Rows(0).Item(1)
        Else
            account_name3 = ""
            account_no3 = ""
        End If
        If ds4.Tables(0).Rows.Count > 0 Then
            account_name4 = ds4.Tables(0).Rows(0).Item(0)
            account_no5 = ds4.Tables(0).Rows(0).Item(1)
        Else
            account_name4 = ""
            account_no4 = ""
        End If
        If ds5.Tables(0).Rows.Count > 0 Then
            account_name5 = ds5.Tables(0).Rows(0).Item(0)
            account_no5 = ds5.Tables(0).Rows(0).Item(1)
        Else
            account_name5 = ""
            account_no5 = ""
        End If
        If ds6.Tables(0).Rows.Count > 0 Then
            account_name6 = ds6.Tables(0).Rows(0).Item(0)
            account_no6 = ds6.Tables(0).Rows(0).Item(1)
        Else
            account_name6 = ""
            account_no6 = ""
        End If
        Me.ComboBox1.Text = account_name1
        Me.ComboBox2.Text = account_name2
        Me.ComboBox3.Text = account_name3
        Me.ComboBox4.Text = account_name4
        Me.ComboBox5.Text = account_name5
        Me.ComboBox6.Text = account_name6
        Adp1.Dispose()
        Adp2.Dispose()
        Adp3.Dispose()
        Adp4.Dispose()
        Adp5.Dispose()
        Adp6.Dispose()
        Consum.Close()
    End Sub
    Private Sub Ch1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch1.CheckedChanged
        If Me.Ch1.Checked = True Then
            Me.DataGridView1.Focus()
            For Each r As DataGridViewRow In DataGridView1.Rows
                tota1 += CDbl(r.Cells("Loa7").Value)
                Me.TextBox18.Text = tota1.ToString("0.00")
            Next
            xx1 = "0.00"
            xx2 = "0.00"
            xx3 = "0.00"
            xx4 = "0.00"
            xx5 = "0.00"
            Me.TextBox7.Text = "0.00"
            Me.TextBoxk7.Text = "0.00"
            Me.TextBox8.Text = "0.00"
            Me.TextBoxk8.Text = "0.00"
            Me.TextBoxkA8.Text = "0.00"
            Me.TextBoxk9.Text = "0.00"
            Me.TextBoxk10.Text = "0.00"
            Me.TextBox21.Text = "0.00"
            Me.TextBox22.Text = "0.00"
            Me.Timsum.Start()
        ElseIf Me.Ch1.Checked = False Then
            Me.Timsum.Stop()
        End If
    End Sub
    Private Sub Ch2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch2.CheckedChanged
        If Me.Ch2.Checked = True Then
            Me.DataGridView2.Focus()
            tota1 = "0.00"
            Me.Timsum1.Start()
            Me.Timsum.Stop()
        ElseIf Me.Ch2.Checked = False Then
            Me.Timsum.Start()
            Me.Timsum1.Stop()
        End If
    End Sub
    Private Sub Ch3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Ch3.CheckedChanged
        If Me.Ch3.Checked = True Then
            Me.DataGridView3.Focus()
            xxk1 = "0.00"
            xxk2 = "0.00"
            xxk3 = "0.00"
            xxk4 = "0.00"
            xxk5 = "0.00"
            Me.TextBoxk7.Text = "0.00"
            Me.TextBoxkA7.Text = "0.00"
            Me.TextBoxk8.Text = "0.00"
            Me.TextBoxkA8.Text = "0.00"
            Me.TextBoxk9.Text = "0.00"
            Me.TextBoxk10.Text = "0.00"
            Me.Timsum.Stop()
            Me.Timsum1.Stop()
            Me.Timsum2.Start()
        ElseIf Me.Ch3.Checked = False Then
            Me.Timsum.Start()
            Me.Timsum1.Stop()
            Me.Timsum2.Stop()
        End If
    End Sub
    Private Sub Timsum_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum.Tick
        On Error Resume Next
        If Me.Ch1.Checked = True Then
            Dim tota2 As Double
            Dim tota3 As Double
            Dim s1 As Double
            Dim s2 As Double
            Dim s3 As Double
            Dim s4 As Double
            Dim s5 As Double
            Dim sums6 As Double
            Dim suming As Double
            Dim tota4 As Double
            Dim I As Integer
            Dim dgvRow As New DataGridViewRow
            For Each dgvRow In DataGridView1.Rows
                If dgvRow.Index Mod 2 = 0 Then
                    Me.DataGridView1.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.LightYellow
                End If
            Next
            Me.TextBox17.Text = "WD" & "-" & Me.DataGridView1("Loa1", Me.DataGridView1.CurrentRow.Index).Value
            If Me.DataGridView1.Rows.Count = 0 Then

            Else
                Dim counter As Integer = Me.DataGridView1.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = Me.DataGridView1.RowCount Then
                    nextRow = Me.DataGridView1.Rows(0)
                    Me.Ch1.Checked = False
                    Me.Ch2.Checked = False
                    tota1 = "0.00"
                    Me.Ta1.Text = "0.00"
                    Me.Ta2.Text = "0.00"
                    Me.Ta3.Text = "0.00"
                    Me.Ta4.Text = "0.00"
                    Me.Ta5.Text = "0.00"
                    Me.Tb1.Text = "0.00"
                    Me.Tb2.Text = "0.00"
                    Me.Tb3.Text = "0.00"
                    Me.Tb4.Text = "0.00"
                    Me.Tb5.Text = "0.00"
                    Me.Taa1.Text = "0.00"
                    Me.Taa2.Text = "0.00"
                    Me.Taa3.Text = "0.00"
                    Me.Taa4.Text = "0.00"
                    Me.Taa5.Text = "0.00"
                    Me.TextBox7.Text = "0.00"
                    Me.TextBox8.Text = "0.00"
                    Me.TextBoxk8.Text = "0.00"
                    Me.TextBox21.Text = "0.00"
                    Me.TextBox22.Text = "0.00"
                    Me.InternalAuditorAccount_name()
                Else
                    nextRow = Me.DataGridView1.Rows(counter)
                    nextRow.Selected = True
                End If
                Me.DataGridView1.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
                Me.DataGridView1.Rows(counter).Selected = True
                Me.SEARCHDATAITEMS10()
                Me.InternalAuditorBalance()
                Me.FundBalance()
                Me.FundBalance()

                Me.LOK1.Text = CDbl(Me.DataGridView1("Lo", Me.DataGridView1.CurrentRow.Index).Value)
                Me.TextBox21.Text = "0.00"
                Me.TextBox22.Text = "0.00"
                For Each r As DataGridViewRow In Me.DataGridView1.Rows
                    tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                    s1 = Me.Taa1.Text
                    Me.Label14.Dock = DockStyle.Top
                    Me.Label14.Visible = True
                    Me.Label14.Text = " الرجاء الانتظار لم تكتمل عملية تحويل الاقساط ... "
                    If Val(s1) >= CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                        s1 = Val(Taa1.Text)
                        tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                        Me.Tb1.Text = Val(s1) - Val(tota2)
                        Me.Ta1.Text = Val(Me.Taa1.Text) - Val(Me.Tb1.Text)
                        s2 = Val(s1) + Val(Me.Taa2.Text)
                        Me.Ta2.Text = "0.00"
                        Me.Tb2.Text = Val(Me.Taa2.Text)
                        Me.Ta3.Text = "0.00"
                        Me.Tb3.Text = Val(Me.Taa3.Text)
                        Me.Ta4.Text = "0.00"
                        Me.Tb4.Text = Val(Me.Taa4.Text)
                        Me.Ta5.Text = "0.00"
                        Me.Tb5.Text = Val(Me.Taa5.Text)
                    ElseIf Val(s1) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                        s1 = Val(Me.Taa1.Text)
                        s2 = Val(s1) + Val(Me.Taa2.Text)
                        If Val(s2) >= CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                            tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                            s1 = Val(Taa1.Text)
                            s2 = Val(s1) + Val(Me.Taa2.Text)
                            Me.Ta1.Text = Val(s1)
                            Me.Tb1.Text = "0.00"
                            tota4 = Val(tota2) - Val(Me.Taa1.Text)
                            '''''''''''''''''''''''''''''
                            Me.Ta2.Text = Val(tota4)
                            Me.Tb2.Text = Val(Me.Taa2.Text) - Val(Me.Ta2.Text)
                            Me.Ta3.Text = "0.00"
                            Me.Tb3.Text = Val(Me.Taa3.Text)
                            Me.Ta4.Text = "0.00"
                            Me.Tb4.Text = Val(Me.Taa4.Text)
                            Me.Ta5.Text = "0.00"
                            Me.Tb5.Text = Val(Me.Taa5.Text)
                        ElseIf Val(s2) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                            tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                            s1 = Val(Me.Taa1.Text)
                            s2 = Val(s1) + Val(Me.Taa2.Text)
                            Me.Ta1.Text = Val(s1)
                            Me.Tb1.Text = "0.00"
                            Me.Ta2.Text = Val(Taa2.Text)
                            Me.Tb2.Text = "0.00"
                            If Val(s3) >= CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                                s1 = Val(Taa1.Text)
                                s2 = Val(s1) + Val(Me.Taa2.Text)
                                s3 = Val(s2) + Val(Me.Taa3.Text)
                                Me.Ta1.Text = Val(Me.Taa1.Text)
                                Me.Tb1.Text = "0.00"
                                tota4 = Val(tota2) - (Val(Me.Taa1.Text) + Val(Me.Taa2.Text))
                                '''''''''''''''''''''''''''''
                                Me.Ta3.Text = Val(tota4)
                                Me.Tb3.Text = Val(Me.Taa3.Text) - Val(Me.Ta3.Text)
                                Me.Ta4.Text = "0.00"
                                Me.Tb4.Text = Val(Me.Taa4.Text)
                                Me.Ta5.Text = "0.00"
                                Me.Tb5.Text = Val(Me.Taa5.Text)
                                'MsgBox("تم تحويل 1")

                            ElseIf Val(s3) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                                s2 = Val(Taa2.Text)
                                s3 = Val(s2) + Val(Me.Taa3.Text)
                                Me.Ta1.Text = Val(Me.Taa1.Text)
                                Me.Tb1.Text = "0.00"
                                Me.Ta2.Text = Val(Me.Taa2.Text)
                                Me.Tb2.Text = "0.00"
                                Me.Ta3.Text = Val(Me.Taa3.Text)
                                Me.Tb3.Text = "0.00"
                                'MsgBox("تم تحويل 2")

                                If Val(s4) >= CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                    tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                                    s1 = Val(Taa1.Text)
                                    s2 = Val(s1) + Val(Me.Taa2.Text)
                                    s3 = Val(s2) + Val(Me.Taa3.Text)
                                    s4 = Val(s3) + Val(Me.Taa4.Text)
                                    Me.Ta1.Text = Val(Me.Taa1.Text)
                                    Me.Tb1.Text = "0.00"
                                    tota4 = Val(tota2) - (Val(Me.Taa1.Text) + Val(Me.Taa2.Text) + Val(Me.Taa3.Text))
                                    '''''''''''''''''''''''''''''
                                    Me.Ta4.Text = Val(tota4)
                                    Me.Tb4.Text = Val(Me.Taa4.Text) - Val(Me.Ta4.Text)
                                    Me.Ta5.Text = "0.00"
                                    Me.Tb5.Text = Val(Taa5.Text)
                                ElseIf Val(s4) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                    tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                                    s3 = Val(Me.Taa3.Text)
                                    s4 = Val(s3) + Val(Me.Taa5.Text)
                                    Me.Ta1.Text = Val(Me.Taa1.Text)
                                    Me.Tb1.Text = "0.00"
                                    Me.Ta2.Text = Val(Me.Taa2.Text)
                                    Me.Tb2.Text = "0.00"
                                    Me.Ta3.Text = Val(Me.Taa3.Text)
                                    Me.Tb3.Text = "0.00"
                                    Me.Ta4.Text = Val(Me.Taa4.Text)
                                    Me.Tb4.Text = "0.00"
                                    If Val(s5) >= CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                        tota2 = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                                        s1 = Val(Me.Taa1.Text)
                                        s2 = Val(s1) + Val(Me.Taa2.Text)
                                        s3 = Val(s2) + Val(Me.Taa3.Text)
                                        s4 = Val(s3) + Val(Me.Taa4.Text)
                                        s5 = Val(s4) + Val(Me.Taa5.Text)
                                        Me.Ta1.Text = Val(Me.Taa1.Text)
                                        Me.Tb1.Text = "0.00"
                                        tota4 = Val(tota2) - (Val(Me.Taa1.Text) + Val(Me.Taa2.Text) + Val(Me.Taa3.Text) + Val(Me.Taa4.Text))
                                        '''''''''''''''''''''''''''''
                                        Me.Ta5.Text = Val(tota4)
                                        Me.Tb5.Text = Val(Me.Taa5.Text) - Val(Me.Ta5.Text)
                                    ElseIf Val(s5) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                        s4 = Val(Me.Taa4.Text)
                                        s5 = Val(s4) + Val(Me.Taa5.Text)
                                        Me.Ta1.Text = Val(Me.Taa1.Text)
                                        Me.Tb1.Text = "0.00"
                                        Me.Ta2.Text = Val(Me.Taa2.Text)
                                        Me.Tb2.Text = "0.00"
                                        Me.Ta3.Text = Val(Me.Taa3.Text)
                                        Me.Tb3.Text = "0.00"
                                        Me.Ta4.Text = Val(Me.Taa4.Text)
                                        Me.Tb4.Text = "0.00"
                                        Me.Ta5.Text = Val(Me.Taa5.Text)
                                        Me.Tb5.Text = "0.00"
                                        Me.SEARCHDATAITEMS1()
                                        Me.InternalAuditorBalance1()

                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

            End If
            Me.FundBalance()
            Me.SEARCHDATAITEMS1()
            Me.InternalAuditorBalance1()
            xx1 = Val(xx1) + Val(Me.Ta1.Text)
            xx2 = Val(xx2) + Val(Me.Ta2.Text)
            xx3 = Val(xx3) + Val(Me.Ta3.Text)
            xx4 = Val(xx4) + Val(Me.Ta4.Text)
            xx5 = Val(xx5) + Val(Me.Ta5.Text)

            Me.TextBox1.Text = Format(Val(xx1) + Val(Me.TextBoxk1.Text), "0.000")
            Me.TextBox2.Text = Format(Val(xx2) + Val(Me.TextBoxk2.Text), "0.000")
            Me.TextBox3.Text = Format(Val(xx3) + Val(Me.TextBoxk3.Text), "0.000")
            Me.TextBox4.Text = Format(Val(xx4) + Val(Me.TextBoxk4.Text), "0.000")
            Me.TextBox5.Text = Format(Val(xx5) + Val(Me.TextBoxk5.Text), "0.000")

            Me.TextBox7.Text = Val(Me.Ta1.Text) + Val(Me.Ta2.Text) + Val(Me.Ta3.Text) + Val(Me.Ta4.Text) + Val(Me.Ta5.Text)
            Me.TextBox8.Text = Val(Me.TextBox1.Text) + Val(Me.TextBox2.Text) + Val(Me.TextBox3.Text) + Val(Me.TextBox4.Text) + Val(Me.TextBox5.Text)
            Me.Textk7.Text = Val(Me.TextBox8.Text) + Val(Me.TextBoxk8.Text)
            Me.TextBox21.Text = Val(Me.TextBoxk9.Text) - Val(Me.TextBoxk8.Text)
            Me.TextBox22.Text = Val(Me.TextBox21.Text) + Val(Me.TextBoxk9.Text)

            If Val(Me.TextBoxk9.Text) >= Val(tota2) Then
                Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                Me.Textk7.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
            Else
                If Val(Me.TextBoxk10.Text) < Val(Me.TextBoxk9.Text) Then
                    Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) + Val(Me.TextBox21.Text)
                ElseIf Val(Me.TextBoxk10.Text) = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                    Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) - Val(Me.TextBox21.Text)
                Else
                    If Val(Me.TextBoxk9.Text) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                        Me.Textk77.Text = Val(Me.TextBox7.Text) + Val(Me.TextBoxk7.Text)
                    ElseIf Val(Me.TextBoxk9.Text) = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                        Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                    End If
                End If
            End If
            Me.Ch2.Checked = True
        End If

        If Me.Ch1.Checked = False Then
            If Me.Ch3.Checked = False Then
                If Me.Ch2.Checked = False Then
                    If TestNet = False Then
                        MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                        Exit Sub
                    End If
                    If LockUpdate = False Then
                        MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل وترحبل السجلات من البرنامج", 16, "تنبيه")
                        Exit Sub
                    End If
                    If Me.Textk7.Text < "1" Then
                        MsgBox("عفوا .. لا يمكن ترحبل السجلات القيمة اقل من واحد", 16, "تنبيه")
                        Exit Sub
                    End If
                    Me.Timsum.Stop()
                    Me.TextBox1.Text = Format(Val(xx1) + Val(Me.TextBoxk1.Text), "0.000")
                    Me.TextBox2.Text = Format(Val(xx2) + Val(Me.TextBoxk2.Text), "0.000")
                    Me.TextBox3.Text = Format(Val(xx3) + Val(Me.TextBoxk3.Text), "0.000")
                    Me.TextBox4.Text = Format(Val(xx4) + Val(Me.TextBoxk4.Text), "0.000")
                    Me.TextBox5.Text = Format(Val(xx5) + Val(Me.TextBoxk5.Text), "0.000")

                    Me.TextBox7.Text = Val(Me.Ta1.Text) + Val(Me.Ta2.Text) + Val(Me.Ta3.Text) + Val(Me.Ta4.Text) + Val(Me.Ta5.Text)
                    Me.TextBox8.Text = Val(Me.TextBox1.Text) + Val(Me.TextBox2.Text) + Val(Me.TextBox3.Text) + Val(Me.TextBox4.Text) + Val(Me.TextBox5.Text)
                    Me.Textk7.Text = Val(Me.TextBox8.Text) + Val(Me.TextBoxk8.Text)
                    Me.TextBox21.Text = Val(Me.TextBoxk9.Text) - Val(Me.TextBoxk8.Text)
                    Me.TextBox22.Text = Val(Me.TextBox21.Text) + Val(Me.TextBoxk9.Text)
                    If Val(Me.TextBoxk9.Text) >= Val(tota2) Then
                        Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                    Else
                        If Val(Me.TextBoxk10.Text) < Val(Me.TextBoxk9.Text) Then
                            Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) + Val(Me.TextBox21.Text)
                        ElseIf Val(TextBoxk10.Text) = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                            Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) - Val(Me.TextBox21.Text)
                        Else
                            If Val(Me.TextBoxk9.Text) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                Me.Textk77.Text = Val(Me.TextBox7.Text) + Val(Me.TextBoxk7.Text)
                            ElseIf Val(Me.TextBoxk9.Text) = CDbl(DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                                Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value)
                            End If
                        End If
                    End If
                    If Me.TextBox1.Text > 0 Then
                        Me.CheckBox1.Checked = True
                        If Me.TextBox2.Text > 0 Then
                            Me.CheckBox2.Checked = True
                        Else
                            Me.CheckBox2.Checked = False
                        End If
                        If Me.TextBox3.Text > 0 Then
                            Me.CheckBox3.Checked = True
                        Else
                            Me.CheckBox3.Checked = False
                        End If
                        If Me.TextBox4.Text > 0 Then
                            Me.CheckBox4.Checked = True
                        Else
                            Me.CheckBox4.Checked = False
                        End If
                        If Me.TextBox5.Text > 0 Then
                            Me.CheckBox5.Checked = True
                        Else
                            Me.CheckBox5.Checked = False
                        End If
                    Else
                        Me.CheckBox1.Checked = False
                        If Me.TextBox2.Text > 0 Then
                            Me.CheckBox2.Checked = True
                        Else
                            Me.CheckBox2.Checked = False
                        End If
                        If Me.TextBox3.Text > 0 Then
                            Me.CheckBox3.Checked = True
                        Else
                            Me.CheckBox3.Checked = False
                        End If
                        If Me.TextBox4.Text > 0 Then
                            Me.CheckBox4.Checked = True
                        Else
                            Me.CheckBox4.Checked = False
                        End If
                        If Me.TextBox5.Text > 0 Then
                            Me.CheckBox5.Checked = True
                        Else
                            Me.CheckBox5.Checked = False
                        End If
                    End If
                    Me.Label14.Text = "اكتمل العملية"
                    Me.Label14.Dock = DockStyle.None
                    Me.Label14.Visible = False

                    Me.SaveMOVES()
                    Me.SaveMOVESDATARecord()
                    MsgBox("تم تحويل الاقساط الى الاعضاء بنجاح")
                    Me.ToolStripButton2.Enabled = True
                End If
            End If
        End If

    End Sub
    Private Sub Timsum1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum1.Tick
        On Error Resume Next
        If Me.Ch2.Checked = True Then
            Dim I As Integer
            Dim KCount As Double
            Dim sumCount As Double
            Dim dgvRow As New DataGridViewRow
            For Each dgvRow In Me.DataGridView2.Rows
                If dgvRow.Index Mod 2 = 0 Then
                    Me.DataGridView2.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.LightYellow
                End If
            Next
            Me.TextBox17.Text = "WD" & "-" & Me.DataGridView1("Loa1", Me.DataGridView1.CurrentRow.Index).Value
            KCount = Me.DataGridView3.Rows.Count - 1
            If Me.DataGridView2.Rows.Count = 0 Then
            Else
                Dim counter As Integer = Me.DataGridView2.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = Me.DataGridView2.RowCount Then
                    nextRow = Me.DataGridView2.Rows(0)
                    Me.Ch2.Checked = False
                    Me.Timsum1.Stop()
                    test = 1
                    test1 = 1
                    For Each r As DataGridViewRow In Me.DataGridView2.Rows
                        If r.Cells("TBNK6").Value = Me.TextBox19.Text Then
                            test = 0
                        End If
                    Next
                    For Each r1 As DataGridViewRow In Me.DataGridView3.Rows
                        If r1.Cells("LOK").Value = LOK1.Text Then
                            test1 = 0
                        End If
                    Next
                    If test1 = 0 Then
                        Me.Ch3.Checked = False
                        If test = 0 Then
                            Me.Ch3.Checked = True
                            Me.Timsum2.Start()
                            For ri As Integer = 0 To Me.DataGridView2.Rows.Count - 2
                                xxk7 += Val(Me.DataGridView2.Rows(ri).Cells("co1").Value)
                            Next

                        End If
                    Else
                        Me.Ch3.Checked = False
                        Me.Timsum2.Stop()
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                    If Me.DataGridView3.Rows.Count = 0 Then
                    Else
                        Dim counter1 As Integer = Me.DataGridView3.CurrentRow.Index + 1
                        Dim nextRow1 As DataGridViewRow
                        If counter1 = Me.DataGridView3.RowCount Then
                            nextRow1 = Me.DataGridView3.Rows(0)
                            Me.Ch3.Checked = False
                            Me.Timsum2.Stop()
                        Else
                            nextRow1 = Me.DataGridView3.Rows(counter1 - 1)
                            nextRow1.Selected = True
                        End If
                        Me.DataGridView3.CurrentCell = nextRow1.Cells(0)
                        nextRow1.Selected = True
                        Me.DataGridView3.Rows(counter1).Selected = True
                    End If
                    ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                Else
                    nextRow = Me.DataGridView2.Rows(counter)
                    nextRow.Selected = True
                    For Each row1 As DataGridViewRow In Me.DataGridView1.Rows
                        For Each row As DataGridViewRow In Me.DataGridView2.Rows
                            If row.Cells("TBNK6").Value = Me.TEXTBOX6.Text Then
                                If row.Cells("TBNK8").Value = "امانات" Then
                                    row.Cells("Co1").Value = Me.Ta1.Text
                                ElseIf row.Cells("TBNK8").Value = "توفير" Then
                                    row.Cells("Co1").Value = Me.Ta2.Text
                                ElseIf row.Cells("TBNK8").Value = "الودائع" Then
                                    row.Cells("Co1").Value = Me.Ta3.Text
                                ElseIf row.Cells("TBNK8").Value = "شهادة إدخار" Then
                                    row.Cells("Co1").Value = Me.Ta4.Text
                                ElseIf row.Cells("TBNK8").Value = "الاسهم" Then
                                    row.Cells("Co1").Value = Me.Ta5.Text
                                End If
                            ElseIf row.Cells("TBNK6").Value = Me.TextBox19.Text Then
                                Me.TextBox20.Text = Val(Me.TextBoxk9.Text)
                                If row.Cells("TBNK8").Value = "امانات" Then
                                    row.Cells("Co1").Value = Me.Tak1.Text
                                ElseIf row.Cells("TBNK8").Value = "توفير" Then
                                    row.Cells("Co1").Value = Me.Tak2.Text
                                ElseIf row.Cells("TBNK8").Value = "الودائع" Then
                                    row.Cells("Co1").Value = Me.Tak3.Text
                                ElseIf row.Cells("TBNK8").Value = "شهادة إدخار" Then
                                    row.Cells("Co1").Value = Me.Tak4.Text
                                ElseIf row.Cells("TBNK8").Value = "الاسهم" Then
                                    row.Cells("Co1").Value = Val(Me.Tak5.Text) '+ Val(TextBoxk7.Text)
                                End If
                            End If
                        Next
                    Next

                    If Me.TextBox1.Text > 0 Then
                        Me.CheckBox1.Checked = True
                        If Me.TextBox2.Text > 0 Then
                            Me.CheckBox2.Checked = True
                        Else
                            Me.CheckBox2.Checked = False
                        End If
                        If Me.TextBox3.Text > 0 Then
                            Me.CheckBox3.Checked = True
                        Else
                            Me.CheckBox3.Checked = False
                        End If
                        If Me.TextBox4.Text > 0 Then
                            Me.CheckBox4.Checked = True
                        Else
                            Me.CheckBox4.Checked = False
                        End If
                        If Me.TextBox5.Text > 0 Then
                            Me.CheckBox5.Checked = True
                        Else
                            Me.CheckBox5.Checked = False
                        End If
                    Else
                        Me.CheckBox1.Checked = False
                        If Me.TextBox2.Text > 0 Then
                            Me.CheckBox2.Checked = True
                        Else
                            Me.CheckBox2.Checked = False
                        End If
                        If Me.TextBox3.Text > 0 Then
                            Me.CheckBox3.Checked = True
                        Else
                            Me.CheckBox3.Checked = False
                        End If
                        If Me.TextBox4.Text > 0 Then
                            Me.CheckBox4.Checked = True
                        Else
                            Me.CheckBox4.Checked = False
                        End If
                        If Me.TextBox5.Text > 0 Then
                            Me.CheckBox5.Checked = True
                        Else
                            Me.CheckBox5.Checked = False
                        End If
                    End If
                End If
                Me.DataGridView2.CurrentCell = nextRow.Cells(0)
                nextRow.Selected = True
                Me.DataGridView2.Rows(counter).Selected = True
                Me.TextBox21.Text = Val(Me.TextBoxk9.Text) - Val(Me.TextBoxk8.Text)
                Me.TextBox24.Text = Val(Me.TextBox7.Text) + Val(Me.TextBoxk8.Text)

                If CDbl(Me.DataGridView2("co1", Me.DataGridView2.CurrentRow.Index).Value) > 0 Then
                    Call UPDATELoansPa()
                End If
                If Me.DataGridView2("TBNK6", DataGridView2.CurrentRow.Index).Value = Me.TEXTBOX6.Text Then
                    Me.InternalAuditorBalance()
                    If CDbl(Me.DataGridView2("co1", Me.DataGridView2.CurrentRow.Index).Value) > 0 Then
                        Call INSERTRECORDempsolf()
                    End If
                ElseIf Me.DataGridView2("TBNK6", Me.DataGridView2.CurrentRow.Index - 1).Value = Me.TextBox19.Text Then
                    Me.InternalAuditorBalance1()
                    If CDbl(Me.DataGridView2("co1", Me.DataGridView2.CurrentRow.Index).Value) > 0 Then
                        Call INSERTRECORDempsolf1()
                    End If
                End If

            End If
        End If

    End Sub
    Private Sub Timsum2_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timsum2.Tick
        On Error Resume Next
        Dim totak2 As Double
        Dim tota3 As Double
        Dim sk1 As Double
        Dim sk2 As Double
        Dim sk3 As Double
        Dim sk4 As Double
        Dim sk5 As Double
        Dim sums6 As Double
        Dim suming As Double
        Dim KCount As Double
        Dim totak4 As Double
        Dim KsCount As Integer
        test2 = 1
        If Ch3.Checked = True Then
            Dim I As Integer
            Dim dgvRow As New DataGridViewRow
            For Each dgvRow In Me.DataGridView3.Rows
                If dgvRow.Index Mod 2 = 0 Then
                    Me.DataGridView3.Rows(dgvRow.Index).DefaultCellStyle.BackColor = Color.LightYellow
                End If
            Next
            Me.SEARCHDATAITEMS1()
            Me.InternalAuditorBalance1()
            Me.SEARCHDATAITEMS13()

            test = 1
            test1 = 1
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells("TBNK6").Value = Me.TEXTBOX6.Text Then
                    test = 0
                End If
            Next
            For Each r As DataGridViewRow In Me.DataGridView2.Rows
                If r.Cells("TBNK6").Value = Me.TextBox19.Text Then
                    test1 = 0
                End If
            Next
            If test = 0 Then
                If test1 = 0 Then

                Else
                    Me.SEARCHDATAITEMS1()
                    Me.InternalAuditorBalance1()
                    Me.SEARCHDATAITEMS13()
                End If
            Else
                If Me.DataGridView2.Rows.Count = 0 Then
                Else
                    Dim counter1 As Integer = Me.DataGridView2.CurrentRow.Index + 1
                    Dim nextRow1 As DataGridViewRow
                    If counter1 = Me.DataGridView2.RowCount Then
                        nextRow1 = Me.DataGridView2.Rows(0)
                    Else
                        nextRow1 = Me.DataGridView2.Rows(counter1)
                        nextRow1.Selected = True
                        Me.Ch3.Checked = False
                        Me.Timsum2.Stop()
                        Me.Ch2.Checked = True
                        Me.Timsum1.Start()
                    End If
                    Me.DataGridView2.CurrentCell = nextRow1.Cells(0)
                    nextRow1.Selected = True
                    Me.DataGridView2.Rows(counter1).Selected = True
                End If
                Me.Ch3.Checked = False
                Me.SEARCHDATAITEMS1()
                Me.InternalAuditorBalance1()
                Me.SEARCHDATAITEMS13()
            End If
            KCount = Me.DataGridView3.Rows.Count - 1
            Me.KCountT.Text = Val(KCount)
            Me.TextBoxk9.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) - Val(Me.TextBox7.Text)
            Me.TextBoxk10.Text = Me.TextBoxk9.Text / Val(Me.KCountT.Text) '+ Val(TextBox22.Text)
            Me.KCountT2.Text = Val(test2)
            Me.KCountT2.Text = Val(Me.KCountT2.Text)
            Me.TextBoxkA8.Text = Val(Me.TextBoxk10.Text) * Val(Me.KCountT.Text)
            If Me.DataGridView3.Rows.Count = 0 Then
            Else
                Dim counter As Integer = Me.DataGridView3.CurrentRow.Index + 1
                Dim nextRow As DataGridViewRow
                If counter = Me.DataGridView3.RowCount Then
                    nextRow = Me.DataGridView3.Rows(0)
                    Me.FundBalance()
                    Me.Ch3.Checked = False
                    Me.Timsum2.Stop()
                    Me.Ch2.Checked = False
                    Me.Timsum1.Stop()
                    'Me.Ch1.Checked = True
                    'Me.Timsum.Start()
                    tota1 = "0.00"
                    Me.Tak1.Text = "0.00"
                    Me.Tak2.Text = "0.00"
                    Me.Tak3.Text = "0.00"
                    Me.Tak4.Text = "0.00"
                    Me.Tak5.Text = "0.00"
                    Me.Tbk1.Text = "0.00"
                    Me.Tbk2.Text = "0.00"
                    Me.Tbk3.Text = "0.00"
                    Me.Tbk4.Text = "0.00"
                    Me.Tbk5.Text = "0.00"
                    Me.Taak1.Text = "0.00"
                    Me.Taak2.Text = "0.00"
                    Me.Taak3.Text = "0.00"
                    Me.Taak4.Text = "0.00"
                    Me.Taak5.Text = "0.00"

                    Me.TextBoxk7.Text = "0.00"
                    Me.TextBoxk8.Text = "0.00"
                    Me.TextBoxkA7.Text = "0.00"
                    Me.TextBoxkA8.Text = "0.00"
                    Me.TextBoxk10.Text = "0.00"
                    Me.TextBox20.Text = "0.00"

                Else
                    nextRow = Me.DataGridView3.Rows(counter)
                    nextRow.Selected = True
                End If
                For Each r As DataGridViewRow In Me.DataGridView3.Rows
                    Me.KCountT2.Text = Val(Me.KCountT2.Text) + 1
                    Me.KCountT1.Text = Val(Me.KCountT1.Text) + 1
                    Me.DataGridView3.CurrentCell = nextRow.Cells(0)
                    nextRow.Selected = True
                    Me.DataGridView3.Rows(counter).Selected = True
                    Me.LOKA2.Text = CDbl(Me.DataGridView3("LOK2", Me.DataGridView3.CurrentRow.Index).Value)
                    sk1 = Val(Me.Taak1.Text)
                    If Val(sk1) >= Val(Me.TextBoxk10.Text) Then
                        sk1 = Val(Me.Taak1.Text)
                        totak2 = Val(Me.TextBoxk10.Text)
                        Me.Tbk1.Text = Val(sk1) - Val(totak2)
                        Me.Tak1.Text = Val(Me.Taak1.Text) - Val(Me.Tbk1.Text)
                        sk2 = Val(sk1) + Val(Me.Taak2.Text)
                        Me.Tak2.Text = "0.00"
                        Me.Tbk2.Text = Val(Me.Taak2.Text)
                        Me.Tak3.Text = "0.00"
                        Me.Tbk3.Text = Val(Me.Taak3.Text)
                        Me.Tak4.Text = "0.00"
                        Me.Tbk4.Text = Val(Me.Taak4.Text)
                        Me.Tak5.Text = "0.00"
                        Me.Tbk5.Text = Val(Me.Taak5.Text)
                    ElseIf Val(sk1) < Val(Me.TextBoxk10.Text) Then
                        sk1 = Val(Me.Taak1.Text)
                        sk2 = Val(sk1) + Val(Me.Taak2.Text)
                        Me.Tak1.Text = Val(Me.Taak1.Text)
                        Me.Tbk1.Text = "0.00"
                        If Val(sk2) >= Val(Me.TextBoxk10.Text) Then
                            totak2 = Val(Me.TextBoxk10.Text)
                            sk1 = Val(Me.Taak1.Text)
                            sk2 = Val(sk1) + Val(Me.Taak2.Text)
                            Me.Tak1.Text = Val(sk1)
                            Me.Tbk1.Text = "0.00"
                            totak4 = Val(totak2) - Val(Me.Taak1.Text)
                            Me.Tak2.Text = Val(totak4)
                            Me.Tbk2.Text = Val(Me.Taak2.Text) - Val(Me.Tak2.Text)
                            Me.Tak3.Text = "0.00"
                            Me.Tbk3.Text = Val(Me.Taak3.Text)
                            Me.Tak4.Text = "0.00"
                            Me.Tbk4.Text = Val(Me.Taak4.Text)
                            Me.Tak5.Text = "0.00"
                            Me.Tbk5.Text = Val(Me.Taak5.Text)
                        ElseIf Val(sk2) < Val(Me.TextBoxk10.Text) Then
                            totak2 = Val(Me.TextBoxk10.Text)
                            sk1 = Val(Me.Taak1.Text)
                            sk2 = Val(sk1) + Val(Me.Taak2.Text)
                            Me.Tak1.Text = Val(sk1)
                            Me.Tbk1.Text = "0.00"
                            Me.Tak2.Text = Val(Me.Taak2.Text)
                            Me.Tbk2.Text = "0.00"
                            If Val(sk3) >= Val(Me.TextBoxk10.Text) Then
                                totak2 = Val(Me.TextBoxk10.Text)
                                sk1 = Val(Me.Taak1.Text)
                                sk2 = Val(sk1) + Val(Me.Taak2.Text)
                                sk3 = Val(sk2) + Val(Me.Taak3.Text)
                                Me.Tak1.Text = Val(Me.Taak1.Text)
                                Me.Tbk1.Text = "0.00"
                                totak4 = Val(totak2) - (Val(Me.Taak1.Text) + Val(Me.Taak2.Text))
                                Me.Tak3.Text = Val(totak4)
                                Me.Tbk3.Text = Val(Me.Taak3.Text) - Val(Tak3.Text)
                                Me.Tak4.Text = "0.00"
                                Me.Tbk4.Text = Val(Me.Taak4.Text)
                                Me.Tak5.Text = "0.00"
                                Me.Tbk5.Text = Val(Me.Taak5.Text)
                            ElseIf Val(sk3) < Val(Me.TextBoxk10.Text) Then
                                totak2 = Val(Me.TextBoxk10.Text)
                                sk2 = Val(Me.Taak2.Text)
                                sk3 = Val(sk2) + Val(Me.Taak3.Text)
                                Me.Tak1.Text = Val(Me.Taak1.Text)
                                Me.Tbk1.Text = "0.00"
                                Me.Tak2.Text = Val(Me.Taak2.Text)
                                Me.Tbk2.Text = "0.00"
                                Me.Tak3.Text = Val(Me.Taak3.Text)
                                Me.Tbk3.Text = "0.00"
                                If Val(sk4) >= Val(Me.TextBoxk10.Text) Then
                                    totak2 = Val(Me.TextBoxk10.Text)
                                    sk1 = Val(Me.Taak1.Text)
                                    sk2 = Val(sk1) + Val(Me.Taak2.Text)
                                    sk3 = Val(sk2) + Val(Me.Taak3.Text)
                                    sk4 = Val(sk3) + Val(Me.Taak4.Text)
                                    Me.Tak1.Text = Val(Me.Taak1.Text)
                                    Me.Tbk1.Text = "0.00"
                                    totak4 = Val(totak2) - (Val(Me.Taak1.Text) + Val(Me.Taak2.Text) + Val(Me.Taak3.Text))
                                    Me.Tak4.Text = Val(totak4)
                                    Me.Tbk4.Text = Val(Me.Taak4.Text) - Val(Me.Tak4.Text)
                                    Me.Tak5.Text = "0.00"
                                    Me.Tbk5.Text = Val(Me.Taak5.Text)
                                ElseIf Val(sk4) < Val(Me.TextBoxk10.Text) Then
                                    totak2 = Val(Me.TextBoxk10.Text)
                                    sk3 = Val(Taak3.Text)
                                    sk4 = Val(sk3) + Val(Me.Taak3.Text)
                                    Me.Tak1.Text = Val(Me.Taak1.Text)
                                    Me.Tbk1.Text = "0.00"
                                    Me.Tak2.Text = Val(Me.Taak2.Text)
                                    Me.Tbk2.Text = "0.00"
                                    Me.Tak3.Text = Val(Me.Taak3.Text)
                                    Me.Tbk3.Text = "0.00"
                                    Me.Tak4.Text = Val(Me.Taak4.Text)
                                    Me.Tbk4.Text = "0.00"
                                    If Val(sk5) >= Val(Me.TextBoxk10.Text) Then
                                        totak2 = Val(Me.TextBoxk10.Text)
                                        sk1 = Val(Me.Taak1.Text)
                                        sk2 = Val(sk1) + Val(Me.Taak2.Text)
                                        sk3 = Val(sk2) + Val(Me.Taak3.Text)
                                        sk4 = Val(sk3) + Val(Me.Taak4.Text)
                                        sk5 = Val(sk4) + Val(Me.Taak5.Text)
                                        Me.Tak1.Text = Val(Me.Taak1.Text)
                                        Me.Tbk1.Text = "0.00"
                                        totak4 = Val(totak2) - (Val(Me.Taak1.Text) + Val(Me.Taak2.Text) + Val(Me.Taak3.Text) + Val(Me.Taak4.Text))
                                        Me.Tak5.Text = Val(totak4)
                                        Me.Tbk5.Text = Val(Me.Taak5.Text) - Val(Me.Tak5.Text)
                                    ElseIf Val(sk5) < Val(Me.TextBoxk10.Text) Then
                                        totak2 = Val(Me.TextBoxk10.Text)
                                        sk4 = Val(Me.Taak4.Text)
                                        sk5 = Val(sk4) + Val(Me.Taak5.Text)
                                        Me.Tak1.Text = Val(Me.Taak1.Text)
                                        Me.Tbk1.Text = "0.00"
                                        Me.Tak2.Text = Val(Me.Taak2.Text)
                                        Me.Tbk2.Text = "0.00"
                                        Me.Tak3.Text = Val(Me.Taak3.Text)
                                        Me.Tbk3.Text = "0.00"
                                        Me.Tak4.Text = Val(Me.Taak4.Text)
                                        Me.Tbk4.Text = "0.00"
                                        Me.Tak5.Text = Val(Me.Taak5.Text)
                                        Me.Tbk5.Text = "0.00"
                                    End If
                                End If
                            End If
                        End If
                    End If
                Next

                xxk1 += Val(Me.Tak1.Text)
                xxk2 += Val(Me.Tak2.Text)
                xxk3 += Val(Me.Tak3.Text)
                xxk4 += Val(Me.Tak4.Text)
                xxk5 += Val(Me.Tak5.Text)


                Me.TextBoxk1.Text = Val(Me.TextBoxk1.Text) + Val(xxk1)
                Me.TextBoxk2.Text = Val(Me.TextBoxk2.Text) + Val(xxk2)
                Me.TextBoxk3.Text = Val(Me.TextBoxk3.Text) + Val(xxk3)
                Me.TextBoxk4.Text = Val(Me.TextBoxk4.Text) + Val(xxk4)
                Me.TextBoxk5.Text = Val(Me.TextBoxk5.Text) + Val(xxk5)

                Me.TextBoxk7.Text = Val(Me.Tak1.Text) + Val(Me.Tak2.Text) + Val(Me.Tak3.Text) + Val(Me.Tak4.Text) + Val(Me.Tak5.Text) + Val(Me.TextBox7.Text)
                Me.TextBoxk8.Text = Val(Me.TextBoxk1.Text) + Val(Me.TextBoxk2.Text) + Val(Me.TextBoxk3.Text) + Val(Me.TextBoxk4.Text) + Val(Me.TextBoxk5.Text)
                Me.TextBox23.Text = Val(Me.Taak1.Text) + Val(Me.Taak2.Text) + Val(Me.Taak3.Text) + Val(Me.Taak4.Text) + Val(Me.Taak5.Text)
                Me.TextBox24.Text = Val(Me.TextBox7.Text) + Val(Me.TextBoxk8.Text)

                If Val(Me.TextBoxk9.Text) = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                    Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) + Val(Me.TextBox21.Text)
                Else
                    Me.TextBox21.Text = Val(Me.TextBoxk9.Text) - Val(Me.TextBoxk8.Text)
                    If Val(Me.TextBoxk10.Text) < Val(Me.TextBoxk9.Text) Then
                        Me.Textk77.Text = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) - Val(Me.TextBox21.Text)
                    ElseIf Val(Me.TextBoxk10.Text) = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                        Me.Textk77.Text = CDbl(DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) + Val(Me.TextBox21.Text)
                    End If
                End If

                If Me.TextBox1.Text > 0 Then
                    Me.CheckBox1.Checked = True
                    If Me.TextBox2.Text > 0 Then
                        Me.CheckBox2.Checked = True
                    Else
                        Me.CheckBox2.Checked = False
                    End If
                    If Me.TextBox3.Text > 0 Then
                        Me.CheckBox3.Checked = True
                    Else
                        Me.CheckBox3.Checked = False
                    End If
                    If Me.TextBox4.Text > 0 Then
                        Me.CheckBox4.Checked = True
                    Else
                        Me.CheckBox4.Checked = False
                    End If
                    If Me.TextBox5.Text > 0 Then
                        Me.CheckBox5.Checked = True
                    Else
                        Me.CheckBox5.Checked = False
                    End If
                Else
                    Me.CheckBox1.Checked = False
                    If Me.TextBox2.Text > 0 Then
                        Me.CheckBox2.Checked = True
                    Else
                        Me.CheckBox2.Checked = False
                    End If
                    If Me.TextBox3.Text > 0 Then
                        Me.CheckBox3.Checked = True
                    Else
                        Me.CheckBox3.Checked = False
                    End If
                    If Me.TextBox4.Text > 0 Then
                        Me.CheckBox4.Checked = True
                    Else
                        Me.CheckBox4.Checked = False
                    End If
                    If TextBox5.Text > 0 Then
                        CheckBox5.Checked = True
                    Else
                        Me.CheckBox5.Checked = False
                    End If
                End If

            End If
        End If

    End Sub

    Private Sub INSERTRECORDempsolf()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(TBNK1) FROM PTRANSACTION", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            N = 1
        Else
            N = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Dim strsql1 As New SqlCommand("", Consum) With {
            .CommandText = "SELECT TBNK6 FROM Deposits WHERE  TBNK6 = '" & Me.TEXTBOX6.Text & "' and CUser ='" & CUser & "'"
        }
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Consum.Close()

        For II As Integer = 0 To ds1.Tables(0).Rows.Count - 1
            te1 = ds1.Tables(0).Rows(II).Item("TBNK6")
        Next
        Dim SQL As String = "INSERT INTO PTRANSACTION( TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK22, TBNK23, USERNAME, CUser, COUser, da, ne, da1, ne1) VALUES     ( @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK22, @TBNK23, @USERNAME, @CUser, @COUser, @da, @ne, @da1, @ne1)"
        Dim cmd As New SqlCommand(SQL, Consum)
        With cmd.Parameters
            .AddWithValue("@TBNK2", Format(Val(SumAmounTOTALCASHANDCHEQUES2(Me.TEXTBOX6.Text, Me.DataGridView2("TBNK8", Me.DataGridView2.CurrentRow.Index).Value, N)), "0.000"))
            .AddWithValue("@TBNK3", MaxDate.ToString("yyyy-MM-dd"))
            .AddWithValue("@TBNK4", Me.DataGridView2("Co1", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK5", 0)
            .AddWithValue("@TBNK6", te1)
            .AddWithValue("@TBNK7", Format(Val(SumAmounTOTALCASHANDCHEQUES2(Me.TEXTBOX6.Text, Me.DataGridView2("TBNK8", Me.DataGridView2.CurrentRow.Index).Value, N)), "0.000") - DataGridView2("Co1", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK8", Me.DataGridView2("TBNK8", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK9", CDate(ServerDateTime()).ToString("MMdd/yyyy"))
            .AddWithValue("@TBNK10", "شهري")
            .AddWithValue("@TBNK11", Me.TextBox17.Text)
            .AddWithValue("@TBNK12", False)
            .AddWithValue("@TBNK13", False)
            .AddWithValue("@TBNK14", "تحويل اقساط")
            .AddWithValue("@TBNK15", "0.00")
            .AddWithValue("@TBNK16", "0.00")
            .AddWithValue("@TBNK17", True)
            .AddWithValue("@TBNK18", "سحب")
            .AddWithValue("@TBNK22", Me.DataGridView2("TBNK22", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK23", Me.DataGridView2("TBNK23", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@USERNAME", USERNAME)
            .AddWithValue("@CUser", CUser)
            .AddWithValue("@COUser", COUser)
            .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            .AddWithValue("@da1", ServerDateTime.ToString("yyyy-MM-dd"))
            .AddWithValue("@ne1", ServerDateTime.ToString("hh:mm:ss tt"))
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source)
        'End Try
    End Sub
    Private Sub INSERTRECORDempsolf1()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlConnection(constring)
        Dim cmd1 As New SqlCommand("SELECT MAX(TBNK1) FROM PTRANSACTION", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            N = 1
        Else
            N = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Dim strsql1 As New SqlCommand("", Consum) With {
            .CommandText = "SELECT TBNK6 FROM Deposits WHERE  TBNK6 = '" & Me.TextBox19.Text & "' and CUser ='" & CUser & "'"
        }
        Dim ds1 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
        ds1.Clear()
        Adp1.Fill(ds1)


        For II As Integer = 0 To ds1.Tables(0).Rows.Count - 1
            te1 = ds1.Tables(0).Rows(II).Item("TBNK6")
        Next
        Consum.Close()
        Dim SQL As String = "INSERT INTO PTRANSACTION( TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK22, TBNK23, USERNAME, CUser, COUser, da, ne, da1, ne1) VALUES     ( @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK22, @TBNK23, @USERNAME, @CUser, @COUser, @da, @ne, @da1, @ne1)"
        Dim cmd As New SqlCommand(SQL, Consum)
        With cmd.Parameters
            .AddWithValue("@TBNK2", Format(Val(SumAmounTOTALCASHANDCHEQUES2(Val(Me.TextBox19.Text), Me.DataGridView2("TBNK8", Me.DataGridView2.CurrentRow.Index).Value, N)), "0.000"))
            .AddWithValue("@TBNK3", MaxDate.ToString("yyyy-MM-dd"))
            .AddWithValue("@TBNK4", Me.DataGridView2("Co1", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK5", 0)
            .AddWithValue("@TBNK6", te1)
            .AddWithValue("@TBNK7", Format(Val(SumAmounTOTALCASHANDCHEQUES2(Me.TextBox19.Text, Me.DataGridView2("TBNK8", Me.DataGridView2.CurrentRow.Index).Value, N)), "0.000") - Me.DataGridView2("Co1", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK8", Me.DataGridView2("TBNK8", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK9", CDate(ServerDateTime()).ToString("MMdd/yyyy"))
            .AddWithValue("@TBNK10", "شهري")
            .AddWithValue("@TBNK11", Me.TextBox17.Text)
            .AddWithValue("@TBNK12", False)
            .AddWithValue("@TBNK13", False)
            .AddWithValue("@TBNK14", "تحويل اقساط")
            .AddWithValue("@TBNK15", "0.00")
            .AddWithValue("@TBNK16", "0.00")
            .AddWithValue("@TBNK17", True)
            .AddWithValue("@TBNK18", "سحب")
            .AddWithValue("@TBNK22", Me.DataGridView2("TBNK22", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@TBNK23", Me.DataGridView2("TBNK23", Me.DataGridView2.CurrentRow.Index).Value)
            .AddWithValue("@USERNAME", USERNAME)
            .AddWithValue("@CUser", CUser)
            .AddWithValue("@COUser", COUser)
            .AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            .AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            .AddWithValue("@da1", ServerDateTime.ToString("yyyy-MM-dd"))
            .AddWithValue("@ne1", ServerDateTime.ToString("hh:mm:ss tt"))
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message & ex.Source)
        'End Try
    End Sub
    Private Sub UPDATELoansPa()
        Try
            Dim Consum As New SqlConnection(constring)
            If DataGridView1.Rows.Count > 0 Then

                If CDbl(Val(Me.Textk77.Text)) = CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                    ppp = "تم التسديد"
                ElseIf CDbl(Val(Me.Textk77.Text)) < CDbl(Me.DataGridView1("Loa7", Me.DataGridView1.CurrentRow.Index).Value) Then
                    ppp = "لم يسدد كامل الاقسط"
                ElseIf CDbl(Val(Me.Textk77.Text)) = "0" Then
                    ppp = "لم يتم التسديد"
                End If
                Dim kast As Double
                kast = CDbl(Val(Me.Textk77.Text))
                LSet(Me.DataGridView1("Lo25", Me.DataGridView1.CurrentRow.Index).Value, 2)
                Dim PA As String = "WD" & "-" & DataGridView1("Loa1", Me.DataGridView1.CurrentRow.Index).Value
                Dim SQL As New SqlCommand(" UPDATE LoansPa SET   Loa3 = @Loa3, Loa4 = @Loa4, Loa5 = @Loa5, Loa6 = @Loa6, Loa8 = @Loa8, Loa12 = @Loa12, Loa13 = @Loa13, Loa14 = @Loa14     WHERE Loa1 = '" & DataGridView1("Loa1", DataGridView1.CurrentRow.Index).Value & "'", Consum)
                Dim CMD As New SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                With CMD
                    .CommandType = CommandType.Text
                    .Connection = Consum
                    .Parameters.Add("@Loa3", SqlDbType.NVarChar).Value = ppp.Trim.ToLower
                    .Parameters.Add("@Loa4", SqlDbType.NVarChar).Value = Me.TextBox17.Text.Trim
                    .Parameters.Add("@Loa5", SqlDbType.Date).Value = MaxDate.ToString("yyyy-MM-dd")
                    .Parameters.Add("@Loa6", SqlDbType.Float).Value = kast
                    .Parameters.Add("@Loa8", SqlDbType.Float).Value = Me.DataGridView1("Loa8", Me.DataGridView1.CurrentRow.Index).Value - kast
                    .Parameters.Add("@Loa12", SqlDbType.NVarChar).Value = CurrencyJO(kast, "jO")
                    .Parameters.Add("@Loa13", SqlDbType.NVarChar).Value = CurrencyJO(Me.DataGridView1("Loa8", Me.DataGridView1.CurrentRow.Index).Value - kast, "jO")
                    .Parameters.Add("@Loa14", SqlDbType.Bit).Value = True
                    .CommandText = SQL.CommandText
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                CMD.Parameters.Clear()
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Shared Function FEXISTS(ByVal s1 As String, ByVal s2 As Date, ByVal s3 As String, ByVal s4 As String, ByVal s5 As String) As Boolean
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Try
            Dim strsq1 As New SqlCommand("SELECT TBNK9,TBNK3,TBNK11,TBNK10 FROM PTRANSACTION WHERE TBNK9 ='" & s1 & "'" & "AND  TBNK8='" & s3 & "'" & "AND  TBNK11='" & s4 & "'" & "AND  TBNK10='" & s5 & "'" & "AND  year(TBNK3)='" & s2.Year & "'" & "AND  month(TBNK3)='" & s2.Month & "'" & "AND  day(TBNK3)='" & s2.Day & "'", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlDataAdapter(strsq1)
            ds1.Clear()
            Adp1.Fill(ds1)
            Adp1.Dispose()
            If ds1.Tables(0).Rows.Count = 0 Then
                FEXISTS = False
            Else
                FEXISTS = True
            End If
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
        Return FEXISTS
    End Function
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "رقم" & Me.Taa5.Text & "   بتاريخ:" & CDbl(Me.DataGridView1("Loa2", Me.DataGridView1.CurrentRow.Index).Value)
        ExResult += "   حساب " & nem.Trim & vbNewLine
        Me.Text = ExResult
    End Sub

    Private Sub SaveMOVESDATARecord()
        Try
            Dim Box, Box1, Box2, Box3, Box4, Box5, Box6, Box7, Box8, Box9, Box10, Box11 As Integer
            nem = " سداد اقساط من حساب الاعضاء"
            nem1 = "سداد اقساط من حساب الاعضاء"
            nem2 = "سداد اقساط من حساب الاعضاء"
            nem3 = "سداد اقساط من حساب الاعضاء"
            nem4 = "سداد اقساط من حساب الاعضاء"
            nem5 = "سداد اقساط من حساب الاعضاء"
            nem7 = "سداد اقساط من حساب الاعضاء"
            nem9 = "سداد اقساط من حساب الاعضاء"
            pp = "1"
            Dim Consum As New SqlConnection(constring)
            Dim kast As Double
            kast = CDbl(Val(Textk7.Text))
            Dim strsq1 As New SqlCommand("SELECT MOV1  FROM MOVES  WHERE (MOVES.MOV11)='" & Me.TextBox15.Text & "'", Consum)
            Dim ds As New DataSet
            Dim Adp1 As New SqlDataAdapter(strsq1)
            ds.Clear()
            Adp1.Fill(ds, "MOVES")

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboBox1.Text, 1)
            Box = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboBox1.Text, 1)
            Box1 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboBox2.Text, 1)
            Box2 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboBox2.Text, 1)
            Box3 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboBox3.Text, 1)
            Box4 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboBox3.Text, 1)
            Box5 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboBox4.Text, 1)
            Box6 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboBox4.Text, 1)
            Box7 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboBox5.Text, 1)
            Box8 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboBox5.Text, 1)
            Box9 = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Me.ComboBox6.Text, 1)
            Box10 = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Me.ComboBox6.Text, 1)
            Box11 = ID_Nam
            Dim strSQL As New SqlCommand("", Consum)
            Dim CMD As New SqlCommand
            With strSQL

                If Me.CheckBox1.Checked = True And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = False And CheckBox4.Checked = False And Me.CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & Me.TextBox1.Text & "','" & 0 & "','" & nem.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 1 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem5.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = True And Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = False And Me.CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TextBox2.Text & "','" & 0 & "','" & nem.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 1 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem5.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 1 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem5.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = True And Me.CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & Me.TextBox4.Text & "','" & 0 & "','" & nem.Trim & "','" & Box7.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 1 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem5.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.CheckBox1.Checked = False And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = False And Me.CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & Me.TextBox5.Text & "','" & 0 & "','" & nem.Trim & "','" & Box9.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 1 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem5.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    '=====================================================
                ElseIf Me.CheckBox1.Checked = True And Me.CheckBox2.Checked = True And Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = False And Me.CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & Me.TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & Me.ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & Me.TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.CheckBox1.Checked = True And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = True And Me.CheckBox4.Checked = False And Me.CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & Me.TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & Me.ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & Me.TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.CheckBox1.Checked = True And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = False And CheckBox4.Checked = True And Me.CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & Me.ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & Me.ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & Me.TextBox4.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & Me.ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf Me.CheckBox1.Checked = True And Me.CheckBox2.Checked = False And Me.CheckBox3.Checked = False And Me.CheckBox4.Checked = False And Me.CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    '=====================================================
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                               & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = False And CheckBox4.Checked = True And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                               & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                               & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                               & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                               & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                        & pp.ToString + 3 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem4.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 4 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                           & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                        & pp.ToString + 3 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem9.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 4 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = False And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                           & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                                           & pp.ToString + 2 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem4.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 3 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 4 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = False And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                           & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                        & pp.ToString + 3 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem4.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 4 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf CheckBox1.Checked = True And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                         & pp.ToString & "','" & ComboBox1.Text.Trim & "','" & Box.ToString.Trim & "','" & TextBox1.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                        & pp.ToString + 3 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem4.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                       & pp.ToString + 4 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem4.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 5 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & Me.TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    '=====================================================
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = False And CheckBox4.Checked = True And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = False And CheckBox4.Checked = False And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox3.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = False And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = True And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                           & pp.ToString & "','" & ComboBox2.Text.Trim & "','" & Box2.ToString.Trim & "','" & TextBox2.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box3.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                        & pp.ToString + 3 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem4.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 4 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    '=====================================================
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = False Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = True And CheckBox4.Checked = False And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = True And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox3.Text.Trim & "','" & Box4.ToString.Trim & "','" & TextBox3.Text & "','" & 0 & "','" & nem1.Trim & "','" & Box5.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box7.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                            & pp.ToString + 2 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem3.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()


                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 3 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    '=====================================================
                ElseIf CheckBox1.Checked = False And CheckBox2.Checked = False And CheckBox3.Checked = False And CheckBox4.Checked = True And CheckBox5.Checked = True Then
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                              & pp.ToString & "','" & ComboBox4.Text.Trim & "','" & Box6.ToString.Trim & "','" & TextBox4.Text & "','" & 0 & "','" & nem7.Trim & "','" & Box1.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                             & pp.ToString + 1 & "','" & ComboBox5.Text.Trim & "','" & Box8.ToString.Trim & "','" & TextBox5.Text & "','" & 0 & "','" & nem2.Trim & "','" & Box9.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()

                    .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                    & pp.ToString + 2 & "','" & ComboBox6.Text.Trim & "','" & Box10.ToString.Trim & "','" & 0 & "','" & kast & "','" & nem.Trim & "','" & Box11.ToString.Trim & "','" & TextBox17.Text.Trim & "','" & CDate(ServerDateTime()).ToString("MMdd/yyyy") & "','" & False & "','" & T2.ToString.Trim & "')"
                    CMD.CommandType = CommandType.Text
                    CMD.Connection = Consum
                    CMD.CommandText = strSQL.CommandText
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    Consum.Close()
                End If
            End With
        Catch er As Exception
            MessageBox.Show(er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveMOVES()
        Try
            Dim Consum As New SqlConnection(constring)
            SEARCHDATA.MAXIDMOVES()
            Dim SQL As New SqlCommand("INSERT INTO MOVES ( MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     ( @MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.Int).Value = T1.ToString.Trim
                .Parameters.Add("@MOV2", SqlDbType.Int).Value = T2.ToString
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = MaxDate.ToString("yyyy-MM-dd")
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = "سداد اقساط من حساب الاعضاء"
                .Parameters.Add("@MOV5", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Me.TextBox8.Text
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Me.TextBox8.Text
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = "قيد"
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = "WD"
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = Me.TextBox17.Text.Trim
                .Parameters.Add("@MOV12", SqlDbType.NVarChar).Value = False
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
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
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", TextBox11, BS, True)
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
            MYDELETERECORD("MOVESDATA", "MOV2", TextBox11, BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub


    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown1.ValueChanged
        On Error Resume Next
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NumericUpDown1.Value, Me.ComboBox1)
    End Sub


    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown2.ValueChanged
        On Error Resume Next
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NumericUpDown2.Value, Me.ComboBox2)
    End Sub
    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown3.ValueChanged
        On Error Resume Next
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NumericUpDown3.Value, Me.ComboBox3)
    End Sub
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown4.ValueChanged
        On Error Resume Next
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NumericUpDown4.Value, Me.ComboBox4)
    End Sub
    Private Sub NumericUpDown5_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown5.ValueChanged
        On Error Resume Next
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NumericUpDown5.Value, Me.ComboBox5)
    End Sub
    Private Sub NumericUpDown6_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NumericUpDown6.ValueChanged
        On Error Resume Next
        FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", NumericUpDown6.Value, Me.ComboBox6)
    End Sub
    Private Sub ButtonTransferOfInstallmentsReceived_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferOfInstallmentsReceived.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        Call MangUsers()
        If LockAddRow = False Then
            Me.ButtonTransferOfInstallmentsReceived.Enabled = False
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        ElseIf LockSave = False Then
            Me.ButtonTransferOfInstallmentsReceived.Enabled = False
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Ch1.Checked = False Then
            Me.SEARCHDATAITEMS10()
            Me.Ch1.Checked = True
            Me.ToolStripButton2.Enabled = False
        End If

    End Sub


End Class