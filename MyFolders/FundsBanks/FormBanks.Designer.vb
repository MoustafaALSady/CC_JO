<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBanks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBanks))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButCB2 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBN3 = New System.Windows.Forms.TextBox()
        Me.TextBN4 = New System.Windows.Forms.TextBox()
        Me.TextBN1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBN2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
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
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.TextIDBN = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ButCB2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TextBN3)
        Me.Panel2.Controls.Add(Me.TextBN4)
        Me.Panel2.Controls.Add(Me.TextBN1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.TextBN2)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(1, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(472, 107)
        Me.Panel2.TabIndex = 459
        '
        'ButCB2
        '
        Me.ButCB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButCB2.Image = Global.CC_JO.My.Resources.Resources.Zoom_16x16
        Me.ButCB2.Location = New System.Drawing.Point(2, 55)
        Me.ButCB2.Name = "ButCB2"
        Me.ButCB2.Size = New System.Drawing.Size(33, 22)
        Me.ButCB2.TabIndex = 736
        Me.ButCB2.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(407, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 15)
        Me.Label1.TabIndex = 735
        Me.Label1.Text = "رقم  الحساب"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(435, 84)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 15)
        Me.Label2.TabIndex = 734
        Me.Label2.Text = "الفرع"
        '
        'TextBN3
        '
        Me.TextBN3.BackColor = System.Drawing.Color.White
        Me.TextBN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBN3.Enabled = False
        Me.TextBN3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBN3.ForeColor = System.Drawing.Color.Black
        Me.TextBN3.Location = New System.Drawing.Point(36, 55)
        Me.TextBN3.Name = "TextBN3"
        Me.TextBN3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextBN3.Size = New System.Drawing.Size(363, 22)
        Me.TextBN3.TabIndex = 733
        '
        'TextBN4
        '
        Me.TextBN4.BackColor = System.Drawing.Color.White
        Me.TextBN4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBN4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBN4.ForeColor = System.Drawing.Color.Black
        Me.TextBN4.Location = New System.Drawing.Point(2, 79)
        Me.TextBN4.Name = "TextBN4"
        Me.TextBN4.Size = New System.Drawing.Size(397, 22)
        Me.TextBN4.TabIndex = 732
        '
        'TextBN1
        '
        Me.TextBN1.BackColor = System.Drawing.Color.White
        Me.TextBN1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBN1.Enabled = False
        Me.TextBN1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBN1.ForeColor = System.Drawing.Color.Black
        Me.TextBN1.Location = New System.Drawing.Point(2, 7)
        Me.TextBN1.Name = "TextBN1"
        Me.TextBN1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBN1.Size = New System.Drawing.Size(397, 22)
        Me.TextBN1.TabIndex = 483
        Me.TextBN1.Text = "0"
        Me.TextBN1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(418, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "رقم  البنك"
        '
        'TextBN2
        '
        Me.TextBN2.BackColor = System.Drawing.Color.White
        Me.TextBN2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBN2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextBN2.ForeColor = System.Drawing.Color.Black
        Me.TextBN2.Location = New System.Drawing.Point(2, 31)
        Me.TextBN2.Name = "TextBN2"
        Me.TextBN2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextBN2.Size = New System.Drawing.Size(397, 22)
        Me.TextBN2.TabIndex = 10
        Me.TextBN2.Text = "0"
        Me.TextBN2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(420, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "اسم البنك"
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(440, 0)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 731
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
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
        Me.Panel1.Location = New System.Drawing.Point(1, 150)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(472, 64)
        Me.Panel1.TabIndex = 460
        '
        'LASTBUTTON
        '
        Me.LASTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.LASTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LASTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LASTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LASTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LASTBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.LASTBUTTON.Location = New System.Drawing.Point(2, 1)
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
        Me.NEXTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NEXTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NEXTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NEXTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NEXTBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.NEXTBUTTON.Location = New System.Drawing.Point(40, 1)
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
        Me.BUTTONCANCEL.Location = New System.Drawing.Point(2, 32)
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
        Me.RECORDSLABEL.Location = New System.Drawing.Point(82, 1)
        Me.RECORDSLABEL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RECORDSLABEL.Name = "RECORDSLABEL"
        Me.RECORDSLABEL.Size = New System.Drawing.Size(310, 28)
        Me.RECORDSLABEL.TabIndex = 432
        Me.RECORDSLABEL.Text = "عدد السجلات"
        Me.RECORDSLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.Location = New System.Drawing.Point(119, 32)
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
        Me.PREVIOUSBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PREVIOUSBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PREVIOUSBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PREVIOUSBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PREVIOUSBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.PREVIOUSBUTTON.Location = New System.Drawing.Point(393, 1)
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
        Me.SAVEBUTTON.Location = New System.Drawing.Point(236, 32)
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
        Me.FIRSTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FIRSTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FIRSTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FIRSTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FIRSTBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.FIRSTBUTTON.Location = New System.Drawing.Point(431, 1)
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
        Me.ADDBUTTON.Location = New System.Drawing.Point(353, 32)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(115, 28)
        Me.ADDBUTTON.TabIndex = 739
        Me.ADDBUTTON.Text = "إضافة"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.UseVisualStyleBackColor = True
        '
        'BackWorker2
        '
        '
        'TextIDBN
        '
        Me.TextIDBN.BackColor = System.Drawing.Color.White
        Me.TextIDBN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextIDBN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextIDBN.ForeColor = System.Drawing.Color.Black
        Me.TextIDBN.Location = New System.Drawing.Point(112, 89)
        Me.TextIDBN.Name = "TextIDBN"
        Me.TextIDBN.Size = New System.Drawing.Size(33, 22)
        Me.TextIDBN.TabIndex = 733
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(477, 37)
        Me.Panel4.TabIndex = 1034
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Traditional Arabic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = Global.CC_JO.My.Resources.Resources.bank
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(475, 36)
        Me.Label7.TabIndex = 1008
        Me.Label7.Text = "إضافة البنوك"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormBanks
        '
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(477, 216)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.TextIDBN)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBanks"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة البنك"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBN4 As TextBox
    Friend WithEvents TextBN1 As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBN2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents LASTBUTTON As Button
    Friend WithEvents NEXTBUTTON As Button
    Private WithEvents BUTTONCANCEL As Button
    Friend WithEvents RECORDSLABEL As Label
    Private WithEvents EDITBUTTON As Button
    Friend WithEvents PREVIOUSBUTTON As Button
    Private WithEvents SAVEBUTTON As Button
    Friend WithEvents FIRSTBUTTON As Button
    Private WithEvents ADDBUTTON As Button
    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TextIDBN As TextBox
    Friend WithEvents ButCB2 As Button
    Private WithEvents TextBN3 As TextBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
End Class
