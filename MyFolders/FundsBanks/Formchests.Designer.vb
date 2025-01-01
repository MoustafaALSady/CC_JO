<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Formchests
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Formchests))
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.TextCB1 = New System.Windows.Forms.TextBox()
        Me.TextCB2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LASTBUTTON = New System.Windows.Forms.Button()
        Me.NEXTBUTTON = New System.Windows.Forms.Button()
        Me.BUTTONCANCEL = New System.Windows.Forms.Button()
        Me.RECORDSLABEL = New System.Windows.Forms.Label()
        Me.EDITBUTTON = New System.Windows.Forms.Button()
        Me.PREVIOUSBUTTON = New System.Windows.Forms.Button()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.FIRSTBUTTON = New System.Windows.Forms.Button()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButCB2 = New System.Windows.Forms.Button()
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.TextIDCB = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(441, 1)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 731
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'TextCB1
        '
        Me.TextCB1.BackColor = System.Drawing.Color.White
        Me.TextCB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCB1.Enabled = False
        Me.TextCB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextCB1.ForeColor = System.Drawing.Color.Black
        Me.TextCB1.Location = New System.Drawing.Point(2, 4)
        Me.TextCB1.Name = "TextCB1"
        Me.TextCB1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextCB1.Size = New System.Drawing.Size(389, 22)
        Me.TextCB1.TabIndex = 483
        Me.TextCB1.Text = "00000"
        Me.TextCB1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextCB2
        '
        Me.TextCB2.BackColor = System.Drawing.Color.White
        Me.TextCB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCB2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextCB2.Enabled = False
        Me.TextCB2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextCB2.ForeColor = System.Drawing.Color.Black
        Me.TextCB2.Location = New System.Drawing.Point(36, 28)
        Me.TextCB2.Name = "TextCB2"
        Me.TextCB2.Size = New System.Drawing.Size(355, 22)
        Me.TextCB2.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(397, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "رقم  الصندوق"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(399, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "اسم الصندوق"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.LASTBUTTON)
        Me.Panel1.Controls.Add(Me.NEXTBUTTON)
        Me.Panel1.Controls.Add(Me.BUTTONCANCEL)
        Me.Panel1.Controls.Add(Me.RECORDSLABEL)
        Me.Panel1.Controls.Add(Me.EDITBUTTON)
        Me.Panel1.Controls.Add(Me.PREVIOUSBUTTON)
        Me.Panel1.Controls.Add(Me.SAVEBUTTON)
        Me.Panel1.Controls.Add(Me.FIRSTBUTTON)
        Me.Panel1.Controls.Add(Me.ADDBUTTON)
        Me.Panel1.Location = New System.Drawing.Point(4, 98)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 66)
        Me.Panel1.TabIndex = 457
        '
        'LASTBUTTON
        '
        Me.LASTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.LASTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.LASTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LASTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LASTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LASTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LASTBUTTON.Location = New System.Drawing.Point(3, 2)
        Me.LASTBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LASTBUTTON.Name = "LASTBUTTON"
        Me.LASTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LASTBUTTON.Size = New System.Drawing.Size(37, 28)
        Me.LASTBUTTON.TabIndex = 453
        Me.LASTBUTTON.UseVisualStyleBackColor = False
        '
        'NEXTBUTTON
        '
        Me.NEXTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.NEXTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.NEXTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NEXTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NEXTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NEXTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NEXTBUTTON.Location = New System.Drawing.Point(41, 2)
        Me.NEXTBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NEXTBUTTON.Name = "NEXTBUTTON"
        Me.NEXTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NEXTBUTTON.Size = New System.Drawing.Size(41, 28)
        Me.NEXTBUTTON.TabIndex = 452
        Me.NEXTBUTTON.UseVisualStyleBackColor = False
        '
        'BUTTONCANCEL
        '
        Me.BUTTONCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BUTTONCANCEL.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.BUTTONCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BUTTONCANCEL.Location = New System.Drawing.Point(3, 33)
        Me.BUTTONCANCEL.Name = "BUTTONCANCEL"
        Me.BUTTONCANCEL.Size = New System.Drawing.Size(115, 28)
        Me.BUTTONCANCEL.TabIndex = 742
        Me.BUTTONCANCEL.Text = "إلغاء"
        Me.BUTTONCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUTTONCANCEL.UseVisualStyleBackColor = True
        '
        'RECORDSLABEL
        '
        Me.RECORDSLABEL.BackColor = System.Drawing.Color.Transparent
        Me.RECORDSLABEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RECORDSLABEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RECORDSLABEL.ForeColor = System.Drawing.Color.Black
        Me.RECORDSLABEL.Location = New System.Drawing.Point(83, 2)
        Me.RECORDSLABEL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RECORDSLABEL.Name = "RECORDSLABEL"
        Me.RECORDSLABEL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RECORDSLABEL.Size = New System.Drawing.Size(308, 28)
        Me.RECORDSLABEL.TabIndex = 432
        Me.RECORDSLABEL.Text = "عدد السجلات"
        Me.RECORDSLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.Location = New System.Drawing.Point(120, 33)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.Size = New System.Drawing.Size(115, 28)
        Me.EDITBUTTON.TabIndex = 741
        Me.EDITBUTTON.Text = "تعديل"
        Me.EDITBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EDITBUTTON.UseVisualStyleBackColor = True
        '
        'PREVIOUSBUTTON
        '
        Me.PREVIOUSBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PREVIOUSBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.PREVIOUSBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PREVIOUSBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PREVIOUSBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PREVIOUSBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PREVIOUSBUTTON.Location = New System.Drawing.Point(392, 2)
        Me.PREVIOUSBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PREVIOUSBUTTON.Name = "PREVIOUSBUTTON"
        Me.PREVIOUSBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PREVIOUSBUTTON.Size = New System.Drawing.Size(37, 28)
        Me.PREVIOUSBUTTON.TabIndex = 450
        Me.PREVIOUSBUTTON.UseVisualStyleBackColor = False
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.Location = New System.Drawing.Point(236, 33)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.Size = New System.Drawing.Size(115, 28)
        Me.SAVEBUTTON.TabIndex = 740
        Me.SAVEBUTTON.Text = "حفظ"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.UseVisualStyleBackColor = True
        '
        'FIRSTBUTTON
        '
        Me.FIRSTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.FIRSTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.FIRSTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FIRSTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FIRSTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FIRSTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FIRSTBUTTON.Location = New System.Drawing.Point(430, 2)
        Me.FIRSTBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FIRSTBUTTON.Name = "FIRSTBUTTON"
        Me.FIRSTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FIRSTBUTTON.Size = New System.Drawing.Size(37, 28)
        Me.FIRSTBUTTON.TabIndex = 449
        Me.FIRSTBUTTON.UseVisualStyleBackColor = False
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.Location = New System.Drawing.Point(352, 33)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(115, 28)
        Me.ADDBUTTON.TabIndex = 739
        Me.ADDBUTTON.Text = "إضافة"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ButCB2)
        Me.Panel2.Controls.Add(Me.TextCB1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextCB2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(4, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 55)
        Me.Panel2.TabIndex = 458
        '
        'ButCB2
        '
        Me.ButCB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButCB2.Image = Global.CC_JO.My.Resources.Resources.Zoom_16x16
        Me.ButCB2.Location = New System.Drawing.Point(2, 28)
        Me.ButCB2.Name = "ButCB2"
        Me.ButCB2.Size = New System.Drawing.Size(33, 22)
        Me.ButCB2.TabIndex = 484
        Me.ButCB2.UseVisualStyleBackColor = True
        '
        'BackWorker2
        '
        '
        'TextIDCB
        '
        Me.TextIDCB.BackColor = System.Drawing.Color.White
        Me.TextIDCB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextIDCB.Enabled = False
        Me.TextIDCB.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextIDCB.ForeColor = System.Drawing.Color.Black
        Me.TextIDCB.Location = New System.Drawing.Point(261, 56)
        Me.TextIDCB.Name = "TextIDCB"
        Me.TextIDCB.Size = New System.Drawing.Size(42, 22)
        Me.TextIDCB.TabIndex = 732
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Traditional Arabic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = Global.CC_JO.My.Resources.Resources.Currency2_32x32
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(481, 36)
        Me.Label7.TabIndex = 1009
        Me.Label7.Text = "إضافة الصناديق"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Formchests
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(481, 169)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TextIDCB)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Formchests"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الصناديق "
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TextCB1 As System.Windows.Forms.TextBox
    Friend WithEvents TextCB2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents LASTBUTTON As System.Windows.Forms.Button
    Friend WithEvents NEXTBUTTON As System.Windows.Forms.Button
    Friend WithEvents RECORDSLABEL As System.Windows.Forms.Label
    Friend WithEvents PREVIOUSBUTTON As System.Windows.Forms.Button
    Friend WithEvents FIRSTBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextIDCB As System.Windows.Forms.TextBox
    Private WithEvents BUTTONCANCEL As Button
    Private WithEvents EDITBUTTON As Button
    Private WithEvents SAVEBUTTON As Button
    Private WithEvents ADDBUTTON As Button
    Friend WithEvents ButCB2 As Button
    Friend WithEvents Label7 As Label
End Class
