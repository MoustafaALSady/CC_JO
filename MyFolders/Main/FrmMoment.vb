Public Class FrmMoment
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick
        For OP As Integer = 100 To 10 Step -1
            Me.Opacity = OP / 100
            Me.Refresh()
        Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub

    Private Sub FrmMoment_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click, Label1.Click
        On Error Resume Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.Timer1.Enabled = True
        Me.Left = My.Computer.Screen.WorkingArea.Width - Me.Width
        Me.Top = My.Computer.Screen.WorkingArea.Height - Me.Height

        Dim Sound As IO.Stream = My.Resources.Right_Anser1
        My.Computer.Audio.Play(Sound, AudioPlayMode.WaitToComplete)

    End Sub


End Class
