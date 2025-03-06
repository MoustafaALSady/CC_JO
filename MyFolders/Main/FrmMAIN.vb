Option Explicit Off
Imports System.ComponentModel
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Globalization
Imports System.IO
Imports System.Net.NetworkInformation
Imports System.Threading.Tasks
'Imports System.Threading
Imports DevExpress.LookAndFeel
Imports DevExpress.Skins
Imports DevExpress.Xpf.Bars
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Localization
Imports TableDependency.SqlClient.Base.EventArgs
Imports TableDependency.SqlClient
Imports DevExpress.XtraEditors.Repository

Public Class FrmMAIN
    ''Inherits DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
<<<<<<< HEAD
    Private WithEvents ConnectDataBase As BackgroundWorker
    Private WithEvents TestUserLogin As BackgroundWorker
    Private WithEvents DelUsersLogin As BackgroundWorker
    Private WithEvents SaveTab As BackgroundWorker
    Private WithEvents RefreshTab As BackgroundWorker
    Private WithEvents SearchTab As BackgroundWorker
=======
    Private WithEvents ConnectDataBase As System.ComponentModel.BackgroundWorker
    Private WithEvents TestUserLogin As System.ComponentModel.BackgroundWorker
    Private WithEvents DelUsersLogin As System.ComponentModel.BackgroundWorker
    Private WithEvents SaveTab As System.ComponentModel.BackgroundWorker
    Private WithEvents RefreshTab As System.ComponentModel.BackgroundWorker
    Private WithEvents SearchTab As System.ComponentModel.BackgroundWorker
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private WithEvents TimerTestNet As New Timer
    Private Delegate Sub LoadDataBaseCallBack()
    Private Delegate Sub CallLoadDataBase()
    Private Delegate Sub PictureBox2Callback()
    Private WithEvents BS As New BindingSource
    Private WithEvents BS1 As New BindingSource

<<<<<<< HEAD
    Dim SqlDataAdapter1 As New SqlDataAdapter
=======
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Dim DataSetUsers As New DataSet
    Dim myds As New DataSet
    Dim Cancel As Boolean = False
    Dim DelRow As Boolean = False

    Dim RowCount1 As Integer = 0
    Dim RowCount2 As Integer = 0

    Dim MouseX As Integer
    Dim MouseY As Integer
    Dim Drag As Boolean
    Dim SEAV As Boolean = False
    Dim resault1 As String
    Dim DsCOMPANY As New DataSet
    Dim resaultSHOWPROMISED As String

    'Protected Overrides ReadOnly Property CreateParams() As CreateParams
    '    Get
    '        Dim param As CreateParams = MyBase.CreateParams
    '        param.ClassStyle = param.ClassStyle Or &H200
    '        Return param
    '    End Get
    'End Property

    Public Sub New()
        Me.InitializeComponent()
        Me.NEWSBAR()
    End Sub

    'Private Sub FormMain_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
    'R.Container = Me
    'End Sub
    'Private Sub FormMain_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
    '    R.ResizeControls()
    'End Sub

<<<<<<< HEAD
    Private Sub FrmMAIN_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseDown
=======
    Private Sub FrmMAIN_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub

<<<<<<< HEAD
    Private Sub FrmMAIN_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseMove
=======
    Private Sub FrmMAIN_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub

<<<<<<< HEAD
    Private Sub FrmMAIN_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        Drag = False
    End Sub

    Private Sub Panel8_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
=======
    Private Sub FrmMAIN_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Drag = False
    End Sub

    Private Sub Panel8_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Drag = True
        MouseX = Cursor.Position.X - Me.Left
        MouseY = Cursor.Position.Y - Me.Top
    End Sub

<<<<<<< HEAD
    Private Sub Panel8_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
=======
    Private Sub Panel8_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If Drag = True Then
            Me.Left = Cursor.Position.X - MouseX
            Me.Top = Cursor.Position.Y - MouseY
        End If
    End Sub

<<<<<<< HEAD
    Private Sub Panel8_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
        Drag = False
    End Sub

    Private Sub FrmMAIN_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
=======
    Private Sub Panel8_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Drag = False
    End Sub

    Private Sub FrmMAIN_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Select Case e.KeyCode
            Case Keys.F5
                MNUOPENPROGRAM_Click(sender, e)
            Case Keys.End
                Me.Close()
        End Select
        e.Handled = True
    End Sub

    Private Sub FrmMAIN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.BackgroundImage = img
        'For a As Byte = 0 To 10
        '    System.Threading.Thread.Sleep(10)
        '    Application.DoEvents()
        '    Me.Opacity = a / 10
        'Next
        Dim element As SkinElement = SkinManager.GetSkinElement(SkinProductId.Ribbon, DevExpress.LookAndFeel.UserLookAndFeel.Default, "StatusBarFormBackground")
        element.Color.SolidImageCenterColor = Color.SteelBlue
        LookAndFeelHelper.ForceDefaultLookAndFeelChanged()


        Insert_Actions(BS.Position + 1, "وقت الدخول", AssociationName)
        If Not Directory.Exists(MYFOLDER & "D:") Then
            Directory.CreateDirectory(MYFOLDER & Application.StartupPath & "\CO_MAS\MyDATA")
            MYFOLDER = mykey.GetValue("MYFOLDER", Application.StartupPath & "\CO_MAS\MyDATA")
        End If
        CraeteTempFolder()
        Dim resault2 As String
        Dim resault4 As String
        Dim resault5 As String
        Dim resault6 As String
        Dim resault7 As String
        Dim resault8 As String
        Dim resault9 As String
        Dim resault10 As String

        Dim resault13 As String
        Dim resault14 As String
        Dim resault15 As String
        Dim resault16 As String
        Dim resault17 As String
        Dim resault18 As String
        Dim ItemsIncludeExpirationDate As String
        Dim OP1 As String
        Dim OP2 As String
        Dim OP3 As String
        Dim OP4 As String
        Dim OP5 As String
        Dim OP7 As String
        Dim OP8 As String
        Dim OP9 As String
        Dim CI As String
        ModuleGeneral.LoadMyDatabase2()
        Me.REGDATAIN_REGISTERY()
        Application.DoEvents()
        Me.TBUTTON3.Enabled = True
        Me.TBUTTON4.Enabled = True
        Me.MAIN1.Enabled = M1
        Me.MAIN2.Enabled = M2
        Me.MAIN3.Enabled = M3
        Me.MAIN4.Enabled = M4
        Me.MMAIN5.Enabled = M5
        Me.MAIN7.Enabled = M7

        Me.SHOWMAIN5()
        Me.NEWSBAR()
        resault1 = CStr(mykey.GetValue("NEWEVENTS", "False"))
        resault11 = mykey.GetValue("SHOWMOMENT", "False")
        resault2 = CStr(mykey.GetValue("LANGUAGE", "ARABIC"))
        resault4 = CStr(mykey.GetValue("SONG", "None"))
        resault5 = CStr(mykey.GetValue("PLAY", "False"))
        resault6 = CStr(mykey.GetValue("VIEW", "False"))
        resault7 = CStr(mykey.GetValue("TBAR", "False"))
        resault8 = CStr(mykey.GetValue("TNEWS", "False"))
        resault9 = CStr(mykey.GetValue("eplor", "False"))
        resault10 = CStr(mykey.GetValue("SHOWMOVIES", "False"))
        resaultSHOWPROMISED = CStr(mykey.GetValue("SHOWPROMISED", "False"))
        ItemsIncludeExpirationDate = CStr(mykey.GetValue("ItemsIncludeExpirationDate", "False"))
        resault13 = CStr(mykey.GetValue("FIFO", False))
        resault14 = CStr(mykey.GetValue("LIFO", False))
        resault15 = CStr(mykey.GetValue("AVG", False))
        resault16 = CStr(mykey.GetValue("CHBO", False))
        resault17 = CStr(mykey.GetValue("CHBO1", False))
        resault18 = CStr(mykey.GetValue("CHBO2", False))
        URL = CStr(mykey.GetValue("URL", URL))
        URL1 = CStr(mykey.GetValue("URL1", URL1))
        URL2 = CStr(mykey.GetValue("URL2", URL2))
        L1.Text = URL.Trim
        L2.Text = URL1.Trim
        L3.Text = URL2.Trim

        FolderImageName = CStr(mykey.GetValue("FolderImageName", "FolderImageName"))
        ImageName = CStr(mykey.GetValue("FaiLImageName", "ImageName"))
        ImageExe = CStr(mykey.GetValue("ImageExe", ".png"))

        OP1 = CStr(mykey.GetValue("Openingbalance1", "False"))
        OP2 = CStr(mykey.GetValue("Openingbalance2", "False"))
        OP3 = CStr(mykey.GetValue("Openingbalance3", "False"))
        OP4 = CStr(mykey.GetValue("Openingbalance4", "False"))
        OP5 = CStr(mykey.GetValue("Openingbalance5", "False"))
        OP6 = mykey.GetValue("Openingbalance6", "False")
        OP7 = CStr(mykey.GetValue("Openingbalance7", "False"))
        OP8 = CStr(mykey.GetValue("Openingbalance8", "False"))
        OP9 = CStr(mykey.GetValue("Openingbalance9", "False"))
        CI = CStr(mykey.GetValue("CHKCI", "False"))

        OBCHK1 = CBool(OP1)
        OBCHK2 = CBool(OP2)
        OBCHK3 = CBool(OP3)
        OBCHK4 = CBool(OP4)
        OBCHK5 = CBool(OP5)
        OBCHK6 = CBool(OP6)
        OBCHK7 = CBool(OP7)
        OBCHK8 = CBool(OP8)
        OBCHK9 = CBool(OP9)


        CHKCI = CBool(CI)

        Me.ComboAppearance.EditValue = CStr(mykey.GetValue("Appearance", Me.ComboAppearance.EditValue))

        If resault2 = "ARABIC" Then
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages().Item(1) 'تغيير لغة لوحة المفاتيح الى اللغه العربية
        ElseIf resault2 = "ENGLISH" Then
            InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages().Item(0) 'تغيير لغة لوحة المفاتيح الى اللغه الانجليزيه
        End If
        MENU18.Enabled = False
        If resault7 = "True" Then
            Me.ToolStrip1.Visible = True
            Me.MNUTOOLBARVIEW.Checked = True
        ElseIf resault7 = "False" Then
            Me.ToolStrip1.Visible = False
            Me.MNUTOOLBARVIEW.Checked = False
        End If
        If resault8 = "True" Then
            Me.NEWEVENTS.Visible = True
            Me.PanelNEWEVENTS.Visible = True
            Me.MNUNEWSBARVIEW.Checked = True
        ElseIf resault8 = "False" Then
            Me.NEWEVENTS.Visible = False
            Me.PanelNEWEVENTS.Visible = False
            Me.MNUNEWSBARVIEW.Checked = False
        End If
        If resault9 = "True" Then
            Explormnu()
        ElseIf resault9 = "False" Then
            Explormnuremove()
        End If
        If resault10 = "True" Then
            Me.mnutransaction.Visible = True
            Me.MNUCERTICATE.Visible = True
            Me.MNUSEARCHTRANSACTION.Visible = True
        ElseIf resault10 = "False" Then
            Me.mnutransaction.Visible = False
            Me.MNUCERTICATE.Visible = False
            Me.MNUSEARCHTRANSACTION.Visible = False
        End If
        If CBool(ItemsIncludeExpirationDate) = True Then
            ModuleGeneral.ItemsExpirationDate = True
        ElseIf CBool(ItemsIncludeExpirationDate) = False Then
            ModuleGeneral.ItemsExpirationDate = False
        End If

        Dim frm As New FrmMoment
        If CBool(resault11) = True Then
            frm.Label1.Text = "البوم" & " " & ServerDateTime.ToString("dddd") & vbCrLf & vbCrLf & ServerDateTime.ToString("yyyy-MM-dd") & vbCrLf & vbCrLf & "مرحباً بكم مع برنامج" & vbCrLf & vbCrLf & "إدارة ومحاسبة الجمعيات التعاونية" & vbCrLf & vbCrLf & " رصيدك النهائى اليوم " & vbCrLf & vbCrLf & ModuleBalanceMoment.Fs6 & " _ " & "د.أ"
            frm.Show()
            MENU16.Visible = True
        ElseIf CBool(resault11) = False Then
            frm.Close()
            MENU16.Visible = False
        End If
        If CBool(resault13) = True Then
            FIFO = True
            LabelStockStatus.Text = "FIFO"
        ElseIf CBool(resault13) = False Then
            FIFO = False
        End If
        If CBool(resault14) = True Then
            LIFO = True
            LabelStockStatus.Text = "LIFO"
        ElseIf CBool(resault14) = False Then
            LIFO = False
        End If
        If CBool(resault15) = True Then
            AVG = True
            LabelStockStatus.Text = "AVG"
        ElseIf resault15 = "False" Then
            AVG = False
        End If
        If CBool(resault16) = True Then
            ChecksIN = CInt(mykey.GetValue("SHOWChecksIN", "10"))
            'Else
            '    ChecksIN = CInt(mykey.GetValue("SHOWChecksIN", "10"))
        End If
        If CBool(resault17) = True Then
            CategoriesIN = CInt(mykey.GetValue("SHOWCategoriesIN", "10"))
            'Else
            '    CategoriesIN = CInt(mykey.GetValue("SHOWCategoriesIN", "10"))
        End If
        If CBool(resault18) = True Then
            PaymentsIN = CInt(mykey.GetValue("SHOWPaymentsIN", "10"))
            'Else
            '    PaymentsIN = CInt(mykey.GetValue("SHOWPaymentsIN", "10"))
        End If

        If Not IO.Directory.Exists(MYFOLDER & "\Photos") Then
            Directory.CreateDirectory(MYFOLDER & "\Photos")
        End If
        If Not IO.Directory.Exists(MYFOLDER & "\DOCUMENTS") Then
            Directory.CreateDirectory(MYFOLDER & "\DOCUMENTS")
        End If
        If Not IO.Directory.Exists(MYFOLDER & "\Backup") Then
            Directory.CreateDirectory(MYFOLDER & "\Backup")
        End If

        Try
            Dim adapters As NetworkInterface() = NetworkInterface.GetAllNetworkInterfaces()
            For Each nic As NetworkInterface In adapters
                Dim type As NetworkInterfaceType = nic.NetworkInterfaceType
                If type <> NetworkInterfaceType.Loopback AndAlso type <> NetworkInterfaceType.Tunnel AndAlso type <> NetworkInterfaceType.Unknown Then
                    UserMacAddress &= nic.GetPhysicalAddress().ToString.Trim()
                    Me.LabelTast.Text = UserMacAddress.Trim
                End If
            Next
            '==================================
            If OnLine = True Then
                If UserMacAddress.Trim = Nothing Then
                    MsgBox("الرجاءالاتصال بإدارة ومحاسبة الجمعيات التعاونية", 16, "تنبيه بوجود خطا ما")
                    End
                End If
            End If

            Call OptionsA()
            MYDATABASE1 = DBServer.Trim

            'Dim Culture = CultureInfo.CreateSpecificCulture("ar")
            'System.Threading.Thread.CurrentThread.CurrentUICulture = Culture
            'System.Threading.Thread.CurrentThread.CurrentCulture = Culture
            'CultureInfo.DefaultThreadCurrentCulture = Culture
            'CultureInfo.DefaultThreadCurrentUICulture = Culture

            CultureInfo.CurrentUICulture = New CultureInfo("ar")

