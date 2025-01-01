Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmEmployees2
    Inherits Form
    Dim WithEvents BS As New BindingSource
    ReadOnly ds As New DataSet
    Dim SqlDataAdapter1 As New SqlDataAdapter

    Friend WithEvents SEARCHBUTTON As Button
    Friend WithEvents PRINTBUTTON As Button
    Friend WithEvents RadioButton3 As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label3 As Label
    ReadOnly rpt As New rptEmployees13
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
    Friend WithEvents Label4 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DateTO As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents DateFrom As DateTimePicker
    Friend WithEvents ComboEmployeeName As ComboBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents RadioButton2 As RadioButton
    Friend WithEvents RadioButton1 As RadioButton
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
    Friend WithEvents COL16 As DataGridTextBoxColumn
    Friend WithEvents COL17 As DataGridTextBoxColumn
    Friend WithEvents COL18 As DataGridTextBoxColumn
    Friend WithEvents COL19 As DataGridTextBoxColumn
    Friend WithEvents COL20 As DataGridTextBoxColumn
    <Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(FrmEmployees2))
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
        Me.COL16 = New DataGridTextBoxColumn()
        Me.COL17 = New DataGridTextBoxColumn()
        Me.COL18 = New DataGridTextBoxColumn()
        Me.COL19 = New DataGridTextBoxColumn()
        Me.COL20 = New DataGridTextBoxColumn()
        Me.Label4 = New Label()
        Me.Label1 = New Label()
        Me.DateTO = New DateTimePicker()
        Me.Label2 = New Label()
        Me.DateFrom = New DateTimePicker()
        Me.ComboEmployeeName = New ComboBox()
        Me.GroupBox1 = New GroupBox()
        Me.Panel3 = New Panel()
        Me.RadioButton3 = New RadioButton()
        Me.RadioButton1 = New RadioButton()
        Me.RadioButton2 = New RadioButton()
        Me.SEARCHBUTTON = New Button()
        Me.PRINTBUTTON = New Button()
        Me.Panel1 = New Panel()
        Me.Panel2 = New Panel()
        Me.Panel4 = New Panel()
        Me.Label3 = New Label()
        CType(Me.DATAGRID, ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'DATAGRID
        '
        Me.DATAGRID.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.DATAGRID.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DATAGRID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DATAGRID.CaptionBackColor = System.Drawing.SystemColors.Control
        Me.DATAGRID.CaptionVisible = False
        Me.DATAGRID.DataMember = ""
        Me.DATAGRID.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DATAGRID.Location = New Point(2, 157)
        Me.DATAGRID.Name = "DATAGRID"
        Me.DATAGRID.ReadOnly = True
        Me.DATAGRID.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DATAGRID.Size = New Size(531, 203)
        Me.DATAGRID.TabIndex = 78
        Me.DATAGRID.TableStyles.AddRange(New DataGridTableStyle() {Me.STYLE})
        '
        'STYLE
        '
        Me.STYLE.AlternatingBackColor = System.Drawing.Color.Pink
        Me.STYLE.BackColor = System.Drawing.Color.Pink
        Me.STYLE.DataGrid = Me.DATAGRID
        Me.STYLE.ForeColor = System.Drawing.Color.Black
        Me.STYLE.GridColumnStyles.AddRange(New DataGridColumnStyle() {Me.COL1, Me.COL2, Me.COL3, Me.COL4, Me.COL5, Me.COL6, Me.COL7, Me.COL8, Me.COL9, Me.COL10, Me.COL11, Me.COL12, Me.COL13, Me.COL14, Me.COL15, Me.COL16, Me.COL17, Me.COL18, Me.COL19, Me.COL20})
        Me.STYLE.GridLineColor = System.Drawing.Color.Blue
        Me.STYLE.HeaderForeColor = System.Drawing.Color.Black
        Me.STYLE.LinkColor = System.Drawing.SystemColors.Control
        Me.STYLE.MappingName = "EMPLOYEES"
        Me.STYLE.SelectionBackColor = System.Drawing.SystemColors.Control
        Me.STYLE.SelectionForeColor = System.Drawing.Color.Black
        '
        'COL1
        '
        Me.COL1.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL1.Format = ""
        Me.COL1.FormatInfo = Nothing
        Me.COL1.HeaderText = "„”·”·"
        Me.COL1.MappingName = "EMP1"
        Me.COL1.NullText = ""
        Me.COL1.Width = 75
        '
        'COL2
        '
        Me.COL2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL2.Format = ""
        Me.COL2.FormatInfo = Nothing
        Me.COL2.HeaderText = "«·„ÊŸ›"
        Me.COL2.MappingName = "EMP2"
        Me.COL2.NullText = ""
        Me.COL2.Width = 200
        '
        'COL3
        '
        Me.COL3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL3.Format = ""
        Me.COL3.FormatInfo = Nothing
        Me.COL3.HeaderText = "«·⁄‰Ê«‰"
        Me.COL3.MappingName = "EMP3"
        Me.COL3.NullText = ""
        Me.COL3.Width = 200
        '
        'COL4
        '
        Me.COL4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL4.Format = ""
        Me.COL4.FormatInfo = Nothing
        Me.COL4.HeaderText = "«· ·Ì›Ê‰"
        Me.COL4.MappingName = "EMP4"
        Me.COL4.NullText = ""
        Me.COL4.Width = 150
        '
        'COL5
        '
        Me.COL5.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL5.Format = ""
        Me.COL5.FormatInfo = Nothing
        Me.COL5.HeaderText = "«·Õ«·… «·«Ã „«⁄Ì…"
        Me.COL5.MappingName = "EMP5"
        Me.COL5.NullText = ""
        Me.COL5.Width = 200
        '
        'COL6
        '
        Me.COL6.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL6.Format = ""
        Me.COL6.FormatInfo = Nothing
        Me.COL6.HeaderText = "«·„ƒÂ·"
        Me.COL6.MappingName = "EMP6"
        Me.COL6.NullText = ""
        Me.COL6.Width = 200
        '
        'COL7
        '
        Me.COL7.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL7.Format = ""
        Me.COL7.FormatInfo = Nothing
        Me.COL7.HeaderText = "«·ÊŸÌ›…"
        Me.COL7.MappingName = "EMP7"
        Me.COL7.NullText = ""
        Me.COL7.Width = 200
        '
        'COL8
        '
        Me.COL8.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL8.Format = ""
        Me.COL8.FormatInfo = Nothing
        Me.COL8.HeaderText = "«·«œ«—…"
        Me.COL8.MappingName = "EMP8"
        Me.COL8.NullText = ""
        Me.COL8.Width = 200
        '
        'COL9
        '
        Me.COL9.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL9.Format = ""
        Me.COL9.FormatInfo = Nothing
        Me.COL9.HeaderText = "«·—ﬁ„ «·Êÿ‰Ì"
        Me.COL9.MappingName = "EMP12"
        Me.COL9.NullText = ""
        Me.COL9.Width = 200
        '
        'COL10
        '
        Me.COL10.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL10.Format = ""
        Me.COL10.FormatInfo = Nothing
        Me.COL10.HeaderText = "«·—ﬁ„ «· √„Ì‰Ï"
        Me.COL10.MappingName = "EMP13"
        Me.COL10.NullText = ""
        Me.COL10.Width = 200
        '
        'COL11
        '
        Me.COL11.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL11.Format = ""
        Me.COL11.FormatInfo = Nothing
        Me.COL11.HeaderText = " «—ÌŒ «·„Ì·«œ"
        Me.COL11.MappingName = "EMP9"
        Me.COL11.NullText = ""
        Me.COL11.Width = 200
        '
        'COL12
        '
        Me.COL12.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL12.Format = ""
        Me.COL12.FormatInfo = Nothing
        Me.COL12.HeaderText = " «—ÌŒ «· ⁄ÌÌ‰"
        Me.COL12.MappingName = "EMP10"
        Me.COL12.NullText = ""
        Me.COL12.Width = 200
        '
        'COL13
        '
        Me.COL13.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL13.Format = ""
        Me.COL13.FormatInfo = Nothing
        Me.COL13.HeaderText = " «—ÌŒ ‰Â«Ì… «·Œœ„…"
        Me.COL13.MappingName = "EMP11"
        Me.COL13.NullText = ""
        Me.COL13.Width = 200
        '
        'COL14
        '
        Me.COL14.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL14.Format = ""
        Me.COL14.FormatInfo = Nothing
        Me.COL14.HeaderText = "«·Œœ„… «·⁄”ﬂ—Ì…"
        Me.COL14.MappingName = "EMP14"
        Me.COL14.NullText = ""
        Me.COL14.Width = 200
        '
        'COL15
        '
        Me.COL15.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL15.Format = ""
        Me.COL15.FormatInfo = Nothing
        Me.COL15.HeaderText = "—’Ìœ «Ã«“«  ”«»ﬁ"
        Me.COL15.MappingName = "EMP15"
        Me.COL15.NullText = ""
        Me.COL15.Width = 150
        '
        'COL16
        '
        Me.COL16.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL16.Format = ""
        Me.COL16.FormatInfo = Nothing
        Me.COL16.HeaderText = "—’Ìœ «Ã«“«  ”‰ÊÏ"
        Me.COL16.MappingName = "EMP16"
        Me.COL16.NullText = ""
        Me.COL16.Width = 150
        '
        'COL17
        '
        Me.COL17.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL17.Format = ""
        Me.COL17.FormatInfo = Nothing
        Me.COL17.HeaderText = "«Ã„«·Ï «·«Ã«“« "
        Me.COL17.MappingName = "EMP17"
        Me.COL17.NullText = ""
        Me.COL17.Width = 150
        '
        'COL18
        '
        Me.COL18.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL18.Format = ""
        Me.COL18.FormatInfo = Nothing
        Me.COL18.HeaderText = "«Ì«„ «·€Ì«»"
        Me.COL18.MappingName = "EMP18"
        Me.COL18.NullText = ""
        Me.COL18.Width = 150
        '
        'COL19
        '
        Me.COL19.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL19.Format = ""
        Me.COL19.FormatInfo = Nothing
        Me.COL19.HeaderText = "«Ì«„ «·Ã“«¡« "
        Me.COL19.MappingName = "EMP19"
        Me.COL19.NullText = ""
        Me.COL19.Width = 150
        '
        'COL20
        '
        Me.COL20.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.COL20.Format = ""
        Me.COL20.FormatInfo = Nothing
        Me.COL20.HeaderText = "«Ã«“… »œÊ‰ „— »"
        Me.COL20.MappingName = "EMP20"
        Me.COL20.NullText = ""
        Me.COL20.Width = 150
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New Point(336, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New Size(41, 15)
        Me.Label4.TabIndex = 82
        Me.Label4.Text = "«·„ÊŸ›"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New Point(358, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(19, 15)
        Me.Label1.TabIndex = 76
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
        Me.DateTO.Location = New Point(3, 52)
        Me.DateTO.Name = "DateTO"
        Me.DateTO.RightToLeftLayout = True
        Me.DateTO.ShowCheckBox = True
        Me.DateTO.Size = New Size(330, 22)
        Me.DateTO.TabIndex = 75
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New Point(357, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(20, 15)
        Me.Label2.TabIndex = 77
        Me.Label2.Text = "«·Ï"
        '
        'DateFrom
        '
        Me.DateFrom.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.DateFrom.Checked = False
        Me.DateFrom.CustomFormat = "yyyy/MM/dd"
        Me.DateFrom.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.DateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateFrom.Location = New Point(3, 29)
        Me.DateFrom.Name = "DateFrom"
        Me.DateFrom.RightToLeftLayout = True
        Me.DateFrom.ShowCheckBox = True
        Me.DateFrom.Size = New Size(330, 22)
        Me.DateFrom.TabIndex = 74
        '
        'ComboEmployeeName
        '
        Me.ComboEmployeeName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.ComboEmployeeName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.ComboEmployeeName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboEmployeeName.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboEmployeeName.Location = New Point(3, 5)
        Me.ComboEmployeeName.Name = "ComboEmployeeName"
        Me.ComboEmployeeName.Size = New Size(330, 23)
        Me.ComboEmployeeName.TabIndex = 73
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.Black
        Me.GroupBox1.Location = New Point(389, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(138, 114)
        Me.GroupBox1.TabIndex = 72
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
        Me.Panel3.Location = New Point(3, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New Size(132, 93)
        Me.Panel3.TabIndex = 449
        '
        'RadioButton3
        '
        Me.RadioButton3.AutoSize = True
        Me.RadioButton3.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton3.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New Point(6, 61)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New Size(119, 19)
        Me.RadioButton3.TabIndex = 733
        Me.RadioButton3.Text = "«·”Ã·«  «·€Ì— „—«Ã⁄…"
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'RadioButton1
        '
        Me.RadioButton1.AutoSize = True
        Me.RadioButton1.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New Point(8, 6)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New Size(117, 19)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "«”„ «·„ÊŸ› Ê«· «—ÌŒ"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.AutoSize = True
        Me.RadioButton2.BackColor = System.Drawing.Color.Transparent
        Me.RadioButton2.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New Point(14, 33)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New Size(111, 19)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "⁄—÷ «·ﬂ· Ê«· «—ÌŒ"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'SEARCHBUTTON
        '
        Me.SEARCHBUTTON.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.SEARCHBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SEARCHBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.SEARCHBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SEARCHBUTTON.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SEARCHBUTTON.ForeColor = System.Drawing.Color.Black
        Me.SEARCHBUTTON.Image = Global.CC_JO.My.Resources.Resources.FindByID_16x16
        Me.SEARCHBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SEARCHBUTTON.Location = New Point(174, 76)
        Me.SEARCHBUTTON.Name = "SEARCHBUTTON"
        Me.SEARCHBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.SEARCHBUTTON.Size = New Size(159, 30)
        Me.SEARCHBUTTON.TabIndex = 446
        Me.SEARCHBUTTON.Text = "»ÕÀ"
        Me.SEARCHBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SEARCHBUTTON.UseVisualStyleBackColor = False
        '
        'PRINTBUTTON
        '
        Me.PRINTBUTTON.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.PRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PRINTBUTTON.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PRINTBUTTON.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PRINTBUTTON.ForeColor = System.Drawing.Color.Black
        Me.PRINTBUTTON.Image = Global.CC_JO.My.Resources.Resources.Print_Quick
        Me.PRINTBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRINTBUTTON.Location = New Point(3, 76)
        Me.PRINTBUTTON.Name = "PRINTBUTTON"
        Me.PRINTBUTTON.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.PRINTBUTTON.Size = New Size(169, 30)
        Me.PRINTBUTTON.TabIndex = 447
        Me.PRINTBUTTON.Text = "ÿ»«⁄…"
        Me.PRINTBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PRINTBUTTON.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New Point(3, 36)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(530, 120)
        Me.Panel1.TabIndex = 448
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.ComboEmployeeName)
        Me.Panel2.Controls.Add(Me.PRINTBUTTON)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.SEARCHBUTTON)
        Me.Panel2.Controls.Add(Me.DateTO)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DateFrom)
        Me.Panel2.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel2.Location = New Point(2, 2)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New Size(380, 112)
        Me.Panel2.TabIndex = 449
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Panel4.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Location = New Point(3, 2)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New Size(530, 32)
        Me.Panel4.TabIndex = 741
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Image = Global.CC_JO.My.Resources.Resources.printpreview_32x32
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label3.Location = New Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(528, 29)
        Me.Label3.TabIndex = 90
        Me.Label3.Text = "«·„ÊŸ›Ì‰ »ÕÀ Ê ÿ»«⁄…"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FrmEmployees2
        '
        Me.AutoScaleBaseSize = New Size(6, 15)
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New Size(535, 363)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.DATAGRID)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.MinimumSize = New Size(551, 402)
        Me.Name = "FrmEmployees2"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "«·„ÊŸ›Ì‰ -- »ÕÀ Ê ÿ»«⁄…"
        CType(Me.DATAGRID, ComponentModel.ISupportInitialize).EndInit()
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
    Private Sub FrmEmployees2_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyUp
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
    Private Sub FrmEmployees2_Load(ByVal sender As System.Object, ByVal e As EventArgs) Handles MyBase.Load
        On Error Resume Next
        Me.BackgroundImage = img
        For a As Byte = 0 To 10
            System.Threading.Thread.Sleep(10)
            Application.DoEvents()
            Me.Opacity = a / 10
        Next
        Dim Consum As New SqlConnection(constring)
        Dim strSQL As New SqlCommand("", Consum)
        With strSQL
            .CommandText = "SELECT EMP1, EMP2 FROM EMPLOYEES  WHERE  CUser='" & CUser & "'  ORDER BY EMP1"
            If Consum.State = ConnectionState.Open Then Consum.Close()
            Consum.Open()
            SqlDataAdapter1 = New SqlDataAdapter(strSQL)
            Dim builder3 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPLOYEES")
            BS.DataSource = ds
            BS.DataMember = "EMPLOYEES"
        End With
        Consum.Close()
        FILLCOMBOBOX1("EMPLOYEES", "EMP2", "CUser", CUser, Me.ComboEmployeeName)
        Call MangUsers()
    End Sub
    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton1.Click
        On Error Resume Next
        Me.ComboEmployeeName.Enabled = True
    End Sub
    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles RadioButton2.Click
        On Error Resume Next
        Me.ComboEmployeeName.Enabled = False
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
        txtFromDate = Format(Me.DateFrom.Value, "yyyy/MM/dd")
        txtToDate = Format(Me.DateTO.Value, "yyyy/MM/dd")
        Try
            If Me.RadioButton1.Checked Then
                If Len(Me.ComboEmployeeName.Text) = 0 Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «”„ «·„ÊŸ›  «·–Ï  »ÕÀ ⁄‰Â", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Me.ComboEmployeeName.Focus()
                    Exit Sub
                End If
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim ds As New DataSet
                Dim bs As New BindingSource
                Dim strsql1 As New SqlCommand("SELECT EMP1, EMP2, EMP3, EMP4, EMP5, EMP6, EMP7, EMP8, EMP9, EMP10, EMP11, EMP12, EMP13, EMP14, EMP15, EMP16, EMP17, EMP18, EMP19, EMP20 FROM EMPLOYEES  WHERE EMP10 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "' AND EMP2='" & Me.ComboEmployeeName.Text & "'", Consum)
                Dim Adp1 As New SqlDataAdapter(strsql1)
                Dim builder22 As New SqlCommandBuilder(Adp1)
                ds.Clear()
                DATAGRID.DataBindings.Clear()
                Adp1.Fill(ds, "EMPLOYEES")
                bs.DataSource = ds
                bs.DataMember = ds.Tables.Item(0).TableName
                Me.DATAGRID.DataSource = bs
                Me.DATAGRID.Refresh()
                Adp1.Dispose()
            ElseIf Me.RadioButton2.Checked Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim bs As New BindingSource
                Dim ds As New DataSet
                Dim strsql2 As New SqlCommand("SELECT * FROM EMPLOYEES  WHERE  CUser='" & CUser & "' and EMP10 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
                Dim Adp2 As New SqlDataAdapter(strsql2)
                Dim builder22 As New SqlCommandBuilder(Adp2)
                ds.Clear()
                DATAGRID.DataBindings.Clear()
                Adp2.Fill(ds, "EMPLOYEES")
                bs.DataSource = ds
                bs.DataMember = ds.Tables.Item(0).TableName
                Me.DATAGRID.DataSource = bs
                Me.DATAGRID.Refresh()
                Adp2.Dispose()
            ElseIf Me.RadioButton3.Checked Then
                If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                    MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                    Exit Sub
                End If
                Dim bs As New BindingSource
                Dim ds As New DataSet
                Dim strsql2 As New SqlCommand("SELECT * FROM EMPLOYEES  WHERE  CUser='" & CUser & "' and EMP10 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EMP22 ='" & False & "'", Consum)
                Dim Adp2 As New SqlDataAdapter(strsql2)
                Dim builder22 As New SqlCommandBuilder(Adp2)
                ds.Clear()
                DATAGRID.DataBindings.Clear()
                Adp2.Fill(ds, "EMPLOYEES")
                bs.DataSource = ds
                bs.DataMember = ds.Tables.Item(0).TableName
                Me.DATAGRID.DataSource = bs
                Me.DATAGRID.Refresh()
                Adp2.Dispose()
            End If
            Consum.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
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
        Dim Consum As New SqlConnection(constring)
        Dim f As New FrmPRINT
        Dim txtFROMDate As String
        Dim txtToDate As String
        Dim txt As TextObject
        txtFROMDate = Format(Me.DateFrom.Value, "yyy, MM, dd, 00, 00, 000")
        txtToDate = Format(Me.DateTO.Value, "yyy, MM, dd, 00, 00, 00")
        On Error Resume Next
        If Me.RadioButton1.Checked Then
            Dim rpt As New rptEmployees13
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM EMPLOYEES  WHERE EMP10 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EMP2 like '" & Me.ComboEmployeeName.Text & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder22 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPLOYEES")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text7")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
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
        ElseIf Me.RadioButton2.Checked Then
            Dim rpt As New rptEmployees13
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM EMPLOYEES  WHERE EMP10 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder22 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPLOYEES")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text7")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
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
            Dim rpt As New rptEmployees13
            If Me.DateFrom.Checked = False And Me.DateTO.Checked = False Then
                MessageBox.Show("„‰ ›÷·ﬂ «œŒ· «· «—ÌŒ  ›Ï Œ«‰… „‰ - «·Ï", "»ÕÀ Êÿ»«⁄Â", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading)
                Exit Sub
            End If
            GETSERVERNAMEANDDATABASENAME(rpt, DBServer, "", "")
            Dim ds As New DataSet
            Dim str As New SqlCommand("SELECT * FROM EMPLOYEES  WHERE EMP10 BETWEEN '" & Format(Me.DateFrom.Value, "yyyy/MM/dd") & "'  AND  '" & Format(Me.DateTO.Value, "yyyy/MM/dd") & "'  AND EMP22 ='" & False & "'", Consum)
            SqlDataAdapter1 = New SqlDataAdapter(str)
            Dim builder22 As New SqlCommandBuilder(SqlDataAdapter1)
            ds.Clear()
            SqlDataAdapter1.Fill(ds, "EMPLOYEES")
            rpt.SetDataSource(ds)
            txt = rpt.Section1.ReportObjects("Text7")
            txt.Text = "Œ·«· «·› —… „‰" & Format(Me.DateFrom.Value, "dd - MM - yyyy") & " «·Ï " & Format(Me.DateTO.Value, "dd - MM - yyyy")
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
        Consum.Close()
    End Sub

End Class
