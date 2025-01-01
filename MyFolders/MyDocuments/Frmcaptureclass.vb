Public Class Frmcaptureclass
    Inherits System.Windows.Forms.Form
#Region "Variables"
    Private m_color As Color
    Private CaptureRectangle As New Rectangle(New Point(0, 0), New Size(0, 0))
    Private isDrag As Boolean = False
    Private startPoint As Point
#End Region
    'Public Sub New(ByVal Parent As Form)
    '    Me.Owner = Parent
    '    Me.FormBorderStyle = FormBorderStyle.None
    '    Me.WindowState = FormWindowState.Maximized
    '    Me.SetStyle(ControlStyles.DoubleBuffer Or _
    '                 ControlStyles.AllPaintingInWmPaint Or _
    '                 ControlStyles.ResizeRedraw Or _
    '                 ControlStyles.UserPaint Or _
    '                 ControlStyles.SupportsTransparentBackColor, True)
    '    Me.ShowInTaskbar = False
    '    m_color = Color.FromArgb(25, Color.Green)
    'End Sub
    Public Property RectCaptureColor() As Color
        Get
            Return m_color
        End Get
        Set(ByVal value As Color)
            m_color = value
        End Set
    End Property
    Public Sub GetScreenShot()
        Me.Owner.Hide()
        Threading.Thread.Sleep(250)
        ' get screen shot of the whole screen and set it as background for the current form
        Dim bounds As Rectangle
        Dim screenshot As System.Drawing.Bitmap
        Dim graph As Graphics
        bounds = Screen.PrimaryScreen.Bounds
        screenshot = New System.Drawing.Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb)
        graph = Graphics.FromImage(screenshot)
        graph.CopyFromScreen(bounds.X, bounds.Y, 0, 0, bounds.Size, CopyPixelOperation.SourceCopy)
        Me.BackgroundImage = screenshot
        Me.Cursor = Cursors.Cross
        Me.Show()
    End Sub
    Public Shared Sub GetScreenShotImage(ByVal Rect As Rectangle)
        If Rect.Width > 0 And Rect.Height > 0 Then
            Dim bmp As New Bitmap(Rect.Width, Rect.Height)
            Dim blockRegionSize As New Size(Rect.Width, Rect.Height)
            Dim g1 As Graphics = Graphics.FromImage(bmp)
            g1.CopyFromScreen(Rect.Location, New Point(0, 0), blockRegionSize)
            Clipboard.SetImage(bmp)
        End If
    End Sub
    Private Sub ScreenCapturer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Left Then
            isDrag = True
        End If
        Dim control As Control = CType(sender, Control)
        ' Calculate the startPoint by using the PointToScreen method.
        startPoint = control.PointToScreen(New Point(e.X, e.Y))
    End Sub
    Private Sub ScreenCapturer_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If isDrag Then
            ControlPaint.DrawReversibleFrame(CaptureRectangle, Me.BackColor, FrameStyle.Dashed)
            Dim endPoint As Point = CType(sender, Control).PointToScreen(New Point(e.X, e.Y))
            Dim width As Integer = endPoint.X - startPoint.X
            Dim height As Integer = endPoint.Y - startPoint.Y
            CaptureRectangle = New Rectangle(startPoint.X, startPoint.Y, width, height)
            ControlPaint.DrawReversibleFrame(CaptureRectangle, Me.BackColor, FrameStyle.Dashed)
            Me.Invalidate()
        End If
    End Sub
    Private Sub ScreenCapturer_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        isDrag = False
        ControlPaint.DrawReversibleFrame(CaptureRectangle, Me.BackColor, FrameStyle.Dashed)
        Me.Hide()
        Threading.Thread.Sleep(250)
        ' get the image
        GetScreenShotImage(CaptureRectangle)
        Me.Cursor = Cursors.Default
        Me.Owner.Show()
        CaptureRectangle = New Rectangle(0, 0, 0, 0)
    End Sub
    Private Sub ScreenCapturer_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim rect As Rectangle = CaptureRectangle
        If rect.Width < 0 Then
            rect.X += rect.Width
            rect.Width = -rect.Width
        End If
        If rect.Height < 0 Then
            rect.Y += rect.Height
            rect.Height = -rect.Height
        End If
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(25, m_color)), rect)
        e.Graphics.DrawRectangle(SystemPens.Highlight, rect)
    End Sub

    Private Sub Frmcaptureclass_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class