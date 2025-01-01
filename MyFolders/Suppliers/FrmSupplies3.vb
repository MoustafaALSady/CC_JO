Option Explicit Off
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSupplies3
    Inherits System.Windows.Forms.Form

    Dim WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    ReadOnly rpt1 As New rptSupplies25
    ReadOnly rpt2 As New rptSupplies27
    ReadOnly rpt3 As New rptSupplies26
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox

#Region " Windows Form Designer generated code "
    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If components IsNot Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Private ReadOnly components As System.ComponentModel.IContainer
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ComboPermissionNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents SEARCHPRINTBUTTON As System.Windows.Forms.Button
    Friend WithEvents ComboITEMNAME As System.Windows.Forms.ComboBox
    Friend WithEvents ComboSupplierName As System.Windows.Forms.ComboBox
    Friend WithEvents ComboInvoiceNumber As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSupplies3))
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboITEMNAME = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboSupplierName = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboInvoiceNumber = New System.Windows.Forms.ComboBox()
        Me.ComboPermissionNumber = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTO = New System.Windows.Forms.DateTimePicker()
        Me.DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.SEARCHPRINTBUTTON = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(233, 30)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "«”„ «·’‰›"
        '
        'ComboITEMNAME
        '
        Me.ComboITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboITEMNAME.DisplayMember = "CATEGORYNAME"
        Me.ComboITEMNAME.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboITEMNAME.Location = New System.Drawing.Point(3, 27)
        Me.ComboITEMNAME.Name = "ComboITEMNAME"
        Me.ComboITEMNAME.Size = New System.Drawing.Size(224, 23)
        Me.ComboITEMNAME.TabIndex = 94
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(236, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 15)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "«”„ «·„Ê—œ"
        '
        'ComboSupplierName
        '
        Me.ComboSupplierName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboSupplierName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboSupplierName.DisplayMember = "CATEGORYNAME"
        Me.ComboSupplierName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboSupplierName.Location = New System.Drawing.Point(3, 51)
        Me.ComboSupplierName.Name = "ComboSupplierName"
        Me.ComboSupplierName.Size = New System.Drawing.Size(224, 23)
        Me.ComboSupplierName.TabIndex = 92
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(231, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(58, 15)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "—ﬁ„ «·›« Ê—…"
        '
        'ComboInvoiceNumber
        '
        Me.ComboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboInvoiceNumber.DisplayMember = "GROUPNAME"
        Me.ComboInvoiceNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboInvoiceNumber.Location = New System.Drawing.Point(3, 3)
        Me.ComboInvoiceNumber.Name = "ComboInvoiceNumber"
        Me.ComboInvoiceNumber.Size = New System.Drawing.Size(224, 23)
        Me.ComboInvoiceNumber.TabIndex = 86
        '
        'ComboPermissionNumber
        '
        Me.ComboPermissionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboPermissionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboPermissionNumber.DisplayMember = "CATEGORYNAME"
        Me.ComboPermissionNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboPermissionNumber.Location = New System.Drawing.Point(3, 75)
        Me.ComboPermissionNumber.Name = "ComboPermissionNumber"
        Me.ComboPermissionNumber.Size = New System.Drawing.Size(224, 23)
        Me.ComboPermissionNumber.TabIndex = 85
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(269, 128)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 84
        Me.Label2.Text = "«·Ï"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(270, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 83
        Me.Label1.Text = "„‰"
        '
        'DateTO
        '
        Me.DateTO.Checked = False
        Me.DateTO.CustomFormat = "yyyy/MM/dd"
        Me.DateTO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTO.Location = New System.Drawing.Point(3, 125)
        Me.DateTO.Name = "DateTO"
        Me.DateTO.RightToLeftLayout = True
        Me.DateTO.ShowCheckBox = True
        Me.DateTO.Size = New System.Drawing.Size(224, 22)
        Me.DateTO.TabIndex = 82
        '
        'DateFrom
        '
        Me.DateFrom.Checked = False
        Me.DateFrom.CustomFormat = "yyyy/MM/dd"
        Me.DateFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFrom.Location = New System.Drawing.Point(3, 101)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.RightToLeftLayout = True
        Me.DateFrom.ShowCheckBox = True
        Me.DateFrom.Size = New System.Drawing.Size(224, 22)
        Me.DateFrom.TabIndex = 81
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(244, 77)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "—ﬁ„ «·«–‰"
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(302, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(187, 200)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "»ÕÀ »Ê«”ÿ…"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.RadioButton6)
        Me.Panel2.Controls.Add(Me.RadioButton1)
        Me.Panel2.Controls.Add(Me.RadioButton5)
        Me.Panel2.Controls.Add(Me.RadioButton2)
        Me.Panel2.Controls.Add(Me.RadioButton4)
        Me.Panel2.Controls.Add(Me.RadioButton3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(3, 18)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(181, 179)
        Me.Panel2.TabIndex = 98
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton6.ForeColor = System.Drawing.Color.Black
        Me.RadioButton6.Location = New System.Drawing.Point(55, 144)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(119, 19)
        Me.RadioButton6.TabIndex = 734
        Me.RadioButton6.Text = "«·”Ã·«  «·€Ì— „—«Ã⁄…"
        Me.RadioButton6.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(98, 14)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(76, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "—ﬁ„ «·›« Ê—…"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton5.ForeColor = System.Drawing.Color.Black
        Me.RadioButton5.Location = New System.Drawing.Point(4, 117)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(170, 19)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.Text = "«Ã„«·Ï «·„‘ —Ì«  Œ·«· › —… „⁄Ì‰…"
        Me.RadioButton5.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(30, 39)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(144, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "«”„ «·’‰› Œ·«· › —… „⁄Ì‰…"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.Black
        Me.RadioButton4.Location = New System.Drawing.Point(111, 92)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(63, 19)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.Text = "—ﬁ„ «·«–‰"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New System.Drawing.Point(33, 66)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(141, 19)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "«”„ «·„Ê—œ Œ·«· › —… „⁄Ì‰…"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'SEARCHPRINTBUTTON
        '
        Me.SEARCHPRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SEARCHPRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SEARCHPRINTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SEARCHPRINTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.SEARCHPRINTBUTTON.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.SEARCHPRINTBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SEARCHPRINTBUTTON.Location = New System.Drawing.Point(2, 249)
        Me.SEARCHPRINTBUTTON.Name = "SEARCHPRINTBUTTON"
        Me.SEARCHPRINTBUTTON.Size = New System.Drawing.Size(496, 30)
        Me.SEARCHPRINTBUTTON.TabIndex = 96
        Me.SEARCHPRINTBUTTON.Text = "»ÕÀ Ê ÿ»«⁄…"
        Me.SEARCHPRINTBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SEARCHPRINTBUTTON.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(496, 211)
        Me.Panel1.TabIndex = 97
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.CheckBox1)
        Me.Panel3.Controls.Add(Me.ComboInvoiceNumber)
        Me.Panel3.Controls.Add(Me.ComboSupplierName)
        Me.Panel3.Controls.Add(Me.ComboPermissionNumber)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.ComboITEMNAME)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.DateFrom)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.DateTO)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(5, 22)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(293, 179)
        Me.Panel3.TabIndex = 98
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(3, 150)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(224, 19)
        Me.CheckBox1.TabIndex = 762
        Me.CheckBox1.Text = "‰‹‹ﬁ‹œÌ"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(2, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(496, 32)
        Me.Panel4.TabIndex = 740
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.CC_JO.My.Resources.Resources.printpreview_32x32
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(494, 29)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "›Ê« Ì— «·„‘ —Ì«  »ÕÀ Ê ÿ»«⁄…"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmSupplies3
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(502, 283)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.SEARCHPRINTBUTTON)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSupplies3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "›Ê« Ì— «·„‘ —Ì«  »ÕÀ Ê ÿ»«⁄…"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Public Sub DanLOd()
        On Error Resume Next

        ds.EnforceConstraints = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Consum.Open()
        Dim str As New SqlClient.SqlCommand("", Consum)
        If Me.CheckBox1.Checked = True Then
            Cash = True
            str.CommandText = "SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, USERNAME, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne, da1, ne1  FROM BUYS where  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & True & "'ORDER BY BUY2"
        Else
            Cash = False
            str.CommandText = "SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, USERNAME, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne , da1, ne1 FROM BUYS where  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & False & "'ORDER BY BUY2"

        End If

        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "BUYS")
        BS.DataSource = ds
        BS.DataMember = "BUYS"
        ds.EnforceConstraints = True
        SqlDataAdapter1.Dispose()
        Consum.Close()
        Me.ComboInvoiceNumber.Focus()
        Me.ComboInvoiceNumber.DataSource = ds.Tables("BUYS")
        Me.ComboInvoiceNumber.DisplayMember = "BUY2"

        'Dim strSQL2 As New SqlCommand("SELECT distinct  BITM3 FROM BUYSITEMS  where  CUser='" & CUser & "' ", Consum)
        'Consum.Open()
        'DR = strSQL2.ExecuteReader()
        'Do While DR.Read()
        '    ComboBox2.Items.Add(DR(0))
        'Loop
        'Consum.Close()
        ModuleGeneral.FILLCOMBOBOX1("STOCKSITEMS", "SKITM5", "CUser", ModuleGeneral.CUser, Me.ComboITEMNAME)

        Me.ComboSupplierName.DataSource = ds.Tables("BUYS")
        Me.ComboSupplierName.DisplayMember = "BUY5"
        Me.ComboPermissionNumber.DataSource = ds.Tables("BUYS")
        Me.ComboPermissionNumber.DisplayMember = "BUY4"
    End Sub
    Private Sub FrmSupplies3_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Me.DanLOd()
        Call MangUsers()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        Me.DanLOd()
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = True
        Me.ComboITEMNAME.Enabled = False
        Me.ComboSupplierName.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboITEMNAME.Enabled = True
        Me.ComboSupplierName.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboITEMNAME.Enabled = False
        Me.ComboSupplierName.Enabled = True
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboITEMNAME.Enabled = False
        Me.ComboSupplierName.Enabled = False
        Me.ComboPermissionNumber.Enabled = True
    End Sub
    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboITEMNAME.Enabled = False
        Me.ComboSupplierName.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub SEARCHPRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCHPRINTBUTTON.Click
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim f As New FrmPRINT
        Dim txt As TextObject
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        On Error Resume Next
        If Me.RadioButton1.Checked Then
            If Len(Me.ComboInvoiceNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ Õœœ —ﬁ„ «·›« Ê—…  ", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboInvoiceNumber.Focus()
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                rpt1.SetDataSource(ds)
                rpt1.RecordSelectionFormula = "{BUYS.BUY2} = " & Me.ComboInvoiceNumber.Text
                txt1 = rpt1.Section1.ReportObjects("Text15")
                txt1.Text = AssociationName
                txt1 = rpt1.Section1.ReportObjects("Text14")
                txt1.Text = Directorate
                txt1 = rpt1.Section1.ReportObjects("Text42")
                txt1.Text = Character
                txt1 = rpt1.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt1.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt1
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton2.Checked Then
            If Len(Me.ComboITEMNAME.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ Õœœ —ﬁ„ «·’‰›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboITEMNAME.Focus()
                Exit Sub
            ElseIf Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                'Dim ds As New DataSet
                'Dim str As New SqlCommand("SELECT * FROM BUYS  WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  BUY3 BETWEEN '" & Me.DateTimePicker1.Text.Trim & "'  AND  '" & Me.DateTimePicker2.Text.Trim & "'", Consum)
                'SqlDataAdapter1 = New SqlClient.SqlDataAdapter(Str)
                'ds.Clear()
                'SqlDataAdapter1.Fill(ds, "BUYS")
                'rpt3.SetDataSource(ds)
                rpt3.RecordSelectionFormula = "{BUYSITEMS.BITM3} like '" & Me.ComboITEMNAME.Text & "'"
                txt = rpt3.Section1.ReportObjects("Text8")
                txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt1 = rpt3.Section1.ReportObjects("Text9")
                txt1.Text = AssociationName
                txt1 = rpt3.Section1.ReportObjects("Text15")
                txt1.Text = Directorate
                txt1 = rpt3.Section1.ReportObjects("Text10")
                txt1.Text = Character
                txt1 = rpt3.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt3.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt3
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton3.Checked Then
            If Len(Me.ComboSupplierName.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ  Õœœ «·„Ê—œ  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboSupplierName.Focus()
                Exit Sub
            ElseIf Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT * FROM BUYS  WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  BUY3 BETWEEN '" & Me.DateFrom.Text.Trim & "'  AND  '" & Me.DateTO.Text.Trim & "'  AND BUY5 like '" & Me.ComboSupplierName.Text & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BUYS")
                rpt2.SetDataSource(ds)
                'rpt2.RecordSelectionFormula = "{BUYS.BUY3} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND {BUYS.BUY5} like '" & Me.ComboBox3.Text & "'"
                'rpt2.RecordSelectionFormula = "{BUYS.BUY5} like '" & Me.ComboBox3.Text & "'"

                txt = rpt2.Section1.ReportObjects("Text7")
                txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt1 = rpt2.Section1.ReportObjects("Text9")
                txt1.Text = AssociationName
                txt1 = rpt2.Section1.ReportObjects("Text15")
                txt1.Text = Directorate
                txt1 = rpt2.Section1.ReportObjects("Text10")
                txt1.Text = Character
                txt1 = rpt2.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt2.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(90%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton4.Checked Then
            If Len(Me.ComboPermissionNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ Õœœ —ﬁ„ «·√–‰  ", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboPermissionNumber.Focus()
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT * FROM BUYS  WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  BUY3 BETWEEN '" & Me.DateFrom.Text.Trim & "'  AND  '" & Me.DateTO.Text.Trim & "'  AND BUY4 like '" & Me.ComboPermissionNumber.Text & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BUYS")
                rpt1.SetDataSource(ds)
                'rpt1.RecordSelectionFormula = "{BUYS.BUY4}  like '" & Me.ComboBox4.Text & "'"
                txt1 = rpt3.Section1.ReportObjects("Text9")
                txt1.Text = AssociationName
                txt1 = rpt3.Section1.ReportObjects("Text15")
                txt1.Text = Directorate
                txt1 = rpt3.Section1.ReportObjects("Text10")
                txt1.Text = Character
                txt1 = rpt3.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt3.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt1
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton5.Checked Then
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, USERNAME, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne , da1, ne1  FROM BUYS  WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)

                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BUYS")
                rpt2.SetDataSource(ds)
                'rpt2.RecordSelectionFormula = "{BUYS.BUY3} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")"
                txt = rpt2.Section1.ReportObjects("Text7")
                txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt1 = rpt2.Section1.ReportObjects("Text9")
                txt1.Text = AssociationName
                txt1 = rpt2.Section1.ReportObjects("Text15")
                txt1.Text = Directorate
                txt1 = rpt2.Section1.ReportObjects("Text10")
                txt1.Text = Character
                txt1 = rpt2.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt2.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(90%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton6.Checked Then
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                Dim ds As New DataSet
                Dim str As New SqlCommand("SELECT BUY1, BUY2, BUY3, BUY4, BUY5, BUY6, BUY7, BUY8, BUY9, BUY10, BUY11, BUY12, BUY13, BUY14, BUY15, BUY16, BUY18, BUY19, BUY20, BUY21, BUY22, BUY23, BUY24, BUY25, BUY26, BUY27, BUY28, USERNAME, CUser, COUser, TYPE_CASH, TYPE_CRDT, Deleted, da, ne , da1, ne1 FROM BUYS   WHERE  CUser='" & CUser & "' and Year(BUY3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and BUY19 = '" & False & "'", Consum)

                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "BUYS")
                rpt2.SetDataSource(ds)
                txt = rpt2.Section1.ReportObjects("Text8")
                txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt1 = rpt2.Section1.ReportObjects("Text9")
                txt1.Text = AssociationName
                txt1 = rpt2.Section1.ReportObjects("Text15")
                txt1.Text = Directorate
                txt1 = rpt2.Section1.ReportObjects("Text10")
                txt1.Text = Character
                txt1 = rpt2.Section1.ReportObjects("TEXT40")
                txt1.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt1 = rpt2.Section1.ReportObjects("Text44")
                txt1.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        End If
        Consum.Close()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboInvoiceNumber, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboITEMNAME, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboSupplierName, e, )
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboPermissionNumber, e, )
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
