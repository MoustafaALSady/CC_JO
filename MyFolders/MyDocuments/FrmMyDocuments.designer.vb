<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMyDocuments
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMyDocuments))
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SimpleButton1 = New DevExpress.XtraEditors.SimpleButton()
        Me.btnSaveSignature = New DevExpress.XtraEditors.SimpleButton()
        Me.CMDBROWSE3 = New System.Windows.Forms.Button()
        Me.CMDBROWSE2 = New System.Windows.Forms.Button()
        Me.CMDBROWSE = New System.Windows.Forms.Button()
        Me.CheckEdit1 = New DevExpress.XtraEditors.CheckEdit()
        Me.AxAcroPDF1 = New AxAcroPDFLib.AxAcroPDF()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.SimpleButton2 = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1.SuspendLayout()
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ComboBox1.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(311, 0)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboBox1.Size = New System.Drawing.Size(435, 27)
        Me.ComboBox1.TabIndex = 357
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.SimpleButton1)
        Me.Panel1.Controls.Add(Me.btnSaveSignature)
        Me.Panel1.Controls.Add(Me.CMDBROWSE3)
        Me.Panel1.Controls.Add(Me.CMDBROWSE2)
        Me.Panel1.Controls.Add(Me.CMDBROWSE)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 493)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(748, 36)
        Me.Panel1.TabIndex = 366
        '
        'SimpleButton1
        '
        Me.SimpleButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SimpleButton1.Appearance.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SimpleButton1.Appearance.ForeColor = System.Drawing.Color.White
        Me.SimpleButton1.Appearance.Options.UseFont = True
        Me.SimpleButton1.Appearance.Options.UseForeColor = True
        Me.SimpleButton1.BackgroundImage = Global.CC_JO.My.Resources.Resources.btn1
        Me.SimpleButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SimpleButton1.ImageOptions.Image = CType(resources.GetObject("SimpleButton1.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton1.Location = New System.Drawing.Point(-1, 0)
        Me.SimpleButton1.Name = "SimpleButton1"
        Me.SimpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light
        Me.SimpleButton1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SimpleButton1.Size = New System.Drawing.Size(161, 34)
        Me.SimpleButton1.TabIndex = 764
        Me.SimpleButton1.Text = " Œ‹‹ ‹‹‹„ —”‹‹‹„‹Ì"
        '
        'btnSaveSignature
        '
        Me.btnSaveSignature.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.btnSaveSignature.Appearance.ForeColor = System.Drawing.Color.Black
        Me.btnSaveSignature.Appearance.Options.UseFont = True
        Me.btnSaveSignature.Appearance.Options.UseForeColor = True
        Me.btnSaveSignature.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSaveSignature.ImageOptions.Image = CType(resources.GetObject("btnSaveSignature.ImageOptions.Image"), System.Drawing.Image)
        Me.btnSaveSignature.Location = New System.Drawing.Point(160, 0)
        Me.btnSaveSignature.Name = "btnSaveSignature"
        Me.btnSaveSignature.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSaveSignature.Size = New System.Drawing.Size(151, 34)
        Me.btnSaveSignature.TabIndex = 761
        Me.btnSaveSignature.Text = "                «÷«›… «· ÊﬁÌ⁄  "
        '
        'CMDBROWSE3
        '
        Me.CMDBROWSE3.Dock = System.Windows.Forms.DockStyle.Right
        Me.CMDBROWSE3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDBROWSE3.Image = Global.CC_JO.My.Resources.Resources.participation_rate
        Me.CMDBROWSE3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDBROWSE3.Location = New System.Drawing.Point(311, 0)
        Me.CMDBROWSE3.Name = "CMDBROWSE3"
        Me.CMDBROWSE3.Size = New System.Drawing.Size(145, 34)
        Me.CMDBROWSE3.TabIndex = 368
        Me.CMDBROWSE3.Text = "⁄«—÷ ÊÌ‰œ“"
        Me.CMDBROWSE3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDBROWSE3.UseVisualStyleBackColor = True
        '
        'CMDBROWSE2
        '
        Me.CMDBROWSE2.Dock = System.Windows.Forms.DockStyle.Right
        Me.CMDBROWSE2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDBROWSE2.Image = Global.CC_JO.My.Resources.Resources.file_extension_pdf
        Me.CMDBROWSE2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDBROWSE2.Location = New System.Drawing.Point(456, 0)
        Me.CMDBROWSE2.Name = "CMDBROWSE2"
        Me.CMDBROWSE2.Size = New System.Drawing.Size(145, 34)
        Me.CMDBROWSE2.TabIndex = 367
        Me.CMDBROWSE2.Text = "⁄—÷"
        Me.CMDBROWSE2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDBROWSE2.UseVisualStyleBackColor = True
        '
        'CMDBROWSE
        '
        Me.CMDBROWSE.Dock = System.Windows.Forms.DockStyle.Right
        Me.CMDBROWSE.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CMDBROWSE.Image = Global.CC_JO.My.Resources.Resources.Folder_24x24
        Me.CMDBROWSE.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CMDBROWSE.Location = New System.Drawing.Point(601, 0)
        Me.CMDBROWSE.Name = "CMDBROWSE"
        Me.CMDBROWSE.Size = New System.Drawing.Size(145, 34)
        Me.CMDBROWSE.TabIndex = 366
        Me.CMDBROWSE.Text = "› Õ"
        Me.CMDBROWSE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CMDBROWSE.UseVisualStyleBackColor = True
        '
        'CheckEdit1
        '
        Me.CheckEdit1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CheckEdit1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.CheckEdit1.Location = New System.Drawing.Point(-1, 0)
        Me.CheckEdit1.Name = "CheckEdit1"
        Me.CheckEdit1.Properties.Appearance.BackColor = System.Drawing.Color.DarkSlateBlue
        Me.CheckEdit1.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.CheckEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.CheckEdit1.Properties.Appearance.Options.UseFont = True
        Me.CheckEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.CheckEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        Me.CheckEdit1.Properties.Caption = "Œ‹ ‹‹„ —”‹‹„‹Ì"
        Me.CheckEdit1.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.[Default]
        Me.CheckEdit1.Size = New System.Drawing.Size(161, 30)
        Me.CheckEdit1.TabIndex = 763
        '
        'AxAcroPDF1
        '
        Me.AxAcroPDF1.Enabled = True
        Me.AxAcroPDF1.Location = New System.Drawing.Point(0, 0)
        Me.AxAcroPDF1.Name = "AxAcroPDF1"
        Me.AxAcroPDF1.OcxState = CType(resources.GetObject("AxAcroPDF1.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF1.Size = New System.Drawing.Size(192, 192)
        Me.AxAcroPDF1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CheckEdit1)
        Me.Panel2.Controls.Add(Me.SimpleButton2)
        Me.Panel2.Controls.Add(Me.ComboBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 461)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(748, 32)
        Me.Panel2.TabIndex = 764
        '
        'SimpleButton2
        '
        Me.SimpleButton2.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SimpleButton2.Appearance.ForeColor = System.Drawing.Color.Black
        Me.SimpleButton2.Appearance.Options.UseFont = True
        Me.SimpleButton2.Appearance.Options.UseForeColor = True
        Me.SimpleButton2.Dock = System.Windows.Forms.DockStyle.Right
        Me.SimpleButton2.ImageOptions.Image = CType(resources.GetObject("SimpleButton2.ImageOptions.Image"), System.Drawing.Image)
        Me.SimpleButton2.Location = New System.Drawing.Point(160, 0)
        Me.SimpleButton2.Name = "SimpleButton2"
        Me.SimpleButton2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SimpleButton2.Size = New System.Drawing.Size(151, 30)
        Me.SimpleButton2.TabIndex = 764
        Me.SimpleButton2.Text = " (Word) «÷«›… «· ÊﬁÌ⁄"
        '
        'FrmMyDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(748, 529)
        Me.Controls.Add(Me.AxAcroPDF1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmMyDocuments"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "⁄—÷ „·› PDF  "
        Me.Panel1.ResumeLayout(False)
        CType(Me.CheckEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AxAcroPDF1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CMDBROWSE3 As System.Windows.Forms.Button
    Friend WithEvents CMDBROWSE2 As System.Windows.Forms.Button
    Friend WithEvents CMDBROWSE As System.Windows.Forms.Button
    Friend WithEvents AxAcroPDF1 As AxAcroPDFLib.AxAcroPDF
    Friend WithEvents CheckEdit1 As DevExpress.XtraEditors.CheckEdit
    Friend WithEvents btnSaveSignature As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents SimpleButton1 As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents SimpleButton2 As DevExpress.XtraEditors.SimpleButton
End Class
