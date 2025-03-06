Imports DevExpress.XtraEditors.Controls
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Smo

Public Class FrmRestore

<<<<<<< HEAD
    Private Sub FrmRestore_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub FrmRestore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Select Case e.KeyCode
                Case Keys.Enter
                    BUTTONDeatch_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmRestore_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        'sql = "Data Source=(Local); DataBase=; Integrated Security=SSPI"

        Call MangUsers()
        'Me.FILL_COMBO()
        FollCombByDataBases1(ServerName, ComboBox1)
        'Me.TextBackupPath.Enabled = False
        Me.GroupBox3.Enabled = True
        Me.GroupBox2.Enabled = True
        Me.RadioCustom.Checked = True
        Me.RadioALLData.Checked = True
        Me.RadioSchemaAndData.Checked = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = 100
    End Sub
    Private Sub FILL_COMBO()
        On Error Resume Next
        Dim DS As New DataSet
        'Dim SqlConnection1 As New SqlClient.SqlConnection("Data Source=" + ServerName + "," + PORT + ";Initial Catalog=tempdb;User Id=" + userIDName + ";Password=" + BWS1 + ";")
        'Dim SqlConnection1 As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=" + My.Computer.Name & "\SQLEXPRESS" + ";Initial Catalog=tempdb;Integrated Security=SSPI;")
        Dim ServerConnectionString As String = Nothing
        If AuthenicationSQLServer = True And LocalConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
            ServerConnectionString = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
        End If
        Dim SqlConnection1 As New SqlClient.SqlConnection(ServerConnectionString)

        Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name not IN('master','msdb','tempdb' ,'model','ReportServer','ReportServerTempDB') and has_dbaccess(Name) = 1 order by name "
        Dim ADP As SqlClient.SqlDataAdapter
        ADP = New SqlClient.SqlDataAdapter(str, SqlConnection1)
        DS.Clear()
        ADP.Fill(DS)
        Me.ComboBox1.Items.Clear()
        Dim i As Integer
        For i = 0 To DS.Tables(0).Rows.Count - 1
            Me.ComboBox1.Items.Add(DS.Tables(0).Rows(i).Item(0))
        Next
        ADP.Dispose()
        SqlConnection1.Dispose()
    End Sub

    Private Sub TextBackupPath_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TextBackupPath.ButtonClick
        On Error Resume Next
        If Len(Me.ComboBox1.Text) = 0 Then
            MessageBox.Show("من فضلك حدد قاعدة البيانات  ", "حدد قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.ComboBox1.Focus()
            Exit Sub
        End If
        OpenFileDialog1.Filter = "Crash Dump File (*.dmp)|*.dmp|SQL Server Transaction Log Backup (*.trn)|*.trn|BAK File (*.bak)|*.bak|All files (*.*)|*.*"
        With Me.OpenFileDialog1
            .FilterIndex = 3
            .Title = "اختيار ملف"
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            .InitialDirectory = MYFOLDER & "\Backup"
            .AddExtension = True
            .ShowDialog()
            If Len(.FileName) > 0 Then
                Me.TextBackupPath.Text = OpenFileDialog1.FileName
            End If
        End With
    End Sub

<<<<<<< HEAD
    Private Sub BUTTONDeatch_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BUTTONDeatch.Click
=======
    Private Sub BUTTONDeatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUTTONDeatch.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If RAdmin = False Then
            MsgBox("عفوا .. هذا الامر للمشرف العام فقط", 16, "تنبيه")
            Exit Sub
        End If
        If Len(Me.ComboBox1.Text) = 0 Then
            MessageBox.Show("من فضلك حدد قاعدة البيانات  ", "حدد قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.ComboBox1.Focus()
            Exit Sub
        End If
        If Len(Me.TextBackupPath.Text) = 0 Then
            MessageBox.Show("من فضلك حدد مسار النسخة الاحتياطية  ", "مسار النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
            Me.TextBackupPath.Focus()
            Exit Sub
        End If

        If Me.RadioStandard.Checked = True Then
            Try
                'CloseAllConnection(Me.ComboBox1.Text, Me)
                Dim ServerConnectionString As String = Nothing
                If AuthenicationSQLServer = True And LocalConnection = True Then
                    ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                    ServerConnectionString = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                    ServerConnectionString = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
                End If
                Dim SqlConnection1 As New SqlClient.SqlConnection(ServerConnectionString)
                Dim CMD As New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = SqlConnection1
                }
                If SqlConnection1.State = ConnectionState.Open Then SqlConnection1.Close()
                SqlConnection1.Open()
                CMD.CommandText = "restore database " + Me.ComboBox1.Text.Trim + " from disk =@PATHFILE "
                CMD.Parameters.Add("@PATHFILE", SqlDbType.NVarChar, 500).Value = Me.TextBackupPath.Text
                CMD.ExecuteNonQuery()
                SqlConnection1.Dispose()
                MessageBox.Show("نجح استرجاع البيانات من النسخه الاحتياطية  ", "استرجاع البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show("فشل البرنامج فى استرجاع البيانات من النسخه الاحتياطية" & vbCrLf & vbCrLf & ex.Message & ex.Source, "استرجاع البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                Exit Sub
            End Try

        Else
            Try
                'Dim ServerConnectionString As String = "Data Source=" + ServerName + "," + PORT + ";User Id=" + userIDName + ";Password=" + BWS1 + ";Connect Timeout=30"
                Dim ServerConnectionString As String = Nothing
                If AuthenicationSQLServer = True And LocalConnection = True Then
                    ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";Connect Timeout=30"
                ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                    ServerConnectionString = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";Connect Timeout=30"
                ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                    ServerConnectionString = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True;Connect Timeout=30"
                End If
                Dim sqlCon As New SqlClient.SqlConnection(ServerConnectionString)
                Dim srvrConnection As New ServerConnection(sqlCon)
                Dim MyServer As New Server(srvrConnection)
                Dim MyRestore As New Restore
                If Me.RadioSchemaAndData.Checked = True Then
                    MyRestore.Action = BackupActionType.Database
                    MyRestore.Checksum = True
                    MyRestore.Partial = False
                ElseIf Me.RadioDataOnly.Checked = True Then
                    MyRestore.Action = BackupActionType.Files
                    MyRestore.Checksum = True
                ElseIf Me.RadioData.Checked = True Then
                    MyRestore.Action = BackupActionType.Log
                End If

                MyRestore.ContinueAfterError = True
                MyRestore.Database = Me.ComboBox1.Text.Trim
                Dim MyDevice As New BackupDeviceItem(Me.TextBackupPath.Text.Trim, DeviceType.File)
                MyRestore.Devices.Add(MyDevice)
                MyRestore.ReplaceDatabase = True

                If Me.RadioALLData.Checked = True Then
                    MyRestore.Partial = False
                ElseIf Me.RadioNewData.Checked = True Then
                    MyRestore.Partial = True
                End If


                Me.ProgressBar1.Visible = True
                MyRestore.PercentCompleteNotification = 10
                Me.ProgressBar1.Value = MyRestore.PercentCompleteNotification
                AddHandler MyRestore.PercentComplete, AddressOf ProgressEventHandler
                If MyRestore.SqlVerify(MyServer) Then
                    MyServer.KillAllProcesses(Me.ComboBox1.Text.Trim)
                    MyServer.DetachDatabase(Me.ComboBox1.Text.Trim, True)
                    MyRestore.SqlRestore(MyServer)
                End If
                MessageBox.Show("نجح استرجاع البيانات من النسخه الاحتياطية  ", "استرجاع البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show("فشل البرنامج فى استرجاع البيانات من النسخه الاحتياطية" & vbCrLf & vbCrLf & ex.Message & ex.Source, "استرجاع البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                Exit Sub
            End Try
        End If
        '    Application.Exit()
        '    Process.Start(Application.StartupPath & "\" & "CC_JO.exe")

        Me.Cursor = Cursors.Default
        'CloseAllConnection(DBServer, Me)
        Consum.Dispose()
        Me.ComboBox1.Text = ""
        Me.TextBackupPath.Text = ""
    End Sub
    Private Sub ProgressEventHandler(ByVal sender As Object,
                                    ByVal e As PercentCompleteEventArgs)
        Static I As Integer = 1
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Step = 10
        Me.ProgressBar1.Value = I
        I += 10
        If CInt(e.Percent) = 100 Then
            Me.ProgressBar1.Visible = False
            I = 10
        End If
        Me.LabelRestore.Text = e.Percent.ToString + "% Restore"
    End Sub
<<<<<<< HEAD
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioStandard.Click
=======
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioStandard.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.RadioStandard.Checked = True Then
                Me.GroupBox3.Enabled = False
                Me.GroupBox2.Enabled = False
            Else
                Me.GroupBox3.Enabled = True
                Me.GroupBox2.Enabled = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioCustom.Click
=======
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioCustom.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.RadioCustom.Checked = True Then
                Me.GroupBox3.Enabled = True
                Me.GroupBox2.Enabled = True
            Else
                Me.GroupBox3.Enabled = False
                Me.GroupBox2.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles ComboBox1.SelectedIndexChanged
=======
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.LabelRestore.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)
        End Try
    End Sub

End Class