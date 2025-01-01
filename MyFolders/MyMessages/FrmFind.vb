Public Class FrmFind
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        Dim StartPosition As Integer
        Dim SearchType As CompareMethod
        If ChkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(1, FrmMyMessages.RichTextBoxEx1.Text, TxtSearchTerm.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("" & TxtSearchTerm.Text.ToString() & " ·„ Ì „ «·⁄ÀÊ— ⁄·Ï", "·«  ÊÃœ ‰ ÌÃ…", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        FrmMyMessages.RichTextBoxEx1.Select(StartPosition - 1, TxtSearchTerm.Text.Length)
        FrmMyMessages.RichTextBoxEx1.ScrollToCaret()
        frmMAIN.Focus()
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
        Dim StartPosition As Integer = FrmMyMessages.RichTextBoxEx1.SelectionStart + 2
        Dim SearchType As CompareMethod
        If ChkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(StartPosition, FrmMyMessages.RichTextBoxEx1.Text, TxtSearchTerm.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("" & TxtSearchTerm.Text.ToString() & " ·„ Ì „ «·⁄ÀÊ— ⁄·Ï", "·«  ÊÃœ ‰ ÌÃ…", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        FrmMyMessages.RichTextBoxEx1.Select(StartPosition - 1, TxtSearchTerm.Text.Length)
        FrmMyMessages.RichTextBoxEx1.ScrollToCaret()
        frmMAIN.Focus()
    End Sub
    Private Sub FrmFind_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    PRINTBUTTON_Click(sender, e)
                Case Keys.PageUp
                    ButtonXP1_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmFind_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class