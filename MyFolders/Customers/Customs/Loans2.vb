Option Explicit Off

Imports System.Data.SqlClient
Public Class Loans2
    Inherits Form
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As SqlDataAdapter
    ReadOnly ds As New DataSet
    Public TB1 As String
    Private Sub Loans2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.DataGridView1.AutoGenerateColumns = False
        Dim Consum As New SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT  Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, Auditor, CUser, COUser, da, ne FROM LoansPa  WHERE  CUser='" & CUser & "'" & "AND loa6>'0'"
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter1 = New SqlDataAdapter(strSQL)
        Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "LoansPa")
        BS.DataSource = ds
        BS.DataMember = "LoansPa"
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Text1.Text = ds.Tables("LoansPa").Rows(Me.BS.Position)("Loa1").ToString
            Me.CheckBox2.Checked = ds.Tables("LoansPa").Rows(Me.BS.Position)("Loa14").ToString

        End If
        Consum.Close()
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            .DataBindings.Clear()
            .DataSource = Me.BS
            .AutoGenerateColumns = False
        End With
        '==============================
        Auditor("LoansPa", "USERNAME", "LO1", Me.Text1.Text, "")
        Logentry = Uses
        Call MangUsers()
        FILLCOMBOBOX1("Loans", "lo5", "CUser", CUser, Me.ComboCustomerName)
        FILLCOMBOBOX1("LoansPa", "lo", "CUser", CUser, Me.TextDebtNumber)
        Me.Button1_Click(sender, e)
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboCustomerName, e, )
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboInstallmentNumber, e, )
    End Sub
    Private Sub TEXTBOX14_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.TextDebtNumber, e, )
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEnquiry.Click
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "yyyy, MM, dd, 00, 00, 00")
        txtToDate = Format(Me.DateTO.Value, "yyyy, MM, dd, 00, 00, 00")
        If Len(Me.ComboCustomerName.Text) = 0 Then
            MessageBox.Show("من فضلك حدد اسم العميل  الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.ComboCustomerName.Focus()
            Exit Sub
        End If
        'Me.DataGridView1.Rows.Clear()
        Try
            If Me.RadioButton1.Checked = True Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim Consum As New SqlConnection(constring)
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, Auditor, CUser, COUser, da, ne FROM LoansPa  WHERE loa5 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND loa10='" & Me.TextCustomerNumber.Text.Trim & "'  ORDER BY lo", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "LoansPa")
                Me.BS.DataSource = ds1
                Me.BS.DataMember = "LoansPa"
                With Me.DataGridView1
                    .DataBindings.Clear()
                    .DataSource = Me.BS
                    .AutoGenerateColumns = False
                End With
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.Text1.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa4").ToString
                    Me.TextLO25.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("LO25").ToString
                    Me.CheckBox2.Checked = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa14").ToString
                    Me.TextLSet.Text = Strings.LSet(Me.TextLO25.Text, 2)
                Else
                    Exit Sub
                End If

                Auditor("LoansPa", "USERNAME", "Loa4", Me.Text1.Text, "")
                Logentry = Uses
            ElseIf Me.RadioButton2.Checked = True Then
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, Auditor, CUser, COUser, da, ne FROM LoansPa  WHERE loa5 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND lo='" & Me.TextDebtNumber.Text.Trim & "'  ORDER BY lo", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "LoansPa")
                Me.BS.DataSource = ds1
                Me.BS.DataMember = "LoansPa"
                With Me.DataGridView1
                    .DataBindings.Clear()
                    .DataSource = Me.BS
                    .AutoGenerateColumns = False
                End With
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.Text1.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa4").ToString
                    Me.TextLO25.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("LO25").ToString
                    Me.CheckBox2.Checked = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa14").ToString
                    Me.TextLSet.Text = Strings.LSet(Me.TextLO25.Text, 2)
                Else
                    Exit Sub
                End If
                Auditor("LoansPa", "USERNAME", "Loa4", Me.Text1.Text, "")
                Logentry = Uses
            ElseIf Me.RadioButton3.Checked = True Then
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, Auditor, CUser, COUser, da, ne FROM LoansPa  WHERE loa5 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND lo='" & Me.TextDebtNumber.Text.Trim & "' AND loa='" & Me.ComboInstallmentNumber.Text.Trim & "'  ORDER BY lo", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "LoansPa")
                Me.BS.DataSource = ds1
                Me.BS.DataMember = "LoansPa"
                With Me.DataGridView1
                    .DataBindings.Clear()
                    .DataSource = Me.BS
                    .AutoGenerateColumns = False
                End With
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.Text1.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa4").ToString
                    Me.TextLO25.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("LO25").ToString
                    Me.CheckBox2.Checked = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa14").ToString
                    Me.TextLSet.Text = Strings.LSet(Me.TextLO25.Text, 2)
                Else
                    Exit Sub
                End If
                Auditor("LoansPa", "USERNAME", "Loa4", Me.Text1.Text, "")
                Logentry = Uses
            ElseIf Me.RadioButton4.Checked = True Then
                Dim ds1 As New DataSet
                Dim str As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, Auditor, CUser, COUser, da, ne FROM LoansPa  WHERE loa5 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND loa16='" & True & "'  ORDER BY lo", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim builder4 As New SqlCommandBuilder(SqlDataAdapter1)
                ds1.Clear()
                SqlDataAdapter1.Fill(ds1, "LoansPa")
                Me.BS.DataSource = ds1
                Me.BS.DataMember = "LoansPa"
                With Me.DataGridView1
                    .DataBindings.Clear()
                    .DataSource = Me.BS
                    .AutoGenerateColumns = False
                End With
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.Text1.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa4").ToString
                    Me.TextLO25.Text = ds1.Tables("LoansPa").Rows(Me.BS.Position)("LO25").ToString
                    Me.CheckBox2.Checked = ds1.Tables("LoansPa").Rows(Me.BS.Position)("Loa14").ToString
                    Me.TextLSet.Text = Strings.LSet(Me.TextLO25.Text, 2)
                Else
                    Exit Sub
                End If
                Auditor("LoansPa", "USERNAME", "Loa4", Me.Text1.Text, "")
                Logentry = Uses
            End If
            Me.Button1_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        Me.DataGridView1.AutoGenerateColumns = False
        Dim Consum As New SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT  Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, USERNAME, Auditor, CUser, COUser, da, ne FROM LoansPa  WHERE  CUser='" & CUser & "'" & "AND Loa1='" & Strings.Trim(Me.TB1) & "'"
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter1 = New SqlDataAdapter(strSQL)
        Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "LoansPa")
        Me.BS.DataSource = ds
        Me.BS.DataMember = "LoansPa"
        If ds.Tables(0).Rows.Count > 0 Then
            Me.Text1.Text = ds.Tables("LoansPa").Rows(Me.BS.Position)("Loa1").ToString
            Me.CheckBox2.Checked = ds.Tables("LoansPa").Rows(Me.BS.Position)("Loa14").ToString

        End If
        Consum.Close()
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            .DataBindings.Clear()
            .DataSource = Me.BS
            .AutoGenerateColumns = False
        End With
    End Sub
    Sub NOLOA()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim AsUser1 As New SqlCommand("select loa from LoansPa where lo = '" & Me.TextDebtNumber.Text & "'", Consum)
        Dim ds5 As New DataSet
        Adp = New SqlDataAdapter(AsUser1)
        ds5.Clear()
        Consum.Open()
        Adp.Fill(ds5, "LoansPa")
        Consum.Close()
        Me.ComboInstallmentNumber.DataSource = ds5.Tables("LoansPa")
        Me.ComboInstallmentNumber.ValueMember = "loa"
    End Sub
    Private Sub TEXTBOX14_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles TextDebtNumber.SelectedIndexChanged
        On Error Resume Next
        NOLOA()
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT IDcust FROM AllCustomers WHERE cust2 ='" & Me.ComboCustomerName.Text & "'", Consum)

        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextCustomerNumber.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextCustomerNumber.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
    Private Sub ButtonDisplyAll_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDisplyAll.Click
        On Error Resume Next
        Me.Loans2_Load(sender, e)
    End Sub
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New Loans
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT Lo FROM Loans WHERE   CUser='" & CUser & "' and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY Lo", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder68 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Loans")
            f.BS.DataMember = "Loans"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("Lo", Me.DataGridView1.CurrentRow.Cells("Lo").Value)
            f.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("Lo").Value)
            f.Show()
            f.Load_Click(sender, e)
            f.BS.Position = index
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMembershipNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New Loans3
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT TBNK1 FROM PTRANSACTION WHERE  CUser='" & CUser & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "PTRANSACTION")
            f.BS.DataMember = "PTRANSACTION"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("TBNK1", Me.MembershipNumber.Text.Trim)
            f.Show()
            f.TextTBNK1.Text = Me.MembershipNumber.Text
            f.BS.Position = index
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
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
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
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
    Private Sub UPDATELoansPa()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE LoansPa SET   loa16 = @loa16, Auditor = @Auditor, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE Loa1 = '" & DataGridView1.Item("Loa1", DataGridView1.CurrentRow.Index).Value() & "'", Consum)
            Dim CMD As New SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@loa16", SqlDbType.Bit).Value = Convert.ToInt32(CheckBox3.Checked)
                .Parameters.Add("@CUser", SqlDbType.Int).Value = CUser
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
            CMD.Parameters.Clear()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles InternalAuditorERBUTTON.Click
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
        If Me.CheckBox2.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckBox3.Checked = True
        Me.UPDATELoansPa()
        Me.Loans2_Load(sender, e)
        Me.UPDATELoansPa()
        Insert_Actions(Me.Text1.Text.Trim, "المراجع", Me.Text)
        Me.BS.Position = P
        Me.Button1_Click(sender, e)
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        If Me.CheckBox3.Checked = False Then
            MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckBox3.Checked = False
        Me.UPDATELoansPa()
        Me.Loans2_Load(sender, e)
        Me.UPDATELoansPa()
        Insert_Actions(Me.Text1.Text.Trim, "إلغاء المراجع", Me.Text)
        Me.BS.Position = P
        Me.Button1_Click(sender, e)
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
        On Error Resume Next
        SEARCHDATA.SEARCHID3(Trim(Me.DataGridView1.Item("Loa4", Me.DataGridView1.CurrentRow.Index).Value().ToString.Trim))
        Me.MembershipNumber.Text = SEARCHDATA.TBNK1A.ToString.Trim
        Me.Text1.Text = Trim(Me.DataGridView1.Item("Loa4", Me.DataGridView1.CurrentRow.Index).Value())
        Strings.LSet(Me.TextLO25.Text, 5)
        If Strings.LSet(Me.Text1.Text.Trim, 5) = FiscalYear_currentDateMustBeInFiscalYear() Then
            SEARCHDATA.SEARCHMOVESFalse(Trim(Me.DataGridView1.Item("Loa4", Me.DataGridView1.CurrentRow.Index).Value().ToString.Trim))
        Else
            SEARCHDATA.SEARCHMOVESFalse(Trim(Me.DataGridView1.Item("Lo25", Me.DataGridView1.CurrentRow.Index).Value()).ToString.Trim)
        End If
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C.ToString.Trim

        SEARCHDATA.SEARCHCASHIER1(Trim(Me.DataGridView1.Item("Lo25", Me.DataGridView1.CurrentRow.Index).Value()), Trim(Me.DataGridView1.Item("Loa4", Me.DataGridView1.CurrentRow.Index).Value()))
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1B.ToString.Trim

    End Sub

End Class