Imports System.ComponentModel
Imports DevExpress.XtraSplashScreen

Public Class FrmOptions
    ReadOnly Startup As String = "Software\Microsoft\Windows\CurrentVersion\Run"
    Dim fs As IO.FileStream
    Dim sw As IO.StreamWriter

    Private Sub FrmOPTIONS_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    Me.ButtonAPPLY_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmOPTIONS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'On Error Resume Next
        Me.BackgroundImage = img
        Me.TabP1.BackgroundImage = img
        Me.TabP2.BackgroundImage = img
        Me.TabP3.BackgroundImage = img
        Me.TabP4.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        Me.BackgroundWorker1.WorkerSupportsCancellation = True
        Me.BackgroundWorker1.WorkerReportsProgress = True
        Me.BackgroundWorker1.RunWorkerAsync()

        'ItemsIncludeExpirationDate

    End Sub

    Private Sub ButtonAPPLY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAPPLY.Click
        On Error Resume Next

        'If Me.ComboBox1.Text = "YES" Then
        'key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Startup, True)
        'key.SetValue("Arabic(Jordan)", Application.ExecutablePath)
        '    mykey.SetValue("UP", "YES")
        'ElseIf Me.ComboBox1.Text = "NO" Then
        '    key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Startup, True)
        '    key.DeleteValue("Arabic(Jordan)")
        '    mykey.SetValue("UP", "NO")
        'End If
        If Me.CheckBackup1.Checked = "True" Then
            mykey.SetValue("BACKUP", "True")
        ElseIf Me.CheckBackup1.Checked = "False" Then
            mykey.SetValue("BACKUP", "False")
        End If
        If Me.CheckBackup.Checked = "True" Then
            mykey.SetValue("BACKUPTIME", "True")
            mykey.SetValue("BACKUPCOMBO", Val(Me.ComboMinute.Text))
        ElseIf Me.CheckBackup.Checked = "False" Then
            mykey.SetValue("BACKUPTIME", "False")
        End If
        If Me.CheckpreviousFiscalYear.Checked = "True" Then
            mykey.SetValue("FiscalYear", "True")
            mykey.SetValue("FiscalYearCOMBO", Val(Me.CombopreviousFiscalYear.Text))
        ElseIf Me.CheckpreviousFiscalYear.Checked = "False" Then
            mykey.SetValue("FiscalYear", "False")
        End If
        If Me.CheckRunprogram.Checked = "True" Then
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Startup, True)
            key.SetValue("JordanTeam1", Application.ExecutablePath)
            mykey.SetValue("UP", "True")
        ElseIf Me.CheckRunprogram.Checked = "False" Then
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(Startup, True)
            key.DeleteValue("JordanTeam1")
            mykey.SetValue("UP", "False")
        End If
        If Me.CheckTurnNewsTicker.Checked = "True" Then
            mykey.SetValue("NEWEVENTS", "True")
        ElseIf Me.CheckTurnNewsTicker.Checked = "False" Then
            mykey.SetValue("NEWEVENTS", "False")
        End If

        If Me.CheckShowToolbar.Checked = "True" Then
            mykey.SetValue("TBAR", "True")
        ElseIf Me.CheckShowToolbar.Checked = "False" Then
            mykey.SetValue("TBAR", "False")
        End If
        If Me.CheckShowNewsTicker.Checked = "True" Then
            mykey.SetValue("TNEWS", "True")
        ElseIf Me.CheckShowNewsTicker.Checked = "False" Then
            mykey.SetValue("TNEWS", "False")
        End If
        If Me.CheckShowProgramName.Checked = "True" Then
            mykey.SetValue("eplor", "True")
        ElseIf Me.CheckShowProgramName.Checked = "False" Then
            mykey.SetValue("eplor", "False")
        End If
        If Me.CheckShowAlertsScreenAndBalanceScreen.Checked = "True" Then
            mykey.SetValue("SHOWMOMENT", "True")
        ElseIf Me.CheckShowAlertsScreenAndBalanceScreen.Checked = "False" Then
            mykey.SetValue("SHOWMOMENT", "False")
        End If
        If Me.CheckShowTimetable.Checked = "True" Then
            mykey.SetValue("SHOWPROMISED", "True")
        ElseIf Me.CheckShowTimetable.Checked = "False" Then
            mykey.SetValue("SHOWPROMISED", "False")
        End If
        If Me.ChkPD.Checked = "True" Then
            mykey.SetValue("ItemsIncludeExpirationDate", "True")
        ElseIf Me.ChkPD.Checked = "False" Then
            mykey.SetValue("ItemsIncludeExpirationDate", "False")
        End If
        If Me.ComboDefaultLanguage.Text = "ARABIC" Then
            mykey.SetValue("LANGUAGE", "ARABIC")
        ElseIf Me.ComboDefaultLanguage.Text = "ENGLISH" Then
            mykey.SetValue("LANGUAGE", "ENGLISH")
        End If

        If Me.ComboImageExe.Text = ".png" Then
            mykey.SetValue("ImageExe", ".png")
        ElseIf Me.ComboImageExe.Text = ".jpeg" Then
            mykey.SetValue("ImageExe", ".jpeg")
        ElseIf Me.ComboImageExe.Text = ".TIFF" Then
            mykey.SetValue("ImageExe", ".TIFF")
        End If


        If Me.RA.Checked = True Then
            mykey.SetValue("FIFO", True)
        Else
            mykey.SetValue("FIFO", False)
        End If
        If Me.RB.Checked = True Then
            mykey.SetValue("LIFO", True)
        Else
            mykey.SetValue("LIFO", False)
        End If

        If Me.RC.Checked = True Then
            mykey.SetValue("AVG", True)
        Else
            mykey.SetValue("AVG", False)
        End If


        If Me.Ob1.Checked = True Then
            mykey.SetValue("Openingbalance1", True)
        Else
            mykey.SetValue("Openingbalance1", False)
        End If
        If Me.Ob2.Checked = True Then
            mykey.SetValue("Openingbalance2", True)
        Else
            mykey.SetValue("Openingbalance2", False)
        End If
        If Me.Ob3.Checked = True Then
            mykey.SetValue("Openingbalance3", True)
        Else
            mykey.SetValue("Openingbalance3", False)
        End If
        If Me.Ob4.Checked = True Then
            mykey.SetValue("Openingbalance4", True)
        Else
            mykey.SetValue("Openingbalance4", False)
        End If
        If Me.Ob5.Checked = True Then
            mykey.SetValue("Openingbalance5", True)
        Else
            mykey.SetValue("Openingbalance5", False)
        End If
        If Me.Ob6.Checked = True Then
            mykey.SetValue("Openingbalance6", True)
        Else
            mykey.SetValue("Openingbalance6", False)
        End If
        If Me.Ob7.Checked = True Then
            mykey.SetValue("Openingbalance7", True)
        Else
            mykey.SetValue("Openingbalance7", False)
        End If
        If Me.Ob8.Checked = True Then
            mykey.SetValue("Openingbalance8", True)
        Else
            mykey.SetValue("Openingbalance8", False)
        End If
        If Me.Ob9.Checked = True Then
            mykey.SetValue("Openingbalance9", True)
        Else
            mykey.SetValue("Openingbalance9", False)
        End If
        If Me.Ch1.Checked = True Then
            mykey.SetValue("CHBO", True)
            mykey.SetValue("SHOWChecksIN", Me.Checks.Value)
            ChecksIN = Me.Checks.Value
        Else
            mykey.SetValue("CHBO", False)
            mykey.SetValue("SHOWChecksIN", "10")
            ChecksIN = Me.Checks.Value
        End If
        If Me.Ch2.Checked = True Then
            mykey.SetValue("CHBO1", True)
            mykey.SetValue("SHOWCategoriesIN", Me.Categories.Value)
            CategoriesIN = Me.Categories.Value
        Else
            mykey.SetValue("CHBO1", False)
            mykey.SetValue("SHOWCategoriesIN", "10")
            CategoriesIN = Me.Categories.Value
        End If
        If Me.Ch3.Checked = True Then
            mykey.SetValue("CHBO2", True)
            mykey.SetValue("SHOWPaymentsIN", Me.Payments.Value)
            PaymentsIN = Me.Payments.Value
        Else
            mykey.SetValue("CHBO2", False)
            mykey.SetValue("SHOWPaymentsIN", "10")
            PaymentsIN = Me.Payments.Value
        End If

        If Me.LabelMYFOLDER.Text <> "" Then
            mykey.SetValue("MYFOLDER", LabelMYFOLDER.Text)
        Else
            mykey.SetValue("MYFOLDER", MYFOLDER)
        End If
        If Me.CHKCI1.Checked = True Then
            mykey.SetValue("CHKCI", True)
        Else
            mykey.SetValue("CHKCI", False)
        End If

        URL = Me.TxtURL.Text.Trim
        URL1 = Me.TxtURL1.Text.Trim
        URL2 = Me.TxtURL2.Text.Trim

        fs = New IO.FileStream(Application.StartupPath & "/URL.txt", IO.FileMode.Create)
        sw = New IO.StreamWriter(fs)
        sw.WriteLine(Me.TxtURL.Text.Trim)
        sw.Close()
        fs.Close()

        fs = New IO.FileStream(Application.StartupPath & "/URL1.txt", IO.FileMode.Create)
        sw = New IO.StreamWriter(fs)
        sw.WriteLine(Me.TxtURL1.Text.Trim)
        sw.Close()
        fs.Close()


        fs = New IO.FileStream(Application.StartupPath & "/URL2.txt", IO.FileMode.Create)
        sw = New IO.StreamWriter(fs)
        sw.WriteLine(Me.TxtURL2.Text.Trim)
        sw.Close()
        fs.Close()
        mykey.SetValue("URL", Me.TxtURL.Text.Trim)
        mykey.SetValue("URL1", Me.TxtURL1.Text.Trim)
        mykey.SetValue("URL2", Me.TxtURL2.Text.Trim)

        mykey.SetValue("FolderImageName", Me.TextFolderImageName.Text.Trim)
        FolderImageName = Me.TextFolderImageName.Text

        mykey.SetValue("FaiLImageName", Me.TextFaiLImageName.Text.Trim)
        ImageName = Me.TextFaiLImageName.Text


        'mykey.SetValue("FolderAccountS", "FolderAccountS")



        keyAccounts.SetValue("PurchasesAccount_No", TextPurchasesAccount.Text)
        keyAccounts.SetValue("PurchaseReturnAccount_No", TextPurchaseReturnAccount.Text)
        keyAccounts.SetValue("EarnedDiscountAccount_No", TextEarnedDiscountAccount.Text)
        keyAccounts.SetValue("CalculatingTaxOnPurchases_No", TextCalculatingTaxOnPurchases.Text)
        keyAccounts.SetValue("SalesAccount_No", TextSalesAccount.Text)
        keyAccounts.SetValue("SalesMergeAccount_No", TextSalesMergeAccount.Text)

        keyAccounts.SetValue("DiscountAccountAllowed_No", TextDiscountAccountAllowed.Text)
        keyAccounts.SetValue("CalculationTaxOnSales_No", TextCalculationTaxOnSales.Text)
        keyAccounts.SetValue("StockAccount_No", TextStockAccount.Text)
        keyAccounts.SetValue("AdepositAccount_No", TextAdepositAccount.Text)
        keyAccounts.SetValue("DepositAccount_No", TextDepositAccount.Text)
        keyAccounts.SetValue("SavingAccount_No", TextSavingAccount.Text)

        keyAccounts.SetValue("CustomerAccount_No", TextCustomerAccount.Text)
        keyAccounts.SetValue("SuppliersAccount_No", TextSuppliersAccount.Text)
        keyAccounts.SetValue("ReceivablesAccount_No", TextReceivablesAccount.Text)
        keyAccounts.SetValue("AccountsPayableAccount_No", TextAccountsPayableAccount.Text)
        keyAccounts.SetValue("IssuedChecksAccount_No", TextIssuedChecksAccount.Text)
        keyAccounts.SetValue("IncomingCheckAAccount_No", TextIncomingCheckAAccount.Text)

        keyAccounts.SetValue("BankAccount_No", TextBankAccount.Text)
        keyAccounts.SetValue("FundAccount_No", TextFundAccount.Text)
        keyAccounts.SetValue("CalculationEmployeeEngagement_No", TextCalculationEmployeeEngagement.Text)
        keyAccounts.SetValue("SalesTaxCalculation_No", TextSalesTaxCalculation.Text)
        keyAccounts.SetValue("CalculateSalesTaxDue_No", TextCalculateSalesTaxDue.Text)

        keyAccounts.SetValue("CalculatingEmployeeSalaries_No", TextCalculatingEmployeeSalaries.Text)
        keyAccounts.SetValue("EmployeeAdvanceAccount_No", TextEmployeeAdvanceAccount.Text)
        keyAccounts.SetValue("MerchandiseStockAccount_No", TextMerchandiseStockAccount.Text)
        keyAccounts.SetValue("CalculatingCostGoodsSold_No", TextCalculatingCostGoodsSold.Text)

        keyAccounts.SetValue("TransferAccount_No", TextTransferAccount.Text)
        keyAccounts.SetValue("PurchaseExpenseAccount_No", TextPurchaseExpenseAccount.Text)

        keyAccounts.SetValue("SalesTaxRate_B", TextSalesTaxRate.EditValue)
        keyAccounts.SetValue("IncomeTaxRate_B", TextIncomeTaxRate.EditValue)

        keyAccounts.SetValue("SocialSecurityContributions_No", TextSocialSecurityContributions.Text)
        keyAccounts.SetValue("CalculatingSocialSecurityContributionsDue_No", TextCalculatingSocialSecurityContributionsDue.Text)
        keyAccounts.SetValue("AssociationDeductionsPercentage_B", TextAssociationDeductionsPercentage.EditValue)
        keyAccounts.SetValue("EmployeeDeductionsPercentage_B", TextEmployeeDeductionsPercentage.EditValue)
        keyAccounts.SetValue("BasicSalaryInsuranceRate_B", TextBasicSalaryInsuranceRate.EditValue)
        keyAccounts.SetValue("VariableRentalInsuranceRate_B", TextVariableRentalInsuranceRate.EditValue)

        If CheckAddSalesTaxToInvoices.Checked = True Then
            keyAccounts.SetValue("AddSalesTaxToInvoices_Check", True)
        Else
            keyAccounts.SetValue("AddSalesTaxToInvoices_Check", False)
        End If
        If CheckItWillBeAnAccountingEntryWhenAdding.Checked = True Then
            keyAccounts.SetValue("ItWillBeAnAccountingEntryWhenAdding_Check", True)
        Else
            keyAccounts.SetValue("ItWillBeAnAccountingEntryWhenAdding_Check", False)
        End If
        Call OptionsA()
        Me.Close()
    End Sub

    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
        On Error Resume Next
        With Me.FolderBrowserDialog1
            .ShowNewFolderButton = True
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowDialog()
            Me.LabelMYFOLDER.Text = .SelectedPath
        End With
        ButtonAPPLY.Focus()

    End Sub

    Private Sub ButPurchasesAccount_Click(sender As Object, e As EventArgs) Handles ButPurchasesAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextPurchasesAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButPurchaseReturnAccount_Click(sender As Object, e As EventArgs) Handles ButPurchaseReturnAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextPurchaseReturnAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButEarnedDiscountAccount_Click(sender As Object, e As EventArgs) Handles ButEarnedDiscountAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextEarnedDiscountAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButCalculatingTaxOnPurchases_Click(sender As Object, e As EventArgs) Handles ButCalculatingTaxOnPurchases.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculatingTaxOnPurchases.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If

        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButSales_Click(sender As Object, e As EventArgs) Handles ButSales.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextSalesAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButSalesMerge_Click(sender As Object, e As EventArgs) Handles ButSalesMerge.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextSalesMergeAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButDiscountAccount_Click(sender As Object, e As EventArgs) Handles ButDiscountAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextDiscountAccountAllowed.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButCalculationTaxOnSales_Click(sender As Object, e As EventArgs) Handles ButCalculationTaxOnSales.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculationTaxOnSales.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButStockAccount_Click(sender As Object, e As EventArgs) Handles ButStockAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextStockAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButAdepositAccount_Click(sender As Object, e As EventArgs) Handles ButAdepositAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextAdepositAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButDepositAccount_Click(sender As Object, e As EventArgs) Handles ButDepositAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextDepositAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButSavingAccount_Click(sender As Object, e As EventArgs) Handles ButSavingAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextSavingAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButCustomer_Click(sender As Object, e As EventArgs) Handles ButCustomer.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCustomerAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButSuppliers_Click(sender As Object, e As EventArgs) Handles ButSuppliers.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextSuppliersAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButReceivables_Click(sender As Object, e As EventArgs) Handles ButReceivables.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextReceivablesAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButAccountsPayable_Click(sender As Object, e As EventArgs) Handles ButAccountsPayable.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextAccountsPayableAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButIssuedChecksAccount_Click(sender As Object, e As EventArgs) Handles ButIssuedChecksAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextIssuedChecksAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButIncomingCheckAAccount_Click(sender As Object, e As EventArgs) Handles ButIncomingCheckAAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextIncomingCheckAAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButBankAccount_Click(sender As Object, e As EventArgs) Handles ButBankAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextBankAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButFundAccount_Click(sender As Object, e As EventArgs) Handles ButFundAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextFundAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButCalculationEmployeeEngagement_Click(sender As Object, e As EventArgs) Handles ButCalculationEmployeeEngagement.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculationEmployeeEngagement.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButSalesTaxCalculation_Click(sender As Object, e As EventArgs) Handles ButSalesTaxCalculation.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextSalesTaxCalculation.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButCalculateSalesTaxDue_Click(sender As Object, e As EventArgs) Handles ButCalculateSalesTaxDue.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculateSalesTaxDue.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButCalculatingEmployeeSalaries_Click(sender As Object, e As EventArgs) Handles ButCalculatingEmployeeSalaries.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculatingEmployeeSalaries.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButEmployeeAdvanceAccount_Click(sender As Object, e As EventArgs) Handles ButEmployeeAdvanceAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextEmployeeAdvanceAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButMerchandiseStockAccount_Click(sender As Object, e As EventArgs) Handles ButMerchandiseStockAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextMerchandiseStockAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub ButCalculatingCostGoodsSold_Click(sender As Object, e As EventArgs) Handles ButCalculatingCostGoodsSold.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculatingCostGoodsSold.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButTransferAccount_Click(sender As Object, e As EventArgs) Handles ButTransferAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextTransferAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub

    Private Sub ButPurchaseExpenseAccount_Click(sender As Object, e As EventArgs) Handles ButPurchaseExpenseAccount.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextPurchaseExpenseAccount.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub ButSocialSecurityContributions_Click(sender As Object, e As EventArgs) Handles ButSocialSecurityContributions.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextSocialSecurityContributions.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub ButCalculatingSocialSecurityContributionsDue_Click(sender As Object, e As EventArgs) Handles ButCalculatingSocialSecurityContributionsDue.Click
        Try
            Dim F As New FRM_ALL_ACC
            F.ShowDialog()
            If F.ACCEPT = True Then
                Dim I As Integer = F.DGV.CurrentRow.Index
                Me.TextCalculatingSocialSecurityContributionsDue.Text = F.DGV.Rows(I).Cells("account_no").Value.ToString
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        End Try
    End Sub
    Private Sub TextCalculatingEmployeeSalaries_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextTransferAccount.KeyPress, TextSuppliersAccount.KeyPress, TextStockAccount.KeyPress, TextSavingAccount.KeyPress, TextSalesTaxCalculation.KeyPress, TextReceivablesAccount.KeyPress, TextPurchaseExpenseAccount.KeyPress, TextIssuedChecksAccount.KeyPress, TextIncomingCheckAAccount.KeyPress, TextFundAccount.KeyPress, TextEmployeeAdvanceAccount.KeyPress, TextDepositAccount.KeyPress, TextCustomerAccount.KeyPress, TextCalculationEmployeeEngagement.KeyPress, TextCalculatingEmployeeSalaries.KeyPress, TextCalculateSalesTaxDue.KeyPress, TextBankAccount.KeyPress, TextAdepositAccount.KeyPress, TextAccountsPayableAccount.KeyPress
        If e.KeyChar = Chr(8) Then Return
        If Not System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar, "[0-9]") Then
            e.Handled = True
        End If
    End Sub

    Private Sub TextMerchandiseStockAccount_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextSalesMergeAccount.KeyPress, TextSalesAccount.KeyPress, TextPurchasesAccount.KeyPress, TextPurchaseReturnAccount.KeyPress, TextMerchandiseStockAccount.KeyPress, TextEarnedDiscountAccount.KeyPress, TextDiscountAccountAllowed.KeyPress, TextCalculationTaxOnSales.KeyPress, TextCalculatingTaxOnPurchases.KeyPress, TextCalculatingCostGoodsSold.KeyPress
        If e.KeyChar = Chr(8) Then Return
        If Not System.Text.RegularExpressions.Regex.IsMatch(e.KeyChar, "[0-9]") Then
            e.Handled = True
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            SplashScreenManager.ShowForm(Me, GetType(WaitForm), True, True, False)
            If tstURL = False Then
                Call MangUsers()
                Call URL_F()
                If RAdmin = True Then
                    Me.CheckBackup1.Enabled = True
                    Me.CheckBackup.Enabled = True
                    Me.ComboMinute.Enabled = True
                ElseIf RAdmin = False Then
                    Me.CheckBackup1.Enabled = False
                    Me.CheckBackup.Enabled = False
                    Me.ComboMinute.Enabled = False
                End If
            End If
            Me.LabelServerDate.Text = ServerDateTime.ToString("yyyy-MM-dd")
            Me.LabelDate.Text = MydateWord(Me.LabelServerDate.Text)

            Me.CheckBackup1.Checked = mykey.GetValue("BACKUP", "False")
            Me.CheckBackup.Checked = mykey.GetValue("BACKUPTIME", "False")
            Me.CheckpreviousFiscalYear.Checked = mykey.GetValue("FiscalYear", "False")
            Me.CheckRunprogram.Checked = mykey.GetValue("UP", "False")
            Me.CheckTurnNewsTicker.Checked = mykey.GetValue("NEWEVENTS", "False")
            Me.CheckShowToolbar.Checked = mykey.GetValue("TBAR", "False")
            Me.CheckShowNewsTicker.Checked = mykey.GetValue("TNEWS", "False")
            Me.CheckShowProgramName.Checked = mykey.GetValue("eplor", "False")
            Me.CheckShowAlertsScreenAndBalanceScreen.Checked = mykey.GetValue("SHOWMOMENT", "False")
            Me.CheckShowTimetable.Checked = mykey.GetValue("SHOWPROMISED", "False")
            Me.ChkPD.Checked = mykey.GetValue("ItemsIncludeExpirationDate", "False")

            Me.ComboDefaultLanguage.Text = mykey.GetValue("LANGUAGE", "ARABIC")
            Me.ComboMinute.Text = mykey.GetValue("BACKUPCOMBO", "0")
            Me.CombopreviousFiscalYear.Text = mykey.GetValue("FiscalYearCOMBO", "0")
            Me.ComboImageExe.Text = mykey.GetValue("ImageExe", ".png")

            Me.TextFolderImageName.Text = mykey.GetValue("FolderImageName", "FolderImageName")
            Me.TextFaiLImageName.Text = mykey.GetValue("FaiLImageName", "ImageName")

            Me.Ob1.Checked = mykey.GetValue("Openingbalance1", "False")
            Me.Ob2.Checked = mykey.GetValue("Openingbalance2", "False")
            Me.Ob3.Checked = mykey.GetValue("Openingbalance3", "False")
            Me.Ob4.Checked = mykey.GetValue("Openingbalance4", "False")
            Me.Ob5.Checked = mykey.GetValue("Openingbalance5", "False")
            Me.Ob6.Checked = mykey.GetValue("Openingbalance6", "False")
            Me.Ob7.Checked = mykey.GetValue("Openingbalance7", "False")
            Me.Ob8.Checked = mykey.GetValue("Openingbalance8", "False")
            Me.Ob9.Checked = mykey.GetValue("Openingbalance9", "False")

            Me.CHKCI1.Checked = mykey.GetValue("CHKCI", "False")

            Me.RA.Checked = mykey.GetValue("FIFO", "False")
            Me.RB.Checked = mykey.GetValue("LIFO", "False")
            Me.RC.Checked = mykey.GetValue("AVG", "False")

            'ImageName

            Me.LabelMYFOLDER.Text = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")

            Me.TxtURL.Text = URL.ToString.Trim
            URL = Me.TxtURL.Text.Trim
            Me.TxtURL1.Text = URL1.ToString.Trim
            URL1 = Me.TxtURL1.Text.Trim
            Me.TxtURL2.Text = URL2.ToString.Trim
            URL2 = Me.TxtURL2.Text.Trim

            mykey.GetValue("URL", URL)
            mykey.GetValue("URL1", URL1)
            mykey.GetValue("URL2", URL2)

            Me.Ch1.Checked = mykey.GetValue("CHBO", False)
            Me.Ch2.Checked = mykey.GetValue("CHBO1", "False")
            Me.Ch3.Checked = mykey.GetValue("CHBO2", "False")

            Me.Checks.Value = mykey.GetValue("SHOWChecksIN", "10")
            Me.Categories.Value = mykey.GetValue("SHOWCategoriesIN", "10")
            Me.Payments.Value = mykey.GetValue("SHOWPaymentsIN", "10")

            TextPurchasesAccount.Text = keyAccounts.GetValue("PurchasesAccount_No", TextPurchasesAccount.Text)
            TextPurchaseReturnAccount.Text = keyAccounts.GetValue("PurchaseReturnAccount_No", TextPurchaseReturnAccount.Text)
            TextEarnedDiscountAccount.Text = keyAccounts.GetValue("EarnedDiscountAccount_No", TextEarnedDiscountAccount.Text)
            TextCalculatingTaxOnPurchases.Text = keyAccounts.GetValue("CalculatingTaxOnPurchases_No", TextCalculatingTaxOnPurchases.Text)
            TextSalesAccount.Text = keyAccounts.GetValue("SalesAccount_No", TextSalesAccount.Text)
            TextSalesMergeAccount.Text = keyAccounts.GetValue("SalesMergeAccount_No", TextSalesMergeAccount.Text)

            TextDiscountAccountAllowed.Text = keyAccounts.GetValue("DiscountAccountAllowed_No", TextDiscountAccountAllowed.Text)
            TextCalculationTaxOnSales.Text = keyAccounts.GetValue("CalculationTaxOnSales_No", TextCalculationTaxOnSales.Text)
            TextStockAccount.Text = keyAccounts.GetValue("StockAccount_No", TextStockAccount.Text)
            TextAdepositAccount.Text = keyAccounts.GetValue("AdepositAccount_No", TextAdepositAccount.Text)
            TextDepositAccount.Text = keyAccounts.GetValue("DepositAccount_No", TextDepositAccount.Text)
            TextSavingAccount.Text = keyAccounts.GetValue("SavingAccount_No", TextSavingAccount.Text)

            TextCustomerAccount.Text = keyAccounts.GetValue("CustomerAccount_No", TextCustomerAccount.Text)
            TextSuppliersAccount.Text = keyAccounts.GetValue("SuppliersAccount_No", TextSuppliersAccount.Text)
            TextReceivablesAccount.Text = keyAccounts.GetValue("ReceivablesAccount_No", TextReceivablesAccount.Text)
            TextAccountsPayableAccount.Text = keyAccounts.GetValue("AccountsPayableAccount_No", TextAccountsPayableAccount.Text)
            TextIssuedChecksAccount.Text = keyAccounts.GetValue("IssuedChecksAccount_No", TextIssuedChecksAccount.Text)
            TextIncomingCheckAAccount.Text = keyAccounts.GetValue("IncomingCheckAAccount_No", TextIncomingCheckAAccount.Text)

            TextBankAccount.Text = keyAccounts.GetValue("BankAccount_No", TextBankAccount.Text)
            TextFundAccount.Text = keyAccounts.GetValue("FundAccount_No", TextFundAccount.Text)
            TextCalculationEmployeeEngagement.Text = keyAccounts.GetValue("CalculationEmployeeEngagement_No", TextCalculationEmployeeEngagement.Text)
            TextSalesTaxCalculation.Text = keyAccounts.GetValue("SalesTaxCalculation_No", TextSalesTaxCalculation.Text)
            TextCalculateSalesTaxDue.Text = keyAccounts.GetValue("CalculateSalesTaxDue_No", TextCalculateSalesTaxDue.Text)

            TextCalculatingEmployeeSalaries.Text = keyAccounts.GetValue("CalculatingEmployeeSalaries_No", TextCalculatingEmployeeSalaries.Text)
            TextEmployeeAdvanceAccount.Text = keyAccounts.GetValue("EmployeeAdvanceAccount_No", TextEmployeeAdvanceAccount.Text)
            TextMerchandiseStockAccount.Text = keyAccounts.GetValue("MerchandiseStockAccount_No", TextMerchandiseStockAccount.Text)
            TextCalculatingCostGoodsSold.Text = keyAccounts.GetValue("CalculatingCostGoodsSold_No", TextCalculatingCostGoodsSold.Text)

            TextTransferAccount.Text = keyAccounts.GetValue("TransferAccount_No", TextTransferAccount.Text)
            TextPurchaseExpenseAccount.Text = keyAccounts.GetValue("PurchaseExpenseAccount_No", TextPurchaseExpenseAccount.Text)

            TextSalesTaxRate.EditValue = keyAccounts.GetValue("SalesTaxRate_B", TextSalesTaxRate.EditValue)
            TextIncomeTaxRate.EditValue = keyAccounts.GetValue("IncomeTaxRate_B", TextIncomeTaxRate.EditValue)

            TextSocialSecurityContributions.Text = keyAccounts.GetValue("SocialSecurityContributions_No", TextSocialSecurityContributions.Text)
            TextCalculatingSocialSecurityContributionsDue.Text = keyAccounts.GetValue("CalculatingSocialSecurityContributionsDue_No", TextCalculatingSocialSecurityContributionsDue.Text)

            TextAssociationDeductionsPercentage.EditValue = keyAccounts.GetValue("AssociationDeductionsPercentage_B", TextAssociationDeductionsPercentage.EditValue)
            TextEmployeeDeductionsPercentage.EditValue = keyAccounts.GetValue("EmployeeDeductionsPercentage_B", TextEmployeeDeductionsPercentage.EditValue)
            TextBasicSalaryInsuranceRate.EditValue = keyAccounts.GetValue("BasicSalaryInsuranceRate_B", TextBasicSalaryInsuranceRate.EditValue)
            TextVariableRentalInsuranceRate.EditValue = keyAccounts.GetValue("VariableRentalInsuranceRate_B", TextVariableRentalInsuranceRate.EditValue)

            CheckAddSalesTaxToInvoices.Checked = keyAccounts.GetValue("AddSalesTaxToInvoices_Check", False)
            CheckItWillBeAnAccountingEntryWhenAdding.Checked = keyAccounts.GetValue("ItWillBeAnAccountingEntryWhenAdding_Check", False)

        Catch ex As Exception
            Return
        End Try
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        SplashScreenManager.CloseForm(False)
    End Sub

End Class