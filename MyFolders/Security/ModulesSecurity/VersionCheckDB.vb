Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
'Imports EmmbedSQLSERVER.My.Resources
Imports CC_JO.My.Resources
Imports Microsoft.Win32
Module VersionCheckDB
    Enum VersionCheck
        Failed = 0
        Equal
        DatabaseIsMoreNew
        DatabaseIsOlder
        DatabaseNotFound
        TableNotFound
    End Enum
    Private sqlCmd As New SqlCommand()

#Region "Server Consumnection Settings"

    Private Function Is64BitOperatingSystem() As Boolean
        Return Environment.Is64BitProcess
    End Function

    Public Sub LoadInstalledServer(ByVal comboBox As ComboBox)
        Try
            Dim regView As RegistryView = If(Environment.Is64BitOperatingSystem, RegistryView.Registry64, RegistryView.Registry32)
            Using localMachine As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, regView)
                Using rk = localMachine.OpenSubKey("SOFTWARE\Microsoft\Microsoft SQL Server")
                    If rk Is Nothing Then
                        ShowMessage("No SQL Server instances found in subkey.", "Instances")
                        Return
                    End If

                    Dim installedInstances As String() = TryCast(rk.GetValue("InstalledInstances"), String())
                    If installedInstances Is Nothing OrElse installedInstances.Length = 0 Then
                        ShowMessage("No SQL Server instances found.", "Instances")
                        Return
                    End If

                    comboBox.Items.Clear()
                    For Each instance As String In installedInstances
                        Dim serverName As String = If(instance = "MSSQLSERVER", Environment.MachineName, $"{Environment.MachineName}\{instance}")
                        comboBox.Items.Add(serverName)
                    Next
                End Using
            End Using
        Catch ex As Security.SecurityException
            ShowMessage("Access to the registry key is denied.", "Security Error")
        Catch ex As UnauthorizedAccessException
            ShowMessage("You do not have the necessary registry rights.", "Unauthorized Access")
        Catch ex As Exception
            ShowMessage($"An unexpected error occurred: {ex.Message}", "Error")
        End Try
    End Sub

    Private Sub ShowMessage(ByVal message As String, ByVal title As String)
        MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Function BuildConnectionString(ByVal server As String, ByVal database As String, ByVal userId As String, ByVal password As String, ByVal integratedSecurity As Boolean) As String
        If integratedSecurity Then
            Return $"Data Source={server};Initial Catalog={database};Integrated Security=True"
        Else
            Return $"Data Source={server};Initial Catalog={database};User Id={userId};Password={password};"
        End If
    End Function

    Public Sub FollCombByDataBases(ByVal CombServer As ComboBox, ByVal CombDBs As ComboBox)
        Try
            If CombServer.Text.Trim <> String.Empty Then
                CombDBs.Items.Clear()
                Dim connectionString As String = BuildConnectionString(CombServer.Text, "master", userIDName, BWS1, Not AuthenicationSQLServer)
                Using con As New SqlConnection(connectionString)
                    Using da As New SqlDataAdapter("SELECT name FROM sys.databases", con)
                        Dim dt As New DataTable
                        da.Fill(dt)
                        For Each row As DataRow In dt.Rows
                            CombDBs.Items.Add(row("name").ToString())
                        Next
                    End Using
                End Using
            End If
        Catch ex As SqlException
            ShowMessage($"{ex.Number} {ex.Message}", "SQL Error")
        Catch ex As Exception
            ShowMessage(ex.Message, "Error")
        End Try
    End Sub

    Public Sub FollCombByDataBases1(ByVal StringServer As String, ByVal CombDBs As ComboBox)
        Try
            If StringServer.Trim() <> String.Empty Then
                CombDBs.Items.Clear()
                Dim Sqlconsar As String = GetConnectionString(StringServer, "master")
                Using con As New SqlConnection(Sqlconsar)
                    Using da As New SqlDataAdapter("SELECT name FROM sys.databases", con)
                        Dim dt As New DataTable()
                        da.Fill(dt)
                        For Each row As DataRow In dt.Rows
                            CombDBs.Items.Add(row("name").ToString())
                        Next
                    End Using
                End Using
            End If
        Catch ex As SqlException
            MessageBox.Show($"{ex.Number} {ex.Message}", "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function GetConnectionString(ByVal server As String, ByVal database As String) As String
        If AuthenicationSQLServer And LocalConnection Then
            Return $"Data Source={server};Initial Catalog={database};User Id={userIDName};Password={BWS1};"
        ElseIf AuthenicationSQLServer And ServerConnection Then
            Return $"Data Source={server},{PORT};Initial Catalog={database};User Id={userIDName};Password={BWS1};"
        ElseIf Not AuthenicationSQLServer And LocalConnection Then
            Return $"Data Source={server};Initial Catalog={database};Integrated Security=True"
        End If
        Return String.Empty
    End Function

    Public Sub ShowSaveSettings(ByVal XX As FrmServerusrs)
        Try
            XX.RdoLocalConnection.Checked = LocalConnection
            XX.RdoServerConnection.Checked = ServerConnection
            If AuthenicationSQLServer = True Then
                XX.ComboAuth.SelectedIndex = 1
            Else
                XX.ComboAuth.SelectedIndex = 0
            End If
            If XX.RdoLocalConnection.Checked = True Then
                XX.ComboServerName.Enabled = True
                XX.ComboServerName.SelectedItem = LocalComp
            Else
                XX.ComboServerName.Enabled = False
                XX.ComboServerName.SelectedItem = Nothing
            End If
            XX.TxtServerName.Text = ServerName
            XX.Port1.Text = PORT
            XX.UserID1.Text = userIDName
            XX.BWS.Text = BWS1
            XX.ComboDBServer.SelectedItem = DBServer
        Catch ex As SqlException
            MessageBox.Show(ex.Number.ToString() & " " & ex.Message.ToString())
        End Try
    End Sub

    Private Function CheckTestSaveSettings(ByVal XX As FrmServerusrs) As Boolean
        'Try
        If XX.RdoLocalConnection.Checked = True Then
                If MyCompTextEmpte(XX.ComboServerName, "اسم السيرفر") Then Return True
                If XX.ComboAuth.SelectedIndex = 1 Then
                    If MyTextNull(XX.UserID1, "اسم المستخدم") = True Then Return True
                    If MyTextNull(XX.BWS, " الباسورد") = True Then Return True
                End If
            ElseIf XX.RdoServerConnection.Checked = True Then
                If MyTextNull(XX.TxtServerName, "اسم السيرفر") = True Then Return True
                If MyTextNull(XX.Port1, "رقم البورت") = True Then Return True
                If MyTextNull(XX.UserID1, "اسم المستخدم") = True Then Return True
                If MyTextNull(XX.BWS, "الباسورد") = True Then Return True
                'ElseIf My.Settings.LoginMothed = 2 Then
            End If
            If MyCompTextEmpte(XX.ComboDBServer, "اسم قاعدة البيانات") = True Then Return True
            Return False
        'Catch ex As SqlException
        '    MessageBox.Show(ex.Number.ToString() & " " & ex.Message.ToString())
        'End Try

    End Function

    Public Sub TestSQLServerConnection(ByVal XX As FrmServerusrs)
        If CheckTestSaveSettings(XX) = True Then Return
        Dim Sqlconsar As String = Nothing
        Dim Sqlconn As New SqlConnection()
        If XX.ComboAuth.SelectedIndex = 0 And XX.RdoLocalConnection.Checked = True Then
            Sqlconsar = "Data Source = " & XX.ComboServerName.Text.Trim & ";Initial Catalog=master;Integrated Security=True"
        ElseIf XX.ComboAuth.SelectedIndex = 1 And XX.RdoLocalConnection.Checked = True Then
            Sqlconsar = "Data Source=" & XX.ComboServerName.Text.Trim & ";Initial Catalog=master;User Id=" + XX.UserID1.Text.Trim + ";Password=" + XX.BWS.Text.Trim + ";"
        ElseIf XX.ComboAuth.SelectedIndex = 1 And XX.RdoServerConnection.Checked = True Then
            Sqlconsar = "Data Source=" & XX.TxtServerName.Text.Trim & "," + XX.Port1.Text.Trim + ";Initial Catalog=master;User Id=" + XX.UserID1.Text.Trim + ";Password=" + XX.BWS.Text.Trim + ";"
        End If
        Sqlconn.ConnectionString = Sqlconsar
        If Sqlconn.State = ConnectionState.Closed Then
            Try
                Sqlconn.Open()
                MessageBox.Show("تمت عملية الاتصال بنجاح", "فحص الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show(" فشل الاتصال بنجاح" + vbCrLf + Err.Description, "فحص الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Public Function TestSQLConnection( ) As Boolean
        Try
            Dim Sqlconsar As String = Nothing
            Dim Sqlconn As New SqlConnection()
            If AuthenicationSQLServer = False Then
                Sqlconsar = "Data Source = " & LocalComp & ";Initial Catalog=master;Integrated Security=True"
            ElseIf AuthenicationSQLServer = True Then
                Sqlconsar = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
            ElseIf ServerConnection = True Then
                Sqlconsar = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
            End If
            Sqlconn.ConnectionString = Sqlconsar
            If Sqlconn.State = ConnectionState.Closed Then Sqlconn.Open()
            Return True
        Catch ex As SqlException
            MessageBox.Show(" فشل الاتصال بنجاح" + vbCrLf + Err.Description, "فحص الاتصال", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function GetSQLConnectionString(ByVal DbName As String) As String
        Dim Sqlconsar As String = Nothing
        If AuthenicationSQLServer = False Then
            Sqlconsar = "Data Source = " & LocalComp & ";Initial Catalog=" & DbName & ";Integrated Security=True"
        ElseIf AuthenicationSQLServer = True Then
            Sqlconsar = "Data Source=" & ServerName & ";Initial Catalog=" & DbName & ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf ServerConnection = True Then
            Sqlconsar = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=" & DbName & ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
        End If
        Return Sqlconsar
    End Function

    Public Function Get_Copy_Of_Basic_Data_To_NewDataBase(ByVal NewDBName As String) As Short
        Try
            Dim Sqlconsar As String = Nothing
            Dim parametr(1) As SqlParameter
            parametr(0) = New SqlParameter("@NewDBName", SqlDbType.NVarChar, 100) With {
                .Value = NewDBName
            }

            parametr(1) = New SqlParameter("@ReturnValue", SqlDbType.TinyInt) With {
                .Direction = ParameterDirection.Output
            }
            'ExecuteSqlcommand("[GetCopyOfBasicDataToNewDB]")
            Return CShort(parametr(1).Value)

        Catch ex As SqlException
            MessageBox.Show(ex.Message, "ErorrMessage", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return 0
    End Function

#End Region

#Region "Backup Settings"
    Public Function BackupDatabase(ByVal Con As SqlConnection, ByVal DatabaseName As String, ByVal DestionFolderPath As String, ByVal BackupOptions As String, ByVal BackupType As Short) As Boolean
        Try
            Dim sqlcmd As New SqlCommand
            sqlcmd = Con.CreateCommand
            Dim CommandStr As String = Nothing
            If BackupType = 0 Then
                CommandStr = "backup database [" & DatabaseName & "]" &
                    "to disk=N'" & DestionFolderPath & "\" & DatabaseName & "_Full_" & Now.ToString("dd-MM-yyyy-hh-mm-tt") & ".bak'WITH" & BackupOptions
            ElseIf BackupType = 1 Then
                CommandStr = "backup database [" & DatabaseName & "]" &
                   "to disk=N'" & DestionFolderPath & "\" & DatabaseName & "_DIFF_" & Now.ToString("dd-MM-yyyy-hh-mm-tt") & ".bak'WITH DIFFERENTIAL ," & BackupOptions & ""
            ElseIf BackupType = 2 Then
                CommandStr = "BACKUP LOG [" & DatabaseName & "]" &
                    "to disk=N'" & DestionFolderPath & "\" & DatabaseName & "_Trans_Log _" & Now.ToString("dd-MM-yyyy-hh-mm-tt") & ".trn'WITH" & BackupOptions
            End If
            sqlcmd.CommandText = CommandStr
            Con.Open()
            sqlcmd.ExecuteNonQuery()
            Con.Close()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try

    End Function
    Public Sub SaveBackupSettings(ByVal xx As FrmBackup1)
        Try
            If xx.LabelMYFOLDER.Text = String.Empty Then
                MessageBox.Show("من فضلك حدد مسار النسخة الاحتياطية  ", "حدد مسار النسخة الاحتياطية", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                Return
            End If
            My.Settings.BackupType = xx.CombBackupType.SelectedIndex
            My.Settings.BackupPath = xx.LabelMYFOLDER.Text
            If xx.RaStob.Checked Then
                My.Settings.AutoBackup = 0
            ElseIf xx.RaAutoClose.Checked Then
                My.Settings.AutoBackup = 1
            ElseIf xx.RaPerHours.Checked Then
                My.Settings.AutoBackup = 2
            End If
            My.Settings.Save()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


#End Region


    Public Function SetupDatabase() As Boolean
        Dim bContinue As Boolean = False
        Try
            'Consum.ConnectionString = "Server=.;Integrated Security=True"
            Consum.Open()
        Catch sql_ex As SqlException
            MessageBox.Show("فشل الاتصال بالسيرفر  " & vbLf & sql_ex.Number.ToString() & " " & sql_ex.Message.ToString())
            Return bContinue
        End Try

        ' بعد الاتصال بالسيرفر نجري المقارنة

        Select Case CheckVersion()
            Case CInt(VersionCheck.Equal)
                bContinue = True
                Exit Select
            Case CInt(VersionCheck.Failed)
                bContinue = False
                Exit Select
            Case CInt(VersionCheck.DatabaseIsOlder)
                bContinue = RunScript(Resource1.UpdateDB_CO.ToString())
                MsgBox("The database has been updated")
                Exit Select
            Case CInt(VersionCheck.DatabaseIsMoreNew)
                MsgBox("The database Is up-To-Date")
                bContinue = False
                Exit Select
            Case CInt(VersionCheck.DatabaseNotFound)
                bContinue = RunScript(Resource1.CreateClientDataBase.ToString())
                MsgBox("The database has been created")
                Exit Select
            Case CInt(VersionCheck.TableNotFound)
                bContinue = RunScript(Resource1.CREATE_TABLE_AppInfo.ToString())
                MsgBox("ارجو إعادة التحديث لإكمال التحديثات(AppInfo)تم اضافة جدول")
                Exit Select
            Case Else
                bContinue = False
                Exit Select
        End Select

        Return bContinue
    End Function
    ''' <summary>
    ''' مقارنة نسخة البرنامج الحالية مع رقم النسخة المسجل في القاعدة
    ''' </summary>
    ''' <returns></returns>
    Public Function CheckVersion() As Integer
        Dim v As New Version(Application.ProductVersion.ToString())

        Try
            'فحص توفر القاعدة في السيرفر
            sqlCmd = New SqlCommand("Select count(*) from master..sysdatabases where name='DB_A3F994_co'", Consum)
            Dim strResult As String = sqlCmd.ExecuteScalar().ToString()
            'اذا لم نجد القاعدة
            If strResult = "0" Then
                Consum.Close()
                'Return CInt(VersionCheck.DatabaseNotFound)
            End If
            'جلب رقم النسخة المسجل في القاعدة
            Dim Table_Name As String = "AppInfo"
            Dim Restrictions() As String = {Nothing, Nothing, Table_Name, Nothing}
            Dim CollectionName As String = "Tables"
            Dim DataTableFind As DataTable = Consum.GetSchema(CollectionName, Restrictions)
            If DataTableFind.Rows.Count > 0 Then
                sqlCmd = New SqlCommand("SELECT value from DB_A3F994_CC_JO..AppInfo where property='version'", Consum)
                strResult = sqlCmd.ExecuteScalar().ToString()
                Consum.Close()
                Dim vDb As New Version(strResult)
                If vDb = v Then Return CInt(VersionCheck.Equal)
                If vDb > v Then Return CInt(VersionCheck.DatabaseIsMoreNew)
                If vDb < v Then Return CInt(VersionCheck.DatabaseIsOlder)
            Else
                Return CInt(VersionCheck.TableNotFound)
            End If



            'اجراء المقارنة

        Catch sql_ex As SqlException
            MessageBox.Show(sql_ex.Number.ToString() & " " & sql_ex.Message.ToString())
            Return CInt(VersionCheck.Failed)
        Catch system_ex As Exception
            MessageBox.Show(system_ex.Message.ToString())
            Return CInt(VersionCheck.Failed)
        End Try

        Return CInt(VersionCheck.Failed)
    End Function

    ''' <summary>
    ''' قراءة الملف النصي الحاوي على السكربت
    ''' التخلص من كلمة GO و ادراج كل جملة في سطر
    ''' GO يجب ازالة كلمة
    ''' من نهاية الملف
    ''' </summary>
    ''' <param name="strScript"></param>
    ''' <returns>مصفوفة نصية تحتوي على الاسطر المراد تنفيذها</returns>
    Public Function ParseScriptToCommands(ByVal strScript As String) As String()
        Dim commands As String()
        commands = Regex.Split(strScript, "GO" & vbCrLf, RegexOptions.IgnoreCase)
        Return commands
    End Function

    ''' <summary>
    ''' تنفيذ السكربت المخزن في المصفوفة النصية
    ''' </summary>
    ''' <param name="strFile"></param>
    ''' <returns></returns>
    Public Function RunScript(ByVal strFile As String) As Boolean
        Dim strCommands As String()
        strCommands = ParseScriptToCommands(strFile)
        Dim strCmd As String
        Try
            If Consum.State <> ConnectionState.Open Then Consum.Open()
            sqlCmd.Connection = Consum
            For Each strCmd In strCommands
                If strCmd.Length > 0 Then
                    sqlCmd.CommandText = strCmd
                    sqlCmd.ExecuteNonQuery()
                End If
            Next
        Catch sql_ex As SqlException
            MessageBox.Show(sql_ex.Number.ToString() & " " & sql_ex.Message.ToString())
            Return False
        End Try
        Return True
    End Function

End Module
