
'This is a very powerful module that is capable of carrying out operations
'related to colors (including color mixing, blend modes, etc.)

'The blend modes are based on the blend modes of Adobe Photoshop but may
'not identically reproduce the effects.

'The color converter allows for conversion of colors between color spaces
'and from various color formats


#Region " Color Converter "

Public Class ColorConversion

    Private ReadOnly _Color As Color

#Region " New "
    Public Sub New(ByVal inputColor As Color)
        _Color = inputColor
    End Sub

    Public Sub New(ByVal r As Byte, ByVal g As Byte, ByVal b As Byte)
        _Color = CRGB(r, g, b)
    End Sub

    Public Sub New(ByVal Hue As Single, ByVal Saturation As Single, ByVal Brightness As Single, ByVal hsb As Boolean)
        _Color = CHSB(Hue, Saturation, Brightness)
        Me.Hsb = hsb
    End Sub

    Public Sub New(ByVal Hexadecimal As String)
        _Color = ColorTranslator.FromHtml(Hexadecimal)
    End Sub

    Public Sub New(ByVal Win32 As Integer)
        _Color = ColorTranslator.FromWin32(Win32)
    End Sub

#End Region

    ReadOnly Property Color() As Color
        Get
            Return _Color
        End Get
    End Property

    ReadOnly Property R() As Byte
        Get
            Return _Color.R
        End Get
    End Property

    ReadOnly Property G() As Byte
        Get
            Return _Color.G
        End Get
    End Property

    ReadOnly Property B() As Byte
        Get
            Return _Color.B
        End Get
    End Property

    ReadOnly Property Hue() As Single
        Get
            Return Convert.ToInt32(_Color.GetHue)
        End Get
    End Property

    ReadOnly Property Saturation() As Single
        Get
            Return _Color.GetSaturation
        End Get
    End Property

    ReadOnly Property Brightness() As Single
        Get
            Return _Color.GetBrightness
        End Get
    End Property

    ReadOnly Property Hexadecimal() As String
        Get
            Return "#" & FixHex(Hex(_Color.R)) & FixHex(Hex(_Color.G)) & FixHex(Hex(_Color.B))
        End Get
    End Property

    ReadOnly Property Win32() As Int32
        Get
            Return ColorTranslator.ToWin32(_Color)
        End Get
    End Property

    Public ReadOnly Property Hsb As Boolean

    Private Shared Function FixHex(ByVal hex As String) As String
        If hex.Length < 2 Then
            FixHex = "0" & hex
        Else
            FixHex = hex
        End If
    End Function

End Class

#End Region
