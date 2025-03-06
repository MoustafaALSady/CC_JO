Option Strict Off
Option Explicit On
Imports System.Diagnostics
Imports System.Drawing.Printing
Imports Microsoft.Win32

Public Class FrmFancy
<<<<<<< HEAD
    Inherits Form
=======
    Inherits System.Windows.Forms.Form
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
<<<<<<< HEAD
    Friend WithEvents Label2 As Label
    Friend WithEvents LblShort As Label
    Public WithEvents TxtURL As TextBox
    Friend WithEvents TxtHourCount As TextBox
    Public WithEvents Label16 As Label
    Public WithEvents Label4 As Label
    Friend WithEvents MenuItem5 As MenuItem
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents TxtKey As Label
    Friend WithEvents BtnMinimize As Button
    Friend WithEvents BtnExit1 As Button
    Friend WithEvents LstSoftware As ListBox
=======
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents LblShort As System.Windows.Forms.Label
    Public WithEvents TxtURL As System.Windows.Forms.TextBox
    Friend WithEvents TxtHourCount As System.Windows.Forms.TextBox
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents TxtKey As System.Windows.Forms.Label
    Friend WithEvents BtnMinimize As System.Windows.Forms.Button
    Friend WithEvents BtnExit1 As System.Windows.Forms.Button
    Friend WithEvents LstSoftware As System.Windows.Forms.ListBox
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
    Friend WithEvents BtnUnistall As FsButton
    Friend WithEvents BtnHelp As FsButton
    Friend WithEvents BtnRemove As FsButton
    Friend WithEvents BtnEmail As FsButton
    Friend WithEvents BtnRefresh As FsButton
<<<<<<< HEAD
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents PnlBrowser As Panel
    Friend WithEvents PnlAbout As Panel
    Friend WithEvents BtnCloseAbout As FsButton
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents BtnVote As FsButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnAbout As FsButton
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(FrmFancy))
        Me.Label4 = New Label()
        Me.Label16 = New Label()
        Me.Label2 = New Label()
        Me.LblShort = New Label()
        Me.TxtURL = New TextBox()
        Me.TxtHourCount = New TextBox()
        Me.MenuItem5 = New MenuItem()
        Me.PictureBox4 = New PictureBox()
        Me.BtnMinimize = New Button()
        Me.BtnExit1 = New Button()
        Me.ListBox1 = New ListBox()
        Me.TxtKey = New Label()
        Me.LstSoftware = New ListBox()
        Me.PictureBox2 = New PictureBox()
        Me.ToolTip1 = New ToolTip(Me.components)
        Me.WebBrowser1 = New WebBrowser()
=======
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents PnlBrowser As System.Windows.Forms.Panel
    Friend WithEvents PnlAbout As System.Windows.Forms.Panel
    Friend WithEvents BtnCloseAbout As FsButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BtnVote As FsButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents BtnAbout As FsButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(FrmFancy))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LblShort = New System.Windows.Forms.Label()
        Me.TxtURL = New System.Windows.Forms.TextBox()
        Me.TxtHourCount = New System.Windows.Forms.TextBox()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.BtnMinimize = New System.Windows.Forms.Button()
        Me.BtnExit1 = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.TxtKey = New System.Windows.Forms.Label()
        Me.LstSoftware = New System.Windows.Forms.ListBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnVote = New FsButton()
        Me.BtnRefresh = New FsButton()
        Me.BtnEmail = New FsButton()
        Me.BtnRemove = New FsButton()
        Me.BtnHelp = New FsButton()
        Me.BtnUnistall = New FsButton()
