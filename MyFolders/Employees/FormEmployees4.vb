
Imports System.Data.SqlClient

Public Class FormEmployees4
    Public WithEvents BS As New BindingSource
    Dim myds As New DataSet
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter

    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Public Delegate Sub PictureBox2Callback()
    Dim DelRow As Boolean = False
    Dim RowCount As Integer = 0
    Private account_noF As String
    Private ACCF As String
    Dim bincl As Double
    Private MaxMonth As String
    Private MaxYear As String
    Private ReadOnly DtYear As Date
    Private ReadOnly DtMonth As Date
    Private FormatYear As String
    Private FormatMonth As String
    Private resault As DialogResult

    Private AssociationDeductionsPercentage As Double
    Private EmployeeDeductionsPercentage As Double
    Private BasicSalaryInsuranceRate As Double
    Private VariableRentalInsuranceRate As Double
    Private AssociationDeductionsPercentage_P As Double

    Private Sub FrmEmployees4_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            If Me.CheckLogReview.Checked = True Then
                Me.KeyPreview = False
            Else
                Me.KeyPreview = True
                Select Case e.KeyCode
                    Case Keys.F1
                        Me.ADDBUTTON_Click(sender, e)
                    Case Keys.F2
                        Me.SAVEBUTTON_Click(sender, e)
                    Case Keys.F3
                        Me.EDITBUTTON_Click(sender, e)
                    Case Keys.F4
                        Me.BUTTONCANCEL_Click(sender, e)
                    Case Keys.F6
                        Me.DELETEBUTTON_Click(sender, e)
                    Case Keys.F7
                        Me.InternalAuditorERBUTTON_Click(sender, e)
                    Case Keys.F8
                        Me.ButtonXP3_Click(sender, e)
                    Case Keys.F10
                        Me.ButtonTransferofAccounts_Click(sender, e)
                    Case Keys.R And (e.Alt And Not e.Control And Not e.Shift)
                        Me.ButtonUpdateA_Click(sender, e)
                    Case Keys.PageDown
                        Me.PREVIOUSBUTTON_Click(sender, e)
                    Case Keys.PageUp
                        Me.NEXTBUTTON_Click(sender, e)
                    Case Keys.Escape
                        Me.Close()
                End Select
                e.Handled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmEmployees4_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        On Error Resume Next
    End Sub
    Private Sub FrmEmployees4_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        On Error Resume Next
        Me.Show()
        Me.TabPage1.Show()
        Me.TabPage2.Show()
        Me.TabPage3.Show()
    End Sub
    Private Sub FrmEmployees4_Load(sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TabPage1.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.ADDBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = False
        Me.BUTTONCANCEL.Enabled = False
        Me.DELETEBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = False
        Me.ButtonTransferofAccounts.Enabled = False
        Me.ButtonUpdateA.Enabled = False
        Me.PREVIOUSBUTTON.Enabled = False
        Me.FIRSTBUTTON.Enabled = False
        Me.NEXTBUTTON.Enabled = False
        Me.LASTBUTTON.Enabled = False
        ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)


        TestkeyAccounts(keyAccounts.GetValue("CalculatingEmployeeSalaries_No", CalculatingEmployeeSalaries_No))
        If TestkeyAccounts_Check = True Then
            AccountNoAktevd = keyAccounts.GetValue("CalculatingEmployeeSalaries_No", CalculatingEmployeeSalaries_No)
        End If
        If Check_OptionsTransforAccounts.Checked = True Then
            PanelAccount.Enabled = True
        Else
            PanelAccount.Enabled = False
        End If
        AssociationDeductionsPercentage = keyAccounts.GetValue("AssociationDeductionsPercentage_B", CalculatingEmployeeSalaries_No)
        EmployeeDeductionsPercentage = keyAccounts.GetValue("EmployeeDeductionsPercentage_B", CalculatingEmployeeSalaries_No)
        'AssociationDeductionsPercentage_B = keyAccounts.GetValue("AssociationDeductionsPercentage_B", CalculatingEmployeeSalaries_No)

        BasicSalaryInsuranceRate = keyAccounts.GetValue("BasicSalaryInsuranceRate_B", CalculatingEmployeeSalaries_No)
        VariableRentalInsuranceRate = keyAccounts.GetValue("VariableRentalInsuranceRate_B", CalculatingEmployeeSalaries_No)

    End Sub
    Public Sub Load_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load1.Click
        On Error Resume Next
        Me.PicBox1.Visible = True
        Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.ConnectDataBase.RunWorkerAsync()
        Me.Load1.Enabled = False
    End Sub
    Private Sub TEXT2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TEXTBasicSalary.EditValueChanged, TEXTExtraValuePercentage.EditValueChanged, TEXTPremiumValueRatio.EditValueChanged, TEXTBonusValue.TextChanged, TEXTLncentiveValueRatio.EditValueChanged, TEXTLncentiveValue.TextChanged, TEXTReward.EditValueChanged, TEXTNatureOfWork.EditValueChanged, TEXTTransferAllowance.EditValueChanged, TEXTHousingAllowance.EditValueChanged, TEXTOtherAdditions.EditValueChanged, TEXTVariablePay.EditValueChanged, TEXTInsurances.EditValueChanged, TEXTAdvancePayment.EditValueChanged, TEXTLateDiscounts.EditValueChanged, TEXTAbsenceDiscounts.EditValueChanged, TEXTSanctionsDiscounts.EditValueChanged, TEXTOtherDiscounts.EditValueChanged, TextSocialSecurity.EditValueChanged
        On Error Resume Next
        Me.TextExtraValue.Text = Format(Val(Me.TEXTExtraValuePercentage.EditValue) * SumOvertimeHours(), "0.000")
        Me.TEXTBonusValue.Text = Format(Val(Me.TEXTBasicSalary.EditValue) * Val(Me.TEXTPremiumValueRatio.EditValue) / 100, "0.000")
        Me.TEXTLncentiveValue.Text = Format(Val(Me.TEXTBasicSalary.EditValue) * Val(Me.TEXTLncentiveValueRatio.EditValue) / 100, "0.000")
        Me.TEXTVariablePay.EditValue = Format(Val(Me.TextExtraValue.Text) + Val(Me.TEXTBonusValue.Text) + Val(Me.TEXTLncentiveValue.Text) + Val(Me.TEXTReward.EditValue) + Val(Me.TEXTNatureOfWork.EditValue) + Val(Me.TEXTTransferAllowance.EditValue) + Val(Me.TEXTHousingAllowance.EditValue) + Val(Me.TEXTOtherAdditions.EditValue), "0.000")
        'Me.TextSocialSecurity.EditValue = Format((Val(Me.TEXTBasicSalary.EditValue) * AssociationDeductionsPercentage / 100) + (Val(Me.TEXTBasicSalary.EditValue) * EmployeeDeductionsPercentage / 100), "0.000")
        AssociationDeductionsPercentage_P = Format((Val(Me.TEXTBasicSalary.EditValue) * AssociationDeductionsPercentage / 100), "0.000")
        Me.TextSocialSecurity.EditValue = Format((Val(Me.TEXTBasicSalary.EditValue) * EmployeeDeductionsPercentage / 100), "0.000")
        Me.TEXTInsurances.EditValue = Format((Val(Me.TEXTBasicSalary.EditValue) * BasicSalaryInsuranceRate / 100) + (Val(Me.TEXTVariablePay.EditValue) * VariableRentalInsuranceRate) / 100, "0.000")

        Me.TEXTNetSalary.Text = Format(Val(Me.TEXTBasicSalary.EditValue) + Me.TEXTVariablePay.EditValue - Val(Me.TEXTInsurances.EditValue) - Val(Me.TEXTAdvancePayment.EditValue) - Val(Me.TEXTLateDiscounts.EditValue) - Val(Me.TEXTAbsenceDiscounts.EditValue) - Val(Me.TEXTSanctionsDiscounts.EditValue) - Val(Me.TEXTOtherDiscounts.EditValue) - Val(Me.TextSocialSecurity.EditValue), "0.000")
    End Sub
    Private Sub TextFundValue_EditValueChanged(sender As Object, e As EventArgs) Handles TextFundValue.EditValueChanged, TextValueOfCheck.EditValueChanged
        TextValueOfCheck.EditValue = Val(Me.TEXTNetSalary.Text) - Val(Me.TextFundValue.EditValue)
        TextFundValue.EditValue = Val(Me.TEXTNetSalary.Text) - Val(Me.TextValueOfCheck.EditValue)

    End Sub


    Public Sub RecordCount()
        On Error Resume Next
        Dim TotalRecords, CurrenRecordst As Integer
        Dim Back As Boolean = False
        Dim Forward As Boolean = False
        TotalRecords = Me.BS.Count
        CurrenRecordst = Me.BS.Position + 1
        Me.RECORDSLABEL.Text = CurrenRecordst.ToString & " من " & TotalRecords.ToString
        If Me.BS.Position > 0 Then
            Back = True
        End If
        If Me.BS.Position < Me.myds.Tables("SALARIES").Rows.Count - 1 Then
            Forward = True
        End If
        Me.FIRSTBUTTON.Enabled = Back
        Me.PREVIOUSBUTTON.Enabled = Back
        Me.NEXTBUTTON.Enabled = Forward
        Me.LASTBUTTON.Enabled = Forward
        Me.AutoEx()
        Me.FundBalance()
        'Me.SEARCHEMPCOSTDETALLS()
        Me.SEARCHEMP()
        AccountsEnquiry()
        If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
            Me.NUpCreditAccount1.Enabled = True
            Me.PicAccountLevel1.Enabled = True
        Else
            Me.NUpCreditAccount1.Enabled = False
            Me.PicAccountLevel1.Enabled = False
        End If
        Me.SHOWBUTTON()
        Me.InternalAuditorType()
        Me.SAVEBUTTON.Enabled = False
        MaxMonthSly()
        FormatYear = Date.Parse(MaxMonth).ToString("yyyy")
        FormatMonth = Date.Parse(MaxMonth).ToString("MM")
        'Me.ComboPaymentMethod1_SelectedIndexChanged(sender, e)
    End Sub
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
        Try
