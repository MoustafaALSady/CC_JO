

Module Module_barcood

    Public Declare Function SetWindowPos Lib "user32.dll" (ByVal hwnd As Int32, ByVal hWndInsertAfter As Int32, ByVal x As Int32, ByVal y As Int32, ByVal cx As Int32, ByVal cy As Int32, ByVal wFlags As Int32) As Int32
    Public Const HWND_TOPMOST = -1
    Public Const HWND_NOTOPMOST = -2
    Public Const SWP_NOSIZE = &H1
    Public Const SWP_NOMOVE = &H2
    Public Const SWP_NOACTIVATE = &H10
    Public Const SWP_SHOWWINDOW = &H40
    'دوال رسم الباركود

    Function Code128(ByVal TheText As String, ByVal CodeLetter As String) As Image
        ' TheText متغير خاص بالنص المراد تشفيره
        ' CodeLetter متغير خاص بالفئة المراد استخدامها

        Dim Binaryz As String = "" 'متغير سيحمل النص بعد تحويله إلى باينرى
        Dim I As Integer
        Dim NumCode As Integer 'متغير سيحمل  قيمة حساب النص التكميلى
        If CodeLetter = "A" Or CodeLetter = "a" Then
            NumCode = 103
            Binaryz = "00101111011"
        End If
        If CodeLetter = "B" Or CodeLetter = "b" Then
            NumCode = 104
            Binaryz = "00101101111"
        End If
        If CodeLetter = "C" Or CodeLetter = "c" Then
            NumCode = 105
            Binaryz = "00101100011"
        End If
        ' الكود التالى سيقوم باسناد قيمة الحرف بالباينرى حسب الجدول الخاص بالكود 128
        For I = 1 To Len(TheText)
            NumCode += (Asc(Mid(TheText, I, 1)) - 32) * I
            Select Case Asc(Mid(TheText, I, 1))
                Case 32
                    Binaryz &= "00100110011"
                Case 33
                    Binaryz &= "00110010011"
                Case 34
                    Binaryz &= "00110011001"
                Case 35
                    Binaryz &= "01101100111"
                Case 36
                    Binaryz &= "01101110011"
                Case 37
                    Binaryz &= "01110110011"
                Case 38
                    Binaryz &= "01100110111"
                Case 39
                    Binaryz &= "01100111011"
                Case 40
                    Binaryz &= "01110011011"
                Case 41
                    Binaryz &= "00110110111"
                Case 42
                    Binaryz &= "00110111011"
                Case 43
                    Binaryz &= "00111011011"
                Case 44
                    Binaryz &= "01001100011"
                Case 45
                    Binaryz &= "01100100011"
                Case 46
                    Binaryz &= "01100110001"
                Case 47
                    Binaryz &= "01000110011"
                Case 48
                    Binaryz &= "01100010011"
                Case 49
                    Binaryz &= "01100011001"
                Case 50
                    Binaryz &= "00110001101"
                Case 51
                    Binaryz &= "00110100011"
                Case 52
                    Binaryz &= "00110110001"
                Case 53
                    Binaryz &= "00100011011"
                Case 54
                    Binaryz &= "00110001011"
                Case 55
                    Binaryz &= "00010010001"
                Case 56
                    Binaryz &= "00010110011"
                Case 57
                    Binaryz &= "00011010011"
                Case 58
                    Binaryz &= "00011011001"
                Case 59
                    Binaryz &= "00010011011"
                Case 60
                    Binaryz &= "00011001011"
                Case 61
                    Binaryz &= "00011001101"
                Case 62
                    Binaryz &= "00100100111"
                Case 63
                    Binaryz &= "00100111001"
                Case 64
                    Binaryz &= "00111001001"
                Case 65
                    Binaryz &= "01011100111"
                Case 66
                    Binaryz &= "01110100111"
                Case 67
                    Binaryz &= "01110111001"
                Case 68
                    Binaryz &= "01001110111"
                Case 69
                    Binaryz &= "01110010111"
                Case 70
                    Binaryz &= "01110011101"
                Case 71
                    Binaryz &= "00101110111"
                Case 72
                    Binaryz &= "00111010111"
                Case 73
                    Binaryz &= "00111011101"
                Case 74
                    Binaryz &= "01001000111"
                Case 75
                    Binaryz &= "01001110001"
                Case 76
                    Binaryz &= "01110010001"
                Case 77
                    Binaryz &= "01000100111"
                Case 78
                    Binaryz &= "01000111001"
                Case 79
                    Binaryz &= "01110001001"
                Case 80
                    Binaryz &= "00010001001"
                Case 81
                    Binaryz &= "00101110001"
                Case 82
                    Binaryz &= "00111010001"
                Case 83
                    Binaryz &= "00100010111"
                Case 84
                    Binaryz &= "00100011101"
                Case 85
                    Binaryz &= "00100010001"
                Case 86
                    Binaryz &= "00010100111"
                Case 87
                    Binaryz &= "00010111001"
                Case 88
                    Binaryz &= "00011101001"
                Case 89
                    Binaryz &= "00010010111"
                Case 90
                    Binaryz &= "00010011101"
                Case 91
                    Binaryz &= "00011100101"
                Case 92
                    Binaryz &= "00010000101"
                Case 93
                    Binaryz &= "00110111101"
                Case 94
                    Binaryz &= "00001110101"
                Case 95
                    Binaryz &= "01011001111"
                Case 96
                    Binaryz &= "01011110011"
                Case 97
                    Binaryz &= "01101001111"
                Case 98
                    Binaryz &= "01101111001"
                Case 99
                    Binaryz &= "01111010011"
                Case 100
                    Binaryz &= "01111011001"
                Case 101
                    Binaryz &= "01001101111"
                Case 102
                    Binaryz &= "01001111011"
                Case 103
                    Binaryz &= "01100101111"
                Case 104
                    Binaryz &= "01100111101"
                Case 105
                    Binaryz &= "01111001011"
                Case 106
                    Binaryz &= "01111001101"
                Case 107
                    Binaryz &= "00111101101"
                Case 108
                    Binaryz &= "00110101111"
                Case 109
                    Binaryz &= "00001000101"
                Case 110
                    Binaryz &= "00111101011"
                Case 111
                    Binaryz &= "01110000101"
                Case 112
                    Binaryz &= "01011000011"
                Case 113
                    Binaryz &= "01101000011"
                Case 114
                    Binaryz &= "01101100001"
                Case 115
                    Binaryz &= "01000011011"
                Case 116
                    Binaryz &= "01100001011"
                Case 117
                    Binaryz &= "01100001101"
                Case 118
                    Binaryz &= "00001011011"
                Case 119
                    Binaryz &= "00001101011"
                Case 120
                    Binaryz &= "00001101101"
                Case 121
                    Binaryz &= "00100100001"
                Case 122
                    Binaryz &= "00100001001"
                Case 123
                    Binaryz &= "00001001001"
                Case 124
                    Binaryz &= "01010000111"
                Case 125
                    Binaryz &= "01011100001"
                Case 126
                    Binaryz &= "01110100001"
                Case 127
                    Binaryz &= "01000010111"
                Case 128
                    Binaryz &= "01000011101"
                Case 129
                    Binaryz &= "00001010111"
                Case 130
                    Binaryz &= "00001011101"
                Case 131
                    Binaryz &= "01000100001"
                Case 132
                    Binaryz &= "01000010001"
                Case 133
                    Binaryz &= "00010100001"
                Case 134
                    Binaryz &= "00001010001"
                Case 135
                    Binaryz &= "00101111011"
                Case 136
                    Binaryz &= "00101101111"
                Case 137
                    Binaryz &= "00101100011"
                Case 138
                    Binaryz &= "0011100010100"
            End Select
        Next
        NumCode = NumCode Mod 103
        ' الكود التالى لمعرفة الحرف المراد اضافتة لاستكمال النص
        Select Case NumCode
            Case 0
                Binaryz &= "00100110011"
            Case 1
                Binaryz &= "00110010011"
            Case 2
                Binaryz &= "00110011001"
            Case 3
                Binaryz &= "01101100111"
            Case 4
                Binaryz &= "01101110011"
            Case 5
                Binaryz &= "01110110011"
            Case 6
                Binaryz &= "01100110111"
            Case 7
                Binaryz &= "01100111011"
            Case 8
                Binaryz &= "01110011011"
            Case 9
                Binaryz &= "00110110111"
            Case 10
                Binaryz &= "00110111011"
            Case 11
                Binaryz &= "00111011011"
            Case 12
                Binaryz &= "01001100011"
            Case 13
                Binaryz &= "01100100011"
            Case 14
                Binaryz &= "01100110001"
            Case 15
                Binaryz &= "01000110011"
            Case 16
                Binaryz &= "01100010011"
            Case 17
                Binaryz &= "01100011001"
            Case 18
                Binaryz &= "00110001101"
            Case 19
                Binaryz &= "00110100011"
            Case 20
                Binaryz &= "00110110001"
            Case 21
                Binaryz &= "00100011011"
            Case 22
                Binaryz &= "00110001011"
            Case 23
                Binaryz &= "00010010001"
            Case 24
                Binaryz &= "00010110011"
            Case 25
                Binaryz &= "00011010011"
            Case 26
                Binaryz &= "00011011001"
            Case 27
                Binaryz &= "00010011011"
            Case 28
                Binaryz &= "00011001011"
            Case 29
                Binaryz &= "00011001101"
            Case 30
                Binaryz &= "00100100111"
            Case 31
                Binaryz &= "00100111001"
            Case 32
                Binaryz &= "00111001001"
            Case 33
                Binaryz &= "01011100111"
            Case 34
                Binaryz &= "01110100111"
            Case 35
                Binaryz &= "01110111001"
            Case 36
                Binaryz &= "01001110111"
            Case 37
                Binaryz &= "01110010111"
            Case 38
                Binaryz &= "01110011101"
            Case 39
                Binaryz &= "00101110111"
            Case 40
                Binaryz &= "00111010111"
            Case 41
                Binaryz &= "00111011101"
            Case 42
                Binaryz &= "01001000111"
            Case 43
                Binaryz &= "01001110001"
            Case 44
                Binaryz &= "01110010001"
            Case 45
                Binaryz &= "01000100111"
            Case 46
                Binaryz &= "01000111001"
            Case 47
                Binaryz &= "01110001001"
            Case 48
                Binaryz &= "00010001001"
            Case 49
                Binaryz &= "00101110001"
            Case 50
                Binaryz &= "00111010001"
            Case 51
                Binaryz &= "00100010111"
            Case 52
                Binaryz &= "00100011101"
            Case 53
                Binaryz &= "00100010001"
            Case 54
                Binaryz &= "00010100111"
            Case 55
                Binaryz &= "00010111001"
            Case 56
                Binaryz &= "00011101001"
            Case 57
                Binaryz &= "00010010111"
            Case 58
                Binaryz &= "00010011101"
            Case 59
                Binaryz &= "00011100101"
            Case 60
                Binaryz &= "00010000101"
            Case 61
                Binaryz &= "00110111101"
            Case 62
                Binaryz &= "00001110101"
            Case 63
                Binaryz &= "01011001111"
            Case 64
                Binaryz &= "01011110011"
            Case 65
                Binaryz &= "01101001111"
            Case 66
                Binaryz &= "01101111001"
            Case 67
                Binaryz &= "01111010011"
            Case 68
                Binaryz &= "01111011001"
            Case 69
                Binaryz &= "01001101111"
            Case 70
                Binaryz &= "01001111011"
            Case 71
                Binaryz &= "01100101111"
            Case 72
                Binaryz &= "01100111101"
            Case 73
                Binaryz &= "01111001011"
            Case 74
                Binaryz &= "01111001101"
            Case 75
                Binaryz &= "00111101101"
            Case 76
                Binaryz &= "00110101111"
            Case 77
                Binaryz &= "00001000101"
            Case 78
                Binaryz &= "00111101011"
            Case 79
                Binaryz &= "01110000101"
            Case 80
                Binaryz &= "01011000011"
            Case 81
                Binaryz &= "01101000011"
            Case 82
                Binaryz &= "01101100001"
            Case 83
                Binaryz &= "01000011011"
            Case 84
                Binaryz &= "01100001011"
            Case 85
                Binaryz &= "01100001101"
            Case 86
                Binaryz &= "00001011011"
            Case 87
                Binaryz &= "00001101011"
            Case 88
                Binaryz &= "00001101101"
            Case 89
                Binaryz &= "00100100001"
            Case 90
                Binaryz &= "00100001001"
            Case 91
                Binaryz &= "00001001001"
            Case 92
                Binaryz &= "01010000111"
            Case 93
                Binaryz &= "01011100001"
            Case 94
                Binaryz &= "01110100001"
            Case 95
                Binaryz &= "01000010111"
            Case 96
                Binaryz &= "01000011101"
            Case 97
                Binaryz &= "00001010111"
            Case 98
                Binaryz &= "00001011101"
            Case 99
                Binaryz &= "01000100001"
            Case 100
                Binaryz &= "01000010001"
            Case 101
                Binaryz &= "00010100001"
            Case 102
                Binaryz &= "00001010001"
        End Select
        Binaryz &= "0011100010100" ' انهاء الكود باضافة الباينرى الخاص بايقاف جميع الاكواد

        ' انشاء صورة عرضها عدد حروف الباينرى المستخدم
        Dim bmp As New Bitmap(Len(Binaryz), 60, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        Dim z As String ' متغير لمعرفة لون الخط 
        Dim GraphZ As Graphics = Graphics.FromImage(bmp)
        Dim RectZ As New Rectangle(0, 0, bmp.Width, bmp.Height) ' مستطيل بحجم الصورة لاعطاء الخلفية باللون الابيض
        ' فرشاه لدهان المستطيل السابق باللون الابيض
        Dim myBrush As Brush = New Drawing2D.LinearGradientBrush(RectZ, Color.White, Color.White, Drawing.Drawing2D.LinearGradientMode.ForwardDiagonal)
        ' دهان المستطيل السابق باللون الابيض
        GraphZ.FillRectangle(myBrush, RectZ)
        '  رسم خطوط الباركود
        Dim PenZ As Pen
        Dim point1 As Point ' نقطة بداية الخط
        Dim point2 As Point ' نقطة نهاية الخط
        For I = 1 To Len(Binaryz)
            z = Mid(Binaryz, I, 1)
            If z = "0" Then
                PenZ = New Pen(Color.Black, 1)
                point1 = New Point(I, 0)
                point2 = New Point(I, 40)
                GraphZ.DrawLine(PenZ, point1, point2)
            Else
                PenZ = New Pen(Color.White, 1)
                point1 = New Point(I, 0)
                point2 = New Point(I, 40)
                GraphZ.DrawLine(PenZ, point1, point2)
            End If
        Next
        ' رسم النص المراد ترميزه اسفل الكود
        GraphZ.DrawString(TheText, New Font("times new roman", 12, FontStyle.Bold), New SolidBrush(Color.DarkBlue), 20, 40)
        ' ارجاع الصورة النهائية للدالة
        Code128 = bmp
    End Function
    Function Toc(ByVal Text2CStr As String) As String
        ' دالة لتعويض النص المطلوب تشفيره بالارقام للفئة 
        ' (C)
        Dim X As Integer = 1
        Dim NewText As String = ""

        Do
            Dim Z As String = Mid(Text2CStr, X, 2)
            ' اضافة رقم32 لقيمة الاسكى واستعادة الحرف الناتج بعد الاضافة
            NewText &= Chr(Val(Z) + 32)
            X += 2
            Z = Mid(Text2CStr, X, 1)
            If X >= Len(Text2CStr) Then Exit Do
            If Z = "" Then Exit Do
        Loop
        Toc = NewText
    End Function



End Module
