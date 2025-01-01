
Public Class FrmCompany1
    Private Sub FrmCompany1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
    Private Sub Texser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Texser.KeyPress
        On Error Resume Next
        If Asc(e.KeyChar) = Keys.Enter Then
            SearchBUTTON_Click(sender, e)
        End If
    End Sub
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
        Dim f As New FrmCompany
        Try
            If Me.RadioButton1.Checked = True Then
                f.TB1 = Trim(Texser.Text)
            ElseIf Me.RadioButton2.Checked = True Then
                f.TB2 = Trim(Texser.Text)
            ElseIf Me.RadioButton3.Checked = True Then
                f.TB3 = Trim(Texser.Text)
            End If
            f.Show()
            f.ButtonXP4_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

End Class