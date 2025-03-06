

Public Class FrmSerchDOCUMENTS

<<<<<<< HEAD
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
=======
    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim f As New FormDOCUMENTS
            If Me.RadioLO_NO.Checked Then
                f.TextTransactionNumber.Text = Strings.Trim(ts.Text)
            ElseIf Me.RadioDOC2_NO.Checked Then
                f.TextFileNo.Text = Strings.Trim(ts.Text)
            ElseIf Me.RadioDOC4_OP.Checked Then
                f.TEXTFileSubject.Text = Strings.Trim(ts.Text)
            ElseIf Me.RadioDOC5_OP.Checked Then
                f.TextFileDescription.Text = Strings.Trim(ts.Text)
            End If
            f.BUD = False
            f.Show()
            f.DanLOd()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub FrmSerchDOCUMENTS_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmSerchDOCUMENTS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
    End Sub
End Class