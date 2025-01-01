Imports System.Diagnostics
Public Class FrmOptions1
    Dim fs As IO.FileStream
    Dim sw As IO.StreamWriter
    Private Sub ButtonAPPLY_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAPPLY.Click
        URL = Me.TxtURL.Text.Trim
        mykey.SetValue("URL", Me.TxtURL.Text.Trim)


        fs = New IO.FileStream(Application.StartupPath & "/URL.txt", IO.FileMode.Create)
        sw = New IO.StreamWriter(fs)
        sw.WriteLine(Me.TxtURL.Text.Trim)
        sw.Close()
        fs.Close()
        Me.Close()
        Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
        Application.Exit()
    End Sub

    Private Sub FrmOptions1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed

        Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
        Application.Exit()
    End Sub

    Private Sub FrmOptions1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
        Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
        Application.Exit()
    End Sub

    Private Sub FrmOptions1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TxtURL.Text = URL.ToString.Trim
        URL = Me.TxtURL.Text.Trim
        mykey.GetValue("URL", URL)

        'Dim f As New FrmLOGIN
        'f.Close()
    End Sub

End Class