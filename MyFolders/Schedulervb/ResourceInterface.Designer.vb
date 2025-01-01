<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ResourceInterface
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.RibbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.BarButtonItem1 = New DevExpress.XtraBars.BarButtonItem()
        Me.ButtonEdit = New DevExpress.XtraBars.BarButtonItem()
        Me.RibbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonStatusBar1 = New DevExpress.XtraBars.Ribbon.RibbonStatusBar()
        Me.RibbonPage2 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.DataSetScheduler = New DataSetScheduler()
        Me.ResourcesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ResourcesTableAdapter = New DataSetSchedulerTableAdapters.ResourcesTableAdapter()
        Me.DataLayoutControl1 = New DevExpress.XtraDataLayout.DataLayoutControl()
        Me.ComboCustomerName = New System.Windows.Forms.ComboBox()
        Me.UniqueIDTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ResourceIDTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ResourceNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.CustomField1TextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ImagePictureEdit = New DevExpress.XtraEditors.PictureEdit()
        Me.UserNameTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.CUserTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.COUserTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.ColorColorPickEdit = New DevExpress.XtraEditors.ColorPickEdit()
        Me.daTextEdit = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit1 = New DevExpress.XtraEditors.TextEdit()
        Me.ItemForUniqueID = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForUserName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForColor = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForCUser = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForCOUser = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForda = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.ItemForCustomField1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForResourceName = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForResourceID = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ItemForImage = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DataNavigator1 = New DevExpress.XtraEditors.DataNavigator()
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSetScheduler, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResourcesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DataLayoutControl1.SuspendLayout()
        CType(Me.UniqueIDTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResourceIDTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ResourceNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomField1TextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImagePictureEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UserNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CUserTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.COUserTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ColorColorPickEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.daTextEdit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForUniqueID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForUserName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForCUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForCOUser, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForda, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForCustomField1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForResourceName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForResourceID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ItemForImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RibbonControl1
        '
        Me.RibbonControl1.ExpandCollapseItem.Id = 0
        Me.RibbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.RibbonControl1.ExpandCollapseItem, Me.RibbonControl1.SearchEditItem, Me.BarButtonItem1, Me.ButtonEdit})
        Me.RibbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.RibbonControl1.MaxItemId = 4
        Me.RibbonControl1.Name = "RibbonControl1"
        Me.RibbonControl1.OptionsCustomizationForm.AllowEditBarItemPopups = True
        Me.RibbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.RibbonPage1})
        Me.RibbonControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RibbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersInFormCaption = DevExpress.Utils.DefaultBoolean.[False]
        Me.RibbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Hide
        Me.RibbonControl1.ShowQatLocationSelector = False
        Me.RibbonControl1.ShowToolbarCustomizeItem = False
        Me.RibbonControl1.Size = New System.Drawing.Size(599, 132)
        Me.RibbonControl1.StatusBar = Me.RibbonStatusBar1
        Me.RibbonControl1.Toolbar.ShowCustomizeItem = False
        '
        'BarButtonItem1
        '
        Me.BarButtonItem1.Caption = "Save"
        Me.BarButtonItem1.Id = 1
        Me.BarButtonItem1.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.save11
        Me.BarButtonItem1.Name = "BarButtonItem1"
        Me.BarButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'ButtonEdit
        '
        Me.ButtonEdit.Caption = "Edit"
        Me.ButtonEdit.Id = 3
        Me.ButtonEdit.ImageOptions.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.ButtonEdit.Name = "ButtonEdit"
        Me.ButtonEdit.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large
        '
        'RibbonPage1
        '
        Me.RibbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.RibbonPageGroup1})
        Me.RibbonPage1.Name = "RibbonPage1"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.BarButtonItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.State = DevExpress.XtraBars.Ribbon.RibbonPageGroupState.Expanded
        Me.RibbonPageGroup1.Text = "Save"
        '
        'RibbonStatusBar1
        '
        Me.RibbonStatusBar1.Location = New System.Drawing.Point(0, 280)
        Me.RibbonStatusBar1.Name = "RibbonStatusBar1"
        Me.RibbonStatusBar1.Ribbon = Me.RibbonControl1
        Me.RibbonStatusBar1.Size = New System.Drawing.Size(599, 22)
        '
        'RibbonPage2
        '
        Me.RibbonPage2.Name = "RibbonPage2"
        Me.RibbonPage2.Text = "RibbonPage2"
        '
        'DataSetScheduler
        '
        Me.DataSetScheduler.DataSetName = "DataSetScheduler"
        Me.DataSetScheduler.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ResourcesBindingSource
        '
        Me.ResourcesBindingSource.DataMember = "Resources"
        Me.ResourcesBindingSource.DataSource = Me.DataSetScheduler
        '
        'ResourcesTableAdapter
        '
        Me.ResourcesTableAdapter.ClearBeforeFill = True
        '
        'DataLayoutControl1
        '
        Me.DataLayoutControl1.Controls.Add(Me.ComboCustomerName)
        Me.DataLayoutControl1.Controls.Add(Me.UniqueIDTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.ResourceIDTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.ResourceNameTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.CustomField1TextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.ImagePictureEdit)
        Me.DataLayoutControl1.Controls.Add(Me.UserNameTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.CUserTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.COUserTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.ColorColorPickEdit)
        Me.DataLayoutControl1.Controls.Add(Me.daTextEdit)
        Me.DataLayoutControl1.Controls.Add(Me.TextEdit1)
        Me.DataLayoutControl1.DataSource = Me.ResourcesBindingSource
        Me.DataLayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.DataLayoutControl1.HiddenItems.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForUniqueID, Me.ItemForUserName, Me.ItemForColor, Me.ItemForCUser, Me.ItemForCOUser, Me.ItemForda, Me.LayoutControlItem2})
        Me.DataLayoutControl1.Location = New System.Drawing.Point(0, 132)
        Me.DataLayoutControl1.Name = "DataLayoutControl1"
        Me.DataLayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(813, 155, 650, 400)
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.BackColor = System.Drawing.Color.LightGray
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseBackColor = True
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseFont = True
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.Options.UseTextOptions = True
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.DataLayoutControl1.OptionsPrint.AppearanceGroupCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.DataLayoutControl1.OptionsView.RightToLeftMirroringApplied = True
        Me.DataLayoutControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DataLayoutControl1.Root = Me.Root
        Me.DataLayoutControl1.Size = New System.Drawing.Size(599, 126)
        Me.DataLayoutControl1.TabIndex = 2
        Me.DataLayoutControl1.Text = "DataLayoutControl1"
        '
        'ComboCustomerName
        '
        Me.ComboCustomerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboCustomerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCustomerName.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboCustomerName.FormattingEnabled = True
        Me.ComboCustomerName.Location = New System.Drawing.Point(189, 12)
        Me.ComboCustomerName.Name = "ComboCustomerName"
        Me.ComboCustomerName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboCustomerName.Size = New System.Drawing.Size(325, 23)
        Me.ComboCustomerName.TabIndex = 961
        '
        'UniqueIDTextEdit
        '
        Me.UniqueIDTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "UniqueID", True))
        Me.UniqueIDTextEdit.Location = New System.Drawing.Point(366, 12)
        Me.UniqueIDTextEdit.MenuManager = Me.RibbonControl1
        Me.UniqueIDTextEdit.Name = "UniqueIDTextEdit"
        Me.UniqueIDTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.UniqueIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.UniqueIDTextEdit.Properties.Mask.EditMask = "N0"
        Me.UniqueIDTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.UniqueIDTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.UniqueIDTextEdit.Size = New System.Drawing.Size(143, 20)
        Me.UniqueIDTextEdit.StyleController = Me.DataLayoutControl1
        Me.UniqueIDTextEdit.TabIndex = 4
        '
        'ResourceIDTextEdit
        '
        Me.ResourceIDTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "ResourceID", True))
        Me.ResourceIDTextEdit.Enabled = False
        Me.ResourceIDTextEdit.Location = New System.Drawing.Point(189, 37)
        Me.ResourceIDTextEdit.MenuManager = Me.RibbonControl1
        Me.ResourceIDTextEdit.Name = "ResourceIDTextEdit"
        Me.ResourceIDTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ResourceIDTextEdit.Properties.Appearance.Options.UseFont = True
        Me.ResourceIDTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ResourceIDTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ResourceIDTextEdit.Properties.BeepOnError = False
        Me.ResourceIDTextEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ResourceIDTextEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ResourceIDTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ResourceIDTextEdit.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.SimpleMaskManager))
        Me.ResourceIDTextEdit.Properties.MaskSettings.Set("mask", "99999")
        Me.ResourceIDTextEdit.Properties.MaskSettings.Set("MaskManagerSignature", "ignoreMaskBlank=True")
        Me.ResourceIDTextEdit.Size = New System.Drawing.Size(325, 22)
        Me.ResourceIDTextEdit.StyleController = Me.DataLayoutControl1
        Me.ResourceIDTextEdit.TabIndex = 5
        '
        'ResourceNameTextEdit
        '
        Me.ResourceNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "ResourceName", True))
        Me.ResourceNameTextEdit.Enabled = False
        Me.ResourceNameTextEdit.Location = New System.Drawing.Point(189, 63)
        Me.ResourceNameTextEdit.MenuManager = Me.RibbonControl1
        Me.ResourceNameTextEdit.Name = "ResourceNameTextEdit"
        Me.ResourceNameTextEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ResourceNameTextEdit.Properties.Appearance.Options.UseFont = True
        Me.ResourceNameTextEdit.Size = New System.Drawing.Size(325, 22)
        Me.ResourceNameTextEdit.StyleController = Me.DataLayoutControl1
        Me.ResourceNameTextEdit.TabIndex = 6
        '
        'CustomField1TextEdit
        '
        Me.CustomField1TextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "CustomField1", True))
        Me.CustomField1TextEdit.Location = New System.Drawing.Point(189, 89)
        Me.CustomField1TextEdit.MenuManager = Me.RibbonControl1
        Me.CustomField1TextEdit.Name = "CustomField1TextEdit"
        Me.CustomField1TextEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CustomField1TextEdit.Properties.Appearance.Options.UseFont = True
        Me.CustomField1TextEdit.Size = New System.Drawing.Size(325, 22)
        Me.CustomField1TextEdit.StyleController = Me.DataLayoutControl1
        Me.CustomField1TextEdit.TabIndex = 9
        '
        'ImagePictureEdit
        '
        Me.ImagePictureEdit.DataBindings.Add(New System.Windows.Forms.Binding("Image", Me.ResourcesBindingSource, "Image", True))
        Me.ImagePictureEdit.EditValue = Global.CC_JO.My.Resources.Resources.insertimage_32x32
        Me.ImagePictureEdit.Location = New System.Drawing.Point(12, 12)
        Me.ImagePictureEdit.MenuManager = Me.RibbonControl1
        Me.ImagePictureEdit.Name = "ImagePictureEdit"
        Me.ImagePictureEdit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ImagePictureEdit.Properties.Appearance.Options.UseFont = True
        Me.ImagePictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze
        Me.ImagePictureEdit.Size = New System.Drawing.Size(173, 102)
        Me.ImagePictureEdit.StyleController = Me.DataLayoutControl1
        Me.ImagePictureEdit.TabIndex = 11
        '
        'UserNameTextEdit
        '
        Me.UserNameTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "UserName", True))
        Me.UserNameTextEdit.Location = New System.Drawing.Point(12, 115)
        Me.UserNameTextEdit.MenuManager = Me.RibbonControl1
        Me.UserNameTextEdit.Name = "UserNameTextEdit"
        Me.UserNameTextEdit.Size = New System.Drawing.Size(602, 20)
        Me.UserNameTextEdit.StyleController = Me.DataLayoutControl1
        Me.UserNameTextEdit.TabIndex = 962
        '
        'CUserTextEdit
        '
        Me.CUserTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "CUser", True))
        Me.CUserTextEdit.Location = New System.Drawing.Point(12, 139)
        Me.CUserTextEdit.MenuManager = Me.RibbonControl1
        Me.CUserTextEdit.Name = "CUserTextEdit"
        Me.CUserTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.CUserTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.CUserTextEdit.Properties.Mask.EditMask = "N0"
        Me.CUserTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.CUserTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.CUserTextEdit.Size = New System.Drawing.Size(502, 20)
        Me.CUserTextEdit.StyleController = Me.DataLayoutControl1
        Me.CUserTextEdit.TabIndex = 963
        '
        'COUserTextEdit
        '
        Me.COUserTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "COUser", True))
        Me.COUserTextEdit.Location = New System.Drawing.Point(12, 139)
        Me.COUserTextEdit.MenuManager = Me.RibbonControl1
        Me.COUserTextEdit.Name = "COUserTextEdit"
        Me.COUserTextEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.COUserTextEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.COUserTextEdit.Properties.Mask.EditMask = "N0"
        Me.COUserTextEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.COUserTextEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.COUserTextEdit.Size = New System.Drawing.Size(502, 20)
        Me.COUserTextEdit.StyleController = Me.DataLayoutControl1
        Me.COUserTextEdit.TabIndex = 964
        '
        'ColorColorPickEdit
        '
        Me.ColorColorPickEdit.DataBindings.Add(New System.Windows.Forms.Binding("Color", Me.ResourcesBindingSource, "Color", True))
        Me.ColorColorPickEdit.EditValue = System.Drawing.Color.Empty
        Me.ColorColorPickEdit.Location = New System.Drawing.Point(189, 115)
        Me.ColorColorPickEdit.MenuManager = Me.RibbonControl1
        Me.ColorColorPickEdit.Name = "ColorColorPickEdit"
        Me.ColorColorPickEdit.Properties.Appearance.Options.UseTextOptions = True
        Me.ColorColorPickEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
        Me.ColorColorPickEdit.Properties.AutomaticColor = System.Drawing.Color.Black
        Me.ColorColorPickEdit.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.ColorColorPickEdit.Properties.Mask.EditMask = "N0"
        Me.ColorColorPickEdit.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.ColorColorPickEdit.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.ColorColorPickEdit.Size = New System.Drawing.Size(325, 20)
        Me.ColorColorPickEdit.StyleController = Me.DataLayoutControl1
        Me.ColorColorPickEdit.TabIndex = 966
        '
        'daTextEdit
        '
        Me.daTextEdit.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "da", True))
        Me.daTextEdit.Location = New System.Drawing.Point(12, 139)
        Me.daTextEdit.MenuManager = Me.RibbonControl1
        Me.daTextEdit.Name = "daTextEdit"
        Me.daTextEdit.Size = New System.Drawing.Size(502, 20)
        Me.daTextEdit.StyleController = Me.DataLayoutControl1
        Me.daTextEdit.TabIndex = 968
        '
        'TextEdit1
        '
        Me.TextEdit1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.ResourcesBindingSource, "USERNAME", True))
        Me.TextEdit1.Location = New System.Drawing.Point(189, 115)
        Me.TextEdit1.MenuManager = Me.RibbonControl1
        Me.TextEdit1.Name = "TextEdit1"
        Me.TextEdit1.Size = New System.Drawing.Size(325, 20)
        Me.TextEdit1.StyleController = Me.DataLayoutControl1
        Me.TextEdit1.TabIndex = 969
        '
        'ItemForUniqueID
        '
        Me.ItemForUniqueID.Control = Me.UniqueIDTextEdit
        Me.ItemForUniqueID.Location = New System.Drawing.Point(243, 0)
        Me.ItemForUniqueID.Name = "ItemForUniqueID"
        Me.ItemForUniqueID.Size = New System.Drawing.Size(258, 26)
        Me.ItemForUniqueID.Text = "Unique ID"
        Me.ItemForUniqueID.TextSize = New System.Drawing.Size(99, 16)
        '
        'ItemForUserName
        '
        Me.ItemForUserName.Control = Me.UserNameTextEdit
        Me.ItemForUserName.Location = New System.Drawing.Point(0, 103)
        Me.ItemForUserName.Name = "ItemForUserName"
        Me.ItemForUserName.Size = New System.Drawing.Size(679, 24)
        Me.ItemForUserName.Text = "User Name"
        Me.ItemForUserName.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForColor
        '
        Me.ItemForColor.Control = Me.ColorColorPickEdit
        Me.ItemForColor.Location = New System.Drawing.Point(177, 103)
        Me.ItemForColor.Name = "ItemForColor"
        Me.ItemForColor.Size = New System.Drawing.Size(402, 28)
        Me.ItemForColor.Text = "لون :"
        Me.ItemForColor.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForCUser
        '
        Me.ItemForCUser.Control = Me.CUserTextEdit
        Me.ItemForCUser.Location = New System.Drawing.Point(0, 127)
        Me.ItemForCUser.Name = "ItemForCUser"
        Me.ItemForCUser.Size = New System.Drawing.Size(579, 24)
        Me.ItemForCUser.Text = "CUser"
        Me.ItemForCUser.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForCOUser
        '
        Me.ItemForCOUser.Control = Me.COUserTextEdit
        Me.ItemForCOUser.Location = New System.Drawing.Point(0, 127)
        Me.ItemForCOUser.Name = "ItemForCOUser"
        Me.ItemForCOUser.Size = New System.Drawing.Size(579, 24)
        Me.ItemForCOUser.Text = "CO User"
        Me.ItemForCOUser.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForda
        '
        Me.ItemForda.Control = Me.daTextEdit
        Me.ItemForda.Location = New System.Drawing.Point(0, 127)
        Me.ItemForda.Name = "ItemForda"
        Me.ItemForda.Size = New System.Drawing.Size(579, 80)
        Me.ItemForda.Text = "da"
        Me.ItemForda.TextSize = New System.Drawing.Size(61, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TextEdit1
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 103)
        Me.LayoutControlItem2.Name = "ItemForUSERNAME"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(402, 104)
        Me.LayoutControlItem2.Text = "USERNAME"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(50, 20)
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlGroup1, Me.ItemForImage})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(599, 126)
        Me.Root.TextLocation = DevExpress.Utils.Locations.[Default]
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.AllowDrawBackground = False
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.ItemForCustomField1, Me.ItemForResourceName, Me.ItemForResourceID, Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Location = New System.Drawing.Point(177, 0)
        Me.LayoutControlGroup1.Name = "autoGeneratedGroup0"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(402, 106)
        '
        'ItemForCustomField1
        '
        Me.ItemForCustomField1.Control = Me.CustomField1TextEdit
        Me.ItemForCustomField1.Location = New System.Drawing.Point(0, 77)
        Me.ItemForCustomField1.Name = "ItemForCustomField1"
        Me.ItemForCustomField1.Size = New System.Drawing.Size(402, 29)
        Me.ItemForCustomField1.Text = "ملاحظات :"
        Me.ItemForCustomField1.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForResourceName
        '
        Me.ItemForResourceName.Control = Me.ResourceNameTextEdit
        Me.ItemForResourceName.Location = New System.Drawing.Point(0, 51)
        Me.ItemForResourceName.Name = "ItemForResourceName"
        Me.ItemForResourceName.Size = New System.Drawing.Size(402, 26)
        Me.ItemForResourceName.Text = "اسم العضو :"
        Me.ItemForResourceName.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForResourceID
        '
        Me.ItemForResourceID.Control = Me.ResourceIDTextEdit
        Me.ItemForResourceID.Location = New System.Drawing.Point(0, 25)
        Me.ItemForResourceID.Name = "ItemForResourceID"
        Me.ItemForResourceID.Size = New System.Drawing.Size(402, 26)
        Me.ItemForResourceID.Text = "رقم العضو :"
        Me.ItemForResourceID.TextSize = New System.Drawing.Size(61, 13)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.ComboCustomerName
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(402, 25)
        Me.LayoutControlItem1.Text = "اختيار العضو :"
        Me.LayoutControlItem1.TextLocation = DevExpress.Utils.Locations.Right
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(61, 13)
        '
        'ItemForImage
        '
        Me.ItemForImage.Control = Me.ImagePictureEdit
        Me.ItemForImage.Location = New System.Drawing.Point(0, 0)
        Me.ItemForImage.Name = "ItemForImage"
        Me.ItemForImage.Size = New System.Drawing.Size(177, 106)
        Me.ItemForImage.StartNewLine = True
        Me.ItemForImage.Text = "صورة"
        Me.ItemForImage.TextLocation = DevExpress.Utils.Locations.Top
        Me.ItemForImage.TextSize = New System.Drawing.Size(0, 0)
        Me.ItemForImage.TextVisible = False
        '
        'DataNavigator1
        '
        Me.DataNavigator1.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DataNavigator1.Appearance.Options.UseFont = True
        Me.DataNavigator1.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.DataNavigator1.DataSource = Me.ResourcesBindingSource
        Me.DataNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DataNavigator1.Location = New System.Drawing.Point(0, 251)
        Me.DataNavigator1.Name = "DataNavigator1"
        Me.DataNavigator1.Size = New System.Drawing.Size(599, 29)
        Me.DataNavigator1.TabIndex = 5
        Me.DataNavigator1.Text = "DataNavigator1"
        Me.DataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center
        '
        'ResourceInterface
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 302)
        Me.Controls.Add(Me.DataNavigator1)
        Me.Controls.Add(Me.DataLayoutControl1)
        Me.Controls.Add(Me.RibbonStatusBar1)
        Me.Controls.Add(Me.RibbonControl1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.IconOptions.Image = Global.CC_JO.My.Resources.Resources.logCO12
        Me.Name = "ResourceInterface"
        Me.Ribbon = Me.RibbonControl1
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.StatusBar = Me.RibbonStatusBar1
        Me.Text = "اعضاء الإدارة"
        CType(Me.RibbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSetScheduler, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResourcesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataLayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DataLayoutControl1.ResumeLayout(False)
        CType(Me.UniqueIDTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResourceIDTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ResourceNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomField1TextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImagePictureEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UserNameTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CUserTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.COUserTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ColorColorPickEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.daTextEdit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForUniqueID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForUserName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForCUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForCOUser, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForda, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForCustomField1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForResourceName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForResourceID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ItemForImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RibbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Friend WithEvents RibbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents RibbonStatusBar1 As DevExpress.XtraBars.Ribbon.RibbonStatusBar
    Friend WithEvents RibbonPage2 As DevExpress.XtraBars.Ribbon.RibbonPage
    Friend WithEvents DataSetScheduler As DataSetScheduler
    Friend WithEvents ResourcesBindingSource As BindingSource
    Friend WithEvents ResourcesTableAdapter As DataSetSchedulerTableAdapters.ResourcesTableAdapter
    Friend WithEvents DataLayoutControl1 As DevExpress.XtraDataLayout.DataLayoutControl
    Friend WithEvents UniqueIDTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ResourceIDTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ResourceNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CustomField1TextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents ItemForResourceName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForUniqueID As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForColor As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BarButtonItem1 As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents ButtonEdit As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents DataNavigator1 As DevExpress.XtraEditors.DataNavigator
    Friend WithEvents ItemForResourceID As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForCustomField1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForImage As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ImagePictureEdit As DevExpress.XtraEditors.PictureEdit
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ComboCustomerName As ComboBox
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents UserNameTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CUserTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents COUserTextEdit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ItemForUserName As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForCUser As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForCOUser As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ItemForda As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColorColorPickEdit As DevExpress.XtraEditors.ColorPickEdit
    Friend WithEvents daTextEdit As DevExpress.XtraEditors.TextEdit
    Private WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents TextEdit1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class
