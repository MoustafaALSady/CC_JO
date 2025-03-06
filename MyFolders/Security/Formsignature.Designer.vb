<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Formsignature
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Formsignature))
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New DevExpress.XtraEditors.PictureEdit()
        Me.LabelWidth = New System.Windows.Forms.Label()
        Me.LabelHeight = New System.Windows.Forms.Label()
        Me.txtSignatureFileName = New System.Windows.Forms.TextBox()
        Me.TextIDCS = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextUP = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LabelFont = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CBFontSize = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TextRight = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
<<<<<<< HEAD
        Me.Label9 = New System.Windows.Forms.Label()
        Me.colorPickEdit1 = New DevExpress.XtraEditors.ColorPickEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CBFontSize1 = New DevExpress.XtraEditors.ComboBoxEdit()
=======
        Me.Label3 = New System.Windows.Forms.Label()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.btnClearSignature = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSaveSignature = New DevExpress.XtraEditors.SimpleButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pBoxSavedSignature = New System.Windows.Forms.PictureBox()
        Me.ButtonAddNaem = New DevExpress.XtraEditors.SimpleButton()
        Me.TextRealname = New System.Windows.Forms.TextBox()
        Me.pBoxSignature = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ADDBUTTON = New DevExpress.XtraEditors.SimpleButton()
        Me.EDITBUTTON = New DevExpress.XtraEditors.SimpleButton()
        Me.SAVEBUTTON = New DevExpress.XtraEditors.SimpleButton()
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.Panel6.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.PictureBox1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.CBFontSize.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
<<<<<<< HEAD
        CType(Me.colorPickEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CBFontSize1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        CType(Me.pBoxSavedSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pBoxSignature, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label8)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
<<<<<<< HEAD
        Me.Panel6.Size = New System.Drawing.Size(779, 37)
=======
        Me.Panel6.Size = New System.Drawing.Size(756, 37)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel6.TabIndex = 1035
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.SteelBlue
        Me.Label8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label8.Font = New System.Drawing.Font("Traditional Arabic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Image = Global.CC_JO.My.Resources.Resources.text_signature
<<<<<<< HEAD
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(777, 35)
=======
        Me.Label8.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label8.Location = New System.Drawing.Point(0, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(754, 35)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label8.TabIndex = 1008
        Me.Label8.Text = "منشئى التوقيــــع الرقمي"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel5)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Location = New System.Drawing.Point(0, 40)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel2.Name = "Panel2"
<<<<<<< HEAD
        Me.Panel2.Size = New System.Drawing.Size(776, 282)
=======
        Me.Panel2.Size = New System.Drawing.Size(753, 282)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel2.TabIndex = 1036
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.PictureBox1)
        Me.Panel5.Controls.Add(Me.LabelWidth)
        Me.Panel5.Controls.Add(Me.LabelHeight)
        Me.Panel5.Controls.Add(Me.txtSignatureFileName)
        Me.Panel5.Controls.Add(Me.TextIDCS)
        Me.Panel5.Location = New System.Drawing.Point(2, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(290, 274)
        Me.Panel5.TabIndex = 761
        '
        'PictureBox1
        '
        Me.PictureBox1.AllowDrop = True
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
<<<<<<< HEAD
        Me.PictureBox1.Properties.Appearance.BackColor = System.Drawing.Color.White
=======
        Me.PictureBox1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.PictureBox1.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PictureBox1.Properties.Appearance.Options.UseBackColor = True
        Me.PictureBox1.Properties.Appearance.Options.UseFont = True
        Me.PictureBox1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.PictureBox1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.[Auto]
        Me.PictureBox1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
        Me.PictureBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.PictureBox1.Size = New System.Drawing.Size(282, 228)
        Me.PictureBox1.TabIndex = 760
        '
        'LabelWidth
        '
        Me.LabelWidth.AutoSize = True
        Me.LabelWidth.BackColor = System.Drawing.Color.Transparent
        Me.LabelWidth.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelWidth.Location = New System.Drawing.Point(4, 235)
        Me.LabelWidth.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelWidth.Name = "LabelWidth"
        Me.LabelWidth.Size = New System.Drawing.Size(14, 15)
        Me.LabelWidth.TabIndex = 433
        Me.LabelWidth.Text = "0"
        '
        'LabelHeight
        '
        Me.LabelHeight.AutoSize = True
        Me.LabelHeight.BackColor = System.Drawing.Color.Transparent
        Me.LabelHeight.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.LabelHeight.ForeColor = System.Drawing.Color.Black
        Me.LabelHeight.Location = New System.Drawing.Point(4, 256)
        Me.LabelHeight.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelHeight.Name = "LabelHeight"
        Me.LabelHeight.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelHeight.Size = New System.Drawing.Size(14, 15)
        Me.LabelHeight.TabIndex = 759
        Me.LabelHeight.Text = "0"
        '
        'txtSignatureFileName
        '
        Me.txtSignatureFileName.Location = New System.Drawing.Point(87, 152)
        Me.txtSignatureFileName.Name = "txtSignatureFileName"
        Me.txtSignatureFileName.Size = New System.Drawing.Size(54, 22)
        Me.txtSignatureFileName.TabIndex = 762
        '
        'TextIDCS
        '
        Me.TextIDCS.Location = New System.Drawing.Point(147, 152)
        Me.TextIDCS.Name = "TextIDCS"
        Me.TextIDCS.Size = New System.Drawing.Size(54, 22)
        Me.TextIDCS.TabIndex = 761
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TextUP)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.LabelFont)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.CBFontSize)
        Me.Panel3.Controls.Add(Me.TextRight)
        Me.Panel3.Location = New System.Drawing.Point(293, 239)
        Me.Panel3.Name = "Panel3"
