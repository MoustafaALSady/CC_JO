Option Strict Off
Option Explicit Off
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Reflection
Imports Microsoft.Win32

Module ModuleGeneral

    Public constring As String
    Public constring1 As String

    Public Declare Function GetDlgItem Lib "user32" (ByVal hDlg As Integer, ByVal nIDDlgItem As Integer) As Integer
    Public Declare Function SendMessage Lib "user32" Alias "SendMessageA" (
        hwnd As Integer,
        wMsg As Integer,
        wParam As Integer,
        lParam As String) As Integer


    Public Const CALC_INPUT As Integer = 403
    Public Const WM_GETTEXT As Integer = 13

    Public URL As String
    Public URL1 As String
    Public URL2 As String
    Public tstURL As Boolean = False

    ReadOnly ds As New DataSet
    Public DR As SqlDataReader

    Public MYFOLDER As String
    Public MYDATABASE1 As String
    Public FolderImageName As String = Nothing
    Public ImageName As String = Nothing
    Public ImageExe As String = Nothing
    Public SCANFILE As String
    Public img As Image = My.Resources.BG2

    Public IDUSER As Integer
    Public IDCOUSER As Integer
    Public RAdmin As Boolean
    Public Realname As String '«”„ «·„” Œœ„ «·ÕﬁÌﬁÌ
    Public CUser As String  '«”„ «·„” Œœ„
    Public COUser As String ' «”„ «·„”ƒÊ·
    Public AssociationName As String '«”„ «·Ã„⁄Ì…
    Public Directorate As String '«·„œÌ—Ì…/«·„Õ«›Ÿ…
    Public Recorded As String ' «·—ﬁ„ «·Êÿ‰Ì ··Ã„⁄Ì…
    Public Adrss As String '  ⁄‰Ê«‰ «·Ã„⁄Ì…
    Public Character As String '  ’›… «·Ã„⁄Ì…..
    Public Ty1 As String '  ‰Ê⁄ «·Ã„⁄Ì….
    Public Phone As String '   «·Ã„⁄Ì… Â« ›.
    Public Phone1 As String '   «·Ã„⁄Ì… Â« ›.
    Public BANK As String '   «·»‰ﬂ.
    Public NOBANK As String '   —ﬁ„ «·Õ”«».
    Public BANSL As Integer '   «·«”Â„.
    Public ChecksIN As Integer
    Public CategoriesIN As Integer
    Public PaymentsIN As Integer

    Public LS1 As Boolean = False
    Public LS2 As Boolean = False
    Public LS3 As Boolean = False
    Public LS4 As Boolean = False

    Public OpeningRecordCheck As Boolean = False '  ›Õ’ ﬁÌœ «›  «ÕÌ 

    Public ActiveFiscalYear As Boolean = False '   ”‰… „«·Ì… ‰‘ÿ….
    'Public InactiveFiscalYear As Boolean = False '   ”‰… „«·Ì… €Ì— ‰‘ÿ….
    Public FY As Integer '   ”‰… „«·Ì….
    Public STarDat As Date

<<<<<<< HEAD
    Public LockAddRow As Boolean = False
    Public LockSave As Boolean = False
    Public LockUpdate As Boolean = False
    Public LockDelete As Boolean = False
    Public LockPrint As Boolean = False

    Public TransferofAccounts As Boolean = False
    Public InternalAuditor As Boolean = False
    Public Managers As Boolean = False
    Public CollaborationManager As Boolean = False
    Public HeadofAuditingDepartment As Boolean = False
    Public ExternalAuditor As Boolean = False
=======
    Public LockAddRow As Boolean
    Public LockSave As Boolean
    Public LockUpdate As Boolean
    Public LockDelete As Boolean
    Public LockPrint As Boolean

    Public TransferofAccounts As Boolean
    Public InternalAuditor As Boolean
    Public Managers As Boolean
    Public CollaborationManager As Boolean
    Public HeadofAuditingDepartment As Boolean
    Public ExternalAuditor As Boolean
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    'Public InternalAuditor1 As Boolean = False
    'Public CollaborationManager1 As Boolean = False
    'Public HeadofAuditingDepartment1 As Boolean = False
<<<<<<< HEAD
    Public SumPreviousBalanceStocks As Decimal = 0.0
=======
    'Public ExternalAuditor1 As Boolean = False
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Public Issued As Boolean
    Public Ward As Boolean
    Public Undercollection As Boolean ' Õ  «· Õ’Ì·
    Public Returned As Boolean '⁄«œ
    Public Returnedinbank As Boolean ' ⁄«œ ›Ì «·»‰ﬂ
    Public Expense As Boolean '„’—Ê›
    Public Portfolio As Boolean ' „Õ›Ÿ…

    Public Cash As Boolean
    Public Accountingprocedure As Boolean = False ' «Ã—«¡ „Õ«”»…
    Public Auditorsnotes As Boolean = False    ' 1„œﬁﬁ «·Õ”«»« 

    'Public Inprogress As Boolean = False  'ﬁÌœ «·⁄„· „Õ«”»
    'Public AuditorClose As Boolean = False  ' „œﬁﬁ «·Õ”«»« 
    'Public CollaborationManagerClose As Boolean = False  ' „œÌ— «· ⁄«Ê‰
    'Public HeadOFExternalAccountsDepartmentClose As Boolean = False  ' —∆Ì” ﬁ”„ «·Õ”«»«  «·Œ«—ÃÌ…
    'Public ExternalAuditorClose As Boolean = False  ' „œﬁﬁ «·Õ”«»«  «·Œ«—ÃÌ…

    'Public Complete As Boolean = False  ' „ﬂ „·
    'Public FiscalYear As Boolean = False  ' „ﬂ „·

    Public CB2 As String
    Public BN3 As String
    Public BN4 As String

    Public flag As Boolean
    Public M1 As Boolean
    Public M2 As Boolean
    Public M3 As Boolean
    Public M4 As Boolean
    Public M5 As Boolean
    Public M6 As Boolean
    Public M7 As Boolean
    Public M8 As Boolean

    Public Lists As Boolean = True
    Public Lists1 As Boolean = True
    Public Lists2 As Boolean = True
    Public Lists3 As Boolean = True
    Public Lists4 As Boolean = True
    Public Lists5 As Boolean = True
    Public Lists6 As Boolean = True
    Public Lists7 As Boolean = True

    Public Time As New Stopwatch

    Public Click1 As Boolean = False
    Public Click2 As Boolean = False
    Public Click3 As Boolean = False
    Public Click4 As Boolean = False
    Public Click5 As Boolean = False
    Public Click6 As Boolean = False
    Public Click7 As Boolean = False
    Public Click8 As Boolean = False
    Public Click9 As Boolean = False
    Public Click10 As Boolean = False
    Public Click11 As Boolean = False
    Public Click12 As Boolean = False
    Public Click13 As Boolean = False
    Public Click14 As Boolean = False
    Public Click15 As Boolean = False
    Public Click16 As Boolean = False
    Public Click17 As Boolean = False
    Public Click18 As Boolean = False
    Public Click19 As Boolean = False
    Public Click20 As Boolean = False
    Public Click21 As Boolean = False
    Public Click22 As Boolean = False
    Public Click23 As Boolean = False
    Public Click24 As Boolean = False
    Public Click25 As Boolean = False
    Public Click26 As Boolean = False
    Public Click27 As Boolean = False


    Public OBCHK1 As Boolean = False
    Public OBCHK2 As Boolean = False
    Public OBCHK3 As Boolean = False
    Public OBCHK4 As Boolean = False
    Public OBCHK5 As Boolean = False
    Public OBCHK6 As Boolean = False
    Public OBCHK7 As Boolean = False
    Public OBCHK8 As Boolean = False
    Public OBCHK9 As Boolean = False
    Public CHKCI As Boolean = False

    Public ItemsExpirationDate As Boolean = False

    Public FIFO As Boolean
    Public LIFO As Boolean
    Public AVG As Boolean
    Public MYUSERS As Boolean = False
    Public Back As Boolean = False
    Public Reg As RegistryKey
    Public mykey As RegistryKey = Registry.CurrentUser.CreateSubKey("software \ co \ CO-JO")
    Public key As RegistryKey = Registry.CurrentUser.CreateSubKey("software \ co \ CO-JO")
    Public keyAccounts As RegistryKey = Registry.CurrentUser.CreateSubKey("software \ co \ Accounts")



    Public Declare Function ShellExecute Lib "shell32.dll" Alias "ShellExecuteA" (ByVal hwnd As Integer, ByVal lpOperation As String, ByVal lpFile As String, ByVal lpParameters As String, ByVal lpDirectory As String, ByVal nShowCmd As Integer) As Integer
    Public Const SW_SHOWNORMAL As Short = 1
    Public Const SW_SHOWMAXIMIZED As Short = 3
    Public Declare Function InternetGetConnectedStateEx Lib "wininet.dll" (ByRef lpdwFlags As Integer, ByVal lpszConnectionName As String, ByVal dwNameLen As Integer, ByVal dwReserved As Integer) As Integer


    Public Declare Function FindWindow Lib "user32" _
        Alias "FindWindowA" (ByVal lpClassName As String,
        ByVal lpWindowName As String) As Integer

    Dim YearCount, MonthCount, DayCount, Result As String
    ReadOnly I As Short

    'Public Function CalculateDifferTime(Time1 As DateTime, Time2 As DateTime) As String
    '    Dim Value As Integer = CInt((Time2 - Time1).TotalSeconds)
    '    ' Check time comparison
    '    Dim ComDate As Integer = DateTime.Compare(Time1, Time2)
    '    If ComDate = 0 Then
    '        Return "ﬁÌ„… «·Êﬁ Ì‰ „ ”«ÊÌ Ì‰"
    '    ElseIf ComDate = 1 Then
    '        Return "·« Ì„ﬂ‰ √‰ ÌﬂÊ‰ «·Êﬁ  «·Õ«·Ì √’€— „‰ «·Êﬁ  «·”«»ﬁ"
    '    End If
    '    Dim Hour, Minute, AllSeconds, Second, Day As Integer
    '    Dim Result As String = ""
    '    Dim DayCount As String = ""
    '    Dim SecondCount As String = ""
    '    Dim MinuteCount As String = ""
    '    Dim HourCount As String = ""
    '    AllSeconds = Value
    '    Day = Value \ (24 * 60 * 60) ' Number of days
    '    Value = Value Mod (24 * 60 * 60) ' Remaining seconds
    '    Hour = Value \ 3600 ' Number of hours
    '    Value = Value Mod 3600 ' Remaining seconds
    '    Minute = Value \ 60 ' Number of minutes
    '    Second = Value Mod 60 ' Remaining seconds
    '    If Day >= 1 Then
    '        If Day > 10 Then
    '            DayCount = Day.ToString & " ÌÊ„ "
    '        ElseIf Day <= 10 AndAlso Day > 1 Then
    '            DayCount = Day.ToString & " √Ì«„ "
    '        ElseIf Day = 2 Then
    '            DayCount = " ÌÊ„«‰ "
    '        ElseIf Day = 1 Then
    '            DayCount = " ÌÊ„ Ê«Õœ "
    '        End If
    '        Result += DayCount
    '    End If
    '    If Hour >= 1 Then
    '        If Result.Length > 0 Then Result += "Ê "
    '        If Hour > 10 Then
    '            HourCount = Hour.ToString() & " ”«⁄… "
    '        ElseIf Hour <= 10 AndAlso Hour > 1 Then
    '            HourCount = Hour.ToString() & " ”«⁄«  "
    '        ElseIf Hour = 2 Then
    '            HourCount = " ”«⁄ «‰ "
    '        ElseIf Hour = 1 Then
    '            HourCount = " ”«⁄… Ê«Õœ… "
    '        End If
    '        Result += HourCount
    '    End If
    '    If Minute >= 1 Then
    '        If Result.Length > 0 Then Result += "Ê "
    '        If Minute > 10 Then
    '            MinuteCount = Minute.ToString() & " œﬁÌﬁ… "
    '        ElseIf Minute <= 10 AndAlso Minute > 1 Then
    '            MinuteCount = Minute.ToString() & " œﬁ«∆ﬁ "
    '        ElseIf Minute = 2 Then
    '            MinuteCount = " œﬁÌﬁ «‰  "
    '        ElseIf Minute = 1 Then
    '            MinuteCount = " œﬁÌﬁ… Ê«Õœ…   "
    '        End If
    '        Result += MinuteCount
    '    End If
    '    If Second >= 1 Then
    '        If Result.Length > 0 Then Result += "Ê "
    '        If Second > 10 Then
    '            SecondCount = Second.ToString() & " À«‰Ì… "
    '        ElseIf Second <= 10 AndAlso Second > 1 Then
    '            SecondCount = Second.ToString() & " ÀÊ«‰Ì "
    '        ElseIf Second = 2 Then
    '            SecondCount = " À«‰Ì «‰ "
    '        ElseIf Second = 1 Then
    '            SecondCount = " À«‰Ì… Ê«Õœ… "
    '        End If
    '        Result += SecondCount
    '    End If
    '    Return Result
    'End Function

    Public Sub ChangeToArabic()
        Dim Inag As InputLanguage
        For Each Inag In InputLanguage.InstalledInputLanguages
            If Inag.Culture.EnglishName.ToUpper Like "*Arabic*".ToUpper Then
                InputLanguage.CurrentInputLanguage = Inag
            End If
        Next
    End Sub

    Public Sub ChangeToEnglish()
        Dim Inag As InputLanguage
        For Each Inag In InputLanguage.InstalledInputLanguages
            If Inag.Culture.EnglishName.ToUpper Like "*English*".ToUpper Then
                InputLanguage.CurrentInputLanguage = Inag
            End If
        Next
    End Sub

