Option Strict Off
Module Module_datac

    Public LongDateString As String = String.Empty

    '#Region " DateConverter (dateValue As String) As String "

#Region " DateConverter (dateValue As String) As String "
    Public Function DateConvert(ByVal dateValue As String) As String

        LongDateString = ""

        ' الاحتفاظ بالإعدادت الحالية
        Dim currentCulture As Globalization.CultureInfo = Threading.Thread.CurrentThread.CurrentCulture

        Dim con As String = ""
        If DateFormating(dateValue) <> "" Then
            dateValue = DateFormating(dateValue)
            '----------------------------------
            Dim y As String = IIf(dateValue <> "", dateValue.Split("/")(2), "")

            Dim mmm() As String
            If y > "1300" And y < "1451" Then
                con = GetGregorianDate(dateValue)
                mmm = Split(GetGregorianDate(dateValue), "/")
                LongDateString = ArabicWeekdayString(Weekday(GetGregorianDate(dateValue))) & " " & mmm(0) & " " & GregorianMonthString(Val(mmm(1))) & ", " & mmm(2)
            End If

            If y > "1883" And y < "2029" Then
                con = GetHijriDate(dateValue)
                mmm = Split(con, "/")
                LongDateString = ArabicWeekdayString(Weekday(dateValue)) & " " & mmm(0) & " " & HiriMonthString(Val(mmm(1))) & ", " & mmm(2)
            End If

        End If

        ' إستعادة الإعدادت
        Threading.Thread.CurrentThread.CurrentCulture = currentCulture

        Return con
    End Function
#End Region

#Region " GetHijriDate(GregorianDate As String) As String "
    Private Function GetHijriDate(ByVal GregorianDate As String) As String
        Try

            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("ar-eg")

            Dim hijriDate As String = String.Empty

            'Start Date is 10-31-1883
<<<<<<< HEAD
            Dim DaysPan As Integer = DateDiff(DateInterval.Day, New DateTime(1883, 10, 31), CDate(GregorianDate)) + 1
=======
            Dim DaysPan As Integer = DateDiff(DateInterval.Day, New System.DateTime(1883, 10, 31), CDate(GregorianDate)) + 1
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim i As Integer = 0
            Do While DaysPan > 29 + Val(UmmUlquraHijriMonths.Chars(i))
                DaysPan = DaysPan - 29 - Val(UmmUlquraHijriMonths.Chars(i))
                i += 1
            Loop
            hijriDate = Format$(DaysPan, "00") + "/" + Format((i Mod 12) + 1, "00") + "/" + CStr(1301 + (i \ 12))

            Return hijriDate

        Catch ex As Exception
            MessageBox.Show("تأكد من التاريخ الميلادي.", "خطأ في التاريخ الميلادي", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading)
            Return Nothing
        End Try
    End Function
#End Region

#Region " GetGregorianDate(HijriDate As String) As Date "
    Private Function GetGregorianDate(ByVal HijriDate As String) As String
        Try

            Threading.Thread.CurrentThread.CurrentCulture = New Globalization.CultureInfo("ar-eg")

            Dim gregorianDate As String = String.Empty

            Dim MonthsPan As Integer
            MonthsPan = (12 * (CInt(Mid(HijriDate, 7, 4)) - 1301)) + CInt(Mid(HijriDate, 4, 2))
            Dim TempDaysPan As Integer
            Dim i As Integer
            For i = 0 To MonthsPan - 2
                TempDaysPan = TempDaysPan + 29 + Val(UmmUlquraHijriMonths.Chars(i))
            Next i
            If CInt(Mid(HijriDate, 1, 2)) > 29 + Val(UmmUlquraHijriMonths.Chars(i)) Then
                MessageBox.Show("رقم اليوم لهذا الشهر يجب أن لا يتجاوز 29", "خطأ اليوم الشهري للتاريخ الهجري", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading)
                Return Nothing
            Else
                TempDaysPan += CInt(Mid(HijriDate, 1, 2))
            End If

            'Start Date is 10-31-1883
<<<<<<< HEAD
            gregorianDate = CStr(DateAdd(DateInterval.Day, TempDaysPan - 1, New DateTime(1883, 10, 31)))
=======
            gregorianDate = CStr(DateAdd(DateInterval.Day, TempDaysPan - 1, New System.DateTime(1883, 10, 31)))
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

            Return gregorianDate

        Catch ex As Exception
            MessageBox.Show("تأكد من التاريخ الهجري.", "خطأ في التاريخ الهجري", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading)
            Return Nothing
        End Try
    End Function
#End Region

