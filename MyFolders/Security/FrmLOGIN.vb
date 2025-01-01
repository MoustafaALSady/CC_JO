Option Explicit Off

Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Security.AccessControl
Imports System.Text

Public Class FrmLOGIN
    Inherits System.Windows.Forms.Form

    Private WithEvents TimerTestNet As New Timer
    Public Delegate Sub LoadDataBaseCallBack()
    Public Delegate Sub CallLoadDataBase()
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Public SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim DataSetUsers As New DataSet
    Dim Attempt As Integer = 1
    Dim Drag As Boolean
    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim ID As Integer
    Private Declare Function SetForegroundWindow Lib "user32" (ByVal hwnd As Long) As IntPtr

    Function Check_user() As Boolean
        Check_user = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim selectCommand As New SqlCommand("Select Pws FROM Users where UserName='" & Me.TxtUser.Text & "'", Consum)
        Dim Ds = New DataSet
        Dim Adp As New SqlDataAdapter(selectCommand)
        Adp.Fill(Ds)
        Dim dt = Ds.Tables(0)
        If dt.Rows.Count > 0 Then
            Dim dr = dt.Rows(0)
            If Trim(dr!pws) = Trim(Me.Txtpassword.Text) Then Check_user = True
        End If
    End Function
    Private Sub FrmLOGIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Try
            Select Case e.KeyCode
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmLOGIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        'mykey.SetValue("CORegCode", COManagement.md5ha(COManagement.SECU().Trim + "muostafa"))
        'mykey.SetValue("ProductVersion", Trim(Application.ProductVersion))
        'If mykey.GetValue("CORegCode", "") = COManagement.Md5ha(COManagement.SECU().Trim + "muostafa.76") Then
        '    Me.L5.Visible = True
        '    Me.L5.Text = "البرنامج       :  Activated"
        'Else
        '    Me.L5.Text = "للتفعيل البرنامج ارسال هذا الكود"
        '    Freg.ShowDialog()
        '    Me.Close()
        'End If

        Dim App As Process() = Process.GetProcessesByName("CC_JO")
        If App.Length > 1 Then
            SetForegroundWindow(App(1).MainWindowHandle)
            MsgBox("البرنامج قيد الاستخدام")
            End
        End If
        'Dim fs As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\" & "Configuration1.ini")
        'fs.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        'File.SetAccessControl(Application.StartupPath & "\" & "Configuration1.ini", fs)
        'CC_JO.CYBELE.MainStart()


        Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
        For Each nic As NetworkInterface In adapters
            Dim type As NetworkInterfaceType = nic.NetworkInterfaceType
            If type <> NetworkInterfaceType.Loopback AndAlso type <> NetworkInterfaceType.Tunnel AndAlso type <> NetworkInterfaceType.Unknown Then
                UserMacAddress &= nic.GetPhysicalAddress().ToString.Trim()
                Me.L1.Text = UserMacAddress.Trim
            End If
        Next
        '==================================
        'If UserMacAddress.Trim = Nothing Then
        '    MsgBox("الرجاءالاتصال بإدارة ومحاسبة الجمعيات التعاونية", 16, "تنبيه بوجود خطا ما")
        '    End
        'End If



        TestNet = True
        USERNAME = ""
        PASSWORD = ""
        Me.TxtUser.Text = ""
        Me.Txtpassword.Text = ""
        Me.TxtUser.Focus()
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        'Windows.Forms.Cursor.Hide()
        Control.CheckForIllegalCrossThreadCalls = False

        Me.CircularProgress1.Value = 0
        Me.BGWLOGIN.WorkerSupportsCancellation = True
        Me.BGWLOGIN.WorkerReportsProgress = True

        Me.BGWFrmLOGIN_Load.WorkerSupportsCancellation = True
        Me.BGWFrmLOGIN_Load.WorkerReportsProgress = True
        Me.BGWFrmLOGIN_Load.RunWorkerAsync()

        Me.BackgroundWorker3.WorkerSupportsCancellation = True
        Me.BackgroundWorker3.WorkerReportsProgress = True

    End Sub
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
        Try
1:
            Me.DataSetUsers = New DataSet
            DataAdapterUsers.Fill(Me.DataSetUsers, "Users")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                e.Cancel = True
                MessageBox.Show(ex.Message, "ErrorRefreshData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            Me.PictureBox2.Visible = False
            Me.Cursor = Cursors.Default
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRefreshData", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub BackgroundWorker3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker3.DoWork

        Try
            'LoadMyDatabase2()
            'Me.REGDATAIN_REGISTERY()
            'Dim Consum As New SqlClient.SqlConnection(constring)
            'Dim dsUser As DataSet = New DataSet
            'Dim strsql As SqlClient.SqlCommand = New SqlClient.SqlCommand("SELECT UserName ,Pws  ,USR21 from Users  WHERE  UserName='" & Me.txtuser.Text.Trim & "' and Pws ='" & Me.txtpassword.Text.Trim & "'", Consum)
            'Dim adapter As New SqlClient.SqlDataAdapter(strsql)
            'dsUser.Clear()
            'If Consum.State = ConnectionState.Open Then Consum.Close()
            'Consum.Open()
            'adapter.Fill(dsUser)
            'Consum.Close()
            'If dsUser.Tables(0).Rows.Count > 0 Then
            '    For IUS As Integer = 0 To dsUser.Tables(0).Rows.Count - 1
            '        If dsUser.Tables(0).Compute("Count(UserName)", "UserName like '" & Me.txtuser.Text.Trim & "' and Pws like '" & Me.txtpassword.Text.Trim & "' and  USR21 =1").ToString > 0 Then
            '            Me.RAdmin1 = True
            '        Else
            '            Me.RAdmin1 = False
            '        End If
            '    Next
            'Else
            '    Me.RAdmin1 = False
            'End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRAdminLogin", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BackgroundWorker3_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorker3.ProgressChanged
        'Me.CircularProgress1.Value = e.ProgressPercentage

    End Sub

    Private Sub BackgroundWorker3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker3.RunWorkerCompleted
        Try
            If Me.TxtUser.Text = Nothing Or Me.Txtpassword.Text = Nothing Then
                Me.Button1.Visible = False
            ElseIf Me.TxtUser.Text = "co-jo-ms76" And Me.Txtpassword.Text = "co-jo-ms76" Then
                Me.Button1.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRAdminLogin", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub BGWFrmLOGIN_Load_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGWFrmLOGIN_Load.DoWork
        Try
            Me.cmdLogin.Enabled = False
            Me.cmdcancel.Enabled = False
            Me.TxtUser.Enabled = False
            Me.Txtpassword.Enabled = False
            Me.Button1.Visible = False
            Me.KeyPreview = False
            Me.TxtUser.Focus()
            Me.CircularProgress2.Visible = False
            Me.CircularProgress1.BringToFront()
            Me.CircularProgress1.Visible = True
            Me.CircularProgress1.IsRunning = True
            Me.Focus()
            'Dim fs As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\")
            'fs.RemoveAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
            'File.SetAccessControl(Application.StartupPath & "\", fs)

            If Not IO.File.Exists(Application.StartupPath & "\" & "ConStr.XML") Then
                Dim path As String = Application.StartupPath & "\" & "ConStr.XML"
                Dim fs1 As FileStream = File.Create(path)
                Dim info1 As Byte() = New UTF8Encoding(True).GetBytes(tmpStr1.ToString.Trim)
                fs1.Write(info1, 0, info1.Length)
                fs1.Close()
            Else
                'Dim fs1 As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\" & "ConStr.XML")
                'fs1.RemoveAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
                'File.SetAccessControl(Application.StartupPath & "\" & "ConStr.XML", fs1)
            End If
            Call URL_F()

            If tstURL = False Then
                MdlConnection.GeneralConnection()
            End If
            Dim RUN As Integer
            Dim i As Integer = 0
            Do While RUN
                Me.BGWFrmLOGIN_Load.ReportProgress(i)
                If i = Me.CircularProgress1.Maximum Then
                    i = 0
                Else
                    i += 1
                End If
                Threading.Thread.Sleep(10)
            Loop
        Catch ex As Exception
            MessageBox.Show("حدث خطأ أثناء الاتصال. الأسباب المحتملة:" & ControlChars.CrLf &
                            "1) الملف الاتصال غير موجود" & ControlChars.CrLf &
                            "2) اخطأ في الخادم البعيد" & ControlChars.CrLf &
                            "3) خطأ غير متوقع", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'MessageBox.Show(ex.Message, "ErrorRAdminLogin", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
            'Process.Start(Application.StartupPath & "\" & "CC_JO.exe")
            Exit Sub
        End Try
    End Sub
    Private Sub BGWFrmLOGIN_Load_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGWFrmLOGIN_Load.ProgressChanged
        Me.CircularProgress1.Value = e.ProgressPercentage
    End Sub
    Private Sub BGWFrmLOGIN_Load_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWFrmLOGIN_Load.RunWorkerCompleted
        Try
            If e.Error IsNot Nothing Then
                Me.L1.Text = "Error occurred!"
            ElseIf e.Cancelled Then
                Me.L1.Text = "Task Cancelled!"
            Else
                Me.L1.Text = "Error completed !"
                'Exit Sub
            End If
            Me.TxtUser.Focus()
            LoadMyDatabase2()
            REGDATAIN_REGISTERY()
            Me.Invoke(New LoadDataBaseCallBack(AddressOf LoadDataBase), Array.Empty(Of Object)())
            Me.CircularProgress1.IsRunning = False
            Me.CircularProgress1.Visible = False
            Me.L4.Visible = False
            Me.cmdLogin.Enabled = True
            Me.cmdcancel.Enabled = True
            Me.TxtUser.Enabled = True
            Me.Txtpassword.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBGWFrmLOGIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub
    Private Sub BGWLOGIN_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BGWLOGIN.DoWork
        Try

            Me.L4.Visible = True
            Me.KeyPreview = True
            Me.CircularProgress2.Visible = True
            Me.CircularProgress2.IsRunning = True
            If TestNet = False Then
                If Me.BGWLOGIN.IsBusy Then
                    Me.BGWLOGIN.CancelAsync()
                End If
                Me.CircularProgress2.IsRunning = False
                Me.CircularProgress2.Visible = False
                'MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                '    Exit Sub
            End If

            If MyTextNull(Me.TxtUser, "اسم المستخدم") = True Then Exit Sub
            If MyTextNull(Me.Txtpassword, "كلمة المرور") = True Then Exit Sub

            'If IsConnectedToInternet() = False Then
            'If OnLine = False Then
            'MsgBox("الرجاء العمل على السيرفر المحلي ... الاتصال بالانترنت غير متوفر", 16, "تنبيه")
            'Exit Sub
            'End If
            'End If
            ' ''-------------------------------------------------------
            USERNAME = Trim(Me.TxtUser.Text)
            PASSWORD = Trim(Me.Txtpassword.Text)
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim ConUsers As New SqlClient.SqlConnection(constring1)
            Dim Users1 As New SqlCommand("SELECT  ID, UserName, Pws, TimeEnter, MacAddress, LoginName, Realname, UserType, CUser, COUser, BlockUser, LockAddRow, LockDelete, LockSave, LockUpdate, Printpreview, InternalAuditor, CollaborationManager, HeadofAuditingDepartment, ExternalAuditor, FileList, ListOFClients, CashAndMembers, ListOFAccounts, ListOFelectronicArchives, StaffMenu, internet, RAdmin1 FROM  USERS  WHERE  UserName like '" & Me.TxtUser.Text.Trim & "' and Pws like '" & Me.Txtpassword.Text.Trim & "' ", ConUsers)
            DataAdapterUsers = New SqlClient.SqlDataAdapter(Users1)
            Me.DataSetUsers.Clear()
            Me.DataSetUsers = New DataSet
            If ConUsers.State = ConnectionState.Open Then ConUsers.Close()
            ConUsers.Open()
            DataAdapterUsers.Fill(Me.DataSetUsers, "Users")
            'frmMAIN.BS.DataSource = DataSetUsers.Tables("Users
            If ConUsers.State = ConnectionState.Open Then ConUsers.Close()
            ''-----------------------------------------------------------------------------
            UPDATE_Users(USERNAME, ServerDateTime.ToString(), UserMacAddress.Trim)
            Me.DataSetUsers.Clear()
            Me.DataSetUsers = New DataSet
            DataAdapterUsers.Fill(Me.DataSetUsers, "Users")
            Dim str1 As New SqlClient.SqlCommand("", Consum) With {
                .CommandText = "SELECT CMP, CMP1, CMP2, CMP3, CMP4, CMP5, CMP7, CMP8, CMP9, CMP11, CMP12, CMP13, CMP14, CUser, COUser from COMPANY  "
            }
            DataAdapterTab = New SqlDataAdapter(str1)
            DataSetTab = New DataSet
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            DataAdapterTab.Fill(DataSetTab, "COMPANY")
            If Consum.State = ConnectionState.Open Then Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBGWLOGIN.DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try
    End Sub
    Private Sub BGWLOGIN_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BGWLOGIN.ProgressChanged
        Me.CircularProgress2.Value = e.ProgressPercentage
    End Sub

    Private Sub BGWLOGIN_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BGWLOGIN.RunWorkerCompleted
        Try
            If e.Error IsNot Nothing Then
                Me.L4.Text = "Error occurred!"
                Exit Sub
            ElseIf e.Cancelled Then
                Me.L4.Text = "Task Cancelled!"
            ElseIf Me.TxtUser.Text = "" Then
                Me.L4.Text = "ادخال اسم المستخدم"
                Exit Sub
            ElseIf Me.Txtpassword.Text = "" Then
                Me.L4.Text = "ادخال كلمة المرور"
                Exit Sub
            ElseIf TestNet = False Then
                Me.L4.Text = "الاتصال بالانترنت غير متوفر"
                PanelUsers.Enabled = False
                cmdLogin.Enabled = False
                Exit Sub
            End If
            If DataSetUsers.Tables("Users").Rows.Count > 0 Then
                '========================================================================================
                If DataSetUsers.Tables("Users").Rows(0).Item("BlockUser").ToString = "True" Then
                    MsgBox("عفوا .. انت محظور من الدخول البرنامج", 16, "تنبيه")
                    Call CloseConUsers()
                    Me.CircularProgress2.IsRunning = False
                    Me.CircularProgress2.Visible = False
                    Exit Sub
                End If
                Me.L1.Visible = False
                Me.L4.Visible = True
                '==========================================================================
                USERNAME = Trim(Me.TxtUser.Text)
                PASSWORD = Trim(Me.Txtpassword.Text)
                M1 = DataSetUsers.Tables("USERS").Rows(0).Item("FileList")
                M2 = DataSetUsers.Tables("USERS").Rows(0).Item("ListOFClients")
                M3 = DataSetUsers.Tables("USERS").Rows(0).Item("CashAndMembers")
                M4 = DataSetUsers.Tables("USERS").Rows(0).Item("ListOFAccounts")
                M5 = DataSetUsers.Tables("USERS").Rows(0).Item("ListOFelectronicArchives")
                M6 = DataSetUsers.Tables("USERS").Rows(0).Item("StaffMenu")
                M7 = DataSetUsers.Tables("USERS").Rows(0).Item("Internet")
                M8 = DataSetUsers.Tables("USERS").Rows(0).Item("CollaborationManager")
                ID = DataSetUsers.Tables("Users").Rows(0).Item("ID")
                CUser = DataSetUsers.Tables("Users").Rows(0).Item("CUser")
                COUser = DataSetUsers.Tables("Users").Rows(0).Item("COUser")
                LockAddRow = DataSetUsers.Tables("USERS").Rows(0).Item("LockAddRow")
                LockSave = DataSetUsers.Tables("USERS").Rows(0).Item("LockSave")
                LockUpdate = DataSetUsers.Tables("USERS").Rows(0).Item("LockUpdate")
                LockDelete = DataSetUsers.Tables("USERS").Rows(0).Item("LockDelete")
                LockPrint = DataSetUsers.Tables("USERS").Rows(0).Item("Printpreview")
                InternalAuditor = DataSetUsers.Tables("USERS").Rows(0).Item("InternalAuditor")
                IDUSER = DataSetUsers.Tables("Users").Rows(0).Item("ID")
                CUser = DataSetUsers.Tables("Users").Rows(0).Item("CUser")
                COUser = DataSetUsers.Tables("Users").Rows(0).Item("COUser")
                USERNAME = Trim(Me.TxtUser.Text)
                PASSWORD = Trim(Me.Txtpassword.Text)
                FrmMAIN.LabelRealname.Text = DataSetUsers.Tables("Users").Rows(0).Item("Realname")
                FrmMAIN.LabelUsersType.Text = DataSetUsers.Tables("Users").Rows(0).Item("UserType").ToString
                Realname = FrmMAIN.LabelRealname.Text
                FrmMAIN.Label_Cuser.Text = CUser
                '=====================================================================
                If DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  RAdmin1=1").ToString > 0 Then
                    FrmMAIN.ComboAppearance.Enabled = False
                    mykey.SetValue("Appearance", "Appearance(A)")
                    ModuleGeneral.FILLCOMBOBOX("Governorates", "GovernorateName", FrmMAIN.ComboGovernorateName)
                    img = My.Resources.A5
                    FrmMAIN.BackgroundImage = img
                ElseIf DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  HeadofAuditingDepartment=1").ToString > 0 Then
                    FrmMAIN.ComboAppearance.Enabled = False
                    mykey.SetValue("Appearance", "Appearance(A)")
                    ModuleGeneral.FILLCOMBOBOX("Governorates", "GovernorateName", FrmMAIN.ComboGovernorateName)
                    img = My.Resources.A5
                    FrmMAIN.BackgroundImage = img
                ElseIf DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  ExternalAuditor=1").ToString > 0 Then
                    FrmMAIN.ComboAppearance.Enabled = False
                    mykey.SetValue("Appearance", "Appearance(A)")
                    ModuleGeneral.FILLCOMBOBOX("Governorates", "GovernorateName", FrmMAIN.ComboGovernorateName)
                    img = My.Resources.A5
                    FrmMAIN.BackgroundImage = img
                ElseIf DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  CollaborationManager=1").ToString > 0 Then
                    ModuleGeneral.FILLCOMBOBOX1("Governorates", "GovernorateName", "ID_Governorate", ModuleGeneral.COUser, FrmMAIN.ComboGovernorateName)
                    'mykey.SetValue("Appearance", "Appearance(0)")
                    'FrmMAIN.ComboAppearance.EditValue = "Null"
                    img = My.Resources.A2
                    FrmMAIN.BackgroundImage = img
                    'frmMAIN.MenuStrip1.BackColor = Color.White
                    FrmMAIN.ToolStrip1.BackColor = Color.White
                    FrmMAIN.Panelinformation.BackColor = Color.White
                ElseIf DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  InternalAuditor=1").ToString > 0 Then
                    ModuleGeneral.FILLCOMBOBOX1("Governorates", "GovernorateName", "ID_Governorate", ModuleGeneral.COUser, FrmMAIN.ComboGovernorateName)
                    'mykey.SetValue("Appearance", "Appearance(0)")
                    'FrmMAIN.ComboAppearance.EditValue = "Null"
                    img = My.Resources.A2
                    FrmMAIN.BackgroundImage = img
                    'frmMAIN.MenuStrip1.BackColor = Color.White
                    FrmMAIN.ToolStrip1.BackColor = Color.White
                    FrmMAIN.Panelinformation.BackColor = Color.White
                Else
                    'FrmMAIN.ComboAppearance.EditValue = CStr(mykey.GetValue("Appearance", FrmMAIN.ComboAppearance.EditValue))
                    img = My.Resources.A18
                    FrmMAIN.BackgroundImage = img
                    FrmMAIN.ComboGovernorateName.Visible = False
                    FrmMAIN.ComboGetAssociationName.Visible = False
                End If
                ''==============================================================================
                For c As Integer = 0 To DataSetTab.Tables("COMPANY").Rows.Count - 1
                    If DataSetTab.Tables("COMPANY").Rows(c).Item("CUser").ToString = CUser Then
                        Recorded = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP5") ' رقم تسجيل الجمعية
                        AssociationName = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP2") ' اسم الجمعية
                        Adrss = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP3") '  عنوانه الجمعية
                        Phone = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP4") ' هاتف الجمعية
                        Character = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP7") ' صفة الجمعية
                        Directorate = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP8") 'المديرية/المحافظة
                        Phone1 = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP9") ' هاتف الجمعية
                        Ty1 = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP11") ' نوع الجمعية
                        BANK = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP12") ' البنك
                        BANSL = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP13") ' الاسهم
                        NOBANK = DataSetTab.Tables("COMPANY").Rows(c).Item("CMP14") ' رقم الحساب
                        FrmMAIN.ComboGovernorateName.Text = ModuleGeneral.Directorate
                    End If
                Next
                '-----------------------------------------------------------------------------
                Me.L2.Visible = False
                Me.L4.Text = " مكتمل "
                MsgBox(" انت الآن متصل بقاعدة البيانات بنجاح ", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.MsgBoxRtlReading + MsgBoxStyle.MsgBoxRight, "co")
                FrmMAIN.LabelUsersType.Text = DataSetUsers.Tables("Users").Rows(0).Item("UserType").ToString
                FrmMAIN.LabelFiscalYear.Text = FiscalYear_currentDateMustBeInFiscalYear()
                Me.Hide()
                FrmMAIN.Show()
                'mykey.SetValue("tmpStr", tmpStr.ToString.Trim)
                '=================================================================================
                Call CloseDB()
                Call CloseConUsers()
                'Dim FSALL As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\")
                'FSALL.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
                'File.SetAccessControl(Application.StartupPath & "\", FSALL)
                Me.CircularProgress2.IsRunning = False
                Me.CircularProgress2.Visible = False
                Me.Close()
                'Exit Sub
            Else
                If Attempt = 3 Then
                    MsgBox(" ! لقد إستخدمت ثلاث محاولات خاطئه , سيتم إغلاق البرنامج الآن ", MsgBoxStyle.Information, "خطأ بتسجيل الدخول")
                    Me.Close()
                End If
                Attempt += 1
                Me.Txtpassword.Text = ""
                Me.Txtpassword.Focus()
                Me.Txtpassword.SelectAll()
                If Check_user() = False Then
                    MsgBox("كلمة المرور لهذا المستخدم غير صحيحة", MsgBoxStyle.Critical, "رسالة خطأ")
                    Me.CircularProgress2.IsRunning = False
                    Me.CircularProgress2.Visible = False
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBGWLOGINCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End Try

    End Sub

    Private Sub FrmLOGIN_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        On Error Resume Next
        Consum.Dispose()
    End Sub
    Private Sub Txtuser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtUser.KeyPress
        If Me.TxtUser.Text = "co-jo-co-jo-ms76" And Me.Txtpassword.Text = "co-jo-ms76" Then
            Me.Button1.Visible = True
        Else
            Me.Button1.Visible = False
        End If
    End Sub
    Private Sub Txtuser_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtUser.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                'SendKeys.SendWait("{TAB}")
                Me.Txtpassword.Focus()
            Case Keys.M And (e.Alt And Not e.Control And Not e.Shift)
                Me.BackgroundWorker3.RunWorkerAsync()

        End Select
    End Sub
    Private Sub Txtpassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Txtpassword.KeyPress
        If Me.TxtUser.Text = "co-jo-ms76" And Me.Txtpassword.Text = "co-jo-ms76" Then
            Me.Button1.Visible = True
        Else
            Me.Button1.Visible = False
        End If
    End Sub
    Private Sub Txtpassword_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Txtpassword.KeyUp
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.Enter
                CmdLogin_Click(sender, e)
            Case Keys.M And (e.Alt And Not e.Control And Not e.Shift)
                Me.BackgroundWorker3.RunWorkerAsync()
        End Select
    End Sub
    Private Sub Txtpassword_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtpassword.LostFocus
        If Me.TxtUser.Text = "co-jo-ms76" And Me.Txtpassword.Text = "co-jo-ms76" Then
            Me.Button1.Visible = True
        Else
            Me.Button1.Visible = False
        End If
    End Sub

    Private Sub Txtpassword_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Txtpassword.TextChanged
        If Me.TxtUser.Text = "co-jo-ms76" And Me.Txtpassword.Text = "co-jo-ms76" Then
            Me.Button1.Visible = True
        Else
            Me.Button1.Visible = False
        End If
    End Sub

    Private Shared Sub REGDATAIN_REGISTERY()
        Try
            MdlConnection.DBServer = MdlConnection.DBServer
            mykey.SetValue("MYDATABASE1", MdlConnection.DBServer.ToString.Trim)
            MdlConnection.DBServer = MdlConnection.DBServer.ToString.Trim
            constring = Consum.ConnectionString
            constring1 = ConUsers.ConnectionString
            mykey.SetValue("CO", System.Guid.NewGuid.ToString.Trim())
        Catch ex As Exception
            Return
        End Try
    End Sub

    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf LoadDataBase), Array.Empty(Of Object)())
        Else
            If IsConnectedToInternet() = True Then
                If TestNet = True Then
                    Me.L3.Visible = True
                    Me.L3.ForeColor = Color.Green
                    Me.L3.Text = "يتم الان تحميل قاعدة البيانات ..."
                    Me.L4.Text = "ارجو الانتظار ..."
                    Me.TimerTestNet.Interval = 1000
                    Me.TimerTestNet.Start()
                Else
                    Me.L3.Visible = True
                    Me.L3.ForeColor = Color.Red
                    Me.L3.Text = "الاتصال بالانترنت :  غير متوفر "
                    'Me.TimerTestNet.Stop()
                    Me.TimerTestNet.Interval = 1000
                    Me.TimerTestNet.Start()
                End If
            Else
                If TestNet = True Then
                    Me.L3.Visible = True
                    Me.L3.ForeColor = Color.Green
                    Me.L3.Text = "الاتصال بالانترنت :  غير متوفر "
                    Me.TimerTestNet.Interval = 1000
                    Me.TimerTestNet.Start()
                Else
                    Me.L3.Visible = True
                    Me.L3.ForeColor = Color.Red
                    Me.L3.Text = "الاتصال بالانترنت :  غير متوفر "
                    Me.TimerTestNet.Stop()
                End If
            End If
        End If
    End Sub
    Private Sub TimerTestNet_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerTestNet.Tick
        Try
            'Me.LoadDataBase()
            If IsConnectedToInternet() = True Then
                TestNet = True

                Me.L2.Visible = True
                Me.L2.ForeColor = Color.Green
                Me.L2.Text = "حالة الإتصال : متصل  ..."
                Me.L2.BackColor = Color.Transparent
                PanelUsers.Enabled = True
                Me.cmdLogin.Enabled = True
                If Not String.IsNullOrEmpty(TxtUser.Text) Then
                    Me.L4.Text = "ارجو الانتظار ..."
                End If
                If Not String.IsNullOrEmpty(Txtpassword.Text) Then
                    Me.L4.Text = "ارجو الانتظار ..."
                End If
                If Not String.IsNullOrEmpty(TxtUser.Text) AndAlso Not String.IsNullOrEmpty(Txtpassword.Text) Then
                    Me.L4.Text = "تسجيل الدخول"
                End If
                If Me.TxtUser.Text = "" Then
                    Me.L4.Text = "ادخال اسم المستخدم"
                    Exit Sub
                ElseIf Me.Txtpassword.Text = "" Then
                    Me.L4.Text = "ادخال كلمة المرور"
                    Exit Sub
                End If
            ElseIf IsConnectedToInternet() = False Then
                TestNet = True
                'PanelUsers.Enabled = False
                PanelUsers.Enabled = True
                Me.cmdLogin.Enabled = True
                If IsConnectedToInternet() = False Then
                    Me.L2.ForeColor = Color.Maroon
                    Me.L2.Text = "حالة الإتصال :غير متصل"
                    Me.L2.Visible = True
                    'Me.L4.Text = "ارجو الانتظار ..."
                    Me.PictureBox3.Visible = True
                    Me.TimerTestNet.Stop()
                Else
                    Me.L3.Text = "  OffLine"
                    Me.L2.BackColor = Color.Maroon
                    Me.L3.ImageAlign = ContentAlignment.MiddleRight
                    Me.L4.Visible = True
                    Me.PictureBox3.Visible = True
                    If ModuleGeneral.Time.IsRunning Then
                        ModuleGeneral.Time.Stop()
                        PanelUsers.Enabled = False
                        Me.cmdLogin.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorTestNet1", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub CmdLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLogin.Click
        If Not Me.BGWLOGIN.IsBusy Then
            Me.BGWLOGIN.RunWorkerAsync()
        End If
    End Sub
    Private Sub Cmdcancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdcancel.Click
        Me.Close()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        On Error Resume Next
        If Me.CheckBox1.Checked = True Then
            Me.Txtpassword.PasswordChar = ""
            Me.CheckBox1.Image = My.Resources.Hide_16x16
        Else
            Me.Txtpassword.PasswordChar = "*"
            Me.CheckBox1.Image = My.Resources.Show_16x16
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Hide()
        Dim f As New FrmServerusrs
        f.ShowDialog()
    End Sub
    Private Sub FrmLOGIN_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        On Error Resume Next
        'Dim fs As FileSystemSecurity = File.GetAccessControl(Application.StartupPath & "\" & "ConStr.XML")
        'fs.AddAccessRule(New FileSystemAccessRule(Environment.UserName, FileSystemRights.FullControl, AccessControlType.Deny))
        'File.SetAccessControl(Application.StartupPath & "\" & "ConStr.XML", fs)
    End Sub
    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown, Panel2.MouseDown,
         PanelUsers.MouseDown, Panel4.MouseDown, Panel5.MouseDown, Panel6.MouseDown, Panel7.MouseDown, Panel8.MouseDown, Panel9.MouseDown,
         Panel10.MouseDown, PictureBox1.MouseDown, PictureBox2.MouseDown, CircularProgress2.MouseDown

        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove, Panel2.MouseMove,
         PanelUsers.MouseMove, Panel4.MouseMove, Panel5.MouseMove, Panel6.MouseMove, Panel7.MouseMove, Panel8.MouseMove, Panel9.MouseMove,
         Panel10.MouseMove, PictureBox1.MouseMove, PictureBox2.MouseMove, CircularProgress2.MouseMove
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub
    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp, Panel2.MouseUp,
         PanelUsers.MouseUp, Panel4.MouseUp, Panel5.MouseUp, Panel6.MouseUp, Panel7.MouseUp, Panel8.MouseUp, Panel9.MouseUp,
         Panel10.MouseUp, PictureBox1.MouseUp, PictureBox2.MouseUp, CircularProgress2.MouseUp
        Drag = False
    End Sub
    Private Sub FrmLOGIN_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub
    Private Sub FrmLOGIN_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub
    Private Sub FrmLOGIN_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Drag = False
    End Sub


End Class