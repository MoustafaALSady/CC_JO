'This class collection is the core drawing engine that control the drawing of
'the entire FreeStyle Button. Although it currently lacks much commenting, it
'fairly easy to understand. 


'The following are the notes regarding problems, updates, and todos:

'Note #1: In the draw text of each theme you may notice that "                " 
'is added after the text. This is to ensure that the text is drawn correctly
'centered.

'Note #2: The current code for the themes is a little glitchy and needs to be
'reworked. The upcoming version will have the entire theme codes rewritten,
'along with a universal drawtext which will be able to handle numerous effects
'applicable to all themes, as well picture support, and crisp path drawn shapes.

'Note #3: Currently not all themes support theme color modification however
'the upcoming version will change the code to support color modification in all
'the themes.

'Note #4: The 'My' rectangle will be replaced with 'Sender' object in the future
'version.

Namespace Theme

    Public Enum States
        Normal
        Focused
        MouseOver
        MouseDown
        Disabled
    End Enum

#Region " Liquid Chrome XP (Default) Theme "
    Public Class LiquidChromeXP

        Private My As Rectangle
        Private TextEffects As Boolean

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Shared Sub FillRoundedRectangle(ByVal b As Brush, ByVal Radius As Integer, ByVal Rect As Rectangle, ByVal e As PaintEventArgs)
            Dim TL, TR, BL, BR As Point 'The four corners of the rectabgle

            'Set the values of each corner point
            TL = New Point(Rect.Left, Rect.Top)
            TR = New Point(Rect.Left + Rect.Width, Rect.Top)
            BL = New Point(Rect.Left, Rect.Top + Rect.Height)
            BR = New Point(Rect.Left + Rect.Width, Rect.Top + Rect.Height)

            'Draws the four corner circles
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias 'Changes smoothing mode to anti-alias to remove jagged edges
            e.Graphics.FillEllipse(b, New Rectangle(TL.X, TL.Y, Radius * 2, Radius * 2)) 'Top-left circle
            e.Graphics.FillEllipse(b, New Rectangle(BL.X, BL.Y - (Radius * 2) - 1, Radius * 2, Radius * 2)) 'Bottom-left circle
            e.Graphics.FillEllipse(b, New Rectangle(TR.X - (Radius * 2) - 1, TR.Y, Radius * 2, Radius * 2)) 'Top-right circle
            e.Graphics.FillEllipse(b, New Rectangle(BR.X - (Radius * 2) - 1, BR.Y - (Radius * 2) - 1, Radius * 2, Radius * 2)) 'Bottom-right circle

            'Draws the two blocks
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default 'Returns the smoothing mode to default for a crisp structure
            e.Graphics.FillRectangle(b, New Rectangle(TL.X, TL.Y + Radius, Rect.Width, Rect.Height - (Radius * 2)))
            e.Graphics.FillRectangle(b, New Rectangle(TL.X + Radius, TL.Y, Rect.Width - (Radius * 2), Rect.Height))
        End Sub

        Private Sub DrawBase(ByVal e As PaintEventArgs, ByVal state As States)
            Dim b As Brush
            If state = States.Disabled Then
                b = New SolidBrush(CRGB(201, 199, 186))
            Else
                b = New SolidBrush(CRGB(35, 55, 85))
            End If
            FillRoundedRectangle(b, 4, New Rectangle(0, 0, My.Width, My.Height), e)
        End Sub

        Private Sub DrawDisabledButtonBody(ByVal e As PaintEventArgs)
            Dim b As Brush
            b = New SolidBrush(CRGB(245, 244, 234))
            FillRoundedRectangle(b, 3, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)
        End Sub


        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(CRGB(153, 214, 255))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(CRGB(0, 122, 204))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            b = New SolidBrush(CRGB(0, 153, 255))
            FillRoundedRectangle(b, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)

            c1 = CRGB(238, 240, 241)
            c2 = CRGB(206, 209, 214)
            c3 = Color.White

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c2)
            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0, 0.75, 1}
            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            FillRoundedRectangle(lgb, 1, New Rectangle(3, 3, My.Width - 6, My.Height - 6), e)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush

            b = New SolidBrush(CRGB(137, 141, 146))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(CRGB(255, 255, 255))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)


            c1 = CRGB(170, 175, 185)
            c2 = CRGB(230, 232, 234)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c2) With {
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 1, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)

        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(CRGB(255, 214, 153))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(CRGB(204, 122, 0))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            b = New SolidBrush(CRGB(255, 153, 0))
            FillRoundedRectangle(b, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)

            c1 = CRGB(243, 244, 245)
            c2 = CRGB(218, 221, 224)
            c3 = Color.White

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c2)
            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0, 0.75, 1}
            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            FillRoundedRectangle(lgb, 1, New Rectangle(3, 3, My.Width - 6, My.Height - 6), e)

        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(Color.White)
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(CRGB(185, 185, 185))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            c1 = CRGB(238, 240, 241)
            c2 = CRGB(206, 209, 214)
            c3 = Color.White

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3)
            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.75, 1.0}
            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            FillRoundedRectangle(lgb, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)
        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean)
            DrawBase(e, state)
            TextEffects = textfx
            If state = Theme.States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawDisabledButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)

            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.5 * 255, Color.White))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.5 * 255, Color.White))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub

    End Class
#End Region