#Region " UmmUlquraHijriMonths "
    'UmmUlquraHijriMonths
    Private Function UmmUlquraHijriMonths() As String
        Dim HijriMonthSequence As String = ""
        'Create the Months data from 1301H to 1450H - (150years)
        HijriMonthSequence += "111010010011" 'Year 1301H
        HijriMonthSequence += "011101001001" 'Year 1302H
        HijriMonthSequence += "011101100100" 'Year 1303H
        HijriMonthSequence += "101101101010" 'Year 1304H
        HijriMonthSequence += "010101110101" 'Year 1305H
        HijriMonthSequence += "010010110110" 'Year 1306H
        HijriMonthSequence += "101001010110" 'Year 1307H
        HijriMonthSequence += "101101001010" 'Year 1308H
        HijriMonthSequence += "110110100100" 'Year 1309H
        HijriMonthSequence += "110111010010" 'Year 1310H
        HijriMonthSequence += "010111011001" 'Year 1311H
        HijriMonthSequence += "001011011100" 'Year 1312H
        HijriMonthSequence += "100101011101" 'Year 1313H
        HijriMonthSequence += "010010101101" 'Year 1314H
        HijriMonthSequence += "101001010101" 'Year 1315H
        HijriMonthSequence += "101101001010" 'Year 1316H
        HijriMonthSequence += "101101101001" 'Year 1317H
        HijriMonthSequence += "010101110100" 'Year 1318H
        HijriMonthSequence += "100101110110" 'Year 1319H
        HijriMonthSequence += "010010110111" 'Year 1320H
        HijriMonthSequence += "001001010111" 'Year 1321H
        HijriMonthSequence += "010100101011" 'Year 1322H
        HijriMonthSequence += "011010010101" 'Year 1323H
        HijriMonthSequence += "011011001010" 'Year 1324H
        HijriMonthSequence += "101011010101" 'Year 1325H
        HijriMonthSequence += "010101011011" 'Year 1326H
        HijriMonthSequence += "001001011101" 'Year 1327H
        HijriMonthSequence += "100100101101" 'Year 1328H
        HijriMonthSequence += "110010010101" 'Year 1329H
        HijriMonthSequence += "110101001010" 'Year 1330H
        HijriMonthSequence += "111010100101" 'Year 1331H
        HijriMonthSequence += "011011010010" 'Year 1332H
        HijriMonthSequence += "101011010101" 'Year 1333H
        HijriMonthSequence += "010101011010" 'Year 1334H
        HijriMonthSequence += "101010101011" 'Year 1335H
        HijriMonthSequence += "010101001011" 'Year 1336H
        HijriMonthSequence += "011010100101" 'Year 1337H
        HijriMonthSequence += "011101010010" 'Year 1338H
        HijriMonthSequence += "101110101001" 'Year 1339H
        HijriMonthSequence += "001101110100" 'Year 1340H
        HijriMonthSequence += "101010110110" 'Year 1341H
        HijriMonthSequence += "010101010110" 'Year 1342H
        HijriMonthSequence += "101010101010" 'Year 1343H
        HijriMonthSequence += "110101010010" 'Year 1344H
        HijriMonthSequence += "110110101001" 'Year 1345H
        HijriMonthSequence += "010111010100" 'Year 1346H
        HijriMonthSequence += "101011101010" 'Year 1347H
        HijriMonthSequence += "010011011101" 'Year 1348H
        HijriMonthSequence += "001001101110" 'Year 1349H
        HijriMonthSequence += "100100101110" 'Year 1350H
        HijriMonthSequence += "101010100110" 'Year 1351H
        HijriMonthSequence += "110101010100" 'Year 1352H
        HijriMonthSequence += "110110101010" 'Year 1353H
        HijriMonthSequence += "010110110101" 'Year 1354H
        HijriMonthSequence += "001010110110" 'Year 1355H
        HijriMonthSequence += "100100110111" 'Year 1356H
        HijriMonthSequence += "010010011011" 'Year 1357H
        HijriMonthSequence += "101001001011" 'Year 1358H
        HijriMonthSequence += "101100100101" 'Year 1359H
        HijriMonthSequence += "101101010100" 'Year 1360H
        HijriMonthSequence += "101101101010" 'Year 1361H
        HijriMonthSequence += "010101101101" 'Year 1362H
        HijriMonthSequence += "010010101101" 'Year 1363H
        HijriMonthSequence += "101001010101" 'Year 1364H
        HijriMonthSequence += "110100100101" 'Year 1365H
        HijriMonthSequence += "111010010010" 'Year 1366H
        HijriMonthSequence += "111011001001" 'Year 1367H
        HijriMonthSequence += "011011010100" 'Year 1368H
        HijriMonthSequence += "101011101010" 'Year 1369H
        HijriMonthSequence += "010101101011" 'Year 1370H
        HijriMonthSequence += "010010101011" 'Year 1371H
        HijriMonthSequence += "011010010101" 'Year 1372H
        HijriMonthSequence += "101101001001" 'Year 1373H
        HijriMonthSequence += "101110100100" 'Year 1374H
        HijriMonthSequence += "101110110010" 'Year 1375H
        HijriMonthSequence += "010110110101" 'Year 1376H
        HijriMonthSequence += "001010111010" 'Year 1377H
        HijriMonthSequence += "100101011011" 'Year 1378H
        HijriMonthSequence += "010010101011" 'Year 1379H
        HijriMonthSequence += "010101010101" 'Year 1380H
        HijriMonthSequence += "011010110010" 'Year 1381H
        HijriMonthSequence += "011011011001" 'Year 1382H
        HijriMonthSequence += "001011101100" 'Year 1383H
        HijriMonthSequence += "100101101110" 'Year 1384H
        HijriMonthSequence += "010010101110" 'Year 1385H
        HijriMonthSequence += "101001010110" 'Year 1386H
        HijriMonthSequence += "110100101010" 'Year 1387H
        HijriMonthSequence += "110101010101" 'Year 1388H
        HijriMonthSequence += "010110101010" 'Year 1389H
        HijriMonthSequence += "101010110101" 'Year 1390H
        HijriMonthSequence += "010010111011" 'Year 1391H
        HijriMonthSequence += "001001011011" 'Year 1392H
        HijriMonthSequence += "100100101011" 'Year 1393H
        HijriMonthSequence += "101010010101" 'Year 1394H
        HijriMonthSequence += "101101001010" 'Year 1395H
        HijriMonthSequence += "101110100101" 'Year 1396H
        HijriMonthSequence += "010110101010" 'Year 1397H
        HijriMonthSequence += "101010110101" 'Year 1398H
        HijriMonthSequence += "010101010110" 'Year 1399H
        HijriMonthSequence += "101010010110" 'Year 1400H
        HijriMonthSequence += "110101001010" 'Year 1401H
        HijriMonthSequence += "111010100101" 'Year 1402H
        HijriMonthSequence += "011101010010" 'Year 1403H
        HijriMonthSequence += "011011101001" 'Year 1404H
        HijriMonthSequence += "001101101010" 'Year 1405H
        HijriMonthSequence += "101010101101" 'Year 1406H
        HijriMonthSequence += "010101010101" 'Year 1407H
        HijriMonthSequence += "101010100101" 'Year 1408H
        HijriMonthSequence += "101101010010" 'Year 1409H
        HijriMonthSequence += "101110101001" 'Year 1410H
        HijriMonthSequence += "010110110100" 'Year 1411H
        HijriMonthSequence += "100110111010" 'Year 1412H
        HijriMonthSequence += "010011011011" 'Year 1413H
        HijriMonthSequence += "001001011101" 'Year 1414H
        HijriMonthSequence += "010100101101" 'Year 1415H
        HijriMonthSequence += "101010100101" 'Year 1416H
        HijriMonthSequence += "101011010100" 'Year 1417H
        HijriMonthSequence += "101011101010" 'Year 1418H
        HijriMonthSequence += "010101101101" 'Year 1419H
        HijriMonthSequence += "010010111101" 'Year 1420H
        HijriMonthSequence += "001000111101" 'Year 1421H
        HijriMonthSequence += "100100011101" 'Year 1422H
        HijriMonthSequence += "101010010101" 'Year 1423H
        HijriMonthSequence += "101101001010" 'Year 1424H
        HijriMonthSequence += "101101011010" 'Year 1425H
        HijriMonthSequence += "010101101101" 'Year 1426H
        HijriMonthSequence += "001010110110" 'Year 1427H
        HijriMonthSequence += "100100111011" 'Year 1428H
        HijriMonthSequence += "010010011011" 'Year 1429H
        HijriMonthSequence += "011001010101" 'Year 1430H
        HijriMonthSequence += "011010101001" 'Year 1431H
        HijriMonthSequence += "011101010100" 'Year 1432H
        HijriMonthSequence += "101101101010" 'Year 1433H
        HijriMonthSequence += "010101101100" 'Year 1434H
        HijriMonthSequence += "101010101101" 'Year 1435H
        HijriMonthSequence += "010101010101" 'Year 1436H
        HijriMonthSequence += "101100101001" 'Year 1437H
        HijriMonthSequence += "101110010010" 'Year 1438H
        HijriMonthSequence += "101110101001" 'Year 1439H
        HijriMonthSequence += "010111010100" 'Year 1440H
        HijriMonthSequence += "101011011010" 'Year 1441H
        HijriMonthSequence += "010101011010" 'Year 1442H
        HijriMonthSequence += "101010101011" 'Year 1443H
        HijriMonthSequence += "010110010101" 'Year 1444H
        HijriMonthSequence += "011101001001" 'Year 1445H
        HijriMonthSequence += "011101100100" 'Year 1446H
        HijriMonthSequence += "101110101010" 'Year 1447H
        HijriMonthSequence += "010110110101" 'Year 1448H
        HijriMonthSequence += "001010110110" 'Year 1449H
        HijriMonthSequence += "101001010110" 'Year 1450H
        Return HijriMonthSequence
    End Function
