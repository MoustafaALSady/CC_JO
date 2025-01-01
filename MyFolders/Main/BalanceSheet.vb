Imports System.Data.SqlClient


Public Class BalanceSheet
    Dim WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlDataAdapter
    ReadOnly rpt1 As New rptStocks25
    ReadOnly rpt11 As New rptStocks26
    ReadOnly rpt12 As New rptStocks271
    ReadOnly rpt2 As New rptTrialBalance
    ReadOnly rpt3 As New RepBlanceSheet_B
    ReadOnly rpt31 As New RepBlanceSheet_A
    ReadOnly rpt4 As New RepGeneralJournal
    ReadOnly rpt5 As New RepGeneralLedger
    ReadOnly rpt6 As New RepIncomeStatement_A
    ReadOnly rpt7 As New Shareholders
    ReadOnly rpt8 As New rptReceivableDisclosure
    ReadOnly rpt9 As New Checks
    ReadOnly rpt10 As New Checks1
    ReadOnly rpt18 As New rptSuppliers12


    Private Sub BalanceSheet_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Dim ds As New DataSet
        Dim Consum As New SqlConnection(constring)
        ds.EnforceConstraints = False
        Consum.Open()
        Dim str1 As New SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT cmp2 FROM COMPANY  WHERE  CUser='" & CUser & "'  ORDER BY cmp2"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        SqlDataAdapter1 = New SqlDataAdapter(str1)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "COMPANY")
        BS.DataSource = ds
        BS.DataMember = "COMPANY"
        ComboBox1.DataSource = ds.Tables("COMPANY")
        ComboBox1.DisplayMember = "cmp2"
        Me.RadioButton9_CheckedChanged(sender, e)
        Me.RadioButton3_CheckedChanged(sender, e)
        Call MangUsers()
        Consum.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT  CUser, COUser, cmp8, cmp5, cmp13 FROM COMPANY WHERE cmp2 ='" & AssociationName & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBox1.Text = ds.Tables(0).Rows(0).Item(0)
            Me.TextBox2.Text = ds.Tables(0).Rows(0).Item(1)
            Me.TextBox3.Text = ds.Tables(0).Rows(0).Item(2)
            Me.TextBox4.Text = ds.Tables(0).Rows(0).Item(3)
            Me.TextBox5.Text = ds.Tables(0).Rows(0).Item(4)

        Else
            Me.TextBox1.Text = ""
            Me.TextBox2.Text = ""
            Me.TextBox3.Text = ""
            Me.TextBox4.Text = ""
            Me.TextBox5.Text = ""
        End If
        Adp.Dispose()
        Consum.Close()

    End Sub
    Public Sub Load_CU1_CU2()
        Dim str3 As New SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, MOV3, yearearlier, YEAR, ISNULL(CUser,CUser), ISNULL(CUser1,CUser) FROM Previouspost1  WHERE  CUser='" & ModuleGeneral.CUser & "'or  CUser1='" & ModuleGeneral.CUser & "'and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and yearearlier  ='" & (FiscalYear_currentDateMustBeInFiscalYear() - 1) & "'", Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str3)
        Dim ds3 As New DataSet
        ds3.Clear()
        SqlDataAdapter1.Fill(ds3, "Previouspost1")
        If ds3.Tables(0).Rows.Count > 0 Then
            'CU1 = ds3.Tables(0).Rows.Item("CUser")
        End If
    End Sub

    Public Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles Button1.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            'If BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim txtFROMDate As String
            Dim txtToDate As String
            txtFROMDate = Format(Me.DateTimePicker1.Value, "yyy, MM, dd, 00, 00, 000")
            txtToDate = Format(Me.DateTimePicker2.Value, "yyy, MM, dd, 00, 00, 00")
            Dim Asu As String
            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject

            Dim f As New FrmPRINT
            Asu = AssociationName
            'Dim str1 As New SqlCommand("", Consum)

            If Len(AssociationName) = 0 Then
                MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboBox1.Focus()
                Exit Sub
            End If
            If Me.DateTimePicker1.Checked = False And Me.DateTimePicker2.Checked = False Then
                MessageBox.Show("من فضلك ادخل التاريخ  فى خانة من - الى", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If

            If Me.RadrptStocks.Checked Then
                Dim str As New SqlCommand("", Consum)
                If FIFO = True Then
                    str.CommandText = "SELECT * FROM FIFOStocks    WHERE  CUser='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  STK4 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "' AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'"
                ElseIf LIFO = True Then
                    str.CommandText = "SELECT * FROM LIFOStock1    WHERE CUser ='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  STK4 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "' AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'"
                ElseIf AVG = True Then
                    str.CommandText = "SELECT * FROM AvgStocks     WHERE CUser ='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  STK4 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "' AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'"
                End If

                SqlDataAdapter1 = New SqlDataAdapter(str)
                Dim ds1 As New DataSet

                If FIFO = True Then
                    GETSERVERNAMEANDDATABASENAME(rpt1, DBServer.Trim, "", "")
                    ds1.Clear()
                    SqlDataAdapter1.Fill(ds1, "FIFOStocks")
                    rpt1.SetDataSource(ds1)
                    txt = rpt1.Section1.ReportObjects("Text5")
                    txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                    txt = rpt1.Section1.ReportObjects("Text3")
                    txt.Text = AssociationName
                    txt = rpt1.Section1.ReportObjects("Text4")
                    txt.Text = Directorate
                    txt = rpt1.Section1.ReportObjects("Text32")
                    txt.Text = Recorded
                    f.CrystalReportViewer1.ReportSource = rpt1

                    f.CrystalReportViewer1.Zoom(65%)
                    f.CrystalReportViewer1.RefreshReport()
                    f.Show()
                ElseIf LIFO = True Then
                    GETSERVERNAMEANDDATABASENAME(rpt11, DBServer.Trim, "", "")
                    ds1.Clear()
                    SqlDataAdapter1.Fill(ds1, "LIFOStock1")
                    rpt11.SetDataSource(ds1)
                    txt = rpt11.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & "_" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy") & " " & " الى " & " " & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy")
                    txt = rpt11.Section1.ReportObjects("Text3")
                    txt.Text = AssociationName
                    txt = rpt11.Section1.ReportObjects("Text4")
                    txt.Text = Directorate
                    txt = rpt11.Section1.ReportObjects("Text32")
                    txt.Text = Recorded
                    f.CrystalReportViewer1.ReportSource = rpt11
                    f.CrystalReportViewer1.Zoom(65%)
                    f.CrystalReportViewer1.RefreshReport()
                    f.Show()
                ElseIf AVG = True Then
                    GETSERVERNAMEANDDATABASENAME(rpt12, DBServer.Trim, "", "")
                    ds1.Clear()
                    SqlDataAdapter1.Fill(ds1, "AvgStocks")
                    rpt12.SetDataSource(ds1)
                    txt = rpt12.Section1.ReportObjects("Text5")
                    txt.Text = "خلال الفترة من" & "_" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy") & " " & " الى " & " " & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy")
                    txt = rpt12.Section1.ReportObjects("Text3")
                    txt.Text = AssociationName
                    txt = rpt12.Section1.ReportObjects("Text4")
                    txt.Text = Directorate
                    txt = rpt12.Section1.ReportObjects("Text32")
                    txt.Text = Recorded
                    f.CrystalReportViewer1.ReportSource = rpt12
                    f.CrystalReportViewer1.Zoom(65%)
                    f.CrystalReportViewer1.RefreshReport()
                    f.Show()
                End If
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If


            If Me.RadiorptTrialBalance.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                Dim account_no1 As Integer = 23007 Or 23007001 Or 23007002
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim str2 As New SqlCommand("SELECT account_no, account_name, ACC, SUMDEBIT, SUMCREDIT, CurrentBalance, CurrentBalance1, MOV3, YEAR, CUser, COUser FROM FINALBALANCE  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  MOV3 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'  and account_no  <>'" & account_no1 & "' ", Consum)
                Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlDataAdapter(str2)
                Dim ds2 As New DataSet
                ds2.Clear()
                SqlDataAdapter1.Fill(ds2, "FINALBALANCE")
                rpt2.SetDataSource(ds2)
                txt = rpt2.Section1.ReportObjects("Text3")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("Text4")
                txt.Text = Directorate
                txt = rpt2.Section1.ReportObjects("Text20")
                txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadRepBlanceSheet.Checked Then

                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                'GetReport()

                'Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR,CUser1 FROM Previouspost1 WHERE  CUser='" & Module1.CUser & "' or  CUser1='" & Module1.CUser & "' or  CUser  IS NULL and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ", Consum)
                'Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, ISNULL(CUser,CUser) AS CUser, ISNULL(CUser1,CUser) AS CUser1 FROM Previouspost1  WHERE  CUser='" & Module1.CUser & "'and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' or  CUser  IS NULL and CUser1 ='" & CUser & "'  ", Consum)
                'Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, ISNULL(CUser,CUser) AS CUser, ISNULL(CUser1,CUser) AS CUser1 FROM Previouspost1  WHERE  CUser='" & Module1.CUser & "'and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' or  CUser  IS NULL or CUser1 ='" & CUser & "'  ", Consum)
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                'Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, CUser, CUser1 FROM Previouspost1 WHERE  CUser='" & CUser & "'and  YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ", Consum)
                Dim str3 As New SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, YEAR1, CUser, CUser1  FROM Previouspost1  WHERE  CUser='" & CUser & "' or CUser1 ='" & CUser & "'   or  CUser  IS NULL   and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)

                'ISNULL(YEAR,'" & FiscalYear_currentDateMustBeInFiscalYear() & "'),
                SqlDataAdapter1 = New SqlDataAdapter(str3)
                Dim ds3 As New DataSet
                ds3.Clear()
                SqlDataAdapter1.Fill(ds3, "Previouspost1")
                If Me.RBB.Checked Then
                    rpt3.SetDataSource(ds3)
                    txt = rpt3.Section1.ReportObjects("Text6")
                    txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                    txt = rpt3.Section1.ReportObjects("Text40")
                    txt.Text = "عن السنة المالية المنتهية فى" & " " & "31" & "-" & "12" & "-" & FiscalYear_currentDateMustBeInFiscalYear()
                    txt = rpt3.Section1.ReportObjects("Text1")
                    txt.Text = "المركز المالي _ ل" & AssociationName
                    txt = rpt3.Section1.ReportObjects("Text5")
                    txt.Text = "المحافظة" & "/" & Directorate
                    txt = rpt3.Section1.ReportObjects("Text7")
                    txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                    txt = rpt3.Section1.ReportObjects("Text9")
                    txt.Text = CUser
                    rpt3.DataDefinition.FormulaFields("CUser_C").Text = CUser
                    rpt3.DataDefinition.FormulaFields("y").Text = FiscalYear_currentDateMustBeInFiscalYear()
                    f.CrystalReportViewer1.ReportSource = rpt3
                    f.CrystalReportViewer1.Zoom(65%)
                    f.CrystalReportViewer1.RefreshReport()
                ElseIf Me.RBA.Checked Then
                    rpt31.SetDataSource(ds3)
                    txt = rpt31.Section1.ReportObjects("Text6")
                    txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                    txt = rpt31.Section1.ReportObjects("Text40")
                    txt.Text = "عن السنة المالية المنتهية فى" & " " & "31" & "-" & "12" & "-" & FiscalYear_currentDateMustBeInFiscalYear()
                    txt = rpt31.Section1.ReportObjects("Text1")
                    txt.Text = "المركز المالي _ ل" & AssociationName
                    txt = rpt31.Section1.ReportObjects("Text5")
                    txt.Text = "المحافظة" & "/" & Directorate
                    txt = rpt31.Section1.ReportObjects("Text7")
                    txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                    txt = rpt31.Section1.ReportObjects("Text9")
                    txt.Text = CUser
                    rpt31.DataDefinition.FormulaFields("CUser_C").Text = CUser
                    rpt31.DataDefinition.FormulaFields("y").Text = FiscalYear_currentDateMustBeInFiscalYear()
                    f.CrystalReportViewer1.ReportSource = rpt31
                    f.CrystalReportViewer1.Zoom(65%)
                    f.CrystalReportViewer1.RefreshReport()
                End If
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadRepGeneralJournal.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                If Consum.State = ConnectionState.Closed Then Consum.Open()
                GETSERVERNAMEANDDATABASENAME(rpt4, DBServer, "", "")

                Dim str4 As New SqlCommand("SELECT MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, Auditor, CUser, COUser, da, ne, da1, ne1 FROM MOVES   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str4)
                Dim ds4 As New DataSet
                ds4.Clear()
                SqlDataAdapter1.Fill(ds4, "MOVES")
                rpt4.SetDataSource(ds4)
                txt = rpt4.Section1.ReportObjects("Text6")
                txt.Text = "خلال الفترة من" & "_" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy") & " " & " الى " & " " & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy")
                txt = rpt4.Section1.ReportObjects("Text2")
                txt.Text = "اليوميــة العــام _ ل" & AssociationName
                txt = rpt4.Section1.ReportObjects("Text3")
                txt.Text = "المحافظة" & " / " & Directorate
                txt = rpt4.Section1.ReportObjects("Text8")
                txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                f.CrystalReportViewer1.ReportSource = rpt4
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadRepGeneralLedger.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt5, DBServer, "", "")
                Dim str5 As New SqlCommand("SELECT MOVD4, MOVD3, AccountKind, SUMDEBIT, SUMCREDIT, CurrentBalance, CurrentBalance1, MOV2, MOV3, YEAR, CUser, COUser FROM BALANCE WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str5)
                Dim ds5 As New DataSet
                ds5.Clear()
                SqlDataAdapter1.Fill(ds5, "BALANCE")
                rpt5.SetDataSource(ds5)
                txt = rpt5.Section1.ReportObjects("Text6")
                txt.Text = "خلال الفترة من" & "_" & Format(Me.DateTimePicker1.Value, "dd-MM-yyyy") & " " & " الى " & " " & Format(Me.DateTimePicker2.Value, "dd-MM-yyyy")
                txt = rpt5.Section1.ReportObjects("Text2")
                txt.Text = "الأستـاذ العــام _ ل" & AssociationName
                txt = rpt5.Section1.ReportObjects("Text3")
                txt.Text = "المحافظة" & ":" & Directorate
                txt = rpt5.Section1.ReportObjects("Text5")
                txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                f.CrystalReportViewer1.ReportSource = rpt5
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadRepIncomeStatement.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt6, DBServer, "", "")
                Dim str6 As New SqlCommand("SELECT MOVD4, MOVD3, SUMDEBIT, SUMCREDIT, AccountKind, MOV2, MOV3, CurrentBalance, CurrentBalance1, MOV9, CUser, COUser FROM BALANCE1  WHERE  CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and MOV3 BETWEEN '" & Format(Me.DateTimePicker1.Value, "yyyy/MM/dd") & "' AND  '" & Format(Me.DateTimePicker2.Value, "yyyy/MM/dd") & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str6)
                Dim ds6 As New DataSet
                ds6.Clear()
                SqlDataAdapter1.Fill(ds6, "BALANCE1")
                rpt6.SetDataSource(ds6)
                txt = rpt6.Section1.ReportObjects("Text6")
                txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                txt = rpt6.Section1.ReportObjects("Text1")
                txt.Text = "قائمة الدخل _ ل" & AssociationName
                txt = rpt6.Section1.ReportObjects("Text2")
                txt.Text = "المحافظة" & ":" & Directorate
                txt = rpt6.Section1.ReportObjects("Text5")
                txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                f.CrystalReportViewer1.ReportSource = rpt6
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadShareholders.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                'Dim BK As PictureBox
                'Dim sql As String = "SELECT CS3 FROM CapturingSignatures  WHERE  USERNAME='" & Module1.USERNAME & "'"
                'If Consum.State = ConnectionState.Open Then Consum.Close()
                'Consum.Open()
                'Dim cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand(sql, Consum)
                'Dim b() As Byte
                'b = cmd.ExecuteScalar()
                'If (b.Length > 0) Then
                '    Dim stream As New MemoryStream(b, True)
                '    stream.Write(b, 0, b.Length)

                '    stream.Close()
                'End If

                GETSERVERNAMEANDDATABASENAME(rpt7, DBServer, "", "")
                'Dim dsCS As DSCapturingSignatures = New DSCapturingSignatures
                'Dim dr As DSCapturingSignatures.CapturingSignaturesRow = dsCS.CapturingSignatures.NewCapturingSignaturesRow
                'dr.CS3 = b
                'BK.Image = Image.FromStream(New System.IO.MemoryStream(CType(dr.Item(0), Byte())))

                Dim str7 As New SqlCommand("SELECT TBNK1, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK15, TBNK16, TBNK19, TBNK119, TBNK20, TBNK21, OpeningBalance, OpeningBalance1, OpeningBalance2, CUser FROM ALLShares  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str7)
                Dim ds7 As New DataSet
                ds7.Clear()
                'ds7.Tables(0).Columns.Add("k2", System.Type.GetType("System.Byte[]"))

                SqlDataAdapter1.Fill(ds7, "ALLShares")
                rpt7.SetDataSource(ds7)
                txt = rpt7.Section1.ReportObjects("Text12")
                txt.Text = AssociationName
                txt = rpt7.Section1.ReportObjects("Text13")
                txt.Text = Directorate
                txt = rpt7.Section1.ReportObjects("Text19")
                txt.Text = Me.TextBox5.Text
                txt = rpt7.Section1.ReportObjects("Text5")
                txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                'rpt7.SetParameterValue("picPath", DR.CS3.ToArray())

                'rpt7.DataDefinition.FormulaFields("picPath ").Text.ToArray() = b.ToArray()

                'Dim picLogo As CrystalDecisions.CrystalReports.Engine.PictureObject
                'picLogo = rpt7.ReportDefinition.ReportObjects.Item("CS31")
                'Dim pic = CType(rpt7.ReportDefinition.ReportObjects("Picture3"), PictureObject)
                'pic.ObjectFormat.EnableSuppress = True
                'picLogo.Kind.PictureObject. = Image.FromStream(New System.IO.MemoryStream(CType(dr.Item(0), Byte())))


                f.CrystalReportViewer1.ReportSource = rpt7
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadrptReceivableDisclosure.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt8, DBServer, "", "")
                Dim str8 As New SqlCommand("SELECT LO, Lo2, Lo3, Lo4, Lo5, Lo6, Lo7, Lo8, Lo9, Lo10, Lo11, Lo12, Lo13, SUMcab5, lo15, lo19, Lo20, Lo21, Lo22, Lo23, Lo24, Lo25, Lo26, Lo30, SUMcab4, CAB7, OpeningBalance, OpeningBalance1, CUser FROM CustomersCABLES2   WHERE lo19 ='" & False & "' AND Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND CUser ='" & CUser & "'", Consum)
                SqlDataAdapter1 = New SqlDataAdapter(str8)
                Dim ds8 As New DataSet
                ds8.Clear()
                SqlDataAdapter1.Fill(ds8, "CustomersCABLES2")
                rpt8.SetDataSource(ds8)
                txt = rpt8.Section1.ReportObjects("Text4")
                txt.Text = AssociationName
                txt = rpt8.Section1.ReportObjects("Text8")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt8
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadrptSuppliers12.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt18, DBServer, "", "")
                Dim str8 As New SqlCommand("SELECT IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Auditor, CUser,  COUser, da, ne, da1, ne1 FROM Suppliers1   WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND CAB19 ='" & True & "'", Consum)

                SqlDataAdapter1 = New SqlDataAdapter(str8)
                Dim ds8 As New DataSet
                ds8.Clear()
                SqlDataAdapter1.Fill(ds8, "Suppliers1")
                rpt8.SetDataSource(ds8)
                txt = rpt18.Section1.ReportObjects("Text4")
                txt.Text = AssociationName
                txt = rpt18.Section1.ReportObjects("Text8")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt18
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If

            If Me.RadioChecks.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt9, DBServer, "", "")
                Dim str9 As New SqlCommand("", Consum)
                With str9
                    If RBExpense.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH17 ='" & True & "' ORDER BY CH2"
                    ElseIf RBPortfolio.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH20 ='" & True & "' ORDER BY CH2"
                    ElseIf RBUndercollection.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH21 ='" & True & "' ORDER BY CH2"
                    ElseIf RBReturned.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH22 ='" & True & "' ORDER BY CH2"
                    ElseIf RBReturnedinbank.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' and CH23 ='" & True & "' ORDER BY CH2"
                    ElseIf RBWard.Checked = True Then
                        'صادر
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & False & "' ORDER BY CH2"
                    End If
                End With
                SqlDataAdapter1 = New SqlDataAdapter(str9)
                Dim ds9 As New DataSet
                ds9.Clear()
                SqlDataAdapter1.Fill(ds9, "Checks")
                rpt9.SetDataSource(ds9)
                txt = rpt9.Section1.ReportObjects("Text12")
                txt.Text = AssociationName
                txt = rpt9.Section1.ReportObjects("Text13")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt9
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If

            If Me.RadChecks1.Checked Then
                If Len(AssociationName) = 0 Then
                    MessageBox.Show("من فضلك ادخل اسم الجمعية الذى تبحث عنه", "بحث وطباعه", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboBox1.Focus()
                    Exit Sub
                End If
                GETSERVERNAMEANDDATABASENAME(rpt10, DBServer, "", "")
                Dim str10 As New SqlCommand("", Consum)
                With str10
                    If RBExpense.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' and CH17 ='" & True & "' ORDER BY CH2"
                    ElseIf RBReturned.Checked = True Then
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' and CH22 ='" & True & "' ORDER BY CH2"
                    ElseIf RBIssued.Checked = True Then
                        'صادر
                        .CommandText = "SELECT IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH13, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH24, CH25, CH26, CH27, CB1, BN2, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM Checks  WHERE  CUser='" & CUser & "' and CH15 ='" & True & "' ORDER BY CH2"
                    End If
                End With
                SqlDataAdapter1 = New SqlDataAdapter(str10)
                Dim ds10 As New DataSet
                ds10.Clear()
                SqlDataAdapter1.Fill(ds10, "Checks")
                rpt10.SetDataSource(ds10)
                txt = rpt10.Section1.ReportObjects("Text12")
                txt.Text = AssociationName
                txt = rpt10.Section1.ReportObjects("Text13")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt10
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If
            If Me.RadCrystalFixedAssets.Checked Then
                Dim rpt As New CrystalFixedAssets
                GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT IDFA, FA1, FA2, FA3, FA4, FA5, FA6, FA7, FA8, FA9, FA10, FA11, FA12, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM FixedAssets   WHERE  CUser='" & ModuleGeneral.CUser & "'   ", Consum)
                Dim builder19 As New SqlCommandBuilder(SqlDataAdapter1)
                SqlDataAdapter1 = New SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "FixedAssets")
                rpt.SetDataSource(ds)
                txt = rpt.Section1.ReportObjects("Text15")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("Text32")
                txt.Text = Directorate
                f.CrystalReportViewer1.ReportSource = rpt
                f.CrystalReportViewer1.Zoom(90%)
                f.CrystalReportViewer1.Refresh()
                f.Show()
                If Consum.State = ConnectionState.Open Then Consum.Close()
            End If


        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadRepBlanceSheet.CheckedChanged
        If Me.RadRepBlanceSheet.Checked = True Then
            Me.GroupBox3.Enabled = True
        Else
            Me.GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub RadioButton9_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioChecks.CheckedChanged
        If Me.RadioChecks.Checked = True Then
            Me.GroupBox2.Enabled = True
            Me.RBWard.Checked = True
            Me.RBWard.Enabled = True
            Me.RBIssued.Checked = False
            Me.RBIssued.Enabled = False
            Me.RBPortfolio.Enabled = True
            Me.RBUndercollection.Enabled = True
            Me.RBReturnedinbank.Enabled = True
            Me.RBExpense.Enabled = True
            Me.RBReturned.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
            Me.RBWard.Checked = False
            Me.RBWard.Enabled = False
            Me.RBIssued.Checked = True
            Me.RBIssued.Enabled = True
            Me.RBPortfolio.Enabled = False
            Me.RBUndercollection.Enabled = False
            Me.RBReturnedinbank.Enabled = False
            Me.RBExpense.Enabled = False
            Me.RBReturned.Enabled = False
        End If

    End Sub

    Private Sub RadioButton10_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadChecks1.CheckedChanged
        If Me.RadChecks1.Checked = True Then
            Me.GroupBox2.Enabled = True
            Me.RBWard.Checked = False
            Me.RBWard.Enabled = False
            Me.RBIssued.Checked = True
            Me.RBIssued.Enabled = True
            Me.RBExpense.Enabled = True
            Me.RBReturned.Enabled = True
        Else
            Me.GroupBox2.Enabled = False
            Me.RBWard.Checked = True
            Me.RBWard.Enabled = True
            Me.RBIssued.Checked = False
            Me.RBIssued.Enabled = False

            Me.RBExpense.Enabled = False
            Me.RBReturned.Enabled = False
        End If

    End Sub

End Class