Imports System.Data.SqlClient


Public Class FormExternalAuditor
<<<<<<< HEAD
    Inherits Form
    Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Dim dt As New DataTable
    ReadOnly rpt1 As New rptStocks25
    ReadOnly rpt11 As New rptStocks26
    ReadOnly rpt12 As New rptStocks271
    ReadOnly rpt2 As New rptTrialBalance
    ReadOnly rpt3 As New RepBlanceSheet_B
    ReadOnly rpt4 As New RepGeneralJournal
    ReadOnly rpt5 As New RepGeneralLedger
    ReadOnly rpt6 As New RepIncomeStatement_A
    ReadOnly rpt7 As New Shareholders
    ReadOnly rpt8 As New rptReceivableDisclosure
    ReadOnly rpt9 As New Checks
    ReadOnly rpt10 As New Checks1
    ReadOnly rpt18 As New rptSuppliers12
    Dim IDFL As Integer = 0
    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Me.CircularProgress1.Visible = True
            Me.CircularProgress1.IsRunning = True
            MessageManager = False
            Call MangUsers()
            If ExternalAuditor = False Then
                MsgBox("عفوا .. غير مسموح لك بدخول هذه الشاشة", 16, "تنبيه")
                Me.Close()
                Exit Sub
            End If
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            dt = New DataTable
            Me.SqlDataAdapter1 = New SqlDataAdapter("select  IDFL, FL1, FL2, FL3, FL4, FL5, FL6, FL7, FL8, FL9, FL10, FL11, FL12, FL13, FL14, FL15  from FinancialList     WHERE  FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and   FL8='" & True & "'  ", Consum)
            Me.SqlDataAdapter1.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.DataGridViewX1.DataSource = dt
                'Me.DataGridViewX1.Columns(0).Visible = False
                Me.DataGridViewX1.Columns(1).HeaderText = "اسم الجمعية"
                Me.DataGridViewX1.Columns(2).HeaderText = "الرقم الوطني للجمعية"
                Me.DataGridViewX1.Columns(3).HeaderText = "السنة المالية"
                Me.DataGridViewX1.Columns(4).HeaderText = "اسم المدقق"
                Me.DataGridViewX1.Columns(5).HeaderText = "اعتماد المحاسب"
                Me.DataGridViewX1.Columns(6).HeaderText = "اعتماد مدقق الحسابات"
                Me.DataGridViewX1.Columns(7).HeaderText = "اعتماد مدير التعاون"
                Me.DataGridViewX1.Columns(8).HeaderText = "اعتماد رئيس قسم الحسابات الخارجي"
                Me.DataGridViewX1.Columns(9).HeaderText = "اعتماد مدقق الحسابات الخارجي"

                'Me.DataGridView1.Columns(1).Width = "140"
                'Me.DataGridView1.Columns(2).Width = "65"
                'Me.DataGridView1.Columns(3).Width = "50"
                'Me.DataGridView1.Columns(4).Width = "75"
                'Me.DataGridView1.Columns(5).Width = "50"
                'Me.DataGridView1.Columns(6).Width = "50"
                'Me.DataGridView1.Columns(7).Width = "50"
                'Me.DataGridView1.Columns(8).Width = "50"

            Else
                'MessageBox.Show("لاتوجد بيانات حالية للمصادقة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                MsgBox("لاتوجد بيانات حالية للمصادقة علية", 64 + 524288, "بيانات")
                Me.ComboAssociationName.Enabled = False
                Me.ButtonEnquiry.Enabled = False
                Me.ButtonViewDocuments.Enabled = False
                Me.ButtonAttachDocument.Enabled = False
                Me.ButtonApproval.Enabled = False
                Me.ButtonRefusal.Enabled = False
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorFormInternalAuditor_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker1.ProgressChanged
        'Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        'Me.DataGridViewX1.Columns(1).Width = 160

        If dt.Rows.Count > 0 Then
            Me.TextNumberOfAssociationsSent.Text = Me.DataGridViewX1.Rows.Count
            Me.IDFL1.Text = Me.DataGridViewX1.CurrentRow.Cells(0).Value
            Me.TextAssociationName.Text = Me.DataGridViewX1.CurrentRow.Cells(1).Value
            Me.TextAssociationNationalNumber.Text = Me.DataGridViewX1.CurrentRow.Cells(2).Value
            Me.TextFiscalYear.Text = Me.DataGridViewX1.CurrentRow.Cells(3).Value
            Me.TextCondition.Text = Me.DataGridViewX1.CurrentRow.Cells(11).Value
            Me.TextReasonsForRejectingBudgetFromAuditor.Text = Me.DataGridViewX1.CurrentRow.Cells(12).Value
            Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Text = Me.DataGridViewX1.CurrentRow.Cells(13).Value
            Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Text = Me.DataGridViewX1.CurrentRow.Cells(14).Value
            Me.TextReasonsForRejectingBudgetFromExternalAuditor.Text = Me.DataGridViewX1.CurrentRow.Cells(15).Value

            Me.DataGridViewX1.Columns(0).Visible = False
            Me.DataGridViewX1.Columns(10).Visible = False
            Me.DataGridViewX1.Columns(11).Visible = False
            Me.DataGridViewX1.Columns(12).Visible = False
            Me.DataGridViewX1.Columns(13).Visible = False
            Me.DataGridViewX1.Columns(14).Visible = False
            Me.DataGridViewX1.Columns(15).Visible = False

            'Me.DataGridViewX1.Columns(1).Width = "140"
            'Me.DataGridViewX1.Columns(2).Width = "65"
            'Me.DataGridViewX1.Columns(3).Width = "50"
            'Me.DataGridViewX1.Columns(4).Width = "75"
            'Me.DataGridViewX1.Columns(5).Width = "50"
            'Me.DataGridViewX1.Columns(6).Width = "50"
            'Me.DataGridViewX1.Columns(7).Width = "50"
            'Me.DataGridViewX1.Columns(8).Width = "50"

            If dt.Rows(0).Item("FL9") = True And dt.Rows(0).Item("FL10") = "5" Then
                Me.ButtonApproval.Enabled = False
                Me.ButtonRefusal.Enabled = True
            ElseIf dt.Rows(0).Item("FL9") = False And dt.Rows(0).Item("FL10") = "3" Then
                Me.ButtonApproval.Enabled = True
                Me.ButtonRefusal.Enabled = False
            ElseIf dt.Rows(0).Item("FL9") = False And dt.Rows(0).Item("FL10") = "4" Then
                Me.ButtonApproval.Enabled = True
                Me.ButtonRefusal.Enabled = True
            End If
            'Else
            '    Me.ButtonX12.Enabled = False
            '    Me.ButtonX1.Enabled = False
            '    MessageBox.Show("لاتوجد بيانات حالية ", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            'Exit Sub
        End If
        'FILLCOMBOBOX2("FinancialList", "FL1", "FL8", Trim("True"), Me.ComboBoxEx2)
        'FILLCOMBOBOX2("FinancialList", "FL1", "FL8", 1, Me.ComboBoxEx2)
        'FILLCOMBOBOX2("FinancialList", "FL1", "FL8", Trim("True"), Me.ComboBoxEx2)
        FILLCOMBOBOX3("FinancialList", "FL1", "FL3", FiscalYear_currentDateMustBeInFiscalYear(), "FL8", Trim("True"), Me.ComboAssociationName)

        Auditor("FinancialList", "USERNAME", "IDFL", Me.IDFL1.Text, "")
        Logentry = Uses

        Consum.Close()
        Me.DataGridViewX1.AutoGenerateColumns = False
        Me.DataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridViewX1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridViewX1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.CircularProgress1.IsRunning = False
        Me.CircularProgress1.Visible = False
        SqlDataAdapter1.Dispose()
    End Sub

