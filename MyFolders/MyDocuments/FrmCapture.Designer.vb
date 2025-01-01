<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCapture
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCapture))
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.buttoncapture = New System.Windows.Forms.Button
        Me.buttonsave = New System.Windows.Forms.Button
        Me.ButtonXP1 = New System.Windows.Forms.Button
        Me.ButtonPrintScreen = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(560, 358)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'buttoncapture
        '
        Me.buttoncapture.BackColor = System.Drawing.Color.Transparent
        Me.buttoncapture.Dock = System.Windows.Forms.DockStyle.Right
        Me.buttoncapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttoncapture.ForeColor = System.Drawing.Color.Black
        Me.buttoncapture.Location = New System.Drawing.Point(200, 358)
        Me.buttoncapture.Name = "buttoncapture"
        Me.buttoncapture.Size = New System.Drawing.Size(72, 38)
        Me.buttoncapture.TabIndex = 741
        Me.buttoncapture.Text = "أبدأ"
        Me.buttoncapture.UseVisualStyleBackColor = False
        '
        'buttonsave
        '
        Me.buttonsave.BackColor = System.Drawing.Color.Transparent
        Me.buttonsave.Dock = System.Windows.Forms.DockStyle.Right
        Me.buttonsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.buttonsave.ForeColor = System.Drawing.Color.Black
        Me.buttonsave.Location = New System.Drawing.Point(272, 358)
        Me.buttonsave.Name = "buttonsave"
        Me.buttonsave.Size = New System.Drawing.Size(91, 38)
        Me.buttonsave.TabIndex = 739
        Me.buttonsave.Text = "حفظ الصورة"
        Me.buttonsave.UseVisualStyleBackColor = False
        '
        'ButtonXP1
        '
        Me.ButtonXP1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonXP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP1.ForeColor = System.Drawing.Color.Black
        Me.ButtonXP1.Location = New System.Drawing.Point(363, 358)
        Me.ButtonXP1.Name = "ButtonXP1"
        Me.ButtonXP1.Size = New System.Drawing.Size(85, 38)
        Me.ButtonXP1.TabIndex = 742
        Me.ButtonXP1.Text = "اخنيار صورة"
        Me.ButtonXP1.UseVisualStyleBackColor = False
        '
        'ButtonPrintScreen
        '
        Me.ButtonPrintScreen.BackColor = System.Drawing.Color.Transparent
        Me.ButtonPrintScreen.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonPrintScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonPrintScreen.ForeColor = System.Drawing.Color.Black
        Me.ButtonPrintScreen.Location = New System.Drawing.Point(448, 358)
        Me.ButtonPrintScreen.Name = "ButtonPrintScreen"
        Me.ButtonPrintScreen.Size = New System.Drawing.Size(112, 38)
        Me.ButtonPrintScreen.TabIndex = 740
        Me.ButtonPrintScreen.Text = "صورة لسطح المكتب"
        Me.ButtonPrintScreen.UseVisualStyleBackColor = False
        '
        'frmCapture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(560, 396)
        Me.Controls.Add(Me.buttoncapture)
        Me.Controls.Add(Me.buttonsave)
        Me.Controls.Add(Me.ButtonXP1)
        Me.Controls.Add(Me.ButtonPrintScreen)
        Me.Controls.Add(Me.PictureBox1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapture"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "لاقط الشاشة"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents buttoncapture As System.Windows.Forms.Button
    Friend WithEvents buttonsave As System.Windows.Forms.Button
    Friend WithEvents ButtonXP1 As System.Windows.Forms.Button
    Friend WithEvents ButtonPrintScreen As System.Windows.Forms.Button
End Class
