Public Class FrmAllCustomers2
<<<<<<< HEAD
    Private Sub FrmCustomer12_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles Me.KeyPress
=======
    Private Sub FrmCustomer12_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
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

<<<<<<< HEAD
    Private Sub FrmAllCustomers2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmAllCustomers2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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