#Region " Soft Glass XP Theme "
    Public Class SoftGlassXP

        Private My As Rectangle
        Private ThemeColor As Color
        Private TextEffects As Boolean

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Shared Sub FillRoundedRectangle(ByVal b As Brush, ByVal Radius As Integer, ByVal Rect As Rectangle, ByVal e As PaintEventArgs)
            Dim TL, TR, BL, BR As Point 'The four corners of the rectabgle

            'Set the values of each corner point
            TL = New Point(Rect.Left, Rect.Top)
            TR = New Point(Rect.Left + Rect.Width, Rect.Top)
            BL = New Point(Rect.Left, Rect.Top + Rect.Height)
            BR = New Point(Rect.Left + Rect.Width, Rect.Top + Rect.Height)

            'Draws the four corner circles
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias 'Changes smoothing mode to anti-alias to remove jagged edges
            e.Graphics.FillEllipse(b, New Rectangle(TL.X, TL.Y, Radius * 2, Radius * 2)) 'Top-left circle
            e.Graphics.FillEllipse(b, New Rectangle(BL.X, BL.Y - (Radius * 2) - 1, Radius * 2, Radius * 2)) 'Bottom-left circle
            e.Graphics.FillEllipse(b, New Rectangle(TR.X - (Radius * 2) - 1, TR.Y, Radius * 2, Radius * 2)) 'Top-right circle
            e.Graphics.FillEllipse(b, New Rectangle(BR.X - (Radius * 2) - 1, BR.Y - (Radius * 2) - 1, Radius * 2, Radius * 2)) 'Bottom-right circle

            'Draws the two blocks
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default 'Returns the smoothing mode to default for a crisp structure
            e.Graphics.FillRectangle(b, New Rectangle(TL.X, TL.Y + Radius, Rect.Width, Rect.Height - (Radius * 2)))
            e.Graphics.FillRectangle(b, New Rectangle(TL.X + Radius, TL.Y, Rect.Width - (Radius * 2), Rect.Height))
        End Sub

        Private Sub DrawBase(ByVal e As PaintEventArgs, ByVal s As States)
            Dim b As Brush
            If s = States.Disabled Then
                b = New SolidBrush(CRGB(201, 199, 186))
            Else
                b = New SolidBrush(OpacityMix(Color.Black, ThemeColor, 45))
            End If
            FillRoundedRectangle(b, 4, New Rectangle(0, 0, My.Width, My.Height), e)
        End Sub

        Private Sub DrawDisabledButtonBody(ByVal e As PaintEventArgs)
            Dim b As Brush
            b = New SolidBrush(CRGB(245, 244, 234))
            FillRoundedRectangle(b, 3, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)
        End Sub

        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(SoftLightMix(SoftLightMix(SoftLightMix(ThemeColor, Color.Black, 60), Color.White, 100), Color.White, 60))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(SoftLightMix(SoftLightMix(ThemeColor, Color.White, 60), Color.Black, 60))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            c1 = SoftLightMix(SoftLightMix(ThemeColor, Color.Black, 60), Color.White, 100)
            c2 = SoftLightMix(ThemeColor, CRGB(52, 52, 52), 60)
            c3 = SoftLightMix(ThemeColor, Color.White, 60)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.25, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3) With {
                .InterpolationColors = cb,
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(SoftLightMix(SoftLightMix(SoftLightMix(ThemeColor, Color.White, 40), Color.Black, 100), Color.Black, 50))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(SoftLightMix(SoftLightMix(ThemeColor, Color.Black, 60), Color.White, 100))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            c1 = SoftLightMix(SoftLightMix(ThemeColor, Color.White, 40), Color.Black, 100)
            c2 = SoftLightMix(ThemeColor, CRGB(203, 203, 203), 60)
            c3 = SoftLightMix(ThemeColor, Color.Black, 60)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.25, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3) With {
                .InterpolationColors = cb,
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(SoftLightMix(SoftLightMix(SoftLightMix(SoftLightMix(ThemeColor, Color.White, 50), Color.Black, 60), Color.White, 100), Color.White, 60))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(SoftLightMix(SoftLightMix(SoftLightMix(ThemeColor, Color.White, 50), Color.White, 60), Color.Black, 60))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            c1 = SoftLightMix(SoftLightMix(SoftLightMix(ThemeColor, Color.White, 50), Color.Black, 60), Color.White, 100)
            c2 = SoftLightMix(SoftLightMix(ThemeColor, Color.White, 50), CRGB(52, 52, 52), 60)
            c3 = SoftLightMix(SoftLightMix(ThemeColor, Color.White, 50), Color.White, 60)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.25, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3) With {
                .InterpolationColors = cb,
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)
        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim b As SolidBrush
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            b = New SolidBrush(SoftLightMix(SoftLightMix(SoftLightMix(ThemeColor, Color.Black, 60), Color.White, 100), Color.White, 60))
            FillRoundedRectangle(b, 3, New Rectangle(1, 1, My.Width - 2, My.Height - 2), e)

            b = New SolidBrush(SoftLightMix(SoftLightMix(ThemeColor, Color.White, 60), Color.Black, 60))
            FillRoundedRectangle(b, 3, New Rectangle(2, 2, My.Width - 3, My.Height - 3), e)

            c1 = SoftLightMix(SoftLightMix(ThemeColor, Color.Black, 60), Color.White, 100)
            c2 = SoftLightMix(ThemeColor, CRGB(52, 52, 52), 60)
            c3 = SoftLightMix(ThemeColor, Color.White, 60)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.25, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3) With {
                .InterpolationColors = cb,
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 2, New Rectangle(2, 2, My.Width - 4, My.Height - 4), e)
        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal tcolor As Color, ByVal TextFx As Boolean)
            ThemeColor = tcolor

            TextEffects = TextFx

            DrawBase(e, state)
            If state = Theme.States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawDisabledButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.3 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.3 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub

    End Class
