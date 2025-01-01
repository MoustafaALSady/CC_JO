

Public Class FrmSerchDOCUMENTS

    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SearchBUTTON.Click
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

    Private Sub FrmSerchDOCUMENTS_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
    End Sub
End Class