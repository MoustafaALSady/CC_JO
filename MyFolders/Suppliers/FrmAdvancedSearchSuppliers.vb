Imports System.Data.SqlClient
Imports System.Diagnostics
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmAdvancedSearchSuppliers
    ReadOnly cmd As New SqlCommand
    Dim Adp As New SqlClient.SqlDataAdapter
    Dim ds As New DataSet
    Public WithEvents BS As New BindingSource
    Private ReadOnly dtSource As DataTable
    Private ReadOnly PageCount As Integer
    Private ReadOnly maxRec As Integer
    Private ReadOnly pageSize As Integer
    Private CurrentPage As Integer
    Private CecNo As Integer
    'Private Sub frmAdvancedSearchSuppliers_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
    '    R.Container = Me
    'End Sub
    'Private Sub frmAdvancedSearchSuppliers_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    R.ResizeControls()
    'End Sub
    Private Sub ButtonSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSearch.Click
        On Error Resume Next
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        ds.EnforceConstraints = False
        Consum.Open()
        Dim da As DataSet
        da = ds.GetChanges
        ds = New DataSet
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL

            .CommandText = "SELECT  IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, USERNAME, Cuser, COUser, da, ne FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Adp = New SqlClient.SqlDataAdapter(strSQL)
            Dim oCommandBuilder1 As New SqlClient.SqlCommandBuilder(Adp)
            Adp.Fill(ds, "Suppliers1")
            BS.DataSource = ds
            BS.DataMember = "Suppliers1"
        End With
        Consum.Close()
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With DataGridView1
            .DataBindings.Clear()
            .DataSource = BS
            .AutoGenerateColumns = False
        End With
        Label8.Text = Me.DataGridView1.Rows.Count - 1 & "  سجل  "
        cmd.Dispose()
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub FrmAdvancedSearchSuppliers_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
                Case Keys.Enter
                    ButtonSearch.PerformClick()
                Case Keys.F5
                    ButtonXP1.PerformClick()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmAdvancedSearchSuppliers_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            FILLCOMBOBOX1("CABLESCOEMPLOYEES", "CEMP3", "CUser", CUser, Me.ComboCertificateNumbe)
            'FILLCOMBOBOX1("CABLESCOEMPLOYEES", "CEMP3", "CUser", CUser, Me.TEXTBOX14)
            FILLCOMBOBOX1("Suppliers1", "CAB10", "CUser", CUser, Me.ComboSupplier)

            Me.DataGridView1.AutoGenerateColumns = False
            FillDataBS()
            If Me.ComboSource.Items.Count > 0 Then Me.ComboSource.SelectedIndex = 0
            If Me.ComboBEnquiry.Items.Count > 0 Then Me.ComboBEnquiry.SelectedIndex = 0
            If Me.ComboCanol.Items.Count > 0 Then Me.ComboCanol.SelectedIndex = 0
            If Me.ComboSupplier.Items.Count > 0 Then Me.ComboSupplier.SelectedIndex = 0
            If Me.ComboCertificateNumbe.Items.Count > 0 Then Me.ComboCertificateNumbe.SelectedIndex = 0
            ComboSource.Enabled = False
            Total()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        '==============================
        Call MangUsers()
        Consum.Close()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboBEnquiry.KeyPress
        AutoComplete(ComboBEnquiry, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSupplier.KeyPress
        AutoComplete(ComboSupplier, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCanol.KeyPress
        AutoComplete(ComboCanol, e, )
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboSource.KeyPress
        AutoComplete(ComboSource, e, )
    End Sub
    Private Sub ListBox3_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox3.SelectedIndexChanged
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
    Private Sub ButtonPrintreport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonPrintreport.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim F As New FrmPRINT
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        If Len(Me.ComboSupplier.Text) = 0 Then
            MessageBox.Show("من فضلك حدد اسم العميل  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.ComboSupplier.Focus()
            Exit Sub
        End If
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Try
            If Me.ComboBEnquiry.Text = "رصيد عميل خلال فترة معينة" Then
                Dim rpt As New rptSuppliers11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB11='" & TextSupplierNumber.Text & "'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                rpt.SetDataSource(ds1)
                Dim txt As TextObject
                txt = rpt.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            ElseIf Me.ComboBEnquiry.Text = "رصيد حساب الجمعية لعميل خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim rpt1 As New rptAccount
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim DataSetTab33 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM DETAILSACCOUNT  WHERE CUser='" & CUser & "' and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
                Dim builder36 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                DataSetTab33.Clear()
                SqlDataAdapter1.Fill(DataSetTab33, "DETAILSACCOUNT")
                rpt1.SetDataSource(DataSetTab33)
                Dim txt As TextObject
                txt = rpt1.Section1.ReportObjects("Text4")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt1.Section1.ReportObjects("TEXT8")
                txt.Text = AssociationName
                txt = rpt1.Section1.ReportObjects("TEXT9")
                txt.Text = Directorate
                txt = rpt1.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                txt = rpt1.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                F.CrystalReportViewer1.ReportSource = rpt1
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            ElseIf Me.ComboBEnquiry.Text = "مصاريف التخليص لشهادة خدمية لعميل معين" Then
                If Len(Me.ComboCertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboCertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt2 As New rptCustomer1
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim DataSetTab2 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES  WHERE CEMP3 ='" & Me.ComboCertificateNumbe.Text & "' AND CEMP29=" & TextSupplierNumber.Text, Consum)
                Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                DataSetTab2.Clear()
                SqlDataAdapter1.Fill(DataSetTab2, "CABLESCOEMPLOYEES")
                Dim txt As TextObject
                rpt2.SetDataSource(DataSetTab2)
                txt = rpt2.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("TEXT23")
                txt.Text = Directorate
                txt = rpt2.Section1.ReportObjects("Text22")
                txt.Text = Character
                txt = rpt2.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                txt = rpt2.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                F.CrystalReportViewer1.ReportSource = rpt2
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            ElseIf Me.ComboBEnquiry.Text = "خصم مسموح بيه لعميل معين" Then
                If Len(Me.ComboCertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الدين التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboCertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt3 As New rptCustomer33
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                Dim DataSetTab2 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES  WHERE CEMP3 ='" & Val(Me.ComboCertificateNumbe.Text) & "' AND CEMP29=" & TextSupplierNumber.Text, Consum)
                Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                DataSetTab2.Clear()
                SqlDataAdapter1.Fill(DataSetTab2, "CABLESCOEMPLOYEES")
                Dim txt As TextObject
                rpt3.SetDataSource(DataSetTab2)
                txt = rpt3.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt3.Section1.ReportObjects("TEXT2")
                txt.Text = Directorate
                txt = rpt3.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                txt = rpt3.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                F.CrystalReportViewer1.ReportSource = rpt3
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            ElseIf Me.ComboBEnquiry.Text = "رصيد الشيكات  لعميل خلال فترة معينة" Then
                Dim rpt1 As New rptSuppliers11
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB6='شيك'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                rpt1.SetDataSource(ds1)
                Dim txt As TextObject
                txt = rpt1.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt1.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt1.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt1
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()

            ElseIf Me.ComboBEnquiry.Text = "رصيد النقدية  لعميل خلال فترة معينة" Then
                Dim rpt2 As New rptSuppliers11
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB6='نقدا'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                rpt2.SetDataSource(ds1)
                Dim txt As TextObject
                txt = rpt2.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt2.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt2
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()


            ElseIf Me.ComboBEnquiry.Text = "مصدر  الحركات  لعميل خلال فترة معينة" Then
                Dim rpt2 As New rptSuppliers11
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB12='" & Me.ComboSource.Text & "'", Consum)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                rpt2.SetDataSource(ds1)
                Dim txt As TextObject
                txt = rpt2.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt2.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt2
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            ElseIf Me.ComboBEnquiry.Text = "حقل مدين أو دائن  لعميل خلال فترة معينة" Then
                Dim rpt2 As New rptSuppliers11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As String = ""
                If Me.ComboCanol.Text = "مدين" Then
                    str = "SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB4=" & Me.TextDebit_Cred.Text
                Else
                    str = "SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB5=" & Me.TextDebit_Cred.Text
                End If
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                Dim ds1 As New DataSet
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str, Consum)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                rpt2.SetDataSource(ds1)
                Dim txt As TextObject
                txt = rpt2.Section1.ReportObjects("Text5")
                txt.Text = "خلال الفترة من" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " الى " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt2.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("TEXT10")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt2
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSupplier.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CAB11 FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB10 ='" & Me.ComboSupplier.Text & "'", Consum)

        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextSupplierNumber.Text = ds.Tables(0).Rows(0).Item(0)
            SELECTTHECUSTOMERFORCERTIFICATE()
        Else
            Me.TextSupplierNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
        SumAmounFINALBALANCE5()
        SumAmounFINALBALANCE4()
    End Sub
    Private Sub SumAmounFINALBALANCE5()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB5-CAB4)  FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'" & "AND CAB12='نقدا'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCashAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE5_1()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB5-CAB4)  FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11 = '" & Me.TextSupplierNumber.Text & "'" & "AND CAB12='نقدا'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCashAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE4()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB5-CAB4)  FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB11 = '" & Me.TextSupplierNumber.Text & "'" & "AND CAB12='شيك'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCurrentAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE4_1()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB5-CAB4)  FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11 = '" & Me.TextSupplierNumber.Text & "'" & "AND CAB12='شيك'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCurrentAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
        Dim SqlDataAdapter1 As SqlClient.SqlDataAdapter
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية قرات السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Me.ListBox3.Items.Clear()
            Me.TxtSearch.Text = ""
            Me.Label1.Text = ""
            Me.Label2.Text = ""
            Dim F As New FrmPRINT
            Dim txtFromDate As String
            Dim txtToDate As String
            txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
            txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
            If Len(Me.ComboSupplier.Text) = 0 Then
                MessageBox.Show("من فضلك حدد اسم العميل  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboSupplier.Focus()
                Exit Sub
            End If
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.ComboBEnquiry.Text = "رصيد مورد خلال فترة معينة" Then
                Dim rpt As New rptSuppliers11
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND CAB11='" & TextSupplierNumber.Text & "'  ORDER BY IDCAB", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                BS.DataSource = ds1
                BS.DataMember = "Suppliers1"
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = BS
                    .AutoGenerateColumns = False
                End With
                SumAmounFINALBALANCE5_1()
                SumAmounFINALBALANCE4_1()
                Consum.Close()
            ElseIf Me.ComboBEnquiry.Text = "رصيد حساب الجمعية لمورد  خلال فترة معينة" Then
                Showcustomsaccountbyreport()
            ElseIf Me.ComboBEnquiry.Text = "مصاريف لشهادة خدمية لمورد  معين" Then
                If Len(Me.ComboCertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboCertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt2 As New rptCustomer1
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES  WHERE   CUser='" & CUser & "' and CEMP3 ='" & Me.ComboCertificateNumbe.Text & "' AND CEMP10='" & Me.ComboSupplier.Text.Trim & "'  ORDER BY CEMP1", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt2.SetDataSource(ds)
                Dim txt As TextObject
                txt = rpt2.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("TEXT22")
                txt.Text = Directorate
                txt = rpt2.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                txt = rpt2.Section1.ReportObjects("Text44")
                txt.Text = Recorded

                F.CrystalReportViewer1.ReportSource = rpt2
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
                Consum.Close()
            ElseIf Me.ComboBEnquiry.Text = "خصم مسموح بيه لشهادة لمورد  معين" Then
                If Len(Me.ComboCertificateNumbe.Text) = 0 Then
                    MessageBox.Show("من فضلك ادخل رقم الشهادة  التى تبحث عنها", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboCertificateNumbe.Focus()
                    Exit Sub
                End If
                Dim rpt3 As New rptCustomer33
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                Dim DataSetTab2 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM CABLESCOEMPLOYEES  WHERE   CUser='" & CUser & "' and CEMP3 ='" & Val(Me.ComboCertificateNumbe.Text) & "' AND CEMP10 ='" & Val(Me.ComboSupplier.Text.Trim) & "'ORDER BY CEMP1", Consum)
                '                                                           WHERE   CUser='" & CUser & "' and CEMP3 ='" & Val(Me.TEXTBOX14.Text) & "' and CEMP10 ='" & Val(Me.ComboBox2.Text.Trim) & "'ORDER BY CEMP1"
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds = New DataSet
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "CABLESCOEMPLOYEES")
                rpt3.SetDataSource(ds)
                Dim txt As TextObject
                txt = rpt3.Section1.ReportObjects("TEXT21")
                txt.Text = AssociationName
                txt = rpt3.Section1.ReportObjects("TEXT2")
                txt.Text = Directorate
                txt = rpt3.Section1.ReportObjects("TEXT40")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                txt = rpt3.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                F.CrystalReportViewer1.ReportSource = rpt3
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.Refresh()
                F.Show()
                Consum.Close()
            ElseIf Me.ComboBEnquiry.Text = "رصيد الشيكات  لمورد  خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB12='شيك'  ORDER BY IDCAB", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                BS.DataSource = ds1
                BS.DataMember = "Suppliers1"
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = BS
                    .AutoGenerateColumns = False
                End With
                SumAmounFINALBALANCE1()
                SumAmounFINALBALANCE2()
                Consum.Close()
            ElseIf Me.ComboBEnquiry.Text = "رصيد النقدية  لمورد  خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT * FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB12='نقدا'  ORDER BY IDCAB", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "Suppliers1")
                BS.DataSource = ds1
                BS.DataMember = "Suppliers1"
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = BS
                    .AutoGenerateColumns = False
                End With
                SumAmounFINALBALANCE1()
                SumAmounFINALBALANCE2()
                Consum.Close()
            ElseIf Me.ComboBEnquiry.Text = "حقل مدين أو دائن  لمورد  خلال فترة معينة" Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim str As New SqlCommand("", Consum)
                With str
                    Dim ds1 As New DataSet
                    If Me.ComboCanol.Text = "مدين" Then
                        .CommandText = "SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB4=" & Me.TextDebit_Cred.Text & "  ORDER BY IDCAB"
                    Else
                        .CommandText = "SELECT * FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB5=" & Me.TextDebit_Cred.Text & "  ORDER BY IDCAB"
                    End If
                    SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                    Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                    ds1.Clear()
                    SqlDataAdapter1.Fill(ds1, "Suppliers1")
                    BS.DataSource = ds1
                    BS.DataMember = "Suppliers1"
                End With
                With DataGridView1
                    .DataBindings.Clear()
                    .DataSource = BS
                    .AutoGenerateColumns = False
                End With
                SumAmounFINALBALANCE7()
                SumAmounFINALBALANCE7_1()
            End If
            Label8.Text = Me.DataGridView1.Rows.Count - 1 & "  سجل  "
            Total()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBEnquiry.SelectedIndexChanged
        Try
            If Me.ComboBEnquiry.Text = "رصيد عميل خلال فترة معينة" Then
                Me.ComboCertificateNumbe.Enabled = False
                ComboSource.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "رصيد حساب الجمعية لعميل خلال فترة معينة" Then
                Me.ComboCertificateNumbe.Enabled = False
                ComboSource.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "مصاريف لشهادة خدمية لعميل معين" Then
                Me.ComboCertificateNumbe.Enabled = True
                ComboSource.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "خصم مسموح بيه لشهادة لعميل معين" Then
                Me.ComboCertificateNumbe.Enabled = True
                ComboSource.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "رصيد الشيكات  لعميل خلال فترة معينة" Then
                Me.ComboCertificateNumbe.Enabled = False
                ComboSource.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "رصيد النقدية  لعميل خلال فترة معينة" Then
                Me.ComboCertificateNumbe.Enabled = False
                ComboSource.Enabled = False
                ComboCanol.Enabled = False
                TextDebit_Cred.Enabled = False
            ElseIf Me.ComboBEnquiry.Text = "حقل مدين أو دائن  لعميل خلال فترة معينة" Then
                Me.ComboCertificateNumbe.Enabled = False
                ComboSource.Enabled = False
                ComboCanol.Enabled = True
                TextDebit_Cred.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub ButtonDisplyAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDisplyAll.Click
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
            Me.ComboCertificateNumbe.Enabled = False
            ComboSource.Enabled = False
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim rpt1 As New rptAccount
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            Dim DataSetTab33 As New DataSet
            Dim str As New SqlCommand("SELECT * FROM DETAILSACCOUNT  WHERE CUser='" & CUser & "' and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder36 As New SqlCommandBuilder(SqlDataAdapter1)
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
            Me.ComboCertificateNumbe.Enabled = False
            ComboSource.Enabled = False
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM DETAILSACCOUNT  WHERE CUser='" & CUser & "' and CEMP2 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder36 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "DETAILSACCOUNT")
            BS.DataSource = ds
            BS.DataMember = "DETAILSACCOUNT"
            With DataGridView1
                .DataBindings.Clear()
                .DataSource = BS
                .AutoGenerateColumns = True
            End With
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub SELECTTHECUSTOMERFORCERTIFICATE()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT CEMP3 FROM CABLESCOEMPLOYEES WHERE  CUser='" & ModuleGeneral.CUser & "' and CEMP28 = '" & Me.ComboSupplier.Text & "'" & "ORDER BY CEMP3", Consum)
        Dim ds As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        ComboCertificateNumbe.Items.Clear()
        Adp1.Fill(ds)
        Adp1.Fill(ds, "CABLESCOEMPLOYEES")
        Adp1.Dispose()
        If ds.Tables(0).Rows.Count > 0 Then
            For I As Integer = 0 To ds.Tables(0).Rows.Count - 1
                ComboCertificateNumbe.SelectedIndex = 0
                ComboCertificateNumbe.Items.Add(ds.Tables(0).Rows(I).Item(0))
            Next I
        Else
            ComboCertificateNumbe.Items.Clear()
        End If
        Consum.Close()
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmSuppliers1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM Suppliers1 WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY IDCAB", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            f.BS.DataMember = "Suppliers1"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find(NameOf(IDCAB), Me.DataGridView1.CurrentRow.Cells("IDCAB").Value)
            f.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("IDCAB").Value)
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
    Private Sub SumAmounFINALBALANCE1()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(CAB5-CAB4) FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11='" & TextSupplierNumber.Text & "' AND CAB12='شيك'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Fill(ds1, "Suppliers1")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCurrentAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE2()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT  Sum(CAB5-CAB4) FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11='" & TextSupplierNumber.Text & "' AND CAB12='نقدا'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Fill(ds1, "Suppliers1")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCashAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE3()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11'" & TextSupplierNumber.Text & "'  AND CAB12='نقدا'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Fill(ds1, "Suppliers1")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCashAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE3_1()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(CAB5-CAB4) FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11='" & TextSupplierNumber.Text & "'  AND CAB6='شيك'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Fill(ds1, "Suppliers1")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCurrentAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE7()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        Dim con As SqlClient.SqlConnection
        On Error Resume Next
        Dim strsq1 As New SqlCommand("", Consum)
        If Me.ComboCanol.Text = "مدين" Then
            strsq1.CommandText = "SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB4='" & Me.TextDebit_Cred.Text & "' AND CAB12='شيك'"
        Else
            strsq1.CommandText = "SELECT Sum(CAB5-CAB4) FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB5='" & Me.TextDebit_Cred.Text & "' AND CAB12='شيك'"
        End If
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCurrentAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub SumAmounFINALBALANCE7_1()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SUM1, SUM2, SUM3 As Double
        Dim con As SqlClient.SqlConnection
        On Error Resume Next
        Dim strsq1 As New SqlCommand("", Consum)
        If Me.ComboCanol.Text = "مدين" Then
            strsq1.CommandText = "SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB4='" & Me.TextDebit_Cred.Text & "' AND CAB12='نقدا'"
        Else
            strsq1.CommandText = "SELECT Sum(CAB5-CAB4) FROM Suppliers1  WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and CAB3 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND CAB11=" & TextSupplierNumber.Text & " AND CAB5='" & Me.TextDebit_Cred.Text & "' AND CAB12='نقدا'"
        End If
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SUM1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            SUM1 = "0"
        End If
        Consum.Close()
        Me.TextCashAccount.Text = Format(Val(SUM1), "#,#0.00")
    End Sub
    Private Sub ButtonEXPORTTPEXCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEXPORTTPEXCEL.Click
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
            Dim newCulture As System.Globalization.CultureInfo
            Dim OldCulture As System.Globalization.CultureInfo
            OldCulture = System.Threading.Thread.CurrentThread.CurrentCulture
            newCulture = New System.Globalization.CultureInfo(
                excel.LanguageSettings.LanguageID(Microsoft.Office.Core.MsoConnectorType.msoConnectorTypeMixed))
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture
            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()
            wSheet.Name = "حركة_العملاء"
            Dim dt As System.Data.DataTable = dset.Tables(0)
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
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
                .FileName = "حركة_العملاء" & "-" & Format(Date.Today, "dd-MM-yyyy").ToString
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
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
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
        TextTotalDebit.Text = 0
        TextTotalCred.Text = 0
        TextBalance.Text = 0
        For Each r As DataGridViewRow In DataGridView1.Rows
            TextTotalDebit.Text += Val(r.Cells(3).Value)
            TextTotalCred.Text += Val(r.Cells(4).Value)
        Next
        TextTotalDebit.Text = Format(Val(TextTotalDebit.Text), "#,#0.00")
        TextTotalCred.Text = Format(Val(TextTotalCred.Text), "#,#0.00")
        TextBalance.Text = Format(Val(TextTotalDebit.Text - TextTotalCred.Text), "#,#0.00")
    End Sub
    Private Sub Buttoncalcluter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Buttoncalcluter.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub LoadPage()
        Dim i As Integer
        Dim startRec As Integer
        Dim endRec As Integer
        Dim dtTemp As DataTable
        dtTemp = dtSource.Clone
        If CurrentPage = PageCount Then
            endRec = maxRec
        Else
            endRec = pageSize * CurrentPage
        End If
        startRec = CecNo
        If dtSource.Rows.Count > 0 Then
            For i = startRec To endRec - 1
                dtTemp.ImportRow(dtSource.Rows(i))
                CecNo += 1
            Next
        End If
        DataGridView1.DataSource = dtTemp
        DisplayPageInfo()
    End Sub
    Private Sub DisplayPageInfo()
        txtDisplayPageNo.Text = "صفحة " & CurrentPage.ToString & "/ " & PageCount.ToString
    End Sub
    Private Function CheckFillButton() As Boolean
        If pageSize = 0 Then
            MessageBox.Show("ضبط حجم الصفحة، ثم انقر فوق ""ملء الشبكة"" زر!")
            CheckFillButton = False
        Else
            CheckFillButton = True
        End If
    End Function
    Private Sub BtnNextPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNextPage.Click
        If Not CheckFillButton() Then Return
        CurrentPage -= 1
        If CurrentPage < 1 Then
            MessageBox.Show("أنت في الصفحة الأولى!")
            CurrentPage = 1
            Return
        Else
            CecNo = pageSize * (CurrentPage - 1)
        End If
        LoadPage()
    End Sub
    Private Sub BtnPreviousPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviousPage.Click
        If Not CheckFillButton() Then Return
        If pageSize = 0 Then
            MessageBox.Show("ضبط حجم الصفحة، ثم انقر فوق ""ملء الشبكة"" زر!")
            Return
        End If
        CurrentPage += 1
        If CurrentPage > PageCount Then
            CurrentPage = PageCount
            If CecNo = maxRec Then
                MessageBox.Show("أنت في الصفحة الأولى!")
                Return
            End If
        End If
        LoadPage()
    End Sub
    Private Sub BtnFirstPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstPage.Click
        If Not CheckFillButton() Then Return
        If CecNo = maxRec Then
            MessageBox.Show("أنت في الصفحة الأخيرة!")
            Return
        End If
        CurrentPage = PageCount
        CecNo = pageSize * (CurrentPage - 1)
        LoadPage()
    End Sub
    Private Sub BtnLastPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLastPage.Click
        If Not CheckFillButton() Then Return
        If CurrentPage = 1 Then
            MessageBox.Show("أنت في الصفحة الأولى!")
            Return
        End If
        CurrentPage = 1
        CecNo = 0
        LoadPage()
    End Sub


End Class