#End Region

#Region " Windows XP Theme "
    Public Class WindowsXP

        Private My As Rectangle
        Private TextEffects As Boolean

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Shared Sub FillRoundedRectangle(ByVal b As Brush, ByVal Radius As Integer, ByVal Rect As Rectangle, ByVal e As PaintEventArgs)
            Dim TL, TR, BL, BR As Point 'The four corners of the rectabgle

            'Set the values of each corner point
            TL = New Point(Rect.Left, Rect.Top)
            TR = New Point(Rect.Left + Rect.Width, Rect.Top)
            BL = New Point(Rect.Left, Rect.Top + Rect.Height)
            BR = New Point(Rect.Left + Rect.Width, Rect.Top + Rect.Height)

            'Draws the four corner circles
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias 'Changes smoothing mode to anti-alias to remove jagged edges
            e.Graphics.FillEllipse(b, New Rectangle(TL.X, TL.Y, Radius * 2, Radius * 2)) 'Top-left circle
            e.Graphics.FillEllipse(b, New Rectangle(BL.X, BL.Y - (Radius * 2) - 1, Radius * 2, Radius * 2)) 'Bottom-left circle
            e.Graphics.FillEllipse(b, New Rectangle(TR.X - (Radius * 2) - 1, TR.Y, Radius * 2, Radius * 2)) 'Top-right circle
            e.Graphics.FillEllipse(b, New Rectangle(BR.X - (Radius * 2) - 1, BR.Y - (Radius * 2) - 1, Radius * 2, Radius * 2)) 'Bottom-right circle

            'Draws the two blocks
            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default 'Returns the smoothing mode to default for a crisp structure
            e.Graphics.FillRectangle(b, New Rectangle(TL.X, TL.Y + Radius, Rect.Width, Rect.Height - (Radius * 2)))
            e.Graphics.FillRectangle(b, New Rectangle(TL.X + Radius, TL.Y, Rect.Width - (Radius * 2), Rect.Height))
        End Sub

        Private Sub DrawBase(ByVal e As PaintEventArgs, ByVal state As States)
            Dim b As Brush

            If state = States.Disabled Then
                b = New SolidBrush(CRGB(201, 199, 186))
            Else
                b = New SolidBrush(CRGB(0, 60, 116))
            End If

            FillRoundedRectangle(b, 2, New Rectangle(My.Left, My.Top, My.Width, My.Height), e)
        End Sub

        Private Sub DrawDisabledButtonBody(ByVal e As PaintEventArgs)
            Dim b As Brush
            b = New SolidBrush(CRGB(245, 244, 234))
            FillRoundedRectangle(b, 1, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)
        End Sub

        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = CRGB(194, 219, 255)
            c2 = CRGB(140, 180, 242)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c2) With {
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 1, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            e.Graphics.DrawLine(New Pen(CRGB(206, 231, 255)), 2, 1, My.Width - 3, 1)
            e.Graphics.DrawLine(New Pen(CRGB(105, 130, 238)), 2, My.Height - 2, My.Width - 3, My.Height - 2)

            c1 = CRGB(255, 255, 255)
            c2 = CRGB(244, 242, 232)
            c3 = CRGB(220, 215, 203)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(My.Left, My.Top + 1), New Point(My.Left, My.Height - 1), c1, c3)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, (My.Height - 5) / My.Height, 1.0}

            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            e.Graphics.FillRectangle(lgb, My.Left + 3, My.Top + 3, My.Width - 6, My.Height - 6)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = CRGB(209, 204, 193)
            c2 = CRGB(227, 226, 218)
            c3 = CRGB(239, 238, 234)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top + 1), New Point(0, My.Height - 1), c1, c3)

            cb.Colors = New Color() {c1, c2, c2, c3}
            cb.Positions = New Single() {0.0, 4 / My.Height, (My.Height - 5) / My.Height, 1.0}

            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            FillRoundedRectangle(lgb, 1, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            e.Graphics.DrawLine(New Pen(c1), My.Left + 1, My.Top + 2, My.Left + 1, My.Height - 3)
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = CRGB(255, 218, 140)
            c2 = CRGB(255, 184, 52)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c2) With {
                .GammaCorrection = True
            }

            FillRoundedRectangle(lgb, 1, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            e.Graphics.DrawLine(New Pen(CRGB(255, 240, 207)), 2, 1, My.Width - 3, 1)
            e.Graphics.DrawLine(New Pen(CRGB(229, 151, 0)), 2, My.Height - 2, My.Width - 3, My.Height - 2)

            c1 = CRGB(255, 255, 255)
            c2 = CRGB(244, 242, 232)
            c3 = CRGB(220, 215, 203)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, (My.Height - 5) / My.Height, 1.0}

            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            e.Graphics.FillRectangle(lgb, My.Left + 3, My.Top + 3, My.Width - 6, My.Height - 6)
        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = CRGB(255, 255, 255)
            c2 = CRGB(244, 242, 232)
            c3 = CRGB(220, 215, 203)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, 1), New Point(0, My.Height - 1), c1, c3)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, (My.Height - 5) / My.Height, 1.0}

            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            FillRoundedRectangle(lgb, 1, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            e.Graphics.DrawLine(New Pen(c3), My.Width - 2, 2, My.Width - 2, My.Height - 3)
        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal TextFX As Boolean)
            DrawBase(e, state)

            TextEffects = TextFX

            If state = Theme.States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawDisabledButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.75 * 255, Color.White))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)

            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.75 * 255, Color.White))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub

    End Class
