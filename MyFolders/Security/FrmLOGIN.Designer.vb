<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLOGIN
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLOGIN))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Txtpassword = New System.Windows.Forms.TextBox()
        Me.TxtUser = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdcancel = New System.Windows.Forms.Button()
        Me.cmdLogin = New System.Windows.Forms.Button()
        Me.L2 = New System.Windows.Forms.Label()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.L1 = New System.Windows.Forms.Label()
        Me.L3 = New System.Windows.Forms.Label()
        Me.CircularProgress2 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.L4 = New System.Windows.Forms.Label()
        Me.L5 = New System.Windows.Forms.Label()
        Me.PanelUsers = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.BGWLOGIN = New System.ComponentModel.BackgroundWorker()
        Me.BGWFrmLOGIN_Load = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker3 = New System.ComponentModel.BackgroundWorker()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelUsers.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.logCO6
        Me.PictureBox1.Location = New System.Drawing.Point(3, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(112, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.login
        Me.PictureBox2.Location = New System.Drawing.Point(391, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 47
        Me.PictureBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(74, 14)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Password :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(74, 14)
        Me.Label1.TabIndex = 45
        Me.Label1.Text = "UserName :"
        '
        'Txtpassword
        '
        Me.Txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Txtpassword.Cursor = System.Windows.Forms.Cursors.Default
        Me.Txtpassword.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Txtpassword.Location = New System.Drawing.Point(89, 38)
        Me.Txtpassword.Name = "Txtpassword"
        Me.Txtpassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.Txtpassword.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Txtpassword.Size = New System.Drawing.Size(299, 26)
        Me.Txtpassword.TabIndex = 44
        Me.Txtpassword.Text = "1"
        '
        'TxtUser
        '
        Me.TxtUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtUser.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtUser.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtUser.Location = New System.Drawing.Point(89, 10)
        Me.TxtUser.Name = "TxtUser"
        Me.TxtUser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtUser.Size = New System.Drawing.Size(299, 26)
        Me.TxtUser.TabIndex = 43
        Me.TxtUser.Text = "m"
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Image = Global.CC_JO.My.Resources.Resources.package_settings
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(3, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(146, 32)
        Me.Button1.TabIndex = 50
        Me.Button1.Text = "&إعدادات الخادم"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'cmdcancel
        '
        Me.cmdcancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdcancel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdcancel.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.cmdcancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdcancel.Location = New System.Drawing.Point(150, 3)
        Me.cmdcancel.Name = "cmdcancel"
        Me.cmdcancel.Size = New System.Drawing.Size(147, 32)
        Me.cmdcancel.TabIndex = 49
        Me.cmdcancel.Text = "&إلغاء"
        Me.cmdcancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdcancel.UseVisualStyleBackColor = True
        '
        'cmdLogin
        '
        Me.cmdLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogin.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.cmdLogin.Image = Global.CC_JO.My.Resources.Resources.userlogin24
        Me.cmdLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdLogin.Location = New System.Drawing.Point(298, 3)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(161, 32)
        Me.cmdLogin.TabIndex = 48
        Me.cmdLogin.Text = "&دخول"
        Me.cmdLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdLogin.UseVisualStyleBackColor = True
        '
        'L2
        '
        Me.L2.AutoSize = True
        Me.L2.BackColor = System.Drawing.Color.Transparent
        Me.L2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.L2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.L2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.L2.Location = New System.Drawing.Point(345, 27)
        Me.L2.Name = "L2"
        Me.L2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.L2.Size = New System.Drawing.Size(113, 20)
        Me.L2.TabIndex = 52
        Me.L2.Text = "حالة الإتصال : متصل  ..."
        Me.L2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.L2.UseCompatibleTextRendering = True
        Me.L2.Visible = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox3.Location = New System.Drawing.Point(213, 20)
        Me.PictureBox3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox3.TabIndex = 730
        Me.PictureBox3.TabStop = False
        Me.PictureBox3.Visible = False
        '
        'Panel1
        '
        Me.Panel1.AllowDrop = True
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.L2)
        Me.Panel1.Controls.Add(Me.L1)
        Me.Panel1.Controls.Add(Me.L3)
        Me.Panel1.Controls.Add(Me.CircularProgress2)
        Me.Panel1.Controls.Add(Me.PictureBox3)
        Me.Panel1.Controls.Add(Me.CircularProgress1)
        Me.Panel1.Controls.Add(Me.L4)
        Me.Panel1.Controls.Add(Me.L5)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New System.Drawing.Point(5, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Panel1.Size = New System.Drawing.Size(464, 98)
        Me.Panel1.TabIndex = 733
        '
        'L1
        '
        Me.L1.AutoSize = True
        Me.L1.BackColor = System.Drawing.Color.Transparent
        Me.L1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.L1.ForeColor = System.Drawing.Color.Maroon
        Me.L1.Location = New System.Drawing.Point(177, 72)
        Me.L1.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.L1.Name = "L1"
        Me.L1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.L1.Size = New System.Drawing.Size(108, 20)
        Me.L1.TabIndex = 824
        Me.L1.Text = "Error completed !"
        Me.L1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.L1.UseCompatibleTextRendering = True
        Me.L1.Visible = False
        '
        'L3
        '
        Me.L3.AutoSize = True
        Me.L3.BackColor = System.Drawing.Color.Transparent
        Me.L3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.L3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.L3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.L3.Location = New System.Drawing.Point(316, 53)
        Me.L3.Name = "L3"
        Me.L3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.L3.Size = New System.Drawing.Size(142, 20)
        Me.L3.TabIndex = 823
        Me.L3.Text = "يتم الان تحميل قاعدة البيانات ..."
        Me.L3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.L3.UseCompatibleTextRendering = True
        Me.L3.Visible = False
        '
        'CircularProgress2
        '
        '
        '
        '
        Me.CircularProgress2.BackgroundStyle.BackColor = System.Drawing.Color.Transparent
        Me.CircularProgress2.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent
        Me.CircularProgress2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.CircularProgress2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.CircularProgress2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.CircularProgress2.BackgroundStyle.BorderRightColor = System.Drawing.Color.Transparent
        Me.CircularProgress2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid
        Me.CircularProgress2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress2.Font = New System.Drawing.Font("Traditional Arabic", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CircularProgress2.Location = New System.Drawing.Point(199, 5)
        Me.CircularProgress2.Name = "CircularProgress2"
        Me.CircularProgress2.PieBorderDark = System.Drawing.Color.SteelBlue
        Me.CircularProgress2.PieBorderLight = System.Drawing.Color.White
        Me.CircularProgress2.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke
        Me.CircularProgress2.ProgressColor = System.Drawing.Color.Orange
        Me.CircularProgress2.ProgressText = "ارجو الانتظار"
        Me.CircularProgress2.ProgressTextColor = System.Drawing.Color.Blue
        Me.CircularProgress2.ProgressTextVisible = True
        Me.CircularProgress2.Size = New System.Drawing.Size(64, 64)
        Me.CircularProgress2.SpokeBorderDark = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CircularProgress2.SpokeBorderLight = System.Drawing.Color.Red
        Me.CircularProgress2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress2.TabIndex = 822
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CircularProgress1.Location = New System.Drawing.Point(199, 3)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.PieBorderDark = System.Drawing.Color.DarkBlue
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.Red
        Me.CircularProgress1.ProgressText = "ارجو الانتظار"
        Me.CircularProgress1.ProgressTextColor = System.Drawing.Color.MidnightBlue
        Me.CircularProgress1.ProgressTextVisible = True
        Me.CircularProgress1.Size = New System.Drawing.Size(64, 64)
        Me.CircularProgress1.SpokeBorderDark = System.Drawing.Color.DarkBlue
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 740
        '
        'L4
        '
        Me.L4.AutoSize = True
        Me.L4.BackColor = System.Drawing.Color.Transparent
        Me.L4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.L4.ForeColor = System.Drawing.Color.Maroon
        Me.L4.Location = New System.Drawing.Point(192, 72)
        Me.L4.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.L4.Name = "L4"
        Me.L4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.L4.Size = New System.Drawing.Size(79, 20)
        Me.L4.TabIndex = 735
        Me.L4.Text = " ارجو الانتظار ..."
        Me.L4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.L4.UseCompatibleTextRendering = True
        '
        'L5
        '
        Me.L5.AutoSize = True
        Me.L5.BackColor = System.Drawing.Color.Transparent
        Me.L5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.L5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.L5.ForeColor = System.Drawing.Color.White
        Me.L5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.L5.Location = New System.Drawing.Point(335, -1)
        Me.L5.Name = "L5"
        Me.L5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.L5.Size = New System.Drawing.Size(123, 15)
        Me.L5.TabIndex = 734
        Me.L5.Text = "البرنامج       :  Activated"
        Me.L5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.L5.Visible = False
        '
        'PanelUsers
        '
        Me.PanelUsers.BackColor = System.Drawing.Color.Transparent
        Me.PanelUsers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelUsers.Controls.Add(Me.CheckBox1)
        Me.PanelUsers.Controls.Add(Me.Label1)
        Me.PanelUsers.Controls.Add(Me.PictureBox2)
        Me.PanelUsers.Controls.Add(Me.Txtpassword)
        Me.PanelUsers.Controls.Add(Me.TxtUser)
        Me.PanelUsers.Controls.Add(Me.Label2)
        Me.PanelUsers.Location = New System.Drawing.Point(5, 110)
        Me.PanelUsers.Name = "PanelUsers"
        Me.PanelUsers.Size = New System.Drawing.Size(464, 76)
        Me.PanelUsers.TabIndex = 735
        '
        'CheckBox1
        '
        Me.CheckBox1.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.White
        Me.CheckBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CheckBox1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CheckBox1.FlatAppearance.BorderSize = 0
        Me.CheckBox1.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CheckBox1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Image = Global.CC_JO.My.Resources.Resources.Show_16x16
        Me.CheckBox1.Location = New System.Drawing.Point(365, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckBox1.Size = New System.Drawing.Size(22, 22)
        Me.CheckBox1.TabIndex = 733
        Me.CheckBox1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Controls.Add(Me.PanelUsers)
        Me.Panel2.Location = New System.Drawing.Point(23, 30)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(477, 240)
        Me.Panel2.TabIndex = 734
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.cmdLogin)
        Me.Panel4.Controls.Add(Me.cmdcancel)
        Me.Panel4.Controls.Add(Me.Button1)
        Me.Panel4.Location = New System.Drawing.Point(5, 192)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(464, 40)
        Me.Panel4.TabIndex = 736
        '
        'BGWLOGIN
        '
        Me.BGWLOGIN.WorkerReportsProgress = True
        Me.BGWLOGIN.WorkerSupportsCancellation = True
        '
        'BGWFrmLOGIN_Load
        '
        Me.BGWFrmLOGIN_Load.WorkerReportsProgress = True
        Me.BGWFrmLOGIN_Load.WorkerSupportsCancellation = True
        '
        'BackgroundWorker3
        '
        Me.BackgroundWorker3.WorkerReportsProgress = True
        Me.BackgroundWorker3.WorkerSupportsCancellation = True
        '
        'PictureBox4
        '
        Me.PictureBox4.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(504, 0)
        Me.PictureBox4.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(18, 22)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox4.TabIndex = 737
        Me.PictureBox4.TabStop = False
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BackgroundImage = CType(resources.GetObject("Panel5.BackgroundImage"), System.Drawing.Image)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(18, 0)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(486, 18)
        Me.Panel5.TabIndex = 738
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BackgroundImage = CType(resources.GetObject("Panel6.BackgroundImage"), System.Drawing.Image)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel6.Location = New System.Drawing.Point(504, 18)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(18, 257)
        Me.Panel6.TabIndex = 739
        '
        'PictureBox5
        '
        Me.PictureBox5.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(18, 22)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 740
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.Dock = System.Windows.Forms.DockStyle.Left
        Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
        Me.PictureBox6.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox6.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox6.TabIndex = 741
        Me.PictureBox6.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BackgroundImage = CType(resources.GetObject("Panel7.BackgroundImage"), System.Drawing.Image)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Location = New System.Drawing.Point(0, 18)
        Me.Panel7.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(18, 257)
        Me.Panel7.TabIndex = 742
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.BackgroundImage = CType(resources.GetObject("Panel8.BackgroundImage"), System.Drawing.Image)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(18, 0)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(486, 18)
        Me.Panel8.TabIndex = 743
        '
        'PictureBox7
        '
        Me.PictureBox7.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
        Me.PictureBox7.Location = New System.Drawing.Point(504, 0)
        Me.PictureBox7.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(18, 18)
        Me.PictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox7.TabIndex = 744
        Me.PictureBox7.TabStop = False
        '
        'Panel9
        '
        Me.Panel9.BackColor = System.Drawing.Color.Transparent
        Me.Panel9.Controls.Add(Me.Panel5)
        Me.Panel9.Controls.Add(Me.PictureBox5)
        Me.Panel9.Controls.Add(Me.PictureBox4)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel9.Location = New System.Drawing.Point(0, 275)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(522, 22)
        Me.Panel9.TabIndex = 745
        '
        'Panel10
        '
        Me.Panel10.BackColor = System.Drawing.Color.Transparent
        Me.Panel10.Controls.Add(Me.Panel8)
        Me.Panel10.Controls.Add(Me.PictureBox7)
        Me.Panel10.Controls.Add(Me.PictureBox6)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(522, 18)
        Me.Panel10.TabIndex = 746
        Me.Panel10.TabStop = True
        '
        'FrmLOGIN
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.CC_JO.My.Resources.Resources.A1
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(522, 297)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel7)
        Me.Controls.Add(Me.Panel10)
        Me.Controls.Add(Me.Panel9)
        Me.Controls.Add(Me.Panel2)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLOGIN"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = ""
        Me.Text = "دخـــول المســــتـخـدمـــين"
        Me.TransparencyKey = System.Drawing.Color.Silver
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelUsers.ResumeLayout(False)
        Me.PanelUsers.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents cmdcancel As System.Windows.Forms.Button
    Friend WithEvents cmdLogin As System.Windows.Forms.Button
    Friend WithEvents L2 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents L5 As System.Windows.Forms.Label
    Public WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BGWLOGIN As System.ComponentModel.BackgroundWorker
    Friend WithEvents L4 As System.Windows.Forms.Label
    Friend WithEvents BGWFrmLOGIN_Load As System.ComponentModel.BackgroundWorker
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents BackgroundWorker3 As System.ComponentModel.BackgroundWorker
    Friend WithEvents L3 As System.Windows.Forms.Label
    Friend WithEvents PanelUsers As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel8 As Panel
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents Panel9 As Panel
    Friend WithEvents Panel10 As Panel
    Private WithEvents CircularProgress2 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents L1 As Label
    Private WithEvents Txtpassword As TextBox
    Private WithEvents TxtUser As TextBox
    Private WithEvents CheckBox1 As CheckBox
End Class
