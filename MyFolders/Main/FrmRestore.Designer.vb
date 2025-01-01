<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmRestore))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.BUTTONDeatch = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.RadioCustom = New System.Windows.Forms.RadioButton()
        Me.RadioStandard = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.RadioData = New System.Windows.Forms.RadioButton()
        Me.RadioSchemaAndData = New System.Windows.Forms.RadioButton()
        Me.RadioDataOnly = New System.Windows.Forms.RadioButton()
        Me.LabelRestore = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.RadioNewData = New System.Windows.Forms.RadioButton()
        Me.RadioALLData = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBackupPath = New DevExpress.XtraEditors.ButtonEdit()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.TextBackupPath.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.SuspendLayout()
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.Gold
        Me.ProgressBar1.ForeColor = System.Drawing.Color.Brown
        Me.ProgressBar1.Location = New System.Drawing.Point(3, 2)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(316, 26)
        Me.ProgressBar1.TabIndex = 529
        Me.ProgressBar1.Visible = False
        '
        'BUTTONDeatch
        '
        Me.BUTTONDeatch.BackColor = System.Drawing.Color.Transparent
        Me.BUTTONDeatch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BUTTONDeatch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BUTTONDeatch.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BUTTONDeatch.Image = CType(resources.GetObject("BUTTONDeatch.Image"), System.Drawing.Image)
        Me.BUTTONDeatch.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BUTTONDeatch.Location = New System.Drawing.Point(320, 2)
        Me.BUTTONDeatch.Name = "BUTTONDeatch"
        Me.BUTTONDeatch.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BUTTONDeatch.Size = New System.Drawing.Size(202, 26)
        Me.BUTTONDeatch.TabIndex = 528
        Me.BUTTONDeatch.Text = "استعادة البيانات من النسخة الاحتياطية"
        Me.BUTTONDeatch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUTTONDeatch.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(6, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 15)
        Me.Label1.TabIndex = 527
        Me.Label1.Text = "قواعد البيانات"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(4, 21)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(8, 6, 8, 6)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(391, 23)
        Me.ComboBox1.TabIndex = 526
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(4, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(108, 15)
        Me.Label2.TabIndex = 532
        Me.Label2.Text = "مسار النسخة الاحتياطية"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel7)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(114, 105)
        Me.GroupBox1.TabIndex = 610
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "طرق الأستعادة"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel7.Controls.Add(Me.RadioCustom)
        Me.Panel7.Controls.Add(Me.RadioStandard)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(3, 18)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel7.Size = New System.Drawing.Size(108, 84)
        Me.Panel7.TabIndex = 618
        '
        'RadioCustom
        '
        Me.RadioCustom.AutoSize = True
        Me.RadioCustom.Checked = True
        Me.RadioCustom.ForeColor = System.Drawing.Color.Black
        Me.RadioCustom.Location = New System.Drawing.Point(21, 46)
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
        Me.RadioStandard.Location = New System.Drawing.Point(30, 17)
        Me.RadioStandard.Name = "RadioStandard"
        Me.RadioStandard.Size = New System.Drawing.Size(56, 19)
        Me.RadioStandard.TabIndex = 0
        Me.RadioStandard.Text = " قياسية"
        Me.RadioStandard.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox3.Controls.Add(Me.Panel6)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Black
        Me.GroupBox3.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(372, 76)
        Me.GroupBox3.TabIndex = 611
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "أستبدال"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.RadioData)
        Me.Panel6.Controls.Add(Me.RadioSchemaAndData)
        Me.Panel6.Controls.Add(Me.RadioDataOnly)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 18)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel6.Size = New System.Drawing.Size(366, 55)
        Me.Panel6.TabIndex = 618
        '
        'RadioData
        '
        Me.RadioData.AutoSize = True
        Me.RadioData.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioData.ForeColor = System.Drawing.Color.Black
        Me.RadioData.Location = New System.Drawing.Point(23, 17)
        Me.RadioData.Name = "RadioData"
        Me.RadioData.Size = New System.Drawing.Size(87, 19)
        Me.RadioData.TabIndex = 2
        Me.RadioData.Text = "ملفات السجلات"
        Me.RadioData.UseVisualStyleBackColor = True
        '
        'RadioSchemaAndData
        '
        Me.RadioSchemaAndData.AutoSize = True
        Me.RadioSchemaAndData.Checked = True
        Me.RadioSchemaAndData.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioSchemaAndData.ForeColor = System.Drawing.Color.Black
        Me.RadioSchemaAndData.Location = New System.Drawing.Point(210, 17)
        Me.RadioSchemaAndData.Name = "RadioSchemaAndData"
        Me.RadioSchemaAndData.Size = New System.Drawing.Size(132, 19)
        Me.RadioSchemaAndData.TabIndex = 0
        Me.RadioSchemaAndData.TabStop = True
        Me.RadioSchemaAndData.Text = "ملفات قاعدة البيانات كاملة"
        Me.RadioSchemaAndData.UseVisualStyleBackColor = True
        '
        'RadioDataOnly
        '
        Me.RadioDataOnly.AutoSize = True
        Me.RadioDataOnly.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioDataOnly.ForeColor = System.Drawing.Color.Black
        Me.RadioDataOnly.Location = New System.Drawing.Point(122, 17)
        Me.RadioDataOnly.Name = "RadioDataOnly"
        Me.RadioDataOnly.Size = New System.Drawing.Size(71, 19)
        Me.RadioDataOnly.TabIndex = 1
        Me.RadioDataOnly.Text = "ملفات الداتا"
        Me.RadioDataOnly.UseVisualStyleBackColor = True
        '
        'LabelRestore
        '
        Me.LabelRestore.AutoSize = True
        Me.LabelRestore.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelRestore.ForeColor = System.Drawing.Color.Black
        Me.LabelRestore.Location = New System.Drawing.Point(196, 2)
        Me.LabelRestore.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.LabelRestore.Name = "LabelRestore"
        Me.LabelRestore.Size = New System.Drawing.Size(0, 15)
        Me.LabelRestore.TabIndex = 612
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Panel5)
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(381, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(135, 78)
        Me.GroupBox2.TabIndex = 613
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "نوع الأستعادة"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.RadioNewData)
        Me.Panel5.Controls.Add(Me.RadioALLData)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(3, 18)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel5.Size = New System.Drawing.Size(129, 57)
        Me.Panel5.TabIndex = 615
        '
        'RadioNewData
        '
        Me.RadioNewData.AutoSize = True
        Me.RadioNewData.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioNewData.ForeColor = System.Drawing.Color.Black
        Me.RadioNewData.Location = New System.Drawing.Point(22, 28)
        Me.RadioNewData.Name = "RadioNewData"
        Me.RadioNewData.Size = New System.Drawing.Size(90, 19)
        Me.RadioNewData.TabIndex = 1
        Me.RadioNewData.Text = "جزء من الفاعدة"
        Me.RadioNewData.UseVisualStyleBackColor = True
        '
        'RadioALLData
        '
        Me.RadioALLData.AutoSize = True
        Me.RadioALLData.Checked = True
        Me.RadioALLData.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioALLData.ForeColor = System.Drawing.Color.Black
        Me.RadioALLData.Location = New System.Drawing.Point(6, 3)
        Me.RadioALLData.Name = "RadioALLData"
        Me.RadioALLData.Size = New System.Drawing.Size(106, 19)
        Me.RadioALLData.TabIndex = 0
        Me.RadioALLData.TabStop = True
        Me.RadioALLData.Text = "قاعدة البيانات كاملة"
        Me.RadioALLData.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Location = New System.Drawing.Point(3, 203)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 88)
        Me.Panel1.TabIndex = 614
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ProgressBar1)
        Me.Panel2.Controls.Add(Me.BUTTONDeatch)
        Me.Panel2.Location = New System.Drawing.Point(3, 47)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(526, 33)
        Me.Panel2.TabIndex = 615
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Location = New System.Drawing.Point(3, 84)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(526, 113)
        Me.Panel3.TabIndex = 616
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.LabelRestore)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.ComboBox1)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Controls.Add(Me.TextBackupPath)
        Me.Panel4.Location = New System.Drawing.Point(120, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(402, 101)
        Me.Panel4.TabIndex = 617
        '
        'TextBackupPath
        '
        Me.TextBackupPath.EditValue = ""
        Me.TextBackupPath.Location = New System.Drawing.Point(4, 69)
        Me.TextBackupPath.Name = "TextBackupPath"
        SerializableAppearanceObject1.Font = New System.Drawing.Font("Cooper Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject1.FontStyleDelta = System.Drawing.FontStyle.Bold
        SerializableAppearanceObject1.Options.UseFont = True
        SerializableAppearanceObject4.Font = New System.Drawing.Font("Cooper Black", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        SerializableAppearanceObject4.FontStyleDelta = System.Drawing.FontStyle.Bold
        SerializableAppearanceObject4.Options.UseFont = True
        Me.TextBackupPath.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis, "", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.TextBackupPath.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.TextBackupPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBackupPath.Size = New System.Drawing.Size(391, 22)
        Me.TextBackupPath.TabIndex = 533
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel8.Controls.Add(Me.Label3)
        Me.Panel8.Location = New System.Drawing.Point(3, 2)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(526, 42)
        Me.Panel8.TabIndex = 617
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.CC_JO.My.Resources.Resources.editdatasource_32x32
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(524, 40)
        Me.Label3.TabIndex = 523
        Me.Label3.Text = "استعادة البيانات من النسخة الاحتياطية  "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 19.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(532, 294)
        Me.Controls.Add(Me.Panel8)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmRestore"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "استعادة البيانات من النسخة الاحتياطية  "
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.TextBackupPath.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents BUTTONDeatch As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioCustom As System.Windows.Forms.RadioButton
    Friend WithEvents RadioStandard As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDataOnly As System.Windows.Forms.RadioButton
    Friend WithEvents RadioSchemaAndData As System.Windows.Forms.RadioButton
    Friend WithEvents LabelRestore As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioNewData As System.Windows.Forms.RadioButton
    Friend WithEvents RadioALLData As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents TextBackupPath As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Panel8 As Panel
    Friend WithEvents Label3 As Label
End Class
