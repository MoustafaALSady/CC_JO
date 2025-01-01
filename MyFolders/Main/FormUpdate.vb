Imports System.Diagnostics
Public Class FormUpdate
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As EventArgs) Handles Timer1.Tick
        For OP As Integer = 100 To 10 Step -1
            Me.Opacity = OP / 100
            Me.Refresh()
        Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub

    Private Sub Update_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Click
        On Error Resume Next
        Me.Timer1.Enabled = False
        Me.Close()
    End Sub

    Private Sub FormUpdate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub ButtonUpdate_Click(sender As Object, e As EventArgs) Handles ButtonUpdate.Click
        If Trim(tmpV) > Trim(mykey.GetValue("ProductVersion", "")) Then
            Dim MSG_ As Integer = MessageBox.Show("هل تريد اتمام تحديث البرنامج للاصدار الجديد؟", "تنبيه بوجود تحديد", MessageBoxButtons.YesNo)
            If MSG_ = DialogResult.Yes Then
                Process.Start(Application.StartupPath & "\Update_CO.exe")
                'My.Settings.VProject = Trim(tmpV)
                'My.Settings.Save()
                Application.Exit()
            Else
                MsgBox("شكراً لك.")
            End If
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

End Class