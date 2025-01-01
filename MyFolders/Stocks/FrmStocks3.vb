Option Explicit Off
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmStocks3
    Inherits Form
    Dim WithEvents BS As New BindingSource
    ReadOnly rpt As New rptStocks21
    Dim SqlDataAdapter1 As New SqlDataAdapter

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Panel4 As Panel


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
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton1 As RadioButton
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTO As DateTimePicker
    Friend WithEvents DateFrom As DateTimePicker
    Friend WithEvents ComboInvoiceNumber As ComboBox
    Friend WithEvents ComboPermissionNumber As ComboBox
    Friend WithEvents ComboGROUPNAME As ComboBox
    Friend WithEvents ComboITEMNAME As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents RadioButton6 As RadioButton
    Friend WithEvents RadioButton7 As RadioButton
    Friend WithEvents PRINTBUTTON As Button
    Friend WithEvents SEARCHBUTTON As Button
    Friend WithEvents DATAGRID As DataGrid
    Friend WithEvents STYLE As DataGridTableStyle
    Friend WithEvents COL1 As DataGridTextBoxColumn
    Friend WithEvents COL2 As DataGridTextBoxColumn
    Friend WithEvents COL3 As DataGridTextBoxColumn
    Friend WithEvents COL4 As DataGridTextBoxColumn
    Friend WithEvents COL5 As DataGridTextBoxColumn
    Friend WithEvents COL6 As DataGridTextBoxColumn
    Friend WithEvents COL7 As DataGridTextBoxColumn
    Friend WithEvents COL8 As DataGridTextBoxColumn
    Friend WithEvents COL9 As DataGridTextBoxColumn
    Friend WithEvents COL10 As DataGridTextBoxColumn
    Friend WithEvents COL11 As DataGridTextBoxColumn
    Friend WithEvents COL12 As DataGridTextBoxColumn
    Friend WithEvents COL13 As DataGridTextBoxColumn
    Friend WithEvents COL14 As DataGridTextBoxColumn
    Friend WithEvents COL15 As DataGridTextBoxColumn
    <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(FrmStocks3))
        Me.GroupBox1 = New GroupBox()
        Me.Panel1 = New Panel()
        Me.RadioButton7 = New RadioButton()
        Me.RadioButton1 = New RadioButton()
        Me.RadioButton6 = New RadioButton()
        Me.RadioButton2 = New RadioButton()
        Me.RadioButton5 = New RadioButton()
        Me.RadioButton3 = New RadioButton()
        Me.RadioButton4 = New RadioButton()
        Me.Label2 = New Label()
        Me.Label1 = New Label()
        Me.DateTO = New DateTimePicker()
        Me.DateFrom = New DateTimePicker()
        Me.ComboInvoiceNumber = New ComboBox()
        Me.ComboPermissionNumber = New ComboBox()
        Me.ComboGROUPNAME = New ComboBox()
        Me.ComboITEMNAME = New ComboBox()
        Me.DATAGRID = New DataGrid()
        Me.STYLE = New DataGridTableStyle()
        Me.COL1 = New DataGridTextBoxColumn()
        Me.COL2 = New DataGridTextBoxColumn()
        Me.COL3 = New DataGridTextBoxColumn()
        Me.COL4 = New DataGridTextBoxColumn()
        Me.COL5 = New DataGridTextBoxColumn()
        Me.COL6 = New DataGridTextBoxColumn()
        Me.COL7 = New DataGridTextBoxColumn()
        Me.COL8 = New DataGridTextBoxColumn()
        Me.COL9 = New DataGridTextBoxColumn()
        Me.COL10 = New DataGridTextBoxColumn()
        Me.COL11 = New DataGridTextBoxColumn()
        Me.COL12 = New DataGridTextBoxColumn()
        Me.COL13 = New DataGridTextBoxColumn()
        Me.COL14 = New DataGridTextBoxColumn()
        Me.COL15 = New DataGridTextBoxColumn()
        Me.Label3 = New Label()
        Me.Label4 = New Label()
        Me.Label5 = New Label()
        Me.Label6 = New Label()
        Me.PRINTBUTTON = New Button()
        Me.SEARCHBUTTON = New Button()
        Me.Panel2 = New Panel()
        Me.Panel4 = New Panel()
        Me.Panel3 = New Panel()
        Me.Label7 = New Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DATAGRID, ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New Point(397, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(165, 212)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "»ÕÀ »Ê«”ÿ…"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.RadioButton7)
        Me.Panel1.Controls.Add(Me.RadioButton1)
        Me.Panel1.Controls.Add(Me.RadioButton6)
        Me.Panel1.Controls.Add(Me.RadioButton2)
        Me.Panel1.Controls.Add(Me.RadioButton5)
        Me.Panel1.Controls.Add(Me.RadioButton3)
        Me.Panel1.Controls.Add(Me.RadioButton4)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New Point(3, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(159, 191)
        Me.Panel1.TabIndex = 113
        '
        'RadioButton7
        '
        Me.RadioButton7.AutoSize = True
        Me.RadioButton7.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton7.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton7.ForeColor = System.Drawing.Color.Black
        Me.RadioButton7.Location = New Point(54, 165)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New Size(96, 19)
        Me.RadioButton7.TabIndex = 6
        Me.RadioButton7.Text = "«’‰«› Õœ «·ÿ·»"
        Me.RadioButton7.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New Point(19, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New Size(131, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "—ﬁ„ «·√–‰ Ê  «—ÌŒ «·Õ—ﬂ…"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton6
        '
        Me.RadioButton6.AutoSize = True
        Me.RadioButton6.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton6.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton6.ForeColor = System.Drawing.Color.Black
        Me.RadioButton6.Location = New Point(60, 138)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New Size(90, 19)
        Me.RadioButton6.TabIndex = 5
        Me.RadioButton6.Text = "»Ì«‰«  «·«’‰«›"
        Me.RadioButton6.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New Point(69, 30)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New Size(81, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = " «—ÌŒ «·Õ—ﬂ…"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton5
        '
        Me.RadioButton5.AutoSize = True
        Me.RadioButton5.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton5.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton5.ForeColor = System.Drawing.Color.Black
        Me.RadioButton5.Location = New Point(27, 111)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New Size(123, 19)
        Me.RadioButton5.TabIndex = 4
        Me.RadioButton5.Text = "«·’‰› Ê  «—ÌŒ «·Õ—ﬂ…"
        Me.RadioButton5.UseVisualStyleBackColor = False
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New Point(6, 57)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New Size(144, 19)
        Me.RadioButton3.TabIndex = 2
        Me.RadioButton3.Text = "—ﬁ„ «·›« Ê—… Ê  «—ÌŒ «·Õ—ﬂ…"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'RadioButton4
        '
        Me.RadioButton4.AutoSize = True
        Me.RadioButton4.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton4.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.Black
        Me.RadioButton4.Location = New Point(16, 84)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New Size(134, 19)
        Me.RadioButton4.TabIndex = 3
        Me.RadioButton4.Text = "«·„Ã„Ê⁄… Ê  «—ÌŒ «·Õ—ﬂ…"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New Point(358, 131)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(20, 15)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "«·Ï"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New Point(359, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(19, 15)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "„‰"
        '
        'DateTO
        '
        Me.DateTO.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.DateTO.Checked = False
        Me.DateTO.CustomFormat = "yyyy/MM/dd"
        Me.DateTO.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.DateTO.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTO.Location = New Point(3, 127)
        Me.DateTO.Name = "DateTO"
        Me.DateTO.RightToLeftLayout = True
        Me.DateTO.ShowCheckBox = True
        Me.DateTO.Size = New Size(313, 22)
        Me.DateTO.TabIndex = 46
        '
        'DateFrom
        '
        Me.DateFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.DateFrom.Checked = False
        Me.DateFrom.CustomFormat = "yyyy/MM/dd"
        Me.DateFrom.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFrom.Location = New Point(2, 102)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.RightToLeftLayout = True
        Me.DateFrom.ShowCheckBox = True
        Me.DateFrom.Size = New Size(314, 22)
        Me.DateFrom.TabIndex = 45
        '
        'ComboInvoiceNumber
        '
        Me.ComboInvoiceNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.ComboInvoiceNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboInvoiceNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboInvoiceNumber.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboInvoiceNumber.Location = New Point(3, 28)
        Me.ComboInvoiceNumber.Name = "ComboInvoiceNumber"
        Me.ComboInvoiceNumber.Size = New Size(313, 23)
        Me.ComboInvoiceNumber.TabIndex = 44
        '
        'ComboPermissionNumber
        '
        Me.ComboPermissionNumber.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.ComboPermissionNumber.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboPermissionNumber.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboPermissionNumber.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboPermissionNumber.Location = New Point(3, 3)
        Me.ComboPermissionNumber.Name = "ComboPermissionNumber"
        Me.ComboPermissionNumber.Size = New Size(313, 23)
        Me.ComboPermissionNumber.TabIndex = 43
        '
        'ComboGROUPNAME
        '
        Me.ComboGROUPNAME.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.ComboGROUPNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboGROUPNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboGROUPNAME.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboGROUPNAME.Location = New Point(3, 53)
        Me.ComboGROUPNAME.Name = "ComboGROUPNAME"
        Me.ComboGROUPNAME.Size = New Size(313, 23)
        Me.ComboGROUPNAME.TabIndex = 50
        '
        'ComboITEMNAME
        '
        Me.ComboITEMNAME.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.ComboITEMNAME.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboITEMNAME.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboITEMNAME.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboITEMNAME.Location = New Point(3, 78)
        Me.ComboITEMNAME.Name = "ComboITEMNAME"
        Me.ComboITEMNAME.Size = New Size(313, 23)
        Me.ComboITEMNAME.TabIndex = 49
        '
        'DATAGRID
        '
        Me.DATAGRID.AlternatingBackColor = System.Drawing.Color.White
        Me.DATAGRID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.DATAGRID.BackColor = System.Drawing.Color.Silver
        Me.DATAGRID.BackgroundColor = System.Drawing.Color.White
        Me.DATAGRID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DATAGRID.CaptionBackColor = System.Drawing.Color.White
        Me.DATAGRID.CaptionFont = New Font("Microsoft Sans Serif", 8.25!)
        Me.DATAGRID.CaptionForeColor = System.Drawing.Color.Navy
        Me.DATAGRID.CaptionVisible = False
        Me.DATAGRID.DataMember = ""
        Me.DATAGRID.ForeColor = System.Drawing.Color.Black
        Me.DATAGRID.GridLineColor = System.Drawing.Color.Black
        Me.DATAGRID.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.DATAGRID.HeaderBackColor = System.Drawing.Color.Silver
        Me.DATAGRID.HeaderForeColor = System.Drawing.Color.Black
        Me.DATAGRID.LinkColor = System.Drawing.Color.Navy
        Me.DATAGRID.Location = New Point(3, 257)
        Me.DATAGRID.Name = "DATAGRID"
        Me.DATAGRID.ParentRowsBackColor = System.Drawing.Color.White
        Me.DATAGRID.ParentRowsForeColor = System.Drawing.Color.Black
        Me.DATAGRID.PreferredColumnWidth = 200
        Me.DATAGRID.ReadOnly = True
        Me.DATAGRID.SelectionBackColor = System.Drawing.Color.Navy
        Me.DATAGRID.SelectionForeColor = System.Drawing.Color.White
        Me.DATAGRID.Size = New Size(567, 156)
        Me.DATAGRID.TabIndex = 51
        Me.DATAGRID.TableStyles.AddRange(New DataGridTableStyle() {Me.STYLE})
        '
        'STYLE
        '
        Me.STYLE.AlternatingBackColor = System.Drawing.Color.Pink
        Me.STYLE.BackColor = System.Drawing.Color.Pink
        Me.STYLE.DataGrid = Me.DATAGRID
        Me.STYLE.ForeColor = System.Drawing.Color.Black
        Me.STYLE.GridColumnStyles.AddRange(New DataGridColumnStyle() {Me.COL1, Me.COL2, Me.COL3, Me.COL4, Me.COL5, Me.COL6, Me.COL7, Me.COL8, Me.COL9, Me.COL10, Me.COL11, Me.COL12, Me.COL13, Me.COL14, Me.COL15})
        Me.STYLE.GridLineColor = System.Drawing.Color.Blue
        Me.STYLE.HeaderForeColor = System.Drawing.Color.Black
        Me.STYLE.LinkColor = System.Drawing.SystemColors.Control
        Me.STYLE.MappingName = "STOCKS"
        Me.STYLE.PreferredColumnWidth = 100
        Me.STYLE.SelectionBackColor = System.Drawing.SystemColors.Control
        Me.STYLE.SelectionForeColor = System.Drawing.Color.Black
        '
        'COL1
        '
        Me.COL1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL1.Format = ""
        Me.COL1.FormatInfo = Nothing
        Me.COL1.HeaderText = "„”·”·"
        Me.COL1.MappingName = "STK1"
        Me.COL1.NullText = ""
        Me.COL1.Width = 75
        '
        'COL2
        '
        Me.COL2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL2.Format = ""
        Me.COL2.FormatInfo = Nothing
        Me.COL2.HeaderText = "«·„Œ“‰"
        Me.COL2.MappingName = "STK2"
        Me.COL2.NullText = ""
        Me.COL2.Width = 200
        '
        'COL3
        '
        Me.COL3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL3.Format = ""
        Me.COL3.FormatInfo = Nothing
        Me.COL3.HeaderText = "—ﬁ„ «·«–‰"
        Me.COL3.MappingName = "STK3"
        Me.COL3.NullText = ""
        Me.COL3.Width = 75
        '
        'COL4
        '
        Me.COL4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL4.Format = ""
        Me.COL4.FormatInfo = Nothing
        Me.COL4.HeaderText = " «—ÌŒ «·Õ—ﬂ…"
        Me.COL4.MappingName = "STK4"
        Me.COL4.NullText = ""
        Me.COL4.Width = 150
        '
        'COL5
        '
        Me.COL5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL5.Format = ""
        Me.COL5.FormatInfo = Nothing
        Me.COL5.HeaderText = "‰Ê⁄ «·«–‰"
        Me.COL5.MappingName = "STK5"
        Me.COL5.NullText = ""
        Me.COL5.Width = 200
        '
        'COL6
        '
        Me.COL6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL6.Format = ""
        Me.COL6.FormatInfo = Nothing
        Me.COL6.HeaderText = "—ﬁ„ «·›« Ê—…"
        Me.COL6.MappingName = "STK6"
        Me.COL6.NullText = ""
        Me.COL6.Width = 75
        '
        'COL7
        '
        Me.COL7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL7.Format = ""
        Me.COL7.FormatInfo = Nothing
        Me.COL7.HeaderText = "«·„Ã„Ê⁄…"
        Me.COL7.MappingName = "STK8"
        Me.COL7.NullText = ""
        Me.COL7.Width = 200
        '
        'COL8
        '
        Me.COL8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL8.Format = ""
        Me.COL8.FormatInfo = Nothing
        Me.COL8.HeaderText = "«·’‰›"
        Me.COL8.MappingName = "STK7"
        Me.COL8.NullText = ""
        Me.COL8.Width = 200
        '
        'COL9
        '
        Me.COL9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL9.Format = ""
        Me.COL9.FormatInfo = Nothing
        Me.COL9.HeaderText = "ÊÕœ… «·ﬁÌ«”"
        Me.COL9.MappingName = "STK9"
        Me.COL9.NullText = ""
        Me.COL9.Width = 150
        '
        'COL10
        '
        Me.COL10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL10.Format = ""
        Me.COL10.FormatInfo = Nothing
        Me.COL10.HeaderText = "—’Ìœ ”«»ﬁ"
        Me.COL10.MappingName = "STK10"
        Me.COL10.NullText = ""
        Me.COL10.Width = 150
        '
        'COL11
        '
        Me.COL11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL11.Format = ""
        Me.COL11.FormatInfo = Nothing
        Me.COL11.HeaderText = "Ê«—œ"
        Me.COL11.MappingName = "STK11"
        Me.COL11.NullText = ""
        Me.COL11.Width = 150
        '
        'COL12
        '
        Me.COL12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL12.Format = ""
        Me.COL12.FormatInfo = Nothing
        Me.COL12.HeaderText = "’«œ—"
        Me.COL12.MappingName = "STK12"
        Me.COL12.NullText = ""
        Me.COL12.Width = 150
        '
        'COL13
        '
        Me.COL13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL13.Format = ""
        Me.COL13.FormatInfo = Nothing
        Me.COL13.HeaderText = "—’Ìœ Õ«·Ï"
        Me.COL13.MappingName = "STK13"
        Me.COL13.NullText = ""
        Me.COL13.Width = 150
        '
        'COL14
        '
        Me.COL14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL14.Format = ""
        Me.COL14.FormatInfo = Nothing
        Me.COL14.HeaderText = "Õœ «·ÿ·»"
        Me.COL14.MappingName = "STK14"
        Me.COL14.NullText = ""
        Me.COL14.Width = 75
        '
        'COL15
        '
        Me.COL15.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL15.Format = ""
        Me.COL15.FormatInfo = Nothing
        Me.COL15.HeaderText = "”⁄— «·ÊÕœ…"
        Me.COL15.MappingName = "STK15"
        Me.COL15.NullText = ""
        Me.COL15.Width = 150
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New Point(333, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(45, 15)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "—ﬁ„ «·«–‰"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New Point(320, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(58, 15)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "—ﬁ„ «·›« Ê—…"
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New Point(330, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New Size(48, 15)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "«·„Ã„Ê⁄…"
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New Point(341, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New Size(37, 15)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "«·’‰›"
        '
        'PRINTBUTTON
        '
        Me.PRINTBUTTON.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.PRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PRINTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.PRINTBUTTON.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.PRINTBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRINTBUTTON.Location = New Point(1, 158)
        Me.PRINTBUTTON.Name = "PRINTBUTTON"
        Me.PRINTBUTTON.Size = New Size(192, 30)
        Me.PRINTBUTTON.TabIndex = 108
        Me.PRINTBUTTON.Text = "ÿ»«⁄…"
        Me.PRINTBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PRINTBUTTON.UseVisualStyleBackColor = False
        '
        'SEARCHBUTTON
        '
        Me.SEARCHBUTTON.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.SEARCHBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SEARCHBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SEARCHBUTTON.ForeColor = System.Drawing.Color.Black
        Me.SEARCHBUTTON.Image = Global.CC_JO.My.Resources.Resources.FindByID_16x16
        Me.SEARCHBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SEARCHBUTTON.Location = New Point(194, 158)
        Me.SEARCHBUTTON.Name = "SEARCHBUTTON"
        Me.SEARCHBUTTON.Size = New Size(192, 30)
        Me.SEARCHBUTTON.TabIndex = 107
        Me.SEARCHBUTTON.Text = "»ÕÀ"
        Me.SEARCHBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SEARCHBUTTON.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ComboPermissionNumber)
        Me.Panel2.Controls.Add(Me.SEARCHBUTTON)
        Me.Panel2.Controls.Add(Me.ComboInvoiceNumber)
        Me.Panel2.Controls.Add(Me.PRINTBUTTON)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ComboITEMNAME)
        Me.Panel2.Controls.Add(Me.DateTO)
        Me.Panel2.Controls.Add(Me.ComboGROUPNAME)
        Me.Panel2.Controls.Add(Me.DateFrom)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New Point(3, 22)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(389, 191)
        Me.Panel2.TabIndex = 110
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.GroupBox1)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Location = New Point(3, 34)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New Size(567, 221)
        Me.Panel4.TabIndex = 112
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Location = New Point(1, 1)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(569, 32)
        Me.Panel3.TabIndex = 742
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Image = Global.CC_JO.My.Resources.Resources.printpreview_32x32
        Me.Label7.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label7.Location = New Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New Size(567, 29)
        Me.Label7.TabIndex = 90
        Me.Label7.Text = "Õ—ﬂ… «·„Œ«“‰ »ÕÀ Ê ÿ»«⁄…"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmStocks3
        '
        Me.AutoScaleBaseSize = New Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New Size(572, 415)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.DATAGRID)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New Size(588, 454)
        Me.Name = "FrmStocks3"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Õ—ﬂ… «·„Œ«“‰ -- »ÕÀ Ê ÿ»«⁄…"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DATAGRID, ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmStocks3_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim Consum As New SqlConnection(constring)
        Dim ds As New DataSet With {
            .EnforceConstraints = False
        }
        Consum.Open()
        Dim str As New SqlCommand("", Consum)
        With str
            .CommandText = "SELECT * FROM STOCKS  WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
        End With
        SqlDataAdapter1 = New SqlDataAdapter(str)
        ds.Clear()
        SqlDataAdapter1.Fill(ds, "STOCKS")
        BS.DataSource = ds
        BS.DataMember = "STOCKS"
        ds.EnforceConstraints = True
        SqlDataAdapter1.Dispose()
        Consum.Close()
        Me.ComboPermissionNumber.Focus()
        Dim strSQL2 As New SqlCommand("SELECT distinct  STK3 FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Consum.Open()
        DR = strSQL2.ExecuteReader()
        Do While DR.Read()
            ComboPermissionNumber.Items.Add(DR(0))
        Loop
        Consum.Close()
        Dim strSQL3 As New SqlCommand("SELECT distinct  STK16 FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Consum.Open()
        DR = strSQL3.ExecuteReader()
        Do While DR.Read()
            ComboInvoiceNumber.Items.Add(DR(0))
        Loop
        Consum.Close()
        Dim strSQL4 As New SqlCommand("SELECT distinct  STK8 FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Consum.Open()
        DR = strSQL4.ExecuteReader()
        Do While DR.Read()
            ComboGROUPNAME.Items.Add(DR(0))
        Loop
        Consum.Close()
        Dim strSQL5 As New SqlCommand("SELECT distinct  STK7 FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'", Consum)
        Consum.Open()
        DR = strSQL5.ExecuteReader()
        Do While DR.Read()
            ComboITEMNAME.Items.Add(DR(0))
        Loop
        MangUsers()
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboPermissionNumber.Enabled = True
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboGROUPNAME.Enabled = False
        Me.ComboITEMNAME.Enabled = False
        Me.SEARCHBUTTON.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboPermissionNumber.Enabled = False
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboGROUPNAME.Enabled = False
        Me.ComboITEMNAME.Enabled = False
        Me.SEARCHBUTTON.Enabled = True
    End Sub
    Private Sub RadioButton3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton3.Click
        On Error Resume Next
        Me.ComboPermissionNumber.Enabled = False
        Me.ComboInvoiceNumber.Enabled = True
        Me.ComboGROUPNAME.Enabled = False
        Me.ComboITEMNAME.Enabled = False
        Me.SEARCHBUTTON.Enabled = True
    End Sub
    Private Sub RadioButton4_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton4.Click
        On Error Resume Next
        Me.ComboPermissionNumber.Enabled = False
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboGROUPNAME.Enabled = True
        Me.ComboITEMNAME.Enabled = False
        Me.SEARCHBUTTON.Enabled = True
    End Sub
    Private Sub RadioButton5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton5.Click
        On Error Resume Next
        Me.ComboPermissionNumber.Enabled = False
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboGROUPNAME.Enabled = False
        Me.ComboITEMNAME.Enabled = True

        Me.SEARCHBUTTON.Enabled = True
    End Sub
    Private Sub RadioButton6_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton6.Click
        On Error Resume Next
        SEARCHBUTTON.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboGROUPNAME.Enabled = False
        Me.ComboITEMNAME.Enabled = False
    End Sub
    Private Sub RadioButton7_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton7.Click
        On Error Resume Next
        SEARCHBUTTON.Enabled = False
        Me.ComboPermissionNumber.Enabled = False
        Me.ComboInvoiceNumber.Enabled = False
        Me.ComboGROUPNAME.Enabled = False
        Me.ComboITEMNAME.Enabled = False
    End Sub
    Private Sub SEARCHBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles SEARCHBUTTON.Click
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim Consum As New SqlConnection(constring)
        Dim txtFromDate As String
        Dim txtToDate As String
        txtFromDate = Format(Me.DateFrom.Value, "dd - MM - yyyy")
        txtToDate = Format(Me.DateTO.Value, "dd - MM - yyyy")
        Dim strsql1 As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK3='" & Me.ComboPermissionNumber.Text & "'ORDER BY STK16", Consum)
        Dim strsql2 As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'ORDER BY STK16", Consum)
        Dim strsql3 As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK16='" & Me.ComboInvoiceNumber.Text & "'ORDER BY STK16", Consum)
        Dim strsql4 As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK8='" & Me.ComboGROUPNAME.Text & "'ORDER BY STK16", Consum)
        Dim strsql5 As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK7='" & Me.ComboITEMNAME.Text & "'ORDER BY STK16", Consum)
        Dim ds1 As New DataSet
        Dim ds2 As New DataSet
        Dim ds3 As New DataSet
        Dim ds4 As New DataSet
        Dim ds5 As New DataSet
        Dim Adp1 As New SqlDataAdapter(strsql1)
        Dim Adp2 As New SqlDataAdapter(strsql2)
        Dim Adp3 As New SqlDataAdapter(strsql3)
        Dim Adp4 As New SqlDataAdapter(strsql4)
        Dim Adp5 As New SqlDataAdapter(strsql5)
        On Error Resume Next
        If Me.RadioButton1.Checked Then
            If Len(Me.ComboPermissionNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·√–‰  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboPermissionNumber.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            ds1.Clear()
            Adp1.Fill(ds1, "STOCKS")
            Me.DATAGRID.DataSource = ds1
            Me.DATAGRID.DataMember = "STOCKS"
            Me.DATAGRID.Refresh()
        ElseIf Me.RadioButton2.Checked Then
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            ds2.Clear()
            Adp2.Fill(ds2, "STOCKS")
            Me.DATAGRID.DataSource = ds2
            Me.DATAGRID.DataMember = "STOCKS"
            Me.DATAGRID.Refresh()
        ElseIf Me.RadioButton3.Checked Then
            If Len(Me.ComboInvoiceNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·›« Ê—…  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboInvoiceNumber.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            ds3.Clear()
            Adp3.Fill(ds3, "STOCKS")
            Me.DATAGRID.DataSource = ds3
            Me.DATAGRID.DataMember = "STOCKS"
            Me.DATAGRID.Refresh()
        ElseIf Me.RadioButton4.Checked Then
            If Len(Me.ComboGROUPNAME.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·„Ã„Ê⁄…  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboGROUPNAME.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            ds4.Clear()
            Adp4.Fill(ds4, "STOCKS")
            Me.DATAGRID.DataSource = ds4
            Me.DATAGRID.DataMember = "STOCKS"
            Me.DATAGRID.Refresh()
        ElseIf Me.RadioButton5.Checked Then
            If Len(Me.ComboITEMNAME.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·’‰›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboITEMNAME.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            ds5.Clear()
            Adp5.Fill(ds5, "STOCKS")
            Me.DATAGRID.DataSource = ds5
            Me.DATAGRID.DataMember = "STOCKS"
            Me.DATAGRID.Refresh()
        End If
        Adp1.Dispose()
        Adp2.Dispose()
        Adp3.Dispose()
        Adp4.Dispose()
        Adp5.Dispose()
        Consum.Close()
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As EventArgs) Handles PRINTBUTTON.Click
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim f As New FrmPRINT
        Dim txt As TextObject
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        On Error Resume Next
        If Me.RadioButton1.Checked Then
            If Len(Me.ComboPermissionNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·√–‰  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboPermissionNumber.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            Dim SqlDataAdapter1 As New SqlDataAdapter
            Dim Consum As New SqlConnection(constring)
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK3='" & Me.ComboPermissionNumber.Text & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "STOCKS")
            rpt.SetDataSource(ds)
            'rpt.RecordSelectionFormula = "{STOCKS.STK4} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND{STOCKS.STK3}= '" & Me.ComboBox1.Text & "'"
            txt = rpt.Section1.ReportObjects("Text9")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(70%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton2.Checked Then
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "STOCKS")
            rpt.SetDataSource(ds)
            'rpt.RecordSelectionFormula = "{STOCKS.STK4} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")"
            txt = rpt.Section1.ReportObjects("Text9")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(70%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton3.Checked Then
            If Len(Me.ComboInvoiceNumber.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· —ﬁ„ «·›« Ê—…  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboInvoiceNumber.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK16='" & Me.ComboInvoiceNumber.Text & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "STOCKS")
            rpt.SetDataSource(ds)
            'rpt.RecordSelectionFormula = "{STOCKS.STK4} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND{STOCKS.STK16}like '" & Me.ComboBox2.Text & "'"
            txt = rpt.Section1.ReportObjects("Text9")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(70%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton4.Checked Then
            If Len(Me.ComboGROUPNAME.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·„Ã„Ê⁄…  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboGROUPNAME.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK8='" & Me.ComboGROUPNAME.Text & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "STOCKS")
            rpt.SetDataSource(ds)
            Dim strsql5 As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK7='" & Me.ComboITEMNAME.Text & "'", Consum)
            'rpt.RecordSelectionFormula = "{STOCKS.STK4} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND {STOCKS.STK8} like '" & Me.ComboBox3.Text & "'"
            txt = rpt.Section1.ReportObjects("Text9")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(70%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton5.Checked Then
            If Len(Me.ComboITEMNAME.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·’‰›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboITEMNAME.Focus()
                Exit Sub
            End If
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM STOCKS WHERE  CUser='" & ModuleGeneral.CUser & "' and Year(STK4) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and STK4 BETWEEN'" & Me.DateFrom.Text.Trim & "'AND'" & Me.DateTO.Text.Trim & "'AND" & " STK7 like'" & Me.ComboITEMNAME.Text & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "STOCKS")
            rpt.SetDataSource(ds)
            'rpt.RecordSelectionFormula = "{STOCKS.STK4} in DateTime (" & txtFROMDate & ") to DateTime (" & txtToDate & ")AND {STOCKS.STK7} like '" & Me.ComboBox4.Text & "'"
            txt = rpt.Section1.ReportObjects("Text9")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd-MM-yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd-MM-yyyy")
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate

            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(70%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton6.Checked Then
            Dim f1 As New FrmPRINT
            Dim rpt1 As New rptStocks22
            GETSERVERNAMEANDDATABASENAME(rpt1, DBServer, "", "")
            txt = rpt1.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt1.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt1.Section1.ReportObjects("Text21")
            txt.Text = Directorate

            txt = rpt1.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt1.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f1.CrystalReportViewer1.ReportSource = rpt1
            f1.CrystalReportViewer1.Zoom(70%)
            f1.CrystalReportViewer1.RefreshReport()
            f1.Show()
        ElseIf Me.RadioButton7.Checked Then
            Dim f1 As New FrmPRINT
            Dim rpt2 As New rptStocks23
            GETSERVERNAMEANDDATABASENAME(rpt2, DBServer, "", "")

            rpt2.RecordSelectionFormula = "{STOCKSITEMS.SKITM7} <={STOCKSITEMS.SKITM11}"
            txt = rpt2.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt2.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt2.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt2.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt2.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f1.CrystalReportViewer1.ReportSource = rpt2
            f1.CrystalReportViewer1.Zoom(65%)
            f1.CrystalReportViewer1.RefreshReport()
            f1.Show()
        End If
        Consum.Close()
    End Sub

End Class
