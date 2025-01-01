
'This is a very powerful module that is capable of carrying out operations
'related to colors (including color mixing, blend modes, etc.)

'The blend modes are based on the blend modes of Adobe Photoshop but may
'not identically reproduce the effects.

'The color converter allows for conversion of colors between color spaces
'and from various color formats

Module ModColorFunctions

#Region " Basic Functions "

    'This function provides an easy way to convert RGB values to a color.
    Public Function CRGB(ByVal r As Integer, ByVal g As Integer, ByVal b As Integer) As Color
        If r > 255 Then r = 255
        If r < 0 Then r = 0
        If g > 255 Then g = 255
        If g < 0 Then g = 0
        If b > 255 Then b = 255
        If b < 0 Then b = 0
        CRGB = ColorTranslator.FromWin32(RGB(r, g, b))
    End Function

    Public Function CHSB(ByVal hue As Single, ByVal saturation As Single, ByVal brightness As Single) As Color
        If hue < 0 Then hue = 0
        If hue > 359 Then hue -= 360
        If saturation < 0 Then saturation = 0
        If saturation > 1 Then saturation = 1
        If brightness < 0 Then brightness = 0
        If brightness > 1 Then brightness = 1

        'Debug.Write(vbCrLf & hue & ", " & saturation & ", " & brightness)

        Dim v1, v2, vh As Single
        Dim r, g, b As Integer

        If saturation = 0 Then
            CHSB = CRGB(brightness * 255, brightness * 255, brightness * 255)
        Else
            If brightness < 0.5 Then
                v2 = brightness * (1 + saturation)
            Else
                v2 = brightness + saturation - (brightness * saturation)
            End If

            v1 = 2 * brightness - v2
            vh = hue / 360

            'Debug.Write(vbCrLf & v1 & ", " & v2)

            'Debug.Write(vbCrLf & Hue2RGB(v1, v2, hue + (1 / 3)) & ", " & Hue2RGB(v1, v2, hue) & ", " & Hue2RGB(v1, v2, hue - (1 / 3)))

            r = 255 * Hue2RGB(v1, v2, vh + (1 / 3))
            g = 255 * Hue2RGB(v1, v2, vh)
            b = 255 * Hue2RGB(v1, v2, vh - (1 / 3))

            CHSB = CRGB(r, g, b)
        End If
    End Function

    Private Function Hue2RGB(ByVal v1 As Single, ByVal v2 As Single, ByVal vH As Single) As Single
        If vH < 0 Then vH += 1
        If vH > 1 Then vH -= 1

        If (6 * vH) < 1 Then
            Hue2RGB = v1 + (v2 - v1) * 6 * vH
        ElseIf (2 * vH) < 1 Then
            Hue2RGB = v2
        ElseIf (3 * vH) < 2 Then
            Hue2RGB = v1 + (v2 - v1) * ((2 / 3) - vH) * 6
        Else
            Hue2RGB = v1
        End If
    End Function

    Public Function OpacityMix(ByVal BlendColor As Color, ByVal BaseColor As Color, ByVal Opacity As Integer) As Color
        Dim r1, g1, b1 As Integer
        Dim r2, g2, b2 As Integer
        Dim r3, g3, b3 As Integer

        r1 = BlendColor.R
        g1 = BlendColor.G
        b1 = BlendColor.B

        r2 = BaseColor.R
        g2 = BaseColor.G
        b2 = BaseColor.B

        r3 = (r1 * (Opacity / 100)) + (r2 * (1 - (Opacity / 100)))
        g3 = (g1 * (Opacity / 100)) + (g2 * (1 - (Opacity / 100)))
        b3 = (b1 * (Opacity / 100)) + (b2 * (1 - (Opacity / 100)))

        OpacityMix = CRGB(r3, g3, b3)
    End Function

    Public Function InvertColor(ByVal c As Color) As Color
        Dim r1, g1, b1 As Integer
        Dim r2, g2, b2 As Integer

        r1 = c.R
        g1 = c.G
        b1 = c.B

        r2 = 255 - r1
        g2 = 255 - g1
        b2 = 255 - b1

        InvertColor = CRGB(r2, g2, b2)
    End Function

#End Region
#Region " Blend Modes "

    Public Function MultiplyMix(ByVal BaseColor As Color, ByVal BlendColor As Color, ByVal Opacity As Integer) As Color
        Dim r1, g1, b1 As Integer
        Dim r2, g2, b2 As Integer
        Dim r3, g3, b3 As Integer

        r1 = BaseColor.R
        g1 = BaseColor.G
        b1 = BaseColor.B

        r2 = BlendColor.R
        g2 = BlendColor.G
        b2 = BlendColor.B

        r3 = r1 * r2 / 255
        g3 = g1 * g2 / 255
        b3 = b1 * b2 / 255

        MultiplyMix = OpacityMix(CRGB(r3, g3, b3), BaseColor, Opacity)
    End Function

    Public Function SoftLightMix(ByVal BaseColor As Color, ByVal BlendColor As Color, ByVal Opacity As Integer) As Color
        Dim r1, g1, b1 As Integer
        Dim r2, g2, b2 As Integer
        Dim r3, g3, b3 As Integer

        r1 = BaseColor.R
        g1 = BaseColor.G
        b1 = BaseColor.B

        r2 = BlendColor.R
        g2 = BlendColor.G
        b2 = BlendColor.B

        r3 = SoftLightMath(r1, r2)
        g3 = SoftLightMath(g1, g2)
        b3 = SoftLightMath(b1, b2)

        SoftLightMix = OpacityMix(CRGB(r3, g3, b3), BaseColor, Opacity)
    End Function

    Public Function OverlayMix(ByVal BaseColor As Color, ByVal BlendColor As Color, ByVal opacity As Integer) As Color
        Dim r1, g1, b1 As Integer
        Dim r2, g2, b2 As Integer
        Dim r3, g3, b3 As Integer

        r1 = BaseColor.R
        g1 = BaseColor.G
        b1 = BaseColor.B

        r2 = BlendColor.R
        g2 = BlendColor.G
        b2 = BlendColor.B

        r3 = OverlayMath(BaseColor.R, BlendColor.R)
        g3 = OverlayMath(BaseColor.G, BlendColor.G)
        b3 = OverlayMath(BaseColor.B, BlendColor.B)

        OverlayMix = OpacityMix(CRGB(r3, g3, b3), BaseColor, opacity)
    End Function

#End Region

#Region " Blend Mode Mathematics "

    Private Function SoftLightMath(ByVal base As Integer, ByVal blend As Integer) As Integer
        Dim dbase As Single
        Dim dblend As Single

        dbase = base / 255
        dblend = blend / 255

        If dblend < 0.5 Then
            SoftLightMath = ((2 * dbase * dblend) + (dbase ^ 2) * (1 - (2 * dblend))) * 255
        Else
            SoftLightMath = ((Math.Sqrt(dbase) * (2 * dblend - 1)) + (2 * dbase * (1 - dblend))) * 255
        End If
    End Function

    Public Function OverlayMath(ByVal base As Integer, ByVal blend As Integer) As Integer
        Dim dbase, dblend As Double

        dbase = base / 255
        dblend = blend / 255

        If dbase < 0.5 Then
            OverlayMath = 2 * dbase * dblend * 255
        Else
            OverlayMath = (1 - (2 * (1 - dbase) * (1 - dblend))) * 255
        End If
    End Function

#End Region

End Module


