Imports System.ComponentModel

Public Class FsButton
<<<<<<< HEAD
    Inherits Control
=======
    Inherits System.Windows.Forms.Control
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Event ButtonThemeChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event ThemeColorChanged(ByVal sender As Object, ByVal e As EventArgs)
    Event ShowTextEffectsChanged(ByVal sender As Object, ByVal e As EventArgs)

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        MyBase.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        MyBase.SetStyle(ControlStyles.UserPaint, True)
        MyBase.SetStyle(ControlStyles.DoubleBuffer, True)
        MyBase.SetStyle(ControlStyles.ResizeRedraw, True)
        MyBase.SetStyle(ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    'UserControl1 overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
<<<<<<< HEAD
    Private components As IContainer
=======
    Private components As System.ComponentModel.IContainer
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
<<<<<<< HEAD
    <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New Container
=======
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub

#End Region

    Private isMouseOver As Boolean = False
    Private isMouseDown As Boolean = False
    Private isFocused As Boolean = False

    Private _Theme As Themes
    Private _ThemeColor As Color = CRGB(0, 102, 255)
    Private _ShowTextEffects As Boolean = True

    Public Enum Themes
        LiquidChromeXP
        SoftGlassXP
        WindowsXP
        MSNLoginButton
        Aqua
        Hover3D
        OfficeXP
        Office2003
        Macintosh
    End Enum

    <Description("Determines whether or not to show the text effects for the selected theme."), DefaultValue(GetType(Boolean), "True")>
    Property ShowTextEffects() As Boolean
        Get
            Return _ShowTextEffects
        End Get
        Set(ByVal Value As Boolean)
            _ShowTextEffects = Value
            Me.Invalidate()
            RaiseEvent ShowTextEffectsChanged(Me, New EventArgs)
        End Set
    End Property

    <Description("Sets the base color for the theme."), DefaultValue(GetType(Color), "0, 102, 255")>
    Property ThemeColor() As Color
        Get
            Return _ThemeColor
        End Get
        Set(ByVal Value As Color)
            _ThemeColor = Value
            Me.Invalidate()
            RaiseEvent ThemeColorChanged(Me, New EventArgs)
        End Set
    End Property

    <Description("Controls the theme which is applied to the button."), DefaultValue(GetType(Themes), "LiquidChromeXP")>
    Property ButtonTheme() As Themes
        Get
            Return _Theme
        End Get
        Set(ByVal Value As Themes)
            _Theme = Value
            Me.Invalidate()
            RaiseEvent ButtonThemeChanged(Me, New EventArgs)
        End Set
    End Property

<<<<<<< HEAD
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
=======
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnPaint(e)

        'Add all painting code here

        Dim s As Theme.States

        If Me.Enabled = False Then
            s = Theme.States.Disabled
        Else
            If isMouseDown = False Then
                If isMouseOver = True Then
                    s = Theme.States.MouseOver
                Else
                    If isFocused = True Then
                        s = Theme.States.Focused
                    Else
                        s = Theme.States.Normal
                    End If
                End If
            Else
                s = Theme.States.MouseDown
            End If
        End If
        Select Case _Theme
            Case Themes.LiquidChromeXP
                Dim t As New Theme.LiquidChromeXP(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.SoftGlassXP
                Dim t As New Theme.SoftGlassXP(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ThemeColor, _ShowTextEffects)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.WindowsXP
                Dim t As New Theme.WindowsXP(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.MSNLoginButton
                Dim t As New Theme.MSNLoginButton(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects, Me.BackColor)
                t.DrawText(e, s, Me.Text, Me.Font)
            Case Themes.Aqua
                Dim t As New Theme.Aqua(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects, _ThemeColor)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.Hover3D
                Dim t As New Theme.Hover3D(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects, isFocused)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.OfficeXP
                Dim t As New Theme.OfficeXP(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects, _ThemeColor, isFocused)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.Office2003
                Dim t As New Theme.Office2003(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects, _ThemeColor, isFocused)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
            Case Themes.Macintosh
                Dim t As New Theme.Macintosh(New Rectangle(0, 0, Me.Width, Me.Height))
                t.DrawTheme(e, s, _ShowTextEffects, _ThemeColor)
                t.DrawText(e, s, Me.Text, Me.Font, Me.ForeColor)
        End Select

    End Sub


<<<<<<< HEAD
    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
=======
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnMouseMove(e)

        If e.Button = MouseButtons.None Or e.Button = MouseButtons.Left Then
            If e.Button = MouseButtons.None Then
                isMouseDown = False
            End If
            isMouseOver = True
        Else
            If Not New Rectangle(0, 0, Me.Width, Me.Height).Contains(e.X, e.Y) Then
                isMouseOver = False
            Else
                isMouseOver = True
            End If
        End If

        If e.Button = MouseButtons.Left Then
            If Not New Rectangle(0, 0, Me.Width, Me.Height).Contains(e.X, e.Y) Then
                isMouseDown = False
            Else
                isMouseDown = True
            End If
        End If
        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
=======
    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnMouseLeave(e)

        isMouseOver = False
        isMouseDown = False

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
=======
    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnMouseDown(e)

        If e.Button = MouseButtons.Left Then
            If New Rectangle(0, 0, Me.Width, Me.Height).Contains(e.X, e.Y) Then
                isMouseDown = True
            Else
                isMouseDown = False
            End If

            Me.Focus()
        End If

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
=======
    Protected Overrides Sub OnMouseUp(ByVal e As System.Windows.Forms.MouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        MyBase.OnMouseUp(e)

        If e.Button = MouseButtons.Left Then
            isMouseDown = False
        End If

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnEnter(ByVal e As EventArgs)
=======
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnEnter(e)

        isFocused = True

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnLeave(ByVal e As EventArgs)
=======
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnLeave(e)

        isFocused = False

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
=======
    Protected Overrides Sub OnKeyDown(ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnKeyDown(e)

        If e.KeyCode = Keys.Space Then
            isMouseDown = True
        End If

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnKeyUp(ByVal e As KeyEventArgs)
=======
    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnKeyUp(e)

        If e.KeyCode = 32 Then
            isMouseDown = False
            MyBase.OnClick(e)
        End If

        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
=======
    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnTextChanged(e)
        Me.Invalidate()
    End Sub

<<<<<<< HEAD
    Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
=======
    Protected Overrides Sub OnEnabledChanged(ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.OnEnabledChanged(e)
        Me.Invalidate()
    End Sub
End Class
