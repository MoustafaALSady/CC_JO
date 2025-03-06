<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Calculatorform
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
<<<<<<< HEAD
        Dim EditorButtonImageOptions1 As DevExpress.XtraEditors.Controls.EditorButtonImageOptions = New DevExpress.XtraEditors.Controls.EditorButtonImageOptions()
        Dim SerializableAppearanceObject1 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject2 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject3 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim SerializableAppearanceObject4 As DevExpress.Utils.SerializableAppearanceObject = New DevExpress.Utils.SerializableAppearanceObject()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calculatorform))
        Me.CalcEdit1 = New DevExpress.XtraEditors.CalcEdit()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.CalcEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'CalcEdit1
        '
        Me.CalcEdit1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CalcEdit1.EnterMoveNextControl = True
        Me.CalcEdit1.Location = New System.Drawing.Point(0, 25)
        Me.CalcEdit1.Name = "CalcEdit1"
        Me.CalcEdit1.Properties.Appearance.BackColor = System.Drawing.Color.White
        Me.CalcEdit1.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcEdit1.Properties.Appearance.ForeColor = System.Drawing.Color.Black
        Me.CalcEdit1.Properties.Appearance.Options.UseBackColor = True
        Me.CalcEdit1.Properties.Appearance.Options.UseFont = True
        Me.CalcEdit1.Properties.Appearance.Options.UseForeColor = True
        Me.CalcEdit1.Properties.AppearanceDisabled.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcEdit1.Properties.AppearanceDisabled.Options.UseFont = True
        Me.CalcEdit1.Properties.AppearanceDropDown.Font = New System.Drawing.Font("Times New Roman", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcEdit1.Properties.AppearanceDropDown.Options.UseFont = True
        Me.CalcEdit1.Properties.AppearanceFocused.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcEdit1.Properties.AppearanceFocused.Options.UseFont = True
        Me.CalcEdit1.Properties.AppearanceReadOnly.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalcEdit1.Properties.AppearanceReadOnly.Options.UseFont = True
        Me.CalcEdit1.Properties.BeepOnError = False
        EditorButtonImageOptions1.Image = Global.CC_JO.My.Resources.Resources.addcalculatedfield_16x16
        Me.CalcEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, True, True, True, EditorButtonImageOptions1, New DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), SerializableAppearanceObject1, SerializableAppearanceObject2, SerializableAppearanceObject3, SerializableAppearanceObject4, "", Nothing, Nothing, DevExpress.Utils.ToolTipAnchor.[Object])})
        Me.CalcEdit1.Properties.MaskSettings.Set("mask", "f3")
        Me.CalcEdit1.Properties.NullText = "0"
        Me.CalcEdit1.Properties.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.DoubleClick
        Me.CalcEdit1.Properties.UseMaskAsDisplayFormat = True
        Me.CalcEdit1.Properties.ValidateOnEnterKey = True
        Me.CalcEdit1.Size = New System.Drawing.Size(397, 28)
        Me.CalcEdit1.TabIndex = 0
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(397, 25)
        Me.Panel4.TabIndex = 933
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.CC_JO.My.Resources.Resources.calculatenow_16x16
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label3.Size = New System.Drawing.Size(395, 24)
        Me.Label3.TabIndex = 763
        Me.Label3.Text = "حــاســـــبـة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Calculatorform
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(397, 296)
        Me.Controls.Add(Me.CalcEdit1)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Calculatorform"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "حاسبة"
        CType(Me.CalcEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CalcEdit1 As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
=======
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Calculatorform))
        Me.Calculator1 = New DevComponents.Editors.Calculator()
        Me.SuspendLayout()
        '
        'Calculator1
        '
        Me.Calculator1.AutoSize = True
        Me.Calculator1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Calculator1.Location = New System.Drawing.Point(0, 0)
        Me.Calculator1.Name = "Calculator1"
        Me.Calculator1.Size = New System.Drawing.Size(190, 211)
        Me.Calculator1.Text = "Calculator1"
        '
        'calculatorform
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(191, 216)
        Me.Controls.Add(Me.Calculator1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "calculatorform"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "حاسبة"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Calculator1 As DevComponents.Editors.Calculator
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
End Class
