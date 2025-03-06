Option Explicit Off

Imports System.Data.SqlClient

Public Class Form_mabeat
<<<<<<< HEAD
    Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Dim dt As New DataTable
    Public WithEvents BS As New BindingSource
    Dim ds1 As New DataSet
    Dim ds2 As New DataSet
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    ReadOnly RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Public TEST As Boolean = False

    Private Sub Ubdatdata()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If DataGriaddTalb.Rows.Count > 0 Then
                For i As Integer = 0 To DataGriaddTalb.Rows.Count - 1
                    Dim row As DataGridViewRow = DataGriaddTalb.Rows(i)
                    If row.IsNewRow Then Continue For

<<<<<<< HEAD
                    Dim SQL As New SqlCommand("update TodaySales set Chk=@Chk,Chk1=@Chk1,Chk2=@Chk2,CB1=@CB1, USERNAME = @USERNAME, Auditor = @Auditor, da1 = @da1, ne1 = @ne1  where DataTS='" & Me.Textdaee.Text.Trim & "'", Consum)
                    Dim CMD As New SqlCommand(SQL.CommandText) With {
=======
                    Dim SQL As New SqlClient.SqlCommand("update TodaySales set Chk=@Chk,Chk1=@Chk1,Chk2=@Chk2,CB1=@CB1, USERNAME = @USERNAME, Auditor = @Auditor, da1 = @da1, ne1 = @ne1  where DataTS='" & Me.Textdaee.Text.Trim & "'", Consum)
                    Dim CMD As New SqlClient.SqlCommand(SQL.CommandText) With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .Parameters.AddWithValue("@Chk", Convert.ToInt32(Me.CheckInternalAuditorER.Checked)) '
                        .Parameters.AddWithValue("@Chk1", Convert.ToInt32(Me.CheckTransferofAccounts.Checked)) '
                        .Parameters.AddWithValue("@Chk2", Convert.ToInt32(Me.CheckTransferofAccounts1.Checked)) '
                        .Parameters.AddWithValue("@CB1", Me.ComboCB1.Text) '
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
                    End With
                    If Consum.State = ConnectionState.Open Then Consum.Close()
                    Consum.Open()
                    CMD.ExecuteNonQuery()
                    CMD.Parameters.Clear()
                    Consum.Close()
                Next
            End If
            MsgBox("تم التعديل", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Ubdatdata2()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim SQL As New SqlCommand("update ASTRGA_ASTRDA set Chk=@Chk,Chk1=@Chk1, USERNAME = @USERNAME, Auditor = @Auditor, da1 = @da1, ne1 = @ne1  where DataD10='" & Me.Textdaee.Text & "'", Consum)
            Dim CMD As New SqlCommand(SQL.CommandText) With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim SQL As New SqlClient.SqlCommand("update ASTRGA_ASTRDA set Chk=@Chk,Chk1=@Chk1, USERNAME = @USERNAME, Auditor = @Auditor, da1 = @da1, ne1 = @ne1  where DataD10='" & Me.Textdaee.Text & "'", Consum)
            Dim CMD As New SqlClient.SqlCommand(SQL.CommandText) With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .Parameters.AddWithValue("@Chk", Convert.ToInt32(Me.CheckInternalAuditorER1.Checked)) '
                .Parameters.AddWithValue("@Chk1", Convert.ToInt32(Me.CheckTransferofAccounts2.Checked)) '
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
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            CMD.Parameters.Clear()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Public Sub BuakrT_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BuakrT.Click
=======
    Public Sub BuakrT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BuakrT.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.TEST = True
        Me.CircularProgress1.Visible = True
        Me.CircularProgress1.IsRunning = True
        Me.CircularProgress1.Value = 0
        Me.BackW1.WorkerSupportsCancellation = True
        Me.BackW1.WorkerReportsProgress = True
        Me.BackW1.RunWorkerAsync()
    End Sub

<<<<<<< HEAD
    Private Sub FrmDeposits_Shown(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Shown
=======
    Private Sub FrmDeposits_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage3.Show()
        Me.TabPage1.Show()
    End Sub

    Public Sub Form_mabeat_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

<<<<<<< HEAD
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
=======
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TEST = False
        Me.CircularProgress1.Visible = True
        Me.CircularProgress1.IsRunning = True
        Me.CircularProgress1.Value = 0
        Me.BackW1.WorkerSupportsCancellation = True
        Me.BackW1.WorkerReportsProgress = True
        Me.BackW1.RunWorkerAsync()
    End Sub

    Private Sub BackW1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW1.DoWork
        Try
            If Me.TEST = False Then
                Me.Textdaee1.Value = MaxDate.ToString("yyyy-MM-dd")
            End If
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            dt = New DataTable
            ds = New DataSet
            Me.SqlDataAdapter1 = New SqlDataAdapter("SELECT TS1,TS2,TS3,TS5,TS6 ,TS14 FROM  TodaySales  where CUser='" & CUser & "'AND DataTS = '" & Format(Me.Textdaee1.Value, "yyyy-MM-dd") & "' AND ID >'" & 0 & "'  ", Consum)
            Me.SqlDataAdapter1.Fill(dt)
            Me.SqlDataAdapter1.Fill(ds)

            Me.BS.DataSource = ds.Tables("TodaySales")

            DataGriaddTalb.DataSource = Nothing

            If dt.Rows.Count > 0 Then
                Me.DataGriaddTalb.DataSource = Me.dt
                Me.DataGriaddTalb.Columns(0).HeaderText = "اسم الصنف"
                Me.DataGriaddTalb.Columns(1).HeaderText = "عدد الصنف"
                Me.DataGriaddTalb.Columns(3).HeaderText = "سعر الصنف"
                Me.DataGriaddTalb.Columns(2).HeaderText = "المجموع"
                Me.DataGriaddTalb.Columns(4).HeaderText = "الخصم"
                Me.DataGriaddTalb.Columns(5).HeaderText = "سعر الشراء"

                Me.TextTotalSales.EditValue = DataGriaddTalb.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells(2).Value))
                Me.TextTotalDiscount.EditValue = DataGriaddTalb.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells(4).Value))
                Me.TextTotalPurchasePrice.EditValue = DataGriaddTalb.Rows.Cast(Of DataGridViewRow).Sum(Function(t) Val(t.Cells(5).Value))
            End If
            SqlDataAdapter1.Dispose()
        Catch ex As Exception