#End Region

#Region " MSN Login Button Theme "
    Public Class MSNLoginButton

        Private My As Rectangle
        Private TextEffects As Boolean

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Sub DrawBase(ByVal e As PaintEventArgs, ByVal state As States, ByVal Backcolor As Color)
            Dim b As Brush
            Dim c As Color

            If state = States.MouseDown Then
                c = Color.FromArgb(64, 7, 66, 131)
                b = New SolidBrush(c)

                e.Graphics.FillRectangle(b, My.Left, My.Top + 1, My.Width - 1, My.Height - 3)
                e.Graphics.FillRectangle(b, My.Left + 1, My.Top, My.Width - 3, My.Height - 1)

                c = CRGB(7, 66, 131)
                b = New SolidBrush(c)

                e.Graphics.FillRectangle(b, My.Left + 1, My.Top + 2, My.Width - 1, My.Height - 3)
                e.Graphics.FillRectangle(b, My.Left + 2, My.Top + 1, My.Width - 3, My.Height - 1)
            ElseIf state = States.Disabled Then
                c = CRGB(117, 120, 138)
                b = New SolidBrush(c)

                e.Graphics.FillRectangle(b, My.Left, My.Top + 1, My.Width - 1, My.Height - 3)
                e.Graphics.FillRectangle(b, My.Left + 1, My.Top, My.Width - 3, My.Height - 1)
            Else
                c = CRGB(7, 66, 131)
                b = New SolidBrush(c)

                e.Graphics.FillRectangle(b, My.Left, My.Top + 1, My.Width - 1, My.Height - 3)
                e.Graphics.FillRectangle(b, My.Left + 1, My.Top, My.Width - 3, My.Height - 1)
            End If
        End Sub

        Private Sub DrawDisabledButtonBody(ByVal e As PaintEventArgs)
            Dim sb As SolidBrush
            Dim x, y As Single

            sb = New SolidBrush(CRGB(176, 178, 191))
            e.Graphics.FillRectangle(sb, My.Left + 1, My.Top + 1, My.Width - 3, My.Height - 3)

            sb = New SolidBrush(CRGB(224, 226, 236))
            e.Graphics.FillRectangle(sb, My.Left + 2, My.Top + 2, My.Width - 5, My.Height - 5)

            x = My.Left + 2
            y = My.Top + My.Height - 4

            e.Graphics.DrawLine(New Pen(CRGB(194, 197, 209)), x, y, My.Left + My.Width - 3, y)
        End Sub

        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            DrawButtonBody(e)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim sb As SolidBrush
            Dim unused As New System.Drawing.Drawing2D.ColorBlend
            Dim x, y, z As Single

            sb = New SolidBrush(CRGB(123, 140, 196))
            e.Graphics.FillRectangle(sb, My.Left + 2, My.Top + 2, My.Width - 3, My.Height - 3)

            sb = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(sb, My.Left + 3, My.Top + 3, My.Width - 5, My.Height - 5)

            c1 = Color.White
            c2 = CRGB(218, 225, 252)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top + 3), New Point(0, My.Top + My.Height - 2), c1, c2)
            Dim cb As New Drawing2D.ColorBlend With {
                .Colors = New Color() {c1, c1, c2},
                .Positions = New Single() {0, 2 / (My.Height - 3), 1}
            }
            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            e.Graphics.FillRectangle(lgb, My.Left + 5, My.Top + 5, My.Width - 10, My.Height - 7)

            e.Graphics.DrawLine(New Pen(CRGB(186, 201, 245)), My.Left + My.Width - 3, My.Top + 4, My.Left + My.Width - 3, My.Top + My.Height - 3)

            x = My.Left + 3
            y = My.Top + My.Height - 2
            z = (My.Width - 4) / 4

            e.Graphics.DrawLine(New Pen(CRGB(249, 172, 20)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(152, 53, 3)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(7, 80, 143)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(17, 147, 49)), x, y, My.Left + My.Width - 3, y)

            x = My.Left + 3
            y -= 1

            e.Graphics.DrawLine(New Pen(CRGB(251, 181, 42)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(236, 112, 102)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(39, 119, 209)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(36, 190, 74)), x, y, My.Left + My.Width - 3, y)
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            DrawButtonBody(e)
        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim sb As SolidBrush
            Dim unused As New System.Drawing.Drawing2D.ColorBlend
            Dim x, y, z As Single

            sb = New SolidBrush(CRGB(238, 163, 53))
            e.Graphics.FillRectangle(sb, My.Left + 1, My.Top + 1, My.Width - 3, My.Height - 3)

            sb = New SolidBrush(Color.White)
            e.Graphics.FillRectangle(sb, My.Left + 2, My.Top + 2, My.Width - 5, My.Height - 5)

            c1 = Color.White
            c2 = CRGB(218, 225, 252)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top + 2), New Point(0, My.Top + My.Height - 3), c1, c2)
            Dim cb As New System.Drawing.Drawing2D.ColorBlend With {
                .Colors = New Color() {c1, c1, c2},
                .Positions = New Single() {0, 2 / (My.Height - 3), 1}
            }
            lgb.InterpolationColors = cb
            lgb.GammaCorrection = True

            e.Graphics.FillRectangle(lgb, My.Left + 4, My.Top + 4, My.Width - 10, My.Height - 7)

            e.Graphics.DrawLine(New Pen(CRGB(186, 201, 245)), My.Left + My.Width - 4, My.Top + 3, My.Left + My.Width - 4, My.Top + My.Height - 4)

            x = My.Left + 2
            y = My.Top + My.Height - 3
            z = (My.Width - 4) / 4

            e.Graphics.DrawLine(New Pen(CRGB(249, 172, 20)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(152, 53, 3)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(7, 80, 143)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(17, 147, 49)), x, y, My.Left + My.Width - 3, y)

            x = My.Left + 2
            y -= 1

            e.Graphics.DrawLine(New Pen(CRGB(251, 181, 42)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(236, 112, 102)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(39, 119, 209)), x, y, My.Left + My.Width - 3, y)
            x += z
            e.Graphics.DrawLine(New Pen(CRGB(36, 190, 74)), x, y, My.Left + My.Width - 3, y)

        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean, ByVal backcolor As Color)
            DrawBase(e, state, backcolor)
            TextEffects = textfx
            If state = Theme.States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawDisabledButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)

            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.25 * 255, CRGB(100, 127, 205)))
                    e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 4, My.Top + 4, My.Width - 5, My.Height - 2), sf)
                End If
                b = New SolidBrush(CRGB(100, 127, 205))
                e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 3, My.Top + 3, My.Width - 5, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(CRGB(117, 120, 138))
                e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 2, My.Top + 2, My.Width - 5, My.Height - 2), sf)
            ElseIf s = States.MouseOver Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.25 * 255, CRGB(100, 127, 205)))
                    e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 3, My.Top + 3, My.Width - 5, My.Height - 2), sf)
                End If
                b = New SolidBrush(CRGB(100, 127, 205))
                e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 2, My.Top + 2, My.Width - 5, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.25 * 255, CRGB(47, 74, 143)))
                    e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 3, My.Top + 3, My.Width - 5, My.Height - 2), sf)
                End If
                b = New SolidBrush(CRGB(47, 74, 143))
                e.Graphics.DrawString(text, font, b, New RectangleF(My.Left + 2, My.Top + 2, My.Width - 5, My.Height - 2), sf)
            End If

        End Sub

    End Class