<<<<<<< HEAD
    Private Sub FormExternalAuditor_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FormExternalAuditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Me.CircularProgress1.Value = 0
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.RunWorkerAsync()
    End Sub
    Private Sub LoadFormInternalAuditor()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            dt = New DataTable
            Me.SqlDataAdapter1 = New SqlDataAdapter("select  IDFL, FL1, FL2, FL3, FL4, FL5, FL6, FL7, FL8, FL9, FL10, FL11, FL12, FL13, FL14, FL15  from FinancialList   WHERE  FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and      FL8='" & True & "'  ", Consum)
            Me.SqlDataAdapter1.Fill(dt)
            If dt.Rows.Count > 0 Then
                Me.DataGridViewX1.DataSource = dt
                Me.DataGridViewX1.Columns(1).HeaderText = "اسم الجمعية"
                Me.DataGridViewX1.Columns(2).HeaderText = "الرقم الوطني للجمعية"
                Me.DataGridViewX1.Columns(3).HeaderText = "السنة المالية"
                Me.DataGridViewX1.Columns(4).HeaderText = "اسم المدقق"
                Me.DataGridViewX1.Columns(5).HeaderText = "اعتماد المحاسب"
                Me.DataGridViewX1.Columns(6).HeaderText = "اعتماد مدقق الحسابات"
                Me.DataGridViewX1.Columns(7).HeaderText = "اعتماد مدير التعاون"
                Me.DataGridViewX1.Columns(8).HeaderText = "اعتماد رئيس قسم الحسابات الخارجي"
                Me.DataGridViewX1.Columns(9).HeaderText = "اعتماد مدقق الحسابات الخارجي"

                Me.TextNumberOfAssociationsSent.Text = Me.DataGridViewX1.Rows.Count
                Me.IDFL1.Text = Me.DataGridViewX1.CurrentRow.Cells(0).Value
                Me.TextAssociationName.Text = Me.DataGridViewX1.CurrentRow.Cells(1).Value
                Me.TextAssociationNationalNumber.Text = Me.DataGridViewX1.CurrentRow.Cells(2).Value
                Me.TextFiscalYear.Text = Me.DataGridViewX1.CurrentRow.Cells(3).Value
                Me.TextCondition.Text = Me.DataGridViewX1.CurrentRow.Cells(11).Value
                Me.TextReasonsForRejectingBudgetFromAuditor.Text = Me.DataGridViewX1.CurrentRow.Cells(12).Value
                Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Text = Me.DataGridViewX1.CurrentRow.Cells(13).Value
                Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Text = Me.DataGridViewX1.CurrentRow.Cells(14).Value
                Me.TextReasonsForRejectingBudgetFromExternalAuditor.Text = Me.DataGridViewX1.CurrentRow.Cells(15).Value
                Consum.Close()
                Me.DataGridViewX1.Columns(0).Visible = False
                Me.DataGridViewX1.Columns(10).Visible = False
                Me.DataGridViewX1.Columns(11).Visible = False
                Me.DataGridViewX1.Columns(12).Visible = False
                Me.DataGridViewX1.Columns(13).Visible = False
                Me.DataGridViewX1.Columns(14).Visible = False
                If dt.Rows(0).Item("FL9") = True And dt.Rows(0).Item("FL10") = "5" Then
                    Me.ButtonApproval.Enabled = False
                    Me.ButtonRefusal.Enabled = True
                ElseIf dt.Rows(0).Item("FL9") = False And dt.Rows(0).Item("FL10") = "3" Then
                    Me.ButtonApproval.Enabled = True
                    Me.ButtonRefusal.Enabled = False
                ElseIf dt.Rows(0).Item("FL9") = False And dt.Rows(0).Item("FL10") = "4" Then
                    Me.ButtonApproval.Enabled = True
                    Me.ButtonRefusal.Enabled = True
                End If
            Else
                MessageBox.Show("لاتوجد بيانات حالية للمصادقة علية", "مصادقة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboAssociationName.Enabled = False
                Me.ButtonEnquiry.Enabled = False
                Me.ButtonViewDocuments.Enabled = False
                Me.ButtonAttachDocument.Enabled = False
                Me.ButtonApproval.Enabled = False
                Me.ButtonRefusal.Enabled = False
                Exit Sub
            End If
            Me.DataGridViewX1.AutoGenerateColumns = False
            Me.DataGridViewX1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Me.DataGridViewX1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Dim Column As New DataGridViewCheckBoxColumn
            With Me.DataGridViewX1
                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            End With

            SqlDataAdapter1.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorFormInternalAuditor_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub
    Private Sub CountDATAITEMS1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()


<<<<<<< HEAD
        Dim MC1 As SqlDataAdapter
        Dim strSQLmc1 As New SqlCommand("SELECT COUNT(IDFL)  FROM FinancialList  WHERE   FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and FL8='" & True & "' ", Consum)
        Dim dsMC1 As New DataSet
        MC1 = New SqlDataAdapter(strSQLmc1)
=======
        Dim MC1 As SqlClient.SqlDataAdapter
        Dim strSQLmc1 As New SqlCommand("SELECT COUNT(IDFL)  FROM FinancialList  WHERE   FL3 ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and FL8='" & True & "' ", Consum)
        Dim dsMC1 As New DataSet
        MC1 = New SqlClient.SqlDataAdapter(strSQLmc1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        dsMC1.Clear()
        MC1.Fill(dsMC1)
        If dsMC1.Tables(0).Rows.Count > 0 Then
            Me.TextNumberOfCompletedAssociations.Text = dsMC1.Tables(0).Rows(0).Item(0)
        Else
            Me.TextNumberOfCompletedAssociations.Text = "0"
        End If
        MC1.Dispose()
    End Sub
    Public Sub SELECT_MOVES4(ByVal DataGrid As Object)
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim ds1 As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim str As New SqlCommand("", Consum)
        If FIFO = True Then
            str.CommandText = "SELECT * FROM FIFOStocks    WHERE  CUser='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds1 As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim str As New SqlClient.SqlCommand("", Consum)
        If FIFO = True Then
            str.CommandText = "SELECT * FROM FIFOStocks    WHERE  CUser='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "FIFOStocks")
        ElseIf LIFO = True Then
            str.CommandText = "SELECT * FROM LIFOStock1    WHERE CUser ='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "LIFOStock1")
        ElseIf AVG = True Then
            str.CommandText = "SELECT * FROM AvgStocks     WHERE CUser ='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "AvgStocks")
        End If
        If ds1.Tables(0).Rows.Count > 0 Then
            ABA1 = "A"
            RB1 = True
            DataGrid.Rows.Add("=== كشف المخازن ===", "1", Nothing, Nothing, Nothing, Nothing, Nothing)
        Else
            ABA1 = "0"
            RB1 = False
        End If

        Dim ds10 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter10 As New SqlDataAdapter
        Dim str10 As New SqlCommand("SELECT * FROM FixedAssets  WHERE  CUser='" & ModuleGeneral.CUser & "' ", Consum)
        SqlDataAdapter10 = New SqlDataAdapter(str10)
=======
        Dim SqlDataAdapter10 As New SqlClient.SqlDataAdapter
        Dim str10 As New SqlClient.SqlCommand("SELECT * FROM FixedAssets  WHERE  CUser='" & ModuleGeneral.CUser & "' ", Consum)
        SqlDataAdapter10 = New SqlClient.SqlDataAdapter(str10)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds10.Clear()
        SqlDataAdapter10.Fill(ds10, "FixedAssets")
        If ds10.Tables(0).Rows.Count > 0 Then
            ABA2 = "2"
            DataGrid.Rows.Add("=== كشف الاثاث ===", "2", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB2 = True
        Else
            ABA2 = "0"
            RB2 = False
        End If


        Dim ds2 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter2 As New SqlDataAdapter
        Dim str2 As New SqlCommand("SELECT * FROM FINALBALANCE  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
        SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
        Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
        Dim str2 As New SqlClient.SqlCommand("SELECT * FROM FINALBALANCE  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
        SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        SqlDataAdapter2.Fill(ds2, "FINALBALANCE")
        If ds2.Tables(0).Rows.Count > 0 Then
            ABA3 = "3"
            RB3 = True
            DataGrid.Rows.Add("=== ميزان المراجعة  ===", "3", Nothing, Nothing, Nothing, Nothing, Nothing)
        Else
            ABA3 = "0"
            RB3 = False
        End If


        Dim ds3 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter3 As New SqlDataAdapter
        Dim str3 As New SqlCommand("SELECT * FROM Previouspost1  WHERE  CUser='" & ModuleGeneral.CUser & "' and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter3 = New SqlDataAdapter(str3)
=======
        Dim SqlDataAdapter3 As New SqlClient.SqlDataAdapter
        Dim str3 As New SqlClient.SqlCommand("SELECT * FROM Previouspost1  WHERE  CUser='" & ModuleGeneral.CUser & "' and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter3 = New SqlClient.SqlDataAdapter(str3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds3.Clear()
        SqlDataAdapter3.Fill(ds3, "Previouspost1")
        If ds3.Tables(0).Rows.Count > 0 Then
            AB4 = "4"
            RB4 = True
            DataGrid.Rows.Add("=== المركز المالي ===", "4", Nothing, Nothing, Nothing, Nothing, Nothing)
        Else
            AB4 = "0"
            RB4 = False
        End If



        Dim ds4 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter4 As New SqlDataAdapter
        Dim str4 As New SqlCommand("SELECT * FROM BALANCE1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter4 = New SqlDataAdapter(str4)
=======
        Dim SqlDataAdapter4 As New SqlClient.SqlDataAdapter
        Dim str4 As New SqlClient.SqlCommand("SELECT * FROM BALANCE1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter4 = New SqlClient.SqlDataAdapter(str4)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds4.Clear()
        SqlDataAdapter4.Fill(ds4, "BALANCE1")
        If ds4.Tables(0).Rows.Count > 0 Then
            AB5 = "5"
            DataGrid.Rows.Add("=== قائمة الداخل ===", "5", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB5 = True
        Else
            AB5 = "0"
            RB5 = False
        End If

        Dim ds5 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter5 As New SqlDataAdapter
        Dim str5 As New SqlCommand("SELECT * FROM ALLShares  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter5 = New SqlDataAdapter(str5)
=======
        Dim SqlDataAdapter5 As New SqlClient.SqlDataAdapter
        Dim str5 As New SqlClient.SqlCommand("SELECT * FROM ALLShares  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter5 = New SqlClient.SqlDataAdapter(str5)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds5.Clear()
        SqlDataAdapter5.Fill(ds5, "ALLShares")
        If ds5.Tables(0).Rows.Count > 0 Then
            AB6 = "6"
            DataGrid.Rows.Add("=== كشف الاعضاء ===", "6", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB6 = True
        Else
            AB6 = "0"
            RB6 = False
        End If

        Dim ds6 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter6 As New SqlDataAdapter
        Dim str6 As New SqlCommand("SELECT * FROM CustomersCABLES2  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter6 = New SqlDataAdapter(str6)
=======
        Dim SqlDataAdapter6 As New SqlClient.SqlDataAdapter
        Dim str6 As New SqlClient.SqlCommand("SELECT * FROM CustomersCABLES2  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter6 = New SqlClient.SqlDataAdapter(str6)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds6.Clear()
        SqlDataAdapter6.Fill(ds6, "CustomersCABLES2")
        If ds6.Tables(0).Rows.Count > 0 Then
            AB7 = "7"
            DataGrid.Rows.Add("=== كشف الذمم المدينة ===", "7", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB7 = True
        Else
            AB7 = "0"
            RB7 = False
        End If
        Dim ds7 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter7 As New SqlDataAdapter
        Dim str7 As New SqlCommand("SELECT * FROM Suppliers1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter7 = New SqlDataAdapter(str7)
=======
        Dim SqlDataAdapter7 As New SqlClient.SqlDataAdapter
        Dim str7 As New SqlClient.SqlCommand("SELECT * FROM Suppliers1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter7 = New SqlClient.SqlDataAdapter(str7)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds7.Clear()
        SqlDataAdapter7.Fill(ds7, "Suppliers1")
        If ds7.Tables(0).Rows.Count > 0 Then
            AB8 = "8"
            DataGrid.Rows.Add("=== كشف الذمم الدائنة ===", "8", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB8 = True
        Else
            AB8 = "0"
            RB8 = False
        End If

        Dim ds8 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter8 As New SqlDataAdapter
        Dim str8 As New SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & False & "' ", Consum)
        SqlDataAdapter8 = New SqlDataAdapter(str8)
=======
        Dim SqlDataAdapter8 As New SqlClient.SqlDataAdapter
        Dim str8 As New SqlClient.SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & False & "' ", Consum)
        SqlDataAdapter8 = New SqlClient.SqlDataAdapter(str8)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds8.Clear()
        SqlDataAdapter8.Fill(ds8, "Checks")
        If ds8.Tables(0).Rows.Count > 0 Then
            AB9 = "9"
            DataGrid.Rows.Add("=== كشف الشيكات الواردة ===", "9", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB9 = True
        Else
            AB9 = "0"
            RB9 = False
        End If

        Dim ds9 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter9 As New SqlDataAdapter
        Dim str9 As New SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & True & "'", Consum)
        SqlDataAdapter9 = New SqlDataAdapter(str9)
=======
        Dim SqlDataAdapter9 As New SqlClient.SqlDataAdapter
        Dim str9 As New SqlClient.SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & True & "'", Consum)
        SqlDataAdapter9 = New SqlClient.SqlDataAdapter(str9)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds9.Clear()
        SqlDataAdapter9.Fill(ds9, "Checks")
        If ds9.Tables(0).Rows.Count > 0 Then
            AB10 = "10"
            DataGrid.Rows.Add("=== كشف الشيكات الصادرة ===", "10", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB10 = True
        Else
            AB10 = "0"
            RB10 = False
        End If

        Dim ds11 As New DataSet
<<<<<<< HEAD
        Dim SqlDataAdapter11 As New SqlDataAdapter
        Dim str11 As New SqlCommand("SELECT * FROM InventoryBox  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter11 = New SqlDataAdapter(str11)
=======
        Dim SqlDataAdapter11 As New SqlClient.SqlDataAdapter
        Dim str11 As New SqlClient.SqlCommand("SELECT * FROM InventoryBox  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        SqlDataAdapter11 = New SqlClient.SqlDataAdapter(str11)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds11.Clear()
        SqlDataAdapter11.Fill(ds11, "InventoryBox")
        If ds11.Tables(0).Rows.Count > 0 Then
            AB11 = "11"
            DataGrid.Rows.Add("=== محضر جرد الصندوق ===", "11", Nothing, Nothing, Nothing, Nothing, Nothing)
            RB11 = True
        Else
            AB11 = "0"
            RB11 = False
        End If


        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
=======
    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.DataGridView1.Rows(Me.DataGridView1.Rows.Count).Selected = True
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
=======
    Private Sub DataGridView1_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

            Dim Asu As String
            Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
            Dim f As New FrmPRINT
            Asu = AssociationName
            Dim VX As String = Me.DataGridView1.Item("AB3", Me.DataGridView1.CurrentRow.Index).Value
            If e.ColumnIndex = 2 Then

                If VX = "1" Then
                    If RB1 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds1 As New DataSet
                        Dim SqlDataAdapter1 As New SqlDataAdapter
                        Dim str As New SqlCommand("", Consum)
                        If FIFO = True Then
                            str.CommandText = "SELECT * FROM FIFOStocks    WHERE  CUser='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds1 As New DataSet
                        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
                        Dim str As New SqlClient.SqlCommand("", Consum)
                        If FIFO = True Then
                            str.CommandText = "SELECT * FROM FIFOStocks    WHERE  CUser='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            ds1.Clear()
                            SqlDataAdapter1.Fill(ds1, "FIFOStocks")
                        ElseIf LIFO = True Then
                            str.CommandText = "SELECT * FROM LIFOStock1    WHERE CUser ='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
<<<<<<< HEAD
                            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            ds1.Clear()
                            SqlDataAdapter1.Fill(ds1, "LIFOStock1")
                        ElseIf AVG = True Then
                            str.CommandText = "SELECT * FROM AvgStocks     WHERE CUser ='" & CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
<<<<<<< HEAD
                            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
                            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            ds1.Clear()
                            SqlDataAdapter1.Fill(ds1, "AvgStocks")
                        End If

                        If FIFO = True Then
                            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer.Trim, "", "")
                            ds1.Clear()
                            SqlDataAdapter1.Fill(ds1, "FIFOStocks")
                            rpt1.SetDataSource(ds1)
                            txt = rpt1.Section1.ReportObjects("Text5")
                            txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                            txt = rpt1.Section1.ReportObjects("Text3")
                            txt.Text = Me.TextAssociationName.Text
                            txt = rpt1.Section1.ReportObjects("Text4")
                            txt.Text = Directorate
                            txt = rpt1.Section1.ReportObjects("Text32")
                            txt.Text = Me.TextFiscalYear.Text
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
                            txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                            txt = rpt11.Section1.ReportObjects("Text3")
                            txt.Text = Me.TextAssociationName.Text
                            txt = rpt11.Section1.ReportObjects("Text4")
                            txt.Text = Directorate
                            txt = rpt11.Section1.ReportObjects("Text32")
                            txt.Text = Me.TextFiscalYear.Text
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
                            txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                            txt = rpt12.Section1.ReportObjects("Text3")
                            txt.Text = Me.TextAssociationName.Text
                            txt = rpt12.Section1.ReportObjects("Text4")
                            txt.Text = Directorate
                            txt = rpt12.Section1.ReportObjects("Text32")
                            txt.Text = Me.TextFiscalYear.Text
                            f.CrystalReportViewer1.ReportSource = rpt12
                            f.CrystalReportViewer1.Zoom(65%)
                            f.CrystalReportViewer1.RefreshReport()
                            f.Show()
                        End If
                    Else
                        RB1 = False
                    End If
                End If



                If VX = "2" Then
                    If RB2 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Dim rpt As New CrystalFixedAssets
                        GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                        Dim ds As New DataSet
                        Dim str1 As New SqlCommand("SELECT * FROM FixedAssets   WHERE  CUser='" & ModuleGeneral.CUser & "'   ", Consum)
<<<<<<< HEAD
                        SqlDataAdapter1 = New SqlDataAdapter(str1)
=======
                        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds.Clear()
                        SqlDataAdapter1.Fill(ds, "FixedAssets")
                        rpt.SetDataSource(ds)
                        txt = rpt.Section1.ReportObjects("Text15")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt.Section1.ReportObjects("Text32")
                        txt.Text = Directorate
                        f.CrystalReportViewer1.ReportSource = rpt
                        f.CrystalReportViewer1.Zoom(90%)
                        f.CrystalReportViewer1.Refresh()
                        f.Show()
                    Else

                    End If
                End If
                If VX = "3" Then
                    If RB3 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim account_no1 As Integer = 23007 Or 23007001 Or 23007002
                        Dim ds2 As New DataSet
                        Dim SqlDataAdapter2 As New SqlDataAdapter
                        Dim str2 As New SqlCommand("SELECT * FROM FINALBALANCE  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and account_no  <>'" & account_no1 & "' ", Consum)
                        Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                        SqlDataAdapter2 = New SqlDataAdapter(str2)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim account_no1 As Integer = 23007 Or 23007001 Or 23007002
                        Dim ds2 As New DataSet
                        Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
                        Dim str2 As New SqlClient.SqlCommand("SELECT * FROM FINALBALANCE  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and account_no  <>'" & account_no1 & "' ", Consum)
                        Dim builder5 As New SqlCommandBuilder(SqlDataAdapter1)
                        SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds2.Clear()
                        SqlDataAdapter2.Fill(ds2, "FINALBALANCE")
                        GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                        rpt2.SetDataSource(ds2)
                        txt = rpt2.Section1.ReportObjects("Text3")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt2.Section1.ReportObjects("Text4")
                        txt.Text = Directorate
                        txt = rpt2.Section1.ReportObjects("Text20")
                        txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Me.TextAssociationNationalNumber.Text
                        f.CrystalReportViewer1.ReportSource = rpt2
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()
                    Else

                    End If
                End If
                If VX = "4" Then
                    If RB4 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds3 As New DataSet
                        Dim SqlDataAdapter3 As New SqlDataAdapter
                        'Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, ISNULL(CUser,CUser) AS CUser, ISNULL(CUser1,CUser) AS CUser1 FROM Previouspost1   WHERE  CUser='" & Module1.CUser & "'and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' or  CUser  IS NULL and CUser1 ='" & CUser & "'  ", Consum)
                        GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                        Dim str3 As New SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, YEAR1, CUser, CUser1  FROM Previouspost1  WHERE  CUser='" & CUser & "' or CUser1 ='" & CUser & "'   or  CUser  IS NULL   and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)

                        SqlDataAdapter3 = New SqlDataAdapter(str3)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds3 As New DataSet
                        Dim SqlDataAdapter3 As New SqlClient.SqlDataAdapter
                        'Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, ISNULL(CUser,CUser) AS CUser, ISNULL(CUser1,CUser) AS CUser1 FROM Previouspost1   WHERE  CUser='" & Module1.CUser & "'and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' or  CUser  IS NULL and CUser1 ='" & CUser & "'  ", Consum)
                        GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                        Dim str3 As New SqlClient.SqlCommand("SELECT MOVD4, account_no, MOVD3, account_name, SUMDEBIT1, SUMCREDIT1, SUMDEBIT, SUMCREDIT, AccountKind, ACC, yearearlier, YEAR, YEAR1, CUser, CUser1  FROM Previouspost1  WHERE  CUser='" & CUser & "' or CUser1 ='" & CUser & "'   or  CUser  IS NULL   and YEAR ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)

                        SqlDataAdapter3 = New SqlClient.SqlDataAdapter(str3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds3.Clear()
                        SqlDataAdapter3.Fill(ds3, "Previouspost1")

                        rpt3.SetDataSource(ds3)
                        txt = rpt3.Section1.ReportObjects("Text6")
                        txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                        txt = rpt3.Section1.ReportObjects("Text40")
                        txt.Text = "عن السنة المالية المنتهية فى" & " " & "31" & "-" & "12" & "-" & FiscalYear_currentDateMustBeInFiscalYear()

                        txt = rpt3.Section1.ReportObjects("Text1")
                        txt.Text = "المركز المالي _ ل" & Me.TextAssociationName.Text
                        txt = rpt3.Section1.ReportObjects("Text5")
                        txt.Text = "المحافظة" & ":" & Directorate
                        txt = rpt3.Section1.ReportObjects("Text7")
                        txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Me.TextAssociationNationalNumber.Text
                        txt = rpt3.Section1.ReportObjects("Text9")
                        txt.Text = CUser
                        rpt3.DataDefinition.FormulaFields("CUser_C").Text = CUser
                        rpt3.DataDefinition.FormulaFields("y").Text = FiscalYear_currentDateMustBeInFiscalYear()


                        f.CrystalReportViewer1.ReportSource = rpt3
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()
                    Else

                    End If
                End If
                If VX = "5" Then
                    If RB5 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds4 As New DataSet
                        Dim SqlDataAdapter4 As New SqlDataAdapter
                        Dim str4 As New SqlCommand("SELECT * FROM BALANCE1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                        SqlDataAdapter4 = New SqlDataAdapter(str4)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds4 As New DataSet
                        Dim SqlDataAdapter4 As New SqlClient.SqlDataAdapter
                        Dim str4 As New SqlClient.SqlCommand("SELECT * FROM BALANCE1  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                        SqlDataAdapter4 = New SqlClient.SqlDataAdapter(str4)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds4.Clear()
                        SqlDataAdapter4.Fill(ds4, "BALANCE1")

                        rpt6.SetDataSource(ds4)
                        txt = rpt6.Section1.ReportObjects("Text6")
                        txt.Text = "السنة المالية" & "_" & FiscalYear_currentDateMustBeInFiscalYear()
                        txt = rpt6.Section1.ReportObjects("Text1")
                        txt.Text = "قائمة الدخل _ ل" & Me.TextAssociationName.Text
                        txt = rpt6.Section1.ReportObjects("Text2")
                        txt.Text = "المحافظة" & ":" & Directorate
                        txt = rpt6.Section1.ReportObjects("Text5")
                        txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Me.TextAssociationNationalNumber.Text
                        f.CrystalReportViewer1.ReportSource = rpt6
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()
                    Else

                    End If
                End If

                If VX = "6" Then
                    If RB6 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds5 As New DataSet
                        Dim SqlDataAdapter5 As New SqlDataAdapter
                        Dim str5 As New SqlCommand("SELECT * FROM ALLShares  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                        SqlDataAdapter5 = New SqlDataAdapter(str5)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds5 As New DataSet
                        Dim SqlDataAdapter5 As New SqlClient.SqlDataAdapter
                        Dim str5 As New SqlClient.SqlCommand("SELECT * FROM ALLShares  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                        SqlDataAdapter5 = New SqlClient.SqlDataAdapter(str5)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds5.Clear()
                        SqlDataAdapter5.Fill(ds5, "ALLShares")
                        rpt7.SetDataSource(ds5)
                        txt = rpt7.Section1.ReportObjects("Text12")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt7.Section1.ReportObjects("Text13")
                        txt.Text = Directorate
                        txt = rpt7.Section1.ReportObjects("Text19")
                        txt.Text = BANSL
                        txt = rpt7.Section1.ReportObjects("Text5")
                        txt.Text = "الرقم الوطني للجمعية" & " " & ":" & " " & Recorded
                        f.CrystalReportViewer1.ReportSource = rpt7
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()

                    Else

                    End If
                End If

                If VX = "7" Then
                    If RB7 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds6 As New DataSet
                        Dim SqlDataAdapter6 As New SqlDataAdapter
                        Dim str6 As New SqlCommand("SELECT * FROM CustomersCABLES2 WHERE lo19 ='" & False & "' AND Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND CUser ='" & CUser & "'", Consum)
                        SqlDataAdapter6 = New SqlDataAdapter(str6)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds6 As New DataSet
                        Dim SqlDataAdapter6 As New SqlClient.SqlDataAdapter
                        Dim str6 As New SqlClient.SqlCommand("SELECT * FROM CustomersCABLES2 WHERE lo19 ='" & False & "' AND Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND CUser ='" & CUser & "'", Consum)
                        SqlDataAdapter6 = New SqlClient.SqlDataAdapter(str6)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds6.Clear()
                        SqlDataAdapter6.Fill(ds6, "CustomersCABLES2")
                        rpt8.SetDataSource(ds6)
                        txt = rpt8.Section1.ReportObjects("Text4")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt8.Section1.ReportObjects("Text8")
                        txt.Text = Directorate
                        f.CrystalReportViewer1.ReportSource = rpt8
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()

                    Else

                    End If
                End If

                If VX = "8" Then
                    If RB8 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds7 As New DataSet
                        Dim SqlDataAdapter7 As New SqlDataAdapter
                        Dim str7 As New SqlCommand("SELECT * FROM Suppliers1  WHERE CAB19 ='" & True & "' AND Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND CUser ='" & CUser & "'", Consum)
                        SqlDataAdapter7 = New SqlDataAdapter(str7)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds7 As New DataSet
                        Dim SqlDataAdapter7 As New SqlClient.SqlDataAdapter
                        Dim str7 As New SqlClient.SqlCommand("SELECT * FROM Suppliers1  WHERE CAB19 ='" & True & "' AND Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' AND CUser ='" & CUser & "'", Consum)
                        SqlDataAdapter7 = New SqlClient.SqlDataAdapter(str7)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds7.Clear()
                        SqlDataAdapter7.Fill(ds7, "Suppliers1")
                        rpt8.SetDataSource(ds7)
                        txt = rpt18.Section1.ReportObjects("Text4")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt18.Section1.ReportObjects("Text8")
                        txt.Text = Directorate
                        f.CrystalReportViewer1.ReportSource = rpt18
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()
                    Else

                    End If
                End If

                If VX = "9" Then
                    If RB9 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds8 As New DataSet
                        Dim SqlDataAdapter8 As New SqlDataAdapter
                        Dim str8 As New SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & False & "' ", Consum)
                        SqlDataAdapter8 = New SqlDataAdapter(str8)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds8 As New DataSet
                        Dim SqlDataAdapter8 As New SqlClient.SqlDataAdapter
                        Dim str8 As New SqlClient.SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & False & "' ", Consum)
                        SqlDataAdapter8 = New SqlClient.SqlDataAdapter(str8)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds8.Clear()
                        SqlDataAdapter8.Fill(ds8, "Checks")
                        rpt9.SetDataSource(ds8)
                        txt = rpt9.Section1.ReportObjects("Text12")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt9.Section1.ReportObjects("Text13")
                        txt.Text = Directorate
                        f.CrystalReportViewer1.ReportSource = rpt9
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()
                    Else

                    End If
                End If

                If VX = "10" Then
                    If RB10 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds9 As New DataSet
                        Dim SqlDataAdapter9 As New SqlDataAdapter
                        Dim str9 As New SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & True & "'", Consum)
                        SqlDataAdapter9 = New SqlDataAdapter(str9)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds9 As New DataSet
                        Dim SqlDataAdapter9 As New SqlClient.SqlDataAdapter
                        Dim str9 As New SqlClient.SqlCommand("SELECT * FROM Checks  WHERE  CUser='" & ModuleGeneral.CUser & "' and CH15 ='" & True & "'", Consum)
                        SqlDataAdapter9 = New SqlClient.SqlDataAdapter(str9)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds9.Clear()
                        SqlDataAdapter9.Fill(ds9, "Checks")

                        rpt10.SetDataSource(ds9)
                        txt = rpt10.Section1.ReportObjects("Text12")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt10.Section1.ReportObjects("Text13")
                        txt.Text = Directorate
                        f.CrystalReportViewer1.ReportSource = rpt10
                        f.CrystalReportViewer1.Zoom(65%)
                        f.CrystalReportViewer1.RefreshReport()
                        f.Show()
                    Else

                    End If
                End If
                If VX = "11" Then
                    If RB11 = True Then
<<<<<<< HEAD
                        Dim Consum As New SqlConnection(constring)
                        Dim ds11 As New DataSet
                        Dim SqlDataAdapter11 As New SqlDataAdapter
                        Dim str11 As New SqlCommand("SELECT * FROM InventoryBox  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                        SqlDataAdapter11 = New SqlDataAdapter(str11)
=======
                        Dim Consum As New SqlClient.SqlConnection(constring)
                        Dim ds11 As New DataSet
                        Dim SqlDataAdapter11 As New SqlClient.SqlDataAdapter
                        Dim str11 As New SqlClient.SqlCommand("SELECT * FROM InventoryBox  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(LOBOX) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
                        SqlDataAdapter11 = New SqlClient.SqlDataAdapter(str11)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        ds11.Clear()
                        SqlDataAdapter11.Fill(ds11, "InventoryBox")
                        Dim rpt As New CrystalInventoryBox
                        GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
                        rpt.SetDataSource(ds11)
                        txt = rpt.Section1.ReportObjects("Text15")
                        txt.Text = Me.TextAssociationName.Text
                        txt = rpt.Section1.ReportObjects("Text8")
                        txt.Text = Directorate
                        txt = rpt.Section1.ReportObjects("Text13")
                        txt.Text = Character
                        txt = rpt.Section1.ReportObjects("Text40")
                        txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                        txt = rpt.Section1.ReportObjects("Text44")
                        txt.Text = Recorded
                        f.CrystalReportViewer1.ReportSource = rpt
                        f.CrystalReportViewer1.Zoom(90%)
                        f.CrystalReportViewer1.Refresh()
                        f.Show()
                    Else

                    End If

                End If
            End If








        Catch ex As Exception
            MessageBox.Show(ex.Message, "Errore.ColumnIndex", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub
    Sub SearchDataView()
        Try
            Dim dv As DataView = dt.DefaultView
            dv.RowFilter = "FL1 like  '%" & Me.ComboAssociationName.Text & "%'"
            For Each r As DataGridViewRow In Me.DataGridViewX1.Rows
                Me.IDFL1.Text = r.Cells(0).Value
                Me.TextAssociationName.Text = r.Cells(1).Value
                Me.TextAssociationNationalNumber.Text = r.Cells(2).Value
                Me.TextFiscalYear.Text = r.Cells(3).Value
                Me.TextCondition.Text = r.Cells(11).Value
                Me.TextReasonsForRejectingBudgetFromAuditor.Text = r.Cells(12).Value
                Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Text = r.Cells(13).Value
                Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Text = r.Cells(14).Value
                Me.TextReasonsForRejectingBudgetFromExternalAuditor.Text = r.Cells(15).Value
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSearchDataView", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonEnquiry_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonEnquiry.Click
=======
    Private Sub ButtonEnquiry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonEnquiry.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            SearchDataView()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorButtonX2_Click", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub

    Private Sub BackgroundWorker2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Me.CircularProgress2.Visible = True
        Me.CircularProgress2.IsRunning = True
<<<<<<< HEAD
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT  CUser, COUser     FROM COMPANY WHERE CMP2 ='" & Me.ComboAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT  CUser, COUser     FROM COMPANY WHERE CMP2 ='" & Me.ComboAssociationName.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            CUser = ds.Tables(0).Rows(0).Item(0)
            COUser = ds.Tables(0).Rows(0).Item(1)
        Else
            CUser = ModuleGeneral.CUser
            COUser = ModuleGeneral.COUser
            Me.CircularProgress2.IsRunning = False
            Me.CircularProgress2.Visible = False
            'Exit Sub
        End If
        Adp.Dispose()
        Consum.Close()
        Me.DataGridView1.Rows.Clear()
        Call LoadFormInternalAuditor()
        Call SELECT_MOVES4(Me.DataGridView1)
        Call CountDATAITEMS1()

        Call AuditorClose()
        Call CollaborationManagerClose()
        Call HeadOFExternalAccountsDepartmentClose()
        Call ExternalAuditorClose()
    End Sub

    Private Sub BackgroundWorker2_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker2.ProgressChanged
        Me.CircularProgress2.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        Me.CircularProgress2.IsRunning = False
        Me.CircularProgress2.Visible = False
    End Sub
<<<<<<< HEAD
    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboAssociationName.SelectedIndexChanged
=======
    Private Sub ComboBoxEx2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboAssociationName.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.CircularProgress2.Value = 0
        Me.BackgroundWorker2.WorkerSupportsCancellation = True
        Me.BackgroundWorker2.WorkerReportsProgress = True
        Me.BackgroundWorker2.RunWorkerAsync()
    End Sub



<<<<<<< HEAD
    Private Sub ButtonViewDocuments_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub ButtonViewDocuments_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
        Try
            Dim ds41 As New DataSet
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FormDOCUMENTS
            ds41.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand("SELECT DOC1, LO FROM DOCUMENTS  WHERE   LO ='" & "BU" & Me.TextAssociationNationalNumber.Text & "'ORDER BY DOC1", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds41.Clear()
            SqlDataAdapter1.Fill(ds41, "DOCUMENTS")
            If ds41.Tables(0).Rows.Count > 0 Then
                Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
                f.XU = "BU" & Year & Me.TextAssociationNationalNumber.Text
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds41.Clear()
            SqlDataAdapter1.Fill(ds41, "DOCUMENTS")
            If ds41.Tables(0).Rows.Count > 0 Then
                f.XU = "BU" & Me.TextAssociationNationalNumber.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                f.BUD = True
                f.Show()
                f.Ts_TextChanged()
            Else
                MsgBox("لا يوجد اي مستندات", 64 + 524288, "تنبيه")
            End If
            SqlDataAdapter1.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

<<<<<<< HEAD
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
=======
    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If

            If ExternalAuditor = False Then
                MsgBox("ععفوا .. قام الأدمن بمنع خاصية إرفاق المستندات", 16, "تنبيه")
                Exit Sub
            End If
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim NumberDOCUMENTS As Object = "BU" & Year & Me.TextAssociationNationalNumber.Text
            GetAutoNumberDOCUMENTSFL(NumberDOCUMENTS)
            Me.IDFL = SEARCHDATA.NumberDOCUMENTSFL
            Dim f As New FormDOCUMENTS
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButLogq.Enabled = True
            f.BUD = True
            f.Show()
            f.ADDBUTTON_Click(sender, e)

            CLEARDATA1(Me)
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextFileNo.Text = IDFL
            f.TextTransactionNumber.Text = NumberDOCUMENTS
            f.TEXTFileSubject.Text = "الموازنه"
            f.TextFileDescription.Text = "ارفاق مستندات مدقق الحسابات الخارجي"
            f.PictureBox1.Image = Nothing
            f.TextFileNo.Enabled = False
            f.TextTransactionNumber.Enabled = False
            Insert_Actions(IDFL1.Text, " ارفاق مستندات مدقق الحسابات الخارجي", Me.Text)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonApproval_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonApproval.Click
=======
    Private Sub ButtonApproval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonApproval.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Try

            If Me.IDFL1.Text = Nothing Then
                MsgBox("الرجاء تحديد الجمعية والنقر على امر استعلام ... ", 16, "تنبيه")
                Exit Sub
            Else
<<<<<<< HEAD
                Dim Consum As New SqlConnection(constring)
                'MAXIDBudget()
                Dim SQL As New SqlCommand(" Update FinancialList SET    FL9 = @FL9, FL10 = @FL10, FL11 = @FL11, FL15 = @FL15, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
                Dim CMD As New SqlCommand With {
=======
                Dim Consum As New SqlClient.SqlConnection(constring)
                'MAXIDBudget()
                Dim SQL As New SqlCommand(" Update FinancialList SET    FL9 = @FL9, FL10 = @FL10, FL11 = @FL11, FL15 = @FL15, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
                Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                With CMD


                    .CommandType = CommandType.Text
                    .Connection = Consum
                    .Parameters.Add("@IDFL", SqlDbType.Int).Value = Me.IDFL1.Text
                    .Parameters.Add("@FL9", SqlDbType.Bit).Value = True
                    .Parameters.Add("@FL10", SqlDbType.NVarChar).Value = "5"
                    .Parameters.Add("@FL11", SqlDbType.NVarChar).Value = "تم الانتهاء من العمل وتم الاعتماد  "
                    .Parameters.Add("@FL15", SqlDbType.NVarChar).Value = "0"
                    .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                    .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                    .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                    .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                    If InternalAuditor = True Then
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                    Else
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                    End If
                    .CommandText = SQL.CommandText
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()
                FormExternalAuditor_Load(sender, e)
                MsgBox("تمت  أعتماد الموازنة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
                Insert_Actions(Me.IDFL1.Text, " أعتماد الموازنة", Me.Text)
                FrmMAIN.ComboGovernorateName_SelectedIndexChanged(sender, e)
                FrmMAIN.ComboGetAssociationName_SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub


<<<<<<< HEAD
    Private Sub ButtonRefusal_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonRefusal.Click
=======
    Private Sub ButtonRefusal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRefusal.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.IDFL1.Text = Nothing Then
                MsgBox("الرجاء تحديد الجمعية والنقر على امر استعلام ... ", 16, "تنبيه")
                Exit Sub
            Else
<<<<<<< HEAD
                Dim Consum As New SqlConnection(constring)
                'MAXIDBudget()
                Dim SQL As New SqlCommand(" Update FinancialList SET    FL9 = @FL9, FL10 = @FL10, FL11 = @FL11, FL15 = @FL15, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
                Dim CMD As New SqlCommand With {
=======
                Dim Consum As New SqlClient.SqlConnection(constring)
                'MAXIDBudget()
                Dim SQL As New SqlCommand(" Update FinancialList SET    FL9 = @FL9, FL10 = @FL10, FL11 = @FL11, FL15 = @FL15, USERNAME = @USERNAME, Auditor = @Auditor, CUser = @CUser, COUser = @COUser, da = @da, ne = @ne WHERE IDFL = @IDFL", Consum)
                Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                With CMD
                    .CommandType = CommandType.Text
                    .Connection = Consum
                    .Parameters.Add("@IDFL", SqlDbType.Int).Value = Me.IDFL1.Text
                    .Parameters.Add("@FL9", SqlDbType.Bit).Value = False
                    .Parameters.Add("@FL10", SqlDbType.NVarChar).Value = "4"
                    .Parameters.Add("@FL11", SqlDbType.NVarChar).Value = "تم رفض الموازنه وجاري ارجاعة الي رئيس قسم الحسابات الخارجية"
                    .Parameters.Add("@FL15", SqlDbType.NVarChar).Value = Me.TextReasonsForRejectingBudgetFromExternalAuditor.Text
                    .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                    .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                    .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                    .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                    If InternalAuditor = True Then
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = Logentry
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = USERNAME
                    Else
                        .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                        .Parameters.Add("@Auditor", SqlDbType.NVarChar).Value = DBNull.Value
                    End If
                    .CommandText = SQL.CommandText
                End With
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.ExecuteNonQuery()
                Consum.Close()
                FormExternalAuditor_Load(sender, e)
                MsgBox("تمت رفض الموازنة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
                Insert_Actions(Me.IDFL1.Text, " رفض الموازنة", Me.Text)
                FrmMAIN.ComboGovernorateName_SelectedIndexChanged(sender, e)
                FrmMAIN.ComboGetAssociationName_SelectedIndexChanged(sender, e)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub


End Class