<<<<<<< HEAD
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "BackW1_DoWork مبيعات اليوم")
=======
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "2 مبيعات اليوم")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Try
    End Sub

    Private Sub BackW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW1.RunWorkerCompleted
        Try
            SalesReturns()
<<<<<<< HEAD
=======
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpComboDebitAccount.Value, Me.ComboDebitAccount)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpCreditAccount.Value, Me.ListCreditAccount)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpSalesReturns.Value, Me.ListSalesReturns)
            FILLCOMBOBOX2("ACCOUNTSTREE", "account_name", "acc", Me.NUpDiscountAccount.Value, Me.ListDiscountAccount)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            FILLCOMBOBOX3("TodaySales", "TS1", "CUser", CUser, "DataTS", Trim(Me.Textdaee.Text), Me.Co0)
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            Call MangUsers()
            Me.TextFullInvoiceNumber1.Text = Me.TextInvoiceNumber.Text & Me.TextInvoiceNumber1.Text
            Me.TextMovementSymbol.Text = "QR" & "-" & CDate(Me.Textdaee.Text.Trim).ToString("yyyy/MMdd")
            Me.InternalAuditorType()
            PurchSales_Check = True
            AccountsEnquiry()
            Me.SEARCHTodaySales()
            Me.SEARCHASTRGA_ASTRDA()
            Me.SEARCHDATAITEMS8()
            'Dim X As Double = Val(TextTotalPurchasePrice.EditValue)
            'Me.TextTotalPurchasePrice.EditValue = Val(X) + Val(TextCostGoodsSold.EditValue)

            TextFundValue.EditValue = Val(TextTotalSales.EditValue) - (Val(Me.TextTotalSalesReturns.EditValue) + Val(Me.TextTotalDiscount.EditValue))
<<<<<<< HEAD
=======
            FILLCOMBOBOX3("TodaySales", "TS1", "CUser", CUser, "DataTS", Trim(Me.Textdaee.Text), Me.Co0)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.SHOWBUTTON()
            Me.InternalAuditorType()
            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If
            Me.CircularProgress1.IsRunning = False
            Me.CircularProgress1.Visible = False
        Catch ex As Exception
