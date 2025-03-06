Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports CC_JO.My.Resources

Public Class VersionCheckDatabase
    Enum VersionCheck
        Failed = 0
        Equal
        DatabaseIsMoreNew
        DatabaseIsOlder
        DatabaseNotFound
        TableNotFound
    End Enum
    Private sqlCmd As New SqlCommand()

<<<<<<< HEAD
    Private Sub VersionCheckDatabase_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub VersionCheckDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If SetupDatabase() = False Then
            Return
        End If
        PopulateGrid()
    End Sub

    Public Function SetupDatabase() As Boolean
        Dim bContinue As Boolean = False

        Try
            'Consum.ConnectionString = "Server=.;Integrated Security=true"
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
                Exit Select
            Case CInt(VersionCheck.DatabaseIsMoreNew)
                bContinue = False
                Exit Select
            Case CInt(VersionCheck.DatabaseNotFound)
                bContinue = RunScript(Resource1.CreateClientDataBase.ToString())
                Exit Select
            Case CInt(VersionCheck.TableNotFound)
                bContinue = RunScript(Resource1.CREATE_TABLE_AppInfo.ToString())
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
            sqlCmd = New SqlCommand("select count(*) from master..sysdatabases where name='DB_A3F994_co'", Consum)
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
    Public Shared Function ParseScriptToCommands(ByVal strScript As String) As String()
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
    ''' <summary>
    ''' تعبئة القريد بالبيانات من القاعدة بعد انشائها
    ''' </summary>
    Public Sub PopulateGrid()
        Dim strCmd As String = "Select * from [DB_A3F994_co].[dbo].[AppInfo]"
        Dim da As SqlDataAdapter
        da = New SqlDataAdapter(strCmd, Consum)

        Dim ds As New DataSet
        da.Fill(ds, "AppInfo")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "AppInfo"
    End Sub

End Class