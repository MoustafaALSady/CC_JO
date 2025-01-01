<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInvoice2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInvoice2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RbTB2 = New System.Windows.Forms.RadioButton()
        Me.RbTB3 = New System.Windows.Forms.RadioButton()
        Me.SearchBUTTON = New System.Windows.Forms.Button()
        Me.RbTB1 = New System.Windows.Forms.RadioButton()
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
        Me.GroupBox1.Size = New System.Drawing.Size(337, 125)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات البحث"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RbTB2)
        Me.Panel1.Controls.Add(Me.RbTB3)
        Me.Panel1.Controls.Add(Me.SearchBUTTON)
        Me.Panel1.Controls.Add(Me.RbTB1)
        Me.Panel1.Controls.Add(Me.Texser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 104)
        Me.Panel1.TabIndex = 762
        '
        'RbTB2
        '
        Me.RbTB2.AutoSize = True
        Me.RbTB2.BackColor = System.Drawing.Color.Transparent
        Me.RbTB2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RbTB2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTB2.ForeColor = System.Drawing.Color.Blue
        Me.RbTB2.Location = New System.Drawing.Point(116, 6)
        Me.RbTB2.Name = "RbTB2"
        Me.RbTB2.Size = New System.Drawing.Size(69, 19)
        Me.RbTB2.TabIndex = 646
        Me.RbTB2.Text = "رقم العميل"
        Me.RbTB2.UseVisualStyleBackColor = False
        '
        'RbTB3
        '
        Me.RbTB3.AutoSize = True
        Me.RbTB3.BackColor = System.Drawing.Color.Transparent
        Me.RbTB3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RbTB3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTB3.ForeColor = System.Drawing.Color.Blue
        Me.RbTB3.Location = New System.Drawing.Point(4, 6)
        Me.RbTB3.Name = "RbTB3"
        Me.RbTB3.Size = New System.Drawing.Size(70, 19)
        Me.RbTB3.TabIndex = 645
        Me.RbTB3.Text = "اسم العميل"
        Me.RbTB3.UseVisualStyleBackColor = False
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
        Me.SearchBUTTON.Location = New System.Drawing.Point(6, 59)
        Me.SearchBUTTON.Name = "SearchBUTTON"
        Me.SearchBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchBUTTON.Size = New System.Drawing.Size(317, 40)
        Me.SearchBUTTON.TabIndex = 761
        Me.SearchBUTTON.Text = "ابـحـــث"
        Me.SearchBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SearchBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SearchBUTTON.UseCompatibleTextRendering = True
        Me.SearchBUTTON.UseVisualStyleBackColor = False
        '
        'RbTB1
        '
        Me.RbTB1.AutoSize = True
        Me.RbTB1.BackColor = System.Drawing.Color.Transparent
        Me.RbTB1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RbTB1.Checked = True
        Me.RbTB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbTB1.ForeColor = System.Drawing.Color.Blue
        Me.RbTB1.Location = New System.Drawing.Point(244, 7)
        Me.RbTB1.Name = "RbTB1"
        Me.RbTB1.Size = New System.Drawing.Size(76, 19)
        Me.RbTB1.TabIndex = 644
        Me.RbTB1.TabStop = True
        Me.RbTB1.Text = "رقم الفاتورة"
        Me.RbTB1.UseVisualStyleBackColor = False
        '
        'Texser
        '
        Me.Texser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Texser.Cursor = System.Windows.Forms.Cursors.Default
        Me.Texser.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Texser.ForeColor = System.Drawing.Color.Blue
        Me.Texser.Location = New System.Drawing.Point(6, 34)
        Me.Texser.Name = "Texser"
        Me.Texser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Texser.Size = New System.Drawing.Size(317, 22)
        Me.Texser.TabIndex = 42
        Me.Texser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmInvoice2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(337, 127)
        Me.Controls.Add(Me.GroupBox1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmInvoice2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "البحث عن فاتورة نقل مفصلة"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RbTB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RbTB3 As System.Windows.Forms.RadioButton
    Friend WithEvents RbTB1 As System.Windows.Forms.RadioButton
    Friend WithEvents Texser As System.Windows.Forms.TextBox
    Friend WithEvents SearchBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
End Class
