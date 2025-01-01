Option Strict Off
Imports System.Data.SqlClient

Module MigrateRestrictions
    Public dtAccounts As DataTable
    Public dvAccounts As New DataView
    Public LoadAccounts As New CLS_ACCOUNTS



    Public AddSalesTaxToInvoices_Check As Boolean 'اضافة ضريبة المبيعات الى الفواتير
    Public ItWillBeAnAccountingEntryWhenAdding_Check As Boolean 'السماح بالترحيل عند الإضافة

    Public PurchasesAccount_No As Integer ' حساب المشتريات
    Public PurchaseReturnAccount_No As Integer ' حساب مرتجع المشتريات
    Public EarnedDiscountAccount_No As Integer ' حساب خصم مكتسب
    Public CalculatingTaxOnPurchases_No As Integer ' حساب ض قيمة مضافة علي المشتريات

    Public SalesAccount_No As Integer ' المبيعات
    Public SalesMergeAccount_No As Integer ' حساب مرتجع المبيعات
    Public DiscountAccountAllowed_No As Integer ' حساب خصم مسموح به
    Public CalculationTaxOnSales_No As Integer ' حساب ض قيمة مضافة علي المبيعات

    Public StockAccount_No As Integer 'حساب الاسهم
    Public AdepositAccount_No As Integer 'حساب امانات
    Public DepositAccount_No As Integer 'حساب الودائع
    Public SavingAccount_No As Integer 'حساب التوفير

    Public CustomerAccount_No As Integer 'حساب العملاء
    Public SuppliersAccount_No As Integer 'حساب الموردين
    Public ReceivablesAccount_No As Integer 'حساب ذمم مدينة
    Public AccountsPayableAccount_No As Integer 'حساب ذمم دائنة

    Public IssuedChecksAccount_No As Integer ' حساب شيكات صادره  
    Public IncomingCheckAAccount_No As Integer ' حساب شيكات واردة 
    Public BankAccount_No As Integer ' حساب البنك 
    Public FundAccount_No As Integer = Nothing ' حساب الصندوق 

    Public CalculationEmployeeEngagement_No As Integer ' حساب عهد الموظفين 
    Public CalculatingEmployeeSalaries_No As Integer ' حساب رواتب الموظفين 
    Public EmployeeAdvanceAccount_No As Integer ' حساب سلفة الموظفين 

    Public SalesTaxCalculation_No As Integer ' حساب ضريية المبيعات
    Public CalculateSalesTaxDue_No As Integer 'حساب ضريبة مبيعات مستحقه 


    Public MerchandiseStockAccount_No As Integer 'حساب مخزون البضاعة
    Public CalculatingCostGoodsSold_No As Integer 'حساب تكلفه البضاعه المباعه

    Public TransferAccount_No As Integer 'حساب  نقل
    Public PurchaseExpenseAccount_No As Integer 'حساب مصاريف مشتريات


    Public PurchSalesCalculatingTax_No As Integer
    Public PurchSalesDiscount_No As Integer
    Public AccountNoAktevd As Integer

    Public SalesTaxRate_B As Double 'نسبة ضريبة المبيعات
    Public IncomeTaxRate_B As Double 'نسبة ضريبة الدخل

    Public Discount_B As Double = 0
    Public CalculatingTax_B As Double = 0

    Public DebitAccount_Name As String 'مدين
    Public CredAccount_Name As String  'دائن

    Public ChecksAccount_Name As String 'حساب شيكات 
    Public FundAccount_Name As String 'حساب الصندوق 
    Public AccountsPayableAccount_Name As String 'حساب ذمم دائنة

    Public CalculatingTaxAccount_Name As String 'حساب ضريية 
    Public DiscountAccountAE_Name As String 'حساب خصم 

    Public SalesMergeAccount_Name As String ' حساب مرتجع المبيعات

    Public SocialSecurityContributions_No As String ' حساب اشتراكات ضمان الاجتماعي 
    Public CalculatingSocialSecurityContributionsDue_No As String ' حساب اشتراكات ضمان الاجتماعي مستحقه

    Public EmployeeDeductionsPercentage_B As Double 'نسبة اقتطاعات الموظف
    Public AssociationDeductionsPercentage_B As Double 'نسبة اقتطاعات الجمعية
    Public BasicSalaryInsuranceRate_B As Double 'نسبة تأمين الراتب الاساسي
    Public VariableRentalInsuranceRate_B As Double 'نسبة تأمين الاجرة المتغيرة

    Public DebitAccount_No, DebitAccount_Cod, CredAccount_NO, CredAccount_Cod, ChecksAccount_NO, ChecksAccount_Cod, PayableAccount_NO,
               PayableAccount_Cod, TaxAccount_NO, TaxAccount_Cod, DiscountAccount_NO, DiscountAccount_Cod, Accounts_NO, CodAccount, SalesMergeAccountS_NO, CodSalesMergeAccount As Integer


    Public NewCredAccount_NO As Integer
    Public NewCredAccount_Name As String
    Public NewCredAccount_Cod As Integer


    Public nem, nem1, nem2, nem3, nem4, nem5 As String
    Public PMO2 As Integer = 1

    Public PurchSales_Check As Boolean = False

    Public TransferToAccounts_Check As Boolean = False
    Public ExitSub_Check As Boolean = False
    Public TestkeyAccounts_Check As Boolean = False

    Public Function GetDataCheck() As DataTable
        dtAccounts = New DataTable
        dtAccounts.Columns.Add("account_name", GetType(String))
        dtAccounts = CLS_ACCOUNTS.LOAD_ACCOUNTSCheck()
        Return dtAccounts
    End Function

    Public Function GetData(ByVal NUpAccount As Integer) As DataTable
        dtAccounts = New DataTable
        dtAccounts.Columns.Add("account_name", GetType(String))
        dtAccounts = CLS_ACCOUNTS.LOAD_ACCOUNTS(NUpAccount)
        Return dtAccounts
    End Function

    Public Sub SetDetailsAccounts(ByVal MovementNumber As Integer, ByVal Number As Integer, ByVal TEXT As String)
        nem = Number & "_" & " " & "رقم " & " " & TEXT & " فاتورة "
        nem1 = MovementNumber & "_" & " " & "نقدي رقم" & " " & TEXT & " فاتورة "
        nem2 = MovementNumber & "_" & " " & "بيموجب مستند رقم " & " " & TEXT & " فاتورة "
        nem3 = Number & "_" & " " & " رقم" & " " & TEXT & " فاتورة "
        nem4 = Number & "_" & " " & "رقم " & " " & TEXT & "خصم لفاتورة"
        nem5 = Number & "_" & " " & "رقم " & " " & TEXT & "حساب ضريبة  لفاتورة "
    End Sub

    Public Sub OptionsTransforAccounts(ByVal PaymentMethod As String, ByVal DebitAccount As String, ByVal CreditAccount As String, ByVal CreditAccount1 As String)
        If DebitAccount <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", DebitAccount, 1)
            DebitAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", DebitAccount, 1)
            DebitAccount_Cod = ID_Nam
        End If
        If CreditAccount1 <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount1, 1)
            CredAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount1, 1)
            CredAccount_Cod = ID_Nam
        End If
        Select Case PaymentMethod
            Case "نقدا"
                If CreditAccount <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount, 1)
                    Accounts_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount, 1)
                    CodAccount = ID_Nam
                End If
            Case "شيك"
                If CreditAccount <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount, 1)
                    ChecksAccount_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount, 1)
                    ChecksAccount_Cod = ID_Nam
                End If
            Case "نقدا_شيك"
                If ModuleGeneral.CB2.ToString <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2.ToString, 1)
                    Accounts_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2.ToString, 1)
                    CodAccount = ID_Nam
                End If
                If CreditAccount <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount, 1)
                    ChecksAccount_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount, 1)
                    ChecksAccount_Cod = ID_Nam
                End If
            Case Else
                MsgBox("يجب مراجعة طريقة الدفع")
                Exit Sub
        End Select
    End Sub

    Public Sub OptionsTransforAccountsTo(ByVal PaymentMethod As String, ByVal DebitAccount As String, ByVal CreditAccount As String)

        If DebitAccount <> Nothing Then
            GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", DebitAccount, 1)
            DebitAccount_No = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", DebitAccount, 1)
            DebitAccount_Cod = ID_Nam
        End If
        Select Case PaymentMethod
            Case "نقدا"
                If CreditAccount <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount, 1)
                    Accounts_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount, 1)
                    CodAccount = ID_Nam
                End If
            Case "شيك"
                If CreditAccount <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount, 1)
                    ChecksAccount_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount, 1)
                    ChecksAccount_Cod = ID_Nam
                End If
            Case "نقدا_شيك"
                If ModuleGeneral.CB2.ToString <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", ModuleGeneral.CB2.ToString, 1)
                    Accounts_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", ModuleGeneral.CB2.ToString, 1)
                    CodAccount = ID_Nam
                End If
                If CreditAccount <> Nothing Then
                    GetNoRecord("ACCOUNTSTREE", "account_no", "account_name", CreditAccount, 1)
                    ChecksAccount_NO = ID_Nam
                    GetNoRecord("ACCOUNTSTREE", "ACC", "account_name", CreditAccount, 1)
                    ChecksAccount_Cod = ID_Nam
                End If
            Case Else
                MsgBox("يجب مراجعة طريقة الدفع")
                Exit Sub
        End Select
    End Sub

    Public Sub SetUpComboBox(ByVal ComboConstraintType As ComboBox)
        Dim A, B, C, D As Integer
        Dim StockAccount As String
        Dim AdepositAccount As String
        Dim DepositAccount As String
        Dim SavingAccount As String
        ComboConstraintType.Items.Clear()
        If keyAccounts.GetValue("StockAccount_No", StockAccount_No) IsNot Nothing Then
            A = keyAccounts.GetValue("StockAccount_No", StockAccount_No)
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", A, 1)
            StockAccount = ID_Nam
            ComboConstraintType.Items.Add(StockAccount)
        End If
        If keyAccounts.GetValue("AdepositAccount_No", AdepositAccount_No) IsNot Nothing Then
            B = keyAccounts.GetValue("AdepositAccount_No", AdepositAccount_No)
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", B, 1)
            AdepositAccount = ID_Nam
            ComboConstraintType.Items.Add(AdepositAccount)
        End If
        If keyAccounts.GetValue("DepositAccount_No", DepositAccount_No) IsNot Nothing Then
            C = keyAccounts.GetValue("DepositAccount_No", DepositAccount_No)
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", C, 1)
            DepositAccount = ID_Nam
            ComboConstraintType.Items.Add(DepositAccount)
        End If
        If keyAccounts.GetValue("SavingAccount_No", SavingAccount_No) IsNot Nothing Then
            D = keyAccounts.GetValue("SavingAccount_No", SavingAccount_No)
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", D, 1)
            SavingAccount = ID_Nam
            ComboConstraintType.Items.Add(SavingAccount)
        End If
        If ComboConstraintType.Items.Count > 0 Then
            ComboConstraintType.SelectedIndex = 0
        End If
        If ComboConstraintType.SelectedIndex = -1 Then
            ComboConstraintType.Items.Add("الحسابات فارغة")
            'ComboConstraintType.Enabled = False
            Exit Sub
        End If

    End Sub

    Public Sub TestkeyAccounts(ByVal keyAccounts As String)
        If keyAccounts = Nothing Then
            MessageBox.Show("رقم حساب النموذج الحالي غير موجد يجب اتخاذ الاجراءت التالية :" & ControlChars.CrLf &
                            "1) فتح اعدادت النظام" & ControlChars.CrLf &
                            "2) اختيار الحساب المناسب " & ControlChars.CrLf &
                            "3) تطبيق الاختيارات", "اعدادت الحسابات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly)
            TestkeyAccounts_Check = False
            Exit Sub
        Else
            TestkeyAccounts_Check = True
        End If


    End Sub


    Public Sub GetUpAccounts(ByVal PaymentMethod As String, ByVal FormTAccount_No As Integer)

        DebitAccount_Name = Nothing
        DebitAccount_No = Nothing
        DebitAccount_Cod = Nothing

        CredAccount_Name = Nothing
        CredAccount_NO = Nothing
        CredAccount_Cod = Nothing

        FundAccount_Name = Nothing
        Accounts_NO = Nothing
        CodAccount = Nothing

        ChecksAccount_Name = Nothing
        ChecksAccount_NO = Nothing
        ChecksAccount_Cod = Nothing

        AccountsPayableAccount_Name = Nothing
        PayableAccount_NO = Nothing
        PayableAccount_Cod = Nothing

        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("FormTAccount_No", FormTAccount_No), 1)
        DebitAccount_Name = ID_Nam
        If keyAccounts.GetValue("FormTAccount_No", FormTAccount_No) = Nothing Then
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FormTAccount_No, 1)
            DebitAccount_Name = ID_Nam
        ElseIf DebitAccount_Name = Nothing Then
            'MsgBox("رقم حساب المدين فارغ")
            ExitSub_Check = True
            Exit Sub
        End If
        GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", DebitAccount_Name, 1)
        DebitAccount_No = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", DebitAccount_No, 1)
        DebitAccount_Cod = ID_Nam

        GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("FormTAccount_No", FormTAccount_No), 1)
        CredAccount_Name = ID_Nam
        If keyAccounts.GetValue("FormTAccount_No", FormTAccount_No) = Nothing Then
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FormTAccount_No, 1)
            CredAccount_Name = ID_Nam
        ElseIf CredAccount_Name = Nothing Then
            'MsgBox("رقم حساب الدائن فارغ")
            ExitSub_Check = True
            Exit Sub
        End If
        GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", CredAccount_Name, 1)
        CredAccount_NO = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", CredAccount_NO, 1)
        CredAccount_Cod = ID_Nam

        Select Case PaymentMethod
            Case "نقدا"
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
                FundAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", FundAccount_Name, 1)
                Accounts_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("FundAccount_No", FundAccount_No), 1)
                CodAccount = ID_Nam
                If keyAccounts.GetValue("FundAccount_No", FundAccount_No) = Nothing Then
                    MsgBox("رقم حساب الصنوق فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If

            Case "شيك"
                'حساب شيكات 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", ChecksAccount_Name, 1)
                ChecksAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Cod = ID_Nam
                If keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No) = Nothing Then
                    MsgBox("رقم حساب شيكات فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
            Case "نقدا_شيك"
                'حساب الصندوق 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
                FundAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", FundAccount_Name, 1)
                Accounts_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("FundAccount_No", FundAccount_No), 1)
                CodAccount = ID_Nam

                If keyAccounts.GetValue("FundAccount_No", FundAccount_No) = Nothing Then
                    MsgBox("رقم حساب الصنوق فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
                'حساب شيكات 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", ChecksAccount_Name, 1)
                ChecksAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Cod = ID_Nam
                If keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No) = Nothing Then
                    MsgBox("رقم حساب شيكات فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
            Case "ذمم_دائنة"
                'حساب ذمم دائنة
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                AccountsPayableAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", AccountsPayableAccount_Name, 1)
                PayableAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                PayableAccount_Cod = ID_Nam
                If keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No) = Nothing Then
                    MsgBox("رقم حساب ذمم دائنة فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
            Case "نقدا_ذمم_دائنة"
                'حساب الصندوق 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
                FundAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", FundAccount_Name, 1)
                Accounts_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("FundAccount_No", FundAccount_No), 1)
                CodAccount = ID_Nam
                If keyAccounts.GetValue("FundAccount_No", FundAccount_No) = Nothing Then
                    MsgBox("رقم حساب الصنوق فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
                'حساب ذمم دائنة
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                AccountsPayableAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", AccountsPayableAccount_Name, 1)
                PayableAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                PayableAccount_Cod = ID_Nam
                If keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No) = Nothing Then
                    MsgBox("رقم حساب ذمم دائنة فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
            Case "شيك_ذمم_دائنة"
                'حساب شيكات 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", ChecksAccount_Name, 1)
                ChecksAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Cod = ID_Nam
                If keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No) = Nothing Then
                    MsgBox("رقم حساب شيكات فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
                'حساب ذمم دائنة
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                AccountsPayableAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", AccountsPayableAccount_Name, 1)
                PayableAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                PayableAccount_Cod = ID_Nam
                If keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No) = Nothing Then
                    MsgBox("رقم حساب ذمم دائنة فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
            Case "نقدا_شيك_ذمم_دائنة"
                'حساب الصندوق 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", FundAccount_No, 1)
                FundAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", FundAccount_Name, 1)
                Accounts_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("FundAccount_No", FundAccount_No), 1)
                CodAccount = ID_Nam
                If keyAccounts.GetValue("FundAccount_No", FundAccount_No) = Nothing Then
                    MsgBox("رقم حساب الصنوق فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
                'حساب شيكات 
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Name = ID_Nam

                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", ChecksAccount_Name, 1)
                ChecksAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No), 1)
                ChecksAccount_Cod = ID_Nam

                If keyAccounts.GetValue("IssuedChecksAccount_No", IssuedChecksAccount_No) = Nothing Then
                    MsgBox("رقم حساب شيكات فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
                'حساب ذمم دائنة
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                AccountsPayableAccount_Name = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", AccountsPayableAccount_Name, 1)
                PayableAccount_NO = ID_Nam
                GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No), 1)
                PayableAccount_Cod = ID_Nam
                If keyAccounts.GetValue("AccountsPayableAccount_No", AccountsPayableAccount_No) = Nothing Then
                    MsgBox("رقم حساب ذمم دائنة فارغ")
                    ExitSub_Check = True
                    Exit Sub
                End If
            Case Else
                'MsgBox("يجب مراجعة ارقام الحسابات او طريقة الدفع")
                'ExitSub_Check = True
                Exit Sub
        End Select
    End Sub

    Public Sub GetFundAccount_No(ByVal CB2_Name As String)
        FundAccount_No = Nothing
        GetNoRecord("ACCOUNTSTREE", "account_no", "account_Name", CB2_Name, 1)
        FundAccount_No = ID_Nam

    End Sub


    Public Sub GetNewAccount_No(ByRef NewAccount_No As Integer)
        Dim AccountNo_New As Integer
        If keyAccounts.GetValue("NewAccount_No", NewAccount_No) IsNot Nothing Then
            AccountNo_New = keyAccounts.GetValue("NewAccount_No", NewAccount_No)
        End If
        CredAccount_NO = AccountNo_New
        GetNoRecord("ACCOUNTSTREE", "account_name", "account_no", AccountNo_New, 1)
        NewCredAccount_Name = ID_Nam
        GetNoRecord("ACCOUNTSTREE", "ACC", "account_no", AccountNo_New, 1)
        NewCredAccount_Cod = ID_Nam
    End Sub


    Public Sub GetPurchSales_Check()
        If PurchSales_Check = False Then
            If keyAccounts.GetValue("CalculatingTaxOnPurchases_No", CalculatingTaxOnPurchases_No) IsNot Nothing Then
                PurchSalesCalculatingTax_No = keyAccounts.GetValue("CalculatingTaxOnPurchases_No", CalculatingTaxOnPurchases_No)
            End If
            If keyAccounts.GetValue("EarnedDiscountAccount_No", EarnedDiscountAccount_No) IsNot Nothing Then
                PurchSalesDiscount_No = keyAccounts.GetValue("EarnedDiscountAccount_No", EarnedDiscountAccount_No)
            End If
        ElseIf PurchSales_Check = True Then
            If keyAccounts.GetValue("CalculationTaxOnSales_No", CalculationTaxOnSales_No) IsNot Nothing Then
                PurchSalesCalculatingTax_No = keyAccounts.GetValue("CalculationTaxOnSales_No", CalculationTaxOnSales_No)
            End If
            If keyAccounts.GetValue("DiscountAccountAllowed_No", DiscountAccountAllowed_No) IsNot Nothing Then
                PurchSalesDiscount_No = keyAccounts.GetValue("DiscountAccountAllowed_No", DiscountAccountAllowed_No)
            End If
        End If
        If keyAccounts.GetValue("PurchSalesCalculatingTax_No", PurchSalesCalculatingTax_No) = Nothing Then
            MsgBox("رقم حساب الضريبة فارغ")
            ExitSub_Check = True
            Exit Sub
        End If
        If keyAccounts.GetValue("PurchSalesDiscount_No", PurchSalesDiscount_No) = Nothing Then
            MsgBox("رقم حساب الخصم فارغ")
            ExitSub_Check = True
            Exit Sub
        End If
    End Sub

    Public Sub GetDiscount_B(ByVal Discount As Double)
        If Discount > 0 Then
            'حساب خصم 
            If keyAccounts.GetValue("PurchSalesDiscount_No", PurchSalesDiscount_No) IsNot Nothing Then
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("PurchSalesDiscount_No", PurchSalesDiscount_No), 1)
                DiscountAccountAE_Name = ID_Nam
            End If
            GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", DiscountAccountAE_Name, 1)
            DiscountAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("PurchSalesDiscount_No", PurchSalesDiscount_No), 1)
            DiscountAccount_Cod = ID_Nam
        End If
    End Sub

    Public Sub GetCalculatingTax_B(ByVal CalculatingTax As Double)
        If CalculatingTax > 0 Then
            'حساب ضريية 
            If keyAccounts.GetValue("PurchSalesCalculatingTax_No", PurchSalesCalculatingTax_No) IsNot Nothing Then
                GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", keyAccounts.GetValue("PurchSalesCalculatingTax_No", PurchSalesCalculatingTax_No), 1)
                CalculatingTaxAccount_Name = ID_Nam
            End If
            GetNoRecord("ACCOUNTSTREE", "Account_no", "Account_Name", CalculatingTaxAccount_Name, 1)
            TaxAccount_NO = ID_Nam
            GetNoRecord("ACCOUNTSTREE", "ACC", "Account_No", keyAccounts.GetValue("PurchSalesCalculatingTax_No", PurchSalesCalculatingTax_No), 1)
            TaxAccount_Cod = ID_Nam
        End If
    End Sub

    Public Sub AccountingEntries(ByVal T1 As Int64, ByVal T2 As Int64, ByVal DateMovementHistory As String, ByVal Statement As String, ByVal MOV5 As Boolean, ByVal Debit As Double, ByVal Cred As Double, ByVal T3 As String, ByVal MOV9 As String, ByVal MOV10 As String, ByVal MovementSymbol As String, ByVal MOV12 As Boolean)
        Try
            'SEARCHDATA.MAXIDMOVES()
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlClient.SqlCommand("INSERT INTO MOVES (MOV1, MOV2, MOV3, MOV4, MOV5, MOV6, MOV7, MOV8, MOV9, MOV10, MOV11, MOV12, USERNAME, Realname, cuser, COUser, da, ne) VALUES     (@MOV1, @MOV2, @MOV3, @MOV4, @MOV5, @MOV6, @MOV7, @MOV8, @MOV9, @MOV10, @MOV11, @MOV12, @USERNAME, @Realname, @cuser, @COUser, @da, @ne)", Consum)
            Dim CMD As New SqlClient.SqlCommand
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@MOV1", SqlDbType.BigInt).Value = T1
                .Parameters.Add("@MOV2", SqlDbType.BigInt).Value = T2
                .Parameters.Add("@MOV3", SqlDbType.Date).Value = DateMovementHistory
                .Parameters.Add("@MOV4", SqlDbType.NVarChar).Value = Statement
                .Parameters.Add("@MOV5", SqlDbType.Bit).Value = MOV5
                .Parameters.Add("@MOV6", SqlDbType.NVarChar).Value = Debit
                .Parameters.Add("@MOV7", SqlDbType.NVarChar).Value = Cred
                .Parameters.Add("@MOV8", SqlDbType.NVarChar).Value = T3
                .Parameters.Add("@MOV9", SqlDbType.NVarChar).Value = MOV9
                .Parameters.Add("@MOV10", SqlDbType.NVarChar).Value = MOV10
                .Parameters.Add("@MOV11", SqlDbType.NVarChar).Value = MovementSymbol
                .Parameters.Add("@MOV12", SqlDbType.NVarChar).Value = MOV12
                .Parameters.Add("@USERNAME", SqlDbType.NVarChar).Value = USERNAME
                .Parameters.Add("@cuser", SqlDbType.NVarChar).Value = CUser
                .Parameters.Add("@Realname", SqlDbType.NVarChar).Value = Realname
                .Parameters.Add("@COUser", SqlDbType.NVarChar).Value = COUser
                .Parameters.Add("@da", SqlDbType.NVarChar).Value = ServerDateTime.ToString("yyyy-MM-dd")
                .Parameters.Add("@ne", SqlDbType.NVarChar).Value = ServerDateTime.ToString("hh:mm:ss tt")
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

    Public Sub DetailsAccountingEntries(p As Integer, ByVal DebitAccount As String, ByVal Account_NO As Integer, ByVal Debit As Double, ByVal Cred As Double, ByVal Statement As String, ByVal CodAccount As Integer, ByVal MovementSymbol As String, ByVal TEXT1 As String, ByVal MOV3 As Boolean, ByVal T2 As String)

        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strSQL As New SqlClient.SqlCommand("", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With strSQL
            .CommandText = "Insert Into MOVESDATA(MOVD2, MOVD3, MOVD4, MOVD5, MOVD6, MOVD7, MOVD8, MOVD9, MOVD10, MOV3, MOV2) values('" _
                  & p & "','" & DebitAccount & "','" & Account_NO & "','" & Debit & "','" & Cred & "','" & Statement & "','" & CodAccount & "','" & MovementSymbol & "','" & TEXT1 & "','" & MOV3 & "','" & T2 & "')"
            CMD.CommandType = CommandType.Text
            CMD.Connection = Consum
            CMD.CommandText = strSQL.CommandText
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        End With
    End Sub

    Public Sub Insert_CASHIER(ByVal DateMovementHistory As String, ByVal ConstraintType As String, ByVal MovementSymbol As String, ByVal start_CASH As Double, ByVal end_CASH As Double, ByVal form_N As String, ByVal Combo_N As String, ByVal LogReview As Boolean, ByVal InvoiceNumber As String, ByVal Chec As Boolean, ByVal Chec1 As Boolean, ByVal Combo_CB As String, ByVal CB2 As String)

        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim TEXTID As Int64

            GetAutoNumber("CSH1", "CASHIER", "CSH2")
            TEXTID = AutoNumber
            Dim cmd As New SqlClient.SqlCommand("INSERT INTO CASHIER(  CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17, CSH18, CSH19, USERNAME, CUser, COUser, da, ne) VALUES     (  @CSH1, @CSH2, @CSH3, @CSH4, @CSH5, @CSH6, @CSH7, @CSH8, @CSH9, @CSH10, @CSH11, @CSH12, @CSH14, @CSH15, @CSH16, @CSH17, @CSH18, @CSH19, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@CSH1", TEXTID)
            cmd.Parameters.AddWithValue("@CSH2", DateMovementHistory)
            cmd.Parameters.AddWithValue("@CSH3", ConstraintType)
            cmd.Parameters.AddWithValue("@CSH4", MovementSymbol)
            cmd.Parameters.AddWithValue("@CSH5", "نقدا")
            cmd.Parameters.AddWithValue("@CSH6", Format(SumAmounTOTALBALANCECASHIER11(CUser, Combo_CB, TEXTID), "0.000"))
            cmd.Parameters.AddWithValue("@CSH7", start_CASH)
            cmd.Parameters.AddWithValue("@CSH8", end_CASH)
            cmd.Parameters.AddWithValue("@CSH9", Format(SumAmounTOTALBALANCECASHIER11(CUser, Combo_CB, TEXTID), "0.000"))
            cmd.Parameters.AddWithValue("@CSH10", form_N)
            cmd.Parameters.AddWithValue("@CSH11", Combo_N)
            cmd.Parameters.AddWithValue("@CSH12", "من حساب حركة" & " _ " & form_N & " _ " & MovementSymbol)
            cmd.Parameters.AddWithValue("@CSH14", LogReview)
            cmd.Parameters.AddWithValue("@CSH15", InvoiceNumber)
            cmd.Parameters.AddWithValue("@CSH16", Chec)
            cmd.Parameters.AddWithValue("@CSH17", Chec1)
            cmd.Parameters.AddWithValue("@CSH18", Combo_CB)
            cmd.Parameters.AddWithValue("@CSH19", CB2)

            cmd.Parameters.AddWithValue("@USERNAME", USERNAME)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@COUser", COUser)
            cmd.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            'MsgBox("تم اضافة حساب الصندوق ", MsgBoxStyle.Information, "معلومات")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل اضافة حساب الصندوق ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Insert_Checks(ByVal CheckNumber As String, ByVal DateMovementHistory As String, ByVal CheckDate As Date, ByVal sta_CH As Double,
                             ByVal end_CH As Double, ByVal nem_N As String, ByVal no_N As String, ByVal ConstraintType As String, ByVal T2 As String, ByVal BANK As String _
                             , ByVal BN4 As String, ByVal CheckEW As Boolean, ByVal MovementSymbol As String, ByVal LogReview As Boolean, ByVal ComboCB1 As String, ByVal ComboBN2 As String)
        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim TEXTID As Int64
            GetAutoNumber("IDCH", "Checks", "CH2")
            TEXTID = AutoNumber
            Consum.Close()
            Dim cmd As New SqlClient.SqlCommand("INSERT INTO Checks(IDCH, CH1, CH2, CH3, CH4, CH5, CH6, CH7, CH8, CH9, CH10, CH11, CH12, CH14, CH15, CH16, CH17, CH18, CH19, CH20, CH21, CH22, CH23, CH25, CH26, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@IDCH, @CH1, @CH2, @CH3, @CH4, @CH5, @CH6, @CH7, @CH8, @CH9, @CH10, @CH11, @CH12, @CH14, @CH15, @CH16, @CH17, @CH18, @CH19, @CH20, @CH21, @CH22, @CH23, @CH25, @CH26, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@IDCH", TEXTID)
            cmd.Parameters.AddWithValue("@CH1", CheckNumber)
            cmd.Parameters.AddWithValue("@CH2", DateMovementHistory)
            cmd.Parameters.AddWithValue("@CH3", CheckDate)
            cmd.Parameters.AddWithValue("@CH4", "جاري")
            cmd.Parameters.AddWithValue("@CH5", sta_CH)
            cmd.Parameters.AddWithValue("@CH6", end_CH)
            cmd.Parameters.AddWithValue("@CH7", nem_N)
            cmd.Parameters.AddWithValue("@CH8", no_N)
            cmd.Parameters.AddWithValue("@CH9", "سحب بشيك بنكي من حساب فاتورة رقم" & " " & ":" & " " & MovementSymbol)
            cmd.Parameters.AddWithValue("@CH10", ConstraintType)
            cmd.Parameters.AddWithValue("@CH11", T2)
            cmd.Parameters.AddWithValue("@CH12", BANK)
            cmd.Parameters.AddWithValue("@CH14", BN4)
            cmd.Parameters.AddWithValue("@CH15", CheckEW)
            cmd.Parameters.AddWithValue("@CH16", MovementSymbol)
            cmd.Parameters.AddWithValue("@CH17", False)
            cmd.Parameters.AddWithValue("@CH18", LogReview)
            cmd.Parameters.AddWithValue("@CH19", True)
            cmd.Parameters.AddWithValue("@CH20", False)
            cmd.Parameters.AddWithValue("@CH21", False)
            cmd.Parameters.AddWithValue("@CH22", False)
            cmd.Parameters.AddWithValue("@CH23", False)
            'cmd.Parameters.AddWithValue("@CH24", Format(Val(SumAmounTOTALChecks(no_N, TEXTID)), "0.000"))
            cmd.Parameters.AddWithValue("@CH25", "جاري")
            cmd.Parameters.AddWithValue("@CH26", "جاري")
            cmd.Parameters.AddWithValue("@CB1", ComboCB1)
            cmd.Parameters.AddWithValue("@BN2", ComboBN2)


            cmd.Parameters.AddWithValue("@USERNAME", USERNAME)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@COUser", COUser)
            cmd.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل اضافة حساب الشيكات ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        'MsgBox("تم اضافة حساب الشيكات ", MsgBoxStyle.Information, "معلومات")
    End Sub

    Public Sub Insert_BANKJO(ByVal EBNK4_BNK As Double, ByVal EBNK5_BNK As Double, ByVal EBNK6_BNK As String, ByVal EBNK8_BNK As String, ByVal EBNK9_BNK As String, ByVal EBNK10_BNK As String, ByVal EBNK11_BNK As String, ByVal EBNK13_BNK As String, ByVal EBNK15_BNK As Byte, ByVal EBNK16_BNK As Byte, ByVal CB1_BNK As String)
        Try

            Dim Consum As New SqlClient.SqlConnection(constring)

            Dim TEXTID As Int64
            GetAutoNumber("EBNK1", "BANKJO", "EBNK3")
            TEXTID = AutoNumber

            Dim cmd As New SqlClient.SqlCommand("INSERT INTO BANKJO(  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16, CB1, USERNAME, CUser, COUser, da, ne) VALUES     (  @EBNK1, @EBNK2, @EBNK3, @EBNK4, @EBNK5, @EBNK6, @EBNK7, @EBNK8, @EBNK9, @EBNK10, @EBNK11, @EBNK12, @EBNK13, @EBNK14, @EBNK15, @EBNK16, @CB1, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@EBNK1", TEXTID)
            cmd.Parameters.AddWithValue("@EBNK2", Format(Val(SumAmounTOTALBALANCE(EBNK10_BNK, TEXTID)), "0.000")) '1
            cmd.Parameters.AddWithValue("@EBNK3", MaxDate.ToString("yyyy-MM-dd")) '2
            cmd.Parameters.AddWithValue("@EBNK4", EBNK4_BNK) '3
            cmd.Parameters.AddWithValue("@EBNK5", EBNK5_BNK) '4
            cmd.Parameters.AddWithValue("@EBNK6", EBNK6_BNK) '5
            cmd.Parameters.AddWithValue("@EBNK7", Format(Val(SumAmounTOTALBALANCE(EBNK10_BNK, TEXTID)), "0.000")) '6
            cmd.Parameters.AddWithValue("@EBNK8", EBNK8_BNK) '7
            cmd.Parameters.AddWithValue("@EBNK9", EBNK9_BNK) '8
            cmd.Parameters.AddWithValue("@EBNK10", EBNK10_BNK) '9
            cmd.Parameters.AddWithValue("@EBNK11", EBNK11_BNK) '10
            cmd.Parameters.AddWithValue("@EBNK12", True)
            cmd.Parameters.AddWithValue("@EBNK13", EBNK13_BNK)
            cmd.Parameters.AddWithValue("@EBNK14", False)
            cmd.Parameters.AddWithValue("@EBNK15", EBNK15_BNK)
            cmd.Parameters.AddWithValue("@EBNK16", EBNK16_BNK)
            cmd.Parameters.AddWithValue("@CB1", CB1_BNK)

            cmd.Parameters.AddWithValue("@USERNAME", USERNAME)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@COUser", COUser)
            cmd.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            'MsgBox("تم اضافة حساب البنك ", MsgBoxStyle.Information, "معلومات")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل اضافة حساب البنك ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Insert_EMPSOLF(ByVal T1 As String, ByVal result As String, ByVal PreviousBalance As Double, ByVal start_CASH As Double, ByVal end_CASH As Double, CurrentBalance As Double, ByVal Combo_N As String, ByVal Combo1_N As String, ByVal Chec As Byte, ByVal nem_N As String, ByVal no_N As String, ByVal result1 As String, ByVal Chec1 As Byte, ByVal CB_1 As String, ByVal BN_2 As String)
        'On Error Resume Next

        Try

            Dim Consum As New SqlClient.SqlConnection(constring)

            Dim TEXTID As Int64
            GetAutoNumber("CSH1", "EMPSOLF", "CSH2")
            TEXTID = AutoNumber
            Dim cmd As New SqlClient.SqlCommand("INSERT INTO EMPSOLF(  CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH13, CSH14, CSH15, CSH16, CSH17, CSH18, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@CSH1, @CSH2, @CSH3, @CSH4, @CSH5, @CSH6, @CSH7, @CSH8, @CSH9, @CSH10, @CSH11, @CSH12, @CSH13, @CSH14, @CSH15, @CSH16, @CSH17, @CSH18, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)", Consum)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@CSH1", TEXTID)
            cmd.Parameters.AddWithValue("@CSH2", MaxDate.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@CSH3", T1)
            cmd.Parameters.AddWithValue("@CSH4", result)
            cmd.Parameters.AddWithValue("@CSH5", "نقدا")
            cmd.Parameters.AddWithValue("@CSH6", PreviousBalance)
            cmd.Parameters.AddWithValue("@CSH7", start_CASH)
            cmd.Parameters.AddWithValue("@CSH8", end_CASH)
            cmd.Parameters.AddWithValue("@CSH9", CurrentBalance)
            cmd.Parameters.AddWithValue("@CSH10", Combo_N)
            cmd.Parameters.AddWithValue("@CSH11", Combo1_N)
            cmd.Parameters.AddWithValue("@CSH12", "من حساب حركة" & " _ " & nem_N & " _ " & result)
            cmd.Parameters.AddWithValue("@CSH13", Chec)
            cmd.Parameters.AddWithValue("@CSH14", nem_N)
            cmd.Parameters.AddWithValue("@CSH15", no_N)
            cmd.Parameters.AddWithValue("@CSH16", False)
            cmd.Parameters.AddWithValue("@CSH17", result1)
            cmd.Parameters.AddWithValue("@CSH18", Chec1)
            cmd.Parameters.AddWithValue("@CB1", CB_1)
            cmd.Parameters.AddWithValue("@BN2", BN_2)
            cmd.Parameters.AddWithValue("@USERNAME", USERNAME)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@COUser", COUser)
            cmd.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            'MsgBox("تم اضافة حساب عهدة الموظفين ", MsgBoxStyle.Information, "معلومات")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "فشل اضافة حساب عهدة الموظفين ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Insert_Suppliers1(ByVal dat As String, ByVal start_CASH As Double, ByVal end_CASH As Double, ByVal PaymentMethod As String, ByVal InvoiceNumber As String,
                                 ByVal Combo_N As String, ByVal nem_N As String, ByVal no_N As String, ByVal Condition As String, ByVal FundValue As Double,
                                 ByVal ValueOfCheck As Double, ByVal form_N As String, ByVal MovementSymbol As String,
                                 ByVal CheckDrawerName As String, ByVal CheckDrawerCode As String, ByVal CheckNumber As String, ByVal CheckDate As String, ByVal CB_1 As String, ByVal BN_2 As String)


        'On Error Resume Next
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)

            Dim TEXTID As Int64
            GetAutoNumber("IDCAB", "Suppliers1", "CAB3")
            TEXTID = AutoNumber

            Dim cmd As New SqlClient.SqlCommand("INSERT INTO Suppliers1(IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CB1, BN2, USERNAME, Cuser, COUser, da, ne) VALUES  ( @IDCAB, @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB7, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB13, @CAB14, @CAB15, @CAB16, @CAB17, @CAB18, @CAB19, @CAB20, @CAB21, @CAB22, @CAB23, @CB1, @BN2, @USERNAME, @Cuser, @COUser, @da, @ne)", Consum)

            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@IDCAB", TEXTID)
            cmd.Parameters.AddWithValue("@CAB2", Format(Val(SumAmounTOTALCASHANDCHEQUES1(CUser, TEXTID)), "0.000"))
            cmd.Parameters.AddWithValue("@CAB3", dat)
            cmd.Parameters.AddWithValue("@CAB4", start_CASH)
            cmd.Parameters.AddWithValue("@CAB5", end_CASH)
            cmd.Parameters.AddWithValue("@CAB6", PaymentMethod)
            cmd.Parameters.AddWithValue("@CAB7", Format(Val(SumAmounTOTALCASHANDCHEQUES1(CUser, TEXTID)), "0.000"))
            cmd.Parameters.AddWithValue("@CAB8", InvoiceNumber)
            cmd.Parameters.AddWithValue("@CAB9", Combo_N)
            cmd.Parameters.AddWithValue("@CAB10", nem_N)
            cmd.Parameters.AddWithValue("@CAB11", no_N)
            cmd.Parameters.AddWithValue("@CAB12", Condition)
            cmd.Parameters.AddWithValue("@CAB13", True)
            cmd.Parameters.AddWithValue("@CAB14", FundValue)
            cmd.Parameters.AddWithValue("@CAB15", ValueOfCheck)
            cmd.Parameters.AddWithValue("@CAB16", form_N)
            cmd.Parameters.AddWithValue("@CAB17", False)
            cmd.Parameters.AddWithValue("@CAB18", MovementSymbol)
            cmd.Parameters.AddWithValue("@CAB19", False)

            cmd.Parameters.AddWithValue("@CAB20", CheckDrawerName)
            cmd.Parameters.AddWithValue("@CAB21", CheckDrawerCode)
            cmd.Parameters.AddWithValue("@CAB22", CheckNumber)
            cmd.Parameters.AddWithValue("@CAB23", CheckDate)

            cmd.Parameters.AddWithValue("@CB1", CB_1)
            cmd.Parameters.AddWithValue("@BN2", BN_2)

            cmd.Parameters.AddWithValue("@USERNAME", USERNAME)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@COUser", COUser)
            cmd.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()

            'MsgBox("تم اضافة حساب الموردين ", MsgBoxStyle.Information, "معلومات")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Errorinsert_Suppliers1", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub Insert_CABLES(ByVal IDCAB As Integer, ByVal dat As String, ByVal TEXTDebit As Double, ByVal TEXTCredit As Double, ByVal TEXTType As String, ByVal TEXTDocumentNumber As String,
                             ByVal TEXTStatement As String, ByVal nem_N As String, ByVal no_N As String, ByVal TextCondition As String, ByVal TextCustomerType As String,
                             ByVal TextFundValue As Double, ByVal PaymentMethod As String, ByVal CheckNumber As String, ByVal Source As String,
                             ByVal CheckDate As Date, ByVal TotalN As String, ByVal MovementSymbol As String, ByVal BANK As String,
                             ByVal Branch As String, ByVal CheckTransfer As Boolean, ByVal CheckSettlement As Boolean,
                             ByVal ValueOfCh As Double, ByVal CheckDrawerName As String, ByVal CheckDrawerCode As String, ByVal CB1 As String, ByVal BN2 As String)


        'On Error Resume Next 
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim cmd As New SqlClient.SqlCommand("INSERT INTO CABLES(IDCAB, CAB2, CAB3, CAB4, CAB5, CAB6, CAB7, CAB8, CAB9, CAB10, CAB11, CAB12, CAB13, CAB14, CAB15, CAB16, CAB17, CAB18, CAB19, CAB20, CAB21, CAB22, CAB23, CAB24, CAB25, CAB26, CAB27, CAB28, CB1, BN2, USERNAME, Cuser, COUSER, da, ne) VALUES  (@IDCAB, @CAB2, @CAB3, @CAB4, @CAB5, @CAB6, @CAB7, @CAB8, @CAB9, @CAB10, @CAB11, @CAB12, @CAB13, @CAB14, @CAB15, @CAB16, @CAB17, @CAB18, @CAB19, @CAB20, @CAB21, @CAB22, @CAB23, @CAB24, @CAB25, @CAB26, @CAB27, @CAB28, @CB1, @BN2, @USERNAME, @Cuser, @COUSER, @da, @ne)", Consum)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@IDCAB", IDCAB)
            cmd.Parameters.AddWithValue("@CAB2", Format(Val(SumAmounTOTALCASHANDCHEQUES(no_N, IDCAB)), "0.000"))
            cmd.Parameters.AddWithValue("@CAB3", dat)
            cmd.Parameters.AddWithValue("@CAB4", TEXTDebit)
            cmd.Parameters.AddWithValue("@CAB5", TEXTCredit)
            cmd.Parameters.AddWithValue("@CAB6", TEXTType)
            cmd.Parameters.AddWithValue("@CAB7", Format(Val(SumAmounTOTALCASHANDCHEQUES(no_N, IDCAB)), "0.000"))
            cmd.Parameters.AddWithValue("@CAB8", TEXTDocumentNumber)
            cmd.Parameters.AddWithValue("@CAB9", TEXTStatement)
            cmd.Parameters.AddWithValue("@CAB10", nem_N)
            cmd.Parameters.AddWithValue("@CAB11", no_N)
            cmd.Parameters.AddWithValue("@CAB12", TextCondition)
            cmd.Parameters.AddWithValue("@CAB13", TextCustomerType)
            cmd.Parameters.AddWithValue("@CAB14", TextFundValue)
            cmd.Parameters.AddWithValue("@CAB15", PaymentMethod)
            cmd.Parameters.AddWithValue("@CAB16", CheckNumber)
            cmd.Parameters.AddWithValue("@CAB17", Source)
            cmd.Parameters.AddWithValue("@CAB18", CheckDate)
            cmd.Parameters.AddWithValue("@CAB19", TotalN)
            cmd.Parameters.AddWithValue("@CAB20", False)
            cmd.Parameters.AddWithValue("@CAB21", MovementSymbol)
            cmd.Parameters.AddWithValue("@CAB22", BANK)
            cmd.Parameters.AddWithValue("@CAB23", Branch)
            cmd.Parameters.AddWithValue("@CAB24", CheckTransfer)
            cmd.Parameters.AddWithValue("@CAB25", CheckSettlement)
            cmd.Parameters.AddWithValue("@CAB26", ValueOfCh)
            cmd.Parameters.AddWithValue("@CAB27", CheckDrawerName)
            cmd.Parameters.AddWithValue("@CAB28", CheckDrawerCode)
            cmd.Parameters.AddWithValue("@CB1", CB1)
            cmd.Parameters.AddWithValue("@BN2", BN2)

            cmd.Parameters.AddWithValue("@USERNAME", USERNAME)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@COUser", COUser)
            cmd.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
            'MsgBox("تم اضافة حساب العملاء ", MsgBoxStyle.Information, "معلومات")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Errorinsert_CABLES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Function ExecuteScalarLoadData(ByVal connection As SqlConnection, ByVal query As String, ByVal CUser As String, ByVal Year As String, Optional ByVal invoiceNumber As String = "", Optional ByVal TB1 As String = "", Optional ByVal TB2 As String = "", Optional ByVal TB3 As String = "") As Object
        Try
            Using cmd As New SqlCommand(query, connection)
                cmd.Parameters.Add("@CUser", SqlDbType.NVarChar).Value = CUser
                cmd.Parameters.Add("@Year", SqlDbType.NVarChar).Value = Year
                cmd.Parameters.Add("@invoiceNumber", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(invoiceNumber), "", invoiceNumber)
                cmd.Parameters.Add("@TB1", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TB1), "", TB1)
                cmd.Parameters.Add("@TB2", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TB2), "", TB2)
                cmd.Parameters.Add("@TB3", SqlDbType.NVarChar).Value = If(String.IsNullOrEmpty(TB3), "", TB3)
                Return cmd.ExecuteScalar()
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed
            Throw New ApplicationException("Error executing scalar query", ex)
        End Try
    End Function


End Module
