<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_ACCOUNT
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_ACCOUNT))
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.EDITBUTTON = New System.Windows.Forms.Button()
        Me.TXT_Account_NO = New System.Windows.Forms.TextBox()
        Me.TXT_Account_Name = New System.Windows.Forms.TextBox()
        Me.TextlblGROUPACCOUNT = New System.Windows.Forms.TextBox()
        Me.TextAccountLevel = New System.Windows.Forms.TextBox()
        Me.TextlblFIRSTDEBIT = New System.Windows.Forms.TextBox()
        Me.TextlblFIRSTCREDIT = New System.Windows.Forms.TextBox()
        Me.TextNotes = New System.Windows.Forms.TextBox()
        Me.TXT_ACC = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblGROUPACCOUNT = New System.Windows.Forms.Label()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.lblFIRSTDEBIT = New System.Windows.Forms.Label()
        Me.lblFIRSTCREDIT = New System.Windows.Forms.Label()
        Me.lblNOTES = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextACC11 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.LabelAccountPrivate = New System.Windows.Forms.Label()
        Me.TextAccountPrivate = New System.Windows.Forms.TextBox()
        Me.CheckMasterAccount = New System.Windows.Forms.CheckBox()
        Me.BtnSearch = New System.Windows.Forms.Button()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Text_ACC_FATHER = New System.Windows.Forms.TextBox()
        Me.Chk_ACTIVAT = New System.Windows.Forms.CheckBox()
        Me.TextACC1 = New System.Windows.Forms.TextBox()
        Me.TXT_Account_NO1 = New System.Windows.Forms.TextBox()
        Me.TXT_PARENT_GUID = New System.Windows.Forms.TextBox()
        Me.TXT_GUID = New System.Windows.Forms.TextBox()
        Me.TXT_END_ACCOUNT = New System.Windows.Forms.TextBox()
        Me.TEXTReviewDate = New System.Windows.Forms.TextBox()
        Me.TEXTReferenceName = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TXT_COUINT_ACCOUNT = New System.Windows.Forms.TextBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BtnSearch1 = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.Enabled = False
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.Location = New System.Drawing.Point(499, 2)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.SAVEBUTTON.Size = New System.Drawing.Size(248, 30)
        Me.SAVEBUTTON.TabIndex = 1
        Me.SAVEBUTTON.Text = "حفظ حساب"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.UseVisualStyleBackColor = True
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.EDITBUTTON.Location = New System.Drawing.Point(250, 2)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.Size = New System.Drawing.Size(248, 30)
        Me.EDITBUTTON.TabIndex = 2
        Me.EDITBUTTON.Text = "تعديل حساب"
        Me.EDITBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.UseVisualStyleBackColor = True
        '
        'TXT_Account_NO
        '
        Me.TXT_Account_NO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_Account_NO.Cursor = System.Windows.Forms.Cursors.Default
        Me.TXT_Account_NO.Enabled = False
        Me.TXT_Account_NO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TXT_Account_NO.Location = New System.Drawing.Point(3, 30)
        Me.TXT_Account_NO.Name = "TXT_Account_NO"
        Me.TXT_Account_NO.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TXT_Account_NO.Size = New System.Drawing.Size(174, 22)
        Me.TXT_Account_NO.TabIndex = 5
        Me.TXT_Account_NO.Text = "0"
        Me.TXT_Account_NO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TXT_Account_Name
        '
        Me.TXT_Account_Name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_Account_Name.Cursor = System.Windows.Forms.Cursors.Default
        Me.TXT_Account_Name.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Account_Name.Location = New System.Drawing.Point(320, 53)
        Me.TXT_Account_Name.Name = "TXT_Account_Name"
        Me.TXT_Account_Name.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TXT_Account_Name.Size = New System.Drawing.Size(345, 21)
        Me.TXT_Account_Name.TabIndex = 7
        '
        'TextlblGROUPACCOUNT
        '
        Me.TextlblGROUPACCOUNT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextlblGROUPACCOUNT.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextlblGROUPACCOUNT.Enabled = False
        Me.TextlblGROUPACCOUNT.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextlblGROUPACCOUNT.Location = New System.Drawing.Point(320, 75)
        Me.TextlblGROUPACCOUNT.Name = "TextlblGROUPACCOUNT"
        Me.TextlblGROUPACCOUNT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextlblGROUPACCOUNT.Size = New System.Drawing.Size(345, 21)
        Me.TextlblGROUPACCOUNT.TabIndex = 9
        '
        'TextAccountLevel
        '
        Me.TextAccountLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAccountLevel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextAccountLevel.Enabled = False
        Me.TextAccountLevel.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextAccountLevel.Location = New System.Drawing.Point(3, 53)
        Me.TextAccountLevel.Name = "TextAccountLevel"
        Me.TextAccountLevel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextAccountLevel.Size = New System.Drawing.Size(174, 22)
        Me.TextAccountLevel.TabIndex = 8
        Me.TextAccountLevel.Text = "1"
        Me.TextAccountLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextlblFIRSTDEBIT
        '
        Me.TextlblFIRSTDEBIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextlblFIRSTDEBIT.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextlblFIRSTDEBIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextlblFIRSTDEBIT.Location = New System.Drawing.Point(3, 76)
        Me.TextlblFIRSTDEBIT.Name = "TextlblFIRSTDEBIT"
        Me.TextlblFIRSTDEBIT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextlblFIRSTDEBIT.Size = New System.Drawing.Size(174, 22)
        Me.TextlblFIRSTDEBIT.TabIndex = 11
        Me.TextlblFIRSTDEBIT.Text = "0.000"
        Me.TextlblFIRSTDEBIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextlblFIRSTCREDIT
        '
        Me.TextlblFIRSTCREDIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextlblFIRSTCREDIT.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextlblFIRSTCREDIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextlblFIRSTCREDIT.Location = New System.Drawing.Point(3, 99)
        Me.TextlblFIRSTCREDIT.Name = "TextlblFIRSTCREDIT"
        Me.TextlblFIRSTCREDIT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextlblFIRSTCREDIT.Size = New System.Drawing.Size(174, 22)
        Me.TextlblFIRSTCREDIT.TabIndex = 10
        Me.TextlblFIRSTCREDIT.Text = "0.000"
        Me.TextlblFIRSTCREDIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextNotes
        '
        Me.TextNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNotes.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextNotes.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNotes.Location = New System.Drawing.Point(320, 97)
        Me.TextNotes.Multiline = True
        Me.TextNotes.Name = "TextNotes"
        Me.TextNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextNotes.Size = New System.Drawing.Size(345, 125)
        Me.TextNotes.TabIndex = 13
        '
        'TXT_ACC
        '
        Me.TXT_ACC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_ACC.Cursor = System.Windows.Forms.Cursors.Default
        Me.TXT_ACC.Enabled = False
        Me.TXT_ACC.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TXT_ACC.Location = New System.Drawing.Point(3, 7)
        Me.TXT_ACC.Name = "TXT_ACC"
        Me.TXT_ACC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TXT_ACC.Size = New System.Drawing.Size(174, 22)
        Me.TXT_ACC.TabIndex = 12
        Me.TXT_ACC.Text = "0"
        Me.TXT_ACC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(212, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 15)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "رقم الحساب"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(686, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "اسم الحساب"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(196, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "مستوى الحساب"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(691, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 15)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "حساب الاب"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGROUPACCOUNT
        '
        Me.lblGROUPACCOUNT.AutoSize = True
        Me.lblGROUPACCOUNT.BackColor = System.Drawing.Color.Transparent
        Me.lblGROUPACCOUNT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblGROUPACCOUNT.ForeColor = System.Drawing.Color.Black
        Me.lblGROUPACCOUNT.Location = New System.Drawing.Point(667, 79)
        Me.lblGROUPACCOUNT.Name = "lblGROUPACCOUNT"
        Me.lblGROUPACCOUNT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblGROUPACCOUNT.Size = New System.Drawing.Size(77, 15)
        Me.lblGROUPACCOUNT.TabIndex = 18
        Me.lblGROUPACCOUNT.Text = "مجموعة الحساب"
        Me.lblGROUPACCOUNT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCODE
        '
        Me.lblCODE.AutoSize = True
        Me.lblCODE.BackColor = System.Drawing.Color.Transparent
        Me.lblCODE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCODE.ForeColor = System.Drawing.Color.Black
        Me.lblCODE.Location = New System.Drawing.Point(707, 12)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(37, 15)
        Me.lblCODE.TabIndex = 19
        Me.lblCODE.Text = "مسلسل"
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFIRSTDEBIT
        '
        Me.lblFIRSTDEBIT.AutoSize = True
        Me.lblFIRSTDEBIT.BackColor = System.Drawing.Color.Transparent
        Me.lblFIRSTDEBIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblFIRSTDEBIT.ForeColor = System.Drawing.Color.Black
        Me.lblFIRSTDEBIT.Location = New System.Drawing.Point(180, 79)
        Me.lblFIRSTDEBIT.Name = "lblFIRSTDEBIT"
        Me.lblFIRSTDEBIT.Size = New System.Drawing.Size(89, 15)
        Me.lblFIRSTDEBIT.TabIndex = 20
        Me.lblFIRSTDEBIT.Text = "رصيد مدين افتتاحى"
        Me.lblFIRSTDEBIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFIRSTCREDIT
        '
        Me.lblFIRSTCREDIT.AutoSize = True
        Me.lblFIRSTCREDIT.BackColor = System.Drawing.Color.Transparent
        Me.lblFIRSTCREDIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblFIRSTCREDIT.ForeColor = System.Drawing.Color.Black
        Me.lblFIRSTCREDIT.Location = New System.Drawing.Point(182, 102)
        Me.lblFIRSTCREDIT.Name = "lblFIRSTCREDIT"
        Me.lblFIRSTCREDIT.Size = New System.Drawing.Size(87, 15)
        Me.lblFIRSTCREDIT.TabIndex = 21
        Me.lblFIRSTCREDIT.Text = "رصيد دائن افتتاحى"
        Me.lblFIRSTCREDIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNOTES
        '
        Me.lblNOTES.AutoSize = True
        Me.lblNOTES.BackColor = System.Drawing.Color.Transparent
        Me.lblNOTES.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNOTES.ForeColor = System.Drawing.Color.Black
        Me.lblNOTES.Location = New System.Drawing.Point(700, 106)
        Me.lblNOTES.Name = "lblNOTES"
        Me.lblNOTES.Size = New System.Drawing.Size(44, 15)
        Me.lblNOTES.TabIndex = 22
        Me.lblNOTES.Text = "ملاحظات"
        Me.lblNOTES.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(212, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 15)
        Me.Label5.TabIndex = 972
        Me.Label5.Text = "كود الحساب"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox1.Location = New System.Drawing.Point(4, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox1.Size = New System.Drawing.Size(756, 251)
        Me.GroupBox1.TabIndex = 975
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات الحساب"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextACC11)
        Me.Panel1.Controls.Add(Me.PictureBox5)
        Me.Panel1.Controls.Add(Me.LabelAccountPrivate)
        Me.Panel1.Controls.Add(Me.TextNotes)
        Me.Panel1.Controls.Add(Me.TextAccountPrivate)
        Me.Panel1.Controls.Add(Me.CheckMasterAccount)
        Me.Panel1.Controls.Add(Me.BtnSearch)
        Me.Panel1.Controls.Add(Me.PictureBox2)
        Me.Panel1.Controls.Add(Me.Text_ACC_FATHER)
        Me.Panel1.Controls.Add(Me.TXT_ACC)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.lblCODE)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.TextlblFIRSTDEBIT)
        Me.Panel1.Controls.Add(Me.TXT_Account_NO)
        Me.Panel1.Controls.Add(Me.lblFIRSTDEBIT)
        Me.Panel1.Controls.Add(Me.TextlblGROUPACCOUNT)
        Me.Panel1.Controls.Add(Me.lblGROUPACCOUNT)
        Me.Panel1.Controls.Add(Me.TXT_Account_Name)
        Me.Panel1.Controls.Add(Me.TextlblFIRSTCREDIT)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.lblFIRSTCREDIT)
        Me.Panel1.Controls.Add(Me.lblNOTES)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextAccountLevel)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel1.Location = New System.Drawing.Point(3, 21)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(750, 227)
        Me.Panel1.TabIndex = 976
        '
        'TextACC11
        '
        Me.TextACC11.BackColor = System.Drawing.Color.SteelBlue
        Me.TextACC11.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextACC11.ForeColor = System.Drawing.Color.White
        Me.TextACC11.Location = New System.Drawing.Point(320, 9)
        Me.TextACC11.Name = "TextACC11"
        Me.TextACC11.Size = New System.Drawing.Size(345, 21)
        Me.TextACC11.TabIndex = 990
        Me.TextACC11.Text = "0"
        Me.TextACC11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox5.Location = New System.Drawing.Point(709, 186)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 974
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'LabelAccountPrivate
        '
        Me.LabelAccountPrivate.AutoSize = True
        Me.LabelAccountPrivate.BackColor = System.Drawing.Color.Transparent
        Me.LabelAccountPrivate.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.LabelAccountPrivate.ForeColor = System.Drawing.Color.Black
        Me.LabelAccountPrivate.Location = New System.Drawing.Point(199, 126)
        Me.LabelAccountPrivate.Name = "LabelAccountPrivate"
        Me.LabelAccountPrivate.Size = New System.Drawing.Size(70, 15)
        Me.LabelAccountPrivate.TabIndex = 969
        Me.LabelAccountPrivate.Text = "مجموعة خاصه"
        '
        'TextAccountPrivate
        '
        Me.TextAccountPrivate.BackColor = System.Drawing.Color.SteelBlue
        Me.TextAccountPrivate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAccountPrivate.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextAccountPrivate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAccountPrivate.ForeColor = System.Drawing.Color.Yellow
        Me.TextAccountPrivate.Location = New System.Drawing.Point(3, 123)
        Me.TextAccountPrivate.Name = "TextAccountPrivate"
        Me.TextAccountPrivate.ReadOnly = True
        Me.TextAccountPrivate.Size = New System.Drawing.Size(174, 24)
        Me.TextAccountPrivate.TabIndex = 966
        Me.TextAccountPrivate.Text = "AN"
        Me.TextAccountPrivate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'CheckMasterAccount
        '
        Me.CheckMasterAccount.AutoSize = True
        Me.CheckMasterAccount.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.CheckMasterAccount.Location = New System.Drawing.Point(79, 153)
        Me.CheckMasterAccount.Name = "CheckMasterAccount"
        Me.CheckMasterAccount.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.CheckMasterAccount.Size = New System.Drawing.Size(98, 23)
        Me.CheckMasterAccount.TabIndex = 976
        Me.CheckMasterAccount.Text = "حساب رئيسي"
        Me.CheckMasterAccount.UseVisualStyleBackColor = True
        '
        'BtnSearch
        '
        Me.BtnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.BtnSearch.Enabled = False
        Me.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearch.Image = Global.CC_JO.My.Resources.Resources.FindByID_16x16
        Me.BtnSearch.Location = New System.Drawing.Point(299, 31)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(20, 20)
        Me.BtnSearch.TabIndex = 989
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(709, 186)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 973
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Text_ACC_FATHER
        '
        Me.Text_ACC_FATHER.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Text_ACC_FATHER.Cursor = System.Windows.Forms.Cursors.Default
        Me.Text_ACC_FATHER.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Text_ACC_FATHER.Location = New System.Drawing.Point(320, 31)
        Me.Text_ACC_FATHER.Name = "Text_ACC_FATHER"
        Me.Text_ACC_FATHER.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Text_ACC_FATHER.Size = New System.Drawing.Size(345, 21)
        Me.Text_ACC_FATHER.TabIndex = 988
        '
        'Chk_ACTIVAT
        '
        Me.Chk_ACTIVAT.AutoSize = True
        Me.Chk_ACTIVAT.Location = New System.Drawing.Point(315, 92)
        Me.Chk_ACTIVAT.Name = "Chk_ACTIVAT"
        Me.Chk_ACTIVAT.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Chk_ACTIVAT.Size = New System.Drawing.Size(93, 17)
        Me.Chk_ACTIVAT.TabIndex = 984
        Me.Chk_ACTIVAT.Text = "Chk_ACTIVAT"
        Me.Chk_ACTIVAT.UseVisualStyleBackColor = True
        '
        'TextACC1
        '
        Me.TextACC1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextACC1.Enabled = False
        Me.TextACC1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextACC1.Location = New System.Drawing.Point(349, 92)
        Me.TextACC1.Name = "TextACC1"
        Me.TextACC1.Size = New System.Drawing.Size(47, 21)
        Me.TextACC1.TabIndex = 979
        '
        'TXT_Account_NO1
        '
        Me.TXT_Account_NO1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_Account_NO1.Enabled = False
        Me.TXT_Account_NO1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TXT_Account_NO1.Location = New System.Drawing.Point(349, 92)
        Me.TXT_Account_NO1.Name = "TXT_Account_NO1"
        Me.TXT_Account_NO1.Size = New System.Drawing.Size(47, 21)
        Me.TXT_Account_NO1.TabIndex = 980
        '
        'TXT_PARENT_GUID
        '
        Me.TXT_PARENT_GUID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_PARENT_GUID.Location = New System.Drawing.Point(349, 92)
        Me.TXT_PARENT_GUID.Name = "TXT_PARENT_GUID"
        Me.TXT_PARENT_GUID.Size = New System.Drawing.Size(47, 20)
        Me.TXT_PARENT_GUID.TabIndex = 979
        '
        'TXT_GUID
        '
        Me.TXT_GUID.Location = New System.Drawing.Point(349, 92)
        Me.TXT_GUID.Name = "TXT_GUID"
        Me.TXT_GUID.Size = New System.Drawing.Size(47, 20)
        Me.TXT_GUID.TabIndex = 981
        '
        'TXT_END_ACCOUNT
        '
        Me.TXT_END_ACCOUNT.Location = New System.Drawing.Point(349, 92)
        Me.TXT_END_ACCOUNT.Name = "TXT_END_ACCOUNT"
        Me.TXT_END_ACCOUNT.Size = New System.Drawing.Size(47, 20)
        Me.TXT_END_ACCOUNT.TabIndex = 980
        '
        'TEXTReviewDate
        '
        Me.TEXTReviewDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTReviewDate.Enabled = False
        Me.TEXTReviewDate.ForeColor = System.Drawing.Color.Black
        Me.TEXTReviewDate.Location = New System.Drawing.Point(3, 43)
        Me.TEXTReviewDate.Name = "TEXTReviewDate"
        Me.TEXTReviewDate.Size = New System.Drawing.Size(195, 20)
        Me.TEXTReviewDate.TabIndex = 968
        Me.TEXTReviewDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTReferenceName
        '
        Me.TEXTReferenceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTReferenceName.Enabled = False
        Me.TEXTReferenceName.ForeColor = System.Drawing.Color.Black
        Me.TEXTReferenceName.Location = New System.Drawing.Point(3, 23)
        Me.TEXTReferenceName.Name = "TEXTReferenceName"
        Me.TEXTReferenceName.Size = New System.Drawing.Size(195, 20)
        Me.TEXTReferenceName.TabIndex = 967
        Me.TEXTReferenceName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(210, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(59, 15)
        Me.Label8.TabIndex = 971
        Me.Label8.Text = "اسم المراجع"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(198, 49)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 15)
        Me.Label7.TabIndex = 970
        Me.Label7.Text = "تاريخ المراجعة"
        '
        'TXT_COUINT_ACCOUNT
        '
        Me.TXT_COUINT_ACCOUNT.Location = New System.Drawing.Point(176, 240)
        Me.TXT_COUINT_ACCOUNT.Name = "TXT_COUINT_ACCOUNT"
        Me.TXT_COUINT_ACCOUNT.Size = New System.Drawing.Size(193, 20)
        Me.TXT_COUINT_ACCOUNT.TabIndex = 982
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BtnSearch1)
        Me.Panel3.Controls.Add(Me.EDITBUTTON)
        Me.Panel3.Controls.Add(Me.SAVEBUTTON)
        Me.Panel3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel3.ForeColor = System.Drawing.Color.Azure
        Me.Panel3.Location = New System.Drawing.Point(7, 305)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(750, 36)
        Me.Panel3.TabIndex = 972
        '
        'BtnSearch1
        '
        Me.BtnSearch1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BtnSearch1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnSearch1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.BtnSearch1.Image = Global.CC_JO.My.Resources.Resources.selection_view
        Me.BtnSearch1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnSearch1.Location = New System.Drawing.Point(1, 2)
        Me.BtnSearch1.Name = "BtnSearch1"
        Me.BtnSearch1.Size = New System.Drawing.Size(248, 30)
        Me.BtnSearch1.TabIndex = 983
        Me.BtnSearch1.Text = "بحث"
        Me.BtnSearch1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BtnSearch1.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TEXTReviewDate)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.TEXTReferenceName)
        Me.Panel4.Location = New System.Drawing.Point(12, 94)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(278, 73)
        Me.Panel4.TabIndex = 973
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.SteelBlue
        Me.Label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label9.Font = New System.Drawing.Font("Traditional Arabic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.Label9.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Location = New System.Drawing.Point(328, 5)
        Me.Label9.Name = "Label9"
        Me.Label9.Padding = New System.Windows.Forms.Padding(1)
        Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label9.Size = New System.Drawing.Size(432, 36)
        Me.Label9.TabIndex = 978
        Me.Label9.Text = "اضافة حساب"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.SteelBlue
        Me.Button3.Enabled = False
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Image = Global.CC_JO.My.Resources.Resources.Reset2_16x16
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(7, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(320, 38)
        Me.Button3.TabIndex = 979
        Me.Button3.Text = "إعادة ترقيم الحسابات"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button3.UseVisualStyleBackColor = False
        '
        'FRM_ACCOUNT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(765, 347)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Chk_ACTIVAT)
        Me.Controls.Add(Me.TXT_END_ACCOUNT)
        Me.Controls.Add(Me.TXT_GUID)
        Me.Controls.Add(Me.TextACC1)
        Me.Controls.Add(Me.TXT_PARENT_GUID)
        Me.Controls.Add(Me.TXT_Account_NO1)
        Me.Controls.Add(Me.TXT_COUINT_ACCOUNT)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_ACCOUNT"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "شجرة الحسابات"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents EDITBUTTON As System.Windows.Forms.Button
    Friend WithEvents TXT_Account_NO As System.Windows.Forms.TextBox
    Friend WithEvents TXT_Account_Name As System.Windows.Forms.TextBox
    Friend WithEvents TextlblGROUPACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TextAccountLevel As System.Windows.Forms.TextBox
    Friend WithEvents TextlblFIRSTDEBIT As System.Windows.Forms.TextBox
    Friend WithEvents TextlblFIRSTCREDIT As System.Windows.Forms.TextBox
    Friend WithEvents TextNotes As System.Windows.Forms.TextBox
    Friend WithEvents TXT_ACC As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblGROUPACCOUNT As System.Windows.Forms.Label
    Friend WithEvents lblCODE As System.Windows.Forms.Label
    Friend WithEvents lblFIRSTDEBIT As System.Windows.Forms.Label
    Friend WithEvents lblFIRSTCREDIT As System.Windows.Forms.Label
    Friend WithEvents lblNOTES As System.Windows.Forms.Label
    Friend WithEvents TEXTReviewDate As System.Windows.Forms.TextBox
    Friend WithEvents TEXTReferenceName As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LabelAccountPrivate As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckMasterAccount As System.Windows.Forms.CheckBox
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TXT_PARENT_GUID As System.Windows.Forms.TextBox
    Friend WithEvents TXT_END_ACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents TXT_GUID As System.Windows.Forms.TextBox
    Friend WithEvents TXT_COUINT_ACCOUNT As System.Windows.Forms.TextBox
    Friend WithEvents Chk_ACTIVAT As System.Windows.Forms.CheckBox
    Friend WithEvents Text_ACC_FATHER As System.Windows.Forms.TextBox
    Friend WithEvents BtnSearch1 As System.Windows.Forms.Button
    Friend WithEvents TextACC1 As System.Windows.Forms.TextBox
    Friend WithEvents TXT_Account_NO1 As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents BtnSearch As System.Windows.Forms.Button
    Private WithEvents TextAccountPrivate As TextBox
    Friend WithEvents TextACC11 As Label
    Friend WithEvents Panel1 As Panel
End Class
