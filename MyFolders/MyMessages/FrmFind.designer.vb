<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFind
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFind))
        Me.TxtSearchTerm = New System.Windows.Forms.TextBox
        Me.ChkMatchCase = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.PRINTBUTTON = New System.Windows.Forms.Button
        Me.ButtonXP1 = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TxtSearchTerm
        '
        Me.TxtSearchTerm.Location = New System.Drawing.Point(0, 24)
        Me.TxtSearchTerm.Multiline = True
        Me.TxtSearchTerm.Name = "TxtSearchTerm"
        Me.TxtSearchTerm.Size = New System.Drawing.Size(307, 20)
        Me.TxtSearchTerm.TabIndex = 9
        '
        'ChkMatchCase
        '
        Me.ChkMatchCase.AutoSize = True
        Me.ChkMatchCase.BackColor = System.Drawing.Color.Transparent
        Me.ChkMatchCase.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkMatchCase.ForeColor = System.Drawing.Color.Black
        Me.ChkMatchCase.Location = New System.Drawing.Point(200, 44)
        Me.ChkMatchCase.Name = "ChkMatchCase"
        Me.ChkMatchCase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ChkMatchCase.Size = New System.Drawing.Size(107, 23)
        Me.ChkMatchCase.TabIndex = 8
        Me.ChkMatchCase.Text = " Õ”” «·«Õ—›"
        Me.ChkMatchCase.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(254, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 19)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "»ÕÀ ⁄‰ "
        '
        'PRINTBUTTON
        '
        Me.PRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PRINTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PRINTBUTTON.Dock = System.Windows.Forms.DockStyle.Right
        Me.PRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PRINTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PRINTBUTTON.Location = New System.Drawing.Point(158, 0)
        Me.PRINTBUTTON.Name = "PRINTBUTTON"
        Me.PRINTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.PRINTBUTTON.Size = New System.Drawing.Size(151, 32)
        Me.PRINTBUTTON.TabIndex = 437
        Me.PRINTBUTTON.Text = "»ÕÀ"
        Me.PRINTBUTTON.UseVisualStyleBackColor = False
        '
        'ButtonXP1
        '
        Me.ButtonXP1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonXP1.Dock = System.Windows.Forms.DockStyle.Right
        Me.ButtonXP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonXP1.Location = New System.Drawing.Point(0, 0)
        Me.ButtonXP1.Name = "ButtonXP1"
        Me.ButtonXP1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonXP1.Size = New System.Drawing.Size(158, 32)
        Me.ButtonXP1.TabIndex = 438
        Me.ButtonXP1.Text = "»ÕÀ ⁄‰ «· «·Ì"
        Me.ButtonXP1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButtonXP1)
        Me.Panel1.Controls.Add(Me.PRINTBUTTON)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 74)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(311, 34)
        Me.Panel1.TabIndex = 439
        '
        'frmFind
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BackgroundImage = img
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(311, 108)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TxtSearchTerm)
        Me.Controls.Add(Me.ChkMatchCase)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFind"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "»ÕÀ"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TxtSearchTerm As System.Windows.Forms.TextBox
    Friend WithEvents ChkMatchCase As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PRINTBUTTON As System.Windows.Forms.Button
    Friend WithEvents ButtonXP1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
