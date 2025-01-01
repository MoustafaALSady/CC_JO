<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmBackup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBackup))
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.ComboDBServer = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ButtonXP2 = New System.Windows.Forms.Button()
        Me.ButtonXP3 = New System.Windows.Forms.Button()
        Me.ButtonLOGDATAVASE = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadioCustom = New System.Windows.Forms.RadioButton()
        Me.RadioStandard = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RadioNewData = New System.Windows.Forms.RadioButton()
        Me.RadioALLData = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RadioData = New System.Windows.Forms.RadioButton()
        Me.RadioDataOnly = New System.Windows.Forms.RadioButton()
        Me.RadioSchemaAndData = New System.Windows.Forms.RadioButton()
        Me.Labelbacked = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextBackupPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TextBackupPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboDBServer
        '
        Me.ComboDBServer.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboDBServer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComboDBServer.FormattingEnabled = True
        Me.ComboDBServer.Location = New System.Drawing.Point(162, 19)
        Me.ComboDBServer.Name = "ComboDBServer"
        Me.ComboDBServer.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboDBServer.Size = New System.Drawing.Size(281, 23)
        Me.ComboDBServer.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label1.Location = New System.Drawing.Point(175, 2)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 521
        Me.Label1.Text = "قواعد البيانات"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Label2.Location = New System.Drawing.Point(26, 5)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 522
        Me.Label2.Text = "مسار النسخة الاحتياطية"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.OrangeRed
        Me.ProgressBar1.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 272)
        Me.ProgressBar1.Margin = New System.Windows.Forms.Padding(2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(452, 19)
        Me.ProgressBar1.TabIndex = 523
        Me.ProgressBar1.Visible = False
        '
        'SaveFileDialog1
        '
        Me.SaveFileDialog1.Tag = "2005"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CheckBox1.Location = New System.Drawing.Point(253, 46)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox1.Size = New System.Drawing.Size(191, 19)
        Me.CheckBox1.TabIndex = 524
        Me.CheckBox1.Text = "اجعل البرنامج يسمى النسخة الاحتياطية"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'ComboBox2
        '
        Me.ComboBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Items.AddRange(New Object() {"Crash Dump File (*.dmp)", "SQL Server Transaction Log Backup (*.trn)", "BAK File (*.bak)"})
        Me.ComboBox2.Location = New System.Drawing.Point(161, 68)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox2.Size = New System.Drawing.Size(282, 23)
        Me.ComboBox2.TabIndex = 525
        '
        'ButtonXP2
        '
        Me.ButtonXP2.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonXP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonXP2.Image = CType(resources.GetObject("ButtonXP2.Image"), System.Drawing.Image)
        Me.ButtonXP2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXP2.Location = New System.Drawing.Point(155, 2)
        Me.ButtonXP2.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXP2.Name = "ButtonXP2"
        Me.ButtonXP2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonXP2.Size = New System.Drawing.Size(162, 25)
        Me.ButtonXP2.TabIndex = 520
        Me.ButtonXP2.Text = "نسخة احتياطية لقاعدة بيانات"
        Me.ButtonXP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXP2.UseVisualStyleBackColor = False
        '
        'ButtonXP3
        '
        Me.ButtonXP3.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonXP3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonXP3.Image = CType(resources.GetObject("ButtonXP3.Image"), System.Drawing.Image)
        Me.ButtonXP3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXP3.Location = New System.Drawing.Point(3, 2)
        Me.ButtonXP3.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXP3.Name = "ButtonXP3"
        Me.ButtonXP3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonXP3.Size = New System.Drawing.Size(151, 25)
        Me.ButtonXP3.TabIndex = 526
        Me.ButtonXP3.Text = " نسخة احتياطية لكل قواعد البيانات"
        Me.ButtonXP3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXP3.UseVisualStyleBackColor = False
        '
        'ButtonLOGDATAVASE
        '
        Me.ButtonLOGDATAVASE.BackColor = System.Drawing.Color.Transparent
        Me.ButtonLOGDATAVASE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonLOGDATAVASE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonLOGDATAVASE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonLOGDATAVASE.Image = CType(resources.GetObject("ButtonLOGDATAVASE.Image"), System.Drawing.Image)
        Me.ButtonLOGDATAVASE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonLOGDATAVASE.Location = New System.Drawing.Point(318, 2)
        Me.ButtonLOGDATAVASE.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonLOGDATAVASE.Name = "ButtonLOGDATAVASE"
        Me.ButtonLOGDATAVASE.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonLOGDATAVASE.Size = New System.Drawing.Size(130, 25)
        Me.ButtonLOGDATAVASE.TabIndex = 608
        Me.ButtonLOGDATAVASE.Text = "ضغط قاعدة البيانات"
        Me.ButtonLOGDATAVASE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonLOGDATAVASE.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox1.Location = New System.Drawing.Point(2, 0)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(154, 93)
        Me.GroupBox1.TabIndex = 609
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "نوع النسخة"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.RadioCustom)
        Me.Panel3.Controls.Add(Me.RadioStandard)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(2, 17)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(150, 74)
        Me.Panel3.TabIndex = 614
        '
        'RadioCustom
        '
        Me.RadioCustom.AutoSize = True
        Me.RadioCustom.Checked = True
        Me.RadioCustom.ForeColor = System.Drawing.Color.Black
        Me.RadioCustom.Location = New System.Drawing.Point(6, 25)
        Me.RadioCustom.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioCustom.Name = "RadioCustom"
        Me.RadioCustom.Size = New System.Drawing.Size(65, 19)
        Me.RadioCustom.TabIndex = 1
        Me.RadioCustom.TabStop = True
        Me.RadioCustom.Text = " مخصصة"
        Me.RadioCustom.UseVisualStyleBackColor = True
        '
        'RadioStandard
        '
        Me.RadioStandard.AutoSize = True
        Me.RadioStandard.ForeColor = System.Drawing.Color.Black
        Me.RadioStandard.Location = New System.Drawing.Point(86, 25)
        Me.RadioStandard.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioStandard.Name = "RadioStandard"
        Me.RadioStandard.Size = New System.Drawing.Size(56, 19)
        Me.RadioStandard.TabIndex = 0
        Me.RadioStandard.Text = " قياسية"
        Me.RadioStandard.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.RadioNewData)
        Me.GroupBox2.Controls.Add(Me.RadioALLData)
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox2.Location = New System.Drawing.Point(322, 202)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(133, 62)
        Me.GroupBox2.TabIndex = 610
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "نوع البيانات"
        '
        'RadioNewData
        '
        Me.RadioNewData.AutoSize = True
        Me.RadioNewData.ForeColor = System.Drawing.Color.Black
        Me.RadioNewData.Location = New System.Drawing.Point(16, 40)
        Me.RadioNewData.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioNewData.Name = "RadioNewData"
        Me.RadioNewData.Size = New System.Drawing.Size(107, 19)
        Me.RadioNewData.TabIndex = 1
        Me.RadioNewData.Text = "البيانات الجديدة فقط"
        Me.RadioNewData.UseVisualStyleBackColor = True
        '
        'RadioALLData
        '
        Me.RadioALLData.AutoSize = True
        Me.RadioALLData.Checked = True
        Me.RadioALLData.ForeColor = System.Drawing.Color.Black
        Me.RadioALLData.Location = New System.Drawing.Point(28, 17)
        Me.RadioALLData.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioALLData.Name = "RadioALLData"
        Me.RadioALLData.Size = New System.Drawing.Size(95, 19)
        Me.RadioALLData.TabIndex = 0
        Me.RadioALLData.TabStop = True
        Me.RadioALLData.Text = "كل البيانات كاملة"
        Me.RadioALLData.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.RadioData)
        Me.GroupBox3.Controls.Add(Me.RadioDataOnly)
        Me.GroupBox3.Controls.Add(Me.RadioSchemaAndData)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.GroupBox3.Location = New System.Drawing.Point(3, 202)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(315, 62)
        Me.GroupBox3.TabIndex = 610
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "نوع الملفات"
        '
        'RadioData
        '
        Me.RadioData.AutoSize = True
        Me.RadioData.ForeColor = System.Drawing.Color.Black
        Me.RadioData.Location = New System.Drawing.Point(6, 24)
        Me.RadioData.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioData.Name = "RadioData"
        Me.RadioData.Size = New System.Drawing.Size(87, 19)
        Me.RadioData.TabIndex = 2
        Me.RadioData.Text = "ملفات السجلات"
        Me.RadioData.UseVisualStyleBackColor = True
        '
        'RadioDataOnly
        '
        Me.RadioDataOnly.AutoSize = True
        Me.RadioDataOnly.ForeColor = System.Drawing.Color.Black
        Me.RadioDataOnly.Location = New System.Drawing.Point(102, 24)
        Me.RadioDataOnly.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioDataOnly.Name = "RadioDataOnly"
        Me.RadioDataOnly.Size = New System.Drawing.Size(71, 19)
        Me.RadioDataOnly.TabIndex = 1
        Me.RadioDataOnly.Text = "ملفات الداتا"
        Me.RadioDataOnly.UseVisualStyleBackColor = True
        '
        'RadioSchemaAndData
        '
        Me.RadioSchemaAndData.AutoSize = True
        Me.RadioSchemaAndData.Checked = True
        Me.RadioSchemaAndData.ForeColor = System.Drawing.Color.Black
        Me.RadioSchemaAndData.Location = New System.Drawing.Point(177, 24)
        Me.RadioSchemaAndData.Margin = New System.Windows.Forms.Padding(2)
        Me.RadioSchemaAndData.Name = "RadioSchemaAndData"
        Me.RadioSchemaAndData.Size = New System.Drawing.Size(132, 19)
        Me.RadioSchemaAndData.TabIndex = 0
        Me.RadioSchemaAndData.TabStop = True
        Me.RadioSchemaAndData.Text = "ملفات قاعدة البيانات كاملة"
        Me.RadioSchemaAndData.UseVisualStyleBackColor = True
        '
        'Labelbacked
        '
        Me.Labelbacked.AutoSize = True
        Me.Labelbacked.BackColor = System.Drawing.Color.Transparent
        Me.Labelbacked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Labelbacked.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Labelbacked.ForeColor = System.Drawing.Color.Black
        Me.Labelbacked.Location = New System.Drawing.Point(6, 223)
        Me.Labelbacked.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Labelbacked.Name = "Labelbacked"
        Me.Labelbacked.Size = New System.Drawing.Size(0, 15)
        Me.Labelbacked.TabIndex = 611
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButtonXP3)
        Me.Panel1.Controls.Add(Me.ButtonXP2)
        Me.Panel1.Controls.Add(Me.ButtonLOGDATAVASE)
        Me.Panel1.Location = New System.Drawing.Point(3, 295)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(452, 31)
        Me.Panel1.TabIndex = 612
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TextBackupPath)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(4, 147)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(451, 50)
        Me.Panel2.TabIndex = 613
        '
        'TextBackupPath
        '
        Me.TextBackupPath.EditValue = ""
        Me.TextBackupPath.Location = New System.Drawing.Point(2, 22)
        Me.TextBackupPath.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBackupPath.Name = "TextBackupPath"
        SerializableAppearanceObject5.Font = New System.Drawing.Font("Cooper Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject5.FontStyleDelta = System.Drawing.FontStyle.Bold
        SerializableAppearanceObject5.Options.UseFont = True
        SerializableAppearanceObject8.Font = New System.Drawing.Font("Cooper Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject8.FontStyleDelta = System.Drawing.FontStyle.Bold
        SerializableAppearanceObject8.Options.UseFont = True
        Me.TextBackupPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.TextBackupPath.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.TextBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBackupPath.Size = New System.Drawing.Size(440, 22)
        Me.TextBackupPath.TabIndex = 616
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.ComboBox2)
        Me.Panel4.Controls.Add(Me.ComboDBServer)
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.CheckBox1)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Location = New System.Drawing.Point(3, 46)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(452, 97)
        Me.Panel4.TabIndex = 615
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label3)
        Me.Panel5.Location = New System.Drawing.Point(3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(452, 42)
        Me.Panel5.TabIndex = 616
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.CC_JO.My.Resources.Resources.datasource_32x32
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(450, 40)
        Me.Label3.TabIndex = 523
        Me.Label3.Text = "نسخة احتياطية - ضغط قاعدة البيانات  "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(459, 329)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Labelbacked)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBackup"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "نسخة احتياطية - ضغط قاعدة البيانات  "
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TextBackupPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboDBServer As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonXP2 As System.Windows.Forms.Button
    Friend WithEvents ButtonXP3 As System.Windows.Forms.Button
    Friend WithEvents ButtonLOGDATAVASE As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioCustom As System.Windows.Forms.RadioButton
    Friend WithEvents RadioStandard As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioNewData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioALLData As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDataOnly As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSchemaAndData As System.Windows.Forms.RadioButton
    Friend WithEvents Labelbacked As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents TextBackupPath As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label3 As Label
End Class
