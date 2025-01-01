Public Class FrmAllCustomers2
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
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
        Dim f As New FrmAllCustomers
        Try
            If Me.RadioButton1.Checked = True Then
                f.TB1 = Trim(Me.Texser.Text)
                f.APALL = False
                f.APALL1 = False
            ElseIf Me.RadioButton2.Checked = True Then
                f.TB2 = Trim(Me.Texser.Text)
                f.APALL = False
                f.APALL1 = False
            ElseIf Me.RadioButton3.Checked = True Then
                f.APALL = True
                f.APALL1 = False
            ElseIf Me.RadioButton4.Checked = True Then
                f.APALL = False
                f.APALL1 = True
            End If
            f.Show()
            f.Load1_Click(sender, e)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmAllCustomers2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next

        Call MangUsers()
        If Managers = True Then
            Me.RadioButton4.Enabled = True
        Else
            Me.RadioButton4.Enabled = False
        End If

    End Sub

End Class