<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loans3
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loans3))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TBNK6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBNK8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBNK23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBNK22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Co1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBNK11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TextTBNK1 = New System.Windows.Forms.TextBox()
        Me.TextTotalPayments = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlLightLight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.TBNK6, Me.TBNK8, Me.TBNK23, Me.TBNK22, Me.Co1, Me.TBNK11})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.Size = New System.Drawing.Size(775, 362)
        Me.DataGridView1.TabIndex = 981
        '
        'TBNK6
        '
        Me.TBNK6.DataPropertyName = "TBNK6"
        Me.TBNK6.HeaderText = "رقم الحساب"
        Me.TBNK6.Name = "TBNK6"
        Me.TBNK6.ReadOnly = True
        '
        'TBNK8
        '
        Me.TBNK8.DataPropertyName = "TBNK8"
        Me.TBNK8.HeaderText = "نوع الحساب"
        Me.TBNK8.Name = "TBNK8"
        Me.TBNK8.ReadOnly = True
        '
        'TBNK23
        '
        Me.TBNK23.DataPropertyName = "TBNK23"
        Me.TBNK23.HeaderText = "رقم العضو"
        Me.TBNK23.Name = "TBNK23"
        Me.TBNK23.ReadOnly = True
        '
        'TBNK22
        '
        Me.TBNK22.DataPropertyName = "TBNK22"
        Me.TBNK22.HeaderText = "اسم العضو"
        Me.TBNK22.Name = "TBNK22"
        Me.TBNK22.ReadOnly = True
        '
        'Co1
        '
        Me.Co1.DataPropertyName = "TBNK4"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Co1.DefaultCellStyle = DataGridViewCellStyle2
        Me.Co1.HeaderText = "الاقسط"
        Me.Co1.Name = "Co1"
        Me.Co1.ReadOnly = True
        '
        'TBNK11
        '
        Me.TBNK11.DataPropertyName = "TBNK11"
        Me.TBNK11.HeaderText = "رقم القيد"
        Me.TBNK11.Name = "TBNK11"
        Me.TBNK11.ReadOnly = True
        '
        'TextTBNK1
        '
        Me.TextTBNK1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTBNK1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTBNK1.Enabled = False
        Me.TextTBNK1.ForeColor = System.Drawing.Color.Black
        Me.TextTBNK1.Location = New System.Drawing.Point(625, 367)
        Me.TextTBNK1.Name = "TextTBNK1"
        Me.TextTBNK1.ReadOnly = True
        Me.TextTBNK1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextTBNK1.Size = New System.Drawing.Size(148, 20)
        Me.TextTBNK1.TabIndex = 982
        Me.TextTBNK1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextTotalPayments
        '
        Me.TextTotalPayments.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextTotalPayments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTotalPayments.Enabled = False
        Me.TextTotalPayments.ForeColor = System.Drawing.Color.Black
        Me.TextTotalPayments.Location = New System.Drawing.Point(0, 368)
        Me.TextTotalPayments.Name = "TextTotalPayments"
        Me.TextTotalPayments.ReadOnly = True
        Me.TextTotalPayments.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextTotalPayments.Size = New System.Drawing.Size(148, 20)
        Me.TextTotalPayments.TabIndex = 983
        Me.TextTotalPayments.Text = "0.000"
        Me.TextTotalPayments.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(154, 370)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 984
        Me.Label1.Text = "المجموع"
        '
        'Loans3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(775, 391)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextTotalPayments)
        Me.Controls.Add(Me.TextTBNK1)
        Me.Controls.Add(Me.DataGridView1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
<<<<<<< HEAD
        Me.MinimumSize = New System.Drawing.Size(791, 430)
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Name = "Loans3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "حسابات الاعضاء"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents TBNK6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TBNK8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TBNK23 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TBNK22 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Co1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TBNK11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TextTBNK1 As System.Windows.Forms.TextBox
    Friend WithEvents TextTotalPayments As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