#End Region

#Region " Aqua Theme "
    Public Class Aqua

        Private My As Rectangle
        Private TextEffects As Boolean
        Private tc As Color

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Shared Sub FillPill(ByVal b As Brush, ByVal rect As Rectangle, ByVal e As PaintEventArgs)
            If rect.Width > rect.Height Then 'Horizontal
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.FillEllipse(b, New Rectangle(rect.Left, rect.Top, rect.Height, rect.Height))
                e.Graphics.FillEllipse(b, New Rectangle(rect.Left + rect.Width - rect.Height, rect.Top, rect.Height, rect.Height))
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
                e.Graphics.FillRectangle(b, New Rectangle(rect.Left + (rect.Height / 2), rect.Top, rect.Width - rect.Height, rect.Height))
            ElseIf rect.Width < rect.Height Then 'Vertical
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.FillEllipse(b, New Rectangle(rect.Left, rect.Top, rect.Width, rect.Width))
                e.Graphics.FillEllipse(b, New Rectangle(rect.Left, rect.Top + rect.Height - rect.Width, rect.Width, rect.Width))
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
                e.Graphics.FillRectangle(b, New Rectangle(rect.Left, rect.Top + (rect.Width / 2), rect.Width, rect.Height - rect.Width))
            ElseIf rect.Width = rect.Height Then 'Circle
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.FillEllipse(b, rect)
                e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.Default
            End If
        End Sub

        Private Sub DrawBase(ByVal e As PaintEventArgs, ByVal state As States)
            Dim b As Brush
            If state = States.Disabled Then
                b = New SolidBrush(CRGB(201, 199, 186))
            Else
                b = New SolidBrush(OpacityMix(Color.Black, tc, 70))
            End If
            FillPill(b, New Rectangle(0, 0, My.Width, My.Height), e)
        End Sub

        Private Sub DrawDisabledButtonBody(ByVal e As PaintEventArgs)
            Dim sb As SolidBrush
            sb = New SolidBrush(CRGB(245, 244, 234))
            FillPill(sb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)
        End Sub


        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            DrawButtonBody(e)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend With {
                .Colors = New Color() {OpacityMix(Color.Black, tc, 25), tc, OpacityMix(Color.Black, tc, 25)},
                .Positions = New Single() {0.0, 0.5, 1.0}
            }

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(My.Left + 1, My.Top), New Point(My.Left + 1, My.Top + My.Height - 1), OpacityMix(Color.Black, tc, 25), OpacityMix(Color.Black, tc, 25)) With {
                .InterpolationColors = cb
            }

            FillPill(lgb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3, c4, c5 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend
            Dim bc As Color

            bc = SoftLightMix(tc, Color.White, 60)

            c1 = OpacityMix(Color.White, SoftLightMix(bc, Color.Black, 100), 40)
            c2 = OpacityMix(Color.White, SoftLightMix(bc, CRGB(64, 64, 64), 100), 20)
            c3 = SoftLightMix(bc, CRGB(128, 128, 128), 100)
            c4 = SoftLightMix(bc, CRGB(192, 192, 192), 100)
            c5 = OverlayMix(SoftLightMix(bc, Color.White, 100), Color.White, 75)

            cb.Colors = New Color() {c1, c2, c3, c4, c5}
            cb.Positions = New Single() {0.0, 0.25, 0.5, 0.75, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(My.Left + 1, My.Top), New Point(My.Left + 1, My.Top + My.Height - 1), c1, c5) With {
                .InterpolationColors = cb
            }

            FillPill(lgb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            c2 = Color.White

            cb.Colors = New Color() {c2, c3, c4, c5}
            cb.Positions = New Single() {0.0, 0.5, 0.75, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(My.Left + 1, My.Top), New Point(My.Left + 1, My.Top + My.Height - 1), c2, c5) With {
                .InterpolationColors = cb
            }

            FillPill(lgb, New Rectangle(My.Left + 4, My.Top + 4, My.Width - 8, My.Height - 8), e)

        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3, c4, c5 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = OpacityMix(Color.White, SoftLightMix(tc, Color.Black, 100), 40)
            c2 = OpacityMix(Color.White, SoftLightMix(tc, CRGB(64, 64, 64), 100), 20)
            c3 = SoftLightMix(tc, CRGB(128, 128, 128), 100)
            c4 = SoftLightMix(tc, CRGB(192, 192, 192), 100)
            c5 = OverlayMix(SoftLightMix(tc, Color.White, 100), Color.White, 75)

            cb.Colors = New Color() {c1, c2, c3, c4, c5}
            cb.Positions = New Single() {0.0, 0.25, 0.5, 0.75, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(My.Left + 1, My.Top), New Point(My.Left + 1, My.Top + My.Height - 1), c1, c5) With {
                .InterpolationColors = cb
            }

            FillPill(lgb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            c2 = Color.White

            cb.Colors = New Color() {c2, c3, c4, c5}
            cb.Positions = New Single() {0.0, 0.5, 0.75, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(My.Left + 1, My.Top), New Point(My.Left + 1, My.Top + My.Height - 1), c2, c5) With {
                .InterpolationColors = cb
            }

            FillPill(lgb, New Rectangle(My.Left + 4, My.Top + 4, My.Width - 8, My.Height - 8), e)

        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean, ByVal themecolor As Color)
            tc = themecolor

            DrawBase(e, state)

            TextEffects = textfx
            If state = Theme.States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawDisabledButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.35 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.35 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub
    End Class
#End Region

#Region " 3D Hover Theme "
    Public Class Hover3D
        Private My As Rectangle
        Private TextEffects As Boolean
        Private isFocused As Boolean

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            Dim p As Pen
            p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                .DashStyle = Drawing2D.DashStyle.Dot
            }
            e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.25 * 255, Color.White)), My.Left, My.Top, My.Left + My.Width, My.Top)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.25 * 255, Color.White)), My.Left, My.Top, My.Left, My.Top + My.Height)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.1 * 255, Color.Black)), My.Left, My.Top + My.Height - 1, My.Left + My.Width, My.Top + My.Height - 1)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.1 * 255, Color.Black)), My.Left + My.Width - 1, My.Top, My.Left + My.Width - 1, My.Top + My.Height)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.15 * 255, Color.Black)), My.Left, My.Top, My.Left + My.Width, My.Top)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.15 * 255, Color.Black)), My.Left, My.Top, My.Left, My.Top + My.Height)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.65 * 255, Color.White)), My.Left, My.Top + My.Height - 1, My.Left + My.Width, My.Top + My.Height - 1)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.65 * 255, Color.White)), My.Left + My.Width - 1, My.Top, My.Left + My.Width - 1, My.Top + My.Height)
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(0.025 * 255, Color.Black)), My.Left, My.Top, My.Width, My.Height)

            If isFocused = True Then
                Dim p As Pen
                p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                    .DashStyle = Drawing2D.DashStyle.Dot
                }
                e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            End If
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            If isFocused = True Then
                Dim p As Pen
                p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                    .DashStyle = Drawing2D.DashStyle.Dot
                }
                e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            End If
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.75 * 255, Color.White)), My.Left, My.Top, My.Left + My.Width, My.Top)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.75 * 255, Color.White)), My.Left, My.Top, My.Left, My.Top + My.Height)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.35 * 255, Color.Black)), My.Left, My.Top + My.Height - 1, My.Left + My.Width, My.Top + My.Height - 1)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.35 * 255, Color.Black)), My.Left + My.Width - 1, My.Top, My.Left + My.Width - 1, My.Top + My.Height)
        End Sub


        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean, ByVal focused As Boolean)
            TextEffects = textfx
            isFocused = focused
            If state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.15 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.15 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub
    End Class
