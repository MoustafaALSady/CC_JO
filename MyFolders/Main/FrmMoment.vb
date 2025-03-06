Public Class FrmMoment
<<<<<<< HEAD
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick
=======
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        For OP As Integer = 100 To 10 Step -1
            Me.Opacity = OP / 100
            Me.Refresh()
        Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub

<<<<<<< HEAD
    Private Sub FrmMoment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click, Label1.Click
=======
    Private Sub FrmMoment_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click, Label1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub

<<<<<<< HEAD
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
=======
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.Timer1.Enabled = True
        Me.Left = My.Computer.Screen.WorkingArea.Width - Me.Width
        Me.Top = My.Computer.Screen.WorkingArea.Height - Me.Height

<<<<<<< HEAD
        Dim Sound As IO.Stream = My.Resources.Right_Anser1
=======
        Dim Sound As System.IO.Stream = My.Resources.Right_Anser1
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)

    End Sub


End Class
