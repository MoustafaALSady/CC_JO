<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SearchCash
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SEARCHCASH))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RB5 = New System.Windows.Forms.RadioButton()
        Me.RB2 = New System.Windows.Forms.RadioButton()
        Me.RB6 = New System.Windows.Forms.RadioButton()
        Me.RB1 = New System.Windows.Forms.RadioButton()
        Me.RB4 = New System.Windows.Forms.RadioButton()
        Me.RB3 = New System.Windows.Forms.RadioButton()
        Me.SearchBUTTON = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioB5 = New System.Windows.Forms.RadioButton()
        Me.RadioB6 = New System.Windows.Forms.RadioButton()
        Me.RadioB1 = New System.Windows.Forms.RadioButton()
        Me.RadioB4 = New System.Windows.Forms.RadioButton()
        Me.RadioB3 = New System.Windows.Forms.RadioButton()
        Me.RadioB2 = New System.Windows.Forms.RadioButton()
        Me.Texser = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox1.Location = New System.Drawing.Point(0, 87)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(348, 87)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات البحث"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RB5)
        Me.Panel1.Controls.Add(Me.RB2)
        Me.Panel1.Controls.Add(Me.RB6)
        Me.Panel1.Controls.Add(Me.RB1)
        Me.Panel1.Controls.Add(Me.RB4)
        Me.Panel1.Controls.Add(Me.RB3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(342, 66)
        Me.Panel1.TabIndex = 762
        '
        'RB5
        '
        Me.RB5.AutoSize = True
        Me.RB5.BackColor = System.Drawing.Color.Transparent
        Me.RB5.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB5.ForeColor = System.Drawing.Color.Blue
        Me.RB5.Location = New System.Drawing.Point(123, 36)
        Me.RB5.Name = "RB5"
        Me.RB5.Size = New System.Drawing.Size(68, 19)
        Me.RB5.TabIndex = 649
        Me.RB5.Text = "رقم الشيك"
        Me.RB5.UseVisualStyleBackColor = False
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.BackColor = System.Drawing.Color.Transparent
        Me.RB2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB2.ForeColor = System.Drawing.Color.Blue
        Me.RB2.Location = New System.Drawing.Point(114, 7)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(77, 19)
        Me.RB2.TabIndex = 646
        Me.RB2.Text = "رقم الموظف"
        Me.RB2.UseVisualStyleBackColor = False
        '
        'RB6
        '
        Me.RB6.AutoSize = True
        Me.RB6.BackColor = System.Drawing.Color.Transparent
        Me.RB6.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB6.ForeColor = System.Drawing.Color.Blue
        Me.RB6.Location = New System.Drawing.Point(18, 36)
        Me.RB6.Name = "RB6"
        Me.RB6.Size = New System.Drawing.Size(71, 19)
        Me.RB6.TabIndex = 648
        Me.RB6.Text = "اسم العضو"
        Me.RB6.UseVisualStyleBackColor = False
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.BackColor = System.Drawing.Color.Transparent
        Me.RB1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB1.ForeColor = System.Drawing.Color.Blue
        Me.RB1.Location = New System.Drawing.Point(242, 7)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(72, 19)
        Me.RB1.TabIndex = 644
        Me.RB1.TabStop = True
        Me.RB1.Text = "رقم الحركة"
        Me.RB1.UseVisualStyleBackColor = False
        '
        'RB4
        '
        Me.RB4.AutoSize = True
        Me.RB4.BackColor = System.Drawing.Color.Transparent
        Me.RB4.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB4.ForeColor = System.Drawing.Color.Blue
        Me.RB4.Location = New System.Drawing.Point(215, 36)
        Me.RB4.Name = "RB4"
        Me.RB4.Size = New System.Drawing.Size(99, 19)
        Me.RB4.TabIndex = 647
        Me.RB4.Text = "رقم شهادة الاسهم"
        Me.RB4.UseVisualStyleBackColor = False
        '
        'RB3
        '
        Me.RB3.AutoSize = True
        Me.RB3.BackColor = System.Drawing.Color.Transparent
        Me.RB3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB3.ForeColor = System.Drawing.Color.Blue
        Me.RB3.Location = New System.Drawing.Point(11, 7)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(78, 19)
        Me.RB3.TabIndex = 645
        Me.RB3.Text = "اسم الموظف"
        Me.RB3.UseVisualStyleBackColor = False
        '
        'SearchBUTTON
        '
        Me.SearchBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SearchBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.btn1
        Me.SearchBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SearchBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SearchBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SearchBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SearchBUTTON.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SearchBUTTON.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.SearchBUTTON.Location = New System.Drawing.Point(3, 31)
        Me.SearchBUTTON.Name = "SearchBUTTON"
        Me.SearchBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchBUTTON.Size = New System.Drawing.Size(330, 40)
        Me.SearchBUTTON.TabIndex = 759
        Me.SearchBUTTON.Text = "ابـحـــث"
        Me.SearchBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SearchBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SearchBUTTON.UseCompatibleTextRendering = True
        Me.SearchBUTTON.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(348, 87)
        Me.GroupBox2.TabIndex = 760
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "اختيار الحســاب"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadioB5)
        Me.Panel2.Controls.Add(Me.RadioB6)
        Me.Panel2.Controls.Add(Me.RadioB1)
        Me.Panel2.Controls.Add(Me.RadioB4)
        Me.Panel2.Controls.Add(Me.RadioB3)
        Me.Panel2.Controls.Add(Me.RadioB2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(342, 66)
        Me.Panel2.TabIndex = 763
        '
        'RadioB5
        '
        Me.RadioB5.AutoSize = True
        Me.RadioB5.BackColor = System.Drawing.Color.Transparent
        Me.RadioB5.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioB5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB5.ForeColor = System.Drawing.Color.Blue
        Me.RadioB5.Location = New System.Drawing.Point(109, 32)
        Me.RadioB5.Name = "RadioB5"
        Me.RadioB5.Size = New System.Drawing.Size(82, 19)
        Me.RadioB5.TabIndex = 649
        Me.RadioB5.Text = "شهادة الادخار"
        Me.RadioB5.UseVisualStyleBackColor = False
        '
        'RadioB6
        '
        Me.RadioB6.AutoSize = True
        Me.RadioB6.BackColor = System.Drawing.Color.Transparent
        Me.RadioB6.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioB6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB6.ForeColor = System.Drawing.Color.Blue
        Me.RadioB6.Location = New System.Drawing.Point(-1, 32)
        Me.RadioB6.Name = "RadioB6"
        Me.RadioB6.Size = New System.Drawing.Size(90, 19)
        Me.RadioB6.TabIndex = 648
        Me.RadioB6.Text = "السحب والايداع"
        Me.RadioB6.UseVisualStyleBackColor = False
        '
        'RadioB1
        '
        Me.RadioB1.AutoSize = True
        Me.RadioB1.BackColor = System.Drawing.Color.Transparent
        Me.RadioB1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioB1.Checked = True
        Me.RadioB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB1.ForeColor = System.Drawing.Color.Blue
        Me.RadioB1.Location = New System.Drawing.Point(251, 3)
        Me.RadioB1.Name = "RadioB1"
        Me.RadioB1.Size = New System.Drawing.Size(63, 19)
        Me.RadioB1.TabIndex = 644
        Me.RadioB1.TabStop = True
        Me.RadioB1.Text = "الصندوق"
        Me.RadioB1.UseVisualStyleBackColor = False
        '
        'RadioB4
        '
        Me.RadioB4.AutoSize = True
        Me.RadioB4.BackColor = System.Drawing.Color.Transparent
        Me.RadioB4.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioB4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB4.ForeColor = System.Drawing.Color.Blue
        Me.RadioB4.Location = New System.Drawing.Point(226, 32)
        Me.RadioB4.Name = "RadioB4"
        Me.RadioB4.Size = New System.Drawing.Size(88, 19)
        Me.RadioB4.TabIndex = 647
        Me.RadioB4.Text = "عهدة الموظفين"
        Me.RadioB4.UseVisualStyleBackColor = False
        '
        'RadioB3
        '
        Me.RadioB3.AutoSize = True
        Me.RadioB3.BackColor = System.Drawing.Color.Transparent
        Me.RadioB3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioB3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB3.ForeColor = System.Drawing.Color.Blue
        Me.RadioB3.Location = New System.Drawing.Point(30, 3)
        Me.RadioB3.Name = "RadioB3"
        Me.RadioB3.Size = New System.Drawing.Size(59, 19)
        Me.RadioB3.TabIndex = 645
        Me.RadioB3.Text = "الشيكات"
        Me.RadioB3.UseVisualStyleBackColor = False
        '
        'RadioB2
        '
        Me.RadioB2.AutoSize = True
        Me.RadioB2.BackColor = System.Drawing.Color.Transparent
        Me.RadioB2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioB2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioB2.ForeColor = System.Drawing.Color.Blue
        Me.RadioB2.Location = New System.Drawing.Point(144, 3)
        Me.RadioB2.Name = "RadioB2"
        Me.RadioB2.Size = New System.Drawing.Size(46, 19)
        Me.RadioB2.TabIndex = 646
        Me.RadioB2.Text = "البنك"
        Me.RadioB2.UseVisualStyleBackColor = False
        '
        'Texser
        '
        Me.Texser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Texser.Cursor = System.Windows.Forms.Cursors.Default
        Me.Texser.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Texser.ForeColor = System.Drawing.Color.Blue
        Me.Texser.Location = New System.Drawing.Point(3, 3)
        Me.Texser.Name = "Texser"
        Me.Texser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Texser.Size = New System.Drawing.Size(330, 22)
        Me.Texser.TabIndex = 761
        Me.Texser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Texser)
        Me.Panel3.Controls.Add(Me.SearchBUTTON)
        Me.Panel3.Location = New System.Drawing.Point(3, 176)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(341, 77)
        Me.Panel3.TabIndex = 763
        '
        'SEARCHCASH
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(348, 258)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SEARCHCASH"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "البحث عن النقدية"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB3 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents SearchBUTTON As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioB3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioB1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioB5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioB6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioB4 As System.Windows.Forms.RadioButton
    Friend WithEvents RB5 As System.Windows.Forms.RadioButton
    Friend WithEvents RB6 As System.Windows.Forms.RadioButton
    Friend WithEvents Texser As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Private WithEvents RB4 As RadioButton
End Class
