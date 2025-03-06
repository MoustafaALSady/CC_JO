Option Explicit Off

Imports System.Data.Common
Imports System.Data.SqlClient
Public Class Loans
<<<<<<< HEAD
    Inherits Form
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As New SqlDataAdapter
    Public SqlDataAdapter2 As New SqlDataAdapter
    Public SqlDataAdapter3 As New SqlDataAdapter
    Public SqlDataAdapter4 As New SqlDataAdapter
=======
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Public SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    Public SqlDataAdapter3 As New SqlClient.SqlDataAdapter
    Public SqlDataAdapter4 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public ds1 As New DataSet
    Public dt As New DataSet
    Public da As SqlDataAdapter
    Public WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Public WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub PictureBox2Callback()
    ReadOnly Cancel As Boolean = False
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Private account_nameF As String
    Dim nemcust2, nemcust7 As String
    ReadOnly pp As Integer = 0
    Dim ppp As String
    Dim Remainder As Double
    Public TB1 As String
    Public TB2 As String
    Public TB3 As String
    Dim b As Boolean = False
<<<<<<< HEAD
    Dim TransferAccounts As Boolean = True
    Dim RecordingAmountOfDebtAndPurchases As Boolean = True

    Private Sub Loans_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======

    Private Sub Loans_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.BUTTONCANCEL_Click(sender, e)
                    Case Keys.F5
                        Me.PRINTBUTTON_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonXP3_Click(sender, e)
                    Case Keys.F9
                        Me.ButtonDivision_Click(sender, e)
                    Case Keys.F10
<<<<<<< HEAD
                        Me.ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonTransferofAccounts1_Click(sender, e)
=======
                        Me.ButtonCUSTOMER1_Click(sender, e)
                    Case Keys.F11
                        Me.ButtonXP2_Click(sender, e)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Case Keys.F12
                        Me.CMDBROWSE_Click(sender, e)
                    Case Keys.PageDown
                        Me.BtnNavPrev_Click(sender, e)
                    Case Keys.PageUp
                        Me.BtnNavNext_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
            End If
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub Loans_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
=======
    Private Sub FrmDeposits_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        'Me.TabPage1.Show()
        'Me.TabPage2.Show()
        'Me.TabPage3.Show()
        'Me.TabPage5.Show()
        'Me.TabPage4.Show()
    End Sub
    Private Sub Loans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.PRINTBUTTON.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.ButtonDivision.Enabled = False
        Me.ButtonAddSponsor.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonTransferofAccounts1.Enabled = False
        Me.ButtonAttachDocument.Enabled = False
        Me.ButtonViewDocuments.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.btnNavFirst.Enabled = False
        Me.btnNavPrev.Enabled = False
        Me.btnNavNext.Enabled = False
        Me.btnLast.Enabled = False


        TestkeyAccounts(keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No)
        End If
    End Sub
<<<<<<< HEAD

    Private Sub FundBalance()
        Try
            Dim N As Int64 = 0
            Using Consum As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
                Consum.Open()
                Dim result As Object = cmd1.ExecuteScalar()
                If result IsNot Nothing AndAlso IsNumeric(result) Then
                    N = Convert.ToInt64(result)
                End If
            End Using
            Me.TextFundBalance.Text = SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N).ToString("0.000")
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error in FundBalance", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SEARCHDATAPP1()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet

        Try
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Consum.Open()
            Dim strsql As New SqlCommand("SELECT Loa6 FROM LoansPa WHERE CUser=@CUser AND Lo=@Lo AND Loa=@Loa", Consum)
            strsql.Parameters.AddWithValue("@CUser", CUser)
            strsql.Parameters.AddWithValue("@Lo", Trim(Me.TextContractNumber.EditValue))
            strsql.Parameters.AddWithValue("@Loa", 0)
            Adp = New SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)

            If ds.Tables(0).Rows.Count > 0 Then
                Me.TextPreviousPayments.Text = ds.Tables(0).Rows(0).Item(0)
            Else
                Me.TextPreviousPayments.Text = 0
            End If

        Catch ex As Exception
            ' Handle the error (log it, show a message, etc.)
            Me.TextPreviousPayments.Text = "Error"
        Finally
            Consum.Close()
        End Try
    End Sub

    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles load1.Click
        Try
            If String.IsNullOrEmpty(constring) Then
                Throw New ArgumentException("Connection string cannot be null or empty.")
            End If

            Me.ds1.EnforceConstraints = False

            Using Consum As New SqlConnection(constring)
                Dim str1 As New SqlCommand("SELECT lo1, lo, lo2, lo3, lo4, lo5, lo6, lo7, lo8, lo9, lo10, lo11, lo12, lo13, lo14, lo15, lo16, lo17, lo18, lo19, lo20, lo21, lo22, lo23, lo24, lo25, lo26, lo27, lo28, lo29, lo30, CB1, BN2, AsUser, Directorate, Recorded, USERNAME, Auditor, cuser, coUser, da, ne, da1, ne1 FROM Loans WHERE CUser = @CUser AND (LO = @LO OR LO4 = @LO4 OR LO5 = @LO5)", Consum)
                str1.Parameters.AddWithValue("@CUser", If(CUser IsNot Nothing, CUser, String.Empty))
                str1.Parameters.AddWithValue("@LO", If(Me.TB1 IsNot Nothing, Trim(Me.TB1), String.Empty))
                str1.Parameters.AddWithValue("@LO4", If(Me.TB2 IsNot Nothing, Trim(Me.TB2), String.Empty))
                str1.Parameters.AddWithValue("@LO5", If(Me.TB3 IsNot Nothing, Trim(Me.TB3), String.Empty))

                Dim str2 As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, CB1, USERNAME, CUser, COUser, da, ne FROM LoansPa WHERE LO = @LO", Consum)
                str2.Parameters.AddWithValue("@LO", If(Me.TB1 IsNot Nothing, Trim(Me.TB1), String.Empty))

                Dim str3 As New SqlCommand("SELECT lok1, lokA, lok2, lok3, lok4, lo22, TBNK7, lok FROM LoansK WHERE lok = @lok", Consum)
                str3.Parameters.AddWithValue("@lok", If(Me.TB1 IsNot Nothing, Trim(Me.TB1), String.Empty))

                Dim str4 As New SqlCommand("SELECT DOC1, LO, DOC2, DOC4, DOC5 FROM MYDOCUMENTSHOME WHERE LO = @LO", Consum)
                str4.Parameters.AddWithValue("@LO", If(Me.TB1 IsNot Nothing, Trim(Me.TB1), String.Empty))

                Me.ds1.EnforceConstraints = False
                Consum.Open()
                Me.SqlDataAdapter1 = New SqlDataAdapter(str1)
                Me.SqlDataAdapter2 = New SqlDataAdapter(str2)
                Me.SqlDataAdapter3 = New SqlDataAdapter(str3)
                Me.SqlDataAdapter4 = New SqlDataAdapter(str4)
                Me.ds1.Clear()
                Me.SqlDataAdapter1.Fill(Me.ds1, "Loans")
                Me.SqlDataAdapter2.Fill(Me.ds1, "LoansPa")
                Me.SqlDataAdapter3.Fill(Me.ds1, "LoansK")
                Me.SqlDataAdapter4.Fill(Me.ds1, "MYDOCUMENTSHOME")

                If Not ds1.Relations.Contains("REL1") Then
                    Me.ds1.Relations.Add("REL1", Me.ds1.Tables("Loans").Columns("LO"), Me.ds1.Tables("LoansPa").Columns("LO"), True)
                End If
                If Not ds1.Relations.Contains("REL2") Then
                    Me.ds1.Relations.Add("REL2", Me.ds1.Tables("Loans").Columns("LO"), Me.ds1.Tables("LoansK").Columns("LOK"), True)
                End If
                If Not ds1.Relations.Contains("REL3") Then
                    Me.ds1.Relations.Add("REL3", Me.ds1.Tables("Loans").Columns("LO17"), Me.ds1.Tables("MYDOCUMENTSHOME").Columns("LO"), True)
                End If
                ' Verify critical controls
                If Me.DataGridView1 Is Nothing Then Throw New Exception("DataGridView1 is not initialized")
                If Me.DataGridView3 Is Nothing Then Throw New Exception("DataGridView3 is not initialized")
                If Me.DataGridView4 Is Nothing Then Throw New Exception("DataGridView4 is not initialized")
                If Me.BS Is Nothing Then Throw New Exception("BindingSource BS is not initialized")

                Me.ds1.EnforceConstraints = False
                Me.DataGridView1.AutoGenerateColumns = False
                Me.DataGridView3.AutoGenerateColumns = False
                Me.DataGridView4.AutoGenerateColumns = False

                Dim star As New SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, CB1, USERNAME, CUser, COUser, da, ne FROM LoansPa WHERE LO = @LO", Consum)
                star.Parameters.AddWithValue("@LO", If(Me.TB1 IsNot Nothing, Trim(Me.TB1), String.Empty))
                Me.da = New SqlDataAdapter(star)
                Me.dt = New DataSet
                Me.da.Fill(Me.dt, "LoansPa")
            End Using

            Me.Invoke(Sub()
                          Me.BS.DataSource = Me.ds1
                          Me.BS.DataMember = "Loans"
                          ds1.EnforceConstraints = True
                          With DataGridView1
                              .DataSource = BS
                              .DataMember = "REL1"
                          End With
                          With DataGridView4
                              .DataSource = Me.BS
                              .DataMember = "REL2"
                          End With
                          With DataGridView3
                              .DataSource = Me.BS
                              .DataMember = "REL3"
                          End With
                      End Sub)

            Me.ds1.EnforceConstraints = True
            Me.SqlDataAdapter1.Dispose()
            Me.SqlDataAdapter2.Dispose()
            Me.SqlDataAdapter3.Dispose()
            Me.SqlDataAdapter4.Dispose()

            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboSponsorName)

            Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
            Me.ComboDebitAccount.DisplayMember = "account_name"
            Me.List1.DataSource = GetData(NUpDebitAccount.Value)
            Me.List1.DisplayMember = "account_name"
            Me.List2.DataSource = GetData(NUpCreditAccount.Value)
            Me.List2.DisplayMember = "account_name"

            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If ComboCB1.Items.Count > 0 Then Me.ComboCB1.SelectedIndex = 0
            If ComboBN2.Items.Count > 0 Then Me.ComboBN2.SelectedIndex = 0

            Me.RecordCount()
            Me.SumAmounBALANCE()
            Me.FundBalance()
            'Me.DataGridView1_CellValidating(sender, e)

            With Me.DataGridView1
                .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                .RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
                .RowsDefaultCellStyle.BackColor = Color.Bisque
                .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
            End With

            Me.load1.Enabled = False
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
            'MessageBox.Show("An error occurred: " & ex.Message & vbCrLf & "Stack Trace: " & ex.StackTrace)
        End Try
    End Sub

    Private Sub DISPLAYRECORD()
        Try
            ' Extract the current row once to avoid repeated access
            Dim currentRow As DataRow = Me.ds1.Tables("Loans").Rows(Me.BS.Position)

            ' Populate UI controls with data
            With Me
                .TextDebtNumber.Text = currentRow("Lo1").ToString()
                .TextContractNumber.EditValue = currentRow("Lo").ToString()
                .DateMovementHistory.Text = If(IsDBNull(currentRow("Lo2")), "", CDate(currentRow("Lo2")).ToString("dd/MM/yyyy"))
                .TEXTStatement.Text = currentRow("Lo3").ToString()
                .TextCustomerNumber.EditValue = currentRow("Lo4").ToString()
                .ComboCustomerName.Text = currentRow("Lo5").ToString()
                .TextNationalNo.Text = currentRow("Lo6").ToString()
                .TextAddress.Text = currentRow("Lo7").ToString()
                .TextMiligDebt.EditValue = If(IsDBNull(currentRow("Lo8")), 0, currentRow("Lo8")) ' Numeric value
                .TextProfitRatio.EditValue = If(IsDBNull(currentRow("Lo9")), 0, currentRow("Lo9")) ' Numeric value
                .ComboNumberOfYears.Text = currentRow("Lo10").ToString()
                .TextFirstBatch.EditValue = If(IsDBNull(currentRow("Lo11")), 0, currentRow("Lo11")) ' Numeric value
                .TextTotalDebt.Text = If(IsDBNull(currentRow("Lo12")), 0, currentRow("Lo12")).ToString()
                .TextMonthlyInstallment.Text = If(IsDBNull(currentRow("Lo13")), 0, currentRow("Lo13")).ToString()
                .TextNetDebt.Text = If(IsDBNull(currentRow("Lo14")), 0, currentRow("Lo14")).ToString()
                .TextTotalDebtA.Text = If(IsDBNull(currentRow("Lo15")), 0, currentRow("Lo15")).ToString()
                .CheckTransferAccounts.Checked = If(IsDBNull(currentRow("Lo16")), False, CBool(currentRow("Lo16")))
                .TextMovementSymbol.EditValue = currentRow("Lo17").ToString()
                .CheckLogReview.Checked = If(IsDBNull(currentRow("Lo18")), False, CBool(currentRow("Lo18")))
                .CheckMember.Checked = If(IsDBNull(currentRow("Lo19")), False, CBool(currentRow("Lo19")))
                .ComboPaymentMethod.Text = currentRow("Lo20").ToString()
                .TextFundValue.EditValue = If(IsDBNull(currentRow("Lo21")), 0, currentRow("Lo21")) ' Numeric value
                .TextValueOfCheck.EditValue = If(IsDBNull(currentRow("Lo22")), 0, currentRow("Lo22")) ' Numeric value
                .ComboCheckDrawerName.Text = currentRow("Lo23").ToString()
                .TextCheckDrawerCode.Text = currentRow("Lo24").ToString()
                .TextCheckNumber.Text = currentRow("Lo25").ToString()
                .CheckDate.Text = If(IsDBNull(currentRow("Lo26")), "", CDate(currentRow("Lo26")).ToString("dd/MM/yyyy"))
                .CheckRecordingAmountOfDebtAndPurchases.Checked = If(IsDBNull(currentRow("Lo27")), False, CBool(currentRow("Lo27")))
                .TextAccountsPayableValue.EditValue = If(IsDBNull(currentRow("Lo28")), 0, currentRow("Lo28")) ' Numeric value
                .CheckCollected.Checked = If(IsDBNull(currentRow("Lo29")), False, CBool(currentRow("Lo29")))
                .ComboLoanType.Text = currentRow("Lo30").ToString()

                .ComboCB1.Text = currentRow("CB1").ToString()
                .ComboBN2.Text = currentRow("BN2").ToString()

                .TextAssociationName.Text = currentRow("ASUser").ToString()
                .TextDirectorateName.Text = currentRow("Directorate").ToString()
                .TextRegisteredUnderNo.Text = currentRow("Recorded").ToString()
                .TEXTUserName.Text = currentRow("USERNAME").ToString()
                .TEXTReferenceName.Text = currentRow("Auditor").ToString()
                .TextDefinitionDirectorate.Text = currentRow("COUser").ToString()
                .TEXTAddDate.Text = If(IsDBNull(currentRow("da")), "", CDate(currentRow("da")).ToString("dd/MM/yyyy"))
                .TextTimeAdd.Text = If(IsDBNull(currentRow("ne")), "", CDate(currentRow("ne")))
                .TEXTReviewDate.Text = If(IsDBNull(currentRow("da1")), "", CDate(currentRow("da1")).ToString("dd/MM/yyyy"))
                .TextreviewTime.Text = If(IsDBNull(currentRow("ne1")), "", CDate(currentRow("ne1")))
            End With

            ' Perform additional operations
            Me.SEARCHDATAPP1()
            Auditor("Loans", "USERNAME", "LO1", Me.TextDebtNumber.Text, "")
            Logentry = Uses

            ' Calculate total payments from DataGridView
            Dim total As Double = 0
            For Each r As DataGridViewRow In Me.DataGridView1.Rows
                If Not r.IsNewRow Then ' Skip the new row if present
                    total += If(r.Cells("Loa6").Value Is Nothing, 0, CDbl(r.Cells("Loa6").Value))
                End If
            Next
            Me.TextTotalPayments.Text = total.ToString("0.00")

            ' Calculate remaining debt
            Dim netDebt As Double = If(String.IsNullOrEmpty(Me.TextNetDebt.Text), 0, CDbl(Me.TextNetDebt.Text))
            Dim totalPayments As Double = If(String.IsNullOrEmpty(Me.TextTotalPayments.Text), 0, CDbl(Me.TextTotalPayments.Text))
            Me.TextRest.Text = (netDebt - totalPayments).ToString("0.00")

            ' Account and panel logic
            TestkeyAccounts(keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No))
            If TestkeyAccounts_Check Then
                AccountNoAktevd = keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No)
            End If
            Me.PanelAccount.Enabled = Me.Check_OptionsTransforAccounts.Checked

        Catch ex As Exception
            ' Display error message (or log it depending on requirements)
            MessageBox.Show("An error occurred while displaying the record: " & ex.Message)
        End Try
    End Sub

