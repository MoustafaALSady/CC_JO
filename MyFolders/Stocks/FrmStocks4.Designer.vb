<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStocks4
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmStocks4))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.RBItemCode = New System.Windows.Forms.RadioButton()
        Me.RBnvoiceNumber = New System.Windows.Forms.RadioButton()
        Me.RBPermissionNumber = New System.Windows.Forms.RadioButton()
        Me.RBITEMNAME = New System.Windows.Forms.RadioButton()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.RBQR = New System.Windows.Forms.RadioButton()
        Me.RBST = New System.Windows.Forms.RadioButton()
        Me.RBVE = New System.Windows.Forms.RadioButton()
        Me.RBPR = New System.Windows.Forms.RadioButton()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TextMovementSymbol1 = New DevExpress.XtraEditors.LabelControl()
        Me.TextWarehouseName = New System.Windows.Forms.Label()
        Me.ComboStore = New System.Windows.Forms.ComboBox()
        Me.SearchBUTTON = New System.Windows.Forms.Button()
        Me.Texser = New System.Windows.Forms.TextBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.SteelBlue
        Me.GroupBox1.Location = New System.Drawing.Point(1, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(347, 284)
        Me.GroupBox1.TabIndex = 42
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات البحث"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupControl2)
        Me.Panel1.Controls.Add(Me.GroupControl1)
        Me.Panel1.Controls.Add(Me.GroupBox5)
        Me.Panel1.Controls.Add(Me.SearchBUTTON)
        Me.Panel1.Controls.Add(Me.Texser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(341, 260)
        Me.Panel1.TabIndex = 763
        '
        'GroupControl2
        '
        Me.GroupControl2.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.GroupControl2.Appearance.Options.UseBackColor = True
        Me.GroupControl2.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl2.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl2.Controls.Add(Me.RBItemCode)
        Me.GroupControl2.Controls.Add(Me.RBnvoiceNumber)
        Me.GroupControl2.Controls.Add(Me.RBPermissionNumber)
        Me.GroupControl2.Controls.Add(Me.RBITEMNAME)
        Me.GroupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl2.Location = New System.Drawing.Point(6, 65)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(189, 125)
        Me.GroupControl2.TabIndex = 981
        Me.GroupControl2.Text = "اختيار"
        '
        'RBItemCode
        '
        Me.RBItemCode.AutoSize = True
        Me.RBItemCode.BackColor = System.Drawing.Color.Transparent
        Me.RBItemCode.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RBItemCode.Checked = True
        Me.RBItemCode.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBItemCode.ForeColor = System.Drawing.Color.Blue
        Me.RBItemCode.Location = New System.Drawing.Point(105, 29)
        Me.RBItemCode.Name = "RBItemCode"
        Me.RBItemCode.Size = New System.Drawing.Size(73, 19)
        Me.RBItemCode.TabIndex = 649
        Me.RBItemCode.TabStop = True
        Me.RBItemCode.Text = "رقم الصنف"
        Me.RBItemCode.UseVisualStyleBackColor = False
        '
        'RBnvoiceNumber
        '
        Me.RBnvoiceNumber.AutoSize = True
        Me.RBnvoiceNumber.BackColor = System.Drawing.Color.Transparent
        Me.RBnvoiceNumber.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RBnvoiceNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBnvoiceNumber.ForeColor = System.Drawing.Color.Blue
        Me.RBnvoiceNumber.Location = New System.Drawing.Point(102, 63)
        Me.RBnvoiceNumber.Name = "RBnvoiceNumber"
        Me.RBnvoiceNumber.Size = New System.Drawing.Size(76, 19)
        Me.RBnvoiceNumber.TabIndex = 651
        Me.RBnvoiceNumber.Text = "رقم الفاتورة"
        Me.RBnvoiceNumber.UseVisualStyleBackColor = False
        '
        'RBPermissionNumber
        '
        Me.RBPermissionNumber.AutoSize = True
        Me.RBPermissionNumber.BackColor = System.Drawing.Color.Transparent
        Me.RBPermissionNumber.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RBPermissionNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBPermissionNumber.ForeColor = System.Drawing.Color.Blue
        Me.RBPermissionNumber.Location = New System.Drawing.Point(19, 63)
        Me.RBPermissionNumber.Name = "RBPermissionNumber"
        Me.RBPermissionNumber.Size = New System.Drawing.Size(63, 19)
        Me.RBPermissionNumber.TabIndex = 652
        Me.RBPermissionNumber.Text = "رقم الاذن"
        Me.RBPermissionNumber.UseVisualStyleBackColor = False
        '
        'RBITEMNAME
        '
        Me.RBITEMNAME.AutoSize = True
        Me.RBITEMNAME.BackColor = System.Drawing.Color.Transparent
        Me.RBITEMNAME.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RBITEMNAME.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RBITEMNAME.ForeColor = System.Drawing.Color.Blue
        Me.RBITEMNAME.Location = New System.Drawing.Point(6, 27)
        Me.RBITEMNAME.Name = "RBITEMNAME"
        Me.RBITEMNAME.Size = New System.Drawing.Size(74, 19)
        Me.RBITEMNAME.TabIndex = 650
        Me.RBITEMNAME.Text = "اسم الصنف"
        Me.RBITEMNAME.UseVisualStyleBackColor = False
        '
        'GroupControl1
        '
        Me.GroupControl1.Appearance.BackColor = System.Drawing.Color.Transparent
        Me.GroupControl1.Appearance.Options.UseBackColor = True
        Me.GroupControl1.AppearanceCaption.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.GroupControl1.AppearanceCaption.Options.UseFont = True
        Me.GroupControl1.AutoSize = True
        Me.GroupControl1.CaptionImageOptions.Image = CType(resources.GetObject("GroupControl1.CaptionImageOptions.Image"), System.Drawing.Image)
        Me.GroupControl1.CaptionLocation = DevExpress.Utils.Locations.Top
        Me.GroupControl1.Controls.Add(Me.RBQR)
        Me.GroupControl1.Controls.Add(Me.RBST)
        Me.GroupControl1.Controls.Add(Me.RBVE)
        Me.GroupControl1.Controls.Add(Me.RBPR)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(196, 65)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(137, 125)
        Me.GroupControl1.TabIndex = 980
        Me.GroupControl1.Text = "خيارات البحث"
        '
        'RBQR
        '
        Me.RBQR.AutoSize = True
        Me.RBQR.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBQR.ForeColor = System.Drawing.Color.SteelBlue
        Me.RBQR.Location = New System.Drawing.Point(17, 76)
        Me.RBQR.Name = "RBQR"
        Me.RBQR.Size = New System.Drawing.Size(106, 21)
        Me.RBQR.TabIndex = 3
        Me.RBQR.Text = "المبيعات اليومية"
        Me.RBQR.UseVisualStyleBackColor = True
        '
        'RBST
        '
        Me.RBST.AutoSize = True
        Me.RBST.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBST.ForeColor = System.Drawing.Color.SteelBlue
        Me.RBST.Location = New System.Drawing.Point(13, 101)
        Me.RBST.Name = "RBST"
        Me.RBST.Size = New System.Drawing.Size(110, 21)
        Me.RBST.TabIndex = 2
        Me.RBST.Text = "حركات المستودع"
        Me.RBST.UseVisualStyleBackColor = True
        '
        'RBVE
        '
        Me.RBVE.AutoSize = True
        Me.RBVE.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBVE.ForeColor = System.Drawing.Color.SteelBlue
        Me.RBVE.Location = New System.Drawing.Point(56, 52)
        Me.RBVE.Name = "RBVE"
        Me.RBVE.Size = New System.Drawing.Size(67, 21)
        Me.RBVE.TabIndex = 1
        Me.RBVE.Text = "المبيعات"
        Me.RBVE.UseVisualStyleBackColor = True
        '
        'RBPR
        '
        Me.RBPR.AutoSize = True
        Me.RBPR.Checked = True
        Me.RBPR.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RBPR.ForeColor = System.Drawing.Color.SteelBlue
        Me.RBPR.Location = New System.Drawing.Point(46, 27)
        Me.RBPR.Name = "RBPR"
        Me.RBPR.Size = New System.Drawing.Size(77, 21)
        Me.RBPR.TabIndex = 0
        Me.RBPR.TabStop = True
        Me.RBPR.Text = "المشتريات"
        Me.RBPR.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.TextMovementSymbol1)
        Me.GroupBox5.Controls.Add(Me.TextWarehouseName)
        Me.GroupBox5.Controls.Add(Me.ComboStore)
        Me.GroupBox5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox5.ForeColor = System.Drawing.Color.Black
        Me.GroupBox5.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(333, 57)
        Me.GroupBox5.TabIndex = 978
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "اختيار المستودع"
        '
        'TextMovementSymbol1
        '
        Me.TextMovementSymbol1.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.TextMovementSymbol1.Appearance.Font = New System.Drawing.Font("Trebuchet MS", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMovementSymbol1.Appearance.ForeColor = System.Drawing.Color.White
        Me.TextMovementSymbol1.Appearance.Options.UseBackColor = True
        Me.TextMovementSymbol1.Appearance.Options.UseFont = True
        Me.TextMovementSymbol1.Appearance.Options.UseForeColor = True
        Me.TextMovementSymbol1.Location = New System.Drawing.Point(174, 7)
        Me.TextMovementSymbol1.Name = "TextMovementSymbol1"
        Me.TextMovementSymbol1.Size = New System.Drawing.Size(20, 20)
        Me.TextMovementSymbol1.TabIndex = 982
        Me.TextMovementSymbol1.Text = "NA"
        '
        'TextWarehouseName
        '
        Me.TextWarehouseName.BackColor = System.Drawing.Color.SteelBlue
        Me.TextWarehouseName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextWarehouseName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TextWarehouseName.ForeColor = System.Drawing.Color.Yellow
        Me.TextWarehouseName.Location = New System.Drawing.Point(3, 31)
        Me.TextWarehouseName.Name = "TextWarehouseName"
        Me.TextWarehouseName.Size = New System.Drawing.Size(327, 23)
        Me.TextWarehouseName.TabIndex = 980
        Me.TextWarehouseName.Text = "....."
        Me.TextWarehouseName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ComboStore
        '
        Me.ComboStore.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboStore.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboStore.BackColor = System.Drawing.Color.White
        Me.ComboStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStore.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboStore.ForeColor = System.Drawing.Color.Black
        Me.ComboStore.Location = New System.Drawing.Point(3, 5)
        Me.ComboStore.Name = "ComboStore"
        Me.ComboStore.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ComboStore.Size = New System.Drawing.Size(169, 23)
        Me.ComboStore.TabIndex = 958
        '
        'SearchBUTTON
        '
        Me.SearchBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SearchBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.btn1
        Me.SearchBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SearchBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SearchBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SearchBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SearchBUTTON.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SearchBUTTON.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.SearchBUTTON.Location = New System.Drawing.Point(6, 219)
        Me.SearchBUTTON.Name = "SearchBUTTON"
        Me.SearchBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchBUTTON.Size = New System.Drawing.Size(328, 35)
        Me.SearchBUTTON.TabIndex = 762
        Me.SearchBUTTON.Text = "ابـحـــث"
        Me.SearchBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SearchBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SearchBUTTON.UseCompatibleTextRendering = True
        Me.SearchBUTTON.UseVisualStyleBackColor = False
        '
        'Texser
        '
        Me.Texser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Texser.Cursor = System.Windows.Forms.Cursors.Default
        Me.Texser.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Texser.ForeColor = System.Drawing.Color.Blue
        Me.Texser.Location = New System.Drawing.Point(6, 195)
        Me.Texser.Name = "Texser"
        Me.Texser.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Texser.Size = New System.Drawing.Size(327, 22)
        Me.Texser.TabIndex = 43
        Me.Texser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmStocks4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(349, 292)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmStocks4"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "البحث عن حركات الاصناف"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        Me.GroupControl2.PerformLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        Me.GroupControl1.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Texser As System.Windows.Forms.TextBox
    Friend WithEvents RBPermissionNumber As System.Windows.Forms.RadioButton
    Friend WithEvents RBnvoiceNumber As System.Windows.Forms.RadioButton
    Friend WithEvents RBITEMNAME As System.Windows.Forms.RadioButton
    Friend WithEvents RBItemCode As System.Windows.Forms.RadioButton
    Friend WithEvents SearchBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents TextWarehouseName As Label
    Friend WithEvents ComboStore As ComboBox
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents RBST As RadioButton
    Friend WithEvents RBVE As RadioButton
    Friend WithEvents RBPR As RadioButton
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents TextMovementSymbol1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents RBQR As RadioButton
End Class