#End Region

#Region " Office XP Theme "
    Public Class OfficeXP
        Private My As Rectangle
        Private TextEffects, isFocused As Boolean
        Private tc As Color

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)
            Dim p As Pen
            p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                .DashStyle = Drawing2D.DashStyle.Dot
            }
            e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim b As SolidBrush
            b = New SolidBrush(tc)
            e.Graphics.FillRectangle(b, My.Left, My.Top, My.Width, My.Height)

            b = New SolidBrush(OverlayMix(OpacityMix(Color.White, tc, 75), Color.Black, 50))
            e.Graphics.FillRectangle(b, My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2)

            If isFocused = True Then
                Dim p As Pen
                p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                    .DashStyle = Drawing2D.DashStyle.Dot
                }
                e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            End If
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            Dim b As SolidBrush
            b = New SolidBrush(tc)
            e.Graphics.FillRectangle(b, My.Left, My.Top, My.Width, My.Height)

            b = New SolidBrush(Color.FromArgb(0.75 * 255, Color.White))
            e.Graphics.FillRectangle(b, My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2)

            If isFocused = True Then
                Dim p As Pen
                p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                    .DashStyle = Drawing2D.DashStyle.Dot
                }
                e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            End If
        End Sub


        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean, ByVal themecolor As Color, ByVal focused As Boolean)
            TextEffects = textfx
            isFocused = focused
            tc = themecolor
            If state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.15 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.15 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub
    End Class
