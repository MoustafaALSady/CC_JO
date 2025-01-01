Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAdvancedSearchMoviesBanks
    ReadOnly cmd As New SqlCommand

    Dim Adp As New SqlDataAdapter
    Dim ds As New DataSet
    ReadOnly bs As New BindingSource
    Private dtSource As DataTable
    Private PageCount As Integer
    Private maxRec As Integer
    Private pageSize As Integer
    Private currentPage As Integer
    Private recNo As Integer

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
        Dim da As DataSet
        da = ds.GetChanges
        ds = New DataSet
        Dim Consum As New SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ORDER BY EBNK1"
            Adp = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(Adp)
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp.Fill(ds, "BANKJO")
            bs.DataSource = ds
            bs.DataMember = "BANKJO"
        End With
        With DataGridView1
            .DataBindings.Clear()
            .DataSource = bs
            .AutoGenerateColumns = False
        End With
        Consum.Close()
        TextMovements.Text = Val(Me.DataGridView1.Rows.Count - 1)
        SumAmounFINALBALANCE()
        cmd.Dispose()
        Adp.Dispose()
        Me.DataGridView1.AutoGenerateColumns = False

        dtSource = ds.Tables("BANKJO")
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
            Dim strSQL1 As New SqlCommand("SELECT distinct  EBNK10 FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader()
            Do While DR.Read()
                ComboAccount.Items.Add(DR(0))
            Loop
            Consum.Close()
            Dim strSQL2 As New SqlCommand("SELECT distinct  EBNK8 FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL2.ExecuteReader()
            Do While DR.Read()
                ComboType.Items.Add(DR(0))
            Loop
            Consum.Close()
            Dim strSQL3 As New SqlCommand("SELECT distinct  EBNK11 FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
            Consum.Open()
            DR = strSQL3.ExecuteReader()
            Do While DR.Read()
                ComboBank.Items.Add(DR(0))
            Loop
            Consum.Close()
            If Me.ComboType.Items.Count > 0 Then Me.ComboType.SelectedIndex = 0
            If Me.ComboBEnquiry.Items.Count > 0 Then Me.ComboBEnquiry.SelectedIndex = 0
            If Me.ComboBank.Items.Count > 0 Then Me.ComboBank.SelectedIndex = 0
            If Me.ComboCanol.Items.Count > 0 Then Me.ComboCanol.SelectedIndex = 0
            If Me.ComboAccount.Items.Count > 0 Then Me.ComboAccount.SelectedIndex = 0
            ComboSpecifiedAccount.SelectedIndex = 0
            ComboType.Enabled = False
            Total()
            Label1.Text = ""
            Label2.Text = ""

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
        '==============================
        Call MangUsers()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboBEnquiry.KeyPress
        AutoComplete(ComboBEnquiry, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboBank.KeyPress
        AutoComplete(ComboBank, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboCanol.KeyPress
        AutoComplete(ComboCanol, e, )
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles ComboType.KeyPress
        AutoComplete(ComboType, e, )
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
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If bs.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        Dim Consum As New SqlConnection(constring)
        Try
            If Me.ComboBEnquiry.Text = "رصيد رقم حساب خلال فترة معينة" Then
                Dim rpt As New rptjo
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)
                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE  CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK10='" & ComboAccount.Text & "'"
                    Else
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE  CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'"
                    End If
                    Dim DataSetTab16 As New DataSet
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    DataSetTab16.Clear()
                    SqlDataAdapter1.Fill(DataSetTab16, "BANKJO")
                    rpt.SetDataSource(DataSetTab16)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text10")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("Text12")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("Text15")
                    txt.Text = Directorate
                    txt = rpt.Section1.ReportObjects("Text14")
                    txt.Text = Character
                    txt = rpt.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    txt = rpt.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "رصيد البنك خلال فترة معينة" Then
                Dim rpt As New rptjo
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)

                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If

                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE  CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK11='" & ComboBank.Text & "'  AND EBNK10='" & ComboAccount.Text & "'"
                    Else
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE  CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK11='" & ComboBank.Text & "'"
                    End If
                    Dim DataSetTab16 As New DataSet
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    DataSetTab16.Clear()
                    SqlDataAdapter1.Fill(DataSetTab16, "BANKJO")
                    rpt.SetDataSource(DataSetTab16)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text10")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("Text12")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("Text15")
                    txt.Text = Directorate
                    txt = rpt.Section1.ReportObjects("Text14")
                    txt.Text = Character
                    txt = rpt.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    txt = rpt.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "رصيد نوع الحركة خلال فترة معينة" Then
                Dim rpt As New rptjo
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim str As New SqlCommand("", Consum)

                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE  CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboType.Text & "'  AND EBNK10='" & ComboAccount.Text & "'"
                    Else
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE  CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboType.Text & "'"
                    End If
                    Dim DataSetTab16 As New DataSet
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    DataSetTab16.Clear()
                    SqlDataAdapter1.Fill(DataSetTab16, "BANKJO")
                    rpt.SetDataSource(DataSetTab16)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text10")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("Text12")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("Text15")
                    txt.Text = Directorate
                    txt = rpt.Section1.ReportObjects("Text14")
                    txt.Text = Character
                    txt = rpt.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    txt = rpt.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            ElseIf Me.ComboBEnquiry.Text = "حركة مدين أو دائنة خلال فترة معينة" Then
                Dim rpt As New rptjo
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                rpt.SetDatabaseLogon("sa", "2710/m") 'لكي لا يطلب باسورد اثناء التنفيذ
                Dim str As New SqlCommand("", Consum)

                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        '.CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and EBNK3 BETWEEN '" & Format(Me.TEXTBOX11.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.TEXTBOX12.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboBox4.Text & "'  AND EBNK10='" & TEXTBOX14.Text & "'"
                        If Me.ComboCanol.Text = "مدين" Then
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK4='" & TextDebit_Cred.Text & "'  AND EBNK10='" & ComboAccount.Text & "'"
                        Else
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK5='" & TextDebit_Cred.Text & "'  AND EBNK10='" & ComboAccount.Text & "'"
                        End If
                    Else
                        If Me.ComboCanol.Text = "مدين" Then
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK4='" & TextDebit_Cred.Text & "'"
                        Else
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK5='" & TextDebit_Cred.Text & "'"
                        End If
                    End If
                    Dim DataSetTab16 As New DataSet
                    SqlDataAdapter1 = New SqlDataAdapter(str)
                    DataSetTab16.Clear()
                    SqlDataAdapter1.Fill(DataSetTab16, "BANKJO")
                    rpt.SetDataSource(DataSetTab16)
                    Dim txt As TextObject
                    txt = rpt.Section1.ReportObjects("Text10")
                    txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                    txt = rpt.Section1.ReportObjects("Text12")
                    txt.Text = AssociationName
                    txt = rpt.Section1.ReportObjects("Text15")
                    txt.Text = Directorate
                    txt = rpt.Section1.ReportObjects("Text14")
                    txt.Text = Character
                    txt = rpt.Section1.ReportObjects("TEXT40")
                    txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                    txt = rpt.Section1.ReportObjects("Text44")
                    txt.Text = Recorded
                    F.CrystalReportViewer1.ReportSource = rpt
                    F.CrystalReportViewer1.Zoom(90%)
                    F.CrystalReportViewer1.Refresh()
                    F.Show()
                End With
            End If
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SumAmounFINALBALANCE1()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(EBNK4-EBNK5) FROM BANKJO  WHERE EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK6='" & ComboAccount.Text & "'", Consum)
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
        Me.TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(EBNK4-EBNK5) FROM BANKJO WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
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
        Me.TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE52()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
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
        Me.TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE3()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(EBNK4-EBNK5) FROM BANKJO  WHERE  CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK10='" & ComboBank.Text & "'  AND EBNK6='" & ComboAccount.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE4()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK10='" & ComboBank.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE5()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboType.Text & "'  AND EBNK6='" & ComboAccount.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE6()
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(EBNK4-EBNK5)  FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboType.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE7()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK4='" & TextDebit_Cred.Text & "'  AND EBNK6='" & ComboAccount.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE8()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT  Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK5='" & TextDebit_Cred.Text & "'  AND EBNK6='" & ComboAccount.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE9()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK4='" & TextDebit_Cred.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
        Consum.Close()
    End Sub
    Private Sub SumAmounFINALBALANCE10()
        Dim Adp1 As SqlDataAdapter
        Dim SUM1 As Double
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT  Sum(EBNK4-EBNK5) FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK5='" & TextDebit_Cred.Text & "'", Consum)
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
        TextBalance1.Text = Format(Val(SUM1), "#,#0.00")
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

            If Me.ComboBEnquiry.Text = "رصيد رقم حساب خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)

                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        Dim ds As New DataSet
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK10='" & ComboAccount.Text & "'  ORDER BY EBNK1"
                        SumAmounFINALBALANCE1()
                    Else
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  ORDER BY EBNK1"
                        SumAmounFINALBALANCE52()
                    End If
                End With
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BANKJO")
                bs.DataSource = ds
                bs.DataMember = "BANKJO"
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With
            ElseIf Me.ComboBEnquiry.Text = "رصيد البنك خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        Dim ds As New DataSet
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK11='" & ComboBank.Text & "'  AND EBNK10='" & ComboAccount.Text & "'  ORDER BY EBNK1"
                        SumAmounFINALBALANCE3()
                    Else
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK11='" & ComboBank.Text & "'  ORDER BY EBNK1"
                        SumAmounFINALBALANCE4()
                    End If
                End With
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BANKJO")
                bs.DataSource = ds
                bs.DataMember = "BANKJO"
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
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        Dim ds As New DataSet
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboType.Text & "'  AND EBNK10='" & ComboAccount.Text & "'  ORDER BY EBNK1"
                        SumAmounFINALBALANCE5()
                    Else
                        .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboType.Text & "'  ORDER BY EBNK1"
                        SumAmounFINALBALANCE6()
                    End If
                End With
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BANKJO")
                bs.DataSource = ds
                bs.DataMember = "BANKJO"
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
                SqlDataAdapter1 = New SqlDataAdapter(str)
                With str
                    If Me.ComboSpecifiedAccount.Text = "الحساب المحدد" Then
                        If Len(Me.ComboAccount.Text) = 0 Then
                            MessageBox.Show("من فضلك حدد ارقم الحساب  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                            Me.ComboAccount.Focus()
                            Exit Sub
                        End If
                        Dim ds As New DataSet
                        '.CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "' and EBNK3 BETWEEN '" & Format(Me.TEXTBOX11.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.TEXTBOX12.Value, "yyyy/MM/dd") & "'  AND EBNK8='" & ComboBox4.Text & "'  AND EBNK10='" & TEXTBOX14.Text & "'  ORDER BY EBNK1"
                        If Me.ComboCanol.Text = "مدين" Then
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK4='" & TextDebit_Cred.Text & "'  AND EBNK10='" & ComboAccount.Text & "'  ORDER BY EBNK1"
                            SumAmounFINALBALANCE7()
                        Else
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK5='" & TextDebit_Cred.Text & "'  AND EBNK10='" & ComboAccount.Text & "'  ORDER BY EBNK1"
                            SumAmounFINALBALANCE8()
                        End If
                    Else
                        If Me.ComboCanol.Text = "مدين" Then
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK4='" & TextDebit_Cred.Text & "'  ORDER BY EBNK1"
                            SumAmounFINALBALANCE9()
                        Else
                            .CommandText = "SELECT  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16 FROM BANKJO  WHERE   CUser='" & CUser & "'and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EBNK5='" & TextDebit_Cred.Text & "'  ORDER BY EBNK1"
                            SumAmounFINALBALANCE10()
                        End If
                    End If
                End With
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BANKJO")
                bs.DataSource = ds
                bs.DataMember = "BANKJO"
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = bs
                    .AutoGenerateColumns = False
                End With
            End If
            TextMovements.Text = Val(Me.DataGridView1.Rows.Count - 1)
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBEnquiry.SelectedIndexChanged
        Try
            If Me.ComboBEnquiry.Text = "رصيد حساب خلال فترة معينة" Then
                Me.ComboAccount.Enabled = True
                ComboType.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
                ComboBank.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "مصدر  الحركات  خلال فترة معينة" Then
                Me.ComboAccount.Enabled = True
                ComboType.Enabled = False
                ComboBank.Enabled = True
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "رصيد نوع الحركة خلال فترة معينة" Then
                ComboType.Enabled = True
                Me.ComboAccount.Enabled = True
                ComboBank.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "حركة مدين أو دائنة خلال فترة معينة" Then
                Me.ComboAccount.Enabled = True
                Me.ComboAccount.Enabled = True
                ComboType.Enabled = False
                ComboBank.Enabled = False
                ComboCanol.Enabled = True
                TextDebit_Cred.Enabled = True
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
            Me.ComboAccount.Enabled = False
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
            DataAdapterTab33 = New SqlDataAdapter(str)
            Dim builder36 As New SqlCommandBuilder(DataAdapterTab33)
            DataSetTab33.Clear()
            DataAdapterTab33.Fill(DataSetTab33, "DETAILSACCOUNT")
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
            Me.ComboAccount.Enabled = False
            ComboType.Enabled = False
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim ds As New DataSet
            Dim Consum As New SqlConnection(constring)
            Dim str As New SqlCommand("SELECT * FROM DETAILSACCOUNT  WHERE   CUser='" & CUser & "' and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder36 As New SqlCommandBuilder(SqlDataAdapter1)
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
        Dim strsq1 As New SqlCommand("SELECT CEMP3 FROM CABLESEMPLOYEES WHERE   CUser='" & CUser & "' and CEMP28 = '" & Me.ComboBank.Text & "'" & "ORDER BY CEMP3", Consum)
        Consum = New SqlConnection(constring)
        Dim ds1 As New DataSet
        Adp1 = New SqlDataAdapter(strsq1)
        ds.Clear()
        ComboAccount.Items.Clear()
        Adp1.Fill(ds)
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            For I As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ComboAccount.SelectedIndex = 0
                ComboAccount.Items.Add(ds.Tables(0).Rows(I).Item(0))
            Next I
        Else
            ComboAccount.Items.Clear()
        End If
        Consum.Close()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Try
            Dim ds As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim f As New FrmJO
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT EBNK1 FROM BANKJO WHERE   CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY EBNK1", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1.Fill(ds, "BANKJO")
            If Consum.State = ConnectionState.Open Then Consum.Close()
            f.BS.DataMember = "BANKJO"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("EBNK1", Me.DataGridView1.CurrentRow.Cells(0).Value)
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
    Private Sub Total()
        On Error Resume Next
        TextTotalDebit.Text = 0
        TextTotalCred.Text = 0
        TextBalance.Text = 0
        For Each r As DataGridViewRow In DataGridView1.Rows
            TextTotalDebit.Text += Val(r.Cells("EBNK4").Value)
            TextTotalCred.Text += Val(r.Cells("EBNK5").Value)
        Next
        TextTotalDebit.Text = Format(Val(TextTotalDebit.Text), "#,#0.00")
        TextTotalCred.Text = Format(Val(TextTotalCred.Text), "#,#0.00")
        TextBalance.Text = Format(Val(TextTotalDebit.Text - TextTotalCred.Text), "#,#0.00")
    End Sub
    Private Sub ButtonEXPORTTPEXCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEXPORTTPEXCEL.Click
        Try
            Dim strFileName As String
            If DataGridView1.RowCount <= 1 Then
                MessageBox.Show("الجدول فارغ من السجلات", " ملحوظة", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

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
            wSheet.Name = "حركة_البنوك"
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
                .FileName = "حركة_البنوك" & "-" & Format(Date.Today, "dd-MM-yyyy").ToString
                If .ShowDialog = Windows.Forms.DialogResult.OK Then
                    If Len(.FileName) > 0 Then
                        strFileName = ofd.FileName
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
                If Len(.FileName) > 0 Then
                    strFileName = ofd.FileName
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
            wBook.SaveAs(strFileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing)
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

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class