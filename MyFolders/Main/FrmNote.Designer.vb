<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNote
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmNote))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.TEXT1 = New System.Windows.Forms.TextBox()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.lblOFFICERTIMEIN = New System.Windows.Forms.Label()
        Me.TEXTBOX1 = New ExtendedRichTextBox.RichTextBoxPrintCtrl()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.InternalAuditorERBUTTON = New System.Windows.Forms.Button()
        Me.DELETEBUTTON = New System.Windows.Forms.Button()
        Me.BUTTONCANCEL = New System.Windows.Forms.Button()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.EDITBUTTON = New System.Windows.Forms.Button()
        Me.LASTBUTTON = New System.Windows.Forms.Button()
        Me.FIRSTBUTTON = New System.Windows.Forms.Button()
        Me.NEXTBUTTON = New System.Windows.Forms.Button()
        Me.PREVIOUSBUTTON = New System.Windows.Forms.Button()
        Me.RECORDSLABEL = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ButtonXP1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker4 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 1000
        '
        'TEXT1
        '
        Me.TEXT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXT1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEXT1.Enabled = False
        Me.TEXT1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXT1.ForeColor = System.Drawing.Color.Black
        Me.TEXT1.Location = New System.Drawing.Point(2, 6)
        Me.TEXT1.Margin = New System.Windows.Forms.Padding(2)
        Me.TEXT1.Name = "TEXT1"
        Me.TEXT1.Size = New System.Drawing.Size(274, 22)
        Me.TEXT1.TabIndex = 7
        Me.TEXT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCODE
        '
        Me.lblCODE.AutoSize = True
        Me.lblCODE.BackColor = System.Drawing.Color.Transparent
        Me.lblCODE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCODE.ForeColor = System.Drawing.Color.Black
        Me.lblCODE.Location = New System.Drawing.Point(300, 5)
        Me.lblCODE.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(37, 15)
        Me.lblCODE.TabIndex = 8
        Me.lblCODE.Text = "مسلسل"
        '
        'lblOFFICERTIMEIN
        '
        Me.lblOFFICERTIMEIN.AutoSize = True
        Me.lblOFFICERTIMEIN.BackColor = System.Drawing.Color.Transparent
        Me.lblOFFICERTIMEIN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOFFICERTIMEIN.ForeColor = System.Drawing.Color.Black
        Me.lblOFFICERTIMEIN.Location = New System.Drawing.Point(306, 35)
        Me.lblOFFICERTIMEIN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblOFFICERTIMEIN.Name = "lblOFFICERTIMEIN"
        Me.lblOFFICERTIMEIN.Size = New System.Drawing.Size(31, 15)
        Me.lblOFFICERTIMEIN.TabIndex = 10
        Me.lblOFFICERTIMEIN.Text = "الوقت"
        '
        'TEXTBOX1
        '
        Me.TEXTBOX1.AutoWordSelection = True
        Me.TEXTBOX1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTBOX1.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEXTBOX1.EnableAutoDragDrop = True
        Me.TEXTBOX1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTBOX1.ForeColor = System.Drawing.Color.Blue
        Me.TEXTBOX1.Location = New System.Drawing.Point(2, 56)
        Me.TEXTBOX1.Margin = New System.Windows.Forms.Padding(2)
        Me.TEXTBOX1.Name = "TEXTBOX1"
        Me.TEXTBOX1.Size = New System.Drawing.Size(276, 130)
        Me.TEXTBOX1.TabIndex = 449
        Me.TEXTBOX1.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(294, 67)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 15)
        Me.Label1.TabIndex = 450
        Me.Label1.Text = "البيــــان"
        '
        'InternalAuditorERBUTTON
        '
        Me.InternalAuditorERBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.InternalAuditorERBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.InternalAuditorERBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.InternalAuditorERBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.InternalAuditorERBUTTON.ForeColor = System.Drawing.Color.Black
        Me.InternalAuditorERBUTTON.Image = Global.CC_JO.My.Resources.Resources.Stop_16x16
        Me.InternalAuditorERBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.InternalAuditorERBUTTON.Location = New System.Drawing.Point(2, 4)
        Me.InternalAuditorERBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.InternalAuditorERBUTTON.Name = "InternalAuditorERBUTTON"
        Me.InternalAuditorERBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.InternalAuditorERBUTTON.Size = New System.Drawing.Size(207, 25)
        Me.InternalAuditorERBUTTON.TabIndex = 479
        Me.InternalAuditorERBUTTON.Text = "أيقاف"
        Me.InternalAuditorERBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InternalAuditorERBUTTON.UseVisualStyleBackColor = False
        '
        'DELETEBUTTON
        '
        Me.DELETEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.DELETEBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DELETEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DELETEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DELETEBUTTON.ForeColor = System.Drawing.Color.Black
        Me.DELETEBUTTON.Image = Global.CC_JO.My.Resources.Resources.delete1
        Me.DELETEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DELETEBUTTON.Location = New System.Drawing.Point(2, 30)
        Me.DELETEBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.DELETEBUTTON.Name = "DELETEBUTTON"
        Me.DELETEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DELETEBUTTON.Size = New System.Drawing.Size(207, 25)
        Me.DELETEBUTTON.TabIndex = 478
        Me.DELETEBUTTON.Text = "حذف"
        Me.DELETEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DELETEBUTTON.UseVisualStyleBackColor = False
        '
        'BUTTONCANCEL
        '
        Me.BUTTONCANCEL.BackColor = System.Drawing.Color.Transparent
        Me.BUTTONCANCEL.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BUTTONCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BUTTONCANCEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BUTTONCANCEL.ForeColor = System.Drawing.Color.Black
        Me.BUTTONCANCEL.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.BUTTONCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BUTTONCANCEL.Location = New System.Drawing.Point(210, 30)
        Me.BUTTONCANCEL.Margin = New System.Windows.Forms.Padding(2)
        Me.BUTTONCANCEL.Name = "BUTTONCANCEL"
        Me.BUTTONCANCEL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.BUTTONCANCEL.Size = New System.Drawing.Size(91, 25)
        Me.BUTTONCANCEL.TabIndex = 477
        Me.BUTTONCANCEL.Text = "الغاء"
        Me.BUTTONCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BUTTONCANCEL.UseVisualStyleBackColor = False
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SAVEBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.ForeColor = System.Drawing.Color.Black
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.Location = New System.Drawing.Point(394, 30)
        Me.SAVEBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SAVEBUTTON.Size = New System.Drawing.Size(91, 25)
        Me.SAVEBUTTON.TabIndex = 476
        Me.SAVEBUTTON.Text = "حفظ"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.UseVisualStyleBackColor = False
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.EDITBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDITBUTTON.ForeColor = System.Drawing.Color.Black
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.Location = New System.Drawing.Point(302, 30)
        Me.EDITBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.EDITBUTTON.Size = New System.Drawing.Size(91, 25)
        Me.EDITBUTTON.TabIndex = 475
        Me.EDITBUTTON.Text = "تعديل"
        Me.EDITBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EDITBUTTON.UseVisualStyleBackColor = False
        '
        'LASTBUTTON
        '
        Me.LASTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.LASTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.LASTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LASTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LASTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.LASTBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.LASTBUTTON.Location = New System.Drawing.Point(210, 4)
        Me.LASTBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.LASTBUTTON.Name = "LASTBUTTON"
        Me.LASTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.LASTBUTTON.Size = New System.Drawing.Size(45, 25)
        Me.LASTBUTTON.TabIndex = 472
        Me.LASTBUTTON.UseVisualStyleBackColor = False
        '
        'FIRSTBUTTON
        '
        Me.FIRSTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.FIRSTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FIRSTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FIRSTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FIRSTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.FIRSTBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.FIRSTBUTTON.Location = New System.Drawing.Point(532, 4)
        Me.FIRSTBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.FIRSTBUTTON.Name = "FIRSTBUTTON"
        Me.FIRSTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FIRSTBUTTON.Size = New System.Drawing.Size(45, 25)
        Me.FIRSTBUTTON.TabIndex = 470
        Me.FIRSTBUTTON.UseVisualStyleBackColor = False
        '
        'NEXTBUTTON
        '
        Me.NEXTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.NEXTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.NEXTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NEXTBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.NEXTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.NEXTBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.NEXTBUTTON.Location = New System.Drawing.Point(256, 4)
        Me.NEXTBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.NEXTBUTTON.Name = "NEXTBUTTON"
        Me.NEXTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.NEXTBUTTON.Size = New System.Drawing.Size(45, 25)
        Me.NEXTBUTTON.TabIndex = 473
        Me.NEXTBUTTON.UseVisualStyleBackColor = False
        '
        'PREVIOUSBUTTON
        '
        Me.PREVIOUSBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PREVIOUSBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PREVIOUSBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PREVIOUSBUTTON.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PREVIOUSBUTTON.ForeColor = System.Drawing.Color.Black
        Me.PREVIOUSBUTTON.Image = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.PREVIOUSBUTTON.Location = New System.Drawing.Point(486, 4)
        Me.PREVIOUSBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.PREVIOUSBUTTON.Name = "PREVIOUSBUTTON"
        Me.PREVIOUSBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PREVIOUSBUTTON.Size = New System.Drawing.Size(45, 25)
        Me.PREVIOUSBUTTON.TabIndex = 471
        Me.PREVIOUSBUTTON.UseVisualStyleBackColor = False
        '
        'RECORDSLABEL
        '
        Me.RECORDSLABEL.BackColor = System.Drawing.Color.Transparent
        Me.RECORDSLABEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RECORDSLABEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RECORDSLABEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RECORDSLABEL.ForeColor = System.Drawing.Color.Black
        Me.RECORDSLABEL.Location = New System.Drawing.Point(302, 4)
        Me.RECORDSLABEL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RECORDSLABEL.Name = "RECORDSLABEL"
        Me.RECORDSLABEL.Size = New System.Drawing.Size(183, 25)
        Me.RECORDSLABEL.TabIndex = 469
        Me.RECORDSLABEL.Text = "عدد السجلات"
        Me.RECORDSLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Checked = False
        Me.DateTimePicker3.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker3.Location = New System.Drawing.Point(231, 198)
        Me.DateTimePicker3.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(101, 22)
        Me.DateTimePicker3.TabIndex = 481
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Checked = False
        Me.DateTimePicker2.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker2.Location = New System.Drawing.Point(359, 198)
        Me.DateTimePicker2.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(101, 22)
        Me.DateTimePicker2.TabIndex = 480
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(463, 202)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 15)
        Me.Label2.TabIndex = 482
        Me.Label2.Text = "من"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(335, 202)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 15)
        Me.Label3.TabIndex = 483
        Me.Label3.Text = "الى"
        '
        'ButtonXP1
        '
        Me.ButtonXP1.BackColor = System.Drawing.Color.Transparent
        Me.ButtonXP1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ButtonXP1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonXP1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButtonXP1.ForeColor = System.Drawing.Color.Black
        Me.ButtonXP1.Image = Global.CC_JO.My.Resources.Resources.BO_Scheduler
        Me.ButtonXP1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButtonXP1.Location = New System.Drawing.Point(487, 196)
        Me.ButtonXP1.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonXP1.Name = "ButtonXP1"
        Me.ButtonXP1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButtonXP1.Size = New System.Drawing.Size(91, 26)
        Me.ButtonXP1.TabIndex = 484
        Me.ButtonXP1.Text = "أحسب"
        Me.ButtonXP1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButtonXP1.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 4)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 15)
        Me.Label4.TabIndex = 485
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(285, 225)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 15)
        Me.Label5.TabIndex = 486
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DateTimePicker4
        '
        Me.DateTimePicker4.Checked = False
        Me.DateTimePicker4.Cursor = System.Windows.Forms.Cursors.Default
        Me.DateTimePicker4.CustomFormat = "yyyy-MM-dd"
        Me.DateTimePicker4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker4.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker4.Location = New System.Drawing.Point(2, 30)
        Me.DateTimePicker4.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker4.Name = "DateTimePicker4"
        Me.DateTimePicker4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateTimePicker4.RightToLeftLayout = True
        Me.DateTimePicker4.Size = New System.Drawing.Size(158, 22)
        Me.DateTimePicker4.TabIndex = 487
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(488, 146)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 488
        Me.Label6.Text = "الوقت المتبقى"
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(307, 147)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 727
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox5.Location = New System.Drawing.Point(307, 147)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(2)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 726
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox2.Enabled = False
        Me.TextBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox2.ForeColor = System.Drawing.Color.Black
        Me.TextBox2.Location = New System.Drawing.Point(374, 144)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(64, 22)
        Me.TextBox2.TabIndex = 728
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox3
        '
        Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox3.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox3.Enabled = False
        Me.TextBox3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox3.ForeColor = System.Drawing.Color.Black
        Me.TextBox3.Location = New System.Drawing.Point(428, 144)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(56, 22)
        Me.TextBox3.TabIndex = 729
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "hh:mm:ss tt"
        Me.DateTimePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DateTimePicker1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(164, 30)
        Me.DateTimePicker1.Margin = New System.Windows.Forms.Padding(2)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.DateTimePicker1.RightToLeftLayout = True
        Me.DateTimePicker1.ShowUpDown = True
        Me.DateTimePicker1.Size = New System.Drawing.Size(112, 22)
        Me.DateTimePicker1.TabIndex = 730
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TEXTBOX1)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.DateTimePicker4)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lblOFFICERTIMEIN)
        Me.Panel1.Controls.Add(Me.lblCODE)
        Me.Panel1.Controls.Add(Me.TEXT1)
        Me.Panel1.Location = New System.Drawing.Point(231, 2)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(347, 190)
        Me.Panel1.TabIndex = 731
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.DELETEBUTTON)
        Me.Panel2.Controls.Add(Me.InternalAuditorERBUTTON)
        Me.Panel2.Controls.Add(Me.BUTTONCANCEL)
        Me.Panel2.Controls.Add(Me.LASTBUTTON)
        Me.Panel2.Controls.Add(Me.EDITBUTTON)
        Me.Panel2.Controls.Add(Me.NEXTBUTTON)
        Me.Panel2.Controls.Add(Me.SAVEBUTTON)
        Me.Panel2.Controls.Add(Me.RECORDSLABEL)
        Me.Panel2.Controls.Add(Me.ADDBUTTON)
        Me.Panel2.Controls.Add(Me.PREVIOUSBUTTON)
        Me.Panel2.Controls.Add(Me.FIRSTBUTTON)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 226)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(581, 60)
        Me.Panel2.TabIndex = 732
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.ADDBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.ForeColor = System.Drawing.Color.Black
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.Location = New System.Drawing.Point(486, 30)
        Me.ADDBUTTON.Margin = New System.Windows.Forms.Padding(2)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ADDBUTTON.Size = New System.Drawing.Size(91, 25)
        Me.ADDBUTTON.TabIndex = 474
        Me.ADDBUTTON.Text = "اضافة"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.UseVisualStyleBackColor = False
        '
        'TextBox4
        '
        Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox4.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextBox4.Enabled = False
        Me.TextBox4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextBox4.ForeColor = System.Drawing.Color.Black
        Me.TextBox4.Location = New System.Drawing.Point(358, 107)
        Me.TextBox4.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(94, 22)
        Me.TextBox4.TabIndex = 734
        Me.TextBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FrmNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(581, 286)
        Me.Controls.Add(Me.DateTimePicker3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ButtonXP1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.DateTimePicker2)
        Me.Controls.Add(Me.TextBox3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmNote"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اجندة المواعيد"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TEXT1 As System.Windows.Forms.TextBox
    Friend WithEvents lblCODE As System.Windows.Forms.Label
    Friend WithEvents lblOFFICERTIMEIN As System.Windows.Forms.Label
    Friend WithEvents TEXTBOX1 As ExtendedRichTextBox.RichTextBoxPrintCtrl
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents InternalAuditorERBUTTON As System.Windows.Forms.Button
    Friend WithEvents DELETEBUTTON As System.Windows.Forms.Button
    Friend WithEvents BUTTONCANCEL As System.Windows.Forms.Button
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents EDITBUTTON As System.Windows.Forms.Button
    Friend WithEvents LASTBUTTON As System.Windows.Forms.Button
    Friend WithEvents FIRSTBUTTON As System.Windows.Forms.Button
    Friend WithEvents NEXTBUTTON As System.Windows.Forms.Button
    Friend WithEvents PREVIOUSBUTTON As System.Windows.Forms.Button
    Friend WithEvents RECORDSLABEL As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents DateTimePicker3 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ButtonXP1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker4 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ADDBUTTON As System.Windows.Forms.Button
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
End Class