<<<<<<< HEAD
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "مبيعات اليوم BackW1_RunWorkerCompleted ")
=======
            MsgBox(ex.Message, MsgBoxStyle.Information + MsgBoxStyle.MsgBoxRight = True + MsgBoxStyle.MsgBoxRtlReading = True + MsgBoxStyle.OkOnly, "مبيعات اليوم 3 ")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Try

    End Sub

    Private Sub SEARCHTodaySales()
        On Error Resume Next
        Me.CircularProgress3.Visible = True
        Me.CircularProgress3.IsRunning = True
        Me.CircularProgress3.Value = 0
        Me.BackW3.WorkerSupportsCancellation = True
        Me.BackW3.WorkerReportsProgress = True
        Me.BackW3.RunWorkerAsync()
    End Sub

    Private Sub BackW3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW3.DoWork
        Dim T As Boolean
        T = True
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("select ID, TS9, Chk, chk1, Chk2, Chk3  from TodaySales where DataTS =  '" & Me.Textdaee.Text.Trim & "' AND CUser='" & CUser & "'", Consum)
        ds1 = New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("select ID, TS9, Chk, chk1, Chk2, Chk3  from TodaySales where DataTS =  '" & Me.Textdaee.Text.Trim & "' AND CUser='" & CUser & "'", Consum)
        ds1 = New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        ds1.Clear()
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Adp1.Fill(ds1, "TodaySales")
        Consum.Close()
    End Sub

    Private Sub BackW3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW3.RunWorkerCompleted

        If ds1.Tables(0).Rows.Count > 0 Then
            Me.TodaySalesID.Text = ds1.Tables(0).Rows(0).Item(0)
            Me.TextInvoiceNumber1.Text = ds1.Tables(0).Rows(0).Item(1)
            Me.CheckInternalAuditorER.Checked = ds1.Tables(0).Rows(0).Item(2)
            Me.CheckTransferofAccounts.Checked = ds1.Tables(0).Rows(0).Item(3)
            Me.CheckTransferofAccounts1.Checked = ds1.Tables(0).Rows(0).Item(4)

            'Me.ComboCB1.Text = ds1.Tables(0).Rows(0).Item(5)
        Else
            Me.CheckInternalAuditorER.Checked = False
            Me.CheckTransferofAccounts.Checked = False
            Me.CheckTransferofAccounts1.Checked = False

            'Me.ComboCB1.Text = ""
        End If
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Auditor("TodaySales", "USERNAME", "ID", Me.TodaySalesID.Text, "")
        Logentry = Uses
        Me.CircularProgress3.IsRunning = False
        Me.CircularProgress3.Visible = False
    End Sub


    Private Sub SEARCHASTRGA_ASTRDA()
        On Error Resume Next
        Me.CircularProgress4.Visible = True
        Me.CircularProgress4.IsRunning = True
        Me.CircularProgress4.Value = 0
        Me.BackW4.WorkerSupportsCancellation = True
        Me.BackW4.WorkerReportsProgress = True
        Me.BackW4.RunWorkerAsync()
    End Sub
    Private Sub BackW4_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW4.DoWork
        Dim T As Boolean
        T = True
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("select ID, NumFatorh12, Chk, chk1, Chk2 from ASTRGA_ASTRDA where DataD10 =  '" & Me.Textdaee.Text.Trim & "' AND CUser='" & CUser & "'", Consum)
        ds2 = New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("select ID, NumFatorh12, Chk, chk1, Chk2 from ASTRGA_ASTRDA where DataD10 =  '" & Me.Textdaee.Text.Trim & "' AND CUser='" & CUser & "'", Consum)
        ds2 = New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        ds2.Clear()
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Adp1.Fill(ds2, "ASTRGA_ASTRDA")
        Consum.Close()
    End Sub

    Private Sub BackW4_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW4.RunWorkerCompleted
        If ds2.Tables(0).Rows.Count > 0 Then
            ASTRGAID.Text = ds2.Tables(0).Rows(0).Item(0)
            Me.TextFullInvoiceNumber.Text = ds2.Tables(0).Rows(0).Item(1)
            Me.CheckInternalAuditorER1.Checked = ds2.Tables(0).Rows(0).Item(2)
            Me.CheckTransferofAccounts2.Checked = ds2.Tables(0).Rows(0).Item(3)
        Else
            Me.CheckInternalAuditorER1.Checked = False
            Me.CheckTransferofAccounts2.Checked = False
        End If
        Auditor("ASTRGA_ASTRDA", "USERNAME", "ID", Me.ASTRGAID.Text, "")
        Logentry = Uses
        Me.CircularProgress4.IsRunning = False
        Me.CircularProgress4.Visible = False
    End Sub
    Sub ListFill()
        On Error Resume Next
        'Me.BackW5.WorkerSupportsCancellation = True
        'Me.BackW5.WorkerReportsProgress = True
        'Me.BackW5.RunWorkerAsync()
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim dp As New SqlDataAdapter("select  DISTINCT TS1 from TodaySales where DataTS = '" & Me.Textdaee.Text.Trim & "'AND CUser='" & CUser & "'", Consum)
        Dim ds As New DataSet
        ds.Clear()
        dp.Fill(ds)
        Co0.DataSource = ds.Tables(0)
        Co0.DisplayMember = "TS1"
    End Sub
    Private Sub BackW5_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW5.DoWork


    End Sub

    Private Sub BackW5_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW5.RunWorkerCompleted

    End Sub
    Private Sub SEARCHDATAITEMS8()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim N1 As Double
        Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N1 As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N1 = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N1)), "0.000")
        AutoEx()
    End Sub
    Private Sub SalesReturns()
        Try
