Option Explicit Off
Public Class FrmjoNumberToString
    Inherits Form
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles Timer1.Tick
        On Error Resume Next
        Me.Label1.Text = Format(DateTime.Now, "dd-MM-yyyy  ****  hh:mm:ss tt")
        Me.Label2.Text = MytimeWord(DateTime.Now)
        Me.Label3.Text = MydateWord(DateTime.Now)
    End Sub

    Private Sub FrmAMOUNTWORD_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.TextBox1.Text = "1"
        Me.TextBox1.SelectAll()
        Me.TextBox1.Focus()
        Me.Label1.Text = Format(DateTime.Now, "dd-MM-yyyy  ****  hh:mm:ss tt")
        Me.Label2.Text = MytimeWord(Format(DateTime.Now, "hh:mm:ss tt"))
        Me.Label3.Text = MydateWord(Format(DateTime.Now, "dd-MM-yyyy"))
        Me.ComboBox1.Text = "œÌ‰«— «—œ‰Ì"
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        On Error Resume Next
        Dim typeamount As String = ""
        If Len(Me.TextBox1.Text) <> 0 Then
            Select Case Me.ComboBox1.Text
                Case Is = "œÌ‰«— «—œ‰Ì"
                    typeamount = "jO"
                Case Is = "«·œÊ·«— «·«„—ÌﬂÏ"
                    typeamount = "USA"
                Case Is = "«·Ê“‰"
                    typeamount = "WEIGHT"
            End Select
            Me.Label4.Text = CurrencyJO(Me.TextBox1.Text, typeamount)
        Else
            MessageBox.Show("„‰ ›÷·ﬂ «œŒ· ﬁÌ„… ›Ï «·„—»⁄", "«· ›ﬁÌÿ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.TextBox1.Focus()
        End If
    End Sub
    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles TextBox1.KeyDown
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.SendWait("{TAB}")
        End Select
    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        On Error Resume Next
        Dim typeamount As String = ""
        If Len(Me.TextBox1.Text) <> 0 Then
            Select Case Me.ComboBox1.Text
                Case Is = "œÌ‰«— «—œ‰Ì"
                    typeamount = "jO"
                Case Is = "«·œÊ·«— «·«„—ÌﬂÏ"
                    typeamount = "USA"
                Case Is = "«·Ê“‰"
                    typeamount = "WEIGHT"
            End Select
            Me.Label4.Text = CurrencyJO(Me.TextBox1.Text, typeamount)
        Else
            MessageBox.Show("„‰ ›÷·ﬂ «œŒ· ﬁÌ„… ›Ï «·„—»⁄", "«· ›ﬁÌÿ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.TextBox1.Focus()
        End If
    End Sub
End Class
