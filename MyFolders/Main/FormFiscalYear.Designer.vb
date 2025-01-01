<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFiscalYear
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFiscalYear))
        Me.label11 = New System.Windows.Forms.Label()
        Me.label6 = New System.Windows.Forms.Label()
        Me.label5 = New System.Windows.Forms.Label()
        Me.CheckActiveFiscalYear = New System.Windows.Forms.CheckBox()
        Me.TextYear1 = New System.Windows.Forms.TextBox()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.OpeningDate = New System.Windows.Forms.DateTimePicker()
        Me.FinalDate = New System.Windows.Forms.DateTimePicker()
        Me.CurrentDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.btnLastPage = New System.Windows.Forms.Button()
        Me.txtDisplayPageNo = New System.Windows.Forms.TextBox()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.btnFirstPage = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.EDITBUTTON = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TextFiscalYear = New System.Windows.Forms.Label()
        Me.TextYear = New System.Windows.Forms.Label()
        Me.Textcouser = New System.Windows.Forms.TextBox()
        Me.Textcuser = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'label11
        '
        Me.label11.AutoSize = True
        Me.label11.BackColor = System.Drawing.Color.Transparent
        Me.label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label11.Location = New System.Drawing.Point(308, 6)
        Me.label11.Name = "label11"
        Me.label11.Size = New System.Drawing.Size(67, 15)
        Me.label11.TabIndex = 7
        Me.label11.Text = "التاريخ الحالي"
        '
        'label6
        '
        Me.label6.AutoSize = True
        Me.label6.BackColor = System.Drawing.Color.Transparent
        Me.label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label6.Location = New System.Drawing.Point(304, 53)
        Me.label6.Name = "label6"
        Me.label6.Size = New System.Drawing.Size(71, 15)
        Me.label6.TabIndex = 4
        Me.label6.Text = "التاريخ النهائي"
        '
        'label5
        '
        Me.label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.label5.AutoSize = True
        Me.label5.BackColor = System.Drawing.Color.Transparent
        Me.label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label5.Location = New System.Drawing.Point(239, 37)
        Me.label5.Name = "label5"
        Me.label5.Size = New System.Drawing.Size(0, 15)
        Me.label5.TabIndex = 5
        '
        'CheckActiveFiscalYear
        '
        Me.CheckActiveFiscalYear.AutoSize = True
        Me.CheckActiveFiscalYear.BackColor = System.Drawing.Color.Transparent
        Me.CheckActiveFiscalYear.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CheckActiveFiscalYear.Location = New System.Drawing.Point(240, 107)
        Me.CheckActiveFiscalYear.Name = "CheckActiveFiscalYear"
        Me.CheckActiveFiscalYear.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckActiveFiscalYear.Size = New System.Drawing.Size(50, 19)
        Me.CheckActiveFiscalYear.TabIndex = 9
        Me.CheckActiveFiscalYear.Text = "تشطة"
        Me.CheckActiveFiscalYear.UseVisualStyleBackColor = False
        '
        'TextYear1
        '
        Me.TextYear1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextYear1.Enabled = False
        Me.TextYear1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextYear1.Location = New System.Drawing.Point(9, 30)
        Me.TextYear1.Name = "TextYear1"
        Me.TextYear1.Size = New System.Drawing.Size(279, 21)
        Me.TextYear1.TabIndex = 12
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.SAVEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SAVEBUTTON.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.SAVEBUTTON.Enabled = False
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.Location = New System.Drawing.Point(128, 34)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.Size = New System.Drawing.Size(125, 30)
        Me.SAVEBUTTON.TabIndex = 13
        Me.SAVEBUTTON.Text = "حفظ"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.UseVisualStyleBackColor = False
        '
        'OpeningDate
        '
        Me.OpeningDate.Checked = False
        Me.OpeningDate.CustomFormat = "dd/MM/yyyy"
        Me.OpeningDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.OpeningDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.OpeningDate.Location = New System.Drawing.Point(5, 29)
        Me.OpeningDate.Name = "OpeningDate"
        Me.OpeningDate.RightToLeftLayout = True
        Me.OpeningDate.Size = New System.Drawing.Size(285, 22)
        Me.OpeningDate.TabIndex = 15
        Me.OpeningDate.Value = New Date(2009, 8, 12, 0, 0, 0, 0)
        '
        'FinalDate
        '
        Me.FinalDate.Checked = False
        Me.FinalDate.CustomFormat = "dd/MM/yyyy"
        Me.FinalDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FinalDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.FinalDate.Location = New System.Drawing.Point(5, 53)
        Me.FinalDate.Name = "FinalDate"
        Me.FinalDate.RightToLeftLayout = True
        Me.FinalDate.Size = New System.Drawing.Size(285, 22)
        Me.FinalDate.TabIndex = 16
        Me.FinalDate.Value = New Date(2009, 8, 12, 0, 0, 0, 0)
        '
        'CurrentDate
        '
        Me.CurrentDate.CalendarMonthBackground = System.Drawing.Color.White
        Me.CurrentDate.CalendarTitleBackColor = System.Drawing.Color.SteelBlue
        Me.CurrentDate.CustomFormat = "dd/MM/yyyy"
        Me.CurrentDate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CurrentDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.CurrentDate.Location = New System.Drawing.Point(5, 6)
        Me.CurrentDate.Name = "CurrentDate"
        Me.CurrentDate.Size = New System.Drawing.Size(285, 22)
        Me.CurrentDate.TabIndex = 17
        Me.CurrentDate.Value = New Date(2024, 1, 17, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.Location = New System.Drawing.Point(296, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "التاريخ الأفتتاحي"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.Location = New System.Drawing.Point(314, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "السنة الحالبة"
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.ADDBUTTON.Cursor = System.Windows.Forms.Cursors.Default
        Me.ADDBUTTON.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.Location = New System.Drawing.Point(254, 34)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(125, 30)
        Me.ADDBUTTON.TabIndex = 520
        Me.ADDBUTTON.Text = "اضافة"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.UseVisualStyleBackColor = False
        '
        'btnLastPage
        '
        Me.btnLastPage.BackColor = System.Drawing.Color.Transparent
        Me.btnLastPage.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.btnLastPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnLastPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLastPage.Location = New System.Drawing.Point(2, 3)
        Me.btnLastPage.Name = "btnLastPage"
        Me.btnLastPage.Size = New System.Drawing.Size(37, 30)
        Me.btnLastPage.TabIndex = 730
        Me.btnLastPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnLastPage.UseVisualStyleBackColor = False
        '
        'txtDisplayPageNo
        '
        Me.txtDisplayPageNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.txtDisplayPageNo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.txtDisplayPageNo.Location = New System.Drawing.Point(79, 3)
        Me.txtDisplayPageNo.Multiline = True
        Me.txtDisplayPageNo.Name = "txtDisplayPageNo"
        Me.txtDisplayPageNo.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDisplayPageNo.Size = New System.Drawing.Size(224, 30)
        Me.txtDisplayPageNo.TabIndex = 731
        Me.txtDisplayPageNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnNextPage
        '
        Me.btnNextPage.BackColor = System.Drawing.Color.Transparent
        Me.btnNextPage.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.btnNextPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextPage.Location = New System.Drawing.Point(41, 3)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.Size = New System.Drawing.Size(37, 30)
        Me.btnNextPage.TabIndex = 729
        Me.btnNextPage.UseVisualStyleBackColor = False
        '
        'btnPreviousPage
        '
        Me.btnPreviousPage.BackColor = System.Drawing.Color.Transparent
        Me.btnPreviousPage.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.btnPreviousPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviousPage.Location = New System.Drawing.Point(304, 3)
        Me.btnPreviousPage.Name = "btnPreviousPage"
        Me.btnPreviousPage.Size = New System.Drawing.Size(37, 30)
        Me.btnPreviousPage.TabIndex = 728
        Me.btnPreviousPage.UseVisualStyleBackColor = False
        '
        'btnFirstPage
        '
        Me.btnFirstPage.BackColor = System.Drawing.Color.Transparent
        Me.btnFirstPage.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.btnFirstPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnFirstPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFirstPage.Location = New System.Drawing.Point(342, 3)
        Me.btnFirstPage.Name = "btnFirstPage"
        Me.btnFirstPage.Size = New System.Drawing.Size(37, 30)
        Me.btnFirstPage.TabIndex = 727
        Me.btnFirstPage.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnLastPage)
        Me.Panel1.Controls.Add(Me.btnNextPage)
        Me.Panel1.Controls.Add(Me.EDITBUTTON)
        Me.Panel1.Controls.Add(Me.ADDBUTTON)
        Me.Panel1.Controls.Add(Me.SAVEBUTTON)
        Me.Panel1.Controls.Add(Me.btnFirstPage)
        Me.Panel1.Controls.Add(Me.txtDisplayPageNo)
        Me.Panel1.Controls.Add(Me.btnPreviousPage)
        Me.Panel1.Location = New System.Drawing.Point(4, 174)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(383, 69)
        Me.Panel1.TabIndex = 732
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.EDITBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.EDITBUTTON.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EDITBUTTON.Location = New System.Drawing.Point(2, 34)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.Size = New System.Drawing.Size(125, 30)
        Me.EDITBUTTON.TabIndex = 734
        Me.EDITBUTTON.Text = "تعديل"
        Me.EDITBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.UseVisualStyleBackColor = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(348, 94)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(30, 30)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 736
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PictureBox2)
        Me.Panel2.Controls.Add(Me.TextFiscalYear)
        Me.Panel2.Controls.Add(Me.label6)
        Me.Panel2.Controls.Add(Me.TextYear)
        Me.Panel2.Controls.Add(Me.OpeningDate)
        Me.Panel2.Controls.Add(Me.CheckActiveFiscalYear)
        Me.Panel2.Controls.Add(Me.label11)
        Me.Panel2.Controls.Add(Me.FinalDate)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.TextYear1)
        Me.Panel2.Controls.Add(Me.CurrentDate)
        Me.Panel2.Location = New System.Drawing.Point(4, 39)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(383, 133)
        Me.Panel2.TabIndex = 733
        '
        'TextFiscalYear
        '
        Me.TextFiscalYear.BackColor = System.Drawing.Color.SteelBlue
        Me.TextFiscalYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextFiscalYear.ForeColor = System.Drawing.Color.Yellow
        Me.TextFiscalYear.Location = New System.Drawing.Point(5, 78)
        Me.TextFiscalYear.Name = "TextFiscalYear"
        Me.TextFiscalYear.Size = New System.Drawing.Size(136, 23)
        Me.TextFiscalYear.TabIndex = 982
        Me.TextFiscalYear.Text = "0000"
        Me.TextFiscalYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TextYear
        '
        Me.TextYear.BackColor = System.Drawing.Color.SteelBlue
        Me.TextYear.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextYear.ForeColor = System.Drawing.Color.Yellow
        Me.TextYear.Location = New System.Drawing.Point(143, 78)
        Me.TextYear.Name = "TextYear"
        Me.TextYear.Size = New System.Drawing.Size(147, 23)
        Me.TextYear.TabIndex = 981
        Me.TextYear.Text = "0000"
        Me.TextYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Textcouser
        '
        Me.Textcouser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Textcouser.Enabled = False
        Me.Textcouser.Location = New System.Drawing.Point(115, 133)
        Me.Textcouser.Name = "Textcouser"
        Me.Textcouser.Size = New System.Drawing.Size(49, 22)
        Me.Textcouser.TabIndex = 733
        '
        'Textcuser
        '
        Me.Textcuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Textcuser.Enabled = False
        Me.Textcuser.Location = New System.Drawing.Point(170, 133)
        Me.Textcuser.Name = "Textcuser"
        Me.Textcuser.Size = New System.Drawing.Size(49, 22)
        Me.Textcuser.TabIndex = 734
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel4.Size = New System.Drawing.Size(392, 37)
        Me.Panel4.TabIndex = 1034
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
        Me.Label7.Size = New System.Drawing.Size(390, 35)
        Me.Label7.TabIndex = 1008
        Me.Label7.Text = "السنة المالية"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FormFiscalYear
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(392, 244)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.label5)
        Me.Controls.Add(Me.Textcuser)
        Me.Controls.Add(Me.Textcouser)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFiscalYear"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "السنة المالية"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents label11 As System.Windows.Forms.Label
    Private WithEvents label6 As System.Windows.Forms.Label
    Private WithEvents label5 As System.Windows.Forms.Label
    Friend WithEvents CheckActiveFiscalYear As System.Windows.Forms.CheckBox
    Friend WithEvents TextYear1 As System.Windows.Forms.TextBox
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents OpeningDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FinalDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CurrentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ADDBUTTON As System.Windows.Forms.Button
    Friend WithEvents btnLastPage As System.Windows.Forms.Button
    Friend WithEvents txtDisplayPageNo As System.Windows.Forms.TextBox
    Friend WithEvents btnNextPage As System.Windows.Forms.Button
    Friend WithEvents btnPreviousPage As System.Windows.Forms.Button
    Friend WithEvents btnFirstPage As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Textcuser As System.Windows.Forms.TextBox
    Friend WithEvents Textcouser As System.Windows.Forms.TextBox
    Friend WithEvents EDITBUTTON As System.Windows.Forms.Button
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents TextYear As Label
    Friend WithEvents TextFiscalYear As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label7 As Label
End Class