<<<<<<< HEAD
            Dim Adp1 As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("select sum(SumMANTG5), sum(ALbaky16) from ASTRGA_ASTRDA where CUser ='" & CUser & "' AND DataD10 =  '" & Format(Me.Textdaee1.Value, "yyyy-MM-dd") & "'", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlDataAdapter(strsq1)
=======
            Dim Adp1 As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq1 As New SqlClient.SqlCommand("select sum(SumMANTG5), sum(ALbaky16) from ASTRGA_ASTRDA where CUser ='" & CUser & "' AND DataD10 =  '" & Format(Me.Textdaee1.Value, "yyyy-MM-dd") & "'", Consum)
            Dim ds1 As New DataSet
            Adp1 = New SqlClient.SqlDataAdapter(strsq1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp1.Fill(ds1, "ASTRGA_ASTRDA")
            If ds1.Tables(0).Rows.Count > 0 Then
                Me.TextTotalSalesReturns.EditValue = ds1.Tables(0).Rows(0)(0).ToString
                Me.TextCostGoodsSold.EditValue = ds1.Tables(0).Rows(0)(1).ToString
            Else
                Me.TextTotalSalesReturns.EditValue = "0.000"
                Me.TextCostGoodsSold.EditValue = "0.000"
            End If
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Adp1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSalesReturns", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = Me.Text & " " & " رقم" & " " & ":" & " " & Me.TextMovementSymbol.Text & " " & "بتاريخ" & " " & ":" & " " & Me.Textdaee.Text & " "
        ExResult += "مثبتة بوثيقة رقم" & " " & ":" & " " & Me.TextMovementSymbol.Text & " " & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub
    Private Sub Co0_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Co0.SelectedIndexChanged
        Dim X1 As Double
        For A1 As Integer = 0 To DataGriaddTalb.RowCount - 1
            If Me.DataGriaddTalb.Item(0, A1).Value.ToString.Trim = Co0.Text.Trim Then
                X1 += Me.DataGriaddTalb.Rows(A1).Cells(1).Value
            End If
        Next
        Me.Texm.Text = X1.ToString("#,##0.###")
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
=======
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        AutoComplete(Me.ComboDebitAccount, e, )
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
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf Me.PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureBox2.Visible = False
            Me.PictureBox5.Visible = False
        End If

    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
=======
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds2.Tables(0).Rows.Count > 0 Then
            account_noF = ds2.Tables(0).Rows(0).Item(0)
            ACCF = ds2.Tables(0).Rows(0).Item(2)
            account_nameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            account_noF = ""
            ACCF = ""
            account_nameF = ""
        End If
    End Sub

    Private Sub DELETEDATMOVESDATA()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM MOVES WHERE MOV2=" & Me.TextMovementRestrictions.Text.Trim, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM MOVES WHERE MOV2=" & Me.TextMovementRestrictions.Text.Trim, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA1()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM MOVESDATA WHERE MOV2=" & Me.MOVESFalseDELET.Text.Trim, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM MOVESDATA WHERE MOV2=" & Me.MOVESFalseDELET.Text.Trim, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()
            'MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA2()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM MOVESDATA WHERE MOV2=" & Me.MOVESTrueDELET.Text, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM MOVESDATA WHERE MOV2=" & Me.MOVESTrueDELET.Text, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()
            'MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA3()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM MOVES WHERE MOV2=" & Me.TextMovementRestrictions1.Text.Trim, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM MOVES WHERE MOV2=" & Me.TextMovementRestrictions1.Text.Trim, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()
            'MYDELETERECORD("MOVES", "MOV2", Me.TextBox15, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA1b()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM MOVESDATA WHERE MOV2=" & Me.TextMovementRestrictions2.Text.Trim, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM MOVESDATA WHERE MOV2=" & Me.TextMovementRestrictions2.Text.Trim, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()
            'MYDELETERECORD("MOVESDATA", "MOV2", Me.TextBox43, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATMOVESDATA2b()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM MOVES WHERE MOV2=" & Me.TextMovementRestrictions2.Text.Trim, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM MOVES WHERE MOV2=" & Me.TextMovementRestrictions2.Text.Trim, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()
            'MYDELETERECORD("MOVES", "MOV2", Me.TextBox43, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATAempsolf()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim CMD2 As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
<<<<<<< HEAD
            Dim SQL2 As New SqlCommand("DELETE FROM CASHIER WHERE CSH1=" & Me.TextFundMovementNumber.Text.Trim, Consum)
=======
            Dim SQL2 As New SqlClient.SqlCommand("DELETE FROM CASHIER WHERE CSH1=" & Me.TextFundMovementNumber.Text.Trim, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            CMD2.CommandText = SQL2.CommandText
            CMD2.ExecuteNonQuery()

            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        DebitAccount_No = Nothing
        CredAccount_NO = Nothing

        TestkeyAccounts(keyAccounts.GetValue("SalesMergeAccount_No", SalesMergeAccount_No))
        If TestkeyAccounts_Check = True Then
            SalesMergeAccountS_NO = keyAccounts.GetValue("SalesMergeAccount_No", SalesMergeAccount_No) 'حساب مرتجع المبيعات
        End If
        TestkeyAccounts(keyAccounts.GetValue("SalesAccount_No", SalesAccount_No))
        If TestkeyAccounts_Check = True Then
            CredAccount_NO = keyAccounts.GetValue("SalesAccount_No", SalesAccount_No)
        End If

        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No
        GetDiscount_B(Val(TextTotalDiscount.EditValue))

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", FundAccount_No, 1)
        FundAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", FundAccount_No, 1)
        CodAccount = ID_Nam

        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", SalesMergeAccountS_NO, 1)
        SalesMergeAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", SalesMergeAccountS_NO, 1)
        CodSalesMergeAccount = ID_Nam


        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
        CredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
        CredAccount_Cod = ID_Nam

        'Me.TextFundValue.Enabled = True
        TextFundValue.EditValue = Val(TextTotalSales.EditValue) - (Val(Me.TextTotalSalesReturns.EditValue) + Val(Me.TextTotalDiscount.EditValue))
        LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"

        If Val(TextTotalSales.EditValue) = Val(Me.TextTotalSalesReturns.EditValue) Then
            TextFundValue.EditValue = 0
            TextTotalDiscount.EditValue = "0.000"
            ComboDebitAccount.Text = Nothing
        End If

        If TextFundValue.EditValue > 0 Then
            ComboDebitAccount.Text = FundAccount_Name
            NUpComboDebitAccount.Value = CodAccount
        End If

        TextCreditAccount.Text = CredAccount_Name
        NUpCreditAccount.Value = CredAccount_Cod

        If Val(Me.TextTotalSalesReturns.EditValue) > 0 Then
            TextSalesReturns.Text = SalesMergeAccount_Name
            NUpSalesReturns.Value = CodSalesMergeAccount
            NUpSalesReturns.Enabled = True
            PicSalesReturns.Enabled = True
        Else
            TextSalesReturns.Text = Nothing
            NUpSalesReturns.Enabled = False
            PicSalesReturns.Enabled = False
        End If
        If Val(Me.TextTotalDiscount.EditValue) > 0 Then
            TextDiscountAccount.Text = DiscountAccountAE_Name
            NUpDiscountAccount.Value = DiscountAccount_Cod
        Else
            TextDiscountAccount.Text = Nothing
            NUpDiscountAccount.Enabled = False
            PicDiscountAccount.Enabled = False
        End If
    End Sub

    Private Sub TransforAccountsSalesReturns()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing
            DebitAccount_No = keyAccounts.GetValue("SalesAccount_No", SalesAccount_No) ' المبيعات
            CredAccount_NO = keyAccounts.GetValue("SalesMergeAccount_No", SalesMergeAccount_No) 'حساب مرتجع المبيعات

            If keyAccounts.GetValue("SalesAccount_No", SalesAccount_No) = Nothing Then
                MsgBox("رقم حساب المبيعات فارغ")
                Exit Sub
            End If
            If keyAccounts.GetValue("SalesMergeAccount_No", SalesMergeAccount_No) = Nothing Then
                MsgBox("رقم حساب حساب مرتجع المبيعات فارغ")
                Exit Sub
            End If


            SEARCHDATA.MAXIDMOVES()
            nem = " فاتورة مبيعات نقدي مسترجعة" & "_" & Me.TextMovementSymbol.Text
            nem1 = "فاتورة مبيعات نقدي" & "_" & Me.TextMovementSymbol.Text

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam


            AccountingEntries(T1, T2, MaxDate.ToString("yyyy-MM-dd"), nem, False, TextTotalSalesReturns.EditValue, TextTotalSalesReturns.EditValue, T3, "قيد", "QRB", TextMovementSymbol.Text, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextTotalSalesReturns.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TextTotalSalesReturns.EditValue, nem, CredAccount_Cod, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)

        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccountsSalesReturns", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub TransforAccounts()
        Try
            AccountsEnquiry()

            SEARCHDATA.MAXIDMOVES()
            TransferToAccounts_Check = True
            nem = "فاتورة مبيعات " & "_" & Me.TextMovementSymbol.Text
            nem1 = "فاتورة مبيعات نقدي" & "_" & Me.TextMovementSymbol.Text
            nem2 = "استرجاع فاتورة مبيعات نقدي " & "_" & Me.TextMovementSymbol.Text
            nem3 = "خصم مسموح به لفاتورة مبيعات رقم" & "_" & Me.TextTotalDiscount.EditValue
            PMO2 = 1

            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
            CodAccount = ID_Nam

            AccountingEntries(T1, T2, MaxDate.ToString("yyyy-MM-dd"), nem, True, TextTotalSales.EditValue, TextTotalSales.EditValue, T3, "قبض", "QRA", TextMovementSymbol.Text, False)
            If TextFundValue.EditValue > 0 Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, Accounts_NO, TextFundValue.EditValue, 0, nem, CodAccount, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)

                Insert_CASHIER(MaxDate.ToString("yyyy-MM-dd"), "قبض", TextMovementSymbol.Text, TextFundValue.EditValue, 0, Me.Text,
                                                                                            "من حساب حركة المبيعات اليومية", False, TextFullInvoiceNumber.Text & "0",
                                                                                            False, True, ComboCB1.Text, CB2)
            End If
            If Val(TextTotalSalesReturns.EditValue) > 0 Then
                DetailsAccountingEntries(PMO2 + 1, TextSalesReturns.Text, SalesMergeAccountS_NO, TextTotalSalesReturns.EditValue, 0, nem2, CodSalesMergeAccount, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)
            Else
                Val(PMO2 - 1)
            End If
            If Val(TextTotalDiscount.EditValue) > 0 Then
                DetailsAccountingEntries(PMO2 + 2, TextDiscountAccount.Text, PurchSalesDiscount_No, TextTotalDiscount.EditValue, 0, nem3, DiscountAccount_Cod, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)
            Else
                Val(PMO2 - 1)
            End If
            DetailsAccountingEntries(PMO2 + 3, TextCreditAccount.Text, CredAccount_NO, 0, TextTotalSales.EditValue, nem, CredAccount_Cod, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)

        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccounts", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub TransforAccountsSalesCost()
        Try
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            DebitAccount_No = Nothing
            CredAccount_NO = Nothing
            DebitAccount_No = keyAccounts.GetValue("CalculatingCostGoodsSold_No", CalculatingCostGoodsSold_No) 'حساب تكلفه البضاعه المباعه
            CredAccount_NO = keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No) 'حساب مخزون البضاعة
            If keyAccounts.GetValue("CalculatingCostGoodsSold_No", CalculatingCostGoodsSold_No) = Nothing Then
                MsgBox("رقم حساب تكلفه البضاعه المباعه فارغ")
                Exit Sub
            End If
            If keyAccounts.GetValue("MerchandiseStockAccount_No", MerchandiseStockAccount_No) = Nothing Then
                MsgBox("رقم حساب مخزون البضاعة فارغ")
                Exit Sub
            End If

            SEARCHDATA.MAXIDMOVES()
            nem = "فاتورة مبيعات " & "_" & Me.TextMovementSymbol.Text
            nem1 = "فاتورة مبيعات نقدي" & "_" & Me.TextMovementSymbol.Text

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", DebitAccount_No, 1)
            DebitAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", DebitAccount_No, 1)
            DebitAccount_Cod = ID_Nam

            GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", CredAccount_NO, 1)
            CredAccount_Name = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", CredAccount_NO, 1)
            CredAccount_Cod = ID_Nam


            AccountingEntries(T1, T2, MaxDate.ToString("yyyy-MM-dd"), nem, False, TextTotalPurchasePrice.EditValue, TextTotalPurchasePrice.EditValue, T3, "قيد", "QR", TextMovementSymbol.Text, False)
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, TextTotalPurchasePrice.EditValue, 0, nem1, DebitAccount_Cod, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, TextTotalPurchasePrice.EditValue, nem, CredAccount_Cod, TextMovementSymbol.Text, CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd"), False, T2)

        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorTransforAccountsSalesCost", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                OptionsTransforAccountsTo("نقدا", ComboDebitAccount.Text, TextCreditAccount.Text)
                PanelAccount.Enabled = True
            Else
                Check_OptionsTransforAccounts.Checked = False
                PanelAccount.Enabled = False
            End If
        Else
            PanelAccount.Enabled = False
        End If
    End Sub
    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            If Val(Me.TextTotalSalesReturns.EditValue) > 0 Then

                Connection.ACONET1.Add(String.Concat(New String() {Me.TextSalesReturns.Text}))
            End If
            If Val(Me.TextTotalDiscount.EditValue) > 0 Then
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextDiscountAccount.Text}))
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