#End Region

    ' Function DateFormating(ByVal _Date As String) As String
#Region " DateFormating( _Date As String) As String "
    Public Function DateFormating(ByVal _Date As String) As String

        '  / تجزئة نص التاريخ من الفاصل 
        Dim dt() As String = Split(_Date, "/")
        Dim i As Integer
        '------------------------------------------------------
        ' في حالة عدم وجود فاصل تاريخ أصلا فيتم المغادرة
        If dt.Length <> 3 Then Return ""

        '------------------------------------------------------
        ' التأكد أن أجزاء التاريخ هي أرقام فعلا
        For i = 0 To dt.Length - 1
            If Not IsNumeric(dt(i)) Then
                Return ""
            End If
        Next i

        '------------------------------------------------------
        ' ترتيب التاريخ بحيث يبدأ باليوم وينتهي السنة
        If Val(dt(0)) > 999 And Val(dt(2)) < 99 Then
            Dim a As String = Val(dt(0))
            Dim b As String = Val(dt(2))
            dt(0) = b : dt(2) = a
        End If

        '------------------------------------------------------
        ' التأكد من عدم تجاوز كل جزء الحدود المسموح له
        If Val(dt(2)) < 1301 Or Val(dt(2)) > 2029 Then Return ""

        ' عدم تجاوز الشهر عن 12
        If Val(dt(1)) < 1 _
        Or Val(dt(1)) > 12 Then
            Return ""
        End If

        ' عدم تجاوز اليوم الهجري عن 30
        If Val(dt(2)) >= 1301 _
        And Val(dt(2)) <= 1450 Then
            If Val(dt(0)) < 1 Or Val(dt(0)) > 30 Then Return ""
        End If

        '------------------------------------------------------

        Dim y As Integer, m As Integer, d As Integer
        d = Val(dt(0)).ToString("00")
        m = Val(dt(1)).ToString("00")
        y = Val(dt(2)).ToString("0000")

        Return Val(dt(0)).ToString("00") _
       & "/" & Val(dt(1)).ToString("00") _
       & "/" & Val(dt(2)).ToString("0000")

    End Function

