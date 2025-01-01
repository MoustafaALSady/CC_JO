<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSuppliersB
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSuppliersB))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TEXTPHONE = New DevExpress.XtraEditors.TextEdit()
        Me.TextE_mail = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTBOX1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TEXTAgentName = New System.Windows.Forms.TextBox()
        Me.TEXTSupplierName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TextITEMNAME = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.TEXTPHONE.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextE_mail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TEXTPHONE)
        Me.Panel1.Controls.Add(Me.TextE_mail)
        Me.Panel1.Controls.Add(Me.TEXTBOX1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TEXTAgentName)
        Me.Panel1.Controls.Add(Me.TEXTSupplierName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.TextITEMNAME)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Location = New System.Drawing.Point(2, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(453, 179)
        Me.Panel1.TabIndex = 953
        '
        'TEXTPHONE
        '
        Me.TEXTPHONE.EditValue = "07-______"
        Me.TEXTPHONE.Location = New System.Drawing.Point(5, 77)
        Me.TEXTPHONE.Name = "TEXTPHONE"
        Me.TEXTPHONE.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTPHONE.Properties.Appearance.Options.UseFont = True
        Me.TEXTPHONE.Properties.BeepOnError = False
        Me.TEXTPHONE.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TEXTPHONE.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far
        Me.TEXTPHONE.Properties.ContextImageOptions.Image = CType(resources.GetObject("TEXTPHONE.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.TEXTPHONE.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TEXTPHONE.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.SimpleMaskManager))
        Me.TEXTPHONE.Properties.MaskSettings.Set("mask", "0000-000000")
        Me.TEXTPHONE.Properties.NullText = "07"
        Me.TEXTPHONE.Properties.UseMaskAsDisplayFormat = True
        Me.TEXTPHONE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTPHONE.Size = New System.Drawing.Size(343, 22)
        Me.TEXTPHONE.TabIndex = 1009
        '
        'TextE_mail
        '
        Me.TextE_mail.Location = New System.Drawing.Point(5, 101)
        Me.TextE_mail.Name = "TextE_mail"
        Me.TextE_mail.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextE_mail.Properties.Appearance.Options.UseFont = True
        Me.TextE_mail.Properties.ContextImageOptions.Alignment = DevExpress.XtraEditors.ContextImageAlignment.Far
        Me.TextE_mail.Properties.ContextImageOptions.Image = CType(resources.GetObject("TextE_mail.Properties.ContextImageOptions.Image"), System.Drawing.Image)
        Me.TextE_mail.Properties.NullText = "CC_JO@gmail.com"
        Me.TextE_mail.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextE_mail.Size = New System.Drawing.Size(343, 22)
        Me.TextE_mail.TabIndex = 955
        '
        'TEXTBOX1
        '
        Me.TEXTBOX1.BackColor = System.Drawing.Color.White
        Me.TEXTBOX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX1.Enabled = False
        Me.TEXTBOX1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTBOX1.Location = New System.Drawing.Point(5, 7)
        Me.TEXTBOX1.Name = "TEXTBOX1"
        Me.TEXTBOX1.Size = New System.Drawing.Size(343, 22)
        Me.TEXTBOX1.TabIndex = 491
        Me.TEXTBOX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(422, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 497
        Me.Label1.Text = "الرقم"
        '
        'TEXTAgentName
        '
        Me.TEXTAgentName.BackColor = System.Drawing.Color.White
        Me.TEXTAgentName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTAgentName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTAgentName.Location = New System.Drawing.Point(5, 30)
        Me.TEXTAgentName.Name = "TEXTAgentName"
        Me.TEXTAgentName.Size = New System.Drawing.Size(343, 22)
        Me.TEXTAgentName.TabIndex = 492
        Me.TEXTAgentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTSupplierName
        '
        Me.TEXTSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TEXTSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TEXTSupplierName.BackColor = System.Drawing.Color.White
        Me.TEXTSupplierName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTSupplierName.FormattingEnabled = True
        Me.TEXTSupplierName.Location = New System.Drawing.Point(5, 53)
        Me.TEXTSupplierName.Name = "TEXTSupplierName"
        Me.TEXTSupplierName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TEXTSupplierName.Size = New System.Drawing.Size(343, 23)
        Me.TEXTSupplierName.TabIndex = 493
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(354, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(96, 15)
        Me.Label3.TabIndex = 499
        Me.Label3.Text = "اسم الوكيل فى الاردن"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(407, 140)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 15)
        Me.Label6.TabIndex = 508
        Me.Label6.Text = "الاصناف"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(384, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 501
        Me.Label5.Text = "بريد الكترونى"
        '
        'TextITEMNAME
        '
        Me.TextITEMNAME.BackColor = System.Drawing.Color.White
        Me.TextITEMNAME.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextITEMNAME.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextITEMNAME.Location = New System.Drawing.Point(5, 128)
        Me.TextITEMNAME.Multiline = True
        Me.TextITEMNAME.Name = "TextITEMNAME"
        Me.TextITEMNAME.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextITEMNAME.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.TextITEMNAME.Size = New System.Drawing.Size(343, 40)
        Me.TextITEMNAME.TabIndex = 496
        Me.TextITEMNAME.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(397, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 15)
        Me.Label2.TabIndex = 498
        Me.Label2.Text = "اسم المورد"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(414, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 15)
        Me.Label4.TabIndex = 500
        Me.Label4.Text = "الهاتف"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(417, 0)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 725
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.BackgroundImage = CType(resources.GetObject("PictureBox5.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox5.Location = New System.Drawing.Point(419, 0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 726
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.ADDBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.Location = New System.Drawing.Point(239, 222)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ADDBUTTON.Size = New System.Drawing.Size(216, 31)
        Me.ADDBUTTON.TabIndex = 954
        Me.ADDBUTTON.Text = "اضافة F1"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.UseVisualStyleBackColor = False
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SAVEBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.Location = New System.Drawing.Point(2, 222)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SAVEBUTTON.Size = New System.Drawing.Size(235, 31)
        Me.SAVEBUTTON.TabIndex = 955
        Me.SAVEBUTTON.Text = "حفظ F2"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Traditional Arabic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = Global.CC_JO.My.Resources.Resources.ceo
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(459, 36)
        Me.Label7.TabIndex = 1010
        Me.Label7.Text = "إضافة الموردون "
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmSuppliersB
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(459, 256)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SAVEBUTTON)
        Me.Controls.Add(Me.ADDBUTTON)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSuppliersB"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "إضافة الموردون "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TEXTPHONE.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextE_mail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TEXTBOX1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TEXTAgentName As System.Windows.Forms.TextBox
    Friend WithEvents TEXTSupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextITEMNAME As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ADDBUTTON As System.Windows.Forms.Button
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents TextE_mail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEXTPHONE As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As Label
End Class
