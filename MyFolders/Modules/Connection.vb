Imports System.Data.SqlClient

Module Connection
    'كود اتصال مع قاعدة بيانات موجودة في موقع على النت
    'اسم القاعدة
    'co
    'عنوان السيرفر
    'cojo.myvnc.com
    'كلمة سر القاعدة
    '
    Public DataAdapterTab As SqlDataAdapter
    Public DataSetTab As DataSet
    '=============================================
    Public DataAdapterUsers As SqlClient.SqlDataAdapter
    '==========================================================
    Public ID_Nam, Uses As String
    Public TestNet As Boolean = False
    Public AN As String
    Public AN2 As String
    Public ACONET As New ArrayList()
    Public ACONET1 As New ArrayList()
    Public ACONET2 As New ArrayList()
    Public ACONET3 As String
    Public AccountantA As Boolean = False
    Public FinanceAuditA As Boolean = False
    '========================================================

    Public Function ServerDateTime() As DateTime
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim comm As New SqlClient.SqlCommand("Select GetDate()", Consum)
            If Consum.State = ConnectionState.Closed Then
                Consum.Open()
            End If
            Dim mDateTime = comm.ExecuteScalar
            Consum.Close()
            Return mDateTime
        Catch ex As Exception
            'MsgBox("حدث خطاء ما في التاريخ", MsgBoxStyle.Information, "معلومات")
        Finally
            Consum.Close()
        End Try
        Return ServerDateTime
    End Function

    Public Sub UPDATE_Users(ByVal LoginName As String, ByVal TimeEnter As Date, ByVal MacAddress As String)
        Try
            Dim ConUsers As New SqlClient.SqlConnection(constring1)
            Dim cmd As New SqlCommand("Update Users SET   LoginName = @LoginName,TimeEnter = @TimeEnter,MacAddress = @MacAddress  WHERE USERNAME = '" & USERNAME & " '", ConUsers)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@LoginName", LoginName)
            cmd.Parameters.AddWithValue("@TimeEnter", TimeEnter)
            cmd.Parameters.AddWithValue("@MacAddress", MacAddress)
            ConUsers.Open()
            cmd.ExecuteNonQuery()
            ConUsers.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ConUsers.Close()
        End Try
    End Sub

    Public Sub AccountingprocedureAA()
        Dim CountACONET As Integer
        Dim CountACONET1 As Integer
        'Dim ACONETs0 As String
        'Dim ACONETs1 As String
        Dim ACONETs2 As String
        'Dim ACONETs3 As String
        'Dim ACONETs4 As String
        'Dim ACONETs5 As String

        Dim x As Integer = 0
        'Dim x1 As Integer = 0
        'MsgBox(CountACONET1)
        Connection.ACONET2.Clear()

        'MsgBox(ACONETs0)
        Dim xCount As Integer
        For x1 As Integer = 0 To Connection.ACONET1.Count - 1
            CountACONET1 = x1
        Next
        For x = 0 To Connection.ACONET.Count - 1
            CountACONET = x
            xCount = CountACONET + 1
            If CountACONET < CountACONET1 Then
                Connection.ACONET2.Add(xCount & "- " & "تم إضافة حساب" & " " & Connection.ACONET1(x))

            ElseIf CountACONET > CountACONET1 Then
                ACONETs2 = Mid(Connection.ACONET(x), 18, 23)
                Connection.ACONET2.Add(xCount & "- " & "تم حذف حساب" & " " & ACONETs2)

            ElseIf CountACONET1 = CountACONET Then

                Connection.ACONET2.Add(Connection.ACONET(x) & Connection.ACONET1(x))
            Else
                Connection.ACONET2.Add(xCount & "- " & "تم إتخاذ جميع الإجراءت")
            End If
        Next



        '
        'If CountACONET = 0 Then
        '    Connection.ACONET2.Add(Connection.ACONET(X) & Connection.ACONET1(X))
        'ElseIf CountACONET = 1 Then
        '    Connection.ACONET2.Add(Connection.ACONET(X) & Connection.ACONET1(X))
        '    MsgBox(Connection.ACONET2(X))
        'ElseIf CountACONET = 2 Then
        '    If CountACONET1 = 2 Then
        '        Connection.ACONET2.Add(Connection.ACONET(X) & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("1")
        '    ElseIf CountACONET1 = 3 Then
        '        Connection.ACONET2.Add("3- " & "تم إضافة حساب" & " " & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("2")
        '    ElseIf CountACONET1 = 4 Then
        '        Connection.ACONET2.Add("3- " & "تم إضافة حساب" & " " & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("3")
        '    ElseIf CountACONET1 = 5 Then
        '        Connection.ACONET2.Add("3- " & "تم إضافة حساب" & " " & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("4")
        '    End If
        'ElseIf CountACONET = 3 Then
        '    If CountACONET1 = 2 Then
        '        ACONETs2 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("4- " & "تم حذف حساب" & " " & ACONETs2)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("5")
        '    ElseIf CountACONET1 = 3 Then
        '        Connection.ACONET2.Add(Connection.ACONET(X) & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("6")
        '    ElseIf CountACONET1 = 4 Then
        '        Connection.ACONET2.Add("4- " & "تم إضافة حساب" & " " & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("7")
        '    ElseIf CountACONET1 = 5 Then
        '        Connection.ACONET2.Add("4- " & "تم إضافة حساب" & " " & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("8")
        '    End If
        'ElseIf CountACONET = 4 Then
        '    If CountACONET1 = 2 Then
        '        ACONETs3 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("5- " & "تم حذف حساب" & " " & ACONETs3)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("9")
        '    ElseIf CountACONET1 = 3 Then
        '        ACONETs3 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("5- " & "تم حذف حساب" & " " & ACONETs3)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("10")
        '    ElseIf CountACONET1 = 4 Then
        '        Connection.ACONET2.Add(Connection.ACONET(X) & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("11")
        '    ElseIf CountACONET1 = 5 Then
        '        Connection.ACONET2.Add("5- " & "تم إضافة حساب" & " " & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("12")
        '    End If
        'ElseIf CountACONET = 5 Then
        '    If CountACONET1 = 1 Then
        '        ACONETs4 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("6- " & "تم حذف حساب" & " " & ACONETs4)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("13")
        '    ElseIf CountACONET1 = 2 Then
        '        ACONETs4 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("6- " & "تم حذف حساب" & " " & ACONETs4)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("14")
        '    ElseIf CountACONET1 = 3 Then
        '        ACONETs4 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("6- " & "تم حذف حساب" & " " & ACONETs4)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("15")
        '    ElseIf CountACONET1 = 4 Then
        '        ACONETs3 = Mid(Connection.ACONET(X), 18, 23)
        '        Connection.ACONET2.Add("6- " & "تم حذف حساب" & " " & ACONETs3)
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("16")
        '    ElseIf CountACONET1 = 5 Then
        '        Connection.ACONET2.Add(Connection.ACONET(X) & Connection.ACONET1(X))
        '        MsgBox(Connection.ACONET2(X))
        '        MsgBox("17")
        '    End If
        'End If


    End Sub

    Public Sub UPDATE_Auditorsnotes()
        Try
            Dim ConUsers As New SqlClient.SqlConnection(constring1)
            Dim cmd As New SqlCommand("Update Auditorsnotes SET   AN6 = @AN6  WHERE AN = '" & AN & " '", ConUsers)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@AN6", ACONET3.ToString.Trim)
            ConUsers.Open()
            cmd.ExecuteNonQuery()
            ConUsers.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            ConUsers.Close()
        End Try
    End Sub

    Public Sub Insert_Actions(ByVal result As String, ByVal Opr_T As String, ByVal form_N As String)
        Try
            Dim Consum As New SqlClient.SqlConnection(constring1)
            Dim cmd As New SqlClient.SqlCommand("insert into Operationsuser (Op2, Op3, Op4, Op5, Op6, Op7, Op8) values (@Op2 ,@Op3, @Op4, @Op5, @Op6, @Op7, @Op8)", Consum)
            cmd.Parameters.Clear()
            cmd.Parameters.AddWithValue("@Op2", result)
            cmd.Parameters.AddWithValue("@Op3", Opr_T)
            cmd.Parameters.AddWithValue("@Op4", ServerDateTime.ToString("yyyy-MM-dd"))
            cmd.Parameters.AddWithValue("@Op5", form_N)
            cmd.Parameters.AddWithValue("@Op6", Realname)
            cmd.Parameters.AddWithValue("@Op7", AssociationName)
            cmd.Parameters.AddWithValue("@Op8", ServerDateTime.ToString("hh:mm:ss tt"))
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MsgBox("حدث خطاء ما عند حركات المستخدمين", MsgBoxStyle.Information, "معلومات")
        Finally
            Call CloseDB()
        End Try
    End Sub

    Public Sub Insert_FiscalYear(ByVal result As String, ByVal start_YE As Date, ByVal end_YE As Date, ByVal ServerstartYear As Date, ByVal Ye1 As Button)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim cmd As New SqlClient.SqlCommand("insert into FiscalYear (Year1,Year2,Year3,Year4,Ye1) values (@Year1 ,@Year2,@Year3,@Year4,@Ye1)", Consum)
        cmd.Parameters.Clear()
        cmd.Parameters.AddWithValue("@Year1", result)
        cmd.Parameters.AddWithValue("@Year2", start_YE)
        cmd.Parameters.AddWithValue("@Year3", end_YE)
        cmd.Parameters.AddWithValue("@Year4", ServerstartYear)
        cmd.Parameters.AddWithValue("@YE1", Ye1)
        Consum.Open()
        cmd.ExecuteNonQuery()
        Consum.Close()
        MsgBox("تم اضافة السنة المحاسبية ", MsgBoxStyle.Information, "معلومات")
    End Sub

    Public Sub SELECT_MOVES1(ByVal DataGrid As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FinaBalances1
        Dim A_Name, A_data, A_No, A_No1, A_USERNAME As String
        Dim strsql As New SqlCommand("", Consum)
        Dim strsqCASH As New SqlCommand("", Consum)
        Dim strsqCASH1 As New SqlCommand("", Consum)
        Dim strsqBANK As New SqlCommand("", Consum)
        Dim strsqBANK1 As New SqlCommand("", Consum)
        Dim strsqEMPSOL As New SqlCommand("", Consum)
        Dim strsqEMPSOL1 As New SqlCommand("", Consum)
        Dim strsqChecks As New SqlCommand("", Consum)
        Dim strsqChecks1 As New SqlCommand("", Consum)
        Dim strsqDeposits As New SqlCommand("", Consum)
        Dim strsqDeposits1 As New SqlCommand("", Consum)
        Dim strsqPTRANSACTION As New SqlCommand("", Consum)
        Dim strsqPTRANSACTION1 As New SqlCommand("", Consum)

        Dim strsqBUYS As New SqlCommand("", Consum)
        Dim strsqBUYS1 As New SqlCommand("", Consum)
        Dim strsqSALES As New SqlCommand("", Consum)
        Dim strsqSALES1 As New SqlCommand("", Consum)
        Dim strsqTodaySales As New SqlCommand("", Consum)
        Dim strsqTodaySales1 As New SqlCommand("", Consum)
        Dim strsqASTRGA_ASTRDA As New SqlCommand("", Consum)
        Dim strsqASTRGA_ASTRDA1 As New SqlCommand("", Consum)
        Dim strsqCABLES As New SqlCommand("", Consum)
        Dim strsqCABLES1 As New SqlCommand("", Consum)
        Dim strsqCABLESCOEMPLOYEES As New SqlCommand("", Consum)
        Dim strsqCABLESCOEMPLOYEES1 As New SqlCommand("", Consum)
        Dim strsqInvoice As New SqlCommand("", Consum)
        Dim strsqInvoice1 As New SqlCommand("", Consum)
        Dim strsqPETRO As New SqlCommand("", Consum)
        Dim strsqPETRO1 As New SqlCommand("", Consum)
        Dim strsqMYCOSTS As New SqlCommand("", Consum)
        Dim strsqMYCOSTS1 As New SqlCommand("", Consum)
        Dim strsqSuppliers As New SqlCommand("", Consum)
        Dim strsqSuppliers1 As New SqlCommand("", Consum)
        Dim strsqSALARIES As New SqlCommand("", Consum)
        Dim strsqSALARIES1 As New SqlCommand("", Consum)

        Dim strsqLoans As New SqlCommand("", Consum)
        Dim strsqLoans1 As New SqlCommand("", Consum)

        Dim strsqLoansPa As New SqlCommand("", Consum)
        Dim strsqLoansPa1 As New SqlCommand("", Consum)


        strsql.CommandText = "SELECT MOV2, MOV11, MOV12, MOV3, MOV4, USERNAME FROM MOVES   WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and MOV12 ='" & False & "'"
        strsqCASH.CommandText = " SELECT CSH1, CSH4, CSH2, CSH11, USERNAME  FROM CASHIER WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH17 ='" & False & "'"
        strsqCASH1.CommandText = "SELECT CSH1, CSH4, CSH2, CSH11, USERNAME  FROM CASHIER WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH14 ='" & False & "'"
        strsqBANK.CommandText = " SELECT EBNK1, EBNK13, EBNK3, EBNK9, USERNAME  FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK15 ='" & False & "'"
        strsqBANK1.CommandText = "SELECT EBNK1, EBNK13, EBNK3, EBNK9, USERNAME  FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK14 ='" & False & "'"
        strsqEMPSOL.CommandText = " SELECT CSH1, CSH2, CSH17, CSH11, USERNAME  FROM EMPSOLF WHERE CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH13 ='" & False & "'"
        strsqEMPSOL1.CommandText = "SELECT CSH1, CSH2, CSH17, CSH11, USERNAME  FROM EMPSOLF WHERE CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH16 ='" & False & "'"
        strsqChecks.CommandText = " SELECT IDCH, CH3, CH16, CH9, USERNAME  FROM Checks WHERE CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CH19 ='" & False & "'"
        strsqChecks1.CommandText = "SELECT IDCH, CH3, CH16, CH9, USERNAME  FROM Checks WHERE CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CH18 ='" & False & "'"
        strsqDeposits.CommandText = " SELECT TBNK1, TBNK18, TBNK3, TBNK20, USERNAME  FROM Deposits WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK22 ='" & False & "'"
        strsqDeposits1.CommandText = "SELECT TBNK1, TBNK18, TBNK3, TBNK20, USERNAME  FROM Deposits WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK17 ='" & False & "'"

        strsqPTRANSACTION.CommandText = " SELECT TBNK1, TBNK11, TBNK3, TBNK22, USERNAME  FROM PTRANSACTION WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK17 ='" & False & "'"
        strsqPTRANSACTION1.CommandText = "SELECT TBNK1, TBNK11, TBNK3, TBNK22, USERNAME  FROM PTRANSACTION WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK13 ='" & False & "'"

        strsqBUYS.CommandText = " SELECT BUY2, BUY18, BUY3, BUY24, USERNAME  FROM BUYS WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and BUY17 ='" & False & "'"
        strsqBUYS1.CommandText = "SELECT BUY2, BUY18, BUY3, BUY24, USERNAME  FROM BUYS WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and BUY19 ='" & False & "'"
        strsqSALES.CommandText = " SELECT SLS2, SLS19, SLS3, SLS5, USERNAME  FROM SALES WHERE CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and SLS17 ='" & False & "'"
        strsqSALES1.CommandText = "SELECT SLS2, SLS19, SLS3, SLS5, USERNAME  FROM SALES WHERE CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and SLS30 ='" & False & "'"
        strsqTodaySales.CommandText = " SELECT ID, TS9, DataTS, BarCod, USERNAME  FROM TodaySales WHERE CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk1 ='" & False & "'"
        strsqTodaySales1.CommandText = "SELECT ID, TS9, DataTS, BarCod, USERNAME  FROM TodaySales WHERE CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk  ='" & False & "'"
        strsqASTRGA_ASTRDA.CommandText = " SELECT ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME  FROM ASTRGA_ASTRDA WHERE CUser='" & CUser & "' and Year(DataD10) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk1 ='" & False & "'"
        strsqASTRGA_ASTRDA1.CommandText = "SELECT ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME  FROM ASTRGA_ASTRDA WHERE CUser='" & CUser & "' and Year(DataD10) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk  ='" & False & "'"
        strsqCABLES.CommandText = "SELECT IDCAB, CAB3, CAB9, CAB21, USERNAME  FROM CABLES WHERE  CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB20 ='" & False & "'"
        strsqCABLES1.CommandText = "SELECT IDCAB, CAB3, CAB9, CAB21, USERNAME  FROM CABLES WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB24 ='" & False & "'"
        strsqCABLESCOEMPLOYEES.CommandText = " SELECT CEMP3, CEMP2, CEMP25, CEMP31, USERNAME  FROM CABLESCOEMPLOYEES WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CEMP21 ='" & False & "'"
        strsqCABLESCOEMPLOYEES1.CommandText = "SELECT CEMP3, CEMP2, CEMP25, CEMP31, USERNAME  FROM CABLESCOEMPLOYEES WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CEMP30 ='" & False & "'"

        strsqInvoice.CommandText = " SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM Invoice WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO15 ='" & False & "'"
        strsqInvoice1.CommandText = "SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM Invoice WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO22 ='" & False & "'"

        strsqPETRO.CommandText = " SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM PETRO WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO15 ='" & False & "'"
        strsqPETRO1.CommandText = "SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM PETRO WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO22 ='" & False & "'"

        strsqMYCOSTS.CommandText = " SELECT CST1, CST7, CST10, CST13, USERNAME  FROM MYCOSTS WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CST5 ='" & False & "'"
        strsqMYCOSTS1.CommandText = "SELECT CST1, CST7, CST10, CST13, USERNAME  FROM MYCOSTS WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CST21 ='" & False & "'"

        strsqSuppliers.CommandText = " SELECT IDCAB, CAB3, CAB9, CAB18, USERNAME  FROM Suppliers1 WHERE  CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CAB13 ='" & False & "'"
        strsqSuppliers1.CommandText = " SELECT IDCAB, CAB3, CAB9, CAB18, USERNAME  FROM Suppliers1 WHERE  CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CAB17 ='" & False & "'"

        strsqSALARIES.CommandText = " SELECT SLY1, SLY2, SLY25, SLY26, USERNAME  FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and SLY27 ='" & False & "'"
        strsqSALARIES1.CommandText = "SELECT SLY1, SLY2, SLY25, SLY26, USERNAME  FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and SLY28 ='" & False & "'"

        strsqLoans.CommandText = " SELECT lo, lo17, lo2, lo5, USERNAME  FROM Loans WHERE   CUser='" & CUser & "' and Year(lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and lo16 ='" & False & "'"
        strsqLoans1.CommandText = "SELECT lo, lo17, lo2, lo5, USERNAME  FROM Loans WHERE   CUser='" & CUser & "' and Year(lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and lo18 ='" & False & "'"

        strsqLoansPa.CommandText = " SELECT Loa1, Loa5, Loa3, Loa11, USERNAME  FROM LoansPa WHERE  CUser='" & CUser & "'  and Loa14 ='" & False & "' and Loa6 >'" & 0 & "'"
        strsqLoansPa1.CommandText = "SELECT Loa1, Loa5, Loa3, Loa11, USERNAME  FROM LoansPa WHERE  CUser='" & CUser & "'  and loa16 ='" & False & "' and Loa6 >'" & 0 & "'"



        Dim ds1 As New DataSet
        Dim dsCASH As New DataSet
        Dim dsCASH1 As New DataSet
        Dim dsBANK As New DataSet
        Dim dsBANK1 As New DataSet
        Dim dsEMPSOL As New DataSet
        Dim dsEMPSOL1 As New DataSet
        Dim dsChecks As New DataSet
        Dim dsChecks1 As New DataSet
        Dim dsDeposits As New DataSet
        Dim dsDeposits1 As New DataSet
        Dim dsPTRANSACTION As New DataSet
        Dim dsPTRANSACTION1 As New DataSet

        Dim dsBUYS As New DataSet
        Dim dsBUYS1 As New DataSet
        Dim dsSALES As New DataSet
        Dim dsSALES1 As New DataSet
        Dim dsTodaySales As New DataSet
        Dim dsTodaySales1 As New DataSet
        Dim dsTodaySales_barcoodd As New DataSet
        Dim dsTodaySales_barcoodd1 As New DataSet
        Dim dsASTRGA_ASTRDA As New DataSet
        Dim dsASTRGA_ASTRDA1 As New DataSet
        Dim dsCABLES As New DataSet
        Dim dsCABLES1 As New DataSet
        Dim dsCABLESCOEMPLOYEES As New DataSet
        Dim dsCABLESCOEMPLOYEES1 As New DataSet
        Dim dsInvoice As New DataSet
        Dim dsInvoice1 As New DataSet
        Dim dsPETRO As New DataSet
        Dim dsPETRO1 As New DataSet
        Dim dsMYCOSTS As New DataSet
        Dim dsMYCOSTS1 As New DataSet

        Dim dsSuppliers As New DataSet
        Dim dsSuppliers1 As New DataSet
        Dim dsSALARIES As New DataSet
        Dim dsSALARIES1 As New DataSet

        Dim dsLoans As New DataSet
        Dim dsLoans1 As New DataSet
        Dim dsLoansPa As New DataSet
        Dim dsLoansPa1 As New DataSet

        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql)
        Dim AdpCASH As New SqlClient.SqlDataAdapter(strsqCASH)
        Dim AdpCASH1 As New SqlClient.SqlDataAdapter(strsqCASH1)
        Dim AdpBANK As New SqlClient.SqlDataAdapter(strsqBANK)
        Dim AdpBANK1 As New SqlClient.SqlDataAdapter(strsqBANK1)
        Dim AdpEMPSOL As New SqlClient.SqlDataAdapter(strsqEMPSOL)
        Dim AdpEMPSOL1 As New SqlClient.SqlDataAdapter(strsqEMPSOL1)
        Dim AdpChecks As New SqlClient.SqlDataAdapter(strsqChecks)
        Dim AdpChecks1 As New SqlClient.SqlDataAdapter(strsqChecks1)
        Dim AdpDeposits As New SqlClient.SqlDataAdapter(strsqDeposits)
        Dim AdpDeposits1 As New SqlClient.SqlDataAdapter(strsqDeposits1)

        Dim AdpPTRANSACTION As New SqlClient.SqlDataAdapter(strsqPTRANSACTION)
        Dim AdpPTRANSACTION1 As New SqlClient.SqlDataAdapter(strsqPTRANSACTION1)


        Dim AdpBUYS As New SqlClient.SqlDataAdapter(strsqBUYS)
        Dim AdpBUYS1 As New SqlClient.SqlDataAdapter(strsqBUYS1)
        Dim AdpSALES As New SqlClient.SqlDataAdapter(strsqSALES)
        Dim AdpSALES1 As New SqlClient.SqlDataAdapter(strsqSALES1)
        Dim AdpTodaySales As New SqlClient.SqlDataAdapter(strsqTodaySales)
        Dim AdpTodaySales1 As New SqlClient.SqlDataAdapter(strsqTodaySales1)

        Dim AdpASTRGA_ASTRDA As New SqlClient.SqlDataAdapter(strsqASTRGA_ASTRDA)
        Dim AdpASTRGA_ASTRDA1 As New SqlClient.SqlDataAdapter(strsqASTRGA_ASTRDA1)
        Dim AdpCABLES As New SqlClient.SqlDataAdapter(strsqCABLES)
        Dim AdpCABLES1 As New SqlClient.SqlDataAdapter(strsqCABLES1)
        Dim AdpCABLESCOEMPLOYEES As New SqlClient.SqlDataAdapter(strsqCABLESCOEMPLOYEES)
        Dim AdpCABLESCOEMPLOYEES1 As New SqlClient.SqlDataAdapter(strsqCABLESCOEMPLOYEES1)
        Dim AdpInvoice As New SqlClient.SqlDataAdapter(strsqInvoice)
        Dim AdpInvoice1 As New SqlClient.SqlDataAdapter(strsqInvoice1)
        Dim AdpPETRO As New SqlClient.SqlDataAdapter(strsqPETRO)
        Dim AdpPETRO1 As New SqlClient.SqlDataAdapter(strsqPETRO1)
        Dim AdpMYCOSTS As New SqlClient.SqlDataAdapter(strsqMYCOSTS)
        Dim AdpMYCOSTS1 As New SqlClient.SqlDataAdapter(strsqMYCOSTS1)

        Dim AdpSuppliers As New SqlClient.SqlDataAdapter(strsqSuppliers)
        Dim AdpSuppliers1 As New SqlClient.SqlDataAdapter(strsqSuppliers1)

        Dim AdpSALARIES As New SqlClient.SqlDataAdapter(strsqSALARIES)
        Dim AdpSALARIES1 As New SqlClient.SqlDataAdapter(strsqSALARIES1)

        Dim AdpLoans As New SqlClient.SqlDataAdapter(strsqLoans)
        Dim AdpLoans1 As New SqlClient.SqlDataAdapter(strsqLoans1)
        Dim AdpLoansPa As New SqlClient.SqlDataAdapter(strsqLoansPa)
        Dim AdpLoansPa1 As New SqlClient.SqlDataAdapter(strsqLoansPa1)




        On Error Resume Next
        ds1.Clear()
        dsCASH.Clear()
        dsCASH1.Clear()
        dsBANK.Clear()
        dsBANK1.Clear()
        dsEMPSOL.Clear()
        dsEMPSOL1.Clear()
        dsChecks.Clear()
        dsChecks1.Clear()
        dsDeposits.Clear()
        dsDeposits1.Clear()
        dsPTRANSACTION.Clear()
        dsPTRANSACTION1.Clear()
        dsBUYS.Clear()
        dsBUYS1.Clear()
        dsSALES.Clear()
        dsSALES1.Clear()
        dsTodaySales.Clear()
        dsTodaySales1.Clear()

        dsASTRGA_ASTRDA.Clear()
        dsASTRGA_ASTRDA1.Clear()
        dsSALES1.Clear()
        dsCABLES.Clear()
        dsCABLESCOEMPLOYEES.Clear()
        dsCABLESCOEMPLOYEES1.Clear()
        dsInvoice.Clear()
        dsInvoice1.Clear()
        dsPETRO.Clear()
        dsPETRO1.Clear()
        dsMYCOSTS.Clear()
        dsMYCOSTS1.Clear()
        dsSuppliers.Clear()
        dsSuppliers1.Clear()
        dsSALARIES.Clear()
        dsSALARIES1.Clear()
        dsLoans.Clear()
        dsLoans1.Clear()
        dsLoansPa.Clear()
        dsLoansPa1.Clear()

        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds1, "MOVES")
        AdpCASH.Fill(dsCASH, "CASHIER")
        AdpCASH1.Fill(dsCASH1, "CASHIER")
        AdpBANK.Fill(dsBANK, "BANKJO")
        AdpBANK1.Fill(dsBANK1, "BANKJO")
        AdpEMPSOL.Fill(dsEMPSOL, "EMPSOLF")
        AdpEMPSOL1.Fill(dsEMPSOL1, "EMPSOLF")
        AdpChecks.Fill(dsChecks, "Checks")
        AdpChecks1.Fill(dsChecks1, "Checks")
        AdpDeposits.Fill(dsDeposits, "Deposits")
        AdpDeposits1.Fill(dsDeposits1, "Deposits")
        AdpPTRANSACTION.Fill(dsPTRANSACTION, "PTRANSACTION")
        AdpPTRANSACTION1.Fill(dsPTRANSACTION1, "PTRANSACTION")

        AdpBUYS.Fill(dsBUYS, "BUYS")
        AdpBUYS1.Fill(dsBUYS1, "BUYS")
        AdpSALES.Fill(dsSALES, "SALES")
        AdpSALES1.Fill(dsSALES1, "SALES")
        AdpTodaySales.Fill(dsTodaySales, "TodaySales")
        AdpTodaySales1.Fill(dsTodaySales1, "TodaySales")

        AdpASTRGA_ASTRDA.Fill(dsASTRGA_ASTRDA, "ASTRGA_ASTRDA")
        AdpASTRGA_ASTRDA1.Fill(dsASTRGA_ASTRDA1, "ASTRGA_ASTRDA")
        AdpCABLES.Fill(dsCABLES, "CABLES")
        AdpCABLES1.Fill(dsCABLES1, "CABLES")
        AdpCABLESCOEMPLOYEES.Fill(dsCABLESCOEMPLOYEES, "CABLESCOEMPLOYEES")
        AdpCABLESCOEMPLOYEES1.Fill(dsCABLESCOEMPLOYEES1, "CABLESCOEMPLOYEES")
        AdpInvoice.Fill(dsInvoice, "Invoice")
        AdpInvoice1.Fill(dsInvoice1, "Invoice")
        AdpPETRO.Fill(dsPETRO, "PETRO")
        AdpPETRO1.Fill(dsPETRO1, "PETRO")
        AdpMYCOSTS.Fill(dsMYCOSTS, "MYCOSTS")
        AdpMYCOSTS1.Fill(dsMYCOSTS1, "MYCOSTS")

        AdpSuppliers.Fill(dsSuppliers, "Suppliers1")
        AdpSuppliers1.Fill(dsSuppliers1, "Suppliers1")

        AdpSALARIES.Fill(dsSALARIES, "SALARIES")
        AdpSALARIES1.Fill(dsSALARIES1, "SALARIES")
        AdpLoans.Fill(dsLoans, "Loans")
        AdpLoans1.Fill(dsLoans1, "Loans")
        AdpLoansPa.Fill(dsLoansPa, "LoansPa")
        AdpLoansPa1.Fill(dsLoansPa1, "LoansPa")

        Consum.Close()
        'Dim fn As Font = New Font(f.DataGridView6.DefaultCellStyle.Font.Name, f.DataGridView6.DefaultCellStyle.Font.Size, FontStyle.Bold)
        DataGrid.Rows.Add("=== القيود المحاسبة ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To ds1.Tables("MOVES").Rows.Count - 1
            Dim MidNo As String = ds1.Tables("MOVES").Rows(II).Item("MOV2")
            Dim MidNo1 As String = ds1.Tables("MOVES").Rows(II).Item("MOV11")
            Dim Middat As String = ds1.Tables("MOVES").Rows(II).Item("MOV3")
            Dim MidName As String = ds1.Tables("MOVES").Rows(II).Item("MOV4")
            Dim MidUSERNAME As String = ds1.Tables("MOVES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "قيود غير مراجعة", "القيود المحاسبة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الصندوق ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsCASH.Tables("CASHIER").Rows.Count - 1
            Dim MidNo As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH4")
            Dim Middat As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH2")
            Dim MidName As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsCASH.Tables("CASHIER").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الصندوق غير مرحلة", "الصندوق", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsCASH1.Tables("CASHIER").Rows.Count - 1
            Dim MidNo As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH4")
            Dim Middat As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH2")
            Dim MidName As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsCASH1.Tables("CASHIER").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الصندوق غير مراجعة", "الصندوق", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الصندوق" Then
                    row.Cells(0).Style.BackColor = Color.Wheat
                    row.Cells(1).Style.BackColor = Color.Wheat
                    row.Cells(2).Style.BackColor = Color.Wheat
                    row.Cells(3).Style.BackColor = Color.Wheat
                    row.Cells(4).Style.BackColor = Color.Wheat
                    row.Cells(5).Style.BackColor = Color.Wheat
                    row.Cells(6).Style.BackColor = Color.Wheat
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("==== البنك =====", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsBANK.Tables("BANKJO").Rows.Count - 1
            Dim MidNo As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK1")
            Dim MidNo1 As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK13")
            Dim Middat As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK3")
            Dim MidName As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK9")
            Dim MidUSERNAME As String = dsBANK.Tables("BANKJO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "البنك غير مرحلة", "البنك", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsBANK1.Tables("BANKJO").Rows.Count - 1
            Dim MidNo As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK1")
            Dim MidNo1 As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK13")
            Dim Middat As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK3")
            Dim MidName As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK9")
            Dim MidUSERNAME As String = dsBANK1.Tables("BANKJO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "البنك غير مراجعة", "البنك", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "البنك" Then
                    row.Cells(0).Style.BackColor = Color.PeachPuff
                    row.Cells(1).Style.BackColor = Color.PeachPuff
                    row.Cells(2).Style.BackColor = Color.PeachPuff
                    row.Cells(3).Style.BackColor = Color.PeachPuff
                    row.Cells(4).Style.BackColor = Color.PeachPuff
                    row.Cells(5).Style.BackColor = Color.PeachPuff
                    row.Cells(6).Style.BackColor = Color.PeachPuff
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الموظفين ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsEMPSOL.Tables("EMPSOLF").Rows.Count - 1
            Dim MidNo As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH17")
            Dim Middat As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH2")
            Dim MidName As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموظفين غير مرحلة", "الموظفين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsEMPSOL1.Tables("EMPSOLF").Rows.Count - 1
            Dim MidNo As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH17")
            Dim Middat As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH2")
            Dim MidName As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموظفين غير مراجعة", "الموظفين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموظفين" Then
                    row.Cells(0).Style.BackColor = Color.Bisque
                    row.Cells(1).Style.BackColor = Color.Bisque
                    row.Cells(2).Style.BackColor = Color.Bisque
                    row.Cells(3).Style.BackColor = Color.Bisque
                    row.Cells(4).Style.BackColor = Color.Bisque
                    row.Cells(5).Style.BackColor = Color.Bisque
                    row.Cells(6).Style.BackColor = Color.Bisque
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الشيكات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsChecks.Tables("Checks").Rows.Count - 1
            Dim MidNo As String = dsChecks.Tables("Checks").Rows(II).Item("IDCH")
            Dim MidNo1 As String = dsChecks.Tables("Checks").Rows(II).Item("CH16")
            Dim Middat As String = dsChecks.Tables("Checks").Rows(II).Item("CH3")
            Dim MidName As String = dsChecks.Tables("Checks").Rows(II).Item("CH9")
            Dim MidUSERNAME As String = dsChecks.Tables("Checks").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الشيكات غير مرحلة", "الشيكات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsChecks1.Tables("Checks").Rows.Count - 1
            Dim MidNo As String = dsChecks1.Tables("Checks").Rows(II).Item("IDCH")
            Dim MidNo1 As String = dsChecks1.Tables("Checks").Rows(II).Item("CH16")
            Dim Middat As String = dsChecks1.Tables("Checks").Rows(II).Item("CH3")
            Dim MidName As String = dsChecks1.Tables("Checks").Rows(II).Item("CH9")
            Dim MidUSERNAME As String = dsChecks1.Tables("Checks").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الشيكات غير مراجعة", "الشيكات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الشيكات" Then
                    row.Cells(0).Style.BackColor = Color.PapayaWhip
                    row.Cells(1).Style.BackColor = Color.PapayaWhip
                    row.Cells(2).Style.BackColor = Color.PapayaWhip
                    row.Cells(3).Style.BackColor = Color.PapayaWhip
                    row.Cells(4).Style.BackColor = Color.PapayaWhip
                    row.Cells(5).Style.BackColor = Color.PapayaWhip
                    row.Cells(6).Style.BackColor = Color.PapayaWhip
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الاسهم ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsDeposits.Tables("Deposits").Rows.Count - 1
            Dim MidNo As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK18")
            Dim Middat As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK3")
            Dim MidName As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK20")
            Dim MidUSERNAME As String = dsDeposits.Tables("Deposits").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الاسهم غير مرحلة", "الاسهم", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsDeposits1.Tables("Deposits").Rows.Count - 1
            Dim MidNo As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK18")
            Dim Middat As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK3")
            Dim MidName As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK20")
            Dim MidUSERNAME As String = dsDeposits1.Tables("Deposits").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الاسهم غير مراجعة", "الاسهم", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الاسهم" Then
                    row.Cells(0).Style.BackColor = Color.FloralWhite
                    row.Cells(1).Style.BackColor = Color.FloralWhite
                    row.Cells(2).Style.BackColor = Color.FloralWhite
                    row.Cells(3).Style.BackColor = Color.FloralWhite
                    row.Cells(4).Style.BackColor = Color.FloralWhite
                    row.Cells(5).Style.BackColor = Color.FloralWhite
                    row.Cells(6).Style.BackColor = Color.FloralWhite
                End If
            Next
        Next

        '===================================================================================================
        DataGrid.Rows.Add("=== حركات السحب والايداعات النقدية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsPTRANSACTION.Tables("PTRANSACTION").Rows.Count - 1
            Dim MidNo As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK11")
            Dim Middat As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK3")
            Dim MidName As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK22")
            Dim MidUSERNAME As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "حركات السحب والايداعات النقدية غير مرحلة", "حركات السحب والايداعات النقدية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsPTRANSACTION1.Tables("PTRANSACTION").Rows.Count - 1
            Dim MidNo As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK11")
            Dim Middat As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK3")
            Dim MidName As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK22")
            Dim MidUSERNAME As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "حركات السحب والايداعات النقدية غير مراجعة", "حركات السحب والايداعات النقدية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "حركات السحب والايداعات النقدية" Then
                    row.Cells(0).Style.BackColor = Color.FloralWhite
                    row.Cells(1).Style.BackColor = Color.FloralWhite
                    row.Cells(2).Style.BackColor = Color.FloralWhite
                    row.Cells(3).Style.BackColor = Color.FloralWhite
                    row.Cells(4).Style.BackColor = Color.FloralWhite
                    row.Cells(5).Style.BackColor = Color.FloralWhite
                    row.Cells(6).Style.BackColor = Color.FloralWhite
                End If
            Next
        Next
        '===================================================================================================

        DataGrid.Rows.Add("=== المبيعات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsSALES.Tables("SALES").Rows.Count - 1
            Dim MidNo As String = dsSALES.Tables("SALES").Rows(II).Item("SLS2")
            Dim MidNo1 As String = dsSALES.Tables("SALES").Rows(II).Item("SLS19")
            Dim Middat As String = dsSALES.Tables("SALES").Rows(II).Item("SLS3")
            Dim MidName As String = dsSALES.Tables("SALES").Rows(II).Item("SLS5")
            Dim MidUSERNAME As String = dsSALES.Tables("SALES").Rows(II).Item("USERNAME")

            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مرحلة", "المبيعات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsSALES1.Tables("SALES").Rows.Count - 1
            Dim MidNo As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS2")
            Dim MidNo1 As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS19")
            Dim Middat As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS3")
            Dim MidName As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS5")
            Dim MidUSERNAME As String = dsSALES1.Tables("SALES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مراجعة", "المبيعات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المبيعات" Then
                    row.Cells(0).Style.BackColor = Color.MediumAquamarine
                    row.Cells(1).Style.BackColor = Color.MediumAquamarine
                    row.Cells(2).Style.BackColor = Color.MediumAquamarine
                    row.Cells(3).Style.BackColor = Color.MediumAquamarine
                    row.Cells(4).Style.BackColor = Color.MediumAquamarine
                    row.Cells(5).Style.BackColor = Color.MediumAquamarine
                    row.Cells(6).Style.BackColor = Color.MediumAquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("===المبيعات اليومية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsTodaySales.Tables("TodaySales").Rows.Count - 1
            Dim MidNo As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("ID")
            Dim MidNo1 As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("TS9")
            Dim Middat As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("DataTS")
            Dim MidName As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("BarCod")
            Dim MidUSERNAME As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مرحلة", "المببعات_اليومية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsTodaySales1.Tables("TodaySales").Rows.Count - 1
            Dim MidNo As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("ID")
            Dim MidNo1 As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("TS9")
            Dim Middat As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("DataTS")
            Dim MidName As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("BarCod")
            Dim MidUSERNAME As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مراجعة", "المببعات_اليومية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المببعات_اليومية" Then
                    row.Cells(0).Style.BackColor = Color.MediumAquamarine
                    row.Cells(1).Style.BackColor = Color.MediumAquamarine
                    row.Cells(2).Style.BackColor = Color.Red
                    row.Cells(3).Style.BackColor = Color.MediumAquamarine
                    row.Cells(4).Style.BackColor = Color.MediumAquamarine
                    row.Cells(5).Style.BackColor = Color.MediumAquamarine
                    row.Cells(6).Style.BackColor = Color.MediumAquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("===المبيعات المسترجعة===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows.Count - 1
            Dim MidNo As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("ID")
            Dim MidNo1 As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("NumFatorh12")
            Dim Middat As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("DataD10")
            Dim MidName As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("Barcodd1")
            Dim MidUSERNAME As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مرحلة", "المبيعات المسترجعة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows.Count - 1
            Dim MidNo As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("ID")
            Dim MidNo1 As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("NumFatorh12")
            Dim Middat As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("DataD10")
            Dim MidName As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("Barcodd1")
            Dim MidUSERNAME As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مراجعة", "المبيعات المسترجعة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المبيعات المسترجعة" Then
                    row.Cells(0).Style.BackColor = Color.MediumAquamarine
                    row.Cells(1).Style.BackColor = Color.MediumAquamarine
                    row.Cells(2).Style.BackColor = Color.MediumAquamarine
                    row.Cells(3).Style.BackColor = Color.MediumAquamarine
                    row.Cells(4).Style.BackColor = Color.MediumAquamarine
                    row.Cells(5).Style.BackColor = Color.MediumAquamarine
                    row.Cells(6).Style.BackColor = Color.MediumAquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المشتريات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsBUYS.Tables("BUYS").Rows.Count - 1
            Dim MidNo As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY2")
            Dim MidNo1 As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY18")
            Dim Middat As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY3")
            Dim MidName As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY24")
            Dim MidUSERNAME As String = dsBUYS.Tables("BUYS").Rows(II).Item("USERNAME")

            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المشتريات غير مرحلة", "المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsBUYS1.Tables("BUYS").Rows.Count - 1
            Dim MidNo As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY2")
            Dim MidNo1 As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY18")
            Dim Middat As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY3")
            Dim MidName As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY24")
            Dim MidUSERNAME As String = dsBUYS1.Tables("BUYS").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المشتريات غير مراجعة", "المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المشتريات" Then
                    row.Cells(0).Style.BackColor = Color.Aquamarine
                    row.Cells(1).Style.BackColor = Color.Aquamarine
                    row.Cells(2).Style.BackColor = Color.Aquamarine
                    row.Cells(3).Style.BackColor = Color.Aquamarine
                    row.Cells(4).Style.BackColor = Color.Aquamarine
                    row.Cells(5).Style.BackColor = Color.Aquamarine
                    row.Cells(6).Style.BackColor = Color.Aquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== العملاء ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsCABLES.Tables("CABLES").Rows.Count - 1
            Dim MidNo As String = dsCABLES.Tables("CABLES").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsCABLES.Tables("CABLES").Rows(II).Item("CAB21")
            Dim Middat As String = dsCABLES.Tables("CABLES").Rows(II).Item("CAB3")
            Dim MidName As String = dsCABLES.Tables("CABLES").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsCABLES.Tables("CABLES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "العملاء غير مراجعة", "العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "العملاء" Then
                    row.Cells(0).Style.BackColor = Color.Tan
                    row.Cells(1).Style.BackColor = Color.Tan
                    row.Cells(2).Style.BackColor = Color.Tan
                    row.Cells(3).Style.BackColor = Color.Tan
                    row.Cells(4).Style.BackColor = Color.Tan
                    row.Cells(5).Style.BackColor = Color.Tan
                    row.Cells(6).Style.BackColor = Color.Tan
                End If
            Next
        Next
        For II As Integer = 0 To dsCABLES1.Tables("CABLES").Rows.Count - 1
            Dim MidNo As String = dsCABLES1.Tables("CABLES").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsCABLES1.Tables("CABLES").Rows(II).Item("CAB21")
            Dim Middat As String = dsCABLES1.Tables("CABLES").Rows(II).Item("CAB3")
            Dim MidName As String = dsCABLES1.Tables("CABLES").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsCABLES1.Tables("CABLES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "العملاء غير مرحلة", "العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "العملاء" Then
                    row.Cells(0).Style.BackColor = Color.Tan
                    row.Cells(1).Style.BackColor = Color.Tan
                    row.Cells(2).Style.BackColor = Color.Tan
                    row.Cells(3).Style.BackColor = Color.Tan
                    row.Cells(4).Style.BackColor = Color.Tan
                    row.Cells(5).Style.BackColor = Color.Tan
                    row.Cells(6).Style.BackColor = Color.Tan
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== مصاريف المشتريات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows.Count - 1
            Dim MidNo As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP3")
            Dim MidNo1 As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP31")
            Dim Middat As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP2")
            Dim MidName As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP25")
            Dim MidUSERNAME As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "مصاريف المشتريات غير مرحلة", "مصاريف المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows.Count - 1
            Dim MidNo As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP3")
            Dim MidNo1 As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP31")
            Dim Middat As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP2")
            Dim MidName As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP25")
            Dim MidUSERNAME As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "مصاريف المشتريات غير مراجعة", "مصاريف المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "مصاريف المشتريات" Then
                    row.Cells(0).Style.BackColor = Color.NavajoWhite
                    row.Cells(1).Style.BackColor = Color.NavajoWhite
                    row.Cells(2).Style.BackColor = Color.NavajoWhite
                    row.Cells(3).Style.BackColor = Color.NavajoWhite
                    row.Cells(4).Style.BackColor = Color.NavajoWhite
                    row.Cells(5).Style.BackColor = Color.NavajoWhite
                    row.Cells(6).Style.BackColor = Color.NavajoWhite
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== فاتورة نقل تفصيلية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsInvoice.Tables("Invoice").Rows.Count - 1
            Dim MidNo As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO23")
            Dim Middat As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO5")
            Dim MidName As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsInvoice.Tables("Invoice").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل تفصيلية غير مرحلة", "فاتورة نقل تفصيلية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsInvoice1.Tables("Invoice").Rows.Count - 1
            Dim MidNo As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO23")
            Dim Middat As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO5")
            Dim MidName As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsInvoice1.Tables("Invoice").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل تفصيلية غير مراجعة", "فاتورة نقل تفصيلية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "فاتورة نقل تفصيلية" Then
                    row.Cells(0).Style.BackColor = Color.OldLace
                    row.Cells(1).Style.BackColor = Color.OldLace
                    row.Cells(2).Style.BackColor = Color.OldLace
                    row.Cells(3).Style.BackColor = Color.OldLace
                    row.Cells(4).Style.BackColor = Color.OldLace
                    row.Cells(5).Style.BackColor = Color.OldLace
                    row.Cells(6).Style.BackColor = Color.OldLace
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== فاتورة نقل === ", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsPETRO.Tables("PETRO").Rows.Count - 1
            Dim MidNo As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO23")
            Dim Middat As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO5")
            Dim MidName As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsPETRO.Tables("PETRO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل غير مرحلة", "فاتورة نقل", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsPETRO1.Tables("PETRO").Rows.Count - 1
            Dim MidNo As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO23")
            Dim Middat As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO5")
            Dim MidName As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsPETRO1.Tables("PETRO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل غير مراجعة", "فاتورة نقل", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "فاتورة نقل" Then
                    row.Cells(0).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(1).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(2).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(3).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(4).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(5).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(6).Style.BackColor = Color.MediumSlateBlue
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المصاريف العامة===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsMYCOSTS.Tables("MYCOSTS").Rows.Count - 1
            Dim MidNo As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST1")
            Dim MidNo1 As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST13")
            Dim Middat As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST7")
            Dim MidName As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST10")
            Dim MidUSERNAME As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المصاريف العامة غير مرحلة", "المصاريف العامة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsMYCOSTS1.Tables("MYCOSTS").Rows.Count - 1
            Dim MidNo As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST1")
            Dim MidNo1 As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST13")
            Dim Middat As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST7")
            Dim MidName As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST10")
            Dim MidUSERNAME As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المصاريف العامة غير مراجعة", "المصاريف العامة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المصاريف العامة" Then
                    row.Cells(0).Style.BackColor = Color.Moccasin
                    row.Cells(1).Style.BackColor = Color.Moccasin
                    row.Cells(2).Style.BackColor = Color.Moccasin
                    row.Cells(3).Style.BackColor = Color.Moccasin
                    row.Cells(4).Style.BackColor = Color.Moccasin
                    row.Cells(5).Style.BackColor = Color.Moccasin
                    row.Cells(6).Style.BackColor = Color.Moccasin
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الموردين ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsSuppliers.Tables("Suppliers1").Rows.Count - 1
            Dim MidNo As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("CAB21")
            Dim Middat As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("CAB3")
            'Dim MidName As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموردين غير مرحلة", "الموردين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsSuppliers1.Tables("Suppliers1").Rows.Count - 1
            Dim MidNo As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("CAB21")
            Dim Middat As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("CAB3")
            'Dim MidName As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموردين غير مراجعة", "الموردين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموردين" Then
                    row.Cells(0).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(1).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(2).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(3).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(4).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(5).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(6).Style.BackColor = Color.BlanchedAlmond
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المرتبات والاجور ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsSALARIES.Tables("SALARIES").Rows.Count - 1
            Dim MidNo As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY1")
            Dim MidNo1 As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY25")
            Dim Middat As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY26")
            Dim MidName As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY2")
            Dim MidUSERNAME As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المرتبات والاجور غير مرحلة", "المرتبات والاجور", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsSALARIES1.Tables("SALARIES").Rows.Count - 1
            Dim MidNo As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY1")
            Dim MidNo1 As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY25")
            Dim Middat As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY26")
            Dim MidName As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY2")
            Dim MidUSERNAME As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المرتبات والاجور غير مراجعة", "المرتبات والاجور", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المرتبات والاجور" Then
                    row.Cells(0).Style.BackColor = Color.AntiqueWhite
                    row.Cells(1).Style.BackColor = Color.AntiqueWhite
                    row.Cells(2).Style.BackColor = Color.AntiqueWhite
                    row.Cells(3).Style.BackColor = Color.AntiqueWhite
                    row.Cells(4).Style.BackColor = Color.AntiqueWhite
                    row.Cells(5).Style.BackColor = Color.AntiqueWhite
                    row.Cells(6).Style.BackColor = Color.AntiqueWhite
                End If
            Next
        Next
        DataGrid.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "" Then
                row.Cells(0).Style.BackColor = Color.LightGray
                row.Cells(1).Style.BackColor = Color.LightGray
                row.Cells(2).Style.BackColor = Color.LightGray
                row.Cells(3).Style.BackColor = Color.LightGray
                row.Cells(4).Style.BackColor = Color.LightGray
                row.Cells(5).Style.BackColor = Color.LightGray
                row.Cells(6).Style.BackColor = Color.LightGray
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== القروض ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsLoans.Tables("Loans").Rows.Count - 1
            Dim MidNo As String = dsLoans.Tables("Loans").Rows(II).Item("lo")
            Dim MidNo1 As String = dsLoans.Tables("Loans").Rows(II).Item("lo17")
            Dim Middat As String = dsLoans.Tables("Loans").Rows(II).Item("lo2")
            Dim MidName As String = dsLoans.Tables("Loans").Rows(II).Item("lo5")
            Dim MidUSERNAME As String = dsLoans.Tables("Loans").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "القروض غير مرحلة", "القروض", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsLoans1.Tables("Loans").Rows.Count - 1
            Dim MidNo As String = dsLoans1.Tables("Loans").Rows(II).Item("lo")
            Dim MidNo1 As String = dsLoans1.Tables("Loans").Rows(II).Item("lo17")
            Dim Middat As String = dsLoans1.Tables("Loans").Rows(II).Item("lo2")
            Dim MidName As String = dsLoans1.Tables("Loans").Rows(II).Item("lo5")
            Dim MidUSERNAME As String = dsLoans1.Tables("Loans").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "القروض غير مراجعة", "القروض", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموظفين" Then
                    row.Cells(0).Style.BackColor = Color.Bisque
                    row.Cells(1).Style.BackColor = Color.Bisque
                    row.Cells(2).Style.BackColor = Color.Bisque
                    row.Cells(3).Style.BackColor = Color.Bisque
                    row.Cells(4).Style.BackColor = Color.Bisque
                    row.Cells(5).Style.BackColor = Color.Bisque
                    row.Cells(6).Style.BackColor = Color.Bisque
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== تسديدات العملاء ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsLoansPa.Tables("LoansPa").Rows.Count - 1
            Dim MidNo As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa1")
            Dim MidNo1 As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa5")
            Dim Middat As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa3")
            Dim MidName As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa11")
            Dim MidUSERNAME As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "تسديدات العملاء غير مرحلة", "تسديدات العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For II As Integer = 0 To dsLoansPa1.Tables("LoansPa").Rows.Count - 1
            Dim MidNo As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa1")
            Dim MidNo1 As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa5")
            Dim Middat As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa3")
            Dim MidName As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa11")
            Dim MidUSERNAME As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "تسديدات العملاء غير مراجعة", "تسديدات العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموظفين" Then
                    row.Cells(0).Style.BackColor = Color.Beige
                    row.Cells(1).Style.BackColor = Color.Beige
                    row.Cells(2).Style.BackColor = Color.Beige
                    row.Cells(3).Style.BackColor = Color.Beige
                    row.Cells(4).Style.BackColor = Color.Beige
                    row.Cells(5).Style.BackColor = Color.Beige
                    row.Cells(6).Style.BackColor = Color.Beige
                End If
            Next
        Next

        Consum.Close()
        'On Error Resume Next
        'Dim I As Integer


        '    For I = 0 To f.DataGridView6.ToString.Count + 1
        '        f.ProgressBar1.Visible = True
        '        f.ProgressBar1.Minimum = 1
        '        f.ProgressBar1.Maximum = BS.Count - 1
        '        f.ProgressBar1.Value = I
        '        If f.ProgressBar1.Value <= 30 Then
        '            f.Label1.Text = "بداية تشغيل البرنامج ـ الحسابات ـ ـ"
        '        ElseIf f.ProgressBar1.Value <= 50 Then
        '            f.Label1.Text = "تحميل البرنامج ـ الحسابات  ـ ـ"
        '        ElseIf f.ProgressBar1.Value <= 70 Then
        '            f.Label1.Text = "التحقيق من الملفات ـ الحسابات  ـ ـ"
        '        ElseIf f.ProgressBar1.Value <= 100 Then
        '            f.Label1.Text = "الرجاء الانتظار ـ-الحسابات -ـ-ـ-ـ"
        '            f.Label1.Visible = False
        '            f.Label1.Visible = False
        '            f.ProgressBar1.Visible = False
        '        End If
        '        Dim percent As Integer = CInt((CDbl(f.ProgressBar1.Value - f.ProgressBar1.Minimum) / CDbl(f.ProgressBar1.Maximum - f.ProgressBar1.Minimum)) * 100)
        '        Using gr As Graphics = f.ProgressBar1.CreateGraphics()
        '            gr.DrawString(percent.ToString() + "%", SystemFonts.DefaultFont, Brushes.Black, New PointF(f.ProgressBar1.Width / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Width / 2.0F), f.ProgressBar1.Height / 2 - (gr.MeasureString(percent.ToString() + "%", SystemFonts.DefaultFont).Height / 2.0F)))
        '        End Using
        '    Next
        'Next
    End Sub

    Public Sub SELECT_MOVES2(ByVal DataGrid As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FinaBalances1
        Dim A_Name, A_data, A_No, A_No1, A_USERNAME As String
        'Dim strsql As New SqlCommand("", Consum)
        Dim strsqCASH As New SqlCommand("", Consum)

        Dim strsqBANK As New SqlCommand("", Consum)

        Dim strsqEMPSOL As New SqlCommand("", Consum)

        Dim strsqChecks As New SqlCommand("", Consum)

        Dim strsqDeposits As New SqlCommand("", Consum)

        Dim strsqPTRANSACTION As New SqlCommand("", Consum)


        Dim strsqBUYS As New SqlCommand("", Consum)

        Dim strsqSALES As New SqlCommand("", Consum)

        Dim strsqTodaySales As New SqlCommand("", Consum)

        Dim strsqASTRGA_ASTRDA As New SqlCommand("", Consum)

        Dim strsqCABLES As New SqlCommand("", Consum)

        Dim strsqCABLESCOEMPLOYEES As New SqlCommand("", Consum)

        Dim strsqInvoice As New SqlCommand("", Consum)

        Dim strsqPETRO As New SqlCommand("", Consum)

        Dim strsqMYCOSTS As New SqlCommand("", Consum)

        Dim strsqSuppliers As New SqlCommand("", Consum)
        Dim strsqSALARIES As New SqlCommand("", Consum)


        Dim strsqLoans As New SqlCommand("", Consum)


        Dim strsqLoansPa As New SqlCommand("", Consum)



        'strsql.CommandText = "SELECT MOV2, MOV11, MOV12, MOV3, MOV4, USERNAME FROM MOVES   WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and MOV12 ='" & False & "'"
        strsqCASH.CommandText = " SELECT CSH1, CSH4, CSH2, CSH11, USERNAME  FROM CASHIER WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH17 ='" & False & "'"
        strsqBANK.CommandText = " SELECT EBNK1, EBNK13, EBNK3, EBNK9, USERNAME  FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK15 ='" & False & "'"
        strsqEMPSOL.CommandText = " SELECT CSH1, CSH2, CSH17, CSH11, USERNAME  FROM EMPSOLF WHERE CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH13 ='" & False & "'"
        strsqChecks.CommandText = " SELECT IDCH, CH3, CH16, CH9, USERNAME  FROM Checks WHERE CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CH19 ='" & False & "'"
        strsqDeposits.CommandText = " SELECT TBNK1, TBNK18, TBNK3, TBNK20, USERNAME  FROM Deposits WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK22 ='" & False & "'"

        strsqPTRANSACTION.CommandText = " SELECT TBNK1, TBNK11, TBNK3, TBNK22, USERNAME  FROM PTRANSACTION WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK17 ='" & False & "'"

        strsqBUYS.CommandText = " SELECT BUY2, BUY18, BUY3, BUY24, USERNAME  FROM BUYS WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and BUY17 ='" & False & "'"
        strsqSALES.CommandText = " SELECT SLS2, SLS19, SLS3, SLS5, USERNAME  FROM SALES WHERE CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and SLS17 ='" & False & "'"
        strsqTodaySales.CommandText = " SELECT ID, TS9, DataTS, BarCod, USERNAME  FROM TodaySales WHERE CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk1 ='" & False & "'"
        strsqASTRGA_ASTRDA.CommandText = " SELECT ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME  FROM ASTRGA_ASTRDA WHERE CUser='" & CUser & "' and Year(DataD10) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk1 ='" & False & "'"
        strsqCABLES.CommandText = "SELECT IDCAB, CAB3, CAB9, CAB21, USERNAME  FROM CABLES WHERE  CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB20 ='" & False & "'"
        strsqCABLESCOEMPLOYEES.CommandText = " SELECT CEMP3, CEMP2, CEMP25, CEMP31, USERNAME  FROM CABLESCOEMPLOYEES WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CEMP21 ='" & False & "'"

        strsqInvoice.CommandText = " SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM Invoice WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO15 ='" & False & "'"

        strsqPETRO.CommandText = " SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM PETRO WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO15 ='" & False & "'"

        strsqMYCOSTS.CommandText = " SELECT CST1, CST7, CST10, CST13, USERNAME  FROM MYCOSTS WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CST5 ='" & False & "'"

        strsqSuppliers.CommandText = " SELECT IDCAB, CAB3, CAB9, CAB18, USERNAME  FROM Suppliers1 WHERE  CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CAB13 ='" & False & "'"

        strsqSALARIES.CommandText = " SELECT SLY1, SLY2, SLY25, SLY26, USERNAME  FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and SLY27 ='" & False & "'"

        strsqLoans.CommandText = " SELECT lo, lo17, lo2, lo5, USERNAME  FROM Loans WHERE   CUser='" & CUser & "' and Year(lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and lo16 ='" & False & "'"

        strsqLoansPa.CommandText = " SELECT Loa1, Loa5, Loa3, Loa11, USERNAME  FROM LoansPa WHERE  CUser='" & CUser & "'  and Loa14 ='" & False & "' and Loa6 >'" & 0 & "'"



        'Dim ds1 As New DataSet
        Dim dsCASH As New DataSet

        Dim dsBANK As New DataSet

        Dim dsEMPSOL As New DataSet

        Dim dsChecks As New DataSet

        Dim dsDeposits As New DataSet

        Dim dsPTRANSACTION As New DataSet

        Dim dsBUYS As New DataSet

        Dim dsSALES As New DataSet

        Dim dsTodaySales As New DataSet

        Dim dsTodaySales_barcoodd As New DataSet

        Dim dsASTRGA_ASTRDA As New DataSet

        Dim dsCABLES As New DataSet

        Dim dsCABLESCOEMPLOYEES As New DataSet

        Dim dsInvoice As New DataSet

        Dim dsPETRO As New DataSet

        Dim dsMYCOSTS As New DataSet

        Dim dsSuppliers As New DataSet
        Dim dsSALARIES As New DataSet

        Dim dsLoans As New DataSet

        Dim dsLoansPa As New DataSet


        'Dim Adp1 As New SqlClient.SqlDataAdapter(strsql)
        Dim AdpCASH As New SqlClient.SqlDataAdapter(strsqCASH)

        Dim AdpBANK As New SqlClient.SqlDataAdapter(strsqBANK)

        Dim AdpEMPSOL As New SqlClient.SqlDataAdapter(strsqEMPSOL)

        Dim AdpChecks As New SqlClient.SqlDataAdapter(strsqChecks)

        Dim AdpDeposits As New SqlClient.SqlDataAdapter(strsqDeposits)


        Dim AdpPTRANSACTION As New SqlClient.SqlDataAdapter(strsqPTRANSACTION)


        Dim AdpBUYS As New SqlClient.SqlDataAdapter(strsqBUYS)

        Dim AdpSALES As New SqlClient.SqlDataAdapter(strsqSALES)

        Dim AdpTodaySales As New SqlClient.SqlDataAdapter(strsqTodaySales)

        Dim AdpASTRGA_ASTRDA As New SqlClient.SqlDataAdapter(strsqASTRGA_ASTRDA)

        Dim AdpCABLES As New SqlClient.SqlDataAdapter(strsqCABLES)

        Dim AdpCABLESCOEMPLOYEES As New SqlClient.SqlDataAdapter(strsqCABLESCOEMPLOYEES)

        Dim AdpInvoice As New SqlClient.SqlDataAdapter(strsqInvoice)

        Dim AdpPETRO As New SqlClient.SqlDataAdapter(strsqPETRO)

        Dim AdpMYCOSTS As New SqlClient.SqlDataAdapter(strsqMYCOSTS)

        Dim AdpSuppliers As New SqlClient.SqlDataAdapter(strsqSuppliers)
        Dim AdpSALARIES As New SqlClient.SqlDataAdapter(strsqSALARIES)


        Dim AdpLoans As New SqlClient.SqlDataAdapter(strsqLoans)

        Dim AdpLoansPa As New SqlClient.SqlDataAdapter(strsqLoansPa)





        On Error Resume Next
        'ds1.Clear()
        dsCASH.Clear()

        dsBANK.Clear()

        dsEMPSOL.Clear()

        dsChecks.Clear()

        dsDeposits.Clear()

        dsPTRANSACTION.Clear()

        dsBUYS.Clear()

        dsSALES.Clear()

        dsTodaySales.Clear()


        dsASTRGA_ASTRDA.Clear()

        dsSALES.Clear()
        dsCABLES.Clear()
        dsCABLESCOEMPLOYEES.Clear()

        dsInvoice.Clear()

        dsPETRO.Clear()

        dsMYCOSTS.Clear()

        dsSuppliers.Clear()
        dsSALARIES.Clear()

        dsLoans.Clear()

        dsLoansPa.Clear()


        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        'Adp1.Fill(ds1, "MOVES")
        AdpCASH.Fill(dsCASH, "CASHIER")

        AdpBANK.Fill(dsBANK, "BANKJO")

        AdpEMPSOL.Fill(dsEMPSOL, "EMPSOLF")

        AdpChecks.Fill(dsChecks, "Checks")

        AdpDeposits.Fill(dsDeposits, "Deposits")

        AdpPTRANSACTION.Fill(dsPTRANSACTION, "PTRANSACTION")

        AdpBUYS.Fill(dsBUYS, "BUYS")

        AdpSALES.Fill(dsSALES, "SALES")

        AdpTodaySales.Fill(dsTodaySales, "TodaySales")


        AdpASTRGA_ASTRDA.Fill(dsASTRGA_ASTRDA, "ASTRGA_ASTRDA")

        AdpCABLES.Fill(dsCABLES, "CABLES")

        AdpCABLESCOEMPLOYEES.Fill(dsCABLESCOEMPLOYEES, "CABLESCOEMPLOYEES")

        AdpInvoice.Fill(dsInvoice, "Invoice")

        AdpPETRO.Fill(dsPETRO, "PETRO")

        AdpMYCOSTS.Fill(dsMYCOSTS, "MYCOSTS")

        AdpSuppliers.Fill(dsSuppliers, "Suppliers1")
        AdpSALARIES.Fill(dsSALARIES, "SALARIES")

        AdpLoans.Fill(dsLoans, "Loans")

        AdpLoansPa.Fill(dsLoansPa, "LoansPa")


        Consum.Close()
        'Dim fn As Font = New Font(f.DataGridView6.DefaultCellStyle.Font.Name, f.DataGridView6.DefaultCellStyle.Font.Size, FontStyle.Bold)
        'DataGrid.Rows.Add("=== القيود المحاسبة ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        'For II As Integer = 0 To ds1.Tables("MOVES").Rows.Count - 1
        '    Dim MidNo As String = ds1.Tables("MOVES").Rows(II).Item("MOV2")
        '    Dim MidNo1 As String = ds1.Tables("MOVES").Rows(II).Item("MOV11")
        '    Dim Middat As String = ds1.Tables("MOVES").Rows(II).Item("MOV3")
        '    Dim MidName As String = ds1.Tables("MOVES").Rows(II).Item("MOV4")
        '    Dim MidUSERNAME As String = ds1.Tables("MOVES").Rows(II).Item("USERNAME")
        '    Dim row1 As String() = {"", MidNo, MidNo1, Middat, "قيود غير مراجعة", "القيود المحاسبة", MidUSERNAME, ""}
        '    DataGrid.Rows.Add(row1)
        'Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الصندوق ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsCASH.Tables("CASHIER").Rows.Count - 1
            Dim MidNo As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH4")
            Dim Middat As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH2")
            Dim MidName As String = dsCASH.Tables("CASHIER").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsCASH.Tables("CASHIER").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الصندوق غير مرحلة", "الصندوق", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next


        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "الصندوق" Then
                row.Cells(0).Style.BackColor = Color.Wheat
                row.Cells(1).Style.BackColor = Color.Wheat
                row.Cells(2).Style.BackColor = Color.Wheat
                row.Cells(3).Style.BackColor = Color.Wheat
                row.Cells(4).Style.BackColor = Color.Wheat
                row.Cells(5).Style.BackColor = Color.Wheat
                row.Cells(6).Style.BackColor = Color.Wheat
            End If

        Next
        '===================================================================================================
        DataGrid.Rows.Add("==== البنك =====", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsBANK.Tables("BANKJO").Rows.Count - 1
            Dim MidNo As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK1")
            Dim MidNo1 As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK13")
            Dim Middat As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK3")
            Dim MidName As String = dsBANK.Tables("BANKJO").Rows(II).Item("EBNK9")
            Dim MidUSERNAME As String = dsBANK.Tables("BANKJO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "البنك غير مرحلة", "البنك", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "البنك" Then
                row.Cells(0).Style.BackColor = Color.PeachPuff
                row.Cells(1).Style.BackColor = Color.PeachPuff
                row.Cells(2).Style.BackColor = Color.PeachPuff
                row.Cells(3).Style.BackColor = Color.PeachPuff
                row.Cells(4).Style.BackColor = Color.PeachPuff
                row.Cells(5).Style.BackColor = Color.PeachPuff
                row.Cells(6).Style.BackColor = Color.PeachPuff
            End If
        Next

        '===================================================================================================
        DataGrid.Rows.Add("=== الموظفين ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsEMPSOL.Tables("EMPSOLF").Rows.Count - 1
            Dim MidNo As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH17")
            Dim Middat As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH2")
            Dim MidName As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsEMPSOL.Tables("EMPSOLF").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموظفين غير مرحلة", "الموظفين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "الموظفين" Then
                row.Cells(0).Style.BackColor = Color.Bisque
                row.Cells(1).Style.BackColor = Color.Bisque
                row.Cells(2).Style.BackColor = Color.Bisque
                row.Cells(3).Style.BackColor = Color.Bisque
                row.Cells(4).Style.BackColor = Color.Bisque
                row.Cells(5).Style.BackColor = Color.Bisque
                row.Cells(6).Style.BackColor = Color.Bisque
            End If

        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الشيكات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsChecks.Tables("Checks").Rows.Count - 1
            Dim MidNo As String = dsChecks.Tables("Checks").Rows(II).Item("IDCH")
            Dim MidNo1 As String = dsChecks.Tables("Checks").Rows(II).Item("CH16")
            Dim Middat As String = dsChecks.Tables("Checks").Rows(II).Item("CH3")
            Dim MidName As String = dsChecks.Tables("Checks").Rows(II).Item("CH9")
            Dim MidUSERNAME As String = dsChecks.Tables("Checks").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الشيكات غير مرحلة", "الشيكات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "الشيكات" Then
                row.Cells(0).Style.BackColor = Color.PapayaWhip
                row.Cells(1).Style.BackColor = Color.PapayaWhip
                row.Cells(2).Style.BackColor = Color.PapayaWhip
                row.Cells(3).Style.BackColor = Color.PapayaWhip
                row.Cells(4).Style.BackColor = Color.PapayaWhip
                row.Cells(5).Style.BackColor = Color.PapayaWhip
                row.Cells(6).Style.BackColor = Color.PapayaWhip
            End If
        Next

        '===================================================================================================
        DataGrid.Rows.Add("=== الاسهم ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsDeposits.Tables("Deposits").Rows.Count - 1
            Dim MidNo As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK18")
            Dim Middat As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK3")
            Dim MidName As String = dsDeposits.Tables("Deposits").Rows(II).Item("TBNK20")
            Dim MidUSERNAME As String = dsDeposits.Tables("Deposits").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الاسهم غير مرحلة", "الاسهم", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "الاسهم" Then
                row.Cells(0).Style.BackColor = Color.FloralWhite
                row.Cells(1).Style.BackColor = Color.FloralWhite
                row.Cells(2).Style.BackColor = Color.FloralWhite
                row.Cells(3).Style.BackColor = Color.FloralWhite
                row.Cells(4).Style.BackColor = Color.FloralWhite
                row.Cells(5).Style.BackColor = Color.FloralWhite
                row.Cells(6).Style.BackColor = Color.FloralWhite
            End If
        Next


        '===================================================================================================
        DataGrid.Rows.Add("=== حركات السحب والايداعات النقدية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsPTRANSACTION.Tables("PTRANSACTION").Rows.Count - 1
            Dim MidNo As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK11")
            Dim Middat As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK3")
            Dim MidName As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("TBNK22")
            Dim MidUSERNAME As String = dsPTRANSACTION.Tables("PTRANSACTION").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "حركات السحب والايداعات النقدية غير مرحلة", "حركات السحب والايداعات النقدية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "حركات السحب والايداعات النقدية" Then
                row.Cells(0).Style.BackColor = Color.FloralWhite
                row.Cells(1).Style.BackColor = Color.FloralWhite
                row.Cells(2).Style.BackColor = Color.FloralWhite
                row.Cells(3).Style.BackColor = Color.FloralWhite
                row.Cells(4).Style.BackColor = Color.FloralWhite
                row.Cells(5).Style.BackColor = Color.FloralWhite
                row.Cells(6).Style.BackColor = Color.FloralWhite
            End If

        Next
        '===================================================================================================

        DataGrid.Rows.Add("=== المبيعات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsSALES.Tables("SALES").Rows.Count - 1
            Dim MidNo As String = dsSALES.Tables("SALES").Rows(II).Item("SLS2")
            Dim MidNo1 As String = dsSALES.Tables("SALES").Rows(II).Item("SLS19")
            Dim Middat As String = dsSALES.Tables("SALES").Rows(II).Item("SLS3")
            Dim MidName As String = dsSALES.Tables("SALES").Rows(II).Item("SLS5")
            Dim MidUSERNAME As String = dsSALES.Tables("SALES").Rows(II).Item("USERNAME")

            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مرحلة", "المبيعات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "المبيعات" Then
                row.Cells(0).Style.BackColor = Color.MediumAquamarine
                row.Cells(1).Style.BackColor = Color.MediumAquamarine
                row.Cells(2).Style.BackColor = Color.MediumAquamarine
                row.Cells(3).Style.BackColor = Color.MediumAquamarine
                row.Cells(4).Style.BackColor = Color.MediumAquamarine
                row.Cells(5).Style.BackColor = Color.MediumAquamarine
                row.Cells(6).Style.BackColor = Color.MediumAquamarine
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("===المبيعات اليومية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsTodaySales.Tables("TodaySales").Rows.Count - 1
            Dim MidNo As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("ID")
            Dim MidNo1 As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("TS9")
            Dim Middat As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("DataTS")
            Dim MidName As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("BarCod")
            Dim MidUSERNAME As String = dsTodaySales.Tables("TodaySales").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مرحلة", "المببعات_اليومية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next

        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "المببعات_اليومية" Then
                row.Cells(0).Style.BackColor = Color.MediumAquamarine
                row.Cells(1).Style.BackColor = Color.MediumAquamarine
                row.Cells(2).Style.BackColor = Color.Red
                row.Cells(3).Style.BackColor = Color.MediumAquamarine
                row.Cells(4).Style.BackColor = Color.MediumAquamarine
                row.Cells(5).Style.BackColor = Color.MediumAquamarine
                row.Cells(6).Style.BackColor = Color.MediumAquamarine
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("===المبيعات المسترجعة===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows.Count - 1
            Dim MidNo As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("ID")
            Dim MidNo1 As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("NumFatorh12")
            Dim Middat As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("DataD10")
            Dim MidName As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("Barcodd1")
            Dim MidUSERNAME As String = dsASTRGA_ASTRDA.Tables("ASTRGA_ASTRDA").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مرحلة", "المبيعات المسترجعة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "المبيعات المسترجعة" Then
                row.Cells(0).Style.BackColor = Color.MediumAquamarine
                row.Cells(1).Style.BackColor = Color.MediumAquamarine
                row.Cells(2).Style.BackColor = Color.MediumAquamarine
                row.Cells(3).Style.BackColor = Color.MediumAquamarine
                row.Cells(4).Style.BackColor = Color.MediumAquamarine
                row.Cells(5).Style.BackColor = Color.MediumAquamarine
                row.Cells(6).Style.BackColor = Color.MediumAquamarine
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المشتريات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsBUYS.Tables("BUYS").Rows.Count - 1
            Dim MidNo As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY2")
            Dim MidNo1 As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY18")
            Dim Middat As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY3")
            Dim MidName As String = dsBUYS.Tables("BUYS").Rows(II).Item("BUY24")
            Dim MidUSERNAME As String = dsBUYS.Tables("BUYS").Rows(II).Item("USERNAME")

            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المشتريات غير مرحلة", "المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "المشتريات" Then
                row.Cells(0).Style.BackColor = Color.Aquamarine
                row.Cells(1).Style.BackColor = Color.Aquamarine
                row.Cells(2).Style.BackColor = Color.Aquamarine
                row.Cells(3).Style.BackColor = Color.Aquamarine
                row.Cells(4).Style.BackColor = Color.Aquamarine
                row.Cells(5).Style.BackColor = Color.Aquamarine
                row.Cells(6).Style.BackColor = Color.Aquamarine
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== العملاء ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsCABLES.Tables("CABLES").Rows.Count - 1
            Dim MidNo As String = dsCABLES.Tables("CABLES").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsCABLES.Tables("CABLES").Rows(II).Item("CAB21")
            Dim Middat As String = dsCABLES.Tables("CABLES").Rows(II).Item("CAB3")
            Dim MidName As String = dsCABLES.Tables("CABLES").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsCABLES.Tables("CABLES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "العملاء غير مراجعة", "العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "العملاء" Then
                    row.Cells(0).Style.BackColor = Color.Tan
                    row.Cells(1).Style.BackColor = Color.Tan
                    row.Cells(2).Style.BackColor = Color.Tan
                    row.Cells(3).Style.BackColor = Color.Tan
                    row.Cells(4).Style.BackColor = Color.Tan
                    row.Cells(5).Style.BackColor = Color.Tan
                    row.Cells(6).Style.BackColor = Color.Tan
                End If
            Next
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "العملاء" Then
                row.Cells(0).Style.BackColor = Color.Tan
                row.Cells(1).Style.BackColor = Color.Tan
                row.Cells(2).Style.BackColor = Color.Tan
                row.Cells(3).Style.BackColor = Color.Tan
                row.Cells(4).Style.BackColor = Color.Tan
                row.Cells(5).Style.BackColor = Color.Tan
                row.Cells(6).Style.BackColor = Color.Tan
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== مصاريف المشتريات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows.Count - 1
            Dim MidNo As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP3")
            Dim MidNo1 As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP31")
            Dim Middat As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP2")
            Dim MidName As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP25")
            Dim MidUSERNAME As String = dsCABLESCOEMPLOYEES.Tables("CABLESCOEMPLOYEES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "مصاريف المشتريات غير مرحلة", "مصاريف المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "مصاريف المشتريات" Then
                row.Cells(0).Style.BackColor = Color.NavajoWhite
                row.Cells(1).Style.BackColor = Color.NavajoWhite
                row.Cells(2).Style.BackColor = Color.NavajoWhite
                row.Cells(3).Style.BackColor = Color.NavajoWhite
                row.Cells(4).Style.BackColor = Color.NavajoWhite
                row.Cells(5).Style.BackColor = Color.NavajoWhite
                row.Cells(6).Style.BackColor = Color.NavajoWhite
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== فاتورة نقل تفصيلية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsInvoice.Tables("Invoice").Rows.Count - 1
            Dim MidNo As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO23")
            Dim Middat As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO5")
            Dim MidName As String = dsInvoice.Tables("Invoice").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsInvoice.Tables("Invoice").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل تفصيلية غير مرحلة", "فاتورة نقل تفصيلية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "فاتورة نقل تفصيلية" Then
                row.Cells(0).Style.BackColor = Color.OldLace
                row.Cells(1).Style.BackColor = Color.OldLace
                row.Cells(2).Style.BackColor = Color.OldLace
                row.Cells(3).Style.BackColor = Color.OldLace
                row.Cells(4).Style.BackColor = Color.OldLace
                row.Cells(5).Style.BackColor = Color.OldLace
                row.Cells(6).Style.BackColor = Color.OldLace
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== فاتورة نقل === ", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsPETRO.Tables("PETRO").Rows.Count - 1
            Dim MidNo As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO23")
            Dim Middat As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO5")
            Dim MidName As String = dsPETRO.Tables("PETRO").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsPETRO.Tables("PETRO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل غير مرحلة", "فاتورة نقل", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "فاتورة نقل" Then
                row.Cells(0).Style.BackColor = Color.MediumSlateBlue
                row.Cells(1).Style.BackColor = Color.MediumSlateBlue
                row.Cells(2).Style.BackColor = Color.MediumSlateBlue
                row.Cells(3).Style.BackColor = Color.MediumSlateBlue
                row.Cells(4).Style.BackColor = Color.MediumSlateBlue
                row.Cells(5).Style.BackColor = Color.MediumSlateBlue
                row.Cells(6).Style.BackColor = Color.MediumSlateBlue
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المصاريف العامة===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsMYCOSTS.Tables("MYCOSTS").Rows.Count - 1
            Dim MidNo As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST1")
            Dim MidNo1 As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST13")
            Dim Middat As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST7")
            Dim MidName As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("CST10")
            Dim MidUSERNAME As String = dsMYCOSTS.Tables("MYCOSTS").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المصاريف العامة غير مرحلة", "المصاريف العامة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "المصاريف العامة" Then
                row.Cells(0).Style.BackColor = Color.Moccasin
                row.Cells(1).Style.BackColor = Color.Moccasin
                row.Cells(2).Style.BackColor = Color.Moccasin
                row.Cells(3).Style.BackColor = Color.Moccasin
                row.Cells(4).Style.BackColor = Color.Moccasin
                row.Cells(5).Style.BackColor = Color.Moccasin
                row.Cells(6).Style.BackColor = Color.Moccasin
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الموردين ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsSuppliers.Tables("Suppliers1").Rows.Count - 1
            Dim MidNo As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("CAB21")
            Dim Middat As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("CAB3")
            Dim MidName As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsSuppliers.Tables("Suppliers1").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموردين غير مرحلة", "الموردين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموردين" Then
                    row.Cells(0).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(1).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(2).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(3).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(4).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(5).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(6).Style.BackColor = Color.BlanchedAlmond
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المرتبات والاجور ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsSALARIES.Tables("SALARIES").Rows.Count - 1
            Dim MidNo As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY1")
            Dim MidNo1 As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY25")
            Dim Middat As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY26")
            Dim MidName As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("SLY2")
            Dim MidUSERNAME As String = dsSALARIES.Tables("SALARIES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المرتبات والاجور غير مرحلة", "المرتبات والاجور", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "المرتبات والاجور" Then
                row.Cells(0).Style.BackColor = Color.AntiqueWhite
                row.Cells(1).Style.BackColor = Color.AntiqueWhite
                row.Cells(2).Style.BackColor = Color.AntiqueWhite
                row.Cells(3).Style.BackColor = Color.AntiqueWhite
                row.Cells(4).Style.BackColor = Color.AntiqueWhite
                row.Cells(5).Style.BackColor = Color.AntiqueWhite
                row.Cells(6).Style.BackColor = Color.AntiqueWhite
            End If
        Next
        DataGrid.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "" Then
                row.Cells(0).Style.BackColor = Color.LightGray
                row.Cells(1).Style.BackColor = Color.LightGray
                row.Cells(2).Style.BackColor = Color.LightGray
                row.Cells(3).Style.BackColor = Color.LightGray
                row.Cells(4).Style.BackColor = Color.LightGray
                row.Cells(5).Style.BackColor = Color.LightGray
                row.Cells(6).Style.BackColor = Color.LightGray
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== القروض ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsLoans.Tables("Loans").Rows.Count - 1
            Dim MidNo As String = dsLoans.Tables("Loans").Rows(II).Item("lo")
            Dim MidNo1 As String = dsLoans.Tables("Loans").Rows(II).Item("lo17")
            Dim Middat As String = dsLoans.Tables("Loans").Rows(II).Item("lo2")
            Dim MidName As String = dsLoans.Tables("Loans").Rows(II).Item("lo5")
            Dim MidUSERNAME As String = dsLoans.Tables("Loans").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "القروض غير مرحلة", "القروض", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "الموظفين" Then
                row.Cells(0).Style.BackColor = Color.Bisque
                row.Cells(1).Style.BackColor = Color.Bisque
                row.Cells(2).Style.BackColor = Color.Bisque
                row.Cells(3).Style.BackColor = Color.Bisque
                row.Cells(4).Style.BackColor = Color.Bisque
                row.Cells(5).Style.BackColor = Color.Bisque
                row.Cells(6).Style.BackColor = Color.Bisque
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== تسديدات العملاء ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsLoansPa.Tables("LoansPa").Rows.Count - 1
            Dim MidNo As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa1")
            Dim MidNo1 As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa5")
            Dim Middat As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa3")
            Dim MidName As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("Loa11")
            Dim MidUSERNAME As String = dsLoansPa.Tables("LoansPa").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "تسديدات العملاء غير مرحلة", "تسديدات العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "الموظفين" Then
                row.Cells(0).Style.BackColor = Color.Beige
                row.Cells(1).Style.BackColor = Color.Beige
                row.Cells(2).Style.BackColor = Color.Beige
                row.Cells(3).Style.BackColor = Color.Beige
                row.Cells(4).Style.BackColor = Color.Beige
                row.Cells(5).Style.BackColor = Color.Beige
                row.Cells(6).Style.BackColor = Color.Beige
            End If
        Next
        Consum.Close()
    End Sub

    Public Sub SELECT_MOVES3(ByVal DataGrid As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim f As New FinaBalances1
        Dim A_Name, A_data, A_No, A_No1, A_USERNAME As String
        Dim strsql As New SqlCommand("", Consum)

        Dim strsqCASH1 As New SqlCommand("", Consum)

        Dim strsqBANK1 As New SqlCommand("", Consum)

        Dim strsqEMPSOL1 As New SqlCommand("", Consum)

        Dim strsqChecks1 As New SqlCommand("", Consum)

        Dim strsqDeposits1 As New SqlCommand("", Consum)

        Dim strsqPTRANSACTION1 As New SqlCommand("", Consum)


        Dim strsqBUYS1 As New SqlCommand("", Consum)

        Dim strsqSALES1 As New SqlCommand("", Consum)

        Dim strsqTodaySales1 As New SqlCommand("", Consum)

        Dim strsqASTRGA_ASTRDA1 As New SqlCommand("", Consum)

        Dim strsqCABLES1 As New SqlCommand("", Consum)

        Dim strsqCABLESCOEMPLOYEES1 As New SqlCommand("", Consum)

        Dim strsqInvoice1 As New SqlCommand("", Consum)

        Dim strsqPETRO1 As New SqlCommand("", Consum)

        Dim strsqMYCOSTS1 As New SqlCommand("", Consum)

        Dim strsqSuppliers1 As New SqlCommand("", Consum)

        Dim strsqSALARIES1 As New SqlCommand("", Consum)

        Dim strsqLoans1 As New SqlCommand("", Consum)

        Dim strsqLoansPa1 As New SqlCommand("", Consum)


        strsql.CommandText = "SELECT MOV2, MOV11, MOV12, MOV3, MOV4, USERNAME FROM MOVES   WHERE   CUser='" & CUser & "' and Year(MOV3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and MOV12 ='" & False & "'"
        strsqCASH1.CommandText = "SELECT CSH1, CSH4, CSH2, CSH11, USERNAME  FROM CASHIER WHERE  CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH14 ='" & False & "'"
        strsqBANK1.CommandText = "SELECT EBNK1, EBNK13, EBNK3, EBNK9, USERNAME  FROM BANKJO WHERE CUser='" & CUser & "' and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and EBNK14 ='" & False & "'"
        strsqEMPSOL1.CommandText = "SELECT CSH1, CSH2, CSH17, CSH11, USERNAME  FROM EMPSOLF WHERE CUser='" & CUser & "' and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CSH16 ='" & False & "'"
        strsqChecks1.CommandText = "SELECT IDCH, CH3, CH16, CH9, USERNAME  FROM Checks WHERE CUser='" & CUser & "' and Year(CH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CH18 ='" & False & "'"
        strsqDeposits1.CommandText = "SELECT TBNK1, TBNK18, TBNK3, TBNK20, USERNAME  FROM Deposits WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK17 ='" & False & "'"

        strsqPTRANSACTION1.CommandText = "SELECT TBNK1, TBNK11, TBNK3, TBNK22, USERNAME  FROM PTRANSACTION WHERE CUser='" & CUser & "' and Year(TBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and TBNK13 ='" & False & "'"

        strsqBUYS1.CommandText = "SELECT BUY2, BUY18, BUY3, BUY24, USERNAME  FROM BUYS WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and BUY19 ='" & False & "'"
        strsqSALES1.CommandText = "SELECT SLS2, SLS9, SLS3, SLS5, USERNAME  FROM SALES WHERE CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and SLS30 ='" & False & "'"
        strsqTodaySales1.CommandText = "SELECT ID, TS9, DataTS, BarCod, USERNAME  FROM TodaySales WHERE CUser='" & CUser & "' and Year(DataTS) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk  ='" & False & "'"
        strsqASTRGA_ASTRDA1.CommandText = "SELECT ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME  FROM ASTRGA_ASTRDA WHERE CUser='" & CUser & "' and Year(DataD10) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and Chk  ='" & False & "'"
        strsqCABLES1.CommandText = "SELECT IDCAB, CAB3, CAB9, CAB21, USERNAME  FROM CABLES WHERE CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and CAB24 ='" & False & "'"
        strsqCABLESCOEMPLOYEES1.CommandText = "SELECT CEMP3, CEMP2, CEMP25, CEMP31, USERNAME  FROM CABLESCOEMPLOYEES WHERE CUser='" & CUser & "' and Year(CEMP2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CEMP30 ='" & False & "'"

        strsqInvoice1.CommandText = "SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM Invoice WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO22 ='" & False & "'"

        strsqPETRO1.CommandText = "SELECT PTRO1, PTRO5, PTRO23, PTRO10, USERNAME  FROM PETRO WHERE  CUser='" & CUser & "' and Year(PTRO5) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and PTRO22 ='" & False & "'"

        strsqMYCOSTS1.CommandText = "SELECT CST1, CST7, CST10, CST13, USERNAME  FROM MYCOSTS WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CST21 ='" & False & "'"

        strsqSuppliers1.CommandText = " SELECT IDCAB, CAB3, CAB9, CAB18, USERNAME  FROM Suppliers1 WHERE  CUser='" & CUser & "' and Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and CAB17 ='" & False & "'"

        strsqSALARIES1.CommandText = "SELECT SLY1, SLY2, SLY25, SLY26, USERNAME  FROM SALARIES WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and SLY28 ='" & False & "'"

        strsqLoans1.CommandText = "SELECT lo, lo17, lo2, lo5, USERNAME  FROM Loans WHERE   CUser='" & CUser & "' and Year(lo2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'  and lo18 ='" & False & "'"

        strsqLoansPa1.CommandText = "SELECT Loa1, Loa5, Loa3, Loa11, USERNAME  FROM LoansPa WHERE  CUser='" & CUser & "'  and loa16 ='" & False & "' and Loa6 >'" & 0 & "'"



        Dim ds1 As New DataSet
        Dim dsCASH1 As New DataSet

        Dim dsBANK1 As New DataSet

        Dim dsEMPSOL1 As New DataSet

        Dim dsChecks1 As New DataSet

        Dim dsDeposits1 As New DataSet

        Dim dsPTRANSACTION1 As New DataSet


        Dim dsBUYS1 As New DataSet

        Dim dsSALES1 As New DataSet

        Dim dsTodaySales1 As New DataSet

        Dim dsTodaySales_barcoodd1 As New DataSet

        Dim dsASTRGA_ASTRDA1 As New DataSet

        Dim dsCABLES1 As New DataSet

        Dim dsCABLESCOEMPLOYEES1 As New DataSet

        Dim dsInvoice1 As New DataSet

        Dim dsPETRO1 As New DataSet

        Dim dsMYCOSTS1 As New DataSet
        Dim dsSuppliers1 As New DataSet

        Dim dsSALARIES1 As New DataSet


        Dim dsLoans1 As New DataSet

        Dim dsLoansPa1 As New DataSet

        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql)

        Dim AdpCASH1 As New SqlClient.SqlDataAdapter(strsqCASH1)

        Dim AdpBANK1 As New SqlClient.SqlDataAdapter(strsqBANK1)

        Dim AdpEMPSOL1 As New SqlClient.SqlDataAdapter(strsqEMPSOL1)

        Dim AdpChecks1 As New SqlClient.SqlDataAdapter(strsqChecks1)

        Dim AdpDeposits1 As New SqlClient.SqlDataAdapter(strsqDeposits1)


        Dim AdpPTRANSACTION1 As New SqlClient.SqlDataAdapter(strsqPTRANSACTION1)


        Dim AdpBUYS1 As New SqlClient.SqlDataAdapter(strsqBUYS1)

        Dim AdpSALES1 As New SqlClient.SqlDataAdapter(strsqSALES1)

        Dim AdpTodaySales1 As New SqlClient.SqlDataAdapter(strsqTodaySales1)


        Dim AdpASTRGA_ASTRDA1 As New SqlClient.SqlDataAdapter(strsqASTRGA_ASTRDA1)

        Dim AdpCABLES1 As New SqlClient.SqlDataAdapter(strsqCABLES1)

        Dim AdpCABLESCOEMPLOYEES1 As New SqlClient.SqlDataAdapter(strsqCABLESCOEMPLOYEES1)

        Dim AdpInvoice1 As New SqlClient.SqlDataAdapter(strsqInvoice1)

        Dim AdpPETRO1 As New SqlClient.SqlDataAdapter(strsqPETRO1)

        Dim AdpMYCOSTS1 As New SqlClient.SqlDataAdapter(strsqMYCOSTS1)
        Dim AdpSuppliers1 As New SqlClient.SqlDataAdapter(strsqSuppliers1)

        Dim AdpSALARIES1 As New SqlClient.SqlDataAdapter(strsqSALARIES1)


        Dim AdpLoans1 As New SqlClient.SqlDataAdapter(strsqLoans1)

        Dim AdpLoansPa1 As New SqlClient.SqlDataAdapter(strsqLoansPa1)




        On Error Resume Next
        ds1.Clear()

        dsCASH1.Clear()

        dsBANK1.Clear()

        dsEMPSOL1.Clear()

        dsChecks1.Clear()

        dsDeposits1.Clear()

        dsPTRANSACTION1.Clear()

        dsBUYS1.Clear()

        dsSALES1.Clear()

        dsTodaySales1.Clear()


        dsASTRGA_ASTRDA1.Clear()
        dsSALES1.Clear()


        dsCABLESCOEMPLOYEES1.Clear()

        dsInvoice1.Clear()

        dsPETRO1.Clear()

        dsMYCOSTS1.Clear()
        dsSuppliers1.Clear()

        dsSALARIES1.Clear()

        dsLoans1.Clear()

        dsLoansPa1.Clear()

        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        Adp1.Fill(ds1, "MOVES")

        AdpCASH1.Fill(dsCASH1, "CASHIER")

        AdpBANK1.Fill(dsBANK1, "BANKJO")

        AdpEMPSOL1.Fill(dsEMPSOL1, "EMPSOLF")

        AdpChecks1.Fill(dsChecks1, "Checks")

        AdpDeposits1.Fill(dsDeposits1, "Deposits")

        AdpPTRANSACTION1.Fill(dsPTRANSACTION1, "PTRANSACTION")


        AdpBUYS1.Fill(dsBUYS1, "BUYS")

        AdpSALES1.Fill(dsSALES1, "SALES")

        AdpTodaySales1.Fill(dsTodaySales1, "TodaySales")


        AdpASTRGA_ASTRDA1.Fill(dsASTRGA_ASTRDA1, "ASTRGA_ASTRDA")

        AdpCABLES1.Fill(dsCABLES1, "CABLES")

        AdpCABLESCOEMPLOYEES1.Fill(dsCABLESCOEMPLOYEES1, "CABLESCOEMPLOYEES")

        AdpInvoice1.Fill(dsInvoice1, "Invoice")

        AdpPETRO1.Fill(dsPETRO1, "PETRO")

        AdpMYCOSTS1.Fill(dsMYCOSTS1, "MYCOSTS")
        AdpSuppliers1.Fill(dsSuppliers1, "Suppliers1")

        AdpSALARIES1.Fill(dsSALARIES1, "SALARIES")

        AdpLoans1.Fill(dsLoans1, "Loans")

        AdpLoansPa1.Fill(dsLoansPa1, "LoansPa")

        Consum.Close()
        'Dim fn As Font = New Font(f.DataGridView6.DefaultCellStyle.Font.Name, f.DataGridView6.DefaultCellStyle.Font.Size, FontStyle.Bold)
        DataGrid.Rows.Add("=== القيود المحاسبة ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To ds1.Tables("MOVES").Rows.Count - 1
            Dim MidNo As String = ds1.Tables("MOVES").Rows(II).Item("MOV2")
            Dim MidNo1 As String = ds1.Tables("MOVES").Rows(II).Item("MOV11")
            Dim Middat As String = ds1.Tables("MOVES").Rows(II).Item("MOV3")
            Dim MidName As String = ds1.Tables("MOVES").Rows(II).Item("MOV4")
            Dim MidUSERNAME As String = ds1.Tables("MOVES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "قيود غير مراجعة", "القيود المحاسبة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الصندوق ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsCASH1.Tables("CASHIER").Rows.Count - 1
            Dim MidNo As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH4")
            Dim Middat As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH2")
            Dim MidName As String = dsCASH1.Tables("CASHIER").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsCASH1.Tables("CASHIER").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الصندوق غير مراجعة", "الصندوق", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الصندوق" Then
                    row.Cells(0).Style.BackColor = Color.Wheat
                    row.Cells(1).Style.BackColor = Color.Wheat
                    row.Cells(2).Style.BackColor = Color.Wheat
                    row.Cells(3).Style.BackColor = Color.Wheat
                    row.Cells(4).Style.BackColor = Color.Wheat
                    row.Cells(5).Style.BackColor = Color.Wheat
                    row.Cells(6).Style.BackColor = Color.Wheat
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("==== البنك =====", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsBANK1.Tables("BANKJO").Rows.Count - 1
            Dim MidNo As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK1")
            Dim MidNo1 As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK13")
            Dim Middat As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK3")
            Dim MidName As String = dsBANK1.Tables("BANKJO").Rows(II).Item("EBNK9")
            Dim MidUSERNAME As String = dsBANK1.Tables("BANKJO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "البنك غير مراجعة", "البنك", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "البنك" Then
                    row.Cells(0).Style.BackColor = Color.PeachPuff
                    row.Cells(1).Style.BackColor = Color.PeachPuff
                    row.Cells(2).Style.BackColor = Color.PeachPuff
                    row.Cells(3).Style.BackColor = Color.PeachPuff
                    row.Cells(4).Style.BackColor = Color.PeachPuff
                    row.Cells(5).Style.BackColor = Color.PeachPuff
                    row.Cells(6).Style.BackColor = Color.PeachPuff
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الموظفين ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsEMPSOL1.Tables("EMPSOLF").Rows.Count - 1
            Dim MidNo As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH1")
            Dim MidNo1 As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH17")
            Dim Middat As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH2")
            Dim MidName As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("CSH11")
            Dim MidUSERNAME As String = dsEMPSOL1.Tables("EMPSOLF").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموظفين غير مراجعة", "الموظفين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموظفين" Then
                    row.Cells(0).Style.BackColor = Color.Bisque
                    row.Cells(1).Style.BackColor = Color.Bisque
                    row.Cells(2).Style.BackColor = Color.Bisque
                    row.Cells(3).Style.BackColor = Color.Bisque
                    row.Cells(4).Style.BackColor = Color.Bisque
                    row.Cells(5).Style.BackColor = Color.Bisque
                    row.Cells(6).Style.BackColor = Color.Bisque
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الشيكات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsChecks1.Tables("Checks").Rows.Count - 1
            Dim MidNo As String = dsChecks1.Tables("Checks").Rows(II).Item("IDCH")
            Dim MidNo1 As String = dsChecks1.Tables("Checks").Rows(II).Item("CH16")
            Dim Middat As String = dsChecks1.Tables("Checks").Rows(II).Item("CH3")
            Dim MidName As String = dsChecks1.Tables("Checks").Rows(II).Item("CH9")
            Dim MidUSERNAME As String = dsChecks1.Tables("Checks").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الشيكات غير مراجعة", "الشيكات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الشيكات" Then
                    row.Cells(0).Style.BackColor = Color.PapayaWhip
                    row.Cells(1).Style.BackColor = Color.PapayaWhip
                    row.Cells(2).Style.BackColor = Color.PapayaWhip
                    row.Cells(3).Style.BackColor = Color.PapayaWhip
                    row.Cells(4).Style.BackColor = Color.PapayaWhip
                    row.Cells(5).Style.BackColor = Color.PapayaWhip
                    row.Cells(6).Style.BackColor = Color.PapayaWhip
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الاسهم ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsDeposits1.Tables("Deposits").Rows.Count - 1
            Dim MidNo As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK18")
            Dim Middat As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK3")
            Dim MidName As String = dsDeposits1.Tables("Deposits").Rows(II).Item("TBNK20")
            Dim MidUSERNAME As String = dsDeposits1.Tables("Deposits").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الاسهم غير مراجعة", "الاسهم", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الاسهم" Then
                    row.Cells(0).Style.BackColor = Color.FloralWhite
                    row.Cells(1).Style.BackColor = Color.FloralWhite
                    row.Cells(2).Style.BackColor = Color.FloralWhite
                    row.Cells(3).Style.BackColor = Color.FloralWhite
                    row.Cells(4).Style.BackColor = Color.FloralWhite
                    row.Cells(5).Style.BackColor = Color.FloralWhite
                    row.Cells(6).Style.BackColor = Color.FloralWhite
                End If
            Next
        Next

        '===================================================================================================
        DataGrid.Rows.Add("=== حركات السحب والايداعات النقدية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsPTRANSACTION1.Tables("PTRANSACTION").Rows.Count - 1
            Dim MidNo As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK1")
            Dim MidNo1 As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK11")
            Dim Middat As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK3")
            Dim MidName As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("TBNK22")
            Dim MidUSERNAME As String = dsPTRANSACTION1.Tables("PTRANSACTION").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "حركات السحب والايداعات النقدية غير مراجعة", "حركات السحب والايداعات النقدية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "حركات السحب والايداعات النقدية" Then
                    row.Cells(0).Style.BackColor = Color.FloralWhite
                    row.Cells(1).Style.BackColor = Color.FloralWhite
                    row.Cells(2).Style.BackColor = Color.FloralWhite
                    row.Cells(3).Style.BackColor = Color.FloralWhite
                    row.Cells(4).Style.BackColor = Color.FloralWhite
                    row.Cells(5).Style.BackColor = Color.FloralWhite
                    row.Cells(6).Style.BackColor = Color.FloralWhite
                End If
            Next
        Next
        '===================================================================================================

        DataGrid.Rows.Add("=== المبيعات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)


        For II As Integer = 0 To dsSALES1.Tables("SALES").Rows.Count - 1
            Dim MidNo As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS2")
            Dim MidNo1 As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS19")
            Dim Middat As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS3")
            Dim MidName As String = dsSALES1.Tables("SALES").Rows(II).Item("SLS5")
            Dim MidUSERNAME As String = dsSALES1.Tables("SALES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مراجعة", "المبيعات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المبيعات" Then
                    row.Cells(0).Style.BackColor = Color.MediumAquamarine
                    row.Cells(1).Style.BackColor = Color.MediumAquamarine
                    row.Cells(2).Style.BackColor = Color.MediumAquamarine
                    row.Cells(3).Style.BackColor = Color.MediumAquamarine
                    row.Cells(4).Style.BackColor = Color.MediumAquamarine
                    row.Cells(5).Style.BackColor = Color.MediumAquamarine
                    row.Cells(6).Style.BackColor = Color.MediumAquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("===المبيعات اليومية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsTodaySales1.Tables("TodaySales").Rows.Count - 1
            Dim MidNo As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("ID")
            Dim MidNo1 As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("TS9")
            Dim Middat As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("DataTS")
            Dim MidName As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("BarCod")
            Dim MidUSERNAME As String = dsTodaySales1.Tables("TodaySales").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مراجعة", "المببعات_اليومية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المببعات_اليومية" Then
                    row.Cells(0).Style.BackColor = Color.MediumAquamarine
                    row.Cells(1).Style.BackColor = Color.MediumAquamarine
                    row.Cells(2).Style.BackColor = Color.Red
                    row.Cells(3).Style.BackColor = Color.MediumAquamarine
                    row.Cells(4).Style.BackColor = Color.MediumAquamarine
                    row.Cells(5).Style.BackColor = Color.MediumAquamarine
                    row.Cells(6).Style.BackColor = Color.MediumAquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("===المبيعات المسترجعة===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows.Count - 1
            Dim MidNo As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("ID")
            Dim MidNo1 As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("NumFatorh12")
            Dim Middat As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("DataD10")
            Dim MidName As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("Barcodd1")
            Dim MidUSERNAME As String = dsASTRGA_ASTRDA1.Tables("ASTRGA_ASTRDA").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المبيعات غير مراجعة", "المبيعات المسترجعة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المبيعات المسترجعة" Then
                    row.Cells(0).Style.BackColor = Color.MediumAquamarine
                    row.Cells(1).Style.BackColor = Color.MediumAquamarine
                    row.Cells(2).Style.BackColor = Color.Red
                    row.Cells(3).Style.BackColor = Color.MediumAquamarine
                    row.Cells(4).Style.BackColor = Color.MediumAquamarine
                    row.Cells(5).Style.BackColor = Color.MediumAquamarine
                    row.Cells(6).Style.BackColor = Color.MediumAquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المشتريات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsBUYS1.Tables("BUYS").Rows.Count - 1
            Dim MidNo As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY2")
            Dim MidNo1 As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY18")
            Dim Middat As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY3")
            Dim MidName As String = dsBUYS1.Tables("BUYS").Rows(II).Item("BUY24")
            Dim MidUSERNAME As String = dsBUYS1.Tables("BUYS").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المشتريات غير مراجعة", "المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المشتريات" Then
                    row.Cells(0).Style.BackColor = Color.Aquamarine
                    row.Cells(1).Style.BackColor = Color.Aquamarine
                    row.Cells(2).Style.BackColor = Color.Aquamarine
                    row.Cells(3).Style.BackColor = Color.Aquamarine
                    row.Cells(4).Style.BackColor = Color.Aquamarine
                    row.Cells(5).Style.BackColor = Color.Aquamarine
                    row.Cells(6).Style.BackColor = Color.Aquamarine
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== العملاء ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsCABLES1.Tables("CABLES").Rows.Count - 1
            Dim MidNo As String = dsCABLES1.Tables("CABLES").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsCABLES1.Tables("CABLES").Rows(II).Item("CAB21")
            Dim Middat As String = dsCABLES1.Tables("CABLES").Rows(II).Item("CAB3")
            Dim MidName As String = dsCABLES1.Tables("CABLES").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsCABLES1.Tables("CABLES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "العملاء غير مرحلة", "العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "العملاء" Then
                    row.Cells(0).Style.BackColor = Color.Tan
                    row.Cells(1).Style.BackColor = Color.Tan
                    row.Cells(2).Style.BackColor = Color.Tan
                    row.Cells(3).Style.BackColor = Color.Tan
                    row.Cells(4).Style.BackColor = Color.Tan
                    row.Cells(5).Style.BackColor = Color.Tan
                    row.Cells(6).Style.BackColor = Color.Tan
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== مصاريف المشتريات ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)


        For II As Integer = 0 To dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows.Count - 1
            Dim MidNo As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP3")
            Dim MidNo1 As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP31")
            Dim Middat As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP2")
            Dim MidName As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("CEMP25")
            Dim MidUSERNAME As String = dsCABLESCOEMPLOYEES1.Tables("CABLESCOEMPLOYEES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "مصاريف المشتريات غير مراجعة", "مصاريف المشتريات", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "مصاريف المشتريات" Then
                    row.Cells(0).Style.BackColor = Color.NavajoWhite
                    row.Cells(1).Style.BackColor = Color.NavajoWhite
                    row.Cells(2).Style.BackColor = Color.NavajoWhite
                    row.Cells(3).Style.BackColor = Color.NavajoWhite
                    row.Cells(4).Style.BackColor = Color.NavajoWhite
                    row.Cells(5).Style.BackColor = Color.NavajoWhite
                    row.Cells(6).Style.BackColor = Color.NavajoWhite
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== فاتورة نقل تفصيلية ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsInvoice1.Tables("Invoice").Rows.Count - 1
            Dim MidNo As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO23")
            Dim Middat As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO5")
            Dim MidName As String = dsInvoice1.Tables("Invoice").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsInvoice1.Tables("Invoice").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل تفصيلية غير مراجعة", "فاتورة نقل تفصيلية", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "فاتورة نقل تفصيلية" Then
                    row.Cells(0).Style.BackColor = Color.OldLace
                    row.Cells(1).Style.BackColor = Color.OldLace
                    row.Cells(2).Style.BackColor = Color.OldLace
                    row.Cells(3).Style.BackColor = Color.OldLace
                    row.Cells(4).Style.BackColor = Color.OldLace
                    row.Cells(5).Style.BackColor = Color.OldLace
                    row.Cells(6).Style.BackColor = Color.OldLace
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== فاتورة نقل === ", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsPETRO1.Tables("PETRO").Rows.Count - 1
            Dim MidNo As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO1")
            Dim MidNo1 As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO23")
            Dim Middat As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO5")
            Dim MidName As String = dsPETRO1.Tables("PETRO").Rows(II).Item("PTRO10")
            Dim MidUSERNAME As String = dsPETRO1.Tables("PETRO").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "فاتورة نقل غير مراجعة", "فاتورة نقل", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "فاتورة نقل" Then
                    row.Cells(0).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(1).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(2).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(3).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(4).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(5).Style.BackColor = Color.MediumSlateBlue
                    row.Cells(6).Style.BackColor = Color.MediumSlateBlue
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المصاريف العامة===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsMYCOSTS1.Tables("MYCOSTS").Rows.Count - 1
            Dim MidNo As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST1")
            Dim MidNo1 As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST13")
            Dim Middat As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST7")
            Dim MidName As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("CST10")
            Dim MidUSERNAME As String = dsMYCOSTS1.Tables("MYCOSTS").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المصاريف العامة غير مراجعة", "المصاريف العامة", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المصاريف العامة" Then
                    row.Cells(0).Style.BackColor = Color.Moccasin
                    row.Cells(1).Style.BackColor = Color.Moccasin
                    row.Cells(2).Style.BackColor = Color.Moccasin
                    row.Cells(3).Style.BackColor = Color.Moccasin
                    row.Cells(4).Style.BackColor = Color.Moccasin
                    row.Cells(5).Style.BackColor = Color.Moccasin
                    row.Cells(6).Style.BackColor = Color.Moccasin
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== الموردين ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)

        For II As Integer = 0 To dsSuppliers1.Tables("Suppliers1").Rows.Count - 1
            Dim MidNo As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("IDCAB")
            Dim MidNo1 As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("CAB21")
            Dim Middat As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("CAB3")
            Dim MidName As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("CAB9")
            Dim MidUSERNAME As String = dsSuppliers1.Tables("Suppliers1").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "الموردين غير مراجعة", "الموردين", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموردين" Then
                    row.Cells(0).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(1).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(2).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(3).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(4).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(5).Style.BackColor = Color.BlanchedAlmond
                    row.Cells(6).Style.BackColor = Color.BlanchedAlmond
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== المرتبات والاجور ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsSALARIES1.Tables("SALARIES").Rows.Count - 1
            Dim MidNo As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY1")
            Dim MidNo1 As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY25")
            Dim Middat As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY26")
            Dim MidName As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("SLY2")
            Dim MidUSERNAME As String = dsSALARIES1.Tables("SALARIES").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "المرتبات والاجور غير مراجعة", "المرتبات والاجور", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "المرتبات والاجور" Then
                    row.Cells(0).Style.BackColor = Color.AntiqueWhite
                    row.Cells(1).Style.BackColor = Color.AntiqueWhite
                    row.Cells(2).Style.BackColor = Color.AntiqueWhite
                    row.Cells(3).Style.BackColor = Color.AntiqueWhite
                    row.Cells(4).Style.BackColor = Color.AntiqueWhite
                    row.Cells(5).Style.BackColor = Color.AntiqueWhite
                    row.Cells(6).Style.BackColor = Color.AntiqueWhite
                End If
            Next
        Next
        DataGrid.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For Each row As DataGridViewRow In DataGrid.Rows
            If row.Cells("Type1").Value = "" Then
                row.Cells(0).Style.BackColor = Color.LightGray
                row.Cells(1).Style.BackColor = Color.LightGray
                row.Cells(2).Style.BackColor = Color.LightGray
                row.Cells(3).Style.BackColor = Color.LightGray
                row.Cells(4).Style.BackColor = Color.LightGray
                row.Cells(5).Style.BackColor = Color.LightGray
                row.Cells(6).Style.BackColor = Color.LightGray
            End If
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== القروض ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsLoans1.Tables("Loans").Rows.Count - 1
            Dim MidNo As String = dsLoans1.Tables("Loans").Rows(II).Item("lo")
            Dim MidNo1 As String = dsLoans1.Tables("Loans").Rows(II).Item("lo17")
            Dim Middat As String = dsLoans1.Tables("Loans").Rows(II).Item("lo2")
            Dim MidName As String = dsLoans1.Tables("Loans").Rows(II).Item("lo5")
            Dim MidUSERNAME As String = dsLoans1.Tables("Loans").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "القروض غير مراجعة", "القروض", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموظفين" Then
                    row.Cells(0).Style.BackColor = Color.Bisque
                    row.Cells(1).Style.BackColor = Color.Bisque
                    row.Cells(2).Style.BackColor = Color.Bisque
                    row.Cells(3).Style.BackColor = Color.Bisque
                    row.Cells(4).Style.BackColor = Color.Bisque
                    row.Cells(5).Style.BackColor = Color.Bisque
                    row.Cells(6).Style.BackColor = Color.Bisque
                End If
            Next
        Next
        '===================================================================================================
        DataGrid.Rows.Add("=== تسديدات العملاء ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For II As Integer = 0 To dsLoansPa1.Tables("LoansPa").Rows.Count - 1
            Dim MidNo As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa1")
            Dim MidNo1 As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa5")
            Dim Middat As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa3")
            Dim MidName As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("Loa11")
            Dim MidUSERNAME As String = dsLoansPa1.Tables("LoansPa").Rows(II).Item("USERNAME")
            Dim row1 As String() = {"", MidNo, MidNo1, Middat, "تسديدات العملاء غير مراجعة", "تسديدات العملاء", MidUSERNAME, ""}
            DataGrid.Rows.Add(row1)
            For Each row As DataGridViewRow In DataGrid.Rows
                If row.Cells("Type1").Value = "الموظفين" Then
                    row.Cells(0).Style.BackColor = Color.Beige
                    row.Cells(1).Style.BackColor = Color.Beige
                    row.Cells(2).Style.BackColor = Color.Beige
                    row.Cells(3).Style.BackColor = Color.Beige
                    row.Cells(4).Style.BackColor = Color.Beige
                    row.Cells(5).Style.BackColor = Color.Beige
                    row.Cells(6).Style.BackColor = Color.Beige
                End If
            Next
        Next

        Consum.Close()

    End Sub

End Module
