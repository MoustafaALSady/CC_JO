Imports System.Diagnostics

Public Class FrmWindows
    Dim fileName As String
    Public Sub ADDBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ADDBUTTON.Click
        Try
            Process.Start("intl.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP1_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP1.Click
        Try
            Shell("rundll32.exe shell32.dll,Control_RunDLL timedate.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP2_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP2.Click
        Try
            Process.Start("sysdm.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP3.Click
        Try
            Process.Start("desk.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP7_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP7.Click
        Try
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages().Item(1) 'تغيير لغة لوحة المفاتيح الى اللغه العربية
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmWindows_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    ADDBUTTON_Click(sender, e)
                Case Keys.F2
                    ButtonXP1_Click(sender, e)
                Case Keys.F3
                    ButtonXP2_Click(sender, e)
                Case Keys.F4
                    ButtonXP3_Click(sender, e)
                Case Keys.F5
                    ButtonXP7_Click(sender, e)
                Case Keys.F6
                    ButtonXP9_Click(sender, e)
                Case Keys.F7
                    ButtonXP8_Click(sender, e)
                Case Keys.F8
                    ButtonXP4_Click(sender, e)
                Case Keys.F9
                    ButtonXP5_Click(sender, e)
                Case Keys.F10
                    ButtonXP6_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP8_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP8.Click
        Try
            Process.Start("inetcpl.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP9_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP9.Click
        Try
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages().Item(0) 'تغيير لغة لوحة المفاتيح الى اللغه الانجليزيه
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP4_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP4.Click
        Try
            Dim resault As Integer
            resault = MessageBox.Show("هل تريد غلق الجهاز", "اغلاق الجهاز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Shell("shutdown -s -f -t 0")
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP5_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP5.Click
        Try
            Dim resault As Integer
            resault = MessageBox.Show("هل تريد اعادة تشغيل الويندز ", "اعادة تشغيل الويندز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Shell("shutdown -r -f -t 0")
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP6_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP6.Click
        Try
            Dim resault As Integer
            resault = MessageBox.Show("هل تريد عمل لوج اوف للويندز ", "عمل لوج اوف للويندز ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            If resault = vbYes Then
                Shell("shutdown -l -f -t 0")
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP10_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP10.Click
        Try
            Process.Start("appwiz.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP11_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP11.Click
        Try
            Process.Start("hdwwiz.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP12_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP12.Click
        Try
            Process.Start("powercfg.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP13_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP13.Click
        Try
            Process.Start("odbccp32.cpl")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub ButtonXP14_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonXP14.Click
        Try
            Dim w As New Wallpaper()
            Dim OPENFILE As New OpenFileDialog With {
                .Filter = "Bitmap Images (*.bmp)|*.bmp",
                .InitialDirectory = "%SystemRoot%"
            }
            If DialogResult.OK = OPENFILE.ShowDialog() Then
                fileName = OPENFILE.FileName
            End If
            If RadioButton1.Checked = True Then
                w.SetWallpaper(fileName, CType(System.Enum.Parse(GetType(Wallpaper.Style), RadioButton1.Text), Wallpaper.Style))
            ElseIf RadioButton2.Checked = True Then
                w.SetWallpaper(fileName, CType(System.Enum.Parse(GetType(Wallpaper.Style), RadioButton2.Text), Wallpaper.Style))
            ElseIf RadioButton3.Checked = True Then
                w.SetWallpaper(fileName, CType(System.Enum.Parse(GetType(Wallpaper.Style), RadioButton3.Text), Wallpaper.Style))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmWindows_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        Try
            Me.BackgroundImage = img
            For a As Byte = 0 To 10
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
                Me.Opacity = a / 10
            Next
            RadioButton1.Checked = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class