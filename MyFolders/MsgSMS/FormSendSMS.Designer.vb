<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSendSMS
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSendSMS))
        Me.tabControl1 = New System.Windows.Forms.TabControl()
        Me.tabPage1 = New System.Windows.Forms.TabPage()
        Me.panel1 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Serial_Num = New System.Windows.Forms.Label()
        Me.Revision_Num = New System.Windows.Forms.Label()
        Me.Phone_Model = New System.Windows.Forms.Label()
        Me.Phone_Name = New System.Windows.Forms.Label()
        Me.label3 = New System.Windows.Forms.Label()
        Me.label22 = New System.Windows.Forms.Label()
        Me.label21 = New System.Windows.Forms.Label()
        Me.label20 = New System.Windows.Forms.Label()
        Me.ButPortDisconnect = New System.Windows.Forms.Button()
        Me.dataGridView3 = New System.Windows.Forms.DataGridView()
        Me.ButGetPort = New System.Windows.Forms.Button()
        Me.label23 = New System.Windows.Forms.Label()
        Me.pictureBox3 = New System.Windows.Forms.PictureBox()
        Me.tabPage2 = New System.Windows.Forms.TabPage()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.label4 = New System.Windows.Forms.Label()
        Me.ButSingle_SMS = New System.Windows.Forms.Button()
        Me.SMS_Text = New System.Windows.Forms.TextBox()
        Me.Cell_Num = New System.Windows.Forms.TextBox()
        Me.label8 = New System.Windows.Forms.Label()
        Me.label2 = New System.Windows.Forms.Label()
        Me.label1 = New System.Windows.Forms.Label()
        Me.tabPage4 = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.RB3 = New System.Windows.Forms.RadioButton()
        Me.RB1 = New System.Windows.Forms.RadioButton()
        Me.RB2 = New System.Windows.Forms.RadioButton()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ButCheckTheValues = New System.Windows.Forms.Button()
        Me.ButSingle_SMSALL = New System.Windows.Forms.Button()
        Me.ButOpenFile = New System.Windows.Forms.Button()
        Me.label25 = New System.Windows.Forms.Label()
        Me.label24 = New System.Windows.Forms.Label()
        Me.dataGridView1 = New System.Windows.Forms.DataGridView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.toolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.BackgroundWorker1 = New System.ComponentModel.BackgroundWorker()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.tabControl1.SuspendLayout()
        Me.tabPage1.SuspendLayout()
        Me.panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage2.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPage4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabControl1
        '
        Me.tabControl1.Controls.Add(Me.tabPage1)
        Me.tabControl1.Controls.Add(Me.tabPage2)
        Me.tabControl1.Controls.Add(Me.tabPage4)
        Me.tabControl1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.tabControl1.ImageList = Me.ImageList2
        Me.tabControl1.Location = New System.Drawing.Point(1, 1)
        Me.tabControl1.Name = "tabControl1"
        Me.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tabControl1.RightToLeftLayout = True
        Me.tabControl1.SelectedIndex = 0
        Me.tabControl1.Size = New System.Drawing.Size(631, 473)
        Me.tabControl1.TabIndex = 1
        '
        'tabPage1
        '
        Me.tabPage1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPage1.Controls.Add(Me.panel1)
        Me.tabPage1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.tabPage1.ImageKey = "Radio_16x16.png"
        Me.tabPage1.Location = New System.Drawing.Point(4, 24)
        Me.tabPage1.Name = "tabPage1"
        Me.tabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage1.Size = New System.Drawing.Size(623, 445)
        Me.tabPage1.TabIndex = 0
        Me.tabPage1.Text = "اتصال"
        Me.tabPage1.UseVisualStyleBackColor = True
        '
        'panel1
        '
        Me.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panel1.Controls.Add(Me.Label5)
        Me.panel1.Controls.Add(Me.PictureBox1)
        Me.panel1.Controls.Add(Me.Serial_Num)
        Me.panel1.Controls.Add(Me.Revision_Num)
        Me.panel1.Controls.Add(Me.Phone_Model)
        Me.panel1.Controls.Add(Me.Phone_Name)
        Me.panel1.Controls.Add(Me.label3)
        Me.panel1.Controls.Add(Me.label22)
        Me.panel1.Controls.Add(Me.label21)
        Me.panel1.Controls.Add(Me.label20)
        Me.panel1.Controls.Add(Me.ButPortDisconnect)
        Me.panel1.Controls.Add(Me.dataGridView3)
        Me.panel1.Controls.Add(Me.ButGetPort)
        Me.panel1.Controls.Add(Me.label23)
        Me.panel1.Controls.Add(Me.pictureBox3)
        Me.panel1.Location = New System.Drawing.Point(7, 7)
        Me.panel1.Name = "panel1"
        Me.panel1.Size = New System.Drawing.Size(611, 432)
        Me.panel1.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(507, 195)
        Me.Label5.Name = "Label5"
        Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label5.Size = New System.Drawing.Size(94, 17)
        Me.Label5.TabIndex = 732
        Me.Label5.Text = " ...ارجو الانتظار "
        Me.Label5.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox1.Location = New System.Drawing.Point(4, 6)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 731
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Serial_Num
        '
        Me.Serial_Num.AutoSize = True
        Me.Serial_Num.Location = New System.Drawing.Point(97, 174)
        Me.Serial_Num.Name = "Serial_Num"
        Me.Serial_Num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Serial_Num.Size = New System.Drawing.Size(22, 15)
        Me.Serial_Num.TabIndex = 31
        Me.Serial_Num.Text = "....."
        '
        'Revision_Num
        '
        Me.Revision_Num.AutoSize = True
        Me.Revision_Num.Font = New System.Drawing.Font("Times New Roman", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Revision_Num.Location = New System.Drawing.Point(97, 137)
        Me.Revision_Num.Name = "Revision_Num"
        Me.Revision_Num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Revision_Num.Size = New System.Drawing.Size(22, 13)
        Me.Revision_Num.TabIndex = 30
        Me.Revision_Num.Text = "....."
        '
        'Phone_Model
        '
        Me.Phone_Model.AutoSize = True
        Me.Phone_Model.Location = New System.Drawing.Point(97, 99)
        Me.Phone_Model.Name = "Phone_Model"
        Me.Phone_Model.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Phone_Model.Size = New System.Drawing.Size(22, 15)
        Me.Phone_Model.TabIndex = 29
        Me.Phone_Model.Text = "....."
        '
        'Phone_Name
        '
        Me.Phone_Name.AutoSize = True
        Me.Phone_Name.Location = New System.Drawing.Point(97, 62)
        Me.Phone_Name.Name = "Phone_Name"
        Me.Phone_Name.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Phone_Name.Size = New System.Drawing.Size(22, 15)
        Me.Phone_Name.TabIndex = 28
        Me.Phone_Name.Text = "....."
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(6, 174)
        Me.label3.Name = "label3"
        Me.label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label3.Size = New System.Drawing.Size(58, 15)
        Me.label3.TabIndex = 27
        Me.label3.Text = "Serial # :"
        '
        'label22
        '
        Me.label22.AutoSize = True
        Me.label22.Location = New System.Drawing.Point(6, 137)
        Me.label22.Name = "label22"
        Me.label22.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label22.Size = New System.Drawing.Size(61, 15)
        Me.label22.TabIndex = 26
        Me.label22.Text = "Revision :"
        '
        'label21
        '
        Me.label21.AutoSize = True
        Me.label21.Location = New System.Drawing.Point(6, 99)
        Me.label21.Name = "label21"
        Me.label21.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label21.Size = New System.Drawing.Size(84, 15)
        Me.label21.TabIndex = 25
        Me.label21.Text = "Phone Model :"
        '
        'label20
        '
        Me.label20.AutoSize = True
        Me.label20.Location = New System.Drawing.Point(6, 62)
        Me.label20.Name = "label20"
        Me.label20.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.label20.Size = New System.Drawing.Size(82, 15)
        Me.label20.TabIndex = 24
        Me.label20.Text = "Phone Name :"
        '
        'ButPortDisconnect
        '
        Me.ButPortDisconnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButPortDisconnect.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButPortDisconnect.ForeColor = System.Drawing.Color.Red
        Me.ButPortDisconnect.Image = Global.CC_JO.My.Resources.Resources.disconnect
        Me.ButPortDisconnect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButPortDisconnect.Location = New System.Drawing.Point(305, 401)
        Me.ButPortDisconnect.Name = "ButPortDisconnect"
        Me.ButPortDisconnect.Size = New System.Drawing.Size(299, 25)
        Me.ButPortDisconnect.TabIndex = 23
        Me.ButPortDisconnect.Text = "افصل الهاتف / المودم"
        Me.ButPortDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButPortDisconnect.UseVisualStyleBackColor = True
        '
        'dataGridView3
        '
        Me.dataGridView3.AllowUserToDeleteRows = False
        Me.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView3.Location = New System.Drawing.Point(3, 217)
        Me.dataGridView3.Name = "dataGridView3"
        Me.dataGridView3.ReadOnly = True
        Me.dataGridView3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dataGridView3.ShowCellToolTips = False
        Me.dataGridView3.Size = New System.Drawing.Size(601, 180)
        Me.dataGridView3.TabIndex = 22
        '
        'ButGetPort
        '
        Me.ButGetPort.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButGetPort.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButGetPort.ForeColor = System.Drawing.Color.DarkGreen
        Me.ButGetPort.Image = Global.CC_JO.My.Resources.Resources.Connect
        Me.ButGetPort.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButGetPort.Location = New System.Drawing.Point(3, 401)
        Me.ButGetPort.Name = "ButGetPort"
        Me.ButGetPort.Size = New System.Drawing.Size(299, 25)
        Me.ButGetPort.TabIndex = 21
        Me.ButGetPort.Text = "احصل على قائمة منفذ COM"
        Me.ButGetPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButGetPort.UseVisualStyleBackColor = True
        '
        'label23
        '
        Me.label23.AutoSize = True
        Me.label23.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label23.ForeColor = System.Drawing.Color.DarkRed
        Me.label23.Location = New System.Drawing.Point(243, 6)
        Me.label23.Name = "label23"
        Me.label23.Size = New System.Drawing.Size(123, 24)
        Me.label23.TabIndex = 19
        Me.label23.Text = "الاتصال - الإعداد"
        '
        'pictureBox3
        '
        Me.pictureBox3.BackColor = System.Drawing.Color.White
        Me.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pictureBox3.ErrorImage = Nothing
        Me.pictureBox3.Image = Global.CC_JO.My.Resources.Resources.sms1
        Me.pictureBox3.Location = New System.Drawing.Point(430, 4)
        Me.pictureBox3.Name = "pictureBox3"
        Me.pictureBox3.Size = New System.Drawing.Size(174, 185)
        Me.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pictureBox3.TabIndex = 18
        Me.pictureBox3.TabStop = False
        '
        'tabPage2
        '
        Me.tabPage2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPage2.Controls.Add(Me.PictureBox2)
        Me.tabPage2.Controls.Add(Me.label4)
        Me.tabPage2.Controls.Add(Me.ButSingle_SMS)
        Me.tabPage2.Controls.Add(Me.SMS_Text)
        Me.tabPage2.Controls.Add(Me.Cell_Num)
        Me.tabPage2.Controls.Add(Me.label8)
        Me.tabPage2.Controls.Add(Me.label2)
        Me.tabPage2.Controls.Add(Me.label1)
        Me.tabPage2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.tabPage2.ImageKey = "NewContact_16x16.png"
        Me.tabPage2.Location = New System.Drawing.Point(4, 24)
        Me.tabPage2.Name = "tabPage2"
        Me.tabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tabPage2.Size = New System.Drawing.Size(623, 445)
        Me.tabPage2.TabIndex = 1
        Me.tabPage2.Text = " رسالة  SMS واحدة"
        Me.tabPage2.UseVisualStyleBackColor = True
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.Control
        Me.PictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.Doveofpeace
        Me.PictureBox2.Location = New System.Drawing.Point(559, 3)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(1, 4, 1, 4)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(60, 53)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 194
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label4.Location = New System.Drawing.Point(22, 382)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(115, 15)
        Me.label4.TabIndex = 18
        Me.label4.Text = "Max 160 Characters"
        '
        'ButSingle_SMS
        '
        Me.ButSingle_SMS.Enabled = False
        Me.ButSingle_SMS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButSingle_SMS.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ButSingle_SMS.Image = Global.CC_JO.My.Resources.Resources.sms13
        Me.ButSingle_SMS.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButSingle_SMS.Location = New System.Drawing.Point(22, 400)
        Me.ButSingle_SMS.Name = "ButSingle_SMS"
        Me.ButSingle_SMS.Size = New System.Drawing.Size(532, 37)
        Me.ButSingle_SMS.TabIndex = 15
        Me.ButSingle_SMS.Text = "إرسال"
        Me.ButSingle_SMS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSingle_SMS.UseVisualStyleBackColor = True
        '
        'SMS_Text
        '
        Me.SMS_Text.Location = New System.Drawing.Point(25, 92)
        Me.SMS_Text.MaxLength = 160
        Me.SMS_Text.Multiline = True
        Me.SMS_Text.Name = "SMS_Text"
        Me.SMS_Text.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SMS_Text.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.SMS_Text.Size = New System.Drawing.Size(529, 287)
        Me.SMS_Text.TabIndex = 8
        Me.SMS_Text.Text = "Your Text Message"
        '
        'Cell_Num
        '
        Me.Cell_Num.Location = New System.Drawing.Point(25, 62)
        Me.Cell_Num.Name = "Cell_Num"
        Me.Cell_Num.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Cell_Num.Size = New System.Drawing.Size(529, 22)
        Me.Cell_Num.TabIndex = 7
        Me.Cell_Num.Text = "+962"
        Me.toolTip1.SetToolTip(Me.Cell_Num, " (+962) ادخل رقم الهاتف بصيغة ")
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label8.ForeColor = System.Drawing.Color.DarkRed
        Me.label8.Location = New System.Drawing.Point(229, 7)
        Me.label8.Name = "label8"
        Me.label8.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label8.Size = New System.Drawing.Size(165, 24)
        Me.label8.TabIndex = 7
        Me.label8.Text = "أرسل - S M S - واحد"
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label2.Location = New System.Drawing.Point(559, 95)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(38, 15)
        Me.label2.TabIndex = 1
        Me.label2.Text = "رســـالـــة"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label1.Location = New System.Drawing.Point(559, 65)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(57, 15)
        Me.label1.TabIndex = 0
        Me.label1.Text = "رقم الخلوي"
        '
        'tabPage4
        '
        Me.tabPage4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.tabPage4.Controls.Add(Me.GroupBox1)
        Me.tabPage4.Controls.Add(Me.Label6)
        Me.tabPage4.Controls.Add(Me.ButCheckTheValues)
        Me.tabPage4.Controls.Add(Me.ButSingle_SMSALL)
        Me.tabPage4.Controls.Add(Me.ButOpenFile)
        Me.tabPage4.Controls.Add(Me.label25)
        Me.tabPage4.Controls.Add(Me.label24)
        Me.tabPage4.Controls.Add(Me.dataGridView1)
        Me.tabPage4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.tabPage4.ImageKey = "NewFeed_16x16.png"
        Me.tabPage4.Location = New System.Drawing.Point(4, 24)
        Me.tabPage4.Name = "tabPage4"
        Me.tabPage4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tabPage4.Size = New System.Drawing.Size(623, 445)
        Me.tabPage4.TabIndex = 3
        Me.tabPage4.Text = "رسائل متعددة"
        Me.tabPage4.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB3)
        Me.GroupBox1.Controls.Add(Me.RB1)
        Me.GroupBox1.Controls.Add(Me.RB2)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(7, 147)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(613, 39)
        Me.GroupBox1.TabIndex = 762
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "اختيار مجموعة  "
        '
        'RB3
        '
        Me.RB3.AutoSize = True
        Me.RB3.BackColor = System.Drawing.Color.Transparent
        Me.RB3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RB3.ForeColor = System.Drawing.Color.Black
        Me.RB3.Location = New System.Drawing.Point(285, 14)
        Me.RB3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RB3.Name = "RB3"
        Me.RB3.Size = New System.Drawing.Size(53, 19)
        Me.RB3.TabIndex = 760
        Me.RB3.TabStop = True
        Me.RB3.Tag = ""
        Me.RB3.Text = "موظف"
        Me.RB3.UseVisualStyleBackColor = False
        '
        'RB1
        '
        Me.RB1.AutoSize = True
        Me.RB1.BackColor = System.Drawing.Color.Transparent
        Me.RB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RB1.ForeColor = System.Drawing.Color.Black
        Me.RB1.Location = New System.Drawing.Point(55, 14)
        Me.RB1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(54, 19)
        Me.RB1.TabIndex = 761
        Me.RB1.TabStop = True
        Me.RB1.Tag = ""
        Me.RB1.Text = "اعضاء"
        Me.RB1.UseVisualStyleBackColor = False
        '
        'RB2
        '
        Me.RB2.AutoSize = True
        Me.RB2.Checked = True
        Me.RB2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RB2.ForeColor = System.Drawing.Color.Black
        Me.RB2.Location = New System.Drawing.Point(480, 14)
        Me.RB2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(50, 19)
        Me.RB2.TabIndex = 758
        Me.RB2.TabStop = True
        Me.RB2.Text = "عملاء"
        Me.RB2.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.Black
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Yellow
        Me.Label6.ImageAlign = System.Drawing.ContentAlignment.BottomLeft
        Me.Label6.Location = New System.Drawing.Point(8, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label6.Size = New System.Drawing.Size(307, 33)
        Me.Label6.TabIndex = 41
        Me.Label6.Text = "0"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ButCheckTheValues
        '
        Me.ButCheckTheValues.Enabled = False
        Me.ButCheckTheValues.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButCheckTheValues.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButCheckTheValues.ForeColor = System.Drawing.Color.Red
        Me.ButCheckTheValues.Image = CType(resources.GetObject("ButCheckTheValues.Image"), System.Drawing.Image)
        Me.ButCheckTheValues.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButCheckTheValues.Location = New System.Drawing.Point(318, 46)
        Me.ButCheckTheValues.Name = "ButCheckTheValues"
        Me.ButCheckTheValues.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButCheckTheValues.Size = New System.Drawing.Size(299, 33)
        Me.ButCheckTheValues.TabIndex = 31
        Me.ButCheckTheValues.Text = "تحقق من القيم المستوردة"
        Me.ButCheckTheValues.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButCheckTheValues.UseVisualStyleBackColor = True
        '
        'ButSingle_SMSALL
        '
        Me.ButSingle_SMSALL.Enabled = False
        Me.ButSingle_SMSALL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButSingle_SMSALL.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButSingle_SMSALL.ForeColor = System.Drawing.Color.DarkGreen
        Me.ButSingle_SMSALL.Image = Global.CC_JO.My.Resources.Resources.sms13
        Me.ButSingle_SMSALL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButSingle_SMSALL.Location = New System.Drawing.Point(318, 82)
        Me.ButSingle_SMSALL.Name = "ButSingle_SMSALL"
        Me.ButSingle_SMSALL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ButSingle_SMSALL.Size = New System.Drawing.Size(299, 33)
        Me.ButSingle_SMSALL.TabIndex = 32
        Me.ButSingle_SMSALL.Text = "أرسل رسالة  SMS"
        Me.ButSingle_SMSALL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButSingle_SMSALL.UseVisualStyleBackColor = True
        '
        'ButOpenFile
        '
        Me.ButOpenFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButOpenFile.Font = New System.Drawing.Font("Times New Roman", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ButOpenFile.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.ButOpenFile.Image = Global.CC_JO.My.Resources.Resources.ExportToDOC_16x16
        Me.ButOpenFile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ButOpenFile.Location = New System.Drawing.Point(7, 45)
        Me.ButOpenFile.Name = "ButOpenFile"
        Me.ButOpenFile.Size = New System.Drawing.Size(308, 33)
        Me.ButOpenFile.TabIndex = 29
        Me.ButOpenFile.Text = "Open Excel File"
        Me.ButOpenFile.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ButOpenFile.UseVisualStyleBackColor = True
        '
        'label25
        '
        Me.label25.AutoSize = True
        Me.label25.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label25.ForeColor = System.Drawing.Color.Black
        Me.label25.Location = New System.Drawing.Point(286, 125)
        Me.label25.Name = "label25"
        Me.label25.Size = New System.Drawing.Size(113, 19)
        Me.label25.TabIndex = 39
        Me.label25.Text = "S M S  -  I N F O"
        '
        'label24
        '
        Me.label24.AutoSize = True
        Me.label24.Font = New System.Drawing.Font("Times New Roman", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.label24.ForeColor = System.Drawing.Color.DarkRed
        Me.label24.Location = New System.Drawing.Point(188, 6)
        Me.label24.Name = "label24"
        Me.label24.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.label24.Size = New System.Drawing.Size(246, 24)
        Me.label24.TabIndex = 27
        Me.label24.Text = "أرسال رسائل  -  S M S - جماعية"
        '
        'dataGridView1
        '
        Me.dataGridView1.AllowUserToAddRows = False
        Me.dataGridView1.AllowUserToDeleteRows = False
        Me.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridView1.Location = New System.Drawing.Point(7, 198)
        Me.dataGridView1.Name = "dataGridView1"
        Me.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.dataGridView1.Size = New System.Drawing.Size(613, 239)
        Me.dataGridView1.TabIndex = 0
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Radio_16x16.png")
        Me.ImageList2.Images.SetKeyName(1, "NewContact_16x16.png")
        Me.ImageList2.Images.SetKeyName(2, "NewFeed_16x16.png")
        '
        'toolTip1
        '
        Me.toolTip1.ToolTipTitle = "Information"
        '
        'imageList1
        '
        Me.imageList1.ImageStream = CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.imageList1.Images.SetKeyName(0, "sms1.png")
        Me.imageList1.Images.SetKeyName(1, "sms2.png")
        Me.imageList1.Images.SetKeyName(2, "sms3.png")
        '
        'BackgroundWorker1
        '
        '
        'FormSendSMS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(634, 474)
        Me.Controls.Add(Me.tabControl1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSendSMS"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "SMS"
        Me.tabControl1.ResumeLayout(False)
        Me.tabPage1.ResumeLayout(False)
        Me.panel1.ResumeLayout(False)
        Me.panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage2.ResumeLayout(False)
        Me.tabPage2.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPage4.ResumeLayout(False)
        Me.tabPage4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents tabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tabPage1 As System.Windows.Forms.TabPage
    Private WithEvents panel1 As System.Windows.Forms.Panel
    Private WithEvents Serial_Num As System.Windows.Forms.Label
    Private WithEvents Revision_Num As System.Windows.Forms.Label
    Private WithEvents Phone_Model As System.Windows.Forms.Label
    Private WithEvents Phone_Name As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents label22 As System.Windows.Forms.Label
    Private WithEvents label21 As System.Windows.Forms.Label
    Private WithEvents label20 As System.Windows.Forms.Label
    Private WithEvents ButPortDisconnect As System.Windows.Forms.Button
    Private WithEvents dataGridView3 As System.Windows.Forms.DataGridView
    Private WithEvents ButGetPort As System.Windows.Forms.Button
    Private WithEvents label23 As System.Windows.Forms.Label
    Private WithEvents pictureBox3 As System.Windows.Forms.PictureBox
    Private WithEvents tabPage2 As System.Windows.Forms.TabPage
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents ButSingle_SMS As System.Windows.Forms.Button
    Private WithEvents SMS_Text As System.Windows.Forms.TextBox
    Private WithEvents Cell_Num As System.Windows.Forms.TextBox
    Private WithEvents label8 As System.Windows.Forms.Label
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents tabPage4 As System.Windows.Forms.TabPage
    Private WithEvents ButCheckTheValues As System.Windows.Forms.Button
    Private WithEvents ButSingle_SMSALL As System.Windows.Forms.Button
    Private WithEvents ButOpenFile As System.Windows.Forms.Button
    Private WithEvents label25 As System.Windows.Forms.Label
    Private WithEvents label24 As System.Windows.Forms.Label
    Private WithEvents dataGridView1 As System.Windows.Forms.DataGridView
    Private WithEvents toolTip1 As System.Windows.Forms.ToolTip
    Private WithEvents imageList1 As System.Windows.Forms.ImageList
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Private WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents RB3 As System.Windows.Forms.RadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents ImageList2 As ImageList
End Class
