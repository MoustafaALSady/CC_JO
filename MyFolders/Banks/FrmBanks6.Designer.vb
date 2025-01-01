<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmBanks6
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmBanks6))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Panel18 = New System.Windows.Forms.Panel()
        Me.ComboMotionSource = New System.Windows.Forms.ComboBox()
        Me.lblBANKNAME = New System.Windows.Forms.Label()
        Me.TEXTStatement = New System.Windows.Forms.ComboBox()
        Me.lblCOLLECTDATE = New System.Windows.Forms.Label()
        Me.ComboDetails = New System.Windows.Forms.ComboBox()
        Me.lblNOTES = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Panel17 = New System.Windows.Forms.Panel()
        Me.TEXTCredit = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTDebit = New DevExpress.XtraEditors.TextEdit()
        Me.ComboPaymentMethod = New System.Windows.Forms.ComboBox()
        Me.lblPAYMENT = New System.Windows.Forms.Label()
        Me.TEXTPreviousBalance = New System.Windows.Forms.TextBox()
        Me.lblPREVIOUSBALANCE = New System.Windows.Forms.Label()
        Me.lblDEBIT = New System.Windows.Forms.Label()
        Me.TEXTCurrentBalance = New System.Windows.Forms.TextBox()
        Me.lblNOWBALANCE = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel16 = New System.Windows.Forms.Panel()
        Me.TextMovementSymbol = New DevExpress.XtraEditors.TextEdit()
        Me.TEXTID = New DevExpress.XtraEditors.TextEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextCB2 = New System.Windows.Forms.TextBox()
        Me.ComboConstraintType = New System.Windows.Forms.ComboBox()
        Me.ComboCB1 = New System.Windows.Forms.ComboBox()
        Me.TEXTDocumentNumber = New System.Windows.Forms.TextBox()
        Me.lblACCOUNTNUMBER = New System.Windows.Forms.Label()
        Me.lblOPERATIONDATE = New System.Windows.Forms.Label()
        Me.DateMovementHistory = New System.Windows.Forms.DateTimePicker()
        Me.lblCODE = New System.Windows.Forms.Label()
        Me.TextDateMovementHistory = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel18.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel17.SuspendLayout()
        CType(Me.TEXTCredit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEXTDebit.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel16.SuspendLayout()
        CType(Me.TextMovementSymbol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TEXTID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.GroupBox3)
        Me.Panel2.Controls.Add(Me.GroupBox2)
        Me.Panel2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Panel2.Location = New System.Drawing.Point(4, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(654, 257)
        Me.Panel2.TabIndex = 923
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel18)
        Me.GroupBox4.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox4.Location = New System.Drawing.Point(3, 140)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox4.Size = New System.Drawing.Size(647, 110)
        Me.GroupBox4.TabIndex = 956
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "البيــان"
        '
        'Panel18
        '
        Me.Panel18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel18.Controls.Add(Me.ComboMotionSource)
        Me.Panel18.Controls.Add(Me.lblBANKNAME)
        Me.Panel18.Controls.Add(Me.TEXTStatement)
        Me.Panel18.Controls.Add(Me.lblCOLLECTDATE)
        Me.Panel18.Controls.Add(Me.ComboDetails)
        Me.Panel18.Controls.Add(Me.lblNOTES)
        Me.Panel18.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel18.Location = New System.Drawing.Point(3, 18)
        Me.Panel18.Name = "Panel18"
        Me.Panel18.Size = New System.Drawing.Size(641, 89)
        Me.Panel18.TabIndex = 0
        '
        'ComboMotionSource
        '
        Me.ComboMotionSource.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboMotionSource.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboMotionSource.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ComboMotionSource.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboMotionSource.ForeColor = System.Drawing.Color.Black
        Me.ComboMotionSource.Location = New System.Drawing.Point(4, 6)
        Me.ComboMotionSource.Name = "ComboMotionSource"
        Me.ComboMotionSource.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboMotionSource.Size = New System.Drawing.Size(542, 23)
        Me.ComboMotionSource.TabIndex = 562
        '
        'lblBANKNAME
        '
        Me.lblBANKNAME.AutoSize = True
        Me.lblBANKNAME.BackColor = System.Drawing.Color.Transparent
        Me.lblBANKNAME.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblBANKNAME.ForeColor = System.Drawing.Color.Black
        Me.lblBANKNAME.Location = New System.Drawing.Point(593, 59)
        Me.lblBANKNAME.Name = "lblBANKNAME"
        Me.lblBANKNAME.Size = New System.Drawing.Size(38, 15)
        Me.lblBANKNAME.TabIndex = 4
        Me.lblBANKNAME.Text = "تفاصيل"
        Me.lblBANKNAME.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TEXTStatement
        '
        Me.TEXTStatement.AutoCompleteCustomSource.AddRange(New String() {"رسوم ادارية", "رسوم جمركية", "ضريبة مبيعات", "ارباح تجارية", "رسوم تفريغ", "رسوم حراسة", "رسوم غرامة", "رسوم حاويات", "رسوم زراعة", "م تخليص", "بتروكيماويات", "ملاحظة جمركية", "هيئةالميناء", "مصاريف بنكية", "مصاريف الفيلا", "توكيلات", "جمارك", "مصاريف اخرى", "مناقصات", "تسويات", "شيكات", "نقل", "ونش"})
        Me.TEXTStatement.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.TEXTStatement.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.TEXTStatement.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTStatement.FormattingEnabled = True
        Me.TEXTStatement.Location = New System.Drawing.Point(4, 31)
        Me.TEXTStatement.Name = "TEXTStatement"
        Me.TEXTStatement.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TEXTStatement.Size = New System.Drawing.Size(542, 23)
        Me.TEXTStatement.TabIndex = 559
        '
        'lblCOLLECTDATE
        '
        Me.lblCOLLECTDATE.AutoSize = True
        Me.lblCOLLECTDATE.BackColor = System.Drawing.Color.Transparent
        Me.lblCOLLECTDATE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCOLLECTDATE.ForeColor = System.Drawing.Color.Black
        Me.lblCOLLECTDATE.Location = New System.Drawing.Point(567, 9)
        Me.lblCOLLECTDATE.Name = "lblCOLLECTDATE"
        Me.lblCOLLECTDATE.Size = New System.Drawing.Size(64, 15)
        Me.lblCOLLECTDATE.TabIndex = 6
        Me.lblCOLLECTDATE.Text = "مصدر الحركة"
        Me.lblCOLLECTDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboDetails
        '
        Me.ComboDetails.AutoCompleteCustomSource.AddRange(New String() {"رسوم ادارية", "رسوم جمركية", "ضريبة مبيعات", "ارباح تجارية", "رسوم تفريغ", "رسوم حراسة", "رسوم غرامة", "رسوم حاويات", "رسوم زراعة", "م تخليص", "بتروكيماويات", "ملاحظة جمركية", "هيئةالميناء", "مصاريف بنكية", "مصاريف الفيلا", "توكيلات", "جمارك", "مصاريف اخرى", "مناقصات", "تسويات", "شيكات", "نقل", "ونش"})
        Me.ComboDetails.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboDetails.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboDetails.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboDetails.FormattingEnabled = True
        Me.ComboDetails.Location = New System.Drawing.Point(4, 56)
        Me.ComboDetails.MinimumSize = New System.Drawing.Size(20, 0)
        Me.ComboDetails.Name = "ComboDetails"
        Me.ComboDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboDetails.Size = New System.Drawing.Size(542, 23)
        Me.ComboDetails.TabIndex = 566
        '
        'lblNOTES
        '
        Me.lblNOTES.AutoSize = True
        Me.lblNOTES.BackColor = System.Drawing.Color.Transparent
        Me.lblNOTES.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNOTES.ForeColor = System.Drawing.Color.Black
        Me.lblNOTES.Location = New System.Drawing.Point(594, 34)
        Me.lblNOTES.Name = "lblNOTES"
        Me.lblNOTES.Size = New System.Drawing.Size(37, 15)
        Me.lblNOTES.TabIndex = 15
        Me.lblNOTES.Text = "البيــان"
        Me.lblNOTES.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Panel17)
        Me.GroupBox3.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox3.Location = New System.Drawing.Point(4, 5)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox3.Size = New System.Drawing.Size(289, 131)
        Me.GroupBox3.TabIndex = 955
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "الأرصدة"
        '
        'Panel17
        '
        Me.Panel17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel17.Controls.Add(Me.TEXTCredit)
        Me.Panel17.Controls.Add(Me.TEXTDebit)
        Me.Panel17.Controls.Add(Me.ComboPaymentMethod)
        Me.Panel17.Controls.Add(Me.lblPAYMENT)
        Me.Panel17.Controls.Add(Me.TEXTPreviousBalance)
        Me.Panel17.Controls.Add(Me.lblPREVIOUSBALANCE)
        Me.Panel17.Controls.Add(Me.lblDEBIT)
        Me.Panel17.Controls.Add(Me.TEXTCurrentBalance)
        Me.Panel17.Controls.Add(Me.lblNOWBALANCE)
        Me.Panel17.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel17.Location = New System.Drawing.Point(3, 18)
        Me.Panel17.Name = "Panel17"
        Me.Panel17.Size = New System.Drawing.Size(283, 110)
        Me.Panel17.TabIndex = 0
        '
        'TEXTCredit
        '
        Me.TEXTCredit.EditValue = "0"
        Me.TEXTCredit.Location = New System.Drawing.Point(3, 52)
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
        Me.TEXTCredit.TabIndex = 958
        '
        'TEXTDebit
        '
        Me.TEXTDebit.EditValue = "0"
        Me.TEXTDebit.Location = New System.Drawing.Point(106, 52)
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
        Me.TEXTDebit.TabIndex = 959
        '
        'ComboPaymentMethod
        '
        Me.ComboPaymentMethod.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboPaymentMethod.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboPaymentMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboPaymentMethod.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboPaymentMethod.ForeColor = System.Drawing.Color.Black
        Me.ComboPaymentMethod.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboPaymentMethod.Items.AddRange(New Object() {"نقدا", "شيك", "نقدا_شيك"})
        Me.ComboPaymentMethod.Location = New System.Drawing.Point(3, 4)
        Me.ComboPaymentMethod.Name = "ComboPaymentMethod"
        Me.ComboPaymentMethod.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboPaymentMethod.Size = New System.Drawing.Size(205, 23)
        Me.ComboPaymentMethod.TabIndex = 4
        '
        'lblPAYMENT
        '
        Me.lblPAYMENT.AutoSize = True
        Me.lblPAYMENT.BackColor = System.Drawing.Color.Transparent
        Me.lblPAYMENT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPAYMENT.ForeColor = System.Drawing.Color.Black
        Me.lblPAYMENT.Location = New System.Drawing.Point(222, 7)
        Me.lblPAYMENT.Name = "lblPAYMENT"
        Me.lblPAYMENT.Size = New System.Drawing.Size(56, 15)
        Me.lblPAYMENT.TabIndex = 19
        Me.lblPAYMENT.Text = "طريقة الدفع"
        Me.lblPAYMENT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TEXTPreviousBalance
        '
        Me.TEXTPreviousBalance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEXTPreviousBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTPreviousBalance.Enabled = False
        Me.TEXTPreviousBalance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTPreviousBalance.ForeColor = System.Drawing.Color.Black
        Me.TEXTPreviousBalance.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TEXTPreviousBalance.Location = New System.Drawing.Point(3, 29)
        Me.TEXTPreviousBalance.Name = "TEXTPreviousBalance"
        Me.TEXTPreviousBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTPreviousBalance.Size = New System.Drawing.Size(205, 22)
        Me.TEXTPreviousBalance.TabIndex = 5
        Me.TEXTPreviousBalance.Text = "0.000"
        Me.TEXTPreviousBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblPREVIOUSBALANCE
        '
        Me.lblPREVIOUSBALANCE.AutoSize = True
        Me.lblPREVIOUSBALANCE.BackColor = System.Drawing.Color.Transparent
        Me.lblPREVIOUSBALANCE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblPREVIOUSBALANCE.ForeColor = System.Drawing.Color.Black
        Me.lblPREVIOUSBALANCE.Location = New System.Drawing.Point(209, 31)
        Me.lblPREVIOUSBALANCE.Name = "lblPREVIOUSBALANCE"
        Me.lblPREVIOUSBALANCE.Size = New System.Drawing.Size(69, 15)
        Me.lblPREVIOUSBALANCE.TabIndex = 20
        Me.lblPREVIOUSBALANCE.Text = "الرصيد السابق"
        Me.lblPREVIOUSBALANCE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDEBIT
        '
        Me.lblDEBIT.AutoSize = True
        Me.lblDEBIT.BackColor = System.Drawing.Color.Transparent
        Me.lblDEBIT.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblDEBIT.ForeColor = System.Drawing.Color.Black
        Me.lblDEBIT.Location = New System.Drawing.Point(223, 54)
        Me.lblDEBIT.Name = "lblDEBIT"
        Me.lblDEBIT.Size = New System.Drawing.Size(55, 15)
        Me.lblDEBIT.TabIndex = 8
        Me.lblDEBIT.Text = "مدين / دائن"
        Me.lblDEBIT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TEXTCurrentBalance
        '
        Me.TEXTCurrentBalance.BackColor = System.Drawing.Color.WhiteSmoke
        Me.TEXTCurrentBalance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTCurrentBalance.Enabled = False
        Me.TEXTCurrentBalance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTCurrentBalance.ForeColor = System.Drawing.Color.Black
        Me.TEXTCurrentBalance.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TEXTCurrentBalance.Location = New System.Drawing.Point(3, 77)
        Me.TEXTCurrentBalance.Name = "TEXTCurrentBalance"
        Me.TEXTCurrentBalance.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTCurrentBalance.Size = New System.Drawing.Size(205, 22)
        Me.TEXTCurrentBalance.TabIndex = 8
        Me.TEXTCurrentBalance.Text = "0.000"
        Me.TEXTCurrentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblNOWBALANCE
        '
        Me.lblNOWBALANCE.AutoSize = True
        Me.lblNOWBALANCE.BackColor = System.Drawing.Color.Transparent
        Me.lblNOWBALANCE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblNOWBALANCE.ForeColor = System.Drawing.Color.Black
        Me.lblNOWBALANCE.Location = New System.Drawing.Point(212, 80)
        Me.lblNOWBALANCE.Name = "lblNOWBALANCE"
        Me.lblNOWBALANCE.Size = New System.Drawing.Size(66, 15)
        Me.lblNOWBALANCE.TabIndex = 16
        Me.lblNOWBALANCE.Text = "الرصيد الحالى"
        Me.lblNOWBALANCE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Panel16)
        Me.GroupBox2.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(295, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.GroupBox2.Size = New System.Drawing.Size(355, 131)
        Me.GroupBox2.TabIndex = 954
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بيانات الحركة"
        '
        'Panel16
        '
        Me.Panel16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel16.Controls.Add(Me.TextMovementSymbol)
        Me.Panel16.Controls.Add(Me.TEXTID)
        Me.Panel16.Controls.Add(Me.Label16)
        Me.Panel16.Controls.Add(Me.TextCB2)
        Me.Panel16.Controls.Add(Me.ComboConstraintType)
        Me.Panel16.Controls.Add(Me.ComboCB1)
        Me.Panel16.Controls.Add(Me.TEXTDocumentNumber)
        Me.Panel16.Controls.Add(Me.lblACCOUNTNUMBER)
        Me.Panel16.Controls.Add(Me.lblOPERATIONDATE)
        Me.Panel16.Controls.Add(Me.DateMovementHistory)
        Me.Panel16.Controls.Add(Me.lblCODE)
        Me.Panel16.Controls.Add(Me.TextDateMovementHistory)
        Me.Panel16.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel16.Location = New System.Drawing.Point(3, 18)
        Me.Panel16.Name = "Panel16"
        Me.Panel16.Size = New System.Drawing.Size(349, 110)
        Me.Panel16.TabIndex = 0
        '
        'TextMovementSymbol
        '
        Me.TextMovementSymbol.EditValue = "0"
        Me.TextMovementSymbol.Enabled = False
        Me.TextMovementSymbol.Location = New System.Drawing.Point(3, 2)
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
        Me.TextMovementSymbol.TabIndex = 995
        '
        'TEXTID
        '
        Me.TEXTID.EditValue = "0"
        Me.TEXTID.Enabled = False
        Me.TEXTID.Location = New System.Drawing.Point(128, 2)
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
        Me.TEXTID.Size = New System.Drawing.Size(126, 22)
        Me.TEXTID.TabIndex = 994
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(277, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(63, 15)
        Me.Label16.TabIndex = 929
        Me.Label16.Text = "رقم الصندوق"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextCB2
        '
        Me.TextCB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCB2.Enabled = False
        Me.TextCB2.Font = New System.Drawing.Font("Times New Roman", 9.85!, System.Drawing.FontStyle.Bold)
        Me.TextCB2.ForeColor = System.Drawing.Color.Black
        Me.TextCB2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextCB2.Location = New System.Drawing.Point(3, 53)
        Me.TextCB2.Name = "TextCB2"
        Me.TextCB2.Size = New System.Drawing.Size(140, 23)
        Me.TextCB2.TabIndex = 928
        Me.TextCB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboConstraintType
        '
        Me.ComboConstraintType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboConstraintType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboConstraintType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboConstraintType.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboConstraintType.ForeColor = System.Drawing.Color.Black
        Me.ComboConstraintType.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboConstraintType.Items.AddRange(New Object() {"قبض", "صرف"})
        Me.ComboConstraintType.Location = New System.Drawing.Point(144, 78)
        Me.ComboConstraintType.Name = "ComboConstraintType"
        Me.ComboConstraintType.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboConstraintType.Size = New System.Drawing.Size(110, 23)
        Me.ComboConstraintType.TabIndex = 2
        '
        'ComboCB1
        '
        Me.ComboCB1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCB1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCB1.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold)
        Me.ComboCB1.ForeColor = System.Drawing.Color.Black
        Me.ComboCB1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboCB1.Location = New System.Drawing.Point(144, 53)
        Me.ComboCB1.Name = "ComboCB1"
        Me.ComboCB1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.ComboCB1.Size = New System.Drawing.Size(110, 23)
        Me.ComboCB1.TabIndex = 927
        '
        'TEXTDocumentNumber
        '
        Me.TEXTDocumentNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TEXTDocumentNumber.Font = New System.Drawing.Font("Times New Roman", 9.85!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TEXTDocumentNumber.ForeColor = System.Drawing.Color.Black
        Me.TEXTDocumentNumber.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TEXTDocumentNumber.Location = New System.Drawing.Point(3, 78)
        Me.TEXTDocumentNumber.Name = "TEXTDocumentNumber"
        Me.TEXTDocumentNumber.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TEXTDocumentNumber.Size = New System.Drawing.Size(140, 23)
        Me.TEXTDocumentNumber.TabIndex = 3
        Me.TEXTDocumentNumber.Text = "0"
        Me.TEXTDocumentNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblACCOUNTNUMBER
        '
        Me.lblACCOUNTNUMBER.AutoSize = True
        Me.lblACCOUNTNUMBER.BackColor = System.Drawing.Color.Transparent
        Me.lblACCOUNTNUMBER.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblACCOUNTNUMBER.ForeColor = System.Drawing.Color.Black
        Me.lblACCOUNTNUMBER.Location = New System.Drawing.Point(255, 85)
        Me.lblACCOUNTNUMBER.Name = "lblACCOUNTNUMBER"
        Me.lblACCOUNTNUMBER.Size = New System.Drawing.Size(85, 15)
        Me.lblACCOUNTNUMBER.TabIndex = 3
        Me.lblACCOUNTNUMBER.Text = "نوع و رقم المستند"
        Me.lblACCOUNTNUMBER.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOPERATIONDATE
        '
        Me.lblOPERATIONDATE.AutoSize = True
        Me.lblOPERATIONDATE.BackColor = System.Drawing.Color.Transparent
        Me.lblOPERATIONDATE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblOPERATIONDATE.ForeColor = System.Drawing.Color.Black
        Me.lblOPERATIONDATE.Location = New System.Drawing.Point(277, 33)
        Me.lblOPERATIONDATE.Name = "lblOPERATIONDATE"
        Me.lblOPERATIONDATE.Size = New System.Drawing.Size(63, 15)
        Me.lblOPERATIONDATE.TabIndex = 17
        Me.lblOPERATIONDATE.Text = "تاريخ الحركة"
        Me.lblOPERATIONDATE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateMovementHistory
        '
        Me.DateMovementHistory.Checked = False
        Me.DateMovementHistory.CustomFormat = "yyyy-MM-dd"
        Me.DateMovementHistory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.DateMovementHistory.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateMovementHistory.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.DateMovementHistory.Location = New System.Drawing.Point(3, 28)
        Me.DateMovementHistory.Name = "DateMovementHistory"
        Me.DateMovementHistory.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.DateMovementHistory.RightToLeftLayout = True
        Me.DateMovementHistory.Size = New System.Drawing.Size(251, 22)
        Me.DateMovementHistory.TabIndex = 922
        Me.DateMovementHistory.Value = New Date(2018, 5, 7, 0, 0, 0, 0)
        '
        'lblCODE
        '
        Me.lblCODE.AutoSize = True
        Me.lblCODE.BackColor = System.Drawing.Color.Transparent
        Me.lblCODE.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.lblCODE.ForeColor = System.Drawing.Color.Black
        Me.lblCODE.Location = New System.Drawing.Point(259, 9)
        Me.lblCODE.Name = "lblCODE"
        Me.lblCODE.Size = New System.Drawing.Size(81, 15)
        Me.lblCODE.TabIndex = 5
        Me.lblCODE.Text = "الرقم - رمز حركة"
        Me.lblCODE.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextDateMovementHistory
        '
        Me.TextDateMovementHistory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextDateMovementHistory.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextDateMovementHistory.ForeColor = System.Drawing.Color.Black
        Me.TextDateMovementHistory.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextDateMovementHistory.Location = New System.Drawing.Point(3, 28)
        Me.TextDateMovementHistory.Name = "TextDateMovementHistory"
        Me.TextDateMovementHistory.Size = New System.Drawing.Size(251, 22)
        Me.TextDateMovementHistory.TabIndex = 923
        Me.TextDateMovementHistory.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox2.Location = New System.Drawing.Point(6, 264)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 924
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox5.Location = New System.Drawing.Point(6, 260)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 925
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.SAVEBUTTON.Location = New System.Drawing.Point(4, 265)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.Size = New System.Drawing.Size(326, 30)
        Me.SAVEBUTTON.TabIndex = 935
        Me.SAVEBUTTON.Text = "حفظ F2"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.UseVisualStyleBackColor = False
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ADDBUTTON.Location = New System.Drawing.Point(332, 265)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(326, 30)
        Me.ADDBUTTON.TabIndex = 934
        Me.ADDBUTTON.Text = "اضافة F1"
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.UseVisualStyleBackColor = False
        '
        'FrmBanks6
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.ClientSize = New System.Drawing.Size(662, 302)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.SAVEBUTTON)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.ADDBUTTON)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmBanks6"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "اضافة حركة الصنندوق"
        Me.Panel2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel18.ResumeLayout(False)
        Me.Panel18.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.Panel17.ResumeLayout(False)
        Me.Panel17.PerformLayout()
        CType(Me.TEXTCredit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEXTDebit.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel16.ResumeLayout(False)
        Me.Panel16.PerformLayout()
        CType(Me.TextMovementSymbol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TEXTID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents DateMovementHistory As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextDateMovementHistory As System.Windows.Forms.TextBox
    Friend WithEvents lblCODE As System.Windows.Forms.Label
    Friend WithEvents lblNOWBALANCE As System.Windows.Forms.Label
    Friend WithEvents TEXTCurrentBalance As System.Windows.Forms.TextBox
    Friend WithEvents lblOPERATIONDATE As System.Windows.Forms.Label
    Friend WithEvents lblDEBIT As System.Windows.Forms.Label
    Friend WithEvents lblACCOUNTNUMBER As System.Windows.Forms.Label
    Friend WithEvents TEXTPreviousBalance As System.Windows.Forms.TextBox
    Friend WithEvents TEXTDocumentNumber As System.Windows.Forms.TextBox
    Friend WithEvents lblPREVIOUSBALANCE As System.Windows.Forms.Label
    Friend WithEvents ComboPaymentMethod As System.Windows.Forms.ComboBox
    Friend WithEvents ComboConstraintType As System.Windows.Forms.ComboBox
    Friend WithEvents lblPAYMENT As System.Windows.Forms.Label
    Friend WithEvents lblCOLLECTDATE As System.Windows.Forms.Label
    Friend WithEvents ComboMotionSource As System.Windows.Forms.ComboBox
    Friend WithEvents lblNOTES As System.Windows.Forms.Label
    Friend WithEvents ComboDetails As System.Windows.Forms.ComboBox
    Friend WithEvents TEXTStatement As System.Windows.Forms.ComboBox
    Friend WithEvents lblBANKNAME As System.Windows.Forms.Label
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents SAVEBUTTON As System.Windows.Forms.Button
    Friend WithEvents ADDBUTTON As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextCB2 As System.Windows.Forms.TextBox
    Friend WithEvents ComboCB1 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel16 As Panel
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Panel17 As Panel
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents Panel18 As Panel
    Friend WithEvents TEXTCredit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEXTDebit As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TEXTID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextMovementSymbol As DevExpress.XtraEditors.TextEdit
End Class
