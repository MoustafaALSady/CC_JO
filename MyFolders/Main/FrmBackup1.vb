Imports System.IO

Public Class FrmBackup1
    Private Sub ChAppendTo_CheckedChanged(sender As Object, e As EventArgs) Handles ChAppendTo.CheckedChanged
        If Me.ChAppendTo.Checked Then Me.ChOverwriteAll.Checked = False
    End Sub

    Private Sub ChOverwriteAll_CheckedChanged(sender As Object, e As EventArgs) Handles ChOverwriteAll.CheckedChanged
        If Me.ChOverwriteAll.Checked Then Me.ChAppendTo.Checked = False
    End Sub

    Private Sub RaToExisting_CheckedChanged(sender As Object, e As EventArgs) Handles RaToExisting.CheckedChanged
        If Me.RaToExisting.Checked = True Then
            Me.ChAppendTo.Enabled = True
            Me.ChOverwriteAll.Enabled = True
            Me.ChAppendTo.Checked = True
            Me.ChOverwriteAll.Checked = False
        Else
            Me.ChAppendTo.Enabled = False
            Me.ChOverwriteAll.Enabled = False
        End If
    End Sub

    Private Sub ButBackup_Click(sender As Object, e As EventArgs) Handles ButBackup.Click
        Dim BackupOptions As String = Nothing
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        Dim BackupPath As String = MYFOLDER & "\Backup\" & Me.ComboDBServer.Text & "_Full_" & Now.ToString("dd-MM-yyyy-hh-mm-tt") & ".bak"
        Dim BackupType As Short = 0
        Dim IsBackupSucceed As Boolean = False
        If String.IsNullOrEmpty(BackupPath) Then
            MessageBox.Show("من فضلك حدد قاعدة البيانات  ", "حدد قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return
        End If
        If My.Computer.FileSystem.FileExists(BackupPath) = False Then System.IO.Directory.CreateDirectory(BackupPath)
        If Me.RaToExisting.Checked AndAlso Me.ChAppendTo.Checked Then
            BackupOptions = "NOFORMAT, NOINIT,SKIP"
        ElseIf Me.RaToExisting.Checked AndAlso Me.ChOverwriteAll.Checked Then
            BackupOptions = "NOFORMAT, INIT,SKIP"
        ElseIf Me.RaToNew.Checked Then
            BackupOptions = "FORMAT, INIT,SKIP"
        End If
        Dim Sqlconsar As String = Nothing
        If AuthenicationSQLServer = True And LocalConnection = True Then
            Sqlconsar = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
            Sqlconsar = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
            Sqlconsar = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
        End If
        Dim SqlConnection1 As New SqlClient.SqlConnection(Sqlconsar)
        Dim CMD As New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = SqlConnection1
                }
        If SqlConnection1.State = ConnectionState.Open Then SqlConnection1.Close()
        SqlConnection1.Open()
        IsBackupSucceed = BackupDatabase(SqlConnection1, Me.ComboDBServer.Text, BackupPath, BackupOptions, BackupType)
        If IsBackupSucceed = True Then

        End If
    End Sub

    Private Sub ButtonXP1_Click(sender As Object, e As EventArgs) Handles ButtonXP1.Click
        On Error Resume Next
        With Me.FolderBrowserDialog1
            .ShowNewFolderButton = True
            .RootFolder = Environment.SpecialFolder.MyComputer
            .ShowDialog()
            Me.LabelMYFOLDER.Text = .SelectedPath
        End With
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub
End Class