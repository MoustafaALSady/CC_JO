Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmEmployees5
    Inherits System.Windows.Forms.Form
    Dim WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    Friend WithEvents PRINTBUTTON As System.Windows.Forms.Button
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents SEARCHBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label2 As Label
    Dim SqlDataAdapter1 As New SqlClient.SqlDataAdapter

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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboEmployeeName As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents ComboMonths As System.Windows.Forms.ComboBox
    Friend WithEvents DATAGRID As System.Windows.Forms.DataGrid
    Friend WithEvents STYLE As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents COL1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL7 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL8 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL9 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL10 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL11 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL12 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL13 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL14 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL15 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL16 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL17 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL18 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL19 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL20 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL21 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL22 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL23 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents COL24 As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmEmployees5))
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboEmployeeName = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.RadioButton3 = New System.Windows.Forms.RadioButton()
        Me.RadioButton1 = New System.Windows.Forms.RadioButton()
        Me.RadioButton2 = New System.Windows.Forms.RadioButton()
        Me.DATAGRID = New System.Windows.Forms.DataGrid()
        Me.STYLE = New System.Windows.Forms.DataGridTableStyle()
        Me.COL1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL7 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL8 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL9 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL10 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL11 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL12 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL13 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL14 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL15 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL16 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL17 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL18 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL19 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL20 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL21 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL22 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL23 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.COL24 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.ComboMonths = New System.Windows.Forms.ComboBox()
        Me.PRINTBUTTON = New System.Windows.Forms.Button()
        Me.SEARCHBUTTON = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DATAGRID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(352, 6)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 15)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "«·„ÊŸ›"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(208, -19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 27)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "—ﬁ„ «·«–‰"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(352, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "‘Â—"
        '
        'ComboEmployeeName
        '
        Me.ComboEmployeeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboEmployeeName.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboEmployeeName.Location = New System.Drawing.Point(7, 2)
        Me.ComboEmployeeName.Name = "ComboEmployeeName"
        Me.ComboEmployeeName.Size = New System.Drawing.Size(343, 23)
        Me.ComboEmployeeName.TabIndex = 59
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New System.Drawing.Point(407, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(152, 102)
        Me.GroupBox1.TabIndex = 58
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "»ÕÀ »Ê«”ÿ…"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.RadioButton3)
        Me.Panel3.Controls.Add(Me.RadioButton1)
        Me.Panel3.Controls.Add(Me.RadioButton2)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(146, 81)
        Me.Panel3.TabIndex = 452
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New System.Drawing.Point(13, 56)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(119, 19)
        Me.RadioButton3.TabIndex = 734
        Me.RadioButton3.Text = "«·”Ã·«  «·€Ì— „—«Ã⁄…"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(15, 3)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(117, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "«”„ «·„ÊŸ› Ê«· «—ÌŒ"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(21, 30)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(111, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "⁄—÷ «·ﬂ· Ê«· «—ÌŒ"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'DATAGRID
        '
        Me.DATAGRID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DATAGRID.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DATAGRID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DATAGRID.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DATAGRID.CaptionFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DATAGRID.CaptionVisible = False
        Me.DATAGRID.DataMember = ""
        Me.DATAGRID.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DATAGRID.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DATAGRID.Location = New System.Drawing.Point(3, 147)
        Me.DATAGRID.Name = "DATAGRID"
        Me.DATAGRID.ReadOnly = True
        Me.DATAGRID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DATAGRID.Size = New System.Drawing.Size(566, 192)
        Me.DATAGRID.TabIndex = 67
        Me.DATAGRID.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.STYLE})
        '
        'STYLE
        '
        Me.STYLE.AlternatingBackColor = System.Drawing.Color.Pink
        Me.STYLE.BackColor = System.Drawing.Color.Pink
        Me.STYLE.DataGrid = Me.DATAGRID
        Me.STYLE.ForeColor = System.Drawing.Color.Black
        Me.STYLE.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.COL1, Me.COL2, Me.COL3, Me.COL4, Me.COL5, Me.COL6, Me.COL7, Me.COL8, Me.COL9, Me.COL10, Me.COL11, Me.COL12, Me.COL13, Me.COL14, Me.COL15, Me.COL16, Me.COL17, Me.COL18, Me.COL19, Me.COL20, Me.COL21, Me.COL22, Me.COL23, Me.COL24})
        Me.STYLE.GridLineColor = System.Drawing.Color.Blue
        Me.STYLE.HeaderForeColor = System.Drawing.Color.Black
        Me.STYLE.LinkColor = System.Drawing.SystemColors.Control
        Me.STYLE.MappingName = "SALARIES"
        Me.STYLE.SelectionBackColor = System.Drawing.SystemColors.Control
        Me.STYLE.SelectionForeColor = System.Drawing.Color.Black
        '
        'COL1
        '
        Me.COL1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL1.Format = ""
        Me.COL1.FormatInfo = Nothing
        Me.COL1.HeaderText = "„”·”·"
        Me.COL1.MappingName = "SLY1"
        Me.COL1.NullText = ""
        Me.COL1.Width = 75
        '
        'COL2
        '
        Me.COL2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL2.Format = ""
        Me.COL2.FormatInfo = Nothing
        Me.COL2.HeaderText = "«·„ÊŸ›"
        Me.COL2.MappingName = "SLY2"
        Me.COL2.NullText = ""
        Me.COL2.Width = 200
        '
        'COL3
        '
        Me.COL3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL3.Format = ""
        Me.COL3.FormatInfo = Nothing
        Me.COL3.HeaderText = "«·‘Â—"
        Me.COL3.MappingName = "SLY3"
        Me.COL3.NullText = ""
        Me.COL3.Width = 150
        '
        'COL4
        '
        Me.COL4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL4.Format = ""
        Me.COL4.FormatInfo = Nothing
        Me.COL4.HeaderText = "«·„— » «·«”«”Ï"
        Me.COL4.MappingName = "SLY4"
        Me.COL4.NullText = ""
        Me.COL4.Width = 150
        '
        'COL5
        '
        Me.COL5.Format = ""
        Me.COL5.FormatInfo = Nothing
        Me.COL5.Width = 75
        '
        'COL6
        '
        Me.COL6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL6.Format = ""
        Me.COL6.FormatInfo = Nothing
        Me.COL6.HeaderText = "ﬁÌ„… «·«÷«›Ï"
        Me.COL6.MappingName = "SLY6"
        Me.COL6.NullText = ""
        Me.COL6.Width = 150
        '
        'COL7
        '
        Me.COL7.Format = ""
        Me.COL7.FormatInfo = Nothing
        Me.COL7.Width = 75
        '
        'COL8
        '
        Me.COL8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL8.Format = ""
        Me.COL8.FormatInfo = Nothing
        Me.COL8.HeaderText = "ﬁÌ„… «·⁄·«Ê« "
        Me.COL8.MappingName = "SLY8"
        Me.COL8.NullText = ""
        Me.COL8.Width = 150
        '
        'COL9
        '
        Me.COL9.Format = ""
        Me.COL9.FormatInfo = Nothing
        Me.COL9.Width = 75
        '
        'COL10
        '
        Me.COL10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL10.Format = ""
        Me.COL10.FormatInfo = Nothing
        Me.COL10.HeaderText = "ﬁÌ„… «·Õ«›“"
        Me.COL10.MappingName = "SLY10"
        Me.COL10.NullText = ""
        Me.COL10.Width = 150
        '
        'COL11
        '
        Me.COL11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL11.Format = ""
        Me.COL11.FormatInfo = Nothing
        Me.COL11.HeaderText = "„ﬂ«›√…"
        Me.COL11.MappingName = "SLY11"
        Me.COL11.NullText = ""
        Me.COL11.Width = 150
        '
        'COL12
        '
        Me.COL12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL12.Format = ""
        Me.COL12.FormatInfo = Nothing
        Me.COL12.HeaderText = "»œ· ÿ»Ì⁄… ⁄„·"
        Me.COL12.MappingName = "SLY12"
        Me.COL12.NullText = ""
        Me.COL12.Width = 150
        '
        'COL13
        '
        Me.COL13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL13.Format = ""
        Me.COL13.FormatInfo = Nothing
        Me.COL13.HeaderText = "»œ· ‰ﬁ·"
        Me.COL13.MappingName = "SLY13"
        Me.COL13.NullText = ""
        Me.COL13.Width = 150
        '
        'COL14
        '
        Me.COL14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL14.Format = ""
        Me.COL14.FormatInfo = Nothing
        Me.COL14.HeaderText = "»œ· ”ﬂ‰"
        Me.COL14.MappingName = "SLY14"
        Me.COL14.NullText = ""
        Me.COL14.Width = 150
        '
        'COL15
        '
        Me.COL15.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL15.Format = ""
        Me.COL15.FormatInfo = Nothing
        Me.COL15.HeaderText = "«÷«›«  ¬Œ—Ï"
        Me.COL15.MappingName = "SLY15"
        Me.COL15.NullText = ""
        Me.COL15.Width = 150
        '
        'COL16
        '
        Me.COL16.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL16.Format = ""
        Me.COL16.FormatInfo = Nothing
        Me.COL16.HeaderText = "«·«Ã— «·„ €Ì—"
        Me.COL16.MappingName = "SLY16"
        Me.COL16.NullText = ""
        Me.COL16.Width = 200
        '
        'COL17
        '
        Me.COL17.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL17.Format = ""
        Me.COL17.FormatInfo = Nothing
        Me.COL17.HeaderText = "«· √„Ì‰« "
        Me.COL17.MappingName = "SLY17"
        Me.COL17.NullText = ""
        Me.COL17.Width = 150
        '
        'COL18
        '
        Me.COL18.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL18.Format = ""
        Me.COL18.FormatInfo = Nothing
        Me.COL18.HeaderText = "«·÷„«‰ «·«Ã „«⁄Ì"
        Me.COL18.MappingName = "SLY18"
        Me.COL18.NullText = ""
        Me.COL18.Width = 150
        '
        'COL19
        '
        Me.COL19.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL19.Format = ""
        Me.COL19.FormatInfo = Nothing
        Me.COL19.HeaderText = "”·›…"
        Me.COL19.MappingName = "SLY19"
        Me.COL19.NullText = ""
        Me.COL19.Width = 150
        '
        'COL20
        '
        Me.COL20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL20.Format = ""
        Me.COL20.FormatInfo = Nothing
        Me.COL20.HeaderText = "Œ’Ê„«  «· √ŒÌ—"
        Me.COL20.MappingName = "SLY20"
        Me.COL20.NullText = ""
        Me.COL20.Width = 150
        '
        'COL21
        '
        Me.COL21.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL21.Format = ""
        Me.COL21.FormatInfo = Nothing
        Me.COL21.HeaderText = "Œ’Ê„«  «·€Ì«»"
        Me.COL21.MappingName = "SLY21"
        Me.COL21.NullText = ""
        Me.COL21.Width = 150
        '
        'COL22
        '
        Me.COL22.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL22.Format = ""
        Me.COL22.FormatInfo = Nothing
        Me.COL22.HeaderText = "Œ’Ê„«  «·Ã“«¡« "
        Me.COL22.MappingName = "SLY22"
        Me.COL22.NullText = ""
        Me.COL22.Width = 150
        '
        'COL23
        '
        Me.COL23.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL23.Format = ""
        Me.COL23.FormatInfo = Nothing
        Me.COL23.HeaderText = "Œ’Ê„«  ¬Œ—Ï"
        Me.COL23.MappingName = "SLY23"
        Me.COL23.NullText = ""
        Me.COL23.Width = 150
        '
        'COL24
        '
        Me.COL24.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL24.Format = ""
        Me.COL24.FormatInfo = Nothing
        Me.COL24.HeaderText = "’«›Ï «·„— »"
        Me.COL24.MappingName = "SLY24"
        Me.COL24.NullText = ""
        Me.COL24.Width = 200
        '
        'ComboMonths
        '
        Me.ComboMonths.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboMonths.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboMonths.ForeColor = System.Drawing.Color.Black
        Me.ComboMonths.Items.AddRange(New Object() {"ﬂ«‰Ê‰ À«‰Ì", "‘»«ÿ", "«–«—", "‰Ì”«‰", "«Ì«—", "Õ“Ì—«‰", " „Ê“", "«»", "«Ì·Ê·", " ‘—Ì‰ «Ê·", " ‘—Ì‰ À«‰Ì", "ﬂ«‰Ê‰ À«‰Ì"})
        Me.ComboMonths.Location = New System.Drawing.Point(7, 26)
        Me.ComboMonths.Name = "ComboMonths"
        Me.ComboMonths.Size = New System.Drawing.Size(343, 23)
        Me.ComboMonths.TabIndex = 239
        '
        'PRINTBUTTON
        '
        Me.PRINTBUTTON.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PRINTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PRINTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PRINTBUTTON.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.PRINTBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRINTBUTTON.Location = New System.Drawing.Point(7, 51)
        Me.PRINTBUTTON.Name = "PRINTBUTTON"
        Me.PRINTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.PRINTBUTTON.Size = New System.Drawing.Size(168, 25)
        Me.PRINTBUTTON.TabIndex = 449
        Me.PRINTBUTTON.Text = "ÿ»«⁄…"
        Me.PRINTBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PRINTBUTTON.UseVisualStyleBackColor = False
        '
        'SEARCHBUTTON
        '
        Me.SEARCHBUTTON.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SEARCHBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SEARCHBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SEARCHBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SEARCHBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SEARCHBUTTON.Image = Global.CC_JO.My.Resources.Resources.FindByID_16x16
        Me.SEARCHBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SEARCHBUTTON.Location = New System.Drawing.Point(176, 51)
        Me.SEARCHBUTTON.Name = "SEARCHBUTTON"
        Me.SEARCHBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SEARCHBUTTON.Size = New System.Drawing.Size(174, 25)
        Me.SEARCHBUTTON.TabIndex = 448
        Me.SEARCHBUTTON.Text = "»ÕÀ"
        Me.SEARCHBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SEARCHBUTTON.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.ComboMonths)
        Me.Panel1.Controls.Add(Me.SEARCHBUTTON)
        Me.Panel1.Controls.Add(Me.PRINTBUTTON)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.ComboEmployeeName)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel1.Location = New System.Drawing.Point(1, 20)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(400, 81)
        Me.Panel1.TabIndex = 450
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.GroupBox1)
        Me.Panel2.Location = New System.Drawing.Point(3, 36)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(566, 109)
        Me.Panel2.TabIndex = 451
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Location = New System.Drawing.Point(3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(566, 32)
        Me.Panel4.TabIndex = 742
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Image = Global.CC_JO.My.Resources.Resources.printpreview_32x32
        Me.Label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(564, 29)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "«·„— »«  »ÕÀ Ê ÿ»«⁄…"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmEmployees5
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(573, 343)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.DATAGRID)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label3)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmEmployees5"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "«·„— »«  -- »ÕÀ Êÿ»«⁄…"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DATAGRID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub FrmEmployees5_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Try
            Select Case e.KeyCode
                Case Keys.F1
                    SEARCHBUTTON_Click(sender, e)
                Case Keys.F5
                    PRINTBUTTON_Click(sender, e)
                Case Keys.Escape
                    Me.Close()
            End Select
            e.Handled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub FrmEmployees5_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        ds.EnforceConstraints = False
        Consum.Open()
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT SLY1, SLY2 FROM SALARIES   WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "' "
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "SALARIES")
            BS.DataSource = ds
            BS.DataMember = "SALARIES"
        End With
        Consum.Close()
        'FILLCOMBOBOX("SALARIES", "SLY2", Me.ComboBox1)
        Me.ComboEmployeeName.DataSource = Me.BS
        Me.ComboEmployeeName.DisplayMember = "SLY2"
        SHOWBUTTON()
        Call MangUsers()
    End Sub
    Private Sub ComboBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        AutoComplete(ComboEmployeeName, e, )
    End Sub
    Private Sub SHOWBUTTON()
        On Error Resume Next
        Me.PRINTBUTTON.Enabled = LockPrint
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboEmployeeName.Enabled = False
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboEmployeeName.Enabled = True
    End Sub
    Private Sub SEARCHBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SEARCHBUTTON.Click
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
        Dim strsql1 As New SqlCommand("SELECT SLY1, SLY2, SLY3, SLY4, SLY6, SLY8, SLY10, SLY11, SLY12, SLY13, SLY14, SLY15, SLY16, SLY17, SLY18, SLY19, SLY20, SLY21, SLY22, SLY23, SLY24  FROM SALARIES WHERE  SLY3='" & Me.ComboMonths.Text & "'" & "AND" & " SLY2='" & Me.ComboEmployeeName.Text & "'", Consum)
        Dim strsql2 As New SqlCommand("SELECT SLY1, SLY2, SLY3, SLY4, SLY6, SLY8, SLY10, SLY11, SLY12, SLY13, SLY14, SLY15, SLY16, SLY17, SLY18, SLY19, SLY20, SLY21, SLY22, SLY23, SLY24 FROM SALARIES WHERE  SLY3='" & Me.ComboMonths.Text & "'", Consum)
        Dim strsql3 As New SqlCommand("SELECT SLY1, SLY2, SLY3, SLY4, SLY6, SLY8, SLY10, SLY11, SLY12, SLY13, SLY14, SLY15, SLY16, SLY17, SLY18, SLY19, SLY20, SLY21, SLY22, SLY23, SLY24 FROM SALARIES WHERE  CUser='" & CUser & "' and   SLY28='" & False & "'", Consum)
        Dim ds As New DataSet
        Dim Adp1 As New SqlClient.SqlDataAdapter(strsql1)
        Dim Adp2 As New SqlClient.SqlDataAdapter(strsql2)
        Dim Adp3 As New SqlClient.SqlDataAdapter(strsql3)
        On Error Resume Next
        If Me.RadioButton1.Checked Then
            If Len(Me.ComboEmployeeName.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·„ÊŸ›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboEmployeeName.Focus()
                Exit Sub
            End If
            If Len(Me.ComboMonths.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·‘Â—  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths.Focus()
                Exit Sub
            End If
            ds.Clear()
            Adp1.Fill(ds, "SALARIES")
            Me.DATAGRID.DataSource = ds
            Me.DATAGRID.DataMember = "SALARIES"
            Me.DATAGRID.Refresh()
        ElseIf Me.RadioButton2.Checked Then
            If Len(Me.ComboMonths.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·‘Â—  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths.Focus()
                Exit Sub
            End If
            ds.Clear()
            Adp3.Fill(ds, "SALARIES")
            Me.DATAGRID.DataSource = ds
            Me.DATAGRID.DataMember = "SALARIES"
            Me.DATAGRID.Refresh()
        ElseIf Me.RadioButton3.Checked Then
            If Len(Me.ComboMonths.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·‘Â—  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths.Focus()
                Exit Sub
            End If
            ds.Clear()
            Adp3.Fill(ds, "SALARIES")
            Me.DATAGRID.DataSource = ds
            Me.DATAGRID.DataMember = "SALARIES"
            Me.DATAGRID.Refresh()
        End If
        Adp1.Dispose()
        Adp2.Dispose()
        Adp3.Dispose()
        Consum.Close()
    End Sub
    Private Sub PRINTBUTTON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRINTBUTTON.Click
        If TestNet = False Then
            MsgBox("«·« ’«· »«·«‰ —‰  €Ì— „ Ê›—", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        If BS.Count = 0 Then Beep() : Exit Sub
        If LockPrint = False Then
            MsgBox("⁄›Ê« .. ﬁ«„ «·√œ„‰ »„‰⁄ Œ«’Ì… „⁄«Ì‰… «Ê ÿ»«⁄… «·”Ã·«  „‰ «·»—‰«„Ã", 16, " ‰»ÌÂ")
            Exit Sub
        End If
        Dim f As New FrmPRINT
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim txt As TextObject
        On Error Resume Next
        Dim Consum As New SqlClient.SqlConnection(constring)
        If Me.RadioButton1.Checked Then
            Dim rpt As New rptEmployees16
            If Len(Me.ComboEmployeeName.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·„ÊŸ›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboEmployeeName.Focus()
                Exit Sub
            End If
            If Len(Me.ComboMonths.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·‘Â—  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM SALARIES  WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and SLY3 like '" & Me.ComboMonths.Text & "' AND SLY2 like '" & ComboEmployeeName.Text & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder37 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "SALARIES")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text1")
            txt.Text = "Œ·«· ‘Â—  " & Me.ComboMonths.Text
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded

            txt = rpt.Section1.ReportObjects("Text39")
            txt.Text = ": „‰Ÿ„ «·ﬂ‘›" & " " & CUser

            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton2.Checked Then
            Dim rpt As New rptEmployees15
            If Len(Me.ComboMonths.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·‘Â—  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM SALARIES   WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and SLY3 like '" & Me.ComboMonths.Text & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "SALARIES")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text1")
            txt.Text = "Œ·«· ‘Â—  " & Me.ComboMonths.Text
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()
        ElseIf Me.RadioButton3.Checked Then
            Dim rpt As New rptEmployees15
            If Len(Me.ComboMonths.Text) = 0 Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·‘Â—  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Me.ComboMonths.Focus()
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM SALARIES   WHERE  CUser='" & CUser & "' and Year(SLY26) ='" & FiscalYear_currentDateMustBeInFiscalYear() & "'and  SLY28 ='" & False & "'", Consum)
            SqlDataAdapter1 = New SqlClient.SqlDataAdapter(str)
            Dim builder37 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "SALARIES")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text1")
            txt.Text = "Œ·«· ‘Â—  " & Me.ComboMonths.Text
            txt = rpt.Section1.ReportObjects("Text22")
            txt.Text = AssociationName
            txt = rpt.Section1.ReportObjects("Text21")
            txt.Text = Directorate
            txt = rpt.Section1.ReportObjects("Text23")
            txt.Text = Character
            txt = rpt.Section1.ReportObjects("TEXT40")
            txt.Text = "«·⁄‰Ê«‰" & " " & ":" & " " & Adrss & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone & " " & "|" & " " & "Â« ›" & " " & ":" & " " & Phone1
            txt = rpt.Section1.ReportObjects("Text44")
            txt.Text = Recorded
            f.CrystalReportViewer1.ReportSource = rpt
            f.CrystalReportViewer1.Zoom(65%)
            f.CrystalReportViewer1.RefreshReport()
            f.Show()


        End If
    End Sub

End Class
