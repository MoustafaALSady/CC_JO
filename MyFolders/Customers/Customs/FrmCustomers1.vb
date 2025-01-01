Option Explicit Off
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmCustomers1
    Inherits System.Windows.Forms.Form
    Public WithEvents BS As New BindingSource
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter
    Dim SqlDataAdapter2 As New SqlClient.SqlDataAdapter
    ReadOnly ds As New DataSet
    ReadOnly ds1 As New DataSet
    ReadOnly rpt1 As New rptCustomers19
    ReadOnly rpt2 As New rptCustomers11
    ReadOnly rpt3 As New rptCustomers10
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    ReadOnly F As Boolean = False
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
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboPermissionNumber As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DateTO As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SEARCHPRINTBUTTON As System.Windows.Forms.Button
    Friend WithEvents ComboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents ComboItem As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboInvoiceNumber As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCustomers1))
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboInvoiceNumber = New System.Windows.Forms.ComboBox()
        Me.ComboPermissionNumber = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTO = New System.Windows.Forms.DateTimePicker()
        Me.DateFrom = New System.Windows.Forms.DateTimePicker()
        Me.ComboBox10 = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadioButton6 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton5 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.RadioButton4 = New System.Windows.Forms.RadioButton()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.ComboCustomerName = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.ComboItem = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SEARCHPRINTBUTTON = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(219, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 15)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "—ﬁ„ «·√–‰"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(206, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 15)
        Me.Label5.TabIndex = 72
        Me.Label5.Text = "—ﬁ„ «·›« Ê—…"
        '
        'ComboInvoiceNumber
        '
        Me.ComboInvoiceNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboInvoiceNumber.Location = New System.Drawing.Point(3, 4)
        Me.ComboInvoiceNumber.Name = "ComboInvoiceNumber"
        Me.ComboInvoiceNumber.Size = New System.Drawing.Size(199, 23)
        Me.ComboInvoiceNumber.TabIndex = 66
        '
        'ComboPermissionNumber
        '
        Me.ComboPermissionNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboPermissionNumber.Location = New System.Drawing.Point(3, 77)
        Me.ComboPermissionNumber.Name = "ComboPermissionNumber"
        Me.ComboPermissionNumber.Size = New System.Drawing.Size(199, 23)
        Me.ComboPermissionNumber.TabIndex = 65
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(244, 129)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 15)
        Me.Label2.TabIndex = 64
        Me.Label2.Text = "«·Ï"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(245, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "„‰"
        '
        'DateTO
        '
        Me.DateTO.Checked = False
        Me.DateTO.CustomFormat = "yyyy/MM/dd"
        Me.DateTO.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.DateTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTO.Location = New System.Drawing.Point(3, 126)
        Me.DateTO.Name = "DateTO"
        Me.DateTO.RightToLeftLayout = True
        Me.DateTO.ShowCheckBox = True
        Me.DateTO.Size = New System.Drawing.Size(199, 22)
        Me.DateTO.TabIndex = 62
        '
        'DateFrom
        '
        Me.DateFrom.Checked = False
        Me.DateFrom.CustomFormat = "yyyy/MM/dd"
        Me.DateFrom.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFrom.Location = New System.Drawing.Point(3, 101)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.RightToLeftLayout = True
        Me.DateFrom.ShowCheckBox = True
        Me.DateFrom.Size = New System.Drawing.Size(199, 22)
        Me.DateFrom.TabIndex = 61
        '
        'ComboBox10
        '
        Me.ComboBox10.ForeColor = System.Drawing.Color.Black
        Me.ComboBox10.Location = New System.Drawing.Point(24, -48)
        Me.ComboBox10.Name = "ComboBox10"
        Me.ComboBox10.Size = New System.Drawing.Size(224, 23)
        Me.ComboBox10.TabIndex = 59
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(279, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(179, 203)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "»ÕÀ »Ê«”ÿ…"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.RadioButton6)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.RadioButton5)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Controls.Add(Me.RadioButton4)
        Me.Panel3.Controls.Add(Me.RadioButton3)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(173, 182)
        Me.Panel3.TabIndex = 763
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton6.ForeColor = System.Drawing.Color.Black
        Me.RadioButton6.Location = New System.Drawing.Point(44, 148)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(119, 19)
        Me.RadioButton6.TabIndex = 733
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
        Me.RadioButton1.Location = New System.Drawing.Point(87, 13)
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
        Me.RadioButton5.Location = New System.Drawing.Point(2, 121)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(161, 19)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.Text = "«Ã„«·Ï «·„»Ì⁄«  Œ·«· › —… „⁄Ì‰…"
        Me.RadioButton5.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(19, 40)
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
        Me.RadioButton4.Location = New System.Drawing.Point(100, 94)
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
        Me.RadioButton3.Location = New System.Drawing.Point(23, 67)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(140, 19)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "«”„ «·⁄„Ì· Œ·«· › —… „⁄Ì‰…"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'ComboCustomerName
        '
        Me.ComboCustomerName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboCustomerName.Location = New System.Drawing.Point(3, 53)
        Me.ComboCustomerName.Name = "ComboCustomerName"
        Me.ComboCustomerName.Size = New System.Drawing.Size(199, 23)
        Me.ComboCustomerName.TabIndex = 74
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(212, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(52, 15)
        Me.Label7.TabIndex = 75
        Me.Label7.Text = "«”„ «·⁄„Ì·"
        '
        'ComboItem
        '
        Me.ComboItem.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboItem.Location = New System.Drawing.Point(3, 29)
        Me.ComboItem.Name = "ComboItem"
        Me.ComboItem.Size = New System.Drawing.Size(199, 23)
        Me.ComboItem.TabIndex = 76
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(208, 33)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 15)
        Me.Label8.TabIndex = 77
        Me.Label8.Text = "«”„ «·’‰›"
        '
        'SEARCHPRINTBUTTON
        '
        Me.SEARCHPRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SEARCHPRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SEARCHPRINTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SEARCHPRINTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.SEARCHPRINTBUTTON.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.SEARCHPRINTBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SEARCHPRINTBUTTON.Location = New System.Drawing.Point(2, 253)
        Me.SEARCHPRINTBUTTON.Name = "SEARCHPRINTBUTTON"
        Me.SEARCHPRINTBUTTON.Size = New System.Drawing.Size(463, 32)
        Me.SEARCHPRINTBUTTON.TabIndex = 78
        Me.SEARCHPRINTBUTTON.Text = "»ÕÀ Ê ÿ»«⁄…"
        Me.SEARCHPRINTBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SEARCHPRINTBUTTON.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New System.Drawing.Point(2, 32)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(463, 218)
        Me.Panel1.TabIndex = 79
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ComboItem)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.CheckBox1)
        Me.Panel2.Controls.Add(Me.ComboPermissionNumber)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.DateTO)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DateFrom)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.ComboCustomerName)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.ComboInvoiceNumber)
        Me.Panel2.Location = New System.Drawing.Point(3, 25)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(270, 182)
        Me.Panel2.TabIndex = 762
        '
        'CheckBox1
        '
        Me.CheckBox1.BackColor = System.Drawing.Color.SteelBlue
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.Location = New System.Drawing.Point(3, 152)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(199, 23)
        Me.CheckBox1.TabIndex = 761
        Me.CheckBox1.Text = "‰‹‹ﬁ‹œÌ"
        Me.CheckBox1.UseVisualStyleBackColor = False
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New System.Drawing.Point(2, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(463, 29)
        Me.Panel4.TabIndex = 740
        '
        'Label3
        '
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(461, 27)
        Me.Label3.TabIndex = 732
        Me.Label3.Text = "›Ê« Ì— «·„»Ì⁄«  »ÕÀ Ê ÿ»«⁄…"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmCustomers1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(467, 286)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.SEARCHPRINTBUTTON)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ComboBox10)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmCustomers1"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "›Ê« Ì— «·„»Ì⁄«  »ÕÀ Ê ÿ»«⁄…"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmCustomers1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        DanLOd()
        Call MangUsers()
    End Sub
    Public Sub DanLOd()
        On Error Resume Next
        ds.EnforceConstraints = False
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim str As New SqlClient.SqlCommand("", Consum)
        If Me.CheckBox1.Checked = True Then
            Cash = True
            str.CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE   CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & True & "' ORDER BY SLS1"
        Else
            Cash = False
            str.CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE   CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & False & "' ORDER BY SLS1"
        End If
        SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
        ds.Clear()
        Consum.Open()
        SqlDataAdapter1.Fill(ds, "SALES")
        BS.DataSource = ds
        BS.DataMember = "SALES"
        Dim str1 As New SqlClient.SqlCommand("", Consum) With {
            .CommandText = "SELECT SITM1, SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, (([SITM5] * [SITM6]) * (100 - [SITM7])) / 100 AS SITM8, SITM9, SITM10, SITM11, SLS2 FROM SALESITEMS ORDER BY SLS2"
        }
        Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str1)
        Me.ds1.Clear()
        SqlDataAdapter2.Fill(ds1, "SALESITEMS")
        ds.EnforceConstraints = True
        'ds1.EnforceConstraints = True
        SqlDataAdapter1.Dispose()
        SqlDataAdapter2.Dispose()
        Me.ComboInvoiceNumber.DataSource = ds.Tables("SALES")
        Me.ComboInvoiceNumber.DisplayMember = "SLS2"
        Me.ComboCustomerName.DataSource = ds.Tables("SALES")
        Me.ComboCustomerName.DisplayMember = "SLS5"
        Me.ComboPermissionNumber.DataSource = ds.Tables("SALES")
        Me.ComboPermissionNumber.DisplayMember = "SLS4"
        Consum.Close()

        Dim strSQL2 As New SqlCommand("SELECT distinct  SITM3 FROM SALESITEMS ", Consum)
        Consum.Open()
        DR = strSQL2.ExecuteReader()
        Do While DR.Read()
            ComboItem.Items.Add(DR(0))
        Loop
        Consum.Close()
    End Sub
    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        DanLOd()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboInvoiceNumber.KeyPress
        AutoComplete(ComboInvoiceNumber, e, )
    End Sub
    Private Sub ComboBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboItem.KeyPress
        AutoComplete(ComboItem, e, )
    End Sub
    Private Sub ComboBox3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboCustomerName.KeyPress
        AutoComplete(ComboCustomerName, e, )
    End Sub
    Private Sub ComboBox4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ComboPermissionNumber.KeyPress
        AutoComplete(ComboPermissionNumber, e, )
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = True
        Me.ComboItem.Enabled = False
        Me.ComboCustomerName.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboItem.Enabled = True
        Me.ComboCustomerName.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton3.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboItem.Enabled = False
        Me.ComboCustomerName.Enabled = True
        Me.ComboPermissionNumber.Enabled = False
    End Sub
    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton4.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboItem.Enabled = False
        Me.ComboCustomerName.Enabled = False
        Me.ComboPermissionNumber.Enabled = True
    End Sub
    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton5.Click
        On Error Resume Next
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboItem.Enabled = False
        Me.ComboCustomerName.Enabled = False
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
        Dim Consum As New SqlClient.SqlConnection(constring)
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim f As New FrmPRINT
        Dim txt As TextObject
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        On Error Resume Next
        'Try
        If Me.RadioButton1.Checked Then
            If Len(Me.ComboInvoiceNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ Õœœ —ﬁ„ «·›« Ê—…  ", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboInvoiceNumber.Focus()
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")


                ds1.EnforceConstraints = False
                Dim str1 As New SqlClient.SqlCommand("", Consum)
                If Me.CheckBox1.Checked = True Then
                    With str1
                        .CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE   CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & True & "' ORDER BY SLS1"
                    End With
                Else
                    With str1
                        .CommandText = "SELECT SLS1, SLS2, SLS3, SLS4, SLS5, SLS6, SLS7, SLS8, SLS9, SLS10, SLS11, SLS12, SLS13, SLS14, SLS15, SLS16, SLS17, SLS18, SLS19, SLS20, SLS21, SLS22, SLS23, SLS24, SLS25, SLS26, SLS27, SLS28, SLS29, SLS30, SLS31, TYPE_CASH, TYPE_CRDT, DELETED, USERNAME, Auditor, CUser, COUser, da, ne, da1, ne1 FROM SALES WHERE   CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' and deleted ='" & False & "' and type_cash ='" & False & "' ORDER BY SLS1"
                    End With
                End If
                Me.ds.EnforceConstraints = False
                Consum.Open()
                Dim str2 As New SqlClient.SqlCommand("", Consum)
                With str2
                    .CommandText = "SELECT SITM1, SITM2, SITM3, SITM4, SITM5, SITM6, SITM7, (([SITM5] * [SITM6]) * (100 - [SITM7])) / 100 AS SITM8, SITM9, SITM10, SITM11, SLS2 FROM SALESITEMS "
                End With
                ds1.EnforceConstraints = False

                Me.SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str1)
                Me.SqlDataAdapter2 = New SqlClient.SqlDataAdapter(str2)
                Me.ds1.Clear()
                Me.SqlDataAdapter1.Fill(Me.ds1, "SALES")
                Me.SqlDataAdapter2.Fill(Me.ds1, "SALESITEMS")
                Me.ds1.Relations.Add("REL1", Me.ds1.Tables("SALES").Columns("SLS2"), Me.ds1.Tables("SALESITEMS").Columns("SLS2"), True)

                'Me.BS.DataSource = Me.ds
                'Me.BS.DataMember = "SALES"
                Me.ds1.EnforceConstraints = True

                Me.SqlDataAdapter1.Dispose()
                Me.SqlDataAdapter2.Dispose()
                If Consum.State = ConnectionState.Open Then
                    Consum.Close()
                End If
                rpt1.SetDataSource(ds1)
                rpt1.RecordSelectionFormula = "{SALES.SLS2} = " & Me.ComboInvoiceNumber.Text & " AND {SALESITEMS.SLS2} = " & Me.ComboInvoiceNumber.Text & ""
                txt = rpt1.Section1.ReportObjects("TEXT15")
                txt.Text = AssociationName
                txt = rpt1.Section1.ReportObjects("TEXT14")
                txt.Text = Directorate
                txt = rpt1.Section1.ReportObjects("TEXT42")
                txt.Text = Character
                txt = rpt1.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt1.Section1.ReportObjects("TEXT44")
                txt.Text = Recorded
                txt = rpt1.Section1.ReportObjects("TEXT43")
                txt.Text = Ty1
                f.CrystalReportViewer1.ReportSource = rpt1
                f.CrystalReportViewer1.Zoom(85%)
                f.CrystalReportViewer1.RefreshReport()
                f.CrystalReportViewer1.Refresh()
                f.Show()
            End If
        ElseIf Me.RadioButton2.Checked Then
            If Len(Me.ComboItem.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ Õœœ —ﬁ„ «·’‰›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboItem.Focus()
                Exit Sub
            ElseIf Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt3, DBServer, "", "")
                rpt3.SetDataSource(ds)
                rpt3.RecordSelectionFormula = " {SALESITEMS.SITM3} like '" & Me.ComboItem.Text & "'"
                'rpt3.RecordSelectionFormula = "{SALES.SLS3} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND {SALESITEMS.SITM3} like '" & Me.ComboBox2.Text & "'"
                txt = rpt3.Section1.ReportObjects("Text8")
                txt.Text = "Œ·«· «·› —… „‰" & " " & "_" & " " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt3.Section1.ReportObjects("TEXT9")
                txt.Text = AssociationName
                txt = rpt3.Section1.ReportObjects("Text10")
                txt.Text = Character
                txt = rpt3.Section1.ReportObjects("Text15")
                txt.Text = Directorate
                txt = rpt3.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt3.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt3
                f.CrystalReportViewer1.Zoom(65%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton3.Checked Then
            If Len(Me.ComboCustomerName.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ  Õœœ «·⁄„Ì·  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboCustomerName.Focus()
                Exit Sub
            ElseIf Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                rpt2.SetDataSource(ds)
                rpt2.RecordSelectionFormula = "{SALES.SLS3} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND {SALES.SLS5} like '" & Me.ComboCustomerName.Text & "'"
                txt = rpt2.Section1.ReportObjects("Text7")
                txt.Text = "Œ·«· «·› —… „‰" & " " & "_" & " " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt2.Section1.ReportObjects("TEXT8")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("Text9")
                txt.Text = Character
                txt = rpt2.Section1.ReportObjects("Text15")
                txt.Text = Directorate
                txt = rpt2.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt2.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(85%)
                f.CrystalReportViewer1.RefreshReport()
                f.CrystalReportViewer1.Refresh()
                f.Show()
            End If
        ElseIf Me.RadioButton4.Checked Then
            If Len(Me.ComboPermissionNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ Õœœ —ﬁ„ «·√–‰  ", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboPermissionNumber.Focus()
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
                rpt1.RecordSelectionFormula = "{SALES.SLS4} like '" & Me.ComboPermissionNumber.Text & "'"
                txt = rpt1.Section1.ReportObjects("TEXT15")
                txt.Text = AssociationName
                txt = rpt1.Section1.ReportObjects("TEXT14")
                txt.Text = Directorate
                txt = rpt1.Section1.ReportObjects("TEXT42")
                txt.Text = Character
                txt = rpt1.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt1.Section1.ReportObjects("TEXT44")
                txt.Text = Recorded
                txt = rpt1.Section1.ReportObjects("TEXT43")
                txt.Text = Ty1
                f.CrystalReportViewer1.ReportSource = rpt1
                f.CrystalReportViewer1.Zoom(85%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        ElseIf Me.RadioButton5.Checked Then
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            Else
                GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")
                rpt2.SetDataSource(ds)
                rpt2.RecordSelectionFormula = "{SALES.SLS3} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")"
                txt = rpt2.Section1.ReportObjects("Text7")
                txt.Text = "Œ·«· «·› —… „‰" & " " & "_" & " " & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
                txt = rpt2.Section1.ReportObjects("TEXT8")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("Text9")
                txt.Text = Character
                txt = rpt2.Section1.ReportObjects("Text15")
                txt.Text = Directorate
                txt = rpt2.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt2.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(85%)
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
                Dim str As New SqlCommand("SELECT * FROM SALES  WHERE  CUser='" & CUser & "' and Year(SLS3) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and   SLS3 BETWEEN '" & Me.DateFrom.Text.Trim & "'  AND  '" & Me.DateTO.Text.Trim & "'  AND SLS30 = '" & False & "'", Consum)
                SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
                ds.Clear()
                SqlDataAdapter1.Fill(ds, "SALES")
                rpt2.SetDataSource(ds)
                'rpt2.RecordSelectionFormula = "{SALES.SLS3} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND {SALES.SLS30} = '" & False & "'"
                txt = rpt2.Section1.ReportObjects("Text7")
                txt.Text = "Œ·«· «·› —… „‰" & " " & "_" & " " & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd-MM-yyyy")
                txt = rpt2.Section1.ReportObjects("TEXT8")
                txt.Text = AssociationName
                txt = rpt2.Section1.ReportObjects("TEXT15")
                txt.Text = Directorate
                txt = rpt2.Section1.ReportObjects("Text10")
                txt.Text = Character
                txt = rpt2.Section1.ReportObjects("TEXT40")
                txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
                txt = rpt2.Section1.ReportObjects("Text44")
                txt.Text = Recorded
                f.CrystalReportViewer1.ReportSource = rpt2
                f.CrystalReportViewer1.Zoom(85%)
                f.CrystalReportViewer1.RefreshReport()
                f.Show()
            End If
        End If
        Consum.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message, "ErrorSAVEBUTTON", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Consum.Close()
        'End Try


    End Sub


End Class
