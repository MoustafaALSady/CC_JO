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

    'Public InternalAuditor1 As Boolean = False
    'Public CollaborationManager1 As Boolean = False
    'Public HeadofAuditingDepartment1 As Boolean = False
    'Public ExternalAuditor1 As Boolean = False

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

    Public Sub AutoComplete(ByRef cb As ComboBox, ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional ByVal blnLimitToList As Boolean = False)
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
            If ServerConnection = True Then
                constring = "Data Source=" + ServerName + "," + PORT + ";Initial Catalog= " + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
            Else
                If AuthenicationSQLServer = True Then
                    constring = "Data Source=" + ServerName + ";Initial Catalog=" + DBServer + ";User Id=" + userIDName + ";Password=" + BWS1 + ";"
                Else
                    constring = "Data Source =" + ServerName + ";Initial Catalog=" + DBServer + ";Integrated Security=True"
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Function GetSql(ByVal Name As String, ByVal TypeFileIncludeexe As Boolean) As String
        Try
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
        End Try
    End Sub

    Public Function GETATTACHDATABASENAME(ByVal db As String) As Boolean
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
    End Sub

    Public Sub GetNoRecord(ByVal TABLE As String, ByVal FIELD As String, ByVal FIELD1 As String, ByVal TXT As String, ByVal TXT1 As Integer)
        Dim SavInto As New SqlCommand
        Dim Consum As New SqlClient.SqlConnection(constring)
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
    End Function

    Public Function MaxDate() As Date
        'On Error Resume Next
        MaxDate = FiscalYear_currentDateMustBeInFiscalYear() & "-" & ServerDateTime.ToString("MM-dd")
       Return MaxDate
    End Function

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
    Public Sub DelValueStar()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x.DeleteValue("*\shell\CC_JO\command")
        x.DeleteSubKeyTree("*\shell\CC_JO")
        x.Close()
    End Sub
    Public Sub DelValueFolder()
        On Error Resume Next
        Dim x As RegistryKey
        x = Registry.ClassesRoot
        x.DeleteValue("Folder\shell\CC_JO\command")
        x.DeleteSubKeyTree("Folder\shell\CC_JO")
        x.Close()
    End Sub
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
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public dmDeviceName As String
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
        <VBFixedString(32), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=32)> Public dmFormName As String
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


