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
    Public NoMyDocuments As Int64

    Public Function SEARCHLogentry(ByVal USERLogentry As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT EBNK1 FROM BANKJO WHERE EBNK13 = '" & USERLogentry & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "BANKJO")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.EBNK1JO = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.EBNK1JO = Nothing
        End If
        connection.Close()
    End Function
    Public Function GetAutoNumberCOUser() As Integer
        Dim CUser_A As Integer
        Dim NO As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim SQL As New SqlCommand("SELECT MAX(CUser) FROM COMPANY  WHERE COUser = '" & COUser & " '", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
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
        If IsDBNull(resualt) Then
            CUser_A = COUser & CType(NO, Integer) & 1
        Else
            If resualt >= 1 AndAlso resualt <= 12 Then
                CUser_A = CType(NO, Integer) & CType(resualt, Integer) + 1
            Else
                CUser_A = CType(resualt, Integer) + 1
            End If
        End If
        Consum.Close()
        Return CUser_A

    End Function
    Public Function GetAutoNumberMyDOCUMENTSFL(ByVal LO As String) As Object
        On Error Resume Next
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(DOC2) FROM MYDOCUMENTSHOME WHERE CUser = '" & CUser & " ' and LO ='" & LO & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Mid(cmd1.ExecuteScalar(), 4)
        'noD = noD.Replace(Mid(noD, noD.IndexOf("Good") + 5, noD.TextLength), "")
        Dim CUsera As Integer = CDbl(CUser)
        Select Case CType(CUsera, Integer)
            Case 1 To 9
                NO = CDbl(CUser) & "000"
            Case 10 To 99
                NO = CDbl(CUser) & "00"
            Case 100 To 999
                NO = CDbl(CUser) & "0"
            Case Else
                NO = CDbl(CUser)
        End Select
        If IsDBNull(resualt) Then
            SEARCHDATA.NumberMyDOCUMENTSFL = CType(NO, Integer) & 1
        Else
            SEARCHDATA.NumberMyDOCUMENTSFL = CType(NO, Integer) & CType(noD, Integer) + 1
        End If
        Consum.Close()
    End Function

    Public Function GetAutoNumberMyDOCUMENTS() As Object
        On Error Resume Next
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(DOC2) FROM MYDOCUMENTSHOME WHERE CUser = '" & CUser & " '  and Year(date_1) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Mid(cmd1.ExecuteScalar(), 4)
        'noD = noD.Replace(Mid(noD, noD.IndexOf("Good") + 5, noD.TextLength), "")
        Dim CUsera As Integer = CDbl(CUser)
        Select Case CType(CUsera, Integer)
            Case 1 To 9
                NO = CDbl(CUser) & "000"
            Case 10 To 99
                NO = CDbl(CUser) & "00"
            Case 100 To 999
                NO = CDbl(CUser) & "0"
            Case Else
                NO = CDbl(CUser)
        End Select
        If IsDBNull(resualt) Then
            SEARCHDATA.NoMyDocuments = CType(NO, Integer) & 1
        Else
            SEARCHDATA.NoMyDocuments = CType(NO, Integer) & CType(noD, Integer) + 1
        End If
        Consum.Close()
    End Function

    Public Function GetAutoNumberDOCUMENTSFL(ByVal LO As String) As Object
        On Error Resume Next
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(DOC2) FROM DOCUMENTS WHERE CUser = '" & CUser & " ' and LO ='" & LO & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Mid(cmd1.ExecuteScalar(), 4)
        'noD = noD.Replace(Mid(noD, noD.IndexOf("Good") + 5, noD.TextLength), "")
        Dim CUsera As Integer = CDbl(CUser)
        Select Case CType(CUsera, Integer)
            Case 1 To 9
                NO = CDbl(CUser) & "000"
            Case 10 To 99
                NO = CDbl(CUser) & "00"
            Case 100 To 999
                NO = CDbl(CUser) & "0"
            Case Else
                NO = CDbl(CUser)
        End Select
        If IsDBNull(resualt) Then
            SEARCHDATA.NumberDOCUMENTSFL = CType(NO, Integer) & 1
        Else
            SEARCHDATA.NumberDOCUMENTSFL = CType(NO, Integer) & CType(noD, Integer) + 1
        End If
        Consum.Close()
    End Function

    Public Function GetAutoNumberDOCUMENTS() As Object
        On Error Resume Next
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(DOC2) FROM DOCUMENTS WHERE CUser = '" & CUser & " '  and Year(date_1) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Mid(cmd1.ExecuteScalar(), 4)
        'noD = noD.Replace(Mid(noD, noD.IndexOf("Good") + 5, noD.TextLength), "")
        Dim CUsera As Integer = CDbl(CUser)
        Select Case CType(CUsera, Integer)
            Case 1 To 9
                NO = CDbl(CUser) & "000"
            Case 10 To 99
                NO = CDbl(CUser) & "00"
            Case 100 To 999
                NO = CDbl(CUser) & "0"
            Case Else
                NO = CDbl(CUser)
        End Select
        If IsDBNull(resualt) Then
            SEARCHDATA.NoDocuments = CType(NO, Integer) & 1
        Else
            SEARCHDATA.NoDocuments = CType(NO, Integer) & CType(noD, Integer) + 1
        End If
        Consum.Close()
    End Function


    Public Function MAXIDBudget() As Object
        On Error Resume Next
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(IDFL) FROM FinancialList WHERE CUser = '" & CUser & " ' ", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        Dim noD As Object = Mid(cmd1.ExecuteScalar(), 4)
        'noD = noD.Replace(Mid(noD, noD.IndexOf("Good") + 5, noD.TextLength), "")
        Dim CUsera As Integer = CDbl(CUser)
        Select Case CType(cusera, Integer)
            Case 1 To 9
                NO = CDbl(CUser) & "000"
            Case 10 To 99
                NO = CDbl(CUser) & "00"
            Case 100 To 999
                NO = CDbl(CUser) & "0"
            Case Else
                NO = CDbl(CUser)
        End Select
        If IsDBNull(resualt) Then
            SEARCHDATA.MAXBudget = CType(NO, Integer) & 1
        Else
            SEARCHDATA.MAXBudget = CType(NO, Integer) & CType(noD, Integer) + 1
        End If
        Consum.Close()
    End Function
    Public Function MAXIDDeposits() As Object
        'On Error Resume Next
        'Dim NO As Integer = 0
        'Dim NO1 As Integer = 0
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(TBNK6) FROM Deposits WHERE CUser = '" & CUser & " ' ", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        'Dim noD As Object = Mid(cmd1.ExecuteScalar(), 4)
        'noD = noD.Replace(Mid(noD, noD.IndexOf("Good") + 5, noD.TextLength), "")
        'Dim cusera As Integer = CDbl(CUser)
        'Select Case CType(cusera, Integer)
        '    Case 1 To 9
        '        NO = CDbl(CUser) & "000"
        '    Case 10 To 99
        '        NO = CDbl(CUser) & "00"
        '    Case 100 To 999
        '        NO = CDbl(CUser) & "0"
        '    Case Else
        '        NO = CDbl(CUser)
        'End Select
        If IsDBNull(resualt) Then
            SEARCHDATA.MAXDeposits = CType(CUser, Integer) & 1
        Else
            SEARCHDATA.MAXDeposits = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Return SEARCHDATA.MAXDeposits
    End Function
    Public Function MAXAllCustomers() As Object
        'On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        'Dim NO As Integer = 0
        Dim SQL As New SqlCommand("SELECT MAX(AllCustomers.IDcust) FROM AllCustomers WHERE CUser = '" & CUser & " '", Consum)
        Dim CMD As New SqlClient.SqlCommand
        With CMD
            .CommandType = CommandType.Text
            .Connection = Consum
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            .CommandText = SQL.CommandText
        End With
        Dim resualt As Object = CMD.ExecuteScalar()
        'Dim noD As Object = Strings.Mid(CMD.ExecuteScalar(), 5)
        'Dim cusera As Double = CDbl(CUser)
        'Select Case CType(cusera, Integer)
        '    Case 1 To 9
        '        NO = CDbl(CUser) & "000"
        '    Case 10 To 99
        '        NO = CDbl(CUser) & "00"
        '    Case 100 To 999
        '        NO = CDbl(CUser) & "0"
        '    Case Else
        '        NO = CDbl(CUser)
        'End Select
        If IsDBNull(resualt) Then
            MAXIDAllCustomers = CType(CUser, Integer) & 1
        Else
            MAXIDAllCustomers = CType(resualt, Integer) + 1
        End If
        Consum.Close()
        Return MAXIDAllCustomers
        'CType(NO, Integer) &
    End Function
    Public Function MAXLoans() As Object
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim Year As String
        Dim NO As Integer = 0
        Dim NO1 As Integer = 0
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        NO1 = CType(Year, Integer) & String.Concat(New String() {CUser})
        Dim cusera As Double = CDbl(CUser)
        Select Case cusera
            Case 1 To 9
                NO = "000"
            Case 10 To 99
                NO = "00"
            Case 100 To 999
                NO = "0"
            Case Else
                NO = CUser
        End Select
        NO1 = CType(Year, Integer) & String.Concat(New String() {NO}) & CType(CUser, Integer)
        Dim cmd2 As New SqlClient.SqlCommand("SELECT MAX(Loans.LO) FROM Loans WHERE CUser = '" & CUser & " 'and Year(LO2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt2 As Object = cmd2.ExecuteScalar()
        Dim noD As Object = Strings.Mid(cmd2.ExecuteScalar(), 7)
        If IsDBNull(resualt2) Then
            SEARCHDATA.MAXIDLoans = CType(NO1, Integer) & 1
        Else
            SEARCHDATA.MAXIDLoans = String.Concat(New String() {NO1}) & CType(noD, Integer) + 1
        End If
        Consum.Close()
        Return SEARCHDATA.MAXIDLoans
    End Function

    Public Function MAXIDCASHIER() As Object
        On Error Resume Next
        Dim Year As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(CSH15) FROM CASHIER WHERE CUser = '" & CUser & " 'and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim resualt As Object = cmd1.ExecuteScalar()
        If IsDBNull(resualt) Then
            SEARCHDATA.BoxDocumentNumber = CType(Year, Integer) & 1
        Else
            SEARCHDATA.BoxDocumentNumber = CType(resualt, Integer) + 1
        End If
        Consum.Close()

        Return BoxDocumentNumber
        'CType(Year, Integer) &
    End Function
    Public Function GetAutoIDSTK()
        GetAutoNumber("STK1", "STOCKS", "STK4")
        IDSTK = AutoNumber
        Return IDSTK
    End Function
    Public Function GetAutoNumber(ByVal FIELD As String, ByVal TABLE As String, ByVal FIELD1 As String)
        On Error Resume Next
        'Try
        Dim Year As Integer
        'Dim NO As Integer
        Dim NO1 As Int64
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        Dim Consum As New SqlClient.SqlConnection(constring)
        'NO1 = CType(Year, Integer) & CType(CUser, Integer)
        'Dim CUserA As Integer = CType(CUser, Integer)
        'Select Case CUserA
        '    Case 1 To 9
        '        NO = "000"
        '    Case 10 To 99
        '        NO = "00"
        '    Case 100 To 999
        '        NO = Nothing
        '    Case 1000 To 9999
        '        NO = Nothing
        'End Select
        NO1 = Year & CType(CUser, Integer) & 1
        AutoNumber = Nothing
        Dim cmd As New SqlClient.SqlCommand("SELECT max([" & FIELD & "]) FROM [" & TABLE & "] WHERE CUser='" & CUser & "'" & "And Year([" & FIELD1 & "]) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' ", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        If IsDBNull(cmd.ExecuteScalar()) Then
            AutoNumber = CType(NO1, Integer)
        Else
            Dim resualt As Object = cmd.ExecuteScalar()
            'AutoNumber = resualt + 1

            AutoNumber = CType(resualt, Int64) + 1
        End If
        Consum.Close()
            'Return AutoNumber
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorGetAutoNumber", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return AutoNumber
        'End Try
    End Function

    Public Function GetAutoNumberOpeningRecord()
        Dim Year As Integer
        Dim NO As Integer
        Dim NO1 As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2) + 1
        Dim Consum As New SqlClient.SqlConnection(constring)
        'NO1 = CType(Year, Integer) & CType(CUser, Integer)
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
        AutoNumber = Nothing
        NO1 = Year & NO & CType(CUser, Integer)
        AutoNumber = NO1 & 1

        Return AutoNumber
    End Function
    Public Function MaxIDMovesMov1() As Int64
        Dim Year As Integer
        Dim NO As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        NO = CType(Year, Integer) & CType(CUser, Integer)
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(MOVES.MOV1) FROM MOVES WHERE CUser='" & CUser & "'and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MaxMovA As Object = cmd1.ExecuteScalar()
        If IsDBNull(MaxMovA) Then
            SEARCHDATA.MAXMOV1 = CType(NO, Integer) & 1
        Else
            SEARCHDATA.MAXMOV1 = CType(MaxMovA, Integer) + 1
            MsgBox(MAXMOV1)
        End If
        Consum.Close()
        T1 = Val(SEARCHDATA.MAXMOV1)
        Return T1
    End Function
    Public Function MaxIDMovesMov2() As Int64
        Dim Year As Integer
        Dim NO As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        NO = CType(Year, Integer) & CType(CUser, Integer)
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim cmd2 As New SqlClient.SqlCommand("SELECT MAX(MOVES.MOV2) FROM MOVES WHERE CUser='" & CUser & "'and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MaxMovB As Object = cmd2.ExecuteScalar()
        If IsDBNull(MaxMovB) Then
            SEARCHDATA.MAXMOV2 = CType(NO, Integer) & 1
        Else
            SEARCHDATA.MAXMOV2 = CType(MaxMovB, Integer) + 1
            MsgBox(MAXMOV2)
        End If
        Consum.Close()
        T2 = Val(SEARCHDATA.MAXMOV2)
        Return T2
    End Function
    Public Function MaxIDMoves()
        On Error Resume Next
        Dim Year As String
        Dim NO As Integer
        Year = Mid(Val(FiscalYear_currentDateMustBeInFiscalYear()), 3, 2)
        NO = CType(Year, Integer) & CType(CUser, Integer)
        Dim Consum As New SqlConnection(ModuleGeneral.constring)
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(MOVES.MOV1) FROM MOVES WHERE CUser='" & CUser & "'and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim cmd2 As New SqlClient.SqlCommand("SELECT MAX(MOVES.MOV2) FROM MOVES WHERE CUser='" & CUser & "'and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Dim cmd3 As New SqlClient.SqlCommand("SELECT MAX(MOVES.MOV8) FROM MOVES WHERE CUser='" & CUser & "'and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Dim MaxMovA As Object = cmd1.ExecuteScalar()
        Dim MaxMovB As Object = cmd2.ExecuteScalar()
        Dim MaxMovC As Object = cmd3.ExecuteScalar()
        If IsDBNull(MaxMovA) Then
            SEARCHDATA.MAXMOV1 = CType(NO, Integer) & 1
        Else
            SEARCHDATA.MAXMOV1 = CType(MaxMovA, Int64) + 1
        End If
        If IsDBNull(MaxMovB) Then
            SEARCHDATA.MAXMOV2 = CType(NO, Integer) & 1
        Else
            SEARCHDATA.MAXMOV2 = CType(MaxMovB, Int64) + 1
        End If
        If IsDBNull(MaxMovC) Then
            SEARCHDATA.MAXMOV8 = CType(NO, Integer) & 1
        Else
            SEARCHDATA.MAXMOV8 = CType(MaxMovC, Int64) + 1
        End If
        Consum.Close()
        T1 = Val(SEARCHDATA.MAXMOV1)
        T2 = Val(SEARCHDATA.MAXMOV2)
        T3 = Val(SEARCHDATA.MAXMOV8)
        'Return T3

    End Function

    Public Function SEARCHAccount_no(ByVal account As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT account_no,ACC,account_name,ACC1 FROM ACCOUNTSTREE WHERE account_name = '" & account & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "ACCOUNTSTREE")

        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.account_no = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
            SEARCHDATA.ACC = dataSet.Tables.Item(0).Rows.Item(0).Item(1)
            SEARCHDATA.account_name = dataSet.Tables.Item(0).Rows.Item(0).Item(2)
        Else
            SEARCHDATA.account_no = Nothing
            SEARCHDATA.ACC = Nothing
            SEARCHDATA.account_name = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHBANKJO(ByVal EBNK13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT EBNK1 FROM BANKJO WHERE   CUser='" & CUser & "' and EBNK13 = '" & EBNK13 & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "BANKJO")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.EBNK1JO = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.EBNK1JO = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHCABLESA(ByVal CAB13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT IDCAB FROM CABLES WHERE   CUser='" & CUser & "' and  CAB13='", CAB13, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CABLES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCABS3 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCABS3 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHCABLES(ByVal CAB8 As String, ByVal CAB13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT IDCAB FROM CABLES WHERE  CUser='" & CUser & "' and  CAB8 = '", CAB8, "'AND CAB6 ='نقدا'" & " AND CAB13='", CAB13, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CABLES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCAB = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCAB = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHCABLES1(ByVal CAB8 As String, ByVal CAB13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT IDCAB FROM CABLES WHERE  CUser='" & CUser & "' and  CAB8 = '", CAB8, "'AND CAB6 ='شيك'" & " AND CAB13='", CAB13, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CABLES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCAB1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCAB1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHCASHIERA1(ByVal CSH4 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and CSH4 = '" & CSH4 & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CASHIER")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CSH1C = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CSH1C = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHCASHIER(ByVal CSH4 As String, ByVal CSH15 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE  CUser='" & CUser & "' and  CSH4 = '" & CSH4 & " 'AND CSH15 = '" & CSH15 & "0'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CASHIER")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CSH1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CSH1 = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHCASHIER1(ByVal CSH4 As String, ByVal CSH15 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE   CUser='" & CUser & "' and  CSH4 = '" & CSH4 & " '" & "AND CSH15 = '" & CSH15 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        connection.Open()
        adapter.Fill(dataSet, "CASHIER")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CSH1B = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CSH1B = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHCASHIERA(ByVal CSH4 As String, ByVal CSH15 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM CASHIER WHERE  CUser='" & CUser & "' and   CSH4 = '" & CSH4 & " 'AND CSH15 = '" & CSH15 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CASHIER")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CSH1A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CSH1A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHDIDChecks(ByVal CH16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT IDCH FROM Checks  WHERE   CUser='" & CUser & "' and  CH16 = '" & CH16 & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Checks")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCH = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCH = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHDIDChecks1(ByVal CH11 As String, ByVal CH16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT idch FROM Checks WHERE  CUser='" & CUser & "' and   CH11 = '", CH11, " 'AND CH16 = '", CH16, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Checks")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCH2 = Conversions.ToInteger(dataSet.Tables.Item(0).Rows.Item(0).Item(0))
        Else
            SEARCHDATA.IDCH2 = 0
        End If
        connection.Close()

    End Function
    Public Function SEARCHSLSCASH(ByVal SLS19 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  TYPE_CASH FROM SALES WHERE  CUser='" & CUser & "' and   SLS19 ='" & SLS19 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "SALES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.SLSCASH = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.SLSCASH = Nothing
        End If
        connection.Close()
        'SLSCASH
    End Function

    Public Function SEARCHBUYSCASH(ByVal BUY18 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  TYPE_CASH FROM BUYS WHERE  CUser='" & CUser & "' and   BUY18 ='" & BUY18 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "BUYS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.BUYCASH = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.BUYCASH = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHDSuppliersA(ByVal CAB18 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT IDCAB FROM Suppliers1 WHERE  CUser='" & CUser & "' and    CAB18='", CAB18, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Suppliers1")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDSuppliesA = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDSuppliesA = Nothing
        End If
        connection.Close()

    End Function
    Public Function SEARCHDSuppliers(ByVal CAB8 As String, ByVal CAB18 As String) As String
        Try
            Dim x As String = "نقدا"
            Dim connection As New SqlConnection(ModuleGeneral.constring)
            Dim selectCommand As New SqlCommand("SELECT DISTINCT IDCAB FROM Suppliers1 WHERE   CUser='" & CUser & "' and  CAB6='" & x.ToString.Trim & "'AND CAB8 ='" & CAB8 & "' AND CAB18 ='" & CAB18 & "'", connection)
            Dim dataSet As New DataSet
            Dim adapter As New SqlDataAdapter(selectCommand)
            'ProjectData.ClearProjectError()
            dataSet.Clear()
            connection.Open()
            adapter.Fill(dataSet, "Suppliers1")
            If dataSet.Tables.Item(0).Rows.Count > 0 Then
                SEARCHDATA.IDCABS = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
                'MessageBox.Show(IDCABS, " البحث في داتا جريد", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                SEARCHDATA.IDCABS = Nothing
            End If
            connection.Close()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)

        End Try
        Return SEARCHDATA.IDCABS
    End Function
    Public Function SEARCHDSuppliers1(ByVal CAB8 As String, ByVal CAB18 As String) As String

        On Error Resume Next
        Dim x As String = "شيك"
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT IDCAB FROM Suppliers1 WHERE  CUser='" & CUser & "' and   CAB6='" & x.ToString.Trim & "'AND CAB8 ='" & CAB8 & "' AND CAB18 ='" & CAB18 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Suppliers1")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCABS1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCABS1 = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHDSuppliers2(ByVal CAB8 As String, ByVal CAB18 As String) As String
        On Error Resume Next
        Dim x As String = "نقدا_شيك"
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT IDCAB FROM Suppliers1 WHERE  CUser='" & CUser & "' and   CAB6='" & x.ToString.Trim & "'AND CAB8 ='" & CAB8 & "' AND CAB18 ='" & CAB18 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Suppliers1")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCABS2 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCABS2 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHEMPSOLF(ByVal CSH17 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT CSH1 FROM EMPSOLF WHERE   CUser='" & CUser & "' and  CSH17 = '" & CSH17 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "EMPSOLF")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CSH1E = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CSH1E = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID(ByVal lo25 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  Loa1 FROM LoansPa WHERE    CUser='" & CUser & "' and lo25 ='" & lo25 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "LoansPa")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.Loa1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.Loa1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID1(ByVal Lo17 As String) As String
        On Error Resume Next
        Dim Connection As New SqlConnection(ModuleGeneral.constring)
        Dim SelectCommand As New SqlCommand("SELECT  Lo FROM Loans WHERE    CUser='" & CUser & "' and lo17 ='" & Lo17 & "'", Connection)
        Dim DataSet As New DataSet
        Dim Adapter As New SqlDataAdapter(SelectCommand)
        ProjectData.ClearProjectError()
        DataSet.Clear()
        Connection.Open()
        Adapter.Fill(DataSet, "Loans")
        If DataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.Lo1 = DataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.Lo1 = Nothing
        End If
        Connection.Close()
        'Return SEARCHDATA.Lo1
    End Function
    Public Function SEARCHID10(ByVal SLS19 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  SLS2 FROM SALES WHERE   CUser='" & CUser & "' and  SLS19 ='" & SLS19 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "SALES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.SLS1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.SLS1 = 0
        End If
        connection.Close()
        'Return SEARCHDATA.SLS1
    End Function

    Public Function SEARCHID11(ByVal CH16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  IDCH FROM Checks WHERE   CUser='" & CUser & "' and  CH16 ='" & CH16 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Checks")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDCH1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.IDCH1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID12(ByVal SLY25 As String) As String
        On Error Resume Next
        Dim num As Integer = -2
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  SLY1 FROM SALARIES WHERE   CUser='" & CUser & "' and  SLY25 ='" & SLY25 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "SALARIES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.SLY1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.SLY1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID2(ByVal TBNK18 As String) As Object
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  TBNK1 FROM Deposits WHERE    CUser='" & CUser & "' and TBNK18 ='" & TBNK18 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Deposits")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.TBNK1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.TBNK1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID3(ByVal TBNK11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  TBNK1 FROM PTRANSACTION WHERE    CUser='" & CUser & "' and TBNK11 ='" & TBNK11 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "PTRANSACTION")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.TBNK1A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.TBNK1A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID31(ByVal TBNK9 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  TBNK1 FROM PTRANSACTION WHERE    CUser='" & CUser & "' and TBNK9 ='" & TBNK9 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "PTRANSACTION")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.TBNK1B = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.TBNK1B = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID4(ByVal EBNK13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  EBNK1 FROM BANKJO WHERE   CUser='" & CUser & "' and  EBNK13 ='" & EBNK13 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "BANKJO")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.EBNK1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.EBNK1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID5(ByVal PTRO23 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  PTRO1 FROM PETRO WHERE    CUser='" & CUser & "' and PTRO23 ='" & PTRO23 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "PETRO")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.PTRO1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.PTRO1 = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHID6(ByVal PTRO23 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  PTRO1 FROM Invoice WHERE   CUser='" & CUser & "' and PTRO23 ='" & PTRO23 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "Invoice")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.PTRO1A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.PTRO1A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHID7(ByVal CEMP31 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  CEMP3 FROM CABLESCOEMPLOYEES WHERE   CUser='" & CUser & "' and  CEMP31 ='" & CEMP31 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "CABLESCOEMPLOYEES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CEMP3 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CEMP3 = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHID8(ByVal CST13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  CST1 FROM MYCOSTS WHERE  CUser='" & CUser & "' and CST13 ='" & CST13 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MYCOSTS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CST1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.CST1 = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHID9(ByVal BUY18 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT  BUY2 FROM BUYS WHERE    CUser='" & CUser & "' and BUY18 ='" & BUY18 & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "BUYS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.BUY1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.BUY1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES(ByVal MOV2 As String) As String
        On Error Resume Next
        'MOV2 = Conversions.ToString(Conversion.Val(SEARCHDATA.MAXMOV2))
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV2 = '" & MOV2 & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV1 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1A(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE  CUser='" & CUser & "' and   MOV11 = '" & MOV11 & " ' And  MOV10='QRA'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1B(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE  CUser='" & CUser & "' and   MOV11 = '" & MOV11 & " ' And  MOV10='QRB'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2B = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2B = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1C(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='QRC'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2C = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2C = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1D(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='QRD'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2D = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2D = Nothing
        End If
        connection.Close()
    End Function


    Public Function SEARCHMOVES1ADELET(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='QRA'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1BDELET(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='QRB'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2B = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2B = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1CDELET(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='QRC'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2C = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2C = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVES1DDELET(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '" & MOV11 & " ' And  MOV10='QRD'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2D = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2D = Nothing
        End If
        connection.Close()
    End Function


    Public Function SEARCHMOVESDATA(ByVal MOVD9 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOVD1,MOV2,MOVD9 FROM MOVESDATA WHERE   CUser='" & CUser & "' and  MOVD9 = '" & MOVD9 & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVESDATA")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            MOVD1 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
            MOV2 = dataSet.Tables.Item(0).Rows.Item(0).Item(1)
            MOVD9A = dataSet.Tables.Item(0).Rows.Item(0).Item(2)

        Else
            MOVD1 = Nothing
            MOV2 = Nothing
            MOVD9A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESDATAFalse(ByVal MOVD9 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOVD1,MOV2,MOVD7 FROM MOVESDATA WHERE   CUser='" & CUser & "' and  MOVD9 = '", MOVD9, " ' And  MOV3='", Conversions.ToString(False), "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVESDATA")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOVD1B = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
            SEARCHDATA.MOV2F = dataSet.Tables.Item(0).Rows.Item(0).Item(1)
        Else
            SEARCHDATA.MOVD1B = Nothing
            SEARCHDATA.MOV2F = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESDATATrue(ByVal MOVD9 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOVD1,MOV2,MOVD7 FROM MOVESDATA WHERE   CUser='" & CUser & "' and  MOVD9 = '", MOVD9, " ' And  MOV3='", Conversions.ToString(True), "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVESDATA")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOVD1A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
            SEARCHDATA.MOV2E = dataSet.Tables.Item(0).Rows.Item(0).Item(1)
        Else
            SEARCHDATA.MOVD1A = Nothing
            SEARCHDATA.MOV2E = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESFalseDELET(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(False), "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOVDELET = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOVDELET = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESTrueDELET(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(True), "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV1DELET = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV1DELET = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESTrueDELETA(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(False), "'And  MOV10='VEA'"}), connection)
        'Dim selectCommand As New SqlCommand(("                           SELECT DISTINCT MOV1 FROM MOVES WHERE MOV11 = '" & MOV11 & " ' And  MOV10='VEA'"), connection)

        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOVADELET = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOVADELET = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESTrueDELETAVE(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(False), "'And  MOV10='VE'"}), connection)
        'Dim selectCommand As New SqlCommand(("                           SELECT DISTINCT MOV1 FROM MOVES WHERE MOV11 = '" & MOV11 & " ' And  MOV10='VEA'"), connection)

        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOVDELETVE = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOVDELETVE = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESTrueVE(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(False), "'And  MOV10='VE'"}), connection)
        'Dim selectCommand As New SqlCommand(("                           SELECT DISTINCT MOV1 FROM MOVES WHERE MOV11 = '" & MOV11 & " ' And  MOV10='VEA'"), connection)

        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV1VE = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV1VE = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESFalse(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(False), "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV1C = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV1C = Nothing
        End If
        connection.Close()

    End Function




    Public Function SEARCHMOVESTrue(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '", MOV11, " ' And  MOV5='", Conversions.ToString(True), "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV1B = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV1B = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESKS(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '" & MOV11 & " ' And  MOV10='KS'And  MOV5='" & Conversions.ToString(True) & "'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2KS = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2KS = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESKSA(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE    CUser='" & CUser & "' and MOV11 = '" & MOV11 & " ' And  MOV10='KSA'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2KSA = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2KSA = Nothing
        End If
        connection.Close()
    End Function

    Public Function SEARCHMOVESKSB(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='KSB'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2KSB = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2KSB = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESKSC(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='KSC'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2KSC = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2KSC = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMOVESKSD(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='KSD'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV2KSD = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV2KSD = Nothing
        End If
        connection.Close()
    End Function


    Public Function SEARCHMOVESVEA(ByVal MOV11 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT MOV2 FROM MOVES WHERE   CUser='" & CUser & "' and  MOV11 = '" & MOV11 & " ' And  MOV10='VEA'", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "MOVES")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.MOV1A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.MOV1A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHSTOCKS1(ByVal STK25 As String, ByVal STK16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT STK1 FROM STOCKS WHERE   CUser='" & CUser & "' and  STK25 = '", STK25, "'AND STK16 = '", STK16, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "STOCKS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.STK1A = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            SEARCHDATA.STK1A = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHSTOCKS2(ByVal STK25 As String, ByVal STK16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT STK16 FROM STOCKS WHERE   CUser='" & CUser & "' and  STK25 = '", STK25, "'AND STK16 = '", STK16, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "STOCKS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            STK16 = dataSet.Tables.Item(0).Rows.Item(0).Item(0)
        Else
            STK16 = Nothing
        End If
        connection.Close()
    End Function
    Public Function SEARCHMAXIDSTOCKS() As Object
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim N As Double
        Dim cmd1 As New SqlClient.SqlCommand("SELECT MAX(STK1) FROM STOCKS ", connection)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        N = cmd1.ExecuteScalar
    End Function
    Public Function SumSTOCKS(ByVal STK7 As String, ByVal STK25 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT Sum(STOCKS.STK11) AS SumIMPORTQUANTITY,Sum(STOCKS.STK12) AS SumEXPORTQUNATITY FROM STOCKS  WHERE  STK7 ='", STK7, "'or STK25 ='", STK25, "' and CUser='", ModuleGeneral.CUser, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "STOCKS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.sumSTK = Conversion.Val(RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(0).Item(0))) - Conversion.Val(RuntimeHelpers.GetObjectValue(dataSet.Tables.Item(0).Rows.Item(0).Item(1)))
        Else
            SEARCHDATA.sumSTK = Conversions.ToDouble("0")
        End If
        connection.Close()
    End Function
    Public Function SEARCHSTOCKSID(ByVal STK25 As String, ByVal STK16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT STK1 FROM STOCKS WHERE    CUser='" & CUser & "' and STK25 = '", STK25, "'AND STK16 = '", STK16, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "STOCKS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.STK1A = Conversions.ToInteger(dataSet.Tables.Item(0).Rows.Item(0).Item(0))
        Else
            SEARCHDATA.STK1A = 0
        End If
        connection.Close()
    End Function
    Public Function SEARCHSTOCKSID1(ByVal STK25 As String, ByVal STK16 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT STK1 FROM STOCKS WHERE   CUser='" & CUser & "' and  STK25 = '", STK25, "'AND STK16 = '", STK16, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "STOCKS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.STK1B = Conversions.ToInteger(dataSet.Tables.Item(0).Rows.Item(0).Item(0))
        Else
            SEARCHDATA.STK1B = 0
        End If
        connection.Close()
    End Function
    Public Function SEARCHEMPCOSTDETALLS(ByVal CSDT6 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand("SELECT DISTINCT CSDT FROM EMPCOSTDETALLS WHERE  CSDT6 = '" & CSDT6 & " '", connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "EMPCOSTDETALLS")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.CSDT = Conversions.ToInteger(dataSet.Tables.Item(0).Rows.Item(0).Item(0))
        Else
            SEARCHDATA.CSDT = 0
        End If
        connection.Close()
    End Function
    Public Function SEARCHEMPCOSTID(ByVal CST13 As String) As String
        On Error Resume Next
        Dim connection As New SqlConnection(ModuleGeneral.constring)
        Dim selectCommand As New SqlCommand(String.Concat(New String() {"SELECT DISTINCT CST1 FROM EMPCOST WHERE    CUser='" & CUser & "' and CST13 = '", CST13, "'"}), connection)
        Dim dataSet As New DataSet
        Dim adapter As New SqlDataAdapter(selectCommand)
        ProjectData.ClearProjectError()
        dataSet.Clear()
        connection.Open()
        adapter.Fill(dataSet, "EMPCOST")
        If dataSet.Tables.Item(0).Rows.Count > 0 Then
            SEARCHDATA.IDEmpCost = Conversions.ToInteger(dataSet.Tables.Item(0).Rows.Item(0).Item(0))
        Else
            SEARCHDATA.IDEmpCost = 0
        End If
        connection.Close()
    End Function
End Module