<<<<<<< HEAD
    Public Sub AutoComplete(ByRef cb As ComboBox, ByVal e As KeyPressEventArgs, Optional ByVal blnLimitToList As Boolean = False)
=======
    Public Sub AutoComplete(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal blnLimitToList As Boolean = False)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim strFindStr As String
        If e.KeyChar = Chr(8) Then
            If cb.SelectionStart <= 1 Then
                cb.Text = ""
                Exit Sub
            End If
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text.Substring(0, cb.Text.Length - 1)
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart - 1)
            End If
        Else
            If cb.SelectionLength = 0 Then
                strFindStr = cb.Text & e.KeyChar
            Else
                strFindStr = cb.Text.Substring(0, cb.SelectionStart) & e.KeyChar
            End If
        End If
        Dim intIdx As Integer = cb.FindString(strFindStr)
        If intIdx <> -1 Then
            cb.SelectedText = ""
            cb.SelectedIndex = intIdx
            cb.SelectionStart = strFindStr.Length
            cb.SelectionLength = cb.Text.Length
            e.Handled = True
        Else
            If blnLimitToList = True Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub

    Public Sub Clear(ByRef c As Control)
        If TypeOf c Is ComboBox Then CType(c, ComboBox).DataSource = Nothing : CType(c, ComboBox).Items.Clear()
        If TypeOf c Is ListBox Then CType(c, ListBox).DataSource = Nothing : CType(c, ListBox).Items.Clear()
        If TypeOf c Is DataGridView Then CType(c, DataGridView).DataSource = Nothing : CType(c, DataGridView).Rows.Clear() : CType(c, DataGridView).Columns.Clear()
    End Sub

    Public Function Calculator() As String
        Try
            Dim hWnd As Integer = FindWindow(Nothing, "Calculator")
            If hWnd <> 0 Then
                Dim hCalcInput As Integer = GetDlgItem(hWnd, CALC_INPUT)
                If hCalcInput <> 0 Then
                    Dim buffer As String = Space(128)
                    Dim unused = SendMessage(hCalcInput, WM_GETTEXT, 128, buffer)
                    Calculator = buffer
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        Return 0

    End Function

    Public Function FrombytestoMB(ByVal SIZE As Integer) As String
        On Error Resume Next
        Dim result As String = ""
        Select Case SIZE
            Case Is < 1000
                result = Format(Val(SIZE), "#,#0.00") & " Bytes"
            Case Is < 1024000
                result = Format(Val(SIZE / 1024), "#,#0.00") & " KB"
            Case Is < 1024000000
                result = Format(Val(SIZE / 1048576), "#,#0.00") & " MB"
            Case Is >= 1024000000
                result = Format(Val(SIZE / 1073741824), "#,#0.00") & " GB"
        End Select
        FrombytestoMB = result
    End Function

    Public Sub GETSERVERNAMEANDDATABASENAME(ByVal rpt As Object, ByVal DATABASENAME As String, Optional ByVal PASSWORD As String = "", Optional ByVal USER As String = "")
        If DATABASENAME Is Nothing Then
            Throw New ArgumentNullException(NameOf(DATABASENAME))
        End If

        If PASSWORD Is Nothing Then
            Throw New ArgumentNullException(NameOf(PASSWORD))
        End If

        If USER Is Nothing Then
            Throw New ArgumentNullException(NameOf(USER))
        End If

        Try
            Dim I As Integer
            Dim TBL1 As New CrystalDecisions.Shared.TableLogOnInfo
            TBL1.ConnectionInfo.ServerName = MdlConnection.ServerName.ToString
            TBL1.ConnectionInfo.DatabaseName = MdlConnection.DBServer.ToString
            TBL1.ConnectionInfo.Password = MdlConnection.BWS1.ToString
            TBL1.ConnectionInfo.UserID = MdlConnection.userIDName.ToString
            For I = 0 To rpt.Database.Tables.Count - 1
                rpt.Database.Tables(I).ApplyLogOnInfo(TBL1)
            Next I


        Catch ex As Exception
            Return
        End Try
    End Sub

    Public Sub LoadMyDatabase2()
        Try
<<<<<<< HEAD
            If ServerConnection Then
                constring = $"Data Source={ServerName},{PORT};Initial Catalog={DBServer};User Id={userIDName};Password={BWS1};"
            ElseIf AuthenicationSQLServer Then
                constring = $"Data Source={ServerName};Initial Catalog={DBServer};User Id={userIDName};Password={BWS1};"
            Else
                constring = $"Data Source={ServerName};Initial Catalog={DBServer};Integrated Security=True"
=======
            If ServerConnection = True Then
                constring = "Data Source=" + ServerName + "," + PORT + ";Initial Catalog= " + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            Else
                If AuthenicationSQLServer = True Then
                    constring = "Data Source=" + ServerName + ";Initial Catalog=" + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
                Else
                    constring = "Data Source =" + ServerName + ";Initial Catalog=" + DBServer + ";Integrated Security=True"
                End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function GetSql(ByVal Name As String, ByVal TypeFileIncludeexe As Boolean) As String
        Try
