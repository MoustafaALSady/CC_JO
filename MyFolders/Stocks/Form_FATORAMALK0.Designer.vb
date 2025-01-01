<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_FATORAMALK0
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_FATORAMALK0))
        Me.TexFIND = New System.Windows.Forms.TextBox()
        Me.Ra1 = New System.Windows.Forms.RadioButton()
        Me.Ra2 = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TexFIND
        '
        Me.TexFIND.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TexFIND.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TexFIND.Location = New System.Drawing.Point(5, 34)
        Me.TexFIND.Name = "TexFIND"
        Me.TexFIND.Size = New System.Drawing.Size(236, 22)
        Me.TexFIND.TabIndex = 1
        Me.TexFIND.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Ra1
        '
        Me.Ra1.AutoSize = True
        Me.Ra1.BackColor = System.Drawing.Color.Transparent
        Me.Ra1.Checked = True
        Me.Ra1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Ra1.ForeColor = System.Drawing.Color.Black
        Me.Ra1.Location = New System.Drawing.Point(147, 9)
        Me.Ra1.Name = "Ra1"
        Me.Ra1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Ra1.Size = New System.Drawing.Size(94, 19)
        Me.Ra1.TabIndex = 2
        Me.Ra1.TabStop = True
        Me.Ra1.Text = "فاتورة بيع معلقه"
        Me.Ra1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Ra1.UseVisualStyleBackColor = False
        '
        'Ra2
        '
        Me.Ra2.AutoSize = True
        Me.Ra2.BackColor = System.Drawing.Color.Transparent
        Me.Ra2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Ra2.ForeColor = System.Drawing.Color.Black
        Me.Ra2.Location = New System.Drawing.Point(9, 9)
        Me.Ra2.Name = "Ra2"
        Me.Ra2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Ra2.Size = New System.Drawing.Size(108, 19)
        Me.Ra2.TabIndex = 3
        Me.Ra2.Text = "فاتورة باركود معلقه"
        Me.Ra2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Ra2.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TexFIND)
        Me.Panel1.Controls.Add(Me.Ra2)
        Me.Panel1.Controls.Add(Me.Ra1)
        Me.Panel1.Location = New System.Drawing.Point(2, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(248, 67)
        Me.Panel1.TabIndex = 4
        '
        'Form_FATORAMALK0
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(253, 71)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_FATORAMALK0"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "بحث عن الفواتير المعلقه"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TexFIND As System.Windows.Forms.TextBox
    Friend WithEvents Ra1 As System.Windows.Forms.RadioButton
    Friend WithEvents Ra2 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As Panel
End Class
