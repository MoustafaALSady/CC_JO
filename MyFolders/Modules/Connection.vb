Imports System.Data.SqlClient
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

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
    Public DataAdapterUsers As SqlDataAdapter
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
        Dim mDateTime As DateTime
        Using Consum As New SqlConnection(constring)
            Try
                Dim comm As New SqlCommand("Select GetDate()", Consum)
                If Consum.State = ConnectionState.Closed Then
                    Consum.Open()
                End If
                mDateTime = comm.ExecuteScalar()
            Catch ex As Exception
                'MsgBox("حدث خطاء ما في التاريخ", MsgBoxStyle.Information, "معلومات")
            End Try
        End Using
        Return mDateTime
    End Function

    Public Sub UPDATE_Users(ByVal LoginName As String, ByVal TimeEnter As Date, ByVal MacAddress As String)
        Using connection As New SqlConnection(constring1)
            Try
                Dim cmd As New SqlCommand("Update Users SET   LoginName = @LoginName,TimeEnter = @TimeEnter,MacAddress = @MacAddress  WHERE USERNAME = '" & USERNAME & " '", ConUsers)
                cmd.Parameters.Clear()
                cmd.Parameters.AddWithValue("@LoginName", LoginName)
                cmd.Parameters.AddWithValue("@TimeEnter", TimeEnter)
                cmd.Parameters.AddWithValue("@MacAddress", MacAddress)
                ConUsers.Open()
                cmd.ExecuteNonQuery()
                ConUsers.Close()
            Catch ex As Exception
                ' Log the error
            End Try
        End Using
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
        Using connection As New SqlConnection(constring1)
            Try
                Dim command As New SqlCommand("UPDATE Auditorsnotes SET AN6 = @AN6 WHERE AN = @AN", connection)
                command.Parameters.AddWithValue("@AN6", ACONET3.Trim())
                command.Parameters.AddWithValue("@AN", AN)
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' Log the error
            End Try
        End Using
    End Sub

    Public Sub Insert_Actions(ByVal result As String, ByVal Opr_T As String, ByVal form_N As String)
        Using connection As New SqlConnection(constring1)
            Try
                Dim command As New SqlCommand("INSERT INTO Operationsuser (Op2, Op3, Op4, Op5, Op6, Op7, Op8) VALUES (@Op2, @Op3, @Op4, @Op5, @Op6, @Op7, @Op8)", connection)
                command.Parameters.AddWithValue("@Op2", result)
                command.Parameters.AddWithValue("@Op3", Opr_T)
                command.Parameters.AddWithValue("@Op4", ServerDateTime().ToString("yyyy-MM-dd"))
                command.Parameters.AddWithValue("@Op5", form_N)
                command.Parameters.AddWithValue("@Op6", Realname)
                command.Parameters.AddWithValue("@Op7", AssociationName)
                command.Parameters.AddWithValue("@Op8", ServerDateTime().ToString("hh:mm:ss tt"))
                connection.Open()
                command.ExecuteNonQuery()
            Catch ex As Exception
                ' Log the error
            End Try
        End Using
    End Sub

    Public Sub Insert_FiscalYear(ByVal result As String, ByVal start_YE As Date, ByVal end_YE As Date, ByVal ServerstartYear As Date, ByVal Ye1 As Button)
        Using connection As New SqlConnection(constring)
            Try
                Dim command As New SqlCommand("INSERT INTO FiscalYear (Year1, Year2, Year3, Year4, Ye1) VALUES (@Year1, @Year2, @Year3, @Year4, @Ye1)", connection)
                command.Parameters.AddWithValue("@Year1", result)
                command.Parameters.AddWithValue("@Year2", start_YE)
                command.Parameters.AddWithValue("@Year3", end_YE)
                command.Parameters.AddWithValue("@Year4", ServerstartYear)
                command.Parameters.AddWithValue("@Ye1", Ye1)
                connection.Open()
                command.ExecuteNonQuery()
                MsgBox("تم اضافة السنة المحاسبية", MsgBoxStyle.Information, "معلومات")
            Catch ex As Exception
                ' Log the error
            End Try
        End Using
    End Sub

    'input array Is longer than number Of columns In this table
    Public Sub SELECT_MOVES1(ByVal DataGrid As GridControl)
        Try
            ' Define categories with their properties
            Dim categories As New List(Of Category) From {
        New Category With {
            .TableName = "MOVES",
            .SelectColumns = "MOV2 AS ID, MOV11 AS Number, MOV3 AS Date, MOV4 AS Name, USERNAME",
            .DateColumn = "MOV3",
            .Condition = "MOV12 = 'False'",
            .Description = "قيود غير مراجعة",
            .TypeName = "القيود المحاسبة"
        },
        New Category With {
            .TableName = "CASHIER",
            .SelectColumns = "CSH1 AS ID, CSH4 AS Number, CSH2 AS Date, CSH11 AS Name, USERNAME",
            .DateColumn = "CSH2",
            .Condition = "CSH17 = 'False'",
            .Description = "الصندوق غير مرحلة",
            .TypeName = "الصندوق"
        },
        New Category With {
            .TableName = "CASHIER",
            .SelectColumns = "CSH1 AS ID, CSH4 AS Number, CSH2 AS Date, CSH11 AS Name, USERNAME",
            .DateColumn = "CSH2",
            .Condition = "CSH14 = 'False'",
            .Description = "الصندوق غير مراجعة",
            .TypeName = "الصندوق"
        },
        New Category With {
            .TableName = "BANKJO",
            .SelectColumns = "EBNK1 AS ID, EBNK13 AS Number, EBNK3 AS Date, EBNK9 AS Name, USERNAME",
            .DateColumn = "EBNK3",
            .Condition = "EBNK15 = 'False'",
            .Description = "البنك غير مرحلة",
            .TypeName = "البنك"
        },
        New Category With {
            .TableName = "BANKJO",
            .SelectColumns = "EBNK1 AS ID, EBNK13 AS Number, EBNK3 AS Date, EBNK9 AS Name, USERNAME",
            .DateColumn = "EBNK3",
            .Condition = "EBNK14 = 'False'",
            .Description = "البنك غير مراجعة",
            .TypeName = "البنك"
        },
        New Category With {
            .TableName = "EMPSOLF",
            .SelectColumns = "CSH1 AS ID, CSH17 AS Number, CSH2 AS Date, CSH11 AS Name, USERNAME",
            .DateColumn = "CSH2",
            .Condition = "CSH13 = 'False'",
            .Description = "الموظفين غير مرحلة",
            .TypeName = "الموظفين"
        },
        New Category With {
            .TableName = "EMPSOLF",
            .SelectColumns = "CSH1 AS ID, CSH17 AS Number, CSH2 AS Date, CSH11 AS Name, USERNAME",
            .DateColumn = "CSH2",
            .Condition = "CSH16 = 'False'",
            .Description = "الموظفين غير مراجعة",
            .TypeName = "الموظفين"
        },
        New Category With {
            .TableName = "Checks",
            .SelectColumns = "IDCH AS ID, CH16 AS Number, CH3 AS Date, CH9 AS Name, USERNAME",
            .DateColumn = "CH2",
            .Condition = "CH19 = 'False'",
            .Description = "الشيكات غير مرحلة",
            .TypeName = "الشيكات"
        },
        New Category With {
            .TableName = "Checks",
            .SelectColumns = "IDCH AS ID, CH16 AS Number, CH3 AS Date, CH9 AS Name, USERNAME",
            .DateColumn = "CH2",
            .Condition = "CH18 = 'False'",
            .Description = "الشيكات غير مراجعة",
            .TypeName = "الشيكات"
        },
        New Category With {
            .TableName = "Deposits",
            .SelectColumns = "TBNK1 AS ID, TBNK18 AS Number, TBNK3 AS Date, TBNK20 AS Name, USERNAME",
            .DateColumn = "TBNK3",
            .Condition = "TBNK22 = 'False'",
            .Description = "الاسهم غير مرحلة",
            .TypeName = "الاسهم"
        },
        New Category With {
            .TableName = "Deposits",
            .SelectColumns = "TBNK1 AS ID, TBNK18 AS Number, TBNK3 AS Date, TBNK20 AS Name, USERNAME",
            .DateColumn = "TBNK3",
            .Condition = "TBNK17 = 'False'",
            .Description = "الاسهم غير مراجعة",
            .TypeName = "الاسهم"
        },
        New Category With {
            .TableName = "PTRANSACTION",
            .SelectColumns = "TBNK1 AS ID, TBNK11 AS Number, TBNK3 AS Date, TBNK22 AS Name, USERNAME",
            .DateColumn = "TBNK3",
            .Condition = "TBNK17 = 'False'",
            .Description = "حركات السحب والايداعات النقدية غير مرحلة",
            .TypeName = "حركات السحب والايداعات النقدية"
        },
        New Category With {
            .TableName = "PTRANSACTION",
            .SelectColumns = "TBNK1 AS ID, TBNK11 AS Number, TBNK3 AS Date, TBNK22 AS Name, USERNAME",
            .DateColumn = "TBNK3",
            .Condition = "TBNK13 = 'False'",
            .Description = "حركات السحب والايداعات النقدية غير مراجعة",
            .TypeName = "حركات السحب والايداعات النقدية"
        },
        New Category With {
            .TableName = "SALES",
            .SelectColumns = "SLS2 AS ID, SLS19 AS Number, SLS3 AS Date, SLS5 AS Name, USERNAME",
            .DateColumn = "SLS3",
            .Condition = "SLS17 = 'False'",
            .Description = "المبيعات غير مرحلة",
            .TypeName = "المبيعات"
        },
        New Category With {
            .TableName = "SALES",
            .SelectColumns = "SLS2 AS ID, SLS19 AS Number, SLS3 AS Date, SLS5 AS Name, USERNAME",
            .DateColumn = "SLS3",
            .Condition = "SLS30 = 'False'",
            .Description = "المبيعات غير مراجعة",
            .TypeName = "المبيعات"
        },
        New Category With {
            .TableName = "TodaySales",
            .SelectColumns = "ID AS ID, TS9 AS Number, DataTS AS Date, BarCod AS Name, USERNAME",
            .DateColumn = "DataTS",
            .Condition = "Chk1 = 'False'",
            .Description = "المبيعات غير مرحلة",
            .TypeName = "المببعات_اليومية"
        },
        New Category With {
            .TableName = "TodaySales",
            .SelectColumns = "ID AS ID, TS9 AS Number, DataTS AS Date, BarCod AS Name, USERNAME",
            .DateColumn = "DataTS",
            .Condition = "Chk = 'False'",
            .Description = "المبيعات غير مراجعة",
            .TypeName = "المببعات_اليومية"
        },
        New Category With {
            .TableName = "ASTRGA_ASTRDA",
            .SelectColumns = "ID AS ID, NumFatorh12 AS Number, DataD10 AS Date, Barcodd1 AS Name, USERNAME",
            .DateColumn = "DataD10",
            .Condition = "Chk1 = 'False'",
            .Description = "المبيعات غير مرحلة",
            .TypeName = "المبيعات المسترجعة"
        },
        New Category With {
            .TableName = "ASTRGA_ASTRDA",
            .SelectColumns = "ID AS ID, NumFatorh12 AS Number, DataD10 AS Date, Barcodd1 AS Name, USERNAME",
            .DateColumn = "DataD10",
            .Condition = "Chk = 'False'",
            .Description = "المبيعات غير مراجعة",
            .TypeName = "المبيعات المسترجعة"
        },
        New Category With {
            .TableName = "BUYS",
            .SelectColumns = "BUY2 AS ID, BUY18 AS Number, BUY3 AS Date, BUY24 AS Name, USERNAME",
            .DateColumn = "BUY3",
            .Condition = "BUY17 = 'False'",
            .Description = "المشتريات غير مرحلة",
            .TypeName = "المشتريات"
        },
        New Category With {
            .TableName = "BUYS",
            .SelectColumns = "BUY2 AS ID, BUY18 AS Number, BUY3 AS Date, BUY24 AS Name, USERNAME",
            .DateColumn = "BUY3",
            .Condition = "BUY19 = 'False'",
            .Description = "المشتريات غير مراجعة",
            .TypeName = "المشتريات"
        },
        New Category With {
            .TableName = "CABLES",
            .SelectColumns = "IDCAB AS ID, CAB21 AS Number, CAB3 AS Date, CAB9 AS Name, USERNAME",
            .DateColumn = "CAB3",
            .Condition = "CAB20 = 'False'",
            .Description = "العملاء غير مراجعة",
            .TypeName = "العملاء"
        },
        New Category With {
            .TableName = "CABLES",
            .SelectColumns = "IDCAB AS ID, CAB21 AS Number, CAB3 AS Date, CAB9 AS Name, USERNAME",
            .DateColumn = "CAB3",
            .Condition = "CAB24 = 'False'",
            .Description = "العملاء غير مرحلة",
            .TypeName = "العملاء"
        },
        New Category With {
            .TableName = "CABLESCOEMPLOYEES",
            .SelectColumns = "CEMP3 AS ID, CEMP31 AS Number, CEMP2 AS Date, CEMP25 AS Name, USERNAME",
            .DateColumn = "CEMP2",
            .Condition = "CEMP21 = 'False'",
            .Description = "مصاريف المشتريات غير مرحلة",
            .TypeName = "مصاريف المشتريات"
        },
        New Category With {
            .TableName = "CABLESCOEMPLOYEES",
            .SelectColumns = "CEMP3 AS ID, CEMP31 AS Number, CEMP2 AS Date, CEMP25 AS Name, USERNAME",
            .DateColumn = "CEMP2",
            .Condition = "CEMP30 = 'False'",
            .Description = "مصاريف المشتريات غير مراجعة",
            .TypeName = "مصاريف المشتريات"
        },
        New Category With {
            .TableName = "Invoice",
            .SelectColumns = "PTRO1 AS ID, PTRO23 AS Number, PTRO5 AS Date, PTRO10 AS Name, USERNAME",
            .DateColumn = "PTRO5",
            .Condition = "PTRO15 = 'False'",
            .Description = "فاتورة نقل تفصيلية غير مرحلة",
            .TypeName = "فاتورة نقل تفصيلية"
        },
        New Category With {
            .TableName = "Invoice",
            .SelectColumns = "PTRO1 AS ID, PTRO23 AS Number, PTRO5 AS Date, PTRO10 AS Name, USERNAME",
            .DateColumn = "PTRO5",
            .Condition = "PTRO22 = 'False'",
            .Description = "فاتورة نقل تفصيلية غير مراجعة",
            .TypeName = "فاتورة نقل تفصيلية"
        },
        New Category With {
            .TableName = "PETRO",
            .SelectColumns = "PTRO1 AS ID, PTRO23 AS Number, PTRO5 AS Date, PTRO10 AS Name, USERNAME",
            .DateColumn = "PTRO5",
            .Condition = "PTRO15 = 'False'",
            .Description = "فاتورة نقل غير مرحلة",
            .TypeName = "فاتورة نقل"
        },
        New Category With {
            .TableName = "PETRO",
            .SelectColumns = "PTRO1 AS ID, PTRO23 AS Number, PTRO5 AS Date, PTRO10 AS Name, USERNAME",
            .DateColumn = "PTRO5",
            .Condition = "PTRO22 = 'False'",
            .Description = "فاتورة نقل غير مراجعة",
            .TypeName = "فاتورة نقل"
        },
        New Category With {
            .TableName = "MYCOSTS",
            .SelectColumns = "CST1 AS ID, CST13 AS Number, CST7 AS Date, CST10 AS Name, USERNAME",
            .DateColumn = "CST7",
            .Condition = "CST5 = 'False'",
            .Description = "المصاريف العامة غير مرحلة",
            .TypeName = "المصاريف العامة"
        },
        New Category With {
            .TableName = "MYCOSTS",
            .SelectColumns = "CST1 AS ID, CST13 AS Number, CST7 AS Date, CST10 AS Name, USERNAME",
            .DateColumn = "CST7",
            .Condition = "CST21 = 'False'",
            .Description = "المصاريف العامة غير مراجعة",
            .TypeName = "المصاريف العامة"
        },
        New Category With {
            .TableName = "Suppliers1",
            .SelectColumns = "IDCAB AS ID, CAB18 AS Number, CAB3 AS Date, CAB9 AS Name, USERNAME",
            .DateColumn = "CAB3",
            .Condition = "CAB13 = 'False'",
            .Description = "الموردين غير مرحلة",
            .TypeName = "الموردين"
        },
        New Category With {
            .TableName = "Suppliers1",
            .SelectColumns = "IDCAB AS ID, CAB18 AS Number, CAB3 AS Date, CAB9 AS Name, USERNAME",
            .DateColumn = "CAB3",
            .Condition = "CAB17 = 'False'",
            .Description = "الموردين غير مراجعة",
            .TypeName = "الموردين"
        },
        New Category With {
            .TableName = "SALARIES",
            .SelectColumns = "SLY1 AS ID, SLY25 AS Number, SLY26 AS Date, SLY2 AS Name, USERNAME",
            .DateColumn = "SLY26",
            .Condition = "SLY27 = 'False'",
            .Description = "المرتبات والاجور غير مرحلة",
            .TypeName = "المرتبات والاجور"
        },
        New Category With {
            .TableName = "SALARIES",
            .SelectColumns = "SLY1 AS ID, SLY25 AS Number, SLY26 AS Date, SLY2 AS Name, USERNAME",
            .DateColumn = "SLY26",
            .Condition = "SLY28 = 'False'",
            .Description = "المرتبات والاجور غير مراجعة",
            .TypeName = "المرتبات والاجور"
        },
        New Category With {
            .TableName = "Loans",
            .SelectColumns = "lo AS ID, lo17 AS Number, lo2 AS Date, lo5 AS Name, USERNAME",
            .DateColumn = "lo2",
            .Condition = "lo16 = 'False'",
            .Description = "القروض غير مرحلة",
            .TypeName = "القروض"
        },
        New Category With {
            .TableName = "Loans",
            .SelectColumns = "lo AS ID, lo17 AS Number, lo2 AS Date, lo5 AS Name, USERNAME",
            .DateColumn = "lo2",
            .Condition = "lo18 = 'False'",
            .Description = "القروض غير مراجعة",
            .TypeName = "القروض"
        },
        New Category With {
            .TableName = "LoansPa",
            .SelectColumns = "Loa1 AS ID, Loa5 AS Number, Loa3 AS Date, Loa11 AS Name, USERNAME",
            .DateColumn = "Loa3",
            .Condition = "Loa14 = 'False' AND Loa6 > '0'",
            .Description = "تسديدات العملاء غير مرحلة",
            .TypeName = "تسديدات العملاء"
        },
        New Category With {
            .TableName = "LoansPa",
            .SelectColumns = "Loa1 AS ID, Loa5 AS Number, Loa3 AS Date, Loa11 AS Name, USERNAME",
            .DateColumn = "Loa3",
            .Condition = "loa16 = 'False' AND Loa6 > '0'",
            .Description = "تسديدات العملاء غير مراجعة",
            .TypeName = "تسديدات العملاء"
        }
    }

            ' Define color mapping for each type
            Dim typeColors As New Dictionary(Of String, Color) From {
        {"القيود المحاسبة", Color.White},
        {"الصندوق", Color.Wheat},
        {"البنك", Color.PeachPuff},
        {"الموظفين", Color.Bisque},
        {"الشيكات", Color.PapayaWhip},
        {"الاسهم", Color.FloralWhite},
        {"حركات السحب والايداعات النقدية", Color.FloralWhite},
        {"المبيعات", Color.MediumAquamarine},
        {"المببعات_اليومية", Color.MediumAquamarine},
        {"المبيعات المسترجعة", Color.MediumAquamarine},
        {"المشتريات", Color.Aquamarine},
        {"العملاء", Color.Tan},
        {"مصاريف المشتريات", Color.NavajoWhite},
        {"فاتورة نقل تفصيلية", Color.OldLace},
        {"فاتورة نقل", Color.MediumSlateBlue},
        {"المصاريف العامة", Color.Moccasin},
        {"الموردين", Color.BlanchedAlmond},
        {"المرتبات والاجور", Color.AntiqueWhite},
        {"القروض", Color.Bisque},
        {"تسديدات العملاء", Color.Beige}
    }

            ' Create DataTable with explicitly defined columns
            Dim dt As New DataTable()
            dt.Columns.Add("Header", GetType(String))      ' For headers or empty
            dt.Columns.Add("ID", GetType(String))          ' ID from database
            dt.Columns.Add("Number", GetType(String))      ' Number from database
            dt.Columns.Add("Date", GetType(Date))        ' Date from database
            dt.Columns.Add("Description", GetType(String)) ' Description from category
            dt.Columns.Add("TypeName", GetType(String))    ' TypeName from category
            dt.Columns.Add("Username", GetType(String))    ' Username from database

            ' Database connection
            Using Consum As New SqlConnection(constring)
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()

                Dim previousType As String = ""
                For Each cat In categories
                    ' Add header when type changes
                    If cat.TypeName <> previousType Then
                        dt.Rows.Add("=== " & cat.TypeName & " ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                        previousType = cat.TypeName
                    End If
                    ' Construct and execute SQL query
                    Dim sql As String = $"SELECT {cat.SelectColumns} FROM {cat.TableName} WHERE CUser='{CUser}' AND Year({cat.DateColumn})='{FiscalYear_currentDateMustBeInFiscalYear()}' AND {cat.Condition}"
                    Using cmd As New SqlCommand(sql, Consum)
                        Dim ds As New DataSet
                        Dim adp As New SqlDataAdapter(cmd)
                        adp.Fill(ds, cat.TableName)
                        For Each row As DataRow In ds.Tables(cat.TableName).Rows
                            dt.Rows.Add(Nothing, row("ID").ToString(), row("Number").ToString(), row("Date").ToString(), cat.Description, cat.TypeName, row("Username").ToString())
                        Next
                    End Using
                Next

                ' Add blank row after "المرتبات والاجور" (before "القروض")
                dt.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                DataGrid.DataSource = dt
                Consum.Close()
            End Using


            ' Apply colors to rows
            ' After setting DataGrid.DataSource = dt
            ' Apply row colors using GridView's RowStyle event
            'Dim gridView As DevExpress.XtraGrid.Views.Grid.GridView = CType(DataGrid.MainView, DevExpress.XtraGrid.Views.Grid.GridView)
            'AddHandler gridView.RowStyle, Sub(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs)
            '                                  Dim view As DevExpress.XtraGrid.Views.Grid.GridView = CType(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            '                                  Dim typeName As String = view.GetRowCellValue(e.RowHandle, "TypeName")?.ToString()
            '                                  If typeColors.ContainsKey(typeName) Then
            '                                      e.Appearance.BackColor = typeColors(typeName)
            '                                  ElseIf String.IsNullOrEmpty(typeName) Then
            '                                      e.Appearance.BackColor = Color.LightGray
            '                                  End If
            '                              End Sub

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in SELECT_MOVES1", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub SELECT_MOVES2(ByVal DataGrid As DataGridView)
        Try
            ' Define table configurations
            Dim tableConfigs As New List(Of TableConfig) From {
        New TableConfig With {
            .TableName = "CASHIER",
            .SelectColumns = "CSH1, CSH4, CSH2, CSH11, USERNAME",
            .DateColumn = "CSH2",
            .FlagColumn = "CSH14",
            .TypeDescription = "الصندوق",
            .BackgroundColor = Color.Wheat,
            .MidNoColumn = "CSH1",
            .MidNo1Column = "CSH4",
            .MiddatColumn = "CSH2",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "BANKJO",
            .SelectColumns = "EBNK1, EBNK13, EBNK3, EBNK9, USERNAME",
            .DateColumn = "EBNK3",
            .FlagColumn = "EBNK14",
            .TypeDescription = "البنك",
            .BackgroundColor = Color.PeachPuff,
            .MidNoColumn = "EBNK1",
            .MidNo1Column = "EBNK13",
            .MiddatColumn = "EBNK3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "EMPSOLF",
            .SelectColumns = "CSH1, CSH2, CSH17, CSH11, USERNAME",
            .DateColumn = "CSH2",
            .FlagColumn = "CSH16",
            .TypeDescription = "الموظفين",
            .BackgroundColor = Color.Bisque,
            .MidNoColumn = "CSH1",
            .MidNo1Column = "CSH17",
            .MiddatColumn = "CSH2",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "Checks",
            .SelectColumns = "IDCH, CH3, CH16, CH9, USERNAME",
            .DateColumn = "CH2",
            .FlagColumn = "CH18",
            .TypeDescription = "الشيكات",
            .BackgroundColor = Color.PapayaWhip,
            .MidNoColumn = "IDCH",
            .MidNo1Column = "CH16",
            .MiddatColumn = "CH3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "Deposits",
            .SelectColumns = "TBNK1, TBNK18, TBNK3, TBNK20, USERNAME",
            .DateColumn = "TBNK3",
            .FlagColumn = "TBNK17",
            .TypeDescription = "الاسهم",
            .BackgroundColor = Color.FloralWhite,
            .MidNoColumn = "TBNK1",
            .MidNo1Column = "TBNK18",
            .MiddatColumn = "TBNK3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "PTRANSACTION",
            .SelectColumns = "TBNK1, TBNK11, TBNK3, TBNK22, USERNAME",
            .DateColumn = "TBNK3",
            .FlagColumn = "TBNK13",
            .TypeDescription = "حركات السحب والايداعات النقدية",
            .BackgroundColor = Color.FloralWhite,
            .MidNoColumn = "TBNK1",
            .MidNo1Column = "TBNK11",
            .MiddatColumn = "TBNK3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "BUYS",
            .SelectColumns = "BUY2, BUY18, BUY3, BUY24, USERNAME",
            .DateColumn = "BUY3",
            .FlagColumn = "BUY19",
            .TypeDescription = "المشتريات",
            .BackgroundColor = Color.Aquamarine,
            .MidNoColumn = "BUY2",
            .MidNo1Column = "BUY18",
            .MiddatColumn = "BUY3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "SALES",
            .SelectColumns = "SLS2, SLS9, SLS3, SLS5, USERNAME",
            .DateColumn = "SLS3",
            .FlagColumn = "SLS30",
            .TypeDescription = "المبيعات",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "SLS2",
            .MidNo1Column = "SLS9",
            .MiddatColumn = "SLS3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "TodaySales",
            .SelectColumns = "ID, TS9, DataTS, BarCod, USERNAME",
            .DateColumn = "DataTS",
            .FlagColumn = "Chk",
            .TypeDescription = "المببعات_اليومية",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "ID",
            .MidNo1Column = "TS9",
            .MiddatColumn = "DataTS",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "ASTRGA_ASTRDA",
            .SelectColumns = "ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME",
            .DateColumn = "DataD10",
            .FlagColumn = "Chk",
            .TypeDescription = "المبيعات المسترجعة",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "ID",
            .MidNo1Column = "NumFatorh12",
            .MiddatColumn = "DataD10",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "CABLES",
            .SelectColumns = "IDCAB, CAB3, CAB9, CAB21, USERNAME",
            .DateColumn = "CAB3",
            .FlagColumn = "CAB24",
            .TypeDescription = "العملاء",
            .BackgroundColor = Color.Tan,
            .MidNoColumn = "IDCAB",
            .MidNo1Column = "CAB21",
            .MiddatColumn = "CAB3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "CABLESCOEMPLOYEES",
            .SelectColumns = "CEMP3, CEMP2, CEMP25, CEMP31, USERNAME",
            .DateColumn = "CEMP2",
            .FlagColumn = "CEMP30",
            .TypeDescription = "مصاريف المشتريات",
            .BackgroundColor = Color.NavajoWhite,
            .MidNoColumn = "CEMP3",
            .MidNo1Column = "CEMP31",
            .MiddatColumn = "CEMP2",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "Invoice",
            .SelectColumns = "PTRO1, PTRO5, PTRO23, PTRO10, USERNAME",
            .DateColumn = "PTRO5",
            .FlagColumn = "PTRO22",
            .TypeDescription = "فاتورة نقل تفصيلية",
            .BackgroundColor = Color.OldLace,
            .MidNoColumn = "PTRO1",
            .MidNo1Column = "PTRO23",
            .MiddatColumn = "PTRO5",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "PETRO",
            .SelectColumns = "PTRO1, PTRO5, PTRO23, PTRO10, USERNAME",
            .DateColumn = "PTRO5",
            .FlagColumn = "PTRO22",
            .TypeDescription = "فاتورة نقل",
            .BackgroundColor = Color.MediumSlateBlue,
            .MidNoColumn = "PTRO1",
            .MidNo1Column = "PTRO23",
            .MiddatColumn = "PTRO5",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "MYCOSTS",
            .SelectColumns = "CST1, CST7, CST10, CST13, USERNAME",
            .DateColumn = "CST7",
            .FlagColumn = "CST21",
            .TypeDescription = "المصاريف العامة",
            .BackgroundColor = Color.Moccasin,
            .MidNoColumn = "CST1",
            .MidNo1Column = "CST13",
            .MiddatColumn = "CST7",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "Suppliers1",
            .SelectColumns = "IDCAB, CAB3, CAB9, CAB18, USERNAME",
            .DateColumn = "CAB3",
            .FlagColumn = "CAB17",
            .TypeDescription = "الموردين",
            .BackgroundColor = Color.BlanchedAlmond,
            .MidNoColumn = "IDCAB",
            .MidNo1Column = "CAB18",
            .MiddatColumn = "CAB3",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "SALARIES",
            .SelectColumns = "SLY1, SLY2, SLY25, SLY26, USERNAME",
            .DateColumn = "SLY26",
            .FlagColumn = "SLY28",
            .TypeDescription = "المرتبات والاجور",
            .BackgroundColor = Color.AntiqueWhite,
            .MidNoColumn = "SLY1",
            .MidNo1Column = "SLY25",
            .MiddatColumn = "SLY26",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "Loans",
            .SelectColumns = "lo, lo17, lo2, lo5, USERNAME",
            .DateColumn = "lo2",
            .FlagColumn = "lo18",
            .TypeDescription = "القروض",
            .BackgroundColor = Color.Bisque,
            .MidNoColumn = "lo",
            .MidNo1Column = "lo17",
            .MiddatColumn = "lo2",
            .UsernameColumn = "USERNAME"
        },
        New TableConfig With {
            .TableName = "LoansPa",
            .SelectColumns = "Loa1, Loa5, Loa3, Loa11, USERNAME",
            .TypeDescription = "تسديدات العملاء",
            .BackgroundColor = Color.Beige,
            .MidNoColumn = "Loa1",
            .MidNo1Column = "Loa5",
            .MiddatColumn = "Loa3",
            .UsernameColumn = "USERNAME",
            .CustomQuery = $"SELECT Loa1, Loa5, Loa3, Loa11, USERNAME FROM LoansPa WHERE CUser='{CUser}' AND loa16 ='{False}' AND Loa6 >'{0}'"
        }
    }

            ' Data retrieval
            Dim ds As New DataSet
            Using Consum As New SqlConnection(constring)
                Consum.Open()
                For Each tc In tableConfigs
                    Dim query As String = If(tc.CustomQuery,
                                        $"SELECT {tc.SelectColumns} FROM {tc.TableName} WHERE CUser='{CUser}' AND Year({tc.DateColumn}) ='{FiscalYear_currentDateMustBeInFiscalYear()}' AND {tc.FlagColumn} ='{False}'")
                    Using cmd As New SqlCommand(query, Consum)
                        Using adp As New SqlDataAdapter(cmd)
                            adp.Fill(ds, tc.TableName)
                        End Using
                    End Using
                Next
                Consum.Close()
            End Using

            ' Populate DataGridView
            For Each tc In tableConfigs
                ' Add header row
                Dim headerRowIndex As Integer = DataGrid.Rows.Add($"=== {tc.TypeDescription} ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
                For col = 0 To 6
                    DataGrid.Rows(headerRowIndex).Cells(col).Style.BackColor = Color.LightGray
                Next

                ' Add data rows
                If ds.Tables(tc.TableName) IsNot Nothing Then
                    For Each dr As DataRow In ds.Tables(tc.TableName).Rows
                        Dim MidNo As String = dr(tc.MidNoColumn).ToString()
                        Dim MidNo1 As String = dr(tc.MidNo1Column).ToString()
                        Dim Middat As String = dr(tc.MiddatColumn).ToString()
                        Dim MidUSERNAME As String = dr(tc.UsernameColumn).ToString()
                        Dim rowIndex As Integer = DataGrid.Rows.Add({"", MidNo, MidNo1, Middat, tc.TypeDescription & " غير مراجعة", tc.TypeDescription, MidUSERNAME, ""})
                        Dim rowIndex1 As Integer = DataGrid.Rows.Add({"", MidNo, MidNo1, Middat, tc.TypeDescription & " غير مرحلة", tc.TypeDescription, MidUSERNAME, ""})

                        For col = 0 To 6
                            DataGrid.Rows(rowIndex).Cells(col).Style.BackColor = tc.BackgroundColor
                        Next
                        For col = 0 To 6
                            DataGrid.Rows(rowIndex1).Cells(col).Style.BackColor = tc.BackgroundColor
                        Next
                    Next
                End If
            Next
            ' Add final row
            Dim finalRowIndex As Integer = DataGrid.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            For col = 0 To 6
                DataGrid.Rows(finalRowIndex).Cells(col).Style.BackColor = Color.LightGray
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error in SELECT_MOVES2", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    'code optimization
    Public Sub SELECT_MOVES3(ByVal DataGrid As DataGridView)
        On Error Resume Next ' Consider replacing with specific exception handling in production

        ' Define table configurations
        Dim tableConfigs As New List(Of TableConfig) From {
        New TableConfig With {
            .TableName = "MOVES",
            .SelectColumns = "MOV2, MOV11, MOV12, MOV3, MOV4, USERNAME",
            .DateColumn = "MOV3",
            .FlagColumn = "MOV12",
            .TypeDescription = "القيود المحاسبة",
            .BackgroundColor = Nothing,
            .MidNoColumn = "MOV2",
            .MidNo1Column = "MOV11",
            .MiddatColumn = "MOV3",
            .UsernameColumn = "USERNAME",
            .StatusText = "قيود غير مراجعة"
        },
        New TableConfig With {
            .TableName = "CASHIER",
            .SelectColumns = "CSH1, CSH4, CSH2, CSH11, USERNAME",
            .DateColumn = "CSH2",
            .FlagColumn = "CSH14",
            .TypeDescription = "الصندوق",
            .BackgroundColor = Color.Wheat,
            .MidNoColumn = "CSH1",
            .MidNo1Column = "CSH4",
            .MiddatColumn = "CSH2",
            .UsernameColumn = "USERNAME",
            .StatusText = "الصندوق غير مراجعة"
        },
         New TableConfig With {
            .TableName = "CASHIER",
            .SelectColumns = "CSH1, CSH4, CSH2, CSH11, USERNAME",
            .DateColumn = "CSH2",
            .FlagColumn = "CSH14",
            .TypeDescription = "الصندوق",
            .BackgroundColor = Color.Wheat,
            .MidNoColumn = "CSH1",
            .MidNo1Column = "CSH4",
            .MiddatColumn = "CSH2",
            .UsernameColumn = "USERNAME",
            .StatusText = "الصندوق غير مرحلة"
        },
        New TableConfig With {
            .TableName = "BANKJO",
            .SelectColumns = "EBNK1, EBNK13, EBNK3, EBNK9, USERNAME",
            .DateColumn = "EBNK3",
            .FlagColumn = "EBNK14",
            .TypeDescription = "البنك",
            .BackgroundColor = Color.PeachPuff,
            .MidNoColumn = "EBNK1",
            .MidNo1Column = "EBNK13",
            .MiddatColumn = "EBNK3",
            .UsernameColumn = "USERNAME",
            .StatusText = "البنك غير مراجعة"
        },
         New TableConfig With {
            .TableName = "BANKJO",
            .SelectColumns = "EBNK1, EBNK13, EBNK3, EBNK9, USERNAME",
            .DateColumn = "EBNK3",
            .FlagColumn = "EBNK14",
            .TypeDescription = "البنك",
            .BackgroundColor = Color.PeachPuff,
            .MidNoColumn = "EBNK1",
            .MidNo1Column = "EBNK13",
            .MiddatColumn = "EBNK3",
            .UsernameColumn = "USERNAME",
            .StatusText = "البنك غير مرحلة"
        },
        New TableConfig With {
            .TableName = "EMPSOLF",
            .SelectColumns = "CSH1, CSH2, CSH17, CSH11, USERNAME",
            .DateColumn = "CSH2",
            .FlagColumn = "CSH16",
            .TypeDescription = "الموظفين",
            .BackgroundColor = Color.Bisque,
            .MidNoColumn = "CSH1",
            .MidNo1Column = "CSH17",
            .MiddatColumn = "CSH2",
            .UsernameColumn = "USERNAME",
            .StatusText = "الموظفين غير مراجعة"
        },
         New TableConfig With {
            .TableName = "EMPSOLF",
            .SelectColumns = "CSH1, CSH2, CSH17, CSH11, USERNAME",
            .DateColumn = "CSH2",
            .FlagColumn = "CSH16",
            .TypeDescription = "الموظفين",
            .BackgroundColor = Color.Bisque,
            .MidNoColumn = "CSH1",
            .MidNo1Column = "CSH17",
            .MiddatColumn = "CSH2",
            .UsernameColumn = "USERNAME",
            .StatusText = "الموظفين غير مرحلة"
        },
        New TableConfig With {
            .TableName = "Checks",
            .SelectColumns = "IDCH, CH3, CH16, CH9, USERNAME",
            .DateColumn = "CH2",
            .FlagColumn = "CH18",
            .TypeDescription = "الشيكات",
            .BackgroundColor = Color.PapayaWhip,
            .MidNoColumn = "IDCH",
            .MidNo1Column = "CH16",
            .MiddatColumn = "CH3",
            .UsernameColumn = "USERNAME",
            .StatusText = "الشيكات غير مراجعة"
        },
         New TableConfig With {
            .TableName = "Checks",
            .SelectColumns = "IDCH, CH3, CH16, CH9, USERNAME",
            .DateColumn = "CH2",
            .FlagColumn = "CH18",
            .TypeDescription = "الشيكات",
            .BackgroundColor = Color.PapayaWhip,
            .MidNoColumn = "IDCH",
            .MidNo1Column = "CH16",
            .MiddatColumn = "CH3",
            .UsernameColumn = "USERNAME",
            .StatusText = "الشيكات غير مرحلة"
        },
        New TableConfig With {
            .TableName = "Deposits",
            .SelectColumns = "TBNK1, TBNK18, TBNK3, TBNK20, USERNAME",
            .DateColumn = "TBNK3",
            .FlagColumn = "TBNK17",
            .TypeDescription = "الاسهم",
            .BackgroundColor = Color.FloralWhite,
            .MidNoColumn = "TBNK1",
            .MidNo1Column = "TBNK18",
            .MiddatColumn = "TBNK3",
            .UsernameColumn = "USERNAME",
            .StatusText = "الاسهم غير مراجعة"
        },
         New TableConfig With {
            .TableName = "Deposits",
            .SelectColumns = "TBNK1, TBNK18, TBNK3, TBNK20, USERNAME",
            .DateColumn = "TBNK3",
            .FlagColumn = "TBNK17",
            .TypeDescription = "الاسهم",
            .BackgroundColor = Color.FloralWhite,
            .MidNoColumn = "TBNK1",
            .MidNo1Column = "TBNK18",
            .MiddatColumn = "TBNK3",
            .UsernameColumn = "USERNAME",
            .StatusText = "الاسهم غير مرحلة"
        },
        New TableConfig With {
            .TableName = "PTRANSACTION",
            .SelectColumns = "TBNK1, TBNK11, TBNK3, TBNK22, USERNAME",
            .DateColumn = "TBNK3",
            .FlagColumn = "TBNK13",
            .TypeDescription = "حركات السحب والايداعات النقدية",
            .BackgroundColor = Color.FloralWhite,
            .MidNoColumn = "TBNK1",
            .MidNo1Column = "TBNK11",
            .MiddatColumn = "TBNK3",
            .UsernameColumn = "USERNAME",
            .StatusText = "حركات السحب والايداعات النقدية غير مراجعة"
        },
        New TableConfig With {
            .TableName = "PTRANSACTION",
            .SelectColumns = "TBNK1, TBNK11, TBNK3, TBNK22, USERNAME",
            .DateColumn = "TBNK3",
            .FlagColumn = "TBNK13",
            .TypeDescription = "حركات السحب والايداعات النقدية",
            .BackgroundColor = Color.FloralWhite,
            .MidNoColumn = "TBNK1",
            .MidNo1Column = "TBNK11",
            .MiddatColumn = "TBNK3",
            .UsernameColumn = "USERNAME",
            .StatusText = "حركات السحب والايداعات النقدية غير مرحلة"
        },
        New TableConfig With {
            .TableName = "SALES",
            .SelectColumns = "SLS2, SLS9, SLS3, SLS5, USERNAME",
            .DateColumn = "SLS3",
            .FlagColumn = "SLS30",
            .TypeDescription = "المبيعات",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "SLS2",
            .MidNo1Column = "SLS19",
            .MiddatColumn = "SLS3",
            .UsernameColumn = "USERNAME",
            .StatusText = "المبيعات غير مراجعة"
        },
        New TableConfig With {
            .TableName = "SALES",
            .SelectColumns = "SLS2, SLS9, SLS3, SLS5, USERNAME",
            .DateColumn = "SLS3",
            .FlagColumn = "SLS30",
            .TypeDescription = "المبيعات",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "SLS2",
            .MidNo1Column = "SLS19",
            .MiddatColumn = "SLS3",
            .UsernameColumn = "USERNAME",
            .StatusText = "المبيعات غير مرحلة"
        },
        New TableConfig With {
            .TableName = "TodaySales",
            .SelectColumns = "ID, TS9, DataTS, BarCod, USERNAME",
            .DateColumn = "DataTS",
            .FlagColumn = "Chk",
            .TypeDescription = "المببعات_اليومية",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "ID",
            .MidNo1Column = "TS9",
            .MiddatColumn = "DataTS",
            .UsernameColumn = "USERNAME",
            .StatusText = "المببعات_اليومية غير مراجعة"
        },
        New TableConfig With {
            .TableName = "TodaySales",
            .SelectColumns = "ID, TS9, DataTS, BarCod, USERNAME",
            .DateColumn = "DataTS",
            .FlagColumn = "Chk",
            .TypeDescription = "المببعات_اليومية",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "ID",
            .MidNo1Column = "TS9",
            .MiddatColumn = "DataTS",
            .UsernameColumn = "USERNAME",
            .StatusText = "المببعات_اليومية غير مرحلة"
        },
        New TableConfig With {
            .TableName = "ASTRGA_ASTRDA",
            .SelectColumns = "ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME",
            .DateColumn = "DataD10",
            .FlagColumn = "Chk",
            .TypeDescription = "المبيعات المسترجعة",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "ID",
            .MidNo1Column = "NumFatorh12",
            .MiddatColumn = "DataD10",
            .UsernameColumn = "USERNAME",
            .StatusText = "المبيعات المسترجعة غير مراجعة"
        },
         New TableConfig With {
            .TableName = "ASTRGA_ASTRDA",
            .SelectColumns = "ID, pros0, Barcodd1, DataD10, NumFatorh12, USERNAME",
            .DateColumn = "DataD10",
            .FlagColumn = "Chk",
            .TypeDescription = "المبيعات المسترجعة",
            .BackgroundColor = Color.MediumAquamarine,
            .MidNoColumn = "ID",
            .MidNo1Column = "NumFatorh12",
            .MiddatColumn = "DataD10",
            .UsernameColumn = "USERNAME",
            .StatusText = "المبيعات المسترجعة غير مرحلة"
        },
        New TableConfig With {
            .TableName = "BUYS",
            .SelectColumns = "BUY2, BUY18, BUY3, BUY24, USERNAME",
            .DateColumn = "BUY3",
            .FlagColumn = "BUY19",
            .TypeDescription = "المشتريات",
            .BackgroundColor = Color.Aquamarine,
            .MidNoColumn = "BUY2",
            .MidNo1Column = "BUY18",
            .MiddatColumn = "BUY3",
            .UsernameColumn = "USERNAME",
            .StatusText = "المشتريات غير مراجعة"
        },
        New TableConfig With {
            .TableName = "BUYS",
            .SelectColumns = "BUY2, BUY18, BUY3, BUY24, USERNAME",
            .DateColumn = "BUY3",
            .FlagColumn = "BUY19",
            .TypeDescription = "المشتريات",
            .BackgroundColor = Color.Aquamarine,
            .MidNoColumn = "BUY2",
            .MidNo1Column = "BUY18",
            .MiddatColumn = "BUY3",
            .UsernameColumn = "USERNAME",
            .StatusText = "المشتريات غير مرحلة"
        },
        New TableConfig With {
            .TableName = "CABLES",
            .SelectColumns = "IDCAB, CAB3, CAB9, CAB21, USERNAME",
            .DateColumn = "CAB3",
            .FlagColumn = "CAB24",
            .TypeDescription = "العملاء",
            .BackgroundColor = Color.Tan,
            .MidNoColumn = "IDCAB",
            .MidNo1Column = "CAB21",
            .MiddatColumn = "CAB3",
            .UsernameColumn = "USERNAME",
            .StatusText = "العملاء غير مراجعة"
        },
         New TableConfig With {
            .TableName = "CABLES",
            .SelectColumns = "IDCAB, CAB3, CAB9, CAB21, USERNAME",
            .DateColumn = "CAB3",
            .FlagColumn = "CAB24",
            .TypeDescription = "العملاء",
            .BackgroundColor = Color.Tan,
            .MidNoColumn = "IDCAB",
            .MidNo1Column = "CAB21",
            .MiddatColumn = "CAB3",
            .UsernameColumn = "USERNAME",
            .StatusText = "العملاء غير مرحلة"
        },
        New TableConfig With {
            .TableName = "CABLESCOEMPLOYEES",
            .SelectColumns = "CEMP3, CEMP2, CEMP25, CEMP31, USERNAME",
            .DateColumn = "CEMP2",
            .FlagColumn = "CEMP30",
            .TypeDescription = "مصاريف المشتريات",
            .BackgroundColor = Color.NavajoWhite,
            .MidNoColumn = "CEMP3",
            .MidNo1Column = "CEMP31",
            .MiddatColumn = "CEMP2",
            .UsernameColumn = "USERNAME",
            .StatusText = "مصاريف المشتريات غير مراجعة"
        },
         New TableConfig With {
            .TableName = "CABLESCOEMPLOYEES",
            .SelectColumns = "CEMP3, CEMP2, CEMP25, CEMP31, USERNAME",
            .DateColumn = "CEMP2",
            .FlagColumn = "CEMP30",
            .TypeDescription = "مصاريف المشتريات",
            .BackgroundColor = Color.NavajoWhite,
            .MidNoColumn = "CEMP3",
            .MidNo1Column = "CEMP31",
            .MiddatColumn = "CEMP2",
            .UsernameColumn = "USERNAME",
            .StatusText = "مصاريف المشتريات غير مرحلة"
        },
        New TableConfig With {
            .TableName = "Invoice",
            .SelectColumns = "PTRO1, PTRO5, PTRO23, PTRO10, USERNAME",
            .DateColumn = "PTRO5",
            .FlagColumn = "PTRO22",
            .TypeDescription = "فاتورة نقل تفصيلية",
            .BackgroundColor = Color.OldLace,
            .MidNoColumn = "PTRO1",
            .MidNo1Column = "PTRO23",
            .MiddatColumn = "PTRO5",
            .UsernameColumn = "USERNAME",
            .StatusText = "فاتورة نقل تفصيلية غير مراجعة"
        },
         New TableConfig With {
            .TableName = "Invoice",
            .SelectColumns = "PTRO1, PTRO5, PTRO23, PTRO10, USERNAME",
            .DateColumn = "PTRO5",
            .FlagColumn = "PTRO22",
            .TypeDescription = "فاتورة نقل تفصيلية",
            .BackgroundColor = Color.OldLace,
            .MidNoColumn = "PTRO1",
            .MidNo1Column = "PTRO23",
            .MiddatColumn = "PTRO5",
            .UsernameColumn = "USERNAME",
            .StatusText = "فاتورة نقل تفصيلية غير مرحلة"
        },
        New TableConfig With {
            .TableName = "PETRO",
            .SelectColumns = "PTRO1, PTRO5, PTRO23, PTRO10, USERNAME",
            .DateColumn = "PTRO5",
            .FlagColumn = "PTRO22",
            .TypeDescription = "فاتورة نقل",
            .BackgroundColor = Color.MediumSlateBlue,
            .MidNoColumn = "PTRO1",
            .MidNo1Column = "PTRO23",
            .MiddatColumn = "PTRO5",
            .UsernameColumn = "USERNAME",
            .StatusText = "فاتورة نقل غير مراجعة"
        },
         New TableConfig With {
            .TableName = "PETRO",
            .SelectColumns = "PTRO1, PTRO5, PTRO23, PTRO10, USERNAME",
            .DateColumn = "PTRO5",
            .FlagColumn = "PTRO22",
            .TypeDescription = "فاتورة نقل",
            .BackgroundColor = Color.MediumSlateBlue,
            .MidNoColumn = "PTRO1",
            .MidNo1Column = "PTRO23",
            .MiddatColumn = "PTRO5",
            .UsernameColumn = "USERNAME",
            .StatusText = "فاتورة نقل غير مرحلة"
        },
        New TableConfig With {
            .TableName = "MYCOSTS",
            .SelectColumns = "CST1, CST7, CST10, CST13, USERNAME",
            .DateColumn = "CST7",
            .FlagColumn = "CST21",
            .TypeDescription = "المصاريف العامة",
            .BackgroundColor = Color.Moccasin,
            .MidNoColumn = "CST1",
            .MidNo1Column = "CST13",
            .MiddatColumn = "CST7",
            .UsernameColumn = "USERNAME",
            .StatusText = "المصاريف العامة غير مراجعة"
        },
         New TableConfig With {
            .TableName = "MYCOSTS",
            .SelectColumns = "CST1, CST7, CST10, CST13, USERNAME",
            .DateColumn = "CST7",
            .FlagColumn = "CST21",
            .TypeDescription = "المصاريف العامة",
            .BackgroundColor = Color.Moccasin,
            .MidNoColumn = "CST1",
            .MidNo1Column = "CST13",
            .MiddatColumn = "CST7",
            .UsernameColumn = "USERNAME",
            .StatusText = "المصاريف العامة غير مرحلة"
        },
        New TableConfig With {
            .TableName = "Suppliers1",
            .SelectColumns = "IDCAB, CAB3, CAB9, CAB18, USERNAME",
            .DateColumn = "CAB3",
            .FlagColumn = "CAB17",
            .TypeDescription = "الموردين",
            .BackgroundColor = Color.BlanchedAlmond,
            .MidNoColumn = "IDCAB",
            .MidNo1Column = "CAB21",
            .MiddatColumn = "CAB3",
            .UsernameColumn = "USERNAME",
            .StatusText = "الموردين غير مراجعة"
        },
         New TableConfig With {
            .TableName = "Suppliers1",
            .SelectColumns = "IDCAB, CAB3, CAB9, CAB18, USERNAME",
            .DateColumn = "CAB3",
            .FlagColumn = "CAB17",
            .TypeDescription = "الموردين",
            .BackgroundColor = Color.BlanchedAlmond,
            .MidNoColumn = "IDCAB",
            .MidNo1Column = "CAB21",
            .MiddatColumn = "CAB3",
            .UsernameColumn = "USERNAME",
            .StatusText = "الموردين غير مرحلة"
        },
        New TableConfig With {
            .TableName = "SALARIES",
            .SelectColumns = "SLY1, SLY2, SLY25, SLY26, USERNAME",
            .DateColumn = "SLY26",
            .FlagColumn = "SLY28",
            .TypeDescription = "المرتبات والاجور",
            .BackgroundColor = Color.AntiqueWhite,
            .MidNoColumn = "SLY1",
            .MidNo1Column = "SLY25",
            .MiddatColumn = "SLY26",
            .UsernameColumn = "USERNAME",
            .StatusText = "المرتبات والاجور غير مراجعة"
        },
          New TableConfig With {
            .TableName = "SALARIES",
            .SelectColumns = "SLY1, SLY2, SLY25, SLY26, USERNAME",
            .DateColumn = "SLY26",
            .FlagColumn = "SLY28",
            .TypeDescription = "المرتبات والاجور",
            .BackgroundColor = Color.AntiqueWhite,
            .MidNoColumn = "SLY1",
            .MidNo1Column = "SLY25",
            .MiddatColumn = "SLY26",
            .UsernameColumn = "USERNAME",
            .StatusText = "المرتبات والاجور غير مرحلة"
        },
        New TableConfig With {
            .TableName = "Loans",
            .SelectColumns = "lo, lo17, lo2, lo5, USERNAME",
            .DateColumn = "lo2",
            .FlagColumn = "lo18",
            .TypeDescription = "القروض",
            .BackgroundColor = Color.Bisque,
            .MidNoColumn = "lo",
            .MidNo1Column = "lo17",
            .MiddatColumn = "lo2",
            .UsernameColumn = "USERNAME",
            .StatusText = "القروض غير مراجعة"
        },
         New TableConfig With {
            .TableName = "Loans",
            .SelectColumns = "lo, lo17, lo2, lo5, USERNAME",
            .DateColumn = "lo2",
            .FlagColumn = "lo18",
            .TypeDescription = "القروض",
            .BackgroundColor = Color.Bisque,
            .MidNoColumn = "lo",
            .MidNo1Column = "lo17",
            .MiddatColumn = "lo2",
            .UsernameColumn = "USERNAME",
            .StatusText = "القروض غير مرحلة"
        },
        New TableConfig With {
            .TableName = "LoansPa",
            .TypeDescription = "تسديدات العملاء",
            .BackgroundColor = Color.Beige,
            .MidNoColumn = "Loa1",
            .MidNo1Column = "Loa5",
            .MiddatColumn = "Loa3",
            .UsernameColumn = "USERNAME",
            .StatusText = "تسديدات العملاء غير مراجعة"
           },
           New TableConfig With {
            .TableName = "LoansPa",
            .TypeDescription = "تسديدات العملاء",
            .BackgroundColor = Color.Beige,
            .MidNoColumn = "Loa1",
            .MidNo1Column = "Loa5",
            .MiddatColumn = "Loa3",
            .UsernameColumn = "USERNAME",
            .StatusText = "تسديدات العملاء غير مرحلة",
                        .CustomQuery = $"SELECT Loa1, Loa5, Loa3, Loa11, USERNAME FROM LoansPa WHERE CUser='{CUser}' AND loa16 ='{False}' AND Loa6 >'{0}'"
        }
    }

        ' Fetch data into a single DataSet
        Dim ds As New DataSet
        Using Consum As New SqlConnection(constring)
            Consum.Open()
            For Each tc In tableConfigs
                Dim query As String
                If Not String.IsNullOrEmpty(tc.CustomQuery) Then
                    query = tc.CustomQuery
                Else
                    query = $"SELECT {tc.SelectColumns} FROM {tc.TableName} WHERE CUser='{CUser}' AND Year({tc.DateColumn}) = '{FiscalYear_currentDateMustBeInFiscalYear()}' AND {tc.FlagColumn} = '{False}'"
                End If
                Using cmd As New SqlCommand(query, Consum)
                    Using adp As New SqlDataAdapter(cmd)
                        adp.Fill(ds, tc.TableName)
                    End Using
                End Using
            Next
            Consum.Close()
        End Using

        ' Populate DataGridView
        For Each tc In tableConfigs
            ' Add header row
            Dim headerRowIndex As Integer = DataGrid.Rows.Add($"=== {tc.TypeDescription} ===", Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
            For col As Integer = 0 To 6
                DataGrid.Rows(headerRowIndex).Cells(col).Style.BackColor = Color.LightGray
            Next

            ' Add data rows
            If ds.Tables(tc.TableName) IsNot Nothing AndAlso ds.Tables(tc.TableName).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(tc.TableName).Rows
                    Dim MidNo As String = dr(tc.MidNoColumn).ToString()
                    Dim MidNo1 As String = dr(tc.MidNo1Column).ToString()
                    Dim Middat As String = dr(tc.MiddatColumn).ToString()
                    Dim MidUSERNAME As String = dr(tc.UsernameColumn).ToString()
                    Dim rowIndex As Integer = DataGrid.Rows.Add("", MidNo, MidNo1, Middat, tc.StatusText, tc.TypeDescription, MidUSERNAME, "")

                    ' Apply background color
                    If tc.BackgroundColor.HasValue Then
                        For col As Integer = 0 To 6
                            DataGrid.Rows(rowIndex).Cells(col).Style.BackColor = tc.BackgroundColor.Value
                        Next
                        ' Special styling for specific types
                        If tc.TypeDescription = "المببعات_اليومية" OrElse tc.TypeDescription = "المبيعات المسترجعة" Then
                            DataGrid.Rows(rowIndex).Cells(2).Style.BackColor = Color.Red
                        End If
                    End If
                Next
            End If
        Next

        ' Add final empty row
        Dim finalRowIndex As Integer = DataGrid.Rows.Add(Nothing, Nothing, Nothing, Nothing, Nothing, Nothing, Nothing)
        For col As Integer = 0 To 6
            DataGrid.Rows(finalRowIndex).Cells(col).Style.BackColor = Color.LightGray
        Next
    End Sub


    Public Class Category
        Public TableName As String
        Public SelectColumns As String
        Public DateColumn As String
        Public Condition As String
        Public Description As String
        Public TypeName As String
    End Class

    Public Class TableConfig
        Public Property TableName As String
        Public Property SelectColumns As String
        Public Property DateColumn As String
        Public Property FlagColumn As String
        Public Property TypeDescription As String

        Public Property BackgroundColor As Color?
        Public Property MidNoColumn As String
        Public Property MidNo1Column As String
        Public Property MiddatColumn As String
        Public Property UsernameColumn As String
        Public Property StatusText As String
        Public Property CustomQuery As String

    End Class


End Module
