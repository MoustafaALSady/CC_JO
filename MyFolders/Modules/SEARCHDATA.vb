Imports System.Data.SqlClient
Imports System.Runtime.CompilerServices
Imports Microsoft.VisualBasic.CompilerServices


Module SEARCHDATA
    Public IDCasher As Int64
    Public IDChecks As Int64
    Public IDDeposits As Int64
    Public MAXDeposits As Int64
    Public MAXIDAllCustomers As Int64
    Public MAXIDLoans As Int64
    Public MAXBudget As Int64
    Public IDEmpsolf As Int64
    Public IDJO As Int64
    Public IDTransaction As Int64
    Public IDCUSTOMER1 As Int64
    Public IDCUSTOMER11 As Int64
    Public IDInvoice As Int64
    Public IDCustomerPay As Int64
    Public IDCustomersA As Int64
    Public IDTransport As Int64
    Public IDLoans As Int64
    Public IDEmpCost As Int64
    Public IDEmployees3 As Int64
    Public IDEmployees4 As Int64
    Public IDMyCosts As Int64
    Public IDJPG As Int64
    Public IDStocks1 As Int64
    Public IDStocks2 As Int64
    Public IDSuppliers1 As Int64
    Public IDSuppliesA As Int64
    Public IDSuppliersPay As Int64
    Public IDFatora As Int64
    Public Account_No As Int64
    Public ACC As Integer
    Public Account_Name As String
    Public ACC1 As Integer
    Public MAXMOV1 As Int64
    Public MAXMOV2 As Int64
    Public MAXMOV8 As Int64
    Public MAXSTK1 As Int64
    Public sumSTK As Double
    Public T1 As Int64
    Public T2 As Int64
    Public T3 As Int64
    Public MOV1 As Int64
    Public MOV1A As Int64
    Public MOV1B As Int64
    Public MOV1C As Int64
    Public MOV1VE As Int64
    Public MOV2 As Int64
    Public MOV2A As Int64
    Public MOV2B As Int64
    Public MOV2C As Int64
    Public MOV2D As Int64
    Public MOV2E As Int64
    Public MOV2F As Int64
    Public MOV2ADELET As Int64
    Public MOV2BDELET As Int64
    Public MOV2CDELET As Int64
    Public MOV2DDELET As Int64
    Public MOV2EDELET As Int64
    Public MOV2KS As Int64
    Public MOV2KSA As Int64
    Public MOV2KSB As Int64
    Public MOV2KSC As Int64
    Public MOV2KSD As Int64
    Public MOV2KSDELET As Int64
    Public MOV2KSADELET As Int64
    Public MOV2KSBDELET As Int64
    Public MOV2KSCDELET As Int64
    Public MOV2KSDDELET As Int64
    Public MOVD1 As Int64
    Public MOVDELET As Int64
    Public MOVDELETVE As Int64
    Public MOV1DELET As Int64
    Public MOVADELET As Int64
    Public MOVD1A As Int64
    Public MOVD1B As Int64
    Public MOVD9A As String
    Public CSH1 As Int64
    Public CSH1A As Int64
    Public CSH1B As Int64
    Public CSH1C As Int64
    Public CSH1E As Int64
    Public IDCH As Int64
    Public IDCH1 As Int64
    Public IDCH2 As Int64
    Public IDCH3 As Int64
    Public BoxDocumentNumber As Int64
    Public EBNK1JO As Int64
    Public STK1 As Int64
    Public STK1A As Int64
    Public STK1B As Int64
    Public STK16 As Int64
    Public IDSTK As Int64
    Public IDCAB As Int64
    Public IDCAB1 As Int64
    Public IDCABS As Int64
    Public IDCABS1 As Int64
    Public IDCABS2 As Int64
    Public IDCABS3 As Int64
    Public Loa1 As Int64
    Public Lo1 As Int64
    Public TBNK1 As Int64
    Public TBNK1A As Int64
    Public TBNK1B As Int64
    Public EBNK1 As Int64
    Public PTRO1 As Int64
    Public PTRO1A As Int64
    Public CEMP3 As Int64
    Public CST1 As Int64
    Public CSDT As Int64
    Public BUY1 As Int64
    Public SLS1 As Int64
    Public SLSCASH As Boolean
    Public BUYCASH As Boolean
    Public SLY1 As Int64
    Public Logentry As String
    Public AutoNumber As Int64
    Public NumberDOCUMENTSFL As Int64
    Public NoDocuments As Int64
    Public NumberMyDOCUMENTSFL As Int64
    Public NumberMyDocuments As Int64

    Public Function SEARCHLogentry(ByVal USERLogentry As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT EBNK1 FROM BANKJO WHERE EBNK13 = @USERLogentry", connection)
                    selectCommand.Parameters.AddWithValue("@USERLogentry", USERLogentry)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "BANKJO")
                        If dataSet.Tables(0).Rows.Count > 0 Then
                            SEARCHDATA.EBNK1JO = dataSet.Tables(0).Rows(0).Item(0)
                        Else
                            SEARCHDATA.EBNK1JO = Nothing
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.EBNK1JO = Nothing
        End Try
        Return SEARCHDATA.EBNK1JO
    End Function

    Public Function GetAutoNumberCOUser() As Integer
        Dim CUser_A As Integer
        Dim NO As Integer = 0
        Try
            Using Consum As New SqlConnection(constring)
                Using SQL As New SqlCommand("SELECT MAX(CUser) FROM COMPANY WHERE COUser = @COUser", Consum)
                    SQL.Parameters.AddWithValue("@COUser", COUser)
                    Consum.Open()
                    Dim resualt As Object = SQL.ExecuteScalar()
                    If IsDBNull(resualt) Then
                        resualt = 0
                    End If
                    If resualt >= 1 AndAlso resualt <= 9 Then
                        resualt = COUser & "0000"
                    ElseIf resualt >= 10 AndAlso resualt <= 12 Then
                        resualt = COUser & "000"
                    End If
                    Dim CUserA As Integer = Mid(CType(resualt, Integer), 2)
                    Select Case CType(CUserA, Integer)
                        Case 1 To 9
                            NO = CDbl(COUser) & "000"
                        Case 10 To 99
                            NO = CDbl(COUser) & "00"
                        Case 100 To 999
                            NO = CDbl(COUser) & "0"
                        Case Else
                            NO = CDbl(COUser)
                    End Select
                    If resualt >= 1 AndAlso resualt <= 12 Then
                        CUser_A = CType(NO, Integer) & CType(resualt, Integer) + 1
                    Else
                        CUser_A = CType(resualt, Integer) + 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            CUser_A = COUser & CType(NO, Integer) & 1
        End Try
        Return CUser_A
    End Function

    Public Function GetAutoNumberMyDOCUMENTS() As Integer
        Dim Result As Object = Nothing
        Try
            Using Consum As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("SELECT MAX(DOC2) FROM MYDOCUMENTSHOME WHERE CUser = @CUser AND Year(date_1) = @FiscalYear", Consum)
                cmd1.Parameters.AddWithValue("@CUser", CUser)
                cmd1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                Consum.Open()
                Result = cmd1.ExecuteScalar()
            End Using
            If IsDBNull(Result) OrElse Result Is Nothing Then
                SEARCHDATA.NumberMyDocuments = Convert.ToInt32(CUser) * 10 + 1
            Else
                SEARCHDATA.NumberMyDocuments = Convert.ToInt32(Result) + 1
            End If
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.NumberMyDocuments = Nothing
        End Try
        Return SEARCHDATA.NumberMyDocuments
    End Function

    Public Function GetAutoNumberMyDOCUMENTSFL(ByVal LO As String) As Integer
        Dim Result As Object = Nothing
        Try
            Using Consum As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("SELECT MAX(DOC2) FROM MYDOCUMENTSHOME WHERE CUser = @CUser AND LO = @LO", Consum)
                cmd1.Parameters.AddWithValue("@CUser", CUser)
                cmd1.Parameters.AddWithValue("@LO", LO)
                Consum.Open()
                Result = cmd1.ExecuteScalar()
            End Using
            If IsDBNull(Result) OrElse Result Is Nothing Then
                SEARCHDATA.NumberMyDOCUMENTSFL = Convert.ToInt32(CUser) * 10 + 1
            Else
                SEARCHDATA.NumberMyDOCUMENTSFL = Convert.ToInt32(Result) + 1
            End If
        Catch ex As Exception
            ' Log the exception (e.g., using a logging framework)
            SEARCHDATA.NumberMyDOCUMENTSFL = Nothing
        End Try
        Return SEARCHDATA.NumberMyDOCUMENTSFL

    End Function

    Public Function GetAutoNumberDOCUMENTS() As Integer
        Try
            Dim Result As Object = Nothing
            Using Consum As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("SELECT MAX(DOC2) FROM DOCUMENTS WHERE CUser = @CUser AND Year(date_1) = @FiscalYear", Consum)
                cmd1.Parameters.AddWithValue("@CUser", CUser)
                cmd1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                Consum.Open()
                Result = cmd1.ExecuteScalar()
            End Using

            If IsDBNull(Result) OrElse Result Is Nothing Then
                SEARCHDATA.NoDocuments = Convert.ToInt32(CUser) * 10 + 1
            Else
                SEARCHDATA.NoDocuments = Convert.ToInt32(Result) + 1
            End If
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.NoDocuments = Nothing
        End Try
        Return SEARCHDATA.NoDocuments
    End Function

    Public Function GetAutoNumberDOCUMENTSFL(ByVal LO As String) As Integer
        Dim Result As Object = Nothing
        Try
            Using Consum As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("SELECT MAX(DOC2) FROM DOCUMENTS WHERE CUser = @CUser AND LO = @LO", Consum)
                cmd1.Parameters.AddWithValue("@CUser", CUser)
                cmd1.Parameters.AddWithValue("@LO", LO)
                Consum.Open()
                Result = cmd1.ExecuteScalar()
            End Using
            If IsDBNull(Result) OrElse Result Is Nothing Then
                SEARCHDATA.NumberDOCUMENTSFL = Convert.ToInt32(CUser) * 10 + 1
            Else
                SEARCHDATA.NumberDOCUMENTSFL = Convert.ToInt32(Result) + 1
            End If
        Catch ex As Exception
            ' Log the exception (e.g., using a logging framework)
            SEARCHDATA.NumberDOCUMENTSFL = Nothing
        End Try
        Return SEARCHDATA.NumberDOCUMENTSFL
    End Function

    Public Function MAXIDBudget() As Object
        Try
            Dim NO As Integer = 0
            Dim NO1 As Integer = 0
            Dim Result As Object
            Using Consum As New SqlConnection(constring)
                Dim cmd1 As New SqlCommand("SELECT MAX(IDFL) FROM FinancialList WHERE CUser = @CUser", Consum)
                cmd1.Parameters.AddWithValue("@CUser", CUser)
                Consum.Open()
                Result = cmd1.ExecuteScalar()
            End Using
            Dim noD As Integer = If(IsDBNull(Result), 0, Convert.ToInt32(Mid(Result.ToString(), 4)))
            Dim CUsera As Integer = Convert.ToInt32(CUser)
            Select Case CUsera
                Case 1 To 9
                    NO = CUsera & "000"
                Case 10 To 99
                    NO = CUsera & "00"
                Case 100 To 999
                    NO = CUsera & 0
                Case Else
                    NO = CUsera
            End Select
            SEARCHDATA.MAXBudget = NO + noD + 1
            Return SEARCHDATA.MAXBudget
        Catch ex As Exception
            ' Handle exception (e.g., log it)
            Return Nothing
        End Try
    End Function

    Public Function MAXIDDeposits() As Object
        Try
            Using Consum As New SqlConnection(constring)
                Using cmd1 As New SqlCommand("SELECT MAX(TBNK6) FROM Deposits WHERE CUser = @CUser", Consum)
                    cmd1.Parameters.AddWithValue("@CUser", CUser)
                    Consum.Open()
                    Dim resualt As Object = cmd1.ExecuteScalar()
                    If IsDBNull(resualt) Then
                        SEARCHDATA.MAXDeposits = CType(CUser, Integer) & 1
                    Else
                        SEARCHDATA.MAXDeposits = CType(resualt, Integer) + 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MAXDeposits = Nothing
        End Try
        Return SEARCHDATA.MAXDeposits
    End Function

    Public Function MAXAllCustomers() As Object
        Dim maxID As Object = Nothing
        Try
            Using connection As New SqlConnection(constring)
                Using command As New SqlCommand("SELECT MAX(AllCustomers.IDcust) FROM AllCustomers WHERE CUser = @CUser", connection)
                    command.Parameters.AddWithValue("@CUser", CUser)
                    connection.Open()
                    Dim Result As Object = command.ExecuteScalar()
                    If IsDBNull(Result) Then
                        maxID = CType(CUser, Integer) & 1
                    Else
                        maxID = CType(Result, Integer) + 1
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            maxID = Nothing
        End Try
        MAXIDAllCustomers = maxID
        Return maxID
    End Function

    Public Function MAXLoans() As Object
        Try
            Dim Year As String = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim NO As String = If(CUser < 10, "000", If(CUser < 100, "00", If(CUser < 1000, "0", "")))
            Dim NO1 As String = Year & NO & CUser
            Using Consum As New SqlConnection(constring)
                Dim query As String = "SELECT MAX(Loans.LO) FROM Loans WHERE CUser = @CUser AND Year(LO2) = @FiscalYear"
                Using cmd2 As New SqlCommand(query, Consum)
                    cmd2.Parameters.AddWithValue("@CUser", CUser)
                    cmd2.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                    Consum.Open()
                    Dim resualt2 As Object = cmd2.ExecuteScalar()
                    Dim noD As Integer = If(IsDBNull(resualt2), 0, Convert.ToInt32(Strings.Mid(resualt2.ToString(), 7)))
                    SEARCHDATA.MAXIDLoans = Convert.ToInt64(NO1) * 10 + noD + 1
                End Using
            End Using

            Return SEARCHDATA.MAXIDLoans
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            Return Nothing
        End Try
    End Function

    Public Function MAXIDCASHIER() As Object
        Try
            Dim Year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
            Dim query As String = "SELECT MAX(CSH15) FROM CASHIER WHERE CUser = @CUser AND Year(CSH2) = @Year"

            Using Consum As New SqlConnection(constring)
                Using cmd1 As New SqlCommand(query, Consum)
                    cmd1.Parameters.AddWithValue("@CUser", CUser)
                    cmd1.Parameters.AddWithValue("@Year", FiscalYear_currentDateMustBeInFiscalYear())

                    Consum.Open()
                    Dim Result As Object = cmd1.ExecuteScalar()

                    If IsDBNull(Result) Then
                        SEARCHDATA.BoxDocumentNumber = Year * 100 + 1
                    Else
                        SEARCHDATA.BoxDocumentNumber = CType(Result, Integer) + 1
                    End If
                End Using
            End Using

            Return BoxDocumentNumber
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            Return Nothing
        End Try
    End Function

    Public Function SumBalanceItems(ByVal ComboStore As Integer, ByVal ItemCode As String, TEXTID As DevExpress.XtraEditors.TextEdit) As Double
        Try
            Dim SUM1 As Double
            Using Consum As New SqlConnection(constring)
                Consum.Open()
                Dim query As String = "SELECT Sum(STK11 - STK12) FROM STOCKS WHERE STOCKS.CUser = @CUser AND STOCKS.WarehouseNumber = @WarehouseNumber AND STOCKS.STK25 = @ItemCode AND STOCKS.STK1 < @StockID"
                Using strsq1 As New SqlCommand(query, Consum)
                    strsq1.Parameters.AddWithValue("@CUser", CUser)
                    strsq1.Parameters.AddWithValue("@WarehouseNumber", ComboStore)
                    strsq1.Parameters.AddWithValue("@ItemCode", ItemCode)
                    strsq1.Parameters.AddWithValue("@StockID", TEXTID)
                    Using reader As SqlDataReader = strsq1.ExecuteReader()
                        If reader.Read() AndAlso Not IsDBNull(reader(0)) Then
                            Double.TryParse(reader(0).ToString(), SUM1)
                        Else
                            SUM1 = 0
                        End If
                    End Using
                End Using
            End Using
            Return Math.Round(SUM1, 3)
        Catch ex As Exception
            ' Handle exception
            MessageBox.Show("An error occurred: " & ex.Message)
            Return 0
        End Try
    End Function

    Public Function SumBalanceItemsA(ByVal ComboStore As Integer, ByVal ItemCode As String, TEXTID As Object) As Double
        Try
            Dim SUM1 As Double
            Using Consum As New SqlConnection(constring)
                Consum.Open()
                Dim query As String = "SELECT Sum(STK11 - STK12) FROM STOCKS WHERE STOCKS.CUser = @CUser AND STOCKS.WarehouseNumber = @WarehouseNumber AND STOCKS.STK25 = @ItemCode AND STOCKS.STK1 < @StockID"
                Using strsq1 As New SqlCommand(query, Consum)
                    strsq1.Parameters.AddWithValue("@CUser", CUser)
                    strsq1.Parameters.AddWithValue("@WarehouseNumber", ComboStore)
                    strsq1.Parameters.AddWithValue("@ItemCode", ItemCode)
                    strsq1.Parameters.AddWithValue("@StockID", TEXTID)
                    Using reader As SqlDataReader = strsq1.ExecuteReader()
                        If reader.Read() AndAlso Not IsDBNull(reader(0)) Then
                            Double.TryParse(reader(0).ToString(), SUM1)
                        Else
                            SUM1 = 0
                        End If
                    End Using
                End Using
            End Using
            Return Math.Round(SUM1, 3)
        Catch ex As Exception
            ' Handle exception
            MessageBox.Show("An error occurred: " & ex.Message)
            Return 0
        End Try
    End Function

    Private Function ExecuteScalarQuery(query As String, parameters As Dictionary(Of String, Object)) As Object
        Using consum As New SqlConnection(constring)
            Using cmd As New SqlCommand(query, consum)
                For Each param In parameters
                    cmd.Parameters.AddWithValue(param.Key, param.Value)
                Next
                Try
                    consum.Open()
                    Return cmd.ExecuteScalar()
                Catch ex As Exception
                    ' Log the exception
                    MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                End Try
            End Using
        End Using
    End Function

    Public Function GetAutoIDSTK() As Int64
        Try
            AutoNumber = GetAutoNumber("STK1", "STOCKS", "STK4")
            IDSTK = AutoNumber
            Return IDSTK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorGetAutoIDSTK", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return -1
        End Try
    End Function

    Public Function GetAutoNumber(ByVal field As String, ByVal table As String, ByVal field1 As String) As Int64
        Dim year As Integer = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim Numb As Int64
        Try
            Numb = Convert.ToInt64(year.ToString() & CType(CUser, Integer).ToString() & "1")
        Catch ex As OverflowException
            Throw New InvalidOperationException("Concatenated value resulted in an overflow.", ex)
        End Try
        AutoNumber = Nothing
        Dim query As String = $"SELECT MAX([{field}]) FROM [{table}] WHERE CUser=@CUser AND Year([{field1}])=@FiscalYear"
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@CUser", CUser},
        {"@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear()}
    }
        Dim result As Object = ExecuteScalarQuery(query, parameters)
        If IsDBNull(result) Then
            AutoNumber = Numb
        Else
            Try
                AutoNumber = CType(result, Int64) + 1
            Catch ex As OverflowException
                Throw New InvalidOperationException("Result increment resulted in an overflow.", ex)
            End Try
        End If
        Return AutoNumber
    End Function

    Public Function GetAutoNumberOpeningRecord() As Int64
        Dim Year As Integer
        Dim NO As String
        Dim NO1 As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2) + 1
        Dim CUserA As Integer = CType(CUser, Integer)
        Select Case CUserA
            Case 1 To 9
                NO = "000"
            Case 10 To 99
                NO = "00"
            Case 100 To 999
                NO = "0"
            Case Else
                NO = ""
        End Select
        NO1 = Year & NO & CUserA
        AutoNumber = NO1 & 1

        Return AutoNumber
    End Function

    Public Function MaxIDMovesMov1() As Int64
        Dim Year As Integer
        Dim NO As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        NO = CType(Year, Integer) & CType(CUser, Integer)
        Using Consum As New SqlConnection(ModuleGeneral.constring)
            Dim cmd1 As New SqlCommand("SELECT MAX(MOVES.MOV1) FROM MOVES WHERE CUser=@CUser AND Year(MOV3)=@FiscalYear", Consum)
            cmd1.Parameters.AddWithValue("@CUser", CUser)
            cmd1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
            Try
                Consum.Open()
                Dim MaxMovA As Object = cmd1.ExecuteScalar()
                If IsDBNull(MaxMovA) Then
                    SEARCHDATA.MAXMOV1 = CType(NO, Integer) & 1
                Else
                    SEARCHDATA.MAXMOV1 = CType(MaxMovA, Integer) + 1
                End If
            Catch ex As Exception
                ' Handle exception (e.g., log the error)
                SEARCHDATA.MAXMOV1 = -1 ' Indicate an error occurred
            End Try
        End Using

        T1 = Val(SEARCHDATA.MAXMOV1)
        Return T1
    End Function

    Public Function MaxIDMovesMov2() As Int64
        Dim Year As Integer
        Dim NO As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        NO = CType(Year, Integer) & CType(CUser, Integer)
        Using Consum As New SqlConnection(ModuleGeneral.constring)
            Dim cmd1 As New SqlCommand("SELECT MAX(MOVES.MOV2) FROM MOVES WHERE CUser=@CUser AND Year(MOV3)=@FiscalYear", Consum)
            cmd1.Parameters.AddWithValue("@CUser", CUser)
            cmd1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
            Try
                Consum.Open()
                Dim MaxMovA As Object = cmd1.ExecuteScalar()
                If IsDBNull(MaxMovA) Then
                    SEARCHDATA.MAXMOV2 = CType(NO, Integer) & 1
                Else
                    SEARCHDATA.MAXMOV2 = CType(MaxMovA, Integer) + 1
                End If
            Catch ex As Exception
                ' Handle exception (e.g., log the error)
                SEARCHDATA.MAXMOV2 = -1 ' Indicate an error occurred
            End Try
        End Using
        T2 = Val(SEARCHDATA.MAXMOV2)
        Return T2
    End Function

    Public Function MaxIDMoves() As Int64
        Dim Year As String = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim NO As Integer = CType(Year, Integer) & CType(CUser, Integer)
        Dim MaxMovA, MaxMovB, MaxMovC As Object
        Using Consum As New SqlConnection(ModuleGeneral.constring)
            Try
                Consum.Open()
                MaxMovA = ExecuteScalar(Consum, "SELECT MAX(MOVES.MOV1) FROM MOVES WHERE CUser=@CUser AND Year(MOV3)=@Year", CUser, FiscalYear_currentDateMustBeInFiscalYear())
                MaxMovB = ExecuteScalar(Consum, "SELECT MAX(MOVES.MOV2) FROM MOVES WHERE CUser=@CUser AND Year(MOV3)=@Year", CUser, FiscalYear_currentDateMustBeInFiscalYear())
                MaxMovC = ExecuteScalar(Consum, "SELECT MAX(MOVES.MOV8) FROM MOVES WHERE CUser=@CUser AND Year(MOV3)=@Year", CUser, FiscalYear_currentDateMustBeInFiscalYear())
                SEARCHDATA.MAXMOV1 = If(MaxMovA = 0, CType(NO, Integer) & 1, MaxMovA + 1)
                SEARCHDATA.MAXMOV2 = If(MaxMovB = 0, CType(NO, Integer) & 1, MaxMovB + 1)
                SEARCHDATA.MAXMOV8 = If(MaxMovC = 0, CType(NO, Integer) & 1, MaxMovC + 1)
                T1 = Val(SEARCHDATA.MAXMOV1)
                T2 = Val(SEARCHDATA.MAXMOV2)
                T3 = Val(SEARCHDATA.MAXMOV8)
            Catch ex As Exception
                ' Handle exception (e.g., log it)
                Throw
            End Try
        End Using
        Return T3
    End Function

    Private Function ExecuteScalar(connection As SqlConnection, query As String, CUser As String, Year As String) As Object
        Using cmd As New SqlCommand(query, connection)
            cmd.Parameters.AddWithValue("@CUser", CUser)
            cmd.Parameters.AddWithValue("@Year", Year)
            Return cmd.ExecuteScalar()
        End Using
    End Function

    Public Function SEARCHAccount_no(ByVal account As String) As Boolean
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT account_no, ACC, account_name, ACC1 FROM ACCOUNTSTREE WHERE account_name = @account", connection)
                    selectCommand.Parameters.AddWithValue("@account", account)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "ACCOUNTSTREE")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.Account_No = Convert.ToInt64(dataSet.Tables(0).Rows(0)("account_no"))
                        SEARCHDATA.ACC = Convert.ToInt32(dataSet.Tables(0).Rows(0)("ACC"))
                        SEARCHDATA.Account_Name = dataSet.Tables(0).Rows(0)("account_name").ToString()
                        Return True
                    Else
                        SEARCHDATA.Account_No = Nothing
                        SEARCHDATA.ACC = Nothing
                        SEARCHDATA.Account_Name = Nothing
                        Return False
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            Return False
        End Try
    End Function

    Public Function SEARCHBANKJO(ByVal EBNK13 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT EBNK1 FROM BANKJO WHERE CUser = @CUser AND EBNK13 = @EBNK13", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@EBNK13", EBNK13)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "BANKJO")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.EBNK1JO = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.EBNK1JO = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Log the exception or handle it as needed
            SEARCHDATA.EBNK1JO = Nothing
        End Try
        Return SEARCHDATA.EBNK1JO
    End Function

    Public Function SEARCHCABLESA(ByVal CAB13 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT IDCAB FROM CABLES WHERE CUser = @CUser AND CAB13 = @CAB13", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@CAB13", CAB13)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "CABLES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.IDCABS3 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.IDCABS3 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.IDCABS3 = Nothing
        End Try
        Return SEARCHDATA.IDCABS3
    End Function

    Public Function SEARCHCABLES(ByVal CAB8 As String, ByVal CAB13 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT IDCAB FROM CABLES WHERE CUser=@CUser AND CAB8=@CAB8 AND CAB6='نقدا' AND CAB13=@CAB13"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CAB8", CAB8)
                    selectCommand.Parameters.AddWithValue("@CAB13", CAB13)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "CABLES")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.IDCAB = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.IDCAB = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.IDCAB = Nothing
        End Try
        Return SEARCHDATA.IDCAB
    End Function

    Public Function SEARCHCABLES1(ByVal CAB8 As String, ByVal CAB13 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT IDCAB FROM CABLES WHERE CUser = @CUser AND CAB8 = @CAB8 AND CAB6 = 'شيك' AND CAB13 = @CAB13"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CAB8", CAB8)
                    selectCommand.Parameters.AddWithValue("@CAB13", CAB13)
                    Dim dataSet As New DataSet()
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "CABLES")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.IDCAB1 = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.IDCAB1 = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.IDCAB1 = Nothing
        End Try
        Return SEARCHDATA.IDCAB1
    End Function

    Public Function SEARCHCASHIERA1(ByVal CSH4 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE CUser = @CUser AND CSH4 = @CSH4", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CSH4", CSH4)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "CASHIER")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.CSH1C = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.CSH1C = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.CSH1C = Nothing
        End Try
        Return SEARCHDATA.CSH1C
    End Function

    Public Function SEARCHCASHIER(ByVal CSH4 As String, ByVal CSH15 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT CSH1 FROM CASHIER WHERE CUser = @CUser AND CSH4 = @CSH4 AND CSH15 = @CSH15"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CSH4", CSH4)
                    selectCommand.Parameters.AddWithValue("@CSH15", CSH15 & "0")
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "CASHIER")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.CSH1 = dataSet.Tables(0).Rows(0).Item(0).ToString()
                    Else
                        SEARCHDATA.CSH1 = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.CSH1 = Nothing
        End Try
        Return SEARCHDATA.CSH1
    End Function

    Public Function SEARCHCASHIER1(ByVal CSH4 As String, ByVal CSH15 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE CUser = @CUser AND CSH4 = @CSH4 AND CSH15 = @CSH15", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@CSH4", CSH4)
                selectCommand.Parameters.AddWithValue("@CSH15", CSH15)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "CASHIER")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.CSH1B = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.CSH1B = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.CSH1B = Nothing
        End Try
        Return SEARCHDATA.CSH1B
    End Function

    Public Function SEARCHCASHIERA(ByVal CSH4 As String, ByVal CSH15 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE CUser=@CUser AND CSH4=@CSH4 AND CSH15=@CSH15", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CSH4", CSH4)
                    selectCommand.Parameters.AddWithValue("@CSH15", CSH15)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "CASHIER")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.CSH1A = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.CSH1A = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.CSH1A = Nothing
        End Try
        Return SEARCHDATA.CSH1A
    End Function

    Public Function SEARCHDIDChecks(ByVal CH16 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT IDCH FROM Checks WHERE CUser = @CUser AND CH16 = @CH16", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CH16", CH16)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "Checks")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.IDCH = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.IDCH = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.IDCH = Nothing
        End Try
        Return SEARCHDATA.IDCH
    End Function

    Public Function SEARCHDIDChecks1(ByVal CH11 As String, ByVal CH16 As String) As Integer
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT idch FROM Checks WHERE CUser = @CUser AND CH11 = @CH11 AND CH16 = @CH16"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CH11", CH11)
                    selectCommand.Parameters.AddWithValue("@CH16", CH16)

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "Checks")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.IDCH2 = Convert.ToInt64(dataSet.Tables(0).Rows(0).Item(0))
                    Else
                        SEARCHDATA.IDCH2 = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.IDCH2 = 0
        End Try

        Return SEARCHDATA.IDCH2
    End Function

    Public Function SEARCHSLSCASH(ByVal SLS19 As String) As Boolean?
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT TYPE_CASH FROM SALES WHERE CUser = @CUser AND SLS19 = @SLS19", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@SLS19", SLS19)

                Dim dataSet As New DataSet()
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "SALES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.SLSCASH = Convert.ToBoolean(dataSet.Tables(0).Rows(0).Item("TYPE_CASH"))
                Else
                    SEARCHDATA.SLSCASH = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            Return Nothing
        End Try
    End Function

    Public Function SEARCHBUYSCASH(ByVal BUY18 As String) As Boolean?
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT TYPE_CASH FROM BUYS WHERE CUser = @CUser AND BUY18 = @BUY18", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@BUY18", BUY18)

                    Dim dataSet As New DataSet
                    Dim adapter As New SqlDataAdapter(selectCommand)

                    dataSet.Clear()
                    connection.Open()
                    adapter.Fill(dataSet, "BUYS")

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.BUYCASH = Convert.ToBoolean(dataSet.Tables(0).Rows(0).Item(0))
                    Else
                        SEARCHDATA.BUYCASH = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed
            SEARCHDATA.BUYCASH = Nothing
        End Try

        Return SEARCHDATA.BUYCASH
    End Function

    Public Function SEARCHDSuppliersA(ByVal CAB18 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT IDCAB FROM Suppliers1 WHERE CUser = @CUser AND CAB18 = @CAB18", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@CAB18", CAB18)

                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "Suppliers1")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.IDSuppliesA = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.IDSuppliesA = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.IDSuppliesA = Nothing
        End Try

        Return SEARCHDATA.IDSuppliesA
    End Function

    Public Function SEARCHDSuppliers(ByVal CAB8 As String, ByVal CAB18 As String) As String
        Dim x As String = "نقدا"
        Dim query As String = "SELECT DISTINCT IDCAB FROM Suppliers1 WHERE CUser=@CUser AND CAB6=@CAB6 AND CAB8=@CAB8 AND CAB18=@CAB18"

        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CAB6", x.Trim())
                    selectCommand.Parameters.AddWithValue("@CAB8", CAB8)
                    selectCommand.Parameters.AddWithValue("@CAB18", CAB18)

                    Dim dataSet As New DataSet
                    Dim adapter As New SqlDataAdapter(selectCommand)
                    dataSet.Clear()
                    connection.Open()
                    adapter.Fill(dataSet, "Suppliers1")

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.IDCABS = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.IDCABS = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return SEARCHDATA.IDCABS
    End Function

    Public Function SEARCHDSuppliers1(ByVal CAB8 As String, ByVal CAB18 As String) As String
        Dim x As String = "شيك"
        Dim Result As String = Nothing

        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT IDCAB FROM Suppliers1 WHERE CUser=@CUser AND CAB6=@CAB6 AND CAB8=@CAB8 AND CAB18=@CAB18"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CAB6", x)
                    selectCommand.Parameters.AddWithValue("@CAB8", CAB8)
                    selectCommand.Parameters.AddWithValue("@CAB18", CAB18)

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        connection.Open()
                        adapter.Fill(dataSet, "Suppliers1")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        Result = dataSet.Tables(0).Rows(0).Item(0).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
        End Try

        SEARCHDATA.IDCABS1 = Result
        Return Result
    End Function

    Public Function SEARCHDSuppliers2(ByVal CAB8 As String, ByVal CAB18 As String) As String
        Dim x As String = "نقدا_شيك"
        Dim Result As String = Nothing
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT IDCAB FROM Suppliers1 WHERE CUser=@CUser AND CAB6=@CAB6 AND CAB8=@CAB8 AND CAB18=@CAB18", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CAB6", x.Trim())
                    selectCommand.Parameters.AddWithValue("@CAB8", CAB8)
                    selectCommand.Parameters.AddWithValue("@CAB18", CAB18)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "Suppliers1")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        Result = dataSet.Tables(0).Rows(0).Item(0).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            Result = Nothing
        End Try

        SEARCHDATA.IDCABS2 = Result
        Return Result
    End Function

    Public Function SEARCHEMPSOLF(ByVal CSH17 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM EMPSOLF WHERE CUser = @CUser AND CSH17 = @CSH17", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CSH17", CSH17)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "EMPSOLF")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.CSH1E = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.CSH1E = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.CSH1E = Nothing
        End Try
        Return SEARCHDATA.CSH1E
    End Function

    Public Function SEARCHID(ByVal lo25 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT Loa1 FROM LoansPa WHERE CUser = @CUser AND lo25 = @lo25", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@lo25", lo25)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "LoansPa")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    Return dataSet.Tables(0).Rows(0).Item(0).ToString()
                Else
                    Return Nothing
                End If
            End Using
        Catch ex As Exception
            ' Log the exception (you can replace this with your logging mechanism)
            Console.WriteLine("Error: " & ex.Message)
            Return Nothing
        End Try
    End Function

    Public Function SEARCHID1(ByVal Lo17 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT Lo FROM Loans WHERE CUser = @CUser AND lo17 = @Lo17", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@Lo17", Lo17)
                Dim dataSet As New DataSet()
                Dim adapter As New SqlDataAdapter(selectCommand)
                connection.Open()
                adapter.Fill(dataSet, "Loans")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.Lo1 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.Lo1 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.Lo1 = Nothing
        End Try
        Return SEARCHDATA.Lo1
    End Function

    Public Function SEARCHID10(ByVal SLS19 As String) As Integer
        Dim Result As Integer = 0
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT SLS2 FROM SALES WHERE CUser = @CUser AND SLS19 = @SLS19", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@SLS19", SLS19)
                connection.Open()
                Dim reader As SqlDataReader = selectCommand.ExecuteReader()
                If reader.HasRows Then
                    reader.Read()
                    Result = Convert.ToInt64(reader("SLS2"))
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
        End Try
        Return Result
    End Function

    Public Function SEARCHID11(ByVal CH16 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT IDCH FROM Checks WHERE CUser = @CUser AND CH16 = @CH16", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@CH16", CH16)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "Checks")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.IDCH1 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.IDCH1 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.IDCH1 = Nothing
        End Try
        Return SEARCHDATA.IDCH1
    End Function

    Public Function SEARCHID12(ByVal SLY25 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT SLY1 FROM SALARIES WHERE CUser=@CUser AND SLY25=@SLY25", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@SLY25", SLY25)
                Dim adapter As New SqlDataAdapter(selectCommand)
                Dim dataSet As New DataSet()
                connection.Open()
                adapter.Fill(dataSet, "SALARIES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.SLY1 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.SLY1 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.SLY1 = Nothing
        End Try
        Return SEARCHDATA.SLY1
    End Function

    Public Function SEARCHID2(ByVal TBNK18 As String) As Object
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT TBNK1 FROM Deposits WHERE CUser = @CUser AND TBNK18 = @TBNK18", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@TBNK18", TBNK18)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "Deposits")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.TBNK1 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.TBNK1 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.TBNK1 = Nothing
        End Try
        Return SEARCHDATA.TBNK1
    End Function

    Public Function SEARCHID3(ByVal TBNK11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT TBNK1 FROM PTRANSACTION WHERE CUser = @CUser AND TBNK11 = @TBNK11", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@TBNK11", TBNK11)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "PTRANSACTION")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.TBNK1A = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.TBNK1A = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.TBNK1A = Nothing
        End Try
        Return SEARCHDATA.TBNK1A
    End Function

    Public Function SEARCHID31(ByVal TBNK9 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT TBNK1 FROM PTRANSACTION WHERE CUser = @CUser AND TBNK9 = @TBNK9", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@TBNK9", TBNK9)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "PTRANSACTION")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.TBNK1B = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.TBNK1B = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.TBNK1B = Nothing
        End Try
        Return SEARCHDATA.TBNK1B
    End Function

    Public Function SEARCHID4(ByVal EBNK13 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT EBNK1 FROM BANKJO WHERE CUser = @CUser AND EBNK13 = @EBNK13", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@EBNK13", EBNK13)
                    Dim dataSet As New DataSet()
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "BANKJO")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.EBNK1 = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.EBNK1 = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.EBNK1 = Nothing
        End Try
        Return SEARCHDATA.EBNK1
    End Function

    Public Function SEARCHID5(ByVal PTRO23 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT PTRO1 FROM PETRO WHERE CUser = @CUser AND PTRO23 = @PTRO23", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@PTRO23", PTRO23)
                Dim adapter As New SqlDataAdapter(selectCommand)
                Dim dataSet As New DataSet()
                connection.Open()
                adapter.Fill(dataSet, "PETRO")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.PTRO1 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.PTRO1 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.PTRO1 = Nothing
        End Try
        Return SEARCHDATA.PTRO1
    End Function

    Public Function SEARCHID6(ByVal PTRO23 As String) As String
        Dim Result As String = Nothing
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT PTRO1 FROM Invoice WHERE CUser = @CUser AND PTRO23 = @PTRO23", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@PTRO23", PTRO23)
                    connection.Open()
                    Using reader As SqlDataReader = selectCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            Result = reader("PTRO1").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
        End Try
        SEARCHDATA.PTRO1A = Result
        Return Result
    End Function

    Public Function SEARCHID7(ByVal CEMP31 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT CEMP3 FROM CABLESCOEMPLOYEES WHERE CUser = @CUser AND CEMP31 = @CEMP31", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@CEMP31", CEMP31)

                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "CABLESCOEMPLOYEES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.CEMP3 = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.CEMP3 = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.CEMP3 = Nothing
        End Try
        Return SEARCHDATA.CEMP3
    End Function

    Public Function SEARCHID8(ByVal CST13 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT CST1 FROM MYCOSTS WHERE CUser = @CUser AND CST13 = @CST13", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CST13", CST13)
                    connection.Open()
                    Using reader As SqlDataReader = selectCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            SEARCHDATA.CST1 = reader("CST1").ToString()
                        Else
                            SEARCHDATA.CST1 = Nothing
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.CST1 = Nothing
        End Try
        Return SEARCHDATA.CST1
    End Function

    Public Function SEARCHID9(ByVal BUY18 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT BUY2 FROM BUYS WHERE CUser = @CUser AND BUY18 = @BUY18", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@BUY18", BUY18)

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "BUYS")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.BUY1 = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.BUY1 = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.BUY1 = Nothing
        End Try
        Return SEARCHDATA.BUY1
    End Function

    Public Function SEARCHMOVES(ByVal MOV2 As String) As String
        Try
            Dim Result As String = Nothing
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser = @CUser AND MOV2 = @MOV2", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV2", MOV2)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    Result = dataSet.Tables(0).Rows(0).Item(0).ToString()
                End If
            End Using
            SEARCHDATA.MOV1 = Result
            Return Result
        Catch ex As Exception
            ' Log or handle the exception as needed
            Return Nothing
        End Try
        Return SEARCHDATA.MOV1
    End Function

    Public Function SEARCHMOVES1A(ByVal MOV11 As String) As String
        Dim Result As String = Nothing
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRA'", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    Dim dataSet As New DataSet
                    Dim adapter As New SqlDataAdapter(selectCommand)
                    connection.Open()
                    adapter.Fill(dataSet, "MOVES")
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        Result = dataSet.Tables(0).Rows(0).Item(0).ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
        End Try
        SEARCHDATA.MOV2A = Result
        Return Result
    End Function

    Public Function SEARCHMOVES1B(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRB'", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2B = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2B = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2B = Nothing
        End Try
        Return SEARCHDATA.MOV2B
    End Function

    Public Function SEARCHMOVES1C(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRC'", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "MOVES")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOV2C = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOV2C = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2C = Nothing
        End Try
        Return SEARCHDATA.MOV2C
    End Function

    Public Function SEARCHMOVES1D(ByVal MOV11 As String) As String
        Dim Result As String = Nothing
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRD'", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    connection.Open()
                    Using reader As SqlDataReader = selectCommand.ExecuteReader()
                        If reader.HasRows Then
                            reader.Read()
                            Result = reader("MOV2").ToString()
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
        End Try
        SEARCHDATA.MOV2D = Result
        Return Result
    End Function

    Public Function SEARCHMOVES1ADELET(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRA'", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2A = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2A = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log it)
            SEARCHDATA.MOV2A = Nothing
        End Try
        Return SEARCHDATA.MOV2A
    End Function

    Public Function SEARCHMOVES1BDELET(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRB'", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "MOVES")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOV2B = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOV2B = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2B = Nothing
        End Try
        Return SEARCHDATA.MOV2B
    End Function

    Public Function SEARCHMOVES1CDELET(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRC'", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2C = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2C = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.MOV2C = Nothing
        End Try
        Return SEARCHDATA.MOV2C
    End Function

    Public Function SEARCHMOVES1DDELET(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='QRD'", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2D = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2D = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2D = Nothing
        End Try
        Return SEARCHDATA.MOV2D
    End Function

    Public Function SEARCHMOVESDATA(ByVal MOVD9 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOVD1, MOV2, MOVD9 FROM MOVESDATA WHERE CUser = @CUser AND MOVD9 = @MOVD9", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOVD9", MOVD9)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "MOVESDATA")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        MOVD1 = dataSet.Tables(0).Rows(0).Item(0)
                        MOV2 = dataSet.Tables(0).Rows(0).Item(1)
                        MOVD9A = dataSet.Tables(0).Rows(0).Item(2)
                    Else
                        MOVD1 = Nothing
                        MOV2 = Nothing
                        MOVD9A = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            MOVD1 = Nothing
            MOV2 = Nothing
            MOVD9A = Nothing
        End Try
        Return SEARCHDATA.MOV2

    End Function

    Public Function SEARCHMOVESDATAFalse(ByVal MOVD9 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOVD1, MOV2, MOVD7 FROM MOVESDATA WHERE CUser = @CUser AND MOVD9 = @MOVD9 AND MOV3 = @MOV3", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOVD9", MOVD9)
                selectCommand.Parameters.AddWithValue("@MOV3", False)
                Dim dataSet As New DataSet()
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVESDATA")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOVD1B = dataSet.Tables(0).Rows(0).Item(0)
                    SEARCHDATA.MOV2F = dataSet.Tables(0).Rows(0).Item(1)
                Else
                    SEARCHDATA.MOVD1B = Nothing
                    SEARCHDATA.MOV2F = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOVD1B = Nothing
            SEARCHDATA.MOV2F = Nothing
        End Try
        Return SEARCHDATA.MOV2F

    End Function

    Public Function SEARCHMOVESDATATrue(ByVal MOVD9 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT MOVD1, MOV2, MOVD7 FROM MOVESDATA WHERE CUser = @CUser AND MOVD9 = @MOVD9 AND MOV3 = @MOV3"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOVD9", MOVD9)
                    selectCommand.Parameters.AddWithValue("@MOV3", True)

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "MOVESDATA")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOVD1A = dataSet.Tables(0).Rows(0).Item("MOVD1")
                        SEARCHDATA.MOV2E = dataSet.Tables(0).Rows(0).Item("MOV2")
                        Return SEARCHDATA.MOV2E
                    Else
                        SEARCHDATA.MOVD1A = Nothing
                        SEARCHDATA.MOV2E = Nothing
                        Return Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed
            Return Nothing
        End Try
    End Function

    Public Function SEARCHMOVESFalseDELET(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV5=@MOV5", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                selectCommand.Parameters.AddWithValue("@MOV5", False)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOVDELET = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOVDELET = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOVDELET = Nothing
        End Try
        Return SEARCHDATA.MOVDELET
    End Function

    Public Function SEARCHMOVESTrueDELET(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV5=@MOV5", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                selectCommand.Parameters.AddWithValue("@MOV5", True)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV1DELET = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV1DELET = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV1DELET = Nothing
        End Try
        Return SEARCHDATA.MOV1DELET
    End Function

    Public Function SEARCHMOVESTrueDELETA(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV5=@MOV5 AND MOV10='VEA'"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    selectCommand.Parameters.AddWithValue("@MOV5", False)

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        connection.Open()
                        adapter.Fill(dataSet, "MOVES")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOVADELET = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOVADELET = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOVADELET = Nothing
        End Try
        Return SEARCHDATA.MOVADELET
    End Function

    Public Function SEARCHMOVESTrueDELETAVE(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV5=@MOV5 AND MOV10='VE'"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    selectCommand.Parameters.AddWithValue("@MOV5", False)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "MOVES")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOVDELETVE = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOVDELETVE = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log it)
            SEARCHDATA.MOVDELETVE = Nothing
        End Try
        Return SEARCHDATA.MOVDELETVE
    End Function

    Public Function SEARCHMOVESTrueVE(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT MOV2 FROM MOVES WHERE CUser = @CUser AND MOV11 = @MOV11 AND MOV5 = @MOV5 AND MOV10 = @MOV10"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    selectCommand.Parameters.AddWithValue("@MOV5", False)
                    selectCommand.Parameters.AddWithValue("@MOV10", "VE")

                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "MOVES")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOV1VE = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOV1VE = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV1VE = Nothing
        End Try
        Return SEARCHDATA.MOV1VE
    End Function

    Public Function SEARCHMOVESFalse(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV5=@MOV5", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                selectCommand.Parameters.AddWithValue("@MOV5", False)

                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV1C = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV1C = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV1C = Nothing
        End Try
        Return SEARCHDATA.MOV1C
    End Function

    Public Function SEARCHMOVESTrue(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser = @CUser AND MOV11 = @MOV11 AND MOV5 = @MOV5", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                selectCommand.Parameters.AddWithValue("@MOV5", True)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV1B = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV1B = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV1B = Nothing
        End Try
        Return SEARCHDATA.MOV1B
    End Function

    Public Function SEARCHMOVESKS(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='KS' AND MOV5=@MOV5", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                selectCommand.Parameters.AddWithValue("@MOV5", True)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2KS = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2KS = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed
            SEARCHDATA.MOV2KS = Nothing
        End Try
        Return SEARCHDATA.MOV2KS
    End Function

    Public Function SEARCHMOVESKSA(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='KSA'", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    Dim dataSet As New DataSet
                    Dim adapter As New SqlDataAdapter(selectCommand)
                    dataSet.Clear()
                    connection.Open()
                    adapter.Fill(dataSet, "MOVES")
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOV2KSA = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOV2KSA = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2KSA = Nothing
        End Try
        Return SEARCHDATA.MOV2KSA
    End Function

    Public Function SEARCHMOVESKSB(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='KSB'", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")
                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2KSB = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2KSB = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2KSB = Nothing
        End Try
        Return SEARCHDATA.MOV2KSB
    End Function

    Public Function SEARCHMOVESKSC(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser = @CUser AND MOV11 = @MOV11 AND MOV10 = 'KSC'", connection)
                selectCommand.Parameters.AddWithValue("@CUser", CUser)
                selectCommand.Parameters.AddWithValue("@MOV11", MOV11)

                Dim dataSet As New DataSet
                Dim adapter As New SqlDataAdapter(selectCommand)
                dataSet.Clear()
                connection.Open()
                adapter.Fill(dataSet, "MOVES")

                If dataSet.Tables(0).Rows.Count > 0 Then
                    SEARCHDATA.MOV2KSC = dataSet.Tables(0).Rows(0).Item(0)
                Else
                    SEARCHDATA.MOV2KSC = Nothing
                End If
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2KSC = Nothing
        End Try
        Return SEARCHDATA.MOV2KSC
    End Function

    Public Function SEARCHMOVESKSD(ByVal MOV11 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='KSD'", connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@MOV11", MOV11)
                    Dim dataSet As New DataSet
                    Dim adapter As New SqlDataAdapter(selectCommand)
                    dataSet.Clear()
                    connection.Open()
                    adapter.Fill(dataSet, "MOVES")
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.MOV2KSD = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.MOV2KSD = Nothing
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.MOV2KSD = Nothing
        End Try
        Return SEARCHDATA.MOV2KSD
    End Function

    Public Function SEARCHMOVESVEA(ByVal MOV11 As String) As String
        Dim query As String = "SELECT DISTINCT MOV2 FROM MOVES WHERE CUser=@CUser AND MOV11=@MOV11 AND MOV10='VEA'"
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@CUser", CUser},
        {"@MOV11", MOV11}
    }
        Dim Result As Object = ExecuteScalarQuery(query, parameters)
        SEARCHDATA.MOV1A = Result?.ToString()
        Return SEARCHDATA.MOV1A
    End Function

    Public Function SEARCHSTOCKS1(ByVal STK25 As String, ByVal STK16 As String) As String
        Dim query As String = "SELECT DISTINCT STK1 FROM STOCKS WHERE CUser=@CUser AND STK25=@STK25 AND STK16=@STK16"
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@CUser", CUser},
        {"@STK25", STK25},
        {"@STK16", STK16}
    }
        Dim Result As Object = ExecuteScalarQuery(query, parameters)
        SEARCHDATA.STK1A = Result?.ToString()
        Return SEARCHDATA.STK1A
    End Function

    Public Function SEARCHSTOCKS2(ByVal STK25 As String, ByVal STK16 As String) As String
        Dim query As String = "SELECT DISTINCT STK16 FROM STOCKS WHERE CUser=@CUser AND STK25=@STK25 AND STK16=@STK16"
        Dim parameters As New Dictionary(Of String, Object) From {
        {"@CUser", CUser},
        {"@STK25", STK25},
        {"@STK16", STK16}
    }
        Dim Result As Object = ExecuteScalarQuery(query, parameters)
        SEARCHDATA.STK16 = Result?.ToString()
        Return SEARCHDATA.STK16
    End Function

    Public Function SEARCHMAXIDSTOCKS() As Object
        Dim maxID As Object = Nothing
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using cmd As New SqlCommand("SELECT MAX(STK1) FROM STOCKS", connection)
                    connection.Open()
                    maxID = cmd.ExecuteScalar()
                End Using
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return maxID
    End Function

    Public Function SumSTOCKS(ByVal STK7 As String, ByVal STK25 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT Sum(STOCKS.STK11) AS SumIMPORTQUANTITY, Sum(STOCKS.STK12) AS SumEXPORTQUNATITY " &
                                  "FROM STOCKS WHERE (STK7 = @STK7 OR STK25 = @STK25) AND CUser = @CUser"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@STK7", STK7)
                    selectCommand.Parameters.AddWithValue("@STK25", STK25)
                    selectCommand.Parameters.AddWithValue("@CUser", ModuleGeneral.CUser)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "STOCKS")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.sumSTK = Convert.ToDouble(dataSet.Tables(0).Rows(0).Item("SumIMPORTQUANTITY")) -
                                        Convert.ToDouble(dataSet.Tables(0).Rows(0).Item("SumEXPORTQUNATITY"))
                    Else
                        SEARCHDATA.sumSTK = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.sumSTK = 0
        End Try
        Return SEARCHDATA.sumSTK
    End Function

    Public Function SEARCHSTOCKSID(ByVal STK25 As String, ByVal STK16 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT STK1 FROM STOCKS WHERE CUser = @CUser AND STK25 = @STK25 AND STK16 = @STK16"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@STK25", STK25)
                    selectCommand.Parameters.AddWithValue("@STK16", STK16)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "STOCKS")
                    End Using

                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.STK1A = Convert.ToInt64(dataSet.Tables(0).Rows(0).Item(0))
                    Else
                        SEARCHDATA.STK1A = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle the exception (e.g., log it)
            SEARCHDATA.STK1A = 0
        End Try
        Return SEARCHDATA.STK1A
    End Function

    Public Function SEARCHSTOCKSID1(ByVal STK25 As String, ByVal STK16 As String) As String
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT STK1 FROM STOCKS WHERE CUser = @CUser AND STK25 = @STK25 AND STK16 = @STK16"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@STK25", STK25)
                    selectCommand.Parameters.AddWithValue("@STK16", STK16)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "STOCKS")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.STK1B = dataSet.Tables(0).Rows(0).Item(0)
                    Else
                        SEARCHDATA.STK1B = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
            SEARCHDATA.STK1B = 0
        End Try
        Return SEARCHDATA.STK1B
    End Function

    Public Function SEARCHEMPCOSTDETALLS(ByVal CSDT6 As String) As Integer
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Using selectCommand As New SqlCommand("SELECT DISTINCT CSDT FROM EMPCOSTDETALLS WHERE CSDT6 = @CSDT6", connection)
                    selectCommand.Parameters.AddWithValue("@CSDT6", CSDT6)
                    Dim dataSet As New DataSet
                    Using adapter As New SqlDataAdapter(selectCommand)
                        dataSet.Clear()
                        connection.Open()
                        adapter.Fill(dataSet, "EMPCOSTDETALLS")
                    End Using
                    If dataSet.Tables(0).Rows.Count > 0 Then
                        SEARCHDATA.CSDT = Convert.ToInt64(dataSet.Tables(0).Rows(0).Item(0))
                    Else
                        SEARCHDATA.CSDT = 0
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Log or handle the exception as needed
            SEARCHDATA.CSDT = 0
        End Try
        Return SEARCHDATA.CSDT
    End Function

    Public Function SEARCHEMPCOSTID(ByVal CST13 As String) As Integer
        Dim IDEmpCost As Integer = 0
        Try
            Using connection As New SqlConnection(ModuleGeneral.constring)
                Dim query As String = "SELECT DISTINCT CST1 FROM EMPCOST WHERE CUser = @CUser AND CST13 = @CST13"
                Using selectCommand As New SqlCommand(query, connection)
                    selectCommand.Parameters.AddWithValue("@CUser", CUser)
                    selectCommand.Parameters.AddWithValue("@CST13", CST13)
                    connection.Open()
                    Dim Result As Object = selectCommand.ExecuteScalar()
                    If Result IsNot Nothing AndAlso Not IsDBNull(Result) Then
                        IDEmpCost = Convert.ToInt64(Result)
                    End If
                End Using
            End Using
        Catch ex As Exception
            ' Handle exception (e.g., log the error)
        End Try
        Return IDEmpCost
    End Function

End Module