<<<<<<< HEAD
        Me.Panel3.Size = New System.Drawing.Size(478, 38)
=======
        Me.Panel3.Size = New System.Drawing.Size(454, 38)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel3.TabIndex = 29
        '
        'TextUP
        '
        Me.TextUP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextUP.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextUP.ForeColor = System.Drawing.Color.MediumBlue
        Me.TextUP.Location = New System.Drawing.Point(147, 6)
        Me.TextUP.Margin = New System.Windows.Forms.Padding(4)
        Me.TextUP.Name = "TextUP"
        Me.TextUP.Size = New System.Drawing.Size(70, 25)
        Me.TextUP.TabIndex = 15
        Me.TextUP.Text = "1"
        Me.TextUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(357, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "المسافة من اليسار :"
        '
        'LabelFont
        '
        Me.LabelFont.AutoSize = True
        Me.LabelFont.BackColor = System.Drawing.Color.Transparent
        Me.LabelFont.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelFont.Location = New System.Drawing.Point(77, 11)
        Me.LabelFont.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFont.Name = "LabelFont"
        Me.LabelFont.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LabelFont.Size = New System.Drawing.Size(56, 15)
        Me.LabelFont.TabIndex = 21
        Me.LabelFont.Text = "حجم الخط :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(219, 11)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "الارتفاع :"
        '
        'CBFontSize
        '
        Me.CBFontSize.Location = New System.Drawing.Point(4, 7)
        Me.CBFontSize.Name = "CBFontSize"
        Me.CBFontSize.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CBFontSize.Properties.Appearance.Options.UseFont = True
        Me.CBFontSize.Properties.Appearance.Options.UseTextOptions = True
        Me.CBFontSize.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CBFontSize.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CBFontSize.Properties.Items.AddRange(New Object() {"30", "34", "36", "38", "40", "42", "44"})
        Me.CBFontSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBFontSize.Size = New System.Drawing.Size(70, 22)
        Me.CBFontSize.TabIndex = 22
        '
        'TextRight
        '
        Me.TextRight.BackColor = System.Drawing.Color.White
        Me.TextRight.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRight.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextRight.ForeColor = System.Drawing.Color.MediumBlue
        Me.TextRight.Location = New System.Drawing.Point(284, 6)
        Me.TextRight.Margin = New System.Windows.Forms.Padding(4)
        Me.TextRight.Name = "TextRight"
        Me.TextRight.Size = New System.Drawing.Size(70, 25)
        Me.TextRight.TabIndex = 14
        Me.TextRight.Text = "25"
        Me.TextRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(312, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label7.Size = New System.Drawing.Size(0, 15)
        Me.Label7.TabIndex = 441
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
<<<<<<< HEAD
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.colorPickEdit1)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.CBFontSize1)
=======
        Me.Panel4.Controls.Add(Me.Label3)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel4.Controls.Add(Me.btnClearSignature)
        Me.Panel4.Controls.Add(Me.btnSaveSignature)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.pBoxSavedSignature)
        Me.Panel4.Controls.Add(Me.ButtonAddNaem)
        Me.Panel4.Controls.Add(Me.TextRealname)
        Me.Panel4.Controls.Add(Me.pBoxSignature)
        Me.Panel4.Location = New System.Drawing.Point(293, 3)
        Me.Panel4.Name = "Panel4"
