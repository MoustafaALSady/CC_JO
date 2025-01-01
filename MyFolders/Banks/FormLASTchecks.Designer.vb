<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormLASTchecks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormLASTchecks))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.CH = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CH1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CH3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CH7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CH8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ButtonXP5 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.TextBox3 = New System.Windows.Forms.TextBox
        Me.TextBox4 = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CH, Me.CH1, Me.CH3, Me.CH7, Me.CH8})
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(610, 143)
        Me.DataGridView1.TabIndex = 0
        '
        'CH
        '
        Me.CH.HeaderText = "رقم"
        Me.CH.Name = "CH"
        Me.CH.Width = 55
        '
        'CH1
        '
        Me.CH1.HeaderText = "رقم الشيك"
        Me.CH1.Name = "CH1"
        Me.CH1.Width = 85
        '
        'CH3
        '
        Me.CH3.HeaderText = "تاريخ الشيك"
        Me.CH3.Name = "CH3"
        Me.CH3.Width = 98
        '
        'CH7
        '
        Me.CH7.HeaderText = "اسم ساحب الشيك"
        Me.CH7.Name = "CH7"
        Me.CH7.Width = 230
        '
        'CH8
        '
        Me.CH8.HeaderText = "رقم العميل"
        Me.CH8.Name = "CH8"
        Me.CH8.Width = 85
        '
        'ButtonXP5
        '
        Me.ButtonXP5.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonXP5.Image = Global.CC_JO.My.Resources.Resources.cheque
        Me.ButtonXP5.Location = New System.Drawing.Point(523, 0)
        Me.ButtonXP5.Name = "ButtonXP5"
        Me.ButtonXP5.Size = New System.Drawing.Size(87, 53)
        Me.ButtonXP5.TabIndex = 730
        Me.ButtonXP5.Text = "اضافة شيك"
        Me.ButtonXP5.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(37, 1)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(206, 22)
        Me.TextBox1.TabIndex = 731
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(37, 28)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(206, 22)
        Me.TextBox2.TabIndex = 732
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(249, 1)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(268, 22)
        Me.TextBox3.TabIndex = 733
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(249, 28)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(268, 22)
        Me.TextBox4.TabIndex = 734
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.TextBox2)
        Me.Panel1.Controls.Add(Me.ButtonXP5)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 143)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(610, 53)
        Me.Panel1.TabIndex = 735
        '
        'FormLASTchecks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.CC_JO.My.Resources.Resources.BG3
        Me.ClientSize = New System.Drawing.Size(610, 197)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLASTchecks"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "شيكات متعددة"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CH As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CH1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CH3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CH7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CH8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonXP5 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
