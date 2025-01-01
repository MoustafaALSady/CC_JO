<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConnect
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConnect))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TEXTBOX4 = New ExtendedRichTextBox.RichTextBoxPrintCtrl()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MNUCOPY = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MNUCUT = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.MNUPASTE = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.MNUSELALL = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.MNUNDEO = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonXP2 = New System.Windows.Forms.Button()
        Me.TEXTBOX1 = New System.Windows.Forms.TextBox()
        Me.TEXTBOX2 = New System.Windows.Forms.TextBox()
        Me.TEXTBOX3 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(519, 8)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label4.Size = New System.Drawing.Size(48, 15)
        Me.Label4.TabIndex = 458
        Me.Label4.Text = "الأيميل  : "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(222, 7)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 15)
        Me.Label3.TabIndex = 455
        Me.Label3.Text = "الراسل"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(519, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 453
        Me.Label2.Text = "الموضوع : "
        '
        'TEXTBOX4
        '
        Me.TEXTBOX4.AutoWordSelection = True
        Me.TEXTBOX4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX4.ContextMenuStrip = Me.ContextMenuStrip1
        Me.TEXTBOX4.EnableAutoDragDrop = True
        Me.TEXTBOX4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TEXTBOX4.ForeColor = System.Drawing.Color.Blue
        Me.TEXTBOX4.Location = New System.Drawing.Point(3, 57)
        Me.TEXTBOX4.Margin = New System.Windows.Forms.Padding(2)
        Me.TEXTBOX4.Name = "TEXTBOX4"
        Me.TEXTBOX4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TEXTBOX4.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.TEXTBOX4.Size = New System.Drawing.Size(513, 242)
        Me.TEXTBOX4.TabIndex = 459
        Me.TEXTBOX4.Text = ""
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNUCOPY, Me.ToolStripSeparator1, Me.MNUCUT, Me.ToolStripSeparator2, Me.MNUPASTE, Me.ToolStripSeparator3, Me.MNUSELALL, Me.ToolStripSeparator4, Me.MNUNDEO, Me.ToolStripSeparator5})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(126, 144)
        '
        'MNUCOPY
        '
        Me.MNUCOPY.Name = "MNUCOPY"
        Me.MNUCOPY.Size = New System.Drawing.Size(125, 22)
        Me.MNUCOPY.Text = "نسخ"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(122, 6)
        '
        'MNUCUT
        '
        Me.MNUCUT.Name = "MNUCUT"
        Me.MNUCUT.Size = New System.Drawing.Size(125, 22)
        Me.MNUCUT.Text = "قص"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(122, 6)
        '
        'MNUPASTE
        '
        Me.MNUPASTE.Name = "MNUPASTE"
        Me.MNUPASTE.Size = New System.Drawing.Size(125, 22)
        Me.MNUPASTE.Text = "لصق"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(122, 6)
        '
        'MNUSELALL
        '
        Me.MNUSELALL.Name = "MNUSELALL"
        Me.MNUSELALL.Size = New System.Drawing.Size(125, 22)
        Me.MNUSELALL.Text = "تحديد الكل"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(122, 6)
        '
        'MNUNDEO
        '
        Me.MNUNDEO.Name = "MNUNDEO"
        Me.MNUNDEO.Size = New System.Drawing.Size(125, 22)
        Me.MNUNDEO.Text = "تراجع"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(122, 6)
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = Global.CC_JO.My.Resources.Resources.Doveofpeace
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.Doveofpeace
        Me.PictureBox1.Location = New System.Drawing.Point(519, 78)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(64, 64)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 542
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'ButtonXP2
        '
        Me.ButtonXP2.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonXP2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonXP2.Image = Global.CC_JO.My.Resources.Resources.email_send_receive
        Me.ButtonXP2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXP2.Location = New System.Drawing.Point(4, 303)
        Me.ButtonXP2.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXP2.Name = "ButtonXP2"
        Me.ButtonXP2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonXP2.Size = New System.Drawing.Size(512, 39)
        Me.ButtonXP2.TabIndex = 541
        Me.ButtonXP2.Text = "أرسل "
        Me.ButtonXP2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXP2.UseVisualStyleBackColor = False
        '
        'TEXTBOX1
        '
        Me.TEXTBOX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTBOX1.Location = New System.Drawing.Point(4, 31)
        Me.TEXTBOX1.Margin = New System.Windows.Forms.Padding(2)
        Me.TEXTBOX1.Name = "TEXTBOX1"
        Me.TEXTBOX1.Size = New System.Drawing.Size(512, 22)
        Me.TEXTBOX1.TabIndex = 544
        '
        'TEXTBOX2
        '
        Me.TEXTBOX2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TEXTBOX2.Location = New System.Drawing.Point(4, 4)
        Me.TEXTBOX2.Margin = New System.Windows.Forms.Padding(2)
        Me.TEXTBOX2.Name = "TEXTBOX2"
        Me.TEXTBOX2.Size = New System.Drawing.Size(214, 22)
        Me.TEXTBOX2.TabIndex = 545
        '
        'TEXTBOX3
        '
        Me.TEXTBOX3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TEXTBOX3.Location = New System.Drawing.Point(262, 5)
        Me.TEXTBOX3.Margin = New System.Windows.Forms.Padding(2)
        Me.TEXTBOX3.Name = "TEXTBOX3"
        Me.TEXTBOX3.Size = New System.Drawing.Size(254, 22)
        Me.TEXTBOX3.TabIndex = 546
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.ButtonXP2)
        Me.Panel1.Controls.Add(Me.TEXTBOX4)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Controls.Add(Me.TEXTBOX3)
        Me.Panel1.Controls.Add(Me.TEXTBOX2)
        Me.Panel1.Controls.Add(Me.TEXTBOX1)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(3, 44)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(590, 351)
        Me.Panel1.TabIndex = 547
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(522, 61)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 547
        Me.Label1.Text = "الرسالة  :"
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label5)
        Me.Panel5.Location = New System.Drawing.Point(3, 1)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(590, 42)
        Me.Panel5.TabIndex = 617
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Image = Global.CC_JO.My.Resources.Resources.Announcement_32x32
        Me.Label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(588, 40)
        Me.Label5.TabIndex = 523
        Me.Label5.Text = "الاتصال بناء"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmConnect
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(597, 397)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmConnect"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اتصل بنا"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TEXTBOX4 As ExtendedRichTextBox.RichTextBoxPrintCtrl
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonXP2 As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MNUCOPY As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUCUT As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNUPASTE As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MNUSELALL As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MNUNDEO As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TEXTBOX1 As System.Windows.Forms.TextBox
    Friend WithEvents TEXTBOX2 As System.Windows.Forms.TextBox
    Friend WithEvents TEXTBOX3 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
End Class
