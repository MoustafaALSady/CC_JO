Public Class FrmInvoice2
<<<<<<< HEAD
    Private Sub FrmInvoice2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
=======
    Private Sub FrmInvoice2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
<<<<<<< HEAD
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Texser.KeyPress
=======
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
        Try
            Dim f As New FrmInvoice
            If Me.RbTB1.Checked = True Then
                f.TB1_chk = True
                f.TB1 = Trim(Me.Texser.Text)
            ElseIf Me.RbTB2.Checked = True Then
                f.TB2_chk = True
                f.TB2 = Trim(Me.Texser.Text)
            ElseIf Me.RbTB3.Checked = True Then
                f.TB3_chk = True
                f.TB3 = Trim(Me.Texser.Text)
            End If
            f.Show()
            f.DanLOd()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub FrmInvoice2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmInvoice2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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