<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBackup1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBackup1))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.ButBackup = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboDBServer = New System.Windows.Forms.ComboBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ChOverwriteAll = New System.Windows.Forms.CheckBox()
        Me.RaToNew = New System.Windows.Forms.RadioButton()
        Me.ChAppendTo = New System.Windows.Forms.CheckBox()
        Me.RaToExisting = New System.Windows.Forms.RadioButton()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.GroupDefaultFolderSettings = New System.Windows.Forms.GroupBox()
        Me.PanelDefaultFolderSettings = New System.Windows.Forms.Panel()
        Me.ButtonXP1 = New System.Windows.Forms.Button()
        Me.LabelMYFOLDER = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboMinute = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RaPerHours = New System.Windows.Forms.RadioButton()
        Me.RaAutoClose = New System.Windows.Forms.RadioButton()
        Me.RaStob = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CombBackupType = New System.Windows.Forms.ComboBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupDefaultFolderSettings.SuspendLayout()
        Me.PanelDefaultFolderSettings.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.TabControl1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(0, 25)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(429, 245)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.ButBackup)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.GroupBox4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(421, 217)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "النسخ الاحتياطي"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'ButBackup
        '
        Me.ButBackup.BackColor = System.Drawing.Color.Transparent
        Me.ButBackup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButBackup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButBackup.Image = CType(resources.GetObject("ButBackup.Image"), System.Drawing.Image)
        Me.ButBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButBackup.Location = New System.Drawing.Point(8, 185)
        Me.ButBackup.Margin = New System.Windows.Forms.Padding(2)
        Me.ButBackup.Name = "ButBackup"
        Me.ButBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButBackup.Size = New System.Drawing.Size(162, 25)
        Me.ButBackup.TabIndex = 621
        Me.ButBackup.Text = "نسخة احتياطية لقاعدة بيانات"
        Me.ButBackup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButBackup.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ComboDBServer)
        Me.Panel1.Location = New System.Drawing.Point(3, 10)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(410, 36)
        Me.Panel1.TabIndex = 620
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(324, 10)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 522
        Me.Label1.Text = "قواعد البيانات"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboDBServer
        '
        Me.ComboDBServer.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboDBServer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComboDBServer.FormattingEnabled = True
        Me.ComboDBServer.Location = New System.Drawing.Point(3, 6)
        Me.ComboDBServer.Name = "ComboDBServer"
        Me.ComboDBServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboDBServer.Size = New System.Drawing.Size(318, 23)
        Me.ComboDBServer.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ChOverwriteAll)
        Me.GroupBox4.Controls.Add(Me.RaToNew)
        Me.GroupBox4.Controls.Add(Me.ChAppendTo)
        Me.GroupBox4.Controls.Add(Me.RaToExisting)
        Me.GroupBox4.Location = New System.Drawing.Point(5, 49)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(408, 133)
        Me.GroupBox4.TabIndex = 619
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "خيارات النسخ الاحتياطي"
        '
        'ChOverwriteAll
        '
        Me.ChOverwriteAll.AutoSize = True
        Me.ChOverwriteAll.Location = New System.Drawing.Point(29, 76)
        Me.ChOverwriteAll.Name = "ChOverwriteAll"
        Me.ChOverwriteAll.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChOverwriteAll.Size = New System.Drawing.Size(216, 19)
        Me.ChOverwriteAll.TabIndex = 5
        Me.ChOverwriteAll.Text = "Overwrite all  Existing Backup set "
        Me.ChOverwriteAll.UseVisualStyleBackColor = True
        '
        'RaToNew
        '
        Me.RaToNew.AutoSize = True
        Me.RaToNew.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RaToNew.ForeColor = System.Drawing.Color.Tomato
        Me.RaToNew.Location = New System.Drawing.Point(9, 104)
        Me.RaToNew.Margin = New System.Windows.Forms.Padding(2)
        Me.RaToNew.Name = "RaToNew"
        Me.RaToNew.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RaToNew.Size = New System.Drawing.Size(366, 19)
        Me.RaToNew.TabIndex = 617
        Me.RaToNew.Text = "Back up To a new media set and erase all Existing Backup sets "
        Me.RaToNew.UseVisualStyleBackColor = True
        '
        'ChAppendTo
        '
        Me.ChAppendTo.AutoSize = True
        Me.ChAppendTo.Checked = True
        Me.ChAppendTo.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChAppendTo.Location = New System.Drawing.Point(29, 53)
        Me.ChAppendTo.Name = "ChAppendTo"
        Me.ChAppendTo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ChAppendTo.Size = New System.Drawing.Size(214, 19)
        Me.ChAppendTo.TabIndex = 4
        Me.ChAppendTo.Text = "Append to the Existing Backup set "
        Me.ChAppendTo.UseVisualStyleBackColor = True
        '
        'RaToExisting
        '
        Me.RaToExisting.AutoSize = True
        Me.RaToExisting.Checked = True
        Me.RaToExisting.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RaToExisting.ForeColor = System.Drawing.Color.Tomato
        Me.RaToExisting.Location = New System.Drawing.Point(9, 24)
        Me.RaToExisting.Margin = New System.Windows.Forms.Padding(2)
        Me.RaToExisting.Name = "RaToExisting"
        Me.RaToExisting.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.RaToExisting.Size = New System.Drawing.Size(188, 19)
        Me.RaToExisting.TabIndex = 3
        Me.RaToExisting.TabStop = True
        Me.RaToExisting.Text = "Back up To Existing media set"
        Me.RaToExisting.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(421, 217)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "استراجع النسخ الاحتياطية"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.GroupDefaultFolderSettings)
        Me.TabPage3.Controls.Add(Me.GroupBox1)
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(421, 217)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "اعدادت النسخ الاحتياطي"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'GroupDefaultFolderSettings
        '
        Me.GroupDefaultFolderSettings.Controls.Add(Me.PanelDefaultFolderSettings)
        Me.GroupDefaultFolderSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupDefaultFolderSettings.ForeColor = System.Drawing.Color.MidnightBlue
        Me.GroupDefaultFolderSettings.Location = New System.Drawing.Point(5, 49)
        Me.GroupDefaultFolderSettings.Name = "GroupDefaultFolderSettings"
        Me.GroupDefaultFolderSettings.Size = New System.Drawing.Size(411, 55)
        Me.GroupDefaultFolderSettings.TabIndex = 975
        Me.GroupDefaultFolderSettings.TabStop = False
        Me.GroupDefaultFolderSettings.Text = "إعدادات المجلد الأفتراضى للتخزين"
        '
        'PanelDefaultFolderSettings
        '
        Me.PanelDefaultFolderSettings.BackColor = System.Drawing.Color.Transparent
        Me.PanelDefaultFolderSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelDefaultFolderSettings.Controls.Add(Me.ButtonXP1)
        Me.PanelDefaultFolderSettings.Controls.Add(Me.LabelMYFOLDER)
        Me.PanelDefaultFolderSettings.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelDefaultFolderSettings.Location = New System.Drawing.Point(3, 18)
        Me.PanelDefaultFolderSettings.Margin = New System.Windows.Forms.Padding(2)
        Me.PanelDefaultFolderSettings.Name = "PanelDefaultFolderSettings"
        Me.PanelDefaultFolderSettings.Size = New System.Drawing.Size(405, 34)
        Me.PanelDefaultFolderSettings.TabIndex = 956
        '
        'ButtonXP1
        '
        Me.ButtonXP1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonXP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonXP1.ForeColor = System.Drawing.Color.Black
        Me.ButtonXP1.Image = Global.CC_JO.My.Resources.Resources.Folder_24x24
        Me.ButtonXP1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXP1.Location = New System.Drawing.Point(2, 2)
        Me.ButtonXP1.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXP1.Name = "ButtonXP1"
        Me.ButtonXP1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonXP1.Size = New System.Drawing.Size(34, 28)
        Me.ButtonXP1.TabIndex = 459
        Me.ButtonXP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXP1.UseVisualStyleBackColor = False
        '
        'LabelMYFOLDER
        '
        Me.LabelMYFOLDER.BackColor = System.Drawing.Color.Transparent
        Me.LabelMYFOLDER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LabelMYFOLDER.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LabelMYFOLDER.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMYFOLDER.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.LabelMYFOLDER.Location = New System.Drawing.Point(37, 2)
        Me.LabelMYFOLDER.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LabelMYFOLDER.Name = "LabelMYFOLDER"
        Me.LabelMYFOLDER.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LabelMYFOLDER.Size = New System.Drawing.Size(364, 28)
        Me.LabelMYFOLDER.TabIndex = 460
        Me.LabelMYFOLDER.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.ComboMinute)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.RaPerHours)
        Me.GroupBox1.Controls.Add(Me.RaAutoClose)
        Me.GroupBox1.Controls.Add(Me.RaStob)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 112)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 97)
        Me.GroupBox1.TabIndex = 622
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "النسخ التلقائي"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Transparent
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button1.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.Location = New System.Drawing.Point(4, 68)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Button1.Size = New System.Drawing.Size(95, 25)
        Me.Button1.TabIndex = 971
        Me.Button1.Text = "حفظ"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ComboMinute
        '
        Me.ComboMinute.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboMinute.ForeColor = System.Drawing.Color.Black
        Me.ComboMinute.FormattingEnabled = True
        Me.ComboMinute.Items.AddRange(New Object() {"0", "5", "10", "15", "20", "30", "60"})
        Me.ComboMinute.Location = New System.Drawing.Point(177, 69)
        Me.ComboMinute.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboMinute.Name = "ComboMinute"
        Me.ComboMinute.Size = New System.Drawing.Size(64, 23)
        Me.ComboMinute.TabIndex = 970
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Maroon
        Me.Label3.Location = New System.Drawing.Point(145, 74)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(28, 15)
        Me.Label3.TabIndex = 969
        Me.Label3.Text = "دقيقة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'RaPerHours
        '
        Me.RaPerHours.AutoSize = True
        Me.RaPerHours.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RaPerHours.ForeColor = System.Drawing.Color.Black
        Me.RaPerHours.Location = New System.Drawing.Point(243, 71)
        Me.RaPerHours.Margin = New System.Windows.Forms.Padding(2)
        Me.RaPerHours.Name = "RaPerHours"
        Me.RaPerHours.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RaPerHours.Size = New System.Drawing.Size(136, 19)
        Me.RaPerHours.TabIndex = 618
        Me.RaPerHours.Text = "انشاء نسخة احتياطيه   كل"
        Me.RaPerHours.UseVisualStyleBackColor = True
        '
        'RaAutoClose
        '
        Me.RaAutoClose.AutoSize = True
        Me.RaAutoClose.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RaAutoClose.ForeColor = System.Drawing.Color.Black
        Me.RaAutoClose.Location = New System.Drawing.Point(179, 44)
        Me.RaAutoClose.Margin = New System.Windows.Forms.Padding(2)
        Me.RaAutoClose.Name = "RaAutoClose"
        Me.RaAutoClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RaAutoClose.Size = New System.Drawing.Size(200, 19)
        Me.RaAutoClose.TabIndex = 617
        Me.RaAutoClose.Text = "انشاء نسخة احتياطيه عند اغلاق البرنامج"
        Me.RaAutoClose.UseVisualStyleBackColor = True
        '
        'RaStob
        '
        Me.RaStob.AutoSize = True
        Me.RaStob.Checked = True
        Me.RaStob.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RaStob.ForeColor = System.Drawing.Color.Black
        Me.RaStob.Location = New System.Drawing.Point(269, 20)
        Me.RaStob.Margin = New System.Windows.Forms.Padding(2)
        Me.RaStob.Name = "RaStob"
        Me.RaStob.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RaStob.Size = New System.Drawing.Size(110, 19)
        Me.RaStob.TabIndex = 3
        Me.RaStob.TabStop = True
        Me.RaStob.Text = "ايقاق النسخ التلقائي"
        Me.RaStob.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.CombBackupType)
        Me.Panel3.Location = New System.Drawing.Point(6, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(410, 36)
        Me.Panel3.TabIndex = 621
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(303, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 15)
        Me.Label2.TabIndex = 522
        Me.Label2.Text = "نوع النسخة الاحتياطية"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CombBackupType
        '
        Me.CombBackupType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CombBackupType.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CombBackupType.FormattingEnabled = True
        Me.CombBackupType.Items.AddRange(New Object() {"Full  Backup", "Differential Backup", "Transaction Log Backup"})
        Me.CombBackupType.Location = New System.Drawing.Point(3, 6)
        Me.CombBackupType.Name = "CombBackupType"
        Me.CombBackupType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CombBackupType.Size = New System.Drawing.Size(297, 23)
        Me.CombBackupType.TabIndex = 1
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripLabel1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(429, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.CC_JO.My.Resources.Resources.help
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.ForeColor = System.Drawing.Color.White
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(145, 22)
        Me.ToolStripLabel1.Text = "نسخة احتياطية لقاعدة بيانات"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 276)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(429, 32)
        Me.Panel2.TabIndex = 621
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.Apply_16x16
        Me.PictureBox1.Location = New System.Drawing.Point(398, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(29, 30)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 621
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'FrmBackup1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(429, 308)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBackup1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نسخة احتياطية لقاعدة بيانات"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.GroupDefaultFolderSettings.ResumeLayout(False)
        Me.PanelDefaultFolderSettings.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents ChOverwriteAll As CheckBox
    Friend WithEvents RaToNew As RadioButton
    Friend WithEvents ChAppendTo As CheckBox
    Friend WithEvents RaToExisting As RadioButton
    Friend WithEvents ComboDBServer As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButBackup As Button
    Friend WithEvents ToolStripLabel1 As ToolStripLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents CombBackupType As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RaAutoClose As RadioButton
    Friend WithEvents RaStob As RadioButton
    Friend WithEvents RaPerHours As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents ComboMinute As ComboBox
    Friend WithEvents GroupDefaultFolderSettings As GroupBox
    Friend WithEvents PanelDefaultFolderSettings As Panel
    Friend WithEvents ButtonXP1 As Button
    Friend WithEvents LabelMYFOLDER As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