=======
    Private Sub FundBalance()
        On Error Resume Next
        Dim N As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
    Private Sub SEARCHDATAPP1()
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim strsql As New SqlCommand("select Loa6 from LoansPa  WHERE  CUser='" & CUser & "' and Lo ='" & Trim(Me.TextContractNumber.EditValue) & "'and Loa ='" & 0 & "'", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextPreviousPayments.Text = ds.Tables(0).Rows(0).Item(0)
        Else
            Me.TextPreviousPayments.Text = 0
        End If
    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles load1.Click
        On Error Resume Next
        Me.ds1.EnforceConstraints = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str1 As New SqlClient.SqlCommand("", Consum)
        With str1
            .CommandText = "SELECT lo1, lo, lo2, lo3, lo4, lo5, lo6, lo7, lo8, lo9, lo10,lo11, lo12, lo13, lo14, lo15, lo16, lo17, lo18, lo19, lo20, lo21, lo22, lo23, lo24, lo25, lo26, lo27, lo28, lo29, lo30, CB1, BN2, AsUser, Directorate,Recorded ,USERNAME, Auditor , cuser, coUser, da, ne, da1, ne1 FROM Loans   WHERE  CUser='" & CUser & "' and LO ='" & Trim(Me.TB1) & "'" & "or LO4 ='" & Trim(Me.TB2) & "'" & "or LO5 ='" & Trim(Me.TB3) & "'"
        End With
        Dim str2 As New SqlClient.SqlCommand("SELECT Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, CB1, USERNAME, CUser, COUser, da, ne  FROM LoansPa ", Consum)
        Dim str3 As New SqlClient.SqlCommand("SELECT lok1, lokA, lok2, lok3, lok4, lo22, TBNK7, lok FROM LoansK", Consum)
        Dim str4 As New SqlClient.SqlCommand("SELECT DOC1, LO, DOC2, DOC4, DOC5 FROM MYDOCUMENTSHOME", Consum)
        Me.ds1.EnforceConstraints = False
        Consum.Open()
        Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
        Me.SqlDataAdapter3 = New SqlClient.SqlDataAdapter(str3)
        Me.SqlDataAdapter4 = New SqlClient.SqlDataAdapter(str4)
        Me.ds1.Clear()
        Me.SqlDataAdapter1.Fill(Me.ds1, "Loans")
        Me.SqlDataAdapter2.Fill(Me.ds1, "LoansPa")
        Me.SqlDataAdapter3.Fill(Me.ds1, "LoansK")
        Me.SqlDataAdapter4.Fill(Me.ds1, "MYDOCUMENTSHOME")
        Me.ds1.Relations.Add("REL1", Me.ds1.Tables("Loans").Columns("LO"), Me.ds1.Tables("LoansPa").Columns("LO"), True)
        Me.ds1.Relations.Add("REL2", Me.ds1.Tables("Loans").Columns("LO"), Me.ds1.Tables("LoansK").Columns("LOK"), True)
        Me.ds1.Relations.Add("REL3", Me.ds1.Tables("Loans").Columns("LO17"), Me.ds1.Tables("MYDOCUMENTSHOME").Columns("LO"), True)
        Me.BS.DataSource = Me.ds1
        Me.BS.DataMember = "Loans"
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView3.AutoGenerateColumns = False
        Me.DataGridView4.AutoGenerateColumns = False

        Me.DataGridView1.DataSource = Me.BS
        Me.DataGridView1.DataMember = "REL1"
        Me.DataGridView4.DataSource = Me.BS
        Me.DataGridView4.DataMember = "REL2"
        Me.DataGridView3.DataSource = Me.BS
        Me.DataGridView3.DataMember = "REL3"
        Dim star As New SqlClient.SqlCommand("SELECT  Loa1, Lo, Loa, Loa2, Loa3, Loa4, Loa5, Loa6, Loa7, Loa8, Loa9, Loa10, Loa11, Loa12, Loa13, Loa14, Loa15, Loa16, LO25, CB1, USERNAME, CUser, COUser, da, ne FROM LoansPa ", Consum)
        Me.da = New SqlDataAdapter(star)
        Dim builder67 As New SqlCommandBuilder(da)
        Me.dt = New DataSet
        Me.da.Fill(Me.dt, "LoansPa")
        Me.DataGridView3.Columns("DOC3").Visible = False
        Me.DataGridView3.Columns("DOC6").Visible = False
        Me.DataGridView3.Columns("DOC7").Visible = False
        Me.DataGridView3.Columns("DOC8").Visible = False
        Me.DataGridView3.Columns("date_1").Visible = False
        Me.DataGridView3.Columns("USERNAME").Visible = False
        Me.DataGridView3.Columns("CUser").Visible = False
        Me.DataGridView3.Columns("COUser").Visible = False
        Me.DataGridView3.Columns("DA").Visible = False
        Me.DataGridView3.Columns("NE").Visible = False
        Me.DataGridView3.Columns("DA1").Visible = False
        Me.DataGridView3.Columns("NE1").Visible = False
        Me.ds1.EnforceConstraints = True
        Me.SqlDataAdapter1.Dispose()
        Me.SqlDataAdapter2.Dispose()
        Me.SqlDataAdapter3.Dispose()
        Me.SqlDataAdapter4.Dispose()
        Consum.Close()

        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCustomerName)
        FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboSponsorName)

        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
        Me.List1.DataSource = GetData(NUpDebitAccount.Value)
        Me.List1.DisplayMember = "account_name"
        Me.List2.DataSource = GetData(NUpCreditAccount.Value)
        Me.List2.DisplayMember = "account_name"

        FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
        FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If

        Me.RecordCount()
        Me.SumAmounBALANCE()
        Me.FundBalance()
        Me.DataGridView1_CellValidating(sender, e)
        'Me.PP1.Text=
        Me.DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        Me.DataGridView1.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomLeft
        Dim Column As New DataGridViewCheckBoxColumn
        With Me.DataGridView1
            .RowsDefaultCellStyle.BackColor = Color.Bisque
            .AlternatingRowsDefaultCellStyle.BackColor = Color.Beige
        End With
        Me.load1.Enabled = False
    End Sub
    Private Sub DISPLAYRECORD()
        On Error Resume Next
        With Me
            .TextDebtNumber.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo1").ToString
            .TextContractNumber.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo").ToString
            .DateMovementHistory.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo2").ToString
            .TEXTStatement.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo3").ToString
            .TextCustomerNumber.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo4").ToString
            .ComboCustomerName.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo5").ToString
            .TextNationalNo.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo6").ToString
            .TextAddress.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo7").ToString
            .TextMiligDebt.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo8").ToString
            .TextProfitRatio.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo9").ToString
            .ComboNumberOfYears.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo10").ToString
            .TextFirstBatch.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo11").ToString
            .TextTotalDebt.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo12").ToString
            .TextMonthlyInstallment.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo13").ToString
            .TextNetDebt.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo14").ToString
            .TextTotalDebtA.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo15").ToString
            .CheckTransferAccounts.Checked = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo16").ToString
            .TextMovementSymbol.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo17").ToString
            .CheckLogReview.Checked = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo18").ToString
            .CheckMember.Checked = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo19").ToString
            .ComboPaymentMethod.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo20").ToString
            .TextFundValue.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo21").ToString
            .TextValueOfCheck.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo22").ToString
            .ComboCheckDrawerName.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo23").ToString
            .TextCheckDrawerCode.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo24").ToString
            .TextCheckNumber.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo25").ToString
            .CheckDate.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo26").ToString
            .CheckRecordingAmountOfDebtAndPurchases.Checked = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo27").ToString
            .TextAccountsPayableValue.EditValue = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo28").ToString
            .CheckCollected.Checked = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo29").ToString
            .ComboLoanType.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Lo30").ToString

            .ComboCB1.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("CB1").ToString
            .ComboBN2.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("BN2").ToString

            .TextAssociationName.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("ASUser").ToString
            .TextDirectorateName.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Directorate").ToString
            .TextRegisteredUnderNo.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("Recorded").ToString
            .TEXTUserName.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("USERNAME").ToString
            .TEXTReferenceName.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position).Item("Auditor").ToString
            .TextDefinitionDirectorate.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("COUser").ToString
            .TEXTAddDate.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("da").ToString
            .TextTimeAdd.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("na").ToString
            .TEXTReviewDate.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("da1").ToString
            .TextreviewTime.Text = Me.ds1.Tables("Loans").Rows(Me.BS.Position)("ne1").ToString
        End With

        Me.SEARCHDATAPP1()
        Auditor("Loans", "USERNAME", "LO1", Me.TextDebtNumber.Text, "")
        Logentry = Uses

        Dim total As Double
        Dim tota2 As Double
        For Each r As DataGridViewRow In Me.DataGridView1.Rows
            total += CDbl(r.Cells("Loa6").Value)
        Next
        Me.TextTotalPayments.Text = total.ToString("0.00")
        tota2 = Val(Me.TextNetDebt.Text) - Val(Me.TextTotalPayments.Text)
        Me.TextRest.Text = tota2.ToString("0.00")
        TestkeyAccounts(keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No)
        End If
        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Sub LoadDataBase()
        On Error Resume Next
        If TestNet = True Then
            Me.Label2.ForeColor = Color.Yellow
        Else
            Me.Close()
        End If
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
            Me.Count()
            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")
<<<<<<< HEAD
                Exit Sub
            End If
            TransferAccounts = True
            RecordingAmountOfDebtAndPurchases = True
            Me.TextNetDebt.Text = Format(Val(Me.TextMiligDebt.EditValue) * Val(Me.TextProfitRatio.EditValue) / 100 * Val(Me.ComboNumberOfYears.Text) + Val(Me.TextMiligDebt.EditValue) - Val(Me.TextFirstBatch.EditValue), "0.000")
            Me.TextMonthlyInstallment.Text = Format(Val(Me.TextNetDebt.Text) / (Val(Me.ComboNumberOfYears.Text) * 12), "0.000")
            Dim Sound As IO.Stream = My.Resources.save
=======

                Exit Sub
            End If
            Me.TextNetDebt.Text = Format(Val(Me.TextMiligDebt.EditValue) * Val(Me.TextProfitRatio.EditValue) / 100 * Val(Me.ComboNumberOfYears.Text) + Val(Me.TextMiligDebt.EditValue) - Val(Me.TextFirstBatch.EditValue), "0.000")
            Me.TextMonthlyInstallment.Text = Format(Val(Me.TextNetDebt.Text) / (Val(Me.ComboNumberOfYears.Text) * 12), "0.000")
            Dim Sound As System.IO.Stream = My.Resources.save
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD

    Public Sub Count()
        Me.lblNavLocation.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub

    Private Sub LblNavLocation_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles Label1.TextChanged
        Me.Count()
    End Sub

=======
    Public Sub Count()
        On Error Resume Next
        Me.lblNavLocation.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub LblNavLocation_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.TextChanged
        On Error Resume Next
        Me.Count()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD

    Private Sub RecordCount()
        Try
            ' Declare variables with meaningful names
            Dim TotalRecords As Integer = Me.BS.Count
            Dim CurrentRecord As Integer = Me.BS.Position + 1

            ' Update the navigation label (e.g., "1 من 10")
            Me.lblNavLocation.Text = CurrentRecord.ToString & " من " & TotalRecords.ToString

            ' Enable/disable navigation buttons directly based on position
            Me.btnNavFirst.Enabled = (Me.BS.Position > 0)
            Me.btnNavPrev.Enabled = (Me.BS.Position > 0)
            Me.btnNavNext.Enabled = (Me.BS.Position < TotalRecords - 1)
            Me.btnLast.Enabled = (Me.BS.Position < TotalRecords - 1)

            ' Perform additional UI updates or logic
            Me.DISPLAYRECORD()
            Me.AutoEx()
            Call MangUsers()
            Me.SHOWBUTTON()
            Me.InternalAuditorType()
            Me.AccountsEnquiry()
            Me.BUTTONCANCEL.Enabled = True
        Catch ex As Exception
            ' Display error message (customize as needed)
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
        Me.RecordCount()
    End Sub

    Private Sub BtnNavFirst_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNavFirst.Click
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub

    Private Sub BtnNavPrev_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNavPrev.Click
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub

    Private Sub BtnNavNext_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnNavNext.Click
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub

    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles btnLast.Click
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub

    Private Sub ComboCustomerName_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        ' Check if an item is selected
        If ComboCustomerName.SelectedIndex = -1 Then
            Me.TextCustomerNumber.EditValue = ""
            Me.TextNationalNo.Text = ""
            Me.TextAddress.Text = ""
            Me.CheckMember.Checked = False
            Return
        End If

        Try
            ' Use Using to ensure proper resource disposal
            Using connection As New SqlConnection(constring)
                connection.Open()
                ' Parameterized query to prevent SQL injection
                Dim query As String = "SELECT IDcust, cust3, cust7, cust33, CUser FROM AllCustomers WHERE cust2 = @cust2"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@cust2", ComboCustomerName.Text)
                    Using adapter As New SqlDataAdapter(command)
                        Dim dataSet As New DataSet()
                        adapter.Fill(dataSet)
                        If dataSet.Tables(0).Rows.Count > 0 Then
                            Dim row As DataRow = dataSet.Tables(0).Rows(0)
                            Me.TextCustomerNumber.EditValue = row("IDcust")
                            Me.TextNationalNo.Text = row("cust3")
                            Me.TextAddress.Text = row("cust7")
                            Me.CheckMember.Checked = CBool(row("cust33")) ' Assuming cust33 is a boolean field
                        Else
                            Me.TextCustomerNumber.EditValue = ""
                            Me.TextNationalNo.Text = ""
                            Me.TextAddress.Text = ""
                            Me.CheckMember.Checked = False
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Display error message and optionally log it
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub DataGridView4_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView4.CellEnter
=======
    Private Sub MAXRECORD()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim V As Integer
        Dim SQL As String = "SELECT MAX(Lo1) FROM Loans"
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL
            V = .ExecuteScalar()
        End With
        Me.TextDebtNumber.Text = Val(V) + 1
        Consum.Close()
    End Sub
    Private Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.lblNavLocation.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.ds1.Tables("Loans").Rows.Count - 1 Then
            Forward = True
        End If
        Me.btnNavFirst.Enabled = Back
        Me.btnNavPrev.Enabled = Back
        Me.btnNavNext.Enabled = Forward
        Me.btnLast.Enabled = Forward
        Me.DISPLAYRECORD()
        Me.AutoEx()
        Call MangUsers()
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.AccountsEnquiry()
        Me.BUTTONCANCEL.Enabled = True



    End Sub

    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub BtnNavFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavFirst.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub BtnNavPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavPrev.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub BtnNavNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNavNext.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub BtnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
        On Error Resume Next
        Me.BS.Position = Me.BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCustomerName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim strsql As New SqlCommand("select IDcust,cust3,cust7,cust33,CUser from AllCustomers where cust2 = '" & ComboCustomerName.Text & "'", Consum)
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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
    Private Sub DataGridView4_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView4.CellEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.DataGridView4.SelectedRows.Count = 0 Then
                Me.DataGridView4.Item("LOKa", e.RowIndex).Value = Me.DataGridView4.CurrentRow.Index + 1
                Me.DataGridView4.Item("LOK", e.RowIndex).Value = Me.TextContractNumber.EditValue
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error97", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub DataGridView4_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs) Handles DataGridView4.DataError
        On Error Resume Next
        'Exit Sub
    End Sub

    Private Sub SEARCHDATAITEMS10()
        Dim Consum As New SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK6 FROM PTRANSACTION WHERE TBNK23 = '" & Val(Me.TextSponsorCode.EditValue) & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql2)
