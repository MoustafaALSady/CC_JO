<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loans2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loans2))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.loa1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lo25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.loa16 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.DateTO = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ComboInstallmentNumber = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TextCustomerNumber = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.ComboCustomerName = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextDebtNumber = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ButtonEnquiry = New System.Windows.Forms.Button()
        Me.ButtonDisplyAll = New System.Windows.Forms.Button()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.PicMovementRestrictions = New System.Windows.Forms.PictureBox()
        Me.TextMovementRestrictions = New System.Windows.Forms.TextBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.PicFundMovementNumber = New System.Windows.Forms.PictureBox()
        Me.TextFundMovementNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.PicMembershipNumber = New System.Windows.Forms.PictureBox()
        Me.MembershipNumber = New System.Windows.Forms.TextBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.InternalAuditorERBUTTON = New System.Windows.Forms.Button()
        Me.ButtonCancellationAuditingAndACheckingAccounts = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ButtonViewrestrictions = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.TextLSet = New System.Windows.Forms.TextBox()
        Me.TextLO25 = New System.Windows.Forms.TextBox()
        Me.Text1 = New System.Windows.Forms.TextBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicMovementRestrictions, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicFundMovementNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicMembershipNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.loa1, Me.lo, Me.loa, Me.lo25, Me.loa2, Me.loa3, Me.loa4, Me.loa5, Me.loa6, Me.loa16})
        Me.DataGridView1.Location = New System.Drawing.Point(4, 133)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.Size = New System.Drawing.Size(971, 304)
        Me.DataGridView1.TabIndex = 0
        '
        'loa1
        '
        Me.loa1.DataPropertyName = "loa1"
        Me.loa1.HeaderText = "loa1"
        Me.loa1.Name = "loa1"
        Me.loa1.ReadOnly = True
        Me.loa1.Visible = False
        '
        'lo
        '
        Me.lo.DataPropertyName = "lo"
        Me.lo.HeaderText = "رقم الدين"
        Me.lo.Name = "lo"
        Me.lo.ReadOnly = True
        '
        'loa
        '
        Me.loa.DataPropertyName = "loa"
        Me.loa.HeaderText = "رقم الاقسط"
        Me.loa.Name = "loa"
        Me.loa.ReadOnly = True
        '
        'lo25
        '
        Me.lo25.DataPropertyName = "lo25"
        Me.lo25.HeaderText = "رقم قيد الاقسط"
        Me.lo25.Name = "lo25"
        Me.lo25.ReadOnly = True
        '
        'loa2
        '
        Me.loa2.DataPropertyName = "loa2"
        Me.loa2.HeaderText = "تاريخ الاستحقاق"
        Me.loa2.Name = "loa2"
        Me.loa2.ReadOnly = True
        '
        'loa3
        '
        Me.loa3.DataPropertyName = "loa3"
        Me.loa3.HeaderText = "حالة السداد"
        Me.loa3.Name = "loa3"
        Me.loa3.ReadOnly = True
        '
        'loa4
        '
        Me.loa4.DataPropertyName = "loa4"
        Me.loa4.HeaderText = "رقم المستند"
        Me.loa4.Name = "loa4"
        Me.loa4.ReadOnly = True
        '
        'loa5
        '
        Me.loa5.DataPropertyName = "loa5"
        Me.loa5.HeaderText = "تاريخ الدفعة"
        Me.loa5.Name = "loa5"
        Me.loa5.ReadOnly = True
        '
        'loa6
        '
        Me.loa6.DataPropertyName = "loa6"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.SteelBlue
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.White
        Me.loa6.DefaultCellStyle = DataGridViewCellStyle1
        Me.loa6.HeaderText = "قيمة الدفعة"
        Me.loa6.Name = "loa6"
        Me.loa6.ReadOnly = True
        '
        'loa16
        '
        Me.loa16.DataPropertyName = "loa16"
        Me.loa16.HeaderText = "مراجع"
        Me.loa16.Name = "loa16"
        Me.loa16.ReadOnly = True
        Me.loa16.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.loa16.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'DateFrom
        '
        Me.DateFrom.CalendarForeColor = System.Drawing.Color.Black
        Me.DateFrom.CalendarMonthBackground = System.Drawing.Color.Pink
        Me.DateFrom.CalendarTitleBackColor = System.Drawing.Color.Pink
        Me.DateFrom.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.DateFrom.CalendarTrailingForeColor = System.Drawing.Color.Black
        Me.DateFrom.Checked = False
        Me.DateFrom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DateFrom.CustomFormat = "dd/MM/yyyy"
        Me.DateFrom.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFrom.Location = New System.Drawing.Point(365, 23)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.RightToLeftLayout = True
        Me.DateFrom.Size = New System.Drawing.Size(170, 22)
        Me.DateFrom.TabIndex = 191
        '
        'DateTO
        '
        Me.DateTO.CalendarForeColor = System.Drawing.Color.Black
        Me.DateTO.CalendarMonthBackground = System.Drawing.Color.Pink
        Me.DateTO.CalendarTitleBackColor = System.Drawing.Color.Pink
        Me.DateTO.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.DateTO.CalendarTrailingForeColor = System.Drawing.Color.Black
        Me.DateTO.Checked = False
        Me.DateTO.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DateTO.CustomFormat = "dd/MM/yyyy"
        Me.DateTO.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTO.Location = New System.Drawing.Point(107, 21)
        Me.DateTO.Name = "DateTO"
        Me.DateTO.RightToLeftLayout = True
        Me.DateTO.Size = New System.Drawing.Size(146, 22)
        Me.DateTO.TabIndex = 192
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton3)
        Me.GroupBox1.Controls.Add(Me.RadioButton4)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.DateTO)
        Me.GroupBox1.Controls.Add(Me.DateFrom)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.ComboInstallmentNumber)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.TextCustomerNumber)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.ComboCustomerName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.TextDebtNumber)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(376, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(588, 114)
        Me.GroupBox1.TabIndex = 451
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "استعلام عن"
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(16, 33)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(64, 19)
        Me.RadioButton2.TabIndex = 643
        Me.RadioButton2.Text = "رقم الدين"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New System.Drawing.Point(13, 58)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(67, 19)
        Me.RadioButton3.TabIndex = 642
        Me.RadioButton3.Text = "رقم الدفعة"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton4.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.Black
        Me.RadioButton4.Location = New System.Drawing.Point(25, 83)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(55, 19)
        Me.RadioButton4.TabIndex = 641
        Me.RadioButton4.Text = "مرااجع"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(28, 11)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(52, 20)
        Me.RadioButton1.TabIndex = 640
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "العميل"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(44, 206)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 15)
        Me.Label8.TabIndex = 639
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(256, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(53, 15)
        Me.Label16.TabIndex = 518
        Me.Label16.Text = "رقم الاقسط"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboInstallmentNumber
        '
        Me.ComboInstallmentNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboInstallmentNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboInstallmentNumber.Location = New System.Drawing.Point(107, 45)
        Me.ComboInstallmentNumber.Name = "ComboInstallmentNumber"
        Me.ComboInstallmentNumber.Size = New System.Drawing.Size(146, 23)
        Me.ComboInstallmentNumber.TabIndex = 517
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Black
        Me.Label15.Location = New System.Drawing.Point(536, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 15)
        Me.Label15.TabIndex = 516
        Me.Label15.Text = "رقم الدين"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextCustomerNumber
        '
        Me.TextCustomerNumber.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextCustomerNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCustomerNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TextCustomerNumber.Enabled = False
        Me.TextCustomerNumber.Font = New System.Drawing.Font("Times New Roman", 9.85!, System.Drawing.FontStyle.Bold)
        Me.TextCustomerNumber.ForeColor = System.Drawing.Color.Black
        Me.TextCustomerNumber.Location = New System.Drawing.Point(107, 71)
        Me.TextCustomerNumber.Name = "TextCustomerNumber"
        Me.TextCustomerNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextCustomerNumber.Size = New System.Drawing.Size(146, 23)
        Me.TextCustomerNumber.TabIndex = 463
        Me.TextCustomerNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(536, 76)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(36, 15)
        Me.Label12.TabIndex = 515
        Me.Label12.Text = " العميل"
        '
        'ComboCustomerName
        '
        Me.ComboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCustomerName.Cursor = System.Windows.Forms.Cursors.Default
        Me.ComboCustomerName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboCustomerName.ForeColor = System.Drawing.Color.Black
        Me.ComboCustomerName.Location = New System.Drawing.Point(255, 71)
        Me.ComboCustomerName.Name = "ComboCustomerName"
        Me.ComboCustomerName.Size = New System.Drawing.Size(280, 23)
        Me.ComboCustomerName.TabIndex = 514
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(256, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 190
        Me.Label1.Text = "الى"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(538, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 15)
        Me.Label2.TabIndex = 189
        Me.Label2.Text = "من"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextDebtNumber
        '
        Me.TextDebtNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDebtNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TextDebtNumber.Location = New System.Drawing.Point(365, 47)
        Me.TextDebtNumber.Name = "TextDebtNumber"
        Me.TextDebtNumber.Size = New System.Drawing.Size(170, 23)
        Me.TextDebtNumber.TabIndex = 438
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.BackgroundImage = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(3, -1)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 662
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'ButtonEnquiry
        '
        Me.ButtonEnquiry.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonEnquiry.BackColor = System.Drawing.Color.Transparent
        Me.ButtonEnquiry.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonEnquiry.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEnquiry.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonEnquiry.Image = Global.CC_JO.My.Resources.Resources.PInternalAuditor_16x16
        Me.ButtonEnquiry.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonEnquiry.Location = New System.Drawing.Point(844, 4)
        Me.ButtonEnquiry.Name = "ButtonEnquiry"
        Me.ButtonEnquiry.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonEnquiry.Size = New System.Drawing.Size(130, 28)
        Me.ButtonEnquiry.TabIndex = 634
        Me.ButtonEnquiry.Text = "أستعلام"
        Me.ButtonEnquiry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonEnquiry.UseVisualStyleBackColor = False
        '
        'ButtonDisplyAll
        '
        Me.ButtonDisplyAll.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonDisplyAll.BackColor = System.Drawing.Color.Transparent
        Me.ButtonDisplyAll.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonDisplyAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonDisplyAll.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonDisplyAll.Image = Global.CC_JO.My.Resources.Resources.Pivot_16x16
        Me.ButtonDisplyAll.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonDisplyAll.Location = New System.Drawing.Point(713, 4)
        Me.ButtonDisplyAll.Name = "ButtonDisplyAll"
        Me.ButtonDisplyAll.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonDisplyAll.Size = New System.Drawing.Size(130, 28)
        Me.ButtonDisplyAll.TabIndex = 663
        Me.ButtonDisplyAll.Text = "عرض الكل"
        Me.ButtonDisplyAll.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonDisplyAll.UseVisualStyleBackColor = False
        '
        'Label28
        '
        Me.Label28.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label28.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.Black
        Me.Label28.Location = New System.Drawing.Point(274, 7)
        Me.Label28.Name = "Label28"
        Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label28.Size = New System.Drawing.Size(78, 15)
        Me.Label28.TabIndex = 945
        Me.Label28.Text = "رقم  حركة القيود"
        '
        'PicMovementRestrictions
        '
        Me.PicMovementRestrictions.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicMovementRestrictions.BackColor = System.Drawing.Color.Transparent
        Me.PicMovementRestrictions.BackgroundImage = Global.CC_JO.My.Resources.Resources.selection_view
        Me.PicMovementRestrictions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicMovementRestrictions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicMovementRestrictions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicMovementRestrictions.InitialImage = Nothing
        Me.PicMovementRestrictions.Location = New System.Drawing.Point(229, 5)
        Me.PicMovementRestrictions.Name = "PicMovementRestrictions"
        Me.PicMovementRestrictions.Size = New System.Drawing.Size(26, 22)
        Me.PicMovementRestrictions.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicMovementRestrictions.TabIndex = 961
        Me.PicMovementRestrictions.TabStop = False
        '
        'TextMovementRestrictions
        '
        Me.TextMovementRestrictions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextMovementRestrictions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextMovementRestrictions.Enabled = False
        Me.TextMovementRestrictions.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextMovementRestrictions.ForeColor = System.Drawing.Color.Black
        Me.TextMovementRestrictions.Location = New System.Drawing.Point(4, 5)
        Me.TextMovementRestrictions.Name = "TextMovementRestrictions"
        Me.TextMovementRestrictions.ReadOnly = True
        Me.TextMovementRestrictions.Size = New System.Drawing.Size(224, 22)
        Me.TextMovementRestrictions.TabIndex = 799
        Me.TextMovementRestrictions.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label31
        '
        Me.Label31.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.ForeColor = System.Drawing.Color.Black
        Me.Label31.Location = New System.Drawing.Point(263, 31)
        Me.Label31.Name = "Label31"
        Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label31.Size = New System.Drawing.Size(89, 15)
        Me.Label31.TabIndex = 943
        Me.Label31.Text = "رقم حركة الصندوق"
        '
        'PicFundMovementNumber
        '
        Me.PicFundMovementNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicFundMovementNumber.BackColor = System.Drawing.Color.Transparent
        Me.PicFundMovementNumber.BackgroundImage = Global.CC_JO.My.Resources.Resources.selection_view
        Me.PicFundMovementNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicFundMovementNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicFundMovementNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicFundMovementNumber.InitialImage = Nothing
        Me.PicFundMovementNumber.Location = New System.Drawing.Point(229, 27)
        Me.PicFundMovementNumber.Name = "PicFundMovementNumber"
        Me.PicFundMovementNumber.Size = New System.Drawing.Size(26, 22)
        Me.PicFundMovementNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicFundMovementNumber.TabIndex = 962
        Me.PicFundMovementNumber.TabStop = False
        '
        'TextFundMovementNumber
        '
        Me.TextFundMovementNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextFundMovementNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFundMovementNumber.Enabled = False
        Me.TextFundMovementNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextFundMovementNumber.ForeColor = System.Drawing.Color.Black
        Me.TextFundMovementNumber.Location = New System.Drawing.Point(4, 27)
        Me.TextFundMovementNumber.Name = "TextFundMovementNumber"
        Me.TextFundMovementNumber.ReadOnly = True
        Me.TextFundMovementNumber.Size = New System.Drawing.Size(224, 22)
        Me.TextFundMovementNumber.TabIndex = 805
        Me.TextFundMovementNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(266, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 963
        Me.Label3.Text = "رقم حركة الاعضاء"
        '
        'PicMembershipNumber
        '
        Me.PicMembershipNumber.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PicMembershipNumber.BackColor = System.Drawing.Color.Transparent
        Me.PicMembershipNumber.BackgroundImage = Global.CC_JO.My.Resources.Resources.selection_view
        Me.PicMembershipNumber.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PicMembershipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PicMembershipNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicMembershipNumber.InitialImage = Nothing
        Me.PicMembershipNumber.Location = New System.Drawing.Point(229, 50)
        Me.PicMembershipNumber.Name = "PicMembershipNumber"
        Me.PicMembershipNumber.Size = New System.Drawing.Size(26, 22)
        Me.PicMembershipNumber.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PicMembershipNumber.TabIndex = 964
        Me.PicMembershipNumber.TabStop = False
        '
        'MembershipNumber
        '
        Me.MembershipNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MembershipNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MembershipNumber.Enabled = False
        Me.MembershipNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.MembershipNumber.ForeColor = System.Drawing.Color.Black
        Me.MembershipNumber.Location = New System.Drawing.Point(4, 50)
        Me.MembershipNumber.Name = "MembershipNumber"
        Me.MembershipNumber.ReadOnly = True
        Me.MembershipNumber.Size = New System.Drawing.Size(224, 22)
        Me.MembershipNumber.TabIndex = 948
        Me.MembershipNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox3.Enabled = False
        Me.CheckBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CheckBox3.Location = New System.Drawing.Point(30, 16)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox3.Size = New System.Drawing.Size(120, 19)
        Me.CheckBox3.TabIndex = 947
        Me.CheckBox3.Text = "تمت مراجعة هذا السجل"
        Me.CheckBox3.UseVisualStyleBackColor = False
        '
        'InternalAuditorERBUTTON
        '
        Me.InternalAuditorERBUTTON.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InternalAuditorERBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.InternalAuditorERBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InternalAuditorERBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InternalAuditorERBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.InternalAuditorERBUTTON.Image = Global.CC_JO.My.Resources.Resources.Apply_16x16
        Me.InternalAuditorERBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InternalAuditorERBUTTON.Location = New System.Drawing.Point(450, 4)
        Me.InternalAuditorERBUTTON.Name = "InternalAuditorERBUTTON"
        Me.InternalAuditorERBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.InternalAuditorERBUTTON.Size = New System.Drawing.Size(262, 28)
        Me.InternalAuditorERBUTTON.TabIndex = 945
        Me.InternalAuditorERBUTTON.Text = "مـراجــــــــــعـة و تدقيــــق الحســــــابـات F7"
        Me.InternalAuditorERBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InternalAuditorERBUTTON.UseVisualStyleBackColor = False
        '
        'ButtonCancellationAuditingAndACheckingAccounts
        '
        Me.ButtonCancellationAuditingAndACheckingAccounts.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonCancellationAuditingAndACheckingAccounts.BackColor = System.Drawing.Color.Transparent
        Me.ButtonCancellationAuditingAndACheckingAccounts.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonCancellationAuditingAndACheckingAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonCancellationAuditingAndACheckingAccounts.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonCancellationAuditingAndACheckingAccounts.Image = Global.CC_JO.My.Resources.Resources.HistoryItem_16x16
        Me.ButtonCancellationAuditingAndACheckingAccounts.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonCancellationAuditingAndACheckingAccounts.Location = New System.Drawing.Point(190, 4)
        Me.ButtonCancellationAuditingAndACheckingAccounts.Name = "ButtonCancellationAuditingAndACheckingAccounts"
        Me.ButtonCancellationAuditingAndACheckingAccounts.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonCancellationAuditingAndACheckingAccounts.Size = New System.Drawing.Size(259, 28)
        Me.ButtonCancellationAuditingAndACheckingAccounts.TabIndex = 944
        Me.ButtonCancellationAuditingAndACheckingAccounts.Text = "الغاء مـراجــــــــــعـة و تدقيق الحسابات F8"
        Me.ButtonCancellationAuditingAndACheckingAccounts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonCancellationAuditingAndACheckingAccounts.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(971, 123)
        Me.Panel1.TabIndex = 948
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ButtonViewrestrictions)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.TextMovementRestrictions)
        Me.Panel2.Controls.Add(Me.PicMovementRestrictions)
        Me.Panel2.Controls.Add(Me.MembershipNumber)
        Me.Panel2.Controls.Add(Me.PicMembershipNumber)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.PicFundMovementNumber)
        Me.Panel2.Controls.Add(Me.TextFundMovementNumber)
        Me.Panel2.Location = New System.Drawing.Point(3, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(367, 109)
        Me.Panel2.TabIndex = 949
        '
        'ButtonViewrestrictions
        '
        Me.ButtonViewrestrictions.AutoSize = True
        Me.ButtonViewrestrictions.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonViewrestrictions.BackgroundImage = Global.CC_JO.My.Resources.Resources.Synchronize
        Me.ButtonViewrestrictions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ButtonViewrestrictions.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonViewrestrictions.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ButtonViewrestrictions.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonViewrestrictions.FlatAppearance.BorderSize = 2
        Me.ButtonViewrestrictions.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ButtonViewrestrictions.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Navy
        Me.ButtonViewrestrictions.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonViewrestrictions.ForeColor = System.Drawing.Color.Ivory
        Me.ButtonViewrestrictions.Location = New System.Drawing.Point(0, 75)
        Me.ButtonViewrestrictions.Name = "ButtonViewrestrictions"
        Me.ButtonViewrestrictions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ButtonViewrestrictions.Size = New System.Drawing.Size(365, 32)
        Me.ButtonViewrestrictions.TabIndex = 980
        Me.ButtonViewrestrictions.UseVisualStyleBackColor = False
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CheckBox3)
        Me.Panel3.Controls.Add(Me.CheckBox2)
        Me.Panel3.Controls.Add(Me.ButtonCancellationAuditingAndACheckingAccounts)
        Me.Panel3.Controls.Add(Me.InternalAuditorERBUTTON)
        Me.Panel3.Controls.Add(Me.ButtonDisplyAll)
        Me.Panel3.Controls.Add(Me.TextLSet)
        Me.Panel3.Controls.Add(Me.TextLO25)
        Me.Panel3.Controls.Add(Me.Text1)
        Me.Panel3.Controls.Add(Me.ButtonEnquiry)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Location = New System.Drawing.Point(0, 443)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(978, 38)
        Me.Panel3.TabIndex = 949
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.BackColor = System.Drawing.Color.Transparent
        Me.CheckBox2.Enabled = False
        Me.CheckBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckBox2.ForeColor = System.Drawing.Color.Blue
        Me.CheckBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox2.Location = New System.Drawing.Point(99, -1)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckBox2.Size = New System.Drawing.Size(53, 19)
        Me.CheckBox2.TabIndex = 948
        Me.CheckBox2.Text = "ترحيل"
        Me.CheckBox2.UseVisualStyleBackColor = False
        '
        'TextLSet
        '
        Me.TextLSet.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLSet.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextLSet.Location = New System.Drawing.Point(90, 4)
        Me.TextLSet.Name = "TextLSet"
        Me.TextLSet.Size = New System.Drawing.Size(22, 22)
        Me.TextLSet.TabIndex = 950
        Me.TextLSet.Visible = False
        '
        'TextLO25
        '
        Me.TextLO25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLO25.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextLO25.Location = New System.Drawing.Point(59, 27)
        Me.TextLO25.Name = "TextLO25"
        Me.TextLO25.Size = New System.Drawing.Size(37, 22)
        Me.TextLO25.TabIndex = 949
        Me.TextLO25.Visible = False
        '
        'Text1
        '
        Me.Text1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Text1.Location = New System.Drawing.Point(45, -1)
        Me.Text1.Name = "Text1"
        Me.Text1.Size = New System.Drawing.Size(37, 22)
        Me.Text1.TabIndex = 644
        Me.Text1.Visible = False
        '
        'Loans2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(978, 481)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(994, 520)
        Me.Name = "Loans2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مراجعة الاقساط"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicMovementRestrictions, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicFundMovementNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicMembershipNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ButtonEnquiry As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ComboInstallmentNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TextCustomerNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ComboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextDebtNumber As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents ButtonDisplyAll As System.Windows.Forms.Button
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents PicMovementRestrictions As System.Windows.Forms.PictureBox
    Friend WithEvents TextMovementRestrictions As System.Windows.Forms.TextBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents PicFundMovementNumber As System.Windows.Forms.PictureBox
    Friend WithEvents TextFundMovementNumber As System.Windows.Forms.TextBox
    Friend WithEvents InternalAuditorERBUTTON As System.Windows.Forms.Button
    Friend WithEvents ButtonCancellationAuditingAndACheckingAccounts As System.Windows.Forms.Button
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PicMembershipNumber As System.Windows.Forms.PictureBox
    Friend WithEvents MembershipNumber As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Text1 As System.Windows.Forms.TextBox
    Friend WithEvents ButtonViewrestrictions As System.Windows.Forms.Button
    Friend WithEvents TextLO25 As System.Windows.Forms.TextBox
    Friend WithEvents TextLSet As System.Windows.Forms.TextBox
    Friend WithEvents loa1 As DataGridViewTextBoxColumn
    Friend WithEvents lo As DataGridViewTextBoxColumn
    Friend WithEvents loa As DataGridViewTextBoxColumn
    Friend WithEvents lo25 As DataGridViewTextBoxColumn
    Friend WithEvents loa2 As DataGridViewTextBoxColumn
    Friend WithEvents loa3 As DataGridViewTextBoxColumn
    Friend WithEvents loa4 As DataGridViewTextBoxColumn
    Friend WithEvents loa5 As DataGridViewTextBoxColumn
    Friend WithEvents loa6 As DataGridViewTextBoxColumn
    Friend WithEvents loa16 As DataGridViewCheckBoxColumn
End Class
