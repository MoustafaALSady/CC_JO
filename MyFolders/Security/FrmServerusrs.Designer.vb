<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmServerusrs
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmServerusrs))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RdoServerConnection = New System.Windows.Forms.RadioButton()
        Me.ComboAuth = New System.Windows.Forms.ComboBox()
        Me.RdoLocalConnection = New System.Windows.Forms.RadioButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ComboServerName = New System.Windows.Forms.ComboBox()
        Me.CheckShowBWS = New System.Windows.Forms.CheckBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboDBServer = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Port1 = New System.Windows.Forms.TextBox()
        Me.BWS = New System.Windows.Forms.TextBox()
        Me.TxtServerName = New System.Windows.Forms.TextBox()
        Me.UserID1 = New System.Windows.Forms.TextBox()
        Me.TextEncrypt = New System.Windows.Forms.TextBox()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButChek = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButClos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Maroon
        Me.GroupBox1.Location = New System.Drawing.Point(3, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(559, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات خادم قواعد البيانات"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.RdoServerConnection)
        Me.Panel2.Controls.Add(Me.ComboAuth)
        Me.Panel2.Controls.Add(Me.RdoLocalConnection)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(553, 63)
        Me.Panel2.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label7.Location = New System.Drawing.Point(308, 36)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 17)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "كيفية الاتصال :-"
        '
        'RdoServerConnection
        '
        Me.RdoServerConnection.AutoSize = True
        Me.RdoServerConnection.Location = New System.Drawing.Point(12, 7)
        Me.RdoServerConnection.Name = "RdoServerConnection"
        Me.RdoServerConnection.Size = New System.Drawing.Size(96, 19)
        Me.RdoServerConnection.TabIndex = 1
        Me.RdoServerConnection.Text = "الكمبيوتر الخادم "
        Me.RdoServerConnection.UseVisualStyleBackColor = True
        '
        'ComboAuth
        '
        Me.ComboAuth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboAuth.FormattingEnabled = True
        Me.ComboAuth.Items.AddRange(New Object() {"Windows Authentication", "SQL Server Authentication"})
        Me.ComboAuth.Location = New System.Drawing.Point(4, 33)
        Me.ComboAuth.Name = "ComboAuth"
        Me.ComboAuth.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboAuth.Size = New System.Drawing.Size(299, 23)
        Me.ComboAuth.TabIndex = 22
        '
        'RdoLocalConnection
        '
        Me.RdoLocalConnection.AutoSize = True
        Me.RdoLocalConnection.Checked = True
        Me.RdoLocalConnection.Location = New System.Drawing.Point(201, 7)
        Me.RdoLocalConnection.Name = "RdoLocalConnection"
        Me.RdoLocalConnection.Size = New System.Drawing.Size(100, 19)
        Me.RdoLocalConnection.TabIndex = 0
        Me.RdoLocalConnection.TabStop = True
        Me.RdoLocalConnection.Text = "الكمبيوتر المحلي "
        Me.RdoLocalConnection.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(500, 6)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(48, 48)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.CausesValidation = False
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 49)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(567, 254)
        Me.Panel1.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.ComboServerName)
        Me.Panel3.Controls.Add(Me.CheckShowBWS)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.ComboDBServer)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Port1)
        Me.Panel3.Controls.Add(Me.BWS)
        Me.Panel3.Controls.Add(Me.TxtServerName)
        Me.Panel3.Controls.Add(Me.UserID1)
        Me.Panel3.Location = New System.Drawing.Point(3, 94)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(559, 153)
        Me.Panel3.TabIndex = 51
        '
        'ComboServerName
        '
        Me.ComboServerName.FormattingEnabled = True
        Me.ComboServerName.Location = New System.Drawing.Point(5, 3)
        Me.ComboServerName.Name = "ComboServerName"
        Me.ComboServerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboServerName.Size = New System.Drawing.Size(302, 23)
        Me.ComboServerName.TabIndex = 23
        '
        'CheckShowBWS
        '
        Me.CheckShowBWS.Appearance = System.Windows.Forms.Appearance.Button
        Me.CheckShowBWS.BackColor = System.Drawing.Color.White
        Me.CheckShowBWS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CheckShowBWS.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckShowBWS.Cursor = System.Windows.Forms.Cursors.Default
        Me.CheckShowBWS.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.CheckShowBWS.FlatAppearance.BorderSize = 0
        Me.CheckShowBWS.FlatAppearance.CheckedBackColor = System.Drawing.Color.White
        Me.CheckShowBWS.FlatAppearance.MouseDownBackColor = System.Drawing.Color.SteelBlue
        Me.CheckShowBWS.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control
        Me.CheckShowBWS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckShowBWS.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckShowBWS.ForeColor = System.Drawing.Color.White
        Me.CheckShowBWS.Image = Global.CC_JO.My.Resources.Resources.Show_16x16
        Me.CheckShowBWS.Location = New System.Drawing.Point(284, 98)
        Me.CheckShowBWS.Name = "CheckShowBWS"
        Me.CheckShowBWS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CheckShowBWS.Size = New System.Drawing.Size(20, 20)
        Me.CheckShowBWS.TabIndex = 734
        Me.CheckShowBWS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.CheckShowBWS.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label5.Location = New System.Drawing.Point(341, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(213, 17)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "الاسم الافتراضي لمحرك قواعد البيانات :-"
        '
        'ComboDBServer
        '
        Me.ComboDBServer.FormattingEnabled = True
        Me.ComboDBServer.Location = New System.Drawing.Point(6, 121)
        Me.ComboDBServer.Name = "ComboDBServer"
        Me.ComboDBServer.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboDBServer.Size = New System.Drawing.Size(301, 23)
        Me.ComboDBServer.TabIndex = 21
        Me.ComboDBServer.Text = "CC_JO"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(382, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 17)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "اسم الافتراضي لقاعدة البيانات :-"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(381, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 17)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "اسم خادم محرك قواعد البيانات :-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(312, 77)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 17)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "اسم  دخـول المستخدم  لمحرك قواعد البيانات :-"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(333, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(221, 17)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "كلمة مرور  دخـول لمحرك قواعد البيانات :-"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label6.Location = New System.Drawing.Point(311, 54)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(243, 17)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "الرقم الافتراضي لبورت سيرفر قاعدة البيانات :-"
        '
        'Port1
        '
        Me.Port1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Port1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Port1.ForeColor = System.Drawing.SystemColors.WindowFrame
        Me.Port1.Location = New System.Drawing.Point(6, 51)
        Me.Port1.Name = "Port1"
        Me.Port1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Port1.Size = New System.Drawing.Size(301, 22)
        Me.Port1.TabIndex = 19
        '
        'BWS
        '
        Me.BWS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.BWS.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BWS.Location = New System.Drawing.Point(6, 97)
        Me.BWS.Name = "BWS"
        Me.BWS.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.BWS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BWS.Size = New System.Drawing.Size(301, 22)
        Me.BWS.TabIndex = 6
        Me.BWS.Text = "2710/m"
        '
        'TxtServerName
        '
        Me.TxtServerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtServerName.Cursor = System.Windows.Forms.Cursors.Default
        Me.TxtServerName.Location = New System.Drawing.Point(6, 28)
        Me.TxtServerName.Name = "TxtServerName"
        Me.TxtServerName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TxtServerName.Size = New System.Drawing.Size(301, 22)
        Me.TxtServerName.TabIndex = 3
        Me.TxtServerName.Text = "127.0.0.1"
        '
        'UserID1
        '
        Me.UserID1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.UserID1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.UserID1.Location = New System.Drawing.Point(6, 74)
        Me.UserID1.Name = "UserID1"
        Me.UserID1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.UserID1.Size = New System.Drawing.Size(301, 22)
        Me.UserID1.TabIndex = 5
        '
        'TextEncrypt
        '
        Me.TextEncrypt.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextEncrypt.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextEncrypt.Location = New System.Drawing.Point(3, 309)
        Me.TextEncrypt.Multiline = True
        Me.TextEncrypt.Name = "TextEncrypt"
        Me.TextEncrypt.Size = New System.Drawing.Size(313, 52)
        Me.TextEncrypt.TabIndex = 11
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ToolStrip1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator8, Me.ButChek, Me.ToolStripSeparator7, Me.ButSave, Me.ToolStripSeparator5, Me.ButClos, Me.ToolStripSeparator6})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.ToolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStrip1.Size = New System.Drawing.Size(574, 47)
        Me.ToolStrip1.TabIndex = 12
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.BackColor = System.Drawing.Color.Tan
        Me.ToolStripSeparator8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ToolStripSeparator8.MergeIndex = 1
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 47)
        '
        'ButChek
        '
        Me.ButChek.AutoSize = False
        Me.ButChek.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButChek.ForeColor = System.Drawing.Color.White
        Me.ButChek.Image = CType(resources.GetObject("ButChek.Image"), System.Drawing.Image)
        Me.ButChek.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButChek.Name = "ButChek"
        Me.ButChek.Size = New System.Drawing.Size(125, 44)
        Me.ButChek.Text = "فحص الاتصال"
        Me.ButChek.ToolTipText = "فحص الاتصال"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 47)
        '
        'ButSave
        '
        Me.ButSave.AutoSize = False
        Me.ButSave.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButSave.ForeColor = System.Drawing.Color.White
        Me.ButSave.Image = CType(resources.GetObject("ButSave.Image"), System.Drawing.Image)
        Me.ButSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(125, 44)
        Me.ButSave.Text = "حفظ الإعدأدت"
        Me.ButSave.ToolTipText = "حفظ الإعدأدت"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 47)
        '
        'ButClos
        '
        Me.ButClos.AutoSize = False
        Me.ButClos.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButClos.ForeColor = System.Drawing.Color.White
        Me.ButClos.Image = CType(resources.GetObject("ButClos.Image"), System.Drawing.Image)
        Me.ButClos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButClos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButClos.Name = "ButClos"
        Me.ButClos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButClos.Size = New System.Drawing.Size(125, 44)
        Me.ButClos.Text = "إغلاق"
        Me.ButClos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButClos.ToolTipText = "إغلاق"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 47)
        '
        'BackgroundWorker1
        '
        '
        'FrmServerusrs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.CC_JO.My.Resources.Resources.A9
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CausesValidation = False
        Me.ClientSize = New System.Drawing.Size(574, 308)
        Me.ControlBox = False
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextEncrypt)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmServerusrs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "إعداد خادم قواعد البيانات"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RdoServerConnection As System.Windows.Forms.RadioButton
    Friend WithEvents RdoLocalConnection As System.Windows.Forms.RadioButton
    Friend WithEvents UserID1 As System.Windows.Forms.TextBox
    Friend WithEvents BWS As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextEncrypt As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Protected Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents TxtServerName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Port1 As System.Windows.Forms.TextBox
    Friend WithEvents ComboAuth As ComboBox
    Friend WithEvents ComboDBServer As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel3 As Panel
    Private WithEvents CheckShowBWS As CheckBox
    Private WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents ButChek As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents ButSave As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents ButClos As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents ComboServerName As ComboBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
End Class
