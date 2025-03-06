Public Class SplashScreen1
    Sub New
        InitializeComponent()
        Me.labelCopyright.Text = "Copyright © 1998-" & DateTime.Now.Year.ToString()
    End Sub

<<<<<<< HEAD
    Public Overrides Sub ProcessCommand(ByVal cmd As [Enum], ByVal arg As Object)
=======
    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum SplashScreenCommand
        SomeCommandId
    End Enum
End Class
