

Public Class FrmJPG2

    Private Sub SearchBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBUTTON.Click
        Try
            Dim f As New FrmJPG
            If Me.RadioID.Checked Then
                f.TEXTBOX1.Text = Strings.Trim(ts.Text)
            ElseIf Me.RadioFileNo.Checked Then
                f.TEXTFileNo.Text = Strings.Trim(ts.Text)
            ElseIf Me.RadioLONO.Checked Then
                f.TextTransactionNumber.Text = Strings.Trim(ts.Text)
            End If
            f.PictureBox1.Dock = DockStyle.Fill
            Dim txt As Control
            For Each txt In f.Controls
                If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Or TypeOf txt Is Label Or TypeOf txt Is Panel Then
                    txt.Visible = False
                End If
            Next
            f.Show()
            f.FrmJPG_Load(sender, e)
            f.DanLOd()
            f.PHOTO = True
            f.ButtonXP5.PerformClick()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End Try
    End Sub

    Private Sub FrmJPG2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
    End Sub
End Class