#End Region

    '#End Region


#Region " ArabicWeekdayString "
    Private Function ArabicWeekdayString(ByVal weekdayValue As Integer)
        Dim w As String = String.Empty
        Select Case weekdayValue
            Case 7
                w = "السبت"
            Case 1
                w = "الاحد"
            Case 2
                w = "الاثنين"
            Case 3
                w = "الثلاثاء"
            Case 4
                w = "الاربعاء"
            Case 5
                w = "الخميس"
            Case 6
                w = "الجمعة"
        End Select
        Return w
    End Function
#End Region

#Region " HiriMonthString "
    Private Function HiriMonthString(ByVal hijriMonthValue As Integer)
        Dim m As String = String.Empty
        Select Case hijriMonthValue
            Case 1
                m = "محرم"
            Case 2
                m = "صفر"
            Case 3
                m = "ربيع الأول"
            Case 4
                m = "ربيع الثاني"
            Case 5
                m = "جمادى الأولى"
            Case 6
                m = "جمادى الثانية"
            Case 7
                m = "رجب"
            Case 8
                m = "شعبان"
            Case 9
                m = "رمضان"
            Case 10
                m = "شوال"
            Case 11
                m = "ذو القعدة"
            Case 12
                m = "ذو الحجة"
        End Select
        Return m
    End Function
#End Region

#Region " GregorianMonthString "
    Private Function GregorianMonthString(ByVal gregorianMonthValue As Integer)
        Dim m As String = String.Empty
        Select Case gregorianMonthValue
            Case 1
                m = "يناير/كانون الثاني"
            Case 2
                m = "فبراير/شباط"
            Case 3
                m = "مارس/آذار"
            Case 4
                m = "أبريل/نيسان"
            Case 5
                m = "مايو/أيار"
            Case 6
                m = "يونيو/حزيران"
            Case 7
                m = "يوليو/تموز"
            Case 8
                m = "أغسطس/آب"
            Case 9
                m = "سبتمبر/أيلول"
            Case 10
                m = "أكتوبر/تشرين الأول"
            Case 11
                m = "نوفمبر/تشرين الثاني"
            Case 12
                m = "ديسمبر/كانون الأول"
        End Select
        Return m
    End Function
#End Region


End Module

