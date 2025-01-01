<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FinaBalances1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FinaBalances1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPInternalAuditor1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.PageSetup1 = New System.Windows.Forms.PageSetupDialog()
        Me.Ck1 = New System.Windows.Forms.CheckBox()
        Me.PrintPInternalAuditor = New System.Windows.Forms.Button()
        Me.PageSetup = New System.Windows.Forms.Button()
        Me.PrintDocument = New System.Windows.Forms.Button()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.RadInvoiceStatus = New System.Windows.Forms.RadioButton()
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.BackWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckedListBox1 = New System.Windows.Forms.CheckedListBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.noID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegistrationNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColDate = New DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn()
        Me.ErrorStatement = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Type1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ColUser = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel2.SuspendLayout()
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
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.noID, Me.IDNumber, Me.RegistrationNumber, Me.ColDate, Me.ErrorStatement, Me.Type1, Me.ColUser})
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1156, 483)
        Me.DataGridView1.TabIndex = 5
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'PrintDocument1
        '
        '
        'PrintPInternalAuditor1
        '
        Me.PrintPInternalAuditor1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPInternalAuditor1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPInternalAuditor1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPInternalAuditor1.Enabled = True
        Me.PrintPInternalAuditor1.Icon = CType(resources.GetObject("PrintPInternalAuditor1.Icon"), System.Drawing.Icon)
        Me.PrintPInternalAuditor1.Name = "PrintPInternalAuditor1"
        Me.PrintPInternalAuditor1.Visible = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "printer_search.png")
        Me.ImageList1.Images.SetKeyName(1, "printer.png")
        Me.ImageList1.Images.SetKeyName(2, "page_edit.png")
        '
        'Ck1
        '
        Me.Ck1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Ck1.AutoSize = True
        Me.Ck1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Ck1.Location = New System.Drawing.Point(560, 8)
        Me.Ck1.Name = "Ck1"
        Me.Ck1.Size = New System.Drawing.Size(84, 19)
        Me.Ck1.TabIndex = 6
        Me.Ck1.Text = "طباعة لليمين "
        Me.Ck1.UseVisualStyleBackColor = True
        '
        'PrintPInternalAuditor
        '
        Me.PrintPInternalAuditor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintPInternalAuditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PrintPInternalAuditor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PrintPInternalAuditor.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.PrintPInternalAuditor.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrintPInternalAuditor.Location = New System.Drawing.Point(660, 3)
        Me.PrintPInternalAuditor.Name = "PrintPInternalAuditor"
        Me.PrintPInternalAuditor.Size = New System.Drawing.Size(166, 30)
        Me.PrintPInternalAuditor.TabIndex = 5
        Me.PrintPInternalAuditor.Text = "Print PInternalAuditor"
        Me.PrintPInternalAuditor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PrintPInternalAuditor.UseVisualStyleBackColor = True
        '
        'PageSetup
        '
        Me.PageSetup.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PageSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PageSetup.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PageSetup.Image = CType(resources.GetObject("PageSetup.Image"), System.Drawing.Image)
        Me.PageSetup.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PageSetup.Location = New System.Drawing.Point(827, 3)
        Me.PageSetup.Name = "PageSetup"
        Me.PageSetup.Size = New System.Drawing.Size(166, 30)
        Me.PageSetup.TabIndex = 4
        Me.PageSetup.Text = "Page Setup"
        Me.PageSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PageSetup.UseVisualStyleBackColor = True
        '
        'PrintDocument
        '
        Me.PrintDocument.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintDocument.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PrintDocument.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PrintDocument.Image = CType(resources.GetObject("PrintDocument.Image"), System.Drawing.Image)
        Me.PrintDocument.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PrintDocument.Location = New System.Drawing.Point(994, 3)
        Me.PrintDocument.Name = "PrintDocument"
        Me.PrintDocument.Size = New System.Drawing.Size(166, 30)
        Me.PrintDocument.TabIndex = 2
        Me.PrintDocument.Text = "Print Document"
        Me.PrintDocument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PrintDocument.UseVisualStyleBackColor = True
        '
        'CircularProgress1
        '
        Me.CircularProgress1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(165, 2)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.SpringGreen
        Me.CircularProgress1.Size = New System.Drawing.Size(50, 31)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 981
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupControl1)
        Me.Panel1.Controls.Add(Me.PrintPInternalAuditor)
        Me.Panel1.Controls.Add(Me.CircularProgress1)
        Me.Panel1.Controls.Add(Me.PrintDocument)
        Me.Panel1.Controls.Add(Me.PageSetup)
        Me.Panel1.Controls.Add(Me.Ck1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 490)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1163, 37)
        Me.Panel1.TabIndex = 19
        '
        'GroupControl1
        '
        Me.GroupControl1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupControl1.Appearance.BackColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.BackColor2 = System.Drawing.Color.White
        Me.GroupControl1.Appearance.BorderColor = System.Drawing.Color.White
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.Appearance.Options.UseBorderColor = True
        Me.GroupControl1.AppearanceCaption.BorderColor = System.Drawing.Color.White
        Me.GroupControl1.AppearanceCaption.Options.UseBorderColor = True
        Me.GroupControl1.AutoSize = True
        Me.GroupControl1.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl1.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.RadInvoiceStatus)
        Me.GroupControl1.Enabled = False
        Me.GroupControl1.Location = New System.Drawing.Point(2, 6)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupControl1.Size = New System.Drawing.Size(161, 23)
        Me.GroupControl1.TabIndex = 990
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
        'BackWorker1
        '
        '
        'GroupBox4
        '
        Me.GroupBox4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox4.Controls.Add(Me.Panel2)
        Me.GroupBox4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(13, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(176, 483)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "حقول مجاميع "
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CheckedListBox1)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(170, 462)
        Me.Panel2.TabIndex = 982
        '
        'CheckedListBox1
        '
        Me.CheckedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CheckedListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CheckedListBox1.FormattingEnabled = True
        Me.CheckedListBox1.Location = New System.Drawing.Point(0, 17)
        Me.CheckedListBox1.Name = "CheckedListBox1"
        Me.CheckedListBox1.Size = New System.Drawing.Size(168, 443)
        Me.CheckedListBox1.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(168, 17)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "تستخدم هذه الحقول"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'noID
        '
        Me.noID.HeaderText = "الحســــاب"
        Me.noID.Name = "noID"
        Me.noID.ReadOnly = True
        '
        'IDNumber
        '
        Me.IDNumber.HeaderText = "الرقم"
        Me.IDNumber.Name = "IDNumber"
        Me.IDNumber.ReadOnly = True
        '
        'RegistrationNumber
        '
        Me.RegistrationNumber.HeaderText = "رقم القيد"
        Me.RegistrationNumber.Name = "RegistrationNumber"
        Me.RegistrationNumber.ReadOnly = True
        '
        'ColDate
        '
        '
        '
        '
        Me.ColDate.BackgroundStyle.Class = "DataGridViewDateTimeBorder"
        Me.ColDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.ColDate.DefaultCellStyle = DataGridViewCellStyle1
        Me.ColDate.HeaderText = "التاريخ"
        Me.ColDate.InputHorizontalAlignment = DevComponents.Editors.eHorizontalAlignment.Left
        '
        '
        '
        '
        '
        '
        Me.ColDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ColDate.MonthCalendar.CalendarDimensions = New System.Drawing.Size(1, 1)
        '
        '
        '
        Me.ColDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ColDate.MonthCalendar.DisplayMonth = New Date(2023, 8, 1, 0, 0, 0, 0)
        Me.ColDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Saturday
        '
        '
        '
        Me.ColDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.ColDate.Name = "ColDate"
        Me.ColDate.ReadOnly = True
        Me.ColDate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'ErrorStatement
        '
        Me.ErrorStatement.HeaderText = "بيـــــان الخطاء"
        Me.ErrorStatement.Name = "ErrorStatement"
        Me.ErrorStatement.ReadOnly = True
        '
        'Type1
        '
        Me.Type1.HeaderText = "مصدر الحركة"
        Me.Type1.Name = "Type1"
        Me.Type1.ReadOnly = True
        '
        'ColUser
        '
        Me.ColUser.HeaderText = "المستخدم"
        Me.ColUser.Name = "ColUser"
        Me.ColUser.ReadOnly = True
        '
        'FinaBalances1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1163, 527)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FinaBalances1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPInternalAuditor1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PageSetup1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents Ck1 As System.Windows.Forms.CheckBox
    Friend WithEvents PrintPInternalAuditor As System.Windows.Forms.Button
    Friend WithEvents PrintDocument As System.Windows.Forms.Button
    Friend WithEvents PageSetup As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents CheckedListBox1 As CheckedListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents RadInvoiceStatus As RadioButton
    Friend WithEvents noID As DataGridViewTextBoxColumn
    Friend WithEvents IDNumber As DataGridViewTextBoxColumn
    Friend WithEvents RegistrationNumber As DataGridViewTextBoxColumn
    Friend WithEvents ColDate As DevComponents.DotNetBar.Controls.DataGridViewDateTimeInputColumn
    Friend WithEvents ErrorStatement As DataGridViewTextBoxColumn
    Friend WithEvents Type1 As DataGridViewTextBoxColumn
    Friend WithEvents ColUser As DataGridViewTextBoxColumn
End Class
