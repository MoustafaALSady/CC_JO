
Imports Microsoft.Win32

Public Class FormRegistryKey
    'Dim RegKeysFind() As String = {"Computer\HKEY_CURRENT_USER\software \ co \ Accounts", "Computer\HKEY_CURRENT_USER\software \ co \ Accounts"}
    ReadOnly RegKeysFind() As String = {"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall",
                               "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall"}
    Private ReadOnly SavingAccount As String

    Private Sub FormRegistryKey_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim dTableApps As DataTable = New DataTable()
        'With dTableApps
        '    .Columns.Add("Aplicacao", GetType(String))
        '    .Columns.Add("Versao", GetType(String))
        '    .Columns.Add("Fabricante", GetType(String))
        '    .Columns.Add("x64", GetType(String))
        '    .Columns.Add("RegKey", GetType(String))
        'End With
        'For Each RegKeyString As String In RegKeysFind
        '    Try
        '        Using RegKey As RegistryKey = Registry.LocalMachine.OpenSubKey(RegKeyString, RegistryKeyPermissionCheck.ReadSubTree, Security.AccessControl.RegistryRights.ReadKey)
        '            For Each SubRegKey As String In RegKey.GetSubKeyNames
        '                If SubRegKey IsNot Nothing Then
        '                    Dim DisplayName, DisplayVersion, InstallLocation, Publisher, SystemComponent, ReleaseType As String
        '                    With RegKey.OpenSubKey(SubRegKey)
        '                        DisplayName = If(.GetValue("DisplayName") IsNot Nothing, .GetValue("DisplayName").ToString, "")
        '                        DisplayVersion = If(.GetValue("DisplayVersion") IsNot Nothing, .GetValue("DisplayVersion").ToString, "")
        '                        If DisplayVersion IsNot Nothing Then
        '                            Dim FirstWhiteChar As Integer = DisplayVersion.IndexOf(" "c)
        '                            If FirstWhiteChar > -1 Then
        '                                DisplayVersion = DisplayVersion.Substring(0, FirstWhiteChar)
        '                            End If
        '                        End If
        '                        InstallLocation = If(.GetValue("InstallLocation") IsNot Nothing, .GetValue("InstallLocation").ToString, "")
        '                        Publisher = If(.GetValue("Publisher") IsNot Nothing, .GetValue("Publisher").ToString, "")
        '                        SystemComponent = If(.GetValue("SystemComponent") IsNot Nothing, .GetValue("SystemComponent").ToString, "")
        '                        ReleaseType = If(.GetValue("ReleaseType") IsNot Nothing, .GetValue("ReleaseType").ToString, "")
        '                        If (Not String.IsNullOrEmpty(DisplayName) AndAlso (Not String.IsNullOrEmpty(SystemComponent) AndAlso (ReleaseType <> "update"))) Then
        '                            dTableApps.Rows.Add({DisplayName, DisplayVersion, Publisher, If(RegKeyString.Contains("WOW6432Node"), "32", "64") & " bits", SubRegKey})
        '                        End If
        '                    End With
        '                End If
        '            Next
        '        End Using
        '    Catch ex As Exception
        '        Console.WriteLine(ex.Message)
        '        Throw
        '    End Try
        'Next

        'dTableApps.DefaultView.Sort = dTableApps.Columns(0).ColumnName & " Asc"
        '

        Dim keyAccounts As RegistryKey = Registry.CurrentUser.CreateSubKey("software \ co \ Accounts")
        Dim dTableApps As New DataTable()
        With dTableApps
            .Columns.Add("Accounts", GetType(String))
            '.Columns.Add("Account_Name", GetType(String))
        End With
        Dim StockAccount As String
        For Each ValueName As String In keyAccounts.GetValueNames()
            Dim Value As Object = keyAccounts.GetValue(ValueName) 'Get the value (data) of the specified value name.
            GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", Value, 1)
            StockAccount = ID_Nam
            If Value IsNot Nothing Then 'Make sure it exists.

                dTableApps.Rows.Add(Value.ToString())
                'dTableApps.Rows.Add({Value.ToString()})
                ListBox1.Items.Add(StockAccount.ToString())
                '
                'dTableApps.Rows.Add(StockAccount)
            End If
        Next
        DataGridView1.DataSource = dTableApps
        keyAccounts.Close()



    End Sub


    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged


    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'Dim StockAccount As String
        'Dim a As Integer
        'On Error Resume Next
        'For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1

        '    Dim celV1 As DataGridViewTextBoxCell = DataGridView1.Rows(i).Cells(0)
        '    a = Val(Me.DataGridView1.Item("Accounts", Me.DataGridView1.CurrentRow.Index).Value())
        '    GetNoRecord("ACCOUNTSTREE", "Account_Name", "Account_No", a, 1)
        '    StockAccount = ID_Nam
        '    Me.DataGridView1.CurrentRow.Cells("acc").Value = StockAccount

        'Next
    End Sub
End Class