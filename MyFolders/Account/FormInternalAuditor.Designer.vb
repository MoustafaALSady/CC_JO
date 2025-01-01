<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInternalAuditor
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInternalAuditor))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TextNumberOfAssociationsSent = New System.Windows.Forms.TextBox()
        Me.TextAssociationName = New System.Windows.Forms.TextBox()
        Me.TextAssociationNationalNumber = New System.Windows.Forms.TextBox()
        Me.TextFiscalYear = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New DevComponents.DotNetBar.Controls.DataGridViewX()
        Me.AB1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AB3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AB2 = New DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButtonRefusal = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonApproval = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonViewDocuments = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAttachDocument = New DevExpress.XtraEditors.SimpleButton()
        Me.TextNumberOfCompletedAssociations = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ComboAssociationName = New System.Windows.Forms.ComboBox()
        Me.ButtonEnquiry = New DevExpress.XtraEditors.SimpleButton()
        Me.TextCondition = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextReasonsForRejectingBudgetFromExternalAuditor = New System.Windows.Forms.TextBox()
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment = New System.Windows.Forms.TextBox()
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextReasonsForRejectingBudgetFromAuditor = New System.Windows.Forms.TextBox()
        Me.IDFL1 = New System.Windows.Forms.TextBox()
        Me.CircularProgress1 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.BackgroundWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.CircularProgress2 = New DevComponents.DotNetBar.Controls.CircularProgress()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.PanelBottom = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.PanelBottom.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TextNumberOfAssociationsSent
        '
        Me.TextNumberOfAssociationsSent.BackColor = System.Drawing.Color.Gainsboro
        Me.TextNumberOfAssociationsSent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumberOfAssociationsSent.Enabled = False
        Me.TextNumberOfAssociationsSent.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextNumberOfAssociationsSent.ForeColor = System.Drawing.Color.Black
        Me.TextNumberOfAssociationsSent.Location = New System.Drawing.Point(0, 269)
        Me.TextNumberOfAssociationsSent.Name = "TextNumberOfAssociationsSent"
        Me.TextNumberOfAssociationsSent.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextNumberOfAssociationsSent.Size = New System.Drawing.Size(185, 22)
        Me.TextNumberOfAssociationsSent.TabIndex = 11
        Me.TextNumberOfAssociationsSent.Text = "0"
        Me.TextNumberOfAssociationsSent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextAssociationName
        '
        Me.TextAssociationName.BackColor = System.Drawing.Color.White
        Me.TextAssociationName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAssociationName.Enabled = False
        Me.TextAssociationName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextAssociationName.ForeColor = System.Drawing.Color.Black
        Me.TextAssociationName.Location = New System.Drawing.Point(3, 165)
        Me.TextAssociationName.Name = "TextAssociationName"
        Me.TextAssociationName.Size = New System.Drawing.Size(182, 22)
        Me.TextAssociationName.TabIndex = 18
        '
        'TextAssociationNationalNumber
        '
        Me.TextAssociationNationalNumber.BackColor = System.Drawing.Color.Gainsboro
        Me.TextAssociationNationalNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAssociationNationalNumber.Enabled = False
        Me.TextAssociationNationalNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextAssociationNationalNumber.ForeColor = System.Drawing.Color.Black
        Me.TextAssociationNationalNumber.Location = New System.Drawing.Point(3, 193)
        Me.TextAssociationNationalNumber.Name = "TextAssociationNationalNumber"
        Me.TextAssociationNationalNumber.Size = New System.Drawing.Size(182, 22)
        Me.TextAssociationNationalNumber.TabIndex = 19
        '
        'TextFiscalYear
        '
        Me.TextFiscalYear.BackColor = System.Drawing.Color.White
        Me.TextFiscalYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFiscalYear.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextFiscalYear.Enabled = False
        Me.TextFiscalYear.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextFiscalYear.ForeColor = System.Drawing.Color.Black
        Me.TextFiscalYear.Location = New System.Drawing.Point(3, 221)
        Me.TextFiscalYear.Name = "TextFiscalYear"
        Me.TextFiscalYear.Size = New System.Drawing.Size(182, 22)
        Me.TextFiscalYear.TabIndex = 20
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AB1, Me.AB3, Me.AB2})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.GridColor = System.Drawing.Color.FromArgb(CType(CType(208, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.DataGridView1.Location = New System.Drawing.Point(603, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 25
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(528, 322)
        Me.DataGridView1.TabIndex = 790
        '
        'AB1
        '
        Me.AB1.FillWeight = 82.62903!
        Me.AB1.HeaderText = "كشوفات الموازنة"
        Me.AB1.Name = "AB1"
        Me.AB1.ReadOnly = True
        Me.AB1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AB1.ToolTipText = "كشوفات الموازنة"
        '
        'AB3
        '
        Me.AB3.HeaderText = "Column1"
        Me.AB3.Name = "AB3"
        Me.AB3.ReadOnly = True
        Me.AB3.Visible = False
        '
        'AB2
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.MistyRose
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        Me.AB2.DefaultCellStyle = DataGridViewCellStyle2
        Me.AB2.DisabledImage = CType(resources.GetObject("AB2.DisabledImage"), System.Drawing.Image)
        Me.AB2.FillWeight = 45.54356!
        Me.AB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AB2.HeaderText = "عرض"
        Me.AB2.HoverImage = CType(resources.GetObject("AB2.HoverImage"), System.Drawing.Image)
        Me.AB2.Image = CType(resources.GetObject("AB2.Image"), System.Drawing.Image)
        Me.AB2.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right
        Me.AB2.Name = "AB2"
        Me.AB2.PopupSide = DevComponents.DotNetBar.ePopupSide.Left
        Me.AB2.PressedImage = CType(resources.GetObject("AB2.PressedImage"), System.Drawing.Image)
        Me.AB2.ReadOnly = True
        Me.AB2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.AB2.Shape = New DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2, 18, 18, 2)
        Me.AB2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.AB2.Text = Nothing
        Me.AB2.TextAlignment = DevComponents.DotNetBar.eButtonTextAlignment.Left
        Me.AB2.ToolTipText = "عرض"
        Me.AB2.UseColumnTextForButtonValue = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButtonRefusal)
        Me.Panel1.Controls.Add(Me.ButtonApproval)
        Me.Panel1.Controls.Add(Me.ButtonViewDocuments)
        Me.Panel1.Controls.Add(Me.ButtonAttachDocument)
        Me.Panel1.Controls.Add(Me.TextNumberOfCompletedAssociations)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TextFiscalYear)
        Me.Panel1.Controls.Add(Me.TextAssociationNationalNumber)
        Me.Panel1.Controls.Add(Me.TextAssociationName)
        Me.Panel1.Controls.Add(Me.TextNumberOfAssociationsSent)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(190, 349)
        Me.Panel1.TabIndex = 792
        '
        'ButtonRefusal
        '
        Me.ButtonRefusal.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonRefusal.Appearance.BackColor2 = System.Drawing.Color.SkyBlue
        Me.ButtonRefusal.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonRefusal.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonRefusal.Appearance.Options.UseBackColor = True
        Me.ButtonRefusal.Appearance.Options.UseFont = True
        Me.ButtonRefusal.Appearance.Options.UseTextOptions = True
        Me.ButtonRefusal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRefusal.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRefusal.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.Reset2_16x16
        Me.ButtonRefusal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonRefusal.Location = New System.Drawing.Point(2, 104)
        Me.ButtonRefusal.Name = "ButtonRefusal"
        Me.ButtonRefusal.Size = New System.Drawing.Size(181, 32)
        Me.ButtonRefusal.TabIndex = 830
        Me.ButtonRefusal.Text = "رفض مدقق الحسابات الداخلي"
        '
        'ButtonApproval
        '
        Me.ButtonApproval.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonApproval.Appearance.BackColor2 = System.Drawing.Color.SkyBlue
        Me.ButtonApproval.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonApproval.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonApproval.Appearance.Options.UseBackColor = True
        Me.ButtonApproval.Appearance.Options.UseFont = True
        Me.ButtonApproval.Appearance.Options.UseTextOptions = True
        Me.ButtonApproval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonApproval.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonApproval.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.accept
        Me.ButtonApproval.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonApproval.Location = New System.Drawing.Point(2, 71)
        Me.ButtonApproval.Name = "ButtonApproval"
        Me.ButtonApproval.Size = New System.Drawing.Size(181, 32)
        Me.ButtonApproval.TabIndex = 831
        Me.ButtonApproval.Text = "اعتماد مدقق الحسابات الداخلي"
        '
        'ButtonViewDocuments
        '
        Me.ButtonViewDocuments.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonViewDocuments.Appearance.BackColor2 = System.Drawing.Color.SkyBlue
        Me.ButtonViewDocuments.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonViewDocuments.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonViewDocuments.Appearance.Options.UseBackColor = True
        Me.ButtonViewDocuments.Appearance.Options.UseFont = True
        Me.ButtonViewDocuments.Appearance.Options.UseTextOptions = True
        Me.ButtonViewDocuments.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonViewDocuments.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonViewDocuments.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.PInternalAuditor_16x16
        Me.ButtonViewDocuments.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonViewDocuments.Location = New System.Drawing.Point(2, 37)
        Me.ButtonViewDocuments.Name = "ButtonViewDocuments"
        Me.ButtonViewDocuments.Size = New System.Drawing.Size(181, 32)
        Me.ButtonViewDocuments.TabIndex = 829
        Me.ButtonViewDocuments.Text = "عرض مستندات "
        '
        'ButtonAttachDocument
        '
        Me.ButtonAttachDocument.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonAttachDocument.Appearance.BackColor2 = System.Drawing.Color.SkyBlue
        Me.ButtonAttachDocument.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonAttachDocument.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonAttachDocument.Appearance.Options.UseBackColor = True
        Me.ButtonAttachDocument.Appearance.Options.UseFont = True
        Me.ButtonAttachDocument.Appearance.Options.UseTextOptions = True
        Me.ButtonAttachDocument.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonAttachDocument.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAttachDocument.ImageOptions.Image = CType(resources.GetObject("ButtonAttachDocument.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonAttachDocument.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonAttachDocument.Location = New System.Drawing.Point(2, 3)
        Me.ButtonAttachDocument.Name = "ButtonAttachDocument"
        Me.ButtonAttachDocument.Size = New System.Drawing.Size(181, 32)
        Me.ButtonAttachDocument.TabIndex = 828
        Me.ButtonAttachDocument.Text = "إضافة مرفق جديد"
        '
        'TextNumberOfCompletedAssociations
        '
        Me.TextNumberOfCompletedAssociations.BackColor = System.Drawing.Color.Gainsboro
        Me.TextNumberOfCompletedAssociations.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNumberOfCompletedAssociations.Enabled = False
        Me.TextNumberOfCompletedAssociations.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextNumberOfCompletedAssociations.ForeColor = System.Drawing.Color.Black
        Me.TextNumberOfCompletedAssociations.Location = New System.Drawing.Point(0, 312)
        Me.TextNumberOfCompletedAssociations.Name = "TextNumberOfCompletedAssociations"
        Me.TextNumberOfCompletedAssociations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextNumberOfCompletedAssociations.Size = New System.Drawing.Size(185, 22)
        Me.TextNumberOfCompletedAssociations.TabIndex = 798
        Me.TextNumberOfCompletedAssociations.Text = "0"
        Me.TextNumberOfCompletedAssociations.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label8.Location = New System.Drawing.Point(64, 251)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(99, 15)
        Me.Label8.TabIndex = 797
        Me.Label8.Text = "عدد الجمعيات المرسلة"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label7.Location = New System.Drawing.Point(65, 294)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 15)
        Me.Label7.TabIndex = 796
        Me.Label7.Text = "عدد الجمعيات المنجزه"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Right
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(874, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 25)
        Me.Label2.TabIndex = 795
        Me.Label2.Text = "تحديد الجمعية"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ComboAssociationName)
        Me.Panel2.Controls.Add(Me.ButtonEnquiry)
        Me.Panel2.Controls.Add(Me.TextCondition)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(190, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(941, 27)
        Me.Panel2.TabIndex = 796
        '
        'ComboAssociationName
        '
        Me.ComboAssociationName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboAssociationName.FormattingEnabled = True
        Me.ComboAssociationName.Location = New System.Drawing.Point(500, 0)
        Me.ComboAssociationName.Name = "ComboAssociationName"
        Me.ComboAssociationName.Size = New System.Drawing.Size(368, 23)
        Me.ComboAssociationName.TabIndex = 824
        '
        'ButtonEnquiry
        '
        Me.ButtonEnquiry.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ButtonEnquiry.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.ButtonEnquiry.Appearance.BackColor2 = System.Drawing.Color.SkyBlue
        Me.ButtonEnquiry.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonEnquiry.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonEnquiry.Appearance.Options.UseBackColor = True
        Me.ButtonEnquiry.Appearance.Options.UseFont = True
        Me.ButtonEnquiry.Appearance.Options.UseTextOptions = True
        Me.ButtonEnquiry.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonEnquiry.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonEnquiry.ImageOptions.Image = CType(resources.GetObject("ButtonEnquiry.ImageOptions.Image"), System.Drawing.Image)
        Me.ButtonEnquiry.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonEnquiry.Location = New System.Drawing.Point(411, 0)
        Me.ButtonEnquiry.Name = "ButtonEnquiry"
        Me.ButtonEnquiry.Size = New System.Drawing.Size(87, 23)
        Me.ButtonEnquiry.TabIndex = 804
        Me.ButtonEnquiry.Text = "استعلام"
        '
        'TextCondition
        '
        Me.TextCondition.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TextCondition.BackColor = System.Drawing.Color.White
        Me.TextCondition.Enabled = False
        Me.TextCondition.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextCondition.ForeColor = System.Drawing.Color.Black
        Me.TextCondition.Location = New System.Drawing.Point(2, 1)
        Me.TextCondition.Name = "TextCondition"
        Me.TextCondition.Size = New System.Drawing.Size(369, 22)
        Me.TextCondition.TabIndex = 797
        '
        'Label3
        '
        Me.Label3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(374, 4)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 796
        Me.Label3.Text = "الحالة"
        '
        'TextReasonsForRejectingBudgetFromExternalAuditor
        '
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.BackColor = System.Drawing.Color.White
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Enabled = False
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.ForeColor = System.Drawing.Color.Black
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Location = New System.Drawing.Point(3, 252)
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Multiline = True
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Name = "TextReasonsForRejectingBudgetFromExternalAuditor"
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.Size = New System.Drawing.Size(405, 64)
        Me.TextReasonsForRejectingBudgetFromExternalAuditor.TabIndex = 816
        '
        'TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment
        '
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.BackColor = System.Drawing.Color.White
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Enabled = False
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.ForeColor = System.Drawing.Color.Black
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Location = New System.Drawing.Point(3, 173)
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Multiline = True
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Name = "TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment"
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.Size = New System.Drawing.Size(405, 64)
        Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment.TabIndex = 815
        '
        'TextReasonsForRejectingBudgetFromDirectorOfCooperation
        '
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.BackColor = System.Drawing.Color.White
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Enabled = False
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.ForeColor = System.Drawing.Color.Black
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Location = New System.Drawing.Point(3, 94)
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Multiline = True
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Name = "TextReasonsForRejectingBudgetFromDirectorOfCooperation"
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.Size = New System.Drawing.Size(405, 64)
        Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation.TabIndex = 814
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.PeachPuff
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(3, 237)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(223, 15)
        Me.Label6.TabIndex = 813
        Me.Label6.Text = "اسباب  رفض الموازنة من مدقق الحسابات الخارجية"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.PeachPuff
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(3, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(248, 15)
        Me.Label5.TabIndex = 812
        Me.Label5.Text = "اسباب  رفض الموازنة من رئيس قسم الحسابات الخارجية"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.PeachPuff
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(3, 79)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(172, 15)
        Me.Label4.TabIndex = 811
        Me.Label4.Text = "اسباب  رفض الموازنة من مدير التعاون"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.PeachPuff
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(182, 15)
        Me.Label1.TabIndex = 809
        Me.Label1.Text = "اسباب  رفض الموازنة من مدقق الحسابات"
        '
        'TextReasonsForRejectingBudgetFromAuditor
        '
        Me.TextReasonsForRejectingBudgetFromAuditor.BackColor = System.Drawing.Color.White
        Me.TextReasonsForRejectingBudgetFromAuditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReasonsForRejectingBudgetFromAuditor.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextReasonsForRejectingBudgetFromAuditor.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextReasonsForRejectingBudgetFromAuditor.ForeColor = System.Drawing.Color.Black
        Me.TextReasonsForRejectingBudgetFromAuditor.Location = New System.Drawing.Point(3, 15)
        Me.TextReasonsForRejectingBudgetFromAuditor.Multiline = True
        Me.TextReasonsForRejectingBudgetFromAuditor.Name = "TextReasonsForRejectingBudgetFromAuditor"
        Me.TextReasonsForRejectingBudgetFromAuditor.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextReasonsForRejectingBudgetFromAuditor.Size = New System.Drawing.Size(405, 64)
        Me.TextReasonsForRejectingBudgetFromAuditor.TabIndex = 808
        '
        'IDFL1
        '
        Me.IDFL1.BackColor = System.Drawing.Color.White
        Me.IDFL1.Enabled = False
        Me.IDFL1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.IDFL1.ForeColor = System.Drawing.Color.Black
        Me.IDFL1.Location = New System.Drawing.Point(107, 99)
        Me.IDFL1.Name = "IDFL1"
        Me.IDFL1.Size = New System.Drawing.Size(94, 22)
        Me.IDFL1.TabIndex = 810
        '
        'CircularProgress1
        '
        '
        '
        '
        Me.CircularProgress1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress1.Location = New System.Drawing.Point(572, 50)
        Me.CircularProgress1.Name = "CircularProgress1"
        Me.CircularProgress1.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Donut
        Me.CircularProgress1.ProgressColor = System.Drawing.Color.SpringGreen
        Me.CircularProgress1.Size = New System.Drawing.Size(75, 69)
        Me.CircularProgress1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress1.TabIndex = 818
        '
        'BackgroundWorker1
        '
        '
        'BackgroundWorker2
        '
        '
        'CircularProgress2
        '
        '
        '
        '
        Me.CircularProgress2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CircularProgress2.Location = New System.Drawing.Point(572, 50)
        Me.CircularProgress2.Name = "CircularProgress2"
        Me.CircularProgress2.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke
        Me.CircularProgress2.ProgressColor = System.Drawing.Color.SpringGreen
        Me.CircularProgress2.Size = New System.Drawing.Size(75, 69)
        Me.CircularProgress2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP
        Me.CircularProgress2.TabIndex = 819
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView2.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView2.Location = New System.Drawing.Point(4, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.ShowCellErrors = False
        Me.DataGridView2.ShowCellToolTips = False
        Me.DataGridView2.ShowEditingIcon = False
        Me.DataGridView2.ShowRowErrors = False
        Me.DataGridView2.Size = New System.Drawing.Size(1131, 203)
        Me.DataGridView2.TabIndex = 820
        '
        'PanelBottom
        '
        Me.PanelBottom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PanelBottom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PanelBottom.Controls.Add(Me.CircularProgress2)
        Me.PanelBottom.Controls.Add(Me.CircularProgress1)
        Me.PanelBottom.Controls.Add(Me.DataGridView1)
        Me.PanelBottom.Controls.Add(Me.Panel3)
        Me.PanelBottom.Controls.Add(Me.Panel2)
        Me.PanelBottom.Controls.Add(Me.Panel1)
        Me.PanelBottom.Location = New System.Drawing.Point(3, 210)
        Me.PanelBottom.Name = "PanelBottom"
        Me.PanelBottom.Size = New System.Drawing.Size(1133, 351)
        Me.PanelBottom.TabIndex = 823
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.TextReasonsForRejectingBudgetFromAuditor)
        Me.Panel3.Controls.Add(Me.TextReasonsForRejectingBudgetFromExternalAuditor)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.TextReasonsForRejectingBudgetFromDirectorOfCooperation)
        Me.Panel3.Controls.Add(Me.TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.IDFL1)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(190, 27)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(413, 322)
        Me.Panel3.TabIndex = 823
        '
        'FormInternalAuditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(1139, 565)
        Me.Controls.Add(Me.PanelBottom)
        Me.Controls.Add(Me.DataGridView2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(1155, 550)
        Me.Name = "FormInternalAuditor"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "مدقق الداخلي "
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.PanelBottom.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextNumberOfAssociationsSent As System.Windows.Forms.TextBox
    Friend WithEvents TextAssociationName As System.Windows.Forms.TextBox
    Friend WithEvents TextAssociationNationalNumber As System.Windows.Forms.TextBox
    Friend WithEvents TextFiscalYear As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As DevComponents.DotNetBar.Controls.DataGridViewX
    Friend WithEvents AB1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AB3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AB2 As DevComponents.DotNetBar.Controls.DataGridViewButtonXColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextReasonsForRejectingBudgetFromExternalAuditor As System.Windows.Forms.TextBox
    Friend WithEvents TextReasonsForRejectingBudgetFromHeadOfExternalAccountsDepartment As System.Windows.Forms.TextBox
    Friend WithEvents TextReasonsForRejectingBudgetFromDirectorOfCooperation As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextReasonsForRejectingBudgetFromAuditor As System.Windows.Forms.TextBox
    Friend WithEvents IDFL1 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextNumberOfCompletedAssociations As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CircularProgress1 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents BackgroundWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents CircularProgress2 As DevComponents.DotNetBar.Controls.CircularProgress
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents PanelBottom As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ButtonEnquiry As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ComboAssociationName As ComboBox
    Friend WithEvents ButtonRefusal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonApproval As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonViewDocuments As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonAttachDocument As DevExpress.XtraEditors.SimpleButton
End Class
