Public Class FormUserSettings
    Private Sub FormUserSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextSettings.Text = My.Settings.HoomPage
    End Sub

    Private Sub ButtonSet_EditValueChanged(sender As Object, e As EventArgs) Handles ButtonSet.Click
        My.Settings.HoomPage = TextSettings.Text
        My.Settings.Save()
        MsgBox("Done")
        Me.Visible = False
    End Sub

    Private Sub ButtonDefault_EditValueChanged(sender As Object, e As EventArgs) Handles ButtonDefault.Click
        My.Settings.HoomPage = ("https://www.google.com/")
        My.Settings.Save()
        MsgBox("Title (URL) Default")
        Me.Close()
    End Sub



End Class