=======
    Private Sub DataGridView4_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles DataGridView4.DataError
        On Error Resume Next
        'Exit Sub
    End Sub
    Private Sub SEARCHDATAITEMS10()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT TBNK6 FROM PTRANSACTION WHERE TBNK23 = '" & Val(Me.TextSponsorCode.EditValue) & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "PTRANSACTION")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextGuarantorAccountNumber.EditValue = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextGuarantorAccountNumber.EditValue = ""
        End If
    End Sub
<<<<<<< HEAD

    Private Sub InternalAuditorBalance()
        Try
            ' Use Using to ensure proper resource disposal
            Using connection As New SqlConnection(constring)
                connection.Open()
                ' Define account types in an array
                Dim accountTypes As String() = {"امانات", "توفير", "الودائع", "شهادة إدخار", "الاسهم"}
                Dim sums(4) As Double ' Array to store calculated sums for each account type

                ' Loop through each account type to calculate balances
                For i As Integer = 0 To accountTypes.Length - 1
                    Dim query As String = "SELECT SUM(PTRANSACTION.TBNK4) AS SumDEBIT, SUM(PTRANSACTION.TBNK5) AS SumDEBIT1 " &
                                     "FROM PTRANSACTION WHERE TBNK6 = @accountNumber AND TBNK8 = @accountType"
                    Using command As New SqlCommand(query, connection)
                        ' Use parameterized query to prevent SQL injection
                        command.Parameters.AddWithValue("@accountNumber", Me.TextGuarantorAccountNumber.EditValue)
                        command.Parameters.AddWithValue("@accountType", accountTypes(i))
                        Using adapter As New SqlDataAdapter(command)
                            Dim dataSet As New DataSet()
                            adapter.Fill(dataSet)
                            ' Check if data exists and is not null
                            If dataSet.Tables(0).Rows.Count > 0 AndAlso dataSet.Tables(0).Rows(0).Item(0) IsNot DBNull.Value AndAlso dataSet.Tables(0).Rows(0).Item(1) IsNot DBNull.Value Then
                                Dim sumDebit As Double = CDbl(dataSet.Tables(0).Rows(0).Item(0))
                                Dim sumDebit1 As Double = CDbl(dataSet.Tables(0).Rows(0).Item(1))
                                sums(i) = sumDebit1 - sumDebit
                            Else
                                sums(i) = 0
                            End If
                        End Using
                    End Using
                Next

                ' Assign formatted sums to text fields
                Me.Taa1.Text = Format(sums(0), "0.000")
                Me.Taa2.Text = Format(sums(1), "0.000")
                Me.Taa3.Text = Format(sums(2), "0.000")
                Me.Taa4.Text = Format(sums(3), "0.000")
                Me.Taa5.Text = Format(sums(4), "0.000")
                ' Calculate and assign total sum
                Me.Taa6.Text = Format(sums(0) + sums(1) + sums(2) + sums(3) + sums(4), "0.000")
            End Using
        Catch ex As Exception
            ' Handle errors gracefully
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

=======
    Private Sub InternalAuditorBalance()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Adp2 As SqlClient.SqlDataAdapter
        Dim Adp3 As SqlClient.SqlDataAdapter
        Dim Adp4 As SqlClient.SqlDataAdapter
        Dim Adp5 As SqlClient.SqlDataAdapter
        Dim SUM1, SUM2, SUM3, SUM4, SUM5 As Double
        Dim Consum As New SqlClient.SqlConnection(constring)
        On Error Resume Next
        Dim strsq1 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextGuarantorAccountNumber.EditValue & "'" & "AND TBNK8='امانات'", Consum)
        Dim strsq2 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextGuarantorAccountNumber.EditValue & "'" & "AND TBNK8='توفير'", Consum)
        Dim strsq3 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextGuarantorAccountNumber.EditValue & "'" & "AND TBNK8='الودائع'", Consum)
        Dim strsq4 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextGuarantorAccountNumber.EditValue & "'" & "AND TBNK8='شهادة إدخار'", Consum)
        Dim strsq5 As New SqlCommand("SELECT Sum(PTRANSACTION.TBNK4) AS SumDEBIT,Sum(PTRANSACTION.TBNK5) AS SumDEBIT1 FROM PTRANSACTION WHERE TBNK6 = '" & Me.TextGuarantorAccountNumber.EditValue & "'" & "AND TBNK8='الاسهم'", Consum)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim ds4 As New DataSet
        Dim ds5 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        Adp2 = New SqlClient.SqlDataAdapter(strsq2)
        Adp3 = New SqlClient.SqlDataAdapter(strsq3)
        Adp4 = New SqlClient.SqlDataAdapter(strsq4)
        Adp5 = New SqlClient.SqlDataAdapter(strsq5)
        ds1.Clear()
        ds2.Clear()
        ds3.Clear()
        ds4.Clear()
        ds5.Clear()
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
        Me.Taa6.Text = Val(SUM1) + Val(SUM2) + Val(SUM3) + Val(SUM4) + Val(SUM5)
        Adp1.Dispose()
        Adp2.Dispose()
        Adp3.Dispose()
        Adp4.Dispose()
        Adp5.Dispose()
        Consum.Close()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub Tepy()
        If Me.RadioButton1.Checked = True Then
            Me.ButtonAddSponsor.Text = "اضافة كفيل"
            Me.ButtonAddSponsor.Image = My.Resources.add1
        ElseIf Me.RadioButton2.Checked = True Then
            Me.ButtonAddSponsor.Text = "تعديل كفيل"
            Me.ButtonAddSponsor.Image = My.Resources.disk_edit
        End If
    End Sub
