<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAssociationAccountant
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAssociationAccountant))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextCondition = New System.Windows.Forms.TextBox()
        Me.TextFL10 = New System.Windows.Forms.Label()
        Me.CheckApproved = New System.Windows.Forms.CheckBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextReasonsForRejectingBudget = New System.Windows.Forms.TextBox()
        Me.IDFL1 = New System.Windows.Forms.TextBox()
        Me.ButtonItem1 = New DevComponents.DotNetBar.ButtonItem()
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.ButtonApproval = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonRefusal = New DevExpress.XtraEditors.SimpleButton()
        Me.ComboBAssociationName = New System.Windows.Forms.ComboBox()
        Me.ComboFiscalYear = New System.Windows.Forms.ComboBox()
        Me.ComboAuditor = New System.Windows.Forms.ComboBox()
        Me.ButtonViewDocuments = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAttachDocument = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonAddAssociationProjects = New DevExpress.XtraEditors.SimpleButton()
        Me.ButtonButtonAddFundInventory = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextAssociationNationalNumber = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.ButtonSave = New DevExpress.XtraEditors.SimpleButton()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(503, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "اسم الجمعية :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label4.Location = New System.Drawing.Point(503, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "الرقم الوطني للجمعية :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label5.Location = New System.Drawing.Point(179, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 15)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "السنة المالية :"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(503, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "مدقق الحسابات :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label6.Location = New System.Drawing.Point(501, 5)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 19)
        Me.Label6.TabIndex = 798
        Me.Label6.Text = "الحالة :"
        '
        'TextCondition
        '
        Me.TextCondition.BackColor = System.Drawing.Color.White
        Me.TextCondition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCondition.Enabled = False
        Me.TextCondition.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextCondition.ForeColor = System.Drawing.Color.Black
        Me.TextCondition.Location = New System.Drawing.Point(3, 4)
        Me.TextCondition.Name = "TextCondition"
        Me.TextCondition.Size = New System.Drawing.Size(495, 22)
        Me.TextCondition.TabIndex = 797
        '
        'TextFL10
        '
        Me.TextFL10.BackColor = System.Drawing.Color.SteelBlue
        Me.TextFL10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TextFL10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextFL10.ForeColor = System.Drawing.Color.White
        Me.TextFL10.Location = New System.Drawing.Point(3, 149)
        Me.TextFL10.Name = "TextFL10"
        Me.TextFL10.Size = New System.Drawing.Size(22, 22)
        Me.TextFL10.TabIndex = 1007
        Me.TextFL10.Text = "5"
        Me.TextFL10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CheckApproved
        '
        Me.CheckApproved.AutoSize = True
        Me.CheckApproved.Enabled = False
        Me.CheckApproved.Location = New System.Drawing.Point(92, 151)
        Me.CheckApproved.Name = "CheckApproved"
        Me.CheckApproved.Size = New System.Drawing.Size(70, 19)
        Me.CheckApproved.TabIndex = 91
        Me.CheckApproved.Text = "تم الاعتماد"
        Me.CheckApproved.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.Location = New System.Drawing.Point(125, 328)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 730
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox5.Location = New System.Drawing.Point(128, 333)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 729
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(500, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 15)
        Me.Label2.TabIndex = 796
        Me.Label2.Text = "اسباب  رفض الموازنة"
        '
        'TextReasonsForRejectingBudget
        '
        Me.TextReasonsForRejectingBudget.BackColor = System.Drawing.Color.White
        Me.TextReasonsForRejectingBudget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReasonsForRejectingBudget.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextReasonsForRejectingBudget.Enabled = False
        Me.TextReasonsForRejectingBudget.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextReasonsForRejectingBudget.ForeColor = System.Drawing.Color.Black
        Me.TextReasonsForRejectingBudget.Location = New System.Drawing.Point(4, 56)
        Me.TextReasonsForRejectingBudget.Multiline = True
        Me.TextReasonsForRejectingBudget.Name = "TextReasonsForRejectingBudget"
        Me.TextReasonsForRejectingBudget.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextReasonsForRejectingBudget.Size = New System.Drawing.Size(600, 222)
        Me.TextReasonsForRejectingBudget.TabIndex = 795
        '
        'IDFL1
        '
        Me.IDFL1.BackColor = System.Drawing.Color.White
        Me.IDFL1.Enabled = False
        Me.IDFL1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.IDFL1.ForeColor = System.Drawing.Color.Black
        Me.IDFL1.Location = New System.Drawing.Point(498, 167)
        Me.IDFL1.Name = "IDFL1"
        Me.IDFL1.Size = New System.Drawing.Size(94, 22)
        Me.IDFL1.TabIndex = 794
        '
        'ButtonItem1
        '
        Me.ButtonItem1.GlobalItem = False
        Me.ButtonItem1.Name = "ButtonItem1"
        '
        'BackWorker2
        '
        '
        'ButtonApproval
        '
        Me.ButtonApproval.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonApproval.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonApproval.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonApproval.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonApproval.Appearance.Options.UseBackColor = True
        Me.ButtonApproval.Appearance.Options.UseFont = True
        Me.ButtonApproval.Appearance.Options.UseTextOptions = True
        Me.ButtonApproval.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonApproval.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonApproval.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.accept
        Me.ButtonApproval.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonApproval.Location = New System.Drawing.Point(261, 3)
        Me.ButtonApproval.Name = "ButtonApproval"
        Me.ButtonApproval.Size = New System.Drawing.Size(256, 32)
        Me.ButtonApproval.TabIndex = 828
        Me.ButtonApproval.Text = "اعتماد المحاسب"
        '
        'ButtonRefusal
        '
        Me.ButtonRefusal.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonRefusal.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonRefusal.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonRefusal.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonRefusal.Appearance.ForeColor = System.Drawing.Color.Black
        Me.ButtonRefusal.Appearance.Options.UseBackColor = True
        Me.ButtonRefusal.Appearance.Options.UseFont = True
        Me.ButtonRefusal.Appearance.Options.UseForeColor = True
        Me.ButtonRefusal.Appearance.Options.UseTextOptions = True
        Me.ButtonRefusal.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonRefusal.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonRefusal.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.Reset2_16x16
        Me.ButtonRefusal.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonRefusal.Location = New System.Drawing.Point(3, 3)
        Me.ButtonRefusal.Name = "ButtonRefusal"
        Me.ButtonRefusal.Size = New System.Drawing.Size(256, 32)
        Me.ButtonRefusal.TabIndex = 832
        Me.ButtonRefusal.Text = "إرجاع الميزانية للتعديل"
        '
        'ComboBAssociationName
        '
        Me.ComboBAssociationName.FormattingEnabled = True
        Me.ComboBAssociationName.Location = New System.Drawing.Point(3, 4)
        Me.ComboBAssociationName.Name = "ComboBAssociationName"
        Me.ComboBAssociationName.Size = New System.Drawing.Size(496, 23)
        Me.ComboBAssociationName.TabIndex = 1011
        '
        'ComboFiscalYear
        '
        Me.ComboFiscalYear.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboFiscalYear.FormattingEnabled = True
        Me.ComboFiscalYear.Location = New System.Drawing.Point(3, 30)
        Me.ComboFiscalYear.Name = "ComboFiscalYear"
        Me.ComboFiscalYear.Size = New System.Drawing.Size(170, 23)
        Me.ComboFiscalYear.TabIndex = 1015
        '
        'ComboAuditor
        '
        Me.ComboAuditor.FormattingEnabled = True
        Me.ComboAuditor.Location = New System.Drawing.Point(3, 55)
        Me.ComboAuditor.Name = "ComboAuditor"
        Me.ComboAuditor.Size = New System.Drawing.Size(496, 23)
        Me.ComboAuditor.TabIndex = 1016
        '
        'ButtonViewDocuments
        '
        Me.ButtonViewDocuments.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonViewDocuments.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonViewDocuments.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonViewDocuments.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonViewDocuments.Appearance.Options.UseBackColor = True
        Me.ButtonViewDocuments.Appearance.Options.UseFont = True
        Me.ButtonViewDocuments.Appearance.Options.UseTextOptions = True
        Me.ButtonViewDocuments.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonViewDocuments.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonViewDocuments.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.PInternalAuditor_16x16
        Me.ButtonViewDocuments.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonViewDocuments.Location = New System.Drawing.Point(3, 37)
        Me.ButtonViewDocuments.Name = "ButtonViewDocuments"
        Me.ButtonViewDocuments.Size = New System.Drawing.Size(159, 32)
        Me.ButtonViewDocuments.TabIndex = 1021
        Me.ButtonViewDocuments.Text = "عرض مستندات "
        '
        'ButtonAttachDocument
        '
        Me.ButtonAttachDocument.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonAttachDocument.Appearance.BackColor2 = System.Drawing.SystemColors.ControlDark
        Me.ButtonAttachDocument.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonAttachDocument.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonAttachDocument.Appearance.Options.UseBackColor = True
        Me.ButtonAttachDocument.Appearance.Options.UseFont = True
        Me.ButtonAttachDocument.Appearance.Options.UseTextOptions = True
        Me.ButtonAttachDocument.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonAttachDocument.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAttachDocument.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.AddFile_16x16
        Me.ButtonAttachDocument.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonAttachDocument.Location = New System.Drawing.Point(3, 3)
        Me.ButtonAttachDocument.Name = "ButtonAttachDocument"
        Me.ButtonAttachDocument.Size = New System.Drawing.Size(159, 32)
        Me.ButtonAttachDocument.TabIndex = 1020
        Me.ButtonAttachDocument.Text = "إضافة مرفق جديد"
        '
        'ButtonAddAssociationProjects
        '
        Me.ButtonAddAssociationProjects.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonAddAssociationProjects.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonAddAssociationProjects.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonAddAssociationProjects.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonAddAssociationProjects.Appearance.Options.UseBackColor = True
        Me.ButtonAddAssociationProjects.Appearance.Options.UseFont = True
        Me.ButtonAddAssociationProjects.Appearance.Options.UseTextOptions = True
        Me.ButtonAddAssociationProjects.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonAddAssociationProjects.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonAddAssociationProjects.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.addheader_16x16
        Me.ButtonAddAssociationProjects.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonAddAssociationProjects.Location = New System.Drawing.Point(3, 105)
        Me.ButtonAddAssociationProjects.Name = "ButtonAddAssociationProjects"
        Me.ButtonAddAssociationProjects.Size = New System.Drawing.Size(159, 32)
        Me.ButtonAddAssociationProjects.TabIndex = 1026
        Me.ButtonAddAssociationProjects.Text = "إضافة مشاريع الجمعية"
        '
        'ButtonButtonAddFundInventory
        '
        Me.ButtonButtonAddFundInventory.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonButtonAddFundInventory.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonButtonAddFundInventory.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonButtonAddFundInventory.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonButtonAddFundInventory.Appearance.Options.UseBackColor = True
        Me.ButtonButtonAddFundInventory.Appearance.Options.UseFont = True
        Me.ButtonButtonAddFundInventory.Appearance.Options.UseTextOptions = True
        Me.ButtonButtonAddFundInventory.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonButtonAddFundInventory.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonButtonAddFundInventory.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.AddItem_16x16
        Me.ButtonButtonAddFundInventory.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonButtonAddFundInventory.Location = New System.Drawing.Point(3, 71)
        Me.ButtonButtonAddFundInventory.Name = "ButtonButtonAddFundInventory"
        Me.ButtonButtonAddFundInventory.Size = New System.Drawing.Size(159, 32)
        Me.ButtonButtonAddFundInventory.TabIndex = 1025
        Me.ButtonButtonAddFundInventory.Text = "إضافة جرد الصندوق"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextAssociationNationalNumber)
        Me.Panel1.Controls.Add(Me.ComboBAssociationName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.ComboAuditor)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ComboFiscalYear)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(4, 40)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(610, 84)
        Me.Panel1.TabIndex = 1030
        '
        'TextAssociationNationalNumber
        '
        Me.TextAssociationNationalNumber.BackColor = System.Drawing.Color.SteelBlue
        Me.TextAssociationNationalNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TextAssociationNationalNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.TextAssociationNationalNumber.ForeColor = System.Drawing.Color.White
        Me.TextAssociationNationalNumber.Location = New System.Drawing.Point(287, 30)
        Me.TextAssociationNationalNumber.Name = "TextAssociationNationalNumber"
        Me.TextAssociationNationalNumber.Size = New System.Drawing.Size(212, 22)
        Me.TextAssociationNationalNumber.TabIndex = 1017
        Me.TextAssociationNationalNumber.Text = "5"
        Me.TextAssociationNationalNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel6)
        Me.Panel2.Controls.Add(Me.TextReasonsForRejectingBudget)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(4, 126)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(610, 283)
        Me.Panel2.TabIndex = 1031
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.TextCondition)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel6.Location = New System.Drawing.Point(0, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(608, 32)
        Me.Panel6.TabIndex = 799
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.ButtonAttachDocument)
        Me.Panel3.Controls.Add(Me.ButtonViewDocuments)
        Me.Panel3.Controls.Add(Me.ButtonButtonAddFundInventory)
        Me.Panel3.Controls.Add(Me.ButtonAddAssociationProjects)
        Me.Panel3.Controls.Add(Me.TextFL10)
        Me.Panel3.Controls.Add(Me.PictureBox5)
        Me.Panel3.Controls.Add(Me.PictureBox2)
        Me.Panel3.Controls.Add(Me.CheckApproved)
        Me.Panel3.Location = New System.Drawing.Point(617, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(167, 369)
        Me.Panel3.TabIndex = 1032
        '
        'ButtonSave
        '
        Me.ButtonSave.AllowDrop = True
        Me.ButtonSave.Appearance.BackColor = System.Drawing.Color.Olive
        Me.ButtonSave.Appearance.BackColor2 = System.Drawing.SystemColors.ActiveCaption
        Me.ButtonSave.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonSave.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.ButtonSave.Appearance.Options.UseBackColor = True
        Me.ButtonSave.Appearance.Options.UseFont = True
        Me.ButtonSave.Appearance.Options.UseTextOptions = True
        Me.ButtonSave.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
        Me.ButtonSave.ImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.[False]
        Me.ButtonSave.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.ButtonSave.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleRight
        Me.ButtonSave.Location = New System.Drawing.Point(519, 3)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(255, 32)
        Me.ButtonSave.TabIndex = 1027
        Me.ButtonSave.Text = "حفظ"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(788, 37)
        Me.Panel4.TabIndex = 1033
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.SteelBlue
        Me.Label7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Traditional Arabic", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = Global.CC_JO.My.Resources.Resources.bopivotchart_32x32
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(786, 35)
        Me.Label7.TabIndex = 1008
        Me.Label7.Text = "ميزانية سنة مالية"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel5
        '
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.ButtonSave)
        Me.Panel5.Controls.Add(Me.ButtonApproval)
        Me.Panel5.Controls.Add(Me.ButtonRefusal)
        Me.Panel5.Location = New System.Drawing.Point(5, 415)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(779, 40)
        Me.Panel5.TabIndex = 1034
        '
        'FormAssociationAccountant
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(788, 457)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.IDFL1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAssociationAccountant"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "محاسب الجمعية "
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ButtonItem1 As DevComponents.DotNetBar.ButtonItem
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextCondition As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextReasonsForRejectingBudget As System.Windows.Forms.TextBox
    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents IDFL1 As System.Windows.Forms.TextBox
    Friend WithEvents CheckApproved As System.Windows.Forms.CheckBox
    Friend WithEvents TextFL10 As Label
    Friend WithEvents ButtonApproval As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonRefusal As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ComboBAssociationName As ComboBox
    Friend WithEvents ComboFiscalYear As ComboBox
    Friend WithEvents ComboAuditor As ComboBox
    Friend WithEvents ButtonViewDocuments As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonAttachDocument As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonAddAssociationProjects As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents ButtonButtonAddFundInventory As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents TextAssociationNationalNumber As Label
    Friend WithEvents ButtonSave As DevExpress.XtraEditors.SimpleButton
End Class