<<<<<<< HEAD
        Me.Panel4.Size = New System.Drawing.Size(478, 235)
        Me.Panel4.TabIndex = 759
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.Location = New System.Drawing.Point(412, 170)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(58, 15)
        Me.Label9.TabIndex = 1041
        Me.Label9.Text = "لون الرسم :"
        '
        'colorPickEdit1
        '
        Me.colorPickEdit1.EditValue = System.Drawing.Color.Navy
        Me.colorPickEdit1.Location = New System.Drawing.Point(355, 167)
        Me.colorPickEdit1.Name = "colorPickEdit1"
        Me.colorPickEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Navy
        Me.colorPickEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.colorPickEdit1.Properties.AutomaticBorderColor = System.Drawing.Color.Navy
        Me.colorPickEdit1.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.colorPickEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.colorPickEdit1.Properties.ColorAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.colorPickEdit1.Properties.ColorText = DevExpress.XtraEditors.Controls.ColorText.[Integer]
        Me.colorPickEdit1.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Buffered
        Me.colorPickEdit1.Properties.HighlightedItemStyle = DevExpress.XtraEditors.HighlightStyle.Standard
        Me.colorPickEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.colorPickEdit1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.colorPickEdit1.Size = New System.Drawing.Size(54, 22)
        Me.colorPickEdit1.TabIndex = 1038
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.Location = New System.Drawing.Point(412, 147)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(61, 15)
        Me.Label6.TabIndex = 1039
        Me.Label6.Text = "حجم الرسم :"
        '
=======
        Me.Panel4.Size = New System.Drawing.Size(454, 235)
        Me.Panel4.TabIndex = 759
        '
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(357, 8)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 763
        Me.Label3.Text = "مـعـاينــة التـوقــــع :"
        '