1:

            Dim Consum As New SqlClient.SqlConnection(constring)
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
            If Consum.State = ConnectionState.Open Then
                Consum.Close()
            End If
            Dim strSQL As New SqlClient.SqlCommand("", Consum)
            With strSQL
                .CommandText = "SELECT  SLY1, SLY2, SLYCod, SLY3, SLY4, SLY5, SLY6, SLY7, SLY8, SLY9, SLY10, SLY11, SLY12, SLY13, SLY14, SLY15, SLY16, SLY17, SLY18, SLY19, SLY20, SLY21, SLY22, SLY23, SLY24, SLY25, SLY26, SLY27, SLY28, SLY29, SLY30, SLY31, SLY32, SLY33, SLY34, SLY35, SLY36, SLY37, CB1, BN2, USERNAME, Auditor, Cuser, COUSER, da, ne, da1, ne1 FROM SALARIES   WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  ORDER BY SLY1"
                Consum.Open()
                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(strSQL)
                Me.myds = New DataSet
                Me.SqlDataAdapter1.TableMappings.Add("Table1", "SALARIES")
                Me.SqlDataAdapter1.Fill(Me.myds, "SALARIES")
                Me.myds.RejectChanges()
            End With
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorConnectDataBase.DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("SALARIES")
            Me.RowCount = Me.BS.Count
            FILLCOMBOBOX1("CashBox", "CB1", "CUser", CUser, Me.ComboCB1)
            FILLCOMBOBOX1("BankNames", "BN2", "CUser", CUser, Me.ComboBN2)
            If Me.myds.Tables("SALARIES").Rows.Count > 0 Then
                Me.TEXTEmployeeCode.Text = Me.myds.Tables("SALARIES").Rows(Me.BS.Position)("SLYCod").ToString
                Me.TEXTPremiumValueRatio.Text = Me.myds.Tables("SALARIES").Rows(Me.BS.Position)("SLY7").ToString
                Me.TEXTLncentiveValueRatio.Text = Me.myds.Tables("SALARIES").Rows(Me.BS.Position)("SLY9").ToString
            End If
            Me.TEXTID.DataBindings.Add("text", Me.BS, "SLY1", True, 1, "")
            Me.ComboEmployeeName.DataBindings.Add("text", Me.BS, "SLY2", True, 1, "")
            'Me.TEXTEmployeeCode.DataBindings.Add("text", Me.BS, "SLYCod", True, 1, "")

            Me.ComboMonths.DataBindings.Add("text", Me.BS, "SLY3", True, 1, "")
            Me.TEXTBasicSalary.DataBindings.Add("text", Me.BS, "SLY4", True, 1, "")
            Me.TEXTExtraValuePercentage.DataBindings.Add("text", Me.BS, "SLY5", True, 1, "")
            Me.TextExtraValue.DataBindings.Add("text", Me.BS, "SLY6", True, 1, "")
            'Me.TEXTPremiumValueRatio.DataBindings.Add("text", Me.BS, "SLY7", True, 1, "")

            Me.TEXTBonusValue.DataBindings.Add("text", Me.BS, "SLY8", True, 1, "")
            'Me.TEXTLncentiveValueRatio.DataBindings.Add("text", Me.BS, "SLY9", True, 1, "")

            Me.TEXTLncentiveValue.DataBindings.Add("text", Me.BS, "SLY10", True, 1, "")
            Me.TEXTReward.DataBindings.Add("text", Me.BS, "SLY11", True, 1, "")
            Me.TEXTNatureOfWork.DataBindings.Add("text", Me.BS, "SLY12", True, 1, "")
            Me.TEXTTransferAllowance.DataBindings.Add("text", Me.BS, "SLY13", True, 1, "")
            Me.TEXTHousingAllowance.DataBindings.Add("text", Me.BS, "SLY14", True, 1, "")
            Me.TEXTOtherAdditions.DataBindings.Add("text", Me.BS, "SLY15", True, 1, "")
            Me.TEXTVariablePay.DataBindings.Add("text", Me.BS, "SLY16", True, 1, "")
            Me.TEXTInsurances.DataBindings.Add("text", Me.BS, "SLY17", True, 1, "")
            Me.TextSocialSecurity.DataBindings.Add("text", Me.BS, "SLY18", True, 1, "")
            Me.TEXTAdvancePayment.DataBindings.Add("text", Me.BS, "SLY19", True, 1, "")
            Me.TEXTLateDiscounts.DataBindings.Add("text", Me.BS, "SLY20", True, 1, "")
            Me.TEXTAbsenceDiscounts.DataBindings.Add("text", Me.BS, "SLY21", True, 1, "")
            Me.TEXTSanctionsDiscounts.DataBindings.Add("text", Me.BS, "SLY22", True, 1, "")
            Me.TEXTOtherDiscounts.DataBindings.Add("text", Me.BS, "SLY23", True, 1, "")
            Me.TEXTNetSalary.DataBindings.Add("text", Me.BS, "SLY24", True, 1, "")
            Me.TextMovementSymbol.DataBindings.Add("text", Me.BS, "SLY25", True, 1, "")
            Me.DateMovementHistory.DataBindings.Add("text", Me.BS, "SLY26", True, 1, "")
            Me.CheckTransferAccounts.DataBindings.Add("Checked", Me.BS, "SLY27", True, 1, "")
            Me.CheckLogReview.DataBindings.Add("Checked", Me.BS, "SLY28", True, 1, "")
            Me.CheckSettled.DataBindings.Add("Checked", Me.BS, "SLY29", True, 1, "")
            Me.ComboCheckDrawerName.DataBindings.Add("text", Me.BS, "SLY30", True, 1, "")
            Me.TextCheckDrawerCode.DataBindings.Add("text", Me.BS, "SLY31", True, 1, "")
            Me.TextFundValue.DataBindings.Add("text", Me.BS, "SLY32", True, 1, "")
            Me.TextCheckNumber.DataBindings.Add("text", Me.BS, "SLY33", True, 1, "")
            Me.CheckDate.DataBindings.Add("text", Me.BS, "SLY34", True, 1, "")
            Me.TextValueOfCheck.DataBindings.Add("text", Me.BS, "SLY35", True, 1, "")
            Me.ComboPaymentMethod1.DataBindings.Add("text", Me.BS, "SLY36", True, 1, "")
            Me.CheckAdvanceDeferral.DataBindings.Add("Checked", Me.BS, "SLY37", True, 1, "")
            Me.ComboCB1.DataBindings.Add("text", Me.BS, "CB1", True, 1, "")
            Me.ComboBN2.DataBindings.Add("text", Me.BS, "BN2", True, 1, "")

            Me.TEXTUserName.DataBindings.Add("text", Me.BS, "USERNAME", True, 1, "")
            Me.TEXTReferenceName.DataBindings.Add("text", Me.BS, "Auditor", True, 1, "")
            Me.TextDefinitionDirectorate.DataBindings.Add("text", Me.BS, "COUser", True, 1, "")
            Me.TEXTAddDate.DataBindings.Add("text", Me.BS, "da", True, 1, "")
            Me.TextTimeAdd.DataBindings.Add("text", Me.BS, "ne", True, 1, "")
            Me.TEXTReviewDate.DataBindings.Add("text", Me.BS, "da1", True, 1, "")
            Me.TextreviewTime.DataBindings.Add("text", Me.BS, "ne1", True, 1, "")

            If ComboCB1.Items.Count > 0 Then
                Me.ComboCB1.SelectedIndex = 0
            End If
            If ComboBN2.Items.Count > 0 Then
                Me.ComboBN2.SelectedIndex = 0
            End If

            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboEmployeeName)
            FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboCheckDrawerName)

            Me.ComboCB1_SelectedIndexChanged(sender, e)
            Me.ComboBN2_SelectedIndexChanged(sender, e)
            Auditor("SALARIES", "USERNAME", "SLY1", Me.TEXTID.EditValue, "")
            Logentry = Uses

            Call MangUsers()
            Me.RecordCount()

            ItWillBeAnAccountingEntryWhenAdding_Check = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", ItWillBeAnAccountingEntryWhenAdding_Check)

            TestkeyAccounts(keyAccounts.GetValue("CalculatingEmployeeSalaries_No", CalculatingEmployeeSalaries_No))
            If TestkeyAccounts_Check = True Then
                AccountNoAktevd = keyAccounts.GetValue("CalculatingEmployeeSalaries_No", CalculatingEmployeeSalaries_No)
            End If
            If Check_OptionsTransforAccounts.Checked = True Then
                PanelAccount.Enabled = True
            Else
                PanelAccount.Enabled = False
            End If
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.Label12.Visible = False
            Consum.Close()
            Me.PicBox1.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorConnectDataBase_RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If TestNet = True Then
                Me.Label12.Visible = True
                Me.Label12.ForeColor = Color.Yellow
                Me.Label12.Text = ".. تم الاتصال بالانترنت .. يتم الان تحميل سجلات القاعدة"
            Else
                Me.Label12.ForeColor = Color.Red
                Me.Label12.Text = "الاتصال بالانترنت غير متوفر"
                Me.Close()
            End If
        End If
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboEmployeeName, e, )
    End Sub
    Private Sub ComboBox5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboDebitAccount, e, )
    End Sub
    Private Sub ComboBox6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(Me.ComboCheckDrawerName, e, )
    End Sub

    Private Sub SAVERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO SALARIES(SLY1, SLY2, SLYCod, SLY3, SLY4, SLY5, SLY6, SLY7, SLY8, SLY9, SLY10, SLY11, SLY12, SLY13, SLY14, SLY15, SLY16, SLY17, SLY18, SLY19, SLY20, SLY21, SLY22, SLY23, SLY24, SLY25, SLY26, SLY27, SLY28, SLY29, SLY30, SLY31, SLY32, SLY33, SLY34, SLY35, SLY36, SLY37, CB1, BN2, USERNAME, Cuser, COUSER, da, ne) VALUES     (@SLY1, @SLY2, @SLYCod, @SLY3, @SLY4, @SLY5, @SLY6, @SLY7, @SLY8, @SLY9, @SLY10, @SLY11, @SLY12, @SLY13, @SLY14, @SLY15, @SLY16, @SLY17, @SLY18, @SLY19, @SLY20, @SLY21, @SLY22, @SLY23, @SLY24, @SLY25, @SLY26, @SLY27, @SLY28, @SLY29, @SLY30, @SLY31, @SLY32, @SLY33, @SLY34, @SLY35, @SLY36, @SLY37, @CB1, @BN2, @USERNAME, @Cuser, @COUSER, @da, @ne)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SLY1", SqlDbType.BigInt).Value = TEXTID.EditValue
                .Parameters.Add("@SLY2", SqlDbType.NVarChar).Value = Me.ComboEmployeeName.Text
                .Parameters.Add("@SLYCod", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.EditValue

                .Parameters.Add("@SLY3", SqlDbType.NVarChar).Value = Me.ComboMonths.Text
                .Parameters.Add("@SLY4", SqlDbType.NVarChar).Value = Me.TEXTBasicSalary.EditValue
                .Parameters.Add("@SLY5", SqlDbType.NVarChar).Value = Me.TEXTExtraValuePercentage.EditValue
                .Parameters.Add("@SLY6", SqlDbType.NVarChar).Value = Me.TextExtraValue.Text
                .Parameters.Add("@SLY7", SqlDbType.NVarChar).Value = Me.TEXTPremiumValueRatio.EditValue
                .Parameters.Add("@SLY8", SqlDbType.NVarChar).Value = Me.TEXTBonusValue.Text
                .Parameters.Add("@SLY9", SqlDbType.NVarChar).Value = Me.TEXTLncentiveValueRatio.EditValue
                .Parameters.Add("@SLY10", SqlDbType.NVarChar).Value = Me.TEXTLncentiveValue.Text
                .Parameters.Add("@SLY11", SqlDbType.NVarChar).Value = Me.TEXTReward.EditValue
                .Parameters.Add("@SLY12", SqlDbType.NVarChar).Value = Me.TEXTNatureOfWork.EditValue
                .Parameters.Add("@SLY13", SqlDbType.NVarChar).Value = Me.TEXTTransferAllowance.EditValue
                .Parameters.Add("@SLY14", SqlDbType.NVarChar).Value = Me.TEXTHousingAllowance.EditValue
                .Parameters.Add("@SLY15", SqlDbType.NVarChar).Value = Me.TEXTOtherAdditions.EditValue
                .Parameters.Add("@SLY16", SqlDbType.NVarChar).Value = Me.TEXTVariablePay.EditValue
                .Parameters.Add("@SLY17", SqlDbType.NVarChar).Value = Me.TEXTInsurances.EditValue
                .Parameters.Add("@SLY18", SqlDbType.NVarChar).Value = Me.TextSocialSecurity.EditValue
                .Parameters.Add("@SLY19", SqlDbType.NVarChar).Value = Me.TEXTAdvancePayment.EditValue
                .Parameters.Add("@SLY20", SqlDbType.NVarChar).Value = Me.TEXTLateDiscounts.EditValue
                .Parameters.Add("@SLY21", SqlDbType.NVarChar).Value = Me.TEXTAbsenceDiscounts.EditValue
                .Parameters.Add("@SLY22", SqlDbType.NVarChar).Value = Me.TEXTSanctionsDiscounts.EditValue
                .Parameters.Add("@SLY23", SqlDbType.NVarChar).Value = Me.TEXTOtherDiscounts.EditValue
                .Parameters.Add("@SLY24", SqlDbType.NVarChar).Value = Me.TEXTNetSalary.Text
                .Parameters.Add("@SLY25", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@SLY26", SqlDbType.NVarChar).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLY27", SqlDbType.Bit).Value = Convert.ToInt32(TransferToAccounts_Check)
                .Parameters.Add("@SLY28", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@SLY29", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettled.Checked)
                .Parameters.Add("@SLY30", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@SLY31", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@SLY32", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@SLY33", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@SLY34", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLY35", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@SLY36", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod1.Text
                .Parameters.Add("@SLY37", SqlDbType.Bit).Value = Convert.ToInt32(CheckAdvanceDeferral.Checked)
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub UPDATERECORD()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand(" Update SALARIES SET  SLY2 = @SLY2, SLYCod = @SLYCod, SLY3 = @SLY3, SLY4 = @SLY4, SLY5 = @SLY5, SLY6 = @SLY6, SLY7 = @SLY7, SLY8 = @SLY8, SLY9 = @SLY9, SLY10 = @SLY10, SLY11 = @SLY11, SLY12 = @SLY12, SLY13 = @SLY13, SLY14 = @SLY14, SLY15 = @SLY15, SLY16 = @SLY16, SLY17 = @SLY17, SLY18 = @SLY18, SLY19 = @SLY19, SLY20 = @SLY20, SLY21 = @SLY21, SLY22 = @SLY22, SLY23 = @SLY23, SLY24 = @SLY24, SLY25 = @SLY25, SLY26 = @SLY26, SLY27= @SLY27, SLY28= @SLY28, SLY29= @SLY29, SLY30= @SLY30, SLY31= @SLY31, SLY32= @SLY32, SLY33= @SLY33, SLY34= @SLY34, SLY35= @SLY35, SLY36= @SLY36, SLY37= @SLY37, CB1= @CB1, BN2= @BN2, USERNAME = @USERNAME, Auditor = @Auditor, Cuser = @Cuser, COUSER = @COUSER, da = @da, ne = @ne, da1 = @da1, ne1 = @ne1 WHERE SLY1 = @SLY1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@SLY1", SqlDbType.NVarChar).Value = TEXTID.EditValue
                .Parameters.Add("@SLY2", SqlDbType.NVarChar).Value = Me.ComboEmployeeName.Text
                .Parameters.Add("@SLYCod", SqlDbType.NVarChar).Value = Me.TEXTEmployeeCode.EditValue
                .Parameters.Add("@SLY3", SqlDbType.NVarChar).Value = Me.ComboMonths.Text
                .Parameters.Add("@SLY4", SqlDbType.NVarChar).Value = Me.TEXTBasicSalary.EditValue
                .Parameters.Add("@SLY5", SqlDbType.NVarChar).Value = Me.TEXTExtraValuePercentage.EditValue
                .Parameters.Add("@SLY6", SqlDbType.NVarChar).Value = Me.TextExtraValue.Text
                .Parameters.Add("@SLY7", SqlDbType.NVarChar).Value = Me.TEXTPremiumValueRatio.EditValue
                .Parameters.Add("@SLY8", SqlDbType.NVarChar).Value = Me.TEXTBonusValue.Text
                .Parameters.Add("@SLY9", SqlDbType.NVarChar).Value = Me.TEXTLncentiveValueRatio.EditValue
                .Parameters.Add("@SLY10", SqlDbType.NVarChar).Value = Me.TEXTLncentiveValue.Text
                .Parameters.Add("@SLY11", SqlDbType.NVarChar).Value = Me.TEXTReward.EditValue
                .Parameters.Add("@SLY12", SqlDbType.NVarChar).Value = Me.TEXTNatureOfWork.EditValue
                .Parameters.Add("@SLY13", SqlDbType.NVarChar).Value = Me.TEXTTransferAllowance.EditValue
                .Parameters.Add("@SLY14", SqlDbType.NVarChar).Value = Me.TEXTHousingAllowance.EditValue
                .Parameters.Add("@SLY15", SqlDbType.NVarChar).Value = Me.TEXTOtherAdditions.EditValue
                .Parameters.Add("@SLY16", SqlDbType.NVarChar).Value = Me.TEXTVariablePay.EditValue
                .Parameters.Add("@SLY17", SqlDbType.NVarChar).Value = Me.TEXTInsurances.EditValue
                .Parameters.Add("@SLY18", SqlDbType.NVarChar).Value = Me.TextSocialSecurity.EditValue
                .Parameters.Add("@SLY19", SqlDbType.NVarChar).Value = Me.TEXTAdvancePayment.EditValue
                .Parameters.Add("@SLY20", SqlDbType.NVarChar).Value = Me.TEXTLateDiscounts.EditValue
                .Parameters.Add("@SLY21", SqlDbType.NVarChar).Value = Me.TEXTAbsenceDiscounts.EditValue
                .Parameters.Add("@SLY22", SqlDbType.NVarChar).Value = Me.TEXTSanctionsDiscounts.EditValue
                .Parameters.Add("@SLY23", SqlDbType.NVarChar).Value = Me.TEXTOtherDiscounts.EditValue
                .Parameters.Add("@SLY24", SqlDbType.NVarChar).Value = Me.TEXTNetSalary.Text
                .Parameters.Add("@SLY25", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@SLY26", SqlDbType.NVarChar).Value = Me.DateMovementHistory.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLY27", SqlDbType.Bit).Value = Convert.ToInt32(CheckTransferAccounts.Checked)
                .Parameters.Add("@SLY28", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckLogReview.Checked)
                .Parameters.Add("@SLY29", SqlDbType.Bit).Value = Convert.ToInt32(Me.CheckSettled.Checked)
                .Parameters.Add("@SLY30", SqlDbType.NVarChar).Value = Me.ComboCheckDrawerName.Text
                .Parameters.Add("@SLY31", SqlDbType.NVarChar).Value = Me.TextCheckDrawerCode.Text
                .Parameters.Add("@SLY32", SqlDbType.NVarChar).Value = Me.TextFundValue.EditValue
                .Parameters.Add("@SLY33", SqlDbType.NVarChar).Value = Me.TextCheckNumber.Text
                .Parameters.Add("@SLY34", SqlDbType.Date).Value = Me.CheckDate.Value.ToString("yyyy-MM-dd")
                .Parameters.Add("@SLY35", SqlDbType.NVarChar).Value = Me.TextValueOfCheck.EditValue
                .Parameters.Add("@SLY36", SqlDbType.NVarChar).Value = Me.ComboPaymentMethod1.Text
                .Parameters.Add("@SLY37", SqlDbType.Bit).Value = Convert.ToInt32(CheckAdvanceDeferral.Checked)
                .Parameters.Add("@CB1", SqlDbType.NVarChar).Value = Me.ComboCB1.Text
                .Parameters.Add("@BN2", SqlDbType.NVarChar).Value = Me.ComboBN2.Text




                .Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
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
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Public Sub Count()
        On Error Resume Next
        Me.RECORDSLABEL.Text = Me.BS.Position + 1 & " من " & Me.BS.Count
    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.PicBox1.Visible = True
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "SALARIES")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                Me.PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                Me.PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "Error3", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.BS.DataSource = Me.myds.Tables("SALARIES")
            Me.PicBox1.Visible = False
            Me.Cursor = Cursors.Default
            Me.Count()
            If DelRow = False Then
                If Me.BS.Count < Me.RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 48 + 524288, "تحديث السجلات")
                ElseIf BS.Count > RowCount Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error4", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
        Try
1:
            'Dim myBuilder As SqlCommandBuilder = New SqlCommandBuilder(SqlDataAdapter1)
            'myBuilder.GetUpdateCommand()
            'SqlDataAdapter1.UpdateCommand = myBuilder.GetUpdateCommand()

            'SqlDataAdapter1.Update(myds, "SALARIES")
            'myds = New DataSet
            'SqlDataAdapter1.Fill(myds, "SALARIES")
            'myds.RejectChanges()
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
                MessageBox.Show(ex.Message, "Error5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
        Try
            If DelRow = True Then
                Me.ButtonUpdateA_Click(sender, e)
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()
            Me.BS.DataSource = Me.myds.Tables("SALARIES")
            Me.Cursor = Cursors.Default
            Me.PicBox1.Visible = False
            Me.Count()

            If Me.BS.Count < Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount - Me.BS.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS.Count > Me.RowCount Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS.Count - Me.RowCount, 64 + 524288, " نجاح الحفظ والتغييرات")

                Exit Sub
            End If
            Dim Sound As System.IO.Stream = My.Resources.save
            My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)
            If Click1 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "حفظ", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click2 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "تعديل", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click3 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click4 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click5 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الصندزق رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click6 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, " ترحيل  الى القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click7 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "تعديل ترحيل  حركة القيود اليومية و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click8 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "حذف ترحيل حركة القيود اليومية و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click9 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "ترحيل الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click10 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "تعديل ترحيل  الى القيود اليومية و الصندزق و الشيكات رفم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click11 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "حذف ترحيل حركة الصندزق و الشيكات رقم" & " " & Me.TextMovementSymbol.EditValue, Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click12 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "المراجع", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            ElseIf Click13 = True Then
                Try
                    Insert_Actions(TEXTID.EditValue, "إلغاء المراجعة", Me.Text)
                Catch ex As Exception
                    MsgBox("حدث خطاء", MsgBoxStyle.Information, "معلومات")
                Finally
                    Consum.Close()
                End Try
            End If
            Click1 = False
            Click2 = False
            Click3 = False
            Click4 = False
            Click5 = False
            Click6 = False
            Click7 = False
            Click8 = False
            Click9 = False
            Click10 = False
            Click11 = False
            Click12 = False
            Click13 = False
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error6", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PicBox1.Visible = False
        End If
    End Sub
    Private Sub BS_PositionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BS.PositionChanged
        On Error Resume Next
        Me.RecordCount()
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.ADDBUTTON.Enabled = LockAddRow
        Me.SAVEBUTTON.Enabled = LockSave
        Me.EDITBUTTON.Enabled = LockUpdate
        Me.DELETEBUTTON.Enabled = LockDelete
        Me.InternalAuditorERBUTTON.Enabled = InternalAuditor
        Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = InternalAuditor
        Me.ButtonTransferofAccounts.Enabled = TransferofAccounts
        Me.ButtonUpdateA.Enabled = True
    End Sub
    Private Sub COMBOBOX1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ComboEmployeeName.KeyDown, TEXTBasicSalary.KeyDown, TEXTBonusValue.KeyDown, TEXTLncentiveValue.KeyDown, ComboMonths.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
                Dim resault As Integer
                resault = MessageBox.Show("هل ترغب باضافةراتب الشهر السابق للموظف " & Me.ComboEmployeeName.Text, "المرتبات", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.SEARCHDATASALARIES()
                End If
        End Select
    End Sub
    Private Sub CLEARDATA()
        On Error Resume Next
        Dim txt As Control
        For Each txt In Me.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
        Next
    End Sub

    Private Sub SEARCHUSERS()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlCommand("SELECT SLY2  FROM SALARIES  WHERE (SALARIES.SLY2)='" & Me.TEXTBasicSalary.EditValue & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsq1)
        ds.Clear()
        Adp1.Fill(ds, "SALARIES")
        If ds.Tables(0).Rows.Count >= 1 Then
            MessageBox.Show("تم تسجيل بيانات المستخدم سابقاً", "تكرار بيانات مستخدم", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Me.TEXTBasicSalary.Focus()
            flag = True
            Exit Sub
        End If
        Adp1.Dispose()
        Consum.Close()
    End Sub
    Private Sub FIRSTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = 0
        Me.RecordCount()
    End Sub
    Private Sub PREVIOUSBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PREVIOUSBUTTON.Click
        On Error Resume Next
        Me.BS.Position = BS.Position - 1
        Me.RecordCount()
    End Sub
    Private Sub NEXTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NEXTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = BS.Position + 1
        Me.RecordCount()
    End Sub
    Private Sub LASTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LASTBUTTON.Click
        On Error Resume Next
        Me.BS.Position = BS.Count - 1
        Me.RecordCount()
    End Sub
    Private Sub DELETEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DELETEBUTTON.Click
        On Error Resume Next
        If LockDelete = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية حذف السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        MYDELETERECORD("SALARIES", "SLY1", Me.TEXTID, Me.BS, True)
        Me.FrmEmployees4_Load(sender, e)
        Insert_Actions(TEXTID.EditValue, "حذف", Me.Text)
    End Sub
    Private Sub EDITBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EDITBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockUpdate = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        If Me.CheckTransferAccounts.Checked = True Then
            MsgBox("لايمكن تعدبل  السجل الحالى لأنه مرحل ... يمكن التعديل من خلال زر ترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        If Format(Val(Me.TEXTNetSalary.Text) <> Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue), "0.000") Then
            MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
            Exit Sub
        End If
        Dim ch As Double
        Dim ch1 As Double
        ch = Me.TEXTNetSalary.Text
        ch1 = Me.TextFundBalance.Text
        If ch1 < ch Then
            MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
            Exit Sub
        End If
        Me.PicBox1.Visible = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.Cursor = Cursors.WaitCursor
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.ADDBUTTON.Enabled = True
        Me.SAVEBUTTON.Enabled = False
        Click2 = True
    End Sub
    Private Sub SAVEBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVEBUTTON.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If BS.Count = 0 Then Beep() : Exit Sub
            If LockSave = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If Format(Val(Me.TEXTNetSalary.Text) <> Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue), "0.000") Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي كشف الراتب", 16, "تنبيه")
                Exit Sub
            End If
            Me.SEARCHUSERS()
            Dim ch As Double
            Dim ch1 As Double
            ch = Val(TEXTNetSalary.Text)
            ch1 = Val(TextFundBalance.Text)
            If ch1 < ch Then
                MsgBox("انتبه رصبد الصندوق لا يكفي لهذه الحركة", 16, "تنبيه")
                Exit Sub
            End If
            If Val(Me.TEXTNetSalary.Text) <> (Val(TextFundValue.EditValue) + Val(TextValueOfCheck.EditValue)) Then
                MsgBox("عفوا .. يجب ان يكون اجمالي الصندوق والشيك مساوي الى اجمالي الفاتورة", 16, "تنبيه")
                Exit Sub
            End If
            Me.PicBox1.Visible = True
            Me.TEXTUserName.Text = USERNAME
            Me.TEXTReferenceName.Text = CUser
            Me.TextDefinitionDirectorate.Text = COUser
            Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
            Me.Cursor = Cursors.WaitCursor
            Me.SAVERECORD()
            Me.BS.EndEdit()
            Me.RowCount = BS.Count
            If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
                TransferToAccounts_Check = True
                TransforAccounts()
                If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                    If Me.TextAdvanceMovementNumber.Text = 0 Then
                        Me.SaveEMPCOSTDETALLS()
                    Else
                        Me.UPDATEEMPCOSTDETALLS()
                    End If
                End If
            Else
                TransferToAccounts_Check = False
            End If

            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
            Click1 = True
            Me.ADDBUTTON.Enabled = True
            Me.SAVEBUTTON.Enabled = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub InternalAuditorERBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InternalAuditorERBUTTON.Click
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
        If Me.CheckTransferAccounts.Checked = False Then
            MsgBox("عفوا .. لايمكن مراجعة السجلات قبل الترحيل الى الحسابات", 16, "تنبيه")
            Exit Sub
        End If
        Static P As Integer
        P = Me.BS.Position
        Me.CheckLogReview.Checked = True
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.RecordCount()
        Me.SAVEBUTTON.Enabled = False
        Me.InternalAuditorType()
        Me.Cursor = Cursors.WaitCursor
        Me.PicBox1.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        Me.BS.Position = P
        MsgBox("تمت عملية المراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Click12 = True
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancellationAuditingAndACheckingAccounts.Click
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
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.TEXTReviewDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextreviewTime.Text = ServerDateTime.ToString("hh:mm:ss tt")
        Me.PicBox1.Visible = True
        Me.UPDATERECORD()
        Me.BS.EndEdit()
        Me.RowCount = Me.BS.Count
        Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.SaveTab.RunWorkerAsync()
        MsgBox("تمت عملية إلغاءالمراجعة بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Click13 = True
    End Sub
    Private Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDBUTTON.Click
        On Error Resume Next
        If TestNet = False Then
            MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            Exit Sub
        End If
        If LockAddRow = False Then
            MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
            Exit Sub
        End If
        CLEARDATA()
        Me.BS.EndEdit()
        Me.BS.AddNew()
        GetAutoNumber("SLY1", "SALARIES", "SLY26")
        Me.TEXTID.EditValue = AutoNumber
        Me.FundBalance()
        Me.TextMovementSymbol.EditValue = "ES" & Me.TEXTID.EditValue
        Me.TextFundValue.EditValue = 0
        Me.TextValueOfCheck.EditValue = 0
        Me.DateMovementHistory.Value = MaxDate.ToString("yyyy-MM-dd")
        Me.TEXTUserName.Text = USERNAME
        Me.TEXTReferenceName.Text = CUser
        Me.TextDefinitionDirectorate.Text = COUser
        Me.TEXTAddDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
        Me.TextTimeAdd.Text = ServerDateTime.ToString("hh:mm:ss tt")
        If ComboCB1.Items.Count > 0 Then
            Me.ComboCB1.SelectedIndex = 0
        End If
        If ComboBN2.Items.Count > 0 Then
            Me.ComboBN2.SelectedIndex = 0
        End If
        If ItWillBeAnAccountingEntryWhenAdding_Check = True Then
            TransferToAccounts_Check = True
        Else
            TransferToAccounts_Check = False
        End If
        Me.ComboEmployeeName.Focus()
        Me.CheckSettled.Checked = True
        Me.CheckAdvanceDeferral.Checked = True
        Me.CheckLogReview.Checked = True
        Me.CheckTransferAccounts.Checked = True
        Me.CheckSettled.Checked = False
        Me.CheckAdvanceDeferral.Checked = False
        Me.CheckLogReview.Checked = False
        Me.CheckTransferAccounts.Checked = False
        Me.InternalAuditorType()
        Me.ADDBUTTON.Enabled = False
        Me.EDITBUTTON.Enabled = False
        Me.SAVEBUTTON.Enabled = True
        Me.BUTTONCANCEL.Enabled = True
        Me.DELETEBUTTON.Enabled = False
        Me.InternalAuditorERBUTTON.Enabled = False
    End Sub
    Private Sub BUTTONCANCEL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONCANCEL.Click
        On Error Resume Next
        Me.BS.CancelEdit()
        Me.RecordCount()
    End Sub
    Private Sub InternalAuditorType()
        On Error Resume Next
        If Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.Panel1.Enabled = False
            Me.Panel2.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False

        ElseIf Me.CheckAdvanceDeferral.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = True
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.Panel1.Enabled = True
            Me.Panel2.Enabled = True
            Me.TabPage3.Enabled = True
        ElseIf Me.CheckAdvanceDeferral.Checked = True And Me.CheckLogReview.Checked = True Then
            Me.SAVEBUTTON.Enabled = False
            Me.EDITBUTTON.Enabled = False
            Me.BUTTONCANCEL.Enabled = True
            Me.DELETEBUTTON.Enabled = False
            Me.InternalAuditorERBUTTON.Enabled = False
            Me.ButtonCancellationAuditingAndACheckingAccounts.Enabled = True
            Me.ButtonUpdateA.Enabled = True
            Me.Panel1.Enabled = False
            Me.Panel2.Enabled = False
            Me.GroupPaymentMethod.Enabled = False
            Me.GroupCHKS1.Enabled = False
            Me.GroupCHKS.Enabled = False
            Me.PanelAccount.Enabled = False
        Else
            Me.SHOWBUTTON()
            Me.Panel1.Enabled = True
            Me.Panel2.Enabled = True
            Me.GroupPaymentMethod.Enabled = True
            Me.GroupCHKS1.Enabled = True
            Me.GroupCHKS.Enabled = True
            Me.PanelAccount.Enabled = True
        End If
    End Sub
    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpComboDebitAccount.ValueChanged
        Me.ComboDebitAccount.DataSource = GetData(NUpComboDebitAccount.Value)
        Me.ComboDebitAccount.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount.ValueChanged

        Me.List1.DataSource = GetData(NUpCreditAccount.Value)
        Me.List1.DisplayMember = "account_name"
    End Sub
    Private Sub NumericUpDown3_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NUpCreditAccount1.ValueChanged
        Me.List2.DataSource = GetData(NUpCreditAccount1.Value)
        Me.List2.DisplayMember = "account_name"
    End Sub
    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel.Click
        LS1 = True
        Me.PanelAccount_Name.Visible = True
        Me.List1.Visible = True
    End Sub
    Private Sub PictureBox10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAccountLevel1.Click
        LS2 = True
        Me.PanelAccount_Name.Visible = True
        Me.List2.Visible = True
    End Sub
    Private Sub List1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List1.MouseDoubleClick
        Me.TextCreditAccount.Text = Me.List1.SelectedItem(0).ToString
        LS1 = False
        Me.PanelAccount_Name.Visible = False
        Me.List1.Visible = False
    End Sub
    Private Sub List2_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles List2.MouseDoubleClick
        Me.TextCreditAccount1.Text = Me.List2.SelectedItem(0).ToString
        LS2 = False
        Me.PanelAccount_Name.Visible = False
        Me.List2.Visible = False
    End Sub
    Private Sub TextAccount_Name_TextChanged(sender As Object, e As EventArgs) Handles TextAccount_Name.TextChanged
        If LS1 = True Then
            Me.List1.DataSource = GetData(NUpCreditAccount.Value)
            Me.List1.DisplayMember = "account_name"
        ElseIf LS2 = True Then
            Me.List2.DataSource = GetData(NUpCreditAccount1.Value)
            Me.List2.DisplayMember = "account_name"
        End If

        dvAccounts = New DataView
        dvAccounts = dtAccounts.DefaultView
        dvAccounts.RowFilter = "account_name Like '%" + Trim(TextAccount_Name.Text) + "%'"
    End Sub

    Private Sub SEARCHDATASALARIES()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlClient.SqlCommand("SELECT * FROM SALARIES  WHERE SLY2 = '" & Me.ComboEmployeeName.Text & " '" & "AND Month(SLY26) = '" & Month(DateMovementHistory.Text) - 1 & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "SALARIES")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TEXTBasicSalary.EditValue = ds2.Tables(0).Rows(0).Item("SLY4")
            'Me.TEXTExtraValuePercentage.EditValue = ds2.Tables(0).Rows(0).Item("SLY5")
            'Me.TextExtraValue.Text = ds2.Tables(0).Rows(0).Item("SLY6")
            Me.TEXTPremiumValueRatio.EditValue = ds2.Tables(0).Rows(0).Item("SLY7")
            Me.TEXTBonusValue.Text = ds2.Tables(0).Rows(0).Item("SLY8")
            Me.TEXTLncentiveValueRatio.EditValue = ds2.Tables(0).Rows(0).Item("SLY9")
            Me.TEXTLncentiveValue.Text = ds2.Tables(0).Rows(0).Item("SLY10")
            Me.TEXTReward.EditValue = ds2.Tables(0).Rows(0).Item("SLY11")
            Me.TEXTNatureOfWork.EditValue = ds2.Tables(0).Rows(0).Item("SLY12")
            Me.TEXTTransferAllowance.EditValue = ds2.Tables(0).Rows(0).Item("SLY13")
            Me.TEXTHousingAllowance.EditValue = ds2.Tables(0).Rows(0).Item("SLY14")
            Me.TEXTOtherAdditions.EditValue = ds2.Tables(0).Rows(0).Item("SLY15")
            Me.TEXTVariablePay.EditValue = ds2.Tables(0).Rows(0).Item("SLY16")
            Me.TEXTInsurances.EditValue = ds2.Tables(0).Rows(0).Item("SLY17")
            Me.TextSocialSecurity.EditValue = ds2.Tables(0).Rows(0).Item("SLY18")
            Me.TEXTAdvancePayment.EditValue = ds2.Tables(0).Rows(0).Item("SLY19")
            Me.TEXTLateDiscounts.EditValue = ds2.Tables(0).Rows(0).Item("SLY20")
            Me.TEXTAbsenceDiscounts.EditValue = ds2.Tables(0).Rows(0).Item("SLY21")
            Me.TEXTSanctionsDiscounts.EditValue = ds2.Tables(0).Rows(0).Item("SLY22")
            Me.TEXTOtherDiscounts.EditValue = ds2.Tables(0).Rows(0).Item("SLY23")
            Me.TEXTNetSalary.Text = ds2.Tables(0).Rows(0).Item("SLY24")
        Else
            Me.TEXTBasicSalary.EditValue = ""
            Me.TEXTExtraValuePercentage.EditValue = ""
            Me.TextExtraValue.Text = ""
            Me.TEXTPremiumValueRatio.EditValue = ""
            Me.TEXTBonusValue.Text = ""
            Me.TEXTLncentiveValueRatio.EditValue = ""
            Me.TEXTLncentiveValue.Text = ""
            Me.TEXTReward.EditValue = ""
            Me.TEXTNatureOfWork.EditValue = ""
            Me.TEXTTransferAllowance.EditValue = ""
            Me.TEXTHousingAllowance.EditValue = ""
            Me.TEXTOtherAdditions.EditValue = ""
            Me.TEXTVariablePay.EditValue = ""
            Me.TEXTInsurances.EditValue = ""
            Me.TextSocialSecurity.EditValue = ""
            Me.TEXTAdvancePayment.EditValue = ""
            Me.TEXTLateDiscounts.EditValue = ""
            Me.TEXTAbsenceDiscounts.EditValue = ""
            Me.TEXTSanctionsDiscounts.EditValue = ""
            Me.TEXTOtherDiscounts.EditValue = ""
            Me.TEXTNetSalary.Text = ""
        End If
    End Sub
    Private Sub SumAmountEMP()
        Dim F As Boolean
        F = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT CST21 FROM EMPCOST WHERE CST2 = '" & ComboEmployeeName.Text & " '" & " And  CST11> '" & 0 & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "EMPCOST")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TEXTAdvancePayment.EditValue = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TEXTAdvancePayment.EditValue = ""
        End If
        If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
            Me.Label15.Visible = True
            Me.TextCreditAccount1.Visible = True
            Me.Label14.Visible = True
            Me.NUpCreditAccount1.Visible = True
            Me.PicAccountLevel1.Visible = True
        Else
            Me.Label15.Visible = False
            Me.TextCreditAccount1.Visible = False
            Me.Label14.Visible = False
            Me.NUpCreditAccount1.Visible = False
            Me.PicAccountLevel1.Visible = False
        End If
    End Sub
    Private Sub SEARCHEMP()
        Dim F As Boolean
        F = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT CST1 FROM EMPCOST WHERE    CUser='" & CUser & "'and CST2 = '" & ComboEmployeeName.Text & " '" & " And  CST11> '" & 0 & "'", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "EMPCOST")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextCST1.Text = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextCST1.Text = ""
        End If
    End Sub
    Private Sub SEARCHEMPCOSTDETALLS()
        Dim F As Boolean
        F = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT CST1 FROM EMPCOST WHERE    CUser='" & CUser & "'and CST13 = '" & TextMovementSymbol.EditValue & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "EMPCOST")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextAdvanceMovementNumber.Text = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextAdvanceMovementNumber.Text = ""
        End If
    End Sub
    Private Sub SumEMPCOSTDETALLS()
        Dim F As Boolean
        F = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsql2 As New SqlCommand("SELECT DISTINCT Sum(CSDT2 - CSDT4) FROM EMPCOSTDETALLS WHERE CST1 = '" & Me.TextCST1.Text & " '", Consum)
        Dim ds2 As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql2)
        On Error Resume Next
        ds2.Clear()
        Adp1.Fill(ds2, "EMPCOSTDETALLS")
        If ds2.Tables(0).Rows.Count > 0 Then
            Me.TextTotalBalanceAdvancePayment.Text = ds2.Tables(0).Rows(0).Item(0)
        Else
            Me.TextTotalBalanceAdvancePayment.Text = ""
        End If
    End Sub
    Private Sub SaveEMPCOSTDETALLS()
        Try
            Dim N As Double
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSDT) FROM EMPCOSTDETALLS", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()
            Dim N1 As Double
            Dim cmd2 As New SqlClient.SqlCommand("SELECT MAX(CSDT1) FROM EMPCOSTDETALLS", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt1 As Object = cmd2.ExecuteScalar()
            If IsDBNull(resualt1) Then
                N1 = 1
            Else
                N1 = CType(resualt1, Integer) + 1
            End If
            Consum.Close()
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO EMPCOSTDETALLS (CSDT1, CSDT2, CSDT3, CSDT4, CSDT5, CSDT6, CST1) VALUES     (@CSDT1, @CSDT2, @CSDT3, @CSDT4, @CSDT5, @CSDT6, @CST1)", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@CSDT", SqlDbType.Int).Value = Val(N)
                .Parameters.Add("@CSDT1", SqlDbType.Int).Value = Val(N1)
                .Parameters.Add("@CSDT2", SqlDbType.Float).Value = 0
                .Parameters.Add("@CSDT3", SqlDbType.Float).Value = Val(Me.TEXTAdvancePayment.EditValue)
                .Parameters.Add("@CSDT4", SqlDbType.NVarChar).Value = "سداد سلفة موظف"
                .Parameters.Add("@CSDT5", SqlDbType.Date).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@CSDT6", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CST1", SqlDbType.Int).Value = Val(Me.TextCST1.Text)
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSaveEMPCOSTDETALLS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub UPDATEEMPCOSTDETALLS()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim N As Double
            Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSDT) FROM EMPCOSTDETALLS", Consum)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Dim resualt As Object = cmd1.ExecuteScalar()
            If IsDBNull(resualt) Then
                N = 1
            Else
                N = CType(resualt, Integer) + 1
            End If
            Consum.Close()
            Dim SQL As New SqlCommand("Update EMPCOSTDETALLS SET   CSDT2 = @CSDT2, CSDT3 = @CSDT3, CSDT4 = @CSDT4, CSDT5 = @CSDT5, CSDT6 = @CSDT6, CST1 = @CST1 WHERE CSDT6 = '" & Me.TextMovementSymbol.EditValue & " '", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                '.Parameters.Add("@CSDT", SqlDbType.Int).Value = N
                .Parameters.Add("@CSDT2", SqlDbType.Float).Value = 0
                .Parameters.Add("@CSDT3", SqlDbType.Float).Value = Val(Me.TEXTAdvancePayment.EditValue)
                .Parameters.Add("@CSDT4", SqlDbType.NVarChar).Value = "سداد سلفة موظف"
                .Parameters.Add("@CSDT5", SqlDbType.Date).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@CSDT6", SqlDbType.NVarChar).Value = Me.TextMovementSymbol.EditValue
                .Parameters.Add("@CST1", SqlDbType.Int).Value = Val(Me.TextCST1.Text)
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorUPDATEEMPCOSTDETALLS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub DELETEDAEMPCOSTDETALLS()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("EMPCOSTDETALLS", "CSDT", Me.TextAdvanceMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub FundBalance()
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH1) FROM CASHIER", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
        Consum.Close()
        Me.TextFundBalance.Text = Format(Val(SumAmounTOTALBALANCECASHIER11(CUser, Me.ComboCB1.Text, N)), "0.000")
    End Sub
    Private Sub AutoEx()
        Dim ExResult As String
        ExResult = "حركة رقم" & " " & ":" & " " & Me.TEXTID.EditValue & " " & "بتاريخ" & " " & ":" & " " & Me.DateMovementHistory.Text & " "
        ExResult += "للموظف" & " " & ":" & " " & Me.ComboEmployeeName.Text & " " & "عن شهر" & " " & ":" & " " & Me.ComboMonths.Text & vbNewLine
        Me.LabelAutoEx.Text = ExResult
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCheckDrawerName.SelectedIndexChanged
        Try
            Dim Adp2 As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsq2 As New SqlCommand("SELECT EMP1  FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboCheckDrawerName.Text & "'", Consum)
            Dim ds2 As New DataSet
            Adp2 = New SqlClient.SqlDataAdapter(strsq2)
            ds2.Clear()
            Adp2.Fill(ds2)
            If ds2.Tables(0).Rows.Count > 0 Then
                Me.TextCheckDrawerCode.Text = ds2.Tables(0).Rows(0).Item(0)
            Else
                Me.TextCheckDrawerCode.Text = ""
            End If
            Adp2.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboCheckDrawerName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub DELETEDATAempsolf()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("CASHIER", "CSH1", Me.TextFundMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATBANK()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("Checks", "IDCH", Me.TextCheckMovementNumber, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVES", "MOV2", Me.TextMovementRestrictions, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub DELETEDATMOVESDATA1()
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            MYDELETERECORD("MOVESDATA", "MOV2", Me.MOVESFalseDELET, Me.BS, True)
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Sub AccountingprocedureA()
        If Accountingprocedure = True Then
            Connection.ACONET1.Clear()
            Me.ACONETA.Clear()
            Connection.ACONET1.Add(String.Concat(New String() {Me.ComboDebitAccount.Text}))
            If Me.ComboPaymentMethod1.Text = "نقدا_شيك" Then
                Connection.ACONET1.Add("الصندوق")
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
            Else
                Connection.ACONET1.Add(String.Concat(New String() {Me.TextCreditAccount.Text}))
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
    Private Sub ButtonTransferofAccounts_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTransferofAccounts.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If TransferofAccounts = False Then
                MsgBox("عفوا ..غير مسموح لك بترحيل السجلات", 16, "تنبيه")
                Exit Sub
            End If
            If Me.ComboDebitAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب المدين فارغ", 16, "تنبيه")
                Exit Sub
            End If
            If Me.TextCreditAccount.Text = "" Then
                MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن فارغ", 16, "تنبيه")
                Exit Sub
            End If
            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                Me.Label15.Visible = True
                Me.TextCreditAccount1.Visible = True
                Me.Label14.Visible = True
                Me.NUpCreditAccount1.Visible = True
                Me.PicAccountLevel1.Visible = True
                If Me.TextCreditAccount1.Text = "" Then
                    MsgBox("عفوا .. لا يمكن ترك حقل حساب الدائن1 فارغ", 16, "تنبيه")
                    Exit Sub
                End If
            Else
                Me.Label15.Visible = False
                Me.TextCreditAccount1.Visible = False
                Me.Label14.Visible = False
                Me.NUpCreditAccount1.Visible = False
                Me.PicAccountLevel1.Visible = False
            End If
            Me.Button2_Click(sender, e)
            Dim resault As Integer
            If OBCHK8 = True Then
                If Me.CheckTransferAccounts.Checked = False Then
                    resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                    If resault = vbYes Then
                        Me.CheckTransferAccounts.Checked = True
                        Me.CheckAdvanceDeferral.Checked = True
                        If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                            If Val(Me.TextAdvanceMovementNumber.Text) = 0 Then
                                Me.SaveEMPCOSTDETALLS()
                            Else
                                Me.UPDATEEMPCOSTDETALLS()
                            End If
                        End If
                        TransforAccounts()
                        Me.UPDATERECORD()
                        Click3 = True
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
                        If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                            If Me.TextAdvanceMovementNumber.Text = 0 Then
                                Me.SaveEMPCOSTDETALLS()
                            Else
                                Me.UPDATEEMPCOSTDETALLS()
                            End If
                        End If
                        TransforAccounts()
                        Me.UPDATERECORD()
                        Click4 = True
                        AccountingprocedureA()
                    Else
                        resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.DELETEDATMOVESDATA()
                            Me.DELETEDATMOVESDATA1()
                            Me.DELETEDAEMPCOSTDETALLS()
                            Me.CheckTransferAccounts.Checked = False
                            Me.CheckAdvanceDeferral.Checked = False
                            Me.UPDATERECORD()
                            Click5 = True
                        Else
                            Exit Sub
                        End If
                    End If
                End If
            Else
                If Me.ComboPaymentMethod1.Text = "نقدا" Then
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندزق رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            Me.CheckAdvanceDeferral.Checked = True
                            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                                If Val(Me.TextAdvanceMovementNumber.Text) = 0 Then
                                    Me.SaveEMPCOSTDETALLS()
                                Else
                                    Me.UPDATEEMPCOSTDETALLS()
                                End If
                            End If
                            TransforAccounts()
                            Me.UPDATERECORD()
                            Click3 = True
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
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                DELETEDATBANK()
                            End If
                            'If Me.TextBox9.Text = 0 Then
                            '    MsgBox("لايوجد سجلات في سلفة الموظفين", 16, "تنبية")
                            'Else
                            '    Me.DELETEDAEMPCOSTDETALLS()
                            'End If
                            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                                If Me.TextAdvanceMovementNumber.Text = 0 Then
                                    Me.SaveEMPCOSTDETALLS()
                                Else
                                    Me.UPDATEEMPCOSTDETALLS()
                                End If
                            End If
                            TransforAccounts()
                            Me.UPDATERECORD()
                            Click4 = True
                            AccountingprocedureA()
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندوق ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDAEMPCOSTDETALLS()
                                Me.CheckTransferAccounts.Checked = False
                                Me.CheckAdvanceDeferral.Checked = False
                                Me.UPDATERECORD()
                                Click5 = True
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '======================================================================================================
                ElseIf Me.ComboPaymentMethod1.Text = "شيك" Then
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
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            Me.CheckAdvanceDeferral.Checked = True
                            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                                If Me.TextAdvanceMovementNumber.Text = 0 Then
                                    Me.SaveEMPCOSTDETALLS()
                                Else
                                    Me.UPDATEEMPCOSTDETALLS()
                                End If
                            End If
                            TransforAccounts()
                            Me.UPDATERECORD()
                            Click6 = True
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
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                                If Me.TextAdvanceMovementNumber.Text = 0 Then
                                    Me.SaveEMPCOSTDETALLS()
                                Else
                                    Me.UPDATEEMPCOSTDETALLS()
                                End If
                            End If
                            TransforAccounts()
                            Me.UPDATERECORD()
                            Click7 = True
                            AccountingprocedureA()
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الشيكات  ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDATBANK()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferAccounts.Checked = False
                                Me.UPDATERECORD()
                                Click8 = True
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                    '=============================================================================================================
                ElseIf Me.ComboPaymentMethod1.Text = "نقدا_شيك" Then
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
                    If Me.CheckTransferAccounts.Checked = False Then
                        resault = MessageBox.Show("سبنم ترحيل السجل الحالى الى القيود اليومية و الصندوق و الشيكات رفم " & Me.TextMovementSymbol.EditValue, "ترحيل سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                        If resault = vbYes Then
                            Me.CheckTransferAccounts.Checked = True
                            Me.CheckAdvanceDeferral.Checked = True
                            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                                If Me.TextAdvanceMovementNumber.Text = 0 Then
                                    Me.SaveEMPCOSTDETALLS()
                                Else
                                    Me.UPDATEEMPCOSTDETALLS()
                                End If
                            End If
                            TransforAccounts()
                            Me.UPDATERECORD()
                            Click9 = True
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
                            If Me.TextCheckMovementNumber.Text = "" Then
                                MsgBox("لايوجد سجلات في الشيكات", 16, "تنبية")
                            Else
                                Me.DELETEDATBANK()
                            End If
                            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                                If Me.TextAdvanceMovementNumber.Text = 0 Then
                                    Me.SaveEMPCOSTDETALLS()
                                Else
                                    Me.UPDATEEMPCOSTDETALLS()
                                End If
                            End If
                            TransforAccounts()
                            Me.UPDATERECORD()
                            Click10 = True
                            AccountingprocedureA()
                        Else
                            resault = MessageBox.Show("هل تريد حذف السجل الحالى من جدول الصندزق و الشيكات ", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                            If resault = vbYes Then
                                Me.DELETEDAEMPCOSTDETALLS()
                                Me.DELETEDATBANK()
                                Me.DELETEDATAempsolf()
                                Me.DELETEDATMOVESDATA()
                                Me.DELETEDATMOVESDATA1()
                                Me.CheckTransferAccounts.Checked = False
                                Me.UPDATERECORD()
                                Click11 = True
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
            End If
            Me.BS.EndEdit()
            Me.RowCount = Me.BS.Count
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicMovementRestrictions.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmDailyrestrictions
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY MOV2", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
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
    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicFundMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmBanks5
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY CSH1", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
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

    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicCheckMovementNumber.Click
        Dim ds As New DataSet
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FrmChecks
        Try
            ds.EnforceConstraints = False
            Dim str As New SqlCommand("SELECT IDCH FROM Checks WHERE   CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'ORDER BY IDCH", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder33 As New SqlClient.SqlCommandBuilder(SqlDataAdapter1)
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
    Private Sub PicAdvanceMovementNumber_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicAdvanceMovementNumber.Click
        Dim f As New FrmEmpCost
        Try
            f.TB1 = Me.TextCST1.Text
            f.Show()
            f.DanLOd()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ComboEmployeeName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboEmployeeName.SelectedIndexChanged
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT EMP1,EMP21,EMP23   FROM EMPLOYEES WHERE EMP2 ='" & Me.ComboEmployeeName.Text & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            Dim ExtraValuePercentage As Double = 0
            Me.TEXTExtraValuePercentage.EditValue = 0
            If ds.Tables(0).Rows.Count > 0 Then
                Me.TEXTEmployeeCode.EditValue = ds.Tables(0).Rows(0).Item(0)
                Me.TEXTAdvancePayment.EditValue = ds.Tables(0).Rows(0).Item(1)
                MaxMonthSly()
                If SumOvertimeHours() > 0 Then
                    ExtraValuePercentage = Format((Me.TEXTNetSalary.Text / 208) * 1.5, "0.000")
                Else
                    ExtraValuePercentage = 0
                End If
                Me.TEXTExtraValuePercentage.EditValue = ExtraValuePercentage
            Else
                Me.TEXTEmployeeCode.EditValue = 0
                Me.TEXTAdvancePayment.EditValue = 0
                Me.TEXTExtraValuePercentage.EditValue = 0
            End If

            Adp.Dispose()
            Consum.Close()
            Me.SumAmountEMP()
            Me.SEARCHEMP()
            Me.SumEMPCOSTDETALLS()

            'Dim resault As Integer
            'resault = MessageBox.Show("هل ترغب باضافةراتب الشهر السابق للموظف " & Me.ComboEmployeeName.Text, "المرتبات", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            'If resault = vbYes Then
            '    Me.SEARCHDATASALARIES()
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboEmployeeName_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End Try

    End Sub

    Private Function SumOvertimeHours() As Double
        Try
            FormatYear = Date.Parse(DateMovementHistory.Value).ToString("yyyy")
            FormatMonth = Date.Parse(DateMovementHistory.Value).ToString("MM")
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT Sum(EWRK7) AS SumOverTime  FROM EXTRAWORK WHERE EWRK8 = '" & Me.TEXTEmployeeCode.EditValue & "'And Year(DateEwrk) ='" & FormatYear & "' And  MONTH(DateEwrk) ='" & FormatMonth & "'", Consum)
            '                                                                                    (EWRK8 = '3') AND (YEAR(DateEwrk) = '2020') AND (MONTH(DateEwrk) = '09')
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                SumOvertimeHours = Format(ds.Tables(0).Rows(0).Item(0), "0.00")
            Else
                SumOvertimeHours = 0
            End If
            Adp.Dispose()
            Consum.Close()
            TextSumOvertime.EditValue = SumOvertimeHours
            'Return SumOvertimeHours
        Catch ex As Exception
            'MessageBox.Show(ex.Message, "ErrorSumOvertimeHours", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return SumOvertimeHours
        End Try
    End Function

    Private Sub MaxMonthSly()
        Try
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim strsql As New SqlCommand("SELECT Max(Year(DateEwrk)) AS MaxYear,  Max(DateEwrk) AS MaxM FROM EXTRAWORK WHERE EWRK8 = '" & Me.TEXTEmployeeCode.EditValue & "'", Consum)
            Dim ds As New DataSet
            Adp = New SqlClient.SqlDataAdapter(strsql)
            ds.Clear()
            Adp.Fill(ds)
            If Not IsDBNull(ds.Tables(0).Rows(0).Item(0)) Then
                MaxYear = ds.Tables(0).Rows(0).Item(0)
                MaxMonth = ds.Tables(0).Rows(0).Item(1)
            End If
            Adp.Dispose()
            Consum.Close()
            'Return MaxMonthSly()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorMaxMonthSly", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Private Sub OptionsTransforAccounts()
    '    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ComboDebitAccount.Text, 1)
    '    DebitAccount_No = ID_Nam
    '    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ComboDebitAccount.Text, 1)
    '    DebitAccount_Cod = ID_Nam

    '    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount1.Text, 1)
    '    CredAccount_NO = ID_Nam
    '    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCreditAccount1.Text, 1)
    '    CredAccount_Cod = ID_Nam

    '    Select Case Me.ComboPaymentMethod1.Text
    '        Case "نقدا"
    '            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount.Text, 1)
    '            Accounts_no = ID_Nam
    '            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCreditAccount.Text, 1)
    '            CodAccount = ID_Nam
    '        Case "شيك"
    '            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount.Text, 1)
    '            ChecksAccount_NO = ID_Nam
    '            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCreditAccount.Text, 1)
    '            ChecksAccount_Cod = ID_Nam
    '        Case "نقدا_شيك"
    '            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", Module1.CB2.ToString, 1)
    '            Accounts_no = ID_Nam
    '            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", Module1.CB2.ToString, 1)
    '            CodAccount = ID_Nam

    '            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", TextCreditAccount.Text, 1)
    '            ChecksAccount_NO = ID_Nam
    '            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", TextCreditAccount.Text, 1)
    '            ChecksAccount_Cod = ID_Nam
    '    End Select
    'End Sub

    Private Sub Check_OptionsTransforAccounts_CheckedChanged(sender As Object, e As EventArgs) Handles Check_OptionsTransforAccounts.CheckedChanged
        If Check_OptionsTransforAccounts.Checked = True Then
            resault = MessageBox.Show("هل تريد إلغاء تحدبث الحسابات الافتراضية ", "تحدبث الحسابات", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                OptionsTransforAccounts(ComboPaymentMethod1.Text, ComboDebitAccount.Text, TextCreditAccount.Text, TextCreditAccount1.Text)
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

        nem = "صرف رواتب الموظفين نقدا "
        nem1 = "صرف رواتب الموظفين نقدا " & " " & Me.ComboEmployeeName.Text
        nem2 = "صرف رواتب الموظفين بيموجب مستند رقم " & " " & Me.TextCheckNumber.Text
        nem3 = "تسديد سلفة الموظفين"
        nem4 = "اشتراكات الضمان الاجتماعي"
        nem5 = "اشتراكات الضمان الاجتماعي مستقة"
        PMO2 = 1
        Dim NewCredAccount_NO As Integer
        Dim NewCredAccount_Cod As Integer

        Dim NewCalculatingSocialSecurityContributionsDue_NO As Integer
        Dim CalculatingSocialSecurityContributionsDue_Name As String
        Dim CalculatingSocialSecurityContributionsDue_Cod As Integer

        Dim NewSocialSecurityContributions_NO As Integer
        Dim SocialSecurityContributions_Name As String
        Dim SocialSecurityContributions_Cod As Integer

        NewCalculatingSocialSecurityContributionsDue_NO = keyAccounts.GetValue("CalculatingSocialSecurityContributionsDue_No", CalculatingSocialSecurityContributionsDue_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", NewCalculatingSocialSecurityContributionsDue_NO, 1)
        CalculatingSocialSecurityContributionsDue_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", NewCalculatingSocialSecurityContributionsDue_NO, 1)
        CalculatingSocialSecurityContributionsDue_Cod = ID_Nam

        NewSocialSecurityContributions_NO = keyAccounts.GetValue("SocialSecurityContributions_No", SocialSecurityContributions_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", NewSocialSecurityContributions_NO, 1)
        SocialSecurityContributions_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", NewSocialSecurityContributions_NO, 1)
        SocialSecurityContributions_Cod = ID_Nam


        NewCredAccount_NO = keyAccounts.GetValue("EmployeeAdvanceAccount_No", EmployeeAdvanceAccount_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", NewCredAccount_NO, 1)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", NewCredAccount_NO, 1)
        NewCredAccount_Cod = ID_Nam

        GetFundAccount_No(ModuleGeneral.CB2)
        Accounts_NO = FundAccount_No

        GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2, 1)
        CodAccount = ID_Nam
        AssociationDeductionsPercentage_P = Format((Val(Me.TEXTBasicSalary.EditValue) * AssociationDeductionsPercentage / 100), "0.000")
        Dim mx As Double = Val(TEXTNetSalary.Text) + Val(TEXTAdvancePayment.EditValue) + Val(TextSocialSecurity.EditValue)
        Dim DeductionsPercentage As Double = Val(AssociationDeductionsPercentage_P) + Val(TextSocialSecurity.EditValue)

        SEARCHDATA.MAXIDMOVES()
        'MaxIDMovesMov1()
        'MaxIDMovesMov2()

        TransferToAccounts_Check = True

        If Check_OptionsTransforAccounts.Checked = True Then
            OptionsTransforAccounts(ComboPaymentMethod1.Text, ComboDebitAccount.Text, TextCreditAccount.Text, TextCreditAccount1.Text)
        End If

        AccountingEntries(T1, T2, DateMovementHistory.Value.ToString("yyyy-MM-dd"), nem, False, Val(mx), Val(mx), T3, "صرف", "ES", TextMovementSymbol.EditValue, False)
        If OBCHK8 = True Then
            DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(mx), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            DetailsAccountingEntries(PMO2 + 1, TextCreditAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                DetailsAccountingEntries(PMO2 + 2, TextCreditAccount1.Text, NewCredAccount_NO, 0, TEXTAdvancePayment.EditValue, nem3, NewCredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
            End If
        Else
            Select Case Me.ComboPaymentMethod1.Text
                Case "نقدا"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(mx), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, SocialSecurityContributions_Name, NewSocialSecurityContributions_NO, AssociationDeductionsPercentage_P, 0, nem4, SocialSecurityContributions_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextCreditAccount1.Text, NewCredAccount_NO, 0, TEXTAdvancePayment.EditValue, nem3, NewCredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 4, CalculatingSocialSecurityContributionsDue_Name, NewCalculatingSocialSecurityContributionsDue_NO, 0, DeductionsPercentage, nem5, CalculatingSocialSecurityContributionsDue_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)
                Case "شيك"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(mx), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, SocialSecurityContributions_Name, NewSocialSecurityContributions_NO, AssociationDeductionsPercentage_P, 0, nem4, SocialSecurityContributions_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    DetailsAccountingEntries(PMO2 + 2, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                        DetailsAccountingEntries(PMO2 + 3, TextCreditAccount1.Text, NewCredAccount_NO, 0, TEXTAdvancePayment.EditValue, nem3, NewCredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 4, CalculatingSocialSecurityContributionsDue_Name, NewCalculatingSocialSecurityContributionsDue_NO, 0, DeductionsPercentage, nem5, CalculatingSocialSecurityContributionsDue_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)
                Case "نقدا_شيك"
                    DetailsAccountingEntries(PMO2, ComboDebitAccount.Text, DebitAccount_No, Val(mx), 0, nem, DebitAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 1, SocialSecurityContributions_Name, NewSocialSecurityContributions_NO, AssociationDeductionsPercentage_P, 0, nem4, SocialSecurityContributions_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)

                    DetailsAccountingEntries(PMO2 + 3, ModuleGeneral.CB2.ToString, Accounts_NO, 0, TextFundValue.EditValue, nem1, CodAccount, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    DetailsAccountingEntries(PMO2 + 4, TextCreditAccount.Text, ChecksAccount_NO, 0, TextValueOfCheck.EditValue, nem2, ChecksAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                        DetailsAccountingEntries(PMO2 + 5, TextCreditAccount1.Text, NewCredAccount_NO, 0, TEXTAdvancePayment.EditValue, nem3, NewCredAccount_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    Else
                        PMO2 = Val(PMO2 - 1)
                    End If
                    DetailsAccountingEntries(PMO2 + 6, CalculatingSocialSecurityContributionsDue_Name, NewCalculatingSocialSecurityContributionsDue_NO, 0, DeductionsPercentage, nem5, CalculatingSocialSecurityContributionsDue_Cod, TextMovementSymbol.EditValue, TEXTID.EditValue, False, T2)
                    Insert_CASHIER(DateMovementHistory.Value.ToString("yyyy-MM-dd"), "صرف", TextMovementSymbol.EditValue, 0, TextFundValue.EditValue, Me.Text,
                                                                nem1, False, TEXTID.EditValue & "0",
                                                                False, True, ComboCB1.Text, CB2)
                    Insert_Checks(TextCheckNumber.Text, DateMovementHistory.Value.ToString("yyyy-MM-dd"), CheckDate.Value.ToString("yyyy-MM-dd"), "0",
                               TextValueOfCheck.EditValue, ComboCheckDrawerName.Text, TextCheckDrawerCode.Text, "صرف", T2, TextBN3.Text, BN4, True, TextMovementSymbol.EditValue, False, ComboCB1.Text, ComboBN2.Text)

            End Select
        End If

    End Sub


    Private Sub AccountsEnquiry()
        On Error Resume Next
        DebitAccount_Name = Nothing
        CredAccount_Name = Nothing
        FundAccount_Name = Nothing
        ChecksAccount_Name = Nothing



        Dim NewCredAccount_NO As Integer
        Dim NewCredAccount_Name As String
        Dim NewCredAccount_Cod As Integer
        NewCredAccount_NO = keyAccounts.GetValue("EmployeeAdvanceAccount_No", EmployeeAdvanceAccount_No)
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", NewCredAccount_NO, 1)
        NewCredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", NewCredAccount_NO, 1)
        NewCredAccount_Cod = ID_Nam


        GetFundAccount_No(ModuleGeneral.CB2)
        GetUpAccounts(ComboPaymentMethod1.Text, AccountNoAktevd)

        ComboDebitAccount.Text = DebitAccount_Name
        NUpComboDebitAccount.Value = DebitAccount_Cod

        bincl = Format(Val(Me.TextFundValue.EditValue) + Val(Me.TextValueOfCheck.EditValue), "0.000")
        Select Case Me.ComboPaymentMethod1.Text
            Case "نقدا"
                Me.TextFundValue.EditValue = Val(Me.TEXTNetSalary.Text)
                Me.TextValueOfCheck.EditValue = 0
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = False
                Me.GroupCHKS.Enabled = False
                Me.GroupCHKS1.Enabled = False
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = FundAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod

                If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                    TextCreditAccount1.Text = NewCredAccount_Name
                    NUpCreditAccount1.Value = NewCredAccount_Cod
                Else
                    TextCreditAccount1.Text = Nothing
                    NUpCreditAccount1.Enabled = False
                    PicAccountLevel1.Enabled = False
                End If

            Case "شيك"
                Me.TextFundValue.EditValue = 0
                Me.TextValueOfCheck.EditValue = Val(Me.TEXTNetSalary.Text)
                Me.TextFundValue.Enabled = False
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True

                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
                If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                    TextCreditAccount1.Text = NewCredAccount_Name
                    NUpCreditAccount1.Value = NewCredAccount_Cod
                Else
                    TextCreditAccount1.Text = Nothing
                    NUpCreditAccount1.Enabled = False
                    PicAccountLevel1.Enabled = False
                End If
            Case "نقدا_شيك"
                Me.TextFundValue.EditValue = Val(Me.TEXTNetSalary.Text) - Val(Me.TextValueOfCheck.EditValue)
                Me.TextValueOfCheck.EditValue = Val(Me.TEXTNetSalary.Text) - Val(Me.TextFundValue.EditValue)
                Me.TextFundValue.Enabled = True
                Me.TextValueOfCheck.Enabled = True
                Me.GroupCHKS.Enabled = True
                Me.GroupCHKS1.Enabled = True
                LabelFundBalance.Text = "رصيد" & " " & FundAccount_Name & " " & ":"
                TextCreditAccount.Text = ChecksAccount_Name
                NUpCreditAccount.Value = ChecksAccount_Cod
                If Val(Me.TEXTAdvancePayment.EditValue) > 0 Then
                    TextCreditAccount1.Text = NewCredAccount_Name
                    NUpCreditAccount1.Value = NewCredAccount_Cod
                Else
                    TextCreditAccount1.Text = Nothing
                    NUpCreditAccount1.Enabled = False
                    PicAccountLevel1.Enabled = False
                End If
        End Select
    End Sub
    Private Sub ComboPaymentMethod1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboPaymentMethod1.SelectedIndexChanged
        AccountsEnquiry()
    End Sub
    Private Sub ButtonUpdateA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUpdateA.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PicBox1.Visible = True
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        SEARCHDATA.SEARCHAccount_no(Me.ComboDebitAccount.Text)
        Me.account_noF = SEARCHDATA.account_no
        Me.ACCF = SEARCHDATA.ACC
        SEARCHDATA.account_name = SEARCHDATA.account_name
        SEARCHDATA.MAXIDMOVES()
        SEARCHDATA.SEARCHMOVESFalse(Me.TextMovementSymbol.EditValue)
        Me.TextMovementRestrictions.Text = SEARCHDATA.MOV1C

        SEARCHDATA.SEARCHMOVESFalseDELET(Me.TextMovementSymbol.EditValue)
        Me.MOVESFalseDELET.Text = SEARCHDATA.MOVDELET

        SEARCHDATA.SEARCHCASHIER(Me.TextMovementSymbol.EditValue, Me.TEXTID.EditValue)
        Me.TextFundMovementNumber.Text = SEARCHDATA.CSH1
        SEARCHDATA.SEARCHDIDChecks(Me.TextMovementSymbol.EditValue)
        Me.TextCheckMovementNumber.Text = SEARCHDATA.IDCH
        SEARCHDATA.SEARCHEMPCOSTDETALLS(Me.TextMovementSymbol.EditValue)
        Me.TextAdvanceMovementNumber.Text = SEARCHDATA.CSDT
    End Sub

    Private Sub ComboCB1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboCB1.SelectedIndexChanged
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Adp As SqlClient.SqlDataAdapter
        On Error Resume Next
        Dim strsql As New SqlCommand("SELECT CB2    FROM CashBox WHERE CB1 ='" & Me.ComboCB1.Text & "'", Consum)
        Dim ds As New DataSet
        Adp = New SqlClient.SqlDataAdapter(strsql)
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