
Public Class FrmReplace
<<<<<<< HEAD
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
=======
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim StartPosition As Integer
        Dim SearchType As CompareMethod

        If ChkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(1, FrmMyMessages.RichTextBoxEx1.Text, TxtSearchTerm.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("" & TxtSearchTerm.Text.ToString() & "·„ Ì „ «·⁄ÀÊ— ⁄·Ï", "·«  ÊÃœ ‰ ÌÃ…", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        FrmMyMessages.RichTextBoxEx1.Select(StartPosition - 1, TxtSearchTerm.Text.Length)
        FrmMyMessages.RichTextBoxEx1.ScrollToCaret()
        FrmMyMessages.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
=======
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim StartPosition As Integer = FrmMyMessages.RichTextBoxEx1.SelectionStart + 2
        Dim SearchType As CompareMethod
        If ChkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(StartPosition, FrmMyMessages.RichTextBoxEx1.Text, TxtSearchTerm.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("" & TxtSearchTerm.Text.ToString() & "·„ Ì „ «·⁄ÀÊ— ⁄·Ï", "·«  ÊÃœ ‰ ÌÃ…", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        FrmMyMessages.RichTextBoxEx1.Select(StartPosition - 1, TxtSearchTerm.Text.Length)
        FrmMyMessages.RichTextBoxEx1.ScrollToCaret()
        FrmMyMessages.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP2.Click
=======
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If FrmMyMessages.RichTextBoxEx1.SelectedText.Length <> 0 Then
            FrmMyMessages.RichTextBoxEx1.SelectedText = TxtReplacementText.Text
        End If
        Dim StartPosition As Integer = FrmMyMessages.RichTextBoxEx1.SelectionStart + 2
        Dim SearchType As CompareMethod
        If ChkMatchCase.Checked = True Then
            SearchType = CompareMethod.Binary
        Else
            SearchType = CompareMethod.Text
        End If
        StartPosition = InStr(StartPosition, FrmMyMessages.RichTextBoxEx1.Text, TxtSearchTerm.Text, SearchType)
        If StartPosition = 0 Then
            MessageBox.Show("" & TxtSearchTerm.Text.ToString() & "·„ Ì „ «·⁄ÀÊ— ⁄·Ï", "·«  ÊÃœ ‰ ÌÃ…", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If
        FrmMyMessages.RichTextBoxEx1.Select(StartPosition - 1, TxtSearchTerm.Text.Length)
        FrmMyMessages.RichTextBoxEx1.ScrollToCaret()
        FrmMyMessages.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP3.Click
=======
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP3.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim currentPosition As Integer = FrmMyMessages.RichTextBoxEx1.SelectionStart
        Dim currentSelect As Integer = FrmMyMessages.RichTextBoxEx1.SelectionLength
        FrmMyMessages.RichTextBoxEx1.Rtf = Replace(FrmMyMessages.RichTextBoxEx1.Rtf, Trim(TxtSearchTerm.Text), Trim(TxtReplacementText.Text))
        FrmMyMessages.RichTextBoxEx1.SelectionStart = currentPosition
        FrmMyMessages.RichTextBoxEx1.SelectionLength = currentSelect
        FrmMyMessages.Focus()
    End Sub
<<<<<<< HEAD
    Private Sub FrmReplace_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmReplace_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    PRINTBUTTON_Click(sender, e)
                Case Keys.F2
                    ButtonXP2_Click(sender, e)
                Case Keys.F3
                    ButtonXP3_Click(sender, e)
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

<<<<<<< HEAD
    Private Sub FrmReplace_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmReplace_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
    End Sub
End Class