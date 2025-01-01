<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_scaner
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
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_scaner))
        Me.Dascan = New System.Windows.Forms.DataGridView()
        Me.Grouevnt = New System.Windows.Forms.GroupBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Chern = New System.Windows.Forms.CheckBox()
        Me.Domain0 = New System.Windows.Forms.DomainUpDown()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dat2 = New System.Windows.Forms.DateTimePicker()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.dat1 = New System.Windows.Forms.DateTimePicker()
        Me.Textdaee = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Buconvert = New System.Windows.Forms.Button()
        Me.BuakrT = New System.Windows.Forms.Button()
        Me.Timrn = New System.Windows.Forms.Timer(Me.components)
        CType(Me.Dascan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Grouevnt.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Dascan
        '
        Me.Dascan.AllowUserToAddRows = False
        Me.Dascan.AllowUserToDeleteRows = False
        Me.Dascan.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.Dascan.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Dascan.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.Dascan.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Dascan.EnableHeadersVisualStyles = False
        Me.Dascan.Location = New System.Drawing.Point(0, 0)
        Me.Dascan.Name = "Dascan"
        Me.Dascan.ReadOnly = True
        Me.Dascan.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Dascan.RowHeadersVisible = False
        Me.Dascan.Size = New System.Drawing.Size(1020, 357)
        Me.Dascan.TabIndex = 817
        '
        'Grouevnt
        '
        Me.Grouevnt.BackColor = System.Drawing.Color.Transparent
        Me.Grouevnt.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Grouevnt.Controls.Add(Me.GroupControl1)
        Me.Grouevnt.Controls.Add(Me.PictureBox1)
        Me.Grouevnt.Controls.Add(Me.GroupBox1)
        Me.Grouevnt.Controls.Add(Me.Buconvert)
        Me.Grouevnt.Controls.Add(Me.BuakrT)
        Me.Grouevnt.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Grouevnt.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grouevnt.ForeColor = System.Drawing.Color.Black
        Me.Grouevnt.Location = New System.Drawing.Point(0, 357)
        Me.Grouevnt.Name = "Grouevnt"
        Me.Grouevnt.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Grouevnt.Size = New System.Drawing.Size(1020, 169)
        Me.Grouevnt.TabIndex = 818
        Me.Grouevnt.TabStop = False
        Me.Grouevnt.Text = "شاشة الاحداث"
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl1.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl1.Controls.Add(Me.Label12)
        Me.GroupControl1.Controls.Add(Me.Chern)
        Me.GroupControl1.Controls.Add(Me.Domain0)
        Me.GroupControl1.Controls.Add(Me.Label25)
        Me.GroupControl1.Location = New System.Drawing.Point(649, 26)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(367, 137)
        Me.GroupControl1.TabIndex = 864
        Me.GroupControl1.Text = "تشغيل المراقبة الذاتية"
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.BackColor = System.Drawing.Color.SteelBlue
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(5, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label12.Size = New System.Drawing.Size(194, 94)
        Me.Label12.TabIndex = 511
        Me.Label12.Text = "عند تفعيل خيار المراقبة الذاتية بقوم" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " النظام كل 10 دقائق بعرض العمليات الاخيرة" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) &
    "في كل 1000 بارمتر ثانية واحدة"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Chern
        '
        Me.Chern.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Chern.AutoSize = True
        Me.Chern.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Chern.ForeColor = System.Drawing.Color.Black
        Me.Chern.Location = New System.Drawing.Point(243, 41)
        Me.Chern.Name = "Chern"
        Me.Chern.Size = New System.Drawing.Size(118, 19)
        Me.Chern.TabIndex = 510
        Me.Chern.Text = "تشغيل المراقبة الذاتية"
        Me.Chern.UseVisualStyleBackColor = True
        '
        'Domain0
        '
        Me.Domain0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Domain0.BackColor = System.Drawing.Color.SteelBlue
        Me.Domain0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Domain0.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Domain0.ForeColor = System.Drawing.Color.White
        Me.Domain0.Location = New System.Drawing.Point(244, 75)
        Me.Domain0.Name = "Domain0"
        Me.Domain0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Domain0.Size = New System.Drawing.Size(118, 25)
        Me.Domain0.TabIndex = 512
        Me.Domain0.Text = "500000"
        Me.Domain0.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.ForeColor = System.Drawing.Color.Black
        Me.Label25.Location = New System.Drawing.Point(211, 79)
        Me.Label25.Name = "Label25"
        Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label25.Size = New System.Drawing.Size(30, 18)
        Me.Label25.TabIndex = 513
        Me.Label25.Text = "ثانية"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.logCO6
        Me.PictureBox1.InitialImage = Global.CC_JO.My.Resources.Resources.logCO12
        Me.PictureBox1.Location = New System.Drawing.Point(6, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(222, 72)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 860
        Me.PictureBox1.TabStop = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.dat2)
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.dat1)
        Me.GroupBox1.Controls.Add(Me.Textdaee)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(234, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(412, 138)
        Me.GroupBox1.TabIndex = 863
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات الاستعلام"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(334, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 863
        Me.Label2.Text = ": التاريخ"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(146, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 843
        Me.Label1.Text = ": الى"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Black
        Me.Label14.Location = New System.Drawing.Point(336, 104)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 15)
        Me.Label14.TabIndex = 862
        Me.Label14.Text = "اسم المستخدم :"
        '
        'dat2
        '
        Me.dat2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dat2.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dat2.CalendarForeColor = System.Drawing.Color.Black
        Me.dat2.CalendarMonthBackground = System.Drawing.Color.Pink
        Me.dat2.CalendarTitleBackColor = System.Drawing.Color.Pink
        Me.dat2.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dat2.CalendarTrailingForeColor = System.Drawing.Color.Black
        Me.dat2.Checked = False
        Me.dat2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dat2.CustomFormat = "dd/MM/yyyy"
        Me.dat2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dat2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dat2.Location = New System.Drawing.Point(5, 74)
        Me.dat2.Name = "dat2"
        Me.dat2.RightToLeftLayout = True
        Me.dat2.Size = New System.Drawing.Size(137, 22)
        Me.dat2.TabIndex = 842
        '
        'RadioButton2
        '
        Me.RadioButton2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton2.Location = New System.Drawing.Point(56, 22)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(78, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "بين تاريخين"
        Me.RadioButton2.UseVisualStyleBackColor = True
        '
        'ComboBox1
        '
        Me.ComboBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(5, 100)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(326, 23)
        Me.ComboBox1.TabIndex = 861
        '
        'RadioButton1
        '
        Me.RadioButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton1.Location = New System.Drawing.Point(258, 21)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "تاريخ محدد"
        Me.RadioButton1.UseVisualStyleBackColor = True
        '
        'dat1
        '
        Me.dat1.CalendarFont = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dat1.CalendarForeColor = System.Drawing.Color.Black
        Me.dat1.CalendarMonthBackground = System.Drawing.Color.Pink
        Me.dat1.CalendarTitleBackColor = System.Drawing.Color.Pink
        Me.dat1.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.dat1.CalendarTrailingForeColor = System.Drawing.Color.Black
        Me.dat1.Checked = False
        Me.dat1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.dat1.CustomFormat = "dd/MM/yyyy"
        Me.dat1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.dat1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dat1.Location = New System.Drawing.Point(194, 74)
        Me.dat1.Name = "dat1"
        Me.dat1.RightToLeftLayout = True
        Me.dat1.Size = New System.Drawing.Size(137, 22)
        Me.dat1.TabIndex = 841
        '
        'Textdaee
        '
        Me.Textdaee.BackColor = System.Drawing.Color.MintCream
        Me.Textdaee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Textdaee.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Textdaee.ForeColor = System.Drawing.Color.Black
        Me.Textdaee.Location = New System.Drawing.Point(194, 49)
        Me.Textdaee.Name = "Textdaee"
        Me.Textdaee.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Textdaee.Size = New System.Drawing.Size(137, 22)
        Me.Textdaee.TabIndex = 506
        Me.Textdaee.Text = "00/00/00"
        Me.Textdaee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label23
        '
        Me.Label23.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label23.ForeColor = System.Drawing.Color.Black
        Me.Label23.Location = New System.Drawing.Point(336, 80)
        Me.Label23.Name = "Label23"
        Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label23.Size = New System.Drawing.Size(26, 15)
        Me.Label23.TabIndex = 507
        Me.Label23.Text = ": من"
        '
        'Buconvert
        '
        Me.Buconvert.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Buconvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Buconvert.Font = New System.Drawing.Font("Arial", 10.25!, System.Drawing.FontStyle.Bold)
        Me.Buconvert.ForeColor = System.Drawing.Color.Black
        Me.Buconvert.Image = Global.CC_JO.My.Resources.Resources.ExportToDOC_16x16
        Me.Buconvert.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Buconvert.Location = New System.Drawing.Point(6, 128)
        Me.Buconvert.Name = "Buconvert"
        Me.Buconvert.Size = New System.Drawing.Size(222, 32)
        Me.Buconvert.TabIndex = 859
        Me.Buconvert.Text = "تصدير إلى الوورد"
        Me.Buconvert.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Buconvert.UseVisualStyleBackColor = True
        '
        'BuakrT
        '
        Me.BuakrT.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BuakrT.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BuakrT.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuakrT.ForeColor = System.Drawing.Color.Black
        Me.BuakrT.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.BuakrT.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BuakrT.Location = New System.Drawing.Point(6, 94)
        Me.BuakrT.Name = "BuakrT"
        Me.BuakrT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BuakrT.Size = New System.Drawing.Size(222, 32)
        Me.BuakrT.TabIndex = 508
        Me.BuakrT.Text = "بحث"
        Me.BuakrT.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.BuakrT.UseVisualStyleBackColor = True
        '
        'Timrn
        '
        Me.Timrn.Interval = 500000
        '
        'Form_scaner
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1020, 526)
        Me.Controls.Add(Me.Dascan)
        Me.Controls.Add(Me.Grouevnt)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Form_scaner"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "المراقبة الذاتية"
        CType(Me.Dascan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Grouevnt.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Dascan As System.Windows.Forms.DataGridView
    Friend WithEvents Grouevnt As System.Windows.Forms.GroupBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Domain0 As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Chern As System.Windows.Forms.CheckBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Textdaee As System.Windows.Forms.TextBox
    Friend WithEvents BuakrT As System.Windows.Forms.Button
    Friend WithEvents Timrn As System.Windows.Forms.Timer
    Friend WithEvents Buconvert As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dat2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents dat1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
End Class
