<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmJPG2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJPG2))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ts = New System.Windows.Forms.TextBox()
        Me.SearchBUTTON = New System.Windows.Forms.Button()
        Me.RadioID = New System.Windows.Forms.RadioButton()
        Me.RadioLONO = New System.Windows.Forms.RadioButton()
        Me.RadioFileNo = New System.Windows.Forms.RadioButton()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(1, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(307, 136)
        Me.GroupBox1.TabIndex = 728
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "خيارات البحث"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ts)
        Me.Panel1.Controls.Add(Me.SearchBUTTON)
        Me.Panel1.Controls.Add(Me.RadioID)
        Me.Panel1.Controls.Add(Me.RadioLONO)
        Me.Panel1.Controls.Add(Me.RadioFileNo)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Panel1.Size = New System.Drawing.Size(301, 115)
        Me.Panel1.TabIndex = 762
        '
        'ts
        '
        Me.ts.BackColor = System.Drawing.Color.White
        Me.ts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ts.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ts.Location = New System.Drawing.Point(4, 48)
        Me.ts.Name = "ts"
        Me.ts.Size = New System.Drawing.Size(290, 22)
        Me.ts.TabIndex = 762
        Me.ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'SearchBUTTON
        '
        Me.SearchBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SearchBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.btn1
        Me.SearchBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.SearchBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SearchBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SearchBUTTON.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SearchBUTTON.ForeColor = System.Drawing.Color.White
        Me.SearchBUTTON.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.SearchBUTTON.Location = New System.Drawing.Point(2, 76)
        Me.SearchBUTTON.Name = "SearchBUTTON"
        Me.SearchBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SearchBUTTON.Size = New System.Drawing.Size(291, 32)
        Me.SearchBUTTON.TabIndex = 761
        Me.SearchBUTTON.Text = "ابـحـــث"
        Me.SearchBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SearchBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
        Me.SearchBUTTON.UseCompatibleTextRendering = True
        Me.SearchBUTTON.UseVisualStyleBackColor = False
        '
        'RadioID
        '
        Me.RadioID.AutoSize = True
        Me.RadioID.BackColor = System.Drawing.Color.Transparent
        Me.RadioID.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioID.Checked = True
        Me.RadioID.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioID.ForeColor = System.Drawing.Color.Black
        Me.RadioID.Location = New System.Drawing.Point(236, 12)
        Me.RadioID.Name = "RadioID"
        Me.RadioID.Size = New System.Drawing.Size(40, 19)
        Me.RadioID.TabIndex = 644
        Me.RadioID.TabStop = True
        Me.RadioID.Text = "رقم"
        Me.RadioID.UseVisualStyleBackColor = False
        '
        'RadioLONO
        '
        Me.RadioLONO.AutoSize = True
        Me.RadioLONO.BackColor = System.Drawing.Color.Transparent
        Me.RadioLONO.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioLONO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioLONO.ForeColor = System.Drawing.Color.Black
        Me.RadioLONO.Location = New System.Drawing.Point(8, 12)
        Me.RadioLONO.Name = "RadioLONO"
        Me.RadioLONO.Size = New System.Drawing.Size(75, 19)
        Me.RadioLONO.TabIndex = 647
        Me.RadioLONO.Text = "رقم المعاملة"
        Me.RadioLONO.UseVisualStyleBackColor = False
        '
        'RadioFileNo
        '
        Me.RadioFileNo.AutoSize = True
        Me.RadioFileNo.BackColor = System.Drawing.Color.Transparent
        Me.RadioFileNo.CheckAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioFileNo.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioFileNo.ForeColor = System.Drawing.Color.Black
        Me.RadioFileNo.Location = New System.Drawing.Point(126, 12)
        Me.RadioFileNo.Name = "RadioFileNo"
        Me.RadioFileNo.Size = New System.Drawing.Size(67, 19)
        Me.RadioFileNo.TabIndex = 646
        Me.RadioFileNo.Text = "رقم الملف"
        Me.RadioFileNo.UseVisualStyleBackColor = False
        '
        'FrmJPG2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(313, 141)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmJPG2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "البحث عن المستندات"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioLONO As System.Windows.Forms.RadioButton
    Friend WithEvents RadioFileNo As System.Windows.Forms.RadioButton
    Friend WithEvents RadioID As System.Windows.Forms.RadioButton
    Friend WithEvents SearchBUTTON As System.Windows.Forms.Button
    Friend WithEvents ts As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As Panel
End Class
