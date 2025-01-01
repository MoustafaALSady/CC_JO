<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormUserSettings
    Inherits DevExpress.XtraEditors.XtraForm

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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUserSettings))
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim EditorButtonImageOptions2 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject5 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject6 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject7 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject8 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Me.GroupHoompage = New DevExpress.XtraEditors.GroupControl()
        Me.TextSettings = New DevExpress.XtraEditors.TextEdit()
        Me.ButtonDefault = New DevExpress.XtraEditors.ButtonEdit()
        Me.ButtonSet = New DevExpress.XtraEditors.ButtonEdit()
        CType(Me.GroupHoompage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupHoompage.SuspendLayout()
        CType(Me.TextSettings.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonDefault.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ButtonSet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupHoompage
        '
        Me.GroupHoompage.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupHoompage.CaptionImageOptions.Image = CType(resources.GetObject("GroupHoomBage.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupHoompage.Controls.Add(Me.TextSettings)
        Me.GroupHoompage.Controls.Add(Me.ButtonDefault)
        Me.GroupHoompage.Controls.Add(Me.ButtonSet)
        Me.GroupHoompage.Location = New System.Drawing.Point(3, 4)
        Me.GroupHoompage.Name = "GroupHoompage"
        Me.GroupHoompage.Size = New System.Drawing.Size(393, 107)
        Me.GroupHoompage.TabIndex = 1
        Me.GroupHoompage.Text = "Hoom page"
        '
        'TextSettings
        '
        Me.TextSettings.EditValue = ""
        Me.TextSettings.Location = New System.Drawing.Point(11, 43)
        Me.TextSettings.Name = "TextSettings"
        Me.TextSettings.Size = New System.Drawing.Size(377, 20)
        Me.TextSettings.TabIndex = 2
        '
        'ButtonDefault
        '
        Me.ButtonDefault.EditValue = "Default"
        Me.ButtonDefault.Location = New System.Drawing.Point(11, 71)
        Me.ButtonDefault.Name = "ButtonDefault"
        Me.ButtonDefault.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        EditorButtonImageOptions1.Image = CType(resources.GetObject("EditorButtonImageOptions1.Image"), System.Drawing.Image)
        Me.ButtonDefault.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Default", -1, True, True, False, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.ButtonDefault.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.ButtonDefault.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.ButtonDefault.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonDefault.Size = New System.Drawing.Size(86, 24)
        Me.ButtonDefault.TabIndex = 1
        '
        'ButtonSet
        '
        Me.ButtonSet.EditValue = "Set"
        Me.ButtonSet.Location = New System.Drawing.Point(306, 71)
        Me.ButtonSet.Name = "ButtonSet"
        Me.ButtonSet.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        EditorButtonImageOptions2.Image = Global.CC_JO.My.Resources.Resources.build_16x16
        Me.ButtonSet.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, False, EditorButtonImageOptions2, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject5, SerializableAppearanceObject6, SerializableAppearanceObject7, SerializableAppearanceObject8, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Default])})
        Me.ButtonSet.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat
        Me.ButtonSet.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor
        Me.ButtonSet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonSet.Size = New System.Drawing.Size(82, 24)
        Me.ButtonSet.TabIndex = 0
        '
        'FormUserSettings
        '
        Me.Appearance.Options.UseFont = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(398, 115)
        Me.Controls.Add(Me.GroupHoompage)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.IconOptions.Image = Global.CC_JO.My.Resources.Resources.logCO5
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormUserSettings"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Settings"
        CType(Me.GroupHoompage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupHoompage.ResumeLayout(False)
        CType(Me.TextSettings.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonDefault.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ButtonSet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupHoompage As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TextSettings As DevExpress.XtraEditors.TextEdit
    Friend WithEvents ButtonDefault As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents ButtonSet As DevExpress.XtraEditors.ButtonEdit
End Class