<<<<<<< HEAD
            Me.BackW3 = New BackgroundWorker With {
=======
            Me.BackW3 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.BackW3.RunWorkerAsync()

<<<<<<< HEAD
            Me.ConnectDataBase = New BackgroundWorker With {
=======
            Me.ConnectDataBase = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.ConnectDataBase.RunWorkerAsync()

<<<<<<< HEAD
            Me.BackW1 = New BackgroundWorker With {
=======
            Me.BackW1 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.BackW1.RunWorkerAsync()





            ' تنفيذ الأمر


            'queueName

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorfrmMAIN_Load", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End
        End Try
    End Sub

    Private Sub GatAppointments()
        Try
            'Dim connectionString As String = "Data Source=CC;Initial Catalog=CC_JO;Integrated Security=True"
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            'SqlDependency.Start(Consum.ConnectionString)
            Consum = New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim strsql_Appointments As New SqlCommand("", Consum) With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            'SqlDependency.Start(Consum.ConnectionString)
            Consum = New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim strsql_Appointments As New SqlClient.SqlCommand("", Consum) With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandText = "SELECT StartDate, EndDate, Subject,Description FROM  dbo.Appointments WHERE  CUser ='" & CUser & "'"
            }

            Dim ds_Appointments As New DataSet
<<<<<<< HEAD
            Dim Adp_Appointments As New SqlDataAdapter(strsql_Appointments)
=======
            Dim Adp_Appointments As New SqlClient.SqlDataAdapter(strsql_Appointments)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds_Appointments.Clear()
            Adp_Appointments.Fill(ds_Appointments)

            Dim StarDateNow As DateTime = Date.Now.ToString("yyyy-MM-dd hh:mm:ss tt")
            Dim EndDate As DateTime
            Dim Num As Integer = 0

            CType(BarEditItemAdornerAppointments.Edit, RepositoryItemComboBox).Items.Clear()
            For II As Integer = 0 To ds_Appointments.Tables(0).Rows.Count - 1
                StarDate = ds_Appointments.Tables(0).Rows(II).Item(0)
                EndDate = ds_Appointments.Tables(0).Rows(II).Item(1)
                EndDate = EndDate.ToString("yyyy-MM-dd hh:mm:ss tt")
                If ds_Appointments.Tables(0).Rows.Count > II Then
                    If StarDateNow >= EndDate Then
                        CType(BarEditItemAdornerAppointments.Edit, RepositoryItemComboBox).Items.Add(ds_Appointments.Tables(0).Rows(II).Item(2))
                        Num = ds_Appointments.Tables(0).Rows.Count
                    End If
                End If
            Next
            If ds_Appointments.Tables(0).Rows.Count > 0 Then
                BarEditItemAdornerAppointments.EditValue = ds_Appointments.Tables(0).Rows(0).Item(2)
            End If
            If Num > 0 AndAlso Num < 100 Then
                BadgeAppointments.Properties.Text = Num
                BadgeAppointments.Visible = True
                BarEditItemAdornerAppointments.Enabled = True
                ButAdornerAppointments.Enabled = True
            ElseIf Num > 99 Then
                BadgeAppointments.Properties.Text = "+99"
                BadgeAppointments.Visible = True
            ElseIf Num = 0 Then
                BadgeAppointments.Properties.Text = "0"
                BadgeAppointments.Visible = False
                CType(BarEditItemAdornerAppointments.Edit, RepositoryItemComboBox).Items.Clear()
                BarEditItemAdornerAppointments.Enabled = False
                ButAdornerAppointments.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorGatAppointments", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
        End Try
    End Sub

    Private Sub GatChecks()
        Try
            'Dim connectionString As String = "Data Source=CC;Initial Catalog=CC_JO;Integrated Security=True"
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            'SqlDependency.Start(Consum.ConnectionString)
            Consum = New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim strsql_Checks As New SqlCommand("", Consum) With {
                   .CommandText = "select  IDCH, CH3, CH7  from Checks  WHERE  CUser='" & CUser & "' and CH17 ='" & False & "' and IDCH>'" & 0 & "' ORDER BY IDCH"
                }
            Dim ds_Checks As New DataSet
            Dim Adp_Checks As New SqlDataAdapter(strsql_Checks)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            'SqlDependency.Start(Consum.ConnectionString)
            Consum = New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim strsql_Checks As New SqlClient.SqlCommand("", Consum) With {
                   .CommandText = "select  IDCH, CH3, CH7  from Checks  WHERE  CUser='" & CUser & "' and CH17 ='" & False & "' and IDCH>'" & 0 & "' ORDER BY IDCH"
                }
            Dim ds_Checks As New DataSet
            Dim Adp_Checks As New SqlClient.SqlDataAdapter(strsql_Checks)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds_Checks.Clear()
            Adp_Checks.Fill(ds_Checks)
            Dim Num As Integer = 0
            CType(BarEditItemChecks.Edit, RepositoryItemComboBox).Items.Clear()
            For II As Integer = 0 To ds_Checks.Tables(0).Rows.Count - 1
                If ds_Checks.Tables(0).Rows.Count > II Then
                    CType(BarEditItemChecks.Edit, RepositoryItemComboBox).Items.Add(ds_Checks.Tables(0).Rows(II).Item(2))
                    Num = ds_Checks.Tables(0).Rows.Count
                End If
            Next
            If ds_Checks.Tables(0).Rows.Count > 0 Then
                BarEditItemChecks.EditValue = ds_Checks.Tables(0).Rows(0).Item(2)
            End If
            If Num > 0 AndAlso Num < 100 Then
                BadgeChecks.Properties.Text = Num
                BadgeChecks.Visible = True
                BarEditItemChecks.Enabled = True
                ButChecks.Enabled = True
            ElseIf Num > 99 Then
                BadgeChecks.Properties.Text = "+99"
                BadgeChecks.Visible = True
            ElseIf Num = 0 Then
                BadgeChecks.Properties.Text = "0"
                BadgeChecks.Visible = False
                CType(BarEditItemChecks.Edit, RepositoryItemComboBox).Items.Clear()
                BarEditItemChecks.Enabled = False
                ButChecks.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorGatChecks", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
        End Try
    End Sub

    Private Sub GatFinishedItems()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            'SqlDependency.Start(Consum.ConnectionString)
            Consum = New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim strsql_FinishedItems As New SqlCommand("", Consum) With {
               .CommandText = "SELECT STK1, STK7, STK25, IT_DATEP, IT_DATEEX, CUser FROM STOCKS  WHERE  CUser='" & CUser & "' and STK13>'" & 0 & "'"
            }
            Dim ds_FinishedItems As New DataSet
            Dim Adp_FinishedItems As New SqlDataAdapter(strsql_FinishedItems)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            'SqlDependency.Start(Consum.ConnectionString)
            Consum = New SqlConnection(constring)
            If Consum.State = ConnectionState.Closed Then Consum.Open()
            Dim strsql_FinishedItems As New SqlClient.SqlCommand("", Consum) With {
               .CommandText = "SELECT STK1, STK7, STK25, IT_DATEP, IT_DATEEX, CUser FROM STOCKS  WHERE  CUser='" & CUser & "' and STK13>'" & 0 & "'"
            }
            Dim ds_FinishedItems As New DataSet
            Dim Adp_FinishedItems As New SqlClient.SqlDataAdapter(strsql_FinishedItems)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            ds_FinishedItems.Clear()
            Adp_FinishedItems.Fill(ds_FinishedItems)
            Dim StarDateNow As DateTime = Date.Now.ToString("yyyy-MM-dd hh:mm:ss tt")
            Dim EndDate As DateTime
            Dim Num As Integer = 0
            CType(BarEditItemFinishedItems.Edit, RepositoryItemComboBox).Items.Clear()
            For II As Integer = 0 To ds_FinishedItems.Tables(0).Rows.Count - 1
                StarDate = ds_FinishedItems.Tables(0).Rows(II).Item(3)
                EndDate = ds_FinishedItems.Tables(0).Rows(II).Item(4)
                EndDate = EndDate.ToString("yyyy-MM-dd hh:mm:ss tt")
                If ds_FinishedItems.Tables(0).Rows.Count > II Then
                    If StarDateNow >= EndDate Then
                        CType(BarEditItemFinishedItems.Edit, RepositoryItemComboBox).Items.Add(ds_FinishedItems.Tables(0).Rows(II).Item(1))
                        Num = ds_FinishedItems.Tables(0).Rows.Count
                    End If
                End If
            Next
            If ds_FinishedItems.Tables(0).Rows.Count > 0 Then
                BarEditItemFinishedItems.EditValue = ds_FinishedItems.Tables(0).Rows(0).Item(1)
            End If

            If Num > 0 AndAlso Num < 100 Then
                BadgeFinishedItems.Properties.Text = Num
                BadgeFinishedItems.Visible = True
                BarEditItemFinishedItems.Enabled = True
                ButFinishedItems.Enabled = True
            ElseIf Num > 99 Then
                BadgeFinishedItems.Properties.Text = "+99"
                BadgeFinishedItems.Visible = True
                BarEditItemFinishedItems.Enabled = True
                ButFinishedItems.Enabled = True
            ElseIf Num = 0 Then
                BadgeFinishedItems.Properties.Text = "0"
                BadgeFinishedItems.Visible = False
                CType(BarEditItemFinishedItems.Edit, RepositoryItemComboBox).Items.Clear()
                BarEditItemFinishedItems.Enabled = False
                ButFinishedItems.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorGatFinishedItems", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
        End Try
    End Sub

    Private Sub ButAdornerAppointments_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ButAdornerAppointments.ItemClick
        Try
            Dim frm As New FormScheduler
            If CType(BarEditItemAdornerAppointments.Edit, RepositoryItemComboBox).Items.Count > 0 Then
                frm.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButChecks_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ButChecks.ItemClick
        Try
            Dim frm As New FrmCheckslsta
            If CType(BarEditItemChecks.Edit, RepositoryItemComboBox).Items.Count > 0 Then
                frm.Show()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub ButFinishedItems_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ButFinishedItems.ItemClick
        Try
            Dim frm As New FrmExpire
            If CType(BarEditItemFinishedItems.Edit, RepositoryItemComboBox).Items.Count > 0 Then
                frm.Show()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub OnDependencyChange(sender As Object, e As SqlNotificationEventArgs)
        MessageBox.Show("تم تغيير البيانات!")
    End Sub

    'Private Sub OnTableChanged(sender As Object, e As TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs(Of YourModel))
    '    ' Handle the change event here.
    '    ' e.ChangeType will indicate the type of change (Insert, Update, Delete).
    '    ' e.Entity will contain the changed data.
    'End Sub

<<<<<<< HEAD
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles ConnectDataBase.DoWork
=======
    Private Sub ConnectDataBase_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles ConnectDataBase.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:

            TestNet = True
            Me.LoadDataBase()
            Me.Invoke(New LoadDataBaseCallBack(AddressOf Me.LoadDataBase), Array.Empty(Of Object)())
<<<<<<< HEAD
            Me.TestUserLogin = New BackgroundWorker With {
=======
            Me.TestUserLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.TestUserLogin.RunWorkerAsync()
        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorConnectDataBase_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
=======
    Private Sub ConnectDataBase_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles ConnectDataBase.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

            '=================================================================================
            Me.Text = "نظام إدارة ومحاسبة الجمعيات التعاونية الاردنيــة "
            Dim dt As DateTime = CDate(ServerDateTime.ToString("yyyy-MM-dd"))
            Dim dt2 As DateTime = CDate(ServerDateTime.ToString("hh:mm:ss tt"))
            Me.TS7.Caption = dt2.ToString("hh:mm:ss tt")
            Me.TS8.Caption = dt.ToString("yyyy-MM-dd")
            Me.PictureTestNet.Visible = False
            FrmLOGIN.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Consum.Close()
        End Try
    End Sub

    Public Sub LoadDataBase()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New CallLoadDataBase(AddressOf Me.LoadDataBase), Array.Empty(Of Object)())
        Else
            Me.LabelSearchConnection.Visible = False
            Me.TimerTestNet.Interval = 100
            Me.TimerTestNet.Start()
            Me.LabelTast.Visible = False
        End If
    End Sub

<<<<<<< HEAD
    Private Sub BackW3_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackW3.DoWork
=======
    Private Sub BackW3_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW3.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.CircularProgress2.IsRunning = True
        Me.CircularProgress2.ProgressTextVisible = True
        Me.RibbonControl2.Enabled = False
        Me.MAIN5.Enabled = False
        Me.ComboGovernorateName.Enabled = False
        Me.ComboGetAssociationName.Enabled = False
        Call TxtURL1()


    End Sub

    Private Sub BackW3_ProgressChanged(sender As Object, e As ProgressChangedEventArgs) Handles BackW3.ProgressChanged
        Me.CircularProgress2.Value = e.ProgressPercentage
        'Me.LabelSearch.Visible = True
    End Sub

<<<<<<< HEAD
    Private Sub BackW3_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackW3.RunWorkerCompleted
=======
    Private Sub BackW3_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW3.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.CircularProgress2.IsRunning = False
        Me.CircularProgress2.ProgressTextVisible = False
        Me.CircularProgress2.Visible = False
        'Me.LabelSearch.Visible = False
        Me.RibbonControl2.Enabled = True
        Me.MAIN5.Enabled = True
        Me.ComboGovernorateName.Enabled = True
        Me.ComboGetAssociationName.Enabled = True
        Dim F As New FrmFinabalances
        If resaultSHOWPROMISED = "True" Then
            If MYVDATE() = True Then
                'F.MdiParent = Me
                F.Show()
            End If
        ElseIf resaultSHOWPROMISED = "False" Then
            F.Close()
        End If
        If Trim(tmpV) > Trim(mykey.GetValue("ProductVersion", "")) Then
            Dim frm As New FormUpdate
            frm.Show()
        End If
    End Sub

    Private Sub TimerTestNet_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerTestNet.Tick
        Try
            If IsConnectedToInternet() = True Then
                OnLine = True
                If Not Time.IsRunning Then
                    ModuleGeneral.Time.Reset()
                    ModuleGeneral.Time.Start()
                End If
                Me.Label1Time.Text = Time.Elapsed.Hours.ToString("00:") & Time.Elapsed.Minutes.ToString("00:") & Time.Elapsed.Seconds.ToString("00")
                Me.LabelSearchConnection.Visible = False
                Me.LabelConnectedToInternet.Image = Me.ImageList1.Images(0)
                If Time.Elapsed.Seconds Mod 6 = 0 Then
                    Me.LabelConnectedToInternet.Image = Me.ImageList1.Images(1)
                ElseIf Time.Elapsed.Seconds Mod 6 = 3 Then
                    Me.LabelConnectedToInternet.Image = Me.ImageList1.Images(2)
                End If
                If Not TestUserLogin.IsBusy Then
<<<<<<< HEAD
                    Me.TestUserLogin = New BackgroundWorker With {
=======
                    Me.TestUserLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .WorkerReportsProgress = True,
                        .WorkerSupportsCancellation = True
                    }
                    Me.TestUserLogin.RunWorkerAsync()
                End If
            ElseIf IsConnectedToInternet() = False Then
                OnLine = False
                Me.LabelConnectedToInternet.Text = "  OffLine"
                Me.LabelConnectedToInternet.ForeColor = Color.White
                Me.LabelConnectedToInternet.BackColor = Color.Red
                Me.LabelConnectedToInternet.Image = ImageList1.Images(4)
                Me.LabelSearchServer.Visible = False
                Me.LabelTast.Visible = False
                Me.PictureSearchServer.Visible = False
                If Not TestUserLogin.IsBusy Then
<<<<<<< HEAD
                    Me.TestUserLogin = New BackgroundWorker With {
=======
                    Me.TestUserLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                    Me.TestUserLogin.RunWorkerAsync()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorTestNet", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BackW1_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackW1.DoWork
=======
    Private Sub BackW1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW1.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try

1:
            Me.Invoke(New LoadDataBaseCallBack(AddressOf Me.LoadDataBase), Array.Empty(Of Object)())
            Me.myds.EnforceConstraints = False
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim News As New SqlCommand("", Consum)
            With News
                .CommandText = "SELECT Ne1, Ne2, Ne3 from News order by Ne1"
            End With
            Me.SqlDataAdapter1 = New SqlDataAdapter(News)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim News As New SqlClient.SqlCommand("", Consum)
            With News
                .CommandText = "SELECT Ne1, Ne2, Ne3 from News order by Ne1"
            End With
            Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(News)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Me.myds = New DataSet
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            Me.SqlDataAdapter1.Fill(Me.myds, "News")
            Consum.Close()

        Catch ex As Exception
            If ex.Message.GetHashCode = 2097666462 Then
                TestNet = False
                Me.LoadDataBase()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                MessageBox.Show(ex.Message, "ErrorBackW1DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Consum.Close()
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub BackW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackW1.RunWorkerCompleted
=======
    Private Sub BackW1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW1.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Me.TextID.DataBindings.Clear()
            Me.TextNewsNumber.DataBindings.Clear()
            Me.TextNewsText.DataBindings.Clear()
            If e.Cancelled Then Exit Sub
            Me.BS1.DataSource = Me.myds.Tables("News")
            Me.RowCount2 = Me.BS1.Count
            Me.TextID.DataBindings.Add("text", Me.BS1, "Ne1", True, 1, "")
            Me.TextNewsNumber.DataBindings.Add("text", Me.BS1, "Ne2", True, 1, "")
            Me.TextNewsText.DataBindings.Add("text", Me.BS1, "Ne3", True, 1, "")
            If resault1 = "True" Then
                Me.NEWSBAR1()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorBackW1RunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

<<<<<<< HEAD
    Private Sub SearchData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SearchTab.DoWork
=======
    Private Sub SearchData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SearchTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:
            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "News")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                TestNet = False
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub SearchData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles SearchTab.RunWorkerCompleted
=======
    Private Sub SearchData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SearchTab.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If e.Cancelled Then Exit Sub
            Me.BS1.DataSource = Me.myds.Tables("News")
            If IsNumeric(Me.TextSearch.Text.Trim) = True Then
                If CInt(Me.myds.Tables("News").Compute("Count(Ne1)", "Ne1='" & Me.TextSearch.Text.Trim & "' or Ne2='" & Me.TextSearch.Text.Trim & "'").ToString) > 0 Then
                    Me.BS1.Filter = "Ne1='" & Me.TextSearch.Text.Trim & "' or Ne2='" & Me.TextSearch.Text.Trim & "'"
                    Me.Cursor = Cursors.Default
                    Me.PictureDovePeace.Visible = False
                    Exit Sub
                End If
            ElseIf IsDate(Me.TextSearch.Text.Trim) = True Then
                Me.TextSearch.Text = CDate(Me.TextSearch.Text).ToShortDateString
                If CInt(Me.myds.Tables("News").Compute("Count(Ne3)", "Ne3='" & Me.TextSearch.Text & "'").ToString) > 0 Then
                    Me.BS1.Filter = "Ne3='" & Me.TextSearch.Text & "'"
                    Me.Cursor = Cursors.Default
                    Me.PictureDovePeace.Visible = False
                    Exit Sub
                End If
            ElseIf IsNumeric(Me.TextSearch.Text.Trim) = False Then
                If CInt(Me.myds.Tables("News").Compute("Count(Ne3)", "Ne3 like '%" & Me.TextSearch.Text & "%'").ToString) > 0 Then
                    Me.BS1.Filter = "Ne3 like '%" & Me.TextSearch.Text & "%'"
                    Me.Cursor = Cursors.Default
                    Me.PictureDovePeace.Visible = False
                    Exit Sub
                End If
            End If
            Me.Cursor = Cursors.Default
            Me.PictureDovePeace.Visible = False
            MsgBox("لم يتم العثور على اي نتائج للبحث", MsgBoxStyle.MsgBoxRight, "البحث")
            Me.TextSearch.Focus()
            Me.TextSearch.SelectAll()
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            Me.PictureDovePeace.Visible = False
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles RefreshTab.DoWork
=======
    Private Sub RefreshData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles RefreshTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:          Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "News")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                Me.PictureBox2False()
                TestNet = False
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                PictureBox2False()
                e.Cancel = True
                MessageBox.Show(ex.Message, "ErrorRefreshData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
=======
    Private Sub RefreshData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles RefreshTab.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            Dim resault13 As String
            Dim resault14 As String
            Dim resault15 As String
            Dim resault16 As String
            Dim resault17 As String
            Dim resault18 As String
            Dim resault1 As String


            Dim CI As String


            Dim ItemsIncludeExpirationDate As String
            ItemsIncludeExpirationDate = mykey.GetValue("ItemsIncludeExpirationDate", "False")

            resault1 = mykey.GetValue("NEWEVENTS", "NO")
            resault13 = mykey.GetValue("FIFO", False)
            resault14 = mykey.GetValue("LIFO", False)
            resault15 = mykey.GetValue("AVG", False)

            resault16 = mykey.GetValue("CHBO", False)
            resault17 = mykey.GetValue("CHBO1", False)
            resault18 = mykey.GetValue("CHBO2", False)
            CI = mykey.GetValue("CHKCI", False)

            If e.Cancelled Then Exit Sub
            Me.BS1.DataSource = Me.myds.Tables("News")
            Me.PictureDovePeace.Visible = False
            Me.NEWSBAR()
            Me.Cursor = Cursors.Default
            Me.LabelFiscalYear.Text = FiscalYear_currentDateMustBeInFiscalYear()
            If resault13 = True Then
                FIFO = True
                LabelStockStatus.Text = "FIFO"
            ElseIf resault1 = False Then
                FIFO = False
            End If
            If resault14 = True Then
                LIFO = True
                LabelStockStatus.Text = "LIFO"
            ElseIf resault1 = False Then
                LIFO = False
            End If
            If resault15 = True Then
                AVG = True
                LabelStockStatus.Text = "AVG"
            ElseIf resault1 = False Then
                AVG = False
            End If

            If CI = True Then
                CHKCI = True
            ElseIf CI = False Then
                CHKCI = False
            End If



            If resault16 = True Then
                ChecksIN = mykey.GetValue("SHOWChecksIN", "10")
            Else
                ChecksIN = mykey.GetValue("SHOWChecksIN", "10")
            End If
            If resault17 = True Then
                CategoriesIN = mykey.GetValue("SHOWCategoriesIN", "10")
            Else
                CategoriesIN = mykey.GetValue("SHOWCategoriesIN", "10")
            End If
            If resault18 = True Then
                PaymentsIN = mykey.GetValue("SHOWPaymentsIN", "10")
            Else
                PaymentsIN = mykey.GetValue("SHOWPaymentsIN", "10")
            End If
            If ItemsIncludeExpirationDate = True Then
                ModuleGeneral.ItemsExpirationDate = True
            ElseIf ItemsIncludeExpirationDate = False Then
                ModuleGeneral.ItemsExpirationDate = False
            End If

            If DelRow = False Then
                If Me.BS1.Count < RowCount2 Then
                    MsgBox(" تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount2 - Me.BS1.Count, 48 + 524288, "تحديث السجلات")
                ElseIf Me.BS1.Count > RowCount2 Then
                    MsgBox(" تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS1.Count - Me.RowCount2, 48 + 524288, "تحديث السجلات")
                End If
            Else
                DelRow = False
            End If
            Me.PictureSearchConnection.Visible = False
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRefreshData", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub SAVERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As String = "INSERT INTO News( Ne2,Ne3) VALUES ( @Ne2, @Ne3)"
            Dim cmd As New SqlCommand(SQL, Consum)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As String = "INSERT INTO News( Ne2,Ne3) VALUES ( @Ne2, @Ne3)"
            Dim cmd As New SqlClient.SqlCommand(SQL, Consum)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            With cmd
                .CommandType = CommandType.Text
                .Connection = Consum
                '.Parameters.Add("@Ne1", SqlDbType.Int).Value = Me.TextBox1.Text.Trim
                .Parameters.Add("@Ne2", SqlDbType.NVarChar).Value = Me.TextNewsNumber.Text.Trim
                .Parameters.Add("@Ne3", SqlDbType.Text).Value = Me.TextNewsText.Text.Trim

                .CommandText = SQL
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            cmd.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorSAVERECORD", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UPDATERECORD()
        Try
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
            Dim SQL As New SqlCommand("Update News SET  Ne2 = @Ne2, Ne3 = @Ne3   WHERE Ne1 = @Ne1", Consum)
            Dim CMD As New SqlCommand With {
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL As New SqlCommand("Update News SET  Ne2 = @Ne2, Ne3 = @Ne3   WHERE Ne1 = @Ne1", Consum)
            Dim CMD As New SqlClient.SqlCommand With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .CommandType = CommandType.Text,
                .Connection = Consum
            }
            With CMD
                .CommandType = CommandType.Text
                .Connection = Consum
                .Parameters.Add("@Ne1", SqlDbType.Int).Value = Me.TextID.Text.Trim
                .Parameters.Add("@Ne2", SqlDbType.NVarChar).Value = Me.TextNewsNumber.Text.Trim
                .Parameters.Add("@Ne3", SqlDbType.Text).Value = Me.TextNewsText.Text.Trim
                .CommandText = SQL.CommandText
            End With
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            CMD.ExecuteNonQuery()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles SaveTab.DoWork
=======
    Private Sub SaveData_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles SaveTab.DoWork
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
1:
            'Me.SqlDataAdapter1.Update(Me.myds, "News")

            Me.myds = New DataSet
            Me.SqlDataAdapter1.Fill(Me.myds, "News")
        Catch ex As Exception
            If ex.Message.GetHashCode = -1115812848 Or ex.Message.GetHashCode = 379362862 Then
                e.Cancel = True
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                e.Cancel = True
                TestNet = False
                Me.PictureBox2False()
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            ElseIf ex.Message.GetHashCode = -652120241 Or ex.Message.GetHashCode = 2067669773 Then
                Me.DelRow = True
                Me.PictureBox2False()
                MsgBox("قام احد المستخدمين بحذف السجل المحدد" & vbCrLf & "سوف يتم تحديث السجلات الآن", 16, "تنبيه")
            Else
                e.Cancel = True
                Me.PictureBox2False()
                MessageBox.Show(ex.Message, "ErrorSaveData_DoWork", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
=======
    Private Sub SaveData_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles SaveTab.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If DelRow = True Then
                Me.Button5.PerformClick()
                Exit Sub
            ElseIf e.Cancelled Then
                Exit Sub
            End If
            Application.DoEvents()

            Me.BS1.DataSource = Me.myds.Tables("News")
            Me.TextNewsText.Enabled = True
            Me.Button3.Enabled = True
            Me.Button5.Enabled = True
            Me.Cursor = Cursors.Default
            Me.PictureDovePeace.Visible = False
            SEAV = False
            If Me.BS1.Count < Me.RowCount2 Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين بحذف سجلات عدد " & Me.RowCount2 - Me.BS1.Count, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            ElseIf Me.BS1.Count > Me.RowCount2 Then
                MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح" & vbCrLf & " تنبيه : قام احد المستخدمين باضافة سجلات عدد " & Me.BS1.Count - Me.RowCount2, 64 + 524288, " نجاح الحفظ والتغييرات")
                Exit Sub
            End If
            MsgBox("تمت عملية الحفظ في قاعدة البيانات بنجاح", 64 + 524288, "نجاح الحفظ والتغييرات والتحديث")
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "ErrorRunWorkerCompleted", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Public Sub PictureBox2False()
        On Error Resume Next
        If Me.InvokeRequired Then
            Me.Invoke(New PictureBox2Callback(AddressOf Me.PictureBox2False), Array.Empty(Of Object)())
        Else
            Me.Cursor = Cursors.Default
            Me.PictureDovePeace.Visible = False
        End If
    End Sub

<<<<<<< HEAD
    Private Sub TestUserLogin_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles TestUserLogin.DoWork
        Try
            Using ConUsers As New SqlConnection(constring)
                Dim Users1 As New SqlCommand("SELECT ID, UserName, Pws, TimeEnter, MacAddress, LoginName, Realname, UserType, CUser, COUser, BlockUser, LockAddRow, LockDelete, LockSave, LockUpdate, Printpreview, TransferofAccounts, InternalAuditor, CollaborationManager, HeadofAuditingDepartment, ExternalAuditor, FileList, ListOFClients, CashAndMembers, ListOFAccounts, ListOFelectronicArchives, StaffMenu, Internet, RAdmin1 FROM Users", ConUsers)
                DataAdapterUsers = New SqlDataAdapter(Users1)
                Me.DataSetUsers.Clear()
                Me.DataSetUsers = New DataSet
                If ConUsers.State = ConnectionState.Closed Then ConUsers.Open()
                DataAdapterUsers.Fill(Me.DataSetUsers, "Users")
            End Using
        Catch ex As SqlException When ex.Number = -1968342016 OrElse ex.Number = -932284142 OrElse ex.Number = -1053942103
            Me.PictureBox2False()
            e.Cancel = True
        Catch ex As SqlException When ex.Number = 1718601380
            ' Retry logic or specific handling for this error
            ' GoTo 1 ' Avoid using GoTo, consider a loop or other control structure
        Catch ex As Exception
            e.Cancel = True
            MessageBox.Show(ex.Message, "Error checking permissions", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub TestUserLogin_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles TestUserLogin.RunWorkerCompleted
        Try
            If e.Cancelled OrElse DataSetUsers.Tables.Count = 0 Then Exit Sub

            TestNet = True
            HideConnectionLabels()
            If IsUserBlocked(USERNAME) Then
                HandleBlockedUser()
                Exit Sub
            End If

            'EnableMenusBasedOnPermissions()

            If Timer2.Enabled Then Timer2.Start()

            UpdateInternetStatus()
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  BlockUser =1").ToString) > 0 Then
                'عند حظر المستخدم يتم طرده مباشرة من البرنامج في حال كان داخل
                Me.DelUsersLogin = New BackgroundWorker With {
=======
    Private Sub TestUserLogin_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles TestUserLogin.DoWork
        Try

1:

            Dim ConUsers As New SqlClient.SqlConnection(constring1)
            Dim Users1 As New SqlCommand("SELECT ID ,UserName ,Pws  ,TimeEnter, MacAddress ,LoginName ,Realname ,UserType  ,CUser, COUser ,BlockUser,LockAddRow ,LockDelete,LockSave  ,LockUpdate,Printpreview, TransferofAccounts ,InternalAuditor ,CollaborationManager ,HeadofAuditingDepartment ,ExternalAuditor   ,FileList ,ListOFClients,CashAndMembers,ListOFAccounts,ListOFelectronicArchives,StaffMenu,Internet,RAdmin1 from Users", ConUsers)
            DataAdapterUsers = New SqlClient.SqlDataAdapter(Users1)
            Me.DataSetUsers.Clear()
            Me.DataSetUsers = New DataSet
            If ConUsers.State = ConnectionState.Open Then ConUsers.Close()
            ConUsers.Open()
            DataAdapterUsers.Fill(Me.DataSetUsers, "Users")
            If ConUsers.State = ConnectionState.Open Then
                ConUsers.Close()
            End If
        Catch ex As Exception
            If ex.Message.GetHashCode = -1968342016 Or ex.Message.GetHashCode = -932284142 Or ex.Message.GetHashCode = -1053942103 Then
                'TestNet = False
                Me.PictureBox2False()
                e.Cancel = True
            ElseIf ex.Message.GetHashCode = 1718601380 Then
                GoTo 1
            Else
                e.Cancel = True
                MessageBox.Show(ex.Message, "يوجد مشكلة في فحص الصلاحيات", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Finally
            Call CloseConUsers()
        End Try
    End Sub

    Private Sub TestUserLogin_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles TestUserLogin.RunWorkerCompleted
        Try
            If e.Cancelled Then Exit Sub
            If DataSetUsers.Tables.Count = 0 Then Exit Sub
            TestNet = True
            Me.PictureSearchConnection.Visible = False
            Me.LabelTast.Visible = False
            Me.LabelSearchServer.Visible = False
            Me.PictureSearchServer.Visible = False
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  BlockUser =1").ToString) > 0 Then
                'عند حظر المستخدم يتم طرده مباشرة من البرنامج في حال كان داخل
                Me.DelUsersLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                            .WorkerReportsProgress = True,
                            .WorkerSupportsCancellation = True
                        }
                Me.DelUsersLogin.RunWorkerAsync()
                Insert_Actions(Me.BS.Position + 1, "حاول الدخول مستخدم محظور", AssociationName)
                Exit Sub
            End If

            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  FileList=1").ToString) > 0 Then
                RowCount1 = DataSetUsers.Tables("Users").Rows.Count
                Me.LabelUsersNumber.Text = "عدد المسجلين  " & RowCount1
                ModuleGeneral.Lists = True
                Me.CMENU1.Enabled = True
                Me.CMENU4.Enabled = True
                Me.CMENU7.Enabled = True
                Me.CMENU8.Enabled = True
                Me.CMENU9.Enabled = True
                Me.CMNUCASHIER.Enabled = True
                Me.CMENU10.Enabled = True
                Me.CMENU11.Enabled = True
                Me.CMENU12.Enabled = True
                Me.CMENU13.Enabled = True
                Me.CMENU14.Enabled = True
                Me.CMENU15.Enabled = True
                Me.CMENU16.Enabled = True
                Me.CMENU17.Enabled = True
                Me.CMENU18.Enabled = True
                Me.TBUTTON5.Enabled = True
                Me.men56.Enabled = True
                'ملف
                Me.men12.Enabled = True
                Me.men13.Enabled = True
                Me.men121.Enabled = True
                Me.men122.Enabled = True


            Else
                ModuleGeneral.Lists = False
                Me.TBUTTON5.Enabled = False
                Me.men56.Enabled = False
            End If
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  ListOFClients=1").ToString) > 0 Then
                'عملاء
                ModuleGeneral.Lists1 = True
                Me.men21.Enabled = True
                Me.men22.Enabled = True
                Me.men23.Enabled = True
                Me.men24.Enabled = True
                Me.men26.Enabled = True
                Me.men271.Enabled = True
                Me.men28.Enabled = True
                Me.men213.Enabled = True
                Me.men215.Enabled = True
                Me.men216.Enabled = True
            Else
                ModuleGeneral.Lists1 = False
            End If
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  CashAndMembers=1").ToString) > 0 Then
                'البنوك
                ModuleGeneral.Lists2 = True
                Me.men31.Enabled = True
                Me.men311.Enabled = True
                Me.men32.Enabled = True
                Me.men321.Enabled = True
                Me.men322.Enabled = True
                Me.men3221.Enabled = True
                Me.men3222.Enabled = True
                Me.men3223.Enabled = True
                Me.men323.Enabled = True
                Me.men3231.Enabled = True
                Me.men3232.Enabled = True
                Me.men3233.Enabled = True
                Me.men3233.Enabled = True
                Me.men3235.Enabled = True
                Me.men3236.Enabled = True
                Me.men33.Enabled = True
                Me.men331.Enabled = True
                Me.men34.Enabled = True
                Me.men35.Enabled = True
                Me.men351.Enabled = True
                Me.men36.Enabled = True
                Me.men37.Enabled = True
                Me.men38.Enabled = True
            Else
                ModuleGeneral.Lists2 = False
            End If
            '==============================
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  ListOFAccounts=1").ToString) > 0 Then
                'الحسابات
                ModuleGeneral.Lists3 = True
                Me.men41.Enabled = True
                Me.men42.Enabled = True
                Me.men422.Enabled = True
                Me.men4221.Enabled = True
                Me.men4222.Enabled = True
                Me.men4223.Enabled = True
                Me.men43.Enabled = True
                Me.men431.Enabled = True
                Me.men4311.Enabled = True
                Me.men4312.Enabled = True
                Me.men4313.Enabled = True
                Me.men4314.Enabled = True
                Me.men433.Enabled = True
                Me.men434.Enabled = True
                Me.men4341.Enabled = True
                Me.men4342.Enabled = True
                Me.men4343.Enabled = True
                Me.men4344.Enabled = True
                Me.men44.Enabled = True
                Me.men441.Enabled = True
                Me.men4411.Enabled = True
                Me.men4412.Enabled = True
                Me.men4413.Enabled = True
                Me.men4414.Enabled = True
                Me.men442.Enabled = True
                Me.men4421.Enabled = True
                Me.men4422.Enabled = True
                Me.men4423.Enabled = True
                Me.men4424.Enabled = True
                Me.men45.Enabled = True
                Me.men46.Enabled = True
                Me.men47.Enabled = True
                Me.men48.Enabled = True
                Me.men49.Enabled = True
                Me.men50.Enabled = True
                Me.men601.Enabled = True
            Else
                ModuleGeneral.Lists3 = False
            End If
            '==============================
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  ListOFelectronicArchives=1").ToString) > 0 Then
                '   الارشيف الالكترونى
                ModuleGeneral.Lists4 = True
                Me.men61.Enabled = True
                Me.men62.Enabled = True
                Me.men63.Enabled = True
                Me.men64.Enabled = True
                Me.men65.Enabled = True
            Else
                ModuleGeneral.Lists4 = False
            End If
            '==============================
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  StaffMenu=1").ToString) > 0 Then
                ' الموظفين 
                ModuleGeneral.Lists5 = True
                Me.men71.Enabled = True
                Me.men72.Enabled = True
                Me.men73.Enabled = True
                Me.men74.Enabled = True
                Me.men75.Enabled = True
                Me.men76.Enabled = True
                'Me.men77.Enabled = True
                Me.men78.Enabled = True
                Me.men79.Enabled = True
            Else
                ModuleGeneral.Lists5 = False
            End If
            '==============================
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  Internet=1").ToString) > 0 Then
                ' الانترنت
                ModuleGeneral.Lists6 = True
                Me.men87.Enabled = True
                Me.men88.Enabled = True
                Me.men92.Enabled = True
            Else
                ModuleGeneral.Lists6 = False
            End If
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  TransferofAccounts=1").ToString) > 0 Then
                ModuleGeneral.Lists7 = True
                Me.men121.Enabled = True
            Else
                ModuleGeneral.Lists7 = False
                'Me.men121.ForeColor = Color.Red
                Me.men121.Enabled = False
            End If

            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  InternalAuditor=1").ToString) > 0 Then
                Me.men601.Enabled = False
                Me.men602.Enabled = True
                Me.men211.Enabled = False
                Me.men221.Enabled = False
                Me.men231.Enabled = False
                Me.men241.Enabled = False
                Me.men251.Enabled = False
                Me.men261.Enabled = False
                Me.men2711.Enabled = False
                Me.men277.Enabled = False
                Me.men2721.Enabled = False
                Me.men2741.Enabled = False
                Me.men2751.Enabled = False
                Me.men333.Enabled = False
                Me.men325.Enabled = False
                Me.men311.Enabled = False
                Me.men341.Enabled = False
                Me.men361.Enabled = False
                Me.men351.Enabled = False
                Me.men421.Enabled = False
                Me.men4421.Enabled = False
                Me.men4422.Enabled = False
                Me.men4411.Enabled = False
                Me.men4412.Enabled = False
                Me.men44141.Enabled = False
                Me.men472.Enabled = False
                Me.men61.Enabled = False
                Me.men65.Enabled = False
                Me.men67.Enabled = False '27
                Me.men78.Enabled = False '28
                Me.men79.Enabled = True '29
                Me.CMENU16.Enabled = False
                Me.CMENU17.Enabled = False
                Me.CMENU18.Enabled = False
            Else
                Me.men602.Enabled = False
            End If
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  CollaborationManager=1").ToString) > 0 Then
                Me.men601.Enabled = False
                Me.men603.Enabled = True
                Me.men211.Enabled = False '1
                Me.men221.Enabled = False '2
                Me.men231.Enabled = False '3
                Me.men241.Enabled = False '4
                Me.men251.Enabled = False '5
                Me.men261.Enabled = False '6
                Me.men2711.Enabled = False '7
                Me.men277.Enabled = False '8
                Me.men2721.Enabled = False '9
                Me.men2741.Enabled = False '10
                Me.men2751.Enabled = False '11
                Me.men333.Enabled = False '12
                Me.men325.Enabled = False '13
                Me.men311.Enabled = False '14
                Me.men341.Enabled = False '15
                Me.men361.Enabled = False '16
                Me.men351.Enabled = False '17
                Me.men421.Enabled = False '18
                Me.men4421.Enabled = False '19
                Me.men4422.Enabled = False '20
                Me.men4411.Enabled = False '21
                Me.men4412.Enabled = False '22
                Me.men44141.Enabled = False '23
                Me.men472.Enabled = False '24
                Me.men61.Enabled = False '25
                Me.men65.Enabled = False '26
                Me.men67.Enabled = False '27
                Me.men77.Enabled = True
                Me.men78.Enabled = True '28
                Me.men79.Enabled = True '29
                Me.CMENU16.Enabled = False
                Me.CMENU17.Enabled = False
                Me.CMENU18.Enabled = False
            Else
                Me.men603.Enabled = False
                'Me.men77.Enabled = False
            End If

            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  HeadofAuditingDepartment=1").ToString) > 0 Then
                Me.men601.Enabled = False
                Me.men604.Enabled = True
                Me.men211.Enabled = False
                Me.men221.Enabled = False
                Me.men231.Enabled = False
                Me.men241.Enabled = False
                Me.men251.Enabled = False
                Me.men261.Enabled = False
                Me.men2711.Enabled = False
                Me.men277.Enabled = False
                Me.men2721.Enabled = False
                Me.men2741.Enabled = False
                Me.men2751.Enabled = False
                Me.men333.Enabled = False
                Me.men325.Enabled = False
                Me.men311.Enabled = False
                Me.men341.Enabled = False
                Me.men361.Enabled = False
                Me.men351.Enabled = False
                Me.men421.Enabled = False
                Me.men4421.Enabled = False
                Me.men4422.Enabled = False
                Me.men4411.Enabled = False
                Me.men4412.Enabled = False
                Me.men44141.Enabled = False
                Me.men472.Enabled = False
                Me.men61.Enabled = False
                Me.men65.Enabled = False
                Me.men67.Enabled = False '27
                Me.men77.Enabled = True
                Me.men78.Enabled = False '28
                Me.men79.Enabled = True '29
                Me.CMENU16.Enabled = False
                Me.CMENU17.Enabled = False
                Me.CMENU18.Enabled = False
            Else
                Me.men604.Enabled = False
                'Me.men77.Enabled = False
            End If
<<<<<<< HEAD

=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  ExternalAuditor=1").ToString) > 0 Then
                Me.men601.Enabled = False
                Me.men605.Enabled = True
                Me.men211.Enabled = False
                Me.men221.Enabled = False
                Me.men231.Enabled = False
                Me.men241.Enabled = False
                Me.men251.Enabled = False
                Me.men261.Enabled = False
                Me.men2711.Enabled = False
                Me.men277.Enabled = False
                Me.men2721.Enabled = False
                Me.men2741.Enabled = False
                Me.men2751.Enabled = False
                Me.men333.Enabled = False
                Me.men325.Enabled = False
                Me.men311.Enabled = False
                Me.men341.Enabled = False
                Me.men361.Enabled = False
                Me.men351.Enabled = False
                Me.men421.Enabled = False
                Me.men4421.Enabled = False
                Me.men4422.Enabled = False
                Me.men4411.Enabled = False
                Me.men4412.Enabled = False
                Me.men44141.Enabled = False
                Me.men472.Enabled = False
                Me.men61.Enabled = False
                Me.men65.Enabled = False
                Me.men67.Enabled = False '27
                Me.men78.Enabled = False '28
                Me.men79.Enabled = True '29
                Me.CMENU16.Enabled = False
                Me.CMENU17.Enabled = False
                Me.CMENU18.Enabled = False
            Else
                Me.men605.Enabled = False

            End If

            If CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", "UserName like '" & USERNAME & "' and  RAdmin1=1").ToString) > 0 Then
                Me.men14.Enabled = True
                Me.men16.Enabled = True
                Me.men17.Enabled = True
                Me.men77.Enabled = True
                Me.men111.Enabled = True
                Me.men112.Enabled = True
                Me.men151.Enabled = True
                Me.men152.Enabled = True
            Else
                ModuleGeneral.Lists7 = False
                Me.men16.Enabled = False
                Me.men17.Enabled = False
                Me.men111.Enabled = False
                Me.men112.Enabled = False
                Me.men151.Enabled = False
                Me.men152.Enabled = False
                'Me.men77.Enabled = False
            End If
<<<<<<< HEAD

=======
            If Me.Timer2.Enabled = True Then
                Me.Timer2.Start()
            End If

            'IsConnectedToInternet()

            If OnLine = True Then
                'OnLine = True
                'ImageList1.ImageSize = New Size(24, 24)
                Me.LabelConnectedToInternet.BackColor = Color.Transparent
                Me.LabelSearchConnection.Visible = False
                Me.LabelConnectedToInternet.Text = "  OnLine"
                Me.LabelConnectedToInternet.ForeColor = Color.Black
            ElseIf OnLine = False Then
                'OnLine = False
                'ImageList1.ImageSize = New Size(32, 32)
                Me.LabelConnectedToInternet.Image = ImageList1.Images(4)
                Me.LabelConnectedToInternet.BackColor = Color.IndianRed
                Me.LabelConnectedToInternet.Text = "  OffLine"
                Me.LabelConnectedToInternet.ForeColor = Color.White
                Me.LabelSearchConnection.Visible = False
            End If
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Catch ex As Exception
            'MessageBox.Show(ex.Message, "يوجد مشكلة في اتصال المستخدمين ", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'ConUsers.Close()
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub HideConnectionLabels()
        Me.PictureSearchConnection.Visible = False
        Me.LabelTast.Visible = False
        Me.LabelSearchServer.Visible = False
        Me.PictureSearchServer.Visible = False
    End Sub

    Private Function IsUserBlocked(username As String) As Boolean
        Return CInt(DataSetUsers.Tables("Users").Compute("Count(UserName)", $"UserName = '{username}' AND BlockUser = 1")) > 0
    End Function

    Private Sub HandleBlockedUser()
        Me.DelUsersLogin = New BackgroundWorker With {
          .WorkerReportsProgress = True,
          .WorkerSupportsCancellation = True
      }
        Me.DelUsersLogin.RunWorkerAsync()
        Insert_Actions(Me.BS.Position + 1, "Blocked user attempted login", AssociationName)
    End Sub

    'Private Sub EnableMenusBasedOnPermissions()
    '    EnableMenu(Me.CMENU1, "FileList")
    '    EnableMenu(Me.CMENU4, "FileList")
    '    EnableMenu(Me.CMENU7, "FileList")
    '    EnableMenu(Me.CMENU8, "FileList")
    '    EnableMenu(Me.CMENU9, "FileList")
    '    EnableMenu(Me.CMNUCASHIER, "FileList")
    '    EnableMenu(Me.CMENU10, "FileList")
    '    EnableMenu(Me.CMENU11, "FileList")
    '    EnableMenu(Me.CMENU12, "FileList")
    '    EnableMenu(Me.CMENU13, "FileList")
    '    EnableMenu(Me.CMENU14, "FileList")
    '    EnableMenu(Me.CMENU15, "FileList")
    '    EnableMenu(Me.CMENU16, "FileList")
    '    EnableMenu(Me.CMENU17, "FileList")
    '    EnableMenu(Me.CMENU18, "FileList")
    '    Me.TBUTTON5.Enabled = ModuleGeneral.Lists
    '    Me.men56.Enabled = ModuleGeneral.Lists

    '    EnableMenu(Me.men2, "ListOFClients")
    '    EnableMenu(Me.men22, "ListOFClients")
    '    EnableMenu(Me.men23, "ListOFClients")
    '    EnableMenu(Me.men24, "ListOFClients")
    '    EnableMenu(Me.men26, "ListOFClients")
    '    EnableMenu(Me.men271, "ListOFClients")
    '    EnableMenu(Me.men28, "ListOFClients")
    '    EnableMenu(Me.men213, "ListOFClients")
    '    EnableMenu(Me.men215, "ListOFClients")
    '    EnableMenu(Me.men216, "ListOFClients")

    '    EnableMenu(Me.men31, "CashAndMembers")
    '    EnableMenu(Me.men311, "CashAndMembers")
    '    EnableMenu(Me.men32, "CashAndMembers")
    '    EnableMenu(Me.men321, "CashAndMembers")
    '    EnableMenu(Me.men322, "CashAndMembers")
    '    EnableMenu(Me.men3221, "CashAndMembers")
    '    EnableMenu(Me.men3222, "CashAndMembers")
    '    EnableMenu(Me.men3223, "CashAndMembers")
    '    EnableMenu(Me.men323, "CashAndMembers")
    '    EnableMenu(Me.men3231, "CashAndMembers")
    '    EnableMenu(Me.men3232, "CashAndMembers")
    '    EnableMenu(Me.men3233, "CashAndMembers")
    '    EnableMenu(Me.men3235, "CashAndMembers")
    '    EnableMenu(Me.men3236, "CashAndMembers")
    '    EnableMenu(Me.men33, "CashAndMembers")
    '    EnableMenu(Me.men331, "CashAndMembers")
    '    EnableMenu(Me.men34, "CashAndMembers")
    '    EnableMenu(Me.men35, "CashAndMembers")
    '    EnableMenu(Me.men351, "CashAndMembers")
    '    EnableMenu(Me.men36, "CashAndMembers")
    '    EnableMenu(Me.men37, "CashAndMembers")
    '    EnableMenu(Me.men38, "CashAndMembers")

    '    EnableMenu(Me.men41, "ListOFAccounts")
    '    EnableMenu(Me.men42, "ListOFAccounts")
    '    EnableMenu(Me.men422, "ListOFAccounts")
    '    EnableMenu(Me.men4221, "ListOFAccounts")
    '    EnableMenu(Me.men4222, "ListOFAccounts")
    '    EnableMenu(Me.men4223, "ListOFAccounts")
    '    EnableMenu(Me.men43, "ListOFAccounts")
    '    EnableMenu(Me.men431, "ListOFAccounts")
    '    EnableMenu(Me.men4311, "ListOFAccounts")
    '    EnableMenu(Me.men4312, "ListOFAccounts")
    '    EnableMenu(Me.men4313, "ListOFAccounts")
    '    EnableMenu(Me.men4314, "ListOFAccounts")
    '    EnableMenu(Me.men433, "ListOFAccounts")
    '    EnableMenu(Me.men434, "ListOFAccounts")
    '    EnableMenu(Me.men4341, "ListOFAccounts")
    '    EnableMenu(Me.men4342, "ListOFAccounts")
    '    EnableMenu(Me.men4343, "ListOFAccounts")
    '    EnableMenu(Me.men4344, "ListOFAccounts")
    '    EnableMenu(Me.men44, "ListOFAccounts")
    '    EnableMenu(Me.men441, "ListOFAccounts")
    '    EnableMenu(Me.men4411, "ListOFAccounts")
    '    EnableMenu(Me.men4412, "ListOFAccounts")
    '    EnableMenu(Me.men4413, "ListOFAccounts")
    '    EnableMenu(Me.men4414, "ListOFAccounts")
    '    EnableMenu(Me.men442, "ListOFAccounts")
    '    EnableMenu(Me.men4421, "ListOFAccounts")
    '    EnableMenu(Me.men4422, "ListOFAccounts")
    '    EnableMenu(Me.men4423, "ListOFAccounts")
    '    EnableMenu(Me.men4424, "ListOFAccounts")

    '    EnableMenu(Me.men45, "ListOFAccounts")
    '    EnableMenu(Me.men46, "ListOFAccounts")
    '    EnableMenu(Me.men47, "ListOFAccounts")
    '    EnableMenu(Me.men48, "ListOFAccounts")
    '    EnableMenu(Me.men49, "ListOFAccounts")
    '    EnableMenu(Me.men50, "ListOFAccounts")
    '    EnableMenu(Me.men601, "ListOFAccounts")
    '    EnableMenu(Me.men61, "ListOFelectronicArchives")
    '    EnableMenu(Me.men62, "ListOFelectronicArchives")
    '    EnableMenu(Me.men63, "ListOFelectronicArchives")
    '    EnableMenu(Me.men64, "ListOFelectronicArchives")
    '    EnableMenu(Me.men65, "ListOFelectronicArchives")

    '    EnableMenu(Me.men71, "StaffMenu")
    '    EnableMenu(Me.men72, "StaffMenu")
    '    EnableMenu(Me.men73, "StaffMenu")
    '    EnableMenu(Me.men74, "StaffMenu")
    '    EnableMenu(Me.men75, "StaffMenu")
    '    EnableMenu(Me.men76, "StaffMenu")
    '    EnableMenu(Me.men78, "StaffMenu")
    '    EnableMenu(Me.men79, "StaffMenu")

    '    EnableMenu(Me.men87, "Internet")
    '    EnableMenu(Me.men88, "Internet")
    '    EnableMenu(Me.men92, "Internet")

    '    EnableMenu(Me.men121, "TransferofAccounts")

    '    EnableMenu(Me.men602, "InternalAuditor")
    '    EnableMenu(Me.men603, "CollaborationManager")
    '    EnableMenu(Me.men604, "HeadofAuditingDepartment")
    '    EnableMenu(Me.men605, "ExternalAuditor")

    '    EnableMenu(Me.men14, "RAdmin1")
    '    EnableMenu(Me.men16, "RAdmin1")
    '    EnableMenu(Me.men17, "RAdmin1")
    '    EnableMenu(Me.men77, "RAdmin1")
    '    EnableMenu(Me.men111, "RAdmin1")
    '    EnableMenu(Me.men112, "RAdmin1")
    '    EnableMenu(Me.men151, "RAdmin1")
    '    EnableMenu(Me.men152, "RAdmin1")
    'End Sub

    Private Sub EnableMenu(menu As ToolStripMenuItem, permission As String)
        menu.Enabled = CInt(DataSetUsers.Tables("Users").Compute($"Count(UserName)", $"UserName = '{USERNAME}' AND {permission} = 1")) > 0
    End Sub

    Private Sub UpdateInternetStatus()
        If OnLine Then
            Me.LabelConnectedToInternet.BackColor = Color.Transparent
            Me.LabelSearchConnection.Visible = False
            Me.LabelConnectedToInternet.Text = "  OnLine"
            Me.LabelConnectedToInternet.ForeColor = Color.Black
        Else
            Me.LabelConnectedToInternet.Image = ImageList1.Images(4)
            Me.LabelConnectedToInternet.BackColor = Color.IndianRed
            Me.LabelConnectedToInternet.Text = "  OffLine"
            Me.LabelConnectedToInternet.ForeColor = Color.White
            Me.LabelSearchConnection.Visible = False
        End If
    End Sub


=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Private Sub REGDATAIN_REGISTERY()
        On Error Resume Next
        MdlConnection.DBServer = MdlConnection.DBServer
        If Consum.State <> ConnectionState.Open Then
            constring = Consum.ConnectionString
            constring1 = ConUsers.ConnectionString
        End If
        mykey.SetValue("MYDATABASE1", MdlConnection.DBServer.ToString.Trim)
    End Sub

    Public Sub ComboGovernorateName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGovernorateName.SelectedIndexChanged
        Try
<<<<<<< HEAD
            Dim Adp As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim SQL_Governorat As New SqlCommand("Select  ID_Governorate FROM Governorates where GovernorateName = '" & Me.ComboGovernorateName.Text & "'", Consum)
            Dim dt As New DataTable
            Adp = New SqlDataAdapter(SQL_Governorat)
=======
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL_Governorat As New SqlCommand("Select  ID_Governorate FROM Governorates where GovernorateName = '" & Me.ComboGovernorateName.Text & "'", Consum)
            Dim dt As New DataTable
            Adp = New SqlClient.SqlDataAdapter(SQL_Governorat)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            dt.Clear()
            Consum.Open()
            Adp.Fill(dt)
            If dt.Rows.Count = 0 Then Exit Sub
            COUser = dt.Rows(0).Item(0)
            GetAssociationName(Me.ComboGovernorateName.Text)
            Directorate = Me.ComboGovernorateName.Text 'المديرية/المحافظة
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboGovernorat_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Sub ComboGetAssociationName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboGetAssociationName.EditValueChanged
        Try
<<<<<<< HEAD
            Dim Adp As SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            Dim SQL_COMPANY As New SqlCommand("select cmp3, cmp4, cmp5, cmp8, cmp9, cmp13, CUser, COUser from COMPANY where Trim(cmp2) = '" & Me.ComboGetAssociationName.Text.Trim & "'", Consum)
            Dim dt1 As New DataTable
            Adp = New SqlDataAdapter(SQL_COMPANY)
=======
            Dim Adp As SqlClient.SqlDataAdapter
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim SQL_COMPANY As New SqlCommand("select cmp3, cmp4, cmp5, cmp8, cmp9, cmp13, CUser, COUser from COMPANY where Trim(cmp2) = '" & Me.ComboGetAssociationName.Text.Trim & "'", Consum)
            Dim dt1 As New DataTable
            Adp = New SqlClient.SqlDataAdapter(SQL_COMPANY)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            dt1.Clear()
            Consum.Open()
            Adp.Fill(dt1)
            If dt1.Rows.Count = 0 Then Exit Sub
            ModuleGeneral.CUser = dt1.Rows(0).Item("CUser")
            ModuleGeneral.COUser = dt1.Rows(0).Item("COUser")
            AssociationName = ComboGetAssociationName.Text ' اسم الجمعية
            Label_Cuser.Text = ModuleGeneral.CUser
            Adrss = dt1.Rows(0).Item("cmp3")
            Phone = dt1.Rows(0).Item("cmp4")
            Recorded = dt1.Rows(0).Item("cmp5")
            Directorate = dt1.Rows(0).Item("cmp8")
            Phone1 = dt1.Rows(0).Item("cmp9")
            BANSL = dt1.Rows(0).Item("cmp13")
            Me.LabelBANSL.Text = Val(BANSL)
            Adp.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorComboGetAssociationName_SelectedIndexChanged", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub GetAssociationName(ByVal GovernorateName As String)
        Try
<<<<<<< HEAD
            Dim Adp As SqlDataAdapter
            'On Error Resume Next
            Dim Consum As New SqlConnection(constring)
            Dim AssociationName1 As New SqlCommand("select CMP,cmp2 from COMPANY where cmp8 = '" & GovernorateName & "'", Consum)
            DsCOMPANY = New DataSet
            Adp = New SqlDataAdapter(AssociationName1)
=======
            Dim Adp As SqlClient.SqlDataAdapter
            'On Error Resume Next
            Dim Consum As New SqlClient.SqlConnection(constring)
            Dim AssociationName1 As New SqlCommand("select CMP,cmp2 from COMPANY where cmp8 = '" & GovernorateName & "'", Consum)
            DsCOMPANY = New DataSet
            Adp = New SqlClient.SqlDataAdapter(AssociationName1)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            DsCOMPANY.Clear()
            Consum.Open()
            Adp.Fill(DsCOMPANY, "COMPANY")
            Consum.Close()
            ComboGetAssociationName.Properties.DataSource = DsCOMPANY.Tables(0)
            ComboGetAssociationName.Properties.ValueMember = "CMP"
            ComboGetAssociationName.Properties.DisplayMember = "cmp2"
            'ComboGetAssociationName.EditValue = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, "ErrorGetAssociationName", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SHOWMAIN5()
        On Error Resume Next
        Me.CMENU1.Enabled = False
        Me.CMENU4.Enabled = False
        Me.CMENU7.Enabled = False
        Me.CMENU8.Enabled = False
        Me.CMENU9.Enabled = False
        Me.CMNUCASHIER.Enabled = False
        Me.CMENU10.Enabled = False
        Me.CMENU11.Enabled = False
        Me.CMENU12.Enabled = False
        Me.CMENU13.Enabled = False
        Me.CMENU14.Enabled = False
        Me.CMENU15.Enabled = False
        Me.CMENU16.Enabled = False
        Me.CMENU17.Enabled = False
        Me.CMENU18.Enabled = False
        Me.TBUTTON5.Enabled = False
        Me.men56.Enabled = False
        ' الانترنت
        Me.men87.Enabled = False
        Me.men88.Enabled = False
        Me.men92.Enabled = False
        'الموظفين
        Me.men71.Enabled = False
        Me.men72.Enabled = False
        Me.men73.Enabled = False
        Me.men74.Enabled = False
        Me.men75.Enabled = False
        Me.men76.Enabled = False
        Me.men77.Enabled = False
        Me.men78.Enabled = False
        Me.men79.Enabled = False
        'الارشيف الالكترونى
        Me.men61.Enabled = False
        Me.men62.Enabled = False
        Me.men64.Enabled = False
        Me.men65.Enabled = False

        'الحسابات
        Me.men41.Enabled = False
        Me.men42.Enabled = False
        Me.men43.Enabled = False
        Me.men44.Enabled = False
        Me.men45.Enabled = False
        Me.men46.Enabled = False
        Me.men47.Enabled = False
        Me.men48.Enabled = False
        Me.men49.Enabled = False
        Me.men50.Enabled = False

        Me.men601.Enabled = False
        Me.men602.Enabled = False
        Me.men603.Enabled = False
        Me.men604.Enabled = False
        Me.men605.Enabled = False
        'فاتـورة 
        Me.men441.Enabled = False
        Me.men4411.Enabled = False
        Me.men4412.Enabled = False
        Me.men4413.Enabled = False
        Me.men4414.Enabled = False
        Me.men442.Enabled = False
        Me.men4421.Enabled = False
        Me.men4422.Enabled = False
        Me.men4423.Enabled = False
        Me.men4424.Enabled = False
        'أحصائيات
        Me.men431.Enabled = False
        Me.men4311.Enabled = False
        Me.men4312.Enabled = False
        Me.men4313.Enabled = False
        Me.men4314.Enabled = False
        Me.men422.Enabled = False
        Me.men4221.Enabled = False
        Me.men4222.Enabled = False
        Me.men4223.Enabled = False
        Me.men433.Enabled = False
        Me.men434.Enabled = False
        'البنوك والجمعيات
        Me.men31.Enabled = False
        Me.men32.Enabled = False
        Me.men33.Enabled = False
        Me.men34.Enabled = False
        Me.men35.Enabled = False
        Me.men36.Enabled = False
        Me.men37.Enabled = False
        Me.men38.Enabled = False
        'العملاء والموردين
        Me.men21.Enabled = False
        Me.men22.Enabled = False
        Me.men23.Enabled = False
        Me.men24.Enabled = False
        Me.men26.Enabled = False
        Me.men271.Enabled = False
        Me.men28.Enabled = False
        Me.men213.Enabled = False
        Me.men215.Enabled = False
        Me.men216.Enabled = False
        'ملف

        Me.men12.Enabled = False
        Me.men13.Enabled = False
        Me.men14.Enabled = False
        Me.men16.Enabled = False
        Me.men17.Enabled = False
        Me.men111.Enabled = False
        Me.men112.Enabled = False
        Me.men151.Enabled = False
        Me.men152.Enabled = False

        Me.men121.Enabled = False
        Me.men122.Enabled = False
    End Sub

<<<<<<< HEAD
    Private Sub DelUsersLogin_DoWork(ByVal sender As Object, ByVal e As DoWorkEventArgs) Handles DelUsersLogin.DoWork
        Try
            Dim DelUsers As New SqlConnection(constring)
=======
    Private Sub DelUsersLogin_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles DelUsersLogin.DoWork
        Try
            Dim DelUsers As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim DEL As New SqlCommand("UPDATE Users SET LoginName = null, MacAddress = null WHERE LoginName =N'" & USERNAME & "'", DelUsers)
            If DelUsers.State = ConnectionState.Closed Then
                DelUsers.Open()
            End If
            DEL.ExecuteNonQuery()

            If DelUsers.State = ConnectionState.Open Then
                DelUsers.Close()
            End If
            BACKUPClos()
        Catch Ex As Exception
            If DelUsers.State = ConnectionState.Open Then
                DelUsers.Close()
            End If
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

<<<<<<< HEAD
    Private Sub DelUsersLogin_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles DelUsersLogin.RunWorkerCompleted
=======
    Private Sub DelUsersLogin_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles DelUsersLogin.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Insert_Actions(BS.Position + 1, "وقت الخروج", AssociationName)
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorDelUsersLogin", MessageBoxButtons.OK, MessageBoxIcon.Error)

        'End Try
        End
    End Sub

    Sub BACKUPClos()
        On Error Resume Next
        Dim resault1 As String
        resault1 = CStr(mykey.GetValue("BACKUP", "NO"))
        If resault1 = "YES" Then
            Backup_database(DBServer)
        Else
        End If
        mykey.Close()
    End Sub

<<<<<<< HEAD
    Private Sub TextSearch_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles TextSearch.KeyPress
=======
    Private Sub TextSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextSearch.KeyPress
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        If Asc(e.KeyChar) = 13 Then
            Button4.PerformClick()
            e.Handled = True
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        On Error Resume Next
        'Application.DoEvents()
        'Me.NEWEVENTS.Left += 1
        'If Me.NEWEVENTS.Left = Val(Me.NEWEVENTS.ToString.Length) + 893 Then
        '    Me.NEWEVENTS.Left = -893
        'End If
        'DataTableToValueList(DataSetTab66.Tables("News"), BindingSourceTab66.Current("Ne3"))
        If Me.NEWEVENTS.Left >= Me.PanelNEWEVENTS.Width Then Me.NEWEVENTS.Left = 0 - Me.NEWEVENTS.Width
        Me.NEWEVENTS.Left += 1
        'If Me.LOGOH1.Left >= Me.PanelNEWEVENTS.Width Then Me.LOGOH1.Left = 0 - Me.LOGOH1.Width
        'Me.LOGOH1.Left += 1


        'LOGOH1.Left = LOGOH1.Left - 1
        'If LOGOH1.Left < 0 - LOGOH1.Width Then
        '    LOGOH1.Left += 1
        'End If


        'Dim strArr() As String
        'Dim Str1 As String = NEWEVENTS.Text & ("       " & "|" & "       ")
        'strArr = Str1.Split("|")
        'If strArr(1) = "       " Then
        '    'If Me.LabelNEWEVENTS.Left >= Me.PanelNEWEVENTS.Width Then Me.LabelNEWEVENTS.Left = 0 - Me.LabelNEWEVENTS.Width
        '    'Me.LabelNEWEVENTS.Left += 1
        '    'MsgBox(Str1.ToString)
        '    NEWEVENTS.Image = LOGOH1.Image
        'Else
        '    NEWEVENTS.Image = LOGOH1.Image
        '    'MsgBox(1)
        '    'If Me.LabelNEWEVENTS.Left >= Me.PanelNEWEVENTS.Width Then Me.LabelNEWEVENTS.Left = 0 - Me.LabelNEWEVENTS.Width
        '    'Me.LabelNEWEVENTS.Left += 1
        'End If
        'Next

    End Sub

    Private Sub NEWSBAR1()
        Dim dt As New DataTable
        Me.myds = New DataSet
        Me.SqlDataAdapter1.Fill(Me.myds, "News")
        Me.SqlDataAdapter1.Fill(dt)
        Me.NEWEVENTS.Left = 0 - Me.NEWEVENTS.Width

        For g As Integer = 0 To dt.Rows.Count - 1
            NEWEVENTS.Text &= " " & dt(g)("Ne3") & ("       " & "|" & "       ")
            'For I = 0 To CInt(Me.BS1.Count)
            '    NEWEVENTS.Image = LOGOH1.Image
            'Next
        Next

        Me.Timer2.Start()
    End Sub

    Private Sub NEWSBAR()
        On Error Resume Next
        'Dim values As List(Of String) = New List(Of String)()
        'Dim Consum As New SqlClient.SqlConnection(constring)
        'Dim News As New SqlCommand("SELECT Ne1,Ne2 ,Ne3 from News order by Ne1", Consum)
        'Connection.DataAdapterTab66 = New SqlClient.SqlDataAdapter(News)
        'Dim builder68 As New SqlCommandBuilder(Connection.DataAdapterTab66)
        'DataSetTab66 = New DataSet
        'If Consum.State = ConnectionState.Open Then Consum.Close()
        'Consum.Open()
        'Connection.DataAdapterTab66.Fill(Me.myds, "News")
        'If Consum.State = ConnectionState.Open Then
        '    Consum.Close()
        'End If

        'Me.BS1.DataSource = Me.myds.Tables("News")
        'Me.RowCount = BindingSourceTab66.Count
        ''textTo.ToList.DataBindings.Add("text", BindingSourceTab66, "Ne3", True, 1, "")
        'Dim L1 As Image = Me.ImageList2.Images(0)

        'Me.NEWEVENTS.Text = Me.NEWEVENTS.Text + " " + "@" + " " + BindingSourceTab66.Current("Ne3") + " "

        ''Return


        'Me.NEWEVENTS.Left = -600
        'Me.Timer2.Start()
        'Consum.Close()
        'ConPowers.Close()
    End Sub

    'Friend Function DataTableToValueList(ByVal table As DataTable, ByVal columnName As String) As List(Of String)

    '    On Error Resume Next
    '    PictureBox3.BackColor = Color.Transparent
    '    BindingSourceTab66.DataSource = DataSetTab66.Tables("News")
    '    RowCount = BindingSourceTab66.Count
    '    table = DataSetTab66.Tables("News")
    '    columnName = BindingSourceTab66.Current("Ne3")

    '    Dim values As List(Of String) = New List(Of String)()
    '    SyncLock table.GetType
    '        For i As Integer = 0 To table.Rows.Count - 1
    '            Dim value As String = CStr(table.Rows(i)(columnName))
    '            values.Add(value)

    '            Me.NEWEVENTS.Text = "   الاخبار : " + values.Item(0)
    '            Me.NEWEVENTS.Text = Me.NEWEVENTS.Text + "   الاخبار : " + values.Item(0)
    '        Next
    '        Return values
    '    End SyncLock
    'End Function

    Private Sub HIDEMAIN5(ByVal FLAG As Boolean)
        On Error Resume Next
        Me.CMENU4.Enabled = FLAG
        Me.CMENU1.Enabled = FLAG
        Me.CMENU7.Enabled = FLAG
        Me.CMENU8.Enabled = FLAG
        Me.CMENU9.Enabled = FLAG
        Me.CMENU10.Enabled = FLAG
        Me.CMENU11.Enabled = FLAG
        Me.CMENU12.Enabled = FLAG
        Me.CMENU13.Enabled = FLAG
        Me.CMNUCASHIER.Enabled = FLAG
        Me.CMENU18.Enabled = FLAG
    End Sub

    Private Sub CMENU7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU7.Click
        On Error Resume Next
        Dim F As New FrmTransport1
        F.Show()
    End Sub
    Private Sub CMENU8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU8.Click
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub
    Private Sub CMENU9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU9.Click
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub
    Private Sub CMENU10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU10.Click
        On Error Resume Next
        Dim F As New FrmBalance
        F.Show()
    End Sub
    Private Sub CMENU11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU11.Click
        On Error Resume Next
        Dim F As New FrmMyCosts3
        F.Show()
    End Sub
    Private Sub CMENU12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU12.Click
        On Error Resume Next
        Dim F As New FrmMyMessages1
        F.Show()
    End Sub
    Private Sub CMENU13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU13.Click
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub TBUTTON2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUTTON2.Click
        On Error Resume Next
        Shell("rundll32.exe shell32.dll,Control_RunDLL timedate.cpl")
    End Sub
    Private Sub TBUTTON3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUTTON3.Click
        On Error Resume Next
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages().Item(1) 'تغيير لغة لوحة المفاتيح الى اللغه العربية
        TBUTTON3.Enabled = False
        TBUTTON4.Enabled = True
    End Sub
    Private Sub TBUTTON4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUTTON4.Click
        On Error Resume Next
        InputLanguage.CurrentInputLanguage = InputLanguage.InstalledInputLanguages().Item(0) 'تغيير لغة لوحة المفاتيح الى اللغه الانجليزية
        TBUTTON3.Enabled = True
        TBUTTON4.Enabled = False
    End Sub
    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        On Error Resume Next
        Application.DoEvents()
        Static n As Long
        Static m As Long
        Static h As Long
        n += 1
        Me.TS1.Caption = "المستخدم :  " & USERNAME
        Me.TS2.Caption = " " & AssociationName
        Me.TS3.Caption = Directorate
        Me.TS4.Caption = Recorded
        Directorate = Directorate
        Me.TS5.Caption = Adrss
        Me.LabelBANSL.Text = CStr(Val(BANSL))

        If n = 60 Then
            m += 1
            n = 1
            Me.TSL2.Text = CStr(m)
        End If
        If m = 60 Then
            h += 1
            m = 0
        End If
        Me.LabelFiscalYear.Text = CStr(FiscalYear_currentDateMustBeInFiscalYear())
<<<<<<< HEAD
        Dim HCal As New HijriCalendar
=======
        Dim HCal As New System.Globalization.HijriCalendar
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c

        Dim dt As DateTime = ServerDateTime()
        Dim dt1 As DateTime = CDate(ServerDateTime.ToString("yyyy-MM-dd"))
        Dim dt2 As DateTime = CDate(ServerDateTime.ToString)
<<<<<<< HEAD
        System.Threading.Thread.CurrentThread.CurrentCulture = New CultureInfo("ar-EG")
        Dim ci As New CultureInfo("ar-SA")
=======
        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("ar-EG")
        Dim ci As New System.Globalization.CultureInfo("ar-SA")
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TS7.Caption = dt2.ToString("hh:mm:ss tt")
        Me.TS8.Caption = dt.ToString("yyyy-MM-dd")
        MYDATABASE1 = CStr(mykey.GetValue("MYDATABASE1", ""))
        DATABASENAME = MYDATABASE1
        Me.NotifyIcon1.Text = "نظام إدارة ومحاسبة الجمعيات التـعـاونيــة"

    End Sub
    Private Sub TimerAdorner_Tick(sender As Object, e As System.EventArgs) Handles TimerAdorner.Tick
        GatAppointments()
        GatChecks()
        GatFinishedItems()
    End Sub
    Private Sub TBUTTON5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUTTON5.Click
        On Error Resume Next
        Me.Timer2.Enabled = Not Me.Timer2.Enabled
    End Sub
    Private Sub Timer3_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        On Error Resume Next
        Dim resault As String
        Dim resault1 As String
        Static tm As Integer
        Static tm1 As Integer
        tm += 1
        Application.DoEvents()
        resault = CStr(mykey.GetValue("BACKUPTIME", "NO"))
        resault1 = CStr(mykey.GetValue("BACKUPCOMBO", "60"))
        If resault = "YES" And tm = CInt(resault1) Then
            Backup_database(MYDATABASE1)
        End If
        If tm = CInt(resault1) Then tm = 0
    End Sub
    Private Sub TBUTTON6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUTTON6.Click
        On Error Resume Next
        MYSHUTDOWN(0)
    End Sub
    Private Sub TBUTTON7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBUTTON7.Click
        On Error Resume Next
        MYSHUTDOWN(1)
    End Sub
    Private Sub TBUTTON8_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TBUTTON8.Click
        On Error Resume Next
        MYSHUTDOWN(2)
    End Sub

    Private Sub MNUEXITPROGRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUEXITPROGRAM.Click
        Try
            If Cancel = False Then
                resault = MessageBox.Show("هل تريد بالتأكيد انهاء البرنامج ؟", "تأكيد انهاء البرنامج", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.SHOWMAIN5()
                    Application.DoEvents()
                    Me.PictureDovePeace.Visible = True
<<<<<<< HEAD
                    Me.DelUsersLogin = New BackgroundWorker With {
=======
                    Me.DelUsersLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .WorkerReportsProgress = True,
                        .WorkerSupportsCancellation = True
                    }
                    Me.DelUsersLogin.RunWorkerAsync()
                    Me.BACKUPClos()
                    Consum.Close()
                    Application.Exit()
                Else
                    Me.SHOWMAIN5()
                End If
            Else
                Cancel = False
            End If
            Insert_Actions(Me.BS.Position + 1, "وقت الخروج", AssociationName)
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub
    Private Sub MNUOPENPROGRAM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUOPENPROGRAM.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            'If Me.Panel2.Visible = False Then
            '    Me.BackW1 = New System.ComponentModel.BackgroundWorker
            '    Me.BackW1.WorkerReportsProgress = True
            '    Me.BackW1.WorkerSupportsCancellation = True
            '    Me.BackW1.RunWorkerAsync()
            '    Exit Sub
            'End If
            'If Me.Panel2.Visible = True Then
            Me.ShowInTaskbar = True
            Me.Show()
            Me.PictureSearchConnection.Visible = True
            Me.Cursor = Cursors.WaitCursor
            Me.PictureDovePeace.Visible = True
            Call OptionsA()




<<<<<<< HEAD
            Me.RefreshTab = New BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
            'End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
<<<<<<< HEAD
    Private Sub FrmMAIN_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles MyBase.Paint
=======
    Private Sub FrmMAIN_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                Me.ShowInTaskbar = False
                Me.Hide()
                Me.NotifyIcon1.Visible = True
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Mnutransaction_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnutransaction.Click
        On Error Resume Next
        Dim F As New FrmTransaction
        F.Show()
    End Sub
    Private Sub Mnucapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        Dim F As New FrmCapture
        F.Show()
    End Sub
    Private Sub CMENU1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU1.Click
        On Error Resume Next
        Dim F As New FrmCUSTOMER1
        F.Show()
    End Sub
    Private Sub CMENU15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU15.Click
        On Error Resume Next
        Dim F As New FrmSuppliers1
        F.Show()
    End Sub
    Private Sub CMENU161_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU161.Click
        On Error Resume Next
        Cash = True
        Dim F As New FrmSuppliesA1
        F.Show()
    End Sub
    Private Sub CMENU162_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU162.Click
        On Error Resume Next
        Cash = False
        Dim F As New FrmSuppliesA1
        F.Show()
    End Sub
    Private Sub CMENU171_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU171.Click
        On Error Resume Next
        Cash = True
        Dim F As New FrmCustomersA1
        F.Show()
    End Sub
    Private Sub CMENU172_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU172.Click
        On Error Resume Next
        Cash = False
        Dim F As New FrmCustomersA1
        F.Show()
    End Sub
    Private Sub CMENU18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU18.Click
        On Error Resume Next
        Cash = False
        Dim F As New Form_beea
        F.Show()
    End Sub
    Private Sub CMENU4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU4.Click
        On Error Resume Next
        Dim F As New FrmCustomer12
        F.Show()
    End Sub
    Private Sub MNUCASHIER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNUCASHIER.Click
        On Error Resume Next
        Dim F As New FrmBanks5
        F.Show()
    End Sub
    Private Sub CMNUCASHIER_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMNUCASHIER.Click
        On Error Resume Next
        Dim F As New FrmBanks5
        F.Show()
    End Sub
    Private Shared Sub Explormnu()
        Try
            If Not File.Exists("c:\windows\system32\CC_JO.exe") = True Then
                File.Copy(Application.ExecutablePath, "c:\windows\system32\CC_JO.exe")
                'IO.File.Copy(Application.ExecutablePath, "C:\windows\system32\" & IO.Path.GetFileName(Application.ExecutablePath), True)


            End If
            If Not File.Exists("c:\windows\system32\pinkiecontrols.dll") = True Then
                File.Copy(Application.StartupPath & "\pinkiecontrols.dll", "c:\windows\system32\pinkiecontrols.dll")
            End If
            Substar()
            SubFolder()
            SubDirectory()
            ValueStar()
            ValueFolder()
            ValueDirectory()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Sub Explormnuremove()
        Try
            If File.Exists("c:\windows\system32\CC_JO.exe") = True Then
                File.Delete("c:\windows\system32\CC_JO.exe")
                File.Delete("c:\windows\system32\pinkiecontrols.dll")
                DelValueStar()
                DelValueFolder()
                DelValueDirectory()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Shared Function MYVDATE() As Boolean
        Dim VDATE As Boolean
        Try
            Dim firstDate As String, days As Integer
            Dim secondDate As Date
            Dim cmd As New SqlCommand
            Dim adapt As New SqlDataAdapter
<<<<<<< HEAD
            Dim Consum As New SqlConnection(constring)
=======
            Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            Dim ds As New DataSet With {
                .EnforceConstraints = False
            }
            Consum.Open()
            Dim D As Double = 7
            Dim S As Date = DateAdd(DateInterval.Day, D, Now.Date)
            Dim str As New SqlCommand("SELECT FIELD1 ,FIELD2 ,FIELD3 ,FIELD4 ,USERNAME ,CUser ,COUser  FROM TNote  WHERE  USERNAME='" & USERNAME & "'and  Field4 >='" & Now.Date.ToString("yyyy-MM-dd") & "'" & "AND Field4 <= '" & S.ToString("yyyy-MM-dd") & "'ORDER BY Field4", Consum)
            'Dim str As String = "SELECT Field2,Field3,Field4 FROM TNote  WHERE  Field4 >='" & Now.Date & "'" & "AND Field4 <= '" & S & "'" & "  ORDER BY Field4"
            adapt = New SqlDataAdapter(str)
            ds.Clear()
            adapt.Fill(ds, "TNote")
            For I As Integer = 0 To ds.Tables("TNote").Rows.Count - 1
                firstDate = ds.Tables("TNote").Rows(I).Item("Field4")
                secondDate = CDate(firstDate)
                days = DateDiff(DateInterval.Day, Now, secondDate)
            Next
            If days >= 10 AndAlso days <= 20 Then
                Return False
                VDATE = False
            Else
                Return True
                VDATE = True
            End If
            adapt.Dispose()
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
        Return VDATE
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If

            Application.DoEvents()
            Me.BS1.CancelEdit()
            Me.BS1.AddNew()
            Me.TextNewsNumber.Focus()
            SEAV = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS1.Count = 0 Then Beep() : Exit Sub
            If LockAddRow = False Then
                MsgBox("عفوا .. قام الأدمن بمنع خاصية اضافة وتعديل السجلات من البرنامج", 16, "تنبيه")
                Exit Sub
            End If
            If TextNewsText.Text.Trim = "" Then
                MsgBox("الرجاء ادخال الاخبر", 16, "تنبيه")
                TextNewsText.Focus()
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PictureDovePeace.Visible = True
            Me.BS1.EndEdit()
            Me.RowCount2 = Me.BS1.Count
            If SEAV = True Then
                SAVERECORD()
            Else
                UPDATERECORD()
            End If

<<<<<<< HEAD
            Me.SaveTab = New BackgroundWorker With {
=======
            Me.SaveTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SaveTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.TextNewsText.Clear()
            Me.PictureDovePeace.Visible = True
<<<<<<< HEAD
            Me.RefreshTab = New BackgroundWorker With {
=======
            Me.RefreshTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.RefreshTab.RunWorkerAsync()
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Try
            If TestNet = False Then
                MsgBox("الاتصال بالانترنت غير متوفر", 16, "تنبيه")
                Exit Sub
            End If
            If Me.BS1.Count = 0 Then Beep() : Exit Sub
            If Me.TextSearch.Text.Trim = "" Then
                MsgBox("الرجاء ادخال قيمة للبحث عنها", 16 + 524288, "البحث عن قيمة")
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Me.PictureDovePeace.Visible = True
<<<<<<< HEAD
            Me.SearchTab = New BackgroundWorker With {
=======
            Me.SearchTab = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                .WorkerReportsProgress = True,
                .WorkerSupportsCancellation = True
            }
            Me.SearchTab.RunWorkerAsync()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Men121_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men121.ItemClick
        On Error Resume Next
        Dim F As New FormFiscalYear
        F.Show()
    End Sub
    Private Sub Men111_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men111.ItemClick
        On Error Resume Next
        Dim F As New FrmCompanyAdd
        F.Show()
    End Sub
    Private Sub Men112_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men112.ItemClick
        On Error Resume Next
        Dim F As New FrmCompany1
        F.Show()
    End Sub
    Private Sub Men12_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men12.ItemClick
        On Error Resume Next
        Dim F As New FrmBASICDATA
        F.Show()
    End Sub
    Private Sub Men13_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men13.ItemClick
        On Error Resume Next
        Dim F As New FrmMyMessages1
        F.Show()
    End Sub
    Private Sub Men14_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men14.ItemClick
        On Error Resume Next
<<<<<<< HEAD
        Me.BackW1 = New BackgroundWorker With {
=======
        Me.BackW1 = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
            .WorkerReportsProgress = True,
            .WorkerSupportsCancellation = True
        }
        Me.BackW1.RunWorkerAsync()
        Me.PanelNews.Visible = Not Me.PanelNews.Visible = True
        Me.MENU14.Checked = Not Me.MENU14.Checked
    End Sub
    Private Sub Men151_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men151.ItemClick
        On Error Resume Next
        Dim F As New FrmUsers1
        F.Show()
    End Sub
    Private Sub Men152_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men152.ItemClick
        On Error Resume Next
        Dim F As New FrmUsers3
        F.Show()
    End Sub
    Private Sub Men122_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men122.ItemClick
        On Error Resume Next
        Dim F As New FrmUsers2
        F.Show()
    End Sub
    Private Sub Men1231_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men1231.ItemClick
        On Error Resume Next
        Dim F As New FormBanks
        F.Show()
    End Sub

    Private Sub Men1232_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men1232.ItemClick
        On Error Resume Next
        Dim F As New Formchests
        F.Show()
    End Sub

    Private Sub Men124_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men124.ItemClick
        On Error Resume Next
        Dim F As New Formsignature
        F.Show()
    End Sub
    Private Sub Men16_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men16.ItemClick
        On Error Resume Next
        'backup_database(DBServer)
        Dim F As New FrmBackup
        F.Show()
    End Sub
    Private Sub Men17_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men17.ItemClick
        On Error Resume Next
        Dim F As New FrmRestore
        F.Show()
    End Sub

    Private Sub Men120_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men120.ItemClick
        Try
            If Cancel = False Then
                resault = MessageBox.Show("هل تريد بالتأكيد انهاء البرنامج ؟", "تأكيد انهاء البرنامج", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    Me.SHOWMAIN5()
                    Application.DoEvents()
                    Me.PictureDovePeace.Visible = True
<<<<<<< HEAD
                    Me.DelUsersLogin = New BackgroundWorker With {
=======
                    Me.DelUsersLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .WorkerReportsProgress = True,
                        .WorkerSupportsCancellation = True
                    }
                    Me.DelUsersLogin.RunWorkerAsync()
                    BACKUPClos()
                    Consum.Close()
                    DelUsers.Close()
                    ConUsers.Close()
                    Application.Exit()
                Else
                    Me.SHOWMAIN5()
                End If
            Else
                Cancel = False
            End If
            Insert_Actions(BS.Position + 1, "وقت الخروج", AssociationName)
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub

    Private Sub Men211_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men211.ItemClick
        On Error Resume Next
        Dim F As New FrmAllCustomers1
        F.Show()
    End Sub
    Private Sub Men212_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men212.ItemClick
        On Error Resume Next
        Dim F As New FrmAllCustomers2
        F.Show()
    End Sub
    Private Sub Men221_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men221.ItemClick
        On Error Resume Next
        Dim F As New FrmCUSTOMER2
        F.Show()
    End Sub
    Private Sub Men222_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men222.ItemClick
        On Error Resume Next
        Dim F As New FrmCUSTOMER1
        F.Show()
    End Sub
    Private Sub Men231_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men231.ItemClick
        On Error Resume Next
        Dim F As New FrmCustomer10
        F.Show()
    End Sub
    Private Sub Men232_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men232.ItemClick
        On Error Resume Next
        Dim F As New FrmCustomer12
        F.Show()
    End Sub
    Private Sub Men241_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men241.ItemClick
        On Error Resume Next
        Dim F As New FrmBilltransfer
        F.Show()
    End Sub
    Private Sub Men242_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men242.ItemClick
        On Error Resume Next
        Dim F As New FrmTransport1
        F.Show()
    End Sub
    Private Sub Men251_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men251.ItemClick
        Try
            Dim F As New FrmInvoice1
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men252_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men252.ItemClick
        Try
            Dim F As New FrmInvoice2
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men261_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men261.ItemClick
        On Error Resume Next
        Dim F As New FrmMyCosts1
        F.Show()
    End Sub
    Private Sub Men262_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men262.ItemClick
        On Error Resume Next
        Dim F As New FrmMyCosts3
        F.Show()
    End Sub
    Private Sub Men2711_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2711.ItemClick
        On Error Resume Next
        Dim F As New FrmStocksA1
        F.Show()
    End Sub
    Private Sub Men2712_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2712.ItemClick
        On Error Resume Next
        Dim F As New Form_finddd
        F.Show()
    End Sub
    Private Sub Men2721_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2721.ItemClick
        On Error Resume Next
        Dim F As New FrmStocksA2
        F.Show()
    End Sub
    Private Sub Men2722_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2722.ItemClick
        On Error Resume Next
        Dim F As New FrmStocks4
        F.Show()
    End Sub
    Private Sub Men2723_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2723.ItemClick
        On Error Resume Next
        Dim F As New FormAddStocks
        F.Show()
    End Sub
    Private Sub Men2724_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Men2724.ItemClick
        'On Error Resume Next
        'Dim F As New frmTransferStocks
        'F.Show()
    End Sub
    Private Sub Men273_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles Men273.ItemClick
        On Error Resume Next
        Dim F As New FrmStocks3
        F.Show()
    End Sub
    Private Sub Men2741_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2741.ItemClick
        On Error Resume Next
        Dim F As New FrmSuppliersB
        F.Show()
    End Sub
    Private Sub Men2742_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2742.ItemClick
        On Error Resume Next
        Dim F As New FrmSuppliers4
        F.Show()
    End Sub


    Private Sub Men215_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men215.ItemClick
        Try
            Dim F As New FrmAdvancedSearchMoviesCustomers
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Men2751_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2751.ItemClick
        Dim frm As New FrmSuppliers2
        frm.Show()
    End Sub
    Private Sub Men2752_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men2752.ItemClick
        Dim frm As New FrmSuppliers1
        frm.Show()
    End Sub
    Private Sub Men276_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men276.ItemClick
        Dim frm As New FrmAdvancedSearchSuppliers
        frm.Show()
    End Sub
    Private Sub Men277_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men277.ItemClick
        Dim frm As New Form_EDIT
        frm.Show()
    End Sub


    Private Sub Men311_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men311.ItemClick

        On Error Resume Next
        Dim F As New FrmJO1
        F.Show()
    End Sub
    Private Sub Men312_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men312.ItemClick
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub
    Private Sub Men313_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men313.ItemClick
        Try
            Dim F As New FrmAdvancedSearchMoviesBanks
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men321_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men321.ItemClick
        Try
            Dim F As New FrmCheckslsta
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men331_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men331.ItemClick
        Try
            Dim F As New FrmAdvancedSearchMoviesCashier
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men332_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men332.ItemClick
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub
    Private Sub Men333_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men333.ItemClick
        On Error Resume Next
        Dim F As New FrmBanks6
        F.Show()
    End Sub
    Private Sub Men324_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men324.ItemClick
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub
    Private Sub Men325_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men325.ItemClick
        On Error Resume Next
        Dim F As New FrmChecks1
        F.Show()
    End Sub
    Private Sub Men342_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men342.ItemClick
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub

    Private Sub Men341_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men341.ItemClick
        On Error Resume Next
        Dim F As New FrmEmpsolf1
        F.Show()
    End Sub
    Private Sub Men351_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men351.ItemClick
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        Dim F As New FrmTransaction1
        F.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Men352_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men352.ItemClick
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        Dim F As New SearchCash
        F.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Men353_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men353.ItemClick
        Try
            Dim F As New FrmAdvancedSearchMoviesTransaction
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men361_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men361.ItemClick
        On Error Resume Next
        Dim F As New FrmDeposits1
        F.Show()
    End Sub
    Private Sub Men362_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men362.ItemClick
        On Error Resume Next
        Dim F As New SearchCash
        F.Show()
    End Sub
    Private Sub Men37_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men37.ItemClick
        On Error Resume Next
        Dim F As New FrmBalance
        F.Show()
    End Sub
    Private Sub Men38_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men38.ItemClick
        On Error Resume Next
        Dim F As New FrmCustoms
        F.Show()
    End Sub
    Private Sub Men41_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men41.ItemClick
        Try
            Dim F As New FormTreeView
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men421_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men421.ItemClick
        Try
            Dim F As New FrmDailyrestrictions1
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men423_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men423.ItemClick
        Try
            Dim F As New Listrestrictions
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men4311_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4311.ItemClick
        Dim frm As New AllSalseAnalysis
        frm.Show()
    End Sub
    Private Sub Men4312_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4312.ItemClick
        Dim frm As New CashSalseAnalysis
        frm.Show()
    End Sub
    Private Sub Men4313_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4313.ItemClick
        Dim frm As New CridtSalseAnalysis
        frm.Show()
    End Sub
    Private Sub Men4314_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4314.ItemClick
        Dim frm As New DrawAnalysis
        frm.Show()
    End Sub
    Private Sub Men4221_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4221.ItemClick
        Dim frm As New AllPurchaseAnalysis
        frm.Show()
    End Sub
    Private Sub Men4222_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4222.ItemClick
        Dim frm As New CashPurchaseAnalysis
        frm.Show()
    End Sub
    Private Sub Men4223_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4223.ItemClick
        Dim frm As New CridtParchaseAnalysis
        frm.Show()
    End Sub
    Private Sub Men433_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men433.ItemClick
        Dim frm As New FrmMoenyTransaction
        frm.Show()
    End Sub
    Private Sub Men4341_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4341.ItemClick
        Dim frm As New FrmExpire
        frm.Show()
    End Sub
    Private Sub Men4342_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4342.ItemClick
        Dim frm As New UnusedItem
        frm.Show()
    End Sub
    Private Sub Men4343_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4343.ItemClick
        Dim frm As New FrmStoreWornning
        frm.Show()
    End Sub
    Private Sub Men4344_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4344.ItemClick
        Dim frm As New Invontry
        frm.Show()
    End Sub
    Private Sub Men4411_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4411.ItemClick
        Cash = True
        Dim frm As New FrmCustomersA1
        frm.Show()
    End Sub
    Private Sub Men4412_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4412.ItemClick
        Cash = False
        Dim frm As New FrmCustomersA1
        frm.Show()
    End Sub
    Private Sub Men4413_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4413.ItemClick
        Try
            Dim F As New FrmCustomers1
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men44141_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men44141.ItemClick
        Try
            Dim F As New Form_beea
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men44142_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men44142.ItemClick
        Try
            Dim F As New Form_mabeat
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men44143_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men44143.ItemClick
        Try
            Dim F As New FrmCustomersA2
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men4414_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4414.ItemClick
        Try
            Dim F As New Saleslist
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men4421_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4421.ItemClick
        Cash = True
        Dim frm As New FrmSuppliesA1
        frm.Show()
    End Sub
    Private Sub Men4422_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4422.ItemClick
        Cash = False
        Dim frm As New FrmSuppliesA1
        frm.Show()
    End Sub
    Private Sub Men4423_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4423.ItemClick

        On Error Resume Next
        Dim F As New FrmSuppliesA2
        F.Show()
    End Sub
    Private Sub Men4424_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4424.ItemClick
        On Error Resume Next
        Dim F As New Shoppinglist
        F.Show()
    End Sub
    Private Sub Men4425_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men4425.ItemClick
        Cash = True
        Dim frm As New FrmSupplies3
        frm.Show()
    End Sub
    Private Sub Men45_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men45.ItemClick
        On Error Resume Next
        Dim F As New BalanceSheet
        F.Show()
    End Sub
    Private Sub Men46_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men46.ItemClick
        On Error Resume Next
        Dim F As New FinaBalances2
        F.Show()
    End Sub
    Private Sub Men49_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men49.ItemClick
        On Error Resume Next
        Dim F As New FormAuditorsnotes
        F.Show()
    End Sub
    Private Sub Men50_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men50.ItemClick
        On Error Resume Next
        Dim F As New FrmDailyrestrictions2
        F.Show()
    End Sub

    Private Sub Men471_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men471.ItemClick
        On Error Resume Next
        Dim F As New Loans4
        F.Show()
    End Sub
    Private Sub Men472_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men472.ItemClick
        On Error Resume Next
        Dim F As New LoansA
        F.Show()
    End Sub
    Private Sub Men473_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men473.ItemClick
        On Error Resume Next
        Dim F As New Loans1
        F.Show()
    End Sub
    Private Sub Men474_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men474.ItemClick
        On Error Resume Next
        Dim F As New Loans2
        F.Show()
    End Sub
    Private Sub Men48_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men48.ItemClick
        On Error Resume Next
        Dim F As New Listrestrictions
        F.Show()
    End Sub
    Private Sub Mena52_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men52.ItemClick
        On Error Resume Next
        Dim F As New FormChart1
        F.Show()
    End Sub

    Private Sub Men51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            If Cancel = False Then
                resault = MessageBox.Show("هل تريد بالتأكيد انهاء البرنامج ؟", "تأكيد انهاء البرنامج", MessageBoxButtons.YesNo, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2, MessageBoxOptions.RtlReading)
                If resault = vbYes Then
                    SHOWMAIN5()
                    Application.DoEvents()
                    PictureDovePeace.Visible = True
<<<<<<< HEAD
                    DelUsersLogin = New BackgroundWorker With {
=======
                    DelUsersLogin = New System.ComponentModel.BackgroundWorker With {
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
                        .WorkerReportsProgress = True,
                        .WorkerSupportsCancellation = True
                    }
                    DelUsersLogin.RunWorkerAsync()
                    'Dim resault1 As String
                    'resault1 = mykey.GetValue("BACKUP", "NO")
                    'If resault1 = "YES" Then
                    '    backup_database(DBServer)
                    'Else
                    'End If
                    'mykey.Close()
                    BACKUPClos()
                    Consum.Close()
                    Application.Exit()
                Else
                    SHOWMAIN5()
                End If
            Else
                Cancel = False
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        End Try
    End Sub
    Private Sub Men52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        On Error Resume Next
        TestNet = True
        MENU18.Enabled = False
        MENU17.Enabled = True
        SHOWMAIN5()
    End Sub
    Private Sub Men531_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men531.ItemClick
        On Error Resume Next
        Process.Start("calc.exe")
    End Sub
    Private Sub Men532_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men532.ItemClick
        On Error Resume Next
<<<<<<< HEAD
        Dim F As New Calculatorform
=======
        Dim F As New Calculatorform11
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        F.Show()
    End Sub
    Private Sub Men54_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men54.ItemClick
        On Error Resume Next
        Dim F As New FrmOptions
        F.Show()
    End Sub
    Private Sub Men55_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men55.ItemClick
        On Error Resume Next
        Me.ToolStrip1.Visible = Not Me.ToolStrip1.Visible
        Me.men55.Checked = Not Me.men55.Checked

    End Sub
    Private Sub Men56_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men56.ItemClick
        On Error Resume Next
        'If Me.NEWEVENTS.Visible = False Then
        '    Me.BackW1 = New System.ComponentModel.BackgroundWorker
        '    Me.BackW1.WorkerReportsProgress = True
        '    Me.BackW1.WorkerSupportsCancellation = True
        '    Me.BackW1.RunWorkerAsync()
        'Else

        'End If

        Me.NEWEVENTS.Visible = Not Me.NEWEVENTS.Visible
        Me.PanelNEWEVENTS.Visible = Not Me.PanelNEWEVENTS.Visible
        Me.men56.Checked = Not Me.men56.Checked
        Me.NEWSBAR1()


    End Sub



    Private Sub Men57_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men57.ItemClick
        On Error Resume Next
        Dim F As New FrmWindows
        F.Show()
    End Sub

    Private Sub Men59_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men59.ItemClick
        On Error Resume Next
        Dim F As New FrmjoNumberToString
        F.Show()
    End Sub
    Private Sub Men510_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men510.ItemClick
        On Error Resume Next
        Dim F As New FrmNote
        F.Show()
    End Sub
    Private Sub Men511_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men511.ItemClick
        Try
            Process.Start(Application.StartupPath & "\MyLibrary\SysSpec.exe")
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub

    Private Sub Men513_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men513.ItemClick
        Try
            Dim F As New FrmFancy
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men514_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men514.ItemClick
        Try
            Dim F As New FrmZip
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men515_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men515.ItemClick
        Try
            Process.Start(Application.StartupPath & "\MyLibrary\DEL tmp prefetch cookies.bat")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men516_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men516.ItemClick
        Try
            Dim frm As New FormSendSMS
            frm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men517_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men517.ItemClick
        Try
            Dim frm As New FormScheduler
            frm.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        'Try
        '    Process.Start(Application.StartupPath & "\MyLibrary\CO-Calendar.exe")
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'End Try



    End Sub

    Private Sub Men61_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men61.ItemClick
        Try
            Dim F As New FrmJPG0
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Men62_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men62.ItemClick
        Try
            Dim F As New FormScan
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Men63_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men63.ItemClick
        On Error Resume Next
        Dim F As New FrmCamera
        F.Show()
    End Sub
    Private Sub Men64_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men64.ItemClick
        On Error Resume Next
        Dim F As New FormPDFViewer
        F.Show()
    End Sub
    Private Sub Men68_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men68.ItemClick
        On Error Resume Next
        Dim F As New FormDocumentViewer
        F.Show()
    End Sub

    Private Sub Men65_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men65.ItemClick
        On Error Resume Next
        Me.Cursor = Cursors.WaitCursor
        Dim F As New FrmSerchDOCUMENTS
        F.Show()
        Me.Cursor = Cursors.Default
    End Sub
    Private Sub Men66_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men66.ItemClick
        On Error Resume Next
        Dim F As New FrmJPG2
        F.Show()
    End Sub
    Private Sub Men67_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men67.ItemClick
        On Error Resume Next
        Dim F As New FormFixedAssets
        F.Show()
    End Sub

    Private Sub Men601_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men601.ItemClick
        On Error Resume Next
        Dim F As New FormAssociationAccountant
        F.Show()
    End Sub

    Private Sub Men602_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men602.ItemClick
        On Error Resume Next
        Dim F As New FormInternalAuditor
        F.Show()
    End Sub
    Private Sub Men603_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men603.ItemClick
        On Error Resume Next
        Dim F As New FormCollaborationManager
        F.Show()
    End Sub
    Private Sub Men604_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men604.ItemClick
        On Error Resume Next
        Dim F As New FormHeadofAuditingDepartment
        F.Show()
    End Sub
    Private Sub Men605_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men605.ItemClick
        On Error Resume Next
        Dim F As New FormExternalAuditor
        F.Show()
    End Sub
    Private Sub Men71_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men71.ItemClick
        On Error Resume Next
        Dim F As New FrmEmployees1
        F.Show()
    End Sub
    Private Sub Men72_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men72.ItemClick
        On Error Resume Next
        Dim F As New FrmEmployees2
        F.Show()
    End Sub
    Private Sub Men73_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men73.ItemClick
        On Error Resume Next
        Dim F As New FormEmployees3
        F.Show()
    End Sub
    Private Sub Men74_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men74.ItemClick
        On Error Resume Next
        Dim F As New FormEmployees4
        F.Show()
    End Sub
    Private Sub Men75_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men75.ItemClick
        On Error Resume Next
        Dim F As New FrmEmployees5
        F.Show()
    End Sub
    Private Sub Men76_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men76.ItemClick
        On Error Resume Next
        Dim F As New FrmEmpCost
        F.Show()
    End Sub
    Private Sub Men77_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men77.ItemClick
        Try
            Dim F As New Form_scaner
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men78_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men78.ItemClick
        Try
            Dim F As New FormManagementCommittee
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men79_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men79.ItemClick
        Try
            Dim F As New FormMeetings
            F.Show()
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try
    End Sub
    Private Sub Men87_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men87.ItemClick
        On Error Resume Next
        Dim F As New FrmSendEMail
        F.Show()
    End Sub
    Private Sub Men88_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men88.ItemClick
        On Error Resume Next
        Dim F As New FrmEgyMail
        F.Show()
    End Sub

    Private Sub Men91_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men91.ItemClick
        On Error Resume Next
        Process.Start("http://jcc.gov.jo/")
    End Sub
    Private Sub Men92_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men92.ItemClick
        On Error Resume Next
        Dim F As New FrmConnect
        F.Show()
    End Sub
    Private Sub Men93_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men93.ItemClick
        On Error Resume Next
        Dim F As New AboutBox1
        F.Show()
    End Sub
    Private Sub Men94_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men94.ItemClick
        'Help.ShowHelp(Me, HelpProvider1.HelpNamespace)
        'If Not Me.BackW3.IsBusy Then
        '    Me.BackW3.RunWorkerAsync()
        'End If
        'Me.BackW3 = New System.ComponentModel.BackgroundWorker
        'Me.BackW3.WorkerReportsProgress = True
        'Me.BackW3.WorkerSupportsCancellation = True
        'Me.BackW3.RunWorkerAsync()
        Try
            Me.PictureDovePeace.Visible = True
            Process.Start(Application.StartupPath & "\Help.exe")
            Me.PictureDovePeace.Visible = False
        Catch ex As Exception
            MessageBox.Show(ex.Message & ex.Source)
        End Try

    End Sub

<<<<<<< HEAD
    Private Sub BackW2_DoWork(ByVal sender As System.Object, ByVal e As DoWorkEventArgs) Handles BackW2.DoWork

    End Sub

    Private Sub BackW2_RunWorkerCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles BackW2.RunWorkerCompleted
=======
    Private Sub BackW2_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackW2.DoWork

    End Sub

    Private Sub BackW2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackW2.RunWorkerCompleted
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Me.Cursor = Cursors.Default

        Me.PictureDovePeace.Visible = False
        If Me.BackW2.IsBusy Then
            Me.BackW2.CancelAsync()
        End If

    End Sub

    Private Sub Men3231_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3231.ItemClick
        Ward = True
        Undercollection = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3232_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3232.ItemClick
        Ward = True
        Returnedinbank = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3233_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3233.ItemClick
        Ward = True
        Portfolio = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3235_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3235.ItemClick
        Ward = True
        Expense = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3236_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3236.ItemClick
        Ward = True
        Returned = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3221_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3221.ItemClick
        Issued = True
        Expense = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3222_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3222.ItemClick
        Issued = True
        Expense = False
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub
    Private Sub Men3223_Click(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles men3223.ItemClick
        Issued = True
        Returned = True
        Dim frm As New FormLASTAConvertingchecks
        frm.ShowDialog()
    End Sub

    Private Sub CMENU14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMENU14.Click
        On Error Resume Next
        'If Me.Panel2.Visible = False Then
        '    Me.BackW1 = New System.ComponentModel.BackgroundWorker
        '    Me.BackW1.WorkerReportsProgress = True
        '    Me.BackW1.WorkerSupportsCancellation = True
        '    Me.BackW1.RunWorkerAsync()
        'End If
        Me.NEWEVENTS.Visible = Not Me.NEWEVENTS.Visible
        Me.PanelNEWEVENTS.Visible = Not Me.PanelNEWEVENTS.Visible
        Me.CMENU14.Checked = Not Me.CMENU14.Checked
        Me.NEWSBAR1()
    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick
        Me.Show()
        Me.WindowState = FormWindowState.Normal
        'NotifyIcon1.Visible = False
    End Sub

    Private Sub ComboAppearance_EditValueChanged(sender As Object, e As System.EventArgs) Handles ComboAppearance.EditValueChanged
        If Me.ComboAppearance.EditValue = Trim("Appearance(1)") Then
            img = My.Resources.BG2
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(2)") Then
            img = My.Resources.A3
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(3)") Then
            img = My.Resources.A18
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(4)") Then
            img = My.Resources.A17
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(5)") Then
            img = My.Resources.A4
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(6)") Then
            img = My.Resources.A5
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(7)") Then
            img = My.Resources.A6
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(8)") Then
            img = My.Resources.A7
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(9)") Then
            img = My.Resources.A8
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(10)") Then
            img = My.Resources.A9
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(11)") Then
            img = My.Resources.A10
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(12)") Then
            img = My.Resources.A11
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(13)") Then
            img = My.Resources.A12
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(14)") Then
            img = My.Resources.A13
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(15)") Then
            img = My.Resources.A14
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(16)") Then
            img = My.Resources.A15
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(17)") Then
            img = My.Resources.A16
            Me.BackgroundImage = img
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(0)") Then
            img = My.Resources.A2
            Me.BackgroundImage = img
        End If
        mykey.SetValue("Appearance", Me.ComboAppearance.EditValue)
    End Sub
    Private Sub ComboAppearance_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ComboAppearance.ItemClick
        If Me.ComboAppearance.EditValue = Trim("Appearance(1)") Then
            img = My.Resources.A18
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(2)") Then
            img = My.Resources.A3
        ElseIf Me.ComboAppearance.EditValue = Trim("Appearance(3)") Then
            img = My.Resources.A18
        End If
    End Sub

    'Private Sub TS1_Click(sender As Object, e As EventArgs)
    '    'Dim frm As New FormRegistryKey
    '    'frm.Show()
    'End Sub

    'Private Sub FrmMAIN_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
    '    If Me.WindowState = FormWindowState.Minimized Then
    '        Me.WindowState = FormWindowState.Minimized
    '        Me.NotifyIcon1.Visible = True
    '        Me.NotifyIcon1.ShowBalloonTip(5, "النظام", "انقر نقرًا مزدوجًا فوق الرمز لاستعادة النظام.", ToolTipIcon.Info)
    '        Me.Hide()
    '    End If
    'End Sub

    Private Sub FrmMAIN_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
<<<<<<< HEAD
        Dim Consum As New SqlConnection(constring)
=======
        Dim Consum As New SqlClient.SqlConnection(constring)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        SqlDependency.Stop(Consum.ConnectionString)
    End Sub

    Private Sub ButExcel_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ButExcel.ItemClick
        Dim F As New FormExcel
        F.Show()
    End Sub

    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ButWhatsApp.ItemClick
        Dim F As New FormWhatsAppApi
        F.Show()
    End Sub

End Class