<<<<<<< HEAD
        'CBFontSize1
        '
        Me.CBFontSize1.Location = New System.Drawing.Point(355, 143)
        Me.CBFontSize1.Name = "CBFontSize1"
        Me.CBFontSize1.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CBFontSize1.Properties.Appearance.Options.UseFont = True
        Me.CBFontSize1.Properties.Appearance.Options.UseTextOptions = True
        Me.CBFontSize1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.CBFontSize1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CBFontSize1.Properties.Items.AddRange(New Object() {"2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.CBFontSize1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CBFontSize1.Size = New System.Drawing.Size(54, 22)
        Me.CBFontSize1.TabIndex = 1040
        '
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'btnClearSignature
        '
        Me.btnClearSignature.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnClearSignature.Appearance.Options.UseFont = True
        Me.btnClearSignature.Appearance.Options.UseTextOptions = True
        Me.btnClearSignature.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.btnClearSignature.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.delete_16x16
        Me.btnClearSignature.Location = New System.Drawing.Point(7, 140)
        Me.btnClearSignature.Name = "btnClearSignature"
        Me.btnClearSignature.Size = New System.Drawing.Size(24, 24)
        Me.btnClearSignature.TabIndex = 21
        '
        'btnSaveSignature
        '
        Me.btnSaveSignature.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.btnSaveSignature.Appearance.BackColor2 = System.Drawing.SystemColors.InactiveCaption
        Me.btnSaveSignature.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnSaveSignature.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnSaveSignature.Appearance.Options.UseBackColor = True
        Me.btnSaveSignature.Appearance.Options.UseFont = True
        Me.btnSaveSignature.Appearance.Options.UseForeColor = True
        Me.btnSaveSignature.Appearance.Options.UseTextOptions = True
        Me.btnSaveSignature.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.btnSaveSignature.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.EditName_16x16
<<<<<<< HEAD
        Me.btnSaveSignature.Location = New System.Drawing.Point(240, 199)
        Me.btnSaveSignature.Name = "btnSaveSignature"
        Me.btnSaveSignature.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSaveSignature.Size = New System.Drawing.Size(234, 32)
=======
        Me.btnSaveSignature.Location = New System.Drawing.Point(223, 199)
        Me.btnSaveSignature.Name = "btnSaveSignature"
        Me.btnSaveSignature.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSaveSignature.Size = New System.Drawing.Size(227, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.btnSaveSignature.TabIndex = 760
        Me.btnSaveSignature.Text = "اضافة رســم التوقيع"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.SteelBlue
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
<<<<<<< HEAD
        Me.Label4.Location = New System.Drawing.Point(355, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(120, 19)
        Me.Label4.TabIndex = 762
        Me.Label4.Text = "وقع هنا  ======>"
=======
        Me.Label4.Location = New System.Drawing.Point(357, 118)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(93, 19)
        Me.Label4.TabIndex = 762
        Me.Label4.Text = "وقع هنا  ===>"
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.Location = New System.Drawing.Point(358, 91)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label5.Size = New System.Drawing.Size(93, 15)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "اســــــم المـوقــــع :"
        '
        'pBoxSavedSignature
        '
        Me.pBoxSavedSignature.BackColor = System.Drawing.Color.White
        Me.pBoxSavedSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pBoxSavedSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pBoxSavedSignature.Location = New System.Drawing.Point(4, 4)
        Me.pBoxSavedSignature.Name = "pBoxSavedSignature"
        Me.pBoxSavedSignature.Size = New System.Drawing.Size(350, 82)
        Me.pBoxSavedSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pBoxSavedSignature.TabIndex = 13
        Me.pBoxSavedSignature.TabStop = False
        '
        'ButtonAddNaem
        '
        Me.ButtonAddNaem.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonAddNaem.Appearance.BackColor2 = System.Drawing.Color.DeepSkyBlue
        Me.ButtonAddNaem.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonAddNaem.Appearance.Options.UseBackColor = True
        Me.ButtonAddNaem.Appearance.Options.UseFont = True
        Me.ButtonAddNaem.Appearance.Options.UseTextOptions = True
        Me.ButtonAddNaem.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ButtonAddNaem.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.addheader_16x16
        Me.ButtonAddNaem.Location = New System.Drawing.Point(4, 199)
        Me.ButtonAddNaem.Name = "ButtonAddNaem"
        Me.ButtonAddNaem.RightToLeft = System.Windows.Forms.RightToLeft.No
<<<<<<< HEAD
        Me.ButtonAddNaem.Size = New System.Drawing.Size(234, 32)
=======
        Me.ButtonAddNaem.Size = New System.Drawing.Size(217, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ButtonAddNaem.TabIndex = 761
        Me.ButtonAddNaem.Text = "إضافة الاسم الى التوقيع مع الاعتماد"
        '
        'TextRealname
        '
        Me.TextRealname.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRealname.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextRealname.ForeColor = System.Drawing.Color.Navy
        Me.TextRealname.Location = New System.Drawing.Point(4, 87)
        Me.TextRealname.Margin = New System.Windows.Forms.Padding(4)
        Me.TextRealname.Name = "TextRealname"
        Me.TextRealname.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextRealname.Size = New System.Drawing.Size(350, 26)
        Me.TextRealname.TabIndex = 17
        Me.TextRealname.Text = "مصطفى ابراهيم السعدي"
        '
        'pBoxSignature
        '
<<<<<<< HEAD
        Me.pBoxSignature.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.pBoxSignature.BackgroundImage = Global.CC_JO.My.Resources.Resources.sigblock
=======
        Me.pBoxSignature.BackColor = System.Drawing.Color.White
        Me.pBoxSignature.BackgroundImage = CType(resources.GetObject("pBoxSignature.BackgroundImage"), System.Drawing.Image)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.pBoxSignature.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pBoxSignature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pBoxSignature.Location = New System.Drawing.Point(4, 115)
        Me.pBoxSignature.Name = "pBoxSignature"
        Me.pBoxSignature.Size = New System.Drawing.Size(350, 82)
        Me.pBoxSignature.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pBoxSignature.TabIndex = 761
        Me.pBoxSignature.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ADDBUTTON)
        Me.Panel1.Controls.Add(Me.EDITBUTTON)
        Me.Panel1.Controls.Add(Me.SAVEBUTTON)
<<<<<<< HEAD
        Me.Panel1.Location = New System.Drawing.Point(0, 326)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(776, 37)
=======
        Me.Panel1.Location = New System.Drawing.Point(0, 324)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(753, 37)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Panel1.TabIndex = 1037
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ADDBUTTON.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.Appearance.Options.UseBackColor = True
        Me.ADDBUTTON.Appearance.Options.UseFont = True
        Me.ADDBUTTON.Appearance.Options.UseTextOptions = True
        Me.ADDBUTTON.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ADDBUTTON.Enabled = False
        Me.ADDBUTTON.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.add1
<<<<<<< HEAD
        Me.ADDBUTTON.Location = New System.Drawing.Point(517, 2)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ADDBUTTON.Size = New System.Drawing.Size(255, 32)
=======
        Me.ADDBUTTON.Location = New System.Drawing.Point(501, 2)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ADDBUTTON.Size = New System.Drawing.Size(247, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ADDBUTTON.TabIndex = 764
        Me.ADDBUTTON.TabStop = False
        Me.ADDBUTTON.Text = "إضافة تـــوقيــــع جـديـد"
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.EDITBUTTON.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDITBUTTON.Appearance.Options.UseBackColor = True
        Me.EDITBUTTON.Appearance.Options.UseFont = True
        Me.EDITBUTTON.Appearance.Options.UseTextOptions = True
        Me.EDITBUTTON.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.EDITBUTTON.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.Location = New System.Drawing.Point(3, 2)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
<<<<<<< HEAD
        Me.EDITBUTTON.Size = New System.Drawing.Size(255, 32)
=======
        Me.EDITBUTTON.Size = New System.Drawing.Size(247, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.EDITBUTTON.TabIndex = 763
        Me.EDITBUTTON.Text = "تعديل التوقيع"
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.SAVEBUTTON.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Appearance.Options.UseBackColor = True
        Me.SAVEBUTTON.Appearance.Options.UseFont = True
        Me.SAVEBUTTON.Appearance.Options.UseTextOptions = True
        Me.SAVEBUTTON.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.SAVEBUTTON.Enabled = False
        Me.SAVEBUTTON.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
<<<<<<< HEAD
        Me.SAVEBUTTON.Location = New System.Drawing.Point(260, 2)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SAVEBUTTON.Size = New System.Drawing.Size(255, 32)
=======
        Me.SAVEBUTTON.Location = New System.Drawing.Point(252, 2)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SAVEBUTTON.Size = New System.Drawing.Size(247, 32)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.SAVEBUTTON.TabIndex = 762
        Me.SAVEBUTTON.Text = "حفظ التوقيع"
        '
        'BackWorker2
        '
        '
        'Formsignature
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
<<<<<<< HEAD
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(779, 368)
=======
        Me.ClientSize = New System.Drawing.Size(756, 362)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel6)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Formsignature"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "منشئى التوقيــــع"
        Me.Panel6.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        CType(Me.PictureBox1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.CBFontSize.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
<<<<<<< HEAD
        CType(Me.colorPickEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CBFontSize1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        CType(Me.pBoxSavedSignature, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pBoxSignature, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label8 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox1 As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents LabelWidth As Label
    Friend WithEvents LabelHeight As Label
    Friend WithEvents TextIDCS As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents TextUP As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LabelFont As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents CBFontSize As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TextRight As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents btnClearSignature As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents btnSaveSignature As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents pBoxSavedSignature As PictureBox
    Friend WithEvents ButtonAddNaem As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents TextRealname As TextBox
    Friend WithEvents pBoxSignature As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents EDITBUTTON As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SAVEBUTTON As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents txtSignatureFileName As TextBox
    Friend WithEvents ADDBUTTON As DevExpress.XtraEditors.SimpleButton
<<<<<<< HEAD
    Friend WithEvents Label6 As Label
    Friend WithEvents CBFontSize1 As DevExpress.XtraEditors.ComboBoxEdit
    Private WithEvents colorPickEdit1 As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents Label9 As Label
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
End Class