#End Region

#Region " Office 2003 Theme "
    Public Class Office2003
        Private My As Rectangle
        Private TextEffects, isFocused As Boolean
        Private tc As Color

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Sub DrawFocusButtonBody(ByVal e As PaintEventArgs)

            Dim c1, c2, c3 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = OverlayMix(OpacityMix(Color.White, tc, 55), Color.White, 60)
            c2 = OpacityMix(Color.White, tc, 55)
            c3 = OpacityMix(Color.Black, c2, 15)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.5, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top), New Point(0, My.Top + My.Height), c1, c3) With {
                .InterpolationColors = cb
            }

            e.Graphics.FillRectangle(lgb, My.Left, My.Top, My.Width, My.Height)

            Dim p As Pen
            p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                .DashStyle = Drawing2D.DashStyle.Dot
            }
            e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)

            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.25 * 255, Color.White)), My.Left, My.Top, My.Left + My.Width, My.Top)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.25 * 255, Color.White)), My.Left, My.Top, My.Left, My.Top + My.Height)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.1 * 255, Color.Black)), My.Left, My.Top + My.Height - 1, My.Left + My.Width, My.Top + My.Height - 1)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.1 * 255, Color.Black)), My.Left + My.Width - 1, My.Top, My.Left + My.Width - 1, My.Top + My.Height)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim bc As Color

            bc = OpacityMix(Color.White, OverlayMix(InvertColor(tc), Color.White, 10), 50)

            c1 = OverlayMix(bc, Color.Black, 35)
            c2 = OverlayMix(bc, Color.White, 25)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top), New Point(0, My.Top + My.Height), c1, c2)

            e.Graphics.FillRectangle(lgb, My.Left, My.Top, My.Width, My.Height)

            e.Graphics.DrawRectangle(New Pen(OpacityMix(Color.Black, OverlayMix(tc, Color.Black, 75), 50)), My.Left, My.Top, My.Width - 1, My.Height - 1)

            If isFocused = True Then
                Dim p As Pen
                p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                    .DashStyle = Drawing2D.DashStyle.Dot
                }
                e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            End If
        End Sub

        Private Sub DrawOverButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim bc As Color

            bc = OpacityMix(Color.White, OverlayMix(InvertColor(tc), Color.White, 25), 50)

            c1 = OverlayMix(bc, Color.White, 50)
            c2 = OverlayMix(bc, Color.Black, 15)

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top), New Point(0, My.Top + My.Height), c1, c2)

            e.Graphics.FillRectangle(lgb, My.Left, My.Top, My.Width, My.Height)

            e.Graphics.DrawRectangle(New Pen(OpacityMix(Color.Black, OverlayMix(tc, Color.Black, 75), 50)), My.Left, My.Top, My.Width - 1, My.Height - 1)

            If isFocused = True Then
                Dim p As Pen
                p = New Pen(Color.FromArgb(0.5 * 255, Color.Black)) With {
                    .DashStyle = Drawing2D.DashStyle.Dot
                }
                e.Graphics.DrawRectangle(p, My.Left + 3, My.Top + 3, My.Width - 7, My.Height - 7)
            End If
        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim c1, c2, c3 As Color
            Dim lgb As System.Drawing.Drawing2D.LinearGradientBrush
            Dim cb As New System.Drawing.Drawing2D.ColorBlend

            c1 = OverlayMix(OpacityMix(Color.White, tc, 55), Color.White, 60)
            c2 = OpacityMix(Color.White, tc, 55)
            c3 = OpacityMix(Color.Black, c2, 15)

            cb.Colors = New Color() {c1, c2, c3}
            cb.Positions = New Single() {0.0, 0.5, 1.0}

            lgb = New System.Drawing.Drawing2D.LinearGradientBrush(New Point(0, My.Top), New Point(0, My.Top + My.Height), c1, c3) With {
                .InterpolationColors = cb
            }

            e.Graphics.FillRectangle(lgb, My.Left, My.Top, My.Width, My.Height)

            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.35 * 255, Color.White)), My.Left, My.Top, My.Left + My.Width, My.Top)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.35 * 255, Color.White)), My.Left, My.Top, My.Left, My.Top + My.Height)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.1 * 255, Color.Black)), My.Left, My.Top + My.Height - 1, My.Left + My.Width, My.Top + My.Height - 1)
            e.Graphics.DrawLine(New Pen(Color.FromArgb(0.1 * 255, Color.Black)), My.Left + My.Width - 1, My.Top, My.Left + My.Width - 1, My.Top + My.Height)
        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean, ByVal themecolor As Color, ByVal focused As Boolean)
            TextEffects = textfx
            isFocused = focused
            tc = themecolor
            If state = States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawOverButtonBody(e)
            ElseIf state = States.Focused Then
                DrawFocusButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.15 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.15 * 255, Color.Black))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub
    End Class
#End Region

