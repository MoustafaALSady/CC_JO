<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAddStocks
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAddStocks))
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.ButAdd = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButEdit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ButCANCEL = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.TextIDW = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.LabelWarehouseNumber = New System.Windows.Forms.Label()
        Me.LabelLocation = New System.Windows.Forms.Label()
        Me.LabelWarehouseName = New System.Windows.Forms.Label()
        Me.TextWarehouseNumber = New DevExpress.XtraEditors.TextEdit()
        Me.TextLocation = New DevExpress.XtraEditors.TextEdit()
        Me.TextWarehouseName = New DevExpress.XtraEditors.TextEdit()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LASTBUTTON = New System.Windows.Forms.Button()
        Me.NEXTBUTTON = New System.Windows.Forms.Button()
        Me.RECORDSLABEL = New System.Windows.Forms.Label()
        Me.PREVIOUSBUTTON = New System.Windows.Forms.Button()
        Me.FIRSTBUTTON = New System.Windows.Forms.Button()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.ToolStrip2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.TextWarehouseNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextWarehouseName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BackWorker2
        '
        '
        'ToolStrip2
        '
        Me.ToolStrip2.BackColor = System.Drawing.Color.SteelBlue
        Me.ToolStrip2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ToolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ButAdd, Me.ToolStripSeparator3, Me.ButSave, Me.ToolStripSeparator2, Me.ButEdit, Me.ToolStripSeparator1, Me.ButCANCEL, Me.ToolStripSeparator5})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.ToolStrip2.Size = New System.Drawing.Size(513, 35)
        Me.ToolStrip2.TabIndex = 7
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ButAdd
        '
        Me.ButAdd.AutoSize = False
        Me.ButAdd.ForeColor = System.Drawing.Color.White
        Me.ButAdd.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ButAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButAdd.Name = "ButAdd"
        Me.ButAdd.Size = New System.Drawing.Size(100, 32)
        Me.ButAdd.Text = "اضافة"
        Me.ButAdd.ToolTipText = "اضافة"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 35)
        '
        'ButSave
        '
        Me.ButSave.AutoSize = False
        Me.ButSave.ForeColor = System.Drawing.Color.White
        Me.ButSave.Image = Global.CC_JO.My.Resources.Resources.save11
        Me.ButSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButSave.Name = "ButSave"
        Me.ButSave.Size = New System.Drawing.Size(100, 32)
        Me.ButSave.Text = "حفظ"
        Me.ButSave.ToolTipText = "حفظ"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 35)
        '
        'ButEdit
        '
        Me.ButEdit.AutoSize = False
        Me.ButEdit.ForeColor = System.Drawing.Color.White
        Me.ButEdit.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.ButEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButEdit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButEdit.Name = "ButEdit"
        Me.ButEdit.Size = New System.Drawing.Size(100, 32)
        Me.ButEdit.Text = "تعديل"
        Me.ButEdit.ToolTipText = "تعديل"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 35)
        '
        'ButCANCEL
        '
        Me.ButCANCEL.AutoSize = False
        Me.ButCANCEL.ForeColor = System.Drawing.Color.White
        Me.ButCANCEL.Image = Global.CC_JO.My.Resources.Resources.pivottableungroup_16x16
        Me.ButCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCANCEL.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ButCANCEL.Name = "ButCANCEL"
        Me.ButCANCEL.Size = New System.Drawing.Size(100, 32)
        Me.ButCANCEL.Text = "إلغاء"
        Me.ButCANCEL.ToolTipText = "إلغاء"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 35)
        '
        'TextIDW
        '
        Me.TextIDW.Enabled = False
        Me.TextIDW.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextIDW.Location = New System.Drawing.Point(328, 38)
        Me.TextIDW.Name = "TextIDW"
        Me.TextIDW.Size = New System.Drawing.Size(116, 20)
        Me.TextIDW.TabIndex = 736
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 735
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.TextIDW)
        Me.Panel1.Location = New System.Drawing.Point(5, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(505, 157)
        Me.Panel1.TabIndex = 737
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.LabelWarehouseNumber)
        Me.Panel3.Controls.Add(Me.LabelLocation)
        Me.Panel3.Controls.Add(Me.LabelWarehouseName)
        Me.Panel3.Controls.Add(Me.TextWarehouseNumber)
        Me.Panel3.Controls.Add(Me.TextLocation)
        Me.Panel3.Controls.Add(Me.TextWarehouseName)
        Me.Panel3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel3.Location = New System.Drawing.Point(4, 7)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(495, 98)
        Me.Panel3.TabIndex = 737
        '
        'LabelWarehouseNumber
        '
        Me.LabelWarehouseNumber.AutoSize = True
        Me.LabelWarehouseNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelWarehouseNumber.Location = New System.Drawing.Point(405, 12)
        Me.LabelWarehouseNumber.Name = "LabelWarehouseNumber"
        Me.LabelWarehouseNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelWarehouseNumber.Size = New System.Drawing.Size(75, 15)
        Me.LabelWarehouseNumber.TabIndex = 8
        Me.LabelWarehouseNumber.Text = ": رقم المستودع "
        '
        'LabelLocation
        '
        Me.LabelLocation.AutoSize = True
        Me.LabelLocation.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelLocation.Location = New System.Drawing.Point(405, 70)
        Me.LabelLocation.Name = "LabelLocation"
        Me.LabelLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelLocation.Size = New System.Drawing.Size(81, 15)
        Me.LabelLocation.TabIndex = 7
        Me.LabelLocation.Text = ": موقع المستودع "
        '
        'LabelWarehouseName
        '
        Me.LabelWarehouseName.AutoSize = True
        Me.LabelWarehouseName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelWarehouseName.Location = New System.Drawing.Point(405, 41)
        Me.LabelWarehouseName.Name = "LabelWarehouseName"
        Me.LabelWarehouseName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LabelWarehouseName.Size = New System.Drawing.Size(76, 15)
        Me.LabelWarehouseName.TabIndex = 6
        Me.LabelWarehouseName.Text = ": اسم المستودع "
        '
        'TextWarehouseNumber
        '
        Me.TextWarehouseNumber.Enabled = False
        Me.TextWarehouseNumber.Location = New System.Drawing.Point(3, 8)
        Me.TextWarehouseNumber.Name = "TextWarehouseNumber"
        Me.TextWarehouseNumber.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextWarehouseNumber.Properties.Appearance.Options.UseFont = True
        Me.TextWarehouseNumber.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextWarehouseNumber.Size = New System.Drawing.Size(398, 22)
        Me.TextWarehouseNumber.TabIndex = 2
        '
        'TextLocation
        '
        Me.TextLocation.Location = New System.Drawing.Point(3, 66)
        Me.TextLocation.Name = "TextLocation"
        Me.TextLocation.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextLocation.Properties.Appearance.Options.UseFont = True
        Me.TextLocation.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextLocation.Size = New System.Drawing.Size(398, 22)
        Me.TextLocation.TabIndex = 1
        '
        'TextWarehouseName
        '
        Me.TextWarehouseName.Location = New System.Drawing.Point(3, 37)
        Me.TextWarehouseName.Name = "TextWarehouseName"
        Me.TextWarehouseName.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextWarehouseName.Properties.Appearance.Options.UseFont = True
        Me.TextWarehouseName.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextWarehouseName.Size = New System.Drawing.Size(398, 22)
        Me.TextWarehouseName.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.LASTBUTTON)
        Me.Panel2.Controls.Add(Me.NEXTBUTTON)
        Me.Panel2.Controls.Add(Me.RECORDSLABEL)
        Me.Panel2.Controls.Add(Me.PREVIOUSBUTTON)
        Me.Panel2.Controls.Add(Me.FIRSTBUTTON)
        Me.Panel2.Location = New System.Drawing.Point(4, 111)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(495, 38)
        Me.Panel2.TabIndex = 739
        '
        'LASTBUTTON
        '
        Me.LASTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.LASTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.LASTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LASTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LASTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LASTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LASTBUTTON.Location = New System.Drawing.Point(2, 2)
        Me.LASTBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LASTBUTTON.Name = "LASTBUTTON"
        Me.LASTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.LASTBUTTON.Size = New System.Drawing.Size(43, 32)
        Me.LASTBUTTON.TabIndex = 453
        Me.LASTBUTTON.UseVisualStyleBackColor = False
        '
        'NEXTBUTTON
        '
        Me.NEXTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.NEXTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.NEXTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NEXTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NEXTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NEXTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NEXTBUTTON.Location = New System.Drawing.Point(46, 2)
        Me.NEXTBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NEXTBUTTON.Name = "NEXTBUTTON"
        Me.NEXTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.NEXTBUTTON.Size = New System.Drawing.Size(48, 32)
        Me.NEXTBUTTON.TabIndex = 452
        Me.NEXTBUTTON.UseVisualStyleBackColor = False
        '
        'RECORDSLABEL
        '
        Me.RECORDSLABEL.BackColor = System.Drawing.Color.Transparent
        Me.RECORDSLABEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RECORDSLABEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RECORDSLABEL.ForeColor = System.Drawing.Color.Black
        Me.RECORDSLABEL.Location = New System.Drawing.Point(95, 2)
        Me.RECORDSLABEL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RECORDSLABEL.Name = "RECORDSLABEL"
        Me.RECORDSLABEL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RECORDSLABEL.Size = New System.Drawing.Size(307, 32)
        Me.RECORDSLABEL.TabIndex = 434
        Me.RECORDSLABEL.Text = "عدد السجلات"
        Me.RECORDSLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PREVIOUSBUTTON
        '
        Me.PREVIOUSBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PREVIOUSBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.PREVIOUSBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PREVIOUSBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PREVIOUSBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PREVIOUSBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PREVIOUSBUTTON.Location = New System.Drawing.Point(403, 2)
        Me.PREVIOUSBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PREVIOUSBUTTON.Name = "PREVIOUSBUTTON"
        Me.PREVIOUSBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PREVIOUSBUTTON.Size = New System.Drawing.Size(43, 32)
        Me.PREVIOUSBUTTON.TabIndex = 450
        Me.PREVIOUSBUTTON.UseVisualStyleBackColor = False
        '
        'FIRSTBUTTON
        '
        Me.FIRSTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.FIRSTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.FIRSTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FIRSTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FIRSTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FIRSTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FIRSTBUTTON.Location = New System.Drawing.Point(448, 2)
        Me.FIRSTBUTTON.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FIRSTBUTTON.Name = "FIRSTBUTTON"
        Me.FIRSTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FIRSTBUTTON.Size = New System.Drawing.Size(43, 32)
        Me.FIRSTBUTTON.TabIndex = 449
        Me.FIRSTBUTTON.UseVisualStyleBackColor = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox5.Location = New System.Drawing.Point(0, 1)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 738
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'FormAddStocks
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(513, 205)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormAddStocks"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضـأفة مســتــودع"
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.TextWarehouseNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextWarehouseName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ButAdd As ToolStripButton
    Friend WithEvents ButSave As ToolStripButton
    Friend WithEvents ButEdit As ToolStripButton
    Friend WithEvents ButCANCEL As ToolStripButton
    Friend WithEvents TextIDW As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextWarehouseNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextWarehouseName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents LASTBUTTON As Button
    Friend WithEvents NEXTBUTTON As Button
    Friend WithEvents RECORDSLABEL As Label
    Friend WithEvents PREVIOUSBUTTON As Button
    Friend WithEvents FIRSTBUTTON As Button

    Private Sub FormAddStocks1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Friend WithEvents LabelWarehouseNumber As Label
    Friend WithEvents LabelLocation As Label
    Friend WithEvents LabelWarehouseName As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
End Class
