<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransport1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTransport1))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RB2 = New System.Windows.Forms.RadioButton()
        Me.SearchBUTTON = New System.Windows.Forms.Button()
        Me.RB3 = New System.Windows.Forms.RadioButton()
        Me.RB1 = New System.Windows.Forms.RadioButton()
        Me.Texser = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.RoyalBlue
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(275, 119)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات البحث"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RB2)
        Me.Panel1.Controls.Add(Me.SearchBUTTON)
        Me.Panel1.Controls.Add(Me.RB3)
        Me.Panel1.Controls.Add(Me.RB1)
        Me.Panel1.Controls.Add(Me.Texser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(269, 98)
        Me.Panel1.TabIndex = 761
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.BackColor = System.Drawing.Color.Transparent
        Me.RB2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB2.ForeColor = System.Drawing.Color.Blue
        Me.RB2.Location = New System.Drawing.Point(99, 3)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(69, 19)
        Me.RB2.TabIndex = 646
        Me.RB2.Text = "رقم العميل"
        Me.RB2.UseVisualStyleBackColor = False
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
        Me.SearchBUTTON.Location = New System.Drawing.Point(2, 56)
        Me.SearchBUTTON.Name = "SearchBUTTON"
        Me.SearchBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchBUTTON.Size = New System.Drawing.Size(262, 35)
        Me.SearchBUTTON.TabIndex = 760
        Me.SearchBUTTON.Text = "ابـحـــث"
        Me.SearchBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SearchBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SearchBUTTON.UseCompatibleTextRendering = True
        Me.SearchBUTTON.UseVisualStyleBackColor = False
        '
        'RB3
        '
        Me.RB3.AutoSize = True
        Me.RB3.BackColor = System.Drawing.Color.Transparent
        Me.RB3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB3.ForeColor = System.Drawing.Color.Blue
        Me.RB3.Location = New System.Drawing.Point(3, 3)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(70, 19)
        Me.RB3.TabIndex = 645
        Me.RB3.Text = "اسم العميل"
        Me.RB3.UseVisualStyleBackColor = False
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.BackColor = System.Drawing.Color.Transparent
        Me.RB1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RB1.Checked = True
        Me.RB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB1.ForeColor = System.Drawing.Color.Blue
        Me.RB1.Location = New System.Drawing.Point(183, 3)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(76, 19)
        Me.RB1.TabIndex = 644
        Me.RB1.TabStop = True
        Me.RB1.Text = "رقم الفاتورة"
        Me.RB1.UseVisualStyleBackColor = False
        '
        'Texser
        '
        Me.Texser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Texser.Cursor = System.Windows.Forms.Cursors.Default
        Me.Texser.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Texser.ForeColor = System.Drawing.Color.Blue
        Me.Texser.Location = New System.Drawing.Point(3, 28)
        Me.Texser.Name = "Texser"
        Me.Texser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Texser.Size = New System.Drawing.Size(261, 22)
        Me.Texser.TabIndex = 41
        Me.Texser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmTransport1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(275, 124)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmTransport1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "البحث عن فاتورة نقل مجمعة"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB3 As System.Windows.Forms.RadioButton
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Texser As System.Windows.Forms.TextBox
    Friend WithEvents SearchBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
End Class
