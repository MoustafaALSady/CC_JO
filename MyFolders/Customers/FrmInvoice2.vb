Public Class FrmInvoice2
    Private Sub FrmInvoice2_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Texser.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
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

    Private Sub FrmInvoice2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class