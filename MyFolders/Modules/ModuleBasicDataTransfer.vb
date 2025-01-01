Imports System.Data.SqlClient

Friend Module ModuleBasicDataTransfer
    Public Property Trans As SqlTransaction
    ' Private variables declaration...
    Private DateMovementHistory As Date
    Private CSH6 As String
    Private CSH14 As String
    Private CSH15 As String
    Private ReadOnly Lo As Int64
    Private DocumentNumber As String = DBNull.Value.ToString
    Private Duration As String = DBNull.Value.ToString
    Private TBNK4 As String
    Private TBNK5 As String
    Private TBNK7 As String
    Private TBNK8 As String
    Private TBNK9 As Date = ServerDateTime.ToString("yyyy-MM-dd")
    Private TBNK10 As Date = ServerDateTime.ToString("yyyy-MM-dd")
    Private TBNK11 As String
    Private TBNK13 As String
    Private TBNK14 As String
    Private TBNK15 As String
    Private TBNK16 As String
    Private TBNK19 As String
    Private TBNK20 As String
    Private TBNK21 As String
    Private TBNK6 As Integer
    Private OpeningBalance As Double
    Private TBNK22 As String = ""
    Private TBNK23 As Integer = 0
    Private CheckDate As Date
    Private CB1 As String = ""
    Private BN2 As String = ""
    Private STK1 As Int64
    Private TEXTID As Int64
    Private Mov2 As Integer

    Public Sub BasicDataTransfer(ByVal XxFB As FinaBalances2)
        Try
            Using Consum As New SqlConnection(constring)
                Consum.Open()

                ' Fetch data from the database
                Dim ds_CASHIER As DataSet = FetchData(Consum, "SELECT CSH18, CSH19 FROM CASHIER WHERE Year(CSH2) = @FiscalYear AND CUser = @CUser GROUP BY CSH18, CSH19", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_BANKJO As DataSet = FetchData(Consum, "SELECT EBNK10, EBNK11 FROM BANKJO WHERE CUser = @CUser AND Year(EBNK3) = @FiscalYear GROUP BY EBNK10, EBNK11", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_Checks As DataSet = FetchData(Consum, "SELECT IDCH FROM Checks WHERE CH17 = @CH17 AND CUser = @CUser", False, CUser)
                Dim ds_Deposits As DataSet = FetchData(Consum, "SELECT TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK13, TBNK15, TBNK15, TBNK16, TBNK19, TBNK20, TBNK21 FROM Deposits WHERE CUser = @CUser AND Year(TBNK3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_Shares_2 As DataSet = FetchData(Consum, "SELECT TBNK22, TBNK23, TBNK2, TBNK3, TBNK4, TBNK5, OpeningBalance1, TBNK6, TBNK8, CUser FROM shares2 WHERE CUser = @CUser AND Year(TBNK3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_Shares_1 As DataSet = FetchData(Consum, "SELECT TBNK23, TBNK22, TBNK2, TBNK3, TBNK6, TBNK8, TBNK4, TBNK5, OpeningBalance, CUser FROM shares1 WHERE CUser = @CUser AND Year(TBNK3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_shares2 As DataSet = FetchData(Consum, "SELECT TBNK22, TBNK23, TBNK2, TBNK3, TBNK4, TBNK5, OpeningBalance1, TBNK6, TBNK8, CB1, BN2, CUser FROM shares2 WHERE CUser = @CUser AND Year(TBNK3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_shares1 As DataSet = FetchData(Consum, "SELECT TBNK23, TBNK22, TBNK2, TBNK3, TBNK6, TBNK8, TBNK4, TBNK5, OpeningBalance, CB1, BN2, CUser FROM shares1 WHERE CUser = @CUser AND Year(TBNK3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_SumCABLES As DataSet = FetchData(Consum, "SELECT IDCAB FROM SumCABLES WHERE CUser = @CUser AND Year(CAB3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_SumSuppliers As DataSet = FetchData(Consum, "SELECT IDCAB FROM SumSuppliers WHERE CUser = @CUser AND Year(CAB3) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_SumEMPSOLF As DataSet = FetchData(Consum, "SELECT Sumcsh, CSH14, CSH15 FROM SumEMPSOLF WHERE CUser = @CUser AND Year(CSH2) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim ds_CustomersCABLES As DataSet = FetchData(Consum, "SELECT Lo FROM CustomersCABLES2 WHERE CUser = @CUser AND Year(lo2) = @FiscalYear", FiscalYear_currentDateMustBeInFiscalYear(), CUser)
                Dim dsSTOCKS As DataSet = FetchData(Consum, "SELECT STK1 FROM STOCKS WHERE CUser = @CUser AND STK13 > @STK13", 0, CUser)

                Using ConTransaction As New SqlConnection(constring)
                    ConTransaction.Open()
                    Dim command As SqlCommand = ConTransaction.CreateCommand()
                    Trans = ConTransaction.BeginTransaction()
                    command.Connection = ConTransaction
                    command.Transaction = Trans

                    Try
                        ' Insert data into Previouspost table
                        InsertPreviousPostData(XxFB, command, Trans)

                        ' Insert data into CASHIER table
                        InsertCashierData(ds_CASHIER, command, Trans)

                        ' Insert data into BANKJO table
                        InsertBankJoData(ds_BANKJO, command, Trans)

                        ' Update Checks table
                        UpdateChecksData(ds_Checks, command, Trans)

                        ' Insert data into Deposits table
                        InsertDepositsData(ds_Deposits, ds_Shares_1, ds_Shares_2, command, Trans)

                        ' Insert data into PTRANSACTION table
                        InsertPTransactionData(ds_shares1, ds_shares2, command, Trans)

                        ' Update CABLES table
                        UpdateCablesData(ds_SumCABLES, command, Trans)

                        ' Update Suppliers1 table
                        UpdateSuppliersData(ds_SumSuppliers, command, Trans)

                        ' Insert data into EMPSOLF table
                        InsertEmpSolfData(ds_SumEMPSOLF, command, Trans)

                        ' Update Loans table
                        UpdateLoansData(ds_CustomersCABLES, command, Trans)

                        ' Update STOCKS table
                        UpdateStocksData(dsSTOCKS, command, Trans)

                        Trans.Commit()

                        ' Insert opening balances
                        InsertOpeningBalances(XxFB)

                        XxFB.Labelstatus.Image = My.Resources.accept
                        XxFB.Labelstatus.Text = "تمت عملية ترحيل الحسابات الافتتاحية بنجاح" & Space(8)
                        XxFB.CircularProgress3.IsRunning = False
                    Catch ex As Exception
                        XxFB.Labelstatus.Text = "Commit Exception Type: {0}"
                        XxFB.Labelstatus.Image = My.Resources.Cancel_16x16
                        MessageBox.Show(ex.Message, "ErrorTransaction", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Try
                            Trans.Rollback()
                            XxFB.Labelstatus.Text = "Rollback completed successfully." & Space(8)
                            XxFB.Labelstatus.Image = My.Resources.Reset2_16x16
                        Catch exRollback As Exception
                            XxFB.Labelstatus.Text = "Rollback Exception Type: {0}" & Space(8)
                            XxFB.Labelstatus.Image = My.Resources.Cancel_16x16
                            MessageBox.Show(exRollback.Message, "ErrorRollback", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End Try
                End Using
            End Using
        Catch ex As Exception
            XxFB.CircularProgress3.IsRunning = False
            MessageBox.Show(ex.Message, "ErrorSaveMOVES", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function FetchData(connection As SqlConnection, query As String, ParamArray parameters() As Object) As DataSet
        Dim ds As New DataSet()
        Using cmd As New SqlCommand(query, connection)
            For i As Integer = 0 To parameters.Length - 1 Step 2
                cmd.Parameters.AddWithValue(parameters(i).ToString(), parameters(i + 1))
            Next
            Using adapter As New SqlDataAdapter(cmd)
                adapter.Fill(ds)
            End Using
        End Using
        Return ds
    End Function

    Private Sub InsertPreviousPostData(XxFB As FinaBalances2, command As SqlCommand, transaction As SqlTransaction)
        For i As Integer = 0 To XxFB.DataGridView1.RowCount - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ - ترحيل الحسابات الختامية(الاصول)"
            command.CommandText = "INSERT INTO Previouspost( MOVD4, MOVD3, SUMDEBIT, SUMCREDIT, AccountKind, yearearlier, MOV9, CUser, COUser) VALUES     (@MOVD4, @MOVD3, @SUMDEBIT, @SUMCREDIT, @AccountKind, @yearearlier, @MOV9, @CUser, @COUser)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                With CMD.Parameters
                    .AddWithValue("@MOVD4", XxFB.DataGridView1.Rows(i).Cells("account_no").Value).DbType = DbType.String
                    .AddWithValue("@MOVD3", XxFB.DataGridView1.Rows(i).Cells("account_name").Value).DbType = DbType.String
                    .AddWithValue("@SUMDEBIT", XxFB.DataGridView1.Rows(i).Cells("Finabalances1").Value).DbType = DbType.String
                    .AddWithValue("@SUMCREDIT", "0").DbType = DbType.String
                    .AddWithValue("@AccountKind", XxFB.DataGridView1.Rows(i).Cells("ACC").Value).DbType = DbType.String
                    .AddWithValue("@yearearlier", FiscalYear_currentDateMustBeInFiscalYear()).DbType = DbType.String
                    .AddWithValue("@MOV9", "قيد").DbType = DbType.String
                    .AddWithValue("@CUser", CUser) '
                    .AddWithValue("@COUser", COUser) '
                End With
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next

        For i As Integer = 0 To XxFB.DataGridView2.RowCount - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ - ترحيل الحسابات الختامية(الاصول)"
            command.CommandText = "INSERT INTO Previouspost( MOVD4, MOVD3, SUMDEBIT, SUMCREDIT, AccountKind, yearearlier, MOV9, CUser, COUser) VALUES     (@MOVD4, @MOVD3, @SUMDEBIT, @SUMCREDIT, @AccountKind, @yearearlier, @MOV9, @CUser, @COUser)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                With CMD.Parameters
                    .AddWithValue("@MOVD4", XxFB.DataGridView2.Rows(i).Cells("account_no1").Value).DbType = DbType.String
                    .AddWithValue("@MOVD3", XxFB.DataGridView2.Rows(i).Cells("account_name1").Value).DbType = DbType.String
                    .AddWithValue("@SUMDEBIT", "0").DbType = DbType.String
                    .AddWithValue("@SUMCREDIT", XxFB.DataGridView2.Rows(i).Cells("Debits").Value).DbType = DbType.String
                    .AddWithValue("@AccountKind", XxFB.DataGridView2.Rows(i).Cells("ACC1").Value).DbType = DbType.String
                    .AddWithValue("@yearearlier", FiscalYear_currentDateMustBeInFiscalYear()).DbType = DbType.String
                    .AddWithValue("@MOV9", "قيد").DbType = DbType.String
                    .AddWithValue("@CUser", CUser) '
                    .AddWithValue("@COUser", COUser) '
                End With
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub InsertCashierData(ds_CASHIER As DataSet, command As SqlCommand, transaction As SqlTransaction)
        'حسابات الصندوق
        Dim XxFB As New FinaBalances2
        For II As Integer = 0 To ds_CASHIER.Tables(0).Rows.Count - 1
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            GetAutoNumber("CSH1", "CASHIER", "CSH2")
            TEXTID = AutoNumber
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات الصندوق -ـ-ـ-ـ"
            CB1 = ds_CASHIER.Tables(0).Rows(II).Item("CSH18")
            CB2 = ds_CASHIER.Tables(0).Rows(II).Item("CSH19")
            DateMovementHistory = "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1
            Dim DocumentNumber As Integer = FiscalYear_currentDateMustBeInFiscalYear() + 1 & II
            If ds_CASHIER.Tables(0).Rows.Count > II Then
                TEXTID += II
            Else
                TEXTID += 0
            End If
            command.CommandText = "INSERT INTO CASHIER(  CSH1, CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH14, CSH15, CSH16, CSH17, CSH18, CSH19, USERNAME, CUser, COUser, da, ne) VALUES     (  @CSH1, @CSH2, @CSH3, @CSH4, @CSH5, @CSH6, @CSH7, @CSH8, @CSH9, @CSH10, @CSH11, @CSH12, @CSH14, @CSH15, @CSH16, @CSH17, @CSH18, @CSH19, @USERNAME, @CUser, @COUser, @da, @ne)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                With CMD
                    .Parameters.AddWithValue("@CSH1", TEXTID)
                    .Parameters.AddWithValue("@CSH2", DateMovementHistory.ToString("yyyy-MM-dd"))
                    .Parameters.AddWithValue("@CSH3", "قيد افتتاحي")
                    .Parameters.AddWithValue("@CSH4", "CH" & TEXTID)
                    .Parameters.AddWithValue("@CSH5", "نقداً")
                    .Parameters.AddWithValue("@CSH6", Format(SumAmounTOTALBALANCECASHIER11(CUser, CB1, TEXTID), "0.000"))
                    .Parameters.AddWithValue("@CSH7", 0)
                    .Parameters.AddWithValue("@CSH8", 0)
                    .Parameters.AddWithValue("@CSH9", Format(SumAmounTOTALBALANCECASHIER11(CUser, CB1, TEXTID), "0.000"))
                    .Parameters.AddWithValue("@CSH10", SqlDbType.NVarChar).Value = "الصندوق"
                    .Parameters.AddWithValue("@CSH11", "نهاية الفترة المالية" & " " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")")
                    .Parameters.AddWithValue("@CSH12", "رصيد الصندوق بنهاية العام")
                    .Parameters.AddWithValue("@CSH14", False)
                    .Parameters.AddWithValue("@CSH15", DocumentNumber)
                    .Parameters.AddWithValue("@CSH16", False)
                    .Parameters.AddWithValue("@CSH17", False)
                    .Parameters.AddWithValue("@CSH18", CB1)
                    .Parameters.AddWithValue("@CSH19", CB2)
                    .Parameters.AddWithValue("@USERNAME", USERNAME)
                    .Parameters.AddWithValue("@CUser", CUser)
                    .Parameters.AddWithValue("@COUser", COUser)
                    .Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                    .Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                End With
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub InsertBankJoData(ds_BANKJO As DataSet, command As SqlCommand, transaction As SqlTransaction)
        'حسابات البنك 
        Dim XxFB As New FinaBalances2
        For II As Integer = 0 To ds_BANKJO.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات البنك -ـ-ـ-ـ"
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            BN2 = ds_BANKJO.Tables(0).Rows(II).Item("EBNK10")
            BN3 = ds_BANKJO.Tables(0).Rows(II).Item("EBNK11")
            If ds_BANKJO.Tables(0).Rows.Count > II Then
                TEXTID += II
            Else
                TEXTID += 0
            End If
            Dim DocumentNumber As Integer = FiscalYear_currentDateMustBeInFiscalYear() + 1 & II
            command.CommandText = "INSERT INTO BANKJO(  EBNK1, EBNK2, EBNK3, EBNK4, EBNK5, EBNK6, EBNK7, EBNK8, EBNK9, EBNK10, EBNK11, EBNK12, EBNK13, EBNK14, EBNK15, EBNK16, USERNAME, CUser, COUser, da, ne) VALUES     (  @EBNK1, @EBNK2, @EBNK3, @EBNK4, @EBNK5, @EBNK6, @EBNK7, @EBNK8, @EBNK9, @EBNK10, @EBNK11, @EBNK12, @EBNK13, @EBNK14, @EBNK15, @EBNK16, @USERNAME, @CUser, @COUser, @da, @ne)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                CMD.Parameters.Clear()
                CMD.Parameters.AddWithValue("@EBNK1", TEXTID) '1
                CMD.Parameters.AddWithValue("@EBNK2", SumAmounTOTALBALANCE(BN2, TEXTID)) '1
                CMD.Parameters.AddWithValue("@EBNK3", "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1) '2
                CMD.Parameters.AddWithValue("@EBNK4", 0) '3
                CMD.Parameters.AddWithValue("@EBNK5", 0) '4
                CMD.Parameters.AddWithValue("@EBNK6", DocumentNumber) '5
                CMD.Parameters.AddWithValue("@EBNK7", SumAmounTOTALBALANCE(BN2, TEXTID)) '6
                CMD.Parameters.AddWithValue("@EBNK8", "ترحيل") '7
                CMD.Parameters.AddWithValue("@EBNK9", "نهاية الفترة المالية" & " " & "(" & FiscalYear_currentDateMustBeInFiscalYear() & ")") '8
                CMD.Parameters.AddWithValue("@EBNK10", BN2) '9
                CMD.Parameters.AddWithValue("@EBNK11", BN3) '10
                CMD.Parameters.AddWithValue("@EBNK12", True)
                CMD.Parameters.AddWithValue("@EBNK13", "BA" & TEXTID)
                CMD.Parameters.AddWithValue("@EBNK14", False)
                CMD.Parameters.AddWithValue("@EBNK15", False)
                CMD.Parameters.AddWithValue("@EBNK16", False)
                'cmd.Parameters.AddWithValue("@CB1", CB1_BNK)
                CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
                CMD.Parameters.AddWithValue("@CUser", CUser)
                CMD.Parameters.AddWithValue("@COUser", COUser)
                CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub UpdateChecksData(ds_Checks As DataSet, command As SqlCommand, transaction As SqlTransaction)
        If command Is Nothing Then
            Throw New ArgumentNullException(NameOf(command))
        End If

        Dim XxFB As New FinaBalances2
        ''حسابات الشيكات
        For Ix As Integer = 0 To ds_Checks.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات الشيكات -ـ-ـ-ـ"
            IDCH = ds_Checks.Tables(0).Rows(Ix).Item("IDCH")
            Dim parameters As SqlParameter() = {
                New SqlParameter("@IDCH", IDCH),
                New SqlParameter("@CH2", "1-1-" & (FiscalYear_currentDateMustBeInFiscalYear() + 1))
            }
            ExecuteNonQuery("UPDATE Checks SET CH2 = @CH2 WHERE IDCH = @IDCH", parameters, transaction)
        Next
    End Sub

    Private Sub InsertDepositsData(ds_Deposits As DataSet, ds_Shares_1 As DataSet, ds_Shares_2 As DataSet, command As SqlCommand, transaction As SqlTransaction)
        ''حسابات الاعضاء
        Dim XxFB As New FinaBalances2
        For II As Integer = 0 To ds_Deposits.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات الاعضاء -ـ-ـ-ـ"
            TBNK4 = ds_Deposits.Tables(0).Rows(II).Item("TBNK4")
            TBNK5 = ds_Deposits.Tables(0).Rows(II).Item("TBNK5")
            TBNK6 = ds_Deposits.Tables(0).Rows(II).Item("TBNK6")
            TBNK7 = ds_Deposits.Tables(0).Rows(II).Item("TBNK7")
            TBNK8 = ds_Deposits.Tables(0).Rows(II).Item("TBNK8")
            TBNK9 = ds_Deposits.Tables(0).Rows(II).Item("TBNK9")
            TBNK10 = ds_Deposits.Tables(0).Rows(II).Item("TBNK10")
            TBNK11 = ds_Deposits.Tables(0).Rows(II).Item("TBNK11")
            TBNK13 = ds_Deposits.Tables(0).Rows(II).Item("TBNK13")
            TBNK14 = ds_Deposits.Tables(0).Rows(II).Item("TBNK14")
            TBNK15 = ds_Deposits.Tables(0).Rows(II).Item("TBNK15")
            TBNK16 = ds_Deposits.Tables(0).Rows(II).Item("TBNK16")
            TBNK19 = ds_Deposits.Tables(0).Rows(II).Item("TBNK19")
            TBNK20 = ds_Deposits.Tables(0).Rows(II).Item("TBNK20")
            TBNK21 = ds_Deposits.Tables(0).Rows(II).Item("TBNK21")
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            If ds_Deposits.Tables(0).Rows.Count > II Then
                TEXTID += II
            Else
                TEXTID += 0
            End If
            DocumentNumber = ds_Deposits.Tables(0).Rows(II).Item("TBNK23")
            Duration = ds_Deposits.Tables(0).Rows(II).Item("TBNK24")
            CB1 = ds_Deposits.Tables(0).Rows(II).Item("CB1")
            For Ix As Integer = 0 To ds_Shares_1.Tables(0).Rows.Count - 1
                If ds_Deposits.Tables(0).Rows(II).Item("TBNK19") = ds_Shares_1.Tables(0).Rows(Ix).Item("TBNK8") Then
                    TBNK19 = ds_Shares_1.Tables(0).Rows(Ix).Item("TBNK8")
                    OpeningBalance = ds_Shares_1.Tables(0).Rows(Ix).Item("OpeningBalance")
                Else
                    For Ix1 As Integer = 0 To ds_Shares_2.Tables(0).Rows.Count - 1
                        TBNK19 = ds_Shares_2.Tables(0).Rows(Ix1).Item("TBNK8")
                        OpeningBalance = ds_Shares_2.Tables(0).Rows(Ix1).Item("OpeningBalance1")
                    Next
                End If
            Next
            command.CommandText = "INSERT INTO Deposits(TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK19, @TBNK20, @TBNK21, @TBNK22, @TBNK23, @TBNK24, @CB1, @USERNAME, @CUser, @COUser, @da, @ne)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                CMD.Parameters.AddWithValue("@TBNK1", TEXTID)
                CMD.Parameters.AddWithValue("@TBNK2", OpeningBalance)
                CMD.Parameters.AddWithValue("@TBNK3", "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1)
                CMD.Parameters.AddWithValue("@TBNK4", TBNK4)
                CMD.Parameters.AddWithValue("@TBNK5", TBNK5)
                CMD.Parameters.AddWithValue("@TBNK6", TBNK6)
                CMD.Parameters.AddWithValue("@TBNK7", TBNK7)
                CMD.Parameters.AddWithValue("@TBNK8", TBNK8)
                CMD.Parameters.AddWithValue("@TBNK9", TBNK9.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@TBNK10", TBNK10.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@TBNK11", TBNK11)
                CMD.Parameters.AddWithValue("@TBNK12", False)
                CMD.Parameters.AddWithValue("@TBNK13", TBNK13)
                CMD.Parameters.AddWithValue("@TBNK14", TBNK14)
                CMD.Parameters.AddWithValue("@TBNK15", TBNK15)
                CMD.Parameters.AddWithValue("@TBNK16", TBNK16)
                CMD.Parameters.AddWithValue("@TBNK17", False)
                CMD.Parameters.AddWithValue("@TBNK18", "SD" & TEXTID)
                CMD.Parameters.AddWithValue("@TBNK19", TBNK19)
                CMD.Parameters.AddWithValue("@TBNK20", TBNK20)
                CMD.Parameters.AddWithValue("@TBNK21", TBNK21)
                CMD.Parameters.AddWithValue("@TBNK22", True)
                CMD.Parameters.AddWithValue("@TBNK23", DocumentNumber)
                CMD.Parameters.AddWithValue("@TBNK24", Duration)
                CMD.Parameters.AddWithValue("@CB1", CB1)
                CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
                CMD.Parameters.AddWithValue("@CUser", CUser)
                CMD.Parameters.AddWithValue("@COUser", COUser)
                CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub InsertPTransactionData(ds_shares1 As DataSet, ds_shares2 As DataSet, command As SqlCommand, transaction As SqlTransaction)
        ''حسابات السحب والايداع 
        Dim XxFB As New FinaBalances2
        For Ix As Integer = 0 To ds_shares1.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات السحب والايداع -ـ-ـ-ـ"
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            If ds_shares1.Tables(0).Rows.Count > Ix Then
                TEXTID += Ix
            Else
                TEXTID += 0
            End If
            TBNK6 = ds_shares1.Tables(0).Rows(Ix).Item("TBNK6")
            OpeningBalance = ds_shares1.Tables(0).Rows(Ix).Item("OpeningBalance")
            TBNK8 = ds_shares1.Tables(0).Rows(Ix).Item("TBNK8")
            CheckDate = "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 2
            TBNK22 = ds_shares1.Tables(0).Rows(Ix).Item("TBNK22")
            TBNK23 = ds_shares1.Tables(0).Rows(Ix).Item("TBNK23")
            CB1 = ds_shares1.Tables(0).Rows(Ix).Item("CB1")
            BN2 = ds_shares1.Tables(0).Rows(Ix).Item("BN2")
            Dim DocumentNumber As Integer = FiscalYear_currentDateMustBeInFiscalYear() + 1 & Ix
            command.CommandText = "INSERT INTO PTRANSACTION(TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK19, @TBNK20, @TBNK21, @TBNK22, @TBNK23, @TBNK24, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                CMD.Parameters.AddWithValue("@TBNK1", TEXTID)
                CMD.Parameters.AddWithValue("@TBNK2", OpeningBalance)
                CMD.Parameters.AddWithValue("@TBNK3", "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1)
                CMD.Parameters.AddWithValue("@TBNK4", "0.000")
                CMD.Parameters.AddWithValue("@TBNK5", "0.000")
                CMD.Parameters.AddWithValue("@TBNK6", TBNK6)
                CMD.Parameters.AddWithValue("@TBNK7", OpeningBalance)
                CMD.Parameters.AddWithValue("@TBNK8", TBNK8)
                CMD.Parameters.AddWithValue("@TBNK9", DocumentNumber)
                CMD.Parameters.AddWithValue("@TBNK10", "سنوى")
                CMD.Parameters.AddWithValue("@TBNK11", "WD" & TEXTID)
                CMD.Parameters.AddWithValue("@TBNK12", False)
                CMD.Parameters.AddWithValue("@TBNK13", False)
                CMD.Parameters.AddWithValue("@TBNK14", "ترحيل")
                CMD.Parameters.AddWithValue("@TBNK15", "0.00")
                CMD.Parameters.AddWithValue("@TBNK16", "0.00")
                CMD.Parameters.AddWithValue("@TBNK17", True)
                CMD.Parameters.AddWithValue("@TBNK18", "ترحيل")
                CMD.Parameters.AddWithValue("@TBNK19", 0)
                CMD.Parameters.AddWithValue("@TBNK20", CheckDate.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@TBNK21", DBNull.Value)
                CMD.Parameters.AddWithValue("@TBNK22", TBNK22)
                CMD.Parameters.AddWithValue("@TBNK23", TBNK23)
                CMD.Parameters.AddWithValue("@TBNK24", 0)
                CMD.Parameters.AddWithValue("@CB1", CB1)
                CMD.Parameters.AddWithValue("@BN2", BN2)
                CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
                CMD.Parameters.AddWithValue("@CUser", CUser)
                CMD.Parameters.AddWithValue("@COUser", COUser)
                CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next

        'حسابات السحب والايداع 
        For IXX As Integer = 0 To ds_shares2.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات السحب والايداع -ـ-ـ-ـ"
            TBNK6 = ds_shares2.Tables(0).Rows(IXX).Item("TBNK6")
            OpeningBalance = ds_shares2.Tables(0).Rows(IXX).Item("OpeningBalance1")
            TBNK8 = ds_shares2.Tables(0).Rows(IXX).Item("TBNK8")
            CheckDate = "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 2
            TBNK22 = ds_shares2.Tables(0).Rows(IXX).Item("TBNK22")
            TBNK23 = ds_shares2.Tables(0).Rows(IXX).Item("TBNK23")
            CB1 = ds_shares2.Tables(0).Rows(IXX).Item("CB1")
            BN2 = ds_shares2.Tables(0).Rows(IXX).Item("BN2")
            If ds_shares2.Tables(0).Rows.Count > IXX Then
                TEXTID += IXX
            Else
                TEXTID += 0
            End If
            Dim DocumentNumber As Integer = FiscalYear_currentDateMustBeInFiscalYear() + 1 & IXX
            command.CommandText = "INSERT INTO PTRANSACTION(TBNK1, TBNK2, TBNK3, TBNK4, TBNK5, TBNK6, TBNK7, TBNK8, TBNK9, TBNK10, TBNK11, TBNK12, TBNK13, TBNK14, TBNK15, TBNK16, TBNK17, TBNK18, TBNK19, TBNK20, TBNK21, TBNK22, TBNK23, TBNK24, CB1, BN2, USERNAME, CUser, COUser, da, ne) VALUES     (@TBNK1, @TBNK2, @TBNK3, @TBNK4, @TBNK5, @TBNK6, @TBNK7, @TBNK8, @TBNK9, @TBNK10, @TBNK11, @TBNK12, @TBNK13, @TBNK14, @TBNK15, @TBNK16, @TBNK17, @TBNK18, @TBNK19, @TBNK20, @TBNK21, @TBNK22, @TBNK23, @TBNK24, @CB1, @BN2, @USERNAME, @CUser, @COUser, @da, @ne)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                CMD.Parameters.AddWithValue("@TBNK1", TEXTID)
                CMD.Parameters.AddWithValue("@TBNK2", OpeningBalance)
                CMD.Parameters.AddWithValue("@TBNK3", "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1)
                CMD.Parameters.AddWithValue("@TBNK4", "0.000")
                CMD.Parameters.AddWithValue("@TBNK5", "0.000")
                CMD.Parameters.AddWithValue("@TBNK6", TBNK6)
                CMD.Parameters.AddWithValue("@TBNK7", OpeningBalance)
                CMD.Parameters.AddWithValue("@TBNK8", TBNK8)
                CMD.Parameters.AddWithValue("@TBNK9", DocumentNumber)
                CMD.Parameters.AddWithValue("@TBNK10", "سنوى")
                CMD.Parameters.AddWithValue("@TBNK11", "WD" & TEXTID)
                CMD.Parameters.AddWithValue("@TBNK12", False)
                CMD.Parameters.AddWithValue("@TBNK13", False)
                CMD.Parameters.AddWithValue("@TBNK14", "ترحيل")
                CMD.Parameters.AddWithValue("@TBNK15", "0.00")
                CMD.Parameters.AddWithValue("@TBNK16", "0.00")
                CMD.Parameters.AddWithValue("@TBNK17", True)
                CMD.Parameters.AddWithValue("@TBNK18", "ترحيل")
                CMD.Parameters.AddWithValue("@TBNK19", "0")
                CMD.Parameters.AddWithValue("@TBNK20", CheckDate.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@TBNK21", DBNull.Value)
                CMD.Parameters.AddWithValue("@TBNK22", TBNK22)
                CMD.Parameters.AddWithValue("@TBNK23", TBNK23)
                CMD.Parameters.AddWithValue("@TBNK24", "0")
                CMD.Parameters.AddWithValue("@CB1", CB1)
                CMD.Parameters.AddWithValue("@BN2", BN2)
                CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
                CMD.Parameters.AddWithValue("@CUser", CUser)
                CMD.Parameters.AddWithValue("@COUser", COUser)
                CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next

    End Sub

    Private Sub UpdateCablesData(ds_SumCABLES As DataSet, command As SqlCommand, transaction As SqlTransaction)
        ''حسابات العملاء
        Dim XxFB As New FinaBalances2
        For Ix As Integer = 0 To ds_SumCABLES.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات العملاء -ـ-ـ-ـ"
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            If ds_SumCABLES.Tables(0).Rows.Count > Ix Then
                TEXTID += Ix
            Else
                TEXTID += 0
            End If
            TEXTID = ds_SumCABLES.Tables(0).Rows(Ix).Item("IDCAB")
            Dim parameters As SqlParameter() = {
                New SqlParameter("@IDCAB", TEXTID),
                New SqlParameter("@CAB3", "1-1-" & (FiscalYear_currentDateMustBeInFiscalYear() + 1))
            }
            Try
                ExecuteNonQuery("UPDATE CABLES SET CAB3 = @CAB3 WHERE IDCAB = @IDCAB", parameters, transaction)
            Catch ex As Exception
                ' Handle any errors that occur during the update
                XxFB.Labelstatus.Text = "Error updating CABLES data: " & ex.Message
                XxFB.Labelstatus.Image = My.Resources.Cancel_16x16
                Throw
            End Try
        Next
    End Sub

    Private Sub UpdateSuppliersData(ds_SumSuppliers As DataSet, command As SqlCommand, transaction As SqlTransaction)
        ' Update supplier accounts
        Dim XxFB As New FinaBalances2
        For II As Integer = 0 To ds_SumSuppliers.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات الموردين -ـ-ـ-ـ"
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            If ds_SumSuppliers.Tables(0).Rows.Count > II Then
                IDCAB += II
            Else
                IDCAB += 0
            End If

            ' Prepare parameters
            Dim parameters As SqlParameter() = {
        New SqlParameter("@IDCAB", IDCAB),
        New SqlParameter("@CAB3", "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1)
    }

            ' Execute the command
            Try
                ExecuteNonQuery("UPDATE Suppliers1 SET CAB3 = @CAB3 WHERE IDCAB = @IDCAB", parameters, transaction)
            Catch ex As Exception
                ' Handle any errors that occur during the update
                XxFB.Labelstatus.Text = "Error updating supplier data: " & ex.Message
                XxFB.Labelstatus.Image = My.Resources.Cancel_16x16
                Throw
            End Try
        Next
    End Sub

    Private Sub InsertEmpSolfData(ds_SumEMPSOLF As DataSet, command As SqlCommand, transaction As SqlTransaction)
        'عهدة الموظفي
        Dim XxFB As New FinaBalances2
        For II As Integer = 0 To ds_SumEMPSOLF.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات عهدة الموظفين -ـ-ـ-ـ"
            GetAutoNumberOpeningRecord()
            TEXTID = AutoNumber
            If ds_SumEMPSOLF.Tables(0).Rows.Count > II Then
                TEXTID += II
            Else
                TEXTID += 0
            End If
            CSH6 = ds_SumEMPSOLF.Tables(0).Rows(II).Item("Sumcsh")
            CSH14 = ds_SumEMPSOLF.Tables(0).Rows(II).Item("CSH14")
            CSH15 = ds_SumEMPSOLF.Tables(0).Rows(II).Item("CSH15")
            command.CommandText = "INSERT INTO EMPSOLF( CSH2, CSH3, CSH4, CSH5, CSH6, CSH7, CSH8, CSH9, CSH10, CSH11, CSH12, CSH13, CSH14, CSH15, CSH16, CSH17, CSH18, USERNAME, CUser, COUser, da, ne) VALUES     (@CSH2, @CSH3, @CSH4, @CSH5, @CSH6, @CSH7, @CSH8, @CSH9, @CSH10, @CSH11, @CSH12, @CSH13, @CSH14, @CSH15, @CSH16, @CSH17, @CSH18, @USERNAME, @CUser, @COUser, @da, @ne)"
            Using CMD As New SqlCommand(command.CommandText, transaction.Connection, Trans)
                CMD.Parameters.AddWithValue("@CSH1", TEXTID)
                CMD.Parameters.AddWithValue("@CSH2", "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1)
                CMD.Parameters.AddWithValue("@CSH3", "ايداع")
                CMD.Parameters.AddWithValue("@CSH4", "1-1")
                CMD.Parameters.AddWithValue("@CSH5", "نقدا")
                CMD.Parameters.AddWithValue("@CSH6", CSH6)
                CMD.Parameters.AddWithValue("@CSH7", 0)
                CMD.Parameters.AddWithValue("@CSH8", 0)
                CMD.Parameters.AddWithValue("@CSH9", CSH6)
                CMD.Parameters.AddWithValue("@CSH10", "عهدة الموظفين")
                CMD.Parameters.AddWithValue("@CSH11", "نهاية الفترة المالية")
                CMD.Parameters.AddWithValue("@CSH12", "من حساب حركة _نهاية الفترة المالية")
                CMD.Parameters.AddWithValue("@CSH13", True)
                CMD.Parameters.AddWithValue("@CSH14", CSH14)
                CMD.Parameters.AddWithValue("@CSH15", CSH15)
                CMD.Parameters.AddWithValue("@CSH16", False)
                CMD.Parameters.AddWithValue("@CSH17", "PS" & TEXTID)
                CMD.Parameters.AddWithValue("@CSH18", False)
                CMD.Parameters.AddWithValue("@USERNAME", USERNAME)
                CMD.Parameters.AddWithValue("@CUser", CUser)
                CMD.Parameters.AddWithValue("@COUser", COUser)
                CMD.Parameters.AddWithValue("@da", ServerDateTime.ToString("yyyy-MM-dd"))
                CMD.Parameters.AddWithValue("@ne", ServerDateTime.ToString("hh:mm:ss tt"))
                CMD.CommandTimeout = 3600
                CMD.ExecuteNonQuery()
            End Using
        Next
    End Sub

    Private Sub UpdateLoansData(ds_CustomersCABLES As DataSet, command As SqlCommand, transaction As SqlTransaction)
        If command Is Nothing Then
            Throw New ArgumentNullException(NameOf(command))
        End If
        'حسابات عهدة الذمم المدينة
        Dim XxFB As New FinaBalances2
        For IX As Integer = 0 To ds_CustomersCABLES.Tables(0).Rows.Count - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات عهدة الذمم المدينة -ـ-ـ-ـ"
            Dim parameters As SqlParameter() = {
                New SqlParameter("@lo", Lo),
                New SqlParameter("@lo2", "1-1-" & (FiscalYear_currentDateMustBeInFiscalYear() + 1))
            }
            ExecuteNonQuery("UPDATE Loans SET lo2 = @lo2 WHERE lo = @lo", parameters, transaction)
        Next
    End Sub

    Private Sub UpdateStocksData(dsSTOCKS As DataSet, command As SqlCommand, transaction As SqlTransaction)
        If command Is Nothing Then
            Throw New ArgumentNullException(NameOf(command))
        End If
        'حسابات عهدة الاصناف
        Dim XxFB As New FinaBalances2
        Try
            For Each row As DataRow In dsSTOCKS.Tables(0).Rows
                XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل حسابات عهدة الاصناف -ـ-ـ-ـ"
                STK1 = row("STK1").ToString()
                Dim parameters As SqlParameter() = {
                New SqlParameter("@STK1", STK1),
                New SqlParameter("@STK4", "1-1-" & (FiscalYear_currentDateMustBeInFiscalYear() + 1))
            }
                ExecuteNonQuery("UPDATE STOCKS SET STK4 = @STK4 WHERE STK1 = @STK1", parameters, transaction)
            Next
        Catch ex As Exception
            ' Log the error
            XxFB.Labelstatus.Text = "Error updating stocks: " & ex.Message
            Throw
        End Try
    End Sub

    Private Sub InsertOpeningBalances(XxFB As FinaBalances2)
        'الحسابات الافتتاحية
        GetAutoNumberOpeningRecord()
        TEXTID = AutoNumber
        Mov2 = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2) + 1 & CUser & 1
        AccountingEntries(TEXTID, TEXTID, "1-1-" & FiscalYear_currentDateMustBeInFiscalYear() + 1, "ارصدة نهاية سنة" & FiscalYear_currentDateMustBeInFiscalYear(), False, "0.00", "0.00", TEXTID, "فيد افتتاحي", "RD", "RD" & Mov2, False)
        For i As Integer = 0 To XxFB.DataGridView1.RowCount - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل الحسابات الافتتاحية -ـ-ـ-ـ"
            DetailsAccountingEntries(XxFB.DataGridView1.Rows(i).Index + 1, XxFB.DataGridView1.Rows(i).Cells("account_name").Value,
                                     XxFB.DataGridView1.Rows(i).Cells("account_no").Value, XxFB.DataGridView1.Rows(i).Cells("Finabalances1").Value,
                                     0, "ارصدة نهاية سنة" & FiscalYear_currentDateMustBeInFiscalYear(), XxFB.DataGridView1.Rows(i).Cells("ACC").Value, "RD" & Mov2,
                                     Mov2, False, TEXTID)
        Next
        'الحسابات الافتتاحية
        For i As Integer = 0 To XxFB.DataGridView2.RowCount - 1
            XxFB.Labelstatus.Text = "الرجاء الانتظار ـ- ترحيل الحسابات الافتتاحية -ـ-ـ-ـ"
            DetailsAccountingEntries(XxFB.DataGridView2.Rows(i).Index + 1, XxFB.DataGridView2.Rows(i).Cells("account_name1").Value,
                                     XxFB.DataGridView2.Rows(i).Cells("account_no1").Value, 0,
                                     XxFB.DataGridView2.Rows(i).Cells("Debits").Value, "ارصدة نهاية سنة" & FiscalYear_currentDateMustBeInFiscalYear(), XxFB.DataGridView2.Rows(i).Cells("ACC1").Value, "RD" & Mov2,
                                     Mov2, False, TEXTID)
        Next

    End Sub




    Private Sub ExecuteNonQuery(commandText As String, parameters As SqlParameter(), transaction As SqlTransaction)
        Using CMD As New SqlCommand(commandText, transaction.Connection, transaction)
            CMD.Parameters.AddRange(parameters)
            CMD.CommandTimeout = 3600
            CMD.ExecuteNonQuery()
        End Using
    End Sub






End Module
