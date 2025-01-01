<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmJO1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmJO1))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.TEXTStatement = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.TEXTCredit = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTDebit = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTCurrentBalance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TEXTPreviousBalance = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TextMovementSymbol = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTID = New DevExpress.XtraEditors.TextEdit()
        Me.DateMovementHistory = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TEXTBN2 = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextBN3 = New System.Windows.Forms.TextBox()
        Me.TextDateMovementHistory = New System.Windows.Forms.TextBox()
        Me.TEXTDocumentNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboConstraintType = New System.Windows.Forms.ComboBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.TEXTTEXTTotalN = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.TEXTTotal = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel17.SuspendLayout()
        CType(Me.TEXTCredit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEXTDebit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.Panel16.SuspendLayout()
        CType(Me.TextMovementSymbol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEXTID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox7)
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(602, 196)
        Me.Panel1.TabIndex = 952
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Panel18)
        Me.GroupBox7.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox7.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox7.Location = New System.Drawing.Point(2, 107)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox7.Size = New System.Drawing.Size(284, 80)
        Me.GroupBox7.TabIndex = 968
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "البيــان"
        '
        'Panel18
        '
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.TEXTStatement)
        Me.Panel18.Controls.Add(Me.Label7)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.Location = New System.Drawing.Point(3, 17)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(278, 60)
        Me.Panel18.TabIndex = 0
        '
        'TEXTStatement
        '
        Me.TEXTStatement.BackColor = System.Drawing.SystemColors.Window
        Me.TEXTStatement.Cursor = System.Windows.Forms.Cursors.Default
        Me.TEXTStatement.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXTStatement.ForeColor = System.Drawing.Color.Black
        Me.TEXTStatement.Location = New System.Drawing.Point(2, 18)
        Me.TEXTStatement.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TEXTStatement.Name = "TEXTStatement"
        Me.TEXTStatement.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TEXTStatement.Size = New System.Drawing.Size(240, 23)
        Me.TEXTStatement.TabIndex = 452
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(246, 21)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 15)
        Me.Label7.TabIndex = 440
        Me.Label7.Text = "البيان"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel17)
        Me.GroupBox4.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox4.Location = New System.Drawing.Point(1, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(284, 100)
        Me.GroupBox4.TabIndex = 969
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "الأرصدة"
        '
        'Panel17
        '
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.TEXTCredit)
        Me.Panel17.Controls.Add(Me.TEXTDebit)
        Me.Panel17.Controls.Add(Me.TEXTCurrentBalance)
        Me.Panel17.Controls.Add(Me.Label2)
        Me.Panel17.Controls.Add(Me.Label9)
        Me.Panel17.Controls.Add(Me.Label4)
        Me.Panel17.Controls.Add(Me.TEXTPreviousBalance)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel17.Location = New System.Drawing.Point(3, 17)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(278, 80)
        Me.Panel17.TabIndex = 0
        '
        'TEXTCredit
        '
        Me.TEXTCredit.EditValue = "0"
        Me.TEXTCredit.Location = New System.Drawing.Point(2, 28)
        Me.TEXTCredit.Name = "TEXTCredit"
        Me.TEXTCredit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTCredit.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.TEXTCredit.Properties.Appearance.Options.UseFont = True
        Me.TEXTCredit.Properties.Appearance.Options.UseTextOptions = True
        Me.TEXTCredit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEXTCredit.Properties.BeepOnError = False
        Me.TEXTCredit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TEXTCredit.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TEXTCredit.Properties.MaskSettings.Set("mask", "f3")
        Me.TEXTCredit.Properties.UseMaskAsDisplayFormat = True
        Me.TEXTCredit.Size = New System.Drawing.Size(102, 22)
        Me.TEXTCredit.TabIndex = 960
        '
        'TEXTDebit
        '
        Me.TEXTDebit.EditValue = "0"
        Me.TEXTDebit.Location = New System.Drawing.Point(105, 28)
        Me.TEXTDebit.Name = "TEXTDebit"
        Me.TEXTDebit.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTDebit.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.TEXTDebit.Properties.Appearance.Options.UseFont = True
        Me.TEXTDebit.Properties.Appearance.Options.UseTextOptions = True
        Me.TEXTDebit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEXTDebit.Properties.BeepOnError = False
        Me.TEXTDebit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TEXTDebit.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TEXTDebit.Properties.MaskSettings.Set("mask", "f3")
        Me.TEXTDebit.Properties.UseMaskAsDisplayFormat = True
        Me.TEXTDebit.Size = New System.Drawing.Size(102, 22)
        Me.TEXTDebit.TabIndex = 961
        '
        'TEXTCurrentBalance
        '
        Me.TEXTCurrentBalance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEXTCurrentBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTCurrentBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TEXTCurrentBalance.Enabled = False
        Me.TEXTCurrentBalance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXTCurrentBalance.ForeColor = System.Drawing.Color.Black
        Me.TEXTCurrentBalance.Location = New System.Drawing.Point(2, 52)
        Me.TEXTCurrentBalance.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TEXTCurrentBalance.Name = "TEXTCurrentBalance"
        Me.TEXTCurrentBalance.ReadOnly = True
        Me.TEXTCurrentBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTCurrentBalance.Size = New System.Drawing.Size(205, 22)
        Me.TEXTCurrentBalance.TabIndex = 421
        Me.TEXTCurrentBalance.TabStop = False
        Me.TEXTCurrentBalance.Text = "0.000"
        Me.TEXTCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(217, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 15)
        Me.Label2.TabIndex = 432
        Me.Label2.Text = "رصيد سابق"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(220, 54)
        Me.Label9.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(54, 15)
        Me.Label9.TabIndex = 437
        Me.Label9.Text = "رصيد حالى"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(219, 30)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 15)
        Me.Label4.TabIndex = 434
        Me.Label4.Text = "مدين / دائن"
        '
        'TEXTPreviousBalance
        '
        Me.TEXTPreviousBalance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEXTPreviousBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTPreviousBalance.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TEXTPreviousBalance.Enabled = False
        Me.TEXTPreviousBalance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXTPreviousBalance.ForeColor = System.Drawing.Color.Black
        Me.TEXTPreviousBalance.Location = New System.Drawing.Point(2, 4)
        Me.TEXTPreviousBalance.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TEXTPreviousBalance.Name = "TEXTPreviousBalance"
        Me.TEXTPreviousBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTPreviousBalance.Size = New System.Drawing.Size(205, 22)
        Me.TEXTPreviousBalance.TabIndex = 416
        Me.TEXTPreviousBalance.TabStop = False
        Me.TEXTPreviousBalance.Text = "0.000"
        Me.TEXTPreviousBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel16)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox3.Location = New System.Drawing.Point(289, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(309, 184)
        Me.GroupBox3.TabIndex = 965
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "بيانات الحركة"
        '
        'Panel16
        '
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.TextMovementSymbol)
        Me.Panel16.Controls.Add(Me.TEXTID)
        Me.Panel16.Controls.Add(Me.DateMovementHistory)
        Me.Panel16.Controls.Add(Me.Label11)
        Me.Panel16.Controls.Add(Me.TEXTBN2)
        Me.Panel16.Controls.Add(Me.Label5)
        Me.Panel16.Controls.Add(Me.Label8)
        Me.Panel16.Controls.Add(Me.TextBN3)
        Me.Panel16.Controls.Add(Me.TextDateMovementHistory)
        Me.Panel16.Controls.Add(Me.TEXTDocumentNumber)
        Me.Panel16.Controls.Add(Me.Label3)
        Me.Panel16.Controls.Add(Me.Label1)
        Me.Panel16.Controls.Add(Me.Label10)
        Me.Panel16.Controls.Add(Me.ComboConstraintType)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(3, 18)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(303, 163)
        Me.Panel16.TabIndex = 0
        '
        'TextMovementSymbol
        '
        Me.TextMovementSymbol.EditValue = "0"
        Me.TextMovementSymbol.Enabled = False
        Me.TextMovementSymbol.Location = New System.Drawing.Point(2, 5)
        Me.TextMovementSymbol.Name = "TextMovementSymbol"
        Me.TextMovementSymbol.Properties.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.TextMovementSymbol.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextMovementSymbol.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.TextMovementSymbol.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.TextMovementSymbol.Properties.Appearance.Options.UseBackColor = True
        Me.TextMovementSymbol.Properties.Appearance.Options.UseFont = True
        Me.TextMovementSymbol.Properties.Appearance.Options.UseForeColor = True
        Me.TextMovementSymbol.Properties.Appearance.Options.UseTextOptions = True
        Me.TextMovementSymbol.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextMovementSymbol.Properties.BeepOnError = False
        Me.TextMovementSymbol.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TextMovementSymbol.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.SimpleMaskManager))
        Me.TextMovementSymbol.Properties.MaskSettings.Set("mask", "AA-00-00000-00000")
        Me.TextMovementSymbol.Properties.MaskSettings.Set("placeholder", Global.Microsoft.VisualBasic.ChrW(0))
        Me.TextMovementSymbol.Properties.UseMaskAsDisplayFormat = True
        Me.TextMovementSymbol.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextMovementSymbol.Size = New System.Drawing.Size(123, 22)
        Me.TextMovementSymbol.TabIndex = 999
        '
        'TEXTID
        '
        Me.TEXTID.EditValue = "0"
        Me.TEXTID.Enabled = False
        Me.TEXTID.Location = New System.Drawing.Point(126, 5)
        Me.TEXTID.Name = "TEXTID"
        Me.TEXTID.Properties.Appearance.BackColor = System.Drawing.Color.SteelBlue
        Me.TEXTID.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTID.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.TEXTID.Properties.Appearance.ForeColor = System.Drawing.Color.White
        Me.TEXTID.Properties.Appearance.Options.UseBackColor = True
        Me.TEXTID.Properties.Appearance.Options.UseFont = True
        Me.TEXTID.Properties.Appearance.Options.UseForeColor = True
        Me.TEXTID.Properties.Appearance.Options.UseTextOptions = True
        Me.TEXTID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TEXTID.Properties.BeepOnError = False
        Me.TEXTID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TEXTID.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.SimpleMaskManager))
        Me.TEXTID.Properties.MaskSettings.Set("mask", "00-00000-00000")
        Me.TEXTID.Properties.MaskSettings.Set("placeholder", Global.Microsoft.VisualBasic.ChrW(0))
        Me.TEXTID.Properties.NullText = "0"
        Me.TEXTID.Properties.UseMaskAsDisplayFormat = True
        Me.TEXTID.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTID.Size = New System.Drawing.Size(104, 22)
        Me.TEXTID.TabIndex = 998
        '
        'DateMovementHistory
        '
        Me.DateMovementHistory.CalendarFont = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateMovementHistory.CalendarForeColor = System.Drawing.Color.Black
        Me.DateMovementHistory.CalendarMonthBackground = System.Drawing.Color.GhostWhite
        Me.DateMovementHistory.CalendarTitleBackColor = System.Drawing.Color.LavenderBlush
        Me.DateMovementHistory.CalendarTitleForeColor = System.Drawing.Color.Black
        Me.DateMovementHistory.CalendarTrailingForeColor = System.Drawing.Color.Black
        Me.DateMovementHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DateMovementHistory.CustomFormat = "yyyy-MM-dd"
        Me.DateMovementHistory.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right
        Me.DateMovementHistory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateMovementHistory.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateMovementHistory.Location = New System.Drawing.Point(2, 76)
        Me.DateMovementHistory.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DateMovementHistory.Name = "DateMovementHistory"
        Me.DateMovementHistory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateMovementHistory.RightToLeftLayout = True
        Me.DateMovementHistory.Size = New System.Drawing.Size(228, 22)
        Me.DateMovementHistory.TabIndex = 417
        Me.DateMovementHistory.Value = New Date(2018, 5, 8, 18, 59, 56, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Location = New System.Drawing.Point(241, 129)
        Me.Label11.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 15)
        Me.Label11.TabIndex = 439
        Me.Label11.Text = "رقم المستند"
        '
        'TEXTBN2
        '
        Me.TEXTBN2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TEXTBN2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TEXTBN2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TEXTBN2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTBN2.ForeColor = System.Drawing.Color.Black
        Me.TEXTBN2.Location = New System.Drawing.Point(2, 29)
        Me.TEXTBN2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TEXTBN2.Name = "TEXTBN2"
        Me.TEXTBN2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TEXTBN2.Size = New System.Drawing.Size(228, 23)
        Me.TEXTBN2.TabIndex = 420
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(250, 55)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 15)
        Me.Label5.TabIndex = 815
        Me.Label5.Text = "اسم البنك"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(240, 32)
        Me.Label8.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 15)
        Me.Label8.TabIndex = 436
        Me.Label8.Text = "رقم الحساب"
        '
        'TextBN3
        '
        Me.TextBN3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextBN3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBN3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TextBN3.Enabled = False
        Me.TextBN3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBN3.ForeColor = System.Drawing.Color.Black
        Me.TextBN3.Location = New System.Drawing.Point(2, 53)
        Me.TextBN3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TextBN3.Name = "TextBN3"
        Me.TextBN3.Size = New System.Drawing.Size(228, 22)
        Me.TextBN3.TabIndex = 814
        Me.TextBN3.TabStop = False
        Me.TextBN3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextDateMovementHistory
        '
        Me.TextDateMovementHistory.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TextDateMovementHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDateMovementHistory.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TextDateMovementHistory.Enabled = False
        Me.TextDateMovementHistory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDateMovementHistory.ForeColor = System.Drawing.Color.Black
        Me.TextDateMovementHistory.Location = New System.Drawing.Point(2, 77)
        Me.TextDateMovementHistory.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TextDateMovementHistory.Name = "TextDateMovementHistory"
        Me.TextDateMovementHistory.Size = New System.Drawing.Size(228, 22)
        Me.TextDateMovementHistory.TabIndex = 961
        Me.TextDateMovementHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TEXTDocumentNumber
        '
        Me.TEXTDocumentNumber.BackColor = System.Drawing.Color.White
        Me.TEXTDocumentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTDocumentNumber.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TEXTDocumentNumber.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TEXTDocumentNumber.ForeColor = System.Drawing.Color.Black
        Me.TEXTDocumentNumber.Location = New System.Drawing.Point(2, 124)
        Me.TEXTDocumentNumber.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TEXTDocumentNumber.Name = "TEXTDocumentNumber"
        Me.TEXTDocumentNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTDocumentNumber.Size = New System.Drawing.Size(228, 22)
        Me.TEXTDocumentNumber.TabIndex = 423
        Me.TEXTDocumentNumber.Text = "0"
        Me.TEXTDocumentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label3.Location = New System.Drawing.Point(234, 79)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 15)
        Me.Label3.TabIndex = 433
        Me.Label3.Text = "تاريخ الحركة"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(269, 6)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 431
        Me.Label1.Text = "الرقم"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label10.Location = New System.Drawing.Point(241, 106)
        Me.Label10.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 15)
        Me.Label10.TabIndex = 513
        Me.Label10.Text = "نوع الحركة"
        '
        'ComboConstraintType
        '
        Me.ComboConstraintType.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboConstraintType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboConstraintType.ForeColor = System.Drawing.Color.Black
        Me.ComboConstraintType.Items.AddRange(New Object() {"ايداع", "سحب"})
        Me.ComboConstraintType.Location = New System.Drawing.Point(2, 100)
        Me.ComboConstraintType.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ComboConstraintType.Name = "ComboConstraintType"
        Me.ComboConstraintType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboConstraintType.Size = New System.Drawing.Size(228, 23)
        Me.ComboConstraintType.TabIndex = 422
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(2, -5)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 725
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox5.Location = New System.Drawing.Point(2, -5)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 724
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'TEXTTEXTTotalN
        '
        Me.TEXTTEXTTotalN.BackColor = System.Drawing.Color.White
        Me.TEXTTEXTTotalN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTTEXTTotalN.Enabled = False
        Me.TEXTTEXTTotalN.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTTEXTTotalN.ForeColor = System.Drawing.Color.Black
        Me.TEXTTEXTTotalN.Location = New System.Drawing.Point(2, 0)
        Me.TEXTTEXTTotalN.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TEXTTEXTTotalN.Name = "TEXTTEXTTotalN"
        Me.TEXTTEXTTotalN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TEXTTEXTTotalN.Size = New System.Drawing.Size(384, 22)
        Me.TEXTTEXTTotalN.TabIndex = 957
        Me.TEXTTEXTTotalN.Text = "."
        Me.TEXTTEXTTotalN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(526, 4)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 958
        Me.Label6.Text = "الاجمـالـى"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.Location = New System.Drawing.Point(301, 2)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(297, 30)
        Me.ADDBUTTON.TabIndex = 961
        Me.ADDBUTTON.Text = "اضافة F1"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.UseVisualStyleBackColor = True
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.Location = New System.Drawing.Point(2, 2)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.Size = New System.Drawing.Size(297, 30)
        Me.SAVEBUTTON.TabIndex = 962
        Me.SAVEBUTTON.Text = "حفظ F2"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TEXTTotal)
        Me.Panel3.Controls.Add(Me.TEXTTEXTTotalN)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(3, 201)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(602, 27)
        Me.Panel3.TabIndex = 963
        '
        'TEXTTotal
        '
        Me.TEXTTotal.BackColor = System.Drawing.Color.SteelBlue
        Me.TEXTTotal.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTTotal.ForeColor = System.Drawing.Color.Yellow
        Me.TEXTTotal.Location = New System.Drawing.Point(387, 0)
        Me.TEXTTotal.Name = "TEXTTotal"
        Me.TEXTTotal.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTTotal.Size = New System.Drawing.Size(134, 22)
        Me.TEXTTotal.TabIndex = 985
        Me.TEXTTotal.Text = "0.000"
        Me.TEXTTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.PictureBox5)
        Me.Panel4.Controls.Add(Me.SAVEBUTTON)
        Me.Panel4.Controls.Add(Me.ADDBUTTON)
        Me.Panel4.Location = New System.Drawing.Point(3, 229)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(602, 36)
        Me.Panel4.TabIndex = 964
        '
        'FrmJO1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(607, 270)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel4)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmJO1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة حركات البنك"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        CType(Me.TEXTCredit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEXTDebit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        CType(Me.TextMovementSymbol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEXTID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TEXTStatement As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TEXTCurrentBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TEXTBN2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TEXTPreviousBalance As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DateMovementHistory As System.Windows.Forms.DateTimePicker
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents TEXTDocumentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboConstraintType As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextDateMovementHistory As System.Windows.Forms.TextBox
    Friend WithEvents TEXTTEXTTotalN As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ADDBUTTON As System.Windows.Forms.Button
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBN3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents Panel18 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Panel17 As Panel
    Friend WithEvents TEXTTotal As Label
    Friend WithEvents TEXTCredit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEXTDebit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEXTID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextMovementSymbol As DevExpress.XtraEditors.TextEdit
End Class
