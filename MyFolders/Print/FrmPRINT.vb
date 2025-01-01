
Public Class FrmPRINT

    Private Sub FrmPRINT_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F5
                    Me.CrystalReportViewer1.PrintReport()
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButPrintSetting_Click(sender As Object, e As EventArgs) Handles ButPrintSetting.Click
        Dim F As New FormPrintOptions
        F.Show()

    End Sub

End Class
