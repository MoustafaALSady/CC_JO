<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTreeView
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTreeView))
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.CheckMasterAccount = New System.Windows.Forms.CheckBox()
        Me.TextACC1 = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.CMS1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuItem3 = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuItem4 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ADDBUTTON = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.EDITBUTTON = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButtonUpdateA = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TxtSearch = New System.Windows.Forms.ToolStripTextBox()
        Me.BtnSearch = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextPARTENT_ACCOUNT = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CMS1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox5.Location = New System.Drawing.Point(481, -4)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 993
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(481, -3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 992
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'CheckMasterAccount
        '
        Me.CheckMasterAccount.AutoSize = True
        Me.CheckMasterAccount.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckMasterAccount.ForeColor = System.Drawing.Color.White
        Me.CheckMasterAccount.Location = New System.Drawing.Point(3, 5)
        Me.CheckMasterAccount.Name = "CheckMasterAccount"
        Me.CheckMasterAccount.Size = New System.Drawing.Size(85, 19)
        Me.CheckMasterAccount.TabIndex = 977
        Me.CheckMasterAccount.Text = "حساب رئيسي"
        Me.CheckMasterAccount.UseVisualStyleBackColor = True
        '
        'TextACC1
        '
        Me.TextACC1.BackColor = System.Drawing.Color.White
        Me.TextACC1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TextACC1.Enabled = False
        Me.TextACC1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextACC1.ForeColor = System.Drawing.Color.Black
        Me.TextACC1.Location = New System.Drawing.Point(2, 504)
        Me.TextACC1.Name = "TextACC1"
        Me.TextACC1.Size = New System.Drawing.Size(136, 15)
        Me.TextACC1.TabIndex = 995
        Me.TextACC1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TreeView1.ContextMenuStrip = Me.CMS1
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.Black
        Me.TreeView1.FullRowSelect = True
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 33)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.RightToLeftLayout = True
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowNodeToolTips = True
        Me.TreeView1.Size = New System.Drawing.Size(545, 489)
        Me.TreeView1.TabIndex = 990
        '
        'CMS1
        '
        Me.CMS1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.CMS1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CMS1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuItem1, Me.MenuItem2, Me.ToolStripSeparator8, Me.MenuItem3, Me.MenuItem4})
        Me.CMS1.Name = "ContextMenuStrip1"
        Me.CMS1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        Me.CMS1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CMS1.Size = New System.Drawing.Size(146, 98)
        Me.CMS1.Text = "القائمة المختصرة"
        '
        'MenuItem1
        '
        Me.MenuItem1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MenuItem1.Image = CType(resources.GetObject("MenuItem1.Image"), System.Drawing.Image)
        Me.MenuItem1.Name = "MenuItem1"
        Me.MenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D1), System.Windows.Forms.Keys)
        Me.MenuItem1.Size = New System.Drawing.Size(145, 22)
        Me.MenuItem1.Text = "طي"
        '
        'MenuItem2
        '
        Me.MenuItem2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MenuItem2.Image = CType(resources.GetObject("MenuItem2.Image"), System.Drawing.Image)
        Me.MenuItem2.Name = "MenuItem2"
        Me.MenuItem2.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.D2), System.Windows.Forms.Keys)
        Me.MenuItem2.Size = New System.Drawing.Size(145, 22)
        Me.MenuItem2.Text = "فرد"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(142, 6)
        '
        'MenuItem3
        '
        Me.MenuItem3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MenuItem3.Image = CType(resources.GetObject("MenuItem3.Image"), System.Drawing.Image)
        Me.MenuItem3.Name = "MenuItem3"
        Me.MenuItem3.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.MenuItem3.Size = New System.Drawing.Size(145, 22)
        Me.MenuItem3.Text = "إضافة"
        '
        'MenuItem4
        '
        Me.MenuItem4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MenuItem4.Image = CType(resources.GetObject("MenuItem4.Image"), System.Drawing.Image)
        Me.MenuItem4.Name = "MenuItem4"
        Me.MenuItem4.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.MenuItem4.Size = New System.Drawing.Size(145, 22)
        Me.MenuItem4.Text = "تعديل"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Check_48x48.png")
        Me.ImageList1.Images.SetKeyName(1, "Folder_24x24.png")
        Me.ImageList1.Images.SetKeyName(2, "New_24x24.png")
        Me.ImageList1.Images.SetKeyName(3, "Check_24x24-1.png")
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.CheckMasterAccount)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 522)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 30)
        Me.Panel1.TabIndex = 997
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ToolStrip3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(545, 33)
        Me.Panel2.TabIndex = 999
        '
        'ToolStrip3
        '
        Me.ToolStrip3.AutoSize = False
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ToolStrip3.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ADDBUTTON, Me.ToolStripSeparator4, Me.EDITBUTTON, Me.ToolStripSeparator1, Me.ButtonUpdateA, Me.ToolStripSeparator3, Me.TxtSearch, Me.BtnSearch, Me.ToolStripSeparator5})
        Me.ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.Size = New System.Drawing.Size(543, 31)
        Me.ToolStrip3.TabIndex = 1001
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.ForeColor = System.Drawing.Color.White
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(56, 24)
        Me.ADDBUTTON.Text = "اضافة"
        Me.ADDBUTTON.ToolTipText = "اضافة حساب جديد"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 23)
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDITBUTTON.ForeColor = System.Drawing.Color.White
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.Size = New System.Drawing.Size(54, 24)
        Me.EDITBUTTON.Text = "تعديل"
        Me.EDITBUTTON.ToolTipText = "تعدييل حساب"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'ButtonUpdateA
        '
        Me.ButtonUpdateA.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonUpdateA.ForeColor = System.Drawing.Color.White
        Me.ButtonUpdateA.Image = Global.CC_JO.My.Resources.Resources.Refresh_16x16
        Me.ButtonUpdateA.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButtonUpdateA.Name = "ButtonUpdateA"
        Me.ButtonUpdateA.Size = New System.Drawing.Size(58, 24)
        Me.ButtonUpdateA.Text = "تحديث"
        Me.ButtonUpdateA.ToolTipText = "تحديث"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'TxtSearch
        '
        Me.TxtSearch.AutoSize = False
        Me.TxtSearch.AutoToolTip = True
        Me.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TxtSearch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TxtSearch.Name = "TxtSearch"
        Me.TxtSearch.Size = New System.Drawing.Size(275, 22)
        Me.TxtSearch.ToolTipText = "بحث"
        '
        'BtnSearch
        '
        Me.BtnSearch.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSearch.ForeColor = System.Drawing.Color.White
        Me.BtnSearch.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(50, 24)
        Me.BtnSearch.Text = "بحث"
        Me.BtnSearch.ToolTipText = "بحث"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 23)
        '
        'TextPARTENT_ACCOUNT
        '
        Me.TextPARTENT_ACCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPARTENT_ACCOUNT.Location = New System.Drawing.Point(12, 353)
        Me.TextPARTENT_ACCOUNT.Name = "TextPARTENT_ACCOUNT"
        Me.TextPARTENT_ACCOUNT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextPARTENT_ACCOUNT.Size = New System.Drawing.Size(334, 22)
        Me.TextPARTENT_ACCOUNT.TabIndex = 1000
        Me.TextPARTENT_ACCOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormTreeView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(545, 552)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TextACC1)
        Me.Controls.Add(Me.TextPARTENT_ACCOUNT)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
<<<<<<< HEAD
        Me.MinimumSize = New System.Drawing.Size(561, 500)
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Name = "FormTreeView"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "شجرة الحسابات"
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CMS1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TextACC1 As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents CheckMasterAccount As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents CMS1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextPARTENT_ACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ADDBUTTON As ToolStripButton
    Friend WithEvents EDITBUTTON As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ButtonUpdateA As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents BtnSearch As ToolStripButton
    Friend WithEvents TxtSearch As ToolStripTextBox
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class
