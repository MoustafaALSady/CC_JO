Imports System.Data.SqlClient
Imports System.IO
Imports DevExpress.XtraEditors.Controls
Imports Microsoft.SqlServer.Management.Common
Imports Microsoft.SqlServer.Management.Smo
Public Class FrmBackup
    Dim Dt As String
    Dim Ext As String
    ReadOnly Cnn As New SqlClient.SqlConnection
    Dim Rdr As SqlDataReader

    Private Sub BUTTONBACKUP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP2.Click
        If RAdmin = False Then
            MsgBox("عفوا .. هذا الامر للمشرف العام فقط", 16, "تنبيه")
            Exit Sub
        End If
        Me.Labelbacked.Text = ""
        If Len(Me.ComboDBServer.Text) = 0 Then
            MessageBox.Show("من فضلك حدد قاعدة البيانات  ", "حدد قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.ComboDBServer.Focus()
            Exit Sub
        End If
        If Me.CheckBox1.Checked = True Then
            If Len(Me.ComboBox2.Text) = 0 Then
                MessageBox.Show("من فضلك حدد نوع ملف النسخة الاحتياطية  ", "حدد نوع ملف النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Me.ComboBox2.Focus()
                Exit Sub
            End If
        End If
        If Len(Me.TextBackupPath.Text) = 0 Then
            MessageBox.Show("من فضلك حدد مسار النسخة الاحتياطية  ", "حدد مسار النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.TextBackupPath.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor

        If Me.RadioStandard.Checked = True Then
            Try
                'Dim SqlConnection1 As New SqlClient.SqlConnection("Data Source=" + ServerName + "," + PORT + ";Initial Catalog=tempdb;User Id=" + userIDName + ";Password=" + BWS1 + ";")
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
                'CloseAllConnection(Me.ComboBox1.Text.Trim, Me)
                CMD.CommandText = "backup database " + Me.ComboDBServer.Text.Trim + " to disk=@PATHFILE with init"
                Dt = ServerDateTime.ToString("yyyy-MM-dd-mm-tt") 'Format(Now, "dd-MM-yyyy-hh-mm-tt")

                CMD.Parameters.Add("@PATHFILE", SqlDbType.NVarChar, 500).Value = Me.TextBackupPath.Text.Trim
                If SqlConnection1.State = ConnectionState.Closed Then SqlConnection1.Open()
                CMD.ExecuteNonQuery()
                SqlConnection1.Dispose()
                MessageBox.Show("نجح النسخة الاحتياطية  ", " النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                MessageBox.Show(ex.Message & "فشل البرنامج فى انشاء نسخه احتياطيه", "نسخه احتياطيه" & vbCrLf & vbCrLf & ex.Message & ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                Exit Sub
            End Try
        Else
            Try
                'Dim ConUsers As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=" + Server1 + "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";")
                'Dim strConnection As String = "Initial Catalog =" + DBServer + ";Server =" + ServerName + "," + PORT + ";Initial Catalog=tempdb;User Id=" + userIDName + ";Password=" + BWS1 + ";"
                Dim strConnection As String = Nothing
                If AuthenicationSQLServer = True And LocalConnection = True Then
                    strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + ";Server =" + ServerName + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                    strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + "," + PORT + ";Server =" + ServerName + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                    strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + ",Server =" + ServerName + ";Integrated Security=True"
                End If
                'Dim ServerConnectionString As String = "Data Source=" + ServerName + "," + PORT + ";User Id=" + userIDName + ";Password=" + BWS1 + ";Connect Timeout=30"

                Dim ServerConnectionString As String = Nothing
                If AuthenicationSQLServer = True And LocalConnection = True Then
                    ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                    ServerConnectionString = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                    ServerConnectionString = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
                End If
                Dim SqlConnection1 As New SqlClient.SqlConnection(ServerConnectionString)
                Dim srvrConnection As New ServerConnection(SqlConnection1)
                Dim MyServer As New Server(srvrConnection)
                Dim MyBackup As New Backup()
                If Me.RadioSchemaAndData.Checked = True Then
                    MyBackup.Action = BackupActionType.Database
                    MyBackup.LogTruncation = BackupTruncateLogType.Truncate
                    MyBackup.Checksum = True
                ElseIf Me.RadioDataOnly.Checked = True Then
                    MyBackup.Action = BackupActionType.Files
                    MyBackup.Checksum = True
                ElseIf Me.RadioData.Checked = True Then
                    MyBackup.Action = BackupActionType.Log
                End If
                If Me.RadioALLData.Checked = True Then
                    MyBackup.Incremental = False
                ElseIf Me.RadioNewData.Checked = True Then
                    MyBackup.Incremental = True
                End If
                MyBackup.Database = Me.ComboDBServer.Text.Trim
                Dim MyDevice As New BackupDeviceItem(Me.TextBackupPath.Text, DeviceType.File)
                MyBackup.Devices.Add(MyDevice)
                MyBackup.Initialize = True
                Me.ProgressBar1.Visible = True
                MyBackup.PercentCompleteNotification = 10
                Me.ProgressBar1.Value = MyBackup.PercentCompleteNotification
                AddHandler MyBackup.PercentComplete, AddressOf ProgressEventHandler
                MyBackup.SqlBackup(MyServer)
                SqlConnection1.Dispose()
                MessageBox.Show("نجح النسخة الاحتياطية  ", " النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch ex As Exception
                'Me.ProgressBar1.Value = 0
                Me.ProgressBar1.Visible = False
                MessageBox.Show(ex.Message & "فشل البرنامج فى انشاء نسخه احتياطيه", "نسخه احتياطيه" & vbCrLf & vbCrLf & ex.Message & ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2)
                Exit Sub
            End Try
        End If



        Me.Cursor = Cursors.Default
        Me.ComboDBServer.Text = ""
        Me.ComboBox2.Text = ""
        Me.TextBackupPath.Text = ""
        Me.CheckBox1.Checked = False
    End Sub
    Private Sub ProgressEventHandler(ByVal sender As Object, ByVal e As PercentCompleteEventArgs)
        On Error Resume Next
        Static I As Integer = 1
        Me.ProgressBar1.Visible = True
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = 100
        Me.ProgressBar1.Step = 10
        Me.ProgressBar1.Value = I
        I += 10
        If CInt(e.Percent) = 100 Then
            Me.ProgressBar1.Visible = False
            Me.CheckBox1.Checked = False
            I = 10
        End If
        Me.Labelbacked.Text = e.Percent.ToString + "% backed up"
    End Sub
    Private Sub FILL_COMBO()
        On Error Resume Next
        Dim DS As New DataSet
        Dim Sqlconsar As String = Nothing
        If AuthenicationSQLServer = True And LocalConnection = True Then
            Sqlconsar = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
            Sqlconsar = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
            Sqlconsar = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
        End If
        Dim SqlConnection1 As New SqlClient.SqlConnection(Sqlconsar)
        Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name not IN('master','msdb','tempdb' ,'model','ReportServer$SQLExpress','ReportServer$SQLExpressTempDB') and has_dbaccess(Name) = 1 order by name "
        Dim ADP As SqlClient.SqlDataAdapter
        ADP = New SqlClient.SqlDataAdapter(str, SqlConnection1)
        DS.Clear()
        ADP.Fill(DS)
        Me.ComboDBServer.Items.Clear()
        Dim i As Integer
        For i = 0 To DS.Tables(0).Rows.Count - 1
            Me.ComboDBServer.Items.Add(DS.Tables(0).Rows(i).Item(0))
        Next
        ADP.Dispose()
        SqlConnection1.Dispose()
    End Sub
    Private Sub FrmBackup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try

            Select Case e.KeyCode

                Case Keys.Enter
                    Me.BUTTONBACKUP_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmBackup_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        If Not IO.Directory.Exists(MYFOLDER & "\Backup") Then Directory.CreateDirectory(MYFOLDER & "\Backup")
        Me.CheckBox1.Checked = False
        Me.ComboBox2.Enabled = False
        Me.GroupBox3.Enabled = True
        Me.GroupBox2.Enabled = True
        Me.RadioCustom.Checked = True
        Me.RadioALLData.Checked = True
        Me.RadioSchemaAndData.Checked = True
        Me.FILL_COMBO()
        Me.ProgressBar1.Minimum = 1
        Me.ProgressBar1.Maximum = 100
        Call MangUsers()
    End Sub

    Private Sub TextBackupPath_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TextBackupPath.ButtonClick
        On Error Resume Next
        If Len(Me.ComboDBServer.Text) = 0 Then
            MessageBox.Show("من فضلك حدد قاعدة البيانات  ", "حدد قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.ComboDBServer.Focus()
            Exit Sub
        End If
        SaveFileDialog1.Filter = "Crash Dump File (*.dmp)|*.dmp|SQL Server Transaction Log Backup (*.trn)|*.trn|BAK File (*.bak)|*.bak|All files (*.*)|*.*"
        With Me.SaveFileDialog1
            .FilterIndex = 3
            .Title = "حفظ ملف"
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            .InitialDirectory = MYFOLDER & "\Backup"
            .AddExtension = True
            .ShowDialog()
            If Len(.FileName) > 0 Then
                Me.TextBackupPath.Text = SaveFileDialog1.FileName
            End If
        End With
    End Sub


    Private Sub CheckBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBox1.Click
        On Error Resume Next
        If Len(Me.ComboDBServer.Text) = 0 Then
            MessageBox.Show("من فضلك حدد قاعدة البيانات  ", "حدد قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.ComboDBServer.Focus()
            Me.CheckBox1.Checked = False
            Exit Sub
        End If
        If Me.CheckBox1.Checked = True Then
            Me.Label2.Enabled = False
            Me.TextBackupPath.Enabled = False
            Me.TextBackupPath.Enabled = False
            Me.ComboBox2.Enabled = True
        Else
            Me.Label2.Enabled = True
            Me.TextBackupPath.Enabled = True
            Me.ComboBox2.Enabled = False
            Me.TextBackupPath.Enabled = True
            Me.TextBackupPath.Text = ""
        End If
    End Sub
    Private Sub SelectExt()
        Select Case Me.ComboBox2.Text
            Case "Crash Dump File (*.dmp)"
                Ext = ".dmp"
            Case "SQL Server Transaction Log Backup (*.trn)"
                Ext = ".trn"
            Case "BAK File (*.bak)"
                Ext = ".bak"
        End Select
        MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
        Dt = Now.ToString("yyyy-MM-dd-hh-mm")
        Me.TextBackupPath.Text = MYFOLDER & "\Backup\" + Me.ComboDBServer.Text.Trim + "_" + Dt + Ext
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        On Error Resume Next
        SelectExt()
    End Sub
    Private Sub ButtonXP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonXP3.Click
        On Error Resume Next
        If RAdmin = False Then
            MsgBox("عفوا .. هذا الامر للمشرف العام فقط", 16, "تنبيه")
            Exit Sub
        End If
        Dim resault As Integer
        resault = MessageBox.Show("سيتم انشاء نسخه احتياطية من كل قواعد البيانات على السرفر", "انشاء نسخة أحتياطية", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        If resault = vbYes Then
            Me.Cursor = Cursors.WaitCursor
            Dim M As Integer
            For M = 0 To Me.ComboDBServer.Items.Count - 1
                CloseAllConnection(Me.ComboDBServer.Items.Item(M), Me)
                Backup_database(Me.ComboDBServer.Items.Item(M))
            Next
            Dim I As Integer
            For I = 1 To 100
                Me.ProgressBar1.Visible = True
                Me.ProgressBar1.Minimum = 1
                Me.ProgressBar1.Maximum = 100
                Me.ProgressBar1.Step = 1
                Me.ProgressBar1.Value = I
                If I = 100 Then
                    Me.ProgressBar1.Visible = False
                End If
            Next
            Me.Cursor = Cursors.Default
        Else
            MessageBox.Show("تم ايقاف العملية ", "انشاء نسخة أحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            Exit Sub
        End If
    End Sub
    Private Sub ButtonLOGDATAVASE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonLOGDATAVASE.Click
        If RAdmin = False Then
            MsgBox("عفوا .. هذا الامر للمشرف العام فقط", 16, "تنبيه")
            Exit Sub
        End If
        If Len(Me.ComboDBServer.Text) = 0 Then
            MessageBox.Show(" من فضلك حدد  اسم  قاعدة البيانات التى تريد ضغطها   ", "حدد اسم قاعدة البيانات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Me.ComboDBServer.Focus()
            Exit Sub
        End If
        Try
            Dim sql1 As String = "DBCC SHRINKDATABASE(" & Me.ComboDBServer.Text.Trim & ")"
            If MessageBox.Show("هل تريد ضغط  قاعدة البيانات  " & Me.ComboDBServer.Text.Trim, "ضغط قاعدة البيانات", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading) = Windows.Forms.DialogResult.Yes Then
                GETCOMMAND(sql1)
                Dim I As Integer
                For I = 1 To 100
                    Me.ProgressBar1.Visible = True
                    Me.ProgressBar1.Minimum = 1
                    Me.ProgressBar1.Maximum = 100
                    Me.ProgressBar1.Step = 1
                    Me.ProgressBar1.Value = I
                    If I = 100 Then
                        Me.ProgressBar1.Visible = False
                    End If
                Next
                Me.FrmBackup_Load(sender, e)
            Else
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)
        End Try
    End Sub
    Public Function GETLOGODATABASE(ByVal MYDATABASE As String) As String
        Try
            If MYDATABASE.Length > 0 Then
                Dim cmd As SqlClient.SqlCommand
                'Dim strConnection As String = "Initial Catalog =" + MYDATABASE + ";Server =" + ServerName + "," + PORT + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
                Dim strConnection As String = Nothing
                If AuthenicationSQLServer = True And LocalConnection = True Then
                    strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + ";Server =" + ServerName + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                    strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + "," + PORT + ";Server =" + ServerName + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"
                ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                    strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + ",Server =" + ServerName + ";Integrated Security=True"
                End If
                Dim cnn As New SqlClient.SqlConnection(strConnection)
                Dim strSQL As String = "EXEC sp_helpfile"
                cnn.Open()
                cmd = New SqlCommand(strSQL, cnn)
                Rdr = cmd.ExecuteReader
                While Rdr.Read
                    GETLOGODATABASE = Rdr("filename")
                End While
            Else
                GETLOGODATABASE = ""
                Exit Function
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)

        End Try
        Return MYDATABASE
    End Function

    Private Sub GETCOMMAND(ByVal SQL As String)
        Try
            '"Initial Catalog =" + Me.ComboBox1.Text.Trim + ";Server =" + ServerName + "," + PORT + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"

            Dim strConnection As String = Nothing
            If AuthenicationSQLServer = True And LocalConnection = True Then
                strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + ";Server =" + ServerName + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"
            ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + "," + PORT + ";Server =" + ServerName + "; User Id=" + userIDName + ";Password=" + BWS1 + ";"
            ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                strConnection = "Initial Catalog =" + Me.ComboDBServer.Text.Trim + ",Server =" + ServerName + ";Integrated Security=True"
            End If

            Dim cnn As New SqlClient.SqlConnection(strConnection)
            cnn.Open()
            Dim cmd1 As New SqlCommand(SQL, cnn)
            cmd1.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)
        Finally
            Cnn.Close()
        End Try
    End Sub
    Private Function NameDB(ByVal Name As String) As String
        On Error Resume Next
        Dim MYDBNAME As String
        Dim f1 As String
        Dim str As String
        Dim N As Integer
        f1 = Name
        MYDBNAME = Microsoft.VisualBasic.Left(f1, Len(f1) - 4)
        str = StrReverse(MYDBNAME)
        N = str.IndexOf("\", 0)
        MYDBNAME = Microsoft.VisualBasic.Right(MYDBNAME, N)
        If Microsoft.VisualBasic.Right(MYDBNAME, 5) = "_Data" Then
            MYDBNAME = Microsoft.VisualBasic.Left(MYDBNAME, Len(MYDBNAME) - 5)
        End If
        NameDB = MYDBNAME
    End Function
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioStandard.Click
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
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioCustom.Click
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
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboDBServer.SelectedIndexChanged
        Try
            Me.Labelbacked.Text = ""
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.Source)
        End Try
    End Sub

End Class