#Region " Macintosh Theme "
    Public Class Macintosh
        Private My As Rectangle
        Private TextEffects As Boolean
        Private tc As Color

        Public Sub New(ByVal Owner As Rectangle)
            MyBase.New()
            My = Owner
        End Sub

        Private Shared Sub FillPlate(ByVal b As Brush, ByVal rect As Rectangle, ByVal e As PaintEventArgs)
            e.Graphics.FillRectangle(b, rect.Left, rect.Top + 1, rect.Width, rect.Height - 2)
            e.Graphics.FillRectangle(b, rect.Left + 1, rect.Top, rect.Width - 2, rect.Height)
        End Sub

        Private Sub DrawBase(ByVal e As PaintEventArgs)
            Dim b As SolidBrush
            b = New SolidBrush(OpacityMix(Color.Black, SoftLightMix(tc, Color.Black, 100), 50))
            FillPlate(b, New Rectangle(My.Left, My.Top, My.Width, My.Height), e)
        End Sub

        Private Sub DrawDownButtonBody(ByVal e As PaintEventArgs)
            Dim sb As SolidBrush
            Dim bc, c As Color

            bc = OpacityMix(Color.Black, SoftLightMix(tc, Color.Black, 100), 30)

            sb = New SolidBrush(SoftLightMix(bc, Color.Black, 75))
            FillPlate(sb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            sb = New SolidBrush(bc)
            FillPlate(sb, New Rectangle(My.Left + 2, My.Top + 2, My.Width - 3, My.Height - 3), e)

            sb = New SolidBrush(OpacityMix(Color.White, bc, 15))
            FillPlate(sb, New Rectangle(My.Left + 2, My.Top + 2, My.Width - 4, My.Height - 4), e)

            sb = New SolidBrush(bc)
            FillPlate(sb, New Rectangle(My.Left + 2, My.Top + 2, My.Width - 5, My.Height - 5), e)

            c = SoftLightMix(bc, Color.Black, 25)
            e.Graphics.DrawLine(New Pen(c), My.Left + 2, My.Top + 3, My.Left + 2, My.Top + My.Height - 2)
            e.Graphics.DrawLine(New Pen(c), My.Left + 3, My.Top + 2, My.Left + My.Width - 2, My.Top + 2)
        End Sub

        Private Sub DrawButtonBody(ByVal e As PaintEventArgs)
            Dim sb As SolidBrush
            Dim c As Color

            sb = New SolidBrush(OpacityMix(Color.Black, SoftLightMix(tc, Color.Black, 100), 30))
            FillPlate(sb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 2, My.Height - 2), e)

            sb = New SolidBrush(tc)
            FillPlate(sb, New Rectangle(My.Left + 1, My.Top + 1, My.Width - 3, My.Height - 3), e)

            sb = New SolidBrush(Color.White)
            FillPlate(sb, New Rectangle(My.Left + 2, My.Top + 2, My.Width - 4, My.Height - 4), e)

            sb = New SolidBrush(tc)
            FillPlate(sb, New Rectangle(My.Left + 3, My.Top + 3, My.Width - 5, My.Height - 5), e)

            c = SoftLightMix(tc, Color.Black, 50)
            e.Graphics.DrawLine(New Pen(c), My.Left + 1, My.Top + My.Height - 3, My.Left + My.Width - 4, My.Top + My.Height - 3)
            e.Graphics.DrawLine(New Pen(c), My.Left + My.Width - 3, My.Top + 1, My.Left + My.Width - 3, My.Top + My.Height - 4)
        End Sub

        Public Sub DrawTheme(ByVal e As PaintEventArgs, ByVal state As Theme.States, ByVal textfx As Boolean, ByVal themecolor As Color)
            TextEffects = textfx
            tc = themecolor

            DrawBase(e)

            If state = States.Normal Then
                DrawButtonBody(e)
            ElseIf state = Theme.States.MouseOver Then
                DrawButtonBody(e)
            ElseIf state = States.Focused Then
                DrawButtonBody(e)
            ElseIf state = States.MouseDown Then
                DrawDownButtonBody(e)
            ElseIf state = States.Disabled Then
                DrawButtonBody(e)
            End If
        End Sub

        Public Sub DrawText(ByVal e As PaintEventArgs, ByVal s As States, ByVal text As String, ByVal font As Font, ByVal forecolor As Color)

            Dim sf As StringFormat
            Dim sz As SizeF
            Dim b As Brush

            sf = New StringFormat With {
                .LineAlignment = StringAlignment.Center,
                .Alignment = StringAlignment.Center,
                .Trimming = StringTrimming.EllipsisCharacter
            }

            sz = e.Graphics.MeasureString(text, font, New SizeF(My.Width - 2, My.Height - 2), sf)
            text &= "                    "

            If s = States.MouseDown Then
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.5 * 255, Color.White))
                    e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
            ElseIf s = States.Disabled Then
                b = New SolidBrush(Color.FromArgb(0.5 * 255, Color.White))
                e.Graphics.DrawString(text, font, b, New RectangleF(3, 3, My.Width - 2, My.Height - 2), sf)
                b = New SolidBrush(Color.FromKnownColor(KnownColor.GrayText))
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            Else
                If TextEffects = True Then
                    b = New SolidBrush(Color.FromArgb(0.5 * 255, Color.White))
                    e.Graphics.DrawString(text, font, b, New RectangleF(2, 2, My.Width - 2, My.Height - 2), sf)
                End If
                b = New SolidBrush(forecolor)
                e.Graphics.DrawString(text, font, b, New RectangleF(1, 1, My.Width - 2, My.Height - 2), sf)
            End If

        End Sub
    End Class
#End Region

End Namespace