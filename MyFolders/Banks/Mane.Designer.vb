<<<<<<< HEAD
﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Mane
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
=======
﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class mane
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
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
<<<<<<< HEAD
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Mane))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextPermissionNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TEXTValues = New DevExpress.XtraEditors.TextEdit()
        Me.Panel1.SuspendLayout()
        CType(Me.TEXTValues.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
=======
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(mane))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TEXTValues = New System.Windows.Forms.TextBox()
        Me.TextPermissionNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(147, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "المبلغ المرد تحويله"
        '
<<<<<<< HEAD
=======
        'TEXTValues
        '
        Me.TEXTValues.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTValues.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXTValues.ForeColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.TEXTValues.Location = New System.Drawing.Point(3, 7)
        Me.TEXTValues.Name = "TEXTValues"
        Me.TEXTValues.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTValues.Size = New System.Drawing.Size(141, 22)
        Me.TEXTValues.TabIndex = 1
        '
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        'TextPermissionNumber
        '
        Me.TextPermissionNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPermissionNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPermissionNumber.Location = New System.Drawing.Point(3, 31)
        Me.TextPermissionNumber.Name = "TextPermissionNumber"
        Me.TextPermissionNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextPermissionNumber.Size = New System.Drawing.Size(141, 22)
        Me.TextPermissionNumber.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(162, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "رقم حركة البنك"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TEXTValues)
        Me.Panel1.Controls.Add(Me.TextPermissionNumber)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(5, 6)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(238, 63)
        Me.Panel1.TabIndex = 6
        '
<<<<<<< HEAD
        'TEXTValues
        '
        Me.TEXTValues.EditValue = "0"
        Me.TEXTValues.Location = New System.Drawing.Point(3, 8)
        Me.TEXTValues.Name = "TEXTValues"
        Me.TEXTValues.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTValues.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.TEXTValues.Properties.Appearance.Options.UseFont = True
        Me.TEXTValues.Properties.Appearance.Options.UseTextOptions = True
        Me.TEXTValues.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEXTValues.Properties.BeepOnError = False
        Me.TEXTValues.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TEXTValues.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TEXTValues.Properties.MaskSettings.Set("mask", "f3")
        Me.TEXTValues.Properties.UseMaskAsDisplayFormat = True
        Me.TEXTValues.Size = New System.Drawing.Size(141, 22)
        Me.TEXTValues.TabIndex = 959
        '
        'Mane
=======
        'mane
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
<<<<<<< HEAD
        Me.ClientSize = New System.Drawing.Size(248, 73)
=======
        Me.ClientSize = New System.Drawing.Size(248, 74)
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
<<<<<<< HEAD
        Me.Name = "Mane"
=======
        Me.Name = "mane"
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تحويل نقدا"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
<<<<<<< HEAD
        CType(Me.TEXTValues.Properties, System.ComponentModel.ISupportInitialize).EndInit()
=======
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
<<<<<<< HEAD
    Friend WithEvents TextPermissionNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TEXTValues As DevExpress.XtraEditors.TextEdit
=======
    Friend WithEvents TEXTValues As System.Windows.Forms.TextBox
    Friend WithEvents TextPermissionNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
>>>>>>> c3c12be08c1593ad8bd7ed80a18e0ca7a526c28c
End Class
