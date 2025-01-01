'Please note that this module is a work in progress and is being 
'developed to be utilized in the upcoming version of FreeStyle 
'Button. Hence it is not used in any of the drawing functions in 
'the currently listed themes.

Module ModPaths

    <Flags()>
    Friend Enum Corner
        None = 0
        TopLeft = 1
        TopRight = 2
        BottomLeft = 4
        BottomRight = 8
        All = TopLeft Or TopRight Or BottomLeft Or BottomRight
    End Enum

    Public Function RoundedRect(ByVal rect As RectangleF, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
        Dim p As New Drawing2D.GraphicsPath
        Dim x As Single = rect.X, y As Single = rect.Y, w As Single = rect.Width, h As Single = rect.Height, m As Integer = margin, r As Integer = cornerradius

        p.StartFigure()
        'top left arc
        If CBool(roundedcorners And Corner.TopLeft) Then
            p.AddArc(CtrlHelper.CheckedRectangleF(x + m, y + m, 2 * r, 2 * r), 180, 90)
        Else
            p.AddLine(New PointF(x + m, y + m + r), New PointF(x + m, y + m))
            p.AddLine(New PointF(x + m, y + m), New PointF(x + m + r, y + m))
        End If

        'top line
        p.AddLine(New PointF(x + m + r, y + m), New PointF(x + w - m - r, y + m))

        'top right arc
        If CBool(roundedcorners And Corner.TopRight) Then
            p.AddArc(CtrlHelper.CheckedRectangleF(x + w - m - 2 * r, y + m, 2 * r, 2 * r), 270, 90)
        Else
            p.AddLine(New PointF(x + w - m - r, y + m), New PointF(x + w - m, y + m))
            p.AddLine(New PointF(x + w - m, y + m), New PointF(x + w - m, y + m + r))
        End If

        'right line
        p.AddLine(New PointF(x + w - m, y + m + r), New PointF(x + w - m, y + h - m - r))

        'bottom right arc
        If CBool(roundedcorners And Corner.BottomRight) Then
            p.AddArc(CtrlHelper.CheckedRectangleF(x + w - m - 2 * r, y + h - m - 2 * r, 2 * r, 2 * r), 0, 90)
        Else
            p.AddLine(New PointF(x + w - m, y + h - m - r), New PointF(x + w - m, y + h - m))
            p.AddLine(New PointF(x + w - m, y + h - m), New PointF(x + w - m - r, y + h - m))
        End If

        'bottom line
        p.AddLine(New PointF(x + w - m - r, y + h - m), New PointF(x + m + r, y + h - m))

        'bottom left arc
        If CBool(roundedcorners And Corner.BottomLeft) Then
            p.AddArc(CtrlHelper.CheckedRectangleF(x + m, y + h - m - 2 * r, 2 * r, 2 * r), 90, 90)
        Else
            p.AddLine(New PointF(x + m + r, y + h - m), New PointF(x + m, y + h - m))
            p.AddLine(New PointF(x + m, y + h - m), New PointF(x + m, y + h - m - r))
        End If

        'left line
        p.AddLine(New PointF(x + m, y + h - m - r), New PointF(x + m, y + m + r))

        'close figure...
        p.CloseFigure()

        Return p
    End Function

    Friend Class CtrlHelper
        Public Shared Function CheckedRectangleF(ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single) As RectangleF
            Return New RectangleF(x, y, CSng(IIf(width <= 0, 1, width)), CSng(IIf(height <= 0, 1, height)))

        End Function

        Public Shared Function CheckedRectangle(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As Rectangle
            Return New Rectangle(x, y, CInt(IIf(width <= 0, 1, width)), CInt(IIf(height <= 0, 1, height)))
        End Function
    End Class

End Module
