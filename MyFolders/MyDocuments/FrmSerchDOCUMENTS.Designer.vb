<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSerchDOCUMENTS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSerchDOCUMENTS))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ts = New System.Windows.Forms.TextBox()
        Me.SearchBUTTON = New System.Windows.Forms.Button()
        Me.RadioDOC2_NO = New System.Windows.Forms.RadioButton()
        Me.RadioDOC5_OP = New System.Windows.Forms.RadioButton()
        Me.RadioDOC4_OP = New System.Windows.Forms.RadioButton()
        Me.RadioLO_NO = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(3, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(307, 154)
        Me.GroupBox1.TabIndex = 729
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات البحث"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ts)
        Me.Panel1.Controls.Add(Me.SearchBUTTON)
        Me.Panel1.Controls.Add(Me.RadioDOC2_NO)
        Me.Panel1.Controls.Add(Me.RadioDOC5_OP)
        Me.Panel1.Controls.Add(Me.RadioDOC4_OP)
        Me.Panel1.Controls.Add(Me.RadioLO_NO)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(301, 133)
        Me.Panel1.TabIndex = 763
        '
        'ts
        '
        Me.ts.BackColor = System.Drawing.Color.White
        Me.ts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ts.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ts.Location = New System.Drawing.Point(4, 67)
        Me.ts.Name = "ts"
        Me.ts.Size = New System.Drawing.Size(290, 22)
        Me.ts.TabIndex = 762
        Me.ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SearchBUTTON
        '
        Me.SearchBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SearchBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.btn1
        Me.SearchBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SearchBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SearchBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SearchBUTTON.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBUTTON.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SearchBUTTON.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.SearchBUTTON.Location = New System.Drawing.Point(1, 95)
        Me.SearchBUTTON.Name = "SearchBUTTON"
        Me.SearchBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchBUTTON.Size = New System.Drawing.Size(298, 32)
        Me.SearchBUTTON.TabIndex = 762
        Me.SearchBUTTON.Text = "ابـحـــث"
        Me.SearchBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SearchBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SearchBUTTON.UseCompatibleTextRendering = True
        Me.SearchBUTTON.UseVisualStyleBackColor = False
        '
        'RadioDOC2_NO
        '
        Me.RadioDOC2_NO.AutoSize = True
        Me.RadioDOC2_NO.BackColor = System.Drawing.Color.Transparent
        Me.RadioDOC2_NO.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioDOC2_NO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioDOC2_NO.ForeColor = System.Drawing.Color.Black
        Me.RadioDOC2_NO.Location = New System.Drawing.Point(20, 11)
        Me.RadioDOC2_NO.Name = "RadioDOC2_NO"
        Me.RadioDOC2_NO.Size = New System.Drawing.Size(67, 19)
        Me.RadioDOC2_NO.TabIndex = 646
        Me.RadioDOC2_NO.Text = "رقم الملف"
        Me.RadioDOC2_NO.UseVisualStyleBackColor = False
        '
        'RadioDOC5_OP
        '
        Me.RadioDOC5_OP.AutoSize = True
        Me.RadioDOC5_OP.BackColor = System.Drawing.Color.Transparent
        Me.RadioDOC5_OP.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioDOC5_OP.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioDOC5_OP.ForeColor = System.Drawing.Color.Black
        Me.RadioDOC5_OP.Location = New System.Drawing.Point(9, 42)
        Me.RadioDOC5_OP.Name = "RadioDOC5_OP"
        Me.RadioDOC5_OP.Size = New System.Drawing.Size(78, 19)
        Me.RadioDOC5_OP.TabIndex = 648
        Me.RadioDOC5_OP.Text = "بيان المعاملة"
        Me.RadioDOC5_OP.UseVisualStyleBackColor = False
        '
        'RadioDOC4_OP
        '
        Me.RadioDOC4_OP.AutoSize = True
        Me.RadioDOC4_OP.BackColor = System.Drawing.Color.Transparent
        Me.RadioDOC4_OP.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioDOC4_OP.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioDOC4_OP.ForeColor = System.Drawing.Color.Black
        Me.RadioDOC4_OP.Location = New System.Drawing.Point(198, 42)
        Me.RadioDOC4_OP.Name = "RadioDOC4_OP"
        Me.RadioDOC4_OP.Size = New System.Drawing.Size(94, 19)
        Me.RadioDOC4_OP.TabIndex = 645
        Me.RadioDOC4_OP.Text = "موضوع المعاملة"
        Me.RadioDOC4_OP.UseVisualStyleBackColor = False
        '
        'RadioLO_NO
        '
        Me.RadioLO_NO.AutoSize = True
        Me.RadioLO_NO.BackColor = System.Drawing.Color.Transparent
        Me.RadioLO_NO.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioLO_NO.Checked = True
        Me.RadioLO_NO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioLO_NO.ForeColor = System.Drawing.Color.Black
        Me.RadioLO_NO.Location = New System.Drawing.Point(217, 11)
        Me.RadioLO_NO.Name = "RadioLO_NO"
        Me.RadioLO_NO.Size = New System.Drawing.Size(75, 19)
        Me.RadioLO_NO.TabIndex = 647
        Me.RadioLO_NO.TabStop = True
        Me.RadioLO_NO.Text = "رقم المعاملة"
        Me.RadioLO_NO.UseVisualStyleBackColor = False
        '
        'frmSerchDOCUMENTS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(312, 164)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSerchDOCUMENTS"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "البحث عن المستندات"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents ts As System.Windows.Forms.TextBox
    Friend WithEvents RadioDOC5_OP As System.Windows.Forms.RadioButton
    Friend WithEvents RadioLO_NO As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDOC2_NO As System.Windows.Forms.RadioButton
    Friend WithEvents RadioDOC4_OP As System.Windows.Forms.RadioButton
    Friend WithEvents SearchBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
End Class
