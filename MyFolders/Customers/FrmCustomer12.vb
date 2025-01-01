
Public Class FrmCustomer12
    Private Sub FrmCustomer12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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
    Public Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
        Dim f As New FrmCUSTOMER11
        Try

            If Me.RadioButton1.Checked = True Then
                f.TB1 = Trim(Texser.Text)
            ElseIf Me.RadioButton2.Checked = True Then
                f.TB2 = Trim(Texser.Text)
            ElseIf Me.RadioButton3.Checked = True Then
                f.TB3 = Trim(Texser.Text)
            ElseIf Me.RadioButton4.Checked = True Then
                f.TB4 = Trim(Texser.Text)
            ElseIf Me.RadioButton5.Checked = True Then
                f.TB5 = Trim(Texser.Text)
            ElseIf Me.RadioButton6.Checked = True Then
                f.TB6 = Trim(Texser.Text)
            End If
            f.Show()
            f.DanLOd()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmCustomer12_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class