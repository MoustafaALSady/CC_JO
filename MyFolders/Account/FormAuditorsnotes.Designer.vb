<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAuditorsnotes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAuditorsnotes))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AN1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AN2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AN3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AN4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AN5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UserNameT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RadInvoiceStatus = New System.Windows.Forms.RadioButton()
        Me.ListAconet = New System.Windows.Forms.ListBox()
        Me.TextXx = New System.Windows.Forms.TextBox()
        Me.TextAconet = New System.Windows.Forms.TextBox()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AN, Me.AN1, Me.AN2, Me.AN3, Me.AN4, Me.AN5, Me.UserNameT})
        Me.DataGridView1.Location = New System.Drawing.Point(6, 39)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(961, 327)
        Me.DataGridView1.TabIndex = 6
        '
        'AN
        '
        Me.AN.DataPropertyName = "AN"
        Me.AN.HeaderText = "AN"
        Me.AN.Name = "AN"
        Me.AN.ReadOnly = True
        Me.AN.Visible = False
        '
        'AN1
        '
        Me.AN1.DataPropertyName = "AN1"
        Me.AN1.FillWeight = 65.0!
        Me.AN1.HeaderText = "الرقم"
        Me.AN1.Name = "AN1"
        Me.AN1.ReadOnly = True
        '
        'AN2
        '
        Me.AN2.DataPropertyName = "AN2"
        Me.AN2.FillWeight = 85.0!
        Me.AN2.HeaderText = "رمز القيد"
        Me.AN2.Name = "AN2"
        Me.AN2.ReadOnly = True
        '
        'AN3
        '
        Me.AN3.DataPropertyName = "AN3"
        Me.AN3.FillWeight = 80.0!
        Me.AN3.HeaderText = "التاريخ"
        Me.AN3.Name = "AN3"
        Me.AN3.ReadOnly = True
        '
        'AN4
        '
        Me.AN4.DataPropertyName = "AN4"
        Me.AN4.FillWeight = 220.0!
        Me.AN4.HeaderText = "ملاحظات مدقق الحسابات"
        Me.AN4.Name = "AN4"
        Me.AN4.ReadOnly = True
        '
        'AN5
        '
        Me.AN5.DataPropertyName = "AN5"
        Me.AN5.FillWeight = 140.0!
        Me.AN5.HeaderText = "مصدر الحركة"
        Me.AN5.Name = "AN5"
        Me.AN5.ReadOnly = True
        '
        'UserNameT
        '
        Me.UserNameT.DataPropertyName = "USERNAME"
        Me.UserNameT.FillWeight = 80.0!
        Me.UserNameT.HeaderText = "المستخدم"
        Me.UserNameT.Name = "UserNameT"
        Me.UserNameT.ReadOnly = True
        '
        'RadInvoiceStatus
        '
        Me.RadInvoiceStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadInvoiceStatus.AutoSize = True
        Me.RadInvoiceStatus.BackColor = System.Drawing.Color.Transparent
        Me.RadInvoiceStatus.Enabled = False
        Me.RadInvoiceStatus.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadInvoiceStatus.ForeColor = System.Drawing.Color.Maroon
        Me.RadInvoiceStatus.Location = New System.Drawing.Point(31, 1)
        Me.RadInvoiceStatus.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RadInvoiceStatus.Name = "RadInvoiceStatus"
        Me.RadInvoiceStatus.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RadInvoiceStatus.Size = New System.Drawing.Size(123, 19)
        Me.RadInvoiceStatus.TabIndex = 981
        Me.RadInvoiceStatus.Text = "حالة الفاتورة نقدا / اجل"
        Me.RadInvoiceStatus.UseVisualStyleBackColor = False
        '
        'ListAconet
        '
        Me.ListAconet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListAconet.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ListAconet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ListAconet.FormattingEnabled = True
        Me.ListAconet.ItemHeight = 15
        Me.ListAconet.Location = New System.Drawing.Point(726, 243)
        Me.ListAconet.Name = "ListAconet"
        Me.ListAconet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ListAconet.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        Me.ListAconet.Size = New System.Drawing.Size(86, 62)
        Me.ListAconet.Sorted = True
        Me.ListAconet.TabIndex = 982
        '
        'TextXx
        '
        Me.TextXx.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextXx.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TextXx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextXx.Location = New System.Drawing.Point(825, 243)
        Me.TextXx.Multiline = True
        Me.TextXx.Name = "TextXx"
        Me.TextXx.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextXx.Size = New System.Drawing.Size(31, 83)
        Me.TextXx.TabIndex = 983
        '
        'TextAconet
        '
        Me.TextAconet.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextAconet.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.TextAconet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAconet.Location = New System.Drawing.Point(862, 243)
        Me.TextAconet.Multiline = True
        Me.TextAconet.Name = "TextAconet"
        Me.TextAconet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextAconet.Size = New System.Drawing.Size(42, 83)
        Me.TextAconet.TabIndex = 988
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.BackColor2 = System.Drawing.Color.White
        Me.GroupControl1.Appearance.BorderColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.Appearance.Options.UseBorderColor = True
        Me.GroupControl1.AppearanceCaption.BackColor = System.Drawing.Color.White
        Me.GroupControl1.AppearanceCaption.BackColor2 = System.Drawing.Color.White
        Me.GroupControl1.AppearanceCaption.BorderColor = System.Drawing.Color.White
        Me.GroupControl1.AppearanceCaption.Options.UseBackColor = True
        Me.GroupControl1.AppearanceCaption.Options.UseBorderColor = True
        Me.GroupControl1.AutoSize = True
        Me.GroupControl1.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl1.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.RadInvoiceStatus)
        Me.GroupControl1.Enabled = False
        Me.GroupControl1.Location = New System.Drawing.Point(806, 369)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(161, 23)
        Me.GroupControl1.TabIndex = 989
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(973, 38)
        Me.Panel4.TabIndex = 1034
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Traditional Arabic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = Global.CC_JO.My.Resources.Resources.BOResume_32x32
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(971, 35)
        Me.Label7.TabIndex = 1008
        Me.Label7.Text = "ملاحظات مدقق الحسابات"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormAuditorsnotes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(973, 394)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.GroupControl1)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ListAconet)
        Me.Controls.Add(Me.TextAconet)
        Me.Controls.Add(Me.TextXx)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(700, 300)
        Me.Name = "FormAuditorsnotes"
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ملاحظات مدقق الحسابات"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RadInvoiceStatus As System.Windows.Forms.RadioButton
    Friend WithEvents TextXx As System.Windows.Forms.TextBox
    Private WithEvents ListAconet As ListBox
    Friend WithEvents TextAconet As TextBox
    Friend WithEvents RadioGroup1 As DevExpress.XtraEditors.RadioGroup
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents AN As DataGridViewTextBoxColumn
    Friend WithEvents AN1 As DataGridViewTextBoxColumn
    Friend WithEvents AN2 As DataGridViewTextBoxColumn
    Friend WithEvents AN3 As DataGridViewTextBoxColumn
    Friend WithEvents AN4 As DataGridViewTextBoxColumn
    Friend WithEvents AN5 As DataGridViewTextBoxColumn
    Friend WithEvents UserNameT As DataGridViewTextBoxColumn
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
End Class
