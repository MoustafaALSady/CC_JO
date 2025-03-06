
Public Class FrmMyCosts3
<<<<<<< HEAD
    Private Sub FrmMyCosts3_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next
    End Sub
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Texser.KeyPress
=======
    Private Sub FrmMyCosts3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next
    End Sub
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Texser.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
<<<<<<< HEAD
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
=======
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim f As New FrmMyCosts
        Try
            If Me.RadioButton1.Checked = True Then
                f.TB1 = Trim(Me.Texser.Text)
            ElseIf Me.customerName.Checked = True Then
                f.TB2 = Trim(Me.Texser.Text)
            ElseIf Me.CustomerNumber.Checked = True Then
                f.TB3 = Trim(Me.Texser.Text)
            End If
            f.Show()
            f.Load_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub FrmMyCosts3_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmMyCosts3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class