Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAdvancedSearchMoviesCashier

    Dim Adp As New SqlDataAdapter
    Private ReadOnly ds As New DataSet
    Private ReadOnly bs As New BindingSource

    Private dtSource As DataTable
    Private PageCount As Integer
    Private maxRec As Integer
    Private pageSize As Integer
    Private currentPage As Integer
    Private recNo As Integer

    'Private Sub frmAdvancedSearchMoviesCashier_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
    '    R.Container = Me
    'End Sub
    'Private Sub frmAdvancedSearchMoviesCashier_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    R.ResizeControls()
    'End Sub
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonSearch.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If bs.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If

        If TxtSearch.Text = "" Then
            MessageBox.Show("الرجاء وضع قيمة للبحث عنها", " البحث في داتا جريد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtSearch.Focus()
            Exit Sub
        End If
        DataGridView1.ClearSelection()
        Label2.Text = ""
        Dim InStrCunot As Integer = 0
        If IsDate(Me.TxtSearch.Text) Then
            Me.TxtSearch.Text = Format(CDate(Me.TxtSearch.Text), "yyyy/MM/dd")
        ElseIf IsNumeric(Me.TxtSearch.Text) Then
            Me.TxtSearch.Text = Format(Val(Me.TxtSearch.Text), "#,#0.00")
        End If
        If RadioButton9.Checked Then
            FillDataBS()
            DataGridView1.ClearSelection()
            InStrCunot = 0
            For intcount As Integer = 0 To DataGridView1.RowCount - 1
                For intcolmn As Integer = 0 To DataGridView1.Columns.Count - 1
                    If Trim(TxtSearch.Text) = DataGridView1.Rows(intcount).Cells(intcolmn).FormattedValue.ToString Then
                        DataGridView1.Rows(intcount).Cells(intcolmn).Selected = True
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.BackColor = Color.Red
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.ForeColor = Color.White
                        InStrCunot += 1
                    End If
                Next intcolmn
            Next intcount
        Else
            FillDataBS()
            DataGridView1.ClearSelection()
            InStrCunot = 0
            Dim b As Boolean
            For intcount As Integer = 0 To DataGridView1.RowCount - 1
                For intcolmn As Integer = 0 To DataGridView1.Columns.Count - 1
                    b = InStr(DataGridView1.Rows(intcount).Cells(intcolmn).FormattedValue, Trim(TxtSearch.Text))
                    If b = True Then
                        DataGridView1.Rows(intcount).Cells(intcolmn).Selected = True
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.BackColor = Color.Red
                        DataGridView1.Rows(intcount).Cells(intcolmn).Style.ForeColor = Color.White
                        InStrCunot += 1
                    End If
                Next intcolmn
            Next intcount
        End If
        Label1.Text = IIf(InStrCunot > 0, InStrCunot & " سجل  ", 0 & " سجل  ")
        Label2.Text = " عدد نتائج البحث "
        If InStrCunot = 0 Then
            MessageBox.Show("لم يتم العثور على شي", " البحث في داتا جريد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            TxtSearch.Focus()
            Label2.Text = " عدد نتائج البحث "
            Label1.Text = "0" & "   سجل   "
        End If
        ListBox3.Items.Clear()
        For Each cell As DataGridViewCell In DataGridView1.SelectedCells
            ListBox3.Items.Add(cell.RowIndex + 1 & " - " & cell.Value)
            ListBox3.Refresh()
            DataGridView1.ClearSelection()
            ListBox3.SelectedIndex = ListBox3.Items.Count - 1
        Next
    End Sub
    Private Sub FillDataBS()
        On Error Resume Next
        Application.DoEvents()
        ds.EnforceConstraints = False
        Dim DataSetTab7 As DataSet
        DataSetTab7 = ds.GetChanges
        DataSetTab7 = New DataSet
        Dim Consum As New SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(Adp)
            ds.Clear()
            Adp.Fill(ds, "CASHIER")
            bs.DataSource = ds
            bs.DataMember = "CASHIER"
        End With
        Consum.Close()
        With DataGridView1
            .DataBindings.Clear()
            .DataSource = bs
            .AutoGenerateColumns = False
        End With
        SumAmounFINALBALANCE1()
        TextMovements1.Text = Val(Me.DataGridView1.Rows.Count - 1)
        Adp.Dispose()

        Me.DataGridView1.AutoGenerateColumns = False

        dtSource = ds.Tables("CASHIER")
        pageSize = 8
        maxRec = dtSource.Rows.Count
        PageCount = maxRec \ pageSize
        If (maxRec Mod pageSize) > 0 Then
            PageCount += 1
        End If
        currentPage = 1
        recNo = 0
        LoadPage()
    End Sub
    Private Sub FrmAdvancedSearchMoviesCustomers_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
                Case Keys.Enter
                    ButtonSearch.PerformClick()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmAdvancedSearchMoviesCustomers_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            Me.DataGridView1.AutoGenerateColumns = False
            FillDataBS()
            Dim Consum As New SqlConnection(constring)
            Dim strSQL1 As New SqlCommand("SELECT distinct  CSH12 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader()
            Do While DR.Read()
                ComboStatement.Items.Add(DR(0))
            Loop
            Consum.Close()
            Dim strSQL2 As New SqlCommand("SELECT distinct  CSH3 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader()
            Do While DR.Read()
                ComboType.Items.Add(DR(0))
            Loop
            Consum.Close()
            Dim strSQL3 As New SqlCommand("SELECT distinct  CSH10 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL3.ExecuteReader()
            Do While DR.Read()
                ComboSource.Items.Add(DR(0))
            Loop
            Consum.Close()
            Dim strSQL4 As New SqlCommand("SELECT distinct  CSH11 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL4.ExecuteReader()
            Do While DR.Read()
                ComboDetails.Items.Add(DR(0))
            Loop
            Consum.Close()
            If Me.ComboType.Items.Count > 0 Then Me.ComboType.SelectedIndex = 0
            If Me.ComboBEnquiry.Items.Count > 0 Then Me.ComboBEnquiry.SelectedIndex = 0
            If Me.ComboSource.Items.Count > 0 Then Me.ComboSource.SelectedIndex = 0
            If Me.ComboMovements.Items.Count > 0 Then Me.ComboMovements.SelectedIndex = 0
            If Me.ComboDetails.Items.Count > 0 Then Me.ComboDetails.SelectedIndex = 0
            If Me.ComboStatement.Items.Count > 0 Then Me.ComboStatement.SelectedIndex = 0
            ComboType.Enabled = False
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.DataGridView1.AutoGenerateColumns = False
        '==============================
        Call MangUsers()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboBEnquiry, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboSource, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboMovements, e, )
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboType, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboDetails, e, )
    End Sub
    Private Sub TEXTBOX14_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(ComboStatement, e, )
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ListBox3.SelectedIndexChanged
        Try
            Dim Str As String = ListBox3.Text
            Dim strArr() As String
            Dim a As String
            strArr = Str.Split("-")
            a = strArr.First()
            DataGridView1.CurrentCell = DataGridView1.Rows(a - 1).Cells(0)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonPrintreport_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonPrintreport.Click
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If bs.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim Consum As New SqlConnection(constring)
        Try
            If Me.ComboBEnquiry.Text = "رصيد  حركة الصندوق خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt As New rptBanks20
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT * FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'"
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    rpt.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text8")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "مصدر  الحركات  خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt As New rptBanks20
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT * FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH10='" & ComboSource.Text & "'"
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    rpt.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text8")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "تفاصيل حركة الصندوق خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt As New rptBanks20
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT * FROM CASHIER   WHERE CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH11='" & ComboDetails.Text & "'"
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    rpt.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text8")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "بيان حركة الصندوق خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt As New rptBanks20
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT * FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH12='" & ComboStatement.Text & "'"
                    SumAmounFINALBALANCE6()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    rpt.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text8")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "رصيد نوع الحركة خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt As New rptBanks20
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT * FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH3='" & ComboType.Text & "'"
                    SumAmounFINALBALANCE7()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    rpt.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text8")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "حركة مدين أو دائنة خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt As New rptBanks20
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    If Me.ComboMovements.Text = "مدين" Then
                        .CommandText = "SELECT * FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH7='" & TextMovements.Text & "'"
                        SumAmounFINALBALANCE9()
                    Else
                        .CommandText = "SELECT * FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH8='" & TextMovements.Text & "'"
                        SumAmounFINALBALANCE10()
                    End If
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    rpt.SetDataSource(ds)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text8")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("TEXT10")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("TEXT11")
                    txt.Text = Directorate
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            End If
            TextMovements1.Text = Val(Me.DataGridView1.Rows.Count - 1)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SumAmounFINALBALANCE1()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER WHERE CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextBalance.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE52()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7 - CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
        Dim DS As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        DS.Clear()
        Consum.Open()
        Adp1.Fill(DS)
        Adp1.Dispose()
        If DS.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(DS.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextBalance.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE3()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH10='" & ComboSource.Text & "'  AND CSH6='" & ComboStatement.Text & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE4()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH10='" & ComboSource.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE5()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH11='" & ComboDetails.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE6()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH12='" & ComboStatement.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE7()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH3='" & ComboType.Text & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE8()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH5='" & TextMovements.Text & "'  AND CSH6='" & ComboStatement.Text & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE9()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH7='" & TextMovements.Text & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE10()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(CSH7-CSH8) FROM CASHIER  WHERE   CUser='" & CUser & "'  and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH8='" & TextMovements.Text & "'", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        Consum.Open()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        TextBalance.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEnquiry.Click
        Me.ListBox3.Items.Clear()
        Me.TxtSearch.Text = ""
        Me.Label1.Text = ""
        Me.Label2.Text = ""
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If bs.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim Consum As New SqlConnection(constring)
        Try
            If Me.ComboBEnquiry.Text = "رصيد  حركة الصندوق خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds1 As New DataSet
                    .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  ORDER BY CSH1"
                    SumAmounFINALBALANCE52()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds1.Clear()
                    SqlDataAdapter1.Fill(ds1, "CASHIER")
                    bs.DataSource = ds1
                    bs.DataMember = "CASHIER"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With

            ElseIf Me.ComboBEnquiry.Text = "مصدر  الحركات  خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH10='" & ComboSource.Text & "'  ORDER BY CSH1"
                    SumAmounFINALBALANCE4()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    bs.DataSource = ds
                    bs.DataMember = "CASHIER"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With

            ElseIf Me.ComboBEnquiry.Text = "تفاصيل حركة الصندوق خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH11='" & ComboDetails.Text & "'  ORDER BY CSH1"
                    SumAmounFINALBALANCE5()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    bs.DataSource = ds
                    bs.DataMember = "CASHIER"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With

            ElseIf Me.ComboBEnquiry.Text = "بيان حركة الصندوق خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH12='" & ComboStatement.Text & "'  ORDER BY CSH1"
                    SumAmounFINALBALANCE6()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    bs.DataSource = ds
                    bs.DataMember = "CASHIER"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With
            ElseIf Me.ComboBEnquiry.Text = "رصيد نوع الحركة خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds As New DataSet
                    .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH3='" & ComboType.Text & "'  ORDER BY CSH1"
                    SumAmounFINALBALANCE7()
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    bs.DataSource = ds
                    bs.DataMember = "CASHIER"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With
            ElseIf Me.ComboBEnquiry.Text = "حركة مدين أو دائنة خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim DataSetTab7 As New DataSet
                    If Me.ComboMovements.Text = "مدين" Then
                        .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH7='" & TextMovements.Text & "'  ORDER BY CSH1"
                        SumAmounFINALBALANCE9()
                    Else
                        .CommandText = "SELECT CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17 FROM CASHIER  WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CSH2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CSH8='" & TextMovements.Text & "'  ORDER BY CSH1"
                        SumAmounFINALBALANCE10()
                    End If
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    Dim builder10 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds.Clear()
                    SqlDataAdapter1.Fill(ds, "CASHIER")
                    bs.DataSource = ds
                    bs.DataMember = "CASHIER"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With
            End If
            TextMovements1.Text = Val(Me.DataGridView1.Rows.Count - 1)
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBEnquiry.SelectedIndexChanged
        Try
            If Me.ComboBEnquiry.Text = "رصيد  حركة الصندوق خلال فترة معينة" Then
                Me.ComboStatement.Enabled = False
                ComboType.Enabled = False
                ComboDetails.Enabled = False
                ComboMovements.Enabled = False
                TextMovements.Enabled = False
                ComboSource.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "مصدر  الحركات  خلال فترة معينة" Then
                Me.ComboStatement.Enabled = False
                ComboType.Enabled = False
                ComboSource.Enabled = True
                ComboMovements.Enabled = False
                TextMovements.Enabled = False
                ComboDetails.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "تفاصيل حركة الصندوق خلال فترة معينة" Then
                ComboType.Enabled = False
                Me.ComboStatement.Enabled = False
                ComboSource.Enabled = False
                ComboMovements.Enabled = False
                TextMovements.Enabled = False
                ComboDetails.Enabled = True
            ElseIf Me.ComboBEnquiry.Text = "بيان حركة الصندوق خلال فترة معينة" Then
                Me.ComboStatement.Enabled = True
                ComboDetails.Enabled = False
                ComboType.Enabled = False
                ComboSource.Enabled = False
                ComboMovements.Enabled = False
                TextMovements.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "رصيد نوع الحركة خلال فترة معينة" Then
                Me.ComboStatement.Enabled = False
                ComboType.Enabled = True
                ComboSource.Enabled = False
                ComboMovements.Enabled = False
                TextMovements.Enabled = False
                ComboDetails.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "حركة مدين أو دائنة خلال فترة معينة" Then
                Me.ComboStatement.Enabled = False
                ComboType.Enabled = False
                ComboSource.Enabled = False
                ComboMovements.Enabled = True
                TextMovements.Enabled = True
                ComboDetails.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonDisplyAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDisplyAll.Click
        Try
            FillDataBS()
            Me.ListBox3.Items.Clear()
            Me.TxtSearch.Text = ""
            Me.Label1.Text = ""
            Me.Label2.Text = ""
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Showcustomsaccountbyreport()
        Try
            Dim F As New FrmPRINT
            Me.ComboStatement.Enabled = False
            ComboType.Enabled = False
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim rpt1 As New rptAccount
            Dim Consum As New SqlConnection(constring)
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            Dim DataSetTab33 As New DataSet
            Dim str As New SqlCommand("SELECT * FROM DETAILSACCOUNT  WHERE   CUser='" & CUser & "' and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            DataSetTab33.Clear()
            SqlDataAdapter1.Fill(DataSetTab33, "DETAILSACCOUNT")
            rpt1.SetDataSource(DataSetTab33)
            Dim txt As TextObject
            txt = rpt1.Section1.ReportObjects("Text4")
            txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt1.Section1.ReportObjects("Text8")
            txt.Text = AssociationName
            txt = rpt1.Section1.ReportObjects("Text9")
            txt.Text = Directorate
            txt = rpt1.Section1.ReportObjects("TEXT40")
            txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
            txt = rpt1.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            F.CrystalReportViewer1.ReportSource = rpt1
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.Refresh()
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Showcustomsaccountbyquery()
        Try
            Me.ComboStatement.Enabled = False
            ComboType.Enabled = False
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim Consum As New SqlConnection(constring)
            Dim str As New SqlCommand("SELECT * FROM DETAILSACCOUNT  WHERE   CUser='" & CUser & "' and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "DETAILSACCOUNT")
            bs.DataSource = ds
            bs.DataMember = "DETAILSACCOUNT"
            With DataGridView1
                .DataBindings.Clear()
                .DataSource = bs
                .AutoGenerateColumns = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SELECTTHECUSTOMERFORCERTIFICATE()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT CEMP3 FROM CABLESCOEMPLOYEES WHERE   CUser='" & CUser & "' and CEMP28 = '" & Me.ComboSource.Text & "'" & "ORDER BY CEMP3", Consum)
        Consum = New SqlConnection(constring)
        Dim ds As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        ComboStatement.Items.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            For I As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ComboStatement.SelectedIndex = 0
                ComboStatement.Items.Add(ds.Tables(0).Rows(I).Item(0))
            Next I
        Else
            ComboStatement.Items.Clear()
        End If
        Consum.Close()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            Dim SqlDataAdapter1 As New SqlDataAdapter(str)
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1.Fill(ds, "CASHIER")
            If Consum.State = ConnectionState.Open Then Consum.Close()
            f.BS.DataMember = "CASHIER"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("CSH1", Me.DataGridView1.CurrentRow.Cells(0).Value)
            f.TB1 = Me.DataGridView1.CurrentRow.Cells(0).Value
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
            SqlDataAdapter1.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub ButtonEXPORTTPEXCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEXPORTTPEXCEL.Click
        Dim strFileName As String
        If DataGridView1.RowCount <= 1 Then
            MessageBox.Show("الجدول فارغ من السجلات", " ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        Try
            If (DataGridView1.Columns.Count = 0) Or (DataGridView1.Rows.Count = 0) Then
                Exit Sub
            End If
            Dim dset As New DataSet
            dset.Tables.Add()
            For i As Integer = 0 To DataGridView1.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView1.Columns(i).HeaderText)
            Next
            Dim dr1 As DataRow
            For i As Integer = 0 To DataGridView1.RowCount - 1
                dr1 = dset.Tables(0).NewRow
                For j As Integer = 0 To DataGridView1.Columns.Count - 1
                    dr1(j) = DataGridView1.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)
            Next
            Dim excel As New Microsoft.Office.Interop.Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet
            Dim newCulture As Globalization.CultureInfo
            Dim OldCulture As Globalization.CultureInfo
            OldCulture = System.Threading.Thread.CurrentThread.CurrentCulture
            newCulture = New Globalization.CultureInfo(
                excel.LanguageSettings.LanguageID(Microsoft.Office.Core.MsoConnectorType.msoConnectorTypeMixed))
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "حركة_الصندوق"
            Dim dt As DataTable = dset.Tables(0)
            Dim dc As DataColumn
            Dim dr As DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0
            For Each dc In dt.Columns
                colIndex += 1
                excel.Cells(1, colIndex) = dc.ColumnName
            Next
            For Each dr In dt.Rows
                rowIndex += 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex += 1
                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next
            wSheet.Columns.AutoFit()
            Dim blnFileOpen As Boolean = False
            Dim ofd As New SaveFileDialog With {
                .Filter = "Excel Files (*.xls)|*.xls"
            }
            With ofd
                .FilterIndex = 1
                .Title = "حفظ ملف"
                MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
                .InitialDirectory = MYFOLDER & "\Excel"
                .AddExtension = True
                .FileName = "حركة_الصندوق" & "-" & Format(Date.Today, "dd-MM-yyyy").ToString
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Len(.FileName) > 0 Then
                        strFileName = ofd.FileName
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
            End With
            Try
                Dim fileTemp As IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try
            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If
            wBook.SaveAs(strFileName)
            excel.Workbooks.Open(strFileName)
            excel.Visible = True
            System.Threading.Thread.CurrentThread.CurrentCulture = OldCulture
        Catch ex As Exception
            If ex.Message.ToString = "Old format or invalid type library. (Exception from HRESULT: 0x80028018 (TYPE_E_INVDATAREAD))" Then
                MessageBox.Show(" من فضلك غير التنسيق الى" & vbCrLf & vbCrLf & "  English(United States)")
                Dim F As New FrmWindows
                F.Show()
                F.ADDBUTTON.PerformClick()
            Else
                Exit Sub
            End If
        End Try
    End Sub
    Private Sub Total()
        On Error Resume Next
        TextDebit.Text = 0
        TextCred.Text = 0
        TextBalance1.Text = 0
        For Each r As DataGridViewRow In DataGridView1.Rows
            TextDebit.Text += Val(r.Cells("CSH7").Value)
            TextCred.Text += Val(r.Cells("CSH8").Value)
        Next
        TextDebit.Text = Format(Val(TextDebit.Text), "#,#0.00")
        TextCred.Text = Format(Val(TextCred.Text), "#,#0.00")
        TextBalance1.Text = Format(Val(TextDebit.Text - TextCred.Text), "#,#0.00")
    End Sub
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub LoadPage()
        Dim i As Integer
        Dim startRec As Integer
        Dim endRec As Integer
        Dim dtTemp As DataTable
        dtTemp = dtSource.Clone
        If currentPage = PageCount Then
            endRec = maxRec
        Else
            endRec = pageSize * currentPage
        End If
        startRec = recNo
        If dtSource.Rows.Count > 0 Then
            For i = startRec To endRec - 1
                dtTemp.ImportRow(dtSource.Rows(i))
                recNo += 1
            Next
        End If
        DataGridView1.DataSource = dtTemp
        DisplayPageInfo()
    End Sub
    Private Sub DisplayPageInfo()
        txtDisplayPageNo.Text = "صفحة " & currentPage.ToString & "/ " & PageCount.ToString
    End Sub
    Private Function CheckFillButton() As Boolean
        If pageSize = 0 Then
            MessageBox.Show("ضبط حجم الصفحة، ثم انقر فوق ""ملء الشبكة"" زر!")
            CheckFillButton = False
        Else
            CheckFillButton = True
        End If
    End Function
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNextPage.Click
        If Not CheckFillButton() Then Return
        currentPage -= 1
        If currentPage < 1 Then
            MessageBox.Show("أنت في الصفحة الأولى!")
            currentPage = 1
            Return
        Else
            recNo = pageSize * (currentPage - 1)
        End If
        LoadPage()
    End Sub
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnPreviousPage.Click
        If Not CheckFillButton() Then Return
        If pageSize = 0 Then
            MessageBox.Show("ضبط حجم الصفحة، ثم انقر فوق ""ملء الشبكة"" زر!")
            Return
        End If
        currentPage += 1
        If currentPage > PageCount Then
            currentPage = PageCount
            If recNo = maxRec Then
                MessageBox.Show("أنت في الصفحة الأولى!")
                Return
            End If
        End If
        LoadPage()
    End Sub
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnFirstPage.Click
        If Not CheckFillButton() Then Return
        If recNo = maxRec Then
            MessageBox.Show("أنت في الصفحة الأخيرة!")
            Return
        End If
        currentPage = PageCount
        recNo = pageSize * (currentPage - 1)
        LoadPage()
    End Sub
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnLastPage.Click
        If Not CheckFillButton() Then Return
        If currentPage = 1 Then
            MessageBox.Show("أنت في الصفحة الأولى!")
            Return
        End If
        currentPage = 1
        recNo = 0
        LoadPage()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub


End Class