<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_ALL_ACC
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_ALL_ACC))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.BTN_CANCEL = New System.Windows.Forms.Button()
        Me.BTN_OK = New System.Windows.Forms.Button()
        Me.BTN_NEW = New System.Windows.Forms.Button()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.COL_NUM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.COL_GUID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.account_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.account_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ACC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TXT_SEARCH = New System.Windows.Forms.TextBox()
        Me.LBL_TITLE = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.DGV)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Controls.Add(Me.LBL_TITLE)
        Me.Panel2.Location = New System.Drawing.Point(2, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(370, 571)
        Me.Panel2.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.BTN_CANCEL)
        Me.Panel1.Controls.Add(Me.BTN_OK)
        Me.Panel1.Controls.Add(Me.BTN_NEW)
        Me.Panel1.Location = New System.Drawing.Point(3, 527)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(363, 38)
        Me.Panel1.TabIndex = 7
        '
        'BTN_CANCEL
        '
        Me.BTN_CANCEL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_CANCEL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_CANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_CANCEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BTN_CANCEL.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.BTN_CANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_CANCEL.Location = New System.Drawing.Point(1, 2)
        Me.BTN_CANCEL.Name = "BTN_CANCEL"
        Me.BTN_CANCEL.Size = New System.Drawing.Size(117, 32)
        Me.BTN_CANCEL.TabIndex = 4
        Me.BTN_CANCEL.Text = "الغاء"
        Me.BTN_CANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_CANCEL.UseVisualStyleBackColor = True
        '
        'BTN_OK
        '
        Me.BTN_OK.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_OK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_OK.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BTN_OK.Image = Global.CC_JO.My.Resources.Resources.accept
        Me.BTN_OK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_OK.Location = New System.Drawing.Point(240, 2)
        Me.BTN_OK.Name = "BTN_OK"
        Me.BTN_OK.Size = New System.Drawing.Size(120, 32)
        Me.BTN_OK.TabIndex = 2
        Me.BTN_OK.Text = "موافق"
        Me.BTN_OK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_OK.UseVisualStyleBackColor = True
        '
        'BTN_NEW
        '
        Me.BTN_NEW.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_NEW.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTN_NEW.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_NEW.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BTN_NEW.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.BTN_NEW.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BTN_NEW.Location = New System.Drawing.Point(119, 2)
        Me.BTN_NEW.Name = "BTN_NEW"
        Me.BTN_NEW.Size = New System.Drawing.Size(120, 32)
        Me.BTN_NEW.TabIndex = 3
        Me.BTN_NEW.Text = "جديد"
        Me.BTN_NEW.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BTN_NEW.UseVisualStyleBackColor = True
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.AllowUserToResizeColumns = False
        Me.DGV.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DGV.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DGV.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DGV.ColumnHeadersHeight = 30
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DGV.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.COL_NUM, Me.COL_GUID, Me.account_name, Me.account_no, Me.ACC})
        Me.DGV.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DGV.EnableHeadersVisualStyles = False
        Me.DGV.Location = New System.Drawing.Point(3, 29)
        Me.DGV.MultiSelect = False
        Me.DGV.Name = "DGV"
        Me.DGV.ReadOnly = True
        Me.DGV.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DGV.RowHeadersVisible = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DGV.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DGV.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGV.Size = New System.Drawing.Size(363, 435)
        Me.DGV.TabIndex = 13
        '
        'COL_NUM
        '
        Me.COL_NUM.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.COL_NUM.DefaultCellStyle = DataGridViewCellStyle3
        Me.COL_NUM.FillWeight = 40.0!
        Me.COL_NUM.Frozen = True
        Me.COL_NUM.HeaderText = "*"
        Me.COL_NUM.Name = "COL_NUM"
        Me.COL_NUM.ReadOnly = True
        Me.COL_NUM.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COL_NUM.Width = 40
        '
        'COL_GUID
        '
        Me.COL_GUID.FillWeight = 119.5432!
        Me.COL_GUID.HeaderText = "COL_GUID"
        Me.COL_GUID.Name = "COL_GUID"
        Me.COL_GUID.ReadOnly = True
        Me.COL_GUID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.COL_GUID.Visible = False
        '
        'account_name
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.account_name.DefaultCellStyle = DataGridViewCellStyle4
        Me.account_name.FillWeight = 135.6413!
        Me.account_name.HeaderText = "الحساب"
        Me.account_name.Name = "account_name"
        Me.account_name.ReadOnly = True
        Me.account_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'account_no
        '
        Me.account_no.HeaderText = "رقم الحساب"
        Me.account_no.Name = "account_no"
        Me.account_no.ReadOnly = True
        Me.account_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.account_no.Visible = False
        '
        'ACC
        '
        Me.ACC.FillWeight = 50.0!
        Me.ACC.HeaderText = "ACC"
        Me.ACC.Name = "ACC"
        Me.ACC.ReadOnly = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Location = New System.Drawing.Point(3, 470)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(363, 52)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "البحث "
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TXT_SEARCH)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(357, 31)
        Me.Panel3.TabIndex = 8
        '
        'TXT_SEARCH
        '
        Me.TXT_SEARCH.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TXT_SEARCH.Location = New System.Drawing.Point(3, 3)
        Me.TXT_SEARCH.Name = "TXT_SEARCH"
        Me.TXT_SEARCH.Size = New System.Drawing.Size(348, 22)
        Me.TXT_SEARCH.TabIndex = 6
        '
        'LBL_TITLE
        '
        Me.LBL_TITLE.BackColor = System.Drawing.Color.SteelBlue
        Me.LBL_TITLE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LBL_TITLE.Dock = System.Windows.Forms.DockStyle.Top
        Me.LBL_TITLE.Font = New System.Drawing.Font("Traditional Arabic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LBL_TITLE.ForeColor = System.Drawing.Color.White
        Me.LBL_TITLE.Location = New System.Drawing.Point(0, 0)
        Me.LBL_TITLE.Name = "LBL_TITLE"
        Me.LBL_TITLE.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LBL_TITLE.Size = New System.Drawing.Size(368, 26)
        Me.LBL_TITLE.TabIndex = 2
        Me.LBL_TITLE.Text = "قائمة الحسابات"
        '
        'FRM_ALL_ACC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(375, 577)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(391, 500)
        Me.Name = "FRM_ALL_ACC"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DGV As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TXT_SEARCH As System.Windows.Forms.TextBox
    Friend WithEvents LBL_TITLE As System.Windows.Forms.Label
    Friend WithEvents BTN_OK As System.Windows.Forms.Button
    Friend WithEvents BTN_NEW As System.Windows.Forms.Button
    Friend WithEvents BTN_CANCEL As System.Windows.Forms.Button
    Friend WithEvents COL_NUM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents COL_GUID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents account_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents account_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
End Class
