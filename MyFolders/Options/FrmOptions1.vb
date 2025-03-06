Imports System.Diagnostics
Public Class FrmOptions1
    Dim fs As IO.FileStream
    Dim sw As IO.StreamWriter
<<<<<<< HEAD
    Private Sub ButtonAPPLY_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles ButtonAPPLY.Click
=======
    Private Sub ButtonAPPLY_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAPPLY.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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

<<<<<<< HEAD
    Private Sub FrmOptions1_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
=======
    Private Sub FrmOptions1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
        Application.Exit()
    End Sub

<<<<<<< HEAD
    Private Sub FrmOptions1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
=======
    Private Sub FrmOptions1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
        Application.Exit()
    End Sub

<<<<<<< HEAD
    Private Sub FrmOptions1_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmOptions1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        Me.TxtURL.Text = URL.ToString.Trim
        URL = Me.TxtURL.Text.Trim
        mykey.GetValue("URL", URL)

        'Dim f As New FrmLOGIN
        'f.Close()
    End Sub

End Class