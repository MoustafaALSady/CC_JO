<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJPG0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJPG0))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LabMaxCh = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Line3 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabFileType = New System.Windows.Forms.Label()
        Me.LabFileSize = New System.Windows.Forms.Label()
        Me.Line1 = New DevComponents.DotNetBar.Controls.Line()
        Me.LabFileInfo = New System.Windows.Forms.Label()
        Me.LabFileName = New System.Windows.Forms.Label()
        Me.Line2 = New DevComponents.DotNetBar.Controls.Line()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TEXTFileNo = New System.Windows.Forms.TextBox()
        Me.TextFileDescription = New System.Windows.Forms.TextBox()
        Me.DateP1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextLO = New System.Windows.Forms.TextBox()
        Me.TEXTFileSubject = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ADDBUTTON = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.SAVEBUTTON = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TEXTBOX1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.op = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PanelImage = New System.Windows.Forms.Panel()
        Me.ComboScanners = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip3 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButScan = New System.Windows.Forms.ToolStripButton()
        Me.ButLogq = New System.Windows.Forms.ToolStripButton()
        Me.ButSaveFile = New System.Windows.Forms.ToolStripButton()
        Me.ButEditImage = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Butrotolaeft = New System.Windows.Forms.ToolStripButton()
        Me.Butrotorait = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.PanelImage.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.ToolStrip1)
        Me.Panel2.Controls.Add(Me.TEXTBOX1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel2.Location = New System.Drawing.Point(432, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(395, 409)
        Me.Panel2.TabIndex = 956
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LabMaxCh)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Panel5)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.TEXTFileNo)
        Me.Panel1.Controls.Add(Me.TextFileDescription)
        Me.Panel1.Controls.Add(Me.DateP1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextLO)
        Me.Panel1.Controls.Add(Me.TEXTFileSubject)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(2, 30)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(389, 377)
        Me.Panel1.TabIndex = 742
        '
        'LabMaxCh
        '
        Me.LabMaxCh.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabMaxCh.AutoSize = True
        Me.LabMaxCh.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabMaxCh.Location = New System.Drawing.Point(185, 309)
        Me.LabMaxCh.Name = "LabMaxCh"
        Me.LabMaxCh.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LabMaxCh.Size = New System.Drawing.Size(131, 15)
        Me.LabMaxCh.TabIndex = 766
        Me.LabMaxCh.Text = " عدد الحروف  : (300) حرف"
        Me.LabMaxCh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox5.Location = New System.Drawing.Point(345, 117)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 740
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(345, 117)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 739
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Line3)
        Me.Panel5.Controls.Add(Me.LabFileType)
        Me.Panel5.Controls.Add(Me.LabFileSize)
        Me.Panel5.Controls.Add(Me.Line1)
        Me.Panel5.Controls.Add(Me.LabFileInfo)
        Me.Panel5.Controls.Add(Me.LabFileName)
        Me.Panel5.Controls.Add(Me.Line2)
        Me.Panel5.Location = New System.Drawing.Point(4, 330)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(377, 40)
        Me.Panel5.TabIndex = 765
        '
        'Line3
        '
        Me.Line3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Line3.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line3.ForeColor = System.Drawing.Color.MidnightBlue
        Me.Line3.Location = New System.Drawing.Point(0, 12)
        Me.Line3.Name = "Line3"
        Me.Line3.Size = New System.Drawing.Size(373, 10)
        Me.Line3.TabIndex = 766
        Me.Line3.Text = "Line3"
        '
        'LabFileType
        '
        Me.LabFileType.AutoSize = True
        Me.LabFileType.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabFileType.Location = New System.Drawing.Point(84, 20)
        Me.LabFileType.Name = "LabFileType"
        Me.LabFileType.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabFileType.Size = New System.Drawing.Size(16, 15)
        Me.LabFileType.TabIndex = 761
        Me.LabFileType.Text = "..."
        '
        'LabFileSize
        '
        Me.LabFileSize.AutoSize = True
        Me.LabFileSize.BackColor = System.Drawing.Color.Transparent
        Me.LabFileSize.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabFileSize.ForeColor = System.Drawing.Color.Black
        Me.LabFileSize.Location = New System.Drawing.Point(3, 21)
        Me.LabFileSize.Name = "LabFileSize"
        Me.LabFileSize.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabFileSize.Size = New System.Drawing.Size(16, 15)
        Me.LabFileSize.TabIndex = 76
        Me.LabFileSize.Text = "..."
        '
        'Line1
        '
        Me.Line1.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line1.ForeColor = System.Drawing.Color.DarkBlue
        Me.Line1.Location = New System.Drawing.Point(138, 14)
        Me.Line1.Name = "Line1"
        Me.Line1.Size = New System.Drawing.Size(10, 24)
        Me.Line1.TabIndex = 764
        Me.Line1.Text = "Line1"
        Me.Line1.Thickness = 2
        Me.Line1.VerticalLine = True
        '
        'LabFileInfo
        '
        Me.LabFileInfo.AutoSize = True
        Me.LabFileInfo.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabFileInfo.Location = New System.Drawing.Point(147, 21)
        Me.LabFileInfo.Name = "LabFileInfo"
        Me.LabFileInfo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabFileInfo.Size = New System.Drawing.Size(16, 15)
        Me.LabFileInfo.TabIndex = 763
        Me.LabFileInfo.Text = "..."
        '
        'LabFileName
        '
        Me.LabFileName.AutoSize = True
        Me.LabFileName.BackColor = System.Drawing.Color.Transparent
        Me.LabFileName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabFileName.ForeColor = System.Drawing.Color.Black
        Me.LabFileName.Location = New System.Drawing.Point(3, -1)
        Me.LabFileName.Name = "LabFileName"
        Me.LabFileName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabFileName.Size = New System.Drawing.Size(16, 15)
        Me.LabFileName.TabIndex = 440
        Me.LabFileName.Text = "..."
        '
        'Line2
        '
        Me.Line2.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Line2.ForeColor = System.Drawing.Color.Navy
        Me.Line2.Location = New System.Drawing.Point(75, 17)
        Me.Line2.Name = "Line2"
        Me.Line2.Size = New System.Drawing.Size(10, 21)
        Me.Line2.TabIndex = 765
        Me.Line2.Text = "Line2"
        Me.Line2.Thickness = 2
        Me.Line2.VerticalLine = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(323, 99)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(60, 15)
        Me.Label8.TabIndex = 730
        Me.Label8.Text = "وصف الملف"
        '
        'Label9
        '
        Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(346, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 15)
        Me.Label9.TabIndex = 733
        Me.Label9.Text = "التاريخ"
        '
        'TEXTFileNo
        '
        Me.TEXTFileNo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEXTFileNo.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEXTFileNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTFileNo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTFileNo.Location = New System.Drawing.Point(4, 27)
        Me.TEXTFileNo.Name = "TEXTFileNo"
        Me.TEXTFileNo.Size = New System.Drawing.Size(306, 22)
        Me.TEXTFileNo.TabIndex = 2
        Me.TEXTFileNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextFileDescription
        '
        Me.TextFileDescription.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextFileDescription.BackColor = System.Drawing.Color.White
        Me.TextFileDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFileDescription.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextFileDescription.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextFileDescription.Location = New System.Drawing.Point(4, 96)
        Me.TextFileDescription.Multiline = True
        Me.TextFileDescription.Name = "TextFileDescription"
        Me.TextFileDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextFileDescription.Size = New System.Drawing.Size(306, 209)
        Me.TextFileDescription.TabIndex = 5
        '
        'DateP1
        '
        Me.DateP1.CustomFormat = "yyyy/MM/dd"
        Me.DateP1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateP1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateP1.Location = New System.Drawing.Point(4, 50)
        Me.DateP1.Name = "DateP1"
        Me.DateP1.RightToLeftLayout = True
        Me.DateP1.Size = New System.Drawing.Size(306, 22)
        Me.DateP1.TabIndex = 732
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(334, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 15)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "رقم الملف"
        '
        'TextLO
        '
        Me.TextLO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextLO.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextLO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLO.Enabled = False
        Me.TextLO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextLO.Location = New System.Drawing.Point(4, 4)
        Me.TextLO.Name = "TextLO"
        Me.TextLO.Size = New System.Drawing.Size(306, 22)
        Me.TextLO.TabIndex = 728
        Me.TextLO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTFileSubject
        '
        Me.TEXTFileSubject.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TEXTFileSubject.BackColor = System.Drawing.Color.White
        Me.TEXTFileSubject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTFileSubject.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTFileSubject.Location = New System.Drawing.Point(4, 73)
        Me.TEXTFileSubject.Name = "TEXTFileSubject"
        Me.TEXTFileSubject.Size = New System.Drawing.Size(306, 22)
        Me.TEXTFileSubject.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(326, 6)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 729
        Me.Label7.Text = "رقم المعاملة"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(315, 75)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 15)
        Me.Label4.TabIndex = 77
        Me.Label4.Text = "موضوع الملف"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ADDBUTTON, Me.ToolStripSeparator4, Me.SAVEBUTTON, Me.ToolStripSeparator5})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(393, 25)
        Me.ToolStrip1.TabIndex = 766
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.ForeColor = System.Drawing.Color.White
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ADDBUTTON.Size = New System.Drawing.Size(75, 22)
        Me.ADDBUTTON.Text = "اضــافة F1"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.ForeColor = System.Drawing.Color.White
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.save11
        Me.SAVEBUTTON.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.Size = New System.Drawing.Size(62, 22)
        Me.SAVEBUTTON.Text = "حفظ F2"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'TEXTBOX1
        '
        Me.TEXTBOX1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEXTBOX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX1.Enabled = False
        Me.TEXTBOX1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTBOX1.Location = New System.Drawing.Point(9, 2)
        Me.TEXTBOX1.Name = "TEXTBOX1"
        Me.TEXTBOX1.Size = New System.Drawing.Size(229, 22)
        Me.TEXTBOX1.TabIndex = 1
        Me.TEXTBOX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(272, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 15)
        Me.Label1.TabIndex = 74
        Me.Label1.Text = "مسلسل"
        '
        'PanelImage
        '
        Me.PanelImage.BackColor = System.Drawing.Color.Transparent
        Me.PanelImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelImage.Controls.Add(Me.ComboScanners)
        Me.PanelImage.Controls.Add(Me.PictureBox1)
        Me.PanelImage.Controls.Add(Me.ToolStrip3)
        Me.PanelImage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelImage.Location = New System.Drawing.Point(0, 0)
        Me.PanelImage.Name = "PanelImage"
        Me.PanelImage.Size = New System.Drawing.Size(432, 409)
        Me.PanelImage.TabIndex = 960
        '
        'ComboScanners
        '
        Me.ComboScanners.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboScanners.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboScanners.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboScanners.FormattingEnabled = True
        Me.ComboScanners.Location = New System.Drawing.Point(159, 0)
        Me.ComboScanners.Name = "ComboScanners"
        Me.ComboScanners.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboScanners.Size = New System.Drawing.Size(268, 22)
        Me.ComboScanners.TabIndex = 961
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.InitialImage = Global.CC_JO.My.Resources.Resources.logCO2
        Me.PictureBox1.Location = New System.Drawing.Point(5, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(422, 378)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'ToolStrip3
        '
        Me.ToolStrip3.BackColor = System.Drawing.Color.Transparent
        Me.ToolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator2, Me.ButScan, Me.ButLogq, Me.ButSaveFile, Me.ButEditImage, Me.ToolStripSeparator1, Me.Butrotolaeft, Me.Butrotorait, Me.ToolStripSeparator3})
        Me.ToolStrip3.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow
        Me.ToolStrip3.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip3.Name = "ToolStrip3"
        Me.ToolStrip3.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStrip3.Size = New System.Drawing.Size(430, 23)
        Me.ToolStrip3.TabIndex = 959
        Me.ToolStrip3.Text = "ToolStrip3"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 23)
        '
        'ButScan
        '
        Me.ButScan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButScan.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButScan.ForeColor = System.Drawing.Color.White
        Me.ButScan.Image = Global.CC_JO.My.Resources.Resources.Scan2
        Me.ButScan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButScan.Name = "ButScan"
        Me.ButScan.Size = New System.Drawing.Size(23, 20)
        Me.ButScan.Text = "سحب الصورة"
        Me.ButScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButScan.ToolTipText = "مســــــح الصوره"
        '
        'ButLogq
        '
        Me.ButLogq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButLogq.ForeColor = System.Drawing.Color.White
        Me.ButLogq.Image = Global.CC_JO.My.Resources.Resources.ImportImage_16x16
        Me.ButLogq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButLogq.Name = "ButLogq"
        Me.ButLogq.Size = New System.Drawing.Size(23, 20)
        Me.ButLogq.Text = "اختيارالصورة "
        Me.ButLogq.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.ButLogq.ToolTipText = "اختيارالصورة من الحاسوب"
        '
        'ButSaveFile
        '
        Me.ButSaveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButSaveFile.Image = Global.CC_JO.My.Resources.Resources.SaveAs_16x16
        Me.ButSaveFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButSaveFile.Name = "ButSaveFile"
        Me.ButSaveFile.Size = New System.Drawing.Size(23, 20)
        Me.ButSaveFile.Text = "حقظ الصورة فى ملف"
        Me.ButSaveFile.ToolTipText = "حقظ الصورة فى ملف"
        '
        'ButEditImage
        '
        Me.ButEditImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ButEditImage.Image = Global.CC_JO.My.Resources.Resources.Card_file
        Me.ButEditImage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButEditImage.Name = "ButEditImage"
        Me.ButEditImage.Size = New System.Drawing.Size(23, 20)
        Me.ButEditImage.Text = "تـــــــعديــل الصورة"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 23)
        '
        'Butrotolaeft
        '
        Me.Butrotolaeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Butrotolaeft.Image = Global.CC_JO.My.Resources.Resources.Reset_16x16
        Me.Butrotolaeft.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Butrotolaeft.Name = "Butrotolaeft"
        Me.Butrotolaeft.Size = New System.Drawing.Size(23, 20)
        Me.Butrotolaeft.Text = "استدارة الى اليمين"
        Me.Butrotolaeft.ToolTipText = "استدارة الى اليمين"
        '
        'Butrotorait
        '
        Me.Butrotorait.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.Butrotorait.Image = Global.CC_JO.My.Resources.Resources.Redo
        Me.Butrotorait.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.Butrotorait.Name = "Butrotorait"
        Me.Butrotorait.RightToLeftAutoMirrorImage = True
        Me.Butrotorait.Size = New System.Drawing.Size(23, 20)
        Me.Butrotorait.Text = "استدارة الى الشمال"
        Me.Butrotorait.ToolTipText = "استدارة الى الشمال"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 23)
        '
        'BackgroundWorker1
        '
        '
        'FrmJPG0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HighlightText
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(827, 409)
        Me.Controls.Add(Me.PanelImage)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(843, 448)
        Me.Name = "FrmJPG0"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الإرشـــبف الـعــام"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.PanelImage.ResumeLayout(False)
        Me.PanelImage.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip3.ResumeLayout(False)
        Me.ToolStrip3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents DateP1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextLO As System.Windows.Forms.TextBox
    Friend WithEvents TEXTFileSubject As System.Windows.Forms.TextBox
    Friend WithEvents TEXTBOX1 As System.Windows.Forms.TextBox
    Friend WithEvents TextFileDescription As System.Windows.Forms.TextBox
    Friend WithEvents TEXTFileNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents op As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PanelImage As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents ToolStrip3 As ToolStrip
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ButScan As ToolStripButton
    Friend WithEvents ButLogq As ToolStripButton
    Friend WithEvents ButEditImage As ToolStripButton
    Friend WithEvents ButSaveFile As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents Butrotolaeft As ToolStripButton
    Friend WithEvents Butrotorait As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Line3 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabFileType As Label
    Friend WithEvents LabFileSize As Label
    Friend WithEvents Line1 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents LabFileInfo As Label
    Friend WithEvents LabFileName As Label
    Friend WithEvents Line2 As DevComponents.DotNetBar.Controls.Line
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ComboScanners As ComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ADDBUTTON As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents SAVEBUTTON As ToolStripButton
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Private WithEvents LabMaxCh As Label
End Class
