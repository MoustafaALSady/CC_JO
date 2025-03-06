Public Class WaitForm
    Sub New
        InitializeComponent()
        Me.progressPanel1.AutoHeight = True
    End Sub

    Public Overrides Sub SetCaption(ByVal caption As String)
        MyBase.SetCaption(caption)
        Me.progressPanel1.Caption = caption
    End Sub

    Public Overrides Sub SetDescription(ByVal description As String)
        MyBase.SetDescription(description)
        Me.progressPanel1.Description = description
    End Sub

<<<<<<< HEAD
    Public Overrides Sub ProcessCommand(ByVal cmd As [Enum], ByVal arg As Object)
=======
    Public Overrides Sub ProcessCommand(ByVal cmd As System.Enum, ByVal arg As Object)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        MyBase.ProcessCommand(cmd, arg)
    End Sub

    Public Enum WaitFormCommand
        SomeCommandId
    End Enum
End Class
