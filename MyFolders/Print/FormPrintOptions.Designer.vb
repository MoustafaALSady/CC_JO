<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPrintOptions
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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TextNumOfCopy = New System.Windows.Forms.NumericUpDown()
        Me.LabelSelectedPrinter = New System.Windows.Forms.Label()
        Me.ChPreview = New System.Windows.Forms.CheckBox()
        Me.CombPrinters = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CombRecords = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CombPaperSize = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CombPageOrientation = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CombSamples = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextLeftMargin = New System.Windows.Forms.NumericUpDown()
        Me.TextBottonMargin = New System.Windows.Forms.NumericUpDown()
        Me.TextRightMargin = New System.Windows.Forms.NumericUpDown()
        Me.TextTopMargin = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CheckAdjustPageMargin = New System.Windows.Forms.CheckBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ButCancel = New System.Windows.Forms.Button()
        Me.ButOK = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.TextNumOfCopy, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TextLeftMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBottonMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextRightMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextTopMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabControl1.RightToLeftLayout = True
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(473, 178)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage1.Controls.Add(Me.Panel3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TabPage1.Size = New System.Drawing.Size(465, 150)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "الخيارات الاسياسية"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TextNumOfCopy)
        Me.Panel3.Controls.Add(Me.LabelSelectedPrinter)
        Me.Panel3.Controls.Add(Me.ChPreview)
        Me.Panel3.Controls.Add(Me.CombPrinters)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.CombRecords)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.CombPaperSize)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.CombPageOrientation)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.CombSamples)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Location = New System.Drawing.Point(4, 5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(455, 139)
        Me.Panel3.TabIndex = 13
        '
        'TextNumOfCopy
        '
        Me.TextNumOfCopy.Location = New System.Drawing.Point(235, 85)
        Me.TextNumOfCopy.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextNumOfCopy.Name = "TextNumOfCopy"
        Me.TextNumOfCopy.Size = New System.Drawing.Size(160, 22)
        Me.TextNumOfCopy.TabIndex = 14
        Me.TextNumOfCopy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.TextNumOfCopy.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'LabelSelectedPrinter
        '
        Me.LabelSelectedPrinter.AutoSize = True
        Me.LabelSelectedPrinter.ForeColor = System.Drawing.Color.MidnightBlue
        Me.LabelSelectedPrinter.Location = New System.Drawing.Point(0, 93)
        Me.LabelSelectedPrinter.Name = "LabelSelectedPrinter"
        Me.LabelSelectedPrinter.Size = New System.Drawing.Size(94, 15)
        Me.LabelSelectedPrinter.TabIndex = 13
        Me.LabelSelectedPrinter.Text = "SelectedPrinter"
        Me.LabelSelectedPrinter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ChPreview
        '
        Me.ChPreview.AutoSize = True
        Me.ChPreview.Location = New System.Drawing.Point(291, 116)
        Me.ChPreview.Name = "ChPreview"
        Me.ChPreview.Size = New System.Drawing.Size(104, 19)
        Me.ChPreview.TabIndex = 0
        Me.ChPreview.Text = "معاينة قبل الطباعة"
        Me.ChPreview.UseVisualStyleBackColor = True
        '
        'CombPrinters
        '
        Me.CombPrinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombPrinters.FormattingEnabled = True
        Me.CombPrinters.Location = New System.Drawing.Point(2, 7)
        Me.CombPrinters.Name = "CombPrinters"
        Me.CombPrinters.Size = New System.Drawing.Size(393, 23)
        Me.CombPrinters.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(401, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 15)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "عدد النسخ"
        '
        'CombRecords
        '
        Me.CombRecords.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombRecords.FormattingEnabled = True
        Me.CombRecords.Items.AddRange(New Object() {"جميع االسجلات", "السجل المحدد"})
        Me.CombRecords.Location = New System.Drawing.Point(235, 60)
        Me.CombRecords.Name = "CombRecords"
        Me.CombRecords.Size = New System.Drawing.Size(160, 23)
        Me.CombRecords.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(146, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 15)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "النمموذج"
        '
        'CombPaperSize
        '
        Me.CombPaperSize.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.CombPaperSize.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CombPaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombPaperSize.FormattingEnabled = True
        Me.CombPaperSize.Location = New System.Drawing.Point(235, 34)
        Me.CombPaperSize.Name = "CombPaperSize"
        Me.CombPaperSize.Size = New System.Drawing.Size(160, 23)
        Me.CombPaperSize.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(146, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "تخطيط الصفحة"
        '
        'CombPageOrientation
        '
        Me.CombPageOrientation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombPageOrientation.FormattingEnabled = True
        Me.CombPageOrientation.Items.AddRange(New Object() {"افتراضي", "راسي", "افقي"})
        Me.CombPageOrientation.Location = New System.Drawing.Point(2, 34)
        Me.CombPageOrientation.Name = "CombPageOrientation"
        Me.CombPageOrientation.Size = New System.Drawing.Size(138, 23)
        Me.CombPageOrientation.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(408, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 15)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "السجلات"
        '
        'CombSamples
        '
        Me.CombSamples.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CombSamples.FormattingEnabled = True
        Me.CombSamples.Items.AddRange(New Object() {"النموذج رقم (1)"})
        Me.CombSamples.Location = New System.Drawing.Point(2, 60)
        Me.CombSamples.Name = "CombSamples"
        Me.CombSamples.Size = New System.Drawing.Size(138, 23)
        Me.CombSamples.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(395, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "حجم الورقة"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(395, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "اسم الطابعة"
        '
        'TabPage2
        '
        Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.CheckAdjustPageMargin)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(465, 150)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "خيارات اخرى"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(184, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(274, 114)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "هوامش الصفحة"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.TextLeftMargin)
        Me.Panel2.Controls.Add(Me.TextBottonMargin)
        Me.Panel2.Controls.Add(Me.TextRightMargin)
        Me.Panel2.Controls.Add(Me.TextTopMargin)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(268, 93)
        Me.Panel2.TabIndex = 0
        '
        'TextLeftMargin
        '
        Me.TextLeftMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextLeftMargin.DecimalPlaces = 3
        Me.TextLeftMargin.Location = New System.Drawing.Point(7, 55)
        Me.TextLeftMargin.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextLeftMargin.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.TextLeftMargin.Name = "TextLeftMargin"
        Me.TextLeftMargin.Size = New System.Drawing.Size(54, 22)
        Me.TextLeftMargin.TabIndex = 15
        Me.TextLeftMargin.Value = New Decimal(New Integer() {201, 0, 0, 196608})
        '
        'TextBottonMargin
        '
        Me.TextBottonMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBottonMargin.DecimalPlaces = 3
        Me.TextBottonMargin.Location = New System.Drawing.Point(7, 14)
        Me.TextBottonMargin.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextBottonMargin.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.TextBottonMargin.Name = "TextBottonMargin"
        Me.TextBottonMargin.Size = New System.Drawing.Size(54, 22)
        Me.TextBottonMargin.TabIndex = 14
        Me.TextBottonMargin.Value = New Decimal(New Integer() {201, 0, 0, 196608})
        '
        'TextRightMargin
        '
        Me.TextRightMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRightMargin.DecimalPlaces = 3
        Me.TextRightMargin.Location = New System.Drawing.Point(140, 55)
        Me.TextRightMargin.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextRightMargin.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.TextRightMargin.Name = "TextRightMargin"
        Me.TextRightMargin.Size = New System.Drawing.Size(54, 22)
        Me.TextRightMargin.TabIndex = 13
        Me.TextRightMargin.Value = New Decimal(New Integer() {201, 0, 0, 196608})
        '
        'TextTopMargin
        '
        Me.TextTopMargin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextTopMargin.DecimalPlaces = 3
        Me.TextTopMargin.Location = New System.Drawing.Point(140, 14)
        Me.TextTopMargin.Maximum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.TextTopMargin.Minimum = New Decimal(New Integer() {1, 0, 0, -2147483648})
        Me.TextTopMargin.Name = "TextTopMargin"
        Me.TextTopMargin.Size = New System.Drawing.Size(54, 22)
        Me.TextTopMargin.TabIndex = 12
        Me.TextTopMargin.Value = New Decimal(New Integer() {201, 0, 0, 196608})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(65, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(63, 15)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "يسار الصفحة"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(65, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "اسفل الصفحة"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(197, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "يمين الصفحة"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(197, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 15)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "اعلى الصفحة"
        '
        'CheckAdjustPageMargin
        '
        Me.CheckAdjustPageMargin.AutoSize = True
        Me.CheckAdjustPageMargin.Location = New System.Drawing.Point(339, 9)
        Me.CheckAdjustPageMargin.Name = "CheckAdjustPageMargin"
        Me.CheckAdjustPageMargin.Size = New System.Drawing.Size(119, 19)
        Me.CheckAdjustPageMargin.TabIndex = 1
        Me.CheckAdjustPageMargin.Text = "تعديل هوامش الصفحة"
        Me.CheckAdjustPageMargin.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ButCancel)
        Me.Panel1.Controls.Add(Me.ButOK)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 178)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(473, 31)
        Me.Panel1.TabIndex = 1
        '
        'ButCancel
        '
        Me.ButCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButCancel.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.ButCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButCancel.Location = New System.Drawing.Point(2, 3)
        Me.ButCancel.Name = "ButCancel"
        Me.ButCancel.Size = New System.Drawing.Size(232, 23)
        Me.ButCancel.TabIndex = 1
        Me.ButCancel.Text = "إلغاء الامر"
        Me.ButCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCancel.UseVisualStyleBackColor = True
        '
        'ButOK
        '
        Me.ButOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButOK.Image = Global.CC_JO.My.Resources.Resources.accept
        Me.ButOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButOK.Location = New System.Drawing.Point(235, 3)
        Me.ButOK.Name = "ButOK"
        Me.ButOK.Size = New System.Drawing.Size(233, 23)
        Me.ButOK.TabIndex = 0
        Me.ButOK.Text = "موفق"
        Me.ButOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButOK.UseVisualStyleBackColor = True
        '
        'FormPrintOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(473, 209)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPrintOptions"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "خيارات الطباعة"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TextNumOfCopy, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TextLeftMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBottonMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextRightMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextTopMargin, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CombSamples As ComboBox
    Friend WithEvents CombPageOrientation As ComboBox
    Friend WithEvents CombPaperSize As ComboBox
    Friend WithEvents CombRecords As ComboBox
    Friend WithEvents CombPrinters As ComboBox
    Friend WithEvents ChPreview As CheckBox
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextLeftMargin As NumericUpDown
    Friend WithEvents TextBottonMargin As NumericUpDown
    Friend WithEvents TextRightMargin As NumericUpDown
    Friend WithEvents TextTopMargin As NumericUpDown
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents CheckAdjustPageMargin As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ButCancel As Button
    Friend WithEvents ButOK As Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LabelSelectedPrinter As Label
    Friend WithEvents TextNumOfCopy As NumericUpDown
End Class