<<<<<<< HEAD
    Private Sub TRANSFERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
=======
    Private Sub TRANSFERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If

            If TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Me.ListCreditAccount.Visible = True
                Exit Sub
            End If
            Me.Button1_Click(sender, e)
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.Text)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Me.TextMovementSymbol.Text = "QR" & "-" & CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd")
            Dim resault As Integer
            If Me.CheckTransferofAccounts.Checked = False Then
                resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferofAccounts.Checked = True
                    Me.CheckTransferofAccounts2.Checked = True
                    TransforAccounts()
                    TransforAccountsSalesReturns()
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions.Text = Nothing Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        DELETEDATMOVESDATA2()
                        DELETEDATMOVESDATA3()
                    End If
                    DELETEDATMOVESDATA1b()
                    DELETEDATMOVESDATA2b()
                    If Me.TextFundMovementNumber.Text = Nothing Then
                        MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                    Else
                        DELETEDATAempsolf()
                    End If
                    TransforAccounts()
                    TransforAccountsSalesReturns()
                    Me.AccountingprocedureA()
                    Insert_Actions(Me.TextMovementSymbol.Text, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                Else
                    resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferofAccounts.Checked = False
                        Me.CheckTransferofAccounts2.Checked = False
                        Me.DELETEDATAempsolf()
                        DELETEDATMOVESDATA2()
                        DELETEDATMOVESDATA3()
                        DELETEDATMOVESDATA1b()
                        DELETEDATMOVESDATA2b()
                        Insert_Actions(Me.TextMovementSymbol.Text, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                End If
            End If
            Me.Ubdatdata()
            Ubdatdata2()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub


<<<<<<< HEAD
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts1.Click
=======
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If CheckTransferofAccounts.Checked = True Or CheckTransferofAccounts2.Checked = True Then
                MessageBox.Show("تنبيه. قيد المبيعات و الصندوق مرحل" & ControlChars.CrLf &
                            "1) الغاء ترحيل قيد المبيعات والصندوق" & ControlChars.CrLf &
                            "2) قم بترحيل قيد تكلفة المبيعات و مخزون البضاعة", "تنبيه", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonTransferofAccounts1.Enabled = False
                Exit Sub
            End If

            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.Text)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Me.TextMovementSymbol.Text = "QR" & "-" & CDate(Textdaee.Text.Trim).ToString("yyyy/MMdd")
            Me.TextFullInvoiceNumber1.Text = Me.TextInvoiceNumber.Text & Me.TextInvoiceNumber1.Text
            Dim resault As Integer
            If Me.CheckTransferofAccounts1.Checked = False Then
                resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.CheckTransferofAccounts1.Checked = True
                    TransforAccountsSalesCost()
                Else
                    Exit Sub
                End If
            Else
                resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.TextMovementRestrictions1.Text = "" Then
                        MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                    Else
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                    End If
                    TransforAccountsSalesCost()
                    Me.AccountingprocedureA()
                    Insert_Actions(Me.TextMovementSymbol.Text, "تعديل ترحيل  الى القيود اليومية رفم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                Else
                    resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول القيود اليومية  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferofAccounts1.Checked = False
                        Me.DELETEDATMOVESDATA()
                        Me.DELETEDATMOVESDATA1()
                        Insert_Actions(Me.TextMovementSymbol.Text, "حذف ترحيل حركة القيود اليومية رقم" & " " & Me.TextMovementSymbol.Text, Me.Text)
                    Else
                        Exit Sub
                    End If
                End If
            End If
            Ubdatdata()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub



<<<<<<< HEAD
    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListSalesReturns.MouseDoubleClick
=======
    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListSalesReturns.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextSalesReturns.Text = Me.ListSalesReturns.SelectedItem(0).ToString
        LS2 = False
        Me.PanelAccount_Name.Visible = False
        Me.ListSalesReturns.Visible = False
    End Sub

<<<<<<< HEAD
    Private Sub ListBox2_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListDiscountAccount.MouseDoubleClick
=======
    Private Sub ListBox2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListDiscountAccount.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextDiscountAccount.Text = Me.ListDiscountAccount.SelectedItem(0).ToString
        LS3 = False
        Me.PanelAccount_Name.Visible = False
        Me.ListDiscountAccount.Visible = False
    End Sub

<<<<<<< HEAD
    Private Sub ListBox3_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles ListCreditAccount.MouseDoubleClick
=======
    Private Sub ListBox3_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListCreditAccount.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextCreditAccount.Text = Me.ListCreditAccount.SelectedItem(0).ToString
        LS4 = False
        Me.PanelAccount_Name.Visible = False
        Me.ListCreditAccount.Visible = False
    End Sub

<<<<<<< HEAD
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
=======
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub

<<<<<<< HEAD
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
=======
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ListCreditAccount.DataSource = GetData(NUpCreditAccount.Value)
        Me.ListCreditAccount.DisplayMember = "account_name"
    End Sub

<<<<<<< HEAD
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpSalesReturns.ValueChanged
=======
    Private Sub NumericUpDown4_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpSalesReturns.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ListSalesReturns.DataSource = GetData(NUpSalesReturns.Value)
        Me.ListSalesReturns.DisplayMember = "account_name"
    End Sub

<<<<<<< HEAD
    Private Sub NumericUpDown6_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDiscountAccount.ValueChanged
=======
    Private Sub NumericUpDown6_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDiscountAccount.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ListDiscountAccount.DataSource = GetData(NUpDiscountAccount.Value)
        Me.ListDiscountAccount.DisplayMember = "account_name"
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCreditAccount.Click
=======
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCreditAccount.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListCreditAccount.Visible = True
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicSalesReturns.Click
=======
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSalesReturns.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS2 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListSalesReturns.Visible = True
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicDiscountAccount.Click
=======
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicDiscountAccount.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS3 = True
        Me.PanelAccount_Name.Visible = True
        Me.ListDiscountAccount.Visible = True
    End Sub


    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.ListCreditAccount.DataSource = GetData(NUpCreditAccount.Value)
            Me.ListCreditAccount.DisplayMember = "account_name"
        ElseIf LS2 = True Then
            Me.ListSalesReturns.DataSource = GetData(NUpSalesReturns.Value)
            Me.ListSalesReturns.DisplayMember = "account_name"
        ElseIf LS3 = True Then
            Me.ListDiscountAccount.DataSource = GetData(NUpDiscountAccount.Value)
            Me.ListDiscountAccount.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub

<<<<<<< HEAD
    Private Sub Textdaee1_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles Textdaee1.ValueChanged
=======
    Private Sub Textdaee1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Textdaee1.ValueChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Textdaee.Text = Format(Me.Textdaee1.Value, "yyyy-MM-dd")
        Me.TextInvoiceNumber.Text = "0.000"
        Me.TextInvoiceNumber1.Text = "0.000"
        Me.TextFullInvoiceNumber.Text = "0.000"
        'Me.BuakrT.PerformClick()
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
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferofAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Me.CheckInternalAuditorER1.Checked = True
        Me.CheckInternalAuditorER.Checked = True
        Me.Ubdatdata()
        Me.Ubdatdata2()
        Me.InternalAuditorType()
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TextMovementSymbol.Text, "مراجعة", Me.Text)
    End Sub

<<<<<<< HEAD
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckInternalAuditorER.Checked = False Then
            MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
            Exit Sub
        End If
        Me.CheckInternalAuditorER1.Checked = False
        Me.CheckInternalAuditorER.Checked = False
        Me.Ubdatdata()
        Me.Ubdatdata2()
        Me.InternalAuditorType()
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Insert_Actions(Me.TextMovementSymbol.Text, "إلغاء المراجعة", Me.Text)
    End Sub

    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckInternalAuditorER.Checked = True Then
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.Panel9.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
            Me.PicSalesReturns.Enabled = False
            Me.PicDiscountAccount.Enabled = False
        ElseIf CheckInternalAuditorER1.Checked = True And Me.CheckInternalAuditorER.Checked = True Then
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.Panel9.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
            Me.PicSalesReturns.Enabled = False
            Me.PicDiscountAccount.Enabled = False
        ElseIf Me.CheckTransferofAccounts.Checked = True And Me.CheckInternalAuditorER1.Checked = True And Me.CheckInternalAuditorER.Checked = True Then
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.Panel9.Enabled = False
            Me.ComboDebitAccount.Enabled = False
            Me.PicCreditAccount.Enabled = False
            Me.PicSalesReturns.Enabled = False
            Me.PicDiscountAccount.Enabled = False
        Else
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.Panel9.Enabled = True
            Me.ComboDebitAccount.Enabled = True
            Me.PicCreditAccount.Enabled = True
            Me.PicSalesReturns.Enabled = True
            Me.PicDiscountAccount.Enabled = True
        End If

    End Sub

    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonTransferofAccounts1.Enabled = TransferofAccounts
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
    End Sub

<<<<<<< HEAD
    Private Sub PicMovementRestrictions_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PicMovementRestrictions_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
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
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
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
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
    End Sub
<<<<<<< HEAD
    Private Sub PicMovementRestrictions1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions1.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PicMovementRestrictions1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions1.Click
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
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
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
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
    End Sub
<<<<<<< HEAD
    Private Sub PicMovementRestrictions2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions2.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub PicMovementRestrictions2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions2.Click
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
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1.Fill(ds, "MOVES")
            f.BS.DataMember = "MOVES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("MOV2", Me.TextMovementRestrictions2.Text.Trim)
            f.TB2 = Me.TextMovementRestrictions2.Text.Trim
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            f.RecordCount()
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
    End Sub


<<<<<<< HEAD
    Private Sub PicFundMovementNumber_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Try
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub PicFundMovementNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
        Try
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmBanks5

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
            SqlDataAdapter1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

        Consum.Close()
    End Sub



<<<<<<< HEAD
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()

        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.Text)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C


        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.Text)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.Text)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHMOVES1A(Me.TextMovementSymbol.Text)
        Me.TextMovementRestrictions1.Text = SEARCHDATA.MOV2A
        SEARCHDATA.SEARCHMOVES1B(Me.TextMovementSymbol.Text)
        Me.TextMovementRestrictions2.Text = SEARCHDATA.MOV2B

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.Text, Me.TextInvoiceNumber1.Text)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1

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
            ModuleGeneral.CB2 = ds.Tables(0).Rows(0).Item(0)
        Else
            ModuleGeneral.CB2 = ""
        End If
        Adp.Dispose()
        Consum.Close()
        GetFundAccount_No(ModuleGeneral.CB2)
        AccountsEnquiry()
        SEARCHDATAITEMS8()
    End Sub


End Class