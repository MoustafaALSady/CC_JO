<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInventoryBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInventoryBox))
        Me.TextNo = New System.Windows.Forms.TextBox()
        Me.DateT = New System.Windows.Forms.DateTimePicker()
        Me.TextReceiptVoucherFrom = New System.Windows.Forms.TextBox()
        Me.TextReceiptVoucher = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextPaymentVoucherFrom = New System.Windows.Forms.TextBox()
        Me.TextPaymentVoucher = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextRecordingDocumentFrom = New System.Windows.Forms.TextBox()
        Me.TextRecordingDocument = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextAmountsInWriting = New System.Windows.Forms.TextBox()
        Me.TextNotes = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TextCB2 = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ComboCB1 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PRINTBUTTON = New System.Windows.Forms.Button()
        Me.BUTTONCANCEL = New System.Windows.Forms.Button()
        Me.EDITBUTTON = New System.Windows.Forms.Button()
        Me.SAVEBUTTON = New System.Windows.Forms.Button()
        Me.ADDBUTTON = New System.Windows.Forms.Button()
        Me.LASTBUTTON = New System.Windows.Forms.Button()
        Me.NEXTBUTTON = New System.Windows.Forms.Button()
        Me.RECORDSLABEL = New System.Windows.Forms.Label()
        Me.PREVIOUSBUTTON = New System.Windows.Forms.Button()
        Me.FIRSTBUTTON = New System.Windows.Forms.Button()
        Me.BackWorker2 = New System.ComponentModel.BackgroundWorker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextcurrentAmounts = New DevExpress.XtraEditors.TextEdit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.TextcurrentAmounts.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TextNo
        '
        Me.TextNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNo.Cursor = System.Windows.Forms.Cursors.Default
        Me.TextNo.Location = New System.Drawing.Point(310, 4)
        Me.TextNo.Name = "TextNo"
        Me.TextNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextNo.Size = New System.Drawing.Size(126, 22)
        Me.TextNo.TabIndex = 0
        Me.TextNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DateT
        '
        Me.DateT.CustomFormat = "dd/MM/yyyy"
        Me.DateT.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateT.Location = New System.Drawing.Point(6, 3)
        Me.DateT.Name = "DateT"
        Me.DateT.RightToLeftLayout = True
        Me.DateT.Size = New System.Drawing.Size(159, 22)
        Me.DateT.TabIndex = 1
        '
        'TextReceiptVoucherFrom
        '
        Me.TextReceiptVoucherFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReceiptVoucherFrom.Location = New System.Drawing.Point(307, 5)
        Me.TextReceiptVoucherFrom.Name = "TextReceiptVoucherFrom"
        Me.TextReceiptVoucherFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextReceiptVoucherFrom.Size = New System.Drawing.Size(126, 22)
        Me.TextReceiptVoucherFrom.TabIndex = 2
        Me.TextReceiptVoucherFrom.Text = "0"
        Me.TextReceiptVoucherFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextReceiptVoucher
        '
        Me.TextReceiptVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextReceiptVoucher.Location = New System.Drawing.Point(2, 3)
        Me.TextReceiptVoucher.Name = "TextReceiptVoucher"
        Me.TextReceiptVoucher.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextReceiptVoucher.Size = New System.Drawing.Size(160, 22)
        Me.TextReceiptVoucher.TabIndex = 3
        Me.TextReceiptVoucher.Text = "0"
        Me.TextReceiptVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(462, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 15)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "سند قبض من"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Location = New System.Drawing.Point(179, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 15)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "سند قبض الى"
        '
        'TextPaymentVoucherFrom
        '
        Me.TextPaymentVoucherFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPaymentVoucherFrom.Location = New System.Drawing.Point(307, 28)
        Me.TextPaymentVoucherFrom.Name = "TextPaymentVoucherFrom"
        Me.TextPaymentVoucherFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextPaymentVoucherFrom.Size = New System.Drawing.Size(126, 22)
        Me.TextPaymentVoucherFrom.TabIndex = 6
        Me.TextPaymentVoucherFrom.Text = "0"
        Me.TextPaymentVoucherFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextPaymentVoucher
        '
        Me.TextPaymentVoucher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextPaymentVoucher.Location = New System.Drawing.Point(2, 26)
        Me.TextPaymentVoucher.Name = "TextPaymentVoucher"
        Me.TextPaymentVoucher.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextPaymentVoucher.Size = New System.Drawing.Size(160, 22)
        Me.TextPaymentVoucher.TabIndex = 7
        Me.TextPaymentVoucher.Text = "0"
        Me.TextPaymentVoucher.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Location = New System.Drawing.Point(175, 36)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "سند صرف الى"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(458, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(67, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "سند صرف من"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(189, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 15)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "سند قيد الى"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Location = New System.Drawing.Point(472, 56)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "سند قيد من"
        '
        'TextRecordingDocumentFrom
        '
        Me.TextRecordingDocumentFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRecordingDocumentFrom.Location = New System.Drawing.Point(307, 51)
        Me.TextRecordingDocumentFrom.Name = "TextRecordingDocumentFrom"
        Me.TextRecordingDocumentFrom.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextRecordingDocumentFrom.Size = New System.Drawing.Size(126, 22)
        Me.TextRecordingDocumentFrom.TabIndex = 11
        Me.TextRecordingDocumentFrom.Text = "0"
        Me.TextRecordingDocumentFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextRecordingDocument
        '
        Me.TextRecordingDocument.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextRecordingDocument.Location = New System.Drawing.Point(2, 50)
        Me.TextRecordingDocument.Name = "TextRecordingDocument"
        Me.TextRecordingDocument.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TextRecordingDocument.Size = New System.Drawing.Size(160, 22)
        Me.TextRecordingDocument.TabIndex = 10
        Me.TextRecordingDocument.Text = "0"
        Me.TextRecordingDocument.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Location = New System.Drawing.Point(463, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 15)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "المبالغ الحالي"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.Transparent
        Me.Label8.Location = New System.Drawing.Point(439, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "المبالغ الحالي كتابة"
        '
        'TextAmountsInWriting
        '
        Me.TextAmountsInWriting.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextAmountsInWriting.Enabled = False
        Me.TextAmountsInWriting.Location = New System.Drawing.Point(3, 30)
        Me.TextAmountsInWriting.Name = "TextAmountsInWriting"
        Me.TextAmountsInWriting.Size = New System.Drawing.Size(430, 22)
        Me.TextAmountsInWriting.TabIndex = 16
        '
        'TextNotes
        '
        Me.TextNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextNotes.Location = New System.Drawing.Point(3, 54)
        Me.TextNotes.Multiline = True
        Me.TextNotes.Name = "TextNotes"
        Me.TextNotes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.TextNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextNotes.Size = New System.Drawing.Size(430, 56)
        Me.TextNotes.TabIndex = 17
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label10.Location = New System.Drawing.Point(475, 58)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 17)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "ملاحظات"
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.CC_JO.My.Resources.Resources.indecator1
        Me.PictureBox5.Location = New System.Drawing.Point(499, 83)
        Me.PictureBox5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(31, 31)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox5.TabIndex = 726
        Me.PictureBox5.TabStop = False
        Me.PictureBox5.Visible = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.CC_JO.My.Resources.Resources.spinner3_greenie
        Me.PictureBox2.Location = New System.Drawing.Point(496, 78)
        Me.PictureBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 36)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox2.TabIndex = 727
        Me.PictureBox2.TabStop = False
        Me.PictureBox2.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TextCB2)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.ComboCB1)
        Me.Panel1.Controls.Add(Me.TextNo)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.DateT)
        Me.Panel1.Location = New System.Drawing.Point(5, 41)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(549, 61)
        Me.Panel1.TabIndex = 35
        '
        'TextCB2
        '
        Me.TextCB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextCB2.Enabled = False
        Me.TextCB2.Font = New System.Drawing.Font("Times New Roman", 9.95!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextCB2.ForeColor = System.Drawing.Color.Black
        Me.TextCB2.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.TextCB2.Location = New System.Drawing.Point(6, 28)
        Me.TextCB2.Name = "TextCB2"
        Me.TextCB2.Size = New System.Drawing.Size(302, 23)
        Me.TextCB2.TabIndex = 926
        Me.TextCB2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Location = New System.Drawing.Point(466, 30)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(63, 15)
        Me.Label9.TabIndex = 927
        Me.Label9.Text = "رقم الصندوق"
        '
        'ComboCB1
        '
        Me.ComboCB1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.ComboCB1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.ComboCB1.Font = New System.Drawing.Font("Times New Roman", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.ComboCB1.ForeColor = System.Drawing.Color.Black
        Me.ComboCB1.ImeMode = System.Windows.Forms.ImeMode.[On]
        Me.ComboCB1.Location = New System.Drawing.Point(310, 28)
        Me.ComboCB1.Name = "ComboCB1"
        Me.ComboCB1.Size = New System.Drawing.Size(126, 23)
        Me.ComboCB1.TabIndex = 925
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Location = New System.Drawing.Point(498, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 15)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "الرقم "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Location = New System.Drawing.Point(182, 6)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(37, 15)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "التاريخ"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.PRINTBUTTON)
        Me.Panel2.Controls.Add(Me.BUTTONCANCEL)
        Me.Panel2.Controls.Add(Me.EDITBUTTON)
        Me.Panel2.Controls.Add(Me.SAVEBUTTON)
        Me.Panel2.Controls.Add(Me.ADDBUTTON)
        Me.Panel2.Controls.Add(Me.LASTBUTTON)
        Me.Panel2.Controls.Add(Me.NEXTBUTTON)
        Me.Panel2.Controls.Add(Me.RECORDSLABEL)
        Me.Panel2.Controls.Add(Me.PREVIOUSBUTTON)
        Me.Panel2.Controls.Add(Me.FIRSTBUTTON)
        Me.Panel2.Location = New System.Drawing.Point(5, 357)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(549, 65)
        Me.Panel2.TabIndex = 85
        '
        'PRINTBUTTON
        '
        Me.PRINTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PRINTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PRINTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PRINTBUTTON.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.PRINTBUTTON.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PRINTBUTTON.Image = CType(resources.GetObject("PRINTBUTTON.Image"), System.Drawing.Image)
        Me.PRINTBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.PRINTBUTTON.Location = New System.Drawing.Point(2, 33)
        Me.PRINTBUTTON.Name = "PRINTBUTTON"
        Me.PRINTBUTTON.Size = New System.Drawing.Size(111, 28)
        Me.PRINTBUTTON.TabIndex = 762
        Me.PRINTBUTTON.Text = "طباعــة F5"
        Me.PRINTBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.PRINTBUTTON.UseVisualStyleBackColor = False
        '
        'BUTTONCANCEL
        '
        Me.BUTTONCANCEL.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.BUTTONCANCEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BUTTONCANCEL.Image = Global.CC_JO.My.Resources.Resources.Cancel_16x16
        Me.BUTTONCANCEL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.BUTTONCANCEL.Location = New System.Drawing.Point(114, 33)
        Me.BUTTONCANCEL.Name = "BUTTONCANCEL"
        Me.BUTTONCANCEL.Size = New System.Drawing.Size(107, 28)
        Me.BUTTONCANCEL.TabIndex = 682
        Me.BUTTONCANCEL.Text = "إلغاء"
        Me.BUTTONCANCEL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EDITBUTTON
        '
        Me.EDITBUTTON.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.EDITBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.EDITBUTTON.Image = Global.CC_JO.My.Resources.Resources.Edit_16x161
        Me.EDITBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EDITBUTTON.Location = New System.Drawing.Point(222, 33)
        Me.EDITBUTTON.Name = "EDITBUTTON"
        Me.EDITBUTTON.Size = New System.Drawing.Size(107, 28)
        Me.EDITBUTTON.TabIndex = 681
        Me.EDITBUTTON.Text = "تعديل"
        Me.EDITBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SAVEBUTTON
        '
        Me.SAVEBUTTON.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.SAVEBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SAVEBUTTON.Image = Global.CC_JO.My.Resources.Resources.Save_16x16
        Me.SAVEBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SAVEBUTTON.Location = New System.Drawing.Point(330, 33)
        Me.SAVEBUTTON.Name = "SAVEBUTTON"
        Me.SAVEBUTTON.Size = New System.Drawing.Size(107, 28)
        Me.SAVEBUTTON.TabIndex = 680
        Me.SAVEBUTTON.Text = "حفظ"
        Me.SAVEBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ADDBUTTON
        '
        Me.ADDBUTTON.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ADDBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ADDBUTTON.Image = Global.CC_JO.My.Resources.Resources.add1
        Me.ADDBUTTON.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ADDBUTTON.Location = New System.Drawing.Point(438, 33)
        Me.ADDBUTTON.Name = "ADDBUTTON"
        Me.ADDBUTTON.Size = New System.Drawing.Size(107, 28)
        Me.ADDBUTTON.TabIndex = 679
        Me.ADDBUTTON.Text = "إضافة "
        Me.ADDBUTTON.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LASTBUTTON
        '
        Me.LASTBUTTON.AutoSize = True
        Me.LASTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.LASTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left_2
        Me.LASTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.LASTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.LASTBUTTON.Location = New System.Drawing.Point(2, 2)
        Me.LASTBUTTON.Name = "LASTBUTTON"
        Me.LASTBUTTON.Size = New System.Drawing.Size(40, 28)
        Me.LASTBUTTON.TabIndex = 678
        Me.LASTBUTTON.UseVisualStyleBackColor = False
        '
        'NEXTBUTTON
        '
        Me.NEXTBUTTON.AutoSize = True
        Me.NEXTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.NEXTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_left
        Me.NEXTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.NEXTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NEXTBUTTON.Location = New System.Drawing.Point(43, 2)
        Me.NEXTBUTTON.Name = "NEXTBUTTON"
        Me.NEXTBUTTON.Size = New System.Drawing.Size(40, 28)
        Me.NEXTBUTTON.TabIndex = 677
        Me.NEXTBUTTON.UseVisualStyleBackColor = False
        '
        'RECORDSLABEL
        '
        Me.RECORDSLABEL.BackColor = System.Drawing.Color.Transparent
        Me.RECORDSLABEL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RECORDSLABEL.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RECORDSLABEL.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.RECORDSLABEL.ForeColor = System.Drawing.Color.Black
        Me.RECORDSLABEL.Location = New System.Drawing.Point(84, 2)
        Me.RECORDSLABEL.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RECORDSLABEL.Name = "RECORDSLABEL"
        Me.RECORDSLABEL.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RECORDSLABEL.Size = New System.Drawing.Size(379, 28)
        Me.RECORDSLABEL.TabIndex = 431
        Me.RECORDSLABEL.Text = "عدد السجلات"
        Me.RECORDSLABEL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PREVIOUSBUTTON
        '
        Me.PREVIOUSBUTTON.AutoSize = True
        Me.PREVIOUSBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.PREVIOUSBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right
        Me.PREVIOUSBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PREVIOUSBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PREVIOUSBUTTON.Location = New System.Drawing.Point(464, 2)
        Me.PREVIOUSBUTTON.Name = "PREVIOUSBUTTON"
        Me.PREVIOUSBUTTON.Size = New System.Drawing.Size(40, 28)
        Me.PREVIOUSBUTTON.TabIndex = 676
        Me.PREVIOUSBUTTON.UseVisualStyleBackColor = False
        '
        'FIRSTBUTTON
        '
        Me.FIRSTBUTTON.AutoSize = True
        Me.FIRSTBUTTON.BackColor = System.Drawing.Color.Transparent
        Me.FIRSTBUTTON.BackgroundImage = Global.CC_JO.My.Resources.Resources.bullet_arrow_right_2
        Me.FIRSTBUTTON.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.FIRSTBUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FIRSTBUTTON.Location = New System.Drawing.Point(505, 2)
        Me.FIRSTBUTTON.Name = "FIRSTBUTTON"
        Me.FIRSTBUTTON.Size = New System.Drawing.Size(40, 28)
        Me.FIRSTBUTTON.TabIndex = 675
        Me.FIRSTBUTTON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.FIRSTBUTTON.UseVisualStyleBackColor = False
        '
        'BackWorker2
        '
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Controls.Add(Me.Panel3)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(5, 108)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(549, 101)
        Me.GroupBox1.TabIndex = 86
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "المستندات"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.TextReceiptVoucherFrom)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Controls.Add(Me.Label2)
        Me.Panel3.Controls.Add(Me.TextRecordingDocumentFrom)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.TextReceiptVoucher)
        Me.Panel3.Controls.Add(Me.TextPaymentVoucherFrom)
        Me.Panel3.Controls.Add(Me.Label1)
        Me.Panel3.Controls.Add(Me.TextPaymentVoucher)
        Me.Panel3.Controls.Add(Me.Label3)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.TextRecordingDocument)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(3, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(543, 80)
        Me.Panel3.TabIndex = 87
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(5, 211)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(549, 145)
        Me.GroupBox2.TabIndex = 87
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "النقدية"
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.TextcurrentAmounts)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.TextNotes)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.PictureBox5)
        Me.Panel4.Controls.Add(Me.PictureBox2)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.TextAmountsInWriting)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 18)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(543, 124)
        Me.Panel4.TabIndex = 87
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.SteelBlue
        Me.Panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel5.Controls.Add(Me.Label13)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(557, 38)
        Me.Panel5.TabIndex = 88
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label13.Font = New System.Drawing.Font("Traditional Arabic", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Image = Global.CC_JO.My.Resources.Resources.notes_32x32
        Me.Label13.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label13.Location = New System.Drawing.Point(0, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(555, 36)
        Me.Label13.TabIndex = 16
        Me.Label13.Text = "محضر جرد صندوق"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TextcurrentAmounts
        '
        Me.TextcurrentAmounts.EditValue = "0"
        Me.TextcurrentAmounts.Location = New System.Drawing.Point(307, 4)
        Me.TextcurrentAmounts.Name = "TextcurrentAmounts"
        Me.TextcurrentAmounts.Properties.Appearance.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.TextcurrentAmounts.Properties.Appearance.FontStyleDelta = System.Drawing.FontStyle.Bold
        Me.TextcurrentAmounts.Properties.Appearance.Options.UseFont = True
        Me.TextcurrentAmounts.Properties.Appearance.Options.UseTextOptions = True
        Me.TextcurrentAmounts.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.TextcurrentAmounts.Properties.BeepOnError = False
        Me.TextcurrentAmounts.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        Me.TextcurrentAmounts.Properties.MaskSettings.Set("MaskManagerType", GetType(DevExpress.Data.Mask.NumericMaskManager))
        Me.TextcurrentAmounts.Properties.MaskSettings.Set("mask", "f3")
        Me.TextcurrentAmounts.Properties.UseMaskAsDisplayFormat = True
        Me.TextcurrentAmounts.Size = New System.Drawing.Size(126, 22)
        Me.TextcurrentAmounts.TabIndex = 959
        '
        'FormInventoryBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(557, 426)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Times New Roman", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormInventoryBox"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "محضر جرد صندوق"
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.TextcurrentAmounts.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TextNo As System.Windows.Forms.TextBox
    Friend WithEvents DateT As System.Windows.Forms.DateTimePicker
    Friend WithEvents TextReceiptVoucherFrom As System.Windows.Forms.TextBox
    Friend WithEvents TextReceiptVoucher As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextPaymentVoucherFrom As System.Windows.Forms.TextBox
    Friend WithEvents TextPaymentVoucher As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextRecordingDocumentFrom As System.Windows.Forms.TextBox
    Friend WithEvents TextRecordingDocument As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextAmountsInWriting As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNotes As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents BackWorker2 As System.ComponentModel.BackgroundWorker
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents ComboCB1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Private WithEvents RECORDSLABEL As Label
    Private WithEvents FIRSTBUTTON As Button
    Private WithEvents PREVIOUSBUTTON As Button
    Private WithEvents NEXTBUTTON As Button
    Private WithEvents LASTBUTTON As Button
    Friend WithEvents BUTTONCANCEL As Button
    Friend WithEvents EDITBUTTON As Button
    Friend WithEvents SAVEBUTTON As Button
    Friend WithEvents ADDBUTTON As Button
    Friend WithEvents PRINTBUTTON As Button
    Private WithEvents TextCB2 As TextBox
    Private WithEvents GroupBox1 As GroupBox
    Friend WithEvents Panel3 As Panel
    Private WithEvents GroupBox2 As GroupBox
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label13 As Label
    Friend WithEvents TextcurrentAmounts As DevExpress.XtraEditors.TextEdit
End Class