<<<<<<< HEAD
        Me.Label3 = New Label()
        Me.Label7 = New Label()
        Me.Label5 = New Label()
        Me.PictureBox5 = New PictureBox()
        Me.PnlBrowser = New Panel()
        Me.PnlAbout = New Panel()
        Me.PictureBox1 = New PictureBox()
        Me.BtnCloseAbout = New FsButton()
        Me.Label6 = New Label()
        Me.Label1 = New Label()
        Me.BtnAbout = New FsButton()
        CType(Me.PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBrowser.SuspendLayout()
        Me.PnlAbout.SuspendLayout()
        CType(Me.PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
=======
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PnlBrowser = New System.Windows.Forms.Panel()
        Me.PnlAbout = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BtnCloseAbout = New FsButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BtnAbout = New FsButton()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PnlBrowser.SuspendLayout()
        Me.PnlAbout.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
<<<<<<< HEAD
        Me.Label4.Font = New Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New Point(129, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(241, 22)
=======
        Me.Label4.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Label4.Location = New System.Drawing.Point(129, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(241, 22)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label4.TabIndex = 84
        Me.Label4.Text = "Add Remove Pro Version"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.FlatStyle = System.Windows.Forms.FlatStyle.Flat
<<<<<<< HEAD
        Me.Label16.Font = New Font("Trebuchet MS", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), Image)
        Me.Label16.Location = New Point(21, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New Size(53, 45)
=======
        Me.Label16.Font = New System.Drawing.Font("Trebuchet MS", 15.75!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Yellow
        Me.Label16.Image = CType(resources.GetObject("Label16.Image"), System.Drawing.Image)
        Me.Label16.Location = New System.Drawing.Point(21, 9)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 45)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label16.TabIndex = 97
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
<<<<<<< HEAD
        Me.Label2.Font = New Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(296, 32)
=======
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(24, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(296, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label2.TabIndex = 85
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LblShort
        '
<<<<<<< HEAD
        Me.LblShort.Location = New Point(520, 160)
        Me.LblShort.Name = "LblShort"
        Me.LblShort.Size = New Size(100, 23)
=======
        Me.LblShort.Location = New System.Drawing.Point(520, 160)
        Me.LblShort.Name = "LblShort"
        Me.LblShort.Size = New System.Drawing.Size(100, 23)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.LblShort.TabIndex = 122
        Me.LblShort.Text = "lblShortCut"
        Me.LblShort.Visible = False
        '
        'TxtURL
        '
        Me.TxtURL.AcceptsReturn = True
        Me.TxtURL.BackColor = System.Drawing.SystemColors.Window
        Me.TxtURL.Cursor = System.Windows.Forms.Cursors.IBeam
<<<<<<< HEAD
        Me.TxtURL.Font = New Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtURL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtURL.Location = New Point(512, 96)
        Me.TxtURL.MaxLength = 0
        Me.TxtURL.Name = "TxtURL"
        Me.TxtURL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtURL.Size = New Size(104, 20)
=======
        Me.TxtURL.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtURL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.TxtURL.Location = New System.Drawing.Point(512, 96)
        Me.TxtURL.MaxLength = 0
        Me.TxtURL.Name = "TxtURL"
        Me.TxtURL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtURL.Size = New System.Drawing.Size(104, 20)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TxtURL.TabIndex = 123
        Me.TxtURL.Text = "dyn.everydns.net"
        Me.TxtURL.Visible = False
        '
        'TxtHourCount
        '
<<<<<<< HEAD
        Me.TxtHourCount.Location = New Point(512, 128)
        Me.TxtHourCount.Name = "TxtHourCount"
        Me.TxtHourCount.Size = New Size(100, 20)
=======
        Me.TxtHourCount.Location = New System.Drawing.Point(512, 128)
        Me.TxtHourCount.Name = "TxtHourCount"
        Me.TxtHourCount.Size = New System.Drawing.Size(100, 20)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TxtHourCount.TabIndex = 124
        Me.TxtHourCount.TabStop = False
        Me.TxtHourCount.Text = "0"
        Me.TxtHourCount.Visible = False
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = -1
        Me.MenuItem5.Text = ""
        '
        'PictureBox4
        '
<<<<<<< HEAD
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), Image)
        Me.PictureBox4.Location = New Point(457, 55)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New Size(32, 32)
=======
        Me.PictureBox4.BackgroundImage = CType(resources.GetObject("PictureBox4.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox4.Location = New System.Drawing.Point(457, 55)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(32, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox4.TabIndex = 153
        Me.PictureBox4.TabStop = False
        '
        'BtnMinimize
        '
        Me.BtnMinimize.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.BtnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.System
<<<<<<< HEAD
        Me.BtnMinimize.Font = New Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMinimize.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnMinimize.Location = New Point(447, 8)
        Me.BtnMinimize.Name = "BtnMinimize"
        Me.BtnMinimize.Size = New Size(22, 24)
=======
        Me.BtnMinimize.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnMinimize.ForeColor = System.Drawing.SystemColors.Desktop
        Me.BtnMinimize.Location = New System.Drawing.Point(447, 8)
        Me.BtnMinimize.Name = "BtnMinimize"
        Me.BtnMinimize.Size = New System.Drawing.Size(22, 24)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnMinimize.TabIndex = 158
        Me.BtnMinimize.Text = "-" & Global.Microsoft.VisualBasic.ChrW(13)
        Me.ToolTip1.SetToolTip(Me.BtnMinimize, "Minimize to taskbar.")
        Me.BtnMinimize.UseVisualStyleBackColor = False
        '
        'BtnExit1
        '
        Me.BtnExit1.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.BtnExit1.FlatStyle = System.Windows.Forms.FlatStyle.System
<<<<<<< HEAD
        Me.BtnExit1.Font = New Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnExit1.Location = New Point(469, 8)
        Me.BtnExit1.Name = "BtnExit1"
        Me.BtnExit1.Size = New Size(22, 24)
=======
        Me.BtnExit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnExit1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BtnExit1.Location = New System.Drawing.Point(469, 8)
        Me.BtnExit1.Name = "BtnExit1"
        Me.BtnExit1.Size = New System.Drawing.Size(22, 24)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnExit1.TabIndex = 159
        Me.BtnExit1.Text = "X"
        Me.ToolTip1.SetToolTip(Me.BtnExit1, "Close add remove pro.")
        Me.BtnExit1.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
<<<<<<< HEAD
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.ListBox1.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ListBox1.Location = New Point(116, 92)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New Size(369, 316)
=======
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.BackColor = System.Drawing.Color.AliceBlue
        Me.ListBox1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.ListBox1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.ListBox1.Location = New System.Drawing.Point(116, 92)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(369, 316)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ListBox1.TabIndex = 164
        '
        'TxtKey
        '
        Me.TxtKey.BackColor = System.Drawing.Color.SteelBlue
<<<<<<< HEAD
        Me.TxtKey.Font = New Font("Traditional Arabic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtKey.ForeColor = System.Drawing.Color.GreenYellow
        Me.TxtKey.Location = New Point(133, 152)
        Me.TxtKey.Name = "TxtKey"
        Me.TxtKey.Size = New Size(339, 24)
=======
        Me.TxtKey.Font = New System.Drawing.Font("Traditional Arabic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtKey.ForeColor = System.Drawing.Color.GreenYellow
        Me.TxtKey.Location = New System.Drawing.Point(133, 152)
        Me.TxtKey.Name = "TxtKey"
        Me.TxtKey.Size = New System.Drawing.Size(339, 24)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.TxtKey.TabIndex = 165
        Me.TxtKey.Text = "CC_JO"
        Me.TxtKey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LstSoftware
        '
        Me.LstSoftware.BackColor = System.Drawing.Color.AliceBlue
<<<<<<< HEAD
        Me.LstSoftware.Font = New Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.LstSoftware.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LstSoftware.Location = New Point(116, 86)
        Me.LstSoftware.Name = "LstSoftware"
        Me.LstSoftware.Size = New Size(373, 329)
=======
        Me.LstSoftware.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(162, Byte))
        Me.LstSoftware.ForeColor = System.Drawing.SystemColors.Desktop
        Me.LstSoftware.Location = New System.Drawing.Point(116, 86)
        Me.LstSoftware.Name = "LstSoftware"
        Me.LstSoftware.Size = New System.Drawing.Size(373, 329)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.LstSoftware.Sorted = True
        Me.LstSoftware.TabIndex = 174
        '
        'PictureBox2
        '
<<<<<<< HEAD
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        Me.PictureBox2.Location = New Point(116, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New Size(32, 30)
=======
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(116, 57)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(32, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 182
        Me.PictureBox2.TabStop = False
        '
        'WebBrowser1
        '
<<<<<<< HEAD
        Me.WebBrowser1.Location = New Point(-2, 4)
        Me.WebBrowser1.MinimumSize = New Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New Size(368, 316)
=======
        Me.WebBrowser1.Location = New System.Drawing.Point(-2, 4)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(368, 316)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.WebBrowser1.TabIndex = 187
        Me.ToolTip1.SetToolTip(Me.WebBrowser1, "Click help button to remove help file and return to list.")
        '
        'BtnVote
        '
        Me.BtnVote.BackColor = System.Drawing.Color.LightGray
        Me.BtnVote.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnVote.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVote.ForeColor = System.Drawing.Color.Yellow
        Me.BtnVote.Location = New Point(12, 302)
        Me.BtnVote.Name = "BtnVote"
        Me.BtnVote.Size = New Size(43, 41)
=======
        Me.BtnVote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnVote.ForeColor = System.Drawing.Color.Yellow
        Me.BtnVote.Location = New System.Drawing.Point(12, 302)
        Me.BtnVote.Name = "BtnVote"
        Me.BtnVote.Size = New System.Drawing.Size(43, 41)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnVote.TabIndex = 191
        Me.BtnVote.Text = "PSC"
        Me.BtnVote.ThemeColor = System.Drawing.Color.RoyalBlue
        Me.ToolTip1.SetToolTip(Me.BtnVote, "Link back to SC in case you want " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "to rate the software or leave a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "comment or s" &
        "uggestion for" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Improvements")
        '
        'BtnRefresh
        '
        Me.BtnRefresh.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnRefresh.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.ForeColor = System.Drawing.Color.Yellow
        Me.BtnRefresh.Location = New Point(12, 184)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New Size(87, 30)
=======
        Me.BtnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRefresh.ForeColor = System.Drawing.Color.Yellow
        Me.BtnRefresh.Location = New System.Drawing.Point(12, 184)
        Me.BtnRefresh.Name = "BtnRefresh"
        Me.BtnRefresh.Size = New System.Drawing.Size(87, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnRefresh.TabIndex = 179
        Me.BtnRefresh.Text = "Refresh"
        Me.BtnRefresh.ThemeColor = System.Drawing.Color.RoyalBlue
        Me.ToolTip1.SetToolTip(Me.BtnRefresh, "Refreshes the list as needed.")
        '
        'BtnEmail
        '
        Me.BtnEmail.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnEmail.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmail.ForeColor = System.Drawing.Color.Yellow
        Me.BtnEmail.Location = New Point(12, 216)
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New Size(87, 30)
=======
        Me.BtnEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnEmail.ForeColor = System.Drawing.Color.Yellow
        Me.BtnEmail.Location = New System.Drawing.Point(12, 216)
        Me.BtnEmail.Name = "BtnEmail"
        Me.BtnEmail.Size = New System.Drawing.Size(87, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnEmail.TabIndex = 178
        Me.BtnEmail.Text = "Email"
        Me.BtnEmail.ThemeColor = System.Drawing.Color.RoyalBlue
        Me.ToolTip1.SetToolTip(Me.BtnEmail, "Email author for technical support.")
        '
        'BtnRemove
        '
        Me.BtnRemove.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnRemove.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.Color.Yellow
        Me.BtnRemove.Location = New Point(12, 152)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New Size(87, 30)
=======
        Me.BtnRemove.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnRemove.ForeColor = System.Drawing.Color.Yellow
        Me.BtnRemove.Location = New System.Drawing.Point(12, 152)
        Me.BtnRemove.Name = "BtnRemove"
        Me.BtnRemove.Size = New System.Drawing.Size(87, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnRemove.TabIndex = 177
        Me.BtnRemove.Text = "Remove"
        Me.BtnRemove.ThemeColor = System.Drawing.Color.RoyalBlue
        Me.ToolTip1.SetToolTip(Me.BtnRemove, "Only removes the selected entry. ")
        '
        'BtnHelp
        '
        Me.BtnHelp.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnHelp.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHelp.ForeColor = System.Drawing.Color.Yellow
        Me.BtnHelp.Location = New Point(12, 86)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New Size(87, 30)
=======
        Me.BtnHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnHelp.ForeColor = System.Drawing.Color.Yellow
        Me.BtnHelp.Location = New System.Drawing.Point(12, 86)
        Me.BtnHelp.Name = "BtnHelp"
        Me.BtnHelp.Size = New System.Drawing.Size(87, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnHelp.TabIndex = 176
        Me.BtnHelp.Text = "Help"
        Me.BtnHelp.ThemeColor = System.Drawing.Color.RoyalBlue
        Me.ToolTip1.SetToolTip(Me.BtnHelp, "Show help file for add remove pro.")
        '
        'BtnUnistall
        '
        Me.BtnUnistall.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnUnistall.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnistall.ForeColor = System.Drawing.Color.Yellow
        Me.BtnUnistall.Location = New Point(12, 120)
        Me.BtnUnistall.Name = "BtnUnistall"
        Me.BtnUnistall.Size = New Size(87, 30)
=======
        Me.BtnUnistall.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnUnistall.ForeColor = System.Drawing.Color.Yellow
        Me.BtnUnistall.Location = New System.Drawing.Point(12, 120)
        Me.BtnUnistall.Name = "BtnUnistall"
        Me.BtnUnistall.Size = New System.Drawing.Size(87, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnUnistall.TabIndex = 175
        Me.BtnUnistall.Text = "Uninstall"
        Me.BtnUnistall.ThemeColor = System.Drawing.Color.RoyalBlue
        Me.ToolTip1.SetToolTip(Me.BtnUnistall, "Uninstalls the selected item" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "using windows unistaller.")
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.MidnightBlue
<<<<<<< HEAD
        Me.Label3.Location = New Point(116, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(16, 8)
=======
        Me.Label3.Location = New System.Drawing.Point(116, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(16, 8)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label3.TabIndex = 184
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.MidnightBlue
<<<<<<< HEAD
        Me.Label7.Location = New Point(457, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(16, 8)
=======
        Me.Label7.Location = New System.Drawing.Point(457, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(16, 8)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label7.TabIndex = 186
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.MidnightBlue
<<<<<<< HEAD
        Me.Label5.Location = New Point(274, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(16, 8)
=======
        Me.Label5.Location = New System.Drawing.Point(274, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(16, 8)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label5.TabIndex = 185
        '
        'PictureBox5
        '
<<<<<<< HEAD
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), Image)
        Me.PictureBox5.Location = New Point(274, 57)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New Size(32, 30)
=======
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.Location = New System.Drawing.Point(274, 57)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(32, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 181
        Me.PictureBox5.TabStop = False
        '
        'PnlBrowser
        '
        Me.PnlBrowser.BackColor = System.Drawing.Color.RoyalBlue
        Me.PnlBrowser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PnlBrowser.Controls.Add(Me.WebBrowser1)
<<<<<<< HEAD
        Me.PnlBrowser.Location = New Point(116, 88)
        Me.PnlBrowser.Name = "PnlBrowser"
        Me.PnlBrowser.Size = New Size(373, 330)
=======
        Me.PnlBrowser.Location = New System.Drawing.Point(116, 88)
        Me.PnlBrowser.Name = "PnlBrowser"
        Me.PnlBrowser.Size = New System.Drawing.Size(373, 330)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PnlBrowser.TabIndex = 188
        '
        'PnlAbout
        '
        Me.PnlAbout.BackColor = System.Drawing.Color.SteelBlue
        Me.PnlAbout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PnlAbout.Controls.Add(Me.PictureBox1)
        Me.PnlAbout.Controls.Add(Me.BtnCloseAbout)
        Me.PnlAbout.Controls.Add(Me.Label6)
        Me.PnlAbout.Controls.Add(Me.Label1)
<<<<<<< HEAD
        Me.PnlAbout.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PnlAbout.Location = New Point(116, 86)
        Me.PnlAbout.Name = "PnlAbout"
        Me.PnlAbout.Size = New Size(373, 328)
=======
        Me.PnlAbout.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PnlAbout.Location = New System.Drawing.Point(116, 86)
        Me.PnlAbout.Name = "PnlAbout"
        Me.PnlAbout.Size = New System.Drawing.Size(373, 328)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PnlAbout.TabIndex = 190
        '
        'PictureBox1
        '
<<<<<<< HEAD
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        Me.PictureBox1.Location = New Point(125, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Size(120, 80)
=======
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(125, 97)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(120, 80)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 178
        Me.PictureBox1.TabStop = False
        '
        'BtnCloseAbout
        '
        Me.BtnCloseAbout.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnCloseAbout.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCloseAbout.ForeColor = System.Drawing.Color.Yellow
        Me.BtnCloseAbout.Location = New Point(302, 269)
        Me.BtnCloseAbout.Name = "BtnCloseAbout"
        Me.BtnCloseAbout.Size = New Size(50, 50)
=======
        Me.BtnCloseAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnCloseAbout.ForeColor = System.Drawing.Color.Yellow
        Me.BtnCloseAbout.Location = New System.Drawing.Point(302, 269)
        Me.BtnCloseAbout.Name = "BtnCloseAbout"
        Me.BtnCloseAbout.Size = New System.Drawing.Size(50, 50)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnCloseAbout.TabIndex = 177
        Me.BtnCloseAbout.Text = "Close"
        Me.BtnCloseAbout.ThemeColor = System.Drawing.Color.RoyalBlue
        '
        'Label6
        '
        Me.Label6.AutoSize = True
<<<<<<< HEAD
        Me.Label6.Font = New Font("Traditional Arabic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New Point(105, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(160, 23)
=======
        Me.Label6.Font = New System.Drawing.Font("Traditional Arabic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(105, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(160, 23)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "‰Ÿ«„ ≈œ«—… Ê„Õ«”»… «·Ã„⁄Ì«  «· ⁄«Ê‰Ì…"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
<<<<<<< HEAD
        Me.Label1.Font = New Font("Traditional Arabic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New Point(128, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(114, 23)
=======
        Me.Label1.Font = New System.Drawing.Font("Traditional Arabic", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(128, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 23)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "«·„‰ Ã «·√Ê· »—«„Ã ÊÌ‰œÊ“"
        '
        'BtnAbout
        '
        Me.BtnAbout.ButtonTheme = FsButton.Themes.Aqua
<<<<<<< HEAD
        Me.BtnAbout.Font = New Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbout.ForeColor = System.Drawing.Color.Yellow
        Me.BtnAbout.Location = New Point(12, 249)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New Size(87, 30)
=======
        Me.BtnAbout.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnAbout.ForeColor = System.Drawing.Color.Yellow
        Me.BtnAbout.Location = New System.Drawing.Point(12, 249)
        Me.BtnAbout.Name = "BtnAbout"
        Me.BtnAbout.Size = New System.Drawing.Size(87, 30)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.BtnAbout.TabIndex = 180
        Me.BtnAbout.Text = "About"
        Me.BtnAbout.ThemeColor = System.Drawing.Color.RoyalBlue
        '
        'FrmFancy
        '
<<<<<<< HEAD
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New Size(498, 418)
=======
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(498, 418)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ControlBox = False
        Me.Controls.Add(Me.BtnVote)
        Me.Controls.Add(Me.LstSoftware)
        Me.Controls.Add(Me.PnlBrowser)
        Me.Controls.Add(Me.BtnMinimize)
        Me.Controls.Add(Me.BtnExit1)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BtnAbout)
        Me.Controls.Add(Me.BtnRefresh)
        Me.Controls.Add(Me.BtnEmail)
        Me.Controls.Add(Me.BtnRemove)
        Me.Controls.Add(Me.BtnHelp)
        Me.Controls.Add(Me.BtnUnistall)
        Me.Controls.Add(Me.TxtHourCount)
        Me.Controls.Add(Me.TxtURL)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblShort)
        Me.Controls.Add(Me.TxtKey)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PnlAbout)
        Me.Controls.Add(Me.Label7)
        Me.ForeColor = System.Drawing.SystemColors.Desktop
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
<<<<<<< HEAD
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
=======
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmFancy"
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Remove Pro "
        Me.TransparencyKey = System.Drawing.Color.DarkRed
<<<<<<< HEAD
        CType(Me.PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBrowser.ResumeLayout(False)
        Me.PnlAbout.ResumeLayout(False)
        Me.PnlAbout.PerformLayout()
        CType(Me.PictureBox1, ComponentModel.ISupportInitialize).EndInit()
=======
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PnlBrowser.ResumeLayout(False)
        Me.PnlAbout.ResumeLayout(False)
        Me.PnlAbout.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    'Dim Clear As Double
    Private WithEvents MDoc As New PrintDocument
    Private ReadOnly mFont As New Font("Courier New", 12)
    Private mouse_offset As Point
    Private str As String
    Private ReadOnly list As New ArrayList
    Private DisplayName, UnistallString As String
    Private BrowserIsVisible As Boolean

    Public Structure Element
        Public key As String
        Public dname As String
        Public ustr As String
    End Structure

#Region "Form Move and load Routines"

    ''' <summary>
    ''' Gets the mouse position and calculates the offset to move the form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub StartBar_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseDown
=======
    Private Sub StartBar_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub

    ''' <summary>
    ''' Calculates the mouse movement and moves the form to the mouse up position
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub StartBar_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles MyBase.MouseMove
=======
    Private Sub StartBar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = Control.MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Location = mousePos
        End If
    End Sub

    ''' <summary>
    ''' Form load sub procedure
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub FrmFancy_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
=======
    Private Sub FrmFancy_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        str = "SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall\"
        LstSoftware.BringToFront()
        Call RefresfTheProgramList()
    End Sub

    ''' <summary>
    ''' When mouse is on an area of the form it shows the hand cursor
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub FrmFancy_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles Me.MouseHover
=======
    Private Sub FrmFancy_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Cursor = Cursors.Hand
    End Sub

    ''' <summary>
    ''' When an area that is not the cursor returns to normal
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub FrmFancy_MouseLeave(sender As Object, ByVal e As EventArgs) Handles Me.MouseLeave
=======
    Private Sub FrmFancy_MouseLeave(sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Cursor = Cursors.Default
    End Sub
#End Region

#Region "Button Click Events"

    ''' <summary>
    ''' Allows the form to fade when exiting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnExit1.Click
=======
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnExit1.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Fade Out and exit
        Dim Clear As Double
        For Clear = 1 To 0 Step -0.01
            Me.Opacity = Clear
        Next
        Me.Close()
    End Sub

    ''' <summary>
    ''' Invokes the uninstall of selected program
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnUninstall_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnUnistall.Click
=======
    Private Sub BtnUninstall_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUnistall.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TxtKey.Text = Nothing Then
            MsgBox("Sorry no file selected to uninstall." & vbCrLf & "Please select file from list and try again.")
            Exit Sub
        End If
        Try
            'MsgBox(Element)
            Shell(CType(list.Item(ListBox1.SelectedIndex), Element).ustr, AppWinStyle.NormalFocus)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Call RefresfTheProgramList()
    End Sub

    'Sub to remove the text entry from the list
    ''' <summary>
    ''' Removes the selected listbox entry using the selected items text
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnRemove.Click
=======
    Private Sub BtnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRemove.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If TxtKey.Text = Nothing Then
            MsgBox("Sorry you must choose a file to remove")
        Else
            If MsgBox("Are You Sure?" & vbCrLf & "This action can not be undone!", MessageBoxIcon.Warning, MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If
            Dim KeyToRemove As String = TxtKey.Text
            Registry.LocalMachine.DeleteSubKey(str & KeyToRemove)
            Call RefresfTheProgramList()
            TxtKey.Text = Nothing
        End If
        Call RefresfTheProgramList()
    End Sub

    ''' <summary>
    ''' Allows the form to minimized to the taskbar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnMinimize_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnMinimize.Click
=======
    Private Sub BtnMinimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnMinimize.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.WindowState = FormWindowState.Minimized
        Me.ShowInTaskbar = True
    End Sub

    ''' <summary>
    ''' Shows the about form dialog box
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnAbout_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnAbout.Click
=======
    Private Sub BtnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnAbout.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        BrowserIsVisible = False
        PnlAbout.BringToFront()
    End Sub

    ''' <summary>
    ''' Removed I shut my server down
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnEmail_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnEmail.Click
=======
    Private Sub BtnEmail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnEmail.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Process.Start("mailto: ma965880@gmail.com")
    End Sub

    ''' <summary>
    ''' Link to PSC for voting.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnVote_Click(ByVal sender As System.Object, ByVal e As EventArgs)
=======
    Private Sub BtnVote_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Process.Start("http://jcc.gov.jo/")
        'Dim F As New frmNewVerion
        'F.Text = "ÕÊ· «·»—‰«„Ã"
        'F.WebBrowser1.Navigate(Application.StartupPath & "\MyLibrary\MyHelp1.mht")
        'F.Show()
    End Sub

    ''' <summary>
    ''' Display the help file in the browser window
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnHelp.Click
=======
    Private Sub BtnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHelp.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        WebBrowser1.Navigate(Application.StartupPath & "\MyLibrary\introduction.htm")
        PnlAbout.SendToBack()
        If BrowserIsVisible Then
            PnlBrowser.SendToBack()
            WebBrowser1.SendToBack()
            BrowserIsVisible = False
            LstSoftware.BringToFront()
        Else
            PnlBrowser.BringToFront()
            WebBrowser1.BringToFront()
            BrowserIsVisible = True
        End If
    End Sub

    ''' <summary>
    ''' Closes the about window
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnCloseAbout_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnCloseAbout.Click
=======
    Private Sub BtnCloseAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCloseAbout.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        If BrowserIsVisible Then
            PnlBrowser.SendToBack()
            WebBrowser1.SendToBack()
            BrowserIsVisible = False
        Else
            LstSoftware.BringToFront()
        End If
    End Sub

    ''' <summary>
    ''' Added to allow a refresh if needed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnRefresh.Click
=======
    Private Sub BtnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Call RefresfTheProgramList()
    End Sub

    ''' <summary>
    ''' Link back to down page for commenting or voting
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub BtnVote_Click_1(ByVal sender As System.Object, ByVal e As EventArgs) Handles BtnVote.Click
=======
    Private Sub BtnVote_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnVote.Click
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        On Error Resume Next
        Process.Start("http://jcc.gov.jo/")
    End Sub

#End Region

#Region "Listbox Subroutine procedures"

    ''' <summary>
    ''' Due to sorting issues listbox1 is hidden and only used when Listbox 2 is selected it
    ''' selects the same name as listbox2 for index purposes
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As EventArgs) Handles ListBox1.SelectedIndexChanged
=======
    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        TxtKey.Text = Nothing
        LstSoftware.SelectedItem = ListBox1.SelectedItem
        TxtKey.Text = CType(list.Item(ListBox1.SelectedIndex), Element).key
    End Sub

    ''' <summary>
    ''' Due to sorting listbox 2 when selected finds the equvilant text in listbox 1 and selects it.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
<<<<<<< HEAD
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles LstSoftware.SelectedIndexChanged
=======
    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstSoftware.SelectedIndexChanged
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        ListBox1.SelectedItem = LstSoftware.SelectedItem
    End Sub

#End Region

    ''' <summary>
    ''' Fills the listboxes with information related to each item available for removal
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RefresfTheProgramList()
        Dim subkey, pr As RegistryKey
        Dim subkeys() As String
        Try
            ListBox1.Items.Clear()
            LstSoftware.Items.Clear()
            list.Clear()
            subkey = Registry.LocalMachine.OpenSubKey(str)
            subkeys = subkey.GetSubKeyNames()
            Dim xkey As String
            For Each xkey In subkeys
                pr = subkey.OpenSubKey(xkey)
                DisplayName = pr.GetValue("DisplayName", "")
                UnistallString = pr.GetValue("UnInstallString", "")
                If DisplayName <> "" And UnistallString <> "" Then
                    ListBox1.Items.Add(DisplayName)
                    LstSoftware.Items.Add(DisplayName)
                    Dim item As New Element With {
                        .key = xkey,
                        .dname = DisplayName,
                        .ustr = UnistallString
                    }
                    list.Add(item)
                End If
            Next
            TxtKey.Text = Nothing
            Me.Invalidate()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