<<<<<<< HEAD
            If TypeFileIncludeexe Then
                Dim Asm As [Assembly] = [Assembly].GetExecutingAssembly()
                Using strm As Stream = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name)
                    Using reader As New StreamReader(strm)
                        Return reader.ReadToEnd()
                    End Using
                End Using
            Else
                Using reader As New StreamReader(Name)
                    Return reader.ReadToEnd()
                End Using
            End If
        Catch ex As Exception
            Throw New Exception("In GetSQL: " & ex.Message, ex)
        End Try
    End Function


    Public Sub ExecuteSql(ByVal DatabaseName As String, ByVal Sql As String)
        Dim ServerConnectionString As String = Nothing
        If AuthenicationSQLServer = True And LocalConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" & userIDName & ";Password=" & BWS1 & ";"
        ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & "," & PORT & ";Initial Catalog=master;User Id=" & userIDName & ";Password=" & BWS1 & ";"
        ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;Integrated Security=True"
        End If

        Using SqlConnection1 As New SqlConnection(ServerConnectionString)
            Using Command As New SqlCommand(Sql, SqlConnection1)
                Command.CommandType = CommandType.Text
                Try
                    SqlConnection1.Open()
                    Command.Connection.ChangeDatabase(DatabaseName)
                    Command.ExecuteNonQuery()
                Catch ex As SqlException
                    ' Log the exception or handle it as needed
                    Throw New ApplicationException("Error executing SQL command: " & ex.Message, ex)
                End Try
            End Using
        End Using
    End Sub


    Public Sub AddDBTable(ByVal strDBName As String, ByVal NameFile As String)
        Try
            ExecuteSql("master", $"CREATE DATABASE {strDBName}")
            ExecuteSql(strDBName, GetSql(NameFile, True))
        Catch ex As Exception
            MessageBox.Show($"In exception handler: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw New ApplicationException($"Failed to add database table for {strDBName} using file {NameFile}", ex)
=======
            If TypeFileIncludeexe = True Then
                Dim Asm As [Assembly] = [Assembly].GetExecutingAssembly()
                Dim strm As Stream = Asm.GetManifestResourceStream(Asm.GetName().Name + "." + Name)
                Dim reader As New StreamReader(strm)
                Return reader.ReadToEnd()
            Else
                Dim reader As New StreamReader(Name)
                Return reader.ReadToEnd()
            End If
        Catch ex As Exception
            MessageBox.Show("In GetSQL: " & ex.Message)
            Throw
        End Try
    End Function

    Public Sub ExecuteSql(ByVal DatabaseName As String, ByVal Sql As String)
        Dim ServerConnectionString As String = Nothing
        If AuthenicationSQLServer = True And LocalConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
            ServerConnectionString = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
        ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
            ServerConnectionString = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
        End If
        Dim SqlConnection1 As New SqlClient.SqlConnection(ServerConnectionString)
        Dim Command As New SqlClient.SqlCommand(Sql, SqlConnection1) With {
            .CommandType = CommandType.Text
        }
        Command.Connection.Open()
        Command.Connection.ChangeDatabase(DatabaseName)
        Try
            Command.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("In GetSQL: " & ex.Message & ex.Source)
            Throw
        Finally
            Command.Connection.Close()
        End Try
    End Sub

    Public Sub AddDBTable(ByVal strDBName As String, ByVal NameFile As String)
        Try
            ExecuteSql("master", "CREATE DATABASE " + strDBName)
            ExecuteSql(strDBName, GetSql(NameFile, True))
        Catch ex As Exception
            MessageBox.Show("In exception handler: " & ex.Message)
            Throw
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        End Try
    End Sub

    Public Function GETATTACHDATABASENAME(ByVal db As String) As Boolean
<<<<<<< HEAD
        Dim DS As New DataSet
        Dim MYFILE As String = mykey.GetValue("PrimaryFile")

        Try
            If Consum.State <> ConnectionState.Open Then
                'GeneralConnection()
                Using ConUsers As New SqlConnection(Consum.ConnectionString)
                    Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name Like @dbName"
                    Using ADP As New SqlDataAdapter(str, ConUsers)
                        ADP.SelectCommand.Parameters.AddWithValue("@dbName", db)
                        DS.Clear()
                        ADP.Fill(DS)
                    End Using
                End Using
            End If

            If DS.Tables(0).Rows.Count = 0 Then
                MessageBox.Show("Database " & db & " is not connected to the server. Attempting to connect..." & vbCrLf & vbCrLf & "Please wait a moment.", My.Computer.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Return False
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

=======
        On Error Resume Next
        Dim DS As New DataSet
        Dim MYFILE As String = mykey.GetValue("PrimaryFile")
        If Consum.State <> ConnectionState.Open Then
            'GeneralConnection()
            Dim ConUsers = New SqlClient.SqlConnection(Consum.ConnectionString)
        End If
        Dim str As String = "Select DISTINCT name from master.dbo.sysdatabases where name Like '" & db & "'"
        Dim ADP As SqlClient.SqlDataAdapter
        ADP = New SqlClient.SqlDataAdapter(str, ConUsers)
        DS.Clear()
        ADP.Fill(DS)
        Dim i As Integer
        If DS.Tables(0).Rows.Count = 0 Then
            GETATTACHDATABASENAME = False
            MessageBox.Show(" ﬁ«⁄œ… «·»Ì«‰«  " & db & "€Ì— „ ’·… »«·”—›— Ã«—Ï ⁄„· «·« ’«·" & vbCrLf & vbCrLf & " „‰ ›÷·ﬂ «‰ Ÿ— ﬁ·Ì·«Û                                 ", My.Computer.Name, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
        Else
            GETATTACHDATABASENAME = True
        End If
        ADP.Dispose()
        ConUsers.Dispose()
    End Function
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Function MyCompTextEmpte(ByVal Comb As ComboBox, ByVal CombCaption As String) As Boolean
        If Comb.Text = String.Empty Then
            MsgBox("Ì—ÃÏ «Œ Ì«—" & Space(1) & "'" & CombCaption & "'", MsgBoxStyle.Information, " «ﬂÌœ «·«Œ Ì«—")
            Comb.Focus()
            Return True
        Else
            Return False
        End If

    End Function
    Public Function MyTextNull(ByVal Txt As TextBox, ByVal Caption As String) As Boolean
        If Txt.Text.Trim = Nothing Then
            MsgBox("Õﬁ·" & "'" & Caption & "'  " & "›«—€", MsgBoxStyle.Information, " «ﬂÌœ «·«Œ Ì«—")
            Txt.Focus()
            Return True
        Else
            Txt.Text = Txt.Text.Trim
            Return False
        End If

    End Function

    Public Function FindSubStringIndex(combo As ComboBox, subString As String, Optional comparer As StringComparison = StringComparison.CurrentCulture) As Integer
        ' Sanity check parameters
        If combo Is Nothing Then
            Throw New ArgumentNullException("combo")
        End If
        If subString Is Nothing Then
            Return -1
        End If

        For index As Integer = 0 To combo.Items.Count - 1
            Dim obj As Object = combo.Items(index)
            If obj Is Nothing Then
                Continue For
            End If
            Dim item As String = Convert.ToString(obj, CultureInfo.CurrentCulture)
            If String.IsNullOrWhiteSpace(item) AndAlso String.IsNullOrWhiteSpace(subString) Then
                Return index
            End If
            Dim indexInItem As Integer = item.IndexOf(subString, comparer)
            If indexInItem >= 0 Then
                Return index
            End If
        Next

        Return -1
    End Function

<<<<<<< HEAD
    Public Sub FILLCOMBOBOX(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As Object)
        Using Consum As New SqlConnection(constring)
            COMBO.Items.Clear()
            Try
                Dim query As String = "SELECT DISTINCT " & FIELD & " FROM " & TABLE
                Dim strSQL1 As New SqlCommand(query, Consum)
                Consum.Open()
                Using DR As SqlDataReader = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
                    While DR.Read()
                        COMBO.Items.Add(DR(0))
                    End While
                End Using
            Catch ex As SqlException
                MessageBox.Show("SQL Error: " & ex.Message, "ErrorFILLCOMBOBOX", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message, "ErrorFILLCOMBOBOX", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

    'error: interface not registered
    Public Sub FILLCOMBOBOX1(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal COMBO As Object)
        COMBO.Items.Clear()
        Dim query As String = "SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE " & FIELD1 & " = @Field2"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Field2", FIELD2)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            COMBO.Items.Add(reader(FIELD).ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("ErrorFILLCOMBOBOX1: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using


    End Sub

    Public Sub FILLCOMBOBOX2(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal COMBO As Object)
        COMBO.Items.Clear()
        Dim query As String = "SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE " & FIELD1 & " = @Field2"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@Field2", FIELD2)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            COMBO.Items.Add(reader(FIELD).ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("ErrorFILLCOMBOBOX2: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub

    Public Sub FILLCOMBOBOX10(ByVal tableName As String, ByVal fieldName As String, ByVal filterField1 As String, ByVal filterValue1 As String, ByVal filterField2 As String, ByVal filterValue2 As String, ByVal comboBox As Object)
        comboBox.Items.Clear()
        Dim query As String = "SELECT DISTINCT " & fieldName & " FROM " & tableName & " WHERE " & filterField1 & " = @FilterValue1 AND " & filterField2 & " = @FilterValue2"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@FilterValue1", filterValue1)
                command.Parameters.AddWithValue("@FilterValue2", filterValue2 & "0")
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            comboBox.Items.Add(reader(fieldName).ToString())
                        End While
                    End Using
                Catch ex As Exception
                    MessageBox.Show("ErrorFILLCOMBOBOX10: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub



    Public Sub FILLCOMBOBOX3(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal FIELD3 As String, ByVal FIELD4 As String, ByVal COMBO As Object)
        ' Validate input parameters
        'If String.IsNullOrWhiteSpace(TABLE) OrElse String.IsNullOrWhiteSpace(FIELD) OrElse String.IsNullOrWhiteSpace(FIELD1) OrElse String.IsNullOrWhiteSpace(FIELD2) OrElse String.IsNullOrWhiteSpace(FIELD3) OrElse String.IsNullOrWhiteSpace(FIELD4) Then
        '    Throw New ArgumentException("Table, Field, Field1, Field2, Field3, and Field4 parameters cannot be null or empty.")
        'End If
        'If COMBO Is Nothing Then
        '    Throw New ArgumentNullException(NameOf(COMBO))
        'End If
        COMBO.Items.Clear()
        Dim query As String = "SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE [" & FIELD1 & "] = @Field2 AND [" & FIELD3 & "] = @Field4"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the command
                command.Parameters.AddWithValue("@Field2", FIELD2)
                command.Parameters.AddWithValue("@Field4", FIELD4)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            COMBO.Items.Add(reader(0))
                        End While
                    End Using
                Catch ex As Exception
                    ' Handle exceptions
                    MessageBox.Show("An error occurred: " & ex.Message, "ErrorFILLCOMBOBOX3", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
    End Sub


    Public Sub FILLCOMBOBOXDISTINCT(ByVal TABLE As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal FIELD3 As String, ByVal FIELD4 As String, ByVal COMBO As Object)
        Dim query As String = "SELECT " & FIELD1 & ", " & FIELD2 & " FROM " & TABLE & " WHERE " & FIELD3 & " = @Field4"
        Try
            Using Consum As New SqlConnection(constring)
                Using cmd As New SqlCommand(query, Consum)
                    cmd.Parameters.AddWithValue("@Field4", FIELD4)
                    Consum.Open()
                    COMBO.Items.Clear()
                    Using DR As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                        While DR.Read()
                            COMBO.Items.Add(DR(FIELD2).ToString() & "-" & DR(FIELD1).ToString())
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "ErrorFILLCOMBOBOXDISTINCT", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub FILLCOMBOBOXValueMember(ByVal TABLE As String, ByVal FIELDDisplayMember As String, ByVal FIELDValueMember As String, ByVal COMBO As ComboBox)
        Try
            Using Consum As New SqlConnection(constring)
                Dim BS As New BindingSource
                Dim DSCO As New DataSet
                Dim str As New SqlCommand("SELECT DISTINCT " & FIELDDisplayMember & "," & FIELDValueMember & " FROM " & TABLE, Consum)
                Dim ADP As New SqlDataAdapter(str)
                Consum.Open()
                ADP.Fill(DSCO, "TBL")
                BS.DataSource = DSCO
                BS.DataMember = "TBL"
                COMBO.Items.Clear()
                COMBO.DataSource = BS
                COMBO.DisplayMember = FIELDDisplayMember
                COMBO.ValueMember = FIELDValueMember
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub FILLCOMBOBOXITEMS(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As ComboBox)
        Try
            Using Consum As New SqlConnection(constring)
                Dim DSCO As New DataSet
                Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE, Consum)
                Dim ADP As New SqlDataAdapter(str)
                Consum.Open()
                ADP.Fill(DSCO, "TBL")
                COMBO.Items.Clear()
                For Each row As DataRow In DSCO.Tables("TBL").Rows
                    If Not IsDBNull(row(0)) Then
                        COMBO.Items.Add(row(0))
                    End If
                Next
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "ErrorFILLCOMBOBOXITEMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub FILLCOMBOBOXITEMSAccess(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As ComboBox)
        Dim Consum As New SqlConnection(constring)
        Dim DS As New DataSet
        Dim adapt As SqlDataAdapter = Nothing

        Try
            Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE, Consum)
            adapt = New SqlDataAdapter(str)
            Consum.Open()
            adapt.Fill(DS, "TBL")
            COMBO.Items.Clear()

            For Each row As DataRow In DS.Tables("TBL").Rows
                If Not IsDBNull(row(0)) Then
                    COMBO.Items.Add(row(0))
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If adapt IsNot Nothing Then adapt.Dispose()
            If Consum.State = ConnectionState.Open Then Consum.Close()
        End Try
    End Sub

    Public Sub FILLCOMBOBOXITEMSTWOFIELDS(ByVal TABLE As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal COMBO As ComboBox)
        If String.IsNullOrWhiteSpace(TABLE) Then Throw New ArgumentException("TABLE cannot be null or empty", NameOf(TABLE))
        If String.IsNullOrWhiteSpace(FIELD1) Then Throw New ArgumentException("FIELD1 cannot be null or empty", NameOf(FIELD1))
        If String.IsNullOrWhiteSpace(FIELD2) Then Throw New ArgumentException("FIELD2 cannot be null or empty", NameOf(FIELD2))
        If COMBO Is Nothing Then Throw New ArgumentNullException(NameOf(COMBO))

        Dim query As String = $"SELECT {FIELD1}, {FIELD2} FROM {TABLE}"
        Dim DSCO As New DataSet

        Try
            Using Consum As New SqlConnection(constring)
                Using str As New SqlCommand(query, Consum)
                    Using ADP As New SqlDataAdapter(str)
                        If Consum.State = ConnectionState.Open Then Consum.Close()
                        Consum.Open()
                        ADP.Fill(DSCO, "TBL")
                    End Using
                End Using
            End Using

            COMBO.Items.Clear()
            For Each row As DataRow In DSCO.Tables("TBL").Rows
                COMBO.Items.Add($"{row(FIELD1)} - {row(FIELD2)}")
            Next
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

=======

    Public Sub FILLCOMBOBOX(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As Object)
        Dim Consum As New SqlConnection(constring)
        COMBO.Items.Clear()
        Try
            Dim strSQL1 As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE, Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                COMBO.Items.Add(DR(0))
            Loop
            DR.Close()
        Catch ex As Exception
        Finally
            Consum.Close()
        End Try
    End Sub

    Public Sub FILLCOMBOBOX1(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal COMBO As Object)
        Dim Consum As New SqlConnection(constring)
        COMBO.Items.Clear()
        On Error Resume Next
        Dim strSQL1 As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE " & FIELD1 & "=" & FIELD2, Consum)
        Consum.Open()
        DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
        Do While DR.Read()
            COMBO.Items.Add(DR(0))
        Loop
        DR.Close()
        'Catch ex As Exception WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
        '    Consum.Close()
        '    MsgBox("Error:" & ex.ToString)
        'Finally
        '    'Consum.Close()
        'End Try
        Consum.Close()
    End Sub

    Public Sub FILLCOMBOBOX10(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal FIELD3 As String, ByVal FIELD4 As String, ByVal COMBO As Object)
        Dim Consum As New SqlConnection(constring)
        COMBO.Items.Clear()
        On Error Resume Next
        Dim strSQL2 As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE " & FIELD1 & "='" & FIELD2 & "'" & "AND " & FIELD3 & " = '" & FIELD4 & "0" & "'", Consum)
        Consum.Open()
        DR = strSQL2.ExecuteReader(CommandBehavior.CloseConnection)
        Do While DR.Read()
            COMBO.Items.Add(DR(0))
        Loop
        DR.Close()
        'Catch ex As Exception WHERE " & FIELD1 & "='" & TXT & "'" & "AND " & FIELD2 & " = '" & TXT1 & "0" & "'"
        '    Consum.Close() "SELECT max(" & FIELD & ") FROM " & TABLE & " WHERE " & FIELD1 & "='" & TXT & "'" & "AND " & FIELD2 & " = '" & TXT1 & "0" & "'"
        '    MsgBox("Error:" & ex.ToString)
        'Finally
        '    'Consum.Close()
        'End Try
        Consum.Close()
    End Sub

    Public Sub FILLCOMBOBOX2(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal COMBO As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim BS As New BindingSource
        Dim DS As New DataSet
        Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE " & FIELD1 & "=" & FIELD2, Consum)
        Dim ADP As New SqlClient.SqlDataAdapter(str)
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        ADP.Fill(DS, "TBL")
        BS.DataSource = DS
        BS.DataMember = "TBL"
        COMBO.Items.Clear()
        COMBO.DataSource = BS
        COMBO.DisplayMember = FIELD
        COMBO.ValueMember = FIELD
        'COMBO.SelectedIndex = 0 WHERE  CUser='" & CUser & "' and Year(CST7) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
        ADP.Dispose()
        Consum.Close()
    End Sub

    Public Sub FILLCOMBOBOX3(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal FIELD3 As String, ByVal FIELD4 As String, ByVal COMBO As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        COMBO.Items.Clear()
        'Dim BS As New BindingSource
        'Dim DS As New DataSet
        Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE & " WHERE [" & FIELD1 & "]='" & FIELD2 & "'" & "AND [" & FIELD3 & "] = '" & FIELD4 & "'", Consum)
        'Dim ADP As New SqlClient.SqlDataAdapter(str)
        If Consum.State = ConnectionState.Open Then Consum.Close()
        Consum.Open()
        DR = str.ExecuteReader(CommandBehavior.CloseConnection)
        Do While DR.Read()
            COMBO.Items.Add(DR(0))
        Loop
        DR.Close()
        Consum.Close()



        'ADP.Fill(DS, "TBL")
        'BS.DataSource = DS
        'BS.DataMember = "TBL"
        'COMBO.Items.Clear()
        'COMBO.DataSource = BS
        'COMBO.DisplayMember = FIELD
        'COMBO.ValueMember = FIELD
        ''COMBO.SelectedIndex = 0 
        'ADP.Dispose()

    End Sub

    Public Sub FILLCOMBOBOXDISTINCT(ByVal TABLE As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal FIELD3 As String, ByVal FIELD4 As String, ByVal COMBO As Object)
        COMBO.Items.Clear()
        Dim Consum As New SqlClient.SqlConnection(constring)
        Try
            Dim strSQL1 As New SqlCommand("SELECT  " & FIELD1 & "," & FIELD2 & " FROM " & TABLE & " WHERE " & FIELD3 & "=" & FIELD4, Consum)
            Consum.Open()
            DR = strSQL1.ExecuteReader(CommandBehavior.CloseConnection)
            Do While DR.Read()
                COMBO.Items.Add(DR(1) & "-" & DR(0))

            Loop
            Consum.Close()
        Catch ex As Exception
        Finally
        End Try
        Consum.Close()
    End Sub

    Public Sub FILLCOMBOBOXValueMember(ByVal TABLE As String, ByVal FIELDDisplayMember As String, ByVal FIELDValueMember As String, ByVal COMBO As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim BS As New BindingSource
        Dim DSCO As New DataSet
        Dim str As New SqlCommand("SELECT DISTINCT " & FIELDDisplayMember & "," & FIELDValueMember & " FROM " & TABLE, Consum)
        Dim ADP As New SqlClient.SqlDataAdapter(str)
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        ADP.Fill(DSCO, "TBL")
        BS.DataSource = DSCO
        BS.DataMember = "TBL"
        COMBO.Items.Clear()
        COMBO.DataSource = BS
        COMBO.DisplayMember = FIELDDisplayMember
        COMBO.ValueMember = FIELDValueMember
        ADP.Dispose()
        Consum.Close()
    End Sub

    Public Sub FILLCOMBOBOXITEMS(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim I As Integer
        Dim DSCO As New DataSet
        Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE, Consum)
        Dim ADP As New SqlClient.SqlDataAdapter(str)
        DSCO.Clear()
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        ADP.Fill(DSCO, "TBL")
        COMBO.Items.Clear()
        For I = 0 To ds.Tables("TBL").Rows.Count - 1
            If DSCO.Tables("TBL").Rows(I).Item(0) Is DBNull.Value Then
            Else
                COMBO.Items.Add(DSCO.Tables("TBL").Rows(I).Item(0))
            End If
        Next I
        ADP.Dispose()
        Consum.Close()
    End Sub

    Public Sub FILLCOMBOBOXITEMSAccess(ByVal TABLE As String, ByVal FIELD As String, ByVal COMBO As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim I As Integer
        Dim DS As New DataSet
        Dim str As New SqlCommand("SELECT DISTINCT " & FIELD & " FROM " & TABLE, Consum)
        Dim adapt As New SqlClient.SqlDataAdapter(str)
        DS.Clear()
        Consum.Open()
        adapt.Fill(DS, "TBL")
        COMBO.Items.Clear()
        For I = 0 To DS.Tables("TBL").Rows.Count - 1
            If DS.Tables("TBL").Rows(I).Item(0) Is DBNull.Value Then
            Else
                COMBO.Items.Add(DS.Tables("TBL").Rows(I).Item(0))
            End If
        Next I
        adapt.Dispose()
    End Sub

    Public Sub FILLCOMBOBOXITEMSTWOFIELDS(ByVal TABLE As String, ByVal FIELD1 As String, ByVal FIELD2 As String, ByVal COMBO As Object)
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim I As Integer
        Dim DSCO As New DataSet
        Dim str As New SqlCommand("SELECT  " & FIELD1 & "," & FIELD2 & "FROM " & TABLE, Consum)
        Dim ADP As New SqlClient.SqlDataAdapter(str)
        DSCO.Clear()
        If Consum.State = ConnectionState.Open Then
            Consum.Close()
        End If
        Consum.Open()
        ADP.Fill(DSCO, "TBL")
        COMBO.Items.Clear()
        For I = 0 To DSCO.Tables("TBL").Rows.Count - 1
            COMBO.Items.Add(DSCO.Tables("TBL").Rows(I).Item(0) & " - " & DSCO.Tables("TBL").Rows(I).Item(1))
        Next I
        ADP.Dispose()
        Consum.Close()
    End Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

    Public Sub MYSHUTDOWN(ByVal OPERATION As Byte)
        On Error Resume Next
        Dim resault As Integer
        Select Case OPERATION
            Case 0
                resault = MessageBox.Show("Â·  —Ìœ €·ﬁ «·ÃÂ«“", "«€·«ﬁ «·ÃÂ«“ ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -s -f -t 0")
                Else
                    Exit Sub
                End If
            Case 1
                resault = MessageBox.Show("Â·  —Ìœ «⁄«œ…  ‘€Ì· «·ÊÌ‰œ“ ", "«⁄«œ…  ‘€Ì· «·ÊÌ‰œ“ ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -r -f -t 0")
                Else
                    Exit Sub
                End If
            Case 2
                resault = MessageBox.Show("Â·  —Ìœ ⁄„· Log Off ", "Log Off ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Shell("shutdown -l -f -t 0")
                Else
                    Exit Sub
                End If
        End Select
    End Sub

<<<<<<< HEAD
    Public Sub Auditor(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal chk As String, USERLogentry As String)
        If USERLogentry Is Nothing Then
            Throw New ArgumentNullException(NameOf(USERLogentry))
        End If

        Dim query As String = "SELECT [" & FIELD & "] FROM [" & TABLE & "] WHERE [" & FIELD1 & "] = @chk"

        Using Consum As New SqlConnection(constring)
            Using SavInto As New SqlCommand(query, Consum)
                SavInto.CommandType = CommandType.Text
                SavInto.Parameters.AddWithValue("@chk", chk)

                If Consum.State <> ConnectionState.Open Then Consum.Open()

                Using DR As SqlDataReader = SavInto.ExecuteReader()
                    If DR.Read() Then
                        Uses = If(DR.IsDBNull(0), String.Empty, DR.GetString(0))
                    End If
                End Using
            End Using
        End Using
=======
    Public Sub Auditor(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal chk As String, ByVal USERLogentry As String)
        Dim SavInto As New SqlCommand
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim DR As SqlDataReader
        SavInto.Connection = Consum
        SavInto.CommandType = CommandType.Text
        'If USERLogentry = 0 Then SavInto.CommandText = "SELECT [" & FIELD & "] FROM [" & TABLE & "] WHERE [" & FIELD1 & "]=" & chk
        If USERLogentry = "" Then SavInto.CommandText = "SELECT [" & FIELD & "] FROM [" & TABLE & "] WHERE [" & FIELD1 & "]='" & chk & "'"
        'If USERLogentry = 2 Then SavInto.CommandText = "SELECT [" & FIELD & "] FROM [" & TABLE & "]"
        ID_Nam = ""
        If Consum.State <> ConnectionState.Open Then Consum.Open()
        DR = SavInto.ExecuteReader()
        Do While DR.Read
            If TypeOf DR.Item(0) Is DBNull Then
                Uses = DR.Item(0).ToString
            Else
                Uses = DR.Item(0).ToString
            End If
        Loop
        Consum.Close()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Sub

    Public Sub GetNoRecord(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal TXT As String, ByVal TXT1 As Integer)
        Dim SavInto As New SqlCommand
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim DR As SqlDataReader
        SavInto.Connection = Consum
        SavInto.CommandType = CommandType.Text
        If TXT1 = 0 Then SavInto.CommandText = "SELECT max([" & FIELD & "]) FROM [" & TABLE & "] WHERE [" & FIELD1 & "]=" & TXT
        If TXT1 = 1 Then SavInto.CommandText = "SELECT max([" & FIELD & "]) FROM [" & TABLE & "] WHERE [" & FIELD1 & "]='" & TXT & "'"
        If TXT1 = 2 Then SavInto.CommandText = "SELECT max([" & FIELD & "]) FROM [" & TABLE & "]"
        ID_Nam = ""
        If Consum.State <> ConnectionState.Open Then Consum.Open()
        DR = SavInto.ExecuteReader()
        Do While DR.Read
            If TypeOf DR.Item(0) Is DBNull Then
                ID_Nam = DR.Item(0).ToString
            Else
                ID_Nam = DR.Item(0).ToString
            End If
        Loop
        Consum.Close()
    End Sub

<<<<<<< HEAD
    Public Sub MYDELETERECORD(ByVal tableName As String, ByVal fieldName As String, ByVal txt As Object, ByVal bindingSource As BindingSource, Optional ByVal isFieldNumeric As Boolean = True)
        Try
            If bindingSource.Count > 0 Then
                Using connection As New SqlConnection(constring)
                    Dim query As String
                    If isFieldNumeric Then
                        query = $"DELETE FROM {tableName} WHERE {fieldName} = @FieldValue"
                    Else
                        query = $"DELETE FROM {tableName} WHERE {fieldName} = @FieldValue"
                    End If

                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@FieldValue", txt.Text.Trim())
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
            Else
                MessageBox.Show("No current record to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub MYDELETERECORD1(ByVal tableName As String, ByVal fieldName As String, ByVal txt As DevExpress.XtraEditors.TextEdit, ByVal bindingSource As BindingSource, Optional ByVal isFieldNumeric As Boolean = True)
        Try
            If bindingSource.Count > 0 Then
                Using connection As New SqlConnection(constring)
                    Dim query As String
                    If isFieldNumeric Then
                        query = $"DELETE FROM {tableName} WHERE {fieldName} = @FieldValue"
                    Else
                        query = $"DELETE FROM {tableName} WHERE {fieldName} = @FieldValue"
                    End If

                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@FieldValue", txt.EditValue)
                        connection.Open()
                        command.ExecuteNonQuery()
                    End Using
                End Using
            Else
                MessageBox.Show("No current record to delete", "Delete Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
=======
    Public Sub MYDELETERECORD(ByVal TABLE As String, ByVal FIELD As String, ByVal TXT As Object, ByVal BS As BindingSource, Optional ByVal FIELDtextornumer As Boolean = True)
        Try
            Dim Consum As New SqlClient.SqlConnection(constring)
            'Dim resault As Integer
            Dim SQL As New SqlClient.SqlCommand("", Consum)
            'Dim FRM As Form
            If FIELDtextornumer = True Then
                SQL.CommandText = "DELETE FROM " & TABLE & " WHERE " & FIELD & "=" & TXT.Text.Trim
            Else
                SQL.CommandText = "DELETE FROM " & TABLE & " WHERE " & FIELD & "='" & TXT.Text.Trim & "'"
            End If

            If BS.Count > 0 Then
                'resault = MessageBox.Show("”»‰„ Õ–› «·”Ã· «·Õ«·Ï", "Õ–› ”Ã· " & TABLE, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                'If resault = vbYes Then
                Dim CMD As New SqlClient.SqlCommand With {
                    .CommandType = CommandType.Text,
                    .Connection = Consum
                }
                If Consum.State = ConnectionState.Open Then Consum.Close()
                Consum.Open()
                CMD.CommandText = SQL.CommandText
                CMD.ExecuteNonQuery()
                Consum.Close()
                'Else
                '    MessageBox.Show(" „ «Ìﬁ«› ⁄„·Ì… «·Õ–›", "Õ–› ”Ã·", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                '    Exit Sub
                'End If
            Else
                MessageBox.Show(" ·«ÌÊÃœ ”Ã· Õ«·Ï ·« „«„ ⁄„·Ì… «·Õ–›", "Õ–› ”Ã·", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                Exit Sub
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CLEARDATA(ByVal frm As Form, ByVal gbx As GroupBox)
        On Error Resume Next
        Dim txt As Control
        Dim chk As CheckBox
        For Each txt In frm.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If
            If gbx Is Nothing Then
                Exit Sub
            Else
                For Each chk In gbx.Controls
                    If TypeOf chk Is CheckBox Then
                        chk.Checked = False
                    End If
                Next
            End If
        Next
    End Sub

    Public Sub CLEARDATA1(ByVal frm As Form)
        On Error Resume Next
        Dim txt As Control
        Dim chk As CheckBox
        For Each txt In frm.Controls
            If TypeOf txt Is TextBox Or TypeOf txt Is ComboBox Then
                txt.Text = ""
            End If

            If TypeOf frm.Controls(I) Is TextBox Or TypeOf frm.Controls(I) Is ComboBox Then
                frm.Controls(I).Text = ""
            End If
        Next
    End Sub

    Public Function CurrencyJO(ByVal NumbersJO As Decimal, ByVal CJO As String) As String


        'CurrencyJO()
        'NumbersJO
        On Error Resume Next
        Dim VPS As Decimal = 0
        Dim V As Decimal = 0
        Dim WORDINTEGER As String = ""
        Dim LE As String = ""
        Dim LE1 As String = ""
        Dim LE2 As String = ""
        Dim P As String = ""
        Dim PS As String = ""
        Dim PS1 As String = ""
        CurrencyJO = ""

        Dim POUNDS As String = ""
        Dim WORDPS As String = ""

        Dim DOLLAR As String = ""
        Dim SENT As String = ""
        Dim SENTS As String = ""

        Dim TON As String = ""
        Dim KG As String = ""
        Dim KGS As String = ""
        Select Case CJO
            Case "jO"
                LE = " œÌ‰«— "
                LE1 = " œÌ‰«—Ì‰ "
                LE2 = " œ‰«‰Ì— "
                P = " ›·” "
                PS = " ›·Ê” "
                PS1 = " ›·”«‰ "
                POUNDS = " œ‰«‰Ì— "
                V = Int(Math.Abs(NumbersJO))
                VPS = Val(Right(Format(NumbersJO, "000000000000.000"), 3))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then CurrencyJO = WORDINTEGER & LE & " Ê " & WORDPS & P & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And VPS >= 3 And VPS <= 9 Then CurrencyJO = WORDINTEGER & LE & " Ê " & WORDPS & PS & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And (VPS > 9) Then CurrencyJO = WORDINTEGER & LE & " Ê " & WORDPS & P & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And (VPS = 2) Then CurrencyJO = WORDINTEGER & " Ê " & PS1 & "›ﬁÿ ·«€Ì— "

                If WORDINTEGER = "" And (VPS <= 2) Then CurrencyJO = WORDPS & P & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS >= 3 And VPS <= 9 Then CurrencyJO = WORDPS & PS & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS > 9 Then CurrencyJO = WORDPS & P & "›ﬁÿ ·«€Ì— "

                If WORDINTEGER = "" And VPS = 0 Then CurrencyJO = ""
                If WORDINTEGER <> "" And VPS = 0 Then CurrencyJO = WORDINTEGER & LE & "›ﬁÿ ·«€Ì— "

            Case "USA"
                DOLLAR = " œÊ·«— "
                SENT = " ”‰ « "
                SENTS = "”‰ « "
                V = Int(System.Math.Abs(NumbersJO))
                VPS = Val(Right(Format(NumbersJO, "000000000000.00"), 2))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then CurrencyJO = WORDINTEGER & DOLLAR & " Ê " & WORDPS & SENT & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And VPS >= 3 And VPS <= 9 Then CurrencyJO = WORDINTEGER & DOLLAR & " Ê " & WORDPS & " " & SENTS & " " & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And (VPS > 9) Then CurrencyJO = WORDINTEGER & DOLLAR & " Ê " & WORDPS & SENT & "›ﬁÿ ·«€Ì— "

                If WORDINTEGER = "" And (VPS <= 2) Then CurrencyJO = WORDPS & SENT & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS >= 3 And VPS <= 9 Then CurrencyJO = WORDPS & " " & SENTS & " " & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS > 9 Then CurrencyJO = WORDPS & SENT & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS = 0 Then CurrencyJO = ""
                If WORDINTEGER <> "" And VPS = 0 Then CurrencyJO = WORDINTEGER & DOLLAR & "›ﬁÿ ·«€Ì— "
            Case "WEIGHT"
                TON = " ÿ‰ "
                KG = " ﬂÌ·Ê Ã—«„ "
                KGS = "ﬂÌ·Ê Ã—«„« "
                V = Int(Math.Abs(NumbersJO))
                VPS = Val(Right(Format(NumbersJO, "000000000000.000"), 3))
                WORDINTEGER = AmountWord(V)
                WORDPS = AmountWord(VPS)
                If WORDINTEGER <> "" And (VPS <= 2) Then CurrencyJO = WORDINTEGER & TON & " Ê " & WORDPS & KG & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And VPS >= 3 And VPS <= 9 Then CurrencyJO = WORDINTEGER & TON & " Ê " & WORDPS & KGS & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER <> "" And (VPS > 9) Then CurrencyJO = WORDINTEGER & TON & " Ê " & WORDPS & KG & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And (VPS <= 2) Then CurrencyJO = WORDPS & KG & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS >= 3 And VPS <= 9 Then CurrencyJO = WORDPS & KGS & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS > 9 Then CurrencyJO = WORDPS & KG & "›ﬁÿ ·«€Ì— "
                If WORDINTEGER = "" And VPS = 0 Then CurrencyJO = ""
                If WORDINTEGER <> "" And VPS = 0 Then CurrencyJO = WORDINTEGER & TON & "›ﬁÿ ·«€Ì— "
        End Select
    End Function

    Public Function AmountWord(ByVal AMOUNT As Decimal) As String
        On Error Resume Next
        Dim n As Decimal = 0
        Dim C0 As Decimal = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim C4 As Decimal = 0
        Dim C5 As Decimal = 0
        Dim C6 As Decimal = 0

        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""
        Dim S6 As String = ""
        Dim m As String = ""
        Dim C As String = ""
        n = Int(AMOUNT)
        C = Format(n, "000000000000")

        C0 = Val(Mid(C, 12, 1))

        Select Case C0
            Case Is = 2 : m = " œÌ‰«—Ì‰ "
            Case Is > 2 : m = " œ‰«‰Ì— "
                C0 = m
        End Select
        If m <> "" And C0 = 2 Then m = m
        ' If m <> "" And C1 >= 3 Then S1 = m + S1

        C1 = Val(Mid(C, 12, 1))
        Select Case C1
            Case Is = 1 : S1 = "Ê«Õœ"
            Case Is = 2 : S1 = "≈À‰«‰"
            Case Is = 3 : S1 = "À·«À…"
            Case Is = 4 : S1 = "«—»⁄…"
            Case Is = 5 : S1 = "Œ„”…"
            Case Is = 6 : S1 = "” …"
            Case Is = 7 : S1 = "”»⁄…"
            Case Is = 8 : S1 = "À„«‰Ì…"
            Case Is = 9 : S1 = " ”⁄…"
        End Select

        C2 = Val(Mid(C, 11, 1))
        Select Case C2
            Case Is = 1 : S2 = "⁄‘—"
            Case Is = 2 : S2 = "⁄‘—Ê‰"
            Case Is = 3 : S2 = "À·«ÀÊ‰"
            Case Is = 4 : S2 = "«—»⁄Ê‰"
            Case Is = 5 : S2 = "Œ„”Ê‰"
            Case Is = 6 : S2 = "” Ê‰"
            Case Is = 7 : S2 = "”»⁄Ê‰"
            Case Is = 8 : S2 = "À„«‰Ê‰"
            Case Is = 9 : S2 = " ”⁄Ê‰"
        End Select

        If S1 <> "" And C2 > 1 Then S2 = S1 + " Ê" + S2
        If S2 = "" Then S2 = S1
        If C1 = 0 And C2 = 1 Then S2 += "…"
        If C1 = 1 And C2 = 1 Then S2 = "«ÕœÏ ⁄‘—"
        If C1 = 2 And C2 = 1 Then S2 = "«À‰Ï ⁄‘—"
        If C1 > 2 And C2 = 1 Then S2 = S1 + " " + S2

        C3 = Val(Mid(C, 10, 1))
        Select Case C3
            Case Is = 1 : S3 = "„«∆…"
            Case Is = 2 : S3 = "„∆ «‰"
            Case Is > 2 : S3 = Left(AmountWord(C3), Len(AmountWord(C3)) - 1) + "„«∆…"
        End Select

        If S3 <> "" And S2 <> "" Then S3 = S3 + " Ê" + S2
        If S3 = "" Then S3 = S2
        C4 = Val(Mid(C, 7, 3))
        Select Case C4
            Case Is = 1 : S4 = "«·›"
            Case Is = 2 : S4 = "«·›«‰"
            Case 3 To 10 : S4 = AmountWord(C4) + " ¬·«›"
            Case Is > 10 : S4 = AmountWord(C4) + " «·›"
        End Select

        If S4 <> "" And S3 <> "" Then S4 = S4 + " Ê" + S3
        If S4 = "" Then S4 = S3
        C5 = Val(Mid(C, 4, 3))
        Select Case C5
            Case Is = 1 : S5 = "„·ÌÊ‰"
            Case Is = 2 : S5 = "„·ÌÊ‰«‰"
            Case 3 To 10 : S5 = AmountWord(C5) + " „·«ÌÌ‰"
            Case Is > 10 : S5 = AmountWord(C5) + " „·ÌÊ‰"
        End Select

        If S5 <> "" And S4 <> "" Then S5 = S5 + " Ê" + S4
        If S5 = "" Then S5 = S4
        C6 = Val(Mid(C, 1, 3))
        Select Case C6
            Case Is = 1 : S6 = "„·Ì«—"
            Case Is = 2 : S6 = "„·Ì«—«‰"
            Case Is > 2 : S6 = AmountWord(C6) + " „·Ì«—"
        End Select
        If S6 <> "" And S5 <> "" Then S6 = S6 + " Ê" + S5
        If S6 = "" Then S6 = S5
        AmountWord = S6
    End Function

    Public Function MydateWord(ByVal MYDATE As Date) As String
        On Error Resume Next
        Dim n As Integer = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim C As String = ""
        MydateWord = ""
        C = Format(MYDATE, "dd-mm-yyyy")
        C1 = MYDATE.Day
        C2 = MYDATE.Month
        C3 = MYDATE.Year
        Select Case C1
            Case Is = 1 : S1 = "«·«Ê·"
            Case Is = 2 : S1 = "«·À«‰Ï"
            Case Is = 3 : S1 = "«·À«·À"
            Case Is = 4 : S1 = "«·—«»⁄"
            Case Is = 5 : S1 = "«·Œ«„”"
            Case Is = 6 : S1 = "«·”«œ”"
            Case Is = 7 : S1 = "«·”«»⁄"
            Case Is = 8 : S1 = "«·À«„‰"
            Case Is = 9 : S1 = "«· «”⁄"
            Case Is = 10 : S1 = "«·⁄«‘—"
            Case Is = 11 : S1 = "«·Õ«œÏ ⁄‘—"
            Case Is = 12 : S1 = "«·À«‰Ï ⁄‘—"
            Case Is = 13 : S1 = "«·À«·À ⁄‘—"
            Case Is = 14 : S1 = "«·—«»⁄ ⁄‘—"
            Case Is = 15 : S1 = "«·Œ«„” ⁄‘—"
            Case Is = 16 : S1 = "«·”«œ” ⁄‘—"
            Case Is = 17 : S1 = "«·”«»⁄ ⁄‘—"
            Case Is = 18 : S1 = "«·À«„‰ ⁄‘—"
            Case Is = 19 : S1 = "«· «”⁄ ⁄‘—"
            Case Is = 20 : S1 = "«·⁄‘—Ê‰"
            Case Is = 21 : S1 = "«·Ê«Õœ Ê«·⁄‘—Ê‰"
            Case Is = 22 : S1 = " «·À«‰Ï Ê«·⁄‘—Ê‰"
            Case Is = 23 : S1 = "«·À«·À Ê«·⁄‘—Ê‰"
            Case Is = 24 : S1 = " «·—«»⁄ Ê«·⁄‘—Ê‰"
            Case Is = 25 : S1 = " «·Œ«„” Ê«·⁄‘—Ê‰"
            Case Is = 26 : S1 = "«·”«œ” Ê«·⁄‘—Ê‰"
            Case Is = 27 : S1 = "«·”«»⁄ Ê«·⁄‘—Ê‰"
            Case Is = 28 : S1 = "«·À«„‰ Ê«·⁄‘—Ê‰"
            Case Is = 29 : S1 = "«· «”⁄ Ê«·⁄‘—Ê‰"
            Case Is = 30 : S1 = "«·À·«ÀÊ‰"
            Case Is = 31 : S1 = "«·Ê«Õœ Ê«·À·«ÀÊ‰"
        End Select

        Select Case C2
            Case Is = 1 : S2 = "ﬂ«‰Ê‰ À«‰Ì"
            Case Is = 2 : S2 = "‘»«ÿ"
            Case Is = 3 : S2 = "√–«—"
            Case Is = 4 : S2 = "‰Ì”‹«‰"
            Case Is = 5 : S2 = "√Ì«—"
            Case Is = 6 : S2 = "Õ“Ì—√‰"
            Case Is = 7 : S2 = " „Ê“"
            Case Is = 8 : S2 = "√»"
            Case Is = 9 : S2 = "√Ì·Ê·"
            Case Is = 10 : S2 = " ‘—Ì‰ √Ê·"
            Case Is = 11 : S2 = " ‘—Ì‰ À√‰Ì"
            Case Is = 12 : S2 = "ﬂ«‰Ê‰ √Ê·"
        End Select
        MydateWord = Format(MYDATE, "dddd") & " «·„Ê«›ﬁ " & S1 & " „‰  ‘Â— " & S2 & " ”‰… " & AmountWord(CDec(C3)) & " „Ì·«œÌ… "
    End Function

    Public Function MytimeWord(ByVal MYTIME As DateTime) As String
        On Error Resume Next
        Dim n As Integer = 0
        Dim C1 As Decimal = 0
        Dim C2 As Decimal = 0
        Dim C3 As Decimal = 0
        Dim C4 As String = ""
        Dim S1 As String = ""
        Dim S2 As String = ""
        Dim S3 As String = ""
        Dim S4 As String = ""
        Dim S5 As String = ""
        Dim C As DateTime
        MytimeWord = ""
        C = Format(MYTIME, "hh:mm:ss tt")
        C1 = Format(C, "ss")
        C2 = Format(C, "mm")
        C3 = Format(C, "hh")
        C4 = Format(C, "tt")
        Select Case C4
            Case "’" : S4 = "’»«Õ«Û"
            Case "„" : S4 = "„”«¡"
            Case "AM" : S4 = "’»«Õ«Û"
            Case "PM" : S4 = "„”«¡"
        End Select
        Select Case C1
            Case Is = 0 : S3 = ""
            Case Is = 1 : S3 = " À«‰Ì… Ê«Õœ… "
            Case Is = 2 : S3 = " À«‰Ì «‰"
            Case 3 To 10 : S3 = AmountWord(C1) + " ÀÊ«‰"
            Case Is > 10 : S3 = AmountWord(C1) + " À«‰Ì…"
        End Select
        Select Case C2
            Case Is = 0 : S1 = ""
            Case Is = 1 : S1 = " œﬁÌﬁ… Ê«Õœ… "
            Case Is = 2 : S1 = " œﬁÌﬁ «‰ "
            Case 3 To 10 : S1 = AmountWord(C2) + " œﬁ«∆ﬁ "
            Case Is > 10 : S1 = AmountWord(C2) + " œﬁÌﬁ… "
        End Select
        If S1 <> "" And S3 <> "" Then S5 = S1 + " Ê" + S3
        If S1 = "" Then S5 = S3
        Select Case C3
            Case Is = 0 : S2 = ""
            Case Is = 1 : S2 = "«·Ê«Õœ…"
            Case Is = 2 : S2 = "«·À«‰Ì…"
            Case Is = 3 : S2 = "«·À«·À…"
            Case Is = 4 : S2 = "«·—«»⁄…"
            Case Is = 5 : S2 = "«·Œ«„”…"
            Case Is = 6 : S2 = "«·”«œ”…"
            Case Is = 7 : S2 = "«·”«»⁄…"
            Case Is = 8 : S2 = "«·À«„‰…"
            Case Is = 9 : S2 = "«· «”⁄…"
            Case Is = 10 : S2 = "«·⁄«‘—…"
            Case Is = 11 : S2 = "«·Õ«œÌ… ⁄‘—"
            Case Is = 12 : S2 = "«·À«‰Ì… ⁄‘—"
        End Select
        If S2 <> "" And S1 <> "" And S3 <> "" Then S5 = S2 + " Ê" + S1 + " Ê" + S3
        If S2 <> "" And S1 <> "" And S3 = "" Then S5 = S2 + " Ê" + S1
        If S2 <> "" And S1 = "" And S3 <> "" Then S5 = S2 + " Ê" + S3
        If S2 <> "" And S1 = "" And S3 = "" Then S5 = S2
        MytimeWord = " «·”«⁄… " & S5 & " " & S4
    End Function

    Public Sub AddCloseAllConnection()
<<<<<<< HEAD
        Try
            ExecuteSql("master", GetSql("dropproc.txt", True))
            ExecuteSql("master", GetSql("CloseAllConnection.sql", True))
        Catch ex As Exception
            MessageBox.Show("An error occurred while closing all connections: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub CloseAllConnection(ByVal DBName As String, ByVal frm As Form)
        Try
            AddCloseAllConnection()
            Dim serverConnectionString As String = GetServerConnectionString()

            Using sqlConnection As New SqlConnection(serverConnectionString)
                Using cmd As New SqlCommand("CloseAllConnection", sqlConnection) With {
                    .CommandType = CommandType.StoredProcedure
                }
                    cmd.Parameters.Add("@DB", SqlDbType.NVarChar, 500).Value = DBName
                    sqlConnection.Open()
                    frm.Cursor = Cursors.WaitCursor
                    cmd.ExecuteNonQuery()
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error closing connections: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            frm.Cursor = Cursors.Default
        End Try
    End Sub

    Private Function GetServerConnectionString() As String
        If AuthenicationSQLServer AndAlso LocalConnection Then
            Return $"Data Source={ServerName};Initial Catalog=master;User Id={userIDName};Password={BWS1};"
        ElseIf AuthenicationSQLServer AndAlso ServerConnection Then
            Return $"Data Source={ServerName},{PORT};Initial Catalog=master;User Id={userIDName};Password={BWS1};"
        ElseIf Not AuthenicationSQLServer AndAlso LocalConnection Then
            Return $"Data Source={ServerName};Initial Catalog=master;Integrated Security=True"
        End If
        Throw New InvalidOperationException("Invalid connection settings.")
    End Function

    Public Sub Backup_database(ByVal DBName As String)
        Try
            Dim dt As String = Now.ToString("yyyy-MM-dd-mm-tt")
            Dim backupFolder As String = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA") & "\Backup" & Now.ToString("yyyy-MM")
            Dim backupFilePath As String = Path.Combine(backupFolder, $"{DBName}_{dt}.dmp")

            If Not Directory.Exists(backupFolder) Then
                Directory.CreateDirectory(backupFolder)
            End If

            Dim serverConnectionString As String
            If AuthenicationSQLServer Then
                If LocalConnection Then
                    serverConnectionString = $"Data Source={ServerName};Initial Catalog=master;User Id={userIDName};Password={BWS1};"
                ElseIf ServerConnection Then
                    serverConnectionString = $"Data Source={ServerName},{PORT};Initial Catalog=master;User Id={userIDName};Password={BWS1};"
                End If
            ElseIf LocalConnection Then
                serverConnectionString = $"Data Source={ServerName};Initial Catalog=master;Integrated Security=True"
            End If

            Using conUsers As New SqlConnection(GetServerConnectionString)
                Using cmd As New SqlCommand("backup database @DBName to disk=@PATHFILE with init", conUsers)
                    cmd.CommandType = CommandType.Text
                    cmd.Parameters.AddWithValue("@DBName", DBName)
                    cmd.Parameters.AddWithValue("@PATHFILE", backupFilePath)

                    conUsers.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show($" „ «‰‘«¡ ‰”ŒÂ «Õ Ì«ÿÌ… „‰ ﬁ«⁄œ… «·»Ì«‰«  «·Õ«·Ì… ›Ï «·„”«— «· «·Ï {vbCrLf}{vbCrLf}{backupFilePath}", "«‰‘«¡ ‰”ŒÂ «Õ Ì«ÿÌÂ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Backup Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Public Function SumAmounTOTALCASHANDCHEQUES(ByVal cust As String, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT Sum(CAB4-CAB5) FROM CABLES WHERE CABLES.CUser = @CUser AND Year(CAB3) = @FiscalYear AND CAB11 = @Cust AND CABLES.IDCAB <= @Num"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@Cust", cust)
                command.Parameters.AddWithValue("@Num", num)
                Try
                    connection.Open()
                    Dim resultObj As Object = command.ExecuteScalar()
                    If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                        result = Convert.ToDouble(resultObj)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        Return Math.Round(result, 3)
    End Function

    Public Function SumAmounTOTALCASHANDCHEQUES1(ByVal cust As String, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT Sum(CAB5-CAB4) FROM Suppliers1 WHERE Suppliers1.CUser = @CUser AND Year(CAB3) = @FiscalYear AND CAB11 = @Cust AND Suppliers1.IDCAB <= @Num"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@Cust", cust)
                command.Parameters.AddWithValue("@Num", num)
                Try
                    connection.Open()
                    Dim resultObj = command.ExecuteScalar()
                    If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                        result = Convert.ToDouble(resultObj)
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        Return Math.Round(result, 3)
    End Function

    Public Function SumAmounTOTALCASHANDCHEQUES2(ByVal customer As String, ByVal customer1 As String, ByVal number As Int64) As Double
        If customer1 Is Nothing Then
            Throw New ArgumentNullException(NameOf(customer1))
        End If

        Dim result As Double = 0
        Using connection As New SqlConnection(constring)
            Dim query As String = "SELECT Sum(TBNK5-TBNK4) FROM PTRANSACTION WHERE PTRANSACTION.CUser = @CUser AND Year(TBNK3) = @FiscalYear AND TBNK6 = @Customer AND PTRANSACTION.TBNK1 <= @Number"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@Customer", customer)
                command.Parameters.AddWithValue("@Number", number)
                connection.Open()
                Dim resultObj = command.ExecuteScalar()
                If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                    result = Convert.ToDouble(resultObj)
                End If
            End Using
        End Using
        Return Math.Round(result, 3)
    End Function

    Public Function SumAmounTOTALBALANCECASHIER(ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT Sum(CSH7-CSH8) FROM CASHIER WHERE CUser = @CUser AND Year(CSH2) = @FiscalYear AND CASHIER.CSH1 <= @Num"

        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@Num", num)

                connection.Open()
                Dim resultObj = command.ExecuteScalar()
                If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                    result = Convert.ToDouble(resultObj)
                End If
            End Using
        End Using

        Return result
    End Function

    Public Function SumAmounTOTALBALANCECASHIER11(ByVal CUserA As Integer, ByVal ComboCB As Integer, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT Sum(CSH7-CSH8) FROM CASHIER WHERE CUser = @CUserA AND CASHIER.CSH18 = @ComboCB AND CASHIER.CSH1 <= @num"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUserA", CUserA)
                command.Parameters.AddWithValue("@ComboCB", ComboCB)
                command.Parameters.AddWithValue("@num", num)
                Try
                    connection.Open()
                    Dim value As Object = command.ExecuteScalar()
                    If value IsNot Nothing AndAlso value IsNot DBNull.Value Then
                        Dim parsedValue As Double
                        If Double.TryParse(value.ToString(), parsedValue) Then
                            result = parsedValue
                        Else
                            MessageBox.Show("Conversion error: invalid numeric value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("ErrorSumCASHIER: " & ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        Return result
    End Function

    Public Function SumAmounTOTALBALANCE(ByVal BN2 As String, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT Sum(BANKJO.EBNK2) AS CurrentBalance, Sum(EBNK4-EBNK5) FROM BANKJO WHERE CUser = @CUser AND Year(EBNK3) = @FiscalYear AND EBNK10 = @BN2 AND BANKJO.EBNK1 <= @Num"
        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@BN2", BN2)
                command.Parameters.AddWithValue("@Num", num)
                Dim adapter As New SqlDataAdapter(command)
                Dim ds As New DataSet()
                connection.Open()
                adapter.Fill(ds, "BANKJO")
                If ds.Tables(0).Rows.Count > 0 Then
                    Dim currentBalance As Double = If(IsDBNull(ds.Tables(0).Rows(0).Item(0)), 0.0, Convert.ToDouble(ds.Tables(0).Rows(0).Item(0)))
                    Dim balanceDifference As Double = If(IsDBNull(ds.Tables(0).Rows(0).Item(1)), 0.0, Convert.ToDouble(ds.Tables(0).Rows(0).Item(1)))
                    result = currentBalance + balanceDifference
                End If
            End Using
        End Using

        Return result
    End Function

    Public Function SumAmounTOTALSTOCKS(ByVal CodItem As Integer, ByVal IDSTK As Int64) As Decimal
        Dim result As Decimal = 0.0
        Dim query As String = "SELECT  SUM(STK11-STK12) AS PreviousBalance FROM STOCKS WHERE CUser = @CUser AND Year(STK4) = @FiscalYear AND STK25 = @CodItem AND STOCKS.STK1 <= @IDSTK"
        Using connection As New SqlClient.SqlConnection(constring)
            Using command As New SqlClient.SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@CodItem", CodItem)
                command.Parameters.AddWithValue("@IDSTK", IDSTK)
                Try
                    connection.Open()
                    Dim resultObj As Object = command.ExecuteScalar()
                    If resultObj IsNot Nothing AndAlso Not IsDBNull(resultObj) Then
                        result = Convert.ToDecimal(resultObj)
                    End If
                Catch ex As OverflowException
                    MessageBox.Show("Overflow occurred: " & ex.Message, "ErrorSumTotalStocksOver", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Catch ex As Exception
                    MessageBox.Show("An error occurred: " & ex.Message, "ErrorSumTotalStocks", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using

        Return result
    End Function

    Public Function SumAmounTOTALSTOCKS1(ByVal cod As String, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT STK13, STK15 FROM STOCKS WHERE CUser = @CUser AND Year(STK4) = @FiscalYear AND STK25 = @cod AND STOCKS.STK1 <= @num"

        Using connection As New SqlConnection(constring)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@cod", cod)
                command.Parameters.AddWithValue("@num", num)
                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            Dim stk13 As Double = If(IsDBNull(reader("STK13")), 0.0, Convert.ToDouble(reader("STK13")))
                            Dim stk15 As Double = If(IsDBNull(reader("STK15")), 0.0, Convert.ToDouble(reader("STK15")))
                            result = stk13 * stk15
                        End If
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using
        Return Math.Round(result, 3)
    End Function

    Public Function SumAmounTOTALSTOCKS2(ByVal cod As String, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Using connection As New SqlConnection(constring)
            Dim query As String = "SELECT STK13, STK19 FROM STOCKS WHERE CUser = @CUser AND Year(STK4) = @FiscalYear AND STK25 = @Cod AND STOCKS.STK1 <= @Num"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@CUser", CUser)
                command.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                command.Parameters.AddWithValue("@Cod", cod)
                command.Parameters.AddWithValue("@Num", num)
                Dim adapter As New SqlDataAdapter(command)
                Dim dataSet As New DataSet()
                connection.Open()
                adapter.Fill(dataSet)
                If dataSet.Tables(0).Rows.Count > 0 Then
                    Dim stk13 As Double = Convert.ToDouble(dataSet.Tables(0).Rows(0)("STK13"))
                    Dim stk19 As Double = Convert.ToDouble(dataSet.Tables(0).Rows(0)("STK19"))
                    result = Math.Round(stk13 * stk19, 3)
                End If
            End Using
        End Using
        Return result
    End Function

    Public Function SumAmounTOTALBALANCEEMPSOLF(ByVal CSH15 As String, ByVal CSH1 As Integer) As Double
        Dim result As Double = 0.0
        Using Consum As New SqlConnection(constring)
            Dim query As String = "SELECT Sum(CSH7-CSH8) FROM EMPSOLF WHERE EMPSOLF.CUser = @CUser AND Year(CSH2) = @FiscalYear AND CSH15 = @CSH15 AND EMPSOLF.CSH1 <= @CSH1"
            Using strsq1 As New SqlCommand(query, Consum)
                strsq1.Parameters.AddWithValue("@CUser", CUser)
                strsq1.Parameters.AddWithValue("@FiscalYear", FiscalYear_currentDateMustBeInFiscalYear())
                strsq1.Parameters.AddWithValue("@CSH15", CSH15)
                strsq1.Parameters.AddWithValue("@CSH1", CSH1)
                Dim ds1 As New DataSet
                Using Adp1 As New SqlDataAdapter(strsq1)
                    ds1.Clear()
                    Consum.Open()
                    Adp1.Fill(ds1)
                End Using
                If ds1.Tables(0).Rows.Count > 0 AndAlso Not IsDBNull(ds1.Tables(0).Rows(0).Item(0)) Then
                    result = Convert.ToDouble(ds1.Tables(0).Rows(0).Item(0))
                End If
            End Using
        End Using
        Return result
    End Function

    Public Function SumAmounTOTALChecks(ByVal cust As String, ByVal num As Int64) As Double
        Dim result As Double = 0.0
        Dim query As String = "SELECT Sum(CH5-CH6) FROM Checks WHERE Checks.CUser = @CUser AND CH8 = @cust AND Checks.IDCH <= @num"

        Try
            Using Consum As New SqlConnection(constring)
                Using cmd As New SqlCommand(query, Consum)
                    cmd.Parameters.AddWithValue("@CUser", CUser)
                    cmd.Parameters.AddWithValue("@cust", cust)
                    cmd.Parameters.AddWithValue("@num", num)

                    Consum.Open()

                    Dim obj As Object = cmd.ExecuteScalar()
                    If obj IsNot Nothing AndAlso Not IsDBNull(obj) Then
                        result = Convert.ToDouble(obj)
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return Math.Round(result, 3)
=======
        On Error Resume Next
        ExecuteSql("master", GetSql("dropproc.txt", True))
        ExecuteSql("master", GetSql("CloseAllConnection.sql", True))
    End Sub
    Public Sub CloseAllConnection(ByVal DBName As String, ByVal frm As Form)
        On Error Resume Next
        AddCloseAllConnection()
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
            .CommandType = CommandType.StoredProcedure,
            .CommandText = "CloseAllConnection",
            .Connection = SqlConnection1
        }
        If SqlConnection1.State = ConnectionState.Open Then SqlConnection1.Close()
        SqlConnection1.Open()
        frm.Cursor = Cursors.WaitCursor
        CMD.Parameters.Add("@DB", SqlDbType.NVarChar, 500).Value = DBName
        CMD.ExecuteNonQuery()
        SqlConnection1.Dispose()
        frm.Cursor = Cursors.Default
        SqlConnection1.Dispose()
    End Sub

    Public Sub Backup_database(ByVal DBName As String)
        Try
            Dim dt As String = ""
            Dim tm As String = ""
            'Dim ConUsers As New SqlClient.SqlConnection("Data Source=" + ServerName + "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";")
            Dim ServerConnectionString As String = Nothing
            If AuthenicationSQLServer = True And LocalConnection = True Then
                ServerConnectionString = "Data Source=" & ServerName & ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
            ElseIf AuthenicationSQLServer = True And ServerConnection = True Then
                ServerConnectionString = "Data Source=" & ServerName & "," + PORT + ";Initial Catalog=master;User Id=" + userIDName + ";Password=" + BWS1 + ";"
            ElseIf AuthenicationSQLServer = False And LocalConnection = True Then
                ServerConnectionString = "Data Source = " & ServerName & ";Initial Catalog=master;Integrated Security=True"
            End If
            Dim ConUsers As New SqlClient.SqlConnection(ServerConnectionString)
            Dim CMD As New SqlClient.SqlCommand With {
                .CommandType = CommandType.Text,
                .Connection = ConUsers
            }
            If ConUsers.State = ConnectionState.Open Then ConUsers.Close()
            ConUsers.Open()
            CMD.CommandText = "backup database " + DBName + " to disk=@PATHFILE with init"
            MYFOLDER = mykey.GetValue("MYFOLDER", "D:\CO_MAS\MyDATA")
            If File.Exists(MYFOLDER & "\Backup" & Now.ToString("yyyy-MM")) = False Then
                Directory.CreateDirectory(MYFOLDER & "\Backup" & Now.ToString("yyyy-MM"))
            End If
            dt = Now.ToString("yyyy-MM-dd-mm-tt")
            CMD.Parameters.AddWithValue("@PATHFILE", SqlDbType.NVarChar).Value = MYFOLDER & "\Backup" & Now.ToString("yyyy-MM") & "\" + DBName + "_" + dt + ".dmp"
            CMD.ExecuteNonQuery()
            MessageBox.Show(" „ «‰‘«¡ ‰”ŒÂ «Õ Ì«ÿÌ… „‰ ﬁ«⁄œ… «·»Ì«‰«  «·Õ«·Ì…" & " ›Ï «·„”«— «· «·Ï  " & vbCrLf & vbCrLf & MYFOLDER & "\Backup" & ServerDateTime.ToString("yyyy-MM") & "\" + DBName + dt + ".dmp", "«‰‘«¡ ‰”ŒÂ «Õ Ì«ÿÌÂ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
            ConUsers.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Public Function SumAmounTOTALCASHANDCHEQUES(ByVal cust As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        'On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CAB4-CAB5)  FROM CABLES WHERE CABLES.CUser = '" & CUser & "'" & "AND  Year(CAB3)='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & " and  CAB11='" & cust & "'" & "AND CABLES.IDCAB <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALCASHANDCHEQUES = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALCASHANDCHEQUES = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALCASHANDCHEQUES
    End Function

    Public Function SumAmounTOTALCASHANDCHEQUES1(ByVal cust As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        'On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CAB5-CAB4)  FROM Suppliers1 WHERE Suppliers1.CUser = '" & CUser & "'" & "AND Year(CAB3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & " and CAB11 ='" & cust & "'" & "AND Suppliers1.IDCAB <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALCASHANDCHEQUES1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALCASHANDCHEQUES1 = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALCASHANDCHEQUES1
    End Function

    Public Function SumAmounTOTALCASHANDCHEQUES2(ByVal cust As String, ByVal cust1 As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(TBNK5-TBNK4)  FROM PTRANSACTION WHERE PTRANSACTION.CUser = '" & CUser & "'" & "AND  Year(TBNK3)='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & " and TBNK6 ='" & cust & "'" & "AND PTRANSACTION.TBNK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALCASHANDCHEQUES2 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALCASHANDCHEQUES2 = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALCASHANDCHEQUES2
    End Function

    Public Function SumAmounTOTALBALANCECASHIER(ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        'On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CSH7-CSH8)  FROM CASHIER WHERE CUser = '" & CUser & "'" & "and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & "AND CASHIER.CSH1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1, "CASHIER")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALBALANCECASHIER = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALBALANCECASHIER = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALBALANCECASHIER
    End Function

    Public Function SumAmounTOTALBALANCECASHIER11(ByVal CUserA As Integer, ByVal ComboCB As Integer, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        'On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CSH7-CSH8)  FROM CASHIER WHERE CUser = '" & CUserA & "'" & "and (CASHIER.CSH18)='" & ComboCB & "'" & "AND CASHIER.CSH1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1, "CASHIER")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALBALANCECASHIER11 = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALBALANCECASHIER11 = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALBALANCECASHIER11
    End Function

    Public Function SumAmounTOTALBALANCE(ByVal BN2 As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(BANKJO.EBNK2) AS CurrentBalance, Sum(EBNK4-EBNK5)  FROM BANKJO WHERE CUser = '" & CUser & "'" & "and Year(EBNK3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & "AND  EBNK10 ='" & BN2 & "'" & "AND BANKJO.EBNK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1, "BANKJO")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALBALANCE = Format(Val(ds1.Tables(0).Rows(0).Item(0) + ds1.Tables(0).Rows(0).Item(1)), "0.000")
        Else
            SumAmounTOTALBALANCE = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALBALANCE
    End Function

    Public Function SumAmounTOTALSTOCKS(ByVal cod As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(STK11-STK12) FROM STOCKS WHERE CUser ='" & CUser & "'" & "and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & "AND  STK25 ='" & cod & "'" & " AND STOCKS.STK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALSTOCKS = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALSTOCKS = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALSTOCKS
    End Function

    Public Function SumAmounTOTALSTOCKS1(ByVal cod As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT  STK13, STK15 FROM STOCKS WHERE CUser ='" & CUser & "'" & "and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & "AND STK25 ='" & cod & "'" & " AND STOCKS.STK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALSTOCKS1 = Format(Val(ds1.Tables(0).Rows(0).Item(0)) * Val(ds1.Tables(0).Rows(0).Item(1)), "0.000")
        Else
            SumAmounTOTALSTOCKS1 = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALSTOCKS1
    End Function

    Public Function SumAmounTOTALSTOCKS2(ByVal cod As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT STK13, STK19 FROM STOCKS WHERE CUser ='" & CUser & "'" & "and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & "AND STK25 ='" & cod & "'" & " AND STOCKS.STK1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALSTOCKS2 = Format(Val(ds1.Tables(0).Rows(0).Item(0)) * Val(ds1.Tables(0).Rows(0).Item(1)), "0.000")
        Else
            SumAmounTOTALSTOCKS2 = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALSTOCKS2
    End Function

    Public Function SumAmounTOTALBALANCEEMPSOLF(ByVal cust As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CSH7-CSH8)  FROM EMPSOLF WHERE EMPSOLF.CUser = '" & CUser & "'" & "and Year(CSH2) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'" & "AND CSH15 ='" & cust & "'" & " AND EMPSOLF.CSH1 <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALBALANCEEMPSOLF = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALBALANCEEMPSOLF = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALBALANCEEMPSOLF
    End Function

    Public Function SumAmounTOTALChecks(ByVal cust As String, ByVal num As Integer) As Double
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim strsq1 As New SqlClient.SqlCommand("SELECT Sum(CH5-CH6)  FROM Checks WHERE Checks.CUser = '" & CUser & "'" & "AND CH8 ='" & cust & "'" & " AND Checks.IDCH <='" & num & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1)
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            SumAmounTOTALChecks = Format(Val(ds1.Tables(0).Rows(0).Item(0)), "0.000")
        Else
            SumAmounTOTALChecks = "0"
        End If
        Consum.Close()
        Return SumAmounTOTALChecks
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Function

    Public Function MaxDate() As Date
        'On Error Resume Next
        MaxDate = FiscalYear_currentDateMustBeInFiscalYear() & "-" & ServerDateTime.ToString("MM-dd")
       Return MaxDate
    End Function

<<<<<<< HEAD
    Public Function FiscalYear_currentDateMustBeInFiscalYear() As Integer
        Dim result As Integer = 0
        Dim fiscalYearSetting As String = mykey.GetValue("FiscalYear", "False")
        Dim fiscalYearCombo As Integer = Convert.ToInt32(mykey.GetValue("FiscalYearCOMBO", "0"))

        Try
            Using connection As New SqlConnection(constring)
                Dim query As String = "SELECT Year2, Year3 FROM FiscalYear WHERE CUser=@CUser AND YE1=@YE1"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@CUser", CUser)
                    command.Parameters.AddWithValue("@YE1", True)

                    Dim adapter As New SqlDataAdapter(command)
                    Dim dataSet As New DataSet()

                    connection.Open()
                    adapter.Fill(dataSet, "FiscalYear")

                    If dataSet.Tables("FiscalYear").Rows.Count > 0 Then
                        STarDat = Convert.ToDateTime(dataSet.Tables("FiscalYear").Rows(0).Item("Year2"))
                        If fiscalYearSetting = "True" Then
                            result = Year(STarDat) - fiscalYearCombo
                        Else
                            result = Year(STarDat)
                        End If
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return result
=======
    Public Function FiscalYear_currentDateMustBeInFiscalYear()
        Dim Adp1 As SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim resault16 As String
        resault16 = mykey.GetValue("FiscalYear", "False")
        FY = mykey.GetValue("FiscalYearCOMBO", "0")
        On Error Resume Next
        Dim strsq1 As New SqlClient.SqlCommand("SELECT  Year2, Year3  FROM FiscalYear WHERE CUser='" & CUser & "' and YE1 ='" & True & "'", Consum)
        Dim ds1 As New DataSet
        Adp1 = New SqlClient.SqlDataAdapter(strsq1)
        ds1.Clear()
        Consum.Open()
        Adp1.Fill(ds1, "FiscalYear")
        Adp1.Dispose()
        If ds1.Tables(0).Rows.Count > 0 Then
            STarDat = ds1.Tables(0).Rows(0).Item(0)
            If resault16 = "True" Then
                FiscalYear_currentDateMustBeInFiscalYear = Year(STarDat) - FY
            Else
                FiscalYear_currentDateMustBeInFiscalYear = Year(STarDat)
            End If
        End If
        Consum.Close()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    End Function

    Public Function MyResultDate(ByVal mydate1 As Date, ByVal mydate2 As Date) As String
        Dim d1, d2, m1, m2, y1, y2, r1, r2, r3 As Integer
        Try


            d1 = mydate1.Day
            d2 = mydate2.Day
            m1 = mydate1.Month
            m2 = mydate2.Month
            y1 = mydate1.Year
            y2 = mydate2.Year
            If d1 < d2 Then
                Dim DayCt As Short
                DayCt = DateTime.DaysInMonth(y1, m1)
                d1 += DayCt
                m1 -= 1
            End If
            If m1 < m2 Then
                m1 += 12
                y1 -= 1
            End If
            r1 = d1 - d2
            r2 = m1 - m2
            r3 = y1 - y2

            Result = Nothing
            If r3 >= 1 Then
                If r3 > 10 Then YearCount = r3.ToString & " ”‰… "
                If r3 <= 10 Then YearCount = r3.ToString & " ”‰Ê«  "
                If r3 = 2 Then YearCount = " ”‰ «‰ "
                If r3 = 1 Then YearCount = " ”‰… Ê«Õœ… "
                Result = YearCount
            End If

            If r2 >= 1 Then

                If r2 > 10 Then MonthCount = r2.ToString & "  ‘Â—  "
                If r2 <= 10 Then MonthCount = r2.ToString & " √‘Â—  "
                If r2 = 2 Then MonthCount = " ‘Â—«‰  "
                If r2 = 1 Then MonthCount = " ‘Â— Ê«Õœ   "
                If MonthCount <> "" AndAlso r3 >= 1 Then
                    Result += " , "
                End If
                Result += MonthCount
            End If

            If r1 >= 1 Then
                If r1 > 10 Then DayCount = r1.ToString & " ÌÊ„ "
                If r1 <= 10 Then DayCount = r1.ToString & " √Ì«„ "
                If r1 = 2 Then DayCount = " ÌÊ„«‰ "
                If r1 = 1 Then DayCount = " ÌÊ„ Ê«Õœ "
                If DayCount <> "" AndAlso r2 >= 1 Then
                    Result += " , "
                End If
                Result += DayCount
            End If
            MyResultDate = Result


        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
            Return Result
        End Try
    End Function
    ' Step 1
    ' ⁄‰œ «·÷€ÿ ⁄·Ï Right Click ”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï √Ì „·›
    Public Sub Substar()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x = x.OpenSubKey("*\shell", True)
        x.CreateSubKey("CC_JO\command")
        x.Close()
    End Sub
    ' Step 2
    ' ⁄‰œ «·÷€ÿ ⁄·Ï Right Click ”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï √Ì „Ã·œ Ê⁄·Ï √Ì ”Ê«ﬁ… Drivers
    ' Ê”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï Recycle Bin
    Public Sub SubFolder()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x = x.OpenSubKey("Folder\shell", True)
        x.CreateSubKey("CC_JO\command")
        x.Close()
    End Sub
    ' Step 3
    ' ⁄‰œ «·÷€ÿ ⁄·Ï Right Click ”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï √Ì „Ã·œ
    Public Sub SubDirectory()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x = x.OpenSubKey("Directory\shell", True)
        x.CreateSubKey("CC_JO\command")
        x.Close()
    End Sub
    ' Step 4
    ' ⁄‰œ «·÷€ÿ ⁄·Ï Right Click ”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï √Ì „·›
    Public Sub ValueStar()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x = x.OpenSubKey("*\shell\CC_JO\command", True)
        x.SetValue("", "c:\windows\system32\CC_JO.exe")
        x.Close()
    End Sub
    ' Step 5
    ' ⁄‰œ «·÷€ÿ ⁄·Ï Right Click ”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï √Ì „Ã·œ Ê⁄·Ï √Ì ”Ê«ﬁ… Drivers
    ' Ê”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï Recycle Bin
    Public Sub ValueFolder()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x = x.OpenSubKey("Folder\shell\CC_JO\command", True)
        x.SetValue("", "c:\windows\system32\CC_JO.exe")
        x.Close()
    End Sub
    ' Step 6
    ' ⁄‰œ «·÷€ÿ ⁄·Ï Right Click ”Ê› ÌŸÂ— «·»—‰«„Ã ⁄·Ï √Ì „Ã·œ
    Public Sub ValueDirectory()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x = x.OpenSubKey("Directory\shell\CC_JO\command", True)
        x.SetValue("", "c:\windows\system32\CC_JO.exe")
        x.Close()
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Sub DelValueStar()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x.DeleteValue("*\shell\CC_JO\command")
        x.DeleteSubKeyTree("*\shell\CC_JO")
        x.Close()
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Sub DelValueFolder()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x.DeleteValue("Folder\shell\CC_JO\command")
        x.DeleteSubKeyTree("Folder\shell\CC_JO")
        x.Close()
    End Sub
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Public Sub DelValueDirectory()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x.DeleteValue("Directory\shell\CC_JO\command")
        x.DeleteSubKeyTree("Directory\shell\CC_JO")
        x.Close()
    End Sub

    Function InternetGetConnectedState() As Boolean
        Dim avocatoConnType As String = 255
        Dim avocato As Integer
        avocato = InternetGetConnectedStateEx(avocato, avocatoConnType, 254, 0)
        If avocato = 1 Then
            InternetGetConnectedState = True
        Else
            InternetGetConnectedState = False
            MsgBox("«‰  €Ì— „ ’· »«·«‰ —‰  Õ«·Ì«", vbInformation)
        End If
    End Function

    Public Structure DevMode
<<<<<<< HEAD
        <VBFixedString(32), Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public dmDeviceName As String
=======
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public dmDeviceName As String
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim dmSpecVersion As Short
        Dim dmDriverVersion As Short
        Dim dmSize As Short
        Dim dmDriverExtra As Short
        Dim dmFields As Integer
        Dim dmOrientation As Short
        Dim dmPaperSize As Short
        Dim dmPaperLength As Short
        Dim dmPaperWidth As Short
        Dim dmScale As Short
        Dim dmCopies As Short
        Dim dmDefaultSource As Short
        Dim dmPrintQuality As Short
        Dim dmColor As Short
        Dim dmDuplex As Short
        Dim dmYResolution As Short
        Dim dmTTOption As Short
        Dim dmCollate As Short
<<<<<<< HEAD
        <VBFixedString(32), Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public dmFormName As String
=======
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public dmFormName As String
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Dim dmLogPixels As Short
        Dim dmBitsPerPel As Integer
        Dim dmPelsWidth As Integer
        Dim dmPelsHeight As Integer
        Dim dmDisplayFlags As Integer
        Dim dmDisplayFrequency As Integer
        Dim dmICMMethod As Integer ' Windows 95 only
        Dim dmICMIntent As Integer ' Windows 95 only
        Dim dmMediaType As Integer ' Windows 95 only
        Dim dmDitherType As Integer ' Windows 95 only
        Dim dmICCManufacturer As Integer ' Windows 95 only
        Dim dmICCModel As Integer ' Windows 95 only
        Dim dmPanningWidth As Integer ' Windows 95 only
        Dim dmPanningHeight As Integer ' Windows 95 only
    End Structure

End Module