<<<<<<< HEAD

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton1.CheckedChanged
        Call Me.Tepy()
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioButton2.CheckedChanged
        Call Me.Tepy()
    End Sub

    Private Sub DataGridView4_CellMouseDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs) Handles DataGridView4.CellMouseDoubleClick
        Try
            Dim resault As Integer
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged
        Call Me.Tepy()
    End Sub
    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton2.CheckedChanged
        Call Me.Tepy()
    End Sub
    Private Sub DataGridView4_CellMouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView4.CellMouseDoubleClick
        Try
            Dim resault As Integer
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.BS.Count > 0 Then
                resault = MessageBox.Show("سبنم حذف السجلات المحددة", "حذف السجلات المحددة", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    If Me.DataGridView4.SelectedRows.Count > 0 Then
                        For i As Integer = Me.DataGridView4.SelectedRows.Count - 1 To 0
                            Dim n As Integer
                            n = Me.DataGridView4.SelectedRows(i).Cells("LOK1").Value
                            Me.DataGridView4.Rows.RemoveAt(Me.DataGridView4.SelectedRows(i).Index)
<<<<<<< HEAD
                            Dim CMD2 As New SqlCommand With {
=======
                            Dim CMD2 As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                                .CommandType = CommandType.Text,
                                .Connection = Consum
                            }
                            If Consum.State = ConnectionState.Open Then Consum.Close()
                            Consum.Open()
                            Dim SQL2 As New SqlCommand("DELETE FROM LoansK WHERE LOK1=" & n, Consum)
                            CMD2.CommandText = SQL2.CommandText
                            CMD2.ExecuteNonQuery()
                        Next
                        Consum.Close()
                    Else

                    End If
                    Exit Sub
                Else
                    MessageBox.Show("تم ايقاف عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
            Else
                MessageBox.Show(" لايوجد سجلات محددة لاتمام عملية الحذف", "حذف السجلات المحددة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "تنبيه")
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboSponsorName.SelectedIndexChanged
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSponsorName.SelectedIndexChanged
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Me.Tepy()
        Dim strsql As New SqlCommand("SELECT IDcust,cust2,cust3,cust7,CUser  FROM AllCustomers WHERE cust2 ='" & Me.ComboSponsorName.Text & "'", Consum)
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
            Me.TextSponsorCode.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.nemcust2 = ds.Tables(0).Rows(0).Item(1)
            Me.nemcust7 = ds.Tables(0).Rows(0).Item(3)
            Me.SEARCHDATAITEMS10()
            Me.InternalAuditorBalance()
        Else
            Me.TextSponsorCode.EditValue = ""
            Me.TextGuarantorAccountNumber.EditValue = ""
            Me.nemcust2 = ""
            Me.nemcust7 = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD

    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles ComboSponsorName.LostFocus
        On Error Resume Next
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub ComboBox2_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboSponsorName.LostFocus
        On Error Resume Next
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Me.Tepy()
        Dim strsql As New SqlCommand("SELECT IDcust,cust2,cust3,cust7,CUser  FROM AllCustomers WHERE cust2 ='" & Me.ComboSponsorName.Text & "'", Consum)
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
            Me.TextSponsorCode.EditValue = ds.Tables(0).Rows(0).Item(0)
            Me.nemcust2 = ds.Tables(0).Rows(0).Item(1)
            Me.nemcust7 = ds.Tables(0).Rows(0).Item(3)
            Me.SEARCHDATAITEMS10()
            Me.InternalAuditorBalance()
        Else
            Me.TextSponsorCode.EditValue = ""
            Me.TextGuarantorAccountNumber.EditValue = ""
            Me.nemcust2 = ""
            Me.nemcust7 = ""
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
        If Me.TextFirstBatch.EditValue > 0 Then
            Me.PB1.Enabled = True
        Else
            Me.PB1.Enabled = False
        End If

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

    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles EDITBUTTON.Click
=======
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) <> FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = True Then
                MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
                Exit Sub
            End If
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Static Dim P As Integer
            P = Me.BS.Position
            ppp = Me.TextPreviousPayments.Text
            Me.DELETEDATRECORD()

            Me.UPDATELoans()
            Me.SaveLoansPa()
            Me.SaveLoansK()
            Me.UPDATELoansPa()
            Me.UPDATLoansK()
            Me.RecordCount()
            Me.Load_Click(sender, e)
            Me.BS.Position = P
            Me.UPDATELoans()
            Me.UPDATELoansPa()
            Me.SaveLoansPa()
            Me.SaveLoansK()
            Me.UPDATELoansPa()
            Me.UPDATLoansK()
            Me.ButtonDivision_Click(sender, e)
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Insert_Actions(Me.TextDebtNumber.Text, "تعديل", Me.Text)
=======
            Insert_Actions(Me.TextDebtNumber.Text.Trim, "تعديل", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SAVEBUTTON_Click(sender As Object, e As EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockUpdate = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim nextRow As DataGridViewRow
            nextRow = Me.DataGridView4.Rows(0)
            Me.DataGridView4.Rows(0).Selected = True

            Static Dim P As Integer
            P = Me.BS.Position

            Me.SaveLoansK()
            Me.UPDATLoansK()
            Me.RecordCount()
            Me.Load_Click(sender, e)
            Me.BS.Position = P
            Me.SaveLoansK()
            Me.UPDATLoansK()
            Me.PictureBox2.Visible = True
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Me.RowCount = Me.BS.Count
            Insert_Actions(Me.TextDebtNumber.Text, "حفظ / نعديل الكفيل", Me.Text)

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVEBUTTON_Click", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAddSponsor.Click
=======
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddSponsor.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.RadioButton1.Checked = True Then
            Me.DataGridView4.AutoGenerateColumns = False

            Me.DataGridView4.CurrentCell = Me.DataGridView4("LOKA", Me.DataGridView4.NewRowIndex)
            Me.DataGridView4.Rows(Me.DataGridView4.Rows.Count - 2).Selected = True
            Me.DataGridView4.MultiSelect = False
            Me.DataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            Me.DataGridView4.Sort(Me.DataGridView4.Columns("LOKA"), System.ComponentModel.ListSortDirection.Descending)
            Me.DataGridView4.Sort(Me.DataGridView4.Columns("LOKA"), System.ComponentModel.ListSortDirection.Ascending)

            Me.DataGridView4.Rows.Add()
            Me.DataGridView4.CurrentRow.Cells("LOKA").Value = Me.DataGridView4.CurrentRow.Index + 1
            Me.DataGridView4.CurrentRow.Cells("LOK2").Value = Me.TextSponsorCode.EditValue
            Me.DataGridView4.CurrentRow.Cells("LOK3").Value = Me.nemcust2
            Me.DataGridView4.CurrentRow.Cells("LOK4").Value = Me.nemcust7
            Me.DataGridView4.CurrentRow.Cells("TBNK7").Value = Me.Taa6.Text
            Me.DataGridView4.CurrentRow.Cells("LO22").Value = Me.TextNetDebt.Text
            'Me.DataGridView4.CurrentRow.Cells("LOK").Value = Me.TextBox39.Text
            'Me.DataGridView4.ClearSelection()
            'Dim nextRow As DataGridViewRow
            'nextRow = Me.DataGridView4.Rows(0)
            'Me.DataGridView4.Rows(0).Selected = True

        ElseIf RadioButton2.Checked = True Then
            Me.DataGridView4.ClearSelection()
            Dim nextRow As DataGridViewRow
            nextRow = Me.DataGridView4.Rows(0)
            Me.DataGridView4.Rows(0).Selected = True

            Me.DataGridView4.CurrentRow.Cells("LOK2").Value = Me.TextSponsorCode.EditValue
            Me.DataGridView4.CurrentRow.Cells("LOK3").Value = Me.nemcust2
            Me.DataGridView4.CurrentRow.Cells("LOK4").Value = Me.nemcust7
            Me.DataGridView4.CurrentRow.Cells("TBNK7").Value = Me.Taa6.Text.Trim
            Me.DataGridView4.CurrentRow.Cells("LO22").Value = Me.TextNetDebt.Text.Trim
        End If

    End Sub

<<<<<<< HEAD
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONCANCEL.Click
=======


    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
<<<<<<< HEAD

    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles DELETEBUTTON.Click
=======
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockDelete = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = True Then
                MsgBox("لايمكن حذف السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
                Exit Sub
            End If
            If MsgBox("  استمرار حذف السجل الحالي" & " ؟ ", MsgBoxStyle.Exclamation + MsgBoxStyle.MsgBoxRight + MsgBoxStyle.OkCancel, "حذف سجل") = MsgBoxResult.Cancel Then Exit Sub
            MYDELETERECORD("Loans", "lo", Me.TextContractNumber, Me.BS, True)
            MYDELETERECORD("LoansPa", "lo", Me.TextContractNumber, Me.BS, True)
            Me.Load_Click(sender, e)
            Me.Cursor = Cursors.WaitCursor
            Me.PictureBox2.Visible = True
            Me.RowCount = Me.BS.Count
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error98", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub DELETEDATRECORD()
        Try
            If DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To DataGridView1.Rows.Count - 1
                    Dim row As DataGridViewRow = DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For
                    MYDELETERECORD("LoansPa", "lo", Me.TextContractNumber, Me.BS, True)
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        Dim F As New FrmPRINT
        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim rpt As New rptLoans
        Dim Installment As Double
        Dim Installment1 As Double
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim SqlDataAdapter1 As New SqlDataAdapter
        If Me.CheckUnreviewedRecords.Checked = False Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM Loans  WHERE   CUser='" & CUser & "' and LO1 ='" & Me.TextDebtNumber.Text & "'", Consum)
            'and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        If Me.CheckUnreviewedRecords.Checked = False Then
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlClient.SqlCommand("SELECT * FROM Loans  WHERE   CUser='" & CUser & "' and LO1 ='" & Me.TextDebtNumber.Text & "'", Consum)
            'and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            Consum.Close()
            SqlDataAdapter1.Fill(ds, "Loans")
            If ds.Tables(0).Rows.Count > 0 Then
                Installment = ds.Tables(0).Rows(0).Item("Lo21")
            Else
                Installment = ""
            End If
            Int(Installment)
            Installment = -Int(Installment)
            rpt.SetDataSource(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                txt1 = rpt.Section1.ReportObjects("TEXT22")
                txt1.Text = CurrencyJO(Installment, "jO")
                txt1 = rpt.Section1.ReportObjects("TEXT40")
                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("LO20"), "jO")
                txt1 = rpt.Section1.ReportObjects("TEXT43")
                txt1.Text = CurrencyJO(ds.Tables(0).Rows(0).Item("LO19"), "jO")
                txt = rpt.Section1.ReportObjects("TEXT7")
                txt.Text = AssociationName
                txt = rpt.Section1.ReportObjects("TEXT9")
                txt.Text = Directorate
                txt = rpt.Section1.ReportObjects("TEXT18")
                txt.Text = "العنوان" & " " & ":" & " " & Adrss & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone & " " & "|" & " " & "هاتف" & " " & ":" & " " & Phone1
                F.CrystalReportViewer1.ReportSource = rpt
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Consum.Close()
        ElseIf Me.CheckUnreviewedRecords.Checked = True Then
            Dim rpt1 As New rptLoans1
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            Dim ds1 As New DataSet
<<<<<<< HEAD
            Dim str1 As New SqlCommand("SELECT * FROM Loans  WHERE   CUser='" & CUser & "' and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and LO18 ='" & False & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str1)
=======
            Dim str1 As New SqlClient.SqlCommand("SELECT * FROM Loans  WHERE   CUser='" & CUser & "' and Year(Lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and LO18 ='" & False & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds1.Clear()
            SqlDataAdapter1.Fill(ds1, "Loans")
            If ds1.Tables(0).Rows.Count > 0 Then
                rpt1.SetDataSource(ds1)
                txt = rpt1.Section1.ReportObjects("TEXT2")
                txt = rpt1.Section1.ReportObjects("Text15")
                txt.Text = AssociationName
                txt = rpt1.Section1.ReportObjects("Text16")
                txt.Text = Directorate
                F.CrystalReportViewer1.ReportSource = rpt1
                F.CrystalReportViewer1.Zoom(90%)
                F.CrystalReportViewer1.RefreshReport()
                F.Show()
            Else
                MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
        End If
    End Sub
<<<<<<< HEAD

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonBatchPrinting.Click
=======
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonBatchPrinting.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim F As New FrmPRINT
        Dim txt As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim rpt1 As New rptLoans2
        GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
        Dim ds1 As New DataSet
<<<<<<< HEAD
        Dim str1 As New SqlCommand("SELECT * FROM LoansPa  WHERE   CUser='" & CUser & "' and LO ='" & Me.TextContractNumber.EditValue & "'", Consum)
        SqlDataAdapter1 = New SqlDataAdapter(str1)
=======
        Dim str1 As New SqlClient.SqlCommand("SELECT * FROM LoansPa  WHERE   CUser='" & CUser & "' and LO ='" & Me.TextContractNumber.EditValue & "'", Consum)
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds1.Clear()
        SqlDataAdapter1.Fill(ds1, "LoansPa")
        If ds1.Tables(0).Rows.Count > 0 Then
            rpt1.SetDataSource(ds1)
            txt = rpt1.Section1.ReportObjects("TEXT2")
            txt = rpt1.Section1.ReportObjects("Text15")
            txt.Text = AssociationName
            txt = rpt1.Section1.ReportObjects("Text16")
            txt.Text = Directorate
            F.CrystalReportViewer1.ReportSource = rpt1
            F.CrystalReportViewer1.Zoom(90%)
            F.CrystalReportViewer1.RefreshReport()
            F.Show()
        Else
            MessageBox.Show("لاتوجد بيانات حالية للطباعة", "طباعة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub
<<<<<<< HEAD

    Private Sub SaveLoansPa()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim PA As String = "PA" & "/" & Me.TextDebtNumber.Text
        For x As Integer = 0 To DataGridView1.RowCount - 2
            Dim SQL As New SqlCommand("INSERT INTO LoansPa(Loa, Loa2, Loa3,Loa7, Loa8, Loa9, Loa10, Loa11, Loa25) VALUES     (@Loa, @Loa2, @Loa3, @Loa7, @Loa8, @Loa9, @Loa10, @Loa11, @Loa25)", Consum)
            Dim CMD As New SqlCommand
=======
    Private Sub SaveLoansPa()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim PA As String = "PA" & "/" & Me.TextDebtNumber.Text
        For x As Integer = 0 To DataGridView1.RowCount - 2
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO LoansPa(Loa, Loa2, Loa3,Loa7, Loa8, Loa9, Loa10, Loa11, Loa25) VALUES     (@Loa, @Loa2, @Loa3, @Loa7, @Loa8, @Loa9, @Loa10, @Loa11, @Loa25)", Consum)
            Dim CMD As New SqlClient.SqlCommand
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With CMD.Parameters
                .AddWithValue("@Lo", Me.TextContractNumber.EditValue).DbType = DbType.String
                .AddWithValue("@Loa", Me.DataGridView2.Rows(x).Cells(0).Value).DbType = DbType.String
                .AddWithValue("@Loa2", Me.DataGridView2.Rows(x).Cells("dat1").Value).DbType = DbType.String
                .AddWithValue("@Loa3", "لم يتم التسديد").DbType = DbType.String
                .AddWithValue("@Loa7", Me.DataGridView2.Rows(x).Cells(1).Value).DbType = DbType.String
                .AddWithValue("@Loa8", Me.TextNetDebt.Text).DbType = DbType.String
                .AddWithValue("@Loa9", Me.TextNetDebt.Text).DbType = DbType.String
                .AddWithValue("@Loa10", Me.TextCustomerNumber.EditValue).DbType = DbType.String
                .AddWithValue("@Loa11", Me.ComboCustomerName.Text).DbType = DbType.String
                .AddWithValue("@Loa25", PA.ToString & "/" & Me.DataGridView2.Rows(x).Cells(0).Value).DbType = DbType.String
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
<<<<<<< HEAD

    Private Sub SaveLoansK()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("INSERT INTO LoansK ( lokA, lok2, lok3, lok4, lo22, TBNK7, lok) VALUES     (@lokA, @lok2, @lok3, @lok4, @lo22, @TBNK7, @lok)", Consum)
        Dim CMD As New SqlCommand With {
=======
    Private Sub SaveLoansK()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("INSERT INTO LoansK ( lokA, lok2, lok3, lok4, lo22, TBNK7, lok) VALUES     (@lokA, @lok2, @lok3, @lok4, @lo22, @TBNK7, @lok)", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@lok1", SqlDbType.Int, 4, "lok1")
            .Parameters.Add("@lokA", SqlDbType.Int, 4, "lokA")
            .Parameters.Add("@lok2", SqlDbType.Int, 4, "lok2")
            .Parameters.Add("@lok3", SqlDbType.NVarChar, 150, "lok3").Value = Me.ComboSponsorName.Text.Trim
            .Parameters.Add("@lok4", SqlDbType.NVarChar, 250, "lok4")
            .Parameters.Add("@lo22", SqlDbType.Float, 8, "lo22")
            .Parameters.Add("@TBNK7", SqlDbType.Float, 8, "TBNK7").Value = Me.Taa6.Text
            .Parameters.Add("@lok", SqlDbType.BigInt, 8, "lok").Value = Me.TextDebtNumber.Text
            .CommandText = SQL.CommandText
        End With
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter3.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table3", "LoansK", New DataColumnMapping() {New DataColumnMapping("lok1", "lok1"), New DataColumnMapping("lokA", "lokA"), New DataColumnMapping("lok2", "lok2"), New DataColumnMapping("lok3", "lok3"), New DataColumnMapping("lok4", "lok4"), New DataColumnMapping("lo22", "lo22"), New DataColumnMapping("TBNK7", "TBNK7"), New DataColumnMapping("lok", "lok")})})
        SqlDataAdapter3.InsertCommand = CMD
        SqlDataAdapter3.Update(ds1, "LoansK")
        SqlDataAdapter3.TableMappings.Clear()
        Consum.Close()
    End Sub
<<<<<<< HEAD

    Private Sub UPDATLoansK()
        On Error Resume Next
        Dim Consum As New SqlConnection(constring)
        Dim SQL As New SqlCommand("Update LoansK SET    lokA = @lokA, LoK2 = @LoK2, LoK3 = @LoK3, LoK4 = @LoK4, Lo22 = @Lo22, TBNK7 = @TBNK7, lok = @lok WHERE  LoK1 = @lok1", Consum)
        Dim CMD As New SqlCommand With {
=======
    Private Sub UPDATLoansK()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlClient.SqlCommand("Update LoansK SET    lokA = @lokA, LoK2 = @LoK2, LoK3 = @LoK3, LoK4 = @LoK4, Lo22 = @Lo22, TBNK7 = @TBNK7, lok = @lok WHERE  LoK1 = @lok1", Consum)
        Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .CommandType = CommandType.Text,
            .Connection = Consum
        }
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            .Parameters.Add("@LoK1", SqlDbType.Int, 4, "LoK1")
            .Parameters.Add("@LoKA", SqlDbType.Int, 4, "LoKA")
            .Parameters.Add("@LoK2", SqlDbType.Int, 4, "LoK2")
            .Parameters.Add("@LoK3", SqlDbType.NVarChar, 150, "LoK3").Value = Me.ComboSponsorName.Text.Trim
            .Parameters.Add("@LoK4", SqlDbType.NVarChar, 250, "LoK4")
            .Parameters.Add("@Lo22", SqlDbType.Float, 8, "Lo22")
            .Parameters.Add("@TBNK7", SqlDbType.Float, 8, "TBNK7").Value = Me.Taa6.Text
            .Parameters.Add("@LoK", SqlDbType.BigInt, 8, "LoK").Value = Me.TextDebtNumber.Text
            .CommandText = SQL.CommandText
        End With

        SqlDataAdapter3.TableMappings.AddRange(New DataTableMapping() {New DataTableMapping("Table4", "LoansK", New DataColumnMapping() {New DataColumnMapping("LoK1", "LoK1"), New DataColumnMapping("LoKa", "LoKa"), New DataColumnMapping("LoK3", "LoK3"), New DataColumnMapping("LoK4", "LoK4"), New DataColumnMapping("Lo22", "Lo22"), New DataColumnMapping("TBNK7", "TBNK7"), New DataColumnMapping("lok", "lok")})})
        SqlDataAdapter3.UpdateCommand = CMD
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        SqlDataAdapter3.Update(ds1, "LoansK")
        SqlDataAdapter3.TableMappings.Clear()
        Consum.Close()
    End Sub
<<<<<<< HEAD

    Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub

    Private Sub UPDATELoans()
        Try
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  Loans SET   lo2 = @lo2, lo3 = @lo3, lo4 = @lo4, lo5 = @lo5, lo6 = @lo6, lo7 = @lo7, lo8 = @lo8, lo9 = @lo9, lo10 = @lo10, lo11 = @lo11, lo12 = @lo12, lo13 = @lo13, lo14 = @lo14, lo15 = @lo15, lo16 = @lo16, lo17 = @lo17, lo18 = @lo18, lo19 = @lo19, lo20 = @lo20, lo21 = @lo21, lo22 = @lo22, lo23 = @lo23, lo24 = @lo24, lo25 = @lo25, lo26 = @lo26, lo27 = @lo27, lo28 = @lo28, lo30 = @lo30, CB1 = @CB1, BN2 = @BN2, AsUser = @AsUser, USERNAME = @USERNAME, Auditor = @Auditor, cuser = @cuser, couser = @couser, Directorate = @Directorate, Recorded = @Recorded, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE lo1 = @lo1", Consum)
            Dim CMD As New SqlCommand With {
=======
    Private Sub Bmp_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub UPDATELoans()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" UPDATE  Loans SET   lo2 = @lo2, lo3 = @lo3, lo4 = @lo4, lo5 = @lo5, lo6 = @lo6, lo7 = @lo7, lo8 = @lo8, lo9 = @lo9, lo10 = @lo10, lo11 = @lo11, lo12 = @lo12, lo13 = @lo13, lo14 = @lo14, lo15 = @lo15, lo16 = @lo16, lo17 = @lo17, lo18 = @lo18, lo19 = @lo19, lo20 = @lo20, lo21 = @lo21, lo22 = @lo22, lo23 = @lo23, lo24 = @lo24, lo25 = @lo25, lo26 = @lo26, lo27 = @lo27, lo28 = @lo28, lo30 = @lo30, CB1 = @CB1, BN2 = @BN2, AsUser = @AsUser, USERNAME = @USERNAME, Auditor = @Auditor, cuser = @cuser, couser = @couser, Directorate = @Directorate, Recorded = @Recorded, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE lo = @lo", Consum)
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
                .Parameters.Add("@lo", SqlDbType.BigInt).Value = Me.TextContractNumber.EditValue
                '.Parameters.Add("@lo1", SqlDbType.Int).Value = Me.Text1.Text
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
<<<<<<< HEAD
                .Parameters.Add("@lo16", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@lo17", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@lo18", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@lo19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckMember.Checked)




=======
                .Parameters.Add("@lo16", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckTransferAccounts.Checked)
                .Parameters.Add("@lo17", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@lo18", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@lo19", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckMember.Checked)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .Parameters.Add("@lo20", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod.Text
                .Parameters.Add("@lo21", SqlDbType.Float).Value = Val(Me.TextFundValue.EditValue)
                .Parameters.Add("@lo22", SqlDbType.Float).Value = Val(Me.TextValueOfCheck.EditValue)
                .Parameters.Add("@lo23", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@lo24", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@lo25", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
<<<<<<< HEAD
                .Parameters.Add("@lo26", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
=======
                .Parameters.Add("@lo26", SqlDbType.Date).Value = Me.CheckDate.Value.ToString
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .Parameters.Add("@lo27", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckRecordingAmountOfDebtAndPurchases.Checked)
                .Parameters.Add("@lo28", SqlDbType.Float).Value = Val(Me.TextAccountsPayableValue.EditValue)
                .Parameters.Add("@lo30", SqlDbType.NVarChar).Value = Me.ComboLoanType.Text
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text

                .Parameters.Add("@AsUser", SqlDbType.NVarChar).Value = AssociationName
                .Parameters.Add("@Directorate", SqlDbType.NVarChar).Value = Directorate
                .Parameters.Add("@Recorded", SqlDbType.NVarChar).Value = Recorded
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@coUser", SqlDbType.NVarChar).Value = COUser
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
            Consum.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATE", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub UPDATELoansPa()
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub UPDATELoansPa()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.DataGridView1.Rows.Count > 0 Then
                For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                    Dim row As DataGridViewRow = Me.DataGridView1.Rows(i)
                    If row.IsNewRow Then Continue For 'حتى لا يتم السطر الجديد الفارغ
                    'If Not System.Convert.IsDBNull(Me.DataGridView1("Loa6", i).Value) Then
                    'If Me.DataGridView1.Rows(i).Cells("Loa6").Value = Me.TextBox15.Text Then
                    '    ppp = "تم التسديد"
                    'ElseIf Me.DataGridView1.Rows(i).Cells("Loa6").Value < Me.TextBox15.Text Then
                    '    ppp = "لم يسدد كامل الاقسط"
                    'ElseIf Me.DataGridView1.Rows(i).Cells("Loa6").Value = "" Then
                    '    ppp = "لم يتم التسديد"
                    'End If
                    Dim PA As String = "PA" & "/" & Me.TextContractNumber.EditValue
                    Dim SQL As New SqlCommand(" UPDATE LoansPa SET Lo = @Lo, Loa = @Loa, Loa2 = @Loa2, Loa3 = @Loa3, Loa6 = @Loa6, Loa7 = @Loa7, Loa8 = @Loa8, Loa9 = @Loa9, Loa10 = @Loa10, Loa11 = @Loa11, Lo25 = @Lo25, CB1 = @CB1, USERNAME = @USERNAME, CUser = @CUser, COUser = @COUser WHERE Loa1 = '" & Me.DataGridView1.Rows(i).Cells("Loa1").Value & "'", Consum)


<<<<<<< HEAD
                    Dim CMD As New SqlCommand With {
=======
                    Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .CommandType = CommandType.Text,
                        .Connection = Consum
                    }
                    With CMD
                        .CommandType = CommandType.Text
                        .Connection = Consum
<<<<<<< HEAD
                        .Parameters.Add("@Lo", SqlDbType.BigInt).Value = Me.TextContractNumber.EditValue
=======
                        .Parameters.Add("@Lo", SqlDbType.BigInt).Value = Val(Me.TextContractNumber.EditValue)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .Parameters.Add("@Loa", SqlDbType.Int).Value = Me.DataGridView1.Rows(i).Cells(0).Value
                        .Parameters.Add("@Loa2", SqlDbType.Date).Value = Me.DataGridView1.Rows(i).Cells("Loa2").Value
                        .Parameters.Add("@Loa3", SqlDbType.NVarChar).Value = Me.DataGridView1.Rows(i).Cells("Loa3").Value
                        .Parameters.Add("@Loa6", SqlDbType.Float).Value = Me.DataGridView1.Rows(i).Cells("Loa6").Value
                        .Parameters.Add("@Loa7", SqlDbType.Float).Value = Me.TextMonthlyInstallment.Text
                        .Parameters.Add("@Loa8", SqlDbType.Float).Value = Me.DataGridView1.Rows(i).Cells("Loa8").Value
                        .Parameters.Add("@Loa9", SqlDbType.Float).Value = Me.TextNetDebt.Text
<<<<<<< HEAD
                        .Parameters.Add("@Loa10", SqlDbType.BigInt).Value = Me.TextCustomerNumber.EditValue
=======
                        .Parameters.Add("@Loa10", SqlDbType.Int).Value = Me.TextCustomerNumber.EditValue
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .Parameters.Add("@Loa11", SqlDbType.NVarChar).Value = Me.ComboCustomerName.Text
                        .Parameters.Add("@Lo25", SqlDbType.NVarChar).Value = PA.ToString & "/" & Me.DataGridView1.Rows(i).Cells(0).Value
                        .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
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
                    'End If
                Next
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error100", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
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

    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs)
        AutoComplete(Me.ComboSponsorName, e, )
    End Sub

    Private Sub TextBox4_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TEXTStatement.KeyPress
=======
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboSponsorName, e, )
    End Sub
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

    Private Sub ButtonDivision_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonDivision.Click
=======
    Private Sub ButtonDivision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonDivision.Click
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
            If Year(Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")) > FiscalYear_currentDateMustBeInFiscalYear() Then
                MsgBox("عفوا .. السنة المحاسبية غير صحيحة فلا يمكن المقارنة", 16, "تنبيه")
                Exit Sub
            End If
            If OBCHK2 = False Then
                If Me.CheckTransferAccounts.Checked = True Then
                    MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
                    Exit Sub
                End If
            End If

<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim strsq1 As New SqlCommand("SELECT *  FROM LoansPa  WHERE Lo='" & Me.DataGridView1.Rows(0).Cells(1).Value & "'", Consum)
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
                Me.TextDebtNumber.Focus()
                Me.ButtonDivision.Enabled = False
                Exit Sub
            Else
                Me.TextPreviousPayments.Text = Val(ppp)
                Dim counter As Integer = Integer.Parse(Me.TextTotalDebtA.Text)
                Dim day = Me.DateMovementHistory.Value.Day
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
                Dim a As Int64 = Me.TextDebtNumber.Text
=======
                Dim a As Integer = Me.TextDebtNumber.Text
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                Dim s = ""
                Dim PA As String = "PA" & "/" & Me.TextContractNumber.EditValue
                Dim Residual1 As Double = 0
                Dim Remaind As Double = Val(Me.TextNetDebt.Text) - Val(Me.TextPreviousPayments.Text)
                Me.TextTotalDebtA.Text = GetNoOfInstallments(Val(Remaind - 1), Val(Me.TextMonthlyInstallment.Text))
                Dim PaidPremiums As Double = Val(Me.TextTotalDebtA.Text) * Val(Me.TextMonthlyInstallment.Text)
                Residual1 = Val(Remaind) - Val(PaidPremiums)
                Remainder = GetRemainder(Val(Me.TextNetDebt.Text), Val(Me.TextTotalDebtA.Text))
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
                    Me.DataGridView2.Rows.Add(0, 0, month.ToString + "-" + year.ToString, p1.Trim.ToLower, Me.TextContractNumber.EditValue, Val(Me.TextPreviousPayments.Text), Val(Remaind), Me.TextMovementSymbol.EditValue, True)
                End If
                For I As Integer = 1 To Val(Me.TextTotalDebtA.Text)
                    Me.DataGridView2.Rows.Add(I, Me.TextMonthlyInstallment.Text, month.ToString + "-" + year.ToString, p.Trim.ToLower, Me.TextContractNumber.EditValue, "0.00", Val(Remaind), Me.TextMovementSymbol.EditValue, False)
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

                Me.DataGridView2.Rows.Add(Val(Me.TextTotalDebtA.Text) + 1, Val(Residual1), month.ToString + "-" + year.ToString, p.Trim.ToLower, Me.TextContractNumber.EditValue, "0.00", Val(Remaind), Me.TextMovementSymbol.EditValue, False)
                Me.Load_Click(sender, e)
                Dim x

                For x = 0 To Me.DataGridView2.Rows.Count - 2
                    Dim row As DataGridViewRow = Me.DataGridView2.Rows(x)
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
                Next
                Me.DataGridView2.Rows.Clear()
                Me.UPDATELoans()
                Me.UPDATELoansPa()
                Me.RecordCount()
                Me.Load_Click(sender, e)
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
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
=======
    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        For u = 0 To DataGridView1.Rows.Count - 1
            If Me.DataGridView1.Rows(u).Cells("Loa3").Value.ToString.Contains("تم التسديد مجموع دفعات سابقة") Then
                Me.DataGridView1.Rows(u).DefaultCellStyle.BackColor = Color.Red
                b = True
                Exit For
            End If
        Next
    End Sub
<<<<<<< HEAD

    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
=======
    Private Sub DataGridView1_CellValidating(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellValidatingEventArgs) Handles DataGridView1.CellValidating
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.DataGridView1.Item(e.ColumnIndex, e.RowIndex).EditedFormattedValue <> Nothing Then
                Dim v As Integer = Me.DataGridView1.Item(0, e.RowIndex).EditedFormattedValue
                For Each row As DataGridViewRow In Me.DataGridView1.Rows
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
        Dim SqlConnection2 As New SqlConnection
        Dim f As New CustomerPay
        Dim Consum As New SqlConnection(constring)
=======

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim SqlConnection2 As New SqlClient.SqlConnection
        Dim f As New CustomerPay
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim LOX As String
        b = False
        Try
            LOX = Nothing
            Me.DataGridView1.ClearSelection()
            LOX = Me.DataGridView1.Item("Loa3", e.RowIndex).EditedFormattedValue
            If LOX = "تم التسديد مجموع دفعات سابقة" Then
                For u = 0 To DataGridView1.Rows.Count - 1
                    If DataGridView1.Rows(u).Cells("Loa3").Value.ToString.Contains("تم التسديد مجموع دفعات سابقة") Then
                        DataGridView1.Rows(u).DefaultCellStyle.BackColor = Color.Red
                        b = True
                        Exit For
                    End If
                Next
                b = True
            End If

            If b = True Then
                MsgBox("لا يمكن تعديل هذا الصف")
                Exit Sub
            Else
                ds.EnforceConstraints = False
                Dim str As New SqlCommand("SELECT Loa1 FROM LoansPa  WHERE   CUser ='" & CUser & "' AND Lo='" & Me.TextContractNumber.EditValue & "'", Consum)
<<<<<<< HEAD
                SqlDataAdapter1 = New SqlDataAdapter(str)
=======
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "LoansPa")
                f.BS.DataMember = "LoansPa"
                f.BS.DataSource = ds
                Dim index As Integer
                index = f.BS.Find(NameOf(Loa1), Me.DataGridView1.CurrentRow.Cells("Loa1").Value)
                f.TB1 = Trim(Me.DataGridView1.CurrentRow.Cells("Loa1").Value)

                f.Show()

                f.TextContractNumber.Text = Me.TextContractNumber.EditValue
                f.TextCustomerName.Text = Me.ComboCustomerName.Text
                f.TextDebtNumber.Text = Me.TextDebtNumber.Text
                f.DatePayment.Text = MaxDate.ToString("yyyy-MM-dd")
                f.TextContractNumber.Text = Me.DataGridView1.CurrentRow.Cells("Loa").Value.ToString.Trim
                'f.TextBox3.Text = Me.TextBox15.Text.Trim
                f.TextNetDebt.Text = Me.DataGridView1.CurrentRow.Cells("Loa8").Value.ToString.Trim - Me.TextMonthlyInstallment.Text.Trim
                f.TextMonthlyInstallment.Focus()
                f.BS.Position = index
            End If
            '    Next intcolmn
            'Next intcount
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD

    Private Sub SumAmounBALANCE()
        Dim Adp As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======
    Private Sub SumAmounBALANCE()
        Dim Adp As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Dim SUM1 As Double
        Dim SUM2 As Double
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim strsql As New SqlCommand("SELECT Sum(Loa6)  FROM LoansPa WHERE Lo ='" & Me.TextContractNumber.EditValue & "'", Consum)
        Dim ds As New DataSet
<<<<<<< HEAD
        Adp = New SqlDataAdapter(strsql)
=======
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextTextNetDebtA.Text = Format(Val(ds.Tables(0).Rows(0).Item(0)) - Me.TextMonthlyInstallment.Text, "0.000")
            SUM1 = Format(Val(ds.Tables(0).Rows(0).Item(0)), "#,#0.00")
        Else
            Me.TextTextNetDebtA.Text = "0"
            SUM1 = "0"
        End If
        Adp.Dispose()
        Consum.Close()
        If Val(SUM1) = Val(Me.TextNetDebt.Text) Then
            Me.DataGridView1.Enabled = False
        End If


    End Sub
<<<<<<< HEAD

    Private Sub ButtonAttachDocument_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAttachDocument.Click
        Try
=======
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAttachDocument.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD
            Dim XLO As Int64
            XLO = Me.DataGridView3.RowCount
            Dim f As New FrmJPG0
            f.Show()
=======
           Dim XLO As Int64
            XLO = Me.DataGridView3.RowCount
            Dim f As New FrmJPG0
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.ADDBUTTON.Enabled = False
            f.SAVEBUTTON.Enabled = True
            f.ButScan.Enabled = True
            f.ButSaveFile.Enabled = False
            f.ButLogq.Enabled = True
            f.ButEditImage.Enabled = False
<<<<<<< HEAD
            f.BS.EndEdit()
            f.BS.AddNew()
            f.MAXRECORD()
=======
            f.Show()
            f.ADDBUTTON_Click(sender, e)
            f.BS.Position = BS.Count - 1
            f.BS.EndEdit()
            f.BS.AddNew()
            CLEARDATA1(Me)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.DateP1.Text = ServerDateTime.ToString("yyyy-MM-dd")
            f.TextLO.Text = Me.TextMovementSymbol.EditValue
            f.TEXTFileNo.Text = Val(XLO) + 1
            f.TEXTFileSubject.Text = "ضمانات القروض"
            f.TextFileDescription.Text = ""
            f.PictureBox1.Image = Nothing
<<<<<<< HEAD
=======

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            f.TEXTBOX1.Enabled = False
            f.TextLO.Enabled = False
            f.TEXTFileNo.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewDocuments.Click
=======
    Private Sub CMDBROWSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewDocuments.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim ds As New DataSet
<<<<<<< HEAD
            Dim SqlDataAdapter1 As New SqlDataAdapter
=======
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            'Dim str As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT * FROM MYDOCUMENTSHOME WHERE  CUser='" & CUser & "'", Consum)
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Strings.Trim(Me.TextDOC1.Text), "'"}), Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextDOC1.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.Show()
                f.TEXTBOX1.Text = Strings.Trim(Me.TextDOC1.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
=======
    Private Sub DataGridView3_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView3.CellEnter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.TextDOC1.Text = CDbl(Me.DataGridView3("DOC1", Me.DataGridView3.CurrentRow.Index).Value)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
<<<<<<< HEAD

    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles DataGridView3.DoubleClick
=======
    Private Sub DataGridView3_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView3.DoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If LockPrint = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية معاينة او طباعة السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            Dim Consum As New SqlConnection(ModuleGeneral.constring)
            Dim ds As New DataSet
<<<<<<< HEAD
            Dim SqlDataAdapter1 As New SqlDataAdapter
=======
            Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim f As New FrmJPG
            ds.EnforceConstraints = False
            Consum.Open()
            Dim str As New SqlCommand(String.Concat(New String() {"SELECT DOC1 FROM MYDOCUMENTSHOME WHERE  CUser='", ModuleGeneral.CUser, "' and DOC1 ='", Strings.Trim(Me.TextDOC1.Text), "'"}), Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "MYDOCUMENTSHOME")
            f.BS.DataMember = "MYDOCUMENTSHOME"
            f.BS.DataSource = ds
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            Dim index As Integer
            If ds.Tables(0).Rows(0).Item("DOC1") = Me.TextDOC1.Text Then
                index = f.BS.Find(NameOf(DOC1), Me.TextDOC1.Text)
                f.Show()
                f.TEXTBOX1.Text = Strings.Trim(Me.TextDOC1.Text)
                f.FrmJPG_Load(sender, e)
                f.DanLOd()
                f.BS.Position = index
                f.RecordCount()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlDataAdapter
        Dim Consum As New SqlConnection(constring)
=======




    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboDebitAccount.SelectedIndexChanged
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        Dim strsql2 As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & Me.ComboDebitAccount.Text & " '", Consum)
<<<<<<< HEAD
        Consum = New SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlDataAdapter(strsql2)
=======
        Consum = New SqlClient.SqlConnection(constring)
        Dim ds2 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsql2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds2.Clear()
        Adp1.Fill(ds2, "ACCOUNTSTREE")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.account_noF = ds2.Tables(0).Rows(0).Item(0)
            Me.ACCF = ds2.Tables(0).Rows(0).Item(2)
            Me.account_nameF = ds2.Tables(0).Rows(0).Item(1)
        Else
            Me.account_noF = ""
            Me.ACCF = ""
            Me.account_nameF = ""
        End If
        Consum.Close()
        Me.TextAccount_noF.Text = Me.account_noF.ToString.Trim
        Me.TextAccount_nameF.Text = Me.account_nameF.ToString.Trim

    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "عقد بيع اجل رقم(قرض)" & " " & ":" & " " & Me.TextDebtNumber.Text & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "للعميل" & " " & ":" & " " & Me.ComboCustomerName.Text & " " & "مثبتة بوثيقة رقم" & " " & ":" & " " & Me.TextDebtNumber.Text & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub

<<<<<<< HEAD
    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlConnection(constring)
=======


    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub DELETEDATMOVESDATA1()
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub DELETEDATMOVESDATA1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub DELETEDATMOVESDATA2()
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub DELETEDATMOVESDATA2()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions1, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub DELETEDATMOVESDATA3()
        Try
            Dim Consum As New SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.TextMovementRestrictions1, Me.BS, True)
=======
    Private Sub DELETEDATMOVESDATA3()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESTrueDELET, Me.BS, True)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod.Text = "نقدا_شيك" Or Me.ComboNumberOfYears.Text = "نقدا_شيك_ذمم_دائنة" Then
                Connection.ACONET1.Add("الصندوق")
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextDebitAccount.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextDebitAccount.Text}))
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

    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts.Click
=======
    Private Sub ButtonCUSTOMER1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Me.BS.Count = 0 Then Beep() : Exit Sub

            If CheckRecordingAmountOfDebtAndPurchases.Checked = True Then
                MessageBox.Show("تنبيه. قيد تسجيل ميلغ الدين و المشتريات   مرحل" & ControlChars.CrLf &
                            "1) الغاء ترحيل  تسجيل ميلغ الدين و المشتريات " & ControlChars.CrLf &
                            "2) قم بترحيل الى الحســـــــابات ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ButtonTransferofAccounts.Enabled = False
                Exit Sub
            End If

            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If

<<<<<<< HEAD
            Me.Button1_Click(sender, e)
            SEARCHDATA.MaxIDMoves()
=======

            Me.Button1_Click(sender, e)
            SEARCHDATA.MAXIDMOVES()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")

            Dim resault As Integer
            Static Dim P As Integer
            If OBCHK2 = True Then
                If Me.CheckTransferAccounts.Checked = False Then
                    resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة القيود اليومية " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.DELETEDATRECORD()
                        Me.CheckTransferAccounts.Checked = True
                        TransforAccounts()
<<<<<<< HEAD
                        Insert_Actions(Me.TextDebtNumber.Text, "ترحيل االى حركة القيود اليومية", Me.Text)
=======
                        Insert_Actions(Me.TextDebtNumber.Text.Trim, "ترحيل االى حركة القيود اليومية", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions.Text = "" Then
                            MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                        End If
                        If Me.TextFundMovementNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                        Else
                            Me.DELETEDATAempsolf()
                        End If
                        Me.DELETEDATRECORD()
                        TransforAccounts()
<<<<<<< HEAD
                        Insert_Actions(Me.TextDebtNumber.Text, "تعديل ترحيل الحركة الى القيود اليومية", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            TransferAccounts = False
                            Me.CheckTransferAccounts.Checked = False
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
=======
                        Insert_Actions(Me.TextDebtNumber.Text.Trim, "تعديل ترحيل الحركة الى القيود اليومية", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.CheckTransferAccounts.Checked = False
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else

                If Me.TextFirstBatch.EditValue = "0" Then
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة القيود اليومية " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
<<<<<<< HEAD
                            Insert_Actions(Me.TextDebtNumber.Text, "ترحيل االى حركة القيود اليومية", Me.Text)
=======
                            Insert_Actions(Me.TextDebtNumber.Text.Trim, "ترحيل االى حركة القيود اليومية", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            TransforAccounts()
<<<<<<< HEAD
                            Insert_Actions(Me.TextDebtNumber.Text, "تعديل ترحيل الحركة الى القيود اليومية", Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                TransferAccounts = False
                                Me.CheckTransferAccounts.Checked = False
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
=======
                            Insert_Actions(Me.TextDebtNumber.Text.Trim, "تعديل ترحيل الحركة الى القيود اليومية", Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferAccounts.Checked = False
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                Else
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة القيود اليومية و الصندوق " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            TransforAccounts()
<<<<<<< HEAD
                            Insert_Actions(Me.TextDebtNumber.Text, "ترحيل االى حركة القيود اليومية و الصندوق", Me.Text)
=======
                            Insert_Actions(Me.TextDebtNumber.Text.Trim, "ترحيل االى حركة القيود اليومية و الصندوق", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    Else
                        resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            If Me.TextMovementRestrictions.Text = "" Then
                                MsgBox("لايوجد سجلات في القيود", 16, "تنبية")
                            Else
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                            End If
                            If Me.TextFundMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الصندوق", 16, "تنبية")
                            Else
                                Me.DELETEDATAempsolf()
                            End If
                            TransforAccounts()
<<<<<<< HEAD
                            Insert_Actions(Me.TextDebtNumber.Text, "تعديل ترحيل الحركة الى القيود اليومية و الصندوق", Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية و الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                TransferAccounts = False
=======
                            Insert_Actions(Me.TextDebtNumber.Text.Trim, "تعديل ترحيل الحركة الى القيود اليومية و الصندوق", Me.Text)
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية و الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                                Me.CheckTransferAccounts.Checked = False
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATAempsolf()
<<<<<<< HEAD
                                Insert_Actions(Me.TextDebtNumber.Text, "حذف ترحيل الحركة الى القيود اليومية و الصندوق", Me.Text)
=======
                                Insert_Actions(Me.TextDebtNumber.Text.Trim, "حذف ترحيل الحركة الى القيود اليومية و الصندوق", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            P = Me.BS.Position
<<<<<<< HEAD
            If TransferAccounts = False Then
                Me.CheckTransferAccounts.Checked = False
            End If
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.UPDATELoans()
            Me.UPDATELoansPa()
            Me.RecordCount()
            Me.Load_Click(sender, e)
            Me.BS.Position = P
<<<<<<< HEAD
            If TransferAccounts = False Then
                Me.CheckTransferAccounts.Checked = False
            End If
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.UPDATELoans()
            Me.UPDATELoansPa()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.PictureBox2.Visible = True
<<<<<<< HEAD
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
<<<<<<< HEAD


    End Sub


    Private Sub DELETEDATAempsolf()
        Try
            Dim Consum As New SqlConnection(constring)
=======
    End Sub



    Private Sub DELETEDATAempsolf()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub DELETEDATAempsolf1()
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub DELETEDATAempsolf1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber1, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

    Private Sub DELETEDATBANK()
        Try
            Dim Consum As New SqlConnection(constring)
=======
    Private Sub DELETEDATBANK()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            ModuleGeneral.MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.PRINTBUTTON.Enabled = LockPrint
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        'Me.ButtonXP1.Enabled = LockUpdate
        Me.ButtonAddSponsor.Enabled = LockUpdate
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonTransferofAccounts1.Enabled = TransferofAccounts
        Me.SAVEBUTTON.Enabled = LockUpdate
        Me.ButtonAttachDocument.Enabled = LockUpdate
        Me.ButtonViewDocuments.Enabled = LockPrint
        Me.BUTTONCANCEL.Enabled = True
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonDivision.Enabled = False
            Me.ButtonAddSponsor.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferofAccounts1.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.TextDebtNumber.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.TextMiligDebt.Enabled = False
            Me.TextProfitRatio.Enabled = False
            Me.ComboNumberOfYears.Enabled = False
            Me.TextFirstBatch.Enabled = False
            Me.ComboSponsorName.Enabled = False
            Me.GroupBox3.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.DataGridView4.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False
        ElseIf Me.CheckTransferAccounts.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonAddSponsor.Enabled = True
            Me.ButtonTransferofAccounts.Enabled = True
            Me.ButtonTransferofAccounts1.Enabled = True
            Me.ButtonAttachDocument.Enabled = True

            'Me.Text1.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.TextMiligDebt.Enabled = True
            Me.TextProfitRatio.Enabled = True
            Me.ComboNumberOfYears.Enabled = True
            Me.TextFirstBatch.Enabled = True
            Me.ComboSponsorName.Enabled = True
        ElseIf Me.CheckTransferAccounts.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.PRINTBUTTON.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonDivision.Enabled = False
            Me.ButtonAddSponsor.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferofAccounts1.Enabled = False
            Me.ButtonAttachDocument.Enabled = False

            Me.TextDebtNumber.Enabled = False
            Me.ComboCustomerName.Enabled = False
            Me.DateMovementHistory.Enabled = False
            Me.TEXTStatement.Enabled = False
            Me.TextMiligDebt.Enabled = False
            Me.TextProfitRatio.Enabled = False
            Me.ComboNumberOfYears.Enabled = False
            Me.TextFirstBatch.Enabled = False
            Me.ComboSponsorName.Enabled = False
            Me.GroupBox3.Enabled = False
            Me.GroupBox2.Enabled = False
            Me.DataGridView4.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            'Me.Text1.Enabled = True
            Me.ComboCustomerName.Enabled = True
            Me.DateMovementHistory.Enabled = True
            Me.TEXTStatement.Enabled = True
            Me.TextMiligDebt.Enabled = True
            Me.TextProfitRatio.Enabled = True
            Me.ComboNumberOfYears.Enabled = True
            Me.TextFirstBatch.Enabled = True
            Me.ComboSponsorName.Enabled = True
            Me.DataGridView4.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.PanelAccount.Enabled = True
        End If
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
        If Me.BS.Count = 0 Then Beep() : Exit Sub
        If InternalAuditor = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية مراجعة السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATELoans()
        Me.RecordCount()
        Me.Load_Click(sender, e)
        Me.BS.Position = P
<<<<<<< HEAD
        Insert_Actions(Me.TextDebtNumber.Text, "المراجع", Me.Text)
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
=======
        Insert_Actions(Me.TextDebtNumber.Text.Trim, "المراجع", Me.Text)
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
        If Me.CheckLogReview.Checked = False Then
            MsgBox("عفوا .. هذا السجل غير مراجع ", 16, "تنبيه")
            Exit Sub
        End If
        Static Dim P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = False
        Me.TEXTReferenceName.Text = USERNAME
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.UPDATELoans()
        Me.RecordCount()
        Me.Load_Click(sender, e)
        Me.UPDATELoans()
        Me.BS.Position = P
<<<<<<< HEAD
        Insert_Actions(Me.TextDebtNumber.Text, "إلغاء المراجع", Me.Text)
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub

    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PB1.Click
=======
        Insert_Actions(Me.TextDebtNumber.Text.Trim, "إلغاء المراجع", Me.Text)
        MsgBox("تمت عملية إلغاء المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
    End Sub
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
<<<<<<< HEAD

    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PB2.Click
=======
    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PB2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        LS2 = True
        Me.PanelAccount_Name.Visible = True
        Me.List2.Visible = True
    End Sub
<<<<<<< HEAD

    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List1.MouseDoubleClick
=======
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List1.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextDebitAccount.Text = Me.List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
<<<<<<< HEAD

    Private Sub List2_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles List2.MouseDoubleClick
=======
    Private Sub List2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List2.MouseDoubleClick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextCreditAccount.Text = Me.List2.SelectedItem(0).ToString
        LS2 = False
        Me.PanelAccount_Name.Visible = False
        Me.List2.Visible = False
    End Sub
<<<<<<< HEAD

    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpComboDebitAccount.ValueChanged
        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub

    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpDebitAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpDebitAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub

    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List2.DataSource = GetData(NUpCreditAccount.Value)
        Me.List2.DisplayMember = "account_name"
    End Sub

=======
    Private Sub NumericUpDown1_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpDebitAccount.ValueChanged
        Me.List1.DataSource = GetData(NUpDebitAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged
        Me.List2.DataSource = GetData(NUpCreditAccount.Value)
        Me.List2.DisplayMember = "account_name"
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpDebitAccount.Value)
            Me.List1.DisplayMember = "account_name"
        ElseIf LS2 = True Then
            Me.List2.DataSource = GetData(NUpCreditAccount.Value)
            Me.List2.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
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
<<<<<<< HEAD

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmBanks5
        Try
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub
<<<<<<< HEAD

    Private Sub ButtonTransferofAccounts1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonTransferofAccounts1.Click
=======
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS.Count = 0 Then Beep() : Exit Sub
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If

            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Me.List1.Visible = True
                Exit Sub
            End If
            If Me.CheckTransferAccounts.Checked = False Then
                MsgBox("عفوا .. يجب ترحيل اولا الى الحســـــــابات اولا ", 16, "تنبيه")
                Exit Sub
            End If
            Me.FundBalance()
            If Val(Me.TextMiligDebt.EditValue) <> (Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue) + Val(Me.TextAccountsPayableValue.EditValue)) Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى ميلغ الدين", 16, "تنبيه")
                Exit Sub
            End If
            Dim ch As Double = "0.00"
            Dim ch1 As Double = "0.00"
            ch = Me.TextFundValue.EditValue
            ch1 = Me.TextFundBalance.Text
            If ch1 < ch Then
                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                Exit Sub
            End If
            Me.Button1_Click(sender, e)

            SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
            SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
            Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Dim resault As Integer
            If Me.ComboPaymentMethod.Text.Trim = "نقدا" Then
                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("  سبنم ترحيل السجل الحالى الى حركة القيود اليومية " & "للعميل " & Me.ComboCustomerName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "ترحيل االى حركة الصندوق و القيود اليومية", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "ترحيل االى حركة الصندوق و القيود اليومية", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا" & " " & "هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "تعديل ترحيل  حركة الصندوق و القيود اليومية", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()

                            Insert_Actions(CInt(Me.TextDebtNumber.Text), "حذف ترحيل حركة الصندوق و القيود اليومية", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  حركة الصندوق و القيود اليومية", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة الصندوق و القيود اليومية", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text.Trim = "شيك" Then
                If Me.ComboCheckDrawerName.Text = "" Then
                    MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                    Me.ComboCheckDrawerName.Focus()
                    Exit Sub
                End If
                If Me.TextCheckNumber.Text = "" Then
                    MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                    Me.TextCheckNumber.Focus()
                    Exit Sub
                End If
                If Me.CheckDate.Value = Nothing Then
                    MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                    Me.CheckDate.Focus()
                    Exit Sub
                End If

                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم ", "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), " ترحيل  الى القيود اليومية و الشيكات رفم", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), " ترحيل  الى القيود اليومية و الشيكات رفم", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية و الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Me.DELETEDATBANK()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Insert_Actions(CInt(Me.TextDebtNumber.Text), "حذف ترحيل حركة القيود اليومية و الشيكات رقم", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية و الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATBANK()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة القيود اليومية و الشيكات رقم", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text.Trim = "نقدا_شيك" Then
                If Me.ComboCheckDrawerName.Text = "" Then
                    MsgBox("يجب إدخال اسم ساحب الشيك", 16, "تنبيه")
                    Me.ComboCheckDrawerName.Focus()
                    Exit Sub
                End If
                If Me.TextCheckNumber.Text = "" Then
                    MsgBox("يجب إدخال رقم الشيك", 16, "تنبيه")
                    Me.TextCheckNumber.Focus()
                    Exit Sub
                End If
                If Me.CheckDate.Value = Nothing Then
                    MsgBox("يجب إدخال تاريخ الشيك", 16, "تنبيه")
                    Me.CheckDate.Focus()
                    Exit Sub
                End If
                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم ", "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            Me.DELETEDATBANK()
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
<<<<<<< HEAD
                            Insert_Actions(CInt(Me.TextDebtNumber.Text), "حذف ترحيل حركة القيود اليومية و الصندزق و الشيكات ", Me.Text)
=======
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة القيود اليومية و الصندزق و الشيكات ", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text.Trim = "ذمم_دائنة" Then
                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الموردين رفم " & Me.TEXTUserName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(Me.TextDebtNumber.Text, "تعديل ترحيل  الى القيود اليومية و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
=======
                        Insert_Actions(Me.TextDebtNumber.Text.Trim, "تعديل ترحيل  الى القيود اليومية و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية و الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Insert_Actions(CInt(Me.TextDebtNumber.Text), "حذف ترحيل حركة القيود اليومية و الشيكات رقم", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول حركة القيود اليومية و الصندوق", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة القيود اليومية و الشيكات رقم", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text.Trim = "نقدا_ذمم_دائنة" Then
                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الموردين رفم " & Me.TEXTUserName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "تعديل ترحيل  الى القيود اليومية و الصندزق و الموردين ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  الى القيود اليومية و الصندزق و الموردين ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            Me.DELETEDATBANK()
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
<<<<<<< HEAD
                            Insert_Actions(CInt(Me.TextDebtNumber.Text), "حذف ترحيل حركة القيود اليومية و الصندزق و الشيكات ", Me.Text)
=======
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة القيود اليومية و الصندزق و الشيكات ", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If

<<<<<<< HEAD
=======

>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ElseIf Me.ComboPaymentMethod.Text.Trim = "شيك_ذمم_دائنة" Then
                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات و الموردين رفم " & Me.TEXTUserName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(CInt(Me.TextDebtNumber.Text), "تعديل ترحيل  الى القيود اليومية و الشيكات و الموردين ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  الى القيود اليومية و الشيكات و الموردين ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            Me.DELETEDATBANK()
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
<<<<<<< HEAD
                            Insert_Actions(CInt(Me.TextDebtNumber.Text), "حذف ترحيل حركة القيود اليومية و الشيكات و الموردين ", Me.Text)
=======
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة القيود اليومية و الشيكات و الموردين ", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            ElseIf Me.ComboPaymentMethod.Text.Trim = "نقدا_شيك_ذمم_دائنة" Then
                If Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات و الموردين رفم " & Me.TEXTUserName.Text, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckRecordingAmountOfDebtAndPurchases.Checked = True
                        TransforAccountsPurchases()
<<<<<<< HEAD
                        Insert_Actions(Me.TextDebtNumber.Text, "ترحيل الى القيود اليومية و الصندزق و الشيكات و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
=======
                        Insert_Actions(Me.TextDebtNumber.Text.Trim, "ترحيل الى القيود اليومية و الصندزق و الشيكات و الموردين رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                    Else
                        Exit Sub
                    End If
                Else
                    resault = MessageBox.Show(" تم ترحيل السجل الحالى  سابقا هل تريد تحدبثه ام لا ", "تحديث سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        If Me.TextMovementRestrictions1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في القيود", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                        End If
                        If Me.TextCheckMovementNumber.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الشيكات", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATBANK()
                        End If
                        If Me.TextFundMovementNumber1.Text = "" Then
                            Interaction.MsgBox("لايوجد سجلات في الصندوق", MsgBoxStyle.Critical, "تنبية")
                        Else
                            Me.DELETEDATAempsolf1()
                        End If
                        If Me.TextSupplierTrafficNumber.Text = "" Then
                            MsgBox("لايوجد سجلات في الموردين نقدا", 16, "تنبية")
                        Else
                            Me.DELETEDATACUSTOMER1()
                        End If
                        TransforAccountsPurchases()
                        AccountingprocedureA()
<<<<<<< HEAD
                        Insert_Actions(Me.TextDebtNumber.Text, "تعديل ترحيل  الى القيود اليومية و الصندزق  و الشيكات و الموردين ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول  الصندزق  الشيكات و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            RecordingAmountOfDebtAndPurchases = False
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Me.DELETEDATBANK()
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()

                            Insert_Actions(Me.TextDebtNumber.Text, "حذف ترحيل حركة القيود اليومية و الصندزق  و الشيكات و الموردين ", Me.Text)
=======
                        Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "تعديل ترحيل  الى القيود اليومية و الصندزق  و الشيكات و الموردين ", Me.Text)
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول  الصندزق  الشيكات و الموردين ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATBANK()
                            Me.DELETEDATAempsolf1()
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATACUSTOMER1()
                            Me.DELETEDATMOVESDATA2()
                            Me.DELETEDATMOVESDATA3()
                            Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
                            Insert_Actions(CInt(Me.TextDebtNumber.Text.Trim), "حذف ترحيل حركة القيود اليومية و الصندزق  و الشيكات و الموردين ", Me.Text)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            End If
            P2 = Me.BS.Position
            'Me.UPDATELoans()
            'Me.RecordCount()
<<<<<<< HEAD
            'Me.Load_Click(sender, e)
            Me.BS.Position = P2
            If RecordingAmountOfDebtAndPurchases = False Then
                Me.CheckRecordingAmountOfDebtAndPurchases.Checked = False
            End If
            Me.UPDATELoans()
            Me.BS.EndEdit()

            Me.PictureBox2.Visible = True
            Me.SaveTab = New ComponentModel.BackgroundWorker With {
=======
            'Me.load_Click(sender, e)
            Me.BS.Position = P2
            Me.UPDATELoans()
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.PictureBox2.Visible = True
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub DELETEDATACUSTOMER1()
        On Error Resume Next
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
        Dim sql As String = "DELETE FROM Suppliers1  WHERE CAB8 = '" & Me.TextDebtNumber.Text & "'" & "AND CAB12 ='نقدا'" & " AND CAB18='" & Me.TextMovementSymbol.EditValue & "'"
        Dim cmd As New SqlCommand(sql, Consum)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim sql As String = "DELETE FROM Suppliers1  WHERE CAB8 = '" & Me.TextDebtNumber.Text & "'" & "AND CAB12 ='نقدا'" & " AND CAB18='" & Me.TextMovementSymbol.EditValue & "'"
        Dim cmd As New SqlClient.SqlCommand(sql, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
    End Sub
<<<<<<< HEAD

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.Account_No
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.Account_Name = SEARCHDATA.Account_Name
        SEARCHDATA.MaxIDMoves()
=======
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonViewrestrictions.Click
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TextMAXMOV1.Text = Conversion.Val(SEARCHDATA.MAXMOV1)
        Me.TextMAXMOV2.Text = Conversion.Val(SEARCHDATA.MAXMOV2)
        Me.TextMAXMOV8.Text = Conversion.Val(SEARCHDATA.MAXMOV8)
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C
        SEARCHDATA.SEARCHMOVESTrue(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions1.Text = SEARCHDATA.MOV1B

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET
        SEARCHDATA.SEARCHMOVESTrueDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESTrueDELET.Text = SEARCHDATA.MOV1DELET

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TextDebtNumber.Text)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHCASHIER1(Me.TextMovementSymbol.EditValue, Me.TextDebtNumber.Text)
        Me.TextFundMovementNumber1.Text = SEARCHDATA.CSH1B

        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
        SEARCHDATA.SEARCHCABLES(Me.TextMovementSymbol.EditValue, Me.TextDebtNumber.Text)
        Me.TextCustomerTrafficNumber.Text = SEARCHDATA.IDCAB
        SEARCHDATA.SEARCHCABLES1(Me.TextMovementSymbol.EditValue, Me.TextDebtNumber.Text)
        Me.TextCustomerTrafficNumber1.Text = SEARCHDATA.IDCAB1
        SEARCHDATA.SEARCHDSuppliersA(Me.TextMovementSymbol.EditValue)
        Me.TextSupplierTrafficNumber.Text = SEARCHDATA.IDSuppliesA
    End Sub

<<<<<<< HEAD
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlDataAdapter(strsql)
=======
    Private Sub ComboBox16_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Me.RadioAllCustomers.Checked = True Then
                Dim Adp As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT IDcust,cust22,cust25,cuser,couser  FROM AllCustomers WHERE cust2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds As New DataSet
                Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds.Clear()
                Adp.Fill(ds)
                If ds.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds.Tables(0).Rows(0).Item(0)
                    TypeCustomer = ds.Tables(0).Rows(0).Item(1)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                    TypeCustomer = ""
                End If
                Adp.Dispose()
                Consum.Close()
            ElseIf Me.RadioSUPPLIER.Checked = True Then
<<<<<<< HEAD
                Dim Adp1 As SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlDataAdapter(strsql)
=======
                Dim Adp1 As SqlClient.SqlDataAdapter
                Dim strsql As New SqlCommand("SELECT sup1  FROM SUPPLIER WHERE sup2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds1 As New DataSet
                Adp1 = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                ds1.Clear()
                Adp1.Fill(ds1)
                If ds1.Tables(0).Rows.Count > 0 Then
                    Me.TextCheckDrawerCode.Text = ds1.Tables(0).Rows(0).Item(0)
                Else
                    Me.TextCheckDrawerCode.Text = ""
                End If
                Adp1.Dispose()
                Consum.Close()
            ElseIf Me.RadioEMPLOYEES.Checked = True Then
<<<<<<< HEAD
                Dim Adp2 As SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlDataAdapter(strsq2)
=======
                Dim Adp2 As SqlClient.SqlDataAdapter
                Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
                Dim ds2 As New DataSet
                Adp2 = New SqlClient.SqlDataAdapter(strsq2)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD

    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub

    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub

=======
    Private Sub RadioButton7_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioAllCustomers.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton6_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioSUPPLIER.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioEMPLOYEES.CheckedChanged
        Call Me.AddType1()
    End Sub
    Private Sub RadioButton4_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioResetText.CheckedChanged
        Call Me.AddType1()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub AddType1()
        On Error Resume Next
        If RadioAllCustomers.Checked = True Then
            FILLCOMBOBOX1("AllCustomers", "cust2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioSUPPLIER.Checked = True Then
            FILLCOMBOBOX1("SUPPLIER", "sup2", "CUser", CUser, Me.ComboCheckDrawerName)
        ElseIf RadioEMPLOYEES.Checked = True Then
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)
        Else
            Me.ComboCheckDrawerName.ResetText()
        End If
        Me.ComboCheckDrawerName.Focus()
    End Sub

<<<<<<< HEAD
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCheckMovementNumber.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Checks")
            f.BS.DataMember = "Checks"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCH", Me.TextCheckMovementNumber.Text.Trim)
            f.TB1 = Me.TextCheckMovementNumber.Text.Trim
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
<<<<<<< HEAD

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicFundMovementNumber1.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber1.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmBanks5
        Try
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
            index = f.BS.Find("CSH1", Me.TextFundMovementNumber1.Text.Trim)
            f.TB1 = Me.TextFundMovementNumber1.Text.Trim
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
<<<<<<< HEAD

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCustomerTrafficNumber.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber.Text.Trim)
            f.TB1 = Trim(Me.TextCustomerTrafficNumber.Text)
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
<<<<<<< HEAD

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicCustomerTrafficNumber1.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCustomerTrafficNumber1.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmCUSTOMER1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "CABLES")
            f.BS.DataMember = "CABLES"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextCustomerTrafficNumber1.Text.Trim)
            f.TB1 = Trim(Me.TextCustomerTrafficNumber1.Text)
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

<<<<<<< HEAD
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicSupplierTrafficNumber.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicSupplierTrafficNumber.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmSuppliers1
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCAB FROM Suppliers1 WHERE   CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCAB", Consum)
<<<<<<< HEAD
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder33 As New SqlCommandBuilder(SqlDataAdapter1)
=======
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "Suppliers1")
            f.BS.DataMember = "Suppliers1"
            f.BS.DataSource = ds
            Dim index As Integer
            index = f.BS.Find("IDCAB", Me.TextSupplierTrafficNumber.Text.Trim)
            f.TB1 = Trim(Me.TextSupplierTrafficNumber.Text)
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
<<<<<<< HEAD

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PicMovementRestrictions1.Click
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions1.Click
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        SqlDataAdapter1.Dispose()
        Consum.Close()
    End Sub

    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged, TextAccountsPayableValue.EditValueChanged

        Select Case Me.ComboPaymentMethod.Text
            Case "نقدا"
                TextFundValue.EditValue = Val(TextMiligDebt.EditValue)
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = 0
            Case "شيك"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue)
                TextAccountsPayableValue.EditValue = 0
            Case "نقدا_شيك"
                TextFundValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue) - Val(TextFundValue.EditValue)
                TextAccountsPayableValue.EditValue = 0
            Case "ذمم_دائنة"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue)
            Case "نقدا_ذمم_دائنة"
                TextFundValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextAccountsPayableValue.EditValue)
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextFundValue.EditValue)
            Case "شيك_ذمم_دائنة"
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue) - Val(TextAccountsPayableValue.EditValue)
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextValueOfCheck.EditValue)
            Case "نقدا_شيك_ذمم_دائنة"
                TextFundValue.EditValue = Val(TextMiligDebt.EditValue) - (Val(TextValueOfCheck.EditValue) + Val(TextAccountsPayableValue.EditValue))
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue) - (Val(TextFundValue.EditValue) + Val(TextAccountsPayableValue.EditValue))
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue) - (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue))
        End Select


    End Sub

<<<<<<< HEAD
    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me. AccountsEnquiry()
    End Sub

    Private Sub AccountsEnquiry()
=======

    Private Sub ComboPaymentMethod_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod.SelectedIndexChanged
        On Error Resume Next
        Me. AccountsEnquiry()
    End Sub
    Private Sub  AccountsEnquiry()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing
        AccountsPayableAccount_Name = Nothing
        TestkeyAccounts(keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No)
        End If
        GetPurchSales_Check()
        GetFundAccount_No(ModuleGeneral.CB2)

        GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)

        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        Select Case Me.ComboPaymentMethod.Text
            Case "رصيد سابق"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = False
                Me.TextAccountsPayableValue.Enabled = False
                Me.PB1.Enabled = False
                Me.PB2.Enabled = True
                'Me.LabelDebitAccount1.Text = "حساب دائن"
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = 0
            Case "نقدا"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextAccountsPayableValue.Enabled = False
                Me.PB1.Enabled = False
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False

                TextFundValue.EditValue = Val(TextMiligDebt.EditValue)
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = 0

                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextDebitAccount.Text = FundAccount_Name
                TextCreditAccount.Text = Nothing
                NUpCreditAccount.Value = ChecksAccount_Cod

                NUpDebitAccount.Enabled = True
                NUpCreditAccount.Enabled = False
                PB1.Enabled = True
                PB2.Enabled = False
            Case "شيك"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.TextAccountsPayableValue.Enabled = False
                Me.PB1.Enabled = False
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True

                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue)
                TextAccountsPayableValue.EditValue = 0

                TextDebitAccount.Text = ChecksAccount_Name
                TextCreditAccount.Text = Nothing
                NUpCreditAccount.Value = ChecksAccount_Cod

                NUpDebitAccount.Enabled = True
                NUpCreditAccount.Enabled = False
                PB1.Enabled = True
                PB2.Enabled = False

            Case "نقدا_شيك"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.TextAccountsPayableValue.Enabled = False
                Me.PB1.Enabled = True
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True

                TextFundValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextValueOfCheck.EditValue)
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue) - Val(TextFundValue.EditValue)
                TextAccountsPayableValue.EditValue = 0

                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextDebitAccount.Text = FundAccount_Name
                NUpDebitAccount.Value = CodAccount
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod

                NUpDebitAccount.Enabled = True
                NUpCreditAccount.Enabled = True
                PB1.Enabled = True
                PB2.Enabled = True
            Case "ذمم_دائنة"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = False
                Me.TextAccountsPayableValue.Enabled = True
                Me.PB1.Enabled = False
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False

                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue)
                TextDebitAccount.Text = "حساب فارغ"
                NUpDebitAccount.Value = Nothing
                TextCreditAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount.Value = PayableAccount_Cod
                NUpDebitAccount.Enabled = False
                NUpCreditAccount.Enabled = True
                PB1.Enabled = False
                PB2.Enabled = True
            Case "نقدا_ذمم_دائنة"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.TextAccountsPayableValue.Enabled = True
                Me.PB1.Enabled = True
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                TextFundValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextAccountsPayableValue.EditValue)
                TextValueOfCheck.EditValue = 0
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextFundValue.EditValue)

                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextDebitAccount.Text = FundAccount_Name
                NUpDebitAccount.Value = CodAccount
                TextCreditAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount.Value = PayableAccount_Cod
                NUpDebitAccount.Enabled = True
                NUpCreditAccount.Enabled = True
                PB1.Enabled = True
                PB2.Enabled = True
            Case "شيك_ذمم_دائنة"
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.TextAccountsPayableValue.Enabled = True
                Me.PB1.Enabled = True
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True

                TextFundValue.EditValue = 0
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue) - Val(TextAccountsPayableValue.EditValue)
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue) - Val(TextValueOfCheck.EditValue)

                TextDebitAccount.Text = ChecksAccount_Name
                NUpDebitAccount.Value = ChecksAccount_Cod
                TextCreditAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount.Value = PayableAccount_Cod
                NUpDebitAccount.Enabled = True
                NUpCreditAccount.Enabled = True
                PB1.Enabled = True
                PB2.Enabled = True
            Case "نقدا_شيك_ذمم_دائنة"
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.TextAccountsPayableValue.Enabled = True
                Me.PB1.Enabled = True
                Me.PB2.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                TextFundValue.EditValue = Val(TextMiligDebt.EditValue) - (Val(TextValueOfCheck.EditValue) + Val(TextAccountsPayableValue.EditValue))
                TextValueOfCheck.EditValue = Val(TextMiligDebt.EditValue) - (Val(TextFundValue.EditValue) + Val(TextAccountsPayableValue.EditValue))
                TextAccountsPayableValue.EditValue = Val(TextMiligDebt.EditValue) - (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue))

                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextDebitAccount.Text = ChecksAccount_Name
                NUpDebitAccount.Value = ChecksAccount_Cod
                TextCreditAccount.Text = AccountsPayableAccount_Name
                NUpCreditAccount.Value = PayableAccount_Cod
                NUpDebitAccount.Enabled = True
                NUpCreditAccount.Enabled = True
                PB1.Enabled = True
                PB2.Enabled = True
        End Select

    End Sub

    Private Sub OptionsTransforAccountMe()



        GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
        DebitAccount_No = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
        DebitAccount_Cod = ID_Nam

        If TextDebitAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextDebitAccount.Text, 1)
            ChecksAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextDebitAccount.Text, 1)
            ChecksAccount_Cod = ID_Nam
        End If

        If TextCreditAccount.Text <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount.Text, 1)
            PayableAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCreditAccount.Text, 1)
            PayableAccount_Cod = ID_Nam
        End If




    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                If ComboPaymentMethod.Text = Nothing Then
                    ComboPaymentMethod.Text = "رصيد سابق"
                End If
                Me.OptionsTransforAccountMe()
                'OptionsTransforAccounts(ComboPaymentMethod.Text, ComboDebitAccount.Text, TextDebitAccount.Text, TextCreditAccount.Text)
                PanelAccount.Enabled = True
            Else
                Check_OptionsTransforAccounts.Checked = False
                PanelAccount.Enabled = False
            End If
        Else
            PanelAccount.Enabled = False
        End If
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
        Accounts_NO = FundAccount_No
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

        Dim x As Double = Val(Me.TextTotalDebt.Text) - Val(Me.TextTotalPayments.Text)


        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, TextNetDebt.Text, TextNetDebt.Text, T3, "قيد", "LO", TextMovementSymbol.EditValue, False)

        If OBCHK2 = True Then
            DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(x), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
            DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, CredAccount_NO, 0, Val(x), nem1, CredAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
        Else
            If Me.TextFirstBatch.EditValue = 0 Then
                DetailsAccountingEntries(PMO2, DebitAccount_Name, DebitAccount_No, Val(x), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, CredAccount_Name, Accounts_NO, 0, Val(x), nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
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




>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub TransforAccountsPurchases()
        Try
            nem = "مشتريات للحساب القرض رقم_" & Me.TextDebtNumber.Text
            nem1 = "صرف نقدي مشتريات رقم_" & Me.TextDebtNumber.Text
            nem2 = "مشتريات بيموجب مستند رقم _" & Me.TextCheckNumber.Text
            nem3 = " فاتورة مشتريات ذمم دائنة "
            PMO2 = 1
            Dim PaymentMethod As String
            If ComboPaymentMethod.Text = "نقدا" Then
                PaymentMethod = "نقدا"
            ElseIf ComboPaymentMethod.Text = "شيك" Then
                PaymentMethod = "شيك"
            ElseIf ComboPaymentMethod.Text = "نقدا_شيك" Then
                PaymentMethod = "نقدا_شيك"
            ElseIf ComboPaymentMethod.Text = "ذمم_دائنة" Then
                PaymentMethod = "نقدا"
            ElseIf ComboPaymentMethod.Text = "نقدا_ذمم_دائنة" Then
                PaymentMethod = "نقدا"
            Else
                PaymentMethod = "نقدا_شيك"
            End If
            DebitAccount_Name = Nothing
            CredAccount_Name = Nothing
            FundAccount_Name = Nothing
            ChecksAccount_Name = Nothing
            TestkeyAccounts(keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("PurchasesAccount_No", PurchasesAccount_No)
            End If

            GetPurchSales_Check()

            GetFundAccount_No(ModuleGeneral.CB2)
            Accounts_NO = FundAccount_No


            GetUpAccounts(ComboPaymentMethod.Text, AccountNoAktevd)
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
            CodAccount = ID_Nam

            SEARCHDATA.MAXIDMOVES()
            AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), LabelAutoEx.Text, True, TextMiligDebt.Text, TextMiligDebt.Text, T3, "قيد", "LO", TextMovementSymbol.EditValue, False)

            If ComboPaymentMethod.Text.Trim = "نقدا" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)

                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TextDebtNumber.Text, False, True, ComboCB1.Text, ModuleGeneral.CB2)

            ElseIf ComboPaymentMethod.Text.Trim = "شيك" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, TextDebitAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)

                Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

            ElseIf ComboPaymentMethod.Text.Trim = "نقدا_شيك" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)

                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TextDebtNumber.Text, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

            ElseIf ComboPaymentMethod.Text.Trim = "ذمم_دائنة" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, PayableAccount_NO, 0, TextAccountsPayableValue.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)


                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), 0, TextAccountsPayableValue.EditValue, PaymentMethod, TextDebtNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboCheckDrawerName.Text, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

            ElseIf ComboPaymentMethod.Text.Trim = "نقدا_ذمم_دائنة" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, PayableAccount_NO, 0, TextAccountsPayableValue.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)

                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TextDebtNumber.Text, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextAccountsPayableValue.EditValue, PaymentMethod, TextDebtNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboCheckDrawerName.Text, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)


            ElseIf Me.ComboPaymentMethod.Text = "شيك_ذمم_دائنة" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, TextDebitAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, PayableAccount_NO, 0, TextAccountsPayableValue.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)

                Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextAccountsPayableValue.EditValue, PaymentMethod, TextDebtNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboCheckDrawerName.Text, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)

            ElseIf Me.ComboPaymentMethod.Text = "نقدا_شيك_ذمم_دائنة" Then
                DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, TextMiligDebt.EditValue, 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 1, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 2, TextDebitAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)
                DetailsAccountingEntries(PMO2 + 3, TextCreditAccount.Text, PayableAccount_NO, 0, TextAccountsPayableValue.EditValue, nem3, PayableAccount_Cod, TextMovementSymbol.EditValue, TextDebtNumber.Text, False, T2)


                Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text, " من حساب حركة العميل  " & " _ " & Me.ComboCustomerName.Text, False, TextDebtNumber.Text, False, True, ComboCB1.Text, ModuleGeneral.CB2)

                Insert_Checks(TextCheckNumber.Text, MaxDate.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                          TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

                Insert_Suppliers1(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "0.000", TextAccountsPayableValue.EditValue, PaymentMethod, TextDebtNumber.Text,
                               "من حساب حركة المورد" & "_" & Me.ComboCheckDrawerName.Text, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "نقدا", TextFundValue.EditValue,
                                 TextValueOfCheck.EditValue, "المشتريات", TextMovementSymbol.EditValue,
                                 ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, TextCheckNumber.Text, CheckDate.Value.ToString("yyyy-MM-dd"), ComboCB1.Text, ComboBN2.Text)
            End If


        Catch er As Exception
            MessageBox.Show(er.Message, "ErrorSaveMOVESDATARecord", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

<<<<<<< HEAD
    Private Sub PP1_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextPreviousPayments.KeyUp
        ppp = Me.TextPreviousPayments.Text
    End Sub

    Private Sub PP1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextPreviousPayments.LostFocus
=======




    Private Sub PP1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextPreviousPayments.KeyUp
        ppp = Me.TextPreviousPayments.Text
    End Sub
    Private Sub PP1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextPreviousPayments.LostFocus
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Val(Me.TextPreviousPayments.Text) >= Val(Me.TextNetDebt.Text) Then
            MsgBox("لا يمكن ان يكون مجموع الدفعات السابقة اكبر  او يساوي من صافي الدين")
            Me.EDITBUTTON.Enabled = False
            Me.ButtonTransferofAccounts.Enabled = False
            Me.ButtonTransferofAccounts1.Enabled = False
            Me.TextPreviousPayments.Focus()
            Exit Sub
        Else
            Me.SHOWBUTTON()
            Me.InternalAuditorType()
        End If
        ppp = Me.TextPreviousPayments.Text
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
<<<<<<< HEAD
        AccountsEnquiry()
        FundBalance()
    End Sub

    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlConnection(constring)
        Dim Adp As SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlDataAdapter(strsql)
=======
         AccountsEnquiry()
        FundBalance()
    End Sub



    Private Sub ComboBN2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBN2.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT BN3,BN4    FROM BankNames WHERE BN2 ='" & Me.ComboBN2.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ds.Clear()
        Consum.Open()
        Adp.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.TextBN3.Text = ds.Tables(0).Rows(0).Item(0)
            BN4 = ds.Tables(0).Rows(0).Item(1)
        Else
            Me.TextBN3.Text = ""
            BN4 = ""
        End If
        Adp.Dispose()
        Consum.Close()
    